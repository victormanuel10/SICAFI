Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_OBURSOLI

    '===================================================
    '*** CLASE OBLIGACIONES URBANISTICAS SOLICITANTE ***
    '===================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_OBURSOLI(ByVal stOUSOCLEN As String, _
                                                         ByVal inOUSONURE As Integer, _
                                                         ByVal stOUSOFERE As String, _
                                                         ByVal obOUSONUDO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inOUSONURE) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(stOUSOFERE) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(stOUSOCLEN) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obOUSONUDO.Text) = True Then

                Dim objdatos1 As New cla_OBURSOLI
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_OBURSOLI(stOUSOCLEN, inOUSONURE, stOUSOFERE, obOUSONUDO.Text)

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
    Public Function fun_Insertar_OBURSOLI(ByVal inOUSOSECU As Integer, _
                                          ByVal stOUSOCLEN As String, _
                                          ByVal inOUSONURE As Integer, _
                                          ByVal stOUSOFERE As String, _
                                          ByVal stOUSONUDO As String, _
                                          ByVal inOUSOSOLI As Integer, _
                                          ByVal stOUSONOMB As String, _
                                          ByVal stOUSOPRAP As String, _
                                          ByVal stOUSOSEAP As String, _
                                          ByVal stOUSODIPR As String, _
                                          ByVal stOUSODINO As String, _
                                          ByVal stOUSOTELE As String, _
                                          ByVal stOUSOCELU As String, _
                                          ByVal stOUSOCOEL As String, _
                                          ByVal stOUSOCOPO As String, _
                                          ByVal stOUSORESO As String, _
                                          ByVal stOUSOESTA As String) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "OBURSOLI "

            stConsultaSQL += "( "
            stConsultaSQL += "OUSOSECU, "
            stConsultaSQL += "OUSOCLEN, "
            stConsultaSQL += "OUSONURE, "
            stConsultaSQL += "OUSOFERE, "
            stConsultaSQL += "OUSONUDO, "
            stConsultaSQL += "OUSOSOLI, "
            stConsultaSQL += "OUSONOMB, "
            stConsultaSQL += "OUSOPRAP, "
            stConsultaSQL += "OUSOSEAP, "
            stConsultaSQL += "OUSODIPR, "
            stConsultaSQL += "OUSODINO, "
            stConsultaSQL += "OUSOTELE, "
            stConsultaSQL += "OUSOCELU, "
            stConsultaSQL += "OUSOCOEL, "
            stConsultaSQL += "OUSOCOPO, "
            stConsultaSQL += "OUSORESO, "
            stConsultaSQL += "OUSOESTA "

            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inOUSOSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUSOCLEN)) & "', "
            stConsultaSQL += "'" & CInt(inOUSONURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUSOFERE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUSONUDO)) & "', "
            stConsultaSQL += "'" & CInt(inOUSOSOLI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUSONOMB)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUSOPRAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUSOSEAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUSODIPR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUSODINO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUSOTELE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUSOCELU)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUSOCOEL)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUSOCOPO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUSORESO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUSOESTA)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_OBURSOLI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_OBURSOLI(ByVal inOUSOIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "OBURSOLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUSOIDRE = '" & CInt(inOUSOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_OBURSOLI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_OBURSOLI(ByVal stOUSOSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "OBURSOLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUSOSECU = '" & CInt(stOUSOSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_OBURSOLI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_OBURSOLI(ByVal inOUSOIDRE As Integer, _
                                            ByVal inOUSOSECU As Integer, _
                                            ByVal stOUSOCLEN As String, _
                                            ByVal inOUSONURE As Integer, _
                                            ByVal stOUSOFERE As String, _
                                            ByVal stOUSONUDO As String, _
                                            ByVal inOUSOSOLI As Integer, _
                                            ByVal stOUSONOMB As String, _
                                            ByVal stOUSOPRAP As String, _
                                            ByVal stOUSOSEAP As String, _
                                            ByVal stOUSODIPR As String, _
                                            ByVal stOUSODINO As String, _
                                            ByVal stOUSOTELE As String, _
                                            ByVal stOUSOCELU As String, _
                                            ByVal stOUSOCOEL As String, _
                                            ByVal stOUSOCOPO As String, _
                                            ByVal stOUSORESO As String, _
                                            ByVal stOUSOESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "OBURSOLI "

            stConsultaSQL += "SET "
            stConsultaSQL += "OUSOSECU = '" & CInt(inOUSOSECU) & "', "
            stConsultaSQL += "OUSOCLEN = '" & CStr(Trim(stOUSOCLEN)) & "', "
            stConsultaSQL += "OUSONURE = '" & CInt(inOUSONURE) & "', "
            stConsultaSQL += "OUSOFERE = '" & CStr(Trim(stOUSOFERE)) & "', "
            stConsultaSQL += "OUSONUDO = '" & CStr(Trim(stOUSONUDO)) & "', "
            stConsultaSQL += "OUSOSOLI = '" & CInt(inOUSOSOLI) & "', "
            stConsultaSQL += "OUSONOMB = '" & CStr(Trim(stOUSONOMB)) & "', "
            stConsultaSQL += "OUSOPRAP = '" & CStr(Trim(stOUSOPRAP)) & "', "
            stConsultaSQL += "OUSOSEAP = '" & CStr(Trim(stOUSOSEAP)) & "', "
            stConsultaSQL += "OUSODIPR = '" & CStr(Trim(stOUSODIPR)) & "', "
            stConsultaSQL += "OUSODINO = '" & CStr(Trim(stOUSODINO)) & "', "
            stConsultaSQL += "OUSOTELE = '" & CStr(Trim(stOUSOTELE)) & "', "
            stConsultaSQL += "OUSOCELU = '" & CStr(Trim(stOUSOCELU)) & "', "
            stConsultaSQL += "OUSOCOEL = '" & CStr(Trim(stOUSOCOEL)) & "', "
            stConsultaSQL += "OUSOCOPO = '" & CStr(Trim(stOUSOCOPO)) & "', "
            stConsultaSQL += "OUSORESO = '" & CStr(Trim(stOUSORESO)) & "', "
            stConsultaSQL += "OUSOESTA = '" & CStr(Trim(stOUSOESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUSOIDRE = '" & CInt(inOUSOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_OBURSOLI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_OBURSOLI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUSOIDRE, "
            stConsultaSQL += "OUSOSECU, "
            stConsultaSQL += "OUSOCLEN, "
            stConsultaSQL += "OUSONURE, "
            stConsultaSQL += "OUSOFERE, "
            stConsultaSQL += "OUSOSOLI, "
            stConsultaSQL += "SOLIDESC, "
            stConsultaSQL += "OUSONUDO, "
            stConsultaSQL += "OUSONOMB, "
            stConsultaSQL += "OUSOPRAP, "
            stConsultaSQL += "OUSOSEAP, "
            stConsultaSQL += "OUSODIPR, "
            stConsultaSQL += "OUSODINO, "
            stConsultaSQL += "OUSOTELE, "
            stConsultaSQL += "OUSOCELU, "
            stConsultaSQL += "OUSOCOEL, "
            stConsultaSQL += "OUSOCOPO, "
            stConsultaSQL += "OUSORESO, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "OUSOESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURSOLI, MANT_SOLICITANTE, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUSOSOLI = SOLICODI AND "
            stConsultaSQL += "OUSOESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUSOIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_OBURSOLI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_OBURSOLI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURSOLI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUSOIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_OBURSOLI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_OBURSOLI(ByVal inOUSOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURSOLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUSOIDRE = '" & CInt(inOUSOIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_OBURSOLI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_OBURSOLI(ByVal stOUSOCLEN As String, _
                                                 ByVal inOUSONURE As Integer, _
                                                 ByVal stOUSOFERE As String, _
                                                 ByVal stOUSONUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURSOLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUSOCLEN = '" & CStr(Trim(stOUSOCLEN)) & "'AND  "
            stConsultaSQL += "OUSONURE = '" & CInt(inOUSONURE) & "'AND  "
            stConsultaSQL += "OUSOFERE = '" & CStr(Trim(stOUSOFERE)) & "' AND "
            stConsultaSQL += "OUSONUDO = '" & CStr(Trim(stOUSONUDO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_OBURSOLI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURSOLI(ByVal inOUSOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUSOIDRE, "
            stConsultaSQL += "OUSOSECU, "
            stConsultaSQL += "OUSOCLEN, "
            stConsultaSQL += "OUSONURE, "
            stConsultaSQL += "OUSOFERE, "
            stConsultaSQL += "OUSOSOLI, "
            stConsultaSQL += "SOLIDESC, "
            stConsultaSQL += "OUSONUDO, "
            stConsultaSQL += "OUSONOMB, "
            stConsultaSQL += "OUSOPRAP, "
            stConsultaSQL += "OUSOSEAP, "
            stConsultaSQL += "OUSODIPR, "
            stConsultaSQL += "OUSODINO, "
            stConsultaSQL += "OUSOTELE, "
            stConsultaSQL += "OUSOCELU, "
            stConsultaSQL += "OUSOCOEL, "
            stConsultaSQL += "OUSOCOPO, "
            stConsultaSQL += "OUSORESO, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "OUSOESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURSOLI, MANT_SOLICITANTE, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUSOSOLI = SOLICODI AND "
            stConsultaSQL += "OUSOESTA = ESTACODI AND "
            stConsultaSQL += "OUSOIDRE = '" & CInt(inOUSOIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUSOIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURSOLI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURSOLI(ByVal stOUSOSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUSOIDRE, "
            stConsultaSQL += "OUSOSECU, "
            stConsultaSQL += "OUSOCLEN, "
            stConsultaSQL += "OUSONURE, "
            stConsultaSQL += "OUSOFERE, "
            stConsultaSQL += "OUSOSOLI, "
            stConsultaSQL += "SOLIDESC, "
            stConsultaSQL += "OUSONUDO, "
            stConsultaSQL += "OUSONOMB, "
            stConsultaSQL += "OUSOPRAP, "
            stConsultaSQL += "OUSOSEAP, "
            stConsultaSQL += "OUSODIPR, "
            stConsultaSQL += "OUSODINO, "
            stConsultaSQL += "OUSOTELE, "
            stConsultaSQL += "OUSOCELU, "
            stConsultaSQL += "OUSOCOEL, "
            stConsultaSQL += "OUSOCOPO, "
            stConsultaSQL += "OUSORESO, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "OUSOESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURSOLI, MANT_SOLICITANTE, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUSOSOLI = SOLICODI AND "
            stConsultaSQL += "OUSOESTA = ESTACODI AND "
            stConsultaSQL += "OUSOSECU = '" & CInt(stOUSOSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUSOIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURSOLI")
            Return Nothing

        End Try

    End Function


End Class
