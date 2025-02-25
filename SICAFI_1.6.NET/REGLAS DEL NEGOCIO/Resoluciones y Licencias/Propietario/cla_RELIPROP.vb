Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RELIPROP

    '==================================================
    '*** CLASE RESOLUCIONES Y LICENCIAS PROPIETARIO ***
    '==================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RELIPROP(ByVal inRLPRNURA As Integer, _
                                                         ByVal stRLPRFERA As String, _
                                                         ByVal inRLPRSECU As Integer, _
                                                         ByVal obRLPRNUDO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inRLPRNURA) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(stRLPRFERA) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(inRLPRSECU) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRLPRNUDO.Text) = True Then

                Dim objdatos1 As New cla_RELIPROP
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_RELIPROP(inRLPRNURA, stRLPRFERA, inRLPRSECU, obRLPRNUDO.Text)

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
    Public Function fun_Insertar_RELIPROP(ByVal inRLPRNURA As Integer, _
                                          ByVal stRLPRFERA As String, _
                                          ByVal inRLPRSECU As Integer, _
                                          ByVal stRLPRNUDO As String, _
                                          ByVal stRLPRNOMB As String, _
                                          ByVal stRLPRPRAP As String, _
                                          ByVal stRLPRSEAP As String, _
                                          ByVal stRLPRDERE As String) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RELIPROP "

            stConsultaSQL += "( "
            stConsultaSQL += "RLPRNURA, "
            stConsultaSQL += "RLPRFERA, "
            stConsultaSQL += "RLPRSECU, "
            stConsultaSQL += "RLPRNUDO, "
            stConsultaSQL += "RLPRNOMB, "
            stConsultaSQL += "RLPRPRAP, "
            stConsultaSQL += "RLPRSEAP, "
            stConsultaSQL += "RLPRDERE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRLPRNURA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLPRFERA)) & "', "
            stConsultaSQL += "'" & CInt(inRLPRSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLPRNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLPRNOMB)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLPRPRAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLPRSEAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRLPRDERE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RELIPROP")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RELIPROP(ByVal inRLPRIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RELIPROP "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RELIPROP")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RELIPROP(ByVal inRLPRSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RELIPROP "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RELIPROP")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RELIPROP(ByVal inRLPRIDRE As Integer, _
                                            ByVal inRLPRNURA As Integer, _
                                            ByVal stRLPRFERA As String, _
                                            ByVal inRLPRSECU As Integer, _
                                            ByVal stRLPRNUDO As String, _
                                            ByVal stRLPRNOMB As String, _
                                            ByVal stRLPRPRAP As String, _
                                            ByVal stRLPRSEAP As String, _
                                            ByVal stRLPRDERE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RELIPROP "

            stConsultaSQL += "SET "
            stConsultaSQL += "RLPRNURA = '" & CInt(inRLPRNURA) & "', "
            stConsultaSQL += "RLPRFERA = '" & CStr(Trim(stRLPRFERA)) & "', "
            stConsultaSQL += "RLPRSECU = '" & CInt(inRLPRSECU) & "', "
            stConsultaSQL += "RLPRNUDO = '" & CStr(Trim(stRLPRNUDO)) & "', "
            stConsultaSQL += "RLPRNOMB = '" & CStr(Trim(stRLPRNOMB)) & "', "
            stConsultaSQL += "RLPRPRAP = '" & CStr(Trim(stRLPRPRAP)) & "', "
            stConsultaSQL += "RLPRSEAP = '" & CStr(Trim(stRLPRSEAP)) & "', "
            stConsultaSQL += "RLPRDIPR = '" & CStr(Trim(stRLPRDERE)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RELIPROP")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RELIPROP() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RLPRIDRE, "
            stConsultaSQL += "RLPRNURA, "
            stConsultaSQL += "RLPRFERA, "
            stConsultaSQL += "RLPRSECU, "
            stConsultaSQL += "RLPRNUDO, "
            stConsultaSQL += "RLPRNOMB, "
            stConsultaSQL += "RLPRPRAP, "
            stConsultaSQL += "RLPRSEAP, "
            stConsultaSQL += "RLPRDERE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIPROP "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RLPRIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RELIPROP")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_RELIPROP() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIPROP "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RLPRIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_RELIPROP")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_RELIPROP(ByVal inRLPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLPRIDRE = '" & CInt(inRLPRIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_RELIPROP")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RELIPROP(ByVal inRLPRNURA As Integer, _
                                                 ByVal stRLPRFERA As String, _
                                                 ByVal inRLPRSECU As Integer, _
                                                 ByVal stRLPRNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLPRNURA = '" & CInt(inRLPRNURA) & "'AND  "
            stConsultaSQL += "RLPRFERA = '" & CStr(Trim(stRLPRFERA)) & "' AND "
            stConsultaSQL += "RLPRSECU = '" & CInt(inRLPRSECU) & "'AND  "
            stConsultaSQL += "RLPRNUDO = '" & CStr(Trim(stRLPRNUDO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_RELIPROP")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RELIPROP(ByVal inRLPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RLPRIDRE, "
            stConsultaSQL += "RLPRNURA, "
            stConsultaSQL += "RLPRFERA, "
            stConsultaSQL += "RLPRSECU, "
            stConsultaSQL += "RLPRNUDO, "
            stConsultaSQL += "RLPRNOMB, "
            stConsultaSQL += "RLPRPRAP, "
            stConsultaSQL += "RLPRSEAP, "
            stConsultaSQL += "RLPRDERE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RLPRIDRE = '" & CInt(inRLPRIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RLPRIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RELIPROP")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RELIPROP(ByVal inRLPRSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RLPRIDRE, "
            stConsultaSQL += "RLPRNURA, "
            stConsultaSQL += "RLPRFERA, "
            stConsultaSQL += "RLPRSECU, "
            stConsultaSQL += "RLPRNUDO, "
            stConsultaSQL += "RLPRNOMB, "
            stConsultaSQL += "RLPRPRAP, "
            stConsultaSQL += "RLPRSEAP, "
            stConsultaSQL += "RLPRDERE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RELIPROP "

            stConsultaSQL += "WHERE "
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

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RELIPROP")
            Return Nothing

        End Try

    End Function

End Class
