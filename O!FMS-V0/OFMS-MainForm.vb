﻿Imports System.Data.SqlClient
Imports O_FMS_V0.PLC_Comms_Server
Imports O_FMS_V0.Field



Public Class Main_Panel

    Dim DriverStation As New Threading.Thread(AddressOf HandleDSConnections)
    Public Shared PLC_Thread As New Threading.Thread(AddressOf handlePLC)
    Dim connection As New SqlConnection("data source=MY-PC\OFMS; Initial Catalog=O!FMS; Integrated Security = true")

    Public Shared Red1_Bypass As Boolean = False
    Public Shared Red2_Bypass As Boolean = False
    Public Shared Red3_Bypass As Boolean = False
    Public Shared Blue1_Bypass As Boolean = False
    Public Shared Blue2_Bypass As Boolean = False
    Public Shared Blue3_Bypass As Boolean = False

    'Red Scoring Varibles'
    Public Shared RedScore As Integer
    Public Shared RedPenaltyScore As Integer
    Public Shared RedCargoshipCargoScore As Integer
    Public Shared RedCargoshipHatchScore As Integer
    Public Shared RedRocketCargoScore As Integer
    Public Shared RedRocketHatchScore As Integer
    Public Shared RedHABScore As Integer
    Public Shared RedClimbScore As Integer
    Public Shared RedRankingPoints As Integer

    'Blue Scoring Varibles
    Public Shared BlueScore As Integer
    Public Shared BluePenaltyScore As Integer
    Public Shared BlueCargoshipCargoScore As Integer
    Public Shared BlueCargoshipHatchScore As Integer
    Public Shared BlueRocketCargoScore As Integer
    Public Shared BlueRocketHatchScore As Integer
    Public Shared BlueHABScore As Integer
    Public Shared BlueClimbScore As Integer
    Public Shared BlueRankingPoints As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the '_O_FMSDataSet.FMSMaster' table. You can move, or remove it, as needed.
        Timer1.Interval = 1000 '1 seconds
        Timer1.Enabled = True
        'Timer1.AutoReset = True
        BackColor = System.Drawing.Color.Yellow
        ' Me.FMSMasterTableAdapter.Fill(Me._O_FMSDataSet.FMSMaster)
        Call CenterToScreen()
        Me.FormBorderStyle = Windows.Forms.BorderStyle.Fixed3D
        Me.WindowState = FormWindowState.Normal
        resetScore()
    End Sub



    Private Sub BindingSource1_CurrentChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        'Dim insertquery As String = "INSERT INTO FMSMaster([Match], [MatchTime], [Blue1], [B1Sur],  [Blue1DQ], [Blue1Volt], [Blue1Estop], [Blue1RL], [Blue1DS], [Blue1Bypass], [Blue2], [B2Sur], [Blue2DQ], [Blue2Volt], [Blue2Estop], [Blue2RL], [Blue2DS], [Blue2Bypass], [Blue3], [B3Sur], [Blue3DQ], [Blue3Volt], [Blue3Estop], [Blue3RL], [Blue3DS], [Blue3Bypass], [Red1], [R1Sur], [Red1DQ], [Red1Volt], [Red1Estop], [Red1RL], [Red1DS], [Red1Bypass], [Red2], [R2Sur], [Red2DQ], [Red2Volt], [Red2Estop], [Red2RL], [Red2DS], [Red2Bypass], [Red3], [R3Sur], [Red3DQ], [Red3Volt], [Red3Estop], [Red3RL], [Red3DS], [Red3Bypass]) VALUES('" & MatchNum.Text & "', '" & Ctime.Text & "', '" & BlueTeam1.Text & "', '" & Blue1Sur.Text & "', '" & BDQ1.Checked & "', '" & BlueVolt1.Text & "','" & PLC_Estop_Red1 & "' ,'" & Robot_Linked_Red1 & "' , '" & DS_Linked_Red1 & "', '" & BBypass1.Checked & "', '" & BlueTeam2.Text & "','" & Blue2Sur.Text & "', '" & BDQ2.Checked & "', '" & BlueVolt2.Text & "', '" & PLC_Estop_Blue2 & "','" & Robot_Linked_Blue2 & "' ,'" & DS_Linked_Blue2 & "' , '" & BBypass2.Checked & "', '" & BlueTeam3.Text & "','" & Blue3Sur.Text & "' , '" & BDQ3.Checked & "', '" & BlueVolt3.Text & "','" & PLC_Estop_Blue3 & "' , '" & Robot_Linked_Blue3 & "', '" & DS_Linked_Blue3 & "', '" & BBypass3.Checked & "', '" & RedTeam1.Text & "', '" & Red1Sur.Text & "', '" & RDQ1.Checked & "', '" & RedVolt1.Text & "', '" & PLC_Estop_Red1 & "', '" & Robot_Linked_Red1 & "', '" & DS_Linked_Red1 & "', '" & RBypass1.Checked & "', '" & RedTeam2.Text & "', '" & Red2Sur.Text & "', '" & RDQ2.Checked & "', '" & RedVolt2.Text & "', '" & PLC_Estop_Red2 & "', '" & Robot_Linked_Red2 & "','" & DS_Linked_Red2 & "' , '" & RBypass2.Checked & "', '" & RedTeam3.Text & "', '" & Red3Sur.Text & "', '" & RDQ3.Checked & "', '" & RedVolt3.Text & "','" & PLC_Estop_Red3 & "' ,'" & Robot_Linked_Red3 & "' ,'" & DS_Linked_Red3 & "' , '" & RBypass3.Checked & "', '" & SandStormMessage.Text & "')"

        'ExecuteQuery(insertquery)

        'MessageBox.Show("Data Saved")

        resetScore()

    End Sub

    Public Sub ExecuteQuery(query As String)
        Dim command As New SqlCommand(query, connection)
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub

    Public Sub MatchLoad_Btn_Click(sender As Object, e As EventArgs) Handles MatchLoad_Btn.Click

        Dim selectQuery As New SqlCommand("Select Match, Blue1, B1Sur, Blue2, B2Sur, Blue3, B3Sur, Red1, R1Sur, Red2, R2Sur, Red3, R3Sur FROM MatchList where Match= @Matchnum", connection)
        selectQuery.Parameters.Add("@Matchnum", SqlDbType.Int).Value = MatchNum.Text
        Dim adapter As New SqlDataAdapter(selectQuery)
        Dim table As New DataTable()
        adapter.Fill(table)
        If table.Rows.Count() > 0 Then
            RedTeam1.Text = table.Rows(0)(7).ToString()
            Red1Sur.Text = table.Rows(0)(8).ToString()
            RedTeam2.Text = table.Rows(0)(9).ToString()
            Red2Sur.Text = table.Rows(0)(10).ToString()
            RedTeam3.Text = table.Rows(0)(11).ToString()
            Red3Sur.Text = table.Rows(0)(12).ToString()
            BlueTeam1.Text = table.Rows(0)(1).ToString()
            Blue1Sur.Text = table.Rows(0)(2).ToString()
            BlueTeam2.Text = table.Rows(0)(3).ToString()
            Blue2Sur.Text = table.Rows(0)(4).ToString()
            BlueTeam3.Text = table.Rows(0)(5).ToString()
            Blue3Sur.Text = table.Rows(0)(6).ToString()

            'updates the audience display with team numbers'
            AudianceDisplay.RedTeam1.Text = table.Rows(0)(7).ToString
            AudianceDisplay.RedTeam2lbl.Text = table.Rows(0)(9).ToString
            AudianceDisplay.RedTeam3.Text = table.Rows(0)(11).ToString
            AudianceDisplay.BlueTeam1lbl.Text = table.Rows(0)(1).ToString
            AudianceDisplay.BlueTeam2.Text = table.Rows(0)(3).ToString
            AudianceDisplay.BlueTeam3.Text = table.Rows(0)(5).ToString

            'Updates the audience display with match number'
            AudianceDisplay.MatchNumb.Text = MatchNum.Text

            'Updates the audience display with match type
            MessageBox.Show("Data Loaded")
        Else
            MessageBox.Show("Not Loaded")
        End If

        RedT1 = RedTeam1.Text
        RedT2 = RedTeam2.Text
        RedT3 = RedTeam3.Text
        BlueT1 = BlueTeam1.Text
        BlueT2 = BlueTeam2.Text
        BlueT3 = BlueTeam3.Text


    End Sub

    Private Sub RDQ1_CheckedChanged(sender As Object, e As EventArgs) Handles RDQ1.CheckedChanged
        If PLC_Estop_Red1 = False Then
            PLC_Estop_Red1 = True
        Else : PLC_Estop_Red1 = True
        End If
    End Sub

    Private WithEvents Timer1 As New System.Windows.Forms.Timer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Ctime.Text = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        'Convert match mode timer to PLC Timer'
        ' PLCTimer.Text = PLC_Match_Timer

        'Estops
        If PLC_Estop_Red1 = True Then
            R1Estop.FillColor = System.Drawing.Color.LimeGreen
        Else : R1Estop.FillColor = System.Drawing.Color.Gray
        End If
        If PLC_Estop_Red2 = True Then
            R2Estop.FillColor = System.Drawing.Color.LimeGreen
        Else : R2Estop.FillColor = System.Drawing.Color.Gray
        End If
        If PLC_Estop_Red3 = True Then
            R3Estop.FillColor = System.Drawing.Color.LimeGreen
        Else : R3Estop.FillColor = System.Drawing.Color.Gray
        End If

        If PLC_Estop_Blue1 = True Then
            B1Estop.FillColor = System.Drawing.Color.LimeGreen
        Else : B1Estop.FillColor = System.Drawing.Color.Gray
        End If
        If PLC_Estop_Blue2 = True Then
            B2Estop.FillColor = System.Drawing.Color.LimeGreen
        Else : B2Estop.FillColor = System.Drawing.Color.Gray
        End If
        If PLC_Estop_Blue3 = True Then
            B3Estop.FillColor = System.Drawing.Color.LimeGreen
        Else : B3Estop.FillColor = System.Drawing.Color.Gray
        End If

        'Driver Stations (DS) Linked
        If DS_Linked_Red1 Then
            R1DS.FillColor = System.Drawing.Color.LimeGreen
        Else : R1DS.FillColor = System.Drawing.Color.Red
        End If
        If DS_Linked_Red2 Then
            R2DS.FillColor = System.Drawing.Color.LimeGreen
        Else : R2DS.FillColor = System.Drawing.Color.Red
        End If
        If DS_Linked_Red3 Then
            R3DS.FillColor = System.Drawing.Color.LimeGreen
        Else : R3DS.FillColor = System.Drawing.Color.Red
        End If

        If DS_Linked_Blue1 Then
            B1DS.FillColor = System.Drawing.Color.LimeGreen
        Else : B1DS.FillColor = System.Drawing.Color.Red
        End If
        If DS_Linked_Blue2 Then
            B2DS.FillColor = System.Drawing.Color.LimeGreen
        Else : B2DS.FillColor = System.Drawing.Color.Red
        End If
        If DS_Linked_Blue3 Then
            B3DS.FillColor = System.Drawing.Color.LimeGreen
        Else : B3DS.FillColor = System.Drawing.Color.Red
        End If

        'Robot Linked
        If Robot_Linked_Red1 = True Then
            R1Robot.FillColor = System.Drawing.Color.LimeGreen
        Else : R1Robot.FillColor = System.Drawing.Color.Red
        End If
        If Robot_Linked_Red2 = True Then
            R2Robot.FillColor = System.Drawing.Color.LimeGreen
        Else : R2Robot.FillColor = System.Drawing.Color.Red
        End If
        If Robot_Linked_Red3 = True Then
            R3Robot.FillColor = System.Drawing.Color.LimeGreen
        Else : R3Robot.FillColor = System.Drawing.Color.Red
        End If

        If Robot_Linked_Blue1 = True Then
            B1Robot.FillColor = System.Drawing.Color.LimeGreen
        Else : B1Robot.FillColor = System.Drawing.Color.Red
        End If
        If Robot_Linked_Blue2 = True Then
            B2Robot.FillColor = System.Drawing.Color.LimeGreen
        Else : B2Robot.FillColor = System.Drawing.Color.Red
        End If
        If Robot_Linked_Blue3 = True Then
            B3Robot.FillColor = System.Drawing.Color.LimeGreen
        Else : B3Robot.FillColor = System.Drawing.Color.Red
        End If

        'Match Mode
        If PLC_Match_Timer = 0 Then
            PLC_Match_Mode = 0

        ElseIf PLC_Match_Timer <= 15 Then
            PLC_Match_Mode = 1

        ElseIf PLC_Match_Timer >= 216 Then
            PLC_Match_Mode = 100

        ElseIf PLC_Match_Timer = 230 Then
            PLC_Match_Mode = 120

        End If
        'Updates the audience display with time and scores'
        AudianceDisplay.Timerlbl.Text = matchTimerLbl.Text



    End Sub


    Private Sub R1Estop_Click(sender As Object, e As EventArgs)
        If PLC_Estop_Red1 = False Then
            PLC_Estop_Red1 = True
        Else : PLC_Estop_Red1 = True
        End If
    End Sub

    Private Sub R2Estop_Click(sender As Object, e As EventArgs)
        If PLC_Estop_Red2 = False Then
            PLC_Estop_Red2 = True
        Else : PLC_Estop_Red2 = True
        End If
    End Sub

    Private Sub R3Estop_Click(sender As Object, e As EventArgs)
        If PLC_Estop_Red3 = False Then
            PLC_Estop_Red3 = True
        Else : PLC_Estop_Red3 = True
        End If
    End Sub

    Private Sub RDQ2_CheckedChanged(sender As Object, e As EventArgs) Handles RDQ2.CheckedChanged
        If PLC_Estop_Red2 = False Then
            PLC_Estop_Red2 = True
        Else : PLC_Estop_Red2 = True
        End If
    End Sub

    Private Sub RDQ3_CheckedChanged(sender As Object, e As EventArgs) Handles RDQ3.CheckedChanged
        If PLC_Estop_Red3 = False Then
            PLC_Estop_Red3 = True
        Else : PLC_Estop_Red3 = True
        End If
    End Sub

    Private Sub B1Estop_Click(sender As Object, e As EventArgs)
        If PLC_Estop_Blue1 = False Then
            PLC_Estop_Blue1 = True
        Else : PLC_Estop_Blue1 = True
        End If
    End Sub

    Private Sub B2Estop_Click(sender As Object, e As EventArgs)
        If PLC_Estop_Blue2 = False Then
            PLC_Estop_Blue2 = True
        Else : PLC_Estop_Blue2 = True
        End If
    End Sub

    Private Sub B3Estop_Click(sender As Object, e As EventArgs)
        If PLC_Estop_Blue3 = False Then
            PLC_Estop_Blue3 = True
        Else : PLC_Estop_Blue3 = True
        End If
    End Sub

    Private Sub BDQ1_CheckedChanged(sender As Object, e As EventArgs) Handles BDQ1.CheckedChanged
        If PLC_Estop_Blue1 = False Then
            PLC_Estop_Blue1 = True
        Else : PLC_Estop_Blue1 = True
        End If
    End Sub

    Private Sub BDQ2_CheckedChanged(sender As Object, e As EventArgs) Handles BDQ2.CheckedChanged
        If PLC_Estop_Blue2 = False Then
            PLC_Estop_Blue2 = True
        Else : PLC_Estop_Blue2 = True
        End If
    End Sub

    Private Sub BDQ3_CheckedChanged(sender As Object, e As EventArgs) Handles BDQ3.CheckedChanged
        If PLC_Estop_Blue3 = False Then
            PLC_Estop_Blue3 = True
        Else : PLC_Estop_Blue3 = True
        End If
    End Sub

    Private Sub Pre_Start_btn_Click(sender As Object, e As EventArgs) Handles Pre_Start_btn.Click
        Match_Aborted = False
        If DriverStation IsNot Nothing Then
            DriverStation.Abort()
        End If

        DriverStation = New Threading.Thread(AddressOf HandleDSConnections)
        DriverStation.Start()
        updateField(MatchEnums.PreMatch)
        matchTimerLbl.Text = SandStormTime
        AutoTimer.Enabled = False
        MatchMessages.Text = "Field Pre-Started"
    End Sub

    Private Sub StartMatch_btn_Click(sender As Object, e As EventArgs) Handles StartMatch_btn.Click
        updateField(MatchEnums.SandStorm)
        AutoTimer.Start()
    End Sub

    Private Sub AutoTimer_Tick(sender As Object, e As EventArgs) Handles AutoTimer.Tick
        AutoTimer.Start()
        AutoTimer.Interval = 1000
        matchTimerLbl.Text = Val(matchTimerLbl.Text) - 1
        MatchMessages.Text = "Sand Storm"

        If matchTimerLbl.Text = 0 Then
            updateField(MatchEnums.TeleOp)
            matchTimerLbl.Text = TeleTime
            AutoTimer.Stop()
            TeleTimer.Enabled = True
            TeleTimer.Start()
        End If
    End Sub

    Private Sub TeleTimer_Tick(sender As Object, e As EventArgs) Handles TeleTimer.Tick
        TeleTimer.Start()
        TeleTimer.Interval = 1000
        matchTimerLbl.Text = Val(matchTimerLbl.Text) - 1
        MatchMessages.Text = "Tele-Operated"

        If matchTimerLbl.Text = 30 Then
            updateField(MatchEnums.EndGameWarning)
            matchTimerLbl.Text = EndgameWarningTime
            TeleTimer.Stop()
            EndGameTimer.Enabled = True
            EndGameTimer.Start()
        End If
    End Sub

    Private Sub EndGameTimer_Tick(sender As Object, e As EventArgs) Handles EndGameTimer.Tick
        EndGameTimer.Start()
        EndGameTimer.Interval = 1000
        matchTimerLbl.Text = Val(matchTimerLbl.Text) - 1
        MatchMessages.Text = "EndGame Warning"

        If matchTimerLbl.Text = 20 Then
            updateField(MatchEnums.EndGame)
            MatchMessages.Text = "EndGame"
        End If

        If matchTimerLbl.Text = 0 Then
            updateField(MatchEnums.PostMatch)
            EndGameTimer.Stop()
            SandStormMessage.Text = ""
            MatchMessages.Text = "Match Ended"
        End If
    End Sub

    Private Sub AbortMatch_btn_Click(sender As Object, e As EventArgs) Handles AbortMatch_btn.Click
        HandleAbortedMatch()
        Match_Aborted = True
        Field.updateField(MatchEnums.AbortMatch)
        MatchMessages.Text = "Match Aborted"
        matchTimerLbl.Text = 0
        AutoTimer.Stop()
        TeleTimer.Stop()
        EndGameTimer.Stop()

    End Sub

    Public Sub HandleAbortedMatch()
        DriverStation.Abort()
    End Sub

    Public Sub ResetPLC()
        PLC_Estop_Field = False
        PLC_Estop_Red1 = False
        PLC_Estop_Red2 = False
        PLC_Estop_Red3 = False
        PLC_Estop_Blue1 = False
        PLC_Estop_Blue2 = False
        PLC_Estop_Blue3 = False
    End Sub

    'FTA Group Buttons'
    Private Sub ConnectPLCBtn_Click(sender As Object, e As EventArgs) Handles ConnectPLCBtn.Click
        ConnectPLC()
    End Sub

    Private Sub DSLightTestBtn_Click(sender As Object, e As EventArgs) Handles DSLightTestBtn.Click
        Alliance_Light_Test = True
    End Sub

    Private Sub ScoringTableLightTestBtn_Click(sender As Object, e As EventArgs) Handles ScoringTableLightTestBtn.Click
        Scoring_Light_Test = True
    End Sub

    Private Sub LedPatternTestBtn_Click(sender As Object, e As EventArgs) Handles LedPatternTestBtn.Click
        'Add Led Pattern Test'
    End Sub

    'Display Box Buttons'
    Private Sub PreMatchBtn_Click(sender As Object, e As EventArgs) Handles PreMatchBtn.Click
        AudianceDisplay.PrestartCover.Show()
        AudianceDisplay.PreStartPanel.Show()
        AudianceDisplay.FinalScoreBox.Hide()
        AudianceDisplay.Winner.Hide()
        AudianceDisplay.WinningAlliance.Hide()
    End Sub

    Private Sub MatchPlay_Click(sender As Object, e As EventArgs) Handles MatchPlay.Click
        AudianceDisplay.PrestartCover.Hide()
        AudianceDisplay.PreStartPanel.Hide()
        AudianceDisplay.FinalScoreBox.Hide()
        AudianceDisplay.Winner.Hide()
        AudianceDisplay.WinningAlliance.Hide()
    End Sub

    Private Sub FinalScoreBtn_Click(sender As Object, e As EventArgs) Handles FinalScoreBtn.Click
        AudianceDisplay.PrestartCover.Show()
        AudianceDisplay.PreStartPanel.Show()
        AudianceDisplay.FinalScoreBox.Show()
        AudianceDisplay.Winner.Show()
        AudianceDisplay.WinningAlliance.Show()
    End Sub

    Private Sub RBypass1_CheckedChanged(sender As Object, e As EventArgs) Handles RBypass1.CheckedChanged
        Red1_Bypass = True
    End Sub

    Private Sub RBypass2_CheckedChanged(sender As Object, e As EventArgs) Handles RBypass2.CheckedChanged
        Red2_Bypass = True
    End Sub

    Private Sub RBypass3_CheckedChanged(sender As Object, e As EventArgs) Handles RBypass3.CheckedChanged
        Red3_Bypass = True
    End Sub

    Private Sub BBypass1_CheckedChanged(sender As Object, e As EventArgs) Handles BBypass1.CheckedChanged
        Blue1_Bypass = True
    End Sub

    Private Sub BBypass2_CheckedChanged(sender As Object, e As EventArgs) Handles BBypass2.CheckedChanged
        Blue2_Bypass = True
    End Sub

    Private Sub BBypass3_CheckedChanged(sender As Object, e As EventArgs) Handles BBypass3.CheckedChanged
        Blue3_Bypass = True
    End Sub

    'Manual Scoring Area'
    'Red Cargoship Cargo'
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        RedCargoshipCargoScore = RedCargoshipCargoScore + 3
        RedScore = RedScore + RedCargoshipCargoScore
        RedScoreLbl.Text = RedScore
    End Sub
    'Red Cargoship Hatch'
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RedCargoshipHatchScore = RedCargoshipHatchScore + 2
        RedScore = RedScore + RedCargoshipHatchScore
        RedScoreLbl.Text = RedScore
    End Sub
    'HAB 1 Sandstorm'
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RedHABScore = RedHABScore + 3
        RedScore = RedScore + RedHABScore
        RedScoreLbl.Text = RedScore
    End Sub
    'HAB 2 Sandstorm
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        RedHABScore = RedHABScore + 6
        RedScore = RedScore + RedHABScore
        RedScoreLbl.Text = RedScore
    End Sub
    'HAB 1 Climb'
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        RedClimbScore = RedClimbScore + 3
        RedScore = RedScore + RedClimbScore
        RedScoreLbl.Text = RedScore
    End Sub
    'HAB 2 Climb'
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        RedClimbScore = RedClimbScore + 6
        RedScore = RedScore + RedClimbScore
        RedScoreLbl.Text = RedScore
    End Sub
    'HAB 3 Climb'
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        RedClimbScore = RedClimbScore + 12
        RedScore = RedScore + RedClimbScore
        RedScoreLbl.Text = RedScore
    End Sub
    'Red Complete Rocket'
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        'Add Ranking Points stuff'
    End Sub
    'Rocket Cargo'
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        RedRocketCargoScore = RedRocketCargoScore + 3
        RedScore = RedScore + RedRocketCargoScore
        RedScoreLbl.Text = RedScore
    End Sub
    'Rocket Hatch'
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        RedRocketHatchScore = RedRocketHatchScore + 2
        RedScore = RedScore + RedRocketHatchScore
        RedScoreLbl.Text = RedScore
    End Sub
    'All Climb'
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        'Add Ranking Points stuff'
    End Sub
    'Red Tech Foul'
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        RedPenaltyScore = RedPenaltyScore + 10
        BlueScore = BlueScore + 10
        BlueScoreLbl.Text = BlueScore
    End Sub
    'Red Foul'
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        RedPenaltyScore = RedPenaltyScore + 3
        BlueScore = BlueScore + 3
        BlueScoreLbl.Text = BlueScore
    End Sub
    'Cargoship Cargo'
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        BlueCargoshipCargoScore = BlueCargoshipCargoScore + 3
        BlueScore = BlueScore + BlueCargoshipCargoScore
        BlueScoreLbl.Text = BlueScore
    End Sub
    'Cargoship Hatch'
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        BlueCargoshipHatchScore = BlueCargoshipHatchScore + 2
        BlueScore = BlueScore + BlueCargoshipHatchScore
        BlueScoreLbl.Text = BlueScore
    End Sub
    'HAB 1 Sandstorm'
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        BlueHABScore = BlueHABScore + 3
        BlueScore = BlueScore + BlueHABScore
        BlueScoreLbl.Text = BlueScore
    End Sub
    'HAB 2 Sandstorm'
    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        BlueHABScore = BlueHABScore + 6
        BlueScore = BlueScore + BlueHABScore
        BlueScoreLbl.Text = BlueScore
    End Sub
    'All Climb'
    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        'Add Ranking points stuff'
    End Sub
    'HAB Climb 1'
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        BlueClimbScore = BlueClimbScore + 3
        BlueScore = BlueScore + BlueClimbScore
        BlueScoreLbl.Text = BlueScore
    End Sub
    'HAB Climb 2'
    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        BlueClimbScore = BlueClimbScore + 6
        BlueScore = BlueScore + BlueClimbScore
        BlueScoreLbl.Text = BlueScore
    End Sub
    'HAB Climb 3'
    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        BlueClimbScore = BlueClimbScore + 12
        BlueScore = BlueScore + BlueClimbScore
        BlueScoreLbl.Text = BlueScore
    End Sub
    'Rocket Cargo'
    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        BlueRocketCargoScore = BlueRocketCargoScore + 3
        BlueScore = BlueScore + BlueRocketCargoScore
        BlueScoreLbl.Text = BlueScore
    End Sub
    'Rocket Hatch'
    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        BlueRocketHatchScore = BlueRocketHatchScore + 2
        BlueScore = BlueScore + BlueRocketHatchScore
        BlueScoreLbl.Text = BlueScore
    End Sub
    'Completed Rocket'
    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        'Add Ranking Points stuff'
    End Sub
    'Blue Tech Foul'
    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        BluePenaltyScore = BluePenaltyScore + 10
        RedScore = RedScore + 10
        RedScoreLbl.Text = RedScore
    End Sub
    'Blue Foul'
    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        BluePenaltyScore = BluePenaltyScore + 3
        RedScore = RedScore + 3
        RedScoreLbl.Text = RedScore
    End Sub

    Private Sub resetScore()
        RedScore = 0
        RedPenaltyScore = 0
        RedCargoshipCargoScore = 0
        RedCargoshipHatchScore = 0
        RedRocketCargoScore = 0
        RedRocketHatchScore = 0
        RedHABScore = 0
        RedClimbScore = 0
        RedRankingPoints = 0
        BlueScore = 0
        BluePenaltyScore = 0
        BlueCargoshipCargoScore = 0
        BlueCargoshipHatchScore = 0
        BlueRocketCargoScore = 0
        BlueRocketHatchScore = 0
        BlueHABScore = 0
        BlueClimbScore = 0
        BlueRankingPoints = 0

        RedScoreLbl.Text = RedScore
        BlueScoreLbl.Text = BlueScore
    End Sub
End Class