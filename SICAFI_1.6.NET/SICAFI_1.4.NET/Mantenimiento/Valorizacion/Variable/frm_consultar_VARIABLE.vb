Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_VARIABLE

    '=========================
    '*** CONSULTA VARIABLE ***
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
            Dim stVARITIVA As String = ""
            Dim stVARICODI As String = ""
            Dim stVARIDESC As String = ""
            Dim stVARIESTA As String = ""

            ' carga los campos
            If Trim(Me.txtVARITIVA.Text) = "" Then
                stVARITIVA = "%"
            Else
                stVARITIVA = Trim(Me.txtVARITIVA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtVARICODI.Text) = "" Then
                stVARICODI = "%"
            Else
                stVARICODI = Trim(Me.txtVARICODI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtVARIDESC.Text) = "" Then
                stVARIDESC = "%"
            Else
                stVARIDESC = Trim(Me.txtVARIDESC.Text)
            End If

            If Trim(Me.txtVARIESTA.Text) = "" Then
                stVARIESTA = "%"
            Else
                stVARIESTA = Trim(Me.txtVARIESTA.Text)
            End If

            'VARIatena la consulta
            stConsulta += "Select "
            stConsulta += "VARIIDRE , "
            stConsulta += "VARITIVA as 'Tipo de Variable', "
            stConsulta += "VARICODI as 'Código', "
            stConsulta += "VARIDESC as 'Descripción', "
            stConsulta += "VARIESTA as 'Estado' "
            stConsulta += "From MANT_VARIABLE "
            stConsulta += "Where "
            stConsulta += "VARITIVA like '" & stVARITIVA & "' and "
            stConsulta += "VARICODI like '" & stVARICODI & "' and "
            stConsulta += "VARIDESC like '" & stVARIDESC & "' and "
            stConsulta += "VARIESTA like '" & stVARIESTA & "' "
            stConsulta += "Order by VARITIVA, VARICODI "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtVARICODI.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtVARITIVA.Text = ""
        Me.txtVARICODI.Text = ""
        Me.txtVARIDESC.Text = ""
        Me.txtVARIESTA.Text = ""

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
            Dim inId_Reg As New frm_VARIABLE(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtVARICODI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtVARICODI.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtVARITIVA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVARICODI.KeyPress, txtVARIDESC.KeyPress, txtVARIESTA.KeyPress, txtVARITIVA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVARICODI.GotFocus, txtVARIDESC.GotFocus, txtVARIESTA.GotFocus, txtVARITIVA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmdAceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#End Region

End Class