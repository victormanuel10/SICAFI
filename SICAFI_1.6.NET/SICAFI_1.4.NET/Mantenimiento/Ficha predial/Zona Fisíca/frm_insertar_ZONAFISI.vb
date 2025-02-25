Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_ZONAFISI

    '============================
    '*** INSERTAR ZONA FÍSICA ***
    '============================

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()

        '=========================================
        ' CARGA LOS COMBOBOX CON LOS DATOS ACTIVOS
        '=========================================

        Dim objdatos As New cla_ESTADO

        cboZOFIESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboZOFIESTA.DisplayMember = "ESTADESC"
        cboZOFIESTA.ValueMember = "ESTACODI"

        Dim objdatos1 As New cla_DEPARTAMENTO

        cboZOFIDEPA.DataSource = objdatos1.fun_Consultar_MANT_DEPARTAMENTO_X_ESTADO
        cboZOFIDEPA.DisplayMember = "DEPACODI"
        cboZOFIDEPA.ValueMember = "DEPACODI"


        Dim objdatos2 As New cla_CLASSECT

        cboZOFICLSE.DataSource = objdatos2.fun_Consultar_MANT_CLASSECT_X_ESTADO
        cboZOFICLSE.DisplayMember = "CLSECODI"
        cboZOFICLSE.ValueMember = "CLSECODI"


        '===========================================================================
        ' CARGA LA DESCRIPCIÓN DEL DEPARTAMENTO (Los reg. activos ya estan cargados)
        '===========================================================================
        Try
            Dim boZOFIDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(cboZOFIDEPA.SelectedValue)
            Dim boZOFICLSE As Boolean = fun_Buscar_Dato_CLASSECT(cboZOFICLSE.SelectedValue)


            If boZOFIDEPA = True OrElse boZOFICLSE = True Then

                lblZOFIDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(cboZOFIDEPA.SelectedValue), String)
                lblZOFICLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(cboZOFICLSE.SelectedValue), String)
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If
            
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        cboZOFIDEPA.Focus()

    End Sub
    Private Sub pro_LimpiarCampos()

        txtZOFICODI.Text = ""
        txtZOFIDESC.Text = ""
        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtZOFICODI, "")

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_6_DATOS(txtZOFICODI.Text, txtZOFIDESC.Text, cboZOFIDEPA.Text, cboZOFIMUNI.Text, cboZOFICLSE.Text, cboZOFIESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                cboZOFIDEPA.Focus()
            Else
                Dim idDepartamento As String = cboZOFIDEPA.Text
                Dim idMunicipio As String = cboZOFIMUNI.Text
                Dim idClaseOsector As Integer = Val(cboZOFICLSE.Text)
                Dim idZonaFisica As Integer = Val(txtZOFICODI.Text)

                Dim objdatos1 As New cla_ZONAFISI
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAFISI(idDepartamento, idMunicipio, idClaseOsector, idZonaFisica)

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("Zona económica existente en la base de datos para el departamento, municipio y sector", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    cboZOFIDEPA.Focus()
                Else
                    Dim objdatos As New cla_ZONAFISI

                    If (objdatos.fun_Insertar_MANT_ZONAFISI(cboZOFIDEPA.SelectedValue, cboZOFIMUNI.SelectedValue, cboZOFICLSE.SelectedValue, txtZOFICODI.Text, txtZOFIDESC.Text, cboZOFIESTA.SelectedValue, Me.chkZOFIZOCO.Checked)) Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                            pro_LimpiarCampos()
                            cboZOFIDEPA.Focus()
                            Me.Close()
                        Else
                            pro_LimpiarCampos()
                            cboZOFIDEPA.Focus()
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
        txtZOFICODI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_ZONAFISI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_LimpiarCampos()
        cboZOFIDEPA.Focus()
    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtZOFICODI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtZOFICODI.TextChanged
        If Trim(txtZOFICODI.Text) = "" Then
            ErrorProvider1.SetError(Me.txtZOFICODI, "")
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboZOFIDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZOFIDEPA.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_DEPARTAMENTO()
        End If
    End Sub
    Private Sub cboZOFIMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZOFIMUNI.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_MUNICIPIO()
        End If
    End Sub
    Private Sub cboZOFICLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZOFICLSE.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_CLASSECT()
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub cboZOFIDEPA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboZOFIDEPA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboZOFIMUNI.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO(cboZOFIDEPA, cboZOFIDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboZOFIMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboZOFIMUNI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboZOFICLSE.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO(cboZOFIMUNI, cboZOFIDEPA.Text)
        End If
    End Sub
    Private Sub cboZOFICLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboZOFICLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtZOFICODI.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT(cboZOFICLSE, cboZOFICLSE.SelectedIndex)
        End If
    End Sub
    Private Sub txtZOFICODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtZOFICODI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtZOFIDESC.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtZOFIDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtZOFIDESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboZOFIESTA.Focus()
        End If
    End Sub
    Private Sub cboZOFIESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboZOFIESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtZOFICODI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZOFICODI.Validated
        Try
            If Trim(txtZOFICODI.Text) = "" Then
                txtZOFICODI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
                ErrorProvider1.SetError(Me.txtZOFICODI, "")
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""

                Dim idDepartamento As String = cboZOFIDEPA.Text
                Dim idMunicipio As String = cboZOFIMUNI.Text
                Dim idClaseOsector As Integer = Val(cboZOFICLSE.Text)
                Dim idZonaFisica As Integer = Val(txtZOFICODI.Text)

                Dim objdatos1 As New cla_ZONAFISI
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAFISI(idDepartamento, idMunicipio, idClaseOsector, idZonaFisica)

                If tbl.Rows.Count > 0 Then
                    ErrorProvider1.SetError(Me.txtZOFICODI, "Código existente en la base de datos")
                    txtZOFICODI.Focus()
                Else
                    ErrorProvider1.SetError(Me.txtZOFICODI, "")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "10")
        End Try
    End Sub
    Private Sub txtZOFIDESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZOFIDESC.Validated
        If Trim(txtZOFIDESC.Text) = "" Then
            txtZOFIDESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboZOFIESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZOFIESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cboZOFIDEPA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZOFIDEPA.GotFocus
        strBARRESTA.Items(0).Text = cboZOFIDEPA.AccessibleDescription
    End Sub
    Private Sub cboZOFIMUNI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZOFIMUNI.GotFocus
        strBARRESTA.Items(0).Text = cboZOFIMUNI.AccessibleDescription
    End Sub
    Private Sub cboZOFICLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZOFICLSE.GotFocus
        strBARRESTA.Items(0).Text = cboZOFICLSE.AccessibleDescription
    End Sub
    Private Sub txtZOFICODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZOFICODI.GotFocus
        txtZOFICODI.SelectionStart = 0
        txtZOFICODI.SelectionLength = Len(txtZOFICODI.Text)
        strBARRESTA.Items(0).Text = txtZOFICODI.AccessibleDescription
    End Sub
    Private Sub txtZOFIDESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZOFIDESC.GotFocus
        txtZOFIDESC.SelectionStart = 0
        txtZOFIDESC.SelectionLength = Len(txtZOFIDESC.Text)
        strBARRESTA.Items(0).Text = txtZOFIDESC.AccessibleDescription
    End Sub
    Private Sub cboZOFIESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZOFIESTA.GotFocus
        strBARRESTA.Items(0).Text = cboZOFIESTA.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub chkZOFIZOCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkZOFIZOCO.GotFocus
        strBARRESTA.Items(0).Text = chkZOFIZOCO.AccessibleDescription
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboZOFIDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZOFIDEPA.SelectedIndexChanged
        lblZOFIDEPA.Text = fun_Buscar_Lista_Valores_DEPARTAMENTO(Trim(cboZOFIDEPA.Text))
        lblZOFIMUNI.Text = ""

        Call cboZOFIMUNI_Click(cboZOFIMUNI, New System.EventArgs)
        Call cboZOFIMUNI_SelectedIndexChanged(cboZOFIMUNI, New System.EventArgs)
    End Sub
    Private Sub cboZOFIMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZOFIMUNI.SelectedIndexChanged
        lblZOFIMUNI.Text = fun_Buscar_Lista_Valores_MUNICIPIO(Trim(cboZOFIDEPA.Text), Trim(cboZOFIMUNI.Text))
    End Sub
    Private Sub cboZOFICLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZOFICLSE.SelectedIndexChanged
        lblZOFICLSE.Text = fun_Buscar_Lista_Valores_CLASSECT(cboZOFICLSE.Text)
    End Sub

#End Region

#Region "Click"

    Private Sub cboZOFIMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZOFIMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO(cboZOFIMUNI, Trim(cboZOFIDEPA.Text))
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