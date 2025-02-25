Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_ZONAECON

    '===============================
    '*** INSERTAR ZONA ECONÓMICA ***
    '===============================

#Region "VARIABLES"

    Dim vl_boSWVerificaDatoAlGuardar As Boolean = True

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        '=========================================
        ' CARGA LOS COMBOBOX CON LOS DATOS ACTIVOS
        '=========================================

        Dim objdatos As New cla_ESTADO

        cboZOECESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboZOECESTA.DisplayMember = "ESTADESC"
        cboZOECESTA.ValueMember = "ESTACODI"

        Dim objdatos1 As New cla_DEPARTAMENTO

        cboZOECDEPA.DataSource = objdatos1.fun_Consultar_MANT_DEPARTAMENTO_X_ESTADO
        cboZOECDEPA.DisplayMember = "DEPACODI"
        cboZOECDEPA.ValueMember = "DEPACODI"


        Dim objdatos2 As New cla_CLASSECT

        cboZOECCLSE.DataSource = objdatos2.fun_Consultar_MANT_CLASSECT_X_ESTADO
        cboZOECCLSE.DisplayMember = "CLSECODI"
        cboZOECCLSE.ValueMember = "CLSECODI"


        '===========================================================================
        ' CARGA LA DESCRIPCIÓN DEL DEPARTAMENTO (Los reg. activos ya estan cargados)
        '===========================================================================
        Try
            Dim boZOECDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(cboZOECDEPA.SelectedValue)
            Dim boZOECCLSE As Boolean = fun_Buscar_Dato_CLASSECT(cboZOECCLSE.SelectedValue)

            If boZOECDEPA = True OrElse boZOECCLSE = True Then

                lblZOECDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(cboZOECDEPA.SelectedValue), String)
                lblZOECCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(cboZOECCLSE.SelectedValue), String)
            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        cboZOECDEPA.Focus()


    End Sub
    Private Sub pro_LimpiarCampos()

        txtZOECCODI.Text = ""
        txtZOECDESC.Text = ""
        txtZOECVALO.Text = "0"
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtZOECCODI, "")

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_7_DATOS(txtZOECCODI.Text, txtZOECDESC.Text, cboZOECDEPA.Text, cboZOECMUNI.Text, cboZOECCLSE.Text, txtZOECVALO.Text, cboZOECESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                cboZOECDEPA.Focus()
            Else
                If vl_boSWVerificaDatoAlGuardar = False Then
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    Dim idDepartamento As String = Trim(Me.cboZOECDEPA.Text)
                    Dim idMunicipio As String = Trim(Me.cboZOECMUNI.Text)
                    Dim idClaseOsector As Integer = Val(Me.cboZOECCLSE.Text)
                    Dim idZonaEconomica As Integer = Val(Me.txtZOECCODI.Text)

                    Dim objdatos1 As New cla_ZONAECON
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAECON(idDepartamento, idMunicipio, idClaseOsector, idZonaEconomica)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("Zona económica existente en la base de datos para el departamento, municipio y sector", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        cboZOECDEPA.Focus()
                    Else
                        Dim objdatos As New cla_ZONAECON

                        If (objdatos.fun_Insertar_MANT_ZONAECON(cboZOECDEPA.SelectedValue, cboZOECMUNI.SelectedValue, cboZOECCLSE.SelectedValue, txtZOECCODI.Text, txtZOECDESC.Text, txtZOECVALO.Text, cboZOECESTA.SelectedValue, Me.chkZOECZOCO.Checked, Trim(Me.txtZOECPOIN.Text))) Then
                            mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                            If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                                pro_LimpiarCampos()
                                cboZOECDEPA.Focus()
                                Me.Close()
                            Else
                                pro_LimpiarCampos()
                                cboZOECDEPA.Focus()
                            End If

                        Else
                            mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        cboZOECDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_ZONAECON_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        cboZOECDEPA.Focus()
    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtZOECCODI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtZOECCODI.TextChanged
        If Trim(txtZOECCODI.Text) = "" Then
            ErrorProvider1.SetError(Me.txtZOECCODI, "")
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboZOECDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZOECDEPA.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_DEPARTAMENTO()
        End If
    End Sub
    Private Sub cboZOECMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZOECMUNI.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_MUNICIPIO()
        End If
    End Sub
    Private Sub cboZOECCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZOECCLSE.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_CLASSECT()
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub cboZOECDEPA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboZOECDEPA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboZOECMUNI.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO(cboZOECDEPA, cboZOECDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboZOECMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboZOECMUNI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboZOECCLSE.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO(cboZOECMUNI, cboZOECDEPA.Text)
        End If
    End Sub
    Private Sub cboZOECCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboZOECCLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtZOECCODI.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT(cboZOECCLSE, cboZOECCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub txtZOECCODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtZOECCODI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtZOECDESC.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtZOECDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtZOECDESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtZOECVALO.Focus()
        End If
    End Sub
    Private Sub txtZOECVALO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtZOECVALO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboZOECESTA.Focus()
        End If
    End Sub
    Private Sub cboZOECESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboZOECESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            chkZOECZOCO.Focus()
        End If
    End Sub
    Private Sub chkZOECZOCO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkZOECZOCO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtZOECPOIN.Focus()
        End If
    End Sub
    Private Sub txtZOECPOIN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtZOECPOIN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtZOECCODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZOECCODI.Validated
        Try
            If Trim(txtZOECCODI.Text) = "" Then
                txtZOECCODI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
                ErrorProvider1.SetError(Me.txtZOECCODI, "")
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""

                Dim idDepartamento As String = cboZOECDEPA.Text
                Dim idMunicipio As String = cboZOECMUNI.Text
                Dim idClaseOsector As Integer = Val(cboZOECCLSE.Text)
                Dim idZonaEconomica As Integer = Val(txtZOECCODI.Text)

                Dim objdatos1 As New cla_ZONAECON
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAECON(idDepartamento, idMunicipio, idClaseOsector, idZonaEconomica)

                If tbl.Rows.Count > 0 Then
                    ErrorProvider1.SetError(Me.txtZOECCODI, "Código existente en la base de datos")
                    txtZOECCODI.Focus()
                Else
                    ErrorProvider1.SetError(Me.txtZOECCODI, "")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "10")
        End Try
    End Sub
    Private Sub txtZOECDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZOECDESC.Validated
        If Trim(txtZOECDESC.Text) = "" Then
            txtZOECDESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtZOECVALO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZOECVALO.Validated
        'If Trim(txtZOECVALO.Text) = "" Then
        '    txtZOECVALO.Text = 0
        '    strBARRESTA.Items(0).Text = ""
        '    strBARRESTA.Items(1).Text = ""
        'Else
        '    strBARRESTA.Items(0).Text = ""
        '    strBARRESTA.Items(1).Text = ""
        'End If


        If Trim(Me.txtZOECVALO.Text) = "" Then
            Me.txtZOECVALO.Text = "0"
        Else
            If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(Me.txtZOECVALO.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                Me.txtZOECVALO.Focus()
                strBARRESTA.Items(1).Text = IncoValoDeci
            Else
                vl_boSWVerificaDatoAlGuardar = True

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If

    End Sub
    Private Sub cboZOECESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZOECESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtZOECPOIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZOECPOIN.Validated

        If Trim(Me.txtZOECPOIN.Text) = "" Then
            Me.txtZOECPOIN.Text = "1.00"
        Else
            If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(Me.txtZOECPOIN.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                Me.txtZOECPOIN.Focus()
                strBARRESTA.Items(1).Text = IncoValoDeci
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Me.txtZOECPOIN.Text = fun_Formato_Decimal_2_Decimales(Me.txtZOECPOIN.Text)

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If

    End Sub

#End Region

#Region "GotFocus"

    Private Sub cboZOECDEPA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZOECDEPA.GotFocus
        strBARRESTA.Items(0).Text = cboZOECDEPA.AccessibleDescription
    End Sub
    Private Sub cboZOECMUNI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZOECMUNI.GotFocus
        strBARRESTA.Items(0).Text = cboZOECMUNI.AccessibleDescription
    End Sub
    Private Sub cboZOECCLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZOECCLSE.GotFocus
        strBARRESTA.Items(0).Text = cboZOECCLSE.AccessibleDescription
    End Sub
    Private Sub txtZOECCODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZOECCODI.GotFocus
        txtZOECCODI.SelectionStart = 0
        txtZOECCODI.SelectionLength = Len(txtZOECCODI.Text)
        strBARRESTA.Items(0).Text = txtZOECCODI.AccessibleDescription
    End Sub
    Private Sub txtZOECDESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZOECDESC.GotFocus
        txtZOECDESC.SelectionStart = 0
        txtZOECDESC.SelectionLength = Len(txtZOECDESC.Text)
        strBARRESTA.Items(0).Text = txtZOECDESC.AccessibleDescription
    End Sub
    Private Sub txtZOECVALO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZOECVALO.GotFocus
        txtZOECVALO.SelectionStart = 0
        txtZOECVALO.SelectionLength = Len(txtZOECVALO.Text)
        strBARRESTA.Items(0).Text = txtZOECVALO.AccessibleDescription
    End Sub
    Private Sub cboZOECESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZOECESTA.GotFocus
        strBARRESTA.Items(0).Text = cboZOECESTA.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub chkZOECZOCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkZOECZOCO.GotFocus
        strBARRESTA.Items(0).Text = chkZOECZOCO.AccessibleDescription
    End Sub
    Private Sub txtZOECPOIN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZOECPOIN.GotFocus
        txtZOECPOIN.SelectionStart = 0
        txtZOECPOIN.SelectionLength = Len(txtZOECPOIN.Text)
        strBARRESTA.Items(0).Text = txtZOECPOIN.AccessibleDescription
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboZOECDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZOECDEPA.SelectedIndexChanged
        lblZOECDEPA.Text = fun_Buscar_Lista_Valores_DEPARTAMENTO(Trim(cboZOECDEPA.Text))
        lblZOECMUNI.Text = ""

        Call cboZOECMUNI_Click(cboZOECMUNI, New System.EventArgs)
        Call cboZOECMUNI_SelectedIndexChanged(cboZOECMUNI, New System.EventArgs)
    End Sub
    Private Sub cboZOECMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZOECMUNI.SelectedIndexChanged
        lblZOECMUNI.Text = fun_Buscar_Lista_Valores_MUNICIPIO(Trim(cboZOECDEPA.Text), Trim(cboZOECMUNI.Text))
    End Sub
    Private Sub cboZOECCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZOECCLSE.SelectedIndexChanged
        lblZOECCLSE.Text = fun_Buscar_Lista_Valores_CLASSECT(cboZOECCLSE.Text)
    End Sub

#End Region

#Region "Click"

    Private Sub cboZOECMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZOECMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO(cboZOECMUNI, Trim(cboZOECDEPA.Text))
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