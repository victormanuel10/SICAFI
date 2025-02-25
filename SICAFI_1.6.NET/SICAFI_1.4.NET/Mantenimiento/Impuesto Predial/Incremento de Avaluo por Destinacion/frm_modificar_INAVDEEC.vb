Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_INAVDEEC

    '=================================================================
    '*** MODIFICAR INCREMTNOS DE AVALUOS POR DESTINACIÓN ECONÓMICA ***
    '=================================================================

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

            Me.cboIADEDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboIADEDEPA.DisplayMember = "DEPADESC"
            Me.cboIADEDEPA.ValueMember = "DEPACODI"

            Dim objdatos2 As New cla_CLASSECT

            Me.cboIADECLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboIADECLSE.DisplayMember = "CLSEDESC"
            Me.cboIADECLSE.ValueMember = "CLSECODI"

            Dim objdatos22 As New cla_VIGENCIA

            Me.cboIADEVIGE.DataSource = objdatos22.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboIADEVIGE.DisplayMember = "VIGEDESC"
            Me.cboIADEVIGE.ValueMember = "VIGECODI"

            Dim objdatos6 As New cla_DESTECON

            Me.cboIADEDEEC.DataSource = objdatos6.fun_Consultar_CAMPOS_MANT_DESTECON
            Me.cboIADEDEEC.DisplayMember = "DEECDESC"
            Me.cboIADEDEEC.ValueMember = "DEECCODI"

            Dim objdatos As New cla_ESTADO

            Me.cboIADEESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
            Me.cboIADEESTA.DisplayMember = "ESIADESC"
            Me.cboIADEESTA.ValueMember = "ESTACODI"

            Dim objdatos3 As New cla_INAVDEEC
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_INAVDEEC(inID_REGISTRO)

            Me.cboIADEDEPA.SelectedValue = tbl.Rows(0).Item("IADEDEPA")

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboIADEMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboIADEMUNI.DisplayMember = "MUNIDESC"
            Me.cboIADEMUNI.ValueMember = "MUNICODI"

            Me.cboIADEMUNI.SelectedValue = tbl.Rows(0).Item("IADEMUNI")
            Me.cboIADECLSE.SelectedValue = tbl.Rows(0).Item("IADECLSE")
            Me.cboIADEDEEC.SelectedValue = tbl.Rows(0).Item("IADEDEEC")
            Me.txtIADETARI.Text = Trim(tbl.Rows(0).Item("IADETARI"))
            Me.cboIADEESTA.SelectedValue = tbl.Rows(0).Item("IADEESTA")
            Me.cboIADEVIGE.SelectedValue = tbl.Rows(0).Item("IADEVIGE")

            Dim boIADEDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboIADEDEPA.SelectedValue)
            Dim boIADEMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboIADEDEPA.SelectedValue, Me.cboIADEMUNI.SelectedValue)
            Dim boIADECLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboIADECLSE.SelectedValue)
            Dim boIADEDEEC As Boolean = fun_Buscar_Dato_DESTECON(Me.cboIADEDEEC.SelectedValue)
            Dim boIADEVIGE As Boolean = fun_Buscar_Dato_VIGENCIA(Me.cboIADEVIGE.SelectedValue)

            If boIADEDEPA = True OrElse boIADEMUNI = True OrElse boIADECLSE = True OrElse boIADEDEEC = True OrElse boIADEVIGE = True Then

                Me.lblIADEMUNI.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboIADEDEPA), String)
                Me.lblIADEDEPA.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboIADEDEPA, Me.cboIADEMUNI), String)
                Me.lblIADECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboIADECLSE), String)
                Me.lblIADEDEEC.Text = CType(fun_Buscar_Lista_Valores_DESTECON_Codigo(Me.cboIADEDEEC), String)
                Me.lblIADEVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboIADEVIGE), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtIADETARI.Text = "0.00"
        Me.lblIADEDEPA.Text = ""
        Me.lblIADEMUNI.Text = ""
        Me.lblIADECLSE.Text = ""
        Me.lblIADEVIGE.Text = ""

        Me.strBARRESTA.Items(1).Text = ""

        Me.cboIADEDEPA.DataSource = New DataTable
        Me.cboIADEMUNI.DataSource = New DataTable
        Me.cboIADECLSE.DataSource = New DataTable
        Me.cboIADEVIGE.DataSource = New DataTable
        Me.cboIADEESTA.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boIADEDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboIADEDEPA)
            Dim boIADEMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboIADEMUNI)
            Dim boIADECLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboIADECLSE)
            Dim boIADEVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboIADEVIGE)
            Dim boIADEDEEC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboIADEDEEC)
            Dim boIADETARI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtIADETARI)
            Dim boIADEESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboIADEESTA)

            ' verifica los datos del formulario 
            If boIADEDEPA = True And _
               boIADEMUNI = True And _
               boIADECLSE = True And _
               boIADEVIGE = True And _
               boIADEDEEC = True And _
               boIADETARI = True And _
               boIADEESTA = True Then

                Dim objdatos22 As New cla_INAVDEEC

                If (objdatos22.fun_Actualizar_INAVDEEC(inID_REGISTRO, _
                                                     Me.cboIADEDEPA.SelectedValue, _
                                                     Me.cboIADEMUNI.SelectedValue, _
                                                     Me.cboIADECLSE.SelectedValue, _
                                                     Me.cboIADEDEEC.SelectedValue, _
                                                     Me.txtIADETARI.Text, _
                                                     Me.cboIADEESTA.SelectedValue, _
                                                     Me.cboIADEVIGE.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.cboIADEDEPA.Focus()
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
        Me.cboIADEDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboIADEDEPA.KeyPress, cboIADEMUNI.KeyPress, cboIADECLSE.KeyPress, cboIADEVIGE.KeyPress, cboIADEDEEC.KeyPress, txtIADETARI.KeyPress, cboIADEESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboIADEDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboIADEDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboIADEDEPA, Me.cboIADEDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboIADEMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboIADEMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboIADEMUNI, Me.cboIADEMUNI.SelectedIndex, Me.cboIADEDEPA)
        End If
    End Sub
    Private Sub cboIADECLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboIADECLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboIADECLSE, Me.cboIADECLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboIADEVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboIADEVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboIADEVIGE, Me.cboIADEVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboIADEDEED_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboIADEDEEC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboIADEDEEC, Me.cboIADEDEEC.SelectedIndex)
        End If
    End Sub
    Private Sub cboIADEESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboIADEESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboIADEESTA, Me.cboIADEESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIADETARI.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIADEDEPA.GotFocus, cboIADEMUNI.GotFocus, cboIADECLSE.GotFocus, cboIADEVIGE.GotFocus, cboIADEDEEC.GotFocus, cboIADEESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboIADEDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIADEDEPA.SelectedIndexChanged
        Me.lblIADEDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboIADEDEPA), String)

        Me.cboIADEMUNI.DataSource = New DataTable
        Me.lblIADEMUNI.Text = ""

    End Sub
    Private Sub cboIADEMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIADEMUNI.SelectedIndexChanged
        Me.lblIADEMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboIADEDEPA, Me.cboIADEMUNI), String)
    End Sub
    Private Sub cboIADECLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIADECLSE.SelectedIndexChanged
        Me.lblIADECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboIADECLSE), String)
    End Sub
    Private Sub cboIADEVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIADEVIGE.SelectedIndexChanged
        Me.lblIADEVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboIADEVIGE), String)
    End Sub
    Private Sub cboIADEDEEC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIADEDEEC.SelectedIndexChanged
        Me.lblIADEDEEC.Text = CType(fun_Buscar_Lista_Valores_DESTECON_Codigo(Me.cboIADEDEPA), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboIADEDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIADEDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboIADEDEPA, Me.cboIADEDEPA.SelectedIndex)
    End Sub
    Private Sub cboIADEMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIADEMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboIADEMUNI, Me.cboIADEMUNI.SelectedIndex, Me.cboIADEDEPA)
    End Sub
    Private Sub cboIADECLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIADECLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboIADECLSE, Me.cboIADECLSE.SelectedIndex)
    End Sub
    Private Sub cboIADEVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIADEVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboIADEVIGE, Me.cboIADEVIGE.SelectedIndex)
    End Sub
    Private Sub cboIADEDEEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIADEDEEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboIADEDEEC, Me.cboIADEDEEC.SelectedIndex)
    End Sub
    Private Sub cboIADEESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIADEESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboIADEESTA, Me.cboIADEESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtIADEAVFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIADETARI.Validated
        If Trim(sender.text) = "" Then
            sender.text = "0.00"
        Else
            If fun_Verificar_Dato_Decimal_Evento_Validated(Me.txtIADETARI.Text) = True Then
                Me.txtIADETARI.Text = fun_Formato_Decimal_2_Decimales(Me.txtIADETARI.Text)
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