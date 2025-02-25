Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_TARIRAAR

    '============================================
    '*** MODIFICAR TARIFA POR RANGOS DE AREAS ***
    '============================================

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
            Dim objdatos1 As New cla_DEPARTAMENTO

            Me.cboTARADEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboTARADEPA.DisplayMember = "DEPADESC"
            Me.cboTARADEPA.ValueMember = "DEPACODI"

            Dim objdatos2 As New cla_CLASSECT

            Me.cboTARACLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboTARACLSE.DisplayMember = "CLSEDESC"
            Me.cboTARACLSE.ValueMember = "CLSECODI"

            Dim objdatos27 As New cla_VIGENCIA

            Me.cboTARAVIGE.DataSource = objdatos27.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboTARAVIGE.DisplayMember = "VIGEDESC"
            Me.cboTARAVIGE.ValueMember = "VIGECODI"

            Dim objdatos28 As New cla_DESTECON

            Me.cboTARADEEC.DataSource = objdatos28.fun_Consultar_CAMPOS_MANT_DESTECON
            Me.cboTARADEEC.DisplayMember = "DEECDESC"
            Me.cboTARADEEC.ValueMember = "DEECCODI"

            Dim objdatos29 As New cla_ESTRATO

            Me.cboTARAESTR.DataSource = objdatos29.fun_Consultar_CAMPOS_MANT_ESTRATO
            Me.cboTARAESTR.DisplayMember = "ESTRDESC"
            Me.cboTARAESTR.ValueMember = "ESTRCODI"

            Dim objdatos As New cla_ESTADO

            Me.cboTARAESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboTARAESTA.DisplayMember = "ESTADESC"
            Me.cboTARAESTA.ValueMember = "ESTACODI"

            Dim objdatos3 As New cla_TARIRAAR
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_TARIRAAR(inID_REGISTRO)

            Me.cboTARADEPA.SelectedValue = tbl.Rows(0).Item("TARADEPA")

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboTARAMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboTARAMUNI.DisplayMember = "MUNIDESC"
            Me.cboTARAMUNI.ValueMember = "MUNICODI"

            Me.cboTARAMUNI.SelectedValue = tbl.Rows(0).Item("TARAMUNI")
            Me.cboTARACLSE.SelectedValue = tbl.Rows(0).Item("TARACLSE")
            Me.cboTARAVIGE.SelectedValue = tbl.Rows(0).Item("TARAVIGE")
            Me.cboTARADEEC.SelectedValue = tbl.Rows(0).Item("TARADEEC")
            Me.cboTARAESTR.SelectedValue = tbl.Rows(0).Item("TARAESTR")

            Me.txtTARATARI.Text = fun_Formato_Decimal_2_Decimales(Trim(tbl.Rows(0).Item("TARATARI")))
            Me.txtTARAAVIN.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("TARAAVIN")))
            Me.txtTARAAVFI.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("TARAAVFI")))

            Me.cboTARAESTA.SelectedValue = tbl.Rows(0).Item("TARAESTA")

            Dim boTARADEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboTARADEPA.SelectedValue)
            Dim boTARAMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboTARADEPA.SelectedValue, Me.cboTARAMUNI.SelectedValue)
            Dim boTARACLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboTARACLSE.SelectedValue)
            Dim boTARAVIGE As Boolean = fun_Buscar_Dato_VIGENCIA(Me.cboTARAVIGE.SelectedValue)
            Dim boTARADEEC As Boolean = fun_Buscar_Dato_DESTECON(Me.cboTARADEEC.SelectedValue)
            Dim boTARAESTR As Boolean = fun_Buscar_Dato_ESTRATO(Me.cboTARAESTR.SelectedValue)

            If boTARADEPA = True OrElse _
               boTARAMUNI = True OrElse _
               boTARACLSE = True OrElse _
               boTARAVIGE = True OrElse _
               boTARADEEC = True OrElse _
               boTARAESTR = True Then

                Me.lblTARADEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboTARADEPA), String)
                Me.lblTARAMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboTARADEPA, Me.cboTARAMUNI), String)
                Me.lblTARACLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboTARACLSE), String)
                Me.lblTARAVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboTARAVIGE), String)
                Me.lblTARADEEC.Text = CType(fun_Buscar_Lista_Valores_DESTECON_Codigo(Me.cboTARADEEC), String)
                Me.lblTARAESTR.Text = CType(fun_Buscar_Lista_Valores_ESTRATO_Codigo(Me.cboTARAESTR), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboTARADEPA.DataSource = New DataTable
        Me.cboTARAMUNI.DataSource = New DataTable
        Me.cboTARACLSE.DataSource = New DataTable
        Me.cboTARAVIGE.DataSource = New DataTable
        Me.cboTARADEEC.DataSource = New DataTable
        Me.cboTARAESTR.DataSource = New DataTable
        Me.cboTARAESTA.DataSource = New DataTable

        Me.txtTARAAVIN.Text = "0"
        Me.txtTARAAVFI.Text = "0"

        Me.lblTARADEPA.Text = ""
        Me.lblTARAMUNI.Text = ""
        Me.lblTARACLSE.Text = ""
        Me.lblTARAVIGE.Text = ""
        Me.lblTARADEEC.Text = ""
        Me.lblTARAESTR.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            Me.txtTARAAVIN.Text = fun_Quita_Letras(Me.txtTARAAVIN)
            Me.txtTARAAVFI.Text = fun_Quita_Letras(Me.txtTARAAVFI)

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boTARADEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTARADEPA)
            Dim boTARAMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTARAMUNI)
            Dim boTARACLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTARACLSE)
            Dim boTARAVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTARAVIGE)
            Dim boTARADEEC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTARADEEC)
            Dim boTARAESTR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTARAESTR)
            Dim boTARAAVIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTARAAVIN)
            Dim boTARAAVFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTARAAVFI)
            Dim boTARATARI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTARATARI)
            Dim boTARAESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTARAESTA)

            ' verifica los datos del formulario 
            If boTARADEPA = True And _
               boTARAMUNI = True And _
               boTARACLSE = True And _
               boTARAVIGE = True And _
               boTARADEEC = True And _
               boTARAESTR = True And _
               boTARAAVIN = True And _
               boTARATARI = True And _
               boTARAAVFI = True And _
               boTARAESTA = True Then

                Dim objdatos22 As New cla_TARIRAAR

                If (objdatos22.fun_Actualizar_TARIRAAR(inID_REGISTRO, _
                                                         Me.cboTARADEPA.SelectedValue, _
                                                         Me.cboTARAMUNI.SelectedValue, _
                                                         Me.cboTARACLSE.SelectedValue, _
                                                         Me.cboTARAVIGE.SelectedValue, _
                                                         Me.cboTARADEEC.SelectedValue, _
                                                         Me.cboTARAESTR.SelectedValue, _
                                                         Me.txtTARATARI.Text, _
                                                         Me.txtTARAAVIN.Text, _
                                                         Me.txtTARAAVFI.Text, _
                                                         Me.cboTARAESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.cboTARADEPA.Focus()
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
        Me.cboTARADEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTARADEPA.KeyPress, cboTARAMUNI.KeyPress, cboTARACLSE.KeyPress, cboTARAVIGE.KeyPress, cboTARADEEC.KeyPress, txtTARATARI.KeyPress, txtTARAAVIN.KeyPress, txtTARAAVFI.KeyPress, cboTARAESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTARADEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTARADEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTARADEPA, Me.cboTARADEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboTARAMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTARAMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTARAMUNI, Me.cboTARAMUNI.SelectedIndex, Me.cboTARADEPA)
        End If
    End Sub
    Private Sub cboTARACLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTARACLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTARACLSE, Me.cboTARACLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTARAVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTARAVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTARAVIGE, Me.cboTARAVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTARADEEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTARADEEC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboTARADEEC, Me.cboTARADEEC.SelectedIndex)
        End If
    End Sub
    Private Sub cboTARAESTR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTARAESTR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboTARAESTR, Me.cboTARAESTR.SelectedIndex)
        End If
    End Sub
    Private Sub cboTARAESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTARAESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTARAESTA, Me.cboTARAESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTARATARI.GotFocus, txtTARAAVIN.GotFocus, txtTARAAVFI.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTARADEPA.GotFocus, cboTARAMUNI.GotFocus, cboTARACLSE.GotFocus, cboTARAVIGE.GotFocus, cboTARADEEC.GotFocus, cboTARAESTA.GotFocus, cboTARAESTR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTARADEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTARADEPA.SelectedIndexChanged
        Me.lblTARADEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboTARADEPA), String)

        Me.cboTARAMUNI.DataSource = New DataTable
        Me.lblTARAMUNI.Text = ""
    End Sub
    Private Sub cboTARAMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTARAMUNI.SelectedIndexChanged
        Me.lblTARAMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboTARADEPA, Me.cboTARAMUNI), String)
    End Sub
    Private Sub cboTARACLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTARACLSE.SelectedIndexChanged
        Me.lblTARACLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboTARACLSE), String)
    End Sub
    Private Sub cboTARAVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTARAVIGE.SelectedIndexChanged
        Me.lblTARAVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboTARAVIGE), String)
    End Sub
    Private Sub cboTARADEEC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTARADEEC.SelectedIndexChanged
        Me.lblTARADEEC.Text = CType(fun_Buscar_Lista_Valores_DESTECON_Codigo(Me.cboTARADEEC), String)
    End Sub
    Private Sub cboTARAESTR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTARAESTR.SelectedIndexChanged
        Me.lblTARAESTR.Text = CType(fun_Buscar_Lista_Valores_ESTRATO_Codigo(Me.cboTARAESTR), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTARADEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTARADEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTARADEPA, Me.cboTARADEPA.SelectedIndex)
    End Sub
    Private Sub cboTARAMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTARAMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTARAMUNI, Me.cboTARAMUNI.SelectedIndex, Me.cboTARADEPA)
    End Sub
    Private Sub cboTARACLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTARACLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTARACLSE, Me.cboTARACLSE.SelectedIndex)
    End Sub
    Private Sub cboTARAVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTARAVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTARAVIGE, Me.cboTARAVIGE.SelectedIndex)
    End Sub
    Private Sub cboTARADEEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTARADEEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboTARADEEC, Me.cboTARADEEC.SelectedIndex)
    End Sub
    Private Sub cboTARAESTR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTARAESTR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboTARAESTR, Me.cboTARAESTR.SelectedIndex)
    End Sub
    Private Sub cboTARAESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTARAESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTARAESTA, Me.cboTARAESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTARATARI.Validated, txtTARAAVIN.Validated, txtTARAAVFI.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTARAAVIN.Text) = True Then
                Me.txtTARAAVIN.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTARAAVIN.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTARAAVFI.Text) = True Then
                Me.txtTARAAVFI.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTARAAVFI.Text)
            End If

        End If

        Me.txtTARATARI.Text = fun_Formato_Decimal_2_Decimales(Me.txtTARATARI.Text)

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