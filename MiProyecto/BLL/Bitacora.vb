Public Class Bitacora
    Implements BE.ICrud(Of BE.Bitacora)


    Public Function alta(obj As BE.Bitacora) As Boolean Implements BE.ICrud(Of BE.Bitacora).alta
        Try
            Dim DALBITACORA As New DAL.Bitacora
            Return DALBITACORA.alta(obj)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function baja(obj As BE.Bitacora) As Boolean Implements BE.ICrud(Of BE.Bitacora).baja

    End Function

    Public Function listarPorId(obj As BE.Bitacora) As BE.Bitacora Implements BE.ICrud(Of BE.Bitacora).listarPorId

    End Function

    Public Function listarTodos() As List(Of BE.Bitacora) Implements BE.ICrud(Of BE.Bitacora).listarTodos

    End Function

    Public Function modificacion(obj As BE.Bitacora) As Boolean Implements BE.ICrud(Of BE.Bitacora).modificacion

    End Function
End Class
