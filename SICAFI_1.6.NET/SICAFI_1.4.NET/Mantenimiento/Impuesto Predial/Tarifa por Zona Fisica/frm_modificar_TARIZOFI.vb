Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_TARIZOFI

    '=========================================
    '*** MODIFICAR TARIFAS POR ZONA FÍSICA ***
    '=========================================

#Region "VARIABLES"

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
            Dim objdatos3 As New cla_TARIZOFI
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_TARIZOFI(inID_REGISTRO)

            Dim objdatos1 As New cla_DEPARTAMENTO

            Me.cboTAZFDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboTAZFDEPA.DisplayMember = "DEPADESC"
            Me.cboTAZFDEPA.ValueMember = "DEPACODI"

            Me.cboTAZFDEPA.SelectedValue = tbl.Rows(0).Item("TAZFDEPA")

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboTAZFMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboTAZFMUNI.DisplayMember = "MUNIDESC"
            Me.cboTAZFMUNI.ValueMember = "MUNICODI"

            Me.cboTAZFMUNI.SelectedValue = tbl.Rows(0).Item("TAZFMUNI")

            Dim objdatos2 As New cla_CLASSECT

            Me.cboTAZFCLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboTAZFCLSE.DisplayMember = "CLSEDESC"
            Me.cboTAZFCLSE.ValueMember = "CLSECODI"

            Me.cboTAZFCLSE.SelectedValue = tbl.Rows(0).Item("TAZFCLSE")

            Dim objdatos22 As New cla_VIGENCIA

            Me.cboTAZFVIGE.DataSource = objdatos22.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboTAZFVIGE.DisplayMember = "VIGEDESC"
            Me.cboTAZFVIGE.ValueMember = "VIGECODI"

            Me.cboTAZFVIGE.SelectedValue = tbl.Rows(0).Item("TAZFVIGE")

            Dim objdatos4 As New cla_ZONAFISI

            Me.cboTAZFZOFI.DataSource = objdatos4.fun_Consultar_CAMPOS_MANT_ZONAFISI()
            Me.cboTAZFZOFI.DisplayMember = "ZOFIDESC"
            Me.cboTAZFZOFI.ValueMember = "ZOFICODI"

            Me.cboTAZFZOFI.SelectedValue = tbl.Rows(0).Item("TAZFZOFI")

            Dim objdatos55 As New cla_ZONAFISI

            Me.cboTAZFZOAP.DataSource = objdatos55.fun_Consultar_CAMPOS_MANT_ZONAFISI()
            Me.cboTAZFZOAP.DisplayMember = "ZOFIDESC"
            Me.cboTAZFZOAP.ValueMember = "ZOFICODI"

            Me.cboTAZFZOAP.SelectedValue = tbl.Rows(0).Item("TAZFZOAP")

            Dim objdatos As New cla_ESTADO

            Me.cboTAZFESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
            Me.cboTAZFESTA.DisplayMember = "ESTADESC"
            Me.cboTAZFESTA.ValueMember = "ESTACODI"

            Me.cboTAZFESTA.SelectedValue = tbl.Rows(0).Item("TAZFESTA")

            Me.txtTAZFTA01.Text = Trim(tbl.Rows(0).Item("TAZFTA01"))
            Me.txtTAZFTA02.Text = Trim(tbl.Rows(0).Item("TAZFTA02"))
            Me.txtTAZFTA03.Text = Trim(tbl.Rows(0).Item("TAZFTA03"))
            Me.txtTAZFTA04.Text = Trim(tbl.Rows(0).Item("TAZFTA04"))
            Me.txtTAZFTA05.Text = Trim(tbl.Rows(0).Item("TAZFTA05"))
            Me.txtTAZFTA06.Text = Trim(tbl.Rows(0).Item("TAZFTA06"))

            Me.cboTAZFSIGN.SelectedItem = Trim(tbl.Rows(0).Item("TAZFSIGN"))
            Me.txtTAZFPORC.Text = Trim(tbl.Rows(0).Item("TAZFPORC"))
            Me.txtTAZFTALO.Text = Trim(tbl.Rows(0).Item("TAZFTALO"))

            Dim boTAZFDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(cboTAZFDEPA.SelectedValue)
            Dim boTAZFMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(cboTAZFDEPA.SelectedValue, cboTAZFMUNI.SelectedValue)
            Dim boTAZFCLSE As Boolean = fun_Buscar_Dato_CLASSECT(cboTAZFCLSE.SelectedValue)
            Dim boTAZFVIGE As Boolean = fun_Buscar_Dato_VIGENCIA(cboTAZFVIGE.SelectedValue)
            Dim boTAZFZOFI As Boolean = fun_Buscar_Dato_ZONAFISI(cboTAZFZOFI.SelectedValue)
            Dim boTAZFZOAP As Boolean = fun_Buscar_Dato_ZONAFISI(cboTAZFZOAP.SelectedValue)

            If boTAZFDEPA = True OrElse boTAZFMUNI = True OrElse boTAZFCLSE = True OrElse boTAZFZOFI = True OrElse boTAZFZOAP = True Then

                Me.lblTAZFDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboTAZFDEPA), String)
                Me.lblTAZFMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboTAZFDEPA, Me.cboTAZFMUNI), String)
                Me.lblTAZFCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboTAZFCLSE), String)
                Me.lblTAZFVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboTAZFVIGE), String)
                Me.lblTAZFZOFI.Text = CType(fun_Buscar_Lista_Valores_ZONAFISI_Codigo(Me.cboTAZFDEPA, Me.cboTAZFMUNI, Me.cboTAZFCLSE, Me.cboTAZFZOFI), String)
                Me.lblTAZFZOAP.Text = CType(fun_Buscar_Lista_Valores_ZONAFISI_Codigo(Me.cboTAZFDEPA, Me.cboTAZFMUNI, Me.cboTAZFCLSE, Me.cboTAZFZOAP), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        Me.txtTAZFTA01.Focus()

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboTAZFDEPA.DataSource = New DataTable
        Me.cboTAZFMUNI.DataSource = New DataTable
        Me.cboTAZFCLSE.DataSource = New DataTable
        Me.cboTAZFVIGE.DataSource = New DataTable
        Me.cboTAZFZOFI.DataSource = New DataTable
        Me.cboTAZFZOAP.DataSource = New DataTable

        Me.lblTAZFDEPA.Text = ""
        Me.lblTAZFMUNI.Text = ""
        Me.lblTAZFCLSE.Text = ""
        Me.lblTAZFVIGE.Text = ""
        Me.lblTAZFZOFI.Text = ""
        Me.lblTAZFZOAP.Text = ""

        Me.txtTAZFTA01.Text = "0.00"
        Me.txtTAZFTA02.Text = "0.00"
        Me.txtTAZFTA03.Text = "0.00"
        Me.txtTAZFTA04.Text = "0.00"
        Me.txtTAZFTA05.Text = "0.00"
        Me.txtTAZFTA06.Text = "0.00"
        Me.txtTAZFTALO.Text = "0.00"

        Me.strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boTAZFDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZFDEPA)
            Dim boTAZFMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZFMUNI)
            Dim boTAZFCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZFCLSE)
            Dim boTAZFVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZFVIGE)
            Dim boTAZFZOFI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZFZOFI)
            Dim boTAZFTA01 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZFTA01)
            Dim boTAZFTA02 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZFTA02)
            Dim boTAZFTA03 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZFTA03)
            Dim boTAZFTA04 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZFTA04)
            Dim boTAZFTA05 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZFTA05)
            Dim boTAZFTA06 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZFTA06)
            Dim boTAZFZOAP As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZFZOAP)
            Dim boTAZFESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZFESTA)
            Dim boTAZFSIGN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZFSIGN)
            Dim boTAZFPORC As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZFPORC)
            Dim boTAZFTALO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZFTALO)

            ' verifica los datos del formulario 
            If boTAZFDEPA = True And _
               boTAZFMUNI = True And _
               boTAZFCLSE = True And _
               boTAZFVIGE = True And _
               boTAZFZOFI = True And _
               boTAZFTA01 = True And _
               boTAZFTA02 = True And _
               boTAZFTA03 = True And _
               boTAZFTA04 = True And _
               boTAZFTA05 = True And _
               boTAZFTA06 = True And _
               boTAZFZOAP = True And _
               boTAZFESTA = True And _
               boTAZFSIGN = True And _
               boTAZFPORC = True And _
               boTAZFTALO = True Then

                Dim objdatos22 As New cla_TARIZOFI

                If (objdatos22.fun_Actualizar_TARIZOFI(inID_REGISTRO, _
                                                       Me.cboTAZFDEPA.SelectedValue, _
                                                       Me.cboTAZFMUNI.SelectedValue, _
                                                       Me.cboTAZFCLSE.SelectedValue, _
                                                       Me.cboTAZFZOFI.SelectedValue, _
                                                       Me.txtTAZFTA01.Text, _
                                                       Me.txtTAZFTA02.Text, _
                                                       Me.txtTAZFTA03.Text, _
                                                       Me.txtTAZFTA04.Text, _
                                                       Me.txtTAZFTA05.Text, _
                                                       Me.txtTAZFTA06.Text, _
                                                       Me.cboTAZFZOAP.SelectedValue, _
                                                       Me.cboTAZFESTA.SelectedValue, _
                                                       Me.cboTAZFVIGE.SelectedValue, _
                                                       Me.cboTAZFSIGN.Text, _
                                                       Me.txtTAZFPORC.Text, _
                                                       Me.txtTAZFTALO.Text)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.cboTAZFDEPA.Focus()
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
        Me.txtTAZFTA01.Focus()
        Me.Close()

    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTAZFDEPA.KeyPress, cboTAZFMUNI.KeyPress, cboTAZFCLSE.KeyPress, cboTAZFVIGE.KeyPress, cboTAZFZOFI.KeyPress, cboTAZFZOAP.KeyPress, cboTAZFESTA.KeyPress, txtTAZFTA01.KeyPress, txtTAZFTA02.KeyPress, txtTAZFTA03.KeyPress, txtTAZFTA04.KeyPress, txtTAZFTA05.KeyPress, txtTAZFTA06.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTAZFDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZFDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTAZFDEPA, Me.cboTAZFDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAZFMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZFMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTAZFMUNI, Me.cboTAZFMUNI.SelectedIndex, Me.cboTAZFDEPA)
        End If
    End Sub
    Private Sub cboTAZFCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZFCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTAZFCLSE, Me.cboTAZFCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAZFVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZFVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTAZFVIGE, Me.cboTAZFVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAZFZOFI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZFZOFI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ZONAFISI_Descripcion(Me.cboTAZFZOFI, Me.cboTAZFZOFI.SelectedIndex, Me.cboTAZFDEPA, Me.cboTAZFMUNI, Me.cboTAZFCLSE)
        End If
    End Sub
    Private Sub cboTAZFZOAP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZFZOAP.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ZONAFISI_Descripcion(Me.cboTAZFZOAP, Me.cboTAZFZOAP.SelectedIndex, Me.cboTAZFDEPA, Me.cboTAZFMUNI, Me.cboTAZFCLSE)
        End If
    End Sub
    Private Sub cboTAZFESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZFESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTAZFESTA, Me.cboTAZFESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAZFTA01.GotFocus, txtTAZFTA02.GotFocus, txtTAZFTA03.GotFocus, txtTAZFTA04.GotFocus, txtTAZFTA05.GotFocus, txtTAZFTA06.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZFDEPA.GotFocus, cboTAZFMUNI.GotFocus, cboTAZFCLSE.GotFocus, cboTAZFVIGE.GotFocus, cboTAZFZOFI.GotFocus, cboTAZFZOAP.GotFocus, cboTAZFESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTAZFDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAZFDEPA.SelectedIndexChanged
        Me.lblTAZFDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboTAZFDEPA), String)

        Me.cboTAZFMUNI.DataSource = New DataTable
        Me.lblTAZFMUNI.Text = ""

        Me.cboTAZFZOFI.DataSource = New DataTable
        Me.lblTAZFZOFI.Text = ""

        Me.cboTAZFZOAP.DataSource = New DataTable
        Me.lblTAZFZOAP.Text = ""
    End Sub
    Private Sub cboTAZFMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAZFMUNI.SelectedIndexChanged
        Me.lblTAZFMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboTAZFDEPA, Me.cboTAZFMUNI), String)
    End Sub
    Private Sub cboTAZFCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAZFCLSE.SelectedIndexChanged
        Me.lblTAZFCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboTAZFCLSE), String)
    End Sub
    Private Sub cboTAZFVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAZFVIGE.SelectedIndexChanged
        Me.lblTAZFVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboTAZFVIGE), String)
    End Sub
    Private Sub cboTAZFZOFI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAZFZOFI.SelectedIndexChanged
        Me.lblTAZFZOFI.Text = CType(fun_Buscar_Lista_Valores_ZONAFISI_Codigo(Me.cboTAZFDEPA, Me.cboTAZFMUNI, Me.cboTAZFCLSE, Me.cboTAZFZOFI), String)
    End Sub
    Private Sub cboTAZFZOAP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAZFZOAP.SelectedIndexChanged
        Me.lblTAZFZOAP.Text = CType(fun_Buscar_Lista_Valores_ZONAFISI_Codigo(Me.cboTAZFDEPA, Me.cboTAZFMUNI, Me.cboTAZFCLSE, Me.cboTAZFZOAP), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTAZFDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZFDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTAZFDEPA, Me.cboTAZFDEPA.SelectedIndex)
    End Sub
    Private Sub cboTAZFMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZFMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTAZFMUNI, Me.cboTAZFMUNI.SelectedIndex, Me.cboTAZFDEPA)
    End Sub
    Private Sub cboTAZFCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZFCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTAZFCLSE, Me.cboTAZFCLSE.SelectedIndex)
    End Sub
    Private Sub cboTAZFVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZFVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTAZFVIGE, Me.cboTAZFVIGE.SelectedIndex)
    End Sub
    Private Sub cboTAZFZOFI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZFZOFI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAFISI_Descripcion(Me.cboTAZFZOFI, Me.cboTAZFZOFI.SelectedIndex, Me.cboTAZFDEPA, Me.cboTAZFMUNI, Me.cboTAZFCLSE)
    End Sub
    Private Sub cboTAZFZOAP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZFZOAP.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAFISI_Descripcion(Me.cboTAZFZOAP, Me.cboTAZFZOAP.SelectedIndex, Me.cboTAZFDEPA, Me.cboTAZFMUNI, Me.cboTAZFCLSE)
    End Sub
    Private Sub cboTAZFESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZFESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTAZFESTA, Me.cboTAZFESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAZFTA01.Validated, txtTAZFTA02.Validated, txtTAZFTA03.Validated, txtTAZFTA04.Validated, txtTAZFTA05.Validated, txtTAZFTA06.Validated, txtTAZFPORC.Validated

        If Trim(sender.text) = "" Then
            sender.text = "0.00"
        Else
            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZFTA01.Text) = True Then
                Me.txtTAZFTA01.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZFTA01.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZFTA02.Text) = True Then
                Me.txtTAZFTA02.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZFTA02.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZFTA03.Text) = True Then
                Me.txtTAZFTA03.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZFTA03.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZFTA04.Text) = True Then
                Me.txtTAZFTA04.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZFTA04.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZFTA05.Text) = True Then
                Me.txtTAZFTA05.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZFTA05.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZFTA06.Text) = True Then
                Me.txtTAZFTA06.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZFTA06.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZFPORC.Text) = True Then
                Me.txtTAZFPORC.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZFPORC.Text)
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


#End Region

End Class