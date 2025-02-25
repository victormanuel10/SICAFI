Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_PREDEXEN

    '================================
    '*** CONSULTA PREDIOS EXENTOS ***
    '=================================

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
            Dim stPREXDEPA As String = ""
            Dim stPREXMUNI As String = ""
            Dim stPREXCLSE As String = ""
            Dim stPREXNUFI As String = ""
            Dim stPREXVIIN As String = ""
            Dim stPREXVIFI As String = ""
            Dim stPREXTIIM As String = ""
            Dim stPREXCONC As String = ""
            Dim stPREXPOAP As String = ""
            Dim stPREXRESO As String = ""
            Dim stPREXFECH As String = ""
            Dim stPREXESTA As String = ""
            Dim stPREXOBSE As String = ""

            ' carga los campos
            If Trim(Me.txtPREXDEPA.Text) = "" Then
                stPREXDEPA = "%"
            Else
                stPREXDEPA = Trim(Me.txtPREXDEPA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPREXMUNI.Text) = "" Then
                stPREXMUNI = "%"
            Else
                stPREXMUNI = Trim(Me.txtPREXMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPREXCLSE.Text) = "" Then
                stPREXCLSE = "%"
            Else
                stPREXCLSE = Trim(Me.txtPREXCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPREXNUFI.Text) = "" Then
                stPREXNUFI = "%"
            Else
                stPREXNUFI = Trim(Me.txtPREXNUFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPREXVIIN.Text) = "" Then
                stPREXVIIN = "%"
            Else
                stPREXVIIN = Trim(Me.txtPREXVIIN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPREXVIFI.Text) = "" Then
                stPREXVIFI = "%"
            Else
                stPREXVIFI = Trim(Me.txtPREXVIFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPREXTIIM.Text) = "" Then
                stPREXTIIM = "%"
            Else
                stPREXTIIM = Trim(Me.txtPREXTIIM.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPREXCONC.Text) = "" Then
                stPREXCONC = "%"
            Else
                stPREXCONC = Trim(Me.txtPREXCONC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPREXPOAP.Text) = "" Then
                stPREXPOAP = "%"
            Else
                stPREXPOAP = Trim(Me.txtPREXPOAP.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPREXRESO.Text) = "" Then
                stPREXRESO = "%"
            Else
                stPREXRESO = Trim(Me.txtPREXRESO.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPREXFECH.Text) = "" Then
                stPREXFECH = "%"
            Else
                stPREXFECH = Trim(Me.txtPREXFECH.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPREXOBSE.Text) = "" Then
                stPREXOBSE = "%"
            Else
                stPREXOBSE = Trim(Me.txtPREXOBSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtPREXESTA.Text) = "" Then
                stPREXESTA = "%"
            Else
                stPREXESTA = Trim(Me.txtPREXESTA.Text)
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "PREXIDRE , "
            stConsulta += "PREXDEPA as 'Departamento', "
            stConsulta += "PREXMUNI as 'Municipio', "
            stConsulta += "PREXCLSE as 'Sector', "
            stConsulta += "PREXNUFI as 'Nro. de Ficha', "
            stConsulta += "PREXTIIM as 'Tipo impuesto', "
            stConsulta += "PREXCONC as 'Concepto', "
            stConsulta += "PREXVIIN as 'Vigencia inicial', "
            stConsulta += "PREXVIFI as 'Vigencia final', "
            stConsulta += "PREXPOAP as '(%) Aplicado', "
            stConsulta += "PREXRESO as 'Resolución', "
            stConsulta += "PREXFECH as 'Fecha resolución', "
            stConsulta += "PREXESTA as 'Estado', "
            stConsulta += "PREXOBSE as 'Observación' "
            stConsulta += "From PREDEXEN "
            stConsulta += "Where "
            stConsulta += "PREXDEPA like '" & stPREXDEPA & "' and "
            stConsulta += "PREXMUNI like '" & stPREXMUNI & "' and "
            stConsulta += "PREXCLSE like '" & stPREXCLSE & "' and "
            stConsulta += "PREXNUFI like '" & stPREXNUFI & "' and "
            stConsulta += "PREXTIIM like '" & stPREXTIIM & "' and "
            stConsulta += "PREXCONC like '" & stPREXCONC & "' and "
            stConsulta += "PREXVIIN like '" & stPREXVIIN & "' and "
            stConsulta += "PREXVIFI like '" & stPREXVIFI & "' and "
            stConsulta += "PREXPOAP like '" & stPREXPOAP & "' and "
            stConsulta += "PREXRESO like '" & stPREXRESO & "' and "
            stConsulta += "PREXFECH like '" & stPREXFECH & "' and "
            stConsulta += "PREXESTA like '" & stPREXESTA & "' and "
            stConsulta += "PREXOBSE like '" & stPREXOBSE & "' "
            stConsulta += "Order by PREXDEPA, PREXMUNI, PREXCLSE, PREXTIIM, PREXCONC "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtPREXDEPA.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtPREXDEPA.Text = ""
        Me.txtPREXMUNI.Text = ""
        Me.txtPREXCLSE.Text = ""
        Me.txtPREXNUFI.Text = ""
        Me.txtPREXVIIN.Text = ""
        Me.txtPREXVIFI.Text = ""
        Me.txtPREXTIIM.Text = ""
        Me.txtPREXCONC.Text = ""
        Me.txtPREXPOAP.Text = ""
        Me.txtPREXRESO.Text = ""
        Me.txtPREXFECH.Text = ""
        Me.txtPREXESTA.Text = ""
        Me.txtPREXOBSE.Text = ""

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
            Dim inId_Reg As New frm_PREDEXEN(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtPREXDEPA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtPREXDEPA.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtPREXDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPREXDEPA.KeyPress, txtPREXMUNI.KeyPress, txtPREXCLSE.KeyPress, txtPREXVIIN.KeyPress, txtPREXTIIM.KeyPress, txtPREXESTA.KeyPress, txtPREXCONC.KeyPress, txtPREXPOAP.KeyPress, txtPREXRESO.KeyPress, txtPREXNUFI.KeyPress, txtPREXVIFI.KeyPress, txtPREXFECH.KeyPress, txtPREXOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPREXDEPA.GotFocus, txtPREXMUNI.GotFocus, txtPREXCLSE.GotFocus, txtPREXVIIN.GotFocus, txtPREXTIIM.GotFocus, txtPREXESTA.GotFocus, txtPREXCONC.GotFocus, txtPREXPOAP.GotFocus, txtPREXRESO.GotFocus, txtPREXNUFI.GotFocus, txtPREXVIFI.GotFocus, txtPREXFECH.GotFocus, txtPREXOBSE.GotFocus
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