Imports O_FMS_V0.PLC_Comms_Server
Imports O_FMS_V0.RandomString
Imports O_FMS_V0.Team_Networks
Imports O_FMS_V0.Lighting
Imports System.Threading
Imports System.Net

Public Class Field
    'PLC Field Types'
    Public Shared FieldReset As Boolean
    Public Shared Volunteers As Boolean
    'Driver Station instances'
    Public Shared Red1DS As New DriverStations
    Public Shared Red2DS As New DriverStations
    Public Shared Red3DS As New DriverStations
    Public Shared Blue1DS As New DriverStations
    Public Shared Blue2DS As New DriverStations
    Public Shared Blue3DS As New DriverStations
    'Led Controllers'
    Public Shared ScaleLeds As New Lighting
    Public Shared RedSwitchLeds As New Lighting
    Public Shared BlueSwitchLeds As New Lighting
    '2018 timing'
    Public Shared WarmUpTime As Integer = 4
    Public Shared AutoTime As Integer = 15
    Public Shared PauseTime As Integer = 3
    Public Shared TeleTime As Integer = 135
    Public Shared EndgameTime As Integer = 30
    Public Shared GameTime As Integer = 0

    Public Shared fieldStatus
    'Match Type enums'
    Public Enum MatchEnums
        PreMatch
        WarmUp
        Auto
        Pause
        TeleOp
        EndGame
        PostMatch
        AbortMatch
    End Enum


    Public Shared Sub HandleDSConnections()
        'Starts the TCP connection threads for finding driver stations'
        Red1DS.ListenToDS()
        'Pings and starts control for the driver station'
        ' Red1DS.newDriverStationConnection(Main_Panel.RedTeam1.Text, 0)
    End Sub

    Public Shared Sub DisposeDS()
        Red1DS.Dispose()
        Red2DS.Dispose()
        Red3DS.Dispose()
        Blue1DS.Dispose()
        Blue2DS.Dispose()
        Blue3DS.Dispose()

    End Sub

    Public Shared Sub handleSwitchLeds()
        Dim pre As Integer = 0
        Dim warm As Integer = 0
        Dim status As Boolean = False
        Do While (True)
            If fieldStatus = MatchEnums.PreMatch Then
                If pre < 1 Then
                    setMode("G")
                    status = False
                    pre = pre + 1
                End If

            ElseIf fieldStatus = MatchEnums.WarmUp Then
                If warm < 1 Then
                    setMode(gamedatause)
                    warm = warm + 1
                    status = True
                End If
            End If



            If status = True Then
                If PLC_BlueScaleOwned = True Then
                    sendClear()
                    setMode("B")
                ElseIf PLC_RedScaleOwned = True Then
                    sendClear()
                    setMode("R")
                ElseIf PLC_RedScaleOwned = False And PLC_BlueScaleOwned = False Then
                    sendClear()
                    setMode("N")
                End If

            End If



        Loop
    End Sub


    Public Shared Function SendDS(Auto As Boolean, Enabled As Boolean)
        If Auto = True Then
            Red1DS.Auto = True
            Red2DS.Auto = True
            Red3DS.Auto = True
            Blue1DS.Auto = True
            Blue2DS.Auto = True
            Blue3DS.Auto = True

            ' Red1DS.sendPacketDS(0)
            ' Red2DS.sendPacketDS(1)
            ' Red3DS.sendPacketDS(2)
            ' Blue1DS.sendPacketDS(3)
            ' Blue2DS.sendPacketDS(4)
            ' Blue3DS.sendPacketDS(5)

        Else
            Red1DS.Auto = False
            Red2DS.Auto = False
            Red3DS.Auto = False
            Blue1DS.Auto = False
            Blue2DS.Auto = False
            Blue3DS.Auto = False

            ' Red1DS.sendPacketDS(0)
            ' Red2DS.sendPacketDS(1)
            ' Red3DS.sendPacketDS(2)
            ' Blue1DS.sendPacketDS(3)
            ' Blue2DS.sendPacketDS(4)
            ' Blue3DS.sendPacketDS(5)
        End If

        If Enabled = True Then
            Red1DS.Enabled = True
            Red2DS.Enabled = True
            Red3DS.Enabled = True
            Blue1DS.Enabled = True
            Blue2DS.Enabled = True
            Blue3DS.Enabled = True

            ' Red1DS.sendPacketDS(0)
            ' Red2DS.sendPacketDS(1)
            ' Red3DS.sendPacketDS(2)
            ' Blue1DS.sendPacketDS(3)
            ' Blue2DS.sendPacketDS(4)
            ' Blue3DS.sendPacketDS(5)
        Else
            Red1DS.Enabled = False
            Red2DS.Enabled = False
            Red3DS.Enabled = False
            Blue1DS.Enabled = False
            Blue2DS.Enabled = False
            Blue3DS.Enabled = False

            ' Red1DS.sendPacketDS(0)
            ' Red2DS.sendPacketDS(1)
            ' Red3DS.sendPacketDS(2)
            ' Blue1DS.sendPacketDS(3)
            ' Blue2DS.sendPacketDS(4)
            ' Blue3DS.sendPacketDS(5)
        End If
        Return 0
    End Function

    Public Shared Sub updateField(MatchEnums As MatchEnums)
        Select Case (MatchEnums)

            Case MatchEnums.PreMatch
                My.Computer.Audio.Play(My.Resources.match_force, AudioPlayMode.Background)
                PLC_Reset = True
                Match_PreStart = True
                fieldStatus = MatchEnums.PreMatch
                SendDS(Auto:=True, Enabled:=False)
            Case MatchEnums.WarmUp
                SendDS(Auto:=True, Enabled:=False)
                GameDataGen()
                Match_Start = True
                fieldStatus = MatchEnums.WarmUp
                SendDS(Auto:=True, Enabled:=False)
                My.Computer.Audio.Play(My.Resources.match_warmup, AudioPlayMode.Background)
            Case MatchEnums.Auto
                fieldStatus = MatchEnums.Auto
                SendDS(Auto:=True, Enabled:=True)
                My.Computer.Audio.Play(My.Resources.match_start, AudioPlayMode.Background)
            Case MatchEnums.Pause
                fieldStatus = MatchEnums.Pause
                SendDS(Auto:=False, Enabled:=False)
                My.Computer.Audio.Play(My.Resources.match_end, AudioPlayMode.Background)
            Case MatchEnums.TeleOp
                fieldStatus = MatchEnums.TeleOp
                SendDS(Auto:=False, Enabled:=True)
                My.Computer.Audio.Play(My.Resources.match_resume, AudioPlayMode.Background)
            Case MatchEnums.EndGame
                fieldStatus = MatchEnums.EndGame
                SendDS(Auto:=False, Enabled:=True)
                My.Computer.Audio.Play(My.Resources.match_endgame, AudioPlayMode.Background)
            Case MatchEnums.PostMatch
                fieldStatus = MatchEnums.PostMatch
                SendDS(Auto:=False, Enabled:=False)
                My.Computer.Audio.Play(My.Resources.match_end, AudioPlayMode.Background)
                Match_Stop = True
                DisposeDS()
            Case MatchEnums.AbortMatch
                fieldStatus = MatchEnums.AbortMatch
                SendDS(Auto:=False, Enabled:=False)
                Match_Stop = True
                Thread.Sleep(50)
                DisposeDS()
            Case Else
                MatchEnums = MatchEnums.PreMatch
        End Select
    End Sub


End Class
