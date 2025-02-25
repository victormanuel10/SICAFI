Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_RECLAMOS

    '=======================
    '*** RECTIFICACIONES ***
    '=======================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False

    Dim stMensaje01 As String = "¿ Desea cambiar el estado del tramite ? "

    Dim vl_stRutaDocumentos As String = ""
    Dim vl_stRutaImagenes As String = ""
    Dim vl_stRutaResolucion As String = ""

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_RECLAMOS
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_RECLAMOS
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

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(4)

            If tblRutas.Rows.Count > 0 AndAlso Trim(Me.txtREAANUEM.Text) <> "" AndAlso Trim(Me.txtREAAFEEM.Text).ToString.Length = 10 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' directorio expediente 
                stCarpetaABuscar = fun_Formato_Mascara_3_String(Trim(Me.txtREAANUEM.Text)) & "-" & fun_Formato_Mascara_4_String(Trim(Me.txtREAAFEEM.Text.ToString.Substring(6, 4)))

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
    Private Function fun_VerificarCarpetaExistenteImagenes() As Boolean

        Try
            Dim stRuta As String = ""
            Dim stCarpetaABuscar As String = ""

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(4)

            If tblRutas.Rows.Count > 0 AndAlso Trim(Me.txtREAANUEM.Text) <> "" AndAlso Trim(Me.txtREAAFEEM.Text).ToString.Length = 10 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' directorio expediente 
                stCarpetaABuscar = fun_Formato_Mascara_3_String(Trim(Me.txtREAANUEM.Text)) & "-" & fun_Formato_Mascara_4_String(Trim(Me.txtREAAFEEM.Text.ToString.Substring(6, 4)))

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
    Private Function fun_VerificarCarpetaExistenteResolucion() As Boolean

        Try
            Dim stRuta As String = ""
            Dim stCarpetaABuscar As String = ""

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(5)

            If tblRutas.Rows.Count > 0 AndAlso Trim(Me.txtREAANURA.Text) <> "" AndAlso Trim(Me.txtREAAFERA.Text).ToString.Length = 10 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' directorio expediente 
                stCarpetaABuscar = Trim(Me.txtREAANURA.Text) & "-" & fun_Formato_Mascara_4_String(Trim(Me.txtREAAFERA.Text.ToString.Substring(6, 4)))

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

#End Region

#Region "PROCEDIMIENTOS RECLAMOS"

    Private Sub pro_ReconsultarReclamos()

        Try
            Dim objdatos As New cla_RECLAMOS

            If boCONSULTA = False Then
                Me.BindingSource_RECLAMOS_1.DataSource = objdatos.fun_Consultar_RECLAMOS
            Else
                Me.BindingSource_RECLAMOS_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLAMOS(vp_inConsulta)
            End If

            Me.dgvRECLAMOS_1.DataSource = BindingSource_RECLAMOS_1
            Me.dgvRECLAMOS_2.DataSource = BindingSource_RECLAMOS_1

            Me.BindingNavigator_RECLAMOS_1.BindingSource = BindingSource_RECLAMOS_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_RECLAMOS_1.Count

            Me.dgvRECLAMOS_1.Columns("RECLIDRE").HeaderText = "Id"
            Me.dgvRECLAMOS_1.Columns("RECLSECU").HeaderText = "Secuencia"

            Me.dgvRECLAMOS_1.Columns("RECLDEPA").HeaderText = "Departamento"
            Me.dgvRECLAMOS_1.Columns("RECLMUNI").HeaderText = "Municipio"
            Me.dgvRECLAMOS_1.Columns("RECLCORR").HeaderText = "Correg."
            Me.dgvRECLAMOS_1.Columns("RECLBARR").HeaderText = "Barrio"
            Me.dgvRECLAMOS_1.Columns("RECLMANZ").HeaderText = "Manzana Vereda"
            Me.dgvRECLAMOS_1.Columns("RECLEDIF").HeaderText = "Edificio"
            Me.dgvRECLAMOS_1.Columns("RECLUNPR").HeaderText = "Unidad Predial"
            Me.dgvRECLAMOS_1.Columns("RECLPRED").HeaderText = "Predio"
            Me.dgvRECLAMOS_1.Columns("CLSEDESC").HeaderText = "Sector"
            Me.dgvRECLAMOS_1.Columns("RECLVIGE").HeaderText = "Vigencia"
            Me.dgvRECLAMOS_1.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvRECLAMOS_2.Columns("RECLNUDO").HeaderText = "Nro documento"
            Me.dgvRECLAMOS_2.Columns("RECLNOMB").HeaderText = "Nombre(s)"
            Me.dgvRECLAMOS_2.Columns("RECLPRAP").HeaderText = "Primer apellido"
            Me.dgvRECLAMOS_2.Columns("RECLSEAP").HeaderText = "Segundo apellido"
            Me.dgvRECLAMOS_2.Columns("RECLMAIN").HeaderText = "Matricula"

            Me.dgvRECLAMOS_1.Columns("RECLIDRE").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLSECU").Visible = False

            Me.dgvRECLAMOS_1.Columns("RECLDEPA").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLRADE").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLFEDE").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLRAMU").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLFEMU").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLRAED").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLFEED").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLRADM").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLFEDM").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLFELC").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLTITR").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLOBSE").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLNUDO").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLNOMB").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLPRAP").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLSEAP").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLMAIN").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLMACA").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLMIAN").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLSOLI").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLESTA").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLCLSE").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLFEMC").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLUSMC").Visible = False
            Me.dgvRECLAMOS_1.Columns("RECLFEIN").Visible = False

            Me.dgvRECLAMOS_2.Columns("RECLIDRE").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLSECU").Visible = False

            Me.dgvRECLAMOS_2.Columns("RECLDEPA").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLMUNI").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLCORR").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLBARR").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLMANZ").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLPRED").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLEDIF").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLUNPR").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLCLSE").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLVIGE").Visible = False
            Me.dgvRECLAMOS_2.Columns("ESTADESC").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLRADE").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLFEDE").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLRAMU").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLFEMU").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLRAED").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLFEED").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLRADM").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLFEDM").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLFELC").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLTITR").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLOBSE").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLMACA").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLMIAN").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLSOLI").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLESTA").Visible = False
            Me.dgvRECLAMOS_2.Columns("CLSEDESC").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLFEMC").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLUSMC").Visible = False
            Me.dgvRECLAMOS_2.Columns("RECLFEIN").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_RECLAMOS_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_RECLAMOS_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_RECLAMOS.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_RECLAMOS.Enabled = boCONTMODI
            Me.cmdELIMINAR_RECLAMOS.Enabled = boCONTELIM
            Me.cmdCONSULTAR_RECLAMOS.Enabled = True
            Me.cmdRECONSULTAR_RECLAMOS.Enabled = boCONTRECO


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresReclamos()

        Try
            If Me.dgvRECLAMOS_1.RowCount > 0 Then

                Dim objdatos As New cla_RECLAMOS
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLAMOS(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLIDRE").Value.ToString)

                If tbl.Rows.Count > 0 Then
                    Me.txtRECLFEMC.Text = Trim(tbl.Rows(0).Item("RECLFEMC").ToString)
                End If

                Me.txtRECLRADE.Text = Trim(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLRADE").Value.ToString)
                Me.txtRECLFEDE.Text = Trim(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLFEDE").Value.ToString)
                Me.txtRECLRAMU.Text = Trim(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLRAMU").Value.ToString)
                Me.txtRECLFEMU.Text = Trim(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLFEMU").Value.ToString)
                Me.txtRECLRAED.Text = Trim(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLRAED").Value.ToString)
                Me.txtRECLFEED.Text = Trim(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLFEED").Value.ToString)
                Me.txtRECLRADM.Text = Trim(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLRADM").Value.ToString)
                Me.txtRECLFEDM.Text = Trim(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLFEDM").Value.ToString)
                Me.txtRECLFELC.Text = Trim(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLFELC").Value.ToString)
                Me.txtRECLTITR.Text = Trim(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLTITR").Value.ToString)
                Me.txtRECLOBSE.Text = Trim(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLOBSE").Value.ToString)

                Me.lblRECLMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLDEPA").Value.ToString, Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLMUNI").Value.ToString), String)
                Me.lblRECLCORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLDEPA").Value.ToString, Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLMUNI").Value.ToString, Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLCLSE").Value.ToString, Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLCORR").Value.ToString), String)

                If CInt(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLCLSE").Value.ToString) = 1 Then
                    Me.lblRECLBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLDEPA").Value.ToString, Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLMUNI").Value.ToString, Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLCLSE").Value.ToString, Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLBARR").Value.ToString, Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLCLSE").Value.ToString) = 2 Then
                    Me.lblRECLBAVE.Text = CType(fun_Buscar_Lista_Valores_VEREDA(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLDEPA").Value.ToString, Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLMUNI").Value.ToString, Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLCLSE").Value.ToString, Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLMANZ").Value.ToString, Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLCLSE").Value.ToString) = 3 Then
                    Me.lblRECLBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLDEPA").Value.ToString, Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLMUNI").Value.ToString, Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLCLSE").Value.ToString, Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLBARR").Value.ToString, Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLCORR").Value.ToString), String)
                End If

                Me.lblRECLTITR.Text = CType(fun_Buscar_Lista_Valores_TIPOTRAM(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLTITR").Value.ToString), String)
                Me.lblRECLSOLI.Text = CType(fun_Buscar_Lista_Valores_SOLICITANTE(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSOLI").Value.ToString), String)

                Me.txtRECLMACA.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Trim(tbl.Rows(0).Item("RECLMACA"))), String)

                If Trim(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLESTA").Value.ToString) = "fi" Then
                    Me.cmdFinalizar.Enabled = False
                Else
                    pro_PermisoControlDeComandos()
                End If

                pro_ReconsultarPrediosAfectados()
                pro_ListaDeValoresPrediosAfectados()

                pro_ReconsultarInformacionDeUsuario()
                pro_ListaDeValoresInformacionDeUsuario()

                pro_ReconsultarMaterialEntregado()
                pro_ListaDeValoresMaterialEntregado()

                pro_ReconsultarMaterialDeFaltante()
                pro_ListaDeValoresMaterialDeFaltante()

                pro_ReconsultarTrabajoDeCampo()
                pro_ListaDeValoresTrabajoDeCampo()

                pro_ReconsultarTrabajoDeOficina()
                pro_ListaDeValoresTrabajoDeOficina()

                pro_ReconsultarActoAdministrativo()
                pro_ListaDeValoresActoAdministrativo()

                pro_ListadoArchivosDocumentos()
                pro_ListadoArchivosResolucion()

                Me.BindingNavigator_RECLPRAF_1.Enabled = True
                Me.BindingNavigator_RECLINUS_1.Enabled = True
                Me.BindingNavigator_RECLMAEN_1.Enabled = True
                Me.BindingNavigator_RECLMAFA_1.Enabled = True
                Me.BindingNavigator_RECLTRCA_1.Enabled = True
                Me.BindingNavigator_RECLTROF_1.Enabled = True
                Me.BindingNavigator_RECLACAD_1.Enabled = True

            Else
                pro_LimpiarCamposReclamos()
                pro_LimpiarPrediosAfectados()
                pro_LimpiarInformacionUsuario()
                pro_LimpiarMaterialEntregado()
                pro_LimpiarMaterialFaltante()
                pro_LimpiarTrabajoDeCampo()
                pro_LimpiarTrabajoDeOficina()
                pro_LimpiarActoAdministrativo()
                pro_LimpiarDocumentos()

                Me.BindingNavigator_RECLPRAF_1.Enabled = False
                Me.BindingNavigator_RECLINUS_1.Enabled = False
                Me.BindingNavigator_RECLMAEN_1.Enabled = False
                Me.BindingNavigator_RECLMAFA_1.Enabled = False
                Me.BindingNavigator_RECLTRCA_1.Enabled = False
                Me.BindingNavigator_RECLTROF_1.Enabled = False
                Me.BindingNavigator_RECLACAD_1.Enabled = False

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposReclamos()

        Me.lblRECLBAVE.Text = ""
        Me.lblRECLMUNI.Text = ""
        Me.lblRECLCORR.Text = ""
        Me.lblRECLSOLI.Text = ""
        Me.txtRECLRADE.Text = ""
        Me.txtRECLFEDE.Text = ""
        Me.txtRECLRAMU.Text = ""
        Me.txtRECLRAED.Text = ""
        Me.txtRECLRADM.Text = ""
        Me.txtRECLOBSE.Text = ""
        Me.txtRECLMACA.Text = ""
        Me.txtRECLFEMC.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub
    Private Sub pro_PermisoControlDeComandos()

        Try

            Me.cmdFinalizar.Enabled = fun_PermisoControlDeComandos(vp_usuario, Me.Name, Me.cmdFinalizar.Name)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_Mensaje01()

        If Me.dgvRECLTRCA.RowCount = 0 And Me.dgvRECLTROF.RowCount = 0 Then
            If MessageBox.Show(stMensaje01, "mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Me.cmdMODIFICAR_RECLAMOS.PerformClick()
            End If
        End If

    End Sub

    Private Sub pro_EjecutarBotonFinalizar()

        Try
            If Me.dgvRECLAMOS_1.RowCount > 0 Then
                If CStr(Trim(Me.txtREAANURA.Text)) <> "" AndAlso CInt(Me.txtREAANURA.Text) <> 0 Then

                    If MessageBox.Show("¿ Desea finalizar el tramite Nro. " & Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim stRECLOBSE_ACTUAL As String = ""
                        Dim stRECLOBSE_NUEVA As String = " Nota de registro: " & " El usuario: " & vp_usuario & " " & fun_fecha() & " finalizo el tramite. "

                        Dim obRECLGEOG As New cla_RECLAMOS
                        Dim dtRECLGEOG As New DataTable

                        dtRECLGEOG = obRECLGEOG.fun_Buscar_ID_RECLAMOS(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLIDRE").Value.ToString())

                        If dtRECLGEOG.Rows.Count > 0 Then
                            stRECLOBSE_ACTUAL = Trim(dtRECLGEOG.Rows(0).Item("RECLOBSE").ToString)
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
                        Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLIDRE").Value.ToString())
                        Dim stMOGEESTA As String = "fi"

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update RECLAMOS "
                        ParametrosConsulta += "set RECLESTA = '" & stMOGEESTA & "', "
                        ParametrosConsulta += "RECLOBSE = '" & stRECLOBSE_ACTUAL & "'  "
                        ParametrosConsulta += "where RECLIDRE = '" & inMOGEIDRE & "'  "

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

                        vp_inConsulta = Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLIDRE").Value.ToString()

                        pro_ReconsultarReclamos()
                        pro_ListaDeValoresReclamos()

                    End If

                Else
                    MessageBox.Show("El Tramite NO posee en el Acto Administrativo Nro. de Resolución.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    Me.tabMAESTRO_1.SelectTab(TabACTOADMI)
                    Me.txtREAANURA.Focus()

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
            If Me.dgvRECLAMOS_1.RowCount > 0 Then

                If MessageBox.Show("¿ Desea ingresar una observación al tramite Nro. " & Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim stObservacionNueva As String = InputBox("Ingrese la observación.", "Mensaje")

                    If Trim(stObservacionNueva) = "" Then
                        MessageBox.Show("Se requiere una observación.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                    Else

                        Dim stRECLOBSE_ACTUAL As String = ""
                        Dim stRECLOBSE_NUEVA As String = Trim(stObservacionNueva.ToString.ToUpper)

                        Dim obMOGEGEOG As New cla_RECLAMOS
                        Dim dtAJUSGEOG As New DataTable

                        dtAJUSGEOG = obMOGEGEOG.fun_Buscar_ID_RECLAMOS(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLIDRE").Value.ToString())

                        If dtAJUSGEOG.Rows.Count > 0 Then
                            stRECLOBSE_ACTUAL = Trim(dtAJUSGEOG.Rows(0).Item("RECLOBSE").ToString)
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
                        Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLIDRE").Value.ToString())

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update RECLAMOS "
                        ParametrosConsulta += "set RECLOBSE = '" & stRECLOBSE_ACTUAL & "' "
                        ParametrosConsulta += "where RECLIDRE = '" & inMOGEIDRE & "' "

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

                        pro_ReconsultarReclamos()
                        pro_ListaDeValoresReclamos()

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

#End Region

#Region "PROCEDIMIENTOS PREDIOS RELACIONADOS"

    Private Sub pro_ReconsultarPrediosAfectados()

        Try
            Dim objdatos As New cla_RECLPRAF

            If boCONSULTA = False Then
                Me.BindingSource_RECLPRAF_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLPRAF(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString)
            Else
                Me.BindingSource_RECLPRAF_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLPRAF(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString)
            End If

            Me.dgvRECLPRAF.DataSource = Me.BindingSource_RECLPRAF_1
            Me.BindingNavigator_RECLPRAF_1.BindingSource = Me.BindingSource_RECLPRAF_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvRECLPRAF.Columns("REPAIDRE").HeaderText = "idre"
            Me.dgvRECLPRAF.Columns("REPASECU").HeaderText = "Secuencia"

            Me.dgvRECLPRAF.Columns("REPAMUNI").HeaderText = "Municipio"
            Me.dgvRECLPRAF.Columns("REPACORR").HeaderText = "Corregi."
            Me.dgvRECLPRAF.Columns("REPABARR").HeaderText = "Barrio"
            Me.dgvRECLPRAF.Columns("REPAMANZ").HeaderText = "Manzana-Vereda"
            Me.dgvRECLPRAF.Columns("REPAPRED").HeaderText = "Predio"
            Me.dgvRECLPRAF.Columns("REPAEDIF").HeaderText = "Edificio"
            Me.dgvRECLPRAF.Columns("REPAUNPR").HeaderText = "Unidad predial"

            Me.dgvRECLPRAF.Columns("REPAIDRE").Visible = False
            Me.dgvRECLPRAF.Columns("REPASECU").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_RECLPRAF_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            ' pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_RECLPRAF_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_PREDAFEC.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_PREDAFEC.Enabled = boCONTMODI
            Me.cmdELIMINAR_PREDAFEC.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MATEREGI.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MATEREGI.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresPrediosAfectados()

        Try
            If Me.dgvRECLPRAF.RowCount = 0 Then

                pro_LimpiarPrediosAfectados()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarPrediosAfectados()

        'Me.dgvRECLPRAF.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS INFORMACION DE SOLICITANTE"

    Private Sub pro_ReconsultarInformacionDeUsuario()

        Try
            Dim objdatos As New cla_RECLINUS

            If boCONSULTA = False Then
                Me.BindingSource_RECLINUS_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLINUS(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString)
            Else
                Me.BindingSource_RECLINUS_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLINUS(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString)
            End If

            Me.BindingNavigator_RECLINUS_1.BindingSource = Me.BindingSource_RECLINUS_1

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_RECLINUS_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_RECLINUS_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

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
            If Me.BindingSource_RECLINUS_1.Count > 0 Then

                Dim objdatos As New cla_RECLINUS
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLINUS(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString)

                If tbl.Rows.Count > 0 Then

                    Me.txtINUSDIPR.Text = Trim(tbl.Rows(0).Item("REIUDIPR"))
                    Me.txtINUSDINO.Text = Trim(tbl.Rows(0).Item("REIUDINO"))
                    Me.txtINUSTEL1.Text = Trim(tbl.Rows(0).Item("REIUTEL1"))
                    Me.txtINUSTEL2.Text = Trim(tbl.Rows(0).Item("REIUTEL2"))
                    Me.chkINUSACTA.Checked = tbl.Rows(0).Item("REIUACTA")
                    Me.chkINUSACFI.Checked = tbl.Rows(0).Item("REIUACFI")
                    Me.txtINUSNUAC.Text = Trim(tbl.Rows(0).Item("REIUNUAC"))
                    Me.txtINUSNOMB.Text = Trim(tbl.Rows(0).Item("REIUNOMB"))
                    Me.txtINUSPRAP.Text = Trim(tbl.Rows(0).Item("REIUPRAP"))
                    Me.txtINUSSEAP.Text = Trim(tbl.Rows(0).Item("REIUSEAP"))
                    Me.txtINUSTEL1.Text = Trim(tbl.Rows(0).Item("REIUTEL1"))
                    Me.txtINUSTEL2.Text = Trim(tbl.Rows(0).Item("REIUTEL2"))
                    Me.txtINUSFEEN.Text = Trim(tbl.Rows(0).Item("REIUFEEN"))
                    Me.txtINUSFERE.Text = Trim(tbl.Rows(0).Item("REIUFERE"))
                    Me.txtINUSOBSE.Text = Trim(tbl.Rows(0).Item("REIUOBSE"))

                End If

            Else
                pro_LimpiarInformacionUsuario()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarInformacionUsuario()

        Me.txtINUSDIPR.Text = ""
        Me.txtINUSDINO.Text = ""
        Me.txtINUSTEL1.Text = ""
        Me.txtINUSTEL2.Text = ""
        Me.chkINUSACTA.Checked = False
        Me.chkINUSACFI.Checked = False
        Me.txtINUSNUAC.Text = ""
        Me.txtINUSNOMB.Text = ""
        Me.txtINUSPRAP.Text = ""
        Me.txtINUSSEAP.Text = ""
        Me.txtINUSTEL1.Text = ""
        Me.txtINUSTEL2.Text = ""
        Me.txtINUSFEEN.Text = ""
        Me.txtINUSFERE.Text = ""
        Me.txtINUSOBSE.Text = ""

    End Sub

#End Region

#Region "PROCEDIMIENTOS METERIAL ENTREGADO"

    Private Sub pro_ReconsultarMaterialEntregado()

        Try
            Dim objdatos As New cla_RECLMAEN

            If boCONSULTA = False Then
                Me.BindingSource_RECLMAEN_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLMAEN(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString)
            Else
                Me.BindingSource_RECLMAEN_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLMAEN(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString)
            End If

            Me.dgvRECLMAEN.DataSource = Me.BindingSource_RECLMAEN_1
            Me.BindingNavigator_RECLMAEN_1.BindingSource = Me.BindingSource_RECLMAEN_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvRECLMAEN.Columns("REMEIDRE").HeaderText = "idre"
            Me.dgvRECLMAEN.Columns("REMESECU").HeaderText = "Secuencia"

            Me.dgvRECLMAEN.Columns("REMEMACA").HeaderText = "Código"
            Me.dgvRECLMAEN.Columns("MACADESC").HeaderText = "Descripción"
            Me.dgvRECLMAEN.Columns("REMEFECH").HeaderText = "Fecha"
            Me.dgvRECLMAEN.Columns("REMEOBSE").HeaderText = "Observación"

            Me.dgvRECLMAEN.Columns("REMEIDRE").Visible = False
            Me.dgvRECLMAEN.Columns("REMESECU").Visible = False
            Me.dgvRECLMAEN.Columns("REMEOBSE").Visible = False

            Me.dgvRECLMAEN.Columns("REMEMACA").Width = 30
            Me.dgvRECLMAEN.Columns("MACADESC").Width = 100
            Me.dgvRECLMAEN.Columns("REMEFECH").Width = 100

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_RECLMAEN_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_RECLMAEN_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_MATEENTR.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_MATEENTR.Enabled = boCONTMODI
            Me.cmdELIMINAR_MATEENTR.Enabled = boCONTELIM
            Me.cmdCONSULTAR_MATEENTR.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_MATEENTR.Enabled = boCONTRECO


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresMaterialEntregado()

        Try
            If Me.dgvRECLMAEN.RowCount > 0 Then

                pro_ListadoArchivosDocumentos()

            Else
                pro_LimpiarMaterialEntregado()

            End If

            Dim objdatos As New cla_RECLOBME
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLOBME(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString)

            If tbl.Rows.Count > 0 Then
                Me.txtREMEOBSE.Text = Trim(tbl.Rows(0).Item("ROMEOBSE"))
            Else
                Me.txtREMEOBSE.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarMaterialEntregado()

        Me.txtREMEOBSE.Text = ""
        'Me.dgvRECLMAEN.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS METERIAL FALTANTE"

    Private Sub pro_ReconsultarMaterialDeFaltante()

        Try
            Dim objdatos As New cla_RECLMAFA

            If boCONSULTA = False Then
                Me.BindingSource_RECLMAFA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLMAFA(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString)
            Else
                Me.BindingSource_RECLMAFA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLMAFA(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString)
            End If

            Me.dgvRECLMAFA.DataSource = Me.BindingSource_RECLMAFA_1
            Me.BindingNavigator_RECLMAFA_1.BindingSource = Me.BindingSource_RECLMAFA_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvRECLMAFA.Columns("REMFIDRE").HeaderText = "idre"
            Me.dgvRECLMAFA.Columns("REMFSECU").HeaderText = "Secuencia"

            Me.dgvRECLMAFA.Columns("REMFMACA").HeaderText = "Código"
            Me.dgvRECLMAFA.Columns("MACADESC").HeaderText = "Descripción"
            Me.dgvRECLMAFA.Columns("REMFFECH").HeaderText = "Fecha"
            Me.dgvRECLMAFA.Columns("REMFOBSE").HeaderText = "Observación"

            Me.dgvRECLMAFA.Columns("REMFIDRE").Visible = False
            Me.dgvRECLMAFA.Columns("REMFSECU").Visible = False
            Me.dgvRECLMAFA.Columns("REMFOBSE").Visible = False

            Me.dgvRECLMAFA.Columns("REMFMACA").Width = 30
            Me.dgvRECLMAFA.Columns("MACADESC").Width = 100
            Me.dgvRECLMAFA.Columns("REMFFECH").Width = 100

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_RECLMAFA_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_RECLMAFA_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

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
            If Me.dgvRECLMAFA.RowCount > 0 Then

                Me.chkMaterialFaltante.Checked = True

            Else
                pro_LimpiarMaterialFaltante()

                Me.chkMaterialFaltante.Checked = False

            End If

            Dim objdatos As New cla_RECLOBMF
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLOBMF(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString)

            If tbl.Rows.Count > 0 Then
                Me.txtMAFAOBSE.Text = Trim(tbl.Rows(0).Item("ROMFOBSE"))
            Else
                Me.txtMAFAOBSE.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarMaterialFaltante()

        Me.txtMAFAOBSE.Text = ""

        'Me.dgvRECLMAFA.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS TRABAJO DE CAMPO"

    Private Sub pro_ReconsultarTrabajoDeCampo()

        Try
            Dim objdatos As New cla_RECLTRCA

            If boCONSULTA = False Then
                Me.BindingSource_RECLTRCA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLTRCA(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString)
            Else
                Me.BindingSource_RECLTRCA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLTRCA(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString)
            End If

            Me.dgvRECLTRCA.DataSource = Me.BindingSource_RECLTRCA_1
            Me.BindingNavigator_RECLTRCA_1.BindingSource = Me.BindingSource_RECLTRCA_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvRECLTRCA.Columns("RETCIDRE").HeaderText = "idre"
            Me.dgvRECLTRCA.Columns("RETCSECU").HeaderText = "Secuencia"

            Me.dgvRECLTRCA.Columns("RETCNUDO").HeaderText = "Nro. Documento"
            Me.dgvRECLTRCA.Columns("USUANOMB").HeaderText = "Nombre(s)"
            Me.dgvRECLTRCA.Columns("USUAPRAP").HeaderText = "Primer apellido"
            Me.dgvRECLTRCA.Columns("USUASEAP").HeaderText = "Segundo apellido"
            Me.dgvRECLTRCA.Columns("RETCFEEN").HeaderText = "Fecha de entrega"
            Me.dgvRECLTRCA.Columns("RETCOBSE").HeaderText = "Observación"

            Me.dgvRECLTRCA.Columns("RETCIDRE").Visible = False
            Me.dgvRECLTRCA.Columns("RETCSECU").Visible = False

            Me.dgvRECLTRCA.Columns("RETCNUDO").Width = 50
            Me.dgvRECLTRCA.Columns("USUANOMB").Width = 50
            Me.dgvRECLTRCA.Columns("USUAPRAP").Width = 50
            Me.dgvRECLTRCA.Columns("USUASEAP").Width = 50
            Me.dgvRECLTRCA.Columns("RETCFEEN").Width = 50
            Me.dgvRECLTRCA.Columns("RETCOBSE").Width = 200

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_RECLTRCA_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_RECLTRCA_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_LEVANTAMIENTO.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_LEVANTAMIENTO.Enabled = boCONTMODI
            Me.cmdELIMINAR_LEVANTAMIENTO.Enabled = boCONTELIM
            Me.cmdCONSULTAR_LEVANTAMIENTO.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_LEVANTAMIENTO.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresTrabajoDeCampo()

        Try
            If Me.dgvRECLTRCA.RowCount = 0 Then

                pro_LimpiarTrabajoDeCampo()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarTrabajoDeCampo()

        'Me.dgvRECLTRCA.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS TRABAJO DE OFICINA"

    Private Sub pro_ReconsultarTrabajoDeOficina()

        Try
            Dim objdatos As New cla_RECLTROF

            If boCONSULTA = False Then
                Me.BindingSource_TRABOFIC_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLTROF(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString)
            Else
                Me.BindingSource_TRABOFIC_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLTROF(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString)
            End If

            Me.dgvRECLTROF.DataSource = Me.BindingSource_TRABOFIC_1
            Me.BindingNavigator_RECLTROF_1.BindingSource = Me.BindingSource_TRABOFIC_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvRECLTROF.Columns("RETOIDRE").HeaderText = "idre"
            Me.dgvRECLTROF.Columns("RETOSECU").HeaderText = "Secuencia"

            Me.dgvRECLTROF.Columns("RETONUDO").HeaderText = "Nro. Documento"
            Me.dgvRECLTROF.Columns("USUANOMB").HeaderText = "Nombre(s)"
            Me.dgvRECLTROF.Columns("USUAPRAP").HeaderText = "Primer apellido"
            Me.dgvRECLTROF.Columns("USUASEAP").HeaderText = "Segundo apellido"
            Me.dgvRECLTROF.Columns("RETOFEEN").HeaderText = "Fecha de entrega"
            Me.dgvRECLTROF.Columns("RETOOBSE").HeaderText = "Observación"

            Me.dgvRECLTROF.Columns("RETOIDRE").Visible = False
            Me.dgvRECLTROF.Columns("RETOSECU").Visible = False

            Me.dgvRECLTROF.Columns("RETONUDO").Width = 50
            Me.dgvRECLTROF.Columns("USUANOMB").Width = 50
            Me.dgvRECLTROF.Columns("USUAPRAP").Width = 50
            Me.dgvRECLTROF.Columns("USUASEAP").Width = 50
            Me.dgvRECLTROF.Columns("RETOFEEN").Width = 50
            Me.dgvRECLTROF.Columns("RETOOBSE").Width = 200

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_TRABOFIC_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_RECLTROF_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_TRABOFIC.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_TRABOFIC.Enabled = boCONTMODI
            Me.cmdELIMINAR_TRABOFIC.Enabled = boCONTELIM
            Me.cmdCONSULTAR_TRABOFIC.Enabled = boCONTCONS

            Me.cmdRECONSULTAR_TRABOFIC.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresTrabajoDeOficina()

        Try
            If Me.dgvRECLTROF.RowCount = 0 Then

                pro_LimpiarTrabajoDeOficina()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarTrabajoDeOficina()

        'Me.dgvRECLTROF.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS ACTO ADMINISTRATIVO"

    Private Sub pro_ReconsultarActoAdministrativo()

        Try
            Dim objdatos As New cla_RECLACAD

            If boCONSULTA = False Then
                Me.BindingSource_RECLACAD_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLACAD(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString)
            Else
                Me.BindingSource_RECLACAD_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLACAD(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString)
            End If

            Me.BindingNavigator_RECLACAD_1.BindingSource = Me.BindingSource_RECLACAD_1

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_RECLACAD_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_RECLACAD_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_ACTOADMI.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_ACTOADMI.Enabled = boCONTMODI
            Me.cmdELIMINAR_ACTOADMI.Enabled = boCONTELIM
            Me.cmdCONSULTAR_ACTOADMI.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_ACTOADMI.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresActoAdministrativo()

        Try
            If Me.BindingSource_RECLACAD_1.Count > 0 Then

                Dim objdatos As New cla_RECLACAD
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RECLACAD(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString)

                If tbl.Rows.Count > 0 Then

                    Me.txtREAAACAD.Text = CStr(Trim(tbl.Rows(0).Item("REAAACAD")))
                    Me.txtREAATITR.Text = CStr(Trim(tbl.Rows(0).Item("REAATITR")))
                    Me.txtREAANUEM.Text = CStr(Trim(tbl.Rows(0).Item("REAANUEM")))
                    Me.txtREAAFEEM.Text = CStr(Trim(tbl.Rows(0).Item("REAAFEEM")))
                    Me.txtREAANURA.Text = CStr(Trim(tbl.Rows(0).Item("REAANURA")))
                    Me.txtREAAFERA.Text = CStr(Trim(tbl.Rows(0).Item("REAAFERA")))
                    Me.txtREAANURR.Text = CStr(Trim(tbl.Rows(0).Item("REAANURR")))
                    Me.txtREAAFERR.Text = CStr(Trim(tbl.Rows(0).Item("REAAFERR")))
                    Me.txtREAAOBSE.Text = CStr(Trim(tbl.Rows(0).Item("REAAOBSE")))

                    Me.lblREAAACAD.Text = fun_Buscar_Lista_Valores_ACTOADMI(Trim(Me.txtREAAACAD.Text))
                    Me.lblREAATITR.Text = fun_Buscar_Lista_Valores_TIPOTRAM(Trim(Me.txtREAATITR.Text))

                    If Trim(Me.txtREAANUEM.Text) <> "0" And Trim(Me.txtREAANUEM.Text) <> "" Then
                        pro_ListadoArchivosDocumentos()
                    End If

                    If Trim(Me.txtREAANURA.Text) <> "0" And Trim(Me.txtREAANURA.Text) <> "" Then
                        pro_ListadoArchivosDocumentos()
                        pro_ListadoArchivosResolucion()
                    End If

                End If

            Else
                pro_LimpiarActoAdministrativo()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarActoAdministrativo()

        Me.txtREAAACAD.Text = ""
        Me.txtREAATITR.Text = ""
        Me.lblREAAACAD.Text = ""
        Me.lblREAATITR.Text = ""
        Me.txtREAANUEM.Text = ""
        Me.txtREAAFEEM.Text = ""
        Me.txtREAANURA.Text = ""
        Me.txtREAAFERA.Text = ""
        Me.txtREAANURR.Text = ""
        Me.txtREAAFERR.Text = ""
        Me.txtREAAOBSE.Text = ""

    End Sub

#End Region

#Region "PROCEDIMIENTOS DOCUMENTOS"

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

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(4)

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentos() = True Then

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & fun_Formato_Mascara_3_String(Trim(Me.txtREAANUEM.Text)) & "-" & fun_Formato_Mascara_4_String(Trim(Me.txtREAAFEEM.Text.ToString.Substring(6, 4)))

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
    Private Sub pro_ListadoArchivosResolucion()

        Try
            Me.lstLISTADO_RESOLUCION.Items.Clear()

            ' declara la variable
            Dim stRuta As String = ""
            Dim stNewPath As String = ""
            Dim ContentItem As String

            ' instancia la clase
            Dim objRutas As New cla_RUTAS
            Dim tblRutas As New DataTable

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(5)

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteResolucion() = True Then

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.txtREAANURA.Text) & "-" & fun_Formato_Mascara_4_String(Trim(Me.txtREAAFERA.Text.ToString.Substring(6, 4)))

                vl_stRutaResolucion = stNewPath

                ChDir(stNewPath)

                Me.lstLISTADO_RESOLUCION.Items.Clear()

                ContentItem = Dir("*.pdf")

                If ContentItem <> "" Then
                    Me.lstLISTADO_RESOLUCION.Focus()
                End If

                Do Until ContentItem = ""
                    ' agrega a la lista
                    Me.lstLISTADO_RESOLUCION.Items.Add(ContentItem)

                    'desplaza el registro
                    ContentItem = Dir()
                Loop

            Else
                Me.lstLISTADO_RESOLUCION.Items.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarDocumentos()

        Me.lstLISTADO_DOCUMENTOS.Items.Clear()
        Me.lstLISTADO_RESOLUCION.Items.Clear()

    End Sub

#End Region

#Region "MENU RECLAMOS"

    Private Sub cmdAGREGAR_RECLAMOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_RECLAMOS.Click

        Try
            If Me.dgvRECLAMOS_1.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_RECLAMOS(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells(0).Value.ToString()))
                frm_insertar.ShowDialog()
            Else
                frm_insertar_RECLAMOS.ShowDialog()
            End If

            If vp_inConsulta <> 0 Then
                boCONSULTA = True

                pro_ReconsultarReclamos()
                pro_ListaDeValoresReclamos()

                If MessageBox.Show("¿ Desea asignar el trabajo de campo ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Me.tabMAESTRO_1.SelectTab(TabTRABCAMP)
                    Me.cmdAGREGAR_LEVANTAMIENTO.PerformClick()
                End If
            Else
                Me.TabMAESTRO_2.SelectTab(TabInformacion)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_RECLAMOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_RECLAMOS.Click

        Try
            Dim frm_modificar As New frm_modificar_RECLAMOS(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True

                pro_ReconsultarReclamos()
                pro_ListaDeValoresReclamos()

            End If

            Me.TabMAESTRO_2.SelectTab(TabInformacion)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_RECLAMOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_RECLAMOS.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RECLAMOS

                If objdatos.fun_Eliminar_IDRE_RECLAMOS(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells(0).Value.ToString())) Then

                    boCONSULTA = False
                    pro_LimpiarCamposReclamos()
                    pro_ReconsultarReclamos()
                    pro_ListaDeValoresReclamos()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_RECLAMOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_RECLAMOS.Click

        Try
            vp_inConsulta = 0

            If Me.dgvRECLAMOS_1.RowCount > 0 Then
                Dim frm_consultar As New frm_consultar_RECLAMOS(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells(0).Value.ToString()))
                frm_consultar.ShowDialog()
            Else
                Dim frm_consultar As New frm_consultar_RECLAMOS()
                frm_consultar.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarReclamos()
            pro_ListaDeValoresReclamos()

            Me.TabMAESTRO_2.SelectTab(TabInformacion)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_RECLAMOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_RECLAMOS.Click

        Try
            If Me.dgvRECLAMOS_1.RowCount > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarReclamos()
            pro_ListaDeValoresReclamos()

            pro_ListaDeValoresPrediosAfectados()

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
    Private Sub cmdCONSULTA_FUNCIONARIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTA_FUNCIONARIO.Click
        Try
            vp_inConsulta = 0

            frm_consultar_funcionario_RECLAMOS.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarReclamos()
            pro_ListaDeValoresReclamos()

            Me.TabMAESTRO_2.SelectTab(TabInformacion)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdIMPORTAR_DOCUMENTOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIMPORTAR_DOCUMENTOS.Click

        Try
            If Me.dgvRECLAMOS_1.RowCount > 0 Then

                Dim frm_inserta_archivo As New frm_insertar_archivo_RECLAMOS(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString(), _
                                                                             Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLMUNI").Value.ToString(), _
                                                                             Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLCORR").Value.ToString(), _
                                                                             Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLBARR").Value.ToString(), _
                                                                             Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLMANZ").Value.ToString(), _
                                                                             Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLPRED").Value.ToString(), _
                                                                             Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLEDIF").Value.ToString(), _
                                                                             Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLUNPR").Value.ToString(), _
                                                                             Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLCLSE").Value.ToString(), _
                                                                             Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLVIGE").Value.ToString())
                frm_inserta_archivo.ShowDialog()

                pro_ListadoArchivosDocumentos()
                pro_ListadoArchivosResolucion()

            Else
                mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
            End If
         

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub cmdFINALIZAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFinalizar.Click
        pro_EjecutarBotonFinalizar()
    End Sub
    Private Sub cmdOBSERVACIONES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOBSERVACIONES.Click
        pro_EjecutarBotonObservaciones()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Try
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        Try
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click

        Try
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click

        Try
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU PREDIOS AFECTADOS"

    Private Sub cmdAGREGAR_PREDAFEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_PREDAFEC.Click

        Try
            Dim frm_modificar As New frm_insertar_RECLPRAF(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString()))
            frm_modificar.ShowDialog()

            boCONSULTA = False

            pro_ReconsultarPrediosAfectados()
            pro_ListaDeValoresPrediosAfectados()

            Me.tabMAESTRO_1.SelectTab(TabPREDAFEC)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_PREDAFEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_PREDAFEC.Click


        Try
            Dim frm_modificar As New frm_insertar_RECLPRAF(Integer.Parse(Me.dgvRECLPRAF.SelectedRows.Item(0).Cells("REPAIDRE").Value.ToString()), Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString())
            frm_modificar.ShowDialog()

            boCONSULTA = False

            pro_ReconsultarPrediosAfectados()
            pro_ListaDeValoresPrediosAfectados()

            Me.tabMAESTRO_1.SelectTab(TabPREDAFEC)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_PREDAFEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_PREDAFEC.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RECLPRAF

                If objdatos.fun_Eliminar_IDRE_RECLPRAF(Integer.Parse(Me.dgvRECLPRAF.SelectedRows.Item(0).Cells("REPAIDRE").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarPrediosAfectados()
                    pro_ReconsultarPrediosAfectados()
                    pro_ListaDeValoresPrediosAfectados()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

                Me.tabMAESTRO_1.SelectTab(TabPREDAFEC)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_PREDAFEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MATEREGI.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_RECLAMOS(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarReclamos()
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_PREDAFEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MATEREGI.Click

        Try
            boCONSULTA = False
            pro_ReconsultarReclamos()
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click

        Try
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click

        Try
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton12.Click

        Try
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton13.Click

        Try
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU INFORMACION DE USUARIO"

    Private Sub cmdAGREGAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_INFOUSUA.Click

        Try
            Dim frm_modificar As New frm_insertar_RECLINUS(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarInformacionDeUsuario()
            pro_ListaDeValoresInformacionDeUsuario()

            If MessageBox.Show("¿ Desea agregar el material aportado ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Me.tabMaestro_2.SelectTab(TabMATEUSUA)
                Me.cmdAGREGAR_MATEENTR.PerformClick()
            End If

            pro_ReconsultarMaterialEntregado()
            pro_ListaDeValoresMaterialEntregado()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_INFOUSUA.Click

        Try
            Dim frm_modificar As New frm_insertar_RECLINUS(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarInformacionDeUsuario()
            pro_ListaDeValoresInformacionDeUsuario()

            pro_ReconsultarMaterialEntregado()
            pro_ListaDeValoresMaterialEntregado()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_INFOUSUA.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RECLINUS

                If objdatos.fun_Eliminar_SECU_RECLINUS(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarInformacionUsuario()
                    pro_ReconsultarInformacionDeUsuario()
                    pro_ListaDeValoresInformacionDeUsuario()

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

            Dim frm_consultar As New frm_consultar_RECLAMOS(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarReclamos()
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_INFOUSUA.Click

        Try
            boCONSULTA = False
            pro_ReconsultarReclamos()
            pro_ListaDeValoresReclamos()

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

#Region "MENU MATERIAL ENTREGADO"

    Private Sub cmdAGREGAR_MATEENTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MATEENTR.Click

        Try
            Dim frm_modificar As New frm_insertar_RECLMAEN(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString()), Me.Name)
            frm_modificar.ShowDialog()

            boCONSULTA = False

            pro_ReconsultarMaterialEntregado()
            pro_ListaDeValoresMaterialEntregado()

            pro_ReconsultarMaterialDeFaltante()
            pro_ListaDeValoresMaterialDeFaltante()

            pro_ListadoArchivosDocumentos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MATEENTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MATEENTR.Click

        Try
            Dim frm_modificar As New frm_insertar_RECLMAEN(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString()), Me.Name)
            frm_modificar.ShowDialog()

            boCONSULTA = False

            pro_ReconsultarMaterialEntregado()
            pro_ListaDeValoresMaterialEntregado()

            pro_ReconsultarMaterialDeFaltante()
            pro_ListaDeValoresMaterialDeFaltante()

            pro_ListadoArchivosDocumentos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MATEENTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MATEENTR.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RECLMAEN

                If objdatos.fun_Eliminar_SECU_X_MACA_RECLMAEN(Integer.Parse(Me.dgvRECLMAEN.SelectedRows.Item(0).Cells("REMESECU").Value.ToString()), _
                                                              Integer.Parse(Me.dgvRECLMAEN.SelectedRows.Item(0).Cells("REMEMACA").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarMaterialEntregado()
                    pro_ReconsultarMaterialEntregado()
                    pro_ListaDeValoresMaterialEntregado()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_MATEENTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_MATEENTR.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_RECLAMOS(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarReclamos()
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MATEENTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MATEENTR.Click

        Try
            boCONSULTA = False
            pro_ReconsultarReclamos()
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub ToolStripButton55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton55.Click
        pro_ListaDeValoresMaterialEntregado()
    End Sub
    Private Sub ToolStripButton56_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton56.Click
        pro_ListaDeValoresMaterialEntregado()
    End Sub
    Private Sub ToolStripButton57_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton57.Click
        pro_ListaDeValoresMaterialEntregado()
    End Sub
    Private Sub ToolStripButton58_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton58.Click
        pro_ListaDeValoresMaterialEntregado()
    End Sub

#End Region

#Region "MENU MATERIAL FALTANTE"

    Private Sub cmdAGREGAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_MATEFALT.Click

        Try
            Dim frm_modificar As New frm_insertar_RECLMAFA(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString()), Me.Name)
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarMaterialDeFaltante()
            pro_ListaDeValoresMaterialDeFaltante()

            pro_ReconsultarPrediosAfectados()
            pro_ListaDeValoresPrediosAfectados()

            pro_ReconsultarMaterialEntregado()
            pro_ListaDeValoresMaterialEntregado()

            pro_ListadoArchivosDocumentos()
            pro_ListadoArchivosResolucion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_MATEFALT.Click

        Try
            Dim frm_modificar As New frm_insertar_RECLMAFA(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString()), Me.Name)
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarMaterialDeFaltante()
            pro_ListaDeValoresMaterialDeFaltante()

            pro_ReconsultarPrediosAfectados()
            pro_ListaDeValoresPrediosAfectados()

            pro_ReconsultarMaterialEntregado()
            pro_ListaDeValoresMaterialEntregado()

            pro_ListadoArchivosDocumentos()
            pro_ListadoArchivosResolucion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_MATEFALT.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RECLMAFA

                If objdatos.fun_Eliminar_SECU_X_MACA_RECLMAFA(Integer.Parse(Me.dgvRECLMAFA.SelectedRows.Item(0).Cells("REMFSECU").Value.ToString()), _
                                                              Integer.Parse(Me.dgvRECLMAFA.SelectedRows.Item(0).Cells("REMFMACA").Value.ToString())) Then
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

            Dim frm_consultar As New frm_consultar_RECLAMOS(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarReclamos()
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_MATEFALT.Click

        Try
            boCONSULTA = False
            pro_ReconsultarReclamos()
            pro_ListaDeValoresReclamos()

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

#Region "MENU TRABAJO DE CAMPO"

    Private Sub cmdAGREGAR_TRABCAMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_LEVANTAMIENTO.Click

        Try
            Dim frm_modificar As New frm_insertar_RECLTRCA(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_Mensaje01()

            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_TRABCAMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_LEVANTAMIENTO.Click

        Try
            Dim frm_modificar As New frm_insertar_RECLTRCA(Integer.Parse(Me.dgvRECLTRCA.SelectedRows.Item(0).Cells("RETCIDRE").Value.ToString()), _
                                                                Integer.Parse(Me.dgvRECLTRCA.SelectedRows.Item(0).Cells("RETCSECU").Value.ToString()), _
                                                                Me.dgvRECLTRCA.SelectedRows.Item(0).Cells("RETCNUDO").Value.ToString())
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_Mensaje01()

            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_TRABCAMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_LEVANTAMIENTO.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RECLTRCA

                If objdatos.fun_Eliminar_IDRE_RECLTRCA(Integer.Parse(Me.dgvRECLTRCA.SelectedRows.Item(0).Cells("RETCIDRE").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarTrabajoDeCampo()
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
    Private Sub cmdCONSULTAR_TRABCAMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_LEVANTAMIENTO.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_RECLAMOS(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarReclamos()
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_TRABCAMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_LEVANTAMIENTO.Click

        Try
            boCONSULTA = False
            pro_ReconsultarReclamos()
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub ToolStripButton19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton19.Click

        Try
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton20.Click

        Try
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton21.Click

        Try
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton22.Click

        Try
            pro_ListaDeValoresTrabajoDeCampo()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU TRABAJO DE OFICINA"

    Private Sub cmdAGREGAR_TRABOFIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_TRABOFIC.Click

        Try
            Dim frm_modificar As New frm_insertar_RECLTROF(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarTrabajoDeOficina()
            pro_ListaDeValoresTrabajoDeOficina()
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_TRABOFIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_TRABOFIC.Click

        Try
            Dim frm_modificar As New frm_insertar_RECLTROF(Integer.Parse(Me.dgvRECLTROF.SelectedRows.Item(0).Cells("RETOIDRE").Value.ToString()), _
                                                           Integer.Parse(Me.dgvRECLTROF.SelectedRows.Item(0).Cells("RETOSECU").Value.ToString()), _
                                                           Me.dgvRECLTROF.SelectedRows.Item(0).Cells("RETONUDO").Value.ToString())
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_Mensaje01()

            pro_ReconsultarTrabajoDeOficina()
            pro_ListaDeValoresTrabajoDeOficina()
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_TRABOFIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_TRABOFIC.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RECLTROF

                If objdatos.fun_Eliminar_IDRE_RECLTROF(Integer.Parse(Me.dgvRECLTROF.SelectedRows.Item(0).Cells("RETOIDRE").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarTrabajoDeOficina()
                    pro_ReconsultarTrabajoDeOficina()
                    pro_ListaDeValoresTrabajoDeOficina()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_TRABOFIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_TRABOFIC.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_RECLAMOS(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarReclamos()
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_TRABOFIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_TRABOFIC.Click

        Try
            boCONSULTA = False
            pro_ReconsultarReclamos()
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU ACTO ADMINISTRATIVO"

    Private Sub cmdAGREGAR_ACTOADMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_ACTOADMI.Click

        Try
            Dim frm_modificar As New frm_insertar_RECLACAD(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarActoAdministrativo()
            pro_ListaDeValoresActoAdministrativo()

            pro_ListadoArchivosDocumentos()
            pro_ListadoArchivosResolucion()

            If Me.txtREAANURA.Text <> "0" Then

                If MessageBox.Show("¿ Desea cambiar el estado del reclamo ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Me.cmdMODIFICAR_RECLAMOS.PerformClick()
                End If

            End If

            Me.tabMAESTRO_1.SelectTab(TabACTOADMI)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_ACTOADMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_ACTOADMI.Click

        Try
            Dim frm_modificar As New frm_insertar_RECLACAD(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarActoAdministrativo()
            pro_ListaDeValoresActoAdministrativo()

            pro_ListadoArchivosDocumentos()
            pro_ListadoArchivosResolucion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_ACTOADMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_ACTOADMI.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_RECLACAD

                If objdatos.fun_Eliminar_SECU_RECLACAD(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells("RECLSECU").Value.ToString())) Then
                    boCONSULTA = False

                    pro_LimpiarActoAdministrativo()
                    pro_ReconsultarActoAdministrativo()
                    pro_ListaDeValoresActoAdministrativo()

                    pro_ListadoArchivosDocumentos()
                    pro_ListadoArchivosResolucion()

                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_ACTOADMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_ACTOADMI.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_RECLAMOS(Integer.Parse(Me.dgvRECLAMOS_1.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarReclamos()
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_ACTOADMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_ACTOADMI.Click

        Try
            boCONSULTA = False
            pro_ReconsultarReclamos()
            pro_ListaDeValoresReclamos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        pro_ListaDeValoresActoAdministrativo()
    End Sub
    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        pro_ListaDeValoresActoAdministrativo()
    End Sub
    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        pro_ListaDeValoresActoAdministrativo()
    End Sub
    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        pro_ListaDeValoresActoAdministrativo()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_TRABCAMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_ReconsultarReclamos()
        pro_ListadoArchivosDocumentos()
        pro_ListadoArchivosResolucion()

        Me.strBARRESTA.Items(0).Text = "Rectificaciones"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_RECLAMOS_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValoresReclamos()
    End Sub
    Private Sub dgvRECLAMOS_1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRECLAMOS_1.GotFocus, dgvRECLAMOS_2.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvRECLAMOS_1.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvRECLAMOS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRECLAMOS_1.KeyDown, dgvRECLAMOS_2.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================


        If e.KeyCode = Keys.F2 Then
            If Me.cmdAGREGAR_RECLAMOS.Enabled = True Then
                Me.cmdAGREGAR_RECLAMOS.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If Me.cmdMODIFICAR_RECLAMOS.Enabled = True Then
                Me.cmdMODIFICAR_RECLAMOS.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_RECLAMOS_1.Count

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
            If Me.cmdELIMINAR_RECLAMOS.Enabled = True Then
                Me.cmdELIMINAR_RECLAMOS.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_RECLAMOS_1.Count

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
            If Me.cmdCONSULTAR_RECLAMOS.Enabled = True Then
                Me.cmdCONSULTAR_RECLAMOS.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If Me.cmdCONSULTAR_RECLAMOS.Enabled = True Then
                Me.cmdRECONSULTAR_RECLAMOS.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvRECLAMOS_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvRECLAMOS_1.KeyUp, dgvRECLAMOS_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresReclamos()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvRECLAMOS_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRECLAMOS_1.CellClick, dgvRECLAMOS_2.CellClick
        pro_ListaDeValoresReclamos()
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
    Private Sub lstLISTADO_RESOLUCION_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLISTADO_RESOLUCION.DoubleClick

        Try
            If lstLISTADO_RESOLUCION.SelectedIndex <> -1 Then

                Dim stArchivo As String = lstLISTADO_RESOLUCION.SelectedItem
                Process.Start(vl_stRutaResolucion & "\" & stArchivo)
            Else

                If lstLISTADO_RESOLUCION.Items.Count > 0 Then
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