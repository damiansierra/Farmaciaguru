Public Class FormLaboratoriosAlta
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click

        Try
            Dim laboratorio As New BE.Laboratorio

            Dim blllaboratorio As New BLL.Laboratorio

            laboratorio.Nombre = Trim(TxtNombre.Text)
       
            laboratorio.Direccion = Trim(TxtDireccion.Text)
            laboratorio.telefono = Trim(TxtTelefono.Text)


            Dim laboratoriobll As New BLL.Laboratorio


            laboratoriobll.alta(laboratorio)

            Dim BLLbitacora As New BLL.Bitacora
            Dim bebitacora As New BE.Bitacora With {.Criticidad = "Media", .nick = UI.FormInicio.Usuariologueado.Nick, .Descripcion = "Nuevo laboratorio creado" & laboratorio.Nombre}
            BLLbitacora.alta(bebitacora)


            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Finally
        End Try
    End Sub



    Private Sub FormUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.FormInicio = Me.MdiParent
    End Sub

End Class