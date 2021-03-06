﻿Public Class Familia
    Implements BE.ICrud(Of BE.Familia)

    Private Shared _instancia As BLL.Familia
    Public Shared Function GetInstance() As BLL.Familia
        If _instancia Is Nothing Then
            _instancia = New BLL.Familia
        End If
        Return _instancia
    End Function

    Public Function alta(obj As BE.Familia) As Boolean Implements BE.ICrud(Of BE.Familia).alta
        Return DAL.Familia.GetInstance.alta(obj)
    End Function

    Public Function baja(obj As BE.Familia) As Boolean Implements BE.ICrud(Of BE.Familia).baja
        Try

            Dim DALFAMILIA As New DAL.Familia

            Return DALFAMILIA.baja(obj)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function listarPorId(obj As BE.Familia) As BE.Familia Implements BE.ICrud(Of BE.Familia).listarPorId
        Return DAL.Familia.GetInstance.listarPorId(obj)
    End Function

    Public Function listarTodos() As List(Of BE.Familia) Implements BE.ICrud(Of BE.Familia).listarTodos
        Try
            Dim DALFAMILIA As New DAL.Familia
            Return DALFAMILIA.listarTodos
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function modificacion(obj As BE.Familia) As Boolean Implements BE.ICrud(Of BE.Familia).modificacion

        Try


          

            Return DAL.Familia.GetInstance.modificacion(obj)

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ValidarEliminarFamiliaUsuario(ByVal FamiliaBE As BE.Familia, ByVal UsuarioBE As BE.Usuario) As Boolean
        Try
            Return DAL.Familia.GetInstance.ValidarEliminarFamiliaUsuario(FamiliaBE, UsuarioBE)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarEliminarFamilia(ByVal FamiliaBE As BE.Familia) As Boolean
        Try
            Return DAL.Familia.GetInstance.ValidarEliminarFamilia(FamiliaBE)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarEliminarFamiliaPatente(ByVal FamiliaBE As BE.Familia, ByVal PatenteBE As BE.Patente) As Boolean
        Try
            Return DAL.Familia.GetInstance.ValidarEliminarFamiliaPatente(FamiliaBE, PatenteBE)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class

