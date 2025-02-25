Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_REVIAVAL

    '===================================
    '*** CONSULTA REVISION DE AVALUO ***
    '===================================

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
            Dim stREAVMUNI As String = ""
            Dim stREAVCORR As String = ""
            Dim stREAVBARR As String = ""
            Dim stREAVMANZ As String = ""
            Dim stREAVPRED As String = ""
            Dim stREAVEDIF As String = ""
            Dim stREAVUNPR As String = ""
            Dim stREAVCLSE As String = ""
            Dim stREAVVIGE As String = ""
            Dim stREAVNUDO As String = ""
            Dim stREAVNOMB As String = ""
            Dim stREAVPRAP As String = ""
            Dim stREAVSEAP As String = ""
            Dim stREAVMAIN As String = ""
            Dim stREAVRADE As String = ""
            Dim stREAVFEDE As String = ""
            Dim stREAVRAMU As String = ""
            Dim stREAVFEMU As String = ""
            Dim stREAVRAED As String = ""
            Dim stREAVFEED As String = ""
            Dim stREAVRADM As String = ""
            Dim stREAVFEDM As String = ""
            Dim stREAVFELC As String = ""
            Dim stREAVTITR As String = ""
            Dim stREAVESTA As String = ""
            Dim stREAVOBSE As String = ""
            Dim stREAVSECU As String = ""

            Dim stREAVMIAN As String = ""


            ' carga los campos
            If Trim(Me.txtREAVMIAN.Text) = "" Then
                stREAVMIAN = "%"
            Else
                stREAVMIAN = Trim(Me.txtREAVMIAN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVSECU.Text) = "" Then
                stREAVSECU = "%"
            Else
                stREAVSECU = Trim(Me.txtREAVSECU.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVMUNI.Text) = "" Then
                stREAVMUNI = "%"
            Else
                stREAVMUNI = Trim(Me.txtREAVMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVCORR.Text) = "" Then
                stREAVCORR = "%"
            Else
                stREAVCORR = Trim(Me.txtREAVCORR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVBARR.Text) = "" Then
                stREAVBARR = "%"
            Else
                stREAVBARR = Trim(Me.txtREAVBARR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVMANZ.Text) = "" Then
                stREAVMANZ = "%"
            Else
                stREAVMANZ = Trim(Me.txtREAVMANZ.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVPRED.Text) = "" Then
                stREAVPRED = "%"
            Else
                stREAVPRED = Trim(Me.txtREAVPRED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVEDIF.Text) = "" Then
                stREAVEDIF = "%"
            Else
                stREAVEDIF = Trim(Me.txtREAVEDIF.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVUNPR.Text) = "" Then
                stREAVUNPR = "%"
            Else
                stREAVUNPR = Trim(Me.txtREAVUNPR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVCLSE.Text) = "" Then
                stREAVCLSE = "%"
            Else
                stREAVCLSE = Trim(Me.txtREAVCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVVIGE.Text) = "" Then
                stREAVVIGE = "%"
            Else
                stREAVVIGE = Trim(Me.txtREAVVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVNUDO.Text) = "" Then
                stREAVNUDO = "%"
            Else
                stREAVNUDO = Trim(Me.txtREAVNUDO.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVNOMB.Text) = "" Then
                stREAVNOMB = "%"
            Else
                stREAVNOMB = Trim(Me.txtREAVNOMB.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVPRAP.Text) = "" Then
                stREAVPRAP = "%"
            Else
                stREAVPRAP = Trim(Me.txtREAVPRAP.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVSEAP.Text) = "" Then
                stREAVSEAP = "%"
            Else
                stREAVSEAP = Trim(Me.txtREAVSEAP.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVMAIN.Text) = "" Then
                stREAVMAIN = "%"
            Else
                stREAVMAIN = Trim(Me.txtREAVMAIN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVRADE.Text) = "" Then
                stREAVRADE = "%"
            Else
                stREAVRADE = Trim(Me.txtREAVRADE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVFEDE.Text) = "" Then
                stREAVFEDE = "%"
            Else
                stREAVFEDE = Trim(Me.txtREAVFEDE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVRAMU.Text) = "" Then
                stREAVRAMU = "%"
            Else
                stREAVRAMU = Trim(Me.txtREAVRAMU.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVFEMU.Text) = "" Then
                stREAVFEMU = "%"
            Else
                stREAVFEMU = Trim(Me.txtREAVFEMU.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVRAED.Text) = "" Then
                stREAVRAED = "%"
            Else
                stREAVRAED = Trim(Me.txtREAVRAED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVFEED.Text) = "" Then
                stREAVFEED = "%"
            Else
                stREAVFEED = Trim(Me.txtREAVFEED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVRADM.Text) = "" Then
                stREAVRADM = "%"
            Else
                stREAVRADM = Trim(Me.txtREAVRADM.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVFEDM.Text) = "" Then
                stREAVFEDM = "%"
            Else
                stREAVFEDM = Trim(Me.txtREAVFEDM.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVFELC.Text) = "" Then
                stREAVFELC = "%"
            Else
                stREAVFELC = Trim(Me.txtREAVFELC.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVTITR.Text) = "" Then
                stREAVTITR = "%"
            Else
                stREAVTITR = Trim(Me.txtREAVTITR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVESTA.Text) = "" Then
                stREAVESTA = "%"
            Else
                stREAVESTA = Trim(Me.txtREAVESTA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtREAVOBSE.Text) = "" Then
                stREAVOBSE = "%"
            Else
                stREAVOBSE = Trim(Me.txtREAVOBSE.Text)
            End If

            ' instancia un dt
            dt = New DataTable

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "REAVIDRE , "
            stConsulta += "REAVMUNI as 'Municipio', "
            stConsulta += "REAVCORR as 'Correg', "
            stConsulta += "REAVBARR as 'Barrio', "
            stConsulta += "REAVMANZ as 'Manzana', "
            stConsulta += "REAVPRED as 'Predio', "
            stConsulta += "REAVEDIF as 'Edicio', "
            stConsulta += "REAVUNPR as 'Unidad', "
            stConsulta += "REAVCLSE as 'Sector', "
            stConsulta += "REAVVIGE as 'Vigencia', "
            stConsulta += "REAVNUDO as 'Nro documento', "
            stConsulta += "REAVNOMB as 'Nombre(s)', "
            stConsulta += "REAVPRAP as 'Pri. apellido', "
            stConsulta += "REAVSEAP as 'Seg. apellido', "
            stConsulta += "REAVMAIN as 'Matricula', "
            stConsulta += "REAVMIAN as 'Matricula anexa', "
            stConsulta += "REAVRADE as 'Rad. depart.', "
            stConsulta += "REAVFEDE as 'Fecha depart.', "
            stConsulta += "REAVRAMU as 'Rad. municipio', "
            stConsulta += "REAVFEMU as 'Fecha munip.', "
            stConsulta += "REAVRAED as 'Rad. envio depa.', "
            stConsulta += "REAVFEED as 'Fecha envio depa.', "
            stConsulta += "REAVRADM as 'Rad. devolucion muni.', "
            stConsulta += "REAVFEDM as 'Fecha devol. muni.', "
            stConsulta += "REAVFELC as 'Fecha llegada muni.', "
            stConsulta += "REAVTITR as 'Tipo de tramite', "
            stConsulta += "TITRDESC as 'Descripción', "
            stConsulta += "REAVESTA as 'Estado', "
            stConsulta += "ESTADESC as 'Descripción', "
            stConsulta += "REAVOBSE as 'Observación', "
            stConsulta += "REAVSECU as 'Expediente' "

            stConsulta += "From REVIAVAL, MANT_TIPOTRAM, ESTADO  "
            stConsulta += "Where "

            stConsulta += "REAVTITR = TITRCODI and "
            stConsulta += "REAVESTA = ESTACODI and "

            stConsulta += "REAVMUNI like '" & stREAVMUNI & "' and "
            stConsulta += "REAVCORR like '" & stREAVCORR & "' and "
            stConsulta += "REAVBARR like '" & stREAVBARR & "' and "
            stConsulta += "REAVMANZ like '" & stREAVMANZ & "' and "
            stConsulta += "REAVPRED like '" & stREAVPRED & "' and "
            stConsulta += "REAVEDIF like '" & stREAVEDIF & "' and "
            stConsulta += "REAVUNPR like '" & stREAVUNPR & "' and "
            stConsulta += "REAVCLSE like '" & stREAVCLSE & "' and "
            stConsulta += "REAVVIGE like '" & stREAVVIGE & "' and "
            stConsulta += "REAVNUDO like '" & stREAVNUDO & "' and "
            stConsulta += "REAVNOMB like '" & stREAVNOMB & "' and "
            stConsulta += "REAVPRAP like '" & stREAVPRAP & "' and "
            stConsulta += "REAVSEAP like '" & stREAVSEAP & "' and "
            stConsulta += "REAVMAIN like '" & stREAVMAIN & "' and "
            stConsulta += "REAVRADE like '" & stREAVRADE & "' and "
            stConsulta += "REAVFEDE like '" & stREAVFEDE & "' and "
            stConsulta += "REAVRAMU like '" & stREAVRAMU & "' and "
            stConsulta += "REAVFEMU like '" & stREAVFEMU & "' and "
            stConsulta += "REAVRAED like '" & stREAVRAED & "' and "
            stConsulta += "REAVFEED like '" & stREAVFEED & "' and "
            stConsulta += "REAVRADM like '" & stREAVRADM & "' and "
            stConsulta += "REAVFEDM like '" & stREAVFEDM & "' and "
            stConsulta += "REAVFELC like '" & stREAVFELC & "' and "
            stConsulta += "REAVTITR like '" & stREAVTITR & "' and "
            stConsulta += "REAVESTA like '" & stREAVESTA & "' and "

            stConsulta += "REAVMIAN like '%" & stREAVMIAN & "%' and "

            stConsulta += "REAVOBSE like '" & stREAVOBSE & "' and "
            stConsulta += "REAVSECU like '" & stREAVSECU & "' "

            stConsulta += "Order by REAVMUNI, REAVCORR, REAVBARR, REAVMANZ, REAVPRED, REAVEDIF, REAVUNPR, REAVCLSE, REAVVIGE "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtREAVMUNI.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtREAVMUNI.Text = ""
        Me.txtREAVCORR.Text = ""
        Me.txtREAVBARR.Text = ""
        Me.txtREAVMANZ.Text = ""
        Me.txtREAVPRED.Text = ""
        Me.txtREAVEDIF.Text = ""
        Me.txtREAVUNPR.Text = ""
        Me.txtREAVCLSE.Text = ""
        Me.txtREAVVIGE.Text = ""
        Me.txtREAVNUDO.Text = ""
        Me.txtREAVNOMB.Text = ""
        Me.txtREAVPRAP.Text = ""
        Me.txtREAVSEAP.Text = ""
        Me.txtREAVMAIN.Text = ""
        Me.txtREAVRADE.Text = ""
        Me.txtREAVFEDE.Text = ""
        Me.txtREAVRAMU.Text = ""
        Me.txtREAVFEMU.Text = ""
        Me.txtREAVRAED.Text = ""
        Me.txtREAVFEED.Text = ""
        Me.txtREAVRADM.Text = ""
        Me.txtREAVFEDM.Text = ""
        Me.txtREAVFELC.Text = ""
        Me.txtREAVTITR.Text = ""
        Me.txtREAVESTA.Text = ""
        Me.txtREAVOBSE.Text = ""
        Me.txtREAVMIAN.Text = ""
        Me.txtREAVMIAN.Text = ""
        Me.txtREAVSECU.Text = ""

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
            Dim inId_Reg As New frm_REVIAVAL(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtREAVMUNI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtREAVMUNI.Focus()
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
        Dim inNroIdRe As New frm_REVIAVAL(inID_REGISTRO)
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
        Me.txtREAVMUNI.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtREAVMUNI.KeyPress, txtREAVCORR.KeyPress, txtREAVBARR.KeyPress, txtREAVMANZ.KeyPress, txtREAVPRED.KeyPress, txtREAVEDIF.KeyPress, txtREAVUNPR.KeyPress, txtREAVCLSE.KeyPress, txtREAVVIGE.KeyPress, txtREAVNUDO.KeyPress, txtREAVNOMB.KeyPress, txtREAVPRAP.KeyPress, txtREAVSEAP.KeyPress, txtREAVMAIN.KeyPress, txtREAVRADE.KeyPress, txtREAVFEDE.KeyPress, txtREAVFEMU.KeyPress, txtREAVRAMU.KeyPress, txtREAVRAED.KeyPress, txtREAVFEED.KeyPress, txtREAVRADM.KeyPress, txtREAVFEDM.KeyPress, txtREAVFELC.KeyPress, txtREAVTITR.KeyPress, txtREAVESTA.KeyPress, txtREAVOBSE.KeyPress, txtREAVMIAN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREAVMUNI.GotFocus, txtREAVCORR.GotFocus, txtREAVBARR.GotFocus, txtREAVMANZ.GotFocus, txtREAVPRED.GotFocus, txtREAVEDIF.GotFocus, txtREAVUNPR.GotFocus, txtREAVCLSE.GotFocus, txtREAVVIGE.GotFocus, txtREAVNUDO.GotFocus, txtREAVNOMB.GotFocus, txtREAVPRAP.GotFocus, txtREAVSEAP.GotFocus, txtREAVMAIN.GotFocus, txtREAVRADE.GotFocus, txtREAVFEDE.GotFocus, txtREAVFEMU.GotFocus, txtREAVRAMU.GotFocus, txtREAVRAED.GotFocus, txtREAVFEED.GotFocus, txtREAVRADM.GotFocus, txtREAVFEDM.GotFocus, txtREAVFELC.GotFocus, txtREAVTITR.GotFocus, txtREAVESTA.GotFocus, txtREAVOBSE.GotFocus, txtREAVMIAN.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdSalir.GotFocus, cmdConsultar.GotFocus, cmdLimpiar.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtREAVMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREAVMUNI.Validated
        If Me.txtREAVMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREAVMUNI.Text) = True Then
            Me.txtREAVMUNI.Text = fun_Formato_Mascara_3_String(Me.txtREAVMUNI.Text)
        End If
    End Sub
    Private Sub txtREAVCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREAVCORR.Validated
        If Me.txtREAVCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREAVCORR.Text) = True Then
            Me.txtREAVCORR.Text = fun_Formato_Mascara_2_String(Me.txtREAVCORR.Text)
        End If
    End Sub
    Private Sub txtREAVBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREAVBARR.Validated
        If Me.txtREAVBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREAVBARR.Text) = True Then
            Me.txtREAVBARR.Text = fun_Formato_Mascara_3_String(Me.txtREAVBARR.Text)
        End If
    End Sub
    Private Sub txtREAVMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREAVMANZ.Validated
        If Me.txtREAVMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREAVMANZ.Text) = True Then
            Me.txtREAVMANZ.Text = fun_Formato_Mascara_3_String(Me.txtREAVMANZ.Text)
        End If
    End Sub
    Private Sub txtREAVPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREAVPRED.Validated
        If Me.txtREAVPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREAVPRED.Text) = True Then
            Me.txtREAVPRED.Text = fun_Formato_Mascara_5_String(Me.txtREAVPRED.Text)
        End If
    End Sub
    Private Sub txtREAVEDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREAVEDIF.Validated
        If Me.txtREAVEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREAVEDIF.Text) = True Then
            Me.txtREAVEDIF.Text = fun_Formato_Mascara_3_String(Me.txtREAVEDIF.Text)
        End If
    End Sub
    Private Sub txtREAVUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtREAVUNPR.Validated
        If Me.txtREAVUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtREAVUNPR.Text) = True Then
            Me.txtREAVUNPR.Text = fun_Formato_Mascara_5_String(Me.txtREAVUNPR.Text)
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