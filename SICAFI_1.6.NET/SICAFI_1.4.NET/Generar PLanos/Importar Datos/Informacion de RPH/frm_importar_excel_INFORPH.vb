Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_importar_excel_INFORPH

    '====================================================
    '*** FORMULARIO IMPORTAR EXCEL INFORMACIÓN DE RPH ***
    '====================================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_importar_excel_INFORPH
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_importar_excel_INFORPH
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
    Dim dt_FPCELIST As New DataTable

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
    Private Sub pro_ValidarCategoriaFichaPredial()

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
        dt1.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
        dt1.Columns.Add(New DataColumn("Direccion", GetType(String)))
        dt1.Columns.Add(New DataColumn("Matricula", GetType(String)))
        dt1.Columns.Add(New DataColumn("Area_Cons", GetType(String)))
        dt1.Columns.Add(New DataColumn("Coef_Edif", GetType(String)))
        dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))

        ' crea la variable
        Dim i As Integer = 0

        ' crea la tabla
        dt_FPCELIST = New DataTable

        ' carga la tabla
        dt_FPCELIST = Me.dgvFIPRLIST.DataSource

        For i = 0 To dt_FPCELIST.Rows.Count - 1

            ' verifica que el campo numero de ficha este lleno
            If Trim(dt_FPCELIST.Rows(i).Item(0).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                dr1("Direccion") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                dr1("Matricula") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                dr1("Area_Cons") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                dr1("Coef_Edif") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                dr1("Descripcion") = "El campo nro de ficha esta vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FPCELIST.Rows(i).Item(0).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Nro_Ficha") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                    dr1("Direccion") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                    dr1("Matricula") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                    dr1("Area_Cons") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                    dr1("Coef_Edif") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                    dr1("Descripcion") = "El campo nro de ficha no es numerico"

                    dt1.Rows.Add(dr1)

                End If

            End If

            ' verifica que el campo direccion este lleno
            If Trim(dt_FPCELIST.Rows(i).Item(1).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                dr1("Direccion") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                dr1("Matricula") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                dr1("Area_Cons") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                dr1("Coef_Edif") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                dr1("Descripcion") = "El campo direccion esta vacio"

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo matricula este lleno
            If Trim(dt_FPCELIST.Rows(i).Item(2).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                dr1("Direccion") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                dr1("Matricula") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                dr1("Area_Cons") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                dr1("Coef_Edif") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                dr1("Descripcion") = "El campo matricula esta vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FPCELIST.Rows(i).Item(2).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Nro_Ficha") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                    dr1("Direccion") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                    dr1("Matricula") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                    dr1("Area_Cons") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                    dr1("Coef_Edif") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                    dr1("Descripcion") = "El campo matricula no es numerico"

                    dt1.Rows.Add(dr1)

                End If

            End If

            ' verifica que el campo area este lleno
            If Trim(dt_FPCELIST.Rows(i).Item(3).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                dr1("Direccion") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                dr1("Matricula") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                dr1("Area_Cons") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                dr1("Coef_Edif") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                dr1("Descripcion") = "El campo area esta vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(dt_FPCELIST.Rows(i).Item(3).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Nro_Ficha") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                    dr1("Direccion") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                    dr1("Matricula") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                    dr1("Area_Cons") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                    dr1("Coef_Edif") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                    dr1("Descripcion") = "El campo area no es decimal"

                    dt1.Rows.Add(dr1)

                End If

            End If

            ' verifica que el campo coeficiente este lleno
            If Trim(dt_FPCELIST.Rows(i).Item(4).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                dr1("Direccion") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                dr1("Matricula") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                dr1("Area_Cons") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                dr1("Coef_Edif") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                dr1("Descripcion") = "El campo coeficiente esta vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(dt_FPCELIST.Rows(i).Item(4).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Nro_Ficha") = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                    dr1("Direccion") = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                    dr1("Matricula") = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                    dr1("Area_Cons") = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                    dr1("Coef_Edif") = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)
                    dr1("Descripcion") = "El campo coeficiente no es decimal"

                    dt1.Rows.Add(dr1)

                End If

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
    Private Sub pro_GuardarCategoriaFichaPredial()

        Try
            ' apaga el boton grabar datos
            Me.cmdGrabarDatos.Enabled = False

            ' Valores predeterminados ProgressBar
            inProceso = 0
            Me.pbPROCESO.Value = 0
            Me.pbPROCESO.Maximum = inTotalRegistros + 1
            Me.Timer1.Enabled = True

            ' declara la variable
            Dim i As Integer = 0

            ' crea la tabla
            dt_FPCELIST = New DataTable

            ' declara las variables
            Dim stFIPRNUFI As String = ""
            Dim stFIPRDIRE As String = ""
            Dim stFIPRMAIN As String = ""
            Dim stFIPRARCO As String = ""
            Dim stFIPRCOED As String = ""
            Dim stFIPRESTA As String = "ac"

            ' carga la tabla
            dt_FPCELIST = Me.dgvFIPRLIST.DataSource

            ' declaro la variable
            Dim inContadorFichaPredial As Integer = 0
            Dim inContadorConstruccion As Integer = 0
            Dim inContadorPropietarios As Integer = 0

            ' recorre la table
            For i = 0 To dt_FPCELIST.Rows.Count - 1

                ' llena las variables
                stFIPRNUFI = Trim(dt_FPCELIST.Rows(i).Item(0).ToString)
                stFIPRDIRE = Trim(dt_FPCELIST.Rows(i).Item(1).ToString)
                stFIPRMAIN = Trim(dt_FPCELIST.Rows(i).Item(2).ToString)
                stFIPRARCO = Trim(dt_FPCELIST.Rows(i).Item(3).ToString)
                stFIPRCOED = Trim(dt_FPCELIST.Rows(i).Item(4).ToString)

                ' verifica el dato
                Dim boFIPRNUFI As Boolean = fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRNUFI)
                Dim boFIPRMAIN As Boolean = fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRMAIN)
                Dim boFIPRARCO As Boolean = fun_Verificar_Dato_Decimal_Evento_Validated(stFIPRARCO)
                Dim boFIPRCOED As Boolean = fun_Verificar_Dato_Decimal_Evento_Validated(stFIPRCOED)

                ' valida el dato
                If boFIPRNUFI = True And _
                   boFIPRMAIN = True And _
                   boFIPRARCO = True And _
                   boFIPRCOED = True Then

                    ' Instancia la clase
                    Dim objdatos As New cla_FICHPRED
                    Dim tbl As New DataTable

                    tbl = objdatos.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(stFIPRNUFI)

                    If tbl.Rows.Count > 0 Then

                        ' declaro la variable
                        Dim stFIPRDEPA As String = CStr(Trim(tbl.Rows(0).Item("FIPRDEPA").ToString))
                        Dim stFIPRMUNI As String = CStr(Trim(tbl.Rows(0).Item("FIPRMUNI").ToString))

                        ' declara la variable
                        Dim inTamanoDireccion As Integer = Trim(stFIPRDIRE).ToString.Length

                        If inTamanoDireccion >= 50 Then
                            stFIPRDIRE = stFIPRDIRE.ToString.Substring(0, 49).ToString.ToUpper
                        Else
                            stFIPRDIRE = stFIPRDIRE.ToString.ToUpper
                        End If

                        ' actualiza ficha predial
                        Dim objdatos1 As New cla_FICHPRED


                        If objdatos1.fun_Actualizar_DIRE_COED_X_FICHPRED(stFIPRNUFI, stFIPRDIRE, fun_Formato_Decimal_6_Decimales(stFIPRCOED)) = True Then
                            inContadorFichaPredial += 1
                        End If

                        ' instancia la clase
                        Dim objdatos4 As New cla_FIPRCONS
                        Dim tbldatos4 As New DataTable

                        tbldatos4 = objdatos4.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(stFIPRNUFI)

                        If tbldatos4.Rows.Count > 0 Then

                            ' actuliza construccion
                            Dim objdatos2 As New cla_FIPRCONS

                            If objdatos2.fun_Actualizar_ARCO_X_FIPRCONS(stFIPRNUFI, fun_Formato_Decimal_2_Decimales(stFIPRARCO)) = True Then
                                inContadorConstruccion += 1
                            End If

                        End If

                        ' instancia la clase
                        Dim objdatos5 As New cla_FIPRPROP
                        Dim tbldatos5 As New DataTable

                        tbldatos5 = objdatos5.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(stFIPRNUFI)

                        If tbldatos5.Rows.Count > 0 Then

                            ' instancia la clase
                            Dim objdatos6 As New cla_CIRCREGI
                            Dim tbldatos6 As New DataTable

                            tbldatos6 = objdatos6.fun_Buscar_CODIGO_DEPA_MUNI_X_MANT_CIRCREGI(stFIPRDEPA, stFIPRMUNI)

                            If tbldatos6.Rows.Count > 0 Then

                                ' declara la variable
                                Dim stCirculaRegistral As String = CStr(Trim(tbldatos6.Rows(0).Item("CIRECIRE").ToString))

                                ' actualiza propietario
                                Dim objdatos3 As New cla_FIPRPROP

                                If objdatos3.fun_Actualizar_MAIN_X_FIPRPROP(stFIPRNUFI, stCirculaRegistral & "-" & fun_Formato_Mascara_7_Reales(stFIPRMAIN)) = True Then
                                    inContadorPropietarios += 1
                                End If

                            End If

                        End If

                    End If

                End If

                ' Incrementa la barra
                inProceso = inProceso + 1
                Me.pbPROCESO.Value = inProceso

            Next

            ' Llena el datagrigview
            TabControl1.SelectTab(TabPage1)
            pbPROCESO.Value = 0

            mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

            MessageBox.Show("Se actualizaron: " & inContadorFichaPredial & " fichas prediales. " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorConstruccion & " áreas de construcción. " & Chr(Keys.Enter) & _
                            "Se actualizaron: " & inContadorPropietarios & " matriculas inmobiliarias. " & Chr(Keys.Enter), "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
           
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

                pro_ValidarCategoriaFichaPredial()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdGrabarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabarDatos.Click

        Try
            If Me.dgvFIPRINCO.RowCount = 0 Then
                If Trim(stRutaArchivo) <> "" Then

                    pro_GuardarCategoriaFichaPredial()

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

#End Region

#End Region

End Class