Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_INAVDEEC

    '================================================================
    '*** INSERTAR INCREMENTO DE AVALUO POR DESTINACIÓN ECONÓMICAS ***
    '================================================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtIADETARI.Text = "0.00"
        Me.lblIADEDEPA.Text = ""
        Me.lblIADEMUNI.Text = ""
        Me.lblIADECLSE.Text = ""
        Me.lblIADEVIGE.Text = ""

        Me.strBARRESTA.Items(1).Text = ""

        Me.cboIADEDEPA.DataSource = New DataTable
        Me.cboIADEMUNI.DataSource = New DataTable
        Me.cboIADECLSE.DataSource = New DataTable
        Me.cboIADEVIGE.DataSource = New DataTable
        Me.cboIADEDEEC.DataSource = New DataTable
        Me.cboIADEESTA.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_INAVDEEC

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_INAVDEEC(Me.cboIADEDEPA, _
                                                                                           Me.cboIADEMUNI, _
                                                                                           Me.cboIADECLSE, _
                                                                                           Me.cboIADEVIGE, _
                                                                                           Me.cboIADEDEEC)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boIADEDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboIADEDEPA)
            Dim boIADEMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboIADEMUNI)
            Dim boIADECLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboIADECLSE)
            Dim boIADEVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboIADEVIGE)
            Dim boIADEDEEC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboIADEDEEC)
            Dim boIADETARI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtIADETARI)
            Dim boIADEESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboIADEESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boIADEDEPA = True And _
               boIADEMUNI = True And _
               boIADECLSE = True And _
               boIADEVIGE = True And _
               boIADEDEEC = True And _
               boIADETARI = True And _
               boIADEESTA = True Then

                Dim objdatos22 As New cla_INAVDEEC

                If (objdatos22.fun_Insertar_INAVDEEC(Me.cboIADEDEPA.SelectedValue, _
                                                     Me.cboIADEMUNI.SelectedValue, _
                                                     Me.cboIADECLSE.SelectedValue, _
                                                     Me.cboIADEVIGE.SelectedValue, _
                                                     Me.cboIADEDEEC.SelectedValue, _
                                                     Me.txtIADETARI.Text, _
                                                     Me.cboIADEESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboIADEDEPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboIADEDEPA.Focus()
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
        Me.cboIADEDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_TARIDEEC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboIADEDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboIADEDEPA.KeyPress, cboIADEMUNI.KeyPress, cboIADECLSE.KeyPress, cboIADEVIGE.KeyPress, cboIADEDEEC.KeyPress, txtIADETARI.KeyPress, cboIADEESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboIADEDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboIADEDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboIADEDEPA, Me.cboIADEDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboIADEMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboIADEMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboIADEMUNI, Me.cboIADEMUNI.SelectedIndex, Me.cboIADEDEPA)
        End If
    End Sub
    Private Sub cboIADECLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboIADECLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboIADECLSE, Me.cboIADECLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboIADEVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboIADEVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboIADEVIGE, Me.cboIADEVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboIADEDEED_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboIADEDEEC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboIADEDEEC, Me.cboIADEDEEC.SelectedIndex)
        End If
    End Sub
    Private Sub cboIADEESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboIADEESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboIADEESTA, Me.cboIADEESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIADETARI.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIADEDEPA.GotFocus, cboIADEMUNI.GotFocus, cboIADECLSE.GotFocus, cboIADEVIGE.GotFocus, cboIADEDEEC.GotFocus, cboIADEESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboIADEDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIADEDEPA.SelectedIndexChanged
        Me.lblIADEDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboIADEDEPA), String)

        Me.cboIADEMUNI.DataSource = New DataTable
        Me.lblIADEMUNI.Text = ""

    End Sub
    Private Sub cboIADEMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIADEMUNI.SelectedIndexChanged
        Me.lblIADEMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboIADEDEPA, Me.cboIADEMUNI), String)
    End Sub
    Private Sub cboIADECLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIADECLSE.SelectedIndexChanged
        Me.lblIADECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboIADECLSE), String)
    End Sub
    Private Sub cboIADEVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIADEVIGE.SelectedIndexChanged
        Me.lblIADEVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboIADEVIGE), String)
    End Sub
    Private Sub cboIADEDEEC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIADEDEEC.SelectedIndexChanged
        Me.lblIADEDEEC.Text = CType(fun_Buscar_Lista_Valores_DESTECON_Codigo(Me.cboIADEDEEC), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboIADEDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIADEDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboIADEDEPA, Me.cboIADEDEPA.SelectedIndex)
    End Sub
    Private Sub cboIADEMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIADEMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboIADEMUNI, Me.cboIADEMUNI.SelectedIndex, Me.cboIADEDEPA)
    End Sub
    Private Sub cboIADECLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIADECLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboIADECLSE, Me.cboIADECLSE.SelectedIndex)
    End Sub
    Private Sub cboIADEVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIADEVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboIADEVIGE, Me.cboIADEVIGE.SelectedIndex)
    End Sub
    Private Sub cboIADEDEEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIADEDEEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboIADEDEEC, Me.cboIADEDEEC.SelectedIndex)
    End Sub
    Private Sub cboIADEESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIADEESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboIADEESTA, Me.cboIADEESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTAAPAVFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIADETARI.Validated
        If Trim(sender.text) = "" Then
            sender.text = "0.00"
        Else
            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtIADETARI.Text) = True Then
                Me.txtIADETARI.Text = fun_Formato_Decimal_2_Decimales(Me.txtIADETARI.Text)
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