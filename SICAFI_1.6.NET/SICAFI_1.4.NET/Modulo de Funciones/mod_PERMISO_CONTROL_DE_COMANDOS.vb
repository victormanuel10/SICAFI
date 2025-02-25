Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports REGLAS_DEL_NEGOCIO

Module mod_PERMISO_CONTROL_DE_COMANDOS

    ''' <summary>
    ''' Configura los botones del control de comando para las exportaciones y barras de menu
    ''' </summary>
    Public Function fun_PermisoControlDeComandos(ByVal stNombreUsuario As String, ByVal stNombreFormulario As String, ByVal stNombreBotonComando As String) As Boolean

        Try
            If Trim(stNombreUsuario) = "ADMINISTRADOR" Then
                Return True
            Else
                ' instancia la clase
                Dim obPERMCOCO As New cla_PERMCOCO
                Dim dtPERMCOCO As New DataTable

                dtPERMCOCO = obPERMCOCO.fun_Buscar_CODIGO_X_PERMCOCO(Trim(stNombreUsuario), Trim(stNombreFormulario), Trim(stNombreBotonComando))

                If dtPERMCOCO.Rows.Count = 0 Then
                    Return False
                Else
                    If CBool(dtPERMCOCO.Rows(0).Item("PECCHABI")) = True Then
                        Return True
                    Else
                        If CBool(dtPERMCOCO.Rows(0).Item("PECCDESH")) = True Then
                            Return False
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function


End Module
