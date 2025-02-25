Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RECLTROF

    '=========================================
    '*** CLASE TRABAJO DE OFICINA RECLAMOS ***
    '=========================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RECLTROF(ByVal inRETOSECU As Integer, ByVal obRETONUDO As Object, ByVal obRETOFEEN As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inRETOSECU) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRETONUDO.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRETOFEEN.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(inRETOSECU) = True Then

                    Dim objdatos1 As New cla_RECLTROF
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_RECLTROF(inRETOSECU, obRETONUDO.Text, obRETOFEEN.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(inRETOSECU) & " - " & Trim(obRETONUDO.Text) & " - " & Trim(obRETOFEEN.Text) & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obRETONUDO.Focus()
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
    Public Function fun_Insertar_RECLTROF(ByVal inRETOSECU As Integer, _
                                          ByVal stRETONUDO As String, _
                                          ByVal stRETOFEEN As String, _
                                          ByVal stRETOOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RECLTROF "

            stConsultaSQL += "( "
            stConsultaSQL += "RETOSECU, "
            stConsultaSQL += "RETONUDO, "
            stConsultaSQL += "RETOFEEN, "
            stConsultaSQL += "RETOOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRETOSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRETONUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRETOFEEN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRETOOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RECLTROF")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RECLTROF(ByVal inRETOIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLTROF "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RETOIDRE = '" & CInt(inRETOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_RECLTROF")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_NUDO_RECLTROF(ByVal inRETOSECU As Integer, ByVal stRETONUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLTROF "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RETOSECU = '" & CInt(inRETOSECU) & "' and "
            stConsultaSQL += "RETONUDO = '" & CStr(Trim(stRETONUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_RECLTROF")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RECLTROF(ByVal inRETOSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLTROF "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RETOSECU = '" & CInt(inRETOSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_RECLTROF")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RECLTROF(ByVal inRETOIDRE As Integer, _
                                            ByVal inRETOSECU As Integer, _
                                            ByVal stRETONUDO As String, _
                                            ByVal stRETOFEEN As String, _
                                            ByVal stRETOOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RECLTROF "

            stConsultaSQL += "SET "
            stConsultaSQL += "RETOSECU = '" & CInt(inRETOSECU) & "', "
            stConsultaSQL += "RETONUDO = '" & CStr(Trim(stRETONUDO)) & "', "
            stConsultaSQL += "RETOFEEN = '" & CStr(Trim(stRETOFEEN)) & "', "
            stConsultaSQL += "RETOOBSE = '" & CStr(Trim(stRETOOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RETOIDRE = '" & CInt(inRETOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RECLTROF")
        End Try

    End Function


    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RECLTROF() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RETOIDRE, "
            stConsultaSQL += "RETOSECU, "
            stConsultaSQL += "RETONUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "RETOFEEN, "
            stConsultaSQL += "RETOOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLTROF, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RETONUDO = USUANUDO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RETOIDRE DESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLTROF")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLTROF(ByVal inRETOSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RETOIDRE, "
            stConsultaSQL += "RETOSECU, "
            stConsultaSQL += "RETONUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "RETOFEEN, "
            stConsultaSQL += "RETOOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLTROF, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RETONUDO = USUANUDO and "
            stConsultaSQL += "RETOSECU = '" & CInt(inRETOSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RETOIDRE DESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLTROF")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECLTROF(ByVal inRETOSECU As Integer, ByVal stRETONUDO As String, ByVal stRETOFEEN As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLTROF "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RETOSECU = '" & CInt(inRETOSECU) & "' and "
            stConsultaSQL += "RETONUDO = '" & CStr(Trim(stRETONUDO)) & "' and "
            stConsultaSQL += "RETOFEEN = '" & CStr(Trim(stRETOFEEN)) & "' "

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
    Public Function fun_Buscar_CODIGO_X_RECLTROF(ByVal inRETOSECU As Integer, ByVal stRETONUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLTROF "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RETOSECU = '" & CInt(inRETOSECU) & "' and "
            stConsultaSQL += "RETONUDO = '" & CStr(Trim(stRETONUDO)) & "' "

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
