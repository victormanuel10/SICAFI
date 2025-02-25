Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_DEECLOTE

    '=================================================
    '*** MODIFICAR DESTINACIÓN ECONÓMICA POR LOTES ***
    '=================================================

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

            Me.cboDELODEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboDELODEPA.DisplayMember = "DEPADESC"
            Me.cboDELODEPA.ValueMember = "DEPACODI"

            Dim objdatos2 As New cla_CLASSECT

            Me.cboDELOCLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboDELOCLSE.DisplayMember = "CLSEDESC"
            Me.cboDELOCLSE.ValueMember = "CLSECODI"

            Dim objdatos27 As New cla_VIGENCIA

            Me.cboDELOVIGE.DataSource = objdatos27.fun_Consultar_CAMPOS_VIGENCIA
            Me.cboDELOVIGE.DisplayMember = "VIGEDESC"
            Me.cboDELOVIGE.ValueMember = "VIGECODI"

            Dim objdatos28 As New cla_DESTECON

            Me.cboDELODEEC.DataSource = objdatos28.fun_Consultar_CAMPOS_MANT_DESTECON
            Me.cboDELODEEC.DisplayMember = "DEECDESC"
            Me.cboDELODEEC.ValueMember = "DEECCODI"

            Dim objdatos As New cla_ESTADO

            Me.cboDELOESTA.DataSource = objdatos.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboDELOESTA.DisplayMember = "ESTADESC"
            Me.cboDELOESTA.ValueMember = "ESTACODI"

            Dim objdatos3 As New cla_DEECLOTE
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_DEECLOTE(inID_REGISTRO)

            Me.cboDELODEPA.SelectedValue = tbl.Rows(0).Item("DELODEPA")

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboDELOMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboDELOMUNI.DisplayMember = "MUNIDESC"
            Me.cboDELOMUNI.ValueMember = "MUNICODI"

            Me.cboDELOMUNI.SelectedValue = tbl.Rows(0).Item("DELOMUNI")
            Me.cboDELOCLSE.SelectedValue = tbl.Rows(0).Item("DELOCLSE")
            Me.cboDELOVIGE.SelectedValue = tbl.Rows(0).Item("DELOVIGE")
            Me.cboDELODEEC.SelectedValue = tbl.Rows(0).Item("DELODEEC")
            Me.chkDELOLOTE.Checked = tbl.Rows(0).Item("DELOLOTE")
            Me.chkDELOLE44.Checked = tbl.Rows(0).Item("DELOLE44")
            Me.chkDELOIMPR.Checked = tbl.Rows(0).Item("DELOIMPR")
            Me.chkDELOACBO.Checked = tbl.Rows(0).Item("DELOACBO")
            Me.chkDELOALPU.Checked = tbl.Rows(0).Item("DELOALPU")
            Me.chkDELOTAAS.Checked = tbl.Rows(0).Item("DELOTAAS")
            Me.cboDELOESTA.SelectedValue = tbl.Rows(0).Item("DELOESTA")

            Dim boDELODEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboDELODEPA.SelectedValue)
            Dim boDELOMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboDELODEPA.SelectedValue, Me.cboDELOMUNI.SelectedValue)
            Dim boDELOCLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboDELOCLSE.SelectedValue)
            Dim boDELOVIGE As Boolean = fun_Buscar_Dato_VIGENCIA(Me.cboDELOVIGE.SelectedValue)
            Dim boDELODEEC As Boolean = fun_Buscar_Dato_DESTECON(Me.cboDELODEEC.SelectedValue)

            If boDELODEPA = True OrElse _
               boDELOMUNI = True OrElse _
               boDELOCLSE = True OrElse _
               boDELOVIGE = True OrElse _
               boDELODEEC = True Then

                Me.lblDELODEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboDELODEPA), String)
                Me.lblDELOMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboDELODEPA, Me.cboDELOMUNI), String)
                Me.lblDELOCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboDELOCLSE), String)
                Me.lblDELOVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboDELOVIGE), String)
                Me.lblDELODEEC.Text = CType(fun_Buscar_Lista_Valores_DESTECON_Codigo(Me.cboDELODEEC), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboDELODEPA.DataSource = New DataTable
        Me.cboDELOMUNI.DataSource = New DataTable
        Me.cboDELOCLSE.DataSource = New DataTable
        Me.cboDELOVIGE.DataSource = New DataTable
        Me.cboDELODEEC.DataSource = New DataTable
        Me.cboDELOESTA.DataSource = New DataTable

        Me.lblDELODEPA.Text = ""
        Me.lblDELOMUNI.Text = ""
        Me.lblDELOCLSE.Text = ""
        Me.lblDELOVIGE.Text = ""
        Me.lblDELODEEC.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
             ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boTAPEDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboDELODEPA)
            Dim boTAPEMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboDELOMUNI)
            Dim boTAPECLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboDELOCLSE)
            Dim boTAPEVIGE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboDELOVIGE)
            Dim boTAPEDEEC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboDELODEEC)
            Dim boTAPEESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboDELOESTA)

            ' verifica los datos del formulario 
            If boTAPEDEPA = True And _
               boTAPEMUNI = True And _
               boTAPECLSE = True And _
               boTAPEVIGE = True And _
               boTAPEDEEC = True And _
               boTAPEESTA = True Then

                Dim objdatos22 As New cla_DEECLOTE

                If (objdatos22.fun_Actualizar_DEECLOTE(inID_REGISTRO, _
                                                         Me.cboDELODEPA.SelectedValue, _
                                                         Me.cboDELOMUNI.SelectedValue, _
                                                         Me.cboDELOCLSE.SelectedValue, _
                                                         Me.cboDELOVIGE.SelectedValue, _
                                                         Me.cboDELODEEC.SelectedValue, _
                                                         Me.chkDELOLOTE.Checked, _
                                                         Me.chkDELOLE44.Checked, _
                                                         Me.chkDELOIMPR.Checked, _
                                                         Me.chkDELOACBO.Checked, _
                                                         Me.chkDELOALPU.Checked, _
                                                         Me.chkDELOTAAS.Checked, _
                                                         Me.cboDELOESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.cboDELODEPA.Focus()
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
        Me.cboDELODEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDELODEPA.KeyPress, cboDELOMUNI.KeyPress, cboDELOCLSE.KeyPress, cboDELOVIGE.KeyPress, cboDELODEEC.KeyPress, cboDELOESTA.KeyPress, chkDELOLOTE.KeyPress, chkDELOLE44.KeyPress, chkDELOIMPR.KeyPress, chkDELOACBO.KeyPress, chkDELOALPU.KeyPress, chkDELOTAAS.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboTAPEDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDELODEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboDELODEPA, Me.cboDELODEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDELOMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboDELOMUNI, Me.cboDELOMUNI.SelectedIndex, Me.cboDELODEPA)
        End If
    End Sub
    Private Sub cboTAPECLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDELOCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboDELOCLSE, Me.cboDELOCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDELOVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboDELOVIGE, Me.cboDELOVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEDEEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDELODEEC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboDELODEEC, Me.cboDELODEEC.SelectedIndex)
        End If
    End Sub
    Private Sub cboTAPEESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDELOESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboDELOESTA, Me.cboDELOESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDELODEPA.GotFocus, cboDELOMUNI.GotFocus, cboDELOCLSE.GotFocus, cboDELOVIGE.GotFocus, cboDELODEEC.GotFocus, cboDELOESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub chk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDELOLOTE.GotFocus, chkDELOLE44.GotFocus, chkDELOIMPR.GotFocus, chkDELOACBO.GotFocus, chkDELOALPU.GotFocus, chkDELOTAAS.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboTAPEDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDELODEPA.SelectedIndexChanged
        Me.lblDELODEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboDELODEPA), String)

        Me.cboDELOMUNI.DataSource = New DataTable
        Me.lblDELOMUNI.Text = ""
    End Sub
    Private Sub cboTAPEMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDELOMUNI.SelectedIndexChanged
        Me.lblDELOMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboDELODEPA, Me.cboDELOMUNI), String)
    End Sub
    Private Sub cboTAPECLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDELOCLSE.SelectedIndexChanged
        Me.lblDELOCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboDELOCLSE), String)
    End Sub
    Private Sub cboTAPEVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDELOVIGE.SelectedIndexChanged
        Me.lblDELOVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboDELOVIGE), String)
    End Sub
    Private Sub cboTAPEDEEC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDELODEEC.SelectedIndexChanged
        Me.lblDELODEEC.Text = CType(fun_Buscar_Lista_Valores_DESTECON_Codigo(Me.cboDELODEEC), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboTAPEDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDELODEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboDELODEPA, Me.cboDELODEPA.SelectedIndex)
    End Sub
    Private Sub cboTAPEMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDELOMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboDELOMUNI, Me.cboDELOMUNI.SelectedIndex, Me.cboDELODEPA)
    End Sub
    Private Sub cboTAPECLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDELOCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboDELOCLSE, Me.cboDELOCLSE.SelectedIndex)
    End Sub
    Private Sub cboTAPEVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDELOVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboDELOVIGE, Me.cboDELOVIGE.SelectedIndex)
    End Sub
    Private Sub cboTAPEDEEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDELODEEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboDELODEEC, Me.cboDELODEEC.SelectedIndex)
    End Sub
    Private Sub cboTAPEESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDELOESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboDELOESTA, Me.cboDELOESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtTAAPAVFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        If Trim(sender.text) = "" Then
            sender.text = 0
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