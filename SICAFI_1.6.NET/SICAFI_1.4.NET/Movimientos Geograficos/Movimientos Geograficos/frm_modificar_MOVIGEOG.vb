Imports REGLAS_DEL_NEGOCIO
Imports System.IO

Public Class frm_modificar_MOVIGEOG

    '=========================================
    '*** MODIFICAR MOVIMIENTOS GEOGRAFICOS ***
    '=========================================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer
    Dim vl_stMOGENUDO As String

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inInRegistro As Integer)
        inID_REGISTRO = inInRegistro

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inInRegistro As Integer, ByVal stNroDocumento As String)
        inID_REGISTRO = inInRegistro
        vl_stMOGENUDO = Trim(stNroDocumento)

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Try
            Dim objdatos1 As New cla_CLASSECT

            Me.cboMOGECLSE.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboMOGECLSE.DisplayMember = "CLSEDESC"
            Me.cboMOGECLSE.ValueMember = "CLSECODI"

            Dim objdatos2 As New cla_VIGENCIA

            Me.cboMOGEVIGE.DataSource = objdatos2.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboMOGEVIGE.DisplayMember = "VIGEDESC"
            Me.cboMOGEVIGE.ValueMember = "VIGECODI"

            Dim objdatos3 As New cla_CAUSACTO

            Me.cboMOGECAAC.DataSource = objdatos3.fun_Consultar_CAMPOS_MANT_CAUSACTO
            Me.cboMOGECAAC.DisplayMember = "CAACDESC"
            Me.cboMOGECAAC.ValueMember = "CAACCODI"

            Dim objdatos4 As New cla_CLASVERS

            Me.cboMOGECLVE.DataSource = objdatos4.fun_Consultar_CAMPOS_MANT_CLASVERS
            Me.cboMOGECLVE.DisplayMember = "CLVEDESC"
            Me.cboMOGECLVE.ValueMember = "CLVECODI"

            Dim objdatos5 As New cla_USUARIO

            Me.cboMOGENUDO.DataSource = objdatos5.fun_Buscar_CODIGO_USUARIO(vl_stMOGENUDO)
            Me.cboMOGENUDO.DisplayMember = "USUANOMB"
            Me.cboMOGENUDO.ValueMember = "USUANUDO"

            Dim objdatos7 As New cla_ESTADO

            Me.cboMOGEESTA.DataSource = objdatos7.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboMOGEESTA.DisplayMember = "ESTADESC"
            Me.cboMOGEESTA.ValueMember = "ESTACODI"

            Dim objdatos8 As New cla_MOVIGEOG
            Dim tbl As New DataTable

            tbl = objdatos8.fun_Buscar_ID_MOVIGEOG(inID_REGISTRO)

            Me.txtMOGESECU.Text = CStr(Trim(tbl.Rows(0).Item("MOGESECU")))
            Me.txtMOGEMUNI.Text = CStr(Trim(tbl.Rows(0).Item("MOGEMUNI")))
            Me.txtMOGECORR.Text = CStr(Trim(tbl.Rows(0).Item("MOGECORR")))
            Me.txtMOGEBARR.Text = CStr(Trim(tbl.Rows(0).Item("MOGEBARR")))
            Me.txtMOGEMANZ.Text = CStr(Trim(tbl.Rows(0).Item("MOGEMANZ")))
            Me.txtMOGEPRED.Text = CStr(Trim(tbl.Rows(0).Item("MOGEPRED")))
            Me.cboMOGEVIGE.SelectedValue = tbl.Rows(0).Item("MOGEVIGE")
            Me.cboMOGECLSE.SelectedValue = tbl.Rows(0).Item("MOGECLSE")
            Me.cboMOGECAAC.SelectedValue = tbl.Rows(0).Item("MOGECAAC")
            Me.cboMOGECLVE.SelectedValue = tbl.Rows(0).Item("MOGECLVE")
            Me.cboMOGENUDO.SelectedValue = tbl.Rows(0).Item("MOGENUDO")
            Me.cboMOGEESTA.SelectedValue = tbl.Rows(0).Item("MOGEESTA")
            Me.txtMOGEOBSE.Text = CStr(Trim(tbl.Rows(0).Item("MOGEOBSE")))
          
            Dim boMOGECAAC As Boolean = fun_Buscar_Dato_CAUSACTO(Me.cboMOGECAAC.SelectedValue)
            Dim boMOGEVIGE As Boolean = fun_Buscar_Dato_VIGENCIA(Me.cboMOGEVIGE.SelectedValue)
            Dim boMOGECLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboMOGECLSE.SelectedValue)
            Dim boMOGECLVE As Boolean = fun_Buscar_Dato_CLASVERS(Me.cboMOGECLVE.SelectedValue)
            Dim boMOGEUSUA As Boolean = fun_Buscar_Dato_USUARIO(Me.cboMOGENUDO.SelectedValue)

            If boMOGECAAC = True OrElse _
               boMOGEVIGE = True OrElse _
               boMOGECLSE = True OrElse _
               boMOGECLVE = True OrElse _
               boMOGEUSUA = True Then

                Me.lblMOGEVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboMOGEVIGE), String)
                Me.lblMOGECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboMOGECLSE), String)
                Me.lblMOGECAAC.Text = CType(fun_Buscar_Lista_Valores_CAUSACTO_Codigo(Me.cboMOGECAAC), String)
                Me.lblMOGECLVE.Text = CType(fun_Buscar_Lista_Valores_CLASVERS_Codigo(Me.cboMOGECLVE), String)
                Me.lblMOGENUDO.Text = CType(fun_Buscar_Lista_Valores_USUARIO_Codigo(Me.cboMOGENUDO), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

         Me.cboMOGECLSE.DataSource = New DataTable
        Me.cboMOGEVIGE.DataSource = New DataTable
        Me.cboMOGECAAC.DataSource = New DataTable
        Me.cboMOGEVIGE.DataSource = New DataTable
        Me.cboMOGECLVE.DataSource = New DataTable
        Me.cboMOGEESTA.DataSource = New DataTable
        Me.cboMOGENUDO.DataSource = New DataTable

        Me.txtMOGESECU.Text = ""
        Me.lblMOGECLSE.Text = ""
        Me.lblMOGEVIGE.Text = ""
        Me.lblMOGECAAC.Text = ""
        Me.lblMOGECLVE.Text = ""
        Me.lblMOGENUDO.Text = ""
        Me.txtMOGEMUNI.Text = ""
        Me.txtMOGECORR.Text = ""
        Me.txtMOGEBARR.Text = ""
        Me.txtMOGEMANZ.Text = ""
        Me.txtMOGEPRED.Text = ""
        Me.txtMOGEOBSE_NUEVAS.Text = ""

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_ConsultaNombreUsuario(ByVal stNUMEDOCU As String) As String

        Try
            ' declara la variable
            Dim stUSUARIO As String = ""

            ' declara la instancia
            Dim obCONTRASENA As New cla_CONTRASENA
            Dim dtCONTRASENA As New DataTable

            dtCONTRASENA = obCONTRASENA.fun_Buscar_CODIGO_CONTRASENA(Trim(stNUMEDOCU))

            If dtCONTRASENA.Rows.Count > 0 Then
                stUSUARIO = Trim(dtCONTRASENA.Rows(0).Item("CONTUSUA").ToString)
            End If

            Return stUSUARIO

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_TRABCAMP

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boMOGEMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMOGEMUNI)
            Dim boMOGECORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMOGECORR)
            Dim boMOGEBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMOGEBARR)
            Dim boMOGEMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMOGEMANZ)
            Dim boMOGEPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMOGEPRED)
            Dim boMOGECLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMOGECLSE)
            Dim boMOGEVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMOGEVIGE)
            Dim boMOGECAAC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMOGECAAC)
            Dim boMOGECLVE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMOGECLVE)
            Dim boMOGEESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMOGEESTA)
            Dim boMOGEUSUA As Boolean = False

            Dim stMOGEUSUA As String = fun_ConsultaNombreUsuario(Me.cboMOGENUDO.SelectedValue)

            If Trim(stMOGEUSUA) = "" Then
                boMOGEUSUA = False
                MessageBox.Show("El funcionario seleccionado no registra un perfil de usuario", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                boMOGEUSUA = True
            End If

            Dim stMOGEOBSE_NUEVA As String = Trim(Me.txtMOGEOBSE_NUEVAS.Text)

            If Trim(stMOGEOBSE_NUEVA) <> "" Then
                Me.txtMOGEOBSE.Text += vbCrLf & " Nota ingresada por: " & vp_usuario & " " & fun_fecha() & " : " & stMOGEOBSE_NUEVA & ". "
            End If

            ' verifica los datos del formulario 
            If boMOGEMUNI = True And _
               boMOGECORR = True And _
               boMOGEBARR = True And _
               boMOGEMANZ = True And _
               boMOGEPRED = True And _
               boMOGECLSE = True And _
               boMOGEVIGE = True And _
               boMOGECAAC = True And _
               boMOGECLVE = True And _
               boMOGEUSUA = True And _
               boMOGEESTA = True Then

                Dim objdatos22 As New cla_MOVIGEOG

                If (objdatos22.fun_Actualizar_MOVIGEOG(inID_REGISTRO, _
                                                       Me.txtMOGESECU.Text, _
                                                       Me.txtMOGEMUNI.Text, _
                                                       Me.txtMOGECORR.Text, _
                                                       Me.txtMOGEBARR.Text, _
                                                       Me.txtMOGEMANZ.Text, _
                                                       Me.txtMOGEPRED.Text, _
                                                       Me.cboMOGECLSE.SelectedValue, _
                                                       Me.cboMOGEVIGE.SelectedValue, _
                                                       Me.cboMOGENUDO.SelectedValue, _
                                                       stMOGEUSUA, _
                                                       Me.cboMOGECAAC.SelectedValue, _
                                                       Me.cboMOGECLVE.SelectedValue, _
                                                       Me.txtMOGEOBSE.Text, _
                                                       Me.cboMOGEESTA.SelectedValue)) = True Then

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(13)

                    If tblRutas.Rows.Count > 0 Then

                        Dim stRuta As String = Me.txtMOGEMUNI.Text & "-" & Me.cboMOGECLSE.SelectedValue & "-" & Me.txtMOGECORR.Text & "-" & Me.txtMOGEBARR.Text & "-" & Me.txtMOGEMANZ.Text & "-" & Me.txtMOGEPRED.Text & "-" & Me.cboMOGEVIGE.SelectedValue

                        If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                            System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                        End If

                    End If

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    Dim objdatos1 As New cla_MOVIGEOG
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_CODIGO_X_MOVIGEOG(CInt(Me.txtMOGESECU.Text))

                    If tbl1.Rows.Count > 0 Then

                        Dim inNroIdRe As New frm_MOVIGEOG(tbl1.Rows(0).Item("MOGEIDRE"))

                    End If

                    Me.txtMOGEMUNI.Focus()
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
        Me.txtMOGEMUNI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMOGEMUNI.KeyPress, txtMOGECORR.KeyPress, txtMOGEMANZ.KeyPress, txtMOGEBARR.KeyPress, txtMOGEPRED.KeyPress, cboMOGECLSE.KeyPress, cboMOGEVIGE.KeyPress, cboMOGECAAC.KeyPress, cboMOGEESTA.KeyPress, cboMOGENUDO.KeyPress, cboMOGECLVE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTRCACLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMOGECLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboMOGECLSE, Me.cboMOGECLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCAVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMOGEVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboMOGEVIGE, Me.cboMOGEVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboMOGENUDO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMOGENUDO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboMOGENUDO, Me.cboMOGENUDO.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCACAAC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMOGECAAC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CAUSACTO_Descripcion(Me.cboMOGECAAC, Me.cboMOGECAAC.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCACLVE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMOGECLVE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASVERS_Descripcion(Me.cboMOGECLVE, Me.cboMOGECLVE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTRCAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMOGEESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboMOGEESTA, Me.cboMOGEESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOGEMUNI.GotFocus, txtMOGECORR.GotFocus, txtMOGEBARR.GotFocus, txtMOGEMANZ.GotFocus, txtMOGEPRED.GotFocus, txtMOGEOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOGECLSE.GotFocus, cboMOGEVIGE.GotFocus, cboMOGECAAC.GotFocus, cboMOGEESTA.GotFocus, cboMOGENUDO.GotFocus, cboMOGECLVE.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTRCACLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMOGECLSE.SelectedIndexChanged
        Me.lblMOGECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboMOGECLSE), String)
    End Sub
    Private Sub cboTRCAVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMOGEVIGE.SelectedIndexChanged
        Me.lblMOGEVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboMOGEVIGE), String)
    End Sub
    Private Sub cboTRCACAAC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMOGECAAC.SelectedIndexChanged
        Me.lblMOGECAAC.Text = CType(fun_Buscar_Lista_Valores_CAUSACTO_Codigo(Me.cboMOGECAAC), String)
    End Sub
    Private Sub cboTRCACLVE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMOGECLVE.SelectedIndexChanged
        Me.lblMOGECLVE.Text = CType(fun_Buscar_Lista_Valores_CLASVERS_Codigo(Me.cboMOGECLVE), String)
    End Sub
    Private Sub cboMOGENUDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMOGENUDO.SelectedIndexChanged
        Me.lblMOGENUDO.Text = CType(fun_Buscar_Lista_Valores_USUARIO_Codigo(Me.cboMOGENUDO), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTRCACLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOGECLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboMOGECLSE, Me.cboMOGECLSE.SelectedIndex)
    End Sub
    Private Sub cboTRCAVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOGEVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboMOGEVIGE, Me.cboMOGEVIGE.SelectedIndex)
    End Sub
    Private Sub cboTRCACAAC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOGECAAC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CAUSACTO_Descripcion(Me.cboMOGECAAC, Me.cboMOGECAAC.SelectedIndex)
    End Sub
    Private Sub cboTRCACLVA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOGECLVE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASVERS_Descripcion(Me.cboMOGECLVE, Me.cboMOGECLVE.SelectedIndex)
    End Sub
    Private Sub cboTRCANUDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOGENUDO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboMOGENUDO, Me.cboMOGENUDO.SelectedIndex)
    End Sub
    Private Sub cboTRCAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMOGEESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboMOGEESTA, Me.cboMOGEESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOGEMUNI.Validated
        If Me.txtMOGEMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOGEMUNI.Text) = True Then
            Me.txtMOGEMUNI.Text = fun_Formato_Mascara_3_String(Me.txtMOGEMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOGECORR.Validated
        If Me.txtMOGECORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOGECORR.Text) = True Then
            Me.txtMOGECORR.Text = fun_Formato_Mascara_2_String(Me.txtMOGECORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOGEBARR.Validated
        If Me.txtMOGEBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOGEBARR.Text) = True Then
            Me.txtMOGEBARR.Text = fun_Formato_Mascara_3_String(Me.txtMOGEBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOGEMANZ.Validated
        If Me.txtMOGEMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOGEMANZ.Text) = True Then
            Me.txtMOGEMANZ.Text = fun_Formato_Mascara_3_String(Me.txtMOGEMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMOGEPRED.Validated
        If Me.txtMOGEPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtMOGEPRED.Text) = True Then
            Me.txtMOGEPRED.Text = fun_Formato_Mascara_5_String(Me.txtMOGEPRED.Text)
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