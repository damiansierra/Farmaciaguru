Imports System.IO

Public Class FormBackup

    Dim MenuUI As UI.FormInicio
    Dim UsuarioBLL As New BLL.Usuario
    Dim BackupBLL As New BLL.Backup
    Dim BitacoraBE As New BE.Bitacora


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub


    Protected Overrides Sub OnLoad(e As EventArgs)
        Try
            MenuUI = Me.MdiParent
            Dim PatenteBE As New BE.Patente
            PatenteBE.Nombre = "Backup"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Sub DescargarRar()
        If txtruta.Text.Trim <> "" Then
            Dim BackupBE As New BE.Backup
            BackupBE.Ubicacion = txtruta.Text
            Dim valor = 0
            BackupBE.Cantidad = nudValor.Value.ToString
            valor = nudValor.Value.ToString
            If (BackupBLL.GenerarRar(BackupBE)) Then
                RegistrarBitacora("Se hizo un backup del sistema", "Media")
                MsgBox("El backup fue hecho con exito")
            Else
                MsgBox("El backup no puede realizarse en el Path, por favor seleccione otro")
            End If
        End If
    End Sub

    Private Function Validar() As Boolean
        Dim valido = True
        If Directory.Exists(txtruta.Text) = False Then
            valido = False
            MsgBox("La Ruta no existe!")
        End If
        If txtruta.Text = "" Then
            valido = False
            MsgBox("Ingrese la Ruta")
        End If
        Return valido
    End Function

    Public Sub RegistrarBitacora(evento As String, nivel As String)

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs)
        Try
            If Validar() Then
                DescargarRar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCarpeta_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FormBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If UI.Login.idioma = "2" Then

            Me.btnAceptar.text = "Acept"
            Me.lblCantidad.Text = "Parts"
        End If
    End Sub

    Private Sub btnCarpeta_Click_1(sender As Object, e As EventArgs) Handles btnCarpeta.Click
        Try
            If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
                txtruta.Text = FolderBrowserDialog1.SelectedPath
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAceptar_Click_1(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If Validar() Then
                DescargarRar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class