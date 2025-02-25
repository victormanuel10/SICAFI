Imports REGLAS_DEL_NEGOCIO
Imports System.IO

Public Class frm_insertar_MUTAPRIM

    '============================================
    '*** INSERTAR MUTACIONES DE PRIMERA CLASE ***
    '============================================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inInRegistro As Integer)
        inID_REGISTRO = inInRegistro

        InitializeComponent()
    End Sub
    Public Sub New()

        InitializeComponent()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboMUPRVIGE.DataSource = New DataTable
        Me.cboMUPRTIRE.DataSource = New DataTable
        Me.cboMUPRUSUA.DataSource = New DataTable
        Me.cboMUPRESTA.DataSource = New DataTable

        Me.txtMUPRSECU.Text = "0"
        Me.txtMUPRRESO.Text = "0"
        Me.txtMUPROBSE.Text = ""

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
            Dim objdatos As New cla_MUTAPRIM

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MUTAPRIM(Me.cboMUPRVIGE, Me.cboMUPRTIRE, Me.txtMUPRRESO)

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
            If boLLAVEPRIMARIA = True And _
               boMUPRVIGE = True And _
               boMUPRTIRE = True And _
               boMUPRRESO = True And _
               boMUPRUSUA = True And _
               boUSUARIO = True And _
               boMUPRESTA = True Then

                Dim stREMUOBSE_ACTUAL As String = ""

                If Trim(Me.txtMUPROBSE.Text) <> "" Then
                    stREMUOBSE_ACTUAL = " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & Trim(Me.txtMUPROBSE.Text) & ". "
                End If

                Me.txtMUPRSECU.Text = CStr(fun_NumeroDeSecuenciaDeRegistro())

                Dim objdatos22 As New cla_MUTAPRIM

                If (objdatos22.fun_Insertar_MUTAPRIM(Me.txtMUPRSECU.Text, _
                                                     Me.cboMUPRVIGE.SelectedValue, _
                                                     Me.cboMUPRTIRE.SelectedValue, _
                                                     Me.txtMUPRRESO.Text, _
                                                     Me.nudMUPRSEMA.Value, _
                                                     Trim(Me.lblMUPRUSUA.Text), _
                                                     Trim(stREMUUSUA), _
                                                     Me.cboMUPRESTA.SelectedValue, _
                                                     stREMUOBSE_ACTUAL)) = True Then

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

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    ' envia el ID al formulario principal
                    Dim objdatos1 As New cla_MUTAPRIM
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_CODIGO_X_MUTAPRIM(CInt(Me.txtMUPRSECU.Text))

                    If tbl1.Rows.Count > 0 Then

                        Dim inNroIdRe As New frm_MUTAPRIM(tbl1.Rows(0).Item("MUPRIDRE"))

                    End If

                    Me.cboMUPRVIGE.Focus()
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

#Region "Load"

    Private Sub frm_insertar_MUTACIONES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtMUPRSECU.Text = fun_NumeroDeSecuenciaDeRegistro()
        Me.cboMUPRVIGE.Focus()

    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMUPRESTA.KeyPress, txtMUPROBSE.KeyPress, cboMUPRTIRE.KeyPress, cboMUPRVIGE.KeyPress, cboMUPRUSUA.KeyPress, txtMUPRRESO.KeyPress, nudMUPRSEMA.KeyPress
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

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMUPROBSE.GotFocus, txtMUPRRESO.GotFocus
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