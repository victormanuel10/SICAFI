Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class cla_ZONAECON

    '============================
    '*** CLASE ZONA ECONÓMICA ***
    '============================

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
    Public Function fun_Consultar_MANT_ZONAECON() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_MANT_ZONAECON", conexion)
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
    Public Function fun_Consultar_CAMPOS_MANT_ZONAECON() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_CAMPOS_MANT_ZONAECON", conexion)
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
    Public Function fun_Consultar_MANT_ZONAECON_X_ESTADO() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_MANT_ZONAECON_X_ESTADO", conexion)
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
    Public Function fun_Insertar_MANT_ZONAECON(ByVal stZOECDEPA As String, _
                                               ByVal stZOECMUNI As String, _
                                               ByVal inZOECCLSE As Integer, _
                                               ByVal inZOECCODI As Integer, _
                                               ByVal stZOECDESC As String, _
                                               ByVal inZOECVALO As Integer, _
                                               ByVal stZOECESTA As String) As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("insertar_MANT_ZONAECON", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@ZOECDEPA", SqlDbType.NChar, 2).Value = stZOECDEPA
            ejecutar.Parameters.Add("@ZOECMUNI", SqlDbType.NChar, 3).Value = stZOECMUNI
            ejecutar.Parameters.Add("@ZOECCLSE", SqlDbType.Int, 4).Value = inZOECCLSE
            ejecutar.Parameters.Add("@ZOECCODI", SqlDbType.Int, 4).Value = inZOECCODI
            ejecutar.Parameters.Add("@ZOECDESC", SqlDbType.NChar, 50).Value = stZOECDESC
            ejecutar.Parameters.Add("@ZOECVALO", SqlDbType.Int, 4).Value = inZOECVALO
            ejecutar.Parameters.Add("@ZOECESTA", SqlDbType.NChar, 10).Value = stZOECESTA

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
    Public Function fun_Eliminar_MANT_ZONAECON(ByVal inZOECIDRE As Integer) As Boolean


        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("eliminar_MANT_ZONAECON", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@ZOECIDRE", SqlDbType.Int, 4).Value = inZOECIDRE

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
    Public Function fun_Actualizar_MANT_ZONAECON(ByVal inZOECIDRE As Integer, _
                                                 ByVal stZOECDEPA As String, _
                                                 ByVal stZOECMUNI As String, _
                                                 ByVal inZOECCLSE As Integer, _
                                                 ByVal inZOECCODI As Integer, _
                                                 ByVal stZOECDESC As String, _
                                                 ByVal inZOECVALO As Integer, _
                                                 ByVal stZOECESTA As String) As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("actualizar_MANT_ZONAECON", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@ZOECIDRE", SqlDbType.Int, 4).Value = inZOECIDRE
            ejecutar.Parameters.Add("@ZOECDEPA", SqlDbType.NChar, 2).Value = stZOECDEPA
            ejecutar.Parameters.Add("@ZOECMUNI", SqlDbType.NChar, 3).Value = stZOECMUNI
            ejecutar.Parameters.Add("@ZOECCLSE", SqlDbType.Int, 4).Value = inZOECCLSE
            ejecutar.Parameters.Add("@ZOECCODI", SqlDbType.Int, 4).Value = inZOECCODI
            ejecutar.Parameters.Add("@ZOECDESC", SqlDbType.NChar, 50).Value = stZOECDESC
            ejecutar.Parameters.Add("@ZOECVALO", SqlDbType.Int, 4).Value = inZOECVALO
            ejecutar.Parameters.Add("@ZOECESTA", SqlDbType.NChar, 10).Value = stZOECESTA

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
    Public Function fun_Buscar_ID_MANT_ZONAECON(ByVal Id As Integer) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_ID_MANT_ZONAECON", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@ZOECIDRE", SqlDbType.Int, 4).Value = Id

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
    Public Function fun_Buscar_CODIGO_MANT_ZONAECON(ByVal IdZonaEconomica As Integer) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_CODIGO_MANT_ZONAECON", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@ZOECCODI", SqlDbType.Int, 4).Value = IdZonaEconomica

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
    ''' Función que busca el DEPARTAMENTO, MUNICIPIO, SECTOR Y CÓDIGO DE ZONA ECONOMICA
    ''' para que no se guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAECON(ByVal IdDepartamento As String, _
                                                                              ByVal IdMunicipio As String, _
                                                                              ByVal IdClaseOSector As Integer, _
                                                                              ByVal IdZonaEconomica As Integer) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAECON", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@ZOECDEPA", SqlDbType.Char, 2).Value = IdDepartamento
            ejecutar.Parameters.Add("@ZOECMUNI", SqlDbType.Char, 3).Value = IdMunicipio
            ejecutar.Parameters.Add("@ZOECCLSE", SqlDbType.Int, 4).Value = IdClaseOSector
            ejecutar.Parameters.Add("@ZOECCODI", SqlDbType.Int, 4).Value = IdZonaEconomica

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
