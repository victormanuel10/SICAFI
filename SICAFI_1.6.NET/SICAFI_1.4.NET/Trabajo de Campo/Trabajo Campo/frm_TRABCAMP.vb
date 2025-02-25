Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_TRABCAMP

    '========================
    '*** TRABAJO DE CAMPO ***
    '========================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False

    Dim vl_stRutaDocumentos As String = ""

    Dim stMensaje01 As String = "¿ Desea cambiar el estado del tramite ? "

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

    Dim inProceso As Integer = 0

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_TRABCAMP
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_TRABCAMP
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

    Private Function fun_VerificarCarpetaExistenteDocumentosTrabajoDeCampo() As Boolean

        Try
            Dim stRuta As String = ""
            Dim stCarpetaABuscar As String = ""

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(6)

            If tblRutas.Rows.Count > 0 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' directorio expediente 
                stCarpetaABuscar = Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAMUNI").Value.ToString) & "-" & _
                                   Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACLSE").Value.ToString) & "-" & _
                                   Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACORR").Value.ToString) & "-" & _
                                   Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCABARR").Value.ToString) & "-" & _
                                   Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAMANZ").Value.ToString) & "-" & _
                                   Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAPRED").Value.ToString) & "-" & _
                                   Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAVIGE").Value.ToString)

                Dim Ruta As New DirectoryInfo(stRuta)

                Dim TodasLasCarpetas(), CarpetaABuscar As DirectoryInfo

                ' declara la variable 
                Dim sw As Byte = 1

                TodasLasCarpetas = Ruta.GetDirectories()

                ' recorre el directorio
                For Each CarpetaABuscar In TodasLasCarpetas

                    If CarpetaABuscar.FullName = Ruta.FullName & stCarpetaABuscar Then
                        sw = 0
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
    Private Function fun_VerificarCarpetaExistenteDocumentosTrabajoDeCampoMovimientosGeograficos() As Boolean

        Try
            Dim stRuta As String = ""
            Dim stCarpetaABuscar As String = ""

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(13)

            If tblRutas.Rows.Count > 0 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' directorio expediente 
                stCarpetaABuscar = Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAMUNI").Value.ToString) & "-" & _
                                   Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACLSE").Value.ToString) & "-" & _
                                   Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACORR").Value.ToString) & "-" & _
                                   Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCABARR").Value.ToString) & "-" & _
                                   Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAMANZ").Value.ToString) & "-" & _
                                   Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAPRED").Value.ToString) & "-" & _
                                   Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAVIGE").Value.ToString)

                Dim Ruta As New DirectoryInfo(stRuta)

                Dim TodasLasCarpetas(), CarpetaABuscar As DirectoryInfo

                ' declara la variable 
                Dim sw As Byte = 1

                TodasLasCarpetas = Ruta.GetDirectories()

                ' recorre el directorio
                For Each CarpetaABuscar In TodasLasCarpetas

                    If CarpetaABuscar.FullName = Ruta.FullName & stCarpetaABuscar Then
                        sw = 0
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
    Private Function fun_VerificarCarpetaExistenteDocumentosTrabajoDeCampoMovimientosAlfanumericos() As Boolean

        Try
            Dim stRuta As String = ""
            Dim stCarpetaABuscar As String = ""

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(16)

            If tblRutas.Rows.Count > 0 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' directorio expediente 
                stCarpetaABuscar = Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAMUNI").Value.ToString) & "-" & _
                                   Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACLSE").Value.ToString) & "-" & _
                                   Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACORR").Value.ToString) & "-" & _
                                   Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCABARR").Value.ToString) & "-" & _
                                   Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAMANZ").Value.ToString) & "-" & _
                                   Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAPRED").Value.ToString) & "-" & _
                                   Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAVIGE").Value.ToString)

                Dim Ruta As New DirectoryInfo(stRuta)

                Dim TodasLasCarpetas(), CarpetaABuscar As DirectoryInfo

                ' declara la variable 
                Dim sw As Byte = 1

                TodasLasCarpetas = Ruta.GetDirectories()

                ' recorre el directorio
                For Each CarpetaABuscar In TodasLasCarpetas

                    If CarpetaABuscar.FullName = Ruta.FullName & stCarpetaABuscar Then
                        sw = 0
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

    Private Function fun_ContarArchivosDocumentosMovimientoGeografico() As Integer

        Try

            ' declara la variable
            Dim stNewPath As String = ""
            Dim ContentItem As String = ""
            Dim inContador As Integer = 0

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(13)

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentosTrabajoDeCampoMovimientosGeograficos() = True Then

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & _
                            Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAMUNI").Value.ToString) & "-" & _
                            Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACLSE").Value.ToString) & "-" & _
                            Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACORR").Value.ToString) & "-" & _
                            Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCABARR").Value.ToString) & "-" & _
                            Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAMANZ").Value.ToString) & "-" & _
                            Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAPRED").Value.ToString) & "-" & _
                            Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAVIGE").Value.ToString)

                vl_stRutaDocumentos = stNewPath

                ChDir(stNewPath)

                ContentItem = Dir("*.pdf")

                Do Until ContentItem = ""

                    ' cuanta el registro
                    inContador += 1

                    'desplaza el registro
                    ContentItem = Dir()
                Loop

            End If

            Return inContador

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarRegistrosTramitesOVCMovimientoGeografico() As Integer

        Try
            ' declara la variable
            Dim inContador As Integer = 0

            ' declara la instancia
            Dim obMOGETRAM As New cla_MOGETRAM
            Dim dtMOGETRAM As New DataTable

            dtMOGETRAM = obMOGETRAM.fun_Buscar_CODIGO_X_MOGETRAM(CInt(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString))

            inContador = dtMOGETRAM.Rows.Count

            Return inContador

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarRegistrosPrediosNuevosMovimientoGeografico() As Integer

        Try
            ' declara la variable
            Dim inContador As Integer = 0

            ' instancia la clase
            Dim obMOVIGEOG As New cla_MOVIGEOG
            Dim dtMOVIGEOG As New DataTable

            dtMOVIGEOG = obMOVIGEOG.fun_Buscar_CODIGO_X_MOVIGEOG(CInt(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString))

            If dtMOVIGEOG.Rows.Count > 0 Then

                ' declara la variable
                Dim stCAUSACTO As String = CStr(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACAAC").Value.ToString)

                ' declara la clase
                Dim obCAUSACTO As New cla_CAUSACTO
                Dim dtCAUSACTO As New DataTable

                dtCAUSACTO = obCAUSACTO.fun_Buscar_CODIGO_MANT_CAUSACTO(Trim(stCAUSACTO))

                If dtCAUSACTO.Rows.Count > 0 Then

                    ' declara la variable
                    Dim boCondicion As Boolean = CBool(dtCAUSACTO.Rows(0).Item("CAACINPR"))

                    ' declara la clase
                    Dim obMOVIPRNU As New cla_MOGEPRNU
                    Dim dtMOVIPRNU As New DataTable

                    dtMOVIPRNU = obMOVIPRNU.fun_Buscar_CODIGO_X_MOGEPRNU(CInt(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString))

                    If dtMOVIPRNU.Rows.Count = 0 And boCondicion = True Then
                        inContador = 0
                    Else
                        inContador = 1
                    End If

                End If

            End If

            Return inContador

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS TRABAJO DE CAMPO"

    Private Sub pro_ReconsultarTrabajoDeCampo()

        Try
            Dim objdatos As New cla_TRABCAMP

            If boCONSULTA = False Then
                Me.BindingSource_TRABCAMP_1.DataSource = objdatos.fun_Consultar_TRABCAMP
            Else
                Me.BindingSource_TRABCAMP_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TRABCAMP(vp_inConsulta)
            End If

            Me.dgvTRABCAMP.DataSource = BindingSource_TRABCAMP_1
            Me.BindingNavigator_TRABCAMP_1.BindingSource = BindingSource_TRABCAMP_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_TRABCAMP_1.Count

            Me.dgvTRABCAMP.Columns("TRCAIDRE").HeaderText = "idre"
            Me.dgvTRABCAMP.Columns("TRCASECU").HeaderText = "Tramite"

            Me.dgvTRABCAMP.Columns("TRCADEPA").HeaderText = "Departamento"
            Me.dgvTRABCAMP.Columns("TRCAMUNI").HeaderText = "Municipio"
            Me.dgvTRABCAMP.Columns("TRCACORR").HeaderText = "Corregim."
            Me.dgvTRABCAMP.Columns("TRCABARR").HeaderText = "Barrio"
            Me.dgvTRABCAMP.Columns("TRCAMANZ").HeaderText = "Manzana- Vereda"
            Me.dgvTRABCAMP.Columns("TRCAPRED").HeaderText = "Predio"
            Me.dgvTRABCAMP.Columns("CLSEDESC").HeaderText = "Sector"
            Me.dgvTRABCAMP.Columns("TRCAVIGE").HeaderText = "Vigencia"
            Me.dgvTRABCAMP.Columns("TRCAFEES").HeaderText = "Fecha Escritura"
            Me.dgvTRABCAMP.Columns("TRCAESCR").HeaderText = "Escritura"
            Me.dgvTRABCAMP.Columns("TRCAPRNU").HeaderText = "Predios Nuevos"
            Me.dgvTRABCAMP.Columns("TRCACAAC").HeaderText = "Causa del Acto"
            Me.dgvTRABCAMP.Columns("TRCANODE").HeaderText = "Notaria Departamento"
            Me.dgvTRABCAMP.Columns("TRCANOMU").HeaderText = "Notaria Municipio"
            Me.dgvTRABCAMP.Columns("TRCANOTA").HeaderText = "Notaria"
            Me.dgvTRABCAMP.Columns("TRCAOBSE").HeaderText = "Observacion"
            Me.dgvTRABCAMP.Columns("TRCAFEIN").HeaderText = "Fecha de ingreso"
            Me.dgvTRABCAMP.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvTRABCAMP.Columns("TRCAIDRE").Visible = False
            'Me.dgvTRABCAMP.Columns("TRCASECU").Visible = False
            Me.dgvTRABCAMP.Columns("TRCAMACA").Visible = False

            Me.dgvTRABCAMP.Columns("TRCADEPA").Visible = False
            Me.dgvTRABCAMP.Columns("TRCAFEES").Visible = False
            Me.dgvTRABCAMP.Columns("TRCAESCR").Visible = False
            Me.dgvTRABCAMP.Columns("TRCAPRNU").Visible = False
            Me.dgvTRABCAMP.Columns("TRCAPRMO").Visible = False
            Me.dgvTRABCAMP.Columns("TRCAPREL").Visible = False
            Me.dgvTRABCAMP.Columns("TRCACAAC").Visible = False
            Me.dgvTRABCAMP.Columns("TRCANODE").Visible = False
            Me.dgvTRABCAMP.Columns("TRCANOMU").Visible = False
            Me.dgvTRABCAMP.Columns("TRCANOTA").Visible = False
            Me.dgvTRABCAMP.Columns("TRCAOBSE").Visible = False
            Me.dgvTRABCAMP.Columns("TRCAPRMO").Visible = False
            Me.dgvTRABCAMP.Columns("TRCAPREL").Visible = False
            Me.dgvTRABCAMP.Columns("TRCADESC").Visible = False
            Me.dgvTRABCAMP.Columns("TRCAESTA").Visible = False
            Me.dgvTRABCAMP.Columns("TRCACLSE").Visible = False
            Me.dgvTRABCAMP.Columns("TRCAMAIN").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_TRABCAMP_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_TRABCAMP_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_TRABCAMP.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_TRABCAMP.Enabled = boCONTMODI
            Me.cmdELIMINAR_TRABCAMP.Enabled = boCONTELIM
            Me.cmdCONSULTAR_TRABCAMP.Enabled = True
            Me.cmdRECONSULTAR_TRABCAMP.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresTrabajoDeCampo()

        Try
            If Me.dgvTRABCAMP.RowCount > 0 Then

                Dim objdatos As New cla_TRABCAMP
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TRABCAMP(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAIDRE").Value.ToString)

                Me.txtTRCAFEES.Text = Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAFEES").Value.ToString)
                Me.txtTRCAESCR.Text = Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAESCR").Value.ToString)
                Me.txtTRCAPRNU.Text = Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAPRNU").Value.ToString)
                Me.txtTRCAPRMO.Text = Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAPRMO").Value.ToString)
                Me.txtTRCAPREL.Text = Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAPREL").Value.ToString)
                Me.txtTRCACAAC.Text = Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACAAC").Value.ToString)
                Me.txtTRCANODE.Text = Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCANODE").Value.ToString)
                Me.txtTRCANOMU.Text = Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCANOMU").Value.ToString)
                Me.txtTRCANOTA.Text = Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCANOTA").Value.ToString)
                Me.txtTRCAOBSE.Text = Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAOBSE").Value.ToString)
                Me.txtTRCADESC.Text = Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCADESC").Value.ToString)

                Me.lblTRCACAAC.Text = CType(fun_Buscar_Lista_Valores_CAUSACTO(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACAAC").Value.ToString), String)
                Me.lblTRCANOTA.Text = CType(fun_Buscar_Lista_Valores_NOTARIA(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCANODE").Value.ToString, Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCANOMU").Value.ToString, Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCANOTA").Value.ToString), String)
                Me.lblTRCAMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCADEPA").Value.ToString, Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAMUNI").Value.ToString), String)

                Me.txtTRCAMAIN.Text = Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAMAIN").Value.ToString)

                Me.lblTRCACORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCADEPA").Value.ToString, Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAMUNI").Value.ToString, Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACLSE").Value.ToString, Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACORR").Value.ToString), String)

                If CInt(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACLSE").Value.ToString) = 1 Then
                    Me.lblTRCABAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCADEPA").Value.ToString, Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAMUNI").Value.ToString, Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACLSE").Value.ToString, Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCABARR").Value.ToString, Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACORR").Value.ToString), String)
                ElseIf CInt(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACLSE").Value.ToString) = 2 Then
                    Me.lblTRCABAVE.Text = CType(fun_Buscar_Lista_Valores_VEREDA(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCADEPA").Value.ToString, Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAMUNI").Value.ToString, Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACLSE").Value.ToString, Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAMANZ").Value.ToString, Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACORR").Value.ToString), String)
                ElseIf CInt(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACLSE").Value.ToString) = 3 Then
                    Me.lblTRCABAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCADEPA").Value.ToString, Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAMUNI").Value.ToString, Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACLSE").Value.ToString, Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCABARR").Value.ToString, Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACORR").Value.ToString), String)
                End If
                Me.lblTRCACLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACLSE").Value.ToString), String)

                Me.txtTRCAMACA.Text = CType(fun_Buscar_Lista_Valores_USUARIO(tbl.Rows(0).Item("TRCAMACA")), String)

                If Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAESTA").Value.ToString) = "fi" Then
                    Me.cmdFinalizar.Enabled = False
                Else
                    pro_PermisoControlDeComandos()
                End If

                pro_ReconsultarMaterialDeRegistro()
                pro_ListaDeValoresMaterialDeRegistro()

                pro_ReconsultarInformacionDeUsuario()
                pro_ListaDeValoresInformacionDeUsuario()

                pro_ReconsultarMaterialDeUsuario()
                pro_ListaDeValoresMaterialDeUsuario()

                pro_ReconsultarMaterialDeFaltante()
                pro_ListaDeValoresMaterialDeFaltante()

                pro_ReconsultarLevantamiento()
                pro_ListaDeValoresLevantamiento()

                pro_ReconsultarDigitacion()
                pro_ListaDeValoresDigitacion()

                pro_ReconsultarLiquidacion()
                pro_ListaDeValoresLiquidacion()

                pro_ReconsultarArchivo()
                pro_ListaDeValoresArchivo()

                pro_PermisoControlBindingNavigator()
                pro_ListadoArchivosDocumentos()

                Me.BindingNavigator_MATEREGI_1.Enabled = True
                Me.BindingNavigator_INFOUSUA_1.Enabled = True
                Me.BindingNavigator_MATEUSUA_1.Enabled = True
                Me.BindingNavigator_MATEFALT_1.Enabled = True
                Me.BindingNavigator_LEVANTAMIENTO_1.Enabled = True
                Me.BindingNavigator_DIGITACION_1.Enabled = True
                Me.BindingNavigator_LIQUIDACION_1.Enabled = True
                Me.BindingNavigator_ARCHIVO_1.Enabled = True

            Else
                pro_LimpiarCamposTrabajoDeCampo()
                pro_LimpiarMaterialRegistro()
                pro_LimpiarInformacionUsuario()
                pro_LimpiarMaterialUsuario()
                pro_LimpiarMaterialFaltante()
                pro_LimpiarLevantamiento()
                pro_LimpiarDigitacion()
                pro_LimpiarLiquidacion()
                pro_LimpiarArchivo()

                Me.BindingNavigator_MATEREGI_1.Enabled = False
                Me.BindingNavigator_INFOUSUA_1.Enabled = False
                Me.BindingNavigator_MATEUSUA_1.Enabled = False
                Me.BindingNavigator_MATEFALT_1.Enabled = False
                Me.BindingNavigator_LEVANTAMIENTO_1.Enabled = False
                Me.BindingNavigator_DIGITACION_1.Enabled = False
                Me.BindingNavigator_LIQUIDACION_1.Enabled = False
                Me.BindingNavigator_ARCHIVO_1.Enabled = False

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposTrabajoDeCampo()

        Me.lblTRCAMUNI.Text = ""
        Me.lblTRCACLSE.Text = ""
        Me.txtTRCAFEES.Text = ""
        Me.txtTRCAESCR.Text = ""
        Me.txtTRCAPRNU.Text = ""
        Me.txtTRCAPRMO.Text = ""
        Me.txtTRCAPREL.Text = ""
        Me.txtTRCACAAC.Text = ""
        Me.lblTRCACAAC.Text = ""
        Me.txtTRCANODE.Text = ""
        Me.txtTRCANOMU.Text = ""
        Me.txtTRCANOTA.Text = ""
        Me.lblTRCANOTA.Text = ""
        Me.txtTRCAOBSE.Text = ""
        Me.txtTRCAMACA.Text = ""
        Me.txtTRCADESC.Text = ""
        Me.lblTRCABAVE.Text = ""
        Me.lblTRCACORR.Text = ""

        Me.lstLISTADO_DOCUMENTOS.Items.Clear()

        ' Me.dgvTRABCAMP.DataSource = New DataTable
        ' Me.dgvMOGEVALI_1.DataSource = New DataTable
        ' Me.dgvMOGEVALI_2.DataSource = New DataTable

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

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

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(6)

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentosTrabajoDeCampo() = True Then

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAMUNI").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACLSE").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACORR").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCABARR").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAMANZ").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAPRED").Value.ToString) & "-" & _
                                                                            Trim(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAVIGE").Value.ToString)

                vl_stRutaDocumentos = stNewPath

                ChDir(stNewPath)

                Me.lstLISTADO_DOCUMENTOS.Items.Clear()

                ContentItem = Dir("*.*")

                If ContentItem <> "" Then
                    Me.lstLISTADO_DOCUMENTOS.Focus()
                End If

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstLISTADO_DOCUMENTOS.Items.Add(ContentItem)

                    'desplaza el registro
                    ContentItem = Dir()
                Loop

            Else
                Me.lstLISTADO_DOCUMENTOS.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_PermisoControlDeComandos()

        Try

            Me.cmdFinalizar.Enabled = fun_PermisoControlDeComandos(vp_usuario, Me.Name, Me.cmdFinalizar.Name)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_PermisoControlBindingNavigator()

        Try
            If Me.BindingSource_LEVANTAMIENTO_1.Count > 0 Then
                Me.BindingNavigator_DIGITACION_1.Enabled = True
                Me.BindingNavigator_LIQUIDACION_1.Enabled = False
            Else
                Me.BindingNavigator_DIGITACION_1.Enabled = False
                Me.BindingNavigator_LIQUIDACION_1.Enabled = False
            End If

            If Me.BindingSource_DIGITACION_1.Count > 0 Then
                Me.BindingNavigator_LIQUIDACION_1.Enabled = True
            Else
                Me.BindingNavigator_LIQUIDACION_1.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_ValidarTramiteDocumentosMovimientosGeograficos()

        Try
            ' Crea objeto registros
            Dim dr1 As DataRow

            ' crea la tabla
            Dim dt_ValidarTramiteDocumentos As New DataTable

            ' crea columnas
            dt_ValidarTramiteDocumentos.Columns.Add(New DataColumn("Tipo_Error", GetType(String)))
            dt_ValidarTramiteDocumentos.Columns.Add(New DataColumn("Inconsistencia", GetType(String)))

            ' instancia la clase
            Dim obMOVIGEOG As New cla_MOVIGEOG
            Dim dtMOVIGEOG As New DataTable

            dtMOVIGEOG = obMOVIGEOG.fun_Buscar_CODIGO_X_MOVIGEOG(CInt(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString))

            If dtMOVIGEOG.Rows.Count > 0 Then

                ' valida tramite en ovc
                If fun_ContarRegistrosTramitesOVCMovimientoGeografico() = 0 Then

                    dr1 = dt_ValidarTramiteDocumentos.NewRow()

                    dr1("Tipo_Error") = "Advertencia"
                    dr1("Inconsistencia") = "NO se encuentra registrado el Nro. de Tramite OVC en Movimiento Geografico"

                    dt_ValidarTramiteDocumentos.Rows.Add(dr1)

                End If

                ' valida documentos anexos movimientos geograficos
                If fun_ContarArchivosDocumentosMovimientoGeografico() = 0 Then

                    dr1 = dt_ValidarTramiteDocumentos.NewRow()

                    dr1("Tipo_Error") = "Severo"
                    dr1("Inconsistencia") = "NO se encuentra documentos anexos en Movimiento Geografico (Acta de visita, Certificación de estrato etc.)"

                    dt_ValidarTramiteDocumentos.Rows.Add(dr1)

                End If

                ' valida registro de predios nuevos movimientos geograficos
                If fun_ContarRegistrosPrediosNuevosMovimientoGeografico() = 0 Then

                    dr1 = dt_ValidarTramiteDocumentos.NewRow()

                    dr1("Tipo_Error") = "Severo"
                    dr1("Inconsistencia") = "NO se encuentra registrado predios nuevos en Movimiento Geografico"

                    dt_ValidarTramiteDocumentos.Rows.Add(dr1)

                End If

            Else

                dr1 = dt_ValidarTramiteDocumentos.NewRow()

                dr1("Tipo_Error") = "Advertencia"
                dr1("Inconsistencia") = "No existe registro en movimiento geografico"

                dt_ValidarTramiteDocumentos.Rows.Add(dr1)

            End If


            Me.dgvMOGEVALI_1.DataSource = dt_ValidarTramiteDocumentos
            Me.dgvMOGEVALI_1.Columns("Tipo_Error").Width = 50

            If Me.dgvMOGEVALI_1.RowCount = 0 Then
                mod_MENSAJE.Proceso_Termino_Correctamente()
            Else
                mod_MENSAJE.Proceso_Termino_Con_Inconsistencias()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ValidarTramiteFotografiaMovimientosGeograficos()

        Try
            ' propiedad del boton
            Me.cmdValidarMovimientoGeograficos_2.Enabled = False

            ' Crea objeto registros
            Dim dr1 As DataRow

            ' crea la tabla
            Dim dt_ValidarTramiteFotografia As New DataTable

            ' crea columnas
            dt_ValidarTramiteFotografia.Columns.Add(New DataColumn("Tipo_Error", GetType(String)))
            dt_ValidarTramiteFotografia.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
            dt_ValidarTramiteFotografia.Columns.Add(New DataColumn("Nro_Construccion", GetType(String)))
            dt_ValidarTramiteFotografia.Columns.Add(New DataColumn("Nro_Foto", GetType(String)))
            dt_ValidarTramiteFotografia.Columns.Add(New DataColumn("Inconsistencia", GetType(String)))

            ' instancia la clase
            Dim obMOVIGEOG As New cla_MOVIGEOG
            Dim dtMOVIGEOG As New DataTable

            dtMOVIGEOG = obMOVIGEOG.fun_Buscar_CODIGO_X_MOVIGEOG(CInt(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString))

            If dtMOVIGEOG.Rows.Count > 0 Then

                ' instancia la clase
                Dim obMOGEPRNU As New cla_MOGEPRNU
                Dim dtMOGEPRNU As New DataTable

                dtMOGEPRNU = obMOGEPRNU.fun_Buscar_CODIGO_X_MOGEPRNU(CInt(dtMOVIGEOG.Rows(0).Item("MOGESECU").ToString))

                If dtMOGEPRNU.Rows.Count > 0 Then

                    ' declaro la variable
                    Dim i As Integer = 0

                    For i = 0 To dtMOGEPRNU.Rows.Count - 1

                        ' declara la variable
                        Dim inFIPRTIFI As Integer = 0

                        ' instancia la clase
                        Dim obFICHPRED As New cla_FICHPRED
                        Dim dtFICHPRED As New DataTable

                        dtFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_x_CEDULA(CStr(Trim(dtMOGEPRNU.Rows(i).Item("MGPNMUNI").ToString)), _
                                                                                     CStr(Trim(dtMOGEPRNU.Rows(i).Item("MGPNCLSE").ToString)), _
                                                                                     CStr(Trim(dtMOGEPRNU.Rows(i).Item("MGPNCORR").ToString)), _
                                                                                     CStr(Trim(dtMOGEPRNU.Rows(i).Item("MGPNBARR").ToString)), _
                                                                                     CStr(Trim(dtMOGEPRNU.Rows(i).Item("MGPNMANZ").ToString)), _
                                                                                     CStr(Trim(dtMOGEPRNU.Rows(i).Item("MGPNPRED").ToString)), _
                                                                                     CInt(inFIPRTIFI))
                        If dtFICHPRED.Rows.Count > 0 Then

                            ' Valores predeterminados ProgressBar
                            inProceso = 0
                            Me.pbPROCESO.Value = 0
                            Me.pbPROCESO.Maximum = CInt(dtFICHPRED.Rows.Count)
                            Me.Timer1.Enabled = True

                            ' declaro la variable
                            Dim ii As Integer = 0

                            For ii = 0 To dtFICHPRED.Rows.Count - 1

                                ' verifica el estado
                                If Trim(dtFICHPRED.Rows(ii).Item("FIPRESTA").ToString) = "ac" Then

                                    ' VERIFICA SI POSEE O NO CONSTRUCCIONES

                                    ' instancia la clase
                                    Dim obFIPRCONS As New cla_FIPRCONS
                                    Dim dtFIPRCONS As New DataTable

                                    dtFIPRCONS = obFIPRCONS.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(CInt(dtFICHPRED.Rows(ii).Item("FIPRNUFI").ToString))

                                    ' NO POSEE CONSTRUCCIONES
                                    If dtFIPRCONS.Rows.Count = 0 Then

                                        ' instancia la clase
                                        Dim obFIPRIMAG As New cla_FIPRIMAG
                                        Dim dtFIPRIMAG As New DataTable

                                        dtFIPRIMAG = obFIPRIMAG.fun_Buscar_CODIGO_FIPRIMAG(CInt(dtFICHPRED.Rows(ii).Item("FIPRNUFI").ToString), 0, 1)

                                        If dtFIPRIMAG.Rows.Count = 0 Then

                                            ' inserta inconsistencia
                                            dr1 = dt_ValidarTramiteFotografia.NewRow()

                                            dr1("Tipo_Error") = "Severo"
                                            dr1("Nro_Ficha") = CStr(dtFICHPRED.Rows(ii).Item("FIPRNUFI").ToString)
                                            dr1("Nro_Construccion") = "0"
                                            dr1("Nro_Foto") = "1"
                                            dr1("Inconsistencia") = "NO se encuentra registrado la fotografia Nro. 0 Lote"

                                            dt_ValidarTramiteFotografia.Rows.Add(dr1)

                                        End If

                                        ' SI POSEE CONSTRUCCIONES
                                    ElseIf dtFIPRCONS.Rows.Count > 0 Then

                                        ' declara la variable
                                        Dim i2 As Integer = 0

                                        For i2 = 0 To dtFIPRCONS.Rows.Count - 1

                                            ' verifica el estado
                                            If Trim(dtFIPRCONS.Rows(i2).Item("FPCOESTA").ToString) = "ac" Then

                                                ' declara la variable
                                                Dim stFPCODEPA As String = CStr(Trim(dtFIPRCONS.Rows(i2).Item("FPCODEPA").ToString))
                                                Dim stFPCOMUNI As String = CStr(Trim(dtFIPRCONS.Rows(i2).Item("FPCOMUNI").ToString))
                                                Dim inFPCOCLSE As Integer = CInt(dtFIPRCONS.Rows(i2).Item("FPCOCLSE").ToString)
                                                Dim inFPCOCLCO As Integer = CInt(dtFIPRCONS.Rows(i2).Item("FPCOCLCO").ToString)
                                                Dim stFPCOTICO As String = CStr(Trim(dtFIPRCONS.Rows(i2).Item("FPCOTICO").ToString))
                                                Dim inFPCOUNID As Integer = CInt(dtFIPRCONS.Rows(i2).Item("FPCOUNID").ToString)

                                                ' declara la clase
                                                Dim obFOTOTICO As New cla_FOTOTICO
                                                Dim dtFOTOTICO As New DataTable

                                                dtFOTOTICO = obFOTOTICO.fun_Buscar_CODIGO_X_MANT_FOTOTICO(stFPCODEPA, stFPCOMUNI, inFPCOCLSE, inFPCOCLCO, stFPCOTICO)

                                                If dtFOTOTICO.Rows.Count > 0 Then

                                                    ' declara la variable
                                                    Dim i3 As Integer = 0

                                                    For i3 = 0 To dtFOTOTICO.Rows.Count - 1

                                                        ' declaro la variable
                                                        Dim inFOTCCAFO As Integer = CInt(dtFOTOTICO.Rows(i3).Item("FOTCCAFO").ToString)
                                                        Dim stCAFODESC As String = ""

                                                        ' instancia la clase
                                                        Dim obCARPFOTO As New cla_CARPFOTO
                                                        Dim dtCARPFOTO As New DataTable

                                                        dtCARPFOTO = obCARPFOTO.fun_Buscar_CODIGO_MANT_CARPFOTO(inFOTCCAFO)

                                                        If dtCARPFOTO.Rows.Count > 0 Then
                                                            stCAFODESC = CStr(Trim(dtCARPFOTO.Rows(0).Item("CAFODESC").ToString))
                                                        End If

                                                        ' instancia la clase
                                                        Dim obFIPRIMAG As New cla_FIPRIMAG
                                                        Dim dtFIPRIMAG As New DataTable

                                                        dtFIPRIMAG = obFIPRIMAG.fun_Buscar_CODIGO_FIPRIMAG(CInt(dtFICHPRED.Rows(ii).Item("FIPRNUFI").ToString), inFPCOUNID, inFOTCCAFO)

                                                        If dtFIPRIMAG.Rows.Count = 0 Then

                                                            ' inserta inconsistencia
                                                            dr1 = dt_ValidarTramiteFotografia.NewRow()

                                                            dr1("Tipo_Error") = "Severo"
                                                            dr1("Nro_Ficha") = CStr(dtFICHPRED.Rows(ii).Item("FIPRNUFI").ToString)
                                                            dr1("Nro_Construccion") = inFPCOUNID
                                                            dr1("Nro_Foto") = inFOTCCAFO
                                                            dr1("Inconsistencia") = "NO se encuentra registrado la fotografia Nro. " & inFOTCCAFO & " " & stCAFODESC

                                                            dt_ValidarTramiteFotografia.Rows.Add(dr1)

                                                        End If

                                                    Next

                                                End If

                                            End If

                                        Next

                                    End If

                                End If

                                ' Incrementa la barra
                                inProceso = inProceso + 1
                                Me.pbPROCESO.Value = inProceso

                            Next

                        End If

                    Next

                Else
                    ' inserta inconsistencia
                    dr1 = dt_ValidarTramiteFotografia.NewRow()

                    dr1("Tipo_Error") = "Severo"
                    dr1("Nro_Ficha") = ""
                    dr1("Nro_Construccion") = ""
                    dr1("Nro_Foto") = ""
                    dr1("Inconsistencia") = "No existe registro de predios nuevos en movimiento geografico"

                    dt_ValidarTramiteFotografia.Rows.Add(dr1)

                End If

            Else
                ' inserta inconsistencia
                dr1 = dt_ValidarTramiteFotografia.NewRow()

                dr1("Tipo_Error") = "Advertencia"
                dr1("Nro_Ficha") = ""
                dr1("Nro_Construccion") = ""
                dr1("Nro_Foto") = ""
                dr1("Inconsistencia") = "No existe registro en movimiento geografico"

                dt_ValidarTramiteFotografia.Rows.Add(dr1)

            End If

            ' inicia la barra de progreso
            Me.pbPROCESO.Value = 0

            Me.dgvMOGEVALI_2.DataSource = dt_ValidarTramiteFotografia
            Me.dgvMOGEVALI_2.Columns("Inconsistencia").Width = 300

            ' propiedad del boton
            Me.cmdValidarMovimientoGeograficos_2.Enabled = True

            If Me.dgvMOGEVALI_2.RowCount = 0 Then
                mod_MENSAJE.Proceso_Termino_Correctamente()
            Else
                mod_MENSAJE.Proceso_Termino_Con_Inconsistencias()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_EjecutarBotonFinalizar()

        Try
            If Me.dgvTRABCAMP.RowCount > 0 Then
                If Me.dgvLEVANTAMIENTO.RowCount > 0 And Me.dgvDIGITACION.RowCount > 0 And Me.dgvLIQUIDACION.RowCount > 0 Then

                    If MessageBox.Show("¿ Desea finalizar el tramite Nro. " & Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim stRECLOBSE_ACTUAL As String = ""
                        Dim stRECLOBSE_NUEVA As String = " Nota de registro: " & " El usuario: " & vp_usuario & " " & fun_fecha() & " finalizo el tramite. "

                        Dim obRECLGEOG As New cla_TRABCAMP
                        Dim dtRECLGEOG As New DataTable

                        dtRECLGEOG = obRECLGEOG.fun_Buscar_ID_TRABCAMP(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAIDRE").Value.ToString())

                        If dtRECLGEOG.Rows.Count > 0 Then
                            stRECLOBSE_ACTUAL = Trim(dtRECLGEOG.Rows(0).Item("TRCAOBSE").ToString)
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
                        Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAIDRE").Value.ToString())
                        Dim stMOGEESTA As String = "fi"

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update TRABCAMP "
                        ParametrosConsulta += "set TRCAESTA = '" & stMOGEESTA & "', "
                        ParametrosConsulta += "TRCAOBSE = '" & stRECLOBSE_ACTUAL & "'  "
                        ParametrosConsulta += "where TRCAIDRE = '" & inMOGEIDRE & "'  "

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

                        boCONSULTA = True

                        vp_inConsulta = Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAIDRE").Value.ToString()

                        pro_ReconsultarTrabajoDeCampo()
                        pro_ListaDeValoresTrabajoDeCampo()

                        Me.tabMaestro_2.SelectTab(TabObservaciones)

                    End If

                Else
                    MessageBox.Show("El Tramite NO a terminado el ciclo de levantamiento o digitación o liquidación.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                End If

            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EjecutarBotonObservaciones()

        Try
            If Me.dgvTRABCAMP.RowCount > 0 Then

                If MessageBox.Show("¿ Desea ingresar una observación al tramite Nro. " & Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim stObservacionNueva As String = InputBox("Ingrese la observación.", "Mensaje")

                    If Trim(stObservacionNueva) = "" Then
                        MessageBox.Show("Se requiere una observación.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                    Else

                        Dim stRECLOBSE_ACTUAL As String = ""
                        Dim stRECLOBSE_NUEVA As String = Trim(stObservacionNueva.ToString.ToUpper)

                        Dim obMOGEGEOG As New cla_TRABCAMP
                        Dim dtAJUSGEOG As New DataTable

                        dtAJUSGEOG = obMOGEGEOG.fun_Buscar_ID_TRABCAMP(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAIDRE").Value.ToString())

                        If dtAJUSGEOG.Rows.Count > 0 Then
                            stRECLOBSE_ACTUAL = Trim(dtAJUSGEOG.Rows(0).Item("TRCAOBSE").ToString)
                        End If

                        If Trim(stRECLOBSE_ACTUAL) <> "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                            stRECLOBSE_ACTUAL += vbCrLf & " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stRECLOBSE_NUEVA & ". "

                        ElseIf Trim(stRECLOBSE_ACTUAL) = "" And Trim(stRECLOBSE_NUEVA) <> "" Then
                            stRECLOBSE_ACTUAL = " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stRECLOBSE_NUEVA & ". "

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
                        Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAIDRE").Value.ToString())

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update TRABCAMP "
                        ParametrosConsulta += "set TRCAOBSE = '" & stRECLOBSE_ACTUAL & "' "
                        ParametrosConsulta += "where TRCAIDRE = '" & inMOGEIDRE & "' "

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

                        pro_ReconsultarTrabajoDeCampo()
                        pro_ListaDeValoresTrabajoDeCampo()

                        Me.tabMaestro_2.SelectTab(TabObservaciones)

                    End If

                End If
            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_Mensaje01()

        If Me.dgvLEVANTAMIENTO.RowCount = 0 And Me.dgvDIGITACION.RowCount = 0 And Me.dgvLIQUIDACION.RowCount = 0 And Me.dgvARCHIVO.RowCount = 0 Then
            If MessageBox.Show(stMensaje01, "mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Me.cmdMODIFICAR_TRABCAMP.PerformClick()
            End If
        End If

    End Sub
    Private Sub pro_Mensaje02()

        If Me.dgvARCHIVO.RowCount = 1 Then
            If MessageBox.Show(stMensaje01, "mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Me.cmdMODIFICAR_TRABCAMP.PerformClick()
            End If
        End If

    End Sub

#End Region

#Region "PROCEDIMIENTOS METERIAL DE REGISTRO"

    Private Sub pro_ReconsultarMaterialDeRegistro()

        Try
            Dim objdatos As New cla_MATEREGI

            If boCONSULTA = False Then
                Me.BindingSource_MATEREGI_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MATEREGI(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString)
            Else
                Me.BindingSource_MATEREGI_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MATEREGI(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString)
            End If

            Me.dgvMATEREGI.DataSource = Me.BindingSource_MATEREGI_1
            Me.BindingNavigator_MATEREGI_1.BindingSource = Me.BindingSource_MATEREGI_1

            '================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '================================================

            Me.dgvMATEREGI.Columns("MAREIDRE").HeaderText = "idre"
            Me.dgvMATEREGI.Columns("MARESECU").HeaderText = "Secuencia"

            Me.dgvMATEREGI.Columns("MAREMACA").HeaderText = "Código"
            Me.dgvMATEREGI.Columns("MACADESC").HeaderText = "Descripción"
            Me.dgvMATEREGI.Columns("MAREFECH").HeaderText = "Fecha"
            Me.dgvMATEREGI.Columns("MAREOBSE").HeaderText = "Observación"

            Me.dgvMATEREGI.Columns("MAREIDRE").Visible = False
            Me.dgvMATEREGI.Columns("MARESECU").Visible = False
            Me.dgvMATEREGI.Columns("MAREOBSE").Visible = False

            Me.dgvMATEREGI.Columns("MAREMACA").Width = 30
            Me.dgvMATEREGI.Columns("MACADESC").Width = 100
            Me.dgvMATEREGI.Columns("MAREFECH").Width = 100

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MATEREGI_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            'pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MATEREGI_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MATEREGI.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MATEREGI.Enabled = boCONTMODI
            Me.cmdELIMINAR_MATEREGI.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MATEREGI.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MATEREGI.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresMaterialDeRegistro()

        Try
            If Me.dgvMATEREGI.RowCount = 0 Then

                pro_LimpiarMaterialRegistro()

            End If

            Dim objdatos As New cla_TRCAOBMR
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TRCAOBMR(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString)

            If tbl.Rows.Count > 0 Then
                Me.txtMAREOBSE.Text = Trim(tbl.Rows(0).Item("TCMROBSE"))
            Else
                Me.txtMAREOBSE.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarMaterialRegistro()

        Me.txtMAREOBSE.Text = ""

        'Me.dgvMATEREGI.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS INFORMACION DE USUARIO"

    Private Sub pro_ReconsultarInformacionDeUsuario()

        Try
            Dim objdatos As New cla_INFOUSUA

            If boCONSULTA = False Then
                Me.BindingSource_INFOUSUA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_INFOUSUA(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString)
            Else
                Me.BindingSource_INFOUSUA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_INFOUSUA(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString)
            End If

            Me.BindingNavigator_INFOUSUA_1.BindingSource = Me.BindingSource_INFOUSUA_1

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_INFOUSUA_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            'pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_INFOUSUA_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_INFOUSUA.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_INFOUSUA.Enabled = boCONTMODI
            Me.cmdELIMINAR_INFOUSUA.Enabled = boCONTELIM
            Me.cmdCONSULTAR_INFOUSUA.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_INFOUSUA.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresInformacionDeUsuario()

        Try
            If Me.BindingSource_INFOUSUA_1.Count > 0 Then

                Dim objdatos As New cla_INFOUSUA
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_INFOUSUA(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString)

                If tbl.Rows.Count > 0 Then

                    Me.txtINUSNUDO.Text = Trim(tbl.Rows(0).Item("INUSNUDO"))
                    Me.txtINUSFERE.Text = Trim(tbl.Rows(0).Item("INUSFERE"))
                    Me.txtINUSNOMB.Text = Trim(tbl.Rows(0).Item("INUSNOMB"))
                    Me.txtINUSPRAP.Text = Trim(tbl.Rows(0).Item("INUSPRAP"))
                    Me.txtINUSSEAP.Text = Trim(tbl.Rows(0).Item("INUSSEAP"))
                    Me.txtINUSTEL1.Text = Trim(tbl.Rows(0).Item("INUSTEL1"))
                    Me.txtINUSTEL2.Text = Trim(tbl.Rows(0).Item("INUSTEL2"))
                    Me.txtINUSDIRE.Text = Trim(tbl.Rows(0).Item("INUSDIRE"))
                    Me.txtINUSOBSE.Text = Trim(tbl.Rows(0).Item("INUSOBSE"))

                End If

            Else
                pro_LimpiarInformacionUsuario()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarInformacionUsuario()

        Me.txtINUSNUDO.Text = ""
        Me.txtINUSFERE.Text = ""
        Me.txtINUSNOMB.Text = ""
        Me.txtINUSPRAP.Text = ""
        Me.txtINUSSEAP.Text = ""
        Me.txtINUSTEL1.Text = ""
        Me.txtINUSTEL2.Text = ""
        Me.txtINUSDIRE.Text = ""
        Me.txtINUSOBSE.Text = ""

    End Sub

#End Region

#Region "PROCEDIMIENTOS METERIAL DE USUARIO"

    Private Sub pro_ReconsultarMaterialDeUsuario()

        Try
            Dim objdatos As New cla_MATEUSUA

            If boCONSULTA = False Then
                Me.BindingSource_MATEUSUA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MATEUSUA(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString)
            Else
                Me.BindingSource_MATEUSUA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MATEUSUA(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString)
            End If

            Me.dgvMATEUSUA.DataSource = Me.BindingSource_MATEUSUA_1
            Me.BindingNavigator_MATEUSUA_1.BindingSource = Me.BindingSource_MATEUSUA_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvMATEUSUA.Columns("MAUSIDRE").HeaderText = "idre"
            Me.dgvMATEUSUA.Columns("MAUSSECU").HeaderText = "Secuencia"

            Me.dgvMATEUSUA.Columns("MAUSMACA").HeaderText = "Código"
            Me.dgvMATEUSUA.Columns("MACADESC").HeaderText = "Descripción"
            Me.dgvMATEUSUA.Columns("MAUSFECH").HeaderText = "Fecha"
            Me.dgvMATEUSUA.Columns("MAUSOBSE").HeaderText = "Observación"

            Me.dgvMATEUSUA.Columns("MAUSIDRE").Visible = False
            Me.dgvMATEUSUA.Columns("MAUSSECU").Visible = False
            Me.dgvMATEUSUA.Columns("MAUSOBSE").Visible = False

            Me.dgvMATEUSUA.Columns("MAUSMACA").Width = 30
            Me.dgvMATEUSUA.Columns("MACADESC").Width = 100
            Me.dgvMATEUSUA.Columns("MAUSFECH").Width = 100

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MATEUSUA_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            If Me.BindingSource_INFOUSUA_1.Count > 0 Then
                'pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
                pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MATEUSUA_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
            End If

            Me.cmdAGREGAR_MATEUSUA.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MATEUSUA.Enabled = boCONTMODI
            Me.cmdELIMINAR_MATEUSUA.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MATEUSUA.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MATEUSUA.Enabled = boCONTRECO


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresMaterialDeUsuario()

        Try
            If Me.dgvMATEUSUA.RowCount = 0 Then

                pro_LimpiarMaterialUsuario()

            End If

            Dim objdatos As New cla_TRCAOBME
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TRCAOBME(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString)

            If tbl.Rows.Count > 0 Then
                Me.txtMAUSOBSE.Text = Trim(tbl.Rows(0).Item("TCMEOBSE"))
            Else
                Me.txtMAUSOBSE.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarMaterialUsuario()

        Me.txtMAUSOBSE.Text = ""

        'Me.dgvMATEUSUA.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS METERIAL FALTANTE"

    Private Sub pro_ReconsultarMaterialDeFaltante()

        Try
            Dim objdatos As New cla_MATEFALT

            If boCONSULTA = False Then
                Me.BindingSource_MATEFALT_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MATEFALT(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString)
            Else
                Me.BindingSource_MATEFALT_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MATEFALT(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString)
            End If

            Me.dgvMATEFALT.DataSource = Me.BindingSource_MATEFALT_1
            Me.BindingNavigator_MATEFALT_1.BindingSource = Me.BindingSource_MATEFALT_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvMATEFALT.Columns("MAFAIDRE").HeaderText = "idre"
            Me.dgvMATEFALT.Columns("MAFASECU").HeaderText = "Secuencia"

            Me.dgvMATEFALT.Columns("MAFAMACA").HeaderText = "Código"
            Me.dgvMATEFALT.Columns("MACADESC").HeaderText = "Descripción"
            Me.dgvMATEFALT.Columns("MAFAFECH").HeaderText = "Fecha"
            Me.dgvMATEFALT.Columns("MAFAOBSE").HeaderText = "Observación"

            Me.dgvMATEFALT.Columns("MAFAIDRE").Visible = False
            Me.dgvMATEFALT.Columns("MAFASECU").Visible = False
            Me.dgvMATEFALT.Columns("MAFAOBSE").Visible = False

            Me.dgvMATEFALT.Columns("MAFAMACA").Width = 30
            Me.dgvMATEFALT.Columns("MACADESC").Width = 100
            Me.dgvMATEFALT.Columns("MAFAFECH").Width = 100

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_MATEFALT_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            'pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_MATEFALT_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MATEFALT.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MATEFALT.Enabled = boCONTMODI
            Me.cmdELIMINAR_MATEFALT.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MATEFALT.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MATEFALT.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresMaterialDeFaltante()

        Try
            If Me.dgvMATEFALT.RowCount > 0 Then

                Me.chkMaterialFaltante.Checked = True

            Else
                pro_LimpiarMaterialFaltante()

                Me.chkMaterialFaltante.Checked = False
            End If

            Dim objdatos As New cla_TRCAOBMF
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TRCAOBMF(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString)

            If tbl.Rows.Count > 0 Then
                Me.txtMAFAOBSE.Text = Trim(tbl.Rows(0).Item("TCMFOBSE"))
            Else
                Me.txtMAFAOBSE.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarMaterialFaltante()

        Me.txtMAFAOBSE.Text = ""

        'Me.dgvMATEFALT.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS LEVANTAMIENTO"

    Private Sub pro_ReconsultarLevantamiento()

        Try
            Dim objdatos As New cla_LEVANTAMIENTO

            If boCONSULTA = False Then
                Me.BindingSource_LEVANTAMIENTO_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LEVANTAMIENTO(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString)
            Else
                Me.BindingSource_LEVANTAMIENTO_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LEVANTAMIENTO(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString)
            End If

            Me.dgvLEVANTAMIENTO.DataSource = Me.BindingSource_LEVANTAMIENTO_1
            Me.BindingNavigator_LEVANTAMIENTO_1.BindingSource = Me.BindingSource_LEVANTAMIENTO_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvLEVANTAMIENTO.Columns("LEVAIDRE").HeaderText = "idre"
            Me.dgvLEVANTAMIENTO.Columns("LEVASECU").HeaderText = "Secuencia"

            Me.dgvLEVANTAMIENTO.Columns("LEVANUDO").HeaderText = "Nro. Documento"
            Me.dgvLEVANTAMIENTO.Columns("USUANOMB").HeaderText = "Nombre(s)"
            Me.dgvLEVANTAMIENTO.Columns("USUAPRAP").HeaderText = "Primer apellido"
            Me.dgvLEVANTAMIENTO.Columns("USUASEAP").HeaderText = "Segundo apellido"
            Me.dgvLEVANTAMIENTO.Columns("LEVAFEEN").HeaderText = "Fecha de asignación"
            Me.dgvLEVANTAMIENTO.Columns("LEVAFERE").HeaderText = "Fecha de finalización"
            Me.dgvLEVANTAMIENTO.Columns("LEVAOBSE").HeaderText = "Observación"

            Me.dgvLEVANTAMIENTO.Columns("LEVAIDRE").Visible = False
            Me.dgvLEVANTAMIENTO.Columns("LEVASECU").Visible = False

            Me.dgvLEVANTAMIENTO.Columns("LEVANUDO").Width = 50
            Me.dgvLEVANTAMIENTO.Columns("USUANOMB").Width = 50
            Me.dgvLEVANTAMIENTO.Columns("USUAPRAP").Width = 50
            Me.dgvLEVANTAMIENTO.Columns("USUASEAP").Width = 50
            Me.dgvLEVANTAMIENTO.Columns("LEVAFEEN").Width = 50
            Me.dgvLEVANTAMIENTO.Columns("LEVAFERE").Width = 50
            Me.dgvLEVANTAMIENTO.Columns("LEVAOBSE").Width = 200

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_LEVANTAMIENTO_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            'pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_LEVANTAMIENTO_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_LEVANTAMIENTO.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_LEVANTAMIENTO.Enabled = boCONTMODI
            Me.cmdELIMINAR_LEVANTAMIENTO.Enabled = boCONTELIM
            Me.cmdCONSULTAR_LEVANTAMIENTO.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_LEVANTAMIENTO.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresLevantamiento()

        Try
            If Me.dgvLEVANTAMIENTO.RowCount = 0 Then

                pro_LimpiarLevantamiento()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarLevantamiento()

        'Me.dgvLEVANTAMIENTO.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS DIGITACION"

    Private Sub pro_ReconsultarDigitacion()

        Try
            Dim objdatos As New cla_DIGITACION

            If boCONSULTA = False Then
                Me.BindingSource_DIGITACION_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_DIGITACION(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString)
            Else
                Me.BindingSource_DIGITACION_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_DIGITACION(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString)
            End If

            Me.dgvDIGITACION.DataSource = Me.BindingSource_DIGITACION_1
            Me.BindingNavigator_DIGITACION_1.BindingSource = Me.BindingSource_DIGITACION_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvDIGITACION.Columns("DIGIIDRE").HeaderText = "idre"
            Me.dgvDIGITACION.Columns("DIGISECU").HeaderText = "Secuencia"

            Me.dgvDIGITACION.Columns("DIGINUDO").HeaderText = "Nro. Documento"
            Me.dgvDIGITACION.Columns("USUANOMB").HeaderText = "Nombre(s)"
            Me.dgvDIGITACION.Columns("USUAPRAP").HeaderText = "Primer apellido"
            Me.dgvDIGITACION.Columns("USUASEAP").HeaderText = "Segundo apellido"
            Me.dgvDIGITACION.Columns("DIGIFEEN").HeaderText = "Fecha de asignación"
            Me.dgvDIGITACION.Columns("DIGIFERE").HeaderText = "Fecha de finalización"
            Me.dgvDIGITACION.Columns("DIGIOBSE").HeaderText = "Observación"

            Me.dgvDIGITACION.Columns("DIGIIDRE").Visible = False
            Me.dgvDIGITACION.Columns("DIGISECU").Visible = False

            Me.dgvDIGITACION.Columns("DIGINUDO").Width = 50
            Me.dgvDIGITACION.Columns("USUANOMB").Width = 50
            Me.dgvDIGITACION.Columns("USUAPRAP").Width = 50
            Me.dgvDIGITACION.Columns("USUASEAP").Width = 50
            Me.dgvDIGITACION.Columns("DIGIFEEN").Width = 50
            Me.dgvDIGITACION.Columns("DIGIFERE").Width = 50
            Me.dgvDIGITACION.Columns("DIGIOBSE").Width = 200

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_DIGITACION_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            'pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_DIGITACION_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_DIGITACION.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_DIGITACION.Enabled = boCONTMODI
            Me.cmdELIMINAR_DIGITACION.Enabled = boCONTELIM
            Me.cmdCONSULTAR_DIGITACION.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_DIGITACION.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresDigitacion()

        Try
            If Me.dgvDIGITACION.RowCount = 0 Then

                pro_LimpiarDigitacion()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarDigitacion()

        'Me.dgvDIGITACION.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS LIQUIDACION"

    Private Sub pro_ReconsultarLiquidacion()

        Try
            Dim objdatos As New cla_LIQUIDACION

            If boCONSULTA = False Then
                Me.BindingSource_LIQUIDACION_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LIQUIDACION(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString)
            Else
                Me.BindingSource_LIQUIDACION_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LIQUIDACION(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString)
            End If

            Me.dgvLIQUIDACION.DataSource = Me.BindingSource_LIQUIDACION_1
            Me.BindingNavigator_LIQUIDACION_1.BindingSource = Me.BindingSource_LIQUIDACION_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvLIQUIDACION.Columns("LIQUIDRE").HeaderText = "idre"
            Me.dgvLIQUIDACION.Columns("LIQUSECU").HeaderText = "Secuencia"

            Me.dgvLIQUIDACION.Columns("LIQUNUDO").HeaderText = "Nro. Documento"
            Me.dgvLIQUIDACION.Columns("USUANOMB").HeaderText = "Nombre(s)"
            Me.dgvLIQUIDACION.Columns("USUAPRAP").HeaderText = "Primer apellido"
            Me.dgvLIQUIDACION.Columns("USUASEAP").HeaderText = "Segundo apellido"
            Me.dgvLIQUIDACION.Columns("LIQUFEEN").HeaderText = "Fecha de asignación"
            Me.dgvLIQUIDACION.Columns("LIQUFERE").HeaderText = "Fecha de finalización"
            Me.dgvLIQUIDACION.Columns("LIQUOBSE").HeaderText = "Observación"

            Me.dgvLIQUIDACION.Columns("LIQUIDRE").Visible = False
            Me.dgvLIQUIDACION.Columns("LIQUSECU").Visible = False

            Me.dgvLIQUIDACION.Columns("LIQUNUDO").Width = 50
            Me.dgvLIQUIDACION.Columns("USUANOMB").Width = 50
            Me.dgvLIQUIDACION.Columns("USUAPRAP").Width = 50
            Me.dgvLIQUIDACION.Columns("USUASEAP").Width = 50
            Me.dgvLIQUIDACION.Columns("LIQUFEEN").Width = 50
            Me.dgvLIQUIDACION.Columns("LIQUFERE").Width = 50
            Me.dgvLIQUIDACION.Columns("LIQUOBSE").Width = 200

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_LIQUIDACION_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            'pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_LIQUIDACION_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_LIQUIDACION.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_LIQUIDACION.Enabled = boCONTMODI
            Me.cmdELIMINAR_LIQUIDACION.Enabled = boCONTELIM
            Me.cmdCONSULTAR_LIQUIDACION.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_LIQUIDACION.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresLiquidacion()

        Try
            If Me.dgvLIQUIDACION.RowCount = 0 Then

                pro_LimpiarLiquidacion()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarLiquidacion()

        'Me.dgvLIQUIDACION.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS ARCHIVO"

    Private Sub pro_ReconsultarArchivo()

        Try
            Dim objdatos As New cla_ARCHIVO

            If boCONSULTA = False Then
                Me.BindingSource_ARCHIVO_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_ARCHIVO(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString)
            Else
                Me.BindingSource_ARCHIVO_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_ARCHIVO(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString)
            End If

            Me.dgvARCHIVO.DataSource = Me.BindingSource_ARCHIVO_1
            Me.BindingNavigator_ARCHIVO_1.BindingSource = Me.BindingSource_ARCHIVO_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvARCHIVO.Columns("ARCHIDRE").HeaderText = "idre"
            Me.dgvARCHIVO.Columns("ARCHSECU").HeaderText = "Secuencia"

            Me.dgvARCHIVO.Columns("ARCHNUDO").HeaderText = "Nro. Documento"
            Me.dgvARCHIVO.Columns("USUANOMB").HeaderText = "Nombre(s)"
            Me.dgvARCHIVO.Columns("USUAPRAP").HeaderText = "Primer apellido"
            Me.dgvARCHIVO.Columns("USUASEAP").HeaderText = "Segundo apellido"
            Me.dgvARCHIVO.Columns("ARCHFEEN").HeaderText = "Fecha de asignación"
            Me.dgvARCHIVO.Columns("ARCHFERE").HeaderText = "Fecha de finalización"
            Me.dgvARCHIVO.Columns("ARCHOBSE").HeaderText = "Observación"

            Me.dgvARCHIVO.Columns("ARCHIDRE").Visible = False
            Me.dgvARCHIVO.Columns("ARCHSECU").Visible = False

            Me.dgvARCHIVO.Columns("ARCHNUDO").Width = 50
            Me.dgvARCHIVO.Columns("USUANOMB").Width = 50
            Me.dgvARCHIVO.Columns("USUAPRAP").Width = 50
            Me.dgvARCHIVO.Columns("USUASEAP").Width = 50
            Me.dgvARCHIVO.Columns("ARCHFEEN").Width = 50
            Me.dgvARCHIVO.Columns("ARCHFERE").Width = 50
            Me.dgvARCHIVO.Columns("ARCHOBSE").Width = 200

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_ARCHIVO_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            'pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_ARCHIVO_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_ARCHIVO.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_ARCHIVO.Enabled = boCONTMODI
            Me.cmdELIMINAR_ARCHIVO.Enabled = boCONTELIM
            Me.cmdCONSULTAR_ARCHIVO.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_ARCHIVO.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresArchivo()

        Try
            If Me.dgvARCHIVO.RowCount = 0 Then

                pro_LimpiarArchivo()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarArchivo()

        'Me.dgvARCHIVO.DataSource = New DataTable

    End Sub

#End Region

#Region "MENU TRABAJO DE CAMPO"

    Private Sub cmdAGREGAR_TRABCAMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_TRABCAMP.Click

        Try
            If Me.dgvTRABCAMP.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_TRABCAMP(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells(0).Value.ToString()))
                frm_insertar.ShowDialog()
            Else
                frm_insertar_TRABCAMP.ShowDialog()
            End If

            If vp_inConsulta <> 0 Then
                boCONSULTA = True

                pro_ReconsultarTrabajoDeCampo()
                pro_ListaDeValoresTrabajoDeCampo()

                If MessageBox.Show("¿ Desea agregar el material aportado ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Me.tabINSCFICHPRED.SelectTab(TabMATEREGI)
                    Me.cmdAGREGAR_MATEREGI.PerformClick()
                End If
            Else
                Me.tabINSCFICHPRED.SelectTab(TabMATEREGI)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_TRABCAMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_TRABCAMP.Click

        Try
            Dim frm_modificar As New frm_modificar_TRABCAMP(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True

                pro_ReconsultarTrabajoDeCampo()
                pro_ListaDeValoresTrabajoDeCampo()

            End If

            Me.tabINSCFICHPRED.SelectTab(TabMATEREGI)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_TRABCAMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_TRABCAMP.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_TRABCAMP

                If objdatos.fun_Eliminar_IDRE_TRABCAMP(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells(0).Value.ToString())) Then

                    boCONSULTA = False
                    pro_LimpiarCamposTrabajoDeCampo()
                    pro_ReconsultarTrabajoDeCampo()
                    pro_ListaDeValoresTrabajoDeCampo()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_TRABCAMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_TRABCAMP.Click

        Try
            vp_inConsulta = 0

            If Me.dgvTRABCAMP.RowCount > 0 Then
                Dim frm_consultar As New frm_consultar_TRABCAMP(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells(0).Value.ToString()))
                frm_consultar.ShowDialog()
            Else
                Dim frm_consultar As New frm_consultar_TRABCAMP()
                frm_consultar.ShowDialog()
            End If

            If vp_inConsulta <> 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_LimpiarCamposTrabajoDeCampo()
            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()

            Me.tabINSCFICHPRED.SelectTab(TabMATEREGI)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTA_FUNCIONARIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTA_FUNCIONARIO.Click

        Try
            vp_inConsulta = 0

            frm_consultar_funcionario_TRABCAMP.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()

            Me.tabINSCFICHPRED.SelectTab(TabMATEREGI)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_TRABCAMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_TRABCAMP.Click

        Try
            If Me.dgvTRABCAMP.RowCount > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_LimpiarCamposTrabajoDeCampo()
            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()

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
            If Me.dgvTRABCAMP.RowCount > 0 Then

                Dim frm_inserta_archivo As New frm_insertar_archivo_TRABCAMP(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAMUNI").Value.ToString(), _
                                                                             Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACORR").Value.ToString(), _
                                                                             Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCABARR").Value.ToString(), _
                                                                             Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAMANZ").Value.ToString(), _
                                                                             Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAPRED").Value.ToString(), _
                                                                             Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCACLSE").Value.ToString(), _
                                                                             Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCAVIGE").Value.ToString())
                frm_inserta_archivo.ShowDialog()

                pro_ListadoArchivosDocumentos()

                Me.tabMaestro_2.SelectTab(TabDocumentos)

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
    Private Sub cmdFINALIZAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFinalizar.Click
        pro_EjecutarBotonFinalizar()
    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel_1.Click

        Try

            If Me.dgvMOGEVALI_1.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvMOGEVALI_1.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdExportarExcel_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel_2.Click

        Try

            If Me.dgvMOGEVALI_2.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvMOGEVALI_2.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdValidarMovimientoGeograficos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValidarMovimientoGeograficos_1.Click
        pro_ValidarTramiteDocumentosMovimientosGeograficos()
    End Sub
    Private Sub cmdValidarMovimientoGeograficos_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValidarMovimientoGeograficos_2.Click
        pro_ValidarTramiteFotografiaMovimientosGeograficos()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Try
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        Try
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click

        Try
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click

        Try
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU MATERIAL REGISTRO"

    Private Sub cmdAGREGAR_MATEREGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MATEREGI.Click

        Try
            Dim frm_modificar As New frm_insertar_MATEREGI(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString()), Me.Name)
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarMaterialDeRegistro()
            pro_ListaDeValoresMaterialDeRegistro()

            pro_ReconsultarMaterialDeFaltante()
            pro_ListaDeValoresMaterialDeFaltante()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MATEREGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MATEREGI.Click

        Try
            Dim frm_modificar As New frm_insertar_MATEREGI(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString()), Me.Name)
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarMaterialDeRegistro()
            pro_ListaDeValoresMaterialDeRegistro()

            pro_ReconsultarMaterialDeFaltante()
            pro_ListaDeValoresMaterialDeFaltante()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MATEREGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MATEREGI.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MATEREGI

                If objdatos.fun_Eliminar_SECU_X_MACA_MATEREGI(Integer.Parse(Me.dgvMATEREGI.SelectedRows.Item(0).Cells("MARESECU").Value.ToString()), _
                                                              Integer.Parse(Me.dgvMATEREGI.SelectedRows.Item(0).Cells("MAREMACA").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarMaterialRegistro()
                    pro_ReconsultarMaterialDeRegistro()
                    pro_ListaDeValoresMaterialDeRegistro()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_MATEREGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MATEREGI.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_TRABCAMP(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MATEREGI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MATEREGI.Click

        Try
            boCONSULTA = False
            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click

        Try
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click

        Try
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton12.Click

        Try
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton13.Click

        Try
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU INFORMACION DE USUARIO"

    Private Sub cmdAGREGAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_INFOUSUA.Click

        Try
            Dim frm_modificar As New frm_insertar_INFOUSUA(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarInformacionDeUsuario()
            pro_ListaDeValoresInformacionDeUsuario()

            pro_ReconsultarMaterialDeUsuario()
            pro_ListaDeValoresMaterialDeUsuario()

            If MessageBox.Show("¿ Desea agregar el material aportado por el usuario ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Me.tabINSCFICHPRED.SelectTab(TabMATEUSUA)
                Me.cmdAGREGAR_MATEUSUA.PerformClick()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_INFOUSUA.Click

        Try
            Dim frm_modificar As New frm_insertar_INFOUSUA(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarInformacionDeUsuario()
            pro_ListaDeValoresInformacionDeUsuario()

            pro_ReconsultarMaterialDeUsuario()
            pro_ListaDeValoresMaterialDeUsuario()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_INFOUSUA.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_INFOUSUA

                If objdatos.fun_Eliminar_SECU_INFOUSUA(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarInformacionUsuario()
                    pro_ReconsultarInformacionDeUsuario()
                    pro_ListaDeValoresInformacionDeUsuario()

                    If Me.dgvMATEUSUA.RowCount > 0 Then

                        Dim objdatos1 As New cla_MATEUSUA
                        objdatos1.fun_Eliminar_SECU_MATEUSUA(Integer.Parse(Me.dgvMATEUSUA.SelectedRows.Item(0).Cells("MAUSSECU").Value.ToString()))

                    End If

                    pro_LimpiarMaterialUsuario()
                    pro_ReconsultarMaterialDeUsuario()
                    pro_ListaDeValoresMaterialDeUsuario()

                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_INFOUSUA.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_TRABCAMP(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_INFOUSUA.Click

        Try
            boCONSULTA = False
            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub ToolStripButton64_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton64.Click
        pro_ListaDeValoresInformacionDeUsuario()
    End Sub
    Private Sub ToolStripButton65_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton65.Click
        pro_ListaDeValoresInformacionDeUsuario()
    End Sub
    Private Sub ToolStripButton66_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton66.Click
        pro_ListaDeValoresInformacionDeUsuario()
    End Sub
    Private Sub ToolStripButton67_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton67.Click
        pro_ListaDeValoresInformacionDeUsuario()
    End Sub

#End Region

#Region "MENU MATERIAL USUARIO"

    Private Sub cmdAGREGAR_MATEUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MATEUSUA.Click

        Try
            Dim frm_modificar As New frm_insertar_MATEUSUA(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString()), Me.Name)
            frm_modificar.ShowDialog()

            boCONSULTA = False

            pro_ReconsultarMaterialDeUsuario()
            pro_ListaDeValoresMaterialDeUsuario()

            pro_ReconsultarMaterialDeFaltante()
            pro_ListaDeValoresMaterialDeFaltante()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MATEUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MATEUSUA.Click

        Try
            Dim frm_modificar As New frm_insertar_MATEUSUA(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString()), Me.Name)
            frm_modificar.ShowDialog()

            boCONSULTA = False

            pro_ReconsultarMaterialDeUsuario()
            pro_ListaDeValoresMaterialDeUsuario()

            pro_ReconsultarMaterialDeFaltante()
            pro_ListaDeValoresMaterialDeFaltante()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MATEUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MATEUSUA.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MATEUSUA

                If objdatos.fun_Eliminar_SECU_X_MACA_MATEUSUA(Integer.Parse(Me.dgvMATEUSUA.SelectedRows.Item(0).Cells("MAUSSECU").Value.ToString()), _
                                                              Integer.Parse(Me.dgvMATEUSUA.SelectedRows.Item(0).Cells("MAUSMACA").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarMaterialUsuario()
                    pro_ReconsultarMaterialDeUsuario()
                    pro_ListaDeValoresMaterialDeUsuario()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_MATEUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MATEUSUA.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_TRABCAMP(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MATEUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MATEUSUA.Click

        Try
            boCONSULTA = False
            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub ToolStripButton55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton55.Click
        pro_ListaDeValoresMaterialDeUsuario()
    End Sub
    Private Sub ToolStripButton56_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton56.Click
        pro_ListaDeValoresMaterialDeUsuario()
    End Sub
    Private Sub ToolStripButton57_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton57.Click
        pro_ListaDeValoresMaterialDeUsuario()
    End Sub
    Private Sub ToolStripButton58_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton58.Click
        pro_ListaDeValoresMaterialDeUsuario()
    End Sub

#End Region

#Region "MENU MATERIAL FALTANTE"

    Private Sub cmdAGREGAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MATEFALT.Click

        Try
            Dim frm_modificar As New frm_insertar_MATEFALT(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString()), Me.Name)
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarMaterialDeFaltante()
            pro_ListaDeValoresMaterialDeFaltante()

            pro_ReconsultarMaterialDeRegistro()
            pro_ListaDeValoresMaterialDeRegistro()

            pro_ReconsultarMaterialDeUsuario()
            pro_ListaDeValoresMaterialDeUsuario()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MATEFALT.Click

        Try
            Dim frm_modificar As New frm_insertar_MATEFALT(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString()), Me.Name)
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarMaterialDeFaltante()
            pro_ListaDeValoresMaterialDeFaltante()

            pro_ReconsultarMaterialDeRegistro()
            pro_ListaDeValoresMaterialDeRegistro()

            pro_ReconsultarMaterialDeUsuario()
            pro_ListaDeValoresMaterialDeUsuario()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MATEFALT.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_MATEFALT

                If objdatos.fun_Eliminar_SECU_X_MACA_MATEFALT(Integer.Parse(Me.dgvMATEFALT.SelectedRows.Item(0).Cells("MAFASECU").Value.ToString()), _
                                                              Integer.Parse(Me.dgvMATEFALT.SelectedRows.Item(0).Cells("MAFAMACA").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarMaterialFaltante()
                    pro_ReconsultarMaterialDeFaltante()
                    pro_ListaDeValoresMaterialDeFaltante()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MATEFALT.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_TRABCAMP(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MATEFALT.Click

        Try
            boCONSULTA = False
            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub ToolStripButton82_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton82.Click

        Try
            pro_ListaDeValoresMaterialDeFaltante()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton83_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton83.Click

        Try
            pro_ListaDeValoresMaterialDeFaltante()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton84_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton84.Click

        Try
            pro_ListaDeValoresMaterialDeFaltante()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton85_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton85.Click

        Try
            pro_ListaDeValoresMaterialDeFaltante()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU LEVANTAMIENTO"

    Private Sub cmdAGREGAR_LEVANTAMIENTO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_LEVANTAMIENTO.Click

        Try
            Dim frm_modificar As New frm_insertar_LEVANTAMIENTO(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_Mensaje01()

            pro_ReconsultarLevantamiento()
            pro_ListaDeValoresLevantamiento()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_LEVANTAMIENTO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_LEVANTAMIENTO.Click

        Try
            Dim frm_modificar As New frm_insertar_LEVANTAMIENTO(Integer.Parse(Me.dgvLEVANTAMIENTO.SelectedRows.Item(0).Cells("LEVAIDRE").Value.ToString()), _
                                                                Integer.Parse(Me.dgvLEVANTAMIENTO.SelectedRows.Item(0).Cells("LEVASECU").Value.ToString()), _
                                                                Me.dgvLEVANTAMIENTO.SelectedRows.Item(0).Cells("LEVANUDO").Value.ToString())
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_Mensaje01()

            pro_ReconsultarLevantamiento()
            pro_ListaDeValoresLevantamiento()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_LEVANTAMIENTO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_LEVANTAMIENTO.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_LEVANTAMIENTO

                If objdatos.fun_Eliminar_IDRE_LEVANTAMIENTO(Integer.Parse(Me.dgvLEVANTAMIENTO.SelectedRows.Item(0).Cells("LEVAIDRE").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarLevantamiento()
                    pro_ReconsultarLevantamiento()
                    pro_ListaDeValoresLevantamiento()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_LEVANTAMIENTO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_LEVANTAMIENTO.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_TRABCAMP(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_LEVANTAMIENTO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_LEVANTAMIENTO.Click

        Try
            boCONSULTA = False
            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub ToolStripButton19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton19.Click

        Try
            pro_ListaDeValoresLevantamiento()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton20.Click

        Try
            pro_ListaDeValoresLevantamiento()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton21.Click

        Try
            pro_ListaDeValoresLevantamiento()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton22.Click

        Try
            pro_ListaDeValoresLevantamiento()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU DIGITACION"

    Private Sub cmdAGREGAR_DIGITACION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_DIGITACION.Click

        Try
            Dim frm_modificar As New frm_insertar_DIGITACION(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_Mensaje01()

            pro_ReconsultarDigitacion()
            pro_ListaDeValoresDigitacion()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_DIGITACION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_DIGITACION.Click

        Try
            Dim frm_modificar As New frm_insertar_DIGITACION(Integer.Parse(Me.dgvDIGITACION.SelectedRows.Item(0).Cells("DIGIIDRE").Value.ToString()), _
                                                                Integer.Parse(Me.dgvDIGITACION.SelectedRows.Item(0).Cells("DIGISECU").Value.ToString()), _
                                                                Me.dgvDIGITACION.SelectedRows.Item(0).Cells("DIGINUDO").Value.ToString())
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_Mensaje01()

            pro_ReconsultarDigitacion()
            pro_ListaDeValoresDigitacion()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_DIGITACION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_DIGITACION.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_DIGITACION

                If objdatos.fun_Eliminar_IDRE_DIGITACION(Integer.Parse(Me.dgvDIGITACION.SelectedRows.Item(0).Cells("DIGIIDRE").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarDigitacion()
                    pro_ReconsultarDigitacion()
                    pro_ListaDeValoresDigitacion()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_DIGITACION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_DIGITACION.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_TRABCAMP(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_DIGITACION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_DIGITACION.Click

        Try
            boCONSULTA = False
            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU LIQUIDACION"

    Private Sub cmdAGREGAR_LIQUIDACION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_LIQUIDACION.Click

        Try
            Dim frm_modificar As New frm_insertar_LIQUIDACION(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_Mensaje01()

            pro_ReconsultarLiquidacion()
            pro_ListaDeValoresLiquidacion()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_LIQUIDACION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_LIQUIDACION.Click

        Try
            Dim frm_modificar As New frm_insertar_LIQUIDACION(Integer.Parse(Me.dgvLIQUIDACION.SelectedRows.Item(0).Cells("LIQUIDRE").Value.ToString()), _
                                                                Integer.Parse(Me.dgvLIQUIDACION.SelectedRows.Item(0).Cells("LIQUSECU").Value.ToString()), _
                                                                Me.dgvLIQUIDACION.SelectedRows.Item(0).Cells("LIQUNUDO").Value.ToString())
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_Mensaje01()

            pro_ReconsultarLiquidacion()
            pro_ListaDeValoresLiquidacion()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_LIQUIDACION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_LIQUIDACION.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_LIQUIDACION

                If objdatos.fun_Eliminar_IDRE_LIQUIDACION(Integer.Parse(Me.dgvLIQUIDACION.SelectedRows.Item(0).Cells("LIQUIDRE").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarLiquidacion()
                    pro_ReconsultarLiquidacion()
                    pro_ListaDeValoresLiquidacion()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_LIQUIDACION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_LIQUIDACION.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_TRABCAMP(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_LIQUIDACION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_LIQUIDACION.Click

        Try
            boCONSULTA = False
            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU ARCHIVO"

    Private Sub cmdAGREGAR_ARCHIVO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_ARCHIVO.Click

        Try
            Dim frm_modificar As New frm_insertar_ARCHIVO(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarArchivo()
            pro_ListaDeValoresArchivo()
            pro_ListaDeValoresTrabajoDeCampo()

            pro_Mensaje02()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_ARCHIVO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_ARCHIVO.Click

        Try
            Dim frm_modificar As New frm_insertar_ARCHIVO(Integer.Parse(Me.dgvARCHIVO.SelectedRows.Item(0).Cells("ARCHIDRE").Value.ToString()), _
                                                                Integer.Parse(Me.dgvARCHIVO.SelectedRows.Item(0).Cells("ARCHSECU").Value.ToString()), _
                                                                Me.dgvARCHIVO.SelectedRows.Item(0).Cells("ARCHNUDO").Value.ToString())
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarArchivo()
            pro_ListaDeValoresArchivo()
            pro_ListaDeValoresTrabajoDeCampo()

            pro_Mensaje02()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_ARCHIVO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_ARCHIVO.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_ARCHIVO

                If objdatos.fun_Eliminar_IDRE_ARCHIVO(Integer.Parse(Me.dgvARCHIVO.SelectedRows.Item(0).Cells("ARCHIDRE").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarArchivo()
                    pro_ReconsultarArchivo()
                    pro_ListaDeValoresArchivo()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_ARCHIVO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_ARCHIVO.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_TRABCAMP(Integer.Parse(Me.dgvTRABCAMP.SelectedRows.Item(0).Cells("TRCASECU").Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_ARCHIVO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_ARCHIVO.Click

        Try
            boCONSULTA = False
            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_TRABCAMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_ReconsultarTrabajoDeCampo()
        Me.strBARRESTA.Items(0).Text = "Trabajo de campo"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_TRABCAMP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValoresTrabajoDeCampo()
        Me.tabMaestro_2.SelectTab(TabInformación)
    End Sub
    Private Sub dgvTRABCAMP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvTRABCAMP.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvTRABCAMP.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvTRABCAMP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTRABCAMP.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================


        If e.KeyCode = Keys.F2 Then
            If Me.cmdAGREGAR_TRABCAMP.Enabled = True Then
                Me.cmdAGREGAR_TRABCAMP.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If Me.cmdMODIFICAR_TRABCAMP.Enabled = True Then
                Me.cmdMODIFICAR_TRABCAMP.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_TRABCAMP_1.Count

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
            If Me.cmdELIMINAR_TRABCAMP.Enabled = True Then
                Me.cmdELIMINAR_TRABCAMP.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_TRABCAMP_1.Count

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
            If Me.cmdCONSULTAR_TRABCAMP.Enabled = True Then
                Me.cmdCONSULTAR_TRABCAMP.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If Me.cmdCONSULTAR_TRABCAMP.Enabled = True Then
                Me.cmdRECONSULTAR_TRABCAMP.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvALUMPUBL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvTRABCAMP.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresTrabajoDeCampo()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvALUMPUBL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTRABCAMP.CellClick
        pro_ListaDeValoresTrabajoDeCampo()
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