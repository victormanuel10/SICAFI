Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_FORMMUNI

    '==================================
    '*** CONSULTA FORMULA MUNICIPIO ***
    '==================================

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
            Dim stFOMUDEPA As String = ""
            Dim stFOMUMUNI As String = ""
            Dim stFOMUCLSE As String = ""
            Dim stFOMUVIGE As String = ""
            Dim stFOMUTIIM As String = ""
            Dim stFOMUCONC As String = ""
            Dim stFOMUFORM As String = ""
            Dim stFOMUDESC As String = ""
            Dim stFOMUESTA As String = ""

            Dim stFOMUIMPR As String = ""
            Dim stFOMUACBO As String = ""
            Dim stFOMUALPU As String = ""
            Dim stFOMUTAAS As String = ""

            ' carga los campos
            If Trim(Me.txtFOMUDEPA.Text) = "" Then
                stFOMUDEPA = "%"
            Else
                stFOMUDEPA = Trim(Me.txtFOMUDEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtFOMUMUNI.Text) = "" Then
                stFOMUMUNI = "%"
            Else
                stFOMUMUNI = Trim(Me.txtFOMUMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtFOMUCLSE.Text) = "" Then
                stFOMUCLSE = "%"
            Else
                stFOMUCLSE = Trim(Me.txtFOMUCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtFOMUVIGE.Text) = "" Then
                stFOMUVIGE = "%"
            Else
                stFOMUVIGE = Trim(Me.txtFOMUVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtFOMUTIIM.Text) = "" Then
                stFOMUTIIM = "%"
            Else
                stFOMUTIIM = Trim(Me.txtFOMUTIIM.Text)
            End If

            ' carga los campos
            If Trim(Me.txtFOMUCONC.Text) = "" Then
                stFOMUCONC = "%"
            Else
                stFOMUCONC = Trim(Me.txtFOMUCONC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtFOMUFORM.Text) = "" Then
                stFOMUFORM = "%"
            Else
                stFOMUFORM = Trim(Me.txtFOMUFORM.Text)
            End If

            ' carga los campos
            If Trim(Me.txtFOMUDESC.Text) = "" Then
                stFOMUDESC = "%"
            Else
                stFOMUDESC = Trim(Me.txtFOMUDESC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtFOMUESTA.Text) = "" Then
                stFOMUESTA = "%"
            Else
                stFOMUESTA = Trim(Me.txtFOMUESTA.Text)
            End If

            ' carga los campos
            If Me.chkFOMUIMPR.CheckState = CheckState.Indeterminate Then
                stFOMUIMPR = "%"
            ElseIf Me.chkFOMUIMPR.Checked = False Then
                stFOMUIMPR = "0"
            ElseIf Me.chkFOMUIMPR.Checked = True Then
                stFOMUIMPR = "1"
            End If

            ' carga los campos
            If Me.chkFOMUACBO.CheckState = CheckState.Indeterminate Then
                stFOMUACBO = "%"
            ElseIf Me.chkFOMUACBO.Checked = False Then
                stFOMUACBO = "0"
            ElseIf Me.chkFOMUACBO.Checked = True Then
                stFOMUACBO = "1"
            End If

            ' carga los campos
            If Me.chkFOMUTAAS.CheckState = CheckState.Indeterminate Then
                stFOMUTAAS = "%"
            ElseIf Me.chkFOMUTAAS.Checked = False Then
                stFOMUTAAS = "0"
            ElseIf Me.chkFOMUTAAS.Checked = True Then
                stFOMUTAAS = "1"
            End If

            ' carga los campos
            If Me.chkFOMUALPU.CheckState = CheckState.Indeterminate Then
                stFOMUALPU = "%"
            ElseIf Me.chkFOMUALPU.Checked = False Then
                stFOMUALPU = "0"
            ElseIf Me.chkFOMUALPU.Checked = True Then
                stFOMUALPU = "1"
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "FOMUIDRE , "
            stConsulta += "FOMUDEPA as 'Departamento', "
            stConsulta += "FOMUMUNI as 'Municipio', "
            stConsulta += "FOMUCLSE as 'Sector', "
            stConsulta += "FOMUVIGE as 'Vigencia', "
            stConsulta += "FOMUTIIM as 'Tipo impuesto', "
            stConsulta += "FOMUCONC as 'Concepto', "
            stConsulta += "FOMUFORM as 'Formula', "
            stConsulta += "FOMUDESC as 'Descripción', "
            stConsulta += "FOMUIMPR as 'Impu. predial', "
            stConsulta += "FOMUACBO as 'Acti. bomberil', "
            stConsulta += "FOMUALPU as 'Alum. publico', "
            stConsulta += "FOMUTAAS as 'Tasa de aseo', "
            stConsulta += "FOMUESTA as 'Estado' "
            stConsulta += "From FORMMUNI "
            stConsulta += "Where "
            stConsulta += "FOMUDEPA like '" & stFOMUDEPA & "' and "
            stConsulta += "FOMUMUNI like '" & stFOMUMUNI & "' and "
            stConsulta += "FOMUCLSE like '" & stFOMUCLSE & "' and "
            stConsulta += "FOMUVIGE like '" & stFOMUVIGE & "' and "
            stConsulta += "FOMUTIIM like '" & stFOMUTIIM & "' and "
            stConsulta += "FOMUCONC like '" & stFOMUCONC & "' and "
            stConsulta += "FOMUFORM like '" & stFOMUFORM & "' and "
            stConsulta += "FOMUDESC like '" & stFOMUDESC & "' and "
            stConsulta += "FOMUIMPR like '" & stFOMUIMPR & "' and "
            stConsulta += "FOMUACBO like '" & stFOMUACBO & "' and "
            stConsulta += "FOMUALPU like '" & stFOMUALPU & "' and "
            stConsulta += "FOMUTAAS like '" & stFOMUTAAS & "' and "
            stConsulta += "FOMUESTA like '" & stFOMUESTA & "' "
            stConsulta += "Order by FOMUDEPA, FOMUMUNI, FOMUCLSE, FOMUTIIM, FOMUCONC "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtFOMUDEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtFOMUDEPA.Text = ""
        Me.txtFOMUMUNI.Text = ""
        Me.txtFOMUCLSE.Text = ""
        Me.txtFOMUVIGE.Text = ""
        Me.txtFOMUTIIM.Text = ""
        Me.txtFOMUCONC.Text = ""
        Me.txtFOMUFORM.Text = ""
        Me.txtFOMUDESC.Text = ""
        Me.txtFOMUESTA.Text = ""

        Me.chkFOMUIMPR.CheckState = CheckState.Indeterminate
        Me.chkFOMUACBO.CheckState = CheckState.Indeterminate
        Me.chkFOMUALPU.CheckState = CheckState.Indeterminate
        Me.chkFOMUTAAS.CheckState = CheckState.Indeterminate

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
            Dim inId_Reg As New frm_FORMMUNI(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtFOMUDEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtFOMUDEPA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtFOMUDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFOMUDEPA.KeyPress, txtFOMUMUNI.KeyPress, txtFOMUCLSE.KeyPress, txtFOMUVIGE.KeyPress, txtFOMUTIIM.KeyPress, txtFOMUESTA.KeyPress, chkFOMUIMPR.KeyPress, chkFOMUACBO.KeyPress, chkFOMUALPU.KeyPress, chkFOMUTAAS.KeyPress, txtFOMUCONC.KeyPress, txtFOMUFORM.KeyPress, txtFOMUDESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFOMUDEPA.GotFocus, txtFOMUMUNI.GotFocus, txtFOMUCLSE.GotFocus, txtFOMUVIGE.GotFocus, txtFOMUTIIM.GotFocus, txtFOMUESTA.GotFocus, txtFOMUCONC.GotFocus, txtFOMUFORM.GotFocus, txtFOMUDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFOMUIMPR.GotFocus, chkFOMUACBO.GotFocus, chkFOMUALPU.GotFocus, chkFOMUTAAS.GotFocus
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