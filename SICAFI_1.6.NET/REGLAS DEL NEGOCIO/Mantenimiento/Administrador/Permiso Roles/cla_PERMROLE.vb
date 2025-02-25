Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_PERMROLE

    '===========================
    '*** CLASE PERMISO ROLES ***
    '===========================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_PERMROLE() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_PERMROLE")

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
    Public Function fun_Consultar_CAMPOS_PERMROLE() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_PERMROLE")

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
    Public Function fun_Consultar_PERMROLE_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_PERMROLE_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_PERMROLE(ByVal stPEROUSUA As String, _
                                          ByVal stPEROROLE As String, _
                                          ByVal stPEROESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stPEROUSUA As New SqlParameter("@PEROUSUA", stPEROUSUA)
            Dim o_stPEROROLE As New SqlParameter("@PEROROLE", stPEROROLE)
            Dim o_stPEROESTA As New SqlParameter("@PEROESTA", stPEROESTA)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_stPEROUSUA
            VecParametros(1) = o_stPEROROLE
            VecParametros(2) = o_stPEROESTA

            objenq.ActualizarDb(VecParametros, "insertar_PERMROLE")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_PERMROLE(ByVal inPEROIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inPEROIDRE As New SqlParameter("@PEROIDRE", inPEROIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inPEROIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_PERMROLE") Then
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
    Public Function fun_Actualizar_PERMROLE(ByVal inPEROIDRE As Integer, _
                                            ByVal stPEROUSUA As String, _
                                            ByVal stPEROROLE As String, _
                                            ByVal stPEROESTA As String) As Boolean
        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inPEROIDRE As New SqlParameter("@PEROIDRE", inPEROIDRE)
            Dim o_stPEROUSUA As New SqlParameter("@PEROUSUA", stPEROUSUA)
            Dim o_stPEROROLE As New SqlParameter("@PEROROLE", stPEROROLE)
            Dim o_stPEROESTA As New SqlParameter("@PEROESTA", stPEROESTA)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_inPEROIDRE
            VecParametros(1) = o_stPEROUSUA
            VecParametros(2) = o_stPEROROLE
            VecParametros(3) = o_stPEROESTA

            objenq.ActualizarDb(VecParametros, "actualizar_PERMROLE")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_PERMROLE(ByVal inPEROIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inPEROIDRE As New SqlParameter("@PEROIDRE", inPEROIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inPEROIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_PERMROLE")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DEL USUARIO Y EL ROLE para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_PERMROLE(ByVal stPEROUSUA As String, ByVal stPEROROLE As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stPEROUSUA As New SqlParameter("@PEROUSUA", stPEROUSUA)
            Dim o_stPEROROLE As New SqlParameter("@PEROROLE", stPEROROLE)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_stPEROUSUA
            VecParametros(1) = o_stPEROROLE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_PERMROLE")

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
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_PERMROLE(ByVal inPEROIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inPEROIDRE As New SqlParameter("@PEROIDRE", inPEROIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inPEROIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_ID_X_CONSULTA_PARAMETRIZADA_PERMROLE")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca USUARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_USUARIO_PERMROLE(ByVal stPEROUSUA As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stPEROUSUA As New SqlParameter("@PEROUSUA", stPEROUSUA)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stPEROUSUA

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_USUARIO_PERMROLE")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function
End Class
