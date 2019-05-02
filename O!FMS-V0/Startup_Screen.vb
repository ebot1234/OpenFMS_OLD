

Public Class Startup_Screen

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TeamAdder.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Main_Panel.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Main_Panel.Show()
        'Add the main panel switching to elim mode'
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AudianceDisplay.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Add alliance maker'
    End Sub
End Class