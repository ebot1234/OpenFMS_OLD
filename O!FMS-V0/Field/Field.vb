Imports O_FMS_V0.PLC_Handler
Imports O_FMS_V0.RandomString
Imports O_FMS_V0.Main_Panel
Imports System.Threading
Imports O_FMS_V0.DriverStation



Public Class Field
    Public Shared status As Boolean = False
    Public Shared sandstorm As Boolean = False
    'PLC Field Types'
    Public Shared FieldReset As Boolean
    Public Shared Volunteers As Boolean
    'Driver Station instances'
    Public Shared Red1DS As New DriverStation
    Public Shared Red2DS As New DriverStation
    Public Shared Red3DS As New DriverStation
    Public Shared Blue1DS As New DriverStation
    Public Shared Blue2DS As New DriverStation
    Public Shared Blue3DS As New DriverStation
    '2019 timing'
    Public Shared SandStormTime As Integer = 15
    Public Shared TeleTime As Integer = 135
    Public Shared EndgameWarningTime As Integer = 30
    Public Shared EndGameTime As Integer = 20
    Public Shared GameTime As Integer = 0

    Public Shared fieldStatus

    Public Shared handleLighting As New Thread(AddressOf PLC_Handler.handleLighting)

    'Match Type enums'
    Public Enum MatchEnums
        PreMatch
        SandStorm
        TeleOp
        EndGameWarning
        EndGame
        PostMatch
        AbortMatch
    End Enum

    Public Shared Sub HandleDSConnections()
        Red1DS.newDriverStation(Main_Panel.RedTeam1.Text, 0)
        'Red2DS.newDriverStation(Main_Panel.RedTeam2.Text, 1)
        'Red3DS.newDriverStation(Main_Panel.RedTeam3.Text, 2)
        'Blue1DS.newDriverStation(Main_Panel.BlueTeam1.Text, 3)
        'Blue2DS.newDriverStation(Main_Panel.BlueTeam2.Text, 4)
        'Blue3DS.newDriverStation(Main_Panel.BlueTeam3.Text, 5)
    End Sub

    Public Shared Sub handlePLC()
        Do While (True)
            writeCoils()
            readCoils()
            writeRegisters()
            readRegisters()
            checkAlliances()
            handleAutomatedScoring()
            handleEstops()
            PLC_Handler.handleLighting()
            Thread.Sleep(PLC_LoopTime)
        Loop
    End Sub

    Public Shared Sub DisposeDS()

    End Sub

    Public Shared Sub SendDS(Auto As Boolean, Enabled As Boolean)
        If Auto = True And Red1DS.Estop = False Then
            Red1DS.Auto = True
            Red1DS.Enabled = False
        ElseIf Auto = True And Enabled = True And Red1DS.Estop = False Then
            Red1DS.Auto = True
            Red1DS.Enabled = True
        ElseIf Enabled = True And Red1DS.Estop = False Then
            Red1DS.Auto = False
            Red1DS.Enabled = True
        ElseIf Red1DS.Estop = True Then
            Red1DS.Auto = False
            Red1DS.Enabled = False
        ElseIf Red1Bypass = True Then
            Red1DS.Auto = False
            Red1DS.Enabled = False
            Red1DS.Estop = False
        End If

        If Auto = True And Red2DS.estop = False Then
            Red2DS.auto = True
            Red2DS.enabled = False
        ElseIf Auto = True And Enabled = True And Red2DS.estop = False Then
            Red2DS.auto = True
            Red2DS.enabled = True
        ElseIf Enabled = True And Red2DS.estop = False Then
            Red2DS.auto = False
            Red2DS.enabled = True
        ElseIf Red2DS.estop = True Then
            Red2DS.auto = False
            Red2DS.enabled = False
        ElseIf Red2Bypass = True Then
            Red2DS.auto = False
            Red2DS.enabled = False
            Red2DS.estop = False
        End If

        If Auto = True And Red3DS.estop = False Then
            Red3DS.auto = True
            Red3DS.enabled = False
        ElseIf Auto = True And Enabled = True And Red3DS.estop = False Then
            Red3DS.auto = True
            Red3DS.enabled = True
        ElseIf Enabled = True And Red3DS.estop = False Then
            Red3DS.auto = False
            Red3DS.enabled = True
        ElseIf Red3DS.estop = True Then
            Red3DS.auto = False
            Red3DS.enabled = False
        ElseIf Red3Bypass = True Then
            Red3DS.auto = False
            Red3DS.enabled = False
            Red3DS.estop = False
        End If

        If Auto = True And Blue1DS.estop = False Then
            Blue1DS.auto = True
            Blue1DS.enabled = False
        ElseIf Auto = True And Enabled = True And Blue1DS.estop = False Then
            Blue1DS.auto = True
            Blue1DS.enabled = True
        ElseIf Enabled = True And Blue1DS.estop = False Then
            Blue1DS.auto = False
            Blue1DS.enabled = True
        ElseIf Blue1DS.estop = True Then
            Blue1DS.auto = False
            Blue1DS.enabled = False
        ElseIf Blue1Bypass = True Then
            Blue1DS.auto = False
            Blue1DS.enabled = False
            Blue1DS.estop = False
        End If

        If Auto = True And Blue2DS.estop = False Then
            Blue2DS.auto = True
            Blue2DS.enabled = False
        ElseIf Auto = True And Enabled = True And Blue2DS.estop = False Then
            Blue2DS.auto = True
            Blue2DS.enabled = True
        ElseIf Enabled = True And Blue2DS.estop = False Then
            Blue2DS.auto = False
            Blue2DS.enabled = True
        ElseIf Blue2DS.estop = True Then
            Blue2DS.auto = False
            Blue2DS.enabled = False
        ElseIf Blue2Bypass = True Then
            Blue2DS.auto = False
            Blue2DS.enabled = False
            Blue2DS.estop = False
        End If

        If Auto = True And Blue3DS.estop = False Then
            Blue3DS.auto = True
            Blue3DS.enabled = False
        ElseIf Auto = True And Enabled = True And Blue3DS.estop = False Then
            Blue3DS.auto = True
            Blue3DS.enabled = True
        ElseIf Enabled = True And Blue3DS.estop = False Then
            Blue3DS.auto = False
            Blue3DS.enabled = True
        ElseIf Blue3DS.estop = True Then
            Blue3DS.auto = False
            Blue3DS.enabled = False
        ElseIf Blue3Bypass = True Then
            Blue3DS.auto = False
            Blue3DS.enabled = False
            Blue3DS.estop = False
        End If
    End Sub

    Public Shared Sub updateField(MatchEnums As MatchEnums)
        Select Case (MatchEnums)

            Case MatchEnums.PreMatch
                HandleDSConnections()
                status = False
                My.Computer.Audio.Play(My.Resources.match_force, AudioPlayMode.Background)
                ResetPLC()
                fieldStatus = MatchEnums.PreMatch
                SendDS(Auto:=True, Enabled:=False)
            Case MatchEnums.SandStorm
                Match_Start = True
                Match_Stop = False
                status = True
                fieldStatus = MatchEnums.SandStorm
                SendDS(Auto:=True, Enabled:=True)
                My.Computer.Audio.Play(My.Resources.match_start, AudioPlayMode.Background)
            Case MatchEnums.TeleOp
                fieldStatus = MatchEnums.TeleOp
                SendDS(Auto:=False, Enabled:=True)
                My.Computer.Audio.Play(My.Resources.match_resume, AudioPlayMode.Background)
            Case MatchEnums.EndGameWarning
                fieldStatus = MatchEnums.EndGameWarning
                SendDS(Auto:=False, Enabled:=True)
                'Add EndGameWarning'
                My.Computer.Audio.Play(My.Resources.match_warning_1, AudioPlayMode.Background)
            Case MatchEnums.EndGame
                fieldStatus = MatchEnums.EndGame
                SendDS(Auto:=False, Enabled:=True)
                My.Computer.Audio.Play(My.Resources.match_endgame, AudioPlayMode.Background)
            Case MatchEnums.PostMatch
                fieldStatus = MatchEnums.PostMatch
                SendDS(Auto:=False, Enabled:=False)
                My.Computer.Audio.Play(My.Resources.match_end, AudioPlayMode.Background)
                Match_Start = False
                Match_Stop = True
                status = False
            Case MatchEnums.AbortMatch
                fieldStatus = MatchEnums.AbortMatch
                My.Computer.Audio.Play(My.Resources.fog_blast, AudioPlayMode.Background)
                SendDS(Auto:=False, Enabled:=False)
                Match_Start = False
                Match_Stop = True
                status = False

            Case Else
                MatchEnums = MatchEnums.PreMatch
        End Select
    End Sub


End Class
