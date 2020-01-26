Imports System.Net
Imports System.Threading

Public Class FCUI

    Private Sub FCUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        roundCorners(RedTeamPanel)
        roundCorners(BlueTeamPanel)
        roundCorners(Blue1EstopBtn)
        roundCorners(Blue2EstopBtn)
        roundCorners(Blue3EstopBtn)

        BlueTeamInd.FillColor = Color.LimeGreen
        BlueTeamIndLabel.BackColor = Color.LimeGreen

        RedTeamInd.FillColor = Color.LimeGreen
        RedTeamIndLabel.BackColor = Color.LimeGreen
    End Sub

    Public Sub roundCorners(thingy As Object)
        Dim ellipseRadius As New Drawing2D.GraphicsPath
        ellipseRadius.StartFigure()
        ellipseRadius.AddArc(New Rectangle(0, 0, 20, 20), 180, 90)
        ellipseRadius.AddLine(20, 0, thingy.Width - 20, 0)
        ellipseRadius.AddArc(New Rectangle(thingy.Width - 20, 0, 20, 20), -90, 90)
        ellipseRadius.AddLine(thingy.Width, 20, thingy.Width, thingy.Height - 20)
        ellipseRadius.AddArc(New Rectangle(thingy.Width - 20, thingy.Height - 20, 20, 20), 0, 90)
        ellipseRadius.AddLine(thingy.Width - 20, thingy.Height, 20, thingy.Height)
        ellipseRadius.AddArc(New Rectangle(0, thingy.Height - 20, 20, 20), 90, 90)
        ellipseRadius.CloseFigure()
        thingy.Region = New Region(ellipseRadius)
    End Sub
End Class