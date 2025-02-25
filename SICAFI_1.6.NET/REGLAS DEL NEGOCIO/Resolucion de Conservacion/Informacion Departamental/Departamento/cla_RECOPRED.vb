Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RECOPRED

    '==================================================
    '*** CLASE RESOLUCIONES DE CONSERVACION PREDIOS ***
    '==================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RECOPRED(ByVal obRCPRNURE As Object, _
                                                         ByVal obRCPRFERE As Object, _
                                                         ByVal obRCPRNUFI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRCPRNURE.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRCPRFERE.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRCPRNUFI.Text) = True Then

                Dim objdatos1 As New cla_RECOPRED
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_RECOPRED(obRCPRNURE.Text, obRCPRFERE.Text, obRCPRNUFI.Text)

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
    Public Function fun_Insertar_RECOPRED(ByVal inRCPRSECU As Integer, _
                                          ByVal inRCPRNURE As Integer, _
                                          ByVal stRCPRFERE As String, _
                                          ByVal inRCPRNUFI As Integer, _
                                          ByVal stRCPRDEPA As String, _
                                          ByVal stRCPRMUNI As String, _
                                          ByVal stRCPRCORR As String, _
                                          ByVal stRCPRBARR As String, _
                                          ByVal stRCPRMANZ As String, _
                                          ByVal stRCPRPRED As String, _
                                          ByVal stRCPREDIF As String, _
                                          ByVal stRCPRUNPR As String, _
                                          ByVal stRCPRCECA As String, _
                                          ByVal inRCPRCLSE As Integer, _
                                          ByVal stRCPRDIRE As String, _
                                          ByVal stRCPRFEIN As String, _
                                          ByVal stRCPRNUPN As String, _
                                          ByVal stRCPRTITR As String, _
                                          ByVal stRCPRESTA As String) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RECOPRED "

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
            stConsultaSQL += "RCPRFEIN, "
            stConsultaSQL += "RCPRNUPN, "
            stConsultaSQL += "RCPRTITR, "
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
            stConsultaSQL += "'" & CStr(Trim(stRCPRFEIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRNUPN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRTITR)) & "', "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RECOPRED")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_CODIGO_RECOPRED(ByVal inRCPRNURE As Integer, _
                                                 ByVal stRCPRFERE As String, _
                                                 ByVal inRCPRNUFI As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECOPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPRNURE = '" & CInt(inRCPRNURE) & "' AND "
            stConsultaSQL += "RCPRFERE = '" & CStr(Trim(stRCPRFERE)) & "' AND "
            stConsultaSQL += "RCPRNUFI = '" & CInt(inRCPRNUFI) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RECOPRED")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RECOPRED(ByVal inRCPRIDRE As Integer, _
                                            ByVal inRCPRNURE As Integer, _
                                            ByVal stRCPRFERE As String, _
                                            ByVal inRCPRNUFI As Integer, _
                                            ByVal stRCPRDEPA As String, _
                                            ByVal stRCPRMUNI As String, _
                                            ByVal stRCPRCORR As String, _
                                            ByVal stRCPRBARR As String, _
                                            ByVal stRCPRMANZ As String, _
                                            ByVal stRCPRPRED As String, _
                                            ByVal stRCPREDIF As String, _
                                            ByVal stRCPRUNPR As String, _
                                            ByVal stRCPRCECA As String, _
                                            ByVal inRCPRCLSE As Integer, _
                                            ByVal stRCPRDIRE As String, _
                                            ByVal stRCPRFEIN As String, _
                                            ByVal stRCPRNUPN As String, _
                                            ByVal stRCPRTITR As String, _
                                            ByVal stRCPRESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RECOPRED "

            stConsultaSQL += "SET "
            stConsultaSQL += "RCPRNURE = '" & CInt(inRCPRNURE) & "', "
            stConsultaSQL += "RCPRFERE = '" & CStr(Trim(stRCPRFERE)) & "', "
            stConsultaSQL += "RCPRNUFI = '" & CInt(inRCPRNUFI) & "', "
            stConsultaSQL += "RCPRDEPA = '" & CStr(Trim(stRCPRDEPA)) & "', "
            stConsultaSQL += "RCPRMUNI = '" & CStr(Trim(stRCPRMUNI)) & "', "
            stConsultaSQL += "RCPRCORR = '" & CStr(Trim(stRCPRCORR)) & "', "
            stConsultaSQL += "RCPRBARR = '" & CStr(Trim(stRCPRBARR)) & "', "
            stConsultaSQL += "RCPRMANZ = '" & CStr(Trim(stRCPRMANZ)) & "', "
            stConsultaSQL += "RCPRPRED = '" & CStr(Trim(stRCPRPRED)) & "', "
            stConsultaSQL += "RCPRUNPR = '" & CStr(Trim(stRCPRUNPR)) & "', "
            stConsultaSQL += "RCPRCECA = '" & CStr(Trim(stRCPRCECA)) & "', "
            stConsultaSQL += "RCPRCLSE = '" & CInt(inRCPRCLSE) & "', "
            stConsultaSQL += "RCPRDIRE = '" & CStr(Trim(stRCPRDIRE)) & "', "
            stConsultaSQL += "RCPRFEIN = '" & CStr(Trim(stRCPRFEIN)) & "', "
            stConsultaSQL += "RCPRNUPN = '" & CStr(Trim(stRCPRNUPN)) & "', "
            stConsultaSQL += "RCPRTITR = '" & CStr(Trim(stRCPRTITR)) & "', "
            stConsultaSQL += "RCPRESTA = '" & CStr(Trim(stRCPRESTA)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RECOPRED")
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECOPRED(ByVal inRCPRNURE As Integer, _
                                                 ByVal stRCPRFERE As String, _
                                                 ByVal inRCPRNUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRED "

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
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_RECOPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RECOPRED(ByVal inRCPRSECU As Integer) As DataTable

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
            stConsultaSQL += "RCPRFEIN, "
            stConsultaSQL += "RCPRNUPN, "
            stConsultaSQL += "RCPRTITR, "
            stConsultaSQL += "RCPRESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPRSECU = '" & CInt(inRCPRSECU) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RCPRSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RECOPRED")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Consulta los registros
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Consultar_RECOPRED(ByVal inRCPRSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 10 "
            stConsultaSQL += "RCPRIDRE, "
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
            stConsultaSQL += "RCPRFEIN, "
            stConsultaSQL += "RCPRNUPN, "
            stConsultaSQL += "RCPRTITR, "
            stConsultaSQL += "RCPRESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPRSECU = '" & CInt(inRCPRSECU) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RCPRSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RECOPRED")
            Return Nothing

        End Try

    End Function
End Class
