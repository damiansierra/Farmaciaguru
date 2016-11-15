Public Class FormFamilias

    Dim FAMILIASELECCIONADA As String = ""
    Dim LISTAfamilias As New List(Of BE.Familia)
    Dim FAMILIAIDSELECCIONADA As Integer = 0

    Private Sub FormFamilias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf KeyUpHandler
        '   CAMBIARIDIOMAS()

        Try
            CARGARCOMBO()
        Catch ex As Exception
            MessageBox.Show("ERROR CARGANDO FORMULARIO")
        End Try



    End Sub




    Private Sub Combofamilia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combofamilia.SelectedIndexChanged
        Try

            txtfamilia.Visible = True
            Combofamilia.Visible = True
            btnconfirmarmodificaciones.Visible = True
            DataGridViewfamilia.Enabled = True
            txtfamilia.Visible = True
            FAMILIASELECCIONADA = Combofamilia.SelectedItem.ToString
            DataGridViewfamilia.Rows.Clear()

            Dim FAMILIA As New BE.Familia
            Dim BLLFAMILIA As New BLL.Familia

            FAMILIA.Nombre = FAMILIASELECCIONADA
            FAMILIA = BLLFAMILIA.listarPorId(FAMILIA)
            FAMILIAIDSELECCIONADA = FAMILIA.IdFamilia

            Dim I As Integer = 0
            For Each Pat In FAMILIA.Patente
                DataGridViewfamilia.Rows.Add()
                DataGridViewfamilia.Rows(I).Cells("IDPATENTE").Value = Pat.Idpatente
                DataGridViewfamilia.Rows(I).Cells("PATENTE").Value = Pat.Nombre
                DataGridViewfamilia.Rows(I).Cells("AGREGADA").Value = True
                I = I + 1
            Next

            Dim LISTADEPATENTES As New List(Of BE.Patente)
            Dim BLLPATENTE As New BLL.PatenteBLL

            LISTADEPATENTES = BLLPATENTE.listarTodos

            For Each PAT In LISTADEPATENTES
                Dim BAND = 0
                For Each _ROW As DataGridViewRow In DataGridViewfamilia.Rows
                    If _ROW.Cells("IDPATENTE").Value = PAT.Idpatente Then
                        BAND = 1
                    End If
                Next

                If BAND = 0 Then
                    Dim CANT As Integer = DataGridViewfamilia.Rows.Count
                    DataGridViewfamilia.Rows.Add()
                    DataGridViewfamilia.Rows(CANT).Cells("ID_PATENTE").Value = PAT.Patente
                    DataGridViewfamilia.Rows(CANT).Cells("PATENTE").Value = PAT.Descripcion
                    DataGridViewfamilia.Rows(CANT).Cells("AGREGADA").Value = False
                End If

            Next


        Catch ex As Exception
            MessageBox.Show("FALLO AL CARGAR LOS ATRIBUTOS DE LA FAMILIA")
        End Try




    End Sub

    ' Private Sub txtfamilia_TextChanged(sender As Object, e As EventArgs) Handles txtfamilia.TextChanged
    '    Try
    '       If txtfamilia.Text <> "" Then
    '          btneliminarfamilia.Visible = False
    '         Combofamilia.Visible = False
    '        btnconfirmarmodificaciones.Visible = False
    '       DataGridViewfamilia.Enabled = False
    '      txtfamilia.Visible = False
    '     lblnuevafam.Visible = True
    'End If
    ' Catch ex As Exception
    '    MessageBox.Show("ERROR AL MODIFICAR EL FORMULARIO")
    'End Try



    'End Sub

    ' Private Sub btneliminarfamilia_Click(sender As Object, e As EventArgs) Handles btneliminarfamilia.Click
    '    Try
    '       If FAMILIASELECCIONADA <> "" Then
    'Dim FAMILIA As New BE.Familia
    '           For Each FAM In LISTAfamilias
    '              If FAM.DESCRIPCION = FAMILIASELECCIONADA Then
    '                 FAMILIA.DESCRIPCION = FAMILIASELECCIONADA
    '                FAMILIA.ID_FAMILIA = FAM.ID_FAMILIA
    '               FAMILIA.DVH = FAM.DVH
    '          End If
    '     Next


    'Dim BLLFAMILIA As New BLL.Familia



    '           If BLLFAMILIA.baja(FAMILIA, UI.Principal.Usuariologueado) = True Then
    '              MessageBox.Show("FAMILIA ELIMINADA")
    '         Else
    '            MessageBox.Show("NO ES POSIBLE ELIMINAR LA FAMILIA")
    '       End If
    '
    '       Else
    '          MessageBox.Show("PRIMERO DEBE SELECCIONAR UNA FAMILIA")
    '     End If

    '        CARGARCOMBO()

    '   Catch ex As Exception
    '      MessageBox.Show("FALLO AL ELIMINAR LA FAMILIA")
    ' End Try


    'End Sub

    Sub CARGARCOMBO()
        Try
            LISTAfamilias.Clear()

            txtfamilia.Visible = True
            Combofamilia.Visible = True

            btnconfirmarmodificaciones.Visible = True
            DataGridViewfamilia.Enabled = True
            txtfamilia.Visible = True
            txtfamilia.Text = ""

            DataGridViewfamilia.Rows.Clear()



            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow

            Combofamilia.DropDownStyle = ComboBoxStyle.DropDownList
            Combofamilia.Items.Clear()

            Dim BLLFAMILIA As New BLL.Familia
            LISTAfamilias = BLLFAMILIA.listarTodos
            For Each FAMS In LISTAfamilias
                Combofamilia.Items.Add(FAMS.Nombre)
            Next

        Catch ex As Exception
            MessageBox.Show("ERROR CARGANDO COMBO FAMILIA")
        End Try
    End Sub


    Private Sub btnconfirmarmodificaciones_Click(sender As Object, e As EventArgs) Handles btnconfirmarmodificaciones.Click

    End Sub



    Private Sub KeyUpHandler(ByVal o As Object, ByVal e As KeyEventArgs)


        'Me.KeyPreview = True

        'AddHandler Me.KeyUp, AddressOf KeyUpHandler

        e.SuppressKeyPress = True
        If e.KeyCode = Keys.F1 Then
            '    UI.Ayuda.formulario = 6
            '   UI.Ayuda.Show()
        End If

    End Sub




    '    Public Sub CAMBIARIDIOMAS()
    '       Try

    '        If UI.Principal.Usuariologueado.IDIOMA.ID_IDIOMA <> 1 Then
    ' Dim BLLMENSAJEIDIOMA As New BLL.MENSAJEIDIOMA(UI.Principal.Usuariologueado.IDIOMA)
    '            BLLMENSAJEIDIOMA.TraducirForm(Me)

    '       End If

    '    Catch ex As Exception
    '       MessageBox.Show("IMPOSIBLE CAMBIAR EL IDIOMA")
    '  End Try
    'End Sub
End Class