Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_LIVAMANT

    '============================================
    '*** CLASE LISTA DE VALORES FICHA PREDIAL ***
    '============================================

    ''' <summary>
    ''' Lista de valores de FICHA PREDIAL
    ''' </summary>
    Public Function fun_Actualizar_ListaDeValores_MANT_TIPORESO() As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            objenq.ActualizarDb("Actualizar_ListaDeValores_MANT_TIPORESO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Lista de valores de FICHA PREDIAL
    ''' </summary>
    Public Function fun_Actualizar_ListaDeValores_MANT_CLASSECT() As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            objenq.ActualizarDb("Actualizar_ListaDeValores_MANT_CLASSECT")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Lista de valores de FICHA PREDIAL
    ''' </summary>
    Public Function fun_Actualizar_ListaDeValores_MANT_CATESUEL() As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            objenq.ActualizarDb("Actualizar_ListaDeValores_MANT_CATESUEL")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try
      
    End Function

    ''' <summary>
    ''' Lista de valores de FICHA PREDIAL
    ''' </summary>
    Public Function fun_Actualizar_ListaDeValores_MANT_CARAPRED() As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            objenq.ActualizarDb("Actualizar_ListaDeValores_MANT_CARAPRED")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try
      
    End Function

    ''' <summary>
    ''' Lista de valores de FICHA PREDIAL
    ''' </summary>
    Public Function fun_Actualizar_ListaDeValores_MANT_MODOADQU() As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            objenq.ActualizarDb("Actualizar_ListaDeValores_MANT_MODOADQU")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try
       
    End Function

    ''' <summary>
    ''' Lista de valores de FICHA PREDIAL
    ''' </summary>
    Public Function fun_Actualizar_ListaDeValores_MANT_DESTECON() As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            objenq.ActualizarDb("Actualizar_ListaDeValores_MANT_DESTECON")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try
         
    End Function

    ''' <summary>
    ''' Lista de valores de FICHA PREDIAL
    ''' </summary>
    Public Function fun_Actualizar_ListaDeValores_MANT_CALIPROP() As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            objenq.ActualizarDb("Actualizar_ListaDeValores_MANT_CALIPROP")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try
        
    End Function

    ''' <summary>
    ''' Lista de valores de FICHA PREDIAL
    ''' </summary>
    Public Function fun_Actualizar_ListaDeValores_MANT_TIPODOCU() As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            objenq.ActualizarDb("Actualizar_ListaDeValores_MANT_TIPODOCU")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Lista de valores de FICHA PREDIAL
    ''' </summary>
    Public Function fun_Actualizar_ListaDeValores_MANT_SEXO() As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            objenq.ActualizarDb("Actualizar_ListaDeValores_MANT_SEXO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try
      
    End Function

    ''' <summary>
    ''' Lista de valores de FICHA PREDIAL
    ''' </summary>
    Public Function fun_Actualizar_ListaDeValores_MANT_DEPARTAMENTO() As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            objenq.ActualizarDb("Actualizar_ListaDeValores_MANT_DEPARTAMENTO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Lista de valores de FICHA PREDIAL
    ''' </summary>
    Public Function fun_Actualizar_ListaDeValores_MANT_MUNICIPIO() As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            objenq.ActualizarDb("Actualizar_ListaDeValores_MANT_MUNICIPIO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Lista de valores de FICHA PREDIAL
    ''' </summary>
    Public Function fun_Actualizar_ListaDeValores_MANT_CLASCONS() As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            objenq.ActualizarDb("Actualizar_ListaDeValores_MANT_CLASCONS")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Lista de valores de FICHA PREDIAL
    ''' </summary>
    Public Function fun_Actualizar_ListaDeValores_MANT_CODICALI() As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            objenq.ActualizarDb("Actualizar_ListaDeValores_MANT_CODICALI")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Lista de valores de FICHA PREDIAL
    ''' </summary>
    Public Function fun_Actualizar_ListaDeValores_MANT_TIPOCALI() As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            objenq.ActualizarDb("Actualizar_ListaDeValores_MANT_TIPOCALI")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Lista de valores de FICHA PREDIAL
    ''' </summary>
    Public Function fun_Actualizar_ListaDeValores_MANT_PUNTCARD() As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            objenq.ActualizarDb("Actualizar_ListaDeValores_MANT_PUNTCARD")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Procedimiento que consulta de varias tablas sin parametros de entrada
    ''' </summary>
    Public Function fun_Consultar_TABLAS_MANT_FICHPRED() As DataSet

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

End Class
