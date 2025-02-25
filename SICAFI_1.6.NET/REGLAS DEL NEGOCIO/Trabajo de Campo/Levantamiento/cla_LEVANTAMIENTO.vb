Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_LEVANTAMIENTO

    '===========================
    '*** CLASE LEVANTAMIENTO ***
    '===========================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_LEVANTAMIENTO(ByVal inLEVASECU As Integer, ByVal obLEVANUDO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inLEVASECU) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obLEVANUDO.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(inLEVASECU) = True Then

                    Dim objdatos1 As New cla_LEVANTAMIENTO
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_LEVANTAMIENTO(inLEVASECU, obLEVANUDO.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(inLEVASECU) & " - " & Trim(obLEVANUDO.Text) & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obLEVANUDO.Focus()
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
    Public Function fun_Insertar_LEVANTAMIENTO(ByVal inLEVASECU As Integer, _
                                          ByVal stLEVANUDO As String, _
                                          ByVal stLEVAFEEN As String, _
                                          ByVal stLEVAFERE As String, _
                                          ByVal stLEVAOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "LEVANTAMIENTO "

            stConsultaSQL += "( "
            stConsultaSQL += "LEVASECU, "
            stConsultaSQL += "LEVANUDO, "
            stConsultaSQL += "LEVAFEEN, "
            stConsultaSQL += "LEVAFERE, "
            stConsultaSQL += "LEVAOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inLEVASECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLEVANUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLEVAFEEN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLEVAFERE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLEVAOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_LEVANTAMIENTO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_NUDO_LEVANTAMIENTO(ByVal inLEVASECU As Integer, ByVal stLEVANUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "LEVANTAMIENTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LEVASECU = '" & CInt(inLEVASECU) & "' and "
            stConsultaSQL += "LEVANUDO = '" & CStr(Trim(stLEVANUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_LEVANTAMIENTO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_LEVANTAMIENTO(ByVal inLEVAIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "LEVANTAMIENTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LEVAIDRE = '" & CInt(inLEVAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_LEVANTAMIENTO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_LEVANTAMIENTO(ByVal inLEVASECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "LEVANTAMIENTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LEVASECU = '" & CInt(inLEVASECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_LEVANTAMIENTO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_LEVANTAMIENTO(ByVal inLEVAIDRE As Integer, _
                                            ByVal inLEVASECU As Integer, _
                                            ByVal stLEVANUDO As String, _
                                            ByVal stLEVAFEEN As String, _
                                            ByVal stLEVAFERE As String, _
                                            ByVal stLEVAOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "LEVANTAMIENTO "

            stConsultaSQL += "SET "
            stConsultaSQL += "LEVASECU = '" & CInt(inLEVASECU) & "', "
            stConsultaSQL += "LEVANUDO = '" & CStr(Trim(stLEVANUDO)) & "', "
            stConsultaSQL += "LEVAFEEN = '" & CStr(Trim(stLEVAFEEN)) & "', "
            stConsultaSQL += "LEVAFERE = '" & CStr(Trim(stLEVAFERE)) & "', "
            stConsultaSQL += "LEVAOBSE = '" & CStr(Trim(stLEVAOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LEVAIDRE = '" & CInt(inLEVAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_LEVANTAMIENTO")
        End Try

    End Function


    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_LEVANTAMIENTO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "LEVAIDRE, "
            stConsultaSQL += "LEVASECU, "
            stConsultaSQL += "LEVANUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "LEVAFEEN, "
            stConsultaSQL += "LEVAFERE, "
            stConsultaSQL += "LEVAOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LEVANTAMIENTO, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LEVANUDO = USUANUDO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LEVAFEEN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_LEVANTAMIENTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LEVANTAMIENTO(ByVal inLEVASECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "LEVAIDRE, "
            stConsultaSQL += "LEVASECU, "
            stConsultaSQL += "LEVANUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "LEVAFEEN, "
            stConsultaSQL += "LEVAFERE, "
            stConsultaSQL += "LEVAOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LEVANTAMIENTO, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LEVANUDO = USUANUDO and "
            stConsultaSQL += "LEVASECU = '" & CInt(inLEVASECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LEVAFEEN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LEVANTAMIENTO")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_LEVANTAMIENTO(ByVal inLEVASECU As Integer, ByVal stLEVANUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LEVANTAMIENTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LEVASECU = '" & CInt(inLEVASECU) & "' and "
            stConsultaSQL += "LEVANUDO = '" & CStr(Trim(stLEVANUDO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_TRABCAMP")
            Return Nothing
        End Try

    End Function
    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_LEVANTAMIENTO(ByVal inLEVAIDRE As Integer, ByVal inLEVASECU As Integer, ByVal stLEVANUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LEVANTAMIENTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LEVAIDRE = '" & CInt(inLEVAIDRE) & "' and "
            stConsultaSQL += "LEVASECU = '" & CInt(inLEVASECU) & "' and "
            stConsultaSQL += "LEVANUDO = '" & CStr(Trim(stLEVANUDO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_TRABCAMP")
            Return Nothing
        End Try

    End Function

End Class
