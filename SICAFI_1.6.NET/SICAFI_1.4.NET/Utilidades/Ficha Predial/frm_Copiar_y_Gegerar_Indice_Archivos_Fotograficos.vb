Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_Copiar_y_Gegerar_Indice_Archivos_Fotograficos

    '=======================================================
    '*** COPIAR Y GENERAR INDICE DE ARCHIVOS FOTOGRAFICO ***
    '=======================================================

#Region "VARIABLE"

    Dim oLeer As New OpenFileDialog

    Dim vl_stRutaInicial As String = ""
    Dim vl_stRutaDestino As String = ""
    Dim vl_stRutaDocumentos As String = ""

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Copiar_y_Gegerar_Indice_Archivos_Fotograficos
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Copiar_y_Gegerar_Indice_Archivos_Fotograficos
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

#Region "PROCEDIMIENTOS"

    Private Sub pro_IndexarArchivoFotografico()

        Try
            If Me.chkIndexarCroquisDelPredio.Checked = False Then

                Dim stNroFicha As String = fun_ObtenerNroFicha(Me.lstLISTADO_DOCUMENTOS.SelectedItem)
                Dim stNroConstruccion As String = fun_ObtenerNroConstruccion(Me.lstLISTADO_DOCUMENTOS.SelectedItem)
                Dim stNroFoto As String = fun_ObtenerNroFoto(Me.lstLISTADO_DOCUMENTOS.SelectedItem)

                If stNroFicha.ToString.Length <= 9 AndAlso
                   fun_Verificar_Dato_Numerico_Evento_Validated(stNroFicha) = True And _
                   fun_Verificar_Dato_Numerico_Evento_Validated(stNroConstruccion) = True And _
                   fun_Verificar_Dato_Numerico_Evento_Validated(stNroFoto) = True Then

                    ' instancia la clase
                    Dim obFIPRIMAG1 As New cla_FIPRIMAG
                    Dim tdFIPRIMAG1 As New DataTable

                    tdFIPRIMAG1 = obFIPRIMAG1.fun_Buscar_CODIGO_FIPRIMAG(stNroFicha, stNroConstruccion, stNroFoto)

                    If tdFIPRIMAG1.Rows.Count = 0 Then
                        obFIPRIMAG1.fun_Insertar_FIPRIMAG(stNroFicha, stNroConstruccion, stNroFoto, Trim(vl_stRutaDestino), Me.cboRUCFDEPA.SelectedValue, Me.cboRUCFMUNI.SelectedValue, Me.cboRUCFCLSE.SelectedValue)
                    Else
                        obFIPRIMAG1.fun_Actualizar_FIPRIMAG(stNroFicha, stNroConstruccion, stNroFoto, Trim(vl_stRutaDestino), Me.cboRUCFDEPA.SelectedValue, Me.cboRUCFMUNI.SelectedValue, Me.cboRUCFCLSE.SelectedValue)
                    End If

                End If

            ElseIf Me.chkIndexarCroquisDelPredio.Checked = True Then

                Dim stNroFicha As String = fun_ObtenerNroFicha(Me.lstLISTADO_DOCUMENTOS.SelectedItem)
                Dim stNroConstruccion As String = fun_ObtenerNroConstruccion(Me.lstLISTADO_DOCUMENTOS.SelectedItem)
                Dim stNroFoto As String = fun_ObtenerNroFoto(Me.lstLISTADO_DOCUMENTOS.SelectedItem)

                If stNroFicha.ToString.Length <= 9 AndAlso
                   fun_Verificar_Dato_Numerico_Evento_Validated(stNroFicha) = True And _
                   fun_Verificar_Dato_Numerico_Evento_Validated(stNroConstruccion) = False And _
                   fun_Verificar_Dato_Numerico_Evento_Validated(stNroFoto) = False Then

                    ' instancia la clase
                    Dim obFIPRIMAG1 As New cla_FIPRCROQ
                    Dim tdFIPRIMAG1 As New DataTable

                    tdFIPRIMAG1 = obFIPRIMAG1.fun_Buscar_CODIGO_FIPRCROQ(stNroFicha, "0", "0")

                    If tdFIPRIMAG1.Rows.Count = 0 Then
                        obFIPRIMAG1.fun_Insertar_FIPRCROQ(stNroFicha, "0", "0", Trim(vl_stRutaDestino))
                    Else
                        obFIPRIMAG1.fun_Actualizar_FIPRCROQ(stNroFicha, "0", "0", Trim(vl_stRutaDestino))
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtRUCFRUTA.Text = ""
        Me.lblRUCFCAFO.Text = ""
        Me.lblRUCFDEPA.Text = ""
        Me.lblRUCFMUNI.Text = ""
        Me.lblRUCFCLSE.Text = ""

        Me.lblRuta.Text = ""
        Me.lstLISTADO_DOCUMENTOS.Items.Clear()


        Me.cboRUCFCAFO.DataSource = New DataTable
        Me.cboRUCFDEPA.DataSource = New DataTable
        Me.cboRUCFMUNI.DataSource = New DataTable
        Me.cboRUCFCLSE.DataSource = New DataTable

    End Sub
    Private Sub pro_ListadoArchivosDocumentos(ByVal stRutaCarpeta As String)

        Try
            Me.lstLISTADO_DOCUMENTOS.Items.Clear()

            ' declara la variable
            Dim stRuta As String = ""
            Dim stNewPath As String = ""
            Dim ContentItem As String

            If stRutaCarpeta <> "" Then

                stNewPath = Trim(stRutaCarpeta)

                vl_stRutaDocumentos = stNewPath

                ChDir(stNewPath)

                Me.lstLISTADO_DOCUMENTOS.Items.Clear()

                ContentItem = Dir("*.jpg")

                If ContentItem <> "" Then
                    Me.lstLISTADO_DOCUMENTOS.Focus()
                End If

                Dim i As Integer = 0

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstLISTADO_DOCUMENTOS.Items.Add(ContentItem)

                    ' desplaza el registro
                    ContentItem = Dir()

                    ' cuenta los registros
                    i += 1
                Loop

                Me.strBARRESTA.Items(2).Text = "Nro. Registros: " & i

            Else
                Me.lstLISTADO_DOCUMENTOS.Items.Clear()

                Me.strBARRESTA.Items(2).Text = "Nro. Registros: " & 0
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_CopiarDocumento(ByVal stRutaInicial As String, ByVal stRutaDestino As String)

        Try
            If File.Exists(Trim(stRutaDestino)) = False Then
                File.Copy(Trim(stRutaInicial), Trim(stRutaDestino))

                pro_IndexarArchivoFotografico()

             ElseIf File.Exists(Trim(stRutaDestino)) = True Then

                MessageBox.Show("Archivo existente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EliminarDocumento(ByVal stRutaDestino As String)

        Try
            If File.Exists(Trim(stRutaDestino)) = True Then
                File.Delete(Trim(stRutaDestino))

                'MessageBox.Show("Se elimino el archivo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("Archivo no existente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_ObtenerNroFicha(ByVal stCadena As String) As String

        Try
            Dim stResultado As String = ""

            Dim inTamano As Integer = stCadena.ToString.Length

            Dim sw1 As Byte = 0
            Dim j1 As Integer = 0

            While j1 < stCadena.ToString.Length And sw1 = 0

                If fun_Verificar_Dato_Numerico_Evento_Validated(stCadena.ToString.Substring(j1, 1)) = True Then
                    stResultado += stCadena.ToString.Substring(j1, 1)
                    j1 = j1 + 1
                Else
                    sw1 = 1
                End If

            End While

            Return stResultado

        Catch ex As Exception
            Return ""
        End Try

    End Function
    Private Function fun_ObtenerNroConstruccion(ByVal stCadena As String) As String

        Try
            Dim stResultado As String = ""

            Dim inTamano As Integer = stCadena.ToString.Length

            Dim sw1 As Byte = 0
            Dim j1 As Integer = 0
            Dim inContador As Integer = 0

            While j1 < stCadena.ToString.Length And sw1 = 0

                If fun_Verificar_Dato_Numerico_Evento_Validated(stCadena.ToString.Substring(j1, 1)) = True Then
                    j1 = j1 + 1
                ElseIf stCadena.ToString.Substring(j1, 1) = "-" Or stCadena.ToString.Substring(j1, 1) = "_" Then
                    stResultado += stCadena.ToString.Substring((j1 + 1), 1)

                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If

            End While

            Return stResultado

        Catch ex As Exception
            Return ""
        End Try

    End Function
    Private Function fun_ObtenerNroFoto(ByVal stCadena As String) As String

        Try
            Dim stResultado As String = ""

            Dim inTamano As Integer = stCadena.ToString.Length

            Dim sw1 As Byte = 0
            Dim j1 As Integer = 0
            Dim inContador As Integer = 0

            While j1 < stCadena.ToString.Length And sw1 = 0

                If stCadena.ToString.Substring(j1, 1) = "-" Or stCadena.ToString.Substring(j1, 1) = "_" Then
                    inContador += 1
                    j1 = j1 + 1
                Else
                    j1 = j1 + 1
                    If inContador = 2 Then
                        stResultado += stCadena.ToString.Substring((j1 - 1), 1)
                        sw1 = 1

                    End If
                End If

            End While

            Return stResultado

        Catch ex As Exception
            Return ""
        End Try

    End Function
    Private Function fun_ConsultarRutaInicial() As String

        Try
            Dim stRutaInicial As String = ""

            stRutaInicial = vl_stRutaDocumentos & "\" & Me.lstLISTADO_DOCUMENTOS.SelectedItem

            Return stRutaInicial

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return ""
        End Try

    End Function
    Private Function fun_consultarRutaDestino() As String

        Try
            vl_stRutaDestino = Trim(Me.txtRUCFRUTA.Text)

            vl_stRutaDestino = vl_stRutaDestino & "\" & Me.lstLISTADO_DOCUMENTOS.SelectedItem

            Return vl_stRutaDestino

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return ""
        End Try

    End Function

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            If Me.chkImportarTodos.Checked = False Then

                If Me.lstLISTADO_DOCUMENTOS.SelectedIndex <> -1 Then

                    Dim stRutaInicial As String = fun_ConsultarRutaInicial()
                    Dim stRutaDestino As String = fun_consultarRutaDestino()

                    pro_CopiarDocumento(stRutaInicial, stRutaDestino)

                    If Me.chkRealizarCopia.Checked = False Then
                        pro_EliminarDocumento(stRutaInicial)
                    End If

                    Me.lstLISTADO_DOCUMENTOS.Items.RemoveAt(lstLISTADO_DOCUMENTOS.SelectedIndex)

                    Me.strBARRESTA.Items(2).Text = "Nro. Registros: " & Me.lstLISTADO_DOCUMENTOS.Items.Count

                    MessageBox.Show("Se copio el archivo correctamente ", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                Else
                    If Me.lstLISTADO_DOCUMENTOS.Items.Count > 0 Then
                        MessageBox.Show("Para guardar un documento, debe seleccionarlo previamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No existen documentos cargados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    End If

                End If

            ElseIf Me.chkImportarTodos.Checked = True Then

                If lstLISTADO_DOCUMENTOS.Items.Count > 0 Then

                    While lstLISTADO_DOCUMENTOS.Items.Count > 0

                        lstLISTADO_DOCUMENTOS.SelectedIndex = lstLISTADO_DOCUMENTOS.Items.Count - 1

                        Dim stRutaInicial As String = fun_ConsultarRutaInicial()
                        Dim stRutaDestino As String = fun_consultarRutaDestino()

                        pro_CopiarDocumento(stRutaInicial, stRutaDestino)

                        If Me.chkRealizarCopia.Checked = False Then
                            pro_EliminarDocumento(stRutaInicial)
                        End If

                        Me.lstLISTADO_DOCUMENTOS.Items.RemoveAt(lstLISTADO_DOCUMENTOS.SelectedIndex)

                        Me.strBARRESTA.Items(2).Text = "Nro. Registros: " & Me.lstLISTADO_DOCUMENTOS.Items.Count

                    End While

                    MessageBox.Show("Se copio el archivo correctamente ", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                Else
                    MessageBox.Show("No existen documentos cargados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand)

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub
    Private Sub cmdBuscarRuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscarRuta.Click

        Try
            If Me.chkIndexarCroquisDelPredio.Checked = False Then

                If Me.cboRUCFDEPA.Text = "" Or _
                   Me.cboRUCFMUNI.Text = "" Or _
                   Me.cboRUCFCLSE.Text = "" Or _
                   Me.cboRUCFCAFO.Text = "" Then

                    mod_MENSAJE.Existen_Campos_Sin_Diligenciar()

                Else
                    ' instancia la clase
                    Dim obRUTACAFO As New cla_RUTACAFO
                    Dim dtRUTACAFO As New DataTable

                    dtRUTACAFO = obRUTACAFO.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_RUCF_X_MANT_RUTACAFO(Me.cboRUCFDEPA.SelectedValue, _
                                                                                                       Me.cboRUCFMUNI.SelectedValue, _
                                                                                                       Me.cboRUCFCLSE.SelectedValue, _
                                                                                                       Me.cboRUCFCAFO.SelectedValue)
                    If dtRUTACAFO.Rows.Count > 0 Then

                        Me.txtRUCFRUTA.Text = Trim(dtRUTACAFO.Rows(0).Item("RUCFRUTA").ToString)
                        Me.cmdAbrirCarpeta.Enabled = True

                    Else

                        Me.cmdAbrirCarpeta.Enabled = False
                        mod_MENSAJE.Consulta_No_Encontro_Registros()

                    End If

                End If

            ElseIf Me.chkIndexarCroquisDelPredio.Checked = True Then

                Dim obRUTAS As New cla_RUTAS
                Dim dtRUTAS As New DataTable

                dtRUTAS = obRUTAS.fun_Buscar_CODIGO_MANT_RUTAS(1)

                If dtRUTAS.Rows.Count > 0 Then

                    Me.txtRUCFRUTA.Text = Trim(dtRUTAS.Rows(0).Item("RUTARUTA").ToString)
                    Me.cmdAbrirCarpeta.Enabled = True

                Else

                    Me.cmdAbrirCarpeta.Enabled = False
                    mod_MENSAJE.Consulta_No_Encontro_Registros()

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdAbrirCarpeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirCarpeta.Click

        Dim oCarpetas As New FolderBrowserDialog
        Dim stNewPath As String = ""

        oCarpetas.ShowDialog()
        stNewPath = oCarpetas.SelectedPath

        Me.lblRuta.Text = stNewPath

        pro_ListadoArchivosDocumentos(Me.lblRuta.Text)

        Try
            '*** VERIFICA QUE LA RUTA ESTE CORRECTA ***
            ChDir(stNewPath)

        Catch ex As Exception When stNewPath = ""
            MessageBox.Show("Se debe introducir una ruta valida", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_OBSEINMO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        pro_LimpiarCampos()
        Me.cboRUCFDEPA.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRUCFRUTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboOBINDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRUCFDEPA, Me.cboRUCFDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRUCFMUNI, Me.cboRUCFMUNI.SelectedIndex, Me.cboRUCFDEPA)
        End If
    End Sub
    Private Sub cboRUCFCAFO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CARPFOTO_Descripcion(Me.cboRUCFCAFO, Me.cboRUCFCAFO.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRUCFCLSE, Me.cboRUCFCLSE.SelectedIndex)
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

    Private Sub cboOBINDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUCFDEPA.SelectedIndexChanged
        Me.lblRUCFDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboRUCFDEPA), String)

        Me.cboRUCFMUNI.DataSource = New DataTable
        Me.lblRUCFMUNI.Text = ""

    End Sub
    Private Sub cboOBINMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUCFMUNI.SelectedIndexChanged
        Me.lblRUCFMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboRUCFDEPA, Me.cboRUCFMUNI), String)

    End Sub
    Private Sub cboRUCFCAFO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUCFCAFO.SelectedIndexChanged
        Me.lblRUCFCAFO.Text = CType(fun_Buscar_Lista_Valores_CARPFOTO_Codigo(Me.cboRUCFCAFO), String)

    End Sub
    Private Sub cboOBINCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRUCFCLSE.SelectedIndexChanged
        Me.lblRUCFCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboRUCFCLSE), String)

    End Sub

#End Region

#Region "Click"

    Private Sub cboOBINNODE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUCFDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboRUCFDEPA, Me.cboRUCFDEPA.SelectedIndex)
    End Sub
    Private Sub cboOBINMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUCFMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboRUCFMUNI, Me.cboRUCFMUNI.SelectedIndex, Me.cboRUCFDEPA)
    End Sub
    Private Sub cboRUCFCAFO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUCFCAFO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CARPFOTO_Descripcion(Me.cboRUCFCAFO, Me.cboRUCFCAFO.SelectedIndex)

        Me.txtRUCFRUTA.Text = ""
        Me.lblRuta.Text = ""
        Me.cmdAbrirCarpeta.Enabled = False

        Me.lstLISTADO_DOCUMENTOS.Items.Clear()

        Me.strBARRESTA.Items(2).Text = "Nro. Registros: " & 0

    End Sub
    Private Sub cboOBINCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUCFCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRUCFCLSE, Me.cboRUCFCLSE.SelectedIndex)
    End Sub

#End Region

#Region "CheckedChanged"

    Private Sub chkIndexarCroquisDelPredio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIndexarCroquisDelPredio.CheckedChanged

        Try
            If Me.chkIndexarCroquisDelPredio.Checked = True Then
                pro_LimpiarCampos()

                Me.cboRUCFCAFO.Enabled = False
                Me.cboRUCFDEPA.Enabled = False
                Me.cboRUCFMUNI.Enabled = False
                Me.cboRUCFCLSE.Enabled = False

            ElseIf Me.chkIndexarCroquisDelPredio.Checked = False Then
                pro_LimpiarCampos()

                Me.cboRUCFCAFO.Enabled = True
                Me.cboRUCFDEPA.Enabled = True
                Me.cboRUCFMUNI.Enabled = True
                Me.cboRUCFCLSE.Enabled = True

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#End Region

End Class