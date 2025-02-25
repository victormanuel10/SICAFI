Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_PEPELIQU

    '=================================================
    '*** CONSULTA PERIODO PERMITIDO DE LIQUIDACIÓN ***
    '=================================================

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
            Dim stPPLIDEPA As String = ""
            Dim stPPLIMUNI As String = ""
            Dim stPPLICLSE As String = ""
            Dim stPPLIVIGE As String = ""
            Dim stPPLITIIM As String = ""
            Dim stPPLICONC As String = ""
            Dim stPPLIFORM As String = ""
            Dim stPPLIDESC As String = ""
            Dim stPPLIESTA As String = ""

            Dim stPPLIHIAV As String = ""
            Dim stPPLIHILI As String = ""
            Dim stPPLIAFSI As String = ""

            ' carga los campos
            If Trim(Me.txtPPLIDEPA.Text) = "" Then
                stPPLIDEPA = "%"
            Else
                stPPLIDEPA = Trim(Me.txtPPLIDEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPPLIMUNI.Text) = "" Then
                stPPLIMUNI = "%"
            Else
                stPPLIMUNI = Trim(Me.txtPPLIMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPPLICLSE.Text) = "" Then
                stPPLICLSE = "%"
            Else
                stPPLICLSE = Trim(Me.txtPPLICLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPPLIVIGE.Text) = "" Then
                stPPLIVIGE = "%"
            Else
                stPPLIVIGE = Trim(Me.txtPPLIVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPPLITIIM.Text) = "" Then
                stPPLITIIM = "%"
            Else
                stPPLITIIM = Trim(Me.txtPPLITIIM.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPPLICONC.Text) = "" Then
                stPPLICONC = "%"
            Else
                stPPLICONC = Trim(Me.txtPPLICONC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPPLIDESC.Text) = "" Then
                stPPLIDESC = "%"
            Else
                stPPLIDESC = Trim(Me.txtPPLIDESC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPPLIESTA.Text) = "" Then
                stPPLIESTA = "%"
            Else
                stPPLIESTA = Trim(Me.txtPPLIESTA.Text)
            End If

            ' carga los campos
            If Me.chkPPLIHIAV.CheckState = CheckState.Indeterminate Then
                stPPLIHIAV = "%"
            ElseIf Me.chkPPLIHIAV.Checked = False Then
                stPPLIHIAV = "0"
            ElseIf Me.chkPPLIHIAV.Checked = True Then
                stPPLIHIAV = "1"
            End If

            ' carga los campos
            If Me.chkPPLIAFSI.CheckState = CheckState.Indeterminate Then
                stPPLIAFSI = "%"
            ElseIf Me.chkPPLIAFSI.Checked = False Then
                stPPLIAFSI = "0"
            ElseIf Me.chkPPLIAFSI.Checked = True Then
                stPPLIAFSI = "1"
            End If

            ' carga los campos
            If Me.chkPPLIHILI.CheckState = CheckState.Indeterminate Then
                stPPLIHILI = "%"
            ElseIf Me.chkPPLIHILI.Checked = False Then
                stPPLIHILI = "0"
            ElseIf Me.chkPPLIHILI.Checked = True Then
                stPPLIHILI = "1"
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "PPLIIDRE , "
            stConsulta += "PPLIDEPA as 'Departamento', "
            stConsulta += "PPLIMUNI as 'Municipio', "
            stConsulta += "PPLICLSE as 'Sector', "
            stConsulta += "PPLIVIGE as 'Vigencia', "
            stConsulta += "PPLITIIM as 'Tipo impuesto', "
            stConsulta += "PPLICONC as 'Concepto', "
            stConsulta += "PPLIDESC as 'Descripción', "
            stConsulta += "PPLIHIAV as 'Hist. avalúo', "
            stConsulta += "PPLIHILI as 'Hist. liquidación', "
            stConsulta += "PPLIAFSI as 'Aforo de impuesto', "
            stConsulta += "PPLIESTA as 'Estado' "
            stConsulta += "From PEPELIQU "
            stConsulta += "Where "
            stConsulta += "PPLIDEPA like '" & stPPLIDEPA & "' and "
            stConsulta += "PPLIMUNI like '" & stPPLIMUNI & "' and "
            stConsulta += "PPLICLSE like '" & stPPLICLSE & "' and "
            stConsulta += "PPLIVIGE like '" & stPPLIVIGE & "' and "
            stConsulta += "PPLITIIM like '" & stPPLITIIM & "' and "
            stConsulta += "PPLICONC like '" & stPPLICONC & "' and "
            stConsulta += "PPLIDESC like '" & stPPLIDESC & "' and "
            stConsulta += "PPLIHIAV like '" & stPPLIHIAV & "' and "
            stConsulta += "PPLIHILI like '" & stPPLIHILI & "' and "
            stConsulta += "PPLIAFSI like '" & stPPLIAFSI & "' and "
            stConsulta += "PPLIESTA like '" & stPPLIESTA & "' "
            stConsulta += "Order by PPLIDEPA, PPLIMUNI, PPLICLSE, PPLITIIM, PPLICONC "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtPPLIDEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtPPLIDEPA.Text = ""
        Me.txtPPLIMUNI.Text = ""
        Me.txtPPLICLSE.Text = ""
        Me.txtPPLIVIGE.Text = ""
        Me.txtPPLITIIM.Text = ""
        Me.txtPPLICONC.Text = ""
        Me.txtPPLIDESC.Text = ""
        Me.txtPPLIESTA.Text = ""

        Me.chkPPLIHIAV.CheckState = CheckState.Indeterminate
        Me.chkPPLIAFSI.CheckState = CheckState.Indeterminate
        Me.chkPPLIHILI.CheckState = CheckState.Indeterminate
       
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
            Me.txtPPLIDEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtPPLIDEPA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtPPLIDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPPLIDEPA.KeyPress, txtPPLIMUNI.KeyPress, txtPPLICLSE.KeyPress, txtPPLIVIGE.KeyPress, txtPPLITIIM.KeyPress, txtPPLIESTA.KeyPress, chkPPLIHIAV.KeyPress, chkPPLIAFSI.KeyPress, chkPPLIHILI.KeyPress, txtPPLICONC.KeyPress, txtPPLIDESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPPLIDEPA.GotFocus, txtPPLIMUNI.GotFocus, txtPPLICLSE.GotFocus, txtPPLIVIGE.GotFocus, txtPPLITIIM.GotFocus, txtPPLIESTA.GotFocus, txtPPLICONC.GotFocus, txtPPLIDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPPLIHIAV.GotFocus, chkPPLIAFSI.GotFocus, chkPPLIHILI.GotFocus
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