Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_SEXO

    '==================
    '*** CLASE SEXO ***
    '==================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_SEXO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_SEXO")

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
    Public Function fun_Consultar_CAMPOS_MANT_SEXO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_MANT_SEXO")

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
    Public Function fun_Consultar_MANT_SEXO_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TIIMatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_SEXO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "SEXOESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "SEXOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_SEXO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_SEXO(ByVal inSEXOCODI As Integer, _
                                           ByVal stSEXODESC As String, _
                                           ByVal stSEXOESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inSEXOCODI As New SqlParameter("@SEXOCODI", inSEXOCODI)
            Dim o_stSEXODESC As New SqlParameter("@SEXODESC", stSEXODESC)
            Dim o_stSEXOESTA As New SqlParameter("@SEXOESTA", stSEXOESTA)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_inSEXOCODI
            VecParametros(1) = o_stSEXODESC
            VecParametros(2) = o_stSEXOESTA

            objenq.ActualizarDb(VecParametros, "insertar_MANT_SEXO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_SEXO(ByVal inSEXOIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inSEXOIDRE As New SqlParameter("@SEXOIDRE", inSEXOIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inSEXOIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_MANT_SEXO") Then
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
    Public Function fun_Actualizar_MANT_SEXO(ByVal inSEXOIDRE As Integer, _
                                             ByVal inSEXOCODI As Integer, _
                                             ByVal stSEXODESC As String, _
                                             ByVal stSEXOESTA As String) As Boolean
        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inSEXOIDRE As New SqlParameter("@SEXOIDRE", inSEXOIDRE)
            Dim o_inSEXOCODI As New SqlParameter("@SEXOCODI", inSEXOCODI)
            Dim o_stSEXODESC As New SqlParameter("@SEXODESC", stSEXODESC)
            Dim o_stSEXOESTA As New SqlParameter("@SEXOESTA", stSEXOESTA)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_inSEXOIDRE
            VecParametros(1) = o_inSEXOCODI
            VecParametros(2) = o_stSEXODESC
            VecParametros(3) = o_stSEXOESTA

            objenq.ActualizarDb(VecParametros, "actualizar_MANT_SEXO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try
      
    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_SEXO(ByVal inSEXOIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inSEXOIDRE As New SqlParameter("@SEXOIDRE", inSEXOIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inSEXOIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_MANT_SEXO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DEL SEXO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_SEXO(ByVal inSEXOCODI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inSEXOCODI As New SqlParameter("@SEXOCODI", inSEXOCODI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inSEXOCODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_MANT_SEXO")

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
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_SEXO(ByVal inSEXOIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inSEXOIDRE As New SqlParameter("@SEXOIDRE", inSEXOIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inSEXOIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_SEXO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function



End Class
