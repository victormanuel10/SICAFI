Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_CALIPROP

    '========================================
    '*** MODIFICAR CALIDAD DE PROPIETARIO ***
    '========================================

#Region "VARIABLE"

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

        cboCAPRESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
        cboCAPRESTA.DisplayMember = "ESTADESC"
        cboCAPRESTA.ValueMember = "ESTACODI"

        Dim objdatos1 As New cla_CALIPROP
        Dim tbl As New DataTable

        tbl = objdatos1.fun_Buscar_ID_MANT_CALIPROP(id)

        txtCAPRCODI.Text = Trim(tbl.Rows(0).Item(1))
        txtCAPRDESC.Text = Trim(tbl.Rows(0).Item(2))
        cboCAPRESTA.SelectedValue = tbl.Rows(0).Item(3)


    End Sub
    Private Sub pro_LimpiarCampos()

        txtCAPRCODI.Text = ""
        txtCAPRDESC.Text = ""
        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try

            If fun_Verificar_Campos_Llenos_3_DATOS(txtCAPRCODI.Text, txtCAPRDESC.Text, cboCAPRESTA.Text) = False Then
                mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                txtCAPRDESC.Focus()
            Else
                Dim objdatos As New cla_CALIPROP

                If objdatos.fun_Actualizar_MANT_CALIPROP(id, Me.txtCAPRCODI.Text, Me.txtCAPRDESC.Text, Me.cboCAPRESTA.SelectedValue) = True Then
                    Me.txtCAPRDESC.Focus()
                    Me.Close()

                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()
                Else
                    mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        txtCAPRDESC.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCAPRCODI.KeyPress, txtCAPRDESC.KeyPress, cboCAPRESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCAPRCODI.GotFocus, txtCAPRDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus, cboCAPRESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
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