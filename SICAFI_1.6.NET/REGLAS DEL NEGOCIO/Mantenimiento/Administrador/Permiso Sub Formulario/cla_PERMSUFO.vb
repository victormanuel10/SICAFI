Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_PERMSUFO

    '====================================
    '*** CLASE PERMISO SUB FORMULARIO ***
    '====================================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_PERMSUFO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_PERMSUFO")

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
    Public Function fun_Consultar_CAMPOS_PERMSUFO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_PERMSUFO")

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
    Public Function fun_Consultar_PERMSUFO_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_PERMSUFO_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_PERMSUFO(ByVal stPESFUSUA As String, _
                                          ByVal stPESFFORM As String, _
                                          ByVal stPESFDESC As String, _
                                          ByVal boPESFAGRE As Boolean, _
                                          ByVal boPESFMODI As Boolean, _
                                          ByVal boPESFELIM As Boolean, _
                                          ByVal stPESFESTA As String) As Boolean
        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stPESFUSUA As New SqlParameter("@PESFUSUA", stPESFUSUA)
            Dim o_stPESFFORM As New SqlParameter("@PESFFORM", stPESFFORM)
            Dim o_stPESFDESC As New SqlParameter("@PESFDESC", stPESFDESC)
            Dim o_boPESFAGRE As New SqlParameter("@PESFAGRE", boPESFAGRE)
            Dim o_boPESFMODI As New SqlParameter("@PESFMODI", boPESFMODI)
            Dim o_boPESFELIM As New SqlParameter("@PESFELIM", boPESFELIM)
            Dim o_stPESFESTA As New SqlParameter("@PESFESTA", stPESFESTA)

            Dim VecParametros(6) As SqlParameter

            VecParametros(0) = o_stPESFUSUA
            VecParametros(1) = o_stPESFFORM
            VecParametros(2) = o_stPESFDESC
            VecParametros(3) = o_boPESFAGRE
            VecParametros(4) = o_boPESFMODI
            VecParametros(5) = o_boPESFELIM
            VecParametros(6) = o_stPESFESTA

            objenq.ActualizarDb(VecParametros, "insertar_PERMSUFO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_PERMSUFO(ByVal inPESFIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inPESFIDRE As New SqlParameter("@PESFIDRE", inPESFIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inPESFIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_PERMSUFO") Then
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
    Public Function fun_Actualizar_PERMSUFO(ByVal inPESFIDRE As Integer, _
                                          ByVal stPESFUSUA As String, _
                                          ByVal stPESFFORM As String, _
                                          ByVal stPESFDESC As String, _
                                          ByVal boPESFAGRE As Boolean, _
                                          ByVal boPESFMODI As Boolean, _
                                          ByVal boPESFELIM As Boolean, _
                                          ByVal stPESFESTA As String) As Boolean
        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inPESFIDRE As New SqlParameter("@PESFIDRE", inPESFIDRE)
            Dim o_stPESFUSUA As New SqlParameter("@PESFUSUA", stPESFUSUA)
            Dim o_stPESFFORM As New SqlParameter("@PESFFORM", stPESFFORM)
            Dim o_stPESFDESC As New SqlParameter("@PESFDESC", stPESFDESC)
            Dim o_boPESFAGRE As New SqlParameter("@PESFAGRE", boPESFAGRE)
            Dim o_boPESFMODI As New SqlParameter("@PESFMODI", boPESFMODI)
            Dim o_boPESFELIM As New SqlParameter("@PESFELIM", boPESFELIM)
            Dim o_stPESFESTA As New SqlParameter("@PESFESTA", stPESFESTA)

            Dim VecParametros(7) As SqlParameter

            VecParametros(0) = o_inPESFIDRE
            VecParametros(1) = o_stPESFUSUA
            VecParametros(2) = o_stPESFFORM
            VecParametros(3) = o_stPESFDESC
            VecParametros(4) = o_boPESFAGRE
            VecParametros(5) = o_boPESFMODI
            VecParametros(6) = o_boPESFELIM
            VecParametros(7) = o_stPESFESTA

            objenq.ActualizarDb(VecParametros, "actualizar_PERMSUFO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_PERMSUFO(ByVal inPESFIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inPESFIDRE As New SqlParameter("@PESFIDRE", inPESFIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inPESFIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_PERMSUFO")

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
    Public Function fun_Buscar_CODIGO_PERMSUFO(ByVal stPESFFORM As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stPESFFORM As New SqlParameter("@PESFFORM", stPESFFORM)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stPESFFORM

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_PERMSUFO")

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
    Public Function fun_Buscar_USUARIO_Y_FORMULARIO_PERMSUFO(ByVal stPESFUSUA As String, _
                                                             ByVal stPESFFORM As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stPESFUSUA As New SqlParameter("@PESFUSUA", stPESFUSUA)
            Dim o_stPESFFORM As New SqlParameter("@PESFFORM", stPESFFORM)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_stPESFUSUA
            VecParametros(1) = o_stPESFFORM

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_USUARIO_Y_FORMULARIO_PERMSUFO")

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
    Public Function fun_Buscar_FORMULARIO_X_USUARIO_PERMSUFO(ByVal stPESFUSUA As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stPESFUSUA As New SqlParameter("@PESFUSUA", stPESFUSUA)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stPESFUSUA

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_FORMULARIO_X_USUARIO_PERMSUFO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

End Class
