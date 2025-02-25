Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RECLAMOS

    '===========================
    '*** CLASE RECTIFICACION ***
    '===========================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RECLAMOS(ByVal obRECLMUNI As Object, _
                                                         ByVal obRECLCORR As Object, _
                                                         ByVal obRECLBARR As Object, _
                                                         ByVal obRECLMANZ As Object, _
                                                         ByVal obRECLPRED As Object, _
                                                         ByVal obRECLEDIF As Object, _
                                                         ByVal obRECLUNPR As Object, _
                                                         ByVal obRECLRADE As Object, _
                                                         ByVal obRECLRAMU As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRECLMUNI.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRECLCORR.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRECLBARR.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRECLMANZ.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRECLPRED.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRECLEDIF.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRECLUNPR.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRECLRADE.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRECLRAMU.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obRECLMUNI.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obRECLCORR.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obRECLBARR.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obRECLMANZ.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obRECLPRED.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obRECLEDIF.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obRECLUNPR.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obRECLRADE.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obRECLRAMU.Text) = True Then

                    Dim objdatos1 As New cla_RECLAMOS
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_RECLAMOS(obRECLMUNI.Text, obRECLCORR.Text, obRECLBARR.Text, obRECLMANZ.Text, obRECLPRED.Text, obRECLEDIF.Text, obRECLUNPR.Text, obRECLRADE.Text, obRECLRAMU.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        obRECLMUNI.Focus()
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
    Public Function fun_Insertar_RECLAMOS(ByVal inRECLSECU As Integer, _
                                            ByVal stRECLMUNI As String, _
                                            ByVal stRECLCORR As String, _
                                            ByVal stRECLBARR As String, _
                                            ByVal stRECLMANZ As String, _
                                            ByVal stRECLPRED As String, _
                                            ByVal stRECLEDIF As String, _
                                            ByVal stRECLUNPR As String, _
                                            ByVal inRECLCLSE As String, _
                                            ByVal inRECLVIGE As Integer, _
                                            ByVal stRECLNUDO As String, _
                                            ByVal stRECLNOMB As String, _
                                            ByVal stRECLPRAP As String, _
                                            ByVal stRECLSEAP As String, _
                                            ByVal stRECLMAIN As String, _
                                            ByVal inRECLRADE As Integer, _
                                            ByVal stRECLFEDE As String, _
                                            ByVal inRECLRAMU As Integer, _
                                            ByVal stRECLFEMU As String, _
                                            ByVal inRECLRAED As Integer, _
                                            ByVal stRECLFEED As String, _
                                            ByVal inRECLRADM As Integer, _
                                            ByVal stRECLFEDM As String, _
                                            ByVal stRECLFELC As String, _
                                            ByVal inRECLTITR As Integer, _
                                            ByVal stRECLOBSE As String, _
                                            ByVal stRECLESTA As String, _
                                            ByVal stRECLMIAN As String, _
                                            ByVal inRECLSOLI As Integer) As Boolean


        Try

            ' variables 
            Dim stRECLDEPA As String = "05"

            '' *** INSTANCIA LA FECHA Y HORA ***
            Dim daRECLFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RECLAMOS "

            stConsultaSQL += "( "
            stConsultaSQL += "RECLSECU, "
            stConsultaSQL += "RECLDEPA, "
            stConsultaSQL += "RECLMUNI, "
            stConsultaSQL += "RECLCORR, "
            stConsultaSQL += "RECLBARR, "
            stConsultaSQL += "RECLMANZ, "
            stConsultaSQL += "RECLPRED, "
            stConsultaSQL += "RECLEDIF, "
            stConsultaSQL += "RECLUNPR, "
            stConsultaSQL += "RECLCLSE, "
            stConsultaSQL += "RECLVIGE, "
            stConsultaSQL += "RECLNUDO, "
            stConsultaSQL += "RECLNOMB, "
            stConsultaSQL += "RECLPRAP, "
            stConsultaSQL += "RECLSEAP, "
            stConsultaSQL += "RECLMAIN, "
            stConsultaSQL += "RECLRADE, "
            stConsultaSQL += "RECLFEDE, "
            stConsultaSQL += "RECLRAMU, "
            stConsultaSQL += "RECLFEMU, "
            stConsultaSQL += "RECLRAED, "
            stConsultaSQL += "RECLFEED, "
            stConsultaSQL += "RECLRADM, "
            stConsultaSQL += "RECLFEDM, "
            stConsultaSQL += "RECLFELC, "
            stConsultaSQL += "RECLTITR, "
            stConsultaSQL += "RECLOBSE, "
            stConsultaSQL += "RECLESTA, "
            stConsultaSQL += "RECLMIAN, "
            stConsultaSQL += "RECLSOLI, "
            stConsultaSQL += "RECLFEIN "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRECLSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLEDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLUNPR)) & "', "
            stConsultaSQL += "'" & CInt(inRECLCLSE) & "', "
            stConsultaSQL += "'" & CInt(inRECLVIGE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLNOMB)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLPRAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLSEAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLMAIN)) & "', "
            stConsultaSQL += "'" & CInt(inRECLRADE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLFEDE)) & "', "
            stConsultaSQL += "'" & CInt(inRECLRAMU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLFEMU)) & "', "
            stConsultaSQL += "'" & CInt(inRECLRAED) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLFEED)) & "', "
            stConsultaSQL += "'" & CInt(inRECLRADM) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLFEDM)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLFELC)) & "', "
            stConsultaSQL += "'" & CInt(inRECLTITR) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLOBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECLMIAN)) & "', "
            stConsultaSQL += "'" & CInt(inRECLSOLI) & "', "
            stConsultaSQL += "'" & CDate(daRECLFEIN) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RECLAMOS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RECLAMOS(ByVal inRECLIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLAMOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECLIDRE = '" & CInt(inRECLIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RECLAMOS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RECLAMOS(ByVal inRECLSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RECLAMOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECLSECU = '" & CInt(inRECLSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RECLAMOS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RECLAMOS(ByVal inRECLIDRE As Integer, _
                                            ByVal inRECLSECU As Integer, _
                                            ByVal stRECLMUNI As String, _
                                            ByVal stRECLCORR As String, _
                                            ByVal stRECLBARR As String, _
                                            ByVal stRECLMANZ As String, _
                                            ByVal stRECLPRED As String, _
                                            ByVal stRECLEDIF As String, _
                                            ByVal stRECLUNPR As String, _
                                            ByVal inRECLCLSE As String, _
                                            ByVal inRECLVIGE As Integer, _
                                            ByVal stRECLNUDO As String, _
                                            ByVal stRECLNOMB As String, _
                                            ByVal stRECLPRAP As String, _
                                            ByVal stRECLSEAP As String, _
                                            ByVal stRECLMAIN As String, _
                                            ByVal inRECLRADE As Integer, _
                                            ByVal stRECLFEDE As String, _
                                            ByVal inRECLRAMU As Integer, _
                                            ByVal stRECLFEMU As String, _
                                            ByVal inRECLRAED As Integer, _
                                            ByVal stRECLFEED As String, _
                                            ByVal inRECLRADM As Integer, _
                                            ByVal stRECLFEDM As String, _
                                            ByVal stRECLFELC As String, _
                                            ByVal inRECLTITR As Integer, _
                                            ByVal stRECLOBSE As String, _
                                            ByVal stRECLESTA As String, _
                                            ByVal stRECLMIAN As String, _
                                            ByVal inRECLSOLI As Integer) As Boolean

        Try
            ' variables
            Dim stRECLDEPA As String = "05"

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RECLAMOS "

            stConsultaSQL += "SET "
            stConsultaSQL += "RECLSECU = '" & CInt(inRECLSECU) & "', "
            stConsultaSQL += "RECLDEPA = '" & CStr(Trim(stRECLDEPA)) & "', "
            stConsultaSQL += "RECLMUNI = '" & CStr(Trim(stRECLMUNI)) & "', "
            stConsultaSQL += "RECLCORR = '" & CStr(Trim(stRECLCORR)) & "', "
            stConsultaSQL += "RECLBARR = '" & CStr(Trim(stRECLBARR)) & "', "
            stConsultaSQL += "RECLMANZ = '" & CStr(Trim(stRECLMANZ)) & "', "
            stConsultaSQL += "RECLPRED = '" & CStr(Trim(stRECLPRED)) & "', "
            stConsultaSQL += "RECLEDIF = '" & CStr(Trim(stRECLEDIF)) & "', "
            stConsultaSQL += "RECLUNPR = '" & CStr(Trim(stRECLUNPR)) & "', "
            stConsultaSQL += "RECLCLSE = '" & CInt(inRECLCLSE) & "', "
            stConsultaSQL += "RECLVIGE = '" & CInt(inRECLVIGE) & "', "
            stConsultaSQL += "RECLNUDO = '" & CStr(Trim(stRECLNUDO)) & "', "
            stConsultaSQL += "RECLNOMB = '" & CStr(Trim(stRECLNOMB)) & "', "
            stConsultaSQL += "RECLPRAP = '" & CStr(Trim(stRECLPRAP)) & "', "
            stConsultaSQL += "RECLSEAP = '" & CStr(Trim(stRECLSEAP)) & "', "
            stConsultaSQL += "RECLMAIN = '" & CStr(Trim(stRECLMAIN)) & "', "
            stConsultaSQL += "RECLRADE = '" & CInt(inRECLRADE) & "', "
            stConsultaSQL += "RECLFEDE = '" & CStr(Trim(stRECLFEDE)) & "', "
            stConsultaSQL += "RECLRAMU = '" & CInt(inRECLRAMU) & "', "
            stConsultaSQL += "RECLFEMU = '" & CStr(Trim(stRECLFEMU)) & "', "
            stConsultaSQL += "RECLRAED = '" & CInt(inRECLRAED) & "', "
            stConsultaSQL += "RECLFEED = '" & CStr(Trim(stRECLFEED)) & "', "
            stConsultaSQL += "RECLRADM = '" & CInt(inRECLRADM) & "', "
            stConsultaSQL += "RECLFEDM = '" & CStr(Trim(stRECLFEDM)) & "', "
            stConsultaSQL += "RECLFELC = '" & CStr(Trim(stRECLFELC)) & "', "
            stConsultaSQL += "RECLTITR = '" & CInt(inRECLTITR) & "', "
            stConsultaSQL += "RECLOBSE = '" & CStr(Trim(stRECLOBSE)) & "', "
            stConsultaSQL += "RECLESTA = '" & CStr(Trim(stRECLESTA)) & "', "
            stConsultaSQL += "RECLMIAN = '" & CStr(Trim(stRECLMIAN)) & "', "
            stConsultaSQL += "RECLSOLI = '" & CInt(inRECLSOLI) & "'  "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECLIDRE = '" & CInt(inRECLIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RECLAMOS")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_Cantidad_x_Usuario_RECLAMOS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "Select RECLUSMC as Usuario, "
            stConsultaSQL += "Count(1) as Pendientes "
            stConsultaSQL += "From RECLAMOS "
            stConsultaSQL += "Where RECLUSMC <> '' AND "
            stConsultaSQL += "RECLESTA = 'ej' "
            stConsultaSQL += "Group by RECLUSMC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLAMOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_Cantidad_x_Usuario_RECLAMOS(ByVal stUSUARIO As String) As DataTable

        Try
            ' instancia la fecha
            Dim daMOGEFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "(Select datediff(day, RECLFEIN, '" & daMOGEFEIN & "')) AS Cantidad, "
            stConsultaSQL += "RECLRAED "
            stConsultaSQL += "From RECLAMOS "
            stConsultaSQL += "Where "
            stConsultaSQL += "RECLUSMC <> '' And "
            stConsultaSQL += "RECLESTA = 'ej' And "
            stConsultaSQL += "RECLUSMC = '" & CStr(Trim(stUSUARIO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLAMOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_Cantidad_x_Vigencia_y_Usuario_RECLAMOS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "RECLUSMC as Usuario, "
            stConsultaSQL += "RECLVIGE as Vigencia, "
            stConsultaSQL += "Count(1) as Cantidad "
            stConsultaSQL += "From RECLAMOS "
            stConsultaSQL += "Where RECLUSMC <> '' "
            stConsultaSQL += "Group by RECLUSMC, RECLVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLAMOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_Cantidad_x_Vigencia_RECLAMOS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "RECLVIGE as Vigencia, "
            stConsultaSQL += "Count(1) as Cantidad "
            stConsultaSQL += "From RECLAMOS "
            stConsultaSQL += "Where RECLUSMC <> '' "
            stConsultaSQL += "Group by RECLVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLAMOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_Cantidad_x_Usuario_y_Vigencia_RECLAMOS(ByVal stUSUARIO As String, _
                                                                         ByVal inVIGENCIA As Integer, _
                                                                         ByVal stESTADO As String) As DataTable

        Try
            ' instancia la fecha
            Dim daMOGEFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "RECLUSMC, "
            stConsultaSQL += "RECLVIGE, "
            stConsultaSQL += "Count(1) as Cantidad "
            stConsultaSQL += "From RECLAMOS "
            stConsultaSQL += "Where "
            stConsultaSQL += "RECLUSMC <> '' And "
            stConsultaSQL += "RECLESTA = '" & CStr(Trim(stESTADO)) & "' AND "
            stConsultaSQL += "RECLUSMC = '" & CStr(Trim(stUSUARIO)) & "' AND "
            stConsultaSQL += "RECLVIGE = '" & CInt(inVIGENCIA) & "' "
            stConsultaSQL += "Group by RECLUSMC, RECLVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLAMOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_Cantidad_x_Usuario_y_Vigencia_RECLAMOS(ByVal inVIGENCIA As Integer, _
                                                                         ByVal stESTADO As String) As DataTable

        Try
            ' instancia la fecha
            Dim daMOGEFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "RECLVIGE, "
            stConsultaSQL += "Count(1) as Cantidad "
            stConsultaSQL += "From RECLAMOS "
            stConsultaSQL += "Where "
            stConsultaSQL += "RECLUSMC <> '' And "
            stConsultaSQL += "RECLESTA = '" & CStr(Trim(stESTADO)) & "' AND "
            stConsultaSQL += "RECLVIGE = '" & CInt(inVIGENCIA) & "' "
            stConsultaSQL += "Group by RECLVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLAMOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RECLAMOS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 0 "
            stConsultaSQL += "RECLIDRE, "
            stConsultaSQL += "RECLSECU, "
            stConsultaSQL += "RECLDEPA, "
            stConsultaSQL += "RECLMUNI, "
            stConsultaSQL += "RECLCORR, "
            stConsultaSQL += "RECLBARR, "
            stConsultaSQL += "RECLMANZ, "
            stConsultaSQL += "RECLPRED, "
            stConsultaSQL += "RECLEDIF, "
            stConsultaSQL += "RECLUNPR, "
            stConsultaSQL += "RECLCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "RECLVIGE, "
            stConsultaSQL += "RECLNUDO, "
            stConsultaSQL += "RECLNOMB, "
            stConsultaSQL += "RECLPRAP, "
            stConsultaSQL += "RECLSEAP, "
            stConsultaSQL += "RECLMAIN, "
            stConsultaSQL += "RECLRADE, "
            stConsultaSQL += "RECLFEDE, "
            stConsultaSQL += "RECLRAMU, "
            stConsultaSQL += "RECLFEMU, "
            stConsultaSQL += "RECLRAED, "
            stConsultaSQL += "RECLFEED, "
            stConsultaSQL += "RECLRADM, "
            stConsultaSQL += "RECLFEDM, "
            stConsultaSQL += "RECLFELC, "
            stConsultaSQL += "RECLTITR, "
            stConsultaSQL += "RECLOBSE, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "RECLMACA, "
            stConsultaSQL += "RECLMIAN, "
            stConsultaSQL += "RECLSOLI, "
            stConsultaSQL += "RECLESTA, "
            stConsultaSQL += "RECLFEMC, "
            stConsultaSQL += "RECLUSMC, "
            stConsultaSQL += "RECLFEIN "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLAMOS, ESTADO, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECLESTA = ESTACODI AND "
            stConsultaSQL += "RECLCLSE = CLSECODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RECLVIGE, RECLCLSE, RECLDEPA, RECLCORR, RECLBARR, RECLMANZ, RECLPRED, RECLEDIF, RECLUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLAMOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RECLAMOS_X_BITACORA() As DataTable

        Try
            ' declaro la variable
            Dim stRECLESTA As String = "ej"

            ' instancia la fecha
            Dim daMOGEFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RECLIDRE, "
            stConsultaSQL += "RECLSECU, "
            stConsultaSQL += "RECLDEPA, "
            stConsultaSQL += "RECLMUNI, "
            stConsultaSQL += "RECLCORR, "
            stConsultaSQL += "RECLBARR, "
            stConsultaSQL += "RECLMANZ, "
            stConsultaSQL += "RECLPRED, "
            stConsultaSQL += "RECLEDIF, "
            stConsultaSQL += "RECLUNPR, "
            stConsultaSQL += "RECLCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "RECLVIGE, "
            stConsultaSQL += "RECLUSMC, "
            stConsultaSQL += "RECLFEIN, "
            stConsultaSQL += "(Select datediff(day, RECLFEIN, '" & daMOGEFEIN & "')) AS RECLDTFI, "
            stConsultaSQL += "RECLFEMC, "
            stConsultaSQL += "(Select datediff(day, RECLFEMC, '" & daMOGEFEIN & "')) AS RECLDTFM, "
            stConsultaSQL += "SOLIDESC, "
            stConsultaSQL += "RECLNUDO, "
            stConsultaSQL += "RECLNOMB, "
            stConsultaSQL += "RECLPRAP, "
            stConsultaSQL += "RECLSEAP, "
            stConsultaSQL += "RECLMAIN, "
            stConsultaSQL += "RECLRADE, "
            stConsultaSQL += "RECLFEDE, "
            stConsultaSQL += "RECLRAMU, "
            stConsultaSQL += "RECLFEMU, "
            stConsultaSQL += "RECLRAED, "
            stConsultaSQL += "RECLFEED, "
            stConsultaSQL += "RECLRADM, "
            stConsultaSQL += "RECLFEDM, "
            stConsultaSQL += "RECLFELC, "
            stConsultaSQL += "RECLTITR, "
            stConsultaSQL += "RECLOBSE, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "RECLMACA, "
            stConsultaSQL += "RECLMIAN, "
            stConsultaSQL += "RECLSOLI, "
            stConsultaSQL += "RECLESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLAMOS, ESTADO, MANT_CLASSECT, MANT_SOLICITANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECLESTA = ESTACODI AND "
            stConsultaSQL += "RECLSOLI = SOLICODI AND "
            stConsultaSQL += "RECLCLSE = CLSECODI AND "
            stConsultaSQL += "RECLESTA = '" & CStr(Trim(stRECLESTA)) & "' AND "
            stConsultaSQL += "RECLUSMC <> '' AND "
            stConsultaSQL += "RECLMACA <> '' AND "
            stConsultaSQL += "RECLFEMC <> '' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RECLVIGE, RECLCLSE, RECLDEPA, RECLCORR, RECLBARR, RECLMANZ, RECLPRED, RECLEDIF, RECLUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLAMOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RECLAMOS_X_BITACORA(ByVal stRECLNUDO As String) As DataTable

        Try
            ' declaro la variable
            Dim stRECLESTA As String = "ej"

            ' instancia la fecha
            Dim daMOGEFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RECLIDRE, "
            stConsultaSQL += "RECLSECU, "
            stConsultaSQL += "RECLDEPA, "
            stConsultaSQL += "RECLMUNI, "
            stConsultaSQL += "RECLCORR, "
            stConsultaSQL += "RECLBARR, "
            stConsultaSQL += "RECLMANZ, "
            stConsultaSQL += "RECLPRED, "
            stConsultaSQL += "RECLEDIF, "
            stConsultaSQL += "RECLUNPR, "
            stConsultaSQL += "RECLCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "RECLVIGE, "
            stConsultaSQL += "RECLUSMC, "
            stConsultaSQL += "RECLFEIN, "
            stConsultaSQL += "(Select datediff(day, RECLFEIN, '" & daMOGEFEIN & "')) AS RECLDTFI, "
            stConsultaSQL += "RECLFEMC, "
            stConsultaSQL += "(Select datediff(day, RECLFEMC, '" & daMOGEFEIN & "')) AS RECLDTFM, "
            stConsultaSQL += "SOLIDESC, "
            stConsultaSQL += "RECLNUDO, "
            stConsultaSQL += "RECLNOMB, "
            stConsultaSQL += "RECLPRAP, "
            stConsultaSQL += "RECLSEAP, "
            stConsultaSQL += "RECLMAIN, "
            stConsultaSQL += "RECLRADE, "
            stConsultaSQL += "RECLFEDE, "
            stConsultaSQL += "RECLRAMU, "
            stConsultaSQL += "RECLFEMU, "
            stConsultaSQL += "RECLRAED, "
            stConsultaSQL += "RECLFEED, "
            stConsultaSQL += "RECLRADM, "
            stConsultaSQL += "RECLFEDM, "
            stConsultaSQL += "RECLFELC, "
            stConsultaSQL += "RECLTITR, "
            stConsultaSQL += "RECLOBSE, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "RECLMACA, "
            stConsultaSQL += "RECLMIAN, "
            stConsultaSQL += "RECLSOLI, "
            stConsultaSQL += "RECLESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLAMOS, ESTADO, MANT_CLASSECT, MANT_SOLICITANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECLESTA = ESTACODI AND "
            stConsultaSQL += "RECLSOLI = SOLICODI AND "
            stConsultaSQL += "RECLCLSE = CLSECODI AND "
            stConsultaSQL += "RECLESTA = '" & CStr(Trim(stRECLESTA)) & "' AND "
            stConsultaSQL += "RECLMACA = '" & CStr(Trim(stRECLNUDO)) & "' AND "
            stConsultaSQL += "RECLUSMC <> '' AND "
            stConsultaSQL += "RECLMACA <> '' AND "
            stConsultaSQL += "RECLFEMC <> '' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RECLVIGE, RECLCLSE, RECLDEPA, RECLCORR, RECLBARR, RECLMANZ, RECLPRED, RECLEDIF, RECLUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLAMOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_RECLAMOS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLAMOS "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RECLVIGE, RECLCLSE, RECLDEPA, RECLCORR, RECLBARR, RECLMANZ, RECLPRED, RECLEDIF, RECLUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_RECLAMOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_RECLAMOS_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLAMOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECLESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RECLVIGE, RECLCLSE, RECLDEPA, RECLCORR, RECLBARR, RECLMANZ, RECLPRED, RECLEDIF, RECLUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLAMOS_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_RECLAMOS(ByVal inRECLIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLAMOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECLIDRE = '" & CInt(inRECLIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_RECLAMOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CEDULA_CATASTRAL_RECLAMOS(ByVal stRECLMUNI As String, _
                                                         ByVal stRECLCORR As String, _
                                                         ByVal stRECLBARR As String, _
                                                         ByVal stRECLMANZ As String, _
                                                         ByVal stRECLPRED As String, _
                                                         ByVal stRECLEDIF As String, _
                                                         ByVal stRECLUNPR As String, _
                                                         ByVal inRECLCLSE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLAMOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECLMUNI = '" & CStr(Trim(stRECLMUNI)) & "'AND  "
            stConsultaSQL += "RECLCORR = '" & CStr(Trim(stRECLCORR)) & "'AND "
            stConsultaSQL += "RECLBARR = '" & CStr(Trim(stRECLBARR)) & "'AND "
            stConsultaSQL += "RECLMANZ = '" & CStr(Trim(stRECLMANZ)) & "'AND "
            stConsultaSQL += "RECLPRED = '" & CStr(Trim(stRECLPRED)) & "'AND "
            stConsultaSQL += "RECLEDIF = '" & CStr(Trim(stRECLEDIF)) & "'AND "
            stConsultaSQL += "RECLUNPR = '" & CStr(Trim(stRECLUNPR)) & "'AND "
            stConsultaSQL += "RECLCLSE = '" & CInt(inRECLCLSE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_RECLAMOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RECLAMOS(ByVal inRECLSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLAMOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECLSECU = '" & CInt(inRECLSECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RECLAMOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_RADICADO_X_RECLAMOS(ByVal inRECLRAMU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLAMOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECLRAMU = '" & CInt(inRECLRAMU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RECLAMOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLAMOS(ByVal inRECLIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RECLIDRE, "
            stConsultaSQL += "RECLSECU, "
            stConsultaSQL += "RECLDEPA, "
            stConsultaSQL += "RECLMUNI, "
            stConsultaSQL += "RECLCORR, "
            stConsultaSQL += "RECLBARR, "
            stConsultaSQL += "RECLMANZ, "
            stConsultaSQL += "RECLPRED, "
            stConsultaSQL += "RECLEDIF, "
            stConsultaSQL += "RECLUNPR, "
            stConsultaSQL += "RECLCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "RECLVIGE, "
            stConsultaSQL += "RECLNUDO, "
            stConsultaSQL += "RECLNOMB, "
            stConsultaSQL += "RECLPRAP, "
            stConsultaSQL += "RECLSEAP, "
            stConsultaSQL += "RECLMAIN, "
            stConsultaSQL += "RECLRADE, "
            stConsultaSQL += "RECLFEDE, "
            stConsultaSQL += "RECLRAMU, "
            stConsultaSQL += "RECLFEMU, "
            stConsultaSQL += "RECLRAED, "
            stConsultaSQL += "RECLFEED, "
            stConsultaSQL += "RECLRADM, "
            stConsultaSQL += "RECLFEDM, "
            stConsultaSQL += "RECLFELC, "
            stConsultaSQL += "RECLTITR, "
            stConsultaSQL += "RECLOBSE, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "RECLMACA, "
            stConsultaSQL += "RECLMIAN, "
            stConsultaSQL += "RECLSOLI, "
            stConsultaSQL += "RECLESTA, "
            stConsultaSQL += "RECLFEMC, "
            stConsultaSQL += "RECLUSMC, "
            stConsultaSQL += "RECLFEIN "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLAMOS, ESTADO, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECLESTA = ESTACODI AND "
            stConsultaSQL += "RECLCLSE = CLSECODI AND "
            stConsultaSQL += "RECLIDRE = '" & CInt(inRECLIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RECLVIGE, RECLCLSE, RECLDEPA, RECLCORR, RECLBARR, RECLMANZ, RECLPRED, RECLEDIF, RECLUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLAMOS")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia maxima
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_RECLAMOS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RECLSECU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLAMOS "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_MAXINA_X_RECLAMOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MATECARG_X_RECLAMOS(ByVal inRECLSECU As Integer, _
                                                       ByVal stRECLMACA As String, _
                                                       ByVal stRECLFEMC As String, _
                                                       ByVal stRECLUSMC As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RECLAMOS "

            stConsultaSQL += "SET "
            stConsultaSQL += "RECLMACA = '" & CStr(Trim(stRECLMACA)) & "', "
            stConsultaSQL += "RECLFEMC = '" & CStr(Trim(stRECLFEMC)) & "', "
            stConsultaSQL += "RECLUSMC = '" & CStr(Trim(stRECLUSMC)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECLSECU = '" & CInt(inRECLSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_TRABCAMP")
        End Try

    End Function

    Public Function fun_Buscar_CODIGO_X_RECLAMOS(ByVal stRECLMUNI As String, _
                                                ByVal stRECLCORR As String, _
                                                ByVal stRECLBARR As String, _
                                                ByVal stRECLMANZ As String, _
                                                ByVal stRECLPRED As String, _
                                                ByVal stRECLEDIF As String, _
                                                ByVal stRECLUNPR As String, _
                                                ByVal inRECLRADE As Integer, _
                                                ByVal inRECLRAMU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RECLAMOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECLMUNI = '" & CStr(Trim(stRECLMUNI)) & "' and "
            stConsultaSQL += "RECLCORR = '" & CStr(Trim(stRECLCORR)) & "' and "
            stConsultaSQL += "RECLBARR = '" & CStr(Trim(stRECLBARR)) & "' and "
            stConsultaSQL += "RECLMANZ = '" & CStr(Trim(stRECLMANZ)) & "' and "
            stConsultaSQL += "RECLPRED = '" & CStr(Trim(stRECLPRED)) & "' and "
            stConsultaSQL += "RECLEDIF = '" & CStr(Trim(stRECLEDIF)) & "' and "
            stConsultaSQL += "RECLUNPR = '" & CStr(Trim(stRECLUNPR)) & "' and "
            stConsultaSQL += "RECLRADE = '" & CInt(inRECLRADE) & "' and "
            stConsultaSQL += "RECLRAMU = '" & CInt(inRECLRAMU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_X_RECLAMOS")
            Return Nothing
        End Try

    End Function

End Class
