Imports O_FMS_V0.PLC_Comms_Server
Imports O_FMS_V0.RandomString
Imports O_FMS_V0.ArduinoIps
Imports O_FMS_V0.AudienceDisplayComms

Imports System.Net

Public Class Field
    Public Shared FieldReset As Boolean
    Public Shared Volunteers As Boolean
    Public Shared Red1DS As New DriverStations
    Public Shared Red2DS As New DriverStations
    Public Shared Red3DS As New DriverStations
    Public Shared Blue1DS As New DriverStations
    Public Shared Blue2DS As New DriverStations
    Public Shared Blue3DS As New DriverStations
    Public Shared ScaleLeds As New ArduinoLedController
    Public Shared RedSwitchLeds As New ArduinoLedController
    Public Shared BlueSwitchLeds As New ArduinoLedController
    Public Shared WarmUpTime As Integer = 4
    Public Shared AutoTime As Integer = 15
    Public Shared PauseTime As Integer = 3
    Public Shared TeleTime As Integer = 135
    Public Shared EndgameTime As Integer = 30
    Public Shared GameTime As Integer = 0

    Public Shared Sub ConnectLeds()
        ' ScaleLeds.ConnectArduino(ScaleNetwork)
        ' BlueSwitchLeds.ConnectArduino(BlueSwitchNetwork)
        'RedSwitchLeds.ConnectArduino(RedSwitchNetwork)
    End Sub
    Public Shared Sub HandleLeds()
        If gamedatause = "LLL" Then
            ' ScaleLeds.SendPackets("LLL")
            ' BlueSwitchLeds.SendPackets("LLL")
            ' RedSwitchLeds.SendPackets("LLL")
        End If
    End Sub

    Public Shared Sub HandlePLC()
        If PLC_Estop_Red1 = True Then
            Red1DS.Estop = True
        End If

        If PLC_Estop_Red2 = True Then
            Red2DS.Estop = True
        End If

        If PLC_Estop_Red3 = True Then
            Red3DS.Estop = True
        End If

        If PLC_Estop_Blue1 = True Then
            Blue1DS.Estop = True
        End If

        If PLC_Estop_Blue2 = True Then
            Blue2DS.Estop = True
        End If

        If PLC_Estop_Blue3 = True Then
            Blue3DS.Estop = True
        End If


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

    Public Shared Sub updateField(mode As String)
        Select Case (mode)
            Case "PreMatch"
                PLC_Reset = True
                SendDS(Auto:=True, Enabled:=False)
                My.Computer.Audio.Play(My.Resources.match_boost, AudioPlayMode.Background)
                Match_PreStart = True
            Case "StartMatch"
                SendDS(Auto:=True, Enabled:=False)
                GameDataGen()
                Match_Start = True
                My.Computer.Audio.Play(My.Resources.match_warmup, AudioPlayMode.Background)
            Case "Auto"
                SendDS(Auto:=True, Enabled:=True)
                My.Computer.Audio.Play(My.Resources.match_start, AudioPlayMode.Background)
 
            Case "Pause"
                My.Computer.Audio.Play(My.Resources.match_end, AudioPlayMode.Background)
            Case "Tele"
                My.Computer.Audio.Play(My.Resources.match_resume, AudioPlayMode.Background)
            Case "EndGame"
                My.Computer.Audio.Play(My.Resources.match_endgame, AudioPlayMode.Background)
            Case "PostMatch"
                My.Computer.Audio.Play(My.Resources.match_end, AudioPlayMode.Background)
                Match_Stop = True
            Case "AbortMatch"
                SendDS(Auto:=False, Enabled:=False)
                My.Computer.Audio.Play(My.Resources.match_end, AudioPlayMode.Background)
                Match_Stop = True
            Case Else
                mode = "PreMatch"
        End Select
    End Sub
End Class