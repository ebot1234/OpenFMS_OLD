Imports EasyModbus
Imports System.Threading.Thread

Public Class PLC
    'PLC Constants'
    Public IP As String
    Public Port As Integer
    Public client As ModbusClient
    Public PLC_Timeout_Ms As Integer = 100

    'Registers'
    Public registerCount
    Public redLowerHubBlue
    Public redLowerHubFar
    Public redLowerHubNear
    Public redLowerHubRed
    Public redUpperHubBlue
    Public redUpperHubFar
    Public redUpperHubNear
    Public redUpperHubRed
    Public blueLowerHubBlue
    Public blueLowerHubFar
    Public blueLowerHubNear
    Public blueLowerHubRed
    Public blueUpperHubBlue
    Public blueUpperHubFar
    Public blueUpperHubNear
    Public blueUpperHubRed


    'Inputs'
    Public inputCount
    Public fieldEstop
    Public redEstop1
    Public redEstop2
    Public redEstop3
    Public blueEstop1
    Public blueEstop2
    Public blueEstop3

    'Coils'
    Public coilCount
    Public heartbeat
    Public matchReset
    Public stackLightGreen
    Public stackLightOrange
    Public stackLightRed
    Public stackLightBlue
    Public stackLightBuzzer
    Public fieldResetLight
    Public hubMotorsState
    Public hubMotorsDirection


    'Creates new PLC instance'
    Public Sub New(ByVal ip As String, ByVal port As Integer)
        client = New ModbusClient(ip, port)
        ip = ip
        port = port
    End Sub

    'Connect PLC'
    Public Sub Connect()
        If client.Connected = False Then
            client.Connect()
        Else
            MessageBox.Show("PLC is already connected")
            client.Disconnect()
            client.Connect()
        End If
    End Sub

    'Updates all PLC values'
    Public Function Run()
        While True
            If client.Connected = False Then
                'Add PLC Watchdog'
            End If

            ReadInputs()
            ReadRegisters()
            WriteCoils()

            Sleep(PLC_Timeout_Ms)

        End While

        Return 0
    End Function

    'Reads PLC Registers (Scoring Counts)
    Public Sub ReadRegisters()

    End Sub

    'Reads PLC Inputs (Buttons)'
    Public Sub ReadInputs()
        fieldEstop = client.ReadInputRegisters(0, 1)
        redEstop1 = client.ReadInputRegisters(1, 1)
        redEstop2 = client.ReadInputRegisters(2, 1)
        redEstop3 = client.ReadInputRegisters(3, 1)
        blueEstop1 = client.ReadInputRegisters(4, 1)
        blueEstop2 = client.ReadInputRegisters(5, 1)
        blueEstop3 = client.ReadInputRegisters(6, 1)
    End Sub

    'Writes PLC Coils (Outputs)'
    Public Sub WriteCoils()
        client.WriteSingleCoil(0, matchReset)
        client.WriteSingleCoil(1, stackLightGreen)
        client.WriteSingleCoil(2, stackLightOrange)
        client.WriteSingleCoil(3, stackLightRed)
        client.WriteSingleCoil(4, stackLightBlue)
        client.WriteSingleCoil(5, stackLightBuzzer)
        client.WriteSingleCoil(6, fieldResetLight)
        client.WriteSingleCoil(7, hubMotorsState)
        client.WriteSingleCoil(8, hubMotorsDirection)
    End Sub

End Class
