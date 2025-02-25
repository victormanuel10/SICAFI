Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_RECLAMOS

    '==========================
    '*** MODIFICAR RECLAMOS ***
    '==========================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inInRegistro As Integer)
        inID_REGISTRO = inInRegistro

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Try
            Me.dtpRECLFEDE.Value = fun_fecha()
            Me.dtpRECLFEMU.Value = fun_fecha()
            Me.dtpRECLFEED.Value = fun_fecha()
            Me.dtpRECLFEDM.Value = fun_fecha()
            Me.dtpRECLFELC.Value = fun_fecha()

            Dim objdatos1 As New cla_CLASSECT

            Me.cboRECLCLSE.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboRECLCLSE.DisplayMember = "CLSEDESC"
            Me.cboRECLCLSE.ValueMember = "CLSECODI"

            Dim objdatos2 As New cla_VIGENCIA

            Me.cboRECLVIGE.DataSource = objdatos2.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboRECLVIGE.DisplayMember = "VIGEDESC"
            Me.cboRECLVIGE.ValueMember = "VIGECODI"

            Dim objdatos3 As New cla_TIPOTRAM

            Me.cboRECLTITR.DataSource = objdatos3.fun_Consultar_CAMPOS_MANT_TIPOTRAM
            Me.cboRECLTITR.DisplayMember = "TITRDESC"
            Me.cboRECLTITR.ValueMember = "TITRCODI"

            Dim objdatos7 As New cla_ESTADO

            Me.cboRECLESTA.DataSource = objdatos7.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboRECLESTA.DisplayMember = "ESTADESC"
            Me.cboRECLESTA.ValueMember = "ESTACODI"

            Dim objdatos9 As New cla_SOLICITANTE

            Me.cboRECLSOLI.DataSource = objdatos9.fun_Consultar_CAMPOS_MANT_SOLICITANTE
            Me.cboRECLSOLI.DisplayMember = "SOLIDESC"
            Me.cboRECLSOLI.ValueMember = "SOLICODI"

            Dim objdatos8 As New cla_RECLAMOS
            Dim tbl As New DataTable

            tbl = objdatos8.fun_Buscar_ID_RECLAMOS(inID_REGISTRO)

            Me.txtRECLSECU.Text = Trim(tbl.Rows(0).Item("RECLSECU"))
            Me.txtRECLMUNI.Text = Trim(tbl.Rows(0).Item("RECLMUNI"))
            Me.txtRECLCORR.Text = Trim(tbl.Rows(0).Item("RECLCORR"))
            Me.txtRECLBARR.Text = Trim(tbl.Rows(0).Item("RECLBARR"))
            Me.txtRECLMANZ.Text = Trim(tbl.Rows(0).Item("RECLMANZ"))
            Me.txtRECLPRED.Text = Trim(tbl.Rows(0).Item("RECLPRED"))
            Me.txtRECLEDIF.Text = Trim(tbl.Rows(0).Item("RECLEDIF"))
            Me.txtRECLUNPR.Text = Trim(tbl.Rows(0).Item("RECLUNPR"))
            Me.cboRECLVIGE.SelectedValue = tbl.Rows(0).Item("RECLVIGE")
            Me.cboRECLCLSE.SelectedValue = tbl.Rows(0).Item("RECLCLSE")
            Me.txtRECLNUDO.Text = Trim(tbl.Rows(0).Item("RECLNUDO"))
            Me.txtRECLNOMB.Text = Trim(tbl.Rows(0).Item("RECLNOMB"))
            Me.txtRECLPRAP.Text = Trim(tbl.Rows(0).Item("RECLPRAP"))
            Me.txtRECLSEAP.Text = Trim(tbl.Rows(0).Item("RECLSEAP"))
            Me.txtRECLMAIN.Text = Trim(tbl.Rows(0).Item("RECLMAIN"))
            Me.txtRECLRADE.Text = Trim(tbl.Rows(0).Item("RECLRADE"))
            Me.txtRECLFEDE.Text = Trim(tbl.Rows(0).Item("RECLFEDE"))
            Me.txtRECLRAMU.Text = Trim(tbl.Rows(0).Item("RECLRAMU"))
            Me.txtRECLFEMU.Text = Trim(tbl.Rows(0).Item("RECLFEMU"))
            Me.txtRECLRAED.Text = Trim(tbl.Rows(0).Item("RECLRAED"))
            Me.txtRECLFEED.Text = Trim(tbl.Rows(0).Item("RECLFEED"))
            Me.txtRECLRADM.Text = Trim(tbl.Rows(0).Item("RECLRADM"))
            Me.txtRECLFEDM.Text = Trim(tbl.Rows(0).Item("RECLFEDM"))
            Me.txtRECLFELC.Text = Trim(tbl.Rows(0).Item("RECLFELC"))
            Me.cboRECLTITR.SelectedValue = tbl.Rows(0).Item("RECLTITR")
            Me.cboRECLESTA.SelectedValue = tbl.Rows(0).Item("RECLESTA")
            Me.txtRECLOBSE.Text = Trim(tbl.Rows(0).Item("RECLOBSE"))
            Me.cboRECLSOLI.SelectedValue = tbl.Rows(0).Item("RECLSOLI")
            Me.txtRECLMIAN.Text = Trim(tbl.Rows(0).Item("RECLMIAN"))

            Dim boRECLVIGE As Boolean = fun_Buscar_Dato_VIGENCIA(Me.cboRECLVIGE.SelectedValue)
            Dim boRECLCLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboRECLCLSE.SelectedValue)
            Dim boRECLTITR As Boolean = fun_Buscar_Dato_TIPOTRAM(Me.cboRECLTITR.SelectedValue)
            Dim boRECLSOLI As Boolean = fun_Buscar_Dato_SOLICITANTE(Me.cboRECLSOLI.SelectedValue)

            If boRECLVIGE = True OrElse _
               boRECLCLSE = True OrElse _
               boRECLSOLI = True OrElse _
               boRECLTITR = True Then

                Me.lblRECLVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboRECLVIGE), String)
                Me.lblRECLCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRECLCLSE), String)
                Me.lblRECLTITR.Text = CType(fun_Buscar_Lista_Valores_TIPOTRAM_Codigo(Me.cboRECLTITR), String)
                Me.lblRECLSOLI.Text = CType(fun_Buscar_Lista_Valores_SOLICITANTE_Codigo(Me.cboRECLSOLI), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboRECLCLSE.DataSource = New DataTable
        Me.cboRECLVIGE.DataSource = New DataTable
        Me.cboRECLTITR.DataSource = New DataTable
        Me.cboRECLVIGE.DataSource = New DataTable
        Me.cboRECLESTA.DataSource = New DataTable
        Me.cboRECLSOLI.DataSource = New DataTable

        Me.txtRECLSECU.Text = ""
        Me.lblRECLCLSE.Text = ""
        Me.lblRECLVIGE.Text = ""
        Me.lblRECLTITR.Text = ""
        Me.lblRECLSOLI.Text = ""
        Me.txtRECLMUNI.Text = "266"
        Me.txtRECLCORR.Text = "01"
        Me.txtRECLBARR.Text = ""
        Me.txtRECLMANZ.Text = ""
        Me.txtRECLPRED.Text = ""
        Me.txtRECLEDIF.Text = ""
        Me.txtRECLUNPR.Text = ""
        Me.txtRECLOBSE.Text = ""
        Me.txtRECLOBSE_NUEVAS.Text = ""
        Me.txtRECLNUDO.Text = ""
        Me.txtRECLNOMB.Text = ""
        Me.txtRECLPRAP.Text = ""
        Me.txtRECLSEAP.Text = ""
        Me.txtRECLMAIN.Text = ""
        Me.txtRECLRADE.Text = "0"
        Me.txtRECLFEDE.Text = ""
        Me.txtRECLRAMU.Text = "0"
        Me.txtRECLFEMU.Text = ""
        Me.txtRECLRADM.Text = "0"
        Me.txtRECLFEDM.Text = ""
        Me.txtRECLRAED.Text = "0"
        Me.txtRECLFEED.Text = ""
        Me.txtRECLFELC.Text = ""
        Me.txtRECLMIAN.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boRECLMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRECLMUNI)
            Dim boRECLCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRECLCORR)
            Dim boRECLBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRECLBARR)
            Dim boRECLMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRECLMANZ)
            Dim boRECLPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRECLPRED)
            Dim boRECLEDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRECLEDIF)
            Dim boRECLUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRECLUNPR)

            Dim boRECLRADE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRECLRADE)
            Dim boRECLRAMU As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRECLRAMU)
            Dim boRECLRAED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRECLRAED)
            Dim boRECLRADM As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRECLRADM)

            Dim boRECLNUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRECLNUDO)
            Dim boRECLNOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRECLNOMB)
            Dim boRECLMAIN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRECLMAIN)
            Dim boRECLCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRECLCLSE)
            Dim boRECLVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRECLVIGE)
            Dim boRECLTITR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRECLTITR)
            Dim boRECLESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRECLESTA)
            Dim boRECLSOLI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRECLSOLI)

            Dim boRECLFELC As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtRECLFELC)

            Dim stRECLOBSE_NUEVA As String = Trim(Me.txtRECLOBSE_NUEVAS.Text)

            If Trim(stRECLOBSE_NUEVA) <> "" Then
                Me.txtRECLOBSE.Text += " Nota ingresada por: " & vp_usuario & " " & fun_fecha() & " : " & stRECLOBSE_NUEVA & ". "
            End If

            ' verifica los datos del formulario 
            If boRECLMUNI = True And _
               boRECLCORR = True And _
               boRECLBARR = True And _
               boRECLMANZ = True And _
               boRECLPRED = True And _
               boRECLEDIF = True And _
               boRECLRADE = True And _
               boRECLRAMU = True And _
               boRECLRAED = True And _
               boRECLRADM = True And _
               boRECLUNPR = True And _
               boRECLNUDO = True And _
               boRECLNOMB = True And _
               boRECLMAIN = True And _
               boRECLCLSE = True And _
               boRECLVIGE = True And _
               boRECLTITR = True And _
               boRECLESTA = True And _
               boRECLFELC = True And _
               boRECLSOLI = True Then

                Dim objdatos22 As New cla_RECLAMOS

                If (objdatos22.fun_Actualizar_RECLAMOS(inID_REGISTRO, _
                                                     Me.txtRECLSECU.Text, _
                                                     Me.txtRECLMUNI.Text, _
                                                     Me.txtRECLCORR.Text, _
                                                     Me.txtRECLBARR.Text, _
                                                     Me.txtRECLMANZ.Text, _
                                                     Me.txtRECLPRED.Text, _
                                                     Me.txtRECLEDIF.Text, _
                                                     Me.txtRECLUNPR.Text, _
                                                     Me.cboRECLCLSE.SelectedValue, _
                                                     Me.cboRECLVIGE.SelectedValue, _
                                                     Me.txtRECLNUDO.Text, _
                                                     Me.txtRECLNOMB.Text, _
                                                     Me.txtRECLPRAP.Text, _
                                                     Me.txtRECLSEAP.Text, _
                                                     Me.txtRECLMAIN.Text, _
                                                     Me.txtRECLRADE.Text, _
                                                     Me.txtRECLFEDE.Text, _
                                                     Me.txtRECLRAMU.Text, _
                                                     Me.txtRECLFEMU.Text, _
                                                     Me.txtRECLRAED.Text, _
                                                     Me.txtRECLFEED.Text, _
                                                     Me.txtRECLRADM.Text, _
                                                     Me.txtRECLFEDM.Text, _
                                                     Me.txtRECLFELC.Text, _
                                                     Me.cboRECLTITR.SelectedValue, _
                                                     Trim(Me.txtRECLOBSE.Text), _
                                                     Me.cboRECLESTA.SelectedValue, _
                                                     Me.txtRECLMIAN.Text, _
                                                     Me.cboRECLSOLI.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    Dim objdatos1 As New cla_RECLAMOS
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_CODIGO_X_RECLAMOS(CInt(Me.txtRECLSECU.Text))

                    If tbl1.Rows.Count > 0 Then

                        Dim inNroIdRe As New frm_RECLAMOS(tbl1.Rows(0).Item("RECLIDRE"))

                    End If

                    Me.txtRECLMUNI.Focus()
                    Me.Close()

                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Dim inNroIdRe As New frm_RECLAMOS(0)
        Me.txtRECLMUNI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRECLMUNI.KeyPress, txtRECLCORR.KeyPress, txtRECLBARR.KeyPress, txtRECLMANZ.KeyPress, txtRECLPRED.KeyPress, txtRECLEDIF.KeyPress, txtRECLUNPR.KeyPress, cboRECLCLSE.KeyPress, cboRECLVIGE.KeyPress, txtRECLNUDO.KeyPress, txtRECLNOMB.KeyPress, txtRECLPRAP.KeyPress, txtRECLSEAP.KeyPress, txtRECLMAIN.KeyPress, txtRECLRADE.KeyPress, txtRECLFEDE.KeyPress, txtRECLFEMU.KeyPress, txtRECLRAMU.KeyPress, txtRECLRAED.KeyPress, txtRECLFEED.KeyPress, txtRECLRADM.KeyPress, txtRECLFEDM.KeyPress, txtRECLFELC.KeyPress, cboRECLTITR.KeyPress, cboRECLESTA.KeyPress, txtRECLOBSE.KeyPress, txtRECLMIAN.KeyPress, cboRECLSOLI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTRCACLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRECLCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRECLCLSE, Me.cboRECLCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCAVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRECLVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboRECLVIGE, Me.cboRECLVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboRECLTITR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRECLTITR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOTRAM_Descripcion(Me.cboRECLTITR, Me.cboRECLTITR.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRECLESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboRECLESTA, Me.cboRECLESTA.SelectedIndex)
        End If
    End Sub
    Private Sub cboRECLSOLI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRECLSOLI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_SOLICITANTE_Descripcion(Me.cboRECLSOLI, Me.cboRECLSOLI.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECLMUNI.GotFocus, txtRECLCORR.GotFocus, txtRECLBARR.GotFocus, txtRECLMANZ.GotFocus, txtRECLPRED.GotFocus, txtRECLEDIF.GotFocus, txtRECLUNPR.GotFocus, txtRECLNUDO.GotFocus, txtRECLNOMB.GotFocus, txtRECLPRAP.GotFocus, txtRECLSEAP.GotFocus, txtRECLMAIN.GotFocus, txtRECLRADE.GotFocus, txtRECLFEDE.GotFocus, txtRECLFEMU.GotFocus, txtRECLRAMU.GotFocus, txtRECLRAED.GotFocus, txtRECLFEED.GotFocus, txtRECLRADM.GotFocus, txtRECLFEDM.GotFocus, txtRECLFELC.GotFocus, txtRECLOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRECLCLSE.GotFocus, cboRECLVIGE.GotFocus, cboRECLTITR.GotFocus, cboRECLESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTRCACLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRECLCLSE.SelectedIndexChanged
        Me.lblRECLCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRECLCLSE), String)
    End Sub
    Private Sub cboTRCAVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRECLVIGE.SelectedIndexChanged
        Me.lblRECLVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboRECLVIGE), String)
    End Sub
    Private Sub cboRECLTITR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRECLTITR.SelectedIndexChanged
        Me.lblRECLTITR.Text = CType(fun_Buscar_Lista_Valores_TIPOTRAM_Codigo(Me.cboRECLTITR), String)
    End Sub
    Private Sub cboRECLSOLI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRECLSOLI.SelectedIndexChanged
        Me.lblRECLSOLI.Text = CType(fun_Buscar_Lista_Valores_SOLICITANTE_Codigo(Me.cboRECLSOLI), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTRCACLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRECLCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRECLCLSE, Me.cboRECLCLSE.SelectedIndex)
    End Sub
    Private Sub cboTRCAVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRECLVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboRECLVIGE, Me.cboRECLVIGE.SelectedIndex)
    End Sub
    Private Sub cboRECLTITR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRECLTITR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOTRAM_Descripcion(Me.cboRECLTITR, Me.cboRECLTITR.SelectedIndex)
    End Sub
    Private Sub cboTRCAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRECLESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboRECLESTA, Me.cboRECLESTA.SelectedIndex)
    End Sub
    Private Sub cboRECLSOLI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRECLSOLI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_SOLICITANTE_Descripcion(Me.cboRECLSOLI, Me.cboRECLSOLI.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTAPEAVFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECLRADE.Validated, txtRECLRAMU.Validated, txtRECLRAED.Validated, txtRECLRADM.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        End If

    End Sub

    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECLMUNI.Validated
        If Me.txtRECLMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRECLMUNI.Text) = True Then
            Me.txtRECLMUNI.Text = fun_Formato_Mascara_3_String(Me.txtRECLMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECLCORR.Validated
        If Me.txtRECLCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRECLCORR.Text) = True Then
            Me.txtRECLCORR.Text = fun_Formato_Mascara_2_String(Me.txtRECLCORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECLBARR.Validated
        If Me.txtRECLBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRECLBARR.Text) = True Then
            Me.txtRECLBARR.Text = fun_Formato_Mascara_3_String(Me.txtRECLBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECLMANZ.Validated
        If Me.txtRECLMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRECLMANZ.Text) = True Then
            Me.txtRECLMANZ.Text = fun_Formato_Mascara_3_String(Me.txtRECLMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECLPRED.Validated
        If Me.txtRECLPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRECLPRED.Text) = True Then
            Me.txtRECLPRED.Text = fun_Formato_Mascara_5_String(Me.txtRECLPRED.Text)
        End If
    End Sub
    Private Sub txtRECLEDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECLEDIF.Validated
        If Me.txtRECLEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRECLEDIF.Text) = True Then
            Me.txtRECLEDIF.Text = fun_Formato_Mascara_3_String(Me.txtRECLEDIF.Text)
        End If
    End Sub
    Private Sub txtRECLUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECLUNPR.Validated
        If Me.txtRECLUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRECLUNPR.Text) = True Then
            Me.txtRECLUNPR.Text = fun_Formato_Mascara_5_String(Me.txtRECLUNPR.Text)
        End If
    End Sub
    Private Sub txtRECLNUDO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECLNUDO.Validated

        Try
            ' extrae el tercero si ya existe en base de datos
            Dim objdatos1 As New cla_TERCERO
            Dim tbl1 As New DataTable

            tbl1 = objdatos1.fun_Buscar_CODIGO_TERCERO(Trim(Me.txtRECLNUDO.Text))

            If tbl1.Rows.Count > 0 Then

                Me.txtRECLNOMB.Text = Trim(tbl1.Rows(0).Item(5))
                Me.txtRECLPRAP.Text = Trim(tbl1.Rows(0).Item(6))
                Me.txtRECLSEAP.Text = Trim(tbl1.Rows(0).Item(7))

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

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

#Region "ValueChanged"

    Private Sub dtpRECLFEDE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRECLFEDE.ValueChanged
        Me.dtpRECLFEDE.Value = fun_fecha()
        Me.txtRECLFEDE.Text = Me.dtpRECLFEDE.Value
    End Sub
    Private Sub dtpRECLFEMU_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRECLFEMU.ValueChanged
        Me.txtRECLFEMU.Text = Me.dtpRECLFEMU.Value
    End Sub
    Private Sub dtpRECLFEED_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRECLFEED.ValueChanged
        Me.txtRECLFEED.Text = Me.dtpRECLFEED.Value
    End Sub
    Private Sub dtpRECLFEDM_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRECLFEDM.ValueChanged
        Me.txtRECLFEDM.Text = Me.dtpRECLFEDM.Value
    End Sub
    Private Sub dtpRECLFELC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRECLFELC.ValueChanged
        Me.txtRECLFELC.Text = Me.dtpRECLFELC.Value
    End Sub

#End Region

#End Region

End Class