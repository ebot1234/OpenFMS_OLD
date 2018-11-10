Imports O_FMS_V0.RandomString
Imports System.Net.Sockets
Imports O_FMS_V0.Modes
Imports O_FMS_V0.Strip
Imports System.Net
Public Class Controller

    Public redController As UdpClient
    Public blueController As UdpClient
    Public scaleController As UdpClient
    Public port As Integer = 5568
    Public sourceName As String = "OpenFMS"
    Public packetTimeOutSec As Integer = 1
    Public Shared numPixels As Integer = 150

    Public pixelDataOffset As Integer
    Public nearStripUniverse As Integer = 1
    Public farStripUniverse As Integer = 2
    Public nearStrip As New Strip
    Public farStrip As New Strip
    Public Conn As New UdpClient
    Public Shared packet() As Byte
    Public b() As Byte
    Public pixelData As New Strip
    Public Shared controller As New Controller
    'ip address of the pixel controller
    Public address As String = "10.0.0.13"
    Public redAddress As String = "10.0.0.14"
    Public blueAddress As String = "10.0.0.15"



    Public Function LedConnect()
        Try
            Conn.Connect(address, port)
            Console.WriteLine("Led Connection worked")

        Catch e As Exception
            Console.WriteLine("Led Connection Failed")
        End Try

        Return controller
    End Function

    Public Function setMode(nearMode As Integer, farMode As Integer)
        If nearMode = nearStrip.currentMode Then
            nearStrip.currentMode = nearMode
            nearStrip.counter = 0
        End If

        If farMode = farStrip.currentMode Then
            farStrip.currentMode = farMode
            farStrip.counter = 0
        End If
        Return offMode
    End Function

    Public Function getCurrentMode()
        If nearStrip.currentMode = farStrip.currentMode Then
            Return nearStrip.currentMode
        Else
            Return offMode

        End If

    End Function

    Public Sub setSidedness(nearIsRed As Boolean)
        nearStrip.isRed = nearIsRed = True
        farStrip.isRed = nearIsRed = False
    End Sub

    Public Function updateLeds()
        nearStrip.updatePixels()
        farStrip.updatePixels()

        If packet.Length = 0 Then
            packet = createBlankPacket(numPixels)
        End If

        If nearStrip.shouldSendPacket = True Then
            nearStrip.populatePacketPixels(packet)
            controller.sendPacket(nearStripUniverse)
        End If

        If farStrip.shouldSendPacket = True Then
            farStrip.populatePacketPixels(packet)
            controller.sendPacket(farStripUniverse)
        End If
        Return 0
    End Function

    Public Shared Function createBlankPacket()
        Dim size = 126 + 3 * numPixels
        packet(size) = size

        packet(0) = &H0
        packet(1) = &H10

        packet(2) = &H0
        packet(3) = &H0

        packet(4) = &H41
        packet(5) = &H53
        packet(6) = &H43
        packet(7) = &H2D
        packet(8) = &H45
        packet(9) = &H31
        packet(10) = &H2E
        packet(11) = &H31
        packet(12) = &H37
        packet(13) = &H0
        packet(14) = &H0
        packet(15) = &H0

        Dim rootPduLength = size - 16
        packet(16) = &H70 Or rootPduLength >> 8
        packet(17) = rootPduLength & &HFF

        packet(18) = &H0
        packet(19) = &H0
        packet(20) = &H0
        packet(21) = &H4

        'source name'
        packet(22) = "O"
        packet(23) = "p"
        packet(24) = "e"
        packet(25) = "n"
        packet(26) = "F"
        packet(27) = "M"
        packet(28) = "S"


        Dim framingPduLength = size - 16
        packet(38) = &H70 Or framingPduLength >> 8
        packet(39) = framingPduLength & &HFF

        packet(40) = &H0
        packet(41) = &H0
        packet(42) = &H0
        packet(43) = &H2

        packet(44) = "O"
        packet(45) = "p"
        packet(46) = "e"
        packet(47) = "n"
        packet(48) = "F"
        packet(49) = "M"
        packet(50) = "S"

        packet(108) = 100

        packet(109) = &H0
        packet(110) = &H0

        packet(111) = &H0

        packet(112) = &H0

        packet(113) = &H0
        packet(114) = &H0

        Dim dmpPduLength = size - 115
        packet(115) = &H70 Or dmpPduLength >> 8
        packet(116) = dmpPduLength & &HFF

        packet(117) = &H2

        packet(118) = &HA1

        packet(119) = &H0
        packet(120) = &H0

        packet(121) = &H0
        packet(122) = &H1

        Dim count = 1 + 3 * numPixels
        packet(123) = count >> 8
        packet(124) = count & &HFF

        packet(125) = 0

        Return 0
    End Function


    Public Function sendPacket(dmxUniverse As Integer)
        packet(111) = packet(111) + 1
        packet(113) = dmxUniverse >> 8
        packet(114) = dmxUniverse & &HFF

        Conn.Send(packet, packet.Length)
        Return packet
    End Function

End Class