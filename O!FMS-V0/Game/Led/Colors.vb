Imports System.Drawing.Color
Imports O_FMS_V0

Public Class Colors
    Public Shared red As New Color
    Public Shared orange As New Color
    Public Shared yellow As New Color
    Public Shared green As New Color
    Public Shared teal As New Color
    Public Shared blue As New Color
    Public Shared purple As New Color
    Public Shared white As New Color
    Public Shared black As New Color
    Public Shared purpleRed As New Color
    Public Shared purpleBlue As New Color
    Public Shared dimRed As New Color
    Public Shared dimBlue As New Color

    Public Shared Sub getColors(colors As Colors)
        red = ColorTranslator.fromHtml("#ff0000")
        orange = ColorTranslator.fromHtml("#ffa500")
        yellow = ColorTranslator.fromHtml("#ffff00")
        green = ColorTranslator.fromHtml("#00b300")
        teal = ColorTranslator.fromHtml("")
        blue = ColorTranslator.fromHtml("")
        purple = ColorTranslator.fromHtml("")
        white = ColorTranslator.fromHtml("")
        black = ColorTranslator.fromHtml("#000000")
        purpleRed = ColorTranslator.fromHtml("")
        purpleBlue = ColorTranslator.fromHtml("")
        dimRed = ColorTranslator.fromHtml("")
        dimBlue = ColorTranslator.fromHtml("")
    End Sub

End Class

