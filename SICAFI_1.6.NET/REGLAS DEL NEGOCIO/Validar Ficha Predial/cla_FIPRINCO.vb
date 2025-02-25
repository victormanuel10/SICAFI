Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_FIPRINCO

    '==============================
    ' *** VALIDAR FICHA PREDIAL ***
    '==============================

    ''' <summary>
    ''' Procedimiento que consultar las tablas de ficha predial
    ''' </summary>
    Public Function fun_Consultar_TABLAS_FICHA_PREDIAL(ByVal inFIPRNUME As Integer) As DataSet

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFIPRNUFI As New SqlParameter("@FIPRNUFI", inFIPRNUME)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFIPRNUFI

            Dim tbl As New DataSet
            tbl = objeq.Consultarset(VecParametros, "Consultar_TABLAS_FICHA_PREDIAL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Procedimiento que consultar las inconsistencias por numero de ficha predial
    ''' </summary>
    Public Function fun_Consultar_Inconsistencia_por_ficha_predial(ByVal inINCOFIPR As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFIPRNUFI As New SqlParameter("@FIPRNUFI", inINCOFIPR)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFIPRNUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_Inconsistencia_por_ficha_predial")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function


End Class
