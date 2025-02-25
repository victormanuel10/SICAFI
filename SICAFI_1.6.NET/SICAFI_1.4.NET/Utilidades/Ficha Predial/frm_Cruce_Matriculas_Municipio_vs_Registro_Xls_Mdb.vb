Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_Cruce_Matriculas_Municipio_vs_Registro_Xls_Mdb

    '============================================================
    '*** FORMULARIO CRUCE DE MATRICULAS MUNICIPIO VS REGISTRO ***
    '============================================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Cruce_Matriculas_Municipio_vs_Registro_Xls_Mdb
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Cruce_Matriculas_Municipio_vs_Registro_Xls_Mdb
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

    Dim oLeer As New OpenFileDialog

    ' crea los objetos datatable
    Dim dt_CargaMunicipio As New DataTable
    Dim dt_CargaRegistro As New DataTable

    Dim dt_MatriculasCruzaronMunicipioRegistro As New DataTable
    Dim dt_MatriculasMunicipioNoRegistro As New DataTable
    Dim dt_MatriculasRegistroNoMunicipio As New DataTable

    ' otros procesos
    Dim stRutaArchivoMunicipio As String
    Dim stRutaArchivoRegistro As String

    Dim inProceso As Integer = 0

    Dim inTotalRegistrosMunicipio As Integer = 0
    Dim inTotalRegistrosRegistro As Integer = 0

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.lblRutaMunicipio.Text = ""
        Me.lblRutaRegistro.Text = ""

        Me.dgvCargaMunicipio.DataSource = New DataTable
        Me.dgvCargaRegistro.DataSource = New DataTable

        Me.dgvMatriculasCruzanMunicipioRegistro.DataSource = New DataTable
        Me.dgvMatriculasMunicipioNoRegistro.DataSource = New DataTable
        Me.dgvMatriculasRegistroNoMunicipio.DataSource = New DataTable

        Me.cmdMatriculasCruzanMunicipioRegistro.Enabled = False
        Me.cmdMatriculasMunicipioNoRegistro.Enabled = False
        Me.cmdMatriculasRegistroNoMunicipio.Enabled = False

        Me.lblCantidadPrediosMunicipio.Text = "0"
        Me.lblCantidadPrediosRegistro.Text = "0"

        Me.strBARRESTA.Items(2).Text = "Registro : 0"

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAbrirArchivoMunicipio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivoMunicipio.Click

        Try
            Me.dgvCargaMunicipio.DataSource = New DataTable

            ' selecciona archivo de excel
            If Me.rbdArchivoMunicipioExcel.Checked = True Then

                ' declara variable
                inTotalRegistrosMunicipio = 0

                ' enruta el archivo
                oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
                oLeer.Filter = "Archivo de texto (*.xls)|*.xls" 'Colocar varias extensiones
                oLeer.FilterIndex = 1 'coloca por defecto el *.txt
                oLeer.FileName = ""
                oLeer.ShowDialog()

                stRutaArchivoMunicipio = Trim(oLeer.FileName)

                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

                MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & stRutaArchivoMunicipio & "'; Extended Properties=Excel 8.0;")

                Dim stNombreLibro As String = InputBox("Ingrese el nombre de la hoja de excel", "Mensaje")

                If Trim(stNombreLibro) <> "" Then

                    MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & stNombreLibro & "$]", MyConnection)

                    MyCommand.TableMappings.Add("Table", "TestTable")
                    DtSet = New System.Data.DataSet
                    MyCommand.Fill(DtSet)

                    Me.dgvCargaMunicipio.DataSource = DtSet.Tables(0)

                    Me.lblRutaMunicipio.Text = Trim(oLeer.FileName)

                    TabControl1.SelectTab(TabPage1)

                    inTotalRegistrosMunicipio = Me.dgvCargaMunicipio.RowCount

                    lblCantidadPrediosMunicipio.Text = inTotalRegistrosMunicipio

                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCargaMunicipio.RowCount

                    MyConnection.Close()

                Else
                    Me.lblRutaMunicipio.Text = ""
                    Me.lblCantidadPrediosMunicipio.Text = "0"
                End If



                ' selecciona el archivo de access
            ElseIf Me.rbdArchivoMunicipioAccess.Checked = True Then

                ' declara variable
                inTotalRegistrosMunicipio = 0

                ' enruta el archivo
                oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
                oLeer.Filter = "Archivo de texto (*.mdb)|*.mdb" 'Colocar varias extensiones
                oLeer.FilterIndex = 1 'coloca por defecto el *.txt
                oLeer.FileName = ""
                oLeer.ShowDialog()

                stRutaArchivoMunicipio = Trim(oLeer.FileName)

                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

                MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & stRutaArchivoMunicipio & "'")

                Dim stNombreLibro As String = InputBox("Ingrese el nombre de la tabla de access", "Mensaje")

                If Trim(stNombreLibro) <> "" Then

                    MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & stNombreLibro & "]", MyConnection)

                    MyCommand.TableMappings.Add("Table", "TestTable")
                    DtSet = New System.Data.DataSet
                    MyCommand.Fill(DtSet)

                    Me.dgvCargaMunicipio.DataSource = DtSet.Tables(0)

                    Me.lblRutaMunicipio.Text = Trim(oLeer.FileName)

                    TabControl1.SelectTab(TabPage1)

                    inTotalRegistrosMunicipio = Me.dgvCargaMunicipio.RowCount

                    lblCantidadPrediosMunicipio.Text = inTotalRegistrosMunicipio

                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCargaMunicipio.RowCount

                    MyConnection.Close()

                Else
                    Me.lblRutaMunicipio.Text = ""
                    Me.lblCantidadPrediosMunicipio.Text = "0"
                End If

            End If

        Catch ex As Exception
            Me.lblRutaMunicipio.Text = ""
            Me.lblCantidadPrediosMunicipio.Text = "0"
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdAbrirArchivoRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivoRegistro.Click

        Try

            Me.dgvCargaRegistro.DataSource = New DataTable

            ' selecciona archivo de excel
            If Me.rbdArchivoRegistroExcel.Checked = True Then

                ' declara variable
                inTotalRegistrosRegistro = 0

                ' enruta el archivo
                oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
                oLeer.Filter = "Archivo de texto (*.xls)|*.xls" 'Colocar varias extensiones
                oLeer.FilterIndex = 1 'coloca por defecto el *.txt
                oLeer.FileName = ""
                oLeer.ShowDialog()

                stRutaArchivoRegistro = Trim(oLeer.FileName)

                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

                MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & stRutaArchivoRegistro & "'; Extended Properties=Excel 8.0;")

                Dim stNombreLibro As String = InputBox("Ingrese el nombre de la hoja de excel", "Mensaje")

                If Trim(stNombreLibro) <> "" Then

                    MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & stNombreLibro & "$]", MyConnection)

                    MyCommand.TableMappings.Add("Table", "TestTable")
                    DtSet = New System.Data.DataSet
                    MyCommand.Fill(DtSet)

                    Me.dgvCargaRegistro.DataSource = DtSet.Tables(0)

                    Me.lblRutaRegistro.Text = Trim(oLeer.FileName)

                    Me.TabControl1.SelectTab(TabPage2)

                    inTotalRegistrosRegistro = Me.dgvCargaRegistro.RowCount

                    Me.lblCantidadPrediosRegistro.Text = inTotalRegistrosRegistro

                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCargaRegistro.RowCount

                    MyConnection.Close()

                Else
                    Me.lblRutaRegistro.Text = ""
                    Me.lblCantidadPrediosRegistro.Text = "0"
                End If



                ' selecciona el archivo de access
            ElseIf Me.rbdArchivoRegistroAccess.Checked = True Then

                ' declara variable
                inTotalRegistrosRegistro = 0

                ' enruta el archivo
                oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
                oLeer.Filter = "Archivo de texto (*.mdb)|*.mdb" 'Colocar varias extensiones
                oLeer.FilterIndex = 1 'coloca por defecto el *.txt
                oLeer.FileName = ""
                oLeer.ShowDialog()

                stRutaArchivoRegistro = Trim(oLeer.FileName)

                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

                MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & stRutaArchivoMunicipio & "'")

                Dim stNombreLibro As String = InputBox("Ingrese el nombre de la tabla de access", "Mensaje")

                If Trim(stNombreLibro) <> "" Then

                    MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & stNombreLibro & "]", MyConnection)

                    MyCommand.TableMappings.Add("Table", "TestTable")
                    DtSet = New System.Data.DataSet
                    MyCommand.Fill(DtSet)

                    Me.dgvCargaRegistro.DataSource = DtSet.Tables(0)

                    Me.lblRutaRegistro.Text = Trim(oLeer.FileName)

                    TabControl1.SelectTab(TabPage2)

                    inTotalRegistrosRegistro = Me.dgvCargaRegistro.RowCount

                    lblCantidadPrediosRegistro.Text = inTotalRegistrosRegistro

                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCargaRegistro.RowCount

                    MyConnection.Close()

                Else
                    Me.lblRutaRegistro.Text = ""
                    Me.lblCantidadPrediosRegistro.Text = "0"
                End If

            End If

        Catch ex As Exception
            Me.lblRutaRegistro.Text = ""
            Me.lblCantidadPrediosRegistro.Text = "0"
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        Try
            If rbdCargaMunicipio.Checked = True Then

                If Me.dgvCargaMunicipio.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvCargaMunicipio.DataSource, DataTable))
                End If

            ElseIf rbdCargaRegistro.Checked = True Then

                If Me.dgvCargaRegistro.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvCargaRegistro.DataSource, DataTable))
                End If

            ElseIf rbdMatriculasCruzanMunicipioRegistro.Checked = True Then

                If Me.dgvMatriculasCruzanMunicipioRegistro.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvMatriculasCruzanMunicipioRegistro.DataSource, DataTable))
                End If

            ElseIf rbdMatriculasMunicipioNoRegistro.Checked = True Then

                If Me.dgvMatriculasMunicipioNoRegistro.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvMatriculasMunicipioNoRegistro.DataSource, DataTable))
                End If

            ElseIf rbdMatriculasRegistroNoMunicipio.Checked = True Then

                If Me.dgvMatriculasRegistroNoMunicipio.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvMatriculasRegistroNoMunicipio.DataSource, DataTable))
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

    Private Sub cmdMatriculasCruzanMunicipioRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMatriculasCruzanMunicipioRegistro.Click

        Try
            ' Cruce municipio vs departamento
            If Me.dgvCargaMunicipio.RowCount > 0 And Me.dgvCargaRegistro.RowCount > 0 Then

                ' crea las tablas
                dt_CargaMunicipio = New DataTable
                dt_CargaRegistro = New DataTable

                ' carga las tablas
                dt_CargaMunicipio = Me.dgvCargaMunicipio.DataSource
                dt_CargaRegistro = Me.dgvCargaRegistro.DataSource

                ' apaga los comandos
                Me.cmdMatriculasCruzanMunicipioRegistro.Enabled = False
                Me.cmdMatriculasMunicipioNoRegistro.Enabled = False
                Me.cmdMatriculasRegistroNoMunicipio.Enabled = False

                ' Valores predeterminados ProgressBar
                inProceso = 0
                pbPROCESO.Value = 0
                pbPROCESO.Maximum = dt_CargaMunicipio.Rows.Count + 1
                Timer1.Enabled = True

                ' declaración de variables
                Dim stMUNIMATR As String = ""
                Dim stMUNICLSE As String = ""
                Dim stREGIMATR As String = ""
                Dim stREGICLSE As String = ""
                
                ' Crea objeto registros
                Dim dr1 As DataRow

                ' crea la tabla
                dt_MatriculasCruzaronMunicipioRegistro = New DataTable

                ' Crea las columnas
                dt_MatriculasCruzaronMunicipioRegistro.Columns.Add(New DataColumn("Matricula_Municipio", GetType(String)))
                dt_MatriculasCruzaronMunicipioRegistro.Columns.Add(New DataColumn("Sector_Municipio", GetType(String)))
                dt_MatriculasCruzaronMunicipioRegistro.Columns.Add(New DataColumn("Matricula_Registro", GetType(String)))
                dt_MatriculasCruzaronMunicipioRegistro.Columns.Add(New DataColumn("Sector_Registro", GetType(String)))

                Dim i As Integer = 0

                ' Recorro la tabla del municipio
                For i = 0 To dt_CargaMunicipio.Rows.Count - 1

                    ' limpias las varaibles
                    stMUNIMATR = ""
                    stMUNICLSE = ""
                    stREGIMATR = ""
                    stREGICLSE = ""

                    ' carga la variable
                    stMUNIMATR = Trim(dt_CargaMunicipio.Rows(i).Item(0))
                    stMUNICLSE = Trim(dt_CargaMunicipio.Rows(i).Item(1))

                    Dim sw1 As Byte = 0
                    Dim j1 As Integer = 0
                    Dim bySW As Byte = 0

                    While j1 < dt_CargaRegistro.Rows.Count And sw1 = 0

                        If Val(Trim(dt_CargaMunicipio.Rows(i).Item(0))) = Val(Trim(dt_CargaRegistro.Rows(j1).Item(0))) Then

                            ' carga la variable
                            stREGIMATR = Trim(dt_CargaRegistro.Rows(j1).Item(0))
                            stREGICLSE = Trim(dt_CargaRegistro.Rows(j1).Item(1))

                            bySW = 1
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If

                    End While

                    ' encuentra la matricula
                    If bySW = 1 Then

                        dr1 = dt_MatriculasCruzaronMunicipioRegistro.NewRow()

                        dr1("Matricula_Municipio") = stMUNIMATR
                        dr1("Sector_Municipio") = stMUNICLSE
                        dr1("Matricula_Registro") = stREGIMATR
                        dr1("Sector_Registro") = stREGICLSE

                        dt_MatriculasCruzaronMunicipioRegistro.Rows.Add(dr1)

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbPROCESO.Value = inProceso

                Next

                ' inicia la barra de progreso
                pbPROCESO.Value = 0

                ' verifica el resultado
                If dt_MatriculasCruzaronMunicipioRegistro.Rows.Count > 0 Then

                    MessageBox.Show("Cruce con resultados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.dgvMatriculasCruzanMunicipioRegistro.DataSource = dt_MatriculasCruzaronMunicipioRegistro

                Else
                    MessageBox.Show("Cruce sin resultados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.dgvMatriculasCruzanMunicipioRegistro.DataSource = New DataTable

                End If

                ' prende los comandos
                Me.cmdMatriculasCruzanMunicipioRegistro.Enabled = True
                Me.cmdMatriculasMunicipioNoRegistro.Enabled = True
                Me.cmdMatriculasRegistroNoMunicipio.Enabled = True

                Me.TabControl1.SelectTab(TabPage3)

            Else
                MessageBox.Show("Existe tablas sin datos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvMatriculasCruzanMunicipioRegistro.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMatriculasMunicipioNoRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMatriculasMunicipioNoRegistro.Click

        Try
            ' Cruce municipio vs departamento
            If Me.dgvCargaMunicipio.RowCount > 0 And Me.dgvCargaRegistro.RowCount > 0 Then

                ' crea las tablas
                dt_CargaMunicipio = New DataTable
                dt_CargaRegistro = New DataTable

                ' carga las tablas
                dt_CargaMunicipio = Me.dgvCargaMunicipio.DataSource
                dt_CargaRegistro = Me.dgvCargaRegistro.DataSource

                ' apaga los comandos
                Me.cmdMatriculasCruzanMunicipioRegistro.Enabled = False
                Me.cmdMatriculasMunicipioNoRegistro.Enabled = False
                Me.cmdMatriculasRegistroNoMunicipio.Enabled = False

                ' Valores predeterminados ProgressBar
                inProceso = 0
                pbPROCESO.Value = 0
                pbPROCESO.Maximum = dt_CargaMunicipio.Rows.Count + 1
                Timer1.Enabled = True

                ' declaración de variables
                Dim stMUNIMATR As String = ""
                Dim stMUNICLSE As String = ""

                ' Crea objeto registros
                Dim dr1 As DataRow

                ' crea la tabla
                dt_MatriculasMunicipioNoRegistro = New DataTable

                ' Crea las columnas
                dt_MatriculasMunicipioNoRegistro.Columns.Add(New DataColumn("Matricula_Municipio", GetType(String)))
                dt_MatriculasMunicipioNoRegistro.Columns.Add(New DataColumn("Sector_Municipio", GetType(String)))

                Dim i As Integer = 0

                ' Recorro la tabla del municipio
                For i = 0 To dt_CargaMunicipio.Rows.Count - 1

                    ' limpias las varaibles
                    stMUNIMATR = ""
                    stMUNICLSE = ""

                    ' carga la variable
                    stMUNIMATR = Trim(dt_CargaMunicipio.Rows(i).Item(0))
                    stMUNICLSE = Trim(dt_CargaMunicipio.Rows(i).Item(1))

                    Dim sw1 As Byte = 0
                    Dim j1 As Integer = 0
                    Dim bySW As Byte = 0

                    While j1 < dt_CargaRegistro.Rows.Count And sw1 = 0

                        If Val(Trim(dt_CargaMunicipio.Rows(i).Item(0))) = Val(Trim(dt_CargaRegistro.Rows(j1).Item(0))) Then

                            bySW = 1
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If

                    End While

                    ' encuentra la matricula
                    If bySW = 0 Then

                        dr1 = dt_MatriculasMunicipioNoRegistro.NewRow()

                        dr1("Matricula_Municipio") = stMUNIMATR
                        dr1("Sector_Municipio") = stMUNICLSE

                        dt_MatriculasMunicipioNoRegistro.Rows.Add(dr1)

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbPROCESO.Value = inProceso

                Next

                ' inicia la barra de progreso
                pbPROCESO.Value = 0

                ' verifica el resultado
                If dt_MatriculasMunicipioNoRegistro.Rows.Count > 0 Then

                    MessageBox.Show("Cruce con resultados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.dgvMatriculasMunicipioNoRegistro.DataSource = dt_MatriculasMunicipioNoRegistro

                Else
                    MessageBox.Show("Cruce sin resultados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.dgvMatriculasMunicipioNoRegistro.DataSource = New DataTable

                End If

                ' prende los comandos
                Me.cmdMatriculasCruzanMunicipioRegistro.Enabled = True
                Me.cmdMatriculasMunicipioNoRegistro.Enabled = True
                Me.cmdMatriculasRegistroNoMunicipio.Enabled = True

                Me.TabControl1.SelectTab(TabPage4)

            Else
                MessageBox.Show("Existe tablas sin datos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvMatriculasCruzanMunicipioRegistro.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMatriculasRegistroNoMunicipio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMatriculasRegistroNoMunicipio.Click

        Try
            ' Cruce municipio vs departamento
            If Me.dgvCargaMunicipio.RowCount > 0 And Me.dgvCargaRegistro.RowCount > 0 Then

                ' crea las tablas
                dt_CargaMunicipio = New DataTable
                dt_CargaRegistro = New DataTable

                ' carga las tablas
                dt_CargaMunicipio = Me.dgvCargaMunicipio.DataSource
                dt_CargaRegistro = Me.dgvCargaRegistro.DataSource

                ' apaga los comandos
                Me.cmdMatriculasCruzanMunicipioRegistro.Enabled = False
                Me.cmdMatriculasMunicipioNoRegistro.Enabled = False
                Me.cmdMatriculasRegistroNoMunicipio.Enabled = False

                ' Valores predeterminados ProgressBar
                inProceso = 0
                pbPROCESO.Value = 0
                pbPROCESO.Maximum = dt_CargaRegistro.Rows.Count + 1
                Timer1.Enabled = True

                ' declaración de variables
                Dim stREGIMATR As String = ""
                Dim stREGICLSE As String = ""

                ' Crea objeto registros
                Dim dr1 As DataRow

                ' crea la tabla
                dt_MatriculasRegistroNoMunicipio = New DataTable

                ' Crea las columnas
                dt_MatriculasRegistroNoMunicipio.Columns.Add(New DataColumn("Matricula_Registro", GetType(String)))
                dt_MatriculasRegistroNoMunicipio.Columns.Add(New DataColumn("Sector_Registro", GetType(String)))

                Dim i As Integer = 0

                ' Recorro la tabla del municipio
                For i = 0 To dt_CargaRegistro.Rows.Count - 1

                    ' limpias las varaibles
                    stREGIMATR = ""
                    stREGICLSE = ""

                    ' carga la variable
                    stREGIMATR = Trim(dt_CargaRegistro.Rows(i).Item(0))
                    stREGICLSE = Trim(dt_CargaRegistro.Rows(i).Item(1))

                    Dim sw1 As Byte = 0
                    Dim j1 As Integer = 0
                    Dim bySW As Byte = 0

                    While j1 < dt_CargaMunicipio.Rows.Count And sw1 = 0

                        If Val(Trim(dt_CargaRegistro.Rows(i).Item(0))) = Val(Trim(dt_CargaMunicipio.Rows(j1).Item(0))) Then

                            bySW = 1
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If

                    End While

                    ' encuentra la matricula
                    If bySW = 0 Then

                        dr1 = dt_MatriculasRegistroNoMunicipio.NewRow()

                        dr1("Matricula_Registro") = stREGIMATR
                        dr1("Sector_Registro") = stREGICLSE

                        dt_MatriculasRegistroNoMunicipio.Rows.Add(dr1)

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbPROCESO.Value = inProceso

                Next

                ' inicia la barra de progreso
                pbPROCESO.Value = 0

                ' verifica el resultado
                If dt_MatriculasRegistroNoMunicipio.Rows.Count > 0 Then

                    MessageBox.Show("Cruce con resultados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.dgvMatriculasRegistroNoMunicipio.DataSource = dt_MatriculasRegistroNoMunicipio

                Else
                    MessageBox.Show("Cruce sin resultados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.dgvMatriculasRegistroNoMunicipio.DataSource = New DataTable

                End If

                ' prende los comandos
                Me.cmdMatriculasCruzanMunicipioRegistro.Enabled = True
                Me.cmdMatriculasMunicipioNoRegistro.Enabled = True
                Me.cmdMatriculasRegistroNoMunicipio.Enabled = True

                Me.TabControl1.SelectTab(TabPage5)

            Else
                MessageBox.Show("Existe tablas sin datos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvMatriculasRegistroNoMunicipio.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.strBARRESTA.Items(0).Text = "Cruce de matriculas"
        Me.strBARRESTA.Items(2).Text = "Registros: 0"

        pro_LimpiarCampos()
    End Sub

#End Region

#Region "TextChanged"

    Private Sub lblRutaMunicipio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblRutaMunicipio.TextChanged

        If Trim(Me.lblRutaMunicipio.Text) <> "" And Trim(Me.lblRutaRegistro.Text) <> "" And Me.dgvCargaMunicipio.RowCount > 0 And Me.dgvCargaRegistro.RowCount > 0 Then

            Me.cmdMatriculasCruzanMunicipioRegistro.Enabled = True
            Me.cmdMatriculasMunicipioNoRegistro.Enabled = True
            Me.cmdMatriculasRegistroNoMunicipio.Enabled = True
        Else
            Me.cmdMatriculasCruzanMunicipioRegistro.Enabled = False
            Me.cmdMatriculasMunicipioNoRegistro.Enabled = False
            Me.cmdMatriculasRegistroNoMunicipio.Enabled = False

        End If

    End Sub
    Private Sub lblRutaRegistro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblRutaRegistro.TextChanged

        If Trim(Me.lblRutaMunicipio.Text) <> "" And Trim(Me.lblRutaRegistro.Text) <> "" And Me.dgvCargaMunicipio.RowCount > 0 And Me.dgvCargaRegistro.RowCount > 0 Then

            Me.cmdMatriculasCruzanMunicipioRegistro.Enabled = True
            Me.cmdMatriculasMunicipioNoRegistro.Enabled = True
            Me.cmdMatriculasRegistroNoMunicipio.Enabled = True
        Else
            Me.cmdMatriculasCruzanMunicipioRegistro.Enabled = False
            Me.cmdMatriculasMunicipioNoRegistro.Enabled = False
            Me.cmdMatriculasRegistroNoMunicipio.Enabled = False

        End If

    End Sub

#End Region

#End Region


End Class