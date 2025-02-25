Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_CESIEQUI

    '====================================
    '*** CONSULTA CESION EQUIPAMIENTO ***
    '====================================

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
            Dim stCEEQESSO As String = ""
            Dim stCEEQDESC As String = ""
            Dim stCEEQUNDE As String = ""
            Dim stCEEQEQSA As String = ""
            Dim stCEEQESTA As String = ""

            ' carga los campos
            If Trim(Me.txtCEEQESSO.Text) = "" Then
                stCEEQESSO = "%"
            Else
                stCEEQESSO = Trim(Me.txtCEEQESSO.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCEEQDESC.Text) = "" Then
                stCEEQDESC = "%"
            Else
                stCEEQDESC = Trim(Me.txtCEEQDESC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCEEQUNDE.Text) = "" Then
                stCEEQUNDE = "%"
            Else
                stCEEQUNDE = Trim(Me.txtCEEQUNDE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCEEQEQSA.Text) = "" Then
                stCEEQEQSA = "%"
            Else
                stCEEQEQSA = Trim(Me.txtCEEQEQSA.Text)
            End If

            If Trim(Me.txtCEEQESTA.Text) = "" Then
                stCEEQESTA = "%"
            Else
                stCEEQESTA = Trim(Me.txtCEEQESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "CEEQIDRE , "
            stConsulta += "CEEQESSO as 'Estrato socioeconómico', "
            stConsulta += "CEEQDESC as 'Descripción', "
            stConsulta += "CEEQUNDE as 'm2 por unidad de destinación y/o por cada 100 m2 de área construida útil de otros usos', "
            stConsulta += "CEEQEQSA as 'Equivalencia en salarios míminos legales mensuales vigentes por unidad de destinación', "
            stConsulta += "CEEQESTA as 'Estado' "
            stConsulta += "From MANT_CESIEQUI "
            stConsulta += "Where "
            stConsulta += "CEEQESSO like '" & stCEEQESSO & "' and "
            stConsulta += "CEEQDESC like '" & stCEEQDESC & "' and "
            stConsulta += "CEEQUNDE like '" & stCEEQUNDE & "' and "
            stConsulta += "CEEQEQSA like '" & stCEEQEQSA & "' and "
            stConsulta += "CEEQESTA like '" & stCEEQESTA & "' "
            stConsulta += "Order by CEEQESSO"

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)
            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtCEEQESSO.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtCEEQESSO.Text = ""
        Me.txtCEEQDESC.Text = ""
        Me.txtCEEQUNDE.Text = ""
        Me.txtCEEQEQSA.Text = ""
        Me.txtCEEQESTA.Text = ""

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
            Dim inId_Reg As New frm_CESIEQUI(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtCEEQESSO.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtCEEQESSO.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtCEEQESSO.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCEEQESSO.KeyPress, txtCEEQDESC.KeyPress, txtCEEQESTA.KeyPress, txtCEEQUNDE.KeyPress, txtCEEQEQSA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEEQESSO.GotFocus, txtCEEQDESC.GotFocus, txtCEEQESTA.GotFocus, txtCEEQUNDE.GotFocus, txtCEEQEQSA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmdAceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#End Region

End Class