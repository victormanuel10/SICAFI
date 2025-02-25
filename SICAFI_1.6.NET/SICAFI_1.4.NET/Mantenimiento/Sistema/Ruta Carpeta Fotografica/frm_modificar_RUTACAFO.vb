Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_RUTACAFO

    '==========================================
    '*** MODIFICAR RUTA CARPETA FOTOGRAFICA ***
    '==========================================

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

            Dim objdatos8 As New cla_RUTACAFO
            Dim tbl As New DataTable

            tbl = objdatos8.fun_Buscar_ID_MANT_RUTACAFO(inID_REGISTRO)

            Dim objdatos11 As New cla_DEPARTAMENTO

            Me.cboRUCFDEPA.DataSource = objdatos11.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboRUCFDEPA.DisplayMember = "DEPADESC"
            Me.cboRUCFDEPA.ValueMember = "DEPACODI"

            Me.cboRUCFDEPA.SelectedValue = tbl.Rows(0).Item("RUCFDEPA")

            Dim objdatos12 As New cla_MUNICIPIO

            Me.cboRUCFMUNI.DataSource = objdatos12.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboRUCFMUNI.DisplayMember = "MUNIDESC"
            Me.cboRUCFMUNI.ValueMember = "MUNICODI"

            Me.cboRUCFMUNI.SelectedValue = tbl.Rows(0).Item("RUCFMUNI")

            Dim objdatos1 As New cla_CLASSECT

            Me.cboRUCFCLSE.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboRUCFCLSE.DisplayMember = "CLSEDESC"
            Me.cboRUCFCLSE.ValueMember = "CLSECODI"

            Me.cboRUCFCLSE.SelectedValue = tbl.Rows(0).Item("RUCFCLSE")

            Dim objdatos18 As New cla_CARPFOTO

            Me.cboRUCFCAFO.DataSource = objdatos18.fun_Consultar_CAMPOS_MANT_CARPFOTO
            Me.cboRUCFCAFO.DisplayMember = "CAFODESC"
            Me.cboRUCFCAFO.ValueMember = "CAFOCODI"

            Me.cboRUCFCAFO.SelectedValue = tbl.Rows(0).Item("RUCFCAFO")

            Me.txtRUCFRUTA.Text = Trim(tbl.Rows(0).Item("RUCFRUTA"))

            Dim objdatos16 As New cla_ESTADO

            Me.cboRUCFESTA.DataSource = objdatos16.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboRUCFESTA.DisplayMember = "ESTADESC"
            Me.cboRUCFESTA.ValueMember = "ESTACODI"

            Me.cboRUCFESTA.SelectedValue = tbl.Rows(0).Item("RUCFESTA")

            ' Lista de valores
            Me.lblRUCFDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboRUCFDEPA), String)
            Me.lblRUCFMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboRUCFDEPA, Me.cboRUCFMUNI), String)
            Me.lblRUCFCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRUCFCLSE), String)
            Me.lblRUCFCAFO.Text = CType(fun_Buscar_Lista_Valores_CARPFOTO_Codigo(Me.cboRUCFCAFO), String)

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

            Dim boFOTCDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUCFDEPA)
            Dim boFOTCMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUCFMUNI)
            Dim boFOTCCAFO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUCFCAFO)
            Dim boFOTCCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUCFCLSE)
            Dim boFOTCESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUCFESTA)
            Dim boRUTARUTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRUCFRUTA)

            ' verifica los datos del formulario 
            If boFOTCDEPA = True And _
               boFOTCMUNI = True And _
               boFOTCCAFO = True And _
               boFOTCCLSE = True And _
               boFOTCESTA = True And _
               boRUTARUTA = True Then

                Dim objdatos22 As New cla_RUTACAFO

                If (objdatos22.fun_Actualizar_MANT_RUTACAFO(inID_REGISTRO, _
                                                            Me.cboRUCFDEPA.SelectedValue, _
                                                            Me.cboRUCFMUNI.SelectedValue, _
                                                            Me.cboRUCFCLSE.SelectedValue, _
                                                            Me.cboRUCFCAFO.SelectedValue, _
                                                            Me.txtRUCFRUTA.Text, _
                                                            Me.cboRUCFESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    Me.cboRUCFDEPA.Focus()
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
        Me.cboRUCFDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRUCFDEPA.KeyPress, cboRUCFMUNI.KeyPress, cboRUCFCAFO.KeyPress, cboRUCFCLSE.KeyPress, txtRUCFRUTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboFOTCDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUCFDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRUCFDEPA, Me.cboRUCFDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOTCMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUCFMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRUCFMUNI, Me.cboRUCFMUNI.SelectedIndex, Me.cboRUCFDEPA)
        End If
    End Sub
    Private Sub cboRUCFCAFO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUCFCAFO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CARPFOTO_Descripcion(Me.cboRUCFCAFO, Me.cboRUCFCAFO.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOTCCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUCFCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRUCFCLSE, Me.cboRUCFCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOTCESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUCFESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRUCFESTA, Me.cboRUCFESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRUCFRUTA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUCFDEPA.GotFocus, cboRUCFMUNI.GotFocus, cboRUCFCAFO.GotFocus, cboRUCFCLSE.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboFOTCDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUCFDEPA.SelectedIndexChanged
        Me.lblRUCFDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboRUCFDEPA), String)

        Me.cboRUCFMUNI.DataSource = New DataTable
        Me.lblRUCFMUNI.Text = ""

    End Sub
    Private Sub cboFOTCMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUCFMUNI.SelectedIndexChanged
        Me.lblRUCFMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboRUCFDEPA, Me.cboRUCFMUNI), String)

    End Sub
    Private Sub cboRUCFCAFO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUCFCAFO.SelectedIndexChanged
        Me.lblRUCFCAFO.Text = CType(fun_Buscar_Lista_Valores_CARPFOTO_Codigo(Me.cboRUCFCAFO), String)

    End Sub
    Private Sub cboFOTCCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUCFCLSE.SelectedIndexChanged
        Me.lblRUCFCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRUCFCLSE), String)

    End Sub

#End Region

#Region "Click"

    Private Sub cboFOTCNODE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUCFDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRUCFDEPA, Me.cboRUCFDEPA.SelectedIndex)
    End Sub
    Private Sub cboFOTCMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUCFMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRUCFMUNI, Me.cboRUCFMUNI.SelectedIndex, Me.cboRUCFDEPA)
    End Sub
    Private Sub cboRUCFCAFO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUCFCAFO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CARPFOTO_Descripcion(Me.cboRUCFCAFO, Me.cboRUCFCAFO.SelectedIndex)
    End Sub
    Private Sub cboFOTCCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUCFCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRUCFCLSE, Me.cboRUCFCLSE.SelectedIndex)
    End Sub
    Private Sub cboFOTCESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUCFESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboRUCFESTA, Me.cboRUCFESTA.SelectedIndex)
    End Sub
    Private Sub cmdCARPETA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCARPETA.Click

        Dim oCarpetas As New FolderBrowserDialog
        Dim stNewPath As String = ""

        oCarpetas.ShowDialog()
        stNewPath = oCarpetas.SelectedPath

        Me.txtRUCFRUTA.Text = stNewPath

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