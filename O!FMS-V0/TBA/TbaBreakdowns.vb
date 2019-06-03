
Public Class TbaBreakdowns

    'Match Breakdown'
    Public Class Match
        Private m_comp_level As String
        Public Property comp_level() As String
            Get
                Return m_comp_level
            End Get

            Set(value As String)
                m_comp_level = value
            End Set
        End Property
        Private m_set_number As Integer
        Public Property set_number() As Integer
            Get
                Return m_set_number
            End Get

            Set(value As Integer)
                m_set_number = value
            End Set
        End Property
        Private m_match_number As Integer
        Public Property match_number() As Integer
            Get
                Return m_match_number
            End Get
            Set(value As Integer)
                m_match_number = value
            End Set
        End Property
        Public alliances As String
        ' Private m_alliances As List(Of List(Of String))
        'Public Property alliances As List(Of List(Of String))
        'Get
        'Return m_alliances
        'End Get
        'Set(ByVal value As List(Of List(Of String)))
        '      m_alliances = value
        'End Set
        'End Property
        Private m_scoreBreakdown As List(Of String)
        Public Property score_breakdown As List(Of String)
            Get
                Return m_scoreBreakdown
            End Get
            Set(value As List(Of String))
                m_scoreBreakdown = value
            End Set
        End Property
        Private m_time As String
        Public Property time_string As String
            Get
                Return m_time
            End Get
            Set(value As String)
                m_time = value
            End Set
        End Property
        Private m_timeUtc As String
        Public Property timeUtc As String
            Get
                Return m_timeUtc
            End Get
            Set(value As String)
                m_timeUtc = value
            End Set
        End Property
    End Class

    'Alliance Breakdown'
    Public Class TbaAlliance
        Private m_color As String
        Public Property color As String
            Get
                Return m_color
            End Get
            Set(value As String)
                m_color = value
            End Set
        End Property
        Private m_teams As String
        Public Property teams() As String
            Get
                Return m_teams
            End Get
            Set(value As String)
                m_teams = value
            End Set
        End Property
        Private m_surrogates As List(Of String)
        Public Property surrogates As List(Of String)
            Get
                Return m_surrogates
            End Get
            Set(value As List(Of String))
                m_surrogates = value
            End Set
        End Property
        Private m_Dqs As List(Of String)
        Public Property Dqs As List(Of String)
            Get
                Return m_Dqs
            End Get
            Set(value As List(Of String))
                m_Dqs = value
            End Set
        End Property
        Private m_score As Integer
        Public Property score As Integer
            Get
                Return m_score
            End Get
            Set(value As Integer)
                m_score = value
            End Set
        End Property
    End Class

    Public Class ScoreBreakdown
        'Add the 2019 scorebreakdown'
    End Class
End Class
