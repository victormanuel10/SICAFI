Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_DOCUGENE

    '=====================================
    '*** INSERTAR DOCUMENTOS GENERALES ***
    '=====================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraDOCUGENE)

        Me.lblDOGEDEPA.Text = ""
        Me.lblDOGEMUNI.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_DOCUGENE

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_DOCUGENE(Me.cboDOGEDEPA, _
                                                                                                Me.cboDOGEMUNI, _
                                                                                                Me.txtDOGECODI)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boCORRDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboDOGEDEPA)
            Dim boCORRMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboDOGEMUNI)
            Dim boCORRCODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtDOGECODI)
            Dim boCORRDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtDOGEDESC)
            Dim boCORRESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboDOGEESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boCORRDEPA = True And _
               boCORRMUNI = True And _
               boCORRCODI = True And _
               boCORRDESC = True And _
               boCORRESTA = True Then

                Dim objdatos22 As New cla_DOCUGENE

                If (objdatos22.fun_Insertar_MANT_DOCUGENE(Me.cboDOGEDEPA.SelectedValue, _
                                                          Me.cboDOGEMUNI.SelectedValue, _
                                                          Me.txtDOGECODI.Text, _
                                                          Me.txtDOGEDESC.Text, _
                                                          Me.cboDOGEESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboDOGEDEPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboDOGEDEPA.Focus()
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
        Me.cboDOGEDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_VIGEACTU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboDOGEDEPA.Focus()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboCORRDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDOGEDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboDOGEDEPA, Me.cboDOGEDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboCORRMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDOGEMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboDOGEMUNI, Me.cboDOGEMUNI.SelectedIndex, Me.cboDOGEDEPA)
        End If
    End Sub
    Private Sub cboCORRESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDOGEESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboDOGEESTA, Me.cboDOGEESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboDOGEDEPA.KeyPress, cboDOGEMUNI.KeyPress, txtDOGECODI.KeyPress, txtDOGEDESC.KeyPress, cboDOGEESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDOGECODI.GotFocus, txtDOGEDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDOGEDEPA.GotFocus, cboDOGEMUNI.GotFocus, cboDOGEESTA.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub rbd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboCORRDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDOGEDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboDOGEDEPA, Me.cboDOGEDEPA.SelectedIndex)
    End Sub
    Private Sub cboCORRMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDOGEMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboDOGEMUNI, Me.cboDOGEMUNI.SelectedIndex, Me.cboDOGEDEPA)
    End Sub
    Private Sub cboCORRESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDOGEESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboDOGEESTA, Me.cboDOGEESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboCORRDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDOGEDEPA.SelectedIndexChanged
        Me.lblDOGEDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboDOGEDEPA), String)

        Me.cboDOGEMUNI.DataSource = New DataTable
        Me.lblDOGEMUNI.Text = ""

    End Sub
    Private Sub cboCORRMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDOGEMUNI.SelectedIndexChanged
        Me.lblDOGEMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboDOGEDEPA, Me.cboDOGEMUNI), String)
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