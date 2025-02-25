Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_ZOFIACTU

    '==========================================
    '*** INSERTAR ZONA FISICA ACTUALIZACION ***
    '==========================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(fraZOFIACTU)

        Me.lblZFACDEPA.Text = ""
        Me.lblZFACMUNI.Text = ""
        Me.lblZFACCLSE.Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_ZOFIACTU

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_ZOFIACTU(Me.cboZFACDEPA, _
                                                                                                Me.cboZFACMUNI, _
                                                                                                Me.cboZFACCLSE, _
                                                                                                Me.txtZFACCODI)
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boZFACDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboZFACDEPA)
            Dim boZFACMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboZFACMUNI)
            Dim boZFACCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboZFACCLSE)
            Dim boZFACCODI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtZFACCODI)
            Dim boZFACDESC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtZFACDESC)
            Dim boZFACESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboZFACESTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boZFACDEPA = True And _
               boZFACMUNI = True And _
               boZFACCLSE = True And _
               boZFACCODI = True And _
               boZFACDESC = True And _
               boZFACESTA = True Then

                Dim objdatos22 As New cla_ZOFIACTU

                If (objdatos22.fun_Insertar_MANT_ZOFIACTU(Me.cboZFACDEPA.SelectedValue, _
                                                          Me.cboZFACMUNI.SelectedValue, _
                                                          Me.cboZFACCLSE.SelectedValue, _
                                                          Me.txtZFACCODI.Text, _
                                                          Me.txtZFACDESC.Text, _
                                                          Me.cboZFACESTA.SelectedValue)) Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboZFACDEPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboZFACDEPA.Focus()
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
        Me.cboZFACDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_ZOFIACTU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboZFACDEPA.Focus()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboZFACDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZFACDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboZFACDEPA, Me.cboZFACDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboZFACMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZFACMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboZFACMUNI, Me.cboZFACMUNI.SelectedIndex, Me.cboZFACDEPA)
        End If
    End Sub
    Private Sub cboZFACCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZFACCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboZFACCLSE, Me.cboZFACCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboZFACESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboZFACESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboZFACESTA, Me.cboZFACESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboZFACDEPA.KeyPress, cboZFACMUNI.KeyPress, txtZFACCODI.KeyPress, txtZFACDESC.KeyPress, cboZFACESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtZFACCODI.GotFocus, txtZFACDESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZFACDEPA.GotFocus, cboZFACMUNI.GotFocus, cboZFACESTA.GotFocus, cboZFACCLSE.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Click"

    Private Sub cboZFACDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZFACDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboZFACDEPA, Me.cboZFACDEPA.SelectedIndex)
    End Sub
    Private Sub cboZFACMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZFACMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboZFACMUNI, Me.cboZFACMUNI.SelectedIndex, Me.cboZFACDEPA)
    End Sub
    Private Sub cboZFACCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZFACCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboZFACCLSE, Me.cboZFACCLSE.SelectedIndex)
    End Sub
    Private Sub cboZFACESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZFACESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(Me.cboZFACESTA, Me.cboZFACESTA.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboZFACDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZFACDEPA.SelectedIndexChanged
        Me.lblZFACDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboZFACDEPA), String)

        Me.cboZFACMUNI.DataSource = New DataTable
        Me.lblZFACMUNI.Text = ""

    End Sub
    Private Sub cboZFACMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZFACMUNI.SelectedIndexChanged
        Me.lblZFACMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboZFACDEPA, Me.cboZFACMUNI), String)
    End Sub
    Private Sub cboZFACCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZFACCLSE.SelectedIndexChanged
        Me.lblZFACCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboZFACCLSE), String)
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