Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_Generar_Areas_de_Construccion_Mediante_Poligonos

    '========================================================
    '*** GENERAR AREAS DE CONSTRUCCIÓN MEDIANTE POLIGONOS ***
    '========================================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Generar_Areas_de_Construccion_Mediante_Poligonos
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Generar_Areas_de_Construccion_Mediante_Poligonos
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
    Dim dt_CargaListadoFuente As New DataTable
    Dim dt_CargaListadoEstructurado As New DataTable
    Dim dt_CargaListadoCruce As New DataTable

    ' otros procesos
    Dim stRutaArchivo As String
    Dim inTotalRegistros As Integer
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

        Me.dgvListadoFuente.DataSource = New DataTable
        Me.dgvListadoEstructurado.DataSource = New DataTable
        Me.dgvListadoCruce.DataSource = New DataTable

        Me.lblRutaArchivo.Text = ""

        Me.cmdValidaDatos.Enabled = False
        Me.cmdEstructurarDatos.Enabled = False
        Me.cmdCruzarDatos.Enabled = False

        Me.lblCantidadRegistros.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registro : 0"

    End Sub
    Private Sub pro_ControlBotones()

        If Me.dgvListadoFuente.RowCount > 0 Then
            Me.cmdValidaDatos.Enabled = True
        Else
            Me.cmdValidaDatos.Enabled = False
        End If

        If Me.dgvInconsistencias.RowCount = 0 And Me.dgvListadoEstructurado.RowCount > 0 Then
            Me.cmdEstructurarDatos.Enabled = True
        Else
            Me.cmdEstructurarDatos.Enabled = False
        End If

        If Me.dgvListadoEstructurado.RowCount > 0 Then
            Me.cmdCruzarDatos.Enabled = True
        Else
            Me.cmdCruzarDatos.Enabled = False
        End If

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdAbrirArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivo.Click

        Try
            ' apaga los comandos
            Me.cmdValidaDatos.Enabled = False
            Me.cmdEstructurarDatos.Enabled = False
            Me.cmdCruzarDatos.Enabled = False

            ' limpia los campos
            Me.lblCantidadRegistros.Text = ""
            Me.lblRutaArchivo.Text = ""
            inTotalRegistros = 0

            Me.dgvListadoFuente.DataSource = New DataTable
            Me.dgvListadoEstructurado.DataSource = New DataTable
            Me.dgvListadoCruce.DataSource = New DataTable
            Me.dgvInconsistencias.DataSource = New DataTable

            ' enruta el archivo
            oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
            oLeer.Filter = "Archivo de texto (*.xls)|*.xls" 'Colocar varias extensiones
            oLeer.FilterIndex = 1 'coloca por defecto el *.txt
            oLeer.FileName = ""
            oLeer.ShowDialog()

            stRutaArchivo = Trim(oLeer.FileName)

            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim DtSet As System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & stRutaArchivo & "'; Extended Properties=Excel 8.0;")

            Dim stNombreLibro As String = InputBox("Ingrese el nombre de la hoja de excel", "Mensaje")

            If Trim(stNombreLibro) <> "" Then

                MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & stNombreLibro & "$]", MyConnection)

                MyCommand.TableMappings.Add("Table", "TestTable")
                DtSet = New System.Data.DataSet
                MyCommand.Fill(DtSet)

                Me.dgvListadoFuente.DataSource = DtSet.Tables(0)

                Me.lblRutaArchivo.Text = Trim(oLeer.FileName)

                Me.TabResultado.SelectTab(TabPage1)

                inTotalRegistros = Me.dgvListadoFuente.RowCount

                Me.lblCantidadRegistros.Text = inTotalRegistros

                Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvListadoFuente.RowCount

                MyConnection.Close()

            Else
                Me.lblRutaArchivo.Text = ""
                Me.lblCantidadRegistros.Text = "0"
            End If

            pro_ControlBotones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub cmdValidaDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValidaDatos.Click

        Try
            If Me.dgvListadoFuente.RowCount > 0 Then

                ' apaga los comandos
                Me.cmdValidaDatos.Enabled = False
                Me.cmdEstructurarDatos.Enabled = False
                Me.cmdCruzarDatos.Enabled = False

                ' Valores predeterminados ProgressBar
                inProceso = 0
                pbProceso.Value = 0
                pbProceso.Maximum = Me.dgvListadoFuente.RowCount
                Timer1.Enabled = True

                ' instancia la tabla
                dt_CargaListadoFuente = New DataTable

                ' carga la tabla
                dt_CargaListadoFuente = Me.dgvListadoFuente.DataSource

                ' crea la tabla
                Dim dt_Inconsistencias As New DataTable

                ' Crea objeto registros
                Dim dr1 As DataRow

                ' Crea las columnas
                dt_Inconsistencias.Columns.Add(New DataColumn("PK_Construcciones", GetType(String)))
                dt_Inconsistencias.Columns.Add(New DataColumn("Tipo", GetType(String)))
                dt_Inconsistencias.Columns.Add(New DataColumn("Uso", GetType(String)))
                dt_Inconsistencias.Columns.Add(New DataColumn("Nro_Pisos", GetType(String)))
                dt_Inconsistencias.Columns.Add(New DataColumn("Area_Construccion", GetType(String)))
                dt_Inconsistencias.Columns.Add(New DataColumn("Inconsistencia", GetType(String)))

                Dim i As Integer = 0

                For i = 0 To dt_CargaListadoFuente.Rows.Count - 1

                    Dim stPkConstrucciones As String = Trim(dt_CargaListadoFuente.Rows(i).Item(0).ToString)
                    Dim stTipo As String = Trim(dt_CargaListadoFuente.Rows(i).Item(1).ToString)
                    Dim stUso As String = Trim(dt_CargaListadoFuente.Rows(i).Item(2).ToString)
                    Dim stNroPisos As String = Trim(dt_CargaListadoFuente.Rows(i).Item(3).ToString)
                    Dim stAreaConstruccion As String = Trim(dt_CargaListadoFuente.Rows(i).Item(4).ToString)

                    If Trim(stPkConstrucciones) = "" Then

                        Dim stInconsistencia As String = "El campo PK_Construcciones esta vacio - Registro: " & i

                        dr1 = dt_Inconsistencias.NewRow()

                        dr1("PK_Construcciones") = stPkConstrucciones
                        dr1("Tipo") = stTipo
                        dr1("Uso") = stUso
                        dr1("Nro_Pisos") = stNroPisos
                        dr1("Area_Construccion") = stAreaConstruccion
                        dr1("Inconsistencia") = stInconsistencia

                        dt_Inconsistencias.Rows.Add(dr1)

                    Else

                        If CInt(Trim(stPkConstrucciones.ToString.Length)) <> 33 Then

                            Dim stInconsistencia As String = "El campo PK_Construcciones no tiene la longitud valida - Registro: " & i

                            dr1 = dt_Inconsistencias.NewRow()

                            dr1("PK_Construcciones") = stPkConstrucciones
                            dr1("Tipo") = stTipo
                            dr1("Uso") = stUso
                            dr1("Nro_Pisos") = stNroPisos
                            dr1("Area_Construccion") = stAreaConstruccion
                            dr1("Inconsistencia") = stInconsistencia

                            dt_Inconsistencias.Rows.Add(dr1)

                        Else

                            If CInt(Trim(stPkConstrucciones.ToString.Substring(28, 5))) = 0 And (Trim(stTipo) = "N" Or Trim(stTipo) = "M") Then

                                Dim stInconsistencia As String = "El campo Nro_Construccion es igual a cero - Registro: " & i

                                dr1 = dt_Inconsistencias.NewRow()

                                dr1("PK_Construcciones") = stPkConstrucciones
                                dr1("Tipo") = stTipo
                                dr1("Uso") = stUso
                                dr1("Nro_Pisos") = stNroPisos
                                dr1("Area_Construccion") = stAreaConstruccion
                                dr1("Inconsistencia") = stInconsistencia

                                dt_Inconsistencias.Rows.Add(dr1)

                            End If

                        End If

                    End If

                    If (Trim(stTipo) = "N" Or Trim(stTipo) = "M") And stUso = "" Then

                        Dim stInconsistencia As String = "El campo Uso esta vacio - Registro: " & i

                        dr1 = dt_Inconsistencias.NewRow()

                        dr1("PK_Construcciones") = stPkConstrucciones
                        dr1("Tipo") = stTipo
                        dr1("Uso") = stUso
                        dr1("Nro_Pisos") = stNroPisos
                        dr1("Area_Construccion") = stAreaConstruccion
                        dr1("Inconsistencia") = stInconsistencia

                        dt_Inconsistencias.Rows.Add(dr1)

                    End If

                    If (Trim(stTipo) = "N" Or Trim(stTipo) = "M") Then

                        If Trim(stNroPisos) = "" Then

                            Dim stInconsistencia As String = "El campo Nro_Pisos esta vacio - Registro: " & i

                            dr1 = dt_Inconsistencias.NewRow()

                            dr1("PK_Construcciones") = stPkConstrucciones
                            dr1("Tipo") = stTipo
                            dr1("Uso") = stUso
                            dr1("Nro_Pisos") = stNroPisos
                            dr1("Area_Construccion") = stAreaConstruccion
                            dr1("Inconsistencia") = stInconsistencia

                            dt_Inconsistencias.Rows.Add(dr1)

                        Else

                            If fun_Verificar_Dato_Numerico_Evento_Validated(stNroPisos) = False Then

                                Dim stInconsistencia As String = "El campo Nro_Pisos no es numerico - Registro: " & i

                                dr1 = dt_Inconsistencias.NewRow()

                                dr1("PK_Construcciones") = stPkConstrucciones
                                dr1("Tipo") = stTipo
                                dr1("Uso") = stUso
                                dr1("Nro_Pisos") = stNroPisos
                                dr1("Area_Construccion") = stAreaConstruccion
                                dr1("Inconsistencia") = stInconsistencia

                                dt_Inconsistencias.Rows.Add(dr1)

                            Else

                                If Trim(stNroPisos) = "0" Then

                                    Dim stInconsistencia As String = "El campo Nro_Pisos es igual a cero - Registro: " & i

                                    dr1 = dt_Inconsistencias.NewRow()

                                    dr1("PK_Construcciones") = stPkConstrucciones
                                    dr1("Tipo") = stTipo
                                    dr1("Uso") = stUso
                                    dr1("Nro_Pisos") = stNroPisos
                                    dr1("Area_Construccion") = stAreaConstruccion
                                    dr1("Inconsistencia") = stInconsistencia

                                    dt_Inconsistencias.Rows.Add(dr1)

                                End If

                            End If
                        End If
                    End If

                    If (Trim(stTipo) = "N" Or Trim(stTipo) = "M") Then

                        If Trim(stAreaConstruccion) = "" Then

                            Dim stInconsistencia As String = "El campo Area_Construccion esta vacio - Registro: " & i

                            dr1 = dt_Inconsistencias.NewRow()

                            dr1("PK_Construcciones") = stPkConstrucciones
                            dr1("Tipo") = stTipo
                            dr1("Uso") = stUso
                            dr1("Nro_Pisos") = stNroPisos
                            dr1("Area_Construccion") = stAreaConstruccion
                            dr1("Inconsistencia") = stInconsistencia

                            dt_Inconsistencias.Rows.Add(dr1)

                        Else

                            If fun_Verificar_Dato_Decimal_Evento_Validated(stAreaConstruccion) = False Then

                                Dim stInconsistencia As String = "El campo Area_Construccion no es numerico - Registro: " & i

                                dr1 = dt_Inconsistencias.NewRow()

                                dr1("PK_Construcciones") = stPkConstrucciones
                                dr1("Tipo") = stTipo
                                dr1("Uso") = stUso
                                dr1("Nro_Pisos") = stNroPisos
                                dr1("Area_Construccion") = stAreaConstruccion
                                dr1("Inconsistencia") = stInconsistencia

                                dt_Inconsistencias.Rows.Add(dr1)

                            End If
                        End If
                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbProceso.Value = inProceso

                Next

                ' Llena el datagrigview
                Me.dgvInconsistencias.DataSource = dt_Inconsistencias
                pbProceso.Value = 0

                pro_ControlBotones()

                ' comando grabar datos
                If dgvInconsistencias.RowCount = 0 Then
                    Me.cmdValidaDatos.Enabled = False
                    Me.cmdEstructurarDatos.Enabled = True
                    Me.TabResultado.SelectTab(TabPage1)

                    MessageBox.Show("Proceso de validación terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvListadoFuente.RowCount
                Else
                    Me.cmdValidaDatos.Enabled = True
                    Me.cmdEstructurarDatos.Enabled = False
                    Me.TabResultado.SelectTab(TabPage4)

                    MessageBox.Show("Proceso de validación con inconsistencias", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    Me.strBARRESTA.Items(2).Text = "Registros : " & dt_Inconsistencias.Rows.Count
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & inProceso)
        End Try

    End Sub
    Private Sub cmdEstructurarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEstructurarDatos.Click

        Try
            ' verifica los registros
            If Me.dgvListadoFuente.RowCount > 0 Then

                ' comando botones
                Me.cmdEstructurarDatos.Enabled = False
                Me.cmdCruzarDatos.Enabled = False

                ' limpia y carga la tabla
                dt_CargaListadoFuente = New DataTable
                dt_CargaListadoFuente = Me.dgvListadoFuente.DataSource

                ' verifica los registros
                If dt_CargaListadoFuente.Rows.Count > 0 Then

                    ' prende el timer
                    inProceso = 0
                    Me.pbProceso.Value = 0
                    Me.pbProceso.Maximum = Me.dgvListadoFuente.RowCount
                    Me.Timer1.Enabled = True

                    ' declara la variable
                    Dim dr1 As DataRow
                    dt_CargaListadoEstructurado = New DataTable

                    ' crea la tabla dinamica
                    dt_CargaListadoEstructurado.Columns.Add(New DataColumn("Municipio", GetType(String)))
                    dt_CargaListadoEstructurado.Columns.Add(New DataColumn("Corregimiento", GetType(String)))
                    dt_CargaListadoEstructurado.Columns.Add(New DataColumn("Barrio", GetType(String)))
                    dt_CargaListadoEstructurado.Columns.Add(New DataColumn("Manzana", GetType(String)))
                    dt_CargaListadoEstructurado.Columns.Add(New DataColumn("Predio", GetType(String)))
                    dt_CargaListadoEstructurado.Columns.Add(New DataColumn("Edificio", GetType(String)))
                    dt_CargaListadoEstructurado.Columns.Add(New DataColumn("Unidad_Predial", GetType(String)))
                    dt_CargaListadoEstructurado.Columns.Add(New DataColumn("Sector", GetType(String)))
                    dt_CargaListadoEstructurado.Columns.Add(New DataColumn("Unidad", GetType(String)))
                    dt_CargaListadoEstructurado.Columns.Add(New DataColumn("Area_Construccion", GetType(String)))
                    dt_CargaListadoEstructurado.Columns.Add(New DataColumn("Tipo", GetType(String)))
                    dt_CargaListadoEstructurado.Columns.Add(New DataColumn("Uso", GetType(String)))

                    ' crea las variables
                    Dim stARCOPKCO As String = ""
                    Dim stARCOMUNI As String = ""
                    Dim stARCOCLSE As String = ""
                    Dim stARCOCORR As String = ""
                    Dim stARCOBARR As String = ""
                    Dim stARCOMANZ As String = ""
                    Dim stARCOPRED As String = ""
                    Dim stARCOEDIF As String = ""
                    Dim stARCOUNPR As String = ""
                    Dim stARCOUNID As String = ""
                    Dim stARCOTIPO As String = ""
                    Dim stARCOUSO As String = ""
                    Dim inARCOPISO As Integer = 0
                    Dim stARCOARCO As String = ""

                    ' instancia la clase
                    Dim obAREACONS2 As New cla_AREACONS
                    obAREACONS2.fun_Eliminar_AREACONS()

                    ' declara la variable
                    Dim i As Integer = 0

                    ' recorre la tabla
                    For i = 0 To dt_CargaListadoFuente.Rows.Count - 1

                        ' llena las variables
                        stARCOPKCO = Trim(dt_CargaListadoFuente.Rows(i).Item(0).ToString)
                        stARCOMUNI = fun_Formato_Mascara_3_String(Trim(dt_CargaListadoFuente.Rows(i).Item(0).ToString.Substring(0, 3)))
                        stARCOCLSE = Trim(dt_CargaListadoFuente.Rows(i).Item(0).ToString.Substring(3, 1))
                        stARCOCORR = fun_Formato_Mascara_3_String(Trim(dt_CargaListadoFuente.Rows(i).Item(0).ToString.Substring(4, 3)))
                        stARCOBARR = fun_Formato_Mascara_3_String(Trim(dt_CargaListadoFuente.Rows(i).Item(0).ToString.Substring(7, 3)))
                        stARCOMANZ = fun_Formato_Mascara_4_String(Trim(dt_CargaListadoFuente.Rows(i).Item(0).ToString.Substring(10, 4)))
                        stARCOPRED = fun_Formato_Mascara_5_String(Trim(dt_CargaListadoFuente.Rows(i).Item(0).ToString.Substring(14, 5)))
                        stARCOEDIF = fun_Formato_Mascara_4_String(Trim(dt_CargaListadoFuente.Rows(i).Item(0).ToString.Substring(19, 4)))
                        stARCOUNPR = fun_Formato_Mascara_5_String(Trim(dt_CargaListadoFuente.Rows(i).Item(0).ToString.Substring(23, 5)))
                        stARCOUNID = fun_Formato_Mascara_5_String(Trim(dt_CargaListadoFuente.Rows(i).Item(0).ToString.Substring(28, 5)))
                        stARCOTIPO = Trim(dt_CargaListadoFuente.Rows(i).Item(1).ToString)
                        stARCOUSO = Trim(dt_CargaListadoFuente.Rows(i).Item(2).ToString)
                        inARCOPISO = dt_CargaListadoFuente.Rows(i).Item(3)
                        stARCOARCO = fun_Formato_Decimal_2_Decimales(CDec(Trim(dt_CargaListadoFuente.Rows(i).Item(4).ToString)) * inARCOPISO)

                        ' condiona los registros
                        If (Trim(stARCOTIPO) = "N" Or Trim(stARCOTIPO) = "M") Then

                            ' instancia la clase
                            Dim obAREACONS As New cla_AREACONS
                            Dim dtAREACONS As New DataTable

                            dtAREACONS = obAREACONS.fun_Consultar_X_PK_AREACONS(Trim(stARCOPKCO))

                            ' verifica si existe el registro
                            If dtAREACONS.Rows.Count = 0 Then

                                ' inserta el registro
                                obAREACONS.fun_Insertar_AREACONS(stARCOPKCO, stARCOMUNI, stARCOCORR, stARCOBARR, stARCOMANZ, stARCOPRED, stARCOEDIF, stARCOUNPR, stARCOCLSE, stARCOTIPO, stARCOUSO, stARCOARCO, stARCOUNID)
                            Else
                                ' declara la variable
                                Dim stAREACONS As String = Trim(dtAREACONS.Rows(0).Item("ARCOARCO").ToString)

                                ' suma las areas de construcción
                                stAREACONS = CDec(stAREACONS) + CDec(stARCOARCO)

                                ' actualiza el área de construcción
                                obAREACONS.fun_Actualizar_ARCO_X_PK_AREACONS(stARCOPKCO, stAREACONS)
                            End If

                        End If

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbProceso.Value = inProceso

                    Next

                    ' instancia la clase
                    Dim obAREACONS1 As New cla_AREACONS
                    Dim dtAREACONS1 As New DataTable

                    dtAREACONS1 = obAREACONS1.fun_Consultar_AREACONS

                    ' verifica los registros
                    If dtAREACONS1.Rows.Count > 0 Then

                        ' declara la variable
                        Dim ii As Integer = 0

                        For ii = 0 To dtAREACONS1.Rows.Count - 1

                            dr1 = dt_CargaListadoEstructurado.NewRow()

                            dr1("Municipio") = Trim(dtAREACONS1.Rows(ii).Item("ARCOMUNI").ToString)
                            dr1("Corregimiento") = Trim(dtAREACONS1.Rows(ii).Item("ARCOCORR").ToString)
                            dr1("Barrio") = Trim(dtAREACONS1.Rows(ii).Item("ARCOBARR").ToString)
                            dr1("Manzana") = Trim(dtAREACONS1.Rows(ii).Item("ARCOMANZ").ToString)
                            dr1("Predio") = Trim(dtAREACONS1.Rows(ii).Item("ARCOPRED").ToString)
                            dr1("Edificio") = Trim(dtAREACONS1.Rows(ii).Item("ARCOEDIF").ToString)
                            dr1("Unidad_Predial") = Trim(dtAREACONS1.Rows(ii).Item("ARCOUNPR").ToString)
                            dr1("Sector") = Trim(dtAREACONS1.Rows(ii).Item("ARCOCLSE").ToString)
                            dr1("Unidad") = Trim(dtAREACONS1.Rows(ii).Item("ARCOUNID").ToString)
                            dr1("Area_Construccion") = Trim(dtAREACONS1.Rows(ii).Item("ARCOARCO").ToString)
                            dr1("Tipo") = Trim(dtAREACONS1.Rows(ii).Item("ARCOTIPO").ToString)
                            dr1("Uso") = Trim(dtAREACONS1.Rows(ii).Item("ARCOUSO").ToString)

                            dt_CargaListadoEstructurado.Rows.Add(dr1)

                        Next

                        Me.TabResultado.SelectTab(TabPage2)

                        Me.dgvListadoEstructurado.DataSource = dt_CargaListadoEstructurado

                        Me.cmdValidaDatos.Enabled = False
                        Me.cmdEstructurarDatos.Enabled = False
                        Me.cmdCruzarDatos.Enabled = True
                    Else
                        Me.dgvListadoEstructurado.DataSource = New DataTable

                        Me.cmdValidaDatos.Enabled = False
                        Me.cmdEstructurarDatos.Enabled = True
                        Me.cmdCruzarDatos.Enabled = False
                    End If

                End If

                pbProceso.Value = 0

                MessageBox.Show("Proceso de estructuración terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("No existes registros", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)

            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvListadoEstructurado.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCruzarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCruzarDatos.Click

        Try
            If Me.dgvListadoEstructurado.RowCount > 0 Then

                ' instancia la clase
                Dim obAREACONS1 As New cla_AREACONS
                Dim dtAREACONS1 As New DataTable

                dtAREACONS1 = obAREACONS1.fun_Consultar_AREACONS

                ' verifica los registros
                If dtAREACONS1.Rows.Count > 0 Then

                    ' declara la variable
                    Dim dr1 As DataRow
                    dt_CargaListadoCruce = New DataTable

                    ' crea la tabla dinamica
                    dt_CargaListadoCruce.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                    dt_CargaListadoCruce.Columns.Add(New DataColumn("Municipio", GetType(String)))
                    dt_CargaListadoCruce.Columns.Add(New DataColumn("Corregimiento", GetType(String)))
                    dt_CargaListadoCruce.Columns.Add(New DataColumn("Barrio", GetType(String)))
                    dt_CargaListadoCruce.Columns.Add(New DataColumn("Manzana", GetType(String)))
                    dt_CargaListadoCruce.Columns.Add(New DataColumn("Predio", GetType(String)))
                    dt_CargaListadoCruce.Columns.Add(New DataColumn("Edificio", GetType(String)))
                    dt_CargaListadoCruce.Columns.Add(New DataColumn("Unidad_Predial", GetType(String)))
                    dt_CargaListadoCruce.Columns.Add(New DataColumn("Sector", GetType(String)))
                    dt_CargaListadoCruce.Columns.Add(New DataColumn("Unidad", GetType(String)))
                    dt_CargaListadoCruce.Columns.Add(New DataColumn("Area_Const_Geodata", GetType(String)))
                    dt_CargaListadoCruce.Columns.Add(New DataColumn("Area_Const_BaseDatos", GetType(String)))
                    dt_CargaListadoCruce.Columns.Add(New DataColumn("Porc_Diferencia", GetType(String)))
                    dt_CargaListadoCruce.Columns.Add(New DataColumn("Inconsistencia", GetType(String)))

                    ' prende el timer
                    inProceso = 0
                    Me.pbProceso.Value = 0
                    Me.pbProceso.Maximum = dtAREACONS1.Rows.Count
                    Me.Timer1.Enabled = True

                    ' declara la variable
                    Dim ii As Integer = 0

                    For ii = 0 To dtAREACONS1.Rows.Count - 1

                        ' crea las variables
                        Dim stARCOMUNI_GEO As String = fun_Formato_Mascara_3_String(Trim(dtAREACONS1.Rows(ii).Item("ARCOMUNI").ToString))
                        Dim stARCOCLSE_GEO As String = Trim(dtAREACONS1.Rows(ii).Item("ARCOCLSE").ToString)
                        Dim stARCOCORR_GEO As String = fun_Formato_Mascara_2_String(Trim(dtAREACONS1.Rows(ii).Item("ARCOCORR").ToString))
                        Dim stARCOBARR_GEO As String = fun_Formato_Mascara_3_String(Trim(dtAREACONS1.Rows(ii).Item("ARCOBARR").ToString))
                        Dim stARCOMANZ_GEO As String = fun_Formato_Mascara_3_String(Trim(dtAREACONS1.Rows(ii).Item("ARCOMANZ").ToString))
                        Dim stARCOPRED_GEO As String = fun_Formato_Mascara_5_String(Trim(dtAREACONS1.Rows(ii).Item("ARCOPRED").ToString))
                        Dim stARCOEDIF_GEO As String = fun_Formato_Mascara_3_String(Trim(dtAREACONS1.Rows(ii).Item("ARCOEDIF").ToString))
                        Dim stARCOUNPR_GEO As String = fun_Formato_Mascara_5_String(Trim(dtAREACONS1.Rows(ii).Item("ARCOUNPR").ToString))
                        Dim stARCOUNID_GEO As String = CInt(dtAREACONS1.Rows(ii).Item("ARCOUNID").ToString)
                        Dim stARCOARCO_GEO As String = Trim(dtAREACONS1.Rows(ii).Item("ARCOARCO").ToString)
                        Dim stARCOTIFI_GEO As String = CInt(0)

                        ' declara la instancia
                        Dim obFICHPRED As New cla_FICHPRED
                        Dim dtFICHPRED As New DataTable

                        dtFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_x_CEDULA(stARCOMUNI_GEO, stARCOCLSE_GEO, stARCOCORR_GEO, stARCOBARR_GEO, stARCOMANZ_GEO, stARCOPRED_GEO, stARCOEDIF_GEO, stARCOUNPR_GEO, stARCOTIFI_GEO)

                        If dtFICHPRED.Rows.Count > 0 Then

                            Dim inFIPRNUME As Integer = CInt(dtFICHPRED.Rows(0).Item("FIPRNUFI"))

                            ' declara la instancia
                            Dim obFIPRCONS As New cla_FIPRCONS
                            Dim dtFIPRCONS As New DataTable

                            dtFIPRCONS = obFIPRCONS.fun_Buscar_CODIGO_FIPRCONS(inFIPRNUME, stARCOUNID_GEO)

                            If dtFIPRCONS.Rows.Count > 0 Then

                                ' almacena las las áreas de construcción
                                Dim deAREACONS_GEO As Decimal = CDec(stARCOARCO_GEO)
                                Dim deAREACONS_BD As Decimal = CDec(dtFIPRCONS.Rows(0).Item("FPCOARCO").ToString)

                                ' verifica el area de terreno
                                If deAREACONS_BD = deAREACONS_GEO Then

                                    ' inserta el registro
                                    dr1 = dt_CargaListadoCruce.NewRow()

                                    dr1("Nro_Ficha") = inFIPRNUME
                                    dr1("Municipio") = stARCOMUNI_GEO
                                    dr1("Corregimiento") = stARCOCORR_GEO
                                    dr1("Barrio") = stARCOBARR_GEO
                                    dr1("Manzana") = stARCOMANZ_GEO
                                    dr1("Predio") = stARCOPRED_GEO
                                    dr1("Edificio") = stARCOEDIF_GEO
                                    dr1("Unidad_Predial") = stARCOUNPR_GEO
                                    dr1("Sector") = stARCOCLSE_GEO
                                    dr1("Unidad") = stARCOUNID_GEO
                                    dr1("Area_Const_Geodata") = deAREACONS_GEO
                                    dr1("Area_Const_BaseDatos") = deAREACONS_BD
                                    dr1("Porc_Diferencia") = "0.00"
                                    dr1("Inconsistencia") = "Area de construcción sin diferencia"

                                    dt_CargaListadoCruce.Rows.Add(dr1)

                                Else

                                    ' declara las variables
                                    Dim doNroMayor As Double = 0.0
                                    Dim doNroMenor As Double = 0.0
                                    Dim doPorcentajeCruce As Double = 0.0

                                    ' compara las variables
                                    If CDbl(deAREACONS_BD) > CDbl(deAREACONS_GEO) And CDbl(deAREACONS_GEO) <> 0 And CDbl(deAREACONS_BD) <> 0 Then

                                        ' llenas las variables
                                        doNroMayor = deAREACONS_BD
                                        doNroMenor = deAREACONS_GEO

                                        ' calcula el porcentaje de diferencia
                                        doPorcentajeCruce = fun_Formato_Decimal_2_Decimales(((doNroMayor * 100) / doNroMenor) - 100)

                                        ' inserta el registro
                                        dr1 = dt_CargaListadoCruce.NewRow()

                                        dr1("Nro_Ficha") = inFIPRNUME
                                        dr1("Municipio") = stARCOMUNI_GEO
                                        dr1("Corregimiento") = stARCOCORR_GEO
                                        dr1("Barrio") = stARCOBARR_GEO
                                        dr1("Manzana") = stARCOMANZ_GEO
                                        dr1("Predio") = stARCOPRED_GEO
                                        dr1("Edificio") = stARCOEDIF_GEO
                                        dr1("Unidad_Predial") = stARCOUNPR_GEO
                                        dr1("Sector") = stARCOCLSE_GEO
                                        dr1("Unidad") = stARCOUNID_GEO
                                        dr1("Area_Const_Geodata") = deAREACONS_GEO
                                        dr1("Area_Const_BaseDatos") = deAREACONS_BD
                                        dr1("Porc_Diferencia") = doPorcentajeCruce
                                        dr1("Inconsistencia") = "Area de construcción con diferencia"

                                        dt_CargaListadoCruce.Rows.Add(dr1)

                                    ElseIf CDbl(deAREACONS_GEO) > CDbl(deAREACONS_BD) And CDbl(deAREACONS_GEO) <> 0 And CDbl(deAREACONS_BD) <> 0 Then
                                        ' llenas las variables
                                        doNroMayor = deAREACONS_GEO
                                        doNroMenor = deAREACONS_BD

                                        ' calcula el porcentaje de diferencia
                                        doPorcentajeCruce = fun_Formato_Decimal_2_Decimales(((doNroMayor * 100) / doNroMenor) - 100)

                                        ' inserta el registro
                                        dr1 = dt_CargaListadoCruce.NewRow()

                                        dr1("Nro_Ficha") = inFIPRNUME
                                        dr1("Municipio") = stARCOMUNI_GEO
                                        dr1("Corregimiento") = stARCOCORR_GEO
                                        dr1("Barrio") = stARCOBARR_GEO
                                        dr1("Manzana") = stARCOMANZ_GEO
                                        dr1("Predio") = stARCOPRED_GEO
                                        dr1("Edificio") = stARCOEDIF_GEO
                                        dr1("Unidad_Predial") = stARCOUNPR_GEO
                                        dr1("Sector") = stARCOCLSE_GEO
                                        dr1("Unidad") = stARCOUNID_GEO
                                        dr1("Area_Const_Geodata") = deAREACONS_GEO
                                        dr1("Area_Const_BaseDatos") = deAREACONS_BD
                                        dr1("Porc_Diferencia") = doPorcentajeCruce
                                        dr1("Inconsistencia") = "Area de construcción con diferencia"

                                        dt_CargaListadoCruce.Rows.Add(dr1)

                                    ElseIf CDbl(deAREACONS_GEO) = 0 Or CDbl(deAREACONS_BD) = 0 Then

                                        ' inserta el registro
                                        dr1 = dt_CargaListadoCruce.NewRow()

                                        dr1("Nro_Ficha") = inFIPRNUME
                                        dr1("Municipio") = stARCOMUNI_GEO
                                        dr1("Corregimiento") = stARCOCORR_GEO
                                        dr1("Barrio") = stARCOBARR_GEO
                                        dr1("Manzana") = stARCOMANZ_GEO
                                        dr1("Predio") = stARCOPRED_GEO
                                        dr1("Edificio") = stARCOEDIF_GEO
                                        dr1("Unidad_Predial") = stARCOUNPR_GEO
                                        dr1("Sector") = stARCOCLSE_GEO
                                        dr1("Unidad") = stARCOUNID_GEO
                                        dr1("Area_Const_Geodata") = deAREACONS_GEO
                                        dr1("Area_Const_BaseDatos") = deAREACONS_BD
                                        dr1("Porc_Diferencia") = ""
                                        dr1("Inconsistencia") = "Area de construcción en cero"

                                        dt_CargaListadoCruce.Rows.Add(dr1)

                                    End If

                                End If

                            Else

                                ' inserta el registro
                                dr1 = dt_CargaListadoCruce.NewRow()

                                dr1("Nro_Ficha") = inFIPRNUME
                                dr1("Municipio") = stARCOMUNI_GEO
                                dr1("Corregimiento") = stARCOCORR_GEO
                                dr1("Barrio") = stARCOBARR_GEO
                                dr1("Manzana") = stARCOMANZ_GEO
                                dr1("Predio") = stARCOPRED_GEO
                                dr1("Edificio") = stARCOEDIF_GEO
                                dr1("Unidad_Predial") = stARCOUNPR_GEO
                                dr1("Sector") = stARCOCLSE_GEO
                                dr1("Unidad") = stARCOUNID_GEO
                                dr1("Area_Const_Geodata") = stARCOARCO_GEO
                                dr1("Area_Const_BaseDatos") = ""
                                dr1("Porc_Diferencia") = ""
                                dr1("Inconsistencia") = "Unidad de construcción no existe en base de datos"

                                dt_CargaListadoCruce.Rows.Add(dr1)

                            End If

                        Else

                            ' inserta el registro
                            dr1 = dt_CargaListadoCruce.NewRow()

                            dr1("Nro_Ficha") = ""
                            dr1("Municipio") = stARCOMUNI_GEO
                            dr1("Corregimiento") = stARCOCORR_GEO
                            dr1("Barrio") = stARCOBARR_GEO
                            dr1("Manzana") = stARCOMANZ_GEO
                            dr1("Predio") = stARCOPRED_GEO
                            dr1("Edificio") = stARCOEDIF_GEO
                            dr1("Unidad_Predial") = stARCOUNPR_GEO
                            dr1("Sector") = stARCOCLSE_GEO
                            dr1("Unidad") = ""
                            dr1("Area_Const_Geodata") = ""
                            dr1("Area_Const_BaseDatos") = ""
                            dr1("Porc_Diferencia") = ""
                            dr1("Inconsistencia") = "Cedula catastral no existe en base de datos"

                            dt_CargaListadoCruce.Rows.Add(dr1)

                        End If

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbProceso.Value = inProceso

                    Next

                End If

                Me.TabResultado.SelectTab(TabPage3)

                Me.dgvListadoCruce.DataSource = dt_CargaListadoCruce

                Me.cmdValidaDatos.Enabled = False
                Me.cmdEstructurarDatos.Enabled = False
                Me.cmdCruzarDatos.Enabled = False

                pbProceso.Value = 0

                MessageBox.Show("Proceso de cruce terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("No existes registros", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)

            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvListadoCruce.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click

        Try
            If Me.rbdListadoFuente.Checked = True Then
                If Me.dgvListadoFuente.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvListadoFuente.DataSource, DataTable))
                End If
            ElseIf Me.rbdListadoEstructurado.Checked = True Then
                If Me.dgvListadoFuente.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvListadoEstructurado.DataSource, DataTable))
                End If
            ElseIf Me.rbdCruceDeDatos.Checked = True Then
                If Me.dgvListadoFuente.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvListadoCruce.DataSource, DataTable))
                End If
            ElseIf Me.rbdInconsistencias.Checked = True Then
                If Me.dgvListadoFuente.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvInconsistencias.DataSource, DataTable))
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdImportarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImportarDatos.Click

        Try
            Me.dgvListadoEstructurado.DataSource = New DataTable

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

                Me.dgvListadoEstructurado.DataSource = DtSet.Tables(0)

                MyConnection.Close()

            Else
                stNombreLibro = InputBox("Ingrese el nombre de la hoja de excel", "Mensaje")
            End If

            Me.TabResultado.SelectTab(TabPage3)
            Me.cmdCruzarDatos.Enabled = True

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvListadoEstructurado.RowCount

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
        Me.strBARRESTA.Items(0).Text = "Generar areas"
        Me.strBARRESTA.Items(2).Text = "Registros: 0"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmdAbrirArchivoMunicipio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivo.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdAbrirArchivo.AccessibleDescription
    End Sub
    Private Sub cmdValidaDatosMunicipio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdValidaDatos.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdValidaDatos.AccessibleDescription
    End Sub
    Private Sub cmdCargarDatosMunicipio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCruzarDatos.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdCruzarDatos.AccessibleDescription
    End Sub
    Private Sub cmdExportarExcel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdExportarExcel.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub dgvFIPRINCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvListadoFuente.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvListadoFuente.AccessibleDescription
    End Sub

#End Region

#Region "TextChanged"

    Private Sub lblRutaArchivoMunicipio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblRutaArchivo.TextChanged

        If Trim(Me.lblRutaArchivo.Text) <> "" Then
            Me.cmdValidaDatos.Enabled = True
        Else
            Me.cmdValidaDatos.Enabled = False
        End If

    End Sub

#End Region

#End Region

   
End Class