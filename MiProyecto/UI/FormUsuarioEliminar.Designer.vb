﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUsuarioEliminar
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
        Me.COMBOUSER = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.HelpProviderHG = New System.Windows.Forms.HelpProvider()
        Me.SuspendLayout()
        '
        'COMBOUSER
        '
        Me.COMBOUSER.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COMBOUSER.FormattingEnabled = True
        Me.HelpProviderHG.SetHelpKeyword(Me.COMBOUSER, "FormUsuarioEliminar.htm#Label1")
        Me.HelpProviderHG.SetHelpNavigator(Me.COMBOUSER, System.Windows.Forms.HelpNavigator.Topic)
        Me.COMBOUSER.Location = New System.Drawing.Point(164, 81)
        Me.COMBOUSER.Name = "COMBOUSER"
        Me.HelpProviderHG.SetShowHelp(Me.COMBOUSER, True)
        Me.COMBOUSER.Size = New System.Drawing.Size(173, 28)
        Me.COMBOUSER.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(66, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Usuario"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpProviderHG.SetHelpKeyword(Me.Button1, "FormUsuarioEliminar.htm#Button1")
        Me.HelpProviderHG.SetHelpNavigator(Me.Button1, System.Windows.Forms.HelpNavigator.Topic)
        Me.Button1.Location = New System.Drawing.Point(232, 173)
        Me.Button1.Name = "Button1"
        Me.HelpProviderHG.SetShowHelp(Me.Button1, True)
        Me.Button1.Size = New System.Drawing.Size(105, 38)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Eliminar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'HelpProviderHG
        '
        Me.HelpProviderHG.HelpNamespace = "MiProyecto.chm"
        '
        'FormUsuarioEliminar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 251)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.COMBOUSER)
        Me.HelpProviderHG.SetHelpKeyword(Me, "FormUsuarioEliminar.htm")
        Me.HelpProviderHG.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.Name = "FormUsuarioEliminar"
        Me.HelpProviderHG.SetShowHelp(Me, True)
        Me.Text = "FormUsuarioEliminar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents COMBOUSER As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents HelpProviderHG As System.Windows.Forms.HelpProvider
End Class
