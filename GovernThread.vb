Imports Microsoft.VisualBasic


Imports Game.RandomString
Imports UI.New_UI
Imports UI.UI_Layer
Imports java.awt.Color
Imports java.io.IOException
Imports java.util.ArrayList
Imports java.util.List
Imports java.util.Random
Imports java.util.logging.Level
Imports java.util.logging.Logger
Imports javax.sound.sampled.AudioInputStream
Imports javax.sound.sampled.AudioSystem
Imports javax.sound.sampled.Clip
Imports javax.sound.sampled.LineUnavailableException
Imports javax.sound.sampled.UnsupportedAudioFileException
Public Class GovernThread
    Inherits Thread

    '<editor-fold defaultstate="collapsed" desc="Variables">
    Private Shared random As Random = New Random

    Private Shared _instance As GovernThread

    Private field As FieldAndRobots

    Private gameUi As New_UI

    Public Shared NO_MATCH_UNDERWAY_MODE As Integer = 0

    Public Shared WARMUP_MODE As Integer = 1

    Public Shared AUTO_MODE As Integer = 2

    '1
    Public Shared TELE_MODE As Integer = 3

    '2
    Private matchMode As Integer = NO_MATCH_UNDERWAY_MODE

    'How long the warmup period lests in milliseconds
    Private WarmUpTimeMillis As Double = (2 * 1000)

    Private autoTimeMillis As Double = (10 * 1000)

    Private teleTimeMillis As Double = (140 * 1000)

    Private currMatchTimeMillis As Integer = 0

    Private pseudoTimeMillis As Integer = 0

    Private PLC_timeSeconds As Integer = (CType(Me.autoTimeMillis, Integer) / 1000)

    Private Shared MATCH_UNDERWAY_AUTONOMOUS As Color = Color.BLUE

    Private Shared MATCH_UNDERWAY_TELEOP As Color = Color.GREEN

    Private Shared MATCH_UNDERWAY_ENDGAME As Color = Color.YELLOW

    Private Shared MATCH_ENDED As Color = Color.RED

    Private Shared WARM_UP As Color = Color.MAGENTA

    Private newMatch As Boolean = True

    Private matchRunning As Boolean = False

    Private kill As Boolean = False

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Creation And Instances">    
    Private Sub New(ByVal gameUi As New_UI, ByVal field As FieldAndRobots)
        MyBase.New()
        System.out.println("GovernThread Constructor")
        Me.gameUi = Me.gameUi
        Me.field = Me.field
    End Sub

    Public Shared Function getNewInstance(ByVal gameUi As New_UI, ByVal field As FieldAndRobots) As GovernThread
        If (Not (_instance) Is Nothing) Then
            _instance.kill = True
            System.out.println(("Asked for a new instance of GT, had one already, " + "killing the existing instance first..."))

            While _instance.isAlive
                Try
                    Thread.sleep(700)
                Catch ex As InterruptedException
                    Logger.getLogger(GovernThread.class.getName).log(Level.SEVERE, Nothing, ex)
                End Try


            End While

            System.out.println("...existing instance has died, creating new.")
        End If

        _instance = New GovernThread(Me.gameUi, Me.field)
        Return _instance
    End Function

    Public Shared Function getInstance() As GovernThread
        If (_instance Is Nothing) Then
            System.out.println(("Asked for GovernThread instance before " + "it was properly created; returning null!!"))
        End If

        Return _instance
    End Function

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Thread Start and Run Code">
    <Override()> _
    Public Sub start()
        If (Me.gameUi Is Nothing) Then
            System.out.println("Invalid GovernThread - No OFMS_UI!!")
        ElseIf (Me.field Is Nothing) Then
            System.out.println("Invalid GovernThread - No FieldAndRobots!!")
        ElseIf Me.newMatch Then
            MyBase.start()
        Else
            System.out.println("************ERROR - THIS IS NOT A NEW MATCH**********")
        End If

        Me.matchRunning = True
    End Sub

    <Override()> _
    Public Sub run()
        'Warmup period
        Me.newMatch = False
        Me.setModeAndStateForAllRobots(AUTO_MODE, False)
        System.out.println("Warmup Start")
        Me.matchMode = WARMUP_MODE
        Me.playSound("MATCH_WARMUP.wav")
        'Play WarmUp sound
        UI_Layer.getInstance.changeProBarColor(WARM_UP)

        While Not Me.kill
            Dim newMatchTimeMillis As Integer = Me.pseudoTimeMillis
            If Not Me.isWarmUp Then
                newMatchTimeMillis = (newMatchTimeMillis - Me.getWarmUpTimeMillis)
            End If

            Me.currMatchTimeMillis = (CType(Me.getModeTimeMillis, Integer) - newMatchTimeMillis)
            Me.PLC_timeSeconds = (Me.currMatchTimeMillis / 1000)
            If (Me.pseudoTimeMillis <= Me.getTotalTimeMillis) Then
                UI_Layer.getInstance.updateProBar((CType(Me.pseudoTimeMillis, Double) / Me.getTotalTimeMillis))
                UI_Layer.getInstance.setMatchTime(Me.fixTime(((Me.currMatchTimeMillis / 1000) _
                                    + "")))
            Else
                Me.stopMatch()
            End If


        End While

        Me.newMatch = False
        Me.setModeAndStateForAllRobots(AUTO_MODE, True)
        System.out.println("Autonomous Start")
        Me.matchMode = AUTO_MODE
        Me.playSound("CHARGE.wav")
        ' Play charge
        UI_Layer.getInstance.changeProBarColor(MATCH_UNDERWAY_AUTONOMOUS)

        While Not Me.kill
            Dim newMatchTimeMillis As Integer = Me.pseudoTimeMillis
            If Not Me.isAutonomous Then
                newMatchTimeMillis = (newMatchTimeMillis - Me.getAutoTimeMillis)
            End If

            Me.currMatchTimeMillis = (CType(Me.getModeTimeMillis, Integer) - newMatchTimeMillis)
            Me.PLC_timeSeconds = (Me.currMatchTimeMillis / 1000)
            If (Me.pseudoTimeMillis <= Me.getTotalTimeMillis) Then
                UI_Layer.getInstance.updateProBar((CType(Me.pseudoTimeMillis, Double) / Me.getTotalTimeMillis))
                UI_Layer.getInstance.setMatchTime(Me.fixTime(((Me.currMatchTimeMillis / 1000) _
                                    + "")))
            Else
                Me.stopMatch()
            End If

            If (Me.pseudoTimeMillis < Me.autoTimeMillis) Then

            ElseIf (Me.pseudoTimeMillis = Me.autoTimeMillis) Then
                System.out.println("Autonomous End")
                Me.setModeAndStateForAllRobots(TELE_MODE, False)
                Me.matchMode = NO_MATCH_UNDERWAY_MODE
                System.out.println("Teleop Start")
                Me.setModeAndStateForAllRobots(TELE_MODE, True)
                Me.matchMode = TELE_MODE
                Me.playSound("3BELLS.wav")
                ' Play 3 bells
                UI_Layer.getInstance.changeProBarColor(MATCH_UNDERWAY_TELEOP)
            ElseIf (Me.pseudoTimeMillis _
                        < (Me.autoTimeMillis _
                        + (Me.teleTimeMillis * (3 / 4)))) Then
                ' Find the non - end game time of the match
            ElseIf (Me.pseudoTimeMillis _
                        = (Me.autoTimeMillis _
                        + (Me.teleTimeMillis * (3 / 4)))) Then
                Me.playSound("ENDGAME.wav")
                ' Play Endgame
                UI_Layer.getInstance.changeProBarColor(MATCH_UNDERWAY_ENDGAME)
            ElseIf (Me.pseudoTimeMillis < Me.getTotalTimeMillis) Then
                ' Find the endgame time of the match
            ElseIf (Me.pseudoTimeMillis = Me.getTotalTimeMillis) Then
                System.out.println("Teleop End")
                Me.setModeAndStateForAllRobots(TELE_MODE, False)
                Me.matchMode = NO_MATCH_UNDERWAY_MODE
                Me.playSound("ENDMATCH.wav")
                ' Play end sound
                UI_Layer.getInstance.changeProBarColor(MATCH_ENDED)
                UI_Layer.getInstance.disableStopButton()
            Else

            End If

            '******************************************************************
            Try
                Me.pseudoTimeMillis = (Me.pseudoTimeMillis + 100)
                Me.sleep(100)
            Catch ex As InterruptedException
                Logger.getLogger(GovernThread.class.getName).log(Level.SEVERE, Nothing, ex)
            End Try


        End While

    End Sub

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Robot Control">
    Public Sub emergencyStopMatch()
        System.out.println("Match Emergency Stopped!!!")
        Me.stopMatch()
        Me.playSound("FOGHORN.wav")
    End Sub

    Public Sub stopMatch()
        System.out.println("Match Ended")
        UI_Layer.getInstance.setResetButtonEnabled(True)
        Me.disableAllBots()
        Me.interrupt()
        Me.kill = True
        Me.matchRunning = False
    End Sub

    Public Sub disableAllBots()
        Me.setModeAndStateForAllRobots(TELE_MODE, False)
    End Sub

    Public Sub setModeAndStateForAllRobots(ByVal mode As Integer, ByVal enabled As Boolean)
        If (Not (Me.field) Is Nothing) Then
            Me.field.setAllRobotStates(mode, enabled)
        End If

    End Sub

    Public Sub setAllRobotsToBypassed(ByVal bypassState As Boolean)
        If (Not (Me.field) Is Nothing) Then
            Me.field.setBypassForAllRobots(bypassState)
        End If

    End Sub

    Public Sub resetAllRobots()
        If (Not (Me.field) Is Nothing) Then
            Me.field.resetAllRobots()
        End If

    End Sub

    Private Shared Sub getRandomItem(ByVal gameData As List(Of String))
        'Size of the list is 5
        Dim index As Integer = random.nextInt(gameData.size)
        System.out.println(("" + gameData.get(index)))
    End Sub

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Match Getters">
    Public Function getMatchState() As String
        If (Me.matchMode = NO_MATCH_UNDERWAY_MODE) Then
            Return "Disabled"
        ElseIf (Me.matchMode = WARMUP_MODE) Then
            Return "WarmUp"
        ElseIf (Me.matchMode = AUTO_MODE) Then
            Return "Autonomous"
        ElseIf (Me.matchMode = TELE_MODE) Then
            Return "Teleop"
        Else
            Return "Unknown State"
        End If

    End Function

    Public Function isAutonomous() As Boolean
        Return (Me.matchMode = AUTO_MODE)
    End Function

    ' returns true if the match is in WarmUp mode and determines if the match is in warmup
    Public Function isWarmUp() As Boolean
        Return (Me.matchMode = WARMUP_MODE)
    End Function

    Public Function isMatchRunning() As Boolean
        Return Me.matchRunning
    End Function

    Public Function isNewMatch() As Boolean
        Return Me.newMatch
    End Function

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Timing">
    Public Sub setWarmUpTime(ByVal newWarmUpTime As Integer)
        Me.WarmUpTimeMillis = (newWarmUpTime * 1000)
    End Sub

    Public Sub setAutoTime(ByVal newAutoTime As Integer)
        Me.autoTimeMillis = (newAutoTime * 1000)
    End Sub

    Public Sub setTeleTime(ByVal newTeleTime As Integer)
        Me.teleTimeMillis = (newTeleTime * 1000)
    End Sub

    Private Function getTotalTimeMillis() As Integer
        Return CType((Me.WarmUpTimeMillis _
                    + (Me.teleTimeMillis + Me.autoTimeMillis)), Integer)
    End Function

    Private Function getModeTimeMillis() As Integer
        If (Me.matchMode = WARMUP_MODE) Then
            Return CType(Me.WarmUpTimeMillis, Integer)
        End If

        If (Me.matchMode = AUTO_MODE) Then
            Return CType(Me.autoTimeMillis, Integer)
        ElseIf (Me.matchMode = TELE_MODE) Then
            Return CType(Me.teleTimeMillis, Integer)
        Else
            Return Me.getTotalTimeMillis
        End If

    End Function

    Private Function getAutoTimeMillis() As Double
        Return Me.autoTimeMillis
    End Function

    Private Function getWarmUpTimeMillis() As Double
        Return Me.WarmUpTimeMillis
    End Function

    Public Function get_PLC_Time() As String
        Return Me.fixTime(("" + Me.PLC_timeSeconds))
    End Function

    Private Function fixTime(ByVal time As String) As String
        If (time.length < 3) Then
            Return Me.fixTime(("0" + time))
        Else
            Return time
        End If

    End Function

    '</editor-fold>
    Public Sub playSound(ByVal fileName As String)
        Try
            Dim clip As Clip = AudioSystem.getClip
            Dim ais As AudioInputStream
            ais = AudioSystem.getAudioInputStream(GovernThread.class.getResource(("/OFMS/Sounds/" + fileName)))
            clip.open(ais)
            clip.start()
        Catch  As LineUnavailableException
        End Try

        (UnsupportedAudioFileException Or IOException)
        e()
        System.err.println(("My_Sound_Error: " + e.getMessage))
    End Sub
End Class