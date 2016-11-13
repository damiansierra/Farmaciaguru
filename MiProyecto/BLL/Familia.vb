Public Class Familia
    Implements BE.ICrud(Of BE.Familia)


    Public Function alta(obj As BE.Familia) As Boolean Implements BE.ICrud(Of BE.Familia).alta
        Return DAL.Familia.GetInstance.alta(obj)
    End Function

    Public Function baja(obj As BE.Familia) As Boolean Implements BE.ICrud(Of BE.Familia).baja

    End Function

    Public Function listarPorId(obj As BE.Familia) As BE.Familia Implements BE.ICrud(Of BE.Familia).listarPorId

    End Function

    Public Function listarTodos() As List(Of BE.Familia) Implements BE.ICrud(Of BE.Familia).listarTodos

    End Function

    Public Function modificacion(obj As BE.Familia) As Boolean Implements BE.ICrud(Of BE.Familia).modificacion

    End Function
End Class
