Imports Renci.SshNet
Imports System.Threading
Imports System.IO

Public Class Switch
    Public Shared Red1 As String
    Public Shared Red2 As String
    Public Shared Red3 As String
    Public Shared Blue1 As String
    Public Shared Blue2 As String
    Public Shared Blue3 As String

    'port for SSHing the switch'
    Public Shared switchSshPort As Integer = 23

    Public Shared Red1VLAN = 10
    Public Shared Red2VLAN = 20
    Public Shared Red3VLAN = 30
    Public Shared Blue1VLAN = 40
    Public Shared Blue2VLAN = 50
    Public Shared Blue3VLAN = 60

    Public Shared addTeamVlanCommand = ""
    Public Shared returnedData

    Public Shared Reader As StreamReader
    Public Shared Writer As StreamWriter

    Structure Switch
        Public Shared address As String
        Public Shared port As Integer
        Public Shared password As String
        Public Shared timeOut As Integer
    End Structure

    'The DS will try to connect to this address
    Public Shared ServerIpAddress As String = "10.0.100.5"

    Public Shared Function configureTeamEthernet(red1 As String, red2 As String, red3 As String, blue1 As String, blue2 As String, blue3 As String)

        'Sets the Vlans command for each team in the match'
        replaceVlan(red1, Red1VLAN)
        replaceVlan(red2, Red2VLAN)
        replaceVlan(red3, Red3VLAN)
        replaceVlan(blue1, Blue1VLAN)
        replaceVlan(blue2, Blue2VLAN)
        replaceVlan(blue3, Blue3VLAN)

        Dim removeTeamVlansCommand = ""
        'Builds the team vlan removal command'
        removeTeamVlansCommand = String.Format("interface Vlan{0}" & vbNewLine & "no ip address" & vbNewLine &
                                                        "no access-list 1{1}" & vbNewLine &
                                                       "interface Vlan{2}" & vbNewLine & "no ip address" & vbNewLine &
                                                       "no access-list 1{3}" & vbNewLine &
                                                       "interface Vlan{4}" & vbNewLine & "no ip address" & vbNewLine &
                                                       "no access-list 1{5}" & vbNewLine &
                                                       "interface Vlan{6}" & vbNewLine & "no ip address" & vbNewLine &
                                                       "no access-list 1{7}" & vbNewLine &
                                                       "interface Vlan{8}" & vbNewLine & "no ip address" & vbNewLine &
                                                       "no access-list 1{9}" & vbNewLine &
                                                       "interface Vlan{10}" & vbNewLine & "no ip address" & vbNewLine &
                                                       "no access-list 1{11}" & vbNewLine, Red1VLAN, Red1VLAN,
                                                        Red2VLAN, Red2VLAN, Red3VLAN, Red3VLAN, Blue1VLAN, Blue1VLAN, Blue2VLAN, Blue2VLAN,
                                                        Blue3VLAN, Blue3VLAN)

        'Builds and run the overall command for the team VLANs'
        Dim command = removeTeamVlansCommand + addTeamVlanCommand
        If Len(command) > 0 Then
            runConfigCommand(removeTeamVlansCommand + addTeamVlanCommand)
        End If
        Return 0
    End Function

    Public Shared Function replaceVlan(teamNumber As String, vlan As Integer)
        'Determines the team number ip address format for use with the command'
        Select Case (teamNumber.Length)
            Case 4
                teamNumber = teamNumber.Substring(0, 2) + "." + teamNumber.Substring(2, 2)
            Case 3
                teamNumber = teamNumber.Substring(0, 1) + "." + teamNumber.Substring(1, 2)
            Case 2
                teamNumber = "0." + teamNumber.Substring(0, 2)
            Case 1
                teamNumber = "0.0" + teamNumber.Substring(0, 1)
            Case Else
                MessageBox.Show(String.Format("Team: {0} doesn't work to short or long", teamNumber))
        End Select

        If teamNumber.Length = 0 Then
            MessageBox.Show("Team is nothing, can't configure the switch")
        End If
        'add vlan checking before command?'
        addTeamVlanCommand = String.Format(
                                     "ip dhcp excluded-address 10.{0}.100 10.{1}.100" & vbNewLine &
                                                 "no ip dhcp pool dhcp{2}" & vbNewLine &
                                                 "ip dhcp pool dhcp{3}" & vbNewLine &
                                                 "network 10.{4}.0 255.255.255.0" & vbNewLine &
                                                 "default-router 10.{5}.61" & vbNewLine &
                                                 "lease 7" & vbNewLine &
                                                 "no access-list 1{6}" & vbNewLine &
                                                 "access-list 1{7} permit ip 10.{8}.0 0.0.0.255 host {9}" & vbNewLine &
                                                 "access-list 1{10} permit udp any eq bootpc any eq bootps" & vbNewLine &
                                                 "interface Vlan{10}" & vbNewLine & "ip address 10.{11}.61 255.255.255.0" & vbNewLine,
                                      teamNumber, teamNumber, vlan, vlan, teamNumber, teamNumber, vlan, vlan, teamNumber,
                                      ServerIpAddress, vlan, vlan, teamNumber)

        Return addTeamVlanCommand
    End Function
    'Sends the commands via ssh'
    Public Shared Function runCommand(command As String)
        Try
            Using client = New SshClient(Switch.address, "OFMS", "OFMS")
                Using ss As ShellStream = client.CreateShellStream("dumb", 80, 24, 800, 600, 1024)
                    sendCommand(command, ss)
                End Using
                client.Disconnect()
            End Using
        Catch ex As Exception
            Dim errorString As String = String.Format("SSH Problems {0}", command)
            MessageBox.Show(errorString)
        End Try
        Return 0
    End Function

    Public Shared Function runConfigCommand(command As String)
        Return runCommand(String.Format("config terminal" & vbNewLine & "{0}send" & vbNewLine & "copy running-config startup-config" & vbNewLine & vbNewLine, command))
    End Function

    Public Shared Function sendCommand(cmd As String, s As ShellStream) As String
        Try
            Reader = New StreamReader(s)
            Writer = New StreamWriter(s)
            Writer.AutoFlush = True
            Writer.WriteLine(cmd)
            While s.Length = 0
                Thread.Sleep(500)
            End While
        Catch ex As Exception
            Dim errorString As String = String.Format("Error sending commands to the switch. {0}", cmd)
            MessageBox.Show(errorString)
        End Try
        Return Reader.ReadToEnd()
    End Function
End Class
