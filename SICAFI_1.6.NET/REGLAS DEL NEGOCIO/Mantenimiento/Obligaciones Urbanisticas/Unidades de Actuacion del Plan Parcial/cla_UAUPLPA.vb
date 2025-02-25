Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_UAUPLPA

    '==============================================
    '*** UNIDADES DE ACTUACION DEL PLAN PARCIAL ***
    '==============================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_UAUPLPA(ByVal inUAPPRESO As Integer, ByVal stUAPPFECH As String, ByVal obUAPPUAU As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inUAPPRESO) = True And
                 obVerifica.fun_Verificar_Campo_Lleno(stUAPPFECH) = True And
                 obVerifica.fun_Verificar_Campo_Lleno(obUAPPUAU.Value) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(inUAPPRESO) = True And
                    obVerifica.fun_Verificar_Dato_Fecha(stUAPPFECH) = True And
                    obVerifica.fun_Verificar_Dato_Numerico(obUAPPUAU.Value) = True Then

                    Dim objdatos1 As New cla_UAUPLPA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_UAUPLPA(inUAPPRESO, Trim(stUAPPFECH), Trim(obUAPPUAU.Value))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obUAPPUAU.Focus()
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
    Public Function fun_Insertar_MANT_UAUPLPA(ByVal inUAPPRESO As Integer, _
                                              ByVal stUAPPFECH As String, _
                                              ByVal inUAPPUAU As Integer, _
                                              ByVal stUAPPESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' UAPPatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_UAUPLPA "

            stConsultaSQL += "( "
            stConsultaSQL += "UAPPRESO, "
            stConsultaSQL += "UAPPFECH, "
            stConsultaSQL += "UAPPUAU, "
            stConsultaSQL += "UAPPESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inUAPPRESO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stUAPPFECH)) & "', "
            stConsultaSQL += "'" & CInt(inUAPPUAU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stUAPPESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_UAUPLPA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_UAUPLPA(ByVal inUAPPIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' UAPPatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_UAUPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "UAPPIDRE = '" & CInt(inUAPPIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_UAUPLPA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_UAUPLPA(ByVal inUAPPIDRE As Integer, _
                                                ByVal inUAPPRESO As Integer, _
                                                ByVal stUAPPFECH As String, _
                                                ByVal inUAPPUAU As Integer, _
                                                ByVal stUAPPESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' UAPPatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_UAUPLPA "

            stConsultaSQL += "SET "
            stConsultaSQL += "UAPPRESO = '" & CInt(inUAPPRESO) & "', "
            stConsultaSQL += "UAPPFECH = '" & CStr(Trim(stUAPPFECH)) & "', "
            stConsultaSQL += "UAPPUAU = '" & CInt(inUAPPUAU) & "', "
            stConsultaSQL += "UAPPESTA = '" & CStr(Trim(stUAPPESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "UAPPIDRE = '" & CInt(inUAPPIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_UAUPLPA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del enUAPPzado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_UAUPLPA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "UAPPIDRE, "
            stConsultaSQL += "UAPPRESO, "
            stConsultaSQL += "UAPPFECH, "
            stConsultaSQL += "UAPPUAU, "
            stConsultaSQL += "PLPADESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "UAPPESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_UAUPLPA, ESTADO, MANT_PLANPARC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "UAPPESTA = ESTACODI AND "
            stConsultaSQL += "UAPPRESO = PLPANURE AND "
            stConsultaSQL += "UAPPFECH = PLPAFERE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "UAPPRESO, UAPPUAU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_UAUPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_UAUPLPA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' UAPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_UAUPLPA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "UAPPRESO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_UAUPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_UAUPLPA_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' UAPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_UAUPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "UAPPESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "UAPPRESO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_UAUPLPA_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_UAUPLPA(ByVal inUAPPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' UAPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_UAUPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "UAPPIDRE = '" & CInt(inUAPPIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_UAUPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_UAUPLPA(ByVal inUAPPRESO As Integer, ByVal stUAPPFECH As String, ByVal inUAPPUAU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' UAPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_UAUPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "UAPPRESO = '" & CInt(inUAPPRESO) & "' AND "
            stConsultaSQL += "UAPPFECH = '" & CStr(Trim(stUAPPFECH)) & "' AND "
            stConsultaSQL += "UAPPUAU = '" & CInt(inUAPPUAU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_UAUPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_UAU_X_PLANPARC_UAUPLPA(ByVal inUAPPRESO As Integer, ByVal stUAPPFECH As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' UAPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_UAUPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "UAPPRESO = '" & CInt(inUAPPRESO) & "' AND "
            stConsultaSQL += "UAPPFECH = '" & CStr(Trim(stUAPPFECH)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_UAUPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el UAUPLPA por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_UAUPLPA(ByVal inUAPPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' UAPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "UAPPIDRE, "
            stConsultaSQL += "UAPPRESO, "
            stConsultaSQL += "UAPPFECH, "
            stConsultaSQL += "UAPPUAU, "
            stConsultaSQL += "PLPADESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "UAPPESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_UAUPLPA, ESTADO, MANT_PLANPARC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "UAPPESTA = ESTACODI AND "
            stConsultaSQL += "UAPPRESO = PLPANURE AND "
            stConsultaSQL += "UAPPFECH = PLPAFERE AND "
            stConsultaSQL += "UAPPIDRE = '" & CInt(inUAPPIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "UAPPRESO, UAPPUAU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_UAUPLPA")
            Return Nothing

        End Try

    End Function

End Class
