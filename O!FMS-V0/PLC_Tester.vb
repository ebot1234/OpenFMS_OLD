Imports O_FMS_V0.PLC_Comms_Server
Public Class PLC_Tester
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        PLC_Estop_Red2 = True
    End Sub

    Private Sub RadioButton9_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton9.CheckedChanged
        PLC_Used_Lev_Red = True
    End Sub

    Private Sub RadioButton10_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton10.CheckedChanged
        PLC_Used_Force_Blue = True
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        PLC_Estop_Red1 = True
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        PLC_Estop_Red3 = True
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        PLC_Estop_Blue1 = True
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        PLC_Estop_Blue2 = True
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        PLC_Estop_Blue3 = True
    End Sub

    Private Sub RadioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton7.CheckedChanged
        PLC_Used_Force_Red = True
    End Sub

    Private Sub RadioButton8_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton8.CheckedChanged
        PLC_Used_Boost_Red = True
    End Sub

    Private Sub RadioButton11_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton11.CheckedChanged
        PLC_Used_Boost_Blue = True
    End Sub

    Private Sub RadioButton12_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton12.CheckedChanged
        PLC_Used_Lev_Blue = True
    End Sub

    Private Sub PLC_Tester_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PLC_Estop_Field = True
    End Sub

    Private Sub FieldEstopbtn_CheckedChanged(sender As Object, e As EventArgs) Handles FieldEstopbtn.CheckedChanged
        PLC_Estop_Field = True
    End Sub

    Private Sub RadioButton14_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton14.CheckedChanged
        PLC_BlueScaleOwned = True
        PLC_RedScaleOwned = False
    End Sub

    Private Sub RadioButton15_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton15.CheckedChanged
        PLC_RedScaleOwned = True
        PLC_BlueScaleOwned = False
    End Sub

    Private Sub RadioButton16_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton16.CheckedChanged
        PLC_RedScaleOwned = False
        PLC_BlueScaleOwned = False
    End Sub

    Private Sub RadioButton13_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton13.CheckedChanged

    End Sub

    Private Sub RadioButton17_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton17.CheckedChanged
        PLC_RedSWBOwned = False
        PLC_RedSWOwned = False
    End Sub

    Private Sub RadioButton18_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton18.CheckedChanged
        PLC_RedSWOwned = True
        PLC_RedSWBOwned = False
    End Sub

    Private Sub RadioButton19_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton19.CheckedChanged
        PLC_RedSWBOwned = True
        PLC_RedSWOwned = False
    End Sub

    Private Sub RadioButton20_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton20.CheckedChanged
        PLC_BlueSWOwned = False
        PLC_BlueSWROwned = False
    End Sub

    Private Sub RadioButton21_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton21.CheckedChanged
        PLC_BlueSWROwned = True
        PLC_BlueSWOwned = False
    End Sub

    Private Sub RadioButton22_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton22.CheckedChanged
        PLC_BlueSWOwned = True
        PLC_BlueSWROwned = False
    End Sub
End Class