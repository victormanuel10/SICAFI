Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_TARIDEEC

    '===================================================
    '*** MODIFICAR TARIFAS POR DESTINACIÓN ECONÓMICA ***
    '===================================================

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

            Me.cboTADEDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboTADEDEPA.DisplayMember = "DEPADESC"
            Me.cboTADEDEPA.ValueMember = "DEPACODI"

            Dim objdatos2 As New cla_CLASSECT

            Me.cboTADECLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboTADECLSE.DisplayMember = "CLSEDESC"
            Me.cboTADECLSE.ValueMember = "CLSECODI"

            Dim objdatos22 As New cla_VIGENCIA

            Me.cboTADEVIGE.DataSource = objdatos22.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboTADEVIGE.DisplayMember = "VIGEDESC"
            Me.cboTADEVIGE.ValueMember = "VIGECODI"

            Dim objdatos6 As New cla_DESTECON

            Me.cboTADEDEEC.DataSource = objdatos6.fun_Consultar_CAMPOS_MANT_DESTECON
            Me.cboTADEDEEC.DisplayMember = "DEECDESC"
            Me.cboTADEDEEC.ValueMember = "DEECCODI"

            Dim objdatos As New cla_ESTADO

            Me.cboTADEESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
            Me.cboTADEESTA.DisplayMember = "ESTADESC"
            Me.cboTADEESTA.ValueMember = "ESTACODI"

            Dim objdatos3 As New cla_TARIDEEC
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_TARIDEEC(inID_REGISTRO)

            Me.cboTADEDEPA.SelectedValue = tbl.Rows(0).Item("TADEDEPA")

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboTADEMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboTADEMUNI.DisplayMember = "MUNIDESC"
            Me.cboTADEMUNI.ValueMember = "MUNICODI"

            Me.cboTADEMUNI.SelectedValue = tbl.Rows(0).Item("TADEMUNI")
            Me.cboTADECLSE.SelectedValue = tbl.Rows(0).Item("TADECLSE")
            Me.cboTADEDEEC.SelectedValue = tbl.Rows(0).Item("TADEDEEC")
            Me.txtTADETARI.Text = Trim(tbl.Rows(0).Item("TADETARI"))
            Me.cboTADEESTA.SelectedValue = tbl.Rows(0).Item("TADEESTA")
            Me.cboTADEVIGE.SelectedValue = tbl.Rows(0).Item("TADEVIGE")

            Dim boTADEDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboTADEDEPA.SelectedValue)
            Dim boTADEMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboTADEDEPA.SelectedValue, Me.cboTADEMUNI.SelectedValue)
            Dim boTADECLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboTADECLSE.SelectedValue)
            Dim boTADEDEEC As Boolean = fun_Buscar_Dato_DESTECON(Me.cboTADEDEEC.SelectedValue)
            Dim boTADEVIGE As Boolean = fun_Buscar_Dato_VIGENCIA(Me.cboTADEVIGE.SelectedValue)

            If boTADEDEPA = True OrElse boTADEMUNI = True OrElse boTADECLSE = True OrElse boTADEDEEC = True OrElse boTADEVIGE = True Then

                Me.lblTADEMUNI.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboTADEDEPA), String)
                Me.lblTADEDEPA.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboTADEDEPA, Me.cboTADEMUNI), String)
                Me.lblTADECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboTADECLSE), String)
                Me.lblTADEDEEC.Text = CType(fun_Buscar_Lista_Valores_DESTECON_Codigo(Me.cboTADEDEEC), String)
                Me.lblTADEVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboTADEVIGE), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtTADETARI.Text = "0.00"
        Me.lblTADEDEPA.Text = ""
        Me.lblTADEMUNI.Text = ""
        Me.lblTADECLSE.Text = ""
        Me.lblTADEVIGE.Text = ""

        Me.strBARRESTA.Items(1).Text = ""

        Me.cboTADEDEPA.DataSource = New DataTable
        Me.cboTADEMUNI.DataSource = New DataTable
        Me.cboTADECLSE.DataSource = New DataTable
        Me.cboTADEVIGE.DataSource = New DataTable
        Me.cboTADEESTA.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boTADEDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTADEDEPA)
            Dim boTADEMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTADEMUNI)
            Dim boTADECLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTADECLSE)
            Dim boTADEVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTADEVIGE)
            Dim boTADEDEEC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTADEDEEC)
            Dim boTADETARI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtTADETARI)
            Dim boTADEESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTADEESTA)

            ' verifica los datos del formulario 
            If boTADEDEPA = True And _
               boTADEMUNI = True And _
               boTADECLSE = True And _
               boTADEVIGE = True And _
               boTADEDEEC = True And _
               boTADETARI = True And _
               boTADEESTA = True Then

                Dim objdatos22 As New cla_TARIDEEC

                If (objdatos22.fun_Actualizar_TARIDEEC(inID_REGISTRO, _
                                                     Me.cboTADEDEPA.SelectedValue, _
                                                     Me.cboTADEMUNI.SelectedValue, _
                                                     Me.cboTADECLSE.SelectedValue, _
                                                     Me.cboTADEDEEC.SelectedValue, _
                                                     Me.txtTADETARI.Text, _
                                                     Me.cboTADEESTA.SelectedValue, _
                                                     Me.cboTADEVIGE.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.cboTADEDEPA.Focus()
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
        Me.cboTADEDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTADEDEPA.KeyPress, cboTADEMUNI.KeyPress, cboTADECLSE.KeyPress, cboTADEVIGE.KeyPress, cboTADEDEEC.KeyPress, txtTADETARI.KeyPress, cboTADEESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTAPEDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTADEDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTADEDEPA, Me.cboTADEDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTADEMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTADEMUNI, Me.cboTADEMUNI.SelectedIndex, Me.cboTADEDEPA)
        End If
    End Sub
    Private Sub cboTAPECLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTADECLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTADECLSE, Me.cboTADECLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTADEVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTADEVIGE, Me.cboTADEVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEDEED_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTADEDEEC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboTADEDEEC, Me.cboTADEDEEC.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTADEESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTADEESTA, Me.cboTADEESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTADETARI.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTADEDEPA.GotFocus, cboTADEMUNI.GotFocus, cboTADECLSE.GotFocus, cboTADEVIGE.GotFocus, cboTADEDEEC.GotFocus, cboTADEESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTAPEDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTADEDEPA.SelectedIndexChanged
        Me.lblTADEDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboTADEDEPA), String)

        Me.cboTADEMUNI.DataSource = New DataTable
        Me.lblTADEMUNI.Text = ""

    End Sub
    Private Sub cboTAPEMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTADEMUNI.SelectedIndexChanged
        Me.lblTADEMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboTADEDEPA, Me.cboTADEMUNI), String)
    End Sub
    Private Sub cboTAPECLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTADECLSE.SelectedIndexChanged
        Me.lblTADECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboTADECLSE), String)
    End Sub
    Private Sub cboTAPEVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTADEVIGE.SelectedIndexChanged
        Me.lblTADEVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboTADEVIGE), String)
    End Sub
    Private Sub cboTADEDEEC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTADEDEEC.SelectedIndexChanged
        Me.lblTADEDEEC.Text = CType(fun_Buscar_Lista_Valores_DESTECON_Codigo(Me.cboTADEDEPA), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTAPEDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTADEDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTADEDEPA, Me.cboTADEDEPA.SelectedIndex)
    End Sub
    Private Sub cboTAPEMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTADEMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTADEMUNI, Me.cboTADEMUNI.SelectedIndex, Me.cboTADEDEPA)
    End Sub
    Private Sub cboTAPECLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTADECLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTADECLSE, Me.cboTADECLSE.SelectedIndex)
    End Sub
    Private Sub cboTAPEVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTADEVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTADEVIGE, Me.cboTADEVIGE.SelectedIndex)
    End Sub
    Private Sub cboTAPEDEEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTADEDEEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboTADEDEEC, Me.cboTADEDEEC.SelectedIndex)
    End Sub
    Private Sub cboTAPEESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTADEESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTADEESTA, Me.cboTADEESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTAAPAVFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTADETARI.Validated
        If Trim(sender.text) = "" Then
            sender.text = "0.00"
        Else
            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtTADETARI.Text) = True Then
                Me.txtTADETARI.Text = fun_Formato_Decimal_2_Decimales(Me.txtTADETARI.Text)
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