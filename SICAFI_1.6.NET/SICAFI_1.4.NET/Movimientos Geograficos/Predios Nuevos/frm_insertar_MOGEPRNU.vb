Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_MOGEPRNU

    '===============================
    '*** INSERTAR PREDIOS NUEVOS ***
    '===============================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer
    Dim inLEVASECU As Integer
    Dim stLEVANUDO As String

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inSECU As Integer)
        inLEVASECU = inSECU

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub
    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer)
        inID_REGISTRO = inIDRE
        inLEVASECU = inSECU

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtMGPNMUNI.Text = "266"
        Me.txtMGPNCORR.Text = "01"
        Me.txtMGPNBARR.Text = ""
        Me.txtMGPNMANZ.Text = ""
        Me.txtMGPNPRED.Text = ""
        Me.txtMGPNNUFI.Text = "0"
        Me.txtMGPNNUOV.Text = "0"

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_MOGEPRNU
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_CODIGO_X_MOGEPRNU(inLEVASECU, inID_REGISTRO)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraCEDUCATA.Text = "MODIFICAR PREDIOS NUEVOS"

                    Me.txtMGPNMUNI.Text = Trim(tbl.Rows(0).Item("MGPNMUNI"))
                    Me.txtMGPNCORR.Text = Trim(tbl.Rows(0).Item("MGPNCORR"))
                    Me.txtMGPNBARR.Text = Trim(tbl.Rows(0).Item("MGPNBARR"))
                    Me.txtMGPNMANZ.Text = Trim(tbl.Rows(0).Item("MGPNMANZ"))
                    Me.txtMGPNPRED.Text = Trim(tbl.Rows(0).Item("MGPNPRED"))

                    Dim objdatos1 As New cla_CLASSECT

                    Me.cboMGPNCLSE.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CLASSECT
                    Me.cboMGPNCLSE.DisplayMember = "CLSEDESC"
                    Me.cboMGPNCLSE.ValueMember = "CLSECODI"

                    Me.cboMGPNCLSE.SelectedValue = tbl.Rows(0).Item("MGPNCLSE")

                    Dim objdatos2 As New cla_CAUSACTO

                    Me.cboMGPNCAAC.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CAUSACTO
                    Me.cboMGPNCAAC.DisplayMember = "CAACDESC"
                    Me.cboMGPNCAAC.ValueMember = "CAACCODI"

                    Me.cboMGPNCAAC.SelectedValue = tbl.Rows(0).Item("MGPNCAAC")

                    Me.txtMGPNNUFI.Text = Trim(tbl.Rows(0).Item("MGPNNUFI"))
                    Me.txtMGPNNUOV.Text = Trim(tbl.Rows(0).Item("MGPNNUOV"))

                    Me.lblMGPNCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboMGPNCLSE), String)
                    Me.lblMGPNCAAC.Text = CType(fun_Buscar_Lista_Valores_CAUSACTO_Codigo(Me.cboMGPNCAAC), String)

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraCEDUCATA.Text = "INSERTAR PREDIOS NUEVOS"

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' inserta el registro
            If boINSERTAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boMGPNMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMGPNMUNI)
                Dim boMGPNCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMGPNCORR)
                Dim boMGPNBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMGPNBARR)
                Dim boMGPNMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMGPNMANZ)
                Dim boMGPNPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMGPNPRED)
                Dim boMGPNCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMGPNCLSE)
                Dim boMGPNCAAC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMGPNCAAC)
                Dim boMGPNNUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMGPNNUFI)
                Dim boMGPNNUOV As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMGPNNUOV)

                ' verifica los datos del formulario 
                If boMGPNMUNI = True And _
                   boMGPNCORR = True And _
                   boMGPNBARR = True And _
                   boMGPNMANZ = True And _
                   boMGPNPRED = True And _
                   boMGPNCAAC = True And _
                   boMGPNCLSE = True And _
                   boMGPNNUFI = True And _
                   boMGPNNUOV = True Then

                    Dim stMGPNEDIF As String = "000"
                    Dim stMGPNUNPR As String = "00000"

                    Dim objdatos22 As New cla_MOGEPRNU

                    If (objdatos22.fun_Insertar_MOGEPRNU(inLEVASECU, _
                                                         Me.txtMGPNMUNI.Text, _
                                                         Me.txtMGPNCORR.Text, _
                                                         Me.txtMGPNBARR.Text, _
                                                         Me.txtMGPNMANZ.Text, _
                                                         Me.txtMGPNPRED.Text, _
                                                         stMGPNEDIF, _
                                                         stMGPNUNPR, _
                                                         Me.cboMGPNCLSE.SelectedValue, _
                                                         Me.cboMGPNCAAC.SelectedValue, _
                                                         Me.txtMGPNNUFI.Text, _
                                                         Me.txtMGPNNUOV.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            Me.txtMGPNMUNI.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            Me.txtMGPNMUNI.Focus()
                        End If
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boMGPNMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMGPNMUNI)
                Dim boMGPNCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMGPNCORR)
                Dim boMGPNBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMGPNBARR)
                Dim boMGPNMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMGPNMANZ)
                Dim boMGPNPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMGPNPRED)
                Dim boMGPNCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMGPNCLSE)
                Dim boMGPNCAAC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMGPNCAAC)
                Dim boMGPNNUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMGPNNUFI)
                Dim boMGPNNUOV As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMGPNNUOV)

                ' verifica los datos del formulario 
                If boMGPNMUNI = True And _
                   boMGPNCORR = True And _
                   boMGPNBARR = True And _
                   boMGPNMANZ = True And _
                   boMGPNPRED = True And _
                   boMGPNCLSE = True And _
                   boMGPNCAAC = True And _
                   boMGPNNUFI = True And _
                   boMGPNNUOV = True Then

                    Dim stMGPNEDIF As String = "000"
                    Dim stMGPNUNPR As String = "00000"

                    Dim objdatos22 As New cla_MOGEPRNU

                    If (objdatos22.fun_Actualizar_MOGEPRNU(inID_REGISTRO, _
                                                           inLEVASECU, _
                                                           Me.txtMGPNMUNI.Text, _
                                                           Me.txtMGPNCORR.Text, _
                                                           Me.txtMGPNBARR.Text, _
                                                           Me.txtMGPNMANZ.Text, _
                                                           Me.txtMGPNPRED.Text, _
                                                           stMGPNEDIF, _
                                                           stMGPNUNPR, _
                                                           Me.cboMGPNCLSE.SelectedValue, _
                                                           Me.cboMGPNCAAC.SelectedValue, _
                                                           Me.txtMGPNNUFI.Text, _
                                                           Me.txtMGPNNUOV.Text)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtMGPNMUNI.Focus()
                        Me.Close()
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
        Me.txtMGPNMUNI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMGPNMUNI.KeyPress, txtMGPNCORR.KeyPress, txtMGPNBARR.KeyPress, txtMGPNMANZ.KeyPress, txtMGPNPRED.KeyPress, txtMGPNNUFI.KeyPress, txtMGPNNUOV.KeyPress, cboMGPNCLSE.KeyPress, cboMGPNCAAC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboOBINCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMGPNCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboMGPNCLSE, Me.cboMGPNCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOTCCAAC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMGPNCAAC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CAUSACTO_Descripcion(Me.cboMGPNCAAC, Me.cboMGPNCAAC.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboOBINCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMGPNCLSE.SelectedIndexChanged
        Me.lblMGPNCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboMGPNCLSE), String)
    End Sub
    Private Sub cboFOTCCAAC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMGPNCAAC.SelectedIndexChanged
        Me.lblMGPNCAAC.Text = CType(fun_Buscar_Lista_Valores_CAUSACTO_Codigo(Me.cboMGPNCAAC), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboOBINCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMGPNCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboMGPNCLSE, Me.cboMGPNCLSE.SelectedIndex)
    End Sub
    Private Sub cboFOTCCAAC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMGPNCAAC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CAUSACTO_Descripcion(Me.cboMGPNCAAC, Me.cboMGPNCAAC.SelectedIndex)
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMGPNMUNI.GotFocus, txtMGPNCORR.GotFocus, txtMGPNBARR.GotFocus, txtMGPNMANZ.GotFocus, txtMGPNPRED.GotFocus, txtMGPNNUFI.GotFocus, txtMGPNNUOV.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtMGPNNUFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMGPNNUFI.Validated, txtMGPNNUOV.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        End If

    End Sub
    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMGPNMUNI.Validated
        If Me.txtMGPNMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMGPNMUNI.Text) = True Then
            Me.txtMGPNMUNI.Text = fun_Formato_Mascara_3_String(Me.txtMGPNMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMGPNCORR.Validated
        If Me.txtMGPNCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMGPNCORR.Text) = True Then
            Me.txtMGPNCORR.Text = fun_Formato_Mascara_2_String(Me.txtMGPNCORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMGPNBARR.Validated
        If Me.txtMGPNBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMGPNBARR.Text) = True Then
            Me.txtMGPNBARR.Text = fun_Formato_Mascara_3_String(Me.txtMGPNBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMGPNMANZ.Validated
        If Me.txtMGPNMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMGPNMANZ.Text) = True Then
            Me.txtMGPNMANZ.Text = fun_Formato_Mascara_3_String(Me.txtMGPNMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMGPNPRED.Validated
        If Me.txtMGPNPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMGPNPRED.Text) = True Then
            Me.txtMGPNPRED.Text = fun_Formato_Mascara_5_String(Me.txtMGPNPRED.Text)
        End If
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

#End Region

End Class