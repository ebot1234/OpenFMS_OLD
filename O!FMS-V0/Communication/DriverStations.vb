Imports System.Net.Sockets
Imports System.Net
Imports System.Text.RegularExpressions
Imports O_FMS_V0.PLC_Comms_Server
Imports O_FMS_V0.RandomString
Imports System.Threading


Public Class DriverStations
    'DS Varibles'
    Public Shared allianceStation
    Public Shared TeamNum As String
    Public Shared teamId
    Public Shared DsLinked As Boolean
    Public Shared RadioLinked As Boolean
    Public Shared RobotLinked As Boolean
    Public Shared BatteryVoltage
    Public Shared packetCount
    Public Shared Auto As Boolean
    Public Shared Enabled As Boolean
    Public Shared Estop As Boolean
    Public Shared float() As Single = {1.0F, 1.0F, 1.0F}
    Public Shared Listen As Boolean = False
    'TCP Listener/Server Varibles'
    Public Shared Listener As TcpListener
    Public Shared TCPListenPort As Integer = 1750
    Public Shared TcpClient As TcpClient
    Public Shared TCP_DS_IP As IPAddress
    'UDP Listener Varibles'
    Public Shared UdpListener As UdpClient
    Public Shared UdpReceivePort As Integer = 1160
    'UDP Server Varibles'
    Public Shared UdpSender As UdpClient
    Public Shared UdpSendPort As Integer = 1121
    Public Shared UdpIPEndPoint As IPEndPoint

    Public Shared Sub startDSListener()
        Dim dsListenThread As Thread = New Thread(AddressOf ListenToDsTcp)

        If dsListenThread.IsAlive Then
        Else
            dsListenThread.Start()
        End If

    End Sub

    Public Shared Sub newDriverStationConnection(teamId As String, allianceStat As String)
        TeamNum = teamId
        allianceStation = allianceStat
    End Sub

    'loops forever reading the udp packets from the driver stations
    Public Shared Sub listenForDsUdpPackets()
        While True
            Dim data As [Byte]() = UdpListener.Receive(UdpIPEndPoint)

            Dim teamid_1 = data(4) << 8
            Dim teamid_2 = data(5)
            teamId = teamid_1 & teamid_2

            Dim sendPacket As Thread = New Thread(AddressOf sendPacketDS)

            If Field.fieldStatus <> Field.MatchEnums.PostMatch Then
                Select Case (teamId)
                    Case Main_Panel.RedTeam1.Text
                        Main_Panel.R1DS.BackColor = Color.LimeGreen
                        DS_Linked_Red1 = True
                        If sendPacket.IsAlive Then
                        Else
                            sendPacket.Start()
                        End If

                        RadioLinked = data(3) & &H10 <> 0
                        If RadioLinked = True Then

                        End If

                        RobotLinked = data(3) & &H20 <> 0
                        If RobotLinked = True Then
                            Robot_Linked_Red1 = True
                            Main_Panel.R1Robot.BackColor = Color.LimeGreen
                            BatteryVoltage = float(data(6)) + float(data(7)) / 256
                            Main_Panel.RedVolt1.Text = BatteryVoltage.ToString
                        End If
                    Case Main_Panel.RedTeam2.Text
                        Main_Panel.R2DS.BackColor = Color.LimeGreen
                        DS_Linked_Red2 = True
                        If sendPacket.IsAlive Then
                        Else
                            sendPacket.Start()
                        End If

                        RadioLinked = data(3) & &H10 <> 0
                        If RadioLinked = True Then

                        End If

                        RobotLinked = data(3) & &H20 <> 0
                        If RobotLinked = True Then
                            Robot_Linked_Red2 = True
                            Main_Panel.R2Robot.BackColor = Color.LimeGreen
                            BatteryVoltage = float(data(6)) + float(data(7)) / 256
                            Main_Panel.RedVolt2 = BatteryVoltage
                        End If
                    Case Main_Panel.RedTeam3.Text
                        Main_Panel.R3DS.BackColor = Color.LimeGreen
                        DS_Linked_Red3 = True
                        If sendPacket.IsAlive Then
                        Else
                            sendPacket.Start()
                        End If

                        RadioLinked = data(3) & &H10 <> 0
                        If RadioLinked = True Then

                        End If

                        RobotLinked = data(3) & &H20 <> 0
                        If RobotLinked = True Then
                            Robot_Linked_Red3 = True
                            Main_Panel.R3Robot.BackColor = Color.LimeGreen
                            BatteryVoltage = float(data(6)) + float(data(7)) / 256
                            Main_Panel.RedVolt3 = BatteryVoltage
                        End If
                    Case Main_Panel.BlueTeam1.Text
                        Main_Panel.B1DS.BackColor = Color.LimeGreen
                        DS_Linked_Blue1 = True
                        If sendPacket.IsAlive Then
                        Else
                            sendPacket.Start()
                        End If

                        RadioLinked = data(3) & &H10 <> 0
                        If RadioLinked = True Then

                        End If

                        RobotLinked = data(3) & &H20 <> 0
                        If RobotLinked = True Then
                            Robot_Linked_Blue1 = True
                            Main_Panel.B1Robot.BackColor = Color.LimeGreen
                            BatteryVoltage = float(data(6)) + float(data(7)) / 256
                            Main_Panel.BlueVolt1 = BatteryVoltage
                        End If
                    Case Main_Panel.BlueTeam2.Text
                        Main_Panel.B2DS.BackColor = Color.LimeGreen
                        DS_Linked_Blue2 = True
                        If sendPacket.IsAlive Then
                        Else
                            sendPacket.Start()
                        End If

                        RadioLinked = data(3) & &H10 <> 0
                        If RadioLinked = True Then

                        End If

                        RobotLinked = data(3) & &H20 <> 0
                        If RobotLinked = True Then
                            Robot_Linked_Blue2 = True
                            Main_Panel.B2Robot.BackColor = Color.LimeGreen
                            BatteryVoltage = float(data(6)) + float(data(7)) / 256
                            Main_Panel.BlueVolt2 = BatteryVoltage
                        End If
                    Case Main_Panel.BlueTeam3.Text
                        Main_Panel.B3DS.BackColor = Color.LimeGreen
                        DS_Linked_Blue3 = True
                        If sendPacket.IsAlive Then
                        Else
                            sendPacket.Start()
                        End If

                        RadioLinked = data(3) & &H10 <> 0
                        If RadioLinked = True Then

                        End If

                        RobotLinked = data(3) & &H20 <> 0
                        If RobotLinked = True Then
                            Robot_Linked_Blue3 = True
                            Main_Panel.B3Robot.BackColor = Color.LimeGreen
                            BatteryVoltage = float(data(6)) + float(data(7)) / 256
                            Main_Panel.BlueVolt3 = BatteryVoltage
                        End If
                End Select
            Else
                UdpListener.Close()
                TcpClient.Close()
            End If

        End While
    End Sub

    Public Shared Sub setDsConnection(dsIP As IPAddress, tcpConnection As TcpClient)
        TcpClient = tcpConnection
        UdpSender = New UdpClient(dsIP.ToString, UdpSendPort)
        UdpIPEndPoint = New IPEndPoint(IPAddress.Parse(dsIP.ToString), 0)
        UdpListener = New System.Net.Sockets.UdpClient(UdpReceivePort)
        Dim ReadUDP As New Thread(AddressOf listenForDsUdpPackets)

        If ReadUDP.IsAlive Then
        Else
            ReadUDP.Start()
        End If

    End Sub

    Public Shared Sub sendPacketDS(allianceStation As Integer)
        While True
            If UdpSender IsNot Nothing Then
                Dim packet As [Byte]() = encodeControlPacket(0)
                UdpSender.Send(packet, packet.Length)
            Else
                MessageBox.Show("Udp Sender has Problems")
            End If

        End While
    End Sub

    Public Shared Function encodeControlPacket(allianceStation As Integer) As Byte()
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
        '0 = r1, 1 = r2, 2 = r3, 3 = b1, 4 = b2, 5 = b3'
        data(5) = allianceStation

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
        Dim nanoseconds = CUInt((currentTime.Ticks / TimeSpan.TicksPerMillisecond Mod 10) * 100)
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

    Public Shared Sub ListenToDsTcp()
        Dim IpEndPoint As IPEndPoint = New IPEndPoint(IPAddress.Parse("127.0.0.1"), TCPListenPort)
        Listener = New TcpListener(IpEndPoint)

        If Listen = False Then
            Listener.Start()
        End If

        MessageBox.Show("Listener Started")
        Listen = True

        While (Field.fieldStatus <> Field.MatchEnums.PostMatch Or Field.fieldStatus <> Field.MatchEnums.AbortMatch And Listen = True)

            If Listen = True Then
                TcpClient = Listener.AcceptTcpClient
            Else
                TcpClient.Close()
                Listener.Stop()
            End If


            Dim Buffer(6) As Byte

            TcpClient.GetStream().Read(Buffer, 0, Buffer.Length)

            If Buffer(0) <> 0 And Buffer(1) <> 24 And Buffer(2) <> 3 Then
                TcpClient.Close()
                MessageBox.Show("Client was rejected since inital packet wasn't right")
            End If

            Dim teamid_1 = Buffer(3) << 8
            Dim teamid_2 = Buffer(4)

            teamId = teamid_1 & teamid_2

            Dim stationStatus As Integer = -1

            TCP_DS_IP = CType(TcpClient.Client.RemoteEndPoint, IPEndPoint).Address

            'Checks the team info to see if they are in the match'
            If teamId = Main_Panel.RedTeam1.Text Then
                stationStatus = 0
                setDsConnection(TCP_DS_IP, TcpClient)
            ElseIf teamId = Main_Panel.RedTeam2.Text Then
                stationStatus = 0
                setDsConnection(TCP_DS_IP, TcpClient)
            ElseIf teamId = Main_Panel.RedTeam3.Text Then
                stationStatus = 0
                setDsConnection(TCP_DS_IP, TcpClient)
            ElseIf teamId = Main_Panel.BlueTeam1.Text Then
                stationStatus = 0
                setDsConnection(TCP_DS_IP, TcpClient)
            ElseIf teamId = Main_Panel.BlueTeam2.Text Then
                stationStatus = 0
                setDsConnection(TCP_DS_IP, TcpClient)
            ElseIf teamId = Main_Panel.BlueTeam3.Text Then
                stationStatus = 0
                setDsConnection(TCP_DS_IP, TcpClient)
            Else
                stationStatus = -1
                Thread.Sleep(1000)
                TcpClient.Close()
            End If



            Dim assignmentPacket(5) As Byte
            assignmentPacket(0) = 0 'packet size'
            assignmentPacket(1) = 3 'packet size'
            assignmentPacket(2) = 25 'packet type'
            assignmentPacket(3) = allianceStation
            assignmentPacket(4) = stationStatus 'station status, need to add station checking'

            TcpClient.GetStream.Write(assignmentPacket, 0, assignmentPacket.Length)
        End While

        If Listen = False Then
            TcpClient.Close()
            Listener.Stop()
        End If

    End Sub

    Public Sub handleDSTcp()
        'FIX THIS'
    End Sub

End Class
