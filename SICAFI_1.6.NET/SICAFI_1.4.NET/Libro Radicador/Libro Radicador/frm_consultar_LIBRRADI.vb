Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_LIBRRADI

    '===============================
    '*** CONSULTA LIBRO RADICADO ***
    '===============================

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

    Private Sub pro_ReconsultarLibroRadicador()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de los campos
            Dim stLIRANURA As String = ""
            Dim stLIRAFERA As String = ""
            Dim stLIRAOFSA As String = ""

            ' carga los campos
            If Trim(Me.txtLIRANURA.Text) = "" Then
                stLIRANURA = "%"
            Else
                stLIRANURA = Trim(Me.txtLIRANURA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtLIRAFERA.Text) = "" Then
                stLIRAFERA = "%"
            Else
                stLIRAFERA = Trim(Me.txtLIRAFERA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtLIRAOFSA.Text) = "" Then
                stLIRAOFSA = "%"
            Else
                stLIRAOFSA = Trim(Me.txtLIRAOFSA.Text)
            End If

            ' crea la variable de consulta
            Dim stConsultaSQL As String = ""

            'concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "LIRAIDRE, "
            stConsultaSQL += "LIRANURA as 'Nro. Radicado', "
            stConsultaSQL += "LIRAFERA as 'Fecha de radicado', "
            stConsultaSQL += "ACADDESC as 'Clasificación', "
            stConsultaSQL += "LIRAASUN as 'Asunto', "
            stConsultaSQL += "LIRAOFSA as 'Oficio de salida', "
            stConsultaSQL += "DIVIDESC as 'División', "
            stConsultaSQL += "LIRAFEIN as 'Fecha de ingreso', "
            stConsultaSQL += "ESTADESC as 'Estado' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIBRRADI, MANT_ACTOADMI, MANT_DIVISION, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIRAACAD = ACADCODI AND "
            stConsultaSQL += "LIRADIVI = DIVICODI AND "
            stConsultaSQL += "LIRAESTA = ESTACODI AND "
            stConsultaSQL += "LIRANURA LIKE '" & stLIRANURA & "' AND "
            stConsultaSQL += "LIRAFERA LIKE '" & stLIRAFERA & "' AND "
            stConsultaSQL += "LIRAOFSA LIKE '" & stLIRAOFSA & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LIRANURA, LIRAFERA "


            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

            Me.dgvCONSULTA_LIBRRADI.DataSource = dt

            Me.dgvCONSULTA_LIBRRADI.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA_LIBRRADI.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptarLibroRadicador.Enabled = False
                Me.txtLIRANURA.Focus()
            Else

                Me.cmdAceptarLibroRadicador.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarLibroRadicadorSolicitante()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de los campos
            Dim stLRSONUDO As String = ""
            Dim stLRSOPRAP As String = ""
            Dim stLRSOSEAP As String = ""
            Dim stLRSONOMB As String = ""
            Dim stLRSODIRE As String = ""

            ' carga los campos
            If Trim(Me.txtLRSONUDO.Text) = "" Then
                stLRSONUDO = "%"
            Else
                stLRSONUDO = Trim(Me.txtLRSONUDO.Text)
            End If

            ' carga los campos
            If Trim(Me.txtLRSOPRAP.Text) = "" Then
                stLRSOPRAP = "%"
            Else
                stLRSOPRAP = Trim(Me.txtLRSOPRAP.Text)
            End If

            ' carga los campos
            If Trim(Me.txtLRSOSEAP.Text) = "" Then
                stLRSOSEAP = "%"
            Else
                stLRSOSEAP = Trim(Me.txtLRSOSEAP.Text)
            End If

            ' carga los campos
            If Trim(Me.txtLRSONOMB.Text) = "" Then
                stLRSONOMB = "%"
            Else
                stLRSONOMB = Trim(Me.txtLRSONOMB.Text)
            End If

            ' carga los campos
            If Trim(Me.txtLRSODIRE.Text) = "" Then
                stLRSODIRE = "%"
            Else
                stLRSODIRE = Trim(Me.txtLRSODIRE.Text)
            End If

            ' crea la variable de consulta
            Dim stConsultaSQL As String = ""

            'concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "LIRAIDRE, "
            stConsultaSQL += "LRSONURA as 'Nro. Radicado', "
            stConsultaSQL += "LRSOFERA as 'Fecha de radicado', "
            stConsultaSQL += "LRSONUDO as 'Nro. Documento', "
            stConsultaSQL += "LRSONOMB as 'Nombre(s)', "
            stConsultaSQL += "LRSOPRAP as 'Primer apellido', "
            stConsultaSQL += "LRSOSEAP as 'Segundo apellido', "
            stConsultaSQL += "SOLIDESC as 'Solicitante', "
            stConsultaSQL += "LRSODIPR as 'Dirección del predio' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIBRRADI, LIRASOLI, MANT_SOLICITANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIRANURA = LRSONURA AND "
            stConsultaSQL += "LIRAFERA = LRSOFERA AND "
            stConsultaSQL += "LIRASECU = LRSOSECU AND "

            stConsultaSQL += "LRSOSOLI = SOLICODI AND "

            stConsultaSQL += "LRSONUDO LIKE '" & stLRSONUDO & "' AND "
            stConsultaSQL += "LRSOPRAP LIKE '" & stLRSOPRAP & "' AND "
            stConsultaSQL += "LRSOSEAP LIKE '" & stLRSOSEAP & "' AND "
            stConsultaSQL += "LRSONOMB LIKE '" & stLRSONOMB & "' AND "
            stConsultaSQL += "LRSODIPR LIKE '" & stLRSODIRE & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LRSONURA, LRSOFERA "


            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

            Me.dgvCONSULTA_LIRASOLI.DataSource = dt

            Me.dgvCONSULTA_LIRASOLI.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA_LIRASOLI.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()

                Me.cmdAceptarSolicitante.Enabled = False
                Me.txtLRSONUDO.Focus()

                Me.strBARRESTA.Items(2).Text = "Registros : " & "0"
            Else
                Me.cmdAceptarSolicitante.Enabled = True
                Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarLibroRadicadorPredio()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de los campos
            Dim stLRPRMUNI As String = ""
            Dim stLRPRCORR As String = ""
            Dim stLRPRBARR As String = ""
            Dim stLRPRMANZ As String = ""
            Dim stLRPRPRED As String = ""
            Dim stLRPREDIF As String = ""
            Dim stLRPRUNPR As String = ""
            Dim stLRPRCLSE As String = ""
            Dim stLRPRNUFI As String = ""
            Dim stLRPRMAIN As String = ""

            ' carga los campos
            If Trim(Me.txtLRPRMUNI.Text) = "" Then
                stLRPRMUNI = "%"
            Else
                stLRPRMUNI = Trim(Me.txtLRPRMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtLRPRCORR.Text) = "" Then
                stLRPRCORR = "%"
            Else
                stLRPRCORR = Trim(Me.txtLRPRCORR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtLRPRBARR.Text) = "" Then
                stLRPRBARR = "%"
            Else
                stLRPRBARR = Trim(Me.txtLRPRBARR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtLRPRMANZ.Text) = "" Then
                stLRPRMANZ = "%"
            Else
                stLRPRMANZ = Trim(Me.txtLRPRMANZ.Text)
            End If

            ' carga los campos
            If Trim(Me.txtLRPRPRED.Text) = "" Then
                stLRPRPRED = "%"
            Else
                stLRPRPRED = Trim(Me.txtLRPRPRED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtLRPREDIF.Text) = "" Then
                stLRPREDIF = "%"
            Else
                stLRPREDIF = Trim(Me.txtLRPREDIF.Text)
            End If

            ' carga los campos
            If Trim(Me.txtLRPRUNPR.Text) = "" Then
                stLRPRUNPR = "%"
            Else
                stLRPRUNPR = Trim(Me.txtLRPRUNPR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtLRPRCLSE.Text) = "" Then
                stLRPRCLSE = "%"
            Else
                stLRPRCLSE = Trim(Me.txtLRPRCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtLRPRNUFI.Text) = "" Then
                stLRPRNUFI = "%"
            Else
                stLRPRNUFI = Trim(Me.txtLRPRNUFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtLRPRMAIN.Text) = "" Then
                stLRPRMAIN = "%"
            Else
                stLRPRMAIN = Trim(Me.txtLRPRMAIN.Text)
            End If

            ' crea la variable de consulta
            Dim stConsultaSQL As String = ""

            'concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "LIRAIDRE, "
            stConsultaSQL += "LRPRNURA as 'Nro. Radicado', "
            stConsultaSQL += "LRPRFERA as 'Fecha de radicado', "
            stConsultaSQL += "LRPRMUNI as 'Municipio', "
            stConsultaSQL += "LRPRCORR as 'Corregi.', "
            stConsultaSQL += "LRPRBARR as 'Barrio', "
            stConsultaSQL += "LRPRMANZ as 'Manzana Vereda', "
            stConsultaSQL += "LRPRPRED as 'Predio', "
            stConsultaSQL += "LRPREDIF as 'Edificio', "
            stConsultaSQL += "LRPRUNPR as 'Unidad predial', "
            stConsultaSQL += "CLSEDESC as 'Sector', "
            stConsultaSQL += "LRPRNUFI as 'Nro. Ficha predial', "
            stConsultaSQL += "LRPRMAIN as 'Matricula' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIBRRADI, LIRAPRED, MANT_CLASSECT "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "LIRANURA = LRPRNURA AND "
            stConsultaSQL += "LIRAFERA = LRPRFERA AND "
            stConsultaSQL += "LIRASECU = LRPRSECU AND "

            stConsultaSQL += "LRPRCLSE = CLSECODI AND "

            stConsultaSQL += "LRPRMUNI LIKE '" & stLRPRMUNI & "' AND "
            stConsultaSQL += "LRPRCORR LIKE '" & stLRPRCORR & "' AND "
            stConsultaSQL += "LRPRBARR LIKE '" & stLRPRBARR & "' AND "
            stConsultaSQL += "LRPRMANZ LIKE '" & stLRPRMANZ & "' AND "
            stConsultaSQL += "LRPRPRED LIKE '" & stLRPRPRED & "' AND "
            stConsultaSQL += "LRPREDIF LIKE '" & stLRPREDIF & "' AND "
            stConsultaSQL += "LRPRUNPR LIKE '" & stLRPRUNPR & "' AND "
            stConsultaSQL += "LRPRCLSE LIKE '" & stLRPRCLSE & "' AND "
            stConsultaSQL += "LRPRNUFI LIKE '" & stLRPRNUFI & "' AND "
            stConsultaSQL += "LRPRMAIN LIKE '" & stLRPRMAIN & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LRPRNURA, LRPRFERA "


            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

            Me.dgvCONSULTA_LIRAPRED.DataSource = dt

            Me.dgvCONSULTA_LIRAPRED.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA_LIRAPRED.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()

                Me.cmdAceptarPredio.Enabled = False
                Me.txtLIRANURA.Focus()

                Me.strBARRESTA.Items(2).Text = "Registros : " & "0"
            Else
                Me.cmdAceptarPredio.Enabled = True
                Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_LimpiarCamposLibroRadicador()

        Me.txtLIRANURA.Text = ""
        Me.txtLIRAFERA.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA_LIBRRADI.DataSource = New DataTable

        Me.cmdAceptarLibroRadicador.Enabled = False

    End Sub
    Private Sub pro_LimpiarCamposLibroRadicadorSolicitante()

        Me.txtLRSONUDO.Text = ""
        Me.txtLRSOPRAP.Text = ""
        Me.txtLRSOSEAP.Text = ""
        Me.txtLRSONOMB.Text = ""
        Me.txtLRSODIRE.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA_LIRASOLI.DataSource = New DataTable

        Me.cmdAceptarSolicitante.Enabled = False

    End Sub
    Private Sub pro_LimpiarCamposLibroRadicadorPredio()

        Me.txtLRPRMUNI.Text = ""
        Me.txtLRPRCORR.Text = ""
        Me.txtLRPRBARR.Text = ""
        Me.txtLRPRMANZ.Text = ""
        Me.txtLRPRPRED.Text = ""
        Me.txtLRPREDIF.Text = ""
        Me.txtLRPRUNPR.Text = ""
        Me.txtLRPRCLSE.Text = ""
        Me.txtLRPRNUFI.Text = ""
        Me.txtLRPRMAIN.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA_LIRAPRED.DataSource = New DataTable

        Me.cmdAceptarPredio.Enabled = False

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdConsultarLibroRadicador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarLibroRadicador.Click

        Try
            pro_ReconsultarLibroRadicador()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdConsultarSolicitante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarSolicitante.Click

        Try
            pro_ReconsultarLibroRadicadorSolicitante()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdConsultarPredio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarPredio.Click

        Try
            pro_ReconsultarLibroRadicadorPredio()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdAceptarLibroRadicador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptarLibroRadicador.Click

        If Me.dgvCONSULTA_LIBRRADI.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_LIBRRADI(Integer.Parse(Me.dgvCONSULTA_LIBRRADI.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtLIRANURA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdAceptarSolicitante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptarSolicitante.Click

        If Me.dgvCONSULTA_LIRASOLI.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_LIBRRADI(Integer.Parse(Me.dgvCONSULTA_LIRASOLI.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtLRSONUDO.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdAceptarPredio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptarPredio.Click

        If Me.dgvCONSULTA_LIRAPRED.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_LIBRRADI(Integer.Parse(Me.dgvCONSULTA_LIRAPRED.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtLRPRMUNI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiarLibroRadicador.Click
        pro_LimpiarCamposLibroRadicador()
        Me.txtLIRANURA.Focus()
    End Sub
    Private Sub cmdLimpiarSolicitante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiarSolicitante.Click
        pro_LimpiarCamposLibroRadicadorSolicitante()
        Me.txtLRSONUDO.Focus()
    End Sub
    Private Sub cmdLimpiarPredio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiarPredio.Click
        pro_LimpiarCamposLibroRadicadorPredio()
        Me.txtLRPRMUNI.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Dim inNroIdRe As New frm_LIBRRADI(inID_REGISTRO)
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCamposLibroRadicador()
        pro_LimpiarCamposLibroRadicadorSolicitante()
        pro_LimpiarCamposLibroRadicadorPredio()

    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_consultar_TRABCAMP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.txtLIRANURA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLIRANURA.KeyPress, txtLIRAFERA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub


#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLIRAFERA.GotFocus, txtLIRANURA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptarLibroRadicador.GotFocus, cmdSalir.GotFocus, cmdConsultarLibroRadicador.GotFocus, cmdLimpiarLibroRadicador.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtLRPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRPRMUNI.Validated
        If Me.txtLRPRMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtLRPRMUNI.Text) = True Then
            Me.txtLRPRMUNI.Text = fun_Formato_Mascara_3_String(Me.txtLRPRMUNI.Text)
        End If
    End Sub
    Private Sub txtLRPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRPRCORR.Validated
        If Me.txtLRPRCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtLRPRCORR.Text) = True Then
            Me.txtLRPRCORR.Text = fun_Formato_Mascara_2_String(Me.txtLRPRCORR.Text)
        End If
    End Sub
    Private Sub txtLRPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRPRBARR.Validated
        If Me.txtLRPRBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtLRPRBARR.Text) = True Then
            Me.txtLRPRBARR.Text = fun_Formato_Mascara_3_String(Me.txtLRPRBARR.Text)
        End If
    End Sub
    Private Sub txtLRPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRPRMANZ.Validated
        If Me.txtLRPRMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtLRPRMANZ.Text) = True Then
            Me.txtLRPRMANZ.Text = fun_Formato_Mascara_3_String(Me.txtLRPRMANZ.Text)
        End If
    End Sub
    Private Sub txtLRPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRPRPRED.Validated
        If Me.txtLRPRPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtLRPRPRED.Text) = True Then
            Me.txtLRPRPRED.Text = fun_Formato_Mascara_5_String(Me.txtLRPRPRED.Text)
        End If
    End Sub
    Private Sub txtLRPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRPREDIF.Validated
        If Me.txtLRPREDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtLRPREDIF.Text) = True Then
            Me.txtLRPREDIF.Text = fun_Formato_Mascara_3_String(Me.txtLRPREDIF.Text)
        End If
    End Sub
    Private Sub txtLRPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLRPRUNPR.Validated
        If Me.txtLRPRUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtLRPRUNPR.Text) = True Then
            Me.txtLRPRUNPR.Text = fun_Formato_Mascara_5_String(Me.txtLRPRUNPR.Text)
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

#Region "CellDoubleClick"

    Private Sub dgvCONSULTA_LIBRRADI_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA_LIBRRADI.CellDoubleClick
        Me.cmdAceptarLibroRadicador.PerformClick()
    End Sub
    Private Sub dgvCONSULTA_LIRASOLI_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA_LIRASOLI.CellDoubleClick
        Me.cmdAceptarSolicitante.PerformClick()
    End Sub
    Private Sub dgvCONSULTA_LIRAPRED_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA_LIRAPRED.CellDoubleClick
        Me.cmdAceptarPredio.PerformClick()
    End Sub

#End Region

#End Region

End Class