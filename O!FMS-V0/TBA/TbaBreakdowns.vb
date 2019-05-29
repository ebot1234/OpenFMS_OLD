Public Class TbaBreakdowns

    'Match Breakdown'
    Public Class Match
        Public Property comp_level() As String
            Get
                Return comp_level
            End Get

            Set(value As String)
                comp_level = value
            End Set
        End Property

        Public Property set_number() As Integer
            Get
                Return set_number
            End Get

            Set(value As Integer)
                set_number = value
            End Set
        End Property

        Public Property match_number() As Integer
            Get
                Return match_number
            End Get
            Set(value As Integer)
                match_number = value
            End Set
        End Property
    End Class
End Class
