Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RECOPRMO

    '=================================
    '*** CLASE PREDIOS MODIFICADOS ***
    '=================================

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_RECOPRMO(ByVal inRCPMSECU As Integer, _
                                          ByVal inRCPMNURE As Integer, _
                                          ByVal stRCPMFERE As String, _
                                          ByVal inRCPMNUFI As Integer, _
                                          ByVal stRCPMMUNI As String, _
                                          ByVal stRCPMCORR As String, _
                                          ByVal stRCPMBARR As String, _
                                          ByVal stRCPMMANZ As String, _
                                          ByVal stRCPMPRED As String, _
                                          ByVal stRCPMEDIF As String, _
                                          ByVal stRCPMUNPR As String, _
                                          ByVal inRCPMCLSE As Integer, _
                                          ByVal stRCPMDIRE As String, _
                                          ByVal stRCPMMAIN As String, _
                                          ByVal stRCPMESTA As String) As Boolean


        Try
            ' declara la variable
            Dim stRCPMCECA As String = inRCPMCLSE & stRCPMBARR & stRCPMMANZ & stRCPMPRED & stRCPMEDIF & stRCPMUNPR
            Dim stRCPMDEPA As String = "05"

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RECOPRMO "

            stConsultaSQL += "( "
            stConsultaSQL += "RCPMSECU, "
            stConsultaSQL += "RCPMNURE, "
            stConsultaSQL += "RCPMFERE, "
            stConsultaSQL += "RCPMNUFI, "
            stConsultaSQL += "RCPMDEPA, "
            stConsultaSQL += "RCPMMUNI, "
            stConsultaSQL += "RCPMCORR, "
            stConsultaSQL += "RCPMBARR, "
            stConsultaSQL += "RCPMMANZ, "
            stConsultaSQL += "RCPMPRED, "
            stConsultaSQL += "RCPMEDIF, "
            stConsultaSQL += "RCPMUNPR, "
            stConsultaSQL += "RCPMCECA, "
            stConsultaSQL += "RCPMCLSE, "
            stConsultaSQL += "RCPMDIRE, "
            stConsultaSQL += "RCPMMAIN, "
            stConsultaSQL += "RCPMESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRCPMSECU) & "', "
            stConsultaSQL += "'" & CInt(inRCPMNURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPMFERE)) & "', "
            stConsultaSQL += "'" & CInt(inRCPMNUFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPMDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPMMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPMCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPMBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPMMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPMPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPMEDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPMUNPR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPMCECA)) & "', "
            stConsultaSQL += "'" & CInt(inRCPMCLSE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPMDIRE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPMMAIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPMESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RECOPRMO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RECOPRMO(ByVal inRCPMIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECOPRMO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPMIDRE = '" & CInt(inRCPMIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RECOPRMO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RECOPRMO(ByVal inRCPMSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECOPRMO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPMSECU = '" & CInt(inRCPMSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RECOPRMO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RECOPRMO(ByVal inRCPMIDRE As Integer, _
                                            ByVal inRCPMSECU As Integer, _
                                            ByVal inRCPMNURE As Integer, _
                                            ByVal stRCPMFERE As String, _
                                            ByVal inRCPMNUFI As Integer, _
                                            ByVal stRCPMMUNI As String, _
                                            ByVal stRCPMCORR As String, _
                                            ByVal stRCPMBARR As String, _
                                            ByVal stRCPMMANZ As String, _
                                            ByVal stRCPMPRED As String, _
                                            ByVal stRCPMEDIF As String, _
                                            ByVal stRCPMUNPR As String, _
                                            ByVal inRCPMCLSE As Integer, _
                                            ByVal stRCPMDIRE As String, _
                                            ByVal stRCPMMAIN As String, _
                                            ByVal stRCPMESTA As String) As Boolean

        Try
            ' declara la variable
            Dim stRCPMCECA As String = inRCPMCLSE & stRCPMBARR & stRCPMMANZ & stRCPMPRED & stRCPMEDIF & stRCPMUNPR

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RECOPRMO "

            stConsultaSQL += "SET "
            stConsultaSQL += "RCPMSECU = '" & CInt(inRCPMSECU) & "', "
            stConsultaSQL += "RCPMNURE = '" & CInt(inRCPMNURE) & "', "
            stConsultaSQL += "RCPMFERE = '" & CStr(Trim(stRCPMFERE)) & "', "
            stConsultaSQL += "RCPMNUFI = '" & CInt(inRCPMNUFI) & "', "
            stConsultaSQL += "RCPMMUNI = '" & CStr(Trim(stRCPMMUNI)) & "', "
            stConsultaSQL += "RCPMCORR = '" & CStr(Trim(stRCPMCORR)) & "', "
            stConsultaSQL += "RCPMBARR = '" & CStr(Trim(stRCPMBARR)) & "', "
            stConsultaSQL += "RCPMMANZ = '" & CStr(Trim(stRCPMMANZ)) & "', "
            stConsultaSQL += "RCPMPRED = '" & CStr(Trim(stRCPMPRED)) & "', "
            stConsultaSQL += "RCPMCECA = '" & CStr(Trim(stRCPMCECA)) & "', "
            stConsultaSQL += "RCPMEDIF = '" & CStr(Trim(stRCPMEDIF)) & "', "
            stConsultaSQL += "RCPMUNPR = '" & CStr(Trim(stRCPMUNPR)) & "', "
            stConsultaSQL += "RCPMCLSE = '" & CInt(inRCPMCLSE) & "', "
            stConsultaSQL += "RCPMDIRE = '" & CStr(Trim(stRCPMDIRE)) & "', "
            stConsultaSQL += "RCPMMAIN = '" & CStr(Trim(stRCPMMAIN)) & "', "
            stConsultaSQL += "RCPMESTA = '" & CStr(Trim(stRCPMESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPMIDRE = '" & CInt(inRCPMIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RECOPRMO")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RECOPRMO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RCPMIDRE, "
            stConsultaSQL += "RCPMSECU, "
            stConsultaSQL += "RCPMNURE, "
            stConsultaSQL += "RCPMFERE, "
            stConsultaSQL += "RCPMNUFI, "
            stConsultaSQL += "RCPMMUNI, "
            stConsultaSQL += "RCPMCORR, "
            stConsultaSQL += "RCPMBARR, "
            stConsultaSQL += "RCPMMANZ, "
            stConsultaSQL += "RCPMPRED, "
            stConsultaSQL += "RCPMEDIF, "
            stConsultaSQL += "RCPMUNPR, "
            stConsultaSQL += "RCPMCLSE, "
            stConsultaSQL += "RCPMMAIN, "
            stConsultaSQL += "RCPMDIRE, "
            stConsultaSQL += "RCPMESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRMO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RCPMMUNI, RCPMCORR, RCPMBARR, RCPMMANZ, RCPMPRED, RCPMEDIF, RCPMUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECOPRMO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_RECOPRMO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRMO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RCPMMUNI, RCPMCORR, RCPMBARR, RCPMMANZ, RCPMPRED, RCPMEDIF, RCPMUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_RECOPRMO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_RECOPRMO(ByVal inRCPMIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRMO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPMIDRE = '" & CInt(inRCPMIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_RECOPRMO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECOPRMO(ByVal inRCPMSECU As Integer, ByVal inRCPMIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRMO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPMSECU = '" & CInt(inRCPMSECU) & "' AND "
            stConsultaSQL += "RCPMIDRE = '" & CInt(inRCPMIDRE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RECOPRMO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECOPRMO(ByVal inRCPMSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRMO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPMSECU = '" & CInt(inRCPMSECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RECOPRMO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECOPRMO(ByVal inRCPMNURE As Integer, ByVal stRCPMFERE As String, ByVal inRCPMNUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRMO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPMNURE = '" & CInt(inRCPMNURE) & "' AND "
            stConsultaSQL += "RCPMFERE = '" & CStr(Trim(stRCPMFERE)) & "' AND "
            stConsultaSQL += "RCPMNUFI = '" & CInt(inRCPMNUFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RECOPRMO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECOPRMO(ByVal inRCPMIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RCPMIDRE, "
            stConsultaSQL += "RCPMSECU, "
            stConsultaSQL += "RCPMNURE, "
            stConsultaSQL += "RCPMFERE, "
            stConsultaSQL += "RCPMNUFI, "
            stConsultaSQL += "RCPMMUNI, "
            stConsultaSQL += "RCPMCORR, "
            stConsultaSQL += "RCPMBARR, "
            stConsultaSQL += "RCPMMANZ, "
            stConsultaSQL += "RCPMPRED, "
            stConsultaSQL += "RCPMEDIF, "
            stConsultaSQL += "RCPMUNPR, "
            stConsultaSQL += "RCPMCLSE, "
            stConsultaSQL += "RCPMCECA, "
            stConsultaSQL += "RCPMMAIN, "
            stConsultaSQL += "RCPMDIRE, "
            stConsultaSQL += "RCPMESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRMO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPMSECU = '" & CInt(inRCPMIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RCPMMUNI, RCPMCORR, RCPMBARR, RCPMMANZ, RCPMPRED, RCPMEDIF, RCPMUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECOPRMO")
            Return Nothing

        End Try

    End Function

End Class
