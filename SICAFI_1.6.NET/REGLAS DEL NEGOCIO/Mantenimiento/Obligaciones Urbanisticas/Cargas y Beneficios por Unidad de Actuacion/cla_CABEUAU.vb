Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CABEUAU

    '======================================================================
    '*** CARGAS Y BENEFICIOS POR UNIDADES DE ACTUACION DEL PLAN PARCIAL ***
    '======================================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_CABEUAU(ByVal inCBUARESO As Integer, _
                                                             ByVal stCBUAFECH As String, _
                                                             ByVal obCBUAUPP As Object, _
                                                             ByVal obCBUCBPP As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inCBUARESO) = True And
                 obVerifica.fun_Verificar_Campo_Lleno(stCBUAFECH) = True And
                 obVerifica.fun_Verificar_Campo_Lleno(obCBUAUPP.SelectedValue) = True And
                 obVerifica.fun_Verificar_Campo_Lleno(obCBUCBPP.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(inCBUARESO) = True And
                    obVerifica.fun_Verificar_Dato_Fecha(stCBUAFECH) = True And
                    obVerifica.fun_Verificar_Dato_Numerico(obCBUAUPP.SelectedValue) = True And
                    obVerifica.fun_Verificar_Dato_Numerico(obCBUCBPP.SelectedValue) = True Then

                    Dim objdatos1 As New cla_CABEUAU
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_CABEUAU(inCBUARESO, Trim(stCBUAFECH), Trim(obCBUAUPP.SelectedValue), Trim(obCBUCBPP.SelectedValue))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obCBUAUPP.Focus()
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
    Public Function fun_Insertar_MANT_CABEUAU(ByVal inCBUARESO As Integer, _
                                              ByVal stCBUAFECH As String, _
                                              ByVal inCBUAUAPP As Integer, _
                                              ByVal inCBUACBPP As Integer, _
                                              ByVal inCBUAVALO As Integer, _
                                              ByVal stCBUAESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_CABEUAU "

            stConsultaSQL += "( "
            stConsultaSQL += "CBUARESO, "
            stConsultaSQL += "CBUAFECH, "
            stConsultaSQL += "CBUAUAPP, "
            stConsultaSQL += "CBUACBPP, "
            stConsultaSQL += "CBUAVALO, "
            stConsultaSQL += "CBUAESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inCBUARESO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCBUAFECH)) & "', "
            stConsultaSQL += "'" & CInt(inCBUAUAPP) & "', "
            stConsultaSQL += "'" & CInt(inCBUACBPP) & "', "
            stConsultaSQL += "'" & CInt(inCBUAVALO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCBUAESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_CABEUAU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CABEUAU(ByVal inCBUAIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_CABEUAU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CBUAIDRE = '" & CInt(inCBUAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_CABEUAU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_CABEUAU(ByVal inCBUAIDRE As Integer, _
                                                ByVal inCBUARESO As Integer, _
                                                ByVal stCBUAFECH As String, _
                                                ByVal inCBUAUAPP As Integer, _
                                                ByVal inCBUACBPP As Integer, _
                                                ByVal inCBUAVALO As Integer, _
                                                ByVal stCBUAESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_CABEUAU "

            stConsultaSQL += "SET "
            stConsultaSQL += "CBUARESO = '" & CInt(inCBUARESO) & "', "
            stConsultaSQL += "CBUAFECH = '" & CStr(Trim(stCBUAFECH)) & "', "
            stConsultaSQL += "CBUAUAPP = '" & CInt(inCBUAUAPP) & "', "
            stConsultaSQL += "CBUACBPP = '" & CInt(inCBUACBPP) & "', "
            stConsultaSQL += "CBUAVALO = '" & CInt(inCBUAVALO) & "', "
            stConsultaSQL += "CBUAESTA = '" & CStr(Trim(stCBUAESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CBUAIDRE = '" & CInt(inCBUAIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_CABEUAU")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del enCBUAzado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CABEUAU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CBUAIDRE, "
            stConsultaSQL += "CBUARESO, "
            stConsultaSQL += "CBUAFECH, "
            stConsultaSQL += "PLPADESC, "
            stConsultaSQL += "CBPPDESC, "
            stConsultaSQL += "CBUAUAPP, "
            stConsultaSQL += "CBUAVALO, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "CBUAESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CABEUAU, ESTADO, MANT_PLANPARC, MANT_CABEPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CBUAESTA = ESTACODI AND "
            stConsultaSQL += "CBUACBPP = CBPPCODI AND "
            stConsultaSQL += "CBUARESO = PLPANURE AND "
            stConsultaSQL += "CBUAFECH = PLPAFERE "


            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CBUARESO, CBUAFECH, PLPADESC, CBPPDESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CABEUAU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_CABEUAU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CABEUAU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CBUARESO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_CABEUAU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_CABEUAU_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CABEUAU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CBUAESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CBUARESO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CABEUAU_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CABEUAU(ByVal inCBUAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CABEUAU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CBUAIDRE = '" & CInt(inCBUAIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_CABEUAU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_CABEUAU(ByVal inCBUARESO As Integer, _
                                              ByVal stCBUAFECH As String, _
                                              ByVal inCBUAUAPP As Integer, _
                                              ByVal inCBUACBPP As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CABEUAU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CBUARESO = '" & CInt(inCBUARESO) & "' AND "
            stConsultaSQL += "CBUAFECH = '" & CStr(Trim(stCBUAFECH)) & "' AND "
            stConsultaSQL += "CBUAUAPP = '" & CInt(inCBUAUAPP) & "' AND "
            stConsultaSQL += "CBUACBPP = '" & CInt(inCBUACBPP) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_CABEUAU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CABEUAU por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CABEUAU(ByVal inCBUAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CBUAIDRE, "
            stConsultaSQL += "CBUARESO, "
            stConsultaSQL += "CBUAFECH, "
            stConsultaSQL += "PLPADESC, "
            stConsultaSQL += "CBPPDESC, "
            stConsultaSQL += "CBUAUAPP, "
            stConsultaSQL += "CBUAVALO, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "CBUAESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CABEUAU, ESTADO, MANT_PLANPARC, MANT_CABEPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CBUAESTA = ESTACODI AND "
            stConsultaSQL += "CBUACBPP = CBPPCODI AND "
            stConsultaSQL += "CBUARESO = PLPANURE AND "
            stConsultaSQL += "CBUAFECH = PLPAFERE AND "
            stConsultaSQL += "CBUAIDRE = '" & CInt(inCBUAIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CBUARESO, CBUAFECH, PLPADESC, CBPPDESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CABEUAU")
            Return Nothing

        End Try

    End Function

End Class
