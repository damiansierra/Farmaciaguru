Imports System.IO
Public Class FormConexion

    Dim SeguridadBLL As New BLL.Ultimo

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If Validar() Then
                File.WriteAllText("StringConexion.txt", SeguridadBLL.pasarstring(txtServidor.Text))
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    Private Function Validar() As Boolean
        Dim valido = True
        If (SeguridadBLL.ValidarServidor(txtServidor.Text)) = False Then
            valido = False
            MsgBox("Servidor SQL incorrecto")
        End If
        Return valido
    End Function

 
    Private Sub FormConexion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class