Imports System.Net
Public Class ArduinoIps
    Public Shared RedSwitchIP As String = "10.0.0.200"
    Public Shared ScaleIP As String = "10.0.0.201"
    Public Shared BlueSwitchIP As String = "10.0.0.202"
    Public Shared RedSwitchNetwork As IPAddress = IPAddress.Parse(RedSwitchIP)
    Public Shared BlueSwitchNetwork As IPAddress = IPAddress.Parse(BlueSwitchIP)
    Public Shared ScaleNetwork As IPAddress = IPAddress.Parse(ScaleIP)



End Class
