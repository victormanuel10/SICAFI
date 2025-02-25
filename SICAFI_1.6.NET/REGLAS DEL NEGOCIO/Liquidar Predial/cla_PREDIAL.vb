Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_PREDIAL

    '======================================
    ' *** LIQUIDAR PREDIAL FICHA PREDIAL ***
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
    Public Function fun_Consultar_PREDIAL_X_FICHA_PREDIAL(ByVal stPREDNUFI As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stPREDNUFI As New SqlParameter("@PREDNUFI", stPREDNUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stPREDNUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_PREDIAL_X_FICHA_PREDIAL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_PREDIAL(ByVal inPREDNUFI As Integer, _
                                               ByVal loPREDPRED As Long, _
                                               ByVal stPREDDATR As String, _
                                               ByVal stPREDDAVI As String, _
                                               ByVal stPREDDAND As String, _
                                               ByVal stPREDESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inPREDNUFI As New SqlParameter("@PREDNUFI", inPREDNUFI)
            Dim o_loPREDPRED As New SqlParameter("@PREDPRED", loPREDPRED)
            Dim o_stPREDDATR As New SqlParameter("@PREDDATR", stPREDDATR)
            Dim o_stPREDDAVI As New SqlParameter("@PREDDAVI", stPREDDAVI)
            Dim o_stPREDDAND As New SqlParameter("@PREDDAND", stPREDDAND)
            Dim o_stPREDESTA As New SqlParameter("@PREDESTA", stPREDESTA)

            Dim VecParametros(5) As SqlParameter

            VecParametros(0) = o_inPREDNUFI
            VecParametros(1) = o_loPREDPRED
            VecParametros(2) = o_stPREDDATR
            VecParametros(3) = o_stPREDDAVI
            VecParametros(4) = o_stPREDDAND
            VecParametros(5) = o_stPREDESTA

            objenq.ActualizarDb(VecParametros, "Insertar_PREDIAL")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que elimina el registro por numero de ficha 
    ''' </summary>
    Public Function fun_Eliminar_PREDIAL(ByVal inPREDNUFI As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inPREDNUFI As New SqlParameter("@PREDNUFI", inPREDNUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inPREDNUFI

            objenq.ActualizarDb(VecParametros, "Eliminar_PREDIAL")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

End Class
