Imports System.IO
'Imports Ionic.Zip


Public Class SERVICIOS
    Public Function checkborradousuarios(objeto As BE.Usuario) As Boolean

        Try


            Dim USUARIOS As New List(Of BE.Usuario)
            Dim dt As New DataTable
            Dim i As Integer = 0
            Dim DALSEGURIDAD As New DAL.Seguridad
            Dim bandera As Boolean = False
            Dim VECTORCONFIRMACION(5) As Boolean


            Dim USUARIO As New BE.Usuario
            Dim dt150 As New DataTable

            Dim USUARIOENCRIPTADO As String = Seguridad.EncriptarReversible(objeto.Nick)
            Dim SELECTUSER As String = "SELECT * FROM USUARIO WHERE Nick = '" & USUARIOENCRIPTADO & "'"
            dt150 = DAL.Conexion.GetInstance.leer(SELECTUSER)

            Dim _ROW30 As DataRow = dt150.Rows(0)

            USUARIO.IdUsuario = _ROW30("IDUSUARIO")
            USUARIO.Apellido = _ROW30("APELLIDO")
            USUARIO.Nick = objeto.Nick
            USUARIO.Nombre = _ROW30("NOMBRE")
            USUARIO.Cant_Int = _ROW30("CANT_INT")





            For i = 1 To 5
                bandera = False
                Dim cantidadusuariospatente As Integer = DAL.Conexion.GetInstance.leerINT("select count(IDUSUARIO) from usupat where IDPATENTE= " & i & " AND NEGADO = 0")
                If cantidadusuariospatente < 2 Then

                    Dim SELECTALL As String = "select IDUSUARIO from usupat where IDPATENTE=" & i & " AND NEGADO = 0"
                    dt = DAL.Conexion.GetInstance.leer(SELECTALL)
                    If dt.Rows.Count > 1 Then
                        bandera = True
                    End If
                    If dt.Rows.Count = 1 Then
                        For Each _ROW As DataRow In dt.Rows
                            If _ROW(0) = objeto.IdUsuario Then
                                For Each pat As BE.Patente In objeto.Patentes
                                    If pat.Idpatente = i And pat.NEGADO = False Then
                                        bandera = True
                                    End If
                                Next
                            Else
                                bandera = True
                            End If

                            If bandera = False And _ROW(0) = objeto.IdUsuario Then
                                ''''''ME FIJO SI ENCUENTRO LA PATENTE EN ALGUNA FAMILIA
                                Dim dt7 As DataTable = DAL.Conexion.GetInstance.leer("select IDFAMILIA FROM FAMPAT WHERE IDPATENTE= " & i)
                                For Each _ROW5 As DataRow In dt7.Rows
                                    Dim FAM As Integer = _ROW5.Item(0)
                                    Dim dt8 As DataTable = DAL.Conexion.GetInstance.leer("select IDUSUARIO FROM USUFAM WHERE IDFAMILIA = " & FAM & "")
                                    If dt8.Rows.Count > 1 Then
                                        bandera = True
                                    End If
                                    If dt8.Rows.Count = 1 Then
                                        If dt8.Rows(0).Item(0) <> objeto.IdUsuario Then
                                            bandera = True
                                        Else
                                            Dim dt9 As DataTable = DAL.Conexion.GetInstance.leer("select UF.IDUSUARIO FROM FAMPAT AS FP JOIN USUFAM AS UF ON FP.IDFAMILIA=UF.IDFAMILIA WHERE IDPATENTE = " & i & "") ''''  AND ID_USUARIO <> " & objeto.ID_USUARIO & "
                                            If dt9.Rows.Count > 0 Then
                                                bandera = True
                                            End If

                                            Dim dt10 As DataTable = DAL.Conexion.GetInstance.leer("SELECT IDUSUARIO FROM USUPAT WHERE IDPATENTE = " & i & " AND IDUSUARIO <> " & objeto.IdUsuario & " AND NEGADO = 0")
                                            If dt10.Rows.Count > 0 Then
                                                bandera = True
                                            End If



                                            Dim BANDERAPATENTEBORRADA As Boolean = False
                                            For Each PAT As BE.Patente In objeto.Patentes
                                                If PAT.Idpatente = i And PAT.NEGADO = True Then
                                                    BANDERAPATENTEBORRADA = True
                                                End If
                                            Next
                                            If dt9.Rows.Count = 0 And BANDERAPATENTEBORRADA = True Then
                                                Return False
                                            End If

                                            For Each FAMILIAS As BE.Familia In objeto.Familias
                                                If FAMILIAS.IdFamilia = FAM And BANDERAPATENTEBORRADA = True Then
                                                    bandera = True
                                                End If
                                                If FAMILIAS.IdFamilia = FAM And bandera = False Then
                                                    Return False
                                                End If
                                            Next
                                        End If
                                    End If
                                Next


                            End If




                        Next
                    End If
                    If dt.Rows.Count = 0 Then
                        For Each pat As BE.Patente In objeto.Patentes
                            If pat.Idpatente = i And pat.NEGADO = False Then
                                bandera = True
                            End If
                        Next
                    End If


                    ''''''''''''''''''''''''''''''''''
                    Dim dt67 As DataTable = DAL.Conexion.GetInstance.leer("select IDFAMILIA FROM FAMPAT WHERE IDPATENTE= " & i)
                    For Each _ROW5 As DataRow In dt67.Rows
                        Dim FAM As Integer = _ROW5.Item(0)
                        Dim dt8 As DataTable = DAL.Conexion.GetInstance.leer("select IDUSUARIO FROM USUFAM WHERE IDFAMILIA = " & FAM & "")
                        If dt8.Rows.Count > 1 Then
                            bandera = True
                        End If
                        If dt8.Rows.Count = 1 Then
                            If dt8.Rows(0).Item(0) <> objeto.IdUsuario Then
                                bandera = True
                            Else
                                Dim dt9 As DataTable = DAL.Conexion.GetInstance.leer("select UF.IDUSUARIO FROM FAMPAT AS FP JOIN USUFAM AS UF ON FP.IDFAMILIA=UF.IDFAMILIA WHERE IDPATENTE = " & i & " AND ID_USUARIO <> " & objeto.IdUsuario & " ") ''''
                                If dt9.Rows.Count > 0 Then
                                    bandera = True
                                End If

                                Dim dt10 As DataTable = DAL.Conexion.GetInstance.leer("SELECT IDUSUARIO FROM USUPAT WHERE ID_PATENTE = " & i & " AND IDUSUARIO <> " & objeto.IdUsuario & " AND NEGADO = 0")
                                If dt10.Rows.Count > 0 Then
                                    bandera = True
                                End If



                                Dim BANDERAPATENTEBORRADA As Boolean = False
                                For Each PAT As BE.Patente In objeto.Patentes
                                    If PAT.Idpatente = i And PAT.NEGADO = True Then
                                        BANDERAPATENTEBORRADA = True
                                    End If
                                Next
                                If dt9.Rows.Count = 0 And BANDERAPATENTEBORRADA = True Then
                                    Return False
                                End If

                                For Each FAMILIAS As BE.Familia In objeto.Familias
                                    If FAMILIAS.IdFamilia = FAM And BANDERAPATENTEBORRADA = True Then
                                        bandera = True
                                    End If
                                    If FAMILIAS.IdFamilia = FAM And bandera = False Then
                                        Return False
                                    End If
                                Next
                            End If
                        End If
                    Next




                Else
                    bandera = True
                End If






                If bandera = False Then
                    Return bandera
                    'VECTORCONFIRMACION(i) = False
                Else
                    VECTORCONFIRMACION(i) = True
                End If

            Next







            bandera = False

            For Each FAM As BE.Familia In objeto.Familias
                '       If FAM.NEGADO = True Then
                Dim dt11 As DataTable = DAL.Conexion.GetInstance.leer("SELECT IDUSUARIO FROM USUFAM WHERE IDFAMILIA = " & FAM.IdFamilia & " AND IDUSUARIO <> " & objeto.IdUsuario & " ")
                If dt11.Rows.Count > 0 Then
                    bandera = True
                End If

                Dim dt12 As DataTable = DAL.Conexion.GetInstance.leer("SELECT IDPATENTE FROM FAMPAT WHERE ID_FAMILIA = " & FAM.IdFamilia)
                For Each _ROW As DataRow In dt12.Rows
                    Dim dt13 As DataTable = DAL.Conexion.GetInstance.leer("select IDUSUARIO FROM USUPAT WHERE IDPATENTE = " & _ROW.Item(0) & " AND ID_USUARIO <> " & objeto.IdUsuario & " AND NEGADO = 0")
                    Dim dt14 As DataTable = DAL.Conexion.GetInstance.leer("select IDFAMILIA FROM FAMPAT WHERE IDPATENTE = " & _ROW.Item(0))
                    For Each _FAM As DataRow In dt14.Rows
                        Dim dt15 As DataTable = DAL.Conexion.GetInstance.leer("select IDUSUARIO FROM USUFAM WHERE IDFAMILIA = " & _FAM.Item(0) & "")
                        If dt13.Rows.Count > 0 And dt14.Rows.Count > 0 Then
                            bandera = True
                        End If
                    Next


                Next
                '        Else
                '       bandera = True
                '   End If

                If bandera = False Then
                    Return bandera
                End If

            Next







            bandera = False


            Dim FAMILIASDELUSUARIO As String = "select IDFAMILIA from usufam where IDUSUARIO= " & objeto.IdUsuario
            Dim dt2 As DataTable = DAL.Conexion.GetInstance.leer(FAMILIASDELUSUARIO)

            If dt2.Rows.Count = 0 Then
                bandera = True
            Else
                For Each _ROW As DataRow In dt2.Rows
                    Dim FAM As New BE.Familia With {.IdFamilia = _ROW(0)}

                    Dim FAMILIAUSUARIOS As String = "select IDUSUARIO from usufam where IDFAMILIA= " & FAM.IdFamilia
                    Dim dt3 As DataTable = DAL.Conexion.GetInstance.leer(FAMILIAUSUARIOS)

                    If dt3.Rows.Count = 1 And dt3.Rows(0).Item(0) = objeto.IdUsuario Then

                        Dim FAMILIAPATENTES As String = "select IDPATENTE from FAMPAT where IDFAMILIA= " & FAM.IdFamilia
                        Dim dt4 As DataTable = DAL.Conexion.GetInstance.leer(FAMILIAPATENTES)
                        Dim J As Integer
                        For Each _ROW2 As DataRow In dt4.Rows
                            For J = 1 To 5
                                If VECTORCONFIRMACION(J) = True Then
                                    bandera = True
                                End If

                                If dt4.Rows(0).Item(0) = J Then

                                    Dim PATENTEFAMILIA As String = "select IDFAMILIA from FAMPAT where (IDPATENTE= " & J & " AND IDFAMILIA <> " & FAM.IdFamilia & ")"
                                    Dim dt5 As DataTable = DAL.Conexion.GetInstance.leer(PATENTEFAMILIA)

                                    For Each _ROW3 As DataRow In dt5.Rows
                                        Dim FAM2 As Integer = _ROW3.Item(0)
                                        Dim FAMILIAUSUARIO As String = "select IDUSUARIO from USUFAM where ID_FAMILIA= " & FAM2
                                        Dim dt6 As DataTable = DAL.Conexion.GetInstance.leer(FAMILIAUSUARIO)

                                        For Each _ROW4 As DataRow In dt6.Rows
                                            If _ROW4.Item(1) = False Then
                                                bandera = True
                                            End If
                                        Next
                                    Next
                                End If

                                Dim patenteUSUARIO As String = "select IDUSUARIO, NEGADO from USUPAT where IDPATENTE= " & J
                                Dim dt7 As DataTable = DAL.Conexion.GetInstance.leer(patenteUSUARIO)
                                For Each _ROW5 As DataRow In dt7.Rows
                                    If _ROW5.Item(1) = False Then
                                        bandera = True
                                    End If
                                Next
                                If bandera = False Then
                                    Return bandera
                                End If
                            Next
                        Next

                    Else
                        bandera = True
                    End If
                Next
            End If




            '''''' Retorna true si se puede borrar
            Return bandera

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function VERIFICARULTIMOUSUARIOCONPERMISOSDEDERESET(OBJETO As BE.Usuario) As Boolean
        Try
            Dim DTUSUARIOPATENTE As DataTable = DAL.Conexion.GetInstance.leer("select US.IDUSUARIO from usupat AS UP JOIN USUARIO AS US ON UP.IDUSUARIO = US.IDUSUARIO where UP.IDPATENTE= 2 AND UP.NEGADO = 0 AND US.CANT_INT < 3 AND US.IDUSUARIO <> " & OBJETO.IdUsuario)
            If DTUSUARIOPATENTE.Rows.Count > 0 Then
                Return True
            End If

            Dim DTUSUARIOFAMILIAPATENTE As DataTable = DAL.Conexion.GetInstance.leer("Select US.IDUSUARIO from FAMPAT AS FP JOIN USUFAM AS UF ON FP.IDFAMILIA=UF.IDFAMILIA JOIN USUARIO AS US ON UF.IDUSUARIO=US.IDUSUARIO WHERE FP.IDPATENTE = 2 And US.CANT_INT < 3 AND US.ID_USUARIO <> " & OBJETO.IdUsuario)
            If DTUSUARIOFAMILIAPATENTE.Rows.Count > 0 Then
                Return True
            End If

            Return False
        Catch ex As Exception
            Throw ex
        End Try

        

    End Function


  



    Public Function verificaralborrarusuario(objeto As BE.Usuario) As Boolean
        Try
            Dim bandera = True

            





            Return bandera



        Catch ex As Exception
            Throw ex
        End Try



    End Function


    Public Function verificaralborrarFAMILIA(OBJETO As BE.FAMILIA) As Boolean
        Try
            Dim bandera = True

      

            Return bandera



        Catch ex As Exception
            Throw ex
        End Try



    End Function




End Class
