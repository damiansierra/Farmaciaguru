Public Class Form1




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim miClaseBE As New BE.MiClaseBE


        If (TextBox1.Text = "") Then
            'mensaje de error
        Else
            Dim seGuardoCorrectamente = False
            seGuardoCorrectamente = BLL.MiClaseBLL.GetInstance.alta(miClaseBE)
            If (seGuardoCorrectamente) Then
                'un mensaje OK
            Else
                'un mensaje de ERRRO
            End If
        End If


    End Sub
End Class
