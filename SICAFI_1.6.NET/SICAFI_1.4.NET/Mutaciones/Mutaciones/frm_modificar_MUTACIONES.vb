Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_MUTACIONES

    '============================
    '*** MODIFICAR MUTACIONES ***
    '============================

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

            Me.cboMUTACLSE.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboMUTACLSE.DisplayMember = "CLSEDESC"
            Me.cboMUTACLSE.ValueMember = "CLSECODI"

            Dim objdatos2 As New cla_VIGENCIA

            Me.cboMUTAVIGE.DataSource = objdatos2.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboMUTAVIGE.DisplayMember = "VIGEDESC"
            Me.cboMUTAVIGE.ValueMember = "VIGECODI"

            Dim objdatos7 As New cla_ESTADO

            Me.cboMUTAESTA.DataSource = objdatos7.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboMUTAESTA.DisplayMember = "ESTADESC"
            Me.cboMUTAESTA.ValueMember = "ESTACODI"

            Dim objdatos8 As New cla_MUTACIONES
            Dim tbl As New DataTable

            tbl = objdatos8.fun_Buscar_ID_MUTACIONES(inID_REGISTRO)

            Me.txtMUTASECU.Text = CStr(Trim(tbl.Rows(0).Item("MUTASECU")))
            Me.txtMUTANUFI.Text = CStr(Trim(tbl.Rows(0).Item("MUTANUFI")))
            Me.txtMUTAMAIN.Text = CStr(Trim(tbl.Rows(0).Item("MUTAMAIN")))
            Me.txtMUTAMUNI.Text = CStr(Trim(tbl.Rows(0).Item("MUTAMUNI")))
            Me.txtMUTACORR.Text = CStr(Trim(tbl.Rows(0).Item("MUTACORR")))
            Me.txtMUTABARR.Text = CStr(Trim(tbl.Rows(0).Item("MUTABARR")))
            Me.txtMUTAMANZ.Text = CStr(Trim(tbl.Rows(0).Item("MUTAMANZ")))
            Me.txtMUTAPRED.Text = CStr(Trim(tbl.Rows(0).Item("MUTAPRED")))
            Me.txtMUTAEDIF.Text = CStr(Trim(tbl.Rows(0).Item("MUTAEDIF")))
            Me.txtMUTAUNPR.Text = CStr(Trim(tbl.Rows(0).Item("MUTAUNPR")))
            Me.txtMUTAFEES.Text = CStr(Trim(tbl.Rows(0).Item("MUTAFEES")))
            Me.txtMUTAESCR.Text = CStr(Trim(tbl.Rows(0).Item("MUTAESCR")))
            Me.txtMUTAFERA.Text = CStr(Trim(tbl.Rows(0).Item("MUTAFERA")))
            Me.txtMUTANURA.Text = CStr(Trim(tbl.Rows(0).Item("MUTANURA")))
            Me.txtMUTAFERE.Text = CStr(Trim(tbl.Rows(0).Item("MUTAFERE")))
            Me.txtMUTANURE.Text = CStr(Trim(tbl.Rows(0).Item("MUTANURE")))
            Me.txtMUTAOBSE.Text = CStr(Trim(tbl.Rows(0).Item("MUTAOBSE")))
            Me.cboMUTAVIGE.SelectedValue = tbl.Rows(0).Item("MUTAVIGE")
            Me.cboMUTACLSE.SelectedValue = tbl.Rows(0).Item("MUTACLSE")
            Me.cboMUTAESTA.SelectedValue = tbl.Rows(0).Item("MUTAESTA")
            Me.txtMUTADESC.Text = CStr(Trim(tbl.Rows(0).Item("MUTADESC")))
            Me.txtMUTAVACO.Text = fun_Formato_Mascara_Pesos_Enteros(CStr(Trim(tbl.Rows(0).Item("MUTAVACO"))))

            If fun_Verificar_Dato_Fecha_Evento_Validated(Me.txtMUTAFEES.Text) = True Then
                Me.dtpMUTAFEES.Value = CDate(tbl.Rows(0).Item("MUTAFEES"))
            End If

            If fun_Verificar_Dato_Fecha_Evento_Validated(Me.dtpMUTAFERA.Text) = True Then
                Me.dtpMUTAFERA.Value = CDate(tbl.Rows(0).Item("MUTAFERA"))
            End If

            Dim boTRCAVIGE As Boolean = fun_Buscar_Dato_VIGENCIA(Me.cboMUTAVIGE.SelectedValue)
            Dim boTRCACLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboMUTACLSE.SelectedValue)

            If boTRCAVIGE = True OrElse _
               boTRCACLSE = True Then

                Me.lblMUTAVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboMUTAVIGE), String)
                Me.lblMUTACLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboMUTACLSE), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboMUTACLSE.DataSource = New DataTable
        Me.cboMUTAVIGE.DataSource = New DataTable
        Me.cboMUTAESTA.DataSource = New DataTable

        Me.txtMUTASECU.Text = "0"
        Me.txtMUTAESCR.Text = "0"
        Me.txtMUTANURA.Text = "0"
        Me.txtMUTANURE.Text = "0"
        Me.lblMUTACLSE.Text = ""
        Me.lblMUTAVIGE.Text = ""
        Me.txtMUTAMUNI.Text = "266"
        Me.txtMUTACORR.Text = "01"
        Me.txtMUTABARR.Text = ""
        Me.txtMUTAMANZ.Text = ""
        Me.txtMUTAPRED.Text = ""
        Me.txtMUTAEDIF.Text = ""
        Me.txtMUTAUNPR.Text = ""
        Me.txtMUTAFEES.Text = ""
        Me.txtMUTAFERA.Text = ""
        Me.txtMUTAFERE.Text = ""
        Me.txtMUTAOBSE.Text = ""
        Me.txtMUTAOBSE_NUEVAS.Text = ""
        Me.txtMUTADESC.Text = ""
        Me.txtMUTANUFI.Text = ""
        Me.txtMUTAMAIN.Text = ""
        Me.txtMUTAVACO.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            Me.txtMUTAVACO.Text = fun_Quita_Letras(Me.txtMUTAVACO)

            ' instancia la clase
            Dim objdatos As New cla_MUTACIONES

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boMUTANUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMUTANUFI)
            Dim boMUTAMAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMUTAMAIN)
            Dim boMUTAMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMUTAMUNI)
            Dim boMUTACORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMUTACORR)
            Dim boMUTABARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMUTABARR)
            Dim boMUTAMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMUTAMANZ)
            Dim boMUTAPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMUTAPRED)
            Dim boMUTAEDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMUTAEDIF)
            Dim boMUTAUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMUTAUNPR)
            Dim boMUTAESCR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMUTAESCR)
            Dim boMUTANURA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMUTANURA)
            Dim boMUTAVACO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMUTAVACO)
            Dim boMUTAFEES As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtMUTAFEES)
            Dim boMUTACLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMUTACLSE)
            Dim boMUTAVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMUTAVIGE)
            Dim boMUTAESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMUTAESTA)

            Dim stMUTAOBSE_NUEVA As String = Trim(Me.txtMUTAOBSE_NUEVAS.Text)

            If Trim(stMUTAOBSE_NUEVA) <> "" Then
                Me.txtMUTAOBSE.Text += " Nota ingresada por: " & vp_usuario & " " & fun_fecha() & " : " & stMUTAOBSE_NUEVA & ". "
            End If

            ' verifica los datos del formulario 
            If boMUTANUFI = True And _
               boMUTAMAIN = True And _
               boMUTAMUNI = True And _
               boMUTACORR = True And _
               boMUTABARR = True And _
               boMUTAMANZ = True And _
               boMUTAPRED = True And _
               boMUTAEDIF = True And _
               boMUTAUNPR = True And _
               boMUTACLSE = True And _
               boMUTAVIGE = True And _
               boMUTAESCR = True And _
               boMUTAFEES = True And _
               boMUTANURA = True And _
               boMUTAVACO = True And _
               boMUTAESTA = True Then

                Dim objdatos22 As New cla_MUTACIONES

                If (objdatos22.fun_Actualizar_MUTACIONES(inID_REGISTRO, _
                                                         Me.txtMUTASECU.Text, _
                                                         Me.txtMUTANUFI.Text, _
                                                         Me.txtMUTAMUNI.Text, _
                                                         Me.txtMUTACORR.Text, _
                                                         Me.txtMUTABARR.Text, _
                                                         Me.txtMUTAMANZ.Text, _
                                                         Me.txtMUTAPRED.Text, _
                                                         Me.txtMUTAEDIF.Text, _
                                                         Me.txtMUTAUNPR.Text, _
                                                         Me.cboMUTACLSE.SelectedValue, _
                                                         Me.cboMUTAVIGE.SelectedValue, _
                                                         Me.txtMUTAFEES.Text, _
                                                         Me.txtMUTAESCR.Text, _
                                                         Me.txtMUTANURA.Text, _
                                                         Me.txtMUTAFERA.Text, _
                                                         Trim(Me.txtMUTAOBSE.Text), _
                                                         Me.cboMUTAESTA.SelectedValue, _
                                                         Me.txtMUTADESC.Text, _
                                                         Me.txtMUTAMAIN.Text, _
                                                         Me.txtMUTAVACO.Text, _
                                                         Me.txtMUTANURE.Text, _
                                                         Me.txtMUTAFERE.Text)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(7)

                    If tblRutas.Rows.Count > 0 Then

                        Dim stRuta As String = Me.txtMUTAMUNI.Text & "-" & Me.cboMUTACLSE.SelectedValue & "-" & Me.txtMUTACORR.Text & "-" & Me.txtMUTABARR.Text & "-" & Me.txtMUTAMANZ.Text & "-" & Me.txtMUTAPRED.Text & "-" & Me.txtMUTAEDIF.Text & "-" & Me.txtMUTAUNPR.Text & "-" & Me.cboMUTAVIGE.SelectedValue

                        If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                            System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                        End If

                    End If

                    Dim objdatos1 As New cla_MUTACIONES
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_CODIGO_X_MUTACIONES(CInt(Me.txtMUTASECU.Text))

                    If tbl1.Rows.Count > 0 Then

                        Dim inNroIdRe As New frm_MUTACIONES(tbl1.Rows(0).Item("MUTAIDRE"))

                    End If

                    Me.txtMUTANUFI.Focus()
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
        Dim inNroIdRe As New frm_MUTACIONES(inID_REGISTRO)
        Me.txtMUTANUFI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMUTAFEES.KeyPress, txtMUTAESCR.KeyPress, txtMUTANURA.KeyPress, txtMUTAFERA.KeyPress, cboMUTAESTA.KeyPress, txtMUTAOBSE.KeyPress, txtMUTANUFI.KeyPress, txtMUTAMUNI.KeyPress, txtMUTACORR.KeyPress, txtMUTABARR.KeyPress, txtMUTAMANZ.KeyPress, txtMUTAPRED.KeyPress, txtMUTAEDIF.KeyPress, txtMUTAUNPR.KeyPress, cboMUTACLSE.KeyPress, cboMUTAESTA.KeyPress, cboMUTAVIGE.KeyPress, txtMUTADESC.KeyPress, txtMUTAOBSE.KeyPress, txtMUTAMAIN.KeyPress, txtMUTAVACO.KeyPress, txtMUTANURE.KeyPress, txtMUTAFERE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboMUTACLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMUTACLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboMUTACLSE, Me.cboMUTACLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboMUTAVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMUTAVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboMUTAVIGE, Me.cboMUTAVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboMUTAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMUTAESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboMUTAESTA, Me.cboMUTAESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUTAMUNI.GotFocus, txtMUTACORR.GotFocus, txtMUTABARR.GotFocus, txtMUTAMANZ.GotFocus, txtMUTAPRED.GotFocus, txtMUTAFEES.GotFocus, txtMUTAESCR.GotFocus, txtMUTAOBSE.GotFocus, txtMUTAEDIF.GotFocus, txtMUTAUNPR.GotFocus, txtMUTANUFI.GotFocus, txtMUTAMAIN.GotFocus, txtMUTAFERA.GotFocus, txtMUTANURA.GotFocus, txtMUTAVACO.GotFocus, txtMUTANURE.GotFocus, txtMUTAFERE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMUTACLSE.GotFocus, cboMUTAVIGE.GotFocus, cboMUTAESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboMUTACLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMUTACLSE.SelectedIndexChanged
        Me.lblMUTACLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboMUTACLSE), String)
    End Sub
    Private Sub cboMUTAVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMUTAVIGE.SelectedIndexChanged
        Me.lblMUTAVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboMUTAVIGE), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboMUTACLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMUTACLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboMUTACLSE, Me.cboMUTACLSE.SelectedIndex)
    End Sub
    Private Sub cboMUTAVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMUTAVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboMUTAVIGE, Me.cboMUTAVIGE.SelectedIndex)
    End Sub
    Private Sub cboMUTAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMUTAESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboMUTAESTA, Me.cboMUTAESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTAPEAVFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUTAESCR.Validated, txtMUTANURA.Validated, txtMUTANURE.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        End If

    End Sub

    Private Sub txtMUTAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUTAMUNI.Validated
        If Me.txtMUTAMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMUTAMUNI.Text) = True Then
            Me.txtMUTAMUNI.Text = fun_Formato_Mascara_3_String(Me.txtMUTAMUNI.Text)
        End If
    End Sub
    Private Sub txtMUTACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUTACORR.Validated
        If Me.txtMUTACORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMUTACORR.Text) = True Then
            Me.txtMUTACORR.Text = fun_Formato_Mascara_2_String(Me.txtMUTACORR.Text)
        End If
    End Sub
    Private Sub txtMUTABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUTABARR.Validated
        If Me.txtMUTABARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMUTABARR.Text) = True Then
            Me.txtMUTABARR.Text = fun_Formato_Mascara_3_String(Me.txtMUTABARR.Text)
        End If
    End Sub
    Private Sub txtMUTAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUTAMANZ.Validated
        If Me.txtMUTAMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMUTAMANZ.Text) = True Then
            Me.txtMUTAMANZ.Text = fun_Formato_Mascara_3_String(Me.txtMUTAMANZ.Text)
        End If
    End Sub
    Private Sub txtMUTAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUTAPRED.Validated
        If Me.txtMUTAPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMUTAPRED.Text) = True Then
            Me.txtMUTAPRED.Text = fun_Formato_Mascara_5_String(Me.txtMUTAPRED.Text)
        End If
    End Sub
    Private Sub txtMUTAEDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUTAEDIF.Validated
        If Me.txtMUTAEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMUTAEDIF.Text) = True Then
            Me.txtMUTAEDIF.Text = fun_Formato_Mascara_3_String(Me.txtMUTAEDIF.Text)
        End If
    End Sub
    Private Sub txtMUTAUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUTAUNPR.Validated
        If Me.txtMUTAUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMUTAUNPR.Text) = True Then
            Me.txtMUTAUNPR.Text = fun_Formato_Mascara_5_String(Me.txtMUTAUNPR.Text)
        End If
    End Sub
    Private Sub txtMUTAVACO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUTAVACO.Validated
        If Trim(sender.text) = "" Then
            sender.text = "0"
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMUTAVACO.Text) = True Then
                Me.txtMUTAVACO.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtMUTAVACO.Text)
            End If

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

    Private Sub dtpTRCAFEES_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpMUTAFEES.ValueChanged
        Me.txtMUTAFEES.Text = Me.dtpMUTAFEES.Value
    End Sub
    Private Sub dtpMUTAFERA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpMUTAFERA.ValueChanged
        Me.txtMUTAFERA.Text = Me.dtpMUTAFERA.Value
    End Sub
    Private Sub dtpMUTAFERE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpMUTAFERE.ValueChanged
        Me.txtMUTAFERE.Text = Me.dtpMUTAFERE.Value
    End Sub

#End Region


#End Region

  
End Class