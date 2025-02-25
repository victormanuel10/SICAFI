#Region "IMPORTS"

Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text
Imports Microsoft.Office.Interop
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf

#End Region

Public Class frm_insertar_archivo_OBLIURBA

    '==================================================
    '*** INSERTAR ARCHIVO OBLIGACIONES URBANISTICAS ***
    '==================================================

#Region "VARIABLE"

    Dim dt1 As New DataTable
    Dim dr1 As DataRow

    Dim oLeer As New OpenFileDialog

    Dim vl_stOBURCLEN As String = ""
    Dim lv_inOBURNURA As Integer = 0
    Dim lv_inOBURVIGE As Integer = 0

    Dim vl_stRutaDocumentos As String = ""
    Dim vl_stRutaDocumentosIndividual As String = ""

    Dim vl_boArchivoIndivial As Boolean = False
    Dim vl_inLongitudEstension As Integer = 0
    Dim vl_boArchivoExistente As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal stOBURCLEN As String, _
                   ByVal inOBURNURA As Integer, _
                   ByVal inOBURVIGE As Integer)

        vl_stOBURCLEN = stOBURCLEN
        lv_inOBURNURA = inOBURNURA
        lv_inOBURVIGE = inOBURVIGE

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
        pro_ListadoArchivosDocumentos()

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_ConsultarRutaInicial() As String

        Try
            Dim stRutaInicial As String = ""

            stRutaInicial = vl_stRutaDocumentos & "\" & Me.lstLISTADO_DOCUMENTOS.SelectedItem

            Return stRutaInicial

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return ""
        End Try

    End Function
    Private Function fun_consultarRutaDestino() As String

        Try
            Dim stRuta As String = ""

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(22)

            If tblRutas.Rows.Count > 0 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(vl_stOBURCLEN) & "-" & lv_inOBURNURA & "-" & lv_inOBURVIGE & "\" & Me.lstLISTADO_DOCUMENTOS.SelectedItem

            End If

            Return stRuta

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return ""
        End Try

    End Function
    Private Function fun_IdentificarDocumentoWord(ByVal stDocumento As String) As Boolean

        Try
            ' declara la variable
            Dim boRespuesta As Boolean = False
            Dim stExtension As String = System.IO.Path.GetExtension(CStr(stDocumento))

            Select Case stExtension

                Case ".doc"
                    boRespuesta = True
                    vl_inLongitudEstension = 3

                Case ".docx"
                    boRespuesta = True
                    vl_inLongitudEstension = 4

            End Select

            Return boRespuesta

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_IdentificarDocumentoImagen(ByVal stDocumento As String) As Boolean

        Try
            ' declara la variable
            Dim boRespuesta As Boolean = False
            Dim stExtension As String = System.IO.Path.GetExtension(CStr(stDocumento))

            Select Case stExtension

                Case ".tif"
                    boRespuesta = True
                    vl_inLongitudEstension = 3

                Case ".tiff"
                    boRespuesta = True
                    vl_inLongitudEstension = 4

            End Select

            Return boRespuesta

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.lstLISTADO_DOCUMENTOS.Items.Clear()

    End Sub
    Private Sub pro_inicializarControles()

        Try
            Dim objRuta As New cla_RUTAS
            Dim tblRuta As New DataTable

            tblRuta = objRuta.fun_Buscar_CODIGO_MANT_RUTAS(19)

            If tblRuta.Rows.Count > 0 Then
                Me.lblRuta.Text = Trim(tblRuta.Rows(0).Item("RUTARUTA").ToString)
            Else
                Me.lblRuta.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListadoArchivosDocumentos()

        Try
            Me.lstLISTADO_DOCUMENTOS.Items.Clear()

            ' declara la variable
            Dim stRuta As String = ""
            Dim stNewPath As String = ""
            Dim ContentItem As String

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(19)

            If tblRutas.Rows.Count > 0 Then

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA"))

                vl_stRutaDocumentos = stNewPath

                ChDir(stNewPath)

                Me.lstLISTADO_DOCUMENTOS.Items.Clear()

                ContentItem = Dir("*.*")

                If ContentItem <> "" Then
                    Me.lstLISTADO_DOCUMENTOS.Focus()
                End If

                Dim i As Integer = 0

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstLISTADO_DOCUMENTOS.Items.Add(ContentItem)

                    'desplaza el registro
                    ContentItem = Dir()

                    ' cuenta los registros
                    i += 1
                Loop

                Me.strBARRESTA.Items(2).Text = "Registro: " & i
            Else
                Me.lstLISTADO_DOCUMENTOS.Items.Clear()
                Me.strBARRESTA.Items(2).Text = "Registro: " & 0
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListadoArchivosDocumentos(ByVal stRutaCarpeta As String)

        Try
            Me.lstLISTADO_DOCUMENTOS.Items.Clear()

            ' declara la variable
            Dim stRuta As String = ""
            Dim stNewPath As String = ""
            Dim ContentItem As String

            If stRutaCarpeta <> "" Then

                stNewPath = Trim(stRutaCarpeta)

                vl_stRutaDocumentos = stNewPath

                ChDir(stNewPath)

                Me.lstLISTADO_DOCUMENTOS.Items.Clear()

                ContentItem = Dir("*.*")

                If ContentItem <> "" Then
                    Me.lstLISTADO_DOCUMENTOS.Focus()
                End If

                Dim i As Integer = 0

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstLISTADO_DOCUMENTOS.Items.Add(ContentItem)

                    'desplaza el registro
                    ContentItem = Dir()

                    ' cuenta los registros
                    i += 1
                Loop

                Me.strBARRESTA.Items(2).Text = "Registro: " & i
            Else
                Me.lstLISTADO_DOCUMENTOS.Items.Clear()
                Me.strBARRESTA.Items(2).Text = "Registro: " & 0
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_CopiarDocumento(ByVal stRutaInicial As String, ByVal stRutaDestino As String)

        Try
            If File.Exists(Trim(stRutaDestino)) = False Then

                ' identifica el archivo word
                If fun_IdentificarDocumentoWord(Trim(stRutaInicial)) = True Then

                    If MessageBox.Show("¿ Desea convertir y copiar el archivo Word en PDF ? ", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim stRutaDestinoPDF As String = Trim(stRutaDestino.ToString.Substring(0, (Trim(Val(stRutaDestino.ToString.Length) - vl_inLongitudEstension))) & "pdf")

                        If File.Exists(Trim(stRutaDestinoPDF)) = False Then
                            pro_ConvertirDocumentoWordaPDF(Trim(stRutaInicial), Trim(stRutaDestinoPDF))
                            vl_boArchivoExistente = False

                        ElseIf File.Exists(Trim(stRutaDestinoPDF)) = True Then

                            mod_MENSAJE.El_Archivo_Existe_En_La_Ruta_De_Destino()
                            vl_boArchivoExistente = True
                        End If

                    Else

                        If File.Exists(Trim(stRutaDestino)) = False Then
                            File.Copy(Trim(stRutaInicial), Trim(stRutaDestino))
                            vl_boArchivoExistente = False

                        ElseIf File.Exists(Trim(stRutaDestino)) = True Then

                            mod_MENSAJE.El_Archivo_Existe_En_La_Ruta_De_Destino()
                            vl_boArchivoExistente = True
                        End If

                    End If

                Else
                    ' copia cualquier archivo que no sea word
                    File.Copy(Trim(stRutaInicial), Trim(stRutaDestino))

                End If

                ' identifica el archivo imagen
                If fun_IdentificarDocumentoImagen(Trim(stRutaInicial)) = True Then

                    If MessageBox.Show("¿ Desea convertir y copiar el archivo TIF en PDF ? ", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim stRutaDestinoPDF As String = Trim(stRutaDestino.ToString.Substring(0, (Trim(Val(stRutaDestino.ToString.Length) - vl_inLongitudEstension))) & "pdf")

                        If File.Exists(Trim(stRutaDestinoPDF)) = False Then
                            pro_ConvertirDocumentoTIFaPDF(Trim(stRutaInicial), Trim(stRutaDestinoPDF))
                            vl_boArchivoExistente = False

                        ElseIf File.Exists(Trim(stRutaDestinoPDF)) = True Then

                            mod_MENSAJE.El_Archivo_Existe_En_La_Ruta_De_Destino()
                            vl_boArchivoExistente = True
                        End If

                    Else

                        If File.Exists(Trim(stRutaDestino)) = False Then
                            File.Copy(Trim(stRutaInicial), Trim(stRutaDestino))
                            vl_boArchivoExistente = False

                        End If

                    End If

                End If

            ElseIf File.Exists(Trim(stRutaDestino)) = True Then

                ' identifica el archivo word
                If fun_IdentificarDocumentoWord(Trim(stRutaInicial)) = True Then

                    If MessageBox.Show("¿ Desea convertir y copiar el archivo Word en PDF ? ", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim stRutaDestinoPDF As String = Trim(stRutaDestino.ToString.Substring(0, (Trim(Val(stRutaDestino.ToString.Length) - vl_inLongitudEstension))) & "pdf")

                        If File.Exists(Trim(stRutaDestinoPDF)) = False Then
                            pro_ConvertirDocumentoWordaPDF(Trim(stRutaInicial), Trim(stRutaDestinoPDF))
                            vl_boArchivoExistente = False

                        ElseIf File.Exists(Trim(stRutaDestinoPDF)) = True Then

                            mod_MENSAJE.El_Archivo_Existe_En_La_Ruta_De_Destino()
                            vl_boArchivoExistente = True
                        End If

                    Else
                        mod_MENSAJE.El_Archivo_Existe_En_La_Ruta_De_Destino()
                        vl_boArchivoExistente = True
                    End If

                Else
                    mod_MENSAJE.El_Archivo_Existe_En_La_Ruta_De_Destino()
                    vl_boArchivoExistente = True
                End If

                ' identifica el archivo imagen
                If fun_IdentificarDocumentoImagen(Trim(stRutaInicial)) = True Then

                    If MessageBox.Show("¿ Desea convertir y copiar el archivo TIF en PDF ? ", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim stRutaDestinoPDF As String = Trim(stRutaDestino.ToString.Substring(0, (Trim(Val(stRutaDestino.ToString.Length) - vl_inLongitudEstension))) & "pdf")

                        If File.Exists(Trim(stRutaDestinoPDF)) = False Then
                            pro_ConvertirDocumentoTIFaPDF(Trim(stRutaInicial), Trim(stRutaDestinoPDF))
                            vl_boArchivoExistente = False

                        ElseIf File.Exists(Trim(stRutaDestinoPDF)) = True Then

                            mod_MENSAJE.El_Archivo_Existe_En_La_Ruta_De_Destino()
                            vl_boArchivoExistente = True
                        End If

                    Else
                        mod_MENSAJE.El_Archivo_Existe_En_La_Ruta_De_Destino()
                        vl_boArchivoExistente = True
                    End If

                Else
                    mod_MENSAJE.El_Archivo_Existe_En_La_Ruta_De_Destino()
                    vl_boArchivoExistente = True
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EliminarDocumento(ByVal stRutaDestino As String)

        Try
            If File.Exists(Trim(stRutaDestino)) = True Then
                File.Delete(Trim(stRutaDestino))

                'MessageBox.Show("Se elimino el archivo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("Archivo no existente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ConvertirDocumentoWordaPDF(ByVal stRutaInicial As String, ByVal stRutaFinal As String)

        Try
            'Creating the instance of Word Application
            Dim newApp As New Word.Application()

            ' Pon unos caminos que sean buenos
            Dim Source As Object = Trim(stRutaInicial)
            Dim Target As Object = Trim(stRutaFinal)

            ' Use for the parameter whose type are not known or say Missing
            Dim Unknown As Object = Type.Missing

            ' Source document open here
            ' Additional Parameters are not known so that are
            ' set as a missing type
            newApp.Documents.Open(Source, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown)

            ' Specifying the format in which you want the output file
            Dim format As Object = Word.WdSaveFormat.wdFormatPDF

            'Changing the format of the document
            newApp.ActiveDocument.SaveAs(Target, format, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown, Unknown)

            ' for closing the application
            newApp.Quit(Unknown, Unknown, Unknown)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ConvertirDocumentoTIFaPDF(ByVal stRutaInicial As String, ByVal stRutaFinal As String)

        Try
            ' Creacion del documento (lo llmaremos "documento" (yo para los nombres no me rompo la cabeza))
            Dim documento As New iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 0, 0, 0, 0) 'el pdf sera tamaño A4 y en este caso sin margenes (los 4 ceros que estan detras del A4)
            'Dim documento As New iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 0, 0, 0, 0) 'el pdf sera tamaño A4 y en este caso sin margenes (los 4 ceros que estan detras del A4)

            ' Creacion de la escritura del pdf (el pdf como tal, pelao y mondao)
            Dim writer As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(documento, New System.IO.FileStream(stRutaFinal, System.IO.FileMode.Create)) 'creamos el "documento" en la ruta "rutaEnLaQueSeCrearaElDocumento"

            ' Cargamos el archivo tif (se supone que hemos escaneado anteriormente y ahora queremos CONVERTIR el archivo tif generado en el escaneo) por paginas 
            Dim bm As New System.Drawing.Bitmap(stRutaInicial) 'ruta alsoluta o relativa donde se encuentra el tif 
            Dim total As Integer = bm.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page) 'calculamos cuantas paginas tiene el tif

            documento.Open() 'abrimos el "documento" para trabajar con el

            Dim cb As iTextSharp.text.pdf.PdfContentByte = writer.DirectContent 'admito que no se que hace exactamente esta linea, pero es TOTALMENTE NECESARIA

            For k As Integer = 0 To total - 1 'en fin, convertir pagina por pagina (k es solo una variable para usar el contador for)
                bm.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, k) 'lo mismo me pasa con la linea de antes, no se para que se usa pero es necesaria

                Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(bm, System.Drawing.Imaging.ImageFormat.Bmp) 'otra de lo mismo

                ' scale the image to fit in the page (vamos, dar un tamaño a la pagina) 
                img.ScalePercent(72.0F / img.DpiX * 100)
                img.SetAbsolutePosition(0, 0) 'posicion de la imagen escaneada dentro de la pagina del pdf
                cb.AddImage(img) 'añadir la imagen (¿sino para que corcho la hemos escaneado?)
                documento.NewPage() 'nueva pagina (si es solo una pagina esto no vale demasiado, pero es mejor no suprimirlo)

            Next 'bueno, para los que no esten familiarizadon con los bucles controlados for, el next es para pasar al siguiente elemento del contador

            documento.Close() 'cerramos el documento (ya hemos trasteado bastante con el)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' declara la variable
            Dim stMensaje As String = ""

            If Me.rbdTODOS.Checked = False Then

                If Me.lstLISTADO_DOCUMENTOS.SelectedIndex <> -1 Then

                    Dim stRutaInicial As String = fun_ConsultarRutaInicial()
                    Dim stRutaDestino As String = fun_consultarRutaDestino()

                    If Trim(stRutaDestino) <> "" Then

                        pro_CopiarDocumento(stRutaInicial, stRutaDestino)

                        If Me.rbdCOPIAR.Checked = False Then
                            pro_EliminarDocumento(stRutaInicial)
                        End If

                        Me.lstLISTADO_DOCUMENTOS.Items.RemoveAt(lstLISTADO_DOCUMENTOS.SelectedIndex)

                        If vl_boArchivoExistente = False Then
                            MessageBox.Show("Se copio el archivo correctamente ", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If

                    Else
                        MessageBox.Show("NO se copio el archivo debido que la ruta no esta completa ", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    End If

                Else
                    If Me.lstLISTADO_DOCUMENTOS.Items.Count > 0 Then
                        MessageBox.Show("Para guardar un documento, debe seleccionarlo previamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No existen documentos cargados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    End If

                End If

            ElseIf Me.rbdTODOS.Checked = True Then

                If Me.lstLISTADO_DOCUMENTOS.Items.Count > 0 Then

                    Dim boRealizaLacopiaDeArchivos As Boolean = False

                    Dim inCantidad As Integer = Me.lstLISTADO_DOCUMENTOS.Items.Count

                    If inCantidad >= 1 Then

                        If Me.rbdCOPIAR.Checked = True Then
                            stMensaje = "copiar"

                        ElseIf Me.rbdMOVER.Checked = True Then
                            stMensaje = "mover"
                        End If

                        If MessageBox.Show("¿ Desea " & stMensaje & " " & inCantidad & " archivo(s) ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                            While lstLISTADO_DOCUMENTOS.Items.Count > 0

                                lstLISTADO_DOCUMENTOS.SelectedIndex = lstLISTADO_DOCUMENTOS.Items.Count - 1

                                Dim stRutaInicial As String = fun_ConsultarRutaInicial()
                                Dim stRutaDestino As String = fun_consultarRutaDestino()

                                pro_CopiarDocumento(stRutaInicial, stRutaDestino)

                                If vl_boArchivoExistente = False Then
                                    boRealizaLacopiaDeArchivos = True
                                End If

                                If Me.rbdCOPIAR.Checked = False Then
                                    pro_EliminarDocumento(stRutaInicial)
                                End If

                                Me.lstLISTADO_DOCUMENTOS.Items.RemoveAt(lstLISTADO_DOCUMENTOS.SelectedIndex)

                            End While

                        End If

                    End If

                    If boRealizaLacopiaDeArchivos = True Then
                        MessageBox.Show("Se copio el archivo correctamente ", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.Close()
                    End If

                Else
                    MessageBox.Show("No existen documentos cargados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub
    Private Sub cmdAbrirArchivoMunicipio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirCarpeta.Click

        Try

            Dim oCarpetas As New FolderBrowserDialog
            Dim stNewPath As String = ""

            oCarpetas.ShowDialog()
            stNewPath = oCarpetas.SelectedPath

            vl_stRutaDocumentos = stNewPath

            If Trim(vl_stRutaDocumentos) <> "" Then

                pro_ListadoArchivosDocumentos(Trim(vl_stRutaDocumentos))

                Me.lblRuta.Text = vl_stRutaDocumentos

            Else
                Me.lstLISTADO_DOCUMENTOS.Items.Clear()
                Me.lblRuta.Text = ""

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_archivo_MUTACIONES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.strBARRESTA.Items(0).Text = "Importar documentos"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub dgv_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "ResizeBegin"

    Private Sub frm_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        Me.Opacity = vp_Opacity
    End Sub

#End Region

#Region "ResizeEnd"

    Private Sub frm_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim opacity As Double = Convert.ToDouble(100)
        Me.Opacity = opacity
    End Sub

#End Region

#Region "DoubleClick"

    Private Sub lstLISTADO_DOCUMENTOS_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLISTADO_DOCUMENTOS.DoubleClick

        Try
            If lstLISTADO_DOCUMENTOS.SelectedIndex <> -1 Then

                Dim stArchivo As String = lstLISTADO_DOCUMENTOS.SelectedItem
                Process.Start(vl_stRutaDocumentos & "\" & stArchivo)

            Else

                If lstLISTADO_DOCUMENTOS.Items.Count > 0 Then
                    MessageBox.Show("Seleccione un archivo de la lista", "mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

#End Region

#End Region

End Class