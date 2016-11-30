Public Class Login

  
  
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        UI.FormInicio.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim BLLDV As New BLL.DV
        Try

            Dim I As Integer = logueo(txtuser.Text, Trim(txtpass.Text))
            FormInicio.Usuariologueado.Nick = txtuser.Text



            If BLLDV.verificarDV() = False And I <> 3 Then
                MessageBox.Show("LA BASE DE DATOS HA SIDO MODIFICADA")

                Dim BLLbitacora As New BLL.BITACORA
                Dim bebitacora As New BE.Bitacora With {.Criticidad = "ALTA", .nick = FormInicio.Usuariologueado.Nick, .Descripcion = "FALLO EN LA INTEGRACION DE LA BASE DE DATOS"}
                BLLbitacora.ALTA(bebitacora)

                Me.Close()
                UI.FormInicio.Close()
            End If

            If BLLDV.verificarDV() = False And I = 3 Then


                MessageBox.Show("LA BASE DE DATOS A SIDO MODIFICADA, RECALCULE LOS DIGITOS VERIFICADORES")
                Me.Close()
                Dim BLLUSUARIO As New BLL.Usuario
                FormInicio.Usuariologueado = BLLUSUARIO.listarPorId(FormInicio.Usuariologueado)
                Dim BLLbitacora As New BLL.Bitacora
                Dim bebitacora As New BE.Bitacora With {.Criticidad = "ALTA", .nick = UI.FormInicio.Usuariologueado.Nick, .Descripcion = "FALLO EN LA INTEGRACION DE LA BASE DE DATOS"}
                BLLbitacora.alta(bebitacora)
                UI.FormInicio.Show()
                '  UI.Principal.CAMBIARIDIOMAS()
                '   ACTIVARFORMPRINCIPALFALLODV()
            End If

            If BLLDV.verificarDV() = True And (I = 1 Or I = 3) Then


                '    Dim MenuUI As New FormInicio()
                ' MenuUI.Show()

                '''''''''''''''' CARGA EL USUARIO LOGUEADO Y MUESTRA  ''''''''''''''''
                Try
                    Dim BLLUSUARIO As New BLL.Usuario



                    FormInicio.Usuariologueado = BLLUSUARIO.listarPorId(FormInicio.Usuariologueado)
                    UI.FormInicio.Show()
                    ACTIVARFORMPRINCIPALFALLODV()
                    ACTIVARFORMPRINCIPAL(FormInicio.Usuariologueado)

                    '  UI.Principal.CAMBIARIDIOMAS()
                    '     UI.RevisionDispositivos.Show()
                    '    UI.RevisionDispositivos.Visible = False

                    '     Me.Close()
                Catch ex As Exception
                    MessageBox.Show("ERROR CARGANDO LOS DATOS DEL USUARIO")
                End Try
            End If




            If I = 4 Then
                MessageBox.Show("USUARIO BLOQUEADO POR FAVOR CONTACTESE CON EL ADMINISTRADOR PARA REALIZAR UN RESETEO DE SU CONTRASEÑA / DESBLOQUEO DE SU USUARIO")
            End If

            If (I = 2 Or I = 0) Then
                MessageBox.Show("USUARIO O CONTRASEÑA INCORRECTOS")
            End If

        Catch ex As Exception
            MessageBox.Show("FALLO AL CALCULAR LOS DIGITOS VERIFICADORES")
        End Try

    End Sub


    Private Function logueo(USER As String, pass As String) As Integer
        Try
            Dim USUARIO As New BE.Usuario With {.Nick = Trim(USER), .Password = Trim(pass)}
            Dim BLLUSUARIO As New BLL.Usuario
            Dim LOGUEA As Integer = BLLUSUARIO.LOGIN(USUARIO)
            Return LOGUEA
        Catch ex As Exception
            MessageBox.Show("FALLO EN EL LOGUIN DE LA APLICACION")
        End Try




    End Function


    Private Sub ACTIVARFORMPRINCIPAL(USUARIO As BE.Usuario)

        For Each patente In USUARIO.Patentes
            If patente.NEGADO = False Then
                habilitarform(patente)
            End If
        Next

        Dim bllfamilia As New BLL.Familia
        For Each fam As BE.Familia In USUARIO.Familias
            fam = bllfamilia.listarPorId(fam)
            '   If fam.NEGADO = False Then
            For Each patente As BE.Patente In fam.Patente
                habilitarform(patente)
            Next
            '     End If
        Next


    End Sub

    Private Sub ACTIVARFORMPRINCIPALFALLODV()
        ' FormInicio.InicioToolStripMenuItem.Visible = False
        ' FormInicio.SalirToolStripMenuItem.Visible = False
        FormInicio.ProductosToolStripMenuItem.Visible = False
        FormInicio.IngresarToolStripMenuItem.Visible = False
        FormInicio.ListarToolStripMenuItem.Visible = False
        FormInicio.ClientesToolStripMenuItem.Visible = False
        FormInicio.IngresarToolStripMenuItem1.Visible = False
        FormInicio.ListarToolStripMenuItem1.Visible = False
        FormInicio.VentasToolStripMenuItem.Visible = False
        FormInicio.OrdenesDeCompraToolStripMenuItem.Visible = False
        FormInicio.PedidosToolStripMenuItem.Visible = False
        FormInicio.ListarToolStripMenuItem2.Visible = False
        FormInicio.SeguridadToolStripMenuItem.Visible = False
        FormInicio.GenerarBackupToolStripMenuItem.Visible = False
        FormInicio.RestoreToolStripMenuItem.Visible = False
        FormInicio.UsuariosToolStripMenuItem.Visible = False
        FormInicio.FamiliasToolStripMenuItem.Visible = False
        FormInicio.PatentesToolStripMenuItem.Visible = False
        FormInicio.BitacoraToolStripMenuItem.Visible = False
        FormInicio.AltaToolStripMenuItem.Visible = False
        FormInicio.BajaToolStripMenuItem.Visible = False
        FormInicio.AltaToolStripMenuItem1.Visible = False
        FormInicio.ModificacionToolStripMenuItem.Visible = False
        FormInicio.ListarToolStripMenuItem3.Visible = False
        FormInicio.BajaToolStripMenuItem1.Visible = False
        FormInicio.ModificaciónToolStripMenuItem.Visible = False
        FormInicio.ListarToolStripMenuItem4.Visible = False
        FormInicio.ListarToolStripMenuItem5.Visible = False
        FormInicio.AsignarPermisosToolStripMenuItem.Visible = False


        'Principal.GestionarPerfilesToolStripMenuItem.Visible = False
        'Principal.gestiondeperfiles.Visible = False
        'Principal.gestiondeperfiles.Visible = False
        'Principal.gestiondefamiliasToolStripMenuItem.Visible = False
        'Principal.gestiondeperfiles.Visible = False
        'Principal.gestiondeusuariosToolStripMenuItem.Visible = False
        'Principal.AltaDeUsuarioToolStripMenuItem.Visible = False
        'Principal.gestiondeperfiles.Visible = False
        'Principal.gestiondeusuariosToolStripMenuItem.Visible = False
        'Principal.ModificarUsuarioToolStripMenuItem.Visible = False
        'Principal.gestiondeperfiles.Visible = False
        'Principal.gestiondeusuariosToolStripMenuItem.Visible = False
        'Principal.BajaDeUsuarioToolStripMenuItem.Visible = False
        'Principal.gestiondeperfiles.Visible = False
        'Principal.gestiondeusuariosToolStripMenuItem.Visible = False
        'Principal.ReseteoDeContraseñasToolStripMenuItem.Visible = False


        'Principal.LogsToolStripMenuItem.Visible = True
        'Principal.RecalcularDigitosVerificadoresToolStripMenuItem.Visible = True
    End Sub

    Private Sub habilitarform(patente)

        '''''CU 1
        If patente.nombre = "Seguridad" Then
            FormInicio.SeguridadToolStripMenuItem.Visible = True
            FormInicio.UsuariosToolStripMenuItem.Visible = True
            FormInicio.FamiliasToolStripMenuItem.Visible = True
            FormInicio.PatentesToolStripMenuItem.Visible = True
            FormInicio.BitacoraToolStripMenuItem.Visible = True
            FormInicio.AltaToolStripMenuItem.Visible = True
            FormInicio.BajaToolStripMenuItem.Visible = True
            FormInicio.AltaToolStripMenuItem1.Visible = True
            FormInicio.ModificacionToolStripMenuItem.Visible = True
            FormInicio.ListarToolStripMenuItem3.Visible = True
            FormInicio.BajaToolStripMenuItem1.Visible = True
            FormInicio.ModificaciónToolStripMenuItem.Visible = True
            FormInicio.ListarToolStripMenuItem4.Visible = True
            FormInicio.ListarToolStripMenuItem5.Visible = True
            FormInicio.AsignarPermisosToolStripMenuItem.Visible = True
        End If
        If patente.nombre = "Clientes" Then
            FormInicio.ClientesToolStripMenuItem.Visible = True
            FormInicio.IngresarToolStripMenuItem1.Visible = True
            FormInicio.ListarToolStripMenuItem1.Visible = True
        End If

        ''''''CU 7
        If patente.nombre = "Ventas" Then
            FormInicio.VentasToolStripMenuItem.Visible = True
            FormInicio.OrdenesDeCompraToolStripMenuItem.Visible = True
            FormInicio.PedidosToolStripMenuItem.Visible = True
            FormInicio.ListarToolStripMenuItem2.Visible = True
        End If
        If patente.nombre = "Productos" Then
            FormInicio.ProductosToolStripMenuItem.Visible = True
            FormInicio.IngresarToolStripMenuItem.Visible = True
            FormInicio.ListarToolStripMenuItem.Visible = True
        End If
        If patente.nombre = "Backup" Then
            FormInicio.SeguridadToolStripMenuItem.Visible = True
            FormInicio.GenerarBackupToolStripMenuItem.Visible = True
            FormInicio.RestoreToolStripMenuItem.Visible = True
        End If
        'If patente.DESCRIPCION = "Reseteo de Contraseñas" Then
        'Principal.gestiondeperfiles.Visible = True
        '  Principal.gestiondeusuariosToolStripMenuItem.Visible = True
        ' Principal.ReseteoDeContraseñasToolStripMenuItem.Visible = True
        ' End If

        ''''''''CU 4
        '  If patente.DESCRIPCION = "Gestion de Logs" Then
        'Principal.LogsToolStripMenuItem.Visible = True
        '  End If

        ''''''''''''''RESTO
        ' If patente.DESCRIPCION = "Gestion de Dispositivos" Then
        'Principal.DispositivosToolStripMenuItem.Visible = True
        '  End If

        '  If patente.DESCRIPCION = "Gestion de Monitoreo" Then
        'Principal.MonitoreoToolStripMenuItem.Visible = True
        '  End If

        ' If patente.DESCRIPCION = "Gestion de Soportes" Then
        'Principal.IncidenciasToolStripMenuItem.Visible = True
        ' End If

        'If patente.DESCRIPCION = "Back Up y Restore" Then
        'Principal.BackUpYRestoreToolStripMenuItem.Visible = True
        '  End If


    End Sub






    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class