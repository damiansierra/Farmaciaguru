Public Class Ultimo


    Private Shared _instancia As BLL.Ultimo
    Public Shared Function GetInstance() As BLL.Ultimo
        If _instancia Is Nothing Then
            _instancia = New BLL.Ultimo
        End If
        Return _instancia
    End Function

    Public Function pasarstring(ByVal con As String) As String
        Return DAL.Ultimo.GetInstance.pasarstring(con)
    End Function


    Public Function ValidarServidor(ByVal dataSource As String) As Boolean
        Return DAL.Ultimo.GetInstance.ValidarServidor(dataSource)
    End Function
End Class
