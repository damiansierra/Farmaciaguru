Public Class PatenteDALL
    Implements BE.ICrud(Of BE.Patente)

    Private Shared _instancia As DAL.PatenteDALL

    Public Shared Function GetInstance() As DAL.PatenteDALL

        If _instancia Is Nothing Then

            _instancia = New DAL.PatenteDALL

        End If
        Return _instancia
    End Function


    Public Function alta(obj As BE.Patente) As Boolean Implements BE.ICrud(Of BE.Patente).alta

    End Function

    Public Function baja(obj As BE.Patente) As Boolean Implements BE.ICrud(Of BE.Patente).baja

    End Function

    Public Function listarPorId(obj As BE.Patente) As BE.Patente Implements BE.ICrud(Of BE.Patente).listarPorId

    End Function

    Public Function listarTodos() As List(Of BE.Patente) Implements BE.ICrud(Of BE.Patente).listarTodos
        Try
            Dim dt As New DataTable

            Dim SELECTPAT As String = "SELECT * FROM patente"
            dt = DAL.Conexion.GetInstance.leer(SELECTPAT)

            Dim LISTADEPATENTES As New List(Of BE.Patente)
            For Each _ROW In dt.Rows
                LISTADEPATENTES.Add(New BE.Patente With {.Idpatente = _ROW("IdPatente"), .Nombre = _ROW("Nombre")})
            Next

            Return LISTADEPATENTES
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function modificacion(obj As BE.Patente) As Boolean Implements BE.ICrud(Of BE.Patente).modificacion

    End Function
End Class
