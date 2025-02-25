Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_NOTARIA

    '=====================
    '*** CLASE NOTARIA ***
    '=====================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_NOTARIA() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_NOTARIA")

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
    Public Function fun_Consultar_CAMPOS_MANT_NOTARIA() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_MANT_NOTARIA")

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Funcion que busca el campo de la notaria en estado activo 
    ''' (Solo debuelve el campo de la notaria)
    ''' </summary>
    Public Function fun_Consultar_MANT_NOTARIA_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_NOTARIA_X_ESTADO")

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_NOTARIA(ByVal stNOTADEPA As String, _
                                              ByVal stNOTAMUNI As String, _
                                              ByVal stNOTACODI As String, _
                                              ByVal stNOTADESC As String, _
                                              ByVal stNOTAESTA As String) As Boolean
        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stNOTADEPA As New SqlParameter("@NOTADEPA", stNOTADEPA)
            Dim o_stNOTAMUNI As New SqlParameter("@NOTAMUNI", stNOTAMUNI)
            Dim o_stNOTACODI As New SqlParameter("@NOTACODI", stNOTACODI)
            Dim o_stNOTADESC As New SqlParameter("@NOTADESC", stNOTADESC)
            Dim o_stNOTAESTA As New SqlParameter("@NOTAESTA", stNOTAESTA)

            Dim VecParametros(4) As SqlParameter

            VecParametros(0) = o_stNOTADEPA
            VecParametros(1) = o_stNOTAMUNI
            VecParametros(2) = o_stNOTACODI
            VecParametros(3) = o_stNOTADESC
            VecParametros(4) = o_stNOTAESTA

            objenq.ActualizarDb(VecParametros, "insertar_MANT_NOTARIA")

            Return True

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_NOTARIA(ByVal inNOTAIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inNOTAIDRE As New SqlParameter("@NOTAIDRE", inNOTAIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inNOTAIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_MANT_NOTARIA") Then
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
    Public Function fun_Actualizar_MANT_NOTARIA(ByVal inNOTAIDRE As Integer, _
                                                ByVal stNOTADEPA As String, _
                                                ByVal stNOTAMUNI As String, _
                                                ByVal stNOTACODI As String, _
                                                ByVal stNOTADESC As String, _
                                                ByVal stNOTAESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inNOTAIDRE As New SqlParameter("@NOTAIDRE", inNOTAIDRE)
            Dim o_stNOTADEPA As New SqlParameter("@NOTADEPA", stNOTADEPA)
            Dim o_stNOTAMUNI As New SqlParameter("@NOTAMUNI", stNOTAMUNI)
            Dim o_stNOTACODI As New SqlParameter("@NOTACODI", stNOTACODI)
            Dim o_stNOTADESC As New SqlParameter("@NOTADESC", stNOTADESC)
            Dim o_stNOTAESTA As New SqlParameter("@NOTAESTA", stNOTAESTA)

            Dim VecParametros(5) As SqlParameter

            VecParametros(0) = o_inNOTAIDRE
            VecParametros(1) = o_stNOTADEPA
            VecParametros(2) = o_stNOTAMUNI
            VecParametros(3) = o_stNOTACODI
            VecParametros(4) = o_stNOTADESC
            VecParametros(5) = o_stNOTAESTA

            objenq.ActualizarDb(VecParametros, "actualizar_MANT_NOTARIA")

            Return True

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_NOTARIA(ByVal inNOTAIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inNOTAIDRE As New SqlParameter("@NOTAIDRE", inNOTAIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inNOTAIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_MANT_NOTARIA")

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
    Public Function fun_Buscar_CODIGO_MANT_NOTARIA(ByVal stNOTADEPA As String, _
                                                    ByVal stNOTAMUNI As String, _
                                                    ByVal stNOTANOTA As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stNOTADEPA As New SqlParameter("@NOTADEPA", stNOTADEPA)
            Dim o_stNOTAMUNI As New SqlParameter("@NOTAMUNI", stNOTAMUNI)
            Dim o_stNOTANOTA As New SqlParameter("@NOTACODI", stNOTANOTA)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_stNOTADEPA
            VecParametros(1) = o_stNOTAMUNI
            VecParametros(2) = o_stNOTANOTA

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_MANT_NOTARIA")

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el DEPARTAMENTO, MUNICIPIO Y CÓDIGO DE NOTARIA para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_CODIGO_MANT_NOTARIA(ByVal stNOTADEPA As String, _
                                                                              ByVal stNOTAMUNI As String, _
                                                                              ByVal stNOTACODI As String) As DataTable
        Try
            Dim objeq As New cExecuteQuery

            Dim o_stNOTADEPA As New SqlParameter("@NOTADEPA", stNOTADEPA)
            Dim o_stNOTAMUNI As New SqlParameter("@NOTAMUNI", stNOTAMUNI)
            Dim o_stNOTACODI As New SqlParameter("@NOTACODI", stNOTACODI)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_stNOTADEPA
            VecParametros(1) = o_stNOTAMUNI
            VecParametros(2) = o_stNOTACODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_CODIGO_MANT_NOTARIA")

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

End Class
