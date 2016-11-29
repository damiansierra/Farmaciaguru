Imports System.Text

Public Class DV
    Dim parametrizaciones As New Parametrizaciones

    Public Function CALCULARDVH(CADENA As String) As Integer
        Try
            Dim DVH As String
            DVH = pasaraASCII(CADENA)
            Return DVH
        Catch ex As Exception
            Throw ex
        End Try
        

    End Function



    Public Function CALCULARDVV(CADENA As String) As Integer

    End Function

    Public Function RECALCULARDVS() As Boolean
        Try
            Dim dt As New DataTable
            Dim dtdvv As New DataTable
            Dim i As Integer = 0

            For Each tabla In parametrizaciones.tablasDV

                Dim selectDV As String = "Select * from "
                Dim selectDVV As String = "Select DVV from DV where NOMBRE="

                selectDV = selectDV & parametrizaciones.tablasDV(i)
                selectDVV = selectDVV & "'" & parametrizaciones.tablasDV(i) & "'"
                dt = DAL.Conexion.GetInstance.leer(selectDV)
                Dim columnas As Integer = dt.Columns.Count
                dtdvv = DAL.Conexion.GetInstance.leer(selectDVV)
                Dim DVV As Integer = 0

                For Each _ROW As DataRow In dt.Rows
                    Dim CANTIDADDECELDAS As Integer = dt.Columns.Count
                    Dim DVH As Integer = concatenar(_ROW, CANTIDADDECELDAS)

                    Dim IDSTRING As String = GETIDSTRING(_ROW, parametrizaciones.tablasDV(i))

                    Dim MODIFICARDVH As String = "UPDATE " & parametrizaciones.tablasDV(i) & " SET DVH = " & DVH & " WHERE " & IDSTRING
                    DAL.Conexion.GetInstance.Escribir(MODIFICARDVH)

                    DVV = DVV + DVH

                Next


                Dim MODIFICARDVV As String = "UPDATE DV SET DVV = " & DVV & " WHERE NOMBRETABLA = '" & parametrizaciones.tablasDV(i) & "'"
                DAL.Conexion.GetInstance.Escribir(MODIFICARDVV)

                i = i + 1


            Next



            Return True

        Catch ex As Exception
            Throw ex
        End Try

        Return True
    End Function


    Private Function GETIDSTRING(_ROW As DataRow, TABLA As String) As String
    
        If TABLA = "DV" Then
            Return "IDTABLA = " & _ROW(0)
        End If


        If TABLA = "FAMPAT" Then
            Return "ID_FAMILIA = " & _ROW(0) & " AND ID_PATENTE = " & _ROW(1)
        End If


        If TABLA = "USUFAM" Then
            Return "ID_USUARIO = " & _ROW(0) & " AND ID_FAMILIA = " & _ROW(1)
        End If

        If TABLA = "USUPAT" Then
            Return "ID_PATENTE = " & _ROW(0) & " AND ID_USUARIO = " & _ROW(1)
        End If


    End Function


    Public Function verificarDV() As Boolean
        Try
            Dim dt As New DataTable
            Dim dtdvv As New DataTable
            Dim i As Integer = 0
            Dim digitovertical As Integer

            For Each tabla In parametrizaciones.tablasDV

                Dim selectDV As String = "Select * from "
                Dim selectDVV As String = "Select DVV from DV where NOMBRETABLA="

                selectDV = selectDV & parametrizaciones.tablasDV(i)
                selectDVV = selectDVV & "'" & parametrizaciones.tablasDV(i) & "'"
                dt = DAL.Conexion.GetInstance.leer(selectDV)
                Dim columnas As Integer = dt.Columns.Count
                dtdvv = DAL.Conexion.GetInstance.leer(selectDVV)
                For Each _row As DataRow In dtdvv.Rows
                    digitovertical = _row("DVV")
                Next


                If comprobardvregistro(dt, digitovertical, columnas) = False Then
                    Return False
                End If

                i = i + 1


            Next



            Return True

        Catch ex As Exception
            Throw ex
        End Try

        Return True

    End Function


    Private Function comprobardvregistro(dt As DataTable, dvv As Integer, columnas As Integer) As Boolean
        Try
            Dim DVHtotal As Integer = 0
            For Each _row As DataRow In dt.Rows
                DVHtotal = DVHtotal + concatenar(_row, columnas)
            Next

            If DVHtotal = dvv Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function concatenar(_row As DataRow, columnas As Integer) As Integer

        Try
            Dim concatenado As String = ""
            Dim DVH As Integer = 0
            Dim i As Integer
            For i = 0 To (columnas - 2)
                If (Convert.ToString(_row.Item(i)) = "False" Or Convert.ToString(_row.Item(i)) = "True") Then
                    If (Convert.ToString(_row.Item(i)) = "True") Then
                        concatenado = concatenado & "1"
                    End If
                    If (Convert.ToString(_row.Item(i)) = "False") Then
                        concatenado = concatenado & "0"
                    End If
                Else
                    concatenado = concatenado & _row.Item(i)
                End If
            Next

            DVH = pasaraASCII(concatenado)

            Return DVH
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function pasaraASCII(cadena As String) As Integer

        Try
            Dim i As Integer = 0
            Dim result As Integer = 0
            Dim DVH As Integer = 0

            For i = 0 To cadena.Length - 1
                result = Convert.ToInt32(cadena(i))
                DVH = DVH + (result * (i + 1))
            Next

            Return DVH
        Catch ex As Exception
            Throw ex
        End Try


    End Function



End Class
