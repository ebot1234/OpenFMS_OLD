Public Class Pre_Match_Selector
    'Red Pre-Match Bays'
    Public Shared redPBay1
    Public Shared redPBay2
    Public Shared redPBay3
    Public Shared redPBay4
    Public Shared redPBay5
    Public Shared redPBay6
    Public Shared redPBay7
    Public Shared redPBay8
    'Blue Pre-Match Bays'
    Public Shared bluePBay1
    Public Shared bluePBay2
    Public Shared bluePBay3
    Public Shared bluePBay4
    Public Shared bluePBay5
    Public Shared bluePBay6
    Public Shared bluePBay7
    Public Shared bluePBay8
    'Red Pre-Match Robots'
    Public Shared redPRobot1
    Public Shared redPRobot2
    Public Shared redPRobot3
    'Blue Pre-Match Robots
    Public Shared bluePRobot1
    Public Shared bluePRobot2
    Public Shared bluePRobot3

    'Red Bay 1'
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        redPBay1 = "Unknown"
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        redPBay1 = "Panel"
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        redPBay1 = "Cargo"
    End Sub
    'Red Bay 2'
    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        redPBay2 = "Unknown"
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        redPBay2 = "Panel"
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        redPBay2 = "Cargo"
    End Sub
    'Red Bay 3'
    Private Sub RadioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton7.CheckedChanged
        redPBay3 = "Unknown"
    End Sub

    Private Sub RadioButton9_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton9.CheckedChanged
        redPBay3 = "Panel"
    End Sub

    Private Sub RadioButton8_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton8.CheckedChanged
        redPBay3 = "Cargo"
    End Sub
    'Red Bay 4'
    Private Sub RadioButton10_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton10.CheckedChanged
        redPBay4 = "Unknown"
    End Sub

    Private Sub RadioButton12_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton12.CheckedChanged
        redPBay4 = "Panel"
    End Sub

    Private Sub RadioButton11_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton11.CheckedChanged
        redPBay4 = "Cargo"
    End Sub
    'Red Bay 5'
    Private Sub RadioButton13_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton13.CheckedChanged
        redPBay5 = "Unknown"
    End Sub

    Private Sub RadioButton15_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton15.CheckedChanged
        redPBay5 = "Panel"
    End Sub

    Private Sub RadioButton14_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton14.CheckedChanged
        redPBay5 = "Cargo"
    End Sub
    'Red Bay 6'
    Private Sub RadioButton16_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton16.CheckedChanged
        redPBay6 = "Unknown"
    End Sub

    Private Sub RadioButton18_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton18.CheckedChanged
        redPBay6 = "Panel"
    End Sub

    Private Sub RadioButton17_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton17.CheckedChanged
        redPBay6 = "Cargo"
    End Sub
    'Red Bay 7'
    Private Sub RadioButton19_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton19.CheckedChanged
        redPBay7 = "Unknown"
    End Sub

    Private Sub RadioButton21_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton21.CheckedChanged
        redPBay7 = "Panel"
    End Sub

    Private Sub RadioButton20_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton20.CheckedChanged
        redPBay7 = "Cargo"
    End Sub
    'Red Bay 8'
    Private Sub RadioButton22_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton22.CheckedChanged
        redPBay8 = "Unknown"
    End Sub

    Private Sub RadioButton24_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton24.CheckedChanged
        redPBay8 = "Panel"
    End Sub

    Private Sub RadioButton23_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton23.CheckedChanged
        redPBay8 = "Cargo"
    End Sub


    'Blue Bay 1'
    Private Sub RadioButton25_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton25.CheckedChanged
        bluePBay1 = "Unknown"
    End Sub

    Private Sub RadioButton27_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton27.CheckedChanged
        bluePBay1 = "Panel"
    End Sub

    Private Sub RadioButton26_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton26.CheckedChanged
        bluePBay1 = "Cargo"
    End Sub
    'Blue Bay 2'
    Private Sub RadioButton28_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton28.CheckedChanged
        bluePBay2 = "Unknown"
    End Sub

    Private Sub RadioButton30_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton30.CheckedChanged
        bluePBay2 = "Panel"
    End Sub

    Private Sub RadioButton29_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton29.CheckedChanged
        bluePBay2 = "Cargo"
    End Sub
    'Blue Bay 3'
    Private Sub RadioButton31_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton31.CheckedChanged
        bluePBay3 = "Unknown"
    End Sub

    Private Sub RadioButton33_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton33.CheckedChanged
        bluePBay3 = "Panel"
    End Sub

    Private Sub RadioButton32_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton32.CheckedChanged
        bluePBay3 = "Cargo"
    End Sub
    'Blue Bay 4'
    Private Sub RadioButton34_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton34.CheckedChanged
        bluePBay4 = "Unknown"
    End Sub

    Private Sub RadioButton36_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton36.CheckedChanged
        bluePBay4 = "Panel"
    End Sub

    Private Sub RadioButton35_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton35.CheckedChanged
        bluePBay4 = "Cargo"
    End Sub
    'Blue Bay 5'
    Private Sub RadioButton37_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton37.CheckedChanged
        bluePBay5 = "Unknown"
    End Sub

    Private Sub RadioButton39_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton39.CheckedChanged
        bluePBay5 = "Panel"
    End Sub

    Private Sub RadioButton38_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton38.CheckedChanged
        bluePBay5 = "Cargo"
    End Sub
    'Blue Bay 6'
    Private Sub RadioButton40_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton40.CheckedChanged
        bluePBay6 = "Unknown"
    End Sub

    Private Sub RadioButton42_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton42.CheckedChanged
        bluePBay6 = "Panel"
    End Sub

    Private Sub RadioButton41_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton41.CheckedChanged
        bluePBay6 = "Cargo"
    End Sub
    'Blue Bay 7'
    Private Sub RadioButton43_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton43.CheckedChanged
        bluePBay7 = "Unknown"
    End Sub

    Private Sub RadioButton45_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton45.CheckedChanged
        bluePBay7 = "Panel"
    End Sub

    Private Sub RadioButton44_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton44.CheckedChanged
        bluePBay7 = "Cargo"
    End Sub
    'Blue Bay 8'
    Private Sub RadioButton46_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton46.CheckedChanged
        bluePBay8 = "Unknown"
    End Sub

    Private Sub RadioButton48_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton48.CheckedChanged
        bluePBay8 = "Panel"
    End Sub

    Private Sub RadioButton47_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton47.CheckedChanged
        bluePBay8 = "Cargo"
    End Sub
    'Red Robots'
    Private Sub RadioButton49_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton49.CheckedChanged
        redPRobot1 = "None"
    End Sub

    Private Sub RadioButton50_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton50.CheckedChanged
        redPRobot1 = "HABLevel1"
    End Sub

    Private Sub RadioButton51_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton51.CheckedChanged
        redPRobot1 = "HABLevel2"
    End Sub

    Private Sub RadioButton54_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton54.CheckedChanged
        redPRobot2 = "None"
    End Sub

    Private Sub RadioButton53_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton53.CheckedChanged
        redPRobot2 = "HABLevel1"
    End Sub

    Private Sub RadioButton52_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton52.CheckedChanged
        redPRobot2 = "HABLevel2"
    End Sub

    Private Sub RadioButton55_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton55.CheckedChanged
        redPRobot3 = "None"
    End Sub

    Private Sub RadioButton56_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton56.CheckedChanged
        redPRobot3 = "HABLevel1"
    End Sub

    Private Sub RadioButton57_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton57.CheckedChanged
        redPRobot3 = "HABLevel2"
    End Sub
    'Blue Robots
    Private Sub RadioButton66_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton66.CheckedChanged
        bluePRobot1 = "None"
    End Sub

    Private Sub RadioButton65_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton65.CheckedChanged
        bluePRobot1 = "HABLevel1"
    End Sub

    Private Sub RadioButton64_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton64.CheckedChanged
        bluePRobot1 = "HABLevel2"
    End Sub

    Private Sub RadioButton63_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton63.CheckedChanged
        bluePRobot2 = "None"
    End Sub

    Private Sub RadioButton62_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton62.CheckedChanged
        bluePRobot2 = "HABLevel1"
    End Sub

    Private Sub RadioButton61_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton61.CheckedChanged
        bluePRobot2 = "HABLevel2"
    End Sub

    Private Sub RadioButton60_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton60.CheckedChanged
        bluePRobot3 = "None"
    End Sub

    Private Sub RadioButton59_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton59.CheckedChanged
        bluePRobot3 = "HABLevel1"
    End Sub

    Private Sub RadioButton58_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton58.CheckedChanged
        bluePRobot3 = "HABLevel2"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class