Imports Renci.SshNet

Public Class AccessPoint
    Public Shared accessPointSshPort As Integer = 22
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

    Structure sshOutput
        Public Shared output As SshCommand
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

    Public Shared Sub configureAdminWifi()
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

    Public Shared Function generateAccessPointConfig()
        Dim commands = createTeamCommands(1, "Add WPA Key", Main_Panel.RedTeam1.Text) +
            createTeamCommands(2, "", Main_Panel.RedTeam2.Text) +
            createTeamCommands(3, "", Main_Panel.RedTeam3.Text) +
            createTeamCommands(4, "", Main_Panel.BlueTeam1.Text) +
            createTeamCommands(5, "", Main_Panel.BlueTeam2.Text) +
            createTeamCommands(6, "", Main_Panel.BlueTeam3.Text)

        Return commands
    End Function

    'This function creates the team id and WPA key part of the UCI Batch command for the Access Point
    Public Shared Function createTeamCommands(position As Integer, WpaKey As String, teamNumber As String)
        Dim commands As String

        If teamNumber.Length = 0 Then
            commands = String.Format("set wireless.@wifi-iface[{0}].disabled='0'", position) & vbNewLine &
                    String.Format("set wireless.@wifi-iface[{0}].ssid='no-team-{1}'", position, position) & vbNewLine &
                    String.Format("set wireless.@wifi-iface[{0}].key='no-team-{1}'", position, position) & vbNewLine &
                    "commit wireless" & vbNewLine

        Else

            commands = String.Format("set wireless.@wifi-iface[{0}].disabled='0'", position) & vbNewLine &
            String.Format("set wireless.@wifi-iface[{0}].ssid='{1}'", position, teamNumber) & vbNewLine &
            String.Format("set wireless.@wifi-iface[{0}].key='{1}'", position, WpaKey) & vbNewLine &
            "commit wireless" & vbNewLine

        End If

        Return commands
    End Function

    Public Shared Sub handleTeamWifiConfiguration()
        Dim config = generateAccessPointConfig()

        If config Is Nothing Then
            MessageBox.Show(String.Format("Failed to configure wifi: {0}", config))
        End If

        Dim command = String.Format("uci batch <<ENDCONFIG && wifi radio0" & vbNewLine & "{0}" & vbNewLine & "ENDCONFIG" & vbNewLine, config)
        Dim attemptCount = 1

        'loops forever until confguration of the AP is correct for the match'
        Do
            Dim status = RunTeamCommand(command)
            Threading.Thread.Sleep(accessPointCommandTimeoutSec * 1000)

            If status Is Nothing Then
                MessageBox.Show("Access Point configured correctly for the match")
                Exit Do
            End If

            If err IsNot Nothing Then
                MessageBox.Show("Error team wifi is not configured")
            End If

            'Shows the retries in a message box'
            MessageBox.Show("Wifi configuration failed retrying!!!")
            attemptCount = attemptCount + 1
        Loop

    End Sub

    Public Shared Sub RunCommand(command() As String)

    End Sub

    Public Shared Function RunTeamCommand(command As String)
        Dim sshClient As SshClient
        Dim sshConnectionInfo As PasswordConnectionInfo

        sshConnectionInfo = New PasswordConnectionInfo(AccessPoint.address, AccessPoint.username, AccessPoint.password)
        sshClient = New SshClient(sshConnectionInfo)

        'Checks if the client is being used if so exits the function'
        If Not sshClient Is Nothing AndAlso sshClient.IsConnected Then
            Exit Function
        End If

        sshClient.Connect()



    End Function

    Public Shared Function updateTeamStatuses()
        Return 0
    End Function

    Public Shared Function configIsCorrectForTeams()
        'Dim team = 0

        'If AccessPoint.initalStatusFetched = False Then
        '    Return False
        'End If

        'For Each team In teams
        '    Dim exspectedTeamId = 0

        '    If team Then

        '    End If
        'Next
        Return 0
    End Function

    'Public Shared red1Vlan = 10
    'Public Shared red2Vlan = 20
    'Public Shared red3Vlan = 30
    'Public Shared blue1Vlan = 40
    'Public Shared blue2Vlan = 50
    'Public Shared blue3Vlan = 60

    'Public Shared APUserName As String = "root"
    'Public Shared APPassWord As String = "1234Five"
    'Public Shared APAddress As String = "10.0.100.3"
    'Public Shared address As String
    'Public Shared port As Integer
    'Public Shared username As String
    'Public Shared password As String
    ''Public teamChannel As Integer = 11
    'Public Shared TChannel As Integer = 11
    'Public Shared adminChannel As String
    'Public Shared adminWpaKey As String
    'Public Shared mutex As New Threading.Mutex
    'Public Shared config As Renci.SshNet.SshClient
    'Public Shared sshConnectionInfo As Renci.SshNet.PasswordConnectionInfo
    'Public Shared Red1 As Team_Networks
    'Public Shared red2 As Team_Networks
    'Public Shared red3 As Team_Networks
    'Public Shared blue1 As Team_Networks
    'Public Shared blue2 As Team_Networks
    'Public Shared blue3 As Team_Networks


    'Public Shared i As Int16 = 6, j As Int16 = 6, k As Int16 = 6, l As Int16 = 6, m As Int16 = 6, n As Int16 = 6
    'Public Shared Temp(i) As String

    'Public Shared TeamChannel(6), Networks(6), vlan(6), SSID(m), WPAKEY(6)







    'Public Shared Sub Main()
    '    i = 1
    '    j = 1
    '    k = 1
    '    l = 1
    '    m = 1
    '    n = 1

    '    While i < 7
    '        Console.WriteLine(i)
    '        Temp(1) = "C:\1\TempRed1.txt"
    '        Temp(2) = "C:\1\TempRed2.txt"
    '        Temp(3) = "C:\1\TempRed3.txt"
    '        Temp(4) = "C:\1\TempBlue1.txt"
    '        Temp(5) = "C:\1\TempBlue2.txt"
    '        Temp(6) = "C:\1\TempBlue3.txt"

    '        adminChannel = "AdminChannel"
    '        adminWpaKey = "Admin Key"

    '        teamChannel(1) = TChannel
    '        teamChannel(2) = TChannel
    '        teamChannel(3) = TChannel
    '        teamChannel(4) = TChannel
    '        teamChannel(5) = TChannel
    '        teamChannel(6) = TChannel

    '        Networks(1) = "redNet1"
    '        Networks(2) = "redNet2"
    '        Networks(3) = "redNet3"
    '        Networks(4) = "BlueNet1"
    '        Networks(5) = "BlueNet2"
    '        Networks(6) = "BlueNet3"

    '        vlan(1) = 10
    '        vlan(2) = 20
    '        vlan(3) = 30
    '        vlan(4) = 40
    '        vlan(5) = 50
    '        vlan(6) = 60

    '        SSID(1) = "TeamNo1"
    '        SSID(2) = "TeamNo2"
    '        SSID(3) = "TeamNo3"
    '        SSID(4) = "TeamNo4"
    '        SSID(5) = "TeamNo5"
    '        SSID(6) = "TeamNo6"

    '        WPAKEY(1) = "Key1"
    '        WPAKEY(2) = "Key2"
    '        WPAKEY(3) = "Key3"
    '        WPAKEY(4) = "Key4"
    '        WPAKEY(5) = "Key5"
    '        WPAKEY(6) = "Key6"

    '        'Temp(i)
    '        'My.Computer.FileSystem.WriteAllText(My.Computer.FileSystem.ReadAllText("C:\OFMS\APTemplate.txt").Replace("{{.AdminChannel}}", adminChannel).Replace("{{.AdminWpaKey}}", adminWpaKey).Replace("{{.TeamChannel}}", TeamChannel(j)).Replace("{{$vlan}}", vlan(l)).Replace("{{$Id}}", SSID(m)).Replace("{{$WpaKey}}", WPAKEY(n)).Replace("{{end}}", ""), False)
    '        i = i + 1
    '        j = j + 1
    '        k = k + 1
    '        l = l + 1
    '        m = m + 1
    '        n = n + 1

    '    End While
    '    i = 1
    '    While i < 7
    '        My.Computer.FileSystem.WriteAllText("C:\AccessPointconfig.Txt", My.Computer.FileSystem.ReadAllText(Temp(i)), True)
    '        i = i + 1

    '    End While
    'End Sub



    'Public Shared Function newAccessPoint(ap As AccessPoint)
    '    Return address = APAddress & port = accessPointSshPort & username = APUserName & password = APPassWord &
    'TChannel = TChannel & adminChannel = adminChannel & adminWpaKey = adminWpaKey
    'End Function
    'Public Function generateAccessPointConfig(red1, red2, red3, blue1, blue2, blue3)


    'End Function

    'Public Function configureTeamWifi(ap As AccessPoint)
    '    ap.mutex.Close()
    '    Dim config = generateAccessPointConfig(Red1, red2, red3, blue1, blue2, blue3)
    '    Dim command = String.Format("cat <<ENDCONFIG > /etc/config/wireless && wifi radio0\n%sENDCONFIG\n", config)
    '    Return ap.runCommand(command)
    'End Function

    'Public Function configureAdminWifi(ap As AccessPoint)
    '    Dim config = generateAccessPointConfig(0, 0, 0, 0, 0, 0)

    '    'changed Dim command As Renci.SshNet.SshCommand = String.Format("cat << ENDCONFIG > /etc/config/wireless && wifi radio1\n%sENDCONFIG\n", config)
    '    Dim command = String.Format("cat << ENDCONFIG > /etc/config/wireless && wifi radio1\n%sENDCONFIG\n", config)
    '    Return ap.runCommand(command)
    'End Function


    'Public Function sendCommand(cmd As String, s As ShellStream) As String
    '    Dim reader As StreamReader
    '    Dim writer As StreamWriter
    '    Try
    '        reader = New StreamReader(s)
    '        writer = New StreamWriter(s)
    '        writer.AutoFlush = True
    '        writer.WriteLine(cmd)
    '        While s.Length = 0
    '            Threading.Thread.Sleep(500)
    '        End While

    '    Catch ex As Exception
    '        Console.WriteLine("Send Command(" & cmd & ") caught Exception: ex" & ex.ToString)
    '    End Try
    '    Return reader.ReadToEnd

    'End Function

    'Public Function runCommand()

    '    Dim linereader As New StreamReader("c:\AccessPointconfig.Txt", Encoding.Default)

    '    Try
    '        Using client = New SshClient(APAddress, APUserName, APPassWord)
    '            client.Connect()
    '            Using ss As ShellStream = client.CreateShellStream("dumb", 80, 24, 800, 600, 1024)
    '                Debug.WriteLine("1 [" & sendCommand("enable", ss) & "]")
    '                While (linereader.Peek >= 0)

    '                    Debug.WriteLine("1 [" & sendCommand(linereader.ReadLine, ss) & "]")

    '                End While

    '            End Using
    '            client.Disconnect()
    '        End Using

    '    Catch ex As Exception
    '        Debug.WriteLine("CAUGHT: " & ex.ToString())
    '    Finally
    '        Console.WriteLine("hit enter to exit")
    '        Dim blah As String = Console.ReadLine()
    '    End Try
    '    Return 0
    'End Function


End Class