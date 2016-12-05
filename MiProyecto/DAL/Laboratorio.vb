Public Class Laboratorio
    Implements BE.ICrud(Of BE.Laboratorio)


    Dim SqlConn As New SqlClient.SqlConnection With {.ConnectionString = Conexion.getConexionMaster}


    Private Shared _instancia As DAL.Laboratorio

    Public Shared Function GetInstance() As DAL.Laboratorio

        If _instancia Is Nothing Then

            _instancia = New DAL.Laboratorio

        End If
        Return _instancia
    End Function



    Public Function alta(obj As BE.Laboratorio) As Boolean Implements BE.ICrud(Of BE.Laboratorio).alta
        Try


            If (obj.IdLaboratorio = 0) Then

                Dim INSERT As String = "INSERT INTO LABORATORIO VALUES " & "('" & obj.Nombre & "','" & obj.Dirección & "','" & obj.telefono & "')"
                DAL.Conexion.GetInstance.Escribir(INSERT)

            End If


        Catch ex As Exception
            MsgBox("Problemas con la base de datos")
        End Try

        Return alta

    End Function

    Public Function baja(obj As BE.Laboratorio) As Boolean Implements BE.ICrud(Of BE.Laboratorio).baja

    End Function

    Public Function listarPorId(obj As BE.Laboratorio) As BE.Laboratorio Implements BE.ICrud(Of BE.Laboratorio).listarPorId

    End Function

    Public Function listarTodos() As List(Of BE.Laboratorio) Implements BE.ICrud(Of BE.Laboratorio).listarTodos
        Try
            Dim dt As New DataTable

            Dim SELECTLAB As String = "SELECT * FROM LABORATORIO"
            dt = DAL.Conexion.GetInstance.leer(SELECTLAB)

            Dim LISTALABORATORIOS As New List(Of BE.Laboratorio)
            For Each _ROW In dt.Rows
                LISTALABORATORIOS.Add(New BE.Laboratorio With {.IdLaboratorio = _ROW("IDLABORATORIO"), .Nombre = _ROW("Nombre"), .Dirección = _ROW("DIRECCION"), .telefono = _ROW("telefono")})
            Next

            Return LISTALABORATORIOS
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function modificacion(obj As BE.Laboratorio) As Boolean Implements BE.ICrud(Of BE.Laboratorio).modificacion

    End Function
End Class
