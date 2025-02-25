Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_TARIZOEC

    '============================================
    '*** MODIFICAR TARIFAS POR ZONA ECONÓMICA ***
    '============================================

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
            Dim objdatos3 As New cla_TARIZOEC
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_TARIZOEC(inID_REGISTRO)

            Dim objdatos1 As New cla_DEPARTAMENTO

            Me.cboTAZEDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboTAZEDEPA.DisplayMember = "DEPADESC"
            Me.cboTAZEDEPA.ValueMember = "DEPACODI"

            Me.cboTAZEDEPA.SelectedValue = tbl.Rows(0).Item("TAZEDEPA")

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboTAZEMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboTAZEMUNI.DisplayMember = "MUNIDESC"
            Me.cboTAZEMUNI.ValueMember = "MUNICODI"

            Me.cboTAZEMUNI.SelectedValue = tbl.Rows(0).Item("TAZEMUNI")

            Dim objdatos2 As New cla_CLASSECT

            Me.cboTAZECLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboTAZECLSE.DisplayMember = "CLSEDESC"
            Me.cboTAZECLSE.ValueMember = "CLSECODI"

            Me.cboTAZECLSE.SelectedValue = tbl.Rows(0).Item("TAZECLSE")

            Dim objdatos22 As New cla_VIGENCIA

            Me.cboTAZEVIGE.DataSource = objdatos22.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboTAZEVIGE.DisplayMember = "VIGEDESC"
            Me.cboTAZEVIGE.ValueMember = "VIGECODI"

            Me.cboTAZEVIGE.SelectedValue = tbl.Rows(0).Item("TAZEVIGE")

            Dim objdatos4 As New cla_ZONAECON

            Me.cboTAZEZOEC.DataSource = objdatos4.fun_Consultar_CAMPOS_MANT_ZONAECON()
            Me.cboTAZEZOEC.DisplayMember = "ZOECDESC"
            Me.cboTAZEZOEC.ValueMember = "ZOECCODI"

            Me.cboTAZEZOEC.SelectedValue = tbl.Rows(0).Item("TAZEZOEC")

            Dim objdatos55 As New cla_ZONAECON

            Me.cboTAZEZOAP.DataSource = objdatos55.fun_Consultar_CAMPOS_MANT_ZONAECON()
            Me.cboTAZEZOAP.DisplayMember = "ZOECDESC"
            Me.cboTAZEZOAP.ValueMember = "ZOECCODI"

            Me.cboTAZEZOAP.SelectedValue = tbl.Rows(0).Item("TAZEZOAP")

            Dim objdatos As New cla_ESTADO

            Me.cboTAZEESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
            Me.cboTAZEESTA.DisplayMember = "ESTADESC"
            Me.cboTAZEESTA.ValueMember = "ESTACODI"

            Me.cboTAZEESTA.SelectedValue = tbl.Rows(0).Item("TAZEESTA")

            Me.txtTAZETA01.Text = Trim(tbl.Rows(0).Item("TAZETA01"))
            Me.txtTAZETA02.Text = Trim(tbl.Rows(0).Item("TAZETA02"))
            Me.txtTAZETA03.Text = Trim(tbl.Rows(0).Item("TAZETA03"))
            Me.txtTAZETA04.Text = Trim(tbl.Rows(0).Item("TAZETA04"))
            Me.txtTAZETA05.Text = Trim(tbl.Rows(0).Item("TAZETA05"))
            Me.txtTAZETA06.Text = Trim(tbl.Rows(0).Item("TAZETA06"))

            Me.cboTAZESIGN.SelectedItem = Trim(tbl.Rows(0).Item("TAZESIGN"))
            Me.txtTAZEPORC.Text = Trim(tbl.Rows(0).Item("TAZEPORC"))
            Me.txtTAZETALO.Text = Trim(tbl.Rows(0).Item("TAZETALO"))

            Dim boTAZEDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(cboTAZEDEPA.SelectedValue)
            Dim boTAZEMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(cboTAZEDEPA.SelectedValue, cboTAZEMUNI.SelectedValue)
            Dim boTAZECLSE As Boolean = fun_Buscar_Dato_CLASSECT(cboTAZECLSE.SelectedValue)
            Dim boTAZEVIGE As Boolean = fun_Buscar_Dato_VIGENCIA(cboTAZEVIGE.SelectedValue)
            Dim boTAZEZOEC As Boolean = fun_Buscar_Dato_ZONAECON(cboTAZEZOEC.SelectedValue)
            Dim boTAZEZOAP As Boolean = fun_Buscar_Dato_ZONAECON(cboTAZEZOAP.SelectedValue)

            If boTAZEDEPA = True OrElse boTAZEMUNI = True OrElse boTAZECLSE = True OrElse boTAZEZOEC = True OrElse boTAZEZOAP = True Then

                Me.lblTAZEDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboTAZEDEPA), String)
                Me.lblTAZEMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboTAZEDEPA, Me.cboTAZEMUNI), String)
                Me.lblTAZECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboTAZECLSE), String)
                Me.lblTAZEVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboTAZEVIGE), String)
                Me.lblTAZEZOEC.Text = CType(fun_Buscar_Lista_Valores_ZONAECON_Codigo(Me.cboTAZEDEPA, Me.cboTAZEMUNI, Me.cboTAZECLSE, Me.cboTAZEZOEC), String)
                Me.lblTAZEZOAP.Text = CType(fun_Buscar_Lista_Valores_ZONAECON_Codigo(Me.cboTAZEDEPA, Me.cboTAZEMUNI, Me.cboTAZECLSE, Me.cboTAZEZOAP), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        Me.txtTAZETA01.Focus()

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboTAZEDEPA.DataSource = New DataTable
        Me.cboTAZEMUNI.DataSource = New DataTable
        Me.cboTAZECLSE.DataSource = New DataTable
        Me.cboTAZEVIGE.DataSource = New DataTable
        Me.cboTAZEZOEC.DataSource = New DataTable
        Me.cboTAZEZOAP.DataSource = New DataTable

        Me.lblTAZEDEPA.Text = ""
        Me.lblTAZEMUNI.Text = ""
        Me.lblTAZECLSE.Text = ""
        Me.lblTAZEVIGE.Text = ""
        Me.lblTAZEZOEC.Text = ""
        Me.lblTAZEZOAP.Text = ""

        Me.txtTAZETA01.Text = "0.00"
        Me.txtTAZETA02.Text = "0.00"
        Me.txtTAZETA03.Text = "0.00"
        Me.txtTAZETA04.Text = "0.00"
        Me.txtTAZETA05.Text = "0.00"
        Me.txtTAZETA06.Text = "0.00"
        Me.txtTAZETALO.Text = "0.00"

        Me.strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
      
        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boTAZEDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZEDEPA)
            Dim boTAZEMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZEMUNI)
            Dim boTAZECLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZECLSE)
            Dim boTAZEVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZEVIGE)
            Dim boTAZEZOEC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZEZOEC)
            Dim boTAZETA01 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZETA01)
            Dim boTAZETA02 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZETA02)
            Dim boTAZETA03 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZETA03)
            Dim boTAZETA04 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZETA04)
            Dim boTAZETA05 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZETA05)
            Dim boTAZETA06 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZETA06)
            Dim boTAZEZOAP As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZEZOAP)
            Dim boTAZEESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZEESTA)
            Dim boTAZESIGN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAZESIGN)
            Dim boTAZEPORC As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZEPORC)
            Dim boTAZETALO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTAZETALO)

            ' verifica los datos del formulario 
            If boTAZEDEPA = True And _
               boTAZEMUNI = True And _
               boTAZECLSE = True And _
               boTAZEVIGE = True And _
               boTAZEZOEC = True And _
               boTAZETA01 = True And _
               boTAZETA02 = True And _
               boTAZETA03 = True And _
               boTAZETA04 = True And _
               boTAZETA05 = True And _
               boTAZETA06 = True And _
               boTAZEZOAP = True And _
               boTAZEESTA = True And _
               boTAZESIGN = True And _
               boTAZEPORC = True And _
               boTAZETALO = True Then

                Dim objdatos22 As New cla_TARIZOEC

                If (objdatos22.fun_Actualizar_TARIZOEC(inID_REGISTRO, _
                                                       Me.cboTAZEDEPA.SelectedValue, _
                                                       Me.cboTAZEMUNI.SelectedValue, _
                                                       Me.cboTAZECLSE.SelectedValue, _
                                                       Me.cboTAZEZOEC.SelectedValue, _
                                                       Me.txtTAZETA01.Text, _
                                                       Me.txtTAZETA02.Text, _
                                                       Me.txtTAZETA03.Text, _
                                                       Me.txtTAZETA04.Text, _
                                                       Me.txtTAZETA05.Text, _
                                                       Me.txtTAZETA06.Text, _
                                                       Me.cboTAZEZOAP.SelectedValue, _
                                                       Me.cboTAZEESTA.SelectedValue, _
                                                       Me.cboTAZEVIGE.SelectedValue, _
                                                       Me.cboTAZESIGN.Text, _
                                                       Me.txtTAZEPORC.Text, _
                                                       Me.txtTAZETALO.Text)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.cboTAZEDEPA.Focus()
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
        Me.txtTAZETA01.Focus()
        Me.Close()

    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTAZEDEPA.KeyPress, cboTAZEMUNI.KeyPress, cboTAZECLSE.KeyPress, cboTAZEVIGE.KeyPress, cboTAZEZOEC.KeyPress, cboTAZEZOAP.KeyPress, cboTAZEESTA.KeyPress, txtTAZETA01.KeyPress, txtTAZETA02.KeyPress, txtTAZETA03.KeyPress, txtTAZETA04.KeyPress, txtTAZETA05.KeyPress, txtTAZETA06.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTAZEDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZEDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTAZEDEPA, Me.cboTAZEDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAZEMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZEMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTAZEMUNI, Me.cboTAZEMUNI.SelectedIndex, Me.cboTAZEDEPA)
        End If
    End Sub
    Private Sub cboTAZECLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZECLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTAZECLSE, Me.cboTAZECLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAZEVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZEVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTAZEVIGE, Me.cboTAZEVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAZEZOEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZEZOEC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON_Descripcion(Me.cboTAZEZOEC, Me.cboTAZEZOEC.SelectedIndex, Me.cboTAZEDEPA, Me.cboTAZEMUNI, Me.cboTAZECLSE)
        End If
    End Sub
    Private Sub cboTAZEZOAP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZEZOAP.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON_Descripcion(Me.cboTAZEZOAP, Me.cboTAZEZOAP.SelectedIndex, Me.cboTAZEDEPA, Me.cboTAZEMUNI, Me.cboTAZECLSE)
        End If
    End Sub
    Private Sub cboTAZEESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAZEESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTAZEESTA, Me.cboTAZEESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAZETA01.GotFocus, txtTAZETA02.GotFocus, txtTAZETA03.GotFocus, txtTAZETA04.GotFocus, txtTAZETA05.GotFocus, txtTAZETA06.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZEDEPA.GotFocus, cboTAZEMUNI.GotFocus, cboTAZECLSE.GotFocus, cboTAZEVIGE.GotFocus, cboTAZEZOEC.GotFocus, cboTAZEZOAP.GotFocus, cboTAZEESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTAZEDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAZEDEPA.SelectedIndexChanged
        Me.lblTAZEDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboTAZEDEPA), String)

        Me.cboTAZEMUNI.DataSource = New DataTable
        Me.lblTAZEMUNI.Text = ""

        Me.cboTAZEZOEC.DataSource = New DataTable
        Me.lblTAZEZOEC.Text = ""

        Me.cboTAZEZOAP.DataSource = New DataTable
        Me.lblTAZEZOAP.Text = ""
    End Sub
    Private Sub cboTAZEMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAZEMUNI.SelectedIndexChanged
        Me.lblTAZEMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboTAZEDEPA, Me.cboTAZEMUNI), String)
    End Sub
    Private Sub cboTAZECLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAZECLSE.SelectedIndexChanged
        Me.lblTAZECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboTAZECLSE), String)
    End Sub
    Private Sub cboTAZEVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAZEVIGE.SelectedIndexChanged
        Me.lblTAZEVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboTAZEVIGE), String)
    End Sub
    Private Sub cboTAZEZOEC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAZEZOEC.SelectedIndexChanged
        Me.lblTAZEZOEC.Text = CType(fun_Buscar_Lista_Valores_ZONAECON_Codigo(Me.cboTAZEDEPA, Me.cboTAZEMUNI, Me.cboTAZECLSE, Me.cboTAZEZOEC), String)
    End Sub
    Private Sub cboTAZEZOAP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAZEZOAP.SelectedIndexChanged
        Me.lblTAZEZOAP.Text = CType(fun_Buscar_Lista_Valores_ZONAECON_Codigo(Me.cboTAZEDEPA, Me.cboTAZEMUNI, Me.cboTAZECLSE, Me.cboTAZEZOAP), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTAZEDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZEDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTAZEDEPA, Me.cboTAZEDEPA.SelectedIndex)
    End Sub
    Private Sub cboTAZEMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZEMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTAZEMUNI, Me.cboTAZEMUNI.SelectedIndex, Me.cboTAZEDEPA)
    End Sub
    Private Sub cboTAZECLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZECLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTAZECLSE, Me.cboTAZECLSE.SelectedIndex)
    End Sub
    Private Sub cboTAZEVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZEVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTAZEVIGE, Me.cboTAZEVIGE.SelectedIndex)
    End Sub
    Private Sub cboTAZEZOEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZEZOEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON_Descripcion(Me.cboTAZEZOEC, Me.cboTAZEZOEC.SelectedIndex, Me.cboTAZEDEPA, Me.cboTAZEMUNI, Me.cboTAZECLSE)
    End Sub
    Private Sub cboTAZEZOAP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZEZOAP.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON_Descripcion(Me.cboTAZEZOAP, Me.cboTAZEZOAP.SelectedIndex, Me.cboTAZEDEPA, Me.cboTAZEMUNI, Me.cboTAZECLSE)
    End Sub
    Private Sub cboTAZEESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAZEESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTAZEESTA, Me.cboTAZEESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAZETA01.Validated, txtTAZETA02.Validated, txtTAZETA03.Validated, txtTAZETA04.Validated, txtTAZETA05.Validated, txtTAZETA06.Validated, txtTAZEPORC.Validated

        If Trim(sender.text) = "" Then
            sender.text = "0.00"
        Else
            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZETA01.Text) = True Then
                Me.txtTAZETA01.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZETA01.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZETA02.Text) = True Then
                Me.txtTAZETA02.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZETA02.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZETA03.Text) = True Then
                Me.txtTAZETA03.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZETA03.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZETA04.Text) = True Then
                Me.txtTAZETA04.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZETA04.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZETA05.Text) = True Then
                Me.txtTAZETA05.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZETA05.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZETA06.Text) = True Then
                Me.txtTAZETA06.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZETA06.Text)
            End If

            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTAZEPORC.Text) = True Then
                Me.txtTAZEPORC.Text = fun_Formato_Decimal_2_Decimales(Me.txtTAZEPORC.Text)
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