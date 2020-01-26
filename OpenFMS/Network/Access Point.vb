Imports System.Net
Imports System.Threading
Imports System.IO
Imports Renci.SshNet

Public Class Access_Point
    Public Shared SSH_Port = 22
    Public Shared accessPointConnectTimeoutSec = 1
    Public Shared accessPointCommandTimeoutSec = 3
    Public Shared accessPointRetryCount = 2
    Public Shared accessPointRequestBufferSize = 10
    Public Shared accessPointPollPeriodSecond = 5

    Structure AccessPoint
        Public Shared address As String
        Public Shared port As Integer
        Public Shared username As String
        Public Shared password As String
        Public Shared teamChannel As Integer
        Public Shared adminChannel As String
        Public Shared adminWpaKey As String
        Public Shared initalStatusFetched As Boolean
    End Structure

    Public Shared Sub SetSettings(address As String, password As String, username As String, teamChannel As Integer,
                                          adminChannel As Integer, adminWpaKey As String)

        address = AccessPoint.address
        username = AccessPoint.username
        password = AccessPoint.password
        teamChannel = AccessPoint.teamChannel
        adminChannel = AccessPoint.adminChannel
        adminWpaKey = AccessPoint.adminWpaKey
    End Sub

    Public Shared Sub ConfigureAdminChannel()
        Dim disabled = 0

        If AccessPoint.adminChannel = 0 Then
            disabled = 1
        End If


        Dim command As String
        command = String.Format("set wireless.radio0.channel='{0}'", AccessPoint.teamChannel) & vbNewLine &
        String.Format("set wireless.radio1.disabled='{0}'", disabled) & vbNewLine &
        String.Format("set wireless.radio.1.channel='{0}'", AccessPoint.adminChannel) & vbNewLine &
        String.Format("set wireless.@wifi-iface[0].key='{0}'", AccessPoint.adminWpaKey) & vbNewLine &
        "commit wireless"

        Dim wifiCommand
        wifiCommand = String.Format("uci batch <<ENDCONFIG && wifi radio1" & vbNewLine & "{0}" & vbNewLine & "ENDCONFIG", command)
        RunCommand(wifiCommand)
    End Sub
    'This builds the access points commmands for the teams'
'    Public Shared Function generateAccessPointConfig()
'        Dim commands = createTeamCommands(1, getTeamWPA(Main_Panel.RedTeam1.Text), Main_Panel.RedTeam1.Text) +
'            createTeamCommands(2, getTeamWPA(Main_Panel.RedTeam2.Text), Main_Panel.RedTeam2.Text) +
'            createTeamCommands(3, getTeamWPA(Main_Panel.RedTeam3.Text), Main_Panel.RedTeam3.Text) +
'            createTeamCommands(4, getTeamWPA(Main_Panel.BlueTeam1.Text), Main_Panel.BlueTeam1.Text) +
'            createTeamCommands(5, getTeamWPA(Main_Panel.BlueTeam2.Text), Main_Panel.BlueTeam2.Text) +
'            createTeamCommands(6, getTeamWPA(Main_Panel.BlueTeam3.Text), Main_Panel.BlueTeam3.Text) + "commit wireless"
'        Return commands
'    End Function

'    'This function creates the team id and WPA key part of the UCI Batch command for the Access Point
'    Public Shared Function createTeamCommands(position As Integer, WpaKey As String, teamNumber As String)
'        Dim commands As String

'        If teamNumber.Length = 0 Then
'            commands = String.Format("set wireless.@wifi-iface[{0}].disabled='0'", position) & vbNewLine &
'                    String.Format("set wireless.@wifi-iface[{0}].ssid='no-team-{1}'", position, position) & vbNewLine &
'                    String.Format("set wireless.@wifi-iface[{0}].key='no-team-{1}'", position, position) & vbNewLine


'        Else

'            commands = String.Format("set wireless.@wifi-iface[{0}].disabled='0'", position) & vbNewLine &
'            String.Format("set wireless.@wifi-iface[{0}].ssid='{1}'", position, teamNumber) & vbNewLine &
'            String.Format("set wireless.@wifi-iface[{0}].key='{1}'", position, WpaKey) & vbNewLine


'        End If

'        Return commands
'    End Function

'    Public Shared Sub handleTeamWifiConfiguration()
'        Dim config = generateAccessPointConfig()

'        If config Is Nothing Then
'            MessageBox.Show(String.Format("Failed to configure wifi: {0}", config))
'        End If

'        Dim command = String.Format("uci batch <<ENDCONFIG && wifi radio0" & vbNewLine & "{0}" & vbNewLine & "ENDCONFIG" & vbNewLine, config)
'        Dim attemptCount = 1

'        RunCommand(command)
'        Thread.Sleep(accessPointConnectTimeoutSec * 1000)

'    End Sub

'    Public Shared Function RunCommand(command As String)
'        Try
'            Using client = New SshClient(AccessPoint.address, AccessPoint.username, AccessPoint.password)
'                Using ss As ShellStream = client.CreateShellStream("dumb", 80, 24, 800, 600, 1024)
'                    sendCommand(command, ss)
'                End Using
'                client.Disconnect()
'            End Using
'        Catch ex As Exception
'            MessageBox.Show("Error running the ssh send command")
'        End Try
'        Return 0
'    End Function

'    Public Shared Function sendCommand(cmd As String, s As ShellStream)
'        Try
'            Reader = New StreamReader(s)
'            Writer = New StreamWriter(s)
'            Writer.AutoFlush = True
'            Writer.WriteLine(cmd)
'            While s.Length = 0
'                Thread.Sleep(500)
'            End While
'        Catch ex As Exception
'            MessageBox.Show("Error sending commands to the switch")
'        End Try
'        Return Reader.ReadToEnd()
'    End Function

'    'This grabs the wpa key from SQL from a team number'
'    Public Shared Function getTeamWPA(teamNumber As String) As String
'        Dim connection As New SqlConnection("data source=MY-PC\OFMS; Initial Catalog=OpenFMS; Integrated Security = true")
'        Dim data As String = String.Format("Select Wpa From teaminfo Where Id= {0}", teamNumber)
'        Dim selectData As New SqlCommand(data, connection)
'        'selectData.Parameters.Add("@Id", SqlDbType.Int)
'        Dim adapter As New SqlDataAdapter(selectData)
'        Dim table As New DataTable()
'        adapter.Fill(table)

'        If table.Rows.Count > 0 Then
'            wpakey = table.Rows(0)(0)
'        End If

'        Return wpakey
'    End Function

'    Public Shared Function generateWpaKey()
'        Dim iLength As Integer = 8
'        Dim rdm As New Random()
'        Dim allowChrs() As Char = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLOMNOPQRSTUVWXYZ0123456789".ToCharArray()
'        Dim sResult As String = ""

'        For i As Integer = 0 To iLength - 1
'            sResult += allowChrs(rdm.Next(0, allowChrs.Length))
'        Next

'        Return sResult
'    End Function


'    Public Shared Sub ExecuteQuery(query As String)
'        Dim connection As New SqlConnection("data source=MY-PC\OFMS; Initial Catalog=OpenFMS; Integrated Security = true")
'        Dim command As New SqlCommand(query, connection)
'        connection.Open()
'        command.ExecuteNonQuery()
'        connection.Close()
'    End Sub
'    End Sub
'End Class
