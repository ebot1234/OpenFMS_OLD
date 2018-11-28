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
    Public DsTcpServer As TcpListener
    Public DsTcpClient As TcpClient
    Public DSEndpoint As IPEndPoint = New IPEndPoint(IPAddress.Any, DSUdpReceivePort)
    Public BatteryVoltage As Double
    Public RadioLinked As Boolean
    Public RobotLinked As Boolean
    Public bufferSize As Integer = 1024
    Public packet(32) As Byte
    Public tcpStream As NetworkStream

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
        'Match Type info from SQL/Main Panel'
        'Add that'

        data(9) = 1

        'Add curent time'
        data(10) = 0
        'time is bytes 10-19'

        'Match Time for bytes 20 and 21'

        packetCount = packetCount + 1
        Return data
    End Function

    Public Sub ListenForTCPConnections(station As String, DSStation As Integer)
        Dim teamId As Integer = 0
        Dim receiveBuffer(bufferSize) As Byte
        Dim recieveByte(5) As Byte
        Dim bytesToRead As Integer = 0
        Dim nextReadCount, rc As Integer
        Dim teamNumber As Integer = 0
        'Creates the TCP server'
        DsTcpServer = New TcpListener(IPAddress.Any, DSTcpPort)
        'Starts the TCP server'
        DsTcpServer.Start()
        'Waiting for TCP client(DS)'
        DsTcpClient = DsTcpServer.AcceptTcpClient()
        'Gets the network stream for receiveing and writing data to the DS'
        tcpStream = DsTcpClient.GetStream
        recieveByte = BitConverter.GetBytes(bytesToRead)
        'Reads the size of bytes'
        tcpStream.Read(recieveByte, 0, recieveByte.Length)
        bytesToRead = BitConverter.ToInt32(recieveByte, 0)
        'Receive the data'
        While (bytesToRead > 0)
            If (bytesToRead < receiveBuffer.Length) Then
                nextReadCount = bytesToRead
            Else
                nextReadCount = receiveBuffer.Length
            End If
            'reads the data'
            rc = tcpStream.Read(receiveBuffer, 0, nextReadCount)
            'Team Id over tcp'
            teamId = recieveByte(3) << +recieveByte(4)
            teamNumber = Convert.ToInt32(station)

            If teamNumber = teamId Then
                'Do nothing this is good'
            ElseIf teamNumber <> teamId Then
                Console.WriteLine("Team is not allowed on the field right now")
                Threading.Thread.Sleep(1000)
                DsTcpClient.Close()
                DsTcpServer.Stop()
            End If

            bytesToRead -= rc
        End While

        Dim assignmentPacket(5) As Byte
        assignmentPacket(0) = 0
        assignmentPacket(1) = 3
        assignmentPacket(2) = 25
        assignmentPacket(3) = DSStation
        assignmentPacket(4) = 0
        tcpStream.Write(assignmentPacket, 0, assignmentPacket.Length)
    End Sub

    Public Sub sendGameDataPacket(gameData As String)
        packet = Encoding.ASCII.GetBytes(gameData)

        tcpStream.Write(packet, 0, packet.Length)
    End Sub
End Class
