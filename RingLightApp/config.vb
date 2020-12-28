Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class config

    Private DES As New TripleDESCryptoServiceProvider
    Private MD5_ As New MD5CryptoServiceProvider

    Public Shared configFile As String = "RingLight.ini"
    Public Shared fxFile As String = "RingLightFX.xml"
    Private Shared ReadOnly fullPathConfigFile As String = Application.StartupPath & "\" & configFile
    Private Shared sb As StringBuilder = New StringBuilder(500)

    Private Declare Auto Function GetPrivateProfileString Lib "kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Auto Function WritePrivateProfileString Lib "kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Boolean


    Public Shared Sub createConfigFile()
        Using writer As New StreamWriter(configFile, True)
            writer.WriteLine("[RingLight]")
            writer.WriteLine("port=COM1")
            writer.WriteLine("baud=9600")
            writer.WriteLine("effect=0")
            writer.WriteLine("bright=50")
            writer.WriteLine("trig=50")
            writer.WriteLine("delay=0")
            writer.WriteLine("play=0")
            writer.WriteLine("skip=0")
            writer.WriteLine("hide=0")
            writer.Close()
        End Using
    End Sub

    Public Shared Sub createFxFile()
        Using writer As New StreamWriter(fxFile, True)
            writer.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            writer.WriteLine("<RingLightFX version=""1.0"">")
            writer.WriteLine("  <effect>")
            writer.WriteLine("    <name>Rainbow</name>")
            writer.WriteLine("  </effect>")
            writer.WriteLine("  <effect>")
            writer.WriteLine("    <name>Theatre Chase</name>")
            writer.WriteLine("  </effect>")
            writer.WriteLine("</RingLightFX>")
            writer.Close()
        End Using
    End Sub

    Public Shared Function Read(ByVal name As String, ByVal defaultValue As String) As String
        GetPrivateProfileString("RingLight", name, defaultValue, sb, sb.Capacity, fullPathConfigFile).ToString()
        Return sb.ToString()
    End Function

    Public Shared Sub Write(ByVal name As String, ByVal value As String)
        WritePrivateProfileString("RingLight", name, value, fullPathConfigFile)
    End Sub

    Public Function Encrypt(StringInput As String, Key As String) As String
        DES.Key = MD5Hash(Key)
        DES.Mode = CipherMode.ECB
        Dim buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(StringInput)
        Return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length))
    End Function

    Public Function Decrypt(EncryptedString As String, Key As String) As String
        DES.Key = MD5Hash(Key)
        DES.Mode = CipherMode.ECB
        Dim Buffer As Byte()
        Try
            Buffer = Convert.FromBase64String(EncryptedString)
        Catch ex As Exception
            Return ""
            Exit Function
        End Try
        Try
            Return ASCIIEncoding.ASCII.GetString(DES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Private Function MD5Hash(value As String) As Byte()
        Return MD5_.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value))
    End Function

End Class
