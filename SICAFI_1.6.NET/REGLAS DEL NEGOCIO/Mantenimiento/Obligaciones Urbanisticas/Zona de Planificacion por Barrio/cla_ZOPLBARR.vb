Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_ZOPLBARR

    '==============================================
    '*** CLASE ZONA DE PLANIFICACION POR BARRIO ***
    '==============================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_ZOPLBARR(ByVal obZPBADEPA As Object, _
                                                         ByVal obZPBAMUNI As Object, _
                                                         ByVal obZPBACLSE As Object, _
                                                         ByVal obZPBACORR As Object, _
                                                         ByVal obZPBABARR As Object, _
                                                         ByVal obZPBAZOPL As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obZPBADEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obZPBAMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obZPBACLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obZPBACORR.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obZPBAZOPL.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obZPBABARR.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obZPBADEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obZPBAMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obZPBACLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obZPBACORR.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obZPBAZOPL.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obZPBABARR.SelectedValue) = True Then

                    Dim objdatos1 As New cla_ZOPLBARR
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_ZOPLBARR(Trim(obZPBADEPA.SelectedValue), _
                                                                 Trim(obZPBAMUNI.SelectedValue), _
                                                                 Trim(obZPBACLSE.SelectedValue), _
                                                                 Trim(obZPBACORR.SelectedValue), _
                                                                 Trim(obZPBABARR.SelectedValue), _
                                                                 Trim(obZPBAZOPL.SelectedValue))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obZPBADEPA.Focus()
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
    Public Function fun_Insertar_ZOPLBARR(ByVal stZPBADEPA As String, _
                                          ByVal stZPBAMUNI As String, _
                                          ByVal stZPBACORR As String, _
                                          ByVal stZPBABARR As String, _
                                          ByVal inZPBACLSE As Integer, _
                                          ByVal inZPBAZOPL As Integer, _
                                          ByVal stZPBAESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_ZOPLBARR "

            stConsultaSQL += "( "
            stConsultaSQL += "ZPBADEPA, "
            stConsultaSQL += "ZPBAMUNI, "
            stConsultaSQL += "ZPBACORR, "
            stConsultaSQL += "ZPBABARR, "
            stConsultaSQL += "ZPBACLSE, "
            stConsultaSQL += "ZPBAZOPL, "
            stConsultaSQL += "ZPBAESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stZPBADEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stZPBAMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stZPBACORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stZPBABARR)) & "', "
            stConsultaSQL += "'" & CInt(inZPBACLSE) & "', "
            stConsultaSQL += "'" & CInt(inZPBAZOPL) & "', "
            stConsultaSQL += "'" & CStr(Trim(stZPBAESTA)) & "'  "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_ZOPLBARR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_ZOPLBARR(ByVal inZPBAIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_ZOPLBARR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZPBAIDRE = '" & CInt(inZPBAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_ZOPLBARR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_ZOPLBARR(ByVal inZPBAIDRE As Integer, _
                                            ByVal stZPBADEPA As String, _
                                            ByVal stZPBAMUNI As String, _
                                            ByVal stZPBACORR As String, _
                                            ByVal stZPBABARR As String, _
                                            ByVal inZPBACLSE As Integer, _
                                            ByVal inZPBAZOPL As Integer, _
                                            ByVal stZPBAESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_ZOPLBARR "

            stConsultaSQL += "SET "
            stConsultaSQL += "ZPBADEPA = '" & CStr(Trim(stZPBADEPA)) & "', "
            stConsultaSQL += "ZPBAMUNI = '" & CStr(Trim(stZPBAMUNI)) & "', "
            stConsultaSQL += "ZPBACORR = '" & CStr(Trim(stZPBACORR)) & "', "
            stConsultaSQL += "ZPBABARR = '" & CStr(Trim(stZPBABARR)) & "', "
            stConsultaSQL += "ZPBACLSE = '" & CInt(inZPBACLSE) & "', "
            stConsultaSQL += "ZPBAZOPL = '" & CInt(inZPBAZOPL) & "', "
            stConsultaSQL += "ZPBAESTA = '" & CStr(Trim(stZPBAESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZPBAIDRE = '" & CInt(inZPBAIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_ZOPLBARR")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_ZOPLBARR() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ZPBAIDRE, "
            stConsultaSQL += "ZPBADEPA, "
            stConsultaSQL += "ZPBAMUNI, "
            stConsultaSQL += "ZPBACORR, "
            stConsultaSQL += "ZPBABARR, "
            stConsultaSQL += "ZPBACLSE, "
            stConsultaSQL += "ZPBAZOPL, "
            stConsultaSQL += "ZPBAESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOPLBARR "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ZPBACLSE, ZPBADEPA, ZPBAMUNI, ZPBACORR, ZPBABARR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_ZOPLBARR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_ZOPLBARR() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOPLBARR "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ZPBACLSE, ZPBADEPA, ZPBAMUNI, ZPBACORR, ZPBABARR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_ZOPLBARR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_ZOPLBARR_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOPLBARR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZPBAESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ZPBACLSE, ZPBADEPA, ZPBAMUNI, ZPBACORR, ZPBABARR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_ZOPLBARR_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_ZOPLBARR(ByVal inZPBAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOPLBARR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZPBAIDRE = '" & CInt(inZPBAIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_ZOPLBARR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_ZOPLBARR(ByVal inZPBAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ZPBAIDRE, "
            stConsultaSQL += "ZPBADEPA, "
            stConsultaSQL += "ZPBAMUNI, "
            stConsultaSQL += "ZPBACORR, "
            stConsultaSQL += "ZPBABARR, "
            stConsultaSQL += "ZPBACLSE, "
            stConsultaSQL += "ZPBAZOPL, "
            stConsultaSQL += "ZPBAESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOPLBARR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZPBAIDRE = '" & CInt(inZPBAIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ZPBACLSE, ZPBADEPA, ZPBAMUNI, ZPBACORR, ZPBABARR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_ZOPLBARR")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_ZOPLBARR(ByVal stZPBADEPA As String, _
                                                 ByVal stZPBAMUNI As String, _
                                                 ByVal inZPBACLSE As Integer, _
                                                 ByVal stZPBACORR As String, _
                                                 ByVal stZPBABARR As String, _
                                                 ByVal inZPBAZOPL As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOPLBARR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZPBADEPA = '" & CStr(Trim(stZPBADEPA)) & "' AND "
            stConsultaSQL += "ZPBAMUNI = '" & CStr(Trim(stZPBAMUNI)) & "' AND "
            stConsultaSQL += "ZPBACORR = '" & CStr(Trim(stZPBACORR)) & "' AND "
            stConsultaSQL += "ZPBABARR = '" & CStr(Trim(stZPBABARR)) & "' AND "
            stConsultaSQL += "ZPBACLSE = '" & CInt(inZPBACLSE) & "' AND "
            stConsultaSQL += "ZPBAZOPL = '" & CInt(inZPBAZOPL) & "'  "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_X_ZOPLBARR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_ZOPLBARR(ByVal stZPBADEPA As String, _
                                                 ByVal stZPBAMUNI As String, _
                                                 ByVal inZPBACLSE As Integer, _
                                                 ByVal stZPBACORR As String, _
                                                 ByVal stZPBABARR As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZOPLBARR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ZPBADEPA = '" & CStr(Trim(stZPBADEPA)) & "' AND "
            stConsultaSQL += "ZPBAMUNI = '" & CStr(Trim(stZPBAMUNI)) & "' AND "
            stConsultaSQL += "ZPBACORR = '" & CStr(Trim(stZPBACORR)) & "' AND "
            stConsultaSQL += "ZPBABARR = '" & CStr(Trim(stZPBABARR)) & "' AND "
            stConsultaSQL += "ZPBACLSE = '" & CInt(inZPBACLSE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_X_ZOPLBARR")
            Return Nothing
        End Try

    End Function

End Class
