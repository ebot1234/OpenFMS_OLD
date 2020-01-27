Imports EasyModbus
Imports OpenFMS.GameSpecificData
Imports OpenFMS.Arena

Public Class PLC
    'PLC Varibles'
    Public MB_Estop_Addresses As Integer() = {0, 1, 2, 3, 4, 5} 'Estops Modbus Addresses'
    Public MB_Coil_Addresses As Integer() = {0, 1, 2, 3, 4, 5} 'Default Year to Year Addresses'
    Public MB_Register_Addresses As Integer() = {0, 1, 2, 3, 4, 5, 6} 'ViewMarq Addresses'
    Public MB_Year_Specific_Coils As Integer() = {40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54}
    Public PLC_Address As String
    Public PLC_Client As ModbusClient

    'Match Control Varibles'
    Public Match_Start As Boolean
    Public Match_Auto As Boolean
    Public Match_Tele As Boolean
    Public Match_EndGame As Boolean
    Public Match_End As Boolean
    Public Match_Aborted As Boolean

    'Estop Data From PLC'
    Public R1_Estop As Boolean()
    Public R2_Estop As Boolean()
    Public R3_Estop As Boolean()
    Public B1_Estop As Boolean()
    Public B2_Estop As Boolean()
    Public B3_Estop As Boolean()

    'ViewMarq (Team Sign) Varibles'
    Public Match_Time As Integer
    Public Red1_Number As Integer
    Public Red2_Number As Integer
    Public Red3_Number As Integer
    Public Blue1_Number As Integer
    Public Blue2_Number As Integer
    Public Blue3_Number As Integer

    'Year-Specific Counters'
    Public Red_Inner_Port_Count As Integer
    Public Red_Outer_Port_Count As Integer
    Public Red_Lower_Port_Count As Integer
    Public Blue_Inner_Port_Count As Integer
    Public Blue_Outer_Port_Count As Integer
    Public Blue_Lower_Port_Count As Integer

    'Year-Specific Coils'
    Public R1_Initiation_Line_Crossed As Boolean
    Public R2_Initiation_Line_Crossed As Boolean
    Public R3_Initiation_Line_Crossed As Boolean
    Public B1_Initiation_Line_Crossed As Boolean
    Public B2_Initiation_Line_Crossed As Boolean
    Public B3_Initiation_Line_Crossed As Boolean
    Public Red_Generator_Balenced As Boolean
    Public Blue_Generator_Balenced As Boolean
    Public Red_Rotation_Completed As Boolean
    Public Blue_Rotation_Completed As Boolean
    Public Red_Position_Completed As Boolean
    Public Blue_Position_Completed As Boolean
    Public R1_Hanging As Boolean
    Public R2_Hanging As Boolean
    Public R3_Hanging As Boolean
    Public B1_Hanging As Boolean
    Public B2_Hanging As Boolean
    Public B3_Hanging As Boolean
    Public R1_Parked As Boolean
    Public R2_Parked As Boolean
    Public R3_Parked As Boolean
    Public B1_Parked As Boolean
    Public B2_Parked As Boolean
    Public B3_Parked As Boolean



    Public Sub Run()
        'Create a new Modbus Client'
        PLC_Client = New ModbusClient(PLC_Address, 502)
        'Connect to PLC via ModbusTCP Client'
        PLC_Client.Connect()
        'Loop for reading and writing I/O while PLC is connected'
        While PLC_Client.Connected
            WriteCoils()
            WriteRegisters()
            ReadCoils()
        End While
    End Sub

    Public Sub WriteCoils()

    End Sub

    Public Sub WriteRegisters()
        PLC_Client.WriteSingleRegister(MB_Register_Addresses(0), Match_Time)
        PLC_Client.WriteSingleRegister(MB_Register_Addresses(1), Red1_Number)
        PLC_Client.WriteSingleRegister(MB_Register_Addresses(2), Red2_Number)
        PLC_Client.WriteSingleRegister(MB_Register_Addresses(3), Red3_Number)
        PLC_Client.WriteSingleRegister(MB_Register_Addresses(4), Blue1_Number)
        PLC_Client.WriteSingleRegister(MB_Register_Addresses(5), Blue2_Number)
        PLC_Client.WriteSingleRegister(MB_Register_Addresses(6), Blue3_Number)
    End Sub

    Public Sub ReadCoils()
        'Reads PLC Estop Buttons'
        R1_Estop = PLC_Client.ReadCoils(MB_Estop_Addresses(0), 1)
        R2_Estop = PLC_Client.ReadCoils(MB_Estop_Addresses(1), 1)
        R3_Estop = PLC_Client.ReadCoils(MB_Estop_Addresses(2), 1)
        B1_Estop = PLC_Client.ReadCoils(MB_Estop_Addresses(3), 1)
        B2_Estop = PLC_Client.ReadCoils(MB_Estop_Addresses(4), 1)
        B3_Estop = PLC_Client.ReadCoils(MB_Estop_Addresses(5), 1)

        'Reads Generator Sensors'
        Red_Rotation_Completed = PLC_Client.ReadCoils()
    End Sub
End Class
