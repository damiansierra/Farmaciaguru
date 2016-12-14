Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class FormReporteBit

    Dim l_ventas As List(Of BE.Bitacora)
    Sub New(ByRef lista_ventas As List(Of BE.Bitacora))
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        l_ventas = lista_ventas
    End Sub

    Private Sub FormReporteBit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", l_ventas))
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class