Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_OBUREJOB

    '=========================================================
    '*** CLASE EJECUCION DE OBRA OBLIGACIONES URBANISTICAS ***
    '=========================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_OBUREJOB(ByVal stOUEOCLEN As String, _
                                                         ByVal inOUEONURE As Integer, _
                                                         ByVal stOUEOFERE As String, _
                                                         ByVal obOUEONUME As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(stOUEOCLEN) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(inOUEONURE) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(stOUEOFERE) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obOUEONUME.Text) = True Then

                Dim objdatos1 As New cla_OBUREJOB
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_OBUREJOB(stOUEOCLEN, inOUEONURE, stOUEOFERE, obOUEONUME.Text)

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
    Public Function fun_Insertar_OBUREJOB(ByVal inOUEOSECU As Integer, _
                                          ByVal stOUEOCLEN As String, _
                                          ByVal inOUEONURE As Integer, _
                                          ByVal stOUEOFERE As String, _
                                          ByVal inOUEONUME As Integer, _
                                          ByVal stOUEOCOCO As String, _
                                          ByVal stOUEOCOOB As String, _
                                          ByVal inOUEOCLOU As Integer, _
                                          ByVal inOUEONUOF As Integer, _
                                          ByVal stOUEOCONT As String, _
                                          ByVal stOUEOSUPE As String, _
                                          ByVal stOUEONDSU As String, _
                                          ByVal loOUEOVAOB As Long, _
                                          ByVal loOUEOVACO As Long, _
                                          ByVal loOUEOVADI As Long, _
                                          ByVal inOUEOFOPA As Integer, _
                                          ByVal inOUEONUCU As Integer, _
                                          ByVal boOUEOAPCO As Boolean, _
                                          ByVal stOUEONUPO As String, _
                                          ByVal stOUEONUCA As String, _
                                          ByVal stOUEOACLI As String, _
                                          ByVal inOUEOPLDI As Integer, _
                                          ByVal stOUEOFEIN As String, _
                                          ByVal stOUEOFEFI As String, _
                                          ByVal stOUEODESC As String, _
                                          ByVal stOUEOOBSE As String, _
                                          ByVal stOUEOOBCO As String, _
                                          ByVal stOUEOESTA As String) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "OBUREJOB "

            stConsultaSQL += "( "
            stConsultaSQL += "OUEOSECU, "
            stConsultaSQL += "OUEOCLEN, "
            stConsultaSQL += "OUEONURE, "
            stConsultaSQL += "OUEOFERE, "
            stConsultaSQL += "OUEONUME, "
            stConsultaSQL += "OUEOCOCO, "
            stConsultaSQL += "OUEOCOOB, "
            stConsultaSQL += "OUEOCLOU, "
            stConsultaSQL += "OUEONUOF, "
            stConsultaSQL += "OUEOCONT, "
            stConsultaSQL += "OUEOSUPE, "
            stConsultaSQL += "OUEONDSU, "
            stConsultaSQL += "OUEOVAOB, "
            stConsultaSQL += "OUEOVACO, "
            stConsultaSQL += "OUEOVADI, "
            stConsultaSQL += "OUEOFOPA, "
            stConsultaSQL += "OUEONUCU, "
            stConsultaSQL += "OUEOAPCO, "
            stConsultaSQL += "OUEONUPO, "
            stConsultaSQL += "OUEONUCA, "
            stConsultaSQL += "OUEOACLI, "
            stConsultaSQL += "OUEOPLDI, "
            stConsultaSQL += "OUEOFEIN, "
            stConsultaSQL += "OUEOFEFI, "
            stConsultaSQL += "OUEODESC, "
            stConsultaSQL += "OUEOOBSE, "
            stConsultaSQL += "OUEOOBCO, "
            stConsultaSQL += "OUEOESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inOUEOSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUEOCLEN)) & "', "
            stConsultaSQL += "'" & CInt(inOUEONURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUEOFERE)) & "', "
            stConsultaSQL += "'" & CInt(inOUEONUME) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUEOCOCO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUEOCOOB)) & "', "
            stConsultaSQL += "'" & CInt(inOUEOCLOU) & "', "
            stConsultaSQL += "'" & CInt(inOUEONUOF) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUEOCONT)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUEOSUPE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUEONDSU)) & "', "
            stConsultaSQL += "'" & CDbl(loOUEOVAOB) & "', "
            stConsultaSQL += "'" & CDbl(loOUEOVACO) & "', "
            stConsultaSQL += "'" & CDbl(loOUEOVADI) & "', "
            stConsultaSQL += "'" & CInt(inOUEOFOPA) & "', "
            stConsultaSQL += "'" & CInt(inOUEONUCU) & "', "
            stConsultaSQL += "'" & CBool(boOUEOAPCO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUEONUPO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUEONUCA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUEOACLI)) & "', "
            stConsultaSQL += "'" & CInt(inOUEOPLDI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUEOFEIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUEOFEFI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUEODESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUEOOBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUEOOBCO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUEOESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_OBUREJOB")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_OBUREJOB(ByVal inOUEOIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "OBUREJOB "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUEOIDRE = '" & CInt(inOUEOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_OBUREJOB")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_OBUREJOB(ByVal inOUEOSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "OBUREJOB "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUEOSECU = '" & CInt(inOUEOSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_OBUREJOB")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_OBUREJOB(ByVal inOUEOIDRE As Integer, _
                                            ByVal inOUEOSECU As Integer, _
                                            ByVal stOUEOCLEN As String, _
                                            ByVal inOUEONURE As Integer, _
                                            ByVal stOUEOFERE As String, _
                                            ByVal inOUEONUME As Integer, _
                                            ByVal stOUEOCOCO As String, _
                                            ByVal stOUEOCOOB As String, _
                                            ByVal inOUEOCLOU As Integer, _
                                            ByVal inOUEONUOF As Integer, _
                                            ByVal stOUEOCONT As String, _
                                            ByVal stOUEOSUPE As String, _
                                            ByVal stOUEONDSU As String, _
                                            ByVal loOUEOVAOB As Long, _
                                            ByVal loOUEOVACO As Long, _
                                            ByVal loOUEOVADI As Long, _
                                            ByVal inOUEOFOPA As Integer, _
                                            ByVal inOUEONUCU As Integer, _
                                            ByVal boOUEOAPCO As Boolean, _
                                            ByVal stOUEONUPO As String, _
                                            ByVal stOUEONUCA As String, _
                                            ByVal stOUEOACLI As String, _
                                            ByVal inOUEOPLDI As Integer, _
                                            ByVal stOUEOFEIN As String, _
                                            ByVal stOUEOFEFI As String, _
                                            ByVal stOUEODESC As String, _
                                            ByVal stOUEOOBSE As String, _
                                            ByVal stOUEOOBCO As String, _
                                            ByVal stOUEOESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "OBUREJOB "

            stConsultaSQL += "SET "
            stConsultaSQL += "OUEOSECU = '" & CInt(inOUEOSECU) & "', "
            stConsultaSQL += "OUEOCLEN = '" & CStr(Trim(stOUEOCLEN)) & "', "
            stConsultaSQL += "OUEONURE = '" & CInt(inOUEONURE) & "', "
            stConsultaSQL += "OUEOFERE = '" & CStr(Trim(stOUEOFERE)) & "', "
            stConsultaSQL += "OUEONUME = '" & CInt(inOUEONUME) & "', "
            stConsultaSQL += "OUEOCOCO = '" & CStr(Trim(stOUEOCOCO)) & "', "
            stConsultaSQL += "OUEOCOOB = '" & CStr(Trim(stOUEOCOOB)) & "', "
            stConsultaSQL += "OUEOCLOU = '" & CInt(inOUEOCLOU) & "', "
            stConsultaSQL += "OUEONUOF = '" & CInt(inOUEONUOF) & "', "
            stConsultaSQL += "OUEOCONT = '" & CStr(Trim(stOUEOCONT)) & "', "
            stConsultaSQL += "OUEOSUPE = '" & CStr(Trim(stOUEOSUPE)) & "', "
            stConsultaSQL += "OUEONDSU = '" & CStr(Trim(stOUEONDSU)) & "', "
            stConsultaSQL += "OUEOVAOB = '" & CLng(loOUEOVAOB) & "', "
            stConsultaSQL += "OUEOVACO = '" & CLng(loOUEOVACO) & "', "
            stConsultaSQL += "OUEOVADI = '" & CLng(loOUEOVADI) & "', "
            stConsultaSQL += "OUEOFOPA = '" & CInt(inOUEOFOPA) & "', "
            stConsultaSQL += "OUEONUCU = '" & CInt(inOUEONUCU) & "', "
            stConsultaSQL += "OUEOAPCO = '" & CBool(boOUEOAPCO) & "', "
            stConsultaSQL += "OUEONUPO = '" & CStr(Trim(stOUEONUPO)) & "', "
            stConsultaSQL += "OUEONUCA = '" & CStr(Trim(stOUEONUCA)) & "', "
            stConsultaSQL += "OUEOACLI = '" & CStr(Trim(stOUEOACLI)) & "', "
            stConsultaSQL += "OUEOPLDI = '" & CInt(inOUEOPLDI) & "', "
            stConsultaSQL += "OUEOFEIN = '" & CStr(Trim(stOUEOFEIN)) & "', "
            stConsultaSQL += "OUEOFEFI = '" & CStr(Trim(stOUEOFEFI)) & "', "
            stConsultaSQL += "OUEODESC = '" & CStr(Trim(stOUEODESC)) & "', "
            stConsultaSQL += "OUEOOBSE = '" & CStr(Trim(stOUEOOBSE)) & "', "
            stConsultaSQL += "OUEOOBCO = '" & CStr(Trim(stOUEOOBCO)) & "', "
            stConsultaSQL += "OUEOESTA = '" & CStr(Trim(stOUEOESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUEOIDRE = '" & CInt(inOUEOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_OBUREJOB")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_OBUREJOB() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUEOIDRE, "
            stConsultaSQL += "OUEOSECU, "
            stConsultaSQL += "OUEOCLEN, "
            stConsultaSQL += "OUEONURE, "
            stConsultaSQL += "OUEOFERE, "
            stConsultaSQL += "OUEOCOCO, "
            stConsultaSQL += "OUEOCOOB, "
            stConsultaSQL += "OUEOCLOU, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "OUEONUME, "
            stConsultaSQL += "OUEONUOF, "
            stConsultaSQL += "OUEOCONT, "
            stConsultaSQL += "OUEOSUPE, "
            stConsultaSQL += "LTRIM(RTRIM(USUANOMB)) + ' ' + LTRIM(RTRIM(USUAPRAP)) + ' ' + LTRIM(RTRIM(USUASEAP)) AS USUARIO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "OUEONDSU, "
            stConsultaSQL += "OUEOVAOB, "
            stConsultaSQL += "OUEOVACO, "
            stConsultaSQL += "OUEOVADI, "
            stConsultaSQL += "OUEOFOPA, "
            stConsultaSQL += "FPPPDESC, "
            stConsultaSQL += "OUEONUCU, "
            stConsultaSQL += "OUEOAPCO, "
            stConsultaSQL += "OUEONUPO, "
            stConsultaSQL += "OUEONUCA, "
            stConsultaSQL += "OUEOACLI, "
            stConsultaSQL += "OUEOPLDI, "
            stConsultaSQL += "OUEOFEIN, "
            stConsultaSQL += "OUEOFEFI, "
            stConsultaSQL += "OUEODESC, "
            stConsultaSQL += "OUEOOBSE, "
            stConsultaSQL += "OUEOOBCO, "
            stConsultaSQL += "OUEOESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBUREJOB, ESTADO, USUARIO, MANT_CLASOBUR, MANT_FOPAPLPA "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "OUEOESTA = ESTACODI AND "
            stConsultaSQL += "OUEONDSU = USUANUDO AND "
            stConsultaSQL += "OUEOFOPA = FPPPCODI AND "
            stConsultaSQL += "OUEOCLOU = CLOUCODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUEOIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_OBUREJOB")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_OBUREJOB() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBUREJOB "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUEOIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_OBUREJOB")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_OBUREJOB(ByVal inOUEOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBUREJOB "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUEOIDRE = '" & CInt(inOUEOIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_OBUREJOB")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_OBUREJOB(ByVal stOUEOCLEN As String, _
                                                 ByVal inOUEONURE As Integer, _
                                                 ByVal stOUEOFERE As String, _
                                                 ByVal inOUEONUME As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBUREJOB "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUEOCLEN = '" & CStr(Trim(stOUEOCLEN)) & "' AND "
            stConsultaSQL += "OUEONURE = '" & CInt(inOUEONURE) & "'AND  "
            stConsultaSQL += "OUEOFERE = '" & CStr(Trim(stOUEOFERE)) & "' AND "
            stConsultaSQL += "OUEONUME = '" & CInt(inOUEONUME) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_OBUREJOB")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_OBUREJOB(ByVal stOUEOCLEN As String, _
                                                 ByVal inOUEONURE As Integer, _
                                                 ByVal stOUEOFERE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBUREJOB "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUEOCLEN = '" & CStr(Trim(stOUEOCLEN)) & "' AND "
            stConsultaSQL += "OUEONURE = '" & CInt(inOUEONURE) & "'AND  "
            stConsultaSQL += "OUEOFERE = '" & CStr(Trim(stOUEOFERE)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_OBUREJOB")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBUREJOB(ByVal inOUEOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUEOIDRE, "
            stConsultaSQL += "OUEOSECU, "
            stConsultaSQL += "OUEOCLEN, "
            stConsultaSQL += "OUEONURE, "
            stConsultaSQL += "OUEOFERE, "
            stConsultaSQL += "OUEOCOCO, "
            stConsultaSQL += "OUEOCOOB, "
            stConsultaSQL += "OUEOCLOU, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "OUEONUME, "
            stConsultaSQL += "OUEONUOF, "
            stConsultaSQL += "OUEOCONT, "
            stConsultaSQL += "OUEOSUPE, "
            stConsultaSQL += "LTRIM(RTRIM(USUANOMB)) + ' ' + LTRIM(RTRIM(USUAPRAP)) + ' ' + LTRIM(RTRIM(USUASEAP)) AS USUARIO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "OUEONDSU, "
            stConsultaSQL += "OUEOVAOB, "
            stConsultaSQL += "OUEOVACO, "
            stConsultaSQL += "OUEOVADI, "
            stConsultaSQL += "OUEOFOPA, "
            stConsultaSQL += "FPPPDESC, "
            stConsultaSQL += "OUEONUCU, "
            stConsultaSQL += "OUEOAPCO, "
            stConsultaSQL += "OUEONUPO, "
            stConsultaSQL += "OUEONUCA, "
            stConsultaSQL += "OUEOACLI, "
            stConsultaSQL += "OUEOPLDI, "
            stConsultaSQL += "OUEOFEIN, "
            stConsultaSQL += "OUEOFEFI, "
            stConsultaSQL += "OUEODESC, "
            stConsultaSQL += "OUEOOBSE, "
            stConsultaSQL += "OUEOOBCO, "
            stConsultaSQL += "OUEOESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBUREJOB, ESTADO, USUARIO, MANT_CLASOBUR, MANT_FOPAPLPA "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "OUEOESTA = ESTACODI AND "
            stConsultaSQL += "OUEONDSU = USUANUDO AND "
            stConsultaSQL += "OUEOFOPA = FPPPCODI AND "
            stConsultaSQL += "OUEOCLOU = CLOUCODI AND "
            stConsultaSQL += "OUEOIDRE = '" & CInt(inOUEOIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUEOIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBUREJOB")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBUREJOB(ByVal inOUEOSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUEOIDRE, "
            stConsultaSQL += "OUEOSECU, "
            stConsultaSQL += "OUEOCLEN, "
            stConsultaSQL += "OUEONURE, "
            stConsultaSQL += "OUEOFERE, "
            stConsultaSQL += "OUEOCOCO, "
            stConsultaSQL += "OUEOCOOB, "
            stConsultaSQL += "OUEOCLOU, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "OUEONUME, "
            stConsultaSQL += "OUEONUOF, "
            stConsultaSQL += "OUEOCONT, "
            stConsultaSQL += "OUEOSUPE, "
            stConsultaSQL += "LTRIM(RTRIM(USUANOMB)) + ' ' + LTRIM(RTRIM(USUAPRAP)) + ' ' + LTRIM(RTRIM(USUASEAP)) AS USUARIO, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "OUEONDSU, "
            stConsultaSQL += "OUEOVAOB, "
            stConsultaSQL += "OUEOVACO, "
            stConsultaSQL += "OUEOVADI, "
            stConsultaSQL += "OUEOFOPA, "
            stConsultaSQL += "FPPPDESC, "
            stConsultaSQL += "OUEONUCU, "
            stConsultaSQL += "OUEOAPCO, "
            stConsultaSQL += "OUEONUPO, "
            stConsultaSQL += "OUEONUCA, "
            stConsultaSQL += "OUEOACLI, "
            stConsultaSQL += "OUEOPLDI, "
            stConsultaSQL += "OUEOFEIN, "
            stConsultaSQL += "OUEOFEFI, "
            stConsultaSQL += "OUEODESC, "
            stConsultaSQL += "OUEOOBSE, "
            stConsultaSQL += "OUEOOBCO, "
            stConsultaSQL += "OUEOESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBUREJOB, ESTADO, USUARIO, MANT_CLASOBUR, MANT_FOPAPLPA "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "OUEOESTA = ESTACODI AND "
            stConsultaSQL += "OUEONDSU = USUANUDO AND "
            stConsultaSQL += "OUEOFOPA = FPPPCODI AND "
            stConsultaSQL += "OUEOCLOU = CLOUCODI AND "
            stConsultaSQL += "OUEOSECU = '" & CInt(inOUEOSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUEOIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBUREJOB")
            Return Nothing

        End Try

    End Function

End Class
