Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_CODICACO

    '========================================================
    '*** INSERTAR CÓDIGOS DE CALIFICACIÓN DE CONSTRUCCIÓN ***
    '========================================================

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboCOCCESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboCOCCESTA.DisplayMember = "ESTADESC"
        cboCOCCESTA.ValueMember = "ESTACODI"

        Dim objdatos7 As New cla_TIPOCALI

        cboCOCCTIPO.DataSource = objdatos7.fun_Consultar_MANT_TIPOCALI_X_ESTADO
        cboCOCCTIPO.DisplayMember = "TICACODI"
        cboCOCCTIPO.ValueMember = "TICACODI"

        '====================================================
        '*** CARGA EL cboCOCCTIPO CON CODIGO SELECCIONADO ***
        '====================================================

        Try
            Dim boCOCCTIPO As Boolean = fun_Buscar_Dato_TIPOCALI(cboCOCCTIPO.SelectedValue)
            Dim boCOCCCODI As Boolean = fun_Buscar_Dato_CODICALI(cboCOCCCODI.SelectedValue)

            If boCOCCTIPO = True OrElse boCOCCCODI = True Then

                lblCOCCCODI.Text = CType(fun_Buscar_Lista_Valores_CODICALI(cboCOCCCODI.SelectedValue), String)
                lblCOCCTIPO.Text = CType(fun_Buscar_Lista_Valores_TIPOCALI(cboCOCCCODI.SelectedValue), String)
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        cboCOCCCODI.Focus()

    End Sub
    Private Sub pro_LimpiarCampos()

        txtCOCCPUNT.Text = ""
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtCOCCPUNT, "")

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_4_DATOS(cboCOCCCODI.Text, cboCOCCTIPO.Text, txtCOCCPUNT.Text, cboCOCCESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                cboCOCCCODI.Focus()
            Else
                Dim idCodigo As String = cboCOCCCODI.SelectedValue
                Dim idTipo As String = cboCOCCTIPO.SelectedValue

                Dim objdatos1 As New cla_CODICACO
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_Y_TIPO_MANT_CODICACO(idCodigo, idTipo)

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("Municipio existente en la base de datos para el departamento", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    cboCOCCCODI.Focus()
                Else
                    Dim objdatos As New cla_CODICACO

                    If (objdatos.fun_Insertar_MANT_CODICACO(cboCOCCCODI.SelectedValue, cboCOCCTIPO.SelectedValue, txtCOCCPUNT.Text, cboCOCCESTA.SelectedValue)) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            pro_LimpiarCampos()
                            cboCOCCCODI.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            cboCOCCCODI.Focus()
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
        cboCOCCCODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_CODICACO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        cboCOCCTIPO.Focus()
    End Sub

#End Region
   
#Region "TextChanged"

    Private Sub txtCOCCPUNT_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCOCCPUNT.TextChanged
        If Trim(txtCOCCPUNT.Text) = "" Then
            ErrorProvider1.SetError(Me.txtCOCCPUNT, "")
        End If
    End Sub

#End Region
   
#Region "KeyPress"

    Private Sub cboCOCCCODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCOCCCODI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboCOCCTIPO.Focus()
        End If
    End Sub
    Private Sub cboCOCCTIPO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCOCCTIPO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtCOCCPUNT.Focus()
        End If
    End Sub
    Private Sub txtCOCCPUNT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCOCCPUNT.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    cboCOCCESTA.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub cboCOCCESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCOCCESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region
    
#Region "Validated"

    Private Sub cboCOCCCODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOCCCODI.Validated
        If Trim(cboCOCCCODI.Text) = "" Then
            cboCOCCCODI.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboCOCCTIPO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOCCTIPO.Validated
        Try
            If Trim(cboCOCCTIPO.Text) = "" Then
                txtCOCCPUNT.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
                ErrorProvider1.SetError(Me.cboCOCCTIPO, "")
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""

                Dim idCODIGO As String = cboCOCCTIPO.SelectedValue
                Dim idTIPO As String = cboCOCCTIPO.SelectedValue

                Dim objdatos1 As New cla_CODICACO
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_CODIGO_Y_TIPO_MANT_CODICACO(idCODIGO, idTIPO)

                If tbl.Rows.Count > 0 Then
                    ErrorProvider1.SetError(Me.cboCOCCTIPO, "Código existente en la base de datos")
                    cboCOCCTIPO.Focus()
                Else
                    ErrorProvider1.SetError(Me.cboCOCCTIPO, "")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub txtCOCCPUNT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCOCCPUNT.Validated
        If Trim(txtCOCCPUNT.Text) = "" Then
            txtCOCCPUNT.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboCOCCESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOCCESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region
   
#Region "GotFocus"

    Private Sub cboCOCCCODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOCCCODI.GotFocus
        cboCOCCCODI.SelectionStart = 0
        cboCOCCCODI.SelectionLength = Len(cboCOCCCODI.Text)
        strBARRESTA.Items(0).Text = cboCOCCCODI.AccessibleDescription
    End Sub
    Private Sub cboCOCCTIPO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOCCTIPO.GotFocus
        cboCOCCTIPO.SelectionStart = 0
        cboCOCCTIPO.SelectionLength = Len(cboCOCCTIPO.Text)
        strBARRESTA.Items(0).Text = cboCOCCTIPO.AccessibleDescription
    End Sub
    Private Sub txtCOCCPUNT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCOCCPUNT.GotFocus
        txtCOCCPUNT.SelectionStart = 0
        txtCOCCPUNT.SelectionLength = Len(txtCOCCPUNT.Text)
        strBARRESTA.Items(0).Text = txtCOCCPUNT.AccessibleDescription
    End Sub
    Private Sub cboCOCCESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOCCESTA.GotFocus
        cboCOCCESTA.SelectionStart = 0
        cboCOCCESTA.SelectionLength = Len(cboCOCCESTA.Text)
        strBARRESTA.Items(0).Text = cboCOCCESTA.AccessibleDescription
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