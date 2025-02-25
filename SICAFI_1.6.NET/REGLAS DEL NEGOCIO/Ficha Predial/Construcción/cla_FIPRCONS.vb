Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_FIPRCONS

    '===========================
    ' *** CLASE CONSTRUCCION ***
    '===========================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_FIPRCONS(ByVal inFPCONUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPCONUFI As New SqlParameter("@FPCONUFI", inFPCONUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPCONUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FIPRCONS")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_FIPRCONS(ByVal inFPCONUFI As Integer, _
                                               ByVal inFPCOUNID As Integer, _
                                               ByVal inFPCOCLCO As Integer, _
                                               ByVal stFPCOTICO As String, _
                                               ByVal inFPCOPUNT As Integer, _
                                               ByVal stFPCOARCO As String, _
                                               ByVal inFPCOACUE As Integer, _
                                               ByVal inFPCOALCA As Integer, _
                                               ByVal inFPCOENER As Integer, _
                                               ByVal inFPCOTELE As Integer, _
                                               ByVal inFPCOGAS As Integer, _
                                               ByVal inFPCOPISO As Integer, _
                                               ByVal inFPCOEDCO As Integer, _
                                               ByVal inFPCOPOCO As Integer, _
                                               ByVal boFPCOMEJO As Boolean, _
                                               ByVal boFPCOLEY As Boolean, _
                                               ByVal inFPCOAVCO As Integer, _
                                               ByVal stFPCODEPA As String, _
                                               ByVal stFPCOMUNI As String, _
                                               ByVal inFPCOTIRE As Integer, _
                                               ByVal inFPCOCLSE As Integer, _
                                               ByVal inFPCOVIGE As Integer, _
                                               ByVal inFPCORESO As Integer, _
                                               ByVal inFPCOSECU As Integer, _
                                               ByVal inFPCONURE As Integer, _
                                               ByVal stFPCOESTA As String) As Boolean

        ''*** INSTANCIA QUE IDENTIFICA EL NOMBRE DE LA MAQUINA ***
        Dim stFPCOMAQU As String = fun_Nombre_de_maquina()

        '' *** INSTANCIA LA FECHA Y HORA ***
        Dim daFPCOFEIN As Date = fun_Hora_y_fecha()
        Dim daFPCOFEMO As Date = fun_Hora_y_fecha()
        Dim daFPCOFECH As Date = fun_Hora_y_fecha()

        '' *** USUARIO QUE MODIFICA ***
        Dim stFPCOUSIN As String = vp_usuario
        Dim stFPCOUSMO As String = ""

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPCONUFI As New SqlParameter("@FPCONUFI", inFPCONUFI)
            Dim o_inFPCOUNID As New SqlParameter("@FPCOUNID", inFPCOUNID)
            Dim o_inFPCOCLCO As New SqlParameter("@FPCOCLCO", inFPCOCLCO)
            Dim o_stFPCOTICO As New SqlParameter("@FPCOTICO", stFPCOTICO)
            Dim o_inFPCOPUNT As New SqlParameter("@FPCOPUNT", inFPCOPUNT)
            Dim o_stFPCOARCO As New SqlParameter("@FPCOARCO", stFPCOARCO)
            Dim o_inFPCOACUE As New SqlParameter("@FPCOACUE", inFPCOACUE)
            Dim o_inFPCOALCA As New SqlParameter("@FPCOALCA", inFPCOALCA)
            Dim o_inFPCOENER As New SqlParameter("@FPCOENER", inFPCOENER)
            Dim o_inFPCOTELE As New SqlParameter("@FPCOTELE", inFPCOTELE)
            Dim o_inFPCOGAS As New SqlParameter("@FPCOGAS", inFPCOGAS)
            Dim o_inFPCOPISO As New SqlParameter("@FPCOPISO", inFPCOPISO)
            Dim o_inFPCOEDCO As New SqlParameter("@FPCOEDCO", inFPCOEDCO)
            Dim o_inFPCOPOCO As New SqlParameter("@FPCOPOCO", inFPCOPOCO)
            Dim o_boFPCOMEJO As New SqlParameter("@FPCOMEJO", boFPCOMEJO)
            Dim o_boFPCOLEY As New SqlParameter("@FPCOLEY", boFPCOLEY)
            Dim o_inFPCOAVCO As New SqlParameter("@FPCOAVCO", inFPCOAVCO)
            Dim o_daFPCOFECH As New SqlParameter("@FPCOFECH", daFPCOFECH)
            Dim o_stFPCODEPA As New SqlParameter("@FPCODEPA", stFPCODEPA)
            Dim o_stFPCOMUNI As New SqlParameter("@FPCOMUNI", stFPCOMUNI)
            Dim o_inFPCOTIRE As New SqlParameter("@FPCOTIRE", inFPCOTIRE)
            Dim o_inFPCOCLSE As New SqlParameter("@FPCOCLSE", inFPCOCLSE)
            Dim o_inFPCOVIGE As New SqlParameter("@FPCOVIGE", inFPCOVIGE)
            Dim o_inFPCORESO As New SqlParameter("@FPCORESO", inFPCORESO)
            Dim o_inFPCOSECU As New SqlParameter("@FPCOSECU", inFPCOSECU)
            Dim o_inFPCONURE As New SqlParameter("@FPCONURE", inFPCONURE)
            Dim o_stFPCOESTA As New SqlParameter("@FPCOESTA", stFPCOESTA)
            Dim o_stFPCOUSIN As New SqlParameter("@FPCOUSIN", stFPCOUSIN)
            Dim o_stFPCOUSMO As New SqlParameter("@FPCOUSMO", stFPCOUSMO)
            Dim o_daFPCOFEIN As New SqlParameter("@FPCOFEIN", daFPCOFEIN)
            Dim o_daFPCOFEMO As New SqlParameter("@FPCOFEMO", daFPCOFEMO)
            Dim o_stFPCOMAQU As New SqlParameter("@FPCOMAQU", stFPCOMAQU)

            Dim VecParametros(31) As SqlParameter

            VecParametros(0) = o_inFPCONUFI
            VecParametros(1) = o_inFPCOUNID
            VecParametros(2) = o_inFPCOCLCO
            VecParametros(3) = o_stFPCOTICO
            VecParametros(4) = o_inFPCOPUNT
            VecParametros(5) = o_stFPCOARCO
            VecParametros(6) = o_inFPCOACUE
            VecParametros(7) = o_inFPCOALCA
            VecParametros(8) = o_inFPCOENER
            VecParametros(9) = o_inFPCOTELE
            VecParametros(10) = o_inFPCOGAS
            VecParametros(11) = o_inFPCOPISO
            VecParametros(12) = o_inFPCOEDCO
            VecParametros(13) = o_inFPCOPOCO
            VecParametros(14) = o_boFPCOMEJO
            VecParametros(15) = o_boFPCOLEY
            VecParametros(16) = o_inFPCOAVCO
            VecParametros(17) = o_daFPCOFECH
            VecParametros(18) = o_stFPCODEPA
            VecParametros(19) = o_stFPCOMUNI
            VecParametros(20) = o_inFPCOTIRE
            VecParametros(21) = o_inFPCOCLSE
            VecParametros(22) = o_inFPCOVIGE
            VecParametros(23) = o_inFPCORESO
            VecParametros(24) = o_inFPCOSECU
            VecParametros(25) = o_inFPCONURE
            VecParametros(26) = o_stFPCOESTA
            VecParametros(27) = o_stFPCOUSIN
            VecParametros(28) = o_stFPCOUSMO
            VecParametros(29) = o_daFPCOFEIN
            VecParametros(30) = o_daFPCOFEMO
            VecParametros(31) = o_stFPCOMAQU

            objenq.ActualizarDb(VecParametros, "insertar_FIPRCONS")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_FIPRCONS(ByVal inFPCOIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPCOIDRE As New SqlParameter("@FPCOIDRE", inFPCOIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPCOIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_FIPRCONS") Then
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
    Public Function fun_Actualizar_FIPRCONS(ByVal inFPCOIDRE As Integer, _
                                               ByVal inFPCONUFI As Integer, _
                                               ByVal inFPCOUNID As Integer, _
                                               ByVal inFPCOCLCO As Integer, _
                                               ByVal stFPCOTICO As String, _
                                               ByVal inFPCOPUNT As Integer, _
                                               ByVal stFPCOARCO As String, _
                                               ByVal inFPCOACUE As Integer, _
                                               ByVal inFPCOALCA As Integer, _
                                               ByVal inFPCOENER As Integer, _
                                               ByVal inFPCOTELE As Integer, _
                                               ByVal inFPCOGAS As Integer, _
                                               ByVal inFPCOPISO As Integer, _
                                               ByVal inFPCOEDCO As Integer, _
                                               ByVal inFPCOPOCO As Integer, _
                                               ByVal boFPCOMEJO As Boolean, _
                                               ByVal boFPCOLEY As Boolean, _
                                               ByVal inFPCOAVCO As Integer, _
                                               ByVal stFPCODEPA As String, _
                                               ByVal stFPCOMUNI As String, _
                                               ByVal inFPCOTIRE As Integer, _
                                               ByVal inFPCOCLSE As Integer, _
                                               ByVal inFPCOVIGE As Integer, _
                                               ByVal inFPCORESO As Integer, _
                                               ByVal inFPCOSECU As Integer, _
                                               ByVal inFPCONURE As Integer, _
                                               ByVal stFPCOESTA As String, _
                                               ByVal daFPCOFECH As Date, _
                                               ByVal stFPCOUSIN As String, _
                                               ByVal daFPCOFEIN As Date) As Boolean


        '===================================
        ' DATOS DE MODIFICACIÓN DE REGISTRO
        '===================================

        Dim stFPCOMAQU As String = fun_Nombre_de_maquina()
        Dim daFPCOFEMO As Date = fun_Hora_y_fecha()
        Dim stFPCOUSMO As String = vp_usuario

        '=====================
        ' SOBRECARGA DE DATOS 
        '=====================

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPCOIDRE As New SqlParameter("@FPCOIDRE", inFPCOIDRE)
            Dim o_inFPCONUFI As New SqlParameter("@FPCONUFI", inFPCONUFI)
            Dim o_inFPCOUNID As New SqlParameter("@FPCOUNID", inFPCOUNID)
            Dim o_inFPCOCLCO As New SqlParameter("@FPCOCLCO", inFPCOCLCO)
            Dim o_stFPCOTICO As New SqlParameter("@FPCOTICO", stFPCOTICO)
            Dim o_inFPCOPUNT As New SqlParameter("@FPCOPUNT", inFPCOPUNT)
            Dim o_stFPCOARCO As New SqlParameter("@FPCOARCO", stFPCOARCO)
            Dim o_inFPCOACUE As New SqlParameter("@FPCOACUE", inFPCOACUE)
            Dim o_inFPCOALCA As New SqlParameter("@FPCOALCA", inFPCOALCA)
            Dim o_inFPCOENER As New SqlParameter("@FPCOENER", inFPCOENER)
            Dim o_inFPCOTELE As New SqlParameter("@FPCOTELE", inFPCOTELE)
            Dim o_inFPCOGAS As New SqlParameter("@FPCOGAS", inFPCOGAS)
            Dim o_inFPCOPISO As New SqlParameter("@FPCOPISO", inFPCOPISO)
            Dim o_inFPCOEDCO As New SqlParameter("@FPCOEDCO", inFPCOEDCO)
            Dim o_inFPCOPOCO As New SqlParameter("@FPCOPOCO", inFPCOPOCO)
            Dim o_boFPCOMEJO As New SqlParameter("@FPCOMEJO", boFPCOMEJO)
            Dim o_boFPCOLEY As New SqlParameter("@FPCOLEY", boFPCOLEY)
            Dim o_inFPCOAVCO As New SqlParameter("@FPCOAVCO", inFPCOAVCO)
            Dim o_daFPCOFECH As New SqlParameter("@FPCOFECH", daFPCOFECH)
            Dim o_stFPCODEPA As New SqlParameter("@FPCODEPA", stFPCODEPA)
            Dim o_stFPCOMUNI As New SqlParameter("@FPCOMUNI", stFPCOMUNI)
            Dim o_inFPCOTIRE As New SqlParameter("@FPCOTIRE", inFPCOTIRE)
            Dim o_inFPCOCLSE As New SqlParameter("@FPCOCLSE", inFPCOCLSE)
            Dim o_inFPCOVIGE As New SqlParameter("@FPCOVIGE", inFPCOVIGE)
            Dim o_inFPCORESO As New SqlParameter("@FPCORESO", inFPCORESO)
            Dim o_inFPCOSECU As New SqlParameter("@FPCOSECU", inFPCOSECU)
            Dim o_inFPCONURE As New SqlParameter("@FPCONURE", inFPCONURE)
            Dim o_stFPCOESTA As New SqlParameter("@FPCOESTA", stFPCOESTA)
            Dim o_stFPCOUSIN As New SqlParameter("@FPCOUSIN", stFPCOUSIN)
            Dim o_stFPCOUSMO As New SqlParameter("@FPCOUSMO", stFPCOUSMO)
            Dim o_daFPCOFEIN As New SqlParameter("@FPCOFEIN", daFPCOFEIN)
            Dim o_daFPCOFEMO As New SqlParameter("@FPCOFEMO", daFPCOFEMO)
            Dim o_stFPCOMAQU As New SqlParameter("@FPCOMAQU", stFPCOMAQU)

            Dim VecParametros(32) As SqlParameter

            VecParametros(0) = o_inFPCOIDRE
            VecParametros(1) = o_inFPCONUFI
            VecParametros(2) = o_inFPCOUNID
            VecParametros(3) = o_inFPCOCLCO
            VecParametros(4) = o_stFPCOTICO
            VecParametros(5) = o_inFPCOPUNT
            VecParametros(6) = o_stFPCOARCO
            VecParametros(7) = o_inFPCOACUE
            VecParametros(8) = o_inFPCOALCA
            VecParametros(9) = o_inFPCOENER
            VecParametros(10) = o_inFPCOTELE
            VecParametros(11) = o_inFPCOGAS
            VecParametros(12) = o_inFPCOPISO
            VecParametros(13) = o_inFPCOEDCO
            VecParametros(14) = o_inFPCOPOCO
            VecParametros(15) = o_boFPCOMEJO
            VecParametros(16) = o_boFPCOLEY
            VecParametros(17) = o_inFPCOAVCO
            VecParametros(18) = o_daFPCOFECH
            VecParametros(19) = o_stFPCODEPA
            VecParametros(20) = o_stFPCOMUNI
            VecParametros(21) = o_inFPCOTIRE
            VecParametros(22) = o_inFPCOCLSE
            VecParametros(23) = o_inFPCOVIGE
            VecParametros(24) = o_inFPCORESO
            VecParametros(25) = o_inFPCOSECU
            VecParametros(26) = o_inFPCONURE
            VecParametros(27) = o_stFPCOESTA
            VecParametros(28) = o_stFPCOUSIN
            VecParametros(29) = o_stFPCOUSMO
            VecParametros(30) = o_daFPCOFEIN
            VecParametros(31) = o_daFPCOFEMO
            VecParametros(32) = o_stFPCOMAQU

            objenq.ActualizarDb(VecParametros, "actualizar_FIPRCONS")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_FIPRCONS(ByVal inFPCOIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPCOIDRE As New SqlParameter("@FPCOIDRE", inFPCOIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPCOIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_FIPRCONS")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CONSTRUCCION para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_FIPRCONS(ByVal inFPCONUFI As Integer, _
                                               ByVal inFPCOUNID As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPCONUFI As New SqlParameter("@FPCONUFI", inFPCONUFI)
            Dim o_stFPCOUNID As New SqlParameter("@FPCOUNID", inFPCOUNID)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_inFPCONUFI
            VecParametros(1) = o_stFPCOUNID

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_FIPRCONS")

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
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_FIPRCONS(ByVal inFPCONUFI As Integer, _
                                                                    ByVal inFPCOUNID As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPCONUFI As New SqlParameter("@FPCONUFI", inFPCONUFI)
            Dim o_stFPCOUNID As New SqlParameter("@FPCOUNID", inFPCOUNID)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_inFPCONUFI
            VecParametros(1) = o_stFPCOUNID

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_ID_X_CONSULTA_PARAMETRIZADA_FIPRCONS")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el EL NUMERO DE SECUENCIA DEL PROPIETARIO MAXIMO de acuerdo
    ''' al numero de la ficha predial.
    ''' </summary>
    Public Function fun_Buscar_NRO_SECUENCIA_FIPRCONS_X_FICHA_PREDIAL(ByVal inFPCONUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPCONUFI As New SqlParameter("@FPCONUFI", inFPCONUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPCONUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_NRO_SECUENCIA_FIPRCONS_X_FICHA_PREDIAL")

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
    Public Function fun_Consultar_SUMA_X_FPCOARCO_FIPRCONS(ByVal inFPCONUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPCONUFI As New SqlParameter("@FPCONUFI", inFPCONUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPCONUFI

            Dim SumaDestino As New DataTable
            SumaDestino = objeq.ConsultarDb(VecParametros, "Consultar_SUMA_X_FPCOARCO_FIPRCONS")

            Return SumaDestino

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Consulta todos los campos de la construccion por ficha predial para llenar los
    ''' campos del formulario ficha predial
    ''' </summary>
    Public Function fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(ByVal inFPCONUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPCONUFI As New SqlParameter("@FPCONUFI", inFPCONUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPCONUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FIPRCONS_X_FICHA_PREDIAL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_NUFI_FIPRCONS(ByVal inFPCONUFI As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "FIPRCONS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPCONUFI = '" & CInt(inFPCONUFI) & "' "

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MUTADEPA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta todos los campos parametrizados por numero de ficha y campo de la tabla
    ''' </summary>
    Public Function fun_Consultar_FIPRCONS_X_PARAMETRO(ByVal stFPCONUFI As String, _
                                                        ByVal stFPCOCAMP As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPCONUFI As New SqlParameter("@FPCONUFI", stFPCONUFI)
            Dim o_stFPCOCAMP As New SqlParameter("@FPCOCAMP", stFPCOCAMP)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_inFPCONUFI
            VecParametros(1) = o_stFPCOCAMP

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FIPRCONS_X_PARAMETRO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_ARCO_X_FIPRCONS(ByVal inFPCONUFI As Integer, _
                                                   ByVal stFPCOARCO As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "FIPRCONS "

            stConsultaSQL += "SET "
            stConsultaSQL += "FPCOARCO = '" & CStr(Trim(stFPCOARCO)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPCONUFI = '" & CInt(inFPCONUFI) & "' "

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_CAPRFIPR")
        End Try

    End Function

End Class
