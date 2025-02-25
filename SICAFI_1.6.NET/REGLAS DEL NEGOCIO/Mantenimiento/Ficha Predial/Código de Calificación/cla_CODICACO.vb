Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CODICACO

    '====================================================
    '*** CLASE CODIGOS DE CALIFICACIÓN DE CONSTRUCCIÓN***
    '====================================================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CODICACO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_CODICACO")

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
    Public Function fun_Consultar_CAMPOS_MANT_CODICACO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_MANT_CODICACO")

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
    Public Function fun_Consultar_MANT_CODICACO_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_CODICACO_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_CODICACO(ByVal inCOCCCODI As Integer, _
                                               ByVal stCOCCTIPO As String, _
                                               ByVal stCOCCPUNT As Integer, _
                                               ByVal stCOCCESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inCOCCCODI As New SqlParameter("@COCCCODI", inCOCCCODI)
            Dim o_stCOCCTIPO As New SqlParameter("@COCCTIPO", stCOCCTIPO)
            Dim o_stCOCCPUNT As New SqlParameter("@COCCPUNT", stCOCCPUNT)
            Dim o_stCOCCESTA As New SqlParameter("@COCCESTA", stCOCCESTA)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_inCOCCCODI
            VecParametros(1) = o_stCOCCTIPO
            VecParametros(2) = o_stCOCCPUNT
            VecParametros(3) = o_stCOCCESTA

            objenq.ActualizarDb(VecParametros, "insertar_MANT_CODICACO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CODICACO(ByVal inCOCCIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inCOCCIDRE As New SqlParameter("@COCCIDRE", inCOCCIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCOCCIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_MANT_CODICACO") Then
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
    Public Function fun_Actualizar_MANT_CODICACO(ByVal inCOCCIDRE As Integer, _
                                                 ByVal stCOCCCODI As Integer, _
                                                 ByVal stCOCCTIPO As String, _
                                                 ByVal inCOCCPUNT As Integer, _
                                                 ByVal stCOCCESTA As String) As Boolean


        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inCOCCIDRE As New SqlParameter("@COCCIDRE", inCOCCIDRE)
            Dim o_inCOCCCODI As New SqlParameter("@COCCCODI", stCOCCCODI)
            Dim o_stCOCCTIPO As New SqlParameter("@COCCTIPO", stCOCCTIPO)
            Dim o_inCOCCPUNT As New SqlParameter("@COCCPUNT", inCOCCPUNT)
            Dim o_stCOCCESTA As New SqlParameter("@COCCESTA", stCOCCESTA)

            Dim VecParametros(4) As SqlParameter

            VecParametros(0) = o_inCOCCIDRE
            VecParametros(1) = o_inCOCCCODI
            VecParametros(2) = o_stCOCCTIPO
            VecParametros(3) = o_inCOCCPUNT
            VecParametros(4) = o_stCOCCESTA

            objenq.ActualizarDb(VecParametros, "insertar_MANT_CODICACO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CODICACO(ByVal inCOCCIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inCOCCIDRE As New SqlParameter("@COCCIDRE", inCOCCIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCOCCIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_MANT_CODICACO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO 
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_CODICACO(ByVal inCOCCCODI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inCOCCCODI As New SqlParameter("@COCCCODI", inCOCCCODI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCOCCCODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_MANT_CODICACO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO Y TIPO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_Y_TIPO_MANT_CODICACO(ByVal inCOCCCODI As Integer, _
                                                           ByVal stCOCCTIPO As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inCOCCCODI As New SqlParameter("@COCCCODI", inCOCCCODI)
            Dim o_stCOCCTIPO As New SqlParameter("@COCCTIPO", stCOCCTIPO)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_inCOCCCODI
            VecParametros(1) = o_inCOCCCODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_MANT_CODICACO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Consulta los puntos de calificacion de acuerdo al codigo y tipo de calificacion
    ''' </summary>
    Public Function fun_Consultar_PUNTOS_DE_CALIFICACION_X_CODIGO_Y_TIPO(ByVal inCOCCCODI As Integer, _
                                                           ByVal stCOCCTIPO As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inCOCCCODI As New SqlParameter("@COCCCODI", inCOCCCODI)
            Dim o_stCOCCTIPO As New SqlParameter("@COCCTIPO", stCOCCTIPO)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_inCOCCCODI
            VecParametros(1) = o_stCOCCTIPO

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_PUNTOS_DE_CALIFICACION_X_CODIGO_Y_TIPO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function
End Class
