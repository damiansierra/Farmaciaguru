Public Class PatenteBLL
    Implements BE.ICrud(Of BE.Patente)


    Public Function alta(obj As BE.Patente) As Boolean Implements BE.ICrud(Of BE.Patente).alta

    End Function

    Public Function baja(obj As BE.Patente) As Boolean Implements BE.ICrud(Of BE.Patente).baja

    End Function

    Public Function listarPorId(obj As BE.Patente) As BE.Patente Implements BE.ICrud(Of BE.Patente).listarPorId

    End Function

    Public Function listarTodos() As List(Of BE.Patente) Implements BE.ICrud(Of BE.Patente).listarTodos
        Return DAL.PatenteDALL.GetInstance.listarTodos()
    End Function

    Public Function modificacion(obj As BE.Patente) As Boolean Implements BE.ICrud(Of BE.Patente).modificacion


    End Function
End Class
