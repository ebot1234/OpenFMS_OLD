
Imports System.Net.Sockets
Imports System.Net
Imports Game.Led.Modes
Imports Game.Led.Strip
Imports Game.RandomString
Public Class Controller
    Public port As Integer = 5568
    Public sourceName As String = "OpenFMS"
    Public packetTimeOutSec As Integer = 1
    Public numPixels As Integer = 150
    Public pixelDataOffset As Integer = 126
    Public nearStripUniverse As Integer = 1
    Public farStripUniverse As Integer = 2
    Public nearStrip As New Strip
    Public farStrip As New Strip
    Public Conn As New UdpClient(port)
    Public packet() As Byte
    Public b() As Byte
    'ip address of the pixel controller
    Public address As String = "10.0.0.12"

    Public Function LedConnect(controller As Controller)
        Try
            controller.Conn.Connect(address, port)
            Console.WriteLine("Led Connection worked")

        Catch e As Exception
            Console.WriteLine("Led Connection Failed")
        End Try
    End Function

    Public Function setMode(controller As Controller, nearMode As Mode, farMode As Mode)
        If nearMode = controller.nearStrip.currentMode Then
            controller.nearStrip.currentMode = nearMode
            controller.nearStrip.counter = 0
        End If

        If farMode = controller.farStrip.currentMode Then
            controller.farStrip.currentMode = farMode
            controller.farStrip.counter = 0
        End If
        Return 0
    End Function

    Public Function getCurrentMode(Mode As Modes, controller As Controller, strip As Strip)
        If controller.nearStrip.currentMode Is controller.farStrip.currentMode Then
            Return controller.nearStrip.currentMode
        Else
            Return Mode.offMode

        End If
    End Function

    Public Function setSidedness(controller As Controller, nearIsRed As Boolean)
        controller.nearStrip.isRed = nearIsRed = True
        controller.farStrip.isRed = nearIsRed = False
        Return 0
    End Function

    Public Function update(controller As Controller)
        controller.nearStrip.updatePixels()
        controller.farStrip.updatePixels()

        If (controller.packet.Length = 0) Then
            controller.packet = createBlankPacket(numPixels)
        End If

        If controller.nearStrip.shouldSendPacket() Then
            controller.nearStrip.populatePacketPixels(controller.packet(pixelDataOffset))
            controller.packet.sendPacket(nearStripUniverse)
        End If

        If controller.farStrip.shouldSendPacket() Then
            controller.farStrip.populatePacketPixels(controller.packet(pixelDataOffset))
            controller.packet.sendPacket(farStripUniverse)
        End If
        Return 0
    End Function

    Public Function pointIndices() As Controller
        Return Nothing
    End Function

    Public Function createBlankPacket() As Byte
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

    Public Function sendPacket(controller As Controller, dmxUniverse As Integer)
        controller.packet(111) = controller.packet(111) + 1
        controller.packet(113) = dmxUniverse >> 8
        controller.packet(114) = dmxUniverse & &HFF

        Conn.Send(controller.packet, packet.Length)

        Return 0
    End Function
End Class
