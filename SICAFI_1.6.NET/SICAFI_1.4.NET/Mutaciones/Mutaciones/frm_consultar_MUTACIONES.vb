Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_MUTACIONES

    '===========================
    '*** CONSULTA MUTACIONES ***
    '===========================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False
    Dim stORDERBY As String = ""
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
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de consulta
            Dim stConsulta As String = ""

            ' crea la variable de los campos
            Dim stMUTANUFI As String = ""
            Dim stMUTAMAIN As String = ""
            Dim stMUTAMUNI As String = ""
            Dim stMUTACORR As String = ""
            Dim stMUTABARR As String = ""
            Dim stMUTAMANZ As String = ""
            Dim stMUTAPRED As String = ""
            Dim stMUTAEDIF As String = ""
            Dim stMUTAUNPR As String = ""
            Dim stMUTACLSE As String = ""
            Dim stMUTAVIGE As String = ""
            Dim stMUTACAAC As String = ""
            Dim stMUTAFEES As String = ""
            Dim stMUTAESCR As String = ""
            Dim stMUTAFERA As String = ""
            Dim stMUTANURA As String = ""
            Dim stMUTANOTA As String = ""
            Dim stMUTAPRNU As String = ""
            Dim stMUTAESTA As String = ""
            Dim stMUTAOBSE As String = ""
            Dim stMUTAFEIN As String = ""
            Dim stMUTADESC As String = ""

            ' carga los campos
            If Trim(Me.txtMUTANUFI.Text) = "" Then
                stMUTANUFI = "%"
            Else
                stMUTANUFI = Trim(Me.txtMUTANUFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMUTAMAIN.Text) = "" Then
                stMUTAMAIN = "%"
            Else
                stMUTAMAIN = Trim(Me.txtMUTAMAIN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMUTAMUNI.Text) = "" Then
                stMUTAMUNI = "%"
            Else
                stMUTAMUNI = Trim(Me.txtMUTAMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMUTACORR.Text) = "" Then
                stMUTACORR = "%"
            Else
                stMUTACORR = Trim(Me.txtMUTACORR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMUTABARR.Text) = "" Then
                stMUTABARR = "%"
            Else
                stMUTABARR = Trim(Me.txtMUTABARR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMUTAMANZ.Text) = "" Then
                stMUTAMANZ = "%"
            Else
                stMUTAMANZ = Trim(Me.txtMUTAMANZ.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMUTAPRED.Text) = "" Then
                stMUTAPRED = "%"
            Else
                stMUTAPRED = Trim(Me.txtMUTAPRED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMUTAEDIF.Text) = "" Then
                stMUTAEDIF = "%"
            Else
                stMUTAEDIF = Trim(Me.txtMUTAEDIF.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMUTAUNPR.Text) = "" Then
                stMUTAUNPR = "%"
            Else
                stMUTAUNPR = Trim(Me.txtMUTAUNPR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMUTACLSE.Text) = "" Then
                stMUTACLSE = "%"
            Else
                stMUTACLSE = Trim(Me.txtMUTACLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMUTAVIGE.Text) = "" Then
                stMUTAVIGE = "%"
            Else
                stMUTAVIGE = Trim(Me.txtMUTAVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMUTAFEES.Text) = "" Then
                stMUTAFEES = "%"
            Else
                stMUTAFEES = Trim(Me.txtMUTAFEES.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMUTAESCR.Text) = "" Then
                stMUTAESCR = "%"
            Else
                stMUTAESCR = Trim(Me.txtMUTAESCR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMUTAFERA.Text) = "" Then
                stMUTAFERA = "%"
            Else
                stMUTAFERA = Trim(Me.txtMUTAFERA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMUTANURA.Text) = "" Then
                stMUTANURA = "%"
            Else
                stMUTANURA = Trim(Me.txtMUTANURA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMUTAESTA.Text) = "" Then
                stMUTAESTA = "%"
            Else
                stMUTAESTA = Trim(Me.txtMUTAESTA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTRCAOBSE.Text) = "" Then
                stMUTAOBSE = "%"
            Else
                stMUTAOBSE = Trim(Me.txtTRCAOBSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtMUTAFEIN.Text) = "" Then
                stMUTAFEIN = "%"
            Else
                stMUTAFEIN = Trim(Me.txtMUTAFEIN.Text)
            End If

            ' carga los campos
            If Trim(Me.txtTRCADESC.Text) = "" Then
                stMUTADESC = "%"
            Else
                stMUTADESC = Trim(Me.txtTRCADESC.Text)
            End If

            ' carga los campos
            If Trim(stORDERBY) = "" Then
                stORDERBY = "MUTAMUNI, MUTACORR, MUTABARR, MUTAMANZ, MUTAPRED "
            End If

            'concatena la consulta
            stConsulta += "Select "
            stConsulta += "MUTAIDRE , "
            stConsulta += "MUTANUFI as 'Nro. Ficha', "
            stConsulta += "MUTAMAIN as 'Matricula', "
            stConsulta += "MUTAMUNI as 'Municipio', "
            stConsulta += "MUTACORR as 'Correg', "
            stConsulta += "MUTABARR as 'Barrio', "
            stConsulta += "MUTAMANZ as 'Manzana', "
            stConsulta += "MUTAPRED as 'Predio', "
            stConsulta += "MUTAEDIF as 'Edificio', "
            stConsulta += "MUTAUNPR as 'Unidad', "
            stConsulta += "MUTACLSE as 'Sector', "
            stConsulta += "MUTAVIGE as 'Vigencia', "
            stConsulta += "MUTAESCR as 'Escritura', "
            stConsulta += "MUTAFEES as 'Fecha escritura', "
            stConsulta += "MUTANURA as 'Radicado', "
            stConsulta += "MUTAFERA as 'Fecha radicado', "
            stConsulta += "MUTAESTA as 'Estado', "
            stConsulta += "MUTADESC as 'Descripción' "
            stConsulta += "From MUTACIONES "
            stConsulta += "Where "
            stConsulta += "MUTANUFI like '" & stMUTANUFI & "' and "
            stConsulta += "MUTAMAIN like '" & stMUTAMAIN & "' and "
            stConsulta += "MUTAMUNI like '" & stMUTAMUNI & "' and "
            stConsulta += "MUTACORR like '" & stMUTACORR & "' and "
            stConsulta += "MUTABARR like '" & stMUTABARR & "' and "
            stConsulta += "MUTAMANZ like '" & stMUTAMANZ & "' and "
            stConsulta += "MUTAPRED like '" & stMUTAPRED & "' and "
            stConsulta += "MUTAEDIF like '" & stMUTAEDIF & "' and "
            stConsulta += "MUTAUNPR like '" & stMUTAUNPR & "' and "
            stConsulta += "MUTACLSE like '" & stMUTACLSE & "' and "
            stConsulta += "MUTAVIGE like '" & stMUTAVIGE & "' and "
            stConsulta += "MUTAFEES like '" & stMUTAFEES & "' and "
            stConsulta += "MUTAESCR like '" & stMUTAESCR & "' and "
            stConsulta += "MUTANURA like '" & stMUTANURA & "' and "
            stConsulta += "MUTAFERA like '" & stMUTAFERA & "' and "
            stConsulta += "MUTAESTA like '" & stMUTAESTA & "' and "
            stConsulta += "MUTAOBSE like '" & stMUTAOBSE & "' and "
            stConsulta += "MUTADESC like '" & stMUTADESC & "'  "
            stConsulta += "Order by " & stORDERBY & " "

            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsulta)

            Me.dgvCONSULTA.DataSource = dt

            Me.dgvCONSULTA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptar.Enabled = False
                Me.txtMUTAMUNI.Focus()
            Else
                Me.cmdAceptar.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtMUTANUFI.Text = ""
        Me.txtMUTAMAIN.Text = ""
        Me.txtMUTAMUNI.Text = ""
        Me.txtMUTACORR.Text = ""
        Me.txtMUTABARR.Text = ""
        Me.txtMUTAMANZ.Text = ""
        Me.txtMUTAPRED.Text = ""
        Me.txtMUTAEDIF.Text = ""
        Me.txtMUTAUNPR.Text = ""
        Me.txtMUTAESCR.Text = ""
        Me.txtMUTAFEES.Text = ""
        Me.txtMUTACLSE.Text = ""
        Me.txtMUTAVIGE.Text = ""
        Me.txtMUTAFEIN.Text = ""
        Me.txtMUTAVIGE.Text = ""
        Me.txtMUTAFERA.Text = ""
        Me.txtMUTANURA.Text = ""
        Me.txtMUTANUFI.Text = ""
        Me.txtMUTAESTA.Text = ""
        Me.txtTRCADESC.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA.DataSource = New DataTable

        pro_LimpiarCampos2()

    End Sub
    Private Sub pro_LimpiarCampos2()

        Me.chkTRCAMUNI.Checked = False
        Me.chkTRCACORR.Checked = False
        Me.chkTRCABARR.Checked = False
        Me.chkTRCAMANZ.Checked = False
        Me.chkTRCAPRED.Checked = False
        Me.chkTRCACLSE.Checked = False
        Me.chkTRCAVIGE.Checked = False
        Me.chkTRCAFEIN.Checked = False
        Me.chkTRCAESTA.Checked = False

        stORDERBY = ""

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
            Dim inId_Reg As New frm_MUTACIONES(Integer.Parse(Me.dgvCONSULTA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtMUTAMUNI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
        Me.txtMUTAMUNI.Focus()
    End Sub
    Private Sub cmdLimpiar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar2.Click
        pro_LimpiarCampos2()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Dim inNroIdRe As New frm_MUTACIONES(inID_REGISTRO)
        Me.Close()
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

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()

    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_consultar_TRABCAMP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.txtMUTAMUNI.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMUTAMUNI.KeyPress, txtMUTACORR.KeyPress, txtMUTABARR.KeyPress, txtMUTAMANZ.KeyPress, txtMUTAPRED.KeyPress, txtMUTAEDIF.KeyPress, txtMUTAUNPR.KeyPress, txtMUTACLSE.KeyPress, txtMUTAVIGE.KeyPress, txtMUTAFEES.KeyPress, txtMUTAESCR.KeyPress, txtMUTANUFI.KeyPress, txtMUTAMAIN.KeyPress, txtMUTAESTA.KeyPress, txtTRCAOBSE.KeyPress, txtMUTANURA.KeyPress, txtMUTAFERA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub


#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUTAMUNI.GotFocus, txtMUTACORR.GotFocus, txtMUTABARR.GotFocus, txtMUTAMANZ.GotFocus, txtMUTAPRED.GotFocus, txtMUTAEDIF.GotFocus, txtMUTAUNPR.GotFocus, txtMUTAFEES.GotFocus, txtMUTAESCR.GotFocus, txtMUTAMAIN.GotFocus, txtTRCAOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.GotFocus, cmdSalir.GotFocus, cmdConsultar.GotFocus, cmdLimpiar.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUTACLSE.GotFocus, txtMUTAVIGE.GotFocus, txtMUTAFERA.GotFocus, txtMUTANURA.GotFocus, txtMUTANUFI.GotFocus, txtMUTAESTA.GotFocus, txtMUTANURA.GotFocus, txtMUTAFERA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUTAMUNI.Validated
        If Me.txtMUTAMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMUTAMUNI.Text) = True Then
            Me.txtMUTAMUNI.Text = fun_Formato_Mascara_3_String(Me.txtMUTAMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUTACORR.Validated
        If Me.txtMUTACORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMUTACORR.Text) = True Then
            Me.txtMUTACORR.Text = fun_Formato_Mascara_2_String(Me.txtMUTACORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUTABARR.Validated
        If Me.txtMUTABARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMUTABARR.Text) = True Then
            Me.txtMUTABARR.Text = fun_Formato_Mascara_3_String(Me.txtMUTABARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUTAMANZ.Validated
        If Me.txtMUTAMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMUTAMANZ.Text) = True Then
            Me.txtMUTAMANZ.Text = fun_Formato_Mascara_3_String(Me.txtMUTAMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUTAPRED.Validated
        If Me.txtMUTAPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMUTAPRED.Text) = True Then
            Me.txtMUTAPRED.Text = fun_Formato_Mascara_5_String(Me.txtMUTAPRED.Text)
        End If
    End Sub
    Private Sub txtTRCAEDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUTAEDIF.Validated
        If Me.txtMUTAEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMUTAEDIF.Text) = True Then
            Me.txtMUTAEDIF.Text = fun_Formato_Mascara_3_String(Me.txtMUTAEDIF.Text)
        End If
    End Sub
    Private Sub txtTRCAUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUTAUNPR.Validated
        If Me.txtMUTAUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMUTAUNPR.Text) = True Then
            Me.txtMUTAUNPR.Text = fun_Formato_Mascara_5_String(Me.txtMUTAUNPR.Text)
        End If
    End Sub

#End Region

#Region "CheckedChanged"

    Private Sub chkTRCAMUNI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTRCAMUNI.CheckedChanged
        If Trim(stORDERBY) = "" Then
            stORDERBY = "MUTAMUNI"
        Else
            stORDERBY += ",TRCAMUNI"
        End If
    End Sub
    Private Sub chkTRCACORR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTRCACORR.CheckedChanged
        If Trim(stORDERBY) = "" Then
            stORDERBY = "MUTACORR"
        Else
            stORDERBY += ",TRCACORR"
        End If
    End Sub
    Private Sub chkTRCABARR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTRCABARR.CheckedChanged
        If Trim(stORDERBY) = "" Then
            stORDERBY = "MUTABARR"
        Else
            stORDERBY += ",TRCABARR"
        End If
    End Sub
    Private Sub chkTRCAMANZ_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTRCAMANZ.CheckedChanged
        If Trim(stORDERBY) = "" Then
            stORDERBY = "MUTAMANZ"
        Else
            stORDERBY += ",TRCAMANZ"
        End If
    End Sub
    Private Sub chkTRCAPRED_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTRCAPRED.CheckedChanged
        If Trim(stORDERBY) = "" Then
            stORDERBY = "MUTAPRED"
        Else
            stORDERBY += ",TRCAPRED"
        End If
    End Sub
    Private Sub chkTRCACLSE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTRCACLSE.CheckedChanged
        If Trim(stORDERBY) = "" Then
            stORDERBY = "MUTACLSE"
        Else
            stORDERBY += ",TRCACLSE"
        End If
    End Sub
    Private Sub chkTRCAVIGE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTRCAVIGE.CheckedChanged
        If Trim(stORDERBY) = "" Then
            stORDERBY = "MUTAVIGE"
        Else
            stORDERBY += ",TRCAVIGE"
        End If
    End Sub
    Private Sub chkTRCAFEIN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTRCAFEIN.CheckedChanged
        If Trim(stORDERBY) = "" Then
            stORDERBY = "MUTAFEIN"
        Else
            stORDERBY += ",TRCAFEIN"
        End If
    End Sub
    Private Sub chkTRCAESTA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTRCAESTA.CheckedChanged
        If Trim(stORDERBY) = "" Then
            stORDERBY = "MUTAESTA"
        Else
            stORDERBY += ",TRCAESTA"
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