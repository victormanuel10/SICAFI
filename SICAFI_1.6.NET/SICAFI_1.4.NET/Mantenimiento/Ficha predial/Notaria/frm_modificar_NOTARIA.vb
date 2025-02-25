Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_NOTARIA

    '=========================
    '*** MODIFICAR NOTARIA ***
    '=========================

    Dim id As Integer

    Public Sub New(ByVal idPersona As Integer)
        id = idPersona
        InitializeComponent()
        pro_inicializarControles()

    End Sub

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboNOTAESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboNOTAESTA.DisplayMember = "ESTADESC"
        cboNOTAESTA.ValueMember = "ESTACODI"

        Dim objdatos5 As New cla_DEPARTAMENTO

        cboNOTADEPA.DataSource = objdatos5.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
        cboNOTADEPA.DisplayMember = "DEPACODI"
        cboNOTADEPA.ValueMember = "DEPACODI"

        Dim objdatos2 As New cla_MUNICIPIO

        cboNOTAMUNI.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_MUNICIPIO
        cboNOTAMUNI.DisplayMember = "MUNICODI"
        cboNOTAMUNI.ValueMember = "MUNICODI"

        Dim objdatos1 As New cla_NOTARIA
        Dim tbl As New DataTable

        tbl = objdatos1.fun_Buscar_ID_MANT_NOTARIA(id)

        cboNOTADEPA.SelectedValue = tbl.Rows(0).Item(1)
        cboNOTAMUNI.SelectedValue = tbl.Rows(0).Item(2)
        txtNOTACODI.Text = Trim(tbl.Rows(0).Item(3))
        txtNOTADESC.Text = Trim(tbl.Rows(0).Item(4))
        cboNOTAESTA.SelectedValue = tbl.Rows(0).Item(5)

        '======================================
        ' CARGA LA DESCRIPCIÓN DEL DEPARTAMENTO
        '======================================

        Try
            Dim boNOTADEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(cboNOTADEPA.SelectedValue)
            Dim boNOTAMUNI As Boolean = fun_Buscar_Dato_DEPARTAMENTO(cboNOTADEPA.SelectedValue)

            If boNOTADEPA = True OrElse boNOTAMUNI = True Then
                lblNOTADEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(cboNOTADEPA.SelectedValue), String)
                lblNOTAMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(cboNOTADEPA.SelectedValue, cboNOTAMUNI.SelectedValue), String)
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        txtNOTADESC.Focus()

    End Sub
    Private Sub pro_LimpiarCampos()

        txtNOTACODI.Text = ""
        txtNOTADESC.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        If fun_Verificar_Campos_Llenos_5_DATOS(txtNOTACODI.Text, txtNOTADESC.Text, cboNOTADEPA.Text, cboNOTAMUNI.Text, cboNOTAESTA.Text) = False Then
            mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
            txtNOTADESC.Focus()
        Else

            Dim objdatos As New cla_NOTARIA

            If (objdatos.fun_Actualizar_MANT_NOTARIA(id, cboNOTADEPA.SelectedValue, cboNOTAMUNI.SelectedValue, txtNOTACODI.Text, txtNOTADESC.Text, cboNOTAESTA.SelectedValue)) Then
                mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                Me.Close()
            Else
                mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
            End If

        End If

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtNOTADESC.Focus()
        Me.Close()

    End Sub

#End Region

#Region "FORMULARIO"

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
    Private Sub cboNOTAMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboNOTAMUNI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtNOTACODI.Focus()
        End If
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