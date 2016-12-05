Imports System.IO

Public Class Usuario
    Implements BE.ICrud(Of BE.Usuario)

    Dim SqlConn As New SqlClient.SqlConnection With {.ConnectionString = Conexion.getConexionMaster}


    Private Shared _instancia As DAL.Usuario

    Public Shared Function GetInstance() As DAL.Usuario

        If _instancia Is Nothing Then

            _instancia = New DAL.Usuario

        End If
        Return _instancia
    End Function



    Public Function alta(obj As BE.Usuario) As Boolean Implements BE.ICrud(Of BE.Usuario).alta


        ESCRIBIRPASSENTXT(obj.Password, obj.Nick)
        Dim userEncriptado As String = Trim(Seguridad.EncriptarReversible(obj.Nick))
        Dim passEncriptado As String

        'En caso de que haya sido modificado el password, el nuevo tiene que ser encriptado
        '   If (obj.PasswordModificado) Then
        passEncriptado = Seguridad.EncriptarIrreversible(Trim(obj.Password))
        '   End If
        Try

            Dim parameters As New Dictionary(Of String, Object)

            If (obj.IdUsuario = 0) Then

                Dim INSERT As String = "INSERT INTO USUARIO VALUES " & "('" & obj.Apellido & "','" & obj.Nombre & "','" & passEncriptado & "','" & userEncriptado & "','" & obj.Cant_Int & "','" & obj.bloqueado & "','" & obj.Baja & "')"
                DAL.Conexion.GetInstance.Escribir(INSERT)

            End If




        Catch ex As Exception
            MsgBox("Problemas con la base de datos")
        End Try

        Return alta

    End Function

    Public Function baja(obj As BE.Usuario) As Boolean Implements BE.ICrud(Of BE.Usuario).baja


        Try


            Dim NickDesEncriptado As String = Seguridad.EncriptarReversible(obj.Nick)

            obj.Nick = NickDesEncriptado
            Dim ID As Integer = DAL.Conexion.GetInstance.leerINT("SELECT IdUsuario FROM USUARIO WHERE Nick = '" & obj.Nick & "'")
            obj.IdUsuario = ID

            Dim USUARIO As New BE.Usuario With {.IdUsuario = ID, .Nick = obj.Nick, .Familias = New List(Of BE.Familia), .Patentes = New List(Of BE.Patente)}


            Dim dalservicios As New DAL.SERVICIOS

            ' If dalservicios.checkborradousuarios(USUARIO) = True Then

            DAL.Conexion.GetInstance.Escribir("DELETE FROM USUFAM WHERE IDUSUARIO = " & obj.IdUsuario)
            DAL.Conexion.GetInstance.Escribir("DELETE FROM USUPAT WHERE IDUSUARIO = " & obj.IdUsuario)
            DAL.Conexion.GetInstance.Escribir("Delete from USUARIO WHERE IDUSUARIO =   '" & obj.IdUsuario & "'")




            Dim SELECTFAM As String = "SELECT SUM(DVH) FROM USUFAM"
            Dim DVV As Integer = DAL.Conexion.GetInstance.leerINT(SELECTFAM)
            Dim MODIFICARDVV As String = "UPDATE DV SET DVV = " & DVV & " WHERE NOMBRETABLA = 'USUFAM'"
            DAL.Conexion.GetInstance.Escribir(MODIFICARDVV)

            Dim SELECTFAM2 As String = "SELECT SUM(DVH) FROM USUPAT"
            Dim DVV2 As Integer = DAL.Conexion.GetInstance.leerINT(SELECTFAM2)
            Dim MODIFICARDVV2 As String = "UPDATE DV SET DVV = " & DVV2 & " WHERE NOMBRETABLA = 'USUPAT'"
            DAL.Conexion.GetInstance.Escribir(MODIFICARDVV2)

            Dim dvs As New DAL.DV
            dvs.RECALCULARDVS()




            Return True

         



        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function listarPorId(obj As BE.Usuario) As BE.Usuario Implements BE.ICrud(Of BE.Usuario).listarPorId

        Try

            Dim USUARIO As New BE.Usuario
            Dim dt As New DataTable


            Dim USUARIOENCRIPTADO As String = Seguridad.EncriptarReversible(obj.Nick)
            Dim SELECTUSER As String = "SELECT * FROM USUARIO WHERE Nick = '" & USUARIOENCRIPTADO & "'"
            dt = DAL.Conexion.GetInstance.leer(SELECTUSER)

            Dim _ROW As DataRow = dt.Rows(0)

            USUARIO.IdUsuario = _ROW("IDUSUARIO")
            USUARIO.Apellido = _ROW("APELLIDO")
            USUARIO.Nick = obj.Nick
            USUARIO.Nombre = _ROW("NOMBRE")
            USUARIO.Cant_Int = _ROW("CANT_INT")


            Dim dt2 As New DataTable
            SELECTUSER = "SELECT US.IDPATENTE,PA.NOMBRE,US.NEGADO FROM USUPAT AS US JOIN PATENTE AS PA ON US.IDPATENTE = PA.IDPATENTE WHERE US.IDUSUARIO = " & USUARIO.IdUsuario
            dt2 = DAL.Conexion.GetInstance.leer(SELECTUSER)

            Dim LISTADEPATENTES As New List(Of BE.Patente)
            USUARIO.Patentes = LISTADEPATENTES
            For Each _ROW In dt2.Rows
                USUARIO.Patentes.Add(New BE.Patente With {.Idpatente = _ROW("IDPATENTE"), .Nombre = _ROW("NOMBRE"), .NEGADO = _ROW("NEGADO")})
            Next

            Dim dt3 As New DataTable
            SELECTUSER = "SELECT US.IDFAMILIA,FA.NOMBRE  FROM USUFAM AS US JOIN FAMILIA AS FA ON US.IDFAMILIA = FA.IDFAMILIA WHERE US.IDUSUARIO= " & USUARIO.IdUsuario
            dt3 = DAL.Conexion.GetInstance.leer(SELECTUSER)

            Dim LISTADEFAMILIAS As New List(Of BE.Familia)
            USUARIO.Familias = LISTADEFAMILIAS

            For Each _ROW In dt3.Rows
                USUARIO.Familias.Add(New BE.Familia With {.IdFamilia = _ROW("IDFAMILIA"), .Nombre = Seguridad.DesEncriptar(_ROW("NOMBRE"))})
            Next

            Return USUARIO

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function listarTodos() As List(Of BE.Usuario) Implements BE.ICrud(Of BE.Usuario).listarTodos
        Try
            Dim USUARIOS As New List(Of BE.Usuario)
            Dim dt As New DataTable
            Dim i As Integer = 0


            Dim SELECTALL As String = "SELECT * FROM USUARIO"
            dt = DAL.Conexion.GetInstance.leer(SELECTALL)

            For Each _ROW In dt.Rows
                USUARIOS.Add(New BE.Usuario With {.IdUsuario = _ROW("IDUSUARIO"), .Apellido = _ROW("APELLIDO"), .Baja = _ROW("BAJA"), .Nick = DAL.Seguridad.DesEncriptar(_ROW("NICK")), .Nombre = _ROW("NOMBRE")})
            Next
            Return USUARIOS

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function modificacion(obj As BE.Usuario) As Boolean Implements BE.ICrud(Of BE.Usuario).modificacion

        Try
            Dim USUARIO As New BE.Usuario
            Dim dt As New DataTable

            Dim USUARIOENCRIPTADO As String = Seguridad.EncriptarReversible(obj.Nick)
            Dim SELECTUSER As String = "SELECT * FROM USUARIO WHERE Nick = '" & USUARIOENCRIPTADO & "'"
            dt = DAL.Conexion.GetInstance.leer(SELECTUSER)

            Dim _ROW As DataRow = dt.Rows(0)

            Usuario.IdUsuario = _ROW("IDUSUARIO")
            Usuario.Apellido = _ROW("APELLIDO")
            Usuario.Nick = obj.Nick
            Usuario.Nombre = _ROW("NOMBRE")
            Usuario.Cant_Int = _ROW("CANT_INT")



            DAL.Conexion.GetInstance.Escribir("DELETE FROM USUPAT WHERE IDUSUARIO = " & USUARIO.IdUsuario)
            DAL.Conexion.GetInstance.Escribir("DELETE FROM USUFAM WHERE IDUSUARIO = " & USUARIO.IdUsuario)


            Dim DALDV As New DAL.DV
            For Each PAT In obj.Patentes
                Dim NEG = 0
                If PAT.NEGADO = True Then
                    NEG = 1
                End If
                Dim DVV2 As Integer = DALDV.pasaraASCII(PAT.Idpatente & USUARIO.IdUsuario & NEG)
                DAL.Conexion.GetInstance.Escribir("INSERT INTO USUPAT VALUES (" & USUARIO.IdUsuario & "," & PAT.Idpatente & "," & NEG & " ," & DVV2 & ")")
            Next

            Dim SELECTPAT As String = "SELECT SUM(DVH) FROM USUPAT"
            Dim DVV As Integer = DAL.Conexion.GetInstance.leerINT(SELECTPAT)
            Dim MODIFICARDVV As String = "UPDATE DV SET DVV = " & DVV & " WHERE NOMBRETABLA = 'USUPAT'"
            DAL.Conexion.GetInstance.Escribir(MODIFICARDVV)



            For Each FAM In obj.Familias

                Dim DVV3 As Integer = DALDV.pasaraASCII(USUARIO.IdUsuario & FAM.IdFamilia)
                DAL.Conexion.GetInstance.Escribir("INSERT INTO USUFAM VALUES (" & USUARIO.IdUsuario & "," & FAM.IdFamilia & "," & DVV3 & ")")
            Next

            Dim SELECTFAM As String = "SELECT SUM(DVH) FROM USUFAM"
            Dim DVV4 As Integer = DAL.Conexion.GetInstance.leerINT(SELECTFAM)
            Dim MODIFICARDVV2 As String = "UPDATE DV SET DVV = " & DVV4 & " WHERE NOMBRETABLA = 'USUFAM'"
            DAL.Conexion.GetInstance.Escribir(MODIFICARDVV2)


            Return True

            Dim dvs As New DAL.DV
            dvs.RECALCULARDVS()


        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function LOGIN(USUARIO As BE.Usuario) As Integer

        Try
            Dim dt As New DataTable
            Dim i As Integer = 0

            Dim PASSENCRIPTADA As String
            Dim USUARIOENCRIPTADO As String
            Dim DALSEGURIDAD As New DAL.seguridad
            USUARIOENCRIPTADO = Seguridad.EncriptarReversible(Trim(USUARIO.Nick))
            PASSENCRIPTADA = Seguridad.EncriptarIrreversible(Trim(USUARIO.Password))


            Dim SELECTUSER As String = "SELECT * FROM USUARIO WHERE nick = '" & USUARIOENCRIPTADO & "' AND password = '" & PASSENCRIPTADA & "' AND CANT_INT < 4"
            dt = DAL.Conexion.GetInstance.leer(SELECTUSER)
            If dt.Rows.Count = 1 Then
                '''' DEVUELVO 1 SI EL USUARIO Y CONTRASEÑA SON CORRECTOS
                '''' vuelvo a 0 el contador de intentos fallidos
                Try
                    Dim DV As New DAL.DV
                    Dim dt3 As New DataTable
                    Dim dt4 As New DataTable

                    Dim DVV As Integer = 0



                    Dim UPDATEBLOCK As String = "UPDATE USUARIO SET CANT_INT = 0 WHERE IDUSUARIO = " & dt.Rows(0).Item(0)
                    DAL.Conexion.GetInstance.Escribir(UPDATEBLOCK)
                    '    Dim SELECTUSU As String = "SELECT * FROM USUARIO WHERE DVH = 1"

                    '     dt3 = DAL.Conexion.GetInstance.leer(SELECTUSU)



                    '    USUARIO.DVH = DV.concatenar(dt3.Rows(0), dt3.Columns.Count)



                    '    Dim MODIFICARDVH As String = "UPDATE USUARIO SET DVH = " & USUARIO.DVH & " WHERE ID_USUARIO = " & dt.Rows(0).Item(0)
                    '       DAL.Conexion.GetInstance.Escribir(MODIFICARDVH)


                    '  Dim SELECTDVH As String = "SELECT SUM(DVH) FROM USUARIO"
                    '     Dim DVV2 As Integer = DAL.Conexion.GetInstance.leerINT(SELECTDVH)


                    '           Dim MODIFICARDVV As String = "UPDATE DV SET DVV = " & DVV2 & " WHERE NOMBRE = 'USUARIO'"
                    '       DAL.Conexion.GetInstance.Escribir(MODIFICARDVV)



                Catch ex As Exception
                    Throw ex
                End Try




                Return 1
            End If

            Dim SELECTUSER2 As String = "SELECT * FROM USUARIO WHERE nick = '" & USUARIOENCRIPTADO & "'"
            Dim dt2 As DataTable = DAL.Conexion.GetInstance.leer(SELECTUSER2)
            If dt2.Rows.Count = 1 Then
                '''' DEVUELVO 2 SI EL USUARIO ES CORRECTO PERO LA CONTRASEÑA NO}
                Return 2
            End If

            Return 0


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function AGREGARINTENTODEBLOQUEO(OBJETO As BE.Usuario) As Boolean
        Try
            Dim DV As New DAL.DV
            Dim dt As New DataTable
            Dim dt2 As New DataTable

            Dim DVV As Integer = 0



            Dim SELECTBLOCK As Integer = DAL.Conexion.GetInstance.leerINT("SELECT CANT_INT FROM USUARIO WHERE IDUSUARIO =" & OBJETO.IdUsuario)
            Dim UPDATEBLOCK As String = "UPDATE USUARIO SET CANT_INT = " & SELECTBLOCK + 1 & " WHERE IDUSUARIO = " & OBJETO.IdUsuario
            DAL.Conexion.GetInstance.Escribir(UPDATEBLOCK)
        
            Return True

        Catch ex As Exception
            Throw ex
        End Try



    End Function

    Public Function MODIFICARDATOS(OBJETO As BE.Usuario) As Boolean

        Try
            Dim DV As New DAL.DV
            Dim dt As New DataTable
            Dim dt2 As New DataTable

            Dim DVV As Integer = 0


            Dim DALSEGURIDAD As New DAL.seguridad
            Dim USUARIOENCRIPTADO As String = Seguridad.EncriptarReversible(OBJETO.Nick)

            Dim ID As Integer = DAL.Conexion.GetInstance.leerINT("SELECT IDUSUARIO FROM USUARIO WHERE USUARIO= '" & USUARIOENCRIPTADO & "'")
            OBJETO.IdUsuario = ID

            Dim UPDATE As String = "UPDATE USUARIO SET NOMBRE= '" & OBJETO.Nombre & "', APELLIDO= '" & OBJETO.Apellido & "' WHERE IDUSUARIO =" & OBJETO.IdUsuario
            DAL.Conexion.GetInstance.Escribir(UPDATE)



            Return True
        Catch ex As Exception
            Throw ex
        End Try



    End Function

    Public Function CAMBIARPASS(USER As String, PASSANTERIOR As String, NUEVAPASS As String) As Boolean

        Try
            Dim DV As New DAL.DV
            Dim dt As New DataTable
            Dim dt2 As New DataTable

            Dim DVV As Integer = 0


            Dim DALSEGURIDAD As New DAL.seguridad
            Dim USUARIOENCRIPTADO As String = Seguridad.EncriptarReversible(USER)
            Dim passencriptada As String = Seguridad.EncriptarIrreversible(PASSANTERIOR)

            Dim DT3 As DataTable = DAL.Conexion.GetInstance.leer("SELECT IDUSUARIO FROM USUARIO WHERE USUARIO= '" & USUARIOENCRIPTADO & "' AND PASS= '" & passencriptada & "'")

            If DT3.Rows.Count = 1 Then

                Dim NUEVAPASSENCRIPTADA As String = Seguridad.EncriptarIrreversible(NUEVAPASS)

                Dim UPDATE As String = "UPDATE USUARIO SET PASS= '" & NUEVAPASSENCRIPTADA & "', WHERE IDUSUARIO =" & DT3.Rows(0).Item(0)
                DAL.Conexion.GetInstance.Escribir(UPDATE)



                Return True
            Else
                Return False
            End If





        Catch ex As Exception
            Throw ex
        End Try


    End Function



    Sub ESCRIBIRPASSENTXT(PASS As String, USER As String)
        Dim sRenglon As String = Nothing
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim ContenidoArchivo As String = Nothing
        ' Donde guardamos los paths de los archivos que vamos a estar utilizando ..
        Dim PathArchivo As String


        Dim i As Integer

        Try

            If Directory.Exists("D:\farmacia\password") = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory("D:\farmacia\password")
            End If

            'Windows.Forms.Cursor.Current = Cursors.WaitCursor
            PathArchivo = "D:\farmacia\Resets\" & USER & Format(Today.Date, "ddMMyyyy") & ".txt" ' Se determina el nombre del archivo con la fecha actual

            'verificamos si existe el archivo

            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura


            'escribimos en el archivo

            strStreamWriter.WriteLine(PASS)


            strStreamWriter.Close() ' cerramos

        Catch ex As Exception
            strStreamWriter.Close() ' cerramos
        End Try

    End Sub



    Function ValidarEliminarUsuarioPatente(UsuarioBE As BE.Usuario, PatenteBE As BE.Patente) As Boolean


        Dim sqlString As String
        Dim sqlString2 As String
        Dim sqlString3 As String





        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim dt3 As New DataTable





        'sqlString = String.Format("select idpatente from fampat join usufam ")
        'sqlString = sqlString & String.Format(" on fampat.idfamilia = usufam.idfamilia ")
        'sqlString = sqlString & String.Format(" where idpatente = " & row.Idpatente & " and fampat.idfamilia <> " & FamiliaBE.IdFamilia & " ")
        'sqlString = sqlString & String.Format(" and usufam.idusuario <> " & UsuarioBE.IdUsuario & " ")
        'sqlString = sqlString & String.Format(" and idusuario not in(select idusuario from usupat ")
        'sqlString = sqlString & String.Format(" where idpatente = fampat.idpatente and ")
        'sqlString = sqlString & String.Format(" idusuario = usufam.idusuario and negado = 1) ")


        Try


            sqlString = String.Format(" select * from UsuPat up	inner join Usuario u on u.idusuario = up.idusuario ")
            sqlString = sqlString & String.Format(" where up.idpatente = " & PatenteBE.Idpatente & " and u.idusuario != " & UsuarioBE.IdUsuario & " and up.Negado = 0 ")
            sqlString = sqlString & String.Format("	and u.bloqueado = 0	")
            Dim SELECTUSU As String = (sqlString)

            dt = DAL.Conexion.GetInstance.leer(SELECTUSU)
            If dt.Rows.Count > 0 Then
                Return True
            Else

                sqlString3 = String.Format(" select *  from dbo.fampat pf, dbo.usufam fu, dbo.Usuario u, dbo.UsuPat up where pf.idpatente = " & PatenteBE.Idpatente & " ")
                sqlString3 = sqlString3 & String.Format(" And pf.idfamilia = fu.idfamilia  and fu.idusuario = u.idusuario  and u.idusuario = " & UsuarioBE.IdUsuario & " ")
                sqlString3 = sqlString3 & String.Format(" and u.bloqueado = 0 ")
                Dim SELECTALGO As String = (sqlString3)

                dt3 = DAL.Conexion.GetInstance.leer(SELECTALGO)
                If dt3.Rows.Count > 0 Then
                    Return True
                Else



                    sqlString2 = String.Format(" select *  from dbo.fampat pf,  dbo.usufam fu, dbo.Usuario u, dbo.UsuPat up")
                    sqlString2 = sqlString2 & String.Format("	where pf.idpatente = " & PatenteBE.Idpatente & " ")
                    sqlString2 = sqlString2 & String.Format("	and pf.idfamilia = fu.idfamilia ")
                    sqlString2 = sqlString2 & String.Format("	and fu.idusuario = u.idusuario ")
                    sqlString2 = sqlString2 & String.Format("  and u.idusuario != " & UsuarioBE.IdUsuario & " and u.bloqueado = 0 ")
                    sqlString2 = sqlString2 & String.Format("	AND pf.idpatente NOT in ( Select up.idpatente from UsuPat up ")
                    sqlString2 = sqlString2 & String.Format("	where up.idusuario = u.idusuario and up.negado = 1 )")

                    Dim SELECTFAM2 As String = (sqlString2)
                    dt2 = DAL.Conexion.GetInstance.leer(SELECTFAM2)
                    If dt2.Rows.Count > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return ValidarEliminarUsuarioPatente

    End Function



    Function ValidarEliminarUsuarioPatenteNegacion(UsuarioBE As BE.Usuario, PatenteBE As BE.Patente) As Boolean
        Dim sqlString As String
        Dim sqlString2 As String






        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim dt3 As New DataTable





        'sqlString = String.Format("select idpatente from fampat join usufam ")
        'sqlString = sqlString & String.Format(" on fampat.idfamilia = usufam.idfamilia ")
        'sqlString = sqlString & String.Format(" where idpatente = " & row.Idpatente & " and fampat.idfamilia <> " & FamiliaBE.IdFamilia & " ")
        'sqlString = sqlString & String.Format(" and usufam.idusuario <> " & UsuarioBE.IdUsuario & " ")
        'sqlString = sqlString & String.Format(" and idusuario not in(select idusuario from usupat ")
        'sqlString = sqlString & String.Format(" where idpatente = fampat.idpatente and ")
        'sqlString = sqlString & String.Format(" idusuario = usufam.idusuario and negado = 1) ")


        Try




            sqlString = String.Format(" select * from UsuPat up	inner join Usuario u on u.idusuario = up.idusuario ")
            sqlString = sqlString & String.Format(" where up.idpatente = " & PatenteBE.Idpatente & " and u.idusuario != " & UsuarioBE.IdUsuario & " and up.Negado = 0 ")
            sqlString = sqlString & String.Format("	and u.bloqueado = 0	")
            Dim SELECTUSU As String = (sqlString)

            dt = DAL.Conexion.GetInstance.leer(SELECTUSU)
            If dt.Rows.Count > 0 Then
                Return True
            Else


                sqlString2 = String.Format(" select *  from dbo.fampat pf,  dbo.usufam fu, dbo.Usuario u ")
                sqlString2 = sqlString2 & String.Format("	where pf.idpatente = " & PatenteBE.Idpatente & " ")
                sqlString2 = sqlString2 & String.Format("	and pf.idfamilia = fu.idfamilia ")
                sqlString2 = sqlString2 & String.Format("	and fu.idusuario = u.idusuario ")
                sqlString2 = sqlString2 & String.Format("  and u.idusuario != " & UsuarioBE.IdUsuario & " ")
                sqlString2 = sqlString2 & String.Format("	AND pf.idpatente NOT in ( Select up.idpatente from UsuPat up ")
                sqlString2 = sqlString2 & String.Format("	where up.idusuario = u.idusuario and up.negado = 1 )")

                Dim SELECTFAM2 As String = (sqlString2)
                dt2 = DAL.Conexion.GetInstance.leer(SELECTFAM2)
                If dt2.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return ValidarEliminarUsuarioPatenteNegacion

    End Function



    Function ValidarEliminarUsuario(UsuarioBE As BE.Usuario) As Boolean

        Dim returnValue As Boolean
        Dim comm As New SqlClient.SqlCommand
        Dim usuarioId As New SqlClient.SqlParameter

        Dim reader As SqlClient.SqlDataReader

        comm.Connection = SqlConn
        comm.CommandType = CommandType.StoredProcedure
        comm.CommandText = "SP_ValidarEliminarUsuario"

        usuarioId.DbType = DbType.Int16
        usuarioId.ParameterName = "@usuario_id"
        usuarioId.Value = UsuarioBE.IdUsuario

        comm.Parameters.Add(usuarioId)

        Try
            SqlConn.Open()
            reader = comm.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    returnValue = reader.GetBoolean(0)
                End While
            End If
        Catch ex As Exception
            Throw ex
        Finally
            reader = Nothing
            SqlConn.Close()
        End Try
        Return returnValue

    End Function


    Public Function validarultimo()
        Try
            Dim DT3 As DataTable = DAL.Conexion.GetInstance.leer("SELECT * FROM USUARIO")
            Dim aver As Boolean = True

            If DT3.Rows.Count = 1 Then
                aver = False
            End If

            validarultimo = aver

            Return validarultimo

        Catch ex As Exception
            Throw ex
        End Try

    End Function
End Class
