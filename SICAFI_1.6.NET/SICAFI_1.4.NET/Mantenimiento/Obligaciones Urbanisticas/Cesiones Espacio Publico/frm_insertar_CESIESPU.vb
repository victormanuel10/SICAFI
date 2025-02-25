Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_CESIESPU

    '=======================================
    '*** INSERTAR CESION ESPACIO PUBLICO ***
    '=======================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtCEEPDEVI.Text = ""
        Me.txtCEEPDESC.Text = ""
        Me.txtCEEPARCE.Text = ""
        Me.txtCEEPOTUS.Text = ""
        Me.txtCEEPAMCE.Text = ""
        Me.cboCEEPESTA.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_CESIESPU

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_CESIESPU(Me.txtCEEPDEVI)

            Dim objVerifica As New cla_Verificar_Dato

            Dim boCEEPDEVI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEEPDEVI)
            Dim boCEEPDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCEEPDESC)
            Dim boCEEPARCE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEEPARCE)
            Dim boCEEPOTUS As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEEPOTUS)
            Dim boCEEPAMCE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEEPAMCE)
            Dim boCEEPESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCEEPESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
                boCEEPDEVI = True And _
                boCEEPDESC = True And _
                boCEEPARCE = True And _
                boCEEPOTUS = True And _
                boCEEPAMCE = True And _
                boCEEPESTA = True Then

                Dim objdatos22 As New cla_CESIESPU

                If (objdatos22.fun_Insertar_MANT_CESIESPU(Me.txtCEEPDEVI.Text, _
                                                          Me.txtCEEPDESC.Text, _
                                                          Me.txtCEEPARCE.Text, _
                                                          Me.txtCEEPOTUS.Text, _
                                                          Me.txtCEEPAMCE.Text, _
                                                          Me.cboCEEPESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.txtCEEPDEVI.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.txtCEEPDEVI.Focus()
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
        Me.txtCEEPDEVI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_CESIESPU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboCEEPESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCEEPESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCEEPESTA, Me.cboCEEPESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCEEPDEVI.KeyPress, txtCEEPDESC.KeyPress, cboCEEPESTA.KeyPress, txtCEEPARCE.KeyPress, txtCEEPOTUS.KeyPress, txtCEEPAMCE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEEPDEVI.GotFocus, txtCEEPDESC.GotFocus, txtCEEPARCE.GotFocus, txtCEEPOTUS.GotFocus, txtCEEPAMCE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCEEPESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub


#End Region

#Region "Click"

    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCEEPESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboCEEPESTA, cboCEEPESTA.SelectedIndex)
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