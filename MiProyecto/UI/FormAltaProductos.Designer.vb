<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAltaProductos
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
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtCantidad = New System.Windows.Forms.NumericUpDown()
        Me.cmbLaboratorio = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Textnombre = New System.Windows.Forms.TextBox()
        Me.HelpProviderHG = New System.Windows.Forms.HelpProvider()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpProviderHG.SetHelpKeyword(Me.txtDescripcion, "FormAltaProductos.htm#lblDescripcion")
        Me.HelpProviderHG.SetHelpNavigator(Me.txtDescripcion, System.Windows.Forms.HelpNavigator.Topic)
        Me.txtDescripcion.Location = New System.Drawing.Point(190, 61)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.HelpProviderHG.SetShowHelp(Me.txtDescripcion, True)
        Me.txtDescripcion.Size = New System.Drawing.Size(226, 24)
        Me.txtDescripcion.TabIndex = 2
        '
        'txtPrecio
        '
        Me.txtPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpProviderHG.SetHelpKeyword(Me.txtPrecio, "FormAltaProductos.htm#lblPrecio")
        Me.HelpProviderHG.SetHelpNavigator(Me.txtPrecio, System.Windows.Forms.HelpNavigator.Topic)
        Me.txtPrecio.Location = New System.Drawing.Point(190, 179)
        Me.txtPrecio.Name = "txtPrecio"
        Me.HelpProviderHG.SetShowHelp(Me.txtPrecio, True)
        Me.txtPrecio.Size = New System.Drawing.Size(93, 24)
        Me.txtPrecio.TabIndex = 5
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.Location = New System.Drawing.Point(97, 64)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(87, 18)
        Me.lblDescripcion.TabIndex = 124
        Me.lblDescripcion.Text = "Descripción"
        Me.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.Location = New System.Drawing.Point(97, 142)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(66, 18)
        Me.lblCantidad.TabIndex = 122
        Me.lblCantidad.Text = "Cantidad"
        Me.lblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecio.Location = New System.Drawing.Point(97, 182)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(51, 18)
        Me.lblPrecio.TabIndex = 121
        Me.lblPrecio.Text = "Precio"
        Me.lblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpProviderHG.SetHelpKeyword(Me.btnAceptar, "FormAltaProductos.htm#btnAceptar")
        Me.HelpProviderHG.SetHelpNavigator(Me.btnAceptar, System.Windows.Forms.HelpNavigator.Topic)
        Me.btnAceptar.Location = New System.Drawing.Point(289, 237)
        Me.btnAceptar.Name = "btnAceptar"
        Me.HelpProviderHG.SetShowHelp(Me.btnAceptar, True)
        Me.btnAceptar.Size = New System.Drawing.Size(127, 27)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "&Aceptar"
        '
        'txtCantidad
        '
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpProviderHG.SetHelpKeyword(Me.txtCantidad, "FormAltaProductos.htm#txtCantidad")
        Me.HelpProviderHG.SetHelpNavigator(Me.txtCantidad, System.Windows.Forms.HelpNavigator.Topic)
        Me.txtCantidad.Location = New System.Drawing.Point(190, 140)
        Me.txtCantidad.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCantidad.Maximum = New Decimal(New Integer() {32767, 0, 0, 0})
        Me.txtCantidad.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtCantidad.Name = "txtCantidad"
        Me.HelpProviderHG.SetShowHelp(Me.txtCantidad, True)
        Me.txtCantidad.Size = New System.Drawing.Size(94, 24)
        Me.txtCantidad.TabIndex = 4
        Me.txtCantidad.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cmbLaboratorio
        '
        Me.cmbLaboratorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLaboratorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLaboratorio.FormattingEnabled = True
        Me.HelpProviderHG.SetHelpKeyword(Me.cmbLaboratorio, "FormAltaProductos.htm#Label1")
        Me.HelpProviderHG.SetHelpNavigator(Me.cmbLaboratorio, System.Windows.Forms.HelpNavigator.Topic)
        Me.cmbLaboratorio.Location = New System.Drawing.Point(190, 99)
        Me.cmbLaboratorio.Name = "cmbLaboratorio"
        Me.HelpProviderHG.SetShowHelp(Me.cmbLaboratorio, True)
        Me.cmbLaboratorio.Size = New System.Drawing.Size(226, 26)
        Me.cmbLaboratorio.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(97, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 18)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "Laboratorio"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(97, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 18)
        Me.Label2.TabIndex = 132
        Me.Label2.Text = "Nombre"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Textnombre
        '
        Me.Textnombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpProviderHG.SetHelpKeyword(Me.Textnombre, "FormAltaProductos.htm#Label2")
        Me.HelpProviderHG.SetHelpNavigator(Me.Textnombre, System.Windows.Forms.HelpNavigator.Topic)
        Me.Textnombre.Location = New System.Drawing.Point(190, 30)
        Me.Textnombre.Name = "Textnombre"
        Me.HelpProviderHG.SetShowHelp(Me.Textnombre, True)
        Me.Textnombre.Size = New System.Drawing.Size(226, 24)
        Me.Textnombre.TabIndex = 1
        '
        'HelpProviderHG
        '
        Me.HelpProviderHG.HelpNamespace = "MiProyecto.chm"
        '
        'FormAltaProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(529, 288)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Textnombre)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbLaboratorio)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.lblPrecio)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.txtPrecio)
        Me.Controls.Add(Me.txtDescripcion)
        Me.HelpProviderHG.SetHelpKeyword(Me, "FormAltaProductos.htm")
        Me.HelpProviderHG.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.Name = "FormAltaProductos"
        Me.HelpProviderHG.SetShowHelp(Me, True)
        Me.Text = "FormAltaProductos"
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtCantidad As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbLaboratorio As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Textnombre As System.Windows.Forms.TextBox
    Friend WithEvents HelpProviderHG As System.Windows.Forms.HelpProvider
End Class
