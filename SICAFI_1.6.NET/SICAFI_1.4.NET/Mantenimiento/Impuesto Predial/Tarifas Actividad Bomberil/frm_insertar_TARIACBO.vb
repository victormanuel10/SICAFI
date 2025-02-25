Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_TARIACBO

    '===========================================
    '*** INSERTAR TARIFAS ACTIVIDAD BOMBERIL ***
    '===========================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboTAABDEPA.DataSource = New DataTable
        Me.cboTAABMUNI.DataSource = New DataTable
        Me.cboTAABCLSE.DataSource = New DataTable
        Me.cboTAABVIGE.DataSource = New DataTable
        Me.cboTAABTIPO.DataSource = New DataTable
        Me.cboTAABESTR.DataSource = New DataTable
        Me.cboTAABESTA.DataSource = New DataTable

        Me.txtTAABTARE.Text = "0"
        Me.txtTAABTACO.Text = "0"
        Me.txtTAABTAIN.Text = "0"
        Me.txtTAABTA01.Text = "0"
        Me.txtTAABTA02.Text = "0"
        Me.txtTAABTA03.Text = "0"
        Me.txtTAABTA04.Text = "0"
        Me.txtTAABTA05.Text = "0"
        Me.txtTAABAVIN.Text = "0"
        Me.txtTAABAVFI.Text = "0"

        Me.lblTAABDEPA.Text = ""
        Me.lblTAABMUNI.Text = ""
        Me.lblTAABCLSE.Text = ""
        Me.lblTAABVIGE.Text = ""
        Me.lblTAABTIPO.Text = ""
        Me.lblTAABESTR.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' convierte a numero
            Me.txtTAABTARE.Text = fun_Quita_Letras(Me.txtTAABTARE)
            Me.txtTAABTACO.Text = fun_Quita_Letras(Me.txtTAABTACO)
            Me.txtTAABTAIN.Text = fun_Quita_Letras(Me.txtTAABTAIN)
            Me.txtTAABAVIN.Text = fun_Quita_Letras(Me.txtTAABAVIN)
            Me.txtTAABAVFI.Text = fun_Quita_Letras(Me.txtTAABAVFI)

            ' instancia la clase
            Dim objdatos As New cla_TARIACBO

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_TARIACBO(Me.cboTAABDEPA, _
                                                                                           Me.cboTAABMUNI, _
                                                                                           Me.cboTAABCLSE, _
                                                                                           Me.cboTAABVIGE, _
                                                                                           Me.cboTAABTIPO, _
                                                                                           Me.txtTAABTARE, _
                                                                                           Me.txtTAABTACO, _
                                                                                           Me.txtTAABTAIN)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boTAAPDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAABDEPA)
            Dim boTAAPMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAABMUNI)
            Dim boTAAPCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAABCLSE)
            Dim boTAAPVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAABVIGE)
            Dim boTAAPTIPO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAABTIPO)
            Dim boTAAPTARE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAABTARE)
            Dim boTAAPTACO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAABTACO)
            Dim boTAAPTAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAABTAIN)
            Dim boTAAPESTR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAABESTR)
            Dim boTAAPTA01 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAABTA01)
            Dim boTAAPTA02 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAABTA02)
            Dim boTAAPTA03 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAABTA03)
            Dim boTAAPTA04 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAABTA04)
            Dim boTAAPTA05 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAABTA05)
            Dim boTAAPAVIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAABAVIN)
            Dim boTAAPAVFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAABAVFI)
            Dim boTAAPESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAABESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boTAAPDEPA = True And _
               boTAAPMUNI = True And _
               boTAAPCLSE = True And _
               boTAAPVIGE = True And _
               boTAAPTIPO = True And _
               boTAAPTARE = True And _
               boTAAPTACO = True And _
               boTAAPTAIN = True And _
               boTAAPESTR = True And _
               boTAAPTA01 = True And _
               boTAAPTA02 = True And _
               boTAAPTA03 = True And _
               boTAAPTA04 = True And _
               boTAAPTA05 = True And _
               boTAAPAVIN = True And _
               boTAAPAVFI = True And _
               boTAAPESTA = True Then

                Dim objdatos22 As New cla_TARIACBO

                If (objdatos22.fun_Insertar_TARIACBO(Me.cboTAABDEPA.SelectedValue, _
                                                         Me.cboTAABMUNI.SelectedValue, _
                                                         Me.cboTAABCLSE.SelectedValue, _
                                                         Me.cboTAABVIGE.SelectedValue, _
                                                         Me.cboTAABTIPO.SelectedValue, _
                                                         Me.txtTAABTARE.Text, _
                                                         Me.txtTAABTACO.Text, _
                                                         Me.txtTAABTAIN.Text, _
                                                         Me.cboTAABESTR.SelectedValue, _
                                                         Me.txtTAABTA01.Text, _
                                                         Me.txtTAABTA02.Text, _
                                                         Me.txtTAABTA03.Text, _
                                                         Me.txtTAABTA04.Text, _
                                                         Me.txtTAABTA05.Text, _
                                                         Me.txtTAABAVIN.Text, _
                                                         Me.txtTAABAVFI.Text, _
                                                         Me.cboTAABESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboTAABDEPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboTAABDEPA.Focus()
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
        Me.cboTAABDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_TARIALPU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboTAABDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTAABDEPA.KeyPress, cboTAABMUNI.KeyPress, cboTAABCLSE.KeyPress, cboTAABVIGE.KeyPress, cboTAABTIPO.KeyPress, txtTAABTARE.KeyPress, txtTAABTACO.KeyPress, txtTAABTAIN.KeyPress, cboTAABESTR.KeyPress, txtTAABTA01.KeyPress, txtTAABTA02.KeyPress, txtTAABTA03.KeyPress, txtTAABTA04.KeyPress, txtTAABTA05.KeyPress, txtTAABAVIN.KeyPress, txtTAABAVFI.KeyPress, cboTAABESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTAAPDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAABDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTAABDEPA, Me.cboTAABDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAAPMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAABMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTAABMUNI, Me.cboTAABMUNI.SelectedIndex, Me.cboTAABDEPA)
        End If
    End Sub
    Private Sub cboTAAPCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAABCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTAABCLSE, Me.cboTAABCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAAPVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAABVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTAABVIGE, Me.cboTAABVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAAPTIPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAABTIPO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboTAABTIPO, Me.cboTAABTIPO.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAAPESTR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAABESTR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboTAABESTR, Me.cboTAABESTR.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAAPESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAABESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTAABESTA, Me.cboTAABESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAABTARE.GotFocus, txtTAABTACO.GotFocus, txtTAABTAIN.GotFocus, txtTAABTA01.GotFocus, txtTAABTA02.GotFocus, txtTAABTA03.GotFocus, txtTAABTA04.GotFocus, txtTAABTA05.GotFocus, txtTAABAVIN.GotFocus, txtTAABAVFI.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAABDEPA.GotFocus, cboTAABMUNI.GotFocus, cboTAABCLSE.GotFocus, cboTAABVIGE.GotFocus, cboTAABTIPO.GotFocus, cboTAABESTR.GotFocus, cboTAABESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTAAPDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAABDEPA.SelectedIndexChanged
        Me.lblTAABDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboTAABDEPA), String)

        Me.cboTAABMUNI.DataSource = New DataTable
        Me.lblTAABMUNI.Text = ""
    End Sub
    Private Sub cboTAAPMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAABMUNI.SelectedIndexChanged
        Me.lblTAABMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboTAABDEPA, Me.cboTAABMUNI), String)
    End Sub
    Private Sub cboTAAPCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAABCLSE.SelectedIndexChanged
        Me.lblTAABCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboTAABCLSE), String)
    End Sub
    Private Sub cboTAAPVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAABVIGE.SelectedIndexChanged
        Me.lblTAABVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboTAABVIGE), String)
    End Sub
    Private Sub cboTAAPTIPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAABTIPO.SelectedIndexChanged
        Me.lblTAABTIPO.Text = CType(fun_Buscar_Lista_Valores_TIPOCALI_Codigo(Me.cboTAABTIPO), String)
    End Sub
    Private Sub cboTAAPESTR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAABESTR.SelectedIndexChanged
        Me.lblTAABESTR.Text = CType(fun_Buscar_Lista_Valores_ESTRATO_Codigo(Me.cboTAABESTR), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTAAPDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAABDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTAABDEPA, Me.cboTAABDEPA.SelectedIndex)
    End Sub
    Private Sub cboTAAPMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAABMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTAABMUNI, Me.cboTAABMUNI.SelectedIndex, Me.cboTAABDEPA)
    End Sub
    Private Sub cboTAAPCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAABCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTAABCLSE, Me.cboTAABCLSE.SelectedIndex)
    End Sub
    Private Sub cboTAAPVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAABVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTAABVIGE, Me.cboTAABVIGE.SelectedIndex)
    End Sub
    Private Sub cboTAAPTIPO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAABTIPO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboTAABTIPO, Me.cboTAABTIPO.SelectedIndex)
    End Sub
    Private Sub cboTAAPESTR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAABESTR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboTAABESTR, Me.cboTAABESTR.SelectedIndex)
    End Sub
    Private Sub cboTAAPESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAABESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTAABESTA, Me.cboTAABESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAABTARE.Validated, txtTAABTACO.Validated, txtTAABTAIN.Validated, txtTAABTA01.Validated, txtTAABTA02.Validated, txtTAABTA03.Validated, txtTAABTA04.Validated, txtTAABTA05.Validated, txtTAABAVIN.Validated, txtTAABAVFI.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTAABTARE.Text) = True Then
                Me.txtTAABTARE.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTAABTARE.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTAABTACO.Text) = True Then
                Me.txtTAABTACO.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTAABTACO.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTAABTAIN.Text) = True Then
                Me.txtTAABTAIN.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTAABTAIN.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTAABAVIN.Text) = True Then
                Me.txtTAABAVIN.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTAABAVIN.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTAABAVFI.Text) = True Then
                Me.txtTAABAVFI.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTAABAVFI.Text)
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