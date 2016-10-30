Public Class Usuario

    Public Property Id As Integer
    Public Property Nick As String
    Public Property Nombre As String
    Public Property Apellido As String
    Public Property Password As String
    Public Property Cant_Int As Integer
    Public Property Baja As Boolean

    Public Property Patentes As List(Of BE.Patente)

    Public Property Familia As List(Of BE.Familia)

End Class
