Imports System.IO

Public Class FormRestore


    Dim MenuUI As UI.FormInicio
    Dim UsuarioBLL As New BLL.Usuario
    Dim BackupBLL As New BLL.Backup
    Dim BitacoraBE As New BE.Bitacora


    Private Sub frmRestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            MenuUI = Me.MdiParent



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If Validar() Then
                Dim BackupBE As New BE.Backup
                BackupBE.Archivo = lstArchivo.SelectedItem.ToString
                BackupBLL.ImportarRar(BackupBE)
                MsgBox("El restore fue hecho con exito")
                RegistrarBitacora("Se hizo un restore del sistema", "Alta")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub txtRuta_TextChanged(sender As Object, e As EventArgs) Handles txtRuta.TextChanged
        Try
            If Directory.Exists(txtRuta.Text) Then
                Dim LfilesInDir As New List(Of String)
                For Each File In Directory.EnumerateFiles(txtRuta.Text)
                    Dim sinExt = File.Substring(0, File.Length - 4)
                    If sinExt.EndsWith(".dbk") Then LfilesInDir.Add(sinExt)
                Next
                LfilesInDir.Sort()
                lstArchivo.DataSource = Nothing
                lstArchivo.Items.Clear()
                lstArchivo.DataSource = LfilesInDir.Distinct().ToArray()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCarpeta_Click(sender As Object, e As EventArgs) Handles btnCarpeta.Click
        Try
            If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
                txtRuta.Text = FolderBrowserDialog1.SelectedPath
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Function Validar() As Boolean
        Dim valido = True
        If txtRuta.Text = "" Then
            valido = False
            MsgBox("Campo requerido")
        End If
        Return valido
    End Function

    Public Sub RegistrarBitacora(evento As String, nivel As String)

    End Sub




End Class