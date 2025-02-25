Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_Actualizar_Propietario_Actual_y_Anterior

    '================================================================
    '*** FORMULARIO IMPORTAR PLANOS PROPIETARIO ACTUAL Y ANTERIOR ***
    '================================================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Actualizar_Propietario_Actual_y_Anterior
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Actualizar_Propietario_Actual_y_Anterior
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
    Dim dt_RESOLUCI As New DataTable
    Dim dt_FICHPRED As New DataTable
    Dim dt_FICHRES1 As New DataTable
    Dim dt_FICHRES2 As New DataTable
    Dim dt_FIPRDEEC As New DataTable
    Dim dt_FIPRPROP As New DataTable
    Dim dt_FIPRCONS As New DataTable
    Dim dt_FIPRCACO As New DataTable
    Dim dt_FIPRLIND As New DataTable
    Dim dt_FIPRCART As New DataTable
   
    ' otros procesos
    Dim stRutaArchivo As String
    Dim stSeparador As String
    Dim inTotalRegistros As Integer
    Dim stRESOLUCION As String
    Dim inProceso As Integer

    ' variables ficha predial
    Dim vl_inFIPRNURE As Integer
    Dim vl_stFIPRCORE As String
    Dim vl_stFIPRCECA As String

    ' variables ficha resumen
    Dim vl_inFIRENUFI As Integer

    ' variables locales de la resolucion
    Dim vl_stRESODEPA As String
    Dim vl_stRESOMUNI As String
    Dim vl_inRESOVIGE As Integer
    Dim vl_inRESOTIRE As Integer
    Dim vl_inRESORESO As Integer
    Dim vl_inRESOCLSE As Integer

    ' variables locales para ficha predial
    Dim vl_inFIPRNUFI As Integer
    Dim vl_stFIPRMUNI As String
    Dim vl_stFIPRCORR As String
    Dim vl_stFIPRBARR As String
    Dim vl_stFIPRMANZ As String
    Dim vl_stFIPRPRED As String
    Dim vl_stFIPREDIF As String
    Dim vl_stFIPRUNPR As String

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

    ' sw de consulta a la base de datos
    Private bySW As Byte = 0
    Private inCantidadFichas As Integer = 0

#End Region

#Region "FUNCIONES"

    Private Function fun_BuscarNroSecuenciaPropietario(ByVal inFPPRNUFI As Integer) As Integer
        Dim inSECUENCIA As Integer = 0

        ' busca el numero de secuencia de la base datos
        Dim objdatos5 As New cla_FIPRPROP
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRPROP_X_FICHA_PREDIAL(Val(inFPPRNUFI))

        If tbl10.Rows.Count = 0 Then
            inSECUENCIA = 1
        Else
            ' asigna el numero de secuencia
            Dim i As Integer
            Dim NroMayor As Integer = 0
            Dim Posicion As Integer = 0

            Posicion = Val(tbl10.Rows(0).Item("FPPRSECU"))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item("FPPRSECU"))

                If NroMayor > Posicion Then
                    inSECUENCIA = NroMayor
                    Posicion = NroMayor
                Else
                    inSECUENCIA = Posicion
                End If
            Next

            inSECUENCIA = inSECUENCIA + 1
        End If

        Return inSECUENCIA

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.dgvFIPRINCO.DataSource = New DataTable

        Me.lblRUTA.Text = ""
        Me.strBARRESTA.Items(2).Text = "Registros: 0"

        Me.cmdValidaDatos.Enabled = False
        Me.cmdGrabarDatos.Enabled = False
        Me.lblFecha2.Visible = False

        ' campos resolución
        Me.txtRESODEPA.Text = ""
        Me.txtRESOMUNI.Text = ""
        Me.txtRESOTIRE.Text = ""
        Me.txtRESOVIGE.Text = ""
        Me.txtRESOCLSE.Text = ""
        Me.txtRESOCODI.Text = ""
        Me.lblRESODEPA.Text = ""
        Me.lblRESOMUNI.Text = ""
        Me.lblRESOTIRE.Text = ""
        Me.lblRESOVIGE.Text = ""
        Me.lblRESOCLSE.Text = ""
        Me.lblRESODESC.Text = ""

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
    Private Sub pro_GrabarInconsistencia(ByVal stCODIGO As String, ByVal stDESCRIPCION As String)

        Dim objdatos1 As New cla_VALIFIPR

        objdatos1.fun_Insertar_FIPRINCO(vl_inFIPRNUFI, _
                                        stCODIGO, _
                                        stDESCRIPCION, _
                                        vl_stFIPRMUNI, _
                                        vl_stFIPRCORR, _
                                        vl_stFIPRBARR, _
                                        vl_stFIPRMANZ, _
                                        vl_stFIPRPRED, _
                                        vl_stFIPREDIF, _
                                        vl_stFIPRUNPR, _
                                        vl_inRESOCLSE, _
                                        stRESOLUCION)

    End Sub

    Private Sub pro_InactivarPropietarios(ByVal inFPPRNUFI As Integer)

        Try

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' variables
            Dim stFPPRESTA As String = "in"

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "update FIPRPROP "
            ParametrosConsulta += "set FPPRESTA = '" & stFPPRESTA & "' "
            ParametrosConsulta += "where FPPRNUFI = '" & inFPPRNUFI & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text

            oReader = oEjecutar.ExecuteReader

            Dim i As Integer = oReader.RecordsAffected

            ' cierra la conexion
            oConexion.Close()
            oReader = Nothing

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ValidarFichaPredial()

        ' limpia los datagrigview
        Me.dgvFIPRINCO.DataSource = New DataTable

        stRESOLUCION = Me.txtRESOMUNI.Text & Me.txtRESOVIGE.Text & Me.txtRESOTIRE.Text & Me.txtRESOCODI.Text & Me.txtRESOCLSE.Text

        ' instancia la clase
        Dim objdatos11 As New cla_VALIFIPR
        'Dim tbl11 As New DataTable

        ' elimina las inconsistencias
        objdatos11.fun_Eliminar_FIPRINCO_X_RESOLUCION(Trim(stRESOLUCION))

        ' abre el archivo
        FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

        ' almacena la linea
        Dim stContenidoLinea As String = ""
        Dim stContenidoRegistro As String = ""
        Dim stNroDeFichaPredial As String = ""

        ' Valores predeterminados ProgressBar
        inProceso = 0
        pbPROCESO.Value = 0
        pbPROCESO.Maximum = inTotalRegistros + 1
        Timer1.Enabled = True

        ' recorre el archivo plano y repita hasta que se acabe las lineas
        Do Until EOF(1)

            ' extrae la linea
            stContenidoLinea = LineInput(1)

            ' verifica cual es el registro de la tabla
            stContenidoRegistro = stContenidoLinea.Substring(0, 1).ToString

            ' crea tablas
            dt_RESOLUCI = New DataTable
            dt_FICHPRED = New DataTable
            dt_FIPRPROP = New DataTable

            ' Tabla RESOLUCION
            If stContenidoRegistro = "1" Then

                Dim dr_RESOLUCI As DataRow

                ' TABLA RESOLUCION
                dt_RESOLUCI.Columns.Add(New DataColumn("RESOIDRE", GetType(String)))
                dt_RESOLUCI.Columns.Add(New DataColumn("RESOVIGE", GetType(String)))
                dt_RESOLUCI.Columns.Add(New DataColumn("RESOTIRE", GetType(String)))
                dt_RESOLUCI.Columns.Add(New DataColumn("RESORESO", GetType(String)))
                dt_RESOLUCI.Columns.Add(New DataColumn("RESOMUNI", GetType(String)))
                dt_RESOLUCI.Columns.Add(New DataColumn("RESOCLSE", GetType(String)))
                dt_RESOLUCI.Columns.Add(New DataColumn("RESONURE", GetType(String)))
                dt_RESOLUCI.Columns.Add(New DataColumn("RESOARTE", GetType(String)))
                dt_RESOLUCI.Columns.Add(New DataColumn("RESOARCO", GetType(String)))
                dt_RESOLUCI.Columns.Add(New DataColumn("RESOSUPU", GetType(String)))
                dt_RESOLUCI.Columns.Add(New DataColumn("RESOPATO", GetType(String)))

                dr_RESOLUCI = dt_RESOLUCI.NewRow()

                dr_RESOLUCI("RESOIDRE") = stContenidoLinea.Substring(0, 1).ToString
                dr_RESOLUCI("RESOVIGE") = stContenidoLinea.Substring(1, 4).ToString
                dr_RESOLUCI("RESOTIRE") = stContenidoLinea.Substring(5, 3).ToString
                dr_RESOLUCI("RESORESO") = stContenidoLinea.Substring(8, 7).ToString
                dr_RESOLUCI("RESOMUNI") = stContenidoLinea.Substring(15, 3).ToString
                dr_RESOLUCI("RESOCLSE") = stContenidoLinea.Substring(18, 1).ToString
                dr_RESOLUCI("RESONURE") = stContenidoLinea.Substring(19, 7).ToString
                dr_RESOLUCI("RESOARTE") = stContenidoLinea.Substring(26, 12).ToString
                dr_RESOLUCI("RESOARCO") = stContenidoLinea.Substring(38, 10).ToString
                dr_RESOLUCI("RESOSUPU") = stContenidoLinea.Substring(48, 10).ToString
                dr_RESOLUCI("RESOPATO") = stContenidoLinea.Substring(58, 1).ToString

                dt_RESOLUCI.Rows.Add(dr_RESOLUCI)

                ' almacena el numero de ficha predial
                stNroDeFichaPredial = stRESOLUCION

                ' valida los datos cargados
                pro_VALIDAR_CARGA_FICHA_PREDIAL(dt_RESOLUCI, dt_FICHPRED, dt_FIPRDEEC, dt_FIPRPROP, dt_FIPRCONS, dt_FIPRCACO, dt_FIPRLIND, dt_FIPRCART, stRESOLUCION, stNroDeFichaPredial, False, False)

            End If

            ' Tabla FIPRPROP
            If stContenidoRegistro = "4" Then

                Dim dr_FIPRPROP As DataRow

                ' TABLA FIPRPROP
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRIDRE", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRVIGE", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRTIRE", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRRESO", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRNUFI", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRNURE", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRTIDO", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRNUDO", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRPRAP", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRNOMB", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRDERE", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRNOTA", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRESCR", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRFEES", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRFERE", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRTOMO", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRMAIN", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRCAPR", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRGRAV", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRMOAD", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRLITI", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRPOLI", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRSEAP", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRSICO", GetType(String)))
                dt_FIPRPROP.Columns.Add(New DataColumn("FPPRSEXO", GetType(String)))

                dr_FIPRPROP = dt_FIPRPROP.NewRow()

                dr_FIPRPROP("FPPRIDRE") = stContenidoLinea.Substring(0, 1).ToString
                dr_FIPRPROP("FPPRVIGE") = stContenidoLinea.Substring(1, 4).ToString
                dr_FIPRPROP("FPPRTIRE") = stContenidoLinea.Substring(5, 3).ToString
                dr_FIPRPROP("FPPRRESO") = stContenidoLinea.Substring(8, 7).ToString
                dr_FIPRPROP("FPPRNUFI") = stContenidoLinea.Substring(15, 9).ToString
                dr_FIPRPROP("FPPRNURE") = stContenidoLinea.Substring(24, 5).ToString
                dr_FIPRPROP("FPPRTIDO") = stContenidoLinea.Substring(29, 2).ToString
                dr_FIPRPROP("FPPRNUDO") = stContenidoLinea.Substring(31, 14).ToString
                dr_FIPRPROP("FPPRPRAP") = stContenidoLinea.Substring(45, 15).ToString
                dr_FIPRPROP("FPPRNOMB") = stContenidoLinea.Substring(60, 20).ToString
                dr_FIPRPROP("FPPRDERE") = stContenidoLinea.Substring(80, 9).ToString
                dr_FIPRPROP("FPPRNOTA") = stContenidoLinea.Substring(89, 10).ToString
                dr_FIPRPROP("FPPRESCR") = stContenidoLinea.Substring(99, 7).ToString
                dr_FIPRPROP("FPPRFEES") = stContenidoLinea.Substring(106, 10).ToString
                dr_FIPRPROP("FPPRFERE") = stContenidoLinea.Substring(116, 10).ToString
                dr_FIPRPROP("FPPRTOMO") = stContenidoLinea.Substring(126, 3).ToString
                dr_FIPRPROP("FPPRMAIN") = stContenidoLinea.Substring(129, 15).ToString
                dr_FIPRPROP("FPPRCAPR") = stContenidoLinea.Substring(144, 2).ToString
                dr_FIPRPROP("FPPRGRAV") = stContenidoLinea.Substring(146, 1).ToString
                dr_FIPRPROP("FPPRMOAD") = stContenidoLinea.Substring(147, 1).ToString
                dr_FIPRPROP("FPPRLITI") = stContenidoLinea.Substring(148, 1).ToString
                dr_FIPRPROP("FPPRPOLI") = stContenidoLinea.Substring(149, 5).ToString
                dr_FIPRPROP("FPPRSEAP") = stContenidoLinea.Substring(154, 15).ToString
                dr_FIPRPROP("FPPRSICO") = stContenidoLinea.Substring(169, 20).ToString
                dr_FIPRPROP("FPPRSEXO") = stContenidoLinea.Substring(189, 1).ToString

                dt_FIPRPROP.Rows.Add(dr_FIPRPROP)

                ' almacena el numero de ficha predial
                stNroDeFichaPredial = stContenidoLinea.Substring(15, 9).ToString

                ' valida los datos cargados
                pro_VALIDAR_CARGA_FICHA_PREDIAL(dt_RESOLUCI, dt_FICHPRED, dt_FIPRDEEC, dt_FIPRPROP, dt_FIPRCONS, dt_FIPRCACO, dt_FIPRLIND, dt_FIPRCART, stRESOLUCION, stNroDeFichaPredial, False, False)


            End If

            ' Incrementa la barra
            inProceso = inProceso + 1
            pbPROCESO.Value = inProceso

        Loop

        ' consulta las inconsistencas de las fichas validadas
        Dim objdatos As New cla_VALIFIPR
        Dim tbl As New DataTable

        tbl = objdatos.fun_Consultar_INCONSISTENCIA_X_RESOLUCION(stRESOLUCION)

        ' Crea objeto de columnas y registros
        Dim dt1 As New DataTable
        Dim dr1 As DataRow

        ' Crea las columnas
        dt1.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
        dt1.Columns.Add(New DataColumn("Cedula catastral", GetType(String)))
        dt1.Columns.Add(New DataColumn("Codigo incons.", GetType(String)))
        dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))

        Dim i As Integer

        For i = 0 To tbl.Rows.Count - 1

            dr1 = dt1.NewRow()
            dr1("Nro_Ficha") = tbl.Rows(i).Item("FPINNUFI")
            dr1("Cedula catastral") = tbl.Rows(i).Item("FPINMUNI") & "-" & _
                                      tbl.Rows(i).Item("FPINCORR") & "-" & _
                                      tbl.Rows(i).Item("FPINBARR") & "-" & _
                                      tbl.Rows(i).Item("FPINMANZ") & "-" & _
                                      tbl.Rows(i).Item("FPINPRED") & "-" & _
                                      tbl.Rows(i).Item("FPINEDIF") & "-" & _
                                      tbl.Rows(i).Item("FPINUNPR")
            dr1("Codigo incons.") = tbl.Rows(i).Item("FPINCODI")
            dr1("Descripcion") = tbl.Rows(i).Item("FPINDESC")
            dt1.Rows.Add(dr1)

        Next

        ' Llena el datagrigview
        TabControl1.SelectTab(TabPage1)
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

        Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRINCO.RowCount

    End Sub
    Private Sub pro_GuardarDatosFichaPredial()

        Try
            ' apaga el boton
            Me.cmdGrabarDatos.Enabled = False

            ' declaro la variable
            Dim stMENSAJE As String = "Se guardo el propietario en base de datos"

            ' Crea objeto de columnas y registros
            Dim dt1 As New DataTable
            Dim dr1 As DataRow

            ' Crea las columnas
            dt1.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
            dt1.Columns.Add(New DataColumn("Operacion", GetType(String)))
            dt1.Columns.Add(New DataColumn("Calidad_Propietario", GetType(String)))
            dt1.Columns.Add(New DataColumn("Tipo_Documento", GetType(String)))
            dt1.Columns.Add(New DataColumn("Nro_Documento", GetType(String)))
            dt1.Columns.Add(New DataColumn("Propietario_Actual", GetType(String)))
            dt1.Columns.Add(New DataColumn("Porcentaje", GetType(String)))
            dt1.Columns.Add(New DataColumn("Propietario_Anterior", GetType(String)))
            dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
            dt1.Columns.Add(New DataColumn("Fecha_Escritura", GetType(String)))

            ' abre el archivo
            FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

            ' almacena la linea
            Dim stContenidoLinea As String = ""
            Dim stContenidoRegistro As String = ""
            Dim inNroDeCaracteresLindero As Integer = 0
            Dim inNroDeCaracteresCartografia As Integer = 0
            Dim stNroDeFichaPredial As String = ""
            Dim inNroDeRegistroDelPlano As Integer = 0

            Dim inFichaAnterior As Integer = 0

            Dim stFPPRCAPR_11 As String = ""
            Dim stFPPRTIDO_11 As String = ""
            Dim stFPPRNUDO_11 As String = ""
            Dim stFPPRNOMB_11 As String = ""
            Dim stFPPRPRAP_11 As String = ""
            Dim stFPPRSEAP_11 As String = ""
            Dim stFPPRCAAC_11 As String = ""
            Dim stFPPROBSE_11 As String = ""
            Dim stFPPRESTA_11 As String = ""
            Dim stFPPRFEES_11 As String = ""

            'declaro la variable
            Dim bySW As Byte = 0

            ' Valores predeterminados ProgressBar
            inProceso = 0
            Me.pbPROCESO.Value = 0
            Me.pbPROCESO.Maximum = inTotalRegistros + 1
            Me.Timer1.Enabled = True

            ' recorre el archivo plano y repita hasta que se acabe las lineas
            Do Until EOF(1)

                ' numero de registro del plano utilizado en codigos asignados
                inNroDeRegistroDelPlano += 1

                a = inNroDeRegistroDelPlano

                ' extrae la linea
                stContenidoLinea = LineInput(1)

                ' verifica cual es el registro de la tabla
                stContenidoRegistro = stContenidoLinea.Substring(0, 1).ToString

                '================================
                '*** Inserta tabla RESOLUCION ***
                '================================
                If stContenidoRegistro = "1" Then

                    ' variables indirectas
                    Dim stRESODEPA As String = "05"
                    Dim boRESOPATO As Boolean = False
                    Dim stRESOESTA As String = "ac"

                    ' variables directas
                    Dim inRESOIDRE As Integer = stContenidoLinea.Substring(0, 1).ToString
                    Dim inRESOVIGE As Integer = stContenidoLinea.Substring(1, 4).ToString
                    Dim inRESOTIRE As Integer = stContenidoLinea.Substring(5, 3).ToString
                    Dim inRESORESO As Integer = stContenidoLinea.Substring(8, 7).ToString
                    Dim stRESOMUNI As String = stContenidoLinea.Substring(15, 3).ToString
                    Dim inRESOCLSE As Integer = stContenidoLinea.Substring(18, 1).ToString
                    Dim inRESONURE As Integer = stContenidoLinea.Substring(19, 7).ToString
                    Dim loRESOARTE As Long = stContenidoLinea.Substring(26, 12).ToString
                    Dim inRESOARCO As Integer = stContenidoLinea.Substring(38, 10).ToString
                    Dim inRESOSUPU As Integer = stContenidoLinea.Substring(48, 10).ToString
                    Dim inRESOPATO As Integer = stContenidoLinea.Substring(58, 1).ToString

                    ' instancia el objeto
                    Dim objdatos1 As New cla_RESOLUCION
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_TIPO_Y_CLASE_Y_VIGENCIA_Y_CODIGO_RESOLUCION(stRESODEPA, stRESOMUNI, inRESOTIRE, inRESOCLSE, inRESOVIGE, inRESORESO)

                    ' verifica si la resolucion existe
                    If tbl1.Rows.Count > 0 Then

                        ' almacena la resolucion
                        vl_stRESODEPA = stRESODEPA
                        vl_stRESOMUNI = stRESOMUNI
                        vl_inRESOVIGE = inRESOVIGE
                        vl_inRESOTIRE = inRESOTIRE
                        vl_inRESORESO = inRESORESO
                        vl_inRESOCLSE = inRESOCLSE

                    Else
                        MessageBox.Show("Resolución no existe", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)

                        ' sale del proceso
                        Exit Sub

                    End If

                End If

                '==============================
                '*** Inserta tabla FIPRPROP ***
                '==============================
                If stContenidoRegistro = "4" Then

                    ' variables indirectas
                    Dim stFPPRESTA As String = "ac"
                    Dim inFPPRNURE As Integer = 0
                    Dim inFPPRSECU As Integer = 0
                    Dim boFPPRGRAV As Boolean = False
                    Dim boFPPRLITI As Boolean = False
                    Dim stFPPRDENO As String = ""
                    Dim stFPPRMUNO As String = ""

                    ' variables directas
                    Dim inFPPRNUFI As Integer = stContenidoLinea.Substring(15, 9).ToString
                    Dim inFPPRTIDO As Integer = stContenidoLinea.Substring(29, 2).ToString
                    Dim stFPPRNUDO As String = stContenidoLinea.Substring(31, 14).ToString
                    Dim sTFPPRPRAP As String = Trim(stContenidoLinea.Substring(45, 15).ToString)
                    Dim stFPPRNOMB As String = Trim(stContenidoLinea.Substring(60, 20).ToString)
                    Dim stFPPRDERE As String = stContenidoLinea.Substring(80, 9).ToString
                    Dim stFPPRNOTA As String = stContenidoLinea.Substring(89, 10).ToString
                    Dim inFPPRESCR As Integer = stContenidoLinea.Substring(99, 7).ToString
                    Dim stFPPRFEES As String = stContenidoLinea.Substring(106, 10).ToString
                    Dim stFPPRFERE As String = stContenidoLinea.Substring(116, 10).ToString
                    Dim inFPPRTOMO As Integer = stContenidoLinea.Substring(126, 3).ToString
                    Dim stFPPRMAIN As String = stContenidoLinea.Substring(129, 15).ToString
                    Dim inFPPRCAPR As Integer = stContenidoLinea.Substring(144, 2).ToString
                    Dim inFPPRGRAV As Integer = stContenidoLinea.Substring(146, 1).ToString
                    Dim inFPPRMOAD As Integer = stContenidoLinea.Substring(147, 1).ToString
                    Dim inFPPRLITI As Integer = stContenidoLinea.Substring(148, 1).ToString
                    Dim stFPPRPOLI As String = stContenidoLinea.Substring(149, 5).ToString
                    Dim stFPPRSEAP As String = Trim(stContenidoLinea.Substring(154, 15).ToString)
                    Dim stFPPRSICO As String = stContenidoLinea.Substring(169, 20).ToString
                    Dim inFPPRSEXO As Integer = stContenidoLinea.Substring(189, 1).ToString

                    ' optiene la longitud del nit 9 digitos
                    If inFPPRTIDO = 3 And stFPPRNUDO.ToString.Length = 10 Or stFPPRNUDO.ToString.Length = 11 Then
                        stFPPRNUDO = stFPPRNUDO.Substring(0, 9).ToString
                    End If

                    ' campo derecho
                    Dim stFPPRDERE_1 As String = Val(stFPPRDERE.Substring(0, 3))
                    Dim stFPPRDERE_2 As String = "."
                    Dim stFPPRDERE_3 As String = stFPPRDERE.Substring(3, 6)
                    Dim stFPPRDERE_4 As String = stFPPRDERE_1 & stFPPRDERE_2 & stFPPRDERE_3

                    stFPPRDERE = CType(fun_Formato_Decimal_6_Decimales(stFPPRDERE_4), String)

                    ' campo porcentaje de litigio
                    Dim stFPPRPOLI_1 As String = Val(stFPPRPOLI.Substring(0, 3))
                    Dim stFPPRPOLI_2 As String = "."
                    Dim stFPPRPOLI_3 As String = stFPPRPOLI.Substring(3, 2)
                    Dim stFPPRPOLI_4 As String = stFPPRPOLI_1 & stFPPRPOLI_2 & stFPPRPOLI_3

                    stFPPRPOLI = CType(fun_Formato_Decimal_2_Decimales(stFPPRPOLI_4), String)

                    ' verifica el formato de las fechas
                    If fun_Verificar_Dato_Fecha_Evento_Validated(stFPPRFEES) = True Then

                        Dim stFPPRFEES_1 As String = stFPPRFEES.Replace("/", "-").ToString
                        stFPPRFEES = stFPPRFEES_1

                        Dim stDia As String = stFPPRFEES.ToString.Substring(0, 2)
                        Dim stMes As String = stFPPRFEES.ToString.Substring(3, 2)
                        Dim stAno As String = stFPPRFEES.ToString.Substring(6, 4)

                        stFPPRFEES = stDia & "-" & stMes & "-" & stAno
                    Else
                        stFPPRFEES = ""
                    End If

                    If fun_Verificar_Dato_Fecha_Evento_Validated(stFPPRFERE) = True Then

                        Dim stFPPRFERE_1 As String = stFPPRFERE.Replace("/", "-").ToString
                        stFPPRFERE = stFPPRFERE_1

                        Dim stDia As String = stFPPRFERE.ToString.Substring(0, 2)
                        Dim stMes As String = stFPPRFERE.ToString.Substring(3, 2)
                        Dim stAno As String = stFPPRFERE.ToString.Substring(6, 4)

                        stFPPRFERE = stDia & "-" & stMes & "-" & stAno
                    Else
                        stFPPRFERE = ""
                    End If

                    ' verifica el formato de la notaria
                    stFPPRDENO = Trim(stFPPRNOTA.Substring(0, 2).ToString)
                    stFPPRMUNO = Trim(stFPPRNOTA.Substring(2, 3).ToString)
                    stFPPRNOTA = Trim(stFPPRNOTA.Substring(5, 5).ToString)

                    ' convierte en variable boleona
                    If inFPPRGRAV = 1 Then
                        boFPPRGRAV = True
                    Else
                        boFPPRGRAV = False
                    End If

                    If inFPPRLITI = 1 Then
                        boFPPRLITI = True
                    Else
                        boFPPRLITI = False
                    End If

                    ' instancia la ficha predial
                    Dim objdatos1 As New cla_FICHPRED
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_buscar_NRO_FICHA_FICHPRED(inFPPRNUFI)

                    ' verifica si existe la ficha predial
                    If tbl1.Rows.Count > 0 Then

                        ' busca el numero de registro
                        inFPPRNURE = Val(tbl1.Rows(0).Item("FIPRNURE"))

                        ' asigna numero de documento para codigo asignado
                        If Trim(stFPPRNUDO) = "" Then
                            stFPPRNUDO = inNroDeRegistroDelPlano
                        End If

                        ' instancia la clase
                        Dim obj2_FIPRPROP As New cla_FIPRPROP
                        Dim tbl2 As New DataTable

                        ' consulta si ya existe el propietario
                        tbl2 = obj2_FIPRPROP.fun_Buscar_CODIGO_FIPRPROP(inFPPRNUFI, Trim(stFPPRNUDO))

                        ' declaro la instancia
                        Dim obFIPRPROP2 As New cla_FIPRPROP
                        Dim dtFIPRPROP2 As New DataTable

                        ' carga todos los registros
                        dtFIPRPROP2 = obFIPRPROP2.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(inFPPRNUFI)

                        ' declaro la variable
                        Dim inCodigo As Integer = 8

                        Dim filas1() As DataRow
                        filas1 = dtFIPRPROP2.Select("FPPRTIDO =  '" & inCodigo & "' ")

                        ' verifica el dato numerico
                        If stFPPRFEES.ToString.Length = 10 AndAlso fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRFEES.ToString.Substring(6, 4)) = True Then

                            ' alamcena la vigencia
                            Dim inVigenciaFechaEscritura As Integer = stFPPRFEES.ToString.Substring(6, 4)

                            ' compara la vigencia
                            If inVigenciaFechaEscritura = Me.cboVIACVIAC.SelectedValue Then

                                ' inactiva los propietarios
                                If inFichaAnterior <> inFPPRNUFI Then
                                    pro_InactivarPropietarios(inFPPRNUFI)
                                End If

                                ' no existe el documento y ningun tipo de documento es 8
                                If tbl2.Rows.Count = 0 And filas1.Length = 0 Then

                                    ' solo optiene un propietario anerior
                                    If inFichaAnterior <> inFPPRNUFI Then

                                        ' almacena el propietario actual
                                        stFPPRCAPR_11 = Trim(dtFIPRPROP2.Rows(0).Item("FPPRCAPR").ToString)
                                        stFPPRTIDO_11 = Trim(dtFIPRPROP2.Rows(0).Item("FPPRTIDO").ToString)
                                        stFPPRNUDO_11 = Trim(dtFIPRPROP2.Rows(0).Item("FPPRNUDO").ToString)
                                        stFPPRNOMB_11 = Trim(dtFIPRPROP2.Rows(0).Item("FPPRNOMB").ToString)
                                        stFPPRPRAP_11 = Trim(dtFIPRPROP2.Rows(0).Item("FPPRPRAP").ToString)
                                        stFPPRSEAP_11 = Trim(dtFIPRPROP2.Rows(0).Item("FPPRSEAP").ToString)
                                        stFPPRCAAC_11 = Me.cboPRANCAAC.SelectedValue
                                        stFPPROBSE_11 = "Propietario anterior insertado por mutación"
                                        stFPPRESTA_11 = Trim(dtFIPRPROP2.Rows(0).Item("FPPRESTA").ToString)
                                    End If

                                    ' instancia la clase 
                                    Dim obj_FIPRPROP As New cla_FIPRPROP

                                    ' inserta registro
                                    If obj_FIPRPROP.fun_Insertar_FIPRPROP(inFPPRNUFI, inFPPRCAPR, inFPPRSEXO, inFPPRTIDO, stFPPRNUDO, sTFPPRPRAP, stFPPRSEAP, stFPPRNOMB, stFPPRDERE, stFPPRSICO, inFPPRESCR, stFPPRDENO, stFPPRMUNO, stFPPRNOTA, stFPPRFEES, stFPPRFERE, inFPPRTOMO, stFPPRMAIN, boFPPRGRAV, inFPPRMOAD, boFPPRLITI, stFPPRPOLI, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPPRSECU, inFPPRNURE, stFPPRESTA) = True Then

                                        ' inserta el registro
                                        dr1 = dt1.NewRow()

                                        dr1("Nro_Ficha") = Trim(inFPPRNUFI)
                                        dr1("Operacion") = "Insertado"
                                        dr1("Calidad_Propietario") = Trim(inFPPRCAPR)
                                        dr1("Tipo_Documento") = Trim(inFPPRTIDO)
                                        dr1("Nro_Documento") = Trim(stFPPRNUDO)
                                        dr1("Propietario_Actual") = Trim(stFPPRNOMB) & " " & Trim(sTFPPRPRAP) & " " & Trim(stFPPRSEAP)
                                        dr1("Porcentaje") = Trim(stFPPRDERE)
                                        dr1("Propietario_Anterior") = Trim(stFPPRNOMB_11) & " " & Trim(stFPPRSEAP_11) & " " & Trim(stFPPRSEAP_11)
                                        dr1("Descripcion") = Trim(stMENSAJE)
                                        dr1("Fecha_Escritura") = Trim(stFPPRFEES) & "."

                                        dt1.Rows.Add(dr1)

                                    End If

                                    ' instancia la clase
                                    Dim obj_PROPANTE As New cla_PROPANTE

                                    ' elimina el registro
                                    obj_PROPANTE.fun_Eliminar_PROPANTE_X_NRO_FICHA_Y_NRO_DOCUMENTO(inFPPRNUFI, Trim(stFPPRNUDO))

                                    ' inserta el registro
                                    obj_PROPANTE.fun_Insertar_PROPANTE(inFPPRNUFI, stFPPRNUDO, stFPPRPRAP_11, stFPPRSEAP_11, stFPPRNOMB_11, stFPPRCAAC_11, stFPPROBSE_11, stFPPRESTA_11)

                                    ' instancia la clase tercero
                                    Dim obj_TERCERO As New cla_TERCERO
                                    Dim tbl_TERCERO As New DataTable

                                    tbl_TERCERO = obj_TERCERO.fun_Buscar_CODIGO_TERCERO(stFPPRNUDO)

                                    If tbl_TERCERO.Rows.Count = 0 Then

                                        Dim obj1_TERCERO As New cla_TERCERO

                                        ' inserta registro
                                        obj1_TERCERO.fun_Insertar_TERCERO(stFPPRNUDO, inFPPRTIDO, inFPPRCAPR, inFPPRSEXO, stFPPRNOMB, sTFPPRPRAP, stFPPRSEAP, stFPPRSICO, "", "", "", "", "ac", "Tercero ingresado por importación de datos")

                                    End If

                                    ' si existe el documento y ningun tipo de documento es 8
                                ElseIf tbl2.Rows.Count >= 1 And filas1.Length = 0 Then

                                    ' declara la variable
                                    Dim inFPPRIDRE As Integer = CInt(tbl2.Rows(0).Item("FPPRIDRE").ToString)
                                    Dim stFPPRUSIN As String = Trim(tbl2.Rows(0).Item("FPPRUSIN").ToString)
                                    Dim daFPPRFEIN As Date = tbl2.Rows(0).Item("FPPRFEIN")

                                    ' instancia la clase 
                                    Dim obj_FIPRPROP As New cla_FIPRPROP

                                    ' actualiza registro
                                    If obj_FIPRPROP.fun_Actualizar_FIPRPROP(inFPPRIDRE, inFPPRNUFI, inFPPRCAPR, inFPPRSEXO, inFPPRTIDO, stFPPRNUDO, sTFPPRPRAP, stFPPRSEAP, stFPPRNOMB, stFPPRDERE, stFPPRSICO, inFPPRESCR, stFPPRDENO, stFPPRMUNO, stFPPRNOTA, stFPPRFEES, stFPPRFERE, inFPPRTOMO, stFPPRMAIN, boFPPRGRAV, inFPPRMOAD, boFPPRLITI, stFPPRPOLI, vl_stRESODEPA, vl_stRESOMUNI, vl_inRESOTIRE, vl_inRESOCLSE, vl_inRESOVIGE, vl_inRESORESO, inFPPRSECU, inFPPRNURE, stFPPRESTA, stFPPRUSIN, daFPPRFEIN) = True Then

                                        ' inserta el registro
                                        dr1 = dt1.NewRow()

                                        dr1("Nro_Ficha") = Trim(inFPPRNUFI)
                                        dr1("Operacion") = "Actualizado"
                                        dr1("Calidad_Propietario") = Trim(inFPPRCAPR)
                                        dr1("Tipo_Documento") = Trim(inFPPRTIDO)
                                        dr1("Nro_Documento") = Trim(stFPPRNUDO)
                                        dr1("Propietario_Actual") = Trim(stFPPRNOMB) & " " & Trim(sTFPPRPRAP) & " " & Trim(stFPPRSEAP)
                                        dr1("Porcentaje") = Trim(stFPPRDERE)
                                        dr1("Propietario_Anterior") = Trim(stFPPRNOMB_11) & " " & Trim(stFPPRSEAP_11) & " " & Trim(stFPPRSEAP_11)
                                        dr1("Descripcion") = Trim(stMENSAJE)
                                        dr1("Fecha_Escritura") = Trim(stFPPRFEES) & "."

                                        dt1.Rows.Add(dr1)

                                    End If

                                End If

                            End If

                        End If

                        ' la ficha actual la vuelve anterior
                        inFichaAnterior = inFPPRNUFI

                    End If

                End If

                ' Incrementa la barra
                inProceso = inProceso + 1
                pbPROCESO.Value = inProceso

            Loop

            ' Llena el datagrigview
            TabControl1.SelectTab(TabPage1)
            Me.dgvFIPRINCO.DataSource = dt1
            pbPROCESO.Value = 0

            ' comando grabar datos
            If dt1.Rows.Count > 0 Then
                MessageBox.Show("Proceso de guardado terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("Proceso no reporto registros guardados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            ' prende el boton
            Me.cmdGrabarDatos.Enabled = True

            Me.cmdGrabarDatos.Enabled = False
            Me.lblFecha2.Visible = False
            Me.cmdValidaDatos.Enabled = False

            Me.cmdAbrirArchivo.Focus()

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRINCO.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description & inProceso)
        Finally
            FileClose(1)
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
            oLeer.Filter = "Archivo de texto (*.txt)|*.txt" 'Colocar varias extensiones
            oLeer.FilterIndex = 1 'coloca por defecto el *.txt
            oLeer.FileName = ""
            oLeer.ShowDialog()

            stRutaArchivo = Trim(oLeer.FileName)
            lblRUTA.Text = Trim(oLeer.FileName)

            ' selecciona ficha predial
            If Trim(stRutaArchivo) <> "" Then

                ' almacena la linea
                Dim stContenidoLinea As String = ""
                Dim stContenidoRegistro As String = ""

                ' abre el archivo
                FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                stContenidoLinea = LineInput(1)

                Me.txtRESODEPA.Text = "05"
                Me.txtRESOVIGE.Text = CType(fun_Formato_Mascara_4_Reales(stContenidoLinea.Substring(1, 4).ToString), String)
                Me.txtRESOTIRE.Text = CType(fun_Formato_Mascara_3_Reales(stContenidoLinea.Substring(5, 3).ToString), String)
                Me.txtRESOCODI.Text = CType(fun_Formato_Mascara_7_Reales(stContenidoLinea.Substring(8, 7).ToString), String)
                Me.txtRESOMUNI.Text = CType(fun_Formato_Mascara_3_Reales(stContenidoLinea.Substring(15, 3).ToString), String)
                Me.txtRESOCLSE.Text = stContenidoLinea.Substring(18, 1).ToString

                ' lista de valores
                Me.lblRESOCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(Me.txtRESOCLSE.Text)), String)
                Me.lblRESOTIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO(Trim(Me.txtRESOTIRE.Text)), String)
                Me.lblRESOMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO("05", Me.txtRESOMUNI.Text), String)
                Me.lblRESODEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Trim("05")), String)
                Me.lblRESOVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Trim(Me.txtRESOVIGE.Text)), String)
                Me.lblRESODESC.Text = CType(fun_Buscar_Lista_Valores_RESOLUCION(Trim(Me.txtRESODEPA.Text), Trim(Me.txtRESOMUNI.Text), Trim(Me.txtRESOTIRE.Text), Trim(Me.txtRESOCLSE.Text), Trim(Me.txtRESOVIGE.Text), Trim(Me.txtRESOCODI.Text)), String)

                ' Total de registros
                Do Until EOF(1)
                    stContenidoLinea = LineInput(1)
                    inTotalRegistros += 1
                Loop

                Me.strBARRESTA.Items(2).Text = "Registro : " & inTotalRegistros

                Me.cmdValidaDatos.Enabled = True
                Me.cmdValidaDatos.Focus()

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

            ' selecciona ficha predial
            If Trim(stRutaArchivo) <> "" Then

                pro_ValidarFichaPredial()

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
            If Me.dgvFIPRINCO.RowCount = 0 Then
                If Trim(stRutaArchivo) <> "" Then

                    pro_GuardarDatosFichaPredial()

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & a)
            MessageBox.Show("Error al guardar los datos, revise la integridad del archivo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        Finally
            FileClose(1)
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

            If Me.dgvFIPRINCO.RowCount <> 0 Then
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

        Dim objdatos23 As New cla_VIGENCIA

        Me.cboVIACVIAC.DataSource = objdatos23.fun_Consultar_CAMPOS_VIGENCIA
        Me.cboVIACVIAC.DisplayMember = "VIGEDESC"
        Me.cboVIACVIAC.ValueMember = "VIGECODI"

        Dim objdatos11 As New cla_CAUSACTO

        Me.cboPRANCAAC.DataSource = objdatos11.fun_Consultar_CAMPOS_MANT_CAUSACTO
        Me.cboPRANCAAC.DisplayMember = "CAACCODI"
        Me.cboPRANCAAC.ValueMember = "CAACCODI"

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

#Region "Click"

    Private Sub cmdSeleccionResolucion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ' seleccina ninguna resolución
            vp_inConsulta = 0

            ' llama el formulario de consulta
            Dim frm_RESOLUCION As New frm_consultar_RESOLUCION_PUBLICA
            frm_RESOLUCION.ShowDialog()

            ' verifica si hay alguna seleccionada
            If vp_inConsulta <> 0 Then

                Dim objdatos As New cla_RESOLUCION
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_RESOLUCION(vp_inConsulta)

                ' coloca los valores en los campos
                Me.txtRESODEPA.Text = CType(fun_Formato_Mascara_2_Reales(Trim(tbl.Rows(0).Item("RESODEPA"))), String)
                Me.txtRESOMUNI.Text = CType(fun_Formato_Mascara_3_Reales(Trim(tbl.Rows(0).Item("RESOMUNI"))), String)
                Me.txtRESOTIRE.Text = CType(fun_Formato_Mascara_3_Reales(Trim(tbl.Rows(0).Item("RESOTIRE"))), String)
                Me.txtRESOCLSE.Text = Trim(tbl.Rows(0).Item("RESOCLSE"))
                Me.txtRESOVIGE.Text = CType(fun_Formato_Mascara_4_Reales(Trim(tbl.Rows(0).Item("RESOVIGE"))), String)
                Me.txtRESOCODI.Text = CType(fun_Formato_Mascara_7_Reales(Trim(tbl.Rows(0).Item("RESOCODI"))), String)
                Me.lblRESODESC.Text = Trim(tbl.Rows(0).Item("RESODESC"))

                ' coloca la lista de valores
                Me.lblRESODEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Trim(Me.txtRESODEPA.Text)), String)
                Me.lblRESOMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Trim(Me.txtRESODEPA.Text), Trim(Me.txtRESOMUNI.Text)), String)
                Me.lblRESOTIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO(Trim(Me.txtRESOTIRE.Text)), String)
                Me.lblRESOCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(Me.txtRESOCLSE.Text)), String)
                Me.lblRESOVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Trim(Me.txtRESOVIGE.Text)), String)

                Me.cmdAbrirArchivo.Enabled = True
                Me.cmdAbrirArchivo.Focus()
            Else
                Me.cmdAbrirArchivo.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboPRANCAAC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPRANCAAC.SelectedIndexChanged
        Me.lblPRANCAAC.Text = CType(fun_Buscar_Lista_Valores_CAUSACTO(Me.cboPRANCAAC.Text), String)
    End Sub
    Private Sub cboVIACVIAC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVIACVIAC.SelectedIndexChanged
        Me.lblVIACVIAC.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboVIACVIAC), String)
    End Sub

#End Region

#End Region

End Class