Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_PERMETIQ

    '==============================
    '*** CLASE PERMISO ETIQUETA ***
    '==============================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_PERMETIQ() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_PERMETIQ")

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
    Public Function fun_Consultar_CAMPOS_PERMETIQ() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_PERMETIQ")

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
    Public Function fun_Consultar_PERMETIQ_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_PERMETIQ_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_PERMETIQ(ByVal stPEETUSUA As String, _
                                          ByVal stPEETETIQ As String, _
                                          ByVal stPEETDESC As String, _
                                          ByVal stPEETESTA As String) As Boolean
        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stPEETUSUA As New SqlParameter("@PEETUSUA", stPEETUSUA)
            Dim o_stPEETETIQ As New SqlParameter("@PEETETIQ", stPEETETIQ)
            Dim o_stPEETDESC As New SqlParameter("@PEETDESC", stPEETDESC)
            Dim o_stPEETESTA As New SqlParameter("@PEETESTA", stPEETESTA)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_stPEETUSUA
            VecParametros(1) = o_stPEETETIQ
            VecParametros(2) = o_stPEETDESC
            VecParametros(3) = o_stPEETESTA

            objenq.ActualizarDb(VecParametros, "insertar_PERMETIQ")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_PERMETIQ(ByVal inPEETIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inPEETIDRE As New SqlParameter("@PEETIDRE", inPEETIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inPEETIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_PERMETIQ") Then
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
    Public Function fun_Actualizar_PERMETIQ(ByVal inPEETIDRE As Integer, _
                                          ByVal stPEETUSUA As String, _
                                          ByVal stPEETETIQ As String, _
                                          ByVal stPEETDESC As String, _
                                          ByVal stPEETESTA As String) As Boolean
        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inPEETIDRE As New SqlParameter("@PEETIDRE", inPEETIDRE)
            Dim o_stPEETUSUA As New SqlParameter("@PEETUSUA", stPEETUSUA)
            Dim o_stPEETETIQ As New SqlParameter("@PEETETIQ", stPEETETIQ)
            Dim o_stPEETDESC As New SqlParameter("@PEETDESC", stPEETDESC)
            Dim o_stPEETESTA As New SqlParameter("@PEETESTA", stPEETESTA)

            Dim VecParametros(4) As SqlParameter

            VecParametros(0) = o_inPEETIDRE
            VecParametros(1) = o_stPEETUSUA
            VecParametros(2) = o_stPEETETIQ
            VecParametros(3) = o_stPEETDESC
            VecParametros(4) = o_stPEETESTA

            objenq.ActualizarDb(VecParametros, "actualizar_PERMETIQ")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_PERMETIQ(ByVal inPEETIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inPEETIDRE As New SqlParameter("@PEETIDRE", inPEETIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inPEETIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_PERMETIQ")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO del registro para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_PERMETIQ(ByVal stPEETETIQ As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stPEETETIQ As New SqlParameter("@PEETETIQ", stPEETETIQ)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stPEETETIQ

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_PERMETIQ")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el USUARIO Y EL FORMULARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_USUARIO_Y_ETIQUETA_PERMETIQ(ByVal stPEETUSUA As String, _
                                                             ByVal stPEETETIQ As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stPEETUSUA As New SqlParameter("@PEETUSUA", stPEETUSUA)
            Dim o_stPEETETIQ As New SqlParameter("@PEETETIQ", stPEETETIQ)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_stPEETUSUA
            VecParametros(1) = o_stPEETETIQ

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_USUARIO_Y_ETIQUETA_PERMETIQ")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el municipio correspondiente al departamento seleccionado,
    ''' este se carga en el combobox correspondiente al municipio.
    ''' </summary>
    Public Function fun_Buscar_ETIQUETA_X_USUARIO_PERMETIQ(ByVal stPEETUSUA As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stPEETUSUA As New SqlParameter("@PEETUSUA", stPEETUSUA)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stPEETUSUA

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_ETIQUETA_X_USUARIO_PERMETIQ")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

End Class
