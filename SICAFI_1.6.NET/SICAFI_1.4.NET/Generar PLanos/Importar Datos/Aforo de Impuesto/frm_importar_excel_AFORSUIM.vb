Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_importar_excel_AFORSUIM

    '===================================================
    '*** FORMULARIO IMPORTAR EXCEL AFORO DE IMPUESTO ***
    '===================================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_importar_excel_AFORSUIM
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_importar_excel_AFORSUIM
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
    Dim dt_CONSULTA As New DataTable
    Dim dt_AFORSUIM As New DataTable

    ' otros procesos
    Dim stRutaArchivo As String
    Dim stSeparador As String
    Dim inTotalRegistros As Integer
    Dim stRESOLUCION As String
    Dim inProceso As Integer

    ' variable contador de registros totales
    Dim a As Integer

    ' variables de conexion
    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.dgvFIPRLIST.DataSource = New DataTable

        Me.lblRUTA.Text = ""
        Me.strBARRESTA.Items(2).Text = "Registros: 0"

        Me.cmdValidaDatos.Enabled = False
        Me.cmdGrabarDatos.Enabled = False
        Me.lblFecha2.Visible = False

        Me.strBARRESTA.Items(2).Text = "Registro : 0"


    End Sub
    Private Sub pro_ValidarHistoricoAvaluos()

        ' limpia los datagrigview
        Me.dgvFIPRINCO.DataSource = New DataTable

        ' Valores predeterminados ProgressBar
        inProceso = 0
        pbPROCESO.Value = 0
        pbPROCESO.Maximum = inTotalRegistros + 1
        Timer1.Enabled = True

        ' Crea objeto de columnas y registros
        Dim dt1 As New DataTable
        Dim dr1 As DataRow

        ' Crea las columnas
        dt1.Columns.Add(New DataColumn("inAFSINUFI", GetType(String)))
        dt1.Columns.Add(New DataColumn("inAFSITIIM", GetType(String)))
        dt1.Columns.Add(New DataColumn("inAFSICONC", GetType(String)))
        dt1.Columns.Add(New DataColumn("inAFSIVIGE", GetType(String)))
        dt1.Columns.Add(New DataColumn("inAFSICLSE", GetType(String)))
        dt1.Columns.Add(New DataColumn("loAFSIVABA", GetType(String)))
        dt1.Columns.Add(New DataColumn("loAFSIVALI", GetType(String)))
        dt1.Columns.Add(New DataColumn("loAFSIVAIM", GetType(String)))
        dt1.Columns.Add(New DataColumn("stAFSIZO01", GetType(String)))
        dt1.Columns.Add(New DataColumn("stAFSIZO02", GetType(String)))
        dt1.Columns.Add(New DataColumn("stAFSIZO03", GetType(String)))
        dt1.Columns.Add(New DataColumn("stAFSIZO04", GetType(String)))
        dt1.Columns.Add(New DataColumn("stAFSIZO05", GetType(String)))
        dt1.Columns.Add(New DataColumn("stAFSIZO06", GetType(String)))
        dt1.Columns.Add(New DataColumn("stAFSIZO07", GetType(String)))
        dt1.Columns.Add(New DataColumn("stAFSITA01", GetType(String)))
        dt1.Columns.Add(New DataColumn("stAFSITA02", GetType(String)))
        dt1.Columns.Add(New DataColumn("stAFSITA03", GetType(String)))
        dt1.Columns.Add(New DataColumn("stAFSITA04", GetType(String)))
        dt1.Columns.Add(New DataColumn("stAFSITA05", GetType(String)))
        dt1.Columns.Add(New DataColumn("stAFSITA06", GetType(String)))
        dt1.Columns.Add(New DataColumn("stAFSITA07", GetType(String)))
        dt1.Columns.Add(New DataColumn("inAFSIMOLI", GetType(String)))
        dt1.Columns.Add(New DataColumn("inAFSITIAF", GetType(String)))
        dt1.Columns.Add(New DataColumn("boAFSIEXEN", GetType(String)))
        dt1.Columns.Add(New DataColumn("stAFSIESTA", GetType(String)))

        ' crea la variable
        Dim i As Integer = 0

        ' crea la tabla
        dt_AFORSUIM = New DataTable

        ' carga la tabla
        dt_AFORSUIM = Me.dgvFIPRLIST.DataSource

        For i = 0 To dt_AFORSUIM.Rows.Count - 1

            Dim boHIAVNUFI As Boolean = fun_Verificar_Dato_Numerico_Evento_Validated(dt_AFORSUIM.Rows(0).Item(0))

            If boHIAVNUFI = False Then

                dr1 = dt1.NewRow()

                dr1("inAFSINUFI") = Trim(dt_AFORSUIM.Rows(i).Item(0).ToString)
                dr1("inAFSITIIM") = Trim(dt_AFORSUIM.Rows(i).Item(1).ToString)
                dr1("inAFSICONC") = Trim(dt_AFORSUIM.Rows(i).Item(2).ToString)
                dr1("inAFSIVIGE") = Trim(dt_AFORSUIM.Rows(i).Item(3).ToString)
                dr1("inAFSICLSE") = Trim(dt_AFORSUIM.Rows(i).Item(4).ToString)
                dr1("loAFSIVABA") = Trim(dt_AFORSUIM.Rows(i).Item(5).ToString)
                dr1("loAFSIVALI") = Trim(dt_AFORSUIM.Rows(i).Item(6).ToString)
                dr1("loAFSIVAIM") = Trim(dt_AFORSUIM.Rows(i).Item(7).ToString)
                dr1("stAFSIZO01") = Trim(dt_AFORSUIM.Rows(i).Item(8).ToString)
                dr1("stAFSIZO02") = Trim(dt_AFORSUIM.Rows(i).Item(9).ToString)
                dr1("stAFSIZO03") = Trim(dt_AFORSUIM.Rows(i).Item(10).ToString)
                dr1("stAFSIZO04") = Trim(dt_AFORSUIM.Rows(i).Item(11).ToString)
                dr1("stAFSIZO05") = Trim(dt_AFORSUIM.Rows(i).Item(12).ToString)
                dr1("stAFSIZO06") = Trim(dt_AFORSUIM.Rows(i).Item(13).ToString)
                dr1("stAFSIZO07") = Trim(dt_AFORSUIM.Rows(i).Item(14).ToString)
                dr1("stAFSITA01") = Trim(dt_AFORSUIM.Rows(i).Item(15).ToString)
                dr1("stAFSITA02") = Trim(dt_AFORSUIM.Rows(i).Item(16).ToString)
                dr1("stAFSITA03") = Trim(dt_AFORSUIM.Rows(i).Item(17).ToString)
                dr1("stAFSITA04") = Trim(dt_AFORSUIM.Rows(i).Item(18).ToString)
                dr1("stAFSITA05") = Trim(dt_AFORSUIM.Rows(i).Item(19).ToString)
                dr1("stAFSITA06") = Trim(dt_AFORSUIM.Rows(i).Item(20).ToString)
                dr1("stAFSITA07") = Trim(dt_AFORSUIM.Rows(i).Item(21).ToString)
                dr1("inAFSIMOLI") = Trim(dt_AFORSUIM.Rows(i).Item(22).ToString)
                dr1("inAFSITIAF") = Trim(dt_AFORSUIM.Rows(i).Item(23).ToString)
                dr1("boAFSIEXEN") = Trim(dt_AFORSUIM.Rows(i).Item(24).ToString)
                dr1("stAFSIESTA") = Trim(dt_AFORSUIM.Rows(i).Item(25).ToString)

                dt1.Rows.Add(dr1)

            End If

            ' Incrementa la barra
            inProceso = inProceso + 1
            pbPROCESO.Value = inProceso

        Next

        ' Llena el datagrigview
        TabControl1.SelectTab(TabPage2)
        Me.dgvFIPRINCO.DataSource = dt1
        pbPROCESO.Value = 0

        ' comando grabar datos
        If dt1.Rows.Count = 0 Then
            Me.cmdGrabarDatos.Enabled = True
            Me.lblFecha2.Visible = True
            Me.cmdValidaDatos.Enabled = False
            Me.cmdGrabarDatos.Focus()
            MessageBox.Show("Proceso de validación terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Me.cmdValidaDatos.Enabled = True
            MessageBox.Show("Proceso de validación inconsistente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

        Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRLIST.RowCount

    End Sub
    Private Sub pro_GuardarHistoricoDeAvaluos()

        Try
            ' apaga el boton grabar datos
            Me.cmdGrabarDatos.Enabled = False

            ' Valores predeterminados ProgressBar
            inProceso = 0
            pbPROCESO.Value = 0
            pbPROCESO.Maximum = inTotalRegistros + 1
            Timer1.Enabled = True

            ' declara la variable
            Dim i As Integer = 0

            ' crea la tabla
            dt_AFORSUIM = New DataTable

            ' declara las variables
            Dim inAFSINUFI As Integer = 0
            Dim inAFSITIIM As Integer = 0
            Dim inAFSICONC As Integer = 0
            Dim inAFSIVIGE As Integer = 0
            Dim inAFSICLSE As Integer = 0
            Dim loAFSIVABA As Long = 0
            Dim loAFSIVALI As Long = 0
            Dim loAFSIVAIM As Long = 0
            Dim stAFSIZO01 As String = ""
            Dim stAFSIZO02 As String = ""
            Dim stAFSIZO03 As String = ""
            Dim stAFSIZO04 As String = ""
            Dim stAFSIZO05 As String = ""
            Dim stAFSIZO06 As String = ""
            Dim stAFSIZO07 As String = ""
            Dim stAFSITA01 As String = ""
            Dim stAFSITA02 As String = ""
            Dim stAFSITA03 As String = ""
            Dim stAFSITA04 As String = ""
            Dim stAFSITA05 As String = ""
            Dim stAFSITA06 As String = ""
            Dim stAFSITA07 As String = ""
            Dim inAFSIMOLI As Integer = 0
            Dim inAFSITIAF As Integer = 0
            Dim boAFSIEXEN As Boolean = False
            Dim stAFSIESTA As String = ""

            Dim inCantidad As Integer = 0

            ' carga la tabla
            dt_AFORSUIM = Me.dgvFIPRLIST.DataSource

            For i = 0 To dt_AFORSUIM.Rows.Count - 1

                inAFSINUFI = Trim(dt_AFORSUIM.Rows(i).Item(0).ToString)
                inAFSITIIM = Trim(dt_AFORSUIM.Rows(i).Item(1).ToString)
                inAFSICONC = Trim(dt_AFORSUIM.Rows(i).Item(2).ToString)
                inAFSIVIGE = Trim(dt_AFORSUIM.Rows(i).Item(3).ToString)
                stAFSIESTA = "ac"

                ' llena las variable
                inAFSINUFI = Trim(dt_AFORSUIM.Rows(i).Item(0).ToString)
                inAFSITIIM = Trim(dt_AFORSUIM.Rows(i).Item(1).ToString)
                inAFSICONC = Trim(dt_AFORSUIM.Rows(i).Item(2).ToString)
                inAFSIVIGE = Trim(dt_AFORSUIM.Rows(i).Item(3).ToString)
                inAFSICLSE = Trim(dt_AFORSUIM.Rows(i).Item(4).ToString)
                loAFSIVABA = Trim(dt_AFORSUIM.Rows(i).Item(5).ToString)
                loAFSIVALI = Trim(dt_AFORSUIM.Rows(i).Item(6).ToString)
                loAFSIVAIM = Trim(dt_AFORSUIM.Rows(i).Item(7).ToString)
                stAFSIZO01 = Trim(dt_AFORSUIM.Rows(i).Item(8).ToString)
                stAFSIZO02 = Trim(dt_AFORSUIM.Rows(i).Item(9).ToString)
                stAFSIZO03 = Trim(dt_AFORSUIM.Rows(i).Item(10).ToString)
                stAFSIZO04 = Trim(dt_AFORSUIM.Rows(i).Item(11).ToString)
                stAFSIZO05 = Trim(dt_AFORSUIM.Rows(i).Item(12).ToString)
                stAFSIZO06 = Trim(dt_AFORSUIM.Rows(i).Item(13).ToString)
                stAFSIZO07 = Trim(dt_AFORSUIM.Rows(i).Item(14).ToString)
                stAFSITA01 = Trim(dt_AFORSUIM.Rows(i).Item(15).ToString)
                stAFSITA02 = Trim(dt_AFORSUIM.Rows(i).Item(16).ToString)
                stAFSITA03 = Trim(dt_AFORSUIM.Rows(i).Item(17).ToString)
                stAFSITA04 = Trim(dt_AFORSUIM.Rows(i).Item(18).ToString)
                stAFSITA05 = Trim(dt_AFORSUIM.Rows(i).Item(19).ToString)
                stAFSITA06 = Trim(dt_AFORSUIM.Rows(i).Item(20).ToString)
                stAFSITA07 = Trim(dt_AFORSUIM.Rows(i).Item(21).ToString)
                inAFSIMOLI = Trim(dt_AFORSUIM.Rows(i).Item(22).ToString)
                inAFSITIAF = Trim(dt_AFORSUIM.Rows(i).Item(23).ToString)
                boAFSIEXEN = Trim(dt_AFORSUIM.Rows(i).Item(24).ToString)
                stAFSIESTA = Trim(dt_AFORSUIM.Rows(i).Item(25).ToString)

                Dim obHISTAVAL As New cla_AFORSUIM

                obHISTAVAL.fun_Eliminar_NUFI_VIGE_CLSE_TIIM_CONC_X_AFORSUIM(inAFSINUFI, inAFSIVIGE, inAFSICLSE, inAFSITIIM, inAFSICONC)

                If obHISTAVAL.fun_Insertar_AFORSUIM(inAFSINUFI, _
                                                            inAFSITIIM, _
                                                            inAFSICONC, _
                                                            inAFSIVIGE, _
                                                            inAFSICLSE, _
                                                            loAFSIVABA, _
                                                            loAFSIVALI, _
                                                            loAFSIVAIM, _
                                                            stAFSIZO01, _
                                                            stAFSIZO02, _
                                                            stAFSIZO03, _
                                                            stAFSIZO04, _
                                                            stAFSIZO05, _
                                                            stAFSIZO06, _
                                                            stAFSIZO07, _
                                                            stAFSITA01, _
                                                            stAFSITA02, _
                                                            stAFSITA03, _
                                                            stAFSITA04, _
                                                            stAFSITA05, _
                                                            stAFSITA06, _
                                                            stAFSITA07, _
                                                            inAFSIMOLI, _
                                                            inAFSITIAF, _
                                                            boAFSIEXEN, _
                                                            stAFSIESTA) = True Then
                    inCantidad += 1

                End If

                ' Incrementa la barra
                inProceso = inProceso + 1
                pbPROCESO.Value = inProceso

            Next

            ' Llena el datagrigview
            TabControl1.SelectTab(TabPage1)
            pbPROCESO.Value = 0

            ' comando grabar datos
            MessageBox.Show("Proceso de guardado terminado correctamente. Registros: " & inCantidad, "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            Me.cmdGrabarDatos.Enabled = False
            Me.lblFecha2.Visible = False
            Me.cmdValidaDatos.Enabled = False

            Me.cmdAbrirArchivo.Focus()

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRLIST.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ExportarPlano(ByVal dtl As DataTable)
        Try
            Me.dgvFIPRLIST.DataSource = dtl

            If dgvFIPRLIST.RowCount > 0 Then

                ' crea la instancia para crear y salvar
                Dim oCrear As New SaveFileDialog

                oCrear.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                oCrear.Filter = "Archivo de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*" 'Colocar varias extensiones
                oCrear.FilterIndex = 1 'coloca por defecto el *.txt
                oCrear.ShowDialog() 'abre la caja de dialogo para guardar


                ' si existe una ruta seleccionada
                If Trim(oCrear.FileName) <> "" Then

                    ' lleba la ruta al label
                    'txtRUTA.Text = oCrear.FileName

                    ' se carga el stSeparador
                    stSeparador = Trim(txtSEPARADOR.Text)

                    'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas
                    Using archivo As StreamWriter = New StreamWriter(oCrear.FileName)

                        ' variable para almacenar la línea actual del dataview
                        Dim linea As String = String.Empty

                        With dgvFIPRLIST
                            ' Recorrer las filas del dataGridView
                            For fila As Integer = 0 To .RowCount - 1
                                ' vaciar la línea
                                linea = String.Empty

                                ' Recorrer la cantidad de columnas que contiene el dataGridView
                                For col As Integer = 0 To .Columns.Count - 1
                                    ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
                                    linea = linea & Trim(.Item(col, fila).Value.ToString) & stSeparador
                                Next

                                ' Escribir una línea con el método WriteLine
                                With archivo
                                    ' eliminar el último caracter ";" de la cadena
                                    linea = linea.Remove(linea.Length - 1).ToString
                                    ' escribir la fila
                                    .WriteLine(linea.ToString)
                                End With
                            Next
                        End With
                    End Using

                    MessageBox.Show("Plano generado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    If MessageBox.Show("¿ Desea abrir el archivo plano ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        ' Abrir con Process.Start el archivo de texto
                        Process.Start(oCrear.FileName)
                    End If

                Else
                    Me.cmdExportarPlano.Focus()
                End If
            Else
                MessageBox.Show("Ejecute la consulta antes de exportar el plano", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAbrirArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivo.Click

        Try
            ' declara variable
            inTotalRegistros = 0

            ' apaga los comandos
            Me.cmdValidaDatos.Enabled = False
            Me.cmdGrabarDatos.Enabled = False

            pro_LimpiarCampos()

            Me.lblFecha2.Visible = False

            ' enruta el archivo
            oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
            oLeer.Filter = "Archivo de texto (*.xls)|*.xls" 'Colocar varias extensiones
            oLeer.FilterIndex = 1 'coloca por defecto el *.txt
            oLeer.FileName = ""
            oLeer.ShowDialog()

            stRutaArchivo = Trim(oLeer.FileName)
            Me.lblRUTA.Text = Trim(oLeer.FileName)

            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim DtSet As System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

            MyConnection = New System.Data.OleDb.OleDbConnection _
            ("provider=Microsoft.Jet.OLEDB.4.0;" & _
            " Data Source='" & stRutaArchivo & "'; " & _
             "Extended Properties=Excel 8.0;")

            Dim stNombreLibro As String = InputBox("Ingrese el nombre de la hoja de excel", "Mensaje")

            If Trim(stNombreLibro) <> "" Then

                MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & stNombreLibro & "$]", MyConnection)

                MyCommand.TableMappings.Add("Table", "TestTable")
                DtSet = New System.Data.DataSet
                MyCommand.Fill(DtSet)
                Me.dgvFIPRLIST.DataSource = DtSet.Tables(0)

                MyConnection.Close()

            Else
                stNombreLibro = InputBox("Ingrese el nombre de la hoja de excel", "Mensaje")
            End If

            ' verifica que exista registros
            If Me.dgvFIPRLIST.RowCount > 0 Then
                Me.cmdValidaDatos.Enabled = True
                inTotalRegistros = Me.dgvFIPRLIST.RowCount
            Else
                Me.cmdValidaDatos.Enabled = False
            End If

            TabControl1.SelectTab(TabPage1)

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRLIST.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdValidaDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValidaDatos.Click
        Try
            ' apaga los comandos
            Me.cmdValidaDatos.Enabled = False
            Me.cmdGrabarDatos.Enabled = False

            Me.lblFecha2.Visible = False

            If Trim(stRutaArchivo) <> "" And Me.dgvFIPRLIST.RowCount > 0 Then

                pro_ValidarHistoricoAvaluos()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdGrabarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabarDatos.Click

        Try
            If Me.dgvFIPRINCO.RowCount = 0 Then
                If Trim(stRutaArchivo) <> "" Then

                    pro_GuardarHistoricoDeAvaluos()

                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error al guardar los datos, revise la integridad del archivo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End Try

    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        Try
            ' exporta ficha predial
            If Me.dgvFIPRLIST.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvFIPRLIST.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarPlano_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.Click

        Try
            If Me.dgvFIPRLIST.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                pro_ExportarPlano(Me.dgvFIPRLIST.DataSource)
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

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_importar_planos_FICHA_PREDIAL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.strBARRESTA.Items(0).Text = "Importar planos"
        Me.strBARRESTA.Items(2).Text = "Registros: 0"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmdAbrirArchivo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivo.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdAbrirArchivo.AccessibleDescription
    End Sub
    Private Sub cmdValidaDatos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdValidaDatos.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdValidaDatos.AccessibleDescription
    End Sub
    Private Sub cmdGrabarDatos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGrabarDatos.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdGrabarDatos.AccessibleDescription
    End Sub
    Private Sub cmdExportarExcel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdExportarExcel.AccessibleDescription
    End Sub
    Private Sub cmdExportarPlano_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdExportarPlano.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub dgvFIPRINCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFIPRLIST.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvFIPRLIST.AccessibleDescription
    End Sub
    Private Sub dgvFIREINCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.strBARRESTA.Items(0).Text = dgvFIPRINCO.AccessibleDescription
    End Sub

#End Region

#End Region

End Class