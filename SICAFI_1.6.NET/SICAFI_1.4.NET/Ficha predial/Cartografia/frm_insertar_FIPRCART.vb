Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_FIPRCART

    '=======================================
    '*** FORMULARIO INSERTAR CARTOGRAFIA ***
    '=======================================

#Region "CONSTRUCTORES"

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
        pro_NumeroDeSecuenciaDeRegistro()
        pro_ReconsultarLinderos()

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

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        '=========================================
        ' CARGA LOS COMBOBOX CON LOS DATOS ACTIVOS
        '=========================================
        Try

            Dim objdatos4 As New cla_ESTADO

            cboFPCAESTA.DataSource = objdatos4.fun_Consultar_ESTADO_X_ESTADO
            cboFPCAESTA.DisplayMember = "ESTADESC"
            cboFPCAESTA.ValueMember = "ESTACODI"

            Me.txtFPCAPLAN.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try



    End Sub
    Private Sub pro_ReconsultarLinderos()
        Try
            Dim objdatos As New cla_FIPRCART

            BindingSource_FIPRCART_1.DataSource = objdatos.fun_Consultar_FIPRCART(vp_FichaPredial)
            dgvFIPRCART.DataSource = BindingSource_FIPRCART_1.DataSource
            BindingNavigator_FIPRCART_1.BindingSource = BindingSource_FIPRCART_1

            dgvFIPRCART.Columns(0).Visible = False
            dgvFIPRCART.Columns(1).Visible = False

            strBARRESTA.Items(2).Text = "Registros : " & BindingSource_FIPRCART_1.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_NumeroDeSecuenciaDeRegistro()
        Dim inFPCASECU As Integer = 0

        Dim objdatos5 As New cla_FIPRCART
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRCART_X_FICHA_PREDIAL(Val(vp_FichaPredial))

        If tbl10.Rows.Count = 0 Then
            inFPCASECU = 1
        Else
            Dim i As Integer
            Dim NroMayor As Integer
            Dim Posicion As Integer

            Posicion = Val(tbl10.Rows(0).Item("FPCASECU"))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item("FPCASECU"))

                If NroMayor > Posicion Then
                    inFPCASECU = NroMayor
                    Posicion = NroMayor
                Else
                    inFPCASECU = Posicion
                End If
            Next

            inFPCASECU = inFPCASECU + 1
        End If

        lblFPCASECU.Text = inFPCASECU
    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtFPCAPLAN.Text = ""
        Me.txtFPCAVENT.Text = ""
        Me.txtFPCAESGR.Text = ""
        Me.txtFPCAVUEL.Text = ""
        Me.txtFPCAFAJA.Text = ""
        Me.txtFPCAFOTO.Text = ""
        Me.txtFPCAAMPL.Text = ""
        Me.txtFPCAESAE.Text = ""

        Me.strBARRESTA.Items(1).Text = ""

        Me.cboFPCAVIAE.DataSource = New DataTable
        Me.cboFPCAVIGR.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            If fun_Verificar_Campos_Llenos_8_DATOS(Trim(Me.txtFPCAPLAN.Text), _
                                                   Trim(Me.txtFPCAESGR.Text), _
                                                   Trim(Me.cboFPCAVIGR.Text), _
                                                   Trim(Me.txtFPCAVUEL.Text), _
                                                   Trim(Me.txtFPCAFAJA.Text), _
                                                   Trim(Me.txtFPCAFOTO.Text), _
                                                   Trim(Me.cboFPCAVIAE.Text), _
                                                   Trim(Me.txtFPCAESAE.Text)) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                Me.txtFPCAPLAN.Focus()
            Else
                Dim objdatos As New cla_FIPRCART
                Dim inFPCASECU As Integer = 0

                Dim objdatos5 As New cla_FIPRCART
                Dim tbl10 As New DataTable

                tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRCART_X_FICHA_PREDIAL(Val(vp_FichaPredial))

                If tbl10.Rows.Count = 0 Then
                    inFPCASECU = 1
                Else
                    Dim i As Integer
                    Dim NroMayor As Integer
                    Dim Posicion As Integer

                    Posicion = Val(tbl10.Rows(0).Item("FPCASECU"))

                    For i = 0 To tbl10.Rows.Count - 1
                        NroMayor = Val(tbl10.Rows(i).Item("FPCASECU"))

                        If NroMayor > Posicion Then
                            inFPCASECU = NroMayor
                            Posicion = NroMayor
                        Else
                            inFPCASECU = Posicion
                        End If
                    Next
                    inFPCASECU = inFPCASECU + 1
                End If

                lblFPCASECU.Text = inFPCASECU

                If (objdatos.fun_Insertar_FIPRCART(vp_FichaPredial, _
                                                   Trim(Me.txtFPCAPLAN.Text), _
                                                   Trim(Me.txtFPCAVENT.Text), _
                                                   Trim(Me.txtFPCAESGR.Text), _
                                                   Me.cboFPCAVIGR.SelectedValue, _
                                                   Trim(Me.txtFPCAVUEL.Text), _
                                                   Trim(Me.txtFPCAFAJA.Text), _
                                                   Trim(Me.txtFPCAFOTO.Text), _
                                                   Me.cboFPCAVIAE.SelectedValue, _
                                                   Trim(Me.txtFPCAAMPL.Text), _
                                                   Trim(Me.txtFPCAESAE.Text), _
                                                   vl_stRESODEPA, _
                                                   vl_stRESOMUNI, _
                                                   vl_inRESOTIRE, _
                                                   vl_inRESOCLSE, _
                                                   vl_inRESOVIGE, _
                                                   vl_inRESORESO, _
                                                   inFPCASECU, _
                                                   vl_inFIPRNURE, _
                                                   Me.cboFPCAESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        pro_NumeroDeSecuenciaDeRegistro()
                        pro_ReconsultarLinderos()

                        Me.txtFPCAPLAN.Text = ""
                        Me.strBARRESTA.Items(1).Text = ""

                        'Me.cboFPCAVIAE.DataSource = New DataTable
                        'Me.cboFPCAVIGR.DataSource = New DataTable

                        Me.txtFPCAPLAN.Focus()

                    Else
                        Me.txtFPCAPLAN.Focus()
                        Me.Close()

                    End If

                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Guardar")
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtFPCAPLAN.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_FIPRLIND_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strBARRESTA.Items(0).Text = "Cartografia"
    End Sub

#End Region

#Region "Click"

    Private Sub cboFPCAVIGR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCAVIGR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA(cboFPCAVIGR, cboFPCAVIGR.SelectedIndex)
    End Sub
    Private Sub cboFPCAVIAE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCAVIAE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA(cboFPCAVIAE, cboFPCAVIAE.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFPCAPLAN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAPLAN.Validated
        If Trim(txtFPCAPLAN.Text) = "" Then
            txtFPCAPLAN.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtFPCAESGR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAESGR.Validated
        If Trim(txtFPCAESGR.Text) = "" Then
            txtFPCAESGR.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboFPCAVIGR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCAVIGR.Validated
        If Trim(cboFPCAVIGR.Text) = "" Then
            cboFPCAVIGR.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtFPCAVUEL_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAVUEL.Validated
        If Trim(txtFPCAVUEL.Text) = "" Then
            txtFPCAVUEL.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtFPCAFAJA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAFAJA.Validated
        If Trim(txtFPCAFAJA.Text) = "" Then
            txtFPCAFAJA.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtFPCAFOTO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAFOTO.Validated
        If Trim(txtFPCAFOTO.Text) = "" Then
            txtFPCAFOTO.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboFPCAVIAE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCAVIAE.Validated
        If Trim(cboFPCAVIAE.Text) = "" Then
            cboFPCAVIAE.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtFPCAESAE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAESAE.Validated
        If Trim(txtFPCAESAE.Text) = "" Then
            txtFPCAESAE.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtFPCAPLAN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAPLAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAVENT.Focus()
        End If
    End Sub
    Private Sub txtFPCAVENT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAVENT.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAESGR.Focus()
        End If
    End Sub
    Private Sub txtFPCAESGR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAESGR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cboFPCAVIGR.Focus()
        End If
    End Sub
    Private Sub cboFPCAVIGR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPCAVIGR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAVUEL.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA(cboFPCAVIGR, cboFPCAVIGR.SelectedIndex)
        End If
    End Sub
    Private Sub txtFPCAVUEL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAVUEL.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAFAJA.Focus()
        End If
    End Sub
    Private Sub txtFPCAFAJA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAFAJA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAFOTO.Focus()
        End If
    End Sub
    Private Sub txtFPCAFOTO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAFOTO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cboFPCAVIAE.Focus()
        End If
    End Sub
    Private Sub cboFPCAVIAE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPCAVIAE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAAMPL.Focus()
        End If
        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA(cboFPCAVIAE, cboFPCAVIAE.SelectedIndex)
        End If
    End Sub
    Private Sub txtFPCAAMPL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAAMPL.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFPCAESAE.Focus()
        End If
    End Sub
    Private Sub txtFPCAESAE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPCAESAE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cboFPCAESTA.Focus()
        End If
    End Sub
    Private Sub cboFPCAESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPCAESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub dgvFIPRCART_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFIPRCART.GotFocus
        strBARRESTA.Items(0).Text = dgvFIPRCART.AccessibleDescription
    End Sub
    Private Sub txtFPCAPLAN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAPLAN.GotFocus
        txtFPCAPLAN.SelectionStart = 0
        txtFPCAPLAN.SelectionLength = Len(txtFPCAPLAN.Text)
        strBARRESTA.Items(0).Text = txtFPCAPLAN.AccessibleDescription
    End Sub
    Private Sub txtFPCAVENT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAVENT.GotFocus
        txtFPCAVENT.SelectionStart = 0
        txtFPCAVENT.SelectionLength = Len(txtFPCAVENT.Text)
        strBARRESTA.Items(0).Text = txtFPCAVENT.AccessibleDescription
    End Sub
    Private Sub txtFPCAESGR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAESGR.GotFocus
        txtFPCAESGR.SelectionStart = 0
        txtFPCAESGR.SelectionLength = Len(txtFPCAESGR.Text)
        strBARRESTA.Items(0).Text = txtFPCAESGR.AccessibleDescription
    End Sub
    Private Sub cboFPCAVIGR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCAVIGR.GotFocus
        strBARRESTA.Items(0).Text = cboFPCAVIGR.AccessibleDescription
    End Sub
    Private Sub txtFPCAVUEL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAVUEL.GotFocus
        txtFPCAVUEL.SelectionStart = 0
        txtFPCAVUEL.SelectionLength = Len(txtFPCAVUEL.Text)
        strBARRESTA.Items(0).Text = txtFPCAVUEL.AccessibleDescription
    End Sub
    Private Sub txtFPCAFAJA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAFAJA.GotFocus
        txtFPCAFAJA.SelectionStart = 0
        txtFPCAFAJA.SelectionLength = Len(txtFPCAFAJA.Text)
        strBARRESTA.Items(0).Text = txtFPCAFAJA.AccessibleDescription
    End Sub
    Private Sub txtFPCAFOTO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAFOTO.GotFocus
        txtFPCAFOTO.SelectionStart = 0
        txtFPCAFOTO.SelectionLength = Len(txtFPCAFOTO.Text)
        strBARRESTA.Items(0).Text = txtFPCAFOTO.AccessibleDescription
    End Sub
    Private Sub cboFPCAVIAE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCAVIAE.GotFocus
        strBARRESTA.Items(0).Text = cboFPCAVIAE.AccessibleDescription
    End Sub
    Private Sub txtFPCAAMPL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAAMPL.GotFocus
        txtFPCAAMPL.SelectionStart = 0
        txtFPCAAMPL.SelectionLength = Len(txtFPCAAMPL.Text)
        strBARRESTA.Items(0).Text = txtFPCAAMPL.AccessibleDescription
    End Sub
    Private Sub txtFPCAESAE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPCAESAE.GotFocus
        txtFPCAESAE.SelectionStart = 0
        txtFPCAESAE.SelectionLength = Len(txtFPCAESAE.Text)
        strBARRESTA.Items(0).Text = txtFPCAESAE.AccessibleDescription
    End Sub
    Private Sub cboFPCAESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPCAESTA.GotFocus
        strBARRESTA.Items(0).Text = cboFPCAESTA.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
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