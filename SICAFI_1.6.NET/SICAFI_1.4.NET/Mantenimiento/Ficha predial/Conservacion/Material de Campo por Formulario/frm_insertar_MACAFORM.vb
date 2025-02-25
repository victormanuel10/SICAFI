Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_MACAFORM

    '=================================================
    '*** INSERTAR MATERIAL DE CAMPO POR FORMULARIO ***
    '=================================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraMACAFORM)

        Me.lblMCFOFORM.Text = ""
        Me.lblMCFOMACA.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_MACAFORM

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_MACAFORM(Me.cboMCFOFORM, Me.cboMCFOMACA)

            Dim objVerifica As New cla_Verificar_Dato

            Dim boMCFOFORM As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMCFOFORM)
            Dim boMCFOMACA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMCFOMACA)
            Dim boMCFOESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMCFOESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And boMCFOFORM = True And boMCFOMACA = True And boMCFOESTA = True Then

                Dim objdatos22 As New cla_MACAFORM

                If (objdatos22.fun_Insertar_MANT_MACAFORM(Me.cboMCFOFORM.SelectedValue, _
                                                          Me.cboMCFOMACA.SelectedValue, _
                                                          Me.cboMCFOESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboMCFOFORM.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboMCFOFORM.Focus()
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
        Me.cboMCFOFORM.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_MACAFORM_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboMCFOFORM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMCFOFORM.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_FORMULARIO_Descripcion(Me.cboMCFOFORM, Me.cboMCFOFORM.SelectedIndex)
        End If
    End Sub
    Private Sub cboMCFOMACA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMCFOMACA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MATECAMP_Descripcion(Me.cboMCFOMACA, Me.cboMCFOMACA.SelectedIndex)
        End If
    End Sub
    Private Sub cboMCFOESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMCFOESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboMCFOESTA, Me.cboMCFOESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMCFOESTA.KeyPress, cboMCFOFORM.KeyPress, cboMCFOMACA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMCFOESTA.GotFocus, cboMCFOFORM.GotFocus, cboMCFOMACA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboMCFOFORM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMCFOFORM.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_FORMULARIO_Descripcion(Me.cboMCFOFORM, Me.cboMCFOFORM.SelectedIndex)
    End Sub
    Private Sub cboMCFOMACA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMCFOMACA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MATECAMP_Descripcion(Me.cboMCFOMACA, Me.cboMCFOMACA.SelectedIndex)
    End Sub
    Private Sub cboMOLIESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMCFOESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboMCFOESTA, cboMCFOESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboMCFOFORM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMCFOFORM.SelectedIndexChanged
        Me.lblMCFOFORM.Text = CType(fun_Buscar_Lista_Valores_FORMULARIO_Codigo(Me.cboMCFOFORM), String)
    End Sub
    Private Sub cboMCFOMACA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMCFOMACA.SelectedIndexChanged
        Me.lblMCFOMACA.Text = CType(fun_Buscar_Lista_Valores_MATECAMP_Codigo(Me.cboMCFOMACA), String)
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