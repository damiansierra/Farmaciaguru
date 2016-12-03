Public Class FormUsuario


   
    
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        'Dim lenguajeBLL As New LenguajeBLL()
        'Dim bitacoraBll As New BitacoraBLL()
        Dim stringrandom As String = GenerateRandomString(5)
        Try
            Dim usuario As New BE.Usuario
            Dim bllusuario As New BLL.Usuario
            ' Me.ValidarCampos()
            usuario.Nick = Trim(TxtNick.Text)
            'En caso de ser un usuario nuevo si guardo el Password
            ' If (usuario.IdUsuario = 0) Then
            usuario.Password = Trim(stringrandom)
            '    End If
            usuario.Nombre = Trim(TxtNombre.Text)
            usuario.Apellido = Trim(TxtApellido.Text)


            Dim usuarioLogic As New BLL.Usuario


            usuarioLogic.alta(usuario)

            Dim BLLbitacora As New BLL.Bitacora
            Dim bebitacora As New BE.Bitacora With {.Criticidad = "ALTA", .nick = UI.FormInicio.Usuariologueado.Nick, .Descripcion = "Nuevo usuario creado" & usuario.Nick}
            BLLbitacora.alta(bebitacora)


            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Finally
        End Try
    End Sub

  

    Private Sub FormUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.FormInicio = Me.MdiParent
    End Sub



    Public Function GenerateRandomString(ByRef iLength As Integer) As String
        Dim rdm As New Random()
        Dim allowChrs() As Char = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLOMNOPQRSTUVWXYZ0123456789".ToCharArray()
        Dim sResult As String = ""

        For i As Integer = 0 To iLength - 1
            sResult += allowChrs(rdm.Next(0, allowChrs.Length))
        Next

        Return sResult
    End Function

End Class