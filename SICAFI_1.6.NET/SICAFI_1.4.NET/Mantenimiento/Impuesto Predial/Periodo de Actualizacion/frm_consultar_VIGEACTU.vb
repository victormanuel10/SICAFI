Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_VIGEACTU

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
            Dim stVIACDEPA As String = ""
            Dim stVIACMUNI As String = ""
            Dim stVIACCLSE As String = ""
            Dim stVIACRESO As String = ""
            Dim stVIACDESC As String = ""
            Dim stVIACVIAC As String = ""
            Dim stVIACPOIN As String = ""
            Dim stVIACACTU As String = ""
            Dim stVIACCONS As String = ""
            Dim stVIACESTA As String = ""


            ' carga los campos
            If Trim(Me.txtVIACDEPA.Text) = "" Then
                stVIACDEPA = "%"
            Else
                stVIACDEPA = Trim(Me.txtVIACDEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtVIACMUNI.Text) = "" Then
                stVIACMUNI = "%"
            Else
                stVIACMUNI = Trim(Me.txtVIACMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtVIACCLSE.Text) = "" Then
                stVIACCLSE = "%"
            Else
                stVIACCLSE = Trim(Me.txtVIACCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtVIACCLSE.Text) = "" Then
                stVIACCLSE = "%"
            Else
                stVIACCLSE = Trim(Me.txtVIACCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtVIACRESO.Text) = "" Then
                stVIACRESO = "%"
            Else
                stVIACRESO = Trim(Me.txtVIACRESO.Text)
            End If

            ' carga los campos
            If Trim(Me.txtVIACDESC.Text) = "" Then
                stVIACDESC = "%"
            Else
                stVIACDESC = Trim(Me.txtVIACDESC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtVIACVIAC.Text) = "" Then
                stVIACVIAC = "%"
            Else
                stVIACVIAC = Trim(Me.txtVIACVIAC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtVIACPOIN.Text) = "" Then
                stVIACPOIN = "%"
            Else
                stVIACPOIN = Trim(Me.txtVIACPOIN.Text)
            End If

            ' carga los campos
            If Me.chkVIACACTU.CheckState = CheckState.Indeterminate Then
                stVIACACTU = "%"
            ElseIf Me.chkVIACACTU.Checked = False Then
                stVIACACTU = "0"
            ElseIf Me.chkVIACACTU.Checked = True Then
                stVIACACTU = "1"
            End If

            ' carga los campos
            If Me.chkVIACCONS.CheckState = CheckState.Indeterminate Then
                stVIACCONS = "%"
            ElseIf Me.chkVIACCONS.Checked = False Then
                stVIACCONS = "0"
            ElseIf Me.chkVIACCONS.Checked = True Then
                stVIACCONS = "1"
            End If

            ' carga los campos
            If Trim(Me.txtVIACESTA.Text) = "" Then
                stVIACESTA = "%"
            Else
                stVIACESTA = Trim(Me.txtVIACESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "VIACIDRE , "
            stConsulta += "VIACDEPA as 'Departamento', "
            stConsulta += "VIACMUNI as 'Municipio', "
            stConsulta += "VIACCLSE as 'Sector', "
            stConsulta += "VIACRESO as 'Resolución', "
            stConsulta += "VIACDESC as 'Descripción', "
            stConsulta += "VIACVIAC as 'Vigencia Actu.', "
            stConsulta += "VIACPOIN as '% Incremento', "
            stConsulta += "VIACACTU as 'Actualización', "
            stConsulta += "VIACCONS as 'Conservación', "
            stConsulta += "VIACESTA as 'Estado' "
            stConsulta += "From VIGEACTU "
            stConsulta += "Where "
            stConsulta += "VIACDEPA like '" & stVIACDEPA & "' and "
            stConsulta += "VIACMUNI like '" & stVIACMUNI & "' and "
            stConsulta += "VIACCLSE like '" & stVIACCLSE & "' and "
            stConsulta += "VIACRESO like '" & stVIACRESO & "' and "
            stConsulta += "VIACDESC like '" & stVIACDESC & "' and "
            stConsulta += "VIACVIAC like '" & stVIACVIAC & "' and "
            stConsulta += "VIACPOIN like '" & stVIACPOIN & "' and "
            stConsulta += "VIACACTU like '" & stVIACACTU & "' and "
            stConsulta += "VIACCONS like '" & stVIACCONS & "' and "
            stConsulta += "VIACESTA like '" & stVIACESTA & "' "
            stConsulta += "Order by VIACDEPA, VIACMUNI, VIACCLSE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)
            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtVIACDEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtVIACDEPA.Text = ""
        Me.txtVIACMUNI.Text = ""
        Me.txtVIACCLSE.Text = ""
        Me.txtVIACRESO.Text = ""
        Me.txtVIACDESC.Text = ""
        Me.txtVIACVIAC.Text = ""
        Me.txtVIACPOIN.Text = ""
        Me.chkVIACACTU.CheckState = CheckState.Indeterminate
        Me.chkVIACCONS.CheckState = CheckState.Indeterminate
        Me.txtVIACESTA.Text = ""

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
            Dim inId_Reg As New frm_VIGEACTU(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtVIACDEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtVIACDEPA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtVIACDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVIACDEPA.KeyPress, txtVIACMUNI.KeyPress, txtVIACCLSE.KeyPress, txtVIACRESO.KeyPress, txtVIACDESC.KeyPress, txtVIACVIAC.KeyPress, txtVIACPOIN.KeyPress, chkVIACACTU.KeyPress, chkVIACCONS.KeyPress, txtVIACESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVIACDEPA.GotFocus, txtVIACMUNI.GotFocus, txtVIACCLSE.GotFocus, txtVIACRESO.GotFocus, txtVIACDESC.GotFocus, txtVIACVIAC.GotFocus, txtVIACPOIN.GotFocus, txtVIACESTA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkVIACCONS.GotFocus, chkVIACACTU.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmdAceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
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