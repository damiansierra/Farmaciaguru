'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''BE
''Pablo Settino
''Backup.vb
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Option Explicit On
Option Strict On

Public Class Backup

    Private _backupId As Integer
    Private _cantidad As Integer
    Private _tamano As Double
    Private _ubicacion As String
    Private _archivo As String

    Public Property BackupId() As Integer
        Get
            Return _backupId
        End Get
        Set(ByVal value As Integer)
            _backupId = value
        End Set
    End Property

    Public Property Cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal Value As Integer)
            _cantidad = Value
        End Set
    End Property

    Public Property Tamano() As Double
        Get
            Return _tamano
        End Get
        Set(ByVal Value As Double)
            _tamano = Value
        End Set
    End Property

    Public Property Ubicacion() As String
        Get
            Return _ubicacion
        End Get
        Set(ByVal Value As String)
            _ubicacion = Value
        End Set
    End Property

    Public Property Archivo() As String
        Get
            Return _archivo
        End Get
        Set(ByVal Value As String)
            _archivo = Value
        End Set
    End Property

End Class