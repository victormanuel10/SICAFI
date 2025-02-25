Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_TIPORESO

    '===================================
    '*** INSERTAR TIPO DE RESOLUCIÓN ***
    '===================================

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboTIREESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboTIREESTA.DisplayMember = "ESTADESC"
        cboTIREESTA.ValueMember = "ESTACODI"

    End Sub
    Private Sub pro_LimpiarCampos()

        txtTIRECODI.Text = ""
        txtTIREDESC.Text = ""
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtTIRECODI, "")

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(txtTIRECODI.Text, txtTIREDESC.Text, cboTIREESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtTIRECODI.Focus()
            Else
                Dim id As Integer = txtTIRECODI.Text

                Dim objdatos1 As New cla_TIPORESO
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_CODIGO_MANT_TIPORESO(id)

                If tbl.Rows.Count > 0 Then
                    mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                    txtTIRECODI.Focus()
                Else
                    Dim objdatos As New cla_TIPORESO

                    If (objdatos.fun_Insertar_MANT_TIPORESO(txtTIRECODI.Text, txtTIREDESC.Text, cboTIREESTA.SelectedValue)) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            pro_LimpiarCampos()
                            txtTIRECODI.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            txtTIRECODI.Focus()
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
        txtTIRECODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_TIPORESO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        txtTIRECODI.Focus()
    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtTIRECODI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTIRECODI.TextChanged
        If Trim(txtTIRECODI.Text) = "" Then
            ErrorProvider1.SetError(Me.txtTIRECODI, "")
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtTIRECODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTIRECODI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtTIREDESC.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtTIREDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTIREDESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTIREESTA.Focus()
        End If
    End Sub
    Private Sub cboTIREESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTIREESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTIRECODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTIRECODI.Validated
        Try
            If Trim(txtTIRECODI.Text) = "" Then
                txtTIRECODI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
                ErrorProvider1.SetError(Me.txtTIRECODI, "")
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""

                Dim Codigo As Integer = Val(txtTIRECODI.Text)

                Dim objdatos1 As New cla_TIPORESO
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_TIPORESO(Codigo)

                If tbl.Rows.Count > 0 Then
                    ErrorProvider1.SetError(Me.txtTIRECODI, "Código existente en la base de datos")
                    txtTIRECODI.Focus()
                Else
                    ErrorProvider1.SetError(Me.txtTIRECODI, "")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub txtTIREDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTIREDESC.Validated
        If Trim(txtTIREDESC.Text) = "" Then
            txtTIREDESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboTIREESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTIREESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtTIRECODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTIRECODI.GotFocus
        txtTIRECODI.SelectionStart = 0
        txtTIRECODI.SelectionLength = Len(txtTIRECODI.Text)
        strBARRESTA.Items(0).Text = txtTIRECODI.AccessibleDescription
    End Sub
    Private Sub txtTIREDESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTIREDESC.GotFocus
        txtTIREDESC.SelectionStart = 0
        txtTIREDESC.SelectionLength = Len(txtTIREDESC.Text)
        strBARRESTA.Items(0).Text = txtTIREDESC.AccessibleDescription
    End Sub
    Private Sub cboTIREESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTIREESTA.GotFocus
        cboTIREESTA.SelectionStart = 0
        cboTIREESTA.SelectionLength = Len(cboTIREESTA.Text)
        strBARRESTA.Items(0).Text = cboTIREESTA.AccessibleDescription
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