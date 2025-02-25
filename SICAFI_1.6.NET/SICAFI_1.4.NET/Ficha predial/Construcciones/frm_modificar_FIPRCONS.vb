Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_modificar_FIPRCONS

    '==============================
    '*** MODIFICAR CONSTRUCCIÓN ***
    '==============================

#Region "CONSTRUCTORES"

    Public Sub New(ByVal inFPCOIDRE As Integer, _
                   ByVal inFIPRNUFI As Integer, _
                   ByVal inFIPRNURE As Integer, _
                   ByVal idRESODEPA As String, _
                   ByVal idRESOMUNI As String, _
                   ByVal idRESOTIRE As Integer, _
                   ByVal idRESOCLSE As Integer, _
                   ByVal idRESOVIGE As Integer, _
                   ByVal idRESORESO As Integer)

        vl_inFPCOIDRE = inFPCOIDRE
        vp_FichaPredial = inFIPRNUFI
        vl_inFIPRNURE = inFIPRNURE
        vl_stRESODEPA = idRESODEPA
        vl_stRESOMUNI = idRESOMUNI
        vl_inRESOTIRE = idRESOTIRE
        vl_inRESOCLSE = idRESOCLSE
        vl_inRESOVIGE = idRESOVIGE
        vl_inRESORESO = idRESORESO

        InitializeComponent()
        pro_inicializarControles()

    End Sub

#End Region

#Region "VARIABLES LOCALES"

    '*** VARIABLES QUE RECIBE DEL FORMULARIO DE FICHA PREDIAL ***
    Dim vl_inFIPRNURE As Integer
    Dim vl_stRESODEPA As String
    Dim vl_stRESOMUNI As String
    Dim vl_inRESOTIRE As Integer
    Dim vl_inRESOCLSE As Integer
    Dim vl_inRESOVIGE As Integer
    Dim vl_inRESORESO As Integer
    Dim vl_stFPCOUNID As Integer
    Dim vl_inFPCOIDRE As Integer
    Dim vl_boSWVerificaDatoAlGuardar As Boolean = True

    'SW para cargar el tipo de construccion con las teclas de arriba y abajo
    Dim inSW As Integer = 0

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        '=================================
        ' CARGA LOS COMBOBOX CON LOS DATOS 
        '=================================

        fun_Cargar_ComboBox_Con_Todos_Los_Datos_CLASCONS(cboFPCOCLCO, cboFPCOCLCO.SelectedValue)
        fun_Cargar_ComboBox_Con_Todos_Los_Datos_TIPOCONS(cboFPCOTICO, cboFPCOTICO.SelectedValue)
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboFPCOESTA, cboFPCOESTA.SelectedValue)

        '==================================
        ' LLENA LOS CAMPOS DE ACUERDO AL ID
        '==================================
        Dim objdatos10 As New cla_FIPRCONS
        Dim tbl10 As New DataTable

        tbl10 = objdatos10.fun_Buscar_ID_FIPRCONS(vl_inFPCOIDRE)

        'lblFPCOIDRE.Text = Trim(tbl10.Rows(0).Item(0))
        'txtFPPRNUFI.Text = Trim(tbl10.Rows(0).Item(1))
        txtFPCOUNID.Text = Trim(tbl10.Rows(0).Item(2))
        cboFPCOCLCO.SelectedValue = Trim(tbl10.Rows(0).Item(3))
        cboFPCOTICO.SelectedValue = Trim(tbl10.Rows(0).Item(4))
        txtFPCOPUNT.Text = Trim(tbl10.Rows(0).Item(5))
        txtFPCOARCO.Text = Trim(tbl10.Rows(0).Item(6))
        cboFPCOACUE.Text = Trim(tbl10.Rows(0).Item(7))
        cboFPCOALCA.Text = Trim(tbl10.Rows(0).Item(8))
        cboFPCOENER.Text = Trim(tbl10.Rows(0).Item(9))
        cboFPCOTELE.Text = Trim(tbl10.Rows(0).Item(10))
        cboFPCOGAS.Text = Trim(tbl10.Rows(0).Item(11))
        txtFPCOPISO.Text = Trim(tbl10.Rows(0).Item(12))
        txtFPCOEDCO.Text = Trim(tbl10.Rows(0).Item(13))
        txtFPCOPOCO.Text = Trim(tbl10.Rows(0).Item(14))
        chkFPCOMEJO.Checked = tbl10.Rows(0).Item(15)
        chkFPCOLEY.Checked = tbl10.Rows(0).Item(16)
        txtFPCOAVCO.Text = Trim(tbl10.Rows(0).Item(17))
        txtFPCOFECH.Text = Trim(tbl10.Rows(0).Item(18))
        'txtFPCODEPA.Text = Trim(tbl10.Rows(0).Item(19))
        'txtFPCOMUNI.Text = Trim(tbl10.Rows(0).Item(20))
        'txtFPCOTIRE.Text = Trim(tbl10.Rows(0).Item(21))
        'txtFPCOCLSE.Text = Trim(tbl10.Rows(0).Item(22))
        'txtFPCOVIGE.Text = Trim(tbl10.Rows(0).Item(23))
        'txtFPCORESO.Text = Trim(tbl10.Rows(0).Item(24))
        'lblFPCOSECU.Text = Trim(tbl10.Rows(0).Item(25))
        'txtFPCONURE.Text = Trim(tbl10.Rows(0).Item(26))
        cboFPCOESTA.SelectedValue = Trim(tbl10.Rows(0).Item(27))
        'txtFPCOUSIN.Text = Trim(tbl10.Rows(0).Item(28))
        'txtFPCOUSMO.Text = Trim(tbl10.Rows(0).Item(29))
        'txtFPCOFEIN.Text = Trim(tbl10.Rows(0).Item(30))
        'txtFPCOFEMO.Text = Trim(tbl10.Rows(0).Item(31))
        'txtFPCOMAQU.Text = Trim(tbl10.Rows(0).Item(32))

        '=============================================
        'CARGA LA DESCRIPCIÓN DEL TIPO DE CONSTRUCCION
        '=============================================

        Dim objdatos15 As New cla_TIPOCONS
        Dim tbl15 As New DataTable

        tbl15 = objdatos15.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(Trim(vl_stRESODEPA), Trim(vl_stRESOMUNI), Trim(cboFPCOCLCO.Text), Trim(vl_inRESOCLSE), Trim(cboFPCOTICO.Text))

        If tbl15.Rows.Count > 0 Then

            Dim stFPCOTIPO As String = Trim(tbl15.Rows(0).Item(4))

            If stFPCOTIPO = "R" Then
                rbdFPCORESI.Checked = True
            ElseIf stFPCOTIPO = "C" Then
                rbdFPCOCOME.Checked = True
            ElseIf stFPCOTIPO = "I" Then
                rbdFPCOINDU.Checked = True
            ElseIf stFPCOTIPO = "O" Then
                rbdFPCOOTRA.Checked = True
            Else
                rbdFPCORESI.Checked = False
                rbdFPCOCOME.Checked = False
                rbdFPCOINDU.Checked = False
                rbdFPCOOTRA.Checked = False
            End If

            chkFPCOARCO.Checked = CType(fun_Buscar_Lista_Valores_BOOLEAN(tbl15.Rows(0).Item(12)), Boolean)

        End If

        '=====================================
        'CARGA LA DESCRIPCIÓN DE LOS GENERALES
        '=====================================

        If Trim(cboFPCOACUE.Text) = "1" Then
            lblFPCOACUE.Text = "Con Servicio"
        Else
            lblFPCOACUE.Text = "Sin Servicio"
        End If

        If Trim(cboFPCOALCA.Text) = "1" Then
            lblFPCOALCA.Text = "Con Servicio"
        Else
            lblFPCOALCA.Text = "Sin Servicio"
        End If

        If Trim(cboFPCOENER.Text) = "1" Then
            lblFPCOENER.Text = "Con Servicio"
        Else
            lblFPCOENER.Text = "Sin Servicio"
        End If

        If Trim(cboFPCOTELE.Text) = "1" Then
            lblFPCOTELE.Text = "Con Servicio"
        Else
            lblFPCOTELE.Text = "Sin Servicio"
        End If

        If Trim(cboFPCOGAS.Text) = "1" Then
            lblFPCOGAS.Text = "Con Servicio"
        Else
            lblFPCOGAS.Text = "Sin Servicio"
        End If

        ' Almacena el numero de documento para verificar si existe al momento de guardar
        vl_stFPCOUNID = Trim(tbl10.Rows(0).Item(2))

        '==========================================================
        ' CARGA LA DESCRIPCIÓN (Los reg. activos ya estan cargados)
        '==========================================================
        Try
            Dim boFPCOCLCO As Boolean = fun_Buscar_Dato_CLASCONS(cboFPCOCLCO.Text)
            'Dim boFPCOTICO As Boolean = fun_Buscar_Dato_TIPOCONS(Trim(vl_stRESODEPA), Trim(vl_stRESOMUNI), Trim(cboFPCOCLCO.Text), Trim(vl_inRESOCLSE), Trim(cboFPCOTICO.Text))

            'If boFPCOCLCO = True AndAlso boFPCOTICO = True Then
            If boFPCOCLCO = True Then
                lblFPCOCLCO.Text = CType(fun_Buscar_Lista_Valores_CLASCONS(cboFPCOCLCO.Text), String)
                lblFPCOTICO.Text = CType(fun_Buscar_Lista_Valores_TIPOCONS(Trim(vl_stRESODEPA), Trim(vl_stRESOMUNI), Trim(cboFPCOCLCO.Text), Trim(vl_inRESOCLSE), Trim(cboFPCOTICO.Text)), String)
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        txtFPCOUNID.Focus()
    End Sub
    Private Sub pro_LimpiarCampos()

        txtFPCOUNID.Text = ""
        txtFPCOPUNT.Text = ""
        txtFPCOARCO.Text = ""
        txtFPCOPISO.Text = ""
        txtFPCOEDCO.Text = ""
        txtFPCOPOCO.Text = ""
        chkFPCOMEJO.Checked = False
        chkFPCOLEY.Checked = False
        rbdFPCORESI.Checked = False
        rbdFPCOCOME.Checked = False
        rbdFPCOINDU.Checked = False
        rbdFPCOOTRA.Checked = False
        chkFPCOARCO.Checked = False
        lblFPCOCLCO.Text = ""
        lblFPCOTICO.Text = ""
        lblFPCOACUE.Text = ""
        lblFPCOALCA.Text = ""
        lblFPCOENER.Text = ""
        lblFPCOTELE.Text = ""
        lblFPCOGAS.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_14_DATOS(txtFPCOUNID.Text, _
                                                    cboFPCOCLCO.Text, _
                                                    cboFPCOTICO.Text, _
                                                    txtFPCOPUNT.Text, _
                                                    txtFPCOARCO.Text, _
                                                    cboFPCOACUE.Text, _
                                                    cboFPCOALCA.Text, _
                                                    cboFPCOENER.Text, _
                                                    cboFPCOTELE.Text, _
                                                    cboFPCOGAS.Text, _
                                                    txtFPCOPISO.Text, _
                                                    txtFPCOEDCO.Text, _
                                                    txtFPCOPOCO.Text, _
                                                    cboFPCOESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtFPCOUNID.Focus()
            Else
                ' verifica que los datos esten correctos numericos o decimales
                If vl_boSWVerificaDatoAlGuardar = False Then
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    '=====================================================================
                    ' ESTRAE LA INFORMACIÓN DEL REGISTRO A MODIFICAR O ELIMINAR ANTES DE..
                    '=====================================================================

                    Dim objdatos As New cla_FIPRCONS
                    Dim tbl As New DataTable

                    tbl = objdatos.fun_Buscar_ID_FIPRCONS(vl_inFPCOIDRE)

                    Dim inFPCOSECU As Integer = Val(Trim(tbl.Rows(0).Item(25)))
                    Dim inFPCONURE As Integer = Val(Trim(tbl.Rows(0).Item(26)))
                    Dim stFPCOUSIN As String = Trim(tbl.Rows(0).Item(28))
                    Dim daFPCOFEIN As Date = tbl.Rows(0).Item(30)

                    If vl_stFPCOUNID = Trim(txtFPCOUNID.Text) Then

                        '=================================================
                        ' ACTUALIZA LA INFORMACION DEL REGISTRO MODIFICADO
                        '=================================================

                        If (objdatos.fun_Actualizar_FIPRCONS(vl_inFPCOIDRE, _
                                                             vp_FichaPredial, _
                                                             txtFPCOUNID.Text, _
                                                             cboFPCOCLCO.Text, _
                                                             cboFPCOTICO.Text, _
                                                             txtFPCOPUNT.Text, _
                                                             txtFPCOARCO.Text, _
                                                             cboFPCOACUE.Text, _
                                                             cboFPCOALCA.Text, _
                                                             cboFPCOENER.Text, _
                                                             cboFPCOTELE.Text, _
                                                             cboFPCOGAS.Text, _
                                                             txtFPCOPISO.Text, _
                                                             txtFPCOEDCO.Text, _
                                                             txtFPCOPOCO.Text, _
                                                             chkFPCOMEJO.Checked, _
                                                             chkFPCOLEY.Checked, _
                                                             txtFPCOAVCO.Text, _
                                                             vl_stRESODEPA, _
                                                             vl_stRESOMUNI, _
                                                             vl_inRESOTIRE, _
                                                             vl_inRESOCLSE, _
                                                             vl_inRESOVIGE, _
                                                             vl_inRESORESO, _
                                                             inFPCOSECU, _
                                                             inFPCONURE, _
                                                             cboFPCOESTA.SelectedValue, _
                                                             txtFPCOFECH.Text, _
                                                             stFPCOUSIN, _
                                                             daFPCOFEIN)) Then
                            mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                            txtFPCOUNID.Focus()
                            Me.Close()
                        Else
                            mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                            txtFPCOUNID.Focus()
                        End If

                    Else

                        Dim objdatos12 As New cla_FIPRCONS
                        Dim tbl12 As New DataTable

                        tbl12 = objdatos12.fun_Buscar_CODIGO_FIPRCONS(vp_FichaPredial, Trim(txtFPCOUNID.Text))

                        If tbl12.Rows.Count > 0 Then
                            mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                            txtFPCOUNID.Focus()
                        Else
                            '=================================================
                            ' ACTUALIZA LA INFORMACION DEL REGISTRO MODIFICADO
                            '=================================================

                            If (objdatos.fun_Actualizar_FIPRCONS(vl_inFPCOIDRE, _
                                                                 vp_FichaPredial, _
                                                                 txtFPCOUNID.Text, _
                                                                 cboFPCOCLCO.Text, _
                                                                 cboFPCOTICO.Text, _
                                                                 txtFPCOPUNT.Text, _
                                                                 txtFPCOARCO.Text, _
                                                                 cboFPCOACUE.Text, _
                                                                 cboFPCOALCA.Text, _
                                                                 cboFPCOENER.Text, _
                                                                 cboFPCOTELE.Text, _
                                                                 cboFPCOGAS.Text, _
                                                                 txtFPCOPISO.Text, _
                                                                 txtFPCOEDCO.Text, _
                                                                 txtFPCOPOCO.Text, _
                                                                 chkFPCOMEJO.Checked, _
                                                                 chkFPCOLEY.Checked, _
                                                                 txtFPCOAVCO.Text, _
                                                                 vl_stRESODEPA, _
                                                                 vl_stRESOMUNI, _
                                                                 vl_inRESOTIRE, _
                                                                 vl_inRESOCLSE, _
                                                                 vl_inRESOVIGE, _
                                                                 vl_inRESORESO, _
                                                                 inFPCOSECU, _
                                                                 inFPCONURE, _
                                                                 cboFPCOESTA.SelectedValue, _
                                                                 txtFPCOFECH.Text, _
                                                                 stFPCOUSIN, _
                                                                 daFPCOFEIN)) Then
                                mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                                txtFPCOUNID.Focus()
                                Me.Close()
                            Else
                                mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                                txtFPCOUNID.Focus()
                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtFPCOUNID.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txtFPCOUNID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOUNID.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFPCOCLCO.Focus()
        End If
    End Sub
    Private Sub cboFPCOCLCO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPCOCLCO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFPCOTICO.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASCONS(cboFPCOCLCO, cboFPCOCLCO.SelectedIndex)
        End If
    End Sub
    Private Sub cboFPCOTICO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPCOTICO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPCOPUNT.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCONS_X_CLASCONS(cboFPCOTICO, vl_stRESODEPA, vl_stRESOMUNI, cboFPCOCLCO.Text, vl_inRESOCLSE)
        End If
    End Sub
    Private Sub txtFPCOPUNT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOPUNT.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPCOARCO.Focus()
        End If
    End Sub
    Private Sub txtFPCOARCO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOARCO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFPCOACUE.Focus()
        End If
    End Sub
    Private Sub cboFPCOACUE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPCOACUE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFPCOALCA.Focus()
        End If
    End Sub
    Private Sub cboFPCOALCA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPCOALCA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFPCOENER.Focus()
        End If
    End Sub
    Private Sub cboFPCOENER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPCOENER.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFPCOTELE.Focus()
        End If
    End Sub
    Private Sub cboFPCOTELE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPCOTELE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFPCOGAS.Focus()
        End If
    End Sub
    Private Sub cboFPCOGAS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPCOGAS.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPCOPISO.Focus()
        End If
    End Sub
    Private Sub txtFPCOPISO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOPISO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPCOEDCO.Focus()
        End If
    End Sub
    Private Sub txtFPCOEDCO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOEDCO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPCOPOCO.Focus()
        End If
    End Sub
    Private Sub txtFPCOPOCO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCOPOCO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            chkFPCOMEJO.Focus()
        End If
    End Sub
    Private Sub chkFPCOMEJO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkFPCOMEJO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            chkFPCOLEY.Focus()
        End If
    End Sub
    Private Sub chkFPCOLEY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkFPCOLEY.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFPCOESTA.Focus()
        End If
    End Sub
    Private Sub cboFPCOESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPCOESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtFPCOUNID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOUNID.GotFocus
        txtFPCOUNID.SelectionStart = 0
        txtFPCOUNID.SelectionLength = Len(txtFPCOUNID.Text)
        strBARRESTA.Items(0).Text = txtFPCOUNID.AccessibleDescription
    End Sub
    Private Sub cboFPCOCLCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOCLCO.GotFocus
        strBARRESTA.Items(0).Text = cboFPCOCLCO.AccessibleDescription
    End Sub
    Private Sub cboFPCOTICO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOTICO.GotFocus
        strBARRESTA.Items(0).Text = cboFPCOTICO.AccessibleDescription
    End Sub
    Private Sub txtFPCOPUNT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOPUNT.GotFocus
        txtFPCOPUNT.SelectionStart = 0
        txtFPCOPUNT.SelectionLength = Len(txtFPCOPUNT.Text)
        strBARRESTA.Items(0).Text = txtFPCOPUNT.AccessibleDescription
    End Sub
    Private Sub txtFPCOARCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOARCO.GotFocus
        txtFPCOARCO.SelectionStart = 0
        txtFPCOARCO.SelectionLength = Len(txtFPCOARCO.Text)
        strBARRESTA.Items(0).Text = txtFPCOARCO.AccessibleDescription
    End Sub
    Private Sub cboFPCOACUE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOACUE.GotFocus
        strBARRESTA.Items(0).Text = cboFPCOACUE.AccessibleDescription
    End Sub
    Private Sub cboFPCOALCA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOALCA.GotFocus
        strBARRESTA.Items(0).Text = cboFPCOALCA.AccessibleDescription
    End Sub
    Private Sub cboFPCOENER_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOENER.GotFocus
        strBARRESTA.Items(0).Text = cboFPCOENER.AccessibleDescription
    End Sub
    Private Sub cboFPCOTELE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOTELE.GotFocus
        strBARRESTA.Items(0).Text = cboFPCOTELE.AccessibleDescription
    End Sub
    Private Sub cboFPCOGAS_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOGAS.GotFocus
        strBARRESTA.Items(0).Text = cboFPCOGAS.AccessibleDescription
    End Sub
    Private Sub txtFPCOPISO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOPISO.GotFocus
        txtFPCOPISO.SelectionStart = 0
        txtFPCOPISO.SelectionLength = Len(txtFPCOPISO.Text)
        strBARRESTA.Items(0).Text = txtFPCOPISO.AccessibleDescription
    End Sub
    Private Sub txtFPCOEDCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOEDCO.GotFocus
        txtFPCOEDCO.SelectionStart = 0
        txtFPCOEDCO.SelectionLength = Len(txtFPCOEDCO.Text)
        strBARRESTA.Items(0).Text = txtFPCOEDCO.AccessibleDescription
    End Sub
    Private Sub txtFPCOPOCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOPOCO.GotFocus
        txtFPCOPOCO.SelectionStart = 0
        txtFPCOPOCO.SelectionLength = Len(txtFPCOPOCO.Text)
        strBARRESTA.Items(0).Text = txtFPCOPOCO.AccessibleDescription
    End Sub
    Private Sub chkFPCOMEJO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFPCOMEJO.GotFocus
        strBARRESTA.Items(0).Text = chkFPCOMEJO.AccessibleDescription
    End Sub
    Private Sub chkFPCOLEY_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFPCOLEY.GotFocus
        strBARRESTA.Items(0).Text = chkFPCOLEY.AccessibleDescription
    End Sub
    Private Sub cboFPCOESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOESTA.GotFocus
        strBARRESTA.Items(0).Text = cboFPCOESTA.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboFPCOCLCO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFPCOCLCO.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_CLASCONS()
        End If
    End Sub
    Private Sub cboFPCOTICO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFPCOTICO.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_TIPOCONS()
            inSW = 0
        End If

        If inSW = 0 Then
            If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCONS_X_CLASCONS(cboFPCOTICO, vl_stRESODEPA, vl_stRESOMUNI, cboFPCOCLCO.Text, vl_inRESOCLSE)
                inSW = 1
            End If
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboFPCOCLCO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOCLCO.SelectedIndexChanged
        lblFPCOCLCO.Text = CType(fun_Buscar_Lista_Valores_CLASCONS(cboFPCOCLCO.Text), String)

        'Call cboFPCOTICO_Click(cboFPCOTICO, New System.EventArgs)
        'Call cboFPCOTICO_SelectedIndexChanged(cboFPCOTICO, New System.EventArgs)

    End Sub
    Private Sub cboFPCOTICO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOTICO.SelectedIndexChanged
        lblFPCOTICO.Text = CType(fun_Buscar_Lista_Valores_TIPOCONS(vl_stRESODEPA, vl_stRESOMUNI, cboFPCOCLCO.Text, vl_inRESOCLSE, Trim(cboFPCOTICO.Text)), String)
    End Sub
    Private Sub cboFPCOACUE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFPCOACUE.SelectedIndexChanged
        Dim seleccion As String

        seleccion = cboFPCOACUE.SelectedIndex

        Select Case seleccion
            Case 0
                lblFPCOACUE.Text = "Con servicio"
            Case 1
                lblFPCOACUE.Text = "Sin servicio"
        End Select
    End Sub
    Private Sub cboFPCOALCA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFPCOALCA.SelectedIndexChanged
        Dim seleccion As String

        seleccion = cboFPCOALCA.SelectedIndex

        Select Case seleccion
            Case 0
                lblFPCOALCA.Text = "Con servicio"
            Case 1
                lblFPCOALCA.Text = "Sin servicio"
        End Select
    End Sub
    Private Sub cboFPCOENER_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFPCOENER.SelectedIndexChanged
        Dim seleccion As String

        seleccion = cboFPCOENER.SelectedIndex

        Select Case seleccion
            Case 0
                lblFPCOENER.Text = "Con servicio"
            Case 1
                lblFPCOENER.Text = "Sin servicio"
        End Select
    End Sub
    Private Sub cboFPCOTELE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFPCOTELE.SelectedIndexChanged
        Dim seleccion As String

        seleccion = cboFPCOTELE.SelectedIndex

        Select Case seleccion
            Case 0
                lblFPCOTELE.Text = "Con servicio"
            Case 1
                lblFPCOTELE.Text = "Sin servicio"
        End Select
    End Sub
    Private Sub cboFPCOGAS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFPCOGAS.SelectedIndexChanged
        Dim seleccion As String

        seleccion = cboFPCOGAS.SelectedIndex

        Select Case seleccion
            Case 0
                lblFPCOGAS.Text = "Con servicio"
            Case 1
                lblFPCOGAS.Text = "Sin servicio"
        End Select
    End Sub

#End Region

#Region "Click"

    Private Sub cboFPCOCLCO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOCLCO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASCONS(cboFPCOCLCO, cboFPCOCLCO.SelectedIndex)
    End Sub
    Private Sub cboFPCOTICO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOTICO.Click
        Dim stTIPO As String = ""

        If rbdFPCORESI.Checked = True Then
            stTIPO = "R"
        End If
        If rbdFPCOCOME.Checked = True Then
            stTIPO = "C"
        End If
        If rbdFPCOINDU.Checked = True Then
            stTIPO = "I"
        End If
        If rbdFPCOOTRA.Checked = True Then
            stTIPO = "O"
        End If


        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCONS_X_CLASCONS_X_TIPOCONS(cboFPCOTICO, vl_stRESODEPA, vl_stRESOMUNI, cboFPCOCLCO.Text, vl_inRESOCLSE, stTIPO)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFPCOUNID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOUNID.Validated
        Try
            If Trim(txtFPCOUNID.Text) = "" Then
                txtFPCOUNID.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                If Trim(txtFPCOUNID.Text) = "0" Then
                    txtFPCOUNID.Focus()
                    strBARRESTA.Items(1).Text = "Ingrese un numero mayor que cero"
                Else
                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFPCOUNID.Text)) = False Then
                        vl_boSWVerificaDatoAlGuardar = False

                        txtFPCOUNID.Focus()
                        strBARRESTA.Items(1).Text = IncoValoNume
                    Else

                        Dim objdatos As New cla_FIPRCONS
                        Dim tbl As New DataTable

                        tbl = objdatos.fun_Buscar_CODIGO_FIPRCONS(vp_FichaPredial, Val(txtFPCOUNID.Text))

                        If tbl.Rows.Count > 0 And vl_stFPCOUNID <> Trim(txtFPCOUNID.Text) Then
                            vl_boSWVerificaDatoAlGuardar = False

                            txtFPCOUNID.Focus()
                            strBARRESTA.Items(1).Text = "Unidad de construcción existente en base de datos"
                        Else
                            vl_boSWVerificaDatoAlGuardar = True

                            strBARRESTA.Items(0).Text = ""
                            strBARRESTA.Items(1).Text = ""
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cboFPCOCLCO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOCLCO.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboFPCOTICO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOTICO.Validated
        Try
            If Trim(cboFPCOTICO.Text) = "" Then
                cboFPCOTICO.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""

                '=============================================
                'CARGA LA DESCRIPCIÓN DEL TIPO DE CONSTRUCCION
                '=============================================

                Dim objdatos15 As New cla_TIPOCONS
                Dim tbl15 As New DataTable

                tbl15 = objdatos15.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(Trim(vl_stRESODEPA), Trim(vl_stRESOMUNI), Trim(cboFPCOCLCO.Text), Trim(vl_inRESOCLSE), Trim(cboFPCOTICO.Text))

                If tbl15.Rows.Count > 0 Then

                    Dim stFPCOTIPO As String = Trim(tbl15.Rows(0).Item(4))

                    If stFPCOTIPO = "R" Then
                        rbdFPCORESI.Checked = True
                    ElseIf stFPCOTIPO = "C" Then
                        rbdFPCOCOME.Checked = True
                    ElseIf stFPCOTIPO = "I" Then
                        rbdFPCOINDU.Checked = True
                    ElseIf stFPCOTIPO = "O" Then
                        rbdFPCOOTRA.Checked = True
                    Else
                        rbdFPCORESI.Checked = False
                        rbdFPCOCOME.Checked = False
                        rbdFPCOINDU.Checked = False
                        rbdFPCOOTRA.Checked = False
                    End If

                    'Area comercial
                    chkFPCOARCO.Checked = CType(fun_Buscar_Lista_Valores_BOOLEAN(tbl15.Rows(0).Item(12)), Boolean)

                    If Val(txtFPCOPUNT.Text) = 0 Then
                        'Puntos predeterminados
                        txtFPCOPUNT.Text = tbl15.Rows(0).Item(7)
                    Else
                        If Val(cboFPCOCLCO.Text) = 2 Then
                            If tbl15.Rows(0).Item(7) <> 0 Then
                                txtFPCOPUNT.Text = tbl15.Rows(0).Item(7)
                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub txtFPCOARCO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOARCO.Validated
        If Trim(txtFPCOARCO.Text) = "" Then
            txtFPCOARCO.Focus()
            strBARRESTA.Items(1).Text = IncoValoNume
        Else
            If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(txtFPCOARCO.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFPCOARCO.Focus()
                strBARRESTA.Items(1).Text = IncoValoDeci
            Else
                vl_boSWVerificaDatoAlGuardar = True

                txtFPCOARCO.Text = fun_Formato_Decimal_2_Decimales(txtFPCOARCO.Text)

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If

    End Sub
    Private Sub cboFPCOACUE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOACUE.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboFPCOALCA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOALCA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboFPCOENER_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOENER.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboFPCOTELE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOTELE.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cboFPCOGAS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOGAS.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFPCOPISO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOPISO.Validated
        If Trim(txtFPCOPISO.Text) = "" Or txtFPCOPISO.Text = "0" Then
            txtFPCOPISO.Focus()
            strBARRESTA.Items(1).Text = IncoValoNume
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFPCOPISO.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFPCOPISO.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFPCOEDCO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOEDCO.Validated
        If Trim(txtFPCOEDCO.Text) = "" Or txtFPCOEDCO.Text = "0" Then
            txtFPCOEDCO.Focus()
            strBARRESTA.Items(1).Text = IncoValoNume
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFPCOEDCO.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFPCOEDCO.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If

    End Sub
    Private Sub txtFPCOPOCO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOPOCO.Validated
        If Trim(txtFPCOPOCO.Text) = "" Or txtFPCOPOCO.Text = "0" Then
            txtFPCOPOCO.Focus()
            strBARRESTA.Items(1).Text = IncoValoNume
        Else
            If txtFPCOPOCO.Text > 100 Then
                txtFPCOPOCO.Focus()
                strBARRESTA.Items(1).Text = "Ingrese un valor no superior 100"
            Else
                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFPCOPOCO.Text)) = False Then
                    vl_boSWVerificaDatoAlGuardar = False

                    txtFPCOPOCO.Focus()
                    strBARRESTA.Items(1).Text = IncoValoNume
                Else
                    vl_boSWVerificaDatoAlGuardar = True

                    strBARRESTA.Items(0).Text = ""
                    strBARRESTA.Items(1).Text = ""
                End If
            End If
        End If
    End Sub
    Private Sub cboFPCOESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cmdGUARDAR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cmdCANCELAR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "ResizeBegin"

    Private Sub frm_insertar_FICHPRED_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        Me.Opacity = vp_Opacity
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