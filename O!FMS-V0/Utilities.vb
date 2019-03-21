Imports Microsoft.VisualBasic.PowerPacks

Public Class Utilities

    Dim AdminNetwork As String = "10.0.0."
    Dim PLC As String = "7"
    Dim FMS_PC As String = "5"
    Dim Red_Box As String = "10"
    Dim Blue_Box As String = "11"
    Dim Access_Point As String = "15"
    Dim Red_team_sign As String = "16"
    Dim Blue_team_sign As String = "17"
    'Year Specifics'
    Dim Rocket_led_controller_1 As String = "13"
    Dim Rocket_led_controller_2 As String = "14"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        checkBasicHardware()
        checkPLCHardware()
        checkFieldSpecificHardware()
    End Sub

    Private Sub checkBasicHardware()
        If My.Computer.Network.Ping(AdminNetwork + Access_Point, 1000) Then
            Access_PointLbl.ForeColor = Color.LimeGreen
        Else
            Access_PointLbl.ForeColor = Color.Red
        End If

        If My.Computer.Network.Ping(AdminNetwork + FMS_PC) Then
            FMS.ForeColor = Color.LimeGreen
        Else
            FMS.ForeColor = Color.Red
        End If
    End Sub

    Private Sub checkPLCHardware()
        If My.Computer.Network.Ping(AdminNetwork + PLC, 1000) Then
            PLC_Status.ForeColor = Color.LimeGreen
        Else
            PLC_Status.ForeColor = Color.Red
        End If

        If My.Computer.Network.Ping(AdminNetwork + Red_Box, 1000) Then
            Red_Alliance_Box.ForeColor = Color.LimeGreen
        Else
            Red_Alliance_Box.ForeColor = Color.Red
        End If

        If My.Computer.Network.Ping(AdminNetwork + Blue_Box, 1000) Then
            Blue_Alliance_Box.ForeColor = Color.LimeGreen
        Else
            Blue_Alliance_Box.ForeColor = Color.Red
        End If

        If My.Computer.Network.Ping(AdminNetwork + Red_team_sign, 1000) Then
            Red_ViewMarq.ForeColor = Color.LimeGreen
        Else
            Red_ViewMarq.ForeColor = Color.Red
        End If

        If My.Computer.Network.Ping(AdminNetwork + Blue_team_sign, 1000) Then
            Blue_ViewMarq.ForeColor = Color.LimeGreen
        Else
            Blue_ViewMarq.ForeColor = Color.Red
        End If
    End Sub

    Private Sub checkFieldSpecificHardware()
        If My.Computer.Network.Ping(AdminNetwork + Rocket_led_controller_1, 1000) Then
            Light_Controller1.ForeColor = Color.LimeGreen
        Else
            Light_Controller1.ForeColor = Color.Red
        End If

        If My.Computer.Network.Ping(AdminNetwork + Rocket_led_controller_2, 1000) Then
            LightController2.ForeColor = Color.LimeGreen
        Else
            LightController2.ForeColor = Color.Red
        End If
    End Sub

End Class