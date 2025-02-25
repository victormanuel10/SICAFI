Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MOGEMEAY

    '===================================================
    '*** CLASE MESA DE AYUDA MOVIMIENTOS GEOGRAFICOS ***
    '===================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MOGEMEAY(ByVal obMGMASECU As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obMGMASECU.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obMGMASECU.Text) = True Then

                    Dim objdatos1 As New cla_MOGEMEAY
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MOGEMEAY(obMGMASECU.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obMGMASECU.Text) & " existe en la base de datos, se incrementara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obMGMASECU.Focus()
                        boRespuesta = False
                    Else
                        boRespuesta = True
                    End If

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
    Public Function fun_Insertar_MOGEMEAY(ByVal inMGMASECU As Integer, _
                                          ByVal inMGMANURA As Integer, _
                                          ByVal stMGMAFERA As String, _
                                          ByVal inMGMANUCA As Integer, _
                                          ByVal stMGMAVERS As String, _
                                          ByVal stMGMAPEAS As String, _
                                          ByVal stMGMAOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MOGEMEAY "

            stConsultaSQL += "( "
            stConsultaSQL += "MGMASECU, "
            stConsultaSQL += "MGMANURA, "
            stConsultaSQL += "MGMAFERA, "
            stConsultaSQL += "MGMANUCA, "
            stConsultaSQL += "MGMAVERS, "
            stConsultaSQL += "MGMAPEAS, "
            stConsultaSQL += "MGMAOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMGMASECU) & "', "
            stConsultaSQL += "'" & CInt(inMGMANURA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMGMAFERA)) & "', "
            stConsultaSQL += "'" & CInt(inMGMANUCA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMGMAVERS)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMGMAPEAS)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMGMAOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MOGEMEAY")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MOGEMEAY(ByVal inMGMAIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MOGEMEAY "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGMAIDRE = '" & CInt(inMGMAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MOGEMEAY")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MOGEMEAY(ByVal inMGMASECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MOGEMEAY "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGMASECU = '" & CInt(inMGMASECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MOGEMEAY")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_IDRE_X_MOGEMEAY(ByVal inMGMAIDRE As Integer, _
                                                   ByVal inMGMASECU As Integer, _
                                                   ByVal inMGMANURA As Integer, _
                                                   ByVal stMGMAFERA As String, _
                                                   ByVal inMGMANUCA As Integer, _
                                                   ByVal stMGMAVERS As String, _
                                                   ByVal stMGMAPEAS As String, _
                                                   ByVal stMGMAOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MOGEMEAY "

            stConsultaSQL += "SET "
            stConsultaSQL += "MGMASECU = '" & CInt(inMGMASECU) & "', "
            stConsultaSQL += "MGMANURA = '" & CInt(inMGMANURA) & "', "
            stConsultaSQL += "MGMAFERA = '" & CStr(Trim(stMGMAFERA)) & "', "
            stConsultaSQL += "MGMANUCA = '" & CInt(inMGMANUCA) & "', "
            stConsultaSQL += "MGMAVERS = '" & CStr(Trim(stMGMAVERS)) & "', "
            stConsultaSQL += "MGMAPEAS = '" & CStr(Trim(stMGMAPEAS)) & "', "
            stConsultaSQL += "MGMAOBSE = '" & CStr(Trim(stMGMAOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGMAIDRE = '" & CInt(inMGMAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MOGEMEAY")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_SECU_X_MOGEMEAY(ByVal inMGMASECU As Integer, _
                                                   ByVal inMGMANURA As Integer, _
                                                   ByVal stMGMAFERA As String, _
                                                   ByVal inMGMANUCA As Integer, _
                                                   ByVal stMGMAVERS As String, _
                                                   ByVal stMGMAPEAS As String, _
                                                   ByVal stMGMAOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MOGEMEAY "

            stConsultaSQL += "SET "
            stConsultaSQL += "MGMANURA = '" & CInt(inMGMANURA) & "', "
            stConsultaSQL += "MGMAFERA = '" & CStr(Trim(stMGMAFERA)) & "', "
            stConsultaSQL += "MGMANUCA = '" & CInt(inMGMANUCA) & "', "
            stConsultaSQL += "MGMAVERS = '" & CStr(Trim(stMGMAVERS)) & "', "
            stConsultaSQL += "MGMAPEAS = '" & CStr(Trim(stMGMAPEAS)) & "', "
            stConsultaSQL += "MGMAOBSE = '" & CStr(Trim(stMGMAOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGMASECU = '" & CInt(inMGMASECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MOGEMEAY")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MOGEMEAY(ByVal inMGMASECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MGMAIDRE, "
            stConsultaSQL += "MGMASECU, "
            stConsultaSQL += "MGMANURA, "
            stConsultaSQL += "MGMAFERA, "
            stConsultaSQL += "MGMANUCA, "
            stConsultaSQL += "MGMAVERS, "
            stConsultaSQL += "MGMAPEAS, "
            stConsultaSQL += "MGMAOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOGEMEAY "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGMASECU = '" & CInt(inMGMASECU) & " '"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MGMASECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl


        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MOGEMEAY")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MOGEMEAY(ByVal inMGMAIDRE As Integer, ByVal inMGMASECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MGMAIDRE, "
            stConsultaSQL += "MGMASECU, "
            stConsultaSQL += "MGMANURA, "
            stConsultaSQL += "MGMAFERA, "
            stConsultaSQL += "MGMANUCA, "
            stConsultaSQL += "MGMAVERS, "
            stConsultaSQL += "MGMAPEAS, "
            stConsultaSQL += "MGMAOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOGEMEAY "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGMAIDRE = '" & CInt(inMGMAIDRE) & "' AND "
            stConsultaSQL += "MGMASECU = '" & CInt(inMGMASECU) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MGMASECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl


        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MOGEMEAY")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEMEAY(ByVal inMGMASECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MGMAIDRE, "
            stConsultaSQL += "MGMASECU, "
            stConsultaSQL += "MGMANURA, "
            stConsultaSQL += "MGMAFERA, "
            stConsultaSQL += "MGMANUCA, "
            stConsultaSQL += "MGMAVERS, "
            stConsultaSQL += "MGMAPEAS, "
            stConsultaSQL += "MGMAOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOGEMEAY "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGMASECU = '" & CInt(inMGMASECU) & " '"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MGMASECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MOGEMEAY")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MOGEMEAY(ByVal inMGMASECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MOGEMEAY "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MGMASECU = '" & CInt(inMGMASECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_TRABCAMP")
            Return Nothing
        End Try

    End Function

End Class
