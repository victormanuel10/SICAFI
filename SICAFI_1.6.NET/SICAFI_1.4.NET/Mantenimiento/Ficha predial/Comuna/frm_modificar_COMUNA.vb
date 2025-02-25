Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_COMUNA

    '========================
    '*** MODIFICAR COMUNA ***
    '========================

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

            Me.cboCOMUDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboCOMUDEPA.DisplayMember = "DEPADESC"
            Me.cboCOMUDEPA.ValueMember = "DEPACODI"

            Dim objdatos2 As New cla_CLASSECT

            Me.cboCOMUCLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboCOMUCLSE.DisplayMember = "CLSEDESC"
            Me.cboCOMUCLSE.ValueMember = "CLSECODI"

            Dim objdatos As New cla_ESTADO

            Me.cboCOMUESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
            Me.cboCOMUESTA.DisplayMember = "ESTADESC"
            Me.cboCOMUESTA.ValueMember = "ESTACODI"

            Dim objdatos3 As New cla_COMUNA
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_COMUNA(inID_REGISTRO)

            Me.cboCOMUDEPA.SelectedValue = tbl.Rows(0).Item("COMUDEPA")

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboCOMUMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboCOMUMUNI.DisplayMember = "MUNIDESC"
            Me.cboCOMUMUNI.ValueMember = "MUNICODI"

            Me.cboCOMUMUNI.SelectedValue = tbl.Rows(0).Item("COMUMUNI")
            Me.cboCOMUCLSE.SelectedValue = tbl.Rows(0).Item("COMUCLSE")
            Me.txtCOMUCODI.Text = Trim(tbl.Rows(0).Item("COMUCODI"))
            Me.txtCOMUDESC.Text = Trim(tbl.Rows(0).Item("COMUDESC"))
            Me.cboCOMUESTA.SelectedValue = tbl.Rows(0).Item("COMUESTA")

            Dim boCORRDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboCOMUDEPA.SelectedValue)
            Dim boCORRMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboCOMUDEPA.SelectedValue, Me.cboCOMUMUNI.SelectedValue)
            Dim boCORRCLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboCOMUCLSE.SelectedValue)

            If boCORRDEPA = True OrElse boCORRMUNI = True OrElse boCORRCLSE = True Then

                Me.lblCOMUDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboCOMUDEPA), String)
                Me.lblCOMUMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboCOMUDEPA, Me.cboCOMUMUNI), String)
                Me.lblCOMUCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboCOMUCLSE), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraVIGEACTU)

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boCORRDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOMUDEPA)
            Dim boCORRMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOMUMUNI)
            Dim boCORRCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOMUCLSE)
            Dim boCORRCODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCOMUCODI)
            Dim boCORRDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCOMUDESC)
            Dim boCORRESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOMUESTA)

            ' verifica los datos del formulario 
            If boCORRDEPA = True And _
               boCORRMUNI = True And _
               boCORRCLSE = True And _
               boCORRCODI = True And _
               boCORRDESC = True And _
               boCORRESTA = True Then

                Dim objdatos22 As New cla_COMUNA

                If (objdatos22.fun_Actualizar_COMUNA(inID_REGISTRO, _
                                                         Me.cboCOMUDEPA.SelectedValue, _
                                                         Me.cboCOMUMUNI.SelectedValue, _
                                                         Me.cboCOMUCLSE.SelectedValue, _
                                                         Me.txtCOMUCODI.Text, _
                                                         Me.txtCOMUDESC.Text, _
                                                         Me.cboCOMUESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    Me.cboCOMUDEPA.Focus()
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
        Me.cboCOMUDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboCORRDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOMUDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboCOMUDEPA, Me.cboCOMUDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboCORRMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOMUMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboCOMUMUNI, Me.cboCOMUMUNI.SelectedIndex, Me.cboCOMUDEPA)
        End If
    End Sub
    Private Sub cboCORRCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOMUCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboCOMUCLSE, Me.cboCOMUCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboCORRESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOMUESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCOMUESTA, Me.cboCOMUESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCOMUDEPA.KeyPress, cboCOMUMUNI.KeyPress, cboCOMUCLSE.KeyPress, txtCOMUCODI.KeyPress, txtCOMUDESC.KeyPress, cboCOMUESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCOMUCODI.GotFocus, txtCOMUDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOMUDEPA.GotFocus, cboCOMUMUNI.GotFocus, cboCOMUCLSE.GotFocus, cboCOMUESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub rbd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboCORRDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOMUDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboCOMUDEPA, Me.cboCOMUDEPA.SelectedIndex)
    End Sub
    Private Sub cboCORRMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOMUMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboCOMUMUNI, Me.cboCOMUMUNI.SelectedIndex, Me.cboCOMUDEPA)
    End Sub
    Private Sub cboCORRCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOMUCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboCOMUCLSE, Me.cboCOMUCLSE.SelectedIndex)
    End Sub
    Private Sub cboCORRESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOMUESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCOMUESTA, Me.cboCOMUESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboCORRDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOMUDEPA.SelectedIndexChanged
        Me.lblCOMUDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboCOMUDEPA), String)

        Me.cboCOMUMUNI.DataSource = New DataTable
        Me.lblCOMUMUNI.Text = ""

    End Sub
    Private Sub cboCORRMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOMUMUNI.SelectedIndexChanged
        Me.lblCOMUMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboCOMUDEPA, Me.cboCOMUMUNI), String)
    End Sub
    Private Sub cboCORRCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOMUCLSE.SelectedIndexChanged
        Me.lblCOMUCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboCOMUCLSE), String)
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