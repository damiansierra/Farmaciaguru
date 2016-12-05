Public Class Laboratorio
    Implements BE.ICrud(Of BE.Laboratorio)

    Private Shared _instancia As BLL.Laboratorio
    Public Shared Function GetInstance() As BLL.Laboratorio
        If _instancia Is Nothing Then
            _instancia = New BLL.Laboratorio
        End If
        Return _instancia
    End Function


    Public Function alta(obj As BE.Laboratorio) As Boolean Implements BE.ICrud(Of BE.Laboratorio).alta

        DAL.Laboratorio.GetInstance.alta(obj)
    End Function

    Public Function baja(obj As BE.Laboratorio) As Boolean Implements BE.ICrud(Of BE.Laboratorio).baja

    End Function

    Public Function listarPorId(obj As BE.Laboratorio) As BE.Laboratorio Implements BE.ICrud(Of BE.Laboratorio).listarPorId

    End Function

    Public Function listarTodos() As List(Of BE.Laboratorio) Implements BE.ICrud(Of BE.Laboratorio).listarTodos
        Return DAL.Laboratorio.GetInstance.listarTodos()

    End Function

    Public Function modificacion(obj As BE.Laboratorio) As Boolean Implements BE.ICrud(Of BE.Laboratorio).modificacion

    End Function
End Class
