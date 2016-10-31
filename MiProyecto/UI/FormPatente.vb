Public Class FormPatente

    Private Sub FormPatente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim patente As New BLL.PatenteBLL
        Dim listpatente As New List(Of patente_be)

        listpatente = patente.traerpatente

        For Each row In patente.traerpatente
            DataGridView1.Rows.Add(row.idpatente,
                                   row.descripcion
                                   )
        Next
    End Sub
End Class