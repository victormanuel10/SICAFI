Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_REMUPRED

    '================================================
    '*** CLASE EREGISTRO DE MUTACIONES DE PREDIOS ***
    '================================================

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_REMUPRED(ByVal inRMPRSECU As Integer, _
                                          ByVal stRMPRDEPA As String, _
                                          ByVal stRMPRMUNI As String, _
                                          ByVal stRMPRCORR As String, _
                                          ByVal stRMPRBARR As String, _
                                          ByVal stRMPRMANZ As String, _
                                          ByVal stRMPRPRED As String, _
                                          ByVal stRMPREDIF As String, _
                                          ByVal stRMPRUNPR As String, _
                                          ByVal inRMPRCLSE As Integer, _
                                          ByVal inRMPRVIGE As Integer, _
                                          ByVal stRMPRESCR As String, _
                                          ByVal stRMPRFEES As String, _
                                          ByVal stRMPRNUFI As String, _
                                          ByVal stRMPRMAIN As String) As Boolean


        Try

            ' variables 
            Dim daREMUFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "REMUPRED "

            stConsultaSQL += "( "
            stConsultaSQL += "RMPRSECU, "
            stConsultaSQL += "RMPRDEPA, "
            stConsultaSQL += "RMPRMUNI, "
            stConsultaSQL += "RMPRCORR, "
            stConsultaSQL += "RMPRBARR, "
            stConsultaSQL += "RMPRMANZ, "
            stConsultaSQL += "RMPRPRED, "
            stConsultaSQL += "RMPREDIF, "
            stConsultaSQL += "RMPRUNPR, "
            stConsultaSQL += "RMPRCLSE, "
            stConsultaSQL += "RMPRVIGE, "
            stConsultaSQL += "RMPRESCR, "
            stConsultaSQL += "RMPRFEES, "
            stConsultaSQL += "RMPRNUFI, "
            stConsultaSQL += "RMPRMAIN, "
            stConsultaSQL += "RMPRFEIN "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRMPRSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPREDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRUNPR)) & "', "
            stConsultaSQL += "'" & CInt(inRMPRCLSE) & "', "
            stConsultaSQL += "'" & CInt(inRMPRVIGE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRESCR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRFEES)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRNUFI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRMAIN)) & "', "
            stConsultaSQL += "'" & CDate(daREMUFEIN) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_REGIMUTA")
        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_REMUPRED(ByVal inRMPRSECU As Integer, _
                                          ByVal stRMPRDEPA As String, _
                                          ByVal stRMPRMUNI As String, _
                                          ByVal stRMPRCORR As String, _
                                          ByVal stRMPRBARR As String, _
                                          ByVal stRMPRMANZ As String, _
                                          ByVal stRMPRPRED As String, _
                                          ByVal stRMPREDIF As String, _
                                          ByVal stRMPRUNPR As String, _
                                          ByVal inRMPRCLSE As Integer, _
                                          ByVal inRMPRVIGE As Integer, _
                                          ByVal inRMPRNURE As Integer, _
                                          ByVal stRMPRFERE As String, _
                                          ByVal stRMPRESCR As String, _
                                          ByVal stRMPRFEES As String, _
                                          ByVal stRMPRNUFI As String, _
                                          ByVal stRMPRMAIN As String) As Boolean


        Try

            ' variables 
            Dim daREMUFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "REMUPRED "

            stConsultaSQL += "( "
            stConsultaSQL += "RMPRSECU, "
            stConsultaSQL += "RMPRDEPA, "
            stConsultaSQL += "RMPRMUNI, "
            stConsultaSQL += "RMPRCORR, "
            stConsultaSQL += "RMPRBARR, "
            stConsultaSQL += "RMPRMANZ, "
            stConsultaSQL += "RMPRPRED, "
            stConsultaSQL += "RMPREDIF, "
            stConsultaSQL += "RMPRUNPR, "
            stConsultaSQL += "RMPRCLSE, "
            stConsultaSQL += "RMPRVIGE, "
            stConsultaSQL += "RMPRNURE, "
            stConsultaSQL += "RMPRFERE, "
            stConsultaSQL += "RMPRESCR, "
            stConsultaSQL += "RMPRFEES, "
            stConsultaSQL += "RMPRNUFI, "
            stConsultaSQL += "RMPRMAIN, "
            stConsultaSQL += "RMPRFEIN "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRMPRSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPREDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRUNPR)) & "', "
            stConsultaSQL += "'" & CInt(inRMPRCLSE) & "', "
            stConsultaSQL += "'" & CInt(inRMPRVIGE) & "', "
            stConsultaSQL += "'" & CInt(inRMPRNURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRFERE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRESCR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRFEES)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRNUFI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRMPRMAIN)) & "', "
            stConsultaSQL += "'" & CDate(daREMUFEIN) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_REGIMUTA")
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_REMUPRED(ByVal stRMPRDEPA As String, _
                                                 ByVal stRMPRMUNI As String, _
                                                 ByVal stRMPRCORR As String, _
                                                 ByVal stRMPRBARR As String, _
                                                 ByVal stRMPRMANZ As String, _
                                                 ByVal stRMPRPRED As String, _
                                                 ByVal stRMPREDIF As String, _
                                                 ByVal stRMPRUNPR As String, _
                                                 ByVal stRMPRCLSE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REMUPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RMPRDEPA = '" & CStr(Trim(stRMPRDEPA)) & "' AND "
            stConsultaSQL += "RMPRMUNI = '" & CStr(Trim(stRMPRMUNI)) & "' AND "
            stConsultaSQL += "RMPRCORR = '" & CStr(Trim(stRMPRCORR)) & "' AND "
            stConsultaSQL += "RMPRBARR = '" & CStr(Trim(stRMPRBARR)) & "' AND "
            stConsultaSQL += "RMPRMANZ = '" & CStr(Trim(stRMPRMANZ)) & "' AND "
            stConsultaSQL += "RMPRPRED = '" & CStr(Trim(stRMPRPRED)) & "' AND "
            stConsultaSQL += "RMPREDIF = '" & CStr(Trim(stRMPREDIF)) & "' AND "
            stConsultaSQL += "RMPRUNPR = '" & CStr(Trim(stRMPRUNPR)) & "' AND "
            stConsultaSQL += "RMPRCLSE = '" & CStr(Trim(stRMPRCLSE)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_REGIMUTA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_REMUPRED(ByVal stRMPRDEPA As String, _
                                                 ByVal stRMPRMUNI As String, _
                                                 ByVal stRMPRCORR As String, _
                                                 ByVal stRMPRBARR As String, _
                                                 ByVal stRMPRMANZ As String, _
                                                 ByVal stRMPRPRED As String, _
                                                 ByVal stRMPREDIF As String, _
                                                 ByVal stRMPRUNPR As String, _
                                                 ByVal stRMPRCLSE As String, _
                                                 ByVal stRMPRSECU As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REMUPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RMPRDEPA = '" & CStr(Trim(stRMPRDEPA)) & "' AND "
            stConsultaSQL += "RMPRMUNI = '" & CStr(Trim(stRMPRMUNI)) & "' AND "
            stConsultaSQL += "RMPRCORR = '" & CStr(Trim(stRMPRCORR)) & "' AND "
            stConsultaSQL += "RMPRBARR = '" & CStr(Trim(stRMPRBARR)) & "' AND "
            stConsultaSQL += "RMPRMANZ = '" & CStr(Trim(stRMPRMANZ)) & "' AND "
            stConsultaSQL += "RMPRPRED = '" & CStr(Trim(stRMPRPRED)) & "' AND "
            stConsultaSQL += "RMPREDIF = '" & CStr(Trim(stRMPREDIF)) & "' AND "
            stConsultaSQL += "RMPRUNPR = '" & CStr(Trim(stRMPRUNPR)) & "' AND "
            stConsultaSQL += "RMPRCLSE = '" & CStr(Trim(stRMPRCLSE)) & "' AND "
            stConsultaSQL += "RMPRSECU = '" & CInt(stRMPRSECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_REGIMUTA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_REMUPRED(ByVal stRMPRDEPA As String, _
                                                 ByVal stRMPRMUNI As String, _
                                                 ByVal stRMPRCORR As String, _
                                                 ByVal stRMPRBARR As String, _
                                                 ByVal stRMPRMANZ As String, _
                                                 ByVal stRMPRPRED As String, _
                                                 ByVal stRMPREDIF As String, _
                                                 ByVal stRMPRUNPR As String, _
                                                 ByVal stRMPRCLSE As String, _
                                                 ByVal stRMPRVIGE As String, _
                                                 ByVal stRMPRESCR As String, _
                                                 ByVal stRMPRFEES As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REMUPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RMPRDEPA = '" & CStr(Trim(stRMPRDEPA)) & "' AND "
            stConsultaSQL += "RMPRMUNI = '" & CStr(Trim(stRMPRMUNI)) & "' AND "
            stConsultaSQL += "RMPRCORR = '" & CStr(Trim(stRMPRCORR)) & "' AND "
            stConsultaSQL += "RMPRBARR = '" & CStr(Trim(stRMPRBARR)) & "' AND "
            stConsultaSQL += "RMPRMANZ = '" & CStr(Trim(stRMPRMANZ)) & "' AND "
            stConsultaSQL += "RMPRPRED = '" & CStr(Trim(stRMPRPRED)) & "' AND "
            stConsultaSQL += "RMPREDIF = '" & CStr(Trim(stRMPREDIF)) & "' AND "
            stConsultaSQL += "RMPRUNPR = '" & CStr(Trim(stRMPRUNPR)) & "' AND "
            stConsultaSQL += "RMPRCLSE = '" & CStr(Trim(stRMPRCLSE)) & "' AND "
            stConsultaSQL += "RMPRVIGE = '" & CStr(Trim(stRMPRVIGE)) & "' AND "
            stConsultaSQL += "RMPRESCR = '" & CStr(Trim(stRMPRESCR)) & "' AND "
            stConsultaSQL += "RMPRFEES = '" & CStr(Trim(stRMPRFEES)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_REGIMUTA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_SECUENCIA_REMUPRED(ByVal inRMPRSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REMUPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RMPRSECU = '" & CInt(inRMPRSECU) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RMPRCLSE, RMPRMUNI, RMPRCORR, RMPRBARR, RMPRMANZ, RMPRPRED, RMPREDIF, RMPRUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_REGIMUTA")
            Return Nothing
        End Try

    End Function

End Class
