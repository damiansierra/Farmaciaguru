Public Class Usuario
    Implements BE.ICrud(Of BE.Usuario)


    Private Shared _instancia As BLL.Usuario
    Public Shared Function GetInstance() As BLL.Usuario
        If _instancia Is Nothing Then
            _instancia = New BLL.Usuario
        End If
        Return _instancia
    End Function

    Public Function alta(obj As BE.Usuario) As Boolean Implements BE.ICrud(Of BE.Usuario).alta
        Return DAL.Usuario.GetInstance.alta(obj)
    End Function

    Public Function baja(obj As BE.Usuario) As Boolean Implements BE.ICrud(Of BE.Usuario).baja

        Try

            Dim dalservicios As New DAL.SERVICIOS

            Dim bandera As Boolean = dalservicios.verificaralborrarusuario(obj)
            If bandera = False Then
                Return False
            End If


            Dim DALUSUARIO As New DAL.Usuario
            Return DALUSUARIO.baja(obj)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function listarPorId(obj As BE.Usuario) As BE.Usuario Implements BE.ICrud(Of BE.Usuario).listarPorId
        Return DAL.Usuario.GetInstance.listarPorId(obj)
    End Function

    Public Function listarTodos() As List(Of BE.Usuario) Implements BE.ICrud(Of BE.Usuario).listarTodos

        Try
            Dim DALUSUARIO As New DAL.Usuario
            Return DALUSUARIO.listarTodos
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function modificacion(obj As BE.Usuario) As Boolean Implements BE.ICrud(Of BE.Usuario).modificacion

        Try
            Dim dalservicios As New DAL.SERVICIOS
            If dalservicios.checkborradousuarios(obj) = True Then
                Dim DALUSUARIO As New DAL.Usuario
                Return DALUSUARIO.modificacion(obj)
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function
End Class
