Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_VALIRETI

    '====================================
    '*** INSERTAR VALIDACIÓN RETIRADA ***
    '====================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraVALIRETI)

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_VALIRETI

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_VALIRETI(Me.txtVARECODI)

            Dim objVerifica As New cla_Verificar_Dato

            Dim boMOLICODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtVARECODI)
            Dim boMOLIDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtVAREDESC)
            Dim boMOLIESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVAREESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And boMOLICODI = True And boMOLIDESC = True And boMOLIESTA = True Then

                Dim objdatos22 As New cla_VALIRETI

                If (objdatos22.fun_Insertar_MANT_VALIRETI(Me.txtVARECODI.Text, Me.txtVAREDESC.Text, Me.cboVAREESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.txtVARECODI.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.txtVARECODI.Focus()
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
        Me.txtVARECODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_VALIRETI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVARECODI.KeyPress, txtVAREDESC.KeyPress, cboVAREESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboESTRESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVAREESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboVAREESTA, Me.cboVAREESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVARECODI.GotFocus, txtVAREDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAREESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub


#End Region

#Region "Click"

    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVAREESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboVAREESTA, cboVAREESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtCAPRCODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVARECODI.Validated

        If fun_Verificar_Campos_Llenos_1_DATOS(Me.txtVARECODI.Text) = True Then

            Dim obVerifica As New cla_Verificar_Dato
            If obVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtVARECODI) = True Then

                Dim obDatos As New cla_VALIRETI
                obDatos.fun_Verifica_llave_Primaria_VALIRETI(Me.txtVARECODI)
            End If

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