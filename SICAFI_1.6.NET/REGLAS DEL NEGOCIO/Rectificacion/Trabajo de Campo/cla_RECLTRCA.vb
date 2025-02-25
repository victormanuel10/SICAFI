Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RECLTRCA

    '=======================================
    '*** CLASE TRABAJO DE CAMPO RECLAMOS ***
    '=======================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RECLTRCA(ByVal inRETCSECU As Integer, ByVal obRETCNUDO As Object, ByVal obRETCFEEN As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inRETCSECU) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRETCNUDO.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRETCFEEN.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(inRETCSECU) = True Then

                    Dim objdatos1 As New cla_RECLTRCA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_RECLTRCA(inRETCSECU, obRETCNUDO.Text, obRETCFEEN.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(inRETCSECU) & " - " & Trim(obRETCNUDO.Text) & " - " & Trim(obRETCFEEN.Text) & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obRETCNUDO.Focus()
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
    Public Function fun_Insertar_RECLTRCA(ByVal inRETCSECU As Integer, _
                                          ByVal stRETCNUDO As String, _
                                          ByVal stRETCFEEN As String, _
                                          ByVal stRETCOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RECLTRCA "

            stConsultaSQL += "( "
            stConsultaSQL += "RETCSECU, "
            stConsultaSQL += "RETCNUDO, "
            stConsultaSQL += "RETCFEEN, "
            stConsultaSQL += "RETCOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRETCSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRETCNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRETCFEEN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRETCOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RECLTRCA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RECLTRCA(ByVal inRETCIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLTRCA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RETCIDRE = '" & CInt(inRETCIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_RECLTRCA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_X_NUDO_RECLTRCA(ByVal inRETCSECU As Integer, ByVal stRETCNUDO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLTRCA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RETCSECU = '" & CInt(inRETCSECU) & "' and "
            stConsultaSQL += "RETCNUDO = '" & CStr(Trim(stRETCNUDO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_SECU_X_MACA_RECLTRCA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RECLTRCA(ByVal inRETCSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLTRCA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RETCSECU = '" & CInt(inRETCSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_RECLTRCA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RECLTRCA(ByVal inRETCIDRE As Integer, _
                                            ByVal inRETCSECU As Integer, _
                                            ByVal stRETCNUDO As String, _
                                            ByVal stRETCFEEN As String, _
                                            ByVal stRETCOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RECLTRCA "

            stConsultaSQL += "SET "
            stConsultaSQL += "RETCSECU = '" & CInt(inRETCSECU) & "', "
            stConsultaSQL += "RETCNUDO = '" & CStr(Trim(stRETCNUDO)) & "', "
            stConsultaSQL += "RETCFEEN = '" & CStr(Trim(stRETCFEEN)) & "', "
            stConsultaSQL += "RETCOBSE = '" & CStr(Trim(stRETCOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RETCIDRE = '" & CInt(inRETCIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RECLTRCA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RECLTRCA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RETCIDRE, "
            stConsultaSQL += "RETCSECU, "
            stConsultaSQL += "RETCNUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "RETCFEEN, "
            stConsultaSQL += "RETCOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLTRCA, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RETCNUDO = USUANUDO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RETCIDRE DESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLTRCA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLTRCA(ByVal inRETCSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RETCIDRE, "
            stConsultaSQL += "RETCSECU, "
            stConsultaSQL += "RETCNUDO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "RETCFEEN, "
            stConsultaSQL += "RETCOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLTRCA, USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RETCNUDO = USUANUDO and "
            stConsultaSQL += "RETCSECU = '" & CInt(inRETCSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RETCIDRE DESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLTRCA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECLTRCA(ByVal inRETCSECU As Integer, ByVal stRETCNUDO As String, ByVal stRETCFEEN As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLTRCA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RETCSECU = '" & CInt(inRETCSECU) & "' and "
            stConsultaSQL += "RETCNUDO = '" & CStr(Trim(stRETCNUDO)) & "' and "
            stConsultaSQL += "RETCFEEN = '" & CStr(Trim(stRETCFEEN)) & "' "

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
    Public Function fun_Buscar_CODIGO_X_RECLTRCA(ByVal inRETCSECU As Integer, ByVal stRETCNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLTRCA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RETCSECU = '" & CInt(inRETCSECU) & "' and "
            stConsultaSQL += "RETCNUDO = '" & CStr(Trim(stRETCNUDO)) & "' "

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
