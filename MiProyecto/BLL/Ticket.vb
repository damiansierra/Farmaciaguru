Public Class Ticket
    Implements BE.ICrud(Of BE.Ticket)

    Private Shared _instancia As BLL.Ticket

    Public Shared Function GetInstance() As BLL.Ticket

        If _instancia Is Nothing Then

            _instancia = New BLL.Ticket

        End If
        Return _instancia
    End Function

    Public Function alta(obj As BE.Ticket) As Boolean Implements BE.ICrud(Of BE.Ticket).alta

    End Function

    Public Function baja(obj As BE.Ticket) As Boolean Implements BE.ICrud(Of BE.Ticket).baja

    End Function

    Public Function listarPorId(obj As BE.Ticket) As BE.Ticket Implements BE.ICrud(Of BE.Ticket).listarPorId

    End Function

    Public Function listarTodos() As List(Of BE.Ticket) Implements BE.ICrud(Of BE.Ticket).listarTodos

    End Function

    Public Function modificacion(obj As BE.Ticket) As Boolean Implements BE.ICrud(Of BE.Ticket).modificacion
        Return DAL.Ticket.GetInstance.modificacion(obj)

    End Function

    Public Function ObtenerMaxId() As Integer
        Try
            Return DAL.Ticket.GetInstance().ObtenerMaxId()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerMaxIdVenta_Medicamento() As Integer
        Try
            Return DAL.Ticket.GetInstance().ObtenerMaxIdVenta_Medicamento()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListarTicketPorParametros(idusuario As Integer, fechaDesde As DateTime, fechaHasta As DateTime) As List(Of BE.Ticket)
        Try
            Return DAL.Ticket.GetInstance.ListarTicketPorParametros(idusuario, fechaDesde, fechaHasta)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
