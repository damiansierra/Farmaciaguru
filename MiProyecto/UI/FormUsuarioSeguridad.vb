Public Class FormUsuarioSeguridad

    Private SELECCIONUSUARIOCOMBO As String = ""
    Private seleccionidusuario As Integer = 0
    Dim unUsuario As New BE.Usuario
     Private _id As String

 
    Private Sub FormUsuarioSeguridad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.StartPosition = FormStartPosition.CenterScreen

           



            COMBOUSER.Items.Clear()
            COMBOUSER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            CARGARCOMBOUSER()

            Dim toolTip1 As New ToolTip()

            ' Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000
            toolTip1.InitialDelay = 1000
            toolTip1.ReshowDelay = 500
            ' Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = True

            ' Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(Me.btnconfirmarmodificaciones, "Confirmar Asignar permisos")

            If UI.Login.idioma = "2" Then
                Me.btnconfirmarmodificaciones.Text = "Confirm"
                Me.Label1.Text = "Select"
                Me.Label3.Text = "Patent"
                Me.familia_id.HeaderText = "ID_FAMILY"
                Me.Nombre_Familia.HeaderText = "Name Family"
                Me.patente_id.HeaderText = "ID_PATENT"
                Me.Nombre.HeaderText = "NAME"

                toolTip1.SetToolTip(Me.btnconfirmarmodificaciones, "Confirm Asing permissions")
            End If

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

    Private Sub COMBOUSER_SelectedIndexChanged(sender As Object, e As EventArgs) Handles COMBOUSER.SelectedIndexChanged

        SELECCIONUSUARIOCOMBO = COMBOUSER.SelectedItem.ToString


        dgFamilias.Rows.Clear()
        For Each FamiliaBE In BLL.Familia.GetInstance().listarTodos
            Dim n As Integer = dgFamilias.Rows.Add()
            dgFamilias.Rows.Item(n).Cells("familia_id").Value = FamiliaBE.IdFamilia
            dgFamilias.Rows.Item(n).Cells("dgAsignarFamilia").Value = False
            dgFamilias.Rows.Item(n).Cells("Nombre_Familia").Value = FamiliaBE.Nombre
        Next

        dgPatentes.Rows.Clear()
        For Each PatenteBE In BLL.PatenteBLL.GetInstance().listarTodos
            Dim n As Integer = dgPatentes.Rows.Add()
            dgPatentes.Rows.Item(n).Cells("patente_id").Value = PatenteBE.Idpatente
            dgPatentes.Rows.Item(n).Cells("Nombre").Value = PatenteBE.Nombre
            dgPatentes.Rows.Item(n).Cells("dgAsignarPatente").Value = False
            dgPatentes.Rows.Item(n).Cells("dgPatenteNegada").Value = False
        Next



        unUsuario.Nick = SELECCIONUSUARIOCOMBO
        Dim UsuarioBE = BLL.Usuario.GetInstance().listarPorId(unUsuario)


        For Each FamiliaBE In UsuarioBE.Familias
            For i = 0 To dgFamilias.Rows.Count - 1
                If dgFamilias.Rows.Item(i).Cells("familia_id").Value = FamiliaBE.IdFamilia Then
                    dgFamilias.Rows.Item(i).Cells("dgAsignarFamilia").Value = True
                End If
            Next
        Next

        For Each PatenteBE In UsuarioBE.Patentes
            For i = 0 To dgPatentes.Rows.Count - 1
                If dgPatentes.Rows.Item(i).Cells("patente_id").Value = PatenteBE.Idpatente Then
                    If PatenteBE.NEGADO = False Then
                        dgPatentes.Rows.Item(i).Cells("dgAsignarPatente").Value = True
                    Else
                        dgPatentes.Rows.Item(i).Cells("dgPatenteNegada").Value = True
                    End If
                End If
            Next
        Next

    End Sub


   
    Private Sub btnconfirmarmodificaciones_Click(sender As Object, e As EventArgs) Handles btnconfirmarmodificaciones.Click

        Try
            Dim BLLUSUARIO As New BLL.Usuario
            Dim USUARIO As New BE.Usuario
            SELECCIONUSUARIOCOMBO = COMBOUSER.SelectedItem.ToString


            USUARIO.Nick = SELECCIONUSUARIOCOMBO
            
            Dim PATENTES As New List(Of BE.Patente)

            For Each _ROW As DataGridViewRow In dgPatentes.Rows
                If _ROW.Cells("dgAsignarPatente").Value = True Then
                    PATENTES.Add(New BE.Patente With {.Idpatente = _ROW.Cells("patente_id").Value, .Nombre = _ROW.Cells("Nombre").Value})
                End If
                If _ROW.Cells("dgPatenteNegada").Value = True Then
                    PATENTES.Add(New BE.Patente With {.Idpatente = _ROW.Cells("patente_id").Value, .Nombre = _ROW.Cells("Nombre").Value, .NEGADO = _ROW.Cells("dgPatenteNegada").Value})
                End If
            Next
            USUARIO.Patentes = PATENTES



            Dim FAMILIAS As New List(Of BE.Familia)

            For Each _ROW As DataGridViewRow In dgFamilias.Rows
                If _ROW.Cells("dgAsignarFamilia").Value = True Then
                    FAMILIAS.Add(New BE.Familia With {.IdFamilia = _ROW.Cells("familia_id").Value, .Nombre = _ROW.Cells("Nombre_Familia").Value})
                End If
            Next
            USUARIO.Familias = FAMILIAS

            If BLLUSUARIO.modificacion(USUARIO) = True Then
                MessageBox.Show("SE MODIFICO EL USUARIO SELECCIONADO")
            Else
                MessageBox.Show("No se Guarda quedan patentes escenciales sin asignar")
            End If



        Catch ex As Exception
            MessageBox.Show("Error")
        End Try

    End Sub



    Private Sub dgFamilias_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgFamilias.CellContentClick
        Try

            If (e.RowIndex >= 0 And e.ColumnIndex = 2) Then
                Dim value As Boolean = CType(dgFamilias.CurrentCell.EditedFormattedValue, Boolean)
                If value = False Then
                    If BLL.Familia.GetInstance.ValidarEliminarFamiliaUsuario(New BE.Familia With {.IdFamilia = dgFamilias.Rows(e.RowIndex).Cells("familia_id").Value}, BLL.Usuario.GetInstance.listarPorId(unUsuario)) = False Then
                        MsgBox("No se puede quitar la familia al usuario porque contiene patentes esenciales y quedaria sin asignar")
                        SELECCIONUSUARIOCOMBO = COMBOUSER.SelectedItem.ToString
                        Dim BLLbitacora As New BLL.Bitacora
                        Dim bebitacora As New BE.Bitacora With {.Criticidad = "ALTA", .nick = UI.FormInicio.Usuariologueado.Nick, .Descripcion = "SE INTENTO SACARLE PATENTE ESENCIAL A UNA FAMILIA "}
                        BLLbitacora.alta(bebitacora)

                        dgFamilias.Rows.Clear()
                        For Each FamiliaBE In BLL.Familia.GetInstance().listarTodos
                            Dim n As Integer = dgFamilias.Rows.Add()
                            dgFamilias.Rows.Item(n).Cells("familia_id").Value = FamiliaBE.IdFamilia
                            dgFamilias.Rows.Item(n).Cells("dgAsignarFamilia").Value = False
                            dgFamilias.Rows.Item(n).Cells("Nombre_Familia").Value = FamiliaBE.Nombre
                        Next

                        dgPatentes.Rows.Clear()
                        For Each PatenteBE In BLL.PatenteBLL.GetInstance().listarTodos
                            Dim n As Integer = dgPatentes.Rows.Add()
                            dgPatentes.Rows.Item(n).Cells("patente_id").Value = PatenteBE.Idpatente
                            dgPatentes.Rows.Item(n).Cells("Nombre").Value = PatenteBE.Nombre
                            dgPatentes.Rows.Item(n).Cells("dgAsignarPatente").Value = False
                            dgPatentes.Rows.Item(n).Cells("dgPatenteNegada").Value = False
                        Next



                        unUsuario.Nick = SELECCIONUSUARIOCOMBO
                        Dim UsuarioBE = BLL.Usuario.GetInstance().listarPorId(unUsuario)


                        For Each FamiliaBE In UsuarioBE.Familias
                            For i = 0 To dgFamilias.Rows.Count - 1
                                If dgFamilias.Rows.Item(i).Cells("familia_id").Value = FamiliaBE.IdFamilia Then
                                    dgFamilias.Rows.Item(i).Cells("dgAsignarFamilia").Value = True
                                End If
                            Next
                        Next

                        For Each PatenteBE In UsuarioBE.Patentes
                            For i = 0 To dgPatentes.Rows.Count - 1
                                If dgPatentes.Rows.Item(i).Cells("patente_id").Value = PatenteBE.Idpatente Then
                                    If PatenteBE.NEGADO = False Then
                                        dgPatentes.Rows.Item(i).Cells("dgAsignarPatente").Value = True
                                    Else
                                        dgPatentes.Rows.Item(i).Cells("dgPatenteNegada").Value = True
                                    End If
                                End If
                            Next
                        Next

                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("error")
        End Try
    End Sub


    Private Sub dgPatentes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPatentes.CellContentClick
        Try

            If (e.RowIndex >= 0 And e.ColumnIndex = 2) Then
                Dim value2 As Boolean = CType(dgPatentes.CurrentCell.EditedFormattedValue, Boolean)
                If value2 = False Then
                    If (BLL.Usuario.GetInstance.ValidarEliminarUsuarioPatente(BLL.Usuario.GetInstance.listarPorId(unUsuario), New BE.Patente With {.Idpatente = dgPatentes.Rows(e.RowIndex).Cells("patente_id").Value}) = False) Then            '                   
                        MsgBox("No se puede quitar la Patente al usuario porque contiene patentes esenciales y quedaria sin asignar")
                        Dim BLLbitacora As New BLL.Bitacora
                        Dim bebitacora As New BE.Bitacora With {.Criticidad = "ALTA", .nick = UI.FormInicio.Usuariologueado.Nick, .Descripcion = "SE INTENTO SACARLE PATENTE ESENCIAL "}
                        BLLbitacora.alta(bebitacora)
                        SELECCIONUSUARIOCOMBO = COMBOUSER.SelectedItem.ToString


                        dgFamilias.Rows.Clear()
                        For Each FamiliaBE In BLL.Familia.GetInstance().listarTodos
                            Dim n As Integer = dgFamilias.Rows.Add()
                            dgFamilias.Rows.Item(n).Cells("familia_id").Value = FamiliaBE.IdFamilia
                            dgFamilias.Rows.Item(n).Cells("dgAsignarFamilia").Value = False
                            dgFamilias.Rows.Item(n).Cells("Nombre_Familia").Value = FamiliaBE.Nombre
                        Next

                        dgPatentes.Rows.Clear()
                        For Each PatenteBE In BLL.PatenteBLL.GetInstance().listarTodos
                            Dim n As Integer = dgPatentes.Rows.Add()
                            dgPatentes.Rows.Item(n).Cells("patente_id").Value = PatenteBE.Idpatente
                            dgPatentes.Rows.Item(n).Cells("Nombre").Value = PatenteBE.Nombre
                            dgPatentes.Rows.Item(n).Cells("dgAsignarPatente").Value = False
                            dgPatentes.Rows.Item(n).Cells("dgPatenteNegada").Value = False
                        Next



                        unUsuario.Nick = SELECCIONUSUARIOCOMBO
                        Dim UsuarioBE = BLL.Usuario.GetInstance().listarPorId(unUsuario)


                        For Each FamiliaBE In UsuarioBE.Familias
                            For i = 0 To dgFamilias.Rows.Count - 1
                                If dgFamilias.Rows.Item(i).Cells("familia_id").Value = FamiliaBE.IdFamilia Then
                                    dgFamilias.Rows.Item(i).Cells("dgAsignarFamilia").Value = True
                                End If
                            Next
                        Next

                        For Each PatenteBE In UsuarioBE.Patentes
                            For i = 0 To dgPatentes.Rows.Count - 1
                                If dgPatentes.Rows.Item(i).Cells("patente_id").Value = PatenteBE.Idpatente Then
                                    If PatenteBE.NEGADO = False Then
                                        dgPatentes.Rows.Item(i).Cells("dgAsignarPatente").Value = True
                                    Else
                                        dgPatentes.Rows.Item(i).Cells("dgPatenteNegada").Value = True
                                    End If
                                End If
                            Next
                        Next
                    End If
                End If
            End If
            If (e.RowIndex >= 0 And e.ColumnIndex = 3) Then
                Dim value3 As Boolean = CType(dgPatentes.CurrentCell.EditedFormattedValue, Boolean)
                If value3 = True Then
                    If (BLL.Usuario.GetInstance.ValidarEliminarUsuarioPatenteNegacion(BLL.Usuario.GetInstance.listarPorId(unUsuario), New BE.Patente With {.Idpatente = dgPatentes.Rows(e.RowIndex).Cells("patente_id").Value}) = False) Then            '                   
                        MsgBox("No se puede negar la patente al usuario porque la patente quedaria sin asignacion")

                        SELECCIONUSUARIOCOMBO = COMBOUSER.SelectedItem.ToString


                        dgFamilias.Rows.Clear()
                        For Each FamiliaBE In BLL.Familia.GetInstance().listarTodos
                            Dim n As Integer = dgFamilias.Rows.Add()
                            dgFamilias.Rows.Item(n).Cells("familia_id").Value = FamiliaBE.IdFamilia
                            dgFamilias.Rows.Item(n).Cells("dgAsignarFamilia").Value = False
                            dgFamilias.Rows.Item(n).Cells("Nombre_Familia").Value = FamiliaBE.Nombre
                        Next

                        dgPatentes.Rows.Clear()
                        For Each PatenteBE In BLL.PatenteBLL.GetInstance().listarTodos
                            Dim n As Integer = dgPatentes.Rows.Add()
                            dgPatentes.Rows.Item(n).Cells("patente_id").Value = PatenteBE.Idpatente
                            dgPatentes.Rows.Item(n).Cells("Nombre").Value = PatenteBE.Nombre
                            dgPatentes.Rows.Item(n).Cells("dgAsignarPatente").Value = False
                            dgPatentes.Rows.Item(n).Cells("dgPatenteNegada").Value = False
                        Next



                        unUsuario.Nick = SELECCIONUSUARIOCOMBO
                        Dim UsuarioBE = BLL.Usuario.GetInstance().listarPorId(unUsuario)


                        For Each FamiliaBE In UsuarioBE.Familias
                            For i = 0 To dgFamilias.Rows.Count - 1
                                If dgFamilias.Rows.Item(i).Cells("familia_id").Value = FamiliaBE.IdFamilia Then
                                    dgFamilias.Rows.Item(i).Cells("dgAsignarFamilia").Value = True
                                End If
                            Next
                        Next

                        For Each PatenteBE In UsuarioBE.Patentes
                            For i = 0 To dgPatentes.Rows.Count - 1
                                If dgPatentes.Rows.Item(i).Cells("patente_id").Value = PatenteBE.Idpatente Then
                                    If PatenteBE.NEGADO = False Then
                                        dgPatentes.Rows.Item(i).Cells("dgAsignarPatente").Value = True
                                    Else
                                        dgPatentes.Rows.Item(i).Cells("dgPatenteNegada").Value = True
                                    End If
                                End If
                            Next
                        Next


                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub





    Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip1.Popup
        ToolTip1.SetToolTip(Me.btnconfirmarmodificaciones, "Confirmar los permisos de patente")
    End Sub
End Class