<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRestore
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
        Me.btnCarpeta = New System.Windows.Forms.Button()
        Me.lstArchivo = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.HelpProviderHG = New System.Windows.Forms.HelpProvider()
        Me.SuspendLayout()
        '
        'btnCarpeta
        '
        Me.HelpProviderHG.SetHelpKeyword(Me.btnCarpeta, "FormRestore.htm#btnCarpeta")
        Me.HelpProviderHG.SetHelpNavigator(Me.btnCarpeta, System.Windows.Forms.HelpNavigator.Topic)
        Me.btnCarpeta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCarpeta.Location = New System.Drawing.Point(524, 58)
        Me.btnCarpeta.Name = "btnCarpeta"
        Me.HelpProviderHG.SetShowHelp(Me.btnCarpeta, True)
        Me.btnCarpeta.Size = New System.Drawing.Size(33, 20)
        Me.btnCarpeta.TabIndex = 36
        Me.btnCarpeta.Text = "..."
        Me.btnCarpeta.UseVisualStyleBackColor = True
        '
        'lstArchivo
        '
        Me.lstArchivo.FormattingEnabled = True
        Me.HelpProviderHG.SetHelpKeyword(Me.lstArchivo, "FormRestore.htm#lstArchivo")
        Me.HelpProviderHG.SetHelpNavigator(Me.lstArchivo, System.Windows.Forms.HelpNavigator.Topic)
        Me.lstArchivo.Location = New System.Drawing.Point(131, 93)
        Me.lstArchivo.Name = "lstArchivo"
        Me.HelpProviderHG.SetShowHelp(Me.lstArchivo, True)
        Me.lstArchivo.Size = New System.Drawing.Size(426, 134)
        Me.lstArchivo.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(90, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 17)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Path"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRuta
        '
        Me.txtRuta.Enabled = False
        Me.HelpProviderHG.SetHelpKeyword(Me.txtRuta, "FormRestore.htm#Label1")
        Me.HelpProviderHG.SetHelpNavigator(Me.txtRuta, System.Windows.Forms.HelpNavigator.Topic)
        Me.txtRuta.Location = New System.Drawing.Point(131, 58)
        Me.txtRuta.Name = "txtRuta"
        Me.HelpProviderHG.SetShowHelp(Me.txtRuta, True)
        Me.txtRuta.Size = New System.Drawing.Size(387, 20)
        Me.txtRuta.TabIndex = 33
        '
        'btnAceptar
        '
        Me.HelpProviderHG.SetHelpKeyword(Me.btnAceptar, "FormRestore.htm#btnAceptar")
        Me.HelpProviderHG.SetHelpNavigator(Me.btnAceptar, System.Windows.Forms.HelpNavigator.Topic)
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(430, 242)
        Me.btnAceptar.Name = "btnAceptar"
        Me.HelpProviderHG.SetShowHelp(Me.btnAceptar, True)
        Me.btnAceptar.Size = New System.Drawing.Size(127, 27)
        Me.btnAceptar.TabIndex = 31
        Me.btnAceptar.Text = "&Aceptar"
        '
        'HelpProviderHG
        '
        Me.HelpProviderHG.HelpNamespace = "MiProyecto.chm"
        '
        'FormRestore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 322)
        Me.Controls.Add(Me.btnCarpeta)
        Me.Controls.Add(Me.lstArchivo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRuta)
        Me.Controls.Add(Me.btnAceptar)
        Me.HelpProviderHG.SetHelpKeyword(Me, "FormRestore.htm")
        Me.HelpProviderHG.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.Name = "FormRestore"
        Me.HelpProviderHG.SetShowHelp(Me, True)
        Me.Text = "FormRestore"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCarpeta As System.Windows.Forms.Button
    Friend WithEvents lstArchivo As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents HelpProviderHG As System.Windows.Forms.HelpProvider
End Class
