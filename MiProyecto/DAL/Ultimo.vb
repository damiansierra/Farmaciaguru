Public Class Ultimo


    Private Shared _instancia As DAL.Ultimo
    Public Shared Function GetInstance() As DAL.Ultimo
        If _instancia Is Nothing Then
            _instancia = New DAL.Ultimo
        End If
        Return _instancia
    End Function


    Public Function pasarstring(ByVal con As String) As String

        Return DAL.Seguridad.EncriptarReversible(con)
    End Function


    Public Function ValidarServidor(ByVal dataSource As String) As Boolean
        Dim connString = "Data Source=" + dataSource + ";Initial Catalog=farmacia;Integrated Security=True"
        Dim SqlConn As New SqlClient.SqlConnection With {.ConnectionString = connString}
        Try
            If dataSource <> "" Then
                SqlConn.Open()
                SqlConn.Close()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
