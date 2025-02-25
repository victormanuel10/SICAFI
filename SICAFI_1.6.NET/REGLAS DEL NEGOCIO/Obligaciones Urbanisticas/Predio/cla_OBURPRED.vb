Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_OBURPRED

    '==============================================
    '*** CLASE PREDIO OBLIGACIONES URBANISTICAS ***
    '==============================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_OBURPRED(ByVal stOUPRCLEN As String, _
                                                         ByVal inOUPRNURE As Integer, _
                                                         ByVal stOUPRFERE As String, _
                                                         ByVal obOUPRMAIN As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(stOUPRCLEN) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(inOUPRNURE) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(stOUPRFERE) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obOUPRMAIN.Text) = True Then

                Dim objdatos1 As New cla_OBURPRED
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_OBURPRED(stOUPRCLEN, inOUPRNURE, stOUPRFERE, obOUPRMAIN.Text)

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
    Public Function fun_Insertar_OBURPRED(ByVal inOUPRSECU As Integer, _
                                          ByVal stOUPRCLEN As String, _
                                          ByVal inOUPRNURE As Integer, _
                                          ByVal stOUPRFERE As String, _
                                          ByVal inOUPRMAIN As Integer, _
                                          ByVal stOUPRMUNI As String, _
                                          ByVal stOUPRCORR As String, _
                                          ByVal stOUPRBARR As String, _
                                          ByVal stOUPRMANZ As String, _
                                          ByVal stOUPRPRED As String, _
                                          ByVal stOUPREDIF As String, _
                                          ByVal stOUPRUNPR As String, _
                                          ByVal inOUPRCLSE As Integer, _
                                          ByVal inOUPRNUFI As Integer, _
                                          ByVal inOUPRARTE As Integer, _
                                          ByVal loOUPRVATP As Long, _
                                          ByVal loOUPRVACP As Long, _
                                          ByVal loOUPRAVCA As Long, _
                                          ByVal inOUPRZOPL As Integer, _
                                          ByVal stOUPRESTA As String) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "OBURPRED "

            stConsultaSQL += "( "
            stConsultaSQL += "OUPRSECU, "
            stConsultaSQL += "OUPRCLEN, "
            stConsultaSQL += "OUPRNURE, "
            stConsultaSQL += "OUPRFERE, "
            stConsultaSQL += "OUPRMAIN, "
            stConsultaSQL += "OUPRMUNI, "
            stConsultaSQL += "OUPRCORR, "
            stConsultaSQL += "OUPRBARR, "
            stConsultaSQL += "OUPRMANZ, "
            stConsultaSQL += "OUPRPRED, "
            stConsultaSQL += "OUPREDIF, "
            stConsultaSQL += "OUPRUNPR, "
            stConsultaSQL += "OUPRCLSE, "
            stConsultaSQL += "OUPRNUFI, "
            stConsultaSQL += "OUPRARTE, "
            stConsultaSQL += "OUPRVATP, "
            stConsultaSQL += "OUPRVACP, "
            stConsultaSQL += "OUPRAVCA, "
            stConsultaSQL += "OUPRZOPL, "
            stConsultaSQL += "OUPRESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inOUPRSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUPRCLEN)) & "', "
            stConsultaSQL += "'" & CInt(inOUPRNURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUPRFERE)) & "', "
            stConsultaSQL += "'" & CInt(inOUPRMAIN) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUPRMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUPRCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUPRBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUPRMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUPRPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUPREDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUPRUNPR)) & "', "
            stConsultaSQL += "'" & CInt(inOUPRCLSE) & "', "
            stConsultaSQL += "'" & CInt(inOUPRNUFI) & "', "
            stConsultaSQL += "'" & CInt(inOUPRARTE) & "', "
            stConsultaSQL += "'" & CDbl(loOUPRVATP) & "', "
            stConsultaSQL += "'" & CDbl(loOUPRVACP) & "', "
            stConsultaSQL += "'" & CDbl(loOUPRAVCA) & "', "
            stConsultaSQL += "'" & CInt(inOUPRZOPL) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUPRESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_OBURPRED")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_OBURPRED(ByVal inOUPRIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "OBURPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUPRIDRE = '" & CInt(inOUPRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_OBURPRED")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_OBURPRED(ByVal inOUPRSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "OBURPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUPRSECU = '" & CInt(inOUPRSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_OBURPRED")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_OBURPRED(ByVal inOUPRIDRE As Integer, _
                                            ByVal inOUPRSECU As Integer, _
                                            ByVal stOUPRCLEN As String, _
                                            ByVal inOUPRNURE As Integer, _
                                            ByVal stOUPRFERE As String, _
                                            ByVal inOUPRMAIN As Integer, _
                                            ByVal stOUPRMUNI As String, _
                                            ByVal stOUPRCORR As String, _
                                            ByVal stOUPRBARR As String, _
                                            ByVal stOUPRMANZ As String, _
                                            ByVal stOUPRPRED As String, _
                                            ByVal stOUPREDIF As String, _
                                            ByVal stOUPRUNPR As String, _
                                            ByVal inOUPRCLSE As Integer, _
                                            ByVal inOUPRNUFI As Integer, _
                                            ByVal inOUPRARTE As Integer, _
                                            ByVal loOUPRVATP As Long, _
                                            ByVal loOUPRVACP As Long, _
                                            ByVal loOUPRAVCA As Long, _
                                            ByVal inOUPRZOPL As Integer, _
                                            ByVal stOUPRESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "OBURPRED "

            stConsultaSQL += "SET "
            stConsultaSQL += "OUPRSECU = '" & CInt(inOUPRSECU) & "', "
            stConsultaSQL += "OUPRCLEN = '" & CStr(Trim(stOUPRCLEN)) & "', "
            stConsultaSQL += "OUPRNURE = '" & CInt(inOUPRNURE) & "', "
            stConsultaSQL += "OUPRFERE = '" & CStr(Trim(stOUPRFERE)) & "', "
            stConsultaSQL += "OUPRMAIN = '" & CInt(inOUPRMAIN) & "', "
            stConsultaSQL += "OUPRMUNI = '" & CStr(Trim(stOUPRMUNI)) & "', "
            stConsultaSQL += "OUPRCORR = '" & CStr(Trim(stOUPRCORR)) & "', "
            stConsultaSQL += "OUPRBARR = '" & CStr(Trim(stOUPRBARR)) & "', "
            stConsultaSQL += "OUPRMANZ = '" & CStr(Trim(stOUPRMANZ)) & "', "
            stConsultaSQL += "OUPRPRED = '" & CStr(Trim(stOUPRPRED)) & "', "
            stConsultaSQL += "OUPREDIF = '" & CStr(Trim(stOUPREDIF)) & "', "
            stConsultaSQL += "OUPRUNPR = '" & CStr(Trim(stOUPRUNPR)) & "', "
            stConsultaSQL += "OUPRCLSE = '" & CInt(inOUPRCLSE) & "', "
            stConsultaSQL += "OUPRNUFI = '" & CInt(inOUPRNUFI) & "', "
            stConsultaSQL += "OUPRARTE = '" & CInt(inOUPRARTE) & "', "
            stConsultaSQL += "OUPRVATP = '" & CLng(loOUPRVATP) & "', "
            stConsultaSQL += "OUPRVACP = '" & CLng(loOUPRVACP) & "', "
            stConsultaSQL += "OUPRAVCA = '" & CLng(loOUPRAVCA) & "', "
            stConsultaSQL += "OUPRZOPL = '" & CInt(inOUPRZOPL) & "', "
            stConsultaSQL += "OUPRESTA = '" & CStr(Trim(stOUPRESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUPRIDRE = '" & CInt(inOUPRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_OBURPRED")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_OBURPRED() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUPRIDRE, "
            stConsultaSQL += "OUPRSECU, "
            stConsultaSQL += "OUPRCLEN, "
            stConsultaSQL += "OUPRNURE, "
            stConsultaSQL += "OUPRFERE, "
            stConsultaSQL += "OUPRMUNI, "
            stConsultaSQL += "OUPRCORR, "
            stConsultaSQL += "OUPRBARR, "
            stConsultaSQL += "OUPRMANZ, "
            stConsultaSQL += "OUPRPRED, "
            stConsultaSQL += "OUPREDIF, "
            stConsultaSQL += "OUPRUNPR, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "OUPRMAIN, "
            stConsultaSQL += "OUPRNUFI, "
            stConsultaSQL += "OUPRARTE, "
            stConsultaSQL += "OUPRVATP, "
            stConsultaSQL += "OUPRVACP, "
            stConsultaSQL += "OUPRAVCA, "
            stConsultaSQL += "OUPRZOPL, "
            stConsultaSQL += "ZOPLDESC, "
            stConsultaSQL += "OUPRESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURPRED, MANT_CLASSECT, MANT_ZONAPLAN, ESTADO "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "OUPRCLSE = CLSECODI AND "
            stConsultaSQL += "OUPRESTA = ESTACODI AND "
            stConsultaSQL += "OUPRZOPL = ZOPLCODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUPRIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_OBURPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_OBURPRED() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURPRED "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUPRIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_OBURPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_OBURPRED(ByVal inOUPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUPRIDRE = '" & CInt(inOUPRIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_OBURPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_OBURPRED(ByVal stOUPRCLEN As String, _
                                                 ByVal inOUPRNURE As Integer, _
                                                 ByVal stOUPRFERE As String, _
                                                 ByVal inOUPRMAIN As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUPRCLEN = '" & CStr(Trim(stOUPRCLEN)) & "' AND "
            stConsultaSQL += "OUPRNURE = '" & CInt(inOUPRNURE) & "'AND  "
            stConsultaSQL += "OUPRFERE = '" & CStr(Trim(stOUPRFERE)) & "' AND "
            stConsultaSQL += "OUPRMAIN = '" & CInt(inOUPRMAIN) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_OBURPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_OBURPRED(ByVal stOUPRCLEN As String, _
                                                 ByVal inOUPRNURE As Integer, _
                                                 ByVal stOUPRFERE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUPRCLEN = '" & CStr(Trim(stOUPRCLEN)) & "' AND "
            stConsultaSQL += "OUPRNURE = '" & CInt(inOUPRNURE) & "'AND  "
            stConsultaSQL += "OUPRFERE = '" & CStr(Trim(stOUPRFERE)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_OBURPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURPRED(ByVal inOUPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUPRIDRE, "
            stConsultaSQL += "OUPRSECU, "
            stConsultaSQL += "OUPRCLEN, "
            stConsultaSQL += "OUPRNURE, "
            stConsultaSQL += "OUPRFERE, "
            stConsultaSQL += "OUPRMUNI, "
            stConsultaSQL += "OUPRCORR, "
            stConsultaSQL += "OUPRBARR, "
            stConsultaSQL += "OUPRMANZ, "
            stConsultaSQL += "OUPRPRED, "
            stConsultaSQL += "OUPREDIF, "
            stConsultaSQL += "OUPRUNPR, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "OUPRMAIN, "
            stConsultaSQL += "OUPRNUFI, "
            stConsultaSQL += "OUPRARTE, "
            stConsultaSQL += "OUPRVATP, "
            stConsultaSQL += "OUPRVACP, "
            stConsultaSQL += "OUPRAVCA, "
            stConsultaSQL += "OUPRZOPL, "
            stConsultaSQL += "ZOPLDESC, "
            stConsultaSQL += "OUPRESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURPRED, MANT_CLASSECT, MANT_ZONAPLAN, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUPRCLSE = CLSECODI AND "
            stConsultaSQL += "OUPRCLSE = CLSECODI AND "
            stConsultaSQL += "OUPRESTA = ESTACODI AND "
            stConsultaSQL += "OUPRZOPL = ZOPLCODI AND "
            stConsultaSQL += "OUPRIDRE = '" & CInt(inOUPRIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUPRIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURPRED")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURPRED(ByVal inOUPRSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUPRIDRE, "
            stConsultaSQL += "OUPRSECU, "
            stConsultaSQL += "OUPRCLEN, "
            stConsultaSQL += "OUPRNURE, "
            stConsultaSQL += "OUPRFERE, "
            stConsultaSQL += "OUPRMUNI, "
            stConsultaSQL += "OUPRCORR, "
            stConsultaSQL += "OUPRBARR, "
            stConsultaSQL += "OUPRMANZ, "
            stConsultaSQL += "OUPRPRED, "
            stConsultaSQL += "OUPREDIF, "
            stConsultaSQL += "OUPRUNPR, "
            stConsultaSQL += "OUPRCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "OUPRMAIN, "
            stConsultaSQL += "OUPRNUFI, "
            stConsultaSQL += "OUPRARTE, "
            stConsultaSQL += "OUPRVATP, "
            stConsultaSQL += "OUPRVACP, "
            stConsultaSQL += "OUPRAVCA, "
            stConsultaSQL += "OUPRZOPL, "
            stConsultaSQL += "ZOPLDESC, "
            stConsultaSQL += "OUPRESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURPRED, MANT_CLASSECT, MANT_ZONAPLAN, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUPRCLSE = CLSECODI AND "
            stConsultaSQL += "OUPRESTA = ESTACODI AND "
            stConsultaSQL += "OUPRZOPL = ZOPLCODI AND "
            stConsultaSQL += "OUPRSECU = '" & CInt(inOUPRSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUPRIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURPRED")
            Return Nothing

        End Try

    End Function


End Class
