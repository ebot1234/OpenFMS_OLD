
Public Class AudianceDisplay

    Private Sub AudianceDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CenterToScreen()
        'Change this for a release version' 
        Me.FormBorderStyle = Windows.Forms.BorderStyle.FixedSingle
        Me.WindowState = FormWindowState.Maximized
        RedScoreLbl.Text = 0
        BlueScoreLbl.Text = 0
        PrestartCover.Hide()
        PreStartPanel.Hide()
        Winner.Hide()
        WinningAlliance.Hide()
    End Sub
End Class