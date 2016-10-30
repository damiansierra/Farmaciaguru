Public Class MiClaseBLL
    Implements BE.ICrud(Of BE.MiClaseBE)


    Private Shared _instancia As BLL.MiClaseBLL
    Public Shared Function GetInstance() As BLL.MiClaseBLL
        If _instancia Is Nothing Then
            _instancia = New BLL.MiClaseBLL
        End If
        Return _instancia
    End Function

    Public Function alta(pepito As BE.MiClaseBE) As Boolean Implements BE.ICrud(Of BE.MiClaseBE).alta
        Return DAL.MiClaseDAL.GetInstance.alta(pepito)
    End Function

    Public Function baja(obj As BE.MiClaseBE) As Boolean Implements BE.ICrud(Of BE.MiClaseBE).baja
        Return DAL.MiClaseDAL.GetInstance.baja(obj)
    End Function

    Public Function listarPorId(obj As BE.MiClaseBE) As BE.MiClaseBE Implements BE.ICrud(Of BE.MiClaseBE).listarPorId

    End Function

    Public Function listarTodos() As List(Of BE.MiClaseBE) Implements BE.ICrud(Of BE.MiClaseBE).listarTodos

    End Function

    Public Function modificacion(obj As BE.MiClaseBE) As Boolean Implements BE.ICrud(Of BE.MiClaseBE).modificacion

    End Function
End Class
