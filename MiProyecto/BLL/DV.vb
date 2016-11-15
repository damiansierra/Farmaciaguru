Public Class DV
    Dim DALDV As New DAL.DV

    Public Function verificarDV() As Boolean
        Try
            If DALDV.verificarDV = False Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CALCULARDV(CADENA As String) As Integer
        Dim DALDV As New DAL.DV
        Dim DIGITO As Integer = DALDV.pasaraASCII(CADENA)
        Return DIGITO
    End Function

    Public Function RECALCULARDVS() As Boolean
        Try
            If DALDV.RECALCULARDVS() = False Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
