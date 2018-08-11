Imports O_FMS_V0.RandomString
Imports System.Net.Sockets
Public Class Controller

    'class for a led controller with 6 dmx outputs and 6 dmx universes
    Public port As Integer = 5568
    Public sourceName As String = "OpenFMS"
    Public packetTimeOutSec As Integer = 1
    Public numPixels As Integer = 150
    Public pixelDataOffset As Integer = 126
    Public nearStripUniverse As Integer = 1
    Public farStripUniverse As Integer = 2
    Public nearBlueSwitchStripUniverse As Integer = 3
    Public nearRedSwitchStripUniverse As Integer = 4
    Public farRedSwitchStripUniverse As Integer = 5
    Public farBlueSwitchStripUniverse As Integer = 6
    Public nearStrip As New Strip
    Public farStrip As New Strip
    Public nearBlueSwitchStrip As New Strip
    Public nearRedSwitchStrip As New Strip
    Public farBlueSwitchStrip As New Strip
    Public farRedSwitchStrip As New Strip
    Public Conn As New UdpClient(port)
    Public packet() As Byte
    Public b() As Byte
    Public pixelData As Strip

    'ip address of the pixel controller
    Public address As String = "10.0.0.13"

    Public Function LedConnect(controller As Controller)
        Try
            controller.Conn.Connect(address, port)
            Console.WriteLine("Led Connection worked")

        Catch e As Exception
            Console.WriteLine("Led Connection Failed")
        End Try
    End Function

    Public Function setMode(controller As Controller, nearMode As Modes, farMode As Modes)
        If nearMode Is controller.nearStrip.currentMode Then
            controller.nearStrip.currentMode = nearMode
            controller.nearStrip.counter = 0
        End If

        If farMode Is controller.farStrip.currentMode Then
            controller.farStrip.currentMode = farMode
            controller.farStrip.counter = 0
        End If
        If farMode Is controller.farBlueSwitchStrip.currentMode Then
            controller.farBlueSwitchStrip.currentMode = farMode
            controller.farBlueSwitchStrip.counter = 0
        End If

        If farMode Is controller.farRedSwitchStrip.currentMode Then
            controller.farRedSwitchStrip.currentMode = farMode
            controller.farRedSwitchStrip.counter = 0
        End If

        If nearMode Is controller.nearRedSwitchStrip.currentMode Then
            controller.nearRedSwitchStrip.currentMode = nearMode
            controller.nearRedSwitchStrip.counter = 0
        End If

        If nearMode Is controller.nearBlueSwitchStrip.currentMode Then
            controller.nearBlueSwitchStrip.currentMode = nearMode
            controller.nearBlueSwitchStrip.counter = 0
        End If
        Return 0
    End Function

    Public Function getCurrentMode(Mode As Modes, controller As Controller, strip As Strip)
        If controller.nearStrip.currentMode Is controller.farStrip.currentMode Then
            Return controller.nearStrip.currentMode
        Else
            Return Mode.offMode

        End If
        If controller.nearRedSwitchStrip.currentMode Is controller.farRedSwitchStrip Then
            Return controller.nearRedSwitchStrip.currentMode
        Else
            Return Mode.offMode
        End If
        If controller.nearBlueSwitchStrip.currentMode Is controller.farBlueSwitchStrip Then
            Return controller.nearBlueSwitchStrip.currentMode
        Else
            Return Mode.offMode
        End If
    End Function

    Public Function setSidedness(controller As Controller, nearIsRed As Boolean)
        controller.nearStrip.isRed = nearIsRed = True
        controller.farStrip.isRed = nearIsRed = False
        controller.nearRedSwitchStrip.isRed = nearIsRed = True
        controller.nearBlueSwitchStrip.isRed = nearIsRed = True
        controller.farRedSwitchStrip.isRed = nearIsRed = False
        controller.farBlueSwitchStrip.isRed = nearIsRed = False
        Return 0
    End Function

    Public Function updateWarmUpMode(controller As Controller, strip As Strip, color As Colors, colors As Colors)
        'updates all the strips'
        controller.nearStrip.updateWarmupMode(strip)
        controller.farStrip.updateWarmupMode(strip)
        controller.nearBlueSwitchStrip.updateWarmupMode(strip)
        controller.nearRedSwitchStrip.updateWarmupMode(strip)
        controller.farBlueSwitchStrip.updateWarmupMode(strip)
        controller.farRedSwitchStrip.updateWarmupMode(strip)
        'create the template if not already'
        If controller.packet.Length = 0 Then
            controller.createBlankPacket(controller)
        End If
        'send packets if the pixels have changed'
        If controller.nearStrip.shouldSendPacket(strip) Then
            controller.nearStrip.populatePacketPixels(strip)
            controller.sendPacketNearUniverse(controller, nearStripUniverse)
        End If

        If controller.farStrip.shouldSendPacket(strip) Then
            controller.farStrip.populatePacketPixels(strip)
            controller.sendPacketFarUniverse(controller, farStripUniverse)
        End If

        If controller.nearBlueSwitchStrip.shouldSendPacket(strip) Then
            controller.nearBlueSwitchStrip.populatePacketPixels(strip)
            controller.sendPacketNearBlueSwitchUniverse(controller, nearBlueSwitchStripUniverse)
        End If

        If controller.nearRedSwitchStrip.shouldSendPacket(strip) Then
            controller.nearRedSwitchStrip.populatePacketPixels(strip)
            controller.sendPacketNearRedSwitchUniverse(controller, nearRedSwitchStripUniverse)
        End If

        If controller.farRedSwitchStrip.shouldSendPacket(strip) Then
            controller.farRedSwitchStrip.populatePacketPixels(strip)
            controller.sendPacketFarRedSwitchUniverse(controller, farRedSwitchStripUniverse)
        End If
        Return 0
    End Function

    Public Function updateRedSwitchRedOwned(controller As Controller, strip As Strip, color As Colors, colors As Colors)
        If gamedataUse = "LLL" Then
            controller.nearRedSwitchStrip.updateOwnedRedMode(strip, color)
            controller.farRedSwitchStrip.updateNotOwnedMode(strip)
        End If

        If gamedataUse = "LRL" Then
            controller.nearRedSwitchStrip.updateOwnedRedMode(strip, color)
            controller.farRedSwitchStrip.updateNotOwnedMode(strip)
        End If

        If gamedataUse = "RLR" Then
            controller.nearRedSwitchStrip.updateNotOwnedMode(strip)
            controller.farRedSwitchStrip.updateOwnedRedMode(strip, color)
        End If

        If gamedataUse = "RRR" Then
            controller.nearRedSwitchStrip.updateNotOwnedMode(strip)
            controller.farRedSwitchStrip.updateOwnedRedMode(strip, color)
        End If

        'create the template if not already'
        If controller.packet.Length = 0 Then
            controller.createBlankPacket(controller)
        End If

        If controller.nearRedSwitchStrip.shouldSendPacket(strip) Then
            controller.nearRedSwitchStrip.populatePacketPixels(strip)
            controller.sendPacketNearRedSwitchUniverse(controller, nearRedSwitchStripUniverse)
        End If

        If controller.farRedSwitchStrip.shouldSendPacket(strip) Then
            controller.farRedSwitchStrip.populatePacketPixels(strip)
            controller.sendPacketFarRedSwitchUniverse(controller, farRedSwitchStripUniverse)
        End If
        Return 0
    End Function

    Public Function updateRedSwitchBlueOwned(controller As Controller, strip As Strip, color As Colors)
        If gamedataUse = "LLL" Then
            controller.nearRedSwitchStrip.updateNotOwnedMode(strip)
            controller.farRedSwitchStrip.updateOwnedBlueMode(strip, color)
        End If

        If gamedataUse = "LRL" Then
            controller.nearRedSwitchStrip.updateOwnedBlueMode(strip, color)
            controller.farRedSwitchStrip.updateNotOwnedMode(strip)
        End If

        If gamedataUse = "RLR" Then
            controller.nearRedSwitchStrip.updateNotOwnedMode(strip)
            controller.farRedSwitchStrip.updateOwnedBlueMode(strip, color)
        End If

        If gamedataUse = "RRR" Then
            controller.nearRedSwitchStrip.updateNotOwnedMode(strip)
            controller.farRedSwitchStrip.updateOwnedBlueMode(strip, color)
        End If
        'create the template if not already'
        If controller.packet.Length = 0 Then
            controller.createBlankPacket(controller)
        End If

        If controller.nearRedSwitchStrip.shouldSendPacket(strip) Then
            controller.nearRedSwitchStrip.populatePacketPixels(strip)
            controller.sendPacketNearRedSwitchUniverse(controller, nearRedSwitchStripUniverse)
        End If

        If controller.farRedSwitchStrip.shouldSendPacket(strip) Then
            controller.farRedSwitchStrip.populatePacketPixels(strip)
            controller.sendPacketFarRedSwitchUniverse(controller, farRedSwitchStripUniverse)
        End If
        Return 0
    End Function

    Public Function updateRedSwitchNotOwned(strip As Strip, controller As Controller)
        controller.nearRedSwitchStrip.updateNotOwnedMode(strip)
        controller.farRedSwitchStrip.updateNotOwnedMode(strip)
        'create the template if not already'
        If controller.packet.Length = 0 Then
            controller.createBlankPacket(controller)
        End If

        If controller.nearRedSwitchStrip.shouldSendPacket(strip) Then
            controller.nearRedSwitchStrip.populatePacketPixels(strip)
            controller.sendPacketNearRedSwitchUniverse(controller, nearRedSwitchStripUniverse)
        End If

        If controller.farRedSwitchStrip.shouldSendPacket(strip) Then
            controller.farRedSwitchStrip.populatePacketPixels(strip)
            controller.sendPacketFarRedSwitchUniverse(controller, farRedSwitchStripUniverse)
        End If
        Return 0

    End Function

    Public Function updateBlueSwitchRedOwned(strip As Strip, controller As Controller, color As Colors)
        If gamedataUse = "LLL" Then
            controller.nearBlueSwitchStrip.updateOwnedRedMode(strip, color)
            controller.farBlueSwitchStrip.updateNotOwnedMode(strip)
        End If
        If gamedataUse = "RRR" Then
            controller.nearRedSwitchStrip.updateNotOwnedMode(strip)
            controller.farRedSwitchStrip.updateOwnedRedMode(strip, color)
        End If
        If gamedataUse = "LRL" Then
            controller.nearRedSwitchStrip.updateOwnedRedMode(strip, color)
            controller.farRedSwitchStrip.updateNotOwnedMode(strip)
        End If
        If gamedataUse = "RLR" Then
            controller.nearRedSwitchStrip.updateNotOwnedMode(strip)
            controller.farRedSwitchStrip.updateOwnedRedMode(strip, color)
        End If

        If controller.packet.Length = 0 Then
            controller.createBlankPacket(controller)
        End If

        If controller.nearRedSwitchStrip.shouldSendPacket(strip) Then
            controller.nearRedSwitchStrip.populatePacketPixels(strip)
            controller.sendPacketNearRedSwitchUniverse(controller, nearRedSwitchStripUniverse)
        End If

        If controller.farRedSwitchStrip.shouldSendPacket(strip) Then
            controller.farRedSwitchStrip.populatePacketPixels(strip)
            controller.sendPacketFarRedSwitchUniverse(controller, farRedSwitchStripUniverse)
        End If
        Return 0
    End Function

    Public Function updateBlueSwitchBlueOwned(controller As Controller, strip As Strip, color As Colors)
        If gamedataUse = "RLR" Then
            controller.nearBlueSwitchStrip.updateOwnedBlueMode(strip, color)
            controller.farBlueSwitchStrip.updateNotOwnedMode(strip)
        End If
        If gamedataUse = "RRR" Then

        End If
        If gamedataUse = "LLL" Then

        End If
        If gamedataUse = "LRL" Then

        End If
    End Function

    Public Function updateBlueSwitchNotOwned()

    End Function

    Public Function updateScaleRedOwned()

    End Function

    Public Function updateScaleBlueOwned()

    End Function

    Public Function updateScaleNotOwned()

    End Function

    Public Function forceModeRedSwitch()

    End Function

    Public Function forceModeBlueSwitch()

    End Function

    Public Function BoostBlueSwitch()

    End Function

    Public Function BoostRedSwitch()

    End Function

    Public Function RedBoostScale()

    End Function

    Public Function BlueBoostScale()

    End Function

    Public Function pointIndices() As Controller
        Return Nothing
    End Function

    Public Function createBlankPacket(controller As Controller)
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

    Public Function sendPacketNearUniverse(controller As Controller, dmxUniverse As Integer)
        controller.packet(111) = controller.packet(111) + 1
        controller.packet(113) = dmxUniverse >> 8
        controller.packet(114) = dmxUniverse & &HFF

        Conn.Send(controller.packet, packet.Length)

        Return 0
    End Function

    Public Function sendPacketFarUniverse(controller As Controller, dmxUniverse As Integer)
        controller.packet(111) = controller.packet(111) + 1
        controller.packet(113) = dmxUniverse >> 8
        controller.packet(114) = dmxUniverse & &HFF

        Conn.Send(controller.packet, packet.Length)
        Return 0
    End Function

    Public Function sendPacketNearRedSwitchUniverse(controller As Controller, dmxUniverse As Integer)
        controller.packet(111) = controller.packet(111) + 1
        controller.packet(113) = dmxUniverse >> 8
        controller.packet(114) = dmxUniverse & &HFF

        Conn.Send(controller.packet, packet.Length)
        Return 0
    End Function
    Public Function sendPacketNearBlueSwitchUniverse(controller As Controller, dmxUniverse As Integer)
        controller.packet(111) = controller.packet(111) + 1
        controller.packet(113) = dmxUniverse >> 8
        controller.packet(114) = dmxUniverse & &HFF

        Conn.Send(controller.packet, packet.Length)
        Return 0
    End Function

    Public Function sendPacketFarBlueSwitchUniverse(controller As Controller, dmxUniverse As Integer)
        controller.packet(111) = controller.packet(111) + 1
        controller.packet(113) = dmxUniverse >> 8
        controller.packet(114) = dmxUniverse & &HFF

        Conn.Send(controller.packet, packet.Length)
        Return 0
    End Function

    Public Function sendPacketFarRedSwitchUniverse(controller As Controller, dmxUniverse As Integer)
        controller.packet(111) = controller.packet(111) + 1
        controller.packet(113) = dmxUniverse >> 8
        controller.packet(114) = dmxUniverse & &HFF

        Conn.Send(controller.packet, packet.Length)
        Return 0
    End Function
End Class