Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_PREDEXNI

    '========================================
    '*** INSERTAR PREDIOS EXENTOS POR NIT ***
    '========================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboPRENDEPA.DataSource = New DataTable
        Me.cboPRENMUNI.DataSource = New DataTable
        Me.cboPRENCLSE.DataSource = New DataTable
        Me.cboPRENTIIM.DataSource = New DataTable
        Me.cboPRENCONC.DataSource = New DataTable
        Me.cboPRENTIDO.DataSource = New DataTable
        Me.cboPRENCAPR.DataSource = New DataTable
        Me.cboPRENSEXO.DataSource = New DataTable
        Me.cboPRENESTA.DataSource = New DataTable

        Me.lblPRENDEPA.Text = ""
        Me.lblPRENMUNI.Text = ""
        Me.lblPRENCLSE.Text = ""
        Me.lblPRENTIIM.Text = ""
        Me.lblPRENCONC.Text = ""
        Me.lblPRENTIDO.Text = ""
        Me.lblPRENCAPR.Text = ""
        Me.lblPRENSEXO.Text = ""

        Me.txtPRENNUDO.Text = ""
        Me.txtPRENDESC.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_PREDEXNI

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_PREDEXNI(Me.cboPRENDEPA, _
                                                                                           Me.cboPRENMUNI, _
                                                                                           Me.cboPRENCLSE, _
                                                                                           Me.cboPRENTIIM, _
                                                                                           Me.cboPRENCONC, _
                                                                                           Me.txtPRENNUDO)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boPRENDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRENDEPA)
            Dim boPRENMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRENMUNI)
            Dim boPRENCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRENCLSE)
            Dim boPRENTIIM As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRENTIIM)
            Dim boPRENCONC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRENCONC)
            Dim boPRENTIDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRENTIDO)
            Dim boPRENCAPR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRENCAPR)
            Dim boPRENSEXO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRENSEXO)
            Dim boPRENNUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtPRENNUDO)
            Dim boPRENESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPRENESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boPRENDEPA = True And _
               boPRENMUNI = True And _
               boPRENCLSE = True And _
               boPRENTIIM = True And _
               boPRENCONC = True And _
               boPRENTIDO = True And _
               boPRENCAPR = True And _
               boPRENSEXO = True And _
               boPRENNUDO = True And _
               boPRENESTA = True Then

                Dim objdatos22 As New cla_PREDEXNI

                If (objdatos22.fun_Insertar_PREDEXNI(Me.cboPRENDEPA.SelectedValue, _
                                                     Me.cboPRENMUNI.SelectedValue, _
                                                     Me.cboPRENCLSE.SelectedValue, _
                                                     Me.cboPRENTIIM.SelectedValue, _
                                                     Me.cboPRENCONC.SelectedValue, _
                                                     Me.cboPRENTIDO.SelectedValue, _
                                                     Me.cboPRENCAPR.SelectedValue, _
                                                     Me.cboPRENSEXO.SelectedValue, _
                                                     Me.txtPRENNUDO.Text, _
                                                     Me.txtPRENDESC.Text, _
                                                     Me.cboPRENESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboPRENDEPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboPRENDEPA.Focus()
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
        Me.cboPRENDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_PREDEXNI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboPRENDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPRENDEPA.KeyPress, cboPRENMUNI.KeyPress, cboPRENCLSE.KeyPress, txtPRENNUDO.KeyPress, cboPRENTIDO.KeyPress, cboPRENCAPR.KeyPress, cboPRENSEXO.KeyPress, cboPRENTIIM.KeyPress, cboPRENCONC.KeyPress, cboPRENESTA.KeyPress, txtPRENDESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboPRENDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRENDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboPRENDEPA, Me.cboPRENDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboPRENMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRENMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboPRENMUNI, Me.cboPRENMUNI.SelectedIndex, Me.cboPRENDEPA)
        End If
    End Sub
    Private Sub cboPRENCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRENCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboPRENCLSE, Me.cboPRENCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboPRENTIIM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRENTIIM.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboPRENTIIM, Me.cboPRENTIIM.SelectedIndex)
        End If
    End Sub
    Private Sub cboPRENCONC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRENCONC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboPRENCONC, Me.cboPRENCONC.SelectedIndex, Me.cboPRENDEPA)
        End If
    End Sub
    Private Sub cboPRENTIDO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRENTIDO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPODOCU_Descripcion(Me.cboPRENTIDO, Me.cboPRENTIDO.SelectedIndex)
        End If
    End Sub
    Private Sub cboPRENCAPR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRENCAPR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CALIPROP_Descripcion(Me.cboPRENCAPR, Me.cboPRENCAPR.SelectedIndex)
        End If
    End Sub
    Private Sub cboPRENSEXO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRENSEXO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_SEXO_Descripcion(Me.cboPRENSEXO, Me.cboPRENSEXO.SelectedIndex)
        End If
    End Sub
    Private Sub cboPRENESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPRENESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPRENESTA, Me.cboPRENESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPRENNUDO.GotFocus, txtPRENDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRENDEPA.GotFocus, cboPRENMUNI.GotFocus, cboPRENCLSE.GotFocus, cboPRENTIDO.GotFocus, cboPRENTIIM.GotFocus, cboPRENESTA.GotFocus, cboPRENCONC.GotFocus, cboPRENCAPR.GotFocus, cboPRENSEXO.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboPRENDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRENDEPA.SelectedIndexChanged
        Me.lblPRENDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboPRENDEPA), String)

        Me.cboPRENMUNI.DataSource = New DataTable
        Me.lblPRENMUNI.Text = ""
    End Sub
    Private Sub cboPRENMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRENMUNI.SelectedIndexChanged
        Me.lblPRENMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboPRENDEPA, Me.cboPRENMUNI), String)
    End Sub
    Private Sub cboPRENCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRENCLSE.SelectedIndexChanged
        Me.lblPRENCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboPRENCLSE), String)
    End Sub
    Private Sub cboPRENTIIM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRENTIIM.SelectedIndexChanged
        Me.lblPRENTIIM.Text = CType(fun_Buscar_Lista_Valores_TIPOIMPU_Codigo(Me.cboPRENTIIM), String)

        Me.cboPRENCONC.DataSource = New DataTable
        Me.lblPRENCONC.Text = ""
    End Sub
    Private Sub cboPRENCONC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRENCONC.SelectedIndexChanged
        Me.lblPRENCONC.Text = CType(fun_Buscar_Lista_Valores_CONCEPTO_Codigo(Me.cboPRENTIIM, Me.cboPRENCONC), String)
    End Sub
    Private Sub cboPRENTIDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRENTIDO.SelectedIndexChanged
        Me.lblPRENTIDO.Text = CType(fun_Buscar_Lista_Valores_TIPODOCU_Codigo(Me.cboPRENTIDO), String)
    End Sub
    Private Sub cboPRENCAPR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRENCAPR.SelectedIndexChanged
        Me.lblPRENCAPR.Text = CType(fun_Buscar_Lista_Valores_CALIPROP_Codigo(Me.cboPRENCAPR), String)
    End Sub
    Private Sub cboPRENSEXO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRENSEXO.SelectedIndexChanged
        Me.lblPRENSEXO.Text = CType(fun_Buscar_Lista_Valores_SEXO_Codigo(Me.cboPRENSEXO), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboPRENDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRENDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboPRENDEPA, Me.cboPRENDEPA.SelectedIndex)
    End Sub
    Private Sub cboPRENMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRENMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboPRENMUNI, Me.cboPRENMUNI.SelectedIndex, Me.cboPRENDEPA)
    End Sub
    Private Sub cboPRENCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRENCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboPRENCLSE, Me.cboPRENCLSE.SelectedIndex)
    End Sub
    Private Sub cboPRENTIIM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRENTIIM.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboPRENTIIM, Me.cboPRENTIIM.SelectedIndex)
    End Sub
    Private Sub cboPRENCONC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRENCONC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboPRENCONC, Me.cboPRENCONC.SelectedIndex, Me.cboPRENTIIM)
    End Sub
    Private Sub cboPRENTIDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRENTIDO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPODOCU_Descripcion(Me.cboPRENTIDO, Me.cboPRENTIDO.SelectedIndex)
    End Sub
    Private Sub cboPRENCAPR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRENCAPR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CALIPROP_Descripcion(Me.cboPRENCAPR, Me.cboPRENCAPR.SelectedIndex)
    End Sub
    Private Sub cboPRENSEXO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRENSEXO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_SEXO_Descripcion(Me.cboPRENSEXO, Me.cboPRENSEXO.SelectedIndex)
    End Sub
    Private Sub cboPRENESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPRENESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPRENESTA, Me.cboPRENESTA.SelectedIndex)
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