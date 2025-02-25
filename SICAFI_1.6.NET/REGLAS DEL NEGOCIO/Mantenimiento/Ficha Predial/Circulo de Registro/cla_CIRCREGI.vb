Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CIRCREGI

    '=================================
    '*** CLASE CIRCULO DE REGISTRO ***
    '=================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_CIRCREGI(ByVal obCIREDEPA As Object, _
                                                         ByVal obCIREMUNI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCIREDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obCIREMUNI.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obCIREDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obCIREMUNI.SelectedValue) = True Then

                    Dim objdatos1 As New cla_CIRCREGI
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_X_MANT_CIRCREGI(Trim(obCIREDEPA.SelectedValue), _
                                                                                          Trim(obCIREMUNI.SelectedValue))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obCIREDEPA.AccessibleDescription & " - " & obCIREMUNI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obCIREDEPA.Focus()
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
    Public Function fun_Insertar_MANT_CIRCREGI(ByVal stCIREDEPA As String, _
                                               ByVal stCIREMUNI As String, _
                                               ByVal stCIRECIRE As String, _
                                               ByVal stCIREDESC As String, _
                                               ByVal stCIREESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_CIRCREGI "

            stConsultaSQL += "( "
            stConsultaSQL += "CIREDEPA, "
            stConsultaSQL += "CIREMUNI, "
            stConsultaSQL += "CIRECIRE, "
            stConsultaSQL += "CIREDESC, "
            stConsultaSQL += "CIREESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stCIREDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCIREMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCIRECIRE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCIREDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCIREESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_CIRCREGI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CIRCREGI(ByVal inCIREIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_CIRCREGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CIREIDRE = '" & CInt(inCIREIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_CIRCREGI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_CIRCREGI(ByVal inCIREIDRE As Integer, _
                                                 ByVal stCIREDEPA As String, _
                                                 ByVal stCIREMUNI As String, _
                                                 ByVal stCIRECIRE As String, _
                                                 ByVal stCIREDESC As String, _
                                                 ByVal stCIREESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_CIRCREGI "

            stConsultaSQL += "SET "
            stConsultaSQL += "CIREDEPA = '" & CStr(Trim(stCIREDEPA)) & "', "
            stConsultaSQL += "CIREMUNI = '" & CStr(Trim(stCIREMUNI)) & "', "
            stConsultaSQL += "CIRECIRE = '" & CStr(Trim(stCIRECIRE)) & "', "
            stConsultaSQL += "CIREDESC = '" & CStr(Trim(stCIREDESC)) & "', "
            stConsultaSQL += "CIREESTA = '" & CStr(Trim(stCIREESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CIREIDRE = '" & CInt(inCIREIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_CIRCREGI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CIRCREGI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CIREIDRE, "
            stConsultaSQL += "CIREDEPA, "
            stConsultaSQL += "DEPADESC, "
            stConsultaSQL += "CIREMUNI, "
            stConsultaSQL += "MUNIDESC, "
            stConsultaSQL += "CIRECIRE, "
            stConsultaSQL += "CIREDESC, "
            stConsultaSQL += "CIREESTA, "
            stConsultaSQL += "ESTADESC  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CIRCREGI, MANT_DEPARTAMENTO, MANT_MUNICIPIO, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CIREDEPA = DEPACODI AND "
            stConsultaSQL += "CIREDEPA = MUNIDEPA AND "
            stConsultaSQL += "CIREMUNI = MUNICODI AND "
            stConsultaSQL += "CIREESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CIREDEPA, CIREMUNI, CIRECIRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CIRCREGI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_CIRCREGI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CIRCREGI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CIREDEPA, CIREMUNI, CIRECIRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_CIRCREGI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_CIRCREGI_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CIRCREGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CIREESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CIREDEPA, CIREMUNI, CIRECIRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CIRCREGI_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CIRCREGI(ByVal inCIREIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CIRCREGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CIREIDRE = '" & CInt(inCIREIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_CIRCREGI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_X_MANT_CIRCREGI(ByVal stCIREDEPA As String, _
                                                                ByVal stCIREMUNI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CIRCREGI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CIREDEPA = '" & CStr(Trim(stCIREDEPA)) & "' and "
            stConsultaSQL += "CIREMUNI = '" & CStr(Trim(stCIREMUNI)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_CIRCREGI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CIRCREGI(ByVal inCIREIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CIREIDRE, "
            stConsultaSQL += "CIREDEPA, "
            stConsultaSQL += "DEPADESC, "
            stConsultaSQL += "CIREMUNI, "
            stConsultaSQL += "MUNIDESC, "
            stConsultaSQL += "CIRECIRE, "
            stConsultaSQL += "CIREDESC, "
            stConsultaSQL += "CIREESTA, "
            stConsultaSQL += "ESTADESC  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CIRCREGI, MANT_DEPARTAMENTO, MANT_MUNICIPIO, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CIREDEPA = DEPACODI AND "
            stConsultaSQL += "CIREDEPA = MUNIDEPA AND "
            stConsultaSQL += "CIREMUNI = MUNICODI AND "
            stConsultaSQL += "CIREESTA = ESTACODI AND "
            stConsultaSQL += "CIREIDRE = '" & CInt(inCIREIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CIREDEPA, CIREMUNI, CIRECIRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CIRCREGI")
            Return Nothing

        End Try

    End Function

End Class
