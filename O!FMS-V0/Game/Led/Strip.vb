'Imports Microsoft.VisualBasic
'Imports O_FMS_V0.Colors
'Imports O_FMS_V0.Controller
'Imports O_FMS_V0.FieldAndRobots
'Imports O_FMS_V0.PLC_Receiver
'Public Class Strip

'    Private mode As Modes = New Modes

'    Private pixels() As Byte

'    Private isRed As Boolean

'    Private strip As String

'    Private oldPixels() As Byte

'    Private numPixels As Integer = 150

'    ' private static final byte pixels = "pixels".getBytes()[0];
'    ' private static final byte oldpixels = "oldPixels".getBytes()[0];
'    Public Sub New()
'        MyBase.New()
'        Me.pixels = New Byte(((Me.numPixels * 3)) - 1) {}
'        Me.oldPixels = New Byte(((Me.numPixels * 3)) - 1) {}
'    End Sub

'    Public Sub updatePixels()
'        Select Case (Me.strip)
'            Case "RedMode"
'                Me.strip.updateSingleColorMode(red)
'            Case "GreenMode"
'                Me.strip.updateSingleColorMode(green)
'            Case "BlueMode"
'                Me.strip.updateSingleColorMode(blue)
'            Case "WhiteMode"
'                Me.strip.updateSingleColorMode(white)
'            Case "ChaseMode"
'                Me.strip.updateChaseMode()
'            Case "WarmupMode"
'                Me.strip.updateWarmupMode()
'            Case "Warmup2Mode"
'                Me.strip.updateWarmup2Mode()
'            Case "Warmup3Mode"
'                Me.strip.updateWarmup3Mode()
'            Case "Warmup4Mode"
'                Me.strip.updateWarmup4Mode()
'            Case "OwnedMode"
'                Me.strip.updateOwnedMode()
'            Case "NotOwnedMode"
'                Me.strip.updateNotOwnedMode()
'            Case "ForceMode"
'                Me.strip.updateForceMode()
'            Case "BoostMode"
'                Me.strip.updateBoostMode()
'            Case "RandomMode"
'                Me.strip.updateRandomMode()
'            Case "FadeMode"
'                Me.strip.updateFadeMode()
'            Case "GradientMode"
'                Me.strip.updateGradientMode()
'            Case "BlinkMode"
'                Me.strip.updateBlinkMode()
'            Case Else
'                Me.strip.updateOffMode()
'        End Select

'    End Sub

'    Public Function shouldSendPacket(ByVal pixelData() As Byte) As Boolean
'        Dim i As Integer = 0
'        Do While (i < Me.numPixels)
'            Dim pixel() As Byte = New Byte((9) - 1) {}
'            If (pixel(i) = Me.oldPixels) Then
'                Return True
'            End If

'            i = (i + 1)
'        Loop

'        Return False
'    End Function

'    Public Sub populatePacketPixels(ByVal pixelData() As Byte)
'        Dim i As Integer = 0
'        Do While (i < 9)
'            Dim pixel() As Byte = New Byte((9) - 1) {}
'            pixel(i) = 0
'            pixel(0) = pixelData((3 * i))
'            pixel(1) = pixelData(((3 * i) _
'                        + 1))
'            pixel(2) = pixelData(((3 * i) _
'                        + 2))
'            i = (i + 1)
'        Loop

'    End Sub

'    Public Function getColor(ByVal Unknown As Colors) As Boolean
'        If PLC_Aux.PLC_Recevier.dataStr.substring(1).equals("LLL") Then

'        Else

'        End If

'        Return blue
'    End Function

'    Public Sub getOppositeColor(ByVal Unknown As Color)
'        If Me.strip.isRed Then
'            Return blue
'        End If

'        Return red
'    End Sub

'    Public Sub getMidColor(ByVal Unknown As Color)
'        If Me.strip.isRed Then
'            Return purpleBlue
'        Else
'            purpleRed()
'        End If

'    End Sub
'End Class
''If strip.isRed Then
''    Return (numPixels / 3)
''End If

''Return (2  _
''            * (numPixels / 3))
''Unknownfpublic


'Public Sub getDimColor(ByVal Unknown As Color)
'    If strip.isRed Then
'        Return dimRed
'    End If

'    Return dimBlue
'End Sub

'Public Sub getGradientStartOffset()
'End Sub

'Public Sub updateOffMode()
'i:
'        Do While 

'    Loop

'0:
'        (i < numPixels)
'    i = (i + 1)
'    strip.pixels(i) = colors(black)
'End Sub

'Public Sub updateSingleColorMode(ByVal color As color)
'i:
'        Do While 

'    Loop

'0:
'        (i < numPixels)
'    i = (i + 1)
'    strip.pixels(i) = colors(color)
'End Sub

'Public Sub updateChaseMode()
'    If (strip.counter _
'                = (int(black) * numPixels)) Then
'        ' Ignore colors listed after white.
'        strip.counter = 0
'    End If

'color:
'    color((strip.counter / numPixels))
'pixelIndex:
'        (strip.counter Mod numPixels)
'    strip.pixels(pixelIndex) = colors(color)
'End Sub

'Public Sub updateWarmupMode()
'endCounter:
'250:
'    If (strip.counter = 0) Then
'        ' Show solid white to start.
'i:
'            Do While 

'        Loop

'0:
'            (i < numPixels)
'        i = (i + 1)
'        strip.pixels(i) = colors(white)
'    ElseIf (strip.counter <= endCounter) Then
'        ' Build to the alliance color from each side.
'numLitPixels:
'            (numPixels / (2  _
'                        * (strip.counter / endCounter)))
'i:
'            Do While 

'        Loop

'0:
'            (i < numLitPixels)
'        i = (i + 1)
'        strip.pixels(i) = colors(strip.getColor)
'        strip.pixels((numPixels _
'                    - (i - 1))) = colors(strip.getColor)
'    Else
'        ' Prevent the counter from rolling over.
'        strip.counter = endCounter
'    End If

'End Sub

'Public Sub updateWarmup2Mode()
'startCounter:
'100:
'endCounter:
'250:
'    If (strip.counter < startCounter) Then
'        ' Show solid purple to start.
'i:
'            Do While 

'        Loop

'0:
'            (i < numPixels)
'        i = (i + 1)
'        strip.pixels(i) = colors(purple)
'    ElseIf (strip.counter <= endCounter) Then
'i:
'            Do While 

'        Loop

'0:
'            (i < numPixels)
'        i = (i + 1)
'        strip.pixels(i) = getFadeColor(purple, strip.getColor, (strip.counter - startCounter), (endCounter - startCounter))
'    Else
'        ' Prevent the counter from rolling over.
'        strip.counter = endCounter
'    End If

'End Sub

'Public Sub updateWarmup3Mode()
'startCounter:
'50:
'middleCounter:
'225:
'endCounter:
'250:
'    If (strip.counter < startCounter) Then
'        ' Show solid purple to start.
'i:
'            Do While 

'        Loop

'0:
'            (i < numPixels)
'        i = (i + 1)
'        strip.pixels(i) = colors(purple)
'    ElseIf (strip.counter < middleCounter) Then
'i:
'            Do While 

'        Loop

'0:
'            (i < numPixels)
'        i = (i + 1)
'        strip.pixels(i) = getFadeColor(purple, strip.getMidColor, (strip.counter - startCounter), (middleCounter - startCounter))
'    ElseIf (strip.counter <= endCounter) Then
'i:
'            Do While 

'        Loop

'0:
'            (i < numPixels)
'        i = (i + 1)
'        strip.pixels(i) = getFadeColor(strip.getMidColor, strip.getColor, (strip.counter - middleCounter), (endCounter - middleCounter))
'    Else
'        ' Maintain the current value and prevent the counter from rolling over.
'        strip.counter = endCounter
'    End If

'End Sub

'Public Sub updateWarmup4Mode()
'middleCounter:
'100:
'i:
'        Do While 

'    Loop

'0:
'        (i < numPixels)
'    i = (i + 1)
'    strip.pixels((numPixels _
'                - (i - 1))) = getGradientColor((i _
'                    + (strip.counter + strip.getGradientStartOffset)), (numPixels / 2))
'    If (strip.counter >= middleCounter) Then
'i:
'            Do While 

'        Loop

'0:
'            (i < numPixels)
'        i = (i + 1)
'        If (i _
'                    < (strip.counter - middleCounter)) Then
'            strip.pixels(i) = colors(strip.getColor)
'        End If

'    End If

'End Sub

'Public Sub updateOwnedMode()
'speedDivisor:
'30:
'pixelSpacing:
'4:
'    If ((strip.counter Mod speedDivisor) _
'                <> 0) Then
'        Return
'    End If

'i:
'        Do While 

'    Loop

'0:
'        (i < numPixels)
'    i = (i + 1)
'    If ((i Mod pixelSpacing) _
'                = (strip.counter _
'                / (speedDivisor Mod pixelSpacing))) Then
'        strip.pixels(i) = colors(strip.getColor)
'    Else
'        strip.pixels(i) = colors(black)
'    End If

'End Sub

'Public Sub updateNotOwnedMode()
'i:
'        Do While 

'    Loop

'0:
'        (i < numPixels)
'    i = (i + 1)
'    strip.pixels(i) = colors(strip.getDimColor)
'End Sub

'Public Sub updateForceMode()
'speedDivisor:
'30:
'pixelSpacing:
'7:
'    If ((strip.counter Mod speedDivisor) _
'                <> 0) Then
'        Return
'    End If

'i:
'        Do While 

'    Loop

'0:
'        (i < numPixels)
'    i = (i + 1)
'    Select Case (i)
'            Case , 
'    End Select

'    pixelSpacing()
'2:
'    fallthrough()
'4:
'    strip.pixels(i) = colors(strip.getOppositeColor)
'3:
'    strip.pixels(i) = colors(strip.getDimColor)
'    strip.pixels(i) = colors(black)
'End Sub

'Public Sub updateBoostMode()
'speedDivisor:
'4:
'pixelSpacing:
'4:
'    If ((strip.counter Mod speedDivisor) _
'                <> 0) Then
'        Return
'    End If

'i:
'        Do While 

'    Loop

'0:
'        (i < numPixels)
'    i = (i + 1)
'    If ((i Mod pixelSpacing) _
'                = (strip.counter _
'                / (speedDivisor Mod pixelSpacing))) Then
'        strip.pixels(i) = colors(strip.getColor)
'    Else
'        strip.pixels(i) = colors(black)
'    End If

'End Sub

'Public Sub updateRandomMode()
'    If ((strip.counter Mod 10) _
'                <> 0) Then
'        Return
'    End If

'i:
'        Do While 

'    Loop

'0:
'        (i < numPixels)
'    i = (i + 1)
'    strip.pixels(i) = colors(color(rand.Intn(int(black))))
'End Sub

'Public Sub updateFadeMode()
'fadeCycles:
'40:
'holdCycles:
'10:
'    If (strip.counter _
'                = ((4 * holdCycles) + (4 * fadeCycles))) Then
'        strip.counter = 0
'    End If

'i:
'        Do While 

'    Loop

'0:
'        (i < numPixels)
'    i = (i + 1)
'    If (strip.counter < holdCycles) Then
'        strip.pixels(i) = colors(black)
'    ElseIf (strip.counter _
'                < (holdCycles + fadeCycles)) Then
'        strip.pixels(i) = getFadeColor(black, red, (strip.counter - holdCycles), fadeCycles)
'    ElseIf (strip.counter _
'                < ((2 * holdCycles) _
'                + fadeCycles)) Then
'        strip.pixels(i) = colors(red)
'    ElseIf (strip.counter _
'                < ((2 * holdCycles) + (2 * fadeCycles))) Then
'        strip.pixels(i) = getFadeColor(red, black, (strip.counter _
'                        - ((2 * holdCycles) _
'                        - fadeCycles)), fadeCycles)
'    ElseIf (strip.counter _
'                < ((3 * holdCycles) + (2 * fadeCycles))) Then
'        strip.pixels(i) = colors(black)
'    ElseIf (strip.counter _
'                < ((3 * holdCycles) + (3 * fadeCycles))) Then
'        strip.pixels(i) = getFadeColor(black, blue, (strip.counter _
'                        - ((3 * holdCycles) - (2 * fadeCycles))), fadeCycles)
'    ElseIf (strip.counter _
'                < ((4 * holdCycles) + (3 * fadeCycles))) Then
'        strip.pixels(i) = colors(blue)
'    ElseIf (strip.counter _
'                < ((4 * holdCycles) + (4 * fadeCycles))) Then
'        strip.pixels(i) = getFadeColor(blue, black, (strip.counter _
'                        - ((4 * holdCycles) - (3 * fadeCycles))), fadeCycles)
'    End If

'End Sub

'Private Sub updateGradientMode()
'i:
'        Do While 

'    Loop

'0:
'        (i < numPixels)
'    i = (i + 1)
'    strip.pixels((numPixels _
'                - (i - 1))) = getGradientColor((i + strip.counter), 75)
'End Sub

'Public Sub updateBlinkMode()
'divisor:
'10:
'i:
'        Do While 

'    Loop

'0:
'        (i < numPixels)
'    i = (i + 1)
'    If ((strip.counter Mod divisor) _
'                < (divisor / 2)) Then
'        strip.pixels(i) = colors(white)
'    Else
'        strip.pixels(i) = colors(black)
'    End If

'End Sub