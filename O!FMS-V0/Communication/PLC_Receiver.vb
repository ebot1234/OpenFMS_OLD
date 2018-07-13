Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Threading
Imports System
Imports System.Net
Imports System.Net.IPEndPoint
Imports System.Net.Sockets
Imports System.Net.IPAddress
Imports System.Text
Imports O_FMS_V0.FieldAndRobots


Public Class PLC_Receiver

    Dim updClient As New UdpClient

    Dim gloip As Net.IPAddress
    Dim ReceiveMessages
    Dim Red1Estop
    Dim Red2Estop
    Dim Red3Estop
    Dim Blue1Estop
    Dim Blue2Estop
    Dim Blue3Estop

    Public receivingudpclient As New UdpClient
    Public RemoteIpEndpiont As New System.Net.IPEndPoint(System.Net.IPAddress.Any, 0)
    Public ThreadReceive As System.Threading.Thread
    Public SocketNum As Integer
    Public DatagramPacket





    Private Shared RED As Integer = FieldAndRobots.RED

    Private Shared BLUE As Integer = FieldAndRobots.BLUE

    Private Shared ONE As Integer = FieldAndRobots.ONE

    Private Shared TWO As Integer = FieldAndRobots.TWO

    Private Shared THREE As Integer = FieldAndRobots.THREE

    Public dataStr As String

    Private Shared field_ESTOPPED As Boolean = False

    Public Sub New()
        MyBase.New()
        
        Try
            SocketNum = 7000
            receivingudpclient = New System.Net.Sockets.UdpClient(SocketNum)

            Dim receiveBytes As [Byte]() = receivingudpclient.Receive(RemoteIpEndpiont)
            Dim returnData As String = Encoding.ASCII.GetString(receiveBytes)
        Catch e As SocketException
            MessageBox.Show("Couldn't setup PLC Receiver socket")
        End Try

    End Sub

    Public Shared Function isFieldESTOPPED() As Boolean
        Return field_ESTOPPED
    End Function

    Public Shared Sub resetFieldESTOPPED()
        field_ESTOPPED = False
    End Sub

    '<Override()> _
    Public Sub run()
        ' Sets up a byte array for the incoming packet
        Dim data() As Byte = New Byte((6) - 1) {}
        ' Sets up a Datagram Packet(aka UDP) to receive PLC data.



        

        Try
            ' Takes in the data from the packet and puts it into a string
            Me.dataStr = New String(dataStr)
            ' COULD THIS BE A PROBLEM?
            'Msg.send(("Recieved PLC String: " + Me.dataStr))

            If Me.dataStr.Substring(0, 6).Equals("111111") Then

                Red1estop = True
                Red2estop = True
                Red3estop = True
                Blue1Estop = True
                Blue2Estop = True
                Blue3Estop = True

            Else
                'Msg.send("Updating robot ESTOP")
                ' If Red One requested an ESTOP then do it
                If Me.dataStr.Substring(0, 1).Equals("1") Then
                    'AD_Test_Panel.getInstance.updateES_Indic(RED, ONE, True)
                    Red1Estop = True
                End If

                ' If Red Two requested an ESTOP then do it
                If Me.dataStr.Substring(1, 2).Equals("1") Then
                    'AD_Test_Panel.getInstance.updateES_Indic(RED, TWO, True)
                    Red2Estop = True
                End If

                ' If Red Three requested an ESTOP then do it
                If Me.dataStr.Substring(2, 3).Equals("1") Then
                    ' Msg.send("Updating R3 ESTOP")
                    'AD_Test_Panel.getInstance.updateES_Indic(RED, THREE, True)
                    Red3Estop = True
                End If

                ' If Blue One requested an ESTOP then do it
                If Me.dataStr.Substring(3, 4).Equals("1") Then
                    'AD_Test_Panel.getInstance.updateES_Indic(BLUE, ONE, True)
                    Blue1Estop = True
                End If

                ' If Blue Two requested an ESTOP then do it
                If Me.dataStr.Substring(4, 5).Equals("1") Then
                    ' AD_Test_Panel.getInstance.updateES_Indic(BLUE, TWO, True)
                    Blue2Estop = True
                End If

                ' If Blue Three requested an ESTOP then do it
                If Me.dataStr.Substring(5, 6).Equals("1") Then
                    'AD_Test_Panel.getInstance.updateES_Indic(BLUE, THREE, True)
                    Blue3Estop = True
                End If

            End If

            'add the indicators for year specfic stuff
            If Me.dataStr.Substring(0, 6).Equals("111111") Then
                ' && GovernThread.getInstance().isMatchRunning()) {
                MessageBox.Show("Full Field ESTOP")
                ' Stop the match
                Main.layer.stopMatch()
                ' ESTOP all of the Red robots
                'FieldAndRobots.getInstance.actOnRobot(RED, ONE, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                'FieldAndRobots.getInstance.actOnRobot(RED, TWO, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                'FieldAndRobots.getInstance.actOnRobot(RED, THREE, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                '' ESTOP all of the Blue robots
                'FieldAndRobots.getInstance.actOnRobot(BLUE, ONE, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                'FieldAndRobots.getInstance.actOnRobot(BLUE, TWO, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                'FieldAndRobots.getInstance.actOnRobot(BLUE, THREE, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                ' Yes, the field has been ESTOPPED
                field_ESTOPPED = True
            Else
                ' The entire field has not been ESTOPPED
                'System.out.println("***Individual Team ESTOP")
                'if (GovernThread.getInstance().isMatchRunning()) {
                'AD_Test_Panel.getInstance().updateAll_ES_Indic(false);
                ' If Red One requested an ESTOP then do it
                If Me.dataStr.Substring(0, 1).Equals("1") Then
                    'FieldAndRobots.getInstance.actOnRobot(RED, ONE, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                End If

                ' If Red Two requested an ESTOP then do it
                If Me.dataStr.Substring(1, 2).Equals("1") Then
                    ' FieldAndRobots.getInstance.actOnRobot(RED, TWO, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                End If

                ' If Red Three requested an ESTOP then do it
                If Me.dataStr.Substring(2, 3).Equals("1") Then
                    ' FieldAndRobots.getInstance.actOnRobot(RED, THREE, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                End If

                ' If Blue One requested an ESTOP then do it
                If Me.dataStr.Substring(3, 4).Equals("1") Then
                    ' FieldAndRobots.getInstance.actOnRobot(BLUE, ONE, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                End If

                ' If Blue Two requested an ESTOP then do it
                If Me.dataStr.Substring(4, 5).Equals("1") Then
                    'FieldAndRobots.getInstance.actOnRobot(BLUE, TWO, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                End If

                ' If Blue Three requested an ESTOP then do it
                If Me.dataStr.Substring(5, 6).Equals("1") Then
                    ' FieldAndRobots.getInstance.actOnRobot(BLUE, THREE, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                End If

                ' }
            End If

            'Scale and Switch plc stuff
            'If the plc get the game data is equal to LLL
            If Me.dataStr.Substring(0).Equals("LLL") Then
                If Me.dataStr.Substring(0).Equals("SS1") Then
                    'FieldAndRobots.getInstance.RedOwnership()
                End If

                If Me.dataStr.Substring(1).Equals("SS2") Then
                    ' FieldAndRobots.getInstance.BlueOwnership()
                End If

                If Me.dataStr.Substring(2).Equals("RSS1") Then
                    ' FieldAndRobots.getInstance.RedOwnership()
                End If

                If Me.dataStr.Substring(3).Equals("RSS2") Then
                    'FieldAndRobots.getInstance.BlueOwnership()
                End If

                If Me.dataStr.Substring(4).Equals("BSS1") Then
                    'FieldAndRobots.getInstance.RedOwnership()
                End If

                If Me.dataStr.Substring(5).Equals("BSS2") Then
                    'FieldAndRobots.getInstance.BlueOwnership()
                End If

            End If

            'if the game data is RRR
            If Me.dataStr.Substring(0).Equals("RRR") Then
                If Me.dataStr.Substring(0).Equals("SS1") Then
                    'FieldAndRobots.getInstance.BlueOwnership()
                End If

                If Me.dataStr.Substring(1).Equals("SS2") Then
                    'FieldAndRobots.getInstance.RedOwnership()
                End If

                If Me.dataStr.Substring(2).Equals("RSS1") Then
                    'FieldAndRobots.getInstance.BlueOwnership()
                End If

                If Me.dataStr.Substring(3).Equals("RSS2") Then
                    'FieldAndRobots.getInstance.RedOwnership()
                End If

                If Me.dataStr.Substring(4).Equals("BSS1") Then
                    'FieldAndRobots.getInstance.BlueOwnership()
                End If

                If Me.dataStr.Substring(5).Equals("BSS2") Then
                    'FieldAndRobots.getInstance.RedOwnership()
                End If

            End If

            'if the game data is LRL
            If Me.dataStr.Substring(0).Equals("LRL") Then
                If Me.dataStr.Substring(0).Equals("SS1") Then
                    'FieldAndRobots.getInstance.RedOwnership()
                End If

                If Me.dataStr.Substring(1).Equals("SS2") Then
                    'FieldAndRobots.getInstance.BlueOwnership()
                End If

                If Me.dataStr.Substring(2).Equals("RSS1") Then
                    'FieldAndRobots.getInstance.BlueOwnership()
                End If

                If Me.dataStr.Substring(3).Equals("RSS2") Then
                    'FieldAndRobots.getInstance.RedOwnership()
                End If

                If Me.dataStr.Substring(4).Equals("BSS1") Then
                    'FieldAndRobots.getInstance.BlueOwnership()
                End If

                If Me.dataStr.Substring(5).Equals("BSS2") Then
                    'FieldAndRobots.getInstance.RedOwnership()
                End If

            End If

            If Me.dataStr.Substring(0).Equals("RLR") Then
                If Me.dataStr.Substring(0).Equals("SS1") Then
                    'FieldAndRobots.getInstance.BlueOwnership()
                End If

                If Me.dataStr.Substring(1).Equals("SS2") Then
                    ' FieldAndRobots.getInstance.RedOwnership()
                End If

                If Me.dataStr.Substring(2).Equals("RSS1") Then
                    'FieldAndRobots.getInstance.RedOwnership()
                End If

                If Me.dataStr.Substring(3).Equals("RSS2") Then
                    'FieldAndRobots.getInstance.BlueOwnership()
                End If

                If Me.dataStr.Substring(4).Equals("BSS1") Then
                    'FieldAndRobots.getInstance.BlueOwnership()
                End If

                If Me.dataStr.Substring(5).Equals("BSS2") Then
                    'FieldAndRobots.getInstance.RedOwnership()
                End If

            End If

            'Power ups
            'If the Red Force becomes active
            If Me.dataStr.Substring(0).Equals("RF1") Then
                'FieldAndRobots.getInstance.redVaultForce(Scoring.CubeNumbers.Force_1)
            End If

            If Me.dataStr.Substring(1).Equals("RF2") Then
                ' FieldAndRobots.getInstance.redVaultForce(Scoring.CubeNumbers.Force_2)
            End If

            If Me.dataStr.Substring(2).Equals("RF3") Then
                ' FieldAndRobots.getInstance.redVaultForce(Scoring.CubeNumbers.Force_3)
            End If

            If Me.dataStr.Substring(9).Equals("RF") Then
                'FieldAndRobots.getInstance.redVaultForce(Scoring.CubeNumbers.Force_PLAYED)
            End If

            'For Red boost
            If Me.dataStr.Substring(6).Equals("RB1") Then
                '  FieldAndRobots.getInstance.redVaultBoost(Scoring.CubeNumbers.Boost_1)
            End If

            If Me.dataStr.Substring(7).Equals("RB2") Then
                'FieldAndRobots.getInstance.redVaultBoost(Scoring.CubeNumbers.Boost_2)
            End If

            If Me.dataStr.Substring(8).Equals("RB3") Then
                'FieldAndRobots.getInstance.redVaultBoost(Scoring.CubeNumbers.Boost_3)
            End If

            If Me.dataStr.Substring(10).Equals("RB") Then
                'FieldAndRobots.getInstance.redVaultBoost(Scoring.CubeNumbers.Boost_PLAYED)
            End If

            'Red Levitiate
            If Me.dataStr.Substring(3).Equals("RLEV1") Then
                ' FieldAndRobots.getInstance.redVaultLev(Scoring.CubeNumbers.Levitate_1)
            End If

            If Me.dataStr.Substring(4).Equals("RLEV2") Then
                ' FieldAndRobots.getInstance.redVaultLev(Scoring.CubeNumbers.Levitate_2)
            End If

            If Me.dataStr.Substring(5).Equals("RLEV3") Then
                'FieldAndRobots.getInstance.redVaultLev(Scoring.CubeNumbers.Levitate_3)
            End If

            If Me.dataStr.Substring(11).Equals("RLEV") Then
                'FieldAndRobots.getInstance.redVaultLev(Scoring.CubeNumbers.Lev_PLAYED)
            End If

            'Fouls coming from the PLC/CMORE Ref Pads
            'Blue Fouls
            If Me.dataStr.Substring(1).Equals("B_F") Then
                'FieldAndRobots.getInstance.blueFoul(Scoring.Fouls.Blue_Foul)
            End If

            'Red Foul
            If Me.dataStr.Substring(2).Equals("R_F") Then
                'FieldAndRobots.getInstance.redFoul(Scoring.Fouls.Red_Foul)
            End If

            'Blue Tech Foul
            If Me.dataStr.Substring(3).Equals("B_Tech") Then
                'FieldAndRobots.getInstance.blueTech(Scoring.Fouls.Blue_Tech)
            End If

            'Red Tech Foul
            If Me.dataStr.Substring(4).Equals("R_Tech") Then
                'FieldAndRobots.getInstance.redTech(Scoring.Fouls.Red_Tech)
            End If

            'Blue Force
            If Me.dataStr.Substring(0).Equals("BF1") Then
                ' FieldAndRobots.getInstance.blueVaultForce(Scoring.CubeNumbers.Force_1)
            End If

            If Me.dataStr.Substring(1).Equals("BF2") Then
                'FieldAndRobots.getInstance.blueVaultForce(Scoring.CubeNumbers.Force_2)
            End If

            If Me.dataStr.Substring(2).Equals("BF3") Then
                'FieldAndRobots.getInstance.blueVaultForce(Scoring.CubeNumbers.Force_3)
            End If

            If Me.dataStr.Substring(3).Equals("BF") Then
                'FieldAndRobots.getInstance.blueVaultForce(Scoring.CubeNumbers.Force_PLAYED)
            End If

            'Blue Boost
            If Me.dataStr.Substring(4).Equals("BB1") Then
                'FieldAndRobots.getInstance.blueVaultBoost(Scoring.CubeNumbers.Boost_1)
            End If

            If Me.dataStr.Substring(5).Equals("BB2") Then
                ' FieldAndRobots.getInstance.blueVaultBoost(Scoring.CubeNumbers.Boost_2)
            End If

            If Me.dataStr.Substring(6).Equals("BB3") Then
                ' FieldAndRobots.getInstance.blueVaultBoost(Scoring.CubeNumbers.Boost_3)
            End If

            If Me.dataStr.Substring(7).Equals("BB") Then
                ' FieldAndRobots.getInstance.blueVaultBoost(Scoring.CubeNumbers.Boost_PLAYED)
            End If

            'Blue Lev
            If Me.dataStr.Substring(8).Equals("BLEV1") Then
                'FieldAndRobots.getInstance.blueVaultLev(Scoring.CubeNumbers.Levitate_1)
            End If

            If Me.dataStr.Substring(9).Equals("BLEV2") Then
                'FieldAndRobots.getInstance.blueVaultLev(Scoring.CubeNumbers.Levitate_2)
            End If

            If Me.dataStr.Substring(10).Equals("BLEV3") Then
                'FieldAndRobots.getInstance.blueVaultLev(Scoring.CubeNumbers.Levitate_3)
            End If

            If Me.dataStr.Substring(11).Equals("BLEV") Then
                'FieldAndRobots.getInstance.blueVaultLev(Scoring.CubeNumbers.Lev_PLAYED)
            End If

           

        Catch e As Exception

        End Try

        ' Reset packet length
        'p.setLength(data.Length)



        'Msg.send("***THE PLC RECEIVER SOCKET HAS BEEN CLOSED***NO MORE PLC RECEIVER***")
    End Sub

    Public Sub shutdownSocket()
        'If (Not (Me.sock) Is Nothing) Then
        'Me.sock.close()
        'End If

    End Sub

    Public Shared Function isBitSet(ByVal data As Byte, ByVal bitPos As Integer) As Boolean
        Dim bitPosition As Integer = (bitPos Mod 8)
        ' Position of this bit in a byte
        Return ((data _
                    + (bitPosition And 1)) _
                    = 1)
    End Function
End Class