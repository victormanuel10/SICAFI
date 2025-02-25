Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_CruceDeTablas

    '=======================
    '*** CRUCE DE TABLAS ***
    '=======================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_CruceDeTablas
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_CruceDeTablas
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

    ' crea las variables de conexion
    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private ds As New DataSet
    Private dt As New DataTable

    ' crea el objeto para abrir el archivo
    Dim oLeer As New OpenFileDialog

    ' crea los objetos datatable
    Dim dt_CargaListadoPrincipal As New DataTable
    Dim dt_CargaListadoSecundario As New DataTable
    Dim dt_CargaCruceDatos As New DataTable

    ' otros procesos
    Dim inProceso As Integer = 0

    Dim inTotalRegistrosListadoPrincipal As Integer = 0
    Dim inTotalRegistrosListadoSecundario As Integer = 0

    Dim stRutaArchivoPrincipal As String = ""
    Dim stRutaArchivoSecundario As String = ""

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.lblRutaArchivoPrincipal.Text = ""
        Me.lblRutaArchivoSecundario.Text = ""
        Me.lblCantidadDatosPrincipal.Text = ""
        Me.lblCantidadDatosSecundarios.Text = ""
        Me.lblCantidadDeDiferencia.Text = ""
        Me.lblCantidadSiCruzaron.Text = ""
        Me.lblCantidadNoCruzaron.Text = ""

        Me.dgvListadoPrincipal.DataSource = New DataTable
        Me.dgvListadoSecundario.DataSource = New DataTable
        Me.dgvInconsistencia.DataSource = New DataTable
        Me.dgvCruceDatos.DataSource = New DataTable

        Me.strBARRESTA.Items(2).Text = "Registro : 0"

        Me.cmdCruceDeDatos.Enabled = False
        Me.cmdValidaDatos.Enabled = False
        Me.chkConcatenar.Checked = False

    End Sub
    Private Sub pro_ControlDeBotones()

        If Me.dgvListadoPrincipal.RowCount > 0 And Me.dgvListadoSecundario.RowCount > 0 Then
            Me.cmdValidaDatos.Enabled = True
            Me.cmdCruceDeDatos.Enabled = False
        Else
            Me.cmdValidaDatos.Enabled = False
        End If

    End Sub
    Private Sub pro_ValidarCampos()

        Try
            ' limpia los datagrigview
            Me.dgvInconsistencia.DataSource = New DataTable

            ' Valores predeterminados ProgressBar
            inProceso = 0
            pbPROCESO.Value = 0
            pbPROCESO.Maximum = Me.dgvListadoPrincipal.RowCount + Me.dgvListadoSecundario.RowCount + 1
            Timer1.Enabled = True

            ' Crea objeto de columnas y registros
            Dim dt1 As New DataTable
            Dim dr1 As DataRow

            ' Crea las columnas
            dt1.Columns.Add(New DataColumn("Listado", GetType(String)))
            dt1.Columns.Add(New DataColumn("Inconsistencia", GetType(String)))

            ' crea la variable
            Dim i As Integer = 0

            ' crea la tabla
            dt_CargaListadoPrincipal = New DataTable

            ' carga la tabla
            dt_CargaListadoPrincipal = Me.dgvListadoPrincipal.DataSource

            For i = 0 To dt_CargaListadoPrincipal.Rows.Count - 1

                ' verifica que el campo Municipio
                If Trim(dt_CargaListadoPrincipal.Rows(i).Item(0).ToString) = "" Then

                    dr1 = dt1.NewRow()

                    dr1("Listado") = "Listado Principal"
                    dr1("Inconsistencia") = "Campo código en blanco"

                    dt1.Rows.Add(dr1)

                End If

                ' Incrementa la barra
                inProceso = inProceso + 1
                pbPROCESO.Value = inProceso

            Next

            ' crea la variable
            Dim k As Integer = 0

            ' crea la tabla
            dt_CargaListadoSecundario = New DataTable

            ' carga la tabla
            dt_CargaListadoSecundario = Me.dgvListadoSecundario.DataSource

            For k = 0 To dt_CargaListadoSecundario.Rows.Count - 1

                ' verifica que el campo Municipio
                If Trim(dt_CargaListadoSecundario.Rows(k).Item(0).ToString) = "" Or Trim(dt_CargaListadoSecundario.Rows(k).Item(0).ToString) Is Nothing Then

                    dr1 = dt1.NewRow()

                    dr1("Listado") = "Listado Secundario"
                    dr1("Inconsistencia") = "Campo Código en blanco"

                    dt1.Rows.Add(dr1)

                End If

                ' Incrementa la barra
                inProceso = inProceso + 1
                pbPROCESO.Value = inProceso

            Next

            ' Llena el datagrigview
            Me.dgvInconsistencia.DataSource = dt1


            pbPROCESO.Value = 0

            ' comando grabar datos
            If dt1.Rows.Count = 0 Then
                Me.cmdCruceDeDatos.Enabled = True
                Me.cmdValidaDatos.Enabled = False
                Me.cmdCruceDeDatos.Focus()
                MessageBox.Show("Proceso de validación terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                Me.cmdValidaDatos.Enabled = True
                MessageBox.Show("Proceso de validación inconsistente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                TabControl1.SelectTab(TabInconsistencias)
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvInconsistencia.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdValidaDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValidaDatos.Click

        Try
            ' apaga los comandos
            Me.cmdValidaDatos.Enabled = False
            Me.cmdCruceDeDatos.Enabled = False

            If Me.dgvListadoPrincipal.RowCount > 0 Then

                pro_ValidarCampos()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdAbrirArchivoPrincipal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivoPrincipal.Click

        Try
            Me.dgvListadoPrincipal.DataSource = New DataTable
            Me.dgvCruceDatos.DataSource = New DataTable
            Me.dgvInconsistencia.DataSource = New DataTable

            Me.cmdCruceDeDatos.Enabled = False

            ' selecciona archivo de excel
            If Me.rbdArchivoExcel.Checked = True Then

                ' declara variable
                inTotalRegistrosListadoPrincipal = 0

                ' enruta el archivo
                oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
                oLeer.Filter = "Archivo de texto (*.xls)|*.xls" 'Colocar varias extensiones
                oLeer.FilterIndex = 1 'coloca por defecto el *.txt
                oLeer.FileName = ""
                oLeer.ShowDialog()

                stRutaArchivoPrincipal = Trim(oLeer.FileName)

                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

                MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & stRutaArchivoPrincipal & "'; Extended Properties=Excel 8.0;")

                Dim stNombreLibro As String = InputBox("Ingrese el nombre de la hoja de excel", "Mensaje")

                If Trim(stNombreLibro) <> "" Then

                    MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & stNombreLibro & "$]", MyConnection)

                    MyCommand.TableMappings.Add("Table", "TestTable")
                    DtSet = New System.Data.DataSet
                    MyCommand.Fill(DtSet)

                    Me.dgvListadoPrincipal.DataSource = DtSet.Tables(0)

                    Me.lblRutaArchivoPrincipal.Text = Trim(oLeer.FileName)

                    Me.TabControl1.SelectTab(tabListadoPrincipal)

                    inTotalRegistrosListadoPrincipal = Me.dgvListadoPrincipal.RowCount

                    Me.lblCantidadDatosPrincipal.Text = inTotalRegistrosListadoPrincipal

                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvListadoPrincipal.RowCount

                    MyConnection.Close()

                Else
                    Me.lblRutaArchivoPrincipal.Text = ""
                    Me.lblCantidadDatosPrincipal.Text = "0"
                End If



                ' selecciona el archivo de access
            ElseIf Me.rbdArchivoAccess.Checked = True Then

                ' declara variable
                inTotalRegistrosListadoPrincipal = 0

                ' enruta el archivo
                oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
                oLeer.Filter = "Archivo de texto (*.mdb)|*.mdb" 'Colocar varias extensiones
                oLeer.FilterIndex = 1 'coloca por defecto el *.txt
                oLeer.FileName = ""
                oLeer.ShowDialog()

                stRutaArchivoPrincipal = Trim(oLeer.FileName)

                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

                MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & stRutaArchivoPrincipal & "'")

                Dim stNombreLibro As String = InputBox("Ingrese el nombre de la tabla de access", "Mensaje")

                If Trim(stNombreLibro) <> "" Then

                    MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & stNombreLibro & "]", MyConnection)

                    MyCommand.TableMappings.Add("Table", "TestTable")
                    DtSet = New System.Data.DataSet
                    MyCommand.Fill(DtSet)

                    Me.dgvListadoPrincipal.DataSource = DtSet.Tables(0)

                    Me.lblRutaArchivoPrincipal.Text = Trim(oLeer.FileName)

                    Me.TabControl1.SelectTab(tabListadoPrincipal)

                    inTotalRegistrosListadoPrincipal = Me.dgvListadoPrincipal.RowCount

                    Me.lblCantidadDatosPrincipal.Text = inTotalRegistrosListadoPrincipal

                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvListadoPrincipal.RowCount

                    MyConnection.Close()

                Else
                    Me.lblRutaArchivoPrincipal.Text = ""
                    Me.lblCantidadDatosPrincipal.Text = "0"
                End If

            End If

            pro_ControlDeBotones()

        Catch ex As Exception
            Me.lblRutaArchivoPrincipal.Text = ""
            Me.lblRutaArchivoSecundario.Text = ""
            Me.lblCantidadDatosPrincipal.Text = "0"
            Me.lblCantidadDatosSecundarios.Text = "0"
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdAbrirArchivoSecundario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivoSecundario.Click

        Try
            Me.dgvListadoSecundario.DataSource = New DataTable
            Me.dgvCruceDatos.DataSource = New DataTable
            Me.dgvInconsistencia.DataSource = New DataTable

            Me.cmdCruceDeDatos.Enabled = False

            ' selecciona archivo de excel
            If Me.rbdArchivoExcel.Checked = True Then

                ' declara variable
                inTotalRegistrosListadoSecundario = 0

                ' enruta el archivo
                oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
                oLeer.Filter = "Archivo de texto (*.xls)|*.xls" 'Colocar varias extensiones
                oLeer.FilterIndex = 1 'coloca por defecto el *.txt
                oLeer.FileName = ""
                oLeer.ShowDialog()

                stRutaArchivoSecundario = Trim(oLeer.FileName)

                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

                MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & stRutaArchivoSecundario & "'; Extended Properties=Excel 8.0;")

                Dim stNombreLibro As String = InputBox("Ingrese el nombre de la hoja de excel", "Mensaje")

                If Trim(stNombreLibro) <> "" Then

                    MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & stNombreLibro & "$]", MyConnection)

                    MyCommand.TableMappings.Add("Table", "TestTable")
                    DtSet = New System.Data.DataSet
                    MyCommand.Fill(DtSet)

                    Me.dgvListadoSecundario.DataSource = DtSet.Tables(0)

                    Me.lblRutaArchivoSecundario.Text = Trim(oLeer.FileName)

                    Me.TabControl1.SelectTab(TabListadoSecundario)

                    inTotalRegistrosListadoSecundario = Me.dgvListadoSecundario.RowCount

                    Me.lblCantidadDatosSecundarios.Text = inTotalRegistrosListadoSecundario

                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvListadoSecundario.RowCount

                    MyConnection.Close()

                Else
                    Me.lblRutaArchivoSecundario.Text = ""
                    Me.lblCantidadDatosSecundarios.Text = "0"
                End If



                ' selecciona el archivo de access
            ElseIf Me.rbdArchivoAccess.Checked = True Then

                ' declara variable
                inTotalRegistrosListadoSecundario = 0

                ' enruta el archivo
                oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
                oLeer.Filter = "Archivo de texto (*.mdb)|*.mdb" 'Colocar varias extensiones
                oLeer.FilterIndex = 1 'coloca por defecto el *.txt
                oLeer.FileName = ""
                oLeer.ShowDialog()

                stRutaArchivoSecundario = Trim(oLeer.FileName)

                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

                MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & stRutaArchivoSecundario & "'")

                Dim stNombreLibro As String = InputBox("Ingrese el nombre de la tabla de access", "Mensaje")

                If Trim(stNombreLibro) <> "" Then

                    MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & stNombreLibro & "]", MyConnection)

                    MyCommand.TableMappings.Add("Table", "TestTable")
                    DtSet = New System.Data.DataSet
                    MyCommand.Fill(DtSet)

                    Me.dgvListadoSecundario.DataSource = DtSet.Tables(0)

                    Me.lblRutaArchivoSecundario.Text = Trim(oLeer.FileName)

                    Me.TabControl1.SelectTab(TabListadoSecundario)

                    inTotalRegistrosListadoSecundario = Me.dgvListadoSecundario.RowCount

                    Me.lblCantidadDatosSecundarios.Text = inTotalRegistrosListadoSecundario

                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvListadoSecundario.RowCount

                    MyConnection.Close()

                Else
                    Me.lblRutaArchivoSecundario.Text = ""
                    Me.lblCantidadDatosSecundarios.Text = "0"
                End If

            End If

            pro_ControlDeBotones()

        Catch ex As Exception
            Me.lblRutaArchivoPrincipal.Text = ""
            Me.lblRutaArchivoSecundario.Text = ""
            Me.lblCantidadDatosPrincipal.Text = "0"
            Me.lblCantidadDatosSecundarios.Text = "0"
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCruceDeDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCruceDeDatos.Click

        Try
            ' limpia las tablas
            dt_CargaListadoPrincipal = New DataTable
            dt_CargaListadoSecundario = New DataTable

            ' llena las tablas
            dt_CargaListadoPrincipal = Me.dgvListadoPrincipal.DataSource
            dt_CargaListadoSecundario = Me.dgvListadoSecundario.DataSource

            ' verifica que existan registros
            If dt_CargaListadoPrincipal.Rows.Count > 0 And dt_CargaListadoSecundario.Rows.Count > 0 Then

                ' Crea objeto registros
                Dim dr1 As DataRow

                ' crea la tabla
                dt_CargaCruceDatos = New DataTable

                Dim inContadorCruce As Integer = 0

                Dim inContadorColumnasPrincipal As Integer = Me.dgvListadoPrincipal.ColumnCount
                Dim inContadorColumnasSecundario As Integer = Me.dgvListadoSecundario.ColumnCount

                dt_CargaCruceDatos.Columns.Add(New DataColumn("DatoPrincipal", GetType(String)))

                Dim j As Integer = 0

                For j = 0 To inContadorColumnasSecundario - 1

                    ' Crea las columnas
                    dt_CargaCruceDatos.Columns.Add(New DataColumn(Me.dgvListadoSecundario.Columns(j).HeaderText, GetType(String)))

                Next

                ' crea las columnas para la concatenacion
                If Me.chkConcatenar.Checked = True Then

                    Dim jj As Integer = 0

                    For jj = 0 To inContadorColumnasPrincipal - 1

                        ' Crea las columnas
                        dt_CargaCruceDatos.Columns.Add(New DataColumn(Me.dgvListadoPrincipal.Columns(jj).HeaderText, GetType(String)))

                    Next

                End If

                ' Valores predeterminados ProgressBar
                inProceso = 0
                pbPROCESO.Value = 0
                pbPROCESO.Maximum = dt_CargaListadoPrincipal.Rows.Count + 1
                Timer1.Enabled = True

                Dim stDatoPrincipal As String = ""
                Dim stDatoSecundario As String = ""

                ' declaro la variable
                Dim i As Integer = 0

                ' recorro la tabla
                For i = 0 To dt_CargaListadoPrincipal.Rows.Count - 1

                    stDatoPrincipal = CType(Trim(dt_CargaListadoPrincipal.Rows(i).Item(0).ToString), String)

                    Dim sw1 As Byte = 0
                    Dim j1 As Integer = 0
                    Dim bySW As Byte = 0
                    Dim boEncuentraRegistro As Boolean = False

                    While j1 < dt_CargaListadoSecundario.Rows.Count And sw1 = 0

                        stDatoSecundario = CType(Trim(dt_CargaListadoSecundario.Rows(j1).Item(0).ToString), String)

                        If stDatoPrincipal = stDatoSecundario Then

                            boEncuentraRegistro = True

                            inContadorCruce += 1

                            dr1 = dt_CargaCruceDatos.NewRow()

                            dr1("DatoPrincipal") = stDatoPrincipal

                            Dim h As Integer = 0

                            For h = 0 To inContadorColumnasSecundario - 1

                                dr1(Me.dgvListadoSecundario.Columns(h).HeaderText) = CType(Trim(dt_CargaListadoSecundario.Rows(j1).Item(h).ToString), String)

                            Next

                            ' crea las columnas para la concatenacion
                            If Me.chkConcatenar.Checked = True Then

                                Dim hh As Integer = 0

                                For hh = 0 To inContadorColumnasPrincipal - 1

                                    dr1(Me.dgvListadoPrincipal.Columns(hh).HeaderText) = CType(Trim(dt_CargaListadoPrincipal.Rows(j1).Item(hh).ToString), String)

                                Next

                            End If

                            dt_CargaCruceDatos.Rows.Add(dr1)

                            bySW = 1
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If

                    End While

                    ' verifica si encontro el registro
                    If boEncuentraRegistro = False Then

                        dr1 = dt_CargaCruceDatos.NewRow()

                        dr1("DatoPrincipal") = stDatoPrincipal

                        Dim h As Integer = 0

                        For h = 0 To inContadorColumnasSecundario - 1

                            dr1(Me.dgvListadoSecundario.Columns(h).HeaderText) = CType("No existe registro", String)

                        Next

                        ' crea las columnas para la concatenacion
                        If Me.chkConcatenar.Checked = True Then

                            Dim hh As Integer = 0

                            For hh = 0 To inContadorColumnasPrincipal - 1

                                dr1(Me.dgvListadoPrincipal.Columns(hh).HeaderText) = CType("No existe registro", String)

                            Next

                        End If

                        dt_CargaCruceDatos.Rows.Add(dr1)

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbPROCESO.Value = inProceso

                Next

                ' inicia la barra de progreso
                pbPROCESO.Value = 0

                If dt_CargaCruceDatos.Rows.Count > 0 Then
                    Me.dgvCruceDatos.DataSource = dt_CargaCruceDatos
                    TabControl1.SelectTab(TabCruceDatos)


                    Me.lblCantidadSiCruzaron.Text = inContadorCruce
                    Me.lblCantidadNoCruzaron.Text = inContadorCruce - Me.dgvListadoPrincipal.RowCount

                    MessageBox.Show("Cruce de registros se genero correctamente", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    MessageBox.Show("Cruce de registros no genero resultado", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

                Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dt_CargaCruceDatos.Rows.Count

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        Try
            If rbdListadoPrincipal.Checked = True Then

                If Me.dgvListadoPrincipal.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvListadoPrincipal.DataSource, DataTable))
                End If

            ElseIf rbdListadoSecundario.Checked = True Then

                If Me.dgvListadoSecundario.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvListadoSecundario.DataSource, DataTable))
                End If

            ElseIf rbdCruceDatos.Checked = True Then

                If Me.dgvCruceDatos.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvCruceDatos.DataSource, DataTable))
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_CruceDeTablas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_CruceDeTablas_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.strBARRESTA.Items(0).Text = "Cruce de tablas"
    End Sub


#End Region

#Region "TextChanged"

    Private Sub lblCantidadDeDiferencia_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCantidadDatosPrincipal.TextChanged, lblCantidadDatosSecundarios.TextChanged
        Me.lblCantidadDeDiferencia.Text = Val(Me.lblCantidadDatosPrincipal.Text) - Val(Me.lblCantidadDatosSecundarios.Text)
    End Sub

#End Region



#End Region

End Class