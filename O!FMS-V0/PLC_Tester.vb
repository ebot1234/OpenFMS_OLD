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
End Class