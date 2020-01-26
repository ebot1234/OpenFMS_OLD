Imports EasyModbus.ModbusClient


Public Class PLC
    'Estops to FMS'
    Public Field_Estop_IN As Boolean
    Public Red1Estop_IN As Boolean
    Public Red2Estop_IN As Boolean
    Public Red3Estop_IN As Boolean
    Public Blue1Estop_IN As Boolean
    Public Blue2Estop_IN As Boolean
    Public Blue3Estop_IN As Boolean
    'Estops to PLC'
    Public Field_Estop_OUT As Boolean
    Public Red1Estop_OUT As Boolean
    Public Red2Estop_OUT As Boolean
    Public Red3Estop_OUT As Boolean
    Public Blue1Estop_OUT As Boolean
    Public Blue2Estop_OUT As Boolean
    Public Blue3Estop_OUT As Boolean


    Public PLC_PreStart As Boolean
    Public PLC_MatchStart As Boolean
    Public PLC_AutoMode As Boolean
    Public PLC_TeleMode As Boolean
    Public PLC_Stop As Boolean


    Public Sub WriteCoils()

    End Sub

    Public Sub WriteRegisters()

    End Sub

    Public Sub ReadCoils()

    End Sub

    Public Sub ReadRegisters()

    End Sub

End Class
