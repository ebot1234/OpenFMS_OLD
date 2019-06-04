Imports System.Net.Sockets
Imports System.Net
Imports System.Text.RegularExpressions
Imports O_FMS_V0.PLC_Comms_Server
Imports O_FMS_V0.RandomString
Imports System.Threading


Public Class DriverStations
    Public packetCount As Integer = 0
    Public DSUpdSendPort As Int32 = 1121
    Public DSUdpReceivePort As Int32 = 1160
    Public Bypassed As Boolean = False
    Public Auto As Boolean = False
    Public Enabled As Boolean = False
    Public Estop As Boolean = False
    Public robotIp As IPAddress
    Public radioIp As IPAddress
    Public DriverStationIP As IPAddress
    Public FMS_IP As String = "10.0.100.5"
    Public tcpClient As TcpClient
    Public udpClient As UdpClient
    Public TeamNum As String
    Public IpEnd As IPEndPoint = New IPEndPoint(IPAddress.Parse("10.0.100.5"), 1750)
    Public dsListener As TcpListener
    Public DsLinked As Boolean
    Public RadioLinked As Boolean
    Public RioLinked As Boolean
    Public robotLinkedTime
    Public rioLinkedTime
    Public dsLinkedTime
    Public batteryVoltage
    Public float() As Single = {1.0F, 1.0F, 1.0F}
    Public allianceStation As Integer
    Public driverStationUdpLinkTimeoutSec
    Public lastRobotLinkTime
    Public DsRobotTripTime
    Public MissedPacketCount
    Public MissPacketOffset
    Public maxTcpPacketBytes = 4096

    Public Function newDriverStationConnection(teamId As String, allianceStat As String, tcpConn As TcpClient)
        Dim ipAddress = tcpClient.Client.RemoteEndPoint.ToString().Split(":")(0)

        udpClient.Connect(ipAddress, DSUpdSendPort)

        TeamNum = teamId
        allianceStat = allianceStation

        Return allianceStat & TeamNum
    End Function

    'loops forever reading the udp packets from the driver stations
    Public Sub listenForDsUdpPackets(ipAddr As IPAddress)
        Dim udp_rec As New IPEndPoint(ipAddr, DSUdpReceivePort)

        Do While (True)
            'Listens to the DS via a udp client'
            Dim rec_bytes As Byte() = udpClient.Receive(udp_rec)

            Dim teamId As Integer = rec_bytes(4) << 8 + rec_bytes(5)

            If teamId <> 0 Then
                DsLinked = True
                dsLinkedTime = DateTime.Now.Second()

                RadioLinked = rec_bytes(3) & &H10 <> 0
                RioLinked = rec_bytes(3) & &H20 <> 0

                If RioLinked = True Then
                    robotLinkedTime = DateTime.Now.Second()
                    batteryVoltage = float(rec_bytes(6)) + float(rec_bytes(7)) / 256
                End If
            End If

        Loop

    End Sub

    Public Sub setConnections(dsIp As IPAddress, tcpConnection As TcpClient)
        DriverStationIP = dsIp
        tcpClient = tcpConnection
        udpClient = New UdpClient(dsIp.ToString(), 1121)
    End Sub

    Public Sub sendPacketDS(allianceStation As Integer)
        Dim packet = encodeControlPacket(allianceStation)
        udpClient.Send(packet, packet.Length)

    End Sub

    Public Function encodeControlPacket(allianceStation As Integer)
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

    Public Sub update()
        sendPacketDS(allianceStation)

        If dsLinkedTime > driverStationUdpLinkTimeoutSec Then
            DsLinked = False
            RadioLinked = False
            RioLinked = False
            batteryVoltage = 0
        End If

        lastRobotLinkTime = DateTime.Now.Second()
    End Sub

    Public Sub close()
        tcpClient.Close()
        udpClient.Close()
    End Sub

    Public Sub ListenToDsTcp()
        Dim listen As Boolean

        Try
            Dim port As Int32 = 1750
            Dim FMS_Address As IPAddress = IPAddress.Parse("10.0.100.5")
            dsListener = New TcpListener(FMS_Address, port)
            dsListener.Start()
            listen = True
        Catch ex As SocketException
            MessageBox.Show(ex.ToString)
            listen = False
        End Try


        While (Field.fieldStatus = Field.MatchEnums.PreMatch And listen = True)
            Dim tcpClient As TcpClient = dsListener.AcceptTcpClient
            Dim buffer(5) As Byte
            tcpClient.GetStream.Read(buffer, 0, buffer.Length)

            If buffer(0) <> 0 & buffer(1) <> 3 & buffer(2) <> 24 Then
                tcpClient.Close()

            End If

            Dim teamid_1 As Integer = buffer(3) << 8
            Dim teamid_2 As Integer = buffer(4)
            Dim teamId As Integer = teamid_1 And teamid_2

            Dim stationStatus As Integer = -1
            Dim ip As String = tcpClient.Client.RemoteEndPoint.ToString().Split(":")(0)
            Dim dsIp As IPAddress = IPAddress.Parse(ip)

            'Sets the status if the team is okay or wrong'
            If TeamNum = teamId Then
                stationStatus = 0
            Else
                stationStatus = -1
            End If

            Dim assignmentPacket(5) As Byte
            assignmentPacket(0) = 0 'packet size'
            assignmentPacket(1) = 3 'packet size'
            assignmentPacket(2) = 25 'packet type'
            assignmentPacket(3) = allianceStation
            assignmentPacket(4) = 0 'station status, need to add station checking'

            tcpClient.GetStream.Write(assignmentPacket, 0, assignmentPacket.Length)

            If TeamNum = teamId Then
                setConnections(dsIp, tcpClient)
            End If

            Dim newDs = newDriverStationConnection(teamId, allianceStation, tcpClient)

            If newDs Is Nothing Then
                tcpClient.Close()
                MessageBox.Show("Error creating new Driver Station")
            End If

            Dim handleTCP As Thread = New Thread(AddressOf handleDSTcp)

            If handleTCP Is Nothing Then
                handleTCP.Start()
            End If
        End While

    End Sub

    Public Sub handleDSTcp()
        Dim buffer(maxTcpPacketBytes) As Byte

        Do While (True)
            tcpClient.Client.ReceiveTimeout = TimeOfDay.Second * driverStationUdpLinkTimeoutSec
            tcpClient.GetStream.Read(buffer, 0, buffer.Length)

            Dim packetType = buffer(2)

            Select Case packetType
                Case 28
                    'DS Keep Alive'
                Case 22
                    'Do Nothing since I dont decompile the status packet
            End Select
        Loop
    End Sub

    Public Sub Dispose()
        If udpClient IsNot Nothing Then
            udpClient.Close()
        Else
            'Do nothing since it is nothing'
        End If

        If tcpClient IsNot Nothing Then
            tcpClient.Close()
        Else
            'Do nothing since it is nothing'
        End If

        If dsListener IsNot Nothing Then
            dsListener.Stop()
        Else
            'Do nothing since it is nothing
        End If

    End Sub

End Class
