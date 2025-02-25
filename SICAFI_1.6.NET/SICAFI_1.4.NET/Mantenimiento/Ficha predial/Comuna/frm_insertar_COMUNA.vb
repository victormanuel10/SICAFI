Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_COMUNA

    '=======================
    '*** INSERTAR COMUNA ***
    '=======================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraCOMUNA)

        Me.lblCOMUDEPA.Text = ""
        Me.lblCOMUMUNI.Text = ""
        Me.lblCOMUCLSE.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_COMUNA

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_COMUNA(Me.cboCOMUDEPA, _
                                                                                         Me.cboCOMUMUNI, _
                                                                                         Me.cboCOMUCLSE, _
                                                                                         Me.txtCOMUCODI)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boCOMUDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOMUDEPA)
            Dim boCOMUMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOMUMUNI)
            Dim boCOMUCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOMUCLSE)
            Dim boCOMUCODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCOMUCODI)
            Dim boCOMUDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCOMUDESC)
            Dim boCOMUESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOMUESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boCOMUDEPA = True And _
               boCOMUMUNI = True And _
               boCOMUCLSE = True And _
               boCOMUCODI = True And _
               boCOMUDESC = True And _
               boCOMUESTA = True Then

                Dim objdatos22 As New cla_COMUNA

                If (objdatos22.fun_Insertar_COMUNA(Me.cboCOMUDEPA.SelectedValue, _
                                                   Me.cboCOMUMUNI.SelectedValue, _
                                                   Me.cboCOMUCLSE.SelectedValue, _
                                                   Me.txtCOMUCODI.Text, _
                                                   Me.txtCOMUDESC.Text, _
                                                   Me.cboCOMUESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboCOMUDEPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboCOMUDEPA.Focus()
                    End If

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

#Region "Load"

    Private Sub frm_COMUNA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboCOMUDEPA.Focus()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboCOMUDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOMUDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboCOMUDEPA, Me.cboCOMUDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboCOMUMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOMUMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboCOMUMUNI, Me.cboCOMUMUNI.SelectedIndex, Me.cboCOMUDEPA)
        End If
    End Sub
    Private Sub cboCOMUCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOMUCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboCOMUCLSE, Me.cboCOMUCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboCOMUESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOMUESTA.KeyDown
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

    Private Sub cboCOMUDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOMUDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboCOMUDEPA, Me.cboCOMUDEPA.SelectedIndex)
    End Sub
    Private Sub cboCOMUMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOMUMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboCOMUMUNI, Me.cboCOMUMUNI.SelectedIndex, Me.cboCOMUDEPA)
    End Sub
    Private Sub cboCOMUCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOMUCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboCOMUCLSE, Me.cboCOMUCLSE.SelectedIndex)
    End Sub
    Private Sub cboCOMUESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOMUESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboCOMUESTA, Me.cboCOMUESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboCOMUDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOMUDEPA.SelectedIndexChanged
        Me.lblCOMUDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboCOMUDEPA), String)

        Me.cboCOMUMUNI.DataSource = New DataTable
        Me.lblCOMUMUNI.Text = ""

    End Sub
    Private Sub cboCOMUMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOMUMUNI.SelectedIndexChanged
        Me.lblCOMUMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboCOMUDEPA, Me.cboCOMUMUNI), String)
    End Sub
    Private Sub cboCOMUCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOMUCLSE.SelectedIndexChanged
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