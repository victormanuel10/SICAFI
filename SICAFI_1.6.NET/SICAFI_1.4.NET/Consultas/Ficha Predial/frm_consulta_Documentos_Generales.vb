Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_consulta_Documentos_Generales

    '=====================================
    '*** CONSULTA DOCUMENTOS GENERALES ***
    '=====================================

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

    Public Shared Function instance() As frm_consulta_Documentos_Generales
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_consulta_Documentos_Generales
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

    Private Sub pro_inicializarControles()

        Try
            Dim objdatos1 As New cla_DEPARTAMENTO

            Me.cboRUDGDEPA.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            Me.cboRUDGDEPA.DisplayMember = "DEPADESC"
            Me.cboRUDGDEPA.ValueMember = "DEPACODI"

            Me.cboRUDGDEPA.SelectedValue = "05"

            Dim objdatos7 As New cla_MUNICIPIO

            Me.cboRUDGMUNI.DataSource = objdatos7.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            Me.cboRUDGMUNI.DisplayMember = "MUNIDESC"
            Me.cboRUDGMUNI.ValueMember = "MUNICODI"

            Me.cboRUDGMUNI.SelectedValue = "266"

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboRUDGDEPA.DataSource = New DataTable
        Me.cboRUDGMUNI.DataSource = New DataTable
        Me.cboRUDGDOGE.DataSource = New DataTable

        Me.lblRUDGDEPA.Text = ""
        Me.lblRUDGMUNI.Text = ""
        Me.lblRUDGDOGE.Text = ""

    End Sub
    Private Sub pro_ListadoArchivosDocumentos(ByVal stRutaCarpeta As String)

        Try
            Me.lstDOCUMENTOS.Items.Clear()

            ' declara la variable
            Dim stRuta As String = ""
            Dim stNewPath As String = ""
            Dim ContentItem As String

            If stRutaCarpeta <> "" Then

                stNewPath = Trim(stRutaCarpeta)

                vl_stRutaDocumentos = stNewPath

                ChDir(stNewPath)

                Me.lstDOCUMENTOS.Items.Clear()

                ContentItem = Dir("*.pdf")

                If ContentItem <> "" Then
                    Me.lstDOCUMENTOS.Focus()
                End If

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstDOCUMENTOS.Items.Add(ContentItem)

                    'desplaza el registro
                    ContentItem = Dir()
                Loop

            Else
                Me.lstDOCUMENTOS.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_PermisoControlDeComandos()

        Try

            Me.axaVisorDocumentoPDF.setShowToolbar(fun_PermisoControlDeComandos(vp_usuario, Me.Name, Me.axaVisorDocumentoPDF.Name))

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

            Dim boOBINDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUDGDEPA)
            Dim boOBINMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUDGMUNI)
            Dim boOBINBAVE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboRUDGDOGE)

            If boOBINDEPA = True And _
               boOBINMUNI = True And _
               boOBINBAVE = True Then

                ' instancia la clase
                Dim obRUTADOGE As New cla_RUTADOGE
                Dim dtRUTADOGE As New DataTable

                dtRUTADOGE = obRUTADOGE.fun_Buscar_CODIGO_DEPA_MUNI_DOGE_X_DOCUGENE(Me.cboRUDGDEPA.SelectedValue, Me.cboRUDGMUNI.SelectedValue, Me.cboRUDGDOGE.SelectedValue)

                If dtRUTADOGE.Rows.Count > 0 Then

                    Dim stRUTA As String = Trim(dtRUTADOGE.Rows(0).Item("RUDGRUTA").ToString)

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

    Private Sub frm_consulta_Documentos_Generales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRUDGDEPA.KeyPress, cboRUDGMUNI.KeyPress, cboRUDGDOGE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub
#End Region

#Region "KeyDown"

    Private Sub cboOBINDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUDGDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRUDGDEPA, Me.cboRUDGDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUDGMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRUDGMUNI, Me.cboRUDGMUNI.SelectedIndex, Me.cboRUDGDEPA)
        End If
    End Sub
    Private Sub cboRUDGDOGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRUDGDOGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DOCUGENE_Descripcion(Me.cboRUDGDOGE, Me.cboRUDGDOGE.SelectedIndex, Me.cboRUDGDEPA, Me.cboRUDGMUNI)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUDGDEPA.GotFocus, cboRUDGMUNI.GotFocus, cboRUDGDOGE.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboOBINDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUDGDEPA.SelectedIndexChanged
        Me.lblRUDGDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboRUDGDEPA), String)

        Me.cboRUDGMUNI.DataSource = New DataTable
        Me.lblRUDGMUNI.Text = ""

        Me.cboRUDGDOGE.DataSource = New DataTable
        Me.lblRUDGDOGE.Text = ""

    End Sub
    Private Sub cboOBINMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUDGMUNI.SelectedIndexChanged
        Me.lblRUDGMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboRUDGDEPA, Me.cboRUDGMUNI), String)

        Me.cboRUDGDOGE.DataSource = New DataTable
        Me.lblRUDGDOGE.Text = ""

    End Sub
    Private Sub cboRUDGDOGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUDGDOGE.SelectedIndexChanged
        Me.lblRUDGDOGE.Text = CType(fun_Buscar_Lista_Valores_DOCUGENE_Codigo(Me.cboRUDGDEPA, Me.cboRUDGMUNI, Me.cboRUDGDOGE), String)
    End Sub
    Private Sub lstMANZANA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstDOCUMENTOS.SelectedIndexChanged

        Try
            If lstDOCUMENTOS.SelectedIndex <> -1 Then

                Dim stArchivo As String = lstDOCUMENTOS.SelectedItem

                axaVisorDocumentoPDF.LoadFile(vl_stRutaDocumentos & "\" & stArchivo)
                axaVisorDocumentoPDF.gotoFirstPage()

                pro_PermisoControlDeComandos()

            Else

                If lstDOCUMENTOS.Items.Count > 0 Then
                    MessageBox.Show("Seleccione un archivo de la lista", "mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "Click"

    Private Sub cboOBINNODE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUDGDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRUDGDEPA, Me.cboRUDGDEPA.SelectedIndex)
    End Sub
    Private Sub cboOBINMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUDGMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRUDGMUNI, Me.cboRUDGMUNI.SelectedIndex, Me.cboRUDGDEPA)
    End Sub
    Private Sub cboRUDGDOGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUDGDOGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DOCUGENE_Descripcion(Me.cboRUDGDOGE, Me.cboRUDGDOGE.SelectedIndex, Me.cboRUDGDEPA, Me.cboRUDGMUNI)
    End Sub

#End Region

#End Region

End Class