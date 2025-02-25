Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_Depurar_Carpetas_Fotograficas

    '=====================================
    '*** DEPURAR CARPETAS FOTOGRAFICAS ***
    '=====================================

#Region "VARIABLE"

    Dim oLeer As New OpenFileDialog

    Dim vl_stRutaInicial As String = ""
    Dim vl_stRutaDestino As String = ""
    Dim vl_stRutaDocumentos As String = ""

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private dt_Predio As New DataTable
    Private dt_Imagen As New DataTable

    Dim inProceso As Integer = 0

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Depurar_Carpetas_Fotograficas
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Depurar_Carpetas_Fotograficas
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

    Private Sub pro_LimpiarCampos()

        Me.lblRUCFDEPA.Text = ""
        Me.lblRUCFMUNI.Text = ""
        Me.lblRUCFCLSE.Text = ""

        Me.txtRutaDestino.Text = ""

        Me.cboRUCFDEPA.DataSource = New DataTable
        Me.cboRUCFMUNI.DataSource = New DataTable
        Me.cboRUCFCLSE.DataSource = New DataTable

    End Sub
    Private Sub pro_MoverDocumento(ByVal stRutaInicial As String, ByVal stRutaDestino As String)

        Try
            If File.Exists(Trim(stRutaInicial)) = True And File.Exists(Trim(stRutaDestino)) = False Then
                File.Move(Trim(stRutaInicial), Trim(stRutaDestino))

            ElseIf File.Exists(Trim(stRutaDestino)) = True Then

                MessageBox.Show("Archivo existente " & stRutaDestino, "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
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

    Private Function fun_ObtenerConsultaDePredio(ByVal stDepartamento As String, ByVal stMunicipio As String, ByVal inSector As Integer) As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt_Predio = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi, "
            ParametrosConsulta += "FiprDepa, "
            ParametrosConsulta += "FiprMuni, "
            ParametrosConsulta += "FiprClse, "
            ParametrosConsulta += "FiprTifi "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprDepa like '" & Trim(stDepartamento) & "' and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stMunicipio) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(inSector) & "' and "
            ParametrosConsulta += "FiprTifi = 0 and "
            ParametrosConsulta += "FiprEsta = 'ac' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_Predio)

            ' cierra la conexion
            oConexion.Close()

            Return dt_Predio

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ObtenerConsultaDeImagenes(ByVal stDepartamento As String, ByVal stMunicipio As String, ByVal inSector As Integer) As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt_Imagen = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select * "
            ParametrosConsulta += "From FiprImag where "
            ParametrosConsulta += "FpimDepa like '" & Trim(stDepartamento) & "' and "
            ParametrosConsulta += "FpimMuni like '" & Trim(stMunicipio) & "' and "
            ParametrosConsulta += "FpimClse like '" & Trim(inSector) & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_Imagen)

            ' cierra la conexion
            oConexion.Close()

            Return dt_Imagen

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
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
    Private Function fun_consultarRutaDestino() As String

        Try
            vl_stRutaDestino = Trim(Me.txtRutaDestino.Text)

            vl_stRutaDestino += "\"

            Return vl_stRutaDestino

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return ""
        End Try

    End Function

#End Region

#Region "MENU"

    Private Sub cmdCARGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCARGAR.Click

        Try

            Dim dtConsultaPredios As New DataTable
            Dim dtConsultaImagenes As New DataTable

            dtConsultaPredios = fun_ObtenerConsultaDePredio(Me.cboRUCFDEPA.SelectedValue, Me.cboRUCFMUNI.SelectedValue, Me.cboRUCFCLSE.SelectedValue)
            dtConsultaImagenes = fun_ObtenerConsultaDeImagenes(Me.cboRUCFDEPA.SelectedValue, Me.cboRUCFMUNI.SelectedValue, Me.cboRUCFCLSE.SelectedValue)

            If dtConsultaImagenes.Rows.Count > 0 And dtConsultaPredios.Rows.Count > 0 Then

                ' Valores predeterminados ProgressBar
                inProceso = 0
                pbPROCESO.Value = 0
                pbPROCESO.Maximum = dtConsultaImagenes.Rows.Count + 1
                Timer1.Enabled = True

                ' Crea objeto registros
                Dim dr1 As DataRow

                ' crea la tabla
                Dim dt_ImagenesNoCrazanConFicha As New DataTable

                ' Crea las columnas
                dt_ImagenesNoCrazanConFicha.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                dt_ImagenesNoCrazanConFicha.Columns.Add(New DataColumn("Nro_Construccion", GetType(String)))
                dt_ImagenesNoCrazanConFicha.Columns.Add(New DataColumn("Nro_Foto", GetType(String)))
                dt_ImagenesNoCrazanConFicha.Columns.Add(New DataColumn("Ruta", GetType(String)))

                Dim i As Integer = 0

                ' Recorro la tabla del municipio
                For i = 0 To dtConsultaImagenes.Rows.Count - 1

                    Dim sw1 As Byte = 0
                    Dim j1 As Integer = 0
                    Dim bySW As Byte = 0

                    While j1 < dtConsultaPredios.Rows.Count And sw1 = 0

                        If Val(Trim(dtConsultaImagenes.Rows(i).Item("FPIMNUFI"))) = Val(Trim(dtConsultaPredios.Rows(j1).Item("FIPRNUFI"))) Then
                            bySW = 1
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If

                    End While

                    ' encuentra la matricula
                    If bySW = 0 Then

                        dr1 = dt_ImagenesNoCrazanConFicha.NewRow()

                        dr1("Nro_Ficha") = Trim(dtConsultaImagenes.Rows(i).Item("FPIMNUFI"))
                        dr1("Nro_Construccion") = Trim(dtConsultaImagenes.Rows(i).Item("FPIMUNID"))
                        dr1("Nro_Foto") = Trim(dtConsultaImagenes.Rows(i).Item("FPIMNUFO"))
                        dr1("Ruta") = Trim(dtConsultaImagenes.Rows(i).Item("FPIMRUTA"))

                        dt_ImagenesNoCrazanConFicha.Rows.Add(dr1)

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    Me.pbPROCESO.Value = inProceso

                Next

                ' inicia la barra de progreso
                Me.pbPROCESO.Value = 0

                ' verifica el resultado
                If dt_ImagenesNoCrazanConFicha.Rows.Count > 0 Then

                    MessageBox.Show("Archivos de imagenes que no cruzaron con la Base de Datos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.dgvArchivosImagenesNoCruzan.DataSource = dt_ImagenesNoCrazanConFicha
                Else
                    MessageBox.Show("Cruce sin resultados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.dgvArchivosImagenesNoCruzan.DataSource = New DataTable

                End If

            Else
                MessageBox.Show("Existe tablas sin datos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvArchivosImagenesNoCruzan.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMOVER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMOVER.Click

        Try
            If Me.dgvArchivosImagenesNoCruzan.RowCount > 0 Then

                If Trim(Me.txtRutaDestino.Text) <> "" Then

                    Dim dtConsultaArchivosImagenes As New DataTable
                    dtConsultaArchivosImagenes = Me.dgvArchivosImagenesNoCruzan.DataSource
                    Dim stRutaDestino As String = fun_consultarRutaDestino()

                    Dim i As Integer = 0

                    For i = 0 To dtConsultaArchivosImagenes.Rows.Count - 1

                        Dim stFPIMNUFI As String = Trim(dtConsultaArchivosImagenes.Rows(i).Item("Nro_Ficha"))
                        Dim stFPIMUNID As String = Trim(dtConsultaArchivosImagenes.Rows(i).Item("Nro_Construccion"))
                        Dim stFPIMNUFO As String = Trim(dtConsultaArchivosImagenes.Rows(i).Item("Nro_Foto"))
                        Dim stFPIMRUTA As String = Trim(dtConsultaArchivosImagenes.Rows(i).Item("Ruta"))

                        If Me.chkMoverTodos.Checked = True Then

                            vl_stRutaInicial = Trim(stFPIMRUTA)
                            vl_stRutaDestino = stRutaDestino & stFPIMNUFI & "-" & stFPIMUNID & "-" & stFPIMNUFO & ".jpg"

                            pro_MoverDocumento(vl_stRutaInicial, vl_stRutaDestino)

                        End If

                    Next

                    MessageBox.Show("Se movieron los archivos correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                Else
                    MessageBox.Show("Seleccione la ruta destino", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                End If
            Else
                MessageBox.Show("No existen archivos cargados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub
    Private Sub cmdAbrirCarpeta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirCarpeta.Click

        Dim oCarpetas As New FolderBrowserDialog
        Dim stNewPath As String = ""

        oCarpetas.ShowDialog()
        stNewPath = oCarpetas.SelectedPath

        Me.txtRutaDestino.Text = stNewPath

    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click

        If Me.dgvArchivosImagenesNoCruzan.RowCount = 0 Then
            MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        Else
            Dim oExp As New cla_ExportarTablaExcel
            oExp.DataTableToExcel(CType(Me.dgvArchivosImagenesNoCruzan.DataSource, DataTable))
        End If

    End Sub
    Private Sub cmdImportarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImportarDatos.Click

        Try
            Me.dgvArchivosImagenesNoCruzan.DataSource = New DataTable

            ' enruta el archivo
            oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
            oLeer.Filter = "Archivo de texto (*.xls)|*.xls" 'Colocar varias extensiones
            oLeer.FilterIndex = 1 'coloca por defecto el *.txt
            oLeer.FileName = ""
            oLeer.ShowDialog()

            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim DtSet As System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

            MyConnection = New System.Data.OleDb.OleDbConnection _
            ("provider=Microsoft.Jet.OLEDB.4.0;" & _
            " Data Source='" & oLeer.FileName & "'; " & _
             "Extended Properties=Excel 8.0;")

            Dim stNombreLibro As String = InputBox("Ingrese el nombre de la hoja de excel", "Mensaje")

            If Trim(stNombreLibro) <> "" Then

                MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & stNombreLibro & "$]", MyConnection)

                MyCommand.TableMappings.Add("Table", "TestTable")
                DtSet = New System.Data.DataSet
                MyCommand.Fill(DtSet)

                Me.dgvArchivosImagenesNoCruzan.DataSource = DtSet.Tables(0)

                MyConnection.Close()

            Else
                stNombreLibro = InputBox("Ingrese el nombre de la hoja de excel", "Mensaje")
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvArchivosImagenesNoCruzan.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description)
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

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
    Private Sub cboOBINCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRUCFCLSE, Me.cboRUCFCLSE.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCARGAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUCFDEPA.GotFocus, cboRUCFMUNI.GotFocus, cboRUCFCLSE.GotFocus
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
    Private Sub cboOBINCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRUCFCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboRUCFCLSE, Me.cboRUCFCLSE.SelectedIndex)
    End Sub

#End Region

#End Region

End Class