Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_CABEUAU

    '============================================================
    '*** INSERTAR CARGAS Y BENEFICIOS POR UNIDAD DE ACTUACION ***
    '============================================================

#Region "VARIABLES"

    Dim vl_inCABENURE As Integer = 0
    Dim vl_stCABEFERE As String = ""

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraUAUPLPA)

    End Sub
    Private Sub pro_ObtenerNroResolucionyFecha()

        Try
            If Trim(Me.cboCBAUPLPA.Text) <> "" Then

                ' consulta la resolucion y fecha
                Dim obPLANPARC As New cla_PLANPARC
                Dim dtPLANPARC As New DataTable

                dtPLANPARC = obPLANPARC.fun_Buscar_ID_MANT_PLANPARC(Me.cboCBAUPLPA.SelectedValue)

                If dtPLANPARC.Rows.Count > 0 Then

                    vl_inCABENURE = dtPLANPARC.Rows(0).Item("PLPANURE")
                    vl_stCABEFERE = dtPLANPARC.Rows(0).Item("PLPAFERE")

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' consulta la resolucion y fecha
            Dim obPLANPARC As New cla_PLANPARC
            Dim dtPLANPARC As New DataTable

            dtPLANPARC = obPLANPARC.fun_Buscar_ID_MANT_PLANPARC(Me.cboCBAUPLPA.SelectedValue)

            If dtPLANPARC.Rows.Count > 0 Then

                vl_inCABENURE = dtPLANPARC.Rows(0).Item("PLPANURE")
                vl_stCABEFERE = dtPLANPARC.Rows(0).Item("PLPAFERE")

            End If

            ' instancia la clase
            Dim objdatos As New cla_CABEUAU

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_CABEUAU(CInt(vl_inCABENURE), CStr(Trim(vl_stCABEFERE)), Me.cboCBUAUAPP, Me.cboCBUACBPP)

            Dim objVerifica As New cla_Verificar_Dato

            Dim boCABEPLPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCBAUPLPA)
            Dim boCABEUAPP As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCBUAUAPP)
            Dim boCABECBPP As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCBUACBPP)
            Dim boCBUAVALO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCBUAVALO)
            Dim boCABEESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCBUAESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
                boCABEPLPA = True And _
                boCABEUAPP = True And _
                boCABECBPP = True And _
                boCBUAVALO = True And _
                boCABEESTA = True Then

                Dim objdatos22 As New cla_CABEUAU

                If (objdatos22.fun_Insertar_MANT_CABEUAU(vl_inCABENURE, _
                                                         Trim(vl_stCABEFERE), _
                                                         Me.cboCBUAUAPP.SelectedValue, _
                                                         Me.cboCBUACBPP.SelectedValue, _
                                                         Me.txtCBUAVALO.Text, _
                                                         Me.cboCBUAESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboCBAUPLPA.Focus()
                        Me.Close()
                    Else
                        'pro_LimpiarCampos()
                        Me.cboCBAUPLPA.Focus()
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
        Me.cboCBAUPLPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_CABEUAU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboCABEPLPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCBAUPLPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_PLAN_PARCIAL(Me.cboCBAUPLPA, Me.cboCBAUPLPA.SelectedIndex)

            Me.cboCBUAUAPP.DataSource = New DataTable
        End If
    End Sub
    Private Sub cboCABEUAPP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCBUAUAPP.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            pro_ObtenerNroResolucionyFecha()
            fun_Cargar_ComboBox_Con_Datos_Activos_UAU_X_PLANPARC_Descripcion(Me.cboCBUAUAPP, Me.cboCBUAUAPP.SelectedIndex, Me.cboCBAUPLPA, vl_inCABENURE, vl_stCABEFERE)
        End If
    End Sub
    Private Sub cboCBUACBPP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCBUACBPP.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CABEPLPA_Descripcion(Me.cboCBUACBPP, Me.cboCBUACBPP.SelectedIndex)
        End If
    End Sub
    Private Sub cboCABEESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCBUAESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCBUAESTA, Me.cboCBUAESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCBAUPLPA.KeyPress, cboCBUAESTA.KeyPress, cboCBUAUAPP.KeyPress, cboCBUACBPP.KeyPress, txtCBUAVALO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCBUAVALO.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCBUAESTA.GotFocus, cboCBAUPLPA.GotFocus, cboCBUACBPP.GotFocus, cboCBUAUAPP.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboCABEPLPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCBAUPLPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_PLAN_PARCIAL(Me.cboCBAUPLPA, Me.cboCBAUPLPA.SelectedIndex)
        Me.cboCBUAUAPP.DataSource = New DataTable
    End Sub
    Private Sub cboCBUAUAPP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCBUAUAPP.Click
        pro_ObtenerNroResolucionyFecha()
        fun_Cargar_ComboBox_Con_Datos_Activos_UAU_X_PLANPARC_Descripcion(Me.cboCBUAUAPP, Me.cboCBUAUAPP.SelectedIndex, Me.cboCBAUPLPA, vl_inCABENURE, vl_stCABEFERE)
    End Sub
    Private Sub cboCBUACBPP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCBUACBPP.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CABEPLPA_Descripcion(Me.cboCBUACBPP, Me.cboCBUACBPP.SelectedIndex)
    End Sub
    Private Sub cboCBUAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCBUAESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboCBUAESTA, cboCBUAESTA.SelectedIndex)
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