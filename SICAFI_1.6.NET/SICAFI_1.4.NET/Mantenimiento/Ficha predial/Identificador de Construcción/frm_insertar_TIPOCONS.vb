Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_TIPOCONS

    '=====================================
    '*** INSERTAR TIPO DE CONSTRUCCIÓN ***
    '=====================================

#Region "VARIABLES"

    Dim vl_boSWVerificaDatoAlGuardar As Boolean = True

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()

        '=========================================
        ' CARGA LOS COMBOBOX CON LOS DATOS ACTIVOS
        '=========================================

        Dim objdatos1 As New cla_DEPARTAMENTO

        cboTICODEPA.DataSource = objdatos1.fun_Consultar_MANT_DEPARTAMENTO_X_ESTADO
        cboTICODEPA.DisplayMember = "DEPACODI"
        cboTICODEPA.ValueMember = "DEPACODI"

        Dim objdatos2 As New cla_CLASCONS

        cboTICOCLCO.DataSource = objdatos2.fun_Consultar_MANT_CLASCONS_X_ESTADO
        cboTICOCLCO.DisplayMember = "CLCOCODI"
        cboTICOCLCO.ValueMember = "CLCOCODI"

        Dim objdatos As New cla_ESTADO

        cboTICOESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboTICOESTA.DisplayMember = "ESTADESC"
        cboTICOESTA.ValueMember = "ESTACODI"

        Dim objdatos5 As New cla_CLASSECT

        cboTICOCLSE.DataSource = objdatos5.fun_Consultar_MANT_CLASSECT_X_ESTADO
        cboTICOCLSE.DisplayMember = "CLSECODI"
        cboTICOCLSE.ValueMember = "CLSECODI"

        Dim objdatos7 As New cla_TIPOCALI

        cboTICOTIPO.DataSource = objdatos7.fun_Consultar_MANT_TIPOCALI_X_ESTADO
        cboTICOTIPO.DisplayMember = "TICACODI"
        cboTICOTIPO.ValueMember = "TICACODI"


        '===========================================================================
        ' CARGA LA DESCRIPCIÓN DEL DEPARTAMENTO (Los reg. activos ya estan cargados)
        '===========================================================================
        Try
            Dim boTICODEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(cboTICODEPA.SelectedValue)
            Dim boTICOCLCO As Boolean = fun_Buscar_Dato_CLASCONS(cboTICOCLCO.SelectedValue)
            Dim boTICOCLSE As Boolean = fun_Buscar_Dato_CLASSECT(cboTICOCLSE.SelectedValue)
            Dim boTICOTIPO As Boolean = fun_Buscar_Dato_TIPOCALI(cboTICOTIPO.SelectedValue)

            If boTICODEPA = True OrElse boTICOCLCO = True OrElse _
               boTICOCLSE = True OrElse boTICOTIPO = True Then

                lblTICODEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(cboTICODEPA.SelectedValue), String)
                lblTICOCLCO.Text = CType(fun_Buscar_Lista_Valores_CLASCONS(cboTICOCLCO.SelectedValue), String)
                lblTICOCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(cboTICOCLSE.SelectedValue), String)
                lblTICOTIPO.Text = CType(fun_Buscar_Lista_Valores_TIPOCALI(cboTICOTIPO.SelectedValue), String)

                '*** Carga los item de la colección por defecto ***
                cboTICOTIPO.SelectedIndex = 0
                cboTICOMOLI.SelectedIndex = 0
                txtTICOPUNT.Text = "0"
                txtTICOPUMA.Text = "100"
                txtTICOFAC1.Text = "0"
                txtTICOFAC2.Text = "0"
                cboTICODEPA.Focus()
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        txtTICOCODI.Text = ""
        txtTICODESC.Text = ""
        txtTICOPUNT.Text = "0"
        txtTICOPUMA.Text = "100"
        txtTICOFAC1.Text = "0" '"0.0000000000"
        txtTICOFAC2.Text = "0" '"0.0000000000"
        cboTICOMOLI.SelectedIndex = 0
        chkTICOARCO.Checked = False
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtTICOCODI, "")

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_13_DATOS(cboTICODEPA.Text, cboTICOMUNI.Text, cboTICOCLCO.Text, cboTICOTIPO.Text, cboTICOCLSE.Text, txtTICOCODI.Text, txtTICODESC.Text, txtTICOPUNT.Text, txtTICOPUMA.Text, txtTICOFAC1.Text, txtTICOFAC2.Text, cboTICOMOLI.Text, cboTICOESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                cboTICODEPA.Focus()
            Else
                If vl_boSWVerificaDatoAlGuardar = False Then
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    Dim idDepartamento As String = cboTICODEPA.Text
                    Dim idMunicipio As String = cboTICOMUNI.Text
                    Dim idClaseConstruccion As Integer = Val(cboTICOCLCO.Text)
                    Dim idTipo As String = cboTICOTIPO.Text
                    Dim idClaseoSector As Integer = Val(cboTICOCLSE.Text)
                    Dim idIdentificador As String = fun_Formato_Mascara_3_String(Trim(txtTICOCODI.Text))

                    Dim objdatos1 As New cla_TIPOCONS
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_CLASE_Y_TIPO_Y_SECTOR_Y_CODIGO_MANT_TIPOCONS(idDepartamento, idMunicipio, idClaseConstruccion, idTipo, idClaseoSector, idIdentificador)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("Identificador existente en la base de datos", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        cboTICODEPA.Focus()
                    Else
                        Dim objdatos As New cla_TIPOCONS

                        If (objdatos.fun_Insertar_MANT_TIPOCONS(cboTICODEPA.SelectedValue, cboTICOMUNI.SelectedValue, cboTICOCLCO.SelectedValue, cboTICOTIPO.Text, txtTICOCODI.Text, txtTICODESC.Text, txtTICOPUNT.Text, txtTICOPUMA.Text, txtTICOFAC1.Text, txtTICOFAC2.Text, cboTICOMOLI.Text, chkTICOARCO.Checked, cboTICOESTA.SelectedValue, cboTICOCLSE.SelectedValue, Trim(Me.txtTICOPOIN.Text))) Then
                            mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                            If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                                pro_LimpiarCampos()
                                cboTICODEPA.Focus()
                                Me.Close()
                            Else
                                pro_LimpiarCampos()
                                cboTICODEPA.Focus()
                            End If
                        Else
                            mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Guardar")
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        cboTICODEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_TIPOCONS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        txtTICOCODI.Focus()
    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtTICOCODI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTICOCODI.TextChanged
        If Trim(txtTICOCODI.Text) = "" Then
            ErrorProvider1.SetError(Me.txtTICOCODI, "")
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub cboTICODEPA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTICODEPA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTICOMUNI.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO(cboTICODEPA, cboTICODEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboTICOMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTICOMUNI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTICOCLCO.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO(cboTICOMUNI, Trim(cboTICODEPA.Text))
        End If
    End Sub
    Private Sub cboTICOCLCO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTICOCLCO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTICOTIPO.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASCONS(cboTICOCLCO, cboTICOCLCO.SelectedIndex)
        End If
    End Sub
    Private Sub cboTICOTIPO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTICOTIPO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTICOCLSE.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI(cboTICOTIPO, cboTICOTIPO.SelectedIndex)
        End If
    End Sub
    Private Sub cboTICOCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTICOCLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTICOCODI.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT(cboTICOCLSE, cboTICOCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub txtTICOCODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTICOCODI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTICODESC.Focus()
        End If

        'If Not Char.IsNumber(e.KeyChar) Then
        '    If e.KeyChar <> Convert.ToChar(Keys.Back) Then
        '        If e.KeyChar <> Convert.ToChar(Keys.A) Then
        '            If e.KeyChar <> Convert.ToChar(Keys.B) Then
        '                If e.KeyChar <> Convert.ToChar(Keys.C) Then
        '                    If e.KeyChar <> Convert.ToChar(Keys.D) Then
        '                        If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
        '                            e.Handled = True
        '                            strBARRESTA.Items(1).Text = IncoValoNume
        '                            mod_MENSAJE.Inco_Valo_Nume()
        '                        Else
        '                            txtTICODESC.Focus()
        '                        End If
        '                    End If
        '                End If
        '            End If
        '        End If
        '    End If
        'End If
    End Sub
    Private Sub txtTICODESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTICODESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then

            If txtTICOPUNT.Enabled = True Then
                txtTICOPUNT.Focus()
            Else
                txtTICOPUMA.Focus()
            End If

        End If
    End Sub
    Private Sub txtTICOPUNT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTICOPUNT.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtTICOPUMA.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtTICOPUMA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTICOPUMA.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtTICOFAC1.Focus()
                End If
            End If
        End If

    End Sub
    Private Sub txtTICOFAC1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTICOFAC1.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTICOFAC2.Focus()
        End If

    End Sub
    Private Sub txtTICOFAC2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTICOFAC2.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTICOMOLI.Focus()
        End If

    End Sub
    Private Sub cboTICOMOLI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTICOMOLI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTICOESTA.Focus()
        End If
    End Sub
    Private Sub cboTICOESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTICOESTA.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtTICOPOIN.Focus()
        End If

    End Sub
    Private Sub txtTICOPOIN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTICOPOIN.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.chkTICOARCO.Focus()
        End If

    End Sub

    Private Sub chkTICOARCO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkTICOARCO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTICODEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTICODEPA.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_DEPARTAMENTO()
        End If
    End Sub
    Private Sub cboTICOMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTICOMUNI.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_MUNICIPIO()
        End If
    End Sub
    Private Sub cboTICOCLCO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTICOCLCO.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_CLASCONS()
        End If
    End Sub
    Private Sub cboTICOTIPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTICOTIPO.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_TIPOCALI()
        End If
    End Sub
    Private Sub cboTICOCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTICOCLSE.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_CLASSECT()
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTICOCODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICOCODI.Validated
        Try
            If Trim(txtTICOCODI.Text) = "" Then
                txtTICOCODI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
                ErrorProvider1.SetError(Me.txtTICOCODI, "")
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""

                Dim idDepartamento As String = Trim(cboTICODEPA.Text)
                Dim idMunicipio As String = Trim(cboTICOMUNI.Text)
                Dim idClaseConstruccion As Integer = Val(cboTICOCLCO.Text)
                Dim idTipo As String = Trim(cboTICOTIPO.Text)
                Dim idClaseoSector As Integer = Val(cboTICOCLSE.Text)
                Dim idIdentificador As String = fun_Formato_Mascara_3_String(Trim(txtTICOCODI.Text))

                Dim objdatos1 As New cla_TIPOCONS
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_CLASE_Y_TIPO_Y_SECTOR_Y_CODIGO_MANT_TIPOCONS(idDepartamento, idMunicipio, idClaseConstruccion, idTipo, idClaseoSector, idIdentificador)

                If tbl.Rows.Count > 0 Then
                    ErrorProvider1.SetError(Me.txtTICOCODI, "Código existente en la base de datos")
                    txtTICOCODI.Focus()
                Else
                    ErrorProvider1.SetError(Me.txtTICOCODI, "")

                    txtTICOCODI.Text = fun_Formato_Mascara_3_String(Trim(txtTICOCODI.Text))
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub txtTICODESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICODESC.Validated
        If Trim(txtTICODESC.Text) = "" Then
            txtTICODESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtTICOPUNT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICOPUNT.Validated
        If Trim(txtTICOPUNT.Text) = "" Then
            txtTICOPUNT.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtTICOPUMA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICOPUMA.Validated
        If Trim(txtTICOPUMA.Text) = "" Then
            txtTICOPUMA.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtTICOFAC1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICOFAC1.Validated
        If Trim(Me.txtTICOFAC1.Text) = "" Then
            Me.txtTICOFAC1.Text = "0.00000000"
        Else
            If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(Me.txtTICOFAC1.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                Me.txtTICOFAC1.Focus()
                strBARRESTA.Items(1).Text = IncoValoDeci
            Else
                vl_boSWVerificaDatoAlGuardar = True

                'Me.txtTICOFAC1.Text = fun_Formato_Decimal_2_Decimales(Me.txtTICOFAC1.Text)

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtTICOFAC2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICOFAC2.Validated
        If Trim(Me.txtTICOFAC2.Text) = "" Then
            Me.txtTICOFAC2.Text = "0.00000000"
        Else
            If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(Me.txtTICOFAC2.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                Me.txtTICOFAC2.Focus()
                strBARRESTA.Items(1).Text = IncoValoDeci
            Else
                vl_boSWVerificaDatoAlGuardar = True

                'Me.txtTICOFAC2.Text = fun_Formato_Decimal_2_Decimales(Me.txtTICOFAC2.Text)

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub cboTICOESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTICOESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtTICOPOIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICOPOIN.Validated

        If Trim(Me.txtTICOPOIN.Text) = "" Then
            Me.txtTICOPOIN.Text = "1.00"
        Else
            If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(Me.txtTICOPOIN.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                Me.txtTICOPOIN.Focus()
                strBARRESTA.Items(1).Text = IncoValoDeci
            Else
                vl_boSWVerificaDatoAlGuardar = True

                Me.txtTICOPOIN.Text = fun_Formato_Decimal_2_Decimales(Me.txtTICOPOIN.Text)

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If

    End Sub

#End Region

#Region "GotFocus"

    Private Sub cboTICODEPA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTICODEPA.GotFocus
        strBARRESTA.Items(0).Text = cboTICODEPA.AccessibleDescription
    End Sub
    Private Sub cboTICOMUNI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTICOMUNI.GotFocus
        strBARRESTA.Items(0).Text = cboTICOMUNI.AccessibleDescription
    End Sub
    Private Sub cboTICOCLCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTICOCLCO.GotFocus
        strBARRESTA.Items(0).Text = cboTICOCLCO.AccessibleDescription
    End Sub
    Private Sub cboTICOCLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTICOCLSE.GotFocus
        strBARRESTA.Items(0).Text = cboTICOCLSE.AccessibleDescription
    End Sub
    Private Sub txtTICOCODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICOCODI.GotFocus
        txtTICOCODI.SelectionStart = 0
        txtTICOCODI.SelectionLength = Len(txtTICOCODI.Text)
        strBARRESTA.Items(0).Text = txtTICOCODI.AccessibleDescription
    End Sub
    Private Sub txtTICODESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICODESC.GotFocus
        txtTICODESC.SelectionStart = 0
        txtTICODESC.SelectionLength = Len(txtTICODESC.Text)
        strBARRESTA.Items(0).Text = txtTICODESC.AccessibleDescription
    End Sub
    Private Sub cboTICOTIPO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTICOTIPO.GotFocus
        cboTICOTIPO.SelectionStart = 0
        cboTICOTIPO.SelectionLength = Len(cboTICOTIPO.Text)
        strBARRESTA.Items(0).Text = cboTICOTIPO.AccessibleDescription
    End Sub
    Private Sub txtTICOPUNT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICOPUNT.GotFocus
        txtTICOPUNT.SelectionStart = 0
        txtTICOPUNT.SelectionLength = Len(txtTICOPUNT.Text)
        strBARRESTA.Items(0).Text = txtTICOPUNT.AccessibleDescription
    End Sub
    Private Sub txtTICOPUMA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICOPUMA.GotFocus
        txtTICOPUMA.SelectionStart = 0
        txtTICOPUMA.SelectionLength = Len(txtTICOPUMA.Text)
        strBARRESTA.Items(0).Text = txtTICOPUMA.AccessibleDescription
    End Sub
    Private Sub txtTICOFAC1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICOFAC1.GotFocus
        txtTICOFAC1.SelectionStart = 0
        txtTICOFAC1.SelectionLength = Len(txtTICOFAC1.Text)
        strBARRESTA.Items(0).Text = txtTICOFAC1.AccessibleDescription
    End Sub
    Private Sub txtTICOFAC2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICOFAC2.GotFocus
        txtTICOFAC2.SelectionStart = 0
        txtTICOFAC2.SelectionLength = Len(txtTICOFAC2.Text)
        strBARRESTA.Items(0).Text = txtTICOFAC2.AccessibleDescription
    End Sub
    Private Sub cboTICOMOLI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTICOMOLI.GotFocus
        cboTICOMOLI.SelectionStart = 0
        cboTICOMOLI.SelectionLength = Len(cboTICOMOLI.Text)
        strBARRESTA.Items(0).Text = cboTICOMOLI.AccessibleDescription
    End Sub
    Private Sub chkTICOARCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkTICOARCO.GotFocus
        strBARRESTA.Items(0).Text = chkTICOARCO.AccessibleDescription
    End Sub
    Private Sub cboTICOESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTICOESTA.GotFocus
        cboTICOESTA.SelectionStart = 0
        cboTICOESTA.SelectionLength = Len(cboTICOESTA.Text)
        strBARRESTA.Items(0).Text = cboTICOESTA.AccessibleDescription
    End Sub
    Private Sub txtTICOPOIN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICOPOIN.GotFocus
        txtTICOPOIN.SelectionStart = 0
        txtTICOPOIN.SelectionLength = Len(txtTICOPOIN.Text)
        strBARRESTA.Items(0).Text = txtTICOPOIN.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub


#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTICODEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTICODEPA.SelectedIndexChanged
        lblTICODEPA.Text = fun_Buscar_Lista_Valores_DEPARTAMENTO(Trim(cboTICODEPA.Text))
        lblTICOMUNI.Text = ""

        Call cboTICOMUNI_Click(cboTICOMUNI, New System.EventArgs)
        Call cboTICOMUNI_SelectedIndexChanged(cboTICOMUNI, New System.EventArgs)
    End Sub
    Private Sub cboTICOMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTICOMUNI.SelectedIndexChanged
        lblTICOMUNI.Text = fun_Buscar_Lista_Valores_MUNICIPIO(Trim(cboTICODEPA.Text), Trim(cboTICOMUNI.Text))
    End Sub
    Private Sub cboTICOTIPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTICOTIPO.SelectedIndexChanged
        lblTICOTIPO.Text = fun_Buscar_Lista_Valores_TIPOCALI(Trim(cboTICOTIPO.Text))
    End Sub
    Private Sub cboTICOCLCO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTICOCLCO.SelectedIndexChanged
        lblTICOCLCO.Text = fun_Buscar_Lista_Valores_CLASCONS(cboTICOCLCO.Text)
    End Sub
    Private Sub cboTICOCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTICOCLSE.SelectedIndexChanged
        lblTICOCLSE.Text = fun_Buscar_Lista_Valores_CLASSECT(cboTICOCLSE.Text)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTICOMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTICOMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO(cboTICOMUNI, Trim(cboTICODEPA.Text))
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