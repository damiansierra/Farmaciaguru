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
        Dim nombreEncriptado As String = Trim(Seguridad.EncriptarReversible(obj.Nombre))

       
        Try

            Dim parameters As New Dictionary(Of String, Object)

            Dim laboratorio As New BE.Laboratorio
            Dim dt As New DataTable


            Dim SELECTlab As String = "SELECT * FROM LABORATORIO WHERE nombre = '" & obj.laboratorio.Nombre & "'"
            dt = DAL.Conexion.GetInstance.leer(SELECTlab)

            Dim _ROW As DataRow = dt.Rows(0)

            laboratorio.IdLaboratorio = _ROW("IDLABORATORIO")
       


            Dim INSERT As String = "INSERT INTO PRODUCTO VALUES " & "('" & nombreEncriptado & "','" & descripcionEncriptado & "','" & PrecioEncriptado & "','" & obj.stock & "','" & laboratorio.IdLaboratorio & "')"
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
        Try

            Dim productobe As New BE.Producto
            Dim dt As New DataTable


            Dim PRODUCTOOENCRIPTADO As String = Seguridad.EncriptarReversible(obj.Nombre)
            Dim SELECTPROD As String = "SELECT * FROM PRODUCTO WHERE NOMBRE = '" & PRODUCTOOENCRIPTADO & "'"
            dt = DAL.Conexion.GetInstance.leer(SELECTPROD)

            Dim _ROW As DataRow = dt.Rows(0)

            productobe.IdProducto = _ROW("IDPRODUCTO")
            productobe.Nombre = obj.Nombre
            productobe.Descripcion = Seguridad.DesEncriptar(_ROW("DESCRIPCION"))
            productobe.Precio_Actual = Seguridad.DesEncriptar(_ROW("PRECIO_ACTUAL"))
            productobe.stock = _ROW("STOCK")
            Dim labo As Integer = _ROW("IDLABORATORIO")

            Dim dt2 As New DataTable
            Dim SELECTlab As String = "SELECT IDLABORATORIO , NOMBRE, direccion , TELEFONO FROM LABORATORIO where  IDLABORATORIO = " & labo
            dt2 = DAL.Conexion.GetInstance.leer(SELECTlab)

            Dim _ROW2 As DataRow = dt2.Rows(0)
            Dim LAB As New BE.Laboratorio

            LAB.IdLaboratorio = _ROW2("IDLABORATORIO")
            LAB.Nombre = _ROW2("NOMBRE")
            LAB.Direccion = _ROW2("direccion")
            LAB.telefono = _ROW2("TELEFONO")

            productobe.laboratorio = LAB


            Return productobe

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function listarTodos() As List(Of BE.Producto) Implements BE.ICrud(Of BE.Producto).listarTodos
      
        Try
            Dim dt As New DataTable

            Dim SELECTFAM As String = "SELECT * FROM PRODUCTO where stock > 0"
            dt = DAL.Conexion.GetInstance.leer(SELECTFAM)

            Dim DALSEGURIDAD As New DAL.Seguridad
            Dim LISTAPRODUCTOS As New List(Of BE.Producto)
            Dim producto As New BE.Producto
            Dim laboratorio As New BE.Laboratorio

            For Each _ROW In dt.Rows
                laboratorio.IdLaboratorio = _ROW("IDLABORATORIO")
                LISTAPRODUCTOS.Add(New BE.Producto With {.IdProducto = _ROW("IDPRODUCTO"), .Nombre = DAL.Seguridad.DesEncriptar(_ROW("Nombre")), .Descripcion = DAL.Seguridad.DesEncriptar(_ROW("DESCRIPCION")), .Precio_Actual = DAL.Seguridad.DesEncriptar(_ROW("PRECIO_ACTUAL")), .stock = _ROW("STOCK"), .laboratorio = laboratorio})
            Next

            Return LISTAPRODUCTOS
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function modificacion(obj As BE.Producto) As Boolean Implements BE.ICrud(Of BE.Producto).modificacion

    End Function
End Class
