Public Class frm_MANUCATA

    '============================
    '*** MANUALES DE CATASTRO ***
    '============================

#Region "VARIABLES LOCALES"

    '*** 'Determina el tamaño de la fuente de impresión ***
    Dim TamanoFuente As String

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_MANUCATA
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_MANUCATA
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

#Region "COMANDOS"

    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub cmdSALIR_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "IMPRESION"

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
    Private Sub btnPrintDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintDialog.Click
        ' PrintDialog permite al usuario seleccionar la impresora en la que desea imprimir, 
        ' además de otras opciones de impresión.

        PrintDialog1.Document = PrintDocument1
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.Print()
        End If
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

        TamanoFuente = nudTAMANO.Value 'determina el tamaño de la letra de impresión

        ' Declare una variable que contenga la posición del último carácter impreso. Declárela
        ' como estática para que los siguiente eventos PrintPage puedan hacer referencia a ella.
        Static intCurrentChar As Int32
        ' Inicialice la fuente que se va a utilizar en la impresión.
        Dim font As New Font("Arial", TamanoFuente)

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
        e.Graphics.MeasureString(Mid(txtDOCUMENTO.Text, intCurrentChar + 1), font, _
                    New SizeF(intPrintAreaWidth, intPrintAreaHeight), fmt, _
                    intCharsFitted, intLinesFilled)

        ' Imprima el texto en la página.
        e.Graphics.DrawString(Mid(txtDOCUMENTO.Text, intCurrentChar + 1), font, _
            Brushes.Black, rectPrintingArea, fmt)

        ' Haga avanzar el carácter actual hasta el último carácter impreso de esta página. Como 
        ' intCurrentChar es una variable estática, su valor se puede utilizar para la página
        ' siguiente que se va a imprimir. Aumenta en 1 y se pasa a Mid() para imprimir la
        ' página siguiente (vea MeasureString() más arriba).
        intCurrentChar += intCharsFitted

        ' HasMorePages indica al módulo de impresión si debe desencadenarse otro
        ' evento PrintPage.
        If intCurrentChar < txtDOCUMENTO.Text.Length Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            ' Debe restablecer explícitamente intCurrentChar ya que es estática.
            intCurrentChar = 0
        End If
    End Sub
    Private Sub cboSELECCION_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSELECCION.SelectedIndexChanged
        '*** SELECCION DE DOCUMENTO ***

        Dim seleccion As String

        seleccion = cboSELECCION.SelectedIndex

        Select Case seleccion
            Case 0
                Me.txtDOCUMENTO.Text = My.Resources.Catastro
            Case 1
                Me.txtDOCUMENTO.Text = My.Resources.Ley_14_de_1983
            Case 2
                Me.txtDOCUMENTO.Text = My.Resources.Resolución_2555_de_1998
            Case 3
                Me.txtDOCUMENTO.Text = My.Resources.Ley_675_de_2001
            Case 4
                Me.txtDOCUMENTO.Text = My.Resources.Diligenciamiento_de_la_ficha_predial
            Case 5
                Me.txtDOCUMENTO.Text = My.Resources.Procedimientos_para_informar_movimientos
            Case 6
                Me.txtDOCUMENTO.Text = My.Resources.Reconocimiento_y_calificación_de_las_construcciones
            Case 7
                Me.txtDOCUMENTO.Text = My.Resources.Formulas_de_liquidación_de_avalúos_catastrales
            Case 8
                Me.txtDOCUMENTO.Text = My.Resources.Estructura_para_importar_el_propietario_anterior
            Case 9
                Me.txtDOCUMENTO.Text = My.Resources.Estructura_para_importar_area_de_terreno
            Case 10
                Me.txtDOCUMENTO.Text = My.Resources.Estructura_cruce_areas_bd_vs_cartografia
            Case 11
                Me.txtDOCUMENTO.Text = My.Resources.Estructura_importar_cedula_catastral
            Case 12
                Me.txtDOCUMENTO.Text = My.Resources.ESTRUCTURA_CRUCE_MATRICULAS_MUNICIPIO_VS_REGISTRO_XLS___MDB
            Case 13
                Me.txtDOCUMENTO.Text = My.Resources.Estructura_Importacion_Investigacion_Juridica
            Case 14
                Me.txtDOCUMENTO.Text = My.Resources.Resolucion_N_70_de_2011
            Case 15
                Me.txtDOCUMENTO.Text = My.Resources.Estructura_Importacion_Registro_y_Control
            Case 16
                Me.txtDOCUMENTO.Text = My.Resources.Estructura_de_importacion_resoluciones_administrativas
            Case 17
                Me.txtDOCUMENTO.Text = My.Resources.EstructuraImportacionAreaDeConstruccion
            Case 18
                Me.txtDOCUMENTO.Text = My.Resources.Estrcutura_importacion_observacion_ficha_predial
            Case 19
                Me.txtDOCUMENTO.Text = My.Resources.Estructurta_importar_identificador_de_construccion
            Case 20
                Me.txtDOCUMENTO.Text = My.Resources.Generar_areas_mediante_poligonos
            Case 21
                Me.txtDOCUMENTO.Text = My.Resources.Estructura_importar_historicos_de_avaluo
            Case 22
                Me.txtDOCUMENTO.Text = My.Resources.Estructura_de_importacion_zona_economica_ficha_predial
            Case 23
                Me.txtDOCUMENTO.Text = My.Resources.EstructuraImportacionCategoriaPredio
            Case 24
                Me.txtDOCUMENTO.Text = My.Resources.EstructuraImportacionCoeficienteDeEdificio
            Case 25
                Me.txtDOCUMENTO.Text = My.Resources.EstructuraImportacionInformacionRPH
            Case 26
                Me.txtDOCUMENTO.Text = My.Resources.ExtructuraImportacionLinderosFichaPredial
            Case 27
                Me.txtDOCUMENTO.Text = My.Resources.Estructura_ICARE

        End Select

    End Sub
    Private Sub nudTAMANO_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudTAMANO.ValueChanged
        '*** TAMAÑO FUENTE DE IMPRESIÓN ***

        TamanoFuente = nudTAMANO.Value

    End Sub
    Private Sub cmdFUENTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFUENTE.Click
        '*** CONFIGURACIÒN DE FUENTES ***

        Dim oFuentes As New FontDialog

        oFuentes.ShowDialog()
        txtDOCUMENTO.Font = oFuentes.Font

    End Sub
    Private Sub cmdIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' PrintDialog permite al usuario seleccionar la impresora en la que desea imprimir, 
        ' además de otras opciones de impresión.

        PrintDialog1.Document = PrintDocument1
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub

#End Region

#Region "FORMULARIO"

    Private Sub frm_MANUCATA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.strBARRESTA.Items(0).Text = "Manuales catastrales"
    End Sub

#End Region

End Class