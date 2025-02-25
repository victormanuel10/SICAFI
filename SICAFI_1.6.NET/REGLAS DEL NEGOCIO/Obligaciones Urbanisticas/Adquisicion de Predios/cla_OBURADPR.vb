Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_OBURADPR

    '=============================================================
    '*** CLASE ADQUISICION DE PREDIO OBLIGACIONES URBANISTICAS ***
    '=============================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_OBURADPR(ByVal stOUAPCLEN As String, _
                                                         ByVal inOUAPNURE As Integer, _
                                                         ByVal stOUAPFERE As String, _
                                                         ByVal obOUAPMAIN As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(stOUAPCLEN) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(inOUAPNURE) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(stOUAPFERE) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obOUAPMAIN.Text) = True Then

                Dim objdatos1 As New cla_OBURADPR
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_OBURADPR(stOUAPCLEN, inOUAPNURE, stOUAPFERE, obOUAPMAIN.Text)

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
    Public Function fun_Insertar_OBURADPR(ByVal inOUAPSECU As Integer, _
                                          ByVal stOUAPCLEN As String, _
                                          ByVal inOUAPNURE As Integer, _
                                          ByVal stOUAPFERE As String, _
                                          ByVal inOUAPMAIN As Integer, _
                                          ByVal inOUAPCLOU As Integer, _
                                          ByVal inOUAPNUOF As Integer, _
                                          ByVal stOUAPSUPE As String, _
                                          ByVal stOUAPNDSU As String, _
                                          ByVal stOUAPMUNI As String, _
                                          ByVal stOUAPCORR As String, _
                                          ByVal stOUAPBARR As String, _
                                          ByVal stOUAPMANZ As String, _
                                          ByVal stOUAPPRED As String, _
                                          ByVal stOUAPEDIF As String, _
                                          ByVal stOUAPUNPR As String, _
                                          ByVal inOUAPCLSE As Integer, _
                                          ByVal stOUAPDIRE As String, _
                                          ByVal inOUAPARTE As Integer, _
                                          ByVal loOUAPAVCA As Long, _
                                          ByVal loOUAPAVCO As Long, _
                                          ByVal loOUAPVACO As Long, _
                                          ByVal stOUAPDESC As String, _
                                          ByVal stOUAPOBSE As String, _
                                          ByVal stOUAPESTA As String) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "OBURADPR "

            stConsultaSQL += "( "
            stConsultaSQL += "OUAPSECU, "
            stConsultaSQL += "OUAPCLEN, "
            stConsultaSQL += "OUAPNURE, "
            stConsultaSQL += "OUAPFERE, "
            stConsultaSQL += "OUAPMAIN, "
            stConsultaSQL += "OUAPCLOU, "
            stConsultaSQL += "OUAPNUOF, "
            stConsultaSQL += "OUAPSUPE, "
            stConsultaSQL += "OUAPNDSU, "
            stConsultaSQL += "OUAPMUNI, "
            stConsultaSQL += "OUAPCORR, "
            stConsultaSQL += "OUAPBARR, "
            stConsultaSQL += "OUAPMANZ, "
            stConsultaSQL += "OUAPPRED, "
            stConsultaSQL += "OUAPEDIF, "
            stConsultaSQL += "OUAPUNPR, "
            stConsultaSQL += "OUAPCLSE, "
            stConsultaSQL += "OUAPDIRE, "
            stConsultaSQL += "OUAPARTE, "
            stConsultaSQL += "OUAPAVCA, "
            stConsultaSQL += "OUAPAVCO, "
            stConsultaSQL += "OUAPVACO, "
            stConsultaSQL += "OUAPDESC, "
            stConsultaSQL += "OUAPOBSE, "
            stConsultaSQL += "OUAPESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inOUAPSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUAPCLEN)) & "', "
            stConsultaSQL += "'" & CInt(inOUAPNURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUAPFERE)) & "', "
            stConsultaSQL += "'" & CInt(inOUAPMAIN) & "', "
            stConsultaSQL += "'" & CInt(inOUAPCLOU) & "', "
            stConsultaSQL += "'" & CInt(inOUAPNUOF) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUAPSUPE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUAPNDSU)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUAPMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUAPCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUAPBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUAPMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUAPPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUAPEDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUAPUNPR)) & "', "
            stConsultaSQL += "'" & CInt(inOUAPCLSE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUAPDIRE)) & "', "
            stConsultaSQL += "'" & CInt(inOUAPARTE) & "', "
            stConsultaSQL += "'" & CDbl(loOUAPAVCA) & "', "
            stConsultaSQL += "'" & CDbl(loOUAPAVCO) & "', "
            stConsultaSQL += "'" & CDbl(loOUAPVACO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUAPDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUAPOBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUAPESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_OBURADPR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_OBURADPR(ByVal inOUAPIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "OBURADPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUAPIDRE = '" & CInt(inOUAPIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_OBURADPR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_OBURADPR(ByVal inOUAPSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "OBURADPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUAPSECU = '" & CInt(inOUAPSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_OBURADPR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_OBURADPR(ByVal inOUAPIDRE As Integer, _
                                            ByVal inOUAPSECU As Integer, _
                                            ByVal stOUAPCLEN As String, _
                                            ByVal inOUAPNURE As Integer, _
                                            ByVal stOUAPFERE As String, _
                                            ByVal inOUAPMAIN As Integer, _
                                            ByVal inOUAPCLOU As Integer, _
                                            ByVal inOUAPNUOF As Integer, _
                                            ByVal stOUAPSUPE As String, _
                                            ByVal stOUAPNDSU As String, _
                                            ByVal stOUAPMUNI As String, _
                                            ByVal stOUAPCORR As String, _
                                            ByVal stOUAPBARR As String, _
                                            ByVal stOUAPMANZ As String, _
                                            ByVal stOUAPPRED As String, _
                                            ByVal stOUAPEDIF As String, _
                                            ByVal stOUAPUNPR As String, _
                                            ByVal inOUAPCLSE As Integer, _
                                            ByVal stOUAPDIRE As String, _
                                            ByVal inOUAPARTE As Integer, _
                                            ByVal loOUAPAVCA As Long, _
                                            ByVal loOUAPAVCO As Long, _
                                            ByVal loOUAPVACO As Long, _
                                            ByVal stOUAPDESC As String, _
                                            ByVal stOUAPOBSE As String, _
                                            ByVal stOUAPESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "OBURADPR "

            stConsultaSQL += "SET "
            stConsultaSQL += "OUAPSECU = '" & CInt(inOUAPSECU) & "', "
            stConsultaSQL += "OUAPCLEN = '" & CStr(Trim(stOUAPCLEN)) & "', "
            stConsultaSQL += "OUAPNURE = '" & CInt(inOUAPNURE) & "', "
            stConsultaSQL += "OUAPFERE = '" & CStr(Trim(stOUAPFERE)) & "', "
            stConsultaSQL += "OUAPMAIN = '" & CInt(inOUAPMAIN) & "', "
            stConsultaSQL += "OUAPCLOU = '" & CInt(inOUAPCLOU) & "', "
            stConsultaSQL += "OUAPNUOF = '" & CInt(inOUAPNUOF) & "', "
            stConsultaSQL += "OUAPSUPE = '" & CStr(Trim(stOUAPSUPE)) & "', "
            stConsultaSQL += "OUAPNDSU = '" & CStr(Trim(stOUAPNDSU)) & "', "
            stConsultaSQL += "OUAPMUNI = '" & CStr(Trim(stOUAPMUNI)) & "', "
            stConsultaSQL += "OUAPCORR = '" & CStr(Trim(stOUAPCORR)) & "', "
            stConsultaSQL += "OUAPBARR = '" & CStr(Trim(stOUAPBARR)) & "', "
            stConsultaSQL += "OUAPMANZ = '" & CStr(Trim(stOUAPMANZ)) & "', "
            stConsultaSQL += "OUAPPRED = '" & CStr(Trim(stOUAPPRED)) & "', "
            stConsultaSQL += "OUAPEDIF = '" & CStr(Trim(stOUAPEDIF)) & "', "
            stConsultaSQL += "OUAPUNPR = '" & CStr(Trim(stOUAPUNPR)) & "', "
            stConsultaSQL += "OUAPCLSE = '" & CInt(inOUAPCLSE) & "', "
            stConsultaSQL += "OUAPDIRE = '" & CStr(Trim(stOUAPDIRE)) & "', "
            stConsultaSQL += "OUAPARTE = '" & CInt(inOUAPARTE) & "', "
            stConsultaSQL += "OUAPAVCA = '" & CLng(loOUAPAVCA) & "', "
            stConsultaSQL += "OUAPAVCO = '" & CLng(loOUAPAVCO) & "', "
            stConsultaSQL += "OUAPVACO = '" & CLng(loOUAPVACO) & "', "
            stConsultaSQL += "OUAPDESC = '" & CStr(Trim(stOUAPDESC)) & "', "
            stConsultaSQL += "OUAPOBSE = '" & CStr(Trim(stOUAPOBSE)) & "', "
            stConsultaSQL += "OUAPESTA = '" & CStr(Trim(stOUAPESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUAPIDRE = '" & CInt(inOUAPIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_OBURADPR")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_OBURADPR() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUAPIDRE, "
            stConsultaSQL += "OUAPSECU, "
            stConsultaSQL += "OUAPCLEN, "
            stConsultaSQL += "OUAPNURE, "
            stConsultaSQL += "OUAPFERE, "
            stConsultaSQL += "OUAPCLOU, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "OUAPMAIN, "
            stConsultaSQL += "OUAPNUOF, "
            stConsultaSQL += "OUAPSUPE, "
            stConsultaSQL += "USUANOMB + ' ' + USUAPRAP + ' ' + USUASEAP AS USUARIO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "OUAPNDSU, "
            stConsultaSQL += "OUAPMUNI, "
            stConsultaSQL += "OUAPCORR, "
            stConsultaSQL += "OUAPBARR, "
            stConsultaSQL += "OUAPMANZ, "
            stConsultaSQL += "OUAPPRED, "
            stConsultaSQL += "OUAPEDIF, "
            stConsultaSQL += "OUAPUNPR, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "OUAPDIRE, "
            stConsultaSQL += "OUAPARTE, "
            stConsultaSQL += "OUAPAVCA, "
            stConsultaSQL += "OUAPAVCO, "
            stConsultaSQL += "OUAPVACO, "
            stConsultaSQL += "OUAPDESC, "
            stConsultaSQL += "OUAPOBSE, "
            stConsultaSQL += "OUAPESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURADPR, MANT_CLASSECT, ESTADO, USUARIO, MANT_CLASOBUR "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "OUAPCLSE = CLSECODI AND "
            stConsultaSQL += "OUAPESTA = ESTACODI AND "
            stConsultaSQL += "OUAPNDSU = USUANUDO AND "
            stConsultaSQL += "OUAPCLOU = CLOUCODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUAPIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_OBURADPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_OBURADPR() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURADPR "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUAPIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_OBURADPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_OBURADPR(ByVal inOUAPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURADPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUAPIDRE = '" & CInt(inOUAPIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_OBURADPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_OBURADPR(ByVal stOUAPCLEN As String, _
                                                 ByVal inOUAPNURE As Integer, _
                                                 ByVal stOUAPFERE As String, _
                                                 ByVal inOUAPMAIN As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURADPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUAPCLEN = '" & CStr(Trim(stOUAPCLEN)) & "' AND "
            stConsultaSQL += "OUAPNURE = '" & CInt(inOUAPNURE) & "'AND  "
            stConsultaSQL += "OUAPFERE = '" & CStr(Trim(stOUAPFERE)) & "' AND "
            stConsultaSQL += "OUAPMAIN = '" & CInt(inOUAPMAIN) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_OBURADPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_OBURADPR(ByVal stOUAPCLEN As String, _
                                                 ByVal inOUAPNURE As Integer, _
                                                 ByVal stOUAPFERE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURADPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUAPCLEN = '" & CStr(Trim(stOUAPCLEN)) & "' AND "
            stConsultaSQL += "OUAPNURE = '" & CInt(inOUAPNURE) & "'AND  "
            stConsultaSQL += "OUAPFERE = '" & CStr(Trim(stOUAPFERE)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_OBURADPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURADPR(ByVal inOUAPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUAPIDRE, "
            stConsultaSQL += "OUAPSECU, "
            stConsultaSQL += "OUAPCLEN, "
            stConsultaSQL += "OUAPNURE, "
            stConsultaSQL += "OUAPFERE, "
            stConsultaSQL += "OUAPCLOU, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "OUAPMAIN, "
            stConsultaSQL += "OUAPNUOF, "
            stConsultaSQL += "OUAPSUPE, "
            stConsultaSQL += "LTRIM(RTRIM(USUANOMB)) + ' ' + LTRIM(RTRIM(USUAPRAP)) + ' ' + LTRIM(RTRIM(USUASEAP)) AS USUARIO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "OUAPNDSU, "
            stConsultaSQL += "OUAPMUNI, "
            stConsultaSQL += "OUAPCORR, "
            stConsultaSQL += "OUAPBARR, "
            stConsultaSQL += "OUAPMANZ, "
            stConsultaSQL += "OUAPPRED, "
            stConsultaSQL += "OUAPEDIF, "
            stConsultaSQL += "OUAPUNPR, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "OUAPDIRE, "
            stConsultaSQL += "OUAPARTE, "
            stConsultaSQL += "OUAPAVCA, "
            stConsultaSQL += "OUAPAVCO, "
            stConsultaSQL += "OUAPVACO, "
            stConsultaSQL += "OUAPDESC, "
            stConsultaSQL += "OUAPOBSE, "
            stConsultaSQL += "OUAPESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURADPR, MANT_CLASSECT, ESTADO, USUARIO, MANT_CLASOBUR "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "OUAPCLSE = CLSECODI AND "
            stConsultaSQL += "OUAPESTA = ESTACODI AND "
            stConsultaSQL += "OUAPNDSU = USUANUDO AND "
            stConsultaSQL += "OUAPCLOU = CLOUCODI AND "
            stConsultaSQL += "OUAPIDRE = '" & CInt(inOUAPIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUAPIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURADPR")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURADPR(ByVal inOUAPSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUAPIDRE, "
            stConsultaSQL += "OUAPSECU, "
            stConsultaSQL += "OUAPCLEN, "
            stConsultaSQL += "OUAPNURE, "
            stConsultaSQL += "OUAPFERE, "
            stConsultaSQL += "OUAPCLOU, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "OUAPMAIN, "
            stConsultaSQL += "OUAPNUOF, "
            stConsultaSQL += "OUAPSUPE, "
            stConsultaSQL += "USUANOMB + ' ' + USUAPRAP + ' ' + USUASEAP AS USUARIO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "OUAPNDSU, "
            stConsultaSQL += "OUAPMUNI, "
            stConsultaSQL += "OUAPCORR, "
            stConsultaSQL += "OUAPBARR, "
            stConsultaSQL += "OUAPMANZ, "
            stConsultaSQL += "OUAPPRED, "
            stConsultaSQL += "OUAPEDIF, "
            stConsultaSQL += "OUAPUNPR, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "OUAPDIRE, "
            stConsultaSQL += "OUAPARTE, "
            stConsultaSQL += "OUAPAVCA, "
            stConsultaSQL += "OUAPAVCO, "
            stConsultaSQL += "OUAPVACO, "
            stConsultaSQL += "OUAPDESC, "
            stConsultaSQL += "OUAPOBSE, "
            stConsultaSQL += "OUAPESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURADPR, MANT_CLASSECT, ESTADO, USUARIO, MANT_CLASOBUR "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "OUAPCLSE = CLSECODI AND "
            stConsultaSQL += "OUAPESTA = ESTACODI AND "
            stConsultaSQL += "OUAPNDSU = USUANUDO AND "
            stConsultaSQL += "OUAPCLOU = CLOUCODI AND "
            stConsultaSQL += "OUAPSECU = '" & CInt(inOUAPSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUAPIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURADPR")
            Return Nothing

        End Try

    End Function

End Class
