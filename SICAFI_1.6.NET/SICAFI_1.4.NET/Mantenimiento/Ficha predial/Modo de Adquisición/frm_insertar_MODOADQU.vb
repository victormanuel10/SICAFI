Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_MODOADQU

    '====================================
    '*** INSERTAR MODO DE ADQUISICIÓN ***
    '====================================

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboMOADESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboMOADESTA.DisplayMember = "ESTADESC"
        cboMOADESTA.ValueMember = "ESTACODI"

    End Sub
    Private Sub pro_LimpiarCampos()

        txtMOADCODI.Text = ""
        txtMOADDESC.Text = ""
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtMOADCODI, "")

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(txtMOADCODI.Text, txtMOADDESC.Text, cboMOADESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtMOADCODI.Focus()
            Else
                Dim id As Integer = Val(txtMOADCODI.Text)

                Dim objdatos1 As New cla_MODOADQU
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_CODIGO_MANT_MODOADQU(id)

                If tbl.Rows.Count > 0 Then
                    mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                    txtMOADCODI.Focus()
                Else
                    Dim objdatos As New cla_MODOADQU

                    If (objdatos.fun_Insertar_MANT_MODOADQU(txtMOADCODI.Text, txtMOADDESC.Text, cboMOADESTA.SelectedValue)) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            pro_LimpiarCampos()
                            txtMOADCODI.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            txtMOADCODI.Focus()
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
        txtMOADCODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_MODOADQU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        txtMOADCODI.Focus()
    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtMOADCODI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMOADCODI.TextChanged
        If Trim(txtMOADCODI.Text) = "" Then
            ErrorProvider1.SetError(Me.txtMOADCODI, "")
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtMOADCODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMOADCODI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtMOADDESC.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtMOADDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMOADDESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboMOADESTA.Focus()
        End If
    End Sub
    Private Sub cboMOADESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMOADESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtMOADCODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOADCODI.Validated
        Try
            If Trim(txtMOADCODI.Text) = "" Then
                txtMOADCODI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
                ErrorProvider1.SetError(Me.txtMOADCODI, "")
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""

                Dim Codigo As Integer = Val(txtMOADCODI.Text)

                Dim objdatos1 As New cla_MODOADQU
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_CODIGO_MANT_MODOADQU(Codigo)

                If tbl.Rows.Count > 0 Then
                    ErrorProvider1.SetError(Me.txtMOADCODI, "Código existente en la base de datos")
                    txtMOADCODI.Focus()
                Else
                    ErrorProvider1.SetError(Me.txtMOADCODI, "")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub txtMOADDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOADDESC.Validated
        If Trim(txtMOADDESC.Text) = "" Then
            txtMOADDESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboMOADESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOADESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtMOADCODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOADCODI.GotFocus
        txtMOADCODI.SelectionStart = 0
        txtMOADCODI.SelectionLength = Len(txtMOADCODI.Text)
        strBARRESTA.Items(0).Text = txtMOADCODI.AccessibleDescription
    End Sub
    Private Sub txtMOADDESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOADDESC.GotFocus
        txtMOADDESC.SelectionStart = 0
        txtMOADDESC.SelectionLength = Len(txtMOADDESC.Text)
        strBARRESTA.Items(0).Text = txtMOADDESC.AccessibleDescription
    End Sub
    Private Sub cboMOADESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOADESTA.GotFocus
        cboMOADESTA.SelectionStart = 0
        cboMOADESTA.SelectionLength = Len(cboMOADESTA.Text)
        strBARRESTA.Items(0).Text = cboMOADESTA.AccessibleDescription
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