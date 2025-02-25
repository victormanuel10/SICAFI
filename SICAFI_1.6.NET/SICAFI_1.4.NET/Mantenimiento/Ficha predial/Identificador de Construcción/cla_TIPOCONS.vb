Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class cla_TIPOCONS

    '==================================
    '*** CLASE TIPO DE CONSTRUCCIÓN ***
    '==================================

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
    Public Function fun_Consultar_MANT_TIPOCONS() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_MANT_TIPOCONS", conexion)
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
    Public Function fun_Consultar_CAMPOS_MANT_TIPOCONS() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_CAMPOS_MANT_TIPOCONS", conexion)
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
    Public Function fun_Consultar_MANT_TIPOCONS_X_ESTADO() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_MANT_TIPOCONS_X_ESTADO", conexion)
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
    Public Function fun_Insertar_MANT_TIPOCONS(ByVal stTICODEPA As String, _
                                                ByVal stTICOMUNI As String, _
                                                ByVal inTICOCLCO As Integer, _
                                                ByVal stTICOTIPO As String, _
                                                ByVal inTICOCODI As Integer, _
                                                ByVal stTICODESC As String, _
                                                ByVal inTICOPUNT As Integer, _
                                                ByVal inTICOPUMA As Integer, _
                                                ByVal doTICOFAC1 As Double, _
                                                ByVal doTICOFAC2 As Double, _
                                                ByVal stTICOMOLI As String, _
                                                ByVal boTICOARCO As Boolean, _
                                                ByVal stTICOESTA As String, _
                                                ByVal inTICOCLSE As Integer) As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("insertar_MANT_TIPOCONS", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@TICODEPA", SqlDbType.NChar, 2).Value = stTICODEPA
            ejecutar.Parameters.Add("@TICOMUNI", SqlDbType.NChar, 3).Value = stTICOMUNI
            ejecutar.Parameters.Add("@TICOCLCO", SqlDbType.Int, 4).Value = inTICOCLCO
            ejecutar.Parameters.Add("@TICOTIPO", SqlDbType.NChar, 1).Value = stTICOTIPO
            ejecutar.Parameters.Add("@TICOCODI", SqlDbType.Int, 4).Value = inTICOCODI
            ejecutar.Parameters.Add("@TICODESC", SqlDbType.NChar, 50).Value = stTICODESC
            ejecutar.Parameters.Add("@TICOPUNT", SqlDbType.Int, 4).Value = inTICOPUNT
            ejecutar.Parameters.Add("@TICOPUMA", SqlDbType.Int, 4).Value = inTICOPUMA
            ejecutar.Parameters.Add("@TICOFAC1", SqlDbType.Float, 8).Value = doTICOFAC1
            ejecutar.Parameters.Add("@TICOFAC2", SqlDbType.Float, 8).Value = doTICOFAC2
            ejecutar.Parameters.Add("@TICOMOLI", SqlDbType.NChar, 20).Value = stTICOMOLI
            ejecutar.Parameters.Add("@TICOARCO", SqlDbType.Bit, 1).Value = boTICOARCO
            ejecutar.Parameters.Add("@TICOESTA", SqlDbType.NChar, 10).Value = stTICOESTA
            ejecutar.Parameters.Add("@TICOCLSE", SqlDbType.Int, 4).Value = inTICOCLSE

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
    Public Function fun_Eliminar_MANT_TIPOCONS(ByVal inTICOIDRE As Integer) As Boolean


        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("eliminar_MANT_TIPOCONS", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@TICOIDRE", SqlDbType.Int, 4).Value = inTICOIDRE

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
    Public Function fun_Actualizar_MANT_TIPOCONS(ByVal inTICOIDRE As Integer, _
                                                ByVal stTICODEPA As String, _
                                                ByVal stTICOMUNI As String, _
                                                ByVal inTICOCLCO As Integer, _
                                                ByVal stTICOTIPO As String, _
                                                ByVal inTICOCODI As Integer, _
                                                ByVal stTICODESC As String, _
                                                ByVal inTICOPUNT As Integer, _
                                                ByVal inTICOPUMA As Integer, _
                                                ByVal doTICOFAC1 As Double, _
                                                ByVal doTICOFAC2 As Double, _
                                                ByVal stTICOMOLI As String, _
                                                ByVal boTICOARCO As Boolean, _
                                                ByVal stTICOESTA As String, _
                                                ByVal inTICOCLSE As Integer) As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("actualizar_MANT_TIPOCONS", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@TICOIDRE", SqlDbType.Int, 4).Value = inTICOIDRE
            ejecutar.Parameters.Add("@TICODEPA", SqlDbType.NChar, 2).Value = stTICODEPA
            ejecutar.Parameters.Add("@TICOMUNI", SqlDbType.NChar, 3).Value = stTICOMUNI
            ejecutar.Parameters.Add("@TICOCLCO", SqlDbType.Int, 4).Value = inTICOCLCO
            ejecutar.Parameters.Add("@TICOTIPO", SqlDbType.NChar, 1).Value = stTICOTIPO
            ejecutar.Parameters.Add("@TICOCODI", SqlDbType.Int, 4).Value = inTICOCODI
            ejecutar.Parameters.Add("@TICODESC", SqlDbType.NChar, 50).Value = stTICODESC
            ejecutar.Parameters.Add("@TICOPUNT", SqlDbType.Int, 4).Value = inTICOPUNT
            ejecutar.Parameters.Add("@TICOPUMA", SqlDbType.Int, 4).Value = inTICOPUMA
            ejecutar.Parameters.Add("@TICOFAC1", SqlDbType.Float, 8).Value = doTICOFAC1
            ejecutar.Parameters.Add("@TICOFAC2", SqlDbType.Float, 8).Value = doTICOFAC2
            ejecutar.Parameters.Add("@TICOMOLI", SqlDbType.NChar, 20).Value = stTICOMOLI
            ejecutar.Parameters.Add("@TICOARCO", SqlDbType.Bit, 1).Value = boTICOARCO
            ejecutar.Parameters.Add("@TICOESTA", SqlDbType.NChar, 10).Value = stTICOESTA
            ejecutar.Parameters.Add("@TICOCLSE", SqlDbType.Int, 4).Value = inTICOCLSE

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
    Public Function fun_Buscar_ID_MANT_TIPOCONS(ByVal Id As Integer) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_ID_MANT_TIPOCONS", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@TICOIDRE", SqlDbType.Int, 4).Value = Id

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
    Public Function fun_Buscar_CODIGO_MANT_TIPOCONS(ByVal IdCodigo As Integer) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_MANT_CODIGO_TIPOCONS", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@TICOCODI", SqlDbType.Int, 4).Value = IdCodigo

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
    ''' Función que busca el DEPARTAMENTO, MUNICIPIO, CLASE, TIPO  Y CODIGO DE IDENTIFICADOR
    ''' para que no se guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_CLASE_Y_TIPO_Y_SECTOR_Y_CODIGO_MANT_TIPOCONS(ByVal IdDepartamento As String, _
                                                                                 ByVal IdMunicipio As String, _
                                                                                 ByVal IdClaseConstruccion As Integer, _
                                                                                 ByVal Idtipo As String, _
                                                                                 ByVal IdSector As Integer, _
                                                                                 ByVal IdIdentificador As Integer) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_CLASE_Y_TIPO_Y_SECTOR_Y_CODIGO_MANT_TIPOCONS", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@TICODEPA", SqlDbType.Char, 2).Value = IdDepartamento
            ejecutar.Parameters.Add("@TICOMUNI", SqlDbType.Char, 3).Value = IdMunicipio
            ejecutar.Parameters.Add("@TICOCLCO", SqlDbType.Int, 4).Value = IdClaseConstruccion
            ejecutar.Parameters.Add("@TICOTIPO", SqlDbType.Char, 1).Value = Idtipo
            ejecutar.Parameters.Add("@TICOCLSE", SqlDbType.Int, 4).Value = IdSector
            ejecutar.Parameters.Add("@TICOCODI", SqlDbType.Int, 4).Value = IdIdentificador

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
