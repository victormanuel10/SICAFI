Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_PERIODO

    '========================
    '*** CONSULTA PERIODO ***
    '========================

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
            Dim stPERIVIGE As String = ""
            Dim stPERIMES As String = ""
            Dim stPERIDESC As String = ""
            Dim stPERIAPLI As String = ""
            Dim stPERIESTA As String = ""

            ' carga los campos
            If Trim(Me.txtPERIVIGE.Text) = "" Then
                stPERIVIGE = "%"
            Else
                stPERIVIGE = Trim(Me.txtPERIVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPERIMES.Text) = "" Then
                stPERIMES = "%"
            Else
                stPERIMES = Trim(Me.txtPERIMES.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPERIDESC.Text) = "" Then
                stPERIDESC = "%"
            Else
                stPERIDESC = Trim(Me.txtPERIDESC.Text)
            End If

            ' carga los campos
            If chkPERIAPLI.CheckState = CheckState.Indeterminate Then
                stPERIAPLI = "%"
            ElseIf chkPERIAPLI.Checked = False Then
                stPERIAPLI = "0"
            ElseIf chkPERIAPLI.Checked = True Then
                stPERIAPLI = "1"
            End If

            ' carga los campos
            If Trim(Me.txtPERIESTA.Text) = "" Then
                stPERIESTA = "%"
            Else
                stPERIESTA = Trim(Me.txtPERIESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "PERIIDRE , "
            stConsulta += "PERIVIGE as 'Vigencia', "
            stConsulta += "PERIMES as 'Mes', "
            stConsulta += "PERIDESC as 'Descripción', "
            stConsulta += "PERIAPLI as 'Aplica', "
            stConsulta += "PERIESTA as 'Estado' "
            stConsulta += "From MANT_PERIODO "
            stConsulta += "Where "
            stConsulta += "PERIVIGE like '" & stPERIVIGE & "' and "
            stConsulta += "PERIMES like '" & stPERIMES & "' and "
            stConsulta += "PERIDESC like '" & stPERIDESC & "' and "
            stConsulta += "PERIAPLI like '" & stPERIAPLI & "' and "
            stConsulta += "PERIESTA like '" & stPERIESTA & "' "
            stConsulta += "Order by PERIVIGE, PERIMES"

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)
            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtPERIVIGE.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtPERIVIGE.Text = ""
        Me.txtPERIMES.Text = ""
        Me.txtPERIDESC.Text = ""
        Me.chkPERIAPLI.CheckState = CheckState.Indeterminate
        Me.txtPERIESTA.Text = ""

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
            Dim inId_Reg As New frm_PERIODO(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtPERIVIGE.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtPERIVIGE.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtPERIVIGE.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPERIVIGE.KeyPress, txtPERIDESC.KeyPress, txtPERIESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPERIVIGE.GotFocus, txtPERIMES.GotFocus, txtPERIDESC.GotFocus, txtPERIESTA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPERIAPLI.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmdAceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#End Region

End Class