Public Class FormInicio
    Public Usuariologueado As New BE.Usuario


  
    Private Sub FormInicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UI.Login.Hide()
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Dim BLLbitacora As New BLL.Bitacora
        Dim bebitacora As New BE.Bitacora With {.Criticidad = "BAJA", .nick = Usuariologueado.Nick, .Descripcion = "Usuario Logueado"}
        BLLbitacora.alta(bebitacora)

    End Sub

   
    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Dim BLLbitacora As New BLL.Bitacora
        Dim bebitacora As New BE.Bitacora With {.Criticidad = "BAJA", .nick = Usuariologueado.Nick, .Descripcion = "Usuario Deslogueado"}
        BLLbitacora.alta(bebitacora)
        Me.Close()
    End Sub

    Private Sub AltaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AltaToolStripMenuItem.Click
        UI.FormUsuario.MdiParent = Me
        UI.FormUsuario.Show()

    End Sub

    Private Sub BajaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BajaToolStripMenuItem.Click
        UI.FormUsuarioEliminar.MdiParent = Me
        UI.FormUsuarioEliminar.Show()
    End Sub

    Private Sub AsignarPermisosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignarPermisosToolStripMenuItem.Click
        UI.FormUsuarioSeguridad.MdiParent = Me
        UI.FormUsuarioSeguridad.Show()
    End Sub

    Private Sub AltaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AltaToolStripMenuItem1.Click
        UI.FormaFamiliaAlta.MdiParent = Me
        UI.FormaFamiliaAlta.Show()
    End Sub

    Private Sub ModificaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificaciónToolStripMenuItem.Click
        UI.FormFamilias.MdiParent = Me
        UI.FormFamilias.Show()
    End Sub

    Private Sub ListarToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ListarToolStripMenuItem5.Click
        UI.FormPatente.MdiParent = Me
        UI.FormPatente.Show()
    End Sub

    Private Sub BajaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BajaToolStripMenuItem1.Click
        UI.FormFamiliaBaja.MdiParent = Me
        UI.FormFamiliaBaja.Show()
    End Sub

    Private Sub BitacoraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BitacoraToolStripMenuItem.Click
        UI.FormBitacora.MdiParent = Me
        UI.FormBitacora.Show()
    End Sub

   
    Private Sub LaboratorioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaboratorioToolStripMenuItem.Click
        UI.FormLaboratoriosAlta.MdiParent = Me
        UI.FormLaboratoriosAlta.Show()
    End Sub

    Private Sub ProductoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductoToolStripMenuItem.Click
        UI.FormAltaProductos.MdiParent = Me
        UI.FormAltaProductos.Show()
    End Sub

    Private Sub PedidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedidosToolStripMenuItem.Click
        UI.FormVentas.MdiParent = Me
        UI.FormVentas.Show()

    End Sub

    Private Sub OrdenesDeCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdenesDeCompraToolStripMenuItem.Click
        UI.FormVentasTicket.MdiParent = Me
        UI.FormVentasTicket.Show()
    End Sub
End Class