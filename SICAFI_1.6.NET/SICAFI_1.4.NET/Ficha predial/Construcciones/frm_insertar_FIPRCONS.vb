Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_FIPRCONS

    '=============================
    '*** INSERTAR CONSTRUCCIÓN ***
    '=============================

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inFIPRNUFI As Integer, _
                  ByVal inFIPRNURE As Integer, _
                  ByVal stRESODEPA As String, _
                  ByVal stRESOMUNI As String, _
                  ByVal inRESOTIRE As Integer, _
                  ByVal inRESOCLSE As Integer, _
                  ByVal inRESOVIGE As Integer, _
                  ByVal inRESORESO As Integer)

        vp_FichaPredial = inFIPRNUFI
        vl_inFIPRNURE = inFIPRNURE
        vl_stRESODEPA = stRESODEPA
        vl_stRESOMUNI = stRESOMUNI
        vl_inRESOTIRE = inRESOTIRE
        vl_inRESOCLSE = inRESOCLSE
        vl_inRESOVIGE = inRESOVIGE
        vl_inRESORESO = inRESORESO

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
        pro_ReconsultarConstruccion()
        pro_NumeroDeSecuenciaDeRegistro()

    End Sub

#End Region

#Region "VARIABLES"

    '*** VARIABLES QUE RECIBE DEL FORMULARIO DE FICHA PREDIAL ***
    Dim vl_inFIPRNURE As Integer
    Dim vl_stRESODEPA As String
    Dim vl_stRESOMUNI As String
    Dim vl_inRESOTIRE As Integer
    Dim vl_inRESOCLSE As Integer
    Dim vl_inRESOVIGE As Integer
    Dim vl_inRESORESO As Integer
    Dim vl_boSWVerificaDatoAlGuardar As Boolean = True

    'SW para cargar el tipo de construccion con las teclas de arriba y abajo
    Dim inSW As Integer = 0

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Try
            '=========================================
            ' CARGA LOS COMBOBOX CON LOS DATOS ACTIVOS
            '=========================================

            Dim objdatos2 As New cla_ESTADO

            cboFPCOESTA.DataSource = objdatos2.fun_Consultar_ESTADO_X_ESTADO
            cboFPCOESTA.DisplayMember = "ESTADESC"
            cboFPCOESTA.ValueMember = "ESTACODI"

            Me.txtFPCOUNID.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try



    End Sub
    Private Sub pro_ReconsultarConstruccion()
        Try
            Dim objdatos As New cla_FIPRCONS

            BindingSource_FIPRcons_1.DataSource = objdatos.fun_Consultar_FIPRCONS(vp_FichaPredial)
            dgvFIPRCONS.DataSource = BindingSource_FIPRcons_1.DataSource
            BindingNavigator_FIPRcons_1.BindingSource = BindingSource_FIPRcons_1

            dgvFIPRCONS.Columns(0).Visible = False
            dgvFIPRCONS.Columns(1).Visible = False

            strBARRESTA.Items(2).Text = "Registros : " & BindingSource_FIPRCONS_1.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_NumeroDeSecuenciaDeRegistro()
        Dim inSECUENCIA As Integer = 0

        Dim objdatos5 As New cla_FIPRCONS
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRCONS_X_FICHA_PREDIAL(Val(vp_FichaPredial))

        If tbl10.Rows.Count = 0 Then
            inSECUENCIA = 1
        Else
            Dim i As Integer
            Dim NroMayor As Integer
            Dim Posicion As Integer

            Posicion = Val(tbl10.Rows(0).Item(25))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item(25))

                If NroMayor > Posicion Then
                    inSECUENCIA = NroMayor
                    Posicion = NroMayor
                Else
                    inSECUENCIA = Posicion
                End If
            Next

            inSECUENCIA = inSECUENCIA + 1
        End If

        lblFPCOSECU.Text = inSECUENCIA
    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtFPCOUNID.Text = ""
        Me.txtFPCOPUNT.Text = "0"
        Me.txtFPCOARCO.Text = ""
        Me.txtFPCOPISO.Text = ""
        Me.txtFPCOEDCO.Text = ""
        Me.txtFPCOPOCO.Text = ""
        Me.chkFPCOMEJO.Checked = False
        Me.chkFPCOLEY.Checked = False
        Me.txtFPCOAVCO.Text = "0"
        Me.txtFPCOFECH.Text = ""
        Me.rbdFPCORESI.Checked = False
        Me.rbdFPCOCOME.Checked = False
        Me.rbdFPCOINDU.Checked = False
        Me.rbdFPCOOTRA.Checked = False
        Me.chkFPCOARCO.Checked = False

        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtFPCOUNID, "")

        Dim tbl As New DataTable

        Me.cboFPCOCLCO.DataSource = tbl
        Me.cboFPCOTICO.DataSource = tbl

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            If fun_Verificar_Campos_Llenos_14_DATOS(Me.txtFPCOUNID.Text, _
                                                    Me.cboFPCOCLCO.Text, _
                                                    Me.cboFPCOTICO.Text, _
                                                    Me.txtFPCOPUNT.Text, _
                                                    Me.txtFPCOARCO.Text, _
                                                    Me.cboFPCOACUE.Text, _
                                                    Me.cboFPCOALCA.Text, _
                                                    Me.cboFPCOENER.Text, _
                                                    Me.cboFPCOTELE.Text, _
                                                    Me.cboFPCOGAS.Text, _
                                                    Me.txtFPCOPISO.Text, _
                                                    Me.txtFPCOEDCO.Text, _
                                                    Me.txtFPCOPOCO.Text, _
                                                    Me.cboFPCOESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtFPCOUNID.Focus()
            Else
                Dim objdatos1 As New cla_FIPRCONS
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_FIPRCONS(vp_FichaPredial, Val(txtFPCOUNID.Text))

                If tbl.Rows.Count > 0 Then
                    mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                    txtFPCOUNID.Focus()
                Else
                    Dim objdatos As New cla_FIPRCONS
                    Dim inSECUENCIA As Integer = 0

                    Dim objdatos5 As New cla_FIPRCONS
                    Dim tbl10 As New DataTable

                    tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRCONS_X_FICHA_PREDIAL(Val(vp_FichaPredial))

                    If tbl10.Rows.Count = 0 Then
                        inSECUENCIA = 1
                    Else
                        Dim i As Integer
                        Dim NroMayor As Integer
                        Dim Posicion As Integer

                        Posicion = Val(tbl10.Rows(0).Item(25))

                        For i = 0 To tbl10.Rows.Count - 1
                            NroMayor = Val(tbl10.Rows(i).Item(25))

                            If NroMayor > Posicion Then
                                inSECUENCIA = NroMayor
                                Posicion = NroMayor
                            Else
                                inSECUENCIA = Posicion
                            End If
                        Next
                        inSECUENCIA = inSECUENCIA + 1
                    End If

                    lblFPCOSECU.Text = inSECUENCIA

                    If (objdatos.fun_Insertar_FIPRCONS(vp_FichaPredial, txtFPCOUNID.Text, cboFPCOCLCO.Text, cboFPCOTICO.Text, txtFPCOPUNT.Text, txtFPCOARCO.Text, cboFPCOACUE.Text, cboFPCOALCA.Text, cboFPCOENER.Text, cboFPCOTELE.Text, cboFPCOGAS.Text, txtFPCOPISO.Text, txtFPCOEDCO.Text, txtFPCOPOCO.Text, chkFPCOMEJO.Checked, chkFPCOLEY.Checked, txtFPCOAVCO.Text, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inSECUENCIA, vl_inFIPRNURE, cboFPCOESTA.SelectedValue)) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar una construcción ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            txtFPCOUNID.Focus()
                            Me.Close()
                        End If

                        pro_NumeroDeSecuenciaDeRegistro()
                        pro_ReconsultarConstruccion()
                        pro_LimpiarCampos()
                        txtFPCOUNID.Focus()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
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

#Region "Load"

    Private Sub frm_insertar_FIPRCONS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboFPCOACUE.SelectedIndex = 0
        cboFPCOALCA.SelectedIndex = 0
        cboFPCOENER.SelectedIndex = 0
        cboFPCOTELE.SelectedIndex = 0
        cboFPCOGAS.SelectedIndex = 0

        strBARRESTA.Items(0).Text = "Construcción"

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
        If Trim(Me.cboFPCOCLCO.Text) <> "" Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCONS_X_CLASCONS(cboFPCOTICO, vl_stRESODEPA, vl_stRESOMUNI, cboFPCOCLCO.Text, vl_inRESOCLSE)
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFPCOUNID_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCOUNID.Validated
        Try
            If Trim(txtFPCOUNID.Text) = "" Then
                txtFPCOUNID.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
                ErrorProvider1.SetError(Me.txtFPCOUNID, "")
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

                        If tbl.Rows.Count > 0 Then
                            vl_boSWVerificaDatoAlGuardar = False

                            txtFPCOUNID.Focus()
                            ErrorProvider1.SetError(Me.txtFPCOUNID, "Unidad de construcción existente en base de datos")
                            strBARRESTA.Items(1).Text = "Unidad de construcción existente en base de datos"
                        Else
                            ErrorProvider1.SetError(Me.txtFPCOUNID, "")

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
        If Trim(cboFPCOCLCO.Text) = "" Then
            cboFPCOCLCO.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboFPCOTICO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCOTICO.Validated
        Try
            If Trim(cboFPCOTICO.Text) <> "" Then
                If Trim(cboFPCOCLCO.Text) <> "" Then

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
                        'Puntos predeterminados
                        txtFPCOPUNT.Text = tbl15.Rows(0).Item(7)

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