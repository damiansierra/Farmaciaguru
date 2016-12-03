Public Class FormUsuarioEliminar

    Private Sub FormUsuarioEliminar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.StartPosition = FormStartPosition.CenterScreen


            '  CAMBIARIDIOMAS()


            COMBOUSER.Items.Clear()
            COMBOUSER.Items.Clear()
            COMBOUSER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            CARGARCOMBOUSER()





        Catch ex As Exception

        End Try

    End Sub

    Sub CARGARCOMBOUSER()
        Try


            Dim listausuarios As New List(Of BE.Usuario)
            Dim bllusuario As New BLL.Usuario

            listausuarios = bllusuario.listarTodos


            For Each USER As BE.Usuario In listausuarios
                COMBOUSER.Items.Add(USER.Nick)
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Dim bllusuario As New BLL.Usuario
            Dim Nick As New BE.Usuario With {.Nick = COMBOUSER.Text}

            '        USUARIO = bllusuario.CONSULTA(USUARIO)

            If COMBOUSER.Text <> "" Then
                If BLL.Usuario.GetInstance.ValidarEliminarUsuario(BLL.Usuario.GetInstance.listarPorId(Nick)) Then
                    If BLL.Usuario.GetInstance.Validarultimo() = True Then
                        If bllusuario.baja(Nick) = True Then
                            MessageBox.Show("SE ELIMINO USUARIO")
                            COMBOUSER.Items.Clear()
                            CARGARCOMBOUSER()

                            Dim BLLbitacora As New BLL.Bitacora
                            Dim bebitacora As New BE.Bitacora With {.Criticidad = "ALTA", .nick = UI.FormInicio.Usuariologueado.Nick, .Descripcion = "SE ELIMINO USUARIO " & COMBOUSER.Text}
                            BLLbitacora.alta(bebitacora)
                        End If
                    Else

                        MessageBox.Show("NO SE PUEDE ELIMINAR EL USUARIO")
                    End If
                Else
                    MessageBox.Show("NO SE PUEDE ELIMINAR EL USUARIO")
                End If
            Else
                MessageBox.Show("DEBE SELECCIONAR UN USUARIO")
            End If



        Catch ex As Exception
            MessageBox.Show("ERROR AL ELIMINAR EL USUARIO")
        End Try

    End Sub



    '  Public Sub CAMBIARIDIOMAS()
    ' Try

    '      If UI.Principal.Usuariologueado.IDIOMA.ID_IDIOMA <> 1 Then
    'Dim BLLMENSAJEIDIOMA As New BLL.MENSAJEIDIOMA(UI.Principal.Usuariologueado.IDIOMA)
    '      BLLMENSAJEIDIOMA.TraducirForm(Me)

    ' End If
    '
    '   Catch ex As Exception
    '    MessageBox.Show("IMPOSIBLE CAMBIAR EL IDIOMA")
    '     End Try
    ' End Sub

    

End Class