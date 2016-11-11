Public Class Usuario
    Implements BE.ICrud(Of BE.Usuario)


    Public Function alta(obj As BE.Usuario) As Boolean Implements BE.ICrud(Of BE.Usuario).alta
        Return DAL.Usuario.GetInstance.alta(obj)
    End Function

    Public Function baja(obj As BE.Usuario) As Boolean Implements BE.ICrud(Of BE.Usuario).baja
        Return DAL.Usuario.GetInstance.baja(obj)
    End Function

    Public Function listarPorId(obj As BE.Usuario) As BE.Usuario Implements BE.ICrud(Of BE.Usuario).listarPorId

    End Function

    Public Function listarTodos() As List(Of BE.Usuario) Implements BE.ICrud(Of BE.Usuario).listarTodos

        Try
            Dim DALUSUARIO As New DAL.Usuario
            Return DALUSUARIO.listarTodos
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function modificacion(obj As BE.Usuario) As Boolean Implements BE.ICrud(Of BE.Usuario).modificacion

    End Function
End Class
