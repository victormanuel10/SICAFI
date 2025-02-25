Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_OBURAJLI

    '=============================================================
    '*** CLASE AJUSTE DE LIQUIDACION OBLIGACIONES URBANISTICAS ***
    '=============================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_OBURAJLI(ByVal stOUALCLEN As String, _
                                                         ByVal inOUALNURE As Integer, _
                                                         ByVal stOUALFERE As String, _
                                                         ByVal inOUALCLOU As Integer, _
                                                         ByVal inOUALNULI As Integer, _
                                                         ByVal obOUALNUAL As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(stOUALCLEN) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(inOUALNURE) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(stOUALFERE) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(inOUALCLOU) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(inOUALNULI) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obOUALNUAL.Text) = True Then

                Dim objdatos1 As New cla_OBURAJLI
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_OBURAJLI(stOUALCLEN, inOUALNURE, stOUALFERE, inOUALCLOU, inOUALNULI, obOUALNUAL.Text)

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
    Public Function fun_Insertar_OBURAJLI(ByVal inOUALSECU As Integer, _
                                          ByVal stOUALCLEN As String, _
                                          ByVal inOUALNURE As Integer, _
                                          ByVal stOUALFERE As String, _
                                          ByVal inOUALCLOU As Integer, _
                                          ByVal inOUALNULI As Integer, _
                                          ByVal inOUALNUAL As Integer, _
                                          ByVal loOUALLIQU As Long, _
                                          ByVal loOUALLIAJ As Long, _
                                          ByVal stOUALOBSE As String) As Boolean


        Try
            ' variables 
            Dim daOUALFEIN As Date = fun_fecha()
            Dim stOUALUSIN As String = fun_usuario()
            Dim stOUALNDIN As String = fun_cedula()
            Dim stOUALMAQU As String = fun_Nombre_de_maquina()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "OBURAJLI "

            stConsultaSQL += "( "
            stConsultaSQL += "OUALSECU, "
            stConsultaSQL += "OUALCLEN, "
            stConsultaSQL += "OUALNURE, "
            stConsultaSQL += "OUALFERE, "
            stConsultaSQL += "OUALCLOU, "
            stConsultaSQL += "OUALNULI, "
            stConsultaSQL += "OUALNUAL, "
            stConsultaSQL += "OUALLIQU, "
            stConsultaSQL += "OUALLIAJ, "
            stConsultaSQL += "OUALOBSE, "
            stConsultaSQL += "OUALFEIN, "
            stConsultaSQL += "OUALUSIN, "
            stConsultaSQL += "OUALNDIN, "
            stConsultaSQL += "OUALMAQU "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inOUALSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUALCLEN)) & "', "
            stConsultaSQL += "'" & CInt(inOUALNURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUALFERE)) & "', "
            stConsultaSQL += "'" & CInt(inOUALCLOU) & "', "
            stConsultaSQL += "'" & CInt(inOUALNULI) & "', "
            stConsultaSQL += "'" & CInt(inOUALNUAL) & "', "
            stConsultaSQL += "'" & CLng(loOUALLIQU) & "', "
            stConsultaSQL += "'" & CLng(loOUALLIAJ) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUALOBSE)) & "', "
            stConsultaSQL += "'" & CDate(daOUALFEIN) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUALUSIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUALNDIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUALMAQU)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_OBURAJLI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_OBURAJLI(ByVal inOUALIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "OBURAJLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUALIDRE = '" & CInt(inOUALIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_OBURAJLI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_OBURAJLI(ByVal inOUALSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "OBURAJLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUALSECU = '" & CInt(inOUALSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_OBURAJLI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_OBURAJLI(ByVal inOUALIDRE As Integer, _
                                            ByVal inOUALSECU As Integer, _
                                            ByVal stOUALCLEN As String, _
                                            ByVal inOUALNURE As Integer, _
                                            ByVal stOUALFERE As String, _
                                            ByVal inOUALCLOU As Integer, _
                                            ByVal inOUALNULI As Integer, _
                                            ByVal inOUALNUAL As Integer, _
                                            ByVal loOUALLIQU As Long, _
                                            ByVal loOUALLIAJ As Long, _
                                            ByVal stOUALOBSE As String) As Boolean

        Try
            ' variables 
            Dim stOUALUSLI As String = fun_usuario()
            Dim stOUALNDLI As String = fun_cedula()
            Dim daOUALFELI As Date = fun_fecha()
            Dim inOUALVILI As Integer = fun_Vigencia()
            Dim stOUALMAQU As String = fun_Nombre_de_maquina()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "OBURAJLI "

            stConsultaSQL += "SET "
            stConsultaSQL += "OUALSECU = '" & CInt(inOUALSECU) & "', "
            stConsultaSQL += "OUALCLEN = '" & CStr(Trim(stOUALCLEN)) & "', "
            stConsultaSQL += "OUALNURE = '" & CInt(inOUALNURE) & "', "
            stConsultaSQL += "OUALFERE = '" & CStr(Trim(stOUALFERE)) & "', "
            stConsultaSQL += "OUALCLOU = '" & CInt(inOUALCLOU) & "', "
            stConsultaSQL += "OUALNULI = '" & CInt(inOUALNULI) & "', "
            stConsultaSQL += "OUALNUAL = '" & CInt(inOUALNUAL) & "', "
            stConsultaSQL += "OUALLIQU = '" & CLng(loOUALLIQU) & "', "
            stConsultaSQL += "OUALLIAJ = '" & CLng(loOUALLIAJ) & "', "
            stConsultaSQL += "OUALOBSE = '" & CStr(Trim(stOUALOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUALIDRE = '" & CInt(inOUALIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_OBURAJLI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_OBURAJLI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUALIDRE, "
            stConsultaSQL += "OUALSECU, "
            stConsultaSQL += "OUALCLEN, "
            stConsultaSQL += "OUALNURE, "
            stConsultaSQL += "OUALFERE, "
            stConsultaSQL += "OUALCLOU, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "OUALNULI, "
            stConsultaSQL += "OUALNUAL, "
            stConsultaSQL += "OUALLIQU, "
            stConsultaSQL += "OUALLIAJ, "
            stConsultaSQL += "OUALOBSE, "
            stConsultaSQL += "OUALFEIN "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURAJLI, MANT_CLASOBUR "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "OUALCLOU = CLOUCODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUALIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_OBURAJLI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_OBURAJLI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURAJLI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUALIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_OBURAJLI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_OBURAJLI(ByVal inOUALIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURAJLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUALIDRE = '" & CInt(inOUALIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_OBURAJLI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_OBURAJLI(ByVal stOUALCLEN As String, _
                                                 ByVal inOUALNURE As Integer, _
                                                 ByVal stOUALFERE As String, _
                                                 ByVal inOUALCLOU As Integer, _
                                                 ByVal inOUALNULI As Integer, _
                                                 ByVal inOUALNUAL As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURAJLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUALCLEN = '" & CStr(Trim(stOUALCLEN)) & "' AND "
            stConsultaSQL += "OUALNURE = '" & CInt(inOUALNURE) & "' AND "
            stConsultaSQL += "OUALFERE = '" & CStr(Trim(stOUALFERE)) & "' AND "
            stConsultaSQL += "OUALCLOU = '" & CInt(inOUALCLOU) & "' AND "
            stConsultaSQL += "OUALNULI = '" & CInt(inOUALNULI) & "' AND "
            stConsultaSQL += "OUALNUAL = '" & CInt(inOUALNUAL) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_OBURAJLI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURAJLI(ByVal inOUALIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
             stConsultaSQL += "SELECT "
            stConsultaSQL += "OUALIDRE, "
            stConsultaSQL += "OUALSECU, "
            stConsultaSQL += "OUALCLEN, "
            stConsultaSQL += "OUALNURE, "
            stConsultaSQL += "OUALFERE, "
            stConsultaSQL += "OUALCLOU, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "OUALNULI, "
            stConsultaSQL += "OUALNUAL, "
            stConsultaSQL += "OUALLIQU, "
            stConsultaSQL += "OUALLIAJ, "
            stConsultaSQL += "OUALOBSE, "
            stConsultaSQL += "OUALFEIN, "
            stConsultaSQL += "OUALUSIN, "
            stConsultaSQL += "OUALMAQU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURAJLI, MANT_CLASOBUR "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "OUALCLOU = CLOUCODI AND "
            stConsultaSQL += "OUALIDRE = '" & CInt(inOUALIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUALIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURAJLI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURAJLI(ByVal inOUALSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
             stConsultaSQL += "SELECT "
            stConsultaSQL += "OUALIDRE, "
            stConsultaSQL += "OUALSECU, "
            stConsultaSQL += "OUALCLEN, "
            stConsultaSQL += "OUALNURE, "
            stConsultaSQL += "OUALFERE, "
            stConsultaSQL += "OUALCLOU, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "OUALNULI, "
            stConsultaSQL += "OUALNUAL, "
            stConsultaSQL += "OUALLIQU, "
            stConsultaSQL += "OUALLIAJ, "
            stConsultaSQL += "OUALOBSE, "
            stConsultaSQL += "OUALFEIN, "
            stConsultaSQL += "OUALUSIN, "
            stConsultaSQL += "OUALMAQU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURAJLI, MANT_CLASOBUR "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "OUALCLOU = CLOUCODI AND "
            stConsultaSQL += "OUALSECU = '" & CInt(inOUALSECU) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUALIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURAJLI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_AJLI_X_CONSULTA_PARAMETRIZADA_OBURAJLI(ByVal inOUALSECU As Integer, _
                                                                      ByVal stOUALCLEN As String, _
                                                                      ByVal inOUALNURE As Integer, _
                                                                      ByVal stOUALFERE As String, _
                                                                      ByVal inOUALCLOU As Integer, _
                                                                      ByVal inOUALNULI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUALIDRE, "
            stConsultaSQL += "OUALSECU, "
            stConsultaSQL += "OUALCLEN, "
            stConsultaSQL += "OUALNURE, "
            stConsultaSQL += "OUALFERE, "
            stConsultaSQL += "OUALCLOU, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "OUALNULI, "
            stConsultaSQL += "OUALNUAL, "
            stConsultaSQL += "OUALLIQU, "
            stConsultaSQL += "OUALLIAJ, "
            stConsultaSQL += "OUALOBSE, "
            stConsultaSQL += "OUALFEIN, "
            stConsultaSQL += "OUALUSIN, "
            stConsultaSQL += "OUALMAQU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURAJLI, MANT_CLASOBUR "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "OUALCLOU = CLOUCODI AND "
            stConsultaSQL += "OUALSECU = '" & CInt(inOUALSECU) & "' AND "
            stConsultaSQL += "OUALCLEN = '" & CStr(Trim(stOUALCLEN)) & "' AND "
            stConsultaSQL += "OUALNURE = '" & CInt(inOUALNURE) & "' AND "
            stConsultaSQL += "OUALFERE = '" & CStr(Trim(stOUALFERE)) & "' AND "
            stConsultaSQL += "OUALCLOU = '" & CInt(inOUALCLOU) & "' AND "
            stConsultaSQL += "OUALNULI = '" & CInt(inOUALNULI) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUALIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURAJLI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_AJLI_X_CONSULTA_PARAMETRIZADA_OBURAJLI(ByVal inOUALSECU As Integer, _
                                                                      ByVal stOUALCLEN As String, _
                                                                      ByVal inOUALNURE As Integer, _
                                                                      ByVal stOUALFERE As String, _
                                                                      ByVal inOUALCLOU As Integer, _
                                                                      ByVal inOUALNULI As Integer, _
                                                                      ByVal inOUALNUAL As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUALIDRE, "
            stConsultaSQL += "OUALSECU, "
            stConsultaSQL += "OUALCLEN, "
            stConsultaSQL += "OUALNURE, "
            stConsultaSQL += "OUALFERE, "
            stConsultaSQL += "OUALCLOU, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "OUALNULI, "
            stConsultaSQL += "OUALNUAL, "
            stConsultaSQL += "OUALLIQU, "
            stConsultaSQL += "OUALLIAJ, "
            stConsultaSQL += "OUALOBSE, "
            stConsultaSQL += "OUALFEIN, "
            stConsultaSQL += "OUALUSIN, "
            stConsultaSQL += "OUALMAQU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURAJLI, MANT_CLASOBUR "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "OUALCLOU = CLOUCODI AND "
            stConsultaSQL += "OUALSECU = '" & CInt(inOUALSECU) & "' AND "
            stConsultaSQL += "OUALCLEN = '" & CStr(Trim(stOUALCLEN)) & "' AND "
            stConsultaSQL += "OUALNURE = '" & CInt(inOUALNURE) & "' AND "
            stConsultaSQL += "OUALFERE = '" & CStr(Trim(stOUALFERE)) & "' AND "
            stConsultaSQL += "OUALCLOU = '" & CInt(inOUALCLOU) & "' AND "
            stConsultaSQL += "OUALNULI = '" & CInt(inOUALNULI) & "' AND "
            stConsultaSQL += "OUALNUAL = '" & CInt(inOUALNUAL) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUALIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURAJLI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_OBURAJLI(ByVal inOUALSECU As Integer, _
                                                    ByVal stOUALCLEN As String, _
                                                    ByVal inOUALNURE As Integer, _
                                                    ByVal stOUALFERE As String, _
                                                    ByVal inOUALCLOU As Integer, _
                                                    ByVal inOUALNULI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUALNULI, "
            stConsultaSQL += "OUALSECU, "
            stConsultaSQL += "OUALCLEN, "
            stConsultaSQL += "OUALNURE, "
            stConsultaSQL += "OUALFERE, "
            stConsultaSQL += "OUALCLOU, "
            stConsultaSQL += "OUALNUAL "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURAJLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUALSECU = '" & CInt(inOUALSECU) & "' AND "
            stConsultaSQL += "OUALCLEN = '" & CStr(Trim(stOUALCLEN)) & "' AND "
            stConsultaSQL += "OUALNURE = '" & CInt(inOUALNURE) & "' AND "
            stConsultaSQL += "OUALFERE = '" & CStr(Trim(stOUALFERE)) & "' AND "
            stConsultaSQL += "OUALCLOU = '" & CInt(inOUALCLOU) & "' AND "
            stConsultaSQL += "OUALNULI = '" & CInt(inOUALNULI) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUALIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_X_OBLIURBA")
            Return Nothing
        End Try

    End Function

End Class
