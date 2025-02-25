Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_LIVASIST

    '======================================
    '*** CLASE LISTA DE VALORES SISTEMA ***
    '======================================

    Public Function fun_Consultar_MANT_LIVASIST() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_LIVASIST")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function
    Public Function fun_Insertar_MANT_LIVASIST(ByVal stLVSITABL As String, _
                                               ByVal stLVSIDESC As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stLVSITABL As New SqlParameter("@LVSITABL", stLVSITABL)
            Dim o_stLVSIDESC As New SqlParameter("@LVSIDESC", stLVSIDESC)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_stLVSITABL
            VecParametros(1) = o_stLVSIDESC


            objenq.ActualizarDb(VecParametros, "insertar_MANT_LIVASIST")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function
    Public Function fun_Eliminar_MANT_LIVASIST(ByVal inLVSIIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inLVSIIDRE As New SqlParameter("@LVSIIDRE", inLVSIIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inLVSIIDRE

            objenq.ActualizarDb(VecParametros, "eliminar_MANT_LIVASIST")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function
    Public Function fun_Actualizar_MANT_LIVASIST(ByVal inLVSIIDRE As Integer, _
                                                 ByVal stLVSITABL As String, _
                                                 ByVal stLVSIDESC As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inLVSIIDRE As New SqlParameter("@LVSIIDRE", inLVSIIDRE)
            Dim o_stLVSITABL As New SqlParameter("@LVSITABL", stLVSITABL)
            Dim o_stLVSIDESC As New SqlParameter("@LVSIDESC", stLVSIDESC)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_inLVSIIDRE
            VecParametros(1) = o_stLVSITABL
            VecParametros(2) = o_stLVSIDESC

            objenq.ActualizarDb(VecParametros, "actualizar_MANT_LIVASIST")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    Public Function fun_Buscar_ID_MANT_LIVASIST(ByVal inLVSIIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inLVSIIDRE As New SqlParameter("@LVSIIDRE", inLVSIIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inLVSIIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_MANT_LIVASIST")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function
    Public Function fun_Buscar_TABLA_MANT_LIVASIST(ByVal inLVSITABL As Integer) As DataTable


        Try
            Dim objeq As New cExecuteQuery

            Dim o_inLVSITABL As New SqlParameter("@LVSITABL", inLVSITABL)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inLVSITABL

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_TABLA_MANT_LIVASIST")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    Public Function fun_Actualizar_ListaDeValores_ESTADO() As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            objenq.ActualizarDb("Actualizar_ListaDeValores_ESTADO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function
    Public Function fun_Insertar_Administrador() As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            objenq.ActualizarDb("Insertar_Administrador")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function
    Public Function fun_Actualizar_ListaDeValores_ETIQUETAS_MENU_CONTENEDOR() As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            objenq.ActualizarDb("Actualizar_ListaDeValores_ETIQUETAS_MENU_CONTENEDOR")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try
      
    End Function
    Public Function fun_Actualizar_ListaDeValores_FORMULARIO() As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            objenq.ActualizarDb("Actualizar_ListaDeValores_FORMULARIO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function
    Public Function fun_Actualizar_ListaDeValores_ETIQUETAS() As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            objenq.ActualizarDb("Actualizar_ListaDeValores_ETIQUETAS")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

End Class
