Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_reporte_Avaluos_Ficha_Predial

    '=====================================
    '*** LIQUIDAR AVALUO FICHA PREDIAL ***
    '=====================================

#Region "VARIABLES"

#Region "Conexion"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

    Dim inProceso As Integer
    Dim inTotalRegistros As Integer
    Dim inNroInconsistencias As Integer
    Dim stSeparador As String

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_reporte_Avaluos_Ficha_Predial
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_reporte_Avaluos_Ficha_Predial
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
        txtFIPRFIIN.Text = "0"
        txtFIPRFIFI.Text = "999999999"
        txtFIPRTIFI.Text = "0"
        txtFIPRMUNI.Text = "%"
        txtFIPRCORR.Text = "%"
        txtFIPRBARR.Text = "%"
        txtFIPRMANZ.Text = "%"
        txtFIPRPRED.Text = "%"
        txtFIPREDIF.Text = "%"
        txtFIPRUNPR.Text = "%"
        txtFIPRCLSE.Text = "%"
        txtFIPRINCO.Text = ""
        strBARRESTA.Items(2).Text = "Registros : 0"
        pbPROCESO.Value = 0

        Dim tbl11 As New DataTable
        dgvFIPRINCO.DataSource = tbl11

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdVALIDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIQUIDAR.Click

        Try
            ' valores predeterminados
            txtFIPRINCO.Text = ""
            cmdLIQUIDAR.Enabled = False
            inNroInconsistencias = 0

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
            ParametrosConsulta += "Fiprnufi, "
            ParametrosConsulta += "Fiprreso, "
            ParametrosConsulta += "Fiprvige, "
            ParametrosConsulta += "Fiprtire "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(txtFIPRMUNI.Text) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(txtFIPRCORR.Text) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(txtFIPRBARR.Text) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(txtFIPRMANZ.Text) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(txtFIPRPRED.Text) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(txtFIPREDIF.Text) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(txtFIPRUNPR.Text) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(txtFIPRCLSE.Text) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(txtFIPRTIFI.Text) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(txtFIPRFIIN.Text) & "' and '" & Trim(txtFIPRFIFI.Text) & "' and "
            ParametrosConsulta += "FiprEsta = 'ac' "

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

            ' valida las ficha encontradas en la consulta
            If dt.Rows.Count > 0 Then

                ' Total de registros
                inTotalRegistros = dt.Rows.Count

                ' Valores predeterminados ProgressBar
                inProceso = 0
                pbPROCESO.Value = 0
                pbPROCESO.Maximum = dt.Rows.Count
                Timer1.Enabled = True

                ' Crea objeto de columnas y registros
                Dim dt1 As New DataTable
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                dt1.Columns.Add(New DataColumn("Cedula catastral", GetType(String)))
                dt1.Columns.Add(New DataColumn("Area terreno privada Mts2", GetType(String)))
                dt1.Columns.Add(New DataColumn("Area terreno común Mts2", GetType(String)))
                dt1.Columns.Add(New DataColumn("Area const. privada Mts2", GetType(String)))
                dt1.Columns.Add(New DataColumn("Area const. común Mts2", GetType(String)))
                dt1.Columns.Add(New DataColumn("Valor terreno privado", GetType(String)))
                dt1.Columns.Add(New DataColumn("Valor terreno común", GetType(String)))
                dt1.Columns.Add(New DataColumn("Valor const. privado", GetType(String)))
                dt1.Columns.Add(New DataColumn("Valor const. común", GetType(String)))
                dt1.Columns.Add(New DataColumn("Valor avalúo total", GetType(String)))

                ' Recorre el rango asignado
                Dim i As Integer

                ' recorre la fichas consultadas
                For i = 0 To dt.Rows.Count - 1

                    ' crea la variable para validar individualmente
                    Dim inFicha As Integer = dt.Rows(i).Item("FIPRNUFI")

                    Dim inResolucion As Integer = dt.Rows(i).Item("FIPRRESO")
                    Dim inVigencia As Integer = dt.Rows(i).Item("FIPRVIGE")
                    Dim inDocumento As Integer = dt.Rows(i).Item("FIPRTIRE")

                    pro_LIQUIDA_AVALUO_FICHA_PREDIAL(inFicha, inResolucion, inVigencia, inDocumento, "Liquidación maxiva")

                    ' consulta las inconsistencas de las fichas validadas
                    Dim objdatos As New cla_FIPRAVAL
                    Dim tbl As New DataTable

                    tbl = objdatos.fun_Consultar_AVALUO_X_FICHA_PREDIAL(inFicha)

                    ' verifica que exista avalúo
                    If tbl.Rows.Count > 0 Then

                        ' Almacena la ficha predial
                        Dim objdatos55 As New cla_FICHPRED
                        Dim tbl55 As New DataTable

                        tbl55 = objdatos55.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(inFicha)

                        ' Inserta el registro en el DataTable
                        dr1 = dt1.NewRow()
                        dr1("Nro_Ficha") = tbl.Rows(0).Item("FPAVNUFI")
                        dr1("Cedula catastral") = Trim(tbl55.Rows(0).Item("FIPRMUNI")) & "-" & _
                                                  Trim(tbl55.Rows(0).Item("FIPRCORR")) & "-" & _
                                                  Trim(tbl55.Rows(0).Item("FIPRBARR")) & "-" & _
                                                  Trim(tbl55.Rows(0).Item("FIPRMANZ")) & "-" & _
                                                  Trim(tbl55.Rows(0).Item("FIPRPRED")) & "-" & _
                                                  Trim(tbl55.Rows(0).Item("FIPREDIF")) & "-" & _
                                                  Trim(tbl55.Rows(0).Item("FIPRUNPR"))
                        dr1("Area terreno privada Mts2") = tbl.Rows(0).Item("FPAVATPR")
                        dr1("Area terreno común Mts2") = tbl.Rows(0).Item("FPAVATCO")
                        dr1("Area const. privada Mts2") = Trim(tbl.Rows(0).Item("FPAVACPR"))
                        dr1("Area const. común Mts2") = Trim(tbl.Rows(0).Item("FPAVACCO"))
                        dr1("Valor terreno privado") = tbl.Rows(0).Item("FPAVVATP")
                        dr1("Valor terreno común") = tbl.Rows(0).Item("FPAVVATC")
                        dr1("Valor const. privado") = tbl.Rows(0).Item("FPAVVACP")
                        dr1("Valor const. común") = tbl.Rows(0).Item("FPAVVACC")
                        dr1("Valor avalúo total") = tbl.Rows(0).Item("FPAVAVAL")

                        dt1.Rows.Add(dr1)

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbPROCESO.Value = inProceso

                Next

                ' Llena el datagrigview
                Me.dgvFIPRINCO.DataSource = dt1
                pbPROCESO.Value = 0

                If Me.dgvFIPRINCO.RowCount > 0 Then
                    MessageBox.Show("Proceso de liquidación de avalúos terminado", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRINCO.RowCount
                Else
                    ' Mensaje terminacion
                    MessageBox.Show("Proceso de liquidación de avalúos terminado", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.strBARRESTA.Items(2).Text = "Registros : 0"
                End If

            Else
                ' Mensaje terminacion
                MessageBox.Show("NO existen registros con los parametros asignados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.strBARRESTA.Items(2).Text = "Registros : 0"
            End If

            cmdLIQUIDAR.Enabled = True
            cmdLIQUIDAR.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdLIQUIDAR.Enabled = True
        End Try

    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
        txtFIPRFIIN.Focus()

    End Sub
    Private Sub cmdIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIMPRIMIR.Click
        ' PrintDialog permite al usuario seleccionar la impresora en la que desea imprimir, 
        ' además de otras opciones de impresión.

        PrintDialog1.Document = PrintDocument1
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.Print()
        End If

    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        pro_LimpiarCampos()
        txtFIPRFIIN.Focus()
        Me.Close()
    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        Try
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
                    txtFIPRFIIN.Focus()
                End If
            Else
                MessageBox.Show("Ejecute la consulta antes de exportar el plano", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        ' PrintPreviewDialog está asociado a PrintDocument; cuando se procesa la 
        ' vista previa, se desencadena el evento PrintPage. A este evento se pasa un contexto 
        ' gráfico en el que se "dibuja" la página.

        Try
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.ShowDialog()
        Catch exp As Exception
            MsgBox("An error occurred while trying to load the " & _
                "document for Print Preview. Make sure you currently have " & _
                "access to a printer. A printer must be connected and " & _
                "accessible for Print Preview to work.", MsgBoxStyle.OkOnly, _
                 Me.Text)
        End Try

    End Sub
    Private Sub btnPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPageSetup.Click
        ' La configuración de página permite especificar aspectos tales como el tamaño del papel, la orientación vertical, 
        ' horizontal, etc.

        With PageSetupDialog1
            .Document = PrintDocument1
            .PageSettings = PrintDocument1.DefaultPageSettings
        End With

        If PageSetupDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.DefaultPageSettings = PageSetupDialog1.PageSettings
        End If

    End Sub
    Private Sub pdoc_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        '-------------------------------------------------------------------------------------------------------
        '*** ESTE SUB PROGRAMA DEBE COPIAR EN EL FORMULARIO QUE SE INSTALE LOS BOTONES PARA IMPRIMIR ***
        '-----------------------------------------------------------------------------------------------

        'TamanoFuente = "10" 'nudTAMANO.Value 'determina el tamaño de la letra de impresión

        ' Declare una variable que contenga la posición del último carácter impreso. Declárela
        ' como estática para que los siguiente eventos PrintPage puedan hacer referencia a ella.
        Static intCurrentChar As Int32
        ' Inicialice la fuente que se va a utilizar en la impresión.
        Dim font As New Font("Arial", 10)

        Dim intPrintAreaHeight, intPrintAreaWidth, marginLeft, marginTop As Int32
        With PrintDocument1.DefaultPageSettings
            ' Inicialice variables locales que contengan los límites del rectángulo del 
            ' área de impresión.
            intPrintAreaHeight = .PaperSize.Height - .Margins.Top - .Margins.Bottom
            intPrintAreaWidth = .PaperSize.Width - .Margins.Left - .Margins.Right

            ' Inicialice variables locales que contengan los valores de margen que servirán
            ' de coordenadas X e Y para la esquina superior izquierda del rectángulo 
            ' del área de impresión.
            marginLeft = .Margins.Left ' Coordenada X
            marginTop = .Margins.Top ' Coordenada Y
        End With

        ' Si el usuario ha seleccionado el modo Horizontal, cambie el alto y el ancho 
        ' del área de impresión.
        If PrintDocument1.DefaultPageSettings.Landscape Then
            Dim intTemp As Int32
            intTemp = intPrintAreaHeight
            intPrintAreaHeight = intPrintAreaWidth
            intPrintAreaWidth = intTemp
        End If

        ' Calcule el número total de líneas en el documento a partir del alto del
        ' área de impresión y del alto de la fuente.
        Dim intLineCount As Int32 = CInt(intPrintAreaHeight / font.Height)
        ' Inicialice la estructura del rectángulo que define el área de impresión.
        Dim rectPrintingArea As New RectangleF(marginLeft, marginTop, intPrintAreaWidth, intPrintAreaHeight)

        ' Cree una instancia de la clase StringFormat, que encapsula la información de diseño 
        ' del texto (como la alineación y el espaciado de las líneas ), muestra las manipulaciones 
        ' (como la inserción de puntos suspensivos y la sustitución de dígitos nacionales) y las características de 
        ' OpenType. El uso de StringFormat permite que MeasureString y DrawString utilicen
        ' sólo un número entero de líneas al imprimir cada página, omitiendo las líneas
        ' parciales que probablemente se imprimirían si el número de líneas por 
        ' página no se dividiera exactamente para cada página (lo que ocurre habitualmente).
        ' Consulte la documentación del SDK sobre StringFormatFlags para obtener más información.
        Dim fmt As New StringFormat(StringFormatFlags.LineLimit)
        ' Llame a MeasureString para determinar el número de caracteres que caben en
        ' el rectángulo del área de impresión. A CharFitted Int32 se pasa ByRef y se utiliza
        ' más adelante cuando se calcula intCurrentChar y, por tanto, HasMorePages. LinesFilled 
        ' no es necesario para este ejemplo, pero debe pasarse cuando se pasa CharsFitted.
        ' Mid se utiliza para pasar el segmento de texto restante que queda de la 
        ' página anterior impresa (recuerde que intCurrentChar se declaró como 
        ' estática).
        Dim intLinesFilled, intCharsFitted As Int32
        e.Graphics.MeasureString(Mid(txtFIPRINCO.Text, intCurrentChar + 1), font, _
                    New SizeF(intPrintAreaWidth, intPrintAreaHeight), fmt, _
                    intCharsFitted, intLinesFilled)

        ' Imprima el texto en la página.
        e.Graphics.DrawString(Mid(txtFIPRINCO.Text, intCurrentChar + 1), font, _
            Brushes.Black, rectPrintingArea, fmt)

        ' Haga avanzar el carácter actual hasta el último carácter impreso de esta página. Como 
        ' intCurrentChar es una variable estática, su valor se puede utilizar para la página
        ' siguiente que se va a imprimir. Aumenta en 1 y se pasa a Mid() para imprimir la
        ' página siguiente (vea MeasureString() más arriba).
        intCurrentChar += intCharsFitted

        ' HasMorePages indica al módulo de impresión si debe desencadenarse otro
        ' evento PrintPage.
        If intCurrentChar < txtFIPRINCO.Text.Length Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            ' Debe restablecer explícitamente intCurrentChar ya que es estática.
            intCurrentChar = 0
        End If
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_REPO_FIPRINCO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strBARRESTA.Items(2).Text = "Registros : 0"
    End Sub

#End Region

#Region "Timer1"

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If inProceso = inTotalRegistros Then
            inProceso = 0
            Timer1.Enabled = False
        End If

    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtFIPRFIIN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRFIIN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRFIFI.Focus()
        End If
    End Sub
    Private Sub txtFIPRFIFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRFIFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRTIFI.Focus()
        End If
    End Sub
    Private Sub txtFIPRTIFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRTIFI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRMUNI.Focus()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtFIPRMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMUNI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRCORR.Focus()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtFIPRCORR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCORR.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRBARR.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRBARR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRBARR.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRMANZ.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRMANZ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMANZ.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRPRED.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRPRED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRPRED.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPREDIF.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPREDIF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPREDIF.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRUNPR.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRUNPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRUNPR.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRCLSE.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCLSE.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        cmdLIQUIDAR.Focus()
                    End If
                End If
            End If
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtFIPRFIIN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIIN.GotFocus
        txtFIPRFIIN.SelectionStart = 0
        txtFIPRFIIN.SelectionLength = Len(txtFIPRFIIN.Text)
        strBARRESTA.Items(0).Text = txtFIPRFIIN.AccessibleDescription
    End Sub
    Private Sub txtFIPRFIFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIFI.GotFocus
        txtFIPRFIFI.SelectionStart = 0
        txtFIPRFIFI.SelectionLength = Len(txtFIPRFIFI.Text)
        strBARRESTA.Items(0).Text = txtFIPRFIFI.AccessibleDescription
    End Sub
    Private Sub txtFIPRTIFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRTIFI.GotFocus
        txtFIPRTIFI.SelectionStart = 0
        txtFIPRTIFI.SelectionLength = Len(txtFIPRTIFI.Text)
        strBARRESTA.Items(0).Text = txtFIPRTIFI.AccessibleDescription
    End Sub
    Private Sub txtFIPRMUNI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.GotFocus
        txtFIPRMUNI.SelectionStart = 0
        txtFIPRMUNI.SelectionLength = Len(txtFIPRMUNI.Text)
        strBARRESTA.Items(0).Text = txtFIPRMUNI.AccessibleDescription
    End Sub
    Private Sub txtFIPRCORR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.GotFocus
        txtFIPRCORR.SelectionStart = 0
        txtFIPRCORR.SelectionLength = Len(txtFIPRCORR.Text)
        strBARRESTA.Items(0).Text = txtFIPRCORR.AccessibleDescription
    End Sub
    Private Sub txtFIPRBARR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.GotFocus
        txtFIPRBARR.SelectionStart = 0
        txtFIPRBARR.SelectionLength = Len(txtFIPRBARR.Text)
        strBARRESTA.Items(0).Text = txtFIPRBARR.AccessibleDescription
    End Sub
    Private Sub txtFIPRMANZ_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.GotFocus
        txtFIPRMANZ.SelectionStart = 0
        txtFIPRMANZ.SelectionLength = Len(txtFIPRMANZ.Text)
        strBARRESTA.Items(0).Text = txtFIPRMANZ.AccessibleDescription
    End Sub
    Private Sub txtFIPRPRED_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.GotFocus
        txtFIPRPRED.SelectionStart = 0
        txtFIPRPRED.SelectionLength = Len(txtFIPRPRED.Text)
        strBARRESTA.Items(0).Text = txtFIPRPRED.AccessibleDescription
    End Sub
    Private Sub txtFIPREDIF_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.GotFocus
        txtFIPREDIF.SelectionStart = 0
        txtFIPREDIF.SelectionLength = Len(txtFIPREDIF.Text)
        strBARRESTA.Items(0).Text = txtFIPREDIF.AccessibleDescription
    End Sub
    Private Sub txtFIPRUNPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.GotFocus
        txtFIPRUNPR.SelectionStart = 0
        txtFIPRUNPR.SelectionLength = Len(txtFIPRUNPR.Text)
        strBARRESTA.Items(0).Text = txtFIPRUNPR.AccessibleDescription
    End Sub
    Private Sub txtFIPRCLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCLSE.GotFocus
        txtFIPRCLSE.SelectionStart = 0
        txtFIPRCLSE.SelectionLength = Len(txtFIPRCLSE.Text)
        strBARRESTA.Items(0).Text = txtFIPRCLSE.AccessibleDescription
    End Sub
    Private Sub txtFIPRINCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        strBARRESTA.Items(0).Text = txtFIPRINCO.AccessibleDescription
    End Sub
    Private Sub cmdVALIDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIQUIDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIQUIDAR.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub
    Private Sub cmdIMPRIMIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdIMPRIMIR.GotFocus
        strBARRESTA.Items(0).Text = cmdIMPRIMIR.AccessibleDescription
    End Sub
    Private Sub btnPrintPreview_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintPreview.GotFocus
        strBARRESTA.Items(0).Text = btnPrintPreview.AccessibleDescription
    End Sub
    Private Sub btnPageSetup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPageSetup.GotFocus
        strBARRESTA.Items(0).Text = btnPageSetup.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub cmdExportarExcel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.GotFocus
        strBARRESTA.Items(0).Text = cmdExportarExcel.AccessibleDescription
    End Sub
    Private Sub cmdExportarPlano_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.GotFocus
        strBARRESTA.Items(0).Text = cmdExportarPlano.AccessibleDescription
    End Sub


#End Region

#Region "Validated"

    Private Sub txtFIPRFIIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIIN.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRFIIN.Text)) = True Then
            Me.txtFIPRFIIN.Text = Val(Trim(Me.txtFIPRFIIN.Text))
        Else
            Me.txtFIPRFIIN.Focus()
            mod_MENSAJE.Inco_Valo_Nume()
        End If
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRFIFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIFI.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRFIFI.Text)) = True Then
            Me.txtFIPRFIFI.Text = Val(Trim(Me.txtFIPRFIFI.Text))
        Else
            Me.txtFIPRFIFI.Focus()
            mod_MENSAJE.Inco_Valo_Nume()
        End If
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRTIFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRTIFI.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRTIFI.Text)) = True Then
            Me.txtFIPRTIFI.Text = Val(Trim(Me.txtFIPRTIFI.Text))
        Else
            Me.txtFIPRTIFI.Focus()
            mod_MENSAJE.Inco_Valo_Nume()
        End If

        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.Validated
        txtFIPRMUNI.Text = fun_Formato_Mascara_3_String(txtFIPRMUNI.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.Validated
        txtFIPRCORR.Text = fun_Formato_Mascara_2_String(txtFIPRCORR.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.Validated
        txtFIPRBARR.Text = fun_Formato_Mascara_3_String(txtFIPRBARR.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.Validated
        txtFIPRMANZ.Text = fun_Formato_Mascara_3_String(txtFIPRMANZ.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.Validated
        txtFIPRPRED.Text = fun_Formato_Mascara_5_String(txtFIPRPRED.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.Validated
        txtFIPREDIF.Text = fun_Formato_Mascara_3_String(txtFIPREDIF.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.Validated
        txtFIPRUNPR.Text = fun_Formato_Mascara_5_String(txtFIPRUNPR.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#End Region

End Class