Imports SYSTEM.Security.Principal
Imports SYSTEM.Security.Permissions
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_FICHPRED

    '===========================
    '*** CLASE FICHA PREDIAL ***
    '===========================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_FICHPRED() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_FICHPRED")

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    '''   <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_FICHPRED() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_FICHPRED")

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Funcion que busca el campo de la notaria en estado activo 
    ''' (Solo debuelve el campo de la notaria)
    ''' </summary>
    Public Function fun_Consultar_FICHPRED_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_FICHPRED_X_ESTADO")

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_FICHPRED(ByVal inFIPRNUFI As Integer, _
                                              ByVal inFIPRVIGE As Integer, _
                                              ByVal inFIPRTIRE As Integer, _
                                              ByVal inFIPRRESO As Integer, _
                                              ByVal stFIPRDIRE As String, _
                                              ByVal stFIPRDESC As String, _
                                              ByVal boFIPRCONJ As Boolean, _
                                              ByVal daFIPRFECH As Date, _
                                              ByVal inFIPRNURE As Integer, _
                                              ByVal stFIPRDEPA As String, _
                                              ByVal stFIPRMUNI As String, _
                                              ByVal stFIPRCORR As String, _
                                              ByVal stFIPRBARR As String, _
                                              ByVal stFIPRMANZ As String, _
                                              ByVal stFIPRPRED As String, _
                                              ByVal stFIPREDIF As String, _
                                              ByVal stFIPRUNPR As String, _
                                              ByVal inFIPRCLSE As Integer, _
                                              ByVal inFIPRCASU As Integer, _
                                              ByVal stFIPRMUAN As String, _
                                              ByVal stFIPRCOAN As String, _
                                              ByVal stFIPRBAAN As String, _
                                              ByVal stFIPRMAAN As String, _
                                              ByVal stFIPRPRAN As String, _
                                              ByVal stFIPREDAN As String, _
                                              ByVal stFIPRUPAN As String, _
                                              ByVal inFIPRCSAN As Integer, _
                                              ByVal inFIPRCASA As Integer, _
                                              ByVal inFIPRCAPR As Integer, _
                                              ByVal inFIPRMOAD As Integer, _
                                              ByVal stFIPRESTA As String, _
                                              ByVal boFIPRLITI As Boolean, _
                                              ByVal stFIPRPOLI As String, _
                                              ByVal stFIPRCORE As String, _
                                              ByVal inFIPRARTE As Integer, _
                                              ByVal stFIPRCOPR As String, _
                                              ByVal stFIPRCOED As String, _
                                              ByVal inFIPRTIFI As Integer, _
                                              ByVal boFIPRINCO As Boolean) As Boolean


        ''*** INSTANCIA QUE IDENTIFICA EL NOMBRE DE LA MAQUINA ***
        Dim stFIPRMAQU As String = fun_Nombre_de_maquina()

        '' *** INSTANCIA LA FECHA Y HORA ***
        Dim daFIPRFEIN As Date = fun_Hora_y_fecha()
        Dim daFIPRFEMO As Date = fun_Hora_y_fecha()

        Dim stFIPRUSMO As String = ""
        Dim stFIPRDATR As String = ""
        Dim stFIPRDAVI As String = ""
        Dim stFIPRDAND As String = ""
        Dim stFIPROBSE As String = ""

        Dim stFIPRCLSE_CODI As String = Trim(inFIPRCLSE)
        Dim stFIPRMUNI_CODI As String = Trim(stFIPRMUNI)
        Dim stFIPRCORR_CODI As String = Trim(stFIPRCORR)
        Dim stFIPRBARR_CODI As String = Trim(stFIPRBARR)
        Dim stFIPRMANZ_CODI As String = Trim(stFIPRMANZ)
        Dim stFIPRPRED_CODI As String = Trim(stFIPRPRED)
        Dim stFIPREDIF_CODI As String = Trim(stFIPREDIF)
        Dim stFIPRUNPR_CODI As String = Trim(stFIPRUNPR)

        stFIPRCLSE_CODI = stFIPRCLSE_CODI.PadLeft(1, "0")
        stFIPRCLSE_CODI = stFIPRCLSE_CODI.Substring(0, 1)

        stFIPRMUNI_CODI = stFIPRMUNI_CODI.PadLeft(3, "0")
        stFIPRMUNI_CODI = stFIPRMUNI_CODI.Substring(0, 3)

        stFIPRCORR_CODI = stFIPRCORR_CODI.PadLeft(2, "0")
        stFIPRCORR_CODI = stFIPRCORR_CODI.Substring(0, 2)

        stFIPRBARR_CODI = stFIPRBARR_CODI.PadLeft(3, "0")
        stFIPRBARR_CODI = stFIPRBARR_CODI.Substring(0, 3)

        stFIPRMANZ_CODI = stFIPRMANZ_CODI.PadLeft(3, "0")
        stFIPRMANZ_CODI = stFIPRMANZ_CODI.Substring(0, 3)

        stFIPRPRED_CODI = stFIPRPRED_CODI.PadLeft(5, "0")
        stFIPRPRED_CODI = stFIPRPRED_CODI.Substring(0, 5)

        stFIPREDIF_CODI = stFIPREDIF_CODI.PadLeft(3, "0")
        stFIPREDIF_CODI = stFIPREDIF_CODI.Substring(0, 3)

        stFIPRUNPR_CODI = stFIPRUNPR_CODI.PadLeft(5, "0")
        stFIPRUNPR_CODI = stFIPRUNPR_CODI.Substring(0, 5)

        Dim stFIPRCECA As String = stFIPRCLSE_CODI & stFIPRMUNI_CODI & stFIPRCORR_CODI & stFIPRBARR_CODI & stFIPRMANZ_CODI & stFIPRPRED_CODI & stFIPREDIF_CODI & stFIPRUNPR_CODI

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFIPRNUFI As New SqlParameter("@FIPRNUFI", inFIPRNUFI)
            Dim o_inFIPRVIGE As New SqlParameter("@FIPRVIGE", inFIPRVIGE)
            Dim o_inFIPRTIRE As New SqlParameter("@FIPRTIRE", inFIPRTIRE)
            Dim o_inFIPRRESO As New SqlParameter("@FIPRRESO", inFIPRRESO)
            Dim o_stFIPRDIRE As New SqlParameter("@FIPRDIRE", stFIPRDIRE)
            Dim o_stFIPRDESC As New SqlParameter("@FIPRDESC", stFIPRDESC)
            Dim o_boFIPRCONJ As New SqlParameter("@FIPRCONJ", boFIPRCONJ)
            Dim o_daFIPRFECH As New SqlParameter("@FIPRFECH", daFIPRFECH)
            Dim o_inFIPRNURE As New SqlParameter("@FIPRNURE", inFIPRNURE)
            Dim o_stFIPRDEPA As New SqlParameter("@FIPRDEPA", stFIPRDEPA)
            Dim o_stFIPRMUNI As New SqlParameter("@FIPRMUNI", stFIPRMUNI)
            Dim o_stFIPRCORR As New SqlParameter("@FIPRCORR", stFIPRCORR)
            Dim o_stFIPRBARR As New SqlParameter("@FIPRBARR", stFIPRBARR)
            Dim o_stFIPRMANZ As New SqlParameter("@FIPRMANZ", stFIPRMANZ)
            Dim o_stFIPRPRED As New SqlParameter("@FIPRPRED", stFIPRPRED)
            Dim o_stFIPREDIF As New SqlParameter("@FIPREDIF", stFIPREDIF)
            Dim o_stFIPRUNPR As New SqlParameter("@FIPRUNPR", stFIPRUNPR)
            Dim o_inFIPRCLSE As New SqlParameter("@FIPRCLSE", inFIPRCLSE)
            Dim o_inFIPRCASU As New SqlParameter("@FIPRCASU", inFIPRCASU)
            Dim o_stFIPRMUAN As New SqlParameter("@FIPRMUAN", stFIPRMUAN)
            Dim o_stFIPRCOAN As New SqlParameter("@FIPRCOAN", stFIPRCOAN)
            Dim o_stFIPRBAAN As New SqlParameter("@FIPRBAAN", stFIPRBAAN)
            Dim o_stFIPRMAAN As New SqlParameter("@FIPRMAAN", stFIPRMAAN)
            Dim o_stFIPRPRAN As New SqlParameter("@FIPRPRAN", stFIPRPRAN)
            Dim o_stFIPREDAN As New SqlParameter("@FIPREDAN", stFIPREDAN)
            Dim o_stFIPRUPAN As New SqlParameter("@FIPRUPAN", stFIPRUPAN)
            Dim o_inFIPRCSAN As New SqlParameter("@FIPRCSAN", inFIPRCSAN)
            Dim o_inFIPRCASA As New SqlParameter("@FIPRCASA", inFIPRCASA)
            Dim o_inFIPRCAPR As New SqlParameter("@FIPRCAPR", inFIPRCAPR)
            Dim o_inFIPRMOAD As New SqlParameter("@FIPRMOAD", inFIPRMOAD)
            Dim o_inFIPRARTE As New SqlParameter("@FIPRARTE", inFIPRARTE)
            Dim o_stFIPRCOPR As New SqlParameter("@FIPRCOPR", stFIPRCOPR)
            Dim o_stFIPRCOED As New SqlParameter("@FIPRCOED", stFIPRCOED)
            Dim o_stFIPRESTA As New SqlParameter("@FIPRESTA", stFIPRESTA)
            Dim o_stFIPRCECA As New SqlParameter("@FIPRCECA", stFIPRCECA)
            Dim o_stFIPRDATR As New SqlParameter("@FIPRDATR", stFIPRDATR)
            Dim o_stFIPRDAVI As New SqlParameter("@FIPRDAVI", stFIPRDAVI)
            Dim o_stFIPRDAND As New SqlParameter("@FIPRDAND", stFIPRDAND)
            Dim o_stFIPRCORE As New SqlParameter("@FIPRCORE", stFIPRCORE)
            Dim o_stFIPRUSIN As New SqlParameter("@FIPRUSIN", vp_usuario)
            Dim o_stFIPRUSMO As New SqlParameter("@FIPRUSMO", stFIPRUSMO)
            Dim o_daFIPRFEIN As New SqlParameter("@FIPRFEIN", daFIPRFEIN)
            Dim o_daFIPRFEMO As New SqlParameter("@FIPRFEMO", daFIPRFEMO)
            Dim o_stFIPRMAQU As New SqlParameter("@FIPRMAQU", stFIPRMAQU)
            Dim o_stFIPROBSE As New SqlParameter("@FIPROBSE", stFIPROBSE)
            Dim o_boFIPRLITI As New SqlParameter("@FIPRLITI", boFIPRLITI)
            Dim o_stFIPRPOLI As New SqlParameter("@FIPRPOLI", stFIPRPOLI)
            Dim o_inFIPRTIFI As New SqlParameter("@FIPRTIFI", inFIPRTIFI)
            Dim o_boFIPRINCO As New SqlParameter("@FIPRINCO", boFIPRINCO)

            Dim VecParametros(48) As SqlParameter

            VecParametros(0) = o_inFIPRNUFI
            VecParametros(1) = o_inFIPRVIGE
            VecParametros(2) = o_inFIPRTIRE
            VecParametros(3) = o_inFIPRRESO
            VecParametros(4) = o_stFIPRDIRE
            VecParametros(5) = o_stFIPRDESC
            VecParametros(6) = o_boFIPRCONJ
            VecParametros(7) = o_daFIPRFECH
            VecParametros(8) = o_inFIPRNURE
            VecParametros(9) = o_stFIPRDEPA
            VecParametros(10) = o_stFIPRMUNI
            VecParametros(11) = o_stFIPRCORR
            VecParametros(12) = o_stFIPRBARR
            VecParametros(13) = o_stFIPRMANZ
            VecParametros(14) = o_stFIPRPRED
            VecParametros(15) = o_stFIPREDIF
            VecParametros(16) = o_stFIPRUNPR
            VecParametros(17) = o_inFIPRCLSE
            VecParametros(18) = o_inFIPRCASU
            VecParametros(19) = o_stFIPRMUAN
            VecParametros(20) = o_stFIPRCOAN
            VecParametros(21) = o_stFIPRBAAN
            VecParametros(22) = o_stFIPRMAAN
            VecParametros(23) = o_stFIPRPRAN
            VecParametros(24) = o_stFIPREDAN
            VecParametros(25) = o_stFIPRUPAN
            VecParametros(26) = o_inFIPRCSAN
            VecParametros(27) = o_inFIPRCASA
            VecParametros(28) = o_inFIPRCAPR
            VecParametros(29) = o_inFIPRMOAD
            VecParametros(30) = o_inFIPRARTE
            VecParametros(31) = o_stFIPRCOPR
            VecParametros(32) = o_stFIPRCOED
            VecParametros(33) = o_stFIPRESTA
            VecParametros(34) = o_stFIPRCECA
            VecParametros(35) = o_stFIPRDATR
            VecParametros(36) = o_stFIPRDAVI
            VecParametros(37) = o_stFIPRDAND
            VecParametros(38) = o_stFIPRCORE
            VecParametros(39) = o_stFIPRUSIN
            VecParametros(40) = o_stFIPRUSMO
            VecParametros(41) = o_daFIPRFEIN
            VecParametros(42) = o_daFIPRFEMO
            VecParametros(43) = o_stFIPRMAQU
            VecParametros(44) = o_stFIPROBSE
            VecParametros(45) = o_boFIPRLITI
            VecParametros(46) = o_stFIPRPOLI
            VecParametros(47) = o_inFIPRTIFI
            VecParametros(48) = o_boFIPRINCO

            objenq.ActualizarDb(VecParametros, "insertar_FICHPRED")

            Return True

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_FICHPRED(ByVal inFIPRNUFI As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFIPRNUFI As New SqlParameter("@FIPRNUFI", inFIPRNUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFIPRNUFI

            If objenq.ActualizarDb(VecParametros, "eliminar_FICHPRED") Then
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
    Public Function fun_Actualizar_FICHPRED(ByVal inFIPRIDRE As Integer, _
                                              ByVal inFIPRNUFI As Integer, _
                                              ByVal inFIPRVIGE As Integer, _
                                              ByVal inFIPRTIRE As Integer, _
                                              ByVal inFIPRRESO As Integer, _
                                              ByVal stFIPRDIRE As String, _
                                              ByVal stFIPRDESC As String, _
                                              ByVal boFIPRCONJ As Boolean, _
                                              ByVal daFIPRFECH As Date, _
                                              ByVal inFIPRNURE As Integer, _
                                              ByVal stFIPRDEPA As String, _
                                              ByVal stFIPRMUNI As String, _
                                              ByVal stFIPRCORR As String, _
                                              ByVal stFIPRBARR As String, _
                                              ByVal stFIPRMANZ As String, _
                                              ByVal stFIPRPRED As String, _
                                              ByVal stFIPREDIF As String, _
                                              ByVal stFIPRUNPR As String, _
                                              ByVal inFIPRCLSE As Integer, _
                                              ByVal inFIPRCASU As Integer, _
                                              ByVal stFIPRMUAN As String, _
                                              ByVal stFIPRCOAN As String, _
                                              ByVal stFIPRBAAN As String, _
                                              ByVal stFIPRMAAN As String, _
                                              ByVal stFIPRPRAN As String, _
                                              ByVal stFIPREDAN As String, _
                                              ByVal stFIPRUPAN As String, _
                                              ByVal inFIPRCSAN As Integer, _
                                              ByVal inFIPRCASA As Integer, _
                                              ByVal inFIPRCAPR As Integer, _
                                              ByVal inFIPRMOAD As Integer, _
                                              ByVal inFIPRARTE As Integer, _
                                              ByVal stFIPRCOPR As String, _
                                              ByVal stFIPRCOED As String, _
                                              ByVal stFIPRESTA As String, _
                                              ByVal stFIPRUSIN As String, _
                                              ByVal daFIPRFEIN As Date, _
                                              ByVal stFIPROBSE As String, _
                                              ByVal stFIPRCECA As String, _
                                              ByVal stFIPRDATR As String, _
                                              ByVal stFIPRDAVI As String, _
                                              ByVal stFIPRDAND As String, _
                                              ByVal boFIPRLITI As Boolean, _
                                              ByVal stFIPRPOLI As String, _
                                              ByVal stFIPRCORE As String, _
                                              ByVal inFIPRTIFI As Integer, _
                                              ByVal boFIPRINCO As Boolean) As Boolean

        '*** INSTANCIA QUE IDENTIFICA EL NOMBRE DE LA MAQUINA ***
        Dim stFIPRMAQU As String = fun_Nombre_de_maquina()

        ' *** INSTANCIA LA FECHA Y HORA ***
        Dim daFIPRFEMO As Date = fun_Hora_y_fecha()

        Dim stFIPRCLSE_CODI As String = Trim(inFIPRCLSE)
        Dim stFIPRMUNI_CODI As String = Trim(stFIPRMUNI)
        Dim stFIPRCORR_CODI As String = Trim(stFIPRCORR)
        Dim stFIPRBARR_CODI As String = Trim(stFIPRBARR)
        Dim stFIPRMANZ_CODI As String = Trim(stFIPRMANZ)
        Dim stFIPRPRED_CODI As String = Trim(stFIPRPRED)
        Dim stFIPREDIF_CODI As String = Trim(stFIPREDIF)
        Dim stFIPRUNPR_CODI As String = Trim(stFIPRUNPR)

        stFIPRCLSE_CODI = stFIPRCLSE_CODI.PadLeft(1, "0")
        stFIPRCLSE_CODI = stFIPRCLSE_CODI.Substring(0, 1)

        stFIPRMUNI_CODI = stFIPRMUNI_CODI.PadLeft(3, "0")
        stFIPRMUNI_CODI = stFIPRMUNI_CODI.Substring(0, 3)

        stFIPRCORR_CODI = stFIPRCORR_CODI.PadLeft(2, "0")
        stFIPRCORR_CODI = stFIPRCORR_CODI.Substring(0, 2)

        stFIPRBARR_CODI = stFIPRBARR_CODI.PadLeft(3, "0")
        stFIPRBARR_CODI = stFIPRBARR_CODI.Substring(0, 3)

        stFIPRMANZ_CODI = stFIPRMANZ_CODI.PadLeft(3, "0")
        stFIPRMANZ_CODI = stFIPRMANZ_CODI.Substring(0, 3)

        stFIPRPRED_CODI = stFIPRPRED_CODI.PadLeft(5, "0")
        stFIPRPRED_CODI = stFIPRPRED_CODI.Substring(0, 5)

        stFIPREDIF_CODI = stFIPREDIF_CODI.PadLeft(3, "0")
        stFIPREDIF_CODI = stFIPREDIF_CODI.Substring(0, 3)

        stFIPRUNPR_CODI = stFIPRUNPR_CODI.PadLeft(5, "0")
        stFIPRUNPR_CODI = stFIPRUNPR_CODI.Substring(0, 5)

        Dim nueva_stFIPRCECA As String = stFIPRCLSE_CODI & stFIPRMUNI_CODI & stFIPRCORR_CODI & stFIPRBARR_CODI & stFIPRMANZ_CODI & stFIPRPRED_CODI & stFIPREDIF_CODI & stFIPRUNPR_CODI


        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFIPRIDRE As New SqlParameter("@FIPRIDRE", inFIPRIDRE)
            Dim o_inFIPRNUFI As New SqlParameter("@FIPRNUFI", inFIPRNUFI)
            Dim o_inFIPRVIGE As New SqlParameter("@FIPRVIGE", inFIPRVIGE)
            Dim o_inFIPRTIRE As New SqlParameter("@FIPRTIRE", inFIPRTIRE)
            Dim o_inFIPRRESO As New SqlParameter("@FIPRRESO", inFIPRRESO)
            Dim o_stFIPRDIRE As New SqlParameter("@FIPRDIRE", stFIPRDIRE)
            Dim o_stFIPRDESC As New SqlParameter("@FIPRDESC", stFIPRDESC)
            Dim o_boFIPRCONJ As New SqlParameter("@FIPRCONJ", boFIPRCONJ)
            Dim o_daFIPRFECH As New SqlParameter("@FIPRFECH", daFIPRFECH)
            Dim o_inFIPRNURE As New SqlParameter("@FIPRNURE", inFIPRNURE)
            Dim o_stFIPRDEPA As New SqlParameter("@FIPRDEPA", stFIPRDEPA)
            Dim o_stFIPRMUNI As New SqlParameter("@FIPRMUNI", stFIPRMUNI)
            Dim o_stFIPRCORR As New SqlParameter("@FIPRCORR", stFIPRCORR)
            Dim o_stFIPRBARR As New SqlParameter("@FIPRBARR", stFIPRBARR)
            Dim o_stFIPRMANZ As New SqlParameter("@FIPRMANZ", stFIPRMANZ)
            Dim o_stFIPRPRED As New SqlParameter("@FIPRPRED", stFIPRPRED)
            Dim o_stFIPREDIF As New SqlParameter("@FIPREDIF", stFIPREDIF)
            Dim o_stFIPRUNPR As New SqlParameter("@FIPRUNPR", stFIPRUNPR)
            Dim o_inFIPRCLSE As New SqlParameter("@FIPRCLSE", inFIPRCLSE)
            Dim o_inFIPRCASU As New SqlParameter("@FIPRCASU", inFIPRCASU)
            Dim o_stFIPRMUAN As New SqlParameter("@FIPRMUAN", stFIPRMUAN)
            Dim o_stFIPRCOAN As New SqlParameter("@FIPRCOAN", stFIPRCOAN)
            Dim o_stFIPRBAAN As New SqlParameter("@FIPRBAAN", stFIPRBAAN)
            Dim o_stFIPRMAAN As New SqlParameter("@FIPRMAAN", stFIPRMAAN)
            Dim o_stFIPRPRAN As New SqlParameter("@FIPRPRAN", stFIPRPRAN)
            Dim o_stFIPREDAN As New SqlParameter("@FIPREDAN", stFIPREDAN)
            Dim o_stFIPRUPAN As New SqlParameter("@FIPRUPAN", stFIPRUPAN)
            Dim o_inFIPRCSAN As New SqlParameter("@FIPRCSAN", inFIPRCSAN)
            Dim o_inFIPRCASA As New SqlParameter("@FIPRCASA", inFIPRCASA)
            Dim o_inFIPRCAPR As New SqlParameter("@FIPRCAPR", inFIPRCAPR)
            Dim o_inFIPRMOAD As New SqlParameter("@FIPRMOAD", inFIPRMOAD)
            Dim o_inFIPRARTE As New SqlParameter("@FIPRARTE", inFIPRARTE)
            Dim o_stFIPRCOPR As New SqlParameter("@FIPRCOPR", stFIPRCOPR)
            Dim o_stFIPRCOED As New SqlParameter("@FIPRCOED", stFIPRCOED)
            Dim o_stFIPRESTA As New SqlParameter("@FIPRESTA", stFIPRESTA)
            Dim o_stFIPRCECA As New SqlParameter("@FIPRCECA", nueva_stFIPRCECA)
            Dim o_stFIPRDATR As New SqlParameter("@FIPRDATR", stFIPRDATR)
            Dim o_stFIPRDAVI As New SqlParameter("@FIPRDAVI", stFIPRDAVI)
            Dim o_stFIPRDAND As New SqlParameter("@FIPRDAND", stFIPRDAND)
            Dim o_stFIPRCORE As New SqlParameter("@FIPRCORE", stFIPRCORE)
            Dim o_stFIPRUSIN As New SqlParameter("@FIPRUSIN", stFIPRUSIN)
            Dim o_stFIPRUSMO As New SqlParameter("@FIPRUSMO", vp_usuario)
            Dim o_daFIPRFEIN As New SqlParameter("@FIPRFEIN", daFIPRFEIN)
            Dim o_daFIPRFEMO As New SqlParameter("@FIPRFEMO", daFIPRFEMO)
            Dim o_stFIPRMAQU As New SqlParameter("@FIPRMAQU", stFIPRMAQU)
            Dim o_stFIPROBSE As New SqlParameter("@FIPROBSE", stFIPROBSE)
            Dim o_boFIPRLITI As New SqlParameter("@FIPRLITI", boFIPRLITI)
            Dim o_stFIPRPOLI As New SqlParameter("@FIPRPOLI", stFIPRPOLI)
            Dim o_inFIPRTIFI As New SqlParameter("@FIPRTIFI", inFIPRTIFI)
            Dim o_boFIPRINCO As New SqlParameter("@FIPRINCO", boFIPRINCO)

            Dim VecParametros(49) As SqlParameter

            VecParametros(0) = o_inFIPRIDRE
            VecParametros(1) = o_inFIPRNUFI
            VecParametros(2) = o_inFIPRVIGE
            VecParametros(3) = o_inFIPRTIRE
            VecParametros(4) = o_inFIPRRESO
            VecParametros(5) = o_stFIPRDIRE
            VecParametros(6) = o_stFIPRDESC
            VecParametros(7) = o_boFIPRCONJ
            VecParametros(8) = o_daFIPRFECH
            VecParametros(9) = o_inFIPRNURE
            VecParametros(11) = o_stFIPRDEPA
            VecParametros(12) = o_stFIPRMUNI
            VecParametros(13) = o_stFIPRCORR
            VecParametros(14) = o_stFIPRBARR
            VecParametros(15) = o_stFIPRMANZ
            VecParametros(16) = o_stFIPRPRED
            VecParametros(17) = o_stFIPREDIF
            VecParametros(18) = o_stFIPRUNPR
            VecParametros(19) = o_inFIPRCLSE
            VecParametros(10) = o_inFIPRCASU
            VecParametros(20) = o_stFIPRMUAN
            VecParametros(21) = o_stFIPRCOAN
            VecParametros(22) = o_stFIPRBAAN
            VecParametros(23) = o_stFIPRMAAN
            VecParametros(24) = o_stFIPRPRAN
            VecParametros(25) = o_stFIPREDAN
            VecParametros(26) = o_stFIPRUPAN
            VecParametros(27) = o_inFIPRCSAN
            VecParametros(28) = o_inFIPRCASA
            VecParametros(29) = o_inFIPRCAPR
            VecParametros(30) = o_inFIPRMOAD
            VecParametros(31) = o_inFIPRARTE
            VecParametros(32) = o_stFIPRCOPR
            VecParametros(33) = o_stFIPRCOED
            VecParametros(34) = o_stFIPRESTA
            VecParametros(35) = o_stFIPRCECA
            VecParametros(36) = o_stFIPRDATR
            VecParametros(37) = o_stFIPRDAVI
            VecParametros(38) = o_stFIPRDAND
            VecParametros(39) = o_stFIPRCORE
            VecParametros(40) = o_stFIPRUSIN
            VecParametros(41) = o_stFIPRUSMO
            VecParametros(42) = o_daFIPRFEIN
            VecParametros(43) = o_daFIPRFEMO
            VecParametros(44) = o_stFIPRMAQU
            VecParametros(45) = o_stFIPROBSE
            VecParametros(46) = o_boFIPRLITI
            VecParametros(47) = o_stFIPRPOLI
            VecParametros(48) = o_inFIPRTIFI
            VecParametros(49) = o_boFIPRINCO

            If objenq.ActualizarDb(VecParametros, "actualizar_FICHPRED") = True Then
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
    Public Function fun_Actualizar_X_NUFI_FICHPRED(ByVal inFIPRNUFI As Integer, _
                                              ByVal inFIPRVIGE As Integer, _
                                              ByVal inFIPRTIRE As Integer, _
                                              ByVal inFIPRRESO As Integer, _
                                              ByVal stFIPRDIRE As String, _
                                              ByVal stFIPRDESC As String, _
                                              ByVal boFIPRCONJ As Boolean, _
                                              ByVal daFIPRFECH As Date, _
                                              ByVal inFIPRNURE As Integer, _
                                              ByVal stFIPRDEPA As String, _
                                              ByVal stFIPRMUNI As String, _
                                              ByVal stFIPRCORR As String, _
                                              ByVal stFIPRBARR As String, _
                                              ByVal stFIPRMANZ As String, _
                                              ByVal stFIPRPRED As String, _
                                              ByVal stFIPREDIF As String, _
                                              ByVal stFIPRUNPR As String, _
                                              ByVal inFIPRCLSE As Integer, _
                                              ByVal inFIPRCASU As Integer, _
                                              ByVal stFIPRMUAN As String, _
                                              ByVal stFIPRCOAN As String, _
                                              ByVal stFIPRBAAN As String, _
                                              ByVal stFIPRMAAN As String, _
                                              ByVal stFIPRPRAN As String, _
                                              ByVal stFIPREDAN As String, _
                                              ByVal stFIPRUPAN As String, _
                                              ByVal inFIPRCSAN As Integer, _
                                              ByVal inFIPRCASA As Integer, _
                                              ByVal inFIPRCAPR As Integer, _
                                              ByVal inFIPRMOAD As Integer, _
                                              ByVal stFIPRESTA As String, _
                                              ByVal boFIPRLITI As Boolean, _
                                              ByVal stFIPRPOLI As String, _
                                              ByVal inFIPRARTE As Integer, _
                                              ByVal stFIPRCOPR As String, _
                                              ByVal stFIPRCOED As String, _
                                              ByVal inFIPRTIFI As Integer) As Boolean

        '*** INSTANCIA QUE IDENTIFICA EL NOMBRE DE LA MAQUINA ***
        Dim stFIPRMAQU As String = fun_Nombre_de_maquina()

        ' *** INSTANCIA LA FECHA Y HORA ***
        Dim daFIPRFEMO As Date = fun_Hora_y_fecha()

        Dim stFIPRCLSE_CODI As String = Trim(inFIPRCLSE)
        Dim stFIPRMUNI_CODI As String = Trim(stFIPRMUNI)
        Dim stFIPRCORR_CODI As String = Trim(stFIPRCORR)
        Dim stFIPRBARR_CODI As String = Trim(stFIPRBARR)
        Dim stFIPRMANZ_CODI As String = Trim(stFIPRMANZ)
        Dim stFIPRPRED_CODI As String = Trim(stFIPRPRED)
        Dim stFIPREDIF_CODI As String = Trim(stFIPREDIF)
        Dim stFIPRUNPR_CODI As String = Trim(stFIPRUNPR)

        stFIPRCLSE_CODI = stFIPRCLSE_CODI.PadLeft(1, "0")
        stFIPRCLSE_CODI = stFIPRCLSE_CODI.Substring(0, 1)

        stFIPRMUNI_CODI = stFIPRMUNI_CODI.PadLeft(3, "0")
        stFIPRMUNI_CODI = stFIPRMUNI_CODI.Substring(0, 3)

        stFIPRCORR_CODI = stFIPRCORR_CODI.PadLeft(2, "0")
        stFIPRCORR_CODI = stFIPRCORR_CODI.Substring(0, 2)

        stFIPRBARR_CODI = stFIPRBARR_CODI.PadLeft(3, "0")
        stFIPRBARR_CODI = stFIPRBARR_CODI.Substring(0, 3)

        stFIPRMANZ_CODI = stFIPRMANZ_CODI.PadLeft(3, "0")
        stFIPRMANZ_CODI = stFIPRMANZ_CODI.Substring(0, 3)

        stFIPRPRED_CODI = stFIPRPRED_CODI.PadLeft(5, "0")
        stFIPRPRED_CODI = stFIPRPRED_CODI.Substring(0, 5)

        stFIPREDIF_CODI = stFIPREDIF_CODI.PadLeft(3, "0")
        stFIPREDIF_CODI = stFIPREDIF_CODI.Substring(0, 3)

        stFIPRUNPR_CODI = stFIPRUNPR_CODI.PadLeft(5, "0")
        stFIPRUNPR_CODI = stFIPRUNPR_CODI.Substring(0, 5)

        Dim nueva_stFIPRCECA As String = stFIPRCLSE_CODI & stFIPRMUNI_CODI & stFIPRCORR_CODI & stFIPRBARR_CODI & stFIPRMANZ_CODI & stFIPRPRED_CODI & stFIPREDIF_CODI & stFIPRUNPR_CODI


        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFIPRNUFI As New SqlParameter("@FIPRNUFI", inFIPRNUFI)
            Dim o_inFIPRVIGE As New SqlParameter("@FIPRVIGE", inFIPRVIGE)
            Dim o_inFIPRTIRE As New SqlParameter("@FIPRTIRE", inFIPRTIRE)
            Dim o_inFIPRRESO As New SqlParameter("@FIPRRESO", inFIPRRESO)
            Dim o_stFIPRDIRE As New SqlParameter("@FIPRDIRE", stFIPRDIRE)
            Dim o_stFIPRDESC As New SqlParameter("@FIPRDESC", stFIPRDESC)
            Dim o_boFIPRCONJ As New SqlParameter("@FIPRCONJ", boFIPRCONJ)
            Dim o_daFIPRFECH As New SqlParameter("@FIPRFECH", daFIPRFECH)
            Dim o_inFIPRNURE As New SqlParameter("@FIPRNURE", inFIPRNURE)
            Dim o_stFIPRDEPA As New SqlParameter("@FIPRDEPA", stFIPRDEPA)
            Dim o_stFIPRMUNI As New SqlParameter("@FIPRMUNI", stFIPRMUNI)
            Dim o_stFIPRCORR As New SqlParameter("@FIPRCORR", stFIPRCORR)
            Dim o_stFIPRBARR As New SqlParameter("@FIPRBARR", stFIPRBARR)
            Dim o_stFIPRMANZ As New SqlParameter("@FIPRMANZ", stFIPRMANZ)
            Dim o_stFIPRPRED As New SqlParameter("@FIPRPRED", stFIPRPRED)
            Dim o_stFIPREDIF As New SqlParameter("@FIPREDIF", stFIPREDIF)
            Dim o_stFIPRUNPR As New SqlParameter("@FIPRUNPR", stFIPRUNPR)
            Dim o_inFIPRCLSE As New SqlParameter("@FIPRCLSE", inFIPRCLSE)
            Dim o_inFIPRCASU As New SqlParameter("@FIPRCASU", inFIPRCASU)
            Dim o_stFIPRMUAN As New SqlParameter("@FIPRMUAN", stFIPRMUAN)
            Dim o_stFIPRCOAN As New SqlParameter("@FIPRCOAN", stFIPRCOAN)
            Dim o_stFIPRBAAN As New SqlParameter("@FIPRBAAN", stFIPRBAAN)
            Dim o_stFIPRMAAN As New SqlParameter("@FIPRMAAN", stFIPRMAAN)
            Dim o_stFIPRPRAN As New SqlParameter("@FIPRPRAN", stFIPRPRAN)
            Dim o_stFIPREDAN As New SqlParameter("@FIPREDAN", stFIPREDAN)
            Dim o_stFIPRUPAN As New SqlParameter("@FIPRUPAN", stFIPRUPAN)
            Dim o_inFIPRCSAN As New SqlParameter("@FIPRCSAN", inFIPRCSAN)
            Dim o_inFIPRCASA As New SqlParameter("@FIPRCASA", inFIPRCASA)
            Dim o_inFIPRCAPR As New SqlParameter("@FIPRCAPR", inFIPRCAPR)
            Dim o_inFIPRMOAD As New SqlParameter("@FIPRMOAD", inFIPRMOAD)
            Dim o_inFIPRARTE As New SqlParameter("@FIPRARTE", inFIPRARTE)
            Dim o_stFIPRCOPR As New SqlParameter("@FIPRCOPR", stFIPRCOPR)
            Dim o_stFIPRCOED As New SqlParameter("@FIPRCOED", stFIPRCOED)
            Dim o_stFIPRESTA As New SqlParameter("@FIPRESTA", stFIPRESTA)
            Dim o_stFIPRCECA As New SqlParameter("@FIPRCECA", nueva_stFIPRCECA)
            Dim o_stFIPRUSMO As New SqlParameter("@FIPRUSMO", vp_usuario)
            Dim o_daFIPRFEMO As New SqlParameter("@FIPRFEMO", daFIPRFEMO)
            Dim o_stFIPRMAQU As New SqlParameter("@FIPRMAQU", stFIPRMAQU)
            Dim o_boFIPRLITI As New SqlParameter("@FIPRLITI", boFIPRLITI)
            Dim o_stFIPRPOLI As New SqlParameter("@FIPRPOLI", stFIPRPOLI)
            Dim o_inFIPRTIFI As New SqlParameter("@FIPRTIFI", inFIPRTIFI)

            Dim VecParametros(40) As SqlParameter

            VecParametros(0) = o_inFIPRNUFI
            VecParametros(1) = o_inFIPRVIGE
            VecParametros(2) = o_inFIPRTIRE
            VecParametros(3) = o_inFIPRRESO
            VecParametros(4) = o_stFIPRDIRE
            VecParametros(5) = o_stFIPRDESC
            VecParametros(6) = o_boFIPRCONJ
            VecParametros(7) = o_daFIPRFECH
            VecParametros(8) = o_inFIPRNURE
            VecParametros(9) = o_stFIPRDEPA
            VecParametros(10) = o_stFIPRMUNI
            VecParametros(11) = o_stFIPRCORR
            VecParametros(12) = o_stFIPRBARR
            VecParametros(13) = o_stFIPRMANZ
            VecParametros(14) = o_stFIPRPRED
            VecParametros(15) = o_stFIPREDIF
            VecParametros(16) = o_stFIPRUNPR
            VecParametros(17) = o_inFIPRCLSE
            VecParametros(18) = o_inFIPRCASU
            VecParametros(19) = o_stFIPRMUAN
            VecParametros(20) = o_stFIPRCOAN
            VecParametros(21) = o_stFIPRBAAN
            VecParametros(22) = o_stFIPRMAAN
            VecParametros(23) = o_stFIPRPRAN
            VecParametros(24) = o_stFIPREDAN
            VecParametros(25) = o_stFIPRUPAN
            VecParametros(26) = o_inFIPRCSAN
            VecParametros(27) = o_inFIPRCASA
            VecParametros(28) = o_inFIPRCAPR
            VecParametros(29) = o_inFIPRMOAD
            VecParametros(30) = o_inFIPRARTE
            VecParametros(31) = o_stFIPRCOPR
            VecParametros(32) = o_stFIPRCOED
            VecParametros(33) = o_stFIPRESTA
            VecParametros(34) = o_stFIPRCECA
            VecParametros(35) = o_stFIPRUSMO
            VecParametros(36) = o_daFIPRFEMO
            VecParametros(37) = o_stFIPRMAQU
            VecParametros(38) = o_boFIPRLITI
            VecParametros(39) = o_stFIPRPOLI
            VecParametros(40) = o_inFIPRTIFI

            If objenq.ActualizarDb(VecParametros, "Actualizar_X_NUFI_FICHPRED") = True Then
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
    ''' Función que busca el Nro ficha del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_buscar_NRO_FICHA_FICHPRED(ByVal inFIPRNUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFIPRNUFI As New SqlParameter("@FIPRNUFI", inFIPRNUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFIPRNUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_NRO_FICHA_FICHPRED")

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_buscar_ID_FICHPRED(ByVal inFIPRIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFIPRIDRE As New SqlParameter("@FIPRIDRE", inFIPRIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFIPRIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_FICHPRED")

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO del registro para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_FICHPRED(ByVal inFIPRFIPR As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFIPRFIPR As New SqlParameter("FIPRFIPR", inFIPRFIPR)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFIPRFIPR

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_FICHPRED")

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el MUNICIPIO, TIPO RESOLUCION, SECTOR, VIGENCIA Y CÓDIGO DE FICHA PREDIAL
    ''' </summary>
    Public Function fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_TIPORESOLUCION_Y_SECTOR_Y_VIGENCIA_Y_CODIGO_FICHPRED(ByVal stFIPRDEPA As String, _
                                                                              ByVal stFIPRMUNI As String, _
                                                                              ByVal inFIPRTIRE As Integer, _
                                                                              ByVal inFIPRCLSE As Integer, _
                                                                              ByVal inFIPRVIGE As Integer, _
                                                                              ByVal inFIPRRESO As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stFIPRDEPA As New SqlParameter("@FIPRDEPA", stFIPRDEPA)
            Dim o_stFIPRMUNI As New SqlParameter("@FIPRMUNI", stFIPRMUNI)
            Dim o_inFIPRTIRE As New SqlParameter("@FIPRTIRE", inFIPRTIRE)
            Dim o_inFIPRCLSE As New SqlParameter("@FIPRCLSE", inFIPRCLSE)
            Dim o_inFIPRVIGE As New SqlParameter("@FIPRVIGE", inFIPRVIGE)
            Dim o_inFIPRRESO As New SqlParameter("@FIPRRESO", inFIPRRESO)

            Dim VecParametros(5) As SqlParameter

            VecParametros(0) = o_stFIPRDEPA
            VecParametros(1) = o_stFIPRMUNI
            VecParametros(2) = o_inFIPRTIRE
            VecParametros(3) = o_inFIPRCLSE
            VecParametros(4) = o_inFIPRVIGE
            VecParametros(5) = o_inFIPRRESO

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_TIPORESOLUCION_Y_SECTOR_Y_VIGENCIA_Y_CODIGO_FICHPRED")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la FICHA PREDIAL CON LOS PARAMETROS  DEPARTAMENT, MUNICIPIO, TIPO RESOLUCION, SECTOR, 
    ''' VIGENCIA Y CÓDIGO DE FICHA PREDIAL.
    ''' para llenar el datagridview
    ''' </summary>
    Public Function fun_Consultar_FICHA_PREDIAL_X_RESOLUCION(ByVal stFIPRDEPA As String, _
                                                                              ByVal stFIPRMUNI As String, _
                                                                              ByVal inFIPRTIRE As Integer, _
                                                                              ByVal inFIPRCLSE As Integer, _
                                                                              ByVal inFIPRVIGE As Integer, _
                                                                              ByVal inFIPRRESO As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stFIPRDEPA As New SqlParameter("@FIPRDEPA", stFIPRDEPA)
            Dim o_stFIPRMUNI As New SqlParameter("@FIPRMUNI", stFIPRMUNI)
            Dim o_inFIPRTIRE As New SqlParameter("@FIPRTIRE", inFIPRTIRE)
            Dim o_inFIPRCLSE As New SqlParameter("@FIPRCLSE", inFIPRCLSE)
            Dim o_inFIPRVIGE As New SqlParameter("@FIPRVIGE", inFIPRVIGE)
            Dim o_inFIPRRESO As New SqlParameter("@FIPRRESO", inFIPRRESO)

            Dim VecParametros(5) As SqlParameter

            VecParametros(0) = o_stFIPRDEPA
            VecParametros(1) = o_stFIPRMUNI
            VecParametros(2) = o_inFIPRTIRE
            VecParametros(3) = o_inFIPRCLSE
            VecParametros(4) = o_inFIPRVIGE
            VecParametros(5) = o_inFIPRRESO

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FICHA_PREDIAL_X_RESOLUCION")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la FICHA PREDIAL mandando el parametro de ficha predial
    ''' para consultar una sola ficha.
    ''' </summary>
    Public Function fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(ByVal inFIPRNUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFIPRNUFI As New SqlParameter("@FIPRNUFI", inFIPRNUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFIPRNUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el EL NUMERO DE REGISTRO DE FICHA PREDIAL MAXIMO de acuerdo
    ''' a la resolución que se encuentre la ficha predial.
    ''' </summary>
    Public Function fun_Buscar_NRO_REGISTRO_FICHA_PREDIAL_X_DEPARTAMENTO_Y_MUNICIPIO_Y_TIPORESOLUCION_Y_SECTOR_Y_VIGENCIA_Y_CODIGO_FICHPRED(ByVal stFIPRDEPA As String, _
                                                                              ByVal stFIPRMUNI As String, _
                                                                              ByVal inFIPRTIRE As Integer, _
                                                                              ByVal inFIPRCLSE As Integer, _
                                                                              ByVal inFIPRVIGE As Integer, _
                                                                              ByVal inFIPRRESO As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stFIPRDEPA As New SqlParameter("@FIPRDEPA", stFIPRDEPA)
            Dim o_stFIPRMUNI As New SqlParameter("@FIPRMUNI", stFIPRMUNI)
            Dim o_inFIPRTIRE As New SqlParameter("@FIPRTIRE", inFIPRTIRE)
            Dim o_inFIPRCLSE As New SqlParameter("@FIPRCLSE", inFIPRCLSE)
            Dim o_inFIPRVIGE As New SqlParameter("@FIPRVIGE", inFIPRVIGE)
            Dim o_inFIPRRESO As New SqlParameter("@FIPRRESO", inFIPRRESO)

            Dim VecParametros(5) As SqlParameter

            VecParametros(0) = o_stFIPRDEPA
            VecParametros(1) = o_stFIPRMUNI
            VecParametros(2) = o_inFIPRTIRE
            VecParametros(3) = o_inFIPRCLSE
            VecParametros(4) = o_inFIPRVIGE
            VecParametros(5) = o_inFIPRRESO

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_TIPORESOLUCION_Y_SECTOR_Y_VIGENCIA_Y_CODIGO_FICHPRED")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que buscar el predio por medio de la cedula catastral.
    ''' </summary>
    Public Function fun_Buscar_CEDULA_CATASTRAL_FICHPRED(ByVal stFIPRMUNI As String, _
                                                        ByVal stFIPRCORR As String, _
                                                        ByVal stFIPRBARR As String, _
                                                        ByVal stFIPRMANZ As String, _
                                                        ByVal stFIPRPRED As String, _
                                                        ByVal inFIPRCLSE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery


            Dim o_stFIPRMUNI As New SqlParameter("@FIPRMUNI", stFIPRMUNI)
            Dim o_stFIPRCORR As New SqlParameter("@FIPRCORR", stFIPRCORR)
            Dim o_stFIPRBARR As New SqlParameter("@FIPRBARR", stFIPRBARR)
            Dim o_stFIPRMANZ As New SqlParameter("@FIPRMANZ", stFIPRMANZ)
            Dim o_stFIPRPRED As New SqlParameter("@FIPRPRED", stFIPRPRED)
            Dim o_inFIPRCLSE As New SqlParameter("@FIPRCLSE", inFIPRCLSE)

            Dim VecParametros(5) As SqlParameter

            VecParametros(0) = o_stFIPRMUNI
            VecParametros(1) = o_stFIPRCORR
            VecParametros(2) = o_stFIPRBARR
            VecParametros(3) = o_stFIPRMANZ
            VecParametros(4) = o_stFIPRPRED
            VecParametros(5) = o_inFIPRCLSE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_CEDULA_CATASTRAL_FICHPRED")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que buscar el predio por medio de la cedula catastral.
    ''' </summary>
    Public Function fun_Buscar_CEDULA_CATASTRAL_FICHPRED(ByVal stFIPRMUNI As String, _
                                                        ByVal stFIPRCORR As String, _
                                                        ByVal stFIPRBARR As String, _
                                                        ByVal stFIPRMANZ As String, _
                                                        ByVal stFIPRPRED As String, _
                                                        ByVal inFIPRCLSE As Integer, _
                                                        ByVal inFIPRTIFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery


            Dim o_stFIPRMUNI As New SqlParameter("@FIPRMUNI", stFIPRMUNI)
            Dim o_stFIPRCORR As New SqlParameter("@FIPRCORR", stFIPRCORR)
            Dim o_stFIPRBARR As New SqlParameter("@FIPRBARR", stFIPRBARR)
            Dim o_stFIPRMANZ As New SqlParameter("@FIPRMANZ", stFIPRMANZ)
            Dim o_stFIPRPRED As New SqlParameter("@FIPRPRED", stFIPRPRED)
            Dim o_inFIPRCLSE As New SqlParameter("@FIPRCLSE", inFIPRCLSE)
            Dim o_inFIPRTIFI As New SqlParameter("@FIPRTIFI", inFIPRTIFI)

            Dim VecParametros(6) As SqlParameter

            VecParametros(0) = o_stFIPRMUNI
            VecParametros(1) = o_stFIPRCORR
            VecParametros(2) = o_stFIPRBARR
            VecParametros(3) = o_stFIPRMANZ
            VecParametros(4) = o_stFIPRPRED
            VecParametros(5) = o_inFIPRCLSE
            VecParametros(6) = o_inFIPRTIFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_CEDULA_CATASTRAL_X_FIPRTIFI_FICHPRED")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function


    ''' <summary>
    ''' Función que busca el predio por medio de la dirección.
    ''' </summary>
    Public Function fun_Buscar_DIRECCION_FICHPRED(ByVal stFIPRDIRE As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery


            Dim o_stFIPRDIRE As New SqlParameter("@FIPRDIRE", stFIPRDIRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stFIPRDIRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_DIRECCION_FICHPRED")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función actualiza las observación de la fiocha predial
    ''' </summary>
    Public Function fun_actualizar_OBSERVACION_FICHPRED(ByVal inFIPRNUFI As Integer, _
                                                        ByVal stFIPROBSE As String) As Boolean

        '*** INSTANCIA QUE IDENTIFICA EL NOMBRE DE LA MAQUINA ***
        Dim MyIdentity As WindowsIdentity = WindowsIdentity.GetCurrent()
        Dim MyPrincipal As New WindowsPrincipal(MyIdentity)

        Dim stFIPRMAQU As String = MyPrincipal.Identity.Name

        ' *** INSTANCIA LA FECHA Y HORA ***
        Dim dateNow As DateTime = DateTime.Now

        Dim daFIPRFEMO As Date = DateTime.Now.ToString()    'Fecha y hora

        Try
            Dim objenq As New cExecuteNonQuery


            Dim o_inFIPRNUFI As New SqlParameter("@FIPRNUFI", inFIPRNUFI)
            Dim o_stFIPRUSMO As New SqlParameter("@FIPRUSMO", vp_usuario)
            Dim o_daFIPRFEMO As New SqlParameter("@FIPRFEMO", daFIPRFEMO)
            Dim o_stFIPRMAQU As New SqlParameter("@FIPRMAQU", stFIPRMAQU)
            Dim o_stFIPROBSE As New SqlParameter("@FIPROBSE", stFIPROBSE)

            Dim VecParametros(4) As SqlParameter

            VecParametros(0) = o_inFIPRNUFI
            VecParametros(1) = o_stFIPRUSMO
            VecParametros(2) = o_daFIPRFEMO
            VecParametros(3) = o_stFIPRMAQU
            VecParametros(4) = o_stFIPROBSE

            objenq.ActualizarDb(VecParametros, "actualizar_OBSERVACION_FICHPRED")

            Return True

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function

    ''' <summary>
    ''' Función actualiza las observación de la fiocha predial
    ''' </summary>
    Public Function fun_actualizar_IMAGEN_FICHPRED(ByVal inFIPRNUFI As Integer, _
                                                        ByVal stFIPRRUIM As String) As Boolean

        '*** INSTANCIA QUE IDENTIFICA EL NOMBRE DE LA MAQUINA ***
        Dim MyIdentity As WindowsIdentity = WindowsIdentity.GetCurrent()
        Dim MyPrincipal As New WindowsPrincipal(MyIdentity)

        Dim stFIPRMAQU As String = MyPrincipal.Identity.Name

        ' *** INSTANCIA LA FECHA Y HORA ***
        Dim dateNow As DateTime = DateTime.Now

        Dim daFIPRFEMO As Date = DateTime.Now.ToString()    'Fecha y hora

        Try
            Dim objenq As New cExecuteNonQuery


            Dim o_inFIPRNUFI As New SqlParameter("@FIPRNUFI", inFIPRNUFI)
            Dim o_stFIPRUSMO As New SqlParameter("@FIPRUSMO", vp_usuario)
            Dim o_daFIPRFEMO As New SqlParameter("@FIPRFEMO", daFIPRFEMO)
            Dim o_stFIPRMAQU As New SqlParameter("@FIPRMAQU", stFIPRMAQU)
            Dim o_stFIPRRUIM As New SqlParameter("@FIPRRUIM", stFIPRRUIM)

            Dim VecParametros(4) As SqlParameter

            VecParametros(0) = o_inFIPRNUFI
            VecParametros(1) = o_stFIPRUSMO
            VecParametros(2) = o_daFIPRFEMO
            VecParametros(3) = o_stFIPRMAQU
            VecParametros(4) = o_stFIPRRUIM

            objenq.ActualizarDb(VecParametros, "actualizar_IMAGEN_FICHPRED")

            Return True

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function

    ''' <summary>
    ''' Función que busca la FICHA PREDIAL X REGISTRO
    ''' </summary>
    Public Function fun_Consultar_FICHA_PREDIAL_X_REGISTRO(ByVal stMATRDEPA As String, _
                                                           ByVal stMATRMUNI As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stMATRDEPA As New SqlParameter("@MATRDEPA", stMATRDEPA)
            Dim o_stMATRMUNI As New SqlParameter("@MATRMUNI", stMATRMUNI)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_stMATRDEPA
            VecParametros(1) = o_stMATRMUNI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FICHA_PREDIAL_X_REGISTRO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la FICHA PREDIAL X PROPIETARIO
    ''' </summary>
    Public Function fun_Consultar_FICHA_PREDIAL_X_PROPIETARIO(ByVal stFIPRDEPA As String, _
                                                          ByVal stFIPRMUNI As String, _
                                                          ByVal inFIPRCLSE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stFIPRDEPA As New SqlParameter("@FIPRDEPA", stFIPRDEPA)
            Dim o_stFIPRMUNI As New SqlParameter("@FIPRMUNI", stFIPRMUNI)
            Dim o_inFIPRCLSE As New SqlParameter("@FIPRCLSE", inFIPRCLSE)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_stFIPRDEPA
            VecParametros(1) = o_stFIPRMUNI
            VecParametros(2) = o_inFIPRCLSE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FICHA_PREDIAL_X_PROPIETARIO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina las ficha prediales
    ''' </summary>
    Public Function fun_Eliminar_DB_FICHA_PREDIAL(ByVal stFIPRMUNI As String, ByVal inFIPRCLSE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "FICHPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FIPRMUNI = '" & CStr(Trim(stFIPRMUNI)) & "' and "
            stConsultaSQL += "FIPRCLSE = '" & CInt(inFIPRCLSE) & "' and "
            stConsultaSQL += "FIPRTIFI IN('0') "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_DB_FICHA_PREDIAL")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina las ficha prediales
    ''' </summary>
    Public Function fun_Eliminar_DB_FICHA_RESUMEN(ByVal stFIPRMUNI As String, ByVal inFIPRCLSE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "FICHPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FIPRMUNI = '" & CStr(Trim(stFIPRMUNI)) & "' and "
            stConsultaSQL += "FIPRCLSE = '" & CInt(inFIPRCLSE) & "' and "
            stConsultaSQL += "FIPRTIFI IN('1','2') "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_DB_FICHA_RESUMEN")
        End Try

    End Function

    ''' <summary>
    ''' Función que consulta las ficha prediales
    ''' </summary>
    Public Function fun_Consultar_FICHA_PREDIAL_x_CEDULA(ByVal stFIPRMUNI As String, _
                                                         ByVal inFIPRCLSE As Integer, _
                                                         ByVal stFIPRCORR As String, _
                                                         ByVal stFIPRBARR As String, _
                                                         ByVal stFIPRMANZ As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FIPRMUNI, "
            stConsultaSQL += "FIPRCLSE, "
            stConsultaSQL += "FIPRCORR, "
            stConsultaSQL += "FIPRBARR, "
            stConsultaSQL += "FIPRMANZ, "
            stConsultaSQL += "FIPRPRED "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FICHPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FIPRMUNI = '" & CStr(Trim(stFIPRMUNI)) & "' and "
            stConsultaSQL += "FIPRCLSE = '" & CInt(inFIPRCLSE) & "' and "
            stConsultaSQL += "FIPRCORR = '" & CStr(Trim(stFIPRCORR)) & "' and "
            stConsultaSQL += "FIPRBARR = '" & CStr(Trim(stFIPRBARR)) & "' and "
            stConsultaSQL += "FIPRMANZ = '" & CStr(Trim(stFIPRMANZ)) & "' and "

            stConsultaSQL += "FIPRTIFI = 0 and "
            stConsultaSQL += "FIPRESTA = 'ac' "

            stConsultaSQL += "GROUP BY "
            stConsultaSQL += "FIPRCLSE, FIPRMUNI, FIPRCORR, FIPRBARR, FIPRMANZ, FIPRPRED "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FIPRCLSE, FIPRMUNI, FIPRCORR, FIPRBARR, FIPRMANZ, FIPRPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description & " " & "fun_Consultar_FICHA_PREDIAL_x_CEDULA")
        End Try

    End Function

    ''' <summary>
    ''' Función que consulta las ficha prediales
    ''' </summary>
    Public Function fun_Consultar_FICHA_PREDIAL_x_CEDULA(ByVal stFIPRMUNI As String, _
                                                         ByVal inFIPRCLSE As Integer, _
                                                         ByVal stFIPRCORR As String, _
                                                         ByVal stFIPRBARR As String, _
                                                         ByVal stFIPRMANZ As String, _
                                                         ByVal stFIPRPRED As String, _
                                                         ByVal inFIPRTIFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT * "
            stConsultaSQL += "FROM "
            stConsultaSQL += "FICHPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FIPRMUNI = '" & CStr(Trim(stFIPRMUNI)) & "' and "
            stConsultaSQL += "FIPRCLSE = '" & CInt(inFIPRCLSE) & "' and "
            stConsultaSQL += "FIPRCORR = '" & CStr(Trim(stFIPRCORR)) & "' and "
            stConsultaSQL += "FIPRBARR = '" & CStr(Trim(stFIPRBARR)) & "' and "
            stConsultaSQL += "FIPRMANZ = '" & CStr(Trim(stFIPRMANZ)) & "' and "
            stConsultaSQL += "FIPRPRED = '" & CStr(Trim(stFIPRPRED)) & "' and "
            stConsultaSQL += "FIPRTIFI = '" & CInt(inFIPRTIFI) & "' and "

            stConsultaSQL += "FIPRESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FIPRCLSE, FIPRMUNI, FIPRCORR, FIPRBARR, FIPRMANZ, FIPRPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description & " " & "fun_Consultar_FICHA_PREDIAL_x_CEDULA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina las ficha prediales
    ''' </summary>
    Public Function fun_Consultar_FICHA_PREDIAL_x_CEDULA(ByVal stFIPRMUNI As String, _
                                                         ByVal inFIPRCLSE As Integer, _
                                                         ByVal stFIPRCORR As String, _
                                                         ByVal stFIPRBARR As String, _
                                                         ByVal stFIPRMANZ As String, _
                                                         ByVal stFIPRPRED As String, _
                                                         ByVal stFIPREDIF As String, _
                                                         ByVal stFIPRUNPR As String, _
                                                         ByVal inFIPRTIFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT * "
            stConsultaSQL += "FROM "
            stConsultaSQL += "FICHPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FIPRMUNI = '" & CStr(Trim(stFIPRMUNI)) & "' and "
            stConsultaSQL += "FIPRCLSE = '" & CInt(inFIPRCLSE) & "' and "
            stConsultaSQL += "FIPRCORR = '" & CStr(Trim(stFIPRCORR)) & "' and "
            stConsultaSQL += "FIPRBARR = '" & CStr(Trim(stFIPRBARR)) & "' and "
            stConsultaSQL += "FIPRMANZ = '" & CStr(Trim(stFIPRMANZ)) & "' and "
            stConsultaSQL += "FIPRPRED = '" & CStr(Trim(stFIPRPRED)) & "' and "
            stConsultaSQL += "FIPREDIF = '" & CStr(Trim(stFIPREDIF)) & "' and "
            stConsultaSQL += "FIPRUNPR = '" & CStr(Trim(stFIPRUNPR)) & "' and "
            stConsultaSQL += "FIPRTIFI = '" & CInt(inFIPRTIFI) & "' and "
            stConsultaSQL += "FIPRESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FIPRCLSE, FIPRMUNI, FIPRCORR, FIPRBARR, FIPRMANZ, FIPRPRED "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description & " " & "fun_Consultar_FICHA_PREDIAL_x_CEDULA")
        End Try

    End Function
    ''' <summary>
    ''' Función que Elimina las ficha prediales
    ''' </summary>
    Public Function fun_Consultar_FICHA_PREDIAL_x_CEDULA(ByVal stFIPRMUNI As String, _
                                                         ByVal inFIPRCLSE As Integer, _
                                                         ByVal stFIPRCORR As String, _
                                                         ByVal stFIPRBARR As String, _
                                                         ByVal stFIPRMANZ As String, _
                                                         ByVal stFIPRPRED As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT * "
            stConsultaSQL += "FROM "
            stConsultaSQL += "FICHPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FIPRMUNI = '" & CStr(Trim(stFIPRMUNI)) & "' and "
            stConsultaSQL += "FIPRCLSE = '" & CInt(inFIPRCLSE) & "' and "
            stConsultaSQL += "FIPRCORR = '" & CStr(Trim(stFIPRCORR)) & "' and "
            stConsultaSQL += "FIPRBARR = '" & CStr(Trim(stFIPRBARR)) & "' and "
            stConsultaSQL += "FIPRMANZ = '" & CStr(Trim(stFIPRMANZ)) & "' and "
            stConsultaSQL += "FIPRPRED = '" & CStr(Trim(stFIPRPRED)) & "' and "

            stConsultaSQL += "FIPRESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FIPRCLSE, FIPRMUNI, FIPRCORR, FIPRBARR, FIPRMANZ, FIPRPRED, FIPREDIF, FIPRUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description & " " & "fun_Consultar_FICHA_PREDIAL_x_CEDULA")
        End Try

    End Function

   ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_FICHPRED_X_FIPRCOED(ByVal inFIPRNUFI As Integer, _
                                                       ByVal stFIPRCOED As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "FICHPRED "

            stConsultaSQL += "SET "
            stConsultaSQL += "FIPRCOED = '" & CStr(Trim(stFIPRCOED)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FIPRNUFI = '" & CInt(inFIPRNUFI) & "'  "

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
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_DIRE_COED_X_FICHPRED(ByVal inFIPRNUFI As Integer, _
                                                        ByVal stFIPRDIRE As String, _
                                                        ByVal stFIPRCOED As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "FICHPRED "

            stConsultaSQL += "SET "
            stConsultaSQL += "FIPRDIRE = '" & CStr(Trim(stFIPRDIRE)) & "', "
            stConsultaSQL += "FIPRCOED = '" & CStr(Trim(stFIPRCOED)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FIPRNUFI = '" & CInt(inFIPRNUFI) & "' "

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
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_FICHPRED_X_FIPRARTE(ByVal inFIPRNUFI As Integer, _
                                                       ByVal loFIPRARTE As Long) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "FICHPRED "

            stConsultaSQL += "SET "
            stConsultaSQL += "FIPRARTE = '" & CLng(loFIPRARTE) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FIPRNUFI = '" & CInt(inFIPRNUFI) & "'  "

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

End Class
