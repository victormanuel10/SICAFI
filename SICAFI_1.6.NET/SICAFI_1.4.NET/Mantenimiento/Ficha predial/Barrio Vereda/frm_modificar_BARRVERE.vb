Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_BARRVERE

    '=================================
    '*** MODIFICAR BARRIO - VEREDA ***
    '=================================

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

            Me.cboBAVEDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboBAVEDEPA.DisplayMember = "DEPADESC"
            Me.cboBAVEDEPA.ValueMember = "DEPACODI"

            Dim objdatos As New cla_ESTADO

            Me.cboBAVEESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
            Me.cboBAVEESTA.DisplayMember = "ESTADESC"
            Me.cboBAVEESTA.ValueMember = "ESTACODI"

            Dim objdatos3 As New cla_BARRVERE
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_BARRVERE(inID_REGISTRO)

            Me.cboBAVEDEPA.SelectedValue = tbl.Rows(0).Item("BAVEDEPA")

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboBAVEMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboBAVEMUNI.DisplayMember = "MUNIDESC"
            Me.cboBAVEMUNI.ValueMember = "MUNICODI"

            Me.cboBAVEMUNI.SelectedValue = tbl.Rows(0).Item("BAVEMUNI")

            Dim objdatos2 As New cla_CLASSECT

            Me.cboBAVECLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboBAVECLSE.DisplayMember = "CLSEDESC"
            Me.cboBAVECLSE.ValueMember = "CLSECODI"

            Me.cboBAVECLSE.SelectedValue = tbl.Rows(0).Item("BAVECLSE")

            Dim objdatos5 As New cla_CORREGIMIENTO

            Me.cboBAVECORR.DataSource = objdatos5.fun_Consultar_CAMPOS_CORREGIMIENTO
            Me.cboBAVECORR.DisplayMember = "CORRDESC"
            Me.cboBAVECORR.ValueMember = "CORRCODI"

            Me.cboBAVECORR.SelectedValue = tbl.Rows(0).Item("BAVECORR")

            Me.txtBAVECODI.Text = Trim(tbl.Rows(0).Item("BAVECODI"))
            Me.txtBAVEDESC.Text = Trim(tbl.Rows(0).Item("BAVEDESC"))
            Me.cboBAVEESTA.SelectedValue = tbl.Rows(0).Item("BAVEESTA")

            Dim boBAVEDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboBAVEDEPA.SelectedValue)
            Dim boBAVEMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboBAVEDEPA.SelectedValue, Me.cboBAVEMUNI.SelectedValue)
            Dim boBAVECLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboBAVECLSE.SelectedValue)
            Dim boBAVECORR As Boolean = fun_Buscar_Dato_CORREGIMIENTO(Me.cboBAVEDEPA.SelectedValue, Me.cboBAVEMUNI.SelectedValue, Me.cboBAVECLSE.SelectedValue, Me.cboBAVECORR.SelectedValue)

            If boBAVEDEPA = True OrElse boBAVEMUNI = True OrElse boBAVECLSE = True OrElse boBAVECORR = True Then

                Me.lblBAVEDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboBAVEDEPA), String)
                Me.lblBAVEMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboBAVEDEPA, Me.cboBAVEMUNI), String)
                Me.lblBAVECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboBAVECLSE), String)
                Me.lblBAVECORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO_Codigo(Me.cboBAVEDEPA, Me.cboBAVEMUNI, Me.cboBAVECLSE, Me.cboBAVECORR), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraBARRVERE)

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boBAVEDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboBAVEDEPA)
            Dim boBAVEMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboBAVEMUNI)
            Dim boBAVECLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboBAVECLSE)
            Dim boBAVECODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtBAVECODI)
            Dim boBAVEDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtBAVEDESC)
            Dim boBAVEESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboBAVEESTA)
            Dim boBAVECORR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboBAVECORR)

            ' verifica los datos del formulario 
            If boBAVEDEPA = True And _
               boBAVEMUNI = True And _
               boBAVECLSE = True And _
               boBAVECORR = True And _
               boBAVECODI = True And _
               boBAVEDESC = True And _
               boBAVEESTA = True Then

                Dim objdatos22 As New cla_BARRVERE

                If (objdatos22.fun_Actualizar_BARRVERE(inID_REGISTRO, _
                                                         Me.cboBAVEDEPA.SelectedValue, _
                                                         Me.cboBAVEMUNI.SelectedValue, _
                                                         Me.cboBAVECLSE.SelectedValue, _
                                                         Me.txtBAVECODI.Text, _
                                                         Me.txtBAVEDESC.Text, _
                                                         Me.cboBAVEESTA.SelectedValue, _
                                                         Me.cboBAVECORR.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    Me.cboBAVEDEPA.Focus()
                    Me.Close()
                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Guardar")
        End Try


    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.cboBAVEDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboBAVEDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBAVEDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboBAVEDEPA, Me.cboBAVEDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboBAVEMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBAVEMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboBAVEMUNI, Me.cboBAVEMUNI.SelectedIndex, Me.cboBAVEDEPA)
        End If
    End Sub
    Private Sub cboBAVECLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBAVECLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboBAVECLSE, Me.cboBAVECLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboBAVEESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBAVEESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboBAVEESTA, Me.cboBAVEESTA.SelectedIndex)
        End If
    End Sub
    Private Sub cboBAVECORR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBAVECORR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CORREGIMIENTO_X_MUNICIPIO_Descripcion(Me.cboBAVECORR, Me.cboBAVECORR.SelectedIndex, Me.cboBAVEDEPA, Me.cboBAVEMUNI, Me.cboBAVECLSE)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboBAVEDEPA.KeyPress, cboBAVEMUNI.KeyPress, cboBAVECLSE.KeyPress, txtBAVECODI.KeyPress, txtBAVEDESC.KeyPress, cboBAVEESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBAVECODI.GotFocus, txtBAVEDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBAVEDEPA.GotFocus, cboBAVEMUNI.GotFocus, cboBAVECLSE.GotFocus, cboBAVEESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub rbd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboBAVEDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBAVEDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboBAVEDEPA, Me.cboBAVEDEPA.SelectedIndex)
    End Sub
    Private Sub cboBAVEMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBAVEMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboBAVEMUNI, Me.cboBAVEMUNI.SelectedIndex, Me.cboBAVEDEPA)
    End Sub
    Private Sub cboBAVECLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBAVECLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboBAVECLSE, Me.cboBAVECLSE.SelectedIndex)
    End Sub
    Private Sub cboBAVEESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBAVEESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboBAVEESTA, Me.cboBAVEESTA.SelectedIndex)
    End Sub
    Private Sub cboBAVECORR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBAVECORR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CORREGIMIENTO_X_MUNICIPIO_Descripcion(Me.cboBAVECORR, Me.cboBAVECORR.SelectedIndex, Me.cboBAVEDEPA, Me.cboBAVEMUNI, Me.cboBAVECLSE)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboBAVEDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBAVEDEPA.SelectedIndexChanged
        Me.lblBAVEDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboBAVEDEPA), String)

        Me.cboBAVEMUNI.DataSource = New DataTable
        Me.lblBAVEMUNI.Text = ""

        Me.cboBAVECLSE.DataSource = New DataTable
        Me.lblBAVECLSE.Text = ""

        Me.cboBAVECORR.DataSource = New DataTable
        Me.lblBAVECORR.Text = ""

    End Sub
    Private Sub cboBAVEMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBAVEMUNI.SelectedIndexChanged
        Me.lblBAVEMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboBAVEDEPA, Me.cboBAVEMUNI), String)
    End Sub
    Private Sub cboBAVECLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBAVECLSE.SelectedIndexChanged
        Me.lblBAVECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboBAVECLSE), String)
    End Sub
    Private Sub cboBAVEcorr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBAVECORR.SelectedIndexChanged
        Me.lblBAVECORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO_Codigo(Me.cboBAVEDEPA, Me.cboBAVEMUNI, Me.cboBAVECLSE, Me.cboBAVECORR), String)
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