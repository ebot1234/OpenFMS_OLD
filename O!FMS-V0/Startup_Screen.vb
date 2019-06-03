Imports O_FMS_V0.Main_Panel
Imports O_FMS_V0.Tba

Public Class Startup_Screen

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'SQLChooser.show()
        TeamAdder.Show()
        'populateMatchBreakdown()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Main_Panel.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Main_Panel.Show()
        ElimMode = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AudianceDisplay.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        AllianceMaker.Show()
    End Sub
End Class