<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBackup
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
        Me.nudValor = New System.Windows.Forms.NumericUpDown()
        Me.btnCarpeta = New System.Windows.Forms.Button()
        Me.txtruta = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lblruta = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.HelpProviderHG = New System.Windows.Forms.HelpProvider()
        CType(Me.nudValor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nudValor
        '
        Me.HelpProviderHG.SetHelpKeyword(Me.nudValor, "FormBackup.htm#nudValor")
        Me.HelpProviderHG.SetHelpNavigator(Me.nudValor, System.Windows.Forms.HelpNavigator.Topic)
        Me.nudValor.Location = New System.Drawing.Point(364, 120)
        Me.nudValor.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.nudValor.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudValor.Name = "nudValor"
        Me.nudValor.ReadOnly = True
        Me.HelpProviderHG.SetShowHelp(Me.nudValor, True)
        Me.nudValor.Size = New System.Drawing.Size(77, 20)
        Me.nudValor.TabIndex = 24
        Me.nudValor.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnCarpeta
        '
        Me.HelpProviderHG.SetHelpKeyword(Me.btnCarpeta, "FormBackup.htm#btnCarpeta")
        Me.HelpProviderHG.SetHelpNavigator(Me.btnCarpeta, System.Windows.Forms.HelpNavigator.Topic)
        Me.btnCarpeta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCarpeta.Location = New System.Drawing.Point(412, 72)
        Me.btnCarpeta.Name = "btnCarpeta"
        Me.HelpProviderHG.SetShowHelp(Me.btnCarpeta, True)
        Me.btnCarpeta.Size = New System.Drawing.Size(29, 23)
        Me.btnCarpeta.TabIndex = 21
        Me.btnCarpeta.Text = "..."
        Me.btnCarpeta.UseVisualStyleBackColor = True
        '
        'txtruta
        '
        Me.HelpProviderHG.SetHelpKeyword(Me.txtruta, "FormBackup.htm#lblruta")
        Me.HelpProviderHG.SetHelpNavigator(Me.txtruta, System.Windows.Forms.HelpNavigator.Topic)
        Me.txtruta.Location = New System.Drawing.Point(118, 74)
        Me.txtruta.Name = "txtruta"
        Me.txtruta.ReadOnly = True
        Me.HelpProviderHG.SetShowHelp(Me.txtruta, True)
        Me.txtruta.Size = New System.Drawing.Size(288, 20)
        Me.txtruta.TabIndex = 18
        '
        'btnAceptar
        '
        Me.HelpProviderHG.SetHelpKeyword(Me.btnAceptar, "FormBackup.htm#btnAceptar")
        Me.HelpProviderHG.SetHelpNavigator(Me.btnAceptar, System.Windows.Forms.HelpNavigator.Topic)
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(314, 161)
        Me.btnAceptar.Name = "btnAceptar"
        Me.HelpProviderHG.SetShowHelp(Me.btnAceptar, True)
        Me.btnAceptar.Size = New System.Drawing.Size(127, 27)
        Me.btnAceptar.TabIndex = 22
        Me.btnAceptar.Text = "&Aceptar"
        '
        'lblruta
        '
        Me.lblruta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblruta.Location = New System.Drawing.Point(57, 74)
        Me.lblruta.Name = "lblruta"
        Me.lblruta.Size = New System.Drawing.Size(45, 17)
        Me.lblruta.TabIndex = 19
        Me.lblruta.Text = "Path"
        Me.lblruta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCantidad
        '
        Me.lblCantidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCantidad.Location = New System.Drawing.Point(272, 120)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(68, 31)
        Me.lblCantidad.TabIndex = 20
        Me.lblCantidad.Text = "Cantidad de partes"
        Me.lblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HelpProviderHG
        '
        Me.HelpProviderHG.HelpNamespace = "MiProyecto.chm"
        '
        'FormBackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(486, 261)
        Me.Controls.Add(Me.nudValor)
        Me.Controls.Add(Me.btnCarpeta)
        Me.Controls.Add(Me.txtruta)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.lblruta)
        Me.Controls.Add(Me.lblCantidad)
        Me.HelpProviderHG.SetHelpKeyword(Me, "FormBackup.htm")
        Me.HelpProviderHG.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.Name = "FormBackup"
        Me.HelpProviderHG.SetShowHelp(Me, True)
        Me.Text = "FormBackup"
        CType(Me.nudValor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents nudValor As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnCarpeta As System.Windows.Forms.Button
    Friend WithEvents txtruta As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents lblruta As System.Windows.Forms.Label
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents HelpProviderHG As System.Windows.Forms.HelpProvider
End Class
