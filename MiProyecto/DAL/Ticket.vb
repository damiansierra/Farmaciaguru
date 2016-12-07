Public Class Ticket
    Implements BE.ICrud(Of BE.Ticket)
    Dim SqlConn As New SqlClient.SqlConnection With {.ConnectionString = Conexion.getConexionMaster}


    Private Shared _instancia As DAL.Ticket

    Public Shared Function GetInstance() As DAL.Ticket

        If _instancia Is Nothing Then

            _instancia = New DAL.Ticket

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

    End Function

    Function ObtenerMaxId() As Integer
        Dim SqlComm As New SqlClient.SqlCommand
        Dim dr As SqlClient.SqlDataReader
        Dim dt As New DataTable

        sqlConn.Open()
        SqlComm.CommandText = String.Format("SELECT isnull(MAX(idticket),0) as MaxId FROM Ticket ")
        SqlComm.Connection = sqlConn
        dr = SqlComm.ExecuteReader()
        dt.Load(dr)
        sqlConn.Close()

        Return dt.Rows(0).Item(0)
    End Function


    Function ObtenerMaxIdVenta_Medicamento() As Integer
        Dim SqlComm As New SqlClient.SqlCommand
        Dim dr As SqlClient.SqlDataReader
        Dim dt As New DataTable

        SqlConn.Open()
        SqlComm.CommandText = String.Format("SELECT isnull(MAX(idrenglon),0) as MaxId FROM RenglonTicket ")
        SqlComm.Connection = SqlConn
        dr = SqlComm.ExecuteReader()
        dt.Load(dr)
        SqlConn.Close()

        Return dt.Rows(0).Item(0)
    End Function
End Class
