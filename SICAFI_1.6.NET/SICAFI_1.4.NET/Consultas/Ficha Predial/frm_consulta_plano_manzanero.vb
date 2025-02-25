Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_consulta_plano_manzanero

    '================================
    '*** CONSULTA PLANO MANZANERO ***
    '================================

#Region "CONSTRUCTORES"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private ds As New DataSet
    Private dt As New DataTable

    Dim tblCONSULTA As New DataTable

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_consulta_plano_manzanero
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_consulta_plano_manzanero
        End If

        frm_Instance.bringtofront()

        Return frm_Instance

    End Function

    Private Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

#End Region

#Region "VARIABLES"

    Dim vl_stRutaDocumentos As String = ""

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboRUPMCORR.DataSource = New DataTable
        Me.cboRUPMDEPA.DataSource = New DataTable
        Me.cboRUPMMUNI.DataSource = New DataTable
        Me.cboRUPMBAVE.DataSource = New DataTable
        Me.cboRUPMCLSE.DataSource = New DataTable

        Me.lblRUPMCORR.Text = ""
        Me.lblRUPMDEPA.Text = ""
        Me.lblRUPMMUNI.Text = ""
        Me.lblRUPMBAVE.Text = ""
        Me.lblRUPMCLSE.Text = ""

    End Sub
    Private Sub pro_ListadoArchivosDocumentos(ByVal stRutaCarpeta As String)

        Try
            Me.lstMANZANA.Items.Clear()

            ' declara la variable
            Dim stRuta As String = ""
            Dim stNewPath As String = ""
            Dim ContentItem As String

            If stRutaCarpeta <> "" Then

                stNewPath = Trim(stRutaCarpeta)

                vl_stRutaDocumentos = stNewPath

                ChDir(stNewPath)

                Me.lstMANZANA.Items.Clear()

                ContentItem = Dir("*.pdf")

                If ContentItem <> "" Then
                    Me.lstMANZANA.Focus()
                End If

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstMANZANA.Items.Add(ContentItem)

                    'desplaza el registro
                    ContentItem = Dir()
                Loop

            Else
                Me.lstMANZANA.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_PermisoControlDeComandos()

        Try

            axaVisorDocumentoPDF.setShowToolbar(fun_PermisoControlDeComandos(vp_usuario, Me.Name, Me.axaVisorDocumentoPDF.Name))

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_inicializarControles()

        Try
            Dim objdatos1 As New cla_DEPARTAMENTO

            Me.cboRUPMDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboRUPMDEPA.DisplayMember = "DEPADESC"
            Me.cboRUPMDEPA.ValueMember = "DEPACODI"

            Me.cboRUPMDEPA.SelectedValue = "05"

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboRUPMMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboRUPMMUNI.DisplayMember = "MUNIDESC"
            Me.cboRUPMMUNI.ValueMember = "MUNICODI"

            Me.cboRUPMMUNI.SelectedValue = "266"

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boOBINDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPMDEPA)
            Dim boOBINMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPMMUNI)
            Dim boOBINCORR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPMCORR)
            Dim boOBINBAVE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPMBAVE)
            Dim boOBINCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUPMCLSE)

            If boOBINDEPA = True And _
               boOBINMUNI = True And _
               boOBINCORR = True And _
               boOBINBAVE = True And _
               boOBINCLSE = True Then

                ' instancia la clase
                Dim obRUTAPLMA As New cla_RUTAPLMA
                Dim dtRUTAPLMA As New DataTable

                dtRUTAPLMA = obRUTAPLMA.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_BAVE_X_MANT_RUTAPLMA(Me.cboRUPMDEPA.SelectedValue, Me.cboRUPMMUNI.SelectedValue, Me.cboRUPMCLSE.SelectedValue, Me.cboRUPMCORR.SelectedValue, Me.cboRUPMBAVE.SelectedValue)

                If dtRUTAPLMA.Rows.Count > 0 Then

                    Dim stRUTA As String = Trim(dtRUTAPLMA.Rows(0).Item("RUPMRUTA").ToString)

                    pro_ListadoArchivosDocumentos(Trim(stRUTA))

                Else
                    MessageBox.Show("No existe ruta que enlace la consulta", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_consulta_plano_manzanero_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRUPMDEPA.KeyPress, cboRUPMMUNI.KeyPress, cboRUPMCORR.KeyPress, cboRUPMBAVE.KeyPress, cboRUPMCLSE.KeyPress
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

#End Region

#Region "GotFocus"

    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
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
    Private Sub lstMANZANA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMANZANA.SelectedIndexChanged

        Try
            If lstMANZANA.SelectedIndex <> -1 Then

                Dim stArchivo As String = lstMANZANA.SelectedItem

                axaVisorDocumentoPDF.LoadFile(vl_stRutaDocumentos & "\" & stArchivo)
                axaVisorDocumentoPDF.gotoFirstPage()

                pro_PermisoControlDeComandos()

            Else

                If lstMANZANA.Items.Count > 0 Then
                    MessageBox.Show("Seleccione un archivo de la lista", "mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

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

#End Region

#End Region


End Class