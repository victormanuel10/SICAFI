Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_POPELIQU

    '====================================================
    '*** CONSULTA PORCENTAJE PERMITIDO DE LIQUIDACION ***
    '====================================================

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
            Dim stPPLIVIAP As String = ""
            Dim stPPLIVIIN As String = ""
            Dim stPPLIVIFI As String = ""
            Dim stPPLITIIM As String = ""
            Dim stPPLICONC As String = ""
            Dim stPPLIPOAP As String = ""
            Dim stPPLIRESO As String = ""
            Dim stPPLIFECH As String = ""
            Dim stPPLIESTA As String = ""
            Dim stPPLIOBSE As String = ""

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
            If Trim(Me.txtPPLIVIAP.Text) = "" Then
                stPPLIVIAP = "%"
            Else
                stPPLIVIAP = Trim(Me.txtPPLIVIAP.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPPLIVIIN.Text) = "" Then
                stPPLIVIIN = "%"
            Else
                stPPLIVIIN = Trim(Me.txtPPLIVIIN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPPLIVIFI.Text) = "" Then
                stPPLIVIFI = "%"
            Else
                stPPLIVIFI = Trim(Me.txtPPLIVIFI.Text)
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
            If Trim(Me.txtPPLIPOAP.Text) = "" Then
                stPPLIPOAP = "%"
            Else
                stPPLIPOAP = Trim(Me.txtPPLIPOAP.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPPLIRESO.Text) = "" Then
                stPPLIRESO = "%"
            Else
                stPPLIRESO = Trim(Me.txtPPLIRESO.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPPLIFECH.Text) = "" Then
                stPPLIFECH = "%"
            Else
                stPPLIFECH = Trim(Me.txtPPLIFECH.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPPLIOBSE.Text) = "" Then
                stPPLIOBSE = "%"
            Else
                stPPLIOBSE = Trim(Me.txtPPLIOBSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPPLIESTA.Text) = "" Then
                stPPLIESTA = "%"
            Else
                stPPLIESTA = Trim(Me.txtPPLIESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "PPLIIDRE , "
            stConsulta += "PPLIDEPA as 'Departamento', "
            stConsulta += "PPLIMUNI as 'Municipio', "
            stConsulta += "PPLICLSE as 'Sector', "
            stConsulta += "PPLIVIAP as 'Vigencia aplicada', "
            stConsulta += "PPLITIIM as 'Tipo impuesto', "
            stConsulta += "PPLICONC as 'Concepto', "
            stConsulta += "PPLIVIIN as 'Vigencia inicial', "
            stConsulta += "PPLIVIFI as 'Vigencia final', "
            stConsulta += "PPLIPOAP as '(%) Aplicado', "
            stConsulta += "PPLIRESO as 'Resolución', "
            stConsulta += "PPLIFECH as 'Fecha resolución', "
            stConsulta += "PPLIESTA as 'Estado', "
            stConsulta += "PPLIOBSE as 'Observación' "
            stConsulta += "From POPELIQU "
            stConsulta += "Where "
            stConsulta += "PPLIDEPA like '" & stPPLIDEPA & "' and "
            stConsulta += "PPLIMUNI like '" & stPPLIMUNI & "' and "
            stConsulta += "PPLICLSE like '" & stPPLICLSE & "' and "
            stConsulta += "PPLIVIAP like '" & stPPLIVIAP & "' and "
            stConsulta += "PPLITIIM like '" & stPPLITIIM & "' and "
            stConsulta += "PPLICONC like '" & stPPLICONC & "' and "
            stConsulta += "PPLIVIIN like '" & stPPLIVIIN & "' and "
            stConsulta += "PPLIVIFI like '" & stPPLIVIFI & "' and "
            stConsulta += "PPLIPOAP like '" & stPPLIPOAP & "' and "
            stConsulta += "PPLIRESO like '" & stPPLIRESO & "' and "
            stConsulta += "PPLIFECH like '" & stPPLIFECH & "' and "
            stConsulta += "PPLIESTA like '" & stPPLIESTA & "' and "
            stConsulta += "PPLIOBSE like '" & stPPLIOBSE & "' "
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
        Me.txtPPLIVIAP.Text = ""
        Me.txtPPLIVIIN.Text = ""
        Me.txtPPLIVIFI.Text = ""
        Me.txtPPLITIIM.Text = ""
        Me.txtPPLICONC.Text = ""
        Me.txtPPLIPOAP.Text = ""
        Me.txtPPLIRESO.Text = ""
        Me.txtPPLIFECH.Text = ""
        Me.txtPPLIESTA.Text = ""
        Me.txtPPLIOBSE.Text = ""

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
            Dim inId_Reg As New frm_POPELIQU(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
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

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPPLIDEPA.KeyPress, txtPPLIMUNI.KeyPress, txtPPLICLSE.KeyPress, txtPPLIVIIN.KeyPress, txtPPLITIIM.KeyPress, txtPPLIESTA.KeyPress, txtPPLICONC.KeyPress, txtPPLIPOAP.KeyPress, txtPPLIRESO.KeyPress, txtPPLIVIAP.KeyPress, txtPPLIVIFI.KeyPress, txtPPLIFECH.KeyPress, txtPPLIOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPPLIDEPA.GotFocus, txtPPLIMUNI.GotFocus, txtPPLICLSE.GotFocus, txtPPLIVIIN.GotFocus, txtPPLITIIM.GotFocus, txtPPLIESTA.GotFocus, txtPPLICONC.GotFocus, txtPPLIPOAP.GotFocus, txtPPLIRESO.GotFocus, txtPPLIVIAP.GotFocus, txtPPLIVIFI.GotFocus, txtPPLIFECH.GotFocus, txtPPLIOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdLimpiar.GotFocus, cmdConsultar.GotFocus, cmdSalir.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
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