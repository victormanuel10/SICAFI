Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_VARIABLE

    '=========================
    '*** INSERTAR VARIABLE ***
    '=========================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraVARIABLE)

        Me.lblVARITIVA.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_VARIABLE

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_VARIABLE(Me.cboVARITIVA, txtVARICODI)

            Dim objVerifica As New cla_Verificar_Dato

            Dim boVARITIIM As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVARITIVA)
            Dim boVARICODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtVARICODI)
            Dim boVARIDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtVARIDESC)
            Dim boVARIESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVARIESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And boVARITIIM = True And boVARICODI = True And boVARIDESC = True And boVARIESTA = True Then

                Dim objdatos22 As New cla_VARIABLE

                If (objdatos22.fun_Insertar_MANT_VARIABLE(Me.cboVARITIVA.SelectedValue, _
                                                          Me.txtVARICODI.Text, _
                                                          Me.txtVARIDESC.Text, _
                                                          Me.cboVARIESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboVARITIVA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboVARITIVA.Focus()
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
        Me.txtVARICODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_VARIABLE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboVARITIIM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVARITIVA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOVARI_Descripcion(Me.cboVARITIVA, Me.cboVARITIVA.SelectedIndex)
        End If
    End Sub
    Private Sub cboVARIESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVARIESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboVARIESTA, Me.cboVARIESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVARICODI.KeyPress, txtVARIDESC.KeyPress, cboVARIESTA.KeyPress, cboVARITIVA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVARICODI.GotFocus, txtVARIDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVARIESTA.GotFocus, cboVARITIVA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboVARITIIM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVARITIVA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOVARI_Descripcion(Me.cboVARITIVA, Me.cboVARITIVA.SelectedIndex)
    End Sub
    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVARIESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboVARIESTA, cboVARIESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboVARITIIM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVARITIVA.SelectedIndexChanged
        Me.lblVARITIVA.Text = CType(fun_Buscar_Lista_Valores_TIPOVARI_Codigo(Me.cboVARITIVA), String)
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