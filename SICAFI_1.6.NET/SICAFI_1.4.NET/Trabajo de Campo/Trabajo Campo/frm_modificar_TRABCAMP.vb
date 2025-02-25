Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_TRABCAMP

    '==================================
    '*** MODIFICAR TRABAJO DE CAMPO ***
    '==================================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inInRegistro As Integer)
        inID_REGISTRO = inInRegistro

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Try
            Dim objdatos1 As New cla_CLASSECT

            Me.cboTRCACLSE.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboTRCACLSE.DisplayMember = "CLSEDESC"
            Me.cboTRCACLSE.ValueMember = "CLSECODI"

            Dim objdatos2 As New cla_VIGENCIA

            Me.cboTRCAVIGE.DataSource = objdatos2.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboTRCAVIGE.DisplayMember = "VIGEDESC"
            Me.cboTRCAVIGE.ValueMember = "VIGECODI"

            Dim objdatos3 As New cla_CAUSACTO

            Me.cboTRCACAAC.DataSource = objdatos3.fun_Consultar_CAMPOS_MANT_CAUSACTO
            Me.cboTRCACAAC.DisplayMember = "CAACDESC"
            Me.cboTRCACAAC.ValueMember = "CAACCODI"

            Dim objdatos4 As New cla_DEPARTAMENTO

            Me.cboTRCANODE.DataSource = objdatos4.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboTRCANODE.DisplayMember = "DEPACODI"
            Me.cboTRCANODE.ValueMember = "DEPACODI"

            Dim objdatos5 As New cla_MUNICIPIO

            Me.cboTRCANOMU.DataSource = objdatos5.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboTRCANOMU.DisplayMember = "MUNICODI"
            Me.cboTRCANOMU.ValueMember = "MUNICODI"

            Dim objdatos6 As New cla_NOTARIA

            Me.cboTRCANOTA.DataSource = objdatos6.fun_Consultar_CAMPOS_MANT_NOTARIA
            Me.cboTRCANOTA.DisplayMember = "NOTACODI"
            Me.cboTRCANOTA.ValueMember = "NOTACODI"

            Dim objdatos7 As New cla_ESTADO

            Me.cboTRCAESTA.DataSource = objdatos7.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboTRCAESTA.DisplayMember = "ESTADESC"
            Me.cboTRCAESTA.ValueMember = "ESTACODI"

            With Me.nudTRCAPRNU
                .Maximum = 1000 ' valor máximo   
                .Minimum = 0 ' minimo  
                .Value = 0
                .Increment = 1
            End With

            Dim objdatos8 As New cla_TRABCAMP
            Dim tbl As New DataTable

            tbl = objdatos8.fun_Buscar_ID_TRABCAMP(inID_REGISTRO)

            Me.txtTRCASECU.Text = CStr(Trim(tbl.Rows(0).Item("TRCASECU")))
            Me.txtTRCAMUNI.Text = CStr(Trim(tbl.Rows(0).Item("TRCAMUNI")))
            Me.txtTRCACORR.Text = CStr(Trim(tbl.Rows(0).Item("TRCACORR")))
            Me.txtTRCABARR.Text = CStr(Trim(tbl.Rows(0).Item("TRCABARR")))
            Me.txtTRCAMANZ.Text = CStr(Trim(tbl.Rows(0).Item("TRCAMANZ")))
            Me.txtTRCAPRED.Text = CStr(Trim(tbl.Rows(0).Item("TRCAPRED")))
            Me.txtTRCAFEES.Text = CStr(Trim(tbl.Rows(0).Item("TRCAFEES")))
            Me.txtTRCAESCR.Text = CStr(Trim(tbl.Rows(0).Item("TRCAESCR")))
            Me.nudTRCAPRNU.Value = CInt(tbl.Rows(0).Item("TRCAPRNU"))
            Me.nudTRCAPRMO.Value = CInt(tbl.Rows(0).Item("TRCAPRMO"))
            Me.nudTRCAPREL.Value = CInt(tbl.Rows(0).Item("TRCAPREL"))
            Me.cboTRCACAAC.SelectedValue = tbl.Rows(0).Item("TRCACAAC")
            Me.cboTRCANODE.SelectedValue = tbl.Rows(0).Item("TRCANODE")
            Me.cboTRCANOMU.SelectedValue = tbl.Rows(0).Item("TRCANOMU")
            Me.cboTRCANOTA.SelectedValue = tbl.Rows(0).Item("TRCANOTA")
            Me.txtTRCAOBSE.Text = CStr(Trim(tbl.Rows(0).Item("TRCAOBSE")))
            Me.cboTRCAVIGE.SelectedValue = tbl.Rows(0).Item("TRCAVIGE")
            Me.cboTRCACLSE.SelectedValue = tbl.Rows(0).Item("TRCACLSE")
            Me.cboTRCAESTA.SelectedValue = tbl.Rows(0).Item("TRCAESTA")
            Me.txtTRCADESC.Text = CStr(Trim(tbl.Rows(0).Item("TRCADESC")))
            Me.txtTRCAMAIN.Text = CStr(Trim(tbl.Rows(0).Item("TRCAMAIN")))

            Me.dtpTRCAFEES.Value = CDate(tbl.Rows(0).Item("TRCAFEES"))

            Dim boTRCACAAC As Boolean = fun_Buscar_Dato_CAUSACTO(Me.cboTRCACAAC.SelectedValue)
            Dim boTRCANOTA As Boolean = fun_Buscar_Dato_NOTARIA(Me.cboTRCANODE.SelectedValue, Me.cboTRCANOMU.SelectedValue, Me.cboTRCANOTA.SelectedValue)
            Dim boTRCAVIGE As Boolean = fun_Buscar_Dato_VIGENCIA(Me.cboTRCAVIGE.SelectedValue)
            Dim boTRCACLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboTRCACLSE.SelectedValue)

            If boTRCACAAC = True OrElse _
               boTRCANOTA = True OrElse _
               boTRCAVIGE = True OrElse _
               boTRCANOTA = True OrElse _
               boTRCACLSE = True Then

                Me.lblTRCACAAC.Text = CType(fun_Buscar_Lista_Valores_CAUSACTO_Codigo(Me.cboTRCACAAC), String)
                Me.lblTRCANOTA.Text = CType(fun_Buscar_Lista_Valores_NOTARIA(Me.cboTRCANODE.SelectedValue, Me.cboTRCANOMU.SelectedValue, Me.cboTRCANOTA.SelectedValue), String)
                Me.lblTRCAVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboTRCAVIGE), String)
                Me.lblTRCACLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboTRCACLSE), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboTRCACLSE.DataSource = New DataTable
        Me.cboTRCAVIGE.DataSource = New DataTable
        Me.cboTRCACAAC.DataSource = New DataTable
        Me.cboTRCAVIGE.DataSource = New DataTable
        Me.cboTRCANODE.DataSource = New DataTable
        Me.cboTRCANOMU.DataSource = New DataTable
        Me.cboTRCANOTA.DataSource = New DataTable
        Me.cboTRCAESTA.DataSource = New DataTable

        Me.txtTRCASECU.Text = ""
        Me.txtTRCAESCR.Text = "0"
        Me.nudTRCAPRNU.Value = 0
        Me.lblTRCACLSE.Text = ""
        Me.lblTRCAVIGE.Text = ""
        Me.lblTRCACAAC.Text = ""
        Me.lblTRCANOTA.Text = ""
        Me.txtTRCAMUNI.Text = ""
        Me.txtTRCACORR.Text = ""
        Me.txtTRCABARR.Text = ""
        Me.txtTRCAMANZ.Text = ""
        Me.txtTRCAPRED.Text = ""
        Me.txtTRCAFEES.Text = ""
        Me.txtTRCAOBSE.Text = ""
        Me.txtTRCAOBSE_NUEVAS.Text = ""
        Me.txtTRCADESC.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_TRABCAMP

              ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boTRCAMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTRCAMUNI)
            Dim boTRCACORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTRCACORR)
            Dim boTRCABARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTRCABARR)
            Dim boTRCAMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTRCAMANZ)
            Dim boTRCAPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTRCAPRED)
            Dim boTRCACLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTRCACLSE)
            Dim boTRCAVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTRCAVIGE)
            Dim boTRCACAAC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTRCACAAC)
            Dim boTRCAFEES As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtTRCAFEES)
            Dim boTRCAESCR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTRCAESCR)
            Dim boTRCAPRNU As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.nudTRCAPRNU)
            Dim boTRCAPRMO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.nudTRCAPRMO)
            Dim boTRCAPREL As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.nudTRCAPREL)
            Dim boTRCAESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTRCAESTA)

            Dim stTRCAOBSE_NUEVA As String = Trim(Me.txtTRCAOBSE_NUEVAS.Text)

            If Trim(stTRCAOBSE_NUEVA) <> "" Then
                Me.txtTRCAOBSE.Text += " Nota ingresada por: " & vp_usuario & " " & fun_fecha() & " : " & stTRCAOBSE_NUEVA & ". "
            End If

            ' verifica los datos del formulario 
            If boTRCAMUNI = True And _
               boTRCACORR = True And _
               boTRCABARR = True And _
               boTRCAMANZ = True And _
               boTRCAPRED = True And _
               boTRCACLSE = True And _
               boTRCAVIGE = True And _
               boTRCACAAC = True And _
               boTRCAESCR = True And _
               boTRCAPRNU = True And _
               boTRCAPRMO = True And _
               boTRCAPREL = True And _
               boTRCAESTA = True Then

                Dim objdatos22 As New cla_TRABCAMP

                If (objdatos22.fun_Actualizar_TRABCAMP(inID_REGISTRO, _
                                                     Me.txtTRCASECU.Text, _
                                                     Me.txtTRCAMUNI.Text, _
                                                     Me.txtTRCACORR.Text, _
                                                     Me.txtTRCABARR.Text, _
                                                     Me.txtTRCAMANZ.Text, _
                                                     Me.txtTRCAPRED.Text, _
                                                     Me.cboTRCACLSE.SelectedValue, _
                                                     Me.cboTRCAVIGE.SelectedValue, _
                                                     Me.txtTRCAFEES.Text, _
                                                     Me.txtTRCAESCR.Text, _
                                                     Me.nudTRCAPRNU.Value, _
                                                     Me.cboTRCACAAC.SelectedValue, _
                                                     Me.cboTRCANODE.Text, _
                                                     Me.cboTRCANOMU.Text, _
                                                     Me.cboTRCANOTA.Text, _
                                                     Trim(Me.txtTRCAOBSE.Text), _
                                                     Me.cboTRCAESTA.SelectedValue, _
                                                     Me.nudTRCAPRMO.Value, _
                                                     Me.nudTRCAPREL.Value, _
                                                     Me.txtTRCADESC.Text, _
                                                     Me.txtTRCAMAIN.Text)) = True Then

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(6)

                    If tblRutas.Rows.Count > 0 Then

                        Dim stRuta As String = Me.txtTRCAMUNI.Text & "-" & Me.cboTRCACLSE.SelectedValue & "-" & Me.txtTRCACORR.Text & "-" & Me.txtTRCABARR.Text & "-" & Me.txtTRCAMANZ.Text & "-" & Me.txtTRCAPRED.Text & "-" & Me.cboTRCAVIGE.SelectedValue

                        If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                            System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                        End If

                    End If

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    Dim objdatos1 As New cla_TRABCAMP
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_CODIGO_X_TRABCAMP(CInt(Me.txtTRCASECU.Text))

                    If tbl1.Rows.Count > 0 Then

                        Dim inNroIdRe As New frm_TRABCAMP(tbl1.Rows(0).Item("TRCAIDRE"))

                    End If

                    Me.txtTRCAMUNI.Focus()
                    Me.Close()

                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtTRCAMUNI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTRCAMUNI.KeyPress, txtTRCACORR.KeyPress, txtTRCABARR.KeyPress, txtTRCAMANZ.KeyPress, txtTRCAPRED.KeyPress, cboTRCACLSE.KeyPress, cboTRCAVIGE.KeyPress, cboTRCACAAC.KeyPress, txtTRCAFEES.KeyPress, txtTRCAESCR.KeyPress, cboTRCANODE.KeyPress, cboTRCANOMU.KeyPress, cboTRCANOTA.KeyPress, cboTRCAESTA.KeyPress, txtTRCAOBSE.KeyPress, nudTRCAPRNU.KeyPress, nudTRCAPRMO.KeyPress, nudTRCAPREL.KeyPress, txtTRCADESC.KeyPress, txtTRCAMAIN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTRCACLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTRCACLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTRCACLSE, Me.cboTRCACLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCAVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTRCAVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTRCAVIGE, Me.cboTRCAVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCACAAC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTRCACAAC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CAUSACTO_Descripcion(Me.cboTRCACAAC, Me.cboTRCACAAC.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTRCAESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTRCAESTA, Me.cboTRCAESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTRCAMUNI.GotFocus, txtTRCACORR.GotFocus, txtTRCABARR.GotFocus, txtTRCAMANZ.GotFocus, txtTRCAPRED.GotFocus, txtTRCAFEES.GotFocus, txtTRCAESCR.GotFocus, txtTRCAOBSE.GotFocus, nudTRCAPRNU.GotFocus, nudTRCAPRMO.GotFocus, nudTRCAPREL.GotFocus, txtTRCADESC.GotFocus, txtTRCAMAIN.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTRCACLSE.GotFocus, cboTRCAVIGE.GotFocus, cboTRCACAAC.GotFocus, cboTRCANODE.GotFocus, cboTRCANOMU.GotFocus, cboTRCANOTA.GotFocus, cboTRCAESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"


    Private Sub cboFPPRDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTRCANODE.SelectedIndexChanged
        lblTRCANOTA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Trim(Me.cboTRCANODE.Text)), String)
    End Sub
    Private Sub cboFPPRMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTRCANOMU.SelectedIndexChanged
        lblTRCANOTA.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Trim(Me.cboTRCANODE.Text), Trim(Me.cboTRCANOMU.Text)), String)
    End Sub
    Private Sub cboFPPRNOTA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTRCANOTA.SelectedIndexChanged
        lblTRCANOTA.Text = CType(fun_Buscar_Lista_Valores_NOTARIA(Trim(Me.cboTRCANODE.Text), Trim(Me.cboTRCANOMU.Text), Trim(Me.cboTRCANOTA.Text)), String)
    End Sub
    Private Sub cboTRCACLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTRCACLSE.SelectedIndexChanged
        Me.lblTRCACLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboTRCACLSE), String)
    End Sub
    Private Sub cboTRCAVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTRCAVIGE.SelectedIndexChanged
        Me.lblTRCAVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboTRCAVIGE), String)
    End Sub
    Private Sub cboTRCACAAC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTRCACAAC.SelectedIndexChanged
        Me.lblTRCACAAC.Text = CType(fun_Buscar_Lista_Valores_CAUSACTO_Codigo(Me.cboTRCACAAC), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTRCANODE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTRCANODE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO(cboTRCANODE, cboTRCANODE.SelectedIndex)
    End Sub
    Private Sub cboTRCANOMU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTRCANOMU.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO(cboTRCANOMU, cboTRCANOMU.SelectedIndex)
    End Sub
    Private Sub cboTRCANOTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTRCANOTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_NOTARIA(cboTRCANOTA, cboTRCANOTA.SelectedIndex)
    End Sub
    Private Sub cboTRCACLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTRCACLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTRCACLSE, Me.cboTRCACLSE.SelectedIndex)
    End Sub
    Private Sub cboTRCAVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTRCAVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTRCAVIGE, Me.cboTRCAVIGE.SelectedIndex)
    End Sub
    Private Sub cboTRCACAAC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTRCACAAC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CAUSACTO_Descripcion(Me.cboTRCACAAC, Me.cboTRCACAAC.SelectedIndex)
    End Sub
    Private Sub cboTRCAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTRCAESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTRCAESTA, Me.cboTRCAESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTAPEAVFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTRCAESCR.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        End If

    End Sub

    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTRCAMUNI.Validated
        If Me.txtTRCAMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTRCAMUNI.Text) = True Then
            Me.txtTRCAMUNI.Text = fun_Formato_Mascara_3_String(Me.txtTRCAMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTRCACORR.Validated
        If Me.txtTRCACORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTRCACORR.Text) = True Then
            Me.txtTRCACORR.Text = fun_Formato_Mascara_2_String(Me.txtTRCACORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTRCABARR.Validated
        If Me.txtTRCABARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTRCABARR.Text) = True Then
            Me.txtTRCABARR.Text = fun_Formato_Mascara_3_String(Me.txtTRCABARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTRCAMANZ.Validated
        If Me.txtTRCAMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTRCAMANZ.Text) = True Then
            Me.txtTRCAMANZ.Text = fun_Formato_Mascara_3_String(Me.txtTRCAMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTRCAPRED.Validated
        If Me.txtTRCAPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTRCAPRED.Text) = True Then
            Me.txtTRCAPRED.Text = fun_Formato_Mascara_5_String(Me.txtTRCAPRED.Text)
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

#Region "ValueChanged"

    Private Sub dtpTRCAFEES_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTRCAFEES.ValueChanged
        Me.txtTRCAFEES.Text = Me.dtpTRCAFEES.Value
    End Sub

#End Region

#End Region


End Class