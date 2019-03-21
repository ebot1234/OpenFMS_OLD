Imports System.Threading

Public Class Switch
    Public Shared switchTelnetPort As Integer = 23

    Public Shared Red1VLAN = 10
    Public Shared Red2VLAN = 20
    Public Shared Red3VLAN = 30
    Public Shared Blue1VLAN = 40
    Public Shared Blue2VLAN = 50
    Public Shared Blue3VLAN = 60

    Public Shared address As String
    Public Shared port As Integer
    Public Shared password As String
    Public Shared mutex As New Mutex

    Public Shared serverIP As String = "10.0.100.5"

    Public Shared Function newSwitch(address As String, password As String)
        Return address And port And password
    End Function

End Class
