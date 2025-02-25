Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_PUNTCARD

    '===============================
    '*** INSERTAR PUNTO CARDINAL ***
    '===============================

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboPUCAESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboPUCAESTA.DisplayMember = "ESTADESC"
        cboPUCAESTA.ValueMember = "ESTACODI"

    End Sub
    Private Sub pro_LimpiarCampos()

        txtPUCACODI.Text = ""
        txtPUCADESC.Text = ""
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtPUCACODI, "")

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(txtPUCACODI.Text, txtPUCADESC.Text, cboPUCAESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtPUCACODI.Focus()
            Else
                Dim id As String = txtPUCACODI.Text

                Dim objdatos1 As New cla_PUNTCARD
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_CODIGO_MANT_PUNTCARD(id)

                If tbl.Rows.Count > 0 Then
                    mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                    txtPUCACODI.Focus()
                Else
                    Dim objdatos As New cla_PUNTCARD

                    If (objdatos.fun_Insertar_MANT_PUNTCARD(txtPUCACODI.Text, txtPUCADESC.Text, cboPUCAESTA.SelectedValue)) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            pro_LimpiarCampos()
                            txtPUCACODI.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            txtPUCACODI.Focus()
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
        txtPUCACODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_PUNTCARD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        txtPUCACODI.Focus()
    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtPUCACODI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPUCACODI.TextChanged
        If Trim(txtPUCACODI.Text) = "" Then
            ErrorProvider1.SetError(Me.txtPUCACODI, "")
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtPUCACODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPUCACODI.KeyPress
        If Not Char.IsLetter(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoAlfa
                    mod_MENSAJE.Inco_Valo_Alfa()
                Else
                    txtPUCADESC.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtPUCADESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPUCADESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboPUCAESTA.Focus()
        End If
    End Sub
    Private Sub cboPUCAESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPUCAESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtPUCACODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPUCACODI.Validated
        Try
            If Trim(txtPUCACODI.Text) = "" Then
                txtPUCACODI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
                ErrorProvider1.SetError(Me.txtPUCACODI, "")
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""

                Dim Codigo As String = txtPUCACODI.Text

                Dim objdatos1 As New cla_PUNTCARD
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_CODIGO_MANT_PUNTCARD(Codigo)

                If tbl.Rows.Count > 0 Then
                    ErrorProvider1.SetError(Me.txtPUCACODI, "Código existente en la base de datos")
                    txtPUCACODI.Focus()
                Else
                    ErrorProvider1.SetError(Me.txtPUCACODI, "")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub txtPUCADESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPUCADESC.Validated
        If Trim(txtPUCADESC.Text) = "" Then
            txtPUCADESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboPUCAESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPUCAESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtPUCACODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPUCACODI.GotFocus
        txtPUCACODI.SelectionStart = 0
        txtPUCACODI.SelectionLength = Len(txtPUCACODI.Text)
        strBARRESTA.Items(0).Text = txtPUCACODI.AccessibleDescription
    End Sub
    Private Sub txtPUCADESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPUCADESC.GotFocus
        txtPUCADESC.SelectionStart = 0
        txtPUCADESC.SelectionLength = Len(txtPUCADESC.Text)
        strBARRESTA.Items(0).Text = txtPUCADESC.AccessibleDescription
    End Sub
    Private Sub cboPUCAESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPUCAESTA.GotFocus
        cboPUCAESTA.SelectionStart = 0
        cboPUCAESTA.SelectionLength = Len(cboPUCAESTA.Text)
        strBARRESTA.Items(0).Text = cboPUCAESTA.AccessibleDescription
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