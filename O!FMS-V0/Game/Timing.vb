Public Class Timing
    Public Shared WarmupDurationSec As Integer = 3
    Public Shared AutoDurationSec As Integer = 15
    Public Shared PauseDurationSec As Integer = 2
    Public Shared TeleopDurationSec As Integer = 135
    Public Shared EndgameTimeLeftSec As Integer = 30

    Public Function GetAutoEndTime(matchStartTime As Date)
        Return matchStartTime.AddSeconds(WarmupDurationSec + AutoDurationSec)
    End Function

    Public Function GetTeleopStartTime(matchStartTime As Date)
        Return matchStartTime.AddSeconds(WarmupDurationSec + AutoDurationSec + PauseDurationSec)
    End Function

    Public Function GetMatchEndTime(matchStartTime As Date)
        Return matchStartTime.AddSeconds(WarmupDurationSec + AutoDurationSec + PauseDurationSec + TeleopDurationSec)
    End Function
End Class