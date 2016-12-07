<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFamilias
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
        Me.Combofamilia = New System.Windows.Forms.ComboBox()
        Me.txtfamilia = New System.Windows.Forms.Label()
        Me.DataGridViewfamilia = New System.Windows.Forms.DataGridView()
        Me.IDPatente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Agregada = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btnconfirmarmodificaciones = New System.Windows.Forms.Button()
        Me.HelpProviderHG = New System.Windows.Forms.HelpProvider()
        CType(Me.DataGridViewfamilia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Combofamilia
        '
        Me.Combofamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combofamilia.FormattingEnabled = True
        Me.HelpProviderHG.SetHelpKeyword(Me.Combofamilia, "FormFamilias.htm#txtfamilia")
        Me.HelpProviderHG.SetHelpNavigator(Me.Combofamilia, System.Windows.Forms.HelpNavigator.Topic)
        Me.Combofamilia.Location = New System.Drawing.Point(166, 26)
        Me.Combofamilia.Name = "Combofamilia"
        Me.HelpProviderHG.SetShowHelp(Me.Combofamilia, True)
        Me.Combofamilia.Size = New System.Drawing.Size(239, 28)
        Me.Combofamilia.TabIndex = 0
        '
        'txtfamilia
        '
        Me.txtfamilia.AutoSize = True
        Me.txtfamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfamilia.Location = New System.Drawing.Point(67, 29)
        Me.txtfamilia.Name = "txtfamilia"
        Me.txtfamilia.Size = New System.Drawing.Size(59, 20)
        Me.txtfamilia.TabIndex = 8
        Me.txtfamilia.Text = "Familia"
        '
        'DataGridViewfamilia
        '
        Me.DataGridViewfamilia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewfamilia.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDPatente, Me.Nombre, Me.Agregada})
        Me.HelpProviderHG.SetHelpKeyword(Me.DataGridViewfamilia, "FormFamilias.htm#DataGridViewfamilia")
        Me.HelpProviderHG.SetHelpNavigator(Me.DataGridViewfamilia, System.Windows.Forms.HelpNavigator.Topic)
        Me.DataGridViewfamilia.Location = New System.Drawing.Point(42, 86)
        Me.DataGridViewfamilia.Name = "DataGridViewfamilia"
        Me.HelpProviderHG.SetShowHelp(Me.DataGridViewfamilia, True)
        Me.DataGridViewfamilia.Size = New System.Drawing.Size(389, 307)
        Me.DataGridViewfamilia.TabIndex = 9
        '
        'IDPatente
        '
        Me.IDPatente.HeaderText = "IDPatente"
        Me.IDPatente.Name = "IDPatente"
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        '
        'Agregada
        '
        Me.Agregada.HeaderText = "Agregar"
        Me.Agregada.Name = "Agregada"
        '
        'btnconfirmarmodificaciones
        '
        Me.HelpProviderHG.SetHelpKeyword(Me.btnconfirmarmodificaciones, "FormFamilias.htm#btnconfirmarmodificaciones")
        Me.HelpProviderHG.SetHelpNavigator(Me.btnconfirmarmodificaciones, System.Windows.Forms.HelpNavigator.Topic)
        Me.btnconfirmarmodificaciones.Location = New System.Drawing.Point(311, 406)
        Me.btnconfirmarmodificaciones.Name = "btnconfirmarmodificaciones"
        Me.HelpProviderHG.SetShowHelp(Me.btnconfirmarmodificaciones, True)
        Me.btnconfirmarmodificaciones.Size = New System.Drawing.Size(133, 23)
        Me.btnconfirmarmodificaciones.TabIndex = 12
        Me.btnconfirmarmodificaciones.Text = "Asignar"
        Me.btnconfirmarmodificaciones.UseVisualStyleBackColor = True
        '
        'HelpProviderHG
        '
        Me.HelpProviderHG.HelpNamespace = "MiProyecto.chm"
        '
        'FormFamilias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 441)
        Me.Controls.Add(Me.btnconfirmarmodificaciones)
        Me.Controls.Add(Me.DataGridViewfamilia)
        Me.Controls.Add(Me.txtfamilia)
        Me.Controls.Add(Me.Combofamilia)
        Me.HelpProviderHG.SetHelpKeyword(Me, "FormFamilias.htm")
        Me.HelpProviderHG.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.Name = "FormFamilias"
        Me.HelpProviderHG.SetShowHelp(Me, True)
        Me.Text = "FormFamilias"
        CType(Me.DataGridViewfamilia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Combofamilia As System.Windows.Forms.ComboBox
    Friend WithEvents txtfamilia As System.Windows.Forms.Label
    Friend WithEvents DataGridViewfamilia As System.Windows.Forms.DataGridView
    Friend WithEvents btnconfirmarmodificaciones As System.Windows.Forms.Button
    Friend WithEvents IDPatente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Agregada As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents HelpProviderHG As System.Windows.Forms.HelpProvider
End Class
