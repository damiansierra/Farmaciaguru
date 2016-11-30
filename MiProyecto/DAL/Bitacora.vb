Public Class Bitacora
    Implements BE.ICrud(Of BE.Bitacora)


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

            '  If objeto.USUARIO.ID_USUARIO = 0 Then
            ' Dim USUARIOENCRIPTADO As String = Seguridad.EncriptarReversible(obj.nick)
            '  SELECTLOG = "SELECT IDUSUARIO FROM USUARIO WHERE USUARIO ='" & USUARIOENCRIPTADO & "'"
            '  Dim dt3 As DataTable = DAL.Conexion.GetInstance.leer(SELECTLOG)
            '  obj.nick = dt3.Rows(0).Item(0)
            '  End If



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
End Class
