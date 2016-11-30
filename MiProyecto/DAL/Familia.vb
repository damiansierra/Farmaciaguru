Public Class Familia
    Implements BE.ICrud(Of BE.Familia)

    Private Shared _instancia As DAL.Familia

    Public Shared Function GetInstance() As DAL.Familia

        If _instancia Is Nothing Then

            _instancia = New DAL.Familia

        End If

        Return _instancia
    End Function


    Public servidor As String
    Public instancia As String
    Public Shared conn As New SqlClient.SqlConnection

    Public Function alta(obj As BE.Familia) As Boolean Implements BE.ICrud(Of BE.Familia).alta


        Try

            Dim DV As New DAL.DV
            Dim dt As New DataTable
            Dim dt2 As New DataTable
            Dim SELECTFAM As String = "SELECT * FROM FAMILIA"
            dt = DAL.Conexion.GetInstance.leer(SELECTFAM)
            Dim DVV As Integer = 0

            For Each _ROW As DataRow In dt.Rows
                DVV = DVV + _ROW.Item("DVH")
            Next

            Dim DALSEGURIDAD As New DAL.Seguridad
            Dim FAMILIAENCRIPTADO As String = Seguridad.EncriptarReversible(obj.Nombre)

            Dim INSERT As String = "INSERT INTO FAMILIA VALUES " & "('" & FAMILIAENCRIPTADO & "',1)"
            DAL.Conexion.GetInstance.Escribir(INSERT)

            SELECTFAM = "SELECT * FROM FAMILIA WHERE DVH = 1"
            dt2 = DAL.Conexion.GetInstance.leer(SELECTFAM)
            For Each _ROW As DataRow In dt2.Rows
                obj.IdFamilia = _ROW.Item("IDFAMILIA")
            Next

            Dim DVH As String = DV.CALCULARDVH(obj.IdFamilia & FAMILIAENCRIPTADO)
            obj.DVH = DVH
            DVV = DVV + DVH

            Dim MODIFICARDVH As String = "UPDATE FAMILIA SET DVH = " & obj.DVH & " WHERE IDFAMILIA = " & obj.IdFamilia
            DAL.Conexion.GetInstance.Escribir(MODIFICARDVH)

            Dim MODIFICARDVV As String = "UPDATE DV SET DVV = " & DVV & " WHERE NOMBRETABLA = 'FAMPAT'"
            DAL.Conexion.GetInstance.Escribir(MODIFICARDVV)

            Dim dvs As New DAL.DV
            dvs.RECALCULARDVS()
            Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function baja(obj As BE.Familia) As Boolean Implements BE.ICrud(Of BE.Familia).baja
        Try

            DAL.Conexion.GetInstance.Escribir("DELETE FROM USUFAM WHERE IDFAMILIA = " & obj.IdFamilia)
            DAL.Conexion.GetInstance.Escribir("DELETE FROM FAMPAT WHERE IDFAMILIA = " & obj.IdFamilia)
            DAL.Conexion.GetInstance.Escribir("DELETE FROM FAMILIA WHERE IDFAMILIA = " & obj.IdFamilia)

            Dim SELECTFAM As String = "SELECT SUM(DVH) FROM USUFAM"
            Dim DVV As Integer = DAL.Conexion.GetInstance.leerINT(SELECTFAM)
            Dim MODIFICARDVV As String = "UPDATE DV SET DVV = " & DVV & " WHERE NOMBRE = 'USUFAM'"
            DAL.Conexion.GetInstance.Escribir(MODIFICARDVV)

            Dim SELECTFAM2 As String = "SELECT SUM(DVH) FROM FAMPAT"
            Dim DVV2 As Integer = DAL.Conexion.GetInstance.leerINT(SELECTFAM2)
            Dim MODIFICARDVV2 As String = "UPDATE DV SET DVV = " & DVV2 & " WHERE NOMBRE = 'FAMPAT'"
            DAL.Conexion.GetInstance.Escribir(MODIFICARDVV2)

            Dim dvs As New DAL.DV
            dvs.RECALCULARDVS()
            Return True


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function listarPorId(obj As BE.Familia) As BE.Familia Implements BE.ICrud(Of BE.Familia).listarPorId
        Try

            Dim nombreencriptado As String = Seguridad.EncriptarReversible(obj.Nombre)

            Dim FAMILIA As New BE.Familia
            Dim dt As New DataTable


            Dim SELECTFAM As String = "SELECT * FROM FAMILIA WHERE Nombre = '" & nombreencriptado & "'"
            dt = DAL.Conexion.GetInstance.leer(SELECTFAM)

            Dim _ROW As DataRow = dt.Rows(0)

            FAMILIA.IdFamilia = _ROW("IDFAMILIA")
            FAMILIA.Nombre = obj.Nombre
            FAMILIA.DVH = _ROW("DVH")

            Dim dt2 As New DataTable
            SELECTFAM = "SELECT FP.IDPATENTE,PA.NOMBRE FROM FAMPAT AS FP JOIN PATENTE AS PA ON FP.IDPATENTE = PA.IDPATENTE WHERE FP.IDFAMILIA = " & FAMILIA.IdFamilia
            dt2 = DAL.Conexion.GetInstance.leer(SELECTFAM)

            Dim LISTADEPATENTES As New List(Of BE.Patente)
            FAMILIA.Patente = LISTADEPATENTES
            For Each _ROW In dt2.Rows
                FAMILIA.Patente.Add(New BE.Patente With {.Idpatente = _ROW("IDPATENTE"), .Nombre = _ROW("Nombre")})
            Next


            Return FAMILIA

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function listarTodos() As List(Of BE.Familia) Implements BE.ICrud(Of BE.Familia).listarTodos
        Try
            Dim dt As New DataTable

            Dim SELECTFAM As String = "SELECT * FROM FAMILIA"
            dt = DAL.Conexion.GetInstance.leer(SELECTFAM)

            Dim DALSEGURIDAD As New DAL.Seguridad
            Dim LISTADEFAMILIAS As New List(Of BE.Familia)
            For Each _ROW In dt.Rows
                LISTADEFAMILIAS.Add(New BE.Familia With {.IdFamilia = _ROW("IDFAMILIA"), .Nombre = DAL.Seguridad.DesEncriptar(_ROW("Nombre")), .DVH = _ROW("DVH")})
            Next

            Return LISTADEFAMILIAS
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function modificacion(obj As BE.Familia) As Boolean Implements BE.ICrud(Of BE.Familia).modificacion

        Try

            DAL.Conexion.GetInstance.Escribir("DELETE FROM FAMPAT WHERE IDFAMILIA = " & obj.IdFamilia)



            Dim DALDV As New DAL.DV
            For Each PAT In obj.Patente
                Dim DVV2 As Integer = DALDV.pasaraASCII(obj.IdFamilia & PAT.Idpatente)
                DAL.Conexion.GetInstance.Escribir("INSERT INTO FAMPAT VALUES (" & obj.IdFamilia & "," & PAT.Idpatente & "," & DVV2 & ")")
            Next

            Dim SELECTFAM As String = "SELECT SUM(DVH) FROM FAMPAT"
            Dim DVV As Integer = DAL.Conexion.GetInstance.leerINT(SELECTFAM)
            Dim MODIFICARDVV As String = "UPDATE DV SET DVV = " & DVV & " WHERE NOMBRETABLA = 'FAMPAT'"
            DAL.Conexion.GetInstance.Escribir(MODIFICARDVV)

            Dim dvs As New DAL.DV
            dvs.RECALCULARDVS()

            Return True

        Catch ex As Exception
            Throw ex
        End Try


    End Function


    Function ValidarEliminarFamiliaUsuario(FamiliaBE As BE.Familia, UsuarioBE As BE.Usuario) As Boolean

        Dim sqlString As String
        Dim sqlString2 As String




        Try
            Dim listpatente As New List(Of BE.Patente)

            listpatente = DAL.PatenteDALL.GetInstance.listarTodos

            Dim dt As New DataTable
            Dim dt2 As New DataTable

            For Each row In listpatente


                'sqlString = String.Format("select idpatente from fampat join usufam ")
                'sqlString = sqlString & String.Format(" on fampat.idfamilia = usufam.idfamilia ")
                'sqlString = sqlString & String.Format(" where idpatente = " & row.Idpatente & " and fampat.idfamilia <> " & FamiliaBE.IdFamilia & " ")
                'sqlString = sqlString & String.Format(" and usufam.idusuario <> " & UsuarioBE.IdUsuario & " ")
                'sqlString = sqlString & String.Format(" and idusuario not in(select idusuario from usupat ")
                'sqlString = sqlString & String.Format(" where idpatente = fampat.idpatente and ")
                'sqlString = sqlString & String.Format(" idusuario = usufam.idusuario and negado = 1) ")


                sqlString = String.Format(" select * from UsuPat up	inner join Usuario u on u.idusuario = up.idusuario ")
                sqlString = sqlString & String.Format(" where up.idpatente = " & row.Idpatente & " and up.Negado = 0 ")
                sqlString = sqlString & String.Format("	and u.bloqueado = 0	")
                Dim SELECTFAM As String = (sqlString)

                dt = DAL.Conexion.GetInstance.leer(SELECTFAM)
                If dt.Rows.Count > 0 Then
                    Return True
                Else

                    sqlString2 = String.Format(" select * from fampat pf ")
                    sqlString2 = sqlString2 & String.Format("	inner join usufam fu on fu.idfamilia = pf.idfamilia inner join Usuario u ")
                    sqlString2 = sqlString2 & String.Format("	on u.idusuario = fu.idusuario AND pf.idpatente NOT in ( Select up.idpatente ")
                    sqlString2 = sqlString2 & String.Format("	from usupat up 	where up.idusuario = " & UsuarioBE.IdUsuario & " and up.negado = 1) ")
                    sqlString2 = sqlString2 & String.Format(" and pf.idpatente = " & row.Idpatente & " ")
                    sqlString2 = sqlString2 & String.Format("	and pf.idpatente = " & row.Idpatente & " and (pf.idfamilia != " & FamiliaBE.IdFamilia & " or fu.idusuario != " & UsuarioBE.IdUsuario & " ")
                    sqlString2 = sqlString2 & String.Format("	and u.bloqueado = 0	and u.baja = 0 )")

                    Dim SELECTFAM2 As String = (sqlString2)
                    dt2 = DAL.Conexion.GetInstance.leer(SELECTFAM2)
                    If dt2.Rows.Count > 1 Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try

        Return ValidarEliminarFamiliaUsuario

    End Function



    Public Function ValidarEliminarFamilia(FamiliaBE As BE.Familia) As Boolean

        Dim sqlString As String
        Dim sqlString2 As String




        Try
            Dim listpatente As New List(Of BE.Patente)

            listpatente = DAL.PatenteDALL.GetInstance.listarTodos

            Dim dt As New DataTable
            Dim dt2 As New DataTable

            For Each row In listpatente


                'sqlString = String.Format("select idpatente from fampat join usufam ")
                'sqlString = sqlString & String.Format(" on fampat.idfamilia = usufam.idfamilia ")
                'sqlString = sqlString & String.Format(" where idpatente = " & row.Idpatente & " and fampat.idfamilia <> " & FamiliaBE.IdFamilia & " ")
                'sqlString = sqlString & String.Format(" and usufam.idusuario <> " & UsuarioBE.IdUsuario & " ")
                'sqlString = sqlString & String.Format(" and idusuario not in(select idusuario from usupat ")
                'sqlString = sqlString & String.Format(" where idpatente = fampat.idpatente and ")
                'sqlString = sqlString & String.Format(" idusuario = usufam.idusuario and negado = 1) ")


                sqlString = String.Format(" select * from UsuPat up	inner join Usuario u on u.idusuario = up.idusuario ")
                sqlString = sqlString & String.Format(" where up.idpatente = " & row.Idpatente & " and up.Negado = 0 ")
                sqlString = sqlString & String.Format("	and u.bloqueado = 0	")
                Dim SELECTFAM As String = (sqlString)

                dt = DAL.Conexion.GetInstance.leer(SELECTFAM)
                If dt.Rows.Count > 0 Then
                    Return True
                Else


                    sqlString2 = String.Format(" select * from fampat pf ")
                    sqlString2 = sqlString2 & String.Format("	inner join usufam fu on fu.idfamilia = pf.idfamilia inner join Usuario u ")
                    sqlString2 = sqlString2 & String.Format("	on u.idusuario = fu.idusuario where  fu.idfamilia != " & FamiliaBE.IdFamilia & " ")
                    sqlString2 = sqlString2 & String.Format("	AND pf.idpatente = " & row.Idpatente & " AND u.bloqueado = 0 ")
                    sqlString2 = sqlString2 & String.Format(" AND pf.idpatente not in ( select up.idpatente from  UsuPat up ")
                    sqlString2 = sqlString2 & String.Format("	where up.idusuario = u.idusuario ")
                    sqlString2 = sqlString2 & String.Format("	AND up.negado = 1 )")

                    Dim SELECTFAM2 As String = (sqlString2)
                    dt2 = DAL.Conexion.GetInstance.leer(SELECTFAM2)
                    If dt2.Rows.Count > 1 Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try


        Return ValidarEliminarFamilia
    End Function

   
End Class
