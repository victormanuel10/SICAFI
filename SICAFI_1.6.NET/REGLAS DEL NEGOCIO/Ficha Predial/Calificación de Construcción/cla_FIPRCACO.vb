Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_FIPRCACO

    '===========================
    ' *** CLASE CONSTRUCCION ***
    '===========================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_FIPRCACO(ByVal inFPCCNUFI As Integer, _
                                           ByVal inFPCCUNID As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPCCNUFI As New SqlParameter("@FPCCNUFI", inFPCCNUFI)
            Dim o_inFPCCUNID As New SqlParameter("@FPCCUNID", inFPCCUNID)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_inFPCCNUFI
            VecParametros(1) = o_inFPCCUNID

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FIPRCACO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_FIPRCACO(ByVal inFPCCNUFI As Integer, _
                                               ByVal inFPCCCODI As Integer, _
                                               ByVal stFPCCTIPO As String, _
                                               ByVal inFPCCPUNT As Integer, _
                                               ByVal inFPCCUNID As Integer, _
                                               ByVal inFPCCCLCO As Integer, _
                                               ByVal stFPCCTICO As String, _
                                               ByVal stFPCCDEPA As String, _
                                               ByVal stFPCCMUNI As String, _
                                               ByVal inFPCCTIRE As Integer, _
                                               ByVal inFPCCCLSE As Integer, _
                                               ByVal inFPCCVIGE As Integer, _
                                               ByVal inFPCCRESO As Integer, _
                                               ByVal inFPCCSECU As Integer, _
                                               ByVal inFPCCNURE As Integer, _
                                               ByVal stFPCCESTA As String) As Boolean

        ''*** INSTANCIA QUE IDENTIFICA EL NOMBRE DE LA MAQUINA ***
        Dim stFPCCMAQU As String = fun_Nombre_de_maquina()

        '' *** INSTANCIA LA FECHA Y HORA ***
        Dim daFPCCFEIN As Date = fun_Hora_y_fecha()
        Dim daFPCCFEMO As Date = fun_Hora_y_fecha()
        Dim daFPCCFECH As Date = fun_Hora_y_fecha()

        '' *** USUARIO QUE MODIFICA ***
        Dim stFPCCUSIN As String = vp_usuario
        Dim stFPCCUSMO As String = ""

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPCCNUFI As New SqlParameter("@FPCCNUFI", inFPCCNUFI)
            Dim o_inFPCCCODI As New SqlParameter("@FPCCCODI", inFPCCCODI)
            Dim o_stFPCCTIPO As New SqlParameter("@FPCCTIPO", stFPCCTIPO)
            Dim o_inFPCCPUNT As New SqlParameter("@FPCCPUNT", inFPCCPUNT)
            Dim o_inFPCCUNID As New SqlParameter("@FPCCUNID", inFPCCUNID)
            Dim o_inFPCCCLCO As New SqlParameter("@FPCCCLCO", inFPCCCLCO)
            Dim o_stFPCCTICO As New SqlParameter("@FPCCTICO", stFPCCTICO)
            Dim o_stFPCCDEPA As New SqlParameter("@FPCCDEPA", stFPCCDEPA)
            Dim o_stFPCCMUNI As New SqlParameter("@FPCCMUNI", stFPCCMUNI)
            Dim o_inFPCCTIRE As New SqlParameter("@FPCCTIRE", inFPCCTIRE)
            Dim o_inFPCCCLSE As New SqlParameter("@FPCCCLSE", inFPCCCLSE)
            Dim o_inFPCCVIGE As New SqlParameter("@FPCCVIGE", inFPCCVIGE)
            Dim o_inFPCCRESO As New SqlParameter("@FPCCRESO", inFPCCRESO)
            Dim o_inFPCCSECU As New SqlParameter("@FPCCSECU", inFPCCSECU)
            Dim o_inFPCCNURE As New SqlParameter("@FPCCNURE", inFPCCNURE)
            Dim o_stFPCCESTA As New SqlParameter("@FPCCESTA", stFPCCESTA)
            Dim o_stFPCCUSIN As New SqlParameter("@FPCCUSIN", stFPCCUSIN)
            Dim o_stFPCCUSMO As New SqlParameter("@FPCCUSMO", stFPCCUSMO)
            Dim o_daFPCCFEIN As New SqlParameter("@FPCCFEIN", daFPCCFEIN)
            Dim o_daFPCCFEMO As New SqlParameter("@FPCCFEMO", daFPCCFEMO)
            Dim o_stFPCCMAQU As New SqlParameter("@FPCCMAQU", stFPCCMAQU)

            Dim VecParametros(20) As SqlParameter

            VecParametros(0) = o_inFPCCNUFI
            VecParametros(1) = o_inFPCCCODI
            VecParametros(2) = o_stFPCCTIPO
            VecParametros(3) = o_inFPCCPUNT
            VecParametros(4) = o_inFPCCUNID
            VecParametros(5) = o_inFPCCCLCO
            VecParametros(6) = o_stFPCCTICO
            VecParametros(7) = o_stFPCCDEPA
            VecParametros(8) = o_stFPCCMUNI
            VecParametros(9) = o_inFPCCTIRE
            VecParametros(10) = o_inFPCCCLSE
            VecParametros(11) = o_inFPCCVIGE
            VecParametros(12) = o_inFPCCRESO
            VecParametros(13) = o_inFPCCSECU
            VecParametros(14) = o_inFPCCNURE
            VecParametros(15) = o_stFPCCESTA
            VecParametros(16) = o_stFPCCUSIN
            VecParametros(17) = o_stFPCCUSMO
            VecParametros(18) = o_daFPCCFEIN
            VecParametros(19) = o_daFPCCFEMO
            VecParametros(20) = o_stFPCCMAQU

            objenq.ActualizarDb(VecParametros, "insertar_FIPRCACO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_FIPRCACO(ByVal inFPCCIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPCCIDRE As New SqlParameter("@FPCCIDRE", inFPCCIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPCCIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_FIPRCACO") Then
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
    ''' Función que Elimina todos los registros de la unidad.
    ''' </summary>
    Public Function fun_Eliminar_Todos_Los_Registros_FIPRCACO(ByVal inFPCCNUFI As Integer, _
                                                              ByVal inFPCCUNID As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPCCNUFI As New SqlParameter("@FPCCNUFI", inFPCCNUFI)
            Dim o_inFPCCUNID As New SqlParameter("@FPCCUNID", inFPCCUNID)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_inFPCCNUFI
            VecParametros(1) = o_inFPCCUNID

            If objenq.ActualizarDb(VecParametros, "Eliminar_Todos_Los_Registros_FIPRCACO") Then
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
    ''' Función que Elimina todos los registros de la unidad.
    ''' </summary>
    Public Function fun_Eliminar_Por_Codigo_FIPRCACO(ByVal inFPCCNUFI As Integer, _
                                                     ByVal inFPCCUNID As Integer, _
                                                     ByVal inFPCCCODI As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPCCNUFI As New SqlParameter("@FPCCNUFI", inFPCCNUFI)
            Dim o_inFPCCUNID As New SqlParameter("@FPCCUNID", inFPCCUNID)
            Dim o_inFPCCCODI As New SqlParameter("@FPCCCODI", inFPCCCODI)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_inFPCCNUFI
            VecParametros(1) = o_inFPCCUNID
            VecParametros(2) = o_inFPCCCODI

            If objenq.ActualizarDb(VecParametros, "Eliminar_Por_Codigo_FIPRCACO") Then
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
    Public Function fun_Actualizar_FIPRCACO(ByVal inFPCCIDRE As Integer, _
                                               ByVal inFPCCNUFI As Integer, _
                                               ByVal inFPCCCODI As Integer, _
                                               ByVal stFPCCTIPO As String, _
                                               ByVal inFPCCPUNT As Integer, _
                                               ByVal inFPCCUNID As Integer, _
                                               ByVal inFPCCCLCO As Integer, _
                                               ByVal stFPCCTICO As String, _
                                               ByVal stFPCCDEPA As String, _
                                               ByVal stFPCCMUNI As String, _
                                               ByVal inFPCCTIRE As Integer, _
                                               ByVal inFPCCCLSE As Integer, _
                                               ByVal inFPCCVIGE As Integer, _
                                               ByVal inFPCCRESO As Integer, _
                                               ByVal inFPCCSECU As Integer, _
                                               ByVal inFPCCNURE As Integer, _
                                               ByVal stFPCCESTA As String, _
                                               ByVal stFPCCUSIN As String, _
                                               ByVal daFPCCFEIN As Date) As Boolean


        '===================================
        ' DATOS DE MODIFICACIÓN DE REGISTRO
        '===================================

        Dim stFPCCMAQU As String = fun_Nombre_de_maquina()

        Dim daFPCCFEMO As Date = fun_Hora_y_fecha()
        Dim stFPCCUSMO As String = vp_usuario

        '=====================
        ' SOBRECARGA DE DATOS 
        '=====================

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPCCIDRE As New SqlParameter("@FPCCIDRE", inFPCCIDRE)
            Dim o_inFPCCNUFI As New SqlParameter("@FPCCNUFI", inFPCCNUFI)
            Dim o_inFPCCCODI As New SqlParameter("@FPCCCODI", inFPCCCODI)
            Dim o_stFPCCTIPO As New SqlParameter("@FPCCTIPO", stFPCCTIPO)
            Dim o_inFPCCPUNT As New SqlParameter("@FPCCPUNT", inFPCCPUNT)
            Dim o_inFPCCUNID As New SqlParameter("@FPCCUNID", inFPCCUNID)
            Dim o_inFPCCCLCO As New SqlParameter("@FPCCCLCO", inFPCCCLCO)
            Dim o_stFPCCTICO As New SqlParameter("@FPCCTICO", stFPCCTICO)
            Dim o_stFPCCDEPA As New SqlParameter("@FPCCDEPA", stFPCCDEPA)
            Dim o_stFPCCMUNI As New SqlParameter("@FPCCMUNI", stFPCCMUNI)
            Dim o_inFPCCTIRE As New SqlParameter("@FPCCTIRE", inFPCCTIRE)
            Dim o_inFPCCCLSE As New SqlParameter("@FPCCCLSE", inFPCCCLSE)
            Dim o_inFPCCVIGE As New SqlParameter("@FPCCVIGE", inFPCCVIGE)
            Dim o_inFPCCRESO As New SqlParameter("@FPCCRESO", inFPCCRESO)
            Dim o_inFPCCSECU As New SqlParameter("@FPCCSECU", inFPCCSECU)
            Dim o_inFPCCNURE As New SqlParameter("@FPCCNURE", inFPCCNURE)
            Dim o_stFPCCESTA As New SqlParameter("@FPCCESTA", stFPCCESTA)
            Dim o_stFPCCUSIN As New SqlParameter("@FPCCUSIN", stFPCCUSIN)
            Dim o_stFPCCUSMO As New SqlParameter("@FPCCUSMO", stFPCCUSMO)
            Dim o_daFPCCFEIN As New SqlParameter("@FPCCFEIN", daFPCCFEIN)
            Dim o_daFPCCFEMO As New SqlParameter("@FPCCFEMO", daFPCCFEMO)
            Dim o_stFPCCMAQU As New SqlParameter("@FPCCMAQU", stFPCCMAQU)

            Dim VecParametros(32) As SqlParameter

            VecParametros(0) = o_inFPCCIDRE
            VecParametros(1) = o_inFPCCNUFI
            VecParametros(2) = o_inFPCCCODI
            VecParametros(3) = o_stFPCCTIPO
            VecParametros(4) = o_inFPCCPUNT
            VecParametros(5) = o_inFPCCUNID
            VecParametros(6) = o_inFPCCCLCO
            VecParametros(7) = o_stFPCCTICO
            VecParametros(8) = o_stFPCCDEPA
            VecParametros(9) = o_stFPCCMUNI
            VecParametros(10) = o_inFPCCTIRE
            VecParametros(11) = o_inFPCCCLSE
            VecParametros(12) = o_inFPCCVIGE
            VecParametros(13) = o_inFPCCRESO
            VecParametros(14) = o_inFPCCSECU
            VecParametros(15) = o_inFPCCNURE
            VecParametros(16) = o_stFPCCESTA
            VecParametros(17) = o_stFPCCUSIN
            VecParametros(18) = o_stFPCCUSMO
            VecParametros(19) = o_daFPCCFEIN
            VecParametros(20) = o_daFPCCFEMO
            VecParametros(21) = o_stFPCCMAQU

            objenq.ActualizarDb(VecParametros, "actualizar_FIPRCACO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_FIPRCACO(ByVal inFPCCIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPCCIDRE As New SqlParameter("@FPCCIDRE", inFPCCIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPCCIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_FIPRCACO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIFICACION para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_FIPRCACO(ByVal inFPCCNUFI As Integer, _
                                               ByVal inFPCCCODI As Integer, _
                                               ByVal inFPCCUNID As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPCCNUFI As New SqlParameter("@FPCCNUFI", inFPCCNUFI)
            Dim o_inFPCCCODI As New SqlParameter("@FPCCCODI", inFPCCCODI)
            Dim o_inFPCCUNID As New SqlParameter("@FPCCUNID", inFPCCUNID)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_inFPCCNUFI
            VecParametros(1) = o_inFPCCCODI
            VecParametros(2) = o_inFPCCUNID

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_FIPRCACO")

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
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_FIPRCACO(ByVal inFPCCNUFI As Integer, _
                                                                    ByVal inFPCCCODI As Integer, _
                                                                    ByVal inFPCCSECU As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPCCNUFI As New SqlParameter("@FPCCNUFI", inFPCCNUFI)
            Dim o_inFPCCCODI As New SqlParameter("@FPCCCODI", inFPCCCODI)
            Dim o_inFPCCSECU As New SqlParameter("@FPCCSECU", inFPCCSECU)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_inFPCCNUFI
            VecParametros(1) = o_inFPCCCODI
            VecParametros(2) = o_inFPCCSECU

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_ID_X_CONSULTA_PARAMETRIZADA_FIPRCACO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que consulta la sumatoria de las areas construidas
    ''' que se encuantran activos.
    ''' </summary>
    Public Function fun_Consultar_SUMA_X_FPCCPUNT_FIPRCACO(ByVal inFPCCNUFI As Integer, _
                                                           ByVal inFPCCUNID As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPCCNUFI As New SqlParameter("@FPCCNUFI", inFPCCNUFI)
            Dim o_inFPCCUNID As New SqlParameter("@FPCCUNID", inFPCCUNID)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_inFPCCNUFI
            VecParametros(1) = o_inFPCCUNID

            Dim SumaDestino As New DataTable
            SumaDestino = objeq.ConsultarDb(VecParametros, "Consultar_SUMA_X_FPCCPUNT_FIPRCACO")

            Return SumaDestino

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Consulta la calificación segun el numero de ficha predial y unidad de construcción
    ''' </summary>
    Public Function fun_Consultar_FIPRCACO_X_FICHA_PREDIAL(ByVal inFPCCNUFI As Integer, _
                                                           ByVal inFPCCUNID As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPCCNUFI As New SqlParameter("@FPCCNUFI", inFPCCNUFI)
            Dim o_inFPCCUNID As New SqlParameter("@FPCCUNID", inFPCCUNID)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_inFPCCNUFI
            VecParametros(1) = o_inFPCCUNID

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FIPRCACO_X_FICHA_PREDIAL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Consulta todas las unidades segun numero de ficha predial
    ''' </summary>
    Public Function fun_Consultar_FIPRCACO_X_FICHA_PREDIAL_TODAS_LAS_UNIDADES(ByVal inFPCCNUFI As Integer) As DataTable


        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FIPRCACO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPCCNUFI = '" & CInt(inFPCCNUFI) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FPCCUNID, FPCCCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_FIPRCACO_X_FICHA_PREDIAL_TODAS_LAS_UNIDADES")
            Return Nothing
        End Try

    End Function


End Class
