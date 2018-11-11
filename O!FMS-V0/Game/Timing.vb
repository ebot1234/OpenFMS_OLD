Public Class Timing
    '3 sec'
    Public Shared WarmupDurationSec As Integer = 3000
    '15 sec'
    Public Shared AutoDurationSec As Integer = 15000
    '2 sec'
    Public Shared PauseDurationSec As Integer = 2000
    '1min 15 sec'
    Public Shared TeleopDurationSec As Integer = 105000
    '30 sec'
    Public Shared EndgameTimeLeftSec As Integer = 30000

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
