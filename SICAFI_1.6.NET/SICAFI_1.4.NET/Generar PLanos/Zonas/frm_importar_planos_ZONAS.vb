Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_importar_planos_ZONAS

    '==================================================
    '*** IMPORTAR PLANOS ZONAS FÍSICAS Y ECONÓMICAS ***
    '==================================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_importar_planos_ZONAS
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_importar_planos_ZONAS
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

    ' crea los objetos datatable
    Dim dt_ZONAECON As New DataTable
    Dim dt_ZONAFISI As New DataTable

    ' otros procesos
    Dim stRutaArchivo As String
    Dim stSeparador As String
    Dim inTotalRegistros As Integer
    Dim doProceso As Double

    ' variables locales para ficha predial
    Dim vl_stZONAMUNI As String
    Dim vl_stZONACORR As String
    Dim vl_stZONABARR As String
    Dim vl_stZONAMANZ As String
    Dim vl_stZONAPRED As String
    Dim vl_stZONAEDIF As String
    Dim vl_stZONAUNPR As String
    Dim vl_stZONAZONA As String
    Dim vl_stZONAPORC As String

    ' variables locales para inconsistencias
    Dim vl_stFPINCODI As String
    Dim vl_stFPINDESC As String

    ' variable contador de registros totales
    Dim a As Integer

    ' variables de conexion
    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable
    Private dt_SecuenciaZona As New DataTable

    Dim inContador As Integer = 0

#End Region

#Region "FUNCIONES"

    Private Function fun_BuscarNroSecuenciaZonasEconomicas(ByVal stFIPRNUFI As String) As Integer

        Try
            ' declaro la variable
            Dim inFPZESECU As Integer = 0

            ' instancia la clase
            Dim objdatosZonas As New cla_FIPRZOEC
            Dim tblZonas As New DataTable

            tblZonas = objdatosZonas.fun_Consultar_FIPRZOEC_X_FICHA_PREDIAL(stFIPRNUFI)

            If tblZonas.Rows.Count = 0 Then
                inFPZESECU = 1
            Else
                ' buscar cadena de conexion
                Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                ' crea el datatable
                dt_SecuenciaZona = New DataTable

                ' crear conexión
                oAdapter = New SqlDataAdapter
                oConexion = New SqlConnection(stCadenaConexion)

                ' abre la conexion
                oConexion.Open()

                ' parametros de la consulta
                Dim ParametrosConsulta As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "Select "
                ParametrosConsulta += "max(FpzeSecu) "
                ParametrosConsulta += "From FiprZoec where "
                ParametrosConsulta += "FpzeNufi = '" & stFIPRNUFI & "' "

                ' ejecuta la consulta
                oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                ' procesa la consulta 
                oEjecutar.CommandTimeout = 0
                oEjecutar.CommandType = CommandType.Text
                oAdapter.SelectCommand = oEjecutar

                ' llena el datatable 
                oAdapter.Fill(dt_SecuenciaZona)

                ' cierra la conexion
                oConexion.Close()

                ' incrementa la variable
                inFPZESECU = Val(dt_SecuenciaZona.Rows(0).Item(0)) + 1

            End If

            Return inFPZESECU

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description & ". Error en numero de secuencia zona económica")
        End Try

    End Function
    Private Function fun_BuscarNroSecuenciaZonasFisicas(ByVal inFPZFNUFI As Integer) As Integer

        Try
            ' declaro la variable
            Dim inFPZFSECU As Integer = 0

            ' instancia la clase
            Dim objdatosZonas As New cla_FIPRZOFI
            Dim tblZonas As New DataTable

            tblZonas = objdatosZonas.fun_Consultar_FIPRZOFI_X_FICHA_PREDIAL(inFPZFNUFI)

            If tblZonas.Rows.Count = 0 Then
                inFPZFSECU = 1
            Else
                ' buscar cadena de conexion
                Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                ' crea el datatable
                dt_SecuenciaZona = New DataTable

                ' crear conexión
                oAdapter = New SqlDataAdapter
                oConexion = New SqlConnection(stCadenaConexion)

                ' abre la conexion
                oConexion.Open()

                ' parametros de la consulta
                Dim ParametrosConsulta As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "Select "
                ParametrosConsulta += "max(FpzfSecu) "
                ParametrosConsulta += "From FiprZofi where "
                ParametrosConsulta += "FpzfNufi = '" & inFPZFNUFI & "' "

                ' ejecuta la consulta
                oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                ' procesa la consulta 
                oEjecutar.CommandTimeout = 0
                oEjecutar.CommandType = CommandType.Text
                oAdapter.SelectCommand = oEjecutar

                ' llena el datatable 
                oAdapter.Fill(dt_SecuenciaZona)

                ' cierra la conexion
                oConexion.Close()

                ' incrementa la variable
                inFPZFSECU = Val(dt_SecuenciaZona.Rows(0).Item(0)) + 1

            End If

            Return inFPZFSECU

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description & ". Error en numero de secuencia zona física")
        End Try


    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.dgvFIPRINCO.DataSource = New DataTable

        Me.lblRESOCLSE.Text = ""
        Me.lblRESOMUNI.Text = ""
        Me.lblRESOVIGE.Text = ""
        Me.txtRESOCLSE.Text = ""
        Me.txtRESOMUNI.Text = ""
        Me.txtRESOVIGE.Text = ""

        Me.lblRUTA.Text = ""
        Me.strBARRESTA.Items(2).Text = "Registros: 0"

        Me.cmdValidaDatos.Enabled = False
        Me.cmdGrabarDatos.Enabled = False
        Me.lblFecha2.Visible = False

        Me.chkEliminarZonasExistentes.Checked = True

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

    Private Sub cmdAbrirArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivo.Click

        Try
            ' apaga los comandos
            Me.cmdValidaDatos.Enabled = False
            Me.cmdGrabarDatos.Enabled = False

            ' limpia los campos
            Me.txtRESOMUNI.Text = ""
            Me.txtRESOVIGE.Text = ""
            Me.txtRESOCLSE.Text = ""

            Me.lblRESOMUNI.Text = ""
            Me.lblRESOVIGE.Text = ""
            Me.lblRESOCLSE.Text = ""

            Me.lblRUTA.Text = ""

            Me.lblFecha2.Visible = False

            ' enruta el archivo
            oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
            oLeer.Filter = "Archivo de texto (*.txt)|*.txt" 'Colocar varias extensiones
            oLeer.FilterIndex = 1 'coloca por defecto el *.txt
            oLeer.FileName = ""
            oLeer.ShowDialog()

            stRutaArchivo = Trim(oLeer.FileName)
            lblRUTA.Text = Trim(oLeer.FileName)

            ' selecciona ficha predial
            If Me.rbdZonaEconomica.Checked = True Then

                If Trim(stRutaArchivo) <> "" Then

                    ' almacena la linea
                    Dim stContenidoLinea As String = ""
                    Dim stContenidoRegistro As String = ""
                    inTotalRegistros = 0

                    ' abre el archivo
                    FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                    stContenidoLinea = LineInput(1)

                    Me.txtRESOMUNI.Text = stContenidoLinea.Substring(4, 3).ToString
                    Me.txtRESOVIGE.Text = stContenidoLinea.Substring(0, 4).ToString
                    Me.txtRESOCLSE.Text = stContenidoLinea.Substring(7, 1).ToString

                    ' lista de valores
                    Me.lblRESOMUNI.Text = fun_Buscar_Lista_Valores_MUNICIPIO("05", Me.txtRESOMUNI.Text)
                    Me.lblRESOVIGE.Text = fun_Buscar_Lista_Valores_VIGENCIA(Me.txtRESOVIGE.Text)
                    Me.lblRESOCLSE.Text = fun_Buscar_Lista_Valores_CLASSECT(Me.txtRESOCLSE.Text)

                    ' Total de registros
                    Do Until EOF(1)
                        stContenidoLinea = LineInput(1)
                        inTotalRegistros += 1
                    Loop

                    If inTotalRegistros > 0 Then
                        Me.strBARRESTA.Items(2).Text = "Registros: " & inTotalRegistros
                    Else
                        Me.strBARRESTA.Items(2).Text = "Registros: 0"
                    End If

                End If

            End If

            ' selecciona ficha resumen
            If Me.rbdZonaFisica.Checked = True Then

                If Trim(stRutaArchivo) <> "" Then

                    ' almacena la linea
                    Dim stContenidoLinea As String = ""
                    Dim stContenidoRegistro As String = ""
                    inTotalRegistros = 0

                    ' abre el archivo
                    FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                    stContenidoLinea = LineInput(1)

                    Me.txtRESOMUNI.Text = stContenidoLinea.Substring(4, 3).ToString
                    Me.txtRESOVIGE.Text = stContenidoLinea.Substring(0, 4).ToString
                    Me.txtRESOCLSE.Text = stContenidoLinea.Substring(7, 1).ToString

                    ' lista de valores
                    Me.lblRESOMUNI.Text = fun_Buscar_Lista_Valores_MUNICIPIO("05", Me.txtRESOMUNI.Text)
                    Me.lblRESOVIGE.Text = fun_Buscar_Lista_Valores_VIGENCIA(Me.txtRESOVIGE.Text)
                    Me.lblRESOCLSE.Text = fun_Buscar_Lista_Valores_CLASSECT(Me.txtRESOCLSE.Text)

                    ' Total de registros
                    Do Until EOF(1)
                        stContenidoLinea = LineInput(1)
                        inTotalRegistros += 1
                    Loop

                    If inTotalRegistros > 0 Then
                        Me.strBARRESTA.Items(2).Text = "Registros: " & inTotalRegistros
                    Else
                        Me.strBARRESTA.Items(2).Text = "Registros: 0"
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub cmdValidaDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValidaDatos.Click
        Try
            ' apaga los comandos
            Me.cmdValidaDatos.Enabled = False
            Me.cmdGrabarDatos.Enabled = False

            Me.lblFecha2.Visible = False

            '=================================
            '*** SELECCIONA ZONA ECONOMICA ***
            '=================================

            If Me.rbdZonaEconomica.Checked = True Then

                If Trim(stRutaArchivo) <> "" Then

                    ' limpia los datagrigview
                    Me.dgvFIPRINCO.DataSource = New DataTable

                    ' abre el archivo
                    FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                    ' almacena la linea
                    Dim stContenidoLinea As String = ""
                    Dim stContenidoRegistro As String = ""
                    Dim stNroDeFichaPredial As String = ""

                    ' Valores predeterminados ProgressBar
                    doProceso = 0
                    pbPROCESO.Value = 0
                    pbPROCESO.Maximum = inTotalRegistros + 1
                    Timer1.Enabled = True

                    ' crea tablas
                    dt_ZONAECON = New DataTable

                    ' Tabla ZONA ECONÓMICA
                    Dim dr_ZONAECON As DataRow

                    ' Crea las columnas
                    dt_ZONAECON.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                    dt_ZONAECON.Columns.Add(New DataColumn("Cedula catastral", GetType(String)))
                    dt_ZONAECON.Columns.Add(New DataColumn("Codigo incons.", GetType(String)))
                    dt_ZONAECON.Columns.Add(New DataColumn("Descripcion", GetType(String)))

                    inContador = 0

                    ' recorre el archivo plano y repita hasta que se acabe las lineas
                    Do Until EOF(1)

                        inContador = inContador + 1

                        ' extrae la linea
                        stContenidoLinea = LineInput(1)

                        stContenidoLinea = Trim(stContenidoLinea)

                        If CInt(stContenidoLinea.Length) <> 48 Then
                            MessageBox.Show("Registro : " & inContador)
                        End If

                        ' almacena los datos en variables
                        Dim stZOECVIGE As String = stContenidoLinea.Substring(0, 4).ToString
                        Dim stZOECMUNI As String = stContenidoLinea.Substring(4, 3).ToString
                        Dim stZOECCLSE As String = stContenidoLinea.Substring(7, 1).ToString
                        Dim stZOECCORR As String = stContenidoLinea.Substring(8, 3).ToString
                        Dim stZOECBARR As String = stContenidoLinea.Substring(11, 3).ToString
                        Dim stZOECMANZ As String = stContenidoLinea.Substring(14, 4).ToString
                        Dim stZOECPRED As String = stContenidoLinea.Substring(18, 5).ToString
                        Dim stZOECEDIF As String = stContenidoLinea.Substring(23, 4).ToString
                        Dim stZOECUNPR As String = stContenidoLinea.Substring(27, 5).ToString
                        Dim stZOECZONA As String = stContenidoLinea.Substring(32, 3).ToString
                        Dim stZOECPORC As String = stContenidoLinea.Substring(35, 3).ToString
                        Dim stZOECTIFI As String = stContenidoLinea.Substring(47, 1).ToString

                        ' declara la variable
                        Dim stRegistroCorrecto As Byte = 0

                        ' verifica si los datos son numericos
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOECVIGE) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOECMUNI) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOECCLSE) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOECCORR) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOECBARR) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOECMANZ) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOECPRED) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOECEDIF) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOECUNPR) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOECZONA) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOECPORC) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOECTIFI) = False Then
                            stRegistroCorrecto = 1
                        End If

                        ' mascara de campos
                        stZOECCORR = stZOECCORR.Substring(1, 2).ToString
                        stZOECMANZ = stZOECMANZ.Substring(1, 3).ToString
                        stZOECEDIF = stZOECEDIF.Substring(1, 3).ToString

                        ' inserta la inconsistencia 
                        If stRegistroCorrecto = 1 Then

                            dr_ZONAECON = dt_ZONAECON.NewRow()

                            dr_ZONAECON("Nro_Ficha") = "0"
                            dr_ZONAECON("Cedula catastral") = stZOECMUNI & "-" & stZOECCORR & "-" & stZOECBARR & "-" & stZOECMANZ & "-" & stZOECPRED & "-" & stZOECEDIF & "-" & stZOECUNPR
                            dr_ZONAECON("Codigo incons.") = "Zona Economica"
                            dr_ZONAECON("Descripcion") = "Existe un valor NO numerico en el registro " & inContador

                            dt_ZONAECON.Rows.Add(dr_ZONAECON)

                        Else
                            ' Instancia la clase
                            Dim objdatos12 As New cla_ZONAECON
                            Dim tbl12 As New DataTable

                            ' busca la zona el maestro detalle
                            tbl12 = objdatos12.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAECON("05", stZOECMUNI, stZOECCLSE, stZOECZONA)

                            If tbl12.Rows.Count = 0 Then

                                ' no encuestra la zona en maestro detalle
                                dr_ZONAECON = dt_ZONAECON.NewRow()

                                dr_ZONAECON("Nro_Ficha") = "0"
                                dr_ZONAECON("Cedula catastral") = stZOECMUNI & "-" & stZOECCORR & "-" & stZOECBARR & "-" & stZOECMANZ & "-" & stZOECPRED & "-" & stZOECEDIF & "-" & stZOECUNPR
                                dr_ZONAECON("Codigo incons.") = "Zona Economica"
                                dr_ZONAECON("Descripcion") = "Zona " & stZOECZONA & " no existe en maestro detalle. "

                                dt_ZONAECON.Rows.Add(dr_ZONAECON)

                            End If

                        End If

                        ' Incrementa la barra
                        doProceso = doProceso + 1
                        pbPROCESO.Value = doProceso

                    Loop

                    ' Llena el datagrigview
                    Me.dgvFIPRINCO.DataSource = dt_ZONAECON
                    pbPROCESO.Value = 0

                    ' comando grabar datos
                    If dt_ZONAECON.Rows.Count = 0 Then
                        Me.cmdGrabarDatos.Enabled = True
                        Me.lblFecha2.Visible = True
                        Me.cmdValidaDatos.Enabled = False
                        Me.cmdGrabarDatos.Focus()
                        MessageBox.Show("Proceso de validación terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Else
                        Me.cmdValidaDatos.Enabled = True
                        MessageBox.Show("Proceso de validación inconsistente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    End If

                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRINCO.RowCount

                End If
            End If

            '==============================
            '*** SELECCIONA ZONA FÍSICA *** 
            '==============================

            If Me.rbdZonaFisica.Checked = True Then
                If Trim(stRutaArchivo) <> "" Then

                    ' limpia los datagrigview
                    Me.dgvFIPRINCO.DataSource = New DataTable

                    ' abre el archivo
                    FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                    ' almacena la linea
                    Dim stContenidoLinea As String = ""
                    Dim stContenidoRegistro As String = ""
                    Dim stNroDeFichaPredial As String = ""

                    ' Valores predeterminados ProgressBar
                    doProceso = 0
                    pbPROCESO.Value = 0
                    pbPROCESO.Maximum = inTotalRegistros + 1
                    Timer1.Enabled = True

                    ' crea tablas
                    dt_ZONAFISI = New DataTable

                    ' Tabla ZONA ECONÓMICA
                    Dim dr_ZONAFISI As DataRow

                    ' Crea las columnas
                    dt_ZONAFISI.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                    dt_ZONAFISI.Columns.Add(New DataColumn("Cedula catastral", GetType(String)))
                    dt_ZONAFISI.Columns.Add(New DataColumn("Codigo incons.", GetType(String)))
                    dt_ZONAFISI.Columns.Add(New DataColumn("Descripcion", GetType(String)))

                    inContador = 0

                    ' recorre el archivo plano y repita hasta que se acabe las lineas
                    Do Until EOF(1)

                        inContador = inContador + 1

                        ' extrae la linea
                        stContenidoLinea = LineInput(1)

                        stContenidoLinea = Trim(stContenidoLinea)

                        If CInt(stContenidoLinea.Length) <> 48 Then
                            MessageBox.Show("Registro : " & inContador)
                        End If

                        ' almacena los datos en variables
                        Dim stZOFIVIGE As String = stContenidoLinea.Substring(0, 4).ToString
                        Dim stZOFIMUNI As String = stContenidoLinea.Substring(4, 3).ToString
                        Dim stZOFICLSE As String = stContenidoLinea.Substring(7, 1).ToString
                        Dim stZOFICORR As String = stContenidoLinea.Substring(8, 3).ToString
                        Dim stZOFIBARR As String = stContenidoLinea.Substring(11, 3).ToString
                        Dim stZOFIMANZ As String = stContenidoLinea.Substring(14, 4).ToString
                        Dim stZOFIPRED As String = stContenidoLinea.Substring(18, 5).ToString
                        Dim stZOFIEDIF As String = stContenidoLinea.Substring(23, 4).ToString
                        Dim stZOFIUNPR As String = stContenidoLinea.Substring(27, 5).ToString
                        Dim stZOFIZONA As String = stContenidoLinea.Substring(32, 3).ToString
                        Dim stZOFIPORC As String = stContenidoLinea.Substring(35, 3).ToString
                        Dim stZOFITIFI As String = stContenidoLinea.Substring(47, 1).ToString

                        ' declara la variable
                        Dim stRegistroCorrecto As Byte = 0

                        ' verifica si los datos son numericos
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOFIVIGE) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOFIMUNI) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOFICLSE) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOFICORR) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOFIBARR) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOFIMANZ) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOFIPRED) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOFIEDIF) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOFIUNPR) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOFIZONA) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOFIPORC) = False Then
                            stRegistroCorrecto = 1
                        End If
                        If fun_Verificar_Dato_Numerico_Evento_Validated(stZOFITIFI) = False Then
                            stRegistroCorrecto = 1
                        End If

                        ' mascara de campos
                        stZOFICORR = stZOFICORR.Substring(1, 2).ToString
                        stZOFIMANZ = stZOFIMANZ.Substring(1, 3).ToString
                        stZOFIEDIF = stZOFIEDIF.Substring(1, 3).ToString

                        ' inserta la inconsistencia 
                        If stRegistroCorrecto = 1 Then

                            dr_ZONAFISI = dt_ZONAFISI.NewRow()

                            dr_ZONAFISI("Nro_Ficha") = "0"
                            dr_ZONAFISI("Cedula catastral") = stZOFIMUNI & "-" & stZOFICORR & "-" & stZOFIBARR & "-" & stZOFIMANZ & "-" & stZOFIPRED & "-" & stZOFIEDIF & "-" & stZOFIUNPR
                            dr_ZONAFISI("Codigo incons.") = "Zona Fisica"
                            dr_ZONAFISI("Descripcion") = "Existe un valor NO numerico en el registro " & inContador

                            dt_ZONAFISI.Rows.Add(dr_ZONAFISI)

                        Else
                            ' Instancia la clase
                            Dim objdatos12 As New cla_ZONAFISI
                            Dim tbl12 As New DataTable

                            ' busca la zona el maestro detalle
                            tbl12 = objdatos12.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAFISI("05", stZOFIMUNI, stZOFICLSE, stZOFIZONA)

                            If tbl12.Rows.Count = 0 Then

                                ' no encuestra la zona en maestro detalle
                                dr_ZONAFISI = dt_ZONAFISI.NewRow()

                                dr_ZONAFISI("Nro_Ficha") = "0"
                                dr_ZONAFISI("Cedula catastral") = stZOFIMUNI & "-" & stZOFICORR & "-" & stZOFIBARR & "-" & stZOFIMANZ & "-" & stZOFIPRED & "-" & stZOFIEDIF & "-" & stZOFIUNPR
                                dr_ZONAFISI("Codigo incons.") = "Zona Fisica"
                                dr_ZONAFISI("Descripcion") = "Zona " & stZOFIZONA & " no existe en maestro detalle. "

                                dt_ZONAFISI.Rows.Add(dr_ZONAFISI)

                            End If

                        End If

                        ' Incrementa la barra
                        doProceso = doProceso + 1
                        pbPROCESO.Value = doProceso

                    Loop

                    ' Llena el datagrigview
                    Me.dgvFIPRINCO.DataSource = dt_ZONAFISI
                    pbPROCESO.Value = 0

                    ' comando grabar datos
                    If dt_ZONAFISI.Rows.Count = 0 Then
                        Me.cmdGrabarDatos.Enabled = True
                        Me.lblFecha2.Visible = True
                        Me.cmdValidaDatos.Enabled = False
                        Me.cmdGrabarDatos.Focus()
                        MessageBox.Show("Proceso de validación terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Else
                        Me.cmdValidaDatos.Enabled = True
                        MessageBox.Show("Proceso de validación inconsistente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    End If

                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRINCO.RowCount

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            MessageBox.Show("Error al importar el archivo, revise la longitud o tipo de archivo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub cmdGrabarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabarDatos.Click

        Try
            '===================================
            '*** SELECCIONA ZONAS ECONÓMICAS ***
            '===================================

            If Me.rbdZonaEconomica.Checked = True Then
                If Me.dgvFIPRINCO.RowCount = 0 Then
                    If Trim(stRutaArchivo) <> "" Then

                        Me.cmdGrabarDatos.Enabled = False

                        ' abre el archivo
                        FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                        ' almacena la linea
                        Dim stContenidoLinea As String = ""
                        Dim stNroDeFichaPredial As String = ""
                        Dim inNroDeRegistroDelPlano As Integer = 0

                        ' Valores predeterminados ProgressBar
                        doProceso = 0
                        pbPROCESO.Value = 0
                        pbPROCESO.Maximum = inTotalRegistros + 1
                        Timer1.Enabled = True

                        '=========================
                        '*** ELIMINA LAS ZONAS ***
                        '=========================

                        Dim boEliminarZonas As Boolean = Me.chkEliminarZonasExistentes.Checked
                        inContador = 0

                        ' elimina todas las zonas de los predios
                        Do Until EOF(1)

                            ' extrae la linea
                            stContenidoLinea = LineInput(1)

                            inContador = inContador + 1

                            If boEliminarZonas = True Then

                                ' almacena los datos en variables
                                Dim stZOECMUNI As String = stContenidoLinea.Substring(4, 3).ToString
                                Dim stZOECCLSE As String = stContenidoLinea.Substring(7, 1).ToString
                                Dim stZOECCORR As String = stContenidoLinea.Substring(8, 3).ToString
                                Dim stZOECBARR As String = stContenidoLinea.Substring(11, 3).ToString
                                Dim stZOECMANZ As String = stContenidoLinea.Substring(14, 4).ToString
                                Dim stZOECPRED As String = stContenidoLinea.Substring(18, 5).ToString
                                Dim stZOECEDIF As String = stContenidoLinea.Substring(23, 4).ToString
                                Dim stZOECUNPR As String = stContenidoLinea.Substring(27, 5).ToString
                                Dim stZOECTIFI As String = stContenidoLinea.Substring(47, 1).ToString

                                ' mascara de campos
                                stZOECCORR = stZOECCORR.Substring(1, 2).ToString
                                stZOECMANZ = stZOECMANZ.Substring(1, 3).ToString
                                stZOECEDIF = stZOECEDIF.Substring(1, 3).ToString

                                If CStr(stZOECTIFI) = "2" Then
                                    stZOECEDIF = "001"
                                    stZOECUNPR = "00000"
                                End If

                                ' buscar cadena de conexion
                                Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                                Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                                ' crea el datatable
                                dt = New DataTable

                                ' crear conexión
                                oAdapter = New SqlDataAdapter
                                oConexion = New SqlConnection(stCadenaConexion)

                                ' abre la conexion
                                oConexion.Open()

                                ' variable de la consulta
                                Dim ParametrosConsulta As String = ""

                                ParametrosConsulta += "Select "
                                ParametrosConsulta += "FiprNufi "
                                ParametrosConsulta += "From FichPred where "
                                ParametrosConsulta += "FiprMuni = '" & Trim(stZOECMUNI) & "' and "
                                ParametrosConsulta += "FiprCorr = '" & Trim(stZOECCORR) & "' and "
                                ParametrosConsulta += "FiprBarr = '" & Trim(stZOECBARR) & "' and "
                                ParametrosConsulta += "FiprManz = '" & Trim(stZOECMANZ) & "' and "
                                ParametrosConsulta += "FiprPred = '" & Trim(stZOECPRED) & "' and "
                                ParametrosConsulta += "FiprEdif = '" & Trim(stZOECEDIF) & "' and "
                                ParametrosConsulta += "FiprUnpr = '" & Trim(stZOECUNPR) & "' and "
                                ParametrosConsulta += "FiprClse = '" & Trim(stZOECCLSE) & "' and "
                                ParametrosConsulta += "FiprTifi = '" & Trim(stZOECTIFI) & "' and "
                                ParametrosConsulta += "FiprEsta = 'ac' "

                                ' ejecuta la consulta
                                oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                                ' procesa la consulta 
                                oEjecutar.CommandTimeout = 0
                                oEjecutar.CommandType = CommandType.Text
                                oAdapter.SelectCommand = oEjecutar

                                ' llena el datatable 
                                oAdapter.Fill(dt)

                                ' cierra la conexion
                                oConexion.Close()

                                ' verifica que exista la ficha 
                                If dt.Rows.Count > 0 Then

                                    Dim k As Integer = 0

                                    For k = 0 To dt.Rows.Count - 1

                                        ' Instancia la clase
                                        Dim objdatos1 As New cla_FIPRZOEC

                                        ' elimina la zona existente
                                        objdatos1.fun_Eliminar_FIPRZOEC_X_FICHA_PREDIAL(dt.Rows(k).Item("FIPRNUFI").ToString)

                                    Next

                                End If

                            End If

                            ' Incrementa la barra
                            doProceso = doProceso + 0.5
                            pbPROCESO.Value = doProceso

                        Loop

                        ' cierra el archivo
                        FileClose(1)

                        '========================
                        '*** GUARDA LOS DATOS ***
                        '========================

                        ' abre el archivo
                        FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                        ' almacena la linea
                        stContenidoLinea = ""

                        ' crea tablas
                        dt_ZONAECON = New DataTable

                        ' Tabla ZONA ECONÓMICA
                        Dim dr_ZONAECON As DataRow

                        ' Crea las columnas
                        dt_ZONAECON.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                        dt_ZONAECON.Columns.Add(New DataColumn("Cedula catastral", GetType(String)))
                        dt_ZONAECON.Columns.Add(New DataColumn("Codigo incons.", GetType(String)))
                        dt_ZONAECON.Columns.Add(New DataColumn("Descripcion", GetType(String)))

                        ' recorre el archivo plano y repita hasta que se acabe las lineas
                        Do Until EOF(1)

                            ' extrae la linea
                            stContenidoLinea = LineInput(1)

                            inContador = inContador + 1

                            ' almacena los datos en variables
                            Dim stZOECVIGE As String = stContenidoLinea.Substring(0, 4).ToString
                            Dim stZOECMUNI As String = stContenidoLinea.Substring(4, 3).ToString
                            Dim stZOECCLSE As String = stContenidoLinea.Substring(7, 1).ToString
                            Dim stZOECCORR As String = stContenidoLinea.Substring(8, 3).ToString
                            Dim stZOECBARR As String = stContenidoLinea.Substring(11, 3).ToString
                            Dim stZOECMANZ As String = stContenidoLinea.Substring(14, 4).ToString
                            Dim stZOECPRED As String = stContenidoLinea.Substring(18, 5).ToString
                            Dim stZOECEDIF As String = stContenidoLinea.Substring(23, 4).ToString
                            Dim stZOECUNPR As String = stContenidoLinea.Substring(27, 5).ToString
                            Dim stZOECZONA As String = stContenidoLinea.Substring(32, 3).ToString
                            Dim stZOECPORC As String = stContenidoLinea.Substring(35, 3).ToString
                            Dim stZOECTIFI As String = stContenidoLinea.Substring(47, 1).ToString

                            ' mascara de campos
                            stZOECCORR = stZOECCORR.Substring(1, 2).ToString
                            stZOECMANZ = stZOECMANZ.Substring(1, 3).ToString
                            stZOECEDIF = stZOECEDIF.Substring(1, 3).ToString

                            If CStr(stZOECTIFI) = "2" Then
                                stZOECEDIF = "001"
                                stZOECUNPR = "00000"
                            End If

                            ' buscar cadena de conexion
                            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                            ' crea el datatable
                            dt = New DataTable

                            ' crear conexión
                            oAdapter = New SqlDataAdapter
                            oConexion = New SqlConnection(stCadenaConexion)

                            ' abre la conexion
                            oConexion.Open()

                            ' variable de la consulta
                            Dim ParametrosConsulta As String = ""

                            ParametrosConsulta += "Select "
                            ParametrosConsulta += "FiprNufi "
                            ParametrosConsulta += "From FichPred where "
                            ParametrosConsulta += "FiprMuni = '" & Trim(stZOECMUNI) & "' and "
                            ParametrosConsulta += "FiprCorr = '" & Trim(stZOECCORR) & "' and "
                            ParametrosConsulta += "FiprBarr = '" & Trim(stZOECBARR) & "' and "
                            ParametrosConsulta += "FiprManz = '" & Trim(stZOECMANZ) & "' and "
                            ParametrosConsulta += "FiprPred = '" & Trim(stZOECPRED) & "' and "
                            ParametrosConsulta += "FiprEdif = '" & Trim(stZOECEDIF) & "' and "
                            ParametrosConsulta += "FiprUnpr = '" & Trim(stZOECUNPR) & "' and "
                            ParametrosConsulta += "FiprClse = '" & Trim(stZOECCLSE) & "' and "
                            ParametrosConsulta += "FiprTifi = '" & Trim(stZOECTIFI) & "' and "
                            ParametrosConsulta += "FiprEsta = 'ac' "

                            ' ejecuta la consulta
                            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                            ' procesa la consulta 
                            oEjecutar.CommandTimeout = 0
                            oEjecutar.CommandType = CommandType.Text
                            oAdapter.SelectCommand = oEjecutar

                            ' llena el datatable 
                            oAdapter.Fill(dt)

                            ' cierra la conexion
                            oConexion.Close()

                            ' verifica que exista la ficha 
                            If dt.Rows.Count > 0 Then

                                Dim i As Integer = 0

                                For i = 0 To dt.Rows.Count - 1

                                    ' Instancia la clase
                                    Dim objdatos11 As New cla_FICHPRED
                                    Dim tbl11 As New DataTable

                                    tbl11 = objdatos11.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dt.Rows(i).Item("FIPRNUFI").ToString)

                                    Dim stFIPRNUFI As String = tbl11.Rows(0).Item("FIPRNUFI").ToString
                                    Dim stFIPRDEPA As String = tbl11.Rows(0).Item("FIPRDEPA").ToString
                                    Dim stFIPRMUNI As String = tbl11.Rows(0).Item("FIPRMUNI").ToString
                                    Dim stFIPRTIRE As String = tbl11.Rows(0).Item("FIPRTIRE").ToString
                                    Dim stFIPRCLSE As String = tbl11.Rows(0).Item("FIPRCLSE").ToString
                                    Dim stFIPRVIGE As String = tbl11.Rows(0).Item("FIPRVIGE").ToString
                                    Dim stFIPRRESO As String = tbl11.Rows(0).Item("FIPRRESO").ToString
                                    Dim stFIPRSECU As String = CType(fun_BuscarNroSecuenciaZonasEconomicas(Val(tbl11.Rows(0).Item("FIPRNUFI"))), String)
                                    Dim stFIPRNURE As String = tbl11.Rows(0).Item("FIPRNURE").ToString
                                    Dim stFIPRESTA As String = tbl11.Rows(0).Item("FIPRESTA").ToString

                                    ' Instancia la clase
                                    Dim objdatos1 As New cla_FIPRZOEC
                                    Dim tbl1 As New DataTable

                                    ' busca la zona existente en ficha 
                                    tbl1 = objdatos1.fun_Buscar_CODIGO_FIPRZOEC(Val(stFIPRNUFI), Val(stZOECZONA))

                                    If tbl1.Rows.Count = 0 Then
                                        ' Instancia la clase
                                        Dim objdatos2 As New cla_FIPRZOEC

                                        ' inserta la zona nueva
                                        objdatos2.fun_Insertar_FIPRZOEC(stFIPRNUFI, stZOECZONA, stZOECPORC, stFIPRDEPA, stFIPRMUNI, stFIPRTIRE, stFIPRCLSE, stFIPRVIGE, stFIPRRESO, stFIPRSECU, stFIPRNURE, stFIPRESTA)

                                    Else
                                        ' zona existe en base datos
                                        dr_ZONAECON = dt_ZONAECON.NewRow()
                                        dr_ZONAECON("Nro_Ficha") = stFIPRNUFI
                                        dr_ZONAECON("Cedula catastral") = stZOECMUNI & "-" & stZOECCORR & "-" & stZOECBARR & "-" & stZOECMANZ & "-" & stZOECPRED & "-" & stZOECEDIF & "-" & stZOECUNPR
                                        dr_ZONAECON("Codigo incons.") = "Zona Economica"
                                        dr_ZONAECON("Descripcion") = "Zona " & stZOECZONA & " existente en base de datos. Nro Ficha : " & stFIPRNUFI
                                        dt_ZONAECON.Rows.Add(dr_ZONAECON)

                                    End If

                                Next

                            End If

                            ' Incrementa la barra
                            doProceso = doProceso + 0.5
                            pbPROCESO.Value = doProceso

                        Loop

                        ' Llena el datagrigview
                        Me.dgvFIPRINCO.DataSource = dt_ZONAECON
                        pbPROCESO.Value = 0

                        ' comando grabar datos
                        If dt_ZONAECON.Rows.Count = 0 Then
                            MessageBox.Show("Proceso de guardado terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Else
                            MessageBox.Show("Proceso de guardado con inconsistencias", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        End If

                        Me.cmdGrabarDatos.Enabled = False
                        Me.lblFecha2.Visible = False
                        Me.cmdValidaDatos.Enabled = False

                        Me.cmdAbrirArchivo.Focus()

                        Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRINCO.RowCount

                    End If
                End If
            End If

            '================================
            '*** SELECCIONA ZONAS FÍSICAS ***
            '================================

            If Me.rbdZonaFisica.Checked = True Then
                If Me.dgvFIPRINCO.RowCount = 0 Then
                    If Trim(stRutaArchivo) <> "" Then

                        Me.cmdGrabarDatos.Enabled = False

                        ' abre el archivo
                        FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                        ' almacena la linea
                        Dim stContenidoLinea As String = ""
                        Dim stNroDeFichaPredial As String = ""
                        Dim inNroDeRegistroDelPlano As Integer = 0

                        ' Valores predeterminados ProgressBar
                        doProceso = 0
                        pbPROCESO.Value = 0
                        pbPROCESO.Maximum = inTotalRegistros + 1
                        Timer1.Enabled = True

                        '=========================
                        '*** ELIMINA LAS ZONAS ***
                        '=========================

                        Dim boEliminarZonas As Boolean = Me.chkEliminarZonasExistentes.Checked
                        inContador = 0

                        ' elimina todas las zonas de los predios
                        Do Until EOF(1)

                            ' extrae la linea
                            stContenidoLinea = LineInput(1)

                            inContador = inContador + 1

                            If boEliminarZonas = True Then

                                ' almacena los datos en variables
                                Dim stZOFIMUNI As String = stContenidoLinea.Substring(4, 3).ToString
                                Dim stZOFICLSE As String = stContenidoLinea.Substring(7, 1).ToString
                                Dim stZOFICORR As String = stContenidoLinea.Substring(8, 3).ToString
                                Dim stZOFIBARR As String = stContenidoLinea.Substring(11, 3).ToString
                                Dim stZOFIMANZ As String = stContenidoLinea.Substring(14, 4).ToString
                                Dim stZOFIPRED As String = stContenidoLinea.Substring(18, 5).ToString
                                Dim stZOFIEDIF As String = stContenidoLinea.Substring(23, 4).ToString
                                Dim stZOFIUNPR As String = stContenidoLinea.Substring(27, 5).ToString
                                Dim stZOFITIFI As String = stContenidoLinea.Substring(47, 1).ToString

                                ' mascara de campos
                                stZOFICORR = stZOFICORR.Substring(1, 2).ToString
                                stZOFIMANZ = stZOFIMANZ.Substring(1, 3).ToString
                                stZOFIEDIF = stZOFIEDIF.Substring(1, 3).ToString

                                If CStr(stZOFITIFI) = "2" Then
                                    stZOFIEDIF = "001"
                                    stZOFIUNPR = "00000"
                                End If

                                ' buscar cadena de conexion
                                Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                                Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                                ' crea el datatable
                                dt = New DataTable

                                ' crear conexión
                                oAdapter = New SqlDataAdapter
                                oConexion = New SqlConnection(stCadenaConexion)

                                ' abre la conexion
                                oConexion.Open()

                                ' variable de la consulta
                                Dim ParametrosConsulta As String = ""

                                ' Concatena la condicion de la consulta
                                ParametrosConsulta += "Select "
                                ParametrosConsulta += "Top 1 FiprNufi "
                                ParametrosConsulta += "From FichPred where "
                                ParametrosConsulta += "FiprMuni = '" & Trim(stZOFIMUNI) & "' and "
                                ParametrosConsulta += "FiprCorr = '" & Trim(stZOFICORR) & "' and "
                                ParametrosConsulta += "FiprBarr = '" & Trim(stZOFIBARR) & "' and "
                                ParametrosConsulta += "FiprManz = '" & Trim(stZOFIMANZ) & "' and "
                                ParametrosConsulta += "FiprPred = '" & Trim(stZOFIPRED) & "' and "
                                ParametrosConsulta += "FiprEdif = '" & Trim(stZOFIEDIF) & "' and "
                                ParametrosConsulta += "FiprUnpr = '" & Trim(stZOFIUNPR) & "' and "
                                ParametrosConsulta += "FiprClse = '" & Trim(stZOFICLSE) & "' and "
                                ParametrosConsulta += "FiprTifi = '" & Trim(stZOFITIFI) & "' and "
                                ParametrosConsulta += "FiprEsta = 'ac' and "
                                ParametrosConsulta += "(exists(select 1 from fiprcons "
                                ParametrosConsulta += "where fiprnufi = fpconufi and fpcoesta = 'ac' and fpcomejo = 0) "
                                ParametrosConsulta += "or not exists(select 1 from fiprcons "
                                ParametrosConsulta += "where fiprnufi = fpconufi)) "
                                ParametrosConsulta += "order by fiprarte desc"

                                ' ejecuta la consulta
                                oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                                ' procesa la consulta 
                                oEjecutar.CommandTimeout = 360
                                oEjecutar.CommandType = CommandType.Text
                                oAdapter.SelectCommand = oEjecutar

                                ' llena el datatable 
                                oAdapter.Fill(dt)

                                ' cierra la conexion
                                oConexion.Close()

                                ' verifica que exista la ficha 

                                If dt.Rows.Count > 0 Then

                                    ' Instancia la clase
                                    Dim objdatos1 As New cla_FIPRZOFI

                                    ' elimina la zona existente
                                    objdatos1.fun_Eliminar_FIPRZOFI_X_FICHA_PREDIAL(dt.Rows(0).Item("FIPRNUFI").ToString)

                                End If

                            End If

                            ' Incrementa la barra
                            doProceso = doProceso + 0.5
                            pbPROCESO.Value = doProceso

                        Loop

                        ' cierra el archivo
                        FileClose(1)

                        '========================
                        '*** GUARDA LOS DATOS ***
                        '========================

                        ' abre el archivo
                        FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                        ' almacena la linea
                        stContenidoLinea = ""

                        ' crea tablas
                        dt_ZONAFISI = New DataTable

                        ' Tabla ZONA FÍSICA
                        Dim dr_ZONAFISI As DataRow

                        ' Crea las columnas
                        dt_ZONAFISI.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                        dt_ZONAFISI.Columns.Add(New DataColumn("Cedula catastral", GetType(String)))
                        dt_ZONAFISI.Columns.Add(New DataColumn("Codigo incons.", GetType(String)))
                        dt_ZONAFISI.Columns.Add(New DataColumn("Descripcion", GetType(String)))

                        ' recorre el archivo plano y repita hasta que se acabe las lineas
                        Do Until EOF(1)

                            ' extrae la linea
                            stContenidoLinea = LineInput(1)

                            inContador = inContador + 1

                            ' almacena los datos en variables
                            Dim stZOFIVIGE As String = stContenidoLinea.Substring(0, 4).ToString
                            Dim stZOFIMUNI As String = stContenidoLinea.Substring(4, 3).ToString
                            Dim stZOFICLSE As String = stContenidoLinea.Substring(7, 1).ToString
                            Dim stZOFICORR As String = stContenidoLinea.Substring(8, 3).ToString
                            Dim stZOFIBARR As String = stContenidoLinea.Substring(11, 3).ToString
                            Dim stZOFIMANZ As String = stContenidoLinea.Substring(14, 4).ToString
                            Dim stZOFIPRED As String = stContenidoLinea.Substring(18, 5).ToString
                            Dim stZOFIEDIF As String = stContenidoLinea.Substring(23, 4).ToString
                            Dim stZOFIUNPR As String = stContenidoLinea.Substring(27, 5).ToString
                            Dim stZOFIZONA As String = stContenidoLinea.Substring(32, 3).ToString
                            Dim stZOFIPORC As String = stContenidoLinea.Substring(35, 3).ToString
                            Dim stZOFITIFI As String = stContenidoLinea.Substring(47, 1).ToString

                            ' mascara de campos
                            stZOFICORR = stZOFICORR.Substring(1, 2).ToString
                            stZOFIMANZ = stZOFIMANZ.Substring(1, 3).ToString
                            stZOFIEDIF = stZOFIEDIF.Substring(1, 3).ToString

                            If CStr(stZOFITIFI) = "2" Then
                                stZOFIEDIF = "001"
                                stZOFIUNPR = "00000"
                            End If

                            ' buscar cadena de conexion
                            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                            ' crea el datatable
                            dt = New DataTable

                            ' crear conexión
                            oAdapter = New SqlDataAdapter
                            oConexion = New SqlConnection(stCadenaConexion)

                            ' abre la conexion
                            oConexion.Open()

                            ' variable de la consulta
                            Dim ParametrosConsulta As String = ""

                            ' Concatena la condicion de la consulta
                            ParametrosConsulta += "Select "
                            ParametrosConsulta += "Top 1 FiprNufi "
                            ParametrosConsulta += "From FichPred where "
                            ParametrosConsulta += "FiprMuni = '" & Trim(stZOFIMUNI) & "' and "
                            ParametrosConsulta += "FiprCorr = '" & Trim(stZOFICORR) & "' and "
                            ParametrosConsulta += "FiprBarr = '" & Trim(stZOFIBARR) & "' and "
                            ParametrosConsulta += "FiprManz = '" & Trim(stZOFIMANZ) & "' and "
                            ParametrosConsulta += "FiprPred = '" & Trim(stZOFIPRED) & "' and "
                            ParametrosConsulta += "FiprEdif = '" & Trim(stZOFIEDIF) & "' and "
                            ParametrosConsulta += "FiprUnpr = '" & Trim(stZOFIUNPR) & "' and "
                            ParametrosConsulta += "FiprClse = '" & Trim(stZOFICLSE) & "' and "
                            ParametrosConsulta += "FiprTifi = '" & Trim(stZOFITIFI) & "' and "
                            ParametrosConsulta += "FiprEsta = 'ac' and "
                            ParametrosConsulta += "(exists(select 1 from fiprcons "
                            ParametrosConsulta += "where fiprnufi = fpconufi and fpcoesta = 'ac' and fpcomejo = 0) "
                            ParametrosConsulta += "or not exists(select 1 from fiprcons "
                            ParametrosConsulta += "where fiprnufi = fpconufi)) "
                            ParametrosConsulta += "order by fiprarte desc"

                            ' ejecuta la consulta
                            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                            ' procesa la consulta 
                            oEjecutar.CommandTimeout = 360
                            oEjecutar.CommandType = CommandType.Text
                            oAdapter.SelectCommand = oEjecutar

                            ' llena el datatable 
                            oAdapter.Fill(dt)

                            ' cierra la conexion
                            oConexion.Close()

                            ' verifica que exista la ficha 
                            If dt.Rows.Count > 0 Then

                                ' Instancia la clase
                                Dim objdatos11 As New cla_FICHPRED
                                Dim tbl11 As New DataTable

                                tbl11 = objdatos11.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dt.Rows(0).Item("FIPRNUFI").ToString)

                                Dim stFIPRDEPA As String = tbl11.Rows(0).Item("FIPRDEPA").ToString
                                Dim stFIPRNUFI As String = tbl11.Rows(0).Item("FIPRNUFI").ToString
                                Dim stFIPRMUNI As String = tbl11.Rows(0).Item("FIPRMUNI").ToString
                                Dim stFIPRTIRE As String = tbl11.Rows(0).Item("FIPRTIRE").ToString
                                Dim stFIPRCLSE As String = tbl11.Rows(0).Item("FIPRCLSE").ToString
                                Dim stFIPRVIGE As String = tbl11.Rows(0).Item("FIPRVIGE").ToString
                                Dim stFIPRRESO As String = tbl11.Rows(0).Item("FIPRRESO").ToString
                                Dim stFIPRSECU As String = CType(fun_BuscarNroSecuenciaZonasFisicas(Val(tbl11.Rows(0).Item("FIPRNUFI"))), String)
                                Dim stFIPRNURE As String = tbl11.Rows(0).Item("FIPRNURE").ToString
                                Dim stFIPRESTA As String = tbl11.Rows(0).Item("FIPRESTA").ToString

                                ' Instancia la clase
                                Dim objdatos1 As New cla_FIPRZOFI
                                Dim tbl1 As New DataTable

                                ' busca la zona existente en ficha 
                                tbl1 = objdatos1.fun_Buscar_CODIGO_FIPRZOFI(Val(stFIPRNUFI), Val(stZOFIZONA))

                                If tbl1.Rows.Count = 0 Then
                                    ' Instancia la clase
                                    Dim objdatos2 As New cla_FIPRZOFI

                                    ' inserta la zona nueva
                                    objdatos2.fun_Insertar_FIPRZOFI(stFIPRNUFI, stZOFIZONA, stZOFIPORC, stFIPRDEPA, stFIPRMUNI, stFIPRTIRE, stFIPRCLSE, stFIPRVIGE, stFIPRRESO, stFIPRSECU, stFIPRNURE, stFIPRESTA)

                                Else
                                    ' zona existe en base datos
                                    dr_ZONAFISI = dt_ZONAFISI.NewRow()
                                    dr_ZONAFISI("Nro_Ficha") = stFIPRNUFI
                                    dr_ZONAFISI("Cedula catastral") = stZOFIMUNI & "-" & stZOFICORR & "-" & stZOFIBARR & "-" & stZOFIMANZ & "-" & stZOFIPRED & "-" & stZOFIEDIF & "-" & stZOFIUNPR
                                    dr_ZONAFISI("Codigo incons.") = "Zona Fisica"
                                    dr_ZONAFISI("Descripcion") = "Zona " & stZOFIZONA & " existente en base de datos. Nro Ficha : " & stFIPRNUFI
                                    dt_ZONAFISI.Rows.Add(dr_ZONAFISI)

                                End If

                            End If

                            ' Incrementa la barra
                            doProceso = doProceso + 0.5
                            pbPROCESO.Value = doProceso

                        Loop

                        ' Llena el datagrigview
                        Me.dgvFIPRINCO.DataSource = dt_ZONAFISI
                        pbPROCESO.Value = 0

                        ' comando grabar datos
                        If dt_ZONAFISI.Rows.Count = 0 Then
                            MessageBox.Show("Proceso de guardado terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Else
                            MessageBox.Show("Proceso de guardado con inconsistencias", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        End If

                        Me.cmdGrabarDatos.Enabled = False
                        Me.lblFecha2.Visible = False
                        Me.cmdValidaDatos.Enabled = False

                        Me.cmdAbrirArchivo.Focus()

                        Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRINCO.RowCount

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & inContador)
            MessageBox.Show("Error al guardar los datos, revise la integridad del archivo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        Try
            ' exporta ficha predial
            If Me.rbdZonaEconomica.Checked = True Then
                If Me.dgvFIPRINCO.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvFIPRINCO.DataSource, DataTable))
                End If
            End If

            ' exporta ficha resumen
            If Me.rbdZonaFisica.Checked = True Then
                If Me.dgvFIPRINCO.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvFIPRINCO.DataSource, DataTable))
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarPlano_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.Click
        Try

            If Me.rbdZonaEconomica.Checked = True Then
                pro_ExportarPlano(Me.dgvFIPRINCO.DataSource)
            End If

            If Me.rbdZonaFisica.Checked = True Then
                pro_ExportarPlano(Me.dgvFIPRINCO.DataSource)
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
    Private Sub rbdFichaPredial_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbdZonaEconomica.GotFocus
        Me.strBARRESTA.Items(0).Text = rbdZonaEconomica.AccessibleDescription
    End Sub
    Private Sub rbdFichaResumen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbdZonaFisica.GotFocus
        Me.strBARRESTA.Items(0).Text = rbdZonaFisica.AccessibleDescription
    End Sub
    Private Sub dgvFIPRINCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFIPRINCO.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvFIPRINCO.AccessibleDescription
    End Sub


#End Region

#Region "TextChanged"

    Private Sub lblRUTA_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblRUTA.TextChanged

        If Trim(Me.lblRUTA.Text) <> "" Then
            Me.cmdValidaDatos.Enabled = True
        Else
            Me.cmdValidaDatos.Enabled = False
        End If
    End Sub

#End Region

#End Region

   
End Class