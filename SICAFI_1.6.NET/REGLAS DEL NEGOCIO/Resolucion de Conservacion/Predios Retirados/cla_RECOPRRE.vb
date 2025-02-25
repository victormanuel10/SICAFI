Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RECOPRRE

    '===============================
    '*** CLASE PREDIOS RETIRADOS ***
    '===============================

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_RECOPRRE(ByVal inRCPRSECU As Integer, _
                                          ByVal inRCPRNURE As Integer, _
                                          ByVal stRCPRFERE As String, _
                                          ByVal inRCPRNUFI As Integer, _
                                          ByVal stRCPRMUNI As String, _
                                          ByVal stRCPRCORR As String, _
                                          ByVal stRCPRBARR As String, _
                                          ByVal stRCPRMANZ As String, _
                                          ByVal stRCPRPRED As String, _
                                          ByVal stRCPREDIF As String, _
                                          ByVal stRCPRUNPR As String, _
                                          ByVal inRCPRCLSE As Integer, _
                                          ByVal stRCPRDIRE As String, _
                                          ByVal stRCPRMAIN As String, _
                                          ByVal stRCPRESTA As String) As Boolean


        Try
            ' declara la variable
            Dim stRCPRCECA As String = inRCPRCLSE & stRCPRBARR & stRCPRMANZ & stRCPRPRED & stRCPREDIF & stRCPRUNPR
            Dim stRCPRDEPA As String = "05"

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RECOPRRE "

            stConsultaSQL += "( "
            stConsultaSQL += "RCPRSECU, "
            stConsultaSQL += "RCPRNURE, "
            stConsultaSQL += "RCPRFERE, "
            stConsultaSQL += "RCPRNUFI, "
            stConsultaSQL += "RCPRDEPA, "
            stConsultaSQL += "RCPRMUNI, "
            stConsultaSQL += "RCPRCORR, "
            stConsultaSQL += "RCPRBARR, "
            stConsultaSQL += "RCPRMANZ, "
            stConsultaSQL += "RCPRPRED, "
            stConsultaSQL += "RCPREDIF, "
            stConsultaSQL += "RCPRUNPR, "
            stConsultaSQL += "RCPRCECA, "
            stConsultaSQL += "RCPRCLSE, "
            stConsultaSQL += "RCPRDIRE, "
            stConsultaSQL += "RCPRMAIN, "
            stConsultaSQL += "RCPRESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRCPRSECU) & "', "
            stConsultaSQL += "'" & CInt(inRCPRNURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRFERE)) & "', "
            stConsultaSQL += "'" & CInt(inRCPRNUFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPREDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRUNPR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRCECA)) & "', "
            stConsultaSQL += "'" & CInt(inRCPRCLSE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRDIRE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRMAIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RECOPRRE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RECOPRRE(ByVal inRCPRIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECOPRRE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPRIDRE = '" & CInt(inRCPRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RECOPRRE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RECOPRRE(ByVal inRCPRSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECOPRRE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPRSECU = '" & CInt(inRCPRSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RECOPRRE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RECOPRRE(ByVal inRCPRIDRE As Integer, _
                                            ByVal inRCPRSECU As Integer, _
                                            ByVal inRCPRNURE As Integer, _
                                            ByVal stRCPRFERE As String, _
                                            ByVal inRCPRNUFI As Integer, _
                                            ByVal stRCPRMUNI As String, _
                                            ByVal stRCPRCORR As String, _
                                            ByVal stRCPRBARR As String, _
                                            ByVal stRCPRMANZ As String, _
                                            ByVal stRCPRPRED As String, _
                                            ByVal stRCPREDIF As String, _
                                            ByVal stRCPRUNPR As String, _
                                            ByVal inRCPRCLSE As Integer, _
                                            ByVal stRCPRDIRE As String, _
                                            ByVal stRCPRMAIN As String, _
                                            ByVal stRCPRESTA As String) As Boolean

        Try
            ' declara la variable
            Dim stRCPRCECA As String = inRCPRCLSE & stRCPRBARR & stRCPRMANZ & stRCPRPRED & stRCPREDIF & stRCPRUNPR

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RECOPRRE "

            stConsultaSQL += "SET "
            stConsultaSQL += "RCPRSECU = '" & CInt(inRCPRSECU) & "', "
            stConsultaSQL += "RCPRNURE = '" & CInt(inRCPRNURE) & "', "
            stConsultaSQL += "RCPRFERE = '" & CStr(Trim(stRCPRFERE)) & "', "
            stConsultaSQL += "RCPRNUFI = '" & CInt(inRCPRNUFI) & "', "
            stConsultaSQL += "RCPRMUNI = '" & CStr(Trim(stRCPRMUNI)) & "', "
            stConsultaSQL += "RCPRCORR = '" & CStr(Trim(stRCPRCORR)) & "', "
            stConsultaSQL += "RCPRBARR = '" & CStr(Trim(stRCPRBARR)) & "', "
            stConsultaSQL += "RCPRMANZ = '" & CStr(Trim(stRCPRMANZ)) & "', "
            stConsultaSQL += "RCPRPRED = '" & CStr(Trim(stRCPRPRED)) & "', "
            stConsultaSQL += "RCPRCECA = '" & CStr(Trim(stRCPRCECA)) & "', "
            stConsultaSQL += "RCPREDIF = '" & CStr(Trim(stRCPREDIF)) & "', "
            stConsultaSQL += "RCPRUNPR = '" & CStr(Trim(stRCPRUNPR)) & "', "
            stConsultaSQL += "RCPRCLSE = '" & CInt(inRCPRCLSE) & "', "
            stConsultaSQL += "RCPRDIRE = '" & CStr(Trim(stRCPRDIRE)) & "', "
            stConsultaSQL += "RCPRMAIN = '" & CStr(Trim(stRCPRMAIN)) & "', "
            stConsultaSQL += "RCPRESTA = '" & CStr(Trim(stRCPRESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPRIDRE = '" & CInt(inRCPRIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RECOPRRE")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RECOPRRE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RCPRIDRE, "
            stConsultaSQL += "RCPRSECU, "
            stConsultaSQL += "RCPRNURE, "
            stConsultaSQL += "RCPRFERE, "
            stConsultaSQL += "RCPRNUFI, "
            stConsultaSQL += "RCPRMUNI, "
            stConsultaSQL += "RCPRCORR, "
            stConsultaSQL += "RCPRBARR, "
            stConsultaSQL += "RCPRMANZ, "
            stConsultaSQL += "RCPRPRED, "
            stConsultaSQL += "RCPREDIF, "
            stConsultaSQL += "RCPRUNPR, "
            stConsultaSQL += "RCPRCLSE, "
            stConsultaSQL += "RCPRMAIN, "
            stConsultaSQL += "RCPRDIRE, "
            stConsultaSQL += "RCPRESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRRE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RCPRMUNI, RCPRCORR, RCPRBARR, RCPRMANZ, RCPRPRED, RCPREDIF, RCPRUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECOPRRE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_RECOPRRE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRRE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RCPRMUNI, RCPRCORR, RCPRBARR, RCPRMANZ, RCPRPRED, RCPREDIF, RCPRUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_RECOPRRE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_RECOPRRE(ByVal inRCPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRRE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPRIDRE = '" & CInt(inRCPRIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_RECOPRRE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECOPRRE(ByVal inRCPRSECU As Integer, ByVal inRCPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRRE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPRSECU = '" & CInt(inRCPRSECU) & "' AND "
            stConsultaSQL += "RCPRIDRE = '" & CInt(inRCPRIDRE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RECOPRRE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECOPRRE(ByVal inRCPRSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRRE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPRSECU = '" & CInt(inRCPRSECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RECOPRRE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECOPRRE(ByVal inRCPRNURE As Integer, ByVal stRCPRFERE As String, ByVal inRCPRNUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRRE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPRNURE = '" & CInt(inRCPRNURE) & "' AND "
            stConsultaSQL += "RCPRFERE = '" & CStr(Trim(stRCPRFERE)) & "' AND "
            stConsultaSQL += "RCPRNUFI = '" & CInt(inRCPRNUFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RECOPRRE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECOPRRE(ByVal inRCPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RCPRIDRE, "
            stConsultaSQL += "RCPRSECU, "
            stConsultaSQL += "RCPRNURE, "
            stConsultaSQL += "RCPRFERE, "
            stConsultaSQL += "RCPRNUFI, "
            stConsultaSQL += "RCPRMUNI, "
            stConsultaSQL += "RCPRCORR, "
            stConsultaSQL += "RCPRBARR, "
            stConsultaSQL += "RCPRMANZ, "
            stConsultaSQL += "RCPRPRED, "
            stConsultaSQL += "RCPREDIF, "
            stConsultaSQL += "RCPRUNPR, "
            stConsultaSQL += "RCPRCLSE, "
            stConsultaSQL += "RCPRCECA, "
            stConsultaSQL += "RCPRMAIN, "
            stConsultaSQL += "RCPRDIRE, "
            stConsultaSQL += "RCPRESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRRE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPRSECU = '" & CInt(inRCPRIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RCPRMUNI, RCPRCORR, RCPRBARR, RCPRMANZ, RCPRPRED, RCPREDIF, RCPRUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECOPRRE")
            Return Nothing

        End Try

    End Function


End Class
