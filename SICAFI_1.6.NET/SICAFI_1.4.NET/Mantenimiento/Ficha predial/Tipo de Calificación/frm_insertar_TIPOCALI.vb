Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_TIPOCALI

    '=====================================
    '*** INSERTAR TIPO DE CALIFICACIÓN ***
    '=====================================

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboTICAESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboTICAESTA.DisplayMember = "ESTADESC"
        cboTICAESTA.ValueMember = "ESTACODI"

    End Sub
    Private Sub pro_LimpiarCampos()

        txtTICACODI.Text = ""
        txtTICADESC.Text = ""
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtTICACODI, "")

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(txtTICACODI.Text, txtTICADESC.Text, cboTICAESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtTICACODI.Focus()
            Else
                Dim id As String = txtTICACODI.Text

                Dim objdatos1 As New cla_TIPOCALI
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_CODIGO_MANT_TIPOCALI(id)

                If tbl.Rows.Count > 0 Then
                    mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                    txtTICACODI.Focus()
                Else
                    Dim objdatos As New cla_TIPOCALI

                    If (objdatos.fun_Insertar_MANT_TIPOCALI(txtTICACODI.Text, txtTICADESC.Text, cboTICAESTA.SelectedValue)) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            pro_LimpiarCampos()
                            txtTICACODI.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            txtTICACODI.Focus()
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
        txtTICACODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_TIPOCALI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        txtTICACODI.Focus()
    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtTICACODI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTICACODI.TextChanged
        If Trim(txtTICACODI.Text) = "" Then
            ErrorProvider1.SetError(Me.txtTICACODI, "")
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtTICACODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTICACODI.KeyPress
        If Not Char.IsLetter(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoAlfa
                    mod_MENSAJE.Inco_Valo_Alfa()
                Else
                    txtTICADESC.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtTICADESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTICADESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTICAESTA.Focus()
        End If
    End Sub
    Private Sub cboTICAESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTICAESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTICACODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICACODI.Validated
        Try
            If Trim(txtTICACODI.Text) = "" Then
                txtTICACODI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
                ErrorProvider1.SetError(Me.txtTICACODI, "")
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""

                Dim Codigo As String = Trim(txtTICACODI.Text)

                Dim objdatos1 As New cla_TIPOCALI
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_TIPOCALI(Codigo)

                If tbl.Rows.Count > 0 Then
                    ErrorProvider1.SetError(Me.txtTICACODI, "Código existente en la base de datos")
                    txtTICACODI.Focus()
                Else
                    ErrorProvider1.SetError(Me.txtTICACODI, "")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub txtTICADESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICADESC.Validated
        If Trim(txtTICADESC.Text) = "" Then
            txtTICADESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboTICAESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTICAESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtTICACODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICACODI.GotFocus
        txtTICACODI.SelectionStart = 0
        txtTICACODI.SelectionLength = Len(txtTICACODI.Text)
        strBARRESTA.Items(0).Text = txtTICACODI.AccessibleDescription
    End Sub
    Private Sub txtTICADESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTICADESC.GotFocus
        txtTICADESC.SelectionStart = 0
        txtTICADESC.SelectionLength = Len(txtTICADESC.Text)
        strBARRESTA.Items(0).Text = txtTICADESC.AccessibleDescription
    End Sub
    Private Sub cboTICAESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTICAESTA.GotFocus
        cboTICAESTA.SelectionStart = 0
        cboTICAESTA.SelectionLength = Len(cboTICAESTA.Text)
        strBARRESTA.Items(0).Text = cboTICAESTA.AccessibleDescription
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