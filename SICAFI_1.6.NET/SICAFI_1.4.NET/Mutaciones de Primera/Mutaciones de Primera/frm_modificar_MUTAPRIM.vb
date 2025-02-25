Imports REGLAS_DEL_NEGOCIO
Imports System.IO

Public Class frm_modificar_MUTAPRIM

    '==============================================
    '*** ACTUALIZAR MUTACIONES DE PRIMERA CLASE ***
    '==============================================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer
    Dim vl_stMUPRNUDO As String = ""

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inInRegistro As Integer)
        inID_REGISTRO = inInRegistro

        InitializeComponent()
    End Sub
    Public Sub New(ByVal inInRegistro As Integer, ByVal stMUPRNUDO As String)
        inID_REGISTRO = inInRegistro
        vl_stMUPRNUDO = stMUPRNUDO

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New()

        InitializeComponent()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Try
            Dim objdatos8 As New cla_MUTAPRIM
            Dim tbl As New DataTable

            tbl = objdatos8.fun_Buscar_ID_MUTAPRIM(inID_REGISTRO)

            Me.txtMUPRSECU.Text = CStr(Trim(tbl.Rows(0).Item("MUPRSECU")))

            Dim objdatos2 As New cla_VIGENCIA

            Me.cboMUPRVIGE.DataSource = objdatos2.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboMUPRVIGE.DisplayMember = "VIGEDESC"
            Me.cboMUPRVIGE.ValueMember = "VIGECODI"

            Me.cboMUPRVIGE.SelectedValue = tbl.Rows(0).Item("MUPRVIGE")

            Dim objdatos3 As New cla_TIPORESO

            Me.cboMUPRTIRE.DataSource = objdatos3.fun_Consultar_CAMPOS_MANT_TIPORESO
            Me.cboMUPRTIRE.DisplayMember = "TIREDESC"
            Me.cboMUPRTIRE.ValueMember = "TIRECODI"

            Me.cboMUPRTIRE.SelectedValue = tbl.Rows(0).Item("MUPRTIRE")

            Me.txtMUPRRESO.Text = tbl.Rows(0).Item("MUPRRESO")
            Me.nudMUPRSEMA.Value = tbl.Rows(0).Item("MUPRSEMA")

            Dim objdatos5 As New cla_USUARIO

            Me.cboMUPRUSUA.DataSource = objdatos5.fun_Buscar_CODIGO_USUARIO(vl_stMUPRNUDO)
            Me.cboMUPRUSUA.DisplayMember = "USUANOMB"
            Me.cboMUPRUSUA.ValueMember = "USUANUDO"

            Dim objdatos7 As New cla_ESTADO

            Me.cboMUPRESTA.DataSource = objdatos7.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboMUPRESTA.DisplayMember = "ESTADESC"
            Me.cboMUPRESTA.ValueMember = "ESTACODI"

            Me.lblMUPRVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboMUPRVIGE), String)
            Me.lblMUPRTIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO_Codigo(Me.cboMUPRTIRE), String)
            Me.lblMUPRUSUA.Text = CType(fun_Buscar_Lista_Valores_USUARIO_Codigo(Me.cboMUPRUSUA), String)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboMUPRVIGE.DataSource = New DataTable
        Me.cboMUPRTIRE.DataSource = New DataTable
        Me.cboMUPRUSUA.DataSource = New DataTable
        Me.cboMUPRESTA.DataSource = New DataTable

        Me.txtMUPRSECU.Text = "0"
        Me.txtMUPRRESO.Text = "0"

        Me.lblMUPRVIGE.Text = ""
        Me.lblMUPRTIRE.Text = ""
        Me.lblMUPRUSUA.Text = ""

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_NumeroDeSecuenciaDeRegistro() As Integer

        Try
            Dim inFPDESECU As Integer = 0

            Dim objdatos5 As New cla_MUTAPRIM
            Dim tbl10 As New DataTable

            tbl10 = objdatos5.fun_Buscar_SECUENCIA_X_MUTAPRIM

            If tbl10.Rows.Count = 0 Then
                inFPDESECU = 1
            Else
                Dim i As Integer
                Dim NroMayor As Integer
                Dim Posicion As Integer

                Posicion = Val(tbl10.Rows(0).Item("MUPRSECU"))

                For i = 0 To tbl10.Rows.Count - 1
                    NroMayor = Val(tbl10.Rows(i).Item("MUPRSECU"))

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
            Dim objVerifica As New cla_Verificar_Dato

            Dim boMUPRVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMUPRVIGE)
            Dim boMUPRTIRE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMUPRTIRE)
            Dim boMUPRRESO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMUPRRESO)
            Dim boMUPRUSUA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMUPRUSUA)
            Dim boMUPRNUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.lblMUPRUSUA)
            Dim boMUPRESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMUPRESTA)
            Dim boUSUARIO As Boolean = False

            Dim stREMUUSUA As String = fun_ConsultaNombreUsuario(Me.cboMUPRUSUA.SelectedValue)

            If Trim(stREMUUSUA) = "" Then
                boUSUARIO = False
                MessageBox.Show("El funcionario seleccionado no registra un perfil de usuario", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                boUSUARIO = True
            End If

            ' verifica los datos del formulario 
            If boMUPRVIGE = True And _
               boMUPRTIRE = True And _
               boMUPRRESO = True And _
               boMUPRUSUA = True And _
               boUSUARIO = True And _
               boMUPRESTA = True Then

                ' instancia la clase
                Dim obMUPRMUTA As New cla_MUTAPRIM
                Dim dtMUPRMUTA As New DataTable

                dtMUPRMUTA = obMUPRMUTA.fun_Buscar_ID_MUTAPRIM(inID_REGISTRO)

                ' declara variables
                Dim stMUPROBSE As String = CStr(Trim(dtMUPRMUTA.Rows(0).Item("MUPROBSE").ToString))
                
                If dtMUPRMUTA.Rows.Count > 0 Then
                    stMUPROBSE = CStr(Trim(dtMUPRMUTA.Rows(0).Item("MUPROBSE").ToString))
                End If

                Dim objdatos22 As New cla_MUTAPRIM

                If (objdatos22.fun_Actualizar_MUTAPRIM(inID_REGISTRO, _
                                                       Me.txtMUPRSECU.Text, _
                                                       Me.cboMUPRVIGE.SelectedValue, _
                                                       Me.cboMUPRTIRE.SelectedValue, _
                                                       Me.txtMUPRRESO.Text, _
                                                       Me.nudMUPRSEMA.Value, _
                                                       Trim(Me.lblMUPRUSUA.Text), _
                                                       Trim(stREMUUSUA), _
                                                       Me.cboMUPRESTA.SelectedValue, _
                                                       stMUPROBSE)) = True Then

                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(24)

                    If tblRutas.Rows.Count > 0 Then

                        Dim stRuta As String = Me.cboMUPRVIGE.SelectedValue & "-" & Me.txtMUPRRESO.Text

                        If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                            System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                        End If

                    End If

                    Dim objdatos1 As New cla_MUTAPRIM
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_ID_MUTAPRIM(CInt(inID_REGISTRO))

                    If tbl1.Rows.Count > 0 Then

                        Dim inNroIdRe As New frm_MUTAPRIM(tbl1.Rows(0).Item("MUPRIDRE"))

                    End If

                    Me.txtMUPRRESO.Focus()
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
        Dim inNroIdRe As New frm_MUTAPRIM(inID_REGISTRO)
        Me.cboMUPRVIGE.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMUPRESTA.KeyPress, cboMUPRTIRE.KeyPress, cboMUPRVIGE.KeyPress, cboMUPRUSUA.KeyPress, txtMUPRRESO.KeyPress, nudMUPRSEMA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboREMUVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMUPRVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboMUPRVIGE, Me.cboMUPRVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboMUPRTIRE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMUPRTIRE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPORESO_Descripcion(Me.cboMUPRTIRE, Me.cboMUPRTIRE.SelectedIndex)
        End If
    End Sub
    Private Sub cboREMUUSUA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMUPRUSUA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboMUPRUSUA, Me.cboMUPRUSUA.SelectedIndex)
        End If
    End Sub
    Private Sub cboMUTAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMUPRESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboMUPRESTA, Me.cboMUPRESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUPRRESO.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMUPRVIGE.GotFocus, cboMUPRESTA.GotFocus, cboMUPRTIRE.GotFocus, cboMUPRUSUA.GotFocus, nudMUPRSEMA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboMUTACLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMUPRVIGE.SelectedIndexChanged
        Me.lblMUPRVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboMUPRVIGE), String)
    End Sub
    Private Sub cboREMUMES_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMUPRTIRE.SelectedIndexChanged
        Me.lblMUPRTIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO_Codigo(cboMUPRTIRE), String)
    End Sub
    Private Sub cboMOGENUDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMUPRUSUA.SelectedIndexChanged
        Me.lblMUPRUSUA.Text = CType(fun_Buscar_Lista_Valores_USUARIO_Codigo(Me.cboMUPRUSUA), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboMUTACLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMUPRVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboMUPRVIGE, Me.cboMUPRVIGE.SelectedIndex)
    End Sub
    Private Sub cboMUPRTIRE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMUPRTIRE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPORESO_Descripcion(Me.cboMUPRTIRE, Me.cboMUPRTIRE.SelectedIndex)
    End Sub
    Private Sub cboREMUUSUA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMUPRUSUA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboMUPRUSUA, Me.cboMUPRUSUA.SelectedIndex)
    End Sub
    Private Sub cboMUTAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMUPRESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboMUPRESTA, Me.cboMUPRESTA.SelectedIndex)
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