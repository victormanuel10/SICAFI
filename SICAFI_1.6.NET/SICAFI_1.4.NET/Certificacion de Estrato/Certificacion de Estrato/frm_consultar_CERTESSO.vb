Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_CERTESSO

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

    Private Sub pro_ReconsultarCertificacionDeEstratoSocioeconomico()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de los campos
            Dim stCEESNURA As String = ""
            Dim stCEESFERA As String = ""
            Dim stCEESOFSA As String = ""

            ' carga los campos
            If Trim(Me.txtCEESNURA.Text) = "" Then
                stCEESNURA = "%"
            Else
                stCEESNURA = Trim(Me.txtCEESNURA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCEESFERA.Text) = "" Then
                stCEESFERA = "%"
            Else
                stCEESFERA = Trim(Me.txtCEESFERA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCEESOFSA.Text) = "" Then
                stCEESOFSA = "%"
            Else
                stCEESOFSA = Trim(Me.txtCEESOFSA.Text)
            End If

            ' crea la variable de consulta
            Dim stConsultaSQL As String = ""

            'concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "CEESIDRE, "
            stConsultaSQL += "CEESNURA as 'Nro. Radicado', "
            stConsultaSQL += "CEESFERA as 'Fecha de radicado', "
            stConsultaSQL += "ACADDESC as 'Clasificación', "
            stConsultaSQL += "CEESASUN as 'Asunto', "
            stConsultaSQL += "CEESOFSA as 'Oficio de salida', "
            stConsultaSQL += "CEESFEIN as 'Fecha de ingreso', "
            stConsultaSQL += "ESTADESC as 'Estado' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CERTESSO, MANT_ACTOADMI, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEESCLAS = ACADCODI AND "
            stConsultaSQL += "CEESESTA = ESTACODI AND "
            stConsultaSQL += "CEESNURA LIKE '" & CStr(Trim(stCEESNURA)) & "' AND "
            stConsultaSQL += "CEESFERA LIKE '" & CStr(Trim(stCEESFERA)) & "' AND "
            stConsultaSQL += "CEESOFSA LIKE '" & CStr(Trim(stCEESOFSA)) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CEESNURA, CEESFERA "


            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

            Me.dgvCONSULTA_CERTESSO.DataSource = dt

            Me.dgvCONSULTA_CERTESSO.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA_CERTESSO.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptarCertificacionDeEstrato.Enabled = False
                Me.txtCEESNURA.Focus()
            Else

                Me.cmdAceptarCertificacionDeEstrato.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarCertificacionDeEstratoSocioeconomicoSolicitante()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de los campos
            Dim stCESONUDO As String = ""
            Dim stCESOPRAP As String = ""
            Dim stCESOSEAP As String = ""
            Dim stCESONOMB As String = ""
            Dim stCESODIRE As String = ""

            ' carga los campos
            If Trim(Me.txtCESONUDO.Text) = "" Then
                stCESONUDO = "%"
            Else
                stCESONUDO = Trim(Me.txtCESONUDO.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCESOPRAP.Text) = "" Then
                stCESOPRAP = "%"
            Else
                stCESOPRAP = Trim(Me.txtCESOPRAP.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCESOSEAP.Text) = "" Then
                stCESOSEAP = "%"
            Else
                stCESOSEAP = Trim(Me.txtCESOSEAP.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCESONOMB.Text) = "" Then
                stCESONOMB = "%"
            Else
                stCESONOMB = Trim(Me.txtCESONOMB.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCESODIRE.Text) = "" Then
                stCESODIRE = "%"
            Else
                stCESODIRE = Trim(Me.txtCESODIRE.Text)
            End If

            ' crea la variable de consulta
            Dim stConsultaSQL As String = ""

            'concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "CEESIDRE, "
            stConsultaSQL += "CESONURA as 'Nro. Radicado', "
            stConsultaSQL += "CESOFERA as 'Fecha de radicado', "
            stConsultaSQL += "CESONUDO as 'Nro. Documento', "
            stConsultaSQL += "CESONOMB as 'Nombre(s)', "
            stConsultaSQL += "CESOPRAP as 'Primer apellido', "
            stConsultaSQL += "CESOSEAP as 'Segundo apellido', "
            stConsultaSQL += "SOLIDESC as 'Solicitante', "
            stConsultaSQL += "CESODIPR as 'Dirección del predio' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CERTESSO, CEESSOLI, MANT_SOLICITANTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEESNURA = CESONURA AND "
            stConsultaSQL += "CEESFERA = CESOFERA AND "
            stConsultaSQL += "CEESSECU = CESOSECU AND "

            stConsultaSQL += "CESOSOLI = SOLICODI AND "

            stConsultaSQL += "CESONUDO LIKE '" & CStr(Trim(stCESONUDO)) & "' AND "
            stConsultaSQL += "CESOPRAP LIKE '" & CStr(Trim(stCESOPRAP)) & "' AND "
            stConsultaSQL += "CESOSEAP LIKE '" & CStr(Trim(stCESOSEAP)) & "' AND "
            stConsultaSQL += "CESONOMB LIKE '" & CStr(Trim(stCESONOMB)) & "' AND "
            stConsultaSQL += "CESODIPR LIKE '" & CStr(Trim(stCESODIRE)) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CESONURA, CESOFERA "


            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

            Me.dgvCONSULTA_CEESSOLI.DataSource = dt

            Me.dgvCONSULTA_CEESSOLI.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA_CEESSOLI.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()

                Me.cmdAceptarSolicitante.Enabled = False
                Me.txtCESONUDO.Focus()

                Me.strBARRESTA.Items(2).Text = "Registros : " & "0"
            Else
                Me.cmdAceptarSolicitante.Enabled = True
                Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarCertificacionDeEstratoSocioeconomicoPredio()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de los campos
            Dim stCEPRMUNI As String = ""
            Dim stCEPRCORR As String = ""
            Dim stCEPRBARR As String = ""
            Dim stCEPRMANZ As String = ""
            Dim stCEPRPRED As String = ""
            Dim stCEPREDIF As String = ""
            Dim stCEPRUNPR As String = ""
            Dim stCEPRCLSE As String = ""
            Dim stCEPRNUFI As String = ""
            Dim stCEPRMAIN As String = ""

            ' carga los campos
            If Trim(Me.txtCEPRMUNI.Text) = "" Then
                stCEPRMUNI = "%"
            Else
                stCEPRMUNI = Trim(Me.txtCEPRMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCEPRCORR.Text) = "" Then
                stCEPRCORR = "%"
            Else
                stCEPRCORR = Trim(Me.txtCEPRCORR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCEPRBARR.Text) = "" Then
                stCEPRBARR = "%"
            Else
                stCEPRBARR = Trim(Me.txtCEPRBARR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCEPRMANZ.Text) = "" Then
                stCEPRMANZ = "%"
            Else
                stCEPRMANZ = Trim(Me.txtCEPRMANZ.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCEPRPRED.Text) = "" Then
                stCEPRPRED = "%"
            Else
                stCEPRPRED = Trim(Me.txtCEPRPRED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCEPREDIF.Text) = "" Then
                stCEPREDIF = "%"
            Else
                stCEPREDIF = Trim(Me.txtCEPREDIF.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCEPRUNPR.Text) = "" Then
                stCEPRUNPR = "%"
            Else
                stCEPRUNPR = Trim(Me.txtCEPRUNPR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCEPRCLSE.Text) = "" Then
                stCEPRCLSE = "%"
            Else
                stCEPRCLSE = Trim(Me.txtCEPRCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCEPRNUFI.Text) = "" Then
                stCEPRNUFI = "%"
            Else
                stCEPRNUFI = Trim(Me.txtCEPRNUFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtCEPRMAIN.Text) = "" Then
                stCEPRMAIN = "%"
            Else
                stCEPRMAIN = Trim(Me.txtCEPRMAIN.Text)
            End If

            ' crea la variable de consulta
            Dim stConsultaSQL As String = ""

            'concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "CEESIDRE, "
            stConsultaSQL += "CEPRNURA as 'Nro. Radicado', "
            stConsultaSQL += "CEPRFERA as 'Fecha de radicado', "
            stConsultaSQL += "CEPRMUNI as 'Municipio', "
            stConsultaSQL += "CEPRCORR as 'Corregi.', "
            stConsultaSQL += "CEPRBARR as 'Barrio', "
            stConsultaSQL += "CEPRMANZ as 'Manzana Vereda', "
            stConsultaSQL += "CEPRPRED as 'Predio', "
            stConsultaSQL += "CEPREDIF as 'Edificio', "
            stConsultaSQL += "CEPRUNPR as 'Unidad predial', "
            stConsultaSQL += "CLSEDESC as 'Sector', "
            stConsultaSQL += "CEPRNUFI as 'Nro. Ficha predial', "
            stConsultaSQL += "CEPRMAIN as 'Matricula' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CERTESSO, CEESPRED, MANT_CLASSECT "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "CEESNURA = CEPRNURA AND "
            stConsultaSQL += "CEESFERA = CEPRFERA AND "
            stConsultaSQL += "CEESSECU = CEPRSECU AND "

            stConsultaSQL += "CEPRCLSE = CLSECODI AND "

            stConsultaSQL += "CEPRMUNI LIKE '" & CStr(Trim(stCEPRMUNI)) & "' AND "
            stConsultaSQL += "CEPRCORR LIKE '" & CStr(Trim(stCEPRCORR)) & "' AND "
            stConsultaSQL += "CEPRBARR LIKE '" & CStr(Trim(stCEPRBARR)) & "' AND "
            stConsultaSQL += "CEPRMANZ LIKE '" & CStr(Trim(stCEPRMANZ)) & "' AND "
            stConsultaSQL += "CEPRPRED LIKE '" & CStr(Trim(stCEPRPRED)) & "' AND "
            stConsultaSQL += "CEPREDIF LIKE '" & CStr(Trim(stCEPREDIF)) & "' AND "
            stConsultaSQL += "CEPRUNPR LIKE '" & CStr(Trim(stCEPRUNPR)) & "' AND "
            stConsultaSQL += "CEPRCLSE LIKE '" & CStr(Trim(stCEPRCLSE)) & "' AND "
            stConsultaSQL += "CEPRNUFI LIKE '" & CStr(Trim(stCEPRNUFI)) & "' AND "
            stConsultaSQL += "CEPRMAIN LIKE '" & CStr(Trim(stCEPRMAIN)) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CEPRNURA, CEPRFERA "


            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

            Me.dgvCONSULTA_CEESPRED.DataSource = dt

            Me.dgvCONSULTA_CEESPRED.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA_CEESPRED.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()

                Me.cmdAceptarPredio.Enabled = False
                Me.txtCEESNURA.Focus()

                Me.strBARRESTA.Items(2).Text = "Registros : " & "0"
            Else
                Me.cmdAceptarPredio.Enabled = True
                Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_LimpiarCamposCertificacionDeEstratoSocioeconomico()

        Me.txtCEESNURA.Text = ""
        Me.txtCEESFERA.Text = ""
        Me.txtCEESOFSA.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA_CERTESSO.DataSource = New DataTable

        Me.cmdAceptarCertificacionDeEstrato.Enabled = False

    End Sub
    Private Sub pro_LimpiarCamposCertificacionDeEstratoSocioeconomicoSolicitante()

        Me.txtCESONUDO.Text = ""
        Me.txtCESOPRAP.Text = ""
        Me.txtCESOSEAP.Text = ""
        Me.txtCESONOMB.Text = ""
        Me.txtCESODIRE.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA_CEESSOLI.DataSource = New DataTable

        Me.cmdAceptarSolicitante.Enabled = False

    End Sub
    Private Sub pro_LimpiarCamposCertificacionDeEstratoSocioeconomicoPredio()

        Me.txtCEPRMUNI.Text = ""
        Me.txtCEPRCORR.Text = ""
        Me.txtCEPRBARR.Text = ""
        Me.txtCEPRMANZ.Text = ""
        Me.txtCEPRPRED.Text = ""
        Me.txtCEPREDIF.Text = ""
        Me.txtCEPRUNPR.Text = ""
        Me.txtCEPRCLSE.Text = ""
        Me.txtCEPRNUFI.Text = ""
        Me.txtCEPRMAIN.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA_CEESPRED.DataSource = New DataTable

        Me.cmdAceptarPredio.Enabled = False

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdConsultarCertificacionDeEstrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarCertificacionDeEstrato.Click

        Try
            pro_ReconsultarCertificacionDeEstratoSocioeconomico()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdConsultarSolicitante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarSolicitante.Click

        Try
            pro_ReconsultarCertificacionDeEstratoSocioeconomicoSolicitante()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdConsultarPredio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarPredio.Click

        Try
            pro_ReconsultarCertificacionDeEstratoSocioeconomicoPredio()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdAceptarLibroRadicador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptarCertificacionDeEstrato.Click

        If Me.dgvCONSULTA_CERTESSO.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_CERTESSO(Integer.Parse(Me.dgvCONSULTA_CERTESSO.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtCEESNURA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdAceptarSolicitante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptarSolicitante.Click

        If Me.dgvCONSULTA_CEESSOLI.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_CERTESSO(Integer.Parse(Me.dgvCONSULTA_CEESSOLI.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtCESONUDO.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdAceptarPredio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptarPredio.Click

        If Me.dgvCONSULTA_CEESPRED.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_CERTESSO(Integer.Parse(Me.dgvCONSULTA_CEESPRED.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtCEPRMUNI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiarLibroRadicador.Click
        pro_LimpiarCamposCertificacionDeEstratoSocioeconomico()
        Me.txtCEESNURA.Focus()
    End Sub
    Private Sub cmdLimpiarSolicitante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiarSolicitante.Click
        pro_LimpiarCamposCertificacionDeEstratoSocioeconomicoSolicitante()
        Me.txtCESONUDO.Focus()
    End Sub
    Private Sub cmdLimpiarPredio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiarPredio.Click
        pro_LimpiarCamposCertificacionDeEstratoSocioeconomicoPredio()
        Me.txtCEPRMUNI.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Dim inNroIdRe As New frm_CERTESSO(inID_REGISTRO)
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCamposCertificacionDeEstratoSocioeconomico()
        pro_LimpiarCamposCertificacionDeEstratoSocioeconomicoSolicitante()
        pro_LimpiarCamposCertificacionDeEstratoSocioeconomicoPredio()

    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_consultar_TRABCAMP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.txtCEESNURA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCEESNURA.KeyPress, txtCEESFERA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub


#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEESFERA.GotFocus, txtCEESNURA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptarCertificacionDeEstrato.GotFocus, cmdSalir.GotFocus, cmdConsultarCertificacionDeEstrato.GotFocus, cmdLimpiarLibroRadicador.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtCEPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEPRMUNI.Validated
        If Me.txtCEPRMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtCEPRMUNI.Text) = True Then
            Me.txtCEPRMUNI.Text = fun_Formato_Mascara_3_String(Me.txtCEPRMUNI.Text)
        End If
    End Sub
    Private Sub txtCEPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEPRCORR.Validated
        If Me.txtCEPRCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtCEPRCORR.Text) = True Then
            Me.txtCEPRCORR.Text = fun_Formato_Mascara_2_String(Me.txtCEPRCORR.Text)
        End If
    End Sub
    Private Sub txtCEPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEPRBARR.Validated
        If Me.txtCEPRBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtCEPRBARR.Text) = True Then
            Me.txtCEPRBARR.Text = fun_Formato_Mascara_3_String(Me.txtCEPRBARR.Text)
        End If
    End Sub
    Private Sub txtCEPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEPRMANZ.Validated
        If Me.txtCEPRMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtCEPRMANZ.Text) = True Then
            Me.txtCEPRMANZ.Text = fun_Formato_Mascara_3_String(Me.txtCEPRMANZ.Text)
        End If
    End Sub
    Private Sub txtCEPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEPRPRED.Validated
        If Me.txtCEPRPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtCEPRPRED.Text) = True Then
            Me.txtCEPRPRED.Text = fun_Formato_Mascara_5_String(Me.txtCEPRPRED.Text)
        End If
    End Sub
    Private Sub txtCEPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEPREDIF.Validated
        If Me.txtCEPREDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtCEPREDIF.Text) = True Then
            Me.txtCEPREDIF.Text = fun_Formato_Mascara_3_String(Me.txtCEPREDIF.Text)
        End If
    End Sub
    Private Sub txtCEPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEPRUNPR.Validated
        If Me.txtCEPRUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtCEPRUNPR.Text) = True Then
            Me.txtCEPRUNPR.Text = fun_Formato_Mascara_5_String(Me.txtCEPRUNPR.Text)
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

    Private Sub dgvCONSULTA_CERTESSO_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA_CERTESSO.CellDoubleClick
        Me.cmdAceptarCertificacionDeEstrato.PerformClick()
    End Sub
    Private Sub dgvCONSULTA_CEESSOLI_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA_CEESSOLI.CellDoubleClick
        Me.cmdAceptarSolicitante.PerformClick()
    End Sub
    Private Sub dgvCONSULTA_CEESPRED_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA_CEESPRED.CellDoubleClick
        Me.cmdAceptarPredio.PerformClick()
    End Sub

#End Region

#End Region

End Class