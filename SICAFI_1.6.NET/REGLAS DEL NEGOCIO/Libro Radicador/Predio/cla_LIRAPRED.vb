Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_LIRAPRED

    '====================================
    '*** CLASE LIBRO RADICADOR PREDIO ***
    '====================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_LIRAPRED(ByVal inLRPRNURA As Integer, _
                                                         ByVal stLRPRFERA As String, _
                                                         ByVal inLRPRSECU As Integer, _
                                                         ByVal obLRPRMAIN As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inLRPRNURA) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(stLRPRFERA) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(inLRPRSECU) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obLRPRMAIN.Text) = True Then

                Dim objdatos1 As New cla_LIRAPRED
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_LIRAPRED(inLRPRNURA, stLRPRFERA, inLRPRSECU, obLRPRMAIN.Text)

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
    Public Function fun_Insertar_LIRAPRED(ByVal inLRPRNURA As Integer, _
                                          ByVal stLRPRFERA As String, _
                                          ByVal inLRPRSECU As Integer, _
                                          ByVal inLRPRMAIN As Integer, _
                                          ByVal stLRPRMUNI As String, _
                                          ByVal stLRPRCORR As String, _
                                          ByVal stLRPRBARR As String, _
                                          ByVal stLRPRMANZ As String, _
                                          ByVal stLRPRPRED As String, _
                                          ByVal stLRPREDIF As String, _
                                          ByVal stLRPRUNPR As String, _
                                          ByVal inLRPRCLSE As Integer, _
                                          ByVal inLRPRNUFI As Integer) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "LIRAPRED "

            stConsultaSQL += "( "
            stConsultaSQL += "LRPRNURA, "
            stConsultaSQL += "LRPRFERA, "
            stConsultaSQL += "LRPRSECU, "
            stConsultaSQL += "LRPRMAIN, "
            stConsultaSQL += "LRPRMUNI, "
            stConsultaSQL += "LRPRCORR, "
            stConsultaSQL += "LRPRBARR, "
            stConsultaSQL += "LRPRMANZ, "
            stConsultaSQL += "LRPRPRED, "
            stConsultaSQL += "LRPREDIF, "
            stConsultaSQL += "LRPRUNPR, "
            stConsultaSQL += "LRPRCLSE, "
            stConsultaSQL += "LRPRNUFI "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inLRPRNURA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRPRFERA)) & "', "
            stConsultaSQL += "'" & CInt(inLRPRSECU) & "', "
            stConsultaSQL += "'" & CInt(inLRPRMAIN) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRPRMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRPRCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRPRBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRPRMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRPRPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRPREDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRPRUNPR)) & "', "
            stConsultaSQL += "'" & CInt(inLRPRCLSE) & "', "
            stConsultaSQL += "'" & CInt(inLRPRNUFI) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_LIRAPRED")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_LIRAPRED(ByVal inLRPRIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "LIRAPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRPRIDRE = '" & CInt(inLRPRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_LIRAPRED")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_LIRAPRED(ByVal inLRPRSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "LIRAPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRPRSECU = '" & CInt(inLRPRSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_LIRAPRED")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_LIRAPRED(ByVal inLRPRIDRE As Integer, _
                                            ByVal inLRPRNURA As Integer, _
                                            ByVal stLRPRFERA As String, _
                                            ByVal inLRPRSECU As Integer, _
                                            ByVal inLRPRMAIN As Integer, _
                                            ByVal stLRPRMUNI As String, _
                                            ByVal stLRPRCORR As String, _
                                            ByVal stLRPRBARR As String, _
                                            ByVal stLRPRMANZ As String, _
                                            ByVal stLRPRPRED As String, _
                                            ByVal stLRPREDIF As String, _
                                            ByVal stLRPRUNPR As String, _
                                            ByVal inLRPRCLSE As Integer, _
                                            ByVal inLRPRNUFI As Integer) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "LIRAPRED "

            stConsultaSQL += "SET "
            stConsultaSQL += "LRPRNURA = '" & CInt(inLRPRNURA) & "', "
            stConsultaSQL += "LRPRFERA = '" & CStr(Trim(stLRPRFERA)) & "', "
            stConsultaSQL += "LRPRSECU = '" & CInt(inLRPRSECU) & "', "
            stConsultaSQL += "LRPRMAIN = '" & CInt(inLRPRMAIN) & "', "
            stConsultaSQL += "LRPRMUNI = '" & CStr(Trim(stLRPRMUNI)) & "', "
            stConsultaSQL += "LRPRCORR = '" & CStr(Trim(stLRPRCORR)) & "', "
            stConsultaSQL += "LRPRBARR = '" & CStr(Trim(stLRPRBARR)) & "', "
            stConsultaSQL += "LRPRMANZ = '" & CStr(Trim(stLRPRMANZ)) & "', "
            stConsultaSQL += "LRPRPRED = '" & CStr(Trim(stLRPRPRED)) & "', "
            stConsultaSQL += "LRPREDIF = '" & CStr(Trim(stLRPREDIF)) & "', "
            stConsultaSQL += "LRPRUNPR = '" & CStr(Trim(stLRPRUNPR)) & "', "
            stConsultaSQL += "LRPRCLSE = '" & CInt(inLRPRCLSE) & "', "
            stConsultaSQL += "LRPRNUFI = '" & CInt(inLRPRNUFI) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRPRIDRE = '" & CInt(inLRPRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_LIRAPRED")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_LIRAPRED() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "LRPRIDRE, "
            stConsultaSQL += "LRPRNURA, "
            stConsultaSQL += "LRPRFERA, "
            stConsultaSQL += "LRPRSECU, "
            stConsultaSQL += "LRPRMUNI, "
            stConsultaSQL += "LRPRCORR, "
            stConsultaSQL += "LRPRBARR, "
            stConsultaSQL += "LRPRMANZ, "
            stConsultaSQL += "LRPRPRED, "
            stConsultaSQL += "LRPREDIF, "
            stConsultaSQL += "LRPRUNPR, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "LRPRMAIN, "
            stConsultaSQL += "LRPRNUFI "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRAPRED, MANT_CLASSECT "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "LRPRCLSE = CLSECODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LRPRIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_LIRAPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_LIRAPRED() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRAPRED "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LRPRIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_LIRAPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_LIRAPRED(ByVal inLRPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRAPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRPRIDRE = '" & CInt(inLRPRIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_LIRAPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_LIRAPRED(ByVal inLRPRNURA As Integer, _
                                                 ByVal stLRPRFERA As String, _
                                                 ByVal inLRPRSECU As Integer, _
                                                 ByVal inLRPRMAIN As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRAPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRPRNURA = '" & CInt(inLRPRNURA) & "'AND  "
            stConsultaSQL += "LRPRFERA = '" & CStr(Trim(stLRPRFERA)) & "' AND "
            stConsultaSQL += "LRPRSECU = '" & CInt(inLRPRSECU) & "'AND  "
            stConsultaSQL += "LRPRMAIN = '" & CInt(inLRPRMAIN) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_LIRAPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LIRAPRED(ByVal inLRPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "LRPRIDRE, "
            stConsultaSQL += "LRPRNURA, "
            stConsultaSQL += "LRPRFERA, "
            stConsultaSQL += "LRPRSECU, "
            stConsultaSQL += "LRPRMUNI, "
            stConsultaSQL += "LRPRCORR, "
            stConsultaSQL += "LRPRBARR, "
            stConsultaSQL += "LRPRMANZ, "
            stConsultaSQL += "LRPRPRED, "
            stConsultaSQL += "LRPREDIF, "
            stConsultaSQL += "LRPRUNPR, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "LRPRMAIN, "
            stConsultaSQL += "LRPRNUFI "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRAPRED, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRPRCLSE = CLSECODI AND "
            stConsultaSQL += "LRPRIDRE = '" & CInt(inLRPRIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LRPRIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LIRAPRED")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_LIRAPRED(ByVal inLRPRSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "LRPRIDRE, "
            stConsultaSQL += "LRPRNURA, "
            stConsultaSQL += "LRPRFERA, "
            stConsultaSQL += "LRPRSECU, "
            stConsultaSQL += "LRPRMUNI, "
            stConsultaSQL += "LRPRCORR, "
            stConsultaSQL += "LRPRBARR, "
            stConsultaSQL += "LRPRMANZ, "
            stConsultaSQL += "LRPRPRED, "
            stConsultaSQL += "LRPREDIF, "
            stConsultaSQL += "LRPRUNPR, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "LRPRMAIN, "
            stConsultaSQL += "LRPRNUFI "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRAPRED, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRPRCLSE = CLSECODI AND  "
            stConsultaSQL += "LRPRSECU = '" & CInt(inLRPRSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LRPRIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LIRAPRED")
            Return Nothing

        End Try

    End Function

End Class
