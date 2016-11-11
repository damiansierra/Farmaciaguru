Public Class Usuario

    Public Property IdUsuario As Integer
    Public Property Nick As String
    Public Property Nombre As String
    Public Property Apellido As String
    Public Property Password As String
    Public Property Cant_Int As Integer
    Public Property Baja As Boolean
    Public Property Patentes As List(Of BE.Patente)
    Public Property Familias As List(Of BE.Familia)

    Public Property bloqueado As Boolean





    Private mPasswordModificado As Boolean
    Public ReadOnly Property PasswordModificado As Boolean
        Get
            Return mPasswordModificado
        End Get
    End Property
End Class
