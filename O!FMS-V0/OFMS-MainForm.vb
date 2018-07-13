Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Sockets
Imports System.Timers



Public Class Form1



    Dim connection As New SqlConnection("data source=miyuki\sqlexpress; Initial Catalog=O!FMS; Integrated Security = true")
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the '_O_FMSDataSet.FMSMaster' table. You can move, or remove it, as needed.
        Timer1.Interval = 1000 '1 seconds
        Timer1.Enabled = True
        'Timer1.AutoReset = True
        Me.FMSMasterTableAdapter.Fill(Me._O_FMSDataSet.FMSMaster)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles RedTeam1.Click

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

    Private Sub MatchLoad_Btn_Click(sender As Object, e As EventArgs) Handles MatchLoad_Btn.Click
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

    End Sub

    Private Sub RDQ1_CheckedChanged(sender As Object, e As EventArgs) Handles RDQ1.CheckedChanged

    End Sub

    Private Sub Ctime_Click(sender As Object, e As EventArgs) Handles Ctime.Click

    End Sub
    Private WithEvents Timer1 As New System.Windows.Forms.Timer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles  Timer1.Tick

        Ctime.Text = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
    End Sub

    Private Sub OnTimedEvent(source As Object, e As System.Timers.ElapsedEventArgs)

    End Sub

    Private Sub R1Estop_Click(sender As Object, e As EventArgs) Handles R1Estop.Click

    End Sub
End Class

