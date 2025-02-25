Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_FIPRAVAL

    '======================================
    ' *** LIQUIDAR AVALUO FICHA PREDIAL ***
    '======================================

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
    Public Function fun_Consultar_AVALUO_X_FICHA_PREDIAL(ByVal stFPAVNUFI As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stFPAVNUFI As New SqlParameter("@FPAVNUFI", stFPAVNUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stFPAVNUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_AVALUO_X_FICHA_PREDIAL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_FIPRAVAL(ByVal inFPAVNUFI As Integer, _
                                               ByVal loFPAVATPR As Long, _
                                               ByVal loFPAVATCO As Long, _
                                               ByVal stFPAVACPR As String, _
                                               ByVal stFPAVACCO As String, _
                                               ByVal loFPAVVATP As Long, _
                                               ByVal loFPAVVATC As Long, _
                                               ByVal loFPAVVACP As Long, _
                                               ByVal loFPAVVACC As Long, _
                                               ByVal loFPAVAVAL As Long, _
                                               ByVal stFPAVOBSE As String, _
                                               ByVal stFPAVDATR As String, _
                                               ByVal stFPAVDAVI As String, _
                                               ByVal stFPAVDAND As String, _
                                               ByVal stFPAVESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPAVNUFI As New SqlParameter("@FPAVNUFI", inFPAVNUFI)
            Dim o_loFPAVATPR As New SqlParameter("@FPAVATPR", loFPAVATPR)
            Dim o_loFPAVATCO As New SqlParameter("@FPAVATCO", loFPAVATCO)
            Dim o_stFPAVACPR As New SqlParameter("@FPAVACPR", stFPAVACPR)
            Dim o_stFPAVACCO As New SqlParameter("@FPAVACCO", stFPAVACCO)
            Dim o_loFPAVVATP As New SqlParameter("@FPAVVATP", loFPAVVATP)
            Dim o_loFPAVVATC As New SqlParameter("@FPAVVATC", loFPAVVATC)
            Dim o_loFPAVVACP As New SqlParameter("@FPAVVACP", loFPAVVACP)
            Dim o_loFPAVVACC As New SqlParameter("@FPAVVACC", loFPAVVACC)
            Dim o_loFPAVAVAL As New SqlParameter("@FPAVAVAL", loFPAVAVAL)
            Dim o_stFPAVOBSE As New SqlParameter("@FPAVOBSE", stFPAVOBSE)
            Dim o_stFPAVDATR As New SqlParameter("@FPAVDATR", stFPAVDATR)
            Dim o_stFPAVDAVI As New SqlParameter("@FPAVDAVI", stFPAVDAVI)
            Dim o_stFPAVDAND As New SqlParameter("@FPAVDAND", stFPAVDAND)
            Dim o_stFPAVESTA As New SqlParameter("@FPAVESTA", stFPAVESTA)

            Dim VecParametros(14) As SqlParameter

            VecParametros(0) = o_inFPAVNUFI
            VecParametros(1) = o_loFPAVATPR
            VecParametros(2) = o_loFPAVATCO
            VecParametros(3) = o_stFPAVACPR
            VecParametros(4) = o_stFPAVACCO
            VecParametros(5) = o_loFPAVVATP
            VecParametros(6) = o_loFPAVVATC
            VecParametros(7) = o_loFPAVVACP
            VecParametros(8) = o_loFPAVVACC
            VecParametros(9) = o_loFPAVAVAL
            VecParametros(10) = o_stFPAVOBSE
            VecParametros(11) = o_stFPAVDATR
            VecParametros(12) = o_stFPAVDAVI
            VecParametros(13) = o_stFPAVDAND
            VecParametros(14) = o_stFPAVESTA

            objenq.ActualizarDb(VecParametros, "Insertar_FIPRAVAL")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que elimina el registro por numero de ficha 
    ''' </summary>
    Public Function fun_Eliminar_FIPRAVAL(ByVal inFPAVNUFI As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPAVNUFI As New SqlParameter("@FPAVNUFI", inFPAVNUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPAVNUFI

            objenq.ActualizarDb(VecParametros, "Eliminar_FIPRAVAL")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function


End Class
