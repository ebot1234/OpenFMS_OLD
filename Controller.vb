Imports Microsoft.VisualBasic


Imports Game.RandomString
Imports java.io.IOException
Imports java.net.DatagramPacket
Imports java.net.DatagramSocket
Imports java.net.InetAddress
Imports java.net.SocketException
Imports java.net.UnknownHostException
Imports java.nio.ByteBuffer
Public Class Controller

    'IP address for the Rasberry Pi on the Field for the LEDs
    Private Led_IP As String = "10.0.0.20"

    Private LedAddr As InetAddress

    Private Shared DMX_DATA_POSITION As Integer = 126

    Private Led As DatagramSocket

    Private len As DatagramPacket

    Private nearStripUniverse As Integer = 1

    Private farStripUniverse As Integer = 2

    Private packetTimeOut As Integer = 1

    Private numPixels As Integer = 150

    Private pixelDataOffset As Integer = 126

    ' String componentId = "O!FMS";
    Private nearStrip As Strip = New Strip

    Private farStrip As Strip = New Strip

    Public Shared gameData As RandomString

    Private pointIndices() As Integer

    Private Sub LED()
        Try
            System.out.println("Made New Socket for the Leds")
            Me.Led = New DatagramSocket
        Catch e As SocketException
            System.out.println("PLC Error 1!")
            e.printStackTrace()
        End Try

        Try
            System.out.println("Made new address for the Leds...")
            Me.LedAddr = InetAddress.getByName(Me.Led_IP)
        Catch ex As IOException
            System.out.println("Led Error 2!")
            ex.printStackTrace()
        End Try

    End Sub

    Public Sub setMode(ByVal , As nearMode, ByVal , As farMode, ByVal Unknown As Mode)
        Me.nearStrip.currentMode = nearMode
        Me.nearStrip.counter = 0
        Me.farStrip.currentMode = farMode
        Me.farStrip.counter = 0
    End Sub

    Public Sub getCurrentMode(ByVal Unknown As Mode)
        If (Me.nearStrip.currentMode = Me.farStrip.currentMode) Then
            (Me.setMode(nearMode, farMode, Mode) = Me.nearStrip.currentMode)
        Else
            Modes.offMode()
        End If

    End Sub

    Private isRed As Boolean

    Public Sub setSidedness()
        If gameData.equals("LLL") Then
            Me.nearStrip.isRed = nearIsRed
            Me.farStrip.isRed = farIsRed
        End If

        If gameData.equals("LRL") Then
            Me.nearStrip.isRed = nearIsRed
            Me.farStrip.isRed = farIsRed
        End If

        If gameData.equals("RLR") Then
            Me.nearStrip.isRed = nearIsRed
            Me.farStrip.isRed = farIsRed
        End If

        If gameData.equals("RRR") Then
            Me.nearStrip.isRed = nearIsRed
            Me.farStrip.isRed = farIsRed
        End If

    End Sub

    Public Sub updateLeds()
        Me.nearStrip.updatePixels()
        Me.farStrip.updatePixels()
        Me.len = createBlankPacket
    End Sub
End Class
'If farStrip.shouldSendPacket Then
'    farStrip.populatePacketPixels(packet(pixelDataOffset:= pixelDataOffset:))
'    Controller.sendPacket(farStripUniverse)
'End If

'UnknownUnknown

Public Function pointIndices() As Controller
    Return Nothing
End Function

Public Sub createBlankPacket(ByVal universeNumber As Integer, ByVal pointIndices() As Integer)
    MyBase.equals((DMX_DATA_POSITION _
                    + (pointIndices.length * 3)))
    Me.pointIndices = pointIndices
    Dim data() As Byte = New Byte(((126 + (3 * numPixels))) - 1) {}
    Dim flagLength As Integer
    ' Preamble size
    data(0) = CType(0, Byte)
    data(1) = CType(16, Byte)
    ' Post-amble size
    data(0) = CType(0, Byte)
    data(1) = CType(16, Byte)
    ' ACN Packet Identifier
    data(4) = CType(65, Byte)
    data(5) = CType(83, Byte)
    data(6) = CType(67, Byte)
    data(7) = CType(45, Byte)
    data(8) = CType(69, Byte)
    data(9) = CType(49, Byte)
    data(10) = CType(46, Byte)
    data(11) = CType(49, Byte)
    data(12) = CType(55, Byte)
    data(13) = CType(0, Byte)
    data(14) = CType(0, Byte)
    data(15) = CType(0, Byte)
    ' Flags and length
    flagLength = (28672 _
                Or ((data.length - 16) _
                And 268435455))
    data(16) = CType(((flagLength + 8) _
                And 255), Byte)
    data(17) = CType((flagLength And 255), Byte)
    ' RLP 1.31 Protocol PDU Identifier
    data(18) = CType(0, Byte)
    data(19) = CType(0, Byte)
    data(20) = CType(0, Byte)
    data(21) = CType(4, Byte)
    ' Sender's CID
    Dim i As Integer = 22
    Do While (i < 38)
        data(i) = CType(i, Byte)
        i = (i + 1)
    Loop

    ' Flags and length
    flagLength = (28672 _
                Or ((data.length - 38) _
                And 268435455))
    data(38) = CType(((flagLength + 8) _
                And 255), Byte)
    data(39) = CType((flagLength And 255), Byte)
    ' DMP Protocol PDU Identifier
    data(40) = CType(0, Byte)
    data(41) = CType(0, Byte)
    data(42) = CType(0, Byte)
    data(43) = CType(2, Byte)
    ' Source name
    data(44) = Microsoft.VisualBasic.ChrW(79)
    data(45) = Microsoft.VisualBasic.ChrW(33)
    data(46) = Microsoft.VisualBasic.ChrW(70)
    data(47) = Microsoft.VisualBasic.ChrW(77)
    data(48) = Microsoft.VisualBasic.ChrW(83)
    Dim i As Integer = 48
    Do While (i < 108)
        data(i) = 0
        i = (i + 1)
    Loop

    ' Priority
    data(108) = 100
    ' Reserved
    data(109) = 0
    data(110) = 0
    ' Sequence Number
    data(111) = 0
    ' Options
    data(112) = 0
    ' Universe number
    ' 113-114 are done in setUniverseNumber()
    ' Flags and length
    flagLength = (28672 _
                Or ((data.length - 115) _
                And 268435455))
    data(115) = CType(((flagLength + 8) _
                And 255), Byte)
    data(116) = CType((flagLength And 255), Byte)
    ' DMP Set Property Message PDU
    data(116) = CType(2, Byte)
    ' Address Type & Data Type
    data(117) = CType(161, Byte)
    ' First Property Address
    data(119) = 0
    data(120) = 0
    ' Address Increment
    data(121) = 0
    data(122) = 1
    ' Property value count
    Dim numProperties As Integer = (1 _
                + (Me.pointIndices.length * 3))
    data(123) = CType(((numProperties + 8) _
                And 255), Byte)
    data(124) = CType((numProperties And 255), Byte)
    ' DMX Start 
    data(125) = 0
End Sub