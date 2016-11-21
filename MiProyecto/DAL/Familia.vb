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

            Dim MODIFICARDVV As String = "UPDATE DV SET DVV = " & DVV & " WHERE NOMBRE = 'FAMILIA'"
            DAL.Conexion.GetInstance.Escribir(MODIFICARDVV)

            Return True

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function baja(obj As BE.Familia) As Boolean Implements BE.ICrud(Of BE.Familia).baja

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

            Return True

        Catch ex As Exception
            Throw ex
        End Try


    End Function

   
End Class
