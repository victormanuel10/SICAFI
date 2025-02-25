Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_REVIAVAL

    '==========================
    '*** REVISION DE AVALUO ***
    '==========================

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

    Public Shared Function instance() As frm_REVIAVAL
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_REVIAVAL
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

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(14)

            If tblRutas.Rows.Count > 0 AndAlso Trim(Me.txtRAAANUEM.Text) <> "" AndAlso Trim(Me.txtRAAAFEEM.Text).ToString.Length = 10 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' directorio expediente 
                stCarpetaABuscar = fun_Formato_Mascara_3_String(Trim(Me.txtRAAANUEM.Text)) & "-" & fun_Formato_Mascara_4_String(Trim(Me.txtRAAAFEEM.Text.ToString.Substring(6, 4)))

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

                ' RATOrna la respuesta
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

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(14)

            If tblRutas.Rows.Count > 0 AndAlso Trim(Me.txtRAAANUEM.Text) <> "" AndAlso Trim(Me.txtRAAAFEEM.Text).ToString.Length = 10 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' directorio expediente 
                stCarpetaABuscar = fun_Formato_Mascara_3_String(Trim(Me.txtRAAANUEM.Text)) & "-" & fun_Formato_Mascara_4_String(Trim(Me.txtRAAAFEEM.Text.ToString.Substring(6, 4)))

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

                ' RATOrna la respuesta
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

            If tblRutas.Rows.Count > 0 AndAlso Trim(Me.txtRAAANURA.Text) <> "" AndAlso Trim(Me.txtRAAAFERA.Text).ToString.Length = 10 Then

                ' directorio pricipal
                stRuta = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\"

                ' directorio expediente 
                stCarpetaABuscar = Trim(Me.txtRAAANURA.Text) & "-" & fun_Formato_Mascara_4_String(Trim(Me.txtRAAAFERA.Text.ToString.Substring(6, 4)))

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

                ' RATOrna la respuesta
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

#Region "PROCEDIMIENTOS REVISION DE AVALUO"

    Private Sub pro_ReconsultarRevisionAvaluos()

        Try
            Dim objdatos As New cla_REVIAVAL

            If boCONSULTA = False Then
                Me.BindingSource_REVIAVAL_1.DataSource = objdatos.fun_Consultar_REVIAVAL
            Else
                Me.BindingSource_REVIAVAL_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REVIAVAL(vp_inConsulta)
            End If

            Me.dgvREVIAVAL_1.DataSource = BindingSource_REVIAVAL_1
            Me.dgvREVIAVAL_2.DataSource = BindingSource_REVIAVAL_1

            Me.BindingNavigator_REVIAVAL_1.BindingSource = BindingSource_REVIAVAL_1

            '=================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '=================================================

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.BindingSource_REVIAVAL_1.Count

            Me.dgvREVIAVAL_1.Columns("REAVIDRE").HeaderText = "Id"
            Me.dgvREVIAVAL_1.Columns("REAVSECU").HeaderText = "Secuencia"

            Me.dgvREVIAVAL_1.Columns("REAVDEPA").HeaderText = "Departamento"
            Me.dgvREVIAVAL_1.Columns("REAVMUNI").HeaderText = "Municipio"
            Me.dgvREVIAVAL_1.Columns("REAVCORR").HeaderText = "Correg."
            Me.dgvREVIAVAL_1.Columns("REAVBARR").HeaderText = "Barrio"
            Me.dgvREVIAVAL_1.Columns("REAVMANZ").HeaderText = "Manzana Vereda"
            Me.dgvREVIAVAL_1.Columns("REAVEDIF").HeaderText = "Edificio"
            Me.dgvREVIAVAL_1.Columns("REAVUNPR").HeaderText = "Unidad Predial"
            Me.dgvREVIAVAL_1.Columns("REAVPRED").HeaderText = "Predio"
            Me.dgvREVIAVAL_1.Columns("CLSEDESC").HeaderText = "Sector"
            Me.dgvREVIAVAL_1.Columns("REAVVIGE").HeaderText = "Vigencia"
            Me.dgvREVIAVAL_1.Columns("ESTADESC").HeaderText = "Estado"

            Me.dgvREVIAVAL_2.Columns("REAVNUDO").HeaderText = "Nro documento"
            Me.dgvREVIAVAL_2.Columns("REAVNOMB").HeaderText = "Nombre(s)"
            Me.dgvREVIAVAL_2.Columns("REAVPRAP").HeaderText = "Primer apellido"
            Me.dgvREVIAVAL_2.Columns("REAVSEAP").HeaderText = "Segundo apellido"
            Me.dgvREVIAVAL_2.Columns("REAVMAIN").HeaderText = "Matricula"

            Me.dgvREVIAVAL_1.Columns("REAVIDRE").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVSECU").Visible = False

            Me.dgvREVIAVAL_1.Columns("REAVDEPA").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVRADE").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVFEDE").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVRAMU").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVFEMU").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVRAED").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVFEED").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVRADM").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVFEDM").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVFELC").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVTITR").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVOBSE").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVNUDO").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVNOMB").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVPRAP").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVSEAP").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVMAIN").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVMACA").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVMIAN").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVSOLI").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVESTA").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVCLSE").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVFEMC").Visible = False
            Me.dgvREVIAVAL_1.Columns("REAVUSMC").Visible = False

            Me.dgvREVIAVAL_2.Columns("REAVIDRE").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVSECU").Visible = False

            Me.dgvREVIAVAL_2.Columns("REAVDEPA").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVMUNI").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVCORR").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVBARR").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVMANZ").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVPRED").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVEDIF").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVUNPR").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVCLSE").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVVIGE").Visible = False
            Me.dgvREVIAVAL_2.Columns("ESTADESC").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVRADE").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVFEDE").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVRAMU").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVFEMU").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVRAED").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVFEED").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVRADM").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVFEDM").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVFELC").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVTITR").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVOBSE").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVMACA").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVMIAN").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVSOLI").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVESTA").Visible = False
            Me.dgvREVIAVAL_2.Columns("CLSEDESC").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVFEMC").Visible = False
            Me.dgvREVIAVAL_2.Columns("REAVUSMC").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_REVIAVAL_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_REVIAVAL_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_REVIAVAL_1.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_REVIAVAL_1.Enabled = boCONTMODI
            Me.cmdELIMINAR_REVIAVAL_1.Enabled = boCONTELIM
            Me.cmdCONSULTAR_REVIAVAL_1.Enabled = True
            Me.cmdRECONSULTAR_REVIAVAL_1.Enabled = boCONTRECO


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresRevisionAvaluos()

        Try
            If Me.dgvREVIAVAL_1.RowCount > 0 Then

                Dim objdatos As New cla_REVIAVAL
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REVIAVAL(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVIDRE").Value.ToString)

                If tbl.Rows.Count > 0 Then
                    Me.txtREAVFEMC.Text = Trim(tbl.Rows(0).Item("REAVFEMC").ToString)
                End If

                Me.txtREAVRADE.Text = Trim(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVRADE").Value.ToString)
                Me.txtREAVFEDE.Text = Trim(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVFEDE").Value.ToString)
                Me.txtREAVRAMU.Text = Trim(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVRAMU").Value.ToString)
                Me.txtREAVFEMU.Text = Trim(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVFEMU").Value.ToString)
                Me.txtREAVRAED.Text = Trim(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVRAED").Value.ToString)
                Me.txtREAVFEED.Text = Trim(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVFEED").Value.ToString)
                Me.txtREAVRADM.Text = Trim(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVRADM").Value.ToString)
                Me.txtREAVFEDM.Text = Trim(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVFEDM").Value.ToString)
                Me.txtREAVFELC.Text = Trim(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVFELC").Value.ToString)
                Me.txtREAVTITR.Text = Trim(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVTITR").Value.ToString)
                Me.txtREAVOBSE.Text = Trim(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVOBSE").Value.ToString)

                Me.lblREAVMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVDEPA").Value.ToString, Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVMUNI").Value.ToString), String)
                Me.lblREAVCORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVDEPA").Value.ToString, Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVMUNI").Value.ToString, Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVCLSE").Value.ToString, Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVCORR").Value.ToString), String)

                If CInt(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVCLSE").Value.ToString) = 1 Then
                    Me.lblREAVBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVDEPA").Value.ToString, Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVMUNI").Value.ToString, Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVCLSE").Value.ToString, Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVBARR").Value.ToString, Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVCLSE").Value.ToString) = 2 Then
                    Me.lblREAVBAVE.Text = CType(fun_Buscar_Lista_Valores_VEREDA(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVDEPA").Value.ToString, Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVMUNI").Value.ToString, Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVCLSE").Value.ToString, Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVMANZ").Value.ToString, Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVCORR").Value.ToString), String)
                ElseIf CInt(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVCLSE").Value.ToString) = 3 Then
                    Me.lblREAVBAVE.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVDEPA").Value.ToString, Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVMUNI").Value.ToString, Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVCLSE").Value.ToString, Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVBARR").Value.ToString, Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVCORR").Value.ToString), String)
                End If

                Me.lblREAVTITR.Text = CType(fun_Buscar_Lista_Valores_TIPOTRAM(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVTITR").Value.ToString), String)
                Me.lblREAVSOLI.Text = CType(fun_Buscar_Lista_Valores_SOLICITANTE(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSOLI").Value.ToString), String)

                Me.txtREAVMACA.Text = CType(fun_Buscar_Lista_Valores_USUARIO(Trim(tbl.Rows(0).Item("REAVMACA"))), String)

                If Trim(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVESTA").Value.ToString) = "fi" Then
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

                Me.BindingNavigator_REAVPRAF_1.Enabled = True
                Me.BindingNavigator_REAVINUS_1.Enabled = True
                Me.BindingNavigator_REAVMAEN_1.Enabled = True
                Me.BindingNavigator_REAVMAFA_1.Enabled = True
                Me.BindingNavigator_REAVTRCA_1.Enabled = True
                Me.BindingNavigator_REAVTROF_1.Enabled = True
                Me.BindingNavigator_REAVACAD_1.Enabled = True

            Else
                pro_LimpiarCamposRevisionAvaluos()
                pro_LimpiarPrediosAfectados()
                pro_LimpiarInformacionUsuario()
                pro_LimpiarMaterialEntregado()
                pro_LimpiarMaterialFaltante()
                pro_LimpiarTrabajoDeCampo()
                pro_LimpiarTrabajoDeOficina()
                pro_LimpiarActoAdministrativo()
                pro_LimpiarDocumentos()

                Me.BindingNavigator_REAVPRAF_1.Enabled = False
                Me.BindingNavigator_REAVINUS_1.Enabled = False
                Me.BindingNavigator_REAVMAEN_1.Enabled = False
                Me.BindingNavigator_REAVMAFA_1.Enabled = False
                Me.BindingNavigator_REAVTRCA_1.Enabled = False
                Me.BindingNavigator_REAVTROF_1.Enabled = False
                Me.BindingNavigator_REAVACAD_1.Enabled = False

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCamposRevisionAvaluos()

        Me.lblREAVBAVE.Text = ""
        Me.lblREAVMUNI.Text = ""
        Me.lblREAVCORR.Text = ""
        Me.lblREAVSOLI.Text = ""
        Me.txtREAVRADE.Text = ""
        Me.txtREAVFEDE.Text = ""
        Me.txtREAVRAMU.Text = ""
        Me.txtREAVRAED.Text = ""
        Me.txtREAVRADM.Text = ""
        Me.txtREAVOBSE.Text = ""
        Me.txtREAVMACA.Text = ""
        Me.txtREAVFEMC.Text = ""

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

        If Me.dgvREAVTRCA.RowCount = 0 And Me.dgvREAVTROF.RowCount = 0 Then
            If MessageBox.Show(stMensaje01, "mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Me.cmdMODIFICAR_REVIAVAL_1.PerformClick()
            End If
        End If

    End Sub

    Private Sub pro_EjecutarBotonFinalizar()

        Try
            If Me.dgvREVIAVAL_1.RowCount > 0 Then
                If CStr(Trim(Me.txtRAAANURA.Text)) <> "" AndAlso CInt(Me.txtRAAANURA.Text) <> 0 Then

                    If MessageBox.Show("¿ Desea finalizar el tramite Nro. " & Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        Dim stREAVOBSE_ACTUAL As String = ""
                        Dim stREAVOBSE_NUEVA As String = " Nota de registro: " & " El usuario: " & vp_usuario & " " & fun_fecha() & " finalizo el tramite. "

                        Dim obREAVGEOG As New cla_REVIAVAL
                        Dim dtREAVGEOG As New DataTable

                        dtREAVGEOG = obREAVGEOG.fun_Buscar_ID_REVIAVAL(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVIDRE").Value.ToString())

                        If dtREAVGEOG.Rows.Count > 0 Then
                            stREAVOBSE_ACTUAL = Trim(dtREAVGEOG.Rows(0).Item("REAVOBSE").ToString)
                        End If

                        If Trim(stREAVOBSE_ACTUAL) <> "" And Trim(stREAVOBSE_NUEVA) <> "" Then
                            stREAVOBSE_ACTUAL += vbCrLf & stREAVOBSE_NUEVA & ". "

                        ElseIf Trim(stREAVOBSE_ACTUAL) = "" And Trim(stREAVOBSE_NUEVA) <> "" Then
                            stREAVOBSE_ACTUAL = stREAVOBSE_NUEVA & ". "

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
                        Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVIDRE").Value.ToString())
                        Dim stMOGEESTA As String = "fi"

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update REVIAVAL "
                        ParametrosConsulta += "set REAVESTA = '" & stMOGEESTA & "', "
                        ParametrosConsulta += "REAVOBSE = '" & stREAVOBSE_ACTUAL & "'  "
                        ParametrosConsulta += "where REAVIDRE = '" & inMOGEIDRE & "'  "

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

                        vp_inConsulta = Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVIDRE").Value.ToString()

                        pro_ReconsultarRevisionAvaluos()
                        pro_ListaDeValoresRevisionAvaluos()

                    End If

                Else
                    MessageBox.Show("El Tramite NO posee en el Acto Administrativo Nro. de Resolución.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    Me.tabMAESTRO_1.SelectTab(TabACTOADMI)
                    Me.txtRAAANURA.Focus()

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
            If Me.dgvREVIAVAL_1.RowCount > 0 Then

                If MessageBox.Show("¿ Desea ingresar una observación al tramite Nro. " & Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString() & " ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim stObservacionNueva As String = InputBox("Ingrese la observación.", "Mensaje")

                    If Trim(stObservacionNueva) = "" Then
                        MessageBox.Show("Se requiere una observación.", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
                    Else

                        Dim stREAVOBSE_ACTUAL As String = ""
                        Dim stREAVOBSE_NUEVA As String = Trim(stObservacionNueva.ToString.ToUpper)

                        Dim obMOGEGEOG As New cla_REVIAVAL
                        Dim dtAJUSGEOG As New DataTable

                        dtAJUSGEOG = obMOGEGEOG.fun_Buscar_ID_REVIAVAL(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVIDRE").Value.ToString())

                        If dtAJUSGEOG.Rows.Count > 0 Then
                            stREAVOBSE_ACTUAL = Trim(dtAJUSGEOG.Rows(0).Item("REAVOBSE").ToString)
                        End If

                        If Trim(stREAVOBSE_ACTUAL) <> "" And Trim(stREAVOBSE_NUEVA) <> "" Then
                            stREAVOBSE_ACTUAL += vbCrLf & " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stREAVOBSE_NUEVA & ". "

                        ElseIf Trim(stREAVOBSE_ACTUAL) = "" And Trim(stREAVOBSE_NUEVA) <> "" Then
                            stREAVOBSE_ACTUAL = " Nota ingresada por " & vp_usuario & " " & fun_fecha() & " : " & stREAVOBSE_NUEVA & ". "

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
                        Dim inMOGEIDRE As Integer = Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVIDRE").Value.ToString())

                        ' parametros de la consulta
                        Dim ParametrosConsulta As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta += "update REVIAVAL "
                        ParametrosConsulta += "set REAVOBSE = '" & stREAVOBSE_ACTUAL & "' "
                        ParametrosConsulta += "where REAVIDRE = '" & inMOGEIDRE & "' "

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

                        pro_ReconsultarRevisionAvaluos()
                        pro_ListaDeValoresRevisionAvaluos()

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
            Dim objdatos As New cla_REAVPRAF

            If boCONSULTA = False Then
                Me.BindingSource_REAVPRAF_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVPRAF(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString)
            Else
                Me.BindingSource_REAVPRAF_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVPRAF(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString)
            End If

            Me.dgvREAVPRAF.DataSource = Me.BindingSource_REAVPRAF_1
            Me.BindingNavigator_REAVPRAF_1.BindingSource = Me.BindingSource_REAVPRAF_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvREAVPRAF.Columns("RAPAIDRE").HeaderText = "idre"
            Me.dgvREAVPRAF.Columns("RAPASECU").HeaderText = "Secuencia"

            Me.dgvREAVPRAF.Columns("RAPAMUNI").HeaderText = "Municipio"
            Me.dgvREAVPRAF.Columns("RAPACORR").HeaderText = "Corregi."
            Me.dgvREAVPRAF.Columns("RAPABARR").HeaderText = "Barrio"
            Me.dgvREAVPRAF.Columns("RAPAMANZ").HeaderText = "Manzana-Vereda"
            Me.dgvREAVPRAF.Columns("RAPAPRED").HeaderText = "Predio"
            Me.dgvREAVPRAF.Columns("RAPAEDIF").HeaderText = "Edificio"
            Me.dgvREAVPRAF.Columns("RAPAUNPR").HeaderText = "Unidad predial"

            Me.dgvREAVPRAF.Columns("RAPAIDRE").Visible = False
            Me.dgvREAVPRAF.Columns("RAPASECU").Visible = False

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_REAVPRAF_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            ' pro_Permiso_Barra_De_Menu_Formulario_Formulario(ContarRegistros, Trim(Me.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)
            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_REAVPRAF_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_REAVPRAF_1.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_REAVPRAF_1.Enabled = boCONTMODI
            Me.cmdELIMINAR_REAVPRAF_1.Enabled = boCONTELIM
            Me.cmdCONSULTAR_REAVPRAF_1.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_REAVPRAF_1.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresPrediosAfectados()

        Try
            If Me.dgvREAVPRAF.RowCount = 0 Then

                pro_LimpiarPrediosAfectados()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarPrediosAfectados()

        'Me.dgvREAVPRAF.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS INFORMACION DE SOLICITANTE"

    Private Sub pro_ReconsultarInformacionDeUsuario()

        Try
            Dim objdatos As New cla_REAVINUS

            If boCONSULTA = False Then
                Me.BindingSource_REAVINUS_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVINUS(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString)
            Else
                Me.BindingSource_REAVINUS_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVINUS(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString)
            End If

            Me.BindingNavigator_REAVINUS_1.BindingSource = Me.BindingSource_REAVINUS_1

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_REAVINUS_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_REAVINUS_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_REAVINUS_1.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_REAVINUS_1.Enabled = boCONTMODI
            Me.cmdELIMINAR_REAVINUS_1.Enabled = boCONTELIM
            Me.cmdCONSULTAR_REAVINUS_1.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_REAVINUS_1.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresInformacionDeUsuario()

        Try
            If Me.BindingSource_REAVINUS_1.Count > 0 Then

                Dim objdatos As New cla_REAVINUS
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVINUS(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString)

                If tbl.Rows.Count > 0 Then

                    Me.txtRAIUDIPR.Text = Trim(tbl.Rows(0).Item("RAIUDIPR"))
                    Me.txtRAIUDINO.Text = Trim(tbl.Rows(0).Item("RAIUDINO"))
                    Me.txtRAIUTEL1.Text = Trim(tbl.Rows(0).Item("RAIUTEL1"))
                    Me.txtRAIUTEL2.Text = Trim(tbl.Rows(0).Item("RAIUTEL2"))
                    Me.chkRAIUACTA.Checked = tbl.Rows(0).Item("RAIUACTA")
                    Me.chkRAIUACFI.Checked = tbl.Rows(0).Item("RAIUACFI")
                    Me.txtRAIUNUAC.Text = Trim(tbl.Rows(0).Item("RAIUNUAC"))
                    Me.txtRAIUNOMB.Text = Trim(tbl.Rows(0).Item("RAIUNOMB"))
                    Me.txtRAIUPRAP.Text = Trim(tbl.Rows(0).Item("RAIUPRAP"))
                    Me.txtRAIUSEAP.Text = Trim(tbl.Rows(0).Item("RAIUSEAP"))
                    Me.txtRAIUTEL1.Text = Trim(tbl.Rows(0).Item("RAIUTEL1"))
                    Me.txtRAIUTEL2.Text = Trim(tbl.Rows(0).Item("RAIUTEL2"))
                    Me.txtRAIUFEEN.Text = Trim(tbl.Rows(0).Item("RAIUFEEN"))
                    Me.txtRAIUFERE.Text = Trim(tbl.Rows(0).Item("RAIUFERE"))
                    Me.txtRAIUOBSE.Text = Trim(tbl.Rows(0).Item("RAIUOBSE"))

                End If

            Else
                pro_LimpiarInformacionUsuario()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarInformacionUsuario()

        Me.txtRAIUDIPR.Text = ""
        Me.txtRAIUDINO.Text = ""
        Me.txtRAIUTEL1.Text = ""
        Me.txtRAIUTEL2.Text = ""
        Me.chkRAIUACTA.Checked = False
        Me.chkRAIUACFI.Checked = False
        Me.txtRAIUNUAC.Text = ""
        Me.txtRAIUNOMB.Text = ""
        Me.txtRAIUPRAP.Text = ""
        Me.txtRAIUSEAP.Text = ""
        Me.txtRAIUTEL1.Text = ""
        Me.txtRAIUTEL2.Text = ""
        Me.txtRAIUFEEN.Text = ""
        Me.txtRAIUFERE.Text = ""
        Me.txtRAIUOBSE.Text = ""

    End Sub

#End Region

#Region "PROCEDIMIENTOS METERIAL ENTREGADO"

    Private Sub pro_ReconsultarMaterialEntregado()

        Try
            Dim objdatos As New cla_REAVMAEN

            If boCONSULTA = False Then
                Me.BindingSource_REAVMAEN_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVMAEN(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString)
            Else
                Me.BindingSource_REAVMAEN_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVMAEN(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString)
            End If

            Me.dgvREAVMAEN.DataSource = Me.BindingSource_REAVMAEN_1
            Me.BindingNavigator_REAVMAEN_1.BindingSource = Me.BindingSource_REAVMAEN_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvREAVMAEN.Columns("RAMEIDRE").HeaderText = "idre"
            Me.dgvREAVMAEN.Columns("RAMESECU").HeaderText = "Secuencia"

            Me.dgvREAVMAEN.Columns("RAMEMACA").HeaderText = "Código"
            Me.dgvREAVMAEN.Columns("MACADESC").HeaderText = "Descripción"
            Me.dgvREAVMAEN.Columns("RAMEFECH").HeaderText = "Fecha"
            Me.dgvREAVMAEN.Columns("RAMEOBSE").HeaderText = "Observación"

            Me.dgvREAVMAEN.Columns("RAMEIDRE").Visible = False
            Me.dgvREAVMAEN.Columns("RAMESECU").Visible = False
            Me.dgvREAVMAEN.Columns("RAMEOBSE").Visible = False

            Me.dgvREAVMAEN.Columns("RAMEMACA").Width = 30
            Me.dgvREAVMAEN.Columns("MACADESC").Width = 100
            Me.dgvREAVMAEN.Columns("RAMEFECH").Width = 100

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_REAVMAEN_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_REAVMAEN_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_REAVMAEN_1.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_REAVMAEN_1.Enabled = boCONTMODI
            Me.cmdELIMINAR_REAVMAEN_1.Enabled = boCONTELIM
            Me.cmdCONSULTAR_REAVMAEN_1.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_REAVMAEN_1.Enabled = boCONTRECO


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresMaterialEntregado()

        Try
            If Me.dgvREAVMAEN.RowCount > 0 Then

                pro_ListadoArchivosDocumentos()

            Else
                pro_LimpiarMaterialEntregado()

            End If

            Dim objdatos As New cla_REAVOBME
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVOBME(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString)

            If tbl.Rows.Count > 0 Then
                Me.txtRAMEOBSE.Text = Trim(tbl.Rows(0).Item("ROMEOBSE"))
            Else
                Me.txtRAMEOBSE.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarMaterialEntregado()

        Me.txtRAMEOBSE.Text = ""
        'Me.dgvREAVMAEN.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS METERIAL FALTANTE"

    Private Sub pro_ReconsultarMaterialDeFaltante()

        Try
            Dim objdatos As New cla_REAVMAFA

            If boCONSULTA = False Then
                Me.BindingSource_REAVMAFA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVMAFA(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString)
            Else
                Me.BindingSource_REAVMAFA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVMAFA(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString)
            End If

            Me.dgvREAVMAFA.DataSource = Me.BindingSource_REAVMAFA_1
            Me.BindingNavigator_REAVMAFA_1.BindingSource = Me.BindingSource_REAVMAFA_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvREAVMAFA.Columns("RAMFIDRE").HeaderText = "idre"
            Me.dgvREAVMAFA.Columns("RAMFSECU").HeaderText = "Secuencia"

            Me.dgvREAVMAFA.Columns("RAMFMACA").HeaderText = "Código"
            Me.dgvREAVMAFA.Columns("MACADESC").HeaderText = "Descripción"
            Me.dgvREAVMAFA.Columns("RAMFFECH").HeaderText = "Fecha"
            Me.dgvREAVMAFA.Columns("RAMFOBSE").HeaderText = "Observación"

            Me.dgvREAVMAFA.Columns("RAMFIDRE").Visible = False
            Me.dgvREAVMAFA.Columns("RAMFSECU").Visible = False
            Me.dgvREAVMAFA.Columns("RAMFOBSE").Visible = False

            Me.dgvREAVMAFA.Columns("RAMFMACA").Width = 30
            Me.dgvREAVMAFA.Columns("MACADESC").Width = 100
            Me.dgvREAVMAFA.Columns("RAMFFECH").Width = 100

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_REAVMAFA_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_REAVMAFA_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_REAVMAFA_1.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_REAVMAFA_1.Enabled = boCONTMODI
            Me.cmdELIMINAR_REAVMAFA_1.Enabled = boCONTELIM
            Me.cmdCONSULTAR_REAVMAFA_1.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_REAVMAFA_1.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresMaterialDeFaltante()

        Try
            If Me.dgvREAVMAFA.RowCount > 0 Then

                Me.chkMaterialFaltante.Checked = True

            Else
                pro_LimpiarMaterialFaltante()

                Me.chkMaterialFaltante.Checked = False

            End If

            Dim objdatos As New cla_REAVOBMF
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVOBMF(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString)

            If tbl.Rows.Count > 0 Then
                Me.txtRAMFOBSE.Text = Trim(tbl.Rows(0).Item("ROMFOBSE"))
            Else
                Me.txtRAMFOBSE.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarMaterialFaltante()

        Me.txtRAMFOBSE.Text = ""

        'Me.dgvREAVMAFA.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS TRABAJO DE CAMPO"

    Private Sub pro_ReconsultarTrabajoDeCampo()

        Try
            Dim objdatos As New cla_REAVTRCA

            If boCONSULTA = False Then
                Me.BindingSource_REAVTRCA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVTRCA(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString)
            Else
                Me.BindingSource_REAVTRCA_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVTRCA(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString)
            End If

            Me.dgvREAVTRCA.DataSource = Me.BindingSource_REAVTRCA_1
            Me.BindingNavigator_REAVTRCA_1.BindingSource = Me.BindingSource_REAVTRCA_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvREAVTRCA.Columns("RATCIDRE").HeaderText = "idre"
            Me.dgvREAVTRCA.Columns("RATCSECU").HeaderText = "Secuencia"

            Me.dgvREAVTRCA.Columns("RATCNUDO").HeaderText = "Nro. Documento"
            Me.dgvREAVTRCA.Columns("USUANOMB").HeaderText = "Nombre(s)"
            Me.dgvREAVTRCA.Columns("USUAPRAP").HeaderText = "Primer apellido"
            Me.dgvREAVTRCA.Columns("USUASEAP").HeaderText = "Segundo apellido"
            Me.dgvREAVTRCA.Columns("RATCFEEN").HeaderText = "Fecha de entrega"
            Me.dgvREAVTRCA.Columns("RATCOBSE").HeaderText = "Observación"

            Me.dgvREAVTRCA.Columns("RATCIDRE").Visible = False
            Me.dgvREAVTRCA.Columns("RATCSECU").Visible = False

            Me.dgvREAVTRCA.Columns("RATCNUDO").Width = 50
            Me.dgvREAVTRCA.Columns("USUANOMB").Width = 50
            Me.dgvREAVTRCA.Columns("USUAPRAP").Width = 50
            Me.dgvREAVTRCA.Columns("USUASEAP").Width = 50
            Me.dgvREAVTRCA.Columns("RATCFEEN").Width = 50
            Me.dgvREAVTRCA.Columns("RATCOBSE").Width = 200

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_REAVTRCA_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_REAVTRCA_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_REAVTRCA_1.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_REAVTRCA_1.Enabled = boCONTMODI
            Me.cmdELIMINAR_REAVTRCA_1.Enabled = boCONTELIM
            Me.cmdCONSULTAR_REAVTRCA_1.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_REAVTRCA_1.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresTrabajoDeCampo()

        Try
            If Me.dgvREAVTRCA.RowCount = 0 Then

                pro_LimpiarTrabajoDeCampo()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarTrabajoDeCampo()

        'Me.dgvREAVTRCA.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS TRABAJO DE OFICINA"

    Private Sub pro_ReconsultarTrabajoDeOficina()

        Try
            Dim objdatos As New cla_REAVTROF

            If boCONSULTA = False Then
                Me.BindingSource_REAVTROF_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVTROF(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString)
            Else
                Me.BindingSource_REAVTROF_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVTROF(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString)
            End If

            Me.dgvREAVTROF.DataSource = Me.BindingSource_REAVTROF_1
            Me.BindingNavigator_REAVTROF_1.BindingSource = Me.BindingSource_REAVTROF_1

            '==================================================
            '*** CONFIGURA OBJETOS DEL FORMULARIO MAESTRO ***
            '==================================================

            Me.dgvREAVTROF.Columns("RATOIDRE").HeaderText = "idre"
            Me.dgvREAVTROF.Columns("RATOSECU").HeaderText = "Secuencia"

            Me.dgvREAVTROF.Columns("RATONUDO").HeaderText = "Nro. Documento"
            Me.dgvREAVTROF.Columns("USUANOMB").HeaderText = "Nombre(s)"
            Me.dgvREAVTROF.Columns("USUAPRAP").HeaderText = "Primer apellido"
            Me.dgvREAVTROF.Columns("USUASEAP").HeaderText = "Segundo apellido"
            Me.dgvREAVTROF.Columns("RATOFEEN").HeaderText = "Fecha de entrega"
            Me.dgvREAVTROF.Columns("RATOOBSE").HeaderText = "Observación"

            Me.dgvREAVTROF.Columns("RATOIDRE").Visible = False
            Me.dgvREAVTROF.Columns("RATOSECU").Visible = False

            Me.dgvREAVTROF.Columns("RATONUDO").Width = 50
            Me.dgvREAVTROF.Columns("USUANOMB").Width = 50
            Me.dgvREAVTROF.Columns("USUAPRAP").Width = 50
            Me.dgvREAVTROF.Columns("USUASEAP").Width = 50
            Me.dgvREAVTROF.Columns("RATOFEEN").Width = 50
            Me.dgvREAVTROF.Columns("RATOOBSE").Width = 200

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_REAVTROF_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_REAVTROF_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_REAVTROF_1.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_REAVTROF_1.Enabled = boCONTMODI
            Me.cmdELIMINAR_REAVTROF_1.Enabled = boCONTELIM
            Me.cmdCONSULTAR_REAVTROF_1.Enabled = boCONTCONS

            Me.cmdRECONSULTAR_REAVTROF_1.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresTrabajoDeOficina()

        Try
            If Me.dgvREAVTROF.RowCount = 0 Then

                pro_LimpiarTrabajoDeOficina()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarTrabajoDeOficina()

        'Me.dgvREAVTROF.DataSource = New DataTable

    End Sub

#End Region

#Region "PROCEDIMIENTOS ACTO ADMINISTRATIVO"

    Private Sub pro_ReconsultarActoAdministrativo()

        Try
            Dim objdatos As New cla_REAVACAD

            If boCONSULTA = False Then
                Me.BindingSource_REAVACAD_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVACAD(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString)
            Else
                Me.BindingSource_REAVACAD_1.DataSource = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVACAD(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString)
            End If

            Me.BindingNavigator_REAVACAD_1.BindingSource = Me.BindingSource_REAVACAD_1

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim ContarRegistros As Integer = Me.BindingSource_REAVACAD_1.Count

            Dim boCONTAGRE As Boolean = False
            Dim boCONTMODI As Boolean = False
            Dim boCONTELIM As Boolean = False
            Dim boCONTCONS As Boolean = False
            Dim boCONTRECO As Boolean = False

            pro_Permiso_Barra_De_Menu_Formulario_SubFormulario(ContarRegistros, Trim(Me.BindingNavigator_REAVACAD_1.Name), boCONTAGRE, boCONTMODI, boCONTELIM, boCONTCONS, boCONTRECO)

            Me.cmdAGREGAR_REAVACAD_1.Enabled = boCONTAGRE
            Me.cmdMODIFICAR_REAVACAD_1.Enabled = boCONTMODI
            Me.cmdELIMINAR_REAVACAD_1.Enabled = boCONTELIM
            Me.cmdCONSULTAR_REAVACAD_1.Enabled = boCONTCONS
            Me.cmdRECONSULTAR_REAVACAD_1.Enabled = boCONTRECO

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresActoAdministrativo()

        Try
            If Me.BindingSource_REAVACAD_1.Count > 0 Then

                Dim objdatos As New cla_REAVACAD
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVACAD(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString)

                If tbl.Rows.Count > 0 Then

                    Me.txtRAAAACAD.Text = CStr(Trim(tbl.Rows(0).Item("RAAAACAD")))
                    Me.txtRAAATITR.Text = CStr(Trim(tbl.Rows(0).Item("RAAATITR")))
                    Me.txtRAAANUEM.Text = CStr(Trim(tbl.Rows(0).Item("RAAANUEM")))
                    Me.txtRAAAFEEM.Text = CStr(Trim(tbl.Rows(0).Item("RAAAFEEM")))
                    Me.txtRAAANURA.Text = CStr(Trim(tbl.Rows(0).Item("RAAANURA")))
                    Me.txtRAAAFERA.Text = CStr(Trim(tbl.Rows(0).Item("RAAAFERA")))
                    Me.txtRAAANURR.Text = CStr(Trim(tbl.Rows(0).Item("RAAANURR")))
                    Me.txtRAAAFERR.Text = CStr(Trim(tbl.Rows(0).Item("RAAAFERR")))
                    Me.txtRAAAOBSE.Text = CStr(Trim(tbl.Rows(0).Item("RAAAOBSE")))

                    Me.lblRAAAACAD.Text = fun_Buscar_Lista_Valores_ACTOADMI(Trim(Me.txtRAAAACAD.Text))
                    Me.lblRAAATITR.Text = fun_Buscar_Lista_Valores_TIPOTRAM(Trim(Me.txtRAAATITR.Text))

                    If Trim(Me.txtRAAANUEM.Text) <> "0" And Trim(Me.txtRAAANUEM.Text) <> "" Then
                        pro_ListadoArchivosDocumentos()
                    End If

                    If Trim(Me.txtRAAANURA.Text) <> "0" And Trim(Me.txtRAAANURA.Text) <> "" Then
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

        Me.txtRAAAACAD.Text = ""
        Me.txtRAAATITR.Text = ""
        Me.lblRAAAACAD.Text = ""
        Me.lblRAAATITR.Text = ""
        Me.txtRAAANUEM.Text = ""
        Me.txtRAAAFEEM.Text = ""
        Me.txtRAAANURA.Text = ""
        Me.txtRAAAFERA.Text = ""
        Me.txtRAAANURR.Text = ""
        Me.txtRAAAFERR.Text = ""
        Me.txtRAAAOBSE.Text = ""

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

            tblRutas = objRutas.fun_Buscar_CODIGO_MANT_RUTAS(14)

            If tblRutas.Rows.Count > 0 AndAlso fun_VerificarCarpetaExistenteDocumentos() = True Then

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & fun_Formato_Mascara_3_String(Trim(Me.txtRAAANUEM.Text)) & "-" & fun_Formato_Mascara_4_String(Trim(Me.txtRAAAFEEM.Text.ToString.Substring(6, 4)))

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

                stNewPath = Trim(tblRutas.Rows(0).Item("RUTARUTA")) & "\" & Trim(Me.txtRAAANURA.Text) & "-" & fun_Formato_Mascara_4_String(Trim(Me.txtRAAAFERA.Text.ToString.Substring(6, 4)))

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

#Region "MENU REVISION DE AVALUO"

    Private Sub cmdAGREGAR_REVIAVAL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_REVIAVAL_1.Click

        Try
            If Me.dgvREVIAVAL_1.RowCount > 0 Then
                Dim frm_insertar As New frm_insertar_REVIAVAL(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells(0).Value.ToString()))
                frm_insertar.ShowDialog()
            Else
                frm_insertar_REVIAVAL.ShowDialog()
            End If
           
            If vp_inConsulta <> 0 Then
                boCONSULTA = True

                pro_ReconsultarRevisionAvaluos()
                pro_ListaDeValoresRevisionAvaluos()

                If MessageBox.Show("¿ Desea asignar el trabajo de campo ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Me.tabMAESTRO_1.SelectTab(TabTRABCAMP)
                    Me.cmdAGREGAR_REAVTRCA_1.PerformClick()
                End If
            Else
                Me.TabMAESTRO_2.SelectTab(TabInformacion)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_REVIAVAL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_REVIAVAL_1.Click

        Try
            Dim frm_modificar As New frm_modificar_REVIAVAL(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_modificar.ShowDialog()

            If vp_inConsulta <> 0 Then
                boCONSULTA = True

                pro_ReconsultarRevisionAvaluos()
                pro_ListaDeValoresRevisionAvaluos()

            End If

            Me.TabMAESTRO_2.SelectTab(TabInformacion)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_REVIAVAL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_REVIAVAL_1.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_REVIAVAL

                If objdatos.fun_Eliminar_IDRE_REVIAVAL(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells(0).Value.ToString())) Then

                    boCONSULTA = False
                    pro_LimpiarCamposRevisionAvaluos()
                    pro_ReconsultarRevisionAvaluos()
                    pro_ListaDeValoresRevisionAvaluos()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCONSULTAR_REVIAVAL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_REVIAVAL_1.Click

        Try
            vp_inConsulta = 0

            If Me.dgvREVIAVAL_1.RowCount > 0 Then
                Dim frm_consultar As New frm_consultar_REVIAVAL(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVIDRE").Value.ToString()))
                frm_consultar.ShowDialog()
            Else
                Dim frm_consultar As New frm_consultar_REVIAVAL()
                frm_consultar.ShowDialog()
            End If

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarRevisionAvaluos()
            pro_ListaDeValoresRevisionAvaluos()

            Me.TabMAESTRO_2.SelectTab(TabInformacion)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_REVIAVAL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_REVIAVAL_1.Click

        Try
            If Me.dgvREVIAVAL_1.RowCount > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarRevisionAvaluos()
            pro_ListaDeValoresRevisionAvaluos()

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
    Private Sub cmdIMPORTAR_DOCUMENTOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIMPORTAR_DOCUMENTOS.Click

        Try
            If Me.dgvREVIAVAL_1.RowCount > 0 Then

                Dim frm_inserta_archivo As New frm_insertar_archivo_REVIAVAL(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString(), _
                                                                             Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVMUNI").Value.ToString(), _
                                                                             Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVCORR").Value.ToString(), _
                                                                             Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVBARR").Value.ToString(), _
                                                                             Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVMANZ").Value.ToString(), _
                                                                             Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVPRED").Value.ToString(), _
                                                                             Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVEDIF").Value.ToString(), _
                                                                             Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVUNPR").Value.ToString(), _
                                                                             Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVCLSE").Value.ToString(), _
                                                                             Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVVIGE").Value.ToString())
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
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        Try
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click

        Try
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click

        Try
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU PREDIOS AFECTADOS"

    Private Sub cmdAGREGAR_PREDAFEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_REAVPRAF_1.Click

        Try
            Dim frm_modificar As New frm_insertar_REAVPRAF(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString()))
            frm_modificar.ShowDialog()

            boCONSULTA = False

            pro_ReconsultarPrediosAfectados()
            pro_ListaDeValoresPrediosAfectados()

            Me.tabMAESTRO_1.SelectTab(TabPREDAFEC)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_PREDAFEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_REAVPRAF_1.Click


        Try
            Dim frm_modificar As New frm_insertar_REAVPRAF(Integer.Parse(Me.dgvREAVPRAF.SelectedRows.Item(0).Cells("RAPAIDRE").Value.ToString()), Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString())
            frm_modificar.ShowDialog()

            boCONSULTA = False

            pro_ReconsultarPrediosAfectados()
            pro_ListaDeValoresPrediosAfectados()

            Me.tabMAESTRO_1.SelectTab(TabPREDAFEC)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_PREDAFEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_REAVPRAF_1.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_REAVPRAF

                If objdatos.fun_Eliminar_IDRE_REAVPRAF(Integer.Parse(Me.dgvREAVPRAF.SelectedRows.Item(0).Cells("RAPAIDRE").Value.ToString())) Then
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
    Private Sub cmdCONSULTAR_PREDAFEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_REAVPRAF_1.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_REVIAVAL(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarRevisionAvaluos()
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_PREDAFEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_REAVPRAF_1.Click

        Try
            boCONSULTA = False
            pro_ReconsultarRevisionAvaluos()
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click

        Try
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click

        Try
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton12.Click

        Try
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub ToolStripButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton13.Click

        Try
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU INFORMACION DE USUARIO"

    Private Sub cmdAGREGAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_REAVINUS_1.Click

        Try
            Dim frm_modificar As New frm_insertar_REAVINUS(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarInformacionDeUsuario()
            pro_ListaDeValoresInformacionDeUsuario()

            If MessageBox.Show("¿ Desea agregar el material aportado ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Me.TabMAESTRO_2.SelectTab(TabMATEUSUA)
                Me.cmdAGREGAR_REAVMAEN_1.PerformClick()
            End If

            pro_ReconsultarMaterialEntregado()
            pro_ListaDeValoresMaterialEntregado()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_REAVINUS_1.Click

        Try
            Dim frm_modificar As New frm_insertar_REAVINUS(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString()))
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
    Private Sub cmdELIMINAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_REAVINUS_1.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_REAVINUS

                If objdatos.fun_Eliminar_SECU_REAVINUS(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString())) Then
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
    Private Sub cmdCONSULTAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_REAVINUS_1.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_REVIAVAL(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarRevisionAvaluos()
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_INFOUSUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_REAVINUS_1.Click

        Try
            boCONSULTA = False
            pro_ReconsultarRevisionAvaluos()
            pro_ListaDeValoresRevisionAvaluos()

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

    Private Sub cmdAGREGAR_MATEENTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_REAVMAEN_1.Click

        Try
            Dim frm_modificar As New frm_insertar_REAVMAEN(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString()), Me.Name)
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
    Private Sub cmdMODIFICAR_MATEENTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_REAVMAEN_1.Click

        Try
            Dim frm_modificar As New frm_insertar_REAVMAEN(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString()), Me.Name)
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
    Private Sub cmdELIMINAR_MATEENTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_REAVMAEN_1.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_REAVMAEN

                If objdatos.fun_Eliminar_SECU_X_MACA_REAVMAEN(Integer.Parse(Me.dgvREAVMAEN.SelectedRows.Item(0).Cells("RAMESECU").Value.ToString()), _
                                                              Integer.Parse(Me.dgvREAVMAEN.SelectedRows.Item(0).Cells("RAMEMACA").Value.ToString())) Then
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
    Private Sub cmdCONSULTAR_MATEENTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_REAVMAEN_1.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_REVIAVAL(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarRevisionAvaluos()
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MATEENTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_REAVMAEN_1.Click

        Try
            boCONSULTA = False
            pro_ReconsultarRevisionAvaluos()
            pro_ListaDeValoresRevisionAvaluos()

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

    Private Sub cmdAGREGAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_REAVMAFA_1.Click

        Try
            Dim frm_modificar As New frm_insertar_REAVMAFA(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString()), Me.Name)
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
    Private Sub cmdMODIFICAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_REAVMAFA_1.Click

        Try
            Dim frm_modificar As New frm_insertar_REAVMAFA(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString()), Me.Name)
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
    Private Sub cmdELIMINAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_REAVMAFA_1.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_REAVMAFA

                If objdatos.fun_Eliminar_SECU_X_MACA_REAVMAFA(Integer.Parse(Me.dgvREAVMAFA.SelectedRows.Item(0).Cells("RAMFSECU").Value.ToString()), _
                                                              Integer.Parse(Me.dgvREAVMAFA.SelectedRows.Item(0).Cells("RAMFMACA").Value.ToString())) Then
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
    Private Sub cmdCONSULTAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_REAVMAFA_1.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_REVIAVAL(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarRevisionAvaluos()
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_MATEFALT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_REAVMAFA_1.Click

        Try
            boCONSULTA = False
            pro_ReconsultarRevisionAvaluos()
            pro_ListaDeValoresRevisionAvaluos()

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

    Private Sub cmdAGREGAR_TRABCAMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_REAVTRCA_1.Click

        Try
            Dim frm_modificar As New frm_insertar_REAVTRCA(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_Mensaje01()

            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_TRABCAMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_REAVTRCA_1.Click

        Try
            Dim frm_modificar As New frm_insertar_REAVTRCA(Integer.Parse(Me.dgvREAVTRCA.SelectedRows.Item(0).Cells("RATCIDRE").Value.ToString()), _
                                                                Integer.Parse(Me.dgvREAVTRCA.SelectedRows.Item(0).Cells("RATCSECU").Value.ToString()), _
                                                                Me.dgvREAVTRCA.SelectedRows.Item(0).Cells("RATCNUDO").Value.ToString())
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_Mensaje01()

            pro_ReconsultarTrabajoDeCampo()
            pro_ListaDeValoresTrabajoDeCampo()
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_TRABCAMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_REAVTRCA_1.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_REAVTRCA

                If objdatos.fun_Eliminar_IDRE_REAVTRCA(Integer.Parse(Me.dgvREAVTRCA.SelectedRows.Item(0).Cells("RATCIDRE").Value.ToString())) Then
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
    Private Sub cmdCONSULTAR_TRABCAMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_REAVTRCA_1.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_REVIAVAL(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarRevisionAvaluos()
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_TRABCAMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_REAVTRCA_1.Click

        Try
            boCONSULTA = False
            pro_ReconsultarRevisionAvaluos()
            pro_ListaDeValoresRevisionAvaluos()

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

    Private Sub cmdAGREGAR_TRABOFIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_REAVTROF_1.Click

        Try
            Dim frm_modificar As New frm_insertar_REAVTROF(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarTrabajoDeOficina()
            pro_ListaDeValoresTrabajoDeOficina()
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_TRABOFIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_REAVTROF_1.Click

        Try
            Dim frm_modificar As New frm_insertar_REAVTROF(Integer.Parse(Me.dgvREAVTROF.SelectedRows.Item(0).Cells("RATOIDRE").Value.ToString()), _
                                                           Integer.Parse(Me.dgvREAVTROF.SelectedRows.Item(0).Cells("RATOSECU").Value.ToString()), _
                                                           Me.dgvREAVTROF.SelectedRows.Item(0).Cells("RATONUDO").Value.ToString())
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_Mensaje01()

            pro_ReconsultarTrabajoDeOficina()
            pro_ListaDeValoresTrabajoDeOficina()
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_TRABOFIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_REAVTROF_1.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_REAVTROF

                If objdatos.fun_Eliminar_IDRE_REAVTROF(Integer.Parse(Me.dgvREAVTROF.SelectedRows.Item(0).Cells("RATOIDRE").Value.ToString())) Then
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
    Private Sub cmdCONSULTAR_TRABOFIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_REAVTROF_1.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_REVIAVAL(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarRevisionAvaluos()
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_TRABOFIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_REAVTROF_1.Click

        Try
            boCONSULTA = False
            pro_ReconsultarRevisionAvaluos()
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU ACTO ADMINISTRATIVO"

    Private Sub cmdAGREGAR_ACTOADMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_REAVACAD_1.Click

        Try
            Dim frm_modificar As New frm_insertar_REAVACAD(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString()))
            frm_modificar.ShowDialog()
            boCONSULTA = False

            pro_ReconsultarActoAdministrativo()
            pro_ListaDeValoresActoAdministrativo()

            pro_ListadoArchivosDocumentos()
            pro_ListadoArchivosResolucion()

            If Me.txtRAAANURA.Text <> "0" Then

                If MessageBox.Show("¿ Desea cambiar el estado del REAVamo ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    Me.cmdMODIFICAR_REVIAVAL_1.PerformClick()
                End If

            End If

            Me.tabMAESTRO_1.SelectTab(TabACTOADMI)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdMODIFICAR_ACTOADMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_REAVACAD_1.Click

        Try
            Dim frm_modificar As New frm_insertar_REAVACAD(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString()))
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
    Private Sub cmdELIMINAR_ACTOADMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_REAVACAD_1.Click

        Try
            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? ", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                Dim objdatos As New cla_REAVACAD

                If objdatos.fun_Eliminar_SECU_REAVACAD(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells("REAVSECU").Value.ToString())) Then
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
    Private Sub cmdCONSULTAR_ACTOADMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_REAVACAD_1.Click

        Try
            vp_inConsulta = 0

            Dim frm_consultar As New frm_consultar_REVIAVAL(Integer.Parse(Me.dgvREVIAVAL_1.SelectedRows.Item(0).Cells(0).Value.ToString()))
            frm_consultar.ShowDialog()

            If vp_inConsulta > 0 Then
                boCONSULTA = True
            Else
                boCONSULTA = False
            End If

            pro_ReconsultarRevisionAvaluos()
            pro_ListaDeValoresRevisionAvaluos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_ACTOADMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_REAVACAD_1.Click

        Try
            boCONSULTA = False
            pro_ReconsultarRevisionAvaluos()
            pro_ListaDeValoresRevisionAvaluos()

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
        pro_ReconsultarRevisionAvaluos()
        pro_ListadoArchivosDocumentos()
        pro_ListadoArchivosResolucion()

        Me.strBARRESTA.Items(0).Text = "Rectificaciones"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_REVIAVAL_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        pro_ListaDeValoresRevisionAvaluos()
    End Sub
    Private Sub dgvREVIAVAL_1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvREVIAVAL_1.GotFocus, dgvREVIAVAL_2.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvREVIAVAL_1.AccessibleDescription
    End Sub

#End Region

#Region "KeyDown"

    Private Sub dgvREVIAVAL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvREVIAVAL_1.KeyDown, dgvREVIAVAL_2.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================


        If e.KeyCode = Keys.F2 Then
            If Me.cmdAGREGAR_REVIAVAL_1.Enabled = True Then
                Me.cmdAGREGAR_REVIAVAL_1.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If Me.cmdMODIFICAR_REVIAVAL_1.Enabled = True Then
                Me.cmdMODIFICAR_REVIAVAL_1.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_REVIAVAL_1.Count

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
            If Me.cmdELIMINAR_REVIAVAL_1.Enabled = True Then
                Me.cmdELIMINAR_REVIAVAL_1.PerformClick()
            Else
                Dim ContarRegistros As Integer = Me.BindingSource_REVIAVAL_1.Count

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
            If Me.cmdCONSULTAR_REVIAVAL_1.Enabled = True Then
                Me.cmdCONSULTAR_REVIAVAL_1.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If Me.cmdCONSULTAR_REVIAVAL_1.Enabled = True Then
                Me.cmdRECONSULTAR_REVIAVAL_1.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

    End Sub

#End Region

#Region "KeyUp"

    Private Sub dgvREVIAVAL_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvREVIAVAL_1.KeyUp, dgvREVIAVAL_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresRevisionAvaluos()
        End If
    End Sub

#End Region

#Region "CellClick"

    Private Sub dgvREVIAVAL_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvREVIAVAL_1.CellClick, dgvREVIAVAL_2.CellClick
        pro_ListaDeValoresRevisionAvaluos()
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