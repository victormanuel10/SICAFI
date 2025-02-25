Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_REVIAVAL

    '================================
    '*** CLASE REVISION DE AVALUO ***
    '================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_REVIAVAL(ByVal obREAVMUNI As Object, _
                                                         ByVal obREAVCORR As Object, _
                                                         ByVal obREAVBARR As Object, _
                                                         ByVal obREAVMANZ As Object, _
                                                         ByVal obREAVPRED As Object, _
                                                         ByVal obREAVEDIF As Object, _
                                                         ByVal obREAVUNPR As Object, _
                                                         ByVal obREAVRADE As Object, _
                                                         ByVal obREAVRAMU As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obREAVMUNI.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obREAVCORR.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obREAVBARR.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obREAVMANZ.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obREAVPRED.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obREAVEDIF.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obREAVUNPR.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obREAVRADE.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obREAVRAMU.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obREAVMUNI.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obREAVCORR.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obREAVBARR.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obREAVMANZ.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obREAVPRED.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obREAVEDIF.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obREAVUNPR.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obREAVRADE.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obREAVRAMU.Text) = True Then

                    Dim objdatos1 As New cla_REVIAVAL
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_REVIAVAL(obREAVMUNI.Text, obREAVCORR.Text, obREAVBARR.Text, obREAVMANZ.Text, obREAVPRED.Text, obREAVEDIF.Text, obREAVUNPR.Text, obREAVRADE.Text, obREAVRAMU.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        obREAVMUNI.Focus()
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
    Public Function fun_Insertar_REVIAVAL(ByVal inREAVSECU As Integer, _
                                            ByVal stREAVMUNI As String, _
                                            ByVal stREAVCORR As String, _
                                            ByVal stREAVBARR As String, _
                                            ByVal stREAVMANZ As String, _
                                            ByVal stREAVPRED As String, _
                                            ByVal stREAVEDIF As String, _
                                            ByVal stREAVUNPR As String, _
                                            ByVal inREAVCLSE As String, _
                                            ByVal inREAVVIGE As Integer, _
                                            ByVal stREAVNUDO As String, _
                                            ByVal stREAVNOMB As String, _
                                            ByVal stREAVPRAP As String, _
                                            ByVal stREAVSEAP As String, _
                                            ByVal stREAVMAIN As String, _
                                            ByVal inREAVRADE As Integer, _
                                            ByVal stREAVFEDE As String, _
                                            ByVal inREAVRAMU As Integer, _
                                            ByVal stREAVFEMU As String, _
                                            ByVal inREAVRAED As Integer, _
                                            ByVal stREAVFEED As String, _
                                            ByVal inREAVRADM As Integer, _
                                            ByVal stREAVFEDM As String, _
                                            ByVal stREAVFELC As String, _
                                            ByVal inREAVTITR As Integer, _
                                            ByVal stREAVOBSE As String, _
                                            ByVal stREAVESTA As String, _
                                            ByVal stREAVMIAN As String, _
                                            ByVal inREAVSOLI As Integer) As Boolean


        Try

            ' variables 
            Dim stREAVDEPA As String = "05"

            '' *** INSTANCIA LA FECHA Y HORA ***
            Dim daREAVFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "REVIAVAL "

            stConsultaSQL += "( "
            stConsultaSQL += "REAVSECU, "
            stConsultaSQL += "REAVDEPA, "
            stConsultaSQL += "REAVMUNI, "
            stConsultaSQL += "REAVCORR, "
            stConsultaSQL += "REAVBARR, "
            stConsultaSQL += "REAVMANZ, "
            stConsultaSQL += "REAVPRED, "
            stConsultaSQL += "REAVEDIF, "
            stConsultaSQL += "REAVUNPR, "
            stConsultaSQL += "REAVCLSE, "
            stConsultaSQL += "REAVVIGE, "
            stConsultaSQL += "REAVNUDO, "
            stConsultaSQL += "REAVNOMB, "
            stConsultaSQL += "REAVPRAP, "
            stConsultaSQL += "REAVSEAP, "
            stConsultaSQL += "REAVMAIN, "
            stConsultaSQL += "REAVRADE, "
            stConsultaSQL += "REAVFEDE, "
            stConsultaSQL += "REAVRAMU, "
            stConsultaSQL += "REAVFEMU, "
            stConsultaSQL += "REAVRAED, "
            stConsultaSQL += "REAVFEED, "
            stConsultaSQL += "REAVRADM, "
            stConsultaSQL += "REAVFEDM, "
            stConsultaSQL += "REAVFELC, "
            stConsultaSQL += "REAVTITR, "
            stConsultaSQL += "REAVOBSE, "
            stConsultaSQL += "REAVESTA, "
            stConsultaSQL += "REAVMIAN, "
            stConsultaSQL += "REAVSOLI, "
            stConsultaSQL += "REAVFEIN "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inREAVSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVCORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVBARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVEDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVUNPR)) & "', "
            stConsultaSQL += "'" & CInt(inREAVCLSE) & "', "
            stConsultaSQL += "'" & CInt(inREAVVIGE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVNOMB)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVPRAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVSEAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVMAIN)) & "', "
            stConsultaSQL += "'" & CInt(inREAVRADE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVFEDE)) & "', "
            stConsultaSQL += "'" & CInt(inREAVRAMU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVFEMU)) & "', "
            stConsultaSQL += "'" & CInt(inREAVRAED) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVFEED)) & "', "
            stConsultaSQL += "'" & CInt(inREAVRADM) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVFEDM)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVFELC)) & "', "
            stConsultaSQL += "'" & CInt(inREAVTITR) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVOBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREAVMIAN)) & "', "
            stConsultaSQL += "'" & CInt(inREAVSOLI) & "', "
            stConsultaSQL += "'" & CDate(daREAVFEIN) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_REVIAVAL")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_REVIAVAL(ByVal inREAVIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REVIAVAL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAVIDRE = '" & CInt(inREAVIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_REVIAVAL")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_REVIAVAL(ByVal inREAVSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REVIAVAL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAVSECU = '" & CInt(inREAVSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_REVIAVAL")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_REVIAVAL(ByVal inREAVIDRE As Integer, _
                                            ByVal inREAVSECU As Integer, _
                                            ByVal stREAVMUNI As String, _
                                            ByVal stREAVCORR As String, _
                                            ByVal stREAVBARR As String, _
                                            ByVal stREAVMANZ As String, _
                                            ByVal stREAVPRED As String, _
                                            ByVal stREAVEDIF As String, _
                                            ByVal stREAVUNPR As String, _
                                            ByVal inREAVCLSE As String, _
                                            ByVal inREAVVIGE As Integer, _
                                            ByVal stREAVNUDO As String, _
                                            ByVal stREAVNOMB As String, _
                                            ByVal stREAVPRAP As String, _
                                            ByVal stREAVSEAP As String, _
                                            ByVal stREAVMAIN As String, _
                                            ByVal inREAVRADE As Integer, _
                                            ByVal stREAVFEDE As String, _
                                            ByVal inREAVRAMU As Integer, _
                                            ByVal stREAVFEMU As String, _
                                            ByVal inREAVRAED As Integer, _
                                            ByVal stREAVFEED As String, _
                                            ByVal inREAVRADM As Integer, _
                                            ByVal stREAVFEDM As String, _
                                            ByVal stREAVFELC As String, _
                                            ByVal inREAVTITR As Integer, _
                                            ByVal stREAVOBSE As String, _
                                            ByVal stREAVESTA As String, _
                                            ByVal stREAVMIAN As String, _
                                            ByVal inREAVSOLI As Integer) As Boolean

        Try
            ' variables
            Dim stREAVDEPA As String = "05"

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "REVIAVAL "

            stConsultaSQL += "SET "
            stConsultaSQL += "REAVSECU = '" & CInt(inREAVSECU) & "', "
            stConsultaSQL += "REAVDEPA = '" & CStr(Trim(stREAVDEPA)) & "', "
            stConsultaSQL += "REAVMUNI = '" & CStr(Trim(stREAVMUNI)) & "', "
            stConsultaSQL += "REAVCORR = '" & CStr(Trim(stREAVCORR)) & "', "
            stConsultaSQL += "REAVBARR = '" & CStr(Trim(stREAVBARR)) & "', "
            stConsultaSQL += "REAVMANZ = '" & CStr(Trim(stREAVMANZ)) & "', "
            stConsultaSQL += "REAVPRED = '" & CStr(Trim(stREAVPRED)) & "', "
            stConsultaSQL += "REAVEDIF = '" & CStr(Trim(stREAVEDIF)) & "', "
            stConsultaSQL += "REAVUNPR = '" & CStr(Trim(stREAVUNPR)) & "', "
            stConsultaSQL += "REAVCLSE = '" & CInt(inREAVCLSE) & "', "
            stConsultaSQL += "REAVVIGE = '" & CInt(inREAVVIGE) & "', "
            stConsultaSQL += "REAVNUDO = '" & CStr(Trim(stREAVNUDO)) & "', "
            stConsultaSQL += "REAVNOMB = '" & CStr(Trim(stREAVNOMB)) & "', "
            stConsultaSQL += "REAVPRAP = '" & CStr(Trim(stREAVPRAP)) & "', "
            stConsultaSQL += "REAVSEAP = '" & CStr(Trim(stREAVSEAP)) & "', "
            stConsultaSQL += "REAVMAIN = '" & CStr(Trim(stREAVMAIN)) & "', "
            stConsultaSQL += "REAVRADE = '" & CInt(inREAVRADE) & "', "
            stConsultaSQL += "REAVFEDE = '" & CStr(Trim(stREAVFEDE)) & "', "
            stConsultaSQL += "REAVRAMU = '" & CInt(inREAVRAMU) & "', "
            stConsultaSQL += "REAVFEMU = '" & CStr(Trim(stREAVFEMU)) & "', "
            stConsultaSQL += "REAVRAED = '" & CInt(inREAVRAED) & "', "
            stConsultaSQL += "REAVFEED = '" & CStr(Trim(stREAVFEED)) & "', "
            stConsultaSQL += "REAVRADM = '" & CInt(inREAVRADM) & "', "
            stConsultaSQL += "REAVFEDM = '" & CStr(Trim(stREAVFEDM)) & "', "
            stConsultaSQL += "REAVFELC = '" & CStr(Trim(stREAVFELC)) & "', "
            stConsultaSQL += "REAVTITR = '" & CInt(inREAVTITR) & "', "
            stConsultaSQL += "REAVOBSE = '" & CStr(Trim(stREAVOBSE)) & "', "
            stConsultaSQL += "REAVESTA = '" & CStr(Trim(stREAVESTA)) & "', "
            stConsultaSQL += "REAVMIAN = '" & CStr(Trim(stREAVMIAN)) & "', "
            stConsultaSQL += "REAVSOLI = '" & CInt(inREAVSOLI) & "'  "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAVIDRE = '" & CInt(inREAVIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_REVIAVAL")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_REVIAVAL() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 0 "
            stConsultaSQL += "REAVIDRE, "
            stConsultaSQL += "REAVSECU, "
            stConsultaSQL += "REAVDEPA, "
            stConsultaSQL += "REAVMUNI, "
            stConsultaSQL += "REAVCORR, "
            stConsultaSQL += "REAVBARR, "
            stConsultaSQL += "REAVMANZ, "
            stConsultaSQL += "REAVPRED, "
            stConsultaSQL += "REAVEDIF, "
            stConsultaSQL += "REAVUNPR, "
            stConsultaSQL += "REAVCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "REAVVIGE, "
            stConsultaSQL += "REAVNUDO, "
            stConsultaSQL += "REAVNOMB, "
            stConsultaSQL += "REAVPRAP, "
            stConsultaSQL += "REAVSEAP, "
            stConsultaSQL += "REAVMAIN, "
            stConsultaSQL += "REAVRADE, "
            stConsultaSQL += "REAVFEDE, "
            stConsultaSQL += "REAVRAMU, "
            stConsultaSQL += "REAVFEMU, "
            stConsultaSQL += "REAVRAED, "
            stConsultaSQL += "REAVFEED, "
            stConsultaSQL += "REAVRADM, "
            stConsultaSQL += "REAVFEDM, "
            stConsultaSQL += "REAVFELC, "
            stConsultaSQL += "REAVTITR, "
            stConsultaSQL += "REAVOBSE, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "REAVMACA, "
            stConsultaSQL += "REAVMIAN, "
            stConsultaSQL += "REAVSOLI, "
            stConsultaSQL += "REAVESTA, "
            stConsultaSQL += "REAVFEMC, "
            stConsultaSQL += "REAVUSMC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REVIAVAL, ESTADO, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAVESTA = ESTACODI AND "
            stConsultaSQL += "REAVCLSE = CLSECODI  "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REAVVIGE, REAVCLSE, REAVDEPA, REAVCORR, REAVBARR, REAVMANZ, REAVPRED, REAVEDIF, REAVUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_REVIAVAL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_REVIAVAL() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REVIAVAL "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REAVVIGE, REAVCLSE, REAVDEPA, REAVCORR, REAVBARR, REAVMANZ, REAVPRED, REAVEDIF, REAVUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_REVIAVAL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_REVIAVAL_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REVIAVAL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAVESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REAVVIGE, REAVCLSE, REAVDEPA, REAVCORR, REAVBARR, REAVMANZ, REAVPRED, REAVEDIF, REAVUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_REVIAVAL_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_REVIAVAL(ByVal inREAVIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REVIAVAL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAVIDRE = '" & CInt(inREAVIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_REVIAVAL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CEDULA_CATASTRAL_REVIAVAL(ByVal stREAVMUNI As String, _
                                                         ByVal stREAVCORR As String, _
                                                         ByVal stREAVBARR As String, _
                                                         ByVal stREAVMANZ As String, _
                                                         ByVal stREAVPRED As String, _
                                                         ByVal stREAVEDIF As String, _
                                                         ByVal stREAVUNPR As String, _
                                                         ByVal inREAVCLSE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REVIAVAL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAVMUNI = '" & CStr(Trim(stREAVMUNI)) & "'AND  "
            stConsultaSQL += "REAVCORR = '" & CStr(Trim(stREAVCORR)) & "'AND "
            stConsultaSQL += "REAVBARR = '" & CStr(Trim(stREAVBARR)) & "'AND "
            stConsultaSQL += "REAVMANZ = '" & CStr(Trim(stREAVMANZ)) & "'AND "
            stConsultaSQL += "REAVPRED = '" & CStr(Trim(stREAVPRED)) & "'AND "
            stConsultaSQL += "REAVEDIF = '" & CStr(Trim(stREAVEDIF)) & "'AND "
            stConsultaSQL += "REAVUNPR = '" & CStr(Trim(stREAVUNPR)) & "'AND "
            stConsultaSQL += "REAVCLSE = '" & CInt(inREAVCLSE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_REVIAVAL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_REVIAVAL(ByVal inREAVSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REVIAVAL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAVSECU = '" & CInt(inREAVSECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_REVIAVAL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_RADICADO_X_REVIAVAL(ByVal inREAVRAMU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REVIAVAL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAVRAMU = '" & CInt(inREAVRAMU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_REVIAVAL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REVIAVAL(ByVal inREAVIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REAVIDRE, "
            stConsultaSQL += "REAVSECU, "
            stConsultaSQL += "REAVDEPA, "
            stConsultaSQL += "REAVMUNI, "
            stConsultaSQL += "REAVCORR, "
            stConsultaSQL += "REAVBARR, "
            stConsultaSQL += "REAVMANZ, "
            stConsultaSQL += "REAVPRED, "
            stConsultaSQL += "REAVEDIF, "
            stConsultaSQL += "REAVUNPR, "
            stConsultaSQL += "REAVCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "REAVVIGE, "
            stConsultaSQL += "REAVNUDO, "
            stConsultaSQL += "REAVNOMB, "
            stConsultaSQL += "REAVPRAP, "
            stConsultaSQL += "REAVSEAP, "
            stConsultaSQL += "REAVMAIN, "
            stConsultaSQL += "REAVRADE, "
            stConsultaSQL += "REAVFEDE, "
            stConsultaSQL += "REAVRAMU, "
            stConsultaSQL += "REAVFEMU, "
            stConsultaSQL += "REAVRAED, "
            stConsultaSQL += "REAVFEED, "
            stConsultaSQL += "REAVRADM, "
            stConsultaSQL += "REAVFEDM, "
            stConsultaSQL += "REAVFELC, "
            stConsultaSQL += "REAVTITR, "
            stConsultaSQL += "REAVOBSE, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "REAVMACA, "
            stConsultaSQL += "REAVMIAN, "
            stConsultaSQL += "REAVSOLI, "
            stConsultaSQL += "REAVESTA, "
            stConsultaSQL += "REAVFEMC, "
            stConsultaSQL += "REAVUSMC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REVIAVAL, ESTADO, MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAVESTA = ESTACODI AND "
            stConsultaSQL += "REAVCLSE = CLSECODI AND "
            stConsultaSQL += "REAVIDRE = '" & CInt(inREAVIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REAVVIGE, REAVCLSE, REAVDEPA, REAVCORR, REAVBARR, REAVMANZ, REAVPRED, REAVEDIF, REAVUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REVIAVAL")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia maxima
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_REVIAVAL() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REAVSECU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REVIAVAL "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_MAXINA_X_REVIAVAL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MATECARG_X_REVIAVAL(ByVal inREAVSECU As Integer, _
                                                       ByVal stREAVMACA As String, _
                                                       ByVal stREAVFEMC As String, _
                                                       ByVal stREAVUSMC As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "REVIAVAL "

            stConsultaSQL += "SET "
            stConsultaSQL += "REAVMACA = '" & CStr(Trim(stREAVMACA)) & "', "
            stConsultaSQL += "REAVFEMC = '" & CStr(Trim(stREAVFEMC)) & "', "
            stConsultaSQL += "REAVUSMC = '" & CStr(Trim(stREAVUSMC)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAVSECU = '" & CInt(inREAVSECU) & "' "

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

    Public Function fun_Buscar_CODIGO_X_REVIAVAL(ByVal stREAVMUNI As String, _
                                                ByVal stREAVCORR As String, _
                                                ByVal stREAVBARR As String, _
                                                ByVal stREAVMANZ As String, _
                                                ByVal stREAVPRED As String, _
                                                ByVal stREAVEDIF As String, _
                                                ByVal stREAVUNPR As String, _
                                                ByVal inREAVRADE As Integer, _
                                                ByVal inREAVRAMU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REVIAVAL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAVMUNI = '" & CStr(Trim(stREAVMUNI)) & "' and "
            stConsultaSQL += "REAVCORR = '" & CStr(Trim(stREAVCORR)) & "' and "
            stConsultaSQL += "REAVBARR = '" & CStr(Trim(stREAVBARR)) & "' and "
            stConsultaSQL += "REAVMANZ = '" & CStr(Trim(stREAVMANZ)) & "' and "
            stConsultaSQL += "REAVPRED = '" & CStr(Trim(stREAVPRED)) & "' and "
            stConsultaSQL += "REAVEDIF = '" & CStr(Trim(stREAVEDIF)) & "' and "
            stConsultaSQL += "REAVUNPR = '" & CStr(Trim(stREAVUNPR)) & "' and "
            stConsultaSQL += "REAVRADE = '" & CInt(inREAVRADE) & "' and "
            stConsultaSQL += "REAVRAMU = '" & CInt(inREAVRAMU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_X_REVIAVAL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_REVIAVAL_X_BITACORA() As DataTable

        Try
            ' declaro la variable
            Dim stREAVESTA As String = "ej"

            ' instancia la fecha
            Dim daMOGEFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REAVIDRE, "
            stConsultaSQL += "REAVSECU, "
            stConsultaSQL += "REAVDEPA, "
            stConsultaSQL += "REAVMUNI, "
            stConsultaSQL += "REAVCORR, "
            stConsultaSQL += "REAVBARR, "
            stConsultaSQL += "REAVMANZ, "
            stConsultaSQL += "REAVPRED, "
            stConsultaSQL += "REAVEDIF, "
            stConsultaSQL += "REAVUNPR, "
            stConsultaSQL += "REAVCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "REAVVIGE, "
            stConsultaSQL += "REAVUSMC, "
            stConsultaSQL += "REAVFEIN, "
            stConsultaSQL += "(Select datediff(day, REAVFEIN, '" & daMOGEFEIN & "')) AS REAVDTFI, "
            stConsultaSQL += "REAVFEMC, "
            stConsultaSQL += "(Select datediff(day, REAVFEMC, '" & daMOGEFEIN & "')) AS REAVDTFM, "
            stConsultaSQL += "SOLIDESC, "
            stConsultaSQL += "REAVNUDO, "
            stConsultaSQL += "REAVNOMB, "
            stConsultaSQL += "REAVPRAP, "
            stConsultaSQL += "REAVSEAP, "
            stConsultaSQL += "REAVMAIN, "
            stConsultaSQL += "REAVRADE, "
            stConsultaSQL += "REAVFEDE, "
            stConsultaSQL += "REAVRAMU, "
            stConsultaSQL += "REAVFEMU, "
            stConsultaSQL += "REAVRAED, "
            stConsultaSQL += "REAVFEED, "
            stConsultaSQL += "REAVRADM, "
            stConsultaSQL += "REAVFEDM, "
            stConsultaSQL += "REAVFELC, "
            stConsultaSQL += "REAVTITR, "
            stConsultaSQL += "REAVOBSE, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "REAVMACA, "
            stConsultaSQL += "REAVMIAN, "
            stConsultaSQL += "REAVSOLI, "
            stConsultaSQL += "REAVESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REVIAVAL, ESTADO, MANT_CLASSECT, MANT_SOLICITANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAVESTA = ESTACODI AND "
            stConsultaSQL += "REAVSOLI = SOLICODI AND "
            stConsultaSQL += "REAVCLSE = CLSECODI AND "
            stConsultaSQL += "REAVESTA = '" & CStr(Trim(stREAVESTA)) & "' AND "
            stConsultaSQL += "REAVUSMC <> '' AND "
            stConsultaSQL += "REAVMACA <> '' AND "
            stConsultaSQL += "REAVFEMC <> '' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REAVVIGE, REAVCLSE, REAVDEPA, REAVCORR, REAVBARR, REAVMANZ, REAVPRED, REAVEDIF, REAVUNPR "

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
    Public Function fun_Consultar_REVIAVAL_X_BITACORA(ByVal stREAVNUDO As String) As DataTable

        Try
            ' declaro la variable
            Dim stREAVESTA As String = "ej"

            ' instancia la fecha
            Dim daMOGEFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "REAVIDRE, "
            stConsultaSQL += "REAVSECU, "
            stConsultaSQL += "REAVDEPA, "
            stConsultaSQL += "REAVMUNI, "
            stConsultaSQL += "REAVCORR, "
            stConsultaSQL += "REAVBARR, "
            stConsultaSQL += "REAVMANZ, "
            stConsultaSQL += "REAVPRED, "
            stConsultaSQL += "REAVEDIF, "
            stConsultaSQL += "REAVUNPR, "
            stConsultaSQL += "REAVCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "REAVVIGE, "
            stConsultaSQL += "REAVUSMC, "
            stConsultaSQL += "REAVFEIN, "
            stConsultaSQL += "(Select datediff(day, REAVFEIN, '" & daMOGEFEIN & "')) AS REAVDTFI, "
            stConsultaSQL += "REAVFEMC, "
            stConsultaSQL += "(Select datediff(day, REAVFEMC, '" & daMOGEFEIN & "')) AS REAVDTFM, "
            stConsultaSQL += "SOLIDESC, "
            stConsultaSQL += "REAVNUDO, "
            stConsultaSQL += "REAVNOMB, "
            stConsultaSQL += "REAVPRAP, "
            stConsultaSQL += "REAVSEAP, "
            stConsultaSQL += "REAVMAIN, "
            stConsultaSQL += "REAVRADE, "
            stConsultaSQL += "REAVFEDE, "
            stConsultaSQL += "REAVRAMU, "
            stConsultaSQL += "REAVFEMU, "
            stConsultaSQL += "REAVRAED, "
            stConsultaSQL += "REAVFEED, "
            stConsultaSQL += "REAVRADM, "
            stConsultaSQL += "REAVFEDM, "
            stConsultaSQL += "REAVFELC, "
            stConsultaSQL += "REAVTITR, "
            stConsultaSQL += "REAVOBSE, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "REAVMACA, "
            stConsultaSQL += "REAVMIAN, "
            stConsultaSQL += "REAVSOLI, "
            stConsultaSQL += "REAVESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REVIAVAL, ESTADO, MANT_CLASSECT, MANT_SOLICITANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "REAVESTA = ESTACODI AND "
            stConsultaSQL += "REAVSOLI = SOLICODI AND "
            stConsultaSQL += "REAVCLSE = CLSECODI AND "
            stConsultaSQL += "REAVESTA = '" & CStr(Trim(stREAVESTA)) & "' AND "
            stConsultaSQL += "REAVMACA = '" & CStr(Trim(stREAVNUDO)) & "' AND "
            stConsultaSQL += "REAVUSMC <> '' AND "
            stConsultaSQL += "REAVMACA <> '' AND "
            stConsultaSQL += "REAVFEMC <> '' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "REAVVIGE, REAVCLSE, REAVDEPA, REAVCORR, REAVBARR, REAVMANZ, REAVPRED, REAVEDIF, REAVUNPR "

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
    Public Function fun_Consultar_Cantidad_x_Usuario_REVIAVAL(ByVal stUSUARIO As String) As DataTable

        Try
            ' instancia la fecha
            Dim daMOGEFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "(Select datediff(day, REAVFEIN, '" & daMOGEFEIN & "')) AS Cantidad, "
            stConsultaSQL += "REAVRAED "
            stConsultaSQL += "From REVIAVAL "
            stConsultaSQL += "Where "
            stConsultaSQL += "REAVUSMC <> '' And "
            stConsultaSQL += "REAVESTA = 'ej' And "
            stConsultaSQL += "REAVUSMC = '" & CStr(Trim(stUSUARIO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_REVIAVAL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_Cantidad_x_Vigencia_y_Usuario_REVIAVAL() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "REAVUSMC as Usuario, "
            stConsultaSQL += "REAVVIGE as Vigencia, "
            stConsultaSQL += "Count(1) as Cantidad "
            stConsultaSQL += "From REVIAVAL "
            stConsultaSQL += "Where REAVUSMC <> '' "
            stConsultaSQL += "Group by REAVUSMC, REAVVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_REVIAVAL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_Cantidad_x_Vigencia_REVIAVAL() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "REAVVIGE as Vigencia, "
            stConsultaSQL += "Count(1) as Cantidad "
            stConsultaSQL += "From REVIAVAL "
            stConsultaSQL += "Where REAVUSMC <> '' "
            stConsultaSQL += "Group by REAVVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_REVIAVAL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_Cantidad_x_Usuario_y_Vigencia_REVIAVAL(ByVal stUSUARIO As String, _
                                                                         ByVal inVIGENCIA As Integer, _
                                                                         ByVal stESTADO As String) As DataTable

        Try
            ' instancia la fecha
            Dim daMOGEFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "REAVUSMC, "
            stConsultaSQL += "REAVVIGE, "
            stConsultaSQL += "Count(1) as Cantidad "
            stConsultaSQL += "From REVIAVAL "
            stConsultaSQL += "Where "
            stConsultaSQL += "REAVUSMC <> '' And "
            stConsultaSQL += "REAVESTA = '" & CStr(Trim(stESTADO)) & "' AND "
            stConsultaSQL += "REAVUSMC = '" & CStr(Trim(stUSUARIO)) & "' AND "
            stConsultaSQL += "REAVVIGE = '" & CInt(inVIGENCIA) & "' "
            stConsultaSQL += "Group by REAVUSMC, REAVVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_REVIAVAL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_Cantidad_x_Usuario_y_Vigencia_REVIAVAL(ByVal inVIGENCIA As Integer, _
                                                                         ByVal stESTADO As String) As DataTable

        Try
            ' instancia la fecha
            Dim daMOGEFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "REAVVIGE, "
            stConsultaSQL += "Count(1) as Cantidad "
            stConsultaSQL += "From REVIAVAL "
            stConsultaSQL += "Where "
            stConsultaSQL += "REAVUSMC <> '' And "
            stConsultaSQL += "REAVESTA = '" & CStr(Trim(stESTADO)) & "' AND "
            stConsultaSQL += "REAVVIGE = '" & CInt(inVIGENCIA) & "' "
            stConsultaSQL += "Group by REAVVIGE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_REVIAVAL")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_Cantidad_x_Usuario_REVIAVAL() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "Select REAVUSMC as Usuario, "
            stConsultaSQL += "Count(1) as Pendientes "
            stConsultaSQL += "From REVIAVAL "
            stConsultaSQL += "Where REAVUSMC <> '' AND "
            stConsultaSQL += "REAVESTA = 'ej' "
            stConsultaSQL += "Group by REAVUSMC "

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

End Class
