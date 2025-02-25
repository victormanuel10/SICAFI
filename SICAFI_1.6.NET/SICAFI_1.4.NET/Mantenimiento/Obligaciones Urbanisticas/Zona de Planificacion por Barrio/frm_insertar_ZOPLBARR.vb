Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_ZOPLBARR

    '================================
    '*** INSERTAR BARRIO - VEREDA ***
    '================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraZOPLBARR)

        Me.lblZPBADEPA.Text = ""
        Me.lblZPBAMUNI.Text = ""
        Me.lblZPBACLSE.Text = ""
        Me.lblZPBACORR.Text = ""
        Me.lblZPBABARR.Text = ""
        Me.lblZPBAZOPL.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_ZOPLBARR

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_ZOPLBARR(Me.cboCPBADEPA, _
                                                                                           Me.cboZPBAMUNI, _
                                                                                           Me.cboZPBACLSE, _
                                                                                           Me.cboZPBACORR, _
                                                                                           Me.cboZPBABARR, _
                                                                                           Me.cboZPBAZOPL)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boBAVEDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCPBADEPA)
            Dim boBAVEMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboZPBAMUNI)
            Dim boBAVECLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboZPBACLSE)
            Dim boBAVECORR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboZPBACORR)
            Dim boBAVEBARR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboZPBABARR)
            Dim boBAVEZOPL As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboZPBAZOPL)
            Dim boBAVEESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboZPBAESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boBAVEDEPA = True And _
               boBAVEMUNI = True And _
               boBAVECLSE = True And _
               boBAVECORR = True And _
               boBAVEBARR = True And _
               boBAVEZOPL = True And _
               boBAVEESTA = True Then

                Dim objdatos22 As New cla_ZOPLBARR

                If (objdatos22.fun_Insertar_ZOPLBARR(Me.cboCPBADEPA.SelectedValue, _
                                                     Me.cboZPBAMUNI.SelectedValue, _
                                                     Me.cboZPBACORR.SelectedValue, _
                                                     Me.cboZPBABARR.SelectedValue, _
                                                     Me.cboZPBACLSE.SelectedValue, _
                                                     Me.cboZPBAZOPL.SelectedValue, _
                                                     Me.cboZPBAESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboCPBADEPA.Focus()
                        Me.Close()
                    Else
                        'pro_LimpiarCampos()
                        Me.cboCPBADEPA.Focus()
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
        Me.cboCPBADEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_VIGEACTU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboCPBADEPA.Focus()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboBAVEDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCPBADEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboCPBADEPA, Me.cboCPBADEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboBAVEMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZPBAMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboZPBAMUNI, Me.cboZPBAMUNI.SelectedIndex, Me.cboCPBADEPA)
        End If
    End Sub
    Private Sub cboBAVECLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZPBACLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboZPBACLSE, Me.cboZPBACLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboZPBAZOPL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZPBAZOPL.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ZONAPLAN_Descripcion(Me.cboZPBAZOPL, Me.cboZPBAZOPL.SelectedIndex)
        End If
    End Sub
    Private Sub cboBAVECORR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZPBACORR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CORREGIMIENTO_X_MUNICIPIO_Descripcion(Me.cboZPBACORR, Me.cboZPBACORR.SelectedIndex, Me.cboCPBADEPA, Me.cboZPBAMUNI, Me.cboZPBACLSE)
        End If
    End Sub
    Private Sub cboZPBABARR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZPBABARR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_BARRVERE_X_MUNICIPIO_Descripcion(Me.cboZPBABARR, Me.cboZPBABARR.SelectedIndex, Me.cboCPBADEPA, Me.cboZPBAMUNI, Me.cboZPBACLSE)
        End If
    End Sub
    Private Sub cboBAVEESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZPBAESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboZPBAESTA, Me.cboZPBAESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCPBADEPA.KeyPress, cboZPBAMUNI.KeyPress, cboZPBACLSE.KeyPress, cboZPBAESTA.KeyPress, cboZPBACORR.KeyPress, cboZPBABARR.KeyPress, cboZPBAZOPL.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCPBADEPA.GotFocus, cboZPBAMUNI.GotFocus, cboZPBACLSE.GotFocus, cboZPBAESTA.GotFocus, cboZPBACORR.GotFocus, cboZPBABARR.GotFocus, cboZPBAZOPL.GotFocus, cboZPBAESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboBAVEDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCPBADEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboCPBADEPA, Me.cboCPBADEPA.SelectedIndex)
    End Sub
    Private Sub cboBAVEMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZPBAMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboZPBAMUNI, Me.cboZPBAMUNI.SelectedIndex, Me.cboCPBADEPA)
    End Sub
    Private Sub cboBAVECLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZPBACLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboZPBACLSE, Me.cboZPBACLSE.SelectedIndex)
    End Sub
    Private Sub cboZPBAZOPL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZPBAZOPL.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAPLAN_Descripcion(Me.cboZPBAZOPL, Me.cboZPBAZOPL.SelectedIndex)
    End Sub
    Private Sub cboBAVECORR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZPBACORR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CORREGIMIENTO_X_MUNICIPIO_Descripcion(Me.cboZPBACORR, Me.cboZPBACORR.SelectedIndex, Me.cboCPBADEPA, Me.cboZPBAMUNI, Me.cboZPBACLSE)
    End Sub
    Private Sub cboZPBABARR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZPBABARR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_BARRVERE_X_MUNICIPIO_Descripcion(Me.cboZPBABARR, Me.cboZPBABARR.SelectedIndex, Me.cboCPBADEPA, Me.cboZPBAMUNI, Me.cboZPBACLSE)
    End Sub
    Private Sub cboBAVEESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZPBAESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboZPBAESTA, Me.cboZPBAESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboBAVEDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCPBADEPA.SelectedIndexChanged
        Me.lblZPBADEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboCPBADEPA), String)

        Me.cboZPBAMUNI.DataSource = New DataTable
        Me.lblZPBAMUNI.Text = ""

        Me.cboZPBACLSE.DataSource = New DataTable
        Me.lblZPBACLSE.Text = ""

        Me.cboZPBACORR.DataSource = New DataTable
        Me.lblZPBACORR.Text = ""

        Me.cboZPBABARR.DataSource = New DataTable
        Me.lblZPBABARR.Text = ""

    End Sub
    Private Sub cboBAVEMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZPBAMUNI.SelectedIndexChanged
        Me.lblZPBAMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboCPBADEPA, Me.cboZPBAMUNI), String)
    End Sub
    Private Sub cboBAVECLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZPBACLSE.SelectedIndexChanged
        Me.lblZPBACLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboZPBACLSE), String)
    End Sub
    Private Sub cboZPBAZOPL_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZPBAZOPL.SelectedIndexChanged
        Me.lblZPBAZOPL.Text = CType(fun_Buscar_Lista_Valores_ZONAPLAN_Codigo(Me.cboZPBAZOPL), String)
    End Sub
    Private Sub cboZPBACORR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZPBACORR.SelectedIndexChanged
        Me.lblZPBACORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO_Codigo(Me.cboCPBADEPA, Me.cboZPBAMUNI, Me.cboZPBACLSE, Me.cboZPBACORR), String)
    End Sub
    Private Sub cboZPBABARR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZPBABARR.SelectedIndexChanged
        Me.lblZPBABARR.Text = CType(fun_Buscar_Lista_Valores_BARRVERE_Codigo(Me.cboCPBADEPA, Me.cboZPBAMUNI, Me.cboZPBACLSE, Me.cboZPBABARR), String)
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