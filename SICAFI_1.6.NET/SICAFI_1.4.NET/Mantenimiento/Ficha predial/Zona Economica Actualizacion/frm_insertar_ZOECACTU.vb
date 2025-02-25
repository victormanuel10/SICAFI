Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_ZOECACTU

    '==========================================
    '*** INSERTAR ZONA FISICA ACTUALIZACION ***
    '==========================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraZOECACTU)

        Me.lblZEACDEPA.Text = ""
        Me.lblZEACMUNI.Text = ""
        Me.lblZEACCLSE.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            Me.txtZEACVACO.Text = fun_Quita_Letras(Me.txtZEACVACO)
            Me.txtZEACVACA.Text = fun_Quita_Letras(Me.txtZEACVACA)

            ' instancia la clase
            Dim objdatos As New cla_ZOECACTU

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_ZOECACTU(Me.cboZEACDEPA, _
                                                                                                Me.cboZEACMUNI, _
                                                                                                Me.cboZEACCLSE, _
                                                                                                Me.txtZEACCODI)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boZFACDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboZEACDEPA)
            Dim boZFACMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboZEACMUNI)
            Dim boZFACCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboZEACCLSE)
            Dim boZFACCODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtZEACCODI)
            Dim boZEACVACO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtZEACVACO)
            Dim boZEACVACA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtZEACVACA)
            Dim boZFACDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtZEACDESC)
            Dim boZFACESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboZEACESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boZFACDEPA = True And _
               boZFACMUNI = True And _
               boZFACCLSE = True And _
               boZFACCODI = True And _
               boZEACVACO = True And _
               boZEACVACA = True And _
               boZFACDESC = True And _
               boZFACESTA = True Then

                Dim objdatos22 As New cla_ZOECACTU

                If (objdatos22.fun_Insertar_MANT_ZOECACTU(Me.cboZEACDEPA.SelectedValue, _
                                                          Me.cboZEACMUNI.SelectedValue, _
                                                          Me.cboZEACCLSE.SelectedValue, _
                                                          Me.txtZEACCODI.Text, _
                                                          Me.txtZEACVACO.Text, _
                                                          Me.txtZEACVACA.Text, _
                                                          Me.txtZEACDESC.Text, _
                                                          Me.cboZEACESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboZEACDEPA.Focus()
                        Me.Close()
                    Else
                        'pro_LimpiarCampos()
                        Me.cboZEACDEPA.Focus()
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
        Me.cboZEACDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_ZOECACTU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboZEACDEPA.Focus()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboZFACDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZEACDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboZEACDEPA, Me.cboZEACDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboZFACMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZEACMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboZEACMUNI, Me.cboZEACMUNI.SelectedIndex, Me.cboZEACDEPA)
        End If
    End Sub
    Private Sub cboZFACCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZEACCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboZEACCLSE, Me.cboZEACCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboZFACESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZEACESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboZEACESTA, Me.cboZEACESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboZEACDEPA.KeyPress, cboZEACMUNI.KeyPress, txtZEACCODI.KeyPress, txtZEACDESC.KeyPress, cboZEACESTA.KeyPress, txtZEACVACA.KeyPress, txtZEACVACO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZEACCODI.GotFocus, txtZEACDESC.GotFocus, txtZEACVACA.GotFocus, txtZEACVACO.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZEACDEPA.GotFocus, cboZEACMUNI.GotFocus, cboZEACESTA.GotFocus, cboZEACCLSE.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboZFACDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZEACDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboZEACDEPA, Me.cboZEACDEPA.SelectedIndex)
    End Sub
    Private Sub cboZFACMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZEACMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboZEACMUNI, Me.cboZEACMUNI.SelectedIndex, Me.cboZEACDEPA)
    End Sub
    Private Sub cboZFACCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZEACCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboZEACCLSE, Me.cboZEACCLSE.SelectedIndex)
    End Sub
    Private Sub cboZFACESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZEACESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboZEACESTA, Me.cboZEACESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboZFACDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZEACDEPA.SelectedIndexChanged
        Me.lblZEACDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboZEACDEPA), String)

        Me.cboZEACMUNI.DataSource = New DataTable
        Me.lblZEACMUNI.Text = ""

    End Sub
    Private Sub cboZFACMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZEACMUNI.SelectedIndexChanged
        Me.lblZEACMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboZEACDEPA, Me.cboZEACMUNI), String)
    End Sub
    Private Sub cboZFACCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZEACCLSE.SelectedIndexChanged
        Me.lblZEACCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboZEACCLSE), String)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtZEACVACO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZEACVACO.Validated, txtZEACVACA.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtZEACVACO.Text) = True Then

                If CInt(Me.txtZEACVACO.Text) <> 0 Then
                    Me.txtZEACVACA.Text = CInt(Me.txtZEACVACO.Text) * 0.6
                    Me.txtZEACVACA.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtZEACVACA.Text)
                End If

                Me.txtZEACVACO.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtZEACVACO.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtZEACVACA.Text) = True Then
                Me.txtZEACVACA.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtZEACVACA.Text)
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