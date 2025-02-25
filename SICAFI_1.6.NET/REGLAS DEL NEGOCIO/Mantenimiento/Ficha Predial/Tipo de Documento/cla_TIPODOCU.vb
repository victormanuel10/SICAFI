Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_TIPODOCU

    '===============================
    '*** CLASE TIPO DE DOCUMENTO ***
    '===============================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_TIPODOCU() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_TIPODOCU")

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
    Public Function fun_Consultar_CAMPOS_MANT_TIPODOCU() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_MANT_TIPODOCU")

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
    Public Function fun_Consultar_MANT_TIPODOCU_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TIIMatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPODOCU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TIDOESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TIDOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_TIPODOCU_X_ESTADO")
            Return Nothing
        End Try


    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_TIPODOCU(ByVal inTIDOCODI As Integer, _
                                                ByVal stTIDODESC As String, _
                                                ByVal stTIDOESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inTIDOCODI As New SqlParameter("@TIDOCODI", inTIDOCODI)
            Dim o_stTIDODESC As New SqlParameter("@TIDODESC", stTIDODESC)
            Dim o_stTIDOESTA As New SqlParameter("@TIDOESTA", stTIDOESTA)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_inTIDOCODI
            VecParametros(1) = o_stTIDODESC
            VecParametros(2) = o_stTIDOESTA

            objenq.ActualizarDb(VecParametros, "insertar_MANT_TIPODOCU")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_TIPODOCU(ByVal inTIDOIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inTIDOIDRE As New SqlParameter("@TIDOIDRE", inTIDOIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inTIDOIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_MANT_TIPODOCU") Then
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
    Public Function fun_Actualizar_MANT_TIPODOCU(ByVal inTIDOIDRE As Integer, _
                                                    ByVal inTIDOCODI As Integer, _
                                                    ByVal stTIDODESC As String, _
                                                    ByVal stTIDOESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inTIDOIDRE As New SqlParameter("@TIDOIDRE", inTIDOIDRE)
            Dim o_inTIDOCODI As New SqlParameter("@TIDOCODI", inTIDOCODI)
            Dim o_stTIDODESC As New SqlParameter("@TIDODESC", stTIDODESC)
            Dim o_stTIDOESTA As New SqlParameter("@TIDOESTA", stTIDOESTA)


            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_inTIDOIDRE
            VecParametros(1) = o_inTIDOCODI
            VecParametros(2) = o_stTIDODESC
            VecParametros(3) = o_stTIDOESTA

            objenq.ActualizarDb(VecParametros, "actualizar_MANT_TIPODOCU")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try
       
    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_TIPODOCU(ByVal inTIDOIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inTIDOIDRE As New SqlParameter("@TIDOIDRE", inTIDOIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inTIDOIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_MANT_TIPODOCU")

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
    Public Function fun_Buscar_CODIGO_MANT_TIPODOCU(ByVal inTIDOCODI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inTIDOCODI As New SqlParameter("@TIDOCODI", inTIDOCODI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inTIDOCODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_MANT_TIPODOCU")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que valida los randos de numero de idenficación contra
    ''' el tipo de documento.
    ''' </summary>
    Public Function fun_Validar_Rangos_Nro_Documento(ByVal stNUMEDOCU As String, _
                                                     ByVal inTIPODOCU As Integer) As Boolean

        Try
            Dim inNUMEDOCU As Long = CType(Trim(stNUMEDOCU), Long)

            ' valida el rango de hombres segun tipo de documento
            If inTIPODOCU = 1 Then
                If (inNUMEDOCU > 0 And inNUMEDOCU < 20000000) Or (inNUMEDOCU > 70000000 And inNUMEDOCU < 100000000) Then
                    Return True
                Else
                    Return False
                End If
            End If

            ' valida el rango de mujeres segun tipo de documento
            If inTIPODOCU = 2 Then
                If (inNUMEDOCU > 20000000 And inNUMEDOCU < 70000000) Then
                    Return True
                Else
                    Return False
                End If
            End If

            ' valida el rango de persona juridica segun tipo de documento
            If inTIPODOCU = 3 Then
                If (inNUMEDOCU > 800000000 And inNUMEDOCU < 1000000000) Then
                    Return True
                Else
                    Return False
                End If
            End If

            ' valida el rango de cedula de extrngeria segun tipo de documento
            If inTIPODOCU = 4 Then
                If (inNUMEDOCU > 1000000) Then
                    Return True
                Else
                    Return False
                End If
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function


End Class
