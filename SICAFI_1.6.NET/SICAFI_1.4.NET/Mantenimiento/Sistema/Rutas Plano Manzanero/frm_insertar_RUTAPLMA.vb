Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_RUTAPLMA

    '=====================================
    '*** INSERTAR RUTA PLANO MANZANERO ***
    '=====================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtRUPMRUTA.Text = ""
        Me.lblRUPMCORR.Text = ""
        Me.lblRUPMDEPA.Text = ""
        Me.lblRUPMMUNI.Text = ""
        Me.lblRUPMBAVE.Text = ""
        Me.lblRUPMCLSE.Text = ""

        Me.cboRUPMCORR.DataSource = New DataTable
        Me.cboRUPMDEPA.DataSource = New DataTable
        Me.cboRUPMMUNI.DataSource = New DataTable
        Me.cboRUPMBAVE.DataSource = New DataTable
        Me.cboRUPMCLSE.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_RUTAPLMA

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_RUTAPLMA(Me.cboRUPMDEPA, Me.cboRUPMMUNI, Me.cboRUPMCLSE, Me.cboRUPMCORR, Me.cboRUPMBAVE)

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boOBINDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPMDEPA)
            Dim boOBINMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPMMUNI)
            Dim boOBINCORR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPMCORR)
            Dim boOBINBAVE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPMBAVE)
            Dim boOBINCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPMCLSE)
            Dim boOBINESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPMESTA)
            Dim boRUTARUTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRUPMRUTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boOBINDEPA = True And _
               boOBINMUNI = True And _
               boOBINCORR = True And _
               boOBINBAVE = True And _
               boOBINCLSE = True And _
               boOBINESTA = True And _
               boRUTARUTA = True Then

                Dim objdatos22 As New cla_RUTAPLMA

                If (objdatos22.fun_Insertar_MANT_RUTAPLMA(Me.cboRUPMDEPA.SelectedValue, _
                                                          Me.cboRUPMMUNI.SelectedValue, _
                                                          Me.cboRUPMCLSE.SelectedValue, _
                                                          Me.cboRUPMBAVE.SelectedValue, _
                                                          Me.txtRUPMRUTA.Text, _
                                                          Me.cboRUPMESTA.SelectedValue, _
                                                          Me.cboRUPMCORR.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboRUPMDEPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboRUPMDEPA.Focus()
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
        Me.cboRUPMDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_OBSEINMO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboRUPMDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRUPMDEPA.KeyPress, cboRUPMMUNI.KeyPress, cboRUPMCORR.KeyPress, cboRUPMBAVE.KeyPress, cboRUPMCLSE.KeyPress, txtRUPMRUTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboOBINDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUPMDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRUPMDEPA, Me.cboRUPMDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUPMMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRUPMMUNI, Me.cboRUPMMUNI.SelectedIndex, Me.cboRUPMDEPA)
        End If
    End Sub
    Private Sub cboOBINCORR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUPMCORR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CORREGIMIENTO_X_MUNICIPIO_Descripcion(Me.cboRUPMCORR, Me.cboRUPMCORR.SelectedIndex, Me.cboRUPMDEPA, Me.cboRUPMMUNI, Me.cboRUPMCLSE)
        End If
    End Sub
    Private Sub cboOBINBAVE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUPMBAVE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_BARRVERE_X_MUNICIPIO_Descripcion(Me.cboRUPMBAVE, Me.cboRUPMBAVE.SelectedIndex, Me.cboRUPMDEPA, Me.cboRUPMMUNI, Me.cboRUPMCLSE)
        End If
    End Sub
    Private Sub cboOBINCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUPMCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRUPMCLSE, Me.cboRUPMCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUPMESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRUPMESTA, Me.cboRUPMESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRUPMRUTA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPMDEPA.GotFocus, cboRUPMMUNI.GotFocus, cboRUPMCORR.GotFocus, cboRUPMBAVE.GotFocus, cboRUPMCLSE.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboOBINDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUPMDEPA.SelectedIndexChanged
        Me.lblRUPMDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboRUPMDEPA), String)

        Me.cboRUPMMUNI.DataSource = New DataTable
        Me.lblRUPMMUNI.Text = ""

        Me.cboRUPMCORR.DataSource = New DataTable
        Me.lblRUPMCORR.Text = ""

        Me.cboRUPMBAVE.DataSource = New DataTable
        Me.lblRUPMBAVE.Text = ""


    End Sub
    Private Sub cboOBINMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUPMMUNI.SelectedIndexChanged
        Me.lblRUPMMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboRUPMDEPA, Me.cboRUPMMUNI), String)

        Me.cboRUPMCORR.DataSource = New DataTable
        Me.lblRUPMCORR.Text = ""

        Me.cboRUPMBAVE.DataSource = New DataTable
        Me.lblRUPMBAVE.Text = ""

    End Sub
    Private Sub cboFPPRCORR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUPMCORR.SelectedIndexChanged
        Me.lblRUPMCORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO_Codigo(Me.cboRUPMDEPA, Me.cboRUPMMUNI, Me.cboRUPMCLSE, Me.cboRUPMCORR), String)

        Me.cboRUPMBAVE.DataSource = New DataTable
        Me.lblRUPMBAVE.Text = ""

    End Sub
    Private Sub cboOBINCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUPMCLSE.SelectedIndexChanged
        Me.lblRUPMCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRUPMCLSE), String)

        Me.cboRUPMBAVE.DataSource = New DataTable
        Me.lblRUPMBAVE.Text = ""

    End Sub
    Private Sub cboOBINBAVE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUPMBAVE.SelectedIndexChanged
        Me.lblRUPMBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRVERE_Codigo(Me.cboRUPMDEPA, Me.cboRUPMMUNI, Me.cboRUPMCLSE, Me.cboRUPMBAVE), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboOBINNODE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPMDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRUPMDEPA, Me.cboRUPMDEPA.SelectedIndex)
    End Sub
    Private Sub cboOBINMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPMMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRUPMMUNI, Me.cboRUPMMUNI.SelectedIndex, Me.cboRUPMDEPA)
    End Sub
    Private Sub cboOBINCORR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPMCORR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CORREGIMIENTO_X_MUNICIPIO_Descripcion(Me.cboRUPMCORR, Me.cboRUPMCORR.SelectedIndex, Me.cboRUPMDEPA, Me.cboRUPMMUNI, Me.cboRUPMCLSE)
    End Sub
    Private Sub cboOBINBAVE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPMBAVE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_BARRVERE_X_MUNICIPIO_Descripcion(Me.cboRUPMBAVE, Me.cboRUPMBAVE.SelectedIndex, Me.cboRUPMDEPA, Me.cboRUPMMUNI, Me.cboRUPMCLSE, Me.cboRUPMCORR)
    End Sub
    Private Sub cboOBINCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPMCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRUPMCLSE, Me.cboRUPMCLSE.SelectedIndex)
    End Sub
    Private Sub cboOBINESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPMESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRUPMESTA, Me.cboRUPMESTA.SelectedIndex)
    End Sub
    Private Sub cmdCARPETA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCARPETA.Click

        Dim oCarpetas As New FolderBrowserDialog
        Dim stNewPath As String = ""

        oCarpetas.ShowDialog()
        stNewPath = oCarpetas.SelectedPath

        Me.txtRUPMRUTA.Text = stNewPath

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