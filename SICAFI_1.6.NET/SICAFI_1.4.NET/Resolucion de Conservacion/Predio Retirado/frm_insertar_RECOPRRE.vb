Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_RECOPRRE

    '==================================
    '*** INSERTAR PREDIOS RETIRADOS ***
    '==================================

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

        Me.txtRCPRMUNI.Text = "266"
        Me.txtRCPRCORR.Text = "01"
        Me.txtRCPRBARR.Text = ""
        Me.txtRCPRMANZ.Text = ""
        Me.txtRCPRPRED.Text = ""
        Me.txtRCPREDIF.Text = ""
        Me.txtRCPRUNPR.Text = ""
        Me.txtRCPRNUFI.Text = ""
        Me.txtRCPRMAIN.Text = ""

        Me.cboRCPRCLSE.DataSource = New DataTable
        Me.cboRCPRESTA.DataSource = New DataTable

        Me.dgvRECOPRRE.DataSource = New DataTable

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub
    Private Sub pro_ConsultaDePredios()

        Try
            ' instancia un dt
            dt = New DataTable

            ' declara las variables
            Dim stRCPRMUNI As String = ""
            Dim stRCPRCORR As String = ""
            Dim stRCPRBARR As String = ""
            Dim stRCPRMANZ As String = ""
            Dim stRCPRPRED As String = ""
            Dim stRCPREDIF As String = ""
            Dim stRCPRUNPR As String = ""
            Dim stRCPRDIRE As String = ""
            Dim stRCPRNUFI As String = ""
            Dim stRCPRMAIN As String = ""
            Dim stRCPRCLSE As String = ""
            Dim stRCPRESTA As String = ""

            ' carga los campos
            If Trim(Me.txtRCPRMUNI.Text) = "" Then
                stRCPRMUNI = "%"
            Else
                stRCPRMUNI = Trim(Me.txtRCPRMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPRCORR.Text) = "" Then
                stRCPRCORR = "%"
            Else
                stRCPRCORR = Trim(Me.txtRCPRCORR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPRBARR.Text) = "" Then
                stRCPRBARR = "%"
            Else
                stRCPRBARR = Trim(Me.txtRCPRBARR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPRMANZ.Text) = "" Then
                stRCPRMANZ = "%"
            Else
                stRCPRMANZ = Trim(Me.txtRCPRMANZ.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPRPRED.Text) = "" Then
                stRCPRPRED = "%"
            Else
                stRCPRPRED = Trim(Me.txtRCPRPRED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPREDIF.Text) = "" Then
                stRCPREDIF = "%"
            Else
                stRCPREDIF = Trim(Me.txtRCPREDIF.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPRUNPR.Text) = "" Then
                stRCPRUNPR = "%"
            Else
                stRCPRUNPR = Trim(Me.txtRCPRUNPR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPRDIRE.Text) = "" Then
                stRCPRDIRE = "%"
            Else
                stRCPRDIRE = Trim(Me.txtRCPRDIRE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPRNUFI.Text) = "" Then
                stRCPRNUFI = "%"
            Else
                stRCPRNUFI = Trim(Me.txtRCPRNUFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPRMAIN.Text) = "" Then
                stRCPRMAIN = "%"
            Else
                stRCPRMAIN = Trim(Me.txtRCPRMAIN.Text)
            End If

            ' carga los campos
            If Trim(Me.cboRCPRCLSE.Text) = "" Then
                stRCPRCLSE = "%"
            Else
                stRCPRCLSE = Trim(Me.cboRCPRCLSE.SelectedValue)
            End If

            ' carga los campos
            If Trim(Me.cboRCPRESTA.Text) = "" Then
                stRCPRESTA = "%"
            Else
                stRCPRESTA = Trim(Me.cboRCPRESTA.SelectedValue)
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
            stConsultaSQL += "FIPRMUNI LIKE '" & Trim(stRCPRMUNI) & "' AND "
            stConsultaSQL += "FIPRCORR LIKE '" & Trim(stRCPRCORR) & "' AND "
            stConsultaSQL += "FIPRBARR LIKE '" & Trim(stRCPRBARR) & "' AND "
            stConsultaSQL += "FIPRMANZ LIKE '" & Trim(stRCPRMANZ) & "' AND "
            stConsultaSQL += "FIPRPRED LIKE '" & Trim(stRCPRPRED) & "' AND "
            stConsultaSQL += "FIPREDIF LIKE '" & Trim(stRCPREDIF) & "' AND "
            stConsultaSQL += "FIPRUNPR LIKE '" & Trim(stRCPRUNPR) & "' AND "
            stConsultaSQL += "FIPRDIRE LIKE '" & Trim(stRCPRDIRE) & "' AND "
            stConsultaSQL += "FIPRCLSE LIKE '" & Trim(stRCPRCLSE) & "' AND "
            stConsultaSQL += "FPPRNUFI LIKE '" & Trim(stRCPRNUFI) & "' AND "
            stConsultaSQL += "FPPRMAIN LIKE '" & Trim(stRCPRMAIN) & "' AND "
            stConsultaSQL += "FIPRESTA LIKE '" & Trim(stRCPRESTA) & "' "

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
                    Me.txtRCPRMUNI.Focus()
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
                        Dim obRECOPRRE As New cla_RECOPRRE
                        Dim dtRECOPRRE As New DataTable

                        dtRECOPRRE = obRECOPRRE.fun_Buscar_CODIGO_X_RECOPRRE(inRECONURE, stRECOFERE, inFIPRNUFI)

                        ' verifica los registros
                        If dtRECOPRRE.Rows.Count = 0 Then

                            ' inserta registro
                            obRECOPRRE.fun_Insertar_RECOPRRE(inRECOSECU, _
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
                Dim boRECOMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPRMUNI)
                Dim boRECOCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPRCORR)
                Dim boRECOBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPRBARR)
                Dim boRECOMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPRMANZ)
                Dim boRECOPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPRPRED)
                Dim boRECOEDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPREDIF)
                Dim boRECOUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPRUNPR)
                Dim boRECOCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRCPRCLSE)
                Dim boRECOESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRCPRESTA)
                Dim boRECONUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtRCPRNUFI)
                Dim boRECOMAIN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRCPRMAIN)

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
                    Dim inFIPRNUFI As Integer = CInt(Trim(Me.txtRCPRNUFI.Text))
                    Dim stFIPRMUNI As String = CStr(Trim(Me.txtRCPRMUNI.Text))
                    Dim stFIPRCORR As String = CStr(Trim(Me.txtRCPRCORR.Text))
                    Dim stFIPRBARR As String = CStr(Trim(Me.txtRCPRBARR.Text))
                    Dim stFIPRMANZ As String = CStr(Trim(Me.txtRCPRMANZ.Text))
                    Dim stFIPRPRED As String = CStr(Trim(Me.txtRCPRPRED.Text))
                    Dim stFIPREDIF As String = CStr(Trim(Me.txtRCPREDIF.Text))
                    Dim stFIPRUNPR As String = CStr(Trim(Me.txtRCPRUNPR.Text))
                    Dim inFIPRCLSE As Integer = CInt(Trim(Me.cboRCPRCLSE.SelectedValue))
                    Dim stFIPRDIRE As String = CStr(Trim(Me.txtRCPRDIRE.Text))

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

                    Dim stFIPRMAIN As String = CStr(Trim(Me.txtRCPRMAIN.Text))
                    Dim stFIPRESTA As String = CStr(Trim(Me.cboRCPRESTA.SelectedValue))

                    ' instancia la clase
                    Dim obRECOPRRE As New cla_RECOPRRE
                    Dim dtRECOPRRE As New DataTable

                    dtRECOPRRE = obRECOPRRE.fun_Buscar_CODIGO_X_RECOPRRE(inRECONURE, stRECOFERE, inFIPRNUFI)

                    ' verifica los registros
                    If dtRECOPRRE.Rows.Count = 0 Then

                        ' inserta registro
                        obRECOPRRE.fun_Insertar_RECOPRRE(inRECOSECU, _
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
                        Me.txtRCPRMUNI.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.txtRCPRMUNI.Focus()
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtRCPRMUNI.Focus()
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

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRCPRMUNI.KeyPress, txtRCPRCORR.KeyPress, txtRCPRBARR.KeyPress, txtRCPRMANZ.KeyPress, txtRCPRPRED.KeyPress, txtRCPRNUFI.KeyPress, txtRCPRMAIN.KeyPress, cboRCPRCLSE.KeyPress, cboRCPRESTA.KeyPress, txtRCPREDIF.KeyPress, txtRCPRUNPR.KeyPress, txtRCPRDIRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboRCPRCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRCPRCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRCPRCLSE, Me.cboRCPRCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboRCPRESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRCPRESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRCPRESTA, Me.cboRCPRESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboRCPRCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRCPRCLSE.SelectedIndexChanged
        Me.lblRCPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRCPRCLSE), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboRCPRCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRCPRCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRCPRCLSE, Me.cboRCPRCLSE.SelectedIndex)
    End Sub
    Private Sub cboRCPRESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRCPRESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRCPRESTA, Me.cboRCPRESTA.SelectedIndex)
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPRMUNI.GotFocus, txtRCPRCORR.GotFocus, txtRCPRBARR.GotFocus, txtRCPRMANZ.GotFocus, txtRCPRPRED.GotFocus, txtRCPRNUFI.GotFocus, txtRCPRMAIN.GotFocus, txtRCPRDIRE.GotFocus, txtRCPREDIF.GotFocus, txtRCPRUNPR.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus, cboRCPRCLSE.GotFocus, cboRCPRESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPRMUNI.Validated
        If Me.txtRCPRMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPRMUNI.Text) = True Then
            Me.txtRCPRMUNI.Text = fun_Formato_Mascara_3_String(Me.txtRCPRMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPRCORR.Validated
        If Me.txtRCPRCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPRCORR.Text) = True Then
            Me.txtRCPRCORR.Text = fun_Formato_Mascara_2_String(Me.txtRCPRCORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPRBARR.Validated
        If Me.txtRCPRBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPRBARR.Text) = True Then
            Me.txtRCPRBARR.Text = fun_Formato_Mascara_3_String(Me.txtRCPRBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPRMANZ.Validated
        If Me.txtRCPRMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPRMANZ.Text) = True Then
            Me.txtRCPRMANZ.Text = fun_Formato_Mascara_3_String(Me.txtRCPRMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPRPRED.Validated
        If Me.txtRCPRPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPRPRED.Text) = True Then
            Me.txtRCPRPRED.Text = fun_Formato_Mascara_5_String(Me.txtRCPRPRED.Text)
        End If
    End Sub
    Private Sub txtRCPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPREDIF.Validated
        If Me.txtRCPREDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPREDIF.Text) = True Then
            Me.txtRCPREDIF.Text = fun_Formato_Mascara_3_String(Me.txtRCPREDIF.Text)
        End If
    End Sub
    Private Sub txtRCPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPRUNPR.Validated
        If Me.txtRCPRUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPRUNPR.Text) = True Then
            Me.txtRCPRUNPR.Text = fun_Formato_Mascara_5_String(Me.txtRCPRUNPR.Text)
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