Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_modificar_RESOLUCION

    '============================
    '*** MODIFICAR RESOLUCIÓN ***
    '============================

#Region "VARIABLES"

    Dim id As Integer

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal idDataGrid As Integer)
        id = idDataGrid


        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        '=========================================
        ' CARGA LOS COMBOBOX CON LOS DATOS ACTIVOS
        '=========================================

        Dim objdatos1 As New cla_DEPARTAMENTO

        cboRESODEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
        cboRESODEPA.DisplayMember = "DEPACODI"
        cboRESODEPA.ValueMember = "DEPACODI"

        Dim objdatos7 As New cla_MUNICIPIO

        cboRESOMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
        cboRESOMUNI.DisplayMember = "MUNICODI"
        cboRESOMUNI.ValueMember = "MUNICODI"

        Dim objdatos2 As New cla_TIPORESO

        cboRESOTIRE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_TIPORESO
        cboRESOTIRE.DisplayMember = "TIRECODI"
        cboRESOTIRE.ValueMember = "TIRECODI"

        Dim objdatos As New cla_ESTADO

        cboRESOESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboRESOESTA.DisplayMember = "ESTADESC"
        cboRESOESTA.ValueMember = "ESTACODI"

        Dim objdatos5 As New cla_CLASSECT

        cboRESOCLSE.DataSource = objdatos5.fun_Consultar_CAMPOS_MANT_CLASSECT
        cboRESOCLSE.DisplayMember = "CLSECODI"
        cboRESOCLSE.ValueMember = "CLSECODI"

        Dim objdatos8 As New cla_VIGENCIA

        cboRESOVIGE.DataSource = objdatos8.fun_Consultar_CAMPOS_VIGENCIA
        cboRESOVIGE.DisplayMember = "VIGECODI"
        cboRESOVIGE.ValueMember = "VIGECODI"

        Dim objdatos3 As New cla_RESOLUCION
        Dim tbl As New DataTable

        tbl = objdatos3.fun_Buscar_ID_RESOLUCION(id)

        cboRESODEPA.SelectedValue = tbl.Rows(0).Item(1)
        cboRESOMUNI.SelectedValue = tbl.Rows(0).Item(2)
        cboRESOTIRE.SelectedValue = tbl.Rows(0).Item(3)
        cboRESOCLSE.SelectedValue = tbl.Rows(0).Item(4)
        cboRESOVIGE.SelectedValue = tbl.Rows(0).Item(5)
        txtRESOCODI.Text = Trim(tbl.Rows(0).Item(6))
        txtRESODESC.Text = Trim(tbl.Rows(0).Item(7))
        chkRESOPATO.Checked = tbl.Rows(0).Item(12)
        cboRESOESTA.SelectedValue = tbl.Rows(0).Item(13)

        '=====================
        ' CARGA LA DESCRIPCIÓN 
        '=====================

        Try
            Dim boRESODEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(cboRESODEPA.SelectedValue)
            Dim boRESOMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(cboRESODEPA.SelectedValue, cboRESOMUNI.SelectedValue)
            Dim boRESOTIRE As Boolean = fun_Buscar_Dato_TIPORESU(cboRESOTIRE.SelectedValue)
            Dim boRESOCLSE As Boolean = fun_Buscar_Dato_CLASSECT(cboRESOCLSE.SelectedValue)
            Dim boRESOVIGE As Boolean = fun_Buscar_Dato_VIGENCIA(cboRESOVIGE.SelectedValue)

            If boRESODEPA = True OrElse boRESOMUNI = True OrElse boRESOTIRE = True OrElse _
                boRESOCLSE = True OrElse boRESOVIGE = True Then

                lblRESODEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(cboRESODEPA.SelectedValue), String)
                lblRESOMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(cboRESODEPA.SelectedValue, cboRESOMUNI.SelectedValue), String)
                lblRESOTIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO(cboRESOTIRE.SelectedValue), String)
                lblRESOCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(cboRESOCLSE.SelectedValue), String)
                lblRESOVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(cboRESOVIGE.SelectedValue), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        txtRESODESC.Focus()

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtRESOCODI.Text = ""
        Me.txtRESODESC.Text = ""
        Me.txtRESOLUCION.Visible = False
        Me.cmdACTURESO.Visible = False

        Me.chkRESORESO.Checked = False
        Me.strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_8_DATOS(cboRESODEPA.Text, cboRESOMUNI.Text, cboRESOTIRE.Text, cboRESOVIGE.Text, cboRESOCLSE.Text, txtRESOCODI.Text, txtRESODESC.Text, cboRESOESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtRESODESC.Focus()
            Else
                Dim objdatos As New cla_RESOLUCION
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_RESOLUCION(id)

                Dim inRESONURE As Integer = Trim(tbl.Rows(0).Item(8))
                Dim doRESOARTE As Double = Trim(tbl.Rows(0).Item(9))
                Dim doRESOARCO As Double = Trim(tbl.Rows(0).Item(10))
                Dim inRESOPUNT As Integer = Trim(tbl.Rows(0).Item(11))
                Dim stRESOUSIN As String = Trim(tbl.Rows(0).Item(14))
                Dim daRESOFEIN As Date = Trim(tbl.Rows(0).Item(16))
                Dim stRESORESO As String = Trim(tbl.Rows(0).Item(19))
                Dim stRESOCONT As String = Trim(tbl.Rows(0).Item(20))

                Dim objdatos1 As New cla_RESOLUCION

                If (objdatos1.fun_Actualizar_RESOLUCION(id, cboRESODEPA.SelectedValue, cboRESOMUNI.SelectedValue, cboRESOTIRE.SelectedValue, cboRESOCLSE.SelectedValue, cboRESOVIGE.SelectedValue, txtRESOCODI.Text, txtRESODESC.Text, inRESONURE, doRESOARTE, doRESOARCO, inRESOPUNT, chkRESOPATO.Checked, cboRESOESTA.SelectedValue, stRESOUSIN, daRESOFEIN, stRESORESO, stRESOCONT)) Then
                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                    txtRESODESC.Focus()
                    Me.Close()
                Else
                    mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Modificar")
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtRESODESC.Focus()
        Me.Close()

    End Sub

    Private Sub cmdACTURESO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdACTURESO.Click

        Try
            If MessageBox.Show("Para ejecutar la actualización de la resolución se requiere que todos los usuarios se encuentren fuera del SICAFI. " & "¿ Desea continuar ?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtRESOLUCION.Text)) = False Then
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    Dim objdatos22 As New cla_RESOLUCION
                    Dim tbl22 As New DataTable

                    tbl22 = objdatos22.fun_Consultar_CAMPOS_RESOLUCION

                    Dim i As Integer = 0
                    Dim bySW As Byte = 0

                    For i = 0 To tbl22.Rows.Count - 1

                        If Trim(Me.txtRESOLUCION.Text) = Trim(tbl22.Rows(i).Item("RESOCODI").ToString) Then

                            bySW = 1

                        End If

                    Next

                    If bySW = 1 Then
                        MessageBox.Show("Codigo de resolución existe", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    Else

                        ' ===============================
                        ' *** ACTUALIZA LA RESOLUCION ***
                        ' ===============================

                        Me.cmdACTURESO.Enabled = False

                        ' variables
                        Dim stRESODEPA As String = fun_Formato_Mascara_2_String(Me.cboRESODEPA.SelectedValue)
                        Dim stRESOMUNI As String = fun_Formato_Mascara_3_String(Me.cboRESOMUNI.SelectedValue)
                        Dim stRESOTIRE As String = fun_Formato_Mascara_3_String(Me.cboRESOTIRE.SelectedValue)
                        Dim stRESOCLSE As String = Me.cboRESOCLSE.SelectedValue
                        Dim stRESOVIGE As String = Me.cboRESOVIGE.SelectedValue
                        Dim stRESOCODI As String = fun_Formato_Mascara_7_Reales(Me.txtRESOLUCION.Text)
                        Dim stRESOCOCA As String = stRESODEPA & stRESOMUNI & stRESOTIRE & stRESOCLSE & stRESOVIGE & fun_Formato_Mascara_7_Reales(Me.txtRESOLUCION.Text)

                        Dim objdatos99 As New cla_RESOLUCION
                        Dim tbl99 As New DataTable

                        tbl99 = objdatos99.fun_Buscar_ID_RESOLUCION(id)

                        Dim stRESOCOCA_ANT As String = Trim(tbl99.Rows(0).Item("RESORESO").ToString)

                        ' buscar cadena de conexion
                        Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion)

                        ' abre la conexion
                        oConexion.Open()

                        ' variables
                        Trim(Me.txtRESOLUCION.Text)

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update resolucion "
                        ParametrosConsulta += "set resocodi = '" & CInt(Me.txtRESOLUCION.Text) & "' "
                        ParametrosConsulta += "where resomuni = '" & CStr(Trim(stRESOMUNI)) & "' and resoclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        '________________________________

                        ' buscar cadena de conexion
                        Dim oCadenaConexion66 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion66 As String = oCadenaConexion66.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta66 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta66 += "update resolucion "
                        ParametrosConsulta66 += "set resoreso = '" & stRESOCOCA & "' "
                        ParametrosConsulta66 += "where resoreso = '" & stRESOCOCA_ANT & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta66, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' ===================================================
                        ' *** ACTUALIZA LA FICHA PREDIAL CEDULA CATASTRAL ***
                        ' ===================================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion11 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion11 As String = oCadenaConexion11.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion11)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta11 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta11 += "update fichpred "
                        ParametrosConsulta11 += "set fiprcore = '" & stRESOCOCA & "' "
                        ParametrosConsulta11 += "where fiprmuni = '" & CStr(Trim(stRESOMUNI)) & "' and fiprclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta11, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' ==================================
                        ' *** ACTUALIZA LA FICHA PREDIAL ***
                        ' ==================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion1)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta1 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta1 += "update fichpred "
                        ParametrosConsulta1 += "set fiprreso = '" & CInt(Me.txtRESOLUCION.Text) & "' "
                        ParametrosConsulta1 += "where fiprmuni = '" & CStr(Trim(stRESOMUNI)) & "' and fiprclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' ======================================
                        ' *** ACTUALIZA EL DESTINO ECONOMICO ***
                        ' ======================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion2 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion2 As String = oCadenaConexion2.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion2)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta2 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta2 += "update fiprdeec "
                        ParametrosConsulta2 += "set fpdereso = '" & CInt(Me.txtRESOLUCION.Text) & "' "
                        ParametrosConsulta2 += "where fpdemuni = '" & CStr(Trim(stRESOMUNI)) & "' and fpdeclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' ================================
                        ' *** ACTUALIZA EL PROPIETARIO ***
                        ' ================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion3 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion3 As String = oCadenaConexion3.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion3)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta3 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta3 += "update fiprprop "
                        ParametrosConsulta3 += "set fpprreso = '" & CInt(Me.txtRESOLUCION.Text) & "' "
                        ParametrosConsulta3 += "where fpprmuni = '" & CStr(Trim(stRESOMUNI)) & "' and fpprclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta3, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' =================================
                        ' *** ACTUALIZA LA CONSTRUCCION ***
                        ' =================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion4 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion4 As String = oCadenaConexion4.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion4)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta4 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta4 += "update fiprcons "
                        ParametrosConsulta4 += "set fpcoreso = '" & CInt(Me.txtRESOLUCION.Text) & "' "
                        ParametrosConsulta4 += "where fpcomuni = '" & CStr(Trim(stRESOMUNI)) & "' and fpcoclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta4, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' =================================
                        ' *** ACTUALIZA LA CALIFICACION ***
                        ' =================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion5 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion5 As String = oCadenaConexion5.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion5)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta5 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta5 += "update fiprcaco "
                        ParametrosConsulta5 += "set fpccreso = '" & CInt(Me.txtRESOLUCION.Text) & "' "
                        ParametrosConsulta5 += "where fpccmuni = '" & CStr(Trim(stRESOMUNI)) & "' and fpccclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta5, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' ==============================
                        ' *** ACTUALIZA LOS LINDEROS ***
                        ' ==============================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion6 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion6 As String = oCadenaConexion6.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion6)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta6 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta6 += "update fiprlind "
                        ParametrosConsulta6 += "set fplireso = '" & CInt(Me.txtRESOLUCION.Text) & "' "
                        ParametrosConsulta6 += "where fplimuni = '" & CStr(Trim(stRESOMUNI)) & "' and fpliclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta6, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' =================================
                        ' *** ACTUALIZA LA CARTOGRAFIA ***
                        ' =================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion7 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion7 As String = oCadenaConexion7.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion7)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta7 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta7 += "update fiprcart "
                        ParametrosConsulta7 += "set fpcareso = '" & CInt(Me.txtRESOLUCION.Text) & "' "
                        ParametrosConsulta7 += "where fpcamuni = '" & CStr(Trim(stRESOMUNI)) & "' and fpcaclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta7, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' ================================
                        ' *** ACTUALIZA LA ZONA FISICA ***
                        ' ================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion8 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion8 As String = oCadenaConexion8.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion8)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta8 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta8 += "update fiprzofi "
                        ParametrosConsulta8 += "set fpzfreso = '" & CInt(Me.txtRESOLUCION.Text) & "' "
                        ParametrosConsulta8 += "where fpzfmuni = '" & CStr(Trim(stRESOMUNI)) & "' and fpzfclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta8, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' ===================================
                        ' *** ACTUALIZA LA ZONA ECONOMICA ***
                        ' ===================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion9 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion9 As String = oCadenaConexion9.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion9)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta9 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta9 += "update fiprzoec "
                        ParametrosConsulta9 += "set fpzereso = '" & CInt(Me.txtRESOLUCION.Text) & "' "
                        ParametrosConsulta9 += "where fpzemuni = '" & CStr(Trim(stRESOMUNI)) & "' and fpzeclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta9, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        Me.txtRESOCODI.Text = CInt(Me.txtRESOLUCION.Text)

                        mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

                        Me.cmdGUARDAR.PerformClick()

                        Me.cmdACTURESO.Enabled = True

                    End If
                End If

            Else
                mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdACTUVIGE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdACTUVIGE.Click

        Try
            If MessageBox.Show("Para ejecutar la actualización de la vigencia se requiere que todos los usuarios se encuentren fuera del SICAFI. " & "¿ Desea continuar ?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtVIGENCIA.Text)) = False Then
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    Dim boVIGENCIA As Boolean = False

                    boVIGENCIA = fun_Buscar_Dato_VIGENCIA(Trim(Me.txtVIGENCIA.Text))

                    If boVIGENCIA = False Then
                        MessageBox.Show("Vigencia no existe en base de datos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)

                        If MessageBox.Show("¿ Desea ingresar la vigencia ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_VIGENCIA()
                        End If

                    Else
                        Me.cmdACTUVIGE.Enabled = False

                        ' variables
                        Dim stRESODEPA As String = fun_Formato_Mascara_2_String(Me.cboRESODEPA.SelectedValue)
                        Dim stRESOMUNI As String = fun_Formato_Mascara_3_String(Me.cboRESOMUNI.SelectedValue)
                        Dim stRESOTIRE As String = fun_Formato_Mascara_3_String(Me.cboRESOTIRE.SelectedValue)
                        Dim stRESOCLSE As String = Me.cboRESOCLSE.SelectedValue
                        Dim stRESOVIGE As String = fun_Formato_Mascara_4_Reales(Me.txtVIGENCIA.Text)
                        Dim stRESOCODI As String = fun_Formato_Mascara_7_Reales(Me.txtRESOCODI.Text)
                        Dim stRESOCOCA As String = stRESODEPA & stRESOMUNI & stRESOTIRE & stRESOCLSE & stRESOVIGE & fun_Formato_Mascara_7_Reales(Me.txtRESOCODI.Text)

                        Dim objdatos99 As New cla_RESOLUCION
                        Dim tbl99 As New DataTable

                        tbl99 = objdatos99.fun_Buscar_ID_RESOLUCION(id)

                        Dim stRESOCOCA_ANT As String = Trim(tbl99.Rows(0).Item("RESORESO").ToString)

                        ' ===============================
                        ' *** ACTUALIZA LA RESOLUCION ***
                        ' ===============================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion)

                        ' abre la conexion
                        oConexion.Open()

                        ' variables
                        Me.cboRESOVIGE.SelectedValue = CInt(Me.txtVIGENCIA.Text)
                        Me.lblRESOVIGE.Text = fun_Buscar_Lista_Valores_VIGENCIA(CInt(Me.txtVIGENCIA.Text))

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update resolucion "
                        ParametrosConsulta += "set resovige = '" & CInt(Me.txtVIGENCIA.Text) & "' "
                        ParametrosConsulta += "where resomuni = '" & CStr(Trim(stRESOMUNI)) & "' and resoclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing


                        '__________________________________

                        ' buscar cadena de conexion
                        Dim oCadenaConexion55 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion55 As String = oCadenaConexion55.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta55 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta55 += "update resolucion "
                        ParametrosConsulta55 += "set resoreso = '" & stRESOCOCA & "' "
                        ParametrosConsulta55 += "where resoreso = '" & stRESOCOCA_ANT & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta55, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' ===================================================
                        ' *** ACTUALIZA LA FICHA PREDIAL CEDULA CATASTRAL ***
                        ' ===================================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion11 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion11 As String = oCadenaConexion11.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion11)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta11 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta11 += "update fichpred "
                        ParametrosConsulta11 += "set fiprcore = '" & stRESOCOCA & "' "
                        ParametrosConsulta11 += "where fiprmuni = '" & CStr(Trim(stRESOMUNI)) & "' and fiprclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta11, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' ==================================
                        ' *** ACTUALIZA LA FICHA PREDIAL ***
                        ' ==================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion1)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta1 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta1 += "update fichpred "
                        ParametrosConsulta1 += "set fiprvige = '" & CInt(Me.txtVIGENCIA.Text) & "' "
                        ParametrosConsulta1 += "where fiprmuni = '" & CStr(Trim(stRESOMUNI)) & "' and fiprclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' ======================================
                        ' *** ACTUALIZA EL DESTINO ECONOMICO ***
                        ' ======================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion2 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion2 As String = oCadenaConexion2.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion2)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta2 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta2 += "update fiprdeec "
                        ParametrosConsulta2 += "set fpdevige = '" & CInt(Me.txtVIGENCIA.Text) & "' "
                        ParametrosConsulta2 += "where fpdemuni = '" & CStr(Trim(stRESOMUNI)) & "' and fpdeclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' ================================
                        ' *** ACTUALIZA EL PROPIETARIO ***
                        ' ================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion3 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion3 As String = oCadenaConexion3.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion3)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta3 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta3 += "update fiprprop "
                        ParametrosConsulta3 += "set fpprvige = '" & CInt(Me.txtVIGENCIA.Text) & "' "
                        ParametrosConsulta3 += "where fpprmuni = '" & CStr(Trim(stRESOMUNI)) & "' and fpprclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta3, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' =================================
                        ' *** ACTUALIZA LA CONSTRUCCION ***
                        ' =================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion4 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion4 As String = oCadenaConexion4.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion4)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta4 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta4 += "update fiprcons "
                        ParametrosConsulta4 += "set fpcovige = '" & CInt(Me.txtVIGENCIA.Text) & "' "
                        ParametrosConsulta4 += "where fpcomuni = '" & CStr(Trim(stRESOMUNI)) & "' and fpcoclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta4, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' =================================
                        ' *** ACTUALIZA LA CALIFICACION ***
                        ' =================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion5 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion5 As String = oCadenaConexion5.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion5)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta5 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta5 += "update fiprcaco "
                        ParametrosConsulta5 += "set fpccvige = '" & CInt(Me.txtVIGENCIA.Text) & "' "
                        ParametrosConsulta5 += "where fpccmuni = '" & CStr(Trim(stRESOMUNI)) & "' and fpccclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta5, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' ==============================
                        ' *** ACTUALIZA LOS LINDEROS ***
                        ' ==============================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion6 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion6 As String = oCadenaConexion6.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion6)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta6 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta6 += "update fiprlind "
                        ParametrosConsulta6 += "set fplivige = '" & CInt(Me.txtVIGENCIA.Text) & "' "
                        ParametrosConsulta6 += "where fplimuni = '" & CStr(Trim(stRESOMUNI)) & "' and fpliclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta6, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' =================================
                        ' *** ACTUALIZA LA CARTOGRAFIA ***
                        ' =================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion7 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion7 As String = oCadenaConexion7.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion7)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta7 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta7 += "update fiprcart "
                        ParametrosConsulta7 += "set fpcavige = '" & CInt(Me.txtVIGENCIA.Text) & "' "
                        ParametrosConsulta7 += "where fpcamuni = '" & CStr(Trim(stRESOMUNI)) & "' and fpcaclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta7, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' ================================
                        ' *** ACTUALIZA LA ZONA FISICA ***
                        ' ================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion8 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion8 As String = oCadenaConexion8.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion8)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta8 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta8 += "update fiprzofi "
                        ParametrosConsulta8 += "set fpzfvige = '" & CInt(Me.txtVIGENCIA.Text) & "' "
                        ParametrosConsulta8 += "where fpzfmuni = '" & CStr(Trim(stRESOMUNI)) & "' and fpzfclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta8, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' ===================================
                        ' *** ACTUALIZA LA ZONA ECONOMICA ***
                        ' ===================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion9 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion9 As String = oCadenaConexion9.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion9)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta9 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta9 += "update fiprzoec "
                        ParametrosConsulta9 += "set fpzevige = '" & CInt(Me.txtVIGENCIA.Text) & "' "
                        ParametrosConsulta9 += "where fpzemuni = '" & CStr(Trim(stRESOMUNI)) & "' and fpzeclse = '" & CInt(stRESOCLSE) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta9, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

                        Me.cmdGUARDAR.PerformClick()

                        Me.cmdACTUVIGE.Enabled = True

                    End If
                End If

            Else
                mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub


#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txtRESODESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRESODESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboRESOESTA.Focus()
        End If
    End Sub
    Private Sub cboRESOESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRESOESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            chkRESOPATO.Focus()
        End If
    End Sub
    Private Sub chkRESOPATO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkRESOPATO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtRESODESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRESODESC.Validated
        If Trim(txtRESODESC.Text) = "" Then
            txtRESODESC.Text = "."
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboRESOESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRESOESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtRESODESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRESODESC.GotFocus
        txtRESODESC.SelectionStart = 0
        txtRESODESC.SelectionLength = Len(txtRESODESC.Text)
        strBARRESTA.Items(0).Text = txtRESODESC.AccessibleDescription
    End Sub
    Private Sub cboRESOESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRESOESTA.GotFocus
        cboRESOESTA.SelectionStart = 0
        cboRESOESTA.SelectionLength = Len(cboRESOESTA.Text)
        strBARRESTA.Items(0).Text = cboRESOESTA.AccessibleDescription
    End Sub
    Private Sub chkRESOPATO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRESOPATO.GotFocus
        strBARRESTA.Items(0).Text = chkRESOPATO.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

#End Region

#Region "ResizeBegin"

    Private Sub frm_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        Me.Opacity = vp_Opacity
    End Sub

#End Region

#Region "ResizeEnd"

    Private Sub frm_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim opacity As Double = Convert.ToDouble(100)
        Me.Opacity = opacity
    End Sub

#End Region

#Region "CheckedChanged"

    Private Sub chkRESORESO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRESORESO.CheckedChanged

        If Me.chkRESORESO.Checked = True Then
            Me.txtRESOLUCION.Visible = True
            Me.txtRESOLUCION.Text = ""
            Me.cmdACTURESO.Visible = True
        Else
            Me.txtRESOLUCION.Visible = False
            Me.cmdACTURESO.Visible = False
        End If

    End Sub
    Private Sub chkRESOVIGE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRESOVIGE.CheckedChanged

        If Me.chkRESOVIGE.Checked = True Then
            Me.txtVIGENCIA.Visible = True
            Me.txtVIGENCIA.Text = ""
            Me.cmdACTUVIGE.Visible = True
        Else
            Me.txtVIGENCIA.Visible = False
            Me.cmdACTUVIGE.Visible = False
        End If

    End Sub

#End Region


#End Region

End Class