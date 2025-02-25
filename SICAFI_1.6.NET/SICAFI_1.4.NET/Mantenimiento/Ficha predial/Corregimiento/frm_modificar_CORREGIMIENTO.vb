Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_CORREGIMIENTO

    '===============================
    '*** MODIFICAR CORREGIMIENTO ***
    '===============================

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

            Me.cboCORRDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboCORRDEPA.DisplayMember = "DEPADESC"
            Me.cboCORRDEPA.ValueMember = "DEPACODI"

            Dim objdatos2 As New cla_CLASSECT

            Me.cboCORRCLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboCORRCLSE.DisplayMember = "CLSEDESC"
            Me.cboCORRCLSE.ValueMember = "CLSECODI"

            Dim objdatos As New cla_ESTADO

            Me.cboCORRESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
            Me.cboCORRESTA.DisplayMember = "ESTADESC"
            Me.cboCORRESTA.ValueMember = "ESTACODI"

            Dim objdatos3 As New cla_CORREGIMIENTO
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_CORREGIMIENTO(inID_REGISTRO)

            Me.cboCORRDEPA.SelectedValue = tbl.Rows(0).Item("CORRDEPA")

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboCORRMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboCORRMUNI.DisplayMember = "MUNIDESC"
            Me.cboCORRMUNI.ValueMember = "MUNICODI"

            Me.cboCORRMUNI.SelectedValue = tbl.Rows(0).Item("CORRMUNI")
            Me.cboCORRCLSE.SelectedValue = tbl.Rows(0).Item("CORRCLSE")
            Me.txtCORRCODI.Text = Trim(tbl.Rows(0).Item("CORRCODI"))
            Me.txtCORRDESC.Text = Trim(tbl.Rows(0).Item("CORRDESC"))
            Me.cboCORRESTA.SelectedValue = tbl.Rows(0).Item("CORRESTA")

            Dim boCORRDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboCORRDEPA.SelectedValue)
            Dim boCORRMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboCORRDEPA.SelectedValue, Me.cboCORRMUNI.SelectedValue)
            Dim boCORRCLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboCORRCLSE.SelectedValue)

            If boCORRDEPA = True OrElse boCORRMUNI = True OrElse boCORRCLSE = True Then

                Me.lblCORRDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboCORRDEPA), String)
                Me.lblCORRMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboCORRDEPA, Me.cboCORRMUNI), String)
                Me.lblCORRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboCORRCLSE), String)

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

            Dim boCORRDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCORRDEPA)
            Dim boCORRMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCORRMUNI)
            Dim boCORRCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCORRCLSE)
            Dim boCORRCODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCORRCODI)
            Dim boCORRDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCORRDESC)
            Dim boCORRESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCORRESTA)

            ' verifica los datos del formulario 
            If boCORRDEPA = True And _
               boCORRMUNI = True And _
               boCORRCLSE = True And _
               boCORRCODI = True And _
               boCORRDESC = True And _
               boCORRESTA = True Then

                Dim objdatos22 As New cla_CORREGIMIENTO

                If (objdatos22.fun_Actualizar_CORREGIMIENTO(inID_REGISTRO, _
                                                         Me.cboCORRDEPA.SelectedValue, _
                                                         Me.cboCORRMUNI.SelectedValue, _
                                                         Me.cboCORRCLSE.SelectedValue, _
                                                         Me.txtCORRCODI.Text, _
                                                         Me.txtCORRDESC.Text, _
                                                         Me.cboCORRESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    Me.cboCORRDEPA.Focus()
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
        Me.cboCORRDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboCORRDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCORRDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboCORRDEPA, Me.cboCORRDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboCORRMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCORRMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboCORRMUNI, Me.cboCORRMUNI.SelectedIndex, Me.cboCORRDEPA)
        End If
    End Sub
    Private Sub cboCORRCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCORRCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboCORRCLSE, Me.cboCORRCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboCORRESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCORRESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCORRESTA, Me.cboCORRESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCORRDEPA.KeyPress, cboCORRMUNI.KeyPress, cboCORRCLSE.KeyPress, txtCORRCODI.KeyPress, txtCORRDESC.KeyPress, cboCORRESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCORRCODI.GotFocus, txtCORRDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCORRDEPA.GotFocus, cboCORRMUNI.GotFocus, cboCORRCLSE.GotFocus, cboCORRESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub rbd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboCORRDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCORRDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboCORRDEPA, Me.cboCORRDEPA.SelectedIndex)
    End Sub
    Private Sub cboCORRMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCORRMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboCORRMUNI, Me.cboCORRMUNI.SelectedIndex, Me.cboCORRDEPA)
    End Sub
    Private Sub cboCORRCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCORRCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboCORRCLSE, Me.cboCORRCLSE.SelectedIndex)
    End Sub
    Private Sub cboCORRESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCORRESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCORRESTA, Me.cboCORRESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboCORRDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCORRDEPA.SelectedIndexChanged
        Me.lblCORRDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboCORRDEPA), String)

        Me.cboCORRMUNI.DataSource = New DataTable
        Me.lblCORRMUNI.Text = ""

    End Sub
    Private Sub cboCORRMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCORRMUNI.SelectedIndexChanged
        Me.lblCORRMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboCORRDEPA, Me.cboCORRMUNI), String)
    End Sub
    Private Sub cboCORRCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCORRCLSE.SelectedIndexChanged
        Me.lblCORRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboCORRCLSE), String)
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