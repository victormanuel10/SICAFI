Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_CARGBENE

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
            Dim stCABENURE As String = ""
            Dim stCABEFERE As String = ""
            Dim stCABEUAU As String = ""
            Dim stCABEDESC As String = ""
            Dim stCABEESTA As String = ""

            ' carga los campos
            If Trim(Me.txtCABENURE.Text) = "" Then
                stCABENURE = "%"
            Else
                stCABENURE = Trim(Me.txtCABENURE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCABEFERE.Text) = "" Then
                stCABEFERE = "%"
            Else
                stCABEFERE = Trim(Me.txtCABEFERE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCABEUAU.Text) = "" Then
                stCABEUAU = "%"
            Else
                stCABEUAU = Trim(Me.txtCABEUAU.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCABEDESC.Text) = "" Then
                stCABEDESC = "%"
            Else
                stCABEDESC = Trim(Me.txtCABEDESC.Text)
            End If

            If Trim(Me.txtCABEESTA.Text) = "" Then
                stCABEESTA = "%"
            Else
                stCABEESTA = Trim(Me.txtCABEESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "CABEIDRE , "
            stConsulta += "CABENURE as 'Nro. Resolución', "
            stConsulta += "CABEFERE as 'Fecha Resolución', "
            stConsulta += "CABEUAU as 'U. A. U.', "
            stConsulta += "CABEDESC as 'Descripción', "
            stConsulta += "CABEESTA as 'Estado' "
            stConsulta += "From MANT_CARGBENE "
            stConsulta += "Where "
            stConsulta += "CABENURE like '" & stCABENURE & "' and "
            stConsulta += "CABEFERE like '" & stCABEFERE & "' and "
            stConsulta += "CABEDESC like '" & stCABEDESC & "' and "
            stConsulta += "CABEESTA like '" & stCABEESTA & "' "
            stConsulta += "Order by CABENURE"

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)
            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtCABENURE.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtCABENURE.Text = ""
        Me.txtCABEFERE.Text = ""
        Me.txtCABEUAU.Text = ""
        Me.txtCABEDESC.Text = ""
        Me.txtCABEESTA.Text = ""

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
            Dim inId_Reg As New frm_CARGBENE(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtCABENURE.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtCABENURE.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtCABENURE.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCABENURE.KeyPress, txtCABEDESC.KeyPress, txtCABEESTA.KeyPress, txtCABEFERE.KeyPress, txtCABEUAU.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCABENURE.GotFocus, txtCABEDESC.GotFocus, txtCABEESTA.GotFocus, txtCABEFERE.GotFocus, txtCABEUAU.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmdAceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#End Region

End Class