Public Class DV
    Private _ID_DV As Integer
    Public Property ID_DV() As Integer
        Get
            Return _ID_DV
        End Get
        Set(ByVal value As Integer)
            _ID_DV = value
        End Set
    End Property

    Private _NOMBRETABLA As String
    Public Property NOMBRETABLA() As String
        Get
            Return _NOMBRETABLA
        End Get
        Set(ByVal value As String)
            _NOMBRETABLA = value
        End Set
    End Property

    Private _DVV As Integer
    Public Property DVV() As Integer
        Get
            Return _DVV
        End Get
        Set(ByVal value As Integer)
            _DVV = value
        End Set
    End Property


End Class
