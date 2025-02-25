Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_AREACONS

    '=============================================================
    '*** CLASE GENERAR AREA DE CONSTRUCCION MEDIENTE POLIGONOS ***
    '=============================================================

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_AREACONS(ByVal stARCOPKCO As String, _
                                          ByVal stARCOMUNI As String, _
                                          ByVal stARCOCORR As String, _
                                          ByVal stARCOBARR As String, _
                                          ByVal stARCOMANZ As String, _
                                          ByVal stARCOPRED As String, _
                                          ByVal stARCOEDIF As String, _
                                          ByVal stARCOUNPR As String, _
                                          ByVal stARCOCLSE As String, _
                                          ByVal stARCOTIPO As String, _
                                          ByVal stARCOUSO As String, _
                                          ByVal stARCOARCO As String, _
                                          ByVal stARCOUNID As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "AREACONS "

            stConsultaSQL += "( "
            stConsultaSQL += "ARCOPKCO, "
            stConsultaSQL += "ARCOMUNI, "
            stConsultaSQL += "ARCOCORR, "
            stConsultaSQL += "ARCOBARR, "
            stConsultaSQL += "ARCOMANZ, "
            stConsultaSQL += "ARCOPRED, "
            stConsultaSQL += "ARCOEDIF, "
            stConsultaSQL += "ARCOUNPR, "
            stConsultaSQL += "ARCOCLSE, "
            stConsultaSQL += "ARCOTIPO, "
            stConsultaSQL += "ARCOUSO, "
            stConsultaSQL += "ARCOARCO, "
            stConsultaSQL += "ARCOUNID "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stARCOPKCO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stARCOMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stARCOCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stARCOBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stARCOMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stARCOPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stARCOEDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stARCOUNPR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stARCOCLSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stARCOTIPO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stARCOUSO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stARCOARCO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stARCOUNID)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_AREACONS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_X_ID_AREACONS(ByVal inARCOIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "AREACONS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ARCOIDRE = '" & CInt(inARCOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_AREACONS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_AREACONS() As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "AREACONS "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_AREACONS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_AREACONS(ByVal inARCOIDRE As Integer, _
                                            ByVal stARCOPKCO As String, _
                                            ByVal stARCOMUNI As String, _
                                            ByVal stARCOCORR As String, _
                                            ByVal stARCOBARR As String, _
                                            ByVal stARCOMANZ As String, _
                                            ByVal stARCOPRED As String, _
                                            ByVal stARCOEDIF As String, _
                                            ByVal stARCOUNPR As String, _
                                            ByVal stARCOCLSE As String, _
                                            ByVal stARCOTIPO As String, _
                                            ByVal stARCOUSO As String, _
                                            ByVal stARCOARCO As String, _
                                            ByVal stARCOUNID As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "AREACONS "

            stConsultaSQL += "SET "
            stConsultaSQL += "ARCOPKCO = '" & CStr(Trim(stARCOPKCO)) & "', "
            stConsultaSQL += "ARCOMUNI = '" & CStr(Trim(stARCOMUNI)) & "', "
            stConsultaSQL += "ARCOCORR = '" & CStr(Trim(stARCOCORR)) & "', "
            stConsultaSQL += "ARCOBARR = '" & CStr(Trim(stARCOBARR)) & "', "
            stConsultaSQL += "ARCOMANZ = '" & CStr(Trim(stARCOMANZ)) & "', "
            stConsultaSQL += "ARCOPRED = '" & CStr(Trim(stARCOPRED)) & "', "
            stConsultaSQL += "ARCOEDIF = '" & CStr(Trim(stARCOEDIF)) & "', "
            stConsultaSQL += "ARCOUNPR = '" & CStr(Trim(stARCOUNPR)) & "', "
            stConsultaSQL += "ARCOCLSE = '" & CStr(Trim(stARCOCLSE)) & "', "
            stConsultaSQL += "ARCOTIPO = '" & CStr(Trim(stARCOTIPO)) & "', "
            stConsultaSQL += "ARCOUSO = '" & CStr(Trim(stARCOUSO)) & "', "
            stConsultaSQL += "ARCOARCO = '" & CStr(Trim(stARCOARCO)) & "', "
            stConsultaSQL += "ARCOUNID = '" & CStr(Trim(stARCOUNID)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ARCOIDRE = '" & CInt(inARCOIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_AREACONS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_ARCO_X_ID_AREACONS(ByVal inARCOIDRE As Integer, _
                                                      ByVal stARCOARCO As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "AREACONS "

            stConsultaSQL += "SET "
            stConsultaSQL += "ARCOARCO = '" & CStr(Trim(stARCOARCO)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ARCOIDRE = '" & CInt(inARCOIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_AREACONS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_ARCO_X_PK_AREACONS(ByVal stARCOPKCO As String, _
                                                      ByVal stARCOARCO As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "AREACONS "

            stConsultaSQL += "SET "
            stConsultaSQL += "ARCOARCO = '" & CStr(Trim(stARCOARCO)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ARCOPKCO = '" & CStr(Trim(stARCOPKCO)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_AREACONS")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_AREACONS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ARCOPKCO, "
            stConsultaSQL += "ARCOMUNI, "
            stConsultaSQL += "ARCOCORR, "
            stConsultaSQL += "ARCOBARR, "
            stConsultaSQL += "ARCOMANZ, "
            stConsultaSQL += "ARCOPRED, "
            stConsultaSQL += "ARCOEDIF, "
            stConsultaSQL += "ARCOUNPR, "
            stConsultaSQL += "ARCOCLSE, "
            stConsultaSQL += "ARCOTIPO, "
            stConsultaSQL += "ARCOUSO, "
            stConsultaSQL += "ARCOARCO, "
            stConsultaSQL += "ARCOUNID "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AREACONS "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ARCOPKCO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_AREACONS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_X_PK_AREACONS(ByVal stARCOPKCO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ARCOPKCO, "
            stConsultaSQL += "ARCOMUNI, "
            stConsultaSQL += "ARCOCORR, "
            stConsultaSQL += "ARCOBARR, "
            stConsultaSQL += "ARCOMANZ, "
            stConsultaSQL += "ARCOPRED, "
            stConsultaSQL += "ARCOEDIF, "
            stConsultaSQL += "ARCOUNPR, "
            stConsultaSQL += "ARCOCLSE, "
            stConsultaSQL += "ARCOTIPO, "
            stConsultaSQL += "ARCOUSO, "
            stConsultaSQL += "ARCOARCO, "
            stConsultaSQL += "ARCOUNID "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AREACONS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ARCOPKCO = '" & CStr(Trim(stARCOPKCO)) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ARCOPKCO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_AREACONS")
            Return Nothing
        End Try

    End Function

End Class
