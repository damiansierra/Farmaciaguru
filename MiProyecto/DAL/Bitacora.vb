Public Class Bitacora
    Implements BE.ICrud(Of BE.Bitacora)


    Private Shared _instancia As DAL.Bitacora
    Public Shared Function GetInstance() As DAL.Bitacora
        If _instancia Is Nothing Then
            _instancia = New DAL.Bitacora
        End If
        Return _instancia
    End Function

    Public Function alta(obj As BE.Bitacora) As Boolean Implements BE.ICrud(Of BE.Bitacora).alta

        Try

            Dim DV As New DAL.DV
            Dim dt As New DataTable
            Dim dt2 As New DataTable
            Dim SELECTLOG As String = "SELECT * FROM BITACORA"
            dt = DAL.Conexion.GetInstance.leer(SELECTLOG)
            Dim DVV As Integer = 0

            For Each _ROW As DataRow In dt.Rows
                DVV = DVV + _ROW.Item("DVH")
            Next

            Dim DALSEGURIDAD As New DAL.Seguridad
            Dim DESCRIPCIONENCRIPTADA As String = DAL.Seguridad.EncriptarReversible(obj.Descripcion)


            Dim sqlString As String
            Dim parameters As New Dictionary(Of String, Object)



            sqlString = "INSERT INTO BITACORA(NICK,CRITICIDAD,fechahora,DESCRIPCIO,DVH) " & _
                            "values(@Nick,@Criticidad,@fechahora,@Descripcion,@DVH)"

            Dim valor As Integer = 1

            parameters.Add("@Nick", obj.nick)
            parameters.Add("@Criticidad", obj.Criticidad)
            parameters.Add("@fechahora", System.DateTime.Now)
            parameters.Add("@Descripcion", DESCRIPCIONENCRIPTADA)
            parameters.Add("@DVH", valor)
          

            Try

                Dim resultQuery As Integer

                Conexion.conn.Close()

                resultQuery = Conexion.ExecuteNonQuery(sqlString, parameters)

                If (resultQuery <= 0) Then
                    MsgBox("Problemas con la base de datos")
                End If

            Catch ex As Exception
                MsgBox("Problemas con la base de datos")
            End Try







            '     Dim INSERT As String = "INSERT INTO BITACORA (NICK,CRITICIDAD,fechahora,DESCRIPCION,DVH) VALUES " & "('" & obj.nick & "','" & obj.Criticidad & "','" & fechahora & "','" & DESCRIPCIONENCRIPTADA & "'," & "1)"
            '  DAL.Conexion.GetInstance.Escribir(INSERT)

            SELECTLOG = "SELECT * FROM BITACORA WHERE DVH = 1"
            dt2 = DAL.Conexion.GetInstance.leer(SELECTLOG)
            For Each _ROW As DataRow In dt2.Rows
                obj.IdBitacora = _ROW.Item("IDBITACORA")
                obj.FechaHora = _ROW.Item("FECHAHORA")
            Next

            Dim DVH As String = DV.CALCULARDVH(obj.IdBitacora & obj.nick & obj.FechaHora & obj.Criticidad & DESCRIPCIONENCRIPTADA)
            obj.DVH = DVH
            DVV = DVV + DVH

            Dim MODIFICARDVH As String = "UPDATE BITACORA SET DVH = " & obj.DVH & " WHERE IDBITACORA = " & obj.IdBitacora
            DAL.Conexion.GetInstance.Escribir(MODIFICARDVH)

            Dim MODIFICARDVV As String = "UPDATE DV SET DVV = " & DVV & " WHERE NOMBRETABLA = 'BITACORA'"
            DAL.Conexion.GetInstance.Escribir(MODIFICARDVV)


            Dim dvs As New DAL.DV
            dvs.RECALCULARDVS()

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function baja(obj As BE.Bitacora) As Boolean Implements BE.ICrud(Of BE.Bitacora).baja

    End Function

    Public Function listarPorId(obj As BE.Bitacora) As BE.Bitacora Implements BE.ICrud(Of BE.Bitacora).listarPorId

    End Function

    Public Function listarTodos() As List(Of BE.Bitacora) Implements BE.ICrud(Of BE.Bitacora).listarTodos

    End Function

    Public Function modificacion(obj As BE.Bitacora) As Boolean Implements BE.ICrud(Of BE.Bitacora).modificacion

    End Function





    Public Function ListarBitacoraPorParametros(idusuario As Integer, fechaDesde As DateTime, fechaHasta As DateTime, criticidad As String) As List(Of BE.Bitacora)
    

        
        Try

            Dim USUARIO As New BE.Usuario
            Dim dt As New DataTable
           
            'Dim desde As String = fechaDesde.ToString("yyyy-MM-dd")
            '  Dim hasta As String = fechaHasta.ToString("yyyy-MM-dd")
            'Dim USUARIOENCRIPTADO As String = Seguridad.EncriptarReversible(obj.Nick)

            Dim SELECTUSER As String = "SELECT * FROM USUARIO WHERE idusuario = '" & idusuario & "'"
            dt = DAL.Conexion.GetInstance.leer(SELECTUSER)

            Dim _ROW As DataRow = dt.Rows(0)

            USUARIO.IdUsuario = _ROW("IDUSUARIO")
            USUARIO.Apellido = _ROW("APELLIDO")
            USUARIO.Nick = DAL.Seguridad.DesEncriptar(_ROW("NICK"))
            USUARIO.Nombre = _ROW("NOMBRE")
            USUARIO.Cant_Int = _ROW("CANT_INT")

            Dim dt2 As New DataTable

            Dim bitacoradelorto As String = "SELECT idbitacora, nick, descripcio, fechahora, criticidad FROM Bitacora " & _
                        " WHERE ( nick =  '" & USUARIO.Nick & "') and  ( fechahora >= '" & Format(fechaDesde, "yyyy-MM-dd") & "' and fechahora <= '" & Format(fechaHasta, "yyyy-MM-dd") & "') and (criticidad = '" & criticidad & "' ) "

            dt2 = DAL.Conexion.GetInstance.leer(bitacoradelorto)
            Dim bitacoras As New List(Of BE.Bitacora)

            For Each _ROW In dt2.Rows
                Dim BitacoraBE As New BE.Bitacora
                Dim UsuarioBE As New BE.Usuario
                BitacoraBE.IdBitacora = CInt(_ROW("idbitacora"))
                BitacoraBE.nick = CStr(_ROW("nick"))
                BitacoraBE.Descripcion = Seguridad.DesEncriptar(CStr(_ROW("descripcio")))
                BitacoraBE.FechaHora = CDate(_ROW("fechahora"))
                BitacoraBE.Criticidad = CStr(_ROW("criticidad"))
                bitacoras.Add(BitacoraBE)
            Next

            Return bitacoras

        Catch ex As Exception
            Throw ex
        End Try


    End Function
End Class
