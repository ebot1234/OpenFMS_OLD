
Public Class AudianceDisplay

    Private Sub AudianceDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CenterToScreen()
        Me.FormBorderStyle = Windows.Forms.BorderStyle.FixedSingle
        Me.WindowState = FormWindowState.Maximized
        RedScoreLbl.Text = 0
        BlueScoreLbl.Text = 0
    End Sub
End Class