Public Class FormVentasTicket


    Dim MenuUI As UI.FormInicio
    Dim ven As New List(Of BE.Ticket)


    Private Sub frmVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MenuUI = Me.MdiParent

        If UI.Login.idioma = "2" Then
            Me.Label2.Text = ""
            Me.Button2.Text = ""
            Me.Button3.Text = ""
            Me.lblUsuario.Text = "User"
            Me.lblFechaHasta.Text = "to"
            Me.Label1.Text = ""
            Me.btnExportar.Text = "Export"
            Me.btnlimpiar.Text = "Clear"
            Me.btnbuscar.Text = "Search"

            Me.NroVenta.HeaderText = "NumberSell"
            Me.Cliente.HeaderText = "User"
            Me.Fecha_Venta.HeaderText = "DateSell"
           
        End If
        Try
            Dim myList As New Dictionary(Of Integer, String)
            For Each UsuarioBE In BLL.Usuario.GetInstance.listarTodos()
                myList.Add(UsuarioBE.IdUsuario, UsuarioBE.Nick)
            Next
            cmbUsuario.DisplayMember = "Value"
            cmbUsuario.ValueMember = "Key"
            cmbUsuario.DataSource = New BindingSource(myList, Nothing)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub btnbuscar_Click(sender As Object, e As EventArgs) Handles btnbuscar.Click
        ListarVentas()
    End Sub

    Public Function ListarVentas()




        Dim TotalImporte As Double
        dgVentas.Rows.Clear()
        Dim fechaDesde = New DateTime(dtpFechaDesde.Value.Year, dtpFechaDesde.Value.Month, dtpFechaDesde.Value.Day, 0, 0, 0)
        Dim fechaHasta = New DateTime(dtpFechaHasta.Value.Year, dtpFechaHasta.Value.Month, dtpFechaHasta.Value.Day, 23, 59, 59)
        Dim VentasBE As New BE.Ticket
        Dim Ventas As New List(Of BE.Ticket)

        Ventas = BLL.Ticket.GetInstance.ListarTicketPorParametros(cmbUsuario.SelectedValue, fechaDesde, fechaHasta)

        For Each item In Ventas
            Dim n As Integer = dgVentas.Rows.Add()
            dgVentas.Rows.Item(n).Cells("NroVenta").Value = item.idticket
            dgVentas.Rows.Item(n).Cells("Cliente").Value = item.idusuario
            dgVentas.Rows.Item(n).Cells("Fecha_Venta").Value = item.fechahora
            dgVentas.Rows.Item(n).Cells("Total").Value = item.totalventa
            TotalImporte = 0
        Next
        ven = Ventas

        Return Ventas
    End Function

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        dgVentas.Rows.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs)
      
        ListarVentas()

    End Sub



    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            Dim rep_bit As New UI.Form1(ven)
            rep_bit.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        dgVentas.Sort(Fecha_Venta, System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        dgVentas.Sort(Fecha_Venta, System.ComponentModel.ListSortDirection.Descending)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class
