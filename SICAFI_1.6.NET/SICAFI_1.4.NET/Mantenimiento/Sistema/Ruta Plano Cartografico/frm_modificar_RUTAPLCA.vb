Imports REGLAS_DEL_NEGOCIO

Public Class frm_modificar_RUTAPLCA

    '=========================================
    '*** MODIFICAR RUTA PLANO CARTOGRAFICO ***
    '=========================================

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

            Dim objdatos8 As New cla_RUTAPLCA
            Dim tbl As New DataTable

            tbl = objdatos8.fun_Buscar_ID_MANT_RUTAPLCA(inID_REGISTRO)

            Dim objdatos11 As New cla_DEPARTAMENTO

            Me.cboRUPCDEPA.DataSource = objdatos11.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboRUPCDEPA.DisplayMember = "DEPADESC"
            Me.cboRUPCDEPA.ValueMember = "DEPACODI"

            Me.cboRUPCDEPA.SelectedValue = tbl.Rows(0).Item("RUPCDEPA")

            Dim objdatos12 As New cla_MUNICIPIO

            Me.cboRUPCMUNI.DataSource = objdatos12.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboRUPCMUNI.DisplayMember = "MUNIDESC"
            Me.cboRUPCMUNI.ValueMember = "MUNICODI"

            Me.cboRUPCMUNI.SelectedValue = tbl.Rows(0).Item("RUPCMUNI")

            Dim objdatos1 As New cla_CLASSECT

            Me.cboRUPCCLSE.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CLASSECT
            Me.cboRUPCCLSE.DisplayMember = "CLSEDESC"
            Me.cboRUPCCLSE.ValueMember = "CLSECODI"

            Me.cboRUPCCLSE.SelectedValue = tbl.Rows(0).Item("RUPCCLSE")

            Dim objdatos18 As New cla_PLANCART

            Me.cboRUPCPLCA.DataSource = objdatos18.fun_Consultar_CAMPOS_MANT_PLANCART
            Me.cboRUPCPLCA.DisplayMember = "PLCADESC"
            Me.cboRUPCPLCA.ValueMember = "PLCACODI"

            Me.cboRUPCPLCA.SelectedValue = tbl.Rows(0).Item("RUPCPLCA")

            Me.txtRUPCRUTA.Text = Trim(tbl.Rows(0).Item("RUPCRUTA"))

            Dim objdatos16 As New cla_ESTADO

            Me.cboRUPCESTA.DataSource = objdatos16.fun_Consultar_TODOS_LOS_ESTADOS
            Me.cboRUPCESTA.DisplayMember = "ESTADESC"
            Me.cboRUPCESTA.ValueMember = "ESTACODI"

            Me.cboRUPCESTA.SelectedValue = tbl.Rows(0).Item("RUPCESTA")

            ' Lista de valores
            Me.lblRUPCDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboRUPCDEPA), String)
            Me.lblRUPCMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboRUPCDEPA, Me.cboRUPCMUNI), String)
            Me.lblRUPCCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRUPCCLSE), String)
            Me.lblRUPCPLCA.Text = CType(fun_Buscar_Lista_Valores_PLANCART_Codigo(Me.cboRUPCPLCA), String)

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

            Dim boFOTCDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPCDEPA)
            Dim boFOTCMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPCMUNI)
            Dim boFOTCCAFO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPCPLCA)
            Dim boFOTCCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPCCLSE)
            Dim boFOTCESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPCESTA)
            Dim boRUTARUTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtRUPCRUTA)

            ' verifica los datos del formulario 
            If boFOTCDEPA = True And _
               boFOTCMUNI = True And _
               boFOTCCAFO = True And _
               boFOTCCLSE = True And _
               boFOTCESTA = True And _
               boRUTARUTA = True Then

                Dim objdatos22 As New cla_RUTAPLCA

                If (objdatos22.fun_Actualizar_MANT_RUTAPLCA(inID_REGISTRO, _
                                                            Me.cboRUPCDEPA.SelectedValue, _
                                                            Me.cboRUPCMUNI.SelectedValue, _
                                                            Me.cboRUPCCLSE.SelectedValue, _
                                                            Me.cboRUPCPLCA.SelectedValue, _
                                                            Me.txtRUPCRUTA.Text, _
                                                            Me.cboRUPCESTA.SelectedValue)) = True Then

                    mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                    Me.cboRUPCDEPA.Focus()
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
        Me.cboRUPCDEPA.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRUPCDEPA.KeyPress, cboRUPCMUNI.KeyPress, cboRUPCPLCA.KeyPress, cboRUPCCLSE.KeyPress, txtRUPCRUTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboFOTCDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUPCDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRUPCDEPA, Me.cboRUPCDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOTCMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUPCMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRUPCMUNI, Me.cboRUPCMUNI.SelectedIndex, Me.cboRUPCDEPA)
        End If
    End Sub
    Private Sub cboRUPCCAFO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUPCPLCA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_PLANCART_Descripcion(Me.cboRUPCPLCA, Me.cboRUPCPLCA.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOTCCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUPCCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRUPCCLSE, Me.cboRUPCCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboFOTCESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUPCESTA.KeyDown
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

    Private Sub cboFOTCDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUPCDEPA.SelectedIndexChanged
        Me.lblRUPCDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboRUPCDEPA), String)

        Me.cboRUPCMUNI.DataSource = New DataTable
        Me.lblRUPCMUNI.Text = ""

    End Sub
    Private Sub cboFOTCMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUPCMUNI.SelectedIndexChanged
        Me.lblRUPCMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboRUPCDEPA, Me.cboRUPCMUNI), String)

    End Sub
    Private Sub cboRUPCCAFO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUPCPLCA.SelectedIndexChanged
        Me.lblRUPCPLCA.Text = CType(fun_Buscar_Lista_Valores_PLANCART_Codigo(Me.cboRUPCPLCA), String)

    End Sub
    Private Sub cboFOTCCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUPCCLSE.SelectedIndexChanged
        Me.lblRUPCCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRUPCCLSE), String)

    End Sub

#End Region

#Region "Click"

    Private Sub cboFOTCNODE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPCDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRUPCDEPA, Me.cboRUPCDEPA.SelectedIndex)
    End Sub
    Private Sub cboFOTCMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPCMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRUPCMUNI, Me.cboRUPCMUNI.SelectedIndex, Me.cboRUPCDEPA)
    End Sub
    Private Sub cboRUPCCAFO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPCPLCA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_PLANCART_Descripcion(Me.cboRUPCPLCA, Me.cboRUPCPLCA.SelectedIndex)
    End Sub
    Private Sub cboFOTCCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPCCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRUPCCLSE, Me.cboRUPCCLSE.SelectedIndex)
    End Sub
    Private Sub cboFOTCESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUPCESTA.Click
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