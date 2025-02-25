Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_UAUPLPA

    '=====================================================
    '*** INSERTAR UNIDAD DE ACTUACION DEL PLAN PARCIAL ***
    '=====================================================

#Region "VARIABLES"

    Dim vl_inCABENURE As Integer = 0
    Dim vl_stCABEFERE As String = ""

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraUAUPLPA)
        Me.nudUAPPUAU.Value = 0

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' consulta la resolucion y fecha
            Dim obPLANPARC As New cla_PLANPARC
            Dim dtPLANPARC As New DataTable

            dtPLANPARC = obPLANPARC.fun_Buscar_ID_MANT_PLANPARC(Me.cboUAPPPLPA.SelectedValue)

            If dtPLANPARC.Rows.Count > 0 Then

                vl_inCABENURE = dtPLANPARC.Rows(0).Item("PLPANURE")
                vl_stCABEFERE = dtPLANPARC.Rows(0).Item("PLPAFERE")

            End If

            ' instancia la clase
            Dim objdatos As New cla_UAUPLPA

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_UAUPLPA(CInt(vl_inCABENURE), CStr(Trim(vl_stCABEFERE)), Me.nudUAPPUAU)

            Dim objVerifica As New cla_Verificar_Dato

            Dim boCABEPLPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboUAPPPLPA)
            Dim boCABEUAU As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.nudUAPPUAU)
            Dim boPLPAESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboUAPPESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
                boCABEPLPA = True And _
                boCABEUAU = True And _
                boPLPAESTA = True Then

                Dim objdatos22 As New cla_UAUPLPA

                If (objdatos22.fun_Insertar_MANT_UAUPLPA(vl_inCABENURE, _
                                                         Trim(vl_stCABEFERE), _
                                                         Me.nudUAPPUAU.Value, _
                                                         Me.cboUAPPESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboUAPPPLPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboUAPPPLPA.Focus()
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
        Me.cboUAPPPLPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_UAUPLPA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboCABEPLPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboUAPPPLPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_PLAN_PARCIAL(Me.cboUAPPPLPA, Me.cboUAPPPLPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboCABEESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboUAPPESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboUAPPESTA, Me.cboUAPPESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboUAPPPLPA.KeyPress, cboUAPPESTA.KeyPress, nudUAPPUAU.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUAPPESTA.GotFocus, cboUAPPPLPA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub


#End Region

#Region "Click"

    Private Sub cboCABEPLPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUAPPPLPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_PLAN_PARCIAL(Me.cboUAPPPLPA, Me.cboUAPPPLPA.SelectedIndex)
    End Sub
    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUAPPESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboUAPPESTA, cboUAPPESTA.SelectedIndex)
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