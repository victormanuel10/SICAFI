Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CARAPRED

    '======================================
    '*** CLASE CARACTERISTICA DE PREDIO ***
    '======================================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CARAPRED() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_CARAPRED")

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
    Public Function fun_Consultar_CAMPOS_MANT_CARAPRED() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_MANT_CARAPRED")

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
    Public Function fun_Consultar_MANT_CARAPRED_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_CARAPRED_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_CARAPRED(ByVal inCAPRCODI As Integer, _
                                               ByVal stCAPRDESC As String, _
                                               ByVal stCAPRESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inCAPRCODI As New SqlParameter("@CAPRCODI", inCAPRCODI)
            Dim o_stCAPRDESC As New SqlParameter("@CAPRDESC", stCAPRDESC)
            Dim o_stCAPRESTA As New SqlParameter("@CAPRESTA", stCAPRESTA)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_inCAPRCODI
            VecParametros(1) = o_stCAPRDESC
            VecParametros(2) = o_stCAPRESTA

            objenq.ActualizarDb(VecParametros, "insertar_MANT_CARAPRED")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CARAPRED(ByVal inCAPRIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inCAPRIDRE As New SqlParameter("@CAPRIDRE", inCAPRIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCAPRIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_MANT_CARAPRED") = True Then
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
    Public Function fun_Actualizar_MANT_CARAPRED(ByVal inCAPRIDRE As Integer, _
                                                 ByVal inCAPRCODI As Integer, _
                                                 ByVal stCAPRDESC As String, _
                                                 ByVal stCAPRESTA As String) As Boolean
        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inCAPRIDRE As New SqlParameter("@CAPRIDRE", inCAPRIDRE)
            Dim o_inCAPRCODI As New SqlParameter("@CAPRCODI", inCAPRCODI)
            Dim o_stCAPRDESC As New SqlParameter("@CAPRDESC", stCAPRDESC)
            Dim o_stCAPRESTA As New SqlParameter("@CAPRESTA", stCAPRESTA)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_inCAPRIDRE
            VecParametros(1) = o_inCAPRCODI
            VecParametros(2) = o_stCAPRDESC
            VecParametros(3) = o_stCAPRESTA

            objenq.ActualizarDb(VecParametros, "actualizar_MANT_CARAPRED")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CARAPRED(ByVal inCAPRIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inCAPRIDRE As New SqlParameter("@CAPRIDRE", inCAPRIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCAPRIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_MANT_CARAPRED")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CARACTERISTICA DE PREDIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_CARAPRED(ByVal inCAPRCODI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inCAPRCODI As New SqlParameter("@CAPRCODI", inCAPRCODI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCAPRCODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_MANT_CARAPRED")

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
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CARAPRED(ByVal inCAPRIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inCAPRIDRE As New SqlParameter("@CAPRIDRE", inCAPRIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCAPRIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CARAPRED")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Carga el codigo y la descripcion de los registros activos que carga el combobox
    ''' </summary>
    Public Function fun_Consultar_Campos_MANT_CARAPRED_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CAPRCODI, "
            stConsultaSQL += "CAPRDESC  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CARAPRED "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAPRESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CAPRDESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_Campos_MANT_CLASSECT_X_ESTADO")
            Return Nothing
        End Try
    End Function


End Class
