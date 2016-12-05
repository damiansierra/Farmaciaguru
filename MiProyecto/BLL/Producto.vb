Public Class Producto
    Implements BE.ICrud(Of BE.Producto)


    Private Shared _instancia As BLL.Producto
    Public Shared Function GetInstance() As BLL.Producto
        If _instancia Is Nothing Then
            _instancia = New BLL.Producto
        End If
        Return _instancia
    End Function

    Public Function alta(obj As BE.Producto) As Boolean Implements BE.ICrud(Of BE.Producto).alta
        Return DAL.Producto.GetInstance.alta(obj)
    End Function

    Public Function baja(obj As BE.Producto) As Boolean Implements BE.ICrud(Of BE.Producto).baja

    End Function

    Public Function listarPorId(obj As BE.Producto) As BE.Producto Implements BE.ICrud(Of BE.Producto).listarPorId

    End Function

    Public Function listarTodos() As List(Of BE.Producto) Implements BE.ICrud(Of BE.Producto).listarTodos

    End Function

    Public Function modificacion(obj As BE.Producto) As Boolean Implements BE.ICrud(Of BE.Producto).modificacion

    End Function
End Class
