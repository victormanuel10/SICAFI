Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CLASCONS

    '===================================
    '*** CLASE CLASE DE CONSTRUCCIÓN ***
    '===================================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CLASCONS() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_CLASCONS")

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
    Public Function fun_Consultar_CAMPOS_MANT_CLASCONS() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_MANT_CLASCONS")

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
    Public Function fun_Consultar_MANT_CLASCONS_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASCONS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLCOESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLCOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_CLASCONS(ByVal inCLCOCODI As Integer, _
                                               ByVal stCLCODESC As String, _
                                               ByVal stCLCOESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inCLCOCODI As New SqlParameter("@CLCOCODI", inCLCOCODI)
            Dim o_stCLCODESC As New SqlParameter("@CLCODESC", stCLCODESC)
            Dim o_stCLCOESTA As New SqlParameter("@CLCOESTA", stCLCOESTA)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_inCLCOCODI
            VecParametros(1) = o_stCLCODESC
            VecParametros(2) = o_stCLCOESTA

            objenq.ActualizarDb(VecParametros, "insertar_MANT_CLASCONS")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CLASCONS(ByVal inCLCOIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inCLCOIDRE As New SqlParameter("@CLCOIDRE", inCLCOIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCLCOIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_MANT_CLASCONS") Then
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
    Public Function fun_Actualizar_MANT_CLASCONS(ByVal inCLCOIDRE As Integer, _
                                                 ByVal inCLCOCODI As Integer, _
                                                 ByVal stCLCODESC As String, _
                                                 ByVal stCLCOESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inCLCOIDRE As New SqlParameter("@CLCOIDRE", inCLCOIDRE)
            Dim o_inCLCOCODI As New SqlParameter("@CLCOCODI", inCLCOCODI)
            Dim o_stCLCODESC As New SqlParameter("@CLCODESC", stCLCODESC)
            Dim o_stCLCOESTA As New SqlParameter("@CLCOESTA", stCLCOESTA)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_inCLCOIDRE
            VecParametros(1) = o_inCLCOCODI
            VecParametros(2) = o_stCLCODESC
            VecParametros(3) = o_stCLCOESTA

            objenq.ActualizarDb(VecParametros, "actualizar_MANT_CLASCONS")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CLASCONS(ByVal inCLCOIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inCLCOIDRE As New SqlParameter("@CLCOIDRE", inCLCOIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCLCOIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_MANT_CLASCONS")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CLASE DE CONSTRUCCIÓN para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_CLASCONS(ByVal inCLCOCODI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inCLCOCODI As New SqlParameter("@CLCOCODI", inCLCOCODI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCLCOCODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_MANT_CLASCONS")

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
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CLASCONS(ByVal inCLCOIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inCLCOIDRE As New SqlParameter("@CLCOIDRE", inCLCOIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCLCOIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CLASCONS")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el identificador correspondiente a la clase de cons. seleccionado,
    ''' este se carga en el combobox correspondiente tipo de construccion.
    ''' </summary>
    Public Function fun_Buscar_TIPO_CONS_X_CLASE_CONS_MANT_TIPOCONS(ByVal inTICOCLCO As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inTICOCLCO As New SqlParameter("@TICOCLCO", inTICOCLCO)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inTICOCLCO

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_TIPO_CONS_X_CLASE_CONS_MANT_TIPOCONS")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

End Class
