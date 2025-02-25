Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_MUNICIPIO

    '==========================
    '*** INSERTAR MUNICIPIO ***
    '==========================

#Region "VARIABLES LOCALES"

    '*** VARIABLES DE LA MASCARA DE LA CEDULA CATASTRAL ***
    Dim Mascara As Integer
    Dim Formato As String

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboMUNIESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboMUNIESTA.DisplayMember = "ESTADESC"
        cboMUNIESTA.ValueMember = "ESTACODI"

        Dim objdatos1 As New cla_DEPARTAMENTO

        cboMUNIDEPA.DataSource = objdatos1.fun_Consultar_MANT_DEPARTAMENTO_X_ESTADO
        cboMUNIDEPA.DisplayMember = "DEPACODI"
        cboMUNIDEPA.ValueMember = "DEPACODI"

        '====================================================
        '*** CARGA EL cboMUNIDEPA CON CODIGO SELECCIONADO ***
        '====================================================
        Try
            Dim boMUNIDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(cboMUNIDEPA.SelectedValue)

            If boMUNIDEPA = True Then
                lblMUNIDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(cboMUNIDEPA.SelectedValue), String)
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        cboMUNIDEPA.Focus()

    End Sub
    Private Sub pro_LimpiarCampos()

        txtMUNICODI.Text = ""
        txtMUNIDESC.Text = ""
        txtMUNIRAIN.Text = ""
        txtMUNIRAFI.Text = ""
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtMUNICODI, "")

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_6_DATOS(txtMUNICODI.Text, txtMUNIDESC.Text, txtMUNIRAIN.Text, cboMUNIDEPA.Text, cboMUNIESTA.Text, txtMUNIRAFI.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtMUNICODI.Focus()
            Else
                Dim idDepartamento As String = cboMUNIDEPA.Text
                Dim idMunicipio As String = fun_Formato_Mascara_3_Reales(Trim(txtMUNICODI.Text))

                Dim objdatos1 As New cla_MUNICIPIO
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_DEPARTAMENTO_Y_CODIGO_MANT_MUNICIPIO(idDepartamento, idMunicipio)

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("Municipio existente en la base de datos para el departamento", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    txtMUNICODI.Focus()
                Else
                    Dim objdatos As New cla_MUNICIPIO

                    If (objdatos.fun_Insertar_MANT_MUNICIPIO(cboMUNIDEPA.SelectedValue, txtMUNICODI.Text, txtMUNIDESC.Text, txtMUNIRAIN.Text, txtMUNIRAFI.Text, cboMUNIESTA.SelectedValue)) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            pro_LimpiarCampos()
                            cboMUNIDEPA.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            cboMUNIDEPA.Focus()
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
        cboMUNIDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_MUNICIPIO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        cboMUNIDEPA.Focus()
    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtMUNICODI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMUNICODI.TextChanged
        If Trim(txtMUNICODI.Text) = "" Then
            ErrorProvider1.SetError(Me.txtMUNICODI, "")
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboMUNIDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMUNIDEPA.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_DEPARTAMENTO()
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub cboMUNIDEPA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMUNIDEPA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtMUNICODI.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO(cboMUNIDEPA, cboMUNIDEPA.SelectedIndex)
        End If

    End Sub
    Private Sub txtMUNICODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMUNICODI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtMUNIDESC.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtMUNIDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMUNIDESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboMUNIESTA.Focus()
        End If
    End Sub
    Private Sub txtMUNIRAIN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMUNIRAIN.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                Else
                    txtMUNIRAFI.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtMUNIRAFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMUNIRAFI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                Else
                    cboMUNIESTA.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub cboMUNIESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMUNIESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtMUNICODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUNICODI.Validated
        Try
            If Trim(txtMUNICODI.Text) = "" Then
                txtMUNICODI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
                ErrorProvider1.SetError(Me.txtMUNICODI, "")
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""

                Dim idDepartamento As String = Trim(cboMUNIDEPA.Text)
                Dim idMunicipio As String = fun_Formato_Mascara_3_Reales(Trim(txtMUNICODI.Text))

                Dim objdatos1 As New cla_MUNICIPIO
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_DEPARTAMENTO_Y_CODIGO_MANT_MUNICIPIO(idDepartamento, idMunicipio)

                If tbl.Rows.Count > 0 Then
                    ErrorProvider1.SetError(Me.txtMUNICODI, "Código existente en la base de datos")
                    txtMUNICODI.Focus()
                Else
                    ErrorProvider1.SetError(Me.txtMUNICODI, "")

                    txtMUNICODI.Text = fun_Formato_Mascara_3_Reales(Trim(txtMUNICODI.Text))

                    Dim inNroRangoInicial As Integer = 0
                    Dim inNroRangoFinal As Integer = 0

                    pro_Asigna_Rango_Ficha_Municipio(Me.txtMUNICODI.Text, inNroRangoInicial, inNroRangoFinal)

                    Me.txtMUNIRAIN.Text = inNroRangoInicial
                    Me.txtMUNIRAFI.Text = inNroRangoFinal

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub txtMUNIDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUNIDESC.Validated
        If Trim(txtMUNIDESC.Text) = "" Then
            txtMUNIDESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtMUNIRAIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUNIRAIN.Validated
        If Trim(txtMUNIRAIN.Text) = "" Then
            txtMUNIRAIN.Text = 0
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtMUNIRAFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUNIRAFI.Validated
        If Trim(txtMUNIRAFI.Text) = "" Then
            txtMUNIRAFI.Text = 0
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboMUNIESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMUNIESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtMUNICODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUNICODI.GotFocus
        txtMUNICODI.SelectionStart = 0
        txtMUNICODI.SelectionLength = Len(txtMUNICODI.Text)
        strBARRESTA.Items(0).Text = txtMUNICODI.AccessibleDescription
    End Sub
    Private Sub txtMUNIDESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUNIDESC.GotFocus
        txtMUNIDESC.SelectionStart = 0
        txtMUNIDESC.SelectionLength = Len(txtMUNIDESC.Text)
        strBARRESTA.Items(0).Text = txtMUNIDESC.AccessibleDescription
    End Sub
    Private Sub cboMUNIESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMUNIESTA.GotFocus
        cboMUNIESTA.SelectionStart = 0
        cboMUNIESTA.SelectionLength = Len(cboMUNIESTA.Text)
        strBARRESTA.Items(0).Text = cboMUNIESTA.AccessibleDescription
    End Sub
    Private Sub txtMUNIRAIN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUNIRAIN.GotFocus
        txtMUNIRAIN.SelectionStart = 0
        txtMUNIRAIN.SelectionLength = Len(txtMUNIRAIN.Text)
        strBARRESTA.Items(0).Text = txtMUNIRAIN.AccessibleDescription
    End Sub
    Private Sub txtMUNIRAFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUNIRAFI.GotFocus
        txtMUNIRAFI.SelectionStart = 0
        txtMUNIRAFI.SelectionLength = Len(txtMUNIRAFI.Text)
        strBARRESTA.Items(0).Text = txtMUNIRAFI.AccessibleDescription
    End Sub
    Private Sub cboMUNIDEPA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMUNIDEPA.GotFocus
        cboMUNIDEPA.SelectionStart = 0
        cboMUNIDEPA.SelectionLength = Len(cboMUNIDEPA.Text)
        strBARRESTA.Items(0).Text = cboMUNIDEPA.AccessibleDescription
    End Sub

    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboMUNIDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMUNIDEPA.SelectedIndexChanged
        lblMUNIDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(cboMUNIDEPA.Text), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboMUNIDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMUNIDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO(cboMUNIDEPA, cboMUNIDEPA.SelectedIndex)
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