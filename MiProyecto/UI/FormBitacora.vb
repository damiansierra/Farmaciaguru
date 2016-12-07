Public Class FormBitacora

  

    Dim MenuUI As UI.FormInicio
    ' Dim TraduccionBLL As BLL.Traduccion

    Private Sub btnbuscar_Click(sender As Object, e As EventArgs) Handles btnbuscar.Click
        Try
            dgBitacora.Rows.Clear()
            ListarBitacoras()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function ListarBitacoras()
        Dim fechaDesde = New DateTime(dtpFechaDesde.Value.Year, dtpFechaDesde.Value.Month, dtpFechaDesde.Value.Day, 0, 0, 0)
        Dim fechaHasta = New DateTime(dtpFechaHasta.Value.Year, dtpFechaHasta.Value.Month, dtpFechaHasta.Value.Day, 23, 59, 59)
        Dim BitacorasBE As New BE.Bitacora
        Dim bitacoras As New List(Of BE.Bitacora)

        bitacoras = BLL.Bitacora.GetInstance.ListarBitacoraPorParametros(cmbUsuario.SelectedValue, fechaDesde, fechaHasta, cmbCriticidad.SelectedValue)
        For Each BitacorasBE In bitacoras
            Dim n As Integer = dgBitacora.Rows.Add()
            dgBitacora.Rows.Item(n).Cells("Id").Value = BitacorasBE.IdBitacora
            dgBitacora.Rows.Item(n).Cells("Usuario").Value = BitacorasBE.nick
            dgBitacora.Rows.Item(n).Cells("Descripcion").Value = BitacorasBE.Descripcion
            dgBitacora.Rows.Item(n).Cells("Fecha_Hora").Value = BitacorasBE.FechaHora.ToString("yyyy/MM/dd HH:mm:ss")
            dgBitacora.Rows.Item(n).Cells("Criticidad").Value = BitacorasBE.criticidad
        Next
        Return bitacoras
    End Function


    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        Try
            dgBitacora.Rows.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmBitacora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If UI.Login.idioma = "2" Then

                ' Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
                '  Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
                Me.btnlimpiar.Text = "Clear"
                Me.btnCancelar.Text = "Cancel"
                Me.btnExportar.Text = "Export"
                Me.btnbuscar.Text = "Search"
                Me.lblCriticidad.Text = "Severity"
                Me.lblUsuario.Text = "User"
                Me.lblFechaDesde.Text = "From"
                Me.lblFechaHasta.Text = "To"
                Me.id.HeaderText = "id"
                Me.usuario.HeaderText = "User"
                Me.descripcion.HeaderText = "Description"
                Me.fecha_hora.HeaderText = "Datetime"
                Me.Criticidad.HeaderText = "Severity"
                Me.Label2.Text = "Sort"
                Me.Button2.Text = "ASc"
                Me.Button3.Text = "Desc"
                
            End If
            UI.FormInicio = Me.MdiParent
            '   TraduccionBLL = New BLL.Traduccion(MenuUI.GetIdioma)
            Dim PatenteBE As New BE.Patente
            PatenteBE.Nombre = "Bitacora"
            '    PatenteBE.PatenteId = BLL.Usuario.GetInstance.ObtenerPantenteID(PatenteBE.Nombre)
            '   If (BLL.Usuario.GetInstance.VerificarPatente(MenuUI.GetUsuario, PatenteBE) = False) Then
            'MsgBox(TraduccionBLL.TraducirTexto("Sus permisos han sido modificados, por favor inicie sesion nuevamente"), MsgBoxStyle.Critical, TraduccionBLL.TraducirTexto("Error"))
            '   Application.Exit()
            '   End If
            '   TraduccionBLL.TraducirForm(Me)
            MuestraCamposBitacora()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub MuestraCamposBitacora()
        cmbUsuario.Items.Clear()




        Dim myList As New Dictionary(Of Integer, String)
        '      myList.Add(0, TraduccionBLL.TraducirTexto("Todos los Usuarios"))
        For Each UsuarioBE In BLL.Usuario.GetInstance.listarTodos()
            myList.Add(UsuarioBE.IdUsuario, UsuarioBE.Nick)
        Next
        cmbUsuario.DisplayMember = "Value"
        cmbUsuario.ValueMember = "Key"
        cmbUsuario.DataSource = New BindingSource(myList, Nothing)

        Dim myListNivel As New Dictionary(Of String, String)
        myListNivel.Add("Alta", "Alta")
        myListNivel.Add("Media", "Media")
        myListNivel.Add("Baja", "Baja")
        cmbCriticidad.DisplayMember = "Value"
        cmbCriticidad.ValueMember = "Key"

        cmbCriticidad.DataSource = New BindingSource(myListNivel, Nothing)

    End Sub


    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            '      Dim bitacoraReporte As New UI.frmBitacoraReporte(ListarBitacoras, "Reporte de Bitacoras ")
            '      bitacoraReporte.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        dgBitacora.Sort(fecha_hora, System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        dgBitacora.Sort(fecha_hora, System.ComponentModel.ListSortDirection.Descending)
    End Sub
End Class