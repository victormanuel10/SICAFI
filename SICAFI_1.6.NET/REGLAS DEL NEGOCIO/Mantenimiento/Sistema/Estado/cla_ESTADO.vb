Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_ESTADO

    '====================
    '*** CLASE ESTADO ***
    '====================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    '''   <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario modificar estado 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_TODOS_LOS_ESTADOS() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_TODOS_LOS_ESTADOS")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_ESTADO_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_ESTADO_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_ESTADO(ByVal stESTACODI As String, _
                                        ByVal stESTADESC As String, _
                                        ByVal stESTAESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stESTACODI As New SqlParameter("@ESTACODI", stESTACODI)
            Dim o_stESTADESC As New SqlParameter("@ESTADESC", stESTADESC)
            Dim o_stESTAESTA As New SqlParameter("@ESTAESTA", stESTAESTA)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_stESTACODI
            VecParametros(1) = o_stESTADESC
            VecParametros(2) = o_stESTAESTA

            objenq.ActualizarDb(VecParametros, "insertar_ESTADO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_ESTADO(ByVal inESTAIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inESTAIDRE As New SqlParameter("@ESTAIDRE", inESTAIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inESTAIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_ESTADO") Then
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
    Public Function fun_Actualizar_ESTADO(ByVal inESTAIDRE As Integer, _
                                          ByVal stESTACODI As String, _
                                          ByVal stESTADESC As String, _
                                          ByVal stESTAESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inESTAIDRE As New SqlParameter("@ESTAIDRE", inESTAIDRE)
            Dim o_stESTACODI As New SqlParameter("@ESTACODI", stESTACODI)
            Dim o_stESTADESC As New SqlParameter("@ESTADESC", stESTADESC)
            Dim o_stESTAESTA As New SqlParameter("@ESTAESTA", stESTAESTA)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_inESTAIDRE
            VecParametros(1) = o_stESTACODI
            VecParametros(2) = o_stESTADESC
            VecParametros(3) = o_stESTAESTA

            objenq.ActualizarDb(VecParametros, "actualizar_ESTADO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ESTADO(ByVal inESTAIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inESTAIDRE As New SqlParameter("@ESTAIDRE", inESTAIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inESTAIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_ESTADO(ByVal stESTACODI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ESTACODI = '" & CStr(Trim(stESTACODI)) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_ESTADO")
            Return Nothing
        End Try

    End Function

End Class
