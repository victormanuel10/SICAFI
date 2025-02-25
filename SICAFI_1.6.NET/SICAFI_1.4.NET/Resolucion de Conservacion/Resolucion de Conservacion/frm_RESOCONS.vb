Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_RESOCONS

    '====================================
    '*** RESOLUCIONES DE CONSERVACION ***
    '====================================

#Region "VARIABLES"

    Dim oLeer As New OpenFileDialog

    Dim boCONSULTA As Boolean = False

    Dim vl_stRutaDocumentosPDF As String = ""
    Dim vl_boControlDeComandos As Boolean = False

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

    Dim vl_inTotalRegistros As Integer
    Dim inProceso As Integer

    Dim vl_inResolucion As Integer = 0
    Dim vl_inVigencia As Integer = 0

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_RESOCONS
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_RESOCONS
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

#Region "CONSTRUCTOR"

    Public Sub New(ByVal idCodigo As Integer)

        vp_inConsulta = idCodigo
        InitializeComponent()

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_VerificarCarpetaExistenteDocumentos() As Boolean

        Try
            Dim stRuta As String = ""
            Dim stCarpetaABuscar As String = ""

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(20)

            If tblRutas.Rows.Count > 0 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' directorio expediente 
                stCarpetaABuscar = Trim(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECONURE").Value.ToString) & "-" & _
                                   Trim(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOFERE").Value.ToString)

                Dim Ruta As New DirectoryInfo(stRuta)

                Dim TodasLasCarpetas(), CarpetaABuscar As DirectoryInfo

                ' declara la variable 
                Dim sw As Byte = 1

                TodasLasCarpetas = Ruta.GetDirectories()

                ' recorre el directorio
                For Each CarpetaABuscar In TodasLasCarpetas

                    If CarpetaABuscar.FullName = Ruta.FullName & stCarpetaABuscar Then
                        sw = 0

                        If sw = 0 Then
                            Exit For
                        End If

                    End If

                Next

                ' retorna la respuesta
                If sw = 1 Then
                    Return False
                Else
                    Return True
                End If

            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Function fun_ConsultarPrediosRetirados() As DataTable

        Try
            ' declaro la instancia
            Dim obRECOPRRE As New cla_RECOPRRE
            Dim dtRECOPRRE As New DataTable
            Dim dt1 As New DataTable

            dtRECOPRRE = obRECOPRRE.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECOPRRE(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())

            If dtRECOPRRE.Rows.Count > 0 Then

                ' creo el datagridview dinamicamente 
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Municipio", GetType(String)))
                dt1.Columns.Add(New DataColumn("Correg.", GetType(String)))
                dt1.Columns.Add(New DataColumn("Barrio", GetType(String)))
                dt1.Columns.Add(New DataColumn("Manzana / Vereda", GetType(String)))
                dt1.Columns.Add(New DataColumn("Predio", GetType(String)))
                dt1.Columns.Add(New DataColumn("Edificio", GetType(String)))
                dt1.Columns.Add(New DataColumn("Unidad Predial", GetType(String)))
                dt1.Columns.Add(New DataColumn("Sector", GetType(String)))
                dt1.Columns.Add(New DataColumn("Cedula Catastral", GetType(String)))
                dt1.Columns.Add(New DataColumn("Dirección", GetType(String)))
                dt1.Columns.Add(New DataColumn("Matricula Inmobiliria", GetType(String)))
                dt1.Columns.Add(New DataColumn("Nro. Ficha Predial", GetType(String)))
                dt1.Columns.Add(New DataColumn("Estado", GetType(String)))

                ' declaro la variable
                Dim i As Integer = 0

                For i = 0 To dtRECOPRRE.Rows.Count - 1

                    ' Inserta el registro en el DataTable
                    dr1 = dt1.NewRow()

                    dr1("Municipio") = CType(dtRECOPRRE.Rows(i).Item("RCPRMUNI"), String)
                    dr1("Correg.") = CType(dtRECOPRRE.Rows(i).Item("RCPRCORR"), String)
                    dr1("Barrio") = CType(dtRECOPRRE.Rows(i).Item("RCPRBARR"), String)
                    dr1("Manzana / Vereda") = CType(dtRECOPRRE.Rows(i).Item("RCPRMANZ"), String)
                    dr1("Predio") = CType(dtRECOPRRE.Rows(i).Item("RCPRPRED"), String)
                    dr1("Edificio") = CType(dtRECOPRRE.Rows(i).Item("RCPREDIF"), String)
                    dr1("Unidad Predial") = CType(dtRECOPRRE.Rows(i).Item("RCPRUNPR"), String)
                    dr1("Sector") = CType(dtRECOPRRE.Rows(i).Item("RCPRCLSE"), String)
                    dr1("Cedula Catastral") = CType(Trim(dtRECOPRRE.Rows(i).Item("RCPRCECA")), String) & " _"
                    dr1("Dirección") = CType(dtRECOPRRE.Rows(i).Item("RCPRDIRE"), String)
                    dr1("Matricula Inmobiliria") = CType(dtRECOPRRE.Rows(i).Item("RCPRMAIN"), String)
                    dr1("Nro. Ficha Predial") = CType(dtRECOPRRE.Rows(i).Item("RCPRNUFI"), String)
                    dr1("Estado") = CType(dtRECOPRRE.Rows(i).Item("RCPRESTA"), String)

                    dt1.Rows.Add(dr1)

                Next

            End If

            Return dt1

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Private Function fun_ConsultarPrediosSegregados() As DataTable

        Try
            ' declaro la instancia
            Dim obRECOPRSE As New cla_RECOPRSE
            Dim dtRECOPRSE As New DataTable
            Dim dt1 As New DataTable

            dtRECOPRSE = obRECOPRSE.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECOPRSE(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())

            If dtRECOPRSE.Rows.Count > 0 Then

                ' creo el datagridview dinamicamente 
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Municipio", GetType(String)))
                dt1.Columns.Add(New DataColumn("Correg.", GetType(String)))
                dt1.Columns.Add(New DataColumn("Barrio", GetType(String)))
                dt1.Columns.Add(New DataColumn("Manzana / Vereda", GetType(String)))
                dt1.Columns.Add(New DataColumn("Predio", GetType(String)))
                dt1.Columns.Add(New DataColumn("Edificio", GetType(String)))
                dt1.Columns.Add(New DataColumn("Unidad Predial", GetType(String)))
                dt1.Columns.Add(New DataColumn("Sector", GetType(String)))
                dt1.Columns.Add(New DataColumn("Cedula Catastral", GetType(String)))
                dt1.Columns.Add(New DataColumn("Dirección", GetType(String)))
                dt1.Columns.Add(New DataColumn("Matricula Inmobiliria", GetType(String)))
                dt1.Columns.Add(New DataColumn("Nro. Ficha Predial", GetType(String)))
                dt1.Columns.Add(New DataColumn("Estado", GetType(String)))

                ' declaro la variable
                Dim i As Integer = 0

                For i = 0 To dtRECOPRSE.Rows.Count - 1

                    ' Inserta el registro en el DataTable
                    dr1 = dt1.NewRow()

                    dr1("Municipio") = CType(dtRECOPRSE.Rows(i).Item("RCPSMUNI"), String)
                    dr1("Correg.") = CType(dtRECOPRSE.Rows(i).Item("RCPSCORR"), String)
                    dr1("Barrio") = CType(dtRECOPRSE.Rows(i).Item("RCPSBARR"), String)
                    dr1("Manzana / Vereda") = CType(dtRECOPRSE.Rows(i).Item("RCPSMANZ"), String)
                    dr1("Predio") = CType(dtRECOPRSE.Rows(i).Item("RCPSPRED"), String)
                    dr1("Edificio") = CType(dtRECOPRSE.Rows(i).Item("RCPSEDIF"), String)
                    dr1("Unidad Predial") = CType(dtRECOPRSE.Rows(i).Item("RCPSUNPR"), String)
                    dr1("Sector") = CType(dtRECOPRSE.Rows(i).Item("RCPSCLSE"), String)
                    dr1("Cedula Catastral") = CType(Trim(dtRECOPRSE.Rows(i).Item("RCPSCECA")), String) & " _"
                    dr1("Dirección") = CType(dtRECOPRSE.Rows(i).Item("RCPSDIRE"), String)
                    dr1("Matricula Inmobiliria") = CType(dtRECOPRSE.Rows(i).Item("RCPSMAIN"), String)
                    dr1("Nro. Ficha Predial") = CType(dtRECOPRSE.Rows(i).Item("RCPSNUFI"), String)
                    dr1("Estado") = CType(dtRECOPRSE.Rows(i).Item("RCPSESTA"), String)

                    dt1.Rows.Add(dr1)

                Next

            End If

            Return dt1

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function
    Private Function fun_ConsultarPrediosModificados() As DataTable

        Try
            ' declaro la instancia
            Dim obRECOPRMO As New cla_RECOPRMO
            Dim dtRECOPRMO As New DataTable
            Dim dt1 As New DataTable

            dtRECOPRMO = obRECOPRMO.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECOPRMO(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())

            If dtRECOPRMO.Rows.Count > 0 Then

                ' creo el datagridview dinamicamente 
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Municipio", GetType(String)))
                dt1.Columns.Add(New DataColumn("Correg.", GetType(String)))
                dt1.Columns.Add(New DataColumn("Barrio", GetType(String)))
                dt1.Columns.Add(New DataColumn("Manzana / Vereda", GetType(String)))
                dt1.Columns.Add(New DataColumn("Predio", GetType(String)))
                dt1.Columns.Add(New DataColumn("Edificio", GetType(String)))
                dt1.Columns.Add(New DataColumn("Unidad Predial", GetType(String)))
                dt1.Columns.Add(New DataColumn("Sector", GetType(String)))
                dt1.Columns.Add(New DataColumn("Cedula Catastral", GetType(String)))
                dt1.Columns.Add(New DataColumn("Dirección", GetType(String)))
                dt1.Columns.Add(New DataColumn("Matricula Inmobiliria", GetType(String)))
                dt1.Columns.Add(New DataColumn("Nro. Ficha Predial", GetType(String)))
                dt1.Columns.Add(New DataColumn("Estado", GetType(String)))

                ' declaro la variable
                Dim i As Integer = 0

                For i = 0 To dtRECOPRMO.Rows.Count - 1

                    ' Inserta el registro en el DataTable
                    dr1 = dt1.NewRow()

                    dr1("Municipio") = CType(dtRECOPRMO.Rows(i).Item("RCPMMUNI"), String)
                    dr1("Correg.") = CType(dtRECOPRMO.Rows(i).Item("RCPMCORR"), String)
                    dr1("Barrio") = CType(dtRECOPRMO.Rows(i).Item("RCPMBARR"), String)
                    dr1("Manzana / Vereda") = CType(dtRECOPRMO.Rows(i).Item("RCPMMANZ"), String)
                    dr1("Predio") = CType(dtRECOPRMO.Rows(i).Item("RCPMPRED"), String)
                    dr1("Edificio") = CType(dtRECOPRMO.Rows(i).Item("RCPMEDIF"), String)
                    dr1("Unidad Predial") = CType(dtRECOPRMO.Rows(i).Item("RCPMUNPR"), String)
                    dr1("Sector") = CType(dtRECOPRMO.Rows(i).Item("RCPMCLSE"), String)
                    dr1("Cedula Catastral") = CType(Trim(dtRECOPRMO.Rows(i).Item("RCPMCECA")), String) & " _"
                    dr1("Dirección") = CType(dtRECOPRMO.Rows(i).Item("RCPMDIRE"), String)
                    dr1("Matricula Inmobiliria") = CType(dtRECOPRMO.Rows(i).Item("RCPMMAIN"), String)
                    dr1("Nro. Ficha Predial") = CType(dtRECOPRMO.Rows(i).Item("RCPMNUFI"), String)
                    dr1("Estado") = CType(dtRECOPRMO.Rows(i).Item("RCPMESTA"), String)

                    dt1.Rows.Add(dr1)

                Next

            End If

            Return dt1

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS RESOLUCIONES DE CONSERVACION"

    Private Sub pro_ReconsultarResolucionesDeConservacion()

        Try
            Dim objdatos As New cla_RESOCONS

            If boCONSULTA = False Then
                Me.BindingSource_RESOCONS_1.DataSource = objdatos.fun_Consultar_RESOCONS
            Else
                Me.BindingSource_RESOCONS_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RESOCONS(vp_inConsulta)
            End If

            Me.dgvRESOCONS.DataSource = BindingSource_RESOCONS_1
            Me.BindingNavigator_RESOCONS_1.BindingSource = BindingSource_RESOCONS_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_RESOCONS_1.Count

            Me.dgvRESOCONS.Columns("RECONURE").HeaderText = "Nro. Resolución"
            Me.dgvRESOCONS.Columns("RECOFERE").HeaderText = "Fecha de Resolución"
            Me.dgvRESOCONS.Columns("CLSEDESC").HeaderText = "Sector"
            Me.dgvRESOCONS.Columns("RECOVIRE").HeaderText = "Vigencia Resolución"
            Me.dgvRESOCONS.Columns("RECOVIFI").HeaderText = "Vigencia Fiscal"
            Me.dgvRESOCONS.Columns("RECONURA").HeaderText = "Nro. Radicado OVC"
            Me.dgvRESOCONS.Columns("RECOFERA").HeaderText = "Fecha de Radicado OVC"
            Me.dgvRESOCONS.Columns("RECOFEES").HeaderText = "Fecha de Escritura"
            Me.dgvRESOCONS.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvRESOCONS.Columns("RECOIDRE").Visible = False
            Me.dgvRESOCONS.Columns("RECOSECU").Visible = False
            Me.dgvRESOCONS.Columns("RECOCLAS").Visible = False
            Me.dgvRESOCONS.Columns("CLASDESC").Visible = False
            Me.dgvRESOCONS.Columns("RECOCLSE").Visible = False
            Me.dgvRESOCONS.Columns("RECODESC").Visible = False
            Me.dgvRESOCONS.Columns("RECONUDO").Visible = False
            Me.dgvRESOCONS.Columns("RECOUSUA").Visible = False
            Me.dgvRESOCONS.Columns("RECOOBSE").Visible = False
            Me.dgvRESOCONS.Columns("RECOFEIN").Visible = False
            Me.dgvRESOCONS.Columns("RECOFEFI").Visible = False
            Me.dgvRESOCONS.Columns("RECOUSFI").Visible = False
            Me.dgvRESOCONS.Columns("RECONDFI").Visible = False
            Me.dgvRESOCONS.Columns("RECOESTA").Visible = False
            Me.dgvRESOCONS.Columns("RECOFELI").Visible = False
            Me.dgvRESOCONS.Columns("RECOUSLI").Visible = False
            Me.dgvRESOCONS.Columns("RECONDLI").Visible = False
            Me.dgvRESOCONS.Columns("RECODOAL").Visible = False
            Me.dgvRESOCONS.Columns("RECOFEAL").Visible = False
            Me.dgvRESOCONS.Columns("RECOAJLI").Visible = False
            Me.dgvRESOCONS.Columns("RECOFEAL").Visible = False
            Me.dgvRESOCONS.Columns("RECOUSAL").Visible = False
            Me.dgvRESOCONS.Columns("RECONDAL").Visible = False
            Me.dgvRESOCONS.Columns("RECOAJPR").Visible = False
            Me.dgvRESOCONS.Columns("RECOAJVA").Visible = False
            Me.dgvRESOCONS.Columns("RECOUNID").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_RESOCONS_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_RESOCONS_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_RESOCONS.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_RESOCONS.Enabled = boCONTMODI
            Me.cmdELIMINAR_RESOCONS.Enabled = boCONTELIM
            Me.cmdCONSULTAR_RESOCONS.Enabled = True
            Me.cmdRECONSULTAR_RESOCONS.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresResolucionesDeConservacion()

        Try
            If Me.dgvRESOCONS.RowCount > 0 Then

                Dim objdatos As New cla_RESOCONS
                Dim tbldatos As New DataTable

                tbldatos = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RESOCONS(CInt(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString()))

                If tbldatos.Rows.Count > 0 Then

                    Me.txtRECONURE.Text = Trim(tbldatos.Rows(0).Item("RECONURE").ToString)
                    Me.txtRECOFERE.Text = Trim(tbldatos.Rows(0).Item("RECOFERE").ToString)
                    Me.txtRECONURA.Text = Trim(tbldatos.Rows(0).Item("RECONURA").ToString)
                    Me.txtRECOFERA.Text = Trim(tbldatos.Rows(0).Item("RECOFERA").ToString)
                    Me.txtRECOVIRE.Text = Trim(tbldatos.Rows(0).Item("RECOVIRE").ToString)
                    Me.txtRECOVIFI.Text = Trim(tbldatos.Rows(0).Item("RECOVIFI").ToString)
                    Me.txtRECODESC.Text = Trim(tbldatos.Rows(0).Item("RECODESC").ToString)
                    Me.txtRECOOBSE.Text = Trim(tbldatos.Rows(0).Item("RECOOBSE").ToString)
                    Me.txtRECOFEIN.Text = Trim(tbldatos.Rows(0).Item("RECOFEIN").ToString).ToString.Substring(0, 10)
                    Me.txtRECOFELI.Text = Trim(tbldatos.Rows(0).Item("RECOFELI").ToString)
                    Me.txtRECOFEFI.Text = Trim(tbldatos.Rows(0).Item("RECOFEFI").ToString)
                    Me.txtRECOFEAL.Text = Trim(tbldatos.Rows(0).Item("RECOFEAL").ToString)
                    Me.txtRECODOAL.Text = Trim(tbldatos.Rows(0).Item("RECODOAL").ToString)
                    Me.txtRECOFEDA.Text = Trim(tbldatos.Rows(0).Item("RECOFEAL").ToString)
                    Me.txtRECOUNID.Text = Trim(tbldatos.Rows(0).Item("RECOUNID").ToString)
                    Me.chkRECOAJLI.Checked = CBool(tbldatos.Rows(0).Item("RECOAJLI"))
                    Me.chkRECOAJPR.Checked = CBool(tbldatos.Rows(0).Item("RECOAJPR"))
                    Me.chkRECOAJVA.Checked = CBool(tbldatos.Rows(0).Item("RECOAJVA"))

                    Me.txtRECOCLAS.Text = CType(fun_Buscar_Lista_Valores_CLASIFICACION(Trim(tbldatos.Rows(0).Item("RECOCLAS").ToString)), String)
                    Me.txtRECOUSUA.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Trim(tbldatos.Rows(0).Item("RECONUDO"))), String)
                    Me.txtRECOUSFI.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Trim(tbldatos.Rows(0).Item("RECONDFI"))), String)
                    Me.txtRECOUSLI.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Trim(tbldatos.Rows(0).Item("RECONDLI"))), String)
                    Me.txtRECOUSAL.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Trim(tbldatos.Rows(0).Item("RECONDAL"))), String)

                    Me.cmdAbrirArchivo.Enabled = True
                Else
                    Me.cmdAbrirArchivo.Enabled = False

                End If

                pro_ReconsultarPredioRetirado()
                pro_ListaDeValoresPredioRetirado()

                pro_ReconsultarPredioSegregado()
                pro_ListaDeValoresPredioSegregado()

                pro_ReconsultarPredioModificado()
                pro_ListaDeValoresPredioModificado()

                pro_ReconsultarInformacionDepartamentalPropietarios()
                pro_ListaDeValoresInfomracionDepartamentalPropietarios()

                pro_ReconsultarInformacionDepartamentalPredios()
                pro_ListaDeValoresInfomracionDepartamentalPredios()

                pro_ReconsultarInformacionDepartamentalAvaluos()
                pro_ListaDeValoresInfomracionDepartamentalAvaluos()

                pro_ReconsultarInformacionDepartamentalZonaEconomica()
                pro_ListaDeValoresInfomracionDepartamentalZonaEconomica()

                pro_OperarBotonFinalizar()
                pro_OperarBotonAjusteLiquidacion()
                pro_ListadoArchivosDocumentos()
                pro_ControldeBindingNavigator()

            Else
                pro_LimpiarCamposResolucionDeConservacion()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposResolucionDeConservacion()

        Me.txtRECONURE.Text = ""
        Me.txtRECOFERE.Text = ""
        Me.txtRECONURA.Text = ""
        Me.txtRECOFERA.Text = ""
        Me.txtRECOCLAS.Text = ""
        Me.txtRECODESC.Text = ""
        Me.txtRECOOBSE.Text = ""
        Me.txtRECOVIFI.Text = ""
        Me.txtRECOVIRE.Text = ""

        Me.txtRECOUSUA.Text = ""
        Me.txtRECOUSLI.Text = ""
        Me.txtRECOUSFI.Text = ""

        Me.txtRECOFEIN.Text = ""
        Me.txtRECOFELI.Text = ""
        Me.txtRECOFEFI.Text = ""

        Me.txtRECODOAL.Text = ""
        Me.txtRECOFEDA.Text = ""
        Me.txtRECOFEAL.Text = ""
        Me.txtRECOUSAL.Text = ""
        Me.txtRECOUNID.Text = ""

        Me.lblRECORESO.Text = ""
        Me.lblRECOVIGE.Text = ""

        Me.chkRECOAJLI.Checked = False

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub

    Private Sub pro_ListadoArchivosDocumentos()

        Try
            Me.lstLISTADO_DOCUMENTOS_RESOCONS.Items.Clear()

            ' declara la variable
            Dim stRuta As String = ""
            Dim stNewPath As String = ""
            Dim ContentItem As String

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(20)

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentos() = True Then

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECONURE").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOFERE").Value.ToString)

                vl_stRutaDocumentosPDF = stNewPath


                ChDir(stNewPath)
                Me.lstLISTADO_DOCUMENTOS_RESOCONS.Items.Clear()

                ContentItem = Dir("*.*")

                If ContentItem <> "" Then
                    Me.lstLISTADO_DOCUMENTOS_RESOCONS.Focus()
                End If

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstLISTADO_DOCUMENTOS_RESOCONS.Items.Add(ContentItem)

                    'desplaza el registro
                    ContentItem = Dir()
                Loop

            Else
                Me.lstLISTADO_DOCUMENTOS_RESOCONS.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ControldeBindingNavigator()

        If Me.dgvRESOCONS.RowCount > 0 Then

            Me.BindingNavigator_RECOPRRE_1.Enabled = True
            Me.BindingNavigator_RECOPRSE_1.Enabled = True
            Me.BindingNavigator_RECOPRMO_1.Enabled = True

            Me.BindingNavigator_RECOPRED_1.Enabled = True
            Me.BindingNavigator_RECOAVAL_1.Enabled = True
            Me.BindingNavigator_RECOPROP_1.Enabled = True
            Me.BindingNavigator_RECOZOEC_1.Enabled = True
        Else
            Me.BindingNavigator_RECOPRRE_1.Enabled = False
            Me.BindingNavigator_RECOPRSE_1.Enabled = False
            Me.BindingNavigator_RECOPRMO_1.Enabled = False

            Me.BindingNavigator_RECOPRED_1.Enabled = False
            Me.BindingNavigator_RECOAVAL_1.Enabled = False
            Me.BindingNavigator_RECOPROP_1.Enabled = False
            Me.BindingNavigator_RECOZOEC_1.Enabled = False
        End If

    End Sub
    Private Sub pro_EjecutarBotonFinalizar()

        Try
            If MessageBox.Show("¿ Desea finalizar la resolución Nro. " & Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECONURE").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim stRECLOBSE_ACTUAL As String = ""
                Dim stRECLOBSE_NUEVA As String = " Nota de registro: " & " El usuario: " & vp_usuario & " " & fun_fecha() & " finalizo el tramite. "

                Dim obRECLGEOG As New cla_RESOCONS
                Dim dtRECLGEOG As New DataTable

                dtRECLGEOG = obRECLGEOG.fun_Buscar_ID_RESOCONS(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString())

                If dtRECLGEOG.Rows.Count > 0 Then
                    stRECLOBSE_ACTUAL = Trim(dtRECLGEOG.Rows(0).Item("RECOOBSE").ToString)
                End If

                If Trim(stRECLOBSE_ACTUAL) <> "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                    stRECLOBSE_ACTUAL += vbCrLf & stRECLOBSE_NUEVA & ". "

                ElseIf Trim(stRECLOBSE_ACTUAL) = "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                    stRECLOBSE_ACTUAL = stRECLOBSE_NUEVA & ". "

                End If

                ' buscar cadena de conexion
                Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                ' crear conexión
                oAdapter = New SqlDataAdapter
                oConexion = New SqlConnection(stCadenaConexion)

                ' abre la conexion
                oConexion.Open()

                ' variables
                Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString())
                Dim stMOGEESTA As String = "fi"

                Dim stLIRAFEFI As String = Trim(fun_fecha())

                ' parametros de la consulta
                Dim ParametrosConsulta As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "Update RESOCONS "
                ParametrosConsulta += "Set RECOESTA = '" & stMOGEESTA & "', "
                ParametrosConsulta += "RECOFEFI = '" & stLIRAFEFI & "', "
                ParametrosConsulta += "RECOUSFI = '" & vp_usuario & "', "
                ParametrosConsulta += "RECONDFI = '" & vp_cedula & "', "
                ParametrosConsulta += "RECOOBSE = '" & stRECLOBSE_ACTUAL & "' "
                ParametrosConsulta += "where RECOIDRE = '" & inMOGEIDRE & "' "

                ' ejecuta la consulta
                oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                ' procesa la consulta 
                oEjecutar.CommandTimeout = 0
                oEjecutar.CommandType = CommandType.Text

                oReader = oEjecutar.ExecuteReader

                Dim ii As Integer = oReader.RecordsAffected

                ' cierra la conexion
                oConexion.Close()
                oReader = Nothing

                mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

                boCONSULTA = True

                vp_inConsulta = Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString()

                pro_ReconsultarResolucionesDeConservacion()
                pro_ListaDeValoresResolucionesDeConservacion()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EjecutarBotonAjusteDeLiquidacion()

        Try
            If MessageBox.Show("¿ Desea reportar un ajuste de liquidación a la resolución Nro. " & Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECONURE").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim stRECLOBSE_ACTUAL As String = ""
                Dim stRECLOBSE_DOAJLI As String = InputBox("Ingrese el Nro. Ajuste de liquidación", "Mensaje ...")
                Dim stRECLOBSE_NUEVA As String = " Nota de registro: " & " El usuario: " & vp_usuario & " " & fun_fecha() & " realizo un ajuste de liquidación Nro.: " & Trim(stRECLOBSE_DOAJLI)

                Dim obRECLGEOG As New cla_RESOCONS
                Dim dtRECLGEOG As New DataTable

                dtRECLGEOG = obRECLGEOG.fun_Buscar_ID_RESOCONS(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString())

                If dtRECLGEOG.Rows.Count > 0 Then
                    stRECLOBSE_ACTUAL = Trim(dtRECLGEOG.Rows(0).Item("RECOOBSE").ToString)
                End If

                If Trim(stRECLOBSE_ACTUAL) <> "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                    stRECLOBSE_ACTUAL += vbCrLf & stRECLOBSE_NUEVA & ". "

                ElseIf Trim(stRECLOBSE_ACTUAL) = "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                    stRECLOBSE_ACTUAL = stRECLOBSE_NUEVA & ". "

                End If

                ' buscar cadena de conexion
                Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                ' crear conexión
                oAdapter = New SqlDataAdapter
                oConexion = New SqlConnection(stCadenaConexion)

                ' abre la conexion
                oConexion.Open()

                ' variables
                Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString())
                Dim boMOGEAJLI As Boolean = True
                Dim inMOGEDOAL As Integer = 0

                If Trim(stRECLOBSE_DOAJLI) <> "" Then
                    If fun_Verificar_Dato_Numerico_Evento_Validated(stRECLOBSE_DOAJLI) = True Then
                        inMOGEDOAL = CInt(stRECLOBSE_DOAJLI)
                    End If
                End If

                Dim stLIRAFEFI As String = Trim(fun_fecha())

                ' parametros de la consulta
                Dim ParametrosConsulta As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "Update RESOCONS "
                ParametrosConsulta += "Set "
                ParametrosConsulta += "RECOFEAL = '" & stLIRAFEFI & "', "
                ParametrosConsulta += "RECOUSAL = '" & vp_usuario & "', "
                ParametrosConsulta += "RECONDAL = '" & vp_cedula & "', "
                ParametrosConsulta += "RECODOAL = '" & inMOGEDOAL & "', "
                ParametrosConsulta += "RECOAJLI = '" & boMOGEAJLI & "', "
                ParametrosConsulta += "RECOOBSE = '" & stRECLOBSE_ACTUAL & "' "
                ParametrosConsulta += "where RECOIDRE = '" & inMOGEIDRE & "' "

                ' ejecuta la consulta
                oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                ' procesa la consulta 
                oEjecutar.CommandTimeout = 0
                oEjecutar.CommandType = CommandType.Text

                oReader = oEjecutar.ExecuteReader

                Dim ii As Integer = oReader.RecordsAffected

                ' cierra la conexion
                oConexion.Close()
                oReader = Nothing

                mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

                boCONSULTA = True

                vp_inConsulta = Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString()

                pro_ReconsultarResolucionesDeConservacion()
                pro_ListaDeValoresResolucionesDeConservacion()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_EjecutarBotonObservaciones()

        Try
            If Me.dgvRESOCONS.RowCount > 0 Then

                If MessageBox.Show("¿ Desea ingresar una observación ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim stObservacionNueva As String = InputBox("Ingrese la observación.", "Mensaje")

                    If Trim(stObservacionNueva) = "" Then
                        MessageBox.Show("Se requiere una observación.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                    Else

                        Dim stREMUOBSE_ACTUAL As String = ""
                        Dim stREMUOBSE_NUEVA As String = Trim(stObservacionNueva.ToString.ToUpper)

                        Dim obMOGEGEOG As New cla_RESOCONS
                        Dim dtAJUSGEOG As New DataTable

                        dtAJUSGEOG = obMOGEGEOG.fun_Buscar_ID_RESOCONS(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString())

                        If dtAJUSGEOG.Rows.Count > 0 Then
                            stREMUOBSE_ACTUAL = Trim(dtAJUSGEOG.Rows(0).Item("RECOOBSE").ToString)
                        End If

                        If Trim(stREMUOBSE_ACTUAL) <> "" And Trim(stREMUOBSE_NUEVA) <> "" Then
                            stREMUOBSE_ACTUAL += vbCrLf & " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stREMUOBSE_NUEVA & ". "

                        ElseIf Trim(stREMUOBSE_ACTUAL) = "" And Trim(stREMUOBSE_NUEVA) <> "" Then
                            stREMUOBSE_ACTUAL = " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stREMUOBSE_NUEVA & ". "

                        End If

                        ' buscar cadena de conexion
                        Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion)

                        ' abre la conexion
                        oConexion.Open()

                        ' variables
                        Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString())

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update RESOCONS "
                        ParametrosConsulta += "set RECOOBSE = '" & stREMUOBSE_ACTUAL & "' "
                        ParametrosConsulta += "where RECOIDRE = '" & inMOGEIDRE & "' "

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

                        mod_MENSAJE.Se_Modificaron_Los_Datos_Correctamente()

                        vp_inConsulta = inMOGEIDRE

                        boCONSULTA = True

                        pro_ReconsultarResolucionesDeConservacion()
                        pro_ListaDeValoresResolucionesDeConservacion()

                        Me.TabMAESTRO_2.SelectTab(TabObservaciones)

                    End If

                End If
            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_PermisoControlDeComandos()

        Try

            Me.cmdExportarExcelPredioRetirado.Enabled = fun_PermisoControlDeComandos(vp_usuario, Me.Name, "cmdExportarExcel")
            Me.cmdExportarExcelPredioSegregado.Enabled = fun_PermisoControlDeComandos(vp_usuario, Me.Name, "cmdExportarExcel")
            Me.cmdExportarExcelPredioModificado.Enabled = fun_PermisoControlDeComandos(vp_usuario, Me.Name, "cmdExportarExcel")

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_OperarBotonFinalizar()

        Try
            ' declara la variable
            Dim boUSUARIO As Boolean = False

            If Trim(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOESTA").Value.ToString()) = "ac" Then
                Me.cmdAjusteLiquidacion.Enabled = fun_PermisoControlDeComandos(vp_usuario, Me.Name, "cmdAjusteLiquidacion")
            Else
                Me.cmdFinalizar.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_OperarBotonAjusteLiquidacion()

        Try
            ' declara la variable
            Dim boUSUARIO As Boolean = False

            If Me.chkRECOAJLI.Checked = False Then
                Me.cmdFinalizar.Enabled = fun_PermisoControlDeComandos(vp_usuario, Me.Name, "cmdFinalizar")
            Else
                Me.cmdAjusteLiquidacion.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_AbrirArchivo()

        Try
            ' apaga los comandos
            Me.cmdGrabarDatos.Enabled = False

            ' enruta el archivo
            oLeer.InitialDirectory = "C:\"
            oLeer.Filter = "Archivo de texto (*.txt)|*.txt" 'Colocar varias extensiones
            oLeer.FilterIndex = 1 'coloca por defecto el *.txt
            oLeer.FileName = ""
            oLeer.ShowDialog()

            Dim stRutaArchivo As String = Trim(oLeer.FileName)

            If Trim(stRutaArchivo) <> "" Then

                ' almacena la linea
                Dim stContenidoLinea As String = ""
                Dim stContenidoRegistro As String = ""

                ' abre el archivo
                FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

                stContenidoLinea = LineInput(1)

                ' declara la variable
                vl_inVigencia = CType(stContenidoLinea.Substring(2, 4).ToString, String)
                vl_inResolucion = CType(CInt(stContenidoLinea.Substring(7, 8).ToString), String)

                Me.lblRECOVIGE.Text = CType(vl_inVigencia, String)
                Me.lblRECORESO.Text = CType(vl_inResolucion, String)

                ' limpia la variable
                vl_inTotalRegistros = 0

                ' Total de registros
                Do Until EOF(1)
                    stContenidoLinea = LineInput(1)
                    vl_inTotalRegistros += 1
                Loop

                Me.strBARRESTA.Items(2).Text = "Registro : " & vl_inTotalRegistros

                ' verifica la resolucion y vigencia
                If CInt(vl_inVigencia) = CInt(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOVIRE").Value.ToString()) And _
                   CInt(vl_inResolucion) = CInt(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECONURE").Value.ToString()) Then

                    Me.cmdGrabarDatos.Enabled = True
                    Me.cmdGrabarDatos.Focus()
                Else
                    MessageBox.Show("La resolución y/o vigencia del archivo texto no corresponde.", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub pro_GuardarArchivo()

        Try
            ' apaga el boton grabar datos
            Me.cmdGrabarDatos.Enabled = False

            ' abre el archivo
            FileOpen(1, oLeer.FileName, OpenMode.Input) 'leer

            ' almacena la linea
            Dim stContenidoLinea As String = ""
            Dim stContenidoRegistro As String = ""

            ' Valores predeterminados 
            inProceso = 0
            Me.pbPROCESO.Value = 0
            Me.pbPROCESO.Maximum = vl_inTotalRegistros + 1
            Me.Timer1.Enabled = True

            ' recorre el archivo plano 
            Do Until EOF(1)

                ' extrae la linea
                stContenidoLinea = LineInput(1)

                ' extrae el dato
                stContenidoRegistro = CStr(stContenidoLinea.Substring(0, 1).ToString)

                ' linea de predios
                If stContenidoRegistro = "1" Then

                    ' declara las variables
                    Dim inRCPRSECU As Integer = CInt(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())
                    Dim inRCPRNURE As Integer = CInt(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECONURE").Value.ToString())
                    Dim stRCPRFERE As String = CStr(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOFERE").Value.ToString())
                    Dim inRCPRNUFI As Integer = CInt(stContenidoLinea.Substring(16, 9).ToString)
                    Dim stRCPRDEPA As String = "05"
                    Dim stRCPRMUNI As String = CStr(stContenidoLinea.Substring(26, 3).ToString)
                    Dim stRCPRCORR As String = CStr(stContenidoLinea.Substring(32, 3).ToString)
                    Dim stRCPRBARR As String = CStr(stContenidoLinea.Substring(36, 3).ToString)
                    Dim stRCPRMANZ As String = CStr(stContenidoLinea.Substring(40, 4).ToString)
                    Dim stRCPRPRED As String = CStr(stContenidoLinea.Substring(45, 5).ToString)
                    Dim stRCPREDIF As String = CStr(stContenidoLinea.Substring(51, 4).ToString)
                    Dim stRCPRUNPR As String = CStr(stContenidoLinea.Substring(56, 5).ToString)
                    Dim inRCPRCLSE As Integer = CInt(stContenidoLinea.Substring(30, 1).ToString)
                    Dim stRCPRCECA As String = Trim(stRCPRMUNI) & Trim(inRCPRCLSE) & Trim(stRCPRCORR) & Trim(stRCPRBARR) & Trim(stRCPRMANZ) & Trim(stRCPRPRED) & Trim(stRCPREDIF) & Trim(stRCPRUNPR)
                    Dim stRCPRDIRE As String = CStr(stContenidoLinea.Substring(112, 49).ToString)
                    Dim stRCPRFEIN As String = CStr(stContenidoLinea.Substring(168, 8).ToString)
                    Dim stRCPRNUPN As String = CStr(stContenidoLinea.Substring(177, 30).ToString)
                    Dim stRCPRTITR As String = CStr(stContenidoLinea.Substring(208, 65).ToString)
                    Dim stRCPRESTA As String = "ac"

                    ' instancla la calse
                    Dim obRECOPRED As New cla_RECOPRED
                    Dim dtRECOPRED As New DataTable

                    dtRECOPRED = obRECOPRED.fun_Buscar_CODIGO_X_RECOPRED(inRCPRNURE, Trim(stRCPRFERE), inRCPRNUFI)

                    If dtRECOPRED.Rows.Count = 0 Then

                        ' inserta el registro
                        obRECOPRED.fun_Insertar_RECOPRED(inRCPRSECU, _
                                                         inRCPRNURE, _
                                                         Trim(stRCPRFERE), _
                                                         inRCPRNUFI, _
                                                         Trim(stRCPRDEPA), _
                                                         Trim(stRCPRMUNI), _
                                                         Trim(stRCPRCORR), _
                                                         Trim(stRCPRBARR), _
                                                         Trim(stRCPRMANZ), _
                                                         Trim(stRCPRPRED), _
                                                         Trim(stRCPREDIF), _
                                                         Trim(stRCPRUNPR), _
                                                         Trim(stRCPRCECA), _
                                                         inRCPRCLSE, _
                                                         Trim(stRCPRDIRE), _
                                                         Trim(stRCPRFEIN), _
                                                         Trim(stRCPRNUPN), _
                                                         Trim(stRCPRTITR), _
                                                         Trim(stRCPRESTA))

                    Else
                        ' elimina el registro
                        obRECOPRED.fun_Eliminar_CODIGO_RECOPRED(inRCPRNURE, Trim(stRCPRFERE), inRCPRNUFI)

                        ' inserta el registro
                        obRECOPRED.fun_Insertar_RECOPRED(inRCPRSECU, _
                                                         inRCPRNURE, _
                                                         Trim(stRCPRFERE), _
                                                         inRCPRNUFI, _
                                                         Trim(stRCPRDEPA), _
                                                         Trim(stRCPRMUNI), _
                                                         Trim(stRCPRCORR), _
                                                         Trim(stRCPRBARR), _
                                                         Trim(stRCPRMANZ), _
                                                         Trim(stRCPRPRED), _
                                                         Trim(stRCPREDIF), _
                                                         Trim(stRCPRUNPR), _
                                                         Trim(stRCPRCECA), _
                                                         inRCPRCLSE, _
                                                         Trim(stRCPRDIRE), _
                                                         Trim(stRCPRFEIN), _
                                                         Trim(stRCPRNUPN), _
                                                         Trim(stRCPRTITR), _
                                                         Trim(stRCPRESTA))
                    End If

                End If

                ' linea de avaluos
                If stContenidoRegistro = "2" Then

                    ' declara las variables
                    Dim inRCAVSECU As Integer = CInt(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())
                    Dim inRCAVNURE As Integer = CInt(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECONURE").Value.ToString())
                    Dim stRCAVFERE As String = CStr(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOFERE").Value.ToString())
                    Dim inRCAVNUFI As Integer = CInt(stContenidoLinea.Substring(2, 9).ToString)
                    Dim inRCAVVIGE As Integer = CInt(stContenidoLinea.Substring(12, 4).ToString)
                    Dim loRCAVATPR As Long = CLng(stContenidoLinea.Substring(28, 10).ToString)
                    Dim loRCAVATCO As Long = CLng(stContenidoLinea.Substring(17, 10).ToString)
                    Dim stRCAVACPR As String = CStr(Val(stContenidoLinea.Substring(50, 8).ToString)) & "." & CStr(stContenidoLinea.Substring(58, 2).ToString)
                    Dim stRCAVACCO As String = CStr(Val(stContenidoLinea.Substring(39, 8).ToString)) & "." & CStr(stContenidoLinea.Substring(47, 2).ToString)
                    Dim loRCAVVTPR As Long = CLng(stContenidoLinea.Substring(74, 12).ToString)
                    Dim loRCAVVTCO As Long = CLng(stContenidoLinea.Substring(61, 12).ToString)
                    Dim loRCAVVCPR As Long = CLng(stContenidoLinea.Substring(100, 12).ToString)
                    Dim loRCAVVCCO As Long = CLng(stContenidoLinea.Substring(87, 12).ToString)
                    Dim loRCAVAVAL As Long = CLng(stContenidoLinea.Substring(113, 12).ToString)
                    Dim inRCAVAUTO As Integer = CInt(stContenidoLinea.Substring(126, 1).ToString)
                    Dim boRCAVAUTO As Boolean = False
                    Dim stRCAVESTA As String = "ac"

                    If inRCAVAUTO = 1 Then
                        boRCAVAUTO = True

                    ElseIf inRCAVAUTO = 2 Then
                        boRCAVAUTO = False
                    End If

                    ' instancla la calse
                    Dim obRECOAVAL As New cla_RECOAVAL
                    Dim dtRECOAVAL As New DataTable

                    dtRECOAVAL = obRECOAVAL.fun_Buscar_CODIGO_X_RECOAVAL(inRCAVNURE, Trim(stRCAVFERE), inRCAVNUFI, inRCAVVIGE)

                    If dtRECOAVAL.Rows.Count = 0 Then

                        ' inserta el registro
                        obRECOAVAL.fun_Insertar_RECOAVAL(inRCAVSECU, _
                                                         inRCAVNURE, _
                                                         Trim(stRCAVFERE), _
                                                         inRCAVNUFI, _
                                                         inRCAVVIGE, _
                                                         loRCAVATPR, _
                                                         loRCAVATCO, _
                                                         stRCAVACPR, _
                                                         stRCAVACCO, _
                                                         loRCAVVTPR, _
                                                         loRCAVVTCO, _
                                                         loRCAVVCPR, _
                                                         loRCAVVCCO, _
                                                         loRCAVAVAL, _
                                                         boRCAVAUTO, _
                                                         Trim(stRCAVESTA))

                    Else
                        ' elimina el registro
                        obRECOAVAL.fun_Eliminar_CODIGO_RECOAVAL(inRCAVNURE, Trim(stRCAVFERE), inRCAVNUFI, inRCAVVIGE)

                        ' inserta el registro
                        obRECOAVAL.fun_Insertar_RECOAVAL(inRCAVSECU, _
                                                         inRCAVNURE, _
                                                         Trim(stRCAVFERE), _
                                                         inRCAVNUFI, _
                                                         inRCAVVIGE, _
                                                         loRCAVATPR, _
                                                         loRCAVATCO, _
                                                         stRCAVACPR, _
                                                         stRCAVACCO, _
                                                         loRCAVVTPR, _
                                                         loRCAVVTCO, _
                                                         loRCAVVCPR, _
                                                         loRCAVVCCO, _
                                                         loRCAVAVAL, _
                                                         boRCAVAUTO, _
                                                         Trim(stRCAVESTA))
                    End If

                End If

                ' linea de propietarios
                If stContenidoRegistro = "3" Then

                    ' declara las variables
                    Dim inRCPRSECU As Integer = CInt(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())
                    Dim inRCPRNURE As Integer = CInt(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECONURE").Value.ToString())
                    Dim stRCPRFERE As String = CStr(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOFERE").Value.ToString())
                    Dim stRCPRNUDO As String = CStr(stContenidoLinea.Substring(17, 14).ToString)
                    Dim stRCPRMAIN As String = CStr(stContenidoLinea.Substring(190, 7).ToString)
                    Dim stRCPRPRAP As String = CStr(stContenidoLinea.Substring(35, 15).ToString)
                    Dim stRCPRSEAP As String = CStr(stContenidoLinea.Substring(51, 15).ToString)
                    Dim stRCPRNOMB As String = CStr(stContenidoLinea.Substring(67, 30).ToString)
                    Dim stRCPRDERE_1 As String = CInt(stContenidoLinea.Substring(166, 3).ToString)
                    Dim stRCPRDERE_2 As String = CStr(".")
                    Dim stRCPRDERE_3 As String = CStr(stContenidoLinea.Substring(169, 6).ToString)
                    Dim stRCPRDERE As String = CStr(Trim(stRCPRDERE_1) & Trim(stRCPRDERE_2) & Trim(stRCPRDERE_3))
                    Dim inRCPRESCR As Integer = CInt(stContenidoLinea.Substring(150, 6).ToString)
                    Dim stRCPRDIFE As String = CStr(fun_Formato_Mascara_2_Reales(stContenidoLinea.Substring(157, 2).ToString))
                    Dim stRCPRMEFE As String = CStr(fun_Formato_Mascara_2_Reales(stContenidoLinea.Substring(159, 2).ToString))
                    Dim stRCPRANFE As String = CStr(fun_Formato_Mascara_4_Reales(stContenidoLinea.Substring(161, 4).ToString))
                    Dim stRCPRFEES As String = CStr(stRCPRDIFE) & "-" & CStr(stRCPRMEFE) & "-" & CStr(stRCPRANFE)
                    Dim stRCPRESTA As String = CStr("ac")

                    If Trim(stRCPRPRAP) = "" And Trim(stRCPRSEAP) = "" And Trim(stRCPRNOMB) = "" Then
                        stRCPRNOMB = CStr(stContenidoLinea.Substring(98, 30).ToString)
                    End If

                    ' instancla la calse
                    Dim obRECOPROP As New cla_RECOPROP
                    Dim dtRECOPROP As New DataTable

                    dtRECOPROP = obRECOPROP.fun_Buscar_CODIGO_X_RECOPROP(inRCPRNURE, Trim(stRCPRFERE), Trim(stRCPRNUDO), Trim(stRCPRMAIN))

                    If dtRECOPROP.Rows.Count = 0 Then

                        ' inserta el registro
                        obRECOPROP.fun_Insertar_RECOPROP(inRCPRSECU, _
                                                         inRCPRNURE, _
                                                         Trim(stRCPRFERE), _
                                                         Trim(stRCPRNUDO), _
                                                         Trim(stRCPRMAIN), _
                                                         Trim(stRCPRPRAP), _
                                                         Trim(stRCPRSEAP), _
                                                         Trim(stRCPRNOMB), _
                                                         Trim(stRCPRDERE), _
                                                         inRCPRESCR, _
                                                         Trim(stRCPRFEES), _
                                                         Trim(stRCPRESTA))

                    Else
                        ' elimina el registro
                        obRECOPROP.fun_Eliminar_CODIGO_RECOPROP(inRCPRNURE, Trim(stRCPRFERE), Trim(stRCPRNUDO), Trim(stRCPRMAIN))

                        ' inserta el registro
                        obRECOPROP.fun_Insertar_RECOPROP(inRCPRSECU, _
                                                         inRCPRNURE, _
                                                         Trim(stRCPRFERE), _
                                                         Trim(stRCPRNUDO), _
                                                         Trim(stRCPRMAIN), _
                                                         Trim(stRCPRPRAP), _
                                                         Trim(stRCPRSEAP), _
                                                         Trim(stRCPRNOMB), _
                                                         Trim(stRCPRDERE), _
                                                         inRCPRESCR, _
                                                         Trim(stRCPRFEES), _
                                                         Trim(stRCPRESTA))
                    End If

                End If

                ' linea de zona economica
                If stContenidoRegistro = "4" Then

                    ' declara las variables
                    Dim inRCZESECU As Integer = CInt(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())
                    Dim inRCZENURE As Integer = CInt(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECONURE").Value.ToString())
                    Dim stRCZEFERE As String = CStr(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOFERE").Value.ToString())
                    Dim inRCZENUFI As Integer = CInt(stContenidoLinea.Substring(2, 9).ToString)
                    Dim inRCZEZOEC As Integer = CInt(stContenidoLinea.Substring(12, 3).ToString)
                    Dim inRCZEPORC As Integer = CInt(stContenidoLinea.Substring(16, 3).ToString)
                    Dim stRCZEESTA As String = "ac"

                    ' instancla la calse
                    Dim obRECOZOEC As New cla_RECOZOEC
                    Dim dtRECOZOEC As New DataTable

                    dtRECOZOEC = obRECOZOEC.fun_Buscar_CODIGO_X_RECOZOEC(inRCZENURE, Trim(stRCZEFERE), inRCZENUFI, inRCZEZOEC)

                    If dtRECOZOEC.Rows.Count = 0 Then

                        ' inserta el registro
                        obRECOZOEC.fun_Insertar_RECOZOEC(inRCZESECU, _
                                                         inRCZENURE, _
                                                         Trim(stRCZEFERE), _
                                                         inRCZENUFI, _
                                                         inRCZEZOEC, _
                                                         inRCZEPORC, _
                                                         Trim(stRCZEESTA))

                    Else
                        ' elimina el registro
                        obRECOZOEC.fun_Eliminar_CODIGO_RECOZOEC(inRCZENURE, Trim(stRCZEFERE), inRCZENUFI, inRCZEZOEC)

                        ' inserta el registro
                        obRECOZOEC.fun_Insertar_RECOZOEC(inRCZESECU, _
                                                         inRCZENURE, _
                                                         Trim(stRCZEFERE), _
                                                         inRCZENUFI, _
                                                         inRCZEZOEC, _
                                                         inRCZEPORC, _
                                                         Trim(stRCZEESTA))
                    End If

                End If

                ' Incrementa la barra
                inProceso = inProceso + 1
                pbPROCESO.Value = inProceso

            Loop

            ' limpia la barra
            Me.pbPROCESO.Value = 0

            pro_ReconsultarResolucionesDeConservacion()
            pro_ListaDeValoresResolucionesDeConservacion()

            ' mensaje de finalizacion
            mod_MENSAJE.Proceso_Termino_Correctamente()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub

#End Region

#Region "PROCEDIMIENTOS INFORMACION DEPARTAMENTAL"

#Region "PREDIO"

    Private Sub pro_ReconsultarInformacionDepartamentalPredios()

        Try
            Dim objdatos As New cla_RECOPRED

            If boCONSULTA = False Then
                Me.BindingSource_RECOPRED_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RECOPRED(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())
            Else
                Me.BindingSource_RECOPRED_1.DataSource = objdatos.fun_Consultar_RECOPRED(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())
            End If

            Me.dgvRECOPRED.DataSource = BindingSource_RECOPRED_1
            Me.BindingNavigator_RECOPRED_1.BindingSource = BindingSource_RECOPRED_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_RESOCONS_1.Count

            Me.dgvRECOPRED.Columns("RCPRNUFI").HeaderText = "Nro. Ficha"
            Me.dgvRECOPRED.Columns("RCPRDEPA").HeaderText = "Departamento"
            Me.dgvRECOPRED.Columns("RCPRMUNI").HeaderText = "Municipio"
            Me.dgvRECOPRED.Columns("RCPRCORR").HeaderText = "Corregimiento"
            Me.dgvRECOPRED.Columns("RCPRBARR").HeaderText = "Barrio"
            Me.dgvRECOPRED.Columns("RCPRMANZ").HeaderText = "Manzana Vereda"
            Me.dgvRECOPRED.Columns("RCPRPRED").HeaderText = "Predio"
            Me.dgvRECOPRED.Columns("RCPREDIF").HeaderText = "Edificio"
            Me.dgvRECOPRED.Columns("RCPRUNPR").HeaderText = "Unidad Predial"
            Me.dgvRECOPRED.Columns("RCPRCECA").HeaderText = "Cedula Catastral"
            Me.dgvRECOPRED.Columns("RCPRCLSE").HeaderText = "Sector"
            Me.dgvRECOPRED.Columns("RCPRDIRE").HeaderText = "Direccion"
            Me.dgvRECOPRED.Columns("RCPRNUPN").HeaderText = "Nro. Unico Predial Nacional"
            Me.dgvRECOPRED.Columns("RCPRTITR").HeaderText = "Tipo de Tramite"
            Me.dgvRECOPRED.Columns("RCPRESTA").HeaderText = "Estado"

            Me.dgvRECOPRED.Columns("RCPRIDRE").Visible = False
            Me.dgvRECOPRED.Columns("RCPRNURE").Visible = False
            Me.dgvRECOPRED.Columns("RCPRFERE").Visible = False
            Me.dgvRECOPRED.Columns("RCPRSECU").Visible = False
            Me.dgvRECOPRED.Columns("RCPRFEIN").Visible = False


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresInfomracionDepartamentalPredios()

    End Sub
    Private Sub pro_LimpiarInformacionDepartamentalPredios()

    End Sub

#End Region

#Region "AVALUOS"

    Private Sub pro_ReconsultarInformacionDepartamentalAvaluos()

        Try
            Dim objdatos As New cla_RECOAVAL

            If boCONSULTA = False Then
                Me.BindingSource_RECOAVAL_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RECOAVAL(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())
            Else
                Me.BindingSource_RECOAVAL_1.DataSource = objdatos.fun_Consultar_RECOAVAL(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())
            End If

            Me.dgvRECOAVAL.DataSource = BindingSource_RECOAVAL_1
            Me.BindingNavigator_RECOAVAL_1.BindingSource = BindingSource_RECOAVAL_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_RESOCONS_1.Count

            Me.dgvRECOAVAL.Columns("RCAVNUFI").HeaderText = "Nro. Ficha"
            Me.dgvRECOAVAL.Columns("RCAVVIGE").HeaderText = "Vigencia"
            Me.dgvRECOAVAL.Columns("RCAVATPR").HeaderText = "Area Terreno Privada m²"
            Me.dgvRECOAVAL.Columns("RCAVATCO").HeaderText = "Area Terreno Comun m²"
            Me.dgvRECOAVAL.Columns("RCAVACPR").HeaderText = "Area Construcción Privada m²"
            Me.dgvRECOAVAL.Columns("RCAVACCO").HeaderText = "Area Construcción Comun m²"
            Me.dgvRECOAVAL.Columns("RCAVVTPR").HeaderText = "Valor Terreno Privado"
            Me.dgvRECOAVAL.Columns("RCAVVTCO").HeaderText = "Valor Terreno Comun"
            Me.dgvRECOAVAL.Columns("RCAVVCPR").HeaderText = "Valor Construcción Privada"
            Me.dgvRECOAVAL.Columns("RCAVVCCO").HeaderText = "Valor Construcción Comun"
            Me.dgvRECOAVAL.Columns("RCAVAVAL").HeaderText = "Avalúo Catastral"
            Me.dgvRECOAVAL.Columns("RCAVAUTO").HeaderText = "Auto Avalúo"
            Me.dgvRECOAVAL.Columns("RCAVESTA").HeaderText = "Estado"

            Me.dgvRECOAVAL.Columns("RCAVIDRE").Visible = False
            Me.dgvRECOAVAL.Columns("RCAVNURE").Visible = False
            Me.dgvRECOAVAL.Columns("RCAVFERE").Visible = False
            Me.dgvRECOAVAL.Columns("RCAVSECU").Visible = False

            Me.dgvRECOAVAL.Columns("RCAVVTPR").DefaultCellStyle.Format = "c"
            Me.dgvRECOAVAL.Columns("RCAVVTCO").DefaultCellStyle.Format = "c"
            Me.dgvRECOAVAL.Columns("RCAVVCPR").DefaultCellStyle.Format = "c"
            Me.dgvRECOAVAL.Columns("RCAVVCCO").DefaultCellStyle.Format = "c"
            Me.dgvRECOAVAL.Columns("RCAVAVAL").DefaultCellStyle.Format = "c"

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresInfomracionDepartamentalAvaluos()

    End Sub
    Private Sub pro_LimpiarInformacionDepartamentalAvaluos()

    End Sub

#End Region

#Region "PROPIETARIOS"

    Private Sub pro_ReconsultarInformacionDepartamentalPropietarios()

        Try
            Dim objdatos As New cla_RECOPROP

            If boCONSULTA = False Then
                Me.BindingSource_RECOPROP_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RECOPROP(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())
            Else
                Me.BindingSource_RECOPROP_1.DataSource = objdatos.fun_Consultar_RECOPROP(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())
            End If

            Me.dgvRECOPROP.DataSource = BindingSource_RECOPROP_1
            Me.BindingNavigator_RECOPROP_1.BindingSource = BindingSource_RECOPROP_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_RESOCONS_1.Count

            Me.dgvRECOPROP.Columns("RCPRMAIN").HeaderText = "Matricula Inmobiliria"
            Me.dgvRECOPROP.Columns("RCPRNUDO").HeaderText = "Nro. Documento"
            Me.dgvRECOPROP.Columns("RCPRPRAP").HeaderText = "Primer Apellido"
            Me.dgvRECOPROP.Columns("RCPRSEAP").HeaderText = "Segundo Apellido"
            Me.dgvRECOPROP.Columns("RCPRNOMB").HeaderText = "Nombre(s)"
            Me.dgvRECOPROP.Columns("RCPRDERE").HeaderText = "Derecho"
            Me.dgvRECOPROP.Columns("RCPRESCR").HeaderText = "Nro. Escritura"
            Me.dgvRECOPROP.Columns("RCPRFEES").HeaderText = "Fecha Escritura"
            Me.dgvRECOPROP.Columns("RCPRESTA").HeaderText = "Estado"

            Me.dgvRECOPROP.Columns("RCPRIDRE").Visible = False
            Me.dgvRECOPROP.Columns("RCPRNURE").Visible = False
            Me.dgvRECOPROP.Columns("RCPRFERE").Visible = False
            Me.dgvRECOPROP.Columns("RCPRSECU").Visible = False

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresInfomracionDepartamentalPropietarios()

    End Sub
    Private Sub pro_LimpiarInformacionDepartamentalPropietarios()

    End Sub

#End Region

#Region "ZONA ECONOMICA"

    Private Sub pro_ReconsultarInformacionDepartamentalZonaEconomica()

        Try
            Dim objdatos As New cla_RECOZOEC

            If boCONSULTA = False Then
                Me.BindingSource_RECOZOEC_1.DataSource = objdatos.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_RECOZOEC(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())
            Else
                Me.BindingSource_RECOZOEC_1.DataSource = objdatos.fun_Consultar_RECOZOEC(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())
            End If

            Me.dgvRECOZOEC.DataSource = BindingSource_RECOZOEC_1
            Me.BindingNavigator_RECOZOEC_1.BindingSource = BindingSource_RECOZOEC_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_RESOCONS_1.Count

            Me.dgvRECOZOEC.Columns("RCZENUFI").HeaderText = "Nro. Ficha"
            Me.dgvRECOZOEC.Columns("RCZEZOEC").HeaderText = "Zona Económica"
            Me.dgvRECOZOEC.Columns("RCZEPORC").HeaderText = "Porcentaje"
            Me.dgvRECOZOEC.Columns("RCZEESTA").HeaderText = "Estado"

            Me.dgvRECOZOEC.Columns("RCZEIDRE").Visible = False
            Me.dgvRECOZOEC.Columns("RCZENURE").Visible = False
            Me.dgvRECOZOEC.Columns("RCZEFERE").Visible = False
            Me.dgvRECOZOEC.Columns("RCZESECU").Visible = False

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresInfomracionDepartamentalZonaEconomica()

    End Sub
    Private Sub pro_LimpiarInformacionDepartamentalZonaEconomica()

    End Sub

#End Region

#End Region

#Region "PROCEDIMIENTO PREDIO RETIRADO"

    Private Sub pro_ReconsultarPredioRetirado()

        Try
            Dim objdatos As New cla_RECOPRRE

            If boCONSULTA = False Then
                Me.BindingSource_RECOPRRE_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECOPRRE(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())
            Else
                Me.BindingSource_RECOPRRE_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECOPRRE(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())
            End If

            Me.dgvRECOPRRE.DataSource = BindingSource_RECOPRRE_1
            Me.BindingNavigator_RECOPRRE_1.BindingSource = BindingSource_RECOPRRE_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_RESOCONS_1.Count

            Me.dgvRECOPRRE.Columns("RCPRMUNI").HeaderText = "Municipio"
            Me.dgvRECOPRRE.Columns("RCPRCORR").HeaderText = "Correg."
            Me.dgvRECOPRRE.Columns("RCPRBARR").HeaderText = "Barrio"
            Me.dgvRECOPRRE.Columns("RCPRMANZ").HeaderText = "Manzana Vereda"
            Me.dgvRECOPRRE.Columns("RCPRPRED").HeaderText = "Predio"
            Me.dgvRECOPRRE.Columns("RCPREDIF").HeaderText = "Edificio"
            Me.dgvRECOPRRE.Columns("RCPRUNPR").HeaderText = "Unidad Predial"
            Me.dgvRECOPRRE.Columns("RCPRCLSE").HeaderText = "Sector"
            Me.dgvRECOPRRE.Columns("RCPRCECA").HeaderText = "Cedula Catastral"
            Me.dgvRECOPRRE.Columns("RCPRDIRE").HeaderText = "Dirección"
            Me.dgvRECOPRRE.Columns("RCPRMAIN").HeaderText = "Matricula Inmobiliria"
            Me.dgvRECOPRRE.Columns("RCPRNUFI").HeaderText = "Nro. Ficha Predial"
            Me.dgvRECOPRRE.Columns("RCPRESTA").HeaderText = "Estado"

            Me.dgvRECOPRRE.Columns("RCPRIDRE").Visible = False
            Me.dgvRECOPRRE.Columns("RCPRNURE").Visible = False
            Me.dgvRECOPRRE.Columns("RCPRFERE").Visible = False
            Me.dgvRECOPRRE.Columns("RCPRSECU").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_RECOPRRE_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_RECOPRRE_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_RECOPRRE.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_RECOPRRE.Enabled = boCONTMODI
            Me.cmdELIMINAR_RECOPRRE.Enabled = boCONTELIM
            Me.cmdCONSULTAR_RECOPRRE.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_RECOPRRE.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresPredioRetirado()

    End Sub
    Private Sub pro_LimpiarCamposPredioRetirado()

        'Me.dgvRECOPRSE.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTO PREDIO SEGREGADO"

    Private Sub pro_ReconsultarPredioSegregado()

        Try
            Dim objdatos As New cla_RECOPRSE

            If boCONSULTA = False Then
                Me.BindingSource_RECOPRSE_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECOPRSE(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())
            Else
                Me.BindingSource_RECOPRSE_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECOPRSE(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())
            End If

            Me.dgvRECOPRSE.DataSource = BindingSource_RECOPRSE_1
            Me.BindingNavigator_RECOPRSE_1.BindingSource = BindingSource_RECOPRSE_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_RESOCONS_1.Count

            Me.dgvRECOPRSE.Columns("RCPSMUNI").HeaderText = "Municipio"
            Me.dgvRECOPRSE.Columns("RCPSCORR").HeaderText = "Correg."
            Me.dgvRECOPRSE.Columns("RCPSBARR").HeaderText = "Barrio"
            Me.dgvRECOPRSE.Columns("RCPSMANZ").HeaderText = "Manzana Vereda"
            Me.dgvRECOPRSE.Columns("RCPSPRED").HeaderText = "Predio"
            Me.dgvRECOPRSE.Columns("RCPSEDIF").HeaderText = "Edificio"
            Me.dgvRECOPRSE.Columns("RCPSUNPR").HeaderText = "Unidad Predial"
            Me.dgvRECOPRSE.Columns("RCPSCLSE").HeaderText = "Sector"
            Me.dgvRECOPRSE.Columns("RCPSCECA").HeaderText = "Cedula Catastral"
            Me.dgvRECOPRSE.Columns("RCPSDIRE").HeaderText = "Dirección"
            Me.dgvRECOPRSE.Columns("RCPSMAIN").HeaderText = "Matricula Inmobiliria"
            Me.dgvRECOPRSE.Columns("RCPSNUFI").HeaderText = "Nro. Ficha Predial"
            Me.dgvRECOPRSE.Columns("RCPSESTA").HeaderText = "Estado"

            Me.dgvRECOPRSE.Columns("RCPSIDRE").Visible = False
            Me.dgvRECOPRSE.Columns("RCPSNURE").Visible = False
            Me.dgvRECOPRSE.Columns("RCPSFERE").Visible = False
            Me.dgvRECOPRSE.Columns("RCPSSECU").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_RECOPRSE_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_RECOPRSE_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_RECOPRSE.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_RECOPRSE.Enabled = boCONTMODI
            Me.cmdELIMINAR_RECOPRSE.Enabled = boCONTELIM
            Me.cmdCONSULTAR_RECOPRSE.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_RECOPRSE.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresPredioSegregado()

    End Sub
    Private Sub pro_LimpiarCamposPredioSegregado()

        'Me.dgvRECOPRSE.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMEINTO PREDIO MODIFICADO"

    Private Sub pro_ReconsultarPredioModificado()

        Try
            Dim objdatos As New cla_RECOPRMO

            If boCONSULTA = False Then
                Me.BindingSource_RECOPRMO_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECOPRMO(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())
            Else
                Me.BindingSource_RECOPRMO_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECOPRMO(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString())
            End If

            Me.dgvRECOPRMO.DataSource = BindingSource_RECOPRMO_1
            Me.BindingNavigator_RECOPRMO_1.BindingSource = BindingSource_RECOPRMO_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_RESOCONS_1.Count

            Me.dgvRECOPRMO.Columns("RCPMMUNI").HeaderText = "Municipio"
            Me.dgvRECOPRMO.Columns("RCPMCORR").HeaderText = "Correg."
            Me.dgvRECOPRMO.Columns("RCPMBARR").HeaderText = "Barrio"
            Me.dgvRECOPRMO.Columns("RCPMMANZ").HeaderText = "Manzana Vereda"
            Me.dgvRECOPRMO.Columns("RCPMPRED").HeaderText = "Predio"
            Me.dgvRECOPRMO.Columns("RCPMEDIF").HeaderText = "Edificio"
            Me.dgvRECOPRMO.Columns("RCPMUNPR").HeaderText = "Unidad Predial"
            Me.dgvRECOPRMO.Columns("RCPMCLSE").HeaderText = "Sector"
            Me.dgvRECOPRMO.Columns("RCPMCECA").HeaderText = "Cedula Catastral"
            Me.dgvRECOPRMO.Columns("RCPMDIRE").HeaderText = "Dirección"
            Me.dgvRECOPRMO.Columns("RCPMMAIN").HeaderText = "Matricula Inmobiliria"
            Me.dgvRECOPRMO.Columns("RCPMNUFI").HeaderText = "Nro. Ficha Predial"
            Me.dgvRECOPRMO.Columns("RCPMESTA").HeaderText = "Estado"

            Me.dgvRECOPRMO.Columns("RCPMIDRE").Visible = False
            Me.dgvRECOPRMO.Columns("RCPMNURE").Visible = False
            Me.dgvRECOPRMO.Columns("RCPMFERE").Visible = False
            Me.dgvRECOPRMO.Columns("RCPMSECU").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_RECOPRMO_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_RECOPRMO_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_RECOPRMO.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_RECOPRMO.Enabled = boCONTMODI
            Me.cmdELIMINAR_RECOPRMO.Enabled = boCONTELIM
            Me.cmdCONSULTAR_RECOPRMO.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_RECOPRMO.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresPredioModificado()

    End Sub
    Private Sub pro_LimpiarCamposPredioModificado()

        'Me.dgvRECOPRSE.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU RESOLUCIONES DE CONSERVACION"

    Private Sub cmdAGREGAR_RESOCONS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_RESOCONS.Click

        Try

            If Me.dgvRESOCONS.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_RESOCONS(Integer.Parse(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString()))
                frm_insertar.ShowDialog()
            Else
                frm_insertar_RESOCONS.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarResolucionesDeConservacion()
            pro_ListaDeValoresResolucionesDeConservacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_RESOCONS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_RESOCONS.Click

        Try
            Dim frm_modificar As New frm_modificar_RESOCONS(Integer.Parse(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString()))
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarResolucionesDeConservacion()
            pro_ListaDeValoresResolucionesDeConservacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_RESOCONS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_RESOCONS.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RESOCONS

                If objdatos.fun_Eliminar_IDRE_RESOCONS(Integer.Parse(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString())) Then

                    boCONSULTA = False

                    pro_LimpiarCamposResolucionDeConservacion()
                    pro_ReconsultarResolucionesDeConservacion()
                    pro_ListaDeValoresResolucionesDeConservacion()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_RESOCONS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_RESOCONS.Click

        Try
            vp_inConsulta = 0

            If Me.dgvRESOCONS.RowCount > 0 Then
                Dim frm_consultar As New frm_consultar_RESOCONS(Integer.Parse(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString()))
                frm_consultar.ShowDialog()
            Else
                Dim frm_consultar As New frm_consultar_RESOCONS()
                frm_consultar.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarResolucionesDeConservacion()
            pro_ListaDeValoresResolucionesDeConservacion()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_RESOCONS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_RESOCONS.Click

        Try
            If Me.dgvRESOCONS.RowCount > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarResolucionesDeConservacion()
            pro_ListaDeValoresResolucionesDeConservacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdBITACORA_PENDLIQU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBITACORA_PENDLIQU.Click

        Try
            vp_inConsulta = 0

            If Me.dgvRESOCONS.RowCount > 0 Then
                Dim frm_bitacora As New frm_bitacora_pendientes_liquidar_RESOCONS(Integer.Parse(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString()))
                frm_bitacora.ShowDialog()
            Else
                Dim frm_bitacora As New frm_bitacora_pendientes_liquidar_RESOCONS()
                frm_bitacora.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarResolucionesDeConservacion()
            pro_ListaDeValoresResolucionesDeConservacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdBITACORA_PENDINAC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBITACORA_PENDINAC.Click

        Try
            vp_inConsulta = 0

            If Me.dgvRESOCONS.RowCount > 0 Then
                Dim frm_bitacora As New frm_bitacora_pendientes_inactivar_RESOCONS(Integer.Parse(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString()))
                frm_bitacora.ShowDialog()
            Else
                Dim frm_bitacora As New frm_bitacora_pendientes_inactivar_RESOCONS()
                frm_bitacora.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarResolucionesDeConservacion()
            pro_ListaDeValoresResolucionesDeConservacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click

        Try
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdIMPORTAR_DOCUMENTOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIMPORTAR_DOCUMENTOS.Click

        Try
            If Me.dgvRESOCONS.RowCount > 0 Then

                Dim frm_inserta_archivo As New frm_insertar_archivo_RESOCONS(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECONURE").Value.ToString(), _
                                                                             Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOFERE").Value.ToString())
                frm_inserta_archivo.ShowDialog()


                vp_inConsulta = Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString()

                If vp_inConsulta <> 0 Then
                    boCONSULTA = True
                Else
                    boCONSULTA = False
                End If

                pro_ReconsultarResolucionesDeConservacion()
                pro_ListaDeValoresResolucionesDeConservacion()

                mod_MENSAJE.Proceso_Termino_Correctamente()

            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub cmdOBSERVACIONES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOBSERVACIONES.Click
        pro_EjecutarBotonObservaciones()
    End Sub
    Private Sub cmdFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFinalizar.Click
        pro_EjecutarBotonFinalizar()
        pro_EjecutarBotonObservaciones()
    End Sub
    Private Sub cmdAjusteLiquidacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAjusteLiquidacion.Click
        pro_EjecutarBotonAjusteDeLiquidacion()
        pro_EjecutarBotonObservaciones()
    End Sub
    Private Sub cmdAbrirArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivo.Click
        pro_AbrirArchivo()
    End Sub
    Private Sub cmdGrabarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabarDatos.Click
        pro_GuardarArchivo()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Try
            pro_ListaDeValoresResolucionesDeConservacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        Try
            pro_ListaDeValoresResolucionesDeConservacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click

        Try
            pro_ListaDeValoresResolucionesDeConservacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click

        Try
            pro_ListaDeValoresResolucionesDeConservacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub cmdExportarExcelPredioRetirado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcelPredioRetirado.Click
        Try
            If Me.dgvRECOPRRE.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                fun_ConsultarPrediosRetirados()

                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(fun_ConsultarPrediosRetirados(), DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarExcelPredioSegregado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcelPredioSegregado.Click
        Try
            If Me.dgvRECOPRSE.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(fun_ConsultarPrediosSegregados(), DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarExcelPredioModificado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcelPredioModificado.Click
        Try
            If Me.dgvRECOPRMO.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(fun_ConsultarPrediosModificados(), DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

#End Region

#Region "MENU PREDIO RETIRADO"

    Private Sub cmdAGREGAR_RECOPRRE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_RECOPRRE.Click

        Try
            If Me.dgvRESOCONS.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_RECOPRRE(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString(), _
                                                              Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECONURE").Value.ToString(), _
                                                              Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOFERE").Value.ToString())
                frm_insertar.ShowDialog()
            End If

            boCONSULTA = False

            pro_ReconsultarPredioRetirado()
            pro_ListaDeValoresPredioRetirado()

            Me.TabMAESTRO_2.SelectTab(TabPrediosRetirados)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_RECOPRRE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_RECOPRRE.Click

        Try
            Dim frm_modificar As New frm_modificar_RECOPRRE(Me.dgvRECOPRRE.SelectedRows.Item(0).Cells("RCPRIDRE").Value.ToString(), _
                                                            Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString(), _
                                                            Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECONURA").Value.ToString(), _
                                                            Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOFERA").Value.ToString())
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarPredioRetirado()
            pro_ListaDeValoresPredioRetirado()

            Me.TabMAESTRO_2.SelectTab(TabPrediosRetirados)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_RECOPRRE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_RECOPRRE.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RECOPRRE

                If objdatos.fun_Eliminar_IDRE_RECOPRRE(Integer.Parse(Me.dgvRECOPRRE.SelectedRows.Item(0).Cells("RCPRIDRE").Value.ToString())) Then

                    boCONSULTA = False

                    pro_LimpiarCamposPredioRetirado()
                    pro_ReconsultarPredioRetirado()
                    pro_ListaDeValoresPredioRetirado()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_RECOPRRE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_RECOPRRE.Click

        vp_inConsulta = 0

        If Me.dgvRESOCONS.RowCount > 0 Then
            Dim frm_consultar As New frm_consultar_RESOCONS(Integer.Parse(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString()))
            frm_consultar.ShowDialog()
        Else
            Dim frm_consultar As New frm_consultar_RESOCONS()
            frm_consultar.ShowDialog()
        End If

        If vp_inConsulta > 0 Then
            boCONSULTA = True
        Else
            boCONSULTA = False
        End If

        pro_ReconsultarResolucionesDeConservacion()
        pro_ListaDeValoresResolucionesDeConservacion()

    End Sub
    Private Sub cmdRECONSULTAR_RECOPRRE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_RECOPRRE.Click

        Try
            If Me.dgvRESOCONS.RowCount > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarResolucionesDeConservacion()
            pro_ListaDeValoresResolucionesDeConservacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU PREDIO SEGREGADO"

    Private Sub cmdAGREGAR_RECOPRSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_RECOPRSE.Click

        Try
            If Me.dgvRESOCONS.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_RECOPRSE(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString(), _
                                                              Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECONURE").Value.ToString(), _
                                                              Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOFERE").Value.ToString())
                frm_insertar.ShowDialog()
            End If

            boCONSULTA = False

            pro_ReconsultarPredioSegregado()
            pro_ListaDeValoresPredioSegregado()

            Me.TabMAESTRO_2.SelectTab(TabPrediosSegregados)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_RECOPRSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_RECOPRSE.Click

        Try
            Dim frm_modificar As New frm_modificar_RECOPRSE(Me.dgvRECOPRSE.SelectedRows.Item(0).Cells("RCPSIDRE").Value.ToString(), _
                                                            Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString(), _
                                                            Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECONURA").Value.ToString(), _
                                                            Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOFERA").Value.ToString())
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarPredioSegregado()
            pro_ListaDeValoresPredioSegregado()

            Me.TabMAESTRO_2.SelectTab(TabPrediosSegregados)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_RECOPRSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_RECOPRSE.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RECOPRSE

                If objdatos.fun_Eliminar_IDRE_RECOPRSE(Integer.Parse(Me.dgvRECOPRSE.SelectedRows.Item(0).Cells("RCPSIDRE").Value.ToString())) Then

                    boCONSULTA = False

                    pro_LimpiarCamposPredioSegregado()
                    pro_ReconsultarPredioSegregado()
                    pro_ListaDeValoresPredioSegregado()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_RECOPRSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_RECOPRSE.Click

        vp_inConsulta = 0

        If Me.dgvRESOCONS.RowCount > 0 Then
            Dim frm_consultar As New frm_consultar_RESOCONS(Integer.Parse(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString()))
            frm_consultar.ShowDialog()
        Else
            Dim frm_consultar As New frm_consultar_RESOCONS()
            frm_consultar.ShowDialog()
        End If

        If vp_inConsulta > 0 Then
            boCONSULTA = True
        Else
            boCONSULTA = False
        End If

        pro_ReconsultarResolucionesDeConservacion()
        pro_ListaDeValoresResolucionesDeConservacion()

    End Sub
    Private Sub cmdRECONSULTAR_RECOPRSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_RECOPRSE.Click

        Try
            If Me.dgvRESOCONS.RowCount > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarResolucionesDeConservacion()
            pro_ListaDeValoresResolucionesDeConservacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU PREDIO MODIFICADO"

    Private Sub cmdAGREGAR_RECOPRMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_RECOPRMO.Click

        Try
            If Me.dgvRESOCONS.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_RECOPRMO(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString(), _
                                                              Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECONURE").Value.ToString(), _
                                                              Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOFERE").Value.ToString())
                frm_insertar.ShowDialog()
            End If

            boCONSULTA = False

            pro_ReconsultarPredioModificado()
            pro_ListaDeValoresPredioModificado()

            Me.TabMAESTRO_2.SelectTab(TabPrediosModificados)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_RECOPRMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_RECOPRMO.Click

        Try
            Dim frm_modificar As New frm_modificar_RECOPRMO(Me.dgvRECOPRMO.SelectedRows.Item(0).Cells("RCPMIDRE").Value.ToString(), _
                                                            Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOSECU").Value.ToString(), _
                                                            Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECONURA").Value.ToString(), _
                                                            Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOFERA").Value.ToString())
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            End If

            pro_ReconsultarPredioModificado()
            pro_ListaDeValoresPredioModificado()

            Me.TabMAESTRO_2.SelectTab(TabPrediosModificados)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_RECOPRMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_RECOPRMO.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RECOPRMO

                If objdatos.fun_Eliminar_IDRE_RECOPRMO(Integer.Parse(Me.dgvRECOPRMO.SelectedRows.Item(0).Cells("RCPMIDRE").Value.ToString())) Then

                    boCONSULTA = False

                    pro_LimpiarCamposPredioModificado()
                    pro_ReconsultarPredioModificado()
                    pro_ListaDeValoresPredioModificado()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_RECOPRMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_RECOPRMO.Click

        vp_inConsulta = 0

        If Me.dgvRESOCONS.RowCount > 0 Then
            Dim frm_consultar As New frm_consultar_RESOCONS(Integer.Parse(Me.dgvRESOCONS.SelectedRows.Item(0).Cells("RECOIDRE").Value.ToString()))
            frm_consultar.ShowDialog()
        Else
            Dim frm_consultar As New frm_consultar_RESOCONS()
            frm_consultar.ShowDialog()
        End If

        If vp_inConsulta > 0 Then
            boCONSULTA = True
        Else
            boCONSULTA = False
        End If

        pro_ReconsultarResolucionesDeConservacion()
        pro_ListaDeValoresResolucionesDeConservacion()

    End Sub
    Private Sub cmdRECONSULTAR_RECOPRMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_RECOPRMO.Click

        Try
            If Me.dgvRESOCONS.RowCount > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarResolucionesDeConservacion()
            pro_ListaDeValoresResolucionesDeConservacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU INFORMACION DEPARTAMENTAL"

    Private Sub cmdRECONSULTAR_INDEPRED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_INDEPRED.Click

        Try
            boCONSULTA = False
            pro_ReconsultarInformacionDepartamentalPredios()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_INDEAVAL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_INDEAVAL.Click

        Try
            boCONSULTA = False
            pro_ReconsultarInformacionDepartamentalAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_INDEPROP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_INDEPROP.Click

        Try
            boCONSULTA = False
            pro_ReconsultarInformacionDepartamentalPropietarios()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_INDEZOEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_INDEZOEC.Click

        Try
            boCONSULTA = False
            pro_ReconsultarInformacionDepartamentalZonaEconomica()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_RESOCONS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        pro_ReconsultarResolucionesDeConservacion()
        pro_PermisoControlDeComandos()
        pro_ControldeBindingNavigator()

        Me.strBARRESTA.Items(0).Text = "Resolución conservación"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_RESOCONS_GotFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValoresResolucionesDeConservacion()
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvREGIMUTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRESOCONS.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================


        If e.KeyCode = Keys.F2 Then
            If Me.cmdAGREGAR_RESOCONS.Enabled = True Then
                Me.cmdAGREGAR_RESOCONS.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If Me.cmdMODIFICAR_RESOCONS.Enabled = True Then
                Me.cmdMODIFICAR_RESOCONS.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_RESOCONS_1.Count

                If ContarRegistros = 0 Then
                    mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
                Else
                    mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
                End If

            End If
        End If

        '===============================================================================================
        '*** ELIMINAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.Delete Then
            If Me.cmdELIMINAR_RESOCONS.Enabled = True Then
                Me.cmdELIMINAR_RESOCONS.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_RESOCONS_1.Count

                If ContarRegistros = 0 Then
                    mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
                Else
                    mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
                End If

            End If
        End If

        '===============================================================================================
        '*** CONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F7 Then
            If Me.cmdCONSULTAR_RESOCONS.Enabled = True Then
                Me.cmdCONSULTAR_RESOCONS.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If Me.cmdCONSULTAR_RESOCONS.Enabled = True Then
                Me.cmdRECONSULTAR_RESOCONS.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvREGIMUTA_1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRESOCONS.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresResolucionesDeConservacion()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvREGIMUTA_1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRESOCONS.CellClick
        pro_ListaDeValoresResolucionesDeConservacion()
    End Sub

#End Region

#Region "DoubleClick"

    Private Sub lstLISTADO_DOCUMENTOS_RESOCONS_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLISTADO_DOCUMENTOS_RESOCONS.DoubleClick

        Try
            If lstLISTADO_DOCUMENTOS_RESOCONS.SelectedIndex <> -1 Then

                Dim stArchivo As String = lstLISTADO_DOCUMENTOS_RESOCONS.SelectedItem
                Process.Start(vl_stRutaDocumentosPDF & "\" & stArchivo)
            Else

                If lstLISTADO_DOCUMENTOS_RESOCONS.Items.Count > 0 Then
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