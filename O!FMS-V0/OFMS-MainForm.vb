Imports System.Data.SqlClient
Imports O_FMS_V0.PLC_Comms_Server
Imports O_FMS_V0.RandomString
Imports O_FMS_V0.Field
Imports O_FMS_V0.Lighting





Public Class Main_Panel

    Dim DriverStation As New Threading.Thread(AddressOf HandleDSConnections)
    Dim PLCThread As New Threading.Thread(AddressOf HandlePLC)
    ' Dim LEDThread As New Threading.Thread(AddressOf handleLeds)

    Dim connection As New SqlConnection("data source=MY-PC\OFMS; Initial Catalog=O!FMS; Integrated Security = true")
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

    End Sub



    Private Sub BindingSource1_CurrentChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        Dim insertquery As String = "INSERT INTO FMSMaster([Match], [MatchTime], [Blue1], [B1Sur],  [Blue1DQ], [Blue1Volt], [Blue1Estop], [Blue1RL], [Blue1DS], [Blue1Bypass], [Blue2], [B2Sur], [Blue2DQ], [Blue2Volt], [Blue2Estop], [Blue2RL], [Blue2DS], [Blue2Bypass], [Blue3], [B3Sur], [Blue3DQ], [Blue3Volt], [Blue3Estop], [Blue3RL], [Blue3DS], [Blue3Bypass], [Red1], [R1Sur], [Red1DQ], [Red1Volt], [Red1Estop], [Red1RL], [Red1DS], [Red1Bypass], [Red2], [R2Sur], [Red2DQ], [Red2Volt], [Red2Estop], [Red2RL], [Red2DS], [Red2Bypass], [Red3], [R3Sur], [Red3DQ], [Red3Volt], [Red3Estop], [Red3RL], [Red3DS], [Red3Bypass], [Bluescore], [bluepen], [BlueForce], [BlueLevitate], [BlueBoost], [BlueHang], [Redscore], [redpen], [RedForce], [RedLevitate], [RedBoost], [RedHang], [SwitchScale]) VALUES('" & MatchNum.Text & "', '" & Ctime.Text & "', '" & BlueTeam1.Text & "', '" & Blue1Sur.Text & "', '" & BDQ1.Checked & "', '" & BlueVolt1.Text & "','" & PLC_Estop_Red1 & "' ,'" & Robot_Linked_Red1 & "' , '" & DS_Linked_Red1 & "', '" & BBypass1.Checked & "', '" & BlueTeam2.Text & "','" & Blue2Sur.Text & "', '" & BDQ2.Checked & "', '" & BlueVolt2.Text & "', '" & PLC_Estop_Blue2 & "','" & Robot_Linked_Blue2 & "' ,'" & DS_Linked_Blue2 & "' , '" & BBypass2.Checked & "', '" & BlueTeam3.Text & "','" & Blue3Sur.Text & "' , '" & BDQ3.Checked & "', '" & BlueVolt3.Text & "','" & PLC_Estop_Blue3 & "' , '" & Robot_Linked_Blue3 & "', '" & DS_Linked_Blue3 & "', '" & BBypass3.Checked & "', '" & RedTeam1.Text & "', '" & Red1Sur.Text & "', '" & RDQ1.Checked & "', '" & RedVolt1.Text & "', '" & PLC_Estop_Red1 & "', '" & Robot_Linked_Red1 & "', '" & DS_Linked_Red1 & "', '" & RBypass1.Checked & "', '" & RedTeam2.Text & "', '" & Red2Sur.Text & "', '" & RDQ2.Checked & "', '" & RedVolt2.Text & "', '" & PLC_Estop_Red2 & "', '" & Robot_Linked_Red2 & "','" & DS_Linked_Red2 & "' , '" & RBypass2.Checked & "', '" & RedTeam3.Text & "', '" & Red3Sur.Text & "', '" & RDQ3.Checked & "', '" & RedVolt3.Text & "','" & PLC_Estop_Red3 & "' ,'" & Robot_Linked_Red3 & "' ,'" & DS_Linked_Red3 & "' , '" & RBypass3.Checked & "', '" & BlueScore.Text & "', '" & BluePen.Text & "','" & PLC_Used_Force_Blue & "' , '" & PLC_Used_Lev_Blue & "','" & PLC_Used_Boost_Blue & "' , '" & BlueAllianceHang.Text & "', '" & RedScore.Text & "', '" & RedPen.Text & "','" & PLC_Used_Force_Red & "' , '" & PLC_Used_Lev_Red & "','" & PLC_Used_Boost_Red & "' , '" & RedAllianceHang & "', '" & ScaleSwitch.Text & "')"

        ExecuteQuery(insertquery)

        MessageBox.Show("Data Saved")

    End Sub

    Public Sub ExecuteQuery(query As String)
        Dim command As New SqlCommand(query, connection)
        connection.Open()
        command.ExecuteNonQuery()
        connection.Close()
    End Sub

    Public Sub MatchLoad_Btn_Click(sender As Object, e As EventArgs) Handles MatchLoad_Btn.Click

        Dim selectQuery As New SqlCommand("Select Match, Blue1, B1Sur, Blue2, B2Sur, Blue3, B3Sur, Red1, R1Sur, Red2, R2Sur, Red3, R3Sur, MatchType FROM MatchList where Match= @Matchnum", connection)
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
            AudianceDisplay.Label1.Text = table.Rows(0)(13).ToString
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
        RPLC_Score.Text = PLC_RedScore
        BPLC_Score.Text = PLC_BlueScore

        'Red Power-Ups

        If PLC_Used_Boost_Red = True Then
            RBoost.FillColor = System.Drawing.Color.LimeGreen

        Else : RBoost.FillColor = System.Drawing.Color.Gray
        End If
        If PLC_Used_Force_Red = True Then
            RForce.FillColor = System.Drawing.Color.LimeGreen
        Else : RForce.FillColor = System.Drawing.Color.Gray
        End If
        If PLC_Used_Lev_Red = True Then
            RLev.FillColor = System.Drawing.Color.LimeGreen
        Else : RLev.FillColor = System.Drawing.Color.Gray
        End If

        'Blue Power-Ups
        If PLC_Used_Boost_Blue = True Then
            BBoost.FillColor = System.Drawing.Color.LimeGreen
        Else : BBoost.FillColor = System.Drawing.Color.Gray
        End If
        If PLC_Used_Force_Blue = True Then
            BForce.FillColor = System.Drawing.Color.LimeGreen
        Else : BForce.FillColor = System.Drawing.Color.Gray
        End If
        If PLC_Used_Lev_Blue = True Then
            BLev.FillColor = System.Drawing.Color.LimeGreen
        Else : BLev.FillColor = System.Drawing.Color.Gray
        End If

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

        'Score & Penalty Calculations
        If RedPen.Text <> Nothing Then
            RedScore.Text = (RPLC_Score.Text + RedAllianceHang.Text - RedPen.Text)
        Else : RedScore = RPLC_Score
        End If
        If BluePen.Text <> Nothing Then
            BlueScore.Text = (BPLC_Score.Text + BlueAllianceHang.Text - BluePen.Text)
        Else : BlueScore = BPLC_Score
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
        AudianceDisplay.RedScoreLbl.Text = RedScore.Text
        AudianceDisplay.BlueScoreLbl.Text = BlueScore.Text

    End Sub


    Private Sub R1Estop_Click(sender As Object, e As EventArgs) Handles R1Estop.Click
        If PLC_Estop_Red1 = False Then
            PLC_Estop_Red1 = True
        Else : PLC_Estop_Red1 = True
        End If
    End Sub

    Private Sub R2Estop_Click(sender As Object, e As EventArgs) Handles R2Estop.Click
        If PLC_Estop_Red2 = False Then
            PLC_Estop_Red2 = True
        Else : PLC_Estop_Red2 = True
        End If
    End Sub

    Private Sub R3Estop_Click(sender As Object, e As EventArgs) Handles R3Estop.Click
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

    Private Sub B1Estop_Click(sender As Object, e As EventArgs) Handles B1Estop.Click
        If PLC_Estop_Blue1 = False Then
            PLC_Estop_Blue1 = True
        Else : PLC_Estop_Blue1 = True
        End If
    End Sub

    Private Sub B2Estop_Click(sender As Object, e As EventArgs) Handles B2Estop.Click
        If PLC_Estop_Blue2 = False Then
            PLC_Estop_Blue2 = True
        Else : PLC_Estop_Blue2 = True
        End If
    End Sub

    Private Sub B3Estop_Click(sender As Object, e As EventArgs) Handles B3Estop.Click
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
        PLCThread = New Threading.Thread(AddressOf HandlePLC)
        DriverStation = New Threading.Thread(AddressOf HandleDSConnections)
        '  LEDThread = New Threading.Thread(AddressOf handleLeds)
        '  LEDThread.Start()
        DriverStation.Start()
        PLCThread.Start()
        updateField(MatchEnums.PreMatch)
        matchTimerLbl.Text = WarmUpTime
        WarmUpTimer.Enabled = False
        MatchMessages.Text = "Field Pre-Started"
        ResetPLC()

    End Sub

    Private Sub StartMatch_btn_Click(sender As Object, e As EventArgs) Handles StartMatch_btn.Click
        updateField(MatchEnums.WarmUp)
        WarmUpTimer.Start()
    End Sub

    Private Sub WarmUpTimer_Tick(sender As Object, e As EventArgs) Handles WarmUpTimer.Tick
        WarmUpTimer.Interval = 1000
        matchTimerLbl.Text = Val(matchTimerLbl.Text) - 1
        MatchMessages.Text = "Warm-Up"
        ScaleSwitch.Text = gamedatause



        If matchTimerLbl.Text = 0 Then
            updateField(MatchEnums.Auto)
            matchTimerLbl.Text = AutoTime
            WarmUpTimer.Stop()
            AutoTimer.Enabled = True
            AutoTimer.Start()
        End If
    End Sub

    Private Sub AutoTimer_Tick(sender As Object, e As EventArgs) Handles AutoTimer.Tick
        AutoTimer.Start()
        AutoTimer.Interval = 1000
        matchTimerLbl.Text = Val(matchTimerLbl.Text) - 1
        MatchMessages.Text = "Auto"


        If matchTimerLbl.Text = 0 Then
            updateField(MatchEnums.Pause)
            matchTimerLbl.Text = PauseTime
            AutoTimer.Stop()
            PauseTimer.Enabled = True
            PauseTimer.Start()
        End If
    End Sub

    Private Sub TeleTimer_Tick(sender As Object, e As EventArgs) Handles TeleTimer.Tick
        TeleTimer.Start()
        TeleTimer.Interval = 1000
        matchTimerLbl.Text = Val(matchTimerLbl.Text) - 1
        MatchMessages.Text = "Tele-Operated"


        If matchTimerLbl.Text = 30 Then
            updateField(MatchEnums.EndGame)

            matchTimerLbl.Text = EndgameTime
            TeleTimer.Stop()
            EndGameTimer.Enabled = True
            EndGameTimer.Start()
        End If
    End Sub

    Private Sub PauseTimer_Tick(sender As Object, e As EventArgs) Handles PauseTimer.Tick
        PauseTimer.Start()
        PauseTimer.Interval = 1000
        matchTimerLbl.Text = Val(matchTimerLbl.Text) - 1
        MatchMessages.Text = "Pause"


        If matchTimerLbl.Text = 0 Then
            updateField(MatchEnums.TeleOp)
            matchTimerLbl.Text = TeleTime
            PauseTimer.Stop()
            TeleTimer.Enabled = True
            TeleTimer.Start()
        End If
    End Sub

    Private Sub EndGameTimer_Tick(sender As Object, e As EventArgs) Handles EndGameTimer.Tick
        EndGameTimer.Start()
        EndGameTimer.Interval = 1000
        matchTimerLbl.Text = Val(matchTimerLbl.Text) - 1
        MatchMessages.Text = "EndGame"


        If matchTimerLbl.Text = 0 Then
            updateField(MatchEnums.PostMatch)
            EndGameTimer.Stop()
            ScaleSwitch.Text = ""
            ResetPLC()
        End If
    End Sub

    Private Sub AbortMatch_btn_Click(sender As Object, e As EventArgs) Handles AbortMatch_btn.Click
        HandleAbortedMatch()
        Field.updateField(MatchEnums.AbortMatch)
        MatchMessages.Text = "Match Aborted"
        matchTimerLbl.Text = 0
    End Sub


    Public Sub HandlePLC()
        Dim RB As Integer = 0
        Dim RF As Integer = 0
        Dim RL As Integer = 0
        Dim BB As Integer = 0
        Dim BF As Integer = 0
        Dim BL As Integer = 0
        Dim i As Integer = 0

        Do While (True)

            If PLC_Estop_Field = True Then
                ' HandleAbortedMatch()

            End If

            If PLC_Estop_Red1 = True Then
                Red1DS.Estop = True
            End If

            If PLC_Estop_Red2 = True Then
                Red2DS.Estop = True
            End If

            If PLC_Estop_Red3 = True Then
                Red3DS.Estop = True
            End If

            If PLC_Estop_Blue1 = True Then
                Blue1DS.Estop = True
            End If

            If PLC_Estop_Blue2 = True Then
                Blue2DS.Estop = True
            End If

            If PLC_Estop_Blue3 = True Then
                Blue3DS.Estop = True
            End If

            'Blue Boost'
            If PLC_Used_Boost_Blue = True And BB < 1 Then
                My.Computer.Audio.Play(My.Resources.match_boost, AudioPlayMode.Background)
                BB = BB + 1
            End If

            'Blue Force'
            If PLC_Used_Force_Blue = True And BF < 1 Then
                My.Computer.Audio.Play(My.Resources.match_force, AudioPlayMode.Background)
                BF = BF + 1
            End If

            'Blue Lev'
            If PLC_Used_Lev_Blue = True And BL < 1 Then
                My.Computer.Audio.Play(My.Resources.match_levitate, AudioPlayMode.Background)
                BL = BL + 1
            End If

            'Red Boost'
            If PLC_Used_Boost_Red = True And RB < 1 Then
                My.Computer.Audio.Play(My.Resources.match_boost, AudioPlayMode.Background)
                RB = RB + 1
            End If

            'Red Force'
            If PLC_Used_Force_Red = True And RF < 1 Then
                My.Computer.Audio.Play(My.Resources.match_force, AudioPlayMode.Background)
                RF = RF + 1
            End If

            'Red Lev'
            If PLC_Used_Lev_Red = True And RL < 1 Then
                My.Computer.Audio.Play(My.Resources.match_levitate, AudioPlayMode.Background)
                RL = RL + 1
            End If


        Loop


    End Sub


    Public Sub HandleAbortedMatch()
        Dim i As Integer = 0
        PLC_Estop_Red1 = True
        PLC_Estop_Red2 = True
        PLC_Estop_Red3 = True
        PLC_Estop_Blue1 = True
        PLC_Estop_Blue2 = True
        PLC_Estop_Blue3 = True
        updateField(MatchEnums.AbortMatch)
        Me.WarmUpTimer.Stop()
        Me.AutoTimer.Stop()
        Me.PauseTimer.Stop()
        Me.TeleTimer.Stop()
        Me.EndGameTimer.Stop()
        If i < 1 Then
            My.Computer.Audio.Play(My.Resources.fog_blast, AudioPlayMode.Background)
        End If
        DriverStation.Abort()
        PLCThread.Abort()
        '    LEDThread.Abort()
    End Sub

    Public Sub ResetPLC()
        PLC_Estop_Field = False
        PLC_Estop_Red1 = False
        PLC_Estop_Red2 = False
        PLC_Estop_Red3 = False
        PLC_Estop_Blue1 = False
        PLC_Estop_Blue2 = False
        PLC_Estop_Blue3 = False
        PLC_Used_Force_Red = False
        PLC_Used_Lev_Blue = False
        PLC_Used_Lev_Red = False
        PLC_Used_Force_Blue = False
        PLC_Used_Boost_Blue = False
        PLC_Used_Boost_Red = False
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
        ' SetMode(LightingModes.Test)
    End Sub

    Private Sub ConnectLedsBtn_Click(sender As Object, e As EventArgs) 
        MainLighting()
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

End Class