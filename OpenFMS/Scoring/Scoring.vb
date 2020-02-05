
Public Class Scoring
    Public Red_Auto_Inner_Score, Red_Auto_Outer_Score, Red_Auto_Lower_Score
    Public Red_Inner_Score, Red_Outer_Score, Red_Lower_Score

    Public Sub HandleScore()
        While True
            handleRedPowerCellScoring()
        End While
    End Sub

    Public Sub handleRedPowerCellScoring()
        If Arena.Auto_Enabled = True Then
            For Each PowerCell In Arena.PLC.Red_Inner_Port_Count
                Red_Auto_Inner_Score = Red_Auto_Inner_Score + 6
            Next

            For Each PowerCell In Arena.PLC.Red_Outer_Port_Count
                Red_Auto_Outer_Score = Red_Auto_Outer_Score + 4
            Next

            For Each PowerCell In Arena.PLC.Red_Lower_Port_Count
                Red_Auto_Lower_Score = Red_Auto_Lower_Score + 2
            Next
        Else
            'Add TeleOp Code'
        End If
    End Sub
End Class
