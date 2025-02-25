Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_AJUSIMPR

    '=========================================
    '*** MODIFICAR AJUSTE IMPUESTO PREDIAL ***
    '=========================================


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
            Me.dtpAJIPFERE.Value = fun_fecha()
            Me.dtpAJIPFERA.Value = fun_fecha()
            Me.dtpAJIPFEOF.Value = fun_fecha()

            Dim objdatos1 As New cla_CLASSECT

            Me.cboAJIPCLSE.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboAJIPCLSE.DisplayMember = "CLSEDESC"
            Me.cboAJIPCLSE.ValueMember = "CLSECODI"

            Dim objdatos2 As New cla_VIGENCIA

            Me.cboAJIPVIGE.DataSource = objdatos2.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboAJIPVIGE.DisplayMember = "VIGEDESC"
            Me.cboAJIPVIGE.ValueMember = "VIGECODI"

            Dim objdatos3 As New cla_TIPOTRAM

            Me.cboAJIPTITR.DataSource = objdatos3.fun_Consultar_CAMPOS_MANT_TIPOTRAM
            Me.cboAJIPTITR.DisplayMember = "TITRDESC"
            Me.cboAJIPTITR.ValueMember = "TITRCODI"

            Dim objdatos9 As New cla_CLASIFICACION

            Me.cboAJIPCLAS.DataSource = objdatos9.fun_Consultar_CAMPOS_MANT_CLASIFICACION
            Me.cboAJIPCLAS.DisplayMember = "CLASDESC"
            Me.cboAJIPCLAS.ValueMember = "CLASCODI"

            Dim objdatos94 As New cla_RESOAJUS

            Me.cboAJIPREAJ.DataSource = objdatos94.fun_Consultar_CAMPOS_MANT_RESOAJUS
            Me.cboAJIPREAJ.DisplayMember = "REAJDESC"
            Me.cboAJIPREAJ.ValueMember = "REAJCODI"

            Dim objdatos95 As New cla_MEDIRESE

            Me.cboAJIPMERE.DataSource = objdatos95.fun_Consultar_CAMPOS_MANT_MEDIRESE
            Me.cboAJIPMERE.DisplayMember = "MEREDESC"
            Me.cboAJIPMERE.ValueMember = "MERECODI"

            Dim objdatos7 As New cla_ESTADO

            Me.cboAJIPESTA.DataSource = objdatos7.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboAJIPESTA.DisplayMember = "ESTADESC"
            Me.cboAJIPESTA.ValueMember = "ESTACODI"

            Dim objdatos8 As New cla_AJUSIMPR
            Dim tbl As New DataTable

            tbl = objdatos8.fun_Buscar_ID_AJUSIMPR(inID_REGISTRO)

            Me.txtAJIPSECU.Text = Trim(tbl.Rows(0).Item("AJIPSECU"))
            Me.txtAJIPMUNI.Text = Trim(tbl.Rows(0).Item("AJIPMUNI"))
            Me.txtAJIPCORR.Text = Trim(tbl.Rows(0).Item("AJIPCORR"))
            Me.txtAJIPBARR.Text = Trim(tbl.Rows(0).Item("AJIPBARR"))
            Me.txtAJIPMANZ.Text = Trim(tbl.Rows(0).Item("AJIPMANZ"))
            Me.txtAJIPPRED.Text = Trim(tbl.Rows(0).Item("AJIPPRED"))
            Me.txtAJIPEDIF.Text = Trim(tbl.Rows(0).Item("AJIPEDIF"))
            Me.txtAJIPUNPR.Text = Trim(tbl.Rows(0).Item("AJIPUNPR"))
            Me.cboAJIPVIGE.SelectedValue = tbl.Rows(0).Item("AJIPVIGE")
            Me.cboAJIPCLSE.SelectedValue = tbl.Rows(0).Item("AJIPCLSE")
            Me.cboAJIPCLAS.SelectedValue = tbl.Rows(0).Item("AJIPCLAS")
            Me.cboAJIPTITR.SelectedValue = tbl.Rows(0).Item("AJIPTITR")
            Me.cboAJIPMERE.SelectedValue = tbl.Rows(0).Item("AJIPMERE")
            Me.cboAJIPREAJ.SelectedValue = tbl.Rows(0).Item("AJIPREAJ")
            Me.txtAJIPNURA.Text = Trim(tbl.Rows(0).Item("AJIPNURA"))
            Me.txtAJIPFERA.Text = Trim(tbl.Rows(0).Item("AJIPFERA"))
            Me.txtAJIPNURE.Text = Trim(tbl.Rows(0).Item("AJIPNURE"))
            Me.txtAJIPFERE.Text = Trim(tbl.Rows(0).Item("AJIPFERE"))
            Me.txtAJIPNUOF.Text = Trim(tbl.Rows(0).Item("AJIPNUOF"))
            Me.txtAJIPFEOF.Text = Trim(tbl.Rows(0).Item("AJIPFEOF"))
            Me.txtAJIPMAIN.Text = Trim(tbl.Rows(0).Item("AJIPMAIN"))
            Me.txtAJIPNUFI.Text = Trim(tbl.Rows(0).Item("AJIPNUFI"))
            Me.cboAJIPESTA.SelectedValue = tbl.Rows(0).Item("AJIPESTA")
            Me.txtAJIPOBSE.Text = Trim(tbl.Rows(0).Item("AJIPOBSE"))

            Dim boAJIPVIGE As Boolean = fun_Buscar_Dato_VIGENCIA(Me.cboAJIPVIGE.SelectedValue)
            Dim boAJIPCLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboAJIPCLSE.SelectedValue)
            Dim boAJIPTITR As Boolean = fun_Buscar_Dato_TIPOTRAM(Me.cboAJIPTITR.SelectedValue)
            Dim boAJIPCLAS As Boolean = fun_Buscar_Dato_CLASIFICACION(Me.cboAJIPCLAS.SelectedValue)
            Dim boAJIPREAJ As Boolean = fun_Buscar_Dato_RESOAJUS(Me.cboAJIPREAJ.SelectedValue)
            Dim boAJIPMERE As Boolean = fun_Buscar_Dato_MEDIRESE(Me.cboAJIPMERE.SelectedValue)

            If boAJIPVIGE = True OrElse _
               boAJIPCLSE = True OrElse _
               boAJIPCLAS = True OrElse _
               boAJIPREAJ = True OrElse _
               boAJIPMERE = True OrElse _
               boAJIPTITR = True Then

                Me.lblAJIPVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboAJIPVIGE), String)
                Me.lblAJIPCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboAJIPCLSE), String)
                Me.lblAJIPTITR.Text = CType(fun_Buscar_Lista_Valores_TIPOTRAM_Codigo(Me.cboAJIPTITR), String)
                Me.lblAJIPCLAS.Text = CType(fun_Buscar_Lista_Valores_CLASIFICACION_Codigo(Me.cboAJIPCLAS), String)
                Me.lblAJIPMERE.Text = CType(fun_Buscar_Lista_Valores_MEDIRESE_Codigo(Me.cboAJIPMERE), String)
                Me.lblAJIPREAJ.Text = CType(fun_Buscar_Lista_Valores_RESOAJUS_Codigo(Me.cboAJIPREAJ), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
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
            Dim objVerifica As New cla_Verificar_Dato

            Dim boAJIPMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtAJIPMUNI)
            Dim boAJIPCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtAJIPCORR)
            Dim boAJIPBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtAJIPBARR)
            Dim boAJIPMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtAJIPMANZ)
            Dim boAJIPPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtAJIPPRED)
            Dim boAJIPEDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtAJIPEDIF)
            Dim boAJIPUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtAJIPUNPR)

            Dim boAJIPNUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtAJIPNUFI)
            Dim boAJIPNURE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtAJIPNURE)
            Dim boAJIPFERE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtAJIPFERE)

            Dim boAJIPMAIN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtAJIPMAIN)
            Dim boAJIPCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboAJIPCLSE)
            Dim boAJIPVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboAJIPVIGE)
            Dim boAJIPTITR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboAJIPTITR)
            Dim boAJIPESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboAJIPESTA)
            Dim boAJIPCLAS As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboAJIPCLAS)
            Dim boAJIPMERE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboAJIPMERE)
            Dim boAJIPREAJ As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboAJIPREAJ)

            Dim stRECLOBSE_NUEVA As String = Trim(Me.txtRECLOBSE_NUEVAS.Text)

            If Trim(stRECLOBSE_NUEVA) <> "" Then
                Me.txtAJIPOBSE.Text += vbCrLf & " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stRECLOBSE_NUEVA & ". "
            End If

            ' verifica los datos del formulario 
            If boAJIPMUNI = True And _
               boAJIPCORR = True And _
               boAJIPBARR = True And _
               boAJIPMANZ = True And _
               boAJIPPRED = True And _
               boAJIPEDIF = True And _
               boAJIPNUFI = True And _
               boAJIPNURE = True And _
               boAJIPUNPR = True And _
               boAJIPMAIN = True And _
               boAJIPCLSE = True And _
               boAJIPVIGE = True And _
               boAJIPTITR = True And _
               boAJIPESTA = True And _
               boAJIPMERE = True And _
               boAJIPREAJ = True And _
               boAJIPCLAS = True Then

                Dim objdatos22 As New cla_AJUSIMPR

                If (objdatos22.fun_Actualizar_AJUSIMPR(inID_REGISTRO, _
                                                       Me.txtAJIPNUFI.Text, _
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
                                                       Me.cboAJIPCLAS.SelectedValue, _
                                                       Me.cboAJIPTITR.SelectedValue, _
                                                       Me.cboAJIPMERE.SelectedValue, _
                                                       Me.cboAJIPREAJ.SelectedValue, _
                                                       Me.txtAJIPNURA.Text, _
                                                       Me.txtAJIPFERA.Text, _
                                                       Me.txtAJIPNURE.Text, _
                                                       Me.txtAJIPFERE.Text, _
                                                       Me.txtAJIPNUOF.Text, _
                                                       Me.txtAJIPFEOF.Text, _
                                                       Me.txtAJIPOBSE.Text, _
                                                       Me.cboAJIPESTA.SelectedValue)) = True Then

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

                    Dim objdatos1 As New cla_AJUSIMPR
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_CODIGO_X_AJUSIMPR(CInt(Me.txtAJIPSECU.Text))

                    If tbl1.Rows.Count > 0 Then

                        Dim inNroIdRe As New frm_AJUSIMPR(tbl1.Rows(0).Item("AJIPIDRE"))

                    End If

                    Me.txtAJIPMUNI.Focus()
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
        Dim inNroIdRe As New frm_AJUSIMPR(0)
        Me.txtAJIPMUNI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAJIPMUNI.KeyPress, txtAJIPCORR.KeyPress, txtAJIPBARR.KeyPress, txtAJIPMANZ.KeyPress, txtAJIPPRED.KeyPress, txtAJIPEDIF.KeyPress, txtAJIPUNPR.KeyPress, cboAJIPCLSE.KeyPress, cboAJIPVIGE.KeyPress, txtAJIPMAIN.KeyPress, txtAJIPNURA.KeyPress, txtAJIPFERA.KeyPress, txtAJIPFERE.KeyPress, txtAJIPNURE.KeyPress, txtAJIPNUOF.KeyPress, txtAJIPFEOF.KeyPress, cboAJIPTITR.KeyPress, cboAJIPESTA.KeyPress, txtAJIPOBSE.KeyPress, cboAJIPCLAS.KeyPress, cboAJIPMERE.KeyPress, cboAJIPREAJ.KeyPress
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
    Private Sub cboAJIPTITR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAJIPTITR.KeyDown
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
    Private Sub cboAJIPTITR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAJIPTITR.SelectedIndexChanged
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
    Private Sub cboAJIPTITR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAJIPTITR.Click
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
    Private Sub txtAJIPEDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIPEDIF.Validated
        If Me.txtAJIPEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtAJIPEDIF.Text) = True Then
            Me.txtAJIPEDIF.Text = fun_Formato_Mascara_3_String(Me.txtAJIPEDIF.Text)
        End If
    End Sub
    Private Sub txtAJIPUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAJIPUNPR.Validated
        If Me.txtAJIPUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtAJIPUNPR.Text) = True Then
            Me.txtAJIPUNPR.Text = fun_Formato_Mascara_5_String(Me.txtAJIPUNPR.Text)
        End If
    End Sub

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

    Private Sub dtpAJIPFEDE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpAJIPFERA.ValueChanged
        Me.txtAJIPFERA.Text = Me.dtpAJIPFERA.Value
    End Sub
    Private Sub dtpAJIPFEMU_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpAJIPFERE.ValueChanged
        Me.txtAJIPFERE.Text = Me.dtpAJIPFERE.Value
    End Sub
    Private Sub dtpAJIPFEED_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpAJIPFEOF.ValueChanged
        Me.txtAJIPFEOF.Text = Me.dtpAJIPFEOF.Value
    End Sub

#End Region

#End Region

#End Region

End Class