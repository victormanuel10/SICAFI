Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_RECOPRMO

    '====================================
    '*** INSERTAR PREDIOS MODIFICADOS ***
    '====================================

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

        Me.txtRCPMMUNI.Text = "266"
        Me.txtRCPMCORR.Text = "01"
        Me.txtRCPMBARR.Text = ""
        Me.txtRCPMMANZ.Text = ""
        Me.txtRCPMPRED.Text = ""
        Me.txtRCPMEDIF.Text = ""
        Me.txtRCPMUNPR.Text = ""
        Me.txtRCPMNUFI.Text = ""
        Me.txtRCPMMAIN.Text = ""

        Me.cboRCPMCLSE.DataSource = New DataTable
        Me.cboRCPMESTA.DataSource = New DataTable

        Me.dgvRECOPRMO.DataSource = New DataTable

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub
    Private Sub pro_ConsultaDePredios()

        Try
            ' instancia un dt
            dt = New DataTable

            ' declara las variables
            Dim stRCPMMUNI As String = ""
            Dim stRCPMCORR As String = ""
            Dim stRCPMBARR As String = ""
            Dim stRCPMMANZ As String = ""
            Dim stRCPMPRED As String = ""
            Dim stRCPMEDIF As String = ""
            Dim stRCPMUNPR As String = ""
            Dim stRCPMDIRE As String = ""
            Dim stRCPMNUFI As String = ""
            Dim stRCPMMAIN As String = ""
            Dim stRCPMCLSE As String = ""
            Dim stRCPMESTA As String = ""

            ' carga los campos
            If Trim(Me.txtRCPMMUNI.Text) = "" Then
                stRCPMMUNI = "%"
            Else
                stRCPMMUNI = Trim(Me.txtRCPMMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPMCORR.Text) = "" Then
                stRCPMCORR = "%"
            Else
                stRCPMCORR = Trim(Me.txtRCPMCORR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPMBARR.Text) = "" Then
                stRCPMBARR = "%"
            Else
                stRCPMBARR = Trim(Me.txtRCPMBARR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPMMANZ.Text) = "" Then
                stRCPMMANZ = "%"
            Else
                stRCPMMANZ = Trim(Me.txtRCPMMANZ.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPMPRED.Text) = "" Then
                stRCPMPRED = "%"
            Else
                stRCPMPRED = Trim(Me.txtRCPMPRED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPMEDIF.Text) = "" Then
                stRCPMEDIF = "%"
            Else
                stRCPMEDIF = Trim(Me.txtRCPMEDIF.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPMUNPR.Text) = "" Then
                stRCPMUNPR = "%"
            Else
                stRCPMUNPR = Trim(Me.txtRCPMUNPR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPMDIRE.Text) = "" Then
                stRCPMDIRE = "%"
            Else
                stRCPMDIRE = Trim(Me.txtRCPMDIRE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPMNUFI.Text) = "" Then
                stRCPMNUFI = "%"
            Else
                stRCPMNUFI = Trim(Me.txtRCPMNUFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPMMAIN.Text) = "" Then
                stRCPMMAIN = "%"
            Else
                stRCPMMAIN = Trim(Me.txtRCPMMAIN.Text)
            End If

            ' carga los campos
            If Trim(Me.cboRCPMCLSE.Text) = "" Then
                stRCPMCLSE = "%"
            Else
                stRCPMCLSE = Trim(Me.cboRCPMCLSE.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.cboRCPMESTA.Text) = "" Then
                stRCPMESTA = "%"
            Else
                stRCPMESTA = Trim(Me.cboRCPMESTA.SelectedValue)
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
            stConsultaSQL += "FIPRMUNI LIKE '" & Trim(stRCPMMUNI) & "' AND "
            stConsultaSQL += "FIPRCORR LIKE '" & Trim(stRCPMCORR) & "' AND "
            stConsultaSQL += "FIPRBARR LIKE '" & Trim(stRCPMBARR) & "' AND "
            stConsultaSQL += "FIPRMANZ LIKE '" & Trim(stRCPMMANZ) & "' AND "
            stConsultaSQL += "FIPRPRED LIKE '" & Trim(stRCPMPRED) & "' AND "
            stConsultaSQL += "FIPREDIF LIKE '" & Trim(stRCPMEDIF) & "' AND "
            stConsultaSQL += "FIPRUNPR LIKE '" & Trim(stRCPMUNPR) & "' AND "
            stConsultaSQL += "FIPRDIRE LIKE '" & Trim(stRCPMDIRE) & "' AND "
            stConsultaSQL += "FIPRCLSE LIKE '" & Trim(stRCPMCLSE) & "' AND "
            stConsultaSQL += "FPPRNUFI LIKE '" & Trim(stRCPMNUFI) & "' AND "
            stConsultaSQL += "FPPRMAIN LIKE '" & Trim(stRCPMMAIN) & "' AND "
            stConsultaSQL += "FIPRESTA LIKE '" & Trim(stRCPMESTA) & "' "

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
                    Me.dgvRECOPRMO.DataSource = dt
                    Me.dgvRECOPRMO.Columns(0).Visible = False
                Else
                    ' sale del proceso de consulta
                    Exit Sub
                End If

                ' verifica si existen datos consultados
                If Me.dgvRECOPRMO.RowCount = 0 Then
                    mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                    Me.txtRCPMMUNI.Focus()
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
            If Me.dgvRECOPRMO.RowCount > 0 Then

                ' declara la variable
                Dim dtRESOCONS As New DataTable

                ' pasa los datos
                dtRESOCONS = Me.dgvRECOPRMO.DataSource

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
                        Dim obRECOPRMO As New cla_RECOPRMO
                        Dim dtRECOPRMO As New DataTable

                        dtRECOPRMO = obRECOPRMO.fun_Buscar_CODIGO_X_RECOPRMO(inRECONURE, stRECOFERE, inFIPRNUFI)

                        ' verifica los registros
                        If dtRECOPRMO.Rows.Count = 0 Then

                            ' inserta registro
                            obRECOPRMO.fun_Insertar_RECOPRMO(inRECOSECU, _
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
                    Me.dgvRECOPRMO.DataSource = New DataTable

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                End If

                ' ingreso de registro individual
            ElseIf Me.dgvRECOPRMO.RowCount = 0 Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                ' verifica los campos
                Dim boRECOMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPMMUNI)
                Dim boRECOCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPMCORR)
                Dim boRECOBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPMBARR)
                Dim boRECOMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPMMANZ)
                Dim boRECOPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPMPRED)
                Dim boRECOEDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPMEDIF)
                Dim boRECOUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPMUNPR)
                Dim boRECOCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRCPMCLSE)
                Dim boRECOESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRCPMESTA)
                Dim boRECONUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPMNUFI)
                Dim boRECOMAIN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRCPMMAIN)

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
                    Dim inFIPRNUFI As Integer = CInt(Trim(Me.txtRCPMNUFI.Text))
                    Dim stFIPRMUNI As String = CStr(Trim(Me.txtRCPMMUNI.Text))
                    Dim stFIPRCORR As String = CStr(Trim(Me.txtRCPMCORR.Text))
                    Dim stFIPRBARR As String = CStr(Trim(Me.txtRCPMBARR.Text))
                    Dim stFIPRMANZ As String = CStr(Trim(Me.txtRCPMMANZ.Text))
                    Dim stFIPRPRED As String = CStr(Trim(Me.txtRCPMPRED.Text))
                    Dim stFIPREDIF As String = CStr(Trim(Me.txtRCPMEDIF.Text))
                    Dim stFIPRUNPR As String = CStr(Trim(Me.txtRCPMUNPR.Text))
                    Dim inFIPRCLSE As Integer = CInt(Trim(Me.cboRCPMCLSE.SelectedValue))
                    Dim stFIPRDIRE As String = CStr(Trim(Me.txtRCPMDIRE.Text))

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

                    Dim stFIPRMAIN As String = CStr(Trim(Me.txtRCPMMAIN.Text))
                    Dim stFIPRESTA As String = CStr(Trim(Me.cboRCPMESTA.SelectedValue))

                    ' instancia la clase
                    Dim obRECOPRMO As New cla_RECOPRMO
                    Dim dtRECOPRMO As New DataTable

                    dtRECOPRMO = obRECOPRMO.fun_Buscar_CODIGO_X_RECOPRMO(inRECONURE, stRECOFERE, inFIPRNUFI)

                    ' verifica los registros
                    If dtRECOPRMO.Rows.Count = 0 Then

                        ' inserta registro
                        obRECOPRMO.fun_Insertar_RECOPRMO(inRECOSECU, _
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
                        Me.txtRCPMMUNI.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.txtRCPMMUNI.Focus()
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtRCPMMUNI.Focus()
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

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRCPMMUNI.KeyPress, txtRCPMCORR.KeyPress, txtRCPMBARR.KeyPress, txtRCPMMANZ.KeyPress, txtRCPMPRED.KeyPress, txtRCPMNUFI.KeyPress, txtRCPMMAIN.KeyPress, cboRCPMCLSE.KeyPress, cboRCPMESTA.KeyPress, txtRCPMEDIF.KeyPress, txtRCPMUNPR.KeyPress, txtRCPMDIRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboRCPMCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRCPMCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRCPMCLSE, Me.cboRCPMCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboRCPMESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRCPMESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRCPMESTA, Me.cboRCPMESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboRCPMCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRCPMCLSE.SelectedIndexChanged
        Me.lblRCPMCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRCPMCLSE), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboRCPMCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRCPMCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRCPMCLSE, Me.cboRCPMCLSE.SelectedIndex)
    End Sub
    Private Sub cboRCPMESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRCPMESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRCPMESTA, Me.cboRCPMESTA.SelectedIndex)
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPMMUNI.GotFocus, txtRCPMCORR.GotFocus, txtRCPMBARR.GotFocus, txtRCPMMANZ.GotFocus, txtRCPMPRED.GotFocus, txtRCPMNUFI.GotFocus, txtRCPMMAIN.GotFocus, txtRCPMDIRE.GotFocus, txtRCPMEDIF.GotFocus, txtRCPMUNPR.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus, cboRCPMCLSE.GotFocus, cboRCPMESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPMMUNI.Validated
        If Me.txtRCPMMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPMMUNI.Text) = True Then
            Me.txtRCPMMUNI.Text = fun_Formato_Mascara_3_String(Me.txtRCPMMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPMCORR.Validated
        If Me.txtRCPMCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPMCORR.Text) = True Then
            Me.txtRCPMCORR.Text = fun_Formato_Mascara_2_String(Me.txtRCPMCORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPMBARR.Validated
        If Me.txtRCPMBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPMBARR.Text) = True Then
            Me.txtRCPMBARR.Text = fun_Formato_Mascara_3_String(Me.txtRCPMBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPMMANZ.Validated
        If Me.txtRCPMMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPMMANZ.Text) = True Then
            Me.txtRCPMMANZ.Text = fun_Formato_Mascara_3_String(Me.txtRCPMMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPMPRED.Validated
        If Me.txtRCPMPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPMPRED.Text) = True Then
            Me.txtRCPMPRED.Text = fun_Formato_Mascara_5_String(Me.txtRCPMPRED.Text)
        End If
    End Sub
    Private Sub txtRCPMEDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPMEDIF.Validated
        If Me.txtRCPMEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPMEDIF.Text) = True Then
            Me.txtRCPMEDIF.Text = fun_Formato_Mascara_3_String(Me.txtRCPMEDIF.Text)
        End If
    End Sub
    Private Sub txtRCPMUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPMUNPR.Validated
        If Me.txtRCPMUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPMUNPR.Text) = True Then
            Me.txtRCPMUNPR.Text = fun_Formato_Mascara_5_String(Me.txtRCPMUNPR.Text)
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