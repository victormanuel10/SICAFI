Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_RUTAFPDI

    '===========================================
    '*** INSERTAR RUTA FICHA PREDIAL DIGITAL ***
    '===========================================

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtRUFDRUTA.Text = ""
        Me.lblRUFDPLCA.Text = ""
        Me.lblRUFDDEPA.Text = ""
        Me.lblRUFDMUNI.Text = ""
        Me.lblRUFDCLSE.Text = ""

        Me.cboRUFDFPDI.DataSource = New DataTable
        Me.cboRUFDDEPA.DataSource = New DataTable
        Me.cboRUFDMUNI.DataSource = New DataTable
        Me.cboRUFDCLSE.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' instancia la clase
            Dim objdatos As New cla_RUTAFPDI

            Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MANT_RUTAFPDI(Me.cboRUFDDEPA, Me.cboRUFDMUNI, Me.cboRUFDCLSE, Me.cboRUFDFPDI)

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boOBINDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUFDDEPA)
            Dim boOBINMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUFDMUNI)
            Dim boOBINCAFO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUFDFPDI)
            Dim boOBINCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUFDCLSE)
            Dim boOBINESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUFDESTA)
            Dim boRUTARUTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRUFDRUTA)

            ' verifica los datos del formulario 
            If boLLAVEPRIMARIA = True And _
               boOBINDEPA = True And _
               boOBINMUNI = True And _
               boOBINCAFO = True And _
               boOBINCLSE = True And _
               boOBINESTA = True And _
               boRUTARUTA = True Then

                Dim objdatos22 As New cla_RUTAFPDI

                If (objdatos22.fun_Insertar_MANT_RUTAFPDI(Me.cboRUFDDEPA.SelectedValue, _
                                                          Me.cboRUFDMUNI.SelectedValue, _
                                                          Me.cboRUFDCLSE.SelectedValue, _
                                                          Me.cboRUFDFPDI.SelectedValue, _
                                                          Me.txtRUFDRUTA.Text, _
                                                          Me.cboRUFDESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                        Me.cboRUFDDEPA.Focus()
                        Me.Close()
                    Else
                        pro_LimpiarCampos()
                        Me.cboRUFDDEPA.Focus()
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
        Me.cboRUFDDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_OBSEINMO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.cboRUFDDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRUFDDEPA.KeyPress, cboRUFDMUNI.KeyPress, cboRUFDFPDI.KeyPress, cboRUFDCLSE.KeyPress, txtRUFDRUTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboOBINDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUFDDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRUFDDEPA, Me.cboRUFDDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUFDMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRUFDMUNI, Me.cboRUFDMUNI.SelectedIndex, Me.cboRUFDDEPA)
        End If
    End Sub
    Private Sub cboRUCFCAFO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUFDFPDI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_FIPRDIGI_Descripcion(Me.cboRUFDFPDI, Me.cboRUFDFPDI.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUFDCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRUFDCLSE, Me.cboRUFDCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUFDESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRUFDESTA, Me.cboRUFDESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRUFDRUTA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUFDDEPA.GotFocus, cboRUFDMUNI.GotFocus, cboRUFDFPDI.GotFocus, cboRUFDCLSE.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboOBINDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUFDDEPA.SelectedIndexChanged
        Me.lblRUFDDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboRUFDDEPA), String)

        Me.cboRUFDMUNI.DataSource = New DataTable
        Me.lblRUFDMUNI.Text = ""

    End Sub
    Private Sub cboOBINMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUFDMUNI.SelectedIndexChanged
        Me.lblRUFDMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboRUFDDEPA, Me.cboRUFDMUNI), String)

    End Sub
    Private Sub cboRUCFCAFO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUFDFPDI.SelectedIndexChanged
        Me.lblRUFDPLCA.Text = CType(fun_Buscar_Lista_Valores_FIPRDIGI_Codigo(Me.cboRUFDFPDI), String)

    End Sub
    Private Sub cboOBINCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUFDCLSE.SelectedIndexChanged
        Me.lblRUFDCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRUFDCLSE), String)

    End Sub

#End Region

#Region "Click"

    Private Sub cboOBINNODE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUFDDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRUFDDEPA, Me.cboRUFDDEPA.SelectedIndex)
    End Sub
    Private Sub cboOBINMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUFDMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRUFDMUNI, Me.cboRUFDMUNI.SelectedIndex, Me.cboRUFDDEPA)
    End Sub
    Private Sub cboRUCFCAFO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUFDFPDI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_FIPRDIGI_Descripcion(Me.cboRUFDFPDI, Me.cboRUFDFPDI.SelectedIndex)
    End Sub
    Private Sub cboOBINCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUFDCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRUFDCLSE, Me.cboRUFDCLSE.SelectedIndex)
    End Sub
    Private Sub cboOBINESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUFDESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRUFDESTA, Me.cboRUFDESTA.SelectedIndex)
    End Sub
    Private Sub cmdCARPETA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCARPETA.Click

        Try
            ' seleccion carpeta
            If Me.rbdFPDICARP.Checked = True Then

                Dim oCarpetas As New FolderBrowserDialog
                Dim stNewPath As String = ""

                oCarpetas.ShowDialog()
                stNewPath = oCarpetas.SelectedPath

                Me.txtRUFDRUTA.Text = stNewPath

                'ChDir(stNewPath)

                ' seleccion archivo
            ElseIf Me.rbdFPDIARCH.Checked = True Then

                Dim oLeer As New OpenFileDialog

                ' enruta el archivo
                oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
                oLeer.Filter = "Todos los archivos (*.*)|*.*" 'Colocar varias extensiones
                oLeer.FilterIndex = 1 'coloca por defecto el primero
                oLeer.FileName = ""
                oLeer.ShowDialog()

                Dim stRutaArchivo As String = Trim(oLeer.FileName)

                ' selecciona ficha predial
                If Trim(stRutaArchivo) <> "" Then

                    Me.txtRUFDRUTA.Text = stRutaArchivo

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
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