Imports Microsoft.VisualBasic.PowerPacks

Public Class Utilities

    Dim AdminNetwork As String = "10.0.0."
    Dim FMS_PC As String = "5"
    Dim PLC As String = "7"
    Dim Red_Box As String = "10"
    Dim Blue_Box As String = "11"
    Dim Red_Vault_Box As String = "8"
    Dim Blue_Vault_Box As String = "9"
    Dim Access_Piont_1 As String = "15"
    Dim red_ViewMarq_1 As String = "16"
    Dim blue_viewmarq_1 As String = "17"
    Dim light_controller_1 As String = "13"

    Private Sub Utilities_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If My.Computer.Network.Ping(AdminNetwork & PLC, 1000) Then
            PLC_Status.ForeColor = Color.LimeGreen
        Else : PLC_Status.ForeColor = Color.Red
        End If

        If My.Computer.Network.Ping(AdminNetwork & Red_Box, 1000) Then
            Red_Alliance_Box.ForeColor = Color.LimeGreen
        Else : Red_Alliance_Box.ForeColor = Color.Red
        End If

        If My.Computer.Network.Ping(AdminNetwork & Blue_Box, 1000) Then
            Blue_Alliance_Box.ForeColor = Color.LimeGreen
        Else : Blue_Alliance_Box.ForeColor = Color.Red
        End If

        If My.Computer.Network.Ping(AdminNetwork & Red_Vault_Box, 1000) Then
            Red_Vault.ForeColor = Color.LimeGreen
        Else : Red_Vault.ForeColor = Color.Red
        End If

        If My.Computer.Network.Ping(AdminNetwork & Blue_Vault_Box, 1000) Then
            Blue_Vault.ForeColor = Color.LimeGreen
        Else : Blue_Vault.ForeColor = Color.Red
        End If

        If My.Computer.Network.Ping(AdminNetwork & Access_Piont_1, 1000) Then
            Access_Piont.ForeColor = Color.LimeGreen
        Else : Access_Piont.ForeColor = Color.Red
        End If

        If My.Computer.Network.Ping(AdminNetwork & red_ViewMarq_1, 1000) Then
            Red_ViewMarq.ForeColor = Color.LimeGreen
        Else : Red_ViewMarq.ForeColor = Color.Red
        End If

        If My.Computer.Network.Ping(AdminNetwork & blue_viewmarq_1, 1000) Then
            Blue_ViewMarq.ForeColor = Color.LimeGreen
        Else : Blue_ViewMarq.ForeColor = Color.Red
        End If

        If My.Computer.Network.Ping(AdminNetwork & light_controller_1, 1000) Then
            Light_Controller.ForeColor = Color.LimeGreen
        Else : Light_Controller.ForeColor = Color.Red
        End If
    End Sub

End Class