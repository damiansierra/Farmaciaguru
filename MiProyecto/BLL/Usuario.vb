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

            '    Dim bandera As Boolean = dalservicios.verificaralborrarusuario(obj)
            '    If bandera = False Then
            'Return False
            '     End If


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
            'If dalservicios.checkborradousuarios(obj) = True Then
            Dim DALUSUARIO As New DAL.Usuario
            Return DALUSUARIO.modificacion(obj)
            '   End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function LOGIN(USUARIO As BE.Usuario) As Integer
        Try
            Dim DALUSUARIO As New DAL.USUARIO
            Dim LOGUEA As Integer = DALUSUARIO.LOGIN(USUARIO)
            Dim DALBITACORA As New DAL.BITACORA

            Dim BITACORA As New BE.BITACORA
            BITACORA.nick = USUARIO.Nick
            Dim INTENTO As String = ""


            'LOGUEA = 0 USER Y PASS INCORRECTOS RETORNO 0 Y NO INGRESA A LA APP
            'LOGUEA = 1 USER CORRECTO PERO NO PUEDE CALCULAR DV
            'LOGUEA = 2 USUARIO O CONTRASEÑA INCORRECTOS
            'LOGUEA = 3 USUARIO CORRECTO Y PUEDE CALCULAR DV
            'LOGUEA = 4 USUARIO BLOQUEADO


            If LOGUEA > 0 Then



                Dim user As New BE.Usuario
                user = listarPorId(USUARIO)

                If LOGUEA = 2 Then
                    ''''''''' LA CONTRASEÑA FUE INGRESADA INCORRECTAMENTE , AGREGO UN INTENTO DE LOGUIN AL USUARIO SI ES QUE ESTE NO ES EL ULTIMO CON POSIBILIDAD DE DESBLOQUEAR USUARIOS

                    ''''' PRIMERO CORROBORO QUE NO SEA EL ULTIMO USUARIO CON PERMISOS PARA RESETEAR PASSWORDS
                    Dim DALSERVICIOS As New DAL.SERVICIOS

                    If DALSERVICIOS.VERIFICARULTIMOUSUARIOCONPERMISOSDEDERESET(user) = True Then
                        DALUSUARIO.AGREGARINTENTODEBLOQUEO(user)

                        ''''''''''''SI TENIA MAS DE 2 INTENTOS DE LOGIN FALLIDOS ENTONCES DEVUELVO 4 QUE ES EL CODIGO DE USUARIO BLOQUEADO
                        If user.Cant_Int > 2 Then
                            LOGUEA = 4
                        End If
                    Else
                        LOGUEA = 2
                    End If



                    '''''''



                End If


                If LOGUEA = 1 Then
                    '''''''''' COMPRUEBO SI EL USUARIO QUE SE ESTA LOGUEANDO TIENE PERMISOS PARA RECALCULAR DIGITOS VERIFICADORES
                    For Each pat As BE.PATENTE In user.PATENTES
                        If pat.Idpatente = 1 And pat.NEGADO = False Then
                            LOGUEA = 3
                        End If
                    Next

                    Dim dalfamilia As New DAL.FAMILIA
                    For Each fam As BE.Familia In user.Familias
                        fam = dalfamilia.listarPorId(fam)
                        '          If fam.Patente = False Then
                        For Each patente As BE.Patente In fam.Patente
                            If patente.Idpatente = 1 Then
                                LOGUEA = 3
                            End If
                        Next
                        ' End If
                    Next


                    '''''''''''''''''
                    If user.Cant_Int > 3 Then
                        LOGUEA = 4
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If






            End If

            If LOGUEA = 1 Or LOGUEA = 3 Then
                INTENTO = "SATISFACTORIO"
            End If

            If LOGUEA = 2 Or LOGUEA = 4 Then
                INTENTO = "NO SATISFACTORIO"
            End If


            BITACORA.Criticidad = "BAJA"
            BITACORA.Descripcion = "INTENTO " & INTENTO & " DE LOGUEO DEL USUARIO " & BITACORA.nick
            DALBITACORA.alta(BITACORA)

            Return LOGUEA
        Catch ex As Exception
            Throw ex
        End Try


    End Function
End Class
