Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_PERIODO

    '=====================
    '*** CLASE PERIODO ***
    '=====================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_PERIODO(ByVal obPERIVIGE As Object, ByVal obPERIMES As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obPERIVIGE.Text) = True And obVerifica.fun_Verificar_Campo_Lleno(obPERIMES.Text) = True Then
                If obVerifica.fun_Verificar_Dato_Numerico(obPERIVIGE.Text) = True And obVerifica.fun_Verificar_Dato_Numerico(obPERIMES.Text) = True Then

                    Dim objdatos1 As New cla_PERIODO
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_VIGENCIA_MES_MANT_PERIODO(Trim(obPERIVIGE.SelectedValue), Trim(obPERIMES.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obPERIVIGE.SelectedValue & " - " & obPERIMES.Text & " del campo " & obPERIVIGE.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obPERIVIGE.Focus()
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
    Public Function fun_Insertar_MANT_PERIODO(ByVal inPERIVIGE As Integer, _
                                              ByVal inPERIMES As Integer, _
                                               ByVal stPERIDESC As String, _
                                               ByVal boPERIAPLI As Boolean, _
                                               ByVal stPERIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_PERIODO "

            stConsultaSQL += "( "
            stConsultaSQL += "PERIVIGE, "
            stConsultaSQL += "PERIMES, "
            stConsultaSQL += "PERIDESC, "
            stConsultaSQL += "PERIAPLI, "
            stConsultaSQL += "PERIESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inPERIVIGE) & "', "
            stConsultaSQL += "'" & CInt(inPERIMES) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPERIDESC)) & "', "
            stConsultaSQL += "'" & CBool(boPERIAPLI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPERIESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_PERIODO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_PERIODO(ByVal inPERIIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_PERIODO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PERIIDRE = '" & CInt(inPERIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_PERIODO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_PERIODO(ByVal inPERIIDRE As Integer, _
                                                 ByVal inPERIVIGE As Integer, _
                                                 ByVal inPERIMES As Integer, _
                                                 ByVal stPERIDESC As String, _
                                                 ByVal boPERIAPLI As Boolean, _
                                                 ByVal stPERIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_PERIODO "

            stConsultaSQL += "SET "
            stConsultaSQL += "PERIVIGE = '" & CInt(inPERIVIGE) & "', "
            stConsultaSQL += "PERIMES = '" & CInt(inPERIMES) & "', "
            stConsultaSQL += "PERIDESC = '" & CStr(Trim(stPERIDESC)) & "', "
            stConsultaSQL += "PERIAPLI = '" & CBool(boPERIAPLI) & "', "
            stConsultaSQL += "PERIESTA = '" & CStr(Trim(stPERIESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PERIIDRE = '" & CInt(inPERIIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_PERIODO")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_PERIODO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PERIIDRE as 'Sec', "
            stConsultaSQL += "PERIVIGE as 'Vigencia', "
            stConsultaSQL += "PERIMES as 'Mes', "
            stConsultaSQL += "PERIDESC as 'Descripción', "
            stConsultaSQL += "PERIAPLI as 'Aplica', "
            stConsultaSQL += "PERIESTA as 'Estado' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PERIODO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PERIVIGE,PERIMES "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_PERIODO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_PERIODO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PERIODO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PERIVIGE,PERIMES "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_PERIODO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_PERIODO_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PERIODO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PERIESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PERIVIGE,PERIMES "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_PERIODO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_PERIODO(ByVal inPERIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PERIODO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PERIIDRE = '" & CInt(inPERIIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_PERIODO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_VIGENCIA_MES_MANT_PERIODO(ByVal inPERIVIGE As Integer, _
                                                                ByVal inPERIMES As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PERIODO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PERIVIGE = '" & CInt(inPERIVIGE) & "' and "
            stConsultaSQL += "PERIMES = '" & CInt(inPERIMES) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_PERIODO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_PERIODO(ByVal inPERIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PERIIDRE as 'Sec', "
            stConsultaSQL += "PERIVIGE as 'Vigencia', "
            stConsultaSQL += "PERIMES as 'Mes', "
            stConsultaSQL += "PERIDESC as 'Descripción', "
            stConsultaSQL += "PERIAPLI as 'Aplica', "
            stConsultaSQL += "PERIESTA as 'Estado' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PERIODO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PERIIDRE = '" & CInt(inPERIIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PERIVIGE, PERIMES "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_PERIODO")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el mes por vigencia
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MES_X_VIGENCIA(ByVal inPERIVIGE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' VARIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PERIODO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PERIVIGE = '" & CInt(inPERIVIGE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_VARIABLE_X_TIPOIMPU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el mes por vigencia
    ''' </summary>
    Public Function fun_Buscar_CODIGO_VIGENCIA_X_MES_X_PERIODO(ByVal inPERIVIGE As Integer, ByVal inPERIMES As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' VARIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_PERIODO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PERIVIGE = '" & CInt(inPERIVIGE) & "' AND "
            stConsultaSQL += "PERIMES = '" & CInt(inPERIMES) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_VARIABLE_X_TIPOIMPU")
            Return Nothing
        End Try

    End Function

End Class
