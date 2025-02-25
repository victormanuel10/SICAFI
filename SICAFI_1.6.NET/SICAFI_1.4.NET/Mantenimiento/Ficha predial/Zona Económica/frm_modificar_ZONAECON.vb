Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_ZONAECON

    '================================
    '*** MODIFICAR ZONA ECONOMICA ***
    '================================

#Region "VARIABLES"

    Dim id As Integer
    Dim vl_boSWVerificaDatoAlGuardar As Boolean = True

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal idPersona As Integer)
        id = idPersona
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

        cboZOECDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
        cboZOECDEPA.DisplayMember = "DEPACODI"
        cboZOECDEPA.ValueMember = "DEPACODI"

        Dim objdatos7 As New cla_MUNICIPIO

        cboZOECMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
        cboZOECMUNI.DisplayMember = "MUNICODI"
        cboZOECMUNI.ValueMember = "MUNICODI"

        Dim objdatos2 As New cla_CLASSECT

        cboZOECCLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
        cboZOECCLSE.DisplayMember = "CLSECODI"
        cboZOECCLSE.ValueMember = "CLSECODI"

        Dim objdatos As New cla_ESTADO

        cboZOECESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboZOECESTA.DisplayMember = "ESTADESC"
        cboZOECESTA.ValueMember = "ESTACODI"

        Dim objdatos3 As New cla_ZONAECON
        Dim tbl As New DataTable

        tbl = objdatos3.fun_Buscar_ID_MANT_ZONAECON(id)

        Me.cboZOECDEPA.SelectedValue = tbl.Rows(0).Item(1)
        Me.cboZOECMUNI.SelectedValue = tbl.Rows(0).Item(2)
        Me.cboZOECCLSE.SelectedValue = tbl.Rows(0).Item(3)
        Me.txtZOECCODI.Text = Trim(tbl.Rows(0).Item(4))
        Me.txtZOECDESC.Text = Trim(tbl.Rows(0).Item(5))
        Me.txtZOECVALO.Text = Trim(tbl.Rows(0).Item(6))
        Me.cboZOECESTA.SelectedValue = tbl.Rows(0).Item(7)
        Me.chkZOECZOCO.Checked = tbl.Rows(0).Item(8)
        Me.txtZOECPOIN.Text = Trim(tbl.Rows(0).Item(9))

        '=====================
        ' CARGA LA DESCRIPCIÓN 
        '=====================

        Try
            Dim boZOECDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(cboZOECDEPA.SelectedValue)
            Dim boZOECMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(cboZOECDEPA.SelectedValue, cboZOECMUNI.SelectedValue)
            Dim boZOECCLSE As Boolean = fun_Buscar_Dato_CLASSECT(cboZOECCLSE.SelectedValue)

            If boZOECDEPA = True OrElse boZOECMUNI = True OrElse boZOECCLSE = True Then

                lblZOECMUNI.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(cboZOECDEPA.SelectedValue), String)
                lblZOECDEPA.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(cboZOECDEPA.SelectedValue, cboZOECMUNI.SelectedValue), String)
                lblZOECCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(cboZOECCLSE.SelectedValue), String)
            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        txtZOECDESC.Focus()

    End Sub
    Private Sub pro_LimpiarCampos()

        txtZOECVALO.Text = "0"
        txtZOECDESC.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_7_DATOS(txtZOECCODI.Text, txtZOECDESC.Text, cboZOECDEPA.Text, cboZOECMUNI.Text, cboZOECCLSE.Text, txtZOECVALO.Text, cboZOECESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtZOECDESC.Focus()
            Else
                If vl_boSWVerificaDatoAlGuardar = False Then
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    Dim objdatos As New cla_ZONAECON

                    If (objdatos.fun_Actualizar_MANT_ZONAECON(id, cboZOECDEPA.SelectedValue, cboZOECMUNI.SelectedValue, cboZOECCLSE.SelectedValue, txtZOECCODI.Text, txtZOECDESC.Text, txtZOECVALO.Text, cboZOECESTA.SelectedValue, Me.chkZOECZOCO.Checked, Trim(Me.txtZOECPOIN.Text))) Then
                        mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                        txtZOECDESC.Focus()
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
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtZOECDESC.Focus()
        Me.Close()

    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub cboZOECDEPA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboZOECDEPA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboZOECMUNI.Focus()
        End If
    End Sub
    Private Sub cboZOECMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboZOECMUNI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboZOECCLSE.Focus()
        End If
    End Sub
    Private Sub cboZOECCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboZOECCLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtZOECCODI.Focus()
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
        cboZOECDEPA.SelectionStart = 0
        cboZOECDEPA.SelectionLength = Len(cboZOECDEPA.Text)
        strBARRESTA.Items(0).Text = cboZOECDEPA.AccessibleDescription
    End Sub
    Private Sub cboZOECMUNI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZOECMUNI.GotFocus
        cboZOECMUNI.SelectionStart = 0
        cboZOECMUNI.SelectionLength = Len(cboZOECMUNI.Text)
        strBARRESTA.Items(0).Text = cboZOECMUNI.AccessibleDescription
    End Sub
    Private Sub cboZOECCLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZOECCLSE.GotFocus
        cboZOECCLSE.SelectionStart = 0
        cboZOECCLSE.SelectionLength = Len(cboZOECCLSE.Text)
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
        cboZOECESTA.SelectionStart = 0
        cboZOECESTA.SelectionLength = Len(cboZOECESTA.Text)
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