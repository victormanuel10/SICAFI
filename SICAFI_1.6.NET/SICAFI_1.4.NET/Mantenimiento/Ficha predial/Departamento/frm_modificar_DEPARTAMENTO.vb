Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_DEPARTAMENTO

    '==============================
    '*** MODIFICAR DEPARTAMENTO ***
    '==============================

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

        cboDEPAESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboDEPAESTA.DisplayMember = "ESTADESC"
        cboDEPAESTA.ValueMember = "ESTACODI"

        Dim objdatos1 As New cla_DEPARTAMENTO
        Dim tbl As New DataTable

        tbl = objdatos1.fun_Buscar_ID_MANT_DEPARTAMENTO(id)

        txtDEPACODI.Text = Trim(tbl.Rows(0).Item(1))
        txtDEPADESC.Text = Trim(tbl.Rows(0).Item(2))
        cboDEPAESTA.SelectedValue = tbl.Rows(0).Item(3)


    End Sub
    Private Sub pro_LimpiarCampos()

        txtDEPACODI.Text = ""
        txtDEPADESC.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            If fun_Verificar_Campos_Llenos_3_DATOS(txtDEPACODI.Text, txtDEPADESC.Text, cboDEPAESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtDEPADESC.Focus()
            Else

                Dim objdatos As New cla_DEPARTAMENTO

                If (objdatos.fun_Actualizar_MANT_DEPARTAMENTO(id, txtDEPACODI.Text, txtDEPADESC.Text, cboDEPAESTA.SelectedValue)) Then
                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                    txtDEPADESC.Focus()
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
        txtDEPADESC.Focus()
        Me.Close()

    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txtDEPACODI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDEPACODI.KeyPress

        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                    e.Handled = True
                    strBARRESTA.Items(1).Text = IncoValoNume
                    mod_MENSAJE.Inco_Valo_Nume()
                Else
                    txtDEPADESC.Focus()
                End If
            End If
        End If

    End Sub
    Private Sub txtDEPADESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDEPADESC.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboDEPAESTA.Focus()
        End If

    End Sub
    Private Sub cboDEPAESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDEPAESTA.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If

    End Sub

#End Region

#Region "Validated"

    Private Sub txtDEPADESC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDEPADESC.Validated
        If Trim(txtDEPADESC.Text) = "" Then
            txtDEPADESC.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboDEPAESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDEPAESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtDEPACODI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDEPACODI.GotFocus
        txtDEPACODI.SelectionStart = 0
        txtDEPACODI.SelectionLength = Len(txtDEPACODI.Text)
        strBARRESTA.Items(0).Text = txtDEPACODI.AccessibleDescription
    End Sub
    Private Sub txtDEPADESC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDEPADESC.GotFocus
        txtDEPADESC.SelectionStart = 0
        txtDEPADESC.SelectionLength = Len(txtDEPADESC.Text)
        strBARRESTA.Items(0).Text = txtDEPADESC.AccessibleDescription
    End Sub
    Private Sub cboDEPAESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDEPAESTA.GotFocus
        cboDEPAESTA.SelectionStart = 0
        cboDEPAESTA.SelectionLength = Len(cboDEPAESTA.Text)
        strBARRESTA.Items(0).Text = cboDEPAESTA.AccessibleDescription
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