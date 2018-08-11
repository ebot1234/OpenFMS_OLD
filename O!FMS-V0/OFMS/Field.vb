Imports System.Single
Imports O_FMS_V0.Controller
Imports O_FMS_V0.DriverStations
Imports System.Globalization
Imports O_FMS_V0.Timing



Public Class Field
    Dim teamIdRed1 As Integer
    Dim teamIdRed2 As Integer
    Dim teamIdRed3 As Integer
    Dim teamIdBlue1 As Integer
    Dim teamIdBlue2 As Integer
    Dim teamIdBlue3 As Integer
    Dim rED1 As String
    Public Red1Conn = Red1Conn
    Public Red2Conn = Red2Conn
    Public Red3Conn = Red3Conn
    Public Blue1Conn = Blue1Conn
    Public Blue2Conn = Blue2Conn
    Public Blue3Conn = Blue3Conn
    Public red1 As String = Main_Panel.RedTeam1.Text = teamIdRed1
    Public red2 As String = Main_Panel.RedTeam2.Text = teamIdRed2
    Public red3 As String = Main_Panel.RedTeam3.Text = teamIdRed3
    Public blue1 As String = Main_Panel.BlueTeam1.Text = teamIdBlue1
    Public blue2 As String = Main_Panel.BlueTeam2.Text = teamIdBlue2
    Public blue3 As String = Main_Panel.BlueTeam3.Text = teamIdBlue3
    Public auto As DriverStations
    Public enabled As DriverStations
    Public updateDs As DriverStations
    Dim arenaLoopPeriodMs As Integer = 10
    Dim dsPacketPeriodMs As Integer = 250
    Dim matchEndScoreDwellSec As Integer = 3
    Public matchState As Integer
    Public PreMatch = matchState + 1
    Public StartMatch = matchState + 1
    Public WarmupPeriod = matchState + 1
    Public AutoPeriod = matchState + 1
    Public PausePeriod = matchState + 1
    Public TelePeriod = matchState + 1
    Public EndGamePeriod = matchState + 1
    Public PostMatch = matchState + 1
    Public AccessPoint
    Public NetworkSwitch As Team_Networks
    Public lastMatchState = matchState
    Public Shared MatchStartTime
    Public LastMatchTime As Integer
    Dim LastDsPacketTime As Timer
    Public FieldVolunteers As Boolean
    Public FieldReset As Boolean
    Public AudienceDisplay As String
    Public matchAborted As Boolean
    Public lastRedAllianceReady As Boolean
    Public lastBlueAllianceReady As Boolean
    Public CanStartMatch As Boolean
    Public PlcIsReady As Boolean
    Public FieldEstop As Boolean
    Public GameSpecificData As RandomString
    Public Dsconn As DriverStations
    Public Astop As Boolean
    Public Estop As Boolean
    Public Bypass As Boolean
    Public AllianceStations As String
    Public currentMatch As Match
    Public controller = New Controller
    Public plc As PLC_Comms_Server

    Public Function NewField(err As ErrObject)
        Dim field As New Field
        'resets the alliance Stations'
        field.AllianceStations = "R1"
        field.AllianceStations = "R2"
        field.AllianceStations = "R3"
        field.AllianceStations = "B1"
        field.AllianceStations = "B2"
        field.AllianceStations = "B3"
        'Loads an empty match as current match'
        field.matchState = PreMatch
        field.LoadTestMatch()
        field.lastMatchState = -1
        field.LastMatchTime = 0
        Return field
    End Function

    Public Function LoadMatch(match As Match, field As Field)
        If matchState > PreMatch Then
            Console.WriteLine("Cannot Load Settind in the middle of a match!!!")
        End If
        field.currentMatch = match
        Try
            field.assignTeam(match.rED1)
        Catch ex As Exception
            Console.WriteLine("can't assign team red 1")
        End Try
        Try
            field.assignTeam(match.Red2, "R2")
        Catch ex As Exception
            Console.WriteLine("can't assign team red 2 ")
        End Try
        Try
            field.assignTeam(match.Red3, "R3")
        Catch ex As Exception
            Console.WriteLine("can't assign team red 3")
        End Try
        Try
            field.assignTeam(match.Blue1, "B1")
        Catch ex As Exception
            Console.WriteLine("can't assign team blue 1")
        End Try
        Try
            field.assignTeam(match.Blue2, "B2")
        Catch ex As Exception
            Console.WriteLine("can't assign team blue 2")
        End Try
        Try
            field.assignTeam(match.Blue3, "B3")
        Catch ex As Exception
            Console.WriteLine("can't assign team blue 3")
        End Try

        field.setupNetwork()

        field.FieldVolunteers = False
        field.FieldReset = False
        controller.ScaleLeds.setSideness(True)
        'add the leds'

    End Function

    Public Function setupNetwork()

    End Function

    Public Function update(field As Field, driverStations As DriverStations, controller As Controller, strip As Strip, color As Colors, colors As Colors)

        driverStations.Auto = False
        driverStations.Enabled = False
        Dim matchTimeSec = field.MatchTimeSec()

        Select Case (field.matchState)
            Case PreMatch
                driverStations.Auto = True
                driverStations.Enabled = False
            Case StartMatch
                field.matchState = WarmupPeriod
                Field.MatchStartTime = DateAndTime.Now()
                field.LastMatchTime = -1
                driverStations.Auto = True
                driverStations.Enabled = False
                driverStations.sendGameData()
                My.Computer.Audio.Play(".../OFMS\O!FMS-V0\OFMS\Images\Resources\Sounds\MATCH_WARMUP.wav", AudioPlayMode.WaitToComplete)
                controller.updateWarmUpMode(controller, strip, colors, color)
            Case WarmupPeriod
                driverStations.Auto = True
                driverStations.Enabled = False
                If matchTimeSec >= Timing.WarmupDurationSec Then
                    field.matchState = AutoPeriod
                    driverStations.Auto = True
                    driverStations.Enabled = True
                    My.Computer.Audio.Play(".../OFMS\O!FMS-V0\OFMS\Images\Resources\Sounds\CHARGE.wav", AudioPlayMode.WaitToComplete)
                End If
            Case AutoPeriod
                driverStations.Auto = True
                driverStations.Enabled = True
                If matchTimeSec >= Timing.WarmupDurationSec + Timing.AutoDurationSec Then
                    field.matchState = PausePeriod
                    driverStations.Auto = False
                    driverStations.Enabled = False
                    My.Computer.Audio.Play(".../OFMS\O!FMS-V0\OFMS\Images\Resources\Sounds\ENDMATCH.wav", AudioPlayMode.WaitToComplete)
                End If
            Case PausePeriod
                driverStations.Auto = False
                driverStations.Enabled = False
                If matchTimeSec >= WarmupDurationSec + AutoDurationSec + PauseDurationSec Then
                    field.matchState = TelePeriod
                    driverStations.Auto = False
                    driverStations.Enabled = True
                    My.Computer.Audio.Play(".../OFMS\O!FMS-V0\OFMS\Images\Resources\Sounds\3BELLS.wav", AudioPlayMode.WaitToComplete)
                End If
            Case TelePeriod
                driverStations.Auto = False
                driverStations.Enabled = True
                If matchTimeSec >= WarmupDurationSec + AutoDurationSec + PauseDurationSec + TeleopDurationSec - EndgameTimeLeftSec Then
                    field.matchState = EndGamePeriod
                    My.Computer.Audio.Play(".../OFMS\O!FMS-V0\OFMS\Images\Resources\Sounds\ENDGAME.wav", AudioPlayMode.WaitToComplete)
                End If
            Case EndGamePeriod
                driverStations.Auto = False
                driverStations.Enabled = True
                driverStations.sendPacketDS(field)
                Threading.Thread.Sleep(matchEndScoreDwellSec)
                My.Computer.Audio.Play(".../OFMS\O!FMS-V0\OFMS\Images\Resources\Sounds\ENDMATCH.wav")
        End Select

        Return 0
    End Function

    Public Function Run(DS As DriverStations, field As Field, driverStations As DriverStations, controller As Controller, strip As Strip, color As Colors, colors As Colors)
        DS.Connect()
        DS.sendPacketDS(field)

        For i As Integer = i To i
        Next
        field.update(field, driverStations, controller, strip, color, colors)
        Threading.Thread.Sleep(arenaLoopPeriodMs)
        Return 0
    End Function

    Public Function assignTeam(Red)
        If Red1Conn = teamIdRed1 Then
            Red1Conn = red1
        End If

    End Function

End Class