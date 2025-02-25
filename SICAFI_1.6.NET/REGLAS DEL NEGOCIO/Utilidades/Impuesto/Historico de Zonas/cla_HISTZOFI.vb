Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_HISTZOFI

    '=======================================
    '*** CLASE HISTORICO DE ZONAS FISICA ***
    '=======================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_HISTZOFI(ByVal obHIZFNUFI As Object, _
                                                         ByVal obHIZFDEPA As Object, _
                                                         ByVal obHIZFMUNI As Object, _
                                                         ByVal obHIZFCLSE As Object, _
                                                         ByVal obHIZFVIGE As Object, _
                                                         ByVal obHIZFZOFI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obHIZFNUFI.Text) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obHIZFDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obHIZFMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obHIZFCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obHIZFVIGE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obHIZFZOFI.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obHIZFNUFI.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obHIZFDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obHIZFMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obHIZFCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obHIZFVIGE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obHIZFZOFI.SelectedValue) = True Then

                    Dim objdatos1 As New cla_HISTZOFI
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_NUFI_DEPA_MUNI_CLSE_VIGE_ZONA_X_HISTZOFI(obHIZFNUFI.Text, _
                                                                                          obHIZFDEPA.SelectedValue, _
                                                                                          obHIZFMUNI.SelectedValue, _
                                                                                          obHIZFCLSE.SelectedValue, _
                                                                                          obHIZFVIGE.SelectedValue, _
                                                                                          obHIZFZOFI.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obHIZFDEPA.Text) & " - " & _
                                                     Trim(obHIZFMUNI.Text) & " - " & _
                                                     Trim(obHIZFCLSE.Text) & " - " & _
                                                     Trim(obHIZFVIGE.Text) & " - " & _
                                                     Trim(obHIZFZOFI.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obHIZFDEPA.Focus()
                        boRespuesta = False
                    Else
                        boRespuesta = True
                    End If

                End If
            End If

            Return boRespuesta

        Catch ex As Exception
            Return False
        End Try

    End Function


    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_HISTZOFI(ByVal inHIZFNUFI As Integer, _
                                          ByVal stHIZFDEPA As String, _
                                          ByVal stHIZFMUNI As String, _
                                          ByVal stHIZFCORR As String, _
                                          ByVal stHIZFBARR As String, _
                                          ByVal stHIZFMANZ As String, _
                                          ByVal stHIZFPRED As String, _
                                          ByVal stHIZFEDIF As String, _
                                          ByVal stHIZFUNPR As String, _
                                          ByVal inHIZFTIFI As Integer, _
                                          ByVal inHIZFCLSE As Integer, _
                                          ByVal inHIZFVIGE As Integer, _
                                          ByVal inHIZFZOFI As Integer, _
                                          ByVal inHIZFPORC As Integer, _
                                          ByVal stHIZFESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "HISTZOFI "

            stConsultaSQL += "( "
            stConsultaSQL += "HIZFNUFI, "
            stConsultaSQL += "HIZFDEPA, "
            stConsultaSQL += "HIZFMUNI, "
            stConsultaSQL += "HIZFCORR, "
            stConsultaSQL += "HIZFBARR, "
            stConsultaSQL += "HIZFMANZ, "
            stConsultaSQL += "HIZFPRED, "
            stConsultaSQL += "HIZFEDIF, "
            stConsultaSQL += "HIZFUNPR, "
            stConsultaSQL += "HIZFTIFI, "
            stConsultaSQL += "HIZFCLSE, "
            stConsultaSQL += "HIZFVIGE, "
            stConsultaSQL += "HIZFZOFI, "
            stConsultaSQL += "HIZFPORC, "
            stConsultaSQL += "HIZFESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inHIZFNUFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIZFDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIZFMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIZFCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIZFBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIZFMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIZFPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIZFEDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIZFUNPR)) & "', "
            stConsultaSQL += "'" & CInt(inHIZFTIFI) & "', "
            stConsultaSQL += "'" & CInt(inHIZFCLSE) & "', "
            stConsultaSQL += "'" & CInt(inHIZFVIGE) & "', "
            stConsultaSQL += "'" & CInt(inHIZFZOFI) & "', "
            stConsultaSQL += "'" & CInt(inHIZFPORC) & "', "
            stConsultaSQL += "'" & CStr(Trim(stHIZFESTA)) & "' "
            stConsultaSQL += ") "

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Insertar_HISTZOFI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_HISTZOFI(ByVal inHIZFIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "HISTZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZFIDRE = '" & CInt(inHIZFIDRE) & "' "

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_HISTZOFI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro con el numero de ficha.
    ''' </summary>
    Public Function fun_Eliminar_NUFI_X_HISTZOFI(ByVal inHIZFNUFI As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "HISTZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZFNUFI = '" & CInt(inHIZFNUFI) & "' "

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_HISTZOFI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro con el numero de ficha.
    ''' </summary>
    Public Function fun_Eliminar_NUFI_CLSE_VIGE_X_HISTZOFI(ByVal inHIZFNUFI As Integer, ByVal inHIZFCLSE As Integer, ByVal inHIZFVIGE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "HISTZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZFNUFI = '" & CInt(inHIZFNUFI) & "' and "
            stConsultaSQL += "HIZFCLSE = '" & CInt(inHIZFCLSE) & "' and "
            stConsultaSQL += "HIZFVIGE = '" & CInt(inHIZFVIGE) & "' "

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_HISTZOFI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro con el numero de ficha.
    ''' </summary>
    Public Function fun_Eliminar_CEDULA_CATASTRAL_VIGE_CLSE_TIFI_X_HISTZOFI(ByVal stHIZFMUNI As String, _
                                                                            ByVal stHIZFCORR As String, _
                                                                            ByVal stHIZFBARR As String, _
                                                                            ByVal stHIZFMANZ As String, _
                                                                            ByVal stHIZFPRED As String, _
                                                                            ByVal stHIZFEDIF As String, _
                                                                            ByVal stHIZFUNPR As String, _
                                                                            ByVal inHIZFTIFI As Integer, _
                                                                            ByVal inHIZFCLSE As Integer, _
                                                                            ByVal inHIZFVIGE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "HISTZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZFMUNI = '" & CStr(Trim(stHIZFMUNI)) & "' and "
            stConsultaSQL += "HIZFCORR = '" & CStr(Trim(stHIZFCORR)) & "' and "
            stConsultaSQL += "HIZFBARR = '" & CStr(Trim(stHIZFBARR)) & "' and "
            stConsultaSQL += "HIZFMANZ = '" & CStr(Trim(stHIZFMANZ)) & "' and "
            stConsultaSQL += "HIZFPRED = '" & CStr(Trim(stHIZFPRED)) & "' and "
            stConsultaSQL += "HIZFEDIF = '" & CStr(Trim(stHIZFEDIF)) & "' and "
            stConsultaSQL += "HIZFUNPR = '" & CStr(Trim(stHIZFUNPR)) & "' and "
            stConsultaSQL += "HIZFTIFI = '" & CInt(inHIZFTIFI) & "' and "
            stConsultaSQL += "HIZFCLSE = '" & CInt(inHIZFCLSE) & "' and "
            stConsultaSQL += "HIZFVIGE = '" & CInt(inHIZFVIGE) & "' "

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_HISTZOFI")
        End Try

    End Function

    ''' <summary>
    ''' elimina por el numero de la ficha predial
    ''' </summary>
    Public Function fun_Eliminar_NUFI_DEPA_MUNI_CLSE_VIGE_ZONA_X_HISTZOFI(ByVal inHIZFNUFI As Integer, _
                                                                          ByVal stHIZFDEPA As String, _
                                                                          ByVal stHIZFMUNI As String, _
                                                                          ByVal inHIZFCLSE As Integer, _
                                                                          ByVal inHIZFVIGE As Integer, _
                                                                          ByVal inHIZFZOFI As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "HISTZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZFNUFI = '" & CInt(inHIZFNUFI) & "' and "
            stConsultaSQL += "HIZFDEPA = '" & CStr(Trim(stHIZFDEPA)) & "' and "
            stConsultaSQL += "HIZFMUNI = '" & CStr(Trim(stHIZFMUNI)) & "' and "
            stConsultaSQL += "HIZFCLSE = '" & CInt(inHIZFCLSE) & "' and "
            stConsultaSQL += "HIZFVIGE = '" & CInt(inHIZFVIGE) & "' and "
            stConsultaSQL += "HIZFZOFI = '" & CInt(inHIZFZOFI) & "' "

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_HISTZOFI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_HISTZOFI(ByVal inHIZFIDRE As Integer, _
                                            ByVal inHIZFNUFI As Integer, _
                                            ByVal stHIZFDEPA As String, _
                                            ByVal stHIZFMUNI As String, _
                                            ByVal stHIZFCORR As String, _
                                            ByVal stHIZFBARR As String, _
                                            ByVal stHIZFMANZ As String, _
                                            ByVal stHIZFPRED As String, _
                                            ByVal stHIZFEDIF As String, _
                                            ByVal stHIZFUNPR As String, _
                                            ByVal inHIZFTIFI As Integer, _
                                            ByVal inHIZFCLSE As Integer, _
                                            ByVal inHIZFVIGE As Integer, _
                                            ByVal inHIZFZOFI As Integer, _
                                            ByVal inHIZFPORC As Integer, _
                                            ByVal stHIZFESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "HISTZOFI "

            stConsultaSQL += "SET "
            stConsultaSQL += "HIZFNUFI = '" & CInt(inHIZFNUFI) & "', "
            stConsultaSQL += "HIZFDEPA = '" & CStr(Trim(stHIZFDEPA)) & "', "
            stConsultaSQL += "HIZFMUNI = '" & CStr(Trim(stHIZFMUNI)) & "', "
            stConsultaSQL += "HIZFCORR = '" & CStr(Trim(stHIZFCORR)) & "', "
            stConsultaSQL += "HIZFBARR = '" & CStr(Trim(stHIZFBARR)) & "', "
            stConsultaSQL += "HIZFMANZ = '" & CStr(Trim(stHIZFMANZ)) & "', "
            stConsultaSQL += "HIZFPRED = '" & CStr(Trim(stHIZFPRED)) & "', "
            stConsultaSQL += "HIZFEDIF = '" & CStr(Trim(stHIZFEDIF)) & "', "
            stConsultaSQL += "HIZFUNPR = '" & CStr(Trim(stHIZFUNPR)) & "', "
            stConsultaSQL += "HIZFTIFI = '" & CInt(inHIZFTIFI) & "', "
            stConsultaSQL += "HIZFCLSE = '" & CInt(inHIZFCLSE) & "', "
            stConsultaSQL += "HIZFVIGE = '" & CInt(inHIZFVIGE) & "', "
            stConsultaSQL += "HIZFZOFI = '" & CInt(inHIZFZOFI) & "', "
            stConsultaSQL += "HIZFPORC = '" & CInt(inHIZFPORC) & "', "
            stConsultaSQL += "HIZFESTA = '" & CStr(Trim(stHIZFESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZFIDRE = '" & CInt(inHIZFIDRE) & "'"

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_HISTZOFI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_NUFI_DEPA_MUNI_CLSE_VIGE_ZONA_X_HISTZOFI(ByVal inHIZFNUFI As Integer, _
                                                        ByVal stHIZFDEPA As String, _
                                                        ByVal stHIZFMUNI As String, _
                                                        ByVal inHIZFCLSE As Integer, _
                                                        ByVal inHIZFVIGE As Integer, _
                                                        ByVal inHIZFZOFI As Integer, _
                                                        ByVal inHIZFPORC As Integer, _
                                                        ByVal stHIZFESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "HISTZOFI "

            stConsultaSQL += "SET "
            stConsultaSQL += "HIZFNUFI = '" & CInt(inHIZFNUFI) & "', "
            stConsultaSQL += "HIZFDEPA = '" & CStr(Trim(stHIZFDEPA)) & "', "
            stConsultaSQL += "HIZFMUNI = '" & CStr(Trim(stHIZFMUNI)) & "', "
            stConsultaSQL += "HIZFCLSE = '" & CInt(inHIZFCLSE) & "', "
            stConsultaSQL += "HIZFVIGE = '" & CInt(inHIZFVIGE) & "', "
            stConsultaSQL += "HIZFZOFI = '" & CInt(inHIZFZOFI) & "', "
            stConsultaSQL += "HIZFPORC = '" & CInt(inHIZFPORC) & "', "
            stConsultaSQL += "HIZFESTA = '" & CStr(Trim(stHIZFESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZFNUFI = '" & CInt(inHIZFNUFI) & "' and "
            stConsultaSQL += "HIZFDEPA = '" & CStr(Trim(stHIZFDEPA)) & "' and "
            stConsultaSQL += "HIZFMUNI = '" & CStr(Trim(stHIZFMUNI)) & "' and "
            stConsultaSQL += "HIZFCLSE = '" & CInt(inHIZFCLSE) & "' and "
            stConsultaSQL += "HIZFVIGE = '" & CInt(inHIZFVIGE) & "' and "
            stConsultaSQL += "HIZFZOFI = '" & CInt(inHIZFZOFI) & "' "

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_HISTZOFI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_HISTZOFI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "HIZFIDRE, "
            stConsultaSQL += "HIZFNUFI, "
            stConsultaSQL += "HIZFDEPA, "
            stConsultaSQL += "HIZFMUNI, "
            stConsultaSQL += "HIZFCORR, "
            stConsultaSQL += "HIZFBARR, "
            stConsultaSQL += "HIZFMANZ, "
            stConsultaSQL += "HIZFPRED, "
            stConsultaSQL += "HIZFEDIF, "
            stConsultaSQL += "HIZFUNPR, "
            stConsultaSQL += "HIZFTIFI, "
            stConsultaSQL += "HIZFCLSE, "
            stConsultaSQL += "HIZFVIGE, "
            stConsultaSQL += "HIZFZOFI, "
            stConsultaSQL += "HIZFPORC, "
            stConsultaSQL += "HIZFESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTZOFI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIZFDEPA, HIZFMUNI, HIZFCLSE, HIZFVIGE, HIZFZOFI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_HISTZOFI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_HISTZOFI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTZOFI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIZFDEPA, HIZFMUNI, HIZFCLSE, HIZFVIGE, HIZFZOFI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_HISTZOFI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_HISTZOFI_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZFESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIZFDEPA, HIZFMUNI, HIZFCLSE, HIZFVIGE, HIZFZOFI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_HISTZOFI_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_HISTZOFI(ByVal inHIZFIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZFIDRE = '" & CInt(inHIZFIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_HISTZOFI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_NUFI_DEPA_MUNI_CLSE_VIGE_ZONA_X_HISTZOFI(ByVal inHIZFNUFI As Integer, _
                                                                               ByVal stHIZFDEPA As String, _
                                                                               ByVal stHIZFMUNI As String, _
                                                                               ByVal inHIZFCLSE As Integer, _
                                                                               ByVal inHIZFVIGE As Integer, _
                                                                               ByVal inHIZFZOFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZFNUFI = '" & CInt(inHIZFNUFI) & "' and "
            stConsultaSQL += "HIZFDEPA = '" & CStr(Trim(stHIZFDEPA)) & "' and "
            stConsultaSQL += "HIZFMUNI = '" & CStr(Trim(stHIZFMUNI)) & "' and "
            stConsultaSQL += "HIZFCLSE = '" & CInt(inHIZFCLSE) & "' and "
            stConsultaSQL += "HIZFVIGE = '" & CInt(inHIZFVIGE) & "' and "
            stConsultaSQL += "HIZFZOFI = '" & CInt(inHIZFZOFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_HISTZOFI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_HISTZOFI(ByVal inHIZFIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "HIZFIDRE, "
            stConsultaSQL += "HIZFNUFI, "
            stConsultaSQL += "HIZFDEPA, "
            stConsultaSQL += "HIZFMUNI, "
            stConsultaSQL += "HIZFCORR, "
            stConsultaSQL += "HIZFBARR, "
            stConsultaSQL += "HIZFMANZ, "
            stConsultaSQL += "HIZFPRED, "
            stConsultaSQL += "HIZFEDIF, "
            stConsultaSQL += "HIZFUNPR, "
            stConsultaSQL += "HIZFTIFI, "
            stConsultaSQL += "HIZFCLSE, "
            stConsultaSQL += "HIZFVIGE, "
            stConsultaSQL += "HIZFZOFI, "
            stConsultaSQL += "HIZFPORC, "
            stConsultaSQL += "HIZFESTA "


            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZFIDRE = '" & CInt(inHIZFIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIZFVIGE DESC, HIZFDEPA, HIZFMUNI, HIZFCLSE, HIZFZOFI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_HISTZOFI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el Nro ficha y vigencia del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Consultar_NUFI_VIGE_X_HISTZOFI(ByVal inHIZFNUFI As Integer, ByVal inHIZFVIGE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZFNUFI = '" & CInt(inHIZFNUFI) & "' and "
            stConsultaSQL += "HIZFVIGE = '" & CInt(inHIZFVIGE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIZFDEPA, HIZFMUNI, HIZFCLSE, HIZFVIGE, HIZFZOFI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_HISTZOFI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el Nro ficha y vigencia del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Consultar_NUFI_VIGE_CLSE_TIFI_X_HISTZOFI(ByVal inHIZFNUFI As Integer, _
                                                                 ByVal inHIZFVIGE As Integer, _
                                                                 ByVal inHIZFCLSE As Integer, _
                                                                 ByVal inHIZFTIFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZFNUFI = '" & CInt(inHIZFNUFI) & "' and "
            stConsultaSQL += "HIZFVIGE = '" & CInt(inHIZFVIGE) & "' and "
            stConsultaSQL += "HIZFCLSE = '" & CInt(inHIZFCLSE) & "' and "
            stConsultaSQL += "HIZFTIFI = '" & CInt(inHIZFTIFI) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIZFDEPA, HIZFMUNI, HIZFCLSE, HIZFVIGE, HIZFZOFI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_HISTZOFI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro de ficha resumen con la cedula catastral 
    ''' </summary>
    Public Function fun_Eliminar_ZONAS_FICHA_X_HISTZOFI(ByVal stHIZFDEPA As String, _
                                                                ByVal stHIZFMUNI As String, _
                                                                ByVal stHIZFCORR As String, _
                                                                ByVal stHIZFBARR As String, _
                                                                ByVal stHIZFMANZ As String, _
                                                                ByVal stHIZFPRED As String, _
                                                                ByVal stHIZFEDIF As String, _
                                                                ByVal stHIZFUNPR As String, _
                                                                ByVal inHIZFCLSE As Integer, _
                                                                ByVal inHIZFVIGE As Integer, _
                                                                ByVal inHIZFTIFI As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "HISTZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZFDEPA = '" & CStr(Trim(stHIZFDEPA)) & "' and "
            stConsultaSQL += "HIZFMUNI = '" & CStr(Trim(stHIZFMUNI)) & "' and "
            stConsultaSQL += "HIZFCORR = '" & CStr(Trim(stHIZFCORR)) & "' and "
            stConsultaSQL += "HIZFBARR = '" & CStr(Trim(stHIZFBARR)) & "' and "
            stConsultaSQL += "HIZFMANZ = '" & CStr(Trim(stHIZFMANZ)) & "' and "
            stConsultaSQL += "HIZFPRED = '" & CStr(Trim(stHIZFPRED)) & "' and "
            stConsultaSQL += "HIZFEDIF = '" & CStr(Trim(stHIZFEDIF)) & "' and "
            stConsultaSQL += "HIZFUNPR = '" & CStr(Trim(stHIZFUNPR)) & "' and "
            stConsultaSQL += "HIZFCLSE = '" & CInt(inHIZFCLSE) & "' and "
            stConsultaSQL += "HIZFVIGE = '" & CInt(inHIZFVIGE) & "' and "
            stConsultaSQL += "HIZFTIFI = '" & CInt(inHIZFTIFI) & "' "

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_HISTZOFI")
        End Try

    End Function

    ''' <summary>
    ''' Función que consulta por cedula catastral 
    ''' </summary>
    Public Function fun_Consultar_CEDULA_CATASTRAL_X_HISTZOFI(ByVal stHIZFDEPA As String, _
                                                                ByVal stHIZFMUNI As String, _
                                                                ByVal stHIZFCORR As String, _
                                                                ByVal stHIZFBARR As String, _
                                                                ByVal stHIZFMANZ As String, _
                                                                ByVal stHIZFPRED As String, _
                                                                ByVal stHIZFEDIF As String, _
                                                                ByVal stHIZFUNPR As String, _
                                                                ByVal inHIZFCLSE As Integer, _
                                                                ByVal inHIZFVIGE As Integer, _
                                                                ByVal inHIZFTIFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZFDEPA = '" & CStr(Trim(stHIZFDEPA)) & "' and "
            stConsultaSQL += "HIZFMUNI = '" & CStr(Trim(stHIZFMUNI)) & "' and "
            stConsultaSQL += "HIZFCORR = '" & CStr(Trim(stHIZFCORR)) & "' and "
            stConsultaSQL += "HIZFBARR = '" & CStr(Trim(stHIZFBARR)) & "' and "
            stConsultaSQL += "HIZFMANZ = '" & CStr(Trim(stHIZFMANZ)) & "' and "
            stConsultaSQL += "HIZFPRED = '" & CStr(Trim(stHIZFPRED)) & "' and "
            stConsultaSQL += "HIZFEDIF = '" & CStr(Trim(stHIZFEDIF)) & "' and "
            stConsultaSQL += "HIZFUNPR = '" & CStr(Trim(stHIZFUNPR)) & "' and "
            stConsultaSQL += "HIZFCLSE = '" & CInt(inHIZFCLSE) & "' and "
            stConsultaSQL += "HIZFVIGE = '" & CInt(inHIZFVIGE) & "' and "
            stConsultaSQL += "HIZFTIFI = '" & CInt(inHIZFTIFI) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIZFDEPA, HIZFMUNI, HIZFCLSE, HIZFVIGE, HIZFZOFI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_HISTZOFI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que consulta por cedula catastral 
    ''' </summary>
    Public Function fun_Consultar_CEDULA_CATASTRAL_X_HISTZOFI(ByVal stHIZFDEPA As String, _
                                                                ByVal stHIZFMUNI As String, _
                                                                ByVal stHIZFCORR As String, _
                                                                ByVal stHIZFBARR As String, _
                                                                ByVal stHIZFMANZ As String, _
                                                                ByVal stHIZFPRED As String, _
                                                                ByVal stHIZFEDIF As String, _
                                                                ByVal stHIZFUNPR As String, _
                                                                ByVal inHIZFCLSE As Integer, _
                                                                ByVal inHIZFTIFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "HISTZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "HIZFDEPA = '" & CStr(Trim(stHIZFDEPA)) & "' and "
            stConsultaSQL += "HIZFMUNI = '" & CStr(Trim(stHIZFMUNI)) & "' and "
            stConsultaSQL += "HIZFCORR = '" & CStr(Trim(stHIZFCORR)) & "' and "
            stConsultaSQL += "HIZFBARR = '" & CStr(Trim(stHIZFBARR)) & "' and "
            stConsultaSQL += "HIZFMANZ = '" & CStr(Trim(stHIZFMANZ)) & "' and "
            stConsultaSQL += "HIZFPRED = '" & CStr(Trim(stHIZFPRED)) & "' and "
            stConsultaSQL += "HIZFEDIF = '" & CStr(Trim(stHIZFEDIF)) & "' and "
            stConsultaSQL += "HIZFUNPR = '" & CStr(Trim(stHIZFUNPR)) & "' and "
            stConsultaSQL += "HIZFCLSE = '" & CInt(inHIZFCLSE) & "' and "
            stConsultaSQL += "HIZFTIFI = '" & CInt(inHIZFTIFI) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "HIZFDEPA, HIZFMUNI, HIZFCLSE, HIZFVIGE, HIZFZOFI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_HISTZOFI")
            Return Nothing

        End Try

    End Function

End Class
