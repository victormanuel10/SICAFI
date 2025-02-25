Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RESOLICE

    '======================================
    '*** CLASE RESOLUCIONES Y LICENCIAS ***
    '======================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RESOLICE(ByVal obRELINURA As Object, _
                                                         ByVal obRELIFERA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRELINURA.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRELIFERA.Text) = True Then

                Dim objdatos1 As New cla_RESOLICE
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_RESOLICE(obRELINURA.Text, obRELIFERA.Text)

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    boRespuesta = False
                Else
                    boRespuesta = True
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
    Public Function fun_Insertar_RESOLICE(ByVal inRELISECU As Integer, _
                                          ByVal stRELICLEN As String, _
                                          ByVal inRELINURA As Integer, _
                                          ByVal stRELIFERA As String, _
                                          ByVal inRELIVIGE As Integer, _
                                          ByVal stRELIFEAS As String, _
                                          ByVal inRELIMAIN As Integer, _
                                          ByVal stRELIOBSE As String, _
                                          ByVal stRELIESTA As String) As Boolean


        Try

            ' variables 
            Dim daRELIFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RESOLICE "

            stConsultaSQL += "( "
            stConsultaSQL += "RELISECU, "
            stConsultaSQL += "RELICLEN, "
            stConsultaSQL += "RELINURA, "
            stConsultaSQL += "RELIFERA, "
            stConsultaSQL += "RELIVIGE, "
            stConsultaSQL += "RELIFEAS, "
            stConsultaSQL += "RELIFEIN, "
            stConsultaSQL += "RELIMAIN, "
            stConsultaSQL += "RELIOBSE, "
            stConsultaSQL += "RELIESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRELISECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRELICLEN)) & "', "
            stConsultaSQL += "'" & CInt(inRELINURA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRELIFERA)) & "', "
            stConsultaSQL += "'" & CInt(inRELIVIGE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRELIFEAS)) & "', "
            stConsultaSQL += "'" & CDate(daRELIFEIN) & "', "
            stConsultaSQL += "'" & CInt(inRELIMAIN) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRELIOBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRELIESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RESOLICE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RESOLICE(ByVal inRELIIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RESOLICE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RELIIDRE = '" & CInt(inRELIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RESOLICE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RESOLICE(ByVal inRELISECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RESOLICE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RELISECU = '" & CInt(inRELISECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RESOLICE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RESOLICE(ByVal inRELIIDRE As Integer, _
                                            ByVal stRELICLEN As String, _
                                            ByVal inRELISECU As Integer, _
                                            ByVal inRELINURA As Integer, _
                                            ByVal stRELIFERA As String, _
                                            ByVal inRELIVIGE As Integer, _
                                            ByVal stRELIFEAS As String, _
                                            ByVal inRELIMAIN As Integer, _
                                            ByVal stRELIESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RESOLICE "

            stConsultaSQL += "SET "
            stConsultaSQL += "RELISECU = '" & CInt(inRELISECU) & "', "
            stConsultaSQL += "RELICLEN = '" & CStr(Trim(stRELICLEN)) & "', "
            stConsultaSQL += "RELINURA = '" & CInt(inRELINURA) & "', "
            stConsultaSQL += "RELIFERA = '" & CStr(Trim(stRELIFERA)) & "', "
            stConsultaSQL += "RELIVIGE = '" & CInt(inRELIVIGE) & "', "
            stConsultaSQL += "RELIFEAS = '" & CStr(Trim(stRELIFEAS)) & "', "
            stConsultaSQL += "RELIMAIN = '" & CInt(inRELIMAIN) & "', "
            stConsultaSQL += "RELIESTA = '" & CStr(Trim(stRELIESTA)) & "' "


            stConsultaSQL += "WHERE "
            stConsultaSQL += "RELIIDRE = '" & CInt(inRELIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RESOLICE")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RESOLICE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 0 "
            stConsultaSQL += "RELIIDRE, "
            stConsultaSQL += "RELISECU, "
            stConsultaSQL += "RELICLEN, "
            stConsultaSQL += "CLENDESC, "
            stConsultaSQL += "RELINURA, "
            stConsultaSQL += "RELIFERA, "
            stConsultaSQL += "RELIVIGE, "
            stConsultaSQL += "RELIFEAS, "
            stConsultaSQL += "RELIFEIN, "
            stConsultaSQL += "RELIMAIN, "
            stConsultaSQL += "RELIOBSE, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOLICE, MANT_CLASENTI, VIGENCIA, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RELICLEN = CLENCODI AND "
            stConsultaSQL += "RELIVIGE = VIGECODI AND "
            stConsultaSQL += "RELIESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RELISECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RESOLICE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_RESOLICE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOLICE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RELISECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_RESOLICE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_RESOLICE_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOLICE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RELIESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RELISECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RESOLICE_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_RESOLICE(ByVal inRELIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOLICE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RELIIDRE = '" & CInt(inRELIIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_RESOLICE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RESOLICE(ByVal inRELINURA As Integer, _
                                                 ByVal stRELIFERA As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOLICE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RELINURA = '" & CInt(inRELINURA) & "'AND  "
            stConsultaSQL += "RELIFERA = '" & CStr(Trim(stRELIFERA)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_RESOLICE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RESOLICE(ByVal inRELISECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOLICE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RELISECU = '" & CInt(inRELISECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RESOLICE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RESOLICE(ByVal inRELIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 1 "
            stConsultaSQL += "RELIIDRE, "
            stConsultaSQL += "RELISECU, "
            stConsultaSQL += "RELICLEN, "
            stConsultaSQL += "CLENDESC, "
            stConsultaSQL += "RELINURA, "
            stConsultaSQL += "RELIFERA, "
            stConsultaSQL += "RELIVIGE, "
            stConsultaSQL += "RELIFEAS, "
            stConsultaSQL += "RELIFEIN, "
            stConsultaSQL += "RELIMAIN, "
            stConsultaSQL += "RELIOBSE, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOLICE, MANT_CLASENTI, VIGENCIA, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RELICLEN = CLENCODI AND "
            stConsultaSQL += "RELIVIGE = VIGECODI AND "
            stConsultaSQL += "RELIESTA = ESTACODI AND "
            stConsultaSQL += "RELIIDRE = '" & CInt(inRELIIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RELISECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RESOLICE")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_RESOLICE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RELISECU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOLICE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_X_RESOLICE")
            Return Nothing
        End Try

    End Function

End Class
