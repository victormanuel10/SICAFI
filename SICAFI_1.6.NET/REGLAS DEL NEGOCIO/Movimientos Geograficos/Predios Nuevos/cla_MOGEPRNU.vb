Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MOGEPRNU

    '============================
    '*** CLASE PREDIOS NUEVOS ***
    '============================

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MOGEPRNU(ByVal inMGPNSECU As Integer, _
                                          ByVal stMGPNMUNI As String, _
                                          ByVal stMGPNCORR As String, _
                                          ByVal stMGPNBARR As String, _
                                          ByVal stMGPNMANZ As String, _
                                          ByVal stMGPNPRED As String, _
                                          ByVal stMGPNEDIF As String, _
                                          ByVal stMGPNUNPR As String, _
                                          ByVal inMGPNCLSE As Integer, _
                                          ByVal stMGPNCAAC As String, _
                                          ByVal inMGPNNUFI As Integer, _
                                          ByVal inMGPNNUOV As Integer) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MOGEPRNU "

            stConsultaSQL += "( "
            stConsultaSQL += "MGPNSECU, "
            stConsultaSQL += "MGPNMUNI, "
            stConsultaSQL += "MGPNCORR, "
            stConsultaSQL += "MGPNBARR, "
            stConsultaSQL += "MGPNMANZ, "
            stConsultaSQL += "MGPNPRED, "
            stConsultaSQL += "MGPNEDIF, "
            stConsultaSQL += "MGPNUNPR, "
            stConsultaSQL += "MGPNCLSE, "
            stConsultaSQL += "MGPNCAAC, "
            stConsultaSQL += "MGPNNUFI, "
            stConsultaSQL += "MGPNNUOV "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMGPNSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMGPNMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMGPNCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMGPNBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMGPNMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMGPNPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMGPNEDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMGPNUNPR)) & "', "
            stConsultaSQL += "'" & CInt(inMGPNCLSE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMGPNCAAC)) & "', "
            stConsultaSQL += "'" & CInt(inMGPNNUFI) & "', "
            stConsultaSQL += "'" & CInt(inMGPNNUOV) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MOGEPRNU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MOGEPRNU(ByVal inMGPNIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MOGEPRNU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGPNIDRE = '" & CInt(inMGPNIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MOGEPRNU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MOGEPRNU(ByVal inMGPNSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MOGEPRNU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGPNSECU = '" & CInt(inMGPNSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MOGEPRNU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MOGEPRNU(ByVal inMGPNIDRE As Integer, _
                                            ByVal inMGPNSECU As Integer, _
                                            ByVal stMGPNMUNI As String, _
                                            ByVal stMGPNCORR As String, _
                                            ByVal stMGPNBARR As String, _
                                            ByVal stMGPNMANZ As String, _
                                            ByVal stMGPNPRED As String, _
                                            ByVal stMGPNEDIF As String, _
                                            ByVal stMGPNUNPR As String, _
                                            ByVal inMGPNCLSE As Integer, _
                                            ByVal stMGPNCAAC As String, _
                                            ByVal inMGPNNUFI As Integer, _
                                            ByVal inMGPNNUOV As Integer) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MOGEPRNU "

            stConsultaSQL += "SET "
            stConsultaSQL += "MGPNSECU = '" & CInt(inMGPNSECU) & "', "
            stConsultaSQL += "MGPNMUNI = '" & CStr(Trim(stMGPNMUNI)) & "', "
            stConsultaSQL += "MGPNCORR = '" & CStr(Trim(stMGPNCORR)) & "', "
            stConsultaSQL += "MGPNBARR = '" & CStr(Trim(stMGPNBARR)) & "', "
            stConsultaSQL += "MGPNMANZ = '" & CStr(Trim(stMGPNMANZ)) & "', "
            stConsultaSQL += "MGPNPRED = '" & CStr(Trim(stMGPNPRED)) & "', "
            stConsultaSQL += "MGPNEDIF = '" & CStr(Trim(stMGPNEDIF)) & "', "
            stConsultaSQL += "MGPNUNPR = '" & CStr(Trim(stMGPNUNPR)) & "', "
            stConsultaSQL += "MGPNCLSE = '" & CInt(inMGPNCLSE) & "', "
            stConsultaSQL += "MGPNCAAC = '" & CStr(Trim(stMGPNCAAC)) & "', "
            stConsultaSQL += "MGPNNUFI = '" & CInt(inMGPNNUFI) & "', "
            stConsultaSQL += "MGPNNUOV = '" & CInt(inMGPNNUOV) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGPNIDRE = '" & CInt(inMGPNIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MOGEPRNU")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MOGEPRNU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MGPNIDRE, "
            stConsultaSQL += "MGPNSECU, "
            stConsultaSQL += "MGPNMUNI, "
            stConsultaSQL += "MGPNCORR, "
            stConsultaSQL += "MGPNBARR, "
            stConsultaSQL += "MGPNMANZ, "
            stConsultaSQL += "MGPNPRED, "
            stConsultaSQL += "MGPNEDIF, "
            stConsultaSQL += "MGPNUNPR, "
            stConsultaSQL += "MGPNCLSE, "
            stConsultaSQL += "MGPNCAAC, "
            stConsultaSQL += "CAACDESC, "
            stConsultaSQL += "MGPNNUFI, "
            stConsultaSQL += "MGPNNUOV "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOGEPRNU, MANT_CAUSACTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGPNCAAC = CAACCODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MGPNMUNI, MGPNCORR, MGPNBARR, MGPNMANZ, MGPNPRED, MGPNEDIF, MGPNUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MOGEPRNU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MOGEPRNU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOGEPRNU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MGPNMUNI, MGPNCORR, MGPNBARR, MGPNMANZ, MGPNPRED, MGPNEDIF, MGPNUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MOGEPRNU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MOGEPRNU(ByVal inMGPNIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOGEPRNU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGPNIDRE = '" & CInt(inMGPNIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MOGEPRNU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MOGEPRNU(ByVal inMGPNSECU As Integer, ByVal inMGPNIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOGEPRNU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGPNSECU = '" & CInt(inMGPNSECU) & "' AND "
            stConsultaSQL += "MGPNIDRE = '" & CInt(inMGPNIDRE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MOGEPRNU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MOGEPRNU(ByVal inMGPNSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOGEPRNU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGPNSECU = '" & CInt(inMGPNSECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MOGEPRNU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MOGEPRNU(ByVal inMGPNSECU As Integer, ByVal stMGPNNUDO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOGEPRNU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGPNSECU = '" & CInt(inMGPNSECU) & "' and "
            stConsultaSQL += "MGPNNUDO = '" & CStr(Trim(stMGPNNUDO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MOGEPRNU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEPRNU(ByVal inMGPNIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MGPNIDRE, "
            stConsultaSQL += "MGPNSECU, "
            stConsultaSQL += "MGPNMUNI, "
            stConsultaSQL += "MGPNCORR, "
            stConsultaSQL += "MGPNBARR, "
            stConsultaSQL += "MGPNMANZ, "
            stConsultaSQL += "MGPNPRED, "
            stConsultaSQL += "MGPNEDIF, "
            stConsultaSQL += "MGPNUNPR, "
            stConsultaSQL += "MGPNCLSE, "
            stConsultaSQL += "MGPNCAAC, "
            stConsultaSQL += "CAACDESC, "
            stConsultaSQL += "MGPNNUFI, "
            stConsultaSQL += "MGPNNUOV "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOGEPRNU, MANT_CAUSACTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGPNSECU = '" & CInt(inMGPNIDRE) & "' AND "
            stConsultaSQL += "MGPNCAAC = CAACCODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MGPNMUNI, MGPNCORR, MGPNBARR, MGPNMANZ, MGPNPRED, MGPNEDIF, MGPNUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEPRNU")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia maxima
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_MOGEPRNU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MGPNSECU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOGEPRNU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_MAXINA_X_MOGEPRNU")
            Return Nothing
        End Try

    End Function

End Class
