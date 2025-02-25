Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class cla_CATESUEL

    '================================
    '*** CLASE CATEGORIA DE SUELO ***
    '================================

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
    Public Function fun_Consultar_MANT_CATESUEL() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_MANT_CATESUEL", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure
            adapter.SelectCommand = ejecutar
            adapter.Fill(dt)
            conexion.Close()

            Return dt

        Catch ex As Exception

            conexion.Close()
            dt = Nothing
            Return dt

        End Try

    End Function

    '''   <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_CATESUEL() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_CAMPOS_MANT_CATESUEL", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure
            adapter.SelectCommand = ejecutar
            adapter.Fill(dt)
            conexion.Close()

            Return dt

        Catch ex As Exception

            conexion.Close()
            dt = Nothing
            Return dt

        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_CATESUEL_X_ESTADO() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_MANT_CATESUEL_X_ESTADO", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure
            adapter.SelectCommand = ejecutar
            adapter.Fill(dt)
            conexion.Close()

            Return dt

        Catch ex As Exception

            conexion.Close()
            dt = Nothing
            Return dt

        End Try

    End Function

    ''' <summary>
    ''' Consulta parametrizada de acuerdo a los datos solicitados por el usuario.
    ''' </summary>
    Public Function fun_Consulta_Parametrizada_MANT_CATESUEL(ByVal stCASUCODI As String, _
                                                             ByVal stCASUDESC As String, _
                                                             ByVal stCASUESTA As String) As DataTable
        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()

            'ejecutar = New SqlCommand("Consulta_Parametrizada_MANT_CALIPROP", conexion)

            If stCASUCODI = "" Then
                ejecutar = New SqlCommand("select * from MANT_CATESUEL where CASUCODI like '" & stCASUCODI & "%'and CASUDESC like '" & stCASUDESC & "%' and CASUESTA like '" & stCASUESTA & "%'", conexion)
            Else
                ejecutar = New SqlCommand("select * from MANT_CATESUEL where CASUCODI = '" & stCASUCODI & "'and CASUDESC like '" & stCASUDESC & "%' and CASUESTA like '" & stCASUESTA & "%'", conexion)
            End If

            ejecutar.CommandTimeout = 360

            'ejecutar.Parameters.Add("@CAPRCODI", SqlDbType.NChar, 9).Value = stCAPRCODI
            'ejecutar.Parameters.Add("@CAPRDESC", SqlDbType.NChar, 50).Value = stCAPRDESC
            'ejecutar.Parameters.Add("@CAPRESTA", SqlDbType.NChar, 10).Value = stCAPRESTA

            ejecutar.CommandType = CommandType.Text
            'ejecutar.CommandType = CommandType.StoredProcedure

            adapter.SelectCommand = ejecutar
            adapter.Fill(dt)
            conexion.Close()
            Return dt

        Catch ex As Exception

            conexion.Close()
            dt = Nothing
            Return dt

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_CATESUEL(ByVal inCASUCODI As Integer, _
                                               ByVal stCASUDESC As String, _
                                               ByVal stCASUESTA As String) As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("insertar_MANT_CATESUEL", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@CASUCODI", SqlDbType.Int, 4).Value = inCASUCODI
            ejecutar.Parameters.Add("@CASUDESC", SqlDbType.NChar, 50).Value = stCASUDESC
            ejecutar.Parameters.Add("@CASUESTA", SqlDbType.NChar, 10).Value = stCASUESTA

            reader = ejecutar.ExecuteReader
            conexion.Close()

            reader = Nothing

        Catch ex As Exception

            conexion.Close()
            reader = Nothing
            Return False

        End Try

        Return True

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CATESUEL(ByVal inCASUIDRE As Integer) As Boolean


        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("eliminar_MANT_CATESUEL", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@CASUIDRE", SqlDbType.Int, 4).Value = inCASUIDRE

            reader = ejecutar.ExecuteReader
            conexion.Close()
            reader = Nothing

        Catch ex As Exception

            conexion.Close()
            reader = Nothing
            Return False

        End Try

        Return True

    End Function

    ''' <summary>
    ''' Función que Modifica o actualiza el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_CATESUEL(ByVal inCASUIDRE As Integer, _
                                                 ByVal inCASUCODI As Integer, _
                                                 ByVal stCASUDESC As String, _
                                                 ByVal stCASUESTA As String) As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("actualizar_MANT_CATESUEL", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@CASUIDRE", SqlDbType.Int, 4).Value = inCASUIDRE
            ejecutar.Parameters.Add("@CASUCODI", SqlDbType.Int, 4).Value = inCASUCODI
            ejecutar.Parameters.Add("@CASUDESC", SqlDbType.NChar, 50).Value = stCASUDESC
            ejecutar.Parameters.Add("@CASUESTA", SqlDbType.NChar, 10).Value = stCASUESTA

            reader = ejecutar.ExecuteReader
            conexion.Close()

            reader = Nothing

        Catch ex As Exception

            conexion.Close()
            reader = Nothing
            Return False

        End Try

        Return True

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CATESUEL(ByVal Id As Integer) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_ID_MANT_CATESUEL", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@CASUIDRE", SqlDbType.Int, 4).Value = Id

            ejecutar.CommandType = CommandType.StoredProcedure
            adapter.SelectCommand = ejecutar
            adapter.Fill(dt)
            conexion.Close()
            Return dt

        Catch ex As Exception

            conexion.Close()
            dt = Nothing
            Return dt

        End Try
    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CATEGORIA DE SUELO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_CATESUEL(ByVal IdCodigo As Integer) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_CODIGO_MANT_CATESUEL", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@CASUCODI", SqlDbType.Int, 4).Value = IdCodigo

            ejecutar.CommandType = CommandType.StoredProcedure
            adapter.SelectCommand = ejecutar
            adapter.Fill(dt)
            conexion.Close()
            Return dt

        Catch ex As Exception

            conexion.Close()
            dt = Nothing
            Return dt

        End Try

    End Function


End Class
