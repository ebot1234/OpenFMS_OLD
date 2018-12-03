Imports O_FMS_V0.Main_Panel
Imports System.Net.Sockets
Imports System.Net
Imports System.Text
Imports O_FMS_V0.PLC_Comms_Server



Public Class DriverStations
    Public packetCount As Integer = 0
    Public DSUpdSendPort As Int32 = 1121
    Public DSUdpReceivePort As Int32 = 1160
    Public DSTcpPort As Int32 = 1750
    Public Auto As Boolean = False
    Public Enabled As Boolean = False
    Public Estop As Boolean = False
    Public DsConn As New UdpClient
    Public DsTcpClient As TcpClient
    Public DSEndpoint As IPEndPoint = New IPEndPoint(IPAddress.Any, DSUdpReceivePort)
    Public BatteryVoltage As Double
    Public RadioLinked As Boolean
    Public RobotLinked As Boolean
    Public bufferSize As Integer = 1024
    Public packet(32) As Byte
    Public tcpStream As NetworkStream
    Public FMS_IP As IPAddress = IPAddress.Parse("10.0.100.5")
    Public DsTcpServer As TcpListener = New TcpListener(FMS_IP, DSTcpPort)

    Public Sub sendPacketDS()
        Dim packet() As Byte = encodeControlPacket()
        If Auto = True Then
            DsConn.Send(packet, packet.Length)
        End If

        If Estop = True Then
            DsConn.Send(packet, packet.Length)
        End If

        If Enabled = True Then
            DsConn.Send(packet, packet.Length)
        End If

    End Sub

    Public Sub ListenForDSUdp(allianceStation As String)
        'Team Id for getting team number from DS'
        Dim teamId As Integer = 0
        Dim DSBytes As Byte()

        Try
            'Recieves the data from the DS'
            DSBytes = DsConn.Receive(DSEndpoint)
            'Gets the team id from the DSByte structure'
            teamId = DSBytes(4) << 8 + DSBytes(5)
            'Checks the team id from the main panel'
            Dim teamNumber As Integer = Convert.ToInt32(allianceStation)
            'Gets the Voltage but this is not implemented Yet!'
            BatteryVoltage = DSBytes(6) + DSBytes(7) / 256

            'Gets the robot if it is linked'
            If allianceStation = Main_Panel.RedTeam1.Text Then
                If RobotLinked = DSBytes(3) = &H20 Then
                    Robot_Linked_Red1 = True
                End If
            End If

            If allianceStation = Main_Panel.RedTeam2.Text Then
                If RobotLinked = DSBytes(3) = &H20 Then
                    Robot_Linked_Red1 = True
                End If
            End If

            If allianceStation = Main_Panel.RedTeam3.Text Then
                If RobotLinked = DSBytes(3) = &H20 Then
                    Robot_Linked_Red1 = True
                End If
            End If

            If allianceStation = Main_Panel.BlueTeam1.Text Then
                If RobotLinked = DSBytes(3) = &H20 Then
                    Robot_Linked_Red1 = True
                End If
            End If

            If allianceStation = Main_Panel.BlueTeam2.Text Then
                If RobotLinked = DSBytes(3) = &H20 Then
                    Robot_Linked_Red1 = True
                End If
            End If

            If allianceStation = Main_Panel.BlueTeam3.Text Then
                If RobotLinked = DSBytes(3) = &H20 Then
                    Robot_Linked_Red1 = True
                End If
            End If

        Catch e As Exception
            MessageBox.Show("DS Listener for UDP has problems")
        End Try
        If allianceStation = teamId Then
            Debug.WriteLine("Yay the driver station is connected")
        Else
            Threading.Thread.Sleep(500)
            'Closes if the id doesn't match the main panel'
            DsConn.Close()
        End If
    End Sub

    Public Function encodeControlPacket()
        'Using the driver station packet structure from Cheesy Arena'
        Dim data(22) As Byte

        data(0) = packetCount >> 8 And &HFF
        data(1) = packetCount And &HFF

        'Protocol version'
        data(2) = 0

        'Robot status byte'
        data(3) = 0

        If Auto = True Then
            data(3) = &H2
        End If

        If Enabled = True Then
            data(3) = &H4
        End If

        If Estop = True Then
            data(3) = &H80
        End If
        'Unused byte or unknown'
        data(4) = 0
        'Alliance Station byte, TODO add map of alliance stations'
        data(5) = 0

        'driver station match type is practice for right now'
        data(6) = 1

        'Match Number'
        data(7) = 0
        data(8) = 1

        'repeat match number'
        data(9) = 1

        'Current time since 1900'
        Dim currentTime = DateAndTime.Now
        'defines the value of a nanosecond'
        Dim nanoseconds As Integer = (currentTime.Ticks / TimeSpan.TicksPerMillisecond / 10) * 100
        data(10) = (((nanoseconds / 1000) >> 24) & &HFF)
        data(11) = (((nanoseconds / 1000) >> 16) & &HFF)
        data(12) = (((nanoseconds / 1000) >> 8) & &HFF)
        data(13) = ((nanoseconds / 1000) & &HFF)
        data(14) = (currentTime.Second)
        data(15) = (currentTime.Minute)
        data(16) = (currentTime.Hour)
        data(17) = (currentTime.Day)
        data(18) = (currentTime.Month)
        data(19) = (currentTime.Year - 1900)

        'Time left in the match'
        data(20) = (Main_Panel.matchTimerLbl.Text >> 8 & &HFF)
        data(21) = (Main_Panel.matchTimerLbl.Text & &HFF)

        packetCount = packetCount + 1

        Return data
    End Function

    Public Sub ListenForTCPConnections()
        DsTcpClient = DsTcpServer.AcceptTcpClient

        Dim buffer(5) As Byte

        DsTcpClient.GetStream().Read(buffer, 0, buffer.Length)

        If (buffer(0) = 0 & buffer(1) = 3 & buffer(2) = 2) Then

        End If
    End Sub

    Public Sub sendGameDataPacket(gameData As String)
        packet = Encoding.ASCII.GetBytes(gameData)
        DsTcpClient.GetStream.Write(packet, 0, packet.Length)
    End Sub
End Class
