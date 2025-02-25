Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports REGLAS_DEL_NEGOCIO

Module mod_pro_LISTA_VALORES_FICHA_PREDIAL

    Public Sub pro_Buscar_Lista_Valores_MUNICIPIO(ByVal stMUNICIPIO As String, ByRef lv_stMUNICIPIO As String)

        Try
            Dim objdatos2 As New cla_DEPARTAMENTO
            Dim tbl As New DataTable

            tbl = objdatos2.fun_Buscar_CODIGO_MANT_DEPARTAMENTO(stMUNICIPIO)

            Dim sw, j As Integer

            While j < tbl.Rows.Count And sw = 0
                If stMUNICIPIO = tbl.Rows(j).Item("DEPACODI") Then
                    lv_stMUNICIPIO = tbl.Rows(j).Item("DEPADESC")
                    sw = 1
                Else
                    j = j + 1
                End If
            End While

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

  

End Module
