Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class cla_NOTARIA

    '=====================
    '*** CLASE NOTARIA ***
    '=====================

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
    Public Function fun_Consultar_MANT_NOTARIA() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_MANT_NOTARIA", conexion)
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
    Public Function fun_Consultar_CAMPOS_MANT_NOTARIA() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_CAMPOS_MANT_NOTARIA", conexion)
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
    ''' Funcion que busca el campo de la notaria en estado activo 
    ''' (Solo debuelve el campo de la notaria)
    ''' </summary>
    Public Function fun_Consultar_MANT_NOTARIA_X_ESTADO() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_MANT_NOTARIA_X_ESTADO", conexion)
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
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_NOTARIA(ByVal stNOTADEPA As String, _
                                              ByVal stNOTAMUNI As String, _
                                              ByVal stNOTACODI As String, _
                                              ByVal stNOTADESC As String, _
                                              ByVal stNOTAESTA As String) As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("insertar_MANT_NOTARIA", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@NOTADEPA", SqlDbType.NChar, 2).Value = stNOTADEPA
            ejecutar.Parameters.Add("@NOTAMUNI", SqlDbType.NChar, 3).Value = stNOTAMUNI
            ejecutar.Parameters.Add("@NOTACODI", SqlDbType.NChar, 5).Value = stNOTACODI
            ejecutar.Parameters.Add("@NOTADESC", SqlDbType.NChar, 50).Value = stNOTADESC
            ejecutar.Parameters.Add("@NOTAESTA", SqlDbType.NChar, 10).Value = stNOTAESTA

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
    Public Function fun_Eliminar_MANT_NOTARIA(ByVal inNOTAIDRE As Integer) As Boolean


        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("eliminar_MANT_NOTARIA", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@NOTAIDRE", SqlDbType.Int, 4).Value = inNOTAIDRE

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
    Public Function fun_Actualizar_MANT_NOTARIA(ByVal inNOTAIDRE As Integer, _
                                                ByVal stNOTADEPA As String, _
                                                ByVal stNOTAMUNI As String, _
                                                ByVal stNOTACODI As String, _
                                                ByVal stNOTADESC As String, _
                                                ByVal stNOTAESTA As String) As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("actualizar_MANT_NOTARIA", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@NOTAIDRE", SqlDbType.Int, 4).Value = inNOTAIDRE
            ejecutar.Parameters.Add("@NOTADEPA", SqlDbType.NChar, 2).Value = stNOTADEPA
            ejecutar.Parameters.Add("@NOTAMUNI", SqlDbType.NChar, 3).Value = stNOTAMUNI
            ejecutar.Parameters.Add("@NOTACODI", SqlDbType.NChar, 5).Value = stNOTACODI
            ejecutar.Parameters.Add("@NOTADESC", SqlDbType.NChar, 50).Value = stNOTADESC
            ejecutar.Parameters.Add("@NOTAESTA", SqlDbType.NChar, 10).Value = stNOTAESTA

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
    Public Function fun_Buscar_ID_MANT_NOTARIA(ByVal Id As Integer) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_ID_MANT_NOTARIA", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@NOTAIDRE", SqlDbType.Int, 4).Value = Id

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
    ''' Función que busca el CÓDIGO del registro para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_NOTARIA(ByVal IdNotaria As String) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_CODIGO_MANT_NOTARIA", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@NOTACODI", SqlDbType.Char, 5).Value = IdNotaria

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
    ''' Función que busca el DEPARTAMENTO, MUNICIPIO Y CÓDIGO DE NOTARIA para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_CODIGO_MANT_NOTARIA(ByVal IdDepartamento As String, _
                                                                              ByVal IdMunicipio As String, _
                                                                              ByVal IdNotaria As String) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_CODIGO_MANT_NOTARIA", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@NOTADEPA", SqlDbType.Char, 2).Value = IdDepartamento
            ejecutar.Parameters.Add("@NOTAMUNI", SqlDbType.Char, 3).Value = IdMunicipio
            ejecutar.Parameters.Add("@NOTACODI", SqlDbType.Char, 5).Value = IdNotaria

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
