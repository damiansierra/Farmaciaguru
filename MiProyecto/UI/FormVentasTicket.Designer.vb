<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVentasTicket
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cmbUsuario = New System.Windows.Forms.ComboBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.lblFechaHasta = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.btnlimpiar = New System.Windows.Forms.Button()
        Me.btnbuscar = New System.Windows.Forms.Button()
        Me.dgVentas = New System.Windows.Forms.DataGridView()
        Me.NroVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Venta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HelpProviderHG = New System.Windows.Forms.HelpProvider()
        CType(Me.dgVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 412)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 137
        Me.Label2.Text = "Ordenar por Fecha"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.HelpProviderHG.SetHelpKeyword(Me.Button2, "FormVentasTicket.htm#Button2")
        Me.HelpProviderHG.SetHelpNavigator(Me.Button2, System.Windows.Forms.HelpNavigator.Topic)
        Me.Button2.Location = New System.Drawing.Point(163, 438)
        Me.Button2.Name = "Button2"
        Me.HelpProviderHG.SetShowHelp(Me.Button2, True)
        Me.Button2.Size = New System.Drawing.Size(97, 27)
        Me.Button2.TabIndex = 136
        Me.Button2.Text = "Descendente"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpProviderHG.SetHelpKeyword(Me.Button3, "FormVentasTicket.htm#Button3")
        Me.HelpProviderHG.SetHelpNavigator(Me.Button3, System.Windows.Forms.HelpNavigator.Topic)
        Me.Button3.Location = New System.Drawing.Point(163, 405)
        Me.Button3.Name = "Button3"
        Me.HelpProviderHG.SetShowHelp(Me.Button3, True)
        Me.Button3.Size = New System.Drawing.Size(97, 27)
        Me.Button3.TabIndex = 135
        Me.Button3.Text = "Ascendente"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'cmbUsuario
        '
        Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuario.FormattingEnabled = True
        Me.HelpProviderHG.SetHelpKeyword(Me.cmbUsuario, "FormVentasTicket.htm#lblUsuario")
        Me.HelpProviderHG.SetHelpNavigator(Me.cmbUsuario, System.Windows.Forms.HelpNavigator.Topic)
        Me.cmbUsuario.Location = New System.Drawing.Point(131, 33)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.HelpProviderHG.SetShowHelp(Me.cmbUsuario, True)
        Me.cmbUsuario.Size = New System.Drawing.Size(240, 21)
        Me.cmbUsuario.TabIndex = 134
        '
        'lblUsuario
        '
        Me.lblUsuario.Location = New System.Drawing.Point(58, 35)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(67, 17)
        Me.lblUsuario.TabIndex = 133
        Me.lblUsuario.Text = "Usuario"
        Me.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.Location = New System.Drawing.Point(593, 37)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(69, 17)
        Me.lblFechaHasta.TabIndex = 132
        Me.lblFechaHasta.Text = "Hasta"
        Me.lblFechaHasta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(377, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 18)
        Me.Label1.TabIndex = 131
        Me.Label1.Text = "Desde"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.HelpProviderHG.SetHelpKeyword(Me.dtpFechaDesde, "FormVentasTicket.htm#Label1")
        Me.HelpProviderHG.SetHelpNavigator(Me.dtpFechaDesde, System.Windows.Forms.HelpNavigator.Topic)
        Me.dtpFechaDesde.Location = New System.Drawing.Point(452, 34)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.HelpProviderHG.SetShowHelp(Me.dtpFechaDesde, True)
        Me.dtpFechaDesde.Size = New System.Drawing.Size(128, 20)
        Me.dtpFechaDesde.TabIndex = 130
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.HelpProviderHG.SetHelpKeyword(Me.dtpFechaHasta, "FormVentasTicket.htm#lblFechaHasta")
        Me.HelpProviderHG.SetHelpNavigator(Me.dtpFechaHasta, System.Windows.Forms.HelpNavigator.Topic)
        Me.dtpFechaHasta.Location = New System.Drawing.Point(668, 37)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.HelpProviderHG.SetShowHelp(Me.dtpFechaHasta, True)
        Me.dtpFechaHasta.Size = New System.Drawing.Size(130, 20)
        Me.dtpFechaHasta.TabIndex = 129
        '
        'btnExportar
        '
        Me.HelpProviderHG.SetHelpKeyword(Me.btnExportar, "FormVentasTicket.htm#btnExportar")
        Me.HelpProviderHG.SetHelpNavigator(Me.btnExportar, System.Windows.Forms.HelpNavigator.Topic)
        Me.btnExportar.Location = New System.Drawing.Point(658, 405)
        Me.btnExportar.Name = "btnExportar"
        Me.HelpProviderHG.SetShowHelp(Me.btnExportar, True)
        Me.btnExportar.Size = New System.Drawing.Size(127, 27)
        Me.btnExportar.TabIndex = 127
        Me.btnExportar.Text = "&Exportar"
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'btnlimpiar
        '
        Me.HelpProviderHG.SetHelpKeyword(Me.btnlimpiar, "FormVentasTicket.htm#btnlimpiar")
        Me.HelpProviderHG.SetHelpNavigator(Me.btnlimpiar, System.Windows.Forms.HelpNavigator.Topic)
        Me.btnlimpiar.Location = New System.Drawing.Point(510, 405)
        Me.btnlimpiar.Name = "btnlimpiar"
        Me.HelpProviderHG.SetShowHelp(Me.btnlimpiar, True)
        Me.btnlimpiar.Size = New System.Drawing.Size(127, 27)
        Me.btnlimpiar.TabIndex = 128
        Me.btnlimpiar.Text = "&Limpiar"
        Me.btnlimpiar.UseVisualStyleBackColor = True
        '
        'btnbuscar
        '
        Me.HelpProviderHG.SetHelpKeyword(Me.btnbuscar, "FormVentasTicket.htm#btnbuscar")
        Me.HelpProviderHG.SetHelpNavigator(Me.btnbuscar, System.Windows.Forms.HelpNavigator.Topic)
        Me.btnbuscar.Location = New System.Drawing.Point(368, 405)
        Me.btnbuscar.Name = "btnbuscar"
        Me.HelpProviderHG.SetShowHelp(Me.btnbuscar, True)
        Me.btnbuscar.Size = New System.Drawing.Size(127, 27)
        Me.btnbuscar.TabIndex = 126
        Me.btnbuscar.Text = "&Buscar"
        Me.btnbuscar.UseVisualStyleBackColor = True
        '
        'dgVentas
        '
        Me.dgVentas.AllowUserToAddRows = False
        Me.dgVentas.AllowUserToDeleteRows = False
        Me.dgVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgVentas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NroVenta, Me.Cliente, Me.Fecha_Venta, Me.Total})
        Me.HelpProviderHG.SetHelpKeyword(Me.dgVentas, "FormVentasTicket.htm#dgVentas")
        Me.HelpProviderHG.SetHelpNavigator(Me.dgVentas, System.Windows.Forms.HelpNavigator.Topic)
        Me.dgVentas.Location = New System.Drawing.Point(60, 94)
        Me.dgVentas.Name = "dgVentas"
        Me.dgVentas.ReadOnly = True
        Me.dgVentas.RowHeadersVisible = False
        Me.HelpProviderHG.SetShowHelp(Me.dgVentas, True)
        Me.dgVentas.Size = New System.Drawing.Size(725, 298)
        Me.dgVentas.TabIndex = 125
        '
        'NroVenta
        '
        Me.NroVenta.FillWeight = 50.0!
        Me.NroVenta.HeaderText = "NroVenta"
        Me.NroVenta.Name = "NroVenta"
        Me.NroVenta.ReadOnly = True
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "IDVendedor"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        '
        'Fecha_Venta
        '
        Me.Fecha_Venta.FillWeight = 90.0!
        Me.Fecha_Venta.HeaderText = "Fecha y Hora"
        Me.Fecha_Venta.Name = "Fecha_Venta"
        Me.Fecha_Venta.ReadOnly = True
        '
        'Total
        '
        Me.Total.FillWeight = 80.0!
        Me.Total.HeaderText = "Importe Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'HelpProviderHG
        '
        Me.HelpProviderHG.HelpNamespace = "MiProyecto.chm"
        '
        'FormVentasTicket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(846, 502)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.cmbUsuario)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.lblFechaHasta)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFechaDesde)
        Me.Controls.Add(Me.dtpFechaHasta)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.btnlimpiar)
        Me.Controls.Add(Me.btnbuscar)
        Me.Controls.Add(Me.dgVentas)
        Me.HelpProviderHG.SetHelpKeyword(Me, "FormVentasTicket.htm")
        Me.HelpProviderHG.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.Name = "FormVentasTicket"
        Me.HelpProviderHG.SetShowHelp(Me, True)
        Me.Text = "FormVentasTicket"
        CType(Me.dgVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents cmbUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents lblFechaHasta As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents btnlimpiar As System.Windows.Forms.Button
    Friend WithEvents btnbuscar As System.Windows.Forms.Button
    Friend WithEvents dgVentas As System.Windows.Forms.DataGridView
    Friend WithEvents NroVenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Venta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HelpProviderHG As System.Windows.Forms.HelpProvider
End Class
