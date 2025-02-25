Imports REGLAS_DEL_NEGOCIO

Public Class frm_Insertar_CODICALI

    '========================================
    '*** INSERTAR CÓDIGOS DE CALIFICACIÓN ***
    '========================================

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboCOCAESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboCOCAESTA.DisplayMember = "ESTADESC"
        cboCOCAESTA.ValueMember = "ESTACODI"

    End Sub
    Private Sub pro_LimpiarCampos()

        txtCOCACODI.Text = ""
        txtCOCADESC.Text = ""
        txtCOCACOPA.Text = ""
        txtCOCACOHI.Text = ""
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtCOCACODI, "")

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_5_DATOS(txtCOCACODI.Text, txtCOCADESC.Text, txtCOCACOPA.Text, txtCOCACOHI.Text, cboCOCAESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtCOCACODI.Focus()
            Else
                Dim id As Integer = Val(txtCOCACODI.Text)

                Dim objdatos1 As New cla_CODICALI
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_CODICALI(id)

                If tbl.Rows.Count > 0 Then
                    mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                    txtCOCACODI.Focus()
                Else
                    Dim objdatos As New cla_CODICALI

                    If (objdatos.fun_Insertar_MANT_CODICALI(Trim(txtCOCACODI.Text), Trim(txtCOCADESC.Text), Trim(txtCOCACOPA.Text), Trim(txtCOCACOHI.Text), Trim(cboCOCAESTA.SelectedValue))) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            pro_LimpiarCampos()
                            txtCOCACODI.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            txtCOCACODI.Focus()
                        End If
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtCOCACODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_CLASSECT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        txtCOCACODI.Focus()
    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtCOCACODI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCOCACODI.TextChanged
        If Trim(txtCOCACODI.Text) = "" Then
            ErrorProvider1.SetError(Me.txtCOCACODI, "")
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtCOCACODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCOCACODI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtCOCADESC.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtCOCADESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCOCADESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtCOCACOPA.Focus()
        End If
    End Sub
    Private Sub txtCOCACOPA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCOCACOPA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtCOCACOHI.Focus()
        End If
    End Sub
    Private Sub txtCOCACOHI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCOCACOHI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboCOCAESTA.Focus()
        End If
    End Sub
    Private Sub cboCOCAESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCOCAESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtCOCACODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCOCACODI.Validated
        Try
            If Trim(txtCOCACODI.Text) = "" Then
                txtCOCACODI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
                ErrorProvider1.SetError(Me.txtCOCACODI, "")
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""

                Dim Codigo As Integer = Val(txtCOCACODI.Text)

                Dim objdatos1 As New cla_CODICALI
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_CODICALI(Codigo)

                If tbl.Rows.Count > 0 Then
                    ErrorProvider1.SetError(Me.txtCOCACODI, "Código existente en la base de datos")
                    txtCOCACODI.Focus()
                Else
                    ErrorProvider1.SetError(Me.txtCOCACODI, "")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub txtCOCADESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCOCADESC.Validated
        If Trim(txtCOCADESC.Text) = "" Then
            txtCOCADESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtCOCACOPA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCOCACOPA.Validated
        If Trim(txtCOCACOPA.Text) = "" Then
            txtCOCACOPA.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtCOCACOHI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCOCACOHI.Validated
        If Trim(txtCOCACOHI.Text) = "" Then
            txtCOCACOHI.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboCOCAESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOCAESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub


#End Region

#Region "GotFocus"

    Private Sub txtCOCACODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCOCACODI.GotFocus
        txtCOCACODI.SelectionStart = 0
        txtCOCACODI.SelectionLength = Len(txtCOCACODI.Text)
        strBARRESTA.Items(0).Text = txtCOCACODI.AccessibleDescription
    End Sub
    Private Sub txtCOCADESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCOCADESC.GotFocus
        txtCOCADESC.SelectionStart = 0
        txtCOCADESC.SelectionLength = Len(txtCOCADESC.Text)
        strBARRESTA.Items(0).Text = txtCOCADESC.AccessibleDescription
    End Sub
    Private Sub txtCOCACOPA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCOCACOPA.GotFocus
        txtCOCACOPA.SelectionStart = 0
        txtCOCACOPA.SelectionLength = Len(txtCOCACOPA.Text)
        strBARRESTA.Items(0).Text = txtCOCACOPA.AccessibleDescription
    End Sub
    Private Sub txtCOCACOHI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCOCACOHI.GotFocus
        txtCOCACOHI.SelectionStart = 0
        txtCOCACOHI.SelectionLength = Len(txtCOCACOHI.Text)
        strBARRESTA.Items(0).Text = txtCOCACOHI.AccessibleDescription
    End Sub
    Private Sub cboCOCAESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOCAESTA.GotFocus
        cboCOCAESTA.SelectionStart = 0
        cboCOCAESTA.SelectionLength = Len(cboCOCAESTA.Text)
        strBARRESTA.Items(0).Text = cboCOCAESTA.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
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