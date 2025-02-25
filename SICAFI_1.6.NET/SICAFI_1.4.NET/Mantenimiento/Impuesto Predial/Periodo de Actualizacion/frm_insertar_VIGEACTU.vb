Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_VIGEACTU

    '=======================================
    '*** INSERTAR VIGENVIA ACTUALIZACIÓN ***
    '=======================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraVIGEACTU)

        Me.lblVIACDEPA.Text = ""
        Me.lblVIACMUNI.Text = ""
        Me.lblVIACCLSE.Text = ""
        Me.lblVIACVIAC.Text = ""

        Me.txtVIACPOIN.Text = "1.00"

        Me.rbdVIACACTU.Checked = True

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_VIGEACTU

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_VIGEACTU(Me.cboVIACDEPA, _
                                                                                           Me.cboVIACMUNI, _
                                                                                           Me.cboVIACCLSE, _
                                                                                           Me.txtVIACRESO, _
                                                                                           Me.cboVIACVIAC)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boVIACDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIACDEPA)
            Dim boVIACMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIACMUNI)
            Dim boVIACCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIACCLSE)
            Dim boVIACRESO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtVIACRESO)
            Dim boVIACDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtVIACDESC)
            Dim boVIACVIAC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIACVIAC)
            Dim boVIACPOIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtVIACPOIN)
            Dim boVIACESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboVIACESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boVIACDEPA = True And _
               boVIACMUNI = True And _
               boVIACCLSE = True And _
               boVIACRESO = True And _
               boVIACDESC = True And _
               boVIACVIAC = True And _
               boVIACPOIN = True And _
               boVIACESTA = True Then

                Dim objdatos22 As New cla_VIGEACTU

                If (objdatos22.fun_Insertar_VIGEACTU(Me.cboVIACDEPA.SelectedValue, _
                                                         Me.cboVIACMUNI.SelectedValue, _
                                                         Me.cboVIACCLSE.SelectedValue, _
                                                         Me.txtVIACRESO.Text, _
                                                         Me.txtVIACDESC.Text, _
                                                         Me.cboVIACVIAC.SelectedValue, _
                                                         Me.txtVIACPOIN.Text, _
                                                         Me.rbdVIACACTU.Checked, _
                                                         Me.rbdVIACCONS.Checked, _
                                                         Me.cboVIACESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboVIACDEPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboVIACDEPA.Focus()
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
        Me.cboVIACDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_VIGEACTU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboVIACDEPA.Focus()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboVIACDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVIACDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboVIACDEPA, Me.cboVIACDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboVIACMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVIACMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboVIACMUNI, Me.cboVIACMUNI.SelectedIndex, Me.cboVIACDEPA)
        End If
    End Sub
    Private Sub cboVIACCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVIACCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboVIACCLSE, Me.cboVIACCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboVIACVIAC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVIACVIAC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboVIACVIAC, Me.cboVIACVIAC.SelectedIndex)
        End If
    End Sub
    Private Sub cboVIACESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboVIACESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboVIACESTA, Me.cboVIACESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboVIACDEPA.KeyPress, cboVIACMUNI.KeyPress, cboVIACCLSE.KeyPress, txtVIACRESO.KeyPress, txtVIACDESC.KeyPress, cboVIACVIAC.KeyPress, txtVIACPOIN.KeyPress, rbdVIACACTU.KeyPress, rbdVIACCONS.KeyPress, cboVIACESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVIACRESO.GotFocus, txtVIACDESC.GotFocus, txtVIACPOIN.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVIACDEPA.GotFocus, cboVIACMUNI.GotFocus, cboVIACCLSE.GotFocus, cboVIACVIAC.GotFocus, cboVIACESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub rbd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbdVIACACTU.GotFocus, rbdVIACCONS.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboVIACDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVIACDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboVIACDEPA, Me.cboVIACDEPA.SelectedIndex)
    End Sub
    Private Sub cboVIACMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVIACMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboVIACMUNI, Me.cboVIACMUNI.SelectedIndex, Me.cboVIACDEPA)
    End Sub
    Private Sub cboVIACCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVIACCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboVIACCLSE, Me.cboVIACCLSE.SelectedIndex)
    End Sub
    Private Sub cboVIACVIAC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVIACVIAC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboVIACVIAC, Me.cboVIACVIAC.SelectedIndex)
    End Sub
    Private Sub cboVIACESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVIACESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboVIACESTA, Me.cboVIACESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboVIACDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVIACDEPA.SelectedIndexChanged
        Me.lblVIACDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboVIACDEPA), String)

        Me.cboVIACMUNI.DataSource = New DataTable
        Me.lblVIACMUNI.Text = ""

    End Sub
    Private Sub cboVIACMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVIACMUNI.SelectedIndexChanged
        Me.lblVIACMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboVIACDEPA, Me.cboVIACMUNI), String)
    End Sub
    Private Sub cboVIACCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVIACCLSE.SelectedIndexChanged
        Me.lblVIACCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboVIACCLSE), String)
    End Sub
    Private Sub cboVIACVIAC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVIACVIAC.SelectedIndexChanged
        Me.lblVIACVIAC.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboVIACVIAC), String)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtVIACPOIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVIACPOIN.Validated
        If Trim(Me.txtVIACPOIN.Text) = "" Then
            Me.txtVIACPOIN.Text = "1.000"
        Else
            Me.txtVIACPOIN.Text = fun_Formato_Decimal_3_Decimales(Trim(Me.txtVIACPOIN.Text))
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