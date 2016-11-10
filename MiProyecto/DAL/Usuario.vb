Public Class Usuario
    Implements BE.ICrud(Of BE.Usuario)


    Private Shared _instancia As DAL.Usuario

    Public Shared Function GetInstance() As DAL.Usuario

        If _instancia Is Nothing Then

            _instancia = New DAL.Usuario

        End If
        Return _instancia
    End Function



    Public Function alta(obj As BE.Usuario) As Boolean Implements BE.ICrud(Of BE.Usuario).alta



        Dim userEncriptado As String = Seguridad.EncriptarReversible(obj.Nick)
        Dim passEncriptado As String = obj.Password

        'En caso de que haya sido modificado el password, el nuevo tiene que ser encriptado
        If (obj.PasswordModificado) Then
            passEncriptado = Seguridad.EncriptarIrreversible(obj.Password)
        End If

        Dim sqlString As String
        Dim parameters As New Dictionary(Of String, Object)
        Dim id As Integer
        If (obj.Id = 0) Then
            id = Conexion.ObtenerUltimoId("Usuario") + 1
            sqlString = "INSERT INTO USUARIO(Apellido, Nombre, [Password],[Nick], Cant_Int, Bloqueado, Baja) " & _
                            "values(@Apellido,@Nombre,@Password,@Nick,@Cant_Int,@Bloqueado,@Baja)"
        Else
            id = obj.Id
            sqlString = "UPDATE USUARIO SET Apellido = @Apellido, Nombre = @Nombre, [Password] = @Password, [Nick] = @Nick, " & _
                "Cant_Int = @CCant_Int, Bloqueado = @Bloqueado, Baja = @Baja WHERE id = @id"

        End If


        parameters.Add("@Apellido", obj.Apellido)
        parameters.Add("@Nombre", obj.Nombre)
        parameters.Add("@Password", passEncriptado)
        parameters.Add("@Nick", userEncriptado)
        parameters.Add("@Cant_Int", obj.Cant_Int)
        parameters.Add("@Bloqueado", obj.bloqueado)
        parameters.Add("@Baja", obj.Baja)


        Try

            Dim resultQuery As Integer

            resultQuery = Conexion.ExecuteNonQuery(sqlString, parameters)
            obj.Id = id

            If (resultQuery <= 0) Then
                MsgBox("Problemas con la base de datos1")
            End If

        Catch ex As Exception
            MsgBox("Problemas con la base de datos2")
        End Try


    End Function

    Public Function baja(obj As BE.Usuario) As Boolean Implements BE.ICrud(Of BE.Usuario).baja

    End Function

    Public Function listarPorId(obj As BE.Usuario) As BE.Usuario Implements BE.ICrud(Of BE.Usuario).listarPorId

    End Function

    Public Function listarTodos() As List(Of BE.Usuario) Implements BE.ICrud(Of BE.Usuario).listarTodos

    End Function

    Public Function modificacion(obj As BE.Usuario) As Boolean Implements BE.ICrud(Of BE.Usuario).modificacion

    End Function
End Class
