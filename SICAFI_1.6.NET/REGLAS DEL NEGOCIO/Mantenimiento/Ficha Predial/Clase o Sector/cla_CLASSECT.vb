Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CLASSECT

    '============================
    '*** CLASE CLASE O SECTOR ***
    '============================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CLASSECT() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_CLASSECT")

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
    Public Function fun_Consultar_CAMPOS_MANT_CLASSECT() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_MANT_CLASSECT")

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
    Public Function fun_Consultar_MANT_CLASSECT_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_CLASSECT_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_CLASSECT(ByVal inCLSECODI As Integer, _
                                               ByVal stCLSEDESC As String, _
                                               ByVal stCLSEESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inCLSECODI As New SqlParameter("@CLSECODI", inCLSECODI)
            Dim o_stCLSEDESC As New SqlParameter("@CLSEDESC", stCLSEDESC)
            Dim o_stCLSEESTA As New SqlParameter("@CLSEESTA", stCLSEESTA)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_inCLSECODI
            VecParametros(1) = o_stCLSEDESC
            VecParametros(2) = o_stCLSEESTA

            objenq.ActualizarDb(VecParametros, "insertar_MANT_CLASSECT")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CLASSECT(ByVal inCLSEIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inCLSEIDRE As New SqlParameter("@CLSEIDRE", inCLSEIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCLSEIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_MANT_CLASSECT") Then
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
    Public Function fun_Actualizar_MANT_CLASSECT(ByVal inCLSEIDRE As Integer, _
                                                 ByVal inCLSECODI As Integer, _
                                                 ByVal stCLSEDESC As String, _
                                                 ByVal stCLSEESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inCLSEIDRE As New SqlParameter("@CLSEIDRE", inCLSEIDRE)
            Dim o_inCLSECODI As New SqlParameter("@CLSECODI", inCLSECODI)
            Dim o_stCLSEDESC As New SqlParameter("@CLSEDESC", stCLSEDESC)
            Dim o_stCLSEESTA As New SqlParameter("@CLSEESTA", stCLSEESTA)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_inCLSEIDRE
            VecParametros(1) = o_inCLSECODI
            VecParametros(2) = o_stCLSEDESC
            VecParametros(3) = o_stCLSEESTA

            objenq.ActualizarDb(VecParametros, "actualizar_MANT_CLASSECT")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CLASSECT(ByVal inCLSEIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inCLSEIDRE As New SqlParameter("@CLSEIDRE", inCLSEIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCLSEIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_MANT_CLASSECT")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CLASE O SECTOR para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_CLASSECT(ByVal inCLSECODI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inCLSECODI As New SqlParameter("@CLSECODI", inCLSECODI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCLSECODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_MANT_CLASSECT")

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
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CLASSECT(ByVal inCLSEIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inCLSEIDRE As New SqlParameter("@CLSEIDRE", inCLSEIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCLSEIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CLASSECT")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Carga el codigo y la descripcion de los registros activos que carga el combobox
    ''' </summary>
    Public Function fun_Consultar_Campos_MANT_CLASSECT_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CLSECODI, "
            stConsultaSQL += "CLSEDESC  "


            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CLASSECT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CLSEESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CLSEDESC "

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
