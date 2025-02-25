Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_PUNTCARD

    '============================
    '*** CLASE PUNTO CARDINAL ***
    '============================

    Private ejecutar As New SqlCommand
    Private conexion As New SqlConnection
    Private adapter As New SqlDataAdapter
    Private reader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_PUNTCARD() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_PUNTCARD")

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
    Public Function fun_Consultar_CAMPOS_MANT_PUNTCARD() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_MANT_PUNTCARD")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_PUNTCARD_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_PUNTCARD_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_PUNTCARD(ByVal stPUCACODI As String, _
                                               ByVal stPUCADESC As String, _
                                               ByVal stPUCAESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stPUCACODI As New SqlParameter("@PUCACODI", stPUCACODI)
            Dim o_stPUCADESC As New SqlParameter("@PUCADESC", stPUCADESC)
            Dim o_stPUCAESTA As New SqlParameter("@PUCAESTA", stPUCAESTA)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_stPUCACODI
            VecParametros(1) = o_stPUCADESC
            VecParametros(2) = o_stPUCAESTA

            objenq.ActualizarDb(VecParametros, "insertar_MANT_PUNTCARD")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_PUNTCARD(ByVal inPUCAIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inPUCAIDRE As New SqlParameter("@PUCAIDRE", inPUCAIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inPUCAIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_MANT_PUNTCARD") Then
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
    Public Function fun_Actualizar_MANT_PUNTCARD(ByVal inPUCAIDRE As Integer, _
                                                     ByVal stPUCACODI As String, _
                                                     ByVal stPUCADESC As String, _
                                                     ByVal stPUCAESTA As String) As Boolean
        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inPUCAIDRE As New SqlParameter("@PUCAIDRE", inPUCAIDRE)
            Dim o_stPUCACODI As New SqlParameter("@PUCACODI", stPUCACODI)
            Dim o_stPUCADESC As New SqlParameter("@PUCADESC", stPUCADESC)
            Dim o_stPUCAESTA As New SqlParameter("@PUCAESTA", stPUCAESTA)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_inPUCAIDRE
            VecParametros(1) = o_stPUCACODI
            VecParametros(2) = o_stPUCADESC
            VecParametros(3) = o_stPUCAESTA

            objenq.ActualizarDb(VecParametros, "actualizar_MANT_PUNTCARD")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try
      
    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_PUNTCARD(ByVal inPUCAIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inPUCAIDRE As New SqlParameter("@PUCAIDRE", inPUCAIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inPUCAIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_MANT_PUNTCARD")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DEL PUNTO CARDINAL para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_PUNTCARD(ByVal stPUCACODI As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stPUCACODI As New SqlParameter("@PUCACODI", stPUCACODI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stPUCACODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_MANT_PUNTCARD")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function


    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_PUNTCARD(ByVal inPUCAIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inPUCAIDRE As New SqlParameter("@PUCAIDRE", inPUCAIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inPUCAIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_PUNTCARD")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function


End Class
