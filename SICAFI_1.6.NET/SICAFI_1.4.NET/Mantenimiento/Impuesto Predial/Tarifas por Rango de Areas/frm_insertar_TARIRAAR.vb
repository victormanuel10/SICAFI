Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_TARIRAAR

    '===========================================
    '*** INSERTAR TARIFAS POR RANGO DE AREAS ***
    '===========================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboTARADEPA.DataSource = New DataTable
        Me.cboTARAMUNI.DataSource = New DataTable
        Me.cboTARACLSE.DataSource = New DataTable
        Me.cboTARAVIGE.DataSource = New DataTable
        Me.cboTARADEEC.DataSource = New DataTable
        Me.cboTARAESTR.DataSource = New DataTable
        Me.cboTARAESTA.DataSource = New DataTable

        Me.txtTARATARI.Text = "0"
        Me.txtTARAAVIN.Text = "0"
        Me.txtTARAAVFI.Text = "0"

        Me.lblTARADEPA.Text = ""
        Me.lblTARAMUNI.Text = ""
        Me.lblTARACLSE.Text = ""
        Me.lblTARAVIGE.Text = ""
        Me.lblTARADEEC.Text = ""
        Me.lblTARAESTR.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            Me.txtTARAAVIN.Text = fun_Quita_Letras(Me.txtTARAAVIN)
            Me.txtTARAAVFI.Text = fun_Quita_Letras(Me.txtTARAAVFI)

            ' instancia la clase
            Dim objdatos As New cla_TARIRAAR

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_TARIRAAR(Me.cboTARADEPA, _
                                                                                           Me.cboTARAMUNI, _
                                                                                           Me.cboTARACLSE, _
                                                                                           Me.cboTARAVIGE, _
                                                                                           Me.cboTARADEEC, _
                                                                                           Me.cboTARAESTR, _
                                                                                           Me.txtTARAAVIN, _
                                                                                           Me.txtTARAAVFI)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boTARADEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTARADEPA)
            Dim boTARAMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTARAMUNI)
            Dim boTARACLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTARACLSE)
            Dim boTARAVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTARAVIGE)
            Dim boTARADEEC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTARADEEC)
            Dim boTARAESTR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTARAESTR)
            Dim boTARAAVIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTARAAVIN)
            Dim boTARAAVFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTARAAVFI)
            Dim boTARATARI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTARATARI)
            Dim boTARAESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTARAESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boTARADEPA = True And _
               boTARAMUNI = True And _
               boTARACLSE = True And _
               boTARAVIGE = True And _
               boTARADEEC = True And _
               boTARAESTR = True And _
               boTARAAVIN = True And _
               boTARAAVFI = True And _
               boTARATARI = True And _
               boTARAESTA = True Then

                Dim objdatos22 As New cla_TARIRAAR

                If (objdatos22.fun_Insertar_TARIRAAR(Me.cboTARADEPA.SelectedValue, _
                                                         Me.cboTARAMUNI.SelectedValue, _
                                                         Me.cboTARACLSE.SelectedValue, _
                                                         Me.cboTARAVIGE.SelectedValue, _
                                                         Me.cboTARADEEC.SelectedValue, _
                                                         Me.cboTARAESTR.SelectedValue, _
                                                         Me.txtTARATARI.Text, _
                                                         Me.txtTARAAVIN.Text, _
                                                         Me.txtTARAAVFI.Text, _
                                                         Me.cboTARAESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboTARADEPA.Focus()
                        Me.Close()
                    Else
                        'pro_LimpiarCampos()
                        Me.cboTARADEPA.Focus()
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
        Me.cboTARADEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_TARIRAAR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboTARADEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTARADEPA.KeyPress, cboTARAMUNI.KeyPress, cboTARACLSE.KeyPress, cboTARAVIGE.KeyPress, cboTARADEEC.KeyPress, txtTARATARI.KeyPress, txtTARAAVIN.KeyPress, txtTARAAVFI.KeyPress, cboTARAESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTARADEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTARADEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTARADEPA, Me.cboTARADEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboTARAMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTARAMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTARAMUNI, Me.cboTARAMUNI.SelectedIndex, Me.cboTARADEPA)
        End If
    End Sub
    Private Sub cboTARACLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTARACLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTARACLSE, Me.cboTARACLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTARAVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTARAVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTARAVIGE, Me.cboTARAVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTARADEEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTARADEEC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboTARADEEC, Me.cboTARADEEC.SelectedIndex)
        End If
    End Sub
    Private Sub cboTARAESTR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTARAESTR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboTARAESTR, Me.cboTARAESTR.SelectedIndex)
        End If
    End Sub
    Private Sub cboTARAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTARAESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTARAESTA, Me.cboTARAESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTARATARI.GotFocus, txtTARAAVIN.GotFocus, txtTARAAVFI.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTARADEPA.GotFocus, cboTARAMUNI.GotFocus, cboTARACLSE.GotFocus, cboTARAVIGE.GotFocus, cboTARADEEC.GotFocus, cboTARAESTA.GotFocus, cboTARAESTR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTARADEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTARADEPA.SelectedIndexChanged
        Me.lblTARADEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboTARADEPA), String)

        Me.cboTARAMUNI.DataSource = New DataTable
        Me.lblTARAMUNI.Text = ""
    End Sub
    Private Sub cboTARAMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTARAMUNI.SelectedIndexChanged
        Me.lblTARAMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboTARADEPA, Me.cboTARAMUNI), String)
    End Sub
    Private Sub cboTARACLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTARACLSE.SelectedIndexChanged
        Me.lblTARACLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboTARACLSE), String)
    End Sub
    Private Sub cboTARAVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTARAVIGE.SelectedIndexChanged
        Me.lblTARAVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboTARAVIGE), String)
    End Sub
    Private Sub cboTARADEEC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTARADEEC.SelectedIndexChanged
        Me.lblTARADEEC.Text = CType(fun_Buscar_Lista_Valores_DESTECON_Codigo(Me.cboTARADEEC), String)
    End Sub
    Private Sub cboTARAESTR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTARAESTR.SelectedIndexChanged
        Me.lblTARAESTR.Text = CType(fun_Buscar_Lista_Valores_ESTRATO_Codigo(Me.cboTARAESTR), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTARADEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTARADEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTARADEPA, Me.cboTARADEPA.SelectedIndex)
    End Sub
    Private Sub cboTARAMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTARAMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTARAMUNI, Me.cboTARAMUNI.SelectedIndex, Me.cboTARADEPA)
    End Sub
    Private Sub cboTARACLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTARACLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTARACLSE, Me.cboTARACLSE.SelectedIndex)
    End Sub
    Private Sub cboTARAVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTARAVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTARAVIGE, Me.cboTARAVIGE.SelectedIndex)
    End Sub
    Private Sub cboTARADEEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTARADEEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboTARADEEC, Me.cboTARADEEC.SelectedIndex)
    End Sub
    Private Sub cboTARAESTR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTARAESTR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboTARAESTR, Me.cboTARAESTR.SelectedIndex)
    End Sub
    Private Sub cboTARAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTARAESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTARAESTA, Me.cboTARAESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTAPEAVFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTARATARI.Validated, txtTARAAVIN.Validated, txtTARAAVFI.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTARAAVIN.Text) = True Then
                Me.txtTARAAVIN.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTARAAVIN.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTARAAVFI.Text) = True Then
                Me.txtTARAAVFI.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTARAAVFI.Text)
            End If

            Me.txtTARATARI.Text = fun_Formato_Decimal_2_Decimales(Me.txtTARATARI.Text)

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