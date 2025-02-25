Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_RUTAPLCA

    '========================================
    '*** INSERTAR RUTA PLANO CARTOGRAFICO ***
    '========================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtRUPCRUTA.Text = ""
        Me.lblRUPCPLCA.Text = ""
        Me.lblRUPCDEPA.Text = ""
        Me.lblRUPCMUNI.Text = ""
        Me.lblRUPCCLSE.Text = ""

        Me.cboRUPCPLCA.DataSource = New DataTable
        Me.cboRUPCDEPA.DataSource = New DataTable
        Me.cboRUPCMUNI.DataSource = New DataTable
        Me.cboRUPCCLSE.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_RUTAPLCA

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_RUTAPLCA(Me.cboRUPCDEPA, Me.cboRUPCMUNI, Me.cboRUPCCLSE, Me.cboRUPCPLCA)

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boOBINDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPCDEPA)
            Dim boOBINMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPCMUNI)
            Dim boOBINCAFO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPCPLCA)
            Dim boOBINCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPCCLSE)
            Dim boOBINESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPCESTA)
            Dim boRUTARUTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRUPCRUTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boOBINDEPA = True And _
               boOBINMUNI = True And _
               boOBINCAFO = True And _
               boOBINCLSE = True And _
               boOBINESTA = True And _
               boRUTARUTA = True Then

                Dim objdatos22 As New cla_RUTAPLCA

                If (objdatos22.fun_Insertar_MANT_RUTAPLCA(Me.cboRUPCDEPA.SelectedValue, _
                                                          Me.cboRUPCMUNI.SelectedValue, _
                                                          Me.cboRUPCCLSE.SelectedValue, _
                                                          Me.cboRUPCPLCA.SelectedValue, _
                                                          Me.txtRUPCRUTA.Text, _
                                                          Me.cboRUPCESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboRUPCDEPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboRUPCDEPA.Focus()
                    End If

                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.cboRUPCDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_OBSEINMO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboRUPCDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRUPCDEPA.KeyPress, cboRUPCMUNI.KeyPress, cboRUPCPLCA.KeyPress, cboRUPCCLSE.KeyPress, txtRUPCRUTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboOBINDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUPCDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRUPCDEPA, Me.cboRUPCDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUPCMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRUPCMUNI, Me.cboRUPCMUNI.SelectedIndex, Me.cboRUPCDEPA)
        End If
    End Sub
    Private Sub cboRUCFCAFO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUPCPLCA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_PLANCART_Descripcion(Me.cboRUPCPLCA, Me.cboRUPCPLCA.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUPCCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRUPCCLSE, Me.cboRUPCCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUPCESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRUPCESTA, Me.cboRUPCESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRUPCRUTA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPCDEPA.GotFocus, cboRUPCMUNI.GotFocus, cboRUPCPLCA.GotFocus, cboRUPCCLSE.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboOBINDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUPCDEPA.SelectedIndexChanged
        Me.lblRUPCDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboRUPCDEPA), String)

        Me.cboRUPCMUNI.DataSource = New DataTable
        Me.lblRUPCMUNI.Text = ""

    End Sub
    Private Sub cboOBINMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUPCMUNI.SelectedIndexChanged
        Me.lblRUPCMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboRUPCDEPA, Me.cboRUPCMUNI), String)

    End Sub
    Private Sub cboRUCFCAFO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUPCPLCA.SelectedIndexChanged
        Me.lblRUPCPLCA.Text = CType(fun_Buscar_Lista_Valores_PLANCART_Codigo(Me.cboRUPCPLCA), String)

    End Sub
    Private Sub cboOBINCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUPCCLSE.SelectedIndexChanged
        Me.lblRUPCCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRUPCCLSE), String)

    End Sub

#End Region

#Region "Click"

    Private Sub cboOBINNODE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPCDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRUPCDEPA, Me.cboRUPCDEPA.SelectedIndex)
    End Sub
    Private Sub cboOBINMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPCMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRUPCMUNI, Me.cboRUPCMUNI.SelectedIndex, Me.cboRUPCDEPA)
    End Sub
    Private Sub cboRUCFCAFO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPCPLCA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_PLANCART_Descripcion(Me.cboRUPCPLCA, Me.cboRUPCPLCA.SelectedIndex)
    End Sub
    Private Sub cboOBINCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPCCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRUPCCLSE, Me.cboRUPCCLSE.SelectedIndex)
    End Sub
    Private Sub cboOBINESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPCESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRUPCESTA, Me.cboRUPCESTA.SelectedIndex)
    End Sub
    Private Sub cmdCARPETA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCARPETA.Click

        Dim oCarpetas As New FolderBrowserDialog
        Dim stNewPath As String = ""

        oCarpetas.ShowDialog()
        stNewPath = oCarpetas.SelectedPath

        Me.txtRUPCRUTA.Text = stNewPath

        Try
            '*** VERIFICA QUE LA RUTA ESTE CORRECTA ***
            ChDir(stNewPath)

        Catch ex As Exception When stNewPath = ""
            MessageBox.Show("Se debe introducir una ruta valida", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try

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