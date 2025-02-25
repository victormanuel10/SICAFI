Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_TIPOCONS

    '======================================
    '*** MODIFICAR TIPO DE CONSTRUCCIÓN ***
    '======================================

#Region "VARIABLES"

    Dim id As Integer
    Dim vl_boSWVerificaDatoAlGuardar As Boolean = True

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal idDataGrid As Integer)
        id = idDataGrid
        InitializeComponent()
        pro_inicializarControles()

    End Sub

#End Region
    
#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()
        '=========================================
        ' CARGA LOS COMBOBOX CON LOS DATOS ACTIVOS
        '=========================================

        Dim objdatos1 As New cla_DEPARTAMENTO

        cboTICODEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
        cboTICODEPA.DisplayMember = "DEPACODI"
        cboTICODEPA.ValueMember = "DEPACODI"

        Dim objdatos7 As New cla_MUNICIPIO

        cboTICOMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
        cboTICOMUNI.DisplayMember = "MUNICODI"
        cboTICOMUNI.ValueMember = "MUNICODI"

        Dim objdatos2 As New cla_CLASCONS

        cboTICOCLCO.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASCONS
        cboTICOCLCO.DisplayMember = "CLCOCODI"
        cboTICOCLCO.ValueMember = "CLCOCODI"

        Dim objdatos9 As New cla_CLASSECT

        cboTICOCLSE.DataSource = objdatos9.fun_Consultar_CAMPOS_MANT_CLASSECT
        cboTICOCLSE.DisplayMember = "CLSECODI"
        cboTICOCLSE.ValueMember = "CLSECODI"

        Dim objdatos As New cla_ESTADO

        cboTICOESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboTICOESTA.DisplayMember = "ESTADESC"
        cboTICOESTA.ValueMember = "ESTACODI"

        Dim objdatos11 As New cla_TIPOCALI

        cboTICOTIPO.DataSource = objdatos11.fun_Consultar_CAMPOS_MANT_TIPOCALI
        cboTICOTIPO.DisplayMember = "TICACODI"
        cboTICOTIPO.ValueMember = "TICACODI"

        Dim objdatos3 As New cla_TIPOCONS
        Dim tbl As New DataTable

        tbl = objdatos3.fun_Buscar_ID_MANT_TIPOCONS(id)

        cboTICODEPA.SelectedValue = tbl.Rows(0).Item(1)
        cboTICOMUNI.SelectedValue = tbl.Rows(0).Item(2)
        cboTICOCLCO.SelectedValue = tbl.Rows(0).Item(3)
        cboTICOTIPO.SelectedValue = tbl.Rows(0).Item(4)
        txtTICOCODI.Text = Trim(tbl.Rows(0).Item(5))
        txtTICODESC.Text = Trim(tbl.Rows(0).Item(6))
        txtTICOPUNT.Text = Trim(tbl.Rows(0).Item(7))
        txtTICOPUMA.Text = Trim(tbl.Rows(0).Item(8))
        txtTICOFAC1.Text = Trim(tbl.Rows(0).Item(9))
        txtTICOFAC2.Text = Trim(tbl.Rows(0).Item(10))
        cboTICOMOLI.SelectedItem = Trim(tbl.Rows(0).Item(11))
        chkTICOARCO.Checked = tbl.Rows(0).Item(12)
        cboTICOESTA.SelectedValue = tbl.Rows(0).Item(13)
        cboTICOCLSE.SelectedValue = tbl.Rows(0).Item(14)
        Me.txtTICOPOIN.Text = Trim(tbl.Rows(0).Item("TICOPOIN"))

        '=====================
        ' CARGA LA DESCRIPCIÓN 
        '=====================

        Try
            Dim boTICODEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(cboTICODEPA.SelectedValue)
            Dim boTICOMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(cboTICODEPA.SelectedValue, cboTICOMUNI.SelectedValue)
            Dim boTICOCLCO As Boolean = fun_Buscar_Dato_CLASCONS(cboTICOCLCO.SelectedValue)
            Dim boTICOCLSE As Boolean = fun_Buscar_Dato_CLASSECT(cboTICOCLSE.SelectedValue)
            Dim boTICOTIPO As Boolean = fun_Buscar_Dato_TIPOCALI(cboTICOTIPO.SelectedValue)

            If boTICODEPA = True OrElse boTICOCLCO = True OrElse boTICOMUNI = True OrElse _
               boTICOCLSE = True OrElse boTICOTIPO = True Then

                lblTICODEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(cboTICODEPA.SelectedValue), String)
                lblTICOMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(cboTICODEPA.SelectedValue, cboTICOMUNI.SelectedValue), String)
                lblTICOCLCO.Text = CType(fun_Buscar_Lista_Valores_CLASCONS(cboTICOCLCO.SelectedValue), String)
                lblTICOCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(cboTICOCLSE.SelectedValue), String)
                lblTICOTIPO.Text = CType(fun_Buscar_Lista_Valores_TIPOCALI(cboTICOTIPO.SelectedValue), String)
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        txtTICODESC.Focus()

    End Sub
    Private Sub pro_LimpiarCampos()

        txtTICOCODI.Text = ""
        txtTICODESC.Text = ""
        txtTICOPUNT.Text = ""
        txtTICOPUMA.Text = ""
        txtTICOFAC1.Text = "" '"0.0000000000"
        txtTICOFAC2.Text = "" '"0.0000000000"
        cboTICOMOLI.SelectedIndex = 0
        chkTICOARCO.Checked = False
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_13_DATOS(cboTICODEPA.Text, cboTICOMUNI.Text, cboTICOCLCO.Text, cboTICOTIPO.Text, cboTICOCLSE.Text, txtTICOCODI.Text, txtTICODESC.Text, txtTICOPUNT.Text, txtTICOPUMA.Text, txtTICOFAC1.Text, txtTICOFAC2.Text, cboTICOMOLI.Text, cboTICOESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtTICOCODI.Focus()
            Else
                If vl_boSWVerificaDatoAlGuardar = False Then
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    Dim objdatos As New cla_TIPOCONS

                    If (objdatos.fun_Actualizar_MANT_TIPOCONS(id, cboTICODEPA.SelectedValue, cboTICOMUNI.SelectedValue, cboTICOCLCO.SelectedValue, cboTICOTIPO.Text, txtTICOCODI.Text, txtTICODESC.Text, txtTICOPUNT.Text, txtTICOPUMA.Text, txtTICOFAC1.Text, txtTICOFAC2.Text, cboTICOMOLI.Text, chkTICOARCO.Checked, cboTICOESTA.SelectedValue, cboTICOCLSE.SelectedValue, Trim(Me.txtTICOPOIN.Text))) Then
                        mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                        txtTICODESC.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Modificar")
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtTICODESC.Focus()
        Me.Close()

    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub cboTICODEPA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTICODEPA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTICOMUNI.Focus()
        End If
    End Sub
    Private Sub cboTICOMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTICOMUNI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTICOCLCO.Focus()
        End If
    End Sub
    Private Sub cboTICOCLCO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTICOCLCO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTICOTIPO.Focus()
        End If
    End Sub
    Private Sub cboTICOTIPO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTICOTIPO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTICOCODI.Focus()
        End If
    End Sub
    Private Sub txtTICOCODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTICOCODI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.A) Then
                    If e.KeyChar <> Convert.ToChar(Keys.B) Then
                        If e.KeyChar <> Convert.ToChar(Keys.C) Then
                            If e.KeyChar <> Convert.ToChar(Keys.D) Then
                                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                                    e.Handled = True
                                    strBARRESTA.Items(1).Text = IncoValoNume
                                    mod_MENSAJE.Inco_Valo_Nume()
                                Else
                                    txtTICODESC.Focus()
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
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

        'If Not Char.IsNumber(e.KeyChar) Then
        '    If e.KeyChar <> Convert.ToChar(Keys.Back) Then
        '        If e.KeyChar <> Convert.ToChar(Chr(46)) Then
        '            If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
        '                e.Handled = True
        '                strBARRESTA.Items(1).Text = IncoValoNume
        '                mod_MENSAJE.Inco_Valo_Nume()
        '            Else
        '                txtTICOFAC2.Focus()
        '            End If
        '        End If
        '    End If
        'End If
    End Sub
    Private Sub txtTICOFAC2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTICOFAC2.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTICOMOLI.Focus()
        End If

        'If Not Char.IsNumber(e.KeyChar) Then
        '    If e.KeyChar <> Convert.ToChar(Keys.Back) Then
        '        If e.KeyChar <> Convert.ToChar(Chr(46)) Then
        '            If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
        '                e.Handled = True
        '                strBARRESTA.Items(1).Text = IncoValoNume
        '                mod_MENSAJE.Inco_Valo_Nume()
        '            Else
        '                cboTICOMOLI.Focus()
        '            End If
        '        End If
        '    End If
        'End If
    End Sub
    Private Sub cboTICOMOLI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTICOMOLI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTICOESTA.Focus()
        End If
    End Sub
    Private Sub cboTICOESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTICOESTA.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtTICOPOIN.Focus()
        End If

    End Sub
    Private Sub txtTICOPOIN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTICOPOIN.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            chkTICOARCO.Focus()
        End If

    End Sub
    Private Sub chkTICOARCO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkTICOARCO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region
   
#Region "Validated"

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
        'If Trim(txtTICOFAC1.Text) = "" Then
        '    txtTICOFAC1.Focus()
        '    strBARRESTA.Items(1).Text = IncoValoNulo
        'Else
        '    strBARRESTA.Items(0).Text = ""
        '    strBARRESTA.Items(1).Text = ""
        'End If

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
        'If Trim(txtTICOFAC2.Text) = "" Then
        '    txtTICOFAC2.Focus()
        '    strBARRESTA.Items(1).Text = IncoValoNulo
        'Else
        '    strBARRESTA.Items(0).Text = ""
        '    strBARRESTA.Items(1).Text = ""
        'End If

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
        cboTICODEPA.SelectionStart = 0
        cboTICODEPA.SelectionLength = Len(cboTICODEPA.Text)
        strBARRESTA.Items(0).Text = cboTICODEPA.AccessibleDescription
    End Sub
    Private Sub cboTICOMUNI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTICOMUNI.GotFocus
        cboTICOMUNI.SelectionStart = 0
        cboTICOMUNI.SelectionLength = Len(cboTICOMUNI.Text)
        strBARRESTA.Items(0).Text = cboTICOMUNI.AccessibleDescription
    End Sub
    Private Sub cboTICOCLCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTICOCLCO.GotFocus
        cboTICOCLCO.SelectionStart = 0
        cboTICOCLCO.SelectionLength = Len(cboTICOCLCO.Text)
        strBARRESTA.Items(0).Text = cboTICOCLCO.AccessibleDescription
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

    Private Sub cboTICOMOLI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTICOMOLI.SelectedIndexChanged
        Dim seleccion As String

        seleccion = cboTICOMOLI.SelectedItem

        Dim sw1, j1 As Integer

        While j1 < cboTICOMOLI.Items.Count And sw1 = 0
            If seleccion = cboTICOMOLI.Items(j1).ToString Then
                cboTICOMOLI.Text = seleccion
                sw1 = 1
            Else
                j1 = j1 + 1
            End If
        End While

        'Dim seleccion1 As Integer

        'seleccion1 = cboTICOCLCO.SelectedIndex

        'Select Case seleccion1

        '    Case 0 : cboTICOCLCO.SelectedText = Me.cboTICOCLCO.Items(0).ToString
        '    Case 1 : cboTICOCLCO.SelectedText = Me.cboTICOCLCO.Items(1).ToString
        '    Case 2 : cboTICOCLCO.SelectedText = Me.cboTICOCLCO.Items(2).ToString
        '    Case 3 : cboTICOCLCO.SelectedText = Me.cboTICOCLCO.Items(3).ToString
        'End Select


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