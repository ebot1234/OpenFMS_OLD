Imports Microsoft.VisualBasic

Public Class Modes

    Public Mode As String

    Public offMode As String

    Public RedMode As String

    Public GreenMode As String

    Public BlueMode As String

    Public WhiteMode As String

    Public ChaseMode As String

    Public WarmupMode As String

    Public Warmup2Mode As String

    Private Warmup3Mode As String

    Public Warmup4Mode As String

    Public OwnedMode As String

    Public NotOwnedMode As String

    Public ForceMode As String

    Public BoostMode As String

    Public RandomMode As String

    Public FadeMode As String

    Public GradientMode As String

    Public BlinkMode As String

    Public Sub ModeNames()
        offMode = "Off"
        RedMode = "Red"
        GreenMode = "Green"
        BlueMode = "Blue"
        WhiteMode = "White"
        ChaseMode = "Chase"
        WarmupMode = "Warmup"
        Warmup2Mode = "Warmup Purple"
        Warmup3Mode = "Warmup Sneaky"
        Warmup4Mode = "Warmup Gradient"
        OwnedMode = "Owned"
        NotOwnedMode = "Not Owned"
        ForceMode = "Force"
        BoostMode = "Boost"
        RandomMode = "Random"
        FadeMode = "Fade"
        GradientMode = "Gradient"
        BlinkMode = "Blink"
    End Sub
End Class
