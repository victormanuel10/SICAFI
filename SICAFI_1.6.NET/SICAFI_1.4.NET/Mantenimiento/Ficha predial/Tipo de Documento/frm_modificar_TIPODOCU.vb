Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_TIPODOCU

    '===================================
    '*** MODIFICAR TIPO DE DOCUMENTO ***
    '===================================

#Region "VARIABLES"

    Dim id As Integer

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal idCodigo As Integer)
        id = idCodigo
        InitializeComponent()
        pro_inicializarControles()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_inicializarControles()
        Dim objdatos As New cla_ESTADO

        cboTIDOESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboTIDOESTA.DisplayMember = "ESTADESC"
        cboTIDOESTA.ValueMember = "ESTACODI"

        Dim objdatos1 As New cla_TIPODOCU
        Dim tbl As New DataTable

        tbl = objdatos1.fun_Buscar_ID_MANT_TIPODOCU(id)

        txtTIDOCODI.Text = Trim(tbl.Rows(0).Item(1))
        txtTIDODESC.Text = Trim(tbl.Rows(0).Item(2))
        cboTIDOESTA.SelectedValue = tbl.Rows(0).Item(3)

        txtTIDODESC.Focus()

    End Sub
    Private Sub pro_LimpiarCampos()

        txtTIDOCODI.Text = ""
        txtTIDODESC.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(txtTIDOCODI.Text, txtTIDODESC.Text, cboTIDOESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtTIDODESC.Focus()
            Else
                Dim objdatos As New cla_TIPODOCU

                If (objdatos.fun_Actualizar_MANT_TIPODOCU(id, txtTIDOCODI.Text, txtTIDODESC.Text, cboTIDOESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                    txtTIDODESC.Focus()
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
        txtTIDODESC.Focus()
        Me.Close()

    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txtTIDOCODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTIDOCODI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtTIDODESC.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub txtTIDODESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTIDODESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboTIDOESTA.Focus()
        End If
    End Sub
    Private Sub cboTIDOESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTIDOESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTIDODESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTIDODESC.Validated
        If Trim(txtTIDODESC.Text) = "" Then
            txtTIDODESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboTIDOESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTIDOESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtTIDOCODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTIDOCODI.GotFocus
        txtTIDOCODI.SelectionStart = 0
        txtTIDOCODI.SelectionLength = Len(txtTIDOCODI.Text)
        strBARRESTA.Items(0).Text = txtTIDOCODI.AccessibleDescription
    End Sub
    Private Sub txtTIDODESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTIDODESC.GotFocus
        txtTIDODESC.SelectionStart = 0
        txtTIDODESC.SelectionLength = Len(txtTIDODESC.Text)
        strBARRESTA.Items(0).Text = txtTIDODESC.AccessibleDescription
    End Sub
    Private Sub cboTIDOESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTIDOESTA.GotFocus
        cboTIDOESTA.SelectionStart = 0
        cboTIDOESTA.SelectionLength = Len(cboTIDOESTA.Text)
        strBARRESTA.Items(0).Text = cboTIDOESTA.AccessibleDescription
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