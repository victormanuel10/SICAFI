Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_FIPRPROP

    '=========================
    '*** CLASE PROPIETARIO ***
    '=========================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_FIPRPROP(ByVal inFPPRNUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPPRNUFI As New SqlParameter("@FPPRNUFI", inFPPRNUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPPRNUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FIPRPROP")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_FIPRPROP(ByVal inFPPRNUFI As Integer, ByVal inFPPRCAPR As Integer, _
                                               ByVal inFPPRSEXO As Integer, _
                                               ByVal inFPPRTIDO As Integer, _
                                               ByVal stFPPRNUDO As String, _
                                               ByVal stFPPRPRAP As String, _
                                               ByVal stFPPRSEAP As String, _
                                               ByVal stFPPRNOMB As String, _
                                               ByVal doFPPRDERE As String, _
                                               ByVal stFPPRSICO As String, _
                                               ByVal inFPPRESCR As Integer, _
                                               ByVal stFPPRDENO As String, _
                                               ByVal stFPPRMUNO As String, _
                                               ByVal stFPPRNOTA As String, _
                                               ByVal stFPPRFEES As String, _
                                               ByVal stFPPRFERE As String, _
                                               ByVal stFPPRTOMO As String, _
                                               ByVal stFPPRMAIN As String, _
                                               ByVal boFPPRGRAV As Boolean, _
                                               ByVal inFPPRMOAD As String, _
                                               ByVal boFPPRLITI As Boolean, _
                                               ByVal stFPPRPOLI As String, _
                                               ByVal stFPPRDEPA As String, _
                                               ByVal stFPPRMUNI As String, _
                                               ByVal inFPPRTIRE As Integer, _
                                               ByVal inFPPRCLSE As Integer, _
                                               ByVal inFPPRVIGE As Integer, _
                                               ByVal inFPPRRESO As Integer, _
                                               ByVal inFPPRSECU As Integer, _
                                               ByVal inFPPRNURE As Integer, _
                                               ByVal stFPPRESTA As String) As Boolean

        ''*** INSTANCIA QUE IDENTIFICA EL NOMBRE DE LA MAQUINA ***
        Dim stFPPRMAQU As String = fun_Nombre_de_maquina()

        '' *** INSTANCIA LA FECHA Y HORA ***
        Dim daFPPRFEIN As Date = fun_Hora_y_fecha()
        Dim daFPPRFEMO As Date = fun_Hora_y_fecha()

        '' *** USUARIO QUE MODIFICA ***
        Dim stFPPRUSIN As String = vp_usuario
        Dim stFPPRUSMO As String = ""

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPPRNUFI As New SqlParameter("@FPPRNUFI", inFPPRNUFI)
            Dim o_inFPPRCAPR As New SqlParameter("@FPPRCAPR", inFPPRCAPR)
            Dim o_inFPPRSEXO As New SqlParameter("@FPPRSEXO", inFPPRSEXO)
            Dim o_inFPPRTIDO As New SqlParameter("@FPPRTIDO", inFPPRTIDO)
            Dim o_stFPPRNUDO As New SqlParameter("@FPPRNUDO", stFPPRNUDO)
            Dim o_stFPPRPRAP As New SqlParameter("@FPPRPRAP", stFPPRPRAP)
            Dim o_stFPPRSEAP As New SqlParameter("@FPPRSEAP", stFPPRSEAP)
            Dim o_stFPPRNOMB As New SqlParameter("@FPPRNOMB", stFPPRNOMB)
            Dim o_doFPPRDERE As New SqlParameter("@FPPRDERE", doFPPRDERE)
            Dim o_stFPPRSICO As New SqlParameter("@FPPRSICO", stFPPRSICO)
            Dim o_inFPPRESCR As New SqlParameter("@FPPRESCR", inFPPRESCR)
            Dim o_stFPPRDENO As New SqlParameter("@FPPRDENO", stFPPRDENO)
            Dim o_stFPPRMUNO As New SqlParameter("@FPPRMUNO", stFPPRMUNO)
            Dim o_stFPPRNOTA As New SqlParameter("@FPPRNOTA", stFPPRNOTA)
            Dim o_stFPPRFEES As New SqlParameter("@FPPRFEES", stFPPRFEES)
            Dim o_stFPPRFERE As New SqlParameter("@FPPRFERE", stFPPRFERE)
            Dim o_stFPPRTOMO As New SqlParameter("@FPPRTOMO", stFPPRTOMO)
            Dim o_stFPPRMAIN As New SqlParameter("@FPPRMAIN", stFPPRMAIN)
            Dim o_boFPPRGRAV As New SqlParameter("@FPPRGRAV", boFPPRGRAV)
            Dim o_inFPPRMOAD As New SqlParameter("@FPPRMOAD", inFPPRMOAD)
            Dim o_boFPPRLITI As New SqlParameter("@FPPRLITI", boFPPRLITI)
            Dim o_stFPPRPOLI As New SqlParameter("@FPPRPOLI", stFPPRPOLI)
            Dim o_stFPPRDEPA As New SqlParameter("@FPPRDEPA", stFPPRDEPA)
            Dim o_stFPPRMUNI As New SqlParameter("@FPPRMUNI", stFPPRMUNI)
            Dim o_inFPPRTIRE As New SqlParameter("@FPPRTIRE", inFPPRTIRE)
            Dim o_inFPPRCLSE As New SqlParameter("@FPPRCLSE", inFPPRCLSE)
            Dim o_inFPPRVIGE As New SqlParameter("@FPPRVIGE", inFPPRVIGE)
            Dim o_inFPPRRESO As New SqlParameter("@FPPRRESO", inFPPRRESO)
            Dim o_inFPPRSECU As New SqlParameter("@FPPRSECU", inFPPRSECU)
            Dim o_inFPPRNURE As New SqlParameter("@FPPRNURE", inFPPRNURE)
            Dim o_stFPPRESTA As New SqlParameter("@FPPRESTA", stFPPRESTA)
            Dim o_stFPPRUSIN As New SqlParameter("@FPPRUSIN", stFPPRUSIN)
            Dim o_stFPPRUSMO As New SqlParameter("@FPPRUSMO", stFPPRUSMO)
            Dim o_daFPPRFEIN As New SqlParameter("@FPPRFEIN", daFPPRFEIN)
            Dim o_daFPPRFEMO As New SqlParameter("@FPPRFEMO", daFPPRFEMO)
            Dim o_stFPPRMAQU As New SqlParameter("@FPPRMAQU", stFPPRMAQU)

            Dim VecParametros(35) As SqlParameter

            VecParametros(0) = o_inFPPRNUFI
            VecParametros(1) = o_inFPPRCAPR
            VecParametros(2) = o_inFPPRSEXO
            VecParametros(3) = o_inFPPRTIDO
            VecParametros(4) = o_stFPPRNUDO
            VecParametros(5) = o_stFPPRPRAP
            VecParametros(6) = o_stFPPRSEAP
            VecParametros(7) = o_stFPPRNOMB
            VecParametros(8) = o_doFPPRDERE
            VecParametros(9) = o_stFPPRSICO
            VecParametros(10) = o_inFPPRESCR
            VecParametros(11) = o_stFPPRDENO
            VecParametros(12) = o_stFPPRMUNO
            VecParametros(13) = o_stFPPRNOTA
            VecParametros(14) = o_stFPPRFEES
            VecParametros(15) = o_stFPPRFERE
            VecParametros(16) = o_stFPPRTOMO
            VecParametros(17) = o_stFPPRMAIN
            VecParametros(18) = o_boFPPRGRAV
            VecParametros(19) = o_inFPPRMOAD
            VecParametros(20) = o_boFPPRLITI
            VecParametros(21) = o_stFPPRPOLI
            VecParametros(22) = o_stFPPRDEPA
            VecParametros(23) = o_stFPPRMUNI
            VecParametros(24) = o_inFPPRTIRE
            VecParametros(25) = o_inFPPRCLSE
            VecParametros(26) = o_inFPPRVIGE
            VecParametros(27) = o_inFPPRRESO
            VecParametros(28) = o_inFPPRSECU
            VecParametros(29) = o_inFPPRNURE
            VecParametros(30) = o_stFPPRESTA
            VecParametros(31) = o_stFPPRUSIN
            VecParametros(32) = o_stFPPRUSMO
            VecParametros(33) = o_daFPPRFEIN
            VecParametros(34) = o_daFPPRFEMO
            VecParametros(35) = o_stFPPRMAQU

            objenq.ActualizarDb(VecParametros, "insertar_FIPRPROP")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_FIPRPROP(ByVal inFPPRIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPPRIDRE As New SqlParameter("@FPPRIDRE", inFPPRIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPPRIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_FIPRPROP") Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica o actualiza el registro.
    ''' </summary>
    Public Function fun_Actualizar_FIPRPROP(ByVal inFPPRIDRE As Integer, _
                                               ByVal inFPPRNUFI As Integer, _
                                               ByVal inFPPRCAPR As Integer, _
                                               ByVal inFPPRSEXO As Integer, _
                                               ByVal inFPPRTIDO As Integer, _
                                               ByVal stFPPRNUDO As String, _
                                               ByVal stFPPRPRAP As String, _
                                               ByVal stFPPRSEAP As String, _
                                               ByVal stFPPRNOMB As String, _
                                               ByVal doFPPRDERE As String, _
                                               ByVal stFPPRSICO As String, _
                                               ByVal inFPPRESCR As Integer, _
                                               ByVal stFPPRDENO As String, _
                                               ByVal stFPPRMUNO As String, _
                                               ByVal stFPPRNOTA As String, _
                                               ByVal stFPPRFEES As String, _
                                               ByVal stFPPRFERE As String, _
                                               ByVal stFPPRTOMO As String, _
                                               ByVal stFPPRMAIN As String, _
                                               ByVal boFPPRGRAV As Boolean, _
                                               ByVal inFPPRMOAD As String, _
                                               ByVal boFPPRLITI As Boolean, _
                                               ByVal stFPPRPOLI As String, _
                                               ByVal stFPPRDEPA As String, _
                                               ByVal stFPPRMUNI As String, _
                                               ByVal inFPPRTIRE As Integer, _
                                               ByVal inFPPRCLSE As Integer, _
                                               ByVal inFPPRVIGE As Integer, _
                                               ByVal inFPPRRESO As Integer, _
                                               ByVal inFPPRSECU As Integer, _
                                               ByVal inFPPRNURE As Integer, _
                                               ByVal stFPPRESTA As String, _
                                               ByVal stFPPRUSIN As String, _
                                               ByVal daFPPRFEIN As Date) As Boolean


        '===================================
        ' DATOS DE MODIFICACIÓN DE REGISTRO
        '===================================

        Dim stFPPRMAQU As String = fun_Nombre_de_maquina()
        Dim daFPPRFEMO As Date = fun_Hora_y_fecha()
        Dim stFPPRUSMO As String = vp_usuario

        '=====================
        ' SOBRECARGA DE DATOS 
        '=====================

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPPRIDRE As New SqlParameter("@FPPRIDRE", inFPPRIDRE)
            Dim o_inFPPRNUFI As New SqlParameter("@FPPRNUFI", inFPPRNUFI)
            Dim o_inFPPRCAPR As New SqlParameter("@FPPRCAPR", inFPPRCAPR)
            Dim o_inFPPRSEXO As New SqlParameter("@FPPRSEXO", inFPPRSEXO)
            Dim o_inFPPRTIDO As New SqlParameter("@FPPRTIDO", inFPPRTIDO)
            Dim o_stFPPRNUDO As New SqlParameter("@FPPRNUDO", stFPPRNUDO)
            Dim o_stFPPRPRAP As New SqlParameter("@FPPRPRAP", stFPPRPRAP)
            Dim o_stFPPRSEAP As New SqlParameter("@FPPRSEAP", stFPPRSEAP)
            Dim o_stFPPRNOMB As New SqlParameter("@FPPRNOMB", stFPPRNOMB)
            Dim o_doFPPRDERE As New SqlParameter("@FPPRDERE", doFPPRDERE)
            Dim o_stFPPRSICO As New SqlParameter("@FPPRSICO", stFPPRSICO)
            Dim o_inFPPRESCR As New SqlParameter("@FPPRESCR", inFPPRESCR)
            Dim o_stFPPRDENO As New SqlParameter("@FPPRDENO", stFPPRDENO)
            Dim o_stFPPRMUNO As New SqlParameter("@FPPRMUNO", stFPPRMUNO)
            Dim o_stFPPRNOTA As New SqlParameter("@FPPRNOTA", stFPPRNOTA)
            Dim o_stFPPRFEES As New SqlParameter("@FPPRFEES", stFPPRFEES)
            Dim o_stFPPRFERE As New SqlParameter("@FPPRFERE", stFPPRFERE)
            Dim o_stFPPRTOMO As New SqlParameter("@FPPRTOMO", stFPPRTOMO)
            Dim o_stFPPRMAIN As New SqlParameter("@FPPRMAIN", stFPPRMAIN)
            Dim o_boFPPRGRAV As New SqlParameter("@FPPRGRAV", boFPPRGRAV)
            Dim o_inFPPRMOAD As New SqlParameter("@FPPRMOAD", inFPPRMOAD)
            Dim o_boFPPRLITI As New SqlParameter("@FPPRLITI", boFPPRLITI)
            Dim o_stFPPRPOLI As New SqlParameter("@FPPRPOLI", stFPPRPOLI)
            Dim o_stFPPRDEPA As New SqlParameter("@FPPRDEPA", stFPPRDEPA)
            Dim o_stFPPRMUNI As New SqlParameter("@FPPRMUNI", stFPPRMUNI)
            Dim o_inFPPRTIRE As New SqlParameter("@FPPRTIRE", inFPPRTIRE)
            Dim o_inFPPRCLSE As New SqlParameter("@FPPRCLSE", inFPPRCLSE)
            Dim o_inFPPRVIGE As New SqlParameter("@FPPRVIGE", inFPPRVIGE)
            Dim o_inFPPRRESO As New SqlParameter("@FPPRRESO", inFPPRRESO)
            Dim o_inFPPRSECU As New SqlParameter("@FPPRSECU", inFPPRSECU)
            Dim o_inFPPRNURE As New SqlParameter("@FPPRNURE", inFPPRNURE)
            Dim o_stFPPRESTA As New SqlParameter("@FPPRESTA", stFPPRESTA)
            Dim o_stFPPRUSIN As New SqlParameter("@FPPRUSIN", stFPPRUSIN)
            Dim o_stFPPRUSMO As New SqlParameter("@FPPRUSMO", stFPPRUSMO)
            Dim o_daFPPRFEIN As New SqlParameter("@FPPRFEIN", daFPPRFEIN)
            Dim o_daFPPRFEMO As New SqlParameter("@FPPRFEMO", daFPPRFEMO)
            Dim o_stFPPRMAQU As New SqlParameter("@FPPRMAQU", stFPPRMAQU)

            Dim VecParametros(36) As SqlParameter

            VecParametros(0) = o_inFPPRIDRE
            VecParametros(1) = o_inFPPRNUFI
            VecParametros(2) = o_inFPPRCAPR
            VecParametros(3) = o_inFPPRSEXO
            VecParametros(4) = o_inFPPRTIDO
            VecParametros(5) = o_stFPPRNUDO
            VecParametros(6) = o_stFPPRPRAP
            VecParametros(7) = o_stFPPRSEAP
            VecParametros(8) = o_stFPPRNOMB
            VecParametros(9) = o_doFPPRDERE
            VecParametros(10) = o_stFPPRSICO
            VecParametros(11) = o_inFPPRESCR
            VecParametros(12) = o_stFPPRDENO
            VecParametros(13) = o_stFPPRMUNO
            VecParametros(14) = o_stFPPRNOTA
            VecParametros(15) = o_stFPPRFEES
            VecParametros(16) = o_stFPPRFERE
            VecParametros(17) = o_stFPPRTOMO
            VecParametros(18) = o_stFPPRMAIN
            VecParametros(19) = o_boFPPRGRAV
            VecParametros(20) = o_inFPPRMOAD
            VecParametros(21) = o_boFPPRLITI
            VecParametros(22) = o_stFPPRPOLI
            VecParametros(23) = o_stFPPRDEPA
            VecParametros(24) = o_stFPPRMUNI
            VecParametros(25) = o_inFPPRTIRE
            VecParametros(26) = o_inFPPRCLSE
            VecParametros(27) = o_inFPPRVIGE
            VecParametros(28) = o_inFPPRRESO
            VecParametros(29) = o_inFPPRSECU
            VecParametros(30) = o_inFPPRNURE
            VecParametros(31) = o_stFPPRESTA
            VecParametros(32) = o_stFPPRUSIN
            VecParametros(33) = o_stFPPRUSMO
            VecParametros(34) = o_daFPPRFEIN
            VecParametros(35) = o_daFPPRFEMO
            VecParametros(36) = o_stFPPRMAQU

            objenq.ActualizarDb(VecParametros, "actualizar_FIPRPROP")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_FIPRPROP(ByVal inFPPRIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPPRIDRE As New SqlParameter("@FPPRIDRE", inFPPRIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPPRIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_FIPRPROP")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DEL PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_FIPRPROP(ByVal inFPPRNUFI As Integer, _
                                                ByVal stFPPRNUDO As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPPRNUFI As New SqlParameter("@FPPRNUFI", inFPPRNUFI)
            Dim o_stFPPRNUDO As New SqlParameter("@FPPRNUDO", stFPPRNUDO)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_inFPPRNUFI
            VecParametros(1) = o_stFPPRNUDO

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_FIPRPROP")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_FIPRPROP(ByVal inFPPRNUFI As Integer, _
                                                                    ByVal stFPPRNUDO As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPPRNUFI As New SqlParameter("@FPPRNUFI", inFPPRNUFI)
            Dim o_stFPPRNUDO As New SqlParameter("@FPPRNUDO", stFPPRNUDO)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_inFPPRNUFI
            VecParametros(1) = o_stFPPRNUDO

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_ID_X_CONSULTA_PARAMETRIZADA_FIPRPROP")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el EL NUMERO DE SECUENCIA DEL PROPIETARIO MAXIMO de acuerdo
    ''' al numero de la ficha predial.
    ''' </summary>
    Public Function fun_Buscar_NRO_SECUENCIA_FIPRPROP_X_FICHA_PREDIAL(ByVal inFPPRNUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPPRNUFI As New SqlParameter("@FPPRNUFI", inFPPRNUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPPRNUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_NRO_SECUENCIA_FIPRPROP_X_FICHA_PREDIAL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que consulta la sumatoria de los porcentajes de la destinación economica
    ''' que se encuantran activos.
    ''' </summary>
    Public Function fun_Consultar_SUMA_X_FPPRDERE_FIPRPROP(ByVal inFPPRNUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPPRNUFI As New SqlParameter("@FPPRNUFI", inFPPRNUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPPRNUFI

            Dim SumaDestino As New DataTable
            SumaDestino = objeq.ConsultarDb(VecParametros, "Consultar_SUMA_X_FPPRDERE_FIPRPROP")

            Return SumaDestino

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Consulta todos los campos de propietario por ficha predial para llenar los
    ''' campos del formulario ficha predial
    ''' </summary>
    Public Function fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(ByVal inFPPRNUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPPRNUFI As New SqlParameter("@FPPRNUFI", inFPPRNUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPPRNUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FIPRPROP_X_FICHA_PREDIAL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_NUFI_FIPRPROP(ByVal inFPPRNUFI As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "FIPRPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPPRNUFI = '" & CInt(inFPPRNUFI) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MUTADEPA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta el propietario por numero de documento
    ''' </summary>
    Public Function fun_Buscar_DOCUMENTO_FIPRPROP(ByVal stFPPRNUDO As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stFPPRNUDO As New SqlParameter("@FPPRNUDO", stFPPRNUDO)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stFPPRNUDO

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_DOCUMENTO_FIPRPROP")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Consulta ficha predial por matricula inmobiliaria
    ''' </summary>
    Public Function fun_Buscar_MATRICULA_FIPRPROP(ByVal stFPPRMAIN As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stFPPRMAIN As New SqlParameter("@FPPRMAIN", stFPPRMAIN)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stFPPRMAIN

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_MATRICULA_FIPRPROP")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MAIN_X_FIPRPROP(ByVal inFPPRNUFI As Integer, _
                                                   ByVal stFPPRMAIN As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "FIPRPROP "

            stConsultaSQL += "SET "
            stConsultaSQL += "FPPRMAIN = '" & CStr(Trim(stFPPRMAIN)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPPRNUFI = '" & CInt(inFPPRNUFI) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_CAPRFIPR")
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_FIPRPROP_X_MATRICULA(ByVal stFPPRMAIN As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FIPRPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPPRMAIN = '" & CStr(Trim(stFPPRMAIN)) & "' AND "
            stConsultaSQL += "FPPRESTA = 'ac' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MUTACIONES")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Consultar_PREDIOS_Y_MATRICULA_X_PROPIETARIOS(ByVal stFIPRDEPA As String, _
                                                                     ByVal stFIPRMUNI As String, _
                                                                     ByVal inFIPRCLSE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "DISTINCT "
            stConsultaSQL += "FIPRNUFI, "
            stConsultaSQL += "FIPRMUNI, "
            stConsultaSQL += "FIPRCLSE, "
            stConsultaSQL += "FIPRCORR, "
            stConsultaSQL += "FIPRBARR, "
            stConsultaSQL += "FIPRMANZ, "
            stConsultaSQL += "FIPRPRED, "
            stConsultaSQL += "FIPREDIF, "
            stConsultaSQL += "FIPRUNPR, "
            stConsultaSQL += "FIPRDIRE, "
            stConsultaSQL += "FPPRMAIN "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FICHPRED, FIPRPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FIPRNUFI = FPPRNUFI AND "
            stConsultaSQL += "FIPRTIFI = 0 AND "
            stConsultaSQL += "FIPRDEPA = '" & CStr(Trim(stFIPRDEPA)) & "' AND "
            stConsultaSQL += "FIPRMUNI = '" & CStr(Trim(stFIPRMUNI)) & "' AND "
            stConsultaSQL += "FIPRCLSE = '" & CInt(inFIPRCLSE) & "' AND "
            stConsultaSQL += "FIPRMOAD IN ('1','3') AND "
            stConsultaSQL += "FIPRESTA = 'ac' AND "
            stConsultaSQL += "FPPRMAIN <> '' AND "
            stConsultaSQL += "FPPRESTA = 'ac' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_PREDIOS_Y_MATRICULA_X_PROPIETARIOS")
            Return Nothing
        End Try

    End Function

End Class
