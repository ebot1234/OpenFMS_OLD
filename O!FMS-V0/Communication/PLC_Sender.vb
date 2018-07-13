Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Threading
Imports System
Imports System.Net
Imports System.Net.IPEndPoint
Imports System.Net.Sockets
Imports System.Net.IPAddress
Imports System.Text
Public Class PLC_Sender

    '<editor-fold defaultstate="collapsed" desc="Variables">
    Dim dsock As Integer = 5000

    Dim PLC_IP As String = "10.0.0.7"
    Public DatagramPacket As String
    Dim addr
    Dim strmessage
    Dim bytCommand As Byte() = New Byte() {}
 

        

        Dim LIGHT_OFF As Byte = AscW("0"(0))

        Dim LIGHT_ON As Byte = AscW("1"(0))

        Dim LIGHT_BLINKING As Byte = AscW("S"(0))

        Dim FIELD_OFF As Byte = AscW("0"(0))

        Dim FIELD_ON As Byte = AscW("1"(0))

        Dim FIELD_BLINKING As Byte = AscW("S"(0))

        Dim LIGHT_MODE As Byte = AscW("L"(0))

        Dim TEAM_NUM_MODE As Byte = AscW("N"(0))

        Dim TIME_MODE As Byte = AscW("T"(0))

        Dim VIEW_MODE As Byte = AscW("V"(0))

        Dim BYTE_ZERO As Byte = AscW("0"(0))

        Dim BYTE_CLEAR As Byte = BYTE_ZERO

        Dim HW_MODE As Byte = AscW("H"(0))

        'Scale byte
        Dim SCALE_SENSOR1 As Byte = AscW("SS1"(0))

        Dim SCALE_SENSOR2 As Byte = AscW("SS2"(0))

        'Red side Switch
        Dim RED_SWITCH_SENSOR1 As Byte = AscW("RSS1"(0))

        Dim RED_SWITCH_SENSOR2 As Byte = AscW("RSS2"(0))

        'Blue side Switch
        Dim BLUE_SWITCH_SENSOR2 As Byte = AscW("BSS2"(0))

        Dim BLUE_SWITCH_SENSOR1 As Byte = AscW("BSS1"(0))

        Dim NeitherAlliance As Byte = AscW("NA"(0))

        'Scale and Switch relays for the lights
        Dim SCALE_RELAY1 As Byte = AscW("SR1"(0))

        Dim SCALE_RELAY2 As Byte = AscW("SR2"(0))

        Dim SCALE_RELAY3 As Byte = AscW("SR3"(0))

        Dim SCALE_RELAY4 As Byte = AscW("SR4"(0))

        Dim SCALE_RELAY5 As Byte = AscW("SR5"(0))

        Dim SCALE_RELAY6 As Byte = AscW("SR6"(0))

        Dim RED_SWITCH_RELAY1_OFF As Byte = AscW("RSR1_OFF"(0))

        Dim RED_SWITCH_RELAY1_ON As Byte = AscW("RSR1_ON"(0))

        Dim RED_SWITCH_RELAY2_OFF As Byte = AscW("RSR2_OFF"(0))

        Dim RED_SWITCH_RELAY2_ON As Byte = AscW("RED_SWITCH_RELAY2_ON"(0))

        Dim RED_SWITCH_RELAY3_OFF As Byte = AscW("RSR3_OFF"(0))

        Dim RED_SWITCH_RELAY3_ON As Byte = AscW("RSR3_ON"(0))

        Dim RED_SWITCH_RELAY4_OFF As Byte = AscW("RSR4_OFF"(0))

        Dim RED_SWITCH_RELAY4_ON As Byte = AscW("RSR4_ON"(0))

        Dim RED_SWITCH_RELAY5_OFF As Byte = AscW("RSR5_OFF"(0))

        Dim RED_SWITCH_RELAY5_ON As Byte = AscW("RSR5_ON"(0))

        Dim RED_SWITCH_RELAY6_OFF As Byte = AscW("RSR6_OFF"(0))

        Dim RED_SWITCH_RELAY6_ON As Byte = AscW("RSR6_ON"(0))

        Dim BLUE_SWITCH_RELAY1 As Byte = AscW("BSR1"(0))

        Dim BLUE_SWITCH_RELAY2 As Byte = AscW("BSR2"(0))

        Dim BLUE_SWITCH_RELAY3 As Byte = AscW("BSR3"(0))

        Dim BLUE_SWITCH_RELAY_4 As Byte = AscW("BSR4"(0))

        Dim BLUE_SWITCH_RELAY_5 As Byte = AscW("BSR5"(0))

        Dim BLUE_SWITCH_RELAY_6 As Byte = AscW("BSR6"(0))

        Dim RED As Integer = FieldAndRobots.RED

        Dim BLUE As Integer = FieldAndRobots.BLUE

        Dim ONE As Integer = FieldAndRobots.ONE

        Dim TWO As Integer = FieldAndRobots.TWO

        Dim THREE As Integer = FieldAndRobots.THREE

        Dim matchTime As String = "0010"

    Dim prevTeamNumPacket 'As DatagramPacket = Nothing

    Dim prevLightsPacket ' As DatagramPacket = Nothing

    Dim prevTimePacket 'As DatagramPacket = Nothing

    Dim prevVM_Packet 'As DatagramPacket = Nothing

    Dim prevRedVaultPacket 'As DatagramPacket = Nothing

    Dim prevBlueVaultPacket 'As DatagramPacket = Nothing

    Dim prevBlueSwitchLightsPacket 'As DatagramPacket = Nothing

    Dim prevRedSwitchLightsPacket 'As DatagramPacket = Nothing

    Dim prevScaleLightsPacket 'As DatagramPacket = Nothing

    Dim _instance As PLC_Sender



    '</editor-fold>
    Public Overridable Function GetBytes(
s As String
) As Byte()
    End Function
    Public Sub New()
        MyBase.New()
        Dim udpclient As New UdpClient
        udpclient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, True)
        Dim bytsent As Byte() = Encoding.ASCII.GetBytes(strmessage)
        udpclient.Send(bytsent, bytsent.Length)
        'Start up
        Try
            udpclient.Connect(PLC_IP, 7000)
        Catch e As SocketException
            'System.out.println("PLC Error 1!")
            'e.printStackTrace()
        End Try

        Try
            'System.out.println("Made new address for PLC...")
            Me.addr = PLC_IP
        Catch ex As Exception
            ' System.out.println("PLC Error 2!")
            'ex.printStackTrace()
        End Try

        'Send Starter Packets
        Me.updatePLC_TeamNum(True)
        Me.updatePLC_Time(True)
    End Sub

    'Public Shared Function getInstance() As PLC_Sender
    '    If (_instance Is Nothing) Then
    '        _instance = New PLC_Sender
    '    End If

    '    Return _instance
    'End Function

    '<editor-fold defaultstate="collapsed" desc="Updater Methods">
    Public Sub updateViewMarq(ByVal forceSend As Boolean)
        'System.out.println("PLC Update ViewMarq - Custom")
        Try
            Dim viewmarqPacket = Me.buildViewMarqPacket
            If forceSend Then
                Console.Out.Write("FORCE SENDING 1 - PLC Viewmarq")
                Me.dsock(viewmarqPacket)
            ElseIf Not Array.Equals(viewmarqPacket.getData, Me.prevVM_Packet.getData) Then
                UdpClient.Send(viewmarqPacket, viewmarqPacket.length)
            Else

            End If

            Me.prevVM_Packet = viewmarqPacket
            'System.out.println("SentPacket");
        Catch e As IO.IOException
            MessageBox.Show("PLC Error 1 - ViewMarq!")
        End Try

    End Sub

    Public Sub updatePLC_TeamNum(ByVal forceSend As Boolean)
        'System.out.println("PLC Update Team Num")
        Try
            Dim teamPacket As DatagramPacket = Me.buildTeamNumberPacket
            If forceSend Then
                'System.out.println("FORCE SENDING 2 - PLC Team Num")
                UdpClient.Send(teamPacket, teamPacket.length)
            ElseIf Not Array.Equals(teamPacket.getData, Me.prevTeamNumPacket.getData) Then
                UdpClient.Send(teamPacket, teamPacket.length)
            Else

            End If

            'System.out.println("SentPacket");
            Me.prevTeamNumPacket = teamPacket
        Catch e As IO.IOException
            'System.out.println("PLC Error 2 - Team Num!")
        End Try

    End Sub

    Public Sub updatePLC_Lights(ByVal forceSend As Boolean)
        Try
            Dim lightsPacket As DatagramPacket = Me.buildLightModePacket
            If forceSend Then
                Console.Out.Write("FORCE SENDING 3 - PLC Lights")
                UdpClient.Send(lightsPacket)
            ElseIf Not Array.Equals(lightsPacket.getData, Me.prevLightsPacket.getData) Then
                UdpClient.Send(lightsPacket)
            Else

            End If

            Me.prevLightsPacket = lightsPacket
            'System.out.println("SentPacket");
        Catch e As IO.IOException
            'System.out.println("PLC Error 3 - Lights!" & vbLf)
        End Try

    End Sub

    Public Sub updatePLC_Time(ByVal forceSend As Boolean)
        'System.out.println("PLC Update Time");
        Try
            Dim timePacket As DatagramPacket = Me.buildTimeModePacket
            If forceSend Then
                ' System.out.println("FORCE SENDING 4 - PLC Time")
                UdpClient.Send(timePacket)
            ElseIf Not Array.Equals(timePacket.getData, Me.prevTimePacket.getData) Then
                UdpClient.Send(timePacket)
            Else

            End If

            Me.prevTimePacket = timePacket
        Catch e As IO.IOException
            'System.out.println("PLC Error 4 - Time!")
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

        Console.Out.Write(matchTime)
        data(0) = TIME_MODE
        data(1) = AscW(matchTime.Substring(0, 1)(0))
        data(2) = AscW(matchTime.Substring(1, 2)(0))
        data(3) = AscW(matchTime.Substring(2, 3)(0))
        data(4) = AscW(matchTime.Substring(3, 4)(0))
        Dim check As Crc32 = New Crc32
        ' check.Equals(data)
        'Dim crc() As Byte = ByteBuffer.allocate(4).putInt(CType(check.getValue, Integer)).array
        ' data(5) = crc(0)
        'data(6) = crc(1)
        'data(7) = crc(2)
        ' data(8) = crc(3)
        'Return New DatagramPacket(data, data.Length, Me.addr, 5000)
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
            Console.Out.Write("PACKET SEND ERROR #1")
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
        ''check.update(data)
        'Dim crc() As Byte = ByteBuffer.allocate(4).putInt(CType(check.getValue, Integer)).array
        '' CRC hash
        'data(21) = crc(0)
        'data(22) = crc(1)
        'data(23) = crc(2)
        'data(24) = crc(3)
        'Return New DatagramPacket(data, data.Length, Me.addr, 5000)
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

        Return New DatagramPacket(data, data.Length, Me.addr, 5000)
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
            data(1) = AscW(r1.Substring(0, 1)(0))
            data(2) = AscW(r1.Substring(1, 2)(0))
            data(3) = AscW(r1.Substring(2, 3)(0))
            data(4) = AscW(r1.Substring(3, 4)(0))
            Dim r2 As String = Me.checkAndFixNum(("" + FAR.teams(RED)(TWO).getTeamNumber), 4)
            data(5) = AscW(r2.Substring(0, 1)(0))
            data(6) = AscW(r2.Substring(1, 2)(0))
            data(7) = AscW(r2.Substring(2, 3)(0))
            data(8) = AscW(r2.Substring(3, 4)(0))
            Dim r3 As String = Me.checkAndFixNum(("" + FAR.teams(RED)(THREE).getTeamNumber), 4)
            data(9) = AscW(r3.Substring(0, 1)(0))
            data(10) = AscW(r3.Substring(1, 2)(0))
            data(11) = AscW(r3.Substring(2, 3)(0))
            data(12) = AscW(r3.Substring(3, 4)(0))
            data(13) = BYTE_CLEAR
            Dim b1 As String = Me.checkAndFixNum(("" + FAR.teams(BLUE)(ONE).getTeamNumber), 4)
            data(14) = AscW(b1.Substring(0, 1)(0))
            data(15) = AscW(b1.Substring(1, 2)(0))
            data(16) = AscW(b1.Substring(2, 3)(0))
            data(17) = AscW(b1.Substring(3, 4)(0))
            Dim b2 As String = Me.checkAndFixNum(("" + FAR.teams(BLUE)(TWO).getTeamNumber), 4)
            data(18) = AscW(b2.Substring(0, 1)(0))
            data(19) = AscW(b2.Substring(1, 2)(0))
            data(20) = AscW(b2.Substring(2, 3)(0))
            data(21) = AscW(b2.Substring(3, 4)(0))
            Dim b3 As String = Me.checkAndFixNum(("" + FAR.teams(BLUE)(THREE).getTeamNumber), 4)
            data(22) = AscW(b3.Substring(0, 1)(0))
            data(23) = AscW(b3.Substring(1, 2)(0))
            data(24) = AscW(b3.Substring(2, 3)(0))
            data(25) = AscW(b3.Substring(3, 4)(0))
        Else
            Console.Out.Write("PACKET SEND ERROR")
        End If

        'Dim check As CRC32 = New CRC32
        'check.update(data)
        'Dim crc() As Byte = ByteBuffer.allocate(4).putInt(CType(check.getValue, Integer)).array
        ' CRC hash
        'data(26) = crc(0)
        'data(27) = crc(1)
        'data(28) = crc(2)
        'data(29) = crc(3)
        Return New DatagramPacket(data, data.Length, Me.addr, 5000)
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
            data(1) = AscW(message.Substring(0, 1)(0))
            data(2) = AscW(message.Substring(1, 2)(0))
            data(3) = AscW(message.Substring(2, 3)(0))
            data(4) = AscW(message.Substring(3, 4)(0))
            data(5) = AscW(message.Substring(4, 5)(0))
            data(6) = AscW(message.Substring(5, 6)(0))
            data(7) = AscW(message.Substring(6, 7)(0))
            data(8) = AscW(message.Substring(7, 8)(0))
            data(9) = AscW(message.Substring(8, 9)(0))
            data(10) = AscW(message.Substring(10, 11)(0))
            data(11) = AscW(message.Substring(11, 12)(0))
            data(12) = AscW(message.Substring(12, 13)(0))
            data(13) = AscW(message.Substring(13, 14)(0))
            data(14) = AscW(message.Substring(14, 15)(0))
            data(15) = AscW(message.Substring(15, 16)(0))
            data(13) = AscW(message.Substring(16, 17)(0))
            data(14) = AscW(message.Substring(17, 18)(0))
            data(15) = AscW(message.Substring(18, 19)(0))
            data(15) = AscW(message.Substring(19, 20)(0))
        Else
            Console.Out.Write("ViewMarq PACKET SEND ERROR")
        End If

        Return New DatagramPacket(data, data.Length, Me.addr, 5000)
    End Function

    '</editor-fold>
    Private Function checkAndFixNum(ByVal initTime As String, ByVal length As Integer) As String
        If (initTime.Length < length) Then
            initTime = "0".Concat(initTime)
            Return Me.checkAndFixNum(initTime, length)
        End If

        Return initTime
    End Function
End Class