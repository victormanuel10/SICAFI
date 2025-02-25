Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_OBURAVCO

    '========================================================
    '*** CLASE AVALUO COMERCIAL OBLIGACIONES URBANISTICAS ***
    '========================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_OBURAVCO(ByVal stOUACCLEN As String, _
                                                         ByVal inOUACNURE As Integer, _
                                                         ByVal stOUACFERE As String, _
                                                         ByVal obOUACNUAV As Object, _
                                                         ByVal obOUACVIAV As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(stOUACCLEN) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(inOUACNURE) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(stOUACFERE) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obOUACNUAV.Text) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obOUACVIAV.SelectedValue) = True Then

                Dim objdatos1 As New cla_OBURAVCO
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_OBURAVCO(stOUACCLEN, inOUACNURE, stOUACFERE, obOUACNUAV.Text, obOUACVIAV.SelectedValue)

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    boRespuesta = False
                Else
                    boRespuesta = True
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
    Public Function fun_Insertar_OBURAVCO(ByVal inOUACSECU As Integer, _
                                          ByVal stOUACCLEN As String, _
                                          ByVal inOUACNURE As Integer, _
                                          ByVal stOUACFERE As String, _
                                          ByVal inOUACNUAV As Integer, _
                                          ByVal inOUACVIAV As Integer, _
                                          ByVal stOUACEMPR As String, _
                                          ByVal stOUACFEVI As String, _
                                          ByVal stOUACFEIN As String, _
                                          ByVal stOUACSOLI As String, _
                                          ByVal stOUACPUNT As String, _
                                          ByVal stOUACPROY As String, _
                                          ByVal stOUACDIRE As String, _
                                          ByVal inOUACARTE As Integer, _
                                          ByVal loOUACAVCO As Long, _
                                          ByVal loOUACACM2 As Long, _
                                          ByVal stOUACESTA As String) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "OBURAVCO "

            stConsultaSQL += "( "
            stConsultaSQL += "OUACSECU, "
            stConsultaSQL += "OUACCLEN, "
            stConsultaSQL += "OUACNURE, "
            stConsultaSQL += "OUACFERE, "
            stConsultaSQL += "OUACNUAV, "
            stConsultaSQL += "OUACVIAV, "
            stConsultaSQL += "OUACEMPR, "
            stConsultaSQL += "OUACFEVI, "
            stConsultaSQL += "OUACFEIN, "
            stConsultaSQL += "OUACSOLI, "
            stConsultaSQL += "OUACPUNT, "
            stConsultaSQL += "OUACPROY, "
            stConsultaSQL += "OUACDIRE, "
            stConsultaSQL += "OUACARTE, "
            stConsultaSQL += "OUACAVCO, "
            stConsultaSQL += "OUACACM2, "
            stConsultaSQL += "OUACESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inOUACSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUACCLEN)) & "', "
            stConsultaSQL += "'" & CInt(inOUACNURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUACFERE)) & "', "
            stConsultaSQL += "'" & CInt(inOUACNUAV) & "', "
            stConsultaSQL += "'" & CInt(inOUACVIAV) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUACEMPR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUACFEVI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUACFEIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUACSOLI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUACPUNT)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUACPROY)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUACDIRE)) & "', "
            stConsultaSQL += "'" & CInt(inOUACARTE) & "', "
            stConsultaSQL += "'" & CDbl(loOUACAVCO) & "', "
            stConsultaSQL += "'" & CDbl(loOUACACM2) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUACESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_OBURAVCO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_OBURAVCO(ByVal inOUACIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "OBURAVCO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUACIDRE = '" & CInt(inOUACIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_OBURAVCO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_OBURAVCO(ByVal inOUACSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "OBURAVCO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUACSECU = '" & CInt(inOUACSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_OBURAVCO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_OBURAVCO(ByVal inOUACIDRE As Integer, _
                                            ByVal inOUACSECU As Integer, _
                                            ByVal stOUACCLEN As String, _
                                            ByVal inOUACNURE As Integer, _
                                            ByVal stOUACFERE As String, _
                                            ByVal inOUACNUAV As Integer, _
                                            ByVal inOUACVIAV As Integer, _
                                            ByVal stOUACEMPR As String, _
                                            ByVal stOUACFEVI As String, _
                                            ByVal stOUACFEIN As String, _
                                            ByVal stOUACSOLI As String, _
                                            ByVal stOUACPUNT As String, _
                                            ByVal stOUACPROY As String, _
                                            ByVal stOUACDIRE As String, _
                                            ByVal inOUACARTE As Integer, _
                                            ByVal loOUACAVCO As Long, _
                                            ByVal loOUACACM2 As Long, _
                                            ByVal stOUACESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "OBURAVCO "

            stConsultaSQL += "SET "
            stConsultaSQL += "OUACSECU = '" & CInt(inOUACSECU) & "', "
            stConsultaSQL += "OUACCLEN = '" & CStr(Trim(stOUACCLEN)) & "', "
            stConsultaSQL += "OUACNURE = '" & CInt(inOUACNURE) & "', "
            stConsultaSQL += "OUACFERE = '" & CStr(Trim(stOUACFERE)) & "', "
            stConsultaSQL += "OUACNUAV = '" & CInt(inOUACNUAV) & "', "
            stConsultaSQL += "OUACVIAV = '" & CInt(inOUACVIAV) & "', "
            stConsultaSQL += "OUACEMPR = '" & CStr(Trim(stOUACEMPR)) & "', "
            stConsultaSQL += "OUACFEVI = '" & CStr(Trim(stOUACFEVI)) & "', "
            stConsultaSQL += "OUACFEIN = '" & CStr(Trim(stOUACFEIN)) & "', "
            stConsultaSQL += "OUACSOLI = '" & CStr(Trim(stOUACSOLI)) & "', "
            stConsultaSQL += "OUACPUNT = '" & CStr(Trim(stOUACPUNT)) & "', "
            stConsultaSQL += "OUACPROY = '" & CStr(Trim(stOUACPROY)) & "', "
            stConsultaSQL += "OUACDIRE = '" & CStr(Trim(stOUACDIRE)) & "', "
            stConsultaSQL += "OUACARTE = '" & CInt(inOUACARTE) & "', "
            stConsultaSQL += "OUACAVCO = '" & CLng(loOUACAVCO) & "', "
            stConsultaSQL += "OUACACM2 = '" & CLng(loOUACACM2) & "', "
            stConsultaSQL += "OUACESTA = '" & CStr(Trim(stOUACESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUACIDRE = '" & CInt(inOUACIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_OBURAVCO")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_OBURAVCO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUACIDRE, "
            stConsultaSQL += "OUACSECU, "
            stConsultaSQL += "OUACCLEN, "
            stConsultaSQL += "OUACNURE, "
            stConsultaSQL += "OUACFERE, "
            stConsultaSQL += "OUACNUAV, "
            stConsultaSQL += "OUACVIAV, "
            stConsultaSQL += "OUACEMPR, "
            stConsultaSQL += "OUACFEVI, "
            stConsultaSQL += "OUACFEIN, "
            stConsultaSQL += "OUACSOLI, "
            stConsultaSQL += "OUACPUNT, "
            stConsultaSQL += "OUACPROY, "
            stConsultaSQL += "OUACDIRE, "
            stConsultaSQL += "OUACARTE, "
            stConsultaSQL += "OUACAVCO, "
            stConsultaSQL += "OUACACM2, "
            stConsultaSQL += "OUACESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURAVCO, ESTADO "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "OUACESTA = ESTACODI "
            
            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUACIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_OBURAVCO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_OBURAVCO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURAVCO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUACIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_OBURAVCO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_OBURAVCO(ByVal inOUACIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURAVCO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUACIDRE = '" & CInt(inOUACIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_OBURAVCO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_OBURAVCO(ByVal stOUACCLEN As String, _
                                                 ByVal inOUACNURE As Integer, _
                                                 ByVal stOUACFERE As String, _
                                                 ByVal inOUACNUAV As Integer, _
                                                 ByVal inOUACVIAV As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURAVCO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUACCLEN = '" & CStr(Trim(stOUACCLEN)) & "' AND "
            stConsultaSQL += "OUACNURE = '" & CInt(inOUACNURE) & "'AND  "
            stConsultaSQL += "OUACFERE = '" & CStr(Trim(stOUACFERE)) & "' AND "
            stConsultaSQL += "OUACNUAV = '" & CInt(inOUACNUAV) & "' AND "
            stConsultaSQL += "OUACVIAV = '" & CInt(inOUACVIAV) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_OBURAVCO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_OBURAVCO(ByVal stOUACCLEN As String, _
                                                 ByVal inOUACNURE As Integer, _
                                                 ByVal stOUACFERE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURAVCO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUACCLEN = '" & CStr(Trim(stOUACCLEN)) & "' AND "
            stConsultaSQL += "OUACNURE = '" & CInt(inOUACNURE) & "'AND  "
            stConsultaSQL += "OUACFERE = '" & CStr(Trim(stOUACFERE)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_OBURAVCO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURAVCO(ByVal inOUACIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUACIDRE, "
            stConsultaSQL += "OUACSECU, "
            stConsultaSQL += "OUACCLEN, "
            stConsultaSQL += "OUACNURE, "
            stConsultaSQL += "OUACFERE, "
            stConsultaSQL += "OUACNUAV, "
            stConsultaSQL += "OUACVIAV, "
            stConsultaSQL += "OUACEMPR, "
            stConsultaSQL += "OUACFEVI, "
            stConsultaSQL += "OUACFEIN, "
            stConsultaSQL += "OUACSOLI, "
            stConsultaSQL += "OUACPUNT, "
            stConsultaSQL += "OUACPROY, "
            stConsultaSQL += "OUACDIRE, "
            stConsultaSQL += "OUACARTE, "
            stConsultaSQL += "OUACAVCO, "
            stConsultaSQL += "OUACACM2, "
            stConsultaSQL += "OUACESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURAVCO, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUACESTA = ESTACODI AND "
            stConsultaSQL += "OUACIDRE = '" & CInt(inOUACIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUACIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURAVCO")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURAVCO(ByVal inOUACSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUACIDRE, "
            stConsultaSQL += "OUACSECU, "
            stConsultaSQL += "OUACCLEN, "
            stConsultaSQL += "OUACNURE, "
            stConsultaSQL += "OUACFERE, "
            stConsultaSQL += "OUACNUAV, "
            stConsultaSQL += "OUACVIAV, "
            stConsultaSQL += "OUACEMPR, "
            stConsultaSQL += "OUACFEVI, "
            stConsultaSQL += "OUACFEIN, "
            stConsultaSQL += "OUACSOLI, "
            stConsultaSQL += "OUACPUNT, "
            stConsultaSQL += "OUACPROY, "
            stConsultaSQL += "OUACDIRE, "
            stConsultaSQL += "OUACARTE, "
            stConsultaSQL += "OUACAVCO, "
            stConsultaSQL += "OUACACM2, "
            stConsultaSQL += "OUACESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURAVCO, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUACESTA = ESTACODI AND "
            stConsultaSQL += "OUACSECU = '" & CInt(inOUACSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUACIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURAVCO")
            Return Nothing

        End Try

    End Function


End Class
