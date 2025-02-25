Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_PERMUSUA

    '================================
    '*** CLASE PERMISO DE USUARIO ***
    '================================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_PERMUSUA() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_PERMUSUA")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_PERMUSUA() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_PERMUSUA")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que consulta los usarios agrupados por usuario 
    ''' </summary>
    Public Function fun_Consultar_USUARIO_AGRUPADO_PERMUSUA() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_USUARIO_AGRUPADO_PERMUSUA")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

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
            Dim objenq As New cExecuteNonQuery

            Dim o_stPEUSUSUA As New SqlParameter("@PEUSUSUA", stPEUSUSUA)
            Dim o_stPEUSETIQ As New SqlParameter("@PEUSETIQ", stPEUSETIQ)
            Dim o_boPEUSAGRE As New SqlParameter("@PEUSAGRE", boPEUSAGRE)
            Dim o_boPEUSMODI As New SqlParameter("@PEUSMODI", boPEUSMODI)
            Dim o_boPEUSELIM As New SqlParameter("@PEUSELIM", boPEUSELIM)

            Dim VecParametros(4) As SqlParameter

            VecParametros(0) = o_stPEUSUSUA
            VecParametros(1) = o_stPEUSETIQ
            VecParametros(2) = o_boPEUSAGRE
            VecParametros(3) = o_boPEUSMODI
            VecParametros(4) = o_boPEUSELIM

            objenq.ActualizarDb(VecParametros, "insertar_PERMUSUA")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_PERMUSUA(ByVal inPEUSIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inPEUSIDRE As New SqlParameter("@PEUSIDRE", inPEUSIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inPEUSIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_PERMUSUA") Then
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
    Public Function fun_Actualizar_PERMUSUA(ByVal inPEUSIDRE As Integer, _
                                                 ByVal stPEUSUSUA As String, _
                                                 ByVal stPEUSETIQ As String, _
                                                 ByVal boPEUSAGRE As Boolean, _
                                                 ByVal boPEUSMODI As Boolean, _
                                                 ByVal boPEUSELIM As Boolean) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inPEUSIDRE As New SqlParameter("@PEUSIDRE", inPEUSIDRE)
            Dim o_stPEUSUSUA As New SqlParameter("@PEUSUSUA", stPEUSUSUA)
            Dim o_stPEUSETIQ As New SqlParameter("@PEUSETIQ", stPEUSETIQ)
            Dim o_boPEUSAGRE As New SqlParameter("@PEUSAGRE", boPEUSAGRE)
            Dim o_boPEUSMODI As New SqlParameter("@PEUSMODI", boPEUSMODI)
            Dim o_boPEUSELIM As New SqlParameter("@PEUSELIM", boPEUSELIM)

            Dim VecParametros(5) As SqlParameter

            VecParametros(0) = o_inPEUSIDRE
            VecParametros(1) = o_stPEUSUSUA
            VecParametros(2) = o_stPEUSETIQ
            VecParametros(3) = o_boPEUSAGRE
            VecParametros(4) = o_boPEUSMODI
            VecParametros(5) = o_boPEUSELIM

            objenq.ActualizarDb(VecParametros, "actualizar_PERMUSUA")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_PERMUSUA(ByVal inPEUSIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inPEUSIDRE As New SqlParameter("@PEUSIDRE", inPEUSIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inPEUSIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_PERMUSUA")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO del registro para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_USUARIO_Y_ETIQUETA_PERMUSUA(ByVal stPEUSUSUA As String, _
                                                           ByVal stPEUSETIQ As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stPEUSUSUA As New SqlParameter("@PEUSUSUA", stPEUSUSUA)
            Dim o_stPEUSETIQ As New SqlParameter("@PEUSETIQ", stPEUSETIQ)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_stPEUSUSUA
            VecParametros(1) = o_stPEUSETIQ

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_USUARIO_Y_ETIQUETA_PERMUSUA")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca los permisos asignados al usuario para verificar cuales
    ''' etiquetas tiene avilitadas. (consulta en permiso de usuario)
    ''' </summary>
    Public Function fun_Buscar_USUARIO_PERMUSUA(ByVal stPEUSUSUA As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stPEUSUSUA As New SqlParameter("@PEUSUSUA", stPEUSUSUA)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stPEUSUSUA

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_USUARIO_PERMUSUA")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function
   
End Class
