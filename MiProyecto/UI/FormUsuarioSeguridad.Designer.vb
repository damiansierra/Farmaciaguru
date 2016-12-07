<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUsuarioSeguridad
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
        Me.components = New System.ComponentModel.Container()
        Me.COMBOUSER = New System.Windows.Forms.ComboBox()
        Me.dgFamilias = New System.Windows.Forms.DataGridView()
        Me.familia_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre_Familia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgAsignarFamilia = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.txtfamilia = New System.Windows.Forms.Label()
        Me.btnconfirmarmodificaciones = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgPatentes = New System.Windows.Forms.DataGridView()
        Me.patente_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgAsignarPatente = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgPatenteNegada = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.dgFamilias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgPatentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'COMBOUSER
        '
        Me.COMBOUSER.FormattingEnabled = True
        Me.COMBOUSER.Location = New System.Drawing.Point(192, 41)
        Me.COMBOUSER.Name = "COMBOUSER"
        Me.COMBOUSER.Size = New System.Drawing.Size(204, 21)
        Me.COMBOUSER.TabIndex = 0
        '
        'dgFamilias
        '
        Me.dgFamilias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFamilias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.familia_id, Me.Nombre_Familia, Me.dgAsignarFamilia})
        Me.dgFamilias.Location = New System.Drawing.Point(22, 116)
        Me.dgFamilias.Name = "dgFamilias"
        Me.dgFamilias.Size = New System.Drawing.Size(344, 251)
        Me.dgFamilias.TabIndex = 1
        '
        'familia_id
        '
        Me.familia_id.HeaderText = "ID Familia"
        Me.familia_id.Name = "familia_id"
        '
        'Nombre_Familia
        '
        Me.Nombre_Familia.HeaderText = "Nombre"
        Me.Nombre_Familia.Name = "Nombre_Familia"
        '
        'dgAsignarFamilia
        '
        Me.dgAsignarFamilia.HeaderText = "Asignar"
        Me.dgAsignarFamilia.Name = "dgAsignarFamilia"
        '
        'txtfamilia
        '
        Me.txtfamilia.AutoSize = True
        Me.txtfamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfamilia.Location = New System.Drawing.Point(18, 93)
        Me.txtfamilia.Name = "txtfamilia"
        Me.txtfamilia.Size = New System.Drawing.Size(59, 20)
        Me.txtfamilia.TabIndex = 2
        Me.txtfamilia.Text = "Familia"
        '
        'btnconfirmarmodificaciones
        '
        Me.btnconfirmarmodificaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnconfirmarmodificaciones.Location = New System.Drawing.Point(741, 401)
        Me.btnconfirmarmodificaciones.Name = "btnconfirmarmodificaciones"
        Me.btnconfirmarmodificaciones.Size = New System.Drawing.Size(101, 37)
        Me.btnconfirmarmodificaciones.TabIndex = 3
        Me.btnconfirmarmodificaciones.Text = "Confirmar"
        Me.btnconfirmarmodificaciones.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Seleccione un Usuario"
        '
        'dgPatentes
        '
        Me.dgPatentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPatentes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.patente_id, Me.Nombre, Me.dgAsignarPatente, Me.dgPatenteNegada})
        Me.dgPatentes.Location = New System.Drawing.Point(398, 116)
        Me.dgPatentes.Name = "dgPatentes"
        Me.dgPatentes.Size = New System.Drawing.Size(444, 251)
        Me.dgPatentes.TabIndex = 5
        '
        'patente_id
        '
        Me.patente_id.HeaderText = "ID Patente"
        Me.patente_id.Name = "patente_id"
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        '
        'dgAsignarPatente
        '
        Me.dgAsignarPatente.HeaderText = "Asignar"
        Me.dgAsignarPatente.Name = "dgAsignarPatente"
        '
        'dgPatenteNegada
        '
        Me.dgPatenteNegada.HeaderText = "Negar"
        Me.dgPatenteNegada.Name = "dgPatenteNegada"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(394, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Pantente"
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Something"
        '
        'FormUsuarioSeguridad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 496)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgPatentes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnconfirmarmodificaciones)
        Me.Controls.Add(Me.txtfamilia)
        Me.Controls.Add(Me.dgFamilias)
        Me.Controls.Add(Me.COMBOUSER)
        Me.Name = "FormUsuarioSeguridad"
        Me.Text = "FormUsuarioSeguridad"
        CType(Me.dgFamilias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgPatentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents COMBOUSER As System.Windows.Forms.ComboBox
    Friend WithEvents dgFamilias As System.Windows.Forms.DataGridView
    Friend WithEvents txtfamilia As System.Windows.Forms.Label
    Friend WithEvents btnconfirmarmodificaciones As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgPatentes As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents familia_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre_Familia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgAsignarFamilia As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents patente_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgAsignarPatente As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgPatenteNegada As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
