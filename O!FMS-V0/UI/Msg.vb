Imports O_FMS_V0.Main

Public Class Msg

    Public Shared Sub send(ByVal message As String)
        Console.Out.Write(("Panel Message: " + message))
        'Dim temp As Net.Mime.MediaTypeNames.Text = Main.getInstance.getCurrentMsgBox
        ' If (Not (temp) Is Nothing) Then
        'temp.setForeground(Color.red);
        'temp.append((message + "" & ""))
        'End If

    End Sub
End Class