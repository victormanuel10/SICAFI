Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_ZONAFISI

    '=========================
    '*** CLASE ZONA FÍSICA ***
    '=========================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_ZONAFISI() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_ZONAFISI")

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
    Public Function fun_Consultar_CAMPOS_MANT_ZONAFISI(ByVal stZOFIDEPA As String, _
                                                        ByVal stZOFIMUNI As String, _
                                                        ByVal inZOFICLSE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stZOFIDEPA As New SqlParameter("@ZOFIDEPA", stZOFIDEPA)
            Dim o_stZOFIMUNI As New SqlParameter("@ZOFIMUNI", stZOFIMUNI)
            Dim o_inZOFICLSE As New SqlParameter("@ZOFICLSE", inZOFICLSE)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_stZOFIDEPA
            VecParametros(1) = o_stZOFIMUNI
            VecParametros(2) = o_inZOFICLSE


            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_CAMPOS_MANT_ZONAFISI")

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
    Public Function fun_Consultar_CAMPOS_MANT_ZONAFISI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZONAFISI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ZOFIDEPA, ZOFIMUNI, ZOFICLSE, ZOFICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_ZONAFISI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_ZONAFISI_X_ESTADO(ByVal stZOFIDEPA As String, _
                                                         ByVal stZOFIMUNI As String, _
                                                         ByVal inZOFICLSE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stZOFIDEPA As New SqlParameter("@ZOFIDEPA", stZOFIDEPA)
            Dim o_stZOFIMUNI As New SqlParameter("@ZOFIMUNI", stZOFIMUNI)
            Dim o_inZOFICLSE As New SqlParameter("@ZOFICLSE", inZOFICLSE)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_stZOFIDEPA
            VecParametros(1) = o_stZOFIMUNI
            VecParametros(2) = o_inZOFICLSE


            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_MANT_ZONAFISI_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_ZONAFISI(ByVal stZOFIDEPA As String, _
                                               ByVal stZOFIMUNI As String, _
                                               ByVal inZOFICLSE As Integer, _
                                               ByVal inZOFICODI As Integer, _
                                               ByVal stZOFIDESC As String, _
                                               ByVal stZOFIESTA As String, _
                                               ByVal boZOFIZOCO As Boolean) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stZOFIDEPA As New SqlParameter("@ZOFIDEPA", stZOFIDEPA)
            Dim o_stZOFIMUNI As New SqlParameter("@ZOFIMUNI", stZOFIMUNI)
            Dim o_inZOFICLSE As New SqlParameter("@ZOFICLSE", inZOFICLSE)
            Dim o_inZOFICODI As New SqlParameter("@ZOFICODI", inZOFICODI)
            Dim o_stZOFIDESC As New SqlParameter("@ZOFIDESC", stZOFIDESC)
            Dim o_stZOFIESTA As New SqlParameter("@ZOFIESTA", stZOFIESTA)
            Dim o_boZOFIZOCO As New SqlParameter("@ZOFIZOCO", boZOFIZOCO)

            Dim VecParametros(6) As SqlParameter

            VecParametros(0) = o_stZOFIDEPA
            VecParametros(1) = o_stZOFIMUNI
            VecParametros(2) = o_inZOFICLSE
            VecParametros(3) = o_inZOFICODI
            VecParametros(4) = o_stZOFIDESC
            VecParametros(5) = o_stZOFIESTA
            VecParametros(6) = o_boZOFIZOCO

            objenq.ActualizarDb(VecParametros, "insertar_MANT_ZONAFISI")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_ZONAFISI(ByVal inZOFIIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inZOFIIDRE As New SqlParameter("@ZOFIIDRE", inZOFIIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inZOFIIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_MANT_ZONAFISI") Then
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
    Public Function fun_Actualizar_MANT_ZONAFISI(ByVal inZOFIIDRE As Integer, _
                                                 ByVal stZOFIDEPA As String, _
                                                 ByVal stZOFIMUNI As String, _
                                                 ByVal inZOFICLSE As Integer, _
                                                 ByVal inZOFICODI As Integer, _
                                                 ByVal stZOFIDESC As String, _
                                                 ByVal stZOFIESTA As String, _
                                                 ByVal boZOFIZOCO As Boolean) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inZOFIIDRE As New SqlParameter("@ZOFIIDRE", inZOFIIDRE)
            Dim o_stZOFIDEPA As New SqlParameter("@ZOFIDEPA", stZOFIDEPA)
            Dim o_stZOFIMUNI As New SqlParameter("@ZOFIMUNI", stZOFIMUNI)
            Dim o_inZOFICLSE As New SqlParameter("@ZOFICLSE", inZOFICLSE)
            Dim o_inZOFICODI As New SqlParameter("@ZOFICODI", inZOFICODI)
            Dim o_stZOFIDESC As New SqlParameter("@ZOFIDESC", stZOFIDESC)
            Dim o_stZOFIESTA As New SqlParameter("@ZOFIESTA", stZOFIESTA)
            Dim o_boZOFIZOCO As New SqlParameter("@ZOFIZOCO", boZOFIZOCO)

            Dim VecParametros(7) As SqlParameter

            VecParametros(0) = o_inZOFIIDRE
            VecParametros(1) = o_stZOFIDEPA
            VecParametros(2) = o_stZOFIMUNI
            VecParametros(3) = o_inZOFICLSE
            VecParametros(4) = o_inZOFICODI
            VecParametros(5) = o_stZOFIDESC
            VecParametros(6) = o_stZOFIESTA
            VecParametros(7) = o_boZOFIZOCO

            objenq.ActualizarDb(VecParametros, "actualizar_MANT_ZONAFISI")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_ZONAFISI(ByVal inZOFIIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inZOFIIDRE As New SqlParameter("@ZOFIIDRE", inZOFIIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inZOFIIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_MANT_ZONAFISI")

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
    Public Function fun_Buscar_CODIGO_MANT_ZONAFISI(ByVal inZOFICODI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inZOFICODI As New SqlParameter("@ZOFICODI", inZOFICODI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inZOFICODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_MANT_ZONAFISI")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el DEPARTAMENTO, MUNICIPIO, SECTOR Y CÓDIGO DE ZONA ECONOMICA
    ''' para que no se guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAFISI(ByVal stZOFIDEPA As String, _
                                                                              ByVal stZOFIMUNI As String, _
                                                                              ByVal inZOFICLSE As Integer, _
                                                                              ByVal inZOFICODI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stZOFIDEPA As New SqlParameter("@ZOFIDEPA", stZOFIDEPA)
            Dim o_stZOFIMUNI As New SqlParameter("@ZOFIMUNI", stZOFIMUNI)
            Dim o_inZOFICLSE As New SqlParameter("@ZOFICLSE", inZOFICLSE)
            Dim o_inZOFICODI As New SqlParameter("@ZOFICODI", inZOFICODI)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_stZOFIDEPA
            VecParametros(1) = o_stZOFIMUNI
            VecParametros(2) = o_inZOFICLSE
            VecParametros(3) = o_inZOFICODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAFISI")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la zona segun departamento, municipio y sector
    ''' </summary>
    Public Function fun_buscar_ZOFIDEPA_X_ZOFIMUNI_X_ZOFICLSE_X_MANT_ZONAFISI(ByVal stZOFIDEPA As String, _
                                                                 ByVal stZOFIMUNI As String, _
                                                                 ByVal inZOFICLSE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stZOFIDEPA As New SqlParameter("@ZOFIDEPA", stZOFIDEPA)
            Dim o_stZOFIMUNI As New SqlParameter("@ZOFIMUNI", stZOFIMUNI)
            Dim o_inZOFICLSE As New SqlParameter("@ZOFICLSE", inZOFICLSE)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_stZOFIDEPA
            VecParametros(1) = o_stZOFIMUNI
            VecParametros(2) = o_inZOFICLSE


            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ZOFIDEPA_X_ZOFIMUNI_X_ZOFICLSE_X_MANT_ZONAFISI")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Consultar_FIPRZOFI_X_NRO_FICHA_Y_CODIGO(ByVal inFPZFNUFI As Integer, ByVal inFPZFZOFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FIPRZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPZFZOFI = '" & CInt(inFPZFZOFI) & "' AND "
            stConsultaSQL += "FPZFNUFI = '" & CInt(inFPZFNUFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_FIPRZOFI_X_NRO_FICHA_Y_CODIGO")
            Return Nothing
        End Try

    End Function

End Class
