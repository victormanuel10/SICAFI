Imports SYSTEM.Security.Principal
Imports SYSTEM.Security.Permissions
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_FICHRESU

    '===========================
    '*** CLASE FICHA RESUMEN ***
    '===========================

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_FICHRESU(ByVal inFIPRNUFI As Integer, _
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
                                              ByVal boFIPRINCO As Boolean, _
                                              ByVal stFIPRRUIM As String, _
                                              ByVal inFIPRATLO As Integer, _
                                              ByVal inFIPRACLO As Integer, _
                                              ByVal inFIPRAPLO As Integer, _
                                              ByVal inFIPRTOED As Integer, _
                                              ByVal inFIPRUNCO As Integer, _
                                              ByVal inFIPRURPH As Integer, _
                                              ByVal inFIPRAPCA As Integer, _
                                              ByVal inFIPRLOCA As Integer, _
                                              ByVal inFIPRCUUT As Integer, _
                                              ByVal inFIPRGACU As Integer, _
                                              ByVal inFIPRGADE As Integer, _
                                              ByVal inFIPRPISO As Integer) As Boolean


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
            Dim o_stFIPRRUIM As New SqlParameter("@FIPRRUIM", stFIPRRUIM)
            Dim o_inFIPRATLO As New SqlParameter("@FIPRATLO", inFIPRATLO)
            Dim o_inFIPRACLO As New SqlParameter("@FIPRACLO", inFIPRACLO)
            Dim o_inFIPRAPLO As New SqlParameter("@FIPRAPLO", inFIPRAPLO)
            Dim o_inFIPRTOED As New SqlParameter("@FIPRTOED", inFIPRTOED)
            Dim o_inFIPRUNCO As New SqlParameter("@FIPRUNCO", inFIPRUNCO)
            Dim o_inFIPRURPH As New SqlParameter("@FIPRURPH", inFIPRURPH)
            Dim o_inFIPRAPCA As New SqlParameter("@FIPRAPCA", inFIPRAPCA)
            Dim o_inFIPRLOCA As New SqlParameter("@FIPRLOCA", inFIPRLOCA)
            Dim o_inFIPRCUUT As New SqlParameter("@FIPRCUUT", inFIPRCUUT)
            Dim o_inFIPRGACU As New SqlParameter("@FIPRGACU", inFIPRGACU)
            Dim o_inFIPRGADE As New SqlParameter("@FIPRGADE", inFIPRGADE)
            Dim o_inFIPRPISO As New SqlParameter("@FIPRPISO", inFIPRPISO)

            Dim VecParametros(61) As SqlParameter

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
            VecParametros(49) = o_stFIPRRUIM
            VecParametros(50) = o_inFIPRATLO
            VecParametros(51) = o_inFIPRACLO
            VecParametros(52) = o_inFIPRAPLO
            VecParametros(53) = o_inFIPRTOED
            VecParametros(54) = o_inFIPRUNCO
            VecParametros(55) = o_inFIPRURPH
            VecParametros(56) = o_inFIPRAPCA
            VecParametros(57) = o_inFIPRLOCA
            VecParametros(58) = o_inFIPRCUUT
            VecParametros(59) = o_inFIPRGACU
            VecParametros(60) = o_inFIPRGADE
            VecParametros(61) = o_inFIPRPISO

            objenq.ActualizarDb(VecParametros, "insertar_FICHRESU")

            Return True

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica o actualiza el registro.
    ''' </summary>
    Public Function fun_Actualizar_FICHRESU(ByVal inFIPRIDRE As Integer, _
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
                                              ByVal boFIPRINCO As Boolean, _
                                              ByVal stFIPRRUIM As String, _
                                              ByVal inFIPRATLO As Integer, _
                                              ByVal inFIPRACLO As Integer, _
                                              ByVal inFIPRAPLO As Integer, _
                                              ByVal inFIPRTOED As Integer, _
                                              ByVal inFIPRUNCO As Integer, _
                                              ByVal inFIPRURPH As Integer, _
                                              ByVal inFIPRAPCA As Integer, _
                                              ByVal inFIPRLOCA As Integer, _
                                              ByVal inFIPRCUUT As Integer, _
                                              ByVal inFIPRGACU As Integer, _
                                              ByVal inFIPRGADE As Integer, _
                                              ByVal inFIPRPISO As Integer) As Boolean

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
            Dim o_stFIPRRUIM As New SqlParameter("@FIPRRUIM", stFIPRRUIM)
            Dim o_inFIPRATLO As New SqlParameter("@FIPRATLO", inFIPRATLO)
            Dim o_inFIPRACLO As New SqlParameter("@FIPRACLO", inFIPRACLO)
            Dim o_inFIPRAPLO As New SqlParameter("@FIPRAPLO", inFIPRAPLO)
            Dim o_inFIPRTOED As New SqlParameter("@FIPRTOED", inFIPRTOED)
            Dim o_inFIPRUNCO As New SqlParameter("@FIPRUNCO", inFIPRUNCO)
            Dim o_inFIPRURPH As New SqlParameter("@FIPRURPH", inFIPRURPH)
            Dim o_inFIPRAPCA As New SqlParameter("@FIPRAPCA", inFIPRAPCA)
            Dim o_inFIPRLOCA As New SqlParameter("@FIPRLOCA", inFIPRLOCA)
            Dim o_inFIPRCUUT As New SqlParameter("@FIPRCUUT", inFIPRCUUT)
            Dim o_inFIPRGACU As New SqlParameter("@FIPRGACU", inFIPRGACU)
            Dim o_inFIPRGADE As New SqlParameter("@FIPRGADE", inFIPRGADE)
            Dim o_inFIPRPISO As New SqlParameter("@FIPRPISO", inFIPRPISO)

            Dim VecParametros(62) As SqlParameter

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
            VecParametros(50) = o_stFIPRRUIM
            VecParametros(51) = o_inFIPRATLO
            VecParametros(52) = o_inFIPRACLO
            VecParametros(53) = o_inFIPRAPLO
            VecParametros(54) = o_inFIPRTOED
            VecParametros(55) = o_inFIPRUNCO
            VecParametros(56) = o_inFIPRURPH
            VecParametros(57) = o_inFIPRAPCA
            VecParametros(58) = o_inFIPRLOCA
            VecParametros(59) = o_inFIPRCUUT
            VecParametros(60) = o_inFIPRGACU
            VecParametros(61) = o_inFIPRGADE
            VecParametros(62) = o_inFIPRPISO

            objenq.ActualizarDb(VecParametros, "actualizar_FICHRESU")

            Return True

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el Nro ficha del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_buscar_CEDULA_CATASTRAL_FICHRESU(ByVal stFIREMUNI As String, _
                                                          ByVal stFIRECORR As String, _
                                                          ByVal stFIREBARR As String, _
                                                          ByVal stFIREMANZ As String, _
                                                          ByVal stFIREPRED As String, _
                                                          ByVal stFIREEDIF As String, _
                                                          ByVal stFIREUNPR As String, _
                                                          ByVal inFIRECLSE As Integer, _
                                                          ByVal inFIRETIFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stFIREMUNI As New SqlParameter("@FIPRMUNI", stFIREMUNI)
            Dim o_stFIRECORR As New SqlParameter("@FIPRCORR", stFIRECORR)
            Dim o_stFIREBARR As New SqlParameter("@FIPRBARR", stFIREBARR)
            Dim o_stFIREMANZ As New SqlParameter("@FIPRMANZ", stFIREMANZ)
            Dim o_stFIREPRED As New SqlParameter("@FIPRPRED", stFIREPRED)
            Dim o_stFIREEDIF As New SqlParameter("@FIPREDIF", stFIREEDIF)
            Dim o_stFIREUNPR As New SqlParameter("@FIPRUNPR", stFIREUNPR)
            Dim o_inFIRECLSE As New SqlParameter("@FIPRCLSE", inFIRECLSE)
            Dim o_inFIRETIFI As New SqlParameter("@FIPRTIFI", inFIRETIFI)

            Dim VecParametros(8) As SqlParameter

            VecParametros(0) = o_stFIREMUNI
            VecParametros(1) = o_stFIRECORR
            VecParametros(2) = o_stFIREBARR
            VecParametros(3) = o_stFIREMANZ
            VecParametros(4) = o_stFIREPRED
            VecParametros(5) = o_stFIREEDIF
            VecParametros(6) = o_stFIREUNPR
            VecParametros(7) = o_inFIRECLSE
            VecParametros(8) = o_inFIRETIFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CEDULA_CATASTRAL_FICHRESU")

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro por cedula catastral.
    ''' </summary>
    Public Function fun_eliminar_POR_CEDULA_CATASTRAL_FICHRESU(ByVal stFIREMUNI As String, _
                                                          ByVal stFIRECORR As String, _
                                                          ByVal stFIREBARR As String, _
                                                          ByVal stFIREMANZ As String, _
                                                          ByVal stFIREPRED As String, _
                                                          ByVal stFIREEDIF As String, _
                                                          ByVal stFIREUNPR As String, _
                                                          ByVal inFIRECLSE As Integer, _
                                                          ByVal inFIRETIFI As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stFIREMUNI As New SqlParameter("@FIPRMUNI", stFIREMUNI)
            Dim o_stFIRECORR As New SqlParameter("@FIPRCORR", stFIRECORR)
            Dim o_stFIREBARR As New SqlParameter("@FIPRBARR", stFIREBARR)
            Dim o_stFIREMANZ As New SqlParameter("@FIPRMANZ", stFIREMANZ)
            Dim o_stFIREPRED As New SqlParameter("@FIPRPRED", stFIREPRED)
            Dim o_stFIREEDIF As New SqlParameter("@FIPREDIF", stFIREEDIF)
            Dim o_stFIREUNPR As New SqlParameter("@FIPRUNPR", stFIREUNPR)
            Dim o_inFIRECLSE As New SqlParameter("@FIPRCLSE", inFIRECLSE)
            Dim o_inFIRETIFI As New SqlParameter("@FIPRTIFI", inFIRETIFI)

            Dim VecParametros(8) As SqlParameter

            VecParametros(0) = o_stFIREMUNI
            VecParametros(1) = o_stFIRECORR
            VecParametros(2) = o_stFIREBARR
            VecParametros(3) = o_stFIREMANZ
            VecParametros(4) = o_stFIREPRED
            VecParametros(5) = o_stFIREEDIF
            VecParametros(6) = o_stFIREUNPR
            VecParametros(7) = o_inFIRECLSE
            VecParametros(8) = o_inFIRETIFI

            If objenq.ActualizarDb(VecParametros, "eliminar_POR_CEDULA_CATASTRAL_FICHRESU") Then
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
    ''' Función que busca la Nro. de ficha de la ficha resumen con el campo de cedula catastral
    ''' concatenada para ubicar en numero de registro para ser insertada.
    ''' </summary>
    Public Function fun_Consultar_FICHA_RESUMEN_X_CEDULA_CONCATENADA(ByVal stFIPRCECA As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stFIPRCECA As New SqlParameter("@FIPRCECA", stFIPRCECA)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stFIPRCECA

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FICHA_RESUMEN_X_CEDULA_CONCATENADA")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que consulta las ficha prediales
    ''' </summary>
    Public Function fun_Consultar_FICHA_RESUMEN_x_CEDULA(ByVal stFIPRMUNI As String, _
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

End Class
