Public Class Familia
    Implements BE.ICrud(Of BE.Familia)

    Private Shared _instancia As DAL.Familia

    Public Shared Function GetInstance() As DAL.Familia

        If _instancia Is Nothing Then

            _instancia = New DAL.Familia

        End If

        Return _instancia
    End Function


    Public Function alta(obj As BE.Familia) As Boolean Implements BE.ICrud(Of BE.Familia).alta
        Dim nombreEncriptado As String = Seguridad.EncriptarReversible(obj.Nombre)

        Dim sqlString As String
        Dim parameters As New Dictionary(Of String, Object)
        Dim idFamilia As Integer
        If (obj.IdFamilia = 0) Then
            idFamilia = Conexion.ObtenerUltimoId("Familia") + 1
            sqlString = "INSERT INTO Familia(idFamilia, Nombre, Eliminada) " & _
                            "values(@idFamilia, @Nombre, @Eliminada)"
        Else
            idFamilia = obj.IdFamilia
            sqlString = "UPDATE Familia SET Nombre = @Nombre, Eliminada = @Eliminada WHERE idFamilia = @idFamilia"

        End If

        parameters.Add("@idFamilia", idFamilia)
        parameters.Add("@Nombre", nombreEncriptado)
        parameters.Add("@Eliminada", obj.Eliminada)

        Try

            Dim resultQuery As Integer

            resultQuery = Conexion.ExecuteNonQuery(sqlString, parameters)
            obj.IdFamilia = idFamilia

            If (resultQuery <= 0) Then
                MsgBox("Problemas con la base de datos")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function baja(obj As BE.Familia) As Boolean Implements BE.ICrud(Of BE.Familia).baja

    End Function

    Public Function listarPorId(obj As BE.Familia) As BE.Familia Implements BE.ICrud(Of BE.Familia).listarPorId

    End Function

    Public Function listarTodos() As List(Of BE.Familia) Implements BE.ICrud(Of BE.Familia).listarTodos

    End Function

    Public Function modificacion(obj As BE.Familia) As Boolean Implements BE.ICrud(Of BE.Familia).modificacion

    End Function

   
End Class
