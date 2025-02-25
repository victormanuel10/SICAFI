Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_MUPRMUTA

    '======================================================
    '*** INSERTAR MUTACIONES PRIMERA CLASE - MUTACIONES ***
    '======================================================

#Region "VARIABLE"

    Dim inMPMUIDRE As Integer
    Dim inMPMUSECU As Integer
    Dim inMPMUVIGE As Integer
    Dim inMPMUTIRE As Integer
    Dim inMPMURESO As Integer
    Dim inMPMUNUFI As Integer
    Dim inMPMUNURE As Integer

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer, _
                   ByVal inSECU As Integer, _
                   ByVal inVIGE As Integer, _
                   ByVal inTIRE As Integer, _
                   ByVal inRESO As Integer, _
                   ByVal inNUFI As Integer, _
                   ByVal inNURE As Integer)

        inMPMUIDRE = inIDRE
        inMPMUSECU = inSECU
        inMPMUVIGE = inVIGE
        inMPMUTIRE = inTIRE
        inMPMURESO = inRESO
        inMPMUNUFI = inNUFI
        inMPMUNURE = inNURE

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inSECU As Integer, _
                   ByVal inVIGE As Integer, _
                   ByVal inTIRE As Integer, _
                   ByVal inRESO As Integer)

        inMPMUSECU = inSECU
        inMPMUVIGE = inVIGE
        inMPMUTIRE = inTIRE
        inMPMURESO = inRESO

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtMPMUNUFI.Text = ""
        Me.txtMPMUNOVC.Text = ""
        Me.txtMPMUMUNI.Text = "266"
        Me.txtMPMUCORR.Text = "01"
        Me.txtMPMUBARR.Text = ""
        Me.txtMPMUMANZ.Text = ""
        Me.txtMPMUPRED.Text = ""
        Me.txtMPMUEDIF.Text = ""
        Me.txtMPMUUNPR.Text = ""
        Me.txtMPMUCAAC.Text = ""

        Me.lblMPMUTIRE.Text = ""
        Me.lblMPMUVIGE.Text = ""
        Me.lblMPMURESO.Text = ""

        Me.cboMPMUNOVE.DataSource = New DataTable
        Me.cboMPMUCLSE.DataSource = New DataTable
        Me.cboMPMUESTA.DataSource = New DataTable

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_MUPRMUTA
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_MUPRMUTA(inMPMUIDRE)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraCEDUCATA.Text = "MODIFICAR MUTACIÓN PRIMERA CLASE"

                    Me.txtMPMUNUFI.ReadOnly = True

                    Me.lblMPMUVIGE.Text = inMPMUVIGE
                    Me.lblMPMUTIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO(inMPMUTIRE), String)
                    Me.lblMPMURESO.Text = inMPMURESO

                    Me.txtMPMUNUFI.Text = Trim(tbl.Rows(0).Item("MPMUNUFI"))
                    Me.txtMPMUNOVC.Text = Trim(tbl.Rows(0).Item("MPMUNOVC"))

                    Dim objdatos11 As New cla_NOVEDAD

                    Me.cboMPMUNOVE.DataSource = objdatos11.fun_Consultar_CAMPOS_MANT_NOVEDAD
                    Me.cboMPMUNOVE.DisplayMember = "NOVEDESC"
                    Me.cboMPMUNOVE.ValueMember = "NOVECODI"

                    Me.cboMPMUNOVE.SelectedValue = tbl.Rows(0).Item("MPMUNOVE")

                    Me.txtMPMUMUNI.Text = Trim(tbl.Rows(0).Item("MPMUMUNI"))
                    Me.txtMPMUCORR.Text = Trim(tbl.Rows(0).Item("MPMUCORR"))
                    Me.txtMPMUBARR.Text = Trim(tbl.Rows(0).Item("MPMUBARR"))
                    Me.txtMPMUMANZ.Text = Trim(tbl.Rows(0).Item("MPMUMANZ"))
                    Me.txtMPMUPRED.Text = Trim(tbl.Rows(0).Item("MPMUPRED"))
                    Me.txtMPMUEDIF.Text = Trim(tbl.Rows(0).Item("MPMUEDIF"))
                    Me.txtMPMUUNPR.Text = Trim(tbl.Rows(0).Item("MPMUUNPR"))

                    Dim objdatos1 As New cla_CLASSECT

                    Me.cboMPMUCLSE.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CLASSECT
                    Me.cboMPMUCLSE.DisplayMember = "CLSEDESC"
                    Me.cboMPMUCLSE.ValueMember = "CLSECODI"

                    Me.cboMPMUCLSE.SelectedValue = tbl.Rows(0).Item("MPMUCLSE")

                    Me.txtMPMUCAAC.Text = Trim(tbl.Rows(0).Item("MPMUCAAC"))

                    Dim objdatos3 As New cla_ESTADO

                    Me.cboMPMUESTA.DataSource = objdatos3.fun_Consultar_TODOS_LOS_ESTADOS
                    Me.cboMPMUESTA.DisplayMember = "ESTADESC"
                    Me.cboMPMUESTA.ValueMember = "ESTACODI"

                    Me.cboMPMUESTA.SelectedValue = tbl.Rows(0).Item("MPMUESTA")

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraCEDUCATA.Text = "INSERTAR MUTACIONES PRIMERA CLASE"

                Me.lblMPMUVIGE.Text = inMPMUVIGE
                Me.lblMPMUTIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO(inMPMUTIRE), String)
                Me.lblMPMURESO.Text = inMPMURESO

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_NumeroDeSecuenciaDeRegistro() As Integer

        Try
            Dim inFPDESECU As Integer = 0

            Dim objdatos5 As New cla_MUPRMUTA
            Dim tbl10 As New DataTable

            tbl10 = objdatos5.fun_Buscar_SECUENCIA_X_MUPRMUTA(inMPMUVIGE, inMPMUTIRE, inMPMURESO, Me.txtMPMUNUFI.Text)

            If tbl10.Rows.Count = 0 Then
                inFPDESECU = 1
            Else
                Dim i As Integer
                Dim NroMayor As Integer
                Dim Posicion As Integer

                Posicion = Val(tbl10.Rows(0).Item("MUPRNURE"))

                For i = 0 To tbl10.Rows.Count - 1
                    NroMayor = Val(tbl10.Rows(i).Item("MUPRNURE"))

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
            'inserta el registro
            If boINSERTAR = True Then

                'instancia la clase
                Dim objdatos As New cla_MUPRMUTA

                Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MUPRMUTA(inMPMUVIGE, inMPMUTIRE, inMPMURESO, Me.txtMPMUNUFI, inMPMURESO)

                'instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boMPMUNUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPMUNUFI)
                Dim boMPMUNOVE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMPMUNOVE)
                Dim boMPMUNOVC As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPMUNOVC)
                Dim boMPMUMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPMUMUNI)
                Dim boMPMUCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPMUCORR)
                Dim boMPMUBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPMUBARR)
                Dim boMPMUMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPMUMANZ)
                Dim boMPMUPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPMUPRED)
                Dim boMPMUEDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPMUEDIF)
                Dim boMPMUUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPMUUNPR)
                Dim boMPMUCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMPMUCLSE)
                Dim boMPMUCAAC As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPMUCAAC)
                Dim boMPMUESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMPMUESTA)

                'verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And _
                   boMPMUNUFI = True And _
                   boMPMUNOVE = True And _
                   boMPMUNOVC = True And _
                   boMPMUMUNI = True And _
                   boMPMUCORR = True And _
                   boMPMUBARR = True And _
                   boMPMUMANZ = True And _
                   boMPMUPRED = True And _
                   boMPMUEDIF = True And _
                   boMPMUUNPR = True And _
                   boMPMUCLSE = True And _
                   boMPMUCAAC = True And _
                   boMPMUESTA = True Then

                    ' numero de registro
                    Dim stNUMEREGI As String = CStr(fun_NumeroDeSecuenciaDeRegistro())

                    Dim objdatos22 As New cla_MUPRMUTA

                    If (objdatos22.fun_Insertar_MUPRMUTA(inMPMUSECU, _
                                                         inMPMUVIGE, _
                                                         inMPMUTIRE, _
                                                         inMPMURESO, _
                                                         Me.txtMPMUNUFI.Text, _
                                                         stNUMEREGI, _
                                                         Me.cboMPMUNOVE.SelectedValue, _
                                                         Me.txtMPMUNOVC.Text, _
                                                         Me.txtMPMUMUNI.Text, _
                                                         Me.txtMPMUCORR.Text, _
                                                         Me.txtMPMUBARR.Text, _
                                                         Me.txtMPMUMANZ.Text, _
                                                         Me.txtMPMUPRED.Text, _
                                                         Me.txtMPMUEDIF.Text, _
                                                         Me.txtMPMUUNPR.Text, _
                                                         Me.cboMPMUCLSE.SelectedValue, _
                                                         Me.txtMPMUCAAC.Text, _
                                                         Me.cboMPMUESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtMPMUNUFI.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boMPMUNUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPMUNUFI)
                Dim boMPMUNOVE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMPMUNOVE)
                Dim boMPMUNOVC As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPMUNOVC)
                Dim boMPMUMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPMUMUNI)
                Dim boMPMUCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPMUCORR)
                Dim boMPMUBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPMUBARR)
                Dim boMPMUMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPMUMANZ)
                Dim boMPMUPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPMUPRED)
                Dim boMPMUEDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPMUEDIF)
                Dim boMPMUUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPMUUNPR)
                Dim boMPMUCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMPMUCLSE)
                Dim boMPMUCAAC As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPMUCAAC)
                Dim boMPMUESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMPMUESTA)

                ' verifica los datos del formulario 
                If boMPMUNUFI = True And _
                   boMPMUNOVE = True And _
                   boMPMUNOVC = True And _
                   boMPMUMUNI = True And _
                   boMPMUCORR = True And _
                   boMPMUBARR = True And _
                   boMPMUMANZ = True And _
                   boMPMUPRED = True And _
                   boMPMUEDIF = True And _
                   boMPMUUNPR = True And _
                   boMPMUCLSE = True And _
                   boMPMUCAAC = True And _
                   boMPMUESTA = True Then

                    Dim objdatos22 As New cla_MUPRMUTA

                    If (objdatos22.fun_Actualizar_MUPRMUTA(inMPMUIDRE, _
                                                           inMPMUSECU, _
                                                           inMPMUVIGE, _
                                                           inMPMUTIRE, _
                                                           inMPMURESO, _
                                                           Me.txtMPMUNUFI.Text, _
                                                           inMPMUNURE, _
                                                           Me.cboMPMUNOVE.SelectedValue, _
                                                           Me.txtMPMUNOVC.Text, _
                                                           Me.txtMPMUMUNI.Text, _
                                                           Me.txtMPMUCORR.Text, _
                                                           Me.txtMPMUBARR.Text, _
                                                           Me.txtMPMUMANZ.Text, _
                                                           Me.txtMPMUPRED.Text, _
                                                           Me.txtMPMUEDIF.Text, _
                                                           Me.txtMPMUUNPR.Text, _
                                                           Me.cboMPMUCLSE.SelectedValue, _
                                                           Me.txtMPMUCAAC.Text, _
                                                           Me.cboMPMUESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboMPMUNOVE.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.cboMPMUNOVE.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMPMUMUNI.KeyPress, txtMPMUCORR.KeyPress, txtMPMUBARR.KeyPress, txtMPMUMANZ.KeyPress, txtMPMUPRED.KeyPress, txtMPMUNUFI.KeyPress, cboMPMUCLSE.KeyPress, txtMPMUEDIF.KeyPress, txtMPMUUNPR.KeyPress, cboMPMUESTA.KeyPress, txtMPMUCAAC.KeyPress, txtMPMUNOVC.KeyPress, cboMPMUNOVE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboMPMUNOVE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMPMUNOVE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_NOVEDAD_Descripcion(Me.cboMPMUNOVE, Me.cboMPMUNOVE.SelectedIndex)
        End If
    End Sub
    Private Sub cboMPMUCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMPMUCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboMPMUCLSE, Me.cboMPMUCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboMPMUESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMPMUESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboMPMUESTA, Me.cboMPMUESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "Click"

    Private Sub cboMPMUNOVE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMPMUNOVE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_NOVEDAD_Descripcion(Me.cboMPMUNOVE, Me.cboMPMUNOVE.SelectedIndex)
    End Sub
    Private Sub cboMPMUCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMPMUCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboMPMUCLSE, Me.cboMPMUCLSE.SelectedIndex)
    End Sub
    Private Sub cboMPMUESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMPMUESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboMPMUESTA, Me.cboMPMUESTA.SelectedIndex)
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMPMUMUNI.GotFocus, txtMPMUCORR.GotFocus, txtMPMUBARR.GotFocus, txtMPMUMANZ.GotFocus, txtMPMUPRED.GotFocus, txtMPMUNUFI.GotFocus, txtMPMUEDIF.GotFocus, txtMPMUUNPR.GotFocus, txtMPMUCAAC.GotFocus, txtMPMUNOVC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMPMUCLSE.GotFocus, cboMPMUESTA.GotFocus, cboMPMUNOVE.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMPMUMUNI.Validated
        If Me.txtMPMUMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMPMUMUNI.Text) = True Then
            Me.txtMPMUMUNI.Text = fun_Formato_Mascara_3_String(Me.txtMPMUMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMPMUCORR.Validated
        If Me.txtMPMUCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMPMUCORR.Text) = True Then
            Me.txtMPMUCORR.Text = fun_Formato_Mascara_2_String(Me.txtMPMUCORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMPMUBARR.Validated
        If Me.txtMPMUBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMPMUBARR.Text) = True Then
            Me.txtMPMUBARR.Text = fun_Formato_Mascara_3_String(Me.txtMPMUBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMPMUMANZ.Validated
        If Me.txtMPMUMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMPMUMANZ.Text) = True Then
            Me.txtMPMUMANZ.Text = fun_Formato_Mascara_3_String(Me.txtMPMUMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMPMUPRED.Validated
        If Me.txtMPMUPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMPMUPRED.Text) = True Then
            Me.txtMPMUPRED.Text = fun_Formato_Mascara_5_String(Me.txtMPMUPRED.Text)
        End If
    End Sub
    Private Sub txtOUAPEDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMPMUEDIF.Validated
        If Me.txtMPMUEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMPMUEDIF.Text) = True Then
            Me.txtMPMUEDIF.Text = fun_Formato_Mascara_3_String(Me.txtMPMUEDIF.Text)
        End If
    End Sub
    Private Sub txtOUAPUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMPMUUNPR.Validated
        If Me.txtMPMUUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMPMUUNPR.Text) = True Then
            Me.txtMPMUUNPR.Text = fun_Formato_Mascara_5_String(Me.txtMPMUUNPR.Text)
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