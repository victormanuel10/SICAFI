Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_PERMCOCO

    '============================================
    '*** INSERTAR PERMISO CONTROL DE COMANDOS ***
    '============================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraPERMCOCO)

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_PERMCOCO
            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_PERMCOCO(Me.cboPECCUSUA, _
                                                                                           Me.cboPECCFORM, _
                                                                                           Me.cboPECCCOCO)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boPECCUSUA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPECCUSUA)
            Dim boPECCFORM As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPECCFORM)
            Dim boPECCCOCO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPECCCOCO)
            Dim boPECCESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboPECCESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boPECCUSUA = True And _
               boPECCFORM = True And _
               boPECCESTA = True Then

                Dim objdatos22 As New cla_PERMCOCO

                If (objdatos22.fun_Insertar_PERMCOCO(Me.cboPECCUSUA.SelectedValue, _
                                                     Me.cboPECCFORM.SelectedValue, _
                                                     Me.cboPECCCOCO.SelectedValue, _
                                                     Me.rbdPECCHABI.Checked, _
                                                     Me.rbdPECCDESH.Checked, _
                                                     Me.cboPECCESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboPECCUSUA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboPECCUSUA.Focus()
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
        Me.cboPECCUSUA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_ZONAECON_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboPECCUSUA.Focus()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboPECCUSUA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPECCUSUA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CONTRASENA_Descripcion(Me.cboPECCUSUA, Me.cboPECCUSUA.SelectedIndex)
        End If
    End Sub
    Private Sub cboPECCFORM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPECCFORM.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_PERMISO_FORMULARIO_Descripcion(Me.cboPECCFORM, Me.cboPECCFORM.SelectedIndex)
        End If
    End Sub
    Private Sub cbocboPECCCOCO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPECCCOCO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CONTCOMA_Descripcion(Me.cboPECCCOCO, Me.cboPECCCOCO.SelectedIndex)
        End If
    End Sub
    Private Sub cboPECCESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPECCESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPECCESTA, Me.cboPECCESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboPECCUSUA.KeyPress, cboPECCFORM.KeyPress, cboPECCCOCO.KeyPress, cboPECCESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPECCUSUA.GotFocus, cboPECCFORM.GotFocus, cboPECCCOCO.GotFocus, cboPECCESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub rbd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbdPECCHABI.GotFocus, rbdPECCDESH.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboPECCUSUA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPECCUSUA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CONTRASENA_Descripcion(Me.cboPECCUSUA, Me.cboPECCUSUA.SelectedIndex)
    End Sub
    Private Sub cboPECCFORM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPECCFORM.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_PERMISO_FORMULARIO_Descripcion(Me.cboPECCFORM, Me.cboPECCFORM.SelectedIndex)
    End Sub
    Private Sub cboPECCCOCO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPECCCOCO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CONTCOMA_Descripcion(Me.cboPECCCOCO, Me.cboPECCCOCO.SelectedIndex)
    End Sub
    Private Sub cboPECCESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPECCESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboPECCESTA, Me.cboPECCESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboPECCUSUA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPECCUSUA.SelectedIndexChanged
        Me.lblPECCUSUA.Text = CType(fun_BuscarNombrePorUsuario(Trim(Me.cboPECCUSUA.Text)), String)
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