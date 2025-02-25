Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_TARILOTE

    '===========================================
    '*** INSERTAR TARIFAS PREDIOS ESPECIALES ***
    '===========================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboTALODEPA.DataSource = New DataTable
        Me.cboTALOMUNI.DataSource = New DataTable
        Me.cboTALOCLSE.DataSource = New DataTable
        Me.cboTALOVIGE.DataSource = New DataTable
        Me.cboTALOZOEC.DataSource = New DataTable
        Me.cboTALOESTA.DataSource = New DataTable

        Me.txtTALOTARI.Text = "0"
        Me.txtTALOAVIN.Text = "0"
        Me.txtTALOAVFI.Text = "0"

        Me.lblTALODEPA.Text = ""
        Me.lblTALOMUNI.Text = ""
        Me.lblTALOCLSE.Text = ""
        Me.lblTALOVIGE.Text = ""
        Me.lblTALOZOEC.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            Me.txtTALOTARI.Text = fun_Quita_Letras(Me.txtTALOTARI)
            Me.txtTALOAVIN.Text = fun_Quita_Letras(Me.txtTALOAVIN)
            Me.txtTALOAVFI.Text = fun_Quita_Letras(Me.txtTALOAVFI)

            ' instancia la clase
            Dim objdatos As New cla_TARILOTE

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_TARILOTE(Me.cboTALODEPA, _
                                                                                           Me.cboTALOMUNI, _
                                                                                           Me.cboTALOCLSE, _
                                                                                           Me.cboTALOVIGE, _
                                                                                           Me.cboTALOZOEC)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boTALODEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTALODEPA)
            Dim boTALOMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTALOMUNI)
            Dim boTALOCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTALOCLSE)
            Dim boTALOVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTALOVIGE)
            Dim boTALOZOEC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTALOZOEC)
            Dim boTALOTARI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTALOTARI)
            Dim boTALOAVIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTALOAVIN)
            Dim boTALOAVFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTALOAVFI)
            Dim boTALOESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTALOESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boTALODEPA = True And _
               boTALOMUNI = True And _
               boTALOCLSE = True And _
               boTALOVIGE = True And _
               boTALOZOEC = True And _
               boTALOTARI = True And _
               boTALOAVIN = True And _
               boTALOAVFI = True And _
               boTALOESTA = True Then

                Dim objdatos22 As New cla_TARILOTE

                If (objdatos22.fun_Insertar_TARILOTE(Me.cboTALODEPA.SelectedValue, _
                                                         Me.cboTALOMUNI.SelectedValue, _
                                                         Me.cboTALOCLSE.SelectedValue, _
                                                         Me.cboTALOVIGE.SelectedValue, _
                                                         Me.cboTALOZOEC.SelectedValue, _
                                                         Me.txtTALOTARI.Text, _
                                                         Me.txtTALOAVIN.Text, _
                                                         Me.txtTALOAVFI.Text, _
                                                         Me.cboTALOESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboTALODEPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboTALODEPA.Focus()
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
        Me.cboTALODEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_TARILOTE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboTALODEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTALODEPA.KeyPress, cboTALOMUNI.KeyPress, cboTALOCLSE.KeyPress, cboTALOVIGE.KeyPress, cboTALOZOEC.KeyPress, txtTALOTARI.KeyPress, txtTALOAVIN.KeyPress, txtTALOAVFI.KeyPress, cboTALOESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTAPEDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTALODEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTALODEPA, Me.cboTALODEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTALOMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTALOMUNI, Me.cboTALOMUNI.SelectedIndex, Me.cboTALODEPA)
        End If
    End Sub
    Private Sub cboTAPECLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTALOCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTALOCLSE, Me.cboTALOCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTALOVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTALOVIGE, Me.cboTALOVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEZOEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTALOZOEC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON_Descripcion(Me.cboTALOZOEC, Me.cboTALOZOEC.SelectedIndex, Me.cboTALODEPA, Me.cboTALOMUNI, Me.cboTALOCLSE)
        End If
    End Sub
    Private Sub cboTAPEESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTALOESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTALOESTA, Me.cboTALOESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTALOTARI.GotFocus, txtTALOAVIN.GotFocus, txtTALOAVFI.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTALODEPA.GotFocus, cboTALOMUNI.GotFocus, cboTALOCLSE.GotFocus, cboTALOVIGE.GotFocus, cboTALOZOEC.GotFocus, cboTALOESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTAPEDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTALODEPA.SelectedIndexChanged
        Me.lblTALODEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboTALODEPA), String)

        Me.cboTALOMUNI.DataSource = New DataTable
        Me.lblTALOMUNI.Text = ""

        Me.cboTALOZOEC.DataSource = New DataTable
        Me.lblTALOZOEC.Text = ""
    End Sub
    Private Sub cboTAPEMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTALOMUNI.SelectedIndexChanged
        Me.lblTALOMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboTALODEPA, Me.cboTALOMUNI), String)
    End Sub
    Private Sub cboTAPECLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTALOCLSE.SelectedIndexChanged
        Me.lblTALOCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboTALOCLSE), String)
    End Sub
    Private Sub cboTAPEVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTALOVIGE.SelectedIndexChanged
        Me.lblTALOVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboTALOVIGE), String)
    End Sub
    Private Sub cboTAPEZOEC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTALOZOEC.SelectedIndexChanged
        Me.lblTALOZOEC.Text = CType(fun_Buscar_Lista_Valores_ZONAECON_Codigo(Me.cboTALODEPA, Me.cboTALOMUNI, Me.cboTALOCLSE, Me.cboTALOZOEC), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTAPEDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTALODEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTALODEPA, Me.cboTALODEPA.SelectedIndex)
    End Sub
    Private Sub cboTAPEMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTALOMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTALOMUNI, Me.cboTALOMUNI.SelectedIndex, Me.cboTALODEPA)
    End Sub
    Private Sub cboTAPECLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTALOCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTALOCLSE, Me.cboTALOCLSE.SelectedIndex)
    End Sub
    Private Sub cboTAPEVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTALOVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTALOVIGE, Me.cboTALOVIGE.SelectedIndex)
    End Sub
    Private Sub cboTAPEZOEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTALOZOEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON_Descripcion(Me.cboTALOZOEC, Me.cboTALOZOEC.SelectedIndex, Me.cboTALODEPA, Me.cboTALOMUNI, Me.cboTALOCLSE)
    End Sub
    Private Sub cboTAPEESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTALOESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTALOESTA, Me.cboTALOESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTAAPAVFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTALOTARI.Validated, txtTALOAVIN.Validated, txtTALOAVFI.Validated
        If Trim(sender.text) = "" Then
            sender.text = 0
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTALOTARI.Text) = True Then
                Me.txtTALOTARI.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTALOTARI.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTALOAVIN.Text) = True Then
                Me.txtTALOAVIN.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTALOAVIN.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTALOAVFI.Text) = True Then
                Me.txtTALOAVFI.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTALOAVFI.Text)
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