Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_CARGBENE

    '=====================================================
    '*** INSERTAR CARGAS Y BENEFICIOS DEL PLAN PARCIAL ***
    '=====================================================

#Region "VARIABLES"

    Dim vl_inCABENURE As Integer = 0
    Dim vl_stCABEFERE As String = ""

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraCARGBENE)

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' consulta la resolucion y fecha
            Dim obPLANPARC As New cla_PLANPARC
            Dim dtPLANPARC As New DataTable

            dtPLANPARC = obPLANPARC.fun_Buscar_ID_MANT_PLANPARC(Me.cboCABEPLPA.SelectedValue)

            If dtPLANPARC.Rows.Count > 0 Then

                vl_inCABENURE = dtPLANPARC.Rows(0).Item("PLPANURE")
                vl_stCABEFERE = dtPLANPARC.Rows(0).Item("PLPAFERE")

            End If

            ' instancia la clase
            Dim objdatos As New cla_CARGBENE

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_CARGBENE(CInt(vl_inCABENURE), CStr(Trim(vl_stCABEFERE)), Me.txtCABEUAU)

            Dim objVerifica As New cla_Verificar_Dato

            Dim boCABEPLPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCABEPLPA)
            Dim boCABEUAU As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCABEUAU)
            Dim boPLPADESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCABEDESC)
            Dim boCABECEEP As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCABECEEP)
            Dim boCABECOEP As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCABECOEP)
            Dim boCABECEVI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCABECEVI)
            Dim boCABECOVI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCABECOVI)
            Dim boCABECOEQ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCABECOEQ)
            Dim boCABECVAI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCABECVAI)
            Dim boCABECEDI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCABECEDI)
            Dim boPLPAESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCABEESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
                boCABEPLPA = True And _
                boPLPADESC = True And _
                boCABECEEP = True And _
                boCABECOEP = True And _
                boCABECEVI = True And _
                boCABECOVI = True And _
                boCABECOEQ = True And _
                boCABECVAI = True And _
                boCABECEDI = True And _
                boPLPAESTA = True Then

                Dim objdatos22 As New cla_CARGBENE

                If (objdatos22.fun_Insertar_MANT_CARGBENE(vl_inCABENURE, _
                                                          Trim(vl_stCABEFERE), _
                                                          Me.txtCABEUAU.Text, _
                                                          Me.txtCABEDESC.Text, _
                                                          Me.txtCABECEEP.Text, _
                                                          Me.txtCABECOEP.Text, _
                                                          Me.txtCABECEVI.Text, _
                                                          Me.txtCABECOVI.Text, _
                                                          Me.txtCABECOEQ.Text, _
                                                          Me.txtCABECVAI.Text, _
                                                          Me.txtCABECEDI.Text, _
                                                          Me.cboCABEESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboCABEPLPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboCABEPLPA.Focus()
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
        Me.txtCABEUAU.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_CARGBENE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboCABEPLPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCABEPLPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_PLAN_PARCIAL(Me.cboCABEPLPA, Me.cboCABEPLPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboCABEESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCABEESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCABEESTA, Me.cboCABEESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCABEPLPA.KeyPress, txtCABEUAU.KeyPress, txtCABEDESC.KeyPress, txtCABECEEP.KeyPress, txtCABECEVI.KeyPress, txtCABECOEP.KeyPress, txtCABECOEQ.KeyPress, txtCABECOVI.KeyPress, cboCABEESTA.KeyPress, txtCABECVAI.KeyPress, txtCABECEDI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCABEUAU.GotFocus, txtCABEDESC.GotFocus, txtCABECEEP.GotFocus, txtCABECEVI.GotFocus, txtCABECOEP.GotFocus, txtCABECOEQ.GotFocus, txtCABECOVI.GotFocus, txtCABECVAI.GotFocus, txtCABECEDI.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCABEESTA.GotFocus, cboCABEPLPA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub


#End Region

#Region "Click"

    Private Sub cboCABEPLPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCABEPLPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_PLAN_PARCIAL(Me.cboCABEPLPA, Me.cboCABEPLPA.SelectedIndex)
    End Sub
    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCABEESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboCABEESTA, cboCABEESTA.SelectedIndex)
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