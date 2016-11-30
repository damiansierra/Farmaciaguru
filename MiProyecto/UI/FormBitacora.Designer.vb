<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBitacora
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmbCriticidad = New System.Windows.Forms.ComboBox()
        Me.cmbUsuario = New System.Windows.Forms.ComboBox()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.btnlimpiar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.btnbuscar = New System.Windows.Forms.Button()
        Me.lblCriticidad = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.lblFechaDesde = New System.Windows.Forms.Label()
        Me.lblFechaHasta = New System.Windows.Forms.Label()
        Me.dgBitacora = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha_hora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Criticidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgBitacora, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbCriticidad
        '
        Me.cmbCriticidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCriticidad.FormattingEnabled = True
        Me.cmbCriticidad.Location = New System.Drawing.Point(564, 33)
        Me.cmbCriticidad.Name = "cmbCriticidad"
        Me.cmbCriticidad.Size = New System.Drawing.Size(362, 21)
        Me.cmbCriticidad.TabIndex = 41
        '
        'cmbUsuario
        '
        Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuario.FormattingEnabled = True
        Me.cmbUsuario.Location = New System.Drawing.Point(118, 34)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(311, 21)
        Me.cmbUsuario.TabIndex = 42
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(564, 67)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(138, 20)
        Me.dtpFechaDesde.TabIndex = 40
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(785, 69)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(139, 20)
        Me.dtpFechaHasta.TabIndex = 39
        '
        'btnlimpiar
        '
        Me.btnlimpiar.Location = New System.Drawing.Point(495, 476)
        Me.btnlimpiar.Name = "btnlimpiar"
        Me.btnlimpiar.Size = New System.Drawing.Size(127, 27)
        Me.btnlimpiar.TabIndex = 34
        Me.btnlimpiar.Text = "&Limpiar"
        Me.btnlimpiar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(807, 476)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(127, 27)
        Me.btnCancelar.TabIndex = 31
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(648, 476)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(127, 27)
        Me.btnExportar.TabIndex = 32
        Me.btnExportar.Text = "&Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'btnbuscar
        '
        Me.btnbuscar.Location = New System.Drawing.Point(302, 476)
        Me.btnbuscar.Name = "btnbuscar"
        Me.btnbuscar.Size = New System.Drawing.Size(127, 27)
        Me.btnbuscar.TabIndex = 33
        Me.btnbuscar.Text = "&Buscar"
        Me.btnbuscar.UseVisualStyleBackColor = True
        '
        'lblCriticidad
        '
        Me.lblCriticidad.Location = New System.Drawing.Point(483, 37)
        Me.lblCriticidad.Name = "lblCriticidad"
        Me.lblCriticidad.Size = New System.Drawing.Size(62, 18)
        Me.lblCriticidad.TabIndex = 37
        Me.lblCriticidad.Text = "Criticidad"
        Me.lblCriticidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUsuario
        '
        Me.lblUsuario.Location = New System.Drawing.Point(40, 34)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(67, 17)
        Me.lblUsuario.TabIndex = 38
        Me.lblUsuario.Text = "Usuario"
        Me.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFechaDesde
        '
        Me.lblFechaDesde.Location = New System.Drawing.Point(483, 67)
        Me.lblFechaDesde.Name = "lblFechaDesde"
        Me.lblFechaDesde.Size = New System.Drawing.Size(75, 18)
        Me.lblFechaDesde.TabIndex = 35
        Me.lblFechaDesde.Text = "Desde"
        Me.lblFechaDesde.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.Location = New System.Drawing.Point(721, 70)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(69, 17)
        Me.lblFechaHasta.TabIndex = 36
        Me.lblFechaHasta.Text = "Hasta"
        Me.lblFechaHasta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgBitacora
        '
        Me.dgBitacora.AllowUserToAddRows = False
        Me.dgBitacora.AllowUserToDeleteRows = False
        Me.dgBitacora.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBitacora.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.usuario, Me.descripcion, Me.fecha_hora, Me.Criticidad})
        Me.dgBitacora.Location = New System.Drawing.Point(68, 106)
        Me.dgBitacora.Name = "dgBitacora"
        Me.dgBitacora.ReadOnly = True
        Me.dgBitacora.RowHeadersVisible = False
        Me.dgBitacora.Size = New System.Drawing.Size(866, 348)
        Me.dgBitacora.TabIndex = 43
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'usuario
        '
        Me.usuario.HeaderText = "Usuario"
        Me.usuario.Name = "usuario"
        Me.usuario.ReadOnly = True
        '
        'descripcion
        '
        Me.descripcion.FillWeight = 200.0!
        Me.descripcion.HeaderText = "Descripcion"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        '
        'fecha_hora
        '
        Me.fecha_hora.FillWeight = 150.0!
        Me.fecha_hora.HeaderText = "Fecha y Hora"
        Me.fecha_hora.Name = "fecha_hora"
        Me.fecha_hora.ReadOnly = True
        '
        'Criticidad
        '
        Me.Criticidad.HeaderText = "Criticidad"
        Me.Criticidad.Name = "Criticidad"
        Me.Criticidad.ReadOnly = True
        '
        'FormBitacora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 552)
        Me.Controls.Add(Me.dgBitacora)
        Me.Controls.Add(Me.cmbCriticidad)
        Me.Controls.Add(Me.cmbUsuario)
        Me.Controls.Add(Me.dtpFechaDesde)
        Me.Controls.Add(Me.dtpFechaHasta)
        Me.Controls.Add(Me.btnlimpiar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.btnbuscar)
        Me.Controls.Add(Me.lblCriticidad)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.lblFechaDesde)
        Me.Controls.Add(Me.lblFechaHasta)
        Me.Name = "FormBitacora"
        Me.Text = "FormBitacora"
        CType(Me.dgBitacora, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbCriticidad As System.Windows.Forms.ComboBox
    Friend WithEvents cmbUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnlimpiar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents btnbuscar As System.Windows.Forms.Button
    Friend WithEvents lblCriticidad As System.Windows.Forms.Label
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents lblFechaDesde As System.Windows.Forms.Label
    Friend WithEvents lblFechaHasta As System.Windows.Forms.Label
    Friend WithEvents dgBitacora As System.Windows.Forms.DataGridView
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents usuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha_hora As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Criticidad As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
