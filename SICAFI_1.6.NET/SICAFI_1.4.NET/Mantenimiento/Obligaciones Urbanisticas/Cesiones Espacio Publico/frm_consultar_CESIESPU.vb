Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_CESIESPU

    '========================================
    '*** CONSULTA CESION ESPACION PUBLICO ***
    '========================================

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
            Dim stCEEPDEVI As String = ""
            Dim stCEEPDESC As String = ""
            Dim stCEEPARCE As String = ""
            Dim stCEEPOTUS As String = ""
            Dim stCEEPAMCE As String = ""
            Dim stCEEPESTA As String = ""

            ' carga los campos
            If Trim(Me.txtCEEPDEVI.Text) = "" Then
                stCEEPDEVI = "%"
            Else
                stCEEPDEVI = Trim(Me.txtCEEPDEVI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCEEPDESC.Text) = "" Then
                stCEEPDESC = "%"
            Else
                stCEEPDESC = Trim(Me.txtCEEPDESC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCEEPARCE.Text) = "" Then
                stCEEPARCE = "%"
            Else
                stCEEPARCE = Trim(Me.txtCEEPARCE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCEEPOTUS.Text) = "" Then
                stCEEPOTUS = "%"
            Else
                stCEEPOTUS = Trim(Me.txtCEEPOTUS.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCEEPAMCE.Text) = "" Then
                stCEEPAMCE = "%"
            Else
                stCEEPAMCE = Trim(Me.txtCEEPAMCE.Text)
            End If

            If Trim(Me.txtCEEPESTA.Text) = "" Then
                stCEEPESTA = "%"
            Else
                stCEEPESTA = Trim(Me.txtCEEPESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "CEEPIDRE , "
            stConsulta += "CEEPDEVI as 'Densidad Vivienda / Ha', "
            stConsulta += "CEEPDESC as 'Descripción', "
            stConsulta += "CEEPARCE as 'Área a ceder por unidad de vivienda', "
            stConsulta += "CEEPOTUS as 'Aporte por otros usos por unidad de destinación y/o cada 100 m2 construidos', "
            stConsulta += "CEEPAMCE as 'Área mínima a ceder del área bruta del lote', "
            stConsulta += "CEEPESTA as 'Estado' "
            stConsulta += "From MANT_CESIESPU "
            stConsulta += "Where "
            stConsulta += "CEEPDEVI like '" & stCEEPDEVI & "' and "
            stConsulta += "CEEPDESC like '" & stCEEPDESC & "' and "
            stConsulta += "CEEPARCE like '" & stCEEPARCE & "' and "
            stConsulta += "CEEPOTUS like '" & stCEEPOTUS & "' and "
            stConsulta += "CEEPAMCE like '" & stCEEPAMCE & "' and "
            stConsulta += "CEEPESTA like '" & stCEEPESTA & "' "
            stConsulta += "Order by CEEPDEVI"

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)
            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtCEEPDEVI.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtCEEPDEVI.Text = ""
        Me.txtCEEPDESC.Text = ""
        Me.txtCEEPARCE.Text = ""
        Me.txtCEEPOTUS.Text = ""
        Me.txtCEEPAMCE.Text = ""
        Me.txtCEEPESTA.Text = ""

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
            Dim inId_Reg As New frm_CESIESPU(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtCEEPDEVI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtCEEPDEVI.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtCEEPDEVI.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCEEPDEVI.KeyPress, txtCEEPDESC.KeyPress, txtCEEPESTA.KeyPress, txtCEEPARCE.KeyPress, txtCEEPOTUS.KeyPress, txtCEEPAMCE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEEPDEVI.GotFocus, txtCEEPDESC.GotFocus, txtCEEPESTA.GotFocus, txtCEEPARCE.GotFocus, txtCEEPOTUS.GotFocus, txtCEEPAMCE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmdAceptar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#End Region

End Class