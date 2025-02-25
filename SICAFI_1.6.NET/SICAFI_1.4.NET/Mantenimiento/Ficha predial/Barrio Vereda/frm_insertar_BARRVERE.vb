Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_BARRVERE

    '================================
    '*** INSERTAR BARRIO - VEREDA ***
    '================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraBARRVERE)

        Me.lblBAVEDEPA.Text = ""
        Me.lblBAVEMUNI.Text = ""
        Me.lblBAVECLSE.Text = ""
        Me.lblBAVECORR.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_BARRVERE

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_BARRVERE(Me.cboBAVEDEPA, _
                                                                                           Me.cboBAVEMUNI, _
                                                                                           Me.cboBAVECLSE, _
                                                                                           Me.cboBAVECORR, _
                                                                                           Me.txtBAVECODI)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boBAVEDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboBAVEDEPA)
            Dim boBAVEMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboBAVEMUNI)
            Dim boBAVECLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboBAVECLSE)
            Dim boBAVECORR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboBAVECORR)
            Dim boBAVECODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtBAVECODI)
            Dim boBAVEDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtBAVEDESC)
            Dim boBAVEESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboBAVEESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boBAVEDEPA = True And _
               boBAVEMUNI = True And _
               boBAVECLSE = True And _
               boBAVECORR = True And _
               boBAVECODI = True And _
               boBAVEDESC = True And _
               boBAVEESTA = True Then

                Dim objdatos22 As New cla_BARRVERE

                If (objdatos22.fun_Insertar_BARRVERE(Me.cboBAVEDEPA.SelectedValue, _
                                                     Me.cboBAVEMUNI.SelectedValue, _
                                                     Me.cboBAVECLSE.SelectedValue, _
                                                     Me.txtBAVECODI.Text, _
                                                     Me.txtBAVEDESC.Text, _
                                                     Me.cboBAVEESTA.SelectedValue, _
                                                     Me.cboBAVECORR.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboBAVEDEPA.Focus()
                        Me.Close()
                    Else
                        'pro_LimpiarCampos()
                        Me.cboBAVEDEPA.Focus()
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
        Me.cboBAVEDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_VIGEACTU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboBAVEDEPA.Focus()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboBAVEDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBAVEDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboBAVEDEPA, Me.cboBAVEDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboBAVEMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBAVEMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboBAVEMUNI, Me.cboBAVEMUNI.SelectedIndex, Me.cboBAVEDEPA)
        End If
    End Sub
    Private Sub cboBAVECLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBAVECLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboBAVECLSE, Me.cboBAVECLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboBAVECORR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBAVECORR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CORREGIMIENTO_X_MUNICIPIO_Descripcion(Me.cboBAVECORR, Me.cboBAVECORR.SelectedIndex, Me.cboBAVEDEPA, Me.cboBAVEMUNI, Me.cboBAVECLSE)
        End If
    End Sub
    Private Sub cboBAVEESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBAVEESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboBAVEESTA, Me.cboBAVEESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboBAVEDEPA.KeyPress, cboBAVEMUNI.KeyPress, cboBAVECLSE.KeyPress, txtBAVECODI.KeyPress, txtBAVEDESC.KeyPress, cboBAVEESTA.KeyPress, cboBAVECORR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBAVECODI.GotFocus, txtBAVEDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBAVEDEPA.GotFocus, cboBAVEMUNI.GotFocus, cboBAVECLSE.GotFocus, cboBAVEESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub rbd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboBAVEDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBAVEDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboBAVEDEPA, Me.cboBAVEDEPA.SelectedIndex)
    End Sub
    Private Sub cboBAVEMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBAVEMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboBAVEMUNI, Me.cboBAVEMUNI.SelectedIndex, Me.cboBAVEDEPA)
    End Sub
    Private Sub cboBAVECLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBAVECLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboBAVECLSE, Me.cboBAVECLSE.SelectedIndex)
    End Sub
    Private Sub cboBAVECORR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBAVECORR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CORREGIMIENTO_X_MUNICIPIO_Descripcion(Me.cboBAVECORR, Me.cboBAVECORR.SelectedIndex, Me.cboBAVEDEPA, Me.cboBAVEMUNI, Me.cboBAVECLSE)
    End Sub
    Private Sub cboBAVEESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBAVEESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboBAVEESTA, Me.cboBAVEESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboBAVEDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBAVEDEPA.SelectedIndexChanged
        Me.lblBAVEDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboBAVEDEPA), String)

        Me.cboBAVEMUNI.DataSource = New DataTable
        Me.lblBAVEMUNI.Text = ""

        Me.cboBAVECLSE.DataSource = New DataTable
        Me.lblBAVECLSE.Text = ""

        Me.cboBAVECORR.DataSource = New DataTable
        Me.lblBAVECORR.Text = ""

    End Sub
    Private Sub cboBAVEMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBAVEMUNI.SelectedIndexChanged
        Me.lblBAVEMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboBAVEDEPA, Me.cboBAVEMUNI), String)
    End Sub
    Private Sub cboBAVECLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBAVECLSE.SelectedIndexChanged
        Me.lblBAVECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboBAVECLSE), String)
    End Sub
    Private Sub cboBAVEcorr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBAVECORR.SelectedIndexChanged
        Me.lblBAVECORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO_Codigo(Me.cboBAVEDEPA, Me.cboBAVEMUNI, Me.cboBAVECLSE, Me.cboBAVECORR), String)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtBAVECODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBAVECODI.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtBAVECODI.Text) = True Then
                Me.txtBAVECODI.Text = fun_Formato_Mascara_3_String(Me.txtBAVECODI.Text)
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