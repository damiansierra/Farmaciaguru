Public Class Familia
    Implements BE.ICrud(Of BE.Familia)


    Public Function alta(obj As BE.Familia) As Boolean Implements BE.ICrud(Of BE.Familia).alta
        Return DAL.Familia.GetInstance.alta(obj)
    End Function

    Public Function baja(obj As BE.Familia) As Boolean Implements BE.ICrud(Of BE.Familia).baja

    End Function

    Public Function listarPorId(obj As BE.Familia) As BE.Familia Implements BE.ICrud(Of BE.Familia).listarPorId
        Return DAL.Familia.GetInstance.listarPorId(obj)
    End Function

    Public Function listarTodos() As List(Of BE.Familia) Implements BE.ICrud(Of BE.Familia).listarTodos
        Try
            Dim DALFAMILIA As New DAL.Familia
            Return DALFAMILIA.listarTodos
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function modificacion(obj As BE.Familia) As Boolean Implements BE.ICrud(Of BE.Familia).modificacion

    End Function
End Class
