Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_DEECLOTE

    '==============================================
    '*** CONSULTA DESTINOS ECONÓMICOS POR LOTES ***
    '==============================================

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
            Dim stDELODEPA As String = ""
            Dim stDELOMUNI As String = ""
            Dim stDELOCLSE As String = ""
            Dim stDELOVIGE As String = ""
            Dim stDELODEEC As String = ""
            Dim stDELOTARI As String = ""
            Dim stDELOESTA As String = ""

            Dim stDELOLOTE As String = ""
            Dim stDELOLE44 As String = ""
            Dim stDELOIMPR As String = ""
            Dim stDELOACBO As String = ""
            Dim stDELOALPU As String = ""
            Dim stDELOTAAS As String = ""

            ' carga los campos
            If Trim(Me.txtDELODEPA.Text) = "" Then
                stDELODEPA = "%"
            Else
                stDELODEPA = Trim(Me.txtDELODEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtDELOMUNI.Text) = "" Then
                stDELOMUNI = "%"
            Else
                stDELOMUNI = Trim(Me.txtDELOMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtDELOCLSE.Text) = "" Then
                stDELOCLSE = "%"
            Else
                stDELOCLSE = Trim(Me.txtDELOCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtDELOVIGE.Text) = "" Then
                stDELOVIGE = "%"
            Else
                stDELOVIGE = Trim(Me.txtDELOVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtDELODEEC.Text) = "" Then
                stDELODEEC = "%"
            Else
                stDELODEEC = Trim(Me.txtDELODEEC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtDELOESTA.Text) = "" Then
                stDELOESTA = "%"
            Else
                stDELOESTA = Trim(Me.txtDELOESTA.Text)
            End If

            ' carga los campos
            If Me.chkDELOLOTE.CheckState = CheckState.Indeterminate Then
                stDELOLOTE = "%"
            ElseIf Me.chkDELOLOTE.Checked = False Then
                stDELOLOTE = "0"
            ElseIf Me.chkDELOLOTE.Checked = True Then
                stDELOLOTE = "1"
            End If

            ' carga los campos
            If Me.chkDELOLE44.CheckState = CheckState.Indeterminate Then
                stDELOLE44 = "%"
            ElseIf Me.chkDELOLE44.Checked = False Then
                stDELOLE44 = "0"
            ElseIf Me.chkDELOLE44.Checked = True Then
                stDELOLE44 = "1"
            End If

            ' carga los campos
            If Me.chkDELOIMPR.CheckState = CheckState.Indeterminate Then
                stDELOIMPR = "%"
            ElseIf Me.chkDELOIMPR.Checked = False Then
                stDELOIMPR = "0"
            ElseIf Me.chkDELOIMPR.Checked = True Then
                stDELOIMPR = "1"
            End If

            ' carga los campos
            If Me.chkDELOACBO.CheckState = CheckState.Indeterminate Then
                stDELOACBO = "%"
            ElseIf Me.chkDELOACBO.Checked = False Then
                stDELOACBO = "0"
            ElseIf Me.chkDELOACBO.Checked = True Then
                stDELOACBO = "1"
            End If

            ' carga los campos
            If Me.chkDELOTAAS.CheckState = CheckState.Indeterminate Then
                stDELOTAAS = "%"
            ElseIf Me.chkDELOTAAS.Checked = False Then
                stDELOTAAS = "0"
            ElseIf Me.chkDELOTAAS.Checked = True Then
                stDELOTAAS = "1"
            End If

            ' carga los campos
            If Me.chkDELOALPU.CheckState = CheckState.Indeterminate Then
                stDELOALPU = "%"
            ElseIf Me.chkDELOALPU.Checked = False Then
                stDELOALPU = "0"
            ElseIf Me.chkDELOALPU.Checked = True Then
                stDELOALPU = "1"
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "DELOIDRE , "
            stConsulta += "DELODEPA as 'Departamento', "
            stConsulta += "DELOMUNI as 'Municipio', "
            stConsulta += "DELOCLSE as 'Sector', "
            stConsulta += "DELOVIGE as 'Vigencia', "
            stConsulta += "DELODEEC as 'Destinación', "
            stConsulta += "DELOLOTE as 'Lote', "
            stConsulta += "DELOLE44 as 'Ley 44', "
            stConsulta += "DELOIMPR as 'Impu. predial', "
            stConsulta += "DELOACBO as 'Acti. bomberil', "
            stConsulta += "DELOALPU as 'Alum. publico', "
            stConsulta += "DELOTAAS as 'Tasa de aseo', "
            stConsulta += "DELOESTA as 'Estado' "
            stConsulta += "From DEECLOTE "
            stConsulta += "Where "
            stConsulta += "DELODEPA like '" & stDELODEPA & "' and "
            stConsulta += "DELOMUNI like '" & stDELOMUNI & "' and "
            stConsulta += "DELOCLSE like '" & stDELOCLSE & "' and "
            stConsulta += "DELOVIGE like '" & stDELOVIGE & "' and "
            stConsulta += "DELODEEC like '" & stDELODEEC & "' and "
            stConsulta += "DELOLOTE like '" & stDELOLOTE & "' and "
            stConsulta += "DELOLE44 like '" & stDELOLE44 & "' and "
            stConsulta += "DELOIMPR like '" & stDELOIMPR & "' and "
            stConsulta += "DELOACBO like '" & stDELOACBO & "' and "
            stConsulta += "DELOALPU like '" & stDELOALPU & "' and "
            stConsulta += "DELOTAAS like '" & stDELOTAAS & "' and "
            stConsulta += "DELOESTA like '" & stDELOESTA & "' "
            stConsulta += "Order by DELODEPA, DELOMUNI, DELOCLSE, DELODEEC "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtDELODEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtDELODEPA.Text = ""
        Me.txtDELOMUNI.Text = ""
        Me.txtDELOCLSE.Text = ""
        Me.txtDELOVIGE.Text = ""
        Me.txtDELODEEC.Text = ""
        Me.txtDELOESTA.Text = ""

        Me.chkDELOLOTE.CheckState = CheckState.Indeterminate
        Me.chkDELOLE44.CheckState = CheckState.Indeterminate
        Me.chkDELOIMPR.CheckState = CheckState.Indeterminate
        Me.chkDELOACBO.CheckState = CheckState.Indeterminate
        Me.chkDELOALPU.CheckState = CheckState.Indeterminate
        Me.chkDELOTAAS.CheckState = CheckState.Indeterminate

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
            Dim inId_Reg As New frm_DEECLOTE(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtDELODEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtDELODEPA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtDELODEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDELODEPA.KeyPress, txtDELOMUNI.KeyPress, txtDELOCLSE.KeyPress, txtDELOVIGE.KeyPress, txtDELODEEC.KeyPress, txtDELOESTA.KeyPress, chkDELOLOTE.KeyPress, chkDELOLE44.KeyPress, chkDELOIMPR.KeyPress, chkDELOACBO.KeyPress, chkDELOALPU.KeyPress, chkDELOTAAS.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDELODEPA.GotFocus, txtDELOMUNI.GotFocus, txtDELOCLSE.GotFocus, txtDELOVIGE.GotFocus, txtDELODEEC.GotFocus, txtDELOESTA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDELOLOTE.GotFocus, chkDELOLE44.GotFocus, chkDELOIMPR.GotFocus, chkDELOACBO.GotFocus, chkDELOALPU.GotFocus, chkDELOTAAS.GotFocus
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