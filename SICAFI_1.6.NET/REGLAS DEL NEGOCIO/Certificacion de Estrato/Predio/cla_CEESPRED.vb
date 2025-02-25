Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CEESPRED

    '======================================================
    '*** CLASE PREDIO CERTIFICACION DE ESTRACTIFICACION ***
    '======================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_CEESPRED(ByVal inCEPRNURE As Integer, _
                                                         ByVal stCEPRFERE As String, _
                                                         ByVal obCEPRMAIN As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inCEPRNURE) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(stCEPRFERE) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obCEPRMAIN.Text) = True Then

                Dim objdatos1 As New cla_CEESPRED
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_CEESPRED(inCEPRNURE, stCEPRFERE, obCEPRMAIN.Text)

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
    Public Function fun_Insertar_CEESPRED(ByVal inCEPRSECU As Integer, _
                                          ByVal inCEPRNURA As Integer, _
                                          ByVal stCEPRFERA As String, _
                                          ByVal inCEPRMAIN As Integer, _
                                          ByVal stCEPRMUNI As String, _
                                          ByVal stCEPRCORR As String, _
                                          ByVal stCEPRBARR As String, _
                                          ByVal stCEPRMANZ As String, _
                                          ByVal stCEPRPRED As String, _
                                          ByVal stCEPREDIF As String, _
                                          ByVal stCEPRUNPR As String, _
                                          ByVal inCEPRCLSE As Integer, _
                                          ByVal stCEPRDIPR As String, _
                                          ByVal inCEPRUNID As Integer, _
                                          ByVal inCEPRNUFI As Integer, _
                                          ByVal inCEPRARTE As Integer, _
                                          ByVal loCEPRVATP As Long, _
                                          ByVal loCEPRVACP As Long, _
                                          ByVal loCEPRAVCA As Long, _
                                          ByVal inCEPRZOPL As Integer, _
                                          ByVal inCEPRSEPU As Integer, _
                                          ByVal boCEPRPRPH As Boolean, _
                                          ByVal stCEPRESTA As String) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "CEESPRED "

            stConsultaSQL += "( "
            stConsultaSQL += "CEPRSECU, "
            stConsultaSQL += "CEPRNURA, "
            stConsultaSQL += "CEPRFERA, "
            stConsultaSQL += "CEPRMAIN, "
            stConsultaSQL += "CEPRMUNI, "
            stConsultaSQL += "CEPRCORR, "
            stConsultaSQL += "CEPRBARR, "
            stConsultaSQL += "CEPRMANZ, "
            stConsultaSQL += "CEPRPRED, "
            stConsultaSQL += "CEPREDIF, "
            stConsultaSQL += "CEPRUNPR, "
            stConsultaSQL += "CEPRCLSE, "
            stConsultaSQL += "CEPRDIPR, "
            stConsultaSQL += "CEPRUNID, "
            stConsultaSQL += "CEPRNUFI, "
            stConsultaSQL += "CEPRARTE, "
            stConsultaSQL += "CEPRVATP, "
            stConsultaSQL += "CEPRVACP, "
            stConsultaSQL += "CEPRAVCA, "
            stConsultaSQL += "CEPRZOPL, "
            stConsultaSQL += "CEPRSEPU, "
            stConsultaSQL += "CEPRPRPH, "
            stConsultaSQL += "CEPRESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inCEPRSECU) & "', "
            stConsultaSQL += "'" & CInt(inCEPRNURA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEPRFERA)) & "', "
            stConsultaSQL += "'" & CInt(inCEPRMAIN) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEPRMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEPRCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEPRBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEPRMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEPRPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEPREDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEPRUNPR)) & "', "
            stConsultaSQL += "'" & CInt(inCEPRCLSE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEPRDIPR)) & "', "
            stConsultaSQL += "'" & CInt(inCEPRUNID) & "', "
            stConsultaSQL += "'" & CInt(inCEPRNUFI) & "', "
            stConsultaSQL += "'" & CInt(inCEPRARTE) & "', "
            stConsultaSQL += "'" & CDbl(loCEPRVATP) & "', "
            stConsultaSQL += "'" & CDbl(loCEPRVACP) & "', "
            stConsultaSQL += "'" & CDbl(loCEPRAVCA) & "', "
            stConsultaSQL += "'" & CInt(inCEPRZOPL) & "', "
            stConsultaSQL += "'" & CInt(inCEPRSEPU) & "', "
            stConsultaSQL += "'" & CBool(boCEPRPRPH) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEPRESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_CEESPRED")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_CEESPRED(ByVal inCEPRIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "CEESPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEPRIDRE = '" & CInt(inCEPRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_CEESPRED")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_CEESPRED(ByVal inCEPRSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "CEESPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEPRSECU = '" & CInt(inCEPRSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_CEESPRED")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_CEESPRED(ByVal inCEPRIDRE As Integer, _
                                            ByVal inCEPRSECU As Integer, _
                                            ByVal inCEPRNURA As Integer, _
                                            ByVal stCEPRFERA As String, _
                                            ByVal inCEPRMAIN As Integer, _
                                            ByVal stCEPRMUNI As String, _
                                            ByVal stCEPRCORR As String, _
                                            ByVal stCEPRBARR As String, _
                                            ByVal stCEPRMANZ As String, _
                                            ByVal stCEPRPRED As String, _
                                            ByVal stCEPREDIF As String, _
                                            ByVal stCEPRUNPR As String, _
                                            ByVal inCEPRCLSE As Integer, _
                                            ByVal stCEPRDIPR As String, _
                                            ByVal inCEPRUNID As Integer, _
                                            ByVal inCEPRNUFI As Integer, _
                                            ByVal inCEPRARTE As Integer, _
                                            ByVal loCEPRVATP As Long, _
                                            ByVal loCEPRVACP As Long, _
                                            ByVal loCEPRAVCA As Long, _
                                            ByVal inCEPRZOPL As Integer, _
                                            ByVal inCEPRSEPU As Integer, _
                                            ByVal boCEPRPRPH As Boolean, _
                                            ByVal stCEPRESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "CEESPRED "

            stConsultaSQL += "SET "
            stConsultaSQL += "CEPRSECU = '" & CInt(inCEPRSECU) & "', "
            stConsultaSQL += "CEPRNURA = '" & CInt(inCEPRNURA) & "', "
            stConsultaSQL += "CEPRFERA = '" & CStr(Trim(stCEPRFERA)) & "', "
            stConsultaSQL += "CEPRMAIN = '" & CInt(inCEPRMAIN) & "', "
            stConsultaSQL += "CEPRMUNI = '" & CStr(Trim(stCEPRMUNI)) & "', "
            stConsultaSQL += "CEPRCORR = '" & CStr(Trim(stCEPRCORR)) & "', "
            stConsultaSQL += "CEPRBARR = '" & CStr(Trim(stCEPRBARR)) & "', "
            stConsultaSQL += "CEPRMANZ = '" & CStr(Trim(stCEPRMANZ)) & "', "
            stConsultaSQL += "CEPRPRED = '" & CStr(Trim(stCEPRPRED)) & "', "
            stConsultaSQL += "CEPREDIF = '" & CStr(Trim(stCEPREDIF)) & "', "
            stConsultaSQL += "CEPRUNPR = '" & CStr(Trim(stCEPRUNPR)) & "', "
            stConsultaSQL += "CEPRCLSE = '" & CInt(inCEPRCLSE) & "', "
            stConsultaSQL += "CEPRDIPR = '" & CStr(Trim(stCEPRDIPR)) & "', "
            stConsultaSQL += "CEPRUNID = '" & CInt(inCEPRUNID) & "', "
            stConsultaSQL += "CEPRNUFI = '" & CInt(inCEPRNUFI) & "', "
            stConsultaSQL += "CEPRARTE = '" & CInt(inCEPRARTE) & "', "
            stConsultaSQL += "CEPRVATP = '" & CLng(loCEPRVATP) & "', "
            stConsultaSQL += "CEPRVACP = '" & CLng(loCEPRVACP) & "', "
            stConsultaSQL += "CEPRAVCA = '" & CLng(loCEPRAVCA) & "', "
            stConsultaSQL += "CEPRZOPL = '" & CInt(inCEPRZOPL) & "', "
            stConsultaSQL += "CEPRSEPU = '" & CInt(inCEPRSEPU) & "', "
            stConsultaSQL += "CEPRPRPH = '" & CBool(boCEPRPRPH) & "', "
            stConsultaSQL += "CEPRESTA = '" & CStr(Trim(stCEPRESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEPRIDRE = '" & CInt(inCEPRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_CEESPRED")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_CEESPRED() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CEPRIDRE, "
            stConsultaSQL += "CEPRSECU, "
            stConsultaSQL += "CEPRNURA, "
            stConsultaSQL += "CEPRFERA, "
            stConsultaSQL += "CEPRMUNI, "
            stConsultaSQL += "CEPRCORR, "
            stConsultaSQL += "CEPRBARR, "
            stConsultaSQL += "CEPRMANZ, "
            stConsultaSQL += "CEPRPRED, "
            stConsultaSQL += "CEPREDIF, "
            stConsultaSQL += "CEPRUNPR, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "CEPRDIPR, "
            stConsultaSQL += "CEPRUNID, "
            stConsultaSQL += "CEPRMAIN, "
            stConsultaSQL += "CEPRPRPH, "
            stConsultaSQL += "CEPRNUFI, "
            stConsultaSQL += "CEPRARTE, "
            stConsultaSQL += "CEPRVATP, "
            stConsultaSQL += "CEPRVACP, "
            stConsultaSQL += "CEPRAVCA, "
            stConsultaSQL += "CEPRZOPL, "
            stConsultaSQL += "ZOPLDESC, "
            stConsultaSQL += "SERVDESC, "
            stConsultaSQL += "CEPRESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CEESPRED, MANT_CLASSECT, MANT_ZONAPLAN, MANT_SERVICIOS, ESTADO "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "CEPRCLSE = CLSECODI AND "
            stConsultaSQL += "CEPRESTA = ESTACODI AND "
            stConsultaSQL += "CEPRZOPL = ZOPLCODI AND "
            stConsultaSQL += "CEPRSEPU = SERVCODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CEPRIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CEESPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_CEESPRED() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CEESPRED "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CEPRIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_CEESPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_CEESPRED(ByVal inCEPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CEESPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEPRIDRE = '" & CInt(inCEPRIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_CEESPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_CEESPRED(ByVal inCEPRNURA As Integer, _
                                                 ByVal stCEPRFERA As String, _
                                                 ByVal inCEPRMAIN As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CEESPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEPRNURA = '" & CInt(inCEPRNURA) & "'AND  "
            stConsultaSQL += "CEPRFERA = '" & CStr(Trim(stCEPRFERA)) & "' AND "
            stConsultaSQL += "CEPRMAIN = '" & CInt(inCEPRMAIN) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_CEESPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_CEESPRED(ByVal inCEPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CEPRIDRE, "
            stConsultaSQL += "CEPRSECU, "
            stConsultaSQL += "CEPRNURA, "
            stConsultaSQL += "CEPRFERA, "
            stConsultaSQL += "CEPRMUNI, "
            stConsultaSQL += "CEPRCORR, "
            stConsultaSQL += "CEPRBARR, "
            stConsultaSQL += "CEPRMANZ, "
            stConsultaSQL += "CEPRPRED, "
            stConsultaSQL += "CEPREDIF, "
            stConsultaSQL += "CEPRUNPR, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "CEPRDIPR, "
            stConsultaSQL += "CEPRUNID, "
            stConsultaSQL += "CEPRMAIN, "
            stConsultaSQL += "CEPRPRPH, "
            stConsultaSQL += "CEPRNUFI, "
            stConsultaSQL += "CEPRARTE, "
            stConsultaSQL += "CEPRVATP, "
            stConsultaSQL += "CEPRVACP, "
            stConsultaSQL += "CEPRAVCA, "
            stConsultaSQL += "CEPRZOPL, "
            stConsultaSQL += "ZOPLDESC, "
            stConsultaSQL += "SERVDESC, "
            stConsultaSQL += "CEPRESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CEESPRED, MANT_CLASSECT, MANT_ZONAPLAN, MANT_SERVICIOS, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEPRCLSE = CLSECODI AND "
            stConsultaSQL += "CEPRCLSE = CLSECODI AND "
            stConsultaSQL += "CEPRESTA = ESTACODI AND "
            stConsultaSQL += "CEPRZOPL = ZOPLCODI AND "
            stConsultaSQL += "CEPRSEPU = SERVCODI AND "
            stConsultaSQL += "CEPRIDRE = '" & CInt(inCEPRIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CEPRIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_CEESPRED")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_CEESPRED(ByVal inCEPRSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CEPRIDRE, "
            stConsultaSQL += "CEPRSECU, "
            stConsultaSQL += "CEPRNURA, "
            stConsultaSQL += "CEPRFERA, "
            stConsultaSQL += "CEPRMUNI, "
            stConsultaSQL += "CEPRCORR, "
            stConsultaSQL += "CEPRBARR, "
            stConsultaSQL += "CEPRMANZ, "
            stConsultaSQL += "CEPRPRED, "
            stConsultaSQL += "CEPREDIF, "
            stConsultaSQL += "CEPRUNPR, "
            stConsultaSQL += "CEPRCLSE, "
            stConsultaSQL += "CEPRDIPR, "
            stConsultaSQL += "CEPRUNID, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "CEPRMAIN, "
            stConsultaSQL += "CEPRPRPH, "
            stConsultaSQL += "CEPRNUFI, "
            stConsultaSQL += "CEPRARTE, "
            stConsultaSQL += "CEPRVATP, "
            stConsultaSQL += "CEPRVACP, "
            stConsultaSQL += "CEPRAVCA, "
            stConsultaSQL += "CEPRZOPL, "
            stConsultaSQL += "ZOPLDESC, "
            stConsultaSQL += "SERVDESC, "
            stConsultaSQL += "CEPRESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CEESPRED, MANT_CLASSECT, MANT_ZONAPLAN, MANT_SERVICIOS, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEPRCLSE = CLSECODI AND "
            stConsultaSQL += "CEPRESTA = ESTACODI AND "
            stConsultaSQL += "CEPRZOPL = ZOPLCODI AND "
            stConsultaSQL += "CEPRSEPU = SERVCODI AND "
            stConsultaSQL += "CEPRSECU = '" & CInt(inCEPRSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CEPRIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_CEESPRED")
            Return Nothing

        End Try

    End Function

End Class
