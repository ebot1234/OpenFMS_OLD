Imports Microsoft.VisualBasic
Imports O_FMS_V0.FieldAndRobots
Imports O_FMS_V0.Msg
Imports System.IO.IOException

Imports System.Net.Sockets.SocketException
Imports System.Net.Sockets
Imports System.IO

Public Class DSReceiver
    'Inherits Thread

    Private sock As DatagramSocket

    Public Sub New()
        MyBase.New()
        Console.Out.Write("***DSReveiver Contructor")
        Try
            ' Tells "sock" to look for packets only on socket 1160
            Me.sock = New DatagramSocket(1160)
        Catch e As SocketException
            ' e.printStackTrace()
            Console.Out.Write("Couldn't setup DS Receiver socket")
        End Try

    End Sub

    <Override()> _
    Public Sub run()
        'All team updates filter through the FieldAndRobots
        Dim FAR As FieldAndRobots = FieldAndRobots.getInstance
        ' Creates a new byte array. This will store the packet data.
        Dim data() As Byte = New Byte((50) - 1) {}
        ' Creates a new DatagramPacket(aka UDP)
        Dim p As DatagramPacket = New DatagramPacket(data, data.Length)

        While Not Me.sock.isClosed
            Try
                If (Not (Me.sock) Is Nothing) Then
                    Me.sock.receive(p)
                    ' Program waits until a new packet is received.
                Else
                    Msg.send("DS Receiver Socket is null...")
                End If

            Catch e As IOException
                ' e.printStackTrace()
            End Try

            Try
                ' Finds the team number from the received packet
                Dim team1 As String = ("" + Integer.Parse((CType(data(4), Integer) + "")))
                Dim team2 As String = ("" + Integer.Parse((CType(data(5), Integer) + "")))
                If (team2.Length < 2) Then
                    team2 = "0".Concat(team2)
                End If

                Dim team As Integer = Integer.Parse((team1 + "".Concat((team2 + ""))))
                ' Gets the robots battery voltage from the packet
                Dim batteryVolts As Double = Double.Parse((DSReceiver.convertInt(CType(data(40), Integer)) + ("." + DSReceiver.convertInt(CType(data(41), Integer)))))
                ' Tells field and robots to update the teams information
                If (Not (FAR) Is Nothing) Then
                    ' FAR.updateRobotStatus(team, batteryVolts, DSReceiver.isRobotCommAlive(CType(data(2), Integer), False))
                End If

            Catch e As Exception
                'e.printStackTrace()
                ' Prints the entire packet that caused an error
                Dim i As Integer = 0
                Do While (i < 50)
                    ' 0xff is needed to prevent byte wrapping
                    ' System.out.print((i + (": " + (Integer.toHexString((data(i) And 255)) + ", "))))
                    'i = (i + 1)
                Loop

                Console.Out.Write("")
            End Try

            ' Resets length of packet in case the length differs
            p.setLength(data.Length)

        End While

        ' End of the while loop
        Msg.send("***THE DS RECEIVER SOCKET HAS BEEN CLOSED***NO MORE DS RECEIVER***")
    End Sub

    Public Sub shutdownSocket()
        If (Not (Me.sock) Is Nothing) Then
            Me.sock.close()
        End If

    End Sub

    Public Shared Function convertInt(ByVal n As Integer) As Integer
        'Return Integer.Parse(Integer.toHexString((n And 255)))
    End Function

    Public Shared Function convertString(ByVal n As Integer) As String
        ' 0x7f is needed to prevent byte wrapping
        'Return Integer.toHexString((n And 127))
    End Function

    Public Shared Function isRobotCommAlive(ByVal state As Integer, ByVal print As Boolean) As Boolean
        Dim alive As Boolean = False
        ' Converts the robot state into a hex String
        Dim conState As String = DSReceiver.convertString(state)
        If print Then
            Msg.send(("ConState: " + conState))
        End If

        'If the DS has connection to a robot it will have one of these values
        ' in it. 5 - Autonomous Disabled 7 - Autonomous Enabled 4 - Teleop
        ' Disabled 6 - Teleop Enabled
        ' ESTOPPED = 8 and/or 0
        If (conState.Equals("8") _
                    OrElse (conState.Equals("0") _
                    OrElse (conState.StartsWith("7") _
                    OrElse (conState.StartsWith("6") _
                    OrElse (conState.StartsWith("5") OrElse conState.StartsWith("4")))))) Then
            If conState.EndsWith("e") Then
                alive = True
            ElseIf conState.EndsWith("0") Then
                alive = False
                ' THIS MIGHT BE A PROBLEM
            Else
                'alive = true;
            End If

        Else

        End If

        Return alive
    End Function
End Class
