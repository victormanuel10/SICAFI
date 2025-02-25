Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_TARIPRES

    '===========================================
    '*** MODIFICAR TARIFA PREDIOS ESPECIALES ***
    '===========================================

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

            Me.cboTAPEDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboTAPEDEPA.DisplayMember = "DEPADESC"
            Me.cboTAPEDEPA.ValueMember = "DEPACODI"

            Dim objdatos2 As New cla_CLASSECT

            Me.cboTAPECLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboTAPECLSE.DisplayMember = "CLSEDESC"
            Me.cboTAPECLSE.ValueMember = "CLSECODI"

            Dim objdatos27 As New cla_VIGENCIA

            Me.cboTAPEVIGE.DataSource = objdatos27.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboTAPEVIGE.DisplayMember = "VIGEDESC"
            Me.cboTAPEVIGE.ValueMember = "VIGECODI"

            Dim objdatos28 As New cla_DESTECON

            Me.cboTAPEDEEC.DataSource = objdatos28.fun_Consultar_CAMPOS_MANT_DESTECON
            Me.cboTAPEDEEC.DisplayMember = "DEECDESC"
            Me.cboTAPEDEEC.ValueMember = "DEECCODI"

            Dim objdatos As New cla_ESTADO

            Me.cboTAPEESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboTAPEESTA.DisplayMember = "ESTADESC"
            Me.cboTAPEESTA.ValueMember = "ESTACODI"

            Dim objdatos3 As New cla_TARIPRES
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_TARIPRES(inID_REGISTRO)

            Me.cboTAPEDEPA.SelectedValue = tbl.Rows(0).Item("TAPEDEPA")

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboTAPEMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboTAPEMUNI.DisplayMember = "MUNIDESC"
            Me.cboTAPEMUNI.ValueMember = "MUNICODI"

            Me.cboTAPEMUNI.SelectedValue = tbl.Rows(0).Item("TAPEMUNI")
            Me.cboTAPECLSE.SelectedValue = tbl.Rows(0).Item("TAPECLSE")
            Me.cboTAPEVIGE.SelectedValue = tbl.Rows(0).Item("TAPEVIGE")
            Me.cboTAPEDEEC.SelectedValue = tbl.Rows(0).Item("TAPEDEEC")

            Me.txtTAPETARI.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("TAPETARI")))
            Me.txtTAPEAVIN.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("TAPEAVIN")))
            Me.txtTAPEAVFI.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("TAPEAVFI")))

            Me.cboTAPEESTA.SelectedValue = tbl.Rows(0).Item("TAPEESTA")

            Dim boTAPEDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboTAPEDEPA.SelectedValue)
            Dim boTAPEMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboTAPEDEPA.SelectedValue, Me.cboTAPEMUNI.SelectedValue)
            Dim boTAPECLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboTAPECLSE.SelectedValue)
            Dim boTAPEVIGE As Boolean = fun_Buscar_Dato_VIGENCIA(Me.cboTAPEVIGE.SelectedValue)
            Dim boTAPEDEEC As Boolean = fun_Buscar_Dato_DESTECON(Me.cboTAPEDEEC.SelectedValue)
           
            If boTAPEDEPA = True OrElse _
               boTAPEMUNI = True OrElse _
               boTAPECLSE = True OrElse _
               boTAPEVIGE = True OrElse _
               boTAPEDEEC = True Then

                Me.lblTAPEDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboTAPEDEPA), String)
                Me.lblTAPEMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboTAPEDEPA, Me.cboTAPEMUNI), String)
                Me.lblTAPECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboTAPECLSE), String)
                Me.lblTAPEVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboTAPEVIGE), String)
                Me.lblTAPEDEEC.Text = CType(fun_Buscar_Lista_Valores_DESTECON_Codigo(Me.cboTAPEDEEC), String)
                
            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboTAPEDEPA.DataSource = New DataTable
        Me.cboTAPEMUNI.DataSource = New DataTable
        Me.cboTAPECLSE.DataSource = New DataTable
        Me.cboTAPEVIGE.DataSource = New DataTable
        Me.cboTAPEDEEC.DataSource = New DataTable
        Me.cboTAPEESTA.DataSource = New DataTable

        Me.txtTAPEAVIN.Text = "0"
        Me.txtTAPEAVFI.Text = "0"

        Me.lblTAPEDEPA.Text = ""
        Me.lblTAPEMUNI.Text = ""
        Me.lblTAPECLSE.Text = ""
        Me.lblTAPEVIGE.Text = ""
        Me.lblTAPEDEEC.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            Me.txtTAPETARI.Text = fun_Quita_Letras(Me.txtTAPETARI)
            Me.txtTAPEAVIN.Text = fun_Quita_Letras(Me.txtTAPEAVIN)
            Me.txtTAPEAVFI.Text = fun_Quita_Letras(Me.txtTAPEAVFI)

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boTAPEDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAPEDEPA)
            Dim boTAPEMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAPEMUNI)
            Dim boTAPECLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAPECLSE)
            Dim boTAPEVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAPEVIGE)
            Dim boTAPEDEEC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAPEDEEC)
            Dim boTAPETARI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAPETARI)
            Dim boTAPEAVIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAPEAVIN)
            Dim boTAPEAVFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTAPEAVFI)
            Dim boTAPEESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTAPEESTA)

            ' verifica los datos del formulario 
            If boTAPEDEPA = True And _
               boTAPEMUNI = True And _
               boTAPECLSE = True And _
               boTAPEVIGE = True And _
               boTAPEDEEC = True And _
               boTAPETARI = True And _
               boTAPEAVIN = True And _
               boTAPEAVFI = True And _
               boTAPEESTA = True Then

                Dim objdatos22 As New cla_TARIPRES

                If (objdatos22.fun_Actualizar_TARIPRES(inID_REGISTRO, _
                                                         Me.cboTAPEDEPA.SelectedValue, _
                                                         Me.cboTAPEMUNI.SelectedValue, _
                                                         Me.cboTAPECLSE.SelectedValue, _
                                                         Me.cboTAPEVIGE.SelectedValue, _
                                                         Me.cboTAPEDEEC.SelectedValue, _
                                                         Me.txtTAPETARI.Text, _
                                                         Me.txtTAPEAVIN.Text, _
                                                         Me.txtTAPEAVFI.Text, _
                                                         Me.cboTAPEESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.cboTAPEDEPA.Focus()
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
        Me.cboTAPEDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTAPEDEPA.KeyPress, cboTAPEMUNI.KeyPress, cboTAPECLSE.KeyPress, cboTAPEVIGE.KeyPress, cboTAPEDEEC.KeyPress, txtTAPETARI.KeyPress, txtTAPEAVIN.KeyPress, txtTAPEAVFI.KeyPress, cboTAPEESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTAPEDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAPEDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTAPEDEPA, Me.cboTAPEDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAPEMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTAPEMUNI, Me.cboTAPEMUNI.SelectedIndex, Me.cboTAPEDEPA)
        End If
    End Sub
    Private Sub cboTAPECLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAPECLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTAPECLSE, Me.cboTAPECLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAPEVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTAPEVIGE, Me.cboTAPEVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEDEEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAPEDEEC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboTAPEDEEC, Me.cboTAPEDEEC.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTAPEESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTAPEESTA, Me.cboTAPEESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAPETARI.GotFocus, txtTAPEAVIN.GotFocus, txtTAPEAVFI.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAPEDEPA.GotFocus, cboTAPEMUNI.GotFocus, cboTAPECLSE.GotFocus, cboTAPEVIGE.GotFocus, cboTAPEDEEC.GotFocus, cboTAPEESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTAPEDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAPEDEPA.SelectedIndexChanged
        Me.lblTAPEDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboTAPEDEPA), String)

        Me.cboTAPEMUNI.DataSource = New DataTable
        Me.lblTAPEMUNI.Text = ""
    End Sub
    Private Sub cboTAPEMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAPEMUNI.SelectedIndexChanged
        Me.lblTAPEMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboTAPEDEPA, Me.cboTAPEMUNI), String)
    End Sub
    Private Sub cboTAPECLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAPECLSE.SelectedIndexChanged
        Me.lblTAPECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboTAPECLSE), String)
    End Sub
    Private Sub cboTAPEVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAPEVIGE.SelectedIndexChanged
        Me.lblTAPEVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboTAPEVIGE), String)
    End Sub
    Private Sub cboTAPEDEEC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTAPEDEEC.SelectedIndexChanged
        Me.lblTAPEDEEC.Text = CType(fun_Buscar_Lista_Valores_DESTECON_Codigo(Me.cboTAPEDEEC), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTAPEDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAPEDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboTAPEDEPA, Me.cboTAPEDEPA.SelectedIndex)
    End Sub
    Private Sub cboTAPEMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAPEMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTAPEMUNI, Me.cboTAPEMUNI.SelectedIndex, Me.cboTAPEDEPA)
    End Sub
    Private Sub cboTAPECLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAPECLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboTAPECLSE, Me.cboTAPECLSE.SelectedIndex)
    End Sub
    Private Sub cboTAPEVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAPEVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboTAPEVIGE, Me.cboTAPEVIGE.SelectedIndex)
    End Sub
    Private Sub cboTAPEDEEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAPEDEEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboTAPEDEEC, Me.cboTAPEDEEC.SelectedIndex)
    End Sub
    Private Sub cboTAPEESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTAPEESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTAPEESTA, Me.cboTAPEESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTAAPAVFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTAPETARI.Validated, txtTAPEAVIN.Validated, txtTAPEAVFI.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTAPETARI.Text) = True Then
                Me.txtTAPETARI.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTAPETARI.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTAPEAVIN.Text) = True Then
                Me.txtTAPEAVIN.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTAPEAVIN.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTAPEAVFI.Text) = True Then
                Me.txtTAPEAVFI.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTAPEAVFI.Text)
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