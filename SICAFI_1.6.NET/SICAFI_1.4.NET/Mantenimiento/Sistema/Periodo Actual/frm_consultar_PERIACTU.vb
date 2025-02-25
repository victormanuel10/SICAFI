Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_PERIACTU

    '===============================
    '*** CONSULTA PEACODO ACTUAL ***
    '===============================

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
            Dim stPEACCODI As String = ""
            Dim stPEACDESC As String = ""
            Dim stPEACPEAC As String = ""
            Dim stPEACESTA As String = ""

            ' carga los campos
            If Trim(Me.txtPEACCODI.Text) = "" Then
                stPEACCODI = "%"
            Else
                stPEACCODI = Trim(Me.txtPEACCODI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPEACDESC.Text) = "" Then
                stPEACDESC = "%"
            Else
                stPEACDESC = Trim(Me.txtPEACDESC.Text)
            End If

            ' carga los campos
            If chkPEACPEAC.CheckState = CheckState.Indeterminate Then
                stPEACPEAC = "%"
            ElseIf chkPEACPEAC.Checked = False Then
                stPEACPEAC = "0"
            ElseIf chkPEACPEAC.Checked = True Then
                stPEACPEAC = "1"
            End If

            ' carga los campos
            If Trim(Me.txtPEACESTA.Text) = "" Then
                stPEACESTA = "%"
            Else
                stPEACESTA = Trim(Me.txtPEACESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "PEACIDRE , "
            stConsulta += "PEACCODI as 'Vigencia', "
            stConsulta += "PEACDESC as 'Descripción', "
            stConsulta += "PEACPEAC as 'Periodo actual', "
            stConsulta += "PEACESTA as 'Estado' "
            stConsulta += "From MANT_PERIACTU "
            stConsulta += "Where "
            stConsulta += "PEACCODI like '" & stPEACCODI & "' and "
            stConsulta += "PEACDESC like '" & stPEACDESC & "' and "
            stConsulta += "PEACPEAC like '" & stPEACPEAC & "' and "
            stConsulta += "PEACESTA like '" & stPEACESTA & "' "
            stConsulta += "Order by PEACCODI "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)
            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtPEACCODI.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtPEACCODI.Text = ""
        Me.txtPEACDESC.Text = ""
        Me.chkPEACPEAC.CheckState = CheckState.Indeterminate
        Me.txtPEACESTA.Text = ""

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
            Dim inId_Reg As New frm_PERIACTU(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtPEACCODI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtPEACCODI.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtPEACCODI.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPEACCODI.KeyPress, txtPEACDESC.KeyPress, txtPEACESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPEACCODI.GotFocus, txtPEACDESC.GotFocus, txtPEACESTA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPEACPEAC.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmdAceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#End Region


End Class