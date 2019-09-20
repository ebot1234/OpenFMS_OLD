Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks

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

    Dim pingThreadRef As ThreadStart
    Dim pingThread As Thread
    Dim sendDataThreadRef As ThreadStart
    Dim sendDataThread As Thread

    Dim udpClient As UdpClient
    Public tcpClient As TcpClient

    Public Sub newDriverStation(teamNumber As String, allianceStationNumber As Integer)

        If Integer.TryParse(teamNumber, Team_Number) Then
            Select Case teamNumber.Length
                Case 1
                Case 2
                    robotIp = IPAddress.Parse("10.00" + teamNumber + ".2")
                    Exit Select
                Case 3
                    robotIp = IPAddress.Parse("10.0" + teamNumber(0) + "." + teamNumber(1) + teamNumber(2) + ".2")
                    Exit Select
                Case 4
                    robotIp = IPAddress.Parse("10." + teamNumber.Substring(0, 2) + "." + teamNumber.Substring(2) + ".2")
                    Exit Select
                Case Else
                    robotIp = IPAddress.Parse("10.0.0.2")
                    Exit Select
            End Select

        Else
            Team_Number = 0
            robotIp = IPAddress.Parse("10.0.0.2")
        End If

        radioIp = IPAddress.Parse(robotIp.ToString().Substring(0, robotIp.ToString().Length - 1) + "1")

        pingThreadRef = New ThreadStart(AddressOf robotPingThread)
        pingThread = New Thread(pingThreadRef)
        pingThread.Start()

        Team_Number = teamNumber 'This may not be needed'
        stationId = allianceStationNumber

        sendDataThreadRef = New ThreadStart(AddressOf sendControlDataThread)
        sendDataThread = New Thread(sendDataThreadRef)
        sendDataThread.Start()
    End Sub

    Public Sub dispose()
        closed = True
        If udpClient IsNot Nothing Then
            udpClient.Close()
        End If

        If tcpClient IsNot Nothing Then
            tcpClient.Close()
        End If
    End Sub

    Public Sub setDsConnections(dsIp As IPAddress, tcpConnection As TcpClient)
        driverStationIp = dsIp
        tcpClient = tcpConnection
        udpClient = New UdpClient(dsIp.ToString(), 1121)
    End Sub

    Public Sub robotPingThread()
        Dim ping As New Ping()
        Dim timeout As Integer = 5

        While closed = False
            'Ping Robot Radio'
            Dim results As PingReply = ping.Send(radioIp, timeout)
            isRadioConnected = results.Status = IPStatus.Success

            'Ping RoboRio'
            results = ping.Send(robotIp, timeout)
            isRioConnected = results.Status = IPStatus.Success

            If driverStationIp IsNot Nothing Then
                results = ping.Send(driverStationIp, timeout)
                isDSConnected = results.Status = IPStatus.Success
            End If
        End While
    End Sub

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

    Public Function generateControlPacket() As Byte()
        'Using the driver station packet structure from Cheesy Arena'
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

        'Alliance Station byte'
        '0 = r1, 1 = r2, 2 = r3, 3 = b1, 4 = b2, 5 = b3'
        If Team_Number = Main_Panel.RedTeam1.Text Then
            data(5) = 0
        ElseIf Team_Number = Main_Panel.RedTeam2.Text Then
            data(5) = 1
        ElseIf Team_Number = Main_Panel.RedTeam3.Text Then
            data(5) = 2
        ElseIf Team_Number = Main_Panel.BlueTeam1.Text Then
            data(5) = 3
        ElseIf Team_Number = Main_Panel.BlueTeam2.Text Then
            data(5) = 4
        ElseIf Team_Number = Main_Panel.BlueTeam3.Text Then
            data(5) = 5
        End If

        'driver station match type is practice for right now, CHANGE THIS?'
        data(6) = 1

        'Match Number, ADD THE ACTUAL MATCH NUM'
        data(7) = 1
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
        data(20) = Integer.Parse(Main_Panel.matchTimerLbl.Text >> 8 & &HFF)
        data(21) = Integer.Parse(Main_Panel.matchTimerLbl.Text & &HFF)

        packetCount = packetCount + 1
        Return data
    End Function
End Class
