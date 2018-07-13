Imports Microsoft.VisualBasic
Imports O_FMS_V0.FieldAndRobots
Imports O_FMS_V0.GovernThread
Imports O_FMS_V0.Main
Imports O_FMS_V0.PLC_Receiver
Imports O_FMS_V0.PLC_Sender

Public Class UI_Layer

    '<editor-fold defaultstate="collapsed" desc="Variables">
    '<editor-fold defaultstate="collapsed" desc="Readiness Indicators">
    Private Shared fullFieldReady 'As TextField

    Private Shared blueSideReady As Label

    Private Shared redSideReady As Label

    Private Shared prevBlueReady As Boolean = False

    Private Shared prevRedReady As Boolean = False

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Time Related Elements">
    Private Shared matchProgressBar 'As JProgressBar

    Private Shared runningMatchTime 'As JTextField

    Private Shared autonomousTime 'As JTextField

    Private Shared teleoperatedTime 'As JTextField

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="UI Control Buttons">
    Private Shared switcherButton 'As JButton

    Private Shared beginMatchButton 'As JButton

    Private Shared stopMatchButton 'As JButton

    Private Shared resetButton 'As JButton

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Team Realted Elements">
    '<editor-fold defaultstate="collapsed" desc="Team Bypass Boxes">
    Private Shared blueTeamBypass1 'As JCheckBox

    Private Shared blueTeamBypass2 'As JCheckBox

    Private Shared blueTeamBypass3 'As JCheckBox

    Private Shared redTeamBypass1 'As JCheckBox

    Private Shared redTeamBypass2 'As JCheckBox

    Private Shared redTeamBypass3 'As JCheckBox

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Team Number Fields">
    Private Shared blueTeamNumber1 'As JTextField

    Private Shared blueTeamNumber2 'As JTextField

    Private Shared blueTeamNumber3 'As JTextField

    Private Shared redTeamNumber1 'As JTextField

    Private Shared redTeamNumber2 'As JTextField

    Private Shared redTeamNumber3 'As JTextField

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Team Voltage Fields"> 
    Private Shared voltageBlueTeam1 'As JTextField

    Private Shared voltageBlueTeam2 'As JTextField

    Private Shared voltageBlueTeam3 'As JTextField

    Private Shared voltageRedTeam1 'As JTextField

    Private Shared voltageRedTeam2 'As JTextField

    Private Shared voltageRedTeam3 'As JTextField

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Team Robot Comm Status"> 
    Private Shared robotComStatusBlueTeam1 As Label

    Private Shared robotComStatusBlueTeam2 As Label

    Private Shared robotComStatusBlueTeam3 As Label

    Private Shared robotComStatusRedTeam1 As Label

    Private Shared robotComStatusRedTeam2 As Label

    Private Shared robotComStatusRedTeam3 As Label

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Team Driver Station Comm Status">
    Private Shared dsComStatusBlueTeam1 As Label

    Private Shared dsComStatusBlueTeam2 As Label

    Private Shared dsComStatusBlueTeam3 As Label

    Private Shared dsComStatusRedTeam1 As Label

    Private Shared dsComStatusRedTeam2 As Label

    Private Shared dsComStatusRedTeam3 As Label

    '</editor-fold>
    '</editor-fold>
    ' <editor-fold defaultstate="collapsed" desc="Colors">
    Private Shared READY As Color = Color.Lime

    Private Shared NOT_READY As Color = Color.Red


    Private Shared BYPASSED As Color = Color.Yellow

    Private Shared ESTOPPED As Color = Color.Magenta

    Private Shared EDITING As Color = Color.Orange

    '</editor-fold>
    Private Shared _instance As UI_Layer

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Constructor and getInstance">
    Private Sub New()
        MyBase.New()
        Console.Out.Write("UI_Layer Const")
        UI_Layer.renewGameThread("10", "140")
    End Sub

    Public Shared Function getInstance() As UI_Layer
        If (_instance Is Nothing) Then
            _instance = New UI_Layer
        End If

        Return _instance
    End Function

    '</editor-fold>
    ' <editor-fold defaultstate="collapsed" desc="Setup UI">
    Public Sub setSwitchViewButton(ByVal switcher As JButton)
        If (Not (switcherButton) Is Nothing) Then
            Dim listeners() As TraceListener = switcherButton.getActionListeners
            For Each lis As TraceListener In listeners
                switcherButton.removeActionListener(lis)
            Next
        End If

        switcherButton = Nothing
        switcherButton = switcher
        Dim listen As TraceListener = New ActionListener
        switcherButton.addActionListener(listen)
    End Sub

    Public Sub setProgressBar(ByVal bar As ProgressBar)
        matchProgressBar = bar
    End Sub

    Public Sub setFullFieldReady(ByVal fieldReady As TextField)
        fullFieldReady = fieldReady
    End Sub

    Public Sub setSideIndicators(ByVal redIndicator As Label, ByVal blueIndicator As Label)
        redSideReady = redIndicator
        blueSideReady = blueIndicator
    End Sub

    Public Sub setStopButton(ByVal stop As JButton)
        If (Not (stopMatchButton) Is Nothing) Then
            Dim listeners() As TraceListener = stopMatchButton.getActionListeners
            For Each lis As TraceListener In listeners
                stopMatchButton.removeActionListener(lis)
            Next
        End If

        stopMatchButton = stop
        stopMatchButton.addActionListener(New ActionListener)
    End Sub

    Public Sub disableStopButton()
        stopMatchButton.setEnabled(False)
    End Sub

    Public Sub stopMatch()
        Dim game As GovernThread = GovernThread.getInstance
        If (Not (game) Is Nothing) Then
            game.emergencyStopMatch()
        End If

        beginMatchButton.setEnabled(False)
        resetButton.setEnabled(True)
        switcherButton.setEnabled(True)
        stopMatchButton.setEnabled(False)
    End Sub

    Public Sub setResetButton(ByVal reset As JButton)
        If (Not (resetButton) Is Nothing) Then
            Dim listeners() As ActionListener = resetButton.getActionListeners
            For Each lis As ActionListener In listeners
                resetButton.removeActionListener(lis)
            Next
        End If

        resetButton = reset
        resetButton.addActionListener(New ActionListener)
    End Sub

    Public Sub resetCommand()
        beginMatchButton.setEnabled(False)
        switcherButton.setEnabled(True)
        stopMatchButton.setEnabled(False)
        autonomousTime.setEditable(True)
        teleoperatedTime.setEditable(True)
        Me.resetProBar()
        UI_Layer.renewGameThread(autonomousTime.getText, teleoperatedTime.getText)
        Me.SetAllBypassBoxesEnabled(True)
        Me.SetAllBypassBoxesSelected(False)
        'dsComStatusBlueTeam1.setBackground(NOT_READY)
        'dsComStatusBlueTeam2.setBackground(NOT_READY)
        'dsComStatusBlueTeam3.setBackground(NOT_READY)
        'dsComStatusRedTeam1.setBackground(NOT_READY)
        'dsComStatusRedTeam2.setBackground(NOT_READY)
        'dsComStatusRedTeam3.setBackground(NOT_READY)
        'robotComStatusBlueTeam1.setBackground(NOT_READY)
        'robotComStatusBlueTeam2.setBackground(NOT_READY)
        'robotComStatusBlueTeam3.setBackground(NOT_READY)
        'robotComStatusRedTeam1.setBackground(NOT_READY)
        'robotComStatusRedTeam2.setBackground(NOT_READY)
        'robotComStatusRedTeam3.setBackground(NOT_READY)
        runningMatchTime.setText(UI_Layer.fixAutoTime(autonomousTime.getText))
        PLC_Receiver.resetFieldESTOPPED()
        PLC_Sender.getInstance.updatePLC_Lights(True)
        Me.SetAllTeamFieldsEditable(True)
        If Not Main.isSimpleMode Then
            PLC_Sender.getInstance.updatePLC_Time(True)
        End If

        Console.Out.Write("Resetting Fields")
    End Sub

    Public Shared Function fixAutoTime(ByVal time As String) As String
        If (time.length < 3) Then
            Return UI_Layer.fixAutoTime("0".concat(time))
        End If

        Return time
    End Function

    Public Shared Sub renewGameThread(ByVal autoTime As String, ByVal teleTime As String)
        Dim game As GovernThread = GovernThread.getInstance
        If (Not (game) Is Nothing) Then
            game.stopMatch()
        End If

        game = GovernThread.getNewInstance(Main.newUI, FieldAndRobots.getInstance)
        game.setAutoTime(Integer.Parse(autoTime))
        game.setTeleTime(Integer.Parse(teleTime))
        game.setAllRobotsToBypassed(False)
        game.resetAllRobots()
    End Sub

    Public Sub setMatchButton(ByVal matchButton As JButton)
        If (Not (beginMatchButton) Is Nothing) Then
            Dim listeners() As TraceListener = beginMatchButton.getActionListeners
            For Each lis As TraceListener In listeners
                beginMatchButton.removeActionListener(lis)
            Next
        End If

        beginMatchButton = matchButton
        beginMatchButton.addActionListener(New java.awt.event.ActionListener)
    End Sub

    Public Sub setMatchTimeField(ByVal time As JTextField)
        runningMatchTime = time
    End Sub

    Public Sub setTimeSetters(ByVal auton As JTextField, ByVal tele As JTextField)
        autonomousTime = auton
        autonomousTime.addActionListener(New ActionListener)
        autonomousTime.addFocusListener(New java.awt.event.FocusAdapter)
        teleoperatedTime = tele
        teleoperatedTime.addActionListener(New ActionListener)
        teleoperatedTime.addFocusListener(New java.awt.event.FocusAdapter)
    End Sub

    '</editor-fold>
    ' <editor-fold defaultstate="collapsed" desc="Team Setup">
    ' <editor-fold defaultstate="collapsed" desc="Setup Blue Indicators">
    Public Sub setBlue1(ByVal num As JTextField, ByVal bypass As CheckBox, ByVal voltage As JTextField, ByVal robCom As Label, ByVal dsCom As Label)
        blueTeamNumber1 = num
        blueTeamNumber1.addActionListener(New java.awt.event.ActionListener)
        blueTeamNumber1.addFocusListener(New java.awt.event.FocusAdapter)
        blueTeamNumber1.addFocusListener(New java.awt.event.FocusAdapter)
        blueTeamBypass1 = bypass
        blueTeamBypass1.addActionListener(New java.awt.event.ActionListener)
        '
        voltageBlueTeam1 = voltage
        ' Initializing is good enough
        robotComStatusBlueTeam1 = robCom
        ' Initializing is good enough
        dsComStatusBlueTeam1 = dsCom
        ' Initializing is good enough
    End Sub

    Public Sub setBlue2(ByVal num As JTextField, ByVal bypass As CheckBox, ByVal voltage As JTextField, ByVal robCom As Label, ByVal dsCom As Label)
        blueTeamNumber2 = num
        blueTeamNumber2.addActionListener(New java.awt.event.ActionListener)
        blueTeamNumber2.addFocusListener(New java.awt.event.FocusAdapter)
        blueTeamNumber2.addFocusListener(New java.awt.event.FocusAdapter)
        blueTeamBypass2 = bypass
        blueTeamBypass2.addActionListener(New java.awt.event.ActionListener)
        '
        voltageBlueTeam2 = voltage
        ' Initializing is good enough
        robotComStatusBlueTeam2 = robCom
        ' Initializing is good enough
        dsComStatusBlueTeam2 = dsCom
        ' Initializing is good enough
    End Sub

    Public Sub setBlue3(ByVal num As JTextField, ByVal bypass As CheckBox, ByVal voltage As JTextField, ByVal robCom As Label, ByVal dsCom As Label)
        blueTeamNumber3 = num
        blueTeamNumber3.addActionListener(New java.awt.event.ActionListener)
        blueTeamNumber3.addFocusListener(New java.awt.event.FocusAdapter)
        blueTeamNumber3.addFocusListener(New java.awt.event.FocusAdapter)
        blueTeamBypass3 = bypass
        blueTeamBypass3.addActionListener(New java.awt.event.ActionListener)
        '
        voltageBlueTeam3 = voltage
        ' Initializing is good enough
        robotComStatusBlueTeam3 = robCom
        ' Initializing is good enough
        dsComStatusBlueTeam3 = dsCom
        ' Initializing is good enough
    End Sub

    '</editor-fold>
    ' <editor-fold defaultstate="collapsed" desc="Setup Red Indicators">
    Public Sub setRed1(ByVal num As JTextField, ByVal bypass As CheckBox, ByVal voltage As JTextField, ByVal robCom As Label, ByVal dsCom As Label)
        redTeamNumber1 = num
        redTeamNumber1.addActionListener(New java.awt.event.ActionListener)
        redTeamNumber1.addFocusListener(New java.awt.event.FocusAdapter)
        redTeamNumber1.addFocusListener(New java.awt.event.FocusAdapter)
        redTeamBypass1 = bypass
        redTeamBypass1.addActionListener(New java.awt.event.ActionListener)
        '
        voltageRedTeam1 = voltage
        ' Initializing is good enough
        robotComStatusRedTeam1 = robCom
        ' Initializing is good enough
        dsComStatusRedTeam1 = dsCom
        ' Initializing is good enough
    End Sub

    Public Sub setRed2(ByVal num As JTextField, ByVal bypass As CheckBox, ByVal voltage As JTextField, ByVal robCom As Label, ByVal dsCom As Label)
        redTeamNumber2 = num
        redTeamNumber2.addActionListener(New java.awt.event.ActionListener)
        redTeamNumber2.addFocusListener(New java.awt.event.FocusAdapter)
        redTeamNumber2.addFocusListener(New java.awt.event.FocusAdapter)
        redTeamBypass2 = bypass
        redTeamBypass2.addActionListener(New java.awt.event.ActionListener)
        '
        voltageRedTeam2 = voltage
        ' Initializing is good enough
        robotComStatusRedTeam2 = robCom
        ' Initializing is good enough
        dsComStatusRedTeam2 = dsCom
        ' Initializing is good enough
    End Sub

    Public Sub setRed3(ByVal num As JTextField, ByVal bypass As JCheckBox, ByVal voltage As JTextField, ByVal robCom As Label, ByVal dsCom As Label)
        redTeamNumber3 = num
        redTeamNumber3.addActionListener(New java.awt.event.ActionListener)
        redTeamNumber3.addFocusListener(New java.awt.event.FocusAdapter)
        redTeamNumber3.addFocusListener(New java.awt.event.FocusAdapter)
        redTeamBypass3 = bypass
        redTeamBypass3.addActionListener(New java.awt.event.ActionListener)
        '
        voltageRedTeam3 = voltage
        ' Initializing is good enough
        robotComStatusRedTeam3 = robCom
        ' Initializing is good enough
        dsComStatusRedTeam3 = dsCom
        ' Initializing is good enough
    End Sub

    '</editor-fold>
    ' <editor-fold defaultstate="collapsed" desc="Set Team Info">
    Private Sub setTeamInfo_Red1()
        redTeamNumber1.setText(Me.fixNumTeam(redTeamNumber1.getText, "Red 1"))
        redTeamNumber1.setBackground(Color.WHITE)
        FieldAndRobots.getInstance.setTeamNumber(FieldAndRobots.RED, FieldAndRobots.ONE, Integer.Parse(redTeamNumber1.getText))
        FieldAndRobots.getInstance.actOnRobot(FieldAndRobots.RED, FieldAndRobots.ONE, FieldAndRobots.SpecialState.ZERO_BATTERY)
        If Not Main.isSimpleMode Then
            PLC_Sender.getInstance.updatePLC_TeamNum(True)
        End If

    End Sub

    Private Sub setTeamInfo_Red2()
        redTeamNumber2.setText(Me.fixNumTeam(redTeamNumber2.getText, "Red 2"))
        redTeamNumber2.setBackground(Color.WHITE)
        FieldAndRobots.getInstance.setTeamNumber(FieldAndRobots.RED, FieldAndRobots.TWO, Integer.Parse(redTeamNumber2.getText))
        FieldAndRobots.getInstance.actOnRobot(FieldAndRobots.RED, FieldAndRobots.TWO, FieldAndRobots.SpecialState.ZERO_BATTERY)
        If Not Main.isSimpleMode Then
            PLC_Sender.getInstance.updatePLC_TeamNum(True)
        End If

    End Sub

    Private Sub setTeamInfo_Red3()
        redTeamNumber3.setText(Me.fixNumTeam(redTeamNumber3.getText, "Red 3"))
        redTeamNumber3.setBackground(Color.WHITE)
        FieldAndRobots.getInstance.setTeamNumber(FieldAndRobots.RED, FieldAndRobots.THREE, Integer.Parse(redTeamNumber3.getText))
        FieldAndRobots.getInstance.actOnRobot(FieldAndRobots.RED, FieldAndRobots.THREE, FieldAndRobots.SpecialState.ZERO_BATTERY)
        If Not Main.isSimpleMode Then
            PLC_Sender.getInstance.updatePLC_TeamNum(True)
        End If

    End Sub

    Private Sub setTeamInfo_Blue1()
        blueTeamNumber1.setText(Me.fixNumTeam(blueTeamNumber1.getText, "Blue 1"))
        blueTeamNumber1.setBackground(Color.WHITE)
        FieldAndRobots.getInstance.setTeamNumber(FieldAndRobots.BLUE, FieldAndRobots.ONE, Integer.Parse(blueTeamNumber1.getText))
        FieldAndRobots.getInstance.actOnRobot(FieldAndRobots.BLUE, FieldAndRobots.ONE, FieldAndRobots.SpecialState.ZERO_BATTERY)
        If Not Main.isSimpleMode Then
            PLC_Sender.getInstance.updatePLC_TeamNum(True)
        End If

    End Sub

    Private Sub setTeamInfo_Blue2()
        blueTeamNumber2.setText(Me.fixNumTeam(blueTeamNumber2.getText, "Blue 2"))
        blueTeamNumber2.setBackground(Color.WHITE)
        FieldAndRobots.getInstance.setTeamNumber(FieldAndRobots.BLUE, FieldAndRobots.TWO, Integer.Parse(blueTeamNumber2.getText))
        FieldAndRobots.getInstance.actOnRobot(FieldAndRobots.BLUE, FieldAndRobots.TWO, FieldAndRobots.SpecialState.ZERO_BATTERY)
        If Not Main.isSimpleMode Then
            PLC_Sender.getInstance.updatePLC_TeamNum(True)
        End If

    End Sub

    Private Sub setTeamInfo_Blue3()
        blueTeamNumber3.setText(Me.fixNumTeam(blueTeamNumber3.getText, "Blue 3"))
        blueTeamNumber3.setBackground(Color.WHITE)
        FieldAndRobots.getInstance.setTeamNumber(FieldAndRobots.BLUE, FieldAndRobots.THREE, Integer.Parse(blueTeamNumber3.getText))
        FieldAndRobots.getInstance.actOnRobot(FieldAndRobots.BLUE, FieldAndRobots.THREE, FieldAndRobots.SpecialState.ZERO_BATTERY)
        If Not Main.isSimpleMode Then
            PLC_Sender.getInstance.updatePLC_TeamNum(True)
        End If

    End Sub

    Public Function fixNumTeam(ByVal input As String, ByVal team As String) As String
        If (input.length < 4) Then
            'Console.Out.Write("Shorter than 4 digits");
            Return Me.fixNumTeam("0".concat(input), team)
        ElseIf (input.length > 4) Then
            Console.Out.Write("Err - Longer than 4")
            'JOptionPane.showMessageDialog(tester,
            '      team + " team number greater than 4 digits",
            '    "Team number error",
            '  JOptionPane.ERROR_MESSAGE);
            input = input.substring(0, 4)
        End If

        Return input
    End Function

    '</editor-fold>
    '<editor-fold defaultstate="collapsed" desc="Get/Set Blue and Red Numbers">
    Public Function getBlueRedNumbers() As String(,)
        Dim blue() As String = New String() {blueTeamNumber1.getText, blueTeamNumber2.getText, blueTeamNumber3.getText}
        Dim red() As String = New String() {redTeamNumber1.getText, redTeamNumber2.getText, redTeamNumber3.getText}
        Dim robots(,) As String = New String() {blue, red}
        Return robots
    End Function

    Public Sub setBlueRedNumbers(ByVal teams(,) As String)
        blueTeamNumber1.setText(teams(0)(0))
        blueTeamNumber2.setText(teams(0)(1))
        blueTeamNumber3.setText(teams(0)(2))
        redTeamNumber1.setText(teams(1)(0))
        redTeamNumber2.setText(teams(1)(1))
        redTeamNumber3.setText(teams(1)(2))
        Me.setTeamInfo_Red1()
        Me.setTeamInfo_Red2()
        Me.setTeamInfo_Red3()
        Me.setTeamInfo_Blue1()
        Me.setTeamInfo_Blue2()
        Me.setTeamInfo_Blue3()
    End Sub

    '</editor-fold>
    '</editor-fold>
    ' <editor-fold defaultstate="collapsed" desc="Progress Bar, Team Comm, and Battery">
    Public Sub updateProBar(ByVal percentTime As Double)
        Dim total As Double = (matchProgressBar.getMaximum - matchProgressBar.getMinimum)
        Dim calc As Integer = CType((percentTime * total), Integer)
        matchProgressBar.setValue(calc)
    End Sub

    Private Sub resetProBar()
        matchProgressBar.setValue(matchProgressBar.getMinimum)
    End Sub

    Public Sub changeProBarColor(ByVal color As Color)
        matchProgressBar.setForeground(color)
    End Sub

    Public Sub setCommStatus(ByVal alliance As Integer, ByVal station As Integer, ByVal isFMSAlive As Boolean, ByVal isRobotAlive As Boolean, ByVal isTeamBypassed As Boolean, ByVal isESTOPPED As Boolean)
        'We default to not being ready.
        Dim robCom As Color = NOT_READY
        Dim dsCom As Color = NOT_READY
        'Console.Out.Write("setting comm status...");
        If isESTOPPED Then
            robCom = ESTOPPED
            dsCom = ESTOPPED
        ElseIf Not isTeamBypassed Then
            If isRobotAlive Then
                robCom = READY
            End If

            If isFMSAlive Then
                dsCom = READY
            End If

        ElseIf isTeamBypassed Then
            robCom = BYPASSED
            dsCom = BYPASSED
        End If

        'Decision off of the alliance and position so we set the right control
        ' values.
        If (alliance = FieldAndRobots.RED) Then
            If (station = FieldAndRobots.ONE) Then
                robotComStatusRedTeam1.BackColor = robCom
                dsComStatusRedTeam1.BackColor = dsCom
            ElseIf (station = FieldAndRobots.TWO) Then
                robotComStatusRedTeam2.BackColor = robCom
                dsComStatusRedTeam2.BackColor = dsCom
            ElseIf (station = FieldAndRobots.THREE) Then
                robotComStatusRedTeam3.BackColor = robCom
                dsComStatusRedTeam3.BackColor = dsCom
            Else
                Console.Out.Write("ERROR - SET COM 1")
            End If

        ElseIf (alliance = FieldAndRobots.BLUE) Then
            If (station = FieldAndRobots.ONE) Then
                robotComStatusBlueTeam1.BackColor = robCom
                dsComStatusBlueTeam1.BackColor = dsCom
            ElseIf (station = FieldAndRobots.TWO) Then
                robotComStatusBlueTeam2.BackColor = robCom
                dsComStatusBlueTeam2.BackColor = dsCom
            ElseIf (station = FieldAndRobots.THREE) Then
                robotComStatusBlueTeam3.BackColor = robCom
                dsComStatusBlueTeam3.BackColor = dsCom
            Else
                Console.Out.Write("ERROR - SET COM 2")
            End If

        Else
            Console.Out.Write("ERROR - SET COM 3")
        End If

    End Sub

    Public Sub setBatteryVisual(ByVal alliance As Integer, ByVal stationNumber As Integer, ByVal voltage As Double)
        If (alliance = FieldAndRobots.RED) Then
            'RED
            If (stationNumber = FieldAndRobots.ONE) Then
                voltageRedTeam1.setText(Me.fixBattery(voltage))
            ElseIf (stationNumber = FieldAndRobots.TWO) Then
                voltageRedTeam2.setText(Me.fixBattery(voltage))
            ElseIf (stationNumber = FieldAndRobots.THREE) Then
                voltageRedTeam3.setText(Me.fixBattery(voltage))
            End If

        ElseIf (alliance = FieldAndRobots.BLUE) Then
            'BLUE
            If (stationNumber = FieldAndRobots.ONE) Then
                voltageBlueTeam1.setText(Me.fixBattery(voltage))
            ElseIf (stationNumber = FieldAndRobots.TWO) Then
                voltageBlueTeam2.setText(Me.fixBattery(voltage))
            ElseIf (stationNumber = FieldAndRobots.THREE) Then
                voltageBlueTeam3.setText(Me.fixBattery(voltage))
            End If

        End If

    End Sub

    Private Function fixBattery(ByVal voltage As Double) As String
        Dim volt As String = ("" + voltage)
        Dim volts() As String = volt.split("\\.")
        Dim first As String = volts(0)
        Dim last As String = volts(1)
        If (volts(0).length < 2) Then
            first = ("0" + volts(0))
        End If

        If (volts(1).length < 2) Then
            last = (volts(1) + "0")
        End If

        Return (first + ("." + last))
    End Function

    '</editor-fold>
    ' <editor-fold defaultstate="collapsed" desc="Set Enabled/Selected">
    Public Sub SetAllTeamFieldsEditable(ByVal editable As Boolean)
        blueTeamNumber1.setEditable(editable)
        blueTeamNumber2.setEditable(editable)
        blueTeamNumber3.setEditable(editable)
        redTeamNumber1.setEditable(editable)
        redTeamNumber2.setEditable(editable)
        redTeamNumber3.setEditable(editable)
    End Sub

    Public Sub SetAllBypassBoxesSelected(ByVal selected As Boolean)
        redTeamBypass1.setSelected(selected)
        redTeamBypass2.setSelected(selected)
        redTeamBypass3.setSelected(selected)
        blueTeamBypass1.setSelected(selected)
        blueTeamBypass2.setSelected(selected)
        blueTeamBypass3.setSelected(selected)
    End Sub

    Public Sub SetAllBypassBoxesEnabled(ByVal enabled As Boolean)
        redTeamBypass1.setEnabled(enabled)
        redTeamBypass2.setEnabled(enabled)
        redTeamBypass3.setEnabled(enabled)
        blueTeamBypass1.setEnabled(enabled)
        blueTeamBypass2.setEnabled(enabled)
        blueTeamBypass3.setEnabled(enabled)
    End Sub

    Public Sub setResetButtonEnabled(ByVal enabled As Boolean)
        resetButton.setEnabled(enabled)
    End Sub

    '</editor-fold>
    ' <editor-fold defaultstate="collapsed" desc="Check Field Readiness">
    Public Sub checkIfFieldReady()
        Dim redReady As Boolean = Me.isRedReady
        Dim blueReady As Boolean = Me.isBlueReady
        If (redReady AndAlso blueReady) Then
            fullFieldReady.setBackground(READY)
            Dim game As GovernThread = GovernThread.getInstance
            If (Not (game) Is Nothing) Then
                beginMatchButton.setEnabled(game.isNewMatch)
            Else
                fullFieldReady.setBackground(NOT_READY)
                beginMatchButton.setEnabled(False)
            End If

        Else
            fullFieldReady.setBackground(NOT_READY)
            beginMatchButton.setEnabled(False)
        End If

        If Not Main.isSimpleMode Then
            If ((redReady <> prevRedReady) _
                        OrElse (blueReady <> prevBlueReady)) Then
                PLC_Sender.getInstance.updatePLC_Lights(True)
            End If

        End If

        prevRedReady = redReady
        prevBlueReady = blueReady
    End Sub

    Public Function isRedReady() As Boolean
        If FieldAndRobots.getInstance.isAllianceReady(FieldAndRobots.RED) Then
            redSideReady.BackColor = READY
            Return True
        Else
            redSideReady.BackColor = NOT_READY
            Return False
        End If

    End Function

    Public Function isBlueReady() As Boolean
        If FieldAndRobots.getInstance.isAllianceReady(FieldAndRobots.BLUE) Then
            blueSideReady.BackColor = READY
            Return True
        Else
            blueSideReady.BackColor = NOT_READY
            Return False
        End If

    End Function

    '</editor-fold>
    Public Sub setMatchTime(ByVal text As String)
        runningMatchTime.setText(text)
        If Not Main.isSimpleMode Then
            PLC_Sender.getInstance.updatePLC_Time(True)
        End If

    End Sub

    Public Shared Sub forceLightUpdate()
        PLC_Sender.getInstance.updatePLC_Lights(True)
    End Sub
End Class