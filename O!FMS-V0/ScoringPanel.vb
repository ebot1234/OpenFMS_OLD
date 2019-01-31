Public Class ScoringPanel
    Public score As Integer = 0

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
        score = score + 2
        Main_Panel.Label23.Text = score
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Add Ranking Points stuff
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        score = score + 2
        Main_Panel.Label23.Text = score
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        score = score + 3
        Main_Panel.Label23.Text = score
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        score = score + 3
        Main_Panel.Label23.Text = score
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        score = score + 6
        Main_Panel.Label23.Text = score
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        score = score + 12
        Main_Panel.Label23.Text = score
    End Sub
End Class