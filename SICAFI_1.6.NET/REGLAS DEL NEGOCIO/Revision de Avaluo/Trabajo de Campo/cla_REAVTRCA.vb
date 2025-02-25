Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_REAVTRCA

    '=================================================
    '*** CLASE TRABAJO DE CAMPO REVISION DE AVALUO ***
    '=================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_REAVTRCA(ByVal inRATCSECU As Integer, ByVal obRATCNUDO As Object, ByVal obRATCFEEN As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inRATCSECU) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRATCNUDO.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRATCFEEN.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(inRATCSECU) = True Then

                    Dim objdatos1 As New cla_REAVTRCA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_REAVTRCA(inRATCSECU, obRATCNUDO.Text, obRATCFEEN.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(inRATCSECU) & " - " & Trim(obRATCNUDO.Text) & " - " & Trim(obRATCFEEN.Text) & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obRATCNUDO.Focus()
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
    Public Function fun_Insertar_REAVTRCA(ByVal inRATCSECU As Integer, _
                                          ByVal stRATCNUDO As String, _
                                          ByVal stRATCFEEN As String, _
                                          ByVal stRATCOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "REAVTRCA "

            stConsultaSQL += "( "
            stConsultaSQL += "RATCSECU, "
            stConsultaSQL += "RATCNUDO, "
            stConsultaSQL += "RATCFEEN, "
            stConsultaSQL += "RATCOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRATCSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRATCNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRATCFEEN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRATCOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_REAVTRCA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_REAVTRCA(ByVal inRATCIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REAVTRCA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RATCIDRE = '" & CInt(inRATCIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_REAVTRCA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_NUDO_REAVTRCA(ByVal inRATCSECU As Integer, ByVal stRATCNUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REAVTRCA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RATCSECU = '" & CInt(inRATCSECU) & "' and "
            stConsultaSQL += "RATCNUDO = '" & CStr(Trim(stRATCNUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_REAVTRCA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_REAVTRCA(ByVal inRATCSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REAVTRCA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RATCSECU = '" & CInt(inRATCSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_REAVTRCA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_REAVTRCA(ByVal inRATCIDRE As Integer, _
                                            ByVal inRATCSECU As Integer, _
                                            ByVal stRATCNUDO As String, _
                                            ByVal stRATCFEEN As String, _
                                            ByVal stRATCOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "REAVTRCA "

            stConsultaSQL += "SET "
            stConsultaSQL += "RATCSECU = '" & CInt(inRATCSECU) & "', "
            stConsultaSQL += "RATCNUDO = '" & CStr(Trim(stRATCNUDO)) & "', "
            stConsultaSQL += "RATCFEEN = '" & CStr(Trim(stRATCFEEN)) & "', "
            stConsultaSQL += "RATCOBSE = '" & CStr(Trim(stRATCOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RATCIDRE = '" & CInt(inRATCIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_REAVTRCA")
        End Try

    End Function


    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_REAVTRCA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RATCIDRE, "
            stConsultaSQL += "RATCSECU, "
            stConsultaSQL += "RATCNUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "RATCFEEN, "
            stConsultaSQL += "RATCOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVTRCA, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RATCNUDO = USUANUDO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RATCIDRE DESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_REAVTRCA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVTRCA(ByVal inRATCSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RATCIDRE, "
            stConsultaSQL += "RATCSECU, "
            stConsultaSQL += "RATCNUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "RATCFEEN, "
            stConsultaSQL += "RATCOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVTRCA, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RATCNUDO = USUANUDO and "
            stConsultaSQL += "RATCSECU = '" & CInt(inRATCSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RATCIDRE DESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVTRCA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_REAVTRCA(ByVal inRATCSECU As Integer, ByVal stRATCNUDO As String, ByVal stRATCFEEN As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVTRCA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RATCSECU = '" & CInt(inRATCSECU) & "' and "
            stConsultaSQL += "RATCNUDO = '" & CStr(Trim(stRATCNUDO)) & "' and "
            stConsultaSQL += "RATCFEEN = '" & CStr(Trim(stRATCFEEN)) & "' "

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
    Public Function fun_Buscar_CODIGO_X_REAVTRCA(ByVal inRATCSECU As Integer, ByVal stRATCNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVTRCA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RATCSECU = '" & CInt(inRATCSECU) & "' and "
            stConsultaSQL += "RATCNUDO = '" & CStr(Trim(stRATCNUDO)) & "' "

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
