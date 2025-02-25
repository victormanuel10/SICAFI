Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_Cruce_Propietario_vs_Plano

    '=====================================================
    '*** FORMULARIO CRUCE PROPIETARIO VS ARCHIVO PLANO ***
    '=====================================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Cruce_Propietario_vs_Plano
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Cruce_Propietario_vs_Plano
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

#Region "VARIABLES LOCALES"

    Dim oLeer As New OpenFileDialog

    ' almacena la relación de fichas prediales
    Dim dt_FICHPRED_Municipio As New DataTable
    Dim dt_FICHPRED_Departamento As New DataTable

    ' almacena la carga de inconsistencias
    Dim dt_CargaIncoMunicipio As New DataTable
    Dim dt_CargaIncoDepartamento As New DataTable

    ' otros procesos
    Dim stRutaArchivoMunicipio As String
    Dim stRutaArchivoDepartamento As String
    Dim inTotalRegistrosMunicipio As Integer
    Dim inTotalRegistrosDepartamento As Integer
    Dim inProceso As Integer
    Dim stSeparador As String

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

        dt_FICHPRED_Departamento = New DataTable
        dt_FICHPRED_Municipio = New DataTable

        Me.dgvFIPRINCO.DataSource = New DataTable

        Me.lblRutaArchivoMunicipio.Text = ""
        Me.lblRutaArchivoDepartamento.Text = ""

        Me.cmdValidaDatosMunicipio.Enabled = False
        Me.cmdCargarDatosMunicipio.Enabled = False
        Me.lblFechaMunicipio.Visible = False

        Me.cmdValidaDatosDepartamento.Enabled = False
        Me.cmdCargarDatosDepartamento.Enabled = False
        Me.lblFechaDepartamento.Visible = False

        Me.cmdCruceMunicipioVsDepartamento.Enabled = False

        Me.lblCantidadPrediosMunicipio.Text = ""
        Me.lblCantidadPrediosDepartamento.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registro : 0"

    End Sub
    Private Sub pro_ExportarPlano(ByVal dtl As DataTable)
        Try
            Me.dgvFIPRINCO.DataSource = dtl

            If dgvFIPRINCO.RowCount > 0 Then

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

                        With dgvFIPRINCO
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

    Private Sub cmdAbrirArchivoMunicipio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivoMunicipio.Click

        Try
            ' apaga los comandos
            Me.cmdValidaDatosMunicipio.Enabled = False
            Me.cmdCargarDatosMunicipio.Enabled = False
            Me.cmdCruceMunicipioVsDepartamento.Enabled = False

            ' limpia los campos
            Me.lblCantidadPrediosMunicipio.Text = ""
            Me.lblRutaArchivoMunicipio.Text = ""
            Me.lblFechaMunicipio.Visible = False
            inTotalRegistrosMunicipio = 0

            ' enruta el archivo
            oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
            oLeer.Filter = "Archivo de texto (*.txt)|*.txt" 'Colocar varias extensiones
            oLeer.FilterIndex = 1 'coloca por defecto el *.txt
            oLeer.FileName = ""
            oLeer.ShowDialog()

            stRutaArchivoMunicipio = Trim(oLeer.FileName)
            lblRutaArchivoMunicipio.Text = Trim(oLeer.FileName)

            If Trim(stRutaArchivoMunicipio) <> "" Then

                ' almacena la linea
                Dim stContenidoLinea As String = ""
                Dim stContenidoRegistro As String = ""

                ' abre el archivo
                FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                stContenidoLinea = LineInput(1)

                ' Total de registros
                Do Until EOF(1)
                    stContenidoLinea = LineInput(1)
                    inTotalRegistrosMunicipio += 1
                Loop

                Me.lblCantidadPrediosMunicipio.Text = inTotalRegistrosMunicipio.ToString

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub cmdValidaDatosMunicipio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValidaDatosMunicipio.Click

        Try
            ' apaga los comandos
            Me.cmdValidaDatosMunicipio.Enabled = False
            Me.cmdCargarDatosMunicipio.Enabled = False
            Me.cmdCruceMunicipioVsDepartamento.Enabled = False

            Me.lblFechaMunicipio.Visible = False

            If Trim(stRutaArchivoMunicipio) <> "" Then

                ' limpia los datagrigview
                Me.dgvFIPRINCO.DataSource = New DataTable

                ' abre el archivo
                FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                ' almacena la linea
                Dim stContenidoLinea As String = ""

                ' Valores predeterminados ProgressBar
                inProceso = 0
                pbProcesoMunicipio.Value = 0
                pbProcesoMunicipio.Maximum = inTotalRegistrosMunicipio + 1
                Timer1.Enabled = True

                ' instancia la tabla
                dt_CargaIncoMunicipio = New DataTable

                ' declaro variables
                Dim stFIPRNUFI As String = ""
                Dim stFIPRCECA As String = ""

                ' recorre el archivo plano y repita hasta que se acabe las lineas
                Do Until EOF(1)

                    ' extrae la linea
                    stContenidoLinea = LineInput(1)

                    stFIPRNUFI = stContenidoLinea.Substring(0, 9).ToString
                    stFIPRCECA = stContenidoLinea.Substring(9, 25).ToString

                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stFIPRNUFI)) = False Then

                        ' Crea objeto registros
                        Dim dr1 As DataRow

                        ' Crea las columnas
                        dt_CargaIncoMunicipio.Columns.Add(New DataColumn("Nro. Ficha", GetType(String)))
                        dt_CargaIncoMunicipio.Columns.Add(New DataColumn("Cedula catastral", GetType(String)))
                        dt_CargaIncoMunicipio.Columns.Add(New DataColumn("Descripcion", GetType(String)))

                        dr1 = dt_CargaIncoMunicipio.NewRow()

                        dr1("Nro. Ficha") = stFIPRNUFI
                        dr1("Cedula catastral") = stFIPRCECA
                        dr1("Descripcion") = "Valor no numérico"

                        dt_CargaIncoMunicipio.Rows.Add(dr1)

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbProcesoMunicipio.Value = inProceso

                Loop

                ' Llena el datagrigview
                Me.dgvFIPRINCO.DataSource = dt_CargaIncoMunicipio
                pbProcesoMunicipio.Value = 0

                ' comando grabar datos
                If dt_CargaIncoMunicipio.Rows.Count = 0 Then

                    Me.cmdCargarDatosMunicipio.Enabled = True
                    Me.lblFechaMunicipio.Visible = True
                    Me.cmdValidaDatosMunicipio.Enabled = False
                    Me.cmdCargarDatosMunicipio.Focus()
                    MessageBox.Show("Proceso de validación terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                Else
                    Me.cmdValidaDatosMunicipio.Enabled = True
                    MessageBox.Show("Proceso de validación con inconsistencias", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)

                End If

                Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRINCO.RowCount

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            MessageBox.Show("Error al importar el archivo, revise la longitud o tipo de archivo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub cmdCargarDatosMunicipio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCargarDatosMunicipio.Click

        Try
            If dt_CargaIncoMunicipio.Rows.Count = 0 Then
                If Trim(stRutaArchivoMunicipio) <> "" Then

                    Me.cmdCargarDatosMunicipio.Enabled = False

                    'abre el archivo
                    FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                    ' almacena la linea
                    Dim stContenidoLinea As String = ""

                    ' Valores predeterminados ProgressBar
                    inProceso = 0
                    pbProcesoMunicipio.Value = 0
                    pbProcesoMunicipio.Maximum = inTotalRegistrosMunicipio + 1
                    Timer1.Enabled = True

                    ' crea tablas
                    dt_FICHPRED_Municipio = New DataTable

                    ' Crea las columnas
                    dt_FICHPRED_Municipio.Columns.Add(New DataColumn("FIPRNUFI", GetType(String)))
                    dt_FICHPRED_Municipio.Columns.Add(New DataColumn("FIPRCECA", GetType(String)))
                    dt_FICHPRED_Municipio.Columns.Add(New DataColumn("FIPRTIDO", GetType(String)))
                    dt_FICHPRED_Municipio.Columns.Add(New DataColumn("FIPRNUDO", GetType(String)))


                    ' declaro variables
                    Dim stFIPRNUFI As String = ""
                    Dim stFIPRCECA As String = ""
                    Dim stFIPRTIDO As String = ""
                    Dim stFIPRNUDO As String = ""

                    ' recorre el archivo plano y repita hasta que se acabe las lineas
                    Do Until EOF(1)

                        ' declaro variale numero de caracteres por linea
                        Dim inNroCaracteresLinea As Integer = 0

                        ' extrae la linea
                        stContenidoLinea = LineInput(1)

                        inNroCaracteresLinea = Val(stContenidoLinea.Length.ToString) - 35

                        stFIPRNUFI = stContenidoLinea.Substring(0, 9).ToString
                        stFIPRCECA = stContenidoLinea.Substring(9, 25).ToString
                        stFIPRTIDO = stContenidoLinea.Substring(34, 1).ToString
                        stFIPRNUDO = stContenidoLinea.Substring(35, inNroCaracteresLinea).ToString

                        ' Crea objeto registros
                        Dim dr1 As DataRow

                        dr1 = dt_FICHPRED_Municipio.NewRow()

                        dr1("FIPRNUFI") = stFIPRNUFI
                        dr1("FIPRCECA") = stFIPRCECA
                        dr1("FIPRTIDO") = stFIPRTIDO
                        dr1("FIPRNUDO") = stFIPRNUDO

                        dt_FICHPRED_Municipio.Rows.Add(dr1)

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbProcesoMunicipio.Value = inProceso

                    Loop

                    ' inicia la barra de progreso
                    pbProcesoMunicipio.Value = 0

                    ' comando grabar datos
                    If dt_FICHPRED_Municipio.Rows.Count > 0 Then
                        MessageBox.Show("Se almacena la relación de fichas municipales temporalmente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.cmdCargarDatosMunicipio.Enabled = False
                        Me.cmdValidaDatosMunicipio.Enabled = False
                        Me.lblFechaMunicipio.Visible = False

                        If dt_FICHPRED_Municipio.Rows.Count > 0 And dt_FICHPRED_Departamento.Rows.Count > 0 Then
                            cmdCruceMunicipioVsDepartamento.Enabled = True
                            Me.cmdCruceMunicipioVsDepartamento.Focus()
                        Else
                            cmdCruceMunicipioVsDepartamento.Enabled = False
                        End If
                    Else
                        MessageBox.Show("No se cargaron fichas prediales", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    End If

                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRINCO.RowCount

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub

    Private Sub cmdAbrirArchivoDepartamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivoDepartamento.Click

        Try
            ' apaga los comandos
            Me.cmdValidaDatosDepartamento.Enabled = False
            Me.cmdCargarDatosDepartamento.Enabled = False
            Me.cmdCruceMunicipioVsDepartamento.Enabled = False

            ' limpia los campos
            Me.lblCantidadPrediosDepartamento.Text = ""
            Me.lblRutaArchivoDepartamento.Text = ""
            Me.lblFechaDepartamento.Visible = False
            inTotalRegistrosDepartamento = 0

            ' enruta el archivo
            oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
            oLeer.Filter = "Archivo de texto (*.txt)|*.txt" 'Colocar varias extensiones
            oLeer.FilterIndex = 1 'coloca por defecto el *.txt
            oLeer.FileName = ""
            oLeer.ShowDialog()

            stRutaArchivoDepartamento = Trim(oLeer.FileName)
            lblRutaArchivoDepartamento.Text = Trim(oLeer.FileName)

            If Trim(stRutaArchivoDepartamento) <> "" Then

                ' almacena la linea
                Dim stContenidoLinea As String = ""
                Dim stContenidoRegistro As String = ""

                ' abre el archivo
                FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                stContenidoLinea = LineInput(1)

                ' Total de registros
                Do Until EOF(1)
                    stContenidoLinea = LineInput(1)
                    inTotalRegistrosDepartamento += 1
                Loop

                Me.lblCantidadPrediosDepartamento.Text = inTotalRegistrosDepartamento.ToString

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub cmdValidaDatosDepartamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValidaDatosDepartamento.Click

        Try
            ' apaga los comandos
            Me.cmdValidaDatosDepartamento.Enabled = False
            Me.cmdCargarDatosDepartamento.Enabled = False
            Me.cmdCruceMunicipioVsDepartamento.Enabled = False

            Me.lblFechaDepartamento.Visible = False

            If Trim(stRutaArchivoDepartamento) <> "" Then

                ' limpia los datagrigview
                Me.dgvFIPRINCO.DataSource = New DataTable

                ' abre el archivo
                FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                ' almacena la linea
                Dim stContenidoLinea As String = ""

                ' Valores predeterminados ProgressBar
                inProceso = 0
                pbProcesoDepartamento.Value = 0
                pbProcesoDepartamento.Maximum = inTotalRegistrosDepartamento + 1
                Timer1.Enabled = True

                ' instancia la tabla
                dt_CargaIncoDepartamento = New DataTable

                ' declaro variables
                Dim stFIPRNUFI As String = ""
                Dim stFIPRCECA As String = ""

                ' recorre el archivo plano y repita hasta que se acabe las lineas
                Do Until EOF(1)

                    ' extrae la linea
                    stContenidoLinea = LineInput(1)

                    stFIPRNUFI = stContenidoLinea.Substring(0, 9).ToString
                    stFIPRCECA = stContenidoLinea.Substring(9, 28).ToString

                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(stFIPRNUFI)) = False Then

                        ' Crea objeto registros
                        Dim dr1 As DataRow

                        ' Crea las columnas
                        dt_CargaIncoDepartamento.Columns.Add(New DataColumn("Nro. Ficha", GetType(String)))
                        dt_CargaIncoDepartamento.Columns.Add(New DataColumn("Cedula catastral", GetType(String)))
                        dt_CargaIncoDepartamento.Columns.Add(New DataColumn("Descripcion", GetType(String)))

                        dr1 = dt_CargaIncoDepartamento.NewRow()

                        dr1("Nro. Ficha") = stFIPRNUFI
                        dr1("Cedula catastral") = stFIPRCECA
                        dr1("Descripcion") = "Valor no numérico"

                        dt_CargaIncoDepartamento.Rows.Add(dr1)

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbProcesoDepartamento.Value = inProceso

                Loop

                ' Llena el datagrigview
                Me.dgvFIPRINCO.DataSource = dt_CargaIncoDepartamento
                pbProcesoDepartamento.Value = 0

                ' comando grabar datos
                If dt_CargaIncoDepartamento.Rows.Count = 0 Then

                    Me.cmdCargarDatosDepartamento.Enabled = True
                    Me.lblFechaDepartamento.Visible = True
                    Me.cmdValidaDatosDepartamento.Enabled = False
                    Me.cmdCargarDatosDepartamento.Focus()
                    MessageBox.Show("Proceso de validación terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                Else
                    Me.cmdValidaDatosDepartamento.Enabled = True
                    MessageBox.Show("Proceso de validación con inconsistencias", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)

                End If

                Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRINCO.RowCount

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            MessageBox.Show("Error al importar el archivo, revise la longitud o tipo de archivo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub cmdCargarDatosDepartamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCargarDatosDepartamento.Click

        Try
            If dt_CargaIncoDepartamento.Rows.Count = 0 Then
                If Trim(stRutaArchivoDepartamento) <> "" Then

                    Me.cmdCargarDatosDepartamento.Enabled = False

                    'abre el archivo
                    FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                    ' almacena la linea
                    Dim stContenidoLinea As String = ""

                    ' Valores predeterminados ProgressBar
                    inProceso = 0
                    pbProcesoDepartamento.Value = 0
                    pbProcesoDepartamento.Maximum = inTotalRegistrosDepartamento + 1
                    Timer1.Enabled = True

                    ' crea tablas
                    dt_FICHPRED_Departamento = New DataTable

                    ' Crea las columnas
                    dt_FICHPRED_Departamento.Columns.Add(New DataColumn("FIPRNUFI", GetType(String)))
                    dt_FICHPRED_Departamento.Columns.Add(New DataColumn("FIPRCECA", GetType(String)))
                    dt_FICHPRED_Departamento.Columns.Add(New DataColumn("FIPRTIDO", GetType(String)))
                    dt_FICHPRED_Departamento.Columns.Add(New DataColumn("FIPRNUDO", GetType(String)))


                    ' declaro variables
                    Dim stFIPRNUFI As String = ""
                    Dim stFIPRCECA As String = ""
                    Dim stFIPRTIDO As String = ""
                    Dim stFIPRNUDO As String = ""

                    ' recorre el archivo plano y repita hasta que se acabe las lineas
                    Do Until EOF(1)

                        ' declaro variale numero de caracteres por linea
                        Dim inNroCaracteresLinea As Integer = 0

                        ' extrae la linea
                        stContenidoLinea = LineInput(1)

                        inNroCaracteresLinea = Val(stContenidoLinea.Length.ToString) - 38

                        stFIPRNUFI = stContenidoLinea.Substring(0, 9).ToString
                        stFIPRCECA = stContenidoLinea.Substring(9, 28).ToString
                        stFIPRTIDO = stContenidoLinea.Substring(37, 1).ToString
                        stFIPRNUDO = stContenidoLinea.Substring(38, inNroCaracteresLinea).ToString

                        ' Crea objeto registros
                        Dim dr1 As DataRow

                        dr1 = dt_FICHPRED_Departamento.NewRow()

                        dr1("FIPRNUFI") = stFIPRNUFI
                        dr1("FIPRCECA") = stFIPRCECA
                        dr1("FIPRTIDO") = stFIPRTIDO
                        dr1("FIPRNUDO") = stFIPRNUDO

                        dt_FICHPRED_Departamento.Rows.Add(dr1)

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbProcesoDepartamento.Value = inProceso

                    Loop

                    ' inicia la barra de progreso
                    pbProcesoDepartamento.Value = 0

                    ' comando grabar datos
                    If dt_FICHPRED_Departamento.Rows.Count > 0 Then
                        MessageBox.Show("Se almacena la relación de fichas departamentales temporalmente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.cmdCargarDatosDepartamento.Enabled = False
                        Me.cmdValidaDatosDepartamento.Enabled = False
                        Me.lblFechaDepartamento.Visible = False

                        If dt_FICHPRED_Municipio.Rows.Count > 0 And dt_FICHPRED_Departamento.Rows.Count > 0 Then
                            cmdCruceMunicipioVsDepartamento.Enabled = True
                            Me.cmdCruceMunicipioVsDepartamento.Focus()
                        Else
                            cmdCruceMunicipioVsDepartamento.Enabled = False
                        End If
                    Else
                        MessageBox.Show("No se cargaron fichas prediales", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    End If

                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRINCO.RowCount

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub

    Private Sub cmdCruceMunicipioVsDepartamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCruceMunicipioVsDepartamento.Click

        Try
            ' Cruce municipio vs departamento
            If dt_FICHPRED_Municipio.Rows.Count > 0 And dt_FICHPRED_Departamento.Rows.Count > 0 Then

                ' apaga los comandos
                Me.cmdCruceMunicipioVsDepartamento.Enabled = False

                ' Valores predeterminados ProgressBar
                inProceso = 0
                pbProcesoMunicipio.Value = 0
                pbProcesoMunicipio.Maximum = inTotalRegistrosMunicipio + 1
                Timer1.Enabled = True

                ' instancia la tabla
                dt_CargaIncoDepartamento = New DataTable

                ' declaración de variables
                Dim stFIPRMUNI As String = ""
                Dim stFIPRCLSE As String = ""
                Dim stFIPRCORR As String = ""
                Dim stFIPRBARR As String = ""
                Dim stFIPRMANZ As String = ""
                Dim stFIPRPRED As String = ""
                Dim stFIPREDIF As String = ""
                Dim stFIPRUNPR As String = ""
                Dim stFIPRCECA As String = ""

                ' Crea objeto registros
                Dim dr1 As DataRow

                ' Crea las columnas
                dt_CargaIncoDepartamento.Columns.Add(New DataColumn("Nro. Ficha", GetType(String)))
                dt_CargaIncoDepartamento.Columns.Add(New DataColumn("Cedula catastral", GetType(String)))
                dt_CargaIncoDepartamento.Columns.Add(New DataColumn("Clase Documento", GetType(String)))
                dt_CargaIncoDepartamento.Columns.Add(New DataColumn("Nro. Documento", GetType(String)))
                dt_CargaIncoDepartamento.Columns.Add(New DataColumn("Descripcion", GetType(String)))

                Dim i As Integer = 0

                ' Recorro la tabla del municipio
                For i = 0 To dt_FICHPRED_Municipio.Rows.Count - 1

                    Dim sw1 As Byte = 0
                    Dim j1 As Integer = 0
                    Dim bySW As Byte = 0
                    Dim bySW1 As Byte = 0

                    ' recorre la tabla del departamento
                    While j1 < dt_FICHPRED_Departamento.Rows.Count And sw1 = 0

                        ' almacena los datos
                        Dim inNroFichaMuncipio As Integer = Val(Trim(dt_FICHPRED_Municipio.Rows(i).Item("FIPRNUFI")))
                        Dim inNroFichaDepartamento As Integer = Val(Trim(dt_FICHPRED_Departamento.Rows(j1).Item("FIPRNUFI")))
                        Dim stNroDocumentoMunicipio As String = Trim(dt_FICHPRED_Municipio.Rows(i).Item("FIPRNUDO"))

                        ' busca el numero de ficha
                        If inNroFichaMuncipio = inNroFichaDepartamento Then

                            ' activa el SW
                            sw1 = 1
                            bySW1 = 1

                            Dim sw2 As Byte = 0
                            Dim j2 As Integer = 0

                            ' recorre la tabla del departamento
                            While j2 < dt_FICHPRED_Departamento.Rows.Count And sw2 = 0

                                ' almacena los datos
                                Dim inNroFichaDepartamento2 As Integer = Val(Trim(dt_FICHPRED_Departamento.Rows(j2).Item("FIPRNUFI")))
                                Dim stNroDocumentoMunicipio2 As String = Trim(dt_FICHPRED_Departamento.Rows(j2).Item("FIPRNUDO"))

                                ' busca el numero de documento
                                If inNroFichaMuncipio = inNroFichaDepartamento2 And stNroDocumentoMunicipio = stNroDocumentoMunicipio2 Then

                                    ' activa el SW
                                    sw2 = 1
                                    bySW = 1
                                Else
                                    j2 = j2 + 1
                                End If

                            End While

                        Else
                            j1 = j1 + 1

                        End If

                    End While

                    ' no encontro el numero de ficha
                    If bySW = 0 And bySW1 = 1 Then

                        dr1 = dt_CargaIncoDepartamento.NewRow()

                        stFIPRMUNI = dt_FICHPRED_Municipio.Rows(i).Item("FIPRCECA").ToString.Substring(0, 3)
                        stFIPRCLSE = dt_FICHPRED_Municipio.Rows(i).Item("FIPRCECA").ToString.Substring(3, 1)
                        stFIPRCORR = dt_FICHPRED_Municipio.Rows(i).Item("FIPRCECA").ToString.Substring(4, 2)
                        stFIPRBARR = dt_FICHPRED_Municipio.Rows(i).Item("FIPRCECA").ToString.Substring(6, 3)
                        stFIPRMANZ = dt_FICHPRED_Municipio.Rows(i).Item("FIPRCECA").ToString.Substring(9, 3)
                        stFIPRPRED = dt_FICHPRED_Municipio.Rows(i).Item("FIPRCECA").ToString.Substring(12, 5)
                        stFIPREDIF = dt_FICHPRED_Municipio.Rows(i).Item("FIPRCECA").ToString.Substring(17, 3)
                        stFIPRUNPR = dt_FICHPRED_Municipio.Rows(i).Item("FIPRCECA").ToString.Substring(20, 5)

                        stFIPRCECA = stFIPRMUNI & "-" & stFIPRCLSE & "-" & stFIPRCORR & "-" & stFIPRBARR & "-" & stFIPRMANZ & "-" & stFIPRPRED & "-" & stFIPREDIF & "-" & stFIPRUNPR

                        dr1("Nro. Ficha") = Val(Trim(dt_FICHPRED_Municipio.Rows(i).Item("FIPRNUFI")))
                        dr1("Cedula catastral") = stFIPRCECA
                        dr1("Clase Documento") = Trim(dt_FICHPRED_Municipio.Rows(i).Item("FIPRTIDO"))
                        dr1("Nro. Documento") = Trim(dt_FICHPRED_Municipio.Rows(i).Item("FIPRNUDO"))
                        dr1("Descripcion") = "Propietario no existe en el departamento"

                        dt_CargaIncoDepartamento.Rows.Add(dr1)

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbProcesoMunicipio.Value = inProceso

                Next

                ' inicia la barra de progreso
                pbProcesoMunicipio.Value = 0

                ' verifica el resultado
                If dt_CargaIncoDepartamento.Rows.Count > 0 Then

                    ' Llena el datagrigview
                    Me.dgvFIPRINCO.DataSource = dt_CargaIncoDepartamento

                    MessageBox.Show("Existen inconsistencias de cruce", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    MessageBox.Show("Cruce sin inconsistencias", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            Else
                MessageBox.Show("Existe tablas sin datos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRINCO.RowCount

            ' prende los comandos
            Me.cmdCruceMunicipioVsDepartamento.Enabled = True

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCruceDepartamentoVsMunicipio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try
            ' Cruce municipio vs departamento
            If dt_FICHPRED_Municipio.Rows.Count > 0 And dt_FICHPRED_Departamento.Rows.Count > 0 Then

                ' apaga los comandos
                Me.cmdCruceMunicipioVsDepartamento.Enabled = False

                ' Valores predeterminados ProgressBar
                inProceso = 0
                pbProcesoDepartamento.Value = 0
                pbProcesoDepartamento.Maximum = inTotalRegistrosDepartamento + 1
                Timer1.Enabled = True

                ' instancia la tabla
                dt_CargaIncoMunicipio = New DataTable

                ' declaración de variables
                Dim stFIPRMUNI As String = ""
                Dim stFIPRCLSE As String = ""
                Dim stFIPRCORR As String = ""
                Dim stFIPRBARR As String = ""
                Dim stFIPRMANZ As String = ""
                Dim stFIPRPRED As String = ""
                Dim stFIPREDIF As String = ""
                Dim stFIPRUNPR As String = ""
                Dim stFIPRCECA As String = ""

                ' Crea objeto registros
                Dim dr1 As DataRow

                ' Crea las columnas
                dt_CargaIncoMunicipio.Columns.Add(New DataColumn("Nro. Ficha", GetType(String)))
                dt_CargaIncoMunicipio.Columns.Add(New DataColumn("Cedula catastral", GetType(String)))
                dt_CargaIncoMunicipio.Columns.Add(New DataColumn("Descripcion", GetType(String)))

                Dim i As Integer = 0

                ' Recorro la tabla del departamento
                For i = 0 To dt_FICHPRED_Departamento.Rows.Count - 1

                    Dim sw1 As Byte = 0
                    Dim j1 As Integer = 0
                    Dim bySW As Byte = 0

                    While j1 < dt_FICHPRED_Municipio.Rows.Count And sw1 = 0

                        If Val(Trim(dt_FICHPRED_Departamento.Rows(i).Item("FIPRNUFI"))) = Val(Trim(dt_FICHPRED_Municipio.Rows(j1).Item("FIPRNUFI"))) Then
                            bySW = 1
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If

                    End While

                    ' no encontro el numero de ficha
                    If bySW = 0 Then

                        dr1 = dt_CargaIncoMunicipio.NewRow()

                        stFIPRMUNI = dt_FICHPRED_Departamento.Rows(i).Item("FIPRCECA").ToString.Substring(0, 3)
                        stFIPRCLSE = dt_FICHPRED_Departamento.Rows(i).Item("FIPRCECA").ToString.Substring(3, 1)
                        stFIPRCORR = dt_FICHPRED_Departamento.Rows(i).Item("FIPRCECA").ToString.Substring(4, 3)
                        stFIPRBARR = dt_FICHPRED_Departamento.Rows(i).Item("FIPRCECA").ToString.Substring(7, 3)
                        stFIPRMANZ = dt_FICHPRED_Departamento.Rows(i).Item("FIPRCECA").ToString.Substring(10, 4)
                        stFIPRPRED = dt_FICHPRED_Departamento.Rows(i).Item("FIPRCECA").ToString.Substring(14, 5)
                        stFIPREDIF = dt_FICHPRED_Departamento.Rows(i).Item("FIPRCECA").ToString.Substring(19, 4)
                        stFIPRUNPR = dt_FICHPRED_Departamento.Rows(i).Item("FIPRCECA").ToString.Substring(23, 5)

                        stFIPRCECA = stFIPRMUNI & "-" & stFIPRCLSE & "-" & stFIPRCORR & "-" & stFIPRBARR & "-" & stFIPRMANZ & "-" & stFIPRPRED & "-" & stFIPREDIF & "-" & stFIPRUNPR

                        dr1("Nro. Ficha") = Val(Trim(dt_FICHPRED_Departamento.Rows(i).Item("FIPRNUFI")))
                        dr1("Cedula catastral") = stFIPRCECA
                        dr1("Descripcion") = "Ficha no existe en el municipio"

                        dt_CargaIncoMunicipio.Rows.Add(dr1)

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbProcesoDepartamento.Value = inProceso

                Next

                ' inicia la barra de progreso
                pbProcesoDepartamento.Value = 0

                ' verifica el resultado
                If dt_CargaIncoMunicipio.Rows.Count > 0 Then

                    ' Llena el datagrigview
                    Me.dgvFIPRINCO.DataSource = dt_CargaIncoMunicipio

                    MessageBox.Show("Existen inconsistencias de cruce", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    MessageBox.Show("Cruce sin inconsistencias", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            Else
                MessageBox.Show("Existe tablas sin datos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRINCO.RowCount

            ' prende los comandos
            Me.cmdCruceMunicipioVsDepartamento.Enabled = True

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        Try
            ' exporta ficha predial
            If Me.dgvFIPRINCO.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvFIPRINCO.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarPlano_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.Click
        Try

            pro_ExportarPlano(Me.dgvFIPRINCO.DataSource)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
    End Sub
    Private Sub cmdExtructura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExtructura.Click

        MessageBox.Show("Estructura del archivo municipal : 0098418692661010210420001600100048232509163" & Chr(Keys.Enter) & _
                      "Equivale 009841869|266|1|01|021|042|00016|001|00048|2|32509163" & Chr(Keys.Enter) & Chr(Keys.Enter) & _
                      "Estructura del archivo departamental : 0097202742661001021004000012000100007115345194" & Chr(Keys.Enter) & _
                      "Equivale 009720274|266|1|001|021|0040|00012|0001|00007|1|15345194" & Chr(Keys.Enter) & Chr(Keys.Enter), "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)


    End Sub

    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_importar_planos_FICHA_PREDIAL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.strBARRESTA.Items(0).Text = "Cruce base de datos"
        Me.strBARRESTA.Items(2).Text = "Registros: 0"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmdAbrirArchivoMunicipio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivoMunicipio.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdAbrirArchivoMunicipio.AccessibleDescription
    End Sub
    Private Sub cmdAbrirArchivoDepartamento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivoDepartamento.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdAbrirArchivoDepartamento.AccessibleDescription
    End Sub
    Private Sub cmdValidaDatosMunicipio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdValidaDatosMunicipio.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdValidaDatosMunicipio.AccessibleDescription
    End Sub
    Private Sub cmdValidaDatosDepartamento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdValidaDatosDepartamento.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdValidaDatosDepartamento.AccessibleDescription
    End Sub
    Private Sub cmdCargarDatosMunicipio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCargarDatosMunicipio.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdCargarDatosMunicipio.AccessibleDescription
    End Sub
    Private Sub cmdCargarDatosDepartamento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCargarDatosDepartamento.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdCargarDatosDepartamento.AccessibleDescription
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
    Private Sub dgvFIPRINCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFIPRINCO.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvFIPRINCO.AccessibleDescription
    End Sub

#End Region

#Region "TextChanged"

    Private Sub lblRutaArchivoMunicipio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblRutaArchivoMunicipio.TextChanged

        If Trim(Me.lblRutaArchivoMunicipio.Text) <> "" Then
            Me.cmdValidaDatosMunicipio.Enabled = True
        Else
            Me.cmdValidaDatosMunicipio.Enabled = False
        End If

    End Sub
    Private Sub lblRutaArchivoDepartamento_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblRutaArchivoDepartamento.TextChanged

        If Trim(Me.lblRutaArchivoDepartamento.Text) <> "" Then
            Me.cmdValidaDatosDepartamento.Enabled = True
        Else
            Me.cmdValidaDatosDepartamento.Enabled = False
        End If

    End Sub

#End Region

#End Region

End Class