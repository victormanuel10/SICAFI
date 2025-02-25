Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CORREGIMIENTO

    '===========================
    '*** CLASE CORREGIMIENTO ***
    '===========================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_CORREGIMIENTO(ByVal obCORRDEPA As Object, _
                                                              ByVal obCORRMUNI As Object, _
                                                              ByVal obCORRCLSE As Object, _
                                                              ByVal obCORRCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCORRDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obCORRMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obCORRCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obCORRCODI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obCORRDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obCORRMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obCORRCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obCORRCODI.Text) = True Then

                    Dim objdatos1 As New cla_CORREGIMIENTO
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_X_CORREGIMIENTO(Trim(obCORRDEPA.SelectedValue), _
                                                                                          Trim(obCORRMUNI.SelectedValue), _
                                                                                          Trim(obCORRCLSE.SelectedValue), _
                                                                                          Trim(obCORRCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obCORRDEPA.Text & " - " & obCORRMUNI.Text & " - " & obCORRCLSE.Text & " del campo " & obCORRCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obCORRDEPA.Focus()
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
    Public Function fun_Insertar_CORREGIMIENTO(ByVal stCORRDEPA As String, _
                                               ByVal stCORRMUNI As String, _
                                               ByVal inCORRCLSE As Integer, _
                                               ByVal stCORRCODI As String, _
                                               ByVal stCORRDESC As String, _
                                               ByVal stCORRESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_CORREGIMIENTO "

            stConsultaSQL += "( "
            stConsultaSQL += "CORRDEPA, "
            stConsultaSQL += "CORRMUNI, "
            stConsultaSQL += "CORRCLSE, "
            stConsultaSQL += "CORRCODI, "
            stConsultaSQL += "CORRDESC, "
            stConsultaSQL += "CORRESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stCORRDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCORRMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inCORRCLSE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCORRCODI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCORRDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCORRESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_CORREGIMIENTO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CORREGIMIENTO(ByVal inCORRIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_CORREGIMIENTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CORRIDRE = '" & CInt(inCORRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_CORREGIMIENTO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_CORREGIMIENTO(ByVal inCORRIDRE As Integer, _
                                                 ByVal stCORRDEPA As String, _
                                                 ByVal stCORRMUNI As String, _
                                                 ByVal inCORRCLSE As Integer, _
                                                 ByVal stCORRCODI As String, _
                                                 ByVal stCORRDESC As String, _
                                                 ByVal stCORRESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_CORREGIMIENTO "

            stConsultaSQL += "SET "
            stConsultaSQL += "CORRDEPA = '" & CStr(Trim(stCORRDEPA)) & "', "
            stConsultaSQL += "CORRMUNI = '" & CStr(Trim(stCORRMUNI)) & "', "
            stConsultaSQL += "CORRCLSE = '" & CInt(inCORRCLSE) & "', "
            stConsultaSQL += "CORRCODI = '" & CStr(Trim(stCORRCODI)) & "', "
            stConsultaSQL += "CORRDESC = '" & CStr(Trim(stCORRDESC)) & "', "
            stConsultaSQL += "CORRESTA = '" & CStr(Trim(stCORRESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CORRIDRE = '" & CInt(inCORRIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_CORREGIMIENTO")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_CORREGIMIENTO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CORRIDRE, "
            stConsultaSQL += "CORRDEPA, "
            stConsultaSQL += "CORRMUNI, "
            stConsultaSQL += "CORRCLSE, "
            stConsultaSQL += "CORRCODI, "
            stConsultaSQL += "CORRDESC, "
            stConsultaSQL += "CORRESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CORREGIMIENTO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CORRDEPA, CORRMUNI, CORRCLSE, CORRCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CORREGIMIENTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_CORREGIMIENTO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CORREGIMIENTO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CORRDEPA, CORRMUNI, CORRCLSE, CORRCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_CORREGIMIENTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CORREGIMIENTO_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CORREGIMIENTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CORRESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CORRDEPA, CORRMUNI, CORRCLSE, CORRCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CORREGIMIENTO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_CORREGIMIENTO(ByVal inCORRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CORREGIMIENTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CORRIDRE = '" & CInt(inCORRIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_CORREGIMIENTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_CORREGIMIENTO(ByVal inCORRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CORRIDRE, "
            stConsultaSQL += "CORRDEPA, "
            stConsultaSQL += "CORRMUNI, "
            stConsultaSQL += "CORRCLSE, "
            stConsultaSQL += "CORRCODI, "
            stConsultaSQL += "CORRDESC, "
            stConsultaSQL += "CORRESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CORREGIMIENTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CORRIDRE = '" & CInt(inCORRIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CORRDEPA, CORRMUNI, CORRCLSE, CORRCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_CORREGIMIENTO")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_X_CORREGIMIENTO(ByVal stCORRDEPA As String, _
                                                                          ByVal stCORRMUNI As String, _
                                                                          ByVal inCORRCLSE As Integer, _
                                                                          ByVal stCORRCODI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CORREGIMIENTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CORRDEPA = '" & CStr(Trim(stCORRDEPA)) & "' and "
            stConsultaSQL += "CORRMUNI = '" & CStr(Trim(stCORRMUNI)) & "' and "
            stConsultaSQL += "CORRCLSE = '" & CInt(inCORRCLSE) & "' and "
            stConsultaSQL += "CORRCODI = '" & CStr(Trim(stCORRCODI)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_X_CORREGIMIENTO")
            Return Nothing
        End Try

    End Function
    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_CORREGIMIENTO(ByVal stCORRDEPA As String, _
                                                                     ByVal stCORRMUNI As String, _
                                                                     ByVal inCORRCLSE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CORREGIMIENTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CORRDEPA = '" & CStr(Trim(stCORRDEPA)) & "' and "
            stConsultaSQL += "CORRMUNI = '" & CStr(Trim(stCORRMUNI)) & "' and "
            stConsultaSQL += "CORRCLSE = '" & CInt(inCORRCLSE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_CORREGIMIENTO")
            Return Nothing
        End Try

    End Function

End Class
