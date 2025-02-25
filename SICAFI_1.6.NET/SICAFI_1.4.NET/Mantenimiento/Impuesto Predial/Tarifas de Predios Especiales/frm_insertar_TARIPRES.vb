Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_TARIPRES

    '===========================================
    '*** INSERTAR TARIFAS PREDIOS ESPECIALES ***
    '===========================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboTAPEDEPA.DataSource = New DataTable
        Me.cboTAPEMUNI.DataSource = New DataTable
        Me.cboTAPECLSE.DataSource = New DataTable
        Me.cboTAPEVIGE.DataSource = New DataTable
        Me.cboTAPEDEEC.DataSource = New DataTable
        Me.cboTAPEESTA.DataSource = New DataTable

        Me.txtTAPETARI.Text = "0"
        Me.txtTAPEAVIN.Text = "0"
        Me.txtTAPEAVFI.Text = "0"

        Me.lblTAPEDEPA.Text = ""
        Me.lblTAPEMUNI.Text = ""
        Me.lblTAPECLSE.Text = ""
        Me.lblTAPEVIGE.Text = ""
        Me.lblTAPEDEEC.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            Me.txtTAPETARI.Text = fun_Quita_Letras(Me.txtTAPETARI)
            Me.txtTAPEAVIN.Text = fun_Quita_Letras(Me.txtTAPEAVIN)
            Me.txtTAPEAVFI.Text = fun_Quita_Letras(Me.txtTAPEAVFI)

            ' instancia la clase
            Dim objdatos As New cla_TARIPRES

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_TARIPRES(Me.cboTAPEDEPA, _
                                                                                           Me.cboTAPEMUNI, _
                                                                                           Me.cboTAPECLSE, _
                                                                                           Me.cboTAPEVIGE, _
                                                                                           Me.cboTAPEDEEC)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boTAPEDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAPEDEPA)
            Dim boTAPEMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAPEMUNI)
            Dim boTAPECLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAPECLSE)
            Dim boTAPEVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAPEVIGE)
            Dim boTAPEDEEC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAPEDEEC)
            Dim boTAPETARI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAPETARI)
            Dim boTAPEAVIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAPEAVIN)
            Dim boTAPEAVFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAPEAVFI)
            Dim boTAPEESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAPEESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boTAPEDEPA = True And _
               boTAPEMUNI = True And _
               boTAPECLSE = True And _
               boTAPEVIGE = True And _
               boTAPEDEEC = True And _
               boTAPETARI = True And _
               boTAPEAVIN = True And _
               boTAPEAVFI = True And _
               boTAPEESTA = True Then

                Dim objdatos22 As New cla_TARIPRES

                If (objdatos22.fun_Insertar_TARIPRES(Me.cboTAPEDEPA.SelectedValue, _
                                                         Me.cboTAPEMUNI.SelectedValue, _
                                                         Me.cboTAPECLSE.SelectedValue, _
                                                         Me.cboTAPEVIGE.SelectedValue, _
                                                         Me.cboTAPEDEEC.SelectedValue, _
                                                         Me.txtTAPETARI.Text, _
                                                         Me.txtTAPEAVIN.Text, _
                                                         Me.txtTAPEAVFI.Text, _
                                                         Me.cboTAPEESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboTAPEDEPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboTAPEDEPA.Focus()
                    End If

                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.cboTAPEDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_TARIPRES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboTAPEDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTAPEDEPA.KeyPress, cboTAPEMUNI.KeyPress, cboTAPECLSE.KeyPress, cboTAPEVIGE.KeyPress, cboTAPEDEEC.KeyPress, txtTAPETARI.KeyPress, txtTAPEAVIN.KeyPress, txtTAPEAVFI.KeyPress, cboTAPEESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTAPEDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAPEDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTAPEDEPA, Me.cboTAPEDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAPEMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTAPEMUNI, Me.cboTAPEMUNI.SelectedIndex, Me.cboTAPEDEPA)
        End If
    End Sub
    Private Sub cboTAPECLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAPECLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTAPECLSE, Me.cboTAPECLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAPEVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTAPEVIGE, Me.cboTAPEVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEDEEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAPEDEEC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboTAPEDEEC, Me.cboTAPEDEEC.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAPEESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTAPEESTA, Me.cboTAPEESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAPETARI.GotFocus, txtTAPEAVIN.GotFocus, txtTAPEAVFI.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAPEDEPA.GotFocus, cboTAPEMUNI.GotFocus, cboTAPECLSE.GotFocus, cboTAPEVIGE.GotFocus, cboTAPEDEEC.GotFocus, cboTAPEESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTAPEDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAPEDEPA.SelectedIndexChanged
        Me.lblTAPEDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboTAPEDEPA), String)

        Me.cboTAPEMUNI.DataSource = New DataTable
        Me.lblTAPEMUNI.Text = ""
    End Sub
    Private Sub cboTAPEMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAPEMUNI.SelectedIndexChanged
        Me.lblTAPEMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboTAPEDEPA, Me.cboTAPEMUNI), String)
    End Sub
    Private Sub cboTAPECLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAPECLSE.SelectedIndexChanged
        Me.lblTAPECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboTAPECLSE), String)
    End Sub
    Private Sub cboTAPEVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAPEVIGE.SelectedIndexChanged
        Me.lblTAPEVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboTAPEVIGE), String)
    End Sub
    Private Sub cboTAPEDEEC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAPEDEEC.SelectedIndexChanged
        Me.lblTAPEDEEC.Text = CType(fun_Buscar_Lista_Valores_DESTECON_Codigo(Me.cboTAPEDEEC), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTAPEDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAPEDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTAPEDEPA, Me.cboTAPEDEPA.SelectedIndex)
    End Sub
    Private Sub cboTAPEMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAPEMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTAPEMUNI, Me.cboTAPEMUNI.SelectedIndex, Me.cboTAPEDEPA)
    End Sub
    Private Sub cboTAPECLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAPECLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTAPECLSE, Me.cboTAPECLSE.SelectedIndex)
    End Sub
    Private Sub cboTAPEVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAPEVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTAPEVIGE, Me.cboTAPEVIGE.SelectedIndex)
    End Sub
    Private Sub cboTAPEDEEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAPEDEEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboTAPEDEEC, Me.cboTAPEDEEC.SelectedIndex)
    End Sub
    Private Sub cboTAPEESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAPEESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTAPEESTA, Me.cboTAPEESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTAPEAVFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAPETARI.Validated, txtTAPEAVIN.Validated, txtTAPEAVFI.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTAPETARI.Text) = True Then
                Me.txtTAPETARI.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTAPETARI.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTAPEAVIN.Text) = True Then
                Me.txtTAPEAVIN.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTAPEAVIN.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTAPEAVFI.Text) = True Then
                Me.txtTAPEAVFI.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTAPEAVFI.Text)
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