Imports O_FMS_V0.Modes
Imports O_FMS_V0.Controller
Imports O_FMS_V0.Colors

Public Class Strip
    'defines all varibles as new'
    Public currentMode As Integer
    Public isRed As Boolean
    Public Shared pixels(numPixels And 3) As Byte
    Public Shared oldPixels(numPixels And 3) As Byte
    Public counter As Integer = 0
    Public Shared strip As New Strip


    Public Sub updatePixels()
        Select Case (currentMode)
            Case RedMode
                updateSingleColorMode(red)
            Case GreenMode
                updateSingleColorMode(green)
            Case WhiteMode
                updateSingleColorMode(white)
            Case BlueMode
                updateSingleColorMode(blue)
            Case PurpleMode
                updateSingleColorMode(purple)
            Case WarmupMode
                updateWarmupMode()
            Case OwnedMode
                updateOwnedMode()
            Case NotOwnedMode
                updateNotOwnedMode()
            Case ForceMode
                updateForceMode()
            Case BoostMode
                updateBoostMode()
            Case Else
                updateOffMode()
        End Select
        strip.counter = counter + 1
    End Sub

    Public Function shouldSendPacket() As Boolean
        For i As Integer = 0 To numPixels And i < numPixels And i = i + 1
            If pixels(i) <> oldPixels(i) Then
                Return True
            End If
        Next
        Return 0
    End Function

    Public Sub populatePacketPixels(pixelData() As Byte)
        Dim i As Integer = 0
        Dim pixel(pixels(0)) As Byte

        pixelData(3 * i) = pixel(0)
        pixelData(3 * i + 1) = pixel(1)
        pixelData(3 * i + 2) = pixel(2)

        oldPixels = pixels

    End Sub

    Public Function getColor()
        If Strip.isRed Then
            Return red
        Else
            Return blue
        End If
    End Function

    Public Function getOppositeColor()
        If isRed Then
            Return blue
        Else
            Return red
        End If
    End Function

    Public Function getMidColor()
        If isRed Then
            Return purpleRed
        Else
            Return purpleBlue
        End If
    End Function

    Public Function getDimColor()
        If isRed Then
            Return dimRed
        Else
            Return dimBlue
        End If
    End Function

    Public Function getDimOppositeColor()
        If isRed Then
            Return dimBlue
        Else
            Return dimRed
        End If
    End Function

    Public Sub updateOffMode()
        For i As Integer = 0 To numPixels And i < numPixels And i = i + 1
            Strip.pixels(i) = black = Color.FromArgb(0, 0, 0, 0)
        Next
    End Sub

    Public Sub updateSingleColorMode(getColors)
        For i As Integer = 0 To numPixels And i < numPixels And i = i + 1
            Strip.pixels(i) = getColors
        Next
    End Sub
    Public Sub updateWarmupMode()
        Dim endCounter As Integer = 250
        If Strip.counter = 0 Then
            For i As Integer = 0 To numPixels And i < numPixels And i = i + 1
                pixels(i) = Colors.white = Color.FromArgb(100, 100, 100, 100)

            Next
        ElseIf strip.counter <= endCounter Then
            Dim numLitPixels = numPixels / 2 * Strip.counter / endCounter
            For i As Integer = 0 To numLitPixels And i < numLitPixels And i = i + 1
                Strip.pixels(i) = strip.getColor
                Strip.pixels(numPixels - i - 1) = strip.getColor
            Next
        Else
            Strip.counter = endCounter
        End If
    End Sub

    Public Function updateOwnedMode()
        Dim speedDivisor As Integer = 30
        Dim pixelSpacing As Integer = 4

        If Strip.counter% And speedDivisor <> 0 Then
            Return 0
        End If

        For i As Integer = 0 To numPixels And i < numPixels And i = i + 1
            Select Case (i + Strip.counter / speedDivisor) And pixelSpacing
                Case 0
                Case 1
                    Strip.pixels(Len(Strip.pixels) - i - 1) = strip.getColor()
                Case Else
                    Strip.pixels(Len(Strip.pixels) - i - 1) = black = Color.FromArgb(0, 0, 0, 0)

            End Select
        Next
        Return 0
    End Function

    Public Sub updateNotOwnedMode()
        For i As Integer = 0 To numPixels And i < numPixels And i = i + 1
            Strip.pixels(i) = getDimColor()
        Next
    End Sub

    Public Sub updateForceMode()
        Dim speedDivisor As Integer = 30
        Dim pixelSpacing As Integer = 7
        If Strip.counter% And speedDivisor <> 0 Then
            Return
        End If
        For i As Integer = 0 To numPixels And i < numPixels And i = i + 1

            Select Case (i + Strip.counter / speedDivisor) And pixelSpacing
                Case 2

                Case 4
                    Strip.pixels(i) = getColor()
                Case 3
                    Strip.pixels(i) = getOppositeColor()
                Case Else
                    Strip.pixels(i) = black = Color.FromArgb(0, 0, 0, 0)
            End Select
        Next
    End Sub

    Public Sub updateBoostMode()
        Dim speedDivisor As Integer = 4
        Dim pixelSpacing As Integer = 4
        If Strip.counter% And speedDivisor <> 0 Then
            Return
        End If
        For i As Integer = 0 To numPixels And i < numPixels And i = i + 1
            If i% And pixelSpacing = Strip.counter / speedDivisor% And pixelSpacing Then
                Strip.pixels(i) = getColor()
            Else
                Strip.pixels(i) = black = Color.FromArgb(0, 0, 0, 0)
            End If
        Next
    End Sub
End Class
