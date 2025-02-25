Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_SEGUDEST

    '==================================
    '*** INSERTAR SEGUN DESTINACION ***
    '==================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraSEGUDEST)

        Me.lblSEDEDEST.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_SEGUDEST

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_SEGUDEST(Me.cboSEDEDEST, txtSEDECODI)

            Dim objVerifica As New cla_Verificar_Dato

            Dim boSEDEDEST As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboSEDEDEST)
            Dim boSEDECODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtSEDECODI)
            Dim boSEDEDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtSEDEDESC)
            Dim boSEDEESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboSEDEESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And boSEDEDEST = True And boSEDECODI = True And boSEDEDESC = True And boSEDEESTA = True Then

                Dim objdatos22 As New cla_SEGUDEST

                If (objdatos22.fun_Insertar_MANT_SEGUDEST(Me.cboSEDEDEST.SelectedValue, _
                                                          Me.txtSEDECODI.Text, _
                                                          Me.txtSEDEDESC.Text, _
                                                          Me.cboSEDEESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboSEDEDEST.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboSEDEDEST.Focus()
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
        Me.txtSEDECODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_SEGUDEST_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboSEDEDEST_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSEDEDEST.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DESTINACION_Descripcion(Me.cboSEDEDEST, Me.cboSEDEDEST.SelectedIndex)
        End If
    End Sub
    Private Sub cboSEDEESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSEDEESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboSEDEESTA, Me.cboSEDEESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSEDECODI.KeyPress, txtSEDEDESC.KeyPress, cboSEDEESTA.KeyPress, cboSEDEDEST.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSEDECODI.GotFocus, txtSEDEDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSEDEESTA.GotFocus, cboSEDEDEST.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboSEDEDEST_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSEDEDEST.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DESTINACION_Descripcion(Me.cboSEDEDEST, Me.cboSEDEDEST.SelectedIndex)
    End Sub
    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSEDEESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboSEDEESTA, cboSEDEESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboSEDEDEST_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSEDEDEST.SelectedIndexChanged
        Me.lblSEDEDEST.Text = CType(fun_Buscar_Lista_Valores_DESTINACION_Codigo(Me.cboSEDEDEST), String)
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