Option Explicit On
Option Strict On

Imports System.Text
Imports System.Security.Cryptography
Imports System.IO

Public Class Seguridad

    Private Const key As String = "Pa$$word"


    ''' <summary>
    ''' Utiliza la libreria Rijndael para realizar un desencriptado
    ''' </summary>
    ''' <param name="pPalabraEncriptada"> Palabra ya encriptada por el mismo metodo de desencriptación </param>
    ''' <returns> Palabra desencriptada </returns>
    ''' <remarks></remarks>
    Public Shared Function DesEncriptar(ByVal pPalabraEncriptada As String) As String

        Dim bytesADescencriptar As Byte() = Convert.FromBase64String(pPalabraEncriptada)
        Dim passwordBytes As Byte() = Encoding.UTF8.GetBytes(key)
        passwordBytes = SHA256.Create().ComputeHash(passwordBytes)

        Dim saltBytes As Byte() = New Byte() {1, 2, 3, 4, 5, 6, 7, 8}
        Dim bytesDescencriptados As Byte()

        Using ms As New MemoryStream()

            Using aes As New RijndaelManaged()
                aes.KeySize = 256
                aes.BlockSize = 128

                Dim key As New Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000)
                aes.Key = key.GetBytes(CInt(aes.KeySize / 8))
                aes.IV = key.GetBytes(CInt(aes.BlockSize / 8))
                aes.Mode = CipherMode.CBC

                Using cs As New CryptoStream(ms, aes.CreateDecryptor, CryptoStreamMode.Write)
                    cs.Write(bytesADescencriptar, 0, bytesADescencriptar.Length)
                    cs.Close()
                End Using

                bytesDescencriptados = ms.ToArray()
            End Using

        End Using

        Dim palabraDesencriptada As String = Encoding.UTF8.GetString(bytesDescencriptados)
        Return palabraDesencriptada
    End Function


    ''' <summary>
    ''' Utiliza la libreria MD5 para encriptar de forma irrevesible una palabra retornando la misma
    ''' </summary>
    ''' <param name="pPalabra"> Palabra a ser encriptada</param>
    ''' <returns> Palabra encriptada mediante el algoritmo md5 </returns>
    ''' <remarks></remarks>
    Public Shared Function EncriptarIrreversible(ByVal pPalabra As String) As String
        Dim md5Hasher As New MD5CryptoServiceProvider()
        Dim bytesHashed As Byte()
        Dim encoder As New UTF8Encoding()

        bytesHashed = md5Hasher.ComputeHash(encoder.GetBytes(pPalabra))

        Dim palabraEncriptada As String = encoder.GetString(bytesHashed)
        Return palabraEncriptada
    End Function

    ''' <summary>
    ''' Utiliza la libreria Rijndael para realizar un encriptado reversible
    ''' </summary>
    ''' <param name="pPalabra"> palabra a ser encriptada</param>
    ''' <returns> Palabra encriptada de manera reversible </returns>
    ''' <remarks></remarks>
    Public Shared Function EncriptarReversible(ByVal pPalabra As String) As String

        Dim bytesAEncriptar As Byte() = Encoding.UTF8.GetBytes(pPalabra)
        Dim passwordBytes As Byte() = Encoding.UTF8.GetBytes(key)

        passwordBytes = SHA256.Create().ComputeHash(passwordBytes)

        Dim bytesEncriptados As Byte()
        Dim saltBytes As Byte() = New Byte() {1, 2, 3, 4, 5, 6, 7, 8}

        Using ms As New MemoryStream

            Using aes As New RijndaelManaged
                aes.KeySize = 256
                aes.BlockSize = 128

                Dim key As Rfc2898DeriveBytes = New Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000)
                aes.Key = key.GetBytes(CInt(aes.KeySize / 8))
                aes.IV = key.GetBytes(CInt(aes.BlockSize / 8))
                aes.Mode = CipherMode.CBC

                Using cs As New CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(bytesAEncriptar, 0, bytesAEncriptar.Length)
                    cs.Close()
                End Using

                bytesEncriptados = ms.ToArray()

            End Using

        End Using

        Dim palabraEncriptada As String = Convert.ToBase64String(bytesEncriptados)
        Return palabraEncriptada

    End Function


End Class

