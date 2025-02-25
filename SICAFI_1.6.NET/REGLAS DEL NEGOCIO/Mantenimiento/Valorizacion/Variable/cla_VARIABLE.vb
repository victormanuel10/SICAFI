Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_VARIABLE

    '================
    '*** VARIABLE ***
    '================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_VARIABLE(ByVal obVARITIVA As Object, ByVal obVARICODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obVARICODI.Text) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obVARITIVA.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obVARICODI.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obVARITIVA.SelectedValue) = True Then


                    Dim objdatos1 As New cla_VARIABLE
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_VARIABLE(obVARITIVA.SelectedValue, Trim(obVARICODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obVARITIVA.Text & " - " & obVARICODI.Text & " del campo " & obVARICODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obVARICODI.Focus()
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
    Public Function fun_Insertar_MANT_VARIABLE(ByVal inVARITIVA As Integer, _
                                               ByVal inVARICODI As Integer, _
                                               ByVal stVARIDESC As String, _
                                               ByVal stVARIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' VARIatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_VARIABLE "

            stConsultaSQL += "( "
            stConsultaSQL += "VARITIVA, "
            stConsultaSQL += "VARICODI, "
            stConsultaSQL += "VARIDESC, "
            stConsultaSQL += "VARIESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inVARITIVA) & "', "
            stConsultaSQL += "'" & CInt(inVARICODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stVARIDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stVARIESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_VARIABLE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_VARIABLE(ByVal inVARIIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' VARIatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_VARIABLE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VARIIDRE = '" & CInt(inVARIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_VARIABLE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_VARIABLE(ByVal inVARIIDRE As Integer, _
                                                 ByVal inVARITIVA As Integer, _
                                                 ByVal inVARICODI As Integer, _
                                                 ByVal stVARIDESC As String, _
                                                 ByVal stVARIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' VARIatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_VARIABLE "

            stConsultaSQL += "SET "
            stConsultaSQL += "VARITIVA = '" & CInt(inVARITIVA) & "', "
            stConsultaSQL += "VARICODI = '" & CInt(inVARICODI) & "', "
            stConsultaSQL += "VARIDESC = '" & CStr(Trim(stVARIDESC)) & "', "
            stConsultaSQL += "VARIESTA = '" & CStr(Trim(stVARIESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VARIIDRE = '" & CInt(inVARIIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_VARIABLE")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_VARIABLE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' VARIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "VARIIDRE, "
            stConsultaSQL += "VARITIVA, "
            stConsultaSQL += "TIVADESC, "
            stConsultaSQL += "VARICODI, "
            stConsultaSQL += "VARIDESC, "
            stConsultaSQL += "VARIESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VARIABLE, "
            stConsultaSQL += "MANT_TIPOVARI, "
            stConsultaSQL += "ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VARITIVA = TIVACODI AND "
            stConsultaSQL += "VARIESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "VARITIVA, VARICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_VARIABLE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_VARIABLE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' VARIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VARIABLE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "VARITIVA, VARICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_VARIABLE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_VARIABLE_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' VARIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VARIABLE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VARIESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "VARITIVA, VARICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_VARIABLE_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_VARIABLE(ByVal inVARIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' VARIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VARIABLE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VARIIDRE = '" & CInt(inVARIIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_VARIABLE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_VARIABLE(ByVal inVARITIVA As Integer, ByVal inVARICODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' VARIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VARIABLE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VARITIVA = '" & CInt(inVARITIVA) & "' and "
            stConsultaSQL += "VARICODI = '" & CInt(inVARICODI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_VARIABLE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el VARIABLE por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_VARIABLE(ByVal inVARIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' VARIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "VARIIDRE, "
            stConsultaSQL += "VARITIVA, "
            stConsultaSQL += "TIVADESC, "
            stConsultaSQL += "VARICODI, "
            stConsultaSQL += "VARIDESC, "
            stConsultaSQL += "VARIESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VARIABLE, "
            stConsultaSQL += "MANT_TIPOVARI, "
            stConsultaSQL += "ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VARITIVA = TIVACODI AND "
            stConsultaSQL += "VARIESTA = ESTACODI AND "
            stConsultaSQL += "VARIIDRE = '" & CInt(inVARIIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "VARITIVA, VARICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_VARIABLE")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el VARIABLE por tipo de impuesto
    ''' </summary>
    Public Function fun_Buscar_CODIGO_VARIABLE_X_TIPOVARI(ByVal inVARITIVA As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' VARIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VARIABLE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VARITIVA = '" & CInt(inVARITIVA) & "' "

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

    Public Function fun_Buscar_CODIGO_VARIABLE_X_TIPOVARI(ByVal inVARITIVA As Integer, ByVal inVARICODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' VARIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_VARIABLE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VARITIVA = '" & CInt(inVARITIVA) & "' AND "
            stConsultaSQL += "VARICODI = '" & CInt(inVARICODI) & "' "

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
