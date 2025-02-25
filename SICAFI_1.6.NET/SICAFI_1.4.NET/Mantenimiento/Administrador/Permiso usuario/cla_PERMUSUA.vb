Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class cla_PERMUSUA

    '====================================
    '*** CLASE CALIDAD DE PROPIETARIO ***
    '====================================

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
    Public Function fun_Consultar_PERMUSUA() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_PERMUSUA", conexion)
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
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_PERMUSUA() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_CAMPOS_PERMUSUA", conexion)
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
    ''' Función que consulta los usarios agrupados por usuario 
    ''' </summary>
    Public Function fun_Consultar_USUARIO_AGRUPADO_PERMUSUA() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_USUARIO_AGRUPADO_PERMUSUA", conexion)
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
    Public Function fun_Insertar_PERMUSUA(ByVal stPEUSUSUA As String, _
                                          ByVal stPEUSETIQ As String, _
                                          ByVal boPEUSAGRE As Boolean, _
                                          ByVal boPEUSMODI As Boolean, _
                                          ByVal boPEUSELIM As Boolean) As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("insertar_PERMUSUA", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@PEUSUSUA", SqlDbType.NChar, 20).Value = stPEUSUSUA
            ejecutar.Parameters.Add("@PEUSETIQ", SqlDbType.NChar, 50).Value = stPEUSETIQ
            ejecutar.Parameters.Add("@PEUSAGRE", SqlDbType.Bit, 1).Value = boPEUSAGRE
            ejecutar.Parameters.Add("@PEUSMODI", SqlDbType.Bit, 1).Value = boPEUSMODI
            ejecutar.Parameters.Add("@PEUSELIM", SqlDbType.Bit, 1).Value = boPEUSELIM

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
    Public Function fun_Eliminar_PERMUSUA(ByVal inPEUSIDRE As Integer) As Boolean


        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("eliminar_PERMUSUA", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@PEUSIDRE", SqlDbType.Int, 4).Value = inPEUSIDRE

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
    Public Function fun_Actualizar_PERMUSUA(ByVal inPEUSIDRE As Integer, _
                                                 ByVal stPEUSUSUA As String, _
                                                 ByVal stPEUSETIQ As String, _
                                                 ByVal boPEUSAGRE As Boolean, _
                                                 ByVal boPEUSMODI As Boolean, _
                                                 ByVal boPEUSELIM As Boolean) As Boolean

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("actualizar_PERMUSUA", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@CAPRIDRE", SqlDbType.Int, 4).Value = inPEUSIDRE
            ejecutar.Parameters.Add("@PEUSUSUA", SqlDbType.NChar, 20).Value = stPEUSUSUA
            ejecutar.Parameters.Add("@PEUSETIQ", SqlDbType.NChar, 50).Value = stPEUSETIQ
            ejecutar.Parameters.Add("@PEUSAGRE", SqlDbType.Bit, 1).Value = boPEUSAGRE
            ejecutar.Parameters.Add("@PEUSMODI", SqlDbType.Bit, 1).Value = boPEUSMODI
            ejecutar.Parameters.Add("@PEUSELIM", SqlDbType.Bit, 1).Value = boPEUSELIM

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
    Public Function fun_Buscar_ID_PERMUSUA(ByVal Id As Integer) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_ID_PERMUSUA", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@PEUSIDRE", SqlDbType.Int, 4).Value = Id

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
    Public Function fun_Buscar_USUARIO_Y_ETIQUETA_PERMUSUA(ByVal IdUsuario As String, ByVal idEtiqueta As String) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Buscar_USUARIO_Y_ETIQUETA_PERMUSUA", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@PEUSUSUA", SqlDbType.NChar, 20).Value = IdUsuario
            ejecutar.Parameters.Add("@PEUSETIQ", SqlDbType.NChar, 50).Value = idEtiqueta

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
    ''' Función que busca los permisos asignados al usuario para verificar cuales
    ''' etiquetas tiene avilitadas. (consulta en permiso de usuario)
    ''' </summary>
    Public Function fun_Buscar_USUARIO_PERMUSUA(ByVal IdUsuario As String) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_USUARIO_PERMUSUA", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@PEUSUSUA", SqlDbType.Char, 20).Value = IdUsuario

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
