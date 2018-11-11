
Public Class AudianceDisplay

    Private Sub AudianceDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CenterToScreen()
        Me.FormBorderStyle = Windows.Forms.BorderStyle.FixedSingle
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class