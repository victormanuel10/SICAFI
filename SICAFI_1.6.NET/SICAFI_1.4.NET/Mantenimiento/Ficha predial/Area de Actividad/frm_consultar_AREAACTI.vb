Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_AREAACTI

    '===================================
    '*** CONSULTA AREAS DE ACTIVIDAD ***
    '===================================

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

            Dim stARACCODI As String = ""
            Dim stARACDESC As String = ""
            Dim stARACESTA As String = ""

            ' carga los campos
            If Trim(Me.txtARACCODI.Text) = "" Then
                stARACCODI = "%"
            Else
                stARACCODI = Trim(Me.txtARACCODI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtARACDESC.Text) = "" Then
                stARACDESC = "%"
            Else
                stARACDESC = Trim(Me.txtARACDESC.Text)
            End If

            If Trim(Me.txtARACESTA.Text) = "" Then
                stARACESTA = "%"
            Else
                stARACESTA = Trim(Me.txtARACESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "ARACIDRE , "
            stConsulta += "ARACCODI as 'Código', "
            stConsulta += "ARACDESC as 'Descripción', "
            stConsulta += "ARACESTA as 'Estado' "
            stConsulta += "From MANT_AREAACTI "
            stConsulta += "Where "
            stConsulta += "ARACCODI like '" & stARACCODI & "' and "
            stConsulta += "ARACDESC like '" & stARACDESC & "' and "
            stConsulta += "ARACESTA like '" & stARACESTA & "' "
            stConsulta += "Order by ARACCODI "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtARACCODI.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtARACCODI.Text = ""
        Me.txtARACDESC.Text = ""
        Me.txtARACESTA.Text = ""

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
            Dim inId_Reg As New frm_AREAACTI(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtARACCODI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtARACCODI.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtARACCODI.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtARACCODI.KeyPress, txtARACDESC.KeyPress, txtARACESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtARACCODI.GotFocus, txtARACDESC.GotFocus, txtARACESTA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmdAceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#End Region

End Class