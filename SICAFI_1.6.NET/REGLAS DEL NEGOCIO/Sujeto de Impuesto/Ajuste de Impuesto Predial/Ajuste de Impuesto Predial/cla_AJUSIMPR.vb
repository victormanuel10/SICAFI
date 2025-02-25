Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_AJUSIMPR

    '========================================
    '*** CLASE AJUSTE DE IMPUESTO PREDIAL ***
    '========================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_AJUSIMPR(ByVal obAJIPNUFI As Object, _
                                                         ByVal obAJIPNURE As Object, _
                                                         ByVal obAJIPFERE As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obAJIPNUFI.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obAJIPNURE.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obAJIPFERE.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obAJIPNUFI.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obAJIPNURE.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Fecha(obAJIPFERE.Text) = True Then

                    Dim objdatos1 As New cla_AJUSIMPR
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_AJUSIMPR(obAJIPNUFI.Text, obAJIPNURE.Text, obAJIPFERE.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        obAJIPNUFI.Focus()
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
    Public Function fun_Insertar_AJUSIMPR(ByVal inAJIPNUFI As Integer, _
                                          ByVal stAJIPDEPA As String, _
                                          ByVal stAJIPMUNI As String, _
                                          ByVal stAJIPCORR As String, _
                                          ByVal stAJIPBARR As String, _
                                          ByVal stAJIPMANZ As String, _
                                          ByVal stAJIPPRED As String, _
                                          ByVal stAJIPEDIF As String, _
                                          ByVal stAJIPUNPR As String, _
                                          ByVal inAJIPCLSE As Integer, _
                                          ByVal inAJIPVIGE As Integer, _
                                          ByVal stAJIPMAIN As String, _
                                          ByVal inAJIPSECU As Integer, _
                                          ByVal stAJIPFECH As String, _
                                          ByVal inAJIPCLAS As Integer, _
                                          ByVal inAJIPTITR As Integer, _
                                          ByVal inAJIPMERE As Integer, _
                                          ByVal inAJIPREAJ As Integer, _
                                          ByVal stAJIPREMI As String, _
                                          ByVal stAJIPFECR As String, _
                                          ByVal stAJIPDEST As String, _
                                          ByVal stAJIPFECD As String, _
                                          ByVal stAJIPNUDO As String, _
                                          ByVal stAJIPUSUR As String, _
                                          ByVal stAJIPNURA As String, _
                                          ByVal stAJIPFERA As String, _
                                          ByVal stAJIPNURE As String, _
                                          ByVal stAJIPFERE As String, _
                                          ByVal stAJIPNUOF As String, _
                                          ByVal stAJIPFEOF As String, _
                                          ByVal stAJIPOBSE As String, _
                                          ByVal stAJIPESTA As String, _
                                          ByVal stAJIPESTR As String, _
                                          ByVal stAJIPUSUD As String) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "AJUSIMPR "

            stConsultaSQL += "( "
            stConsultaSQL += "AJIPNUFI, "
            stConsultaSQL += "AJIPDEPA, "
            stConsultaSQL += "AJIPMUNI, "
            stConsultaSQL += "AJIPCORR, "
            stConsultaSQL += "AJIPBARR, "
            stConsultaSQL += "AJIPMANZ, "
            stConsultaSQL += "AJIPPRED, "
            stConsultaSQL += "AJIPEDIF, "
            stConsultaSQL += "AJIPUNPR, "
            stConsultaSQL += "AJIPCLSE, "
            stConsultaSQL += "AJIPVIGE, "
            stConsultaSQL += "AJIPMAIN, "
            stConsultaSQL += "AJIPSECU, "
            stConsultaSQL += "AJIPFECH, "
            stConsultaSQL += "AJIPCLAS, "
            stConsultaSQL += "AJIPTITR, "
            stConsultaSQL += "AJIPMERE, "
            stConsultaSQL += "AJIPREAJ, "
            stConsultaSQL += "AJIPREMI, "
            stConsultaSQL += "AJIPFECR, "
            stConsultaSQL += "AJIPDEST, "
            stConsultaSQL += "AJIPFECD, "
            stConsultaSQL += "AJIPNUDO, "
            stConsultaSQL += "AJIPUSUR, "
            stConsultaSQL += "AJIPNURA, "
            stConsultaSQL += "AJIPFERA, "
            stConsultaSQL += "AJIPNURE, "
            stConsultaSQL += "AJIPFERE, "
            stConsultaSQL += "AJIPNUOF, "
            stConsultaSQL += "AJIPFEOF, "
            stConsultaSQL += "AJIPOBSE, "
            stConsultaSQL += "AJIPESTA, "
            stConsultaSQL += "AJIPESTR, "
            stConsultaSQL += "AJIPUSUD "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inAJIPNUFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPEDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPUNPR)) & "', "
            stConsultaSQL += "'" & CInt(inAJIPCLSE) & "', "
            stConsultaSQL += "'" & CInt(inAJIPVIGE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPMAIN)) & "', "
            stConsultaSQL += "'" & CInt(inAJIPSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPFECH)) & "', "
            stConsultaSQL += "'" & CInt(inAJIPCLAS) & "', "
            stConsultaSQL += "'" & CInt(inAJIPTITR) & "', "
            stConsultaSQL += "'" & CInt(inAJIPMERE) & "', "
            stConsultaSQL += "'" & CInt(inAJIPREAJ) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPREMI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPFECR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPDEST)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPFECD)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPUSUR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPNURA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPFERA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPNURE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPFERE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPNUOF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPFEOF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPOBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPESTR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAJIPUSUD)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_AJUSIMPR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_AJUSIMPR(ByVal inAJIPIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "AJUSIMPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIPIDRE = '" & CInt(inAJIPIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_AJUSIMPR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_AJUSIMPR(ByVal inAJIPSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "AJUSIMPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIPSECU = '" & CInt(inAJIPSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_AJUSIMPR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_AJUSIMPR(ByVal inAJIPIDRE As Integer, _
                                            ByVal inAJIPNUFI As Integer, _
                                            ByVal stAJIPDEPA As String, _
                                            ByVal stAJIPMUNI As String, _
                                            ByVal stAJIPCORR As String, _
                                            ByVal stAJIPBARR As String, _
                                            ByVal stAJIPMANZ As String, _
                                            ByVal stAJIPPRED As String, _
                                            ByVal stAJIPEDIF As String, _
                                            ByVal stAJIPUNPR As String, _
                                            ByVal inAJIPCLSE As Integer, _
                                            ByVal inAJIPVIGE As Integer, _
                                            ByVal stAJIPMAIN As String, _
                                            ByVal inAJIPCLAS As Integer, _
                                            ByVal inAJIPTITR As Integer, _
                                            ByVal inAJIPMERE As Integer, _
                                            ByVal inAJIPREAJ As Integer, _
                                            ByVal stAJIPNURA As String, _
                                            ByVal stAJIPFERA As String, _
                                            ByVal stAJIPNURE As String, _
                                            ByVal stAJIPFERE As String, _
                                            ByVal stAJIPNUOF As String, _
                                            ByVal stAJIPFEOF As String, _
                                            ByVal stAJIPOBSE As String, _
                                            ByVal stAJIPESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "AJUSIMPR "

            stConsultaSQL += "SET "
            stConsultaSQL += "AJIPNUFI = '" & CInt(inAJIPNUFI) & "', "
            stConsultaSQL += "AJIPDEPA = '" & CStr(Trim(stAJIPDEPA)) & "', "
            stConsultaSQL += "AJIPMUNI = '" & CStr(Trim(stAJIPMUNI)) & "', "
            stConsultaSQL += "AJIPCORR = '" & CStr(Trim(stAJIPCORR)) & "', "
            stConsultaSQL += "AJIPBARR = '" & CStr(Trim(stAJIPBARR)) & "', "
            stConsultaSQL += "AJIPMANZ = '" & CStr(Trim(stAJIPMANZ)) & "', "
            stConsultaSQL += "AJIPPRED = '" & CStr(Trim(stAJIPPRED)) & "', "
            stConsultaSQL += "AJIPEDIF = '" & CStr(Trim(stAJIPEDIF)) & "', "
            stConsultaSQL += "AJIPUNPR = '" & CStr(Trim(stAJIPUNPR)) & "', "
            stConsultaSQL += "AJIPCLSE = '" & CInt(inAJIPCLSE) & "', "
            stConsultaSQL += "AJIPVIGE = '" & CInt(inAJIPVIGE) & "', "
            stConsultaSQL += "AJIPMAIN = '" & CStr(Trim(stAJIPMAIN)) & "', "
            stConsultaSQL += "AJIPCLAS = '" & CInt(inAJIPCLAS) & "', "
            stConsultaSQL += "AJIPTITR = '" & CInt(inAJIPTITR) & "', "
            stConsultaSQL += "AJIPMERE = '" & CInt(inAJIPMERE) & "', "
            stConsultaSQL += "AJIPREAJ = '" & CInt(inAJIPREAJ) & "', "
            stConsultaSQL += "AJIPNURA = '" & CStr(Trim(stAJIPNURA)) & "', "
            stConsultaSQL += "AJIPFERA = '" & CStr(Trim(stAJIPFERA)) & "', "
            stConsultaSQL += "AJIPNURE = '" & CStr(Trim(stAJIPNURE)) & "', "
            stConsultaSQL += "AJIPFERE = '" & CStr(Trim(stAJIPFERE)) & "', "
            stConsultaSQL += "AJIPNUOF = '" & CStr(Trim(stAJIPNUOF)) & "', "
            stConsultaSQL += "AJIPFEOF = '" & CStr(Trim(stAJIPFEOF)) & "', "
            stConsultaSQL += "AJIPOBSE = '" & CStr(Trim(stAJIPOBSE)) & "', "
            stConsultaSQL += "AJIPESTA = '" & CStr(Trim(stAJIPESTA)) & "', "
            stConsultaSQL += "AJIPESTR = '" & CStr(Trim(stAJIPESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIPIDRE = '" & CInt(inAJIPIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_AJUSIMPR")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_AJUSIMPR() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "AJIPIDRE, "
            stConsultaSQL += "AJIPNUFI, "
            stConsultaSQL += "AJIPSECU, "
            stConsultaSQL += "AJIPDEPA, "
            stConsultaSQL += "AJIPMUNI, "
            stConsultaSQL += "AJIPCORR, "
            stConsultaSQL += "AJIPBARR, "
            stConsultaSQL += "AJIPMANZ, "
            stConsultaSQL += "AJIPPRED, "
            stConsultaSQL += "AJIPEDIF, "
            stConsultaSQL += "AJIPUNPR, "
            stConsultaSQL += "AJIPCLSE, "
            stConsultaSQL += "AJIPVIGE, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "AJIPMAIN, "
            stConsultaSQL += "AJIPFECH, "
            stConsultaSQL += "AJIPCLAS, "
            stConsultaSQL += "AJIPTITR, "
            stConsultaSQL += "AJIPMERE, "
            stConsultaSQL += "AJIPREAJ, "
            stConsultaSQL += "AJIPREMI, "
            stConsultaSQL += "AJIPFECR, "
            stConsultaSQL += "AJIPDEST, "
            stConsultaSQL += "AJIPFECD, "
            stConsultaSQL += "AJIPNUDO, "
            stConsultaSQL += "AJIPUSUR, "
            stConsultaSQL += "AJIPNURA, "
            stConsultaSQL += "AJIPFERA, "
            stConsultaSQL += "AJIPNURE, "
            stConsultaSQL += "AJIPFERE, "
            stConsultaSQL += "AJIPNUOF, "
            stConsultaSQL += "AJIPFEOF, "
            stConsultaSQL += "AJIPOBSE, "
            stConsultaSQL += "AJIPESTA, "
            stConsultaSQL += "AJIPESTR, "
            stConsultaSQL += "AJIPUSUD "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AJUSIMPR, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIPESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AJIPSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_AJUSIMPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_AJUSIMPR() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AJUSIMPR "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AJIPSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_AJUSIMPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_AJUSIMPR_X_ESTADO_AC() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AJUSIMPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIPESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AJIPSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_AJUSIMPR_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_AJUSIMPR_X_ESTADO_PE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AJUSIMPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIPESTA = 'pe' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AJIPSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_AJUSIMPR_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_AJUSIMPR_X_ESTADO_AS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AJUSIMPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIPESTA = 'as' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AJIPSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_AJUSIMPR_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_AJUSIMPR_X_ESTADO_FI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AJUSIMPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIPESTA = 'fi' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AJIPSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_AJUSIMPR_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_AJUSIMPR(ByVal inAJIPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AJUSIMPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIPIDRE = '" & CInt(inAJIPIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_AJUSIMPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_AJUSIMPR(ByVal inAJIPSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AJUSIMPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIPSECU = '" & CInt(inAJIPSECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_AJUSIMPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJUSIMPR(ByVal inAJIPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "AJIPIDRE, "
            stConsultaSQL += "AJIPNUFI, "
            stConsultaSQL += "AJIPSECU, "
            stConsultaSQL += "AJIPDEPA, "
            stConsultaSQL += "AJIPMUNI, "
            stConsultaSQL += "AJIPCORR, "
            stConsultaSQL += "AJIPBARR, "
            stConsultaSQL += "AJIPMANZ, "
            stConsultaSQL += "AJIPPRED, "
            stConsultaSQL += "AJIPEDIF, "
            stConsultaSQL += "AJIPUNPR, "
            stConsultaSQL += "AJIPCLSE, "
            stConsultaSQL += "AJIPVIGE, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "AJIPMAIN, "
            stConsultaSQL += "AJIPFECH, "
            stConsultaSQL += "AJIPCLAS, "
            stConsultaSQL += "AJIPTITR, "
            stConsultaSQL += "AJIPMERE, "
            stConsultaSQL += "AJIPREAJ, "
            stConsultaSQL += "AJIPREMI, "
            stConsultaSQL += "AJIPFECR, "
            stConsultaSQL += "AJIPDEST, "
            stConsultaSQL += "AJIPFECD, "
            stConsultaSQL += "AJIPNUDO, "
            stConsultaSQL += "AJIPUSUR, "
            stConsultaSQL += "AJIPNURA, "
            stConsultaSQL += "AJIPFERA, "
            stConsultaSQL += "AJIPNURE, "
            stConsultaSQL += "AJIPFERE, "
            stConsultaSQL += "AJIPNUOF, "
            stConsultaSQL += "AJIPFEOF, "
            stConsultaSQL += "AJIPOBSE, "
            stConsultaSQL += "AJIPESTA, "
            stConsultaSQL += "AJIPESTR, "
            stConsultaSQL += "AJIPUSUD "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AJUSIMPR, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIPESTA = ESTACODI and "
            stConsultaSQL += "AJIPIDRE = '" & CInt(inAJIPIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AJIPSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AJUSIMPR")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia maxima
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_AJUSIMPR() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "AJIPSECU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AJUSIMPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_MAXINA_X_AJUSIMPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MATECARG_X_AJUSIMPR(ByVal inAJIPSECU As Integer, _
                                                       ByVal stAJIPMACA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "AJUSIMPR "

            stConsultaSQL += "SET "
            stConsultaSQL += "AJIPMACA = '" & CStr(Trim(stAJIPMACA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIPSECU = '" & CInt(inAJIPSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_TRABCAMP")
        End Try

    End Function

    Public Function fun_Buscar_CODIGO_X_AJUSIMPR(ByVal stAJIPNUFI As String, _
                                                 ByVal stAJIPNURE As String, _
                                                 ByVal stAJIPFERE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AJUSIMPR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIPNUFI = '" & CStr(Trim(stAJIPNUFI)) & "' and "
            stConsultaSQL += "AJIPNURE = '" & CStr(Trim(stAJIPNURE)) & "' and "
            stConsultaSQL += "AJIPFERE = '" & CStr(Trim(stAJIPFERE)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_X_AJUSIMPR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_Asignar_Tramite(ByVal inAJIPIDRE As Integer, _
                                                   ByVal stAJIPREMI As String, _
                                                   ByVal stAJIPUSUR As String, _
                                                   ByVal stAJIPFECR As String, _
                                                   ByVal stAJIPDEST As String, _
                                                   ByVal stAJIPUSUD As String, _
                                                   ByVal stAJIPFECD As String, _
                                                   ByVal stAJIPOBSE As String, _
                                                   ByVal stAJIPESTA As String, _
                                                   ByVal stAJIPESTR As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "AJUSIMPR "

            stConsultaSQL += "SET "
            stConsultaSQL += "AJIPREMI = '" & CStr(Trim(stAJIPREMI)) & "', "
            stConsultaSQL += "AJIPUSUR = '" & CStr(Trim(stAJIPUSUR)) & "', "
            stConsultaSQL += "AJIPFECR = '" & CStr(Trim(stAJIPFECR)) & "', "
            stConsultaSQL += "AJIPDEST = '" & CStr(Trim(stAJIPDEST)) & "', "
            stConsultaSQL += "AJIPUSUD = '" & CStr(Trim(stAJIPUSUD)) & "', "
            stConsultaSQL += "AJIPFECD = '" & CStr(Trim(stAJIPFECD)) & "', "
            stConsultaSQL += "AJIPOBSE = '" & CStr(Trim(stAJIPOBSE)) & "', "
            stConsultaSQL += "AJIPESTA = '" & CStr(Trim(stAJIPESTA)) & "', "
            stConsultaSQL += "AJIPESTR = '" & CStr(Trim(stAJIPESTR)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AJIPIDRE = '" & CInt(inAJIPIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_LEVANTAMIENTO")
        End Try

    End Function

End Class
