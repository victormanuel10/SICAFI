Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_RUTAFPDI

    '============================================
    '*** MODIFICAR RUTA FICHA PREDIAL DIGITAL ***
    '============================================

#Region "VARIABLE"

    Dim inID_REGISTRO As Integer

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inInRegistro As Integer)
        inID_REGISTRO = inInRegistro

        InitializeComponent()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Try

            Dim objdatos8 As New cla_RUTAFPDI
            Dim tbl As New DataTable

            tbl = objdatos8.fun_Buscar_ID_MANT_RUTAFPDI(inID_REGISTRO)

            Dim objdatos11 As New cla_DEPARTAMENTO

            Me.cboRUFDDEPA.DataSource = objdatos11.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboRUFDDEPA.DisplayMember = "DEPADESC"
            Me.cboRUFDDEPA.ValueMember = "DEPACODI"

            Me.cboRUFDDEPA.SelectedValue = tbl.Rows(0).Item("RUFDDEPA")

            Dim objdatos12 As New cla_MUNICIPIO

            Me.cboRUFDMUNI.DataSource = objdatos12.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboRUFDMUNI.DisplayMember = "MUNIDESC"
            Me.cboRUFDMUNI.ValueMember = "MUNICODI"

            Me.cboRUFDMUNI.SelectedValue = tbl.Rows(0).Item("RUFDMUNI")

            Dim objdatos1 As New cla_CLASSECT

            Me.cboRUFDCLSE.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboRUFDCLSE.DisplayMember = "CLSEDESC"
            Me.cboRUFDCLSE.ValueMember = "CLSECODI"

            Me.cboRUFDCLSE.SelectedValue = tbl.Rows(0).Item("RUFDCLSE")

            Dim objdatos18 As New cla_FIPRDIGI

            Me.cboRUFDFPDI.DataSource = objdatos18.fun_Consultar_CAMPOS_MANT_FIPRDIGI
            Me.cboRUFDFPDI.DisplayMember = "FPDIDESC"
            Me.cboRUFDFPDI.ValueMember = "FPDICODI"

            Me.cboRUFDFPDI.SelectedValue = tbl.Rows(0).Item("RUFDFPDI")

            Me.txtRUFDRUTA.Text = Trim(tbl.Rows(0).Item("RUFDRUTA"))

            Dim objdatos16 As New cla_ESTADO

            Me.cboRUFDESTA.DataSource = objdatos16.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboRUFDESTA.DisplayMember = "ESTADESC"
            Me.cboRUFDESTA.ValueMember = "ESTACODI"

            Me.cboRUFDESTA.SelectedValue = tbl.Rows(0).Item("RUFDESTA")

            ' Lista de valores
            Me.lblRUFDDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboRUFDDEPA), String)
            Me.lblRUFDMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboRUFDDEPA, Me.cboRUFDMUNI), String)
            Me.lblRUFDCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRUFDCLSE), String)
            Me.lblRUFDFPDI.Text = CType(fun_Buscar_Lista_Valores_FIPRDIGI_Codigo(Me.cboRUFDFPDI), String)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub
    Private Sub pro_LimpiarCampos()

        pp_pro_LimpiarCampos(GroupBox1)

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boFOTCDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUFDDEPA)
            Dim boFOTCMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUFDMUNI)
            Dim boFOTCCAFO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUFDFPDI)
            Dim boFOTCCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUFDCLSE)
            Dim boFOTCESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUFDESTA)
            Dim boRUTARUTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRUFDRUTA)

            ' verifica los datos del formulario 
            If boFOTCDEPA = True And _
               boFOTCMUNI = True And _
               boFOTCCAFO = True And _
               boFOTCCLSE = True And _
               boFOTCESTA = True And _
               boRUTARUTA = True Then

                Dim objdatos22 As New cla_RUTAFPDI

                If (objdatos22.fun_Actualizar_MANT_RUTAFPDI(inID_REGISTRO, _
                                                            Me.cboRUFDDEPA.SelectedValue, _
                                                            Me.cboRUFDMUNI.SelectedValue, _
                                                            Me.cboRUFDCLSE.SelectedValue, _
                                                            Me.cboRUFDFPDI.SelectedValue, _
                                                            Me.txtRUFDRUTA.Text, _
                                                            Me.cboRUFDESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    Me.cboRUFDDEPA.Focus()
                    Me.Close()

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

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRUFDDEPA.KeyPress, cboRUFDMUNI.KeyPress, cboRUFDFPDI.KeyPress, cboRUFDCLSE.KeyPress, txtRUFDRUTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboFOTCDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUFDDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRUFDDEPA, Me.cboRUFDDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOTCMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUFDMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRUFDMUNI, Me.cboRUFDMUNI.SelectedIndex, Me.cboRUFDDEPA)
        End If
    End Sub
    Private Sub cboRUFDCAFO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUFDFPDI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_FIPRDIGI_Descripcion(Me.cboRUFDFPDI, Me.cboRUFDFPDI.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOTCCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUFDCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRUFDCLSE, Me.cboRUFDCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOTCESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUFDESTA.KeyDown
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

    Private Sub cboFOTCDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUFDDEPA.SelectedIndexChanged
        Me.lblRUFDDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboRUFDDEPA), String)

        Me.cboRUFDMUNI.DataSource = New DataTable
        Me.lblRUFDMUNI.Text = ""

    End Sub
    Private Sub cboFOTCMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUFDMUNI.SelectedIndexChanged
        Me.lblRUFDMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboRUFDDEPA, Me.cboRUFDMUNI), String)

    End Sub
    Private Sub cboRUFDCAFO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUFDFPDI.SelectedIndexChanged
        Me.lblRUFDFPDI.Text = CType(fun_Buscar_Lista_Valores_FIPRDIGI_Codigo(Me.cboRUFDFPDI), String)

    End Sub
    Private Sub cboFOTCCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUFDCLSE.SelectedIndexChanged
        Me.lblRUFDCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRUFDCLSE), String)

    End Sub

#End Region

#Region "Click"

    Private Sub cboFOTCNODE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUFDDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRUFDDEPA, Me.cboRUFDDEPA.SelectedIndex)
    End Sub
    Private Sub cboFOTCMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUFDMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRUFDMUNI, Me.cboRUFDMUNI.SelectedIndex, Me.cboRUFDDEPA)
    End Sub
    Private Sub cboRUFDCAFO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUFDFPDI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_FIPRDIGI_Descripcion(Me.cboRUFDFPDI, Me.cboRUFDFPDI.SelectedIndex)
    End Sub
    Private Sub cboFOTCCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUFDCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRUFDCLSE, Me.cboRUFDCLSE.SelectedIndex)
    End Sub
    Private Sub cboFOTCESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUFDESTA.Click
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