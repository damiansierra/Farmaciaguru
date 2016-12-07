Public Class FormVentas

    Dim ticket As New BE.Ticket
    Dim i As Integer = 0

    Private _id As String
    Dim ticker As New BE.Ticket

    Dim renglones As New List(Of BE.RenglonTicket)
    Public Sub frmVentasMod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim listaprod As New List(Of BE.Producto)
            cmbMedicamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Dim prod As New BLL.Producto
            listaprod = BLL.Producto.GetInstance.listarTodos
            For Each row In listaprod
                cmbMedicamento.Items.Add(row.Nombre)
            Next

            txtFechaHora.Text = DateTime.Now
           
            txtNroVenta.Text = BLL.Ticket.GetInstance.ObtenerMaxId()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
      

        MostrarDatos()
 
    End Sub




    Public Function cmbMedicamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMedicamento.SelectedIndexChanged
        txtPrecioLista.Text = ""
        txtDisponible.Text = ""
        txtCantidad.Text = 1
        txtDisponible.Text = ObtenerMedicamento.stock
        txtPrecioLista.Text = ObtenerMedicamento.Precio_Actual
    End Function


    Public Function ObtenerMedicamento()
        Dim MedicamentoBE As New BE.Producto

        cmbMedicamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Dim prodsel As String = cmbMedicamento.SelectedItem.ToString

        MedicamentoBE.Nombre = prodsel

        MedicamentoBE = BLL.Producto.GetInstance.listarPorId(MedicamentoBE)
        Return MedicamentoBE
    End Function



    Public Sub MostrarDatos()


    
    End Sub


    Public Sub btnAgregarMedicamento_Click(sender As Object, e As EventArgs) Handles btnAgregarMedicamento.Click
        If ValidarStock() Then
            AgregarMedicamentosPorVenta()



        End If
    End Sub


    Public Function ValidarStock() As Boolean
        Dim valido = True
        Dim cantStock As Integer = ObtenerMedicamento.stock
        If cantStock < CInt(txtCantidad.Text) Then
            valido = False
            MsgBox("La cantidad solicitad es superior al stock disponible")
        End If
        Return valido
    End Function



    Public Sub AgregarMedicamentosPorVenta()

        Dim prod As New BE.Producto

        Dim tick As New BE.Ticket


        prod.IdProducto = ObtenerMedicamento.idproducto
        prod.Nombre = ObtenerMedicamento.nombre
        tick.idticket = txtNroVenta.Text


        Dim renglon As New BE.RenglonTicket
        renglon.ticket = tick
        renglon.idrenglon = i
        renglon.producto = prod
        renglon.precio_historico = ObtenerMedicamento.Precio_Actual
        renglon.cantidad = txtCantidad.Text
        renglones.Add(renglon)

        i = i + 1


        Dim n As Integer = dgMedicamentosPorVenta.Rows.Add()
        dgMedicamentosPorVenta.Rows.Item(n).Cells("idrenglon").Value = i
        dgMedicamentosPorVenta.Rows.Item(n).Cells("Nombre").Value = renglon.producto.Nombre
        dgMedicamentosPorVenta.Rows.Item(n).Cells("Cantidad").Value = renglon.cantidad
        dgMedicamentosPorVenta.Rows.Item(n).Cells("Precio").Value = renglon.precio_historico

        Dim val1 As Integer = 0
        Int32.TryParse(txtImporteTotal.Text, val1)

        Dim val2 As Integer = 0
        Int32.TryParse(renglon.cantidad, val2)

        Dim val3 As Integer = 0
        Int32.TryParse(renglon.precio_historico, val3)

        txtImporteTotal.Text = Convert.ToString(val1 + (val2 * val3))


    End Sub





    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        ticker.idticket = txtNroVenta.Text
        ticker.fechahora = txtFechaHora.Text
        ticker.idusuario = FormInicio.Usuariologueado.IdUsuario
        ticker.renglonticket = renglones
        ticker.totalventa = txtImporteTotal.Text
        BLL.Ticket.GetInstance.modificacion(ticker)

    End Sub
End Class