Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RUTADOGE

    '=======================================
    '*** CLASE RUTA DOCUMENTOS GENERALES ***
    '=======================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_RUTADOGE(ByVal obRUDGDEPA As Object, _
                                                              ByVal obRUDGMUNI As Object, _
                                                              ByVal obRUDGDOGE As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRUDGDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRUDGMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRUDGDOGE.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obRUDGDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRUDGMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRUDGDOGE.SelectedValue) = True Then

                    Dim objdatos1 As New cla_RUTADOGE
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_DOGE_X_MANT_RUTADOGE(Trim(obRUDGDEPA.SelectedValue), _
                                                                                     Trim(obRUDGMUNI.SelectedValue), _
                                                                                     Trim(obRUDGDOGE.SelectedValue))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obRUDGDEPA.Text) & " - " & Trim(obRUDGMUNI.Text) & " - " & " del campo " & obRUDGDOGE.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obRUDGDEPA.Focus()
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
    Public Function fun_Insertar_MANT_RUTADOGE(ByVal stRUDGDEPA As String, _
                                               ByVal stRUDGMUNI As String, _
                                               ByVal stRUDGDOGE As String, _
                                               ByVal stRUDGRUTA As String, _
                                               ByVal stRUDGESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_RUTADOGE "

            stConsultaSQL += "( "
            stConsultaSQL += "RUDGDEPA, "
            stConsultaSQL += "RUDGMUNI, "
            stConsultaSQL += "RUDGDOGE, "
            stConsultaSQL += "RUDGRUTA, "
            stConsultaSQL += "RUDGESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stRUDGDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUDGMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUDGDOGE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUDGRUTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRUDGESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_RUTADOGE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_RUTADOGE(ByVal inRUDGIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_RUTADOGE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUDGIDRE = '" & CInt(inRUDGIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_MANT_RUTADOGE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_RUTADOGE(ByVal inRUDGIDRE As Integer, _
                                                 ByVal stRUDGDEPA As String, _
                                                 ByVal stRUDGMUNI As String, _
                                                 ByVal stRUDGDOGE As String, _
                                                 ByVal stRUDGRUTA As String, _
                                                 ByVal stRUDGESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_RUTADOGE "

            stConsultaSQL += "SET "
            stConsultaSQL += "RUDGDEPA = '" & CStr(Trim(stRUDGDEPA)) & "', "
            stConsultaSQL += "RUDGMUNI = '" & CStr(Trim(stRUDGMUNI)) & "', "
            stConsultaSQL += "RUDGDOGE = '" & CStr(Trim(stRUDGDOGE)) & "', "
            stConsultaSQL += "RUDGRUTA = '" & CStr(Trim(stRUDGRUTA)) & "', "
            stConsultaSQL += "RUDGESTA = '" & CStr(Trim(stRUDGESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUDGIDRE = '" & CInt(inRUDGIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_RUTADOGE")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_RUTADOGE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RUDGIDRE, "
            stConsultaSQL += "RUDGDEPA, "
            stConsultaSQL += "RUDGMUNI, "
            stConsultaSQL += "RUDGDOGE, "
            stConsultaSQL += "RUDGRUTA, "
            stConsultaSQL += "RUDGESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTADOGE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUDGDEPA, RUDGMUNI, RUDGDOGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_RUTADOGE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_RUTADOGE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTADOGE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUDGDEPA, RUDGMUNI, RUDGDOGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_RUTADOGE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_RUTADOGE_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTADOGE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUDGESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUDGDEPA, RUDGMUNI, RUDGDOGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_RUTADOGE_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_RUTADOGE(ByVal inRUDGIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTADOGE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUDGIDRE = '" & CInt(inRUDGIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_RUTADOGE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_RUTADOGE(ByVal inRUDGIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RUDGIDRE, "
            stConsultaSQL += "RUDGDEPA, "
            stConsultaSQL += "RUDGMUNI, "
            stConsultaSQL += "RUDGDOGE, "
            stConsultaSQL += "RUDGRUTA, "
            stConsultaSQL += "RUDGESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTADOGE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUDGIDRE = '" & CInt(inRUDGIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RUDGDEPA, RUDGMUNI, RUDGCLSE, RUDGDOGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_RUTADOGE")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RUDG_X_MANT_RUTADOGE(ByVal stRUDGDEPA As String, _
                                                                          ByVal stRUDGMUNI As String, _
                                                                          ByVal inRUDGCLSE As Integer, _
                                                                          ByVal stRUDGDOGE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTADOGE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUDGDEPA = '" & CStr(Trim(stRUDGDEPA)) & "' and "
            stConsultaSQL += "RUDGMUNI = '" & CStr(Trim(stRUDGMUNI)) & "' and "
            stConsultaSQL += "RUDGCLSE = '" & CInt(inRUDGCLSE) & "' and "
            stConsultaSQL += "RUDGDOGE = '" & CStr(Trim(stRUDGDOGE)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_RUTADOGE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_DOGE_X_MANT_RUTADOGE(ByVal stRUDGDEPA As String, _
                                                                     ByVal stRUDGMUNI As String, _
                                                                     ByVal stRUDGDOGE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTADOGE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUDGDEPA = '" & CStr(Trim(stRUDGDEPA)) & "' and "
            stConsultaSQL += "RUDGMUNI = '" & CStr(Trim(stRUDGMUNI)) & "' and "
            stConsultaSQL += "RUDGDOGE = '" & CStr(Trim(stRUDGDOGE)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_RUTADOGE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_MANT_RUTADOGE(ByVal stRUDGDEPA As String, _
                                                                     ByVal stRUDGMUNI As String, _
                                                                     ByVal inRUDGCLSE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTADOGE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUDGDEPA = '" & CStr(Trim(stRUDGDEPA)) & "' and "
            stConsultaSQL += "RUDGMUNI = '" & CStr(Trim(stRUDGMUNI)) & "' and "
            stConsultaSQL += "RUDGCLSE = '" & CInt(inRUDGCLSE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_RUTADOGE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_DOCUGENE(ByVal stDOGEDEPA As String, _
                                                                ByVal stDOGEMUNI As String, _
                                                                ByVal inDOGECLSE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTADOGE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUDGDEPA = '" & CStr(Trim(stDOGEDEPA)) & "' and "
            stConsultaSQL += "RUDGMUNI = '" & CStr(Trim(stDOGEMUNI)) & "' and "
            stConsultaSQL += "RUDGCLSE = '" & CInt(inDOGECLSE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_BARRVERE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_DOGE_X_DOCUGENE(ByVal stDOGEDEPA As String, _
                                                                ByVal stDOGEMUNI As String, _
                                                                ByVal inDOGEDOGE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RUTADOGE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RUDGDEPA = '" & CStr(Trim(stDOGEDEPA)) & "' and "
            stConsultaSQL += "RUDGMUNI = '" & CStr(Trim(stDOGEMUNI)) & "' and "
            stConsultaSQL += "RUDGDOGE = '" & CInt(inDOGEDOGE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_BARRVERE")
            Return Nothing
        End Try

    End Function

End Class
