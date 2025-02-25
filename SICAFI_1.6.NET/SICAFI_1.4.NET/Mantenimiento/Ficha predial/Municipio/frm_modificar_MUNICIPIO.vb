Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_MUNICIPIO

    '===========================
    '*** MODIFICAR MUNICIPIO ***
    '===========================

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
        Dim objdatos As New cla_ESTADO

        cboMUNIESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
        cboMUNIESTA.DisplayMember = "ESTADESC"
        cboMUNIESTA.ValueMember = "ESTACODI"

        Dim objdatos1 As New cla_DEPARTAMENTO

        cboMUNIDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
        cboMUNIDEPA.DisplayMember = "DEPACODI"
        cboMUNIDEPA.ValueMember = "DEPACODI"

        Dim objdatos2 As New cla_MUNICIPIO
        Dim tbl As New DataTable

        tbl = objdatos2.fun_Buscar_ID_MANT_MUNICIPIO(id)

        cboMUNIDEPA.SelectedValue = tbl.Rows(0).Item(1)
        txtMUNICODI.Text = Trim(tbl.Rows(0).Item(2))
        txtMUNIDESC.Text = Trim(tbl.Rows(0).Item(3))
        txtMUNIRAIN.Text = Trim(tbl.Rows(0).Item(4))
        txtMUNIRAFI.Text = Trim(tbl.Rows(0).Item(5))
        cboMUNIESTA.SelectedValue = tbl.Rows(0).Item(6)

        '=======================================================
        '*** CARGA EL lblMUNIDEPA CON EL CODIGO SELECCIONADO ***
        '=======================================================
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

        txtMUNIDESC.Focus()

    End Sub
    Private Sub pro_LimpiarCampos()

        txtMUNICODI.Text = ""
        txtMUNIDESC.Text = ""
        txtMUNIRAIN.Text = ""
        txtMUNIRAFI.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_6_DATOS(txtMUNICODI.Text, txtMUNIDESC.Text, txtMUNIRAIN.Text, cboMUNIDEPA.Text, cboMUNIESTA.Text, txtMUNIRAFI.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtMUNIDESC.Focus()
            Else
                Dim objdatos As New cla_MUNICIPIO

                If (objdatos.fun_Actualizar_MANT_MUNICIPIO(id, cboMUNIDEPA.SelectedValue, txtMUNICODI.Text, txtMUNIDESC.Text, txtMUNIRAIN.Text, txtMUNIRAFI.Text, cboMUNIESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                    txtMUNIDESC.Focus()
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
        txtMUNIDESC.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub cboMUNIDEPA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMUNIDEPA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtMUNICODI.Focus()
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