Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_AJUSIMPR

    '========================================
    '*** INSERTAR AJUSTE IMPUESTO PREDIAL ***
    '========================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_ConsultarNroFichaYMatricula()

        Try

            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtAJIPMUNI.Text)) = True And _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.cboAJIPCLSE.SelectedValue)) = True And _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtAJIPCORR.Text)) = True And _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtAJIPBARR.Text)) = True And _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtAJIPMANZ.Text)) = True And _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtAJIPPRED.Text)) = True And _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtAJIPEDIF.Text)) = True And _
               fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtAJIPUNPR.Text)) = True Then

                Dim obFICHPRED As New cla_FICHPRED
                Dim dtFICHPRED As New DataTable

                dtFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_x_CEDULA(Trim(Me.txtAJIPMUNI.Text), _
                                                                             Trim(Me.cboAJIPCLSE.SelectedValue), _
                                                                             Trim(Me.txtAJIPCORR.Text), _
                                                                             Trim(Me.txtAJIPBARR.Text), _
                                                                             Trim(Me.txtAJIPMANZ.Text), _
                                                                             Trim(Me.txtAJIPPRED.Text), _
                                                                             Trim(Me.txtAJIPEDIF.Text), _
                                                                             Trim(Me.txtAJIPUNPR.Text), 0)

                If dtFICHPRED.Rows.Count > 0 Then

                    Me.txtAJIPNUFI.Text = dtFICHPRED.Rows(0).Item("FIPRNUFI")

                    Dim obFIPRPROP As New cla_FIPRPROP
                    Dim dtFIPRPROP As New DataTable

                    dtFIPRPROP = obFIPRPROP.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(dtFICHPRED.Rows(0).Item("FIPRNUFI"))

                    If dtFIPRPROP.Rows.Count > 0 Then

                        Me.txtAJIPMAIN.Text = dtFIPRPROP.Rows(0).Item("FPPRMAIN")

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboAJIPCLSE.DataSource = New DataTable
        Me.cboAJIPVIGE.DataSource = New DataTable
        Me.cboAJIPTITR.DataSource = New DataTable
        Me.cboAJIPMERE.DataSource = New DataTable
        Me.cboAJIPESTA.DataSource = New DataTable
        Me.cboAJIPCLAS.DataSource = New DataTable
        Me.cboAJIPREAJ.DataSource = New DataTable

        Me.txtAJIPSECU.Text = ""
        Me.lblAJIPCLSE.Text = ""
        Me.lblAJIPVIGE.Text = ""
        Me.lblRECLTITR.Text = ""
        Me.lblAJIPTITR.Text = ""
        Me.lblAJIPCLAS.Text = ""
        Me.lblAJIPREAJ.Text = ""
        Me.lblAJIPMERE.Text = ""
        Me.txtAJIPMUNI.Text = "266"
        Me.txtAJIPCORR.Text = "01"
        Me.txtAJIPBARR.Text = ""
        Me.txtAJIPMANZ.Text = ""
        Me.txtAJIPPRED.Text = ""
        Me.txtAJIPEDIF.Text = ""
        Me.txtAJIPUNPR.Text = ""
        Me.txtAJIPOBSE.Text = ""
        Me.txtAJIPMAIN.Text = ""
        Me.txtAJIPNUFI.Text = ""
        Me.txtAJIPNURA.Text = "0"
        Me.txtAJIPFERA.Text = ""
        Me.txtAJIPNURE.Text = "0"
        Me.txtAJIPFERE.Text = ""
        Me.txtAJIPNUOF.Text = "0"
        Me.txtAJIPFEOF.Text = ""
        Me.txtAJIPOBSE.Text = ""

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_NumeroDeSecuenciaDeRegistro() As Integer

        Try
            Dim inFPDESECU As Integer = 0

            Dim objdatos5 As New cla_AJUSIMPR
            Dim tbl10 As New DataTable

            tbl10 = objdatos5.fun_Buscar_SECUENCIA_X_AJUSIMPR

            If tbl10.Rows.Count = 0 Then
                inFPDESECU = 1
            Else
                Dim i As Integer
                Dim NroMayor As Integer
                Dim Posicion As Integer

                Posicion = Val(tbl10.Rows(0).Item("AJIPSECU"))

                For i = 0 To tbl10.Rows.Count - 1
                    NroMayor = Val(tbl10.Rows(i).Item("AJIPSECU"))

                    If NroMayor > Posicion Then
                        inFPDESECU = NroMayor
                        Posicion = NroMayor
                    Else
                        inFPDESECU = Posicion
                    End If
                Next

                inFPDESECU += 1
            End If

            Return inFPDESECU

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_AJUSIMPR

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_AJUSIMPR(Me.txtAJIPNUFI, Me.txtAJIPNURE, Me.txtAJIPFERE)
            boLLAVEPRIMARIA = True

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boCECAMUNI As Boolean = objVerifica.fun_Verificar_Dato_Municipio(vp_Departamento, Me.txtAJIPMUNI.Text)
            Dim boCECACORR As Boolean = objVerifica.fun_Verificar_Dato_Corregimiento(vp_Departamento, Me.txtAJIPMUNI.Text, Me.cboAJIPCLSE.SelectedValue, Me.txtAJIPCORR.Text)
            Dim boCECABARR As Boolean = False

            If Me.cboAJIPCLSE.SelectedValue = 1 Then
                boCECABARR = objVerifica.fun_Verificar_Dato_BarrioVereda(vp_Departamento, Me.txtAJIPMUNI.Text, Me.cboAJIPCLSE.SelectedValue, Me.txtAJIPCORR.Text, Me.txtAJIPBARR.Text)

            ElseIf Me.cboAJIPCLSE.SelectedValue = 2 Then
                boCECABARR = objVerifica.fun_Verificar_Dato_BarrioVereda(vp_Departamento, Me.txtAJIPMUNI.Text, Me.cboAJIPCLSE.SelectedValue, Me.txtAJIPCORR.Text, Me.txtAJIPMANZ.Text)
            End If
           
            Dim boRECLMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtAJIPMUNI)
            Dim boRECLCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtAJIPCORR)
            Dim boRECLBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtAJIPBARR)
            Dim boRECLMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtAJIPMANZ)
            Dim boRECLPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtAJIPPRED)
            Dim boRECLEDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtAJIPEDIF)
            Dim boRECLUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtAJIPUNPR)

            Dim boRECLNUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtAJIPNUFI)
            Dim boRECLNURE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtAJIPNURE)
            Dim boRECLFERE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtAJIPFERE)
            boRECLFERE = True

            Dim boRECLMAIN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtAJIPMAIN)
            Dim boRECLCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboAJIPCLSE)
            Dim boRECLVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboAJIPVIGE)
            Dim boRECLTITR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboAJIPTITR)
            Dim boRECLESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboAJIPESTA)
            Dim boRECLCLAS As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboAJIPCLAS)
            Dim boRECLMERE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboAJIPMERE)
            Dim boRECLREAJ As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboAJIPREAJ)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boCECAMUNI = True And _
               boCECACORR = True And _
               boCECABARR = True And _
               boRECLMUNI = True And _
               boRECLCORR = True And _
               boRECLBARR = True And _
               boRECLMANZ = True And _
               boRECLPRED = True And _
               boRECLEDIF = True And _
               boRECLNUFI = True And _
               boRECLNURE = True And _
               boRECLFERE = True And _
               boRECLUNPR = True And _
               boRECLMAIN = True And _
               boRECLCLSE = True And _
               boRECLVIGE = True And _
               boRECLTITR = True And _
               boRECLESTA = True And _
               boRECLMERE = True And _
               boRECLREAJ = True And _
               boRECLCLAS = True Then

                Dim stAJIPFECH As String = fun_fecha()
                stAJIPFECH = stAJIPFECH.ToString.Replace("/", "-")
                stAJIPFECH = stAJIPFECH.ToString.Substring(0, 10)

                If Trim(Me.txtAJIPOBSE.Text) <> "" Then
                    Me.txtAJIPOBSE.Text = " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & Trim(Me.txtAJIPOBSE.Text) & ". "
                End If

                Dim stAJIPUSUD As String = ""

                Dim objdatos22 As New cla_AJUSIMPR

                If (objdatos22.fun_Insertar_AJUSIMPR(Me.txtAJIPNUFI.Text, _
                                                     vp_Departamento, _
                                                     Me.txtAJIPMUNI.Text, _
                                                     Me.txtAJIPCORR.Text, _
                                                     Me.txtAJIPBARR.Text, _
                                                     Me.txtAJIPMANZ.Text, _
                                                     Me.txtAJIPPRED.Text, _
                                                     Me.txtAJIPEDIF.Text, _
                                                     Me.txtAJIPUNPR.Text, _
                                                     Me.cboAJIPCLSE.SelectedValue, _
                                                     Me.cboAJIPVIGE.SelectedValue, _
                                                     Me.txtAJIPMAIN.Text, _
                                                     Me.txtAJIPSECU.Text, _
                                                     stAJIPFECH, _
                                                     Me.cboAJIPCLAS.SelectedValue, _
                                                     Me.cboAJIPTITR.SelectedValue, _
                                                     Me.cboAJIPMERE.SelectedValue, _
                                                     Me.cboAJIPREAJ.SelectedValue, _
                                                     "", _
                                                     "", _
                                                     "", _
                                                     "", _
                                                     vp_cedula, _
                                                     "", _
                                                     Me.txtAJIPNURA.Text, _
                                                     Me.txtAJIPFERA.Text, _
                                                     Me.txtAJIPNURE.Text, _
                                                     Me.txtAJIPFERE.Text, _
                                                     Me.txtAJIPNUOF.Text, _
                                                     Me.txtAJIPFEOF.Text, _
                                                     Me.txtAJIPOBSE.Text, _
                                                     Me.cboAJIPESTA.SelectedValue, _
                                                     Me.cboAJIPESTA.SelectedValue, _
                                                     stAJIPUSUD)) = True Then

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(11)

                    If tblRutas.Rows.Count > 0 Then

                        Dim stRuta As String = Me.txtAJIPMUNI.Text & "-" & Me.cboAJIPCLSE.SelectedValue & "-" & Me.txtAJIPCORR.Text & "-" & Me.txtAJIPBARR.Text & "-" & Me.txtAJIPMANZ.Text & "-" & Me.txtAJIPPRED.Text & "-" & Me.txtAJIPEDIF.Text & "-" & Me.txtAJIPUNPR.Text & "-" & Me.cboAJIPVIGE.SelectedValue

                        If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                            System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                        End If

                    End If

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then

                        Dim objdatos1 As New cla_AJUSIMPR
                        Dim tbl1 As New DataTable

                        tbl1 = objdatos1.fun_Buscar_CODIGO_X_AJUSIMPR(CInt(Me.txtAJIPSECU.Text))

                        If tbl1.Rows.Count > 0 Then

                            Dim inNroIdRe As New frm_AJUSIMPR(tbl1.Rows(0).Item("AJIPIDRE"))

                        End If

                        Me.txtAJIPMUNI.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.txtAJIPSECU.Text = fun_NumeroDeSecuenciaDeRegistro()
                        Me.txtAJIPMUNI.Focus()
                    End If

                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Dim inNroIdRe As New frm_AJUSIMPR(0)
        Me.txtAJIPMUNI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_TRABCAMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtAJIPSECU.Text = fun_NumeroDeSecuenciaDeRegistro()

        Me.dtpAJIPFERA.MaxDate = DateTime.Today
        Me.dtpAJIPFERE.MaxDate = DateTime.Today
        Me.dtpAJIPFEOF.MaxDate = DateTime.Today

        Me.txtAJIPFERA.Text = ""
        Me.txtAJIPFERE.Text = ""
        Me.txtAJIPFEOF.Text = ""

        Me.txtAJIPMUNI.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAJIPMUNI.KeyPress, txtAJIPCORR.KeyPress, txtAJIPBARR.KeyPress, txtAJIPMANZ.KeyPress, txtAJIPPRED.KeyPress, txtAJIPEDIF.KeyPress, txtAJIPUNPR.KeyPress, cboAJIPCLSE.KeyPress, cboAJIPVIGE.KeyPress, txtAJIPMAIN.KeyPress, txtAJIPNURA.KeyPress, txtAJIPFERA.KeyPress, txtAJIPFERE.KeyPress, txtAJIPNURE.KeyPress, txtAJIPNUOF.KeyPress, txtAJIPFEOF.KeyPress, cboAJIPTITR.KeyPress, cboAJIPCLAS.KeyPress, cboAJIPMERE.KeyPress, cboAJIPREAJ.KeyPress, txtAJIPNUFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTRCACLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAJIPCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboAJIPCLSE, Me.cboAJIPCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCAVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAJIPVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboAJIPVIGE, Me.cboAJIPVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboRECLTITR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAJIPTITR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOTRAM_Descripcion(Me.cboAJIPTITR, Me.cboAJIPTITR.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAJIPESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboAJIPESTA, Me.cboAJIPESTA.SelectedIndex)
        End If
    End Sub
    Private Sub cboAJIPCLAS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAJIPCLAS.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASIFICACION_Descripcion(Me.cboAJIPCLAS, Me.cboAJIPCLAS.SelectedIndex)
        End If
    End Sub
    Private Sub cboAJIPMERE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAJIPMERE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MEDIRESE_Descripcion(Me.cboAJIPMERE, Me.cboAJIPMERE.SelectedIndex)
        End If
    End Sub
    Private Sub cboAJIPREAJ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAJIPREAJ.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_RESOAJUS_Descripcion(Me.cboAJIPREAJ, Me.cboAJIPREAJ.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIPMUNI.GotFocus, txtAJIPCORR.GotFocus, txtAJIPBARR.GotFocus, txtAJIPMANZ.GotFocus, txtAJIPPRED.GotFocus, txtAJIPEDIF.GotFocus, txtAJIPUNPR.GotFocus, txtAJIPMAIN.GotFocus, txtAJIPNURA.GotFocus, txtAJIPFERA.GotFocus, txtAJIPFERE.GotFocus, txtAJIPNURE.GotFocus, txtAJIPNUOF.GotFocus, txtAJIPFEOF.GotFocus, txtAJIPOBSE.GotFocus, txtAJIPNUFI.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAJIPCLSE.GotFocus, cboAJIPVIGE.GotFocus, cboAJIPTITR.GotFocus, cboAJIPESTA.GotFocus, cboAJIPCLAS.GotFocus, cboAJIPREAJ.GotFocus, cboAJIPMERE.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTRCACLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAJIPCLSE.SelectedIndexChanged
        Me.lblAJIPCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboAJIPCLSE), String)
    End Sub
    Private Sub cboTRCAVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAJIPVIGE.SelectedIndexChanged
        Me.lblAJIPVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboAJIPVIGE), String)
    End Sub
    Private Sub cboRECLTITR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAJIPTITR.SelectedIndexChanged
        Me.lblAJIPTITR.Text = CType(fun_Buscar_Lista_Valores_TIPOTRAM_Codigo(Me.cboAJIPTITR), String)
    End Sub
    Private Sub cboAJIPCLAS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAJIPCLAS.SelectedIndexChanged
        Me.lblAJIPCLAS.Text = CType(fun_Buscar_Lista_Valores_SOLICITANTE_Codigo(Me.cboAJIPCLAS), String)
    End Sub
    Private Sub cboAJIPMERE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAJIPMERE.SelectedIndexChanged
        Me.lblAJIPMERE.Text = CType(fun_Buscar_Lista_Valores_MEDIRESE_Codigo(Me.cboAJIPMERE), String)
    End Sub
    Private Sub cboAJIPREAJ_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAJIPREAJ.SelectedIndexChanged
        Me.lblAJIPREAJ.Text = CType(fun_Buscar_Lista_Valores_RESOAJUS_Codigo(Me.cboAJIPREAJ), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTRCACLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAJIPCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboAJIPCLSE, Me.cboAJIPCLSE.SelectedIndex)
    End Sub
    Private Sub cboTRCAVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAJIPVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboAJIPVIGE, Me.cboAJIPVIGE.SelectedIndex)
    End Sub
    Private Sub cboRECLTITR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAJIPTITR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOTRAM_Descripcion(Me.cboAJIPTITR, Me.cboAJIPTITR.SelectedIndex)
    End Sub
    Private Sub cboTRCAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAJIPESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboAJIPESTA, Me.cboAJIPESTA.SelectedIndex)
    End Sub
    Private Sub cboAJIPCLAS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAJIPCLAS.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASIFICACION_Descripcion(Me.cboAJIPCLAS, Me.cboAJIPCLAS.SelectedIndex)
    End Sub
    Private Sub cboAJIPMERE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAJIPMERE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MEDIRESE_Descripcion(Me.cboAJIPMERE, Me.cboAJIPMERE.SelectedIndex)
    End Sub
    Private Sub cboAJIPREAJ_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAJIPREAJ.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_RESOAJUS_Descripcion(Me.cboAJIPREAJ, Me.cboAJIPREAJ.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTAPEAVFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIPNURA.Validated, txtAJIPNURE.Validated, txtAJIPNUOF.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        End If

    End Sub

    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIPMUNI.Validated
        If Me.txtAJIPMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtAJIPMUNI.Text) = True Then
            Me.txtAJIPMUNI.Text = fun_Formato_Mascara_3_String(Me.txtAJIPMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIPCORR.Validated
        If Me.txtAJIPCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtAJIPCORR.Text) = True Then
            Me.txtAJIPCORR.Text = fun_Formato_Mascara_2_String(Me.txtAJIPCORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIPBARR.Validated
        If Me.txtAJIPBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtAJIPBARR.Text) = True Then
            Me.txtAJIPBARR.Text = fun_Formato_Mascara_3_String(Me.txtAJIPBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIPMANZ.Validated
        If Me.txtAJIPMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtAJIPMANZ.Text) = True Then
            Me.txtAJIPMANZ.Text = fun_Formato_Mascara_3_String(Me.txtAJIPMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIPPRED.Validated
        If Me.txtAJIPPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtAJIPPRED.Text) = True Then
            Me.txtAJIPPRED.Text = fun_Formato_Mascara_5_String(Me.txtAJIPPRED.Text)
        End If
    End Sub
    Private Sub txtRECLEDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIPEDIF.Validated
        If Me.txtAJIPEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtAJIPEDIF.Text) = True Then
            Me.txtAJIPEDIF.Text = fun_Formato_Mascara_3_String(Me.txtAJIPEDIF.Text)
        End If
    End Sub
    Private Sub txtRECLUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIPUNPR.Validated
        If Me.txtAJIPUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtAJIPUNPR.Text) = True Then
            Me.txtAJIPUNPR.Text = fun_Formato_Mascara_5_String(Me.txtAJIPUNPR.Text)
        End If
    End Sub
    Private Sub cboAJIPCLSE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAJIPCLSE.Validated
        pro_ConsultarNroFichaYMatricula()
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

    Private Sub dtpRECLFEDE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpAJIPFERA.ValueChanged
        Me.txtAJIPFERA.Text = Me.dtpAJIPFERA.Value
    End Sub
    Private Sub dtpRECLFEMU_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpAJIPFERE.ValueChanged
        Me.txtAJIPFERE.Text = Me.dtpAJIPFERE.Value
    End Sub
    Private Sub dtpRECLFEED_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpAJIPFEOF.ValueChanged
        Me.txtAJIPFEOF.Text = Me.dtpAJIPFEOF.Value
    End Sub

#End Region

#End Region

End Class