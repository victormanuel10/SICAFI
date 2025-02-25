Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MUNICIPIO

    '=======================
    '*** CLASE MUNICIPIO ***
    '=======================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_MUNICIPIO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_MUNICIPIO")

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
    Public Function fun_Consultar_CAMPOS_MANT_MUNICIPIO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_MANT_MUNICIPIO")

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
    Public Function fun_Consultar_MANT_MUNICIPIO_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_MUNICIPIO_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_MUNICIPIO(ByVal stMUNIDEPA As String, ByVal _
                                                      stMUNICODI As String, ByVal _
                                                      stMUNIDESC As String, ByVal _
                                                      inMUNIRAIN As Integer, ByVal _
                                                      inMUNIRAFI As Integer, ByVal _
                                                      stMUNIESTA As String) As Boolean
        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stMUNIDEPA As New SqlParameter("@MUNIDEPA", stMUNIDEPA)
            Dim o_stMUNICODI As New SqlParameter("@MUNICODI", stMUNICODI)
            Dim o_stMUNIDESC As New SqlParameter("@MUNIDESC", stMUNIDESC)
            Dim o_inMUNIRAIN As New SqlParameter("@MUNIRAIN", inMUNIRAIN)
            Dim o_inMUNIRAFI As New SqlParameter("@MUNIRAFI", inMUNIRAFI)
            Dim o_stMUNIESTA As New SqlParameter("@MUNIESTA", stMUNIESTA)

            Dim VecParametros(5) As SqlParameter

            VecParametros(0) = o_stMUNIDEPA
            VecParametros(1) = o_stMUNICODI
            VecParametros(2) = o_stMUNIDESC
            VecParametros(3) = o_inMUNIRAIN
            VecParametros(4) = o_inMUNIRAFI
            VecParametros(5) = o_stMUNIESTA

            objenq.ActualizarDb(VecParametros, "insertar_MANT_MUNICIPIO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_MUNICIPIO(ByVal inMUNIIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inMUNIIDRE As New SqlParameter("@MUNIIDRE", inMUNIIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inMUNIIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_MANT_MUNICIPIO") Then
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
    Public Function fun_Actualizar_MANT_MUNICIPIO(ByVal inMUNIIDRE As Integer, ByVal _
                                                        stMUNIDEPA As String, ByVal _
                                                        stMUNICODI As String, ByVal _
                                                        stMUNIDESC As String, ByVal _
                                                        inMUNIRAIN As Integer, ByVal _
                                                        inMUNIRAFI As Integer, ByVal _
                                                        stMUNIESTA As String) As Boolean
        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inMUNIIDRE As New SqlParameter("@MUNIIDRE", inMUNIIDRE)
            Dim o_stMUNIDEPA As New SqlParameter("@MUNIDEPA", stMUNIDEPA)
            Dim o_stMUNICODI As New SqlParameter("@MUNICODI", stMUNICODI)
            Dim o_stMUNIDESC As New SqlParameter("@MUNIDESC", stMUNIDESC)
            Dim o_inMUNIRAIN As New SqlParameter("@MUNIRAIN", inMUNIRAIN)
            Dim o_inMUNIRAFI As New SqlParameter("@MUNIRAFI", inMUNIRAFI)
            Dim o_stMUNIESTA As New SqlParameter("@MUNIESTA", stMUNIESTA)

            Dim VecParametros(6) As SqlParameter

            VecParametros(0) = o_inMUNIIDRE
            VecParametros(1) = o_stMUNIDEPA
            VecParametros(2) = o_stMUNICODI
            VecParametros(3) = o_stMUNIDESC
            VecParametros(4) = o_inMUNIRAIN
            VecParametros(5) = o_inMUNIRAFI
            VecParametros(6) = o_stMUNIESTA

            objenq.ActualizarDb(VecParametros, "actualizar_MANT_MUNICIPIO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_MUNICIPIO(ByVal inMUNIIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inMUNIIDRE As New SqlParameter("@MUNIIDRE", inMUNIIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inMUNIIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_MANT_MUNICIPIO")

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
    Public Function fun_Buscar_CODIGO_MANT_MUNICIPIO(ByVal inMUNICODI As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inMUNICODI As New SqlParameter("@MUNICODI", inMUNICODI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inMUNICODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_MANT_MUNICIPIO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el DEPARTAMENTO Y EL CÓDIGO DEL MUNICIPIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_DEPARTAMENTO_Y_CODIGO_MANT_MUNICIPIO(ByVal stMUNIDEPA As String, _
                                                                    ByVal stMUNICODI As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stMUNIDEPA As New SqlParameter("@MUNIDEPA", stMUNIDEPA)
            Dim o_stMUNICODI As New SqlParameter("@MUNICODI", stMUNICODI)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_stMUNIDEPA
            VecParametros(1) = o_stMUNICODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_DEPARTAMENTO_Y_CODIGO_MANT_MUNICIPIO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el municipio correspondiente al departamento seleccionado,
    ''' este se carga en el combobox correspondiente al municipio.
    ''' </summary>
    Public Function fun_Buscar_MUNICIPIO_X_DEPARTAMENTO_MANT_MUNICIPIO(ByVal stMUNIDEPA As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stMUNIDEPA As New SqlParameter("@MUNIDEPA", stMUNIDEPA)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stMUNIDEPA

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_MUNICIPIO_X_DEPARTAMENTO_MANT_MUNICIPIO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function
  

End Class
