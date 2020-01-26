Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

Public Class DriverStation
    Public Team_Number As Integer
    Public robotIp As IPAddress
    Public radioIp As IPAddress
    Public driverStationIp As IPAddress
    Public isDSConnected As Boolean = False
    Public isRadioConnected As Boolean = False
    Public isRioConnected As Boolean = False
    Public stationId As Integer = -1
    Public packetCount As Integer = 0
    Public closed = False
    Public estop = False
    Public auto = False
    Public enabled = False
    Dim float() As Single = {1.0F, 1.0F, 1.0F}
    Public batteryVoltage As Double
    Dim pingThreadRef As ThreadStart
    Dim pingThread As Thread
    Dim sendDataThreadRef As ThreadStart
    Dim sendDataThread As Thread
    Dim udpClient As UdpClient
    Dim udpListener As UdpClient
    Public tcpClient As TcpClient
    Dim endPoint As IPEndPoint

    'Sets up a new driverstation and starts the Robot/Radio Ping and DS Comms Threads'
    Public Sub NewDriverStation(TeamNumber As String, AllianceStationNumber As Integer)
        'Formats the robots IP so OpenFMS can ping it'
        If Integer.TryParse(TeamNumber, Team_Number) Then
            Select Case TeamNumber.Length
                Case 1
                    robotIp = IPAddress.Parse("10.00.0" & TeamNumber & ".2")
                    Exit Select
                Case 2
                    robotIp = IPAddress.Parse("10.00." & TeamNumber & ".2")
                    Exit Select
                Case 3
                    robotIp = IPAddress.Parse("10.0" + TeamNumber(0) + "." + TeamNumber(1) + TeamNumber(2) + ".2")
                    Exit Select
                Case 4
                    robotIp = IPAddress.Parse("10." + TeamNumber.Substring(0, 2) + "." + TeamNumber.Substring(2) + ".2")
                    Exit Select
                Case Else
                    robotIp = IPAddress.Parse("10.0.0.2")
                    Exit Select
            End Select
        Else
            Team_Number = 0
            robotIp = IPAddress.Parse("10.0.0.2")
        End If

        'Sets the radio IP to the robots and sets the last part to .1'
        radioIp = IPAddress.Parse(robotIp.ToString().Substring(0, robotIp.ToString().Length - 1) + "1")
        'Sets the Team Numbers and Station IDs'
        Team_Number = TeamNumber
        stationId = AllianceStationNumber

        'Starts the DS Comms Thread'
        sendDataThreadRef = New ThreadStart(AddressOf sendControlDataThread)
        sendDataThread = New Thread(sendDataThreadRef)
        sendDataThread.Start()
    End Sub

    'Sets connection info'
    Public Sub setDSConnections(dsIp As IPAddress, tcpConnection As TcpClient)
        driverStationIp = dsIp
        tcpClient = tcpConnection
        udpClient = New UdpClient(dsIp.ToString(), 1121)
        endPoint = New IPEndPoint(IPAddress.Parse(driverStationIp.ToString), 0)
        udpListener = New UdpClient(1160)

        pingThreadRef = New ThreadStart(AddressOf driverstationStatusThread)
        pingThread = New Thread(pingThreadRef)
        pingThread.Start()
    End Sub

    'Reads info from Driver Stations'
    Public Sub driverStationStatusThread()
        While closed = False
            Dim data As [Byte]() = udpListener.Receive(endPoint)
            Dim teamid_1 = data(4) << 8
            Dim teamid_2 = data(5)
            Dim teamId = teamid_1 & teamid_2

            If teamId = Team_Number Then
                isDSConnected = True
                isRadioConnected = data(3) & &H10 <> 0
                isRioConnected = data(3) & &H20 <> 0

                If isRadioConnected = True Then
                    batteryVoltage = data(6) & "." & data(7)
                End If
            Else
                Exit While
            End If
        End While
    End Sub

    'Destroys the DS Connections'
    Public Sub Dispose()
        closed = True

        If udpClient IsNot Nothing Then
            udpClient.Close()
        End If

        If tcpClient IsNot Nothing Then
            tcpClient.Close()
        End If
    End Sub

    'DS Comms Thread'
    Public Sub sendControlDataThread()
        While closed = False
            If udpClient IsNot Nothing Then
                Dim packet As Byte() = generateControlPacket()
                udpClient.Send(packet, packet.Length)
            Else
                Thread.Sleep(100)
            End If
        End While
    End Sub

    'DS 2015-2020 Communications Packet'
    Public Function generateControlPacket() As Byte()
        'Reformated from Cheesy Arena'

        Dim data(22) As Byte

        data(0) = packetCount >> 8 And &HFF
        data(1) = packetCount And &HFF

        'Protocol version'
        data(2) = 0

        'Robot status byte'
        data(3) = 0

        If auto = True Then
            data(3) = &H2
        End If

        If enabled = True Then
            data(3) = &H4
        End If

        If estop = True Then
            data(3) = &H80
        End If

        'Unused byte or unknown'
        data(4) = 0

        'Alliance Station Byte'
        data(5) = stationId

        'Match Type'
        data(6) = 2 'For Normal Match Play'
        data(6) = 3 'For Elimination Match Play'
        data(6) = 1 'For Practice Mode, Not Used By OpenFMS'

        'Match Number, Not Used By OpenFMS'
        data(7) = 0
        data(8) = 1

        'Repeat Match Number, Not Used By OpenFMS'
        data(9) = 1

        'Current Time Since 1900'
        Dim currentTime = DateAndTime.Now()
        Dim nanoseconds = CUInt((currentTime.Ticks / TimeSpan.TicksPerMillisecond Mod 10) * 100)
        data(10) = ((nanoseconds / 1000) >> 25) & &HFF
        data(11) = ((nanoseconds / 1000) >> 16) & &HFF
        data(12) = ((nanoseconds / 1000) >> 8) & &HFF
        data(13) = (nanoseconds / 1000) & &HFF
        data(14) = currentTime.Second
        data(15) = currentTime.Minute
        data(16) = currentTime.Hour
        data(17) = currentTime.Day
        data(18) = currentTime.Month
        data(19) = currentTime.Year - 1900

        'Current Match Time'
        'data(20) = Integer.Parse(MatchTime >> 8 & &HFF)
        'data(21) = Integer.Parse(MatchTime & &HFF)

        'Increment Packet Count'
        packetCount = packetCount + 1

        'Returns the data packet'
        Return data
    End Function

    'Writes the Game Data to the Driver Station'
    Public Sub SendGameSpecificData(GameString As String)
        Dim data(GameString) As Byte
        Dim size = data.Length
        Dim packet(size + 4) As Byte

        packet(0) = 0
        packet(1) = size + 2
        packet(2) = 28
        packet(3) = size

        Dim data_byte = Text.Encoding.ASCII.GetBytes(GameString)

        For i As Integer = 4 To size
            For Each character As Byte In data_byte
                packet(i) = character
            Next
        Next

        Dim Stream As NetworkStream = tcpClient.GetStream()
        Stream.Write(packet, 0, packet.Length)
        Stream.Close()

    End Sub

End Class
