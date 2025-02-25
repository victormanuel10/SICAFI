Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RECOPROP

    '=======================================================
    '*** CLASE RESOLUCIONES DE CONSERVACION PROPIETARIOS ***
    '=======================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RECOPROP(ByVal obRCPRNURE As Object, _
                                                         ByVal obRCPRFERE As Object, _
                                                         ByVal obRCPRNUDO As Object, _
                                                         ByVal obRCPRMAIN As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRCPRNURE.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRCPRFERE.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRCPRNUDO.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRCPRMAIN.Text) = True Then

                Dim objdatos1 As New cla_RECOPROP
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_RECOPROP(obRCPRNURE.Text, obRCPRFERE.Text, obRCPRNUDO.Text, obRCPRMAIN.Text)

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
    Public Function fun_Insertar_RECOPROP(ByVal inRCPRSECU As Integer, _
                                          ByVal inRCPRNURE As Integer, _
                                          ByVal stRCPRFERE As String, _
                                          ByVal stRCPRNUDO As String, _
                                          ByVal stRCPRMAIN As String, _
                                          ByVal stRCPRPRAP As String, _
                                          ByVal stRCPRSEAP As String, _
                                          ByVal stRCPRNOMB As String, _
                                          ByVal stRCPRDERE As String, _
                                          ByVal inRCPRESCR As Integer, _
                                          ByVal stRCPRFEES As String, _
                                          ByVal stRCPRESTA As String) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RECOPROP "

            stConsultaSQL += "( "
            stConsultaSQL += "RCPRSECU, "
            stConsultaSQL += "RCPRNURE, "
            stConsultaSQL += "RCPRFERE, "
            stConsultaSQL += "RCPRNUDO, "
            stConsultaSQL += "RCPRMAIN, "
            stConsultaSQL += "RCPRPRAP, "
            stConsultaSQL += "RCPRSEAP, "
            stConsultaSQL += "RCPRNOMB, "
            stConsultaSQL += "RCPRDERE, "
            stConsultaSQL += "RCPRESCR, "
            stConsultaSQL += "RCPRFEES, "
            stConsultaSQL += "RCPRESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRCPRSECU) & "', "
            stConsultaSQL += "'" & CInt(inRCPRNURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRFERE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRMAIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRPRAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRSEAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRNOMB)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRDERE)) & "', "
            stConsultaSQL += "'" & CInt(inRCPRESCR) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPRFEES)) & "', "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RECOPROP")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_CODIGO_RECOPROP(ByVal inRCPRNURE As Integer, _
                                                 ByVal stRCPRFERE As String, _
                                                 ByVal stRCPRNUDO As String, _
                                                 ByVal stRCPRMAIN As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECOPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPRNURE = '" & CInt(inRCPRNURE) & "' AND "
            stConsultaSQL += "RCPRFERE = '" & CStr(Trim(stRCPRFERE)) & "' AND "
            stConsultaSQL += "RCPRNUDO = '" & CStr(Trim(stRCPRNUDO)) & "' AND "
            stConsultaSQL += "RCPRMAIN = '" & CStr(Trim(stRCPRMAIN)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RECOPROP")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RECOPROP(ByVal inRCPRIDRE As Integer, _
                                            ByVal inRCPRSECU As Integer, _
                                            ByVal inRCPRNURE As Integer, _
                                            ByVal stRCPRFERE As String, _
                                            ByVal stRCPRNUDO As String, _
                                            ByVal stRCPRMAIN As String, _
                                            ByVal stRCPRPRAP As String, _
                                            ByVal stRCPRSEAP As String, _
                                            ByVal stRCPRNOMB As String, _
                                            ByVal stRCPRDERE As String, _
                                            ByVal inRCPRESCR As Integer, _
                                            ByVal stRCPRFEES As String, _
                                            ByVal stRCPRESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RECOPROP "

            stConsultaSQL += "SET "
            stConsultaSQL += "RCPRNURE = '" & CInt(inRCPRNURE) & "', "
            stConsultaSQL += "RCPRFERE = '" & CStr(Trim(stRCPRFERE)) & "', "
            stConsultaSQL += "RCPRNUDO = '" & CStr(Trim(stRCPRNUDO)) & "', "
            stConsultaSQL += "RCPRMAIN = '" & CStr(Trim(stRCPRMAIN)) & "', "
            stConsultaSQL += "RCPRPRAP = '" & CStr(Trim(stRCPRPRAP)) & "', "
            stConsultaSQL += "RCPRSEAP = '" & CStr(Trim(stRCPRSEAP)) & "', "
            stConsultaSQL += "RCPRNOMB = '" & CStr(Trim(stRCPRNOMB)) & "', "
            stConsultaSQL += "RCPRDERE = '" & CStr(Trim(stRCPRDERE)) & "', "
            stConsultaSQL += "RCPRESCR = '" & CInt(inRCPRESCR) & "', "
            stConsultaSQL += "RCPRFEES = '" & CStr(Trim(stRCPRFEES)) & "', "
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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RECOPROP")
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECOPROP(ByVal inRCPRNURE As Integer, _
                                                 ByVal stRCPRFERE As String, _
                                                 ByVal stRCPRNUDO As String, _
                                                 ByVal stRCPRMAIN As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPRNURE = '" & CInt(inRCPRNURE) & "' AND "
            stConsultaSQL += "RCPRFERE = '" & CStr(Trim(stRCPRFERE)) & "' AND "
            stConsultaSQL += "RCPRNUDO = '" & CStr(Trim(stRCPRNUDO)) & "' AND "
            stConsultaSQL += "RCPRMAIN = '" & CStr(Trim(stRCPRMAIN)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_RECOPROP")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que consulta los registros
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Consultar_RECOPROP(ByVal inRCPRSECU As Integer) As DataTable

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
            stConsultaSQL += "RCPRMAIN, "
            stConsultaSQL += "RCPRNUDO, "
            stConsultaSQL += "RCPRPRAP, "
            stConsultaSQL += "RCPRSEAP, "
            stConsultaSQL += "RCPRNOMB, "
            stConsultaSQL += "RCPRDERE, "
            stConsultaSQL += "RCPRESCR, "
            stConsultaSQL += "RCPRFEES, "
            stConsultaSQL += "RCPRESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPROP "

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

            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RECOPROP")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RECOPROP(ByVal inRCPRSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RCPRIDRE, "
            stConsultaSQL += "RCPRSECU, "
            stConsultaSQL += "RCPRNURE, "
            stConsultaSQL += "RCPRFERE, "
            stConsultaSQL += "RCPRMAIN, "
            stConsultaSQL += "RCPRNUDO, "
            stConsultaSQL += "RCPRPRAP, "
            stConsultaSQL += "RCPRSEAP, "
            stConsultaSQL += "RCPRNOMB, "
            stConsultaSQL += "RCPRDERE, "
            stConsultaSQL += "RCPRESCR, "
            stConsultaSQL += "RCPRFEES, "
            stConsultaSQL += "RCPRESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPROP "

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

            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RECOPROP")
            Return Nothing

        End Try

    End Function

End Class
