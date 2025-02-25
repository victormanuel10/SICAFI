Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_ZONAECON

    '============================
    '*** CLASE ZONA ECONÓMICA ***
    '============================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_ZONAECON() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_ZONAECON")

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
    Public Function fun_Consultar_CAMPOS_MANT_ZONAECON(ByVal stZOECDEPA As String, _
                                                       ByVal stZOECMUNI As String, _
                                                       ByVal inZOECCLSE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stZOECDEPA As New SqlParameter("@ZOECDEPA", stZOECDEPA)
            Dim o_stZOECMUNI As New SqlParameter("@ZOECMUNI", stZOECMUNI)
            Dim o_inZOECCLSE As New SqlParameter("@ZOECCLSE", inZOECCLSE)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_stZOECDEPA
            VecParametros(1) = o_stZOECMUNI
            VecParametros(2) = o_inZOECCLSE


            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_CAMPOS_MANT_ZONAECON")

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
    Public Function fun_Consultar_CAMPOS_MANT_ZONAECON() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_ZONAECON "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ZOECDEPA, ZOECMUNI, ZOECCLSE, ZOECCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_ZONAECON")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_ZONAECON_X_ESTADO(ByVal stZOECDEPA As String, _
                                                         ByVal stZOECMUNI As String, _
                                                         ByVal inZOECCLSE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stZOECDEPA As New SqlParameter("@ZOECDEPA", stZOECDEPA)
            Dim o_stZOECMUNI As New SqlParameter("@ZOECMUNI", stZOECMUNI)
            Dim o_inZOECCLSE As New SqlParameter("@ZOECCLSE", inZOECCLSE)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_stZOECDEPA
            VecParametros(1) = o_stZOECMUNI
            VecParametros(2) = o_inZOECCLSE


            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_MANT_ZONAECON_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_ZONAECON(ByVal stZOECDEPA As String, _
                                               ByVal stZOECMUNI As String, _
                                               ByVal inZOECCLSE As Integer, _
                                               ByVal inZOECCODI As Integer, _
                                               ByVal stZOECDESC As String, _
                                               ByVal inZOECVALO As Integer, _
                                               ByVal stZOECESTA As String, _
                                               ByVal boZOECZOCO As Boolean, _
                                               ByVal stZOECPOIN As String) As Boolean


        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stZOECDEPA As New SqlParameter("@ZOECDEPA", stZOECDEPA)
            Dim o_stZOECMUNI As New SqlParameter("@ZOECMUNI", stZOECMUNI)
            Dim o_inZOECCLSE As New SqlParameter("@ZOECCLSE", inZOECCLSE)
            Dim o_inZOECCODI As New SqlParameter("@ZOECCODI", inZOECCODI)
            Dim o_stZOECDESC As New SqlParameter("@ZOECDESC", stZOECDESC)
            Dim o_inZOECVALO As New SqlParameter("@ZOECVALO", inZOECVALO)
            Dim o_stZOECESTA As New SqlParameter("@ZOECESTA", stZOECESTA)
            Dim o_boZOECZOCO As New SqlParameter("@ZOECZOCO", boZOECZOCO)
            Dim o_stZOECPOIN As New SqlParameter("@ZOECPOIN", stZOECPOIN)

            Dim VecParametros(8) As SqlParameter

            VecParametros(0) = o_stZOECDEPA
            VecParametros(1) = o_stZOECMUNI
            VecParametros(2) = o_inZOECCLSE
            VecParametros(3) = o_inZOECCODI
            VecParametros(4) = o_stZOECDESC
            VecParametros(5) = o_inZOECVALO
            VecParametros(6) = o_stZOECESTA
            VecParametros(7) = o_boZOECZOCO
            VecParametros(8) = o_stZOECPOIN

            objenq.ActualizarDb(VecParametros, "insertar_MANT_ZONAECON")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_ZONAECON(ByVal inZOECIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inZOECIDRE As New SqlParameter("@ZOECIDRE", inZOECIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inZOECIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_MANT_ZONAECON") Then
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
    Public Function fun_Actualizar_MANT_ZONAECON(ByVal inZOECIDRE As Integer, _
                                                 ByVal stZOECDEPA As String, _
                                                 ByVal stZOECMUNI As String, _
                                                 ByVal inZOECCLSE As Integer, _
                                                 ByVal inZOECCODI As Integer, _
                                                 ByVal stZOECDESC As String, _
                                                 ByVal inZOECVALO As Integer, _
                                                 ByVal stZOECESTA As String, _
                                                 ByVal boZOECZOCO As Boolean, _
                                                 ByVal stZOECPOIN As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inZOECIDRE As New SqlParameter("@ZOECIDRE", inZOECIDRE)
            Dim o_stZOECDEPA As New SqlParameter("@ZOECDEPA", stZOECDEPA)
            Dim o_stZOECMUNI As New SqlParameter("@ZOECMUNI", stZOECMUNI)
            Dim o_inZOECCLSE As New SqlParameter("@ZOECCLSE", inZOECCLSE)
            Dim o_inZOECCODI As New SqlParameter("@ZOECCODI", inZOECCODI)
            Dim o_stZOECDESC As New SqlParameter("@ZOECDESC", stZOECDESC)
            Dim o_inZOECVALO As New SqlParameter("@ZOECVALO", inZOECVALO)
            Dim o_stZOECESTA As New SqlParameter("@ZOECESTA", stZOECESTA)
            Dim o_boZOECZOCO As New SqlParameter("@ZOECZOCO", boZOECZOCO)
            Dim o_stZOECPOIN As New SqlParameter("@ZOECPOIN", stZOECPOIN)

            Dim VecParametros(9) As SqlParameter

            VecParametros(0) = o_inZOECIDRE
            VecParametros(1) = o_stZOECDEPA
            VecParametros(2) = o_stZOECMUNI
            VecParametros(3) = o_inZOECCLSE
            VecParametros(4) = o_inZOECCODI
            VecParametros(5) = o_stZOECDESC
            VecParametros(6) = o_inZOECVALO
            VecParametros(7) = o_stZOECESTA
            VecParametros(8) = o_boZOECZOCO
            VecParametros(9) = o_stZOECPOIN

            objenq.ActualizarDb(VecParametros, "actualizar_MANT_ZONAECON")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_ZONAECON(ByVal inZOECIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inZOECIDRE As New SqlParameter("@ZOECIDRE", inZOECIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inZOECIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_MANT_ZONAECON")

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
    Public Function fun_Buscar_CODIGO_MANT_ZONAECON(ByVal inZOECCODI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inZOECCODI As New SqlParameter("@ZOECCODI", inZOECCODI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inZOECCODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_MANT_ZONAECON")

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
    Public Function fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAECON(ByVal stZOECDEPA As String, _
                                                                              ByVal stZOECMUNI As String, _
                                                                              ByVal inZOECCLSE As Integer, _
                                                                              ByVal inZOECCODI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stZOECDEPA As New SqlParameter("@ZOECDEPA", stZOECDEPA)
            Dim o_stZOECMUNI As New SqlParameter("@ZOECMUNI", stZOECMUNI)
            Dim o_inZOECCLSE As New SqlParameter("@ZOECCLSE", inZOECCLSE)
            Dim o_inZOECCODI As New SqlParameter("@ZOECCODI", inZOECCODI)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_stZOECDEPA
            VecParametros(1) = o_stZOECMUNI
            VecParametros(2) = o_inZOECCLSE
            VecParametros(3) = o_inZOECCODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAECON")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la zona segun departamento, municipio y sector
    ''' </summary>
    Public Function fun_buscar_ZOECDEPA_X_ZOECMUNI_X_ZOECCLSE_X_MANT_ZONAECON(ByVal stZOECDEPA As String, _
                                                                 ByVal stZOECMUNI As String, _
                                                                 ByVal inZOECCLSE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stZOECDEPA As New SqlParameter("@ZOECDEPA", stZOECDEPA)
            Dim o_stZOECMUNI As New SqlParameter("@ZOECMUNI", stZOECMUNI)
            Dim o_inZOECCLSE As New SqlParameter("@ZOECCLSE", inZOECCLSE)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_stZOECDEPA
            VecParametros(1) = o_stZOECMUNI
            VecParametros(2) = o_inZOECCLSE


            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ZOECDEPA_X_ZOECMUNI_X_ZOECCLSE_X_MANT_ZONAECON")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

End Class
