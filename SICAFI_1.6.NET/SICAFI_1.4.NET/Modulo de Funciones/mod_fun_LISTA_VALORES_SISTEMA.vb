Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports REGLAS_DEL_NEGOCIO

Module mod_fun_LISTA_VALORES_SISTEMA

    Public Function fun_Buscar_Lista_Valores_BOOLEAN(ByVal inSISTCODI) As Boolean

        Try
            If inSISTCODI = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_STRING(ByVal stSISTCODI) As String

        Try
            If Trim(stSISTCODI) <> "" Then
                Return stSISTCODI
            Else
                Return ""
            End If

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function

End Module
