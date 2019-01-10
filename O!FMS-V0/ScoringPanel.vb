Public Class ScoringPanel
    Dim score As Integer = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        score = score + 3
        Main_Panel.Label23.Text = score
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        score = score + 6
        Main_Panel.Label23.Text = score
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        score = score + 3
        Main_Panel.Label23.Text = score
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        score = score + 3
        Main_Panel.Label23.Text = score
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        score = score + 20
        Main_Panel.Label23.Text = score
    End Sub
End Class