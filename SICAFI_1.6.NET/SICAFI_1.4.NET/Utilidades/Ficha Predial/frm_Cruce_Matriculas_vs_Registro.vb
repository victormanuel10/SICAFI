Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_Cruce_Matriculas_vs_Registro

    '==============================================
    '*** CRUCE MATRICULAS MUNICIPIO VS REGISTRO ***
    '==============================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Cruce_Matriculas_vs_Registro
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Cruce_Matriculas_vs_Registro
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

    ' almacena la relación de fichas prediales
    Dim dt_FICHPRED_Municipio As New DataTable
    Dim dt_FICHPRED_Registro As New DataTable

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

    ' otros procesos
    Dim stRutaArchivo As String
    Dim inTotalRegistros As Integer

    ' crea los objetos datatable
    Dim dt_MATRICULA As New DataTable

    ' declaro la variable
    Dim inContador As Integer = 0

    Dim stMATRMATR As String = ""
    Dim stMATRNUCA As String = ""
    Dim stMATRVIGE As String = ""
    Dim stMATRCLSE As String = ""
    Dim stMATRDIRE As String = ""
    Dim stMATRLIND As String = ""
    Dim stMATRTIDO As String = ""
    Dim stMATRNUDO As String = ""
    Dim stMATRNOMB As String = ""
    Dim stMATRPRAP As String = ""
    Dim stMATRSEAP As String = ""
    Dim stMATRPODE As String = ""

    Dim stMATRRESU As String = ""

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.cboMATRDEPA.DataSource = New DataTable
        Me.cboMATRMUNI.DataSource = New DataTable
        Me.cboMATRCLSE.DataSource = New DataTable

        dt_FICHPRED_Municipio = New DataTable
        dt_FICHPRED_Registro = New DataTable

        dt_CargaIncoMunicipio = New DataTable
        dt_CargaIncoDepartamento = New DataTable

        Me.lblMATRDEPA.Text = ""
        Me.lblMATRMUNI.Text = ""
        Me.lblMATRCLSE.Text = ""
        Me.lblRUTA.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registro : 0"

        Me.cmdCruceMunicipioVsRegistro.Enabled = True
        Me.cmdCruceRegistroVsMunicipio.Enabled = True
        Me.cmdListadoDePrediosConMatricula.Enabled = True

        Me.dgvCONSULTA.DataSource = New DataTable

        inContador = 0

    End Sub
    Private Sub pro_ExportarPlano(ByVal dtl As DataTable)
        Try
            Me.dgvCONSULTA.DataSource = dtl

            If dgvCONSULTA.RowCount > 0 Then

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

                        With dgvCONSULTA
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
            Me.cmdCruceMunicipioVsRegistro.Enabled = False
            Me.cmdCruceRegistroVsMunicipio.Enabled = False
            Me.cmdListadoDePrediosConMatricula.Enabled = False

            pro_LimpiarCampos()

            Me.lblFlecha2.Visible = False

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

                ' Total de registros
                Do Until EOF(1)
                    stContenidoLinea = LineInput(1)
                    inTotalRegistros += 1
                Loop

                Me.strBARRESTA.Items(2).Text = "Registro : " & inTotalRegistros


                Me.cmdCruceMunicipioVsRegistro.Enabled = True
                Me.cmdCruceRegistroVsMunicipio.Enabled = True
                Me.cmdListadoDePrediosConMatricula.Enabled = True

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

            Me.lblFlecha2.Visible = False

            '==========================================
            '*** VERIFICA LA INTEGRIDAD DEL ARCHIVO ***
            '==========================================

            If Trim(stRutaArchivo) <> "" Then

                ' limpia los datagrigview
                Me.dgvCONSULTA.DataSource = New DataTable

                ' abre el archivo
                FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                ' almacena la linea
                Dim stContenidoLinea As String = ""
                Dim stContenidoRegistro As String = ""

                ' Valores predeterminados ProgressBar
                inProceso = 0
                pbPROCESO.Value = 0
                pbPROCESO.Maximum = inTotalRegistros + 1
                Timer1.Enabled = True

                ' crea tablas
                dt_MATRICULA = New DataTable

                ' Tabla ZONA ECONÓMICA
                Dim dr_MATRICULA As DataRow

                ' Crea las columnas
                dt_MATRICULA.Columns.Add(New DataColumn("Posicion", GetType(String)))
                dt_MATRICULA.Columns.Add(New DataColumn("Codigo incons.", GetType(String)))
                dt_MATRICULA.Columns.Add(New DataColumn("Descripcion", GetType(String)))

                ' selecciona el tipo de archivo
                If Me.rbdArchivoXML.Checked = True Then

                    Dim inContadorRegistro As Integer = 0

                    ' recorre el archivo plano y repita hasta que se acabe las lineas
                    Do Until EOF(1)

                        ' extrae la linea
                        stContenidoLinea = LineInput(1)

                        If stContenidoLinea = "" Then

                            inContadorRegistro += 1

                        End If

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbPROCESO.Value = inProceso

                    Loop

                    If inContadorRegistro = inProceso Then

                        dr_MATRICULA = dt_MATRICULA.NewRow()

                        dr_MATRICULA("Posicion") = inProceso + 1
                        dr_MATRICULA("Codigo incons.") = "01"
                        dr_MATRICULA("Descripcion") = "El registro " & inContadorRegistro & " esta en vacio"

                        dt_MATRICULA.Rows.Add(dr_MATRICULA)

                    End If

                    ' selecciona el tipo de archivo
                ElseIf Me.rbdArchivoEstructurado.Checked = True Then

                    Dim inContadorRegistro As Integer = 0

                    ' recorre el archivo plano y repita hasta que se acabe las lineas
                    Do Until EOF(1)

                        inContadorRegistro += 1

                        ' extrae la linea
                        stContenidoLinea = LineInput(1)

                        If stContenidoLinea = "" Then

                            dr_MATRICULA = dt_MATRICULA.NewRow()

                            dr_MATRICULA("Posicion") = inProceso + 1
                            dr_MATRICULA("Codigo incons.") = "01"
                            dr_MATRICULA("Descripcion") = "El registro " & inContadorRegistro & " esta en vacio"

                            dt_MATRICULA.Rows.Add(dr_MATRICULA)

                        Else

                            If stContenidoLinea.Substring(0, 1).ToString <> "0" Or _
                               stContenidoLinea.Substring(0, 1).ToString = " " Then

                                dr_MATRICULA = dt_MATRICULA.NewRow()

                                dr_MATRICULA("Posicion") = inProceso + 1
                                dr_MATRICULA("Codigo incons.") = "01"
                                dr_MATRICULA("Descripcion") = "Existe un valor NO numerico en el registro"

                                dt_MATRICULA.Rows.Add(dr_MATRICULA)

                            End If
                        End If

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbPROCESO.Value = inProceso

                    Loop


                End If

                ' Llena el datagrigview
                Me.dgvCONSULTA.DataSource = dt_MATRICULA
                Me.pbPROCESO.Value = 0

                ' comando grabar datos
                If dt_MATRICULA.Rows.Count = 0 Then
                    Me.cmdGrabarDatos.Enabled = True
                    Me.lblFlecha2.Visible = True
                    Me.cmdValidaDatos.Enabled = False
                    Me.cmdGrabarDatos.Focus()
                    MessageBox.Show("Proceso de validación terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    Me.cmdValidaDatos.Enabled = True
                    MessageBox.Show("Proceso de validación inconsistente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                End If

                Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCONSULTA.RowCount

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
            If Trim(Me.lblMATRDEPA.Text) = "" And Trim(Me.lblMATRMUNI.Text) = "" Then
                MessageBox.Show("Ingrese el departamento o municipio", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.cboMATRDEPA.Focus()
            Else
                If Me.dgvCONSULTA.RowCount = 0 Then
                    If Trim(stRutaArchivo) <> "" Then

                        ' apaga el boton
                        Me.cmdGrabarDatos.Enabled = False

                        ' limpia el datagrig
                        Me.dgvCONSULTA.DataSource = New DataTable

                        ' abre el archivo
                        FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                        ' almacena la linea
                        Dim stContenidoLinea As String = ""
                        Dim stNroDeFichaPredial As String = ""
                        Dim inNroDeRegistroDelPlano As Integer = 0

                        ' Valores predeterminados ProgressBar
                        inProceso = 0
                        pbPROCESO.Value = 0
                        pbPROCESO.Maximum = inTotalRegistros + 1
                        Timer1.Enabled = True

                        ' Crea objeto de columnas y registros
                        Dim dt1 As New DataTable
                        Dim dr1 As DataRow

                        ' Crea las columnas
                        dt1.Columns.Add(New DataColumn("Matricula", GetType(String)))
                        dt1.Columns.Add(New DataColumn("Nro_Catastro", GetType(String)))
                        dt1.Columns.Add(New DataColumn("Vigente", GetType(String)))
                        dt1.Columns.Add(New DataColumn("Sector", GetType(String)))
                        dt1.Columns.Add(New DataColumn("Direccion", GetType(String)))
                        dt1.Columns.Add(New DataColumn("Lindero", GetType(String)))
                        dt1.Columns.Add(New DataColumn("Tipo_Documento", GetType(String)))
                        dt1.Columns.Add(New DataColumn("Nro_Documento", GetType(String)))
                        dt1.Columns.Add(New DataColumn("Nombre", GetType(String)))

                        ' declara la variable
                        Dim stMATRDEPA As String = Trim(Me.cboMATRDEPA.Text)
                        Dim stMATRMUNI As String = Trim(Me.cboMATRMUNI.Text)

                        ' elimina todas las zonas de los predios
                        Do Until EOF(1)

                            ' extrae la linea
                            stContenidoLinea = LineInput(1)

                            Dim inNroDeCaracteres As Integer = stContenidoLinea.Length.ToString

                            ' selecciona el tipo de archivo
                            If Me.rbdArchivoEstructurado.Checked = True Then

                                stMATRMATR = stContenidoLinea.Substring(0, 12).ToString
                                stMATRNUCA = stContenidoLinea.Substring(12, 25).ToString
                                stMATRVIGE = stContenidoLinea.Substring(37, 1).ToString
                                stMATRCLSE = stContenidoLinea.Substring(38, 1).ToString
                                stMATRDIRE = Trim(stContenidoLinea.Substring(39, 120).ToString)
                                stMATRLIND = Trim(stContenidoLinea.Substring(159, 2000).ToString)
                                stMATRTIDO = stContenidoLinea.Substring(2159, 2).ToString
                                stMATRNUDO = stContenidoLinea.Substring(2161, 12).ToString
                                stMATRNOMB = Trim(stContenidoLinea.Substring(2173, (inNroDeCaracteres - 2173)).ToString)

                                ' quita los ceros
                                stMATRMATR = stMATRMATR.TrimStart("0").ToString
                                stMATRNUDO = stMATRNUDO.TrimStart("0").ToString

                                ' *** CONFIGURA LOS CAMPOS ***

                                If stMATRCLSE = "U" Then
                                    stMATRCLSE = "1"
                                End If

                                If stMATRCLSE = "R" Then
                                    stMATRCLSE = "2"
                                End If

                                ' *** ELIMINA EL REGISTRO ***

                                ' instancia la clase
                                Dim objdatos1 As New cla_MATRICULA

                                objdatos1.fun_Eliminar_MATRICULA(stMATRMATR, stMATRDEPA, stMATRMUNI, stMATRCLSE, stMATRNUDO)

                                ' *** GUARDA EL REGISTRO ***

                                ' instancia la clase
                                Dim objdatos As New cla_MATRICULA

                                objdatos.fun_Insertar_MATRICULA(Trim(stMATRMATR), _
                                                                Trim(stMATRNUCA), _
                                                                Trim(stMATRVIGE), _
                                                                Trim(stMATRCLSE), _
                                                                Trim(stMATRDIRE), _
                                                                Trim(stMATRLIND), _
                                                                Trim(stMATRTIDO), _
                                                                Trim(stMATRNUDO), _
                                                                Trim(stMATRNOMB), _
                                                                Trim(stMATRDEPA), _
                                                                Trim(stMATRMUNI))


                                ' Inserta el registro en el DataTable
                                'dr1 = dt1.NewRow()

                                'dr1("Matricula") = Trim(stMATRMATR)
                                'dr1("Nro_Catastro") = Trim(stMATRNUCA)
                                'dr1("Vigente") = Trim(stMATRVIGE)
                                'dr1("Sector") = Trim(stMATRCLSE)
                                'dr1("Direccion") = Trim(stMATRDIRE)
                                'dr1("Lindero") = Trim(stMATRLIND)
                                'dr1("Tipo_Documento") = Trim(stMATRTIDO)
                                'dr1("Nro_Documento") = Trim(stMATRNUDO)
                                'dr1("Nombre") = Trim(stMATRNOMB)

                                'dt1.Rows.Add(dr1)

                            End If

                            ' selecciona el tipo de archivo
                            If Me.rbdArchivoXML.Checked = True Then

                                Dim inLongitudRegistro As Integer = stContenidoLinea.Length

                                ' verifica la longitud 
                                If stContenidoLinea.Length >= 15 Then
                                    ' almacena la matricula inmobiliaria
                                    If stContenidoLinea.Substring(0, 15).ToString = "<FLI_MATRICULA>" Then
                                        If stContenidoLinea.ToString.Length > 15 Then
                                            stMATRMATR = fun_Extra_Informacion_Antes_del_Signo_Menor(stContenidoLinea.Substring(15, (inLongitudRegistro - 15)))
                                        End If
                                    End If
                                End If

                                '' verifica la longitud 
                                'If stContenidoLinea.Length >= 20 Then
                                '    ' almacena el tipo de documento
                                '    If stContenidoLinea.Substring(0, 20).ToString = "<CIU_TIPO_DOCUMENTO>" Then
                                '        If stContenidoLinea.ToString.Length > 20 Then
                                '            stMATRTIDO = fun_Extra_Informacion_Antes_del_Signo_Menor(stContenidoLinea.Substring(20, (inLongitudRegistro - 20)))
                                '        End If
                                '    End If
                                'End If

                                ' verifica la longitud 
                                If stContenidoLinea.Length >= 20 Then
                                    ' almacena la direccion
                                    If stContenidoLinea.Substring(0, 20).ToString = "<DIR_ESPECIFICACION>" Then
                                        If stContenidoLinea.ToString.Length > 20 Then
                                            stMATRDIRE = fun_Extra_Informacion_Antes_del_Signo_Menor(stContenidoLinea.Substring(20, (inLongitudRegistro - 20)))
                                        End If
                                    End If
                                End If

                                ' verifica la longitud 
                                If stContenidoLinea.Length >= 17 Then
                                    ' almacena la clase o sector
                                    If stContenidoLinea.Substring(0, 17).ToString = "<FLI_TIPO_PREDIO>" Then
                                        If stContenidoLinea.ToString.Length > 17 Then
                                            stMATRCLSE = fun_Extra_Informacion_Antes_del_Signo_Menor(stContenidoLinea.Substring(17, (inLongitudRegistro - 17)))

                                            If stMATRCLSE = "U" Then
                                                stMATRCLSE = "1"
                                            ElseIf stMATRCLSE = "R" Then
                                                stMATRCLSE = "2"
                                            Else
                                                stMATRCLSE = ""
                                            End If

                                            ' *** ELIMINA EL REGISTRO ***
                                            ' instancia la clase
                                            Dim objdatos1 As New cla_MATRICULA
                                            objdatos1.fun_Eliminar_MATRICULA_X_MUNICIPIO(Trim(stMATRDEPA), Trim(stMATRMUNI), Trim(stMATRCLSE))

                                            ' concatena el nombre y apellidos
                                            stMATRNOMB = stMATRNOMB & " " & stMATRPRAP & " " & stMATRSEAP

                                            ' *** GUARDA EL REGISTRO ***
                                            ' instancia la clase
                                            Dim objdatos As New cla_MATRICULA
                                            objdatos.fun_Insertar_MATRICULA(Trim(stMATRMATR), _
                                                                            Trim(stMATRNUCA), _
                                                                            Trim(stMATRVIGE), _
                                                                            Trim(stMATRCLSE), _
                                                                            Trim(stMATRDIRE), _
                                                                            Trim(stMATRLIND), _
                                                                            Trim(stMATRTIDO), _
                                                                            Trim(stMATRNUDO), _
                                                                            Trim(stMATRNOMB), _
                                                                            Trim(stMATRDEPA), _
                                                                            Trim(stMATRMUNI))

                                            stMATRMATR = ""
                                            stMATRCLSE = ""
                                            stMATRDIRE = ""

                                        End If
                                    End If
                                End If

                                '' verifica la longitud 
                                '    If stContenidoLinea.Length >= 15 Then
                                '        ' almacena el numero de documento
                                '        If stContenidoLinea.Substring(0, 15).ToString = "<CIU_DOCUMENTO>" Then
                                '            If stContenidoLinea.ToString.Length > 15 Then
                                '                stMATRNUDO = fun_Extra_Informacion_Antes_del_Signo_Menor(stContenidoLinea.Substring(15, (inLongitudRegistro - 15)))
                                '            End If
                                '        End If
                                '    End If

                                '    ' verifica la longitud 
                                '    If stContenidoLinea.Length >= 15 Then
                                '        ' almacena el primer apellido
                                '        If stContenidoLinea.Substring(0, 15).ToString = "<CIU_APELLIDO1>" Then
                                '            If stContenidoLinea.ToString.Length > 15 Then
                                '                stMATRPRAP = fun_Extra_Informacion_Antes_del_Signo_Menor(stContenidoLinea.Substring(15, (inLongitudRegistro - 15)))
                                '            End If
                                '        End If
                                '    End If

                                '    ' verifica la longitud 
                                '    If stContenidoLinea.Length >= 15 Then
                                '        ' almacena el segundo apellido
                                '        If stContenidoLinea.Substring(0, 15).ToString = "<CIU_APELLIDO2>" Then
                                '            If stContenidoLinea.ToString.Length > 15 Then
                                '                stMATRSEAP = fun_Extra_Informacion_Antes_del_Signo_Menor(stContenidoLinea.Substring(15, (inLongitudRegistro - 15)))
                                '            End If
                                '        End If
                                '    End If

                                '    ' verifica la longitud 
                                '    If stContenidoLinea.Length >= 12 Then
                                '        ' almacena el nombre
                                '        If stContenidoLinea.Substring(0, 12).ToString = "<CIU_NOMBRE>" Then
                                '            If stContenidoLinea.ToString.Length > 12 Then
                                '                stMATRNOMB = fun_Extra_Informacion_Antes_del_Signo_Menor(stContenidoLinea.Substring(12, (inLongitudRegistro - 12)))
                                '            End If
                                '        End If
                                '    End If

                                '    ' verifica la longitud 
                                '    If stContenidoLinea.Length >= 16 Then
                                '        ' almacena el porcentaje
                                '        If stContenidoLinea.Substring(0, 16).ToString = "<ANC_PORCENTAJE>" Then
                                '            If stContenidoLinea.ToString.Length > 16 Then
                                '            stMATRPODE = fun_Extra_Informacion_Antes_del_Signo_Menor(stContenidoLinea.Substring(16, (inLongitudRegistro - 16)))

                                '                ' *** ELIMINA EL REGISTRO ***
                                '                ' instancia la clase
                                '                Dim objdatos1 As New cla_MATRICULA
                                '            objdatos1.fun_Eliminar_MATRICULA(Trim(stMATRMATR), Trim(stMATRDEPA), Trim(stMATRMUNI), Trim(stMATRCLSE), Trim(stMATRNUDO))

                                '                ' concatena el nombre y apellidos
                                '                stMATRNOMB = stMATRNOMB & " " & stMATRPRAP & " " & stMATRSEAP

                                '                ' *** GUARDA EL REGISTRO ***
                                '                ' instancia la clase
                                '                Dim objdatos As New cla_MATRICULA
                                '                objdatos.fun_Insertar_MATRICULA(Trim(stMATRMATR), _
                                '                                                Trim(stMATRNUCA), _
                                '                                                Trim(stMATRVIGE), _
                                '                                                Trim(stMATRCLSE), _
                                '                                                Trim(stMATRDIRE), _
                                '                                                Trim(stMATRLIND), _
                                '                                                Trim(stMATRTIDO), _
                                '                                                Trim(stMATRNUDO), _
                                '                                                Trim(stMATRNOMB), _
                                '                                                Trim(stMATRDEPA), _
                                '                                                Trim(stMATRMUNI))

                                '                ' Inserta el registro en el DataTable
                                '            'dr1 = dt1.NewRow()

                                '            'dr1("Matricula") = Trim(stMATRMATR)
                                '            'dr1("Nro_Catastro") = Trim(stMATRNUCA)
                                '            'dr1("Vigente") = Trim(stMATRVIGE)
                                '            'dr1("Sector") = Trim(stMATRCLSE)
                                '            'dr1("Direccion") = Trim(stMATRDIRE)
                                '            'dr1("Lindero") = Trim(stMATRLIND)
                                '            'dr1("Tipo_Documento") = Trim(stMATRTIDO)
                                '            'dr1("Nro_Documento") = Trim(stMATRNUDO)
                                '            'dr1("Nombre") = Trim(stMATRNOMB)

                                '            'dt1.Rows.Add(dr1)

                                '                ' limpia las variables
                                '            stMATRNUDO = ""
                                '            stMATRNOMB = ""
                                '            stMATRPRAP = ""
                                '            stMATRSEAP = ""
                                '            stMATRPODE = ""

                                '        End If
                                '    End If

                                '' verifica la longitud 
                                'If stContenidoLinea.Length >= 13 Then
                                '    ' almacena el nombre
                                '    If stContenidoLinea.Substring(0, 13).ToString = "<ODO_RESUMEN>" Then
                                '        If stContenidoLinea.ToString.Length > 13 Then
                                '            stMATRLIND += stContenidoLinea.ToString & " "
                                '        End If
                                '    Else
                                '        stMATRLIND += stContenidoLinea.ToString & " "
                                '    End If
                                'End If

                                '' verifica la longitud 
                                'If stContenidoLinea.Length >= 16 Then
                                '    ' almacena el nombre
                                '    If stContenidoLinea.Substring(0, 16).ToString = "</FLI_FOLIO_SIR>" Then
                                '        If stContenidoLinea.ToString.Length >= 16 Then

                                '            ' *** ELIMINA EL REGISTRO ***
                                '            ' instancia la clase
                                '            Dim objdatos1 As New cla_MATRICULA
                                '            objdatos1.fun_Eliminar_MATRICULA(Trim(stMATRMATR), Trim(stMATRDEPA), Trim(stMATRMUNI), Trim(stMATRCLSE), Trim(stMATRNUDO))

                                '            ' concatena el nombre y apellidos
                                '            stMATRNOMB = stMATRNOMB & " " & stMATRPRAP & " " & stMATRSEAP

                                '            ' *** GUARDA EL REGISTRO ***
                                '            ' instancia la clase
                                '            Dim objdatos As New cla_MATRICULA
                                '            objdatos.fun_Insertar_MATRICULA(Trim(stMATRMATR), _
                                '                                            Trim(stMATRNUCA), _
                                '                                            Trim(stMATRVIGE), _
                                '                                            Trim(stMATRCLSE), _
                                '                                            Trim(stMATRDIRE), _
                                '                                            Trim(stMATRLIND), _
                                '                                            Trim(stMATRTIDO), _
                                '                                            Trim(stMATRNUDO), _
                                '                                            Trim(stMATRNOMB), _
                                '                                            Trim(stMATRDEPA), _
                                '                                            Trim(stMATRMUNI))

                                '            stMATRLIND = ""

                                '            stMATRNUDO = ""
                                '            stMATRNOMB = ""
                                '            stMATRPRAP = ""
                                '            stMATRSEAP = ""
                                '            stMATRPODE = ""

                                '        End If
                                '    End If
                                'End If

                            End If
                            'End If

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbPROCESO.Value = inProceso

                        Loop

                        ' cierra el archivo
                        FileClose(1)

                        ' instancia la clase
                        Dim objdatos22 As New cla_MATRICULA

                        ' Llena el datagrigview
                        Me.dgvCONSULTA.DataSource = dt1
                        pbPROCESO.Value = 0

                        ' comando grabar datos
                        If dt_MATRICULA.Rows.Count = 0 Then
                            MessageBox.Show("Proceso de guardado terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Else
                            MessageBox.Show("Proceso de guardado con inconsistencias", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        End If

                        Me.cmdGrabarDatos.Enabled = False
                        Me.lblFlecha2.Visible = False
                        Me.cmdValidaDatos.Enabled = False

                        Me.cmdAbrirArchivo.Focus()

                        Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCONSULTA.RowCount

                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " posición " & inContador)
            MessageBox.Show("Error al guardar los datos, revise la integridad del archivo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub cmdCruceMunicipioVsRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCruceMunicipioVsRegistro.Click

        Try

            If Trim(Me.cboMATRDEPA.Text) = "" Or Trim(Me.cboMATRMUNI.Text) = "" Or Me.cboMATRCLSE.Text = "" Then
                MessageBox.Show("Seleccione el Departamento o Municipio o Sector", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                ' apaga los comandos
                Me.cmdCruceMunicipioVsRegistro.Enabled = False
                Me.cmdCruceRegistroVsMunicipio.Enabled = False
                Me.cmdListadoDePrediosConMatricula.Enabled = False

                ' instancia la clase
                Dim objdatos35 As New cla_FICHPRED
                dt_FICHPRED_Municipio = New DataTable

                ' Consulta las matriculas de ficha predial
                dt_FICHPRED_Municipio = objdatos35.fun_Consultar_FICHA_PREDIAL_X_PROPIETARIO(Trim(Me.cboMATRDEPA.Text), Trim(Me.cboMATRMUNI.Text), CInt(Me.cboMATRCLSE.Text))

                ' instancia la clase
                Dim objdatos33 As New cla_FICHPRED
                dt_FICHPRED_Registro = New DataTable

                'Consulta las matriculas de registro
                dt_FICHPRED_Registro = objdatos33.fun_Consultar_FICHA_PREDIAL_X_REGISTRO(Trim(Me.cboMATRDEPA.Text), Trim(Me.cboMATRMUNI.Text))

                ' Cruce municipio vs registro
                If dt_FICHPRED_Municipio.Rows.Count > 0 And dt_FICHPRED_Registro.Rows.Count > 0 Then

                    ' Valores predeterminados ProgressBar
                    inProceso = 0
                    pbPROCESO.Value = 0
                    pbPROCESO.Maximum = dt_FICHPRED_Municipio.Rows.Count + 1
                    Timer1.Enabled = True

                    ' instancia la tabla
                    dt_CargaIncoDepartamento = New DataTable

                    ' declaración de variables
                    Dim stFIPRNUFI As String = ""
                    Dim stFIPRCLSE As String = ""
                    Dim stFIPRMUNI As String = ""
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
                    dt_CargaIncoDepartamento.Columns.Add(New DataColumn("Matricula", GetType(String)))
                    dt_CargaIncoDepartamento.Columns.Add(New DataColumn("Descripcion", GetType(String)))

                    ' declara la variable
                    Dim i As Integer = 0

                    ' Recorro la tabla del municipio
                    For i = 0 To dt_FICHPRED_Municipio.Rows.Count - 1

                        ' declara la variable
                        Dim stInconsistencia As String = ""
                        Dim stMatriculaMunicipio As String = ""
                        Dim stMatriculaRegistro As String = ""
                        Dim bySW As Byte = 0

                        ' almacena la matricula
                        stMatriculaMunicipio = Trim(dt_FICHPRED_Municipio.Rows(i).Item("FPPRMAIN"))

                        ' almacena la longitud
                        Dim inLongitud As Integer = stMatriculaMunicipio.Length.ToString

                        ' valida el campo matricula
                        If Trim(stMatriculaMunicipio) <> "" Then

                            ' verifica la longitud
                            If inLongitud > 4 Then

                                ' verifica el dato numerico
                                If fun_Verificar_Dato_Numerico_Evento_Validated(stMatriculaMunicipio.ToString.Substring(4, (inLongitud - 4))) = True Then

                                    ' convierte a numero
                                    Dim inMatriculaM As Integer = CInt(stMatriculaMunicipio.ToString.Substring(4, (inLongitud - 4)).TrimStart("0").ToString)

                                    Dim sw1 As Byte = 0
                                    Dim j1 As Integer = 0

                                    While j1 < dt_FICHPRED_Registro.Rows.Count And sw1 = 0

                                        ' convierte a numero
                                        Dim inMatriculaR As Integer = CInt(Trim(dt_FICHPRED_Registro.Rows(j1).Item("MATRMATR").ToString.TrimStart("0").ToString))

                                        If Val(inMatriculaM) = Val(inMatriculaR) Then
                                            bySW = 1
                                            sw1 = 1
                                        Else
                                            j1 = j1 + 1
                                        End If

                                    End While

                                    ' verifica si existe
                                    If bySW = 0 Then
                                        stInconsistencia = "No existe la matricula en registro"
                                        bySW = 0
                                    End If
                                Else
                                    stInconsistencia = "La matricula del municipio no es un dato numerico"
                                    bySW = 0
                                End If
                            Else
                                stInconsistencia = "La longitud de la maltricula del municipio es incorrecta"
                                bySW = 0
                            End If
                        Else
                            stInconsistencia = "El campo matricula del municipio esta nulo"
                            bySW = 0
                        End If

                        ' almacena la inconsistencia 
                        If bySW = 0 Then

                            dr1 = dt_CargaIncoDepartamento.NewRow()

                            stFIPRMUNI = Trim(dt_FICHPRED_Municipio.Rows(i).Item("FIPRMUNI"))
                            stFIPRCLSE = Trim(dt_FICHPRED_Municipio.Rows(i).Item("FIPRCLSE"))
                            stFIPRCORR = Trim(dt_FICHPRED_Municipio.Rows(i).Item("FIPRCORR"))
                            stFIPRBARR = Trim(dt_FICHPRED_Municipio.Rows(i).Item("FIPRBARR"))
                            stFIPRMANZ = Trim(dt_FICHPRED_Municipio.Rows(i).Item("FIPRMANZ"))
                            stFIPRPRED = Trim(dt_FICHPRED_Municipio.Rows(i).Item("FIPRPRED"))
                            stFIPREDIF = Trim(dt_FICHPRED_Municipio.Rows(i).Item("FIPREDIF"))
                            stFIPRUNPR = Trim(dt_FICHPRED_Municipio.Rows(i).Item("FIPRUNPR"))

                            stFIPRCECA = stFIPRMUNI & "-" & stFIPRCLSE & "-" & stFIPRCORR & "-" & stFIPRBARR & "-" & stFIPRMANZ & "-" & stFIPRPRED & "-" & stFIPREDIF & "-" & stFIPRUNPR

                            dr1("Nro. Ficha") = Val(Trim(dt_FICHPRED_Municipio.Rows(i).Item("FIPRNUFI")))
                            dr1("Cedula catastral") = stFIPRCECA
                            dr1("Matricula") = stMatriculaMunicipio
                            dr1("Descripcion") = stInconsistencia

                            dt_CargaIncoDepartamento.Rows.Add(dr1)

                        End If

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbPROCESO.Value = inProceso

                    Next

                    ' inicia la barra de progreso
                    pbPROCESO.Value = 0

                    ' verifica el resultado
                    If dt_CargaIncoDepartamento.Rows.Count > 0 Then

                        ' Llena el datagrigview
                        Me.dgvCONSULTA.DataSource = dt_CargaIncoDepartamento

                        MessageBox.Show("Existen inconsistencias de cruce", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    Else
                        MessageBox.Show("Cruce sin inconsistencias", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If

                Else
                    MessageBox.Show("Existe tablas sin datos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                End If

            End If


            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCONSULTA.RowCount

            ' prende los comandos
            Me.cmdCruceMunicipioVsRegistro.Enabled = True
            Me.cmdCruceRegistroVsMunicipio.Enabled = True
            Me.cmdListadoDePrediosConMatricula.Enabled = True

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCruceRegistroVsMunicipio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCruceRegistroVsMunicipio.Click

        Try

            If Trim(Me.cboMATRDEPA.Text) = "" Or Trim(Me.cboMATRMUNI.Text) = "" Or Me.cboMATRCLSE.Text = "" Then
                MessageBox.Show("Seleccione el Departamento o Municipio o Sector", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Else
                ' apaga los comandos
                Me.cmdCruceMunicipioVsRegistro.Enabled = False
                Me.cmdCruceRegistroVsMunicipio.Enabled = False
                Me.cmdListadoDePrediosConMatricula.Enabled = False

                ' instancia la clase
                Dim objdatos35 As New cla_FICHPRED
                dt_FICHPRED_Municipio = New DataTable

                ' Consulta las matriculas de ficha predial
                dt_FICHPRED_Municipio = objdatos35.fun_Consultar_FICHA_PREDIAL_X_PROPIETARIO(Trim(Me.cboMATRDEPA.Text), Trim(Me.cboMATRMUNI.Text), CInt(Me.cboMATRCLSE.Text))

                ' instancia la clase
                Dim objdatos33 As New cla_FICHPRED
                dt_FICHPRED_Registro = New DataTable

                'Consulta las matriculas de registro
                dt_FICHPRED_Registro = objdatos33.fun_Consultar_FICHA_PREDIAL_X_REGISTRO(Trim(Me.cboMATRDEPA.Text), Trim(Me.cboMATRMUNI.Text))

                ' Cruce municipio vs registro
                If dt_FICHPRED_Municipio.Rows.Count > 0 And dt_FICHPRED_Registro.Rows.Count > 0 Then

                    ' Valores predeterminados ProgressBar
                    inProceso = 0
                    pbPROCESO.Value = 0
                    pbPROCESO.Maximum = dt_FICHPRED_Registro.Rows.Count + 1
                    Timer1.Enabled = True

                    ' instancia la tabla
                    dt_CargaIncoDepartamento = New DataTable

                    ' declaración de variables
                    Dim stFIPRNUFI As String = ""
                    Dim stFIPRCLSE As String = ""
                    Dim stFIPRMUNI As String = ""
                    Dim stFIPRCORR As String = ""
                    Dim stFIPRBARR As String = ""
                    Dim stFIPRMANZ As String = ""
                    Dim stFIPRPRED As String = ""
                    Dim stFIPREDIF As String = ""
                    Dim stFIPRUNPR As String = ""

                    ' Crea objeto registros
                    Dim dr1 As DataRow

                    ' Crea las columnas
                    dt_CargaIncoDepartamento.Columns.Add(New DataColumn("Municipio", GetType(String)))
                    dt_CargaIncoDepartamento.Columns.Add(New DataColumn("Sector", GetType(String)))
                    dt_CargaIncoDepartamento.Columns.Add(New DataColumn("Vigente", GetType(String)))
                    dt_CargaIncoDepartamento.Columns.Add(New DataColumn("Matricula", GetType(String)))
                    dt_CargaIncoDepartamento.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt_CargaIncoDepartamento.Columns.Add(New DataColumn("Tipo_Documento", GetType(String)))
                    dt_CargaIncoDepartamento.Columns.Add(New DataColumn("Nro_Documento", GetType(String)))
                    dt_CargaIncoDepartamento.Columns.Add(New DataColumn("Nombre", GetType(String)))

                    ' declara la variable
                    Dim i As Integer = 0

                    ' Recorro la tabla del municipio
                    For i = 0 To dt_FICHPRED_Registro.Rows.Count - 1

                        ' declara la variable
                        Dim stInconsistencia As String = ""
                        Dim stMatriculaMunicipio As String = ""
                        Dim stTomoMunicipio As String = ""
                        Dim stMatriculaRegistro As String = ""
                        Dim stSectorRegistro As String = ""
                        Dim stVigente As String = ""
                        Dim byMatriculaRegistrada As Byte = 0

                        Dim stTipoDocumento As String = ""
                        Dim stNroDocumento As String = ""
                        Dim stNombreApellidos As String = ""

                        ' almacena la matricula
                        stMatriculaRegistro = Trim(dt_FICHPRED_Registro.Rows(i).Item("MATRMATR"))

                        ' almacena la variable
                        stSectorRegistro = Trim(dt_FICHPRED_Registro.Rows(i).Item("MATRCLSE").ToString)
                        stVigente = Trim(dt_FICHPRED_Registro.Rows(i).Item("MATRVIGE").ToString)

                        ' determina el folio
                        If Trim(stVigente) = "S" Then
                            stVigente = "Folio activo"
                        End If

                        If Trim(stVigente) = "C" Then
                            stVigente = "Folio cerrado"
                        End If

                        If Trim(stVigente) <> "S" And Trim(stVigente) = "C" Then
                            stVigente = "Folio Desconocido"
                        End If

                        ' almacena la longitud
                        Dim inLongitud As Integer = stMatriculaRegistro.Length.ToString

                        ' convierte a numero
                        Dim inMatriculaR As Long = CType(stMatriculaRegistro, Long)

                        Dim sw1 As Byte = 0
                        Dim j1 As Integer = 0

                        While j1 < dt_FICHPRED_Municipio.Rows.Count And sw1 = 0

                            ' almacena la matricula
                            stMatriculaMunicipio = Trim(dt_FICHPRED_Municipio.Rows(j1).Item("FPPRMAIN"))
                            stTomoMunicipio = Trim(dt_FICHPRED_Municipio.Rows(j1).Item("FPPRTOMO"))

                            ' almacena la longitud
                            Dim inLongitudM As Integer = stMatriculaMunicipio.Length.ToString

                            ' valida el campo matricula
                            If Trim(stMatriculaMunicipio) <> "" Then

                                ' verifica la longitud
                                If inLongitudM > 4 And stTomoMunicipio = "0" Then

                                    ' verifica el dato numerico
                                    If fun_Verificar_Dato_Numerico_Evento_Validated(stMatriculaMunicipio.ToString.Substring(4, (inLongitudM - 4))) = True Then

                                        ' convierte a numero
                                        Dim inMatriculaM As Integer = CInt(stMatriculaMunicipio.ToString.Substring(4, (inLongitudM - 4)).TrimStart("0").ToString)

                                        If Val(inMatriculaM) = Val(inMatriculaR) Then
                                            ' sale del ciclo
                                            sw1 = 1
                                            ' encontro la matricula
                                            byMatriculaRegistrada = 1
                                        Else
                                            j1 = j1 + 1
                                        End If

                                    Else
                                        j1 = j1 + 1
                                    End If

                                Else
                                    j1 = j1 + 1
                                End If

                            Else
                                j1 = j1 + 1
                            End If

                        End While

                        ' verifica si existe
                        If byMatriculaRegistrada = 0 Then

                            ' llena las variables
                            stInconsistencia = "No existe la matricula en el municipio"

                            stFIPRMUNI = Trim(dt_FICHPRED_Registro.Rows(i).Item("MATRMUNI"))
                            stFIPRCLSE = Trim(dt_FICHPRED_Registro.Rows(i).Item("MATRCLSE"))

                            stTipoDocumento = Trim(dt_FICHPRED_Registro.Rows(i).Item("MATRTIDO"))
                            stNroDocumento = Trim(dt_FICHPRED_Registro.Rows(i).Item("MATRNUDO"))
                            stNombreApellidos = Trim(dt_FICHPRED_Registro.Rows(i).Item("MATRNOMB"))

                            ' condiciona el tipo de documento
                            If Trim(stTipoDocumento) = "C" Or Trim(stTipoDocumento) = "CC" Then
                                stTipoDocumento = "Cedula"
                            ElseIf Trim(stTipoDocumento) = "N" Or Trim(stTipoDocumento) = "NI" Then
                                stTipoDocumento = "Nit"
                            ElseIf Trim(stTipoDocumento) = "T" Or Trim(stTipoDocumento) = "TI" Then
                                stTipoDocumento = "Tarjeta de identidad"
                            ElseIf Trim(stTipoDocumento) = "P" Or Trim(stTipoDocumento) = "PA" Then
                                stTipoDocumento = "Pasaporte"
                            ElseIf Trim(stTipoDocumento) = "S" Then
                                stTipoDocumento = "Secuencia"
                            ElseIf Trim(stTipoDocumento) = "CE" Then
                                stTipoDocumento = "Cedula extranjeria"
                            Else
                                stTipoDocumento = "Tipo desconocido"
                            End If

                            dr1 = dt_CargaIncoDepartamento.NewRow()

                            dr1("Municipio") = stFIPRMUNI
                            dr1("Sector") = stFIPRCLSE
                            dr1("Vigente") = stVigente
                            dr1("Matricula") = stMatriculaRegistro
                            dr1("Descripcion") = stInconsistencia
                            dr1("Tipo_Documento") = stTipoDocumento
                            dr1("Nro_Documento") = stNroDocumento
                            dr1("Nombre") = stNombreApellidos

                            dt_CargaIncoDepartamento.Rows.Add(dr1)

                        End If

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbPROCESO.Value = inProceso

                    Next

                    ' inicia la barra de progreso
                    pbPROCESO.Value = 0

                    ' verifica el resultado
                    If dt_CargaIncoDepartamento.Rows.Count > 0 Then

                        ' Llena el datagrigview
                        Me.dgvCONSULTA.DataSource = dt_CargaIncoDepartamento

                        MessageBox.Show("Existen inconsistencias de cruce", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    Else
                        MessageBox.Show("Cruce sin inconsistencias", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If

                Else
                    MessageBox.Show("Existe tablas sin datos", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                End If

            End If


            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCONSULTA.RowCount

            ' prende los comandos
            Me.cmdCruceMunicipioVsRegistro.Enabled = True
            Me.cmdCruceRegistroVsMunicipio.Enabled = True
            Me.cmdListadoDePrediosConMatricula.Enabled = True

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdListadoDePrediosConMatricula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListadoDePrediosConMatricula.Click

        Try
            If Me.cboMATRDEPA.Text = "" Or Me.cboMATRMUNI.Text = "" Then
                MessageBox.Show("Favor selecionar el Departamento o Municipio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.cboMATRDEPA.Focus()
            Else
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

                ' parametros de la consulta
                Dim ParametrosConsulta As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "Select "
                ParametrosConsulta += "MatrMatr as Matricula, "
                ParametrosConsulta += "MatrNuca as Nro_Catastral, "
                ParametrosConsulta += "MatrVige as Vigente_Cerrado, "
                ParametrosConsulta += "MatrClse as Sector, "
                ParametrosConsulta += "MatrDire as Direccion, "
                ParametrosConsulta += "MatrLind as Lindero, "
                ParametrosConsulta += "MatrTido as Tipo_Dicumen, "
                ParametrosConsulta += "MatrNudo as Nro_Documen, "
                ParametrosConsulta += "MatrNomb as Nombre, "
                ParametrosConsulta += "MatrDepa as Departamento, "
                ParametrosConsulta += "MatrMuni as Municipio "

                ParametrosConsulta += "From Matricula where "
                ParametrosConsulta += "MatrDepa like '" & Trim(Me.cboMATRDEPA.Text) & "' and "
                ParametrosConsulta += "MatrMuni like '" & Trim(Me.cboMATRMUNI.Text) & "' "
                ParametrosConsulta += "order by MatrMatr "

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

                ' cuenta los registros
                If dt.Rows.Count > 0 Then
                    ' llena el datagridview
                    If dt.Rows.Count > 500 Then
                        ' controla la sobregarga del datagridview
                        If MessageBox.Show("La consulta sobrecargara el sistema" & Chr(Keys.Enter) & Chr(Keys.Enter) & _
                                           "Nro. de registros para cargar :  " & dt.Rows.Count & Chr(Keys.Enter) & Chr(Keys.Enter) & _
                                           "¿ Desea continuar ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                            ' llena el datagridview
                            dgvCONSULTA.DataSource = dt
                        Else
                            ' sale del proceso de consulta
                            Exit Sub
                        End If
                    End If

                    ' llena el datagridview
                    Me.dgvCONSULTA.DataSource = dt

                Else

                    Me.dgvCONSULTA.DataSource = New DataTable
                    mod_MENSAJE.Consulta_No_Encontro_Registros()

                End If

                ' Numero de registros recuperados
                Me.strBARRESTA.Items(2).Text = "Registros : " & dgvCONSULTA.RowCount.ToString

                Me.dgvCONSULTA.Focus()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        Try

            ' exporta ficha predial
            If Me.dgvCONSULTA.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvCONSULTA.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdExportarPlano_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.Click
        Try

            ' exporta ficha predial
            If Me.dgvCONSULTA.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                pro_ExportarPlano(Me.dgvCONSULTA.DataSource)
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

    Private Sub frm_Cruce_Matriculas_vs_Registro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboMATRDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMATRDEPA.SelectedIndexChanged
        Me.lblMATRDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(cboMATRDEPA.Text), String)
    End Sub
    Private Sub cboMATRMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMATRMUNI.SelectedIndexChanged
        Me.lblMATRMUNI.Text = fun_Buscar_Lista_Valores_MUNICIPIO(Trim(cboMATRDEPA.Text), Trim(cboMATRMUNI.Text))
    End Sub
    Private Sub cboMATRCLSE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMATRCLSE.SelectedIndexChanged
        Me.lblMATRCLSE.Text = fun_Buscar_Lista_Valores_CLASSECT(Trim(cboMATRCLSE.Text))
    End Sub

#End Region

#Region "Click"

    Private Sub cboMATRDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMATRDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO(cboMATRDEPA, cboMATRDEPA.SelectedIndex)

        Dim tbl As New DataTable
        cboMATRMUNI.DataSource = tbl

        Me.lblMATRMUNI.Text = ""

    End Sub
    Private Sub cboMATRMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMATRMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO(cboMATRMUNI, cboMATRDEPA.SelectedValue)
    End Sub
    Private Sub cboMATRCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMATRCLSE.Click
        fun_Cargar_ComboBox_Con_Todos_Los_Datos_CLASSECT(cboMATRCLSE, cboMATRCLSE.SelectedIndex)
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmdAbrirArchivo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivo.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdAbrirArchivo.AccessibleDescription
    End Sub
    Private Sub cboZOECDEPA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMATRDEPA.GotFocus
        Me.strBARRESTA.Items(0).Text = cboMATRDEPA.AccessibleDescription
    End Sub
    Private Sub cboZOECMUNI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMATRMUNI.GotFocus
        Me.strBARRESTA.Items(0).Text = cboMATRMUNI.AccessibleDescription
    End Sub
    Private Sub cmdValidaDatos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdValidaDatos.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdValidaDatos.AccessibleDescription
    End Sub
    Private Sub cmdGrabarDatos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGrabarDatos.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdGrabarDatos.AccessibleDescription
    End Sub
    Private Sub cmdCruceMunicipioVsRegistro_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCruceMunicipioVsRegistro.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdCruceMunicipioVsRegistro.AccessibleDescription
    End Sub
    Private Sub cmdCruceRegistroVsMunicipio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCruceRegistroVsMunicipio.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdCruceRegistroVsMunicipio.AccessibleDescription
    End Sub
    Private Sub cmdListadoDePrediosConMatricula_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdListadoDePrediosConMatricula.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdListadoDePrediosConMatricula.AccessibleDescription
    End Sub
    Private Sub dgvFIPRCONS_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCONSULTA.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvCONSULTA.AccessibleDescription
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

#End Region

#End Region

End Class