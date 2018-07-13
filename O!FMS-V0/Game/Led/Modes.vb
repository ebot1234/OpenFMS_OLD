Imports Microsoft.VisualBasic

Public Class Modes

    Private Mode As String

    Private offMode As String = Me.Mode

    Private RedMode As String = Me.Mode

    Private GreenMode As String = Me.Mode

    Private BlueMode As String = Me.Mode

    Private WhiteMode As String = Me.Mode

    Private ChaseMode As String = Me.Mode

    Private WarmupMode As String = Me.Mode

    Private Warmup2Mode As String = Me.Mode

    Private Warmup3Mode As String = Me.Mode

    Private Warmup4Mode As String = Me.Mode

    Private OwnedMode As String = Me.Mode

    Private NotOwnedMode As String = Me.Mode

    Private ForceMode As String = Me.Mode

    Private BoostMode As String = Me.Mode

    Private RandomMode As String = Me.Mode

    Private FadeMode As String = Me.Mode

    Private GradientMode As String = Me.Mode

    Private BlinkMode As String = Me.Mode

    Public Sub modeNames()
        Me.offMode = "Off"
        Me.RedMode = "Red"
        Me.GreenMode = "Green"
        Me.BlueMode = "Blue"
        Me.WhiteMode = "White"
        Me.ChaseMode = "Chase"
        Me.WarmupMode = "Warmup"
        Me.Warmup2Mode = "Warmup Purple"
        Me.Warmup3Mode = "Warmup Sneaky"
        Me.Warmup4Mode = "Warmup Gradient"
        Me.OwnedMode = "Owned"
        Me.NotOwnedMode = "Not Owned"
        Me.ForceMode = "Force"
        Me.BoostMode = "Boost"
        Me.RandomMode = "Random"
        Me.FadeMode = "Fade"
        Me.GradientMode = "Gradient"
        Me.BlinkMode = "Blink"
    End Sub
End Class
