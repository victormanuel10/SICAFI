Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_VALIFIPR

    '==============================
    ' *** VALIDAR FICHA PREDIAL ***
    '==============================

    ''' <summary>
    ''' Procedimiento que consultar las tablas de ficha predial
    ''' </summary>
    Public Function fun_Consultar_TABLAS_FICHA_PREDIAL(ByVal inFPINNUFI As Integer) As DataSet

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPINNUFI As New SqlParameter("@FPINNUFI", inFPINNUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPINNUFI

            Dim ds As New DataSet
            ds = objeq.Consultarset(VecParametros, "Consultar_TABLAS_FICHA_PREDIAL")

            Return ds

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Procedimiento que consultar las inconsistencias por numero de ficha predial
    ''' </summary>
    Public Function fun_Consultar_INCONSISTENCIA_X_FICHA_PREDIAL(ByVal stFPINNUFI As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stFPINNUFI As New SqlParameter("@FPINNUFI", stFPINNUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stFPINNUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_INCONSISTENCIA_X_FICHA_PREDIAL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Procedimiento que consultar las inconsistencias por resolucion
    ''' </summary>
    Public Function fun_Consultar_INCONSISTENCIA_X_RESOLUCION(ByVal stFPINRESO As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stFPINRESO As New SqlParameter("@FPINRESO", stFPINRESO)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stFPINRESO

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_INCONSISTENCIA_X_RESOLUCION")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_FIPRINCO(ByVal stFPINNUFI As String, _
                                               ByVal stFPINCODI As String, _
                                               ByVal stFPINDESC As String, _
                                               ByVal stFPINMUNI As String, _
                                               ByVal stFPINCORR As String, _
                                               ByVal stFPINBARR As String, _
                                               ByVal stFPINMANZ As String, _
                                               ByVal stFPINPRED As String, _
                                               ByVal stFPINEDIF As String, _
                                               ByVal stFPINUNPR As String, _
                                               ByVal stFPINCLSE As String, _
                                               ByVal stFPINRESO As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stFPINNUFI As New SqlParameter("@FPINNUFI", stFPINNUFI)
            Dim o_stFPINCODI As New SqlParameter("@FPINCODI", stFPINCODI)
            Dim o_stFPINDESC As New SqlParameter("@FPINDESC", stFPINDESC)
            Dim o_stFPINMUNI As New SqlParameter("@FPINMUNI", stFPINMUNI)
            Dim o_stFPINCORR As New SqlParameter("@FPINCORR", stFPINCORR)
            Dim o_stFPINBARR As New SqlParameter("@FPINBARR", stFPINBARR)
            Dim o_stFPINMANZ As New SqlParameter("@FPINMANZ", stFPINMANZ)
            Dim o_stFPINPRED As New SqlParameter("@FPINPRED", stFPINPRED)
            Dim o_stFPINEDIF As New SqlParameter("@FPINEDIF", stFPINEDIF)
            Dim o_stFPINUNPR As New SqlParameter("@FPINUNPR", stFPINUNPR)
            Dim o_stFPINCLSE As New SqlParameter("@FPINCLSE", stFPINCLSE)
            Dim o_stFPINRESO As New SqlParameter("@FPINRESO", stFPINRESO)

            Dim VecParametros(11) As SqlParameter

            VecParametros(0) = o_stFPINNUFI
            VecParametros(1) = o_stFPINCODI
            VecParametros(2) = o_stFPINDESC
            VecParametros(3) = o_stFPINMUNI
            VecParametros(4) = o_stFPINCORR
            VecParametros(5) = o_stFPINBARR
            VecParametros(6) = o_stFPINMANZ
            VecParametros(7) = o_stFPINPRED
            VecParametros(8) = o_stFPINEDIF
            VecParametros(9) = o_stFPINUNPR
            VecParametros(10) = o_stFPINCLSE
            VecParametros(11) = o_stFPINRESO

            objenq.ActualizarDb(VecParametros, "Insertar_FIPRINCO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que elimina el registro por numero de ficha 
    ''' </summary>
    Public Function fun_Eliminar_FIPRINCO(ByVal stFPINNUFI As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stFPINNUFI As New SqlParameter("@FPINNUFI", stFPINNUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stFPINNUFI

            objenq.ActualizarDb(VecParametros, "Eliminar_FIPRINCO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que elimina el registro por numero de resolucion
    ''' </summary>
    Public Function fun_Eliminar_FIPRINCO_X_RESOLUCION(ByVal stFPINRESO As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stFPINRESO As New SqlParameter("@FPINRESO", stFPINRESO)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stFPINRESO

            objenq.ActualizarDb(VecParametros, "Eliminar_FIPRINCO_X_RESOLUCION")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Validaciones por sobrecarga
    ''' </summary>
    Public Function fun_Consultar_FIPRCOED_X_FICHA_PREDIAL_INCO_112(ByVal stFIPRCLSE As String, _
                                                                    ByVal stFIPRCAPR As String, _
                                                                    ByVal stFIPRMUNI As String, _
                                                                    ByVal stFIPRCORR As String, _
                                                                    ByVal stFIPRBARR As String, _
                                                                    ByVal stFIPRMANZ As String, _
                                                                    ByVal stFIPRPRED As String, _
                                                                    ByVal stFIPREDIF As String, _
                                                                    ByVal stFIPRESTA As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stFIPRCLSE As New SqlParameter("@FIPRCLSE", stFIPRCLSE)
            Dim o_stFIPRCAPR As New SqlParameter("@FIPRCAPR", stFIPRCAPR)
            Dim o_stFIPRMUNI As New SqlParameter("@FIPRMUNI", stFIPRMUNI)
            Dim o_stFIPRCORR As New SqlParameter("@FIPRCORR", stFIPRCORR)
            Dim o_stFIPRBARR As New SqlParameter("@FIPRBARR", stFIPRBARR)
            Dim o_stFIPRMANZ As New SqlParameter("@FIPRMANZ", stFIPRMANZ)
            Dim o_stFIPRPRED As New SqlParameter("@FIPRPRED", stFIPRPRED)
            Dim o_stFIPREDIF As New SqlParameter("@FIPREDIF", stFIPREDIF)
            Dim o_stFIPRESTA As New SqlParameter("@FIPRESTA", stFIPRESTA)

            Dim VecParametros(8) As SqlParameter

            VecParametros(0) = o_stFIPRCLSE
            VecParametros(1) = o_stFIPRCAPR
            VecParametros(2) = o_stFIPRMUNI
            VecParametros(3) = o_stFIPRCORR
            VecParametros(4) = o_stFIPRBARR
            VecParametros(5) = o_stFIPRMANZ
            VecParametros(6) = o_stFIPRPRED
            VecParametros(7) = o_stFIPREDIF
            VecParametros(8) = o_stFIPRESTA


            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FIPRCOED_X_FICHA_PREDIAL_INCO_112")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Public Function fun_Consultar_FIPRCOPR_X_FICHA_PREDIAL_INCO_113(ByVal stFIPRCLSE As String, _
                                                                   ByVal stFIPRCAPR As String, _
                                                                   ByVal stFIPRMUNI As String, _
                                                                   ByVal stFIPRCORR As String, _
                                                                   ByVal stFIPRBARR As String, _
                                                                   ByVal stFIPRMANZ As String, _
                                                                   ByVal stFIPRPRED As String, _
                                                                   ByVal stFIPRESTA As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stFIPRCLSE As New SqlParameter("@FIPRCLSE", stFIPRCLSE)
            Dim o_stFIPRCAPR As New SqlParameter("@FIPRCAPR", stFIPRCAPR)
            Dim o_stFIPRMUNI As New SqlParameter("@FIPRMUNI", stFIPRMUNI)
            Dim o_stFIPRCORR As New SqlParameter("@FIPRCORR", stFIPRCORR)
            Dim o_stFIPRBARR As New SqlParameter("@FIPRBARR", stFIPRBARR)
            Dim o_stFIPRMANZ As New SqlParameter("@FIPRMANZ", stFIPRMANZ)
            Dim o_stFIPRPRED As New SqlParameter("@FIPRPRED", stFIPRPRED)
            Dim o_stFIPRESTA As New SqlParameter("@FIPRESTA", stFIPRESTA)

            Dim VecParametros(7) As SqlParameter

            VecParametros(0) = o_stFIPRCLSE
            VecParametros(1) = o_stFIPRCAPR
            VecParametros(2) = o_stFIPRMUNI
            VecParametros(3) = o_stFIPRCORR
            VecParametros(4) = o_stFIPRBARR
            VecParametros(5) = o_stFIPRMANZ
            VecParametros(6) = o_stFIPRPRED
            VecParametros(7) = o_stFIPRESTA


            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FIPRCOPR_X_FICHA_PREDIAL_INCO_113")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Public Function fun_Consultar_FICHA_RESUMEN_2_INCO_123(ByVal stFIPRCLSE As String, _
                                                                  ByVal stFIPRTIFI As String, _
                                                                  ByVal stFIPRMUNI As String, _
                                                                  ByVal stFIPRCORR As String, _
                                                                  ByVal stFIPRBARR As String, _
                                                                  ByVal stFIPRMANZ As String, _
                                                                  ByVal stFIPRPRED As String, _
                                                                  ByVal stFIPREDIF As String, _
                                                                  ByVal stFIPRESTA As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stFIPRCLSE As New SqlParameter("@FIPRCLSE", stFIPRCLSE)
            Dim o_stFIPRTIFI As New SqlParameter("@FIPRTIFI", stFIPRTIFI)
            Dim o_stFIPRMUNI As New SqlParameter("@FIPRMUNI", stFIPRMUNI)
            Dim o_stFIPRCORR As New SqlParameter("@FIPRCORR", stFIPRCORR)
            Dim o_stFIPRBARR As New SqlParameter("@FIPRBARR", stFIPRBARR)
            Dim o_stFIPRMANZ As New SqlParameter("@FIPRMANZ", stFIPRMANZ)
            Dim o_stFIPRPRED As New SqlParameter("@FIPRPRED", stFIPRPRED)
            Dim o_stFIPREDIF As New SqlParameter("@FIPREDIF", stFIPREDIF)
            Dim o_stFIPRESTA As New SqlParameter("@FIPRESTA", stFIPRESTA)

            Dim VecParametros(8) As SqlParameter

            VecParametros(0) = o_stFIPRCLSE
            VecParametros(1) = o_stFIPRTIFI
            VecParametros(2) = o_stFIPRMUNI
            VecParametros(3) = o_stFIPRCORR
            VecParametros(4) = o_stFIPRBARR
            VecParametros(5) = o_stFIPRMANZ
            VecParametros(6) = o_stFIPRPRED
            VecParametros(7) = o_stFIPREDIF
            VecParametros(8) = o_stFIPRESTA


            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FICHA_RESUMEN_2_INCO_123")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Public Function fun_Consultar_FICHA_RESUMEN_1_INCO_124(ByVal stFIPRCLSE As String, _
                                                                 ByVal stFIPRTIFI As String, _
                                                                 ByVal stFIPRMUNI As String, _
                                                                 ByVal stFIPRCORR As String, _
                                                                 ByVal stFIPRBARR As String, _
                                                                 ByVal stFIPRMANZ As String, _
                                                                 ByVal stFIPRPRED As String, _
                                                                 ByVal stFIPREDIF As String, _
                                                                 ByVal stFIPRESTA As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stFIPRCLSE As New SqlParameter("@FIPRCLSE", stFIPRCLSE)
            Dim o_stFIPRTIFI As New SqlParameter("@FIPRTIFI", stFIPRTIFI)
            Dim o_stFIPRMUNI As New SqlParameter("@FIPRMUNI", stFIPRMUNI)
            Dim o_stFIPRCORR As New SqlParameter("@FIPRCORR", stFIPRCORR)
            Dim o_stFIPRBARR As New SqlParameter("@FIPRBARR", stFIPRBARR)
            Dim o_stFIPRMANZ As New SqlParameter("@FIPRMANZ", stFIPRMANZ)
            Dim o_stFIPRPRED As New SqlParameter("@FIPRPRED", stFIPRPRED)
            Dim o_stFIPREDIF As New SqlParameter("@FIPREDIF", stFIPREDIF)
            Dim o_stFIPRESTA As New SqlParameter("@FIPRESTA", stFIPRESTA)

            Dim VecParametros(8) As SqlParameter

            VecParametros(0) = o_stFIPRCLSE
            VecParametros(1) = o_stFIPRTIFI
            VecParametros(2) = o_stFIPRMUNI
            VecParametros(3) = o_stFIPRCORR
            VecParametros(4) = o_stFIPRBARR
            VecParametros(5) = o_stFIPRMANZ
            VecParametros(6) = o_stFIPRPRED
            VecParametros(7) = o_stFIPREDIF
            VecParametros(8) = o_stFIPRESTA


            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FICHA_RESUMEN_1_INCO_124")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Public Function fun_Consultar_CEDULA_CATASTRAL_REPETIDA_INCO_140(ByVal stFIPRMUNI As String, _
                                                                     ByVal stFIPRCORR As String, _
                                                                     ByVal stFIPRBARR As String, _
                                                                     ByVal stFIPRMANZ As String, _
                                                                     ByVal stFIPRPRED As String, _
                                                                     ByVal stFIPREDIF As String, _
                                                                     ByVal stFIPRUNPR As String, _
                                                                     ByVal stFIPRCLSE As String, _
                                                                     ByVal stFIPRESTA As String, _
                                                                     ByVal stFIPRTIFI As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stFIPRMUNI As New SqlParameter("@FIPRMUNI", stFIPRMUNI)
            Dim o_stFIPRCORR As New SqlParameter("@FIPRCORR", stFIPRCORR)
            Dim o_stFIPRBARR As New SqlParameter("@FIPRBARR", stFIPRBARR)
            Dim o_stFIPRMANZ As New SqlParameter("@FIPRMANZ", stFIPRMANZ)
            Dim o_stFIPRPRED As New SqlParameter("@FIPRPRED", stFIPRPRED)
            Dim o_stFIPREDIF As New SqlParameter("@FIPREDIF", stFIPREDIF)
            Dim o_stFIPRUNPR As New SqlParameter("@FIPRUNPR", stFIPRUNPR)
            Dim o_stFIPRCLSE As New SqlParameter("@FIPRCLSE", stFIPRCLSE)
            Dim o_stFIPRESTA As New SqlParameter("@FIPRESTA", stFIPRESTA)
            Dim o_stFIPRTIFI As New SqlParameter("@FIPRTIFI", stFIPRTIFI)

            Dim VecParametros(9) As SqlParameter

            VecParametros(0) = o_stFIPRMUNI
            VecParametros(1) = o_stFIPRCORR
            VecParametros(2) = o_stFIPRBARR
            VecParametros(3) = o_stFIPRMANZ
            VecParametros(4) = o_stFIPRPRED
            VecParametros(5) = o_stFIPREDIF
            VecParametros(6) = o_stFIPRUNPR
            VecParametros(7) = o_stFIPRCLSE
            VecParametros(8) = o_stFIPRESTA
            VecParametros(9) = o_stFIPRTIFI



            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_CEDULA_CATASTRAL_REPETIDA_INCO_140")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Public Function fun_Consultar_PORCENTAJE_LITIGIO_INVALIDO_INCO_319(ByVal stFIPRMUNI As String, _
                                                                    ByVal stFIPRCORR As String, _
                                                                    ByVal stFIPRBARR As String, _
                                                                    ByVal stFIPRMANZ As String, _
                                                                    ByVal stFIPRPRED As String, _
                                                                    ByVal stFIPREDIF As String, _
                                                                    ByVal stFIPRUNPR As String, _
                                                                    ByVal stFIPRCLSE As String, _
                                                                    ByVal stFIPRESTA As String, _
                                                                    ByVal stFIPRTIFI As String, _
                                                                    ByVal boFIPRLITI As Boolean) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stFIPRMUNI As New SqlParameter("@FIPRMUNI", stFIPRMUNI)
            Dim o_stFIPRCORR As New SqlParameter("@FIPRCORR", stFIPRCORR)
            Dim o_stFIPRBARR As New SqlParameter("@FIPRBARR", stFIPRBARR)
            Dim o_stFIPRMANZ As New SqlParameter("@FIPRMANZ", stFIPRMANZ)
            Dim o_stFIPRPRED As New SqlParameter("@FIPRPRED", stFIPRPRED)
            Dim o_stFIPREDIF As New SqlParameter("@FIPREDIF", stFIPREDIF)
            Dim o_stFIPRUNPR As New SqlParameter("@FIPRUNPR", stFIPRUNPR)
            Dim o_stFIPRCLSE As New SqlParameter("@FIPRCLSE", stFIPRCLSE)
            Dim o_stFIPRESTA As New SqlParameter("@FIPRESTA", stFIPRESTA)
            Dim o_stFIPRTIFI As New SqlParameter("@FIPRTIFI", stFIPRTIFI)
            Dim o_boFIPRLITI As New SqlParameter("@FIPRLITI", boFIPRLITI)

            Dim VecParametros(10) As SqlParameter

            VecParametros(0) = o_stFIPRMUNI
            VecParametros(1) = o_stFIPRCORR
            VecParametros(2) = o_stFIPRBARR
            VecParametros(3) = o_stFIPRMANZ
            VecParametros(4) = o_stFIPRPRED
            VecParametros(5) = o_stFIPREDIF
            VecParametros(6) = o_stFIPRUNPR
            VecParametros(7) = o_stFIPRCLSE
            VecParametros(8) = o_stFIPRESTA
            VecParametros(9) = o_stFIPRTIFI
            VecParametros(10) = o_boFIPRLITI



            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_PORCENTAJE_LITIGIO_INVALIDO_INCO_319")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Public Function fun_Consultar_PUNTOS_MAYOR_TABLA_CODAZZI_INCO_408(ByVal stFPCODEPA As String, _
                                                                      ByVal stFPCOMUNI As String, _
                                                                      ByVal stFPCOCLCO As String, _
                                                                      ByVal stFPCOTICO As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stFPCODEPA As New SqlParameter("@FPCODEPA", stFPCODEPA)
            Dim o_stFPCOMUNI As New SqlParameter("@FPCOMUNI", stFPCOMUNI)
            Dim o_stFPCOCLCO As New SqlParameter("@FPCOCLCO", stFPCOCLCO)
            Dim o_stFPCOTICO As New SqlParameter("@FPCOTICO", stFPCOTICO)
            
            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_stFPCODEPA
            VecParametros(1) = o_stFPCOMUNI
            VecParametros(2) = o_stFPCOCLCO
            VecParametros(3) = o_stFPCOTICO


            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_PUNTOS_MAYOR_TABLA_CODAZZI_INCO_408")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Procedimiento que consultar las tablas de ficha predial
    ''' </summary>
    Public Function fun_Consultar_NRO_REGISTROS_DE_EXPORTACION(ByVal stRESODEPA As String, _
                                                               ByVal stRESOMUNI As String, _
                                                               ByVal inRESOTIRE As Integer, _
                                                               ByVal inRESOCLSE As Integer, _
                                                               ByVal inRESOVIGE As Integer, _
                                                               ByVal inRESORESO As Integer) As DataSet

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stRESODEPA As New SqlParameter("@RESODEPA", stRESODEPA)
            Dim o_stRESOMUNI As New SqlParameter("@RESOMUNI", stRESOMUNI)
            Dim o_inRESOTIRE As New SqlParameter("@RESOTIRE", inRESOTIRE)
            Dim o_inRESOCLSE As New SqlParameter("@RESOCLSE", inRESOCLSE)
            Dim o_inRESOVIGE As New SqlParameter("@RESOVIGE", inRESOVIGE)
            Dim o_inRESORESO As New SqlParameter("@RESORESO", inRESORESO)

            Dim VecParametros(5) As SqlParameter

            VecParametros(0) = o_stRESODEPA
            VecParametros(1) = o_stRESOMUNI
            VecParametros(2) = o_inRESOTIRE
            VecParametros(3) = o_inRESOCLSE
            VecParametros(4) = o_inRESOVIGE
            VecParametros(5) = o_inRESORESO

            Dim ds As New DataSet
            ds = objeq.Consultarset(VecParametros, "Consultar_NRO_REGISTROS_DE_EXPORTACION")

            Return ds

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Procedimiento que consultar las tablas de ficha predial
    ''' </summary>
    Public Function fun_Consultar_NRO_REGISTROS_DE_EXPORTACION_RESOADMI(ByVal inRESOTIRE As Integer, _
                                                                        ByVal inRESOCLSE As Integer, _
                                                                        ByVal inRESOVIGE As Integer, _
                                                                        ByVal inRESORESO As Integer) As DataSet

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inRESOTIRE As New SqlParameter("@RESOTIRE", inRESOTIRE)
            Dim o_inRESOCLSE As New SqlParameter("@RESOCLSE", inRESOCLSE)
            Dim o_inRESOVIGE As New SqlParameter("@RESOVIGE", inRESOVIGE)
            Dim o_inRESORESO As New SqlParameter("@RESORESO", inRESORESO)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_inRESOTIRE
            VecParametros(1) = o_inRESOCLSE
            VecParametros(2) = o_inRESOVIGE
            VecParametros(3) = o_inRESORESO

            Dim ds As New DataSet
            ds = objeq.Consultarset(VecParametros, "Consultar_NRO_REGISTROS_DE_EXPORTACION_RESOADMI")

            Return ds

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Procedimiento que consultar las tablas de ficha predial
    ''' </summary>
    Public Function fun_Consultar_NRO_REGISTROS_DE_EXPORTACION_FICHA_RESUMEN(ByVal stRESODEPA As String, _
                                                                             ByVal stRESOMUNI As String, _
                                                                             ByVal inRESOTIRE As Integer, _
                                                                             ByVal inRESOCLSE As Integer, _
                                                                             ByVal inRESOVIGE As Integer, _
                                                                             ByVal inRESORESO As Integer) As DataSet

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stRESODEPA As New SqlParameter("@RESODEPA", Trim(stRESODEPA))
            Dim o_stRESOMUNI As New SqlParameter("@RESOMUNI", Trim(stRESOMUNI))
            Dim o_inRESOTIRE As New SqlParameter("@RESOTIRE", inRESOTIRE)
            Dim o_inRESOCLSE As New SqlParameter("@RESOCLSE", inRESOCLSE)
            Dim o_inRESOVIGE As New SqlParameter("@RESOVIGE", inRESOVIGE)
            Dim o_inRESORESO As New SqlParameter("@RESORESO", inRESORESO)

            Dim VecParametros(5) As SqlParameter

            VecParametros(0) = o_stRESODEPA
            VecParametros(1) = o_stRESOMUNI
            VecParametros(2) = o_inRESOTIRE
            VecParametros(3) = o_inRESOCLSE
            VecParametros(4) = o_inRESOVIGE
            VecParametros(5) = o_inRESORESO

            Dim ds As New DataSet
            ds = objeq.Consultarset(VecParametros, "Consultar_NRO_REGISTROS_DE_EXPORTACION_FICHA_RESUMEN")

            Return ds

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Procedimiento que consultar las tablas de ficha predial
    ''' </summary>
    Public Function fun_Consultar_NRO_REGISTROS_DE_EXPORTACION_FICHA_RESUMEN_RESOADMI(ByVal inRESOTIRE As Integer, _
                                                                                      ByVal inRESOCLSE As Integer, _
                                                                                      ByVal inRESOVIGE As Integer, _
                                                                                      ByVal inRESORESO As Integer) As DataSet

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inRESOTIRE As New SqlParameter("@RESOTIRE", inRESOTIRE)
            Dim o_inRESOCLSE As New SqlParameter("@RESOCLSE", inRESOCLSE)
            Dim o_inRESOVIGE As New SqlParameter("@RESOVIGE", inRESOVIGE)
            Dim o_inRESORESO As New SqlParameter("@RESORESO", inRESORESO)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_inRESOTIRE
            VecParametros(1) = o_inRESOCLSE
            VecParametros(2) = o_inRESOVIGE
            VecParametros(3) = o_inRESORESO

            Dim ds As New DataSet
            ds = objeq.Consultarset(VecParametros, "Consultar_NRO_REGISTROS_DE_EXPORTACION_FICHA_RESUMEN_RESOADMI")

            Return ds

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

End Class
