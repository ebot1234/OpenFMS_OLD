Imports O_FMS_V0.Led_Controller
Public Class Led_Strip

    Public Structure strip
        Public Shared currentMode As String
        Public Shared isRed As Boolean
        Public Shared pixels = Num_Pixels(3)
        Public Shared oldPixels = Num_Pixels(3)
        Public Shared counter As Integer
        Public Shared lastPacketTime As DateTime
    End Structure

    Public Shared Sub updatePixels()
        Select Case strip.currentMode
            Case "RedMode"
            Case "GreenMode"
            Case "BlueMode"
        End Select

        strip.counter = strip.counter + 1
    End Sub

    Public Shared Function shouldSendPacket() As Boolean

        For i As Integer = 0 To Num_Pixels
            i = i + 1
            If strip.pixels(i) IsNot strip.oldPixels(i) Then
                Return True
            End If
        Next
        'Check this'
        Return strip.lastPacketTime.Second > packetTimeoutSec
    End Function

    Public Shared Sub populatePacketPixels(pixelData)
        For Each pixel In pixelData
            pixelData(3 * pixel) = pixel(0)
        Next
    End Sub
End Class
