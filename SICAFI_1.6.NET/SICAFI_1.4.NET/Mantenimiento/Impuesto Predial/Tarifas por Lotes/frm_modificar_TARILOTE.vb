Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_TARILOTE

    '==================================
    '*** MODIFICAR TARIFA POR LOTES ***
    '==================================

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

            Me.cboTALODEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboTALODEPA.DisplayMember = "DEPADESC"
            Me.cboTALODEPA.ValueMember = "DEPACODI"

            Dim objdatos2 As New cla_CLASSECT

            Me.cboTALOCLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboTALOCLSE.DisplayMember = "CLSEDESC"
            Me.cboTALOCLSE.ValueMember = "CLSECODI"

            Dim objdatos27 As New cla_VIGENCIA

            Me.cboTALOVIGE.DataSource = objdatos27.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboTALOVIGE.DisplayMember = "VIGEDESC"
            Me.cboTALOVIGE.ValueMember = "VIGECODI"

            Dim objdatos As New cla_ESTADO

            Me.cboTALOESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboTALOESTA.DisplayMember = "ESTADESC"
            Me.cboTALOESTA.ValueMember = "ESTACODI"

            Dim objdatos3 As New cla_TARILOTE
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_TARILOTE(inID_REGISTRO)

            Me.cboTALODEPA.SelectedValue = tbl.Rows(0).Item("TALODEPA")

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboTALOMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboTALOMUNI.DisplayMember = "MUNIDESC"
            Me.cboTALOMUNI.ValueMember = "MUNICODI"

            Me.cboTALOMUNI.SelectedValue = tbl.Rows(0).Item("TALOMUNI")
            Me.cboTALOCLSE.SelectedValue = tbl.Rows(0).Item("TALOCLSE")
            Me.cboTALOVIGE.SelectedValue = tbl.Rows(0).Item("TALOVIGE")

            Dim objdatos28 As New cla_ZONAECON

            Me.cboTALOZOEC.DataSource = objdatos28.fun_Consultar_CAMPOS_MANT_ZONAECON
            Me.cboTALOZOEC.DisplayMember = "ZOECDESC"
            Me.cboTALOZOEC.ValueMember = "ZOECCODI"

            Me.cboTALOZOEC.SelectedValue = tbl.Rows(0).Item("TALOZOEC")

            Me.txtTALOTARI.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("TALOTARI")))
            Me.txtTALOAVIN.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("TALOAVIN")))
            Me.txtTALOAVFI.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("TALOAVFI")))

            Me.cboTALOESTA.SelectedValue = tbl.Rows(0).Item("TALOESTA")

            Dim boTALODEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboTALODEPA.SelectedValue)
            Dim boTALOMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboTALODEPA.SelectedValue, Me.cboTALOMUNI.SelectedValue)
            Dim boTALOCLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboTALOCLSE.SelectedValue)
            Dim boTALOVIGE As Boolean = fun_Buscar_Dato_VIGENCIA(Me.cboTALOVIGE.SelectedValue)
            Dim boTALOZOEC As Boolean = fun_Buscar_Dato_ZONAECON(Me.cboTALOZOEC.SelectedValue)

            If boTALODEPA = True OrElse _
               boTALOMUNI = True OrElse _
               boTALOCLSE = True OrElse _
               boTALOVIGE = True OrElse _
               boTALOZOEC = True Then

                Me.lblTALODEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboTALODEPA), String)
                Me.lblTALOMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboTALODEPA, Me.cboTALOMUNI), String)
                Me.lblTALOCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboTALOCLSE), String)
                Me.lblTALOVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboTALOVIGE), String)
                Me.lblTALOZOEC.Text = CType(fun_Buscar_Lista_Valores_ZONAECON_Codigo(Me.cboTALODEPA, Me.cboTALOMUNI, Me.cboTALOCLSE, Me.cboTALOZOEC), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboTALODEPA.DataSource = New DataTable
        Me.cboTALOMUNI.DataSource = New DataTable
        Me.cboTALOCLSE.DataSource = New DataTable
        Me.cboTALOVIGE.DataSource = New DataTable
        Me.cboTALOZOEC.DataSource = New DataTable
        Me.cboTALOESTA.DataSource = New DataTable

        Me.txtTALOTARI.Text = "0"
        Me.txtTALOAVIN.Text = "0"
        Me.txtTALOAVFI.Text = "0"

        Me.lblTALODEPA.Text = ""
        Me.lblTALOMUNI.Text = ""
        Me.lblTALOCLSE.Text = ""
        Me.lblTALOVIGE.Text = ""
        Me.lblTALOZOEC.Text = ""

    End Sub

#End Region


#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            Me.txtTALOTARI.Text = fun_Quita_Letras(Me.txtTALOTARI)
            Me.txtTALOAVIN.Text = fun_Quita_Letras(Me.txtTALOAVIN)
            Me.txtTALOAVFI.Text = fun_Quita_Letras(Me.txtTALOAVFI)

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boTAPEDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTALODEPA)
            Dim boTAPEMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTALOMUNI)
            Dim boTAPECLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTALOCLSE)
            Dim boTAPEVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTALOVIGE)
            Dim boTAPEZOEC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTALOZOEC)
            Dim boTAPETARI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTALOTARI)
            Dim boTAPEAVIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTALOAVIN)
            Dim boTAPEAVFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtTALOAVFI)
            Dim boTAPEESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboTALOESTA)

            ' verifica los datos del formulario 
            If boTAPEDEPA = True And _
               boTAPEMUNI = True And _
               boTAPECLSE = True And _
               boTAPEVIGE = True And _
               boTAPEZOEC = True And _
               boTAPETARI = True And _
               boTAPEAVIN = True And _
               boTAPEAVFI = True And _
               boTAPEESTA = True Then

                Dim objdatos22 As New cla_TARILOTE

                If (objdatos22.fun_Actualizar_TARILOTE(inID_REGISTRO, _
                                                         Me.cboTALODEPA.SelectedValue, _
                                                         Me.cboTALOMUNI.SelectedValue, _
                                                         Me.cboTALOCLSE.SelectedValue, _
                                                         Me.cboTALOVIGE.SelectedValue, _
                                                         Me.cboTALOZOEC.SelectedValue, _
                                                         Me.txtTALOTARI.Text, _
                                                         Me.txtTALOAVIN.Text, _
                                                         Me.txtTALOAVFI.Text, _
                                                         Me.cboTALOESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.cboTALODEPA.Focus()
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
        Me.cboTALODEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTALODEPA.KeyPress, cboTALOMUNI.KeyPress, cboTALOCLSE.KeyPress, cboTALOVIGE.KeyPress, cboTALOZOEC.KeyPress, txtTALOTARI.KeyPress, txtTALOAVIN.KeyPress, txtTALOAVFI.KeyPress, cboTALOESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTAPEDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTALODEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO(Me.cboTALODEPA, Me.cboTALODEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTALOMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboTALOMUNI, Me.cboTALOMUNI.SelectedIndex, Me.cboTALODEPA)
        End If
    End Sub
    Private Sub cboTAPECLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTALOCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT(Me.cboTALOCLSE, Me.cboTALOCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTALOVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA(Me.cboTALOVIGE, Me.cboTALOVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEZOEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTALOZOEC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON_Descripcion(Me.cboTALOZOEC, Me.cboTALOZOEC.SelectedIndex, Me.cboTALODEPA, Me.cboTALOMUNI, Me.cboTALOCLSE)
        End If
    End Sub
    Private Sub cboTAPEESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTALOESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTALOESTA, Me.cboTALOESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTALOTARI.GotFocus, txtTALOAVIN.GotFocus, txtTALOAVFI.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTALODEPA.GotFocus, cboTALOMUNI.GotFocus, cboTALOCLSE.GotFocus, cboTALOVIGE.GotFocus, cboTALOZOEC.GotFocus, cboTALOESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTAPEDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTALODEPA.SelectedIndexChanged
        Me.lblTALODEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Me.cboTALODEPA.Text), String)

        Me.cboTALOMUNI.DataSource = New DataTable
        Me.lblTALOMUNI.Text = ""

        Me.cboTALOZOEC.DataSource = New DataTable
        Me.lblTALOZOEC.Text = ""
    End Sub
    Private Sub cboTAPEMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTALOMUNI.SelectedIndexChanged
        Me.lblTALOMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.cboTALODEPA.Text, Me.cboTALOMUNI.Text), String)
    End Sub
    Private Sub cboTAPECLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTALOCLSE.SelectedIndexChanged
        Me.lblTALOCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.cboTALOCLSE.Text), String)
    End Sub
    Private Sub cboTAPEVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTALOVIGE.SelectedIndexChanged
        Me.lblTALOVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.cboTALOVIGE.Text), String)
    End Sub
    Private Sub cboTAPEZOEC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTALOZOEC.SelectedIndexChanged
        Me.lblTALOZOEC.Text = CType(fun_Buscar_Lista_Valores_ZONAECON(Me.cboTALODEPA.Text, Me.cboTALOMUNI.Text, Me.cboTALOCLSE.Text, Me.cboTALOZOEC.Text), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTAPEDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTALODEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO(Me.cboTALODEPA, Me.cboTALODEPA.SelectedIndex)
    End Sub
    Private Sub cboTAPEMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTALOMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO(Me.cboTALOMUNI, Me.cboTALODEPA.Text)
    End Sub
    Private Sub cboTAPECLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTALOCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT(Me.cboTALOCLSE, Me.cboTALOCLSE.SelectedIndex)
    End Sub
    Private Sub cboTAPEVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTALOVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA(Me.cboTALOVIGE, Me.cboTALOVIGE.SelectedIndex)
    End Sub
    Private Sub cboTAPEZOEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTALOZOEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON(Me.cboTALOZOEC, Me.cboTALOZOEC.SelectedIndex, Me.cboTALODEPA.Text, Me.cboTALOMUNI.Text, Me.cboTALOCLSE.Text)
    End Sub
    Private Sub cboTAPEESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTALOESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboTALOESTA, Me.cboTALOESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTAAPAVFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTALOTARI.Validated, txtTALOAVIN.Validated, txtTALOAVFI.Validated
        If Trim(sender.text) = "" Then
            sender.text = 0
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTALOTARI.Text) = True Then
                Me.txtTALOTARI.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTALOTARI.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTALOAVIN.Text) = True Then
                Me.txtTALOAVIN.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTALOAVIN.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtTALOAVFI.Text) = True Then
                Me.txtTALOAVFI.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtTALOAVFI.Text)
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