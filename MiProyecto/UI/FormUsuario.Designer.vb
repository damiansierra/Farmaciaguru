﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUsuario
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtNick = New System.Windows.Forms.TextBox()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.TxtApellido = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.HelpProviderHG = New System.Windows.Forms.HelpProvider()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(55, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nick"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(55, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(55, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Apellido"
        '
        'TxtNick
        '
        Me.HelpProviderHG.SetHelpKeyword(Me.TxtNick, "FormUsuario.htm#Label1")
        Me.HelpProviderHG.SetHelpNavigator(Me.TxtNick, System.Windows.Forms.HelpNavigator.Topic)
        Me.TxtNick.Location = New System.Drawing.Point(161, 60)
        Me.TxtNick.Name = "TxtNick"
        Me.HelpProviderHG.SetShowHelp(Me.TxtNick, True)
        Me.TxtNick.Size = New System.Drawing.Size(149, 20)
        Me.TxtNick.TabIndex = 5
        '
        'TxtNombre
        '
        Me.HelpProviderHG.SetHelpKeyword(Me.TxtNombre, "FormUsuario.htm#Label2")
        Me.HelpProviderHG.SetHelpNavigator(Me.TxtNombre, System.Windows.Forms.HelpNavigator.Topic)
        Me.TxtNombre.Location = New System.Drawing.Point(161, 99)
        Me.TxtNombre.Name = "TxtNombre"
        Me.HelpProviderHG.SetShowHelp(Me.TxtNombre, True)
        Me.TxtNombre.Size = New System.Drawing.Size(149, 20)
        Me.TxtNombre.TabIndex = 6
        '
        'TxtApellido
        '
        Me.HelpProviderHG.SetHelpKeyword(Me.TxtApellido, "FormUsuario.htm#Label3")
        Me.HelpProviderHG.SetHelpNavigator(Me.TxtApellido, System.Windows.Forms.HelpNavigator.Topic)
        Me.TxtApellido.Location = New System.Drawing.Point(161, 134)
        Me.TxtApellido.Name = "TxtApellido"
        Me.HelpProviderHG.SetShowHelp(Me.TxtApellido, True)
        Me.TxtApellido.Size = New System.Drawing.Size(149, 20)
        Me.TxtApellido.TabIndex = 7
        '
        'btnAceptar
        '
        Me.HelpProviderHG.SetHelpKeyword(Me.btnAceptar, "FormUsuario.htm#btnAceptar")
        Me.HelpProviderHG.SetHelpNavigator(Me.btnAceptar, System.Windows.Forms.HelpNavigator.Topic)
        Me.btnAceptar.Location = New System.Drawing.Point(235, 185)
        Me.btnAceptar.Name = "btnAceptar"
        Me.HelpProviderHG.SetShowHelp(Me.btnAceptar, True)
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'HelpProviderHG
        '
        Me.HelpProviderHG.HelpNamespace = "MiProyecto.chm"
        '
        'FormUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 237)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.TxtApellido)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.TxtNick)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.HelpProviderHG.SetHelpKeyword(Me, "FormUsuario.htm")
        Me.HelpProviderHG.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.Name = "FormUsuario"
        Me.HelpProviderHG.SetShowHelp(Me, True)
        Me.Text = "FormUsuario"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtNick As System.Windows.Forms.TextBox
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents TxtApellido As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents HelpProviderHG As System.Windows.Forms.HelpProvider
End Class
