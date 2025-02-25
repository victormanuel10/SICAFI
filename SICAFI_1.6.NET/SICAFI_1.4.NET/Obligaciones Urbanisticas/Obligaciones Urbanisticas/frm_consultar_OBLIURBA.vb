Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_OBLIURBA

    '==========================================
    '*** CONSULTA OBLIGACIONES URBANISTICAS ***
    '==========================================

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

    Private Sub pro_ReconsultarObligacionesUrbanisticas()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de los campos
            Dim stOBURNURE As String = ""
            Dim stOBURFERE As String = ""
            Dim stOBURVIRE As String = ""
            Dim stOBURNULI As String = ""

            ' carga los campos
            If Trim(Me.txtOBURNURE.Text) = "" Then
                stOBURNURE = "%"
            Else
                stOBURNURE = Trim(Me.txtOBURNURE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOBURFERE.Text) = "" Then
                stOBURFERE = "%"
            Else
                stOBURFERE = Trim(Me.txtOBURFERE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOBURVIRE.Text) = "" Then
                stOBURVIRE = "%"
            Else
                stOBURVIRE = Trim(Me.txtOBURVIRE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOBURNULI.Text) = "" Then
                stOBURNULI = "%"
            Else
                stOBURNULI = Trim(Me.txtOBURNULI.Text)
            End If

            ' crea la variable de consulta
            Dim stConsultaSQL As String = ""

            'concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "OBURIDRE, "
            stConsultaSQL += "OBURSECU as 'Nro. Liquidación', "
            stConsultaSQL += "OBURNURE as 'Nro. Radicado', "
            stConsultaSQL += "OBURFERE as 'Fecha de radicado', "
            stConsultaSQL += "CLENDESC as 'Clase de entidad', "
            stConsultaSQL += "OBURVIRE as 'Vigencia radicado', "
            stConsultaSQL += "OBURFEIN as 'Fecha de ingreso', "
            stConsultaSQL += "ESTADESC as 'Estado' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBLIURBA, MANT_CLASENTI, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OBURCLEN = CLENCODI AND "
            stConsultaSQL += "OBURESTA = ESTACODI AND "
            stConsultaSQL += "OBURNURE LIKE '" & stOBURNURE & "' AND "
            stConsultaSQL += "OBURFERE LIKE '" & stOBURFERE & "' AND "
            stConsultaSQL += "OBURVIRE LIKE '" & stOBURVIRE & "' AND "
            stConsultaSQL += "OBURSECU LIKE '" & stOBURNULI & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OBURSECU, OBURNURE, OBURFERE "


            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

            Me.dgvCONSULTA_OBLIURBA.DataSource = dt

            Me.dgvCONSULTA_OBLIURBA.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA_OBLIURBA.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptarOblicacionUrbanistica.Enabled = False
                Me.txtOBURNURE.Focus()
            Else
                Me.cmdAceptarOblicacionUrbanistica.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarObligacionesUrbanisticasSolicitante()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de los campos
            Dim stOUSONUDO As String = ""
            Dim stOUSOPRAP As String = ""
            Dim stOUSOSEAP As String = ""
            Dim stOUSONOMB As String = ""
            Dim stOUSODIRE As String = ""
            Dim stOUSOPROY As String = ""

            ' carga los campos
            If Trim(Me.txtOUSONUDO.Text) = "" Then
                stOUSONUDO = "%"
            Else
                stOUSONUDO = Trim(Me.txtOUSONUDO.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOUSOPRAP.Text) = "" Then
                stOUSOPRAP = "%"
            Else
                stOUSOPRAP = Trim(Me.txtOUSOPRAP.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOUSOSEAP.Text) = "" Then
                stOUSOSEAP = "%"
            Else
                stOUSOSEAP = Trim(Me.txtOUSOSEAP.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOUSONOMB.Text) = "" Then
                stOUSONOMB = "%"
            Else
                stOUSONOMB = Trim(Me.txtOUSONOMB.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOUSODIRE.Text) = "" Then
                stOUSODIRE = "%"
            Else
                stOUSODIRE = Trim(Me.txtOUSODIRE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOUSOPROY.Text) = "" Then
                stOUSOPROY = "%"
            Else
                stOUSOPROY = Trim(Me.txtOUSOPROY.Text)
            End If

            ' crea la variable de consulta
            Dim stConsultaSQL As String = ""

            'concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "OBURIDRE, "
            stConsultaSQL += "OUSONURE as 'Nro. Radicado', "
            stConsultaSQL += "OUSOFERE as 'Fecha de radicado', "
            stConsultaSQL += "CLENDESC as 'Clase de entidad', "
            stConsultaSQL += "OUSONUDO as 'Nro. Documento', "
            stConsultaSQL += "OUSONOMB as 'Nombre(s)', "
            stConsultaSQL += "OUSOPRAP as 'Primer apellido', "
            stConsultaSQL += "OUSOSEAP as 'Segundo apellido', "
            stConsultaSQL += "OUSODIPR as 'Dirección del predio', "
            stConsultaSQL += "OUSOCOPO as 'Proyecto', "
            stConsultaSQL += "ESTADESC as 'Estado' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBLIURBA, OBURSOLI, MANT_CLASENTI, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OBURCLEN = OUSOCLEN AND "
            stConsultaSQL += "OBURNURE = OUSONURE AND "
            stConsultaSQL += "OBURFERE = OUSOFERE AND "
            stConsultaSQL += "OBURSECU = OUSOSECU AND "

            stConsultaSQL += "OBURCLEN = CLENCODI AND "
            stConsultaSQL += "OUSOESTA = ESTACODI AND "

            stConsultaSQL += "OUSONUDO LIKE '" & stOUSONUDO & "' AND "
            stConsultaSQL += "OUSOPRAP LIKE '%" & stOUSOPRAP & "%' AND "
            stConsultaSQL += "OUSOSEAP LIKE '%" & stOUSOSEAP & "%' AND "
            stConsultaSQL += "OUSONOMB LIKE '%" & stOUSONOMB & "%' AND "
            stConsultaSQL += "OUSOCOPO LIKE '%" & stOUSOPROY & "%' AND "
            stConsultaSQL += "OUSODIPR LIKE '%" & stOUSODIRE & "%' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUSONURE, OUSOFERE "


            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

            Me.dgvCONSULTA_OBURSOLI.DataSource = dt

            Me.dgvCONSULTA_OBURSOLI.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA_OBURSOLI.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()

                Me.cmdAceptarSolicitante.Enabled = False
                Me.txtOUSONUDO.Focus()

                Me.strBARRESTA.Items(2).Text = "Registros : " & "0"
            Else
                Me.cmdAceptarSolicitante.Enabled = True

                Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarObligacionesUrbanisticasPredio()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de los campos
            Dim stOUPRMUNI As String = ""
            Dim stOUPRCORR As String = ""
            Dim stOUPRBARR As String = ""
            Dim stOUPRMANZ As String = ""
            Dim stOUPRPRED As String = ""
            Dim stOUPREDIF As String = ""
            Dim stOUPRUNPR As String = ""
            Dim stOUPRCLSE As String = ""
            Dim stOUPRNUFI As String = ""
            Dim stOUPRMAIN As String = ""

            ' carga los campos
            If Trim(Me.txtOUPRMUNI.Text) = "" Then
                stOUPRMUNI = "%"
            Else
                stOUPRMUNI = Trim(Me.txtOUPRMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOUPRCORR.Text) = "" Then
                stOUPRCORR = "%"
            Else
                stOUPRCORR = Trim(Me.txtOUPRCORR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOUPRBARR.Text) = "" Then
                stOUPRBARR = "%"
            Else
                stOUPRBARR = Trim(Me.txtOUPRBARR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOUPRMANZ.Text) = "" Then
                stOUPRMANZ = "%"
            Else
                stOUPRMANZ = Trim(Me.txtOUPRMANZ.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOUPRPRED.Text) = "" Then
                stOUPRPRED = "%"
            Else
                stOUPRPRED = Trim(Me.txtOUPRPRED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOUPREDIF.Text) = "" Then
                stOUPREDIF = "%"
            Else
                stOUPREDIF = Trim(Me.txtOUPREDIF.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOUPRUNPR.Text) = "" Then
                stOUPRUNPR = "%"
            Else
                stOUPRUNPR = Trim(Me.txtOUPRUNPR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOUPRCLSE.Text) = "" Then
                stOUPRCLSE = "%"
            Else
                stOUPRCLSE = Trim(Me.txtOUPRCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOUPRNUFI.Text) = "" Then
                stOUPRNUFI = "%"
            Else
                stOUPRNUFI = Trim(Me.txtOUPRNUFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtOUPRMAIN.Text) = "" Then
                stOUPRMAIN = "%"
            Else
                stOUPRMAIN = Trim(Me.txtOUPRMAIN.Text)
            End If

            ' crea la variable de consulta
            Dim stConsultaSQL As String = ""

            'concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "OBURIDRE, "
            stConsultaSQL += "OUPRNURE as 'Nro. Radicado', "
            stConsultaSQL += "OUPRFERE as 'Fecha de radicado', "
            stConsultaSQL += "CLENDESC as 'Clase de entidad', "
            stConsultaSQL += "OUPRMUNI as 'Municipio', "
            stConsultaSQL += "OUPRCORR as 'Corregi.', "
            stConsultaSQL += "OUPRBARR as 'Barrio', "
            stConsultaSQL += "OUPRMANZ as 'Manzana Vereda', "
            stConsultaSQL += "OUPRPRED as 'Predio', "
            stConsultaSQL += "OUPREDIF as 'Edificio', "
            stConsultaSQL += "OUPRUNPR as 'Unidad predial', "
            stConsultaSQL += "CLSEDESC as 'Sector', "
            stConsultaSQL += "OUPRNUFI as 'Nro. Ficha predial', "
            stConsultaSQL += "OUPRMAIN as 'Matricula inmobiliria', "
            stConsultaSQL += "ESTADESC as 'Estado' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBLIURBA, OBURPRED, MANT_CLASSECT, MANT_CLASENTI, ESTADO "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "OBURCLEN = OUPRCLEN AND "
            stConsultaSQL += "OBURNURE = OUPRNURE AND "
            stConsultaSQL += "OBURFERE = OUPRFERE AND "
            stConsultaSQL += "OBURSECU = OUPRSECU AND "

            stConsultaSQL += "OUPRCLSE = CLSECODI AND "
            stConsultaSQL += "OUPRCLEN = CLENCODI AND "
            stConsultaSQL += "OUPRESTA = ESTACODI AND "

            stConsultaSQL += "OUPRMUNI LIKE '" & stOUPRMUNI & "' AND "
            stConsultaSQL += "OUPRCORR LIKE '" & stOUPRCORR & "' AND "
            stConsultaSQL += "OUPRBARR LIKE '" & stOUPRBARR & "' AND "
            stConsultaSQL += "OUPRMANZ LIKE '" & stOUPRMANZ & "' AND "
            stConsultaSQL += "OUPRPRED LIKE '" & stOUPRPRED & "' AND "
            stConsultaSQL += "OUPREDIF LIKE '" & stOUPREDIF & "' AND "
            stConsultaSQL += "OUPRUNPR LIKE '" & stOUPRUNPR & "' AND "
            stConsultaSQL += "OUPRCLSE LIKE '" & stOUPRCLSE & "' AND "
            stConsultaSQL += "OUPRNUFI LIKE '" & stOUPRNUFI & "' AND "
            stConsultaSQL += "OUPRMAIN LIKE '" & stOUPRMAIN & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUPRNURE, OUPRFERE "


            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

            Me.dgvCONSULTA_OBURPRED.DataSource = dt

            Me.dgvCONSULTA_OBURPRED.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA_OBURPRED.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()

                Me.cmdAceptarPredio.Enabled = False
                Me.txtOBURNURE.Focus()

                Me.strBARRESTA.Items(2).Text = "Registros : " & "0"
            Else
                Me.cmdAceptarPredio.Enabled = True

                Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_LimpiarCamposObligacionesUrbanisticas()

        Me.txtOBURNURE.Text = ""
        Me.txtOBURFERE.Text = ""
        Me.txtOBURVIRE.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA_OBLIURBA.DataSource = New DataTable

        Me.cmdAceptarOblicacionUrbanistica.Enabled = False

    End Sub
    Private Sub pro_LimpiarCamposObligacionesUrbanisticasSolicitante()

        Me.txtOUSONUDO.Text = ""
        Me.txtOUSOPRAP.Text = ""
        Me.txtOUSOSEAP.Text = ""
        Me.txtOUSONOMB.Text = ""
        Me.txtOUSODIRE.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA_OBURSOLI.DataSource = New DataTable

        Me.cmdAceptarSolicitante.Enabled = False

    End Sub
    Private Sub pro_LimpiarCamposObligacionesUrbanisticasPredio()

        Me.txtOUPRMUNI.Text = ""
        Me.txtOUPRCORR.Text = ""
        Me.txtOUPRBARR.Text = ""
        Me.txtOUPRMANZ.Text = ""
        Me.txtOUPRPRED.Text = ""
        Me.txtOUPREDIF.Text = ""
        Me.txtOUPRUNPR.Text = ""
        Me.txtOUPRCLSE.Text = ""
        Me.txtOUPRNUFI.Text = ""
        Me.txtOUPRMAIN.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA_OBURPRED.DataSource = New DataTable

        Me.cmdAceptarPredio.Enabled = False

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdConsultarOblicacionUrbanistica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarOblicacionUrbanistica.Click

        Try
            pro_ReconsultarObligacionesUrbanisticas()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdConsultarSolicitante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarSolicitante.Click

        Try
            pro_ReconsultarObligacionesUrbanisticasSolicitante()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdConsultarPredio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarPredio.Click

        Try
            pro_ReconsultarObligacionesUrbanisticasPredio()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub cmdAceptarOblicacionUrbanistica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptarOblicacionUrbanistica.Click

        If Me.dgvCONSULTA_OBLIURBA.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_OBLIURBA(Integer.Parse(Me.dgvCONSULTA_OBLIURBA.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtOBURNURE.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdAceptarSolicitante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptarSolicitante.Click

        If Me.dgvCONSULTA_OBURSOLI.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_OBLIURBA(Integer.Parse(Me.dgvCONSULTA_OBURSOLI.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtOUSONUDO.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdAceptarPredio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptarPredio.Click

        If Me.dgvCONSULTA_OBURPRED.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_OBLIURBA(Integer.Parse(Me.dgvCONSULTA_OBURPRED.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtOUPRMUNI.Focus()
            Me.Close()
        End If

    End Sub

    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiarOblicacionUrbanistica.Click
        pro_LimpiarCamposObligacionesUrbanisticas()
        Me.txtOBURNURE.Focus()
    End Sub
    Private Sub cmdLimpiarSolicitante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiarSolicitante.Click
        pro_LimpiarCamposObligacionesUrbanisticasSolicitante()
        Me.txtOUSONUDO.Focus()
    End Sub
    Private Sub cmdLimpiarPredio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiarPredio.Click
        pro_LimpiarCamposObligacionesUrbanisticasPredio()
        Me.txtOUPRMUNI.Focus()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Dim inNroIdRe As New frm_OBLIURBA(inID_REGISTRO)
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCamposObligacionesUrbanisticas()
        pro_LimpiarCamposObligacionesUrbanisticasSolicitante()
        pro_LimpiarCamposObligacionesUrbanisticasPredio()

    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_consultar_TRABCAMP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.txtOBURNURE.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOBURNURE.KeyPress, txtOBURFERE.KeyPress, txtOBURVIRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub


#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOBURFERE.GotFocus, txtOBURNURE.GotFocus, txtOBURVIRE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptarOblicacionUrbanistica.GotFocus, cmdSalir.GotFocus, cmdConsultarOblicacionUrbanistica.GotFocus, cmdLimpiarOblicacionUrbanistica.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtOUPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUPRMUNI.Validated
        If Me.txtOUPRMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUPRMUNI.Text) = True Then
            Me.txtOUPRMUNI.Text = fun_Formato_Mascara_3_String(Me.txtOUPRMUNI.Text)
        End If
    End Sub
    Private Sub txtOUPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUPRCORR.Validated
        If Me.txtOUPRCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUPRCORR.Text) = True Then
            Me.txtOUPRCORR.Text = fun_Formato_Mascara_2_String(Me.txtOUPRCORR.Text)
        End If
    End Sub
    Private Sub txtOUPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUPRBARR.Validated
        If Me.txtOUPRBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUPRBARR.Text) = True Then
            Me.txtOUPRBARR.Text = fun_Formato_Mascara_3_String(Me.txtOUPRBARR.Text)
        End If
    End Sub
    Private Sub txtOUPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUPRMANZ.Validated
        If Me.txtOUPRMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUPRMANZ.Text) = True Then
            Me.txtOUPRMANZ.Text = fun_Formato_Mascara_3_String(Me.txtOUPRMANZ.Text)
        End If
    End Sub
    Private Sub txtOUPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUPRPRED.Validated
        If Me.txtOUPRPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUPRPRED.Text) = True Then
            Me.txtOUPRPRED.Text = fun_Formato_Mascara_5_String(Me.txtOUPRPRED.Text)
        End If
    End Sub
    Private Sub txtOUPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUPREDIF.Validated
        If Me.txtOUPREDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUPREDIF.Text) = True Then
            Me.txtOUPREDIF.Text = fun_Formato_Mascara_3_String(Me.txtOUPREDIF.Text)
        End If
    End Sub
    Private Sub txtOUPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUPRUNPR.Validated
        If Me.txtOUPRUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUPRUNPR.Text) = True Then
            Me.txtOUPRUNPR.Text = fun_Formato_Mascara_5_String(Me.txtOUPRUNPR.Text)
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

    Private Sub dgvCONSULTA_OBLIURBA_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA_OBLIURBA.CellDoubleClick
        Me.cmdAceptarOblicacionUrbanistica.PerformClick()
    End Sub
    Private Sub dgvCONSULTA_OBURSOLI_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA_OBURSOLI.CellDoubleClick
        Me.cmdAceptarSolicitante.PerformClick()
    End Sub
    Private Sub dgvCONSULTA_OBURPRED_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA_OBURPRED.CellDoubleClick
        Me.cmdAceptarPredio.PerformClick()
    End Sub

#End Region

#End Region

End Class