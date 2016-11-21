Public Class Patente
    Public Property Idpatente As Integer
    Public Property Nombre As String

    Public Property Descripcion As String

    Public Property DVH As Integer

    Public Property NEGADO As Boolean
    Public Property Usuario As List(Of BE.Usuario)

    Public Property Patente As List(Of BE.Familia)
End Class
