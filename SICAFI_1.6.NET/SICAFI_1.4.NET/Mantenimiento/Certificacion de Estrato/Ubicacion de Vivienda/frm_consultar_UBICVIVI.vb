Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_UBICVIVI

    '======================================
    '*** CONSULTA UBICACION DE VIVIENDA ***
    '======================================

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
            Dim stUBVICODI As String = ""
            Dim stUBVIDESC As String = ""
            Dim stUBVIESTA As String = ""

            ' carga los campos
            If Trim(Me.txtUBVICODI.Text) = "" Then
                stUBVICODI = "%"
            Else
                stUBVICODI = Trim(Me.txtUBVICODI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtUBVIDESC.Text) = "" Then
                stUBVIDESC = "%"
            Else
                stUBVIDESC = Trim(Me.txtUBVIDESC.Text)
            End If

            If Trim(Me.txtUBVIESTA.Text) = "" Then
                stUBVIESTA = "%"
            Else
                stUBVIESTA = Trim(Me.txtUBVIESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "UBVIIDRE , "
            stConsulta += "UBVICODI as 'Codigo', "
            stConsulta += "UBVIDESC as 'Descripción', "
            stConsulta += "UBVIESTA as 'Estado' "
            stConsulta += "From MANT_UBICVIVI "
            stConsulta += "Where "
            stConsulta += "UBVICODI like '" & stUBVICODI & "' and "
            stConsulta += "UBVIDESC like '" & stUBVIDESC & "' and "
            stConsulta += "UBVIESTA like '" & stUBVIESTA & "' "
            stConsulta += "Order by UBVICODI"

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)
            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtUBVICODI.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtUBVICODI.Text = ""
        Me.txtUBVIDESC.Text = ""
        Me.txtUBVIESTA.Text = ""

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
            Dim inId_Reg As New frm_UBICVIVI(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtUBVICODI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtUBVICODI.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtUBVICODI.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUBVICODI.KeyPress, txtUBVIDESC.KeyPress, txtUBVIESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUBVICODI.GotFocus, txtUBVIDESC.GotFocus, txtUBVIESTA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmdAceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#End Region

End Class