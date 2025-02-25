Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_PEPELIQU

    '=================================================
    '*** INSERTAR PERIODO PERMITIDO DE LIQUIDACIÓN ***
    '=================================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboPPLIDEPA.DataSource = New DataTable
        Me.cboPPLIMUNI.DataSource = New DataTable
        Me.cboPPLICLSE.DataSource = New DataTable
        Me.cboPPLIVIGE.DataSource = New DataTable
        Me.cboPPLITIIM.DataSource = New DataTable
        Me.cboPPLICONC.DataSource = New DataTable
        Me.cboPPLIESTA.DataSource = New DataTable

        Me.chkPPLIHIAV.Checked = False
        Me.chkPPLIHILI.Checked = False
        Me.chkPPLIAFSI.Checked = False

        Me.lblPPLIDEPA.Text = ""
        Me.lblPPLIMUNI.Text = ""
        Me.lblPPLICLSE.Text = ""
        Me.lblPPLIVIGE.Text = ""
        Me.lblPPLITIIM.Text = ""
        Me.lblPPLICONC.Text = ""
        Me.txtPPLIDESC.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_PEPELIQU

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_PEPELIQU(Me.cboPPLIDEPA, _
                                                                                           Me.cboPPLIMUNI, _
                                                                                           Me.cboPPLICLSE, _
                                                                                           Me.cboPPLIVIGE, _
                                                                                           Me.cboPPLITIIM, _
                                                                                           Me.cboPPLICONC)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boFOMUDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLIDEPA)
            Dim boFOMUMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLIMUNI)
            Dim boFOMUCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLICLSE)
            Dim boFOMUVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLIVIGE)
            Dim boFOMUTIIM As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLITIIM)
            Dim boFOMUCONC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLICONC)
            Dim boFOMUESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLIESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boFOMUDEPA = True And _
               boFOMUMUNI = True And _
               boFOMUCLSE = True And _
               boFOMUVIGE = True And _
               boFOMUTIIM = True And _
               boFOMUCONC = True And _
               boFOMUESTA = True Then

                Dim objdatos22 As New cla_PEPELIQU

                If (objdatos22.fun_Insertar_PEPELIQU(Me.cboPPLIDEPA.SelectedValue, _
                                                         Me.cboPPLIMUNI.SelectedValue, _
                                                         Me.cboPPLICLSE.SelectedValue, _
                                                         Me.cboPPLIVIGE.SelectedValue, _
                                                         Me.cboPPLITIIM.SelectedValue, _
                                                         Me.cboPPLICONC.SelectedValue, _
                                                         Me.txtPPLIDESC.Text, _
                                                         Me.chkPPLIHIAV.Checked, _
                                                         Me.chkPPLIHILI.Checked, _
                                                         Me.chkPPLIAFSI.Checked, _
                                                         Me.cboPPLIESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboPPLIDEPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboPPLIDEPA.Focus()
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
        Me.cboPPLIDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_PEPELIQU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboPPLIDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPPLIDEPA.KeyPress, cboPPLIMUNI.KeyPress, cboPPLICLSE.KeyPress, cboPPLIVIGE.KeyPress, cboPPLITIIM.KeyPress, cboPPLIESTA.KeyPress, chkPPLIHIAV.KeyPress, chkPPLIHILI.KeyPress, chkPPLIAFSI.KeyPress, cboPPLICONC.KeyPress, txtPPLIDESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboFOMUDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLIDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboPPLIDEPA, Me.cboPPLIDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOMUMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLIMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboPPLIMUNI, Me.cboPPLIMUNI.SelectedIndex, Me.cboPPLIDEPA)
        End If
    End Sub
    Private Sub cboFOMUCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLICLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboPPLICLSE, Me.cboPPLICLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOMUVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLIVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboPPLIVIGE, Me.cboPPLIVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOMUTIIM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLITIIM.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboPPLITIIM, Me.cboPPLITIIM.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOMUCONC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLICONC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboPPLICONC, Me.cboPPLICONC.SelectedIndex, Me.cboPPLITIIM)
        End If
    End Sub
    Private Sub cboFOMUESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLIESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPPLIESTA, Me.cboPPLIESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPPLIDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLIDEPA.GotFocus, cboPPLIMUNI.GotFocus, cboPPLICLSE.GotFocus, cboPPLIVIGE.GotFocus, cboPPLITIIM.GotFocus, cboPPLIESTA.GotFocus, cboPPLICONC.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPPLIHIAV.GotFocus, chkPPLIHILI.GotFocus, chkPPLIAFSI.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboFOMUDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPPLIDEPA.SelectedIndexChanged
        Me.lblPPLIDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboPPLIDEPA), String)

        Me.cboPPLIMUNI.DataSource = New DataTable
        Me.lblPPLIMUNI.Text = ""
    End Sub
    Private Sub cboFOMUMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPPLIMUNI.SelectedIndexChanged
        Me.lblPPLIMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboPPLIDEPA, Me.cboPPLIMUNI), String)
    End Sub
    Private Sub cboFOMUCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPPLICLSE.SelectedIndexChanged
        Me.lblPPLICLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboPPLICLSE), String)
    End Sub
    Private Sub cboFOMUVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPPLIVIGE.SelectedIndexChanged
        Me.lblPPLIVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboPPLIVIGE), String)
    End Sub
    Private Sub cboFOMUTIIM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPPLITIIM.SelectedIndexChanged
        Me.lblPPLITIIM.Text = CType(fun_Buscar_Lista_Valores_TIPOIMPU_Codigo(Me.cboPPLITIIM), String)

        Me.cboPPLICONC.DataSource = New DataTable
        Me.lblPPLICONC.Text = ""
    End Sub
    Private Sub cboFOMUCONC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPPLICONC.SelectedIndexChanged
        Me.lblPPLICONC.Text = CType(fun_Buscar_Lista_Valores_CONCEPTO_Codigo(Me.cboPPLITIIM, Me.cboPPLICONC), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboFOMUDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLIDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboPPLIDEPA, Me.cboPPLIDEPA.SelectedIndex)
    End Sub
    Private Sub cboFOMUMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLIMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboPPLIMUNI, Me.cboPPLIMUNI.SelectedIndex, Me.cboPPLIDEPA)
    End Sub
    Private Sub cboFOMUCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLICLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboPPLICLSE, Me.cboPPLICLSE.SelectedIndex)
    End Sub
    Private Sub cboFOMUVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLIVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboPPLIVIGE, Me.cboPPLIVIGE.SelectedIndex)
    End Sub
    Private Sub cboFOMUTIIM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLITIIM.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboPPLITIIM, Me.cboPPLITIIM.SelectedIndex)
    End Sub
    Private Sub cboFOMUCONC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLICONC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboPPLICONC, Me.cboPPLICONC.SelectedIndex, Me.cboPPLITIIM)
    End Sub
    Private Sub cboFOMUESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLIESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPPLIESTA, Me.cboPPLIESTA.SelectedIndex)
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