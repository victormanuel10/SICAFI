Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_PUNTREQU

    '===================================
    '*** MODIFICAR PUNTOS REQUERIDOS ***
    '===================================

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

            Dim objdatos3 As New cla_PUNTREQU
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_PUNTREQU(inID_REGISTRO)

            Dim objdatos1 As New cla_DEPARTAMENTO

            Me.cboPUREDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboPUREDEPA.DisplayMember = "DEPADESC"
            Me.cboPUREDEPA.ValueMember = "DEPACODI"

            Me.cboPUREDEPA.SelectedValue = tbl.Rows(0).Item("PUREDEPA")

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboPUREMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboPUREMUNI.DisplayMember = "MUNIDESC"
            Me.cboPUREMUNI.ValueMember = "MUNICODI"

            Me.cboPUREMUNI.SelectedValue = tbl.Rows(0).Item("PUREMUNI")

            Dim objdatos2 As New cla_CLASSECT

            Me.cboPURECLSE.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboPURECLSE.DisplayMember = "CLSEDESC"
            Me.cboPURECLSE.ValueMember = "CLSECODI"

            Me.cboPURECLSE.SelectedValue = tbl.Rows(0).Item("PURECLSE")
            Me.txtPUREPURE.Text = Trim(tbl.Rows(0).Item("PUREPURE"))

            Dim objdatos As New cla_ESTADO

            Me.cboPUREESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
            Me.cboPUREESTA.DisplayMember = "ESPURESC"
            Me.cboPUREESTA.ValueMember = "ESTACODI"

            Me.cboPUREESTA.SelectedValue = tbl.Rows(0).Item("PUREESTA")

            Dim boPUREDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboPUREDEPA.SelectedValue)
            Dim boPUREMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboPUREDEPA.SelectedValue, Me.cboPUREMUNI.SelectedValue)
            Dim boPURECLSE As Boolean = fun_Buscar_Dato_CLASSECT(Me.cboPURECLSE.SelectedValue)

            If boPUREDEPA = True OrElse boPUREMUNI = True OrElse boPURECLSE = True Then

                Me.lblPUREMUNI.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboPUREDEPA), String)
                Me.lblPUREDEPA.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboPUREDEPA, Me.cboPUREMUNI), String)
                Me.lblPURECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboPURECLSE), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtPUREPURE.Text = "0"
        Me.lblPUREDEPA.Text = ""
        Me.lblPUREMUNI.Text = ""
        Me.lblPURECLSE.Text = ""

        Me.strBARRESTA.Items(1).Text = ""

        Me.cboPUREDEPA.DataSource = New DataTable
        Me.cboPUREMUNI.DataSource = New DataTable
        Me.cboPURECLSE.DataSource = New DataTable
        Me.cboPUREESTA.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boPUREDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPUREDEPA)
            Dim boPUREMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPUREMUNI)
            Dim boPURECLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPURECLSE)
            Dim boPUREPURE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtPUREPURE)
            Dim boPUREESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPUREESTA)

            ' verifica los datos del formulario 
            If boPUREDEPA = True And _
               boPUREMUNI = True And _
               boPURECLSE = True And _
               boPUREPURE = True And _
               boPUREESTA = True Then

                Dim objdatos22 As New cla_PUNTREQU

                If (objdatos22.fun_Actualizar_PUNTREQU(inID_REGISTRO, _
                                                     Me.cboPUREDEPA.SelectedValue, _
                                                     Me.cboPUREMUNI.SelectedValue, _
                                                     Me.cboPURECLSE.SelectedValue, _
                                                     Me.txtPUREPURE.Text, _
                                                     Me.cboPUREESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.cboPUREDEPA.Focus()
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
        Me.cboPUREDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPUREDEPA.KeyPress, cboPUREMUNI.KeyPress, cboPURECLSE.KeyPress, txtPUREPURE.KeyPress, cboPUREESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboPUREDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPUREDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboPUREDEPA, Me.cboPUREDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboPUREMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPUREMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboPUREMUNI, Me.cboPUREMUNI.SelectedIndex, Me.cboPUREDEPA)
        End If
    End Sub
    Private Sub cboPURECLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPURECLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboPURECLSE, Me.cboPURECLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboPUREESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPUREESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPUREESTA, Me.cboPUREESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPUREPURE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPUREDEPA.GotFocus, cboPUREMUNI.GotFocus, cboPURECLSE.GotFocus, cboPUREESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboPUREDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPUREDEPA.SelectedIndexChanged
        Me.lblPUREDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboPUREDEPA), String)

        Me.cboPUREMUNI.DataSource = New DataTable
        Me.lblPUREMUNI.Text = ""

    End Sub
    Private Sub cboPUREMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPUREMUNI.SelectedIndexChanged
        Me.lblPUREMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboPUREDEPA, Me.cboPUREMUNI), String)
    End Sub
    Private Sub cboPURECLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPURECLSE.SelectedIndexChanged
        Me.lblPURECLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboPURECLSE), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboPUREDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPUREDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboPUREDEPA, Me.cboPUREDEPA.SelectedIndex)
    End Sub
    Private Sub cboPUREMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPUREMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboPUREMUNI, Me.cboPUREMUNI.SelectedIndex, Me.cboPUREDEPA)
    End Sub
    Private Sub cboPURECLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPURECLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboPURECLSE, Me.cboPURECLSE.SelectedIndex)
    End Sub
    Private Sub cboPUREESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPUREESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPUREESTA, Me.cboPUREESTA.SelectedIndex)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtPUREAVFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPUREPURE.Validated
        If Trim(sender.text) = "" Then
            sender.text = "1"
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