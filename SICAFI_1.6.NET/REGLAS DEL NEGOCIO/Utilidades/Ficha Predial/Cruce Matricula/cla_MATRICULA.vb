Imports DATOS
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class cla_MATRICULA

    '======================================
    '*** CLASE MATRICULAS INMOBILIARIAS ***
    '======================================

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MATRICULA(ByVal stMATRMATR As String, _
                                           ByVal stMATRNUCA As String, _
                                           ByVal stMATRVIGE As String, _
                                           ByVal stMATRCLSE As String, _
                                           ByVal stMATRDIRE As String, _
                                           ByVal stMATRLIND As String, _
                                           ByVal stMATRTIDO As String, _
                                           ByVal stMATRNUDO As String, _
                                           ByVal stMATRNOMB As String, _
                                           ByVal stMATRDEPA As String, _
                                           ByVal stMATRMUNI As String) As Boolean

        Try

            Dim objenq As New cExecuteNonQuery

            Dim o_stMATRMATR As New SqlParameter("@MATRMATR", stMATRMATR)
            Dim o_stMATRNUCA As New SqlParameter("@MATRNUCA", stMATRNUCA)
            Dim o_stMATRVIGE As New SqlParameter("@MATRVIGE", stMATRVIGE)
            Dim o_stMATRCLSE As New SqlParameter("@MATRCLSE", stMATRCLSE)
            Dim o_stMATRDIRE As New SqlParameter("@MATRDIRE", stMATRDIRE)
            Dim o_stMATRLIND As New SqlParameter("@MATRLIND", stMATRLIND)
            Dim o_stMATRTIDO As New SqlParameter("@MATRTIDO", stMATRTIDO)
            Dim o_stMATRNUDO As New SqlParameter("@MATRNUDO", stMATRNUDO)
            Dim o_stMATRNOMB As New SqlParameter("@MATRNOMB", stMATRNOMB)
            Dim o_stMATRDEPA As New SqlParameter("@MATRDEPA", stMATRDEPA)
            Dim o_stMATRMUNI As New SqlParameter("@MATRMUNI", stMATRMUNI)

            Dim VecParametros(10) As SqlParameter

            VecParametros(0) = o_stMATRMATR
            VecParametros(1) = o_stMATRNUCA
            VecParametros(2) = o_stMATRVIGE
            VecParametros(3) = o_stMATRCLSE
            VecParametros(4) = o_stMATRDIRE
            VecParametros(5) = o_stMATRLIND
            VecParametros(6) = o_stMATRTIDO
            VecParametros(7) = o_stMATRNUDO
            VecParametros(8) = o_stMATRNOMB
            VecParametros(9) = o_stMATRDEPA
            VecParametros(10) = o_stMATRMUNI


            objenq.ActualizarDb(VecParametros, "insertar_MATRICULA")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MATRICULA(ByVal stMATRMATR As String, _
                                           ByVal stMATRDEPA As String, _
                                           ByVal stMATRMUNI As String, _
                                           ByVal stMATRCLSE As String, _
                                           ByVal stMATRNUDO As String) As Boolean


        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stMATRMATR As New SqlParameter("@MATRMATR", stMATRMATR)
            Dim o_stMATRDEPA As New SqlParameter("@MATRDEPA", stMATRDEPA)
            Dim o_stMATRMUNI As New SqlParameter("@MATRMUNI", stMATRMUNI)
            Dim o_stMATRCLSE As New SqlParameter("@MATRCLSE", stMATRCLSE)
            Dim o_stMATRNUDO As New SqlParameter("@MATRNUDO", stMATRNUDO)

            Dim VecParametros(4) As SqlParameter

            VecParametros(0) = o_stMATRMATR
            VecParametros(1) = o_stMATRDEPA
            VecParametros(2) = o_stMATRMUNI
            VecParametros(3) = o_stMATRCLSE
            VecParametros(4) = o_stMATRNUDO

            If objenq.ActualizarDb(VecParametros, "eliminar_MATRICULA") Then
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
    ''' Función que Elimina todas las matriculas del municipio.
    ''' </summary>
    Public Function fun_Eliminar_MATRICULA_X_MUNICIPIO(ByVal stMATRDEPA As String, _
                                           ByVal stMATRMUNI As String, _
                                           ByVal stMATRCLSE As String) As Boolean


        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stMATRDEPA As New SqlParameter("@MATRDEPA", stMATRDEPA)
            Dim o_stMATRMUNI As New SqlParameter("@MATRMUNI", stMATRMUNI)
            Dim o_stMATRCLSE As New SqlParameter("@MATRCLSE", stMATRCLSE)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_stMATRDEPA
            VecParametros(1) = o_stMATRMUNI
            VecParametros(2) = o_stMATRCLSE

            If objenq.ActualizarDb(VecParametros, "Eliminar_MATRICULA_X_MUNICIPIO") Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

End Class
