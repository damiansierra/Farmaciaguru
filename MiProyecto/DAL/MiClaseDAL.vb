Public Class MiClaseDAL
    Implements BE.ICrud(Of BE.MiClaseBE)
    Dim SqlConn As New SqlClient.SqlConnection With {.ConnectionString = "MI STRING CONECTION"}

    Private Shared _instancia As DAL.MiClaseDAL

    Public Shared Function GetInstance() As DAL.MiClaseDAL
        If _instancia Is Nothing Then

            _instancia = New DAL.MiClaseDAL

        End If
        Return _instancia
    End Function

    Public Function alta(obj As BE.MiClaseBE) As Boolean Implements BE.ICrud(Of BE.MiClaseBE).alta
        Dim comm As New SqlClient.SqlCommand
        Dim sqlDA As New SqlClient.SqlDataAdapter
        Dim returnValue As Boolean = False

        Dim parametro As New SqlClient.SqlParameter

        comm.Connection = SqlConn
        comm.CommandType = CommandType.Text
        comm.CommandText = "insert into MiTabla (id) values (" + obj.Id + ")"

        Try
            sqlDA.InsertCommand = comm
            sqlDA.InsertCommand.Connection.Open()
            If sqlDA.InsertCommand.ExecuteNonQuery > 0 Then
                returnValue = True
            End If

        Catch ex As Exception
            Throw ex
        Finally
            sqlDA.InsertCommand.Connection.Close()
        End Try
        Return returnValue
    End Function

    Public Function baja(obj As BE.MiClaseBE) As Boolean Implements BE.ICrud(Of BE.MiClaseBE).baja

    End Function

    Public Function listarPorId(obj As BE.MiClaseBE) As BE.MiClaseBE Implements BE.ICrud(Of BE.MiClaseBE).listarPorId

    End Function

    Public Function listarTodos() As List(Of BE.MiClaseBE) Implements BE.ICrud(Of BE.MiClaseBE).listarTodos

    End Function

    Public Function modificacion(obj As BE.MiClaseBE) As Boolean Implements BE.ICrud(Of BE.MiClaseBE).modificacion

    End Function
End Class
