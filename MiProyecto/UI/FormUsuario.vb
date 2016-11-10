Public Class FormUsuario


   
    
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        'Dim lenguajeBLL As New LenguajeBLL()
        'Dim bitacoraBll As New BitacoraBLL()
        Try
            Dim usuario As New BE.Usuario
            Dim bllusuario As New BLL.Usuario
            ' Me.ValidarCampos()
            usuario.Nick = TxtNick.Text
            'En caso de ser un usuario nuevo si guardo el Password
            If (usuario.Id = 0) Then
                usuario.Password = Txtpassword.Text
            End If
            usuario.Nombre = TxtNombre.Text
            usuario.Apellido = TxtApellido.Text
            

            Dim usuarioLogic As New BLL.Usuario


            usuarioLogic.alta(usuario)

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Finally
        End Try
    End Sub
End Class