Public Class FormAltaProductos

    Dim BitacoraBE As New BE.Bitacora
    Dim Laboratorio As New BLL.Laboratorio
    Dim unproducto As New BE.Producto
    Dim MenuUI As UI.FormInicio
    Private _id As String

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(Optional idParameter As Integer = 0)
        InitializeComponent()
        _id = idParameter
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try

            Dim nombre As String = Trim(Textnombre.Text)
            Dim descripcion As String = Trim(txtDescripcion.Text)
            cmbLaboratorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Dim laboratoriosel As String = cmbLaboratorio.SelectedItem.ToString
            Dim laboratorio As New BE.Laboratorio

            unproducto.Descripcion = descripcion


            unproducto.Nombre = Trim(Textnombre.Text)
            laboratorio.Nombre = laboratoriosel
            unproducto.laboratorio = laboratorio

            unproducto.stock = Trim(txtCantidad.Text)
            unproducto.Precio_Actual = Trim(txtPrecio.Text)


            BLL.Producto.GetInstance.alta(unproducto)

            Dim BLLbitacora As New BLL.Bitacora
            Dim bebitacora As New BE.Bitacora With {.Criticidad = "Media", .nick = UI.FormInicio.Usuariologueado.Nick, .Descripcion = "Nuevo Producto creado" & unproducto.Nombre}
            BLLbitacora.alta(bebitacora)

            MessageBox.Show("Se Creo un nuevo Producto")


            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub










    Private Sub FormAltaProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If UI.Login.idioma = "2" Then

            Me.lblDescripcion.Text = "Details"
            Me.lblCantidad.Text = "Quantity"
            Me.lblPrecio.Text = "Price"
            Me.btnAceptar.Text = "Acepts"
            Me.Label1.Text = "Pharma"
            Me.Label2.Text = "Name"
        End If


        Try
            Dim listalab As New List(Of BE.Laboratorio)
            cmbLaboratorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Dim lab As New BLL.Laboratorio
            listalab = BLL.Laboratorio.GetInstance.listarTodos
            For Each row In listalab
                cmbLaboratorio.Items.Add(row.Nombre)
            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

  

  
End Class