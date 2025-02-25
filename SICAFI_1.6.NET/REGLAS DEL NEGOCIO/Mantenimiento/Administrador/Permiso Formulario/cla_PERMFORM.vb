Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_PERMFORM

    '================================
    '*** CLASE PERMISO FORMULARIO ***
    '================================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_PERMFORM() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_PERMFORM")

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
    Public Function fun_Consultar_CAMPOS_PERMFORM() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_PERMFORM")

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
    Public Function fun_Consultar_PERMFORM_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_PERMFORM_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_PERMFORM(ByVal stPEFOUSUA As String, _
                                          ByVal stPEFOFORM As String, _
                                          ByVal stPEFODESC As String, _
                                          ByVal boPEFOAGRE As Boolean, _
                                          ByVal boPEFOMODI As Boolean, _
                                          ByVal boPEFOELIM As Boolean, _
                                          ByVal stPEFOESTA As String) As Boolean
        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stPEFOUSUA As New SqlParameter("@PEFOUSUA", stPEFOUSUA)
            Dim o_stPEFOFORM As New SqlParameter("@PEFOFORM", stPEFOFORM)
            Dim o_stPEFODESC As New SqlParameter("@PEFODESC", stPEFODESC)
            Dim o_boPEFOAGRE As New SqlParameter("@PEFOAGRE", boPEFOAGRE)
            Dim o_boPEFOMODI As New SqlParameter("@PEFOMODI", boPEFOMODI)
            Dim o_boPEFOELIM As New SqlParameter("@PEFOELIM", boPEFOELIM)
            Dim o_stPEFOESTA As New SqlParameter("@PEFOESTA", stPEFOESTA)

            Dim VecParametros(6) As SqlParameter

            VecParametros(0) = o_stPEFOUSUA
            VecParametros(1) = o_stPEFOFORM
            VecParametros(2) = o_stPEFODESC
            VecParametros(3) = o_boPEFOAGRE
            VecParametros(4) = o_boPEFOMODI
            VecParametros(5) = o_boPEFOELIM
            VecParametros(6) = o_stPEFOESTA

            objenq.ActualizarDb(VecParametros, "insertar_PERMFORM")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_PERMFORM(ByVal inPEFOIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inPEFOIDRE As New SqlParameter("@PEFOIDRE", inPEFOIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inPEFOIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_PERMFORM") Then
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
    Public Function fun_Actualizar_PERMFORM(ByVal inPEFOIDRE As Integer, _
                                          ByVal stPEFOUSUA As String, _
                                          ByVal stPEFOFORM As String, _
                                          ByVal stPEFODESC As String, _
                                          ByVal boPEFOAGRE As Boolean, _
                                          ByVal boPEFOMODI As Boolean, _
                                          ByVal boPEFOELIM As Boolean, _
                                          ByVal stPEFOESTA As String) As Boolean
        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inPEFOIDRE As New SqlParameter("@PEFOIDRE", inPEFOIDRE)
            Dim o_stPEFOUSUA As New SqlParameter("@PEFOUSUA", stPEFOUSUA)
            Dim o_stPEFOFORM As New SqlParameter("@PEFOFORM", stPEFOFORM)
            Dim o_stPEFODESC As New SqlParameter("@PEFODESC", stPEFODESC)
            Dim o_boPEFOAGRE As New SqlParameter("@PEFOAGRE", boPEFOAGRE)
            Dim o_boPEFOMODI As New SqlParameter("@PEFOMODI", boPEFOMODI)
            Dim o_boPEFOELIM As New SqlParameter("@PEFOELIM", boPEFOELIM)
            Dim o_stPEFOESTA As New SqlParameter("@PEFOESTA", stPEFOESTA)

            Dim VecParametros(7) As SqlParameter

            VecParametros(0) = o_inPEFOIDRE
            VecParametros(1) = o_stPEFOUSUA
            VecParametros(2) = o_stPEFOFORM
            VecParametros(3) = o_stPEFODESC
            VecParametros(4) = o_boPEFOAGRE
            VecParametros(5) = o_boPEFOMODI
            VecParametros(6) = o_boPEFOELIM
            VecParametros(7) = o_stPEFOESTA

            objenq.ActualizarDb(VecParametros, "actualizar_PERMFORM")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_PERMFORM(ByVal inPEFOIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inPEFOIDRE As New SqlParameter("@PEFOIDRE", inPEFOIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inPEFOIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_PERMFORM")

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
    Public Function fun_Buscar_CODIGO_PERMFORM(ByVal stPEFOFORM As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stPEFOFORM As New SqlParameter("@PEFOFORM", stPEFOFORM)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stPEFOFORM

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_PERMFORM")

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
    Public Function fun_Buscar_USUARIO_Y_FORMULARIO_PERMFORM(ByVal stPEFOUSUA As String, _
                                                             ByVal stPEFOFORM As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stPEFOUSUA As New SqlParameter("@PEFOUSUA", stPEFOUSUA)
            Dim o_stPEFOFORM As New SqlParameter("@PEFOFORM", stPEFOFORM)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_stPEFOUSUA
            VecParametros(1) = o_stPEFOFORM

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_USUARIO_Y_FORMULARIO_PERMFORM")

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
    Public Function fun_Buscar_FORMULARIO_X_USUARIO_PERMFORM(ByVal stPEFOUSUA As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stPEFOUSUA As New SqlParameter("@PEFOUSUA", stPEFOUSUA)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stPEFOUSUA

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_FORMULARIO_X_USUARIO_PERMFORM")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

End Class
