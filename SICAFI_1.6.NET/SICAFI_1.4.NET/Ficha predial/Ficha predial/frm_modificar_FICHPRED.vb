Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_modificar_FICHPRED

    '===============================
    '*** MODIFICAR FICHA PREDIAL ***
    '===============================

#Region "CONSTRUCTORES"

    Public Sub New(ByVal idFIPRNUFI As Integer, _
                   ByVal idRESODEPA As String, _
                   ByVal idRESOMUNI As String, _
                   ByVal idRESOTIRE As Integer, _
                   ByVal idRESOCLSE As Integer, _
                   ByVal idRESOVIGE As Integer, _
                   ByVal idRESOCODI As Integer, _
                   ByVal idRESORESO As String)

        vl_inFIPRNUFI = idFIPRNUFI
        vl_stRESODEPA = idRESODEPA
        vl_stRESOMUNI = idRESOMUNI
        vl_inRESOTIRE = idRESOTIRE
        vl_inRESOCLSE = idRESOCLSE
        vl_inRESOVIGE = idRESOVIGE
        vl_inRESOCODI = idRESOCODI
        vl_stRESORESO = idRESORESO

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader

#End Region
  
#Region "VARIABLES LOCALES"

    '*** VARIABLES QUE RECIBE DEL FORMULARIO DE FICHA PREDIAL ***
    Dim vl_inFIPRNUFI As Integer
    Dim vl_stRESODEPA As String
    Dim vl_stRESOMUNI As String
    Dim vl_inRESOTIRE As Integer
    Dim vl_inRESOCLSE As Integer
    Dim vl_inRESOVIGE As Integer
    Dim vl_inRESOCODI As Integer
    Dim vl_stRESORESO As String
    Dim vl_boSWVerificaDatoAlGuardar As Boolean = True

    '*** VARIABLES DE LA MASCARA DE LA CEDULA CATASTRAL ***
    Dim Mascara As Integer
    Dim Formato As String

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()

        '===============================================================
        ' CARGA LOS COMBOBOX CON TODOS LOS REGISTROS ACTIVOS E INACTIVOS
        '===============================================================

        fun_Cargar_ComboBox_Con_Todos_Los_Datos_CLASSECT(cboFIPRCLSE, cboFIPRCLSE.SelectedIndex)
        fun_Cargar_ComboBox_Con_Todos_Los_Datos_CLASSECT(cboFIPRCSAN, cboFIPRCSAN.SelectedIndex)
        fun_Cargar_ComboBox_Con_Todos_Los_Datos_CATESUEL(cboFIPRCASU, cboFIPRCASU.SelectedIndex)
        fun_Cargar_ComboBox_Con_Todos_Los_Datos_CATESUEL(cboFIPRCASA, cboFIPRCASA.SelectedIndex)
        fun_Cargar_ComboBox_Con_Todos_Los_Datos_CARAPRED(cboFIPRCAPR, cboFIPRCAPR.SelectedIndex)
        fun_Cargar_ComboBox_Con_Todos_Los_Datos_MODOADQU(cboFIPRMOAD, cboFIPRMOAD.SelectedIndex)
        fun_Cargar_ComboBox_Con_Todos_Los_Datos_ESTADO(cboFIPRESTA, cboFIPRESTA.SelectedIndex)

        '==================================================
        ' LLENO LOS CAMPOS SEGUN EL NUMERO DE FICHA PREDIAL
        '==================================================

        Dim objdatos15 As New cla_FICHPRED
        Dim tbl_FICHPRED As New DataTable

        tbl_FICHPRED = objdatos15.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(vl_inFIPRNUFI)

        txtFIPRNUFI.Text = Trim(tbl_FICHPRED.Rows(0).Item(1))
        'txtFIPRVIGE.Text = Trim(tbl_FICHPRED.Rows(0).Item(2))
        'txtFIPRTIRE.Text = Trim(tbl_FICHPRED.Rows(0).Item(3))
        'txtFIPRRESO.Text = Trim(tbl_FICHPRED.Rows(0).Item(4))
        txtFIPRDIRE.Text = Trim(tbl_FICHPRED.Rows(0).Item(5))
        txtFIPRDESC.Text = Trim(tbl_FICHPRED.Rows(0).Item(6))
        chkFIPRCONJ.Checked = tbl_FICHPRED.Rows(0).Item(7)
        'txtFIPRFECH.Text = Trim(tbl_FICHPRED.Rows(0).Item(8))
        'txtFIPRNURE.Text = Trim(tbl_FICHPRED.Rows(0).Item(9))
        'txtFIPRDEPA.Text = Trim(tbl_FICHPRED.Rows(0).Item(10))
        txtFIPRMUNI.Text = Trim(tbl_FICHPRED.Rows(0).Item(11))
        txtFIPRCORR.Text = Trim(tbl_FICHPRED.Rows(0).Item(12))
        txtFIPRBARR.Text = Trim(tbl_FICHPRED.Rows(0).Item(13))
        txtFIPRMANZ.Text = Trim(tbl_FICHPRED.Rows(0).Item(14))
        txtFIPRPRED.Text = Trim(tbl_FICHPRED.Rows(0).Item(15))
        txtFIPREDIF.Text = Trim(tbl_FICHPRED.Rows(0).Item(16))
        txtFIPRUNPR.Text = Trim(tbl_FICHPRED.Rows(0).Item(17))
        cboFIPRCLSE.SelectedValue = Trim(tbl_FICHPRED.Rows(0).Item(18))
        cboFIPRCASU.SelectedValue = Trim(tbl_FICHPRED.Rows(0).Item(19))
        txtFIPRMUAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(20))
        txtFIPRCOAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(21))
        txtFIPRBAAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(22))
        txtFIPRMAAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(23))
        txtFIPRPRAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(24))
        txtFIPREDAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(25))
        txtFIPRUPAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(26))
        cboFIPRCSAN.SelectedValue = Trim(tbl_FICHPRED.Rows(0).Item(27))
        cboFIPRCASA.SelectedValue = Trim(tbl_FICHPRED.Rows(0).Item(28))
        cboFIPRCAPR.SelectedValue = Trim(tbl_FICHPRED.Rows(0).Item(29))
        cboFIPRMOAD.SelectedValue = Trim(tbl_FICHPRED.Rows(0).Item(30))
        txtFIPRARTE.Text = Trim(tbl_FICHPRED.Rows(0).Item(31))
        txtFIPRCOPR.Text = Trim(tbl_FICHPRED.Rows(0).Item(32))
        txtFIPRCOED.Text = Trim(tbl_FICHPRED.Rows(0).Item(33))
        cboFIPRESTA.SelectedValue = tbl_FICHPRED.Rows(0).Item(34)
        'txtFIPRCECA.Text = Trim(tbl_FICHPRED.Rows(0).Item(35))
        'txtFIPRDATR.Text = Trim(tbl_FICHPRED.Rows(0).Item(36))
        'txtFIPRDAVI.Text = Trim(tbl_FICHPRED.Rows(0).Item(37))
        'txtFIPRDAND.Text = Trim(tbl_FICHPRED.Rows(0).Item(38))
        'txtFIPRCORE.Text = Trim(tbl_FICHPRED.Rows(0).Item(39))
        'txtFIPRUSIN.Text = Trim(tbl_FICHPRED.Rows(0).Item(40))
        'txtFIPRUSMO.Text = Trim(tbl_FICHPRED.Rows(0).Item(41))
        'txtFIPRFEIN.Text = Trim(tbl_FICHPRED.Rows(0).Item(42))
        'txtFIPRFEMO.Text = Trim(tbl_FICHPRED.Rows(0).Item(43))
        'txtFIPRMAQU.Text = Trim(tbl_FICHPRED.Rows(0).Item(44))
        'txtFIPROBSE.Text = Trim(tbl_FICHPRED.Rows(0).Item(45))
        chkFIPRLITI.Checked = tbl_FICHPRED.Rows(0).Item(46)
        txtFIPRPOLI.Text = Trim(tbl_FICHPRED.Rows(0).Item(47))

        '==================
        ' FORMATO DE CAMPOS
        '==================

        txtFIPRPOLI.Text = fun_Formato_Decimal_2_Decimales(txtFIPRPOLI.Text)
        txtFIPRCOPR.Text = fun_Formato_Decimal_6_Decimales(txtFIPRCOPR.Text)
        txtFIPRCOED.Text = fun_Formato_Decimal_6_Decimales(txtFIPRCOED.Text)

        '=====================
        ' CARGA LA DESCRIPCIÓN 
        '=====================
        Try
            cboFIPRCLSE.SelectedValue = vl_inRESOCLSE
            txtFIPRMUNI.Text = vl_stRESOMUNI

            Dim boFIPRCLSE As Boolean = fun_Buscar_Dato_CLASSECT(cboFIPRCLSE.SelectedValue)
            Dim boFIPRCSAN As Boolean = fun_Buscar_Dato_CLASSECT(cboFIPRCSAN.SelectedValue)
            Dim boFIPRCASU As Boolean = fun_Buscar_Dato_CATESUEL(cboFIPRCASU.SelectedValue)
            Dim boFIPRCASA As Boolean = fun_Buscar_Dato_CATESUEL(cboFIPRCASA.SelectedValue)
            Dim boFIPRCAPR As Boolean = fun_Buscar_Dato_CARAPRED(cboFIPRCAPR.SelectedValue)
            Dim boFIPRMOAD As Boolean = fun_Buscar_Dato_MODOADQU(cboFIPRMOAD.SelectedValue)

            If boFIPRCLSE = True AndAlso boFIPRCLSE = True AndAlso boFIPRCASU = True AndAlso _
               boFIPRCASA = True AndAlso boFIPRCAPR = True AndAlso boFIPRMOAD = True Then

                lblFIPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(cboFIPRCLSE.SelectedValue), String)
                lblFIPRCSAN.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(cboFIPRCSAN.SelectedValue), String)
                lblFIPRCASU.Text = CType(fun_Buscar_Lista_Valores_CATESUEL(cboFIPRCASU.SelectedValue), String)
                lblFIPRCASA.Text = CType(fun_Buscar_Lista_Valores_CATESUEL(cboFIPRCASA.SelectedValue), String)
                lblFIPRCAPR.Text = CType(fun_Buscar_Lista_Valores_CARAPRED(cboFIPRCAPR.SelectedValue), String)
                lblFIPRMOAD.Text = CType(fun_Buscar_Lista_Valores_MODOADQU(cboFIPRMOAD.SelectedValue), String)
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        txtFIPRDESC.Focus()

    End Sub
    Private Sub pro_LimpiarCampos()

        txtFIPRNUFI.Text = ""
        txtFIPRDIRE.Text = ""
        txtFIPRDESC.Text = ""
        chkFIPRCONJ.Checked = False
        txtFIPRMUNI.Text = ""
        txtFIPRCORR.Text = ""
        txtFIPRBARR.Text = ""
        txtFIPRMANZ.Text = ""
        txtFIPRPRED.Text = ""
        txtFIPREDIF.Text = ""
        txtFIPRUNPR.Text = ""
        txtFIPRMUAN.Text = ""
        txtFIPRCOAN.Text = ""
        txtFIPRBAAN.Text = ""
        txtFIPRMAAN.Text = ""
        txtFIPRPRAN.Text = ""
        txtFIPREDAN.Text = ""
        txtFIPRUPAN.Text = ""
        chkFIPRLITI.Checked = False
        txtFIPRPOLI.Text = "0.00"
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            If fun_Verificar_Campos_Llenos_23_DATOS(txtFIPRDIRE.Text, txtFIPRMUNI.Text, txtFIPRCORR.Text, txtFIPRBARR.Text, txtFIPRMANZ.Text, txtFIPRPRED.Text, txtFIPREDIF.Text, txtFIPRUNPR.Text, cboFIPRCLSE.Text, cboFIPRCASU.Text, txtFIPRMUAN.Text, txtFIPRCOAN.Text, txtFIPRBAAN.Text, txtFIPRMAAN.Text, txtFIPRPRAN.Text, txtFIPREDAN.Text, txtFIPRUPAN.Text, cboFIPRCSAN.Text, cboFIPRCASA.Text, cboFIPRCAPR.Text, cboFIPRMOAD.Text, cboFIPRESTA.Text, txtFIPRPOLI.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtFIPRDESC.Focus()
            Else
                If vl_boSWVerificaDatoAlGuardar = False Then
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    Dim objdatos10 As New cla_FICHPRED
                    Dim tbl_FICHPRED As New DataTable

                    tbl_FICHPRED = objdatos10.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(Val(txtFIPRNUFI.Text))

                    Dim inFIPRIDRE As Integer = Trim(tbl_FICHPRED.Rows(0).Item(0))
                    Dim daFIPRFECH As Date = Trim(tbl_FICHPRED.Rows(0).Item(8))
                    Dim inFIPRNURE As Integer = Trim(tbl_FICHPRED.Rows(0).Item(9))
                    Dim inFIPRARTE As Integer = CType(txtFIPRARTE.Text, Integer)
                    Dim stFIPRCOPR As String = CType(txtFIPRCOPR.Text, String)
                    Dim stFIPRCOED As String = CType(txtFIPRCOED.Text, String)
                    Dim stFIPRUSIN As String = Trim(tbl_FICHPRED.Rows(0).Item(40))
                    Dim daFIPRFEIN As Date = Trim(tbl_FICHPRED.Rows(0).Item(42))
                    Dim stFIPROBSE As String = Trim(tbl_FICHPRED.Rows(0).Item(45))
                    Dim stFIPRCECA As String = Trim(tbl_FICHPRED.Rows(0).Item(35))
                    Dim stFIPRDATR As String = Trim(tbl_FICHPRED.Rows(0).Item(36))
                    Dim stFIPRDAVI As String = Trim(tbl_FICHPRED.Rows(0).Item(37))
                    Dim stFIPRDAND As String = Trim(tbl_FICHPRED.Rows(0).Item(38))
                    Dim stFIPRCORE As String = Trim(tbl_FICHPRED.Rows(0).Item(39))
                    Dim inFIPRTIFI As Integer = Trim(tbl_FICHPRED.Rows(0).Item(48))
                    Dim boFIPRINCO As Boolean = Trim(tbl_FICHPRED.Rows(0).Item(49))

                    Dim objdatos11 As New cla_FICHPRED

                    If (objdatos11.fun_Actualizar_FICHPRED(inFIPRIDRE, txtFIPRNUFI.Text, vl_inRESOVIGE, vl_inRESOTIRE, vl_inRESOCODI, txtFIPRDIRE.Text, txtFIPRDESC.Text, chkFIPRCONJ.Checked, daFIPRFECH, inFIPRNURE, vl_stRESODEPA, txtFIPRMUNI.Text, txtFIPRCORR.Text, txtFIPRBARR.Text, txtFIPRMANZ.Text, txtFIPRPRED.Text, txtFIPREDIF.Text, txtFIPRUNPR.Text, cboFIPRCLSE.SelectedValue, cboFIPRCASU.SelectedValue, txtFIPRMUAN.Text, txtFIPRCOAN.Text, txtFIPRBAAN.Text, txtFIPRMAAN.Text, txtFIPRPRAN.Text, txtFIPREDAN.Text, txtFIPRUPAN.Text, cboFIPRCSAN.SelectedValue, cboFIPRCASA.SelectedValue, cboFIPRCAPR.SelectedValue, cboFIPRMOAD.SelectedValue, inFIPRARTE, stFIPRCOPR, stFIPRCOED, cboFIPRESTA.SelectedValue, stFIPRUSIN, daFIPRFEIN, stFIPROBSE, stFIPRCECA, stFIPRDATR, stFIPRDAVI, stFIPRDAND, chkFIPRLITI.Checked, txtFIPRPOLI.Text, vl_stRESORESO, inFIPRTIFI, boFIPRINCO)) Then

                        '=============================================
                        '*** ACTUALIZA EL REGISTRO EN PROPIETARIOS ***
                        '=============================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' variables
                        Dim inFPPRMOAD As Integer = cboFIPRMOAD.Text
                        Dim boFPPRLITI As Boolean = chkFIPRLITI.Checked
                        Dim stFPPRPOLI As String = Trim(txtFIPRPOLI.Text)
                        Dim stFPPRLITI As String = 0

                        ' convierte el tipo boolean a string
                        If boFPPRLITI = True Then
                            stFPPRLITI = 1
                        ElseIf boFPPRLITI = False Then
                            stFPPRLITI = 0
                        End If

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update FIPRPROP "
                        ParametrosConsulta += "set FPPRMOAD = '" & inFPPRMOAD & "', "
                        ParametrosConsulta += "FPPRLITI = '" & stFPPRLITI & "', "
                        ParametrosConsulta += "FPPRPOLI = '" & stFPPRPOLI & "' "
                        ParametrosConsulta += "where FPPRNUFI = '" & vl_inFIPRNUFI & "'"

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text
                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        txtFIPRDESC.Focus()
                        Me.Close()
                    Else
                        txtFIPRDESC.Focus()
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtFIPRDESC.Focus()
        Dim frm_FICHPRED As New frm_FICHPRED(Val(Me.txtFIPRNUFI.Text))
        Me.Close()
    End Sub
    Private Sub cmdCAMBIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCAMBIAR.Click

        Try
            Dim inNroFichaActual As Integer = CInt(Me.txtFIPRNUFI.Text)
            Dim stNroFichaCorregido As String = ""

            stNroFichaCorregido = InputBox("Digite el número de ficha predial")

            If Trim(stNroFichaCorregido.ToString.Length) > 9 Then
                MessageBox.Show("El valor supera la longitud permitida", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stNroFichaCorregido)) = False Then
                    MessageBox.Show("El valor no es númerico", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim obFICHPRED As New cla_FICHPRED
                    Dim tdFICHPRED As New DataTable

                    tdFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(CInt(stNroFichaCorregido))

                    If tdFICHPRED.Rows.Count > 0 Then
                        MessageBox.Show("Ficha existe la base de datos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    Else
                        '=========================================
                        '*** ACTUALIZA EL NRO DE FICHA PREDIAL ***
                        '=========================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update FICHPRED "
                        ParametrosConsulta += "set FIPRNUFI = '" & CInt(stNroFichaCorregido) & "' "
                        ParametrosConsulta += "where FIPRNUFI = '" & CInt(inNroFichaActual) & "' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text
                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

                        Me.txtFIPRNUFI.Text = stNroFichaCorregido

                        Me.txtFIPRNUFI.Focus()
                        Me.cmdGUARDAR.Visible = False



                    End If

                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FORMULARIO "

#Region "KeyPress"

    Private Sub txtFIPRNUFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRNUFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRDESC.Focus()
        End If
    End Sub
    Private Sub txtFIPRDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRDESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRDIRE.Focus()
        End If
    End Sub
    Private Sub txtFIPRDIRE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRDIRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            chkFIPRCONJ.Focus()
        End If
    End Sub
    Private Sub chkFIPRCONJ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkFIPRCONJ.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRMUNI.Focus()
        End If
    End Sub
    Private Sub txtFIPRMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMUNI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCORR.Focus()
        End If
    End Sub
    Private Sub txtFIPRCORR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCORR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRBARR.Focus()
        End If
    End Sub
    Private Sub txtFIPRBARR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRBARR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRMANZ.Focus()
        End If
    End Sub
    Private Sub txtFIPRMANZ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMANZ.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRPRED.Focus()
        End If

    End Sub
    Private Sub txtFIPRPRED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRPRED.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPREDIF.Focus()
        End If
    End Sub
    Private Sub txtFIPREDIF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPREDIF.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRUNPR.Focus()
        End If
    End Sub
    Private Sub txtFIPRUNPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRUNPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFIPRCASU.Focus()
        End If
    End Sub
    Private Sub cboFIPRCASU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRCASU.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRMUAN.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CATESUEL(cboFIPRCASU, cboFIPRCASU.SelectedIndex)
        End If
    End Sub
    Private Sub txtFIPRMUAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMUAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCOAN.Focus()
        End If
    End Sub
    Private Sub txtFIPRCOAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCOAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRBAAN.Focus()
        End If
    End Sub
    Private Sub txtFIPRBAAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRBAAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRMAAN.Focus()
        End If
    End Sub
    Private Sub txtFIPRMAAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMAAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRPRAN.Focus()
        End If
    End Sub
    Private Sub txtFIPRPRAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRPRAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPREDAN.Focus()
        End If
    End Sub
    Private Sub txtFIPREDAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPREDAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRUPAN.Focus()
        End If
    End Sub
    Private Sub txtFIPRUPAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRUPAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFIPRCSAN.Focus()
        End If
    End Sub
    Private Sub cboFIPRCSAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRCSAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFIPRCASA.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT(cboFIPRCSAN, cboFIPRCSAN.SelectedIndex)
        End If
    End Sub
    Private Sub cboFIPRCASA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRCASA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFIPRCAPR.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CATESUEL(cboFIPRCASA, cboFIPRCASA.SelectedIndex)
        End If
    End Sub
    Private Sub cboFIPRCAPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRCAPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFIPRMOAD.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CARAPRED(cboFIPRCAPR, cboFIPRCAPR.SelectedIndex)
        End If
    End Sub
    Private Sub cboFIPRMOAD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRMOAD.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRARTE.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MODOADQU(cboFIPRMOAD, cboFIPRMOAD.SelectedIndex)
        End If
    End Sub
    Private Sub cboFIPRESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFIPRESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub
    Private Sub txtFIPRPOLI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRPOLI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub
    Private Sub txtFIPRARTE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRARTE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCOPR.Focus()
        End If
    End Sub
    Private Sub txtFIPRCOPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCOPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCOED.Focus()
        End If
    End Sub
    Private Sub txtFIPRCOED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCOED.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFIPRESTA.Focus()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboFIPRCASU_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFIPRCASU.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim frm_insertar_CATESUEL As New frm_insertar_CATESUEL
            frm_insertar_CATESUEL.Show()
        End If
    End Sub
    Private Sub cboFIPRCSAN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFIPRCSAN.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim frm_insertar_CLASSECT As New frm_insertar_CLASSECT
            frm_insertar_CLASSECT.Show()
        End If
    End Sub
    Private Sub cboFIPRCASA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFIPRCASA.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim frm_insertar_CATESUEL As New frm_insertar_CATESUEL
            frm_insertar_CATESUEL.Show()
        End If
    End Sub
    Private Sub cboFIPRCAPR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFIPRCAPR.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim frm_insertar_CARAPRED As New frm_insertar_CARAPRED
            frm_insertar_CARAPRED.Show()
        End If
    End Sub
    Private Sub cboFIPRMOAD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFIPRMOAD.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim frm_insertar_MODOADQU As New frm_insertar_MODOADQU
            frm_insertar_MODOADQU.Show()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtFIPRNUFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRNUFI.GotFocus
        txtFIPRNUFI.SelectionStart = 0
        txtFIPRNUFI.SelectionLength = Len(txtFIPRNUFI.Text)
        strBARRESTA.Items(0).Text = txtFIPRNUFI.AccessibleDescription
    End Sub
    Private Sub txtFIPRDESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRDESC.GotFocus
        txtFIPRDESC.SelectionStart = 0
        txtFIPRDESC.SelectionLength = Len(txtFIPRDESC.Text)
        strBARRESTA.Items(0).Text = txtFIPRDESC.AccessibleDescription
    End Sub
    Private Sub txtFIPRDIRE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRDIRE.GotFocus
        txtFIPRDIRE.SelectionStart = 0
        txtFIPRDIRE.SelectionLength = Len(txtFIPRDIRE.Text)
        strBARRESTA.Items(0).Text = txtFIPRDIRE.AccessibleDescription
    End Sub
    Private Sub chkFIPRCONJ_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFIPRCONJ.GotFocus
        strBARRESTA.Items(0).Text = chkFIPRCONJ.AccessibleDescription
    End Sub
    Private Sub txtFIPRMUNI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.GotFocus
        txtFIPRMUNI.SelectionStart = 0
        txtFIPRMUNI.SelectionLength = Len(txtFIPRMUNI.Text)
        strBARRESTA.Items(0).Text = txtFIPRMUNI.AccessibleDescription
    End Sub
    Private Sub txtFIPRCORR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.GotFocus
        txtFIPRCORR.SelectionStart = 0
        txtFIPRCORR.SelectionLength = Len(txtFIPRCORR.Text)
        strBARRESTA.Items(0).Text = txtFIPRCORR.AccessibleDescription
    End Sub
    Private Sub txtFIPRBARR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.GotFocus
        txtFIPRBARR.SelectionStart = 0
        txtFIPRBARR.SelectionLength = Len(txtFIPRBARR.Text)
        strBARRESTA.Items(0).Text = txtFIPRBARR.AccessibleDescription
    End Sub
    Private Sub txtFIPRMANZ_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.GotFocus
        txtFIPRMANZ.SelectionStart = 0
        txtFIPRMANZ.SelectionLength = Len(txtFIPRMANZ.Text)
        strBARRESTA.Items(0).Text = txtFIPRMANZ.AccessibleDescription
    End Sub
    Private Sub txtFIPRPRED_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.GotFocus
        txtFIPRPRED.SelectionStart = 0
        txtFIPRPRED.SelectionLength = Len(txtFIPRPRED.Text)
        strBARRESTA.Items(0).Text = txtFIPRPRED.AccessibleDescription
    End Sub
    Private Sub txtFIPREDIF_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.GotFocus
        txtFIPREDIF.SelectionStart = 0
        txtFIPREDIF.SelectionLength = Len(txtFIPREDIF.Text)
        strBARRESTA.Items(0).Text = txtFIPREDIF.AccessibleDescription
    End Sub
    Private Sub txtFIPRUNPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.GotFocus
        txtFIPRUNPR.SelectionStart = 0
        txtFIPRUNPR.SelectionLength = Len(txtFIPRUNPR.Text)
        strBARRESTA.Items(0).Text = txtFIPRUNPR.AccessibleDescription
    End Sub
    Private Sub txtFIPRMUAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUAN.GotFocus
        txtFIPRMUAN.SelectionStart = 0
        txtFIPRMUAN.SelectionLength = Len(txtFIPRMUAN.Text)
        strBARRESTA.Items(0).Text = txtFIPRMUAN.AccessibleDescription
    End Sub
    Private Sub txtFIPRCOAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCOAN.GotFocus
        txtFIPRCOAN.SelectionStart = 0
        txtFIPRCOAN.SelectionLength = Len(txtFIPRCOAN.Text)
        strBARRESTA.Items(0).Text = txtFIPRCOAN.AccessibleDescription
    End Sub
    Private Sub txtFIPRBAAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBAAN.GotFocus
        txtFIPRBAAN.SelectionStart = 0
        txtFIPRBAAN.SelectionLength = Len(txtFIPRBAAN.Text)
        strBARRESTA.Items(0).Text = txtFIPRBAAN.AccessibleDescription
    End Sub
    Private Sub txtFIPRMAAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMAAN.GotFocus
        txtFIPRMAAN.SelectionStart = 0
        txtFIPRMAAN.SelectionLength = Len(txtFIPRMAAN.Text)
        strBARRESTA.Items(0).Text = txtFIPRMAAN.AccessibleDescription
    End Sub
    Private Sub txtFIPRPRAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRAN.GotFocus
        txtFIPRPRAN.SelectionStart = 0
        txtFIPRPRAN.SelectionLength = Len(txtFIPRPRAN.Text)
        strBARRESTA.Items(0).Text = txtFIPRPRAN.AccessibleDescription
    End Sub
    Private Sub txtFIPREDAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDAN.GotFocus
        txtFIPREDAN.SelectionStart = 0
        txtFIPREDAN.SelectionLength = Len(txtFIPREDAN.Text)
        strBARRESTA.Items(0).Text = txtFIPREDAN.AccessibleDescription
    End Sub
    Private Sub txtFIPRUPAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUPAN.GotFocus
        txtFIPRUPAN.SelectionStart = 0
        txtFIPRUPAN.SelectionLength = Len(txtFIPRUPAN.Text)
        strBARRESTA.Items(0).Text = txtFIPRUPAN.AccessibleDescription
    End Sub
    Private Sub cboFIPRCASU_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCASU.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRCASU.AccessibleDescription
    End Sub
    Private Sub cboFIPRCSAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCSAN.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRCSAN.AccessibleDescription
    End Sub
    Private Sub cboFIPRCASA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCASA.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRCASA.AccessibleDescription
    End Sub
    Private Sub cboFIPRCAPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCAPR.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRCAPR.AccessibleDescription
    End Sub
    Private Sub cboFIPRMOAD_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRMOAD.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRMOAD.AccessibleDescription
    End Sub
    Private Sub cboFIPRESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRESTA.GotFocus
        strBARRESTA.Items(0).Text = cboFIPRESTA.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub chkFIPRLITI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFIPRLITI.GotFocus
        strBARRESTA.Items(0).Text = chkFIPRLITI.AccessibleDescription
    End Sub
    Private Sub txtFIPRPOLI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPOLI.GotFocus
        txtFIPRPOLI.SelectionStart = 0
        txtFIPRPOLI.SelectionLength = Len(txtFIPRPOLI.Text)
        strBARRESTA.Items(0).Text = txtFIPRPOLI.AccessibleDescription
    End Sub
    Private Sub txtFIPRARTE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRARTE.GotFocus
        txtFIPRARTE.SelectionStart = 0
        txtFIPRARTE.SelectionLength = Len(txtFIPRARTE.Text)
        strBARRESTA.Items(0).Text = txtFIPRARTE.AccessibleDescription
    End Sub
    Private Sub txtFIPRCOPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCOPR.GotFocus
        txtFIPRCOPR.SelectionStart = 0
        txtFIPRCOPR.SelectionLength = Len(txtFIPRCOPR.Text)
        strBARRESTA.Items(0).Text = txtFIPRCOPR.AccessibleDescription
    End Sub
    Private Sub txtFIPRCOED_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCOED.GotFocus
        txtFIPRCOED.SelectionStart = 0
        txtFIPRCOED.SelectionLength = Len(txtFIPRCOED.Text)
        strBARRESTA.Items(0).Text = txtFIPRCOED.AccessibleDescription
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFIPRDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRDESC.Validated
        If Trim(txtFIPRDESC.Text) = "" Then
            txtFIPRDESC.Text = "."
        End If

        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub
    Private Sub txtFIPRDIRE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRDIRE.Validated
        If Trim(cboFIPRCLSE.Text) = 1 Then
            If Trim(txtFIPRDIRE.Text) = "" Then
                txtFIPRDIRE.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
            Else
                If Trim(txtFIPRDIRE.Text) = "" Then
                    txtFIPRDIRE.Text = "."
                End If

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub chkFIPRCONJ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFIPRCONJ.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.Validated
        If Trim(txtFIPRMUNI.Text) = "" Then
            txtFIPRMUNI.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRMUNI.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRMUNI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRMUNI.Text)
                Formato = Format(Mascara, "000")
                txtFIPRMUNI.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.Validated
        If Trim(txtFIPRCORR.Text) = "" Or Trim(txtFIPRCORR.Text) = "0" Then
            txtFIPRCORR.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRCORR.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRCORR.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRCORR.Text)
                Formato = Format(Mascara, "00")
                txtFIPRCORR.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.Validated
        If Trim(txtFIPRBARR.Text) = "" Then
            txtFIPRBARR.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRBARR.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRBARR.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRBARR.Text)
                Formato = Format(Mascara, "000")
                txtFIPRBARR.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.Validated
        If Trim(txtFIPRMANZ.Text) = "" Or Trim(txtFIPRMANZ.Text) = "0" Then
            txtFIPRMANZ.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRMANZ.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRMANZ.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRMANZ.Text)
                Formato = Format(Mascara, "000")
                txtFIPRMANZ.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.Validated
        If Trim(txtFIPRPRED.Text) = "" Or Trim(txtFIPRPRED.Text) = "0" Then
            txtFIPRPRED.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRPRED.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRPRED.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRPRED.Text)
                Formato = Format(Mascara, "00000")
                txtFIPRPRED.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.Validated
        If Trim(txtFIPREDIF.Text) = "" Then
            txtFIPREDIF.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPREDIF.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPREDIF.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPREDIF.Text)
                Formato = Format(Mascara, "000")
                txtFIPREDIF.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.Validated
        If Trim(txtFIPRUNPR.Text) = "" Then
            txtFIPRUNPR.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRUNPR.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRUNPR.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRUNPR.Text)
                Formato = Format(Mascara, "00000")
                txtFIPRUNPR.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRMUAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUAN.Validated
        If Trim(txtFIPRMUAN.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRMUAN.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRMUAN.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRMUAN.Text)
                Formato = Format(Mascara, "000")
                txtFIPRMUAN.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRCOAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCOAN.Validated
        If Trim(txtFIPRCOAN.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRCOAN.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRCOAN.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRCOAN.Text)
                Formato = Format(Mascara, "00")
                txtFIPRCOAN.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRBAAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBAAN.Validated
        If Trim(txtFIPRBAAN.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRBAAN.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRBAAN.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRBAAN.Text)
                Formato = Format(Mascara, "000")
                txtFIPRBAAN.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRMAAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMAAN.Validated
        If Trim(txtFIPRMAAN.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRMAAN.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRMAAN.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRMAAN.Text)
                Formato = Format(Mascara, "000")
                txtFIPRMAAN.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRPRAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRAN.Validated
        If Trim(txtFIPRPRAN.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRPRAN.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRPRAN.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRPRAN.Text)
                Formato = Format(Mascara, "00000")
                txtFIPRPRAN.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPREDAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDAN.Validated
        If Trim(txtFIPREDAN.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPREDAN.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPREDAN.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPREDAN.Text)
                Formato = Format(Mascara, "000")
                txtFIPREDAN.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRUPAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUPAN.Validated
        If Trim(txtFIPRUPAN.Text) <> "" Then
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRUPAN.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRUPAN.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Mascara = Val(txtFIPRUPAN.Text)
                Formato = Format(Mascara, "00000")
                txtFIPRUPAN.Text = Formato

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRPOLI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPOLI.Validated
        If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(txtFIPRPOLI.Text)) = False Then
            vl_boSWVerificaDatoAlGuardar = False

            txtFIPRPOLI.Focus()
            strBARRESTA.Items(1).Text = IncoValoDeci
        Else
            vl_boSWVerificaDatoAlGuardar = True

            txtFIPRPOLI.Text = fun_Formato_Decimal_2_Decimales(txtFIPRPOLI.Text)

            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboFIPRCLSE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCLSE.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboFIPRCASU_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCASU.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboFIPRCSAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCSAN.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboFIPRCASA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCASA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboFIPRCAPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCAPR.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboFIPRMOAD_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRMOAD.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""

        Try
            Dim objdatos As New cla_FIPRPROP
            Dim tbl As New DataTable
            Dim inFPPRMOAD As Integer = 0

            tbl = objdatos.fun_Consultar_FIPRPROP(vl_inFIPRNUFI)

            If tbl.Rows.Count > 0 Then
                If cboFIPRMOAD.Text = 2 Then
                    If MessageBox.Show("¿ Desea eliminar los datos juridicos ?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        '=============================================
                        '*** ACTUALIZA EL REGISTRO EN PROPIETARIOS ***
                        '=============================================

                        ' buscar cadena de conexion
                        Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' variables
                        Dim inFPPRESCR As Integer = 0
                        Dim stFPPRFEES As String = ""
                        Dim stFPPRFERE As String = ""
                        Dim stFPPRDEPA As String = ""
                        Dim stFPPRMUNI As String = ""
                        Dim stFPPRNOTA As String = ""
                        Dim inFPPRTOMO As Integer = 0
                        Dim stFPPRMAIN As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update FIPRPROP "
                        ParametrosConsulta += "set FPPRESCR = '" & inFPPRESCR & "', "
                        ParametrosConsulta += "FPPRFEES = '" & stFPPRFEES & "', "
                        ParametrosConsulta += "FPPRFERE = '" & stFPPRFERE & "', "
                        ParametrosConsulta += "FPPRDENO = '" & stFPPRDEPA & "', "
                        ParametrosConsulta += "FPPRMUNO = '" & stFPPRMUNI & "', "
                        ParametrosConsulta += "FPPRNOTA = '" & stFPPRNOTA & "', "
                        ParametrosConsulta += "FPPRTOMO = '" & inFPPRTOMO & "', "
                        ParametrosConsulta += "FPPRMAIN = '" & stFPPRMAIN & "' "
                        ParametrosConsulta += "where FPPRNUFI = '" & vl_inFIPRNUFI & "'"

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 360
                        oEjecutar.CommandType = CommandType.Text
                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cboFIPRESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRARTE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRARTE.Validated
        If Trim(txtFIPRARTE.Text) = "" Then
            txtFIPRARTE.Text = "0"
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFIPRARTE.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFIPRARTE.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFIPRCOPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCOPR.Validated
        If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(txtFIPRCOPR.Text)) = False Then
            vl_boSWVerificaDatoAlGuardar = False

            txtFIPRCOPR.Focus()
            strBARRESTA.Items(1).Text = IncoValoDeci
        Else
            vl_boSWVerificaDatoAlGuardar = True

            txtFIPRCOPR.Text = fun_Formato_Decimal_6_Decimales(txtFIPRCOPR.Text)

            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If

    End Sub
    Private Sub txtFIPRCOED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCOED.Validated
        If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(txtFIPRCOED.Text)) = False Then
            vl_boSWVerificaDatoAlGuardar = False

            txtFIPRCOED.Focus()
            strBARRESTA.Items(1).Text = IncoValoDeci
        Else
            vl_boSWVerificaDatoAlGuardar = True

            txtFIPRCOED.Text = fun_Formato_Decimal_6_Decimales(txtFIPRCOED.Text)

            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboFIPRCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFIPRCLSE.SelectedIndexChanged
        lblFIPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Val(cboFIPRCLSE.Text)), String)
    End Sub
    Private Sub cboFIPRCASU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFIPRCASU.SelectedIndexChanged
        lblFIPRCASU.Text = CType(fun_Buscar_Lista_Valores_CATESUEL(Val(cboFIPRCASU.Text)), String)
    End Sub
    Private Sub cboFIPRCSAN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFIPRCSAN.SelectedIndexChanged
        lblFIPRCSAN.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Val(cboFIPRCSAN.Text)), String)
    End Sub
    Private Sub cboFIPRCASA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFIPRCASA.SelectedIndexChanged
        lblFIPRCASA.Text = CType(fun_Buscar_Lista_Valores_CATESUEL(Val(cboFIPRCASA.Text)), String)
    End Sub
    Private Sub cboFIPRCAPR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFIPRCAPR.SelectedIndexChanged
        lblFIPRCAPR.Text = CType(fun_Buscar_Lista_Valores_CARAPRED(Val(cboFIPRCAPR.Text)), String)
    End Sub
    Private Sub cboFIPRMOAD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFIPRMOAD.SelectedIndexChanged
        lblFIPRMOAD.Text = CType(fun_Buscar_Lista_Valores_MODOADQU(Val(cboFIPRMOAD.Text)), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboFIPRCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT(cboFIPRCLSE, cboFIPRCLSE.SelectedIndex)
    End Sub
    Private Sub cboFIPRCASU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCASU.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CATESUEL(cboFIPRCASU, cboFIPRCASU.SelectedIndex)
    End Sub
    Private Sub cboFIPRCSAN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCSAN.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT(cboFIPRCSAN, cboFIPRCSAN.SelectedIndex)
    End Sub
    Private Sub cboFIPRCASA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCASA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CATESUEL(cboFIPRCASA, cboFIPRCASA.SelectedIndex)
    End Sub
    Private Sub cboFIPRCAPR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRCAPR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CARAPRED(cboFIPRCAPR, cboFIPRCAPR.SelectedIndex)
    End Sub
    Private Sub cboFIPRMOAD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFIPRMOAD.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MODOADQU(cboFIPRMOAD, cboFIPRMOAD.SelectedIndex)
    End Sub

#End Region

#Region "CheckedChanged"

    Private Sub chkFIPRLITI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFIPRLITI.CheckedChanged
        If chkFIPRLITI.Checked = True Then
            txtFIPRPOLI.Enabled = True
            txtFIPRPOLI.Focus()
        Else
            txtFIPRPOLI.Text = "0.00"
            txtFIPRPOLI.Enabled = False
        End If
    End Sub

#End Region

#Region "TextChanged"

    Private Sub tstBAESDESC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tstBAESDESC.TextChanged
        ' coloca en modo de mensaje el texto que se muestra en la barra
        'If strBARRESTA.Items(1).Text <> "" Then
        '    MessageBox.Show(strBARRESTA.Items(1).Text, "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        'End If
    End Sub

#End Region

#Region "ResizeBegin"

    Private Sub frm_insertar_FICHPRED_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        Dim opacity As Double = Convert.ToDouble(0.5)
        Me.Opacity = opacity
    End Sub

#End Region

#Region "ResizeEnd"

    Private Sub frm_insertar_FICHPRED_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim opacity As Double = Convert.ToDouble(100)
        Me.Opacity = opacity
    End Sub

#End Region

#End Region

   
End Class