Imports System.IO
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Conexion

    Shared servidor As String
    Shared instancia As String
    Public Shared conn As New SqlClient.SqlConnection
    Public comm As New SqlClient.SqlCommand


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

    Public Shared Function getConexionMaster() As String

        obtenercadenaconexion()
        Return "Data Source=" & servidor & "\" & instancia & ";Initial Catalog=farmacia;Integrated Security=True"
    End Function


    Public Shared Function EjecutarSQLReader(ByVal pCommandText As String) As DataSet
        Dim mDs As New DataSet
        Try
            obtenercadenaconexion()
            conn.ConnectionString = "Data Source=" & servidor & "\" & instancia & ";Initial Catalog=farmacia;Integrated Security=True"

            Dim mDa As New SqlDataAdapter(pCommandText, conn)
            conn.Open()
            mDa.Fill(mDs)
            Return mDs
        Catch ex As SqlException
            Dim mStr As String = ""
            For Each mErr As SqlError In ex.Errors
                mStr &= mErr.Message & ControlChars.CrLf
            Next

        Catch ex As Exception
            Throw ex
        
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Function

    Public Shared Function EjecutarSQLReader(ByVal pCommandText As String, ByVal pParameters As Dictionary(Of String, Object)) As DataSet
        Dim mDs As New DataSet
        Try
            obtenercadenaconexion()

            conn.ConnectionString = "Data Source=" & servidor & "\" & instancia & ";Initial Catalog=farmacia;Integrated Security=True"

            Dim mDa As New SqlDataAdapter(pCommandText, conn)

            For Each key As String In pParameters.Keys
                mDa.SelectCommand.Parameters.AddWithValue(key, pParameters(key))
            Next

            conn.Open()
            mDa.Fill(mDs)
            Return mDs
        Catch ex As SqlException
            Dim mStr As String = ""
            For Each mErr As SqlError In ex.Errors
                mStr &= mErr.Message & ControlChars.CrLf
            Next



        Catch ex As Exception
            MsgBox("Problemas con la base de datos")
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Function


    Public Shared Function ExecuteNonQuery(ByVal pCommandText As String) As Integer
        Try
            obtenercadenaconexion()

            conn.ConnectionString = "Data Source=" & servidor & "\" & instancia & ";Initial Catalog=farmacia;Integrated Security=True"
            Dim mCom As New SqlCommand(pCommandText, conn)
            conn.Open()
            Return mCom.ExecuteNonQuery
        Catch ex As Exception
            Throw ex
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Function


    Public Shared Function ExecuteScalar(ByVal pCommandText As String) As Object
        Try
            obtenercadenaconexion()

            conn.ConnectionString = "Data Source=" & servidor & "\" & instancia & ";Initial Catalog=farmacia;Integrated Security=True"

            Dim mCom As New SqlCommand(pCommandText, conn)
            conn.Open()
            Return mCom.ExecuteScalar
        Catch ex As Exception
            MsgBox("Problemas con la base de datos")
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Function


    Public Shared Function ExecuteScalar(ByVal pCommandText As String, ByVal pParametersDictionary As Dictionary(Of String, Object)) As Object
        Try
            obtenercadenaconexion()

            conn.ConnectionString = "Data Source=" & servidor & "\" & instancia & ";Initial Catalog=farmacia;Integrated Security=True"

            Dim mCom As New SqlCommand(pCommandText, conn)

            For Each key As String In pParametersDictionary.Keys
                mCom.Parameters.AddWithValue(key, pParametersDictionary(key))
            Next

            conn.Open()
            Return mCom.ExecuteScalar
        Catch ex As Exception
            MsgBox("Problemas con la base de datos")
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Function


    Public Shared Function ExecuteNonQuery(ByVal pCommandText As String, ByVal pParametersDictionary As Dictionary(Of String, Object)) As Integer
        Try
            obtenercadenaconexion()

            conn.ConnectionString = "Data Source=" & servidor & "\" & instancia & ";Initial Catalog=farmacia;Integrated Security=True"

            Dim mCom As New SqlCommand(pCommandText, conn)

            For Each key As String In pParametersDictionary.Keys
                mCom.Parameters.AddWithValue(key, pParametersDictionary(key))
            Next

            conn.Open()
            Return mCom.ExecuteNonQuery
        Catch ex As Exception
            MsgBox("Problemas con la base de datos3")
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Function

    Public Shared Function ExecuteStoredProcedureNonQuery(ByVal pStoredProcedureName As String, ByVal pParameters As Dictionary(Of String, Object)) As Object
        Try
            obtenercadenaconexion()

            conn.ConnectionString = "Data Source=" & servidor & "\" & instancia & ";Initial Catalog=farmacia;Integrated Security=True"

            Dim mCommand As New SqlCommand()
            mCommand.Connection = conn
            mCommand.CommandType = CommandType.StoredProcedure
            mCommand.CommandText = pStoredProcedureName

            For Each key As String In pParameters.Keys
                mCommand.Parameters.AddWithValue(key, pParameters(key))
            Next

            conn.Open()
            Return mCommand.ExecuteScalar()
        Catch ex As Exception
            MsgBox("Problemas con la base de datos")
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Function

    Public Shared Function EjecutarStoredProcedureSQLReader(ByVal pStoredProcedureName As String, ByVal pParameters As Dictionary(Of String, Object)) As DataSet
        Dim mDs As New DataSet
        Try
            obtenercadenaconexion()

            conn.ConnectionString = "Data Source=" & servidor & "\" & instancia & ";Initial Catalog=farmacia;Integrated Security=True"

            Dim mCommand As New SqlCommand()
            mCommand.Connection = conn
            mCommand.CommandType = CommandType.StoredProcedure
            mCommand.CommandText = pStoredProcedureName

            For Each key As String In pParameters.Keys
                mCommand.Parameters.AddWithValue(key, pParameters(key))
            Next

            Dim mDa As New SqlDataAdapter()
            mDa.SelectCommand = mCommand
            conn.Open()
            mDa.Fill(mDs)
            Return mDs
        Catch ex As SqlException
            Dim mStr As String = ""
            For Each mErr As SqlError In ex.Errors
                mStr &= mErr.Message & ControlChars.CrLf
            Next

           

        Catch ex As Exception
            MsgBox("Problemas con la base de datos")
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Function

    Public Shared Function ObtenerUltimoId(ByVal pTabla As String) As Integer
        Try
            obtenercadenaconexion()

            conn.ConnectionString = "Data Source=" & servidor & "\" & instancia & ";Initial Catalog=farmacia;Integrated Security=True"

            Dim mCom As New SqlCommand("SELECT ISNULL(MAX(id" & pTabla & "),0) FROM " & pTabla & " (NoLock)", conn)
            conn.Open()
            Return DirectCast(mCom.ExecuteScalar, Integer)
        Catch ex As Exception
            MsgBox("Problemas con la base de datos")
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Function


    Public Shared Function ObtenerMaximoValor(ByVal pTabla As String, ByVal pCampo As String) As Integer
        Try
            obtenercadenaconexion()

            conn.ConnectionString = "Data Source=" & servidor & "\" & instancia & ";Initial Catalog=farmacia;Integrated Security=True"

            Dim mCom As New SqlCommand("SELECT ISNULL(MAX(" & pCampo & "),0) FROM " & pTabla & " (NoLock)", conn)
            conn.Open()
            Return DirectCast(mCom.ExecuteScalar, Integer)
        Catch ex As Exception
            MsgBox("Problemas con la base de datos")
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Function

    ''' 
    ''' <param name="pCarpeta"></param>
    Public Sub GenerarBackup(ByVal pCarpeta As String)

    End Sub

    Public Sub RestaurarBackup(ByVal pSqlBackup As String)
        Dim sqlAlter As String = String.Empty
        Dim mCom As New SqlCommand()
        Try

            obtenercadenaconexion()

            conn.ConnectionString = "Data Source=" & servidor & "\" & instancia & ";Initial Catalog=farmacia;Integrated Security=True"

            mCom.Connection = conn
            conn.Open()
            sqlAlter = String.Format("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE", Me.ObtenerBaseDatosNombre())
            mCom.CommandText = sqlAlter
            mCom.ExecuteNonQuery()
            mCom.CommandText = pSqlBackup
            mCom.ExecuteNonQuery()
            sqlAlter = String.Format("ALTER DATABASE {0} SET MULTI_USER WITH ROLLBACK IMMEDIATE", Me.ObtenerBaseDatosNombre())
            mCom.CommandText = sqlAlter
            mCom.ExecuteNonQuery()
        Catch ex As Exception
            sqlAlter = String.Format("ALTER DATABASE {0} SET MULTI_USER WITH ROLLBACK IMMEDIATE", Me.ObtenerBaseDatosNombre())
            mCom.CommandText = sqlAlter
            mCom.ExecuteNonQuery()
            MsgBox("Problemas con la base de datos")
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub

    Public Function ObtenerBaseDatosNombre() As String
        obtenercadenaconexion()

        conn.ConnectionString = "Data Source=" & servidor & "\" & instancia & ";Initial Catalog=farmacia;Integrated Security=True"
        Dim conBuilder As SqlConnectionStringBuilder = New SqlConnectionStringBuilder(conn.ConnectionString)
        Return conBuilder.InitialCatalog
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
        CerrarConexion()
        dt.Dispose()
        comm.Dispose()

        Return dt
     
    End Function

    Public Overloads Function leer(unaCadena As String) As DataTable
        Dim dr As SqlClient.SqlDataReader
        Dim dt As New DataTable
        comm.Connection = Abrirconexion()
        comm.CommandType = CommandType.Text
        comm.CommandText = unaCadena

        dr = comm.ExecuteReader()
        dt.Load(dr)
        CerrarConexion()
        dt.Dispose()
        comm.Dispose()
        Return dt
       

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


    Public Shared Sub obtenercadenaconexion()

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
