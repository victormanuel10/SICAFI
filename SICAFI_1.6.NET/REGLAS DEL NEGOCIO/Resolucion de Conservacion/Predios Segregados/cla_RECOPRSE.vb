Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RECOPRSE

    '================================
    '*** CLASE PREDIOS SEGREGADOS ***
    '================================

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_RECOPRSE(ByVal inRCPSSECU As Integer, _
                                          ByVal inRCPSNURE As Integer, _
                                          ByVal stRCPSFERE As String, _
                                          ByVal inRCPSNUFI As Integer, _
                                          ByVal stRCPSMUNI As String, _
                                          ByVal stRCPSCORR As String, _
                                          ByVal stRCPSBARR As String, _
                                          ByVal stRCPSMANZ As String, _
                                          ByVal stRCPSPRED As String, _
                                          ByVal stRCPSEDIF As String, _
                                          ByVal stRCPSUNPR As String, _
                                          ByVal inRCPSCLSE As Integer, _
                                          ByVal stRCPSDIRE As String, _
                                          ByVal stRCPSMAIN As String, _
                                          ByVal stRCPSESTA As String) As Boolean


        Try
            ' declara la variable
            Dim stRCPSCECA As String = inRCPSCLSE & stRCPSBARR & stRCPSMANZ & stRCPSPRED & stRCPSEDIF & stRCPSUNPR
            Dim stRCPSDEPA As String = "05"

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RECOPRSE "

            stConsultaSQL += "( "
            stConsultaSQL += "RCPSSECU, "
            stConsultaSQL += "RCPSNURE, "
            stConsultaSQL += "RCPSFERE, "
            stConsultaSQL += "RCPSNUFI, "
            stConsultaSQL += "RCPSDEPA, "
            stConsultaSQL += "RCPSMUNI, "
            stConsultaSQL += "RCPSCORR, "
            stConsultaSQL += "RCPSBARR, "
            stConsultaSQL += "RCPSMANZ, "
            stConsultaSQL += "RCPSPRED, "
            stConsultaSQL += "RCPSEDIF, "
            stConsultaSQL += "RCPSUNPR, "
            stConsultaSQL += "RCPSCECA, "
            stConsultaSQL += "RCPSCLSE, "
            stConsultaSQL += "RCPSDIRE, "
            stConsultaSQL += "RCPSMAIN, "
            stConsultaSQL += "RCPSESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRCPSSECU) & "', "
            stConsultaSQL += "'" & CInt(inRCPSNURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPSFERE)) & "', "
            stConsultaSQL += "'" & CInt(inRCPSNUFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPSDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPSMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPSCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPSBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPSMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPSPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPSEDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPSUNPR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPSCECA)) & "', "
            stConsultaSQL += "'" & CInt(inRCPSCLSE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPSDIRE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPSMAIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRCPSESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RECOPRSE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RECOPRSE(ByVal inRCPSIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECOPRSE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPSIDRE = '" & CInt(inRCPSIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RECOPRSE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RECOPRSE(ByVal inRCPSSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECOPRSE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPSSECU = '" & CInt(inRCPSSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RECOPRSE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RECOPRSE(ByVal inRCPSIDRE As Integer, _
                                            ByVal inRCPSSECU As Integer, _
                                            ByVal inRCPSNURE As Integer, _
                                            ByVal stRCPSFERE As String, _
                                            ByVal inRCPSNUFI As Integer, _
                                            ByVal stRCPSMUNI As String, _
                                            ByVal stRCPSCORR As String, _
                                            ByVal stRCPSBARR As String, _
                                            ByVal stRCPSMANZ As String, _
                                            ByVal stRCPSPRED As String, _
                                            ByVal stRCPSEDIF As String, _
                                            ByVal stRCPSUNPR As String, _
                                            ByVal inRCPSCLSE As Integer, _
                                            ByVal stRCPSDIRE As String, _
                                            ByVal stRCPSMAIN As String, _
                                            ByVal stRCPSESTA As String) As Boolean

        Try
            ' declara la variable
            Dim stRCPSCECA As String = inRCPSCLSE & stRCPSBARR & stRCPSMANZ & stRCPSPRED & stRCPSEDIF & stRCPSUNPR

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RECOPRSE "

            stConsultaSQL += "SET "
            stConsultaSQL += "RCPSSECU = '" & CInt(inRCPSSECU) & "', "
            stConsultaSQL += "RCPSNURE = '" & CInt(inRCPSNURE) & "', "
            stConsultaSQL += "RCPSFERE = '" & CStr(Trim(stRCPSFERE)) & "', "
            stConsultaSQL += "RCPSNUFI = '" & CInt(inRCPSNUFI) & "', "
            stConsultaSQL += "RCPSMUNI = '" & CStr(Trim(stRCPSMUNI)) & "', "
            stConsultaSQL += "RCPSCORR = '" & CStr(Trim(stRCPSCORR)) & "', "
            stConsultaSQL += "RCPSBARR = '" & CStr(Trim(stRCPSBARR)) & "', "
            stConsultaSQL += "RCPSMANZ = '" & CStr(Trim(stRCPSMANZ)) & "', "
            stConsultaSQL += "RCPSPRED = '" & CStr(Trim(stRCPSPRED)) & "', "
            stConsultaSQL += "RCPSCECA = '" & CStr(Trim(stRCPSCECA)) & "', "
            stConsultaSQL += "RCPSEDIF = '" & CStr(Trim(stRCPSEDIF)) & "', "
            stConsultaSQL += "RCPSUNPR = '" & CStr(Trim(stRCPSUNPR)) & "', "
            stConsultaSQL += "RCPSCLSE = '" & CInt(inRCPSCLSE) & "', "
            stConsultaSQL += "RCPSDIRE = '" & CStr(Trim(stRCPSDIRE)) & "', "
            stConsultaSQL += "RCPSMAIN = '" & CStr(Trim(stRCPSMAIN)) & "', "
            stConsultaSQL += "RCPSESTA = '" & CStr(Trim(stRCPSESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPSIDRE = '" & CInt(inRCPSIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RECOPRSE")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RECOPRSE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RCPSIDRE, "
            stConsultaSQL += "RCPSSECU, "
            stConsultaSQL += "RCPSNURE, "
            stConsultaSQL += "RCPSFERE, "
            stConsultaSQL += "RCPSNUFI, "
            stConsultaSQL += "RCPSMUNI, "
            stConsultaSQL += "RCPSCORR, "
            stConsultaSQL += "RCPSBARR, "
            stConsultaSQL += "RCPSMANZ, "
            stConsultaSQL += "RCPSPRED, "
            stConsultaSQL += "RCPSEDIF, "
            stConsultaSQL += "RCPSUNPR, "
            stConsultaSQL += "RCPSCLSE, "
            stConsultaSQL += "RCPSMAIN, "
            stConsultaSQL += "RCPSDIRE, "
            stConsultaSQL += "RCPSESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRSE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RCPSMUNI, RCPSCORR, RCPSBARR, RCPSMANZ, RCPSPRED, RCPSEDIF, RCPSUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECOPRSE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_RECOPRSE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRSE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RCPSMUNI, RCPSCORR, RCPSBARR, RCPSMANZ, RCPSPRED, RCPSEDIF, RCPSUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_RECOPRSE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_RECOPRSE(ByVal inRCPSIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRSE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPSIDRE = '" & CInt(inRCPSIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_RECOPRSE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECOPRSE(ByVal inRCPSSECU As Integer, ByVal inRCPSIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRSE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPSSECU = '" & CInt(inRCPSSECU) & "' AND "
            stConsultaSQL += "RCPSIDRE = '" & CInt(inRCPSIDRE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RECOPRSE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECOPRSE(ByVal inRCPSSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRSE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPSSECU = '" & CInt(inRCPSSECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RECOPRSE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECOPRSE(ByVal inRCPSNURE As Integer, ByVal stRCPSFERE As String, ByVal inRCPSNUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRSE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPSNURE = '" & CInt(inRCPSNURE) & "' AND "
            stConsultaSQL += "RCPSFERE = '" & CStr(Trim(stRCPSFERE)) & "' AND "
            stConsultaSQL += "RCPSNUFI = '" & CInt(inRCPSNUFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RECOPRSE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECOPRSE(ByVal inRCPSIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RCPSIDRE, "
            stConsultaSQL += "RCPSSECU, "
            stConsultaSQL += "RCPSNURE, "
            stConsultaSQL += "RCPSFERE, "
            stConsultaSQL += "RCPSNUFI, "
            stConsultaSQL += "RCPSMUNI, "
            stConsultaSQL += "RCPSCORR, "
            stConsultaSQL += "RCPSBARR, "
            stConsultaSQL += "RCPSMANZ, "
            stConsultaSQL += "RCPSPRED, "
            stConsultaSQL += "RCPSEDIF, "
            stConsultaSQL += "RCPSUNPR, "
            stConsultaSQL += "RCPSCLSE, "
            stConsultaSQL += "RCPSCECA, "
            stConsultaSQL += "RCPSMAIN, "
            stConsultaSQL += "RCPSDIRE, "
            stConsultaSQL += "RCPSESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECOPRSE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RCPSSECU = '" & CInt(inRCPSIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RCPSMUNI, RCPSCORR, RCPSBARR, RCPSMANZ, RCPSPRED, RCPSEDIF, RCPSUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECOPRSE")
            Return Nothing

        End Try

    End Function

End Class
