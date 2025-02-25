Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_CONCEPTO

    '=========================
    '*** CONSULTA CONCEPTO ***
    '=========================

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
            Dim stCONCTIIM As String = ""
            Dim stCONCCODI As String = ""
            Dim stCONCDESC As String = ""
            Dim stCONCESTA As String = ""

            ' carga los campos
            If Trim(Me.txtCONCTIIM.Text) = "" Then
                stCONCTIIM = "%"
            Else
                stCONCTIIM = Trim(Me.txtCONCTIIM.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCONCCODI.Text) = "" Then
                stCONCCODI = "%"
            Else
                stCONCCODI = Trim(Me.txtCONCCODI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCONCDESC.Text) = "" Then
                stCONCDESC = "%"
            Else
                stCONCDESC = Trim(Me.txtCONCDESC.Text)
            End If

            If Trim(Me.txtCONCESTA.Text) = "" Then
                stCONCESTA = "%"
            Else
                stCONCESTA = Trim(Me.txtCONCESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "CONCIDRE , "
            stConsulta += "CONCTIIM as 'Tipo de Impuesto', "
            stConsulta += "CONCCODI as 'Concepto', "
            stConsulta += "CONCDESC as 'Descripción', "
            stConsulta += "CONCESTA as 'Estado' "
            stConsulta += "From MANT_CONCEPTO "
            stConsulta += "Where "
            stConsulta += "CONCTIIM like '" & stCONCTIIM & "' and "
            stConsulta += "CONCCODI like '" & stCONCCODI & "' and "
            stConsulta += "CONCDESC like '" & stCONCDESC & "' and "
            stConsulta += "CONCESTA like '" & stCONCESTA & "' "
            stConsulta += "Order by CONCTIIM, CONCCODI "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtCONCCODI.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtCONCTIIM.Text = ""
        Me.txtCONCCODI.Text = ""
        Me.txtCONCDESC.Text = ""
        Me.txtCONCESTA.Text = ""

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
            Dim inId_Reg As New frm_CONCEPTO(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtCONCCODI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtCONCCODI.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtCONCTIIM.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCONCCODI.KeyPress, txtCONCDESC.KeyPress, txtCONCESTA.KeyPress, txtCONCTIIM.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCONCCODI.GotFocus, txtCONCDESC.GotFocus, txtCONCESTA.GotFocus, txtCONCTIIM.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmdAceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#End Region

End Class