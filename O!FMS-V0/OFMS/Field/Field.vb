Imports O_FMS_V0.PLC_Comms_Server
Imports O_FMS_V0.RandomString
Imports O_FMS_V0.Team_Networks
Imports O_FMS_V0.Lighting
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


    Public Shared Sub ConnectDriverStations()
        Red1DS.Connect(IPAddress.Parse(""))
        Red2DS.Connect(IPAddress.Parse(""))
        Red3DS.Connect(IPAddress.Parse(""))
        Blue1DS.Connect(IPAddress.Parse(""))
        Blue2DS.Connect(IPAddress.Parse(""))
        Blue3DS.Connect(IPAddress.Parse(""))
    End Sub
    Public Shared Sub ConnectLeds()

        RedSwitchLeds.ConnectController("10.0.0.23")
        BlueSwitchLeds.ConnectController("10.0.0.24")
        ScaleLeds.ConnectController("10.0.0.25")

        'pings the led controllers'
        If My.Computer.Network.Ping("10.0.0.23", 1000) Then
            MessageBox.Show("Red Switch Leds Connected")
        Else
            MessageBox.Show("Red Switch Leds Not Connected")
        End If
        If My.Computer.Network.Ping("10.0.0.24", 1000) Then
            MessageBox.Show("Blue Switch Leds Connected")
        Else
            MessageBox.Show("Blue Switch Leds Not Connected")
        End If
        If My.Computer.Network.Ping("10.0.0.25", 1000) Then
            MessageBox.Show("Scale Leds Not Connected")
        Else
            MessageBox.Show("Scale Leds Not Connected")
        End If

    End Sub
    Public Shared Sub handleLeds()
        Dim RB As Integer = 0
        Dim RF As Integer = 0
        Dim RL As Integer = 0
        Dim BB As Integer = 0
        Dim BF As Integer = 0
        Dim BL As Integer = 0

        Do While (True)
            'Teams enter field'
            If PLC_Field_Reset = True Then
                SetMode(LightingModes.Green)
            End If
            'Field Reset'
            If PLC_Field_Volunteers = True Then
                SetMode(LightingModes.Purple)
            End If
            'Power Ups'
            If PLC_Used_Boost_Blue = True And BB < 1 Then
                SetMode(LightingModes.Blue_Boost)
                BB = BB + 1
            End If

            If PLC_Used_Boost_Red = True And RB < 1 Then
                SetMode(LightingModes.Red_Boost)
                RB = RB + 1
            End If

            If PLC_Used_Force_Blue = True And BF < 1 Then
                SetMode(LightingModes.Blue_Force)
                BF = BF + 1
            End If

            If PLC_Used_Force_Red = True And RF < 1 Then
                SetMode(LightingModes.Red_Force)
                RF = RF + 1
            End If

            If PLC_Used_Lev_Blue = True And BL < 1 Then
                SetMode(LightingModes.Blue_Levitate)
                BL = BL + 1
            End If

            If PLC_Used_Lev_Red = True And RL < 1 Then
                SetMode(LightingModes.Red_Levitate)
                RL = RL + 1
            End If
            'Sends game string'
            If Match_Start = True Then
                SendPacket(gamedatause)
            End If

            'Blue Switch Ownership'
            If PLC_BlueSWOwned = True Then
                SetMode(LightingModes.Blue_Owned_BSwitch)
            ElseIf PLC_BlueSWROwned = True Then
                SetMode(LightingModes.Red_Owned_BSwitch)
            Else
                SetMode(LightingModes.Red_NotOwned_BSwitch)
                SetMode(LightingModes.Blue_NotOwned_BSwitch)
            End If

            'Red Switch Ownership'
            If PLC_RedSWOwned = True Then
                SetMode(LightingModes.Red_Owned_RSwitch)
            ElseIf PLC_RedSWBOwned = True Then
                SetMode(LightingModes.Blue_Owned_RSwitch)
            Else
                SetMode(LightingModes.Blue_NotOwned_RSwitch)
                SetMode(LightingModes.Red_NotOwned_RSwitch)
            End If

            'Scale Ownership'
            If PLC_RedScaleOwned = True Then
                SetMode(LightingModes.Red_Owned_Scale)
            ElseIf PLC_BlueScaleOwned = True Then
                SetMode(LightingModes.Blue_Owned_Scale)
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

            'Red1DS.sendPacketDS()
            ' Red2DS.sendPacketDS()
            ' Red3DS.sendPacketDS()
            ' Blue1DS.sendPacketDS()
            ' Blue2DS.sendPacketDS()
            ' Blue3DS.sendPacketDS()

        Else
            Red1DS.Auto = False
            Red2DS.Auto = False
            Red3DS.Auto = False
            Blue1DS.Auto = False
            Blue2DS.Auto = False
            Blue3DS.Auto = False

            ' Red1DS.sendPacketDS()
            ' Red2DS.sendPacketDS()
            'Red3DS.sendPacketDS()
            ' Blue1DS.sendPacketDS()
            ' Blue2DS.sendPacketDS()
            'Blue3DS.sendPacketDS()
        End If

        If Enabled = True Then
            Red1DS.Enabled = True
            Red2DS.Enabled = True
            Red3DS.Enabled = True
            Blue1DS.Enabled = True
            Blue2DS.Enabled = True
            Blue3DS.Enabled = True

            ' Red1DS.sendPacketDS()
            ' Red2DS.sendPacketDS()
            ' Red3DS.sendPacketDS()
            ' Blue1DS.sendPacketDS()
            'Blue2DS.sendPacketDS()
            ' Blue3DS.sendPacketDS()
        Else
            Red1DS.Enabled = False
            Red2DS.Enabled = False
            Red3DS.Enabled = False
            Blue1DS.Enabled = False
            Blue2DS.Enabled = False
            Blue3DS.Enabled = False

            ' Red1DS.sendPacketDS()
            ' Red2DS.sendPacketDS()
            ' Red3DS.sendPacketDS()
            'Blue1DS.sendPacketDS()
            'Blue2DS.sendPacketDS()
            'Blue3DS.sendPacketDS()
        End If
        Return 0
    End Function

    Public Shared Sub updateField(MatchEnums As MatchEnums)
        Select Case (MatchEnums)
            Case MatchEnums.PreMatch
                PLC_Reset = True
                Match_PreStart = True

                'ConnectDriverStations()
                'pingDSConnections()
                SendDS(Auto:=True, Enabled:=False)

            Case MatchEnums.WarmUp
                SendDS(Auto:=True, Enabled:=False)
                GameDataGen()
                Match_Start = True
                My.Computer.Audio.Play(My.Resources.match_warmup, AudioPlayMode.Background)
            Case MatchEnums.Auto
                SendDS(Auto:=True, Enabled:=True)
                My.Computer.Audio.Play(My.Resources.match_start, AudioPlayMode.Background)

            Case MatchEnums.Pause
                My.Computer.Audio.Play(My.Resources.match_end, AudioPlayMode.Background)
            Case MatchEnums.TeleOp
                My.Computer.Audio.Play(My.Resources.match_resume, AudioPlayMode.Background)
            Case MatchEnums.EndGame
                My.Computer.Audio.Play(My.Resources.match_endgame, AudioPlayMode.Background)
            Case MatchEnums.PostMatch
                My.Computer.Audio.Play(My.Resources.match_end, AudioPlayMode.Background)
                Match_Stop = True
            Case MatchEnums.AbortMatch
                SendDS(Auto:=False, Enabled:=False)
                Match_Stop = True
            Case Else
                MatchEnums = MatchEnums.PreMatch
        End Select
    End Sub
End Class