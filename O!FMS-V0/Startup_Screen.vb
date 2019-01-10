

Public Class Startup_Screen

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Main_Panel.Show()
        ScoringPanel.Show()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AudianceDisplay.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Main_Panel.Show()
        AudianceDisplay.Show()
        'Utilities.Show()
        'Match_Generator.Show()
        ScoringPanel.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Match_Generator.Show()
    End Sub

    Private Sub Startup_Screen_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub
End Class