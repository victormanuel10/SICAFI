Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_RECOPRSE

    '===================================
    '*** INSERTAR PREDIOS SEGREGADOS ***
    '===================================

#Region "VARIABLE"

    Dim vl_inRECOSECU As Integer
    Dim vl_inRECONURE As Integer
    Dim vl_stRECOFERE As String = ""

    Dim dt As DataTable

#End Region

#Region "CONSTRUCTOR"

    Public Sub New()

        InitializeComponent()

    End Sub
    Public Sub New(ByVal inSECU As Integer, ByVal inNURE As Integer, ByVal stFERE As String)
        vl_inRECOSECU = inSECU
        vl_inRECONURE = inNURE
        vl_stRECOFERE = stFERE

        InitializeComponent()
        pro_LimpiarCampos()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtRCPSMUNI.Text = "266"
        Me.txtRCPSCORR.Text = "01"
        Me.txtRCPSBARR.Text = ""
        Me.txtRCPSMANZ.Text = ""
        Me.txtRCPSPRED.Text = ""
        Me.txtRCPSEDIF.Text = ""
        Me.txtRCPSUNPR.Text = ""
        Me.txtRCPSNUFI.Text = ""
        Me.txtRCPSMAIN.Text = ""

        Me.cboRCPSCLSE.DataSource = New DataTable
        Me.cboRCPSESTA.DataSource = New DataTable

        Me.dgvRECOPRRE.DataSource = New DataTable

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub
    Private Sub pro_ConsultaDePredios()

        Try
            ' instancia un dt
            dt = New DataTable

            ' declara las variables
            Dim stRCPSMUNI As String = ""
            Dim stRCPSCORR As String = ""
            Dim stRCPSBARR As String = ""
            Dim stRCPSMANZ As String = ""
            Dim stRCPSPRED As String = ""
            Dim stRCPSEDIF As String = ""
            Dim stRCPSUNPR As String = ""
            Dim stRCPSDIRE As String = ""
            Dim stRCPSNUFI As String = ""
            Dim stRCPSMAIN As String = ""
            Dim stRCPSCLSE As String = ""
            Dim stRCPSESTA As String = ""

            ' carga los campos
            If Trim(Me.txtRCPSMUNI.Text) = "" Then
                stRCPSMUNI = "%"
            Else
                stRCPSMUNI = Trim(Me.txtRCPSMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPSCORR.Text) = "" Then
                stRCPSCORR = "%"
            Else
                stRCPSCORR = Trim(Me.txtRCPSCORR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPSBARR.Text) = "" Then
                stRCPSBARR = "%"
            Else
                stRCPSBARR = Trim(Me.txtRCPSBARR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPSMANZ.Text) = "" Then
                stRCPSMANZ = "%"
            Else
                stRCPSMANZ = Trim(Me.txtRCPSMANZ.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPSPRED.Text) = "" Then
                stRCPSPRED = "%"
            Else
                stRCPSPRED = Trim(Me.txtRCPSPRED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPSEDIF.Text) = "" Then
                stRCPSEDIF = "%"
            Else
                stRCPSEDIF = Trim(Me.txtRCPSEDIF.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPSUNPR.Text) = "" Then
                stRCPSUNPR = "%"
            Else
                stRCPSUNPR = Trim(Me.txtRCPSUNPR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPSDIRE.Text) = "" Then
                stRCPSDIRE = "%"
            Else
                stRCPSDIRE = Trim(Me.txtRCPSDIRE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPSNUFI.Text) = "" Then
                stRCPSNUFI = "%"
            Else
                stRCPSNUFI = Trim(Me.txtRCPSNUFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPSMAIN.Text) = "" Then
                stRCPSMAIN = "%"
            Else
                stRCPSMAIN = Trim(Me.txtRCPSMAIN.Text)
            End If

            ' carga los campos
            If Trim(Me.cboRCPSCLSE.Text) = "" Then
                stRCPSCLSE = "%"
            Else
                stRCPSCLSE = Trim(Me.cboRCPSCLSE.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.cboRCPSESTA.Text) = "" Then
                stRCPSESTA = "%"
            Else
                stRCPSESTA = Trim(Me.cboRCPSESTA.SelectedValue)
            End If

            ' crea la variable de consulta
            Dim stConsultaSQL As String = ""

            'concatena la consulta
            stConsultaSQL += "Select DISTINCT "
            stConsultaSQL += "FIPRDEPA as 'Departamento', "
            stConsultaSQL += "FIPRNUFI as 'Nro. Ficha', "
            stConsultaSQL += "FIPRMUNI as 'Municipio', "
            stConsultaSQL += "FIPRCORR as 'Correg.', "
            stConsultaSQL += "FIPRBARR as 'Barrio', "
            stConsultaSQL += "FIPRMANZ as 'Manzana - Vereda', "
            stConsultaSQL += "FIPRPRED as 'Predio', "
            stConsultaSQL += "FIPREDIF as 'Edificio', "
            stConsultaSQL += "FIPRUNPR as 'Unidad', "
            stConsultaSQL += "FIPRCLSE as 'Sector', "
            stConsultaSQL += "FIPRDIRE as 'Direccion', "
            stConsultaSQL += "FPPRMAIN as 'Matricula', "
            stConsultaSQL += "FIPRESTA as 'Estado' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FICHPRED, FIPRPROP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FIPRNUFI = FPPRNUFI AND "
            stConsultaSQL += "FIPRESTA = 'ac' AND "
            stConsultaSQL += "FPPRESTA = 'ac' AND "
            stConsultaSQL += "FIPRTIFI = '0' AND "
            stConsultaSQL += "FIPRMUNI LIKE '" & Trim(stRCPSMUNI) & "' AND "
            stConsultaSQL += "FIPRCORR LIKE '" & Trim(stRCPSCORR) & "' AND "
            stConsultaSQL += "FIPRBARR LIKE '" & Trim(stRCPSBARR) & "' AND "
            stConsultaSQL += "FIPRMANZ LIKE '" & Trim(stRCPSMANZ) & "' AND "
            stConsultaSQL += "FIPRPRED LIKE '" & Trim(stRCPSPRED) & "' AND "
            stConsultaSQL += "FIPREDIF LIKE '" & Trim(stRCPSEDIF) & "' AND "
            stConsultaSQL += "FIPRUNPR LIKE '" & Trim(stRCPSUNPR) & "' AND "
            stConsultaSQL += "FIPRDIRE LIKE '" & Trim(stRCPSDIRE) & "' AND "
            stConsultaSQL += "FIPRCLSE LIKE '" & Trim(stRCPSCLSE) & "' AND "
            stConsultaSQL += "FPPRNUFI LIKE '" & Trim(stRCPSNUFI) & "' AND "
            stConsultaSQL += "FPPRMAIN LIKE '" & Trim(stRCPSMAIN) & "' AND "
            stConsultaSQL += "FIPRESTA LIKE '" & Trim(stRCPSESTA) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FIPRMUNI, FIPRCORR, FIPRBARR, FIPRMANZ, FIPRPRED, FIPREDIF, FIPRUNPR  "


            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

            ' cuenta los registros
            If dt.Rows.Count > 0 Then
                ' controla la sobregarga del datagridview
                If MessageBox.Show("Nro. de registros consultados :  " & dt.Rows.Count & Chr(Keys.Enter) & Chr(Keys.Enter) & _
                                   "¿ Desea continuar ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    ' llena el datagridview
                    Me.dgvRECOPRRE.DataSource = dt
                    Me.dgvRECOPRRE.Columns(0).Visible = False
                Else
                    ' sale del proceso de consulta
                    Exit Sub
                End If

                ' verifica si existen datos consultados
                If Me.dgvRECOPRRE.RowCount = 0 Then
                    mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                    Me.txtRCPSMUNI.Focus()
                Else
                    mod_MENSAJE.Proceso_Termino_Correctamente()
                End If

            Else
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' verica los datos consultados
            If Me.dgvRECOPRRE.RowCount > 0 Then

                ' declara la variable
                Dim dtRESOCONS As New DataTable

                ' pasa los datos
                dtRESOCONS = Me.dgvRECOPRRE.DataSource

                If dtRESOCONS.Rows.Count > 0 Then

                    ' declara la variable
                    Dim i As Integer = 0

                    For i = 0 To dtRESOCONS.Rows.Count - 1

                        ' declara la variable
                        Dim inRECOSECU As Integer = vl_inRECOSECU
                        Dim inRECONURE As Integer = vl_inRECONURE
                        Dim stRECOFERE As String = vl_stRECOFERE
                        Dim stFIPRDEPA As String = CStr(Trim(dtRESOCONS.Rows(i).Item(0)))
                        Dim inFIPRNUFI As Integer = CInt(Trim(dtRESOCONS.Rows(i).Item(1)))
                        Dim stFIPRMUNI As String = CStr(Trim(dtRESOCONS.Rows(i).Item(2)))
                        Dim stFIPRCORR As String = CStr(Trim(dtRESOCONS.Rows(i).Item(3)))
                        Dim stFIPRBARR As String = CStr(Trim(dtRESOCONS.Rows(i).Item(4)))
                        Dim stFIPRMANZ As String = CStr(Trim(dtRESOCONS.Rows(i).Item(5)))
                        Dim stFIPRPRED As String = CStr(Trim(dtRESOCONS.Rows(i).Item(6)))
                        Dim stFIPREDIF As String = CStr(Trim(dtRESOCONS.Rows(i).Item(7)))
                        Dim stFIPRUNPR As String = CStr(Trim(dtRESOCONS.Rows(i).Item(8)))
                        Dim inFIPRCLSE As Integer = CInt(Trim(dtRESOCONS.Rows(i).Item(9)))
                        Dim stFIPRDIRE As String = CStr(Trim(dtRESOCONS.Rows(i).Item(10)))
                        Dim stFIPRMAIN As String = CStr(Trim(dtRESOCONS.Rows(i).Item(11)))
                        Dim stFIPRESTA As String = CStr(Trim(dtRESOCONS.Rows(i).Item(12)))

                        ' instancia la clase
                        Dim obRECOPRSE As New cla_RECOPRSE
                        Dim dtRECOPRSE As New DataTable

                        dtRECOPRSE = obRECOPRSE.fun_Buscar_CODIGO_X_RECOPRSE(inRECONURE, stRECOFERE, inFIPRNUFI)

                        ' verifica los registros
                        If dtRECOPRSE.Rows.Count = 0 Then

                            ' inserta registro
                            obRECOPRSE.fun_Insertar_RECOPRSE(inRECOSECU, _
                                                             inRECONURE, _
                                                             stRECOFERE, _
                                                             inFIPRNUFI, _
                                                             stFIPRMUNI, _
                                                             stFIPRCORR, _
                                                             stFIPRBARR, _
                                                             stFIPRMANZ, _
                                                             stFIPRPRED, _
                                                             stFIPREDIF, _
                                                             stFIPRUNPR, _
                                                             inFIPRCLSE, _
                                                             stFIPRDIRE, _
                                                             stFIPRMAIN, _
                                                             stFIPRESTA)

                        End If

                    Next

                    ' limpia la consulta
                    Me.dgvRECOPRRE.DataSource = New DataTable

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                End If

                ' ingreso de registro individual
            ElseIf Me.dgvRECOPRRE.RowCount = 0 Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                ' verifica los campos
                Dim boRECOMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPSMUNI)
                Dim boRECOCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPSCORR)
                Dim boRECOBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPSBARR)
                Dim boRECOMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPSMANZ)
                Dim boRECOPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPSPRED)
                Dim boRECOEDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPSEDIF)
                Dim boRECOUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPSUNPR)
                Dim boRECOCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRCPSCLSE)
                Dim boRECOESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRCPSESTA)
                Dim boRECONUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPSNUFI)
                Dim boRECOMAIN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRCPSMAIN)

                ' valida los campos
                If boRECOMUNI = True And _
                   boRECOCORR = True And _
                   boRECOBARR = True And _
                   boRECOMANZ = True And _
                   boRECOPRED = True And _
                   boRECOEDIF = True And _
                   boRECOUNPR = True And _
                   boRECOCLSE = True And _
                   boRECOESTA = True And _
                   boRECONUFI = True And _
                   boRECOMAIN = True Then

                    ' declara la variable
                    Dim inRECOSECU As Integer = vl_inRECOSECU
                    Dim inRECONURE As Integer = vl_inRECONURE
                    Dim stRECOFERE As String = vl_stRECOFERE
                    Dim inFIPRNUFI As Integer = CInt(Trim(Me.txtRCPSNUFI.Text))
                    Dim stFIPRMUNI As String = CStr(Trim(Me.txtRCPSMUNI.Text))
                    Dim stFIPRCORR As String = CStr(Trim(Me.txtRCPSCORR.Text))
                    Dim stFIPRBARR As String = CStr(Trim(Me.txtRCPSBARR.Text))
                    Dim stFIPRMANZ As String = CStr(Trim(Me.txtRCPSMANZ.Text))
                    Dim stFIPRPRED As String = CStr(Trim(Me.txtRCPSPRED.Text))
                    Dim stFIPREDIF As String = CStr(Trim(Me.txtRCPSEDIF.Text))
                    Dim stFIPRUNPR As String = CStr(Trim(Me.txtRCPSUNPR.Text))
                    Dim inFIPRCLSE As Integer = CInt(Trim(Me.cboRCPSCLSE.SelectedValue))
                    Dim stFIPRDIRE As String = CStr(Trim(Me.txtRCPSDIRE.Text))

                    If Trim(stFIPRDIRE) = "" Then

                        ' instancia la clase
                        Dim obFICHPRED As New cla_FICHPRED
                        Dim dtFICHPRED As New DataTable

                        dtFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(inFIPRNUFI)

                        If dtFICHPRED.Rows.Count > 0 Then
                            stFIPRDIRE = CStr(Trim(dtFICHPRED.Rows(0).Item("FIPRDIRE").ToString))
                        Else
                            stFIPRDIRE = ""
                        End If

                    End If

                    Dim stFIPRMAIN As String = CStr(Trim(Me.txtRCPSMAIN.Text))
                    Dim stFIPRESTA As String = CStr(Trim(Me.cboRCPSESTA.SelectedValue))

                    ' instancia la clase
                    Dim obRECOPRSE As New cla_RECOPRSE
                    Dim dtRECOPRSE As New DataTable

                    dtRECOPRSE = obRECOPRSE.fun_Buscar_CODIGO_X_RECOPRSE(inRECONURE, stRECOFERE, inFIPRNUFI)

                    ' verifica los registros
                    If dtRECOPRSE.Rows.Count = 0 Then

                        ' inserta registro
                        obRECOPRSE.fun_Insertar_RECOPRSE(inRECOSECU, _
                                                         inRECONURE, _
                                                         stRECOFERE, _
                                                         inFIPRNUFI, _
                                                         stFIPRMUNI, _
                                                         stFIPRCORR, _
                                                         stFIPRBARR, _
                                                         stFIPRMANZ, _
                                                         stFIPRPRED, _
                                                         stFIPREDIF, _
                                                         stFIPRUNPR, _
                                                         inFIPRCLSE, _
                                                         stFIPRDIRE, _
                                                         stFIPRMAIN, _
                                                         stFIPRESTA)

                    Else
                        mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                    End If

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.txtRCPSMUNI.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.txtRCPSMUNI.Focus()
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtRCPSMUNI.Focus()
        Me.Close()
    End Sub

    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click
        pro_ConsultaDePredios()
    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRCPSMUNI.KeyPress, txtRCPSCORR.KeyPress, txtRCPSBARR.KeyPress, txtRCPSMANZ.KeyPress, txtRCPSPRED.KeyPress, txtRCPSNUFI.KeyPress, txtRCPSMAIN.KeyPress, cboRCPSCLSE.KeyPress, cboRCPSESTA.KeyPress, txtRCPSEDIF.KeyPress, txtRCPSUNPR.KeyPress, txtRCPSDIRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboRCPSCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRCPSCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRCPSCLSE, Me.cboRCPSCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboRCPSESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRCPSESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRCPSESTA, Me.cboRCPSESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboRCPSCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRCPSCLSE.SelectedIndexChanged
        Me.lblRCPSCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRCPSCLSE), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboRCPSCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRCPSCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRCPSCLSE, Me.cboRCPSCLSE.SelectedIndex)
    End Sub
    Private Sub cboRCPSESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRCPSESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRCPSESTA, Me.cboRCPSESTA.SelectedIndex)
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSMUNI.GotFocus, txtRCPSCORR.GotFocus, txtRCPSBARR.GotFocus, txtRCPSMANZ.GotFocus, txtRCPSPRED.GotFocus, txtRCPSNUFI.GotFocus, txtRCPSMAIN.GotFocus, txtRCPSDIRE.GotFocus, txtRCPSEDIF.GotFocus, txtRCPSUNPR.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus, cboRCPSCLSE.GotFocus, cboRCPSESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSMUNI.Validated
        If Me.txtRCPSMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSMUNI.Text) = True Then
            Me.txtRCPSMUNI.Text = fun_Formato_Mascara_3_String(Me.txtRCPSMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSCORR.Validated
        If Me.txtRCPSCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSCORR.Text) = True Then
            Me.txtRCPSCORR.Text = fun_Formato_Mascara_2_String(Me.txtRCPSCORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSBARR.Validated
        If Me.txtRCPSBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSBARR.Text) = True Then
            Me.txtRCPSBARR.Text = fun_Formato_Mascara_3_String(Me.txtRCPSBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSMANZ.Validated
        If Me.txtRCPSMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSMANZ.Text) = True Then
            Me.txtRCPSMANZ.Text = fun_Formato_Mascara_3_String(Me.txtRCPSMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSPRED.Validated
        If Me.txtRCPSPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSPRED.Text) = True Then
            Me.txtRCPSPRED.Text = fun_Formato_Mascara_5_String(Me.txtRCPSPRED.Text)
        End If
    End Sub
    Private Sub txtRCPSEDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSEDIF.Validated
        If Me.txtRCPSEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSEDIF.Text) = True Then
            Me.txtRCPSEDIF.Text = fun_Formato_Mascara_3_String(Me.txtRCPSEDIF.Text)
        End If
    End Sub
    Private Sub txtRCPSUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSUNPR.Validated
        If Me.txtRCPSUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSUNPR.Text) = True Then
            Me.txtRCPSUNPR.Text = fun_Formato_Mascara_5_String(Me.txtRCPSUNPR.Text)
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