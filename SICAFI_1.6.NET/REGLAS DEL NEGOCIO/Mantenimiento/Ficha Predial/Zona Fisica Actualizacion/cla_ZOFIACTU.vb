Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_ZOFIACTU

    '=======================================
    '*** CLASE ZONA FISICA ACTUALIZACION ***
    '=======================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_ZOFIACTU(ByVal obZFACDEPA As Object, _
                                                              ByVal obZFACMUNI As Object, _
                                                              ByVal obZFACCLSE As Object, _
                                                              ByVal obZFACCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obZFACDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obZFACMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obZFACCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obZFACCODI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obZFACDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obZFACMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obZFACCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obZFACCODI.Text) = True Then

                    Dim objdatos1 As New cla_ZOFIACTU
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_X_MANT_ZOFIACTU(Trim(obZFACDEPA.SelectedValue), _
                                                                                Trim(obZFACMUNI.SelectedValue), _
                                                                                Trim(obZFACCLSE.SelectedValue), _
                                                                                Trim(obZFACCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obZFACDEPA.AccessibleDescription & " - " & obZFACMUNI.AccessibleDescription & " - " & obZFACCLSE.AccessibleDescription & " - " & obZFACCODI.Text & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obZFACDEPA.Focus()
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
    Public Function fun_Insertar_MANT_ZOFIACTU(ByVal stZFACDEPA As String, _
                                               ByVal stZFACMUNI As String, _
                                               ByVal inZFACCLSE As Integer, _
                                               ByVal inZFACCODI As Integer, _
                                               ByVal stZFACDESC As String, _
                                               ByVal stZFACESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_ZOFIACTU "

            stConsultaSQL += "( "
            stConsultaSQL += "ZFACDEPA, "
            stConsultaSQL += "ZFACMUNI, "
            stConsultaSQL += "ZFACCLSE, "
            stConsultaSQL += "ZFACCODI, "
            stConsultaSQL += "ZFACDESC, "
            stConsultaSQL += "ZFACESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stZFACDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stZFACMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inZFACCLSE) & "', "
            stConsultaSQL += "'" & CInt(inZFACCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stZFACDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stZFACESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_ZOFIACTU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_ZOFIACTU(ByVal inZFACIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_ZOFIACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZFACIDRE = '" & CInt(inZFACIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_ZOFIACTU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_ZOFIACTU(ByVal inZFACIDRE As Integer, _
                                                 ByVal stZFACDEPA As String, _
                                                 ByVal stZFACMUNI As String, _
                                                 ByVal inZFACCLSE As Integer, _
                                                 ByVal inZFACCODI As Integer, _
                                                 ByVal stZFACDESC As String, _
                                                 ByVal stZFACESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_ZOFIACTU "

            stConsultaSQL += "SET "
            stConsultaSQL += "ZFACDEPA = '" & CStr(Trim(stZFACDEPA)) & "', "
            stConsultaSQL += "ZFACMUNI = '" & CStr(Trim(stZFACMUNI)) & "', "
            stConsultaSQL += "ZFACCLSE = '" & CInt(inZFACCLSE) & "', "
            stConsultaSQL += "ZFACCODI = '" & CInt(inZFACCODI) & "', "
            stConsultaSQL += "ZFACDESC = '" & CStr(Trim(stZFACDESC)) & "', "
            stConsultaSQL += "ZFACESTA = '" & CStr(Trim(stZFACESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZFACIDRE = '" & CInt(inZFACIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_ZOFIACTU")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_ZOFIACTU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ZFACIDRE, "
            stConsultaSQL += "ZFACDEPA, "
            stConsultaSQL += "ZFACMUNI, "
            stConsultaSQL += "ZFACCLSE, "
            stConsultaSQL += "ZFACCODI, "
            stConsultaSQL += "ZFACDESC, "
            stConsultaSQL += "ZFACESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOFIACTU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ZFACDEPA, ZFACMUNI, ZFACCLSE, ZFACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_ZOFIACTU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_ZOFIACTU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOFIACTU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ZFACDEPA, ZFACMUNI, ZFACCLSE, ZFACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_ZOFIACTU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_ZOFIACTU_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOFIACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZFACESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ZFACDEPA, ZFACMUNI, ZFACCLSE, ZFACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_ZOFIACTU_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_ZOFIACTU(ByVal inZFACIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOFIACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZFACIDRE = '" & CInt(inZFACIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_ZOFIACTU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_X_MANT_ZOFIACTU(ByVal stZFACDEPA As String, _
                                                                ByVal stZFACMUNI As String, _
                                                                ByVal inZFACCLSE As Integer, _
                                                                ByVal stZFACCODI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOFIACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZFACDEPA = '" & CStr(Trim(stZFACDEPA)) & "' and "
            stConsultaSQL += "ZFACMUNI = '" & CStr(Trim(stZFACMUNI)) & "' and "
            stConsultaSQL += "ZFACCLSE = '" & CInt(inZFACCLSE) & "' and "
            stConsultaSQL += "ZFACCODI = '" & CStr(Trim(stZFACCODI)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_ZOFIACTU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_X_MANT_ZOFIACTU(ByVal stZFACDEPA As String, _
                                                                ByVal stZFACMUNI As String, _
                                                                ByVal inZFACCLSE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOFIACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZFACDEPA = '" & CStr(Trim(stZFACDEPA)) & "' and "
            stConsultaSQL += "ZFACMUNI = '" & CStr(Trim(stZFACMUNI)) & "' and "
            stConsultaSQL += "ZFACCLSE = '" & CInt(inZFACCLSE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_ZOFIACTU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_ZOFIACTU(ByVal inZFACIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ZFACIDRE, "
            stConsultaSQL += "ZFACDEPA, "
            stConsultaSQL += "ZFACMUNI, "
            stConsultaSQL += "ZFACCLSE, "
            stConsultaSQL += "ZFACCODI, "
            stConsultaSQL += "ZFACDESC, "
            stConsultaSQL += "ZFACESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOFIACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZFACIDRE = '" & CInt(inZFACIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ZFACDEPA, ZFACMUNI, ZFACCLSE, ZFACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_ZOFIACTU")
            Return Nothing

        End Try

    End Function


End Class
