﻿Public Class FormPatente

    Private Sub FormPatente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim patente As New BLL.PatenteBLL
        Dim listpatente As New List(Of BE.Patente)

        listpatente = patente.listarTodos



        For Each row In patente.listarTodos
            DataGridView1.Rows.Add(row.Idpatente,
                                   row.Descripcion
                                   )
        Next
    End Sub
End Class