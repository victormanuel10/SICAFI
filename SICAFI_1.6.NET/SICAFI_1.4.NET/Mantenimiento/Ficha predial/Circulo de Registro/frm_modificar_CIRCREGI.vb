Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_CIRCREGI

    '=====================================
    '*** MODIFICAR CIRCULO DE REGISTRO ***
    '=====================================

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
           
            Dim objdatos3 As New cla_CIRCREGI
            Dim tbl As New DataTable

            tbl = objdatos3.fun_Buscar_ID_MANT_CIRCREGI(inID_REGISTRO)

            Dim objdatos1 As New cla_DEPARTAMENTO

            Me.cboCIREDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboCIREDEPA.DisplayMember = "DEPADESC"
            Me.cboCIREDEPA.ValueMember = "DEPACODI"

            Me.cboCIREDEPA.SelectedValue = tbl.Rows(0).Item("CIREDEPA")

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboCIREMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboCIREMUNI.DisplayMember = "MUNIDESC"
            Me.cboCIREMUNI.ValueMember = "MUNICODI"
            Me.cboCIREMUNI.SelectedValue = tbl.Rows(0).Item("CIREMUNI")
            Me.txtCIRECIRE.Text = Trim(tbl.Rows(0).Item("CIRECIRE"))
            Me.txtCIREDESC.Text = Trim(tbl.Rows(0).Item("CIREDESC"))

            Dim objdatos As New cla_ESTADO

            Me.cboCIREESTA.DataSource = objdatos.fun_Consultar_ESTADO_X_ESTADO
            Me.cboCIREESTA.DisplayMember = "ESTADESC"
            Me.cboCIREESTA.ValueMember = "ESTACODI"

            Me.cboCIREESTA.SelectedValue = tbl.Rows(0).Item("CIREESTA")

            Dim boCIREDEPA As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.cboCIREDEPA.SelectedValue)
            Dim boCIREMUNI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.cboCIREDEPA.SelectedValue, Me.cboCIREMUNI.SelectedValue)
           
            If boCIREDEPA = True OrElse boCIREMUNI = True Then

                Me.lblCIREDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboCIREDEPA), String)
                Me.lblCIREMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboCIREDEPA, Me.cboCIREMUNI), String)
              
            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraCIRCREGI)

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boCIREDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCIREDEPA)
            Dim boCIREMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCIREMUNI)
            Dim boCIRECIRE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCIRECIRE)
            Dim boCIREDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCIREDESC)
            Dim boCIREESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCIREESTA)

            ' verifica los datos del formulario 
            If boCIREDEPA = True And _
               boCIREMUNI = True And _
               boCIRECIRE = True And _
               boCIREDESC = True And _
               boCIREESTA = True Then

                ' asigna el formato del campo
                Me.txtCIRECIRE.Text = fun_Formato_Mascara_3_Reales(Me.txtCIRECIRE.Text)

                Dim objdatos22 As New cla_CIRCREGI

                If (objdatos22.fun_Actualizar_MANT_CIRCREGI(inID_REGISTRO, _
                                                         Me.cboCIREDEPA.SelectedValue, _
                                                         Me.cboCIREMUNI.SelectedValue, _
                                                         Me.txtCIRECIRE.Text, _
                                                         Me.txtCIREDESC.Text, _
                                                         Me.cboCIREESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                    Me.cboCIREDEPA.Focus()
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
        Me.cboCIREDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyDown"

    Private Sub cboCIREDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCIREDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboCIREDEPA, Me.cboCIREDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboCIREMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCIREMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboCIREMUNI, Me.cboCIREMUNI.SelectedIndex, Me.cboCIREDEPA)
        End If
    End Sub
    Private Sub cboCIREESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCIREESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCIREESTA, Me.cboCIREESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCIREDEPA.KeyPress, cboCIREMUNI.KeyPress, txtCIRECIRE.KeyPress, txtCIREDESC.KeyPress, cboCIREESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCIRECIRE.GotFocus, txtCIREDESC.GotFocus, txtCIRECIRE.GotFocus, txtCIREDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCIREDEPA.GotFocus, cboCIREMUNI.GotFocus, cboCIREESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub rbd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboCIREDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCIREDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboCIREDEPA, Me.cboCIREDEPA.SelectedIndex)
    End Sub
    Private Sub cboCIREMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCIREMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboCIREMUNI, Me.cboCIREMUNI.SelectedIndex, Me.cboCIREDEPA)
    End Sub
    Private Sub cboCIREESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCIREESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCIREESTA, Me.cboCIREESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboCIREDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCIREDEPA.SelectedIndexChanged
        Me.lblCIREDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboCIREDEPA), String)

        Me.cboCIREMUNI.DataSource = New DataTable
        Me.lblCIREMUNI.Text = ""

    End Sub
    Private Sub cboCIREMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCIREMUNI.SelectedIndexChanged
        Me.lblCIREMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboCIREDEPA, Me.cboCIREMUNI), String)
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