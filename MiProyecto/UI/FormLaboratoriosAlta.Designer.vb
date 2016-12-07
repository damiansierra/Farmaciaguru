<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLaboratoriosAlta
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
        Me.TxtDireccion = New System.Windows.Forms.TextBox()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtTelefono = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.HelpProviderHG = New System.Windows.Forms.HelpProvider()
        Me.SuspendLayout()
        '
        'TxtDireccion
        '
        Me.HelpProviderHG.SetHelpKeyword(Me.TxtDireccion, "FormLaboratoriosAlta.htm#Label3")
        Me.HelpProviderHG.SetHelpNavigator(Me.TxtDireccion, System.Windows.Forms.HelpNavigator.Topic)
        Me.TxtDireccion.Location = New System.Drawing.Point(171, 104)
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.HelpProviderHG.SetShowHelp(Me.TxtDireccion, True)
        Me.TxtDireccion.Size = New System.Drawing.Size(149, 20)
        Me.TxtDireccion.TabIndex = 13
        '
        'TxtNombre
        '
        Me.HelpProviderHG.SetHelpKeyword(Me.TxtNombre, "FormLaboratoriosAlta.htm#Label2")
        Me.HelpProviderHG.SetHelpNavigator(Me.TxtNombre, System.Windows.Forms.HelpNavigator.Topic)
        Me.TxtNombre.Location = New System.Drawing.Point(171, 62)
        Me.TxtNombre.Name = "TxtNombre"
        Me.HelpProviderHG.SetShowHelp(Me.TxtNombre, True)
        Me.TxtNombre.Size = New System.Drawing.Size(149, 20)
        Me.TxtNombre.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(65, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Dirección"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(65, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 20)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Nombre"
        '
        'TxtTelefono
        '
        Me.HelpProviderHG.SetHelpKeyword(Me.TxtTelefono, "FormLaboratoriosAlta.htm#Label1")
        Me.HelpProviderHG.SetHelpNavigator(Me.TxtTelefono, System.Windows.Forms.HelpNavigator.Topic)
        Me.TxtTelefono.Location = New System.Drawing.Point(171, 144)
        Me.TxtTelefono.Name = "TxtTelefono"
        Me.HelpProviderHG.SetShowHelp(Me.TxtTelefono, True)
        Me.TxtTelefono.Size = New System.Drawing.Size(149, 20)
        Me.TxtTelefono.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(65, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 20)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Telefono"
        '
        'BtnAceptar
        '
        Me.HelpProviderHG.SetHelpKeyword(Me.BtnAceptar, "FormLaboratoriosAlta.htm#BtnAceptar")
        Me.HelpProviderHG.SetHelpNavigator(Me.BtnAceptar, System.Windows.Forms.HelpNavigator.Topic)
        Me.BtnAceptar.Location = New System.Drawing.Point(245, 216)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.HelpProviderHG.SetShowHelp(Me.BtnAceptar, True)
        Me.BtnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.BtnAceptar.TabIndex = 16
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'HelpProviderHG
        '
        Me.HelpProviderHG.HelpNamespace = "MiProyecto.chm"
        '
        'FormLaboratoriosAlta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 261)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.TxtTelefono)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtDireccion)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.HelpProviderHG.SetHelpKeyword(Me, "FormLaboratoriosAlta.htm")
        Me.HelpProviderHG.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.Name = "FormLaboratoriosAlta"
        Me.HelpProviderHG.SetShowHelp(Me, True)
        Me.Text = "FormLaboratoriosAlta"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
    Friend WithEvents HelpProviderHG As System.Windows.Forms.HelpProvider
End Class
