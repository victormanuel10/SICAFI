Imports REGLAS_DEL_NEGOCIO
Imports System.IO

Public Class frm_modificar_CERTESSO

    '=======================================================
    '*** MODIFICAR CERTIFICADO DE ESTRATO SOCIOECONOMICO ***
    '=======================================================

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
    Public Sub New()

        InitializeComponent()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Try
            Dim objdatos8 As New cla_CERTESSO
            Dim tbl As New DataTable

            tbl = objdatos8.fun_Buscar_ID_CERTESSO(inID_REGISTRO)

            Me.txtCEESSECU.Text = CStr(Trim(tbl.Rows(0).Item("CEESSECU")))

            Dim objdatos2 As New cla_ACTOADMI

            Me.cboCEESCLAS.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_ACTOADMI
            Me.cboCEESCLAS.DisplayMember = "ACADDESC"
            Me.cboCEESCLAS.ValueMember = "ACADCODI"

            Me.cboCEESCLAS.SelectedValue = tbl.Rows(0).Item("CEESCLAS")

            Dim objdatos3 As New cla_MEDIRESE

            Me.cboCEESMERE.DataSource = objdatos3.fun_Consultar_CAMPOS_MANT_MEDIRESE
            Me.cboCEESMERE.DisplayMember = "MEREDESC"
            Me.cboCEESMERE.ValueMember = "MERECODI"

            Me.cboCEESMERE.SelectedValue = tbl.Rows(0).Item("CEESMERE")

            Me.txtCEESNURA.Text = Trim(tbl.Rows(0).Item("CEESNURA"))
            Me.txtCEESFERA.Text = Trim(tbl.Rows(0).Item("CEESFERA"))
            Me.txtCEESASUN.Text = Trim(tbl.Rows(0).Item("CEESASUN"))
            Me.txtCEESOFSA.Text = Trim(tbl.Rows(0).Item("CEESOFSA"))

            Dim objdatos6 As New cla_VIGENCIA

            Me.cboCEESVIRA.DataSource = objdatos6.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboCEESVIRA.DisplayMember = "VIGEDESC"
            Me.cboCEESVIRA.ValueMember = "VIGECODI"

            Me.cboCEESVIRA.SelectedValue = tbl.Rows(0).Item("CEESVIRA")

            Dim objdatos7 As New cla_ESTADO

            Me.cboCEESESTA.DataSource = objdatos7.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboCEESESTA.DisplayMember = "ESTADESC"
            Me.cboCEESESTA.ValueMember = "ESTACODI"

            Me.cboCEESESTA.SelectedValue = tbl.Rows(0).Item("CEESESTA")

            Me.lblCEESCLAS.Text = CType(fun_Buscar_Lista_Valores_ACTOADMI_Codigo(Me.cboCEESCLAS), String)
            Me.lblCEESMERE.Text = CType(fun_Buscar_Lista_Valores_MEDIRESE_Codigo(Me.cboCEESMERE), String)
            Me.lblCEESVIRA.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboCEESVIRA), String)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboCEESCLAS.DataSource = New DataTable
        Me.cboCEESMERE.DataSource = New DataTable
        Me.cboCEESVIRA.DataSource = New DataTable
        Me.cboCEESESTA.DataSource = New DataTable

        Me.txtCEESSECU.Text = "0"
        Me.txtCEESNURA.Text = ""
        Me.txtCEESFERA.Text = ""
        Me.txtCEESASUN.Text = ""

        Me.lblCEESCLAS.Text = ""
        Me.lblCEESMERE.Text = ""
        Me.lblCEESVIRA.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boCEESCLAS As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCEESCLAS)
            Dim boCEESMERE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCEESMERE)
            Dim boCEESNURA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEESNURA)
            Dim boCEESFERA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtCEESFERA)
            Dim boCEESVIRA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCEESVIRA)

            Dim boCEESESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCEESESTA)

            ' verifica los datos del formulario 
            If boCEESCLAS = True And _
               boCEESNURA = True And _
               boCEESFERA = True And _
               boCEESVIRA = True And _
               boCEESMERE = True And _
               boCEESESTA = True Then

                Dim objdatos22 As New cla_CERTESSO

                If (objdatos22.fun_Actualizar_CERTESSO(inID_REGISTRO, _
                                                       Me.txtCEESSECU.Text, _
                                                       Me.cboCEESCLAS.SelectedValue, _
                                                       Me.cboCEESMERE.SelectedValue, _
                                                       Me.txtCEESNURA.Text, _
                                                       Me.txtCEESFERA.Text, _
                                                       Me.cboCEESVIRA.SelectedValue, _
                                                       Me.txtCEESASUN.Text, _
                                                       Me.txtCEESOFSA.Text, _
                                                       Me.cboCEESESTA.SelectedValue)) = True Then

                    ' instancia la clase
                    Dim objRutas As New cla_RUTAS
                    Dim tblRutas As New DataTable

                    tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(23)

                    If tblRutas.Rows.Count > 0 Then

                        Dim stRuta As String = Trim(Me.txtCEESNURA.Text) & "-" & Trim(Me.txtCEESFERA.Text)

                        If System.IO.Directory.Exists(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta) = False Then

                            System.IO.Directory.CreateDirectory(Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & stRuta)

                        End If

                    End If

                    mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

                    Me.cboCEESCLAS.Focus()
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
        Dim inNroIdRe As New frm_CERTESSO(inID_REGISTRO)
        Me.cboCEESMERE.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCEESMERE.KeyPress, txtCEESNURA.KeyPress, txtCEESFERA.KeyPress, cboCEESVIRA.KeyPress, cboCEESESTA.KeyPress, cboCEESCLAS.KeyPress, txtCEESASUN.KeyPress, txtCEESOFSA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboCEESCLAS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCEESCLAS.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ACTOADMI_Descripcion(Me.cboCEESCLAS, Me.cboCEESCLAS.SelectedIndex)
        End If
    End Sub
    Private Sub cboCEESMERE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCEESMERE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MEDIRESE_Descripcion(Me.cboCEESMERE, Me.cboCEESMERE.SelectedIndex)
        End If
    End Sub
    Private Sub cboCEESVIRA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCEESVIRA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboCEESVIRA, Me.cboCEESVIRA.SelectedIndex)
        End If
    End Sub
    Private Sub cboCEESESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCEESESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCEESESTA, Me.cboCEESESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEESFERA.GotFocus, txtCEESNURA.GotFocus, txtCEESASUN.GotFocus, txtCEESOFSA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCEESMERE.GotFocus, cboCEESVIRA.GotFocus, cboCEESESTA.GotFocus, cboCEESCLAS.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboCEESCLAS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCEESCLAS.SelectedIndexChanged
        Me.lblCEESCLAS.Text = CType(fun_Buscar_Lista_Valores_ACTOADMI_Codigo(Me.cboCEESCLAS), String)
    End Sub
    Private Sub cboCEESMERE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCEESMERE.SelectedIndexChanged
        Me.lblCEESMERE.Text = CType(fun_Buscar_Lista_Valores_CLASENTI_Codigo(Me.cboCEESMERE), String)
    End Sub
    Private Sub cboCEESMENO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCEESVIRA.SelectedIndexChanged
        Me.lblCEESVIRA.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboCEESVIRA), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboCEESCLAS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCEESCLAS.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ACTOADMI_Descripcion(Me.cboCEESCLAS, Me.cboCEESCLAS.SelectedIndex)
    End Sub
    Private Sub cboCEESMERE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCEESMERE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MEDIRESE_Descripcion(Me.cboCEESMERE, Me.cboCEESMERE.SelectedIndex)
    End Sub
    Private Sub cboCEESMENO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCEESVIRA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboCEESVIRA, Me.cboCEESVIRA.SelectedIndex)
    End Sub
    Private Sub cboMUTAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCEESESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCEESESTA, Me.cboCEESESTA.SelectedIndex)
    End Sub

#End Region

#Region "ValueChanged"

    Private Sub dtpCEESFERA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpCEESFERA.ValueChanged
        Me.txtCEESFERA.Text = Me.dtpCEESFERA.Value
    End Sub

#End Region

#Region "Validated"

    Private Sub txtCEESFERE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEESFERA.Validated

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boCEESFERA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtCEESFERA)

            If boCEESFERA = True AndAlso Trim(Me.txtCEESFERA.Text).ToString.Length = 10 Then

                Dim stVigencia As String = Trim(Me.txtCEESFERA.Text).ToString.Substring(6, 4)

                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stVigencia)) = True Then

                    Dim objdatos5 As New cla_VIGENCIA

                    Me.cboCEESVIRA.DataSource = objdatos5.fun_Consultar_CAMPOS_VIGENCIA
                    Me.cboCEESVIRA.DisplayMember = "VIGEDESC"
                    Me.cboCEESVIRA.ValueMember = "VIGECODI"

                    Me.cboCEESVIRA.SelectedValue = CInt(stVigencia)

                    Me.lblCEESVIRA.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboCEESVIRA), String)

                End If

            Else
                Me.cboCEESVIRA.DataSource = New DataTable
                Me.lblCEESVIRA.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

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