Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_LIRASOLI

    '=========================================
    '*** CLASE LIBRO RADICADOR SOLICITANTE ***
    '=========================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_LIRASOLI(ByVal inLRSONURA As Integer, _
                                                         ByVal stLRSOFERA As String, _
                                                         ByVal inLRSOSECU As Integer, _
                                                         ByVal obLRSONUDO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inLRSONURA) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(stLRSOFERA) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(inLRSOSECU) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obLRSONUDO.Text) = True Then

                Dim objdatos1 As New cla_LIRASOLI
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_LIRASOLI(inLRSONURA, stLRSOFERA, inLRSOSECU, obLRSONUDO.Text)

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
    Public Function fun_Insertar_LIRASOLI(ByVal inLRSONURA As Integer, _
                                          ByVal stLRSOFERA As String, _
                                          ByVal inLRSOSECU As Integer, _
                                          ByVal stLRSONUDO As String, _
                                          ByVal stLRSONOMB As String, _
                                          ByVal stLRSOPRAP As String, _
                                          ByVal stLRSOSEAP As String, _
                                          ByVal stLRSODIPR As String, _
                                          ByVal stLRSODINO As String, _
                                          ByVal stLRSOTELE As String, _
                                          ByVal stLRSOCELU As String, _
                                          ByVal stLRSOCOEL As String, _
                                          ByVal stLRSOCOPO As String, _
                                          ByVal stLRSORESO As String, _
                                          ByVal inLRSOSOLI As Integer) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "LIRASOLI "

            stConsultaSQL += "( "
            stConsultaSQL += "LRSONURA, "
            stConsultaSQL += "LRSOFERA, "
            stConsultaSQL += "LRSOSECU, "
            stConsultaSQL += "LRSONUDO, "
            stConsultaSQL += "LRSONOMB, "
            stConsultaSQL += "LRSOPRAP, "
            stConsultaSQL += "LRSOSEAP, "
            stConsultaSQL += "LRSODIPR, "
            stConsultaSQL += "LRSODINO, "
            stConsultaSQL += "LRSOTELE, "
            stConsultaSQL += "LRSOCELU, "
            stConsultaSQL += "LRSOCOEL, "
            stConsultaSQL += "LRSOCOPO, "
            stConsultaSQL += "LRSORESO, "
            stConsultaSQL += "LRSOSOLI "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inLRSONURA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRSOFERA)) & "', "
            stConsultaSQL += "'" & CInt(inLRSOSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRSONUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRSONOMB)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRSOPRAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRSOSEAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRSODIPR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRSODINO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRSOTELE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRSOCELU)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRSOCOEL)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRSOCOPO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRSORESO)) & "', "
            stConsultaSQL += "'" & CInt(inLRSOSOLI) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_LIRASOLI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_LIRASOLI(ByVal inLRSOIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "LIRASOLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRSOIDRE = '" & CInt(inLRSOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_LIRASOLI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_LIRASOLI(ByVal inLRSOSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "LIRASOLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRSOSECU = '" & CInt(inLRSOSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_LIRASOLI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_LIRASOLI(ByVal inLRSOIDRE As Integer, _
                                            ByVal inLRSONURA As Integer, _
                                            ByVal stLRSOFERA As String, _
                                            ByVal inLRSOSECU As Integer, _
                                            ByVal stLRSONUDO As String, _
                                            ByVal stLRSONOMB As String, _
                                            ByVal stLRSOPRAP As String, _
                                            ByVal stLRSOSEAP As String, _
                                            ByVal stLRSODIPR As String, _
                                            ByVal stLRSODINO As String, _
                                            ByVal stLRSOTELE As String, _
                                            ByVal stLRSOCELU As String, _
                                            ByVal stLRSOCOEL As String, _
                                            ByVal stLRSOCOPO As String, _
                                            ByVal stLRSORESO As String, _
                                            ByVal inLRSOSOLI As Integer) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "LIRASOLI "

            stConsultaSQL += "SET "
            stConsultaSQL += "LRSONURA = '" & CInt(inLRSONURA) & "', "
            stConsultaSQL += "LRSOFERA = '" & CStr(Trim(stLRSOFERA)) & "', "
            stConsultaSQL += "LRSOSECU = '" & CInt(inLRSOSECU) & "', "
            stConsultaSQL += "LRSONUDO = '" & CStr(Trim(stLRSONUDO)) & "', "
            stConsultaSQL += "LRSONOMB = '" & CStr(Trim(stLRSONOMB)) & "', "
            stConsultaSQL += "LRSOPRAP = '" & CStr(Trim(stLRSOPRAP)) & "', "
            stConsultaSQL += "LRSOSEAP = '" & CStr(Trim(stLRSOSEAP)) & "', "
            stConsultaSQL += "LRSODIPR = '" & CStr(Trim(stLRSODIPR)) & "', "
            stConsultaSQL += "LRSODINO = '" & CStr(Trim(stLRSODINO)) & "', "
            stConsultaSQL += "LRSOTELE = '" & CStr(Trim(stLRSOTELE)) & "', "
            stConsultaSQL += "LRSOCELU = '" & CStr(Trim(stLRSOCELU)) & "', "
            stConsultaSQL += "LRSOCOEL = '" & CStr(Trim(stLRSOCOEL)) & "', "
            stConsultaSQL += "LRSOCOPO = '" & CStr(Trim(stLRSOCOPO)) & "', "
            stConsultaSQL += "LRSORESO = '" & CStr(Trim(stLRSORESO)) & "', "
            stConsultaSQL += "LRSOSOLI = '" & CInt(inLRSOSOLI) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRSOIDRE = '" & CInt(inLRSOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_LIRASOLI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_LIRASOLI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "LRSOIDRE, "
            stConsultaSQL += "LRSONURA, "
            stConsultaSQL += "LRSOFERA, "
            stConsultaSQL += "LRSOSECU, "
            stConsultaSQL += "SOLIDESC, "
            stConsultaSQL += "LRSONUDO, "
            stConsultaSQL += "LRSONOMB, "
            stConsultaSQL += "LRSOPRAP, "
            stConsultaSQL += "LRSOSEAP, "
            stConsultaSQL += "LRSODIPR, "
            stConsultaSQL += "LRSODINO, "
            stConsultaSQL += "LRSOTELE, "
            stConsultaSQL += "LRSOCELU, "
            stConsultaSQL += "LRSOCOEL, "
            stConsultaSQL += "LRSOCOPO, "
            stConsultaSQL += "LRSORESO "


            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRASOLI, MANT_SOLICITANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRSOSOLI = SOLICODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LRSOIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_LIRASOLI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_LIRASOLI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRASOLI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LRSOIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_LIRASOLI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_LIRASOLI(ByVal inLRSOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRASOLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRSOIDRE = '" & CInt(inLRSOIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_LIRASOLI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_LIRASOLI(ByVal inLRSONURA As Integer, _
                                                 ByVal stLRSOFERA As String, _
                                                 ByVal inLRSOSECU As Integer, _
                                                 ByVal stLRSONUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRASOLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRSONURA = '" & CInt(inLRSONURA) & "'AND  "
            stConsultaSQL += "LRSOFERA = '" & CStr(Trim(stLRSOFERA)) & "' AND "
            stConsultaSQL += "LRSOSECU = '" & CInt(inLRSOSECU) & "'AND  "
            stConsultaSQL += "LRSONUDO = '" & CStr(Trim(stLRSONUDO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_LIRASOLI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LIRASOLI(ByVal inLRSOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "LRSOIDRE, "
            stConsultaSQL += "LRSONURA, "
            stConsultaSQL += "LRSOFERA, "
            stConsultaSQL += "LRSOSECU, "
            stConsultaSQL += "SOLIDESC, "
            stConsultaSQL += "LRSONUDO, "
            stConsultaSQL += "LRSONOMB, "
            stConsultaSQL += "LRSOPRAP, "
            stConsultaSQL += "LRSOSEAP, "
            stConsultaSQL += "LRSODIPR, "
            stConsultaSQL += "LRSODINO, "
            stConsultaSQL += "LRSOTELE, "
            stConsultaSQL += "LRSOCELU, "
            stConsultaSQL += "LRSOCOEL, "
            stConsultaSQL += "LRSOCOPO, "
            stConsultaSQL += "LRSORESO "


            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRASOLI, MANT_SOLICITANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRSOSOLI = SOLICODI AND "
            stConsultaSQL += "LRSOIDRE = '" & CInt(inLRSOIDRE) & "'"
          
            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LRSOIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LIRASOLI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_LIRASOLI(ByVal inLRSOSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "LRSOIDRE, "
            stConsultaSQL += "LRSONURA, "
            stConsultaSQL += "LRSOFERA, "
            stConsultaSQL += "LRSOSECU, "
            stConsultaSQL += "SOLIDESC, "
            stConsultaSQL += "LRSONUDO, "
            stConsultaSQL += "LRSONOMB, "
            stConsultaSQL += "LRSOPRAP, "
            stConsultaSQL += "LRSOSEAP, "
            stConsultaSQL += "LRSODIPR, "
            stConsultaSQL += "LRSODINO, "
            stConsultaSQL += "LRSOTELE, "
            stConsultaSQL += "LRSOCELU, "
            stConsultaSQL += "LRSOCOEL, "
            stConsultaSQL += "LRSOCOPO, "
            stConsultaSQL += "LRSORESO "


            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRASOLI, MANT_SOLICITANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRSOSOLI = SOLICODI AND "
            stConsultaSQL += "LRSOSECU = '" & CInt(inLRSOSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LRSOIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LIRASOLI")
            Return Nothing

        End Try

    End Function

End Class
