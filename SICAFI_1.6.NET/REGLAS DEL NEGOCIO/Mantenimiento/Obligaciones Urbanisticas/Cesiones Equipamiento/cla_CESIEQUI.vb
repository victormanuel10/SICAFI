Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CESIEQUI

    '===========================
    '*** CESION EQUIPAMIENTO ***
    '===========================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_CESIEQUI(ByVal obCEEQESSO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCEEQESSO.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obCEEQESSO.Text) = True Then

                    Dim objdatos1 As New cla_CESIEQUI
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_CESIEQUI(Trim(obCEEQESSO.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obCEEQESSO.Text & " del campo " & obCEEQESSO.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obCEEQESSO.Focus()
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
    Public Function fun_Insertar_MANT_CESIEQUI(ByVal inCEEQESSO As Integer, _
                                               ByVal stCEEQDESC As String, _
                                               ByVal stCEEQUNDE As String, _
                                               ByVal stCEEQEQSA As String, _
                                               ByVal stCEEQESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CEEQatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_CESIEQUI "

            stConsultaSQL += "( "
            stConsultaSQL += "CEEQESSO, "
            stConsultaSQL += "CEEQDESC, "
            stConsultaSQL += "CEEQUNDE, "
            stConsultaSQL += "CEEQEQSA, "
            stConsultaSQL += "CEEQESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inCEEQESSO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEEQDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEEQUNDE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEEQEQSA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEEQESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_CESIEQUI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CESIEQUI(ByVal inCEEQIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CEEQatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_CESIEQUI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEEQIDRE = '" & CInt(inCEEQIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_CESIEQUI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_CESIEQUI(ByVal inCEEQIDRE As Integer, _
                                                 ByVal inCEEQESSO As Integer, _
                                                 ByVal stCEEQDESC As String, _
                                                 ByVal stCEEQUNDE As String, _
                                                 ByVal stCEEQEQSA As String, _
                                                 ByVal stCEEQESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CEEQatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_CESIEQUI "

            stConsultaSQL += "SET "
            stConsultaSQL += "CEEQESSO = '" & CInt(inCEEQESSO) & "', "
            stConsultaSQL += "CEEQDESC = '" & CStr(Trim(stCEEQDESC)) & "', "
            stConsultaSQL += "CEEQUNDE = '" & CStr(Trim(stCEEQUNDE)) & "', "
            stConsultaSQL += "CEEQEQSA = '" & CStr(Trim(stCEEQEQSA)) & "', "
            stConsultaSQL += "CEEQESTA = '" & CStr(Trim(stCEEQESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEEQIDRE = '" & CInt(inCEEQIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_CESIEQUI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CESIEQUI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CEEQatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CEEQIDRE, "
            stConsultaSQL += "CEEQESSO, "
            stConsultaSQL += "CEEQDESC, "
            stConsultaSQL += "CEEQUNDE, "
            stConsultaSQL += "CEEQEQSA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "CEEQESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CESIEQUI, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEEQESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CEEQESSO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CESIEQUI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_CESIEQUI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CEEQatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CESIEQUI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CEEQESSO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_CESIEQUI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_CESIEQUI_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CEEQatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CESIEQUI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEEQESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CEEQESSO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CESIEQUI_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CESIEQUI(ByVal inCEEQIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CEEQatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CESIEQUI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEEQIDRE = '" & CInt(inCEEQIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_CESIEQUI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_CESIEQUI(ByVal inCEEQESSO As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CEEQatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CESIEQUI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEEQESSO = '" & CInt(inCEEQESSO) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_CESIEQUI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CESIEQUI por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CESIEQUI(ByVal inCEEQIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CEEQatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CEEQIDRE, "
            stConsultaSQL += "CEEQESSO, "
            stConsultaSQL += "CEEQDESC, "
            stConsultaSQL += "CEEQUNDE, "
            stConsultaSQL += "CEEQEQSA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "CEEQESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CESIEQUI, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEEQESTA = ESTACODI AND "
            stConsultaSQL += "CEEQIDRE = '" & CInt(inCEEQIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CEEQESSO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CESIEQUI")
            Return Nothing

        End Try

    End Function

End Class
