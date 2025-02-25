Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_DESTECON

    '======================================
    '*** INSERTAR DESTINACIÓN ECONÓMICA ***
    '======================================

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboDEECESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboDEECESTA.DisplayMember = "ESTADESC"
        cboDEECESTA.ValueMember = "ESTACODI"

    End Sub
    Private Sub pro_LimpiarCampos()

        txtDEECCODI.Text = ""
        txtDEECDESC.Text = ""
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtDEECCODI, "")

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(txtDEECCODI.Text, txtDEECDESC.Text, cboDEECESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtDEECCODI.Focus()
            Else
                Dim id As Integer = Val(txtDEECCODI.Text)

                Dim objdatos1 As New cla_DESTECON
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_CODIGO_MANT_DESTECON(id)

                If tbl.Rows.Count > 0 Then
                    mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                    txtDEECCODI.Focus()
                Else
                    Dim objdatos As New cla_DESTECON

                    If (objdatos.fun_Insertar_MANT_DESTECON(txtDEECCODI.Text, txtDEECDESC.Text, cboDEECESTA.SelectedValue, Me.chkDEECLOTE.Checked)) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            pro_LimpiarCampos()
                            txtDEECCODI.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            txtDEECCODI.Focus()
                        End If

                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Guardar")
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtDEECCODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_DESTECON_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        txtDEECCODI.Focus()
    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtDEECCODI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDEECCODI.TextChanged
        If Trim(txtDEECCODI.Text) = "" Then
            ErrorProvider1.SetError(Me.txtDEECCODI, "")
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtDEECCODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDEECCODI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtDEECDESC.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtDEECDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDEECDESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboDEECESTA.Focus()
        End If
    End Sub
    Private Sub cboDEECESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDEECESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtDEECCODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDEECCODI.Validated
        Try
            If Trim(txtDEECCODI.Text) = "" Then
                txtDEECCODI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
                ErrorProvider1.SetError(Me.txtDEECCODI, "")
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""

                Dim Codigo As Integer = Val(txtDEECCODI.Text)

                Dim objdatos1 As New cla_DESTECON
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_CODIGO_MANT_DESTECON(Codigo)

                If tbl.Rows.Count > 0 Then
                    ErrorProvider1.SetError(Me.txtDEECCODI, "Código existente en la base de datos")
                    txtDEECCODI.Focus()
                Else
                    ErrorProvider1.SetError(Me.txtDEECCODI, "")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub txtDEECDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDEECDESC.Validated
        If Trim(txtDEECDESC.Text) = "" Then
            txtDEECDESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboDEECESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDEECESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtDEECCODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDEECCODI.GotFocus
        txtDEECCODI.SelectionStart = 0
        txtDEECCODI.SelectionLength = Len(txtDEECCODI.Text)
        strBARRESTA.Items(0).Text = txtDEECCODI.AccessibleDescription
    End Sub
    Private Sub txtDEECDESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDEECDESC.GotFocus
        txtDEECDESC.SelectionStart = 0
        txtDEECDESC.SelectionLength = Len(txtDEECDESC.Text)
        strBARRESTA.Items(0).Text = txtDEECDESC.AccessibleDescription
    End Sub
    Private Sub cboDEECESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDEECESTA.GotFocus
        cboDEECESTA.SelectionStart = 0
        cboDEECESTA.SelectionLength = Len(cboDEECESTA.Text)
        strBARRESTA.Items(0).Text = cboDEECESTA.AccessibleDescription
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