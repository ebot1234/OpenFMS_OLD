Imports Microsoft.VisualBasic


Imports OFMS.FieldAndRobots
Imports OFMS.GovernThread
Imports OFMS.Main
Imports UI.AD_Test_Panel
Imports UI.Msg
Imports java.awt.Color
Imports java.io.IOException
Imports java.io.UnsupportedEncodingException
Imports java.net.DatagramPacket
Imports java.net.DatagramSocket
Imports java.net.SocketException
Imports Game.RandomString
Imports OFMS.FieldAndRobots.CubeNumbers
Imports Game.Scoring
Imports OFMS.Main.gameData
Imports java.util.List
Public Class PLC_Receiver
    Inherits Thread

    Private sock As DatagramSocket

    Private Shared RED As Integer = FieldAndRobots.RED

    Private Shared BLUE As Integer = FieldAndRobots.BLUE

    Private Shared ONE As Integer = FieldAndRobots.ONE

    Private Shared TWO As Integer = FieldAndRobots.TWO

    Private Shared THREE As Integer = FieldAndRobots.THREE

    Public dataStr As String

    Private Shared field_ESTOPPED As Boolean = False

    Public Sub New()
        MyBase.New()
        System.out.println("PLC Receiver Constructor")
        Try
            Me.sock = New DatagramSocket(7000)
        Catch e As SocketException
            System.out.println("Couldn't setup PLC Receiver socket")
        End Try

    End Sub

    Public Shared Function isFieldESTOPPED() As Boolean
        Return field_ESTOPPED
    End Function

    Public Shared Sub resetFieldESTOPPED()
        field_ESTOPPED = False
    End Sub

    <Override()> _
    Public Sub run()
        ' Sets up a byte array for the incoming packet
        Dim data() As Byte = New Byte((6) - 1) {}
        ' Sets up a Datagram Packet(aka UDP) to receive PLC data.
        Dim p As DatagramPacket = New DatagramPacket(data, data.length)

        While Not Me.sock.isClosed
            Try
                ' Waits until a packet is received before moving on...
                Me.sock.receive(p)
                ' Takes in the data from the packet and puts it into a string
                Me.dataStr = New String(data, "UTF-8")
            Catch e As IOException

            End Try

            Try
                ' Takes in the data from the packet and puts it into a string
                Me.dataStr = New String(data, "UTF-8")
                ' COULD THIS BE A PROBLEM?
                Msg.send(("Recieved PLC String: " + Me.dataStr))
                AD_Test_Panel.getInstance.updateAll_ES_Indic(False)
                If Me.dataStr.substring(0, 6).equals("111111") Then
                    AD_Test_Panel.getInstance.updateFieldES(True)
                    R1EStop.fillcolor = lime
                Else
                    Msg.send("Updating robot ESTOP")
                    ' If Red One requested an ESTOP then do it
                    If Me.dataStr.substring(0, 1).equals("1") Then
                        AD_Test_Panel.getInstance.updateES_Indic(RED, ONE, True)
                        R1EStop.fillcolor = red
                    End If

                    ' If Red Two requested an ESTOP then do it
                    If Me.dataStr.substring(1, 2).equals("1") Then
                        AD_Test_Panel.getInstance.updateES_Indic(RED, TWO, True)
                        R2EStop.fillcolor = red
                    End If

                    ' If Red Three requested an ESTOP then do it
                    If Me.dataStr.substring(2, 3).equals("1") Then
                        Msg.send("Updating R3 ESTOP")
                        AD_Test_Panel.getInstance.updateES_Indic(RED, THREE, True)
                        R3EStop.fillcolor = red
                    End If

                    ' If Blue One requested an ESTOP then do it
                    If Me.dataStr.substring(3, 4).equals("1") Then
                        AD_Test_Panel.getInstance.updateES_Indic(BLUE, ONE, True)
                        B1EStop.fillcolor = red
                    End If

                    ' If Blue Two requested an ESTOP then do it
                    If Me.dataStr.substring(4, 5).equals("1") Then
                        AD_Test_Panel.getInstance.updateES_Indic(BLUE, TWO, True)
                        B2EStop.fillcolor = red
                    End If

                    ' If Blue Three requested an ESTOP then do it
                    If Me.dataStr.substring(5, 6).equals("1") Then
                        AD_Test_Panel.getInstance.updateES_Indic(BLUE, THREE, True)
                        B3EStop.fillcolor = red
                    End If

                End If

                'add the indicators for year specfic stuff
                If Me.dataStr.substring(0, 6).equals("111111") Then
                    ' && GovernThread.getInstance().isMatchRunning()) {
                    System.out.println("Full Field ESTOP")
                    ' Stop the match
                    Main.layer.stopMatch()
                    ' ESTOP all of the Red robots
                    FieldAndRobots.getInstance.actOnRobot(RED, ONE, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                    FieldAndRobots.getInstance.actOnRobot(RED, TWO, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                    FieldAndRobots.getInstance.actOnRobot(RED, THREE, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                    ' ESTOP all of the Blue robots
                    FieldAndRobots.getInstance.actOnRobot(BLUE, ONE, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                    FieldAndRobots.getInstance.actOnRobot(BLUE, TWO, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                    FieldAndRobots.getInstance.actOnRobot(BLUE, THREE, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                    ' Yes, the field has been ESTOPPED
                    field_ESTOPPED = True
                Else
                    ' The entire field has not been ESTOPPED
                    System.out.println("***Individual Team ESTOP")
                    'if (GovernThread.getInstance().isMatchRunning()) {
                    'AD_Test_Panel.getInstance().updateAll_ES_Indic(false);
                    ' If Red One requested an ESTOP then do it
                    If Me.dataStr.substring(0, 1).equals("1") Then
                        FieldAndRobots.getInstance.actOnRobot(RED, ONE, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                    End If

                    ' If Red Two requested an ESTOP then do it
                    If Me.dataStr.substring(1, 2).equals("1") Then
                        FieldAndRobots.getInstance.actOnRobot(RED, TWO, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                    End If

                    ' If Red Three requested an ESTOP then do it
                    If Me.dataStr.substring(2, 3).equals("1") Then
                        FieldAndRobots.getInstance.actOnRobot(RED, THREE, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                    End If

                    ' If Blue One requested an ESTOP then do it
                    If Me.dataStr.substring(3, 4).equals("1") Then
                        FieldAndRobots.getInstance.actOnRobot(BLUE, ONE, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                    End If

                    ' If Blue Two requested an ESTOP then do it
                    If Me.dataStr.substring(4, 5).equals("1") Then
                        FieldAndRobots.getInstance.actOnRobot(BLUE, TWO, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                    End If

                    ' If Blue Three requested an ESTOP then do it
                    If Me.dataStr.substring(5, 6).equals("1") Then
                        FieldAndRobots.getInstance.actOnRobot(BLUE, THREE, FieldAndRobots.SpecialState.ESTOP_ROBOT)
                    End If

                    ' }
                End If

                'Scale and Switch plc stuff
                'If the plc get the game data is equal to LLL
                If Me.dataStr.substring(0).equals("LLL") Then
                    If Me.dataStr.substring(0).equals("SS1") Then
                        FieldAndRobots.getInstance.RedOwnership()
                    End If

                    If Me.dataStr.substring(1).equals("SS2") Then
                        FieldAndRobots.getInstance.BlueOwnership()
                    End If

                    If Me.dataStr.substring(2).equals("RSS1") Then
                        FieldAndRobots.getInstance.RedOwnership()
                    End If

                    If Me.dataStr.substring(3).equals("RSS2") Then
                        FieldAndRobots.getInstance.BlueOwnership()
                    End If

                    If Me.dataStr.substring(4).equals("BSS1") Then
                        FieldAndRobots.getInstance.RedOwnership()
                    End If

                    If Me.dataStr.substring(5).equals("BSS2") Then
                        FieldAndRobots.getInstance.BlueOwnership()
                    End If

                End If

                'if the game data is RRR
                If Me.dataStr.substring(0).equals("RRR") Then
                    If Me.dataStr.substring(0).equals("SS1") Then
                        FieldAndRobots.getInstance.BlueOwnership()
                    End If

                    If Me.dataStr.substring(1).equals("SS2") Then
                        FieldAndRobots.getInstance.RedOwnership()
                    End If

                    If Me.dataStr.substring(2).equals("RSS1") Then
                        FieldAndRobots.getInstance.BlueOwnership()
                    End If

                    If Me.dataStr.substring(3).equals("RSS2") Then
                        FieldAndRobots.getInstance.RedOwnership()
                    End If

                    If Me.dataStr.substring(4).equals("BSS1") Then
                        FieldAndRobots.getInstance.BlueOwnership()
                    End If

                    If Me.dataStr.substring(5).equals("BSS2") Then
                        FieldAndRobots.getInstance.RedOwnership()
                    End If

                End If

                'if the game data is LRL
                If gameData.equals("LRL") Then
                    If Me.dataStr.substring(0).equals("SS1") Then
                        FieldAndRobots.getInstance.RedOwnership()
                    End If

                    If Me.dataStr.substring(1).equals("SS2") Then
                        FieldAndRobots.getInstance.BlueOwnership()
                    End If

                    If Me.dataStr.substring(2).equals("RSS1") Then
                        FieldAndRobots.getInstance.BlueOwnership()
                    End If

                    If Me.dataStr.substring(3).equals("RSS2") Then
                        FieldAndRobots.getInstance.RedOwnership()
                    End If

                    If Me.dataStr.substring(4).equals("BSS1") Then
                        FieldAndRobots.getInstance.BlueOwnership()
                    End If

                    If Me.dataStr.substring(5).equals("BSS2") Then
                        FieldAndRobots.getInstance.RedOwnership()
                    End If

                End If

                If Me.dataStr.substring(0).equals("RLR") Then
                    If Me.dataStr.substring(0).equals("SS1") Then
                        FieldAndRobots.getInstance.BlueOwnership()
                    End If

                    If Me.dataStr.substring(1).equals("SS2") Then
                        FieldAndRobots.getInstance.RedOwnership()
                    End If

                    If Me.dataStr.substring(2).equals("RSS1") Then
                        FieldAndRobots.getInstance.RedOwnership()
                    End If

                    If Me.dataStr.substring(3).equals("RSS2") Then
                        FieldAndRobots.getInstance.BlueOwnership()
                    End If

                    If Me.dataStr.substring(4).equals("BSS1") Then
                        FieldAndRobots.getInstance.BlueOwnership()
                    End If

                    If Me.dataStr.substring(5).equals("BSS2") Then
                        FieldAndRobots.getInstance.RedOwnership()
                    End If

                End If

                'Power ups
                'If the Red Force becomes active
                If Me.dataStr.substring(0).equals("RF1") Then
                    FieldAndRobots.getInstance.redVaultForce(Scoring.CubeNumbers.Force_1)
                End If

                If Me.dataStr.substring(1).equals("RF2") Then
                    FieldAndRobots.getInstance.redVaultForce(Scoring.CubeNumbers.Force_2)
                End If

                If Me.dataStr.substring(2).equals("RF3") Then
                    FieldAndRobots.getInstance.redVaultForce(Scoring.CubeNumbers.Force_3)
                End If

                If Me.dataStr.substring(9).equals("RF") Then
                    FieldAndRobots.getInstance.redVaultForce(Scoring.CubeNumbers.Force_PLAYED)
                End If

                'For Red boost
                If Me.dataStr.substring(6).equals("RB1") Then
                    FieldAndRobots.getInstance.redVaultBoost(Scoring.CubeNumbers.Boost_1)
                End If

                If Me.dataStr.substring(7).equals("RB2") Then
                    FieldAndRobots.getInstance.redVaultBoost(Scoring.CubeNumbers.Boost_2)
                End If

                If Me.dataStr.substring(8).equals("RB3") Then
                    FieldAndRobots.getInstance.redVaultBoost(Scoring.CubeNumbers.Boost_3)
                End If

                If Me.dataStr.substring(10).equals("RB") Then
                    FieldAndRobots.getInstance.redVaultBoost(Scoring.CubeNumbers.Boost_PLAYED)
                End If

                'Red Levitiate
                If Me.dataStr.substring(3).equals("RLEV1") Then
                    FieldAndRobots.getInstance.redVaultLev(Scoring.CubeNumbers.Levitate_1)
                End If

                If Me.dataStr.substring(4).equals("RLEV2") Then
                    FieldAndRobots.getInstance.redVaultLev(Scoring.CubeNumbers.Levitate_2)
                End If

                If Me.dataStr.substring(5).equals("RLEV3") Then
                    FieldAndRobots.getInstance.redVaultLev(Scoring.CubeNumbers.Levitate_3)
                End If

                If Me.dataStr.substring(11).equals("RLEV") Then
                    FieldAndRobots.getInstance.redVaultLev(Scoring.CubeNumbers.Lev_PLAYED)
                End If

                'Fouls coming from the PLC/CMORE Ref Pads
                'Blue Fouls
                If Me.dataStr.substring(1).equals("B_F") Then
                    FieldAndRobots.getInstance.blueFoul(Scoring.Fouls.Blue_Foul)
                End If

                'Red Foul
                If Me.dataStr.substring(2).equals("R_F") Then
                    FieldAndRobots.getInstance.redFoul(Scoring.Fouls.Red_Foul)
                End If

                'Blue Tech Foul
                If Me.dataStr.substring(3).equals("B_Tech") Then
                    FieldAndRobots.getInstance.blueTech(Scoring.Fouls.Blue_Tech)
                End If

                'Red Tech Foul
                If Me.dataStr.substring(4).equals("R_Tech") Then
                    FieldAndRobots.getInstance.redTech(Scoring.Fouls.Red_Tech)
                End If

                'Blue Force
                If Me.dataStr.substring(0).equals("BF1") Then
                    FieldAndRobots.getInstance.blueVaultForce(Scoring.CubeNumbers.Force_1)
                End If

                If Me.dataStr.substring(1).equals("BF2") Then
                    FieldAndRobots.getInstance.blueVaultForce(Scoring.CubeNumbers.Force_2)
                End If

                If Me.dataStr.substring(2).equals("BF3") Then
                    FieldAndRobots.getInstance.blueVaultForce(Scoring.CubeNumbers.Force_3)
                End If

                If Me.dataStr.substring(3).equals("BF") Then
                    FieldAndRobots.getInstance.blueVaultForce(Scoring.CubeNumbers.Force_PLAYED)
                End If

                'Blue Boost
                If Me.dataStr.substring(4).equals("BB1") Then
                    FieldAndRobots.getInstance.blueVaultBoost(Scoring.CubeNumbers.Boost_1)
                End If

                If Me.dataStr.substring(5).equals("BB2") Then
                    FieldAndRobots.getInstance.blueVaultBoost(Scoring.CubeNumbers.Boost_2)
                End If

                If Me.dataStr.substring(6).equals("BB3") Then
                    FieldAndRobots.getInstance.blueVaultBoost(Scoring.CubeNumbers.Boost_3)
                End If

                If Me.dataStr.substring(7).equals("BB") Then
                    FieldAndRobots.getInstance.blueVaultBoost(Scoring.CubeNumbers.Boost_PLAYED)
                End If

                'Blue Lev
                If Me.dataStr.substring(8).equals("BLEV1") Then
                    FieldAndRobots.getInstance.blueVaultLev(Scoring.CubeNumbers.Levitate_1)
                End If

                If Me.dataStr.substring(9).equals("BLEV2") Then
                    FieldAndRobots.getInstance.blueVaultLev(Scoring.CubeNumbers.Levitate_2)
                End If

                If Me.dataStr.substring(10).equals("BLEV3") Then
                    FieldAndRobots.getInstance.blueVaultLev(Scoring.CubeNumbers.Levitate_3)
                End If

                If Me.dataStr.substring(11).equals("BLEV") Then
                    FieldAndRobots.getInstance.blueVaultLev(Scoring.CubeNumbers.Lev_PLAYED)
                End If

                If PLC_Receiver.isBitSet(data(2), 0) Then
                    Main.getESTOP_Panel.setBlueIOStatus(Color.GREEN)
                Else
                    Main.getESTOP_Panel.setBlueIOStatus(Color.RED)
                End If

                If PLC_Receiver.isBitSet(data(2), 1) Then
                    Main.getESTOP_Panel.setRedIOStatus(Color.GREEN)
                Else
                    Main.getESTOP_Panel.setRedIOStatus(Color.RED)
                End If

            Catch e As UnsupportedEncodingException

            End Try

            ' Reset packet length
            p.setLength(data.length)

        End While

        Msg.send("***THE PLC RECEIVER SOCKET HAS BEEN CLOSED***NO MORE PLC RECEIVER***")
    End Sub

    Public Sub shutdownSocket()
        If (Not (Me.sock) Is Nothing) Then
            Me.sock.close()
        End If

    End Sub

    Public Shared Function isBitSet(ByVal data As Byte, ByVal bitPos As Integer) As Boolean
        Dim bitPosition As Integer = (bitPos Mod 8)
        ' Position of this bit in a byte
        Return ((data _
                    + (bitPosition And 1)) _
                    = 1)
    End Function
End Class