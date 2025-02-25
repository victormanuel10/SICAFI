Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RECLPROP

    '=======================================
    '*** CLASE RECTIFICACION PROPIETARIO ***
    '=======================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RECLPROP(ByVal obREPRSECU As Object, _
                                                         ByVal obREPRNUDO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obREPRSECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obREPRNUDO.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obREPRSECU.Text) = True Then

                    Dim objdatos1 As New cla_RECLPROP
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_RECLPROP(obREPRSECU.Text, obREPRNUDO.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        obREPRNUDO.Focus()
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
    Public Function fun_Insertar_RECLPROP(ByVal inREPRSECU As Integer, _
                                          ByVal stREPRNUDO As String, _
                                          ByVal stREPRNOMB As String, _
                                          ByVal stREPRPRAP As String, _
                                          ByVal stREPRSEAP As String, _
                                          ByVal stREPRMAIN As String, _
                                          ByVal inREPRROVC As Integer, _
                                          ByVal stREPRFOVC As String, _
                                          ByVal stREPRESTA As String) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RECLPROP "

            stConsultaSQL += "( "
            stConsultaSQL += "REPRSECU, "
            stConsultaSQL += "REPRNUDO, "
            stConsultaSQL += "REPRNOMB, "
            stConsultaSQL += "REPRPRAP, "
            stConsultaSQL += "REPRSEAP, "
            stConsultaSQL += "REPRMAIN, "
            stConsultaSQL += "REPRROVC, "
            stConsultaSQL += "REPRFOVC, "
            stConsultaSQL += "REPRESTA  "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inREPRSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREPRNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREPRNOMB)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREPRPRAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREPRSEAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREPRMAIN)) & "', "
            stConsultaSQL += "'" & CInt(inREPRROVC) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREPRFOVC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREPRESTA)) & "'  "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RECLPROP")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RECLPROP(ByVal inREPRIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REPRIDRE = '" & CInt(inREPRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RECLPROP")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RECLPROP(ByVal inREPRSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REPRSECU = '" & CInt(inREPRSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RECLPROP")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RECLPROP(ByVal inREPRIDRE As Integer, _
                                            ByVal inREPRSECU As Integer, _
                                            ByVal stREPRNUDO As String, _
                                            ByVal stREPRNOMB As String, _
                                            ByVal stREPRPRAP As String, _
                                            ByVal stREPRSEAP As String, _
                                            ByVal stREPRMAIN As String, _
                                            ByVal inREPRROVC As Integer, _
                                            ByVal stREPRFOVC As String, _
                                            ByVal stREPRESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RECLPROP "

            stConsultaSQL += "SET "
            stConsultaSQL += "REPRSECU = '" & CInt(inREPRSECU) & "', "
            stConsultaSQL += "REPRNUDO = '" & CStr(Trim(stREPRNUDO)) & "', "
            stConsultaSQL += "REPRNOMB = '" & CStr(Trim(stREPRNOMB)) & "', "
            stConsultaSQL += "REPRPRAP = '" & CStr(Trim(stREPRPRAP)) & "', "
            stConsultaSQL += "REPRSEAP = '" & CStr(Trim(stREPRSEAP)) & "', "
            stConsultaSQL += "REPRMAIN = '" & CStr(Trim(stREPRMAIN)) & "', "
            stConsultaSQL += "REPRROVC = '" & CInt(inREPRROVC) & "', "
            stConsultaSQL += "REPRFOVC = '" & CStr(Trim(stREPRFOVC)) & "', "
            stConsultaSQL += "REPRESTA = '" & CStr(Trim(stREPRESTA)) & "'  "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REPRIDRE = '" & CInt(inREPRIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RECLPROP")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RECLPROP() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REPRIDRE, "
            stConsultaSQL += "REPRNUDO, "
            stConsultaSQL += "REPRNOMB, "
            stConsultaSQL += "REPRPRAP, "
            stConsultaSQL += "REPRSEAP, "
            stConsultaSQL += "REPRMAIN, "
            stConsultaSQL += "REPRROVC, "
            stConsultaSQL += "REPRFOVC, "
            stConsultaSQL += "REPRESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLPROP, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REPRESTA = ESTACODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLPROP")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_RECLPROP() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLPROP "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_RECLPROP")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_RECLPROP_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REPRESTA = 'ac' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLPROP_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_RECLPROP(ByVal inREPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REPRIDRE = '" & CInt(inREPRIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_RECLPROP")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECLPROP(ByVal inREPRSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REPRSECU = '" & CInt(inREPRSECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RECLPROP")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_RADICADO_X_RECLPROP(ByVal inREPRRAMU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REPRRAMU = '" & CInt(inREPRRAMU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RECLPROP")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLPROP(ByVal inREPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REPRIDRE, "
            stConsultaSQL += "REPRNUDO, "
            stConsultaSQL += "REPRNOMB, "
            stConsultaSQL += "REPRPRAP, "
            stConsultaSQL += "REPRSEAP, "
            stConsultaSQL += "REPRMAIN, "
            stConsultaSQL += "REPRROVC, "
            stConsultaSQL += "REPRFOVC, "
            stConsultaSQL += "REPRESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLPROP, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REPRESTA = ESTACODI and "
            stConsultaSQL += "REPRIDRE = '" & CInt(inREPRIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLPROP")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia maxima
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_RECLPROP() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REPRSECU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLPROP "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_MAXINA_X_RECLPROP")
            Return Nothing
        End Try

    End Function

    Public Function fun_Buscar_CODIGO_X_RECLPROP(ByVal inREPRSECU As Integer, _
                                                 ByVal stREPRNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REPRSECU = '" & CInt(inREPRSECU) & "' and "
            stConsultaSQL += "REPRNUDO = '" & CStr(Trim(stREPRNUDO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_X_RECLPROP")
            Return Nothing
        End Try

    End Function


End Class
