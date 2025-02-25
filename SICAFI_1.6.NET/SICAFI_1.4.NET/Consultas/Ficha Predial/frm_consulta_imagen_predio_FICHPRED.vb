Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_consulta_imagen_predio_FICHPRED

    '======================================
    ' *** CONSULTA IMAGEN FICHA PREDIAL ***
    '======================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_consulta_imagen_predio_FICHPRED
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_consulta_imagen_predio_FICHPRED
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

    ' variables de conexión
    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private ds As New DataSet
    Private dt As New DataTable

    ' variables verificar datos
    Dim stFIPRNUFI As String
    Dim stFIPRDIRE As String
    Dim stFIPRMUNI As String
    Dim stFIPRCORR As String
    Dim stFIPRBARR As String
    Dim stFIPRMANZ As String
    Dim stFIPRPRED As String
    Dim stFIPREDIF As String
    Dim stFIPRUNPR As String
    Dim stFIPRCLSE As String
    Dim Separador As String

    ' variables guardar consulta
    Dim Guardar_stFIPRNUFI As String
    Dim Guardar_stFIPRDIRE As String
    Dim Guardar_stFIPRMUNI As String
    Dim Guardar_stFIPRCORR As String
    Dim Guardar_stFIPRBARR As String
    Dim Guardar_stFIPRMANZ As String
    Dim Guardar_stFIPRPRED As String
    Dim Guardar_stFIPREDIF As String
    Dim Guardar_stFIPRUNPR As String
    Dim Guardar_stFIPRCLSE As String

    Dim tblCONSULTA As New DataTable

    Dim vl_inFIPRNUFI As Integer = 0

    Dim vl_stRutaImagen0 As String
    Dim vl_stRutaImagen1 As String
    Dim vl_stRutaImagen2 As String
    Dim vl_stRutaImagen3 As String
    Dim vl_stRutaImagen4 As String
    Dim vl_stRutaImagen5 As String
    Dim vl_stRutaImagen6 As String

    Dim vl_stNombreImagen0 As String
    Dim vl_stNombreImagen1 As String
    Dim vl_stNombreImagen2 As String
    Dim vl_stNombreImagen3 As String
    Dim vl_stNombreImagen4 As String
    Dim vl_stNombreImagen5 As String

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtFIPRNUFI.Text = ""
        Me.txtFIPRDIRE.Text = ""
        Me.txtFIPRMUNI.Text = ""
        Me.txtFIPRCORR.Text = ""
        Me.txtFIPRBARR.Text = ""
        Me.txtFIPRMANZ.Text = ""
        Me.txtFIPRPRED.Text = ""
        Me.txtFIPREDIF.Text = ""
        Me.txtFIPRUNPR.Text = ""
        Me.txtFIPRCLSE.Text = ""
        'Me.cboPresentacion.SelectedIndex = 4

        Me.pibImagenPredio.Image = Nothing
        Me.pibImagenFachada.Image = Nothing
        Me.pibImagenPiso.Image = Nothing
        Me.pibImagenBano.Image = Nothing
        Me.pibImagenCocina.Image = Nothing
        Me.pibImagenCerchas.Image = Nothing
        Me.pibImagenLote.Image = Nothing

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA.DataSource = New DataTable
        Me.dgvCONSTRUCCION.DataSource = New DataTable

        Me.txtFIPRNUFI.Focus()

    End Sub
    Private Sub pro_VerificarDatos()

        '*** VERIFICA DATOS DE FICHA PREDIAL ***

        If Trim(Me.txtFIPRNUFI.Text) = "" Then
            stFIPRNUFI = "%"
        Else
            stFIPRNUFI = Trim(Me.txtFIPRNUFI.Text)
        End If

        If Trim(Me.txtFIPRDIRE.Text) = "" Then
            stFIPRDIRE = "%"
        Else
            stFIPRDIRE = Trim(Me.txtFIPRDIRE.Text)
        End If

        If Trim(Me.txtFIPRMUNI.Text) = "" Then
            stFIPRMUNI = "%"
        Else
            stFIPRMUNI = Trim(Me.txtFIPRMUNI.Text)
        End If

        If Trim(Me.txtFIPRCORR.Text) = "" Then
            stFIPRCORR = "%"
        Else
            stFIPRCORR = Trim(Me.txtFIPRCORR.Text)
        End If

        If Trim(Me.txtFIPRBARR.Text) = "" Then
            stFIPRBARR = "%"
        Else
            stFIPRBARR = Trim(Me.txtFIPRBARR.Text)
        End If

        If Trim(Me.txtFIPRMANZ.Text) = "" Then
            stFIPRMANZ = "%"
        Else
            stFIPRMANZ = Trim(Me.txtFIPRMANZ.Text)
        End If

        If Trim(Me.txtFIPRPRED.Text) = "" Then
            stFIPRPRED = "%"
        Else
            stFIPRPRED = Trim(Me.txtFIPRPRED.Text)
        End If

        If Trim(Me.txtFIPREDIF.Text) = "" Then
            stFIPREDIF = "%"
        Else
            stFIPREDIF = Trim(Me.txtFIPREDIF.Text)
        End If

        If Trim(Me.txtFIPRUNPR.Text) = "" Then
            stFIPRUNPR = "%"
        Else
            stFIPRUNPR = Trim(Me.txtFIPRUNPR.Text)
        End If

        If Trim(Me.txtFIPRCLSE.Text) = "" Then
            stFIPRCLSE = "%"
        Else
            stFIPRCLSE = Trim(Me.txtFIPRCLSE.Text)
        End If

    End Sub
    Private Sub pro_ListaDeValores()

        Try
            Dim I, SW As Byte

            While I < Me.dgvCONSULTA.RowCount And SW = 0
                If Me.dgvCONSULTA.CurrentRow.Cells(I).Selected Then

                    ' llena los campos de ficha predial
                    Me.txtFIPRNUFI.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(0).Value.ToString())
                    Me.txtFIPRDIRE.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(1).Value.ToString())
                    Me.txtFIPRMUNI.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(2).Value.ToString())
                    Me.txtFIPRCORR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(3).Value.ToString())
                    Me.txtFIPRBARR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(4).Value.ToString())
                    Me.txtFIPRMANZ.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(5).Value.ToString())
                    Me.txtFIPRPRED.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(6).Value.ToString())
                    Me.txtFIPREDIF.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(7).Value.ToString())
                    Me.txtFIPRUNPR.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(8).Value.ToString())
                    Me.txtFIPRCLSE.Text = Trim(Me.dgvCONSULTA.CurrentRow.Cells(9).Value.ToString())

                    vl_inFIPRNUFI = CInt(Me.txtFIPRNUFI.Text)

                    pro_ListarImagenPredios()

                    SW = 1
                Else
                    I = I + 1
                End If
            End While

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListarImagenPredios()

        Try
            ' Consulta imagenes de ficha predial
            If Me.dgvCONSULTA.RowCount > 0 Then

                ' instancia la clase
                Dim objdatos33 As New cla_RUTAS
                Dim tbl33 As New DataTable

                ' almacena la consulta
                tbl33 = objdatos33.fun_Buscar_CODIGO_MANT_RUTAS(1)

                ' verifica que exista registros
                If tbl33.Rows.Count > 0 Then

                    ' declara las variables
                    Dim stRutaImagenPredios1 As String = ""
                    Dim stRutaImagenPredios11 As String = ""
                    Dim stConsulta0 As String = ""

                    ' consultar imagen automatica
                    If Me.rbdConsultarImagenAutomatica.Checked = True Then

                        ' almacena la variable ruta
                        stRutaImagenPredios1 = Trim(tbl33.Rows(0).Item("RUTARUTA"))

                        If Trim(stRutaImagenPredios1) = "" Then
                            MessageBox.Show("Se debe introducir una ruta valida", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Else
                            ' verifica la ruta
                            ChDir(stRutaImagenPredios1)

                            stRutaImagenPredios11 = stRutaImagenPredios1

                            ' consulta los archivos por extension
                            stRutaImagenPredios1 = Dir("*.jpg")

                            ' verifica que exista archivos
                            If stRutaImagenPredios1 <> "" Then

                                ' declara la variable
                                Dim bySW As Byte = 0

                                ' recorre la consulta
                                Do Until stRutaImagenPredios1 = ""

                                    ' compara la seleccion
                                    If (vl_inFIPRNUFI & ".jpg") = Trim(stRutaImagenPredios1.ToString.ToLower) And bySW = 0 Then

                                        bySW = 1

                                    End If

                                    '*** DESPLAZARSE AL SIGUIENTE REGISTRO ***
                                    stRutaImagenPredios1 = Dir()
                                Loop

                                ' encontro el archivo
                                If bySW = 1 Then

                                    pibImagenPredio.Image = Image.FromFile(stRutaImagenPredios11 & "\" & (vl_inFIPRNUFI & ".jpg"))

                                    Dim Presentacion As Integer = Me.cboPresentacion.SelectedIndex

                                    Select Case Presentacion
                                        Case 0
                                            pibImagenPredio.SizeMode = PictureBoxSizeMode.StretchImage
                                        Case 1
                                            pibImagenPredio.SizeMode = PictureBoxSizeMode.CenterImage
                                        Case 2
                                            pibImagenPredio.SizeMode = PictureBoxSizeMode.Normal
                                        Case 3
                                            pibImagenPredio.SizeMode = PictureBoxSizeMode.Zoom
                                        Case Else
                                            pibImagenPredio.SizeMode = PictureBoxSizeMode.Zoom

                                    End Select

                                Else
                                    pibImagenPredio.Image = Nothing
                                End If

                            End If
                        End If

                        ' consulta imagen enrutada
                    ElseIf Me.rbdConsultarImagenEnrutada.Checked = True Then

                        Dim obRutaPredio As New cla_FIPRCROQ
                        Dim dtRutaPredio As New DataTable

                        dtRutaPredio = obRutaPredio.fun_Buscar_CODIGO_FIPRCROQ(vl_inFIPRNUFI, 0, 0)

                        If dtRutaPredio.Rows.Count > 0 Then

                            Dim stRutaImagen As String = ""

                            stRutaImagen = Trim(dtRutaPredio.Rows(0).Item("FPCRRUTA").ToString)
                            pibImagenPredio.Image = Image.FromFile(stRutaImagen)

                            vl_stRutaImagen6 = stRutaImagen

                            pibImagenPredio.SizeMode = PictureBoxSizeMode.Zoom

                        Else
                            pibImagenPredio.Image = Nothing
                        End If

                    End If

                End If

                ' consulta las construcciones
                If Me.dgvCONSULTA.RowCount > 0 Then

                    Dim objdatos22 As New cla_FIPRCONS
                    Dim tbl22 As New DataTable

                    tbl22 = objdatos22.fun_Buscar_NRO_SECUENCIA_FIPRCONS_X_FICHA_PREDIAL(vl_inFIPRNUFI)

                    If tbl22.Rows.Count > 0 Then

                        Dim dt1 As New DataTable
                        Dim dr1 As DataRow

                        dt1.Columns.Add(New DataColumn("Nro. Construcción", GetType(String)))

                        Dim k As Integer = 0

                        For k = 0 To tbl22.Rows.Count - 1

                            dr1 = dt1.NewRow()

                            dr1("Nro. Construcción") = CType(Trim(tbl22.Rows(k).Item("FPCOUNID")), String)

                            dt1.Rows.Add(dr1)

                        Next

                        Me.dgvCONSTRUCCION.DataSource = dt1

                        ' instancia la clase
                        Dim objdatos34 As New cla_RUTAS
                        Dim tbl34 As New DataTable

                        ' almacena la consulta
                        tbl34 = objdatos34.fun_Buscar_CODIGO_MANT_RUTAS(2)

                        ' verifica que exista registros
                        If tbl34.Rows.Count > 0 And Me.rbdConsultarImagenAutomatica.Checked = True Then

                            ' declara las variables
                            Dim stRutaImagenPredios2 As String = ""
                            Dim stRutaImagenPredios22 As String = ""
                            Dim stConsulta0 As String = ""

                            ' almacena la variable ruta
                            stRutaImagenPredios2 = Trim(tbl34.Rows(0).Item("RUTARUTA"))

                            If Trim(stRutaImagenPredios2) = "" Then
                                MessageBox.Show("Se debe introducir una ruta valida", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Else
                                ' verifica la ruta
                                ChDir(stRutaImagenPredios2)

                                stRutaImagenPredios22 = stRutaImagenPredios2

                                ' consulta los archivos por extension
                                stRutaImagenPredios2 = Dir("*.jpg")

                                ' verifica que exista archivos
                                If stRutaImagenPredios2 <> "" Then

                                    ' declara la variable
                                    Dim bySW0 As Byte = 0
                                    Dim bySW1 As Byte = 0
                                    Dim bySW2 As Byte = 0
                                    Dim bySW3 As Byte = 0
                                    Dim bySW4 As Byte = 0
                                    Dim bySW5 As Byte = 0

                                    ' recorre la consulta
                                    Do Until stRutaImagenPredios2 = ""

                                        ' compara la seleccion
                                        If (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "1" & ".jpg") = stRutaImagenPredios2.ToString.ToLower And bySW1 = 0 Then
                                             bySW1 = 1
                                        End If

                                        If (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "2" & ".jpg") = stRutaImagenPredios2.ToString.ToLower And bySW2 = 0 Then
                                            bySW2 = 1
                                        End If

                                        If (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "3" & ".jpg") = stRutaImagenPredios2.ToString.ToLower And bySW3 = 0 Then
                                            bySW3 = 1
                                        End If

                                        If (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "4" & ".jpg") = stRutaImagenPredios2.ToString.ToLower And bySW4 = 0 Then
                                            bySW4 = 1
                                        End If

                                        If (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "5" & ".jpg") = stRutaImagenPredios2.ToString.ToLower And bySW5 = 0 Then
                                            bySW5 = 1
                                        End If

                                        '*** DESPLAZARSE AL SIGUIENTE REGISTRO ***
                                        stRutaImagenPredios2 = Dir()
                                    Loop

                                    ' encontro el archivo
                                    If bySW1 = 1 Then

                                        pibImagenFachada.Image = Image.FromFile(stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "1" & ".jpg"))

                                        vl_stRutaImagen1 = (stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "1" & ".jpg"))

                                        Dim Presentacion As Integer = Me.cboPresentacion.SelectedIndex

                                        Select Case Presentacion
                                            Case 0
                                                pibImagenFachada.SizeMode = PictureBoxSizeMode.StretchImage
                                            Case 1
                                                pibImagenFachada.SizeMode = PictureBoxSizeMode.CenterImage
                                            Case 2
                                                pibImagenFachada.SizeMode = PictureBoxSizeMode.Normal
                                            Case 3
                                                pibImagenFachada.SizeMode = PictureBoxSizeMode.Zoom
                                            Case Else
                                                pibImagenFachada.SizeMode = PictureBoxSizeMode.Zoom

                                        End Select

                                    Else
                                        pibImagenFachada.Image = Nothing
                                        vl_stRutaImagen1 = ""
                                    End If

                                    If bySW2 = 1 Then

                                        pibImagenPiso.Image = Image.FromFile(stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "2" & ".jpg"))

                                        vl_stRutaImagen2 = (stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "2" & ".jpg"))

                                        Dim Presentacion As Integer = Me.cboPresentacion.SelectedIndex

                                        Select Case Presentacion
                                            Case 0
                                                pibImagenPiso.SizeMode = PictureBoxSizeMode.StretchImage
                                            Case 1
                                                pibImagenPiso.SizeMode = PictureBoxSizeMode.CenterImage
                                            Case 2
                                                pibImagenPiso.SizeMode = PictureBoxSizeMode.Normal
                                            Case 3
                                                pibImagenPiso.SizeMode = PictureBoxSizeMode.Zoom
                                            Case Else
                                                pibImagenPiso.SizeMode = PictureBoxSizeMode.Zoom

                                        End Select

                                    Else
                                        pibImagenPiso.Image = Nothing
                                        vl_stRutaImagen2 = ""
                                    End If

                                    If bySW3 = 1 Then

                                        pibImagenBano.Image = Image.FromFile(stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "3" & ".jpg"))

                                        vl_stRutaImagen3 = (stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "3" & ".jpg"))

                                        Dim Presentacion As Integer = Me.cboPresentacion.SelectedIndex

                                        Select Case Presentacion
                                            Case 0
                                                pibImagenBano.SizeMode = PictureBoxSizeMode.StretchImage
                                            Case 1
                                                pibImagenBano.SizeMode = PictureBoxSizeMode.CenterImage
                                            Case 2
                                                pibImagenBano.SizeMode = PictureBoxSizeMode.Normal
                                            Case 3
                                                pibImagenBano.SizeMode = PictureBoxSizeMode.Zoom
                                            Case Else
                                                pibImagenBano.SizeMode = PictureBoxSizeMode.Zoom

                                        End Select

                                    Else
                                        pibImagenBano.Image = Nothing
                                        vl_stRutaImagen3 = ""
                                    End If

                                    If bySW4 = 1 Then

                                        pibImagenCocina.Image = Image.FromFile(stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "4" & ".jpg"))

                                        vl_stRutaImagen4 = (stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "4" & ".jpg"))

                                        Dim Presentacion As Integer = Me.cboPresentacion.SelectedIndex

                                        Select Case Presentacion
                                            Case 0
                                                pibImagenCocina.SizeMode = PictureBoxSizeMode.StretchImage
                                            Case 1
                                                pibImagenCocina.SizeMode = PictureBoxSizeMode.CenterImage
                                            Case 2
                                                pibImagenCocina.SizeMode = PictureBoxSizeMode.Normal
                                            Case 3
                                                pibImagenCocina.SizeMode = PictureBoxSizeMode.Zoom
                                            Case Else
                                                pibImagenCocina.SizeMode = PictureBoxSizeMode.Zoom

                                        End Select

                                    Else
                                        pibImagenCocina.Image = Nothing
                                        vl_stRutaImagen4 = ""
                                    End If

                                    If bySW5 = 1 Then

                                        pibImagenCerchas.Image = Image.FromFile(stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "5" & ".jpg"))

                                        vl_stRutaImagen5 = (stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "5" & ".jpg"))

                                        Dim Presentacion As Integer = Me.cboPresentacion.SelectedIndex

                                        Select Case Presentacion
                                            Case 0
                                                pibImagenCerchas.SizeMode = PictureBoxSizeMode.StretchImage
                                            Case 1
                                                pibImagenCerchas.SizeMode = PictureBoxSizeMode.CenterImage
                                            Case 2
                                                pibImagenCerchas.SizeMode = PictureBoxSizeMode.Normal
                                            Case 3
                                                pibImagenCerchas.SizeMode = PictureBoxSizeMode.Zoom
                                            Case Else
                                                pibImagenCerchas.SizeMode = PictureBoxSizeMode.Zoom

                                        End Select

                                    Else
                                        pibImagenCerchas.Image = Nothing
                                        vl_stRutaImagen5 = ""
                                    End If
                                End If
                            End If

                            pibImagenLote.Image = Nothing

                            ' busca la imagen con la ruta asignada
                        ElseIf Me.rbdConsultarImagenEnrutada.Checked = True Then

                            ' limpia las variables
                            vl_stRutaImagen0 = ""
                            vl_stRutaImagen1 = ""
                            vl_stRutaImagen2 = ""
                            vl_stRutaImagen3 = ""
                            vl_stRutaImagen4 = ""
                            vl_stRutaImagen5 = ""

                            vl_stNombreImagen0 = ""
                            vl_stNombreImagen1 = ""
                            vl_stNombreImagen2 = ""
                            vl_stNombreImagen3 = ""
                            vl_stNombreImagen4 = ""
                            vl_stNombreImagen5 = ""

                            ' instancia la clase
                            Dim obRutaFoto1 As New cla_FIPRIMAG
                            Dim dtRutaFoto1 As New DataTable

                            dtRutaFoto1 = obRutaFoto1.fun_Buscar_CODIGO_FIPRIMAG(vl_inFIPRNUFI, Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString), 1)

                            If dtRutaFoto1.Rows.Count > 0 Then

                                vl_stNombreImagen1 = vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString) & "-" & "1" & ".jpg"

                                Dim stRutaImagen As String = ""

                                stRutaImagen = Trim(dtRutaFoto1.Rows(0).Item("FPIMRUTA").ToString)
                                pibImagenFachada.Image = Image.FromFile(stRutaImagen)

                                vl_stRutaImagen1 = stRutaImagen

                                pibImagenFachada.SizeMode = PictureBoxSizeMode.Zoom

                            Else
                                pibImagenFachada.Image = Nothing
                                vl_stRutaImagen1 = ""
                                vl_stNombreImagen1 = ""
                            End If

                            Dim obRutaFoto2 As New cla_FIPRIMAG
                            Dim dtRutaFoto2 As New DataTable

                            dtRutaFoto2 = obRutaFoto2.fun_Buscar_CODIGO_FIPRIMAG(vl_inFIPRNUFI, Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString), 2)

                            If dtRutaFoto2.Rows.Count > 0 Then

                                vl_stNombreImagen2 = vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString) & "-" & "2" & ".jpg"

                                Dim stRutaImagen As String = ""

                                stRutaImagen = Trim(dtRutaFoto2.Rows(0).Item("FPIMRUTA").ToString)
                                pibImagenPiso.Image = Image.FromFile(stRutaImagen)

                                vl_stRutaImagen2 = stRutaImagen

                                pibImagenPiso.SizeMode = PictureBoxSizeMode.Zoom

                            Else
                                pibImagenPiso.Image = Nothing
                                vl_stRutaImagen2 = ""
                                vl_stNombreImagen2 = ""
                            End If

                            Dim obRutaFoto3 As New cla_FIPRIMAG
                            Dim dtRutaFoto3 As New DataTable

                            dtRutaFoto3 = obRutaFoto3.fun_Buscar_CODIGO_FIPRIMAG(vl_inFIPRNUFI, Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString), 3)

                            If dtRutaFoto3.Rows.Count > 0 Then

                                vl_stNombreImagen3 = vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString) & "-" & "3" & ".jpg"

                                Dim stRutaImagen As String = ""

                                stRutaImagen = Trim(dtRutaFoto3.Rows(0).Item("FPIMRUTA").ToString)
                                pibImagenBano.Image = Image.FromFile(stRutaImagen)

                                vl_stRutaImagen3 = stRutaImagen

                                pibImagenBano.SizeMode = PictureBoxSizeMode.Zoom

                            Else
                                pibImagenBano.Image = Nothing
                                vl_stRutaImagen3 = ""
                                vl_stNombreImagen3 = ""
                            End If

                            Dim obRutaFoto4 As New cla_FIPRIMAG
                            Dim dtRutaFoto4 As New DataTable

                            dtRutaFoto4 = obRutaFoto4.fun_Buscar_CODIGO_FIPRIMAG(vl_inFIPRNUFI, Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString), 4)

                            If dtRutaFoto4.Rows.Count > 0 Then

                                vl_stNombreImagen4 = vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString) & "-" & "4" & ".jpg"

                                Dim stRutaImagen As String = ""

                                stRutaImagen = Trim(dtRutaFoto4.Rows(0).Item("FPIMRUTA").ToString)
                                pibImagenCocina.Image = Image.FromFile(stRutaImagen)

                                vl_stRutaImagen4 = stRutaImagen

                                pibImagenCocina.SizeMode = PictureBoxSizeMode.Zoom

                            Else
                                pibImagenCocina.Image = Nothing
                                vl_stRutaImagen4 = ""
                                vl_stNombreImagen4 = ""
                            End If

                            Dim obRutaFoto5 As New cla_FIPRIMAG
                            Dim dtRutaFoto5 As New DataTable

                            dtRutaFoto5 = obRutaFoto5.fun_Buscar_CODIGO_FIPRIMAG(vl_inFIPRNUFI, Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString), 5)

                            If dtRutaFoto5.Rows.Count > 0 Then

                                vl_stNombreImagen5 = vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString) & "-" & "5" & ".jpg"

                                Dim stRutaImagen As String = ""

                                stRutaImagen = Trim(dtRutaFoto5.Rows(0).Item("FPIMRUTA").ToString)
                                pibImagenCerchas.Image = Image.FromFile(stRutaImagen)

                                vl_stRutaImagen5 = stRutaImagen

                                pibImagenCerchas.SizeMode = PictureBoxSizeMode.Zoom

                            Else
                                pibImagenCerchas.Image = Nothing
                                vl_stRutaImagen5 = ""
                                vl_stNombreImagen5 = ""
                            End If

                        End If

                        pibImagenLote.Image = Nothing
                    Else
                        Me.dgvCONSTRUCCION.DataSource = New DataTable
                        Me.pibImagenFachada.Image = Nothing
                        Me.pibImagenPiso.Image = Nothing
                        Me.pibImagenBano.Image = Nothing
                        Me.pibImagenCocina.Image = Nothing
                        Me.pibImagenCerchas.Image = Nothing

                        ' NO POSEE CONSTRUCCIÓN

                        ' instancia la clase
                        Dim objdatos34 As New cla_RUTAS
                        Dim tbl34 As New DataTable

                        ' almacena la consulta
                        tbl34 = objdatos34.fun_Buscar_CODIGO_MANT_RUTAS(2)

                        ' verifica que exista registros
                        If tbl34.Rows.Count > 0 And Me.rbdConsultarImagenAutomatica.Checked = True Then

                            ' declara las variables
                            Dim stRutaImagenPredios2 As String = ""
                            Dim stRutaImagenPredios22 As String = ""
                            Dim stConsulta0 As String = ""

                            ' almacena la variable ruta
                            stRutaImagenPredios2 = Trim(tbl34.Rows(0).Item("RUTARUTA"))

                            If Trim(stRutaImagenPredios2) = "" Then
                                MessageBox.Show("Se debe introducir una ruta valida", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Else
                                ' verifica la ruta
                                ChDir(stRutaImagenPredios2)

                                stRutaImagenPredios22 = stRutaImagenPredios2

                                ' consulta los archivos por extension
                                stRutaImagenPredios2 = Dir("*.jpg")

                                ' verifica que exista archivos
                                If stRutaImagenPredios2 <> "" Then

                                    ' declara la variable
                                    Dim bySW0 As Byte = 0

                                    ' recorre la consulta
                                    Do Until stRutaImagenPredios2 = ""

                                        ' compara la seleccion
                                        If vl_inFIPRNUFI & "-" & Trim("0" & "-" & "1" & ".jpg") = stRutaImagenPredios2.ToString.ToLower And bySW0 = 0 Then
                                            bySW0 = 1
                                        End If

                                        '*** DESPLAZARSE AL SIGUIENTE REGISTRO ***
                                        stRutaImagenPredios2 = Dir()
                                    Loop

                                    ' encontro el archivo
                                    If bySW0 = 1 Then

                                        pibImagenLote.Image = Image.FromFile(stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim("0") & "-" & "1" & ".jpg"))

                                        vl_stRutaImagen0 = (stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim("0") & "-" & "1" & ".jpg"))
                                        vl_stNombreImagen0 = (vl_inFIPRNUFI & "-" & Trim("0") & "-" & "1" & ".jpg")

                                        Dim Presentacion As Integer = Me.cboPresentacion.SelectedIndex

                                        Select Case Presentacion
                                            Case 0
                                                pibImagenLote.SizeMode = PictureBoxSizeMode.StretchImage
                                            Case 1
                                                pibImagenLote.SizeMode = PictureBoxSizeMode.CenterImage
                                            Case 2
                                                pibImagenLote.SizeMode = PictureBoxSizeMode.Normal
                                            Case 3
                                                pibImagenLote.SizeMode = PictureBoxSizeMode.Zoom
                                            Case Else
                                                pibImagenLote.SizeMode = PictureBoxSizeMode.Zoom

                                        End Select

                                    Else
                                        pibImagenLote.Image = Nothing
                                        vl_stRutaImagen0 = ""
                                        vl_stRutaImagen0 = ""
                                    End If

                                End If
                            End If

                            ' busca la imagen con la ruta asignada
                        ElseIf Me.rbdConsultarImagenEnrutada.Checked = True Then

                            Dim obRutaFoto0 As New cla_FIPRIMAG
                            Dim dtRutaFoto0 As New DataTable

                            dtRutaFoto0 = obRutaFoto0.fun_Buscar_CODIGO_FIPRIMAG(vl_inFIPRNUFI, Trim("0"), 1)

                            If dtRutaFoto0.Rows.Count > 0 Then

                                vl_stNombreImagen0 = vl_inFIPRNUFI & "-" & "0" & "-" & "1" & ".jpg"

                                Dim stRutaImagen As String = ""

                                stRutaImagen = Trim(dtRutaFoto0.Rows(0).Item("FPIMRUTA").ToString)
                                pibImagenLote.Image = Image.FromFile(stRutaImagen)

                                vl_stRutaImagen0 = stRutaImagen

                                pibImagenLote.SizeMode = PictureBoxSizeMode.Zoom

                            Else
                                pibImagenLote.Image = Nothing
                            End If

                        Else
                            Me.pibImagenLote.Image = Nothing
                        End If

                    End If
                Else
                    Me.dgvCONSTRUCCION.DataSource = New DataTable
                    Me.pibImagenFachada.Image = Nothing
                    Me.pibImagenPiso.Image = Nothing
                    Me.pibImagenBano.Image = Nothing
                    Me.pibImagenCocina.Image = Nothing
                    Me.pibImagenCerchas.Image = Nothing

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListarImagenConstrucciones()

        Try
            ' consulta las construcciones
            If Me.dgvCONSULTA.RowCount > 0 Then

                ' instancia la clase
                Dim objdatos34 As New cla_RUTAS
                Dim tbl34 As New DataTable

                ' almacena la consulta
                tbl34 = objdatos34.fun_Buscar_CODIGO_MANT_RUTAS(2)

                ' verifica que exista registros
                If tbl34.Rows.Count > 0 And Me.rbdConsultarImagenAutomatica.Checked = True Then

                    ' declara las variables
                    Dim stRutaImagenPredios2 As String = ""
                    Dim stRutaImagenPredios22 As String = ""
                    Dim stConsulta0 As String = ""

                    ' almacena la variable ruta
                    stRutaImagenPredios2 = Trim(tbl34.Rows(0).Item("RUTARUTA"))

                    If Trim(stRutaImagenPredios2) = "" Then
                        MessageBox.Show("Se debe introducir una ruta valida", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Else
                        ' verifica la ruta
                        ChDir(stRutaImagenPredios2)

                        stRutaImagenPredios22 = stRutaImagenPredios2

                        ' consulta los archivos por extension
                        stRutaImagenPredios2 = Dir("*.jpg")

                        ' verifica que exista archivos
                        If stRutaImagenPredios2 <> "" Then

                            ' declara la variable
                            Dim bySW0 As Byte = 0
                            Dim bySW1 As Byte = 0
                            Dim bySW2 As Byte = 0
                            Dim bySW3 As Byte = 0
                            Dim bySW4 As Byte = 0
                            Dim bySW5 As Byte = 0

                            ' recorre la consulta
                            Do Until stRutaImagenPredios2 = ""

                                ' compara la seleccion
                                If (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "1" & ".jpg") = stRutaImagenPredios2.ToString.ToLower And bySW1 = 0 Then
                                    bySW1 = 1
                                End If

                                If (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "2" & ".jpg") = stRutaImagenPredios2.ToString.ToLower And bySW2 = 0 Then
                                    bySW2 = 1
                                End If

                                If (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "3" & ".jpg") = stRutaImagenPredios2.ToString.ToLower And bySW3 = 0 Then
                                    bySW3 = 1
                                End If

                                If (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "4" & ".jpg") = stRutaImagenPredios2.ToString.ToLower And bySW4 = 0 Then
                                    bySW4 = 1
                                End If

                                If (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "5" & ".jpg") = stRutaImagenPredios2.ToString.ToLower And bySW5 = 0 Then
                                    bySW5 = 1
                                End If

                                '*** DESPLAZARSE AL SIGUIENTE REGISTRO ***
                                stRutaImagenPredios2 = Dir()
                            Loop

                            ' encontro el archivo
                            If bySW1 = 1 Then

                                pibImagenFachada.Image = Image.FromFile(stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "1" & ".jpg"))

                                vl_stRutaImagen1 = (stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "1" & ".jpg"))
                                vl_stNombreImagen1 = (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "1" & ".jpg")

                                Dim Presentacion As Integer = Me.cboPresentacion.SelectedIndex

                                Select Case Presentacion
                                    Case 0
                                        pibImagenFachada.SizeMode = PictureBoxSizeMode.StretchImage
                                    Case 1
                                        pibImagenFachada.SizeMode = PictureBoxSizeMode.CenterImage
                                    Case 2
                                        pibImagenFachada.SizeMode = PictureBoxSizeMode.Normal
                                    Case 3
                                        pibImagenFachada.SizeMode = PictureBoxSizeMode.Zoom
                                    Case Else
                                        pibImagenFachada.SizeMode = PictureBoxSizeMode.Zoom

                                End Select

                            Else
                                pibImagenFachada.Image = Nothing
                                vl_stRutaImagen1 = ""
                                vl_stNombreImagen1 = ""
                            End If

                            If bySW2 = 1 Then

                                pibImagenPiso.Image = Image.FromFile(stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "2" & ".jpg"))

                                vl_stRutaImagen2 = (stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "2" & ".jpg"))
                                vl_stNombreImagen2 = (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "2" & ".jpg")

                                Dim Presentacion As Integer = Me.cboPresentacion.SelectedIndex

                                Select Case Presentacion
                                    Case 0
                                        pibImagenPiso.SizeMode = PictureBoxSizeMode.StretchImage
                                    Case 1
                                        pibImagenPiso.SizeMode = PictureBoxSizeMode.CenterImage
                                    Case 2
                                        pibImagenPiso.SizeMode = PictureBoxSizeMode.Normal
                                    Case 3
                                        pibImagenPiso.SizeMode = PictureBoxSizeMode.Zoom
                                    Case Else
                                        pibImagenPiso.SizeMode = PictureBoxSizeMode.Zoom

                                End Select

                            Else
                                pibImagenPiso.Image = Nothing
                                vl_stRutaImagen2 = ""
                                vl_stNombreImagen2 = ""
                            End If

                            If bySW3 = 1 Then

                                pibImagenBano.Image = Image.FromFile(stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "3" & ".jpg"))

                                vl_stRutaImagen3 = (stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "3" & ".jpg"))
                                vl_stNombreImagen3 = (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "3" & ".jpg")

                                Dim Presentacion As Integer = Me.cboPresentacion.SelectedIndex

                                Select Case Presentacion
                                    Case 0
                                        pibImagenBano.SizeMode = PictureBoxSizeMode.StretchImage
                                    Case 1
                                        pibImagenBano.SizeMode = PictureBoxSizeMode.CenterImage
                                    Case 2
                                        pibImagenBano.SizeMode = PictureBoxSizeMode.Normal
                                    Case 3
                                        pibImagenBano.SizeMode = PictureBoxSizeMode.Zoom
                                    Case Else
                                        pibImagenBano.SizeMode = PictureBoxSizeMode.Zoom

                                End Select

                            Else
                                pibImagenBano.Image = Nothing
                                vl_stRutaImagen3 = ""
                                vl_stNombreImagen3 = ""
                            End If

                            If bySW4 = 1 Then

                                pibImagenCocina.Image = Image.FromFile(stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "4" & ".jpg"))

                                vl_stRutaImagen4 = (stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "4" & ".jpg"))
                                vl_stNombreImagen4 = (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "4" & ".jpg")

                                Dim Presentacion As Integer = Me.cboPresentacion.SelectedIndex

                                Select Case Presentacion
                                    Case 0
                                        pibImagenCocina.SizeMode = PictureBoxSizeMode.StretchImage
                                    Case 1
                                        pibImagenCocina.SizeMode = PictureBoxSizeMode.CenterImage
                                    Case 2
                                        pibImagenCocina.SizeMode = PictureBoxSizeMode.Normal
                                    Case 3
                                        pibImagenCocina.SizeMode = PictureBoxSizeMode.Zoom
                                    Case Else
                                        pibImagenCocina.SizeMode = PictureBoxSizeMode.Zoom

                                End Select

                            Else
                                pibImagenCocina.Image = Nothing
                                vl_stRutaImagen4 = ""
                                vl_stNombreImagen4 = ""
                            End If

                            If bySW5 = 1 Then

                                pibImagenCerchas.Image = Image.FromFile(stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "5" & ".jpg"))

                                vl_stRutaImagen5 = (stRutaImagenPredios22 & "\" & (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "5" & ".jpg"))
                                vl_stNombreImagen5 = (vl_inFIPRNUFI & "-" & Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString().ToString.ToLower) & "-" & "5" & ".jpg")

                                Dim Presentacion As Integer = Me.cboPresentacion.SelectedIndex

                                Select Case Presentacion
                                    Case 0
                                        pibImagenCerchas.SizeMode = PictureBoxSizeMode.StretchImage
                                    Case 1
                                        pibImagenCerchas.SizeMode = PictureBoxSizeMode.CenterImage
                                    Case 2
                                        pibImagenCerchas.SizeMode = PictureBoxSizeMode.Normal
                                    Case 3
                                        pibImagenCerchas.SizeMode = PictureBoxSizeMode.Zoom
                                    Case Else
                                        pibImagenCerchas.SizeMode = PictureBoxSizeMode.Zoom

                                End Select

                            Else
                                pibImagenCerchas.Image = Nothing
                                vl_stRutaImagen5 = ""
                                vl_stNombreImagen5 = ""
                            End If

                        End If
                    End If

                    pibImagenLote.Image = Nothing

                    ' busca la imagen con la ruta asignada
                ElseIf Me.rbdConsultarImagenEnrutada.Checked = True Then

                    ' limpia las variables
                    vl_stRutaImagen0 = ""
                    vl_stRutaImagen1 = ""
                    vl_stRutaImagen2 = ""
                    vl_stRutaImagen3 = ""
                    vl_stRutaImagen4 = ""
                    vl_stRutaImagen5 = ""

                    vl_stNombreImagen0 = ""
                    vl_stNombreImagen1 = ""
                    vl_stNombreImagen2 = ""
                    vl_stNombreImagen3 = ""
                    vl_stNombreImagen4 = ""
                    vl_stNombreImagen5 = ""

                    ' instancia la clase
                    Dim obRutaFoto1 As New cla_FIPRIMAG
                    Dim dtRutaFoto1 As New DataTable

                    dtRutaFoto1 = obRutaFoto1.fun_Buscar_CODIGO_FIPRIMAG(vl_inFIPRNUFI, Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString), 1)

                    If dtRutaFoto1.Rows.Count > 0 Then

                        Dim stRutaImagen As String = ""

                        stRutaImagen = Trim(dtRutaFoto1.Rows(0).Item("FPIMRUTA").ToString)
                        pibImagenFachada.Image = Image.FromFile(stRutaImagen)

                        vl_stRutaImagen1 = stRutaImagen

                        pibImagenFachada.SizeMode = PictureBoxSizeMode.Zoom

                    Else
                        pibImagenFachada.Image = Nothing
                        vl_stRutaImagen1 = ""
                        vl_stNombreImagen1 = ""
                    End If

                    Dim obRutaFoto2 As New cla_FIPRIMAG
                    Dim dtRutaFoto2 As New DataTable

                    dtRutaFoto2 = obRutaFoto2.fun_Buscar_CODIGO_FIPRIMAG(vl_inFIPRNUFI, Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString), 2)

                    If dtRutaFoto2.Rows.Count > 0 Then

                        Dim stRutaImagen As String = ""

                        stRutaImagen = Trim(dtRutaFoto2.Rows(0).Item("FPIMRUTA").ToString)
                        pibImagenPiso.Image = Image.FromFile(stRutaImagen)

                        vl_stRutaImagen2 = stRutaImagen

                        pibImagenPiso.SizeMode = PictureBoxSizeMode.Zoom

                    Else
                        pibImagenPiso.Image = Nothing
                        vl_stRutaImagen2 = ""
                        vl_stNombreImagen2 = ""
                    End If

                    Dim obRutaFoto3 As New cla_FIPRIMAG
                    Dim dtRutaFoto3 As New DataTable

                    dtRutaFoto3 = obRutaFoto3.fun_Buscar_CODIGO_FIPRIMAG(vl_inFIPRNUFI, Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString), 3)

                    If dtRutaFoto3.Rows.Count > 0 Then

                        Dim stRutaImagen As String = ""

                        stRutaImagen = Trim(dtRutaFoto3.Rows(0).Item("FPIMRUTA").ToString)
                        pibImagenBano.Image = Image.FromFile(stRutaImagen)

                        vl_stRutaImagen3 = stRutaImagen

                        pibImagenBano.SizeMode = PictureBoxSizeMode.Zoom

                    Else
                        pibImagenBano.Image = Nothing
                        vl_stRutaImagen3 = ""
                        vl_stNombreImagen3 = ""
                    End If

                    Dim obRutaFoto4 As New cla_FIPRIMAG
                    Dim dtRutaFoto4 As New DataTable

                    dtRutaFoto4 = obRutaFoto4.fun_Buscar_CODIGO_FIPRIMAG(vl_inFIPRNUFI, Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString), 4)

                    If dtRutaFoto4.Rows.Count > 0 Then

                        Dim stRutaImagen As String = ""

                        stRutaImagen = Trim(dtRutaFoto4.Rows(0).Item("FPIMRUTA").ToString)
                        pibImagenCocina.Image = Image.FromFile(stRutaImagen)

                        vl_stRutaImagen4 = stRutaImagen

                        pibImagenCocina.SizeMode = PictureBoxSizeMode.Zoom

                    Else
                        pibImagenCocina.Image = Nothing
                        vl_stRutaImagen4 = ""
                        vl_stNombreImagen4 = ""
                    End If

                    Dim obRutaFoto5 As New cla_FIPRIMAG
                    Dim dtRutaFoto5 As New DataTable

                    dtRutaFoto5 = obRutaFoto4.fun_Buscar_CODIGO_FIPRIMAG(vl_inFIPRNUFI, Trim(Me.dgvCONSTRUCCION.CurrentRow.Cells(0).Value.ToString), 5)

                    If dtRutaFoto5.Rows.Count > 0 Then

                        Dim stRutaImagen As String = ""

                        stRutaImagen = Trim(dtRutaFoto5.Rows(0).Item("FPIMRUTA").ToString)
                        pibImagenCerchas.Image = Image.FromFile(stRutaImagen)

                        vl_stRutaImagen5 = stRutaImagen

                        pibImagenCerchas.SizeMode = PictureBoxSizeMode.Zoom

                    Else
                        pibImagenCerchas.Image = Nothing
                        vl_stRutaImagen5 = ""
                        vl_stNombreImagen5 = ""
                    End If

                    pibImagenLote.Image = Nothing
                    vl_stRutaImagen0 = ""
                    vl_stNombreImagen0 = ""

                End If
            Else
                Me.dgvCONSTRUCCION.DataSource = New DataTable
                Me.pibImagenFachada.Image = Nothing
                Me.pibImagenPiso.Image = Nothing
                Me.pibImagenBano.Image = Nothing
                Me.pibImagenCocina.Image = Nothing
                Me.pibImagenCerchas.Image = Nothing

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GuardarConsulta()

        Guardar_stFIPRNUFI = Trim(Me.txtFIPRNUFI.Text)
        Guardar_stFIPRDIRE = Trim(Me.txtFIPRDIRE.Text)
        Guardar_stFIPRMUNI = Trim(Me.txtFIPRMUNI.Text)
        Guardar_stFIPRCORR = Trim(Me.txtFIPRCORR.Text)
        Guardar_stFIPRBARR = Trim(Me.txtFIPRBARR.Text)
        Guardar_stFIPRMANZ = Trim(Me.txtFIPRMANZ.Text)
        Guardar_stFIPRPRED = Trim(Me.txtFIPRPRED.Text)
        Guardar_stFIPREDIF = Trim(Me.txtFIPREDIF.Text)
        Guardar_stFIPRUNPR = Trim(Me.txtFIPRUNPR.Text)
        Guardar_stFIPRCLSE = Trim(Me.txtFIPRCLSE.Text)

    End Sub
    Private Sub pro_ObtenerConsulta()

        Me.txtFIPRNUFI.Text = Guardar_stFIPRNUFI
        Me.txtFIPRDIRE.Text = Guardar_stFIPRDIRE
        Me.txtFIPRMUNI.Text = Guardar_stFIPRMUNI
        Me.txtFIPRCORR.Text = Guardar_stFIPRCORR
        Me.txtFIPRBARR.Text = Guardar_stFIPRBARR
        Me.txtFIPRMANZ.Text = Guardar_stFIPRMANZ
        Me.txtFIPRPRED.Text = Guardar_stFIPRPRED
        Me.txtFIPREDIF.Text = Guardar_stFIPREDIF
        Me.txtFIPRUNPR.Text = Guardar_stFIPRUNPR
        Me.txtFIPRCLSE.Text = Guardar_stFIPRCLSE

    End Sub
    Private Sub pro_CopiarArchivo()

        Try
            If Me.dgvCONSULTA.RowCount > 0 Then

                Dim oCarpetas As New FolderBrowserDialog
                Dim stNewPath As String = ""
                Dim boCopiaArchivo As Boolean = False

                If oCarpetas.ShowDialog = Windows.Forms.DialogResult.OK Then

                    stNewPath = oCarpetas.SelectedPath

                    If Trim(stNewPath) <> "" Then

                        If Trim(vl_stRutaImagen0) <> "" Then
                            pro_Copiar(vl_stRutaImagen0, stNewPath & "\" & Trim(vl_stNombreImagen0))
                            boCopiaArchivo = True
                        End If

                        If Trim(vl_stRutaImagen1) <> "" Then
                            pro_Copiar(vl_stRutaImagen1, stNewPath & "\" & Trim(vl_stNombreImagen1))
                            boCopiaArchivo = True
                        End If

                        If Trim(vl_stRutaImagen2) <> "" Then
                            pro_Copiar(vl_stRutaImagen2, stNewPath & "\" & Trim(vl_stNombreImagen2))
                            boCopiaArchivo = True
                        End If

                        If Trim(vl_stRutaImagen3) <> "" Then
                            pro_Copiar(vl_stRutaImagen3, stNewPath & "\" & Trim(vl_stNombreImagen3))
                            boCopiaArchivo = True
                        End If

                        If Trim(vl_stRutaImagen4) <> "" Then
                            pro_Copiar(vl_stRutaImagen4, stNewPath & "\" & Trim(vl_stNombreImagen4))
                            boCopiaArchivo = True
                        End If

                        If Trim(vl_stRutaImagen5) <> "" Then
                            pro_Copiar(vl_stRutaImagen5, stNewPath & "\" & Trim(vl_stNombreImagen5))
                            boCopiaArchivo = True
                        End If

                        If boCopiaArchivo = True Then
                            MessageBox.Show("Se realizo la copia del archivo correctamente.", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("No se realizo la copia del archivo.", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    End If

                End If

            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_Copiar(ByVal stRutaInicial As String, ByVal stRutaDestino As String)

        Try
            If File.Exists(Trim(stRutaDestino)) = False Then

                If File.Exists(Trim(stRutaDestino)) = False Then
                    File.Copy(Trim(stRutaInicial), Trim(stRutaDestino))

                ElseIf File.Exists(Trim(stRutaDestino)) = True Then

                    mod_MENSAJE.El_Archivo_Existe_En_La_Ruta_De_Destino()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
#End Region

#Region "MENU"

    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
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

            ' guarda la consulta
            pro_GuardarConsulta()

            ' verifica los datos de los campos
            pro_VerificarDatos()

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi as NroFicha, "
            ParametrosConsulta += "FiprDire as Direccion, "
            ParametrosConsulta += "FiprMuni as Municipio, "
            ParametrosConsulta += "FiprCorr as Corregi, "
            ParametrosConsulta += "FiprBarr as Barrio, "
            ParametrosConsulta += "FiprManz as Manzana, "
            ParametrosConsulta += "FiprPred as Predio, "
            ParametrosConsulta += "FiprEdif as Edificio, "
            ParametrosConsulta += "FiprUnpr as UnidPred, "
            ParametrosConsulta += "FiprClse as Sector "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprNufi like '" & stFIPRNUFI & "' and "
            ParametrosConsulta += "FiprDire like '" & stFIPRDIRE & "' and "
            ParametrosConsulta += "FiprMuni like '" & stFIPRMUNI & "' and "
            ParametrosConsulta += "FiprCorr like '" & stFIPRCORR & "' and "
            ParametrosConsulta += "FiprBarr like '" & stFIPRBARR & "' and "
            ParametrosConsulta += "FiprManz like '" & stFIPRMANZ & "' and "
            ParametrosConsulta += "FiprPred like '" & stFIPRPRED & "' and "
            ParametrosConsulta += "FiprEdif like '" & stFIPREDIF & "' and "
            ParametrosConsulta += "FiprUnpr like '" & stFIPRUNPR & "' and "
            ParametrosConsulta += "FiprClse like '" & stFIPRCLSE & "' and "
            ParametrosConsulta += "FiprTifi = 0 "
            ParametrosConsulta += "order by FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr"

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
                        Me.dgvCONSULTA.DataSource = dt
                    Else
                        ' sale del proceso de consulta
                        Exit Sub
                    End If
                End If

                ' llena el datagridview
                Me.dgvCONSULTA.DataSource = dt

                Me.dgvCONSULTA.Columns(1).Visible = False

                ' llena la lista de valores
                pro_ListaDeValores()
            Else
                Me.dgvCONSULTA.DataSource = New DataTable
                mod_MENSAJE.Consulta_No_Encontro_Registros()

            End If

            ' Numero de registros recuperados
            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCONSULTA.RowCount.ToString

            Me.dgvCONSULTA.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub
    Private Sub cmdULTIMACONSULTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdULTIMACONSULTA.Click
        pro_LimpiarCampos()
        pro_ObtenerConsulta()
        cmdCONSULTAR.Focus()
    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtFIPRNUFI.Focus()
        Me.Close()
    End Sub
    Private Sub cmdCALIFICACION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCALIFICACION.Click

        If Me.dgvCONSTRUCCION.RowCount > 0 Then
            Dim frm_consulta_calificacion_FIPRCACO As New frm_consulta_calificacion_FIPRCACO(txtFIPRNUFI.Text, Me.dgvCONSTRUCCION.SelectedRows(0).Cells(0).Value.ToString)
            frm_consulta_calificacion_FIPRCACO.ShowDialog()
        Else
            MessageBox.Show("Seleccione una construcción", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

    End Sub
    Private Sub cmdCopiarArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopiarArchivo.Click
        pro_CopiarArchivo()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_consulta_propietario_FIPRPROP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtFIPRNUFI.Focus()

    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtFIPRNUFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRNUFI.GotFocus
        txtFIPRNUFI.SelectionStart = 0
        txtFIPRNUFI.SelectionLength = Len(txtFIPRNUFI.Text)
        strBARRESTA.Items(0).Text = txtFIPRNUFI.AccessibleDescription
    End Sub
    Private Sub txtFIPRDIRE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRDIRE.GotFocus
        txtFIPRDIRE.SelectionStart = 0
        txtFIPRDIRE.SelectionLength = Len(txtFIPRDIRE.Text)
        strBARRESTA.Items(0).Text = txtFIPRDIRE.AccessibleDescription
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
    Private Sub cmdCONSULTAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.GotFocus
        strBARRESTA.Items(0).Text = cmdCONSULTAR.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub
    Private Sub dgvCONSULTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCONSULTA.GotFocus
        strBARRESTA.Items(0).Text = dgvCONSULTA.AccessibleDescription
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtFIPRNUFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRNUFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRDIRE.Focus()
        End If

    End Sub
    Private Sub txtFIPRDIRE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRDIRE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRMUNI.Focus()
        End If
    End Sub
    Private Sub txtFIPRMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMUNI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCORR.Focus()
        End If

    End Sub
    Private Sub txtFIPRCORR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCORR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRBARR.Focus()
        End If

    End Sub
    Private Sub txtFIPRBARR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRBARR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRMANZ.Focus()
        End If

    End Sub
    Private Sub txtFIPRMANZ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMANZ.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRPRED.Focus()
        End If

    End Sub
    Private Sub txtFIPRPRED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRPRED.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPREDIF.Focus()
        End If

    End Sub
    Private Sub txtFIPREDIF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPREDIF.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRUNPR.Focus()
        End If

    End Sub
    Private Sub txtFIPRUNPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRUNPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCLSE.Focus()
        End If

    End Sub
    Private Sub txtFIPRCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdCONSULTAR.Focus()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cmdCONSULTAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdCONSULTAR.KeyDown, txtFIPRNUFI.KeyDown, txtFIPRDIRE.KeyDown, txtFIPRMUNI.KeyDown, txtFIPRCORR.KeyDown, txtFIPRBARR.KeyDown, txtFIPRMANZ.KeyDown, txtFIPRPRED.KeyDown, txtFIPREDIF.KeyDown, txtFIPRUNPR.KeyDown, txtFIPRCLSE.KeyDown, dgvCONSULTA.KeyDown
        If e.KeyCode = Keys.F8 Then
            cmdCONSULTAR.PerformClick()
        End If

        If e.KeyCode = Keys.F7 Then
            cmdULTIMACONSULTA.PerformClick()
        End If

    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvCONSULTA_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA.CellClick
        pro_ListaDeValores()
    End Sub
    Private Sub dgvCONSTRUCCION_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSTRUCCION.CellClick
        pro_ListarImagenConstrucciones()
    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvCONSULTA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCONSULTA.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValores()
        End If
    End Sub
    Private Sub dgvCONSTRUCCION_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvCONSTRUCCION.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListarImagenConstrucciones()
        End If
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFIPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.Validated
        If Me.txtFIPRMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRMUNI.Text) = True Then
            Me.txtFIPRMUNI.Text = fun_Formato_Mascara_3_String(Me.txtFIPRMUNI.Text)
        End If
    End Sub
    Private Sub txtFIPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.Validated
        If Me.txtFIPRCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRCORR.Text) = True Then
            Me.txtFIPRCORR.Text = fun_Formato_Mascara_2_String(Me.txtFIPRCORR.Text)
        End If
    End Sub
    Private Sub txtFIPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.Validated
        If Me.txtFIPRBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRBARR.Text) = True Then
            Me.txtFIPRBARR.Text = fun_Formato_Mascara_3_String(Me.txtFIPRBARR.Text)
        End If
    End Sub
    Private Sub txtFIPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.Validated
        If Me.txtFIPRMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRMANZ.Text) = True Then
            Me.txtFIPRMANZ.Text = fun_Formato_Mascara_3_String(Me.txtFIPRMANZ.Text)
        End If
    End Sub
    Private Sub txtFIPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.Validated
        If Me.txtFIPRPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRPRED.Text) = True Then
            Me.txtFIPRPRED.Text = fun_Formato_Mascara_5_String(Me.txtFIPRPRED.Text)
        End If
    End Sub
    Private Sub txtFIPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.Validated
        If Me.txtFIPREDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPREDIF.Text) = True Then
            Me.txtFIPREDIF.Text = fun_Formato_Mascara_3_String(Me.txtFIPREDIF.Text)
        End If
    End Sub
    Private Sub txtFIPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.Validated
        If Me.txtFIPRUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRUNPR.Text) = True Then
            Me.txtFIPRUNPR.Text = fun_Formato_Mascara_5_String(Me.txtFIPRUNPR.Text)
        End If
    End Sub


#End Region

#Region "TextChanged"

    Private Sub tstBAESDESC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tstBAESDESC.TextChanged
        If tstBAESDESC.Text <> "" Then
            MessageBox.Show(Trim(tstBAESDESC.Text), "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboPresentacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPresentacion.SelectedIndexChanged
        '*** PRESENTACIÓN DE COMBOBOX ***

        Dim Presentacion As Integer

        Presentacion = cboPresentacion.SelectedIndex

        Select Case Presentacion
            Case 0
                pibImagenLote.SizeMode = PictureBoxSizeMode.StretchImage
                pibImagenPredio.SizeMode = PictureBoxSizeMode.StretchImage
                pibImagenFachada.SizeMode = PictureBoxSizeMode.StretchImage
                pibImagenPiso.SizeMode = PictureBoxSizeMode.StretchImage
                pibImagenBano.SizeMode = PictureBoxSizeMode.StretchImage
                pibImagenCocina.SizeMode = PictureBoxSizeMode.StretchImage
                pibImagenCerchas.SizeMode = PictureBoxSizeMode.StretchImage
            Case 1
                pibImagenLote.SizeMode = PictureBoxSizeMode.CenterImage
                pibImagenPredio.SizeMode = PictureBoxSizeMode.CenterImage
                pibImagenFachada.SizeMode = PictureBoxSizeMode.CenterImage
                pibImagenPiso.SizeMode = PictureBoxSizeMode.CenterImage
                pibImagenBano.SizeMode = PictureBoxSizeMode.CenterImage
                pibImagenCocina.SizeMode = PictureBoxSizeMode.CenterImage
                pibImagenCerchas.SizeMode = PictureBoxSizeMode.CenterImage
            Case 2
                pibImagenLote.SizeMode = PictureBoxSizeMode.Normal
                pibImagenPredio.SizeMode = PictureBoxSizeMode.Normal
                pibImagenFachada.SizeMode = PictureBoxSizeMode.Normal
                pibImagenPiso.SizeMode = PictureBoxSizeMode.Normal
                pibImagenBano.SizeMode = PictureBoxSizeMode.Normal
                pibImagenCocina.SizeMode = PictureBoxSizeMode.Normal
                pibImagenCerchas.SizeMode = PictureBoxSizeMode.Normal
            Case 3
                pibImagenLote.SizeMode = PictureBoxSizeMode.Zoom
                pibImagenPredio.SizeMode = PictureBoxSizeMode.Zoom
                pibImagenFachada.SizeMode = PictureBoxSizeMode.Zoom
                pibImagenPiso.SizeMode = PictureBoxSizeMode.Zoom
                pibImagenBano.SizeMode = PictureBoxSizeMode.Zoom
                pibImagenCocina.SizeMode = PictureBoxSizeMode.Zoom
                pibImagenCerchas.SizeMode = PictureBoxSizeMode.Zoom
        End Select

    End Sub

#End Region

#Region "Click"

    Private Sub pibImagenPredio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pibImagenPredio.Click

        Try
            If vl_stRutaImagen6 <> "" Then
                Dim o_frm_Visor As New frm_visor_imagen(Trim(vl_stRutaImagen6))
                o_frm_Visor.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pibImagenLote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pibImagenLote.Click

        Try
            If vl_stRutaImagen0 <> "" Then
                Dim o_frm_Visor As New frm_visor_imagen(Trim(vl_stRutaImagen0))
                o_frm_Visor.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pibImagenFachada_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pibImagenFachada.Click
        Try
            If vl_stRutaImagen1 <> "" Then
                Dim o_frm_Visor As New frm_visor_imagen(Trim(vl_stRutaImagen1))
                o_frm_Visor.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pibImagenPiso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pibImagenPiso.Click
        Try
            If vl_stRutaImagen2 <> "" Then
                Dim o_frm_Visor As New frm_visor_imagen(Trim(vl_stRutaImagen2))
                o_frm_Visor.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pibImagenBano_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pibImagenBano.Click
        Try
            If vl_stRutaImagen3 <> "" Then
                Dim o_frm_Visor As New frm_visor_imagen(Trim(vl_stRutaImagen3))
                o_frm_Visor.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pibImagenCocina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pibImagenCocina.Click

        Try
            If vl_stRutaImagen4 <> "" Then
                Dim o_frm_Visor As New frm_visor_imagen(Trim(vl_stRutaImagen4))
                o_frm_Visor.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pibImagenCerchas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pibImagenCerchas.Click

        Try
            If vl_stRutaImagen5 <> "" Then
                Dim o_frm_Visor As New frm_visor_imagen(Trim(vl_stRutaImagen5))
                o_frm_Visor.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#End Region

   
End Class