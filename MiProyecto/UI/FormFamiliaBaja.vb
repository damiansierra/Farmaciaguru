Public Class FormFamiliaBaja
    Dim FAMILIASELECCIONADA As String = ""
    Dim LISTAfamilias As New List(Of BE.Familia)
    Dim FAMILIAIDSELECCIONADA As Integer = 0
    Public Usuariologueado As New BE.Usuario

    Private Sub FormFamiliaBaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.StartPosition = FormStartPosition.CenterScreen


            '  CAMBIARIDIOMAS()


            COMBOFAM.Items.Clear()
            COMBOFAM.Items.Clear()
            COMBOFAM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            CARGARCOMBOFAM()





        Catch ex As Exception

        End Try

    End Sub


    Sub CARGARCOMBOFAM()
        Try


            Dim listafam As New List(Of BE.Familia)
            Dim bllfamilia As New BLL.Familia

            listafam = bllfamilia.listarTodos


            For Each familia As BE.Familia In listafam
                COMBOFAM.Items.Add(familia.Nombre)
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If COMBOFAM.Text <> "" Then

                Dim nombre As New BE.Familia With {.Nombre = COMBOFAM.Text}

                Dim BLLFAMILIA As New BLL.Familia
                If BLL.Familia.GetInstance.ValidarEliminarFamilia(BLL.Familia.GetInstance.listarPorId(nombre)) Then
                    If BLLFAMILIA.baja(nombre) = True Then
                        MessageBox.Show("FAMILIA ELIMINADA")
                        COMBOFAM.Items.Clear()
                        CARGARCOMBOFAM()

                        Dim BLLbitacora As New BLL.Bitacora
                        Dim bebitacora As New BE.Bitacora With {.Criticidad = "ALTA", .nick = UI.FormInicio.Usuariologueado.Nick, .Descripcion = "SE ELIMINO FAMILIA " & COMBOFAM.Text}
                        BLLbitacora.alta(bebitacora)
                    End If
                Else
                    MessageBox.Show("NO ES POSIBLE ELIMINAR LA FAMILIA")

                End If

            Else
                MessageBox.Show("PRIMERO DEBE SELECCIONAR UNA FAMILIA")
            End If
            COMBOFAM.Items.Clear()
            CARGARCOMBOFAM()

        Catch ex As Exception
            MessageBox.Show("FALLO AL ELIMINAR LA FAMILIA")
        End Try

    End Sub
End Class