Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_CABEPLPA

    '=====================================================
    '*** CONSULTA CARGAS Y BENEFICIOS DEL PLAN PARCIAL ***
    '=====================================================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False

    Dim dt As DataTable

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_Reconsultar()
        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            ' crea la variable de los campos
            Dim stCBPPCODI As String = ""
            Dim stCBPPDESC As String = ""
            Dim stCBPPESTA As String = ""

            ' carga los campos
            If Trim(Me.txtCBPPCODI.Text) = "" Then
                stCBPPCODI = "%"
            Else
                stCBPPCODI = Trim(Me.txtCBPPCODI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCBPPDESC.Text) = "" Then
                stCBPPDESC = "%"
            Else
                stCBPPDESC = Trim(Me.txtCBPPDESC.Text)
            End If

            If Trim(Me.txtCBPPESTA.Text) = "" Then
                stCBPPESTA = "%"
            Else
                stCBPPESTA = Trim(Me.txtCBPPESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "CBPPIDRE , "
            stConsulta += "CBPPCODI as 'Codigo', "
            stConsulta += "CBPPDESC as 'Descripción', "
            stConsulta += "CBPPESTA as 'Estado' "
            stConsulta += "From MANT_CABEPLPA "
            stConsulta += "Where "
            stConsulta += "CBPPCODI like '" & stCBPPCODI & "' and "
            stConsulta += "CBPPDESC like '" & stCBPPDESC & "' and "
            stConsulta += "CBPPESTA like '" & stCBPPESTA & "' "
            stConsulta += "Order by CBPPCODI"

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)
            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtCBPPCODI.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtCBPPCODI.Text = ""
        Me.txtCBPPDESC.Text = ""
        Me.txtCBPPESTA.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click

        Try
            pro_Reconsultar()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click

        If Me.dgvCONSULTA.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_CABEPLPA(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtCBPPCODI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtCBPPCODI.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtCBPPCODI.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCBPPCODI.KeyPress, txtCBPPDESC.KeyPress, txtCBPPESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCBPPCODI.GotFocus, txtCBPPDESC.GotFocus, txtCBPPESTA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmdAceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#End Region

End Class