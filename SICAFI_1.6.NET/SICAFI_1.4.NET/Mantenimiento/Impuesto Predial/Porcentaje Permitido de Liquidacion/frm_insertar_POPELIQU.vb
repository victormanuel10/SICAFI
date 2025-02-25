Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_POPELIQU

    '================================
    '*** INSERTAR PREDIOS EXENTOS ***
    '================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboPPLIDEPA.DataSource = New DataTable
        Me.cboPPLIMUNI.DataSource = New DataTable
        Me.cboPPLICLSE.DataSource = New DataTable
        Me.cboPPLITIIM.DataSource = New DataTable
        Me.cboPPLICONC.DataSource = New DataTable
        Me.cboPPLIVIIN.DataSource = New DataTable
        Me.cboPPLIVIFI.DataSource = New DataTable
        Me.cboPPLIESTA.DataSource = New DataTable

        Me.lblPPLIDEPA.Text = ""
        Me.lblPPLIMUNI.Text = ""
        Me.lblPPLICLSE.Text = ""
        Me.lblPPLIVIIN.Text = ""
        Me.lblPPLIVIFI.Text = ""
        Me.lblPPLITIIM.Text = ""
        Me.lblPPLICONC.Text = ""

        Me.txtPPLIFECH.Text = ""
        Me.txtPPLIPOAP.Text = "100"
        Me.txtPPLIRESO.Text = ""
        Me.txtPPLIOBSE.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_POPELIQU

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_POPELIQU(Me.cboPPLIDEPA, _
                                                                                           Me.cboPPLIMUNI, _
                                                                                           Me.cboPPLICLSE)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boPREXDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLIDEPA)
            Dim boPREXMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLIMUNI)
            Dim boPREXCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLICLSE)
            Dim boPREXTIIM As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLITIIM)
            Dim boPREXCONC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLICONC)
            Dim boPREXVIIN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLIVIIN)
            Dim boPREXVIFI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLIVIFI)
            Dim boPREXPOAP As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtPPLIPOAP)
            Dim boPREXRESO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtPPLIRESO)
            Dim boPREXFECH As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtPPLIFECH)
            Dim boPREXESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPPLIESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boPREXDEPA = True And _
               boPREXMUNI = True And _
               boPREXCLSE = True And _
               boPREXTIIM = True And _
               boPREXCONC = True And _
               boPREXVIIN = True And _
               boPREXVIFI = True And _
               boPREXPOAP = True And _
               boPREXRESO = True And _
               boPREXFECH = True And _
               boPREXESTA = True Then

                Dim objdatos22 As New cla_POPELIQU

                If (objdatos22.fun_Insertar_POPELIQU(Me.cboPPLIDEPA.SelectedValue, _
                                                     Me.cboPPLIMUNI.SelectedValue, _
                                                     Me.cboPPLICLSE.SelectedValue, _
                                                     Me.nudPPLIVIAP.Value, _
                                                     Me.cboPPLITIIM.SelectedValue, _
                                                     Me.cboPPLICONC.SelectedValue, _
                                                     Me.cboPPLIVIIN.SelectedValue, _
                                                     Me.cboPPLIVIFI.SelectedValue, _
                                                     Me.txtPPLIPOAP.Text, _
                                                     Me.txtPPLIRESO.Text, _
                                                     Me.txtPPLIFECH.Text, _
                                                     Me.txtPPLIOBSE.Text, _
                                                     Me.cboPPLIESTA.SelectedValue)) = True Then

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

    Private Sub frm_insertar_PREDEXEN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboPPLIDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPPLIDEPA.KeyPress, cboPPLIMUNI.KeyPress, cboPPLICLSE.KeyPress, cboPPLIVIIN.KeyPress, cboPPLIVIFI.KeyPress, cboPPLITIIM.KeyPress, cboPPLICONC.KeyPress, cboPPLIESTA.KeyPress, txtPPLIPOAP.KeyPress, txtPPLIRESO.KeyPress, txtPPLIFECH.KeyPress, txtPPLIOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboPREXDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLIDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboPPLIDEPA, Me.cboPPLIDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboPREXMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLIMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboPPLIMUNI, Me.cboPPLIMUNI.SelectedIndex, Me.cboPPLIDEPA)
        End If
    End Sub
    Private Sub cboPREXCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLICLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboPPLICLSE, Me.cboPPLICLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboPREXVIIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLIVIIN.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboPPLIVIIN, Me.cboPPLIVIIN.SelectedIndex)
        End If
    End Sub
    Private Sub cboPREXVIFI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLIVIFI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboPPLIVIFI, Me.cboPPLIVIFI.SelectedIndex)
        End If
    End Sub
    Private Sub cboPREXTIIM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLITIIM.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboPPLITIIM, Me.cboPPLITIIM.SelectedIndex)
        End If
    End Sub
    Private Sub cboPREXCONC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLICONC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboPPLICONC, Me.cboPPLICONC.SelectedIndex, Me.cboPPLIDEPA)
        End If
    End Sub
    Private Sub cboPREXESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPPLIESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPPLIESTA, Me.cboPPLIESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPPLIPOAP.GotFocus, txtPPLIRESO.GotFocus, txtPPLIFECH.GotFocus, txtPPLIOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLIDEPA.GotFocus, cboPPLIMUNI.GotFocus, cboPPLICLSE.GotFocus, cboPPLIVIIN.GotFocus, cboPPLITIIM.GotFocus, cboPPLIESTA.GotFocus, cboPPLICONC.GotFocus, cboPPLIVIIN.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboPREXDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPPLIDEPA.SelectedIndexChanged
        Me.lblPPLIDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboPPLIDEPA), String)

        Me.cboPPLIMUNI.DataSource = New DataTable
        Me.lblPPLIMUNI.Text = ""
    End Sub
    Private Sub cboPREXMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPPLIMUNI.SelectedIndexChanged
        Me.lblPPLIMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboPPLIDEPA, Me.cboPPLIMUNI), String)
    End Sub
    Private Sub cboPREXCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPPLICLSE.SelectedIndexChanged
        Me.lblPPLICLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboPPLICLSE), String)
    End Sub
    Private Sub cboPREXVIIN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPPLIVIIN.SelectedIndexChanged
        Me.lblPPLIVIIN.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboPPLIVIIN), String)
    End Sub
    Private Sub cboPREXVIFI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPPLIVIFI.SelectedIndexChanged
        Me.lblPPLIVIFI.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboPPLIVIFI), String)
    End Sub
    Private Sub cboPREXTIIM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPPLITIIM.SelectedIndexChanged
        Me.lblPPLITIIM.Text = CType(fun_Buscar_Lista_Valores_TIPOIMPU_Codigo(Me.cboPPLITIIM), String)

        Me.cboPPLICONC.DataSource = New DataTable
        Me.lblPPLICONC.Text = ""
    End Sub
    Private Sub cboPREXCONC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPPLICONC.SelectedIndexChanged
        Me.lblPPLICONC.Text = CType(fun_Buscar_Lista_Valores_CONCEPTO_Codigo(Me.cboPPLITIIM, Me.cboPPLICONC), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboPREXDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLIDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboPPLIDEPA, Me.cboPPLIDEPA.SelectedIndex)
    End Sub
    Private Sub cboPREXMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLIMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboPPLIMUNI, Me.cboPPLIMUNI.SelectedIndex, Me.cboPPLIDEPA)
    End Sub
    Private Sub cboPREXCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLICLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboPPLICLSE, Me.cboPPLICLSE.SelectedIndex)
    End Sub
    Private Sub cboPREXVIIN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLIVIIN.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboPPLIVIIN, Me.cboPPLIVIIN.SelectedIndex)
    End Sub
    Private Sub cboPREXVIFI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLIVIFI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboPPLIVIFI, Me.cboPPLIVIFI.SelectedIndex)
    End Sub
    Private Sub cboPREXTIIM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLITIIM.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboPPLITIIM, Me.cboPPLITIIM.SelectedIndex)
    End Sub
    Private Sub cboPREXCONC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLICONC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboPPLICONC, Me.cboPPLICONC.SelectedIndex, Me.cboPPLITIIM)
    End Sub
    Private Sub cboPREXESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPPLIESTA.Click
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