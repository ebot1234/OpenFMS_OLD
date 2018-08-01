Imports O_FMS_V0.Colors
Imports O_FMS_V0.Modes
Imports O_FMS_V0.Controller
Imports O_FMS_V0

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


    Function updatePixels(strip As Strip)
        Select Case (strip.currentMode)
            Case RedMode
                updateSingleColorModeRed()
            Case GreenMode
                strip.updateSingleColorModeGreen()
            Case BlueMode
                strip.updateSingleColorModeBlue
            Case WhiteMode
                strip.updateSingleColorModeWhite
            Case PurpleMode
                strip.updateSingleColorModePurple
            Case ChaseMode
                strip.updateChaseMode()
            Case WarmupMode
                strip.updateWarmupMode()
            Case Warmup2Mode
                strip.updateWarmup2Mode()
            Case Warmup3Mode
                strip.updateWarmup3Mode()
            Case Warmup4Mode
                strip.updateWarmup4Mode()
            Case OwnedMode
                strip.updateOwnedMode()
            Case NotOwnedMode
                strip.updateNotOwnedMode()
            Case ForceMode
                strip.updateForceMode()
            Case BoostMode
                strip.updateBoostMode()
            Case RandomMode
                strip.updateRandomMode()
            Case FadeRedBlueMode
                strip.updateFadeRedBlueMode()
            Case FadeSingleMode
                strip.updateFadeSingleMode()
            Case GradientMode
                strip.updateGradientMode()
            Case BlinkMode
                strip.updateBlinkMode()
            Case offMode
                strip.updateOffMode()
        End Select
        strip.counter = counter + 1
        Return strip
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

    Public Function populatePacketPixels(strip As Strip, pixelData As Byte())

        Dim pixel
        Dim i As Integer = 0
        For i = 0 & pixel Is strip.pixels
                Next
        pixelData(3 * i) = pixel(0)
        pixelData(3 * i + 1) = pixel(1)
        pixelData(3 * i + 2) = pixel(2)

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

    Public Function updateOffMode(strip As Strip, color As Colors)
        Dim i As Integer = 0
        If i < numPixels Then
            i = i + 1
            strip.pixels(i) = black
        End If
        Return 0
    End Function
    Public Function updateSingleColorModeRed(strip As Strip, color As Colors)
        Return color.red
    End Function
    Public Function updateSingleColorModeBlue(strip As Strip, color As Colors)
        Return color.blue
    End Function

    Public Function updateSingleColorModeGreen(strip As Strip, color As Colors)
        Return color.green
    End Function
    Public Function updateSingleColorMode(strip As Strip, color As Colors)
        Dim i As Integer = 0
        If i < numPixels Then
            i = i + 1
            strip.pixels(i) = red
            strip.pixels(i) = green
            strip.pixels(i) = blue
            strip.pixels(i) = white
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
        Dim endCounter As Integer = 250

        If strip.counter = 0 Then
            Dim i = 0
            If i < numPixels Then
                strip.pixels(i) = white
                i = i + 1
            End If
        ElseIf strip.counter <= endCounter Then
            Dim numLitPixels = numPixels / 2 * strip.counter / endCounter
            Dim colors As Byte
            Dim i As Integer = 0
            If i < numPixels Then
                i = i + 1
                strip.pixels(i) = 
            End If

        End If
    End Function
End Class

