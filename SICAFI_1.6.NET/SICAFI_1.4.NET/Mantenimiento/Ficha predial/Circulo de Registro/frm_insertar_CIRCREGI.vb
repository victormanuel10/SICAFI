Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_CIRCREGI

    '====================================
    '*** INSERTAR CIRCULO DE REGISTRO ***
    '====================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraCIRCREGI)

        Me.lblCIREDEPA.Text = ""
        Me.lblCIREMUNI.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_CIRCREGI

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_CIRCREGI(Me.cboCIREDEPA, _
                                                                                           Me.cboCIREMUNI)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boCIREDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCIREDEPA)
            Dim boCIREMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCIREMUNI)
            Dim boCIRECIRE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCIRECIRE)
            Dim boCIREDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCIREDESC)
            Dim boCIREESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCIREESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boCIREDEPA = True And _
               boCIREMUNI = True And _
               boCIRECIRE = True And _
               boCIREDESC = True And _
               boCIREESTA = True Then

                ' asigna el formato del campo
                Me.txtCIRECIRE.Text = fun_Formato_Mascara_3_Reales(Me.txtCIRECIRE.Text)

                Dim objdatos22 As New cla_CIRCREGI

                If (objdatos22.fun_Insertar_MANT_CIRCREGI(Me.cboCIREDEPA.SelectedValue, _
                                                         Me.cboCIREMUNI.SelectedValue, _
                                                         Me.txtCIRECIRE.Text, _
                                                         Me.txtCIREDESC.Text, _
                                                         Me.cboCIREESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboCIREDEPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboCIREDEPA.Focus()
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
        Me.cboCIREDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_CIRCREGI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboCIREDEPA.Focus()
    End Sub

#End Region

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