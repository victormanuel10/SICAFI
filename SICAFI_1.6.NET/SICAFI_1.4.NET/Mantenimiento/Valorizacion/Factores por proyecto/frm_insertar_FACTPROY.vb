Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_FACTPROY

    '=========================
    '*** INSERTAR FACTORES ***
    '=========================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraFACTORES)

        Me.txtFAPRFAIN.Text = "1.0000"
        Me.txtFAPRFAFI.Text = "1.0000"
        Me.txtFAPRFAAP.Text = "1.0000"
        Me.lblFAPRDEPA.Text = ""
        Me.lblFAPRMUNI.Text = ""
        Me.lblFAPRCLSE.Text = ""
        Me.lblFAPRPROY.Text = ""
        Me.lblFAPRTIVA.Text = ""
        Me.lblFAPRVARI.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_FACTPROY

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_FACTPROY(Me.cboFAPRDEPA, _
                                                                                                Me.cboFAPRMUNI, _
                                                                                                Me.cboFAPRCLSE, _
                                                                                                Me.cboFAPRPROY, _
                                                                                                Me.cboFAPRTIVA, _
                                                                                                Me.cboFAPRVARI)

            Dim objVerifica As New cla_Verificar_Dato

            Dim boFACTPROY As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFAPRPROY)
            Dim boFACTTIVA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFAPRTIVA)
            Dim boFACTVARI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFAPRVARI)
            Dim boFACTDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtFAPRDESC)
            Dim boFACTFAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtFAPRFAIN)
            Dim boFACTFAFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtFAPRFAFI)
            Dim boFACTFACT As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtFAPRFAAP)
            Dim boFACTESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFAPRESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boFACTPROY = True And _
               boFACTTIVA = True And _
               boFACTVARI = True And _
               boFACTDESC = True And _
               boFACTFAIN = True And _
               boFACTFAFI = True And _
               boFACTFACT = True And _
               boFACTESTA = True Then

                Dim objdatos22 As New cla_FACTPROY

                If (objdatos22.fun_Insertar_MANT_FACTPROY(Me.cboFAPRDEPA.SelectedValue, _
                                                          Me.cboFAPRMUNI.SelectedValue, _
                                                          Me.cboFAPRCLSE.SelectedValue, _
                                                          Me.cboFAPRPROY.SelectedValue, _
                                                          Me.cboFAPRTIVA.SelectedValue, _
                                                          Me.cboFAPRVARI.SelectedValue, _
                                                          Me.txtFAPRDESC.Text, _
                                                          Me.txtFAPRFAIN.Text, _
                                                          Me.txtFAPRFAFI.Text, _
                                                          Me.txtFAPRFAAP.Text, _
                                                          Me.cboFAPRESTA.SelectedValue, _
                                                          Me.chkFAPRAPRA.Checked)) = True Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboFAPRTIVA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboFAPRTIVA.Focus()
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
        Me.cboFAPRDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_CONCEPTO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboFOMUDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFAPRDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboFAPRDEPA, Me.cboFAPRDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOMUMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFAPRMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboFAPRMUNI, Me.cboFAPRMUNI.SelectedIndex, Me.cboFAPRDEPA)
        End If
    End Sub
    Private Sub cboFOMUCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFAPRCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboFAPRCLSE, Me.cboFAPRCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboFACTPROY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFAPRPROY.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_PROYECTO_Descripcion(Me.cboFAPRPROY, Me.cboFAPRPROY.SelectedIndex, Me.cboFAPRDEPA, Me.cboFAPRMUNI, Me.cboFAPRCLSE)
        End If
    End Sub
    Private Sub cboFACTTIVA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFAPRTIVA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOVARI_Descripcion(Me.cboFAPRTIVA, Me.cboFAPRTIVA.SelectedIndex)
        End If
    End Sub
    Private Sub cboFACTVARI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFAPRVARI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VARIABLES_X_TIPOVARI_Descripcion(Me.cboFAPRVARI, Me.cboFAPRVARI.SelectedIndex, Me.cboFAPRTIVA)
        End If
    End Sub
    Private Sub cboFACTESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFAPRESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboFAPRESTA, Me.cboFAPRESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFAPRDESC.KeyPress, cboFAPRESTA.KeyPress, cboFAPRTIVA.KeyPress, txtFAPRFAIN.KeyPress, txtFAPRFAFI.KeyPress, txtFAPRFAAP.KeyPress, cboFAPRPROY.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFAPRDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFAPRESTA.GotFocus, cboFAPRTIVA.GotFocus, cboFAPRPROY.GotFocus, cboFAPRDEPA.GotFocus, cboFAPRMUNI.GotFocus, cboFAPRCLSE.GotFocus, cboFAPRVARI.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboFOMUDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFAPRDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboFAPRDEPA, Me.cboFAPRDEPA.SelectedIndex)
    End Sub
    Private Sub cboFOMUMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFAPRMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboFAPRMUNI, Me.cboFAPRMUNI.SelectedIndex, Me.cboFAPRDEPA)
    End Sub
    Private Sub cboFOMUCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFAPRCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboFAPRCLSE, Me.cboFAPRCLSE.SelectedIndex)
    End Sub
    Private Sub cboFACTPROY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFAPRPROY.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_PROYECTO_Descripcion(Me.cboFAPRPROY, Me.cboFAPRPROY.SelectedIndex, Me.cboFAPRDEPA, Me.cboFAPRMUNI, Me.cboFAPRCLSE)
    End Sub
    Private Sub cboFACTTIVA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFAPRTIVA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOVARI_Descripcion(Me.cboFAPRTIVA, Me.cboFAPRTIVA.SelectedIndex)
    End Sub
    Private Sub cboFACTVARI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFAPRVARI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VARIABLES_X_TIPOVARI_Descripcion(Me.cboFAPRVARI, Me.cboFAPRVARI.SelectedIndex, Me.cboFAPRTIVA)
    End Sub
    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFAPRESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboFAPRESTA, cboFAPRESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboFOMUDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFAPRDEPA.SelectedIndexChanged
        Me.lblFAPRDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboFAPRDEPA), String)

        Me.cboFAPRMUNI.DataSource = New DataTable
        Me.lblFAPRMUNI.Text = ""
    End Sub
    Private Sub cboFOMUMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFAPRMUNI.SelectedIndexChanged
        Me.lblFAPRMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboFAPRDEPA, Me.cboFAPRMUNI), String)
    End Sub
    Private Sub cboFACTPROY_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFAPRPROY.SelectedIndexChanged
        Me.lblFAPRPROY.Text = CType(fun_Buscar_Lista_Valores_PROYECTO_Codigo(Me.cboFAPRDEPA, Me.cboFAPRMUNI, Me.cboFAPRCLSE, Me.cboFAPRPROY), String)
    End Sub
    Private Sub cboFACTCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFAPRCLSE.SelectedIndexChanged
        Me.lblFAPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboFAPRCLSE), String)
    End Sub
    Private Sub cboFACTTIVA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFAPRTIVA.SelectedIndexChanged
        Me.lblFAPRTIVA.Text = CType(fun_Buscar_Lista_Valores_TIPOVARI_Codigo(Me.cboFAPRTIVA), String)

        Me.cboFAPRVARI.DataSource = New DataTable
        Me.lblFAPRVARI.Text = ""
    End Sub
    Private Sub cboFACTVARI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFAPRVARI.SelectedIndexChanged
        Me.lblFAPRVARI.Text = CType(fun_Buscar_Lista_Valores_VARIABLE_Codigo(Me.cboFAPRTIVA, Me.cboFAPRVARI), String)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFACTFAIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFAPRFAIN.Validated, txtFAPRFAFI.Validated, txtFAPRFAAP.Validated

        If Trim(sender.text) = "" Then
            sender.text = "0.0000"
        Else
            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtFAPRFAIN.Text) = True Then
                Me.txtFAPRFAIN.Text = fun_Formato_Decimal_4_Decimales(Me.txtFAPRFAIN.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtFAPRFAFI.Text) = True Then
                Me.txtFAPRFAFI.Text = fun_Formato_Decimal_4_Decimales(Me.txtFAPRFAFI.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtFAPRFAAP.Text) = True Then
                Me.txtFAPRFAAP.Text = fun_Formato_Decimal_4_Decimales(Me.txtFAPRFAAP.Text)
            End If

        End If

    End Sub

#End Region

#Region "CheckedChanged"

    Private Sub chkFACTAPRA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFAPRAPRA.CheckedChanged

        If Me.chkFAPRAPRA.Checked = True Then

            Me.txtFAPRFAIN.Text = "1.0000"
            Me.txtFAPRFAFI.Text = "1.0000"
            Me.txtFAPRFAAP.Text = "1.0000"

            Me.txtFAPRFAIN.Enabled = False
            Me.txtFAPRFAFI.Enabled = False
            Me.txtFAPRFAAP.Enabled = False

        ElseIf Me.chkFAPRAPRA.Checked = False Then

            Me.txtFAPRFAIN.Enabled = True
            Me.txtFAPRFAFI.Enabled = True
            Me.txtFAPRFAAP.Enabled = True

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