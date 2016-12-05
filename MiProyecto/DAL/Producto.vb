Public Class Producto
    Implements BE.ICrud(Of BE.Producto)

    Private Shared _instancia As DAL.Producto
    Public Shared Function GetInstance() As DAL.Producto
        If _instancia Is Nothing Then
            _instancia = New DAL.Producto
        End If
        Return _instancia
    End Function


    Public Function alta(obj As BE.Producto) As Boolean Implements BE.ICrud(Of BE.Producto).alta
        Dim descripcionEncriptado As String = Trim(Seguridad.EncriptarReversible(obj.Descripcion))
        Dim PrecioEncriptado As String = Trim(Seguridad.EncriptarReversible(obj.Precio_Actual))
        Dim stockEncriptado As String = Trim(Seguridad.EncriptarReversible(obj.stock))
        Dim nombreEncriptado As String = Trim(Seguridad.EncriptarReversible(obj.Nombre))

       
        Try

            Dim parameters As New Dictionary(Of String, Object)

            Dim laboratorio As New BE.Laboratorio
            Dim dt As New DataTable


            Dim SELECTlab As String = "SELECT * FROM LABORATORIO WHERE nombre = '" & obj.laboratorio.Nombre & "'"
            dt = DAL.Conexion.GetInstance.leer(SELECTlab)

            Dim _ROW As DataRow = dt.Rows(0)

            laboratorio.IdLaboratorio = _ROW("IDLABORATORIO")
       


            Dim INSERT As String = "INSERT INTO PRODUCTO VALUES " & "('" & nombreEncriptado & "','" & descripcionEncriptado & "','" & PrecioEncriptado & "','" & stockEncriptado & "','" & laboratorio.IdLaboratorio & "')"
            DAL.Conexion.GetInstance.Escribir(INSERT)
            Dim dvs As New DAL.DV
            dvs.RECALCULARDVS()




        Catch ex As Exception
            MsgBox("Problemas con la base de datos")
        End Try

        Return alta

    End Function

    Public Function baja(obj As BE.Producto) As Boolean Implements BE.ICrud(Of BE.Producto).baja

    End Function

    Public Function listarPorId(obj As BE.Producto) As BE.Producto Implements BE.ICrud(Of BE.Producto).listarPorId

    End Function

    Public Function listarTodos() As List(Of BE.Producto) Implements BE.ICrud(Of BE.Producto).listarTodos

    End Function

    Public Function modificacion(obj As BE.Producto) As Boolean Implements BE.ICrud(Of BE.Producto).modificacion

    End Function
End Class
