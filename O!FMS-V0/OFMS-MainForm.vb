Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Sockets
Imports System.Timers
Imports System.Math
Imports O_FMS_V0.PLC_Comms_Server
Imports O_FMS_V0.RandomString
Imports O_FMS_V0.Team_Networks




Public Class Form1




    Dim connection As New SqlConnection("data source=127.0.0.1\sqlexpress; Initial Catalog=O!FMS; Integrated Security = true")
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the '_O_FMSDataSet.FMSMaster' table. You can move, or remove it, as needed.
        Timer1.Interval = 1000 '1 seconds
        Timer1.Enabled = True
        'Timer1.AutoReset = True
        Me.FMSMasterTableAdapter.Fill(Me._O_FMSDataSet.FMSMaster)

    End Sub

    

    Private Sub BindingSource1_CurrentChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Save_btn.Click
        Dim insertquery As String = "INSERT INTO FMSMaster([Match], [MatchTime], [Blue1], [Blue1DQ], [Blue1Volt], [Blue1Estop], [Blue1RL], [Blue1DS], [Blue1Bypass], [Blue2], [Blue2DQ], [Blue2Volt], [Blue2Estop], [Blue2RL], [Blue2DS], [Blue2Bypass], [Blue3], [Blue3DQ], [Blue3Volt], [Blue3Estop], [Blue3RL], [Blue3DS], [Blue3Bypass], [Red1], [Red1DQ], [Red1Volt], [Red1Estop], [Red1RL], [Red1DS], [Red1Bypass], [Red2], [Red2DQ], [Red2Volt], [Red2Estop], [Red2RL], [Red2DS], [Red2Bypass], [Red3], [Red3DQ], [Red3Volt], [Red3Estop], [Red3RL], [Red3DS], [Red3Bypass], [Bluescore], [bluepen], [BlueForce], [BlueLevitate], [BlueBoost], [Redscore], [redpen], [RedForce], [RedLevitate], [RedBoost], [SwitchScale]) VALUES('" & MatchNum.Text & "', '" & Ctime.Text & "', '" & BlueTeam1.Text & "', '" & BDQ1.Checked & "', '" & BlueVolt1.Text & "','""' ,'""' , '""', '" & BBypass1.Checked & "', '" & BlueTeam2.Text & "', '" & BDQ2.Checked & "', '" & BlueVolt2.Text & "', '""','""' ,'""' , '" & BBypass2.Checked & "', '" & BlueTeam3.Text & "', '" & BDQ3.Checked & "', '" & BlueVolt3.Text & "','""' , '""', '""', '" & BBypass3.Checked & "', '" & RedTeam1.Text & "', '" & RDQ1.Checked & "', '" & RedVolt1.Text & "', '""', '""', '""', '" & RBypass1.Checked & "', '" & RedTeam2.Text & "', '" & RDQ2.Checked & "', '" & RedVolt2.Text & "', '""', '""','""' , '" & RBypass2.Checked & "', '" & RedTeam3.Text & "', '" & RDQ3.Checked & "', '" & RedVolt3.Text & "','""' ,'""' ,'""' , '" & RBypass3.Checked & "', '" & BlueScore.Text & "', '" & BluePen.Text & "','""' , '""','""' , '" & RedScore.Text & "', '" & RedPen.Text & "','""' , '""','""' , '" & ScaleSwitch.Text & "')"

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

        Dim selectQuery As New SqlCommand("Select Blue1, Blue2, Blue3, Red1, Red2, Red3 FROM MatchList where Match= @Matchnum", connection)
        selectQuery.Parameters.Add("@Matchnum", SqlDbType.Int).Value = MatchNum.Text
        Dim adapter As New SqlDataAdapter(selectQuery)
        Dim table As New DataTable()
        adapter.Fill(table)
        If table.Rows.Count() > 0 Then
            RedTeam1.Text = table.Rows(0)(3).ToString()
            RedTeam2.Text = table.Rows(0)(4).ToString()
            RedTeam3.Text = table.Rows(0)(5).ToString()
            BlueTeam1.Text = table.Rows(0)(0).ToString()
            BlueTeam2.Text = table.Rows(0)(1).ToString()
            BlueTeam3.Text = table.Rows(0)(2).ToString()


            MessageBox.Show("Data Loaded")
        Else
            MessageBox.Show("Not Loaded")
        End If
        game_data_main(gamedataUse)
        ScaleSwitch.Text = gamedataUse

    End Sub

    Private Sub RDQ1_CheckedChanged(sender As Object, e As EventArgs) Handles RDQ1.CheckedChanged
        If PLC_Estop_Red1 = False Then
            PLC_Estop_Red1 = True
        Else : PLC_Estop_Red1 = True
        End If
    End Sub

    Private Sub Ctime_Click(sender As Object, e As EventArgs) Handles Ctime.Click

    End Sub
    Private WithEvents Timer1 As New System.Windows.Forms.Timer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles  Timer1.Tick

        Ctime.Text = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        PLCTimer.Text = PLC_Match_Timer
        RPLC_Score.Text = PLC_RedScore
        BPLC_Score.Text = PLC_BlueScore

        'Red Power-Ups
        If PLC_Used_Boost_Red = True Then
            RBoost.FillColor = Color.LimeGreen
        Else : RBoost.FillColor = Color.Gray
        End If
        If PLC_Used_Force_Red = True Then
            RForce.FillColor = Color.LimeGreen
        Else : RForce.FillColor = Color.Gray
        End If
        If PLC_Used_Lev_Red = True Then
            RLev.FillColor = Color.LimeGreen
        Else : RLev.FillColor = Color.Gray
        End If

        'Blue Power-Ups
        If PLC_Used_Boost_Blue = True Then
            BBoost.FillColor = Color.LimeGreen
        Else : BBoost.FillColor = Color.Gray
        End If
        If PLC_Used_Force_Blue = True Then
            BForce.FillColor = Color.LimeGreen
        Else : BForce.FillColor = Color.Gray
        End If
        If PLC_Used_Lev_Blue = True Then
            BLev.FillColor = Color.LimeGreen
        Else : BLev.FillColor = Color.Gray
        End If

        'Estops
        If PLC_Estop_Red1 = True Then
            R1Estop.FillColor = Color.LimeGreen
        Else : R1Estop.FillColor = Color.Gray
        End If
        If PLC_Estop_Red2 = True Then
            R2Estop.FillColor = Color.LimeGreen
        Else : R2Estop.FillColor = Color.Gray
        End If
        If PLC_Estop_Red3 = True Then
            R3Estop.FillColor = Color.LimeGreen
        Else : R3Estop.FillColor = Color.Gray
        End If

        If PLC_Estop_Blue1 = True Then
            B1Estop.FillColor = Color.LimeGreen
        Else : B1Estop.FillColor = Color.Gray
        End If
        If PLC_Estop_Blue2 = True Then
            B2Estop.FillColor = Color.LimeGreen
        Else : B2Estop.FillColor = Color.Gray
        End If
        If PLC_Estop_Blue3 = True Then
            B3Estop.FillColor = Color.LimeGreen
        Else : B3Estop.FillColor = Color.Gray
        End If

        'Driver Stations (DS) Linked
        If DS_Linked_Red1 Then
            R1DS.FillColor = Color.LimeGreen
        Else : R1DS.FillColor = Color.Gray
        End If
        If DS_Linked_Red2 Then
            R2DS.FillColor = Color.LimeGreen
        Else : R2DS.FillColor = Color.Gray
        End If
        If DS_Linked_Red3 Then
            R3DS.FillColor = Color.LimeGreen
        Else : R3DS.FillColor = Color.Gray
        End If

        If DS_Linked_Blue1 Then
            B1DS.FillColor = Color.LimeGreen
        Else : B1DS.FillColor = Color.Gray
        End If
        If DS_Linked_Blue2 Then
            B2DS.FillColor = Color.LimeGreen
        Else : B2DS.FillColor = Color.Gray
        End If
        If DS_Linked_Blue3 Then
            B3DS.FillColor = Color.LimeGreen
        Else : B3DS.FillColor = Color.Gray
        End If

        'Robot Linked
        If Robot_Linked_Red1 = True Then
            R1Robot.FillColor = Color.LimeGreen
        Else : R1Robot.FillColor = Color.Gray
        End If
        If Robot_Linked_Red2 = True Then
            R2Robot.FillColor = Color.LimeGreen
        Else : R2Robot.FillColor = Color.Gray
        End If
        If Robot_Linked_Red3 = True Then
            R3Robot.FillColor = Color.LimeGreen
        Else : R3Robot.FillColor = Color.Gray
        End If

        If Robot_Linked_Blue1 = True Then
            B1Robot.FillColor = Color.LimeGreen
        Else : B1Robot.FillColor = Color.Gray
        End If
        If Robot_Linked_Blue2 = True Then
            B2Robot.FillColor = Color.LimeGreen
        Else : B2Robot.FillColor = Color.Gray
        End If
        If Robot_Linked_Blue3 = True Then
            B3Robot.FillColor = Color.LimeGreen
        Else : B3Robot.FillColor = Color.Gray
        End If

        'Score & Penalty Calculations
        If RedPen.Text <> Nothing Then
            RedScore.Text = (RPLC_Score.Text - RedPen.Text)
        Else : RedScore = RPLC_Score
        End If
        If BluePen.Text <> Nothing Then
            BlueScore.Text = (BPLC_Score.Text - BluePen.Text)
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
    End Sub

    Private Sub OnTimedEvent(source As Object, e As System.Timers.ElapsedEventArgs)

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

    
    Private Sub AxOPCWareGroup1_ItemUpdate(sender As Object, e As AxOPCWareAX.__OPCWareGroup_ItemUpdateEvent)

    End Sub
End Class

