﻿

Public Class Startup_Screen

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Main_Panel.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AudianceDisplay.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Main_Panel.Show()
        AudianceDisplay.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub
End Class