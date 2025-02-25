Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MODOADQU

    '====================================
    '*** CLASE MODO DE ADQUISICIÓN ***
    '====================================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_MODOADQU() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_MODOADQU")

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
    Public Function fun_Consultar_CAMPOS_MANT_MODOADQU() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_MANT_MODOADQU")

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
    Public Function fun_Consultar_MANT_MODOADQU_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_MODOADQU_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_MODOADQU(ByVal inMOADCODI As Integer, _
                                               ByVal stMOADDESC As String, _
                                               ByVal stMOADESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inMOADCODI As New SqlParameter("@MOADCODI", inMOADCODI)
            Dim o_stMOADDESC As New SqlParameter("@MOADDESC", stMOADDESC)
            Dim o_stMOADESTA As New SqlParameter("@MOADESTA", stMOADESTA)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_inMOADCODI
            VecParametros(1) = o_stMOADDESC
            VecParametros(2) = o_stMOADESTA

            objenq.ActualizarDb(VecParametros, "insertar_MANT_MODOADQU")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_MODOADQU(ByVal inMOADIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inMOADIDRE As New SqlParameter("@MOADIDRE", inMOADIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inMOADIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_MANT_MODOADQU") Then
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
    Public Function fun_Actualizar_MANT_MODOADQU(ByVal inMOADIDRE As Integer, _
                                                 ByVal inMOADCODI As Integer, _
                                                 ByVal stMOADDESC As String, _
                                                 ByVal stMOADESTA As String) As Boolean
        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inMOADIDRE As New SqlParameter("@MOADIDRE", inMOADIDRE)
            Dim o_inMOADCODI As New SqlParameter("@MOADCODI", inMOADCODI)
            Dim o_stMOADDESC As New SqlParameter("@MOADDESC", stMOADDESC)
            Dim o_stMOADESTA As New SqlParameter("@MOADESTA", stMOADESTA)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_stMOADESTA
            VecParametros(1) = o_inMOADCODI
            VecParametros(2) = o_stMOADDESC
            VecParametros(3) = o_stMOADESTA

            objenq.ActualizarDb(VecParametros, "actualizar_MANT_MODOADQU")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_MODOADQU(ByVal inMOADIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inMOADIDRE As New SqlParameter("@MOADIDRE", inMOADIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inMOADIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_MANT_MODOADQU")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DEL MODO DE ADQUISICIÓN para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_MODOADQU(ByVal inMOADCODI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inMOADCODI As New SqlParameter("@MOADCODI", inMOADCODI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inMOADCODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_MANT_MODOADQU")

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
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_MODOADQU(ByVal inMOADIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inMOADIDRE As New SqlParameter("@MOADIDRE", inMOADIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inMOADIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_MODOADQU")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Carga el codigo y la descripcion de los registros activos que carga el combobox
    ''' </summary>
    Public Function fun_Consultar_Campos_MANT_MODOADQU_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MOADCODI, "
            stConsultaSQL += "MOADDESC  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MODOADQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOADESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MOADDESC "

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
