Public Class FormUsuarioSeguridad

    Private SELECCIONUSUARIOCOMBO As String = ""
    Private seleccionidusuario As Integer = 0
    Dim unUsuario As New BE.Usuario
     Private _id As String

 
    Private Sub FormUsuarioSeguridad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.StartPosition = FormStartPosition.CenterScreen


            '  CAMBIARIDIOMAS()


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
                MessageBox.Show("NO SE PUEDE MODIFICAR EL USUARIO YA QUE DETERMINADAS PATENTES / FAMILIAS NO SE PUEDEN ELIMINAR SI NO EXISTE OTRO USUARIO QUE LAS POSEA")
            End If



        Catch ex As Exception
            MessageBox.Show("FALLO AL INTENTAR MODIFICAR EL USUARIO")
        End Try

    End Sub
End Class