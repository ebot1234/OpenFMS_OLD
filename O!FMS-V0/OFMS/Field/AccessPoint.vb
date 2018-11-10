Imports Renci.SshNet
Imports O_FMS_V0.Team_Networks
Imports System.IO
Imports System.Net.Dns
Imports O_FMS_V0.PLC_Comms_Server
Imports System.Text
Imports System




Public Class AccessPoint
    Public accessPointSshPort As Integer = 22
    Public accessPointConnectTimeoutSec = 1
    Public accessPointCommandTimeoutSec = 3
    Public accessPointRetryCount = 2

    Public red1Vlan = 10
    Public red2Vlan = 20
    Public red3Vlan = 30
    Public blue1Vlan = 40
    Public blue2Vlan = 50
    Public blue3Vlan = 60

    Dim APUserName As String = "root"
    Dim APPassWord As String = "1234Five"
    Dim APAddress As String = "10.0.100.3"
    Public address As String
    Public port As Integer
    Public username As String
    Public password As String
    'Public teamChannel As Integer = 11
    Public TChannel As Integer = 11
    Public adminChannel As Integer = 2
    Public adminWpaKey As String
    Public mutex As New Threading.Mutex
    Public config As Renci.SshNet.SshClient
    Private sshConnectionInfo As Renci.SshNet.PasswordConnectionInfo
    Public Red1 As Team_Networks
    Public red2 As Team_Networks
    Public red3 As Team_Networks
    Public blue1 As Team_Networks
    Public blue2 As Team_Networks
    Public blue3 As Team_Networks


    Dim i As Int16 = 6, j As Int16 = 6, k As Int16 = 6, l As Int16 = 6, m As Int16 = 6, n As Int16 = 6
    Public Temp(i) As String

    Public TeamChannel(j), Networks(k), vlan(l), SSID(m), WPAKEY(n)





    Sub Main()
        i = 1
        j = 1
        k = 1
        l = 1
        m = 1
        n = 1

        While i < 7
            Console.WriteLine(i)
            Temp(1) = "C:\1\TempRed1.txt"
            Temp(2) = "C:\1\TempRed2.txt"
            Temp(3) = "C:\1\TempRed3.txt"
            Temp(4) = "C:\1\TempBlue1.txt"
            Temp(5) = "C:\1\TempBlue2.txt"
            Temp(6) = "C:\1\TempBlue3.txt"

            AdminChannel = "AdminChannel"
            AdminWpaKey = "Admin Key"

            TeamChannel(1) = TChannel
            TeamChannel(2) = TChannel
            TeamChannel(3) = TChannel
            TeamChannel(4) = TChannel
            TeamChannel(5) = TChannel
            TeamChannel(6) = TChannel

            Networks(1) = "redNet1"
            Networks(2) = "redNet2"
            Networks(3) = "redNet3"
            Networks(4) = "BlueNet1"
            Networks(5) = "BlueNet2"
            Networks(6) = "BlueNet3"

            vlan(1) = 10
            vlan(2) = 20
            vlan(3) = 30
            vlan(4) = 40
            vlan(5) = 50
            vlan(6) = 60

            SSID(1) = "TeamNo1"
            SSID(2) = "TeamNo2"
            SSID(3) = "TeamNo3"
            SSID(4) = "TeamNo4"
            SSID(5) = "TeamNo5"
            SSID(6) = "TeamNo6"

            WPAKEY(1) = "Key1"
            WPAKEY(2) = "Key2"
            WPAKEY(3) = "Key3"
            WPAKEY(4) = "Key4"
            WPAKEY(5) = "Key5"
            WPAKEY(6) = "Key6"

            My.Computer.FileSystem.WriteAllText(Temp(i), My.Computer.FileSystem.ReadAllText("C:\APTemplate.txt").Replace("{{.AdminChannel}}", adminChannel).Replace("{{.AdminWpaKey}}", adminWpaKey).Replace("{{.TeamChannel}}", TeamChannel(j)).Replace("{{$vlan}}", vlan(l)).Replace("{{$Id}}", SSID(m)).Replace("{{$WpaKey}}", WPAKEY(n)).Replace("{{end}}", ""), False)
            i = i + 1
            j = j + 1
            k = k + 1
            l = l + 1
            m = m + 1
            n = n + 1

        End While
        i = 1
        While i < 7
            My.Computer.FileSystem.WriteAllText("C:\AccessPointconfig.Txt", My.Computer.FileSystem.ReadAllText(Temp(i)), True)
            i = i + 1

        End While
    End Sub



    'Public Function newAccessPoint(ap As AccessPoint)
    '    Return ap.address = APAddress & ap.port = accessPointSshPort & ap.username = APUserName & ap.password = APPassWord &
    '    ap.teamChannel = teamChannel & ap.adminChannel = adminChannel & ap.adminWpaKey = adminWpaKey
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


    Public Function sendCommand(cmd As String, s As ShellStream) As String
        Dim reader As StreamReader
        Dim writer As StreamWriter
        Try
            reader = New StreamReader(s)
            writer = New StreamWriter(s)
            writer.AutoFlush = True
            writer.WriteLine(cmd)
            While s.Length = 0
                Threading.Thread.Sleep(500)
            End While

        Catch ex As Exception
            Console.WriteLine("Send Command(" & cmd & ") caught Exception: ex" & ex.ToString)
        End Try
        Return reader.ReadToEnd

    End Function

    Public Function runCommand()

        Dim linereader As New StreamReader("c:\AccessPointconfig.Txt", Encoding.Default)

        Try
            Using client = New SshClient(APAddress, APUserName, APPassWord)
                client.Connect()
                Using ss As ShellStream = client.CreateShellStream("dumb", 80, 24, 800, 600, 1024)
                    Debug.WriteLine("1 [" & sendCommand("enable", ss) & "]")
                    While (linereader.Peek >= 0)

                        Debug.WriteLine("1 [" & sendCommand(linereader.ReadLine, ss) & "]")

                    End While

                End Using
                client.Disconnect()
            End Using

        Catch ex As Exception
            Debug.WriteLine("CAUGHT: " & ex.ToString())
        Finally
            Console.WriteLine("hit enter to exit")
            Dim blah As String = Console.ReadLine()
        End Try
        Return 0
    End Function


End Class