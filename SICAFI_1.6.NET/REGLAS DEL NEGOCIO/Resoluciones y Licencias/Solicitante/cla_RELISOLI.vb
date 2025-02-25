Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RELISOLI

    '==================================================
    '*** CLASE RESOLUCIONES Y LICENCIAS SOLICITANTE ***
    '==================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RELISOLI(ByVal inRLSONURA As Integer, _
                                                         ByVal stRLSOFERA As String, _
                                                         ByVal inRLSOSECU As Integer, _
                                                         ByVal obRLSONUDO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inRLSONURA) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(stRLSOFERA) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(inRLSOSECU) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRLSONUDO.Text) = True Then

                Dim objdatos1 As New cla_RELISOLI
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_RELISOLI(inRLSONURA, stRLSOFERA, inRLSOSECU, obRLSONUDO.Text)

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
    Public Function fun_Insertar_RELISOLI(ByVal inRLSONURA As Integer, _
                                          ByVal stRLSOFERA As String, _
                                          ByVal inRLSOSECU As Integer, _
                                          ByVal stRLSONUDO As String, _
                                          ByVal stRLSONOMB As String, _
                                          ByVal stRLSOPRAP As String, _
                                          ByVal stRLSOSEAP As String, _
                                          ByVal stRLSODIPR As String, _
                                          ByVal stRLSODINO As String, _
                                          ByVal stRLSOTELE As String, _
                                          ByVal stRLSOCELU As String, _
                                          ByVal stRLSOCOEL As String, _
                                          ByVal stRLSOCOPO As String, _
                                          ByVal stRLSORESO As String, _
                                          ByVal inRLSOSOLI As Integer) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RELISOLI "

            stConsultaSQL += "( "
            stConsultaSQL += "RLSONURA, "
            stConsultaSQL += "RLSOFERA, "
            stConsultaSQL += "RLSOSECU, "
            stConsultaSQL += "RLSONUDO, "
            stConsultaSQL += "RLSONOMB, "
            stConsultaSQL += "RLSOPRAP, "
            stConsultaSQL += "RLSOSEAP, "
            stConsultaSQL += "RLSODIPR, "
            stConsultaSQL += "RLSODINO, "
            stConsultaSQL += "RLSOTELE, "
            stConsultaSQL += "RLSOCELU, "
            stConsultaSQL += "RLSOCOEL, "
            stConsultaSQL += "RLSOCOPO, "
            stConsultaSQL += "RLSORESO, "
            stConsultaSQL += "RLSOSOLI "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRLSONURA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLSOFERA)) & "', "
            stConsultaSQL += "'" & CInt(inRLSOSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLSONUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLSONOMB)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLSOPRAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLSOSEAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLSODIPR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLSODINO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLSOTELE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLSOCELU)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLSOCOEL)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLSOCOPO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLSORESO)) & "', "
            stConsultaSQL += "'" & CInt(inRLSOSOLI) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RELISOLI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RELISOLI(ByVal inRLSOIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RELISOLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLSOIDRE = '" & CInt(inRLSOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RELISOLI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RELISOLI(ByVal inRLSOSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RELISOLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLSOSECU = '" & CInt(inRLSOSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RELISOLI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RELISOLI(ByVal inRLSOIDRE As Integer, _
                                            ByVal inRLSONURA As Integer, _
                                            ByVal stRLSOFERA As String, _
                                            ByVal inRLSOSECU As Integer, _
                                            ByVal stRLSONUDO As String, _
                                            ByVal stRLSONOMB As String, _
                                            ByVal stRLSOPRAP As String, _
                                            ByVal stRLSOSEAP As String, _
                                            ByVal stRLSODIPR As String, _
                                            ByVal stRLSODINO As String, _
                                            ByVal stRLSOTELE As String, _
                                            ByVal stRLSOCELU As String, _
                                            ByVal stRLSOCOEL As String, _
                                            ByVal stRLSOCOPO As String, _
                                            ByVal stRLSORESO As String, _
                                            ByVal inRLSOSOLI As Integer) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RELISOLI "

            stConsultaSQL += "SET "
            stConsultaSQL += "RLSONURA = '" & CInt(inRLSONURA) & "', "
            stConsultaSQL += "RLSOFERA = '" & CStr(Trim(stRLSOFERA)) & "', "
            stConsultaSQL += "RLSOSECU = '" & CInt(inRLSOSECU) & "', "
            stConsultaSQL += "RLSONUDO = '" & CStr(Trim(stRLSONUDO)) & "', "
            stConsultaSQL += "RLSONOMB = '" & CStr(Trim(stRLSONOMB)) & "', "
            stConsultaSQL += "RLSOPRAP = '" & CStr(Trim(stRLSOPRAP)) & "', "
            stConsultaSQL += "RLSOSEAP = '" & CStr(Trim(stRLSOSEAP)) & "', "
            stConsultaSQL += "RLSODIPR = '" & CStr(Trim(stRLSODIPR)) & "', "
            stConsultaSQL += "RLSODINO = '" & CStr(Trim(stRLSODINO)) & "', "
            stConsultaSQL += "RLSOTELE = '" & CStr(Trim(stRLSOTELE)) & "', "
            stConsultaSQL += "RLSOCELU = '" & CStr(Trim(stRLSOCELU)) & "', "
            stConsultaSQL += "RLSOCOEL = '" & CStr(Trim(stRLSOCOEL)) & "', "
            stConsultaSQL += "RLSOCOPO = '" & CStr(Trim(stRLSOCOPO)) & "', "
            stConsultaSQL += "RLSORESO = '" & CStr(Trim(stRLSORESO)) & "', "
            stConsultaSQL += "RLSOSOLI = '" & CInt(inRLSOSOLI) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLSOIDRE = '" & CInt(inRLSOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RELISOLI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RELISOLI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RLSOIDRE, "
            stConsultaSQL += "RLSONURA, "
            stConsultaSQL += "RLSOFERA, "
            stConsultaSQL += "RLSOSECU, "
            stConsultaSQL += "SOLIDESC, "
            stConsultaSQL += "RLSONUDO, "
            stConsultaSQL += "RLSONOMB, "
            stConsultaSQL += "RLSOPRAP, "
            stConsultaSQL += "RLSOSEAP, "
            stConsultaSQL += "RLSODIPR, "
            stConsultaSQL += "RLSODINO, "
            stConsultaSQL += "RLSOTELE, "
            stConsultaSQL += "RLSOCELU, "
            stConsultaSQL += "RLSOCOEL, "
            stConsultaSQL += "RLSOCOPO, "
            stConsultaSQL += "RLSORESO "


            stConsultaSQL += "FROM "
            stConsultaSQL += "RELISOLI, MANT_SOLICITANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLSOSOLI = SOLICODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RLSOIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RELISOLI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_RELISOLI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELISOLI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RLSOIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_RELISOLI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_RELISOLI(ByVal inRLSOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELISOLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLSOIDRE = '" & CInt(inRLSOIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_RELISOLI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RELISOLI(ByVal inRLSONURA As Integer, _
                                                 ByVal stRLSOFERA As String, _
                                                 ByVal inRLSOSECU As Integer, _
                                                 ByVal stRLSONUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELISOLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLSONURA = '" & CInt(inRLSONURA) & "'AND  "
            stConsultaSQL += "RLSOFERA = '" & CStr(Trim(stRLSOFERA)) & "' AND "
            stConsultaSQL += "RLSOSECU = '" & CInt(inRLSOSECU) & "'AND  "
            stConsultaSQL += "RLSONUDO = '" & CStr(Trim(stRLSONUDO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_RELISOLI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RELISOLI(ByVal inRLSOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RLSOIDRE, "
            stConsultaSQL += "RLSONURA, "
            stConsultaSQL += "RLSOFERA, "
            stConsultaSQL += "RLSOSECU, "
            stConsultaSQL += "SOLIDESC, "
            stConsultaSQL += "RLSONUDO, "
            stConsultaSQL += "RLSONOMB, "
            stConsultaSQL += "RLSOPRAP, "
            stConsultaSQL += "RLSOSEAP, "
            stConsultaSQL += "RLSODIPR, "
            stConsultaSQL += "RLSODINO, "
            stConsultaSQL += "RLSOTELE, "
            stConsultaSQL += "RLSOCELU, "
            stConsultaSQL += "RLSOCOEL, "
            stConsultaSQL += "RLSOCOPO, "
            stConsultaSQL += "RLSORESO "


            stConsultaSQL += "FROM "
            stConsultaSQL += "RELISOLI, MANT_SOLICITANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLSOSOLI = SOLICODI AND "
            stConsultaSQL += "RLSOIDRE = '" & CInt(inRLSOIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RLSOIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RELISOLI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RELISOLI(ByVal inRLSOSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RLSOIDRE, "
            stConsultaSQL += "RLSONURA, "
            stConsultaSQL += "RLSOFERA, "
            stConsultaSQL += "RLSOSECU, "
            stConsultaSQL += "SOLIDESC, "
            stConsultaSQL += "RLSONUDO, "
            stConsultaSQL += "RLSONOMB, "
            stConsultaSQL += "RLSOPRAP, "
            stConsultaSQL += "RLSOSEAP, "
            stConsultaSQL += "RLSODIPR, "
            stConsultaSQL += "RLSODINO, "
            stConsultaSQL += "RLSOTELE, "
            stConsultaSQL += "RLSOCELU, "
            stConsultaSQL += "RLSOCOEL, "
            stConsultaSQL += "RLSOCOPO, "
            stConsultaSQL += "RLSORESO "


            stConsultaSQL += "FROM "
            stConsultaSQL += "RELISOLI, MANT_SOLICITANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLSOSOLI = SOLICODI AND "
            stConsultaSQL += "RLSOSECU = '" & CInt(inRLSOSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RLSOIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RELISOLI")
            Return Nothing

        End Try

    End Function

End Class
