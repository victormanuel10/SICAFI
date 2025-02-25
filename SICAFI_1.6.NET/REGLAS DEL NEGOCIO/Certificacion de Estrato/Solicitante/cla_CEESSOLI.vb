Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CEESSOLI

    '======================================================
    '*** CLASE CERTIFICACION SOCIOECONOMICA SOLICITANTE ***
    '======================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_CEESSOLI(ByVal inCESONURA As Integer, _
                                                         ByVal stCESOFERA As String, _
                                                         ByVal obCESONUDO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inCESONURA) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(stCESOFERA) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obCESONUDO.Text) = True Then

                Dim objdatos1 As New cla_CEESSOLI
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_CEESSOLI(inCESONURA, stCESOFERA, obCESONUDO.Text)

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
    Public Function fun_Insertar_CEESSOLI(ByVal inCESOSECU As Integer, _
                                          ByVal inCESONURA As Integer, _
                                          ByVal stCESOFERA As String, _
                                          ByVal stCESONUDO As String, _
                                          ByVal inCESOSOLI As Integer, _
                                          ByVal stCESONOMB As String, _
                                          ByVal stCESOPRAP As String, _
                                          ByVal stCESOSEAP As String, _
                                          ByVal stCESODIPR As String, _
                                          ByVal stCESODINO As String, _
                                          ByVal stCESOTELE As String, _
                                          ByVal stCESOCELU As String, _
                                          ByVal stCESOCOEL As String, _
                                          ByVal stCESOCOPO As String, _
                                          ByVal stCESOPROY As String, _
                                          ByVal stCESORESO As String, _
                                          ByVal stCESOESTA As String) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "CEESSOLI "

            stConsultaSQL += "( "
            stConsultaSQL += "CESOSECU, "
            stConsultaSQL += "CESONURA, "
            stConsultaSQL += "CESOFERA, "
            stConsultaSQL += "CESONUDO, "
            stConsultaSQL += "CESOSOLI, "
            stConsultaSQL += "CESONOMB, "
            stConsultaSQL += "CESOPRAP, "
            stConsultaSQL += "CESOSEAP, "
            stConsultaSQL += "CESODIPR, "
            stConsultaSQL += "CESODINO, "
            stConsultaSQL += "CESOTELE, "
            stConsultaSQL += "CESOCELU, "
            stConsultaSQL += "CESOCOEL, "
            stConsultaSQL += "CESOCOPO, "
            stConsultaSQL += "CESOPROY, "
            stConsultaSQL += "CESORESO, "
            stConsultaSQL += "CESOESTA "

            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inCESOSECU) & "', "
            stConsultaSQL += "'" & CInt(inCESONURA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCESOFERA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCESONUDO)) & "', "
            stConsultaSQL += "'" & CInt(inCESOSOLI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCESONOMB)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCESOPRAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCESOSEAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCESODIPR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCESODINO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCESOTELE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCESOCELU)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCESOCOEL)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCESOCOPO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCESOPROY)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCESORESO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCESOESTA)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_CEESSOLI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_CEESSOLI(ByVal inCESOIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "CEESSOLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CESOIDRE = '" & CInt(inCESOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_CEESSOLI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_CEESSOLI(ByVal stCESOSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "CEESSOLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CESOSECU = '" & CInt(stCESOSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_CEESSOLI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_CEESSOLI(ByVal inCESOIDRE As Integer, _
                                            ByVal inCESOSECU As Integer, _
                                            ByVal inCESONURA As Integer, _
                                            ByVal stCESOFERA As String, _
                                            ByVal stCESONUDO As String, _
                                            ByVal inCESOSOLI As Integer, _
                                            ByVal stCESONOMB As String, _
                                            ByVal stCESOPRAP As String, _
                                            ByVal stCESOSEAP As String, _
                                            ByVal stCESODIPR As String, _
                                            ByVal stCESODINO As String, _
                                            ByVal stCESOTELE As String, _
                                            ByVal stCESOCELU As String, _
                                            ByVal stCESOCOEL As String, _
                                            ByVal stCESOCOPO As String, _
                                            ByVal stCESOPROY As String, _
                                            ByVal stCESORESO As String, _
                                            ByVal stCESOESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "CEESSOLI "

            stConsultaSQL += "SET "
            stConsultaSQL += "CESOSECU = '" & CInt(inCESOSECU) & "', "
            stConsultaSQL += "CESONURA = '" & CInt(inCESONURA) & "', "
            stConsultaSQL += "CESOFERA = '" & CStr(Trim(stCESOFERA)) & "', "
            stConsultaSQL += "CESONUDO = '" & CStr(Trim(stCESONUDO)) & "', "
            stConsultaSQL += "CESOSOLI = '" & CInt(inCESOSOLI) & "', "
            stConsultaSQL += "CESONOMB = '" & CStr(Trim(stCESONOMB)) & "', "
            stConsultaSQL += "CESOPRAP = '" & CStr(Trim(stCESOPRAP)) & "', "
            stConsultaSQL += "CESOSEAP = '" & CStr(Trim(stCESOSEAP)) & "', "
            stConsultaSQL += "CESODIPR = '" & CStr(Trim(stCESODIPR)) & "', "
            stConsultaSQL += "CESODINO = '" & CStr(Trim(stCESODINO)) & "', "
            stConsultaSQL += "CESOTELE = '" & CStr(Trim(stCESOTELE)) & "', "
            stConsultaSQL += "CESOCELU = '" & CStr(Trim(stCESOCELU)) & "', "
            stConsultaSQL += "CESOCOEL = '" & CStr(Trim(stCESOCOEL)) & "', "
            stConsultaSQL += "CESOCOPO = '" & CStr(Trim(stCESOCOPO)) & "', "
            stConsultaSQL += "CESOPROY = '" & CStr(Trim(stCESOPROY)) & "', "
            stConsultaSQL += "CESORESO = '" & CStr(Trim(stCESORESO)) & "', "
            stConsultaSQL += "CESOESTA = '" & CStr(Trim(stCESOESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CESOIDRE = '" & CInt(inCESOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_CEESSOLI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_CEESSOLI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CESOIDRE, "
            stConsultaSQL += "CESOSECU, "
            stConsultaSQL += "CESONURA, "
            stConsultaSQL += "CESOFERA, "
            stConsultaSQL += "CESOSOLI, "
            stConsultaSQL += "SOLIDESC, "
            stConsultaSQL += "CESONUDO, "
            stConsultaSQL += "CESONOMB, "
            stConsultaSQL += "CESOPRAP, "
            stConsultaSQL += "CESOSEAP, "
            stConsultaSQL += "CESODIPR, "
            stConsultaSQL += "CESODINO, "
            stConsultaSQL += "CESOTELE, "
            stConsultaSQL += "CESOCELU, "
            stConsultaSQL += "CESOCOEL, "
            stConsultaSQL += "CESOCOPO, "
            stConsultaSQL += "CESOPROY, "
            stConsultaSQL += "CESORESO, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "CESOESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CEESSOLI, MANT_SOLICITANTE, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CESOSOLI = SOLICODI AND "
            stConsultaSQL += "CESOESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CESOIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CEESSOLI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_CEESSOLI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CEESSOLI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CESOIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_CEESSOLI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_CEESSOLI(ByVal inCESOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CEESSOLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CESOIDRE = '" & CInt(inCESOIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_CEESSOLI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_CEESSOLI(ByVal inCESONURA As Integer, _
                                                 ByVal stCESOFERA As String, _
                                                 ByVal stCESONUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CEESSOLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CESONURA = '" & CInt(inCESONURA) & "'AND  "
            stConsultaSQL += "CESOFERA = '" & CStr(Trim(stCESOFERA)) & "' AND "
            stConsultaSQL += "CESONUDO = '" & CStr(Trim(stCESONUDO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_CEESSOLI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_CEESSOLI(ByVal inCESOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CESOIDRE, "
            stConsultaSQL += "CESOSECU, "
            stConsultaSQL += "CESONURA, "
            stConsultaSQL += "CESOFERA, "
            stConsultaSQL += "CESOSOLI, "
            stConsultaSQL += "SOLIDESC, "
            stConsultaSQL += "CESONUDO, "
            stConsultaSQL += "CESONOMB, "
            stConsultaSQL += "CESOPRAP, "
            stConsultaSQL += "CESOSEAP, "
            stConsultaSQL += "CESODIPR, "
            stConsultaSQL += "CESODINO, "
            stConsultaSQL += "CESOTELE, "
            stConsultaSQL += "CESOCELU, "
            stConsultaSQL += "CESOCOEL, "
            stConsultaSQL += "CESOCOPO, "
            stConsultaSQL += "CESOPROY, "
            stConsultaSQL += "CESORESO, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "CESOESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CEESSOLI, MANT_SOLICITANTE, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CESOSOLI = SOLICODI AND "
            stConsultaSQL += "CESOESTA = ESTACODI AND "
            stConsultaSQL += "CESOIDRE = '" & CInt(inCESOIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CESOIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_CEESSOLI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_CEESSOLI(ByVal stCESOSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CESOIDRE, "
            stConsultaSQL += "CESOSECU, "
            stConsultaSQL += "CESONURA, "
            stConsultaSQL += "CESOFERA, "
            stConsultaSQL += "CESOSOLI, "
            stConsultaSQL += "SOLIDESC, "
            stConsultaSQL += "CESONUDO, "
            stConsultaSQL += "CESONOMB, "
            stConsultaSQL += "CESOPRAP, "
            stConsultaSQL += "CESOSEAP, "
            stConsultaSQL += "CESODIPR, "
            stConsultaSQL += "CESODINO, "
            stConsultaSQL += "CESOTELE, "
            stConsultaSQL += "CESOCELU, "
            stConsultaSQL += "CESOCOEL, "
            stConsultaSQL += "CESOCOPO, "
            stConsultaSQL += "CESOPROY, "
            stConsultaSQL += "CESORESO, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "CESOESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CEESSOLI, MANT_SOLICITANTE, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CESOSOLI = SOLICODI AND "
            stConsultaSQL += "CESOESTA = ESTACODI AND "
            stConsultaSQL += "CESOSECU = '" & CInt(stCESOSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CESOIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_CEESSOLI")
            Return Nothing

        End Try

    End Function


End Class
