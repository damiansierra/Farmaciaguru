﻿Imports System.Transactions
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
        Dim idUsuario As Integer
        If (obj.IdUsuario = 0) Then
            idUsuario = Conexion.ObtenerUltimoId("Usuario") + 1
            sqlString = "INSERT INTO USUARIO(Apellido, Nombre, [Password],[Nick], Cant_Int, Bloqueado, Baja) " & _
                            "values(@Apellido,@Nombre,@Password,@Nick,@Cant_Int,@Bloqueado,@Baja)"
        Else
            idUsuario = obj.IdUsuario
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
            obj.IdUsuario = idUsuario

            If (resultQuery <= 0) Then
                MsgBox("Problemas con la base de datos")
            End If

        Catch ex As Exception
            MsgBox("Problemas con la base de datos")
        End Try


    End Function

    Public Function baja(obj As BE.Usuario) As Boolean Implements BE.ICrud(Of BE.Usuario).baja


        Try


            Dim NickDesEncriptado As String = Seguridad.EncriptarReversible(obj.Nick)

            obj.Nick = NickDesEncriptado
            Dim ID As Integer = DAL.Conexion.GetInstance.leerINT("SELECT IdUsuario FROM USUARIO WHERE Nick = '" & obj.Nick & "'")
            obj.IdUsuario = ID

            '  Dim USUARIO As New BE.Usuario With {.IdUsuario = ID, .Nick = obj.Nick, .Familias = New List(Of BE.Familia), .Patentes = New List(Of BE.Patente)}


            'Dim dalservicios As New DAL.SERVICIOS

            '  If dalservicios.checkborradousuarios(USUARIO) = True Then

            '  DAL.Conexion.GetInstance.Escribir("DELETE FROM USUFAM WHERE IDUSUARIO = " & obj.IdUsuario)
            '  DAL.Conexion.GetInstance.Escribir("DELETE FROM USUPAT WHERE IDUSUARIO = " & obj.IdUsuario)
            DAL.Conexion.GetInstance.Escribir("Delete from USUARIO WHERE IDUSUARIO =   '" & obj.IdUsuario & "'")




            '   Dim SELECTFAM As String = "SELECT SUM(DVH) FROM USUFAM"
            '    Dim DVV As Integer = DAL.Conexion.GetInstance.leerINT(SELECTFAM)
            '    Dim MODIFICARDVV As String = "UPDATE DV SET DVV = " & DVV & " WHERE NOMBRE = 'USUFAM'"
            '   DAL.Conexion.GetInstance.Escribir(MODIFICARDVV)

            '   Dim SELECTFAM2 As String = "SELECT SUM(DVH) FROM USUPAT"
            '    Dim DVV2 As Integer = DAL.Conexion.GetInstance.leerINT(SELECTFAM2)
            '   Dim MODIFICARDVV2 As String = "UPDATE DV SET DVV = " & DVV2 & " WHERE NOMBRE = 'USUPAT'"
            '    DAL.Conexion.GetInstance.Escribir(MODIFICARDVV2)

            ' Dim SELECTFAM3 As String = "SELECT SUM(DVH) FROM USUARIO"
            'Dim DVV3 As Integer = DAL.Conexion.GetInstance.leerINT(SELECTFAM3)
            'Dim MODIFICARDVV3 As String = "UPDATE DV SET DVV = " & DVV3 & " WHERE NOMBRE = 'USUARIO'"
            'DAL.Conexion.GetInstance.Escribir(MODIFICARDVV3)

            Return True

            '  Else
            '   Return False
            '   End If



        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function listarPorId(obj As BE.Usuario) As BE.Usuario Implements BE.ICrud(Of BE.Usuario).listarPorId

    End Function

    Public Function listarTodos() As List(Of BE.Usuario) Implements BE.ICrud(Of BE.Usuario).listarTodos
        Try
            Dim USUARIOS As New List(Of BE.Usuario)
            Dim dt As New DataTable
            Dim i As Integer = 0


            Dim SELECTALL As String = "SELECT * FROM USUARIO"
            dt = DAL.Conexion.GetInstance.leer(SELECTALL)

            For Each _ROW In dt.Rows
                USUARIOS.Add(New BE.Usuario With {.Apellido = _ROW("APELLIDO"), .Baja = _ROW("BAJA"), .Nick = DAL.Seguridad.DesEncriptar(_ROW("NICK")), .Nombre = _ROW("NOMBRE")})
            Next
            Return USUARIOS

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function modificacion(obj As BE.Usuario) As Boolean Implements BE.ICrud(Of BE.Usuario).modificacion

    End Function
End Class
