Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_TARIALPU

    '==========================================
    '*** INSERTAR TARIFAS ALUMBRADO PUBLICO ***
    '==========================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboTAAPDEPA.DataSource = New DataTable
        Me.cboTAAPMUNI.DataSource = New DataTable
        Me.cboTAAPCLSE.DataSource = New DataTable
        Me.cboTAAPVIGE.DataSource = New DataTable
        Me.cboTAAPTIPO.DataSource = New DataTable
        Me.cboTAAPESTR.DataSource = New DataTable
        Me.cboTAAPESTA.DataSource = New DataTable

        Me.txtTAAPTARE.Text = "0"
        Me.txtTAAPTACO.Text = "0"
        Me.txtTAAPTAIN.Text = "0"
        Me.txtTAAPTA01.Text = "0"
        Me.txtTAAPTA02.Text = "0"
        Me.txtTAAPTA03.Text = "0"
        Me.txtTAAPTA04.Text = "0"
        Me.txtTAAPTA05.Text = "0"
        Me.txtTAAPAVIN.Text = "0"
        Me.txtTAAPAVFI.Text = "0"

        Me.lblTAAPDEPA.Text = ""
        Me.lblTAAPMUNI.Text = ""
        Me.lblTAAPCLSE.Text = ""
        Me.lblTAAPVIGE.Text = ""
        Me.lblTAAPTIPO.Text = ""
        Me.lblTAAPESTR.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' convierte a numero
            Me.txtTAAPTARE.Text = fun_Quita_Letras(Me.txtTAAPTARE)
            Me.txtTAAPTACO.Text = fun_Quita_Letras(Me.txtTAAPTACO)
            Me.txtTAAPTAIN.Text = fun_Quita_Letras(Me.txtTAAPTAIN)
            Me.txtTAAPAVIN.Text = fun_Quita_Letras(Me.txtTAAPAVIN)
            Me.txtTAAPAVFI.Text = fun_Quita_Letras(Me.txtTAAPAVFI)

            ' instancia la clase
            Dim objdatos As New cla_TARIALPU

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_TARIALPU(Me.cboTAAPDEPA, _
                                                                                           Me.cboTAAPMUNI, _
                                                                                           Me.cboTAAPCLSE, _
                                                                                           Me.cboTAAPVIGE, _
                                                                                           Me.cboTAAPTIPO, _
                                                                                           Me.txtTAAPTARE, _
                                                                                           Me.txtTAAPTACO, _
                                                                                           Me.txtTAAPTAIN)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boTAAPDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAAPDEPA)
            Dim boTAAPMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAAPMUNI)
            Dim boTAAPCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAAPCLSE)
            Dim boTAAPVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAAPVIGE)
            Dim boTAAPTIPO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAAPTIPO)
            Dim boTAAPTARE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAAPTARE)
            Dim boTAAPTACO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAAPTACO)
            Dim boTAAPTAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAAPTAIN)
            Dim boTAAPESTR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAAPESTR)
            Dim boTAAPTA01 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAAPTA01)
            Dim boTAAPTA02 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAAPTA02)
            Dim boTAAPTA03 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAAPTA03)
            Dim boTAAPTA04 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAAPTA04)
            Dim boTAAPTA05 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAAPTA05)
            Dim boTAAPAVIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAAPAVIN)
            Dim boTAAPAVFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAAPAVFI)
            Dim boTAAPESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAAPESTA)

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

                Dim objdatos22 As New cla_TARIALPU

                If (objdatos22.fun_Insertar_TARIALPU(Me.cboTAAPDEPA.SelectedValue, _
                                                         Me.cboTAAPMUNI.SelectedValue, _
                                                         Me.cboTAAPCLSE.SelectedValue, _
                                                         Me.cboTAAPVIGE.SelectedValue, _
                                                         Me.cboTAAPTIPO.SelectedValue, _
                                                         Me.txtTAAPTARE.Text, _
                                                         Me.txtTAAPTACO.Text, _
                                                         Me.txtTAAPTAIN.Text, _
                                                         Me.cboTAAPESTR.SelectedValue, _
                                                         Me.txtTAAPTA01.Text, _
                                                         Me.txtTAAPTA02.Text, _
                                                         Me.txtTAAPTA03.Text, _
                                                         Me.txtTAAPTA04.Text, _
                                                         Me.txtTAAPTA05.Text, _
                                                         Me.txtTAAPAVIN.Text, _
                                                         Me.txtTAAPAVFI.Text, _
                                                         Me.cboTAAPESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboTAAPDEPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboTAAPDEPA.Focus()
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
        Me.cboTAAPDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_TARIALPU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboTAAPDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTAAPDEPA.KeyPress, cboTAAPMUNI.KeyPress, cboTAAPCLSE.KeyPress, cboTAAPVIGE.KeyPress, cboTAAPTIPO.KeyPress, txtTAAPTARE.KeyPress, txtTAAPTACO.KeyPress, txtTAAPTAIN.KeyPress, cboTAAPESTR.KeyPress, txtTAAPTA01.KeyPress, txtTAAPTA02.KeyPress, txtTAAPTA03.KeyPress, txtTAAPTA04.KeyPress, txtTAAPTA05.KeyPress, txtTAAPAVIN.KeyPress, txtTAAPAVFI.KeyPress, cboTAAPESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTAAPDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAAPDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTAAPDEPA, Me.cboTAAPDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAAPMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAAPMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTAAPMUNI, Me.cboTAAPMUNI.SelectedIndex, Me.cboTAAPDEPA)
        End If
    End Sub
    Private Sub cboTAAPCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAAPCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTAAPCLSE, Me.cboTAAPCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAAPVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAAPVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTAAPVIGE, Me.cboTAAPVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAAPTIPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAAPTIPO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboTAAPTIPO, Me.cboTAAPTIPO.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAAPESTR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAAPESTR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboTAAPESTR, Me.cboTAAPESTR.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAAPESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAAPESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTAAPESTA, Me.cboTAAPESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAAPTARE.GotFocus, txtTAAPTACO.GotFocus, txtTAAPTAIN.GotFocus, txtTAAPTA01.GotFocus, txtTAAPTA02.GotFocus, txtTAAPTA03.GotFocus, txtTAAPTA04.GotFocus, txtTAAPTA05.GotFocus, txtTAAPAVIN.GotFocus, txtTAAPAVFI.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAAPDEPA.GotFocus, cboTAAPMUNI.GotFocus, cboTAAPCLSE.GotFocus, cboTAAPVIGE.GotFocus, cboTAAPTIPO.GotFocus, cboTAAPESTR.GotFocus, cboTAAPESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTAAPDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAAPDEPA.SelectedIndexChanged
        Me.lblTAAPDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboTAAPDEPA), String)

        Me.cboTAAPMUNI.DataSource = New DataTable
        Me.lblTAAPMUNI.Text = ""
    End Sub
    Private Sub cboTAAPMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAAPMUNI.SelectedIndexChanged
        Me.lblTAAPMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboTAAPDEPA, Me.cboTAAPMUNI), String)
    End Sub
    Private Sub cboTAAPCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAAPCLSE.SelectedIndexChanged
        Me.lblTAAPCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboTAAPCLSE), String)
    End Sub
    Private Sub cboTAAPVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAAPVIGE.SelectedIndexChanged
        Me.lblTAAPVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboTAAPVIGE), String)
    End Sub
    Private Sub cboTAAPTIPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAAPTIPO.SelectedIndexChanged
        Me.lblTAAPTIPO.Text = CType(fun_Buscar_Lista_Valores_TIPOCALI_Codigo(Me.cboTAAPTIPO), String)
    End Sub
    Private Sub cboTAAPESTR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAAPESTR.SelectedIndexChanged
        Me.lblTAAPESTR.Text = CType(fun_Buscar_Lista_Valores_ESTRATO_Codigo(Me.cboTAAPESTR), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTAAPDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAAPDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTAAPDEPA, Me.cboTAAPDEPA.SelectedIndex)
    End Sub
    Private Sub cboTAAPMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAAPMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTAAPMUNI, Me.cboTAAPMUNI.SelectedIndex, Me.cboTAAPDEPA)
    End Sub
    Private Sub cboTAAPCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAAPCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTAAPCLSE, Me.cboTAAPCLSE.SelectedIndex)
    End Sub
    Private Sub cboTAAPVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAAPVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTAAPVIGE, Me.cboTAAPVIGE.SelectedIndex)
    End Sub
    Private Sub cboTAAPTIPO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAAPTIPO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboTAAPTIPO, Me.cboTAAPTIPO.SelectedIndex)
    End Sub
    Private Sub cboTAAPESTR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAAPESTR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboTAAPESTR, Me.cboTAAPESTR.SelectedIndex)
    End Sub
    Private Sub cboTAAPESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAAPESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTAAPESTA, Me.cboTAAPESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTAAPAVFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAAPTARE.Validated, txtTAAPTACO.Validated, txtTAAPTAIN.Validated, txtTAAPTA01.Validated, txtTAAPTA02.Validated, txtTAAPTA03.Validated, txtTAAPTA04.Validated, txtTAAPTA05.Validated, txtTAAPAVIN.Validated, txtTAAPAVFI.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTAAPTARE.Text) = True Then
                Me.txtTAAPTARE.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTAAPTARE.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTAAPTACO.Text) = True Then
                Me.txtTAAPTACO.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTAAPTACO.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTAAPTAIN.Text) = True Then
                Me.txtTAAPTAIN.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTAAPTAIN.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTAAPAVIN.Text) = True Then
                Me.txtTAAPAVIN.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTAAPAVIN.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTAAPAVFI.Text) = True Then
                Me.txtTAAPAVFI.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTAAPAVFI.Text)
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