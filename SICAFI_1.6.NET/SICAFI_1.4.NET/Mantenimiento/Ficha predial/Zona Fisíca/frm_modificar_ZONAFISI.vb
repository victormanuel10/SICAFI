Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_ZONAFISI

    '=============================
    '*** MODIFICAR ZONA FÍSICA ***
    '=============================

#Region "VARIABLES"

    Dim id As Integer

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal idPersona As Integer)
        id = idPersona
        InitializeComponent()
        pro_inicializarControles()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        '=========================================
        ' CARGA LOS COMBOBOX CON LOS DATOS ACTIVOS
        '=========================================

        Dim objdatos1 As New cla_DEPARTAMENTO

        cboZOFIDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
        cboZOFIDEPA.DisplayMember = "DEPACODI"
        cboZOFIDEPA.ValueMember = "DEPACODI"

        Dim objdatos7 As New cla_MUNICIPIO

        cboZOFIMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
        cboZOFIMUNI.DisplayMember = "MUNICODI"
        cboZOFIMUNI.ValueMember = "MUNICODI"

        Dim objdatos2 As New cla_CLASSECT

        cboZOFICLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
        cboZOFICLSE.DisplayMember = "CLSECODI"
        cboZOFICLSE.ValueMember = "CLSECODI"

        Dim objdatos As New cla_ESTADO

        cboZOFIESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboZOFIESTA.DisplayMember = "ESTADESC"
        cboZOFIESTA.ValueMember = "ESTACODI"

        Dim objdatos3 As New cla_ZONAFISI
        Dim tbl As New DataTable

        tbl = objdatos3.fun_Buscar_ID_MANT_ZONAFISI(id)

        Me.cboZOFIDEPA.SelectedValue = tbl.Rows(0).Item(1)
        Me.cboZOFIMUNI.SelectedValue = tbl.Rows(0).Item(2)
        Me.cboZOFICLSE.SelectedValue = tbl.Rows(0).Item(3)
        Me.txtZOFICODI.Text = Trim(tbl.Rows(0).Item(4))
        Me.txtZOFIDESC.Text = Trim(tbl.Rows(0).Item(5))
        Me.cboZOFIESTA.SelectedValue = tbl.Rows(0).Item(6)
        Me.chkZOFIZOCO.Checked = tbl.Rows(0).Item(7)

        '=====================
        ' CARGA LA DESCRIPCIÓN 
        '=====================

        Try
            Dim boZOFIDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(cboZOFIDEPA.SelectedValue)
            Dim boZOFIMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(cboZOFIDEPA.SelectedValue, cboZOFIMUNI.SelectedValue)
            Dim boZOFICLSE As Boolean = fun_Buscar_Dato_CLASSECT(cboZOFICLSE.SelectedValue)


            If boZOFIDEPA = True OrElse boZOFIMUNI = True OrElse boZOFICLSE = True Then

                lblZOFIDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(cboZOFIDEPA.SelectedValue), String)
                lblZOFIMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(cboZOFIDEPA.SelectedValue, cboZOFIMUNI.SelectedValue), String)
                lblZOFICLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(cboZOFICLSE.SelectedValue), String)
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        txtZOFIDESC.Focus()

    End Sub
    Private Sub pro_LimpiarCampos()

        txtZOFIDESC.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_6_DATOS(txtZOFICODI.Text, txtZOFIDESC.Text, cboZOFIDEPA.Text, cboZOFIMUNI.Text, cboZOFICLSE.Text, cboZOFIESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtZOFIDESC.Focus()
            Else
                Dim objdatos As New cla_ZONAFISI

                If (objdatos.fun_Actualizar_MANT_ZONAFISI(id, cboZOFIDEPA.SelectedValue, cboZOFIMUNI.SelectedValue, cboZOFICLSE.SelectedValue, txtZOFICODI.Text, txtZOFIDESC.Text, cboZOFIESTA.SelectedValue, Me.chkZOFIZOCO.Checked)) Then
                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                    txtZOFIDESC.Focus()
                    Me.Close()
                Else
                    mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Modificar")
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtZOFIDESC.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub cboZOFIDEPA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboZOFIDEPA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboZOFIMUNI.Focus()
        End If
    End Sub
    Private Sub cboZOFIMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboZOFIMUNI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboZOFICLSE.Focus()
        End If
    End Sub
    Private Sub cboZOFICLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboZOFICLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtZOFICODI.Focus()
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
        cboZOFIDEPA.SelectionStart = 0
        cboZOFIDEPA.SelectionLength = Len(cboZOFIDEPA.Text)
        strBARRESTA.Items(0).Text = cboZOFIDEPA.AccessibleDescription
    End Sub
    Private Sub cboZOFIMUNI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZOFIMUNI.GotFocus
        cboZOFIMUNI.SelectionStart = 0
        cboZOFIMUNI.SelectionLength = Len(cboZOFIMUNI.Text)
        strBARRESTA.Items(0).Text = cboZOFIMUNI.AccessibleDescription
    End Sub
    Private Sub cboZOFICLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZOFICLSE.GotFocus
        cboZOFICLSE.SelectionStart = 0
        cboZOFICLSE.SelectionLength = Len(cboZOFICLSE.Text)
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
        cboZOFIESTA.SelectionStart = 0
        cboZOFIESTA.SelectionLength = Len(cboZOFIESTA.Text)
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