Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_VIGENCIA

    '======================
    '*** CLASE VIGENCIA ***
    '======================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_VIGENCIA() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_VIGENCIA")

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
    Public Function fun_Consultar_CAMPOS_VIGENCIA() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_VIGENCIA")

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
    Public Function fun_Consultar_VIGENCIA_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_VIGENCIA_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_VIGENCIA(ByVal inVIGECODI As Integer, _
                                               ByVal stVIGEDESC As String, _
                                               ByVal stVIGEESTA As String) As Boolean


        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inVIGECODI As New SqlParameter("@VIGECODI", inVIGECODI)
            Dim o_stVIGEDESC As New SqlParameter("@VIGEDESC", stVIGEDESC)
            Dim o_stVIGEESTA As New SqlParameter("@VIGEESTA", stVIGEESTA)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_inVIGECODI
            VecParametros(1) = o_stVIGEDESC
            VecParametros(2) = o_stVIGEESTA

            objenq.ActualizarDb(VecParametros, "insertar_VIGENCIA")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_VIGENCIA(ByVal inVIGEIDRE As Integer) As Boolean


        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inVIGEIDRE As New SqlParameter("@VIGEIDRE", inVIGEIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inVIGEIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_VIGENCIA") Then
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
    Public Function fun_Actualizar_VIGENCIA(ByVal inVIGEIDRE As Integer, _
                                                 ByVal inVIGECODI As Integer, _
                                                 ByVal stVIGEDESC As String, _
                                                 ByVal stVIGEESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inVIGEIDRE As New SqlParameter("@VIGEIDRE", inVIGEIDRE)
            Dim o_inVIGECODI As New SqlParameter("@VIGECODI", inVIGECODI)
            Dim o_stVIGEDESC As New SqlParameter("@VIGEDESC", stVIGEDESC)
            Dim o_stVIGEESTA As New SqlParameter("@VIGEESTA", stVIGEESTA)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_inVIGEIDRE
            VecParametros(1) = o_inVIGECODI
            VecParametros(2) = o_stVIGEDESC
            VecParametros(3) = o_stVIGEESTA

            objenq.ActualizarDb(VecParametros, "actualizar_VIGENCIA")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_VIGENCIA(ByVal inVIGEIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inVIGEIDRE As New SqlParameter("@VIGEIDRE", inVIGEIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inVIGEIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_VIGENCIA")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try
      
    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA VIGENCIA para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_VIGENCIA(ByVal inVIGECODI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inVIGECODI As New SqlParameter("@VIGECODI", inVIGECODI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inVIGECODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_VIGENCIA")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try
      
    End Function

    ''' <summary>
    ''' Carga el codigo y la descripcion de los registros activos que carga el combobox
    ''' </summary>
    Public Function fun_Consultar_campos_MANT_VIGENCIA_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "VIGECODI, "
            stConsultaSQL += "VIGEDESC  "


            stConsultaSQL += "FROM "
            stConsultaSQL += "VIGENCIA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "VIGEESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "VIGECODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_campos_MANT_VIGENCIA_X_ESTADO")
            Return Nothing
        End Try

    End Function

End Class
