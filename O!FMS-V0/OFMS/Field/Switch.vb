Imports System.Threading
Imports System.Net.Sockets
Imports System.Net
Imports O_FMS_V0.Team
Imports System.Text

Public Class Switch
    'port for telneting the switch'
    Public Shared switchTelnetPort As Integer = 23

    Public Shared Red1VLAN = 10
    Public Shared Red2VLAN = 20
    Public Shared Red3VLAN = 30
    Public Shared Blue1VLAN = 40
    Public Shared Blue2VLAN = 50
    Public Shared Blue3VLAN = 60

    Public Shared addTeamVlanCommand = ""
    Public Shared returnedData

    Structure Switch
        Public Shared address As String
        Public Shared port As Integer
        Public Shared password As String
        Public Shared mutex As New Mutex
    End Structure

    'The DS will try to connect to this address
    Public Shared ServerIpAddress As String = "10.0.100.5"

    Public Shared Function newSwitch(address As String, password As String)
        Return Switch.address = address And Switch.port = switchTelnetPort And Switch.password = password
    End Function

    Public Shared Function configureTeamEthernet(red1 As Team, red2 As Team, red3 As Team, blue1 As Team, blue2 As Team, blue3 As Team)
        Switch.mutex.ReleaseMutex()

        'Determines what new VLANs are needed
        Dim oldTeamVlans = getTeamVlans()
        If oldTeamVlans Is Nothing Then
            MessageBox.Show("No VLANs Avalible")
        End If

        replaceVlan(red1, Red1VLAN)
        replaceVlan(red2, Red2VLAN)
        replaceVlan(red3, Red3VLAN)
        replaceVlan(blue1, Blue1VLAN)
        replaceVlan(blue2, Blue2VLAN)
        replaceVlan(blue3, Blue3VLAN)

        Dim removeTeamVlansCommand = ""
        'Builds the team vlan removal command'
        removeTeamVlansCommand = String.Format("interface Vlan{0}\nno ip address\nno access-list 1{1}\n" +
                                                       "interface Vlan{2}\nno ip address\nno access-list 1{3}\n" +
                                                       "interface Vlan{4}\nno ip address\nno access-list 1{5}\n" +
                                                       "interface Vlan{6}\nno ip address\nno access-list 1{7}\n" +
                                                       "interface Vlan{8}\nno ip address\nno access-list 1{9}\n" +
                                                       "interface Vlan{10}\nno ip address\nno access-list 1{11}\n", Red1VLAN, Red1VLAN,
                                                        Red2VLAN, Red2VLAN, Red3VLAN, Red3VLAN, Blue1VLAN, Blue1VLAN, Blue2VLAN, Blue2VLAN,
                                                        Blue3VLAN, Blue3VLAN)

        'Builds and run the overall command for the team VLANs'
        Dim command = removeTeamVlansCommand + addTeamVlanCommand
        If Len(command) > 0 Then
            runConfigCommand(removeTeamVlansCommand + addTeamVlanCommand)
        End If
        Return 0
    End Function

    Public Shared Function getTeamVlans()
        Return 0
    End Function

    Public Shared Function replaceVlan(team As Team, vlan As Integer)
        Dim oldTeamVlans = getTeamVlans()

        If team Is Nothing Then
            MessageBox.Show("Team is nothing, can't configure the switch")
        End If
        'add vlan checking before command?'
        addTeamVlanCommand = String.Format(
                                     "ip dhcp excluded-address 10.{0}.{1}.100 10.{2}.{3}.100\n" +
                                                 "no ip dhcp pool dhcp{4}\n" +
                                                 "ip dhcp pool dhcp{5}\n" +
                                                 "network 10.{6}.{7}.0 255.255.255.0\n" +
                                                 "default-router 10.{8}.{9}.61\n" +
                                                 "lease 7\n" +
                                                 "no access-list 1{10}\n" +
                                                 "access-list 1{11} permit ip 10.{12}.{13}.0 0.0.0.255 host {14}\n" +
                                                 "access-list 1{15} permit udp any eq bootpc any eq bootps\n" +
                                                 "interface Vlan{16}\nip address 10.{17}.{18}.61 255.255.255.0\n",
                                     Team.Id / 100, Team.Id Mod 100, Team.Id / 100, Team.Id Mod 100, vlan, vlan,
                                     Team.Id / 100, Team.Id Mod 100, Team.Id / 100, Team.Id Mod 100, vlan, vlan, Team.Id / 100, Team.Id Mod 100,
                                     ServerIpAddress, vlan, vlan, Team.Id / 100, Team.Id Mod 100)

        Return addTeamVlanCommand
    End Function

    Public Shared Function runCommand(command As String)
        Dim client As New TcpClient()
        'Connects to the switch'
        client.Connect(ServerIpAddress, Switch.port)
        'setup a network stream'
        Dim NetworkStream As NetworkStream = client.GetStream()
        'Checks if the network stream can transport data'
        If NetworkStream.CanWrite Then
            'Format the string for username and password'
            Dim commandString As String = String.Format("{0}\nenable\n{1}\nterminal length 0\n{2}exit\n", Switch.password, Switch.password, command)
            Dim networkByte As [Byte]() = Encoding.ASCII.GetBytes(commandString)
            NetworkStream.Write(networkByte, 0, networkByte.Length)
        End If

        NetworkStream.Flush()

        If NetworkStream.CanRead Then
            Dim returnedByte(client.ReceiveBufferSize) As Byte
            NetworkStream.Read(returnedByte, 0, CInt(client.ReceiveBufferSize))
            returnedData = Encoding.ASCII.GetString(returnedByte)
        End If

        Return returnedData
    End Function

    Public Shared Function runConfigCommand(command As String)
        Return runCommand(String.Format("config terminal\n{0}send\ncopy running-config startup-config\n\n", command))
    End Function
End Class
