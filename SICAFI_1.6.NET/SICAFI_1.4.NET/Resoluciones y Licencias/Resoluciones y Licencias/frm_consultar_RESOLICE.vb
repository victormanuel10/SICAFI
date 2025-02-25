Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_RESOLICE

    '=========================================
    '*** CONSULTA RESOLUCIONES Y LICENCIAS ***
    '=========================================

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

    Private Sub pro_ReconsultarResolucionesyLicencias()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de los campos
            Dim stRELINURA As String = ""
            Dim stRELIFERA As String = ""
            Dim stRELIVIGE As String = ""
            Dim stRELIMAIN As String = ""

            ' carga los campos
            If Trim(Me.txtRELINURA.Text) = "" Then
                stRELINURA = "%"
            Else
                stRELINURA = Trim(Me.txtRELINURA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRELIFERA.Text) = "" Then
                stRELIFERA = "%"
            Else
                stRELIFERA = Trim(Me.txtRELIFERA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRELIVIGE.Text) = "" Then
                stRELIVIGE = "%"
            Else
                stRELIVIGE = Trim(Me.txtRELIVIGE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRELIMAIN.Text) = "" Then
                stRELIMAIN = "%"
            Else
                stRELIMAIN = Trim(Me.txtRELIMAIN.Text)
            End If

            ' crea la variable de consulta
            Dim stConsultaSQL As String = ""

            'concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "RELIIDRE, "
            stConsultaSQL += "RELINURA as 'Nro. Resolución', "
            stConsultaSQL += "RELIFERA as 'Fecha de resolución', "
            stConsultaSQL += "CLENDESC as 'Clase de entidad', "
            stConsultaSQL += "RELIVIGE as 'Vigencia', "
            stConsultaSQL += "RELIMAIN as 'Matricula inmobiliaria', "
            stConsultaSQL += "RELIFEAS as 'Fechas de asignación', "
            stConsultaSQL += "RELIFEIN as 'Fecha de ingreso', "
            stConsultaSQL += "ESTADESC as 'Estado' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOLICE, MANT_CLASENTI, VIGENCIA, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RELICLEN = CLENCODI AND "
            stConsultaSQL += "RELIVIGE = VIGECODI AND "
            stConsultaSQL += "RELIESTA = ESTACODI AND "
            stConsultaSQL += "RELINURA LIKE '" & stRELINURA & "' AND "
            stConsultaSQL += "RELIFERA LIKE '" & stRELIFERA & "' AND "
            stConsultaSQL += "RELIVIGE LIKE '" & stRELIVIGE & "' AND "
            stConsultaSQL += "RELIMAIN LIKE '" & stRELIMAIN & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RELINURA, RELIFERA "


            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

            Me.dgvCONSULTA_RESOLICE.DataSource = dt

            Me.dgvCONSULTA_RESOLICE.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA_RESOLICE.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptarLibroRadicador.Enabled = False
                Me.txtRELINURA.Focus()
            Else
                Me.cmdAceptarLibroRadicador.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarResolucionesyLicenciasSolicitante()

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
            If Trim(Me.txtRLSONUDO.Text) = "" Then
                stLRSONUDO = "%"
            Else
                stLRSONUDO = Trim(Me.txtRLSONUDO.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRLSOPRAP.Text) = "" Then
                stLRSOPRAP = "%"
            Else
                stLRSOPRAP = Trim(Me.txtRLSOPRAP.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRLSOSEAP.Text) = "" Then
                stLRSOSEAP = "%"
            Else
                stLRSOSEAP = Trim(Me.txtRLSOSEAP.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRLSONOMB.Text) = "" Then
                stLRSONOMB = "%"
            Else
                stLRSONOMB = Trim(Me.txtRLSONOMB.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRLSODIRE.Text) = "" Then
                stLRSODIRE = "%"
            Else
                stLRSODIRE = Trim(Me.txtRLSODIRE.Text)
            End If

            ' crea la variable de consulta
            Dim stConsultaSQL As String = ""

            'concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "RELIIDRE, "
            stConsultaSQL += "RLSONURA as 'Nro. Resolución', "
            stConsultaSQL += "RLSOFERA as 'Fecha de resolución', "
            stConsultaSQL += "RLSONUDO as 'Nro. Documento', "
            stConsultaSQL += "RLSONOMB as 'Nombre(s)', "
            stConsultaSQL += "RLSOPRAP as 'Primer apellido', "
            stConsultaSQL += "RLSOSEAP as 'Segundo apellido', "
            stConsultaSQL += "RLSODIPR as 'Dirección del predio' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOLICE, RELISOLI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RELINURA = RLSONURA AND "
            stConsultaSQL += "RELIFERA = RLSOFERA AND "
            stConsultaSQL += "RELISECU = RLSOSECU AND "

            stConsultaSQL += "RLSONUDO LIKE '" & stLRSONUDO & "' AND "
            stConsultaSQL += "RLSOPRAP LIKE '" & stLRSOPRAP & "' AND "
            stConsultaSQL += "RLSOSEAP LIKE '" & stLRSOSEAP & "' AND "
            stConsultaSQL += "RLSONOMB LIKE '" & stLRSONOMB & "' AND "
            stConsultaSQL += "RLSODIPR LIKE '" & stLRSODIRE & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RLSONURA, RLSOFERA "


            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

            Me.dgvCONSULTA_RELISOLI.DataSource = dt

            Me.dgvCONSULTA_RELISOLI.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA_RELISOLI.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()

                Me.cmdAceptarSolicitante.Enabled = False
                Me.txtRLSONUDO.Focus()

                Me.strBARRESTA.Items(2).Text = "Registros : " & "0"
            Else
                Me.cmdAceptarSolicitante.Enabled = True

                Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarResolucionesyLicenciasPredio()

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
            If Trim(Me.txtRLPRMUNI.Text) = "" Then
                stLRPRMUNI = "%"
            Else
                stLRPRMUNI = Trim(Me.txtRLPRMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRLPRCORR.Text) = "" Then
                stLRPRCORR = "%"
            Else
                stLRPRCORR = Trim(Me.txtRLPRCORR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRLPRBARR.Text) = "" Then
                stLRPRBARR = "%"
            Else
                stLRPRBARR = Trim(Me.txtRLPRBARR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRLPRMANZ.Text) = "" Then
                stLRPRMANZ = "%"
            Else
                stLRPRMANZ = Trim(Me.txtRLPRMANZ.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRLPRPRED.Text) = "" Then
                stLRPRPRED = "%"
            Else
                stLRPRPRED = Trim(Me.txtRLPRPRED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRLPREDIF.Text) = "" Then
                stLRPREDIF = "%"
            Else
                stLRPREDIF = Trim(Me.txtRLPREDIF.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRLPRUNPR.Text) = "" Then
                stLRPRUNPR = "%"
            Else
                stLRPRUNPR = Trim(Me.txtRLPRUNPR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRLPRCLSE.Text) = "" Then
                stLRPRCLSE = "%"
            Else
                stLRPRCLSE = Trim(Me.txtRLPRCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRLPRNUFI.Text) = "" Then
                stLRPRNUFI = "%"
            Else
                stLRPRNUFI = Trim(Me.txtRLPRNUFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRLPRMAIN.Text) = "" Then
                stLRPRMAIN = "%"
            Else
                stLRPRMAIN = Trim(Me.txtRLPRMAIN.Text)
            End If

            ' crea la variable de consulta
            Dim stConsultaSQL As String = ""

            'concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "RELIIDRE, "
            stConsultaSQL += "RLPRNURA as 'Nro. Resolución', "
            stConsultaSQL += "RLPRFERA as 'Fecha de resolución', "
            stConsultaSQL += "RLPRMUNI as 'Municipio', "
            stConsultaSQL += "RLPRCORR as 'Corregi.', "
            stConsultaSQL += "RLPRBARR as 'Barrio', "
            stConsultaSQL += "RLPRMANZ as 'Manzana Vereda', "
            stConsultaSQL += "RLPRPRED as 'Predio', "
            stConsultaSQL += "RLPREDIF as 'Edificio', "
            stConsultaSQL += "RLPRUNPR as 'Unidad predial', "
            stConsultaSQL += "CLSEDESC as 'Sector', "
            stConsultaSQL += "RLPRNUFI as 'Nro. Ficha predial', "
            stConsultaSQL += "RLPRMAIN as 'Matricula' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOLICE, RELIPRED, MANT_CLASSECT "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "RELINURA = RLPRNURA AND "
            stConsultaSQL += "RELIFERA = RLPRFERA AND "
            stConsultaSQL += "RELISECU = RLPRSECU AND "

            stConsultaSQL += "RLPRCLSE = CLSECODI AND "

            stConsultaSQL += "RLPRMUNI LIKE '" & stLRPRMUNI & "' AND "
            stConsultaSQL += "RLPRCORR LIKE '" & stLRPRCORR & "' AND "
            stConsultaSQL += "RLPRBARR LIKE '" & stLRPRBARR & "' AND "
            stConsultaSQL += "RLPRMANZ LIKE '" & stLRPRMANZ & "' AND "
            stConsultaSQL += "RLPRPRED LIKE '" & stLRPRPRED & "' AND "
            stConsultaSQL += "RLPREDIF LIKE '" & stLRPREDIF & "' AND "
            stConsultaSQL += "RLPRUNPR LIKE '" & stLRPRUNPR & "' AND "
            stConsultaSQL += "RLPRCLSE LIKE '" & stLRPRCLSE & "' AND "
            stConsultaSQL += "RLPRNUFI LIKE '" & stLRPRNUFI & "' AND "
            stConsultaSQL += "RLPRMAIN LIKE '" & stLRPRMAIN & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RLPRNURA, RLPRFERA "


            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

            Me.dgvCONSULTA_RELIPRED.DataSource = dt

            Me.dgvCONSULTA_RELIPRED.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA_RELIPRED.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()

                Me.cmdAceptarPredio.Enabled = False
                Me.txtRELINURA.Focus()

                Me.strBARRESTA.Items(2).Text = "Registros : " & "0"
            Else
                Me.cmdAceptarPredio.Enabled = True

                Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarResolucionesyLicenciasPropietario()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de los campos
            Dim stLRPRNUDO As String = ""
            Dim stLRPRPRAP As String = ""
            Dim stLRPRSEAP As String = ""
            Dim stLRPRNOMB As String = ""
            Dim stLRPRDERE As String = ""

            ' carga los campos
            If Trim(Me.txtRLPRNUDO.Text) = "" Then
                stLRPRNUDO = "%"
            Else
                stLRPRNUDO = Trim(Me.txtRLPRNUDO.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRLPRPRAP.Text) = "" Then
                stLRPRPRAP = "%"
            Else
                stLRPRPRAP = Trim(Me.txtRLPRPRAP.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRLPRSEAP.Text) = "" Then
                stLRPRSEAP = "%"
            Else
                stLRPRSEAP = Trim(Me.txtRLPRSEAP.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRLPRNOMB.Text) = "" Then
                stLRPRNOMB = "%"
            Else
                stLRPRNOMB = Trim(Me.txtRLPRNOMB.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRLPRDERE.Text) = "" Then
                stLRPRDERE = "%"
            Else
                stLRPRDERE = Trim(Me.txtRLPRDERE.Text)
            End If

            ' crea la variable de consulta
            Dim stConsultaSQL As String = ""

            'concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "RELIIDRE, "
            stConsultaSQL += "RLPRNURA as 'Nro. Resolución', "
            stConsultaSQL += "RLPRFERA as 'Fecha de resolución', "
            stConsultaSQL += "RLPRNUDO as 'Nro. Documento', "
            stConsultaSQL += "RLPRNOMB as 'Nombre(s)', "
            stConsultaSQL += "RLPRPRAP as 'Primer apellido', "
            stConsultaSQL += "RLPRSEAP as 'Segundo apellido', "
            stConsultaSQL += "RLPRDERE as 'Derecho' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOLICE, RELIPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RELINURA = RLPRNURA AND "
            stConsultaSQL += "RELIFERA = RLPRFERA AND "
            stConsultaSQL += "RELISECU = RLPRSECU AND "

            stConsultaSQL += "RLPRNUDO LIKE '" & stLRPRNUDO & "' AND "
            stConsultaSQL += "RLPRPRAP LIKE '" & stLRPRPRAP & "' AND "
            stConsultaSQL += "RLPRSEAP LIKE '" & stLRPRSEAP & "' AND "
            stConsultaSQL += "RLPRNOMB LIKE '" & stLRPRNOMB & "' AND "
            stConsultaSQL += "RLPRDERE LIKE '" & stLRPRDERE & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RLPRNURA, RLPRFERA "


            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

            Me.dgvCONSULTA_RELIPROP.DataSource = dt

            Me.dgvCONSULTA_RELIPROP.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA_RELIPROP.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()

                Me.cmdAceptarPropietario.Enabled = False
                Me.txtRLSONUDO.Focus()

                Me.strBARRESTA.Items(2).Text = "Registros : " & "0"
            Else
                Me.cmdAceptarPropietario.Enabled = True

                Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_LimpiarCamposResolucionesyLicencias()

        Me.txtRELINURA.Text = ""
        Me.txtRELIFERA.Text = ""
        Me.txtRELIVIGE.Text = ""
        Me.txtRELIMAIN.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA_RESOLICE.DataSource = New DataTable

        Me.cmdAceptarLibroRadicador.Enabled = False

    End Sub
    Private Sub pro_LimpiarCamposResolucionesyLicenciasSolicitante()

        Me.txtRLSONUDO.Text = ""
        Me.txtRLSOPRAP.Text = ""
        Me.txtRLSOSEAP.Text = ""
        Me.txtRLSONOMB.Text = ""
        Me.txtRLSODIRE.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA_RELISOLI.DataSource = New DataTable

        Me.cmdAceptarSolicitante.Enabled = False

    End Sub
    Private Sub pro_LimpiarCamposResolucionesyLicenciasPredio()

        Me.txtRLPRMUNI.Text = ""
        Me.txtRLPRCORR.Text = ""
        Me.txtRLPRBARR.Text = ""
        Me.txtRLPRMANZ.Text = ""
        Me.txtRLPRPRED.Text = ""
        Me.txtRLPREDIF.Text = ""
        Me.txtRLPRUNPR.Text = ""
        Me.txtRLPRCLSE.Text = ""
        Me.txtRLPRNUFI.Text = ""
        Me.txtRLPRMAIN.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA_RELIPRED.DataSource = New DataTable

        Me.cmdAceptarPredio.Enabled = False

    End Sub
    Private Sub pro_LimpiarCamposResolucionesyLicenciasPropietario()

        Me.txtRLPRNUDO.Text = ""
        Me.txtRLPRPRAP.Text = ""
        Me.txtRLPRSEAP.Text = ""
        Me.txtRLPRNOMB.Text = ""
        Me.txtRLPRDERE.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA_RELIPROP.DataSource = New DataTable

        Me.cmdAceptarPropietario.Enabled = False

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdConsultarLibroRadicador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarLibroRadicador.Click

        Try
            pro_ReconsultarResolucionesyLicencias()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdConsultarSolicitante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarSolicitante.Click

        Try
            pro_ReconsultarResolucionesyLicenciasSolicitante()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdConsultarPredio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarPredio.Click

        Try
            pro_ReconsultarResolucionesyLicenciasPredio()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdConsultarPropietario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarPropietario.Click

        Try
            pro_ReconsultarResolucionesyLicenciasPropietario()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub cmdAceptarLibroRadicador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptarLibroRadicador.Click

        If Me.dgvCONSULTA_RESOLICE.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_RESOLICE(Integer.Parse(Me.dgvCONSULTA_RESOLICE.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtRELINURA.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdAceptarSolicitante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptarSolicitante.Click

        If Me.dgvCONSULTA_RELISOLI.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_RESOLICE(Integer.Parse(Me.dgvCONSULTA_RELISOLI.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtRLSONUDO.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdAceptarPredio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptarPredio.Click

        If Me.dgvCONSULTA_RELIPRED.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_RESOLICE(Integer.Parse(Me.dgvCONSULTA_RELIPRED.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtRLPRMUNI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdAceptarPropietario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptarPropietario.Click

        If Me.dgvCONSULTA_RELIPROP.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_RESOLICE(Integer.Parse(Me.dgvCONSULTA_RELIPROP.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtRLPRNUDO.Focus()
            Me.Close()
        End If

    End Sub

    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiarLibroRadicador.Click
        pro_LimpiarCamposResolucionesyLicencias()
        Me.txtRELINURA.Focus()
    End Sub
    Private Sub cmdLimpiarSolicitante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiarSolicitante.Click
        pro_LimpiarCamposResolucionesyLicenciasSolicitante()
        Me.txtRLSONUDO.Focus()
    End Sub
    Private Sub cmdLimpiarPredio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiarPredio.Click
        pro_LimpiarCamposResolucionesyLicenciasPredio()
        Me.txtRLPRMUNI.Focus()
    End Sub
    Private Sub cmdLimpiarPropietario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiarPropietario.Click
        pro_LimpiarCamposResolucionesyLicenciasPropietario()
        Me.txtRLPRNUDO.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Dim inNroIdRe As New frm_RESOLICE(inID_REGISTRO)
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCamposResolucionesyLicencias()
        pro_LimpiarCamposResolucionesyLicenciasSolicitante()
        pro_LimpiarCamposResolucionesyLicenciasPredio()

    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_consultar_TRABCAMP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.txtRELINURA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRELINURA.KeyPress, txtRELIFERA.KeyPress, txtRELIVIGE.KeyPress, txtRELIMAIN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub


#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRELIFERA.GotFocus, txtRELINURA.GotFocus, txtRELIVIGE.GotFocus, txtRELIMAIN.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptarLibroRadicador.GotFocus, cmdSalir.GotFocus, cmdConsultarLibroRadicador.GotFocus, cmdLimpiarLibroRadicador.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtLRPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRLPRMUNI.Validated
        If Me.txtRLPRMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRLPRMUNI.Text) = True Then
            Me.txtRLPRMUNI.Text = fun_Formato_Mascara_3_String(Me.txtRLPRMUNI.Text)
        End If
    End Sub
    Private Sub txtLRPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRLPRCORR.Validated
        If Me.txtRLPRCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRLPRCORR.Text) = True Then
            Me.txtRLPRCORR.Text = fun_Formato_Mascara_2_String(Me.txtRLPRCORR.Text)
        End If
    End Sub
    Private Sub txtLRPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRLPRBARR.Validated
        If Me.txtRLPRBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRLPRBARR.Text) = True Then
            Me.txtRLPRBARR.Text = fun_Formato_Mascara_3_String(Me.txtRLPRBARR.Text)
        End If
    End Sub
    Private Sub txtLRPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRLPRMANZ.Validated
        If Me.txtRLPRMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRLPRMANZ.Text) = True Then
            Me.txtRLPRMANZ.Text = fun_Formato_Mascara_3_String(Me.txtRLPRMANZ.Text)
        End If
    End Sub
    Private Sub txtLRPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRLPRPRED.Validated
        If Me.txtRLPRPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRLPRPRED.Text) = True Then
            Me.txtRLPRPRED.Text = fun_Formato_Mascara_5_String(Me.txtRLPRPRED.Text)
        End If
    End Sub
    Private Sub txtLRPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRLPREDIF.Validated
        If Me.txtRLPREDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRLPREDIF.Text) = True Then
            Me.txtRLPREDIF.Text = fun_Formato_Mascara_3_String(Me.txtRLPREDIF.Text)
        End If
    End Sub
    Private Sub txtLRPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRLPRUNPR.Validated
        If Me.txtRLPRUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRLPRUNPR.Text) = True Then
            Me.txtRLPRUNPR.Text = fun_Formato_Mascara_5_String(Me.txtRLPRUNPR.Text)
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

    Private Sub dgvCONSULTA_RESOLICE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA_RESOLICE.CellDoubleClick
        Me.cmdAceptarLibroRadicador.PerformClick()
    End Sub
    Private Sub dgvCONSULTA_RELISOLI_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA_RELISOLI.CellDoubleClick
        Me.cmdAceptarSolicitante.PerformClick()
    End Sub
    Private Sub dgvCONSULTA_RELIPRED_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA_RELIPRED.CellDoubleClick
        Me.cmdAceptarPredio.PerformClick()
    End Sub
    Private Sub dgvCONSULTA_RELIPROP_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA_RELIPROP.CellDoubleClick
        Me.cmdAceptarPropietario.PerformClick()
    End Sub

#End Region

#End Region

End Class