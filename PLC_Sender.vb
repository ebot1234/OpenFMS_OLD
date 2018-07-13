Imports Microsoft.VisualBasic

Imports OFMS.FieldAndRobots
Imports OFMS.GovernThread
Imports OFMS.Main
Imports java.io.IOException
Imports java.net.DatagramPacket
Imports java.net.DatagramSocket
Imports java.net.InetAddress
Imports java.net.SocketException
Imports java.net.UnknownHostException
Imports java.nio.ByteBuffer
Imports java.util.Arrays
Imports java.util.zip.CRC32
Public Class PLC_Sender

    '<editor-fold defaultstate="collapsed" desc="Variables">
    Private dsock As DatagramSocket

    Private PLC_IP As String = "10.0.0.7"

    Private addr As InetAddress

    Private Shared LIGHT_OFF As Byte = "0".getBytes(0)

    Private Shared LIGHT_ON As Byte = "1".getBytes(0)

    Private Shared LIGHT_BLINKING As Byte = "S".getBytes(0)

    Private Shared FIELD_OFF As Byte = "0".getBytes(0)

    Private Shared FIELD_ON As Byte = "1".getBytes(0)

    Private Shared FIELD_BLINKING As Byte = "S".getBytes(0)

    Private Shared LIGHT_MODE As Byte = "L".getBytes(0)

    Private Shared TEAM_NUM_MODE As Byte = "N".getBytes(0)

    Private Shared TIME_MODE As Byte = "T".getBytes(0)

    Private Shared VIEW_MODE As Byte = "V".getBytes(0)

    Private Shared BYTE_ZERO As Byte = "0".getBytes(0)

    Private Shared BYTE_CLEAR As Byte = BYTE_ZERO

    Private Shared HW_MODE As Byte = "H".getBytes(0)

    'Scale byte
    Private Shared SCALE_SENSOR1 As Byte = "SS1".getBytes(0)

    Private Shared SCALE_SENSOR2 As Byte = "SS2".getBytes(0)

    'Red side Switch
    Private Shared RED_SWITCH_SENSOR1 As Byte = "RSS1".getBytes(0)

    Private Shared RED_SWITCH_SENSOR2 As Byte = "RSS2".getBytes(0)

    'Blue side Switch
    Private Shared BLUE_SWITCH_SENSOR2 As Byte = "BSS2".getBytes(0)

    Private Shared BLUE_SWITCH_SENSOR1 As Byte = "BSS1".getBytes(0)

    Private Shared NeitherAlliance As Byte = "NA".getBytes(0)

    'Scale and Switch relays for the lights
    Private Shared SCALE_RELAY1 As Byte = "SR1".getBytes(0)

    Private Shared SCALE_RELAY2 As Byte = "SR2".getBytes(0)

    Private Shared SCALE_RELAY3 As Byte = "SR3".getBytes(0)

    Private Shared SCALE_RELAY4 As Byte = "SR4".getBytes(0)

    Private Shared SCALE_RELAY5 As Byte = "SR5".getBytes(0)

    Private Shared SCALE_RELAY6 As Byte = "SR6".getBytes(0)

    Private Shared RED_SWITCH_RELAY1_OFF As Byte = "RSR1_OFF".getBytes(0)

    Private Shared RED_SWITCH_RELAY1_ON As Byte = "RSR1_ON".getBytes(0)

    Private Shared RED_SWITCH_RELAY2_OFF As Byte = "RSR2_OFF".getBytes(0)

    Private Shared RED_SWITCH_RELAY2_ON As Byte = "RED_SWITCH_RELAY2_ON".getBytes(0)

    Private Shared RED_SWITCH_RELAY3_OFF As Byte = "RSR3_OFF".getBytes(0)

    Private Shared RED_SWITCH_RELAY3_ON As Byte = "RSR3_ON".getBytes(0)

    Private Shared RED_SWITCH_RELAY4_OFF As Byte = "RSR4_OFF".getBytes(0)

    Private Shared RED_SWITCH_RELAY4_ON As Byte = "RSR4_ON".getBytes(0)

    Private Shared RED_SWITCH_RELAY5_OFF As Byte = "RSR5_OFF".getBytes(0)

    Private Shared RED_SWITCH_RELAY5_ON As Byte = "RSR5_ON".getBytes(0)

    Private Shared RED_SWITCH_RELAY6_OFF As Byte = "RSR6_OFF".getBytes(0)

    Private Shared RED_SWITCH_RELAY6_ON As Byte = "RSR6_ON".getBytes(0)

    Private Shared BLUE_SWITCH_RELAY1 As Byte = "BSR1".getBytes(0)

    Private Shared BLUE_SWITCH_RELAY2 As Byte = "BSR2".getBytes(0)

    Private Shared BLUE_SWITCH_RELAY3 As Byte = "BSR3".getBytes(0)

    Private Shared BLUE_SWITCH_RELAY_4 As Byte = "BSR4".getBytes(0)

    Private Shared BLUE_SWITCH_RELAY_5 As Byte = "BSR5".getBytes(0)

    Private Shared BLUE_SWITCH_RELAY_6 As Byte = "BSR6".getBytes(0)

    Private Shared RED As Integer = FieldAndRobots.RED

    Private Shared BLUE As Integer = FieldAndRobots.BLUE

    Private Shared ONE As Integer = FieldAndRobots.ONE

    Private Shared TWO As Integer = FieldAndRobots.TWO

    Private Shared THREE As Integer = FieldAndRobots.THREE

    Private Shared matchTime As String = "0010"

    Private prevTeamNumPacket As DatagramPacket = Nothing

    Private prevLightsPacket As DatagramPacket = Nothing

    Private prevTimePacket As DatagramPacket = Nothing

    Private prevVM_Packet As DatagramPacket = Nothing

    Private prevRedVaultPacket As DatagramPacket = Nothing

    Private prevBlueVaultPacket As DatagramPacket = Nothing

    Private prevBlueSwitchLightsPacket As DatagramPacket = Nothing

    Private prevRedSwitchLightsPacket As DatagramPacket = Nothing

    Private prevScaleLightsPacket As DatagramPacket = Nothing

    Private Shared _instance As PLC_Sender

    '</editor-fold>
    Private Sub New()
        MyBase.New()
        'Start up
        Try
            System.out.println("Made new socket for PLC...")
            Me.dsock = New DatagramSocket
        Catch e As SocketException
            System.out.println("PLC Error 1!")
            e.printStackTrace()
        End Try

        Try
            System.out.println("Made new address for PLC...")
            Me.addr = InetAddress.getByName(Me.PLC_IP)
        Catch ex As UnknownHostException
            System.out.println("PLC Error 2!")
            ex.printStackTrace()
        End Try

        'Send Starter Packets
        Me.updatePLC_TeamNum(True)
        Me.updatePLC_Time(True)
    End Sub

    Public Shared Function getInstance() As PLC_Sender
        If (_instance Is Nothing) Then
            _instance = New PLC_Sender
        End If

        Return _instance
    End Function

    '<editor-fold defaultstate="collapsed" desc="Updater Methods">
    Public Sub updateViewMarq(ByVal forceSend As Boolean)
        System.out.println("PLC Update ViewMarq - Custom")
        Try
            Dim viewmarqPacket As DatagramPacket = Me.buildViewMarqPacket
            If forceSend Then
                System.out.println("FORCE SENDING 1 - PLC Viewmarq")
                Me.dsock.send(viewmarqPacket)
            ElseIf Not Arrays.equals(viewmarqPacket.getData, Me.prevVM_Packet.getData) Then
                Me.dsock.send(viewmarqPacket)
            Else

            End If

            Me.prevVM_Packet = viewmarqPacket
            'System.out.println("SentPacket");
        Catch e As IOException
            System.out.println("PLC Error 1 - ViewMarq!")
        End Try

    End Sub

    Public Sub updatePLC_TeamNum(ByVal forceSend As Boolean)
        System.out.println("PLC Update Team Num")
        Try
            Dim teamPacket As DatagramPacket = Me.buildTeamNumberPacket
            If forceSend Then
                System.out.println("FORCE SENDING 2 - PLC Team Num")
                Me.dsock.send(teamPacket)
            ElseIf Not Arrays.equals(teamPacket.getData, Me.prevTeamNumPacket.getData) Then
                Me.dsock.send(teamPacket)
            Else

            End If

            'System.out.println("SentPacket");
            Me.prevTeamNumPacket = teamPacket
        Catch e As IOException
            System.out.println("PLC Error 2 - Team Num!")
        End Try

    End Sub

    Public Sub updatePLC_Lights(ByVal forceSend As Boolean)
        Try
            Dim lightsPacket As DatagramPacket = Me.buildLightModePacket
            If forceSend Then
                System.out.println("FORCE SENDING 3 - PLC Lights")
                Me.dsock.send(lightsPacket)
            ElseIf Not Arrays.equals(lightsPacket.getData, Me.prevLightsPacket.getData) Then
                Me.dsock.send(lightsPacket)
            Else

            End If

            Me.prevLightsPacket = lightsPacket
            'System.out.println("SentPacket");
        Catch e As IOException
            System.out.println("PLC Error 3 - Lights!" & vbLf)
        End Try

    End Sub

    Public Sub updatePLC_Time(ByVal forceSend As Boolean)
        'System.out.println("PLC Update Time");
        Try
            Dim timePacket As DatagramPacket = Me.buildTimeModePacket
            If forceSend Then
                System.out.println("FORCE SENDING 4 - PLC Time")
                Me.dsock.send(timePacket)
            ElseIf Not Arrays.equals(timePacket.getData, Me.prevTimePacket.getData) Then
                Me.dsock.send(timePacket)
            Else

            End If

            Me.prevTimePacket = timePacket
        Catch e As IOException
            System.out.println("PLC Error 4 - Time!")
        End Try

    End Sub

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Packet Building Methods">
    Private Function buildTimeModePacket() As DatagramPacket
        'System.out.println("Building packet for PLC...");
        Dim data() As Byte = New Byte((9) - 1) {}
        Dim i As Integer = 0
        Do While (i < 9)
            data(i) = BYTE_ZERO
            i = (i + 1)
        Loop

        If (Not (GovernThread.getInstance) Is Nothing) Then
            matchTime = Me.checkAndFixNum(GovernThread.getInstance.get_PLC_Time, 4)
        Else

        End If

        System.out.println(matchTime)
        data(0) = TIME_MODE
        data(1) = matchTime.substring(0, 1).getBytes(0)
        data(2) = matchTime.substring(1, 2).getBytes(0)
        data(3) = matchTime.substring(2, 3).getBytes(0)
        data(4) = matchTime.substring(3, 4).getBytes(0)
        Dim check As CRC32 = New CRC32
        check.update(data)
        Dim crc() As Byte = ByteBuffer.allocate(4).putInt(CType(check.getValue, Integer)).array
        data(5) = crc(0)
        data(6) = crc(1)
        data(7) = crc(2)
        data(8) = crc(3)
        Return New DatagramPacket(data, data.length, Me.addr, 5000)
    End Function

    Private Function buildLightModePacket() As DatagramPacket
        'System.out.println("Building packet for PLC...");
        Dim data() As Byte = New Byte((25) - 1) {}
        Dim i As Integer = 0
        Do While (i < 25)
            data(i) = BYTE_ZERO
            i = (i + 1)
        Loop

        Dim matchRunning As Boolean
        If (Not (GovernThread.getInstance) Is Nothing) Then
            matchRunning = GovernThread.getInstance.isMatchRunning
        Else
            matchRunning = False
        End If

        Dim FAR As FieldAndRobots
        If (Not (FieldAndRobots.getInstance) Is Nothing) Then
            FAR = FieldAndRobots.getInstance
            data(0) = LIGHT_MODE
            data(1) = FAR.teams(RED)(ONE).isReady
            'TODO: Warning!!!, inline IF is not supported ?
            'TODO: Warning!!!, inline IF is not supported ?
            'R1
            data(2) = FAR.teams(RED)(TWO).isReady
            'TODO: Warning!!!, inline IF is not supported ?
            'TODO: Warning!!!, inline IF is not supported ?
            'R2
            data(3) = FAR.teams(RED)(THREE).isReady
            'TODO: Warning!!!, inline IF is not supported ?
            'TODO: Warning!!!, inline IF is not supported ?
            'R3
            data(4) = BYTE_CLEAR
            'Empty byte for fun
            data(5) = FAR.teams(RED)(ONE).isESTOPPED
            'TODO: Warning!!!, inline IF is not supported ?
            data(6) = FAR.teams(RED)(TWO).isESTOPPED
            'TODO: Warning!!!, inline IF is not supported ?
            data(7) = FAR.teams(RED)(THREE).isESTOPPED
            'TODO: Warning!!!, inline IF is not supported ?
            data(8) = BYTE_CLEAR
            'Empty byte for fun
            data(9) = FAR.teams(BLUE)(ONE).isReady
            'TODO: Warning!!!, inline IF is not supported ?
            'TODO: Warning!!!, inline IF is not supported ?
            'B1
            data(10) = FAR.teams(BLUE)(TWO).isReady
            'TODO: Warning!!!, inline IF is not supported ?
            'TODO: Warning!!!, inline IF is not supported ?
            'B2
            data(11) = FAR.teams(BLUE)(THREE).isReady
            'TODO: Warning!!!, inline IF is not supported ?
            'TODO: Warning!!!, inline IF is not supported ?
            'B3
            data(12) = BYTE_CLEAR
            'Empty byte for fun
            data(13) = FAR.teams(BLUE)(ONE).isESTOPPED
            'TODO: Warning!!!, inline IF is not supported ?
            data(14) = FAR.teams(BLUE)(TWO).isESTOPPED
            'TODO: Warning!!!, inline IF is not supported ?
            data(15) = FAR.teams(BLUE)(THREE).isESTOPPED
            'TODO: Warning!!!, inline IF is not supported ?
            data(16) = BYTE_CLEAR
        Else
            System.out.println("PACKET SEND ERROR #1")
        End If

        If (Not (Main.layer) Is Nothing) Then
            Dim redReady As Boolean = Main.layer.isRedReady
            Dim blueReady As Boolean = Main.layer.isBlueReady
            Dim allEstopped As Boolean = PLC_Receiver.isFieldESTOPPED
            data(17) = redReady
            'TODO: Warning!!!, inline IF is not supported ?
            'Red Alliance
            data(19) = blueReady
            'TODO: Warning!!!, inline IF is not supported ?
            'Blue Alliance
            data(18) = (redReady AndAlso blueReady)
            'TODO: Warning!!!, inline IF is not supported ?
            'TODO: Warning!!!, inline IF is not supported ?
            'Main/green light
            data(20) = allEstopped
            'TODO: Warning!!!, inline IF is not supported ?
            ' Horn
        Else

        End If

        Dim check As CRC32 = New CRC32
        check.update(data)
        Dim crc() As Byte = ByteBuffer.allocate(4).putInt(CType(check.getValue, Integer)).array
        ' CRC hash
        data(21) = crc(0)
        data(22) = crc(1)
        data(23) = crc(2)
        data(24) = crc(3)
        Return New DatagramPacket(data, data.length, Me.addr, 5000)
    End Function

    Private Function buildScaleandSwitchLights() As DatagramPacket
        Dim data() As Byte = New Byte((25) - 1) {}
        Dim i As Integer = 0
        Do While (i < 25)
            data(i) = BYTE_ZERO
            i = (i + 1)
        Loop

        Dim warmUp As Boolean
        If (Not (GovernThread.getInstance) Is Nothing) Then
            warmUp = GovernThread.getInstance.isWarmUp
        Else
            warmUp = False
        End If

        Dim FAR As FieldAndRobots
        If (Not (FieldAndRobots.getInstance) Is Nothing) Then
            FAR = FieldAndRobots.getInstance
        End If

        Return New DatagramPacket(data, data.length, Me.addr, 5000)
    End Function

    Private Function buildTeamNumberPacket() As DatagramPacket
        Dim data() As Byte = New Byte((30) - 1) {}
        Dim i As Integer = 0
        Do While (i < 30)
            data(i) = BYTE_ZERO
            i = (i + 1)
        Loop

        Dim FAR As FieldAndRobots
        If (Not (FieldAndRobots.getInstance) Is Nothing) Then
            FAR = FieldAndRobots.getInstance
            data(0) = TEAM_NUM_MODE
            Dim r1 As String = Me.checkAndFixNum(("" + FAR.teams(RED)(ONE).getTeamNumber), 4)
            data(1) = r1.substring(0, 1).getBytes(0)
            data(2) = r1.substring(1, 2).getBytes(0)
            data(3) = r1.substring(2, 3).getBytes(0)
            data(4) = r1.substring(3, 4).getBytes(0)
            Dim r2 As String = Me.checkAndFixNum(("" + FAR.teams(RED)(TWO).getTeamNumber), 4)
            data(5) = r2.substring(0, 1).getBytes(0)
            data(6) = r2.substring(1, 2).getBytes(0)
            data(7) = r2.substring(2, 3).getBytes(0)
            data(8) = r2.substring(3, 4).getBytes(0)
            Dim r3 As String = Me.checkAndFixNum(("" + FAR.teams(RED)(THREE).getTeamNumber), 4)
            data(9) = r3.substring(0, 1).getBytes(0)
            data(10) = r3.substring(1, 2).getBytes(0)
            data(11) = r3.substring(2, 3).getBytes(0)
            data(12) = r3.substring(3, 4).getBytes(0)
            data(13) = BYTE_CLEAR
            Dim b1 As String = Me.checkAndFixNum(("" + FAR.teams(BLUE)(ONE).getTeamNumber), 4)
            data(14) = b1.substring(0, 1).getBytes(0)
            data(15) = b1.substring(1, 2).getBytes(0)
            data(16) = b1.substring(2, 3).getBytes(0)
            data(17) = b1.substring(3, 4).getBytes(0)
            Dim b2 As String = Me.checkAndFixNum(("" + FAR.teams(BLUE)(TWO).getTeamNumber), 4)
            data(18) = b2.substring(0, 1).getBytes(0)
            data(19) = b2.substring(1, 2).getBytes(0)
            data(20) = b2.substring(2, 3).getBytes(0)
            data(21) = b2.substring(3, 4).getBytes(0)
            Dim b3 As String = Me.checkAndFixNum(("" + FAR.teams(BLUE)(THREE).getTeamNumber), 4)
            data(22) = b3.substring(0, 1).getBytes(0)
            data(23) = b3.substring(1, 2).getBytes(0)
            data(24) = b3.substring(2, 3).getBytes(0)
            data(25) = b3.substring(3, 4).getBytes(0)
        Else
            System.out.println("PACKET SEND ERROR")
        End If

        Dim check As CRC32 = New CRC32
        check.update(data)
        Dim crc() As Byte = ByteBuffer.allocate(4).putInt(CType(check.getValue, Integer)).array
        ' CRC hash
        data(26) = crc(0)
        data(27) = crc(1)
        data(28) = crc(2)
        data(29) = crc(3)
        Return New DatagramPacket(data, data.length, Me.addr, 5000)
    End Function

    Private Function buildViewMarqPacket() As DatagramPacket
        Dim data() As Byte = New Byte((20) - 1) {}
        Dim i As Integer = 0
        Do While (i < 20)
            data(i) = BYTE_ZERO
            i = (i + 1)
        Loop

        If (1 = 1) Then
            Dim message As String = "<ID 1><T>Hello World!</T>"
            data(0) = VIEW_MODE
            data(1) = message.substring(0, 1).getBytes(0)
            data(2) = message.substring(1, 2).getBytes(0)
            data(3) = message.substring(2, 3).getBytes(0)
            data(4) = message.substring(3, 4).getBytes(0)
            data(5) = message.substring(4, 5).getBytes(0)
            data(6) = message.substring(5, 6).getBytes(0)
            data(7) = message.substring(6, 7).getBytes(0)
            data(8) = message.substring(7, 8).getBytes(0)
            data(9) = message.substring(8, 9).getBytes(0)
            data(10) = message.substring(10, 11).getBytes(0)
            data(11) = message.substring(11, 12).getBytes(0)
            data(12) = message.substring(12, 13).getBytes(0)
            data(13) = message.substring(13, 14).getBytes(0)
            data(14) = message.substring(14, 15).getBytes(0)
            data(15) = message.substring(15, 16).getBytes(0)
            data(13) = message.substring(16, 17).getBytes(0)
            data(14) = message.substring(17, 18).getBytes(0)
            data(15) = message.substring(18, 19).getBytes(0)
            data(15) = message.substring(19, 20).getBytes(0)
        Else
            System.out.println("ViewMarq PACKET SEND ERROR")
        End If

        Return New DatagramPacket(data, data.length, Me.addr, 5000)
    End Function

    '</editor-fold>
    Private Function checkAndFixNum(ByVal initTime As String, ByVal length As Integer) As String
        If (initTime.length < length) Then
            initTime = "0".concat(initTime)
            Return Me.checkAndFixNum(initTime, length)
        End If

        Return initTime
    End Function
End Class