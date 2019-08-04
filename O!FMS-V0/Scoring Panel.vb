Imports O_FMS_V0.Main_Panel
Imports O_FMS_V0.Pre_Match_Selector

Public Class Scoring_Panel
    'Red Top Left Rocket Bay'
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        redTopLeftRocketNear = "None"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        Else
            redTelePoints = redTelePoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        redTopLeftRocketNear = "Panel"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        Else
            redTelePoints = redTelePoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        redTopLeftRocketNear = "PanelAndCargo"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        Else
            redTelePoints = redTelePoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        End If
    End Sub
    'Red Mid Left Rocket Bay'
    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        redMidLeftRocketNear = "None"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        Else
            redTelePoints = redTelePoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        redMidLeftRocketNear = "Panel"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        Else
            redTelePoints = redTelePoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        redMidLeftRocketNear = "PanelAndCargo"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        Else
            redTelePoints = redTelePoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        End If
    End Sub
    'Red Low Left Rocket Bay'
    Private Sub RadioButton9_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton9.CheckedChanged
        redLowLeftRocketNear = "None"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        Else
            redTelePoints = redTelePoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        End If
    End Sub

    Private Sub RadioButton8_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton8.CheckedChanged
        redLowLeftRocketNear = "Panel"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        Else
            redTelePoints = redTelePoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        End If
    End Sub

    Private Sub RadioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton7.CheckedChanged
        redLowLeftRocketNear = "PanelAndCargo"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        Else
            redTelePoints = redTelePoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        End If
    End Sub
    'Red Top Right Bay'
    Private Sub RadioButton18_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton18.CheckedChanged
        redTopRightRocketNear = "None"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        Else
            redTelePoints = redTelePoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        End If
    End Sub

    Private Sub RadioButton17_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton17.CheckedChanged
        redTopRightRocketNear = "Panel"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        Else
            redTelePoints = redTelePoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        End If
    End Sub

    Private Sub RadioButton16_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton16.CheckedChanged
        redTopRightRocketNear = "PanelAndCargo"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        Else
            redTelePoints = redTelePoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        End If
    End Sub
    'Red Mid Right Bay
    Private Sub RadioButton15_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton15.CheckedChanged
        redMidRightRocketNear = "None"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        Else
            redTelePoints = redTelePoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        End If
    End Sub

    Private Sub RadioButton14_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton14.CheckedChanged
        redMidRightRocketNear = "Panel"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        Else
            redTelePoints = redTelePoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        End If
    End Sub

    Private Sub RadioButton13_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton13.CheckedChanged
        redMidRightRocketNear = "PanelAndCargo"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        Else
            redTelePoints = redTelePoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        End If
    End Sub
    'Red Low Right Bay'
    Private Sub RadioButton12_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton12.CheckedChanged
        redLowRightRocketNear = "None"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        Else
            redTelePoints = redTelePoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        End If
    End Sub

    Private Sub RadioButton11_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton11.CheckedChanged
        redLowRightRocketNear = "Panel"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        Else
            redTelePoints = redTelePoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        End If
    End Sub

    Private Sub RadioButton10_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton10.CheckedChanged
        redLowRightRocketNear = "PanelAndCargo"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        Else
            redTelePoints = redTelePoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        redCompleteRocketNear = True
        redRocketRP = redRocketRP + 1
    End Sub
    'Red Top Right Bay
    Private Sub RadioButton36_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton36.CheckedChanged
        redTopLeftRocketFar = "None"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        Else
            redTelePoints = redTelePoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        End If
    End Sub

    Private Sub RadioButton35_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton35.CheckedChanged
        redTopLeftRocketFar = "Panel"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        Else
            redTelePoints = redTelePoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        End If
    End Sub

    Private Sub RadioButton34_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton34.CheckedChanged
        redTopLeftRocketFar = "PanelAndCargo"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        Else
            redTelePoints = redTelePoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        End If
    End Sub

    Private Sub RadioButton33_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton33.CheckedChanged
        redMidLeftRocketFar = "None"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        Else
            redTelePoints = redTelePoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        End If
    End Sub

    Private Sub RadioButton32_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton32.CheckedChanged
        redMidLeftRocketFar = "Panel"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        Else
            redTelePoints = redTelePoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        End If
    End Sub

    Private Sub RadioButton31_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton31.CheckedChanged
        redMidLeftRocketFar = "PanelAndCargo"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        Else
            redTelePoints = redTelePoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        End If
    End Sub

    Private Sub RadioButton30_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton30.CheckedChanged
        redLowLeftRocketFar = "None"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        Else
            redTelePoints = redTelePoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        End If
    End Sub

    Private Sub RadioButton29_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton29.CheckedChanged
        redLowLeftRocketFar = "Panel"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        Else
            redTelePoints = redTelePoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        End If
    End Sub

    Private Sub RadioButton28_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton28.CheckedChanged
        redLowLeftRocketFar = "PanelAndCargo"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        Else
            redTelePoints = redTelePoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        End If
    End Sub

    Private Sub RadioButton27_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton27.CheckedChanged
        redTopRightRocketFar = "None"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        Else
            redTelePoints = redTelePoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        End If
    End Sub

    Private Sub RadioButton26_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton26.CheckedChanged
        redTopRightRocketFar = "Panel"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        Else
            redTelePoints = redTelePoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        End If
    End Sub

    Private Sub RadioButton25_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton25.CheckedChanged
        redTopRightRocketFar = "PanelAndCargo"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        Else
            redTelePoints = redTelePoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        End If
    End Sub

    Private Sub RadioButton24_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton24.CheckedChanged
        redMidRightRocketFar = "None"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        Else
            redTelePoints = redTelePoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        End If
    End Sub

    Private Sub RadioButton23_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton23.CheckedChanged
        redMidRightRocketFar = "Panel"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        Else
            redTelePoints = redTelePoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        End If
    End Sub

    Private Sub RadioButton22_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton22.CheckedChanged
        redMidRightRocketFar = "PanelAndCargo"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        Else
            redTelePoints = redTelePoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        End If
    End Sub

    Private Sub RadioButton21_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton21.CheckedChanged
        redLowRightRocketFar = "None"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
        Else
            redTelePoints = redTelePoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
        End If
    End Sub

    Private Sub RadioButton20_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton20.CheckedChanged
        redLowRightRocketFar = "Panel"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        Else
            redTelePoints = redTelePoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        End If
    End Sub

    Private Sub RadioButton19_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton19.CheckedChanged
        redLowRightRocketFar = "PanelAndCargo"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        Else
            redTelePoints = redTelePoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        redCompleteRocketFar = True
        redRocketRP = redRocketRP + 1
    End Sub
    'Red Cargoship'
    Private Sub RadioButton73_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton73.CheckedChanged
        redBay1 = "None"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        Else
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        End If
    End Sub

    Private Sub RadioButton74_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton74.CheckedChanged
        redBay1 = "Panel"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        Else
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        End If
    End Sub

    Private Sub RadioButton75_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton75.CheckedChanged
        redBay1 = "PanelAndCargo"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        Else
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        End If
    End Sub

    Private Sub RadioButton78_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton78.CheckedChanged
        redBay2 = "None"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        Else
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        End If
    End Sub

    Private Sub RadioButton77_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton77.CheckedChanged
        redBay2 = "Panel"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        Else
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        End If
    End Sub

    Private Sub RadioButton76_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton76.CheckedChanged
        redBay2 = "PanelAndCargo"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        Else
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        End If
    End Sub

    Private Sub RadioButton81_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton81.CheckedChanged
        redBay3 = "None"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        Else
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        End If
    End Sub

    Private Sub RadioButton80_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton80.CheckedChanged
        redBay3 = "Panel"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        Else
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        End If
    End Sub

    Private Sub RadioButton79_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton79.CheckedChanged
        redBay3 = "PanelAndCargo"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        Else
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        End If
    End Sub

    Private Sub RadioButton84_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton84.CheckedChanged
        redBay4 = "None"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        Else
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        End If
    End Sub

    Private Sub RadioButton83_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton83.CheckedChanged
        redBay4 = "Panel"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        Else
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        End If
    End Sub

    Private Sub RadioButton82_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton82.CheckedChanged
        redBay4 = "PanelAndCargo"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        Else
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        End If
    End Sub

    Private Sub RadioButton87_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton87.CheckedChanged
        redBay5 = "None"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        Else
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        End If
    End Sub

    Private Sub RadioButton86_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton86.CheckedChanged
        redBay5 = "Panel"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        Else
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        End If
    End Sub

    Private Sub RadioButton85_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton85.CheckedChanged
        redBay5 = "PanelAndCargo"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        Else
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        End If
    End Sub

    Private Sub RadioButton90_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton90.CheckedChanged
        redBay6 = "None"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        Else
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        End If
    End Sub

    Private Sub RadioButton89_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton89.CheckedChanged
        redBay6 = "Panel"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        Else
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        End If
    End Sub

    Private Sub RadioButton88_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton88.CheckedChanged
        redBay6 = "PanelAndHatch"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        Else
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        End If
    End Sub

    Private Sub RadioButton93_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton93.CheckedChanged
        redBay7 = "None"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        Else
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        End If
    End Sub

    Private Sub RadioButton92_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton92.CheckedChanged
        redBay7 = "Panel"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        Else
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        End If
    End Sub

    Private Sub RadioButton91_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton91.CheckedChanged
        redBay7 = "PanelAndCargo"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        Else
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        End If
    End Sub

    Private Sub RadioButton96_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton96.CheckedChanged
        redBay8 = "None"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        Else
            redAutoPoints = redAutoPoints + 0
            redHatchPanelPoints = redHatchPanelPoints + 0
            redCargoPoints = redCargoPoints + 0
        End If
    End Sub

    Private Sub RadioButton95_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton95.CheckedChanged
        redBay8 = "Panel"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        Else
            redAutoPoints = redAutoPoints + 2
            redHatchPanelPoints = redHatchPanelPoints + 2
        End If
    End Sub

    Private Sub RadioButton94_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton94.CheckedChanged
        redBay8 = "PanelAndCargo"

        If auto_score = True Then
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        Else
            redAutoPoints = redAutoPoints + 6
            redHatchPanelPoints = redHatchPanelPoints + 6
            redCargoPoints = redCargoPoints + 6
        End If
    End Sub
End Class