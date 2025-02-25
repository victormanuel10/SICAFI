Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_TERCERO

    '=====================
    '*** CLASE TERCERO ***
    '=====================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_TERCERO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_TERCERO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_TERCERO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_TERCERO")

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
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TERCERO(ByVal inTERCIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inTERCIDRE As New SqlParameter("@TERCIDRE", inTERCIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inTERCIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_ID_X_CONSULTA_PARAMETRIZADA_TERCERO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_TERCERO(ByVal stTERCNUDO As String, _
                                         ByVal inTERCTIDO As Integer, _
                                         ByVal inTERCCAPR As Integer, _
                                         ByVal inTERCSEXO As Integer, _
                                         ByVal stTERCNOMB As String, _
                                         ByVal stTERCPRAP As String, _
                                         ByVal stTERCSEAP As String, _
                                         ByVal stTERCSICO As String, _
                                         ByVal stTERCTEL1 As String, _
                                         ByVal stTERCTEL2 As String, _
                                         ByVal stTERCFAX1 As String, _
                                         ByVal stTERCDIRE As String, _
                                         ByVal stTERCESTA As String, _
                                         ByVal stTERCOBSE As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            ' *** INSTANCIA LA FECHA Y HORA ***
            Dim dateNow As DateTime = DateTime.Now

            Dim stTERCUSMO As String = ""
            Dim daTERCFEIN As Date = DateTime.Now.ToString()    'Fecha y hora
            Dim daTERCFEMO As Date = DateTime.Now.ToString()

            Dim o_stTERCNUDO As New SqlParameter("@TERCNUDO", stTERCNUDO)
            Dim o_inTERCTIDO As New SqlParameter("@TERCTIDO", inTERCTIDO)
            Dim o_inTERCCAPR As New SqlParameter("@TERCCAPR", inTERCCAPR)
            Dim o_inTERCSEXO As New SqlParameter("@TERCSEXO", inTERCSEXO)
            Dim o_stTERCNOMB As New SqlParameter("@TERCNOMB", stTERCNOMB)
            Dim o_stTERCPRAP As New SqlParameter("@TERCPRAP", stTERCPRAP)
            Dim o_stTERCSEAP As New SqlParameter("@TERCSEAP", stTERCSEAP)
            Dim o_stTERCSICO As New SqlParameter("@TERCSICO", stTERCSICO)
            Dim o_stTERCTEL1 As New SqlParameter("@TERCTEL1", stTERCTEL1)
            Dim o_stTERCTEL2 As New SqlParameter("@TERCTEL2", stTERCTEL2)
            Dim o_stTERCFAX1 As New SqlParameter("@TERCFAX1", stTERCFAX1)
            Dim o_stTERCDIRE As New SqlParameter("@TERCDIRE", stTERCDIRE)
            Dim o_stTERCESTA As New SqlParameter("@TERCESTA", stTERCESTA)
            Dim o_stTERCUSIN As New SqlParameter("@TERCUSIN", vp_usuario)
            Dim o_stTERCUSMO As New SqlParameter("@TERCUSMO", stTERCUSMO)
            Dim o_daTERCFEIN As New SqlParameter("@TERCFEIN", daTERCFEIN)
            Dim o_daTERCFEMO As New SqlParameter("@TERCFEMO", daTERCFEMO)
            Dim o_stTERCOBSE As New SqlParameter("@TERCOBSE", stTERCOBSE)

            Dim VecParametros(17) As SqlParameter

            VecParametros(0) = o_stTERCNUDO
            VecParametros(1) = o_inTERCTIDO
            VecParametros(2) = o_inTERCCAPR
            VecParametros(3) = o_inTERCSEXO
            VecParametros(4) = o_stTERCNOMB
            VecParametros(5) = o_stTERCPRAP
            VecParametros(6) = o_stTERCSEAP
            VecParametros(7) = o_stTERCSICO
            VecParametros(8) = o_stTERCTEL1
            VecParametros(9) = o_stTERCTEL2
            VecParametros(10) = o_stTERCFAX1
            VecParametros(11) = o_stTERCDIRE
            VecParametros(12) = o_stTERCESTA
            VecParametros(13) = o_stTERCUSIN
            VecParametros(14) = o_stTERCUSMO
            VecParametros(15) = o_daTERCFEIN
            VecParametros(16) = o_daTERCFEMO
            VecParametros(17) = o_stTERCOBSE

            objenq.ActualizarDb(VecParametros, "insertar_TERCERO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_TERCERO(ByVal inTERCIDRE As Integer) As Boolean


        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inTERCIDRE As New SqlParameter("@TERCIDRE", inTERCIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inTERCIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_TERCERO") Then
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
    Public Function fun_Actualizar_TERCERO(ByVal inTERCIDRE As Integer, _
                                           ByVal stTERCNUDO As String, _
                                           ByVal inTERCTIDO As Integer, _
                                           ByVal inTERCCAPR As Integer, _
                                           ByVal inTERCSEXO As Integer, _
                                           ByVal stTERCNOMB As String, _
                                           ByVal stTERCPRAP As String, _
                                           ByVal stTERCSEAP As String, _
                                           ByVal stTERCSICO As String, _
                                           ByVal stTERCTEL1 As String, _
                                           ByVal stTERCTEL2 As String, _
                                           ByVal stTERCFAX1 As String, _
                                           ByVal stTERCDIRE As String, _
                                           ByVal stTERCESTA As String, _
                                           ByVal stTERCUSIN As String, _
                                           ByVal daTERCFEIN As Date, _
                                           ByVal stTERCOBSE As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            ' *** INSTANCIA LA FECHA Y HORA ***
            Dim dateNow As DateTime = DateTime.Now

            Dim daTERCFEMO As Date = DateTime.Now.ToString()    'Fecha y hora

            Dim o_inTERCIDRE As New SqlParameter("@TERCIDRE", inTERCIDRE)
            Dim o_stTERCNUDO As New SqlParameter("@TERCNUDO", stTERCNUDO)
            Dim o_inTERCTIDO As New SqlParameter("@TERCTIDO", inTERCTIDO)
            Dim o_inTERCCAPR As New SqlParameter("@TERCCAPR", inTERCCAPR)
            Dim o_inTERCSEXO As New SqlParameter("@TERCSEXO", inTERCSEXO)
            Dim o_stTERCNOMB As New SqlParameter("@TERCNOMB", stTERCNOMB)
            Dim o_stTERCPRAP As New SqlParameter("@TERCPRAP", stTERCPRAP)
            Dim o_stTERCSEAP As New SqlParameter("@TERCSEAP", stTERCSEAP)
            Dim o_stTERCSICO As New SqlParameter("@TERCSICO", stTERCSICO)
            Dim o_stTERCTEL1 As New SqlParameter("@TERCTEL1", stTERCTEL1)
            Dim o_stTERCTEL2 As New SqlParameter("@TERCTEL2", stTERCTEL2)
            Dim o_stTERCFAX1 As New SqlParameter("@TERCFAX1", stTERCFAX1)
            Dim o_stTERCDIRE As New SqlParameter("@TERCDIRE", stTERCDIRE)
            Dim o_stTERCESTA As New SqlParameter("@TERCESTA", stTERCESTA)
            Dim o_stTERCUSIN As New SqlParameter("@TERCUSIN", stTERCUSIN)
            Dim o_stTERCUSMO As New SqlParameter("@TERCUSMO", vp_usuario)
            Dim o_daTERCFEIN As New SqlParameter("@TERCFEIN", daTERCFEIN)
            Dim o_daTERCFEMO As New SqlParameter("@TERCFEMO", daTERCFEMO)
            Dim o_stTERCOBSE As New SqlParameter("@TERCOBSE", stTERCOBSE)

            Dim VecParametros(18) As SqlParameter

            VecParametros(0) = o_inTERCIDRE
            VecParametros(1) = o_stTERCNUDO
            VecParametros(2) = o_inTERCTIDO
            VecParametros(3) = o_inTERCCAPR
            VecParametros(4) = o_inTERCSEXO
            VecParametros(5) = o_stTERCNOMB
            VecParametros(6) = o_stTERCPRAP
            VecParametros(7) = o_stTERCSEAP
            VecParametros(8) = o_stTERCSICO
            VecParametros(9) = o_stTERCTEL1
            VecParametros(10) = o_stTERCTEL2
            VecParametros(11) = o_stTERCFAX1
            VecParametros(12) = o_stTERCDIRE
            VecParametros(13) = o_stTERCESTA
            VecParametros(14) = o_stTERCUSIN
            VecParametros(15) = o_stTERCUSMO
            VecParametros(16) = o_daTERCFEIN
            VecParametros(17) = o_daTERCFEMO
            VecParametros(18) = o_stTERCOBSE

            objenq.ActualizarDb(VecParametros, "actualizar_TERCERO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_TERCERO(ByVal inTERCIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inTERCIDRE As New SqlParameter("@TERCIDRE", inTERCIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inTERCIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_TERCERO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DEL TERCERO (Documento de identidad)
    ''' para que no se guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_TERCERO(ByVal stTERCNUDO As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stTERCNUDO As New SqlParameter("@TERCNUDO", stTERCNUDO)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stTERCNUDO

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_TERCERO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

End Class
