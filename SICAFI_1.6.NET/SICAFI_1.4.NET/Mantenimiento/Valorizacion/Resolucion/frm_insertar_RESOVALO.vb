Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_RESOVALO

    '=================================================
    '*** INSERTAR PERIODO PERMITIDO DE LIQUIDACIÓN ***
    '=================================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboREVADEPA.DataSource = New DataTable
        Me.cboREVAMUNI.DataSource = New DataTable
        Me.cboREVACLSE.DataSource = New DataTable
        Me.cboREVAVIGE.DataSource = New DataTable
        Me.cboREVAPROY.DataSource = New DataTable
        Me.cboREVATIRE.DataSource = New DataTable
        Me.cboREVAESTA.DataSource = New DataTable

        Me.lblREVADEPA.Text = ""
        Me.lblREVAMUNI.Text = ""
        Me.lblREVACLSE.Text = ""
        Me.lblREVAVIGE.Text = ""
        Me.lblREVAPROY.Text = ""
        Me.lblREVATIRE.Text = ""
        Me.txtREVADECR.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_RESOVALO

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_RESOVALO(Me.cboREVADEPA, _
                                                                                           Me.cboREVAMUNI, _
                                                                                           Me.cboREVACLSE, _
                                                                                           Me.cboREVAPROY, _
                                                                                           Me.txtREVADECR, _
                                                                                           Me.cboREVATIRE, _
                                                                                           Me.cboREVAVIGE)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boREVADEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREVADEPA)
            Dim boREVAMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREVAMUNI)
            Dim boREVACLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREVACLSE)
            Dim boREVAPROY As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREVAPROY)
            Dim boREVADECR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtREVADECR)
            Dim boREVATIRE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREVATIRE)
            Dim boREVAVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREVAVIGE)
            Dim boREVAESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboREVAESTA)
            Dim boREVAFECH As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtREVAFECH)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boREVADEPA = True And _
               boREVAMUNI = True And _
               boREVACLSE = True And _
               boREVAPROY = True And _
               boREVADECR = True And _
               boREVATIRE = True And _
               boREVAVIGE = True And _
               boREVAFECH = True And _
               boREVAESTA = True Then

                Dim objdatos22 As New cla_RESOVALO

                If (objdatos22.fun_Insertar_RESOVALO(Me.cboREVADEPA.SelectedValue, _
                                                     Me.cboREVAMUNI.SelectedValue, _
                                                     Me.cboREVACLSE.SelectedValue, _
                                                     Me.cboREVAPROY.SelectedValue, _
                                                     Me.txtREVADECR.Text, _
                                                     Me.cboREVATIRE.SelectedValue, _
                                                     Me.cboREVAVIGE.SelectedValue, _
                                                     Me.txtREVADESC.Text, _
                                                     Me.cboREVAESTA.SelectedValue, _
                                                     Me.txtREVACONT.Text, _
                                                     Me.rbdREVARETO.Checked, _
                                                     Me.rbdREVAREPA.Checked, _
                                                     Me.txtREVAFECH.Text)) Then
                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboREVADEPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboREVADEPA.Focus()
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
        Me.cboREVADEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_RESOVALO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboREVADEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboREVADEPA.KeyPress, cboREVAMUNI.KeyPress, cboREVACLSE.KeyPress, cboREVAVIGE.KeyPress, cboREVAPROY.KeyPress, cboREVAESTA.KeyPress, cboREVATIRE.KeyPress, txtREVADECR.KeyPress, txtREVADESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboREVADEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREVADEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboREVADEPA, Me.cboREVADEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboREVAMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREVAMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboREVAMUNI, Me.cboREVAMUNI.SelectedIndex, Me.cboREVADEPA)
        End If
    End Sub
    Private Sub cboREVACLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREVACLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboREVACLSE, Me.cboREVACLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboREVAVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREVAVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboREVAVIGE, Me.cboREVAVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboREVATIIM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREVAPROY.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_PROYECTO_Descripcion(Me.cboREVAPROY, Me.cboREVAPROY.SelectedIndex, cboREVADEPA, cboREVAMUNI, cboREVACLSE)
        End If
    End Sub
    Private Sub cboREVATIRE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREVATIRE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPORESO_Descripcion(Me.cboREVATIRE, Me.cboREVATIRE.SelectedIndex)
        End If
    End Sub
    Private Sub cboREVAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboREVAESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboREVAESTA, Me.cboREVAESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREVADECR.GotFocus, txtREVADESC.GotFocus, txtREVACONT.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREVADEPA.GotFocus, cboREVAMUNI.GotFocus, cboREVACLSE.GotFocus, cboREVAVIGE.GotFocus, cboREVAPROY.GotFocus, cboREVAESTA.GotFocus, cboREVATIRE.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbdREVAREPA.GotFocus, rbdREVARETO.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboREVADEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboREVADEPA.SelectedIndexChanged
        Me.lblREVADEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboREVADEPA), String)

        Me.cboREVAMUNI.DataSource = New DataTable
        Me.lblREVAMUNI.Text = ""

        Me.cboREVAPROY.DataSource = New DataTable
        Me.lblREVAPROY.Text = ""
    End Sub
    Private Sub cboREVAMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboREVAMUNI.SelectedIndexChanged
        Me.lblREVAMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboREVADEPA, Me.cboREVAMUNI), String)

        Me.cboREVAPROY.DataSource = New DataTable
        Me.lblREVAPROY.Text = ""
    End Sub
    Private Sub cboREVACLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboREVACLSE.SelectedIndexChanged
        Me.lblREVACLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboREVACLSE), String)
    End Sub
    Private Sub cboREVAVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboREVAVIGE.SelectedIndexChanged
        Me.lblREVAVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboREVAVIGE), String)
    End Sub
    Private Sub cboREVAPROY_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboREVAPROY.SelectedIndexChanged
        Me.lblREVAPROY.Text = CType(fun_Buscar_Lista_Valores_PROYECTO_Codigo(cboREVADEPA, cboREVAMUNI, cboREVACLSE, Me.cboREVAPROY), String)
    End Sub
    Private Sub cboREVATIRE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboREVATIRE.SelectedIndexChanged
        Me.lblREVATIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO_Codigo(Me.cboREVATIRE), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboREVADEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREVADEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboREVADEPA, Me.cboREVADEPA.SelectedIndex)
    End Sub
    Private Sub cboREVAMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREVAMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboREVAMUNI, Me.cboREVAMUNI.SelectedIndex, Me.cboREVADEPA)
    End Sub
    Private Sub cboREVACLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREVACLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboREVACLSE, Me.cboREVACLSE.SelectedIndex)
    End Sub
    Private Sub cboREVAVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREVAVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboREVAVIGE, Me.cboREVAVIGE.SelectedIndex)
    End Sub
    Private Sub cboREVAPROY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREVAPROY.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_PROYECTO_Descripcion(Me.cboREVAPROY, Me.cboREVAPROY.SelectedIndex, Me.cboREVADEPA, Me.cboREVAMUNI, Me.cboREVACLSE)
    End Sub
    Private Sub cboREVATIRE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREVATIRE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPORESO_Descripcion(Me.cboREVATIRE, Me.cboREVATIRE.SelectedIndex)
    End Sub
    Private Sub cboREVAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboREVAESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboREVAESTA, Me.cboREVAESTA.SelectedIndex)
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