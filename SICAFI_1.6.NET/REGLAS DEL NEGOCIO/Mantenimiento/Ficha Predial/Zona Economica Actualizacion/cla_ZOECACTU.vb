Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_ZOECACTU

    '==========================================
    '*** CLASE ZONA ECONOMICA ACTUALIZACION ***
    '==========================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_ZOECACTU(ByVal obZEACDEPA As Object, _
                                                              ByVal obZEACMUNI As Object, _
                                                              ByVal obZEACCLSE As Object, _
                                                              ByVal obZEACCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obZEACDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obZEACMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obZEACCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obZEACCODI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obZEACDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obZEACMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obZEACCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obZEACCODI.Text) = True Then

                    Dim objdatos1 As New cla_ZOECACTU
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_X_MANT_ZOECACTU(Trim(obZEACDEPA.SelectedValue), _
                                                                                Trim(obZEACMUNI.SelectedValue), _
                                                                                Trim(obZEACCLSE.SelectedValue), _
                                                                                Trim(obZEACCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obZEACDEPA.AccessibleDescription & " - " & obZEACMUNI.AccessibleDescription & " - " & obZEACCLSE.AccessibleDescription & " - " & obZEACCODI.Text & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obZEACDEPA.Focus()
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
    Public Function fun_Insertar_MANT_ZOECACTU(ByVal stZEACDEPA As String, _
                                               ByVal stZEACMUNI As String, _
                                               ByVal inZEACCLSE As Integer, _
                                               ByVal inZEACCODI As Integer, _
                                               ByVal loZEACVACO As Long, _
                                               ByVal loZEACVACA As Long, _
                                               ByVal stZEACDESC As String, _
                                               ByVal stZEACESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_ZOECACTU "

            stConsultaSQL += "( "
            stConsultaSQL += "ZEACDEPA, "
            stConsultaSQL += "ZEACMUNI, "
            stConsultaSQL += "ZEACCLSE, "
            stConsultaSQL += "ZEACCODI, "
            stConsultaSQL += "ZEACVACO, "
            stConsultaSQL += "ZEACVACA, "
            stConsultaSQL += "ZEACDESC, "
            stConsultaSQL += "ZEACESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stZEACDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stZEACMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inZEACCLSE) & "', "
            stConsultaSQL += "'" & CInt(inZEACCODI) & "', "
            stConsultaSQL += "'" & CLng(loZEACVACO) & "', "
            stConsultaSQL += "'" & CLng(loZEACVACA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stZEACDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stZEACESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_ZOECACTU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_ZOECACTU(ByVal inZEACIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_ZOECACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZEACIDRE = '" & CInt(inZEACIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_ZOECACTU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_ZOECACTU(ByVal inZEACIDRE As Integer, _
                                                 ByVal stZEACDEPA As String, _
                                                 ByVal stZEACMUNI As String, _
                                                 ByVal inZEACCLSE As Integer, _
                                                 ByVal inZEACCODI As Integer, _
                                                 ByVal loZEACVACO As Long, _
                                                 ByVal loZEACVACA As Long, _
                                                 ByVal stZEACDESC As String, _
                                                 ByVal stZEACESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_ZOECACTU "

            stConsultaSQL += "SET "
            stConsultaSQL += "ZEACDEPA = '" & CStr(Trim(stZEACDEPA)) & "', "
            stConsultaSQL += "ZEACMUNI = '" & CStr(Trim(stZEACMUNI)) & "', "
            stConsultaSQL += "ZEACCLSE = '" & CInt(inZEACCLSE) & "', "
            stConsultaSQL += "ZEACCODI = '" & CInt(inZEACCODI) & "', "
            stConsultaSQL += "ZEACVACO = '" & CLng(loZEACVACO) & "', "
            stConsultaSQL += "ZEACVACA = '" & CLng(loZEACVACA) & "', "
            stConsultaSQL += "ZEACDESC = '" & CStr(Trim(stZEACDESC)) & "', "
            stConsultaSQL += "ZEACESTA = '" & CStr(Trim(stZEACESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZEACIDRE = '" & CInt(inZEACIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_ZOECACTU")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_ZOECACTU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ZEACIDRE, "
            stConsultaSQL += "ZEACDEPA, "
            stConsultaSQL += "ZEACMUNI, "
            stConsultaSQL += "ZEACCLSE, "
            stConsultaSQL += "ZEACCODI, "
            stConsultaSQL += "ZEACVACO, "
            stConsultaSQL += "ZEACVACA, "
            stConsultaSQL += "ZEACDESC, "
            stConsultaSQL += "ZEACESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOECACTU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ZEACDEPA, ZEACMUNI, ZEACCLSE, ZEACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_ZOECACTU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_ZOECACTU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOECACTU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ZEACDEPA, ZEACMUNI, ZEACCLSE, ZEACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_ZOECACTU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_ZOECACTU_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOECACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZEACESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ZEACDEPA, ZEACMUNI, ZEACCLSE, ZEACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_ZOECACTU_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_ZOECACTU(ByVal inZEACIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOECACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZEACIDRE = '" & CInt(inZEACIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_ZOECACTU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_X_MANT_ZOECACTU(ByVal stZEACDEPA As String, _
                                                                ByVal stZEACMUNI As String, _
                                                                ByVal inZEACCLSE As Integer, _
                                                                ByVal stZEACCODI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOECACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZEACDEPA = '" & CStr(Trim(stZEACDEPA)) & "' and "
            stConsultaSQL += "ZEACMUNI = '" & CStr(Trim(stZEACMUNI)) & "' and "
            stConsultaSQL += "ZEACCLSE = '" & CInt(inZEACCLSE) & "' and "
            stConsultaSQL += "ZEACCODI = '" & CStr(Trim(stZEACCODI)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_ZOECACTU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_X_MANT_ZOECACTU(ByVal stZEACDEPA As String, _
                                                                ByVal stZEACMUNI As String, _
                                                                ByVal inZEACCLSE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOECACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZEACDEPA = '" & CStr(Trim(stZEACDEPA)) & "' and "
            stConsultaSQL += "ZEACMUNI = '" & CStr(Trim(stZEACMUNI)) & "' and "
            stConsultaSQL += "ZEACCLSE = '" & CInt(inZEACCLSE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_ZOECACTU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_ZOECACTU(ByVal inZEACIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ZEACIDRE, "
            stConsultaSQL += "ZEACDEPA, "
            stConsultaSQL += "ZEACMUNI, "
            stConsultaSQL += "ZEACCLSE, "
            stConsultaSQL += "ZEACCODI, "
            stConsultaSQL += "ZEACVACO, "
            stConsultaSQL += "ZEACVACA, "
            stConsultaSQL += "ZEACDESC, "
            stConsultaSQL += "ZEACESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOECACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZEACIDRE = '" & CInt(inZEACIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ZEACDEPA, ZEACMUNI, ZEACCLSE, ZEACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_ZOECACTU")
            Return Nothing

        End Try

    End Function

End Class
