Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CESIESPU

    '==============================
    '*** CESION ESPACIO PUBLICO ***
    '==============================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_CESIESPU(ByVal obCEEPDEVI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCEEPDEVI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obCEEPDEVI.Text) = True Then

                    Dim objdatos1 As New cla_CESIESPU
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_CESIESPU(Trim(obCEEPDEVI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obCEEPDEVI.Text & " del campo " & obCEEPDEVI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obCEEPDEVI.Focus()
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
    Public Function fun_Insertar_MANT_CESIESPU(ByVal inCEEPDEVI As Integer, _
                                               ByVal stCEEPDESC As String, _
                                               ByVal inCEEPARCE As Integer, _
                                               ByVal inCEEPOTUS As Integer, _
                                               ByVal inCEEPAMCE As Integer, _
                                               ByVal stCEEPESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CEEPatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_CESIESPU "

            stConsultaSQL += "( "
            stConsultaSQL += "CEEPDEVI, "
            stConsultaSQL += "CEEPDESC, "
            stConsultaSQL += "CEEPARCE, "
            stConsultaSQL += "CEEPOTUS, "
            stConsultaSQL += "CEEPAMCE, "
            stConsultaSQL += "CEEPESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inCEEPDEVI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEEPDESC)) & "', "
            stConsultaSQL += "'" & CInt(inCEEPARCE) & "', "
            stConsultaSQL += "'" & CInt(inCEEPOTUS) & "', "
            stConsultaSQL += "'" & CInt(inCEEPAMCE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEEPESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_CESIESPU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CESIESPU(ByVal inCEEPIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CEEPatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_CESIESPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEEPIDRE = '" & CInt(inCEEPIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_CESIESPU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_CESIESPU(ByVal inCEEPIDRE As Integer, _
                                                 ByVal inCEEPDEVI As Integer, _
                                                 ByVal stCEEPDESC As String, _
                                                 ByVal inCEEPARCE As Integer, _
                                                 ByVal inCEEPOTUS As Integer, _
                                                 ByVal inCEEPAMCE As Integer, _
                                                 ByVal stCEEPESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CEEPatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_CESIESPU "

            stConsultaSQL += "SET "
            stConsultaSQL += "CEEPDEVI = '" & CInt(inCEEPDEVI) & "', "
            stConsultaSQL += "CEEPDESC = '" & CStr(Trim(stCEEPDESC)) & "', "
            stConsultaSQL += "CEEPARCE = '" & CInt(inCEEPARCE) & "', "
            stConsultaSQL += "CEEPOTUS = '" & CInt(inCEEPOTUS) & "', "
            stConsultaSQL += "CEEPAMCE = '" & CInt(inCEEPAMCE) & "', "
            stConsultaSQL += "CEEPESTA = '" & CStr(Trim(stCEEPESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEEPIDRE = '" & CInt(inCEEPIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_CESIESPU")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CESIESPU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CEEPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CEEPIDRE, "
            stConsultaSQL += "CEEPDEVI, "
            stConsultaSQL += "CEEPDESC, "
            stConsultaSQL += "CEEPARCE, "
            stConsultaSQL += "CEEPOTUS, "
            stConsultaSQL += "CEEPAMCE, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "CEEPESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CESIESPU, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEEPESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CEEPDEVI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CESIESPU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_CESIESPU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CEEPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CESIESPU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CEEPDEVI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_CESIESPU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_CESIESPU_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CEEPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CESIESPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEEPESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CEEPDEVI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CESIESPU_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CESIESPU(ByVal inCEEPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CEEPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CESIESPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEEPIDRE = '" & CInt(inCEEPIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_CESIESPU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_CESIESPU(ByVal inCEEPDEVI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CEEPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CESIESPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEEPDEVI = '" & CInt(inCEEPDEVI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_CESIESPU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CESIESPU por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CESIESPU(ByVal inCEEPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' CEEPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CEEPIDRE, "
            stConsultaSQL += "CEEPDEVI, "
            stConsultaSQL += "CEEPDESC, "
            stConsultaSQL += "CEEPARCE, "
            stConsultaSQL += "CEEPOTUS, "
            stConsultaSQL += "CEEPAMCE, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "CEEPESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CESIESPU, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEEPESTA = ESTACODI AND "
            stConsultaSQL += "CEEPIDRE = '" & CInt(inCEEPIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CEEPDEVI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CESIESPU")
            Return Nothing

        End Try

    End Function

End Class
