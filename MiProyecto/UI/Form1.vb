Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class Form1




    Dim l_ventas As List(Of BE.Ticket)
    Sub New(ByRef lista_ventas As List(Of BE.Ticket))
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        l_ventas = lista_ventas
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet5", l_ventas))
        Me.ReportViewer1.RefreshReport()
    End Sub

 
    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub
End Class