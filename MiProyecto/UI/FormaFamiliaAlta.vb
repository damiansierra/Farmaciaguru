Public Class FormaFamiliaAlta

 
  
    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        '   Dim lenguajeBLL As New LenguajeBLL()
        Dim Familia As New BE.Familia
        Try
            Me.ValidarCampos()

            Familia.Nombre = Me.TxtNombre.Text
            Dim familiaBll As New BLL.Familia
            familiaBll.alta(Familia)
            '      MsgBox(lenguajeBLL.Traducir("OperacionExitosa"), MsgBoxStyle.Information, Me.Text)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.TxtNombre.Clear()
            Dim BLLbitacora As New BLL.Bitacora
            Dim bebitacora As New BE.Bitacora With {.Criticidad = "ALTA", .nick = UI.FormInicio.Usuariologueado.Nick, .Descripcion = "SE CREO FAMILIA " & Familia.Nombre}
            BLLbitacora.alta(bebitacora)

      Catch ex As Exception
            MsgBox("Problemas con la base de datos")

        End Try
    End Sub

    Private Sub FormaFamiliaAlta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If UI.Login.idioma = "2" Then
            Me.Label1.Text = "Family name"
            Me.BtnAceptar.Text = "Acept"
        End If

        Dim Familia As New BE.Familia
        If (Familia Is Nothing AndAlso Familia.IdFamilia <> 0) Then
            Me.TxtNombre.Text = Familia.Nombre
        End If

    End Sub


    Private Sub ValidarCampos()
        If String.IsNullOrEmpty(Me.txtNombre.Text) Then
            If UI.Login.idioma = "2" Then
                MsgBox("You must complete a name")
            Else
                MsgBox("Debe ingresar un Nombre")
            End If
        End If
    End Sub
End Class