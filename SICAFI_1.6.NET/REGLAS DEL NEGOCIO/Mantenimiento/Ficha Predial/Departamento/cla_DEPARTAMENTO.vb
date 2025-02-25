Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_DEPARTAMENTO

    '==========================
    '*** CLASE DEPARTAMENTO ***
    '==========================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_DEPARTAMENTO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_DEPARTAMENTO")

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
    Public Function fun_Consultar_CAMPOS_MANT_DEPARTAMENTO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_MANT_DEPARTAMENTO")

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
    Public Function fun_Consultar_MANT_DEPARTAMENTO_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_DEPARTAMENTO_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try
       
    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_DEPARTAMENTO(ByVal stDEPACODI As String, _
                                                   ByVal stDEPADESC As String, _
                                                   ByVal stDEPAESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stDEPACODI As New SqlParameter("@DEPACODI", stDEPACODI)
            Dim o_stDEPADESC As New SqlParameter("@DEPADESC", stDEPADESC)
            Dim o_stDEPAESTA As New SqlParameter("@DEPAESTA", stDEPAESTA)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_stDEPACODI
            VecParametros(1) = o_stDEPADESC
            VecParametros(2) = o_stDEPAESTA

            objenq.ActualizarDb(VecParametros, "insertar_MANT_DEPARTAMENTO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_DEPARTAMENTO(ByVal inDEPAIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inDEPAIDRE As New SqlParameter("@DEPAIDRE", inDEPAIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inDEPAIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_MANT_DEPARTAMENTO") Then
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
    Public Function fun_Actualizar_MANT_DEPARTAMENTO(ByVal inDEPAIDRE As Integer, _
                                                     ByVal stDEPACODI As String, _
                                                     ByVal stDEPADESC As String, _
                                                     ByVal stDEPAESTA As String) As Boolean
        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inDEPAIDRE As New SqlParameter("@DEPAIDRE", inDEPAIDRE)
            Dim o_stDEPACODI As New SqlParameter("@DEPACODI", stDEPACODI)
            Dim o_stDEPADESC As New SqlParameter("@DEPADESC", stDEPADESC)
            Dim o_stDEPAESTA As New SqlParameter("@DEPAESTA", stDEPAESTA)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_inDEPAIDRE
            VecParametros(1) = o_stDEPACODI
            VecParametros(2) = o_stDEPADESC
            VecParametros(3) = o_stDEPAESTA

            objenq.ActualizarDb(VecParametros, "actualizar_MANT_DEPARTAMENTO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_DEPARTAMENTO(ByVal inDEPAIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inDEPAIDRE As New SqlParameter("@DEPAIDRE", inDEPAIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inDEPAIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_MANT_DEPARTAMENTO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DEL DEPARTAMENTO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_DEPARTAMENTO(ByVal stDEPACODI As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stDEPACODI As New SqlParameter("@DEPACODI", stDEPACODI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stDEPACODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_MANT_DEPARTAMENTO")

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
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_DEPARTAMENTO(ByVal inDEPAIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inDEPAIDRE As New SqlParameter("@DEPAIDRE", inDEPAIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inDEPAIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_DEPARTAMENTO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Carga el codigo y la descripcion de los registros activos que carga el combobox
    ''' </summary>
    Public Function fun_Consultar_campos_MANT_DEPARTAMENTO_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "DEPACODI, "
            stConsultaSQL += "DEPADESC  "


            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DEPARTAMENTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DEPAESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DEPADESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_campos_MANT_DEPARTAMENTO_X_ESTADO")
            Return Nothing
        End Try

    End Function

End Class
