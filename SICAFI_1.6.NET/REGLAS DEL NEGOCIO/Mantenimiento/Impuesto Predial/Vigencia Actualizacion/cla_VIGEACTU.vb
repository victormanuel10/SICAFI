Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_VIGEACTU

    '=======================================
    '*** CLASE VIGENCIA DE ACTUALIZACIÓN ***
    '=======================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_VIGEACTU(ByVal obVIACDEPA As Object, _
                                                         ByVal obVIACMUNI As Object, _
                                                         ByVal obVIACCLSE As Object, _
                                                         ByVal obVIACRESO As Object, _
                                                         ByVal obVIACVIAC As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obVIACDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obVIACMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obVIACCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obVIACVIAC.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obVIACRESO.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obVIACDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obVIACMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obVIACCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obVIACVIAC.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obVIACRESO.Text) = True Then

                    Dim objdatos1 As New cla_VIGEACTU
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RESO_VIAC_X_VIGEACTU(Trim(obVIACDEPA.SelectedValue), _
                                                                                          Trim(obVIACMUNI.SelectedValue), _
                                                                                          Trim(obVIACCLSE.SelectedValue), _
                                                                                          Trim(obVIACRESO.Text), _
                                                                                          Trim(obVIACVIAC.SelectedValue))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obVIACDEPA.Text & " - " & obVIACMUNI.Text & " - " & obVIACCLSE.Text & " - " & obVIACRESO.Text & " del campo " & obVIACRESO.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obVIACDEPA.Focus()
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
    Public Function fun_Insertar_VIGEACTU(ByVal stVIACDEPA As String, _
                                               ByVal stVIACMUNI As String, _
                                               ByVal inVIACCLSE As Integer, _
                                               ByVal inVIACRESO As Integer, _
                                               ByVal stVIACDESC As String, _
                                               ByVal inVIACVIAC As Integer, _
                                               ByVal stVIACPOIN As String, _
                                               ByVal boVIACACTU As Boolean, _
                                               ByVal boVIACCONS As Boolean, _
                                               ByVal stVIACESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "VIGEACTU "

            stConsultaSQL += "( "
            stConsultaSQL += "VIACDEPA, "
            stConsultaSQL += "VIACMUNI, "
            stConsultaSQL += "VIACCLSE, "
            stConsultaSQL += "VIACRESO, "
            stConsultaSQL += "VIACDESC, "
            stConsultaSQL += "VIACVIAC, "
            stConsultaSQL += "VIACPOIN, "
            stConsultaSQL += "VIACACTU, "
            stConsultaSQL += "VIACCONS, "
            stConsultaSQL += "VIACESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stVIACDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stVIACMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inVIACCLSE) & "', "
            stConsultaSQL += "'" & CInt(inVIACRESO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stVIACDESC)) & "', "
            stConsultaSQL += "'" & CInt(inVIACVIAC) & "', "
            stConsultaSQL += "'" & CStr(Trim(stVIACPOIN)) & "', "
            stConsultaSQL += "'" & CBool(boVIACACTU) & "', "
            stConsultaSQL += "'" & CBool(boVIACCONS) & "', "
            stConsultaSQL += "'" & CStr(Trim(stVIACESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_VIGEACTU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_VIGEACTU(ByVal inVIACIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "VIGEACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VIACIDRE = '" & CInt(inVIACIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_VIGEACTU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_VIGEACTU(ByVal inVIACIDRE As Integer, _
                                                 ByVal stVIACDEPA As String, _
                                                 ByVal stVIACMUNI As String, _
                                                 ByVal inVIACCLSE As Integer, _
                                                 ByVal inVIACRESO As Integer, _
                                                 ByVal stVIACDESC As String, _
                                                 ByVal inVIACVIAC As Integer, _
                                                 ByVal stVIACPOIN As String, _
                                                 ByVal boVIACACTU As Boolean, _
                                                 ByVal boVIACCONS As Boolean, _
                                                 ByVal stVIACESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "VIGEACTU "

            stConsultaSQL += "SET "
            stConsultaSQL += "VIACDEPA = '" & CStr(Trim(stVIACDEPA)) & "', "
            stConsultaSQL += "VIACMUNI = '" & CStr(Trim(stVIACMUNI)) & "', "
            stConsultaSQL += "VIACCLSE = '" & CInt(inVIACCLSE) & "', "
            stConsultaSQL += "VIACRESO = '" & CInt(inVIACRESO) & "', "
            stConsultaSQL += "VIACDESC = '" & CStr(Trim(stVIACDESC)) & "', "
            stConsultaSQL += "VIACVIAC = '" & CInt(inVIACVIAC) & "', "
            stConsultaSQL += "VIACPOIN = '" & CStr(Trim(stVIACPOIN)) & "', "
            stConsultaSQL += "VIACACTU = '" & CBool(boVIACACTU) & "', "
            stConsultaSQL += "VIACCONS = '" & CBool(boVIACCONS) & "', "
            stConsultaSQL += "VIACESTA = '" & CStr(Trim(stVIACESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VIACIDRE = '" & CInt(inVIACIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_VIGEACTU")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_VIGEACTU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "VIACIDRE, "
            stConsultaSQL += "VIACDEPA, "
            stConsultaSQL += "VIACMUNI, "
            stConsultaSQL += "VIACCLSE, "
            stConsultaSQL += "VIACRESO, "
            stConsultaSQL += "VIACDESC, "
            stConsultaSQL += "VIACVIAC, "
            stConsultaSQL += "VIACPOIN, "
            stConsultaSQL += "VIACACTU, "
            stConsultaSQL += "VIACCONS, "
            stConsultaSQL += "VIACESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "VIGEACTU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "VIACDEPA, VIACMUNI, VIACCLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_VIGEACTU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_VIGEACTU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "VIGEACTU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "VIACDEPA, VIACMUNI, VIACCLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_VIGEACTU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_VIGEACTU_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "VIGEACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VIACESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "VIACDEPA, VIACMUNI, VIACCLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_VIGEACTU_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_VIGEACTU(ByVal inVIACIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "VIGEACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VIACIDRE = '" & CInt(inVIACIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_VIGEACTU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_RESO_VIAC_X_VIGEACTU(ByVal stVIACDEPA As String, _
                                                                          ByVal stVIACMUNI As String, _
                                                                          ByVal inVIACCLSE As Integer, _
                                                                          ByVal inVIACRESO As Integer, _
                                                                          ByVal inVIACVIAC As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "VIGEACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VIACDEPA = '" & CStr(Trim(stVIACDEPA)) & "' and "
            stConsultaSQL += "VIACMUNI = '" & CStr(Trim(stVIACMUNI)) & "' and "
            stConsultaSQL += "VIACCLSE = '" & CInt(inVIACCLSE) & "' and "
            stConsultaSQL += "VIACRESO = '" & CInt(inVIACRESO) & "' and "
            stConsultaSQL += "VIACVIAC = '" & CInt(inVIACVIAC) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_VIGEACTU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_VIGEACTU(ByVal inVIACIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "VIACIDRE, "
            stConsultaSQL += "VIACDEPA, "
            stConsultaSQL += "VIACMUNI, "
            stConsultaSQL += "VIACCLSE, "
            stConsultaSQL += "VIACRESO, "
            stConsultaSQL += "VIACDESC, "
            stConsultaSQL += "VIACVIAC, "
            stConsultaSQL += "VIACPOIN, "
            stConsultaSQL += "VIACACTU, "
            stConsultaSQL += "VIACCONS, "
            stConsultaSQL += "VIACESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "VIGEACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VIACIDRE = '" & CInt(inVIACIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "VIACDEPA, VIACMUNI, VIACCLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_VIGEACTU")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIAC_X_VIGEACTU(ByVal stVIACDEPA As String, _
                                                                          ByVal stVIACMUNI As String, _
                                                                          ByVal inVIACCLSE As Integer, _
                                                                          ByVal inVIACVIAC As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "VIGEACTU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VIACDEPA = '" & CStr(Trim(stVIACDEPA)) & "' and "
            stConsultaSQL += "VIACMUNI = '" & CStr(Trim(stVIACMUNI)) & "' and "
            stConsultaSQL += "VIACCLSE = '" & CInt(inVIACCLSE) & "' and "
            stConsultaSQL += "VIACVIAC = '" & CInt(inVIACVIAC) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_VIGEACTU")
            Return Nothing
        End Try

    End Function

End Class
