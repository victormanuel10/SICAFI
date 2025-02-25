Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_NOTARIA

    '========================
    '*** INSERTAR NOTARIA ***
    '========================

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboNOTAESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboNOTAESTA.DisplayMember = "ESTADESC"
        cboNOTAESTA.ValueMember = "ESTACODI"

        Dim objdatos5 As New cla_DEPARTAMENTO

        cboNOTADEPA.DataSource = objdatos5.fun_Consultar_MANT_DEPARTAMENTO_X_ESTADO
        cboNOTADEPA.DisplayMember = "DEPACODI"
        cboNOTADEPA.ValueMember = "DEPACODI"

        '======================================
        ' CARGA LA DESCRIPCIÓN DEL DEPARTAMENTO
        '======================================

        Try
            Dim boNOTADEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(cboNOTADEPA.Text)

            If boNOTADEPA = True Then
                lblNOTADEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(cboNOTADEPA.Text), String)
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        cboNOTADEPA.Focus()

    End Sub
    Private Sub pro_LimpiarCampos()

        txtNOTACODI.Text = ""
        txtNOTADESC.Text = ""
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtNOTACODI, "")

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_5_DATOS(txtNOTACODI.Text, txtNOTADESC.Text, cboNOTADEPA.Text, cboNOTAMUNI.Text, cboNOTAESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                cboNOTADEPA.Focus()
            Else
                Dim idDepartamento As String = Trim(cboNOTADEPA.Text)
                Dim idMunicipio As String = Trim(cboNOTAMUNI.Text)
                Dim idNotaria As String = Trim(txtNOTACODI.Text)

                Dim objdatos1 As New cla_NOTARIA
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_CODIGO_MANT_NOTARIA(idDepartamento, idMunicipio, idNotaria)

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("Notaria existente en la base de datos para el departamento y el municipio", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    cboNOTADEPA.Focus()
                Else
                    Dim objdatos As New cla_NOTARIA

                    If (objdatos.fun_Insertar_MANT_NOTARIA(cboNOTADEPA.SelectedValue, cboNOTAMUNI.SelectedValue, txtNOTACODI.Text, txtNOTADESC.Text, cboNOTAESTA.SelectedValue)) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            pro_LimpiarCampos()
                            cboNOTADEPA.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            cboNOTADEPA.Focus()
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
        cboNOTADEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_NOTARIA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        cboNOTADEPA.Focus()
    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtNOTACODI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNOTACODI.TextChanged
        If Trim(txtNOTACODI.Text) = "" Then
            ErrorProvider1.SetError(Me.txtNOTACODI, "")
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboNOTAMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboNOTAMUNI.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_MUNICIPIO()
        End If
    End Sub

    Private Sub cboNOTADEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboNOTADEPA.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_DEPARTAMENTO()
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtNOTACODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNOTACODI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtNOTADESC.Focus()
        End If
    End Sub
    Private Sub txtNOTADESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNOTADESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboNOTAESTA.Focus()
        End If
    End Sub
    Private Sub cboNOTAESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboNOTAESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub
    Private Sub cboNOTADEPA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboNOTADEPA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboNOTAMUNI.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO(cboNOTADEPA, cboNOTADEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboNOTAMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboNOTAMUNI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtNOTACODI.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO(cboNOTAMUNI, cboNOTADEPA.Text)
        End If
    End Sub


#End Region

#Region "Validated"

    Private Sub txtNOTACODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNOTACODI.Validated
        Try
            If Trim(txtNOTACODI.Text) = "" Then
                txtNOTACODI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
                ErrorProvider1.SetError(Me.txtNOTACODI, "")
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""

                Dim idDepartamento As String = cboNOTADEPA.Text
                Dim idMunicipio As String = cboNOTAMUNI.Text
                Dim idNotaria As String = txtNOTACODI.Text

                Dim objdatos1 As New cla_NOTARIA
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_CODIGO_MANT_NOTARIA(idDepartamento, idMunicipio, idNotaria)

                If tbl.Rows.Count > 0 Then
                    ErrorProvider1.SetError(Me.txtNOTACODI, "Código existente en la base de datos")
                    txtNOTACODI.Focus()
                Else
                    ErrorProvider1.SetError(Me.txtNOTACODI, "")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub txtNOTADESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNOTADESC.Validated
        If Trim(txtNOTADESC.Text) = "" Then
            txtNOTADESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtNOTACODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNOTACODI.GotFocus
        txtNOTACODI.SelectionStart = 0
        txtNOTACODI.SelectionLength = Len(txtNOTACODI.Text)
        strBARRESTA.Items(0).Text = txtNOTACODI.AccessibleDescription
    End Sub
    Private Sub txtNOTADESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNOTADESC.GotFocus
        txtNOTADESC.SelectionStart = 0
        txtNOTADESC.SelectionLength = Len(txtNOTADESC.Text)
        strBARRESTA.Items(0).Text = txtNOTADESC.AccessibleDescription
    End Sub
    Private Sub cboNOTAESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboNOTAESTA.GotFocus
        cboNOTAESTA.SelectionStart = 0
        cboNOTAESTA.SelectionLength = Len(cboNOTAESTA.Text)
        strBARRESTA.Items(0).Text = cboNOTAESTA.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub cboNOTAMUNI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboNOTAMUNI.GotFocus
        cboNOTAMUNI.SelectionStart = 0
        cboNOTAMUNI.SelectionLength = Len(cboNOTAMUNI.Text)
        strBARRESTA.Items(0).Text = cboNOTAMUNI.AccessibleDescription
    End Sub
    Private Sub cboNOTADEPA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboNOTADEPA.GotFocus
        cboNOTADEPA.SelectionStart = 0
        cboNOTADEPA.SelectionLength = Len(cboNOTADEPA.Text)
        strBARRESTA.Items(0).Text = cboNOTADEPA.AccessibleDescription
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboNOTADEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNOTADEPA.SelectedIndexChanged
        lblNOTADEPA.Text = fun_Buscar_Lista_Valores_DEPARTAMENTO(cboNOTADEPA.Text)
        lblNOTAMUNI.Text = ""
        Call cboNOTAMUNI_Click(cboNOTAMUNI, New System.EventArgs)
        Call cboNOTAMUNI_SelectedIndexChanged(cboNOTAMUNI, New System.EventArgs)
    End Sub
    Private Sub cboNOTAMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNOTAMUNI.SelectedIndexChanged
        lblNOTAMUNI.Text = fun_Buscar_Lista_Valores_MUNICIPIO(cboNOTADEPA.Text, cboNOTAMUNI.Text)
    End Sub

#End Region

#Region "Click"

    Private Sub cboNOTADEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboNOTADEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO(cboNOTADEPA, cboNOTADEPA.SelectedIndex)
    End Sub
    Private Sub cboNOTAMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboNOTAMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO(cboNOTAMUNI, cboNOTADEPA.Text)
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