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

        Try
            Dim ticket As New BE.Ticket

            Dim sinstock As Integer = 0

            Dim dt As New DataTable

            Dim productos As New BE.Producto

            Dim INSERT As String = "INSERT INTO  TICKET VALUES " & "('" & obj.idticket & "','" & obj.idusuario & "','" & obj.fechahora & "','" & obj.totalventa & "')"
            DAL.Conexion.GetInstance.Escribir(INSERT)
          



            For Each REG In obj.renglonticket

                Dim SELECTPROD As String = "SELECT * FROM PRODUCTO WHERE IDPRODUCTO = '" & REG.producto.IdProducto & "'"
                dt = DAL.Conexion.GetInstance.leer(SELECTPROD)

                Dim _ROW As DataRow = dt.Rows(0)

                productos.stock = _ROW("STOCK")
                productos.Nombre = Seguridad.DesEncriptar(_ROW("NOMBRE"))



                Dim val1 As Integer = 0
                Int32.TryParse(productos.stock, val1)

                Dim val2 As Integer = 0
                Int32.TryParse(REG.cantidad, val2)

                If val2 < val1 Then

                    productos.stock = val1 - val2
                    Dim UPDATEARSTOCK As String = "UPDATE PRODUCTO SET STOCK = " & productos.stock & " WHERE IDPRODUCTO = '" & REG.producto.IdProducto & "'"
                    DAL.Conexion.GetInstance.Escribir(UPDATEARSTOCK)

                    Dim INSERTRENGLON As String = "INSERT INTO  RENGLONTICKET VALUES " & "('" & REG.idrenglon & "','" & REG.ticket.idticket & "','" & REG.producto.IdProducto & "','" & REG.cantidad & "','" & REG.precio_historico & "')"
                    DAL.Conexion.GetInstance.Escribir(INSERTRENGLON)

                Else
                    sinstock = sinstock + REG.cantidad
                End If

                If sinstock > 0 Then
                    MsgBox("La cantidad de " & sinstock & " de " & productos.Nombre & " no se vendio")
                    sinstock = 0
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try

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
