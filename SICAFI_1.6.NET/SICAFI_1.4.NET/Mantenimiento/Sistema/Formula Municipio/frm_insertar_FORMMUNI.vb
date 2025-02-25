Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_FORMMUNI

    '==================================
    '*** INSERTAR FORMULA MUNICIPIO ***
    '==================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboFOMUDEPA.DataSource = New DataTable
        Me.cboFOMUMUNI.DataSource = New DataTable
        Me.cboFOMUCLSE.DataSource = New DataTable
        Me.cboFOMUVIGE.DataSource = New DataTable
        Me.cboFOMUTIIM.DataSource = New DataTable
        Me.cboFOMUCONC.DataSource = New DataTable
        Me.cboFOMUFORM.DataSource = New DataTable
        Me.cboFOMUESTA.DataSource = New DataTable

        Me.chkFOMUIMPR.Checked = False
        Me.chkFOMUACBO.Checked = False
        Me.chkFOMUALPU.Checked = False
        Me.chkFOMUTAAS.Checked = False

        Me.lblFOMUDEPA.Text = ""
        Me.lblFOMUMUNI.Text = ""
        Me.lblFOMUCLSE.Text = ""
        Me.lblFOMUVIGE.Text = ""
        Me.lblFOMUTIIM.Text = ""
        Me.lblFOMUCONC.Text = ""
        Me.lblFOMUFORM.Text = ""
        Me.txtFOMUDESC.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_FORMMUNI

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_FORMMUNI(Me.cboFOMUDEPA, _
                                                                                           Me.cboFOMUMUNI, _
                                                                                           Me.cboFOMUCLSE, _
                                                                                           Me.cboFOMUVIGE, _
                                                                                           Me.cboFOMUTIIM, _
                                                                                           Me.cboFOMUCONC)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boFOMUDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOMUDEPA)
            Dim boFOMUMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOMUMUNI)
            Dim boFOMUCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOMUCLSE)
            Dim boFOMUVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOMUVIGE)
            Dim boFOMUTIIM As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOMUTIIM)
            Dim boFOMUCONC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOMUCONC)
            Dim boFOMUFORM As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOMUFORM)
            Dim boFOMUESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboFOMUESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boFOMUDEPA = True And _
               boFOMUMUNI = True And _
               boFOMUCLSE = True And _
               boFOMUVIGE = True And _
               boFOMUTIIM = True And _
               boFOMUCONC = True And _
               boFOMUFORM = True And _
               boFOMUESTA = True Then

                Dim objdatos22 As New cla_FORMMUNI

                If (objdatos22.fun_Insertar_FORMMUNI(Me.cboFOMUDEPA.SelectedValue, _
                                                         Me.cboFOMUMUNI.SelectedValue, _
                                                         Me.cboFOMUCLSE.SelectedValue, _
                                                         Me.cboFOMUVIGE.SelectedValue, _
                                                         Me.cboFOMUTIIM.SelectedValue, _
                                                         Me.cboFOMUCONC.SelectedValue, _
                                                         Me.cboFOMUFORM.SelectedValue, _
                                                         Me.txtFOMUDESC.Text, _
                                                         Me.chkFOMUIMPR.Checked, _
                                                         Me.chkFOMUACBO.Checked, _
                                                         Me.chkFOMUALPU.Checked, _
                                                         Me.chkFOMUTAAS.Checked, _
                                                         False, False, False, False, False, _
                                                         Me.cboFOMUESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboFOMUDEPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboFOMUDEPA.Focus()
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
        Me.cboFOMUDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_FORMMUNI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboFOMUDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFOMUDEPA.KeyPress, cboFOMUMUNI.KeyPress, cboFOMUCLSE.KeyPress, cboFOMUVIGE.KeyPress, cboFOMUTIIM.KeyPress, cboFOMUESTA.KeyPress, chkFOMUIMPR.KeyPress, chkFOMUACBO.KeyPress, chkFOMUALPU.KeyPress, chkFOMUTAAS.KeyPress, cboFOMUCONC.KeyPress, cboFOMUFORM.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboFOMUDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOMUDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboFOMUDEPA, Me.cboFOMUDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOMUMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOMUMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboFOMUMUNI, Me.cboFOMUMUNI.SelectedIndex, Me.cboFOMUDEPA)
        End If
    End Sub
    Private Sub cboFOMUCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOMUCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboFOMUCLSE, Me.cboFOMUCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOMUVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOMUVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboFOMUVIGE, Me.cboFOMUVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOMUTIIM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOMUTIIM.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboFOMUTIIM, Me.cboFOMUTIIM.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOMUCONC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOMUCONC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboFOMUCONC, Me.cboFOMUCONC.SelectedIndex, Me.cboFOMUTIIM)
        End If
    End Sub
    Private Sub cboFOMUFORM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOMUFORM.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_FORMULA_Descripcion(Me.cboFOMUFORM, Me.cboFOMUFORM.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOMUESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFOMUESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboFOMUESTA, Me.cboFOMUESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOMUDEPA.GotFocus, cboFOMUMUNI.GotFocus, cboFOMUCLSE.GotFocus, cboFOMUVIGE.GotFocus, cboFOMUTIIM.GotFocus, cboFOMUESTA.GotFocus, cboFOMUCONC.GotFocus, cboFOMUFORM.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFOMUIMPR.GotFocus, chkFOMUACBO.GotFocus, chkFOMUALPU.GotFocus, chkFOMUTAAS.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboFOMUDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOMUDEPA.SelectedIndexChanged
        Me.lblFOMUDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboFOMUDEPA), String)

        Me.cboFOMUMUNI.DataSource = New DataTable
        Me.lblFOMUMUNI.Text = ""
    End Sub
    Private Sub cboFOMUMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOMUMUNI.SelectedIndexChanged
        Me.lblFOMUMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboFOMUDEPA, Me.cboFOMUMUNI), String)
    End Sub
    Private Sub cboFOMUCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOMUCLSE.SelectedIndexChanged
        Me.lblFOMUCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboFOMUCLSE), String)
    End Sub
    Private Sub cboFOMUVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOMUVIGE.SelectedIndexChanged
        Me.lblFOMUVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboFOMUVIGE), String)
    End Sub
    Private Sub cboFOMUTIIM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOMUTIIM.SelectedIndexChanged
        Me.lblFOMUTIIM.Text = CType(fun_Buscar_Lista_Valores_TIPOIMPU_Codigo(Me.cboFOMUTIIM), String)

        Me.cboFOMUCONC.DataSource = New DataTable
        Me.lblFOMUCONC.Text = ""
    End Sub
    Private Sub cboFOMUCONC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOMUCONC.SelectedIndexChanged
        Me.lblFOMUCONC.Text = CType(fun_Buscar_Lista_Valores_CONCEPTO_Codigo(Me.cboFOMUTIIM, Me.cboFOMUCONC), String)
    End Sub
    Private Sub cboFOMUFORM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFOMUFORM.SelectedIndexChanged
        Me.lblFOMUFORM.Text = CType(fun_Buscar_Lista_Valores_FORMULA_Codigo(Me.cboFOMUFORM), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboFOMUDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOMUDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboFOMUDEPA, Me.cboFOMUDEPA.SelectedIndex)
    End Sub
    Private Sub cboFOMUMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOMUMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboFOMUMUNI, Me.cboFOMUMUNI.SelectedIndex, Me.cboFOMUDEPA)
    End Sub
    Private Sub cboFOMUCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOMUCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboFOMUCLSE, Me.cboFOMUCLSE.SelectedIndex)
    End Sub
    Private Sub cboFOMUVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOMUVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboFOMUVIGE, Me.cboFOMUVIGE.SelectedIndex)
    End Sub
    Private Sub cboFOMUTIIM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOMUTIIM.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboFOMUTIIM, Me.cboFOMUTIIM.SelectedIndex)
    End Sub
    Private Sub cboFOMUCONC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOMUCONC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboFOMUCONC, Me.cboFOMUCONC.SelectedIndex, Me.cboFOMUTIIM)
    End Sub
    Private Sub cboFOMUFORM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOMUFORM.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_FORMULA_Descripcion(Me.cboFOMUFORM, Me.cboFOMUFORM.SelectedIndex)
    End Sub
    Private Sub cboFOMUESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFOMUESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboFOMUESTA, Me.cboFOMUESTA.SelectedIndex)
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