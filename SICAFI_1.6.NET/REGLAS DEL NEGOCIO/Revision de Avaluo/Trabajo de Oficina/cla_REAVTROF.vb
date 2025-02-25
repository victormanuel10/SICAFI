Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_REAVTROF

    '===================================================
    '*** CLASE TRABAJO DE OFICINA REVISION DE AVALUO ***
    '===================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_REAVTROF(ByVal inRATOSECU As Integer, ByVal obRATONUDO As Object, ByVal obRATOFEEN As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inRATOSECU) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRATONUDO.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRATOFEEN.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(inRATOSECU) = True Then

                    Dim objdatos1 As New cla_REAVTROF
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_REAVTROF(inRATOSECU, obRATONUDO.Text, obRATOFEEN.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(inRATOSECU) & " - " & Trim(obRATONUDO.Text) & " - " & Trim(obRATOFEEN.Text) & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obRATONUDO.Focus()
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
    Public Function fun_Insertar_REAVTROF(ByVal inRATOSECU As Integer, _
                                          ByVal stRATONUDO As String, _
                                          ByVal stRATOFEEN As String, _
                                          ByVal stRATOOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "REAVTROF "

            stConsultaSQL += "( "
            stConsultaSQL += "RATOSECU, "
            stConsultaSQL += "RATONUDO, "
            stConsultaSQL += "RATOFEEN, "
            stConsultaSQL += "RATOOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRATOSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRATONUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRATOFEEN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRATOOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_REAVTROF")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_REAVTROF(ByVal inRATOIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REAVTROF "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RATOIDRE = '" & CInt(inRATOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_REAVTROF")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_NUDO_REAVTROF(ByVal inRATOSECU As Integer, ByVal stRATONUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REAVTROF "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RATOSECU = '" & CInt(inRATOSECU) & "' and "
            stConsultaSQL += "RATONUDO = '" & CStr(Trim(stRATONUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_REAVTROF")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_REAVTROF(ByVal inRATOSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REAVTROF "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RATOSECU = '" & CInt(inRATOSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_REAVTROF")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_REAVTROF(ByVal inRATOIDRE As Integer, _
                                            ByVal inRATOSECU As Integer, _
                                            ByVal stRATONUDO As String, _
                                            ByVal stRATOFEEN As String, _
                                            ByVal stRATOOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "REAVTROF "

            stConsultaSQL += "SET "
            stConsultaSQL += "RATOSECU = '" & CInt(inRATOSECU) & "', "
            stConsultaSQL += "RATONUDO = '" & CStr(Trim(stRATONUDO)) & "', "
            stConsultaSQL += "RATOFEEN = '" & CStr(Trim(stRATOFEEN)) & "', "
            stConsultaSQL += "RATOOBSE = '" & CStr(Trim(stRATOOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RATOIDRE = '" & CInt(inRATOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_REAVTROF")
        End Try

    End Function


    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_REAVTROF() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RATOIDRE, "
            stConsultaSQL += "RATOSECU, "
            stConsultaSQL += "RATONUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "RATOFEEN, "
            stConsultaSQL += "RATOOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVTROF, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RATONUDO = USUANUDO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RATOIDRE DESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_REAVTROF")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVTROF(ByVal inRATOSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RATOIDRE, "
            stConsultaSQL += "RATOSECU, "
            stConsultaSQL += "RATONUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "RATOFEEN, "
            stConsultaSQL += "RATOOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVTROF, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RATONUDO = USUANUDO and "
            stConsultaSQL += "RATOSECU = '" & CInt(inRATOSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RATOIDRE DESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVTROF")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_REAVTROF(ByVal inRATOSECU As Integer, ByVal stRATONUDO As String, ByVal stRATOFEEN As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVTROF "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RATOSECU = '" & CInt(inRATOSECU) & "' and "
            stConsultaSQL += "RATONUDO = '" & CStr(Trim(stRATONUDO)) & "' and "
            stConsultaSQL += "RATOFEEN = '" & CStr(Trim(stRATOFEEN)) & "' "

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
    Public Function fun_Buscar_CODIGO_X_REAVTROF(ByVal inRATOSECU As Integer, ByVal stRATONUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVTROF "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RATOSECU = '" & CInt(inRATOSECU) & "' and "
            stConsultaSQL += "RATONUDO = '" & CStr(Trim(stRATONUDO)) & "' "

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
