Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_REVIAVAL

    '====================================
    '*** MODIFICAR REVISION DE AVALUO ***
    '====================================

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
            Me.dtpREAVFEDE.Value = fun_fecha()
            Me.dtpREAVFEMU.Value = fun_fecha()
            Me.dtpREAVFEED.Value = fun_fecha()
            Me.dtpREAVFEDM.Value = fun_fecha()
            Me.dtpREAVFELC.Value = fun_fecha()

            Dim objdatos1 As New cla_CLASSECT

            Me.cboREAVCLSE.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboREAVCLSE.DisplayMember = "CLSEDESC"
            Me.cboREAVCLSE.ValueMember = "CLSECODI"

            Dim objdatos2 As New cla_VIGENCIA

            Me.cboREAVVIGE.DataSource = objdatos2.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboREAVVIGE.DisplayMember = "VIGEDESC"
            Me.cboREAVVIGE.ValueMember = "VIGECODI"

            Dim objdatos3 As New cla_TIPOTRAM

            Me.cboREAVTITR.DataSource = objdatos3.fun_Consultar_CAMPOS_MANT_TIPOTRAM
            Me.cboREAVTITR.DisplayMember = "TITRDESC"
            Me.cboREAVTITR.ValueMember = "TITRCODI"

            Dim objdatos7 As New cla_ESTADO

            Me.cboREAVESTA.DataSource = objdatos7.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboREAVESTA.DisplayMember = "ESTADESC"
            Me.cboREAVESTA.ValueMember = "ESTACODI"

            Dim objdatos9 As New cla_SOLICITANTE

            Me.cboREAVSOLI.DataSource = objdatos9.fun_Consultar_CAMPOS_MANT_SOLICITANTE
            Me.cboREAVSOLI.DisplayMember = "SOLIDESC"
            Me.cboREAVSOLI.ValueMember = "SOLICODI"

            Dim objdatos8 As New cla_REVIAVAL
            Dim tbl As New DataTable

            tbl = objdatos8.fun_Buscar_ID_REVIAVAL(inID_REGISTRO)

            Me.txtREAVSECU.Text = Trim(tbl.Rows(0).Item("REAVSECU"))
            Me.txtREAVMUNI.Text = Trim(tbl.Rows(0).Item("REAVMUNI"))
            Me.txtREAVCORR.Text = Trim(tbl.Rows(0).Item("REAVCORR"))
            Me.txtREAVBARR.Text = Trim(tbl.Rows(0).Item("REAVBARR"))
            Me.txtREAVMANZ.Text = Trim(tbl.Rows(0).Item("REAVMANZ"))
            Me.txtREAVPRED.Text = Trim(tbl.Rows(0).Item("REAVPRED"))
            Me.txtREAVEDIF.Text = Trim(tbl.Rows(0).Item("REAVEDIF"))
            Me.txtREAVUNPR.Text = Trim(tbl.Rows(0).Item("REAVUNPR"))
            Me.cboREAVVIGE.SelectedValue = tbl.Rows(0).Item("REAVVIGE")
            Me.cboREAVCLSE.SelectedValue = tbl.Rows(0).Item("REAVCLSE")
            Me.txtREAVNUDO.Text = Trim(tbl.Rows(0).Item("REAVNUDO"))
            Me.txtREAVNOMB.Text = Trim(tbl.Rows(0).Item("REAVNOMB"))
            Me.txtREAVPRAP.Text = Trim(tbl.Rows(0).Item("REAVPRAP"))
            Me.txtREAVSEAP.Text = Trim(tbl.Rows(0).Item("REAVSEAP"))
            Me.txtREAVMAIN.Text = Trim(tbl.Rows(0).Item("REAVMAIN"))
            Me.txtREAVRADE.Text = Trim(tbl.Rows(0).Item("REAVRADE"))
            Me.txtREAVFEDE.Text = Trim(tbl.Rows(0).Item("REAVFEDE"))
            Me.txtREAVRAMU.Text = Trim(tbl.Rows(0).Item("REAVRAMU"))
            Me.txtREAVFEMU.Text = Trim(tbl.Rows(0).Item("REAVFEMU"))
            Me.txtREAVRAED.Text = Trim(tbl.Rows(0).Item("REAVRAED"))
            Me.txtREAVFEED.Text = Trim(tbl.Rows(0).Item("REAVFEED"))
            Me.txtREAVRADM.Text = Trim(tbl.Rows(0).Item("REAVRADM"))
            Me.txtREAVFEDM.Text = Trim(tbl.Rows(0).Item("REAVFEDM"))
            Me.txtREAVFELC.Text = Trim(tbl.Rows(0).Item("REAVFELC"))
            Me.cboREAVTITR.SelectedValue = tbl.Rows(0).Item("REAVTITR")
            Me.cboREAVESTA.SelectedValue = tbl.Rows(0).Item("REAVESTA")
            Me.txtREAVOBSE.Text = Trim(tbl.Rows(0).Item("REAVOBSE"))
            Me.cboREAVSOLI.SelectedValue = tbl.Rows(0).Item("REAVSOLI")
            Me.txtREAVMIAN.Text = Trim(tbl.Rows(0).Item("REAVMIAN"))

            Dim boREAVVIGE As Boolean = fun_Buscar_Dato_VIGENCIA(Me.cboREAVVIGE.SelectedValue)
            Dim boREAVCLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboREAVCLSE.SelectedValue)
            Dim boREAVTITR As Boolean = fun_Buscar_Dato_TIPOTRAM(Me.cboREAVTITR.SelectedValue)
            Dim boREAVSOLI As Boolean = fun_Buscar_Dato_SOLICITANTE(Me.cboREAVSOLI.SelectedValue)

            If boREAVVIGE = True OrElse _
               boREAVCLSE = True OrElse _
               boREAVSOLI = True OrElse _
               boREAVTITR = True Then

                Me.lblREAVVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboREAVVIGE), String)
                Me.lblREAVCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboREAVCLSE), String)
                Me.lblREAVTITR.Text = CType(fun_Buscar_Lista_Valores_TIPOTRAM_Codigo(Me.cboREAVTITR), String)
                Me.lblREAVSOLI.Text = CType(fun_Buscar_Lista_Valores_SOLICITANTE_Codigo(Me.cboREAVSOLI), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboREAVCLSE.DataSource = New DataTable
        Me.cboREAVVIGE.DataSource = New DataTable
        Me.cboREAVTITR.DataSource = New DataTable
        Me.cboREAVVIGE.DataSource = New DataTable
        Me.cboREAVESTA.DataSource = New DataTable
        Me.cboREAVSOLI.DataSource = New DataTable

        Me.txtREAVSECU.Text = ""
        Me.lblREAVCLSE.Text = ""
        Me.lblREAVVIGE.Text = ""
        Me.lblREAVTITR.Text = ""
        Me.lblREAVSOLI.Text = ""
        Me.txtREAVMUNI.Text = "266"
        Me.txtREAVCORR.Text = "01"
        Me.txtREAVBARR.Text = ""
        Me.txtREAVMANZ.Text = ""
        Me.txtREAVPRED.Text = ""
        Me.txtREAVEDIF.Text = ""
        Me.txtREAVUNPR.Text = ""
        Me.txtREAVOBSE.Text = ""
        Me.txtREAVOBSE_NUEVAS.Text = ""
        Me.txtREAVNUDO.Text = ""
        Me.txtREAVNOMB.Text = ""
        Me.txtREAVPRAP.Text = ""
        Me.txtREAVSEAP.Text = ""
        Me.txtREAVMAIN.Text = ""
        Me.txtREAVRADE.Text = "0"
        Me.txtREAVFEDE.Text = ""
        Me.txtREAVRAMU.Text = "0"
        Me.txtREAVFEMU.Text = ""
        Me.txtREAVRADM.Text = "0"
        Me.txtREAVFEDM.Text = ""
        Me.txtREAVRAED.Text = "0"
        Me.txtREAVFEED.Text = ""
        Me.txtREAVFELC.Text = ""
        Me.txtREAVMIAN.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boREAVMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtREAVMUNI)
            Dim boREAVCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtREAVCORR)
            Dim boREAVBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtREAVBARR)
            Dim boREAVMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtREAVMANZ)
            Dim boREAVPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtREAVPRED)
            Dim boREAVEDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtREAVEDIF)
            Dim boREAVUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtREAVUNPR)

            Dim boREAVRADE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtREAVRADE)
            Dim boREAVRAMU As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtREAVRAMU)
            Dim boREAVRAED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtREAVRAED)
            Dim boREAVRADM As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtREAVRADM)

            Dim boREAVNUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREAVNUDO)
            Dim boREAVNOMB As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREAVNOMB)
            Dim boREAVMAIN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtREAVMAIN)
            Dim boREAVCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREAVCLSE)
            Dim boREAVVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREAVVIGE)
            Dim boREAVTITR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREAVTITR)
            Dim boREAVESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREAVESTA)
            Dim boREAVSOLI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREAVSOLI)

            Dim boREAVFELC As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtREAVFELC)

            Dim stREAVOBSE_NUEVA As String = Trim(Me.txtREAVOBSE_NUEVAS.Text)

            If Trim(stREAVOBSE_NUEVA) <> "" Then
                Me.txtREAVOBSE.Text += " Nota ingresada por: " & vp_usuario & " " & fun_fecha() & " : " & stREAVOBSE_NUEVA & ". "
            End If

            ' verifica los datos del formulario 
            If boREAVMUNI = True And _
               boREAVCORR = True And _
               boREAVBARR = True And _
               boREAVMANZ = True And _
               boREAVPRED = True And _
               boREAVEDIF = True And _
               boREAVRADE = True And _
               boREAVRAMU = True And _
               boREAVRAED = True And _
               boREAVRADM = True And _
               boREAVUNPR = True And _
               boREAVNUDO = True And _
               boREAVNOMB = True And _
               boREAVMAIN = True And _
               boREAVCLSE = True And _
               boREAVVIGE = True And _
               boREAVTITR = True And _
               boREAVESTA = True And _
               boREAVFELC = True And _
               boREAVSOLI = True Then

                Dim objdatos22 As New cla_REVIAVAL

                If (objdatos22.fun_Actualizar_REVIAVAL(inID_REGISTRO, _
                                                     Me.txtREAVSECU.Text, _
                                                     Me.txtREAVMUNI.Text, _
                                                     Me.txtREAVCORR.Text, _
                                                     Me.txtREAVBARR.Text, _
                                                     Me.txtREAVMANZ.Text, _
                                                     Me.txtREAVPRED.Text, _
                                                     Me.txtREAVEDIF.Text, _
                                                     Me.txtREAVUNPR.Text, _
                                                     Me.cboREAVCLSE.SelectedValue, _
                                                     Me.cboREAVVIGE.SelectedValue, _
                                                     Me.txtREAVNUDO.Text, _
                                                     Me.txtREAVNOMB.Text, _
                                                     Me.txtREAVPRAP.Text, _
                                                     Me.txtREAVSEAP.Text, _
                                                     Me.txtREAVMAIN.Text, _
                                                     Me.txtREAVRADE.Text, _
                                                     Me.txtREAVFEDE.Text, _
                                                     Me.txtREAVRAMU.Text, _
                                                     Me.txtREAVFEMU.Text, _
                                                     Me.txtREAVRAED.Text, _
                                                     Me.txtREAVFEED.Text, _
                                                     Me.txtREAVRADM.Text, _
                                                     Me.txtREAVFEDM.Text, _
                                                     Me.txtREAVFELC.Text, _
                                                     Me.cboREAVTITR.SelectedValue, _
                                                     Trim(Me.txtREAVOBSE.Text), _
                                                     Me.cboREAVESTA.SelectedValue, _
                                                     Me.txtREAVMIAN.Text, _
                                                     Me.cboREAVSOLI.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    Dim objdatos1 As New cla_REVIAVAL
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_CODIGO_X_REVIAVAL(CInt(Me.txtREAVSECU.Text))

                    If tbl1.Rows.Count > 0 Then

                        Dim inNroIdRe As New frm_REVIAVAL(tbl1.Rows(0).Item("REAVIDRE"))

                    End If

                    Me.txtREAVMUNI.Focus()
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
        Dim inNroIdRe As New frm_REVIAVAL(inID_REGISTRO)
        Me.txtREAVMUNI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtREAVMUNI.KeyPress, txtREAVCORR.KeyPress, txtREAVBARR.KeyPress, txtREAVMANZ.KeyPress, txtREAVPRED.KeyPress, txtREAVEDIF.KeyPress, txtREAVUNPR.KeyPress, cboREAVCLSE.KeyPress, cboREAVVIGE.KeyPress, txtREAVNUDO.KeyPress, txtREAVNOMB.KeyPress, txtREAVPRAP.KeyPress, txtREAVSEAP.KeyPress, txtREAVMAIN.KeyPress, txtREAVRADE.KeyPress, txtREAVFEDE.KeyPress, txtREAVFEMU.KeyPress, txtREAVRAMU.KeyPress, txtREAVRAED.KeyPress, txtREAVFEED.KeyPress, txtREAVRADM.KeyPress, txtREAVFEDM.KeyPress, txtREAVFELC.KeyPress, cboREAVTITR.KeyPress, cboREAVESTA.KeyPress, txtREAVOBSE.KeyPress, txtREAVMIAN.KeyPress, cboREAVSOLI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTRCACLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREAVCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboREAVCLSE, Me.cboREAVCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCAVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREAVVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboREAVVIGE, Me.cboREAVVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboREAVTITR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREAVTITR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOTRAM_Descripcion(Me.cboREAVTITR, Me.cboREAVTITR.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREAVESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboREAVESTA, Me.cboREAVESTA.SelectedIndex)
        End If
    End Sub
    Private Sub cboREAVSOLI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREAVSOLI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_SOLICITANTE_Descripcion(Me.cboREAVSOLI, Me.cboREAVSOLI.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREAVMUNI.GotFocus, txtREAVCORR.GotFocus, txtREAVBARR.GotFocus, txtREAVMANZ.GotFocus, txtREAVPRED.GotFocus, txtREAVEDIF.GotFocus, txtREAVUNPR.GotFocus, txtREAVNUDO.GotFocus, txtREAVNOMB.GotFocus, txtREAVPRAP.GotFocus, txtREAVSEAP.GotFocus, txtREAVMAIN.GotFocus, txtREAVRADE.GotFocus, txtREAVFEDE.GotFocus, txtREAVFEMU.GotFocus, txtREAVRAMU.GotFocus, txtREAVRAED.GotFocus, txtREAVFEED.GotFocus, txtREAVRADM.GotFocus, txtREAVFEDM.GotFocus, txtREAVFELC.GotFocus, txtREAVOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREAVCLSE.GotFocus, cboREAVVIGE.GotFocus, cboREAVTITR.GotFocus, cboREAVESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTRCACLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboREAVCLSE.SelectedIndexChanged
        Me.lblREAVCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboREAVCLSE), String)
    End Sub
    Private Sub cboTRCAVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboREAVVIGE.SelectedIndexChanged
        Me.lblREAVVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboREAVVIGE), String)
    End Sub
    Private Sub cboREAVTITR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboREAVTITR.SelectedIndexChanged
        Me.lblREAVTITR.Text = CType(fun_Buscar_Lista_Valores_TIPOTRAM_Codigo(Me.cboREAVTITR), String)
    End Sub
    Private Sub cboREAVSOLI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboREAVSOLI.SelectedIndexChanged
        Me.lblREAVSOLI.Text = CType(fun_Buscar_Lista_Valores_SOLICITANTE_Codigo(Me.cboREAVSOLI), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTRCACLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREAVCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboREAVCLSE, Me.cboREAVCLSE.SelectedIndex)
    End Sub
    Private Sub cboTRCAVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREAVVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboREAVVIGE, Me.cboREAVVIGE.SelectedIndex)
    End Sub
    Private Sub cboREAVTITR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREAVTITR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOTRAM_Descripcion(Me.cboREAVTITR, Me.cboREAVTITR.SelectedIndex)
    End Sub
    Private Sub cboTRCAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREAVESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboREAVESTA, Me.cboREAVESTA.SelectedIndex)
    End Sub
    Private Sub cboREAVSOLI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREAVSOLI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_SOLICITANTE_Descripcion(Me.cboREAVSOLI, Me.cboREAVSOLI.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTAPEAVFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREAVRADE.Validated, txtREAVRAMU.Validated, txtREAVRAED.Validated, txtREAVRADM.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        End If

    End Sub

    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREAVMUNI.Validated
        If Me.txtREAVMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREAVMUNI.Text) = True Then
            Me.txtREAVMUNI.Text = fun_Formato_Mascara_3_String(Me.txtREAVMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREAVCORR.Validated
        If Me.txtREAVCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREAVCORR.Text) = True Then
            Me.txtREAVCORR.Text = fun_Formato_Mascara_2_String(Me.txtREAVCORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREAVBARR.Validated
        If Me.txtREAVBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREAVBARR.Text) = True Then
            Me.txtREAVBARR.Text = fun_Formato_Mascara_3_String(Me.txtREAVBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREAVMANZ.Validated
        If Me.txtREAVMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREAVMANZ.Text) = True Then
            Me.txtREAVMANZ.Text = fun_Formato_Mascara_3_String(Me.txtREAVMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREAVPRED.Validated
        If Me.txtREAVPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREAVPRED.Text) = True Then
            Me.txtREAVPRED.Text = fun_Formato_Mascara_5_String(Me.txtREAVPRED.Text)
        End If
    End Sub
    Private Sub txtREAVEDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREAVEDIF.Validated
        If Me.txtREAVEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREAVEDIF.Text) = True Then
            Me.txtREAVEDIF.Text = fun_Formato_Mascara_3_String(Me.txtREAVEDIF.Text)
        End If
    End Sub
    Private Sub txtREAVUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREAVUNPR.Validated
        If Me.txtREAVUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREAVUNPR.Text) = True Then
            Me.txtREAVUNPR.Text = fun_Formato_Mascara_5_String(Me.txtREAVUNPR.Text)
        End If
    End Sub
    Private Sub txtREAVNUDO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREAVNUDO.Validated

        Try
            ' extrae el tercero si ya existe en base de datos
            Dim objdatos1 As New cla_TERCERO
            Dim tbl1 As New DataTable

            tbl1 = objdatos1.fun_Buscar_CODIGO_TERCERO(Trim(Me.txtREAVNUDO.Text))

            If tbl1.Rows.Count > 0 Then

                Me.txtREAVNOMB.Text = Trim(tbl1.Rows(0).Item(5))
                Me.txtREAVPRAP.Text = Trim(tbl1.Rows(0).Item(6))
                Me.txtREAVSEAP.Text = Trim(tbl1.Rows(0).Item(7))

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

    Private Sub dtpREAVFEDE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpREAVFEDE.ValueChanged
        Me.dtpREAVFEDE.Value = fun_fecha()
        Me.txtREAVFEDE.Text = Me.dtpREAVFEDE.Value
    End Sub
    Private Sub dtpREAVFEMU_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpREAVFEMU.ValueChanged
        Me.txtREAVFEMU.Text = Me.dtpREAVFEMU.Value
    End Sub
    Private Sub dtpREAVFEED_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpREAVFEED.ValueChanged
        Me.txtREAVFEED.Text = Me.dtpREAVFEED.Value
    End Sub
    Private Sub dtpREAVFEDM_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpREAVFEDM.ValueChanged
        Me.txtREAVFEDM.Text = Me.dtpREAVFEDM.Value
    End Sub
    Private Sub dtpREAVFELC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpREAVFELC.ValueChanged
        Me.txtREAVFELC.Text = Me.dtpREAVFELC.Value
    End Sub

#End Region

#End Region

End Class