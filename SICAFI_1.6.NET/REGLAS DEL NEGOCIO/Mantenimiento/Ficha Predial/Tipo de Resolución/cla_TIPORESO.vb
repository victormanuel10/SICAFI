Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_TIPORESO

    '================================
    '*** CLASE TIPO DE RESOLUCIÓN ***
    '================================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_TIPORESO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_TIPORESO")

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
    Public Function fun_Consultar_CAMPOS_MANT_TIPORESO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_MANT_TIPORESO")

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
    Public Function fun_Consultar_MANT_TIPORESO_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TIRECODI, "
            stConsultaSQL += "TIREDESC  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPORESO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TIREESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TIREDESC "

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

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_TIPORESO(ByVal inTIDOCODI As Integer, _
                                               ByVal stTIREDESC As String, _
                                               ByVal stTIREESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inTIDOCODI As New SqlParameter("@TIRECODI", inTIDOCODI)
            Dim o_stTIREDESC As New SqlParameter("@TIREDESC", stTIREDESC)
            Dim o_stTIREESTA As New SqlParameter("@TIREESTA", stTIREESTA)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_inTIDOCODI
            VecParametros(1) = o_stTIREDESC
            VecParametros(2) = o_stTIREESTA

            objenq.ActualizarDb(VecParametros, "insertar_MANT_TIPORESO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_TIPORESO(ByVal inTIREIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inTIREIDRE As New SqlParameter("@TIREIDRE", inTIREIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inTIREIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_MANT_TIPORESO") Then
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
    Public Function fun_Actualizar_MANT_TIPORESO(ByVal inTIREIDRE As Integer, _
                                                 ByVal inTIRECODI As Integer, _
                                                 ByVal stTIREDESC As String, _
                                                 ByVal stTIREESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inTIREIDRE As New SqlParameter("@TIREIDRE", inTIREIDRE)
            Dim o_inTIRECODI As New SqlParameter("@TIRECODI", inTIRECODI)
            Dim o_stTIREDESC As New SqlParameter("@TIREDESC", stTIREDESC)
            Dim o_stTIREESTA As New SqlParameter("@TIREESTA", stTIREESTA)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_inTIREIDRE
            VecParametros(1) = o_inTIRECODI
            VecParametros(2) = o_stTIREDESC
            VecParametros(3) = o_stTIREESTA

            objenq.ActualizarDb(VecParametros, "actualizar_MANT_TIPORESO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_TIPORESO(ByVal inTIREIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inTIREIDRE As New SqlParameter("@TIREIDRE", inTIREIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inTIREIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_MANT_TIPORESO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE TIPO DE RESOLUCIÓN para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_TIPORESO(ByVal inTIRECODI As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inTIRECODI As New SqlParameter("@TIRECODI", inTIRECODI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inTIRECODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_MANT_TIPORESO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

End Class
