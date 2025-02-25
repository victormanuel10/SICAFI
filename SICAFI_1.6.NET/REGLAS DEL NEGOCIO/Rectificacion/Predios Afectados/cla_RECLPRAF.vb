Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RECLPRAF

    '========================================
    '*** CLASE PREDIOS AFECTADOS RECLAMOS ***
    '========================================

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_RECLPRAF(ByVal inREPASECU As Integer, _
                                            ByVal stREPAMUNI As String, _
                                            ByVal stREPACORR As String, _
                                            ByVal stREPABARR As String, _
                                            ByVal stREPAMANZ As String, _
                                            ByVal stREPAPRED As String, _
                                            ByVal stREPAEDIF As String, _
                                            ByVal stREPAUNPR As String) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RECLPRAF "

            stConsultaSQL += "( "
            stConsultaSQL += "REPASECU, "
            stConsultaSQL += "REPAMUNI, "
            stConsultaSQL += "REPACORR, "
            stConsultaSQL += "REPABARR, "
            stConsultaSQL += "REPAMANZ, "
            stConsultaSQL += "REPAPRED, "
            stConsultaSQL += "REPAEDIF, "
            stConsultaSQL += "REPAUNPR "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inREPASECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREPAMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREPACORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREPABARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREPAMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREPAPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREPAEDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREPAUNPR)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RECLPRAF")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RECLPRAF(ByVal inREPAIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLPRAF "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REPAIDRE = '" & CInt(inREPAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RECLPRAF")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RECLPRAF(ByVal inREPASECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLPRAF "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REPASECU = '" & CInt(inREPASECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RECLPRAF")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RECLPRAF(ByVal inREPAIDRE As Integer, _
                                            ByVal inREPASECU As Integer, _
                                            ByVal stREPAMUNI As String, _
                                            ByVal stREPACORR As String, _
                                            ByVal stREPABARR As String, _
                                            ByVal stREPAMANZ As String, _
                                            ByVal stREPAPRED As String, _
                                            ByVal stREPAEDIF As String, _
                                            ByVal stREPAUNPR As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RECLPRAF "

            stConsultaSQL += "SET "
            stConsultaSQL += "REPASECU = '" & CInt(inREPASECU) & "', "
            stConsultaSQL += "REPAMUNI = '" & CStr(Trim(stREPAMUNI)) & "', "
            stConsultaSQL += "REPACORR = '" & CStr(Trim(stREPACORR)) & "', "
            stConsultaSQL += "REPABARR = '" & CStr(Trim(stREPABARR)) & "', "
            stConsultaSQL += "REPAMANZ = '" & CStr(Trim(stREPAMANZ)) & "', "
            stConsultaSQL += "REPAPRED = '" & CStr(Trim(stREPAPRED)) & "', "
            stConsultaSQL += "REPAEDIF = '" & CStr(Trim(stREPAEDIF)) & "', "
            stConsultaSQL += "REPAUNPR = '" & CStr(Trim(stREPAUNPR)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REPAIDRE = '" & CInt(inREPAIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RECLPRAF")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RECLPRAF() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REPAIDRE, "
            stConsultaSQL += "REPASECU, "
            stConsultaSQL += "REPAMUNI, "
            stConsultaSQL += "REPACORR, "
            stConsultaSQL += "REPABARR, "
            stConsultaSQL += "REPAMANZ, "
            stConsultaSQL += "REPAPRED, "
            stConsultaSQL += "REPAEDIF, "
            stConsultaSQL += "REPAUNPR "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLPRAF "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REPAMUNI, REPACORR, REPABARR, REPAMANZ, REPAPRED, REPAEDIF, REPAUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLPRAF")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_RECLPRAF() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLPRAF "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REPAMUNI, REPACORR, REPABARR, REPAMANZ, REPAPRED, REPAEDIF, REPAUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_RECLPRAF")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_RECLPRAF(ByVal inREPAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLPRAF "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REPAIDRE = '" & CInt(inREPAIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_RECLPRAF")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECLPRAF(ByVal inREPASECU As Integer, ByVal inREPAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLPRAF "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REPASECU = '" & CInt(inREPASECU) & "' and "
            stConsultaSQL += "REPAIDRE = '" & CInt(inREPAIDRE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RECLPRAF")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLPRAF(ByVal inREPAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REPAIDRE, "
            stConsultaSQL += "REPASECU, "
            stConsultaSQL += "REPAMUNI, "
            stConsultaSQL += "REPACORR, "
            stConsultaSQL += "REPABARR, "
            stConsultaSQL += "REPAMANZ, "
            stConsultaSQL += "REPAPRED, "
            stConsultaSQL += "REPAEDIF, "
            stConsultaSQL += "REPAUNPR "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLPRAF "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REPASECU = '" & CInt(inREPAIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REPAMUNI, REPACORR, REPABARR, REPAMANZ, REPAPRED, REPAEDIF, REPAUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLPRAF")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia maxima
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_RECLPRAF() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REPASECU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLPRAF "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_MAXINA_X_RECLPRAF")
            Return Nothing
        End Try

    End Function


End Class
