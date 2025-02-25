Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CODICALI


    '=====================================
    '*** CLASE CODIGOS DE CALIFICACIÓN ***
    '=====================================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CODICALI() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_CODICALI")

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
    Public Function fun_Consultar_CAMPOS_MANT_CODICALI() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_MANT_CODICALI")

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
    Public Function fun_Consultar_MANT_CODICALI_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_CODICALI_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_CODICALI(ByVal inCOCACODI As Integer, _
                                               ByVal stCOCADESC As String, _
                                               ByVal stCOCACOPA As String, _
                                               ByVal stCOCACOHI As String, _
                                               ByVal stCOCAESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inCOCACODI As New SqlParameter("@COCACODI", inCOCACODI)
            Dim o_stCOCADESC As New SqlParameter("@COCADESC", stCOCADESC)
            Dim o_stCOCACOPA As New SqlParameter("@COCACOPA", stCOCACOPA)
            Dim o_stCOCACOHI As New SqlParameter("@COCACOHI", stCOCACOHI)
            Dim o_stCOCAESTA As New SqlParameter("@COCAESTA", stCOCAESTA)

            Dim VecParametros(4) As SqlParameter

            VecParametros(0) = o_inCOCACODI
            VecParametros(1) = o_stCOCADESC
            VecParametros(2) = o_stCOCACOPA
            VecParametros(3) = o_stCOCACOHI
            VecParametros(4) = o_stCOCAESTA

            objenq.ActualizarDb(VecParametros, "insertar_MANT_CODICALI")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CODICALI(ByVal inCOCAIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inCOCAIDRE As New SqlParameter("@COCAIDRE", inCOCAIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCOCAIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_MANT_CODICALI") Then
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
    Public Function fun_Actualizar_MANT_CODICALI(ByVal inCOCAIDRE As Integer, _
                                                 ByVal inCOCACODI As Integer, _
                                                 ByVal stCOCADESC As String, _
                                                 ByVal stCOCACOPA As String, _
                                                 ByVal stCOCACOHI As String, _
                                                 ByVal stCOCAESTA As String) As Boolean


        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inCOCAIDRE As New SqlParameter("@COCAIDRE", inCOCAIDRE)
            Dim o_inCOCACODI As New SqlParameter("@COCACODI", inCOCACODI)
            Dim o_stCOCADESC As New SqlParameter("@COCADESC", stCOCADESC)
            Dim o_stCOCACOPA As New SqlParameter("@COCACOPA", stCOCACOPA)
            Dim o_stCOCACOHI As New SqlParameter("@COCACOHI", stCOCACOHI)
            Dim o_stCOCAESTA As New SqlParameter("@COCAESTA", stCOCAESTA)

            Dim VecParametros(5) As SqlParameter

            VecParametros(0) = o_inCOCAIDRE
            VecParametros(1) = o_inCOCACODI
            VecParametros(2) = o_stCOCADESC
            VecParametros(3) = o_stCOCACOPA
            VecParametros(4) = o_stCOCACOHI
            VecParametros(5) = o_stCOCAESTA

            objenq.ActualizarDb(VecParametros, "actualizar_MANT_CODICALI")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CODICALI(ByVal inCOCAIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inCOCAIDRE As New SqlParameter("@COCAIDRE", inCOCAIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCOCAIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_MANT_CODICALI")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CLASE O SECTOR para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_CODICALI(ByVal inCOCACODI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inCOCACODI As New SqlParameter("@COCACODI", inCOCACODI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCOCACODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_MANT_CODICALI")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function
End Class
