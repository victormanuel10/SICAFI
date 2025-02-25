Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class cla_USUARIO

    '=====================
    '*** CLASE USUARIO ***
    '=====================

    Private ejecutar As New SqlCommand
    Private conexion As New SqlConnection
    Private adapter As New SqlDataAdapter
    Private ds As New DataSet
    Private dt As New DataTable
    Private reader As SqlDataReader

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_USUARIO() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_USUARIO", conexion)
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
    Public Function fun_Consultar_USUARIO_X_ESTADO() As DataTable

        Try

            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.Settings.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("Consultar_USUARIO_X_ESTADO", conexion)
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
    Public Function fun_Insertar_USUARIO(ByVal stUSUANUDO As String, _
                                         ByVal inUSUATIDO As Integer, _
                                         ByVal inUSUACAPR As Integer, _
                                         ByVal inUSUASEXO As Integer, _
                                         ByVal stUSUANOMB As String, _
                                         ByVal stUSUAPRAP As String, _
                                         ByVal stUSUASEAP As String, _
                                         ByVal stUSUASICO As String, _
                                         ByVal stUSUATEL1 As String, _
                                         ByVal stUSUATEL2 As String, _
                                         ByVal stUSUAFAX1 As String, _
                                         ByVal stUSUADIRE As String, _
                                         ByVal stUSUAESTA As String, _
                                         ByVal stUSUAOBSE As String) As Boolean

        ' *** INSTANCIA LA FECHA Y HORA ***
        Dim dateNow As DateTime = DateTime.Now

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("insertar_USUARIO", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@USUANUDO", SqlDbType.NChar, 15).Value = stUSUANUDO
            ejecutar.Parameters.Add("@USUATIDO", SqlDbType.Int, 4).Value = inUSUATIDO
            ejecutar.Parameters.Add("@USUACAPR", SqlDbType.Int, 4).Value = inUSUACAPR
            ejecutar.Parameters.Add("@USUASEXO", SqlDbType.Int, 4).Value = inUSUASEXO
            ejecutar.Parameters.Add("@USUANOMB", SqlDbType.NChar, 20).Value = stUSUANOMB
            ejecutar.Parameters.Add("@USUAPRAP", SqlDbType.NChar, 15).Value = stUSUAPRAP
            ejecutar.Parameters.Add("@USUASEAP", SqlDbType.NChar, 15).Value = stUSUASEAP
            ejecutar.Parameters.Add("@USUASICO", SqlDbType.NChar, 20).Value = stUSUASICO
            ejecutar.Parameters.Add("@USUATEL1", SqlDbType.NChar, 15).Value = stUSUATEL1
            ejecutar.Parameters.Add("@USUATEL2", SqlDbType.NChar, 15).Value = stUSUATEL2
            ejecutar.Parameters.Add("@USUAFAX1", SqlDbType.NChar, 15).Value = stUSUAFAX1
            ejecutar.Parameters.Add("@USUADIRE", SqlDbType.NChar, 49).Value = stUSUADIRE
            ejecutar.Parameters.Add("@USUAESTA", SqlDbType.NChar, 10).Value = stUSUAESTA
            ejecutar.Parameters.Add("@USUAUSIN", SqlDbType.NChar, 50).Value = vp_usuario
            ejecutar.Parameters.Add("@USUAUSMO", SqlDbType.NChar, 50).Value = ""
            ejecutar.Parameters.Add("@USUAFEIN", SqlDbType.DateTime).Value = DateTime.Now.ToString()    'Fecha y hora
            ejecutar.Parameters.Add("@USUAFEMO", SqlDbType.DateTime).Value = DateTime.Now.ToString()    'Fecha y hora
            ejecutar.Parameters.Add("@USUAOBSE", SqlDbType.NChar, 1000).Value = stUSUAOBSE

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
    Public Function fun_Eliminar_USUARIO(ByVal inUSUAIDRE As Integer) As Boolean


        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("eliminar_USUARIO", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@USUAIDRE", SqlDbType.Int, 4).Value = inUSUAIDRE

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
    Public Function fun_Actualizar_USUARIO(ByVal inUSUAIDRE As Integer, _
                                           ByVal stUSUANUDO As String, _
                                           ByVal inUSUATIDO As Integer, _
                                           ByVal inUSUACAPR As Integer, _
                                           ByVal inUSUASEXO As Integer, _
                                           ByVal stUSUANOMB As String, _
                                           ByVal stUSUAPRAP As String, _
                                           ByVal stUSUASEAP As String, _
                                           ByVal stUSUASICO As String, _
                                           ByVal stUSUATEL1 As String, _
                                           ByVal stUSUATEL2 As String, _
                                           ByVal stUSUAFAX1 As String, _
                                           ByVal stUSUADIRE As String, _
                                           ByVal stUSUAESTA As String, _
                                           ByVal stUSUAUSIN As String, _
                                           ByVal daUSUAFEIN As Date, _
                                           ByVal stUSUAOBSE As String) As Boolean

        ' *** INSTANCIA LA FECHA Y HORA ***
        Dim dateNow As DateTime = DateTime.Now

        Try
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("actualizar_USUARIO", conexion)
            ejecutar.CommandTimeout = 360
            ejecutar.CommandType = CommandType.StoredProcedure

            ejecutar.Parameters.Add("@USUAIDRE", SqlDbType.Int, 4).Value = inUSUAIDRE
            ejecutar.Parameters.Add("@USUANUDO", SqlDbType.NChar, 15).Value = stUSUANUDO
            ejecutar.Parameters.Add("@USUATIDO", SqlDbType.Int, 4).Value = inUSUATIDO
            ejecutar.Parameters.Add("@USUACAPR", SqlDbType.Int, 4).Value = inUSUACAPR
            ejecutar.Parameters.Add("@USUASEXO", SqlDbType.Int, 4).Value = inUSUASEXO
            ejecutar.Parameters.Add("@USUANOMB", SqlDbType.NChar, 20).Value = stUSUANOMB
            ejecutar.Parameters.Add("@USUAPRAP", SqlDbType.NChar, 15).Value = stUSUAPRAP
            ejecutar.Parameters.Add("@USUASEAP", SqlDbType.NChar, 15).Value = stUSUASEAP
            ejecutar.Parameters.Add("@USUASICO", SqlDbType.NChar, 20).Value = stUSUASICO
            ejecutar.Parameters.Add("@USUATEL1", SqlDbType.NChar, 15).Value = stUSUATEL1
            ejecutar.Parameters.Add("@USUATEL2", SqlDbType.NChar, 15).Value = stUSUATEL2
            ejecutar.Parameters.Add("@USUAFAX1", SqlDbType.NChar, 15).Value = stUSUAFAX1
            ejecutar.Parameters.Add("@USUADIRE", SqlDbType.NChar, 49).Value = stUSUADIRE
            ejecutar.Parameters.Add("@USUAESTA", SqlDbType.NChar, 10).Value = stUSUAESTA
            ejecutar.Parameters.Add("@USUAUSIN", SqlDbType.NChar, 50).Value = stUSUAUSIN
            ejecutar.Parameters.Add("@USUAUSMO", SqlDbType.NChar, 50).Value = vp_usuario
            ejecutar.Parameters.Add("@USUAFEIN", SqlDbType.DateTime).Value = daUSUAFEIN
            ejecutar.Parameters.Add("@USUAFEMO", SqlDbType.DateTime).Value = DateTime.Now.ToString()    'Fecha y hora
            ejecutar.Parameters.Add("@USUAOBSE", SqlDbType.NChar, 1000).Value = stUSUAOBSE

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
    Public Function fun_Buscar_ID_USUARIO(ByVal Id As Integer) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_ID_USUARIO", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@USUAIDRE", SqlDbType.Int, 4).Value = Id

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
    ''' Función que busca el CÓDIGO DEL USUARIO (Documento de identidad)
    ''' para que no se guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_USUARIO(ByVal IdCodigo As String) As DataTable

        Try
            dt = New DataTable
            adapter = New SqlDataAdapter
            conexion = New SqlConnection(Global.SICAFI.My.MySettings.Default.SICAFIConnectionString1)
            conexion.Open()
            ejecutar = New SqlCommand("buscar_CODIGO_USUARIO", conexion)
            ejecutar.CommandTimeout = 360

            ejecutar.Parameters.Add("@USUANUDO", SqlDbType.NChar, 14).Value = IdCodigo

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
