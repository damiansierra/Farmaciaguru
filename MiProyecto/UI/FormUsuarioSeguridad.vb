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
       
    End Sub
End Class