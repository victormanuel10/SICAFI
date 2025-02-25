Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RELIPRED

    '============================================
    '*** CLASE PREDIO RESOLUCIONES Y LICENCIA ***
    '============================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RELIPRED(ByVal inRLPRNURA As Integer, _
                                                         ByVal stRLPRFERA As String, _
                                                         ByVal inRLPRSECU As Integer, _
                                                         ByVal obRLPRMAIN As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inRLPRNURA) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(stRLPRFERA) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(inRLPRSECU) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRLPRMAIN.Text) = True Then

                Dim objdatos1 As New cla_RELIPRED
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_RELIPRED(inRLPRNURA, stRLPRFERA, inRLPRSECU, obRLPRMAIN.Text)

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
    Public Function fun_Insertar_RELIPRED(ByVal inRLPRNURA As Integer, _
                                          ByVal stRLPRFERA As String, _
                                          ByVal inRLPRSECU As Integer, _
                                          ByVal inRLPRMAIN As Integer, _
                                          ByVal stRLPRMUNI As String, _
                                          ByVal stRLPRCORR As String, _
                                          ByVal stRLPRBARR As String, _
                                          ByVal stRLPRMANZ As String, _
                                          ByVal stRLPRPRED As String, _
                                          ByVal stRLPREDIF As String, _
                                          ByVal stRLPRUNPR As String, _
                                          ByVal inRLPRCLSE As Integer, _
                                          ByVal inRLPRNUFI As Integer) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RELIPRED "

            stConsultaSQL += "( "
            stConsultaSQL += "RLPRNURA, "
            stConsultaSQL += "RLPRFERA, "
            stConsultaSQL += "RLPRSECU, "
            stConsultaSQL += "RLPRMAIN, "
            stConsultaSQL += "RLPRMUNI, "
            stConsultaSQL += "RLPRCORR, "
            stConsultaSQL += "RLPRBARR, "
            stConsultaSQL += "RLPRMANZ, "
            stConsultaSQL += "RLPRPRED, "
            stConsultaSQL += "RLPREDIF, "
            stConsultaSQL += "RLPRUNPR, "
            stConsultaSQL += "RLPRCLSE, "
            stConsultaSQL += "RLPRNUFI "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRLPRNURA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLPRFERA)) & "', "
            stConsultaSQL += "'" & CInt(inRLPRSECU) & "', "
            stConsultaSQL += "'" & CInt(inRLPRMAIN) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLPRMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLPRCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLPRBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLPRMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLPRPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLPREDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLPRUNPR)) & "', "
            stConsultaSQL += "'" & CInt(inRLPRCLSE) & "', "
            stConsultaSQL += "'" & CInt(inRLPRNUFI) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RELIPRED")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RELIPRED(ByVal inRLPRIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RELIPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLPRIDRE = '" & CInt(inRLPRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RELIPRED")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RELIPRED(ByVal inRLPRSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RELIPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLPRSECU = '" & CInt(inRLPRSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RELIPRED")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RELIPRED(ByVal inRLPRIDRE As Integer, _
                                            ByVal inRLPRNURA As Integer, _
                                            ByVal stRLPRFERA As String, _
                                            ByVal inRLPRSECU As Integer, _
                                            ByVal inRLPRMAIN As Integer, _
                                            ByVal stRLPRMUNI As String, _
                                            ByVal stRLPRCORR As String, _
                                            ByVal stRLPRBARR As String, _
                                            ByVal stRLPRMANZ As String, _
                                            ByVal stRLPRPRED As String, _
                                            ByVal stRLPREDIF As String, _
                                            ByVal stRLPRUNPR As String, _
                                            ByVal inRLPRCLSE As Integer, _
                                            ByVal inRLPRNUFI As Integer) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RELIPRED "

            stConsultaSQL += "SET "
            stConsultaSQL += "RLPRNURA = '" & CInt(inRLPRNURA) & "', "
            stConsultaSQL += "RLPRFERA = '" & CStr(Trim(stRLPRFERA)) & "', "
            stConsultaSQL += "RLPRSECU = '" & CInt(inRLPRSECU) & "', "
            stConsultaSQL += "RLPRMAIN = '" & CInt(inRLPRMAIN) & "', "
            stConsultaSQL += "RLPRMUNI = '" & CStr(Trim(stRLPRMUNI)) & "', "
            stConsultaSQL += "RLPRCORR = '" & CStr(Trim(stRLPRCORR)) & "', "
            stConsultaSQL += "RLPRBARR = '" & CStr(Trim(stRLPRBARR)) & "', "
            stConsultaSQL += "RLPRMANZ = '" & CStr(Trim(stRLPRMANZ)) & "', "
            stConsultaSQL += "RLPRPRED = '" & CStr(Trim(stRLPRPRED)) & "', "
            stConsultaSQL += "RLPREDIF = '" & CStr(Trim(stRLPREDIF)) & "', "
            stConsultaSQL += "RLPRUNPR = '" & CStr(Trim(stRLPRUNPR)) & "', "
            stConsultaSQL += "RLPRCLSE = '" & CInt(inRLPRCLSE) & "', "
            stConsultaSQL += "RLPRNUFI = '" & CInt(inRLPRNUFI) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLPRIDRE = '" & CInt(inRLPRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RELIPRED")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RELIPRED() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RLPRIDRE, "
            stConsultaSQL += "RLPRNURA, "
            stConsultaSQL += "RLPRFERA, "
            stConsultaSQL += "RLPRSECU, "
            stConsultaSQL += "RLPRMUNI, "
            stConsultaSQL += "RLPRCORR, "
            stConsultaSQL += "RLPRBARR, "
            stConsultaSQL += "RLPRMANZ, "
            stConsultaSQL += "RLPRPRED, "
            stConsultaSQL += "RLPREDIF, "
            stConsultaSQL += "RLPRUNPR, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "RLPRMAIN, "
            stConsultaSQL += "RLPRNUFI "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIPRED, MANT_CLASSECT "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "RLPRCLSE = CLSECODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RLPRIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RELIPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_RELIPRED() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIPRED "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RLPRIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_RELIPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_RELIPRED(ByVal inRLPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLPRIDRE = '" & CInt(inRLPRIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_RELIPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RELIPRED(ByVal inRLPRNURA As Integer, _
                                                 ByVal stRLPRFERA As String, _
                                                 ByVal inRLPRSECU As Integer, _
                                                 ByVal inRLPRMAIN As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLPRNURA = '" & CInt(inRLPRNURA) & "'AND  "
            stConsultaSQL += "RLPRFERA = '" & CStr(Trim(stRLPRFERA)) & "' AND "
            stConsultaSQL += "RLPRSECU = '" & CInt(inRLPRSECU) & "'AND  "
            stConsultaSQL += "RLPRMAIN = '" & CInt(inRLPRMAIN) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_RELIPRED")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RELIPRED(ByVal inRLPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RLPRIDRE, "
            stConsultaSQL += "RLPRNURA, "
            stConsultaSQL += "RLPRFERA, "
            stConsultaSQL += "RLPRSECU, "
            stConsultaSQL += "RLPRMUNI, "
            stConsultaSQL += "RLPRCORR, "
            stConsultaSQL += "RLPRBARR, "
            stConsultaSQL += "RLPRMANZ, "
            stConsultaSQL += "RLPRPRED, "
            stConsultaSQL += "RLPREDIF, "
            stConsultaSQL += "RLPRUNPR, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "RLPRMAIN, "
            stConsultaSQL += "RLPRNUFI "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIPRED, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLPRCLSE = CLSECODI AND "
            stConsultaSQL += "RLPRIDRE = '" & CInt(inRLPRIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RLPRIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RELIPRED")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RELIPRED(ByVal inRLPRSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RLPRIDRE, "
            stConsultaSQL += "RLPRNURA, "
            stConsultaSQL += "RLPRFERA, "
            stConsultaSQL += "RLPRSECU, "
            stConsultaSQL += "RLPRMUNI, "
            stConsultaSQL += "RLPRCORR, "
            stConsultaSQL += "RLPRBARR, "
            stConsultaSQL += "RLPRMANZ, "
            stConsultaSQL += "RLPRPRED, "
            stConsultaSQL += "RLPREDIF, "
            stConsultaSQL += "RLPRUNPR, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "RLPRMAIN, "
            stConsultaSQL += "RLPRNUFI "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIPRED, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLPRCLSE = CLSECODI AND  "
            stConsultaSQL += "RLPRSECU = '" & CInt(inRLPRSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RLPRIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RELIPRED")
            Return Nothing

        End Try

    End Function

End Class
