Imports System.IO
Public Class Conexion

    Private servidor As String
    Private instancia As String
    Private conn As New SqlClient.SqlConnection
    Private comm As New SqlClient.SqlCommand


    Private Sub New()
    End Sub

    Shared _instancia As DAL.Conexion
    Public Shared Function GetInstance() As DAL.Conexion
        If _instancia Is Nothing Then
            _instancia = New DAL.Conexion
        Else
            _instancia = New DAL.Conexion
        End If
        Return _instancia
    End Function

    Public Function AbrirConexion() As SqlClient.SqlConnection
        Try
            obtenercadenaconexion()
            conn = New SqlClient.SqlConnection
            conn.ConnectionString = "Data Source=" & servidor & "\" & instancia & ";Initial Catalog=farmacia;Integrated Security=True"

            conn.Open()
        Catch ex As Exception
            Throw ex
        End Try
        Return conn
    End Function

    Private Function CerrarConexion() As SqlClient.SqlConnection
        Try
            conn.Close()
            conn.Dispose()
        Catch ex As Exception

        End Try
        Return conn
    End Function


    Public Overloads Function Escribir(unStoreProcedure As String, unaListaParametros As List(Of SqlClient.SqlParameter)) As Integer
        Try
            Dim a As Integer = 0
            comm.Connection = Abrirconexion()
            comm.CommandType = CommandType.StoredProcedure
            comm.CommandText = unStoreProcedure

            For Each unParametro As SqlClient.SqlParameter In unaListaParametros
                comm.Parameters.Add(unParametro)
            Next

            a = comm.ExecuteNonQuery()
            CerrarConexion()
            Return a
        Catch ex As Exception
            CerrarConexion()
            Return 0
        End Try
    End Function

    Public Overloads Function Escribir(cadena As String) As Integer
        Try
            Dim a As Integer
            comm.Connection = Abrirconexion()
            comm.CommandType = CommandType.Text
            comm.CommandText = cadena
            a = comm.ExecuteNonQuery()
            CerrarConexion()
            Return a
        Catch ex As Exception
            CerrarConexion()
            Return 0
        End Try
    End Function

    Public Overloads Function leer(unStoreProcedure As String, unaListaParametros As List(Of SqlClient.SqlParameter)) As DataTable
        Dim dr As SqlClient.SqlDataReader
        Dim dt As New DataTable
        comm.Connection = Abrirconexion()
        comm.CommandType = CommandType.StoredProcedure
        comm.CommandText = unStoreProcedure

        For Each unParametro As SqlClient.SqlParameter In unaListaParametros
            comm.Parameters.Add(unParametro)
        Next

        dr = comm.ExecuteReader()
        dt.Load(dr)

        Return dt
        CerrarConexion()
        dt.Dispose()
        comm.Dispose()

    End Function

    Public Overloads Function leer(unaCadena As String) As DataTable
        Dim dr As SqlClient.SqlDataReader
        Dim dt As New DataTable
        comm.Connection = Abrirconexion()
        comm.CommandType = CommandType.Text
        comm.CommandText = unaCadena

        dr = comm.ExecuteReader()
        dt.Load(dr)

        Return dt
        CerrarConexion()
        dt.Dispose()
        comm.Dispose()

    End Function

    Public Overloads Function leerINT(unaCadena As String) As Integer
        Dim dr As SqlClient.SqlDataReader
        Dim dt As New DataTable
        comm.Connection = Abrirconexion()
        comm.CommandType = CommandType.Text
        comm.CommandText = unaCadena

        dr = comm.ExecuteReader()
        dt.Load(dr)
        If IsDBNull(dt.Rows(0).Item(0)) = True Then
            Return 0
        Else
            Return dt.Rows(0).Item(0)
        End If

        CerrarConexion()
        dt.Dispose()
        comm.Dispose()

    End Function


    Public Sub obtenercadenaconexion()

        Dim rutaFicheroINI As String
        rutaFicheroINI = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "configuracion.txt")

        Dim leer As StreamReader
        'Leer el archivo por la ruta
        leer = New StreamReader(rutaFicheroINI)

        If File.Exists(rutaFicheroINI) = True Then
            'Variable de control para leer la primera linea
            Dim c As Integer = 0
            'Leer linea a linea hasta el final
            While c <= 1 And Not leer.EndOfStream
                If c = 0 Then
                    servidor = leer.ReadLine
                End If

                If c = 1 Then
                    instancia = leer.ReadLine
                End If

                c += 1
            End While
        End If

    End Sub

End Class
