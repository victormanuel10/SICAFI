Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_RECLAMOS

    '================================
    '*** CONSULTA RECTIFICACIONES ***
    '================================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False
    Dim inID_REGISTRO As Integer

    Dim dt As DataTable

#End Region

#Region "CONSTRUCTOR"

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal inInRegistro As Integer)
        inID_REGISTRO = inInRegistro

        InitializeComponent()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_Reconsultar()

        Try

            ' crea la variable de los campos
            Dim stRECLMUNI As String = ""
            Dim stRECLCORR As String = ""
            Dim stRECLBARR As String = ""
            Dim stRECLMANZ As String = ""
            Dim stRECLPRED As String = ""
            Dim stRECLEDIF As String = ""
            Dim stRECLUNPR As String = ""
            Dim stRECLCLSE As String = ""
            Dim stRECLVIGE As String = ""
            Dim stRECLNUDO As String = ""
            Dim stRECLNOMB As String = ""
            Dim stRECLPRAP As String = ""
            Dim stRECLSEAP As String = ""
            Dim stRECLMAIN As String = ""
            Dim stRECLRADE As String = ""
            Dim stRECLFEDE As String = ""
            Dim stRECLRAMU As String = ""
            Dim stRECLFEMU As String = ""
            Dim stRECLRAED As String = ""
            Dim stRECLFEED As String = ""
            Dim stRECLRADM As String = ""
            Dim stRECLFEDM As String = ""
            Dim stRECLFELC As String = ""
            Dim stRECLTITR As String = ""
            Dim stRECLESTA As String = ""
            Dim stRECLOBSE As String = ""
            Dim stRECLSECU As String = ""

            Dim stRECLMIAN As String = ""
         

            ' carga los campos
            If Trim(Me.txtRECLMIAN.Text) = "" Then
                stRECLMIAN = "%"
            Else
                stRECLMIAN = Trim(Me.txtRECLMIAN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLSECU.Text) = "" Then
                stRECLSECU = "%"
            Else
                stRECLSECU = Trim(Me.txtRECLSECU.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLMUNI.Text) = "" Then
                stRECLMUNI = "%"
            Else
                stRECLMUNI = Trim(Me.txtRECLMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLCORR.Text) = "" Then
                stRECLCORR = "%"
            Else
                stRECLCORR = Trim(Me.txtRECLCORR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLBARR.Text) = "" Then
                stRECLBARR = "%"
            Else
                stRECLBARR = Trim(Me.txtRECLBARR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLMANZ.Text) = "" Then
                stRECLMANZ = "%"
            Else
                stRECLMANZ = Trim(Me.txtRECLMANZ.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLPRED.Text) = "" Then
                stRECLPRED = "%"
            Else
                stRECLPRED = Trim(Me.txtRECLPRED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLEDIF.Text) = "" Then
                stRECLEDIF = "%"
            Else
                stRECLEDIF = Trim(Me.txtRECLEDIF.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLUNPR.Text) = "" Then
                stRECLUNPR = "%"
            Else
                stRECLUNPR = Trim(Me.txtRECLUNPR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLCLSE.Text) = "" Then
                stRECLCLSE = "%"
            Else
                stRECLCLSE = Trim(Me.txtRECLCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLVIGE.Text) = "" Then
                stRECLVIGE = "%"
            Else
                stRECLVIGE = Trim(Me.txtRECLVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLNUDO.Text) = "" Then
                stRECLNUDO = "%"
            Else
                stRECLNUDO = Trim(Me.txtRECLNUDO.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLNOMB.Text) = "" Then
                stRECLNOMB = "%"
            Else
                stRECLNOMB = Trim(Me.txtRECLNOMB.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLPRAP.Text) = "" Then
                stRECLPRAP = "%"
            Else
                stRECLPRAP = Trim(Me.txtRECLPRAP.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLSEAP.Text) = "" Then
                stRECLSEAP = "%"
            Else
                stRECLSEAP = Trim(Me.txtRECLSEAP.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLMAIN.Text) = "" Then
                stRECLMAIN = "%"
            Else
                stRECLMAIN = Trim(Me.txtRECLMAIN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLRADE.Text) = "" Then
                stRECLRADE = "%"
            Else
                stRECLRADE = Trim(Me.txtRECLRADE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLFEDE.Text) = "" Then
                stRECLFEDE = "%"
            Else
                stRECLFEDE = Trim(Me.txtRECLFEDE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLRAMU.Text) = "" Then
                stRECLRAMU = "%"
            Else
                stRECLRAMU = Trim(Me.txtRECLRAMU.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLFEMU.Text) = "" Then
                stRECLFEMU = "%"
            Else
                stRECLFEMU = Trim(Me.txtRECLFEMU.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLRAED.Text) = "" Then
                stRECLRAED = "%"
            Else
                stRECLRAED = Trim(Me.txtRECLRAED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLFEED.Text) = "" Then
                stRECLFEED = "%"
            Else
                stRECLFEED = Trim(Me.txtRECLFEED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLRADM.Text) = "" Then
                stRECLRADM = "%"
            Else
                stRECLRADM = Trim(Me.txtRECLRADM.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLFEDM.Text) = "" Then
                stRECLFEDM = "%"
            Else
                stRECLFEDM = Trim(Me.txtRECLFEDM.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLFELC.Text) = "" Then
                stRECLFELC = "%"
            Else
                stRECLFELC = Trim(Me.txtRECLFELC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLTITR.Text) = "" Then
                stRECLTITR = "%"
            Else
                stRECLTITR = Trim(Me.txtRECLTITR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLESTA.Text) = "" Then
                stRECLESTA = "%"
            Else
                stRECLESTA = Trim(Me.txtRECLESTA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECLOBSE.Text) = "" Then
                stRECLOBSE = "%"
            Else
                stRECLOBSE = Trim(Me.txtRECLOBSE.Text)
            End If

            ' instancia un dt
            dt = New DataTable

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "RECLIDRE , "
            stConsulta += "RECLMUNI as 'Municipio', "
            stConsulta += "RECLCORR as 'Correg', "
            stConsulta += "RECLBARR as 'Barrio', "
            stConsulta += "RECLMANZ as 'Manzana', "
            stConsulta += "RECLPRED as 'Predio', "
            stConsulta += "RECLEDIF as 'Edicio', "
            stConsulta += "RECLUNPR as 'Unidad', "
            stConsulta += "RECLCLSE as 'Sector', "
            stConsulta += "RECLVIGE as 'Vigencia', "
            stConsulta += "RECLNUDO as 'Nro documento', "
            stConsulta += "RECLNOMB as 'Nombre(s)', "
            stConsulta += "RECLPRAP as 'Pri. apellido', "
            stConsulta += "RECLSEAP as 'Seg. apellido', "
            stConsulta += "RECLMAIN as 'Matricula', "
            stConsulta += "RECLMIAN as 'Matricula anexa', "
            stConsulta += "RECLRADE as 'Rad. depart.', "
            stConsulta += "RECLFEDE as 'Fecha depart.', "
            stConsulta += "RECLRAMU as 'Rad. municipio', "
            stConsulta += "RECLFEMU as 'Fecha munip.', "
            stConsulta += "RECLRAED as 'Rad. envio depa.', "
            stConsulta += "RECLFEED as 'Fecha envio depa.', "
            stConsulta += "RECLRADM as 'Rad. devolucion muni.', "
            stConsulta += "RECLFEDM as 'Fecha devol. muni.', "
            stConsulta += "RECLFELC as 'Fecha llegada muni.', "
            stConsulta += "RECLTITR as 'Tipo de tramite', "
            stConsulta += "TITRDESC as 'Descripción', "
            stConsulta += "RECLESTA as 'Estado', "
            stConsulta += "ESTADESC as 'Descripción', "
            'stConsulta += "RECLOBSE as 'Observación', "
            stConsulta += "RECLSECU as 'Expediente', "
            stConsulta += "RECLUSMC as 'Usuario', "
            stConsulta += "RECLFEIN as 'Fecha de ingreso' "

            'stConsulta += "From RECLAMOS, RECLACAD "
            stConsulta += "From RECLAMOS, mant_tipotram, estado  "
            stConsulta += "Where "

            stConsulta += "RECLTITR = TITRCODI and "
            stConsulta += "RECLESTA = ESTACODI and "

            stConsulta += "RECLMUNI like '" & stRECLMUNI & "' and "
            stConsulta += "RECLCORR like '" & stRECLCORR & "' and "
            stConsulta += "RECLBARR like '" & stRECLBARR & "' and "
            stConsulta += "RECLMANZ like '" & stRECLMANZ & "' and "
            stConsulta += "RECLPRED like '" & stRECLPRED & "' and "
            stConsulta += "RECLEDIF like '" & stRECLEDIF & "' and "
            stConsulta += "RECLUNPR like '" & stRECLUNPR & "' and "
            stConsulta += "RECLCLSE like '" & stRECLCLSE & "' and "
            stConsulta += "RECLVIGE like '" & stRECLVIGE & "' and "
            stConsulta += "RECLNUDO like '" & stRECLNUDO & "' and "
            stConsulta += "RECLNOMB like '" & stRECLNOMB & "' and "
            stConsulta += "RECLPRAP like '" & stRECLPRAP & "' and "
            stConsulta += "RECLSEAP like '" & stRECLSEAP & "' and "
            stConsulta += "RECLMAIN like '" & stRECLMAIN & "' and "
            stConsulta += "RECLRADE like '" & stRECLRADE & "' and "
            stConsulta += "RECLFEDE like '" & stRECLFEDE & "' and "
            stConsulta += "RECLRAMU like '" & stRECLRAMU & "' and "
            stConsulta += "RECLFEMU like '" & stRECLFEMU & "' and "
            stConsulta += "RECLRAED like '" & stRECLRAED & "' and "
            stConsulta += "RECLFEED like '" & stRECLFEED & "' and "
            stConsulta += "RECLRADM like '" & stRECLRADM & "' and "
            stConsulta += "RECLFEDM like '" & stRECLFEDM & "' and "
            stConsulta += "RECLFELC like '" & stRECLFELC & "' and "
            stConsulta += "RECLTITR like '" & stRECLTITR & "' and "
            stConsulta += "RECLESTA like '" & stRECLESTA & "' and "

            stConsulta += "RECLMIAN like '%" & stRECLMIAN & "%' and "

            stConsulta += "RECLOBSE like '" & stRECLOBSE & "' and "
            stConsulta += "RECLSECU like '" & stRECLSECU & "' "

            stConsulta += "Order by RECLMUNI, RECLCORR, RECLBARR, RECLMANZ, RECLPRED, RECLEDIF, RECLUNPR, RECLCLSE, RECLVIGE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtRECLMUNI.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtRECLMUNI.Text = ""
        Me.txtRECLCORR.Text = ""
        Me.txtRECLBARR.Text = ""
        Me.txtRECLMANZ.Text = ""
        Me.txtRECLPRED.Text = ""
        Me.txtRECLEDIF.Text = ""
        Me.txtRECLUNPR.Text = ""
        Me.txtRECLCLSE.Text = ""
        Me.txtRECLVIGE.Text = ""
        Me.txtRECLNUDO.Text = ""
        Me.txtRECLNOMB.Text = ""
        Me.txtRECLPRAP.Text = ""
        Me.txtRECLSEAP.Text = ""
        Me.txtRECLMAIN.Text = ""
        Me.txtRECLRADE.Text = ""
        Me.txtRECLFEDE.Text = ""
        Me.txtRECLRAMU.Text = ""
        Me.txtRECLFEMU.Text = ""
        Me.txtRECLRAED.Text = ""
        Me.txtRECLFEED.Text = ""
        Me.txtRECLRADM.Text = ""
        Me.txtRECLFEDM.Text = ""
        Me.txtRECLFELC.Text = ""
        Me.txtRECLTITR.Text = ""
        Me.txtRECLESTA.Text = ""
        Me.txtRECLOBSE.Text = ""
        Me.txtRECLMIAN.Text = ""
        Me.txtRECLMIAN.Text = ""
        Me.txtRECLSECU.Text = ""

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
            Dim inId_Reg As New frm_RECLAMOS(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtRECLMUNI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtRECLMUNI.Focus()
    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        Try
            If Me.dgvCONSULTA.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvCONSULTA.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Dim inNroIdRe As New frm_RECLAMOS(inID_REGISTRO)
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()

    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_consultar_TRABCAMP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.txtRECLMUNI.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRECLMUNI.KeyPress, txtRECLCORR.KeyPress, txtRECLBARR.KeyPress, txtRECLMANZ.KeyPress, txtRECLPRED.KeyPress, txtRECLEDIF.KeyPress, txtRECLUNPR.KeyPress, txtRECLCLSE.KeyPress, txtRECLVIGE.KeyPress, txtRECLNUDO.KeyPress, txtRECLNOMB.KeyPress, txtRECLPRAP.KeyPress, txtRECLSEAP.KeyPress, txtRECLMAIN.KeyPress, txtRECLRADE.KeyPress, txtRECLFEDE.KeyPress, txtRECLFEMU.KeyPress, txtRECLRAMU.KeyPress, txtRECLRAED.KeyPress, txtRECLFEED.KeyPress, txtRECLRADM.KeyPress, txtRECLFEDM.KeyPress, txtRECLFELC.KeyPress, txtRECLTITR.KeyPress, txtRECLESTA.KeyPress, txtRECLOBSE.KeyPress, txtRECLMIAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECLMUNI.GotFocus, txtRECLCORR.GotFocus, txtRECLBARR.GotFocus, txtRECLMANZ.GotFocus, txtRECLPRED.GotFocus, txtRECLEDIF.GotFocus, txtRECLUNPR.GotFocus, txtRECLCLSE.GotFocus, txtRECLVIGE.GotFocus, txtRECLNUDO.GotFocus, txtRECLNOMB.GotFocus, txtRECLPRAP.GotFocus, txtRECLSEAP.GotFocus, txtRECLMAIN.GotFocus, txtRECLRADE.GotFocus, txtRECLFEDE.GotFocus, txtRECLFEMU.GotFocus, txtRECLRAMU.GotFocus, txtRECLRAED.GotFocus, txtRECLFEED.GotFocus, txtRECLRADM.GotFocus, txtRECLFEDM.GotFocus, txtRECLFELC.GotFocus, txtRECLTITR.GotFocus, txtRECLESTA.GotFocus, txtRECLOBSE.GotFocus, txtRECLMIAN.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdSalir.GotFocus, cmdConsultar.GotFocus, cmdLimpiar.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtRECLMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECLMUNI.Validated
        If Me.txtRECLMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRECLMUNI.Text) = True Then
            Me.txtRECLMUNI.Text = fun_Formato_Mascara_3_String(Me.txtRECLMUNI.Text)
        End If
    End Sub
    Private Sub txtRECLCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECLCORR.Validated
        If Me.txtRECLCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRECLCORR.Text) = True Then
            Me.txtRECLCORR.Text = fun_Formato_Mascara_2_String(Me.txtRECLCORR.Text)
        End If
    End Sub
    Private Sub txtRECLBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECLBARR.Validated
        If Me.txtRECLBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRECLBARR.Text) = True Then
            Me.txtRECLBARR.Text = fun_Formato_Mascara_3_String(Me.txtRECLBARR.Text)
        End If
    End Sub
    Private Sub txtRECLMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECLMANZ.Validated
        If Me.txtRECLMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRECLMANZ.Text) = True Then
            Me.txtRECLMANZ.Text = fun_Formato_Mascara_3_String(Me.txtRECLMANZ.Text)
        End If
    End Sub
    Private Sub txtRECLPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECLPRED.Validated
        If Me.txtRECLPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRECLPRED.Text) = True Then
            Me.txtRECLPRED.Text = fun_Formato_Mascara_5_String(Me.txtRECLPRED.Text)
        End If
    End Sub
    Private Sub txtRECLEDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECLEDIF.Validated
        If Me.txtRECLEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRECLEDIF.Text) = True Then
            Me.txtRECLEDIF.Text = fun_Formato_Mascara_3_String(Me.txtRECLEDIF.Text)
        End If
    End Sub
    Private Sub txtRECLUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECLUNPR.Validated
        If Me.txtRECLUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRECLUNPR.Text) = True Then
            Me.txtRECLUNPR.Text = fun_Formato_Mascara_5_String(Me.txtRECLUNPR.Text)
        End If
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