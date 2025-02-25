Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RECLACAD

    '============================================
    '*** CLASE ACTOS ADMINISTRATIVOS RECLAMOS ***
    '============================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RECLACAD(ByVal obACADSECU As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obACADSECU.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obACADSECU.Text) = True Then

                    Dim objdatos1 As New cla_RECLACAD
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_RECLACAD(obACADSECU.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obACADSECU.Text) & " existe en la base de datos, se incrementara una secuencia, favor guardar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obACADSECU.Focus()
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
    Public Function fun_Insertar_RECLACAD(ByVal inACADSECU As Integer, _
                                          ByVal inACADACAD As Integer, _
                                          ByVal inACADTITR As Integer, _
                                          ByVal inACADNUEM As Integer, _
                                          ByVal stACADFEEM As String, _
                                          ByVal inACADNURA As Integer, _
                                          ByVal stACADFERA As String, _
                                          ByVal inACADNURR As Integer, _
                                          ByVal stACADFERR As String, _
                                          ByVal stACADOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RECLACAD "

            stConsultaSQL += "( "
            stConsultaSQL += "REAASECU, "
            stConsultaSQL += "REAAACAD, "
            stConsultaSQL += "REAATITR, "
            stConsultaSQL += "REAANUEM, "
            stConsultaSQL += "REAAFEEM, "
            stConsultaSQL += "REAANURA, "
            stConsultaSQL += "REAAFERA, "
            stConsultaSQL += "REAANURR, "
            stConsultaSQL += "REAAFERR, "
            stConsultaSQL += "REAAOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inACADSECU) & "', "
            stConsultaSQL += "'" & CInt(inACADACAD) & "', "
            stConsultaSQL += "'" & CInt(inACADTITR) & "', "
            stConsultaSQL += "'" & CInt(inACADNUEM) & "', "
            stConsultaSQL += "'" & CStr(Trim(stACADFEEM)) & "', "
            stConsultaSQL += "'" & CInt(inACADNURA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stACADFERA)) & "', "
            stConsultaSQL += "'" & CInt(inACADNURR) & "', "
            stConsultaSQL += "'" & CStr(Trim(stACADFERR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stACADOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RECLACAD")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RECLACAD(ByVal inACADIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLACAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAAIDRE = '" & CInt(inACADIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_RECLACAD")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RECLACAD(ByVal inACADSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLACAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAASECU = '" & CInt(inACADSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_RECLACAD")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_IDRE_X_RECLACAD(ByVal inACADIDRE As Integer, _
                                                   ByVal inACADSECU As Integer, _
                                                   ByVal inACADACAD As Integer, _
                                                   ByVal inACADTITR As Integer, _
                                                   ByVal inACADNUEM As Integer, _
                                                   ByVal stACADFEEM As String, _
                                                   ByVal inACADNURA As Integer, _
                                                   ByVal stACADFERA As String, _
                                                   ByVal inACADNURR As Integer, _
                                                   ByVal stACADFERR As String, _
                                                   ByVal stACADOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RECLACAD "

            stConsultaSQL += "SET "
            stConsultaSQL += "REAASECU = '" & CInt(inACADSECU) & "', "
            stConsultaSQL += "REAAACAD = '" & CInt(inACADACAD) & "', "
            stConsultaSQL += "REAATITR = '" & CInt(inACADTITR) & "', "
            stConsultaSQL += "REAANUEM = '" & CInt(inACADNUEM) & "', "
            stConsultaSQL += "REAAFEEM = '" & CStr(Trim(stACADFEEM)) & "', "
            stConsultaSQL += "REAANURA = '" & CInt(inACADNURA) & "', "
            stConsultaSQL += "REAAFERA = '" & CStr(Trim(stACADFERA)) & "', "
            stConsultaSQL += "REAANURR = '" & CInt(inACADNURR) & "', "
            stConsultaSQL += "REAAFERR = '" & CStr(Trim(stACADFERR)) & "', "
            stConsultaSQL += "REAAOBSE = '" & CStr(Trim(stACADOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAAIDRE = '" & CInt(inACADIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RECLACAD")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_SECU_X_RECLACAD(ByVal inACADSECU As Integer, _
                                                   ByVal inACADACAD As Integer, _
                                                   ByVal inACADTITR As Integer, _
                                                   ByVal inACADNUEM As Integer, _
                                                   ByVal stACADFEEM As String, _
                                                   ByVal inACADNURA As Integer, _
                                                   ByVal stACADFERA As String, _
                                                   ByVal inACADNURR As Integer, _
                                                   ByVal stACADFERR As String, _
                                                   ByVal stACADOBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RECLACAD "

            stConsultaSQL += "SET "
            stConsultaSQL += "REAASECU = '" & CInt(inACADSECU) & "', "
            stConsultaSQL += "REAAACAD = '" & CInt(inACADACAD) & "', "
            stConsultaSQL += "REAATITR = '" & CInt(inACADTITR) & "', "
            stConsultaSQL += "REAANUEM = '" & CInt(inACADNUEM) & "', "
            stConsultaSQL += "REAAFEEM = '" & CStr(Trim(stACADFEEM)) & "', "
            stConsultaSQL += "REAANURA = '" & CInt(inACADNURA) & "', "
            stConsultaSQL += "REAAFERA = '" & CStr(Trim(stACADFERA)) & "', "
            stConsultaSQL += "REAANURR = '" & CInt(inACADNURR) & "', "
            stConsultaSQL += "REAAFERR = '" & CStr(Trim(stACADFERR)) & "', "
            stConsultaSQL += "REAAOBSE = '" & CStr(Trim(stACADOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAASECU = '" & CInt(inACADSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RECLACAD")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RECLACAD(ByVal inACADSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REAAIDRE, "
            stConsultaSQL += "REAASECU, "
            stConsultaSQL += "REAAACAD, "
            stConsultaSQL += "REAATITR, "
            stConsultaSQL += "REAANUEM, "
            stConsultaSQL += "REAAFEEM, "
            stConsultaSQL += "REAANURA, "
            stConsultaSQL += "REAAFERA, "
            stConsultaSQL += "REAANURR, "
            stConsultaSQL += "REAAFERR, "
            stConsultaSQL += "REAAOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLACAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAASECU = '" & CInt(inACADSECU) & " '"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REAASECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl


        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLACAD")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLACAD(ByVal inACADSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REAAIDRE, "
            stConsultaSQL += "REAASECU, "
            stConsultaSQL += "REAAACAD, "
            stConsultaSQL += "REAATITR, "
            stConsultaSQL += "REAANUEM, "
            stConsultaSQL += "REAAFEEM, "
            stConsultaSQL += "REAANURA, "
            stConsultaSQL += "REAAFERA, "
            stConsultaSQL += "REAANURR, "
            stConsultaSQL += "REAAFERR, "
            stConsultaSQL += "REAAOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLACAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAASECU = '" & CInt(inACADSECU) & " '"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REAASECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLACAD")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECLACAD(ByVal inACADSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLACAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAASECU = '" & CInt(inACADSECU) & "' "

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
