Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CATESUEL

    '================================
    '*** CLASE CATEGORIA DE SUELO ***
    '================================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CATESUEL() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_CATESUEL")

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
    Public Function fun_Consultar_CAMPOS_MANT_CATESUEL() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_MANT_CATESUEL")

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
    Public Function fun_Consultar_MANT_CATESUEL_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_CATESUEL_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    'º'' <summary>
    'º'' Consulta parametrizada de acuerdo a los datos solicitados por el usuario.
    'º'' </summary>
    'Public Function fun_Consulta_Parametrizada_MANT_CATESUEL(ByVal stCASUCODI As String, _
    '                                                         ByVal stCASUDESC As String, _
    '                                                         ByVal stCASUESTA As String) As DataTable
    '    Try
    '        dt = New DataTable
    '        adapter = New SqlDataAdapter
    '        'conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
    '        conexion.Open()

    '        'ejecutar = New SqlCommand("Consulta_Parametrizada_MANT_CALIPROP", conexion)

    '        If stCASUCODI = "" Then
    '            ejecutar = New SqlCommand("select * from MANT_CATESUEL where CASUCODI like '" & stCASUCODI & "%'and CASUDESC like '" & stCASUDESC & "%' and CASUESTA like '" & stCASUESTA & "%'", conexion)
    '        Else
    '            ejecutar = New SqlCommand("select * from MANT_CATESUEL where CASUCODI = '" & stCASUCODI & "'and CASUDESC like '" & stCASUDESC & "%' and CASUESTA like '" & stCASUESTA & "%'", conexion)
    '        End If

    '        ejecutar.CommandTimeout = 360

    '        'ejecutar.Parameters.Add("@CAPRCODI", SqlDbType.NChar, 9).Value = stCAPRCODI
    '        'ejecutar.Parameters.Add("@CAPRDESC", SqlDbType.NChar, 50).Value = stCAPRDESC
    '        'ejecutar.Parameters.Add("@CAPRESTA", SqlDbType.NChar, 10).Value = stCAPRESTA

    '        ejecutar.CommandType = CommandType.Text
    '        'ejecutar.CommandType = CommandType.StoredProcedure

    '        adapter.SelectCommand = ejecutar
    '        adapter.Fill(dt)
    '        conexion.Close()
    '        Return dt

    '    Catch ex As Exception

    '        conexion.Close()
    '        dt = Nothing
    '        Return dt

    '    End Try

    'End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_CATESUEL(ByVal inCASUCODI As Integer, _
                                               ByVal stCASUDESC As String, _
                                               ByVal stCASUESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inCASUCODI As New SqlParameter("@CASUCODI", inCASUCODI)
            Dim o_stCASUDESC As New SqlParameter("@CASUDESC", stCASUDESC)
            Dim o_stCASUESTA As New SqlParameter("@CASUESTA", stCASUESTA)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_inCASUCODI
            VecParametros(1) = o_stCASUDESC
            VecParametros(2) = o_stCASUESTA

            objenq.ActualizarDb(VecParametros, "insertar_MANT_CATESUEL")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CATESUEL(ByVal inCASUIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inCASUIDRE As New SqlParameter("@CASUIDRE", inCASUIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCASUIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_MANT_CATESUEL") Then
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
    Public Function fun_Actualizar_MANT_CATESUEL(ByVal inCASUIDRE As Integer, _
                                                 ByVal inCASUCODI As Integer, _
                                                 ByVal stCASUDESC As String, _
                                                 ByVal stCASUESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inCASUIDRE As New SqlParameter("@CASUIDRE", inCASUIDRE)
            Dim o_inCASUCODI As New SqlParameter("@CASUCODI", inCASUCODI)
            Dim o_stCASUDESC As New SqlParameter("@CASUDESC", stCASUDESC)
            Dim o_stCASUESTA As New SqlParameter("@CASUESTA", stCASUESTA)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_inCASUIDRE
            VecParametros(1) = o_inCASUCODI
            VecParametros(2) = o_stCASUDESC
            VecParametros(3) = o_stCASUESTA

            objenq.ActualizarDb(VecParametros, "actualizar_MANT_CATESUEL")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CATESUEL(ByVal inCASUIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inCAPRIDRE As New SqlParameter("@CASUIDRE", inCASUIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCAPRIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_MANT_CATESUEL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try
       
    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CATEGORIA DE SUELO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_CATESUEL(ByVal inCASUCODI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inCAPRCODI As New SqlParameter("@CASUCODI", inCASUCODI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCAPRCODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_MANT_CATESUEL")

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
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CATESUEL(ByVal inCASUIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inCASUIDRE As New SqlParameter("@CASUIDRE", inCASUIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCASUIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CATESUEL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Carga el codigo y la descripcion de los registros activos que carga el combobox
    ''' </summary>
    Public Function fun_Consultar_Campos_MANT_CATESUEL_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CASUCODI, "
            stConsultaSQL += "CASUDESC  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CATESUEL "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CASUESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CASUDESC "

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
