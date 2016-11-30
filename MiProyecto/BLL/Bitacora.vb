Public Class Bitacora
    Implements BE.ICrud(Of BE.Bitacora)

    Private Shared _instancia As BLL.Bitacora
    Public Shared Function GetInstance() As BLL.Bitacora
        If _instancia Is Nothing Then
            _instancia = New BLL.Bitacora
        End If
        Return _instancia
    End Function



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


    Public Function ListarBitacoraPorParametros(idusuario As Integer, fechaDesde As DateTime, fechaHasta As DateTime, criticidad As String) As List(Of BE.Bitacora)
        Try
            Return DAL.Bitacora.GetInstance().ListarBitacoraPorParametros(idusuario, fechaDesde, fechaHasta, criticidad)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
