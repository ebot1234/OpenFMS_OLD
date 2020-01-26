Imports System.Net

Public Class Arena
    Public Shared ResetField As Boolean 'Reset the Field Elements and Varibles'
    'Driver Stations'
    Public Shared Red1DS As New DriverStation
    Public Shared Red2DS As New DriverStation
    Public Shared Red3DS As New DriverStation
    Public Shared Blue1DS As New DriverStation
    Public Shared Blue2DS As New DriverStation
    Public Shared Blue3DS As New DriverStation
    'Field Networking'
    Public Shared AP As New Access_Point
    Public Shared Switch As New Switch

    Public Shared PLC As New PLC

    Public Sub UpdateField(Mode As String)
        Select Case Mode
            Case "PreMatch"
                SendDS(Auto:=True, Enabled:=False)
            Case "StartMatch"
                SendDS(Auto:=True, Enabled:=False)
                PlaySound("MatchStart")
            Case "Auto"
                SendDS(Auto:=True, Enabled:=True)
            Case "Pause"
                SendDS(Auto:=False, Enabled:=False)
                PlaySound("AutoEnd")
            Case "Tele"
                SendDS(Auto:=False, Enabled:=True)
                PlaySound("TeleStart")
            Case "EndGame"
                SendDS(Auto:=False, Enabled:=True)
                PlaySound("EndGameWarning")
            Case "PostMatch"
                SendDS(Auto:=False, Enabled:=False)
                PlaySound("MatchEnd")
            Case "AbortMatch"
                SendDS(Auto:=False, Enabled:=False)
                PlaySound("Aborted")
            Case Else
                Mode = "PreMatch"
        End Select
    End Sub

    'Plays the arena sounds in background'
    Public Sub PlaySound(soundStr As String)
        Select Case soundStr
            Case "MatchStart"
            Case "AutoEnd"
            Case "TeleStart"
            Case "EndGameWarning"
            Case "MatchEnd"
            Case "Aborted"
            Case "RotationCompleted"
            Case "PositionCompleted"
        End Select
    End Sub

    Public Sub SendDS(Auto As Boolean, Enabled As Boolean)

    End Sub

End Class
