Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_DATASET

    '=====================
    '*** CLASE DATASET ***
    '=====================

    ''' <summary>
    ''' Procedimiento que consulta de varias tablas sin parametros de entrada
    ''' </summary>
    Public Function fun_Consultar_MANT_CALIPROP() As DataSet

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataSet
            tbl = objeq.Consultarset("Consultar_TABLAS_MANT_FICHPRED")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Procedimiento que consulta de varias tablas con parametros de entrada
    ''' </summary>
    Public Function consulta_individual_prestamo(ByVal pcodprestamo As String) As DataSet
        Try
            Dim objcons As New cExecuteQuery
            '
            Dim mcodprestamo As New SqlParameter("@codprestamo", pcodprestamo)
            '
            Dim VecParametros(0) As SqlParameter 'se especifica en que posicion esta el ultimo dato valido
            '
            VecParametros(0) = mcodprestamo
            Dim ds As New DataSet
            '
            ds = objcons.Consultarset(VecParametros, "consulta_prestamo_10")
            Return ds

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

End Class
