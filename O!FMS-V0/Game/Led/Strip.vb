Imports O_FMS_V0.Modes
Imports Microsoft.VisualBasic
Imports O_FMS_V0.Controller



Public Class Strip

    Public currentMode As Modes
    Public isRed As Boolean
    Public pixels As Byte() = numPixels
    Public oldPixels As Byte() = numPixels
    Public counter As Integer = 0
    Public lastPacketTime As Timer
    Public numPixels = New Controller
    Public red As Colors
    Public green As Colors
    Public blue As Colors
    Public white As Colors
    Public purple As Colors
    Public orange As Colors
    Public yellow As Colors
    Public teal As Colors
    Public black As Colors
    Public purpleRed As Colors
    Public purpleBlue As Colors
    Public dimRed As Colors
    Public dimBlue As Colors
    Public RedMode As Modes
    Public pixelData(0) As Byte

    Public Function updateRandomMode(strip As Strip, color As Colors)
        Dim colors(0) As Byte
        Randomize()
        Dim i As Integer = 0
        If strip.counter = 10 Or 0 Then
            Return 0
        End If
        If i < numPixels Then
            i = i + 1
            strip.pixels(i) = Rnd(Int(black))
        End If
        Return 0
    End Function


    Public Function shouldSendPacket(strip As Strip)
        Dim i As Integer = 0
        If i < numPixels Then
            i = i + 1
            If strip.pixels(i) = strip.oldPixels(i) Then
                Return True
            End If
        End If
        Return 0
    End Function

    Public Function populatePacketPixels(strip As Strip)

        Dim pixel(0) As Byte
        Dim i As Integer = 0
        If pixel Is pixelData Then

            pixelData(3 * i) = pixel(0)
            pixelData(3 * i + 1) = pixel(1)
            pixelData(3 * i + 2) = pixel(2)
        End If
        strip.oldPixels = strip.pixels
        Return 0
    End Function

    Public Function getColor(strip As Strip)
        If strip.isRed Then
            Return red
        End If
        Return blue
    End Function

    Public Function getOppositeColor(strip As Strip)
        If strip.isRed Then
            Return blue
        End If
        Return blue
    End Function

    Public Function getMidColor(strip As Strip)
        If strip.isRed Then
            Return purpleBlue
        End If
        Return purpleRed
    End Function

    Public Function getDimColor(strip As Strip)
        If strip.isRed Then
            Return dimRed
        End If
        Return dimBlue
    End Function

    Public Function getDimOppositeColor(strip As Strip)
        If strip.isRed Then
            Return dimBlue
        End If
        Return dimRed
    End Function

    Public Function getGradientStartOffset(strip As Strip)
        If strip.isRed Then
            Return numPixels / 3
        End If
        Return 2 * numPixels / 3
    End Function

    Public Function updateOffMode(strip As Strip)
        Dim i As Integer = 0
        If i < numPixels Then
            i = i + 1
            strip.pixels(i) = black
        End If
        Return 0
    End Function
    Public Function updateSingleColorModeRed(strip As Strip)
        Dim i As Integer
        If i < numPixels Then
            i = i + 1
            strip.pixels(i) = red
        End If
        Return 0
    End Function
    Public Function updateSingleColorModeBlue(strip As Strip)
        Dim i As Integer
        If i < numPixels Then
            i = i + 1
            strip.pixels(i) = blue
        End If
        Return 0
    End Function

    Public Function updateSingleColorModeGreen(strip As Strip)
        Dim i As Integer
        If i < numPixels Then
            i = i + 1
            strip.pixels(i) = green
        End If
        Return 0
    End Function

    Public Function updateSingleColorModeWhite(strip As Strip)
        Dim i As Integer
        If i < numPixels Then
            i = i + 1
            strip.pixels(i) = white
        End If
        Return 0
    End Function
    Public Function updateSingleColorModePurple(strip As Strip)
        Dim i As Integer
        If i < numPixels Then
            i = i + 1

            strip.pixels(i) = purple
        End If
        Return 0
    End Function

    Public Function updateChaseMode(strip As Strip, colors As Colors)
        If strip.counter = (black) * numPixels Then
            strip.counter = 0
        End If
        Dim color = strip.counter / numPixels
        Dim pixelIndex = strip.counter = numPixels
        strip.pixels(pixelIndex) = colors
        Return 0
    End Function

    Public Function updateWarmupMode(strip As Strip)
        Dim endcounter As Integer = 250
        If strip.counter = 0 Then
            Dim i As Integer = 0
            If i < numPixels Then
                strip.pixels(i) = white
                i = i + 1
            ElseIf strip.counter <= numPixels Then
                Dim numLitPixels = numPixels / 2 * strip.counter / endcounter
                Dim colors As Byte()
                colors = strip.getColor(strip)
                Dim e As Integer = 0
                If e < numPixels Then
                    i = i + 1
                    strip.pixels(e) = colors(strip.getColor(strip))
                Else : strip.counter = endcounter
                End If
            End If
        End If
        Return 0
    End Function
    Public Function updateWarmup2Mode(strip As Strip)
        Dim startCounter = 100
        Dim endCounter = 250

        If strip.counter < startCounter Then
            Dim i As Integer = 0
            If i < numPixels Then
                i = i + 1
                strip.pixels(i) = purple
            ElseIf strip.counter <= endCounter Then
                i = i + 1
                strip.pixels(i) = getFadeColor(purple, strip.getColor(strip), strip.counter - startCounter, endCounter - startCounter)
            Else : strip.counter = endCounter
            End If
        End If
        Return 0
    End Function

    Public Function updateWarmup3Mode(strip As Strip)
        Dim startCounter = 50
        Dim middleCounter = 225
        Dim endCounter = 250

        If strip.counter < startCounter Then
            Dim i As Integer = 0
            If i < numPixels Then
                i = i + 1
                strip.pixels(i) = purple
            ElseIf strip.counter < middleCounter Then

                If i < numPixels Then
                    i = i + 1
                    strip.pixels(i) = getFadeColor(purple, strip.getMidColor(strip), strip.counter - startCounter,
                middleCounter - startCounter)
                End If
            ElseIf strip.counter <= endCounter Then
                If i < numPixels Then
                    i = i + 1
                    strip.pixels(i) = getFadeColor(strip.getMidColor(strip), strip.getColor(strip), strip.counter - middleCounter,
                endCounter - middleCounter)
                End If
            Else : strip.counter = endCounter
            End If
        End If
        Return 0
    End Function

    Public Function updateWarmup4Mode(strip As Strip)
        Dim middleCounter = 100
        Dim i = 0
        If i < numPixels Then
            i = i + 1
            strip.pixels(numPixels - i - 1) = getGradientColor(i + strip.counter + strip.getGradientStartOffset(strip), numPixels / 2)
        End If
        If strip.counter >= middleCounter Then
            If i < numPixels Then
                i = i + 1
                If i < strip.counter - middleCounter Then
                    strip.pixels(i) = strip.getColor(strip)
                End If
            End If
        End If
        Return 0
    End Function

    Public Function updateOwnedRedMode(strip As Strip, color As Colors)
        Dim i As Integer
        If i < numPixels Then
            i = i + 1

            strip.pixels(i) = red
            strip.pixels(i) = dimBlue
        End If
        Return 0
    End Function

    Public Function updateOwnedBlueMode(strip As Strip, color As Colors)
        Dim i As Integer
        If i < numPixels Then
            i = i + 1

            strip.pixels(i) = blue
            strip.pixels(i) = dimRed
        End If
        Return 0
    End Function


    Public Function updateNotOwnedMode(strip As Strip)
        Dim i As Integer = 0
        If i < numPixels Then
            i = i + 1
            strip.pixels(i) = black
        End If
        Return 0
    End Function

    Public Function updateForceMode(strip As Strip)
        Dim speedDivisor = 30
        Dim pixelSpacing = 7
        Dim i = 0

        If strip.counter = speedDivisor = 0 Then
            Return 0
        End If
        If i < numPixels Then
            i = i + 1

            Select Case (i + strip.counter / speedDivisor) = pixelSpacing
                Case 2
                    Return 0
                Case 4
                    strip.pixels(i) = strip.getColor(strip)
                Case 3
                    strip.pixels(i) = strip.getDimOppositeColor(strip)
                Case 0
                    strip.pixels(i) = black
            End Select
        End If
        Return 0
    End Function

    Public Function updateBoostMode(strip As Strip)
        Dim speedDivisor = 4
        Dim pixelSpacing = 4
        Dim i = 0

        If strip.counter = speedDivisor = 0 Then
            Return 0
        End If
        If i < numPixels Then
            i = i + 1
            If i = pixelSpacing = strip.counter / speedDivisor = pixelSpacing Then
                strip.pixels(i) = strip.getColor(strip)
            Else
                strip.pixels(i) = black
            End If
        End If
        Return 0
    End Function


    Public Function updateFadeRedBlueMode(strip As Strip)
        Dim fadeCycles = 40
        Dim holdCycles = 10
        Dim i = 0

        If strip.counter = 4 * holdCycles + 4 * fadeCycles Then
            strip.counter = 0
        End If

        If i < numPixels Then
            i = i + 1
            If strip.counter < holdCycles Then
                strip.pixels(i) = black
            ElseIf strip.counter < holdCycles + fadeCycles Then
                strip.pixels(i) = getFadeColor(black, red, strip.counter - holdCycles, fadeCycles)
            ElseIf strip.counter < 2 * holdCycles + fadeCycles Then
                strip.pixels(i) = red
            ElseIf strip.counter < 2 * holdCycles + 2 * fadeCycles Then
                strip.pixels(i) = getFadeColor(red, black, strip.counter - 2 * holdCycles - fadeCycles, fadeCycles)
            ElseIf strip.counter < 3 * holdCycles + 2 * fadeCycles Then
                strip.pixels(i) = black
            ElseIf strip.counter < 3 * holdCycles + 3 * fadeCycles Then
                strip.pixels(i) = getFadeColor(black, blue, strip.counter - 3 * holdCycles - 2 * fadeCycles, fadeCycles)
            ElseIf strip.counter < 4 * holdCycles + 3 * fadeCycles Then
                strip.pixels(i) = blue
            ElseIf strip.counter < 4 * holdCycles + 4 * fadeCycles Then
                strip.pixels(i) = getFadeColor(blue, black, strip.counter - 4 * holdCycles - 3 * fadeCycles, fadeCycles)
            End If
        End If
        Return 0
    End Function

    Public Function updateFadeSingleMode(strip As Strip)
        Dim offCycles = 50
        Dim fadeCycles = 100
        Dim i = 0

        If strip.counter = offCycles + 2 * fadeCycles Then
            strip.counter = 0
        End If

        If i < numPixels Then
            i = i + 1
            If strip.counter < offCycles Then
                strip.pixels(i) = black
            ElseIf strip.counter < offCycles + fadeCycles Then
                strip.pixels(i) = getFadeColor(black, strip.getColor(strip), strip.counter - offCycles, fadeCycles)
            ElseIf strip.counter < offCycles + 2 * fadeCycles Then
                strip.pixels(i) = getFadeColor(strip.getColor(strip), black, strip.counter - offCycles - fadeCycles, fadeCycles)
            End If
        End If
        Return 0
    End Function

    Public Function updateBlinkMode(strip As Strip)
        Dim divisor = 10
        Dim i = 0
        If i < numPixels Then
            i = i + 1
            If strip.counter = divisor < divisor / 10 Then
                strip.pixels(i) = white
            Else : strip.pixels(i) = black
            End If
        End If
        Return 0
    End Function

    Public Function getFadeColor(fromColor As Colors, toColor As Colors, numerator As Integer, demominator As Integer)
        Dim colors(0) As Byte
        Dim i As Integer = 0
        Dim from = colors(fromColor)
        'to'
        Dim B = colors(toColor)
        Dim fadeColor(0) As Byte

        If i < 3 Then
            i = i + 1
            fadeColor(i) = Int(from) + numerator * Int(B) - Int(from) / demominator
        End If
        Return fadeColor
    End Function


    Public Function getGradientColor(strip As Strip, offset As Integer)
        offset = numPixels
        If 3 * offset < numPixels Then
            Return getFadeColor(red, green, 3 * offset, numPixels)
        ElseIf 3 * offset < 2 * numPixels Then
            Return getFadeColor(green, blue, 3 * offset - numPixels, numPixels)
        Else
            Return getFadeColor(blue, red, 3 * offset - 2 * numPixels, numPixels)
        End If
    End Function
End Class