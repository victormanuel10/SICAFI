Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_FICHPRED

    '================================
    '*** FORMULARIO FICHA PREDIAL ***
    '================================

#Region "CONSTRUCTORES"

    Public Sub New(ByVal id As Integer)
        vp_FichaPredial = id
        InitializeComponent()
    End Sub
    Public Sub New(ByVal tbl As DataTable)
        vp_tblConsulta = tbl
        InitializeComponent()
    End Sub

#End Region

#Region "VARIABLES LOCALES"

    Dim id As Integer
    Dim tbl As DataTable

    ' Almacena que tipo de calificación para el form insertar codigo de calificación
    Dim stFPCCTIPO As String

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

    ' variable resolución concatenada
    Dim vl_stFIPRCORE As String

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_FICHPRED
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_FICHPRED
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

#Region "PROCEDIMIENTOS RESOLUCION"

    Public Sub pro_inicializarControlesResolucion()

        '=================
        ' CARGA LOS CAMPOS 
        '=================

        Dim objdatos3 As New cla_RESOLUCION
        Dim tbl As New DataTable

        tbl = objdatos3.fun_Buscar_ID_RESOLUCION(vp_FichaPredial)

        Me.txtRESODEPA.Text = Trim(tbl.Rows(0).Item("RESODEPA"))
        Me.txtRESOMUNI.Text = Trim(tbl.Rows(0).Item("RESOMUNI"))
        Me.txtRESOTIRE.Text = Trim(tbl.Rows(0).Item("RESOTIRE"))
        Me.txtRESOCLSE.Text = Trim(tbl.Rows(0).Item("RESOCLSE"))
        Me.txtRESOVIGE.Text = Trim(tbl.Rows(0).Item("RESOVIGE"))
        Me.txtRESOCODI.Text = Trim(tbl.Rows(0).Item("RESOCODI"))
        Me.lblRESODESC.Text = Trim(tbl.Rows(0).Item("RESODESC"))

        '=====================
        ' CARGA LA DESCRIPCIÓN 
        '=====================

        Try
            Dim boDEPARTAM As Boolean = fun_Buscar_Dato_DEPARTAMENTO(Me.txtRESODEPA.Text)
            Dim boMUNICIPI As Boolean = fun_Buscar_Dato_MUNICIPIO(Me.txtRESODEPA.Text, Me.txtRESOMUNI.Text)
            Dim boTIPORESO As Boolean = fun_Buscar_Dato_TIPORESU(Me.txtRESOTIRE.Text)
            Dim boCLASSECT As Boolean = fun_Buscar_Dato_CLASSECT(Me.txtRESOCLSE.Text)
            Dim boVIGENCIA As Boolean = fun_Buscar_Dato_VIGENCIA(Me.txtRESOVIGE.Text)


            If boDEPARTAM = True AndAlso boMUNICIPI = True AndAlso boTIPORESO = True AndAlso _
               boCLASSECT = True AndAlso boVIGENCIA = True Then

                Me.lblRESODEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Me.txtRESODEPA.Text), String)
                Me.lblRESOMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Me.txtRESODEPA.Text, Me.txtRESOMUNI.Text), String)
                Me.lblRESOTIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO(Me.txtRESOTIRE.Text), String)
                Me.lblRESOCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Me.txtRESOCLSE.Text), String)
                Me.lblRESOVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Me.txtRESOVIGE.Text), String)

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        BindingNavigator_FICHPRED_1.Focus()

    End Sub
    Public Sub pro_listaDeValoresResolucion()

        '=====================
        ' CARGA LA DESCRIPCIÓN 
        '=====================

        Try
            'BUSCA EL DEPARTAMENTO

            Dim objdatos4 As New cla_DEPARTAMENTO
            Dim tbl_Departamento As New DataTable
            Dim id_Departamento As String = Me.txtRESODEPA.Text

            tbl_Departamento = objdatos4.fun_Buscar_CODIGO_MANT_DEPARTAMENTO(id_Departamento)

            'BUSCA EL MUNICIPIO POR DEPARTAMENTO

            Dim objdatos20 As New cla_MUNICIPIO
            Dim tbl_Municipio As New DataTable
            Dim idDepa As String = Me.txtRESODEPA.Text
            Dim idMunicipio As String = Me.txtRESOMUNI.Text

            tbl_Municipio = objdatos20.fun_Buscar_DEPARTAMENTO_Y_CODIGO_MANT_MUNICIPIO(idDepa, idMunicipio)

            'BUSCA EL TIPO DE RESOLUCIÓN

            Dim objdatos6 As New cla_TIPORESO
            Dim tbl_TipoResolucion As New DataTable
            Dim id_TipoResolucion As Integer = Val(Me.txtRESOTIRE.Text)

            tbl_TipoResolucion = objdatos6.fun_Buscar_CODIGO_MANT_TIPORESO(id_TipoResolucion)

            'BUSCA LA CLASE O SECTOR

            Dim objdatos10 As New cla_CLASSECT
            Dim tbl_ClaseoSector As New DataTable
            Dim id_ClaseoSector As Integer = Val(Me.txtRESOCLSE.Text)

            tbl_ClaseoSector = objdatos10.fun_Buscar_CODIGO_MANT_CLASSECT(id_ClaseoSector)

            'BUSCA LA VIGENCIA

            Dim objdatos12 As New cla_VIGENCIA
            Dim tbl_Vigencia As New DataTable
            Dim id_Vigencia As Integer = Val(Me.txtRESOVIGE.Text)

            tbl_Vigencia = objdatos12.fun_Buscar_CODIGO_VIGENCIA(id_Vigencia)

            'VERIFICA QUE ESTEN LLENOS LAS LISTAS DE VALORES
            If tbl_Departamento.Rows.Count <> 0 Or _
               tbl_Municipio.Rows.Count <> 0 Or _
               tbl_Vigencia.Rows.Count <> 0 Or _
               tbl_TipoResolucion.Rows.Count <> 0 Or _
               tbl_ClaseoSector.Rows.Count <> 0 Then

                Me.lblRESODEPA.Text = tbl_Departamento.Rows(0).Item("DEPADESC")
                Me.lblRESOMUNI.Text = tbl_Municipio.Rows(0).Item("MUNIDESC")
                Me.lblRESOTIRE.Text = tbl_TipoResolucion.Rows(0).Item("TIREDESC")
                Me.lblRESOCLSE.Text = tbl_ClaseoSector.Rows(0).Item("CLSEDESC")
                Me.lblRESOVIGE.Text = tbl_Vigencia.Rows(0).Item("VIGEDESC")

            Else
                frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
            End If


        Catch ex As Exception
            frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
        End Try

        BindingNavigator_FICHPRED_1.Focus()

    End Sub

#End Region

#Region "PROCEDIMIENTOS FICHA PREDIAL"

    Private Sub pro_ReconsultarFichaPredialxFichaPredial()

        Try

            Dim objdatos As New cla_FICHPRED
            Dim tbl_FICHPRED As New DataTable

            BindingSource_FICHPRED_1.DataSource = objdatos.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(vp_FichaPredial)
            tbl_FICHPRED = BindingSource_FICHPRED_1.DataSource
            BindingNavigator_FICHPRED_1.BindingSource = BindingSource_FICHPRED_1

            strBARRESTA.Items(2).Text = "Registros : " & BindingSource_FICHPRED_1.Count
            Dim ContarRegistros As Integer = BindingSource_FICHPRED_1.Count

            If ContarRegistros > 0 Then

                txtFIPRNUFI.Text = Trim(tbl_FICHPRED.Rows(0).Item(1))
                'txtFIPRVIGE.Text = Trim(tbl_FICHPRED.Rows(0).Item(2))
                'txtFIPRTIRE.Text = Trim(tbl_FICHPRED.Rows(0).Item(3))
                'txtFIPRRESO.Text = Trim(tbl_FICHPRED.Rows(0).Item(4))
                txtFIPRDIRE.Text = Trim(tbl_FICHPRED.Rows(0).Item(5))
                txtFIPRDESC.Text = Trim(tbl_FICHPRED.Rows(0).Item(6))
                chkFIPRCONJ.Checked = tbl_FICHPRED.Rows(0).Item(7)
                txtFIPRFECH.Text = Trim(tbl_FICHPRED.Rows(0).Item(8))
                txtFIPRNURE.Text = Trim(tbl_FICHPRED.Rows(0).Item(9))
                'txtFIPRDEPA.Text = Trim(tbl_FICHPRED.Rows(0).Item(10))
                txtFIPRMUNI.Text = Trim(tbl_FICHPRED.Rows(0).Item(11))
                txtFIPRCORR.Text = Trim(tbl_FICHPRED.Rows(0).Item(12))
                txtFIPRBARR.Text = Trim(tbl_FICHPRED.Rows(0).Item(13))
                txtFIPRMANZ.Text = Trim(tbl_FICHPRED.Rows(0).Item(14))
                txtFIPRPRED.Text = Trim(tbl_FICHPRED.Rows(0).Item(15))
                txtFIPREDIF.Text = Trim(tbl_FICHPRED.Rows(0).Item(16))
                txtFIPRUNPR.Text = Trim(tbl_FICHPRED.Rows(0).Item(17))
                txtFIPRCLSE.Text = Trim(tbl_FICHPRED.Rows(0).Item(18))
                txtFIPRCASU.Text = Trim(tbl_FICHPRED.Rows(0).Item(19))
                txtFIPRMUAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(20))
                txtFIPRCOAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(21))
                txtFIPRBAAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(22))
                txtFIPRMAAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(23))
                txtFIPRPRAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(24))
                txtFIPREDAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(25))
                txtFIPRUPAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(26))
                txtFIPRCSAN.Text = Trim(tbl_FICHPRED.Rows(0).Item(27))
                txtFIPRCASA.Text = Trim(tbl_FICHPRED.Rows(0).Item(28))
                txtFIPRCAPR.Text = Trim(tbl_FICHPRED.Rows(0).Item(29))
                txtFIPRMOAD.Text = Trim(tbl_FICHPRED.Rows(0).Item(30))
                txtFIPRARTE.Text = Trim(tbl_FICHPRED.Rows(0).Item(31))
                txtFIPRCOPR.Text = Trim(tbl_FICHPRED.Rows(0).Item(32))
                txtFIPRCOED.Text = Trim(tbl_FICHPRED.Rows(0).Item(33))
                cboFIPRESTA.SelectedValue = tbl_FICHPRED.Rows(0).Item(34)
                txtFIPRCECA.Text = Trim(tbl_FICHPRED.Rows(0).Item(35))
                txtFIPRDATR.Text = Trim(tbl_FICHPRED.Rows(0).Item(36))
                txtFIPRDAVI.Text = Trim(tbl_FICHPRED.Rows(0).Item(37))
                txtFIPRDAND.Text = Trim(tbl_FICHPRED.Rows(0).Item(38))
                txtFIPRCORE.Text = Trim(tbl_FICHPRED.Rows(0).Item(39))
                txtFIPRUSIN.Text = Trim(tbl_FICHPRED.Rows(0).Item(40))
                txtFIPRUSMO.Text = Trim(tbl_FICHPRED.Rows(0).Item(41))
                txtFIPRFEIN.Text = Trim(tbl_FICHPRED.Rows(0).Item(42))
                txtFIPRFEMO.Text = Trim(tbl_FICHPRED.Rows(0).Item(43))
                txtFIPRMAQU.Text = Trim(tbl_FICHPRED.Rows(0).Item(44))
                txtFIPROBSE.Text = Trim(tbl_FICHPRED.Rows(0).Item(45))
                chkFIPRLITI.Checked = tbl_FICHPRED.Rows(0).Item(46)
                txtFIPRPOLI.Text = Trim(tbl_FICHPRED.Rows(0).Item(47))
                chkFIPRINCO.Checked = tbl_FICHPRED.Rows(0).Item(49)

                If Trim(Me.txtFIPRMOAD.Text) <> "3" Then
                    Me.lblModoAdquisicionPropietario.Visible = False
                    Me.txtFPPRMOAD.Visible = False
                    Me.lblFPPRMOAD.Visible = False
                Else
                    Me.lblModoAdquisicionPropietario.Visible = True
                    Me.txtFPPRMOAD.Visible = True
                    Me.lblFPPRMOAD.Visible = True
                End If

                '==================
                ' FORMATO DE CAMPOS
                '==================

                txtFIPRPOLI.Text = fun_Formato_Decimal_2_Decimales(txtFIPRPOLI.Text)
                txtFIPRCOED.Text = fun_Formato_Decimal_6_Decimales(txtFIPRCOED.Text)
                txtFIPRCOPR.Text = fun_Formato_Decimal_6_Decimales(txtFIPRCOPR.Text)

            End If

            If Trim(txtFIPRNUFI.Text) <> 0 Then
                lblCECANUFI.Text = txtFIPRNUFI.Text
                lblCECAMUNI.Text = txtFIPRMUNI.Text
                lblCECACORR.Text = txtFIPRCORR.Text
                lblCECABARR.Text = txtFIPRBARR.Text
                lblCECAMANZ.Text = txtFIPRMANZ.Text
                lblCECAPRED.Text = txtFIPRPRED.Text
                lblCECAEDIF.Text = txtFIPREDIF.Text
                lblCECAUNPR.Text = txtFIPRUNPR.Text
            Else
                lblCECANUFI.Text = ""
                lblCECAMUNI.Text = ""
                lblCECACORR.Text = ""
                lblCECABARR.Text = ""
                lblCECAMANZ.Text = ""
                lblCECAPRED.Text = ""
                lblCECAEDIF.Text = ""
                lblCECAUNPR.Text = ""
            End If

            '==================================================
            '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
            '==================================================

            Dim objdatos1 As New cla_CONTRASENA
            Dim tbl1 As New DataTable

            tbl1 = objdatos1.fun_Buscar_USUARIO_CONTRASENA(vp_usuario)

            Dim boCONTAGRE As Boolean = Trim(tbl1.Rows(0).Item(5))
            Dim boCONTMODI As Boolean = Trim(tbl1.Rows(0).Item(6))
            Dim boCONTELIM As Boolean = Trim(tbl1.Rows(0).Item(7))

            If boCONTAGRE = True Then
                cmdAGREGAR_FICHPRED.Enabled = True
            Else
                cmdAGREGAR_FICHPRED.Enabled = False
            End If

            If ContarRegistros = 0 Then
                cmdMODIFICAR_FICHPRED.Enabled = False
            Else
                If boCONTMODI = True Then
                    cmdMODIFICAR_FICHPRED.Enabled = True
                Else
                    cmdMODIFICAR_FICHPRED.Enabled = False
                End If
            End If

            If ContarRegistros = 0 Then
                cmdELIMINAR_FICHPRED.Enabled = False
            Else
                If boCONTELIM = True Then
                    cmdELIMINAR_FICHPRED.Enabled = True
                Else
                    cmdELIMINAR_FICHPRED.Enabled = False
                End If
            End If

            Dim RegistrosExistentes As DataTable = objdatos.fun_Consultar_FICHPRED

            If RegistrosExistentes.Rows.Count = 0 Then
                cmdCONSULTAR_FICHPRED.Enabled = False
            Else
                cmdCONSULTAR_FICHPRED.Enabled = True
            End If

            If ContarRegistros = 0 Then
                cmdRECONSULTAR_FICHPRED.Enabled = False
            Else
                cmdRECONSULTAR_FICHPRED.Enabled = True
            End If

            BindingNavigator_FICHPRED_1.Focus()

            ' PERMISOS DE INTERVENTORIA
            If Trim(Me.txtRESOTIRE.Text) = "185" Then
                Me.cmdAGREGAR_FICHPRED.Enabled = False
                Me.cmdMODIFICAR_FICHPRED.Enabled = False
                Me.cmdELIMINAR_FICHPRED.Enabled = False
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_AsignarPermisosFichaPredial()
        '==================================================
        '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
        '==================================================
        Try
            Dim objdatos As New cla_FICHPRED
            Dim objdatos1 As New cla_CONTRASENA
            Dim tbl1 As New DataTable

            tbl1 = objdatos1.fun_Buscar_USUARIO_CONTRASENA(vp_usuario)

            Dim boCONTAGRE As Boolean = Trim(tbl1.Rows(0).Item(5))
            Dim boCONTMODI As Boolean = Trim(tbl1.Rows(0).Item(6))
            Dim boCONTELIM As Boolean = Trim(tbl1.Rows(0).Item(7))

            Dim ContarRegistros As Integer = 0


            If boCONTAGRE = True Then
                cmdAGREGAR_FICHPRED.Enabled = True
            Else
                cmdAGREGAR_FICHPRED.Enabled = False
            End If

            If ContarRegistros = 0 Then
                cmdMODIFICAR_FICHPRED.Enabled = False
            Else
                If boCONTMODI = True Then
                    cmdMODIFICAR_FICHPRED.Enabled = True
                Else
                    cmdMODIFICAR_FICHPRED.Enabled = False
                End If
            End If

            If ContarRegistros = 0 Then
                cmdELIMINAR_FICHPRED.Enabled = False
            Else
                If boCONTELIM = True Then
                    cmdELIMINAR_FICHPRED.Enabled = True
                Else
                    cmdELIMINAR_FICHPRED.Enabled = False
                End If
            End If

            Dim RegistrosExistentes As DataTable = objdatos.fun_Consultar_FICHPRED

            If RegistrosExistentes.Rows.Count > 0 Then
                cmdCONSULTAR_FICHPRED.Enabled = True
            Else
                cmdCONSULTAR_FICHPRED.Enabled = False
            End If

            If Trim(txtFIPRNUFI.Text) = "" Then
                cmdRECONSULTAR_FICHPRED.Enabled = False
            Else
                cmdRECONSULTAR_FICHPRED.Enabled = True
            End If

            '=============================================
            '*** CONFIGURACIÓN DE PESTAÑAS SECUNDARIAS ***
            '=============================================

            BindingNavigator_FIPRDEEC_1.Enabled = False
            BindingNavigator_FIPRPROP_1.Enabled = False
            BindingNavigator_FIPRCONS_1.Enabled = False
            BindingNavigator_FIPRCACO_1.Enabled = False
            BindingNavigator_FIPRLIND_1.Enabled = False
            BindingNavigator_FIPRCART_1.Enabled = False
            BindingNavigator_FIPRZOEC_1.Enabled = False
            BindingNavigator_FIPRZOFI_1.Enabled = False

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresFichaPredial()

        '===========================================
        'CARGA LA DESCRIPCION DE LA LISTA DE VALORES
        '===========================================
        Try
            If Trim(txtFIPRNUFI.Text) <> "" Then

                Me.lblFIPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(txtFIPRCLSE.Text)), String)
                Me.lblFIPRCSAN.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(txtFIPRCSAN.Text)), String)
                Me.lblFIPRCASU.Text = CType(fun_Buscar_Lista_Valores_CATESUEL(Trim(txtFIPRCASU.Text)), String)
                Me.lblFIPRCASA.Text = CType(fun_Buscar_Lista_Valores_CATESUEL(Trim(txtFIPRCASA.Text)), String)
                Me.lblFIPRCAPR.Text = CType(fun_Buscar_Lista_Valores_CARAPRED(Trim(txtFIPRCAPR.Text)), String)
                Me.lblFIPRMOAD.Text = CType(fun_Buscar_Lista_Valores_MODOADQU(Trim(txtFIPRMOAD.Text)), String)
                Me.lblFIPRMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Trim(txtFIPRCORE.Text).Substring(0, 2), Trim(txtFIPRMUNI.Text)), String)
                Me.lblFIPRMUAN.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Trim(txtFIPRCORE.Text).Substring(0, 2), Trim(txtFIPRMUAN.Text)), String)

                Me.lblFIPRCORR.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO(Trim(Me.txtRESODEPA.Text), Trim(Me.txtFIPRMUNI.Text), Trim(Me.txtFIPRCLSE.Text), Trim(Me.txtFIPRCORR.Text)), String)
                Me.lblFIPRCOAN.Text = CType(fun_Buscar_Lista_Valores_CORREGIMIENTO(Trim(Me.txtRESODEPA.Text), Trim(Me.txtFIPRMUAN.Text), Trim(Me.txtFIPRCSAN.Text), Trim(Me.txtFIPRCOAN.Text)), String)

                If Trim(Me.txtFIPRCLSE.Text) = 1 Then
                    Me.lblFIPRBARR.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Trim(Me.txtRESODEPA.Text), Trim(Me.txtFIPRMUNI.Text), Trim(Me.txtFIPRCLSE.Text), Trim(Me.txtFIPRBARR.Text), Trim(Me.txtFIPRCORR.Text)), String)
                ElseIf Trim(Me.txtFIPRCLSE.Text) = 2 Then
                    Me.lblFIPRBARR.Text = CType(fun_Buscar_Lista_Valores_VEREDA(Trim(Me.txtRESODEPA.Text), Trim(Me.txtFIPRMUNI.Text), Trim(Me.txtFIPRCLSE.Text), Trim(Me.txtFIPRMANZ.Text), Trim(Me.txtFIPRCORR.Text)), String)
                ElseIf Trim(Me.txtFIPRCLSE.Text) = 3 Then
                    Me.lblFIPRBARR.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Trim(Me.txtRESODEPA.Text), Trim(Me.txtFIPRMUNI.Text), Trim(Me.txtFIPRCLSE.Text), Trim(Me.txtFIPRBARR.Text), Trim(Me.txtFIPRCORR.Text)), String)
                End If

                If Trim(Me.txtFIPRCSAN.Text) = 1 Then
                    Me.lblFIPRBAAN.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Trim(Me.txtRESODEPA.Text), Trim(Me.txtFIPRMUAN.Text), Trim(Me.txtFIPRCSAN.Text), Trim(Me.txtFIPRBAAN.Text), Trim(Me.txtFIPRCORR.Text)), String)
                ElseIf Trim(Me.txtFIPRCSAN.Text) = 2 Then
                    Me.lblFIPRBAAN.Text = CType(fun_Buscar_Lista_Valores_VEREDA(Trim(Me.txtRESODEPA.Text), Trim(Me.txtFIPRMUAN.Text), Trim(Me.txtFIPRCSAN.Text), Trim(Me.txtFIPRMAAN.Text), Trim(Me.txtFIPRCORR.Text)), String)
                ElseIf Trim(Me.txtFIPRCSAN.Text) = 3 Then
                    Me.lblFIPRBAAN.Text = CType(fun_Buscar_Lista_Valores_BARRIO(Trim(Me.txtRESODEPA.Text), Trim(Me.txtFIPRMUAN.Text), Trim(Me.txtFIPRCSAN.Text), Trim(Me.txtFIPRBAAN.Text), Trim(Me.txtFIPRCORR.Text)), String)
                End If

            Else
                pro_LimpiarCamposFichaPredial()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        If Trim(txtFIPRUSMO.Text) = "" Then
            txtFIPRFEMO.Text = ""
        End If

    End Sub
    Private Sub pro_LimpiarCamposFichaPredial()

        txtFIPRNUFI.Text = ""
        txtFIPRDIRE.Text = ""
        txtFIPRDESC.Text = ""
        txtFIPRMUNI.Text = ""
        txtFIPRCORR.Text = ""
        txtFIPRBARR.Text = ""
        txtFIPRMANZ.Text = ""
        txtFIPRPRED.Text = ""
        txtFIPREDIF.Text = ""
        txtFIPRUNPR.Text = ""
        txtFIPRCLSE.Text = ""
        txtFIPRCASU.Text = ""
        txtFIPRMUAN.Text = ""
        txtFIPRCOAN.Text = ""
        txtFIPRBAAN.Text = ""
        txtFIPRMAAN.Text = ""
        txtFIPRPRAN.Text = ""
        txtFIPREDAN.Text = ""
        txtFIPRUPAN.Text = ""
        txtFIPRCSAN.Text = ""
        txtFIPRCASA.Text = ""
        txtFIPRCAPR.Text = ""
        txtFIPRMOAD.Text = ""
        txtFIPRARTE.Text = ""
        txtFIPRCOED.Text = ""
        txtFIPRCOPR.Text = ""
        cboFIPRESTA.Text = ""
        txtFIPRUSIN.Text = ""
        txtFIPRUSMO.Text = ""
        txtFIPRFEIN.Text = ""
        txtFIPRFEMO.Text = ""
        txtFIPROBSE.Text = ""
        lblFIPRBAAN.Text = ""
        lblFIPRBARR.Text = ""
        lblFIPRCAPR.Text = ""
        lblFIPRCASA.Text = ""
        lblFIPRCASU.Text = ""
        lblFIPRCLSE.Text = ""
        lblFIPRCOAN.Text = ""
        lblFIPRCORR.Text = ""
        lblFIPRCSAN.Text = ""
        lblFIPRMOAD.Text = ""
        lblFIPRMUAN.Text = ""
        lblFIPRMUNI.Text = ""
        lblCECANUFI.Text = ""
        lblCECAMUNI.Text = ""
        lblCECACORR.Text = ""
        lblCECABARR.Text = ""
        lblCECAMANZ.Text = ""
        lblCECAPRED.Text = ""
        lblCECAEDIF.Text = ""
        lblCECAUNPR.Text = ""
        txtFIPRMAQU.Text = ""
        txtFIPRFECH.Text = ""
        txtFIPRCECA.Text = ""
        txtFIPRCORE.Text = ""
        txtFIPRNURE.Text = ""

    End Sub
    Private Sub pro_inicializarControles()
        '=========================================
        ' CARGA LOS COMBOBOX CON LOS DATOS ACTIVOS
        '=========================================

        Dim objdatos7 As New cla_ESTADO

        cboFIPRESTA.DataSource = objdatos7.fun_Consultar_TODOS_LOS_ESTADOS
        cboFIPRESTA.DisplayMember = "ESTADESC"
        cboFIPRESTA.ValueMember = "ESTACODI"

    End Sub
    Private Sub pro_ObtenerResolucionCancatenada()

        Dim stRESODEPA_CODI As String = Trim(Me.txtRESODEPA.Text)
        Dim stRESOMUNI_CODI As String = Trim(Me.txtRESOMUNI.Text)
        Dim stRESOTIRE_CODI As String = Trim(Me.txtRESOTIRE.Text)
        Dim stRESOCLSE_CODI As String = Trim(Me.txtRESOCLSE.Text)
        Dim stRESOVIGE_CODI As String = Trim(Me.txtRESOVIGE.Text)
        Dim stRESORESO_CODI As String = Trim(Me.txtRESOCODI.Text)

        stRESODEPA_CODI = stRESODEPA_CODI.PadLeft(2, "0")
        stRESODEPA_CODI = stRESODEPA_CODI.Substring(0, 2)

        stRESOMUNI_CODI = stRESOMUNI_CODI.PadLeft(3, "0")
        stRESOMUNI_CODI = stRESOMUNI_CODI.Substring(0, 3)

        stRESOTIRE_CODI = stRESOTIRE_CODI.PadLeft(3, "0")
        stRESOTIRE_CODI = stRESOTIRE_CODI.Substring(0, 3)

        stRESOCLSE_CODI = stRESOCLSE_CODI.PadLeft(1, "0")
        stRESOCLSE_CODI = stRESOCLSE_CODI.Substring(0, 1)

        stRESOVIGE_CODI = stRESOVIGE_CODI.PadLeft(4, "0")
        stRESOVIGE_CODI = stRESOVIGE_CODI.Substring(0, 4)

        stRESORESO_CODI = stRESORESO_CODI.PadLeft(7, "0")
        stRESORESO_CODI = stRESORESO_CODI.Substring(0, 7)

        vl_stFIPRCORE = stRESODEPA_CODI & stRESOMUNI_CODI & stRESOTIRE_CODI & stRESOCLSE_CODI & stRESOVIGE_CODI & stRESORESO_CODI

    End Sub
    Private Sub pro_ValidarFichaPredial()

        Try
            If Trim(txtFIPRNUFI.Text) = "" Then
                MessageBox.Show("Selecione una ficha predial", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim objdatos As New cla_VALIFIPR
                Dim dt As DataTable

                ' Valida la ficha predial
                pro_VALIDAR_CRITICA_FICHA_PREDIAL(Trim(txtFIPRNUFI.Text))

                ' Almacena las inconsistencias
                dt = objdatos.fun_Consultar_INCONSISTENCIA_X_FICHA_PREDIAL(Trim(txtFIPRNUFI.Text))

                ' Verifica si existen fichas inconsistentes
                If dt.Rows.Count > 0 Then
                    Dim frm_FIPRINCO As New frm_FIPRINCO(Trim(txtFIPRNUFI.Text))
                    frm_FIPRINCO.ShowDialog()
                    chkFIPRINCO.Checked = True
                Else
                    MessageBox.Show("Ficha diligenciada correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    chkFIPRINCO.Checked = False
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "PROCEDIMIENTOS DESTINO ECONOMICO"

    Private Sub pro_ReconsultarDestinoEconomico()
        Try
            '*** Reconsulte destino si ficha predial tiene registros
            If BindingSource_FICHPRED_1.Count > 0 Then

                BindingNavigator_FIPRDEEC_1.Enabled = True

                Dim objdatos As New cla_FIPRDEEC

                Me.BindingSource_FIPRDEEC_1.DataSource = objdatos.fun_Consultar_FIPRDEEC(Val(txtFIPRNUFI.Text))
                Me.dgvFIPRDEEC.DataSource = BindingSource_FIPRDEEC_1.DataSource
                Me.BindingNavigator_FIPRDEEC_1.BindingSource = BindingSource_FIPRDEEC_1

                Me.dgvFIPRDEEC.Columns(0).Visible = False
                Me.dgvFIPRDEEC.Columns(1).Visible = False

                Me.dgvFIPRDEEC.Columns(2).Width = 150
                Me.dgvFIPRDEEC.Columns(3).Width = 350
                Me.dgvFIPRDEEC.Columns(4).Width = 100

                Dim ContarRegistros As Integer = BindingSource_FIPRDEEC_1.Count

                '====================================================
                '*** LLENA LOS CAMPOS DE LA DESTINACION ECONOMICA ***
                '====================================================

                Dim tbl10 As New DataTable

                tbl10 = objdatos.fun_Consultar_FIPRDEEC(Val(txtFIPRNUFI.Text))

                If tbl10.Rows.Count > 0 Then

                    lblFPDEIDRE.Text = Trim(tbl10.Rows(0).Item(0))
                    lblFPDESECU.Text = Trim(tbl10.Rows(0).Item(1))
                    txtFPDEDEEC.Text = Trim(tbl10.Rows(0).Item(2))
                    lblFPDEDESC.Text = Trim(tbl10.Rows(0).Item(3))
                    txtFPDEPORC.Text = Trim(tbl10.Rows(0).Item(4))

                    '===================================================
                    '*** SUMA EL PORCENTAJE DE DESTINACION ECONOMICA ***
                    '===================================================

                  pro_SumarPorcentajeDestinoEconomico

                End If

                '==================================================
                '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
                '==================================================

                Dim objdatos1 As New cla_CONTRASENA
                Dim tbl1 As New DataTable

                tbl1 = objdatos1.fun_Buscar_USUARIO_CONTRASENA(vp_usuario)

                Dim boCONTAGRE As Boolean = Trim(tbl1.Rows(0).Item(5))
                Dim boCONTMODI As Boolean = Trim(tbl1.Rows(0).Item(6))
                Dim boCONTELIM As Boolean = Trim(tbl1.Rows(0).Item(7))

                If boCONTAGRE = True Then
                    cmdAGREGAR_FIPRDEEC.Enabled = True
                Else
                    cmdAGREGAR_FIPRDEEC.Enabled = False
                End If

                If ContarRegistros = 0 Then
                    cmdMODIFICAR_FIPRDEEC.Enabled = False
                Else
                    If boCONTMODI = True Then
                        cmdMODIFICAR_FIPRDEEC.Enabled = True
                    Else
                        cmdMODIFICAR_FIPRDEEC.Enabled = False
                    End If
                End If

                If ContarRegistros = 0 Then
                    cmdELIMINAR_FIPRDEEC.Enabled = False
                Else
                    If boCONTELIM = True Then
                        cmdELIMINAR_FIPRDEEC.Enabled = True
                    Else
                        cmdELIMINAR_FIPRDEEC.Enabled = False
                    End If
                End If

                If ContarRegistros = 0 Then
                    cmdCONSULTAR_FIPRDEEC.Enabled = False
                Else
                    cmdCONSULTAR_FIPRDEEC.Enabled = True
                End If

                If ContarRegistros = 0 Then
                    cmdRECONSULTAR_FIPRDEEC.Enabled = False
                Else
                    cmdRECONSULTAR_FIPRDEEC.Enabled = True
                End If

                ' PERMISOS DE INTERVENTORIA
                If Trim(Me.txtRESOTIRE.Text) = "185" Then
                    Me.cmdAGREGAR_FIPRDEEC.Enabled = False
                    Me.cmdMODIFICAR_FIPRDEEC.Enabled = False
                    Me.cmdELIMINAR_FIPRDEEC.Enabled = False
                End If

            Else
                BindingNavigator_FIPRDEEC_1.Enabled = False
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresDestinoEconomico()
        '============================================================
        'Verifica si existen registros para traer la lista de valores
        '============================================================

        If BindingSource_FIPRDEEC_1.Count > 0 Then

            '=============================
            'Carga los datos en los campos
            '=============================
            Try
                Dim objdatos As New cla_FIPRDEEC
                Dim tbl As New DataTable

                Dim id As Integer = (Integer.Parse(dgvFIPRDEEC.CurrentRow.Cells(0).Value.ToString()))
                'Dim id As Integer = (Integer.Parse(lblFPDEIDRE.Text))

                tbl = objdatos.fun_Buscar_ID_FIPRDEEC(id)

                lblFPDEIDRE.Text = Trim(tbl.Rows(0).Item(0))
                lblFPDESECU.Text = Trim(tbl.Rows(0).Item(10))
                txtFPDEDEEC.Text = Trim(tbl.Rows(0).Item(2))
                txtFPDEPORC.Text = Trim(tbl.Rows(0).Item(3))

                '===========================================
                'CARGA LA DESCRIPCIÓN DE LA LISTA DE VALORES
                '===========================================

                lblFPDEDESC.Text = CType(fun_Buscar_Lista_Valores_DESTECON(txtFPDEDEEC.Text), String)

                '=============================================
                'SUMA EL PORCENTAJE DE LOS REGISTROS CARGADOS
                '=============================================

                'Dim objdatos2 As New cla_FIPRDEEC
                'Dim tbl1 As New DataTable

                'tbl1 = objdatos2.fun_Consultar_SUMA_X_FPDEDEEC_FIPRDEEC(Val(txtFIPRNUFI.Text))

                'lblFPDETOTA.Text = Trim(tbl1.Rows(0).Item(0))

            Catch ex As Exception
                MessageBox.Show(Err.Description & "lista de valores")
            End Try

        End If

    End Sub
    Private Sub pro_LimpiarCamposDestinoEconomico()

        lblFPDEIDRE.Text = ""
        lblFPDESECU.Text = ""
        txtFPDEDEEC.Text = ""
        lblFPDEDESC.Text = ""
        txtFPDEPORC.Text = ""
        lblFPDETOTA.Text = ""

    End Sub
    Private Sub pro_SumarPorcentajeDestinoEconomico()
        Dim objdatos2 As New cla_FIPRDEEC
        Dim tbl1 As New DataTable

        tbl1 = objdatos2.fun_Consultar_SUMA_X_FPDEPORC_FIPRDEEC(Val(txtFIPRNUFI.Text))

        Dim i As Integer
        Dim inTOTAL As Integer

        If tbl1.Rows.Count > 0 Then

            For i = 0 To tbl1.Rows.Count - 1
                inTOTAL += Trim(tbl1.Rows(i).Item("FPDEPORC"))
            Next

        End If

        lblFPDETOTA.Text = inTOTAL.ToString

    End Sub

#End Region

#Region "PROCEDIMIENTOS PROPIETARIO"

    Private Sub pro_ReconsultarPropietario()
        Try
            ' reconsulte si ficha predial tiene registros
            If BindingSource_FICHPRED_1.Count > 0 Then

                ' activa el navegador
                BindingNavigator_FIPRPROP_1.Enabled = True

                Dim objdatos As New cla_FIPRPROP

                BindingSource_FIPRPROP_1.DataSource = objdatos.fun_Consultar_FIPRPROP(Val(txtFIPRNUFI.Text))
                dgvFIPRPROP.DataSource = BindingSource_FIPRPROP_1.DataSource
                BindingNavigator_FIPRPROP_1.BindingSource = BindingSource_FIPRPROP_1

                dgvFIPRPROP.Columns(0).Visible = False
                dgvFIPRPROP.Columns(1).Visible = False
                dgvFIPRPROP.Columns(2).Visible = False
                dgvFIPRPROP.Columns(3).Visible = False

                Me.dgvFIPRPROP.Columns(4).Width = 50
                Me.dgvFIPRPROP.Columns(5).Width = 130
                Me.dgvFIPRPROP.Columns(6).Width = 150
                Me.dgvFIPRPROP.Columns(7).Width = 150
                Me.dgvFIPRPROP.Columns(8).Width = 150
                Me.dgvFIPRPROP.Columns(9).Width = 100

                Dim ContarRegistros As Integer = BindingSource_FIPRPROP_1.Count

                '========================================
                '*** LLENA LOS CAMPOS DE PROPIETARIOS ***
                '========================================

                Dim tbl10 As New DataTable

                tbl10 = objdatos.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(Val(txtFIPRNUFI.Text))

                If tbl10.Rows.Count > 0 Then

                    lblFPPRIDRE.Text = Trim(tbl10.Rows(0).Item(0))
                    'txtFPPRNUFI.Text = Trim(tbl10.Rows(0).Item(1))
                    txtFPPRCAPR.Text = Trim(tbl10.Rows(0).Item(2))
                    txtFPPRSEXO.Text = Trim(tbl10.Rows(0).Item(3))
                    txtFPPRTIDO.Text = Trim(tbl10.Rows(0).Item(4))
                    txtFPPRNUDO.Text = Trim(tbl10.Rows(0).Item(5))
                    txtFPPRPRAP.Text = Trim(tbl10.Rows(0).Item(6))
                    txtFPPRSEAP.Text = Trim(tbl10.Rows(0).Item(7))
                    txtFPPRNOMB.Text = Trim(tbl10.Rows(0).Item(8))
                    txtFPPRDERE.Text = Trim(tbl10.Rows(0).Item(9))
                    txtFPPRSICO.Text = Trim(tbl10.Rows(0).Item(10))
                    txtFPPRESCR.Text = Trim(tbl10.Rows(0).Item(11))
                    txtFPPRDEPA.Text = Trim(tbl10.Rows(0).Item(12))
                    txtFPPRMUNI.Text = Trim(tbl10.Rows(0).Item(13))
                    txtFPPRNOTA.Text = Trim(tbl10.Rows(0).Item(14))
                    txtFPPRFEES.Text = Trim(tbl10.Rows(0).Item(15))
                    txtFPPRFERE.Text = Trim(tbl10.Rows(0).Item(16))
                    txtFPPRTOMO.Text = Trim(tbl10.Rows(0).Item(17))
                    txtFPPRMAIN.Text = Trim(tbl10.Rows(0).Item(18))
                    chkFPPRGRAV.Checked = tbl10.Rows(0).Item(19)
                    txtFPPRMOAD.Text = Trim(tbl10.Rows(0).Item(20))
                    'chkFPPRLITI.Checked = tbl10.Rows(0).Item(21)
                    'txtFPPRPOLI.Text = Trim(tbl10.Rows(0).Item(22))
                    'txtFPPRDEPA.Text = Trim(tbl10.Rows(0).Item(23))
                    'txtFPPRMUNI.Text = Trim(tbl10.Rows(0).Item(24))
                    'txtFPPRTIRE.Text = Trim(tbl10.Rows(0).Item(25))
                    'txtFPPRCLSE.Text = Trim(tbl10.Rows(0).Item(26))
                    'txtFPPRVIGE.Text = Trim(tbl10.Rows(0).Item(27))
                    'txtFPPRRESO.Text = Trim(tbl10.Rows(0).Item(28))
                    lblFPPRSECU.Text = Trim(tbl10.Rows(0).Item(29))
                    'txtFPPRNURE.Text = Trim(tbl10.Rows(0).Item(30))
                    'txtFPPRESTA.Text = Trim(tbl10.Rows(0).Item(31))
                    'txtFPPRUSIN.Text = Trim(tbl10.Rows(0).Item(32))
                    'txtFPPRUSMO.Text = Trim(tbl10.Rows(0).Item(33))
                    'txtFPPRFEIN.Text = Trim(tbl10.Rows(0).Item(34))
                    'txtFPPRFEMO.Text = Trim(tbl10.Rows(0).Item(35))
                    'txtFPPRMAQU.Text = Trim(tbl10.Rows(0).Item(36))

                    '===========================================
                    'CARGA LA DESCRIPCIÓN DE LA LISTA DE VALORES
                    '===========================================

                    lblFPPRCAPR.Text = CType(fun_Buscar_Lista_Valores_CALIPROP(txtFPPRCAPR.Text), String)
                    lblFPPRSEXO.Text = CType(fun_Buscar_Lista_Valores_SEXO(txtFPPRSEXO.Text), String)
                    lblFPPRTIDO.Text = CType(fun_Buscar_Lista_Valores_TIPODOCU(txtFPPRTIDO.Text), String)
                    lblFPPRNOTA.Text = CType(fun_Buscar_Lista_Valores_NOTARIA(Trim(txtFPPRDEPA.Text), Trim(txtFPPRMUNI.Text), Trim(txtFPPRNOTA.Text)), String)
                    lblFPPRMOAD.Text = CStr(fun_Buscar_Lista_Valores_MODOADQU(Me.txtFPPRMOAD.Text))

                    '=============================================
                    'SUMA EL PORCENTAJE DE LOS REGISTROS CARGADOS
                    '=============================================

                    pro_SumarPorcentajeDerechoPropietario()

                    ' consulta el propietario anterior

                    If Me.dgvFIPRPROP.RowCount > 0 Then

                        Dim obj3344 As New cla_PROPANTE
                        Dim tbl3344 As New DataTable

                        tbl3344 = obj3344.fun_Buscar_PROPIETARIOS_X_NRO_DE_FICHA_Y_NRO_DE_DOCUMENTO(Trim(Me.txtFIPRNUFI.Text), Trim(Me.txtFPPRNUDO.Text))

                        If tbl3344.Rows.Count > 0 Then

                            Me.txtPRANPRAP.Text = Trim(tbl3344.Rows(0).Item("PRANPRAP"))
                            Me.txtPRANSEAP.Text = Trim(tbl3344.Rows(0).Item("PRANSEAP"))
                            Me.txtPRANNOMB.Text = Trim(tbl3344.Rows(0).Item("PRANNOMB"))
                            Me.lblPRANCAAC.Text = Trim(tbl3344.Rows(0).Item("PRANCAAC"))

                        Else
                            Me.txtPRANPRAP.Text = ""
                            Me.txtPRANSEAP.Text = ""
                            Me.txtPRANNOMB.Text = ""
                            Me.lblPRANCAAC.Text = ""

                        End If

                    End If

                End If

                '==================================================
                '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
                '==================================================

                Dim objdatos1 As New cla_CONTRASENA
                Dim tbl1 As New DataTable

                tbl1 = objdatos1.fun_Buscar_USUARIO_CONTRASENA(vp_usuario)

                Dim boCONTAGRE As Boolean = Trim(tbl1.Rows(0).Item(5))
                Dim boCONTMODI As Boolean = Trim(tbl1.Rows(0).Item(6))
                Dim boCONTELIM As Boolean = Trim(tbl1.Rows(0).Item(7))

                If boCONTAGRE = True Then
                    cmdAGREGAR_FIPRPROP.Enabled = True
                Else
                    cmdAGREGAR_FIPRPROP.Enabled = False
                End If

                If ContarRegistros = 0 Then
                    cmdMODIFICAR_FIPRPROP.Enabled = False
                Else
                    If boCONTMODI = True Then
                        cmdMODIFICAR_FIPRPROP.Enabled = True
                    Else
                        cmdMODIFICAR_FIPRPROP.Enabled = False
                    End If
                End If

                If ContarRegistros = 0 Then
                    cmdELIMINAR_FIPRPROP.Enabled = False
                Else
                    If boCONTELIM = True Then
                        cmdELIMINAR_FIPRPROP.Enabled = True
                    Else
                        cmdELIMINAR_FIPRPROP.Enabled = False
                    End If
                End If

                If ContarRegistros = 0 Then
                    cmdCONSULTAR_FIPRPROP.Enabled = False
                Else
                    cmdCONSULTAR_FIPRPROP.Enabled = True
                End If

                If ContarRegistros = 0 Then
                    cmdRECONSULTAR_FIPRPROP.Enabled = False
                Else
                    cmdRECONSULTAR_FIPRPROP.Enabled = True
                End If

                If ContarRegistros = 0 Then
                    Me.cmdPROPANTE.Enabled = False
                Else
                    Me.cmdPROPANTE.Enabled = True
                End If

                ' PERMISOS DE INTERVENTORIA
                If Trim(Me.txtRESOTIRE.Text) = "185" Then
                    Me.cmdAGREGAR_FIPRPROP.Enabled = False
                    Me.cmdMODIFICAR_FIPRPROP.Enabled = False
                    Me.cmdELIMINAR_FIPRPROP.Enabled = False
                    Me.cmdPROPANTE.Enabled = False
                End If

            Else
                BindingNavigator_FIPRPROP_1.Enabled = False
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresPropietario()
        '============================================================
        'Verifica si existen registros para traer la lista de valores
        '============================================================

        If BindingSource_FIPRPROP_1.Count > 0 Then

            '=============================
            'Carga los datos en los campos
            '=============================
            Try
                Dim objdatos As New cla_FIPRPROP
                Dim tbl As New DataTable

                Dim id As Integer = (Integer.Parse(dgvFIPRPROP.CurrentRow.Cells(0).Value.ToString()))

                tbl = objdatos.fun_Buscar_ID_FIPRPROP(id)

                lblFPPRIDRE.Text = Trim(tbl.Rows(0).Item(0))
                'txtFPPRNUFI.Text = Trim(tbl10.Rows(0).Item(1))
                txtFPPRCAPR.Text = Trim(tbl.Rows(0).Item(2))
                txtFPPRSEXO.Text = Trim(tbl.Rows(0).Item(3))
                txtFPPRTIDO.Text = Trim(tbl.Rows(0).Item(4))
                txtFPPRNUDO.Text = Trim(tbl.Rows(0).Item(5))
                txtFPPRPRAP.Text = Trim(tbl.Rows(0).Item(6))
                txtFPPRSEAP.Text = Trim(tbl.Rows(0).Item(7))
                txtFPPRNOMB.Text = Trim(tbl.Rows(0).Item(8))
                txtFPPRDERE.Text = Trim(tbl.Rows(0).Item(9))
                txtFPPRSICO.Text = Trim(tbl.Rows(0).Item(10))
                txtFPPRESCR.Text = Trim(tbl.Rows(0).Item(11))
                txtFPPRDEPA.Text = Trim(tbl.Rows(0).Item(12))
                txtFPPRMUNI.Text = Trim(tbl.Rows(0).Item(13))
                txtFPPRNOTA.Text = Trim(tbl.Rows(0).Item(14))
                txtFPPRFEES.Text = Trim(tbl.Rows(0).Item(15))
                txtFPPRFERE.Text = Trim(tbl.Rows(0).Item(16))
                txtFPPRTOMO.Text = Trim(tbl.Rows(0).Item(17))
                txtFPPRMAIN.Text = Trim(tbl.Rows(0).Item(18))
                chkFPPRGRAV.Checked = tbl.Rows(0).Item(19)
                txtFPPRMOAD.Text = Trim(tbl.Rows(0).Item(20))
                'chkFPPRLITI.Checked = tbl10.Rows(0).Item(21)
                'txtFPPRPOLI.Text = Trim(tbl10.Rows(0).Item(22))
                'txtFPPRDEPA.Text = Trim(tbl10.Rows(0).Item(23))
                'txtFPPRMUNI.Text = Trim(tbl10.Rows(0).Item(24))
                'txtFPPRTIRE.Text = Trim(tbl10.Rows(0).Item(25))
                'txtFPPRCLSE.Text = Trim(tbl10.Rows(0).Item(26))
                'txtFPPRVIGE.Text = Trim(tbl10.Rows(0).Item(27))
                'txtFPPRRESO.Text = Trim(tbl10.Rows(0).Item(28))
                lblFPPRSECU.Text = Trim(tbl.Rows(0).Item(29))
                'txtFPPRNURE.Text = Trim(tbl10.Rows(0).Item(30))
                'txtFPPRESTA.Text = Trim(tbl10.Rows(0).Item(31))
                'txtFPPRUSIN.Text = Trim(tbl10.Rows(0).Item(32))
                'txtFPPRUSMO.Text = Trim(tbl10.Rows(0).Item(33))
                'txtFPPRFEIN.Text = Trim(tbl10.Rows(0).Item(34))
                'txtFPPRFEMO.Text = Trim(tbl10.Rows(0).Item(35))
                'txtFPPRMAQU.Text = Trim(tbl10.Rows(0).Item(36))

                '===========================================
                'CARGA LA DESCRIPCIÓN DE LA LISTA DE VALORES
                '===========================================

                lblFPPRCAPR.Text = CType(fun_Buscar_Lista_Valores_CALIPROP(txtFPPRCAPR.Text), String)
                lblFPPRSEXO.Text = CType(fun_Buscar_Lista_Valores_SEXO(txtFPPRSEXO.Text), String)
                lblFPPRTIDO.Text = CType(fun_Buscar_Lista_Valores_TIPODOCU(txtFPPRTIDO.Text), String)
                lblFPPRNOTA.Text = CType(fun_Buscar_Lista_Valores_NOTARIA(Trim(txtFPPRDEPA.Text), Trim(txtFPPRMUNI.Text), Trim(txtFPPRNOTA.Text)), String)
                lblFPPRMOAD.Text = CType(fun_Buscar_Lista_Valores_MODOADQU(Trim(Me.txtFPPRMOAD.Text)), String)

                '=============================================
                'SUMA EL PORCENTAJE DE LOS REGISTROS CARGADOS
                '=============================================

                pro_SumarPorcentajeDerechoPropietario()

                ' consulta el propietario anterior

                If Me.dgvFIPRPROP.RowCount > 0 Then

                    Dim obj3344 As New cla_PROPANTE
                    Dim tbl3344 As New DataTable

                    tbl3344 = obj3344.fun_Buscar_PROPIETARIOS_X_NRO_DE_FICHA_Y_NRO_DE_DOCUMENTO(Trim(Me.txtFIPRNUFI.Text), Trim(Me.txtFPPRNUDO.Text))

                    If tbl3344.Rows.Count > 0 Then

                        Me.txtPRANPRAP.Text = Trim(tbl3344.Rows(0).Item("PRANPRAP"))
                        Me.txtPRANSEAP.Text = Trim(tbl3344.Rows(0).Item("PRANSEAP"))
                        Me.txtPRANNOMB.Text = Trim(tbl3344.Rows(0).Item("PRANNOMB"))
                        Me.lblPRANCAAC.Text = Trim(tbl3344.Rows(0).Item("PRANCAAC"))

                    Else
                        Me.txtPRANPRAP.Text = ""
                        Me.txtPRANSEAP.Text = ""
                        Me.txtPRANNOMB.Text = ""
                        Me.lblPRANCAAC.Text = ""

                    End If

                End If

            Catch ex As Exception
                MessageBox.Show(Err.Description & "3")
            End Try

        End If

    End Sub
    Private Sub pro_LimpiarCamposPropietario()

        lblFPPRIDRE.Text = ""
        lblFPPRCAPR.Text = ""
        lblFPPRSEXO.Text = ""
        lblFPPRTIDO.Text = ""
        txtFPPRCAPR.Text = ""
        txtFPPRSEXO.Text = ""
        txtFPPRTIDO.Text = ""
        txtFPPRNUDO.Text = ""
        txtFPPRPRAP.Text = ""
        txtFPPRSEAP.Text = ""
        txtFPPRNOMB.Text = ""
        txtFPPRDERE.Text = ""
        txtFPPRSICO.Text = ""
        txtFPPRESCR.Text = ""
        txtFPPRDEPA.Text = ""
        txtFPPRMUNI.Text = ""
        txtFPPRNOTA.Text = ""
        txtFPPRFEES.Text = ""
        txtFPPRFERE.Text = ""
        txtFPPRTOMO.Text = ""
        txtFPPRMAIN.Text = ""
        chkFPPRGRAV.Checked = False
        lblFPPRSECU.Text = ""
        lblFPPRTOTA.Text = ""
        lblFPPRNOTA.Text = ""

        Me.txtFPPRMOAD.Text = ""
        Me.lblFPPRMOAD.Text = ""

        Me.txtPRANPRAP.Text = ""
        Me.txtPRANSEAP.Text = ""
        Me.txtPRANNOMB.Text = ""

        Me.lblPRANCAAC.Text = ""

    End Sub
    Private Sub pro_SumarPorcentajeDerechoPropietario()
        Dim objdatos2 As New cla_FIPRPROP
        Dim tbl1 As New DataTable

        tbl1 = objdatos2.fun_Consultar_SUMA_X_FPPRDERE_FIPRPROP(Val(txtFIPRNUFI.Text))

        Dim i As Integer
        Dim deTOTAL As Decimal

        If tbl1.Rows.Count > 0 Then

            For i = 0 To tbl1.Rows.Count - 1
                deTOTAL += Trim(tbl1.Rows(i).Item("FPPRDERE"))
            Next

        End If

        lblFPPRTOTA.Text = deTOTAL.ToString

    End Sub

#End Region

#Region "PROCEDIMIENTOS CONSTRUCCION"

    Private Sub pro_ReconsultarConstruccion()
        Try
            ' reconsulte si ficha predial tiene registros
            If BindingSource_FICHPRED_1.Count > 0 Then

                ' activa el navegador
                BindingNavigator_FIPRCONS_1.Enabled = True

                Dim objdatos As New cla_FIPRCONS

                BindingSource_FIPRCONS_1.DataSource = objdatos.fun_Consultar_FIPRCONS(Val(txtFIPRNUFI.Text))
                dgvFIPRCONS.DataSource = BindingSource_FIPRCONS_1.DataSource
                dgvFIPRCOCA.DataSource = BindingSource_FIPRCONS_1.DataSource
                BindingNavigator_FIPRCONS_1.BindingSource = BindingSource_FIPRCONS_1

                dgvFIPRCONS.Columns(0).Visible = False
                dgvFIPRCONS.Columns(1).Visible = False

                dgvFIPRCOCA.Columns(0).Visible = False
                dgvFIPRCOCA.Columns(1).Visible = False

                Me.dgvFIPRCONS.Columns(2).Width = 50
                Me.dgvFIPRCONS.Columns(3).Width = 100
                Me.dgvFIPRCONS.Columns(4).Width = 100
                Me.dgvFIPRCONS.Columns(5).Width = 50
                Me.dgvFIPRCONS.Columns(6).Width = 100
                Me.dgvFIPRCONS.Columns(7).Width = 100

                Me.dgvFIPRCOCA.Columns(2).Width = 50
                Me.dgvFIPRCOCA.Columns(3).Width = 100
                Me.dgvFIPRCOCA.Columns(4).Width = 100
                Me.dgvFIPRCOCA.Columns(5).Width = 50
                Me.dgvFIPRCOCA.Columns(6).Width = 100
                Me.dgvFIPRCOCA.Columns(7).Width = 100

                Dim ContarRegistros As Integer = BindingSource_FIPRCONS_1.Count

                '========================================
                '*** LLENA LOS CAMPOS DE PROPIETARIOS ***
                '========================================

                Dim tbl10 As New DataTable

                tbl10 = objdatos.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(Val(txtFIPRNUFI.Text))

                If tbl10.Rows.Count > 0 Then

                    lblFPCOIDRE.Text = Trim(tbl10.Rows(0).Item(0))
                    'txtFPPRNUFI.Text = Trim(tbl10.Rows(0).Item(1))
                    txtFPCOUNID.Text = Trim(tbl10.Rows(0).Item(2))
                    txtFPCOCLCO.Text = Trim(tbl10.Rows(0).Item(3))
                    txtFPCOTICO.Text = Trim(tbl10.Rows(0).Item(4))
                    txtFPCOPUNT.Text = Trim(tbl10.Rows(0).Item(5))
                    txtFPCOARCO.Text = Trim(tbl10.Rows(0).Item(6))
                    txtFPCOACUE.Text = Trim(tbl10.Rows(0).Item(7))
                    txtFPCOALCA.Text = Trim(tbl10.Rows(0).Item(8))
                    txtFPCOENER.Text = Trim(tbl10.Rows(0).Item(9))
                    txtFPCOTELE.Text = Trim(tbl10.Rows(0).Item(10))
                    txtFPCOGAS.Text = Trim(tbl10.Rows(0).Item(11))
                    txtFPCOPISO.Text = Trim(tbl10.Rows(0).Item(12))
                    txtFPCOEDCO.Text = Trim(tbl10.Rows(0).Item(13))
                    txtFPCOPOCO.Text = Trim(tbl10.Rows(0).Item(14))
                    chkFPCOMEJO.Checked = tbl10.Rows(0).Item(15)
                    chkFPCOLEY.Checked = tbl10.Rows(0).Item(16)
                    txtFPCOAVCO.Text = Trim(tbl10.Rows(0).Item(17))
                    txtFPCOFECH.Text = Trim(tbl10.Rows(0).Item(18))
                    'txtFPCODEPA.Text = Trim(tbl10.Rows(0).Item(19))
                    'txtFPCOMUNI.Text = Trim(tbl10.Rows(0).Item(20))
                    'txtFPCOTIRE.Text = Trim(tbl10.Rows(0).Item(21))
                    'txtFPCOCLSE.Text = Trim(tbl10.Rows(0).Item(22))
                    'txtFPCOVIGE.Text = Trim(tbl10.Rows(0).Item(23))
                    'txtFPCORESO.Text = Trim(tbl10.Rows(0).Item(24))
                    lblFPCOSECU.Text = Trim(tbl10.Rows(0).Item(25))
                    'txtFPCONURE.Text = Trim(tbl10.Rows(0).Item(26))
                    'txtFPCOESTA.Text = Trim(tbl10.Rows(0).Item(27))
                    'txtFPCOUSIN.Text = Trim(tbl10.Rows(0).Item(28))
                    'txtFPCOUSMO.Text = Trim(tbl10.Rows(0).Item(29))
                    'txtFPCOFEIN.Text = Trim(tbl10.Rows(0).Item(30))
                    'txtFPCOFEMO.Text = Trim(tbl10.Rows(0).Item(31))
                    'txtFPCOMAQU.Text = Trim(tbl10.Rows(0).Item(32))

                    '===========================================
                    'CARGA LA DESCRIPCIÓN DE LA LISTA DE VALORES
                    '===========================================

                    lblFPCOCLCO.Text = CType(fun_Buscar_Lista_Valores_CLASCONS(txtFPCOCLCO.Text), String)
                    lblFPCOTICO.Text = CType(fun_Buscar_Lista_Valores_TIPOCONS(Trim(txtRESODEPA.Text), Trim(txtRESOMUNI.Text), Trim(txtFPCOCLCO.Text), Trim(txtRESOCLSE.Text), Trim(txtFPCOTICO.Text)), String)

                    '==============================
                    'APLICA EL FORMATO A LOS CAMPOS
                    '==============================

                    txtFPCOARCO.Text = CType(fun_Formato_Decimal_2_Decimales(Trim(txtFPCOARCO.Text)), String)

                    '=============================================
                    'CARGA LA DESCRIPCIÓN DEL TIPO DE CONSTRUCCION
                    '=============================================

                    Dim objdatos15 As New cla_TIPOCONS
                    Dim tbl15 As New DataTable

                    tbl15 = objdatos15.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(Trim(txtRESODEPA.Text), Trim(txtRESOMUNI.Text), Trim(txtFPCOCLCO.Text), Trim(txtRESOCLSE.Text), Trim(txtFPCOTICO.Text))

                    If tbl15.Rows.Count > 0 Then

                        Dim stFPCOTIPO As String = Trim(tbl15.Rows(0).Item(4))

                        If stFPCOTIPO = "R" Then
                            rbdFPCORESI.Checked = True
                            rbdFPCCRESI.Checked = True
                        ElseIf stFPCOTIPO = "C" Then
                            rbdFPCOCOME.Checked = True
                            rbdFPCCCOME.Checked = True
                        ElseIf stFPCOTIPO = "I" Then
                            rbdFPCOINDU.Checked = True
                            rbdFPCCINDU.Checked = True
                        ElseIf stFPCOTIPO = "O" Then
                            rbdFPCOOTRA.Checked = True
                            rbdFPCCOTRA.Checked = True
                        Else
                            rbdFPCORESI.Checked = False
                            rbdFPCCRESI.Checked = False
                            rbdFPCOCOME.Checked = False
                            rbdFPCCCOME.Checked = False
                            rbdFPCOINDU.Checked = False
                            rbdFPCCINDU.Checked = False
                            rbdFPCOOTRA.Checked = False
                            rbdFPCCOTRA.Checked = False
                        End If

                        chkFPCOARCO.Checked = CType(fun_Buscar_Lista_Valores_BOOLEAN(tbl15.Rows(0).Item(12)), Boolean)

                    End If

                    '=====================================
                    'CARGA LA DESCRIPCIÓN DE LOS GENERALES
                    '=====================================

                    If Trim(txtFPCOACUE.Text) = "1" Then
                        lblFPCOACUE.Text = "Con Servicio"
                    Else
                        lblFPCOACUE.Text = "Sin Servicio"
                    End If

                    If Trim(txtFPCOALCA.Text) = "1" Then
                        lblFPCOALCA.Text = "Con Servicio"
                    Else
                        lblFPCOALCA.Text = "Sin Servicio"
                    End If

                    If Trim(txtFPCOENER.Text) = "1" Then
                        lblFPCOENER.Text = "Con Servicio"
                    Else
                        lblFPCOENER.Text = "Sin Servicio"
                    End If

                    If Trim(txtFPCOTELE.Text) = "1" Then
                        lblFPCOTELE.Text = "Con Servicio"
                    Else
                        lblFPCOTELE.Text = "Sin Servicio"
                    End If

                    If Trim(txtFPCOGAS.Text) = "1" Then
                        lblFPCOGAS.Text = "Con Servicio"
                    Else
                        lblFPCOGAS.Text = "Sin Servicio"
                    End If

                End If

                '==================================================
                '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
                '==================================================

                Dim objdatos1 As New cla_CONTRASENA
                Dim tbl1 As New DataTable

                tbl1 = objdatos1.fun_Buscar_USUARIO_CONTRASENA(vp_usuario)

                Dim boCONTAGRE As Boolean = Trim(tbl1.Rows(0).Item(5))
                Dim boCONTMODI As Boolean = Trim(tbl1.Rows(0).Item(6))
                Dim boCONTELIM As Boolean = Trim(tbl1.Rows(0).Item(7))

                If boCONTAGRE = True Then
                    cmdAGREGAR_FIPRCONS.Enabled = True
                Else
                    cmdAGREGAR_FIPRCONS.Enabled = False
                End If

                If ContarRegistros = 0 Then
                    cmdMODIFICAR_FIPRCONS.Enabled = False
                Else
                    If boCONTMODI = True Then
                        cmdMODIFICAR_FIPRCONS.Enabled = True
                    Else
                        cmdMODIFICAR_FIPRCONS.Enabled = False
                    End If
                End If

                If ContarRegistros = 0 Then
                    cmdELIMINAR_FIPRCONS.Enabled = False
                Else
                    If boCONTELIM = True Then
                        cmdELIMINAR_FIPRCONS.Enabled = True
                    Else
                        cmdELIMINAR_FIPRCONS.Enabled = False
                    End If
                End If

                If ContarRegistros = 0 Then
                    cmdCONSULTAR_FIPRCONS.Enabled = False
                Else
                    cmdCONSULTAR_FIPRCONS.Enabled = True
                End If

                If ContarRegistros = 0 Then
                    cmdRECONSULTAR_FIPRCONS.Enabled = False
                Else
                    cmdRECONSULTAR_FIPRCONS.Enabled = True
                End If

                ' PERMISOS DE INTERVENTORIA
                If Trim(Me.txtRESOTIRE.Text) = "185" Then
                    Me.cmdAGREGAR_FIPRCONS.Enabled = False
                    Me.cmdMODIFICAR_FIPRCONS.Enabled = False
                    Me.cmdELIMINAR_FIPRCONS.Enabled = False
                End If

            Else
                BindingNavigator_FIPRCONS_1.Enabled = False
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresConstruccion()
        '============================================================
        'Verifica si existen registros para traer la lista de valores
        '============================================================

        If BindingSource_FIPRCONS_1.Count > 0 Then

            '=============================
            'Carga los datos en los campos
            '=============================
            Try
                Dim objdatos As New cla_FIPRCONS
                Dim tbl As New DataTable

                Dim id As Integer = (Integer.Parse(dgvFIPRCONS.CurrentRow.Cells(0).Value.ToString()))

                tbl = objdatos.fun_Buscar_ID_FIPRCONS(id)

                lblFPCOIDRE.Text = Trim(tbl.Rows(0).Item(0))
                'txtFPPRNUFI.Text = Trim(tbl.Rows(0).Item(1))
                txtFPCOUNID.Text = Trim(tbl.Rows(0).Item(2))
                txtFPCOCLCO.Text = Trim(tbl.Rows(0).Item(3))
                txtFPCOTICO.Text = Trim(tbl.Rows(0).Item(4))
                txtFPCOPUNT.Text = Trim(tbl.Rows(0).Item(5))
                txtFPCOARCO.Text = Trim(tbl.Rows(0).Item(6))
                txtFPCOACUE.Text = Trim(tbl.Rows(0).Item(7))
                txtFPCOALCA.Text = Trim(tbl.Rows(0).Item(8))
                txtFPCOENER.Text = Trim(tbl.Rows(0).Item(9))
                txtFPCOTELE.Text = Trim(tbl.Rows(0).Item(10))
                txtFPCOGAS.Text = Trim(tbl.Rows(0).Item(11))
                txtFPCOPISO.Text = Trim(tbl.Rows(0).Item(12))
                txtFPCOEDCO.Text = Trim(tbl.Rows(0).Item(13))
                txtFPCOPOCO.Text = Trim(tbl.Rows(0).Item(14))
                chkFPCOMEJO.Checked = tbl.Rows(0).Item(15)
                chkFPCOLEY.Checked = tbl.Rows(0).Item(16)
                txtFPCOAVCO.Text = Trim(tbl.Rows(0).Item(17))
                txtFPCOFECH.Text = Trim(tbl.Rows(0).Item(18))
                'txtFPCODEPA.Text = Trim(tbl.Rows(0).Item(19))
                'txtFPCOMUNI.Text = Trim(tbl.Rows(0).Item(20))
                'txtFPCOTIRE.Text = Trim(tbl.Rows(0).Item(21))
                'txtFPCOCLSE.Text = Trim(tbl.Rows(0).Item(22))
                'txtFPCOVIGE.Text = Trim(tbl.Rows(0).Item(23))
                'txtFPCORESO.Text = Trim(tbl.Rows(0).Item(24))
                lblFPCOSECU.Text = Trim(tbl.Rows(0).Item(25))
                'txtFPCONURE.Text = Trim(tbl.Rows(0).Item(26))
                'txtFPCOESTA.Text = Trim(tbl.Rows(0).Item(27))
                'txtFPCOUSIN.Text = Trim(tbl.Rows(0).Item(28))
                'txtFPCOUSMO.Text = Trim(tbl.Rows(0).Item(29))
                'txtFPCOFEIN.Text = Trim(tbl.Rows(0).Item(30))
                'txtFPCOFEMO.Text = Trim(tbl.Rows(0).Item(31))
                'txtFPCOMAQU.Text = Trim(tbl.Rows(0).Item(32))

                '===========================================
                'CARGA LA DESCRIPCIÓN DE LA LISTA DE VALORES
                '===========================================

                lblFPCOCLCO.Text = CType(fun_Buscar_Lista_Valores_CLASCONS(txtFPCOCLCO.Text), String)
                lblFPCOTICO.Text = CType(fun_Buscar_Lista_Valores_TIPOCONS(Trim(txtRESODEPA.Text), Trim(txtRESOMUNI.Text), Trim(txtFPCOCLCO.Text), Trim(txtRESOCLSE.Text), Trim(txtFPCOTICO.Text)), String)

                '==============================
                'APLICA EL FORMATO A LOS CAMPOS
                '==============================

                txtFPCOARCO.Text = CType(fun_Formato_Decimal_2_Decimales(Trim(txtFPCOARCO.Text)), String)

                '=============================================
                'CARGA LA DESCRIPCIÓN DEL TIPO DE CONSTRUCCION
                '=============================================

                Dim objdatos15 As New cla_TIPOCONS
                Dim tbl15 As New DataTable

                tbl15 = objdatos15.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(Trim(txtRESODEPA.Text), Trim(txtRESOMUNI.Text), Trim(txtFPCOCLCO.Text), Trim(txtRESOCLSE.Text), Trim(txtFPCOTICO.Text))

                If tbl15.Rows.Count > 0 Then

                    Dim stFPCOTIPO As String = Trim(tbl15.Rows(0).Item(4))

                    If stFPCOTIPO = "R" Then
                        rbdFPCORESI.Checked = True
                        rbdFPCCRESI.Checked = True
                    ElseIf stFPCOTIPO = "C" Then
                        rbdFPCOCOME.Checked = True
                        rbdFPCCCOME.Checked = True
                    ElseIf stFPCOTIPO = "I" Then
                        rbdFPCOINDU.Checked = True
                        rbdFPCCINDU.Checked = True
                    ElseIf stFPCOTIPO = "O" Then
                        rbdFPCOOTRA.Checked = True
                        rbdFPCCOTRA.Checked = True
                    Else
                        rbdFPCORESI.Checked = False
                        rbdFPCCRESI.Checked = False
                        rbdFPCOCOME.Checked = False
                        rbdFPCCCOME.Checked = False
                        rbdFPCOINDU.Checked = False
                        rbdFPCCINDU.Checked = False
                        rbdFPCOOTRA.Checked = False
                        rbdFPCCOTRA.Checked = False
                    End If

                    ' Carga el valor boleano si el tipo de construcción es area comercial
                    chkFPCOARCO.Checked = CType(fun_Buscar_Lista_Valores_BOOLEAN(tbl15.Rows(0).Item(12)), Boolean)

                End If

                '=============================================
                'CARGA LA DESCRIPCIÓN DEL TIPO DE CONSTRUCCION
                '=============================================

                If Trim(txtFPCOACUE.Text) = "1" Then
                    lblFPCOACUE.Text = "Con Servicio"
                Else
                    lblFPCOACUE.Text = "Sin Servicio"
                End If

                If Trim(txtFPCOALCA.Text) = "1" Then
                    lblFPCOALCA.Text = "Con Servicio"
                Else
                    lblFPCOALCA.Text = "Sin Servicio"
                End If

                If Trim(txtFPCOENER.Text) = "1" Then
                    lblFPCOENER.Text = "Con Servicio"
                Else
                    lblFPCOENER.Text = "Sin Servicio"
                End If

                If Trim(txtFPCOTELE.Text) = "1" Then
                    lblFPCOTELE.Text = "Con Servicio"
                Else
                    lblFPCOTELE.Text = "Sin Servicio"
                End If

                If Trim(txtFPCOGAS.Text) = "1" Then
                    lblFPCOGAS.Text = "Con Servicio"
                Else
                    lblFPCOGAS.Text = "Sin Servicio"
                End If


            Catch ex As Exception
                MessageBox.Show(Err.Description)
            End Try

        End If

    End Sub
    Private Sub pro_LimpiarCamposConstruccion()

        lblFPCOIDRE.Text = ""
        txtFPCOUNID.Text = ""
        txtFPCOCLCO.Text = ""
        lblFPCOCLCO.Text = ""
        txtFPCOTICO.Text = ""
        lblFPCOTICO.Text = ""
        txtFPCOPUNT.Text = ""
        txtFPCOARCO.Text = ""
        txtFPCOACUE.Text = ""
        lblFPCOACUE.Text = ""
        txtFPCOALCA.Text = ""
        lblFPCOALCA.Text = ""
        txtFPCOENER.Text = ""
        lblFPCOENER.Text = ""
        txtFPCOTELE.Text = ""
        lblFPCOTELE.Text = ""
        txtFPCOGAS.Text = ""
        lblFPCOGAS.Text = ""
        txtFPCOPISO.Text = ""
        txtFPCOEDCO.Text = ""
        txtFPCOPOCO.Text = ""
        chkFPCOMEJO.Checked = False
        chkFPCOLEY.Checked = False
        txtFPCOAVCO.Text = ""
        txtFPCOFECH.Text = ""
        lblFPCOSECU.Text = ""

    End Sub

#End Region

#Region "PROCEDIMIENTOS CALIFICACION"

    Private Sub pro_ReconsultarCalificacion()
        Try
            ' reconsulte si ficha predial tiene registros
            If BindingSource_FICHPRED_1.Count > 0 Then
                If BindingSource_FIPRCONS_1.Count > 0 Then

                    ' activa el navegador
                    BindingNavigator_FIPRCACO_1.Enabled = True

                    Dim objdatos As New cla_FIPRCACO

                    BindingSource_FIPRCACO_1.DataSource = objdatos.fun_Consultar_FIPRCACO(Val(txtFIPRNUFI.Text), Trim(txtFPCOUNID.Text))
                    dgvFIPRCACO.DataSource = BindingSource_FIPRCACO_1.DataSource
                    BindingNavigator_FIPRCACO_1.BindingSource = BindingSource_FIPRCACO_1

                    dgvFIPRCACO.Columns(0).Visible = False
                    dgvFIPRCACO.Columns(1).Visible = False

                    Me.dgvFIPRCACO.Columns(2).Width = 70
                    Me.dgvFIPRCACO.Columns(3).Width = 150
                    Me.dgvFIPRCACO.Columns(4).Width = 70
                    Me.dgvFIPRCACO.Columns(5).Width = 70

                    Dim ContarRegistros As Integer = BindingSource_FIPRCACO_1.Count

                    '=======================================================
                    '*** LLENA LOS CAMPOS DE CALIFICACIN DE CONSTRUCCION ***
                    '=======================================================

                    Dim tbl10 As New DataTable

                    tbl10 = objdatos.fun_Consultar_FIPRCACO_X_FICHA_PREDIAL(Val(txtFIPRNUFI.Text), Trim(txtFPCOUNID.Text))

                    If tbl10.Rows.Count > 0 Then

                        lblFPCCIDRE.Text = Trim(tbl10.Rows(0).Item(0))
                        'txtFPCCNUFI.Text = Trim(tbl10.Rows(0).Item(1))
                        txtFPCCCODI.Text = Trim(tbl10.Rows(0).Item(2))
                        'txtFPCCTIPO.Text = Trim(tbl10.Rows(0).Item(3))
                        'txtFPCCPUNT.Text = Trim(tbl10.Rows(0).Item(4))
                        'txtFPCCUNID.Text = Trim(tbl10.Rows(0).Item(5))
                        'txtFPCCCLCO.Text = Trim(tbl10.Rows(0).Item(6))
                        'txtFPCCTICO.Text = Trim(tbl10.Rows(0).Item(7))
                        'txtFPCCDEPA.Text = Trim(tbl10.Rows(0).Item(8))
                        'txtFPCCMUNI.Text = Trim(tbl10.Rows(0).Item(9))
                        'txtFPCCTIRE.Text = Trim(tbl10.Rows(0).Item(10))
                        'txtFPCCCLSE.Text = Trim(tbl10.Rows(0).Item(11))
                        'txtFPCCVIGE.Text = Trim(tbl10.Rows(0).Item(12))
                        'txtFPCCRESO.Text = Trim(tbl10.Rows(0).Item(13))
                        lblFPCCSECU.Text = Trim(tbl10.Rows(0).Item(14))
                        'txtFPCCNURE.Text = Trim(tbl10.Rows(0).Item(15))
                        'txtFPCCESTA.Text = Trim(tbl10.Rows(0).Item(16))
                        'txtFPCCUSIN.Text = Trim(tbl10.Rows(0).Item(17))
                        'txtFPCCUSMO.Text = Trim(tbl10.Rows(0).Item(18))
                        'txtFPCCFEIN.Text = Trim(tbl10.Rows(0).Item(19))
                        'txtFPCCFEMO.Text = Trim(tbl10.Rows(0).Item(20))
                        'txtFPCCMAQU.Text = Trim(tbl10.Rows(0).Item(21))

                        '===========================================
                        'CARGA LA DESCRIPCIÓN DE LA LISTA DE VALORES
                        '===========================================

                        lblFPCCCOPA.Text = CType(fun_Buscar_Lista_Valores_CODICALI_COCACOPA(txtFPCCCODI.Text), String)
                        lblFPCCCOHI.Text = CType(fun_Buscar_Lista_Valores_CODICALI_COCACOHI(txtFPCCCODI.Text), String)
                        
                        '==========================================================
                        'SUMA LOS PUNTOS DE CALIFICACION DE CONSTRUCCION POR UNIDAD
                        '==========================================================

                        pro_SumaPuntosDeCalificacionDeConstruccion()
                    Else
                        pro_LimpiarCamposCalificacion()
                    End If
                    '==================================================
                    '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
                    '==================================================

                    Dim objdatos1 As New cla_CONTRASENA
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_USUARIO_CONTRASENA(vp_usuario)

                    Dim boCONTAGRE As Boolean = Trim(tbl1.Rows(0).Item(5))
                    Dim boCONTMODI As Boolean = Trim(tbl1.Rows(0).Item(6))
                    Dim boCONTELIM As Boolean = Trim(tbl1.Rows(0).Item(7))

                    If boCONTAGRE = True Then
                        cmdAGREGAR_FIPRCACO.Enabled = True
                    Else
                        cmdAGREGAR_FIPRCACO.Enabled = False
                    End If

                    If ContarRegistros = 0 Then
                        cmdMODIFICAR_FIPRCACO.Enabled = False
                    Else
                        If boCONTMODI = True Then
                            cmdMODIFICAR_FIPRCACO.Enabled = True
                        Else
                            cmdMODIFICAR_FIPRCACO.Enabled = False
                        End If
                    End If

                    If ContarRegistros = 0 Then
                        cmdELIMINAR_FIPRCACO.Enabled = False
                    Else
                        If boCONTELIM = True Then
                            cmdELIMINAR_FIPRCACO.Enabled = True
                        Else
                            cmdELIMINAR_FIPRCACO.Enabled = False
                        End If
                    End If

                    If ContarRegistros = 0 Then
                        cmdCONSULTAR_FIPRCACO.Enabled = False
                    Else
                        cmdCONSULTAR_FIPRCACO.Enabled = True
                    End If

                    If ContarRegistros = 0 Then
                        cmdRECONSULTAR_FIPRCACO.Enabled = False
                    Else
                        cmdRECONSULTAR_FIPRCACO.Enabled = True
                    End If

                    ' PERMISOS DE INTERVENTORIA
                    If Trim(Me.txtRESOTIRE.Text) = "185" Then
                        Me.cmdAGREGAR_FIPRCACO.Enabled = False
                        Me.cmdMODIFICAR_FIPRCACO.Enabled = False
                        Me.cmdELIMINAR_FIPRCACO.Enabled = False
                    End If

                Else
                    BindingNavigator_FIPRCACO_1.Enabled = False

                    pro_LimpiarCamposCalificacion()

                    Dim tbl As New DataTable
                    dgvFIPRCACO.DataSource = tbl

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_ListaDeValoresCalificacion()
        '============================================================
        'Verifica si existen registros para traer la lista de valores
        '============================================================

        If BindingSource_FIPRCACO_1.Count > 0 Then

            '=============================
            'Carga los datos en los campos
            '=============================
            Try
                Dim objdatos As New cla_FIPRCACO
                Dim tbl As New DataTable

                Dim id As Integer = (Integer.Parse(dgvFIPRCACO.CurrentRow.Cells(0).Value.ToString()))
                'Dim id As Integer = Trim(lblFPCCIDRE.Text)

                tbl = objdatos.fun_Buscar_ID_FIPRCACO(id)

                lblFPCCIDRE.Text = Trim(tbl.Rows(0).Item(0))
                'txtFPCCNUFI.Text = Trim(tbl.Rows(0).Item(1))
                txtFPCCCODI.Text = Trim(tbl.Rows(0).Item(2))
                'txtFPCCTIPO.Text = Trim(tbl.Rows(0).Item(3))
                'txtFPCCPUNT.Text = Trim(tbl.Rows(0).Item(4))
                'txtFPCCUNID.Text = Trim(tbl.Rows(0).Item(5))
                'txtFPCCCLCO.Text = Trim(tbl.Rows(0).Item(6))
                'txtFPCCTICO.Text = Trim(tbl.Rows(0).Item(7))
                'txtFPCCDEPA.Text = Trim(tbl.Rows(0).Item(8))
                'txtFPCCMUNI.Text = Trim(tbl.Rows(0).Item(9))
                'txtFPCCTIRE.Text = Trim(tbl.Rows(0).Item(10))
                'txtFPCCCLSE.Text = Trim(tbl.Rows(0).Item(11))
                'txtFPCCVIGE.Text = Trim(tbl.Rows(0).Item(12))
                'txtFPCCRESO.Text = Trim(tbl.Rows(0).Item(13))
                lblFPCCSECU.Text = Trim(tbl.Rows(0).Item(14))
                'txtFPCCNURE.Text = Trim(tbl.Rows(0).Item(15))
                'txtFPCCESTA.Text = Trim(tbl.Rows(0).Item(16))
                'txtFPCCUSIN.Text = Trim(tbl.Rows(0).Item(17))
                'txtFPCCUSMO.Text = Trim(tbl.Rows(0).Item(18))
                'txtFPCCFEIN.Text = Trim(tbl.Rows(0).Item(19))
                'txtFPCCFEMO.Text = Trim(tbl.Rows(0).Item(20))
                'txtFPCCMAQU.Text = Trim(tbl.Rows(0).Item(21))

                '===========================================
                'CARGA LA DESCRIPCIÓN DE LA LISTA DE VALORES
                '===========================================

                lblFPCCCOPA.Text = CType(fun_Buscar_Lista_Valores_CODICALI_COCACOPA(txtFPCCCODI.Text), String)
                lblFPCCCOHI.Text = CType(fun_Buscar_Lista_Valores_CODICALI_COCACOHI(txtFPCCCODI.Text), String)

                '==========================================================
                'SUMA LOS PUNTOS DE CALIFICACION DE CONSTRUCCION POR UNIDAD
                '==========================================================

                pro_SumaPuntosDeCalificacionDeConstruccion()

            Catch ex As Exception
                MessageBox.Show(Err.Description)
            End Try

        End If
    End Sub
    Private Sub pro_ListaDeValoresCalificacionInicial()
        '============================================================
        'Verifica si existen registros para traer la lista de valores
        '============================================================

        If BindingSource_FIPRCACO_1.Count > 0 Then

            '=============================
            'Carga los datos en los campos
            '=============================
            Try
                Dim objdatos As New cla_FIPRCACO
                Dim tbl As New DataTable

                'Dim id As Integer = (Integer.Parse(dgvFIPRCACO.CurrentRow.Cells(0).Value.ToString()))
                Dim id As Integer = Trim(lblFPCCIDRE.Text)

                tbl = objdatos.fun_Buscar_ID_FIPRCACO(id)

                lblFPCCIDRE.Text = Trim(tbl.Rows(0).Item(0))
                'txtFPCCNUFI.Text = Trim(tbl.Rows(0).Item(1))
                txtFPCCCODI.Text = Trim(tbl.Rows(0).Item(2))
                'txtFPCCTIPO.Text = Trim(tbl.Rows(0).Item(3))
                'txtFPCCPUNT.Text = Trim(tbl.Rows(0).Item(4))
                'txtFPCCUNID.Text = Trim(tbl.Rows(0).Item(5))
                'txtFPCCCLCO.Text = Trim(tbl.Rows(0).Item(6))
                'txtFPCCTICO.Text = Trim(tbl.Rows(0).Item(7))
                'txtFPCCDEPA.Text = Trim(tbl.Rows(0).Item(8))
                'txtFPCCMUNI.Text = Trim(tbl.Rows(0).Item(9))
                'txtFPCCTIRE.Text = Trim(tbl.Rows(0).Item(10))
                'txtFPCCCLSE.Text = Trim(tbl.Rows(0).Item(11))
                'txtFPCCVIGE.Text = Trim(tbl.Rows(0).Item(12))
                'txtFPCCRESO.Text = Trim(tbl.Rows(0).Item(13))
                lblFPCCSECU.Text = Trim(tbl.Rows(0).Item(14))
                'txtFPCCNURE.Text = Trim(tbl.Rows(0).Item(15))
                'txtFPCCESTA.Text = Trim(tbl.Rows(0).Item(16))
                'txtFPCCUSIN.Text = Trim(tbl.Rows(0).Item(17))
                'txtFPCCUSMO.Text = Trim(tbl.Rows(0).Item(18))
                'txtFPCCFEIN.Text = Trim(tbl.Rows(0).Item(19))
                'txtFPCCFEMO.Text = Trim(tbl.Rows(0).Item(20))
                'txtFPCCMAQU.Text = Trim(tbl.Rows(0).Item(21))

                '===========================================
                'CARGA LA DESCRIPCIÓN DE LA LISTA DE VALORES
                '===========================================

                lblFPCCCOPA.Text = CType(fun_Buscar_Lista_Valores_CODICALI_COCACOPA(txtFPCCCODI.Text), String)
                lblFPCCCOHI.Text = CType(fun_Buscar_Lista_Valores_CODICALI_COCACOHI(txtFPCCCODI.Text), String)

                '==========================================================
                'SUMA LOS PUNTOS DE CALIFICACION DE CONSTRUCCION POR UNIDAD
                '==========================================================

                pro_SumaPuntosDeCalificacionDeConstruccion()

            Catch ex As Exception
                MessageBox.Show(Err.Description)
            End Try

        End If
    End Sub
    Private Sub pro_LimpiarCamposCalificacion()
        lblFPCCIDRE.Text = ""
        lblFPCCSECU.Text = ""
        lblFPCCCOPA.Text = ""
        lblFPCCCOHI.Text = ""
        lblFPCCTOTA.Text = ""
        txtFPCCCODI.Text = ""
        'rbdFPCCRESI.Checked = False
        'rbdFPCCCOME.Checked = False
        'rbdFPCCINDU.Checked = False
        'rbdFPCCOTRA.Checked = False

    End Sub
    Private Sub pro_SumaPuntosDeCalificacionDeConstruccion()
        Dim objdatos2 As New cla_FIPRCACO
        Dim tbl1 As New DataTable

        tbl1 = objdatos2.fun_Consultar_SUMA_X_FPCCPUNT_FIPRCACO(Val(txtFIPRNUFI.Text), Trim(txtFPCOUNID.Text))

        Dim i As Integer
        Dim inTOTAL As Integer

        If tbl1.Rows.Count > 0 Then

            For i = 0 To tbl1.Rows.Count - 1
                inTOTAL += CType(tbl1.Rows(i).Item(0), Integer)
            Next

        End If

        lblFPCCTOTA.Text = inTOTAL.ToString

    End Sub

#End Region

#Region "PROCEDIMIENTOS LINDEROS"

    Private Sub pro_ReconsultarLinderos()
        Try
            '*** Reconsulte destino si ficha predial tiene registros
            If BindingSource_FICHPRED_1.Count > 0 Then

                BindingNavigator_FIPRLIND_1.Enabled = True

                Dim objdatos As New cla_FIPRLIND

                BindingSource_FIPRLIND_1.DataSource = objdatos.fun_Consultar_FIPRLIND(Val(txtFIPRNUFI.Text))
                dgvFIPRLIND.DataSource = BindingSource_FIPRLIND_1.DataSource
                BindingNavigator_FIPRLIND_1.BindingSource = BindingSource_FIPRLIND_1

                dgvFIPRLIND.Columns(0).Visible = False
                dgvFIPRLIND.Columns(1).Visible = False

                Me.dgvFIPRLIND.Columns(2).Width = 100
                Me.dgvFIPRLIND.Columns(3).Width = 150
                Me.dgvFIPRLIND.Columns(4).Width = 200
                Me.dgvFIPRLIND.Columns(5).Width = 100

                Dim ContarRegistros As Integer = BindingSource_FIPRLIND_1.Count

                '========================
                '*** LLENA LOS CAMPOS ***
                '========================

                Dim tbl10 As New DataTable

                tbl10 = objdatos.fun_Consultar_FIPRLIND(Val(txtFIPRNUFI.Text))

                If tbl10.Rows.Count > 0 Then

                    lblFPLIIDRE.Text = Trim(tbl10.Rows(0).Item(0))
                    lblFPLISECU.Text = Trim(tbl10.Rows(0).Item(1))
                    txtFPLIPUCA.Text = Trim(tbl10.Rows(0).Item(2))
                    lblFPLIDESC.Text = Trim(tbl10.Rows(0).Item(3))
                    txtFPLICOLI.Text = Trim(tbl10.Rows(0).Item(4))

                End If

                '==================================================
                '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
                '==================================================

                Dim objdatos1 As New cla_CONTRASENA
                Dim tbl1 As New DataTable

                tbl1 = objdatos1.fun_Buscar_USUARIO_CONTRASENA(vp_usuario)

                Dim boCONTAGRE As Boolean = Trim(tbl1.Rows(0).Item(5))
                Dim boCONTMODI As Boolean = Trim(tbl1.Rows(0).Item(6))
                Dim boCONTELIM As Boolean = Trim(tbl1.Rows(0).Item(7))

                If boCONTAGRE = True Then
                    cmdAGREGAR_FIPRLIND.Enabled = True
                Else
                    cmdAGREGAR_FIPRLIND.Enabled = False
                End If

                If ContarRegistros = 0 Then
                    cmdMODIFICAR_FIPRLIND.Enabled = False
                Else
                    If boCONTMODI = True Then
                        cmdMODIFICAR_FIPRLIND.Enabled = True
                    Else
                        cmdMODIFICAR_FIPRLIND.Enabled = False
                    End If
                End If

                If ContarRegistros = 0 Then
                    cmdELIMINAR_FIPRLIND.Enabled = False
                Else
                    If boCONTELIM = True Then
                        cmdELIMINAR_FIPRLIND.Enabled = True
                    Else
                        cmdELIMINAR_FIPRLIND.Enabled = False
                    End If
                End If

                If ContarRegistros = 0 Then
                    cmdCONSULTAR_FIPRLIND.Enabled = False
                Else
                    cmdCONSULTAR_FIPRLIND.Enabled = True
                End If

                If ContarRegistros = 0 Then
                    cmdRECONSULTAR_FIPRLIND.Enabled = False
                Else
                    cmdRECONSULTAR_FIPRLIND.Enabled = True
                End If

                ' PERMISOS DE INTERVENTORIA
                If Trim(Me.txtRESOTIRE.Text) = "185" Then
                    Me.cmdAGREGAR_FIPRLIND.Enabled = False
                    Me.cmdMODIFICAR_FIPRLIND.Enabled = False
                    Me.cmdELIMINAR_FIPRLIND.Enabled = False
                End If

            Else
                BindingNavigator_FIPRLIND_1.Enabled = False
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresLinderos()
        '============================================================
        'Verifica si existen registros para traer la lista de valores
        '============================================================

        If BindingSource_FIPRLIND_1.Count > 0 Then

            '=============================
            'Carga los datos en los campos
            '=============================
            Try
                Dim objdatos As New cla_FIPRLIND
                Dim tbl As New DataTable

                Dim id As Integer = (Integer.Parse(dgvFIPRLIND.CurrentRow.Cells(0).Value.ToString()))
                'Dim id As Integer = (Integer.Parse(lblFPDEIDRE.Text))

                tbl = objdatos.fun_Buscar_ID_FIPRLIND(id)

                lblFPLIIDRE.Text = Trim(tbl.Rows(0).Item("FPLIIDRE"))
                lblFPLISECU.Text = Trim(tbl.Rows(0).Item("FPLISECU"))
                txtFPLIPUCA.Text = Trim(tbl.Rows(0).Item("FPLIPUCA"))
                txtFPLICOLI.Text = Trim(tbl.Rows(0).Item("FPLICOLI"))

                '===========================================
                'CARGA LA DESCRIPCIÓN DE LA LISTA DE VALORES
                '===========================================

                lblFPLIDESC.Text = CType(fun_Buscar_Lista_Valores_PUNTCARD(Trim(txtFPLIPUCA.Text)), String)

            Catch ex As Exception
                MessageBox.Show(Err.Description & "lista de valores")
            End Try

        End If

    End Sub
    Private Sub pro_LimpiarCamposLinderos()

        lblFPLIIDRE.Text = ""
        lblFPLISECU.Text = ""
        txtFPLIPUCA.Text = ""
        lblFPLIDESC.Text = ""
        txtFPLICOLI.Text = ""

    End Sub
   
#End Region

#Region "PROCEDIMIENTOS CARTOGRAFIA"

    Private Sub pro_ReconsultarCartografia()
        Try
            '*** Reconsulte destino si ficha predial tiene registros
            If BindingSource_FICHPRED_1.Count > 0 Then

                BindingNavigator_FIPRCART_1.Enabled = True

                Dim objdatos As New cla_FIPRCART

                BindingSource_FIPRCART_1.DataSource = objdatos.fun_Consultar_FIPRCART(Val(txtFIPRNUFI.Text))
                dgvFIPRCART_1.DataSource = BindingSource_FIPRCART_1.DataSource
                dgvFIPRCART_2.DataSource = BindingSource_FIPRCART_1.DataSource
                BindingNavigator_FIPRCART_1.BindingSource = BindingSource_FIPRCART_1

                dgvFIPRCART_1.Columns(0).Visible = False
                dgvFIPRCART_1.Columns(1).Visible = False
                dgvFIPRCART_1.Columns(6).Visible = False
                dgvFIPRCART_1.Columns(7).Visible = False
                dgvFIPRCART_1.Columns(8).Visible = False
                dgvFIPRCART_1.Columns(9).Visible = False
                dgvFIPRCART_1.Columns(10).Visible = False
                dgvFIPRCART_1.Columns(11).Visible = False

                dgvFIPRCART_2.Columns(0).Visible = False
                dgvFIPRCART_2.Columns(1).Visible = False
                dgvFIPRCART_2.Columns(2).Visible = False
                dgvFIPRCART_2.Columns(3).Visible = False
                dgvFIPRCART_2.Columns(4).Visible = False
                dgvFIPRCART_2.Columns(5).Visible = False

                Dim ContarRegistros As Integer = BindingSource_FIPRCART_1.Count

                '========================
                '*** LLENA LOS CAMPOS ***
                '========================

                Dim tbl10 As New DataTable

                tbl10 = objdatos.fun_Consultar_FIPRCART(Val(txtFIPRNUFI.Text))

                If tbl10.Rows.Count > 0 Then

                    lblFPCAIDRE.Text = Trim(tbl10.Rows(0).Item(0))
                    lblFPCASECU.Text = Trim(tbl10.Rows(0).Item(1))
                    txtFPCAPLAN.Text = Trim(tbl10.Rows(0).Item(2))
                    txtFPCAVENT.Text = Trim(tbl10.Rows(0).Item(3))
                    txtFPCAESGR.Text = Trim(tbl10.Rows(0).Item(4))
                    txtFPCAVIGR.Text = Trim(tbl10.Rows(0).Item(5))
                    txtFPCAVUEL.Text = Trim(tbl10.Rows(0).Item(6))
                    txtFPCAFAJA.Text = Trim(tbl10.Rows(0).Item(7))
                    txtFPCAFOTO.Text = Trim(tbl10.Rows(0).Item(8))
                    txtFPCAVIAE.Text = Trim(tbl10.Rows(0).Item(9))
                    txtFPCAAMPL.Text = Trim(tbl10.Rows(0).Item(10))
                    txtFPCAESAE.Text = Trim(tbl10.Rows(0).Item(11))


                End If

                '==================================================
                '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
                '==================================================

                Dim objdatos1 As New cla_CONTRASENA
                Dim tbl1 As New DataTable

                tbl1 = objdatos1.fun_Buscar_USUARIO_CONTRASENA(vp_usuario)

                Dim boCONTAGRE As Boolean = Trim(tbl1.Rows(0).Item(5))
                Dim boCONTMODI As Boolean = Trim(tbl1.Rows(0).Item(6))
                Dim boCONTELIM As Boolean = Trim(tbl1.Rows(0).Item(7))

                If boCONTAGRE = True Then
                    cmdAGREGAR_FIPRCART.Enabled = True
                Else
                    cmdAGREGAR_FIPRCART.Enabled = False
                End If

                If ContarRegistros = 0 Then
                    cmdMODIFICAR_FIPRCART.Enabled = False
                Else
                    If boCONTMODI = True Then
                        cmdMODIFICAR_FIPRCART.Enabled = True
                    Else
                        cmdMODIFICAR_FIPRCART.Enabled = False
                    End If
                End If

                If ContarRegistros = 0 Then
                    cmdELIMINAR_FIPRCART.Enabled = False
                Else
                    If boCONTELIM = True Then
                        cmdELIMINAR_FIPRCART.Enabled = True
                    Else
                        cmdELIMINAR_FIPRCART.Enabled = False
                    End If
                End If

                If ContarRegistros = 0 Then
                    cmdCONSULTAR_FIPRCART.Enabled = False
                Else
                    cmdCONSULTAR_FIPRCART.Enabled = True
                End If

                If ContarRegistros = 0 Then
                    cmdRECONSULTAR_FIPRCART.Enabled = False
                Else
                    cmdRECONSULTAR_FIPRCART.Enabled = True
                End If

                ' PERMISOS DE INTERVENTORIA
                If Trim(Me.txtRESOTIRE.Text) = "185" Then
                    Me.cmdAGREGAR_FIPRCART.Enabled = False
                    Me.cmdMODIFICAR_FIPRCART.Enabled = False
                    Me.cmdELIMINAR_FIPRCART.Enabled = False
                End If

            Else
                BindingNavigator_FIPRCART_1.Enabled = False
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresCartografia()
        '============================================================
        'Verifica si existen registros para traer la lista de valores
        '============================================================

        If BindingSource_FIPRCART_1.Count > 0 Then

            '=============================
            'Carga los datos en los campos
            '=============================
            Try
                Dim objdatos As New cla_FIPRCART
                Dim tbl As New DataTable

                Dim id As Integer = (Integer.Parse(dgvFIPRCART_1.CurrentRow.Cells(0).Value.ToString()))
                'Dim id As Integer = (Integer.Parse(lblFPDEIDRE.Text))

                tbl = objdatos.fun_Buscar_ID_FIPRCART(id)

                lblFPCAIDRE.Text = Trim(tbl.Rows(0).Item(0))
                lblFPCASECU.Text = Trim(tbl.Rows(0).Item(18))
                txtFPCAPLAN.Text = Trim(tbl.Rows(0).Item(2))
                txtFPCAVENT.Text = Trim(tbl.Rows(0).Item(3))
                txtFPCAESGR.Text = Trim(tbl.Rows(0).Item(4))
                txtFPCAVIGR.Text = Trim(tbl.Rows(0).Item(5))
                txtFPCAVUEL.Text = Trim(tbl.Rows(0).Item(6))
                txtFPCAFAJA.Text = Trim(tbl.Rows(0).Item(7))
                txtFPCAFOTO.Text = Trim(tbl.Rows(0).Item(8))
                txtFPCAVIAE.Text = Trim(tbl.Rows(0).Item(9))
                txtFPCAAMPL.Text = Trim(tbl.Rows(0).Item(10))
                txtFPCAESAE.Text = Trim(tbl.Rows(0).Item(11))

            Catch ex As Exception
                MessageBox.Show(Err.Description & "lista de valores")
            End Try

        End If

    End Sub
    Private Sub pro_LimpiarCamposCartografia()

        lblFPCAIDRE.Text = ""
        lblFPCASECU.Text = ""
        txtFPCAPLAN.Text = ""
        txtFPCAVENT.Text = ""
        txtFPCAESGR.Text = ""
        txtFPCAVIGR.Text = ""
        txtFPCAVUEL.Text = ""
        txtFPCAFAJA.Text = ""
        txtFPCAFOTO.Text = ""
        txtFPCAVIAE.Text = ""
        txtFPCAAMPL.Text = ""
        txtFPCAESAE.Text = ""

    End Sub

#End Region

#Region "PROCEDIMIENTOS ZONA FISICA"

    Private Sub pro_ReconsultarZonaFisica()
        Try
            '*** Reconsulte destino si ficha predial tiene registros
            If BindingSource_FICHPRED_1.Count > 0 Then

                BindingNavigator_FIPRZOFI_1.Enabled = True

                Dim objdatos As New cla_FIPRZOFI

                BindingSource_FIPRZOFI_1.DataSource = objdatos.fun_Consultar_FIPRZOFI(Val(txtFIPRNUFI.Text))
                dgvFIPRZOFI.DataSource = BindingSource_FIPRZOFI_1.DataSource
                BindingNavigator_FIPRZOFI_1.BindingSource = BindingSource_FIPRZOFI_1

                dgvFIPRZOFI.Columns(0).Visible = False
                dgvFIPRZOFI.Columns(1).Visible = False

                Me.dgvFIPRZOFI.Columns(2).Width = 150
                Me.dgvFIPRZOFI.Columns(3).Width = 350
                Me.dgvFIPRZOFI.Columns(4).Width = 100

                Dim ContarRegistros As Integer = BindingSource_FIPRZOFI_1.Count

                '========================
                '*** LLENA LOS CAMPOS ***
                '========================

                Dim tbl10 As New DataTable

                tbl10 = objdatos.fun_Consultar_FIPRZOFI(Val(txtFIPRNUFI.Text))

                If tbl10.Rows.Count > 0 Then

                    lblFPZFIDRE.Text = Trim(tbl10.Rows(0).Item(0))
                    lblFPZFSECU.Text = Trim(tbl10.Rows(0).Item(1))
                    txtFPZFZOFI.Text = Trim(tbl10.Rows(0).Item(2))
                    lblFPZFDESC.Text = Trim(tbl10.Rows(0).Item(3))
                    txtFPZFPORC.Text = Trim(tbl10.Rows(0).Item(4))

                    '===================================================
                    '*** SUMA EL PORCENTAJE DE DESTINACION ECONOMICA ***
                    '===================================================

                    pro_SumarPorcentajeZonaFisica()

                End If

                '==================================================
                '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
                '==================================================

                Dim objdatos1 As New cla_CONTRASENA
                Dim tbl1 As New DataTable

                tbl1 = objdatos1.fun_Buscar_USUARIO_CONTRASENA(vp_usuario)

                Dim boCONTAGRE As Boolean = Trim(tbl1.Rows(0).Item(5))
                Dim boCONTMODI As Boolean = Trim(tbl1.Rows(0).Item(6))
                Dim boCONTELIM As Boolean = Trim(tbl1.Rows(0).Item(7))

                If boCONTAGRE = True Then
                    cmdAGREGAR_FIPRZOFI.Enabled = True
                Else
                    cmdAGREGAR_FIPRZOFI.Enabled = False
                End If

                If ContarRegistros = 0 Then
                    cmdMODIFICAR_FIPRZOFI.Enabled = False
                Else
                    If boCONTMODI = True Then
                        cmdMODIFICAR_FIPRZOFI.Enabled = True
                    Else
                        cmdMODIFICAR_FIPRZOFI.Enabled = False
                    End If
                End If

                If ContarRegistros = 0 Then
                    cmdELIMINAR_FIPRZOFI.Enabled = False
                Else
                    If boCONTELIM = True Then
                        cmdELIMINAR_FIPRZOFI.Enabled = True
                    Else
                        cmdELIMINAR_FIPRZOFI.Enabled = False
                    End If
                End If

                If ContarRegistros = 0 Then
                    cmdCONSULTAR_FIPRZOFI.Enabled = False
                Else
                    cmdCONSULTAR_FIPRZOFI.Enabled = True
                End If

                If ContarRegistros = 0 Then
                    cmdRECONSULTAR_FIPRZOFI.Enabled = False
                Else
                    cmdRECONSULTAR_FIPRZOFI.Enabled = True
                End If

                ' PERMISOS DE INTERVENTORIA
                If Trim(Me.txtRESOTIRE.Text) = "185" Then
                    Me.cmdAGREGAR_FIPRZOFI.Enabled = False
                    Me.cmdMODIFICAR_FIPRZOFI.Enabled = False
                    Me.cmdELIMINAR_FIPRZOFI.Enabled = False
                End If

            Else
                BindingNavigator_FIPRZOFI_1.Enabled = False
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresZonaFisica()
        '============================================================
        'Verifica si existen registros para traer la lista de valores
        '============================================================

        If BindingSource_FIPRZOFI_1.Count > 0 Then

            '=============================
            'Carga los datos en los campos
            '=============================
            Try
                Dim objdatos As New cla_FIPRZOFI
                Dim tbl As New DataTable

                Dim id As Integer = (Integer.Parse(dgvFIPRZOFI.CurrentRow.Cells(0).Value.ToString()))
                'Dim id As Integer = (Integer.Parse(lblFPDEIDRE.Text))

                tbl = objdatos.fun_Buscar_ID_FIPRZOFI(id)

                lblFPZFIDRE.Text = Trim(tbl.Rows(0).Item("FPZFIDRE"))
                lblFPZFSECU.Text = Trim(tbl.Rows(0).Item("FPZFSECU"))
                txtFPZFZOFI.Text = Trim(tbl.Rows(0).Item("FPZFZOFI"))
                txtFPZFPORC.Text = Trim(tbl.Rows(0).Item("FPZFPORC"))

                Dim stFPZFDEPA As String = Trim(tbl.Rows(0).Item("FPZFDEPA"))
                Dim stFPZFMUNI As String = Trim(tbl.Rows(0).Item("FPZFMUNI"))
                Dim stFPZFCLSE As String = Trim(tbl.Rows(0).Item("FPZFCLSE"))

                '===========================================
                'CARGA LA DESCRIPCIÓN DE LA LISTA DE VALORES
                '===========================================

                lblFPZFDESC.Text = CType(fun_Buscar_Lista_Valores_ZONAFISI(stFPZFDEPA, stFPZFMUNI, stFPZFCLSE, txtFPZFZOFI.Text), String)

            Catch ex As Exception
                MessageBox.Show(Err.Description & "lista de valores")
            End Try

        End If

    End Sub
    Private Sub pro_LimpiarCamposZonaFisica()

        lblFPZFIDRE.Text = ""
        lblFPZFSECU.Text = ""
        txtFPZFZOFI.Text = ""
        lblFPZFDESC.Text = ""
        txtFPZFPORC.Text = ""
        lblFPZFTOTA.Text = ""

    End Sub
    Private Sub pro_SumarPorcentajeZonaFisica()
        Dim objdatos2 As New cla_FIPRZOFI
        Dim tbl1 As New DataTable

        tbl1 = objdatos2.fun_Consultar_SUMA_X_FPZFPORC_FIPRZOFI(Val(txtFIPRNUFI.Text))

        Dim i As Integer
        Dim inTOTAL As Integer

        If tbl1.Rows.Count > 0 Then

            For i = 0 To tbl1.Rows.Count - 1
                inTOTAL += Trim(tbl1.Rows(i).Item("FPZFPORC"))
            Next

        End If

        lblFPZFTOTA.Text = inTOTAL.ToString

    End Sub

#End Region

#Region "PROCEDIMIENTOS ZONA ECONOMICA"

    Private Sub pro_ReconsultarZonaEconomica()
        Try
            '*** Reconsulte destino si ficha predial tiene registros
            If BindingSource_FICHPRED_1.Count > 0 Then

                BindingNavigator_FIPRZOEC_1.Enabled = True

                Dim objdatos As New cla_FIPRZOEC

                BindingSource_FIPRZOEC_1.DataSource = objdatos.fun_Consultar_FIPRZOEC(Val(txtFIPRNUFI.Text))
                dgvFIPRZOEC.DataSource = BindingSource_FIPRZOEC_1.DataSource
                BindingNavigator_FIPRZOEC_1.BindingSource = BindingSource_FIPRZOEC_1

                dgvFIPRZOEC.Columns(0).Visible = False
                dgvFIPRZOEC.Columns(1).Visible = False

                Me.dgvFIPRZOEC.Columns(2).Width = 150
                Me.dgvFIPRZOEC.Columns(3).Width = 350
                Me.dgvFIPRZOEC.Columns(4).Width = 100

                Dim ContarRegistros As Integer = BindingSource_FIPRZOEC_1.Count

                '========================
                '*** LLENA LOS CAMPOS ***
                '========================

                Dim tbl10 As New DataTable

                tbl10 = objdatos.fun_Consultar_FIPRZOEC(Val(txtFIPRNUFI.Text))

                If tbl10.Rows.Count > 0 Then

                    lblFPZEIDRE.Text = Trim(tbl10.Rows(0).Item(0))
                    lblFPZESECU.Text = Trim(tbl10.Rows(0).Item(1))
                    txtFPZEZOEC.Text = Trim(tbl10.Rows(0).Item(2))
                    lblFPZEDESC.Text = Trim(tbl10.Rows(0).Item(3))
                    txtFPZEPORC.Text = Trim(tbl10.Rows(0).Item(4))

                    '===================================================
                    '*** SUMA EL PORCENTAJE DE DESTINACION ECONOMICA ***
                    '===================================================

                    pro_SumarPorcentajeZonaEconomica()

                End If

                '==================================================
                '*** ASIGNA LOS PRIVILEGIOS DE LA BARRA DE MENU ***
                '==================================================

                Dim objdatos1 As New cla_CONTRASENA
                Dim tbl1 As New DataTable

                tbl1 = objdatos1.fun_Buscar_USUARIO_CONTRASENA(vp_usuario)

                Dim boCONTAGRE As Boolean = Trim(tbl1.Rows(0).Item(5))
                Dim boCONTMODI As Boolean = Trim(tbl1.Rows(0).Item(6))
                Dim boCONTELIM As Boolean = Trim(tbl1.Rows(0).Item(7))

                If boCONTAGRE = True Then
                    cmdAGREGAR_FIPRZOEC.Enabled = True
                Else
                    cmdAGREGAR_FIPRZOEC.Enabled = False
                End If

                If ContarRegistros = 0 Then
                    cmdMODIFICAR_FIPRZOEC.Enabled = False
                Else
                    If boCONTMODI = True Then
                        cmdMODIFICAR_FIPRZOEC.Enabled = True
                    Else
                        cmdMODIFICAR_FIPRZOEC.Enabled = False
                    End If
                End If

                If ContarRegistros = 0 Then
                    cmdELIMINAR_FIPRZOEC.Enabled = False
                Else
                    If boCONTELIM = True Then
                        cmdELIMINAR_FIPRZOEC.Enabled = True
                    Else
                        cmdELIMINAR_FIPRZOEC.Enabled = False
                    End If
                End If

                If ContarRegistros = 0 Then
                    cmdCONSULTAR_FIPRZOEC.Enabled = False
                Else
                    cmdCONSULTAR_FIPRZOEC.Enabled = True
                End If

                If ContarRegistros = 0 Then
                    cmdRECONSULTAR_FIPRZOEC.Enabled = False
                Else
                    cmdRECONSULTAR_FIPRZOEC.Enabled = True
                End If

                ' PERMISOS DE INTERVENTORIA
                If Trim(Me.txtRESOTIRE.Text) = "185" Then
                    Me.cmdAGREGAR_FIPRZOEC.Enabled = False
                    Me.cmdMODIFICAR_FIPRZOEC.Enabled = False
                    Me.cmdELIMINAR_FIPRZOEC.Enabled = False
                End If

            Else
                BindingNavigator_FIPRZOEC_1.Enabled = False
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ListaDeValoresZonaEconomica()
        '============================================================
        'Verifica si existen registros para traer la lista de valores
        '============================================================

        If BindingSource_FIPRZOEC_1.Count > 0 Then

            '=============================
            'Carga los datos en los campos
            '=============================
            Try
                Dim objdatos As New cla_FIPRZOEC
                Dim tbl As New DataTable

                Dim id As Integer = (Integer.Parse(dgvFIPRZOEC.CurrentRow.Cells(0).Value.ToString()))
                'Dim id As Integer = (Integer.Parse(lblFPDEIDRE.Text))

                tbl = objdatos.fun_Buscar_ID_FIPRZOEC(id)

                lblFPZEIDRE.Text = Trim(tbl.Rows(0).Item("FPZEIDRE"))
                lblFPZESECU.Text = Trim(tbl.Rows(0).Item("FPZESECU"))
                txtFPZEZOEC.Text = Trim(tbl.Rows(0).Item("FPZEZOEC"))
                txtFPZEPORC.Text = Trim(tbl.Rows(0).Item("FPZEPORC"))

                Dim stFPZEDEPA As String = Trim(tbl.Rows(0).Item("FPZEDEPA"))
                Dim stFPZEMUNI As String = Trim(tbl.Rows(0).Item("FPZEMUNI"))
                Dim stFPZECLSE As String = Trim(tbl.Rows(0).Item("FPZECLSE"))

                '===========================================
                'CARGA LA DESCRIPCIÓN DE LA LISTA DE VALORES
                '===========================================

                lblFPZEDESC.Text = CType(fun_Buscar_Lista_Valores_ZONAECON(stFPZEDEPA, stFPZEMUNI, stFPZECLSE, txtFPZEZOEC.Text), String)

            Catch ex As Exception
                MessageBox.Show(Err.Description & "lista de valores")
            End Try

        End If

    End Sub
    Private Sub pro_LimpiarCamposZonaEconomica()

        lblFPZEIDRE.Text = ""
        lblFPZESECU.Text = ""
        txtFPZEZOEC.Text = ""
        lblFPZEDESC.Text = ""
        txtFPZEPORC.Text = ""
        lblFPZETOTA.Text = ""

    End Sub
    Private Sub pro_SumarPorcentajeZonaEconomica()
        Dim objdatos2 As New cla_FIPRZOEC
        Dim tbl1 As New DataTable

        tbl1 = objdatos2.fun_Consultar_SUMA_X_FPZEPORC_FIPRZOEC(Val(txtFIPRNUFI.Text))

        Dim i As Integer
        Dim inTOTAL As Integer

        If tbl1.Rows.Count > 0 Then

            For i = 0 To tbl1.Rows.Count - 1
                inTOTAL += Trim(tbl1.Rows(i).Item("FPZEPORC"))
            Next

        End If

        lblFPZETOTA.Text = inTOTAL.ToString

    End Sub

#End Region

#Region "MENU RESOLUCION"

    Private Sub tsRESOLUCION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRESOLUCION.Click
        Try
            vp_FichaPredial = 0

            frm_consultar_RESOLUCION_FICHPRED.ShowDialog()

            '*** LLENO CAMPOS DE RESOLUCIÓN SU FUE SELECCIONADA ***
            If vp_FichaPredial <> 0 Then
                pro_LimpiarCamposFichaPredial()
                pro_LimpiarCamposDestinoEconomico()
                pro_LimpiarCamposPropietario()
                pro_LimpiarCamposConstruccion()
                pro_LimpiarCamposCalificacion()
                pro_LimpiarCamposLinderos()
                pro_LimpiarCamposCartografia()
                pro_LimpiarCamposZonaFisica()
                pro_LimpiarCamposZonaEconomica()

                ' Limpiar los datagridview de ficha predial
                Dim tbl As New DataTable

                BindingSource_FIPRDEEC_1.DataSource = tbl
                dgvFIPRDEEC.DataSource = BindingSource_FIPRDEEC_1.DataSource

                BindingSource_FIPRPROP_1.DataSource = tbl
                dgvFIPRPROP.DataSource = BindingSource_FIPRPROP_1.DataSource

                BindingSource_FIPRCONS_1.DataSource = tbl
                dgvFIPRCONS.DataSource = BindingSource_FIPRCONS_1.DataSource
                dgvFIPRCOCA.DataSource = BindingSource_FIPRCONS_1.DataSource

                BindingSource_FIPRCACO_1.DataSource = tbl
                dgvFIPRCACO.DataSource = BindingSource_FIPRCACO_1.DataSource

                BindingSource_FIPRLIND_1.DataSource = tbl
                dgvFIPRLIND.DataSource = BindingSource_FIPRLIND_1.DataSource

                BindingSource_FIPRCART_1.DataSource = tbl
                dgvFIPRCART_1.DataSource = BindingSource_FIPRCART_1.DataSource
                dgvFIPRCART_2.DataSource = BindingSource_FIPRCART_1.DataSource

                BindingSource_FIPRZOFI_1.DataSource = tbl
                dgvFIPRZOFI.DataSource = BindingSource_FIPRZOFI_1.DataSource

                BindingSource_FIPRZOEC_1.DataSource = tbl
                dgvFIPRZOEC.DataSource = BindingSource_FIPRZOEC_1.DataSource


                '====================================================================

                pro_inicializarControlesResolucion()
                pro_AsignarPermisosFichaPredial()
                vp_FichaPredial = 0
            End If

            vp_FichaPredial = 0

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "MENU FICHA PREDIAL"

    Private Sub cmdAGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_FICHPRED.Click
        Try
            'Verifica que exista una resolución y una ficha predial
            If Trim(lblRESODESC.Text) = "" Then
                vp_FichaPredial = 0

                'Abre el formulario para consultar la resolución
                frm_consultar_RESOLUCION_FICHPRED.ShowDialog()

                'Verifica que se halla seleccionado una resolución
                If vp_FichaPredial <> 0 Then

                    'Muestras la descripción de los códigos de la resolución
                    pro_inicializarControlesResolucion()
                    vp_FichaPredial = 0

                    ' concatena la resolución
                    pro_ObtenerResolucionCancatenada()

                    'Abre el formulario de ficha predial y le envia los datos de la resolución
                    Dim frm_insertar As New frm_insertar_FICHPRED(txtRESODEPA.Text, txtRESOMUNI.Text, Val(txtRESOTIRE.Text), Val(txtRESOCLSE.Text), Val(txtRESOVIGE.Text), Val(txtRESOCODI.Text), vl_stFIPRCORE)
                    frm_insertar.ShowDialog()

                    'Verifica que se halla ingresado la ficha predial
                    If vp_FichaPredial <> 0 Then

                        '*** RECONSULTAR FICHA PREDIAL *** 
                        pro_ReconsultarFichaPredialxFichaPredial()
                        pro_ListaDeValoresFichaPredial()

                        '===============================================
                        '*** INFORMACIÓN DE LAS PESTAÑAS SECUNDARIAS ***
                        '===============================================

                        pro_LimpiarCamposDestinoEconomico()
                        pro_ReconsultarDestinoEconomico()

                        pro_LimpiarCamposPropietario()
                        pro_ReconsultarPropietario()

                        pro_LimpiarCamposConstruccion()
                        pro_ReconsultarConstruccion()

                        pro_LimpiarCamposCalificacion()
                        pro_ReconsultarCalificacion()

                        pro_LimpiarCamposLinderos()
                        pro_ReconsultarLinderos()

                        pro_LimpiarCamposCartografia()
                        pro_ReconsultarCartografia()

                        pro_LimpiarCamposZonaFisica()
                        pro_ReconsultarZonaFisica()

                        pro_LimpiarCamposZonaEconomica()
                        pro_ReconsultarZonaEconomica()

                        'Como existe una ficha ingresada pregusta por el destino económico
                        If Trim(txtFIPRNUFI.Text) <> "" Then
                            If vp_FichaPredial <> 0 Then

                                If MessageBox.Show("Desea ingresar el Destino Economico", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                    tabINSCFICHPRED.SelectTab(tabFIPRDEEC)
                                    cmdAGREGAR_FIPRDEEC.PerformClick()
                                Else
                                    tabINSCFICHPRED.SelectTab(TabFICHPRED)
                                End If
                            End If
                        End If
                    Else
                        'Si el usuario cancelo la operación se reconsulta el nro de ficha vigente
                        If Trim(txtFIPRNUFI.Text) <> "" Then

                            vp_FichaPredial = Val(txtFIPRNUFI.Text)
                            pro_ReconsultarFichaPredialxFichaPredial()
                            pro_ListaDeValoresFichaPredial()
                        End If
                    End If
                End If
            Else
                ' concatena la resolución
                pro_ObtenerResolucionCancatenada()

                'Abre el formulario de ficha predial y le envia los datos de la resolución
                Dim frm_insertar As New frm_insertar_FICHPRED(txtRESODEPA.Text, txtRESOMUNI.Text, Val(txtRESOTIRE.Text), Val(txtRESOCLSE.Text), Val(txtRESOVIGE.Text), Val(txtRESOCODI.Text), vl_stFIPRCORE)
                frm_insertar.ShowDialog()

                'Verifica que se halla ingresado la ficha predial
                If vp_FichaPredial <> 0 Then
                    pro_ReconsultarFichaPredialxFichaPredial()
                    pro_ListaDeValoresFichaPredial()

                    '===============================================
                    '*** INFORMACIÓN DE LAS PESTAÑAS SECUNDARIAS ***
                    '===============================================

                    pro_LimpiarCamposDestinoEconomico()
                    pro_ReconsultarDestinoEconomico()

                    pro_LimpiarCamposPropietario()
                    pro_ReconsultarPropietario()

                    pro_LimpiarCamposConstruccion()
                    pro_ReconsultarConstruccion()

                    pro_LimpiarCamposCalificacion()
                    pro_ReconsultarCalificacion()

                    pro_LimpiarCamposLinderos()
                    pro_ReconsultarLinderos()

                    pro_LimpiarCamposCartografia()
                    pro_ReconsultarCartografia()

                    pro_LimpiarCamposZonaFisica()
                    pro_ReconsultarZonaFisica()

                    pro_LimpiarCamposZonaEconomica()
                    pro_ReconsultarZonaEconomica()

                    'Como existe una ficha ingresada pregusta por el destino económico
                    If Trim(txtFIPRNUFI.Text) <> "" Then
                        If vp_FichaPredial <> 0 Then

                            If MessageBox.Show("Desea ingresar el Destino Economico", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                                tabINSCFICHPRED.SelectTab(tabFIPRDEEC)
                                cmdAGREGAR_FIPRDEEC.PerformClick()
                            Else
                                tabINSCFICHPRED.SelectTab(TabFICHPRED)
                            End If
                        End If
                    End If
                Else
                    If Trim(txtFIPRNUFI.Text) <> "" Then

                        vp_FichaPredial = Val(txtFIPRNUFI.Text)
                        pro_ReconsultarFichaPredialxFichaPredial()
                        pro_ListaDeValoresFichaPredial()
                    End If
                End If
            End If


            '*** ASUME QUE NO HAY REGISTROS CARGADOS ***
            vp_FichaPredial = 0

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub
    Private Sub cmdELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_FICHPRED.Click
        Try
            Dim Codigo As String = txtFIPRNUFI.Text

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro. Ficha Predial : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim objdatos As New cla_FICHPRED

                If objdatos.fun_Eliminar_FICHPRED(txtFIPRNUFI.Text) Then
                    pro_ReconsultarFichaPredialxFichaPredial()
                    pro_LimpiarCamposFichaPredial()

                    '===============================================
                    '*** INFORMACIÓN DE LAS PESTAÑAS SECUNDARIAS ***
                    '===============================================

                    pro_LimpiarCamposDestinoEconomico()
                    pro_ReconsultarDestinoEconomico()

                    pro_ReconsultarPropietario()
                    pro_LimpiarCamposPropietario()

                    pro_LimpiarCamposConstruccion()
                    pro_ReconsultarConstruccion()

                    pro_LimpiarCamposCalificacion()
                    pro_ReconsultarCalificacion()

                    pro_LimpiarCamposLinderos()
                    pro_ReconsultarLinderos()

                    pro_LimpiarCamposCartografia()
                    pro_ReconsultarCartografia()

                    pro_LimpiarCamposZonaFisica()
                    pro_ReconsultarZonaFisica()

                    pro_LimpiarCamposZonaEconomica()
                    pro_ReconsultarZonaEconomica()

                    ' Limpiar los datagridview de ficha predial
                    Dim tbl As New DataTable

                    BindingSource_FIPRDEEC_1.DataSource = tbl
                    dgvFIPRDEEC.DataSource = BindingSource_FIPRDEEC_1.DataSource

                    BindingSource_FIPRPROP_1.DataSource = tbl
                    dgvFIPRPROP.DataSource = BindingSource_FIPRPROP_1.DataSource

                    BindingSource_FIPRCONS_1.DataSource = tbl
                    dgvFIPRCONS.DataSource = BindingSource_FIPRCONS_1.DataSource
                    dgvFIPRCOCA.DataSource = BindingSource_FIPRCONS_1.DataSource

                    BindingSource_FIPRCACO_1.DataSource = tbl
                    dgvFIPRCACO.DataSource = BindingSource_FIPRCACO_1.DataSource

                    BindingSource_FIPRLIND_1.DataSource = tbl
                    dgvFIPRLIND.DataSource = BindingSource_FIPRLIND_1.DataSource

                    BindingSource_FIPRCART_1.DataSource = tbl
                    dgvFIPRCART_1.DataSource = BindingSource_FIPRCART_1.DataSource
                    dgvFIPRCART_2.DataSource = BindingSource_FIPRCART_1.DataSource

                    BindingSource_FIPRZOFI_1.DataSource = tbl
                    dgvFIPRZOFI.DataSource = BindingSource_FIPRZOFI_1.DataSource

                    BindingSource_FIPRZOEC_1.DataSource = tbl
                    dgvFIPRZOEC.DataSource = BindingSource_FIPRZOEC_1.DataSource

                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdMODIFICAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_FICHPRED.Click
        Try

            Dim frm_modificar As New frm_modificar_FICHPRED(txtFIPRNUFI.Text, txtRESODEPA.Text, txtRESOMUNI.Text, Val(txtRESOTIRE.Text), Val(txtRESOCLSE.Text), Val(txtRESOVIGE.Text), Val(txtRESOCODI.Text), Trim(Me.txtFIPRCORE.Text))

            frm_modificar.ShowDialog()

            If vp_FichaPredial <> 0 Then

                '*** RECONSULTAR FICHA PREDIAL *** 
                pro_ReconsultarFichaPredialxFichaPredial()
                pro_ListaDeValoresFichaPredial()

                '===============================================
                '*** INFORMACIÓN DE LAS PESTAÑAS SECUNDARIAS ***
                '===============================================

                pro_LimpiarCamposDestinoEconomico()
                pro_ReconsultarDestinoEconomico()

                pro_LimpiarCamposPropietario()
                pro_ReconsultarPropietario()

                pro_LimpiarCamposConstruccion()
                pro_ReconsultarConstruccion()

                pro_LimpiarCamposCalificacion()
                pro_ReconsultarCalificacion()

                pro_LimpiarCamposLinderos()
                pro_ReconsultarLinderos()

                pro_LimpiarCamposCartografia()
                pro_ReconsultarCartografia()

                pro_LimpiarCamposZonaFisica()
                pro_ReconsultarZonaFisica()

                pro_LimpiarCamposZonaEconomica()
                pro_ReconsultarZonaEconomica()

            End If

            vp_FichaPredial = Val(txtFIPRNUFI.Text)

            pro_ReconsultarFichaPredialxFichaPredial()
            pro_ListaDeValoresFichaPredial()

        Catch ex As Exception
            frm_INCO_modifircar_registros_sin_listas_de_valores.ShowDialog()
        End Try

    End Sub
    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_FICHPRED.Click
        Try
            'Se inicialioza consulta en 0 registros
            vp_FichaPredial = 0

            'Llamar al formulario consultar
            Dim frm_consultar_FICHPRED As New frm_consulta_total_FICHPRED
            frm_consultar_FICHPRED.ShowDialog()

            'Consulta por ficha predial
            If vp_FichaPredial > 0 Then

                Dim objdatos As New cla_FICHPRED
                Dim tbl_Nro_Ficha As New DataTable

                tbl_Nro_Ficha = objdatos.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(vp_FichaPredial)

                If tbl_Nro_Ficha.Rows.Count > 0 Then
                    pro_ReconsultarFichaPredialxFichaPredial()
                    pro_ListaDeValoresFichaPredial()

                    txtRESODEPA.Text = Trim(tbl_Nro_Ficha.Rows(0).Item(10))
                    txtRESOMUNI.Text = Trim(tbl_Nro_Ficha.Rows(0).Item(11))
                    txtRESOTIRE.Text = Trim(tbl_Nro_Ficha.Rows(0).Item(3))
                    txtRESOCLSE.Text = Trim(tbl_Nro_Ficha.Rows(0).Item(18))
                    txtRESOVIGE.Text = Trim(tbl_Nro_Ficha.Rows(0).Item(2))
                    txtRESOCODI.Text = Trim(tbl_Nro_Ficha.Rows(0).Item(4))
                    Me.lblRESODESC.Text = CType(fun_Buscar_Lista_Valores_RESOLUCION(Trim(Me.txtRESODEPA.Text), _
                                                                                    Trim(Me.txtRESOMUNI.Text), _
                                                                                    Trim(Me.txtRESOTIRE.Text), _
                                                                                    Trim(Me.txtRESOCLSE.Text), _
                                                                                    Trim(Me.txtRESOVIGE.Text), _
                                                                                    Trim(Me.txtRESOCODI.Text)), String)

                    pro_listaDeValoresResolucion()

                    '===============================================
                    '*** INFORMACIÓN DE LAS PESTAÑAS SECUNDARIAS ***
                    '===============================================

                    pro_LimpiarCamposDestinoEconomico()
                    pro_ReconsultarDestinoEconomico()

                    pro_LimpiarCamposPropietario()
                    pro_ReconsultarPropietario()

                    pro_LimpiarCamposConstruccion()
                    pro_ReconsultarConstruccion()

                    pro_LimpiarCamposCalificacion()
                    pro_ReconsultarCalificacion()

                    pro_LimpiarCamposLinderos()
                    pro_ReconsultarLinderos()

                    pro_LimpiarCamposCartografia()
                    pro_ReconsultarCartografia()

                    pro_LimpiarCamposZonaFisica()
                    pro_ReconsultarZonaFisica()

                    pro_LimpiarCamposZonaEconomica()
                    pro_ReconsultarZonaEconomica()

                Else
                    MessageBox.Show("No se encontro ningún registros", "Mensaje ..", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRECONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_FICHPRED.Click
        vp_FichaPredial = txtFIPRNUFI.Text
        pro_ReconsultarFichaPredialxFichaPredial()
        pro_ListaDeValoresFichaPredial()
    End Sub
    Private Sub cmdFIPROBSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFIPROBSE.Click
        Try
            If Trim(txtFIPRNUFI.Text) <> "" Then
                Dim frm_modificar_FIPROBSE As New frm_modificar_FIPROBSE(Val(txtFIPRNUFI.Text))
                frm_modificar_FIPROBSE.ShowDialog()

                vp_FichaPredial = Val(txtFIPRNUFI.Text)

                pro_ReconsultarFichaPredialxFichaPredial()
                pro_ListaDeValoresFichaPredial()
            Else
                MessageBox.Show("Selecione una ficha predial", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdConsultaParametrizada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTA_PARAMETRIZADA.Click
        Try
            'Se inicialioza consulta en 0 registros
            vp_FichaPredial = 0

            'Llamar al formulario consultar
            Dim frm_consultar_FICHPRED As New frm_consultar_FICHPRED
            frm_consultar_FICHPRED.ShowDialog()

            'Consulta por ficha predial
            If vp_FichaPredial > 0 Then

                Dim objdatos As New cla_FICHPRED
                Dim tbl_Nro_Ficha As New DataTable

                tbl_Nro_Ficha = objdatos.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(vp_FichaPredial)

                If tbl_Nro_Ficha.Rows.Count > 0 Then
                    pro_ReconsultarFichaPredialxFichaPredial()
                    pro_ListaDeValoresFichaPredial()

                    txtRESODEPA.Text = Trim(tbl_Nro_Ficha.Rows(0).Item(10))
                    txtRESOMUNI.Text = Trim(tbl_Nro_Ficha.Rows(0).Item(11))
                    txtRESOTIRE.Text = Trim(tbl_Nro_Ficha.Rows(0).Item(3))
                    txtRESOCLSE.Text = Trim(tbl_Nro_Ficha.Rows(0).Item(18))
                    txtRESOVIGE.Text = Trim(tbl_Nro_Ficha.Rows(0).Item(2))
                    txtRESOCODI.Text = Trim(tbl_Nro_Ficha.Rows(0).Item(4))
                    lblRESODESC.Text = Trim(tbl_Nro_Ficha.Rows(0).Item(39))

                    pro_listaDeValoresResolucion()

                    '===============================================
                    '*** INFORMACIÓN DE LAS PESTAÑAS SECUNDARIAS ***
                    '===============================================

                    pro_LimpiarCamposDestinoEconomico()
                    pro_ReconsultarDestinoEconomico()

                    pro_LimpiarCamposPropietario()
                    pro_ReconsultarPropietario()

                    pro_LimpiarCamposConstruccion()
                    pro_ReconsultarConstruccion()

                    pro_LimpiarCamposCalificacion()
                    pro_ReconsultarCalificacion()

                    pro_LimpiarCamposLinderos()
                    pro_ReconsultarLinderos()

                    pro_LimpiarCamposCartografia()
                    pro_ReconsultarCartografia()

                    pro_LimpiarCamposZonaFisica()
                    pro_ReconsultarZonaFisica()

                    pro_LimpiarCamposZonaEconomica()
                    pro_ReconsultarZonaEconomica()

                Else
                    MessageBox.Show("No se encontro ningún registros", "Mensaje ..", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdIMagenPredio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIMagenPredio.Click
        Try
            If Trim(txtFIPRNUFI.Text) <> "" Then

                Dim frm_imagen_PREDIO As New frm_imagen_PREDIO(Trim(Val(Me.txtFIPRNUFI.Text)))
                frm_imagen_PREDIO.ShowDialog()

                vp_FichaPredial = Val(txtFIPRNUFI.Text)

            Else
                MessageBox.Show("Selecione una ficha predial", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

    Private Sub cmdFIPRVALI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFIPRVALI.Click

        Try
            pro_ValidarFichaPredial()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdLiquidaAvaluo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLiquidaAvaluo.Click
        Try
            If Trim(txtFIPRNUFI.Text) = "" Then
                MessageBox.Show("Selecione una ficha predial", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim objdatos As New cla_FIPRAVAL
                Dim dt As DataTable

                ' Liquida avaluo predial
                pro_LIQUIDA_AVALUO_FICHA_PREDIAL(Trim(Me.txtFIPRNUFI.Text), Trim(Me.txtRESOTIRE.Text), Trim(Me.txtRESOVIGE.Text), Trim(Me.txtFIPRNUFI.Text), "Liquidado forma ficha predial")

                ' Almacena el avaluo catastral
                dt = objdatos.fun_Consultar_AVALUO_X_FICHA_PREDIAL(Trim(Me.txtFIPRNUFI.Text))

                ' Verifica si existen registros de avaluos
                If dt.Rows.Count > 0 Then
                    Dim frm_FIPRAVAL As New frm_liquicacion_AVALUOS(Trim(txtFIPRNUFI.Text))
                    frm_FIPRAVAL.ShowDialog()
                Else
                    MessageBox.Show("Ficha NO liquido avalúo catastral", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    chkFIPRINCO.Checked = False
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdLiquidaPredial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLiquidaPredial.Click
        Try
            If Trim(txtFIPRNUFI.Text) = "" Then
                MessageBox.Show("Selecione una ficha predial", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim objdatos As New cla_PREDIAL
                Dim dt As DataTable

                ' Liquida avaluo predial
                pro_LIQUIDA_PREDIAL_FICHA_PREDIAL(Trim(Me.txtFIPRNUFI.Text), Trim(Me.txtRESOTIRE.Text), Trim(Me.txtRESOVIGE.Text), Trim(Me.txtFIPRNUFI.Text))

                ' Almacena el avaluo catastral
                dt = objdatos.fun_Consultar_PREDIAL_X_FICHA_PREDIAL(Trim(Me.txtFIPRNUFI.Text))

                ' Verifica si existen registros de avaluos
                If dt.Rows.Count > 0 Then
                    Dim frm_PREDIAL As New frm_liquidacion_PREDIAL(Trim(txtFIPRNUFI.Text))
                    frm_PREDIAL.ShowDialog()
                Else
                    MessageBox.Show("Ficha NO liquido impuesto predial", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    chkFIPRINCO.Checked = False
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

    Private Sub cmdESTRFIPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdESTRFIPR.Click

        Try
            If Trim(txtFIPRNUFI.Text) <> "" Then
                Dim frm_estrato As New frm_estrato_ESTRFIPR(Val(txtFIPRNUFI.Text))
                frm_estrato.ShowDialog()

            Else
                MessageBox.Show("Selecione una ficha predial", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCAPRFIPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCAPRFIPR.Click

        Try
            If Trim(txtFIPRNUFI.Text) <> "" Then
                Dim frm_categoria As New frm_categoria_CAPRFIPR(Val(txtFIPRNUFI.Text))
                frm_categoria.ShowDialog()

            Else
                MessageBox.Show("Selecione una ficha predial", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdREGICONT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdREGICONT.Click

        Try
            If Trim(Me.txtFIPRNUFI.Text) <> "" Then
                Dim frm_REGISTRO As New frm_registro_control_FICHPRED(Val(Me.txtFIPRNUFI.Text))
                frm_REGISTRO.ShowDialog()
            Else
                MessageBox.Show("Selecione una ficha predial", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdJuridicaPredio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdJuridicaPredio.Click
        Try
            If Trim(Me.txtFIPRNUFI.Text) <> "" Then
                Dim frm_JURIDICA_PREDIO As New frm_juridica_PREDIO(Val(Me.txtFIPRNUFI.Text))
                frm_JURIDICA_PREDIO.ShowDialog()
            Else
                MessageBox.Show("Selecione una ficha predial", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub


#End Region

#Region "MENU DESTINO ECONOMICO"

    Private Sub cmdAGREGAR_FIPRDEEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_FIPRDEEC.Click
        Try
            Dim frm_insertar_FIPRDEEC As New frm_insertar_FIPRDEEC(txtFIPRNUFI.Text, txtFIPRNURE.Text, txtRESODEPA.Text, txtRESOMUNI.Text, txtRESOTIRE.Text, txtRESOCLSE.Text, txtRESOVIGE.Text, txtRESOCODI.Text)
            frm_insertar_FIPRDEEC.ShowDialog()

            pro_ReconsultarDestinoEconomico()

            'Verifica si existen registros de propietario e inscribe
            Dim objdatos As New cla_FIPRPROP
            Dim tbl As New DataTable

            tbl = objdatos.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(vp_FichaPredial)

            If tbl.Rows.Count = 0 Then
                If MessageBox.Show("Desea ingresar el Propietario", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    tabINSCFICHPRED.SelectTab(TabFIPRPROP)
                    cmdAGREGAR_FIPRPROP.PerformClick()
                Else
                    tabINSCFICHPRED.SelectTab(tabFIPRDEEC)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub
    Private Sub cmdMODIFICAR_FIPRDEEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_FIPRDEEC.Click
        Try
            Dim frm_modificar_FIPRDEEC As New frm_modificar_FIPRDEEC(Val(lblFPDEIDRE.Text), txtFIPRNUFI.Text, txtFIPRNURE.Text, txtRESODEPA.Text, txtRESOMUNI.Text, txtRESOTIRE.Text, txtRESOCLSE.Text, txtRESOVIGE.Text, txtRESOCODI.Text)

            frm_modificar_FIPRDEEC.ShowDialog()

            pro_ReconsultarDestinoEconomico()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try



    End Sub
    Private Sub cmdELIMINAR_FIPRDEEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_FIPRDEEC.Click
        Try
            Dim Codigo As String = txtFPDEDEEC.Text

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim objdatos As New cla_FIPRDEEC

                If objdatos.fun_Eliminar_FIPRDEEC(Val(lblFPDEIDRE.Text)) = True Then
                    pro_LimpiarCamposDestinoEconomico()
                    pro_ReconsultarDestinoEconomico()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdCONSULTAR_FIPRDEEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_FIPRDEEC.Click
        Me.cmdCONSULTAR_FICHPRED.PerformClick()
    End Sub
    Private Sub cmdRECONSULTAR_FIPRDEEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_FIPRDEEC.Click
        pro_ReconsultarDestinoEconomico()
    End Sub

#End Region

#Region "MENU PROPIETARIO"

    Private Sub cmdAGREGAR_FIPRPROP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_FIPRPROP.Click
        Try
            Dim frm_insertar_FIPRPROP As New frm_insertar_FIPRPROP(txtFIPRNUFI.Text, txtFIPRNURE.Text, txtRESODEPA.Text, txtRESOMUNI.Text, txtRESOTIRE.Text, txtRESOCLSE.Text, txtRESOVIGE.Text, txtRESOCODI.Text)
            frm_insertar_FIPRPROP.ShowDialog()

            pro_ReconsultarPropietario()

            'Verifica si existen registros de construcción e inscribe
            Dim objdatos1 As New cla_PROPANTE
            Dim tbl1 As New DataTable

            tbl1 = objdatos1.fun_Buscar_PROPIETARIOS_X_NRO_DE_FICHA(vp_FichaPredial)

            If tbl1.Rows.Count = 0 Then
                If MessageBox.Show("Desea ingresar el propietario anterior", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    tabINSCFICHPRED.SelectTab(TabFIPRPROP)
                    cmdPROPANTE.PerformClick()
                Else
                    tabINSCFICHPRED.SelectTab(TabFIPRPROP)
                End If
            End If

            'Verifica si existen registros de construcción e inscribe
            Dim objdatos As New cla_FIPRCONS
            Dim tbl As New DataTable

            tbl = objdatos.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(vp_FichaPredial)

            If tbl.Rows.Count = 0 Then
                If MessageBox.Show("Desea ingresar la construcción", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    tabINSCFICHPRED.SelectTab(tabFIPRCONS)
                    cmdAGREGAR_FIPRCONS.PerformClick()
                Else
                    tabINSCFICHPRED.SelectTab(TabFIPRPROP)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdMODIFICAR_FIPRPROP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_FIPRPROP.Click
        Try
            Dim frm_modificar_FIPRPROP As New frm_modificar_FIPRPROP(Val(lblFPPRIDRE.Text), txtFIPRNUFI.Text, txtFIPRNURE.Text, txtRESODEPA.Text, txtRESOMUNI.Text, txtRESOTIRE.Text, txtRESOCLSE.Text, txtRESOVIGE.Text, txtRESOCODI.Text)

            frm_modificar_FIPRPROP.ShowDialog()

            pro_ReconsultarPropietario()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdELIMINAR_FIPRPROP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_FIPRPROP.Click
        Try
            Dim Codigo As String = txtFPPRNUDO.Text

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim objdatos As New cla_FIPRPROP

                If objdatos.fun_Eliminar_FIPRPROP(Val(lblFPPRIDRE.Text)) = True Then
                    pro_LimpiarCamposPropietario()
                    pro_ReconsultarPropietario()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdCONSULTAR_FIPRPROP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_FIPRPROP.Click
        Me.cmdCONSULTAR_FICHPRED.PerformClick()
    End Sub
    Private Sub cmdRECONSULTAR_FIPRPROP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_FIPRPROP.Click
        pro_ReconsultarPropietario()
    End Sub
    Private Sub cmdPROPANTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPROPANTE.Click

        Try
            ' consulta el propietario anterior
            If Me.dgvFIPRPROP.RowCount > 0 Then

                Dim obj3344 As New cla_PROPANTE
                Dim tbl3344 As New DataTable

                tbl3344 = obj3344.fun_Buscar_PROPIETARIOS_X_NRO_DE_FICHA_Y_NRO_DE_DOCUMENTO(Trim(Me.txtFIPRNUFI.Text), Trim(Me.txtFPPRNUDO.Text))

                If tbl3344.Rows.Count > 0 Then

                    Dim frm_modificar As New frm_modificar_PROPANTE(Trim(Me.txtFIPRNUFI.Text), Trim(Me.txtFPPRNUDO.Text))
                    frm_modificar.ShowDialog()
                    pro_ListaDeValoresPropietario()

                Else

                    Dim frm_Insertar As New frm_insertar_PROPANTE(Trim(Me.txtFIPRNUFI.Text), Trim(Me.txtFPPRNUDO.Text))
                    frm_Insertar.ShowDialog()
                    pro_ListaDeValoresPropietario()

                End If

            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU CONSTRUCCION"

    Private Sub cmdAGREGAR_FIPRCONS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_FIPRCONS.Click
        Try
            Dim frm_insertar_FIPRCONS As New frm_insertar_FIPRCONS(txtFIPRNUFI.Text, txtFIPRNURE.Text, txtRESODEPA.Text, txtRESOMUNI.Text, txtRESOTIRE.Text, txtRESOCLSE.Text, txtRESOVIGE.Text, txtRESOCODI.Text)
            frm_insertar_FIPRCONS.ShowDialog()

            pro_ReconsultarConstruccion()
            pro_ReconsultarCalificacion()

            If Me.dgvFIPRCONS.RowCount > 0 AndAlso Trim(Me.txtFPCOCLCO.Text) = "1" Or Trim(Me.txtFPCOCLCO.Text) = "3" Then

                'Verifica si existen registros de construcción e inscribe
                Dim objdatos As New cla_FIPRCACO
                Dim tbl As New DataTable

                tbl = objdatos.fun_Consultar_FIPRCACO_X_FICHA_PREDIAL(vp_FichaPredial, Me.txtFPCOUNID.Text)

                If tbl.Rows.Count = 0 Then
                    If MessageBox.Show("¿ Desea ingresar la calificación de la unidad Nro.: " & Trim(Me.txtFPCOUNID.Text) & " ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        tabINSCFICHPRED.SelectTab(TabFIPRCACO)
                        cmdAGREGAR_FIPRCACO.PerformClick()
                    Else
                        tabINSCFICHPRED.SelectTab(tabFIPRCONS)
                    End If
                End If

            Else

                'Verifica si existen registros de construcción e inscribe
                Dim objdatos As New cla_FIPRLIND
                Dim tbl As New DataTable

                tbl = objdatos.fun_Consultar_FIPRLIND_X_FICHA_PREDIAL(vp_FichaPredial)

                If tbl.Rows.Count = 0 Then
                    If MessageBox.Show("¿ Desea ingresar los linderos ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        tabINSCFICHPRED.SelectTab(tabFIPRLIND)
                        cmdAGREGAR_FIPRLIND.PerformClick()
                    Else
                        tabINSCFICHPRED.SelectTab(TabFIPRCACO)
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdMODIFICAR_FIPRCONS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_FIPRCONS.Click
        Try
            Dim frm_modificar_FIPRCONS As New frm_modificar_FIPRCONS(Val(lblFPCOIDRE.Text), txtFIPRNUFI.Text, txtFIPRNURE.Text, txtRESODEPA.Text, txtRESOMUNI.Text, txtRESOTIRE.Text, txtRESOCLSE.Text, txtRESOVIGE.Text, txtRESOCODI.Text)

            frm_modificar_FIPRCONS.ShowDialog()

            pro_ReconsultarConstruccion()
            pro_ReconsultarCalificacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdELIMINAR_FIPRCONS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_FIPRCONS.Click
        Try
            Dim Codigo As String = txtFPCOUNID.Text

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                ' eliminar los codigos de calificacion
                Dim objdatos1 As New cla_FIPRCACO

                objdatos1.fun_Eliminar_Todos_Los_Registros_FIPRCACO(Trim(txtFIPRNUFI.Text), Trim(txtFPCOUNID.Text))

                Dim objdatos As New cla_FIPRCONS

                If objdatos.fun_Eliminar_FIPRCONS(Val(lblFPCOIDRE.Text)) = True Then
                    pro_LimpiarCamposConstruccion()
                    pro_ReconsultarConstruccion()

                    pro_LimpiarCamposCalificacion()
                    pro_ReconsultarCalificacion()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdCONSULTAR_FIPRCONS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_FIPRCONS.Click
        Try

            Me.cmdCONSULTAR_FICHPRED.PerformClick()
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdRECONSULTAR_FIPRCONS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_FIPRCONS.Click
        Try
            pro_ReconsultarConstruccion()
            pro_ReconsultarCalificacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

#End Region

#Region "MENU CALIFICACION"

    Private Sub cmdAGREGAR_FIPRCACO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_FIPRCACO.Click

        Try
            ' declara la variable
            Dim stFPCCTIPO As String = ""
            Dim boMEJORA As Boolean = False

            ' instancia la clase
            Dim obFIPRCONS As New cla_FIPRCONS
            Dim dtFIPRCONS As New DataTable

            dtFIPRCONS = obFIPRCONS.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(Trim(txtFIPRNUFI.Text))

            If dtFIPRCONS.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To dtFIPRCONS.Rows.Count - 1

                    If CInt(dtFIPRCONS.Rows(i).Item("FPCOCLCO").ToString) = 1 Or _
                       CInt(dtFIPRCONS.Rows(i).Item("FPCOCLCO").ToString) = 3 Then

                        Dim inFPCOUNID As Integer = CInt(dtFIPRCONS.Rows(i).Item("FPCOUNID").ToString)
                        Dim inFPCOCLCO As Integer = CInt(dtFIPRCONS.Rows(i).Item("FPCOCLCO").ToString)
                        Dim stFPCOTICO As String = CStr(dtFIPRCONS.Rows(i).Item("FPCOTICO").ToString)
                        Dim inFPCOSECU As Integer = CInt(dtFIPRCONS.Rows(i).Item("FPCOSECU").ToString)

                        boMEJORA = CBool(dtFIPRCONS.Rows(i).Item("FPCOMEJO").ToString)

                        ' instancia la clase
                        Dim obFIPRCACO As New cla_FIPRCACO
                        Dim dtFIPRCACO As New DataTable

                        dtFIPRCACO = obFIPRCACO.fun_Consultar_FIPRCACO(Trim(txtFIPRNUFI.Text), inFPCOUNID)

                        If dtFIPRCACO.Rows.Count = 0 Then

                            If MessageBox.Show("¿ Desea ingresar la calificación de la unidad Nro.: " & Trim(inFPCOUNID) & " ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                                ' consulta el tipo de calificacion de construccion
                                Dim objdatos15 As New cla_TIPOCONS
                                Dim tbl15 As New DataTable

                                tbl15 = objdatos15.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(Trim(txtRESODEPA.Text), Trim(txtRESOMUNI.Text), inFPCOCLCO, Trim(txtRESOCLSE.Text), stFPCOTICO)

                                If tbl15.Rows.Count > 0 Then

                                    ' llena la variable
                                    stFPCCTIPO = Trim(tbl15.Rows(0).Item(4))

                                    ' ejecuta el constructor de insertar el codigo de calificación
                                    Dim frm_insertar_FIPRCACO As New frm_insertar_FIPRCACO(txtFIPRNUFI.Text, txtFIPRNURE.Text, txtRESODEPA.Text, txtRESOMUNI.Text, txtRESOTIRE.Text, txtRESOCLSE.Text, txtRESOVIGE.Text, txtRESOCODI.Text, stFPCCTIPO, inFPCOUNID, inFPCOCLCO, stFPCOTICO, inFPCOSECU)
                                    frm_insertar_FIPRCACO.ShowDialog()

                                    pro_ReconsultarConstruccion()
                                    pro_ReconsultarCalificacion()

                                Else
                                    MessageBox.Show("Existe un error con la clasificación del tipo de calificación, favor validar la ficha", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)

                                End If
                            Else
                                tabINSCFICHPRED.SelectTab(TabFIPRCACO)
                            End If

                        End If

                    End If

                Next

            End If

            If boMEJORA = False Then

                'Verifica si existen registros de construcción e inscribe
                Dim objdatos As New cla_FIPRLIND
                Dim tbl As New DataTable

                tbl = objdatos.fun_Consultar_FIPRLIND_X_FICHA_PREDIAL(vp_FichaPredial)

                If tbl.Rows.Count = 0 Then
                    If MessageBox.Show("Desea ingresar los linderos", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        tabINSCFICHPRED.SelectTab(tabFIPRLIND)
                        cmdAGREGAR_FIPRLIND.PerformClick()
                    Else
                        tabINSCFICHPRED.SelectTab(TabFIPRCACO)
                    End If
                End If

            ElseIf boMEJORA = True Then

                'Verifica si existen registros de propietario e inscribe
                Dim objdatos As New cla_FIPRCART
                Dim tbl As New DataTable

                tbl = objdatos.fun_Consultar_FIPRCART_X_FICHA_PREDIAL(vp_FichaPredial)

                If tbl.Rows.Count = 0 Then
                    If MessageBox.Show("¿ Desea ingresar la cartografia ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        tabINSCFICHPRED.SelectTab(tabFIPRCART)
                        cmdAGREGAR_FIPRCART.PerformClick()
                    Else
                        tabINSCFICHPRED.SelectTab(tabFIPRLIND)
                    End If
                End If

            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdMODIFICAR_FIPRCACO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_FIPRCACO.Click
        Try
            ' consulta el tipo de calificacion de construccion
            Dim objdatos15 As New cla_TIPOCONS
            Dim tbl15 As New DataTable

            tbl15 = objdatos15.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(Trim(txtRESODEPA.Text), Trim(txtRESOMUNI.Text), Trim(txtFPCOCLCO.Text), Trim(txtRESOCLSE.Text), Trim(txtFPCOTICO.Text))

            If tbl15.Rows.Count > 0 Then

                Dim stFPCCTIPO As String = Trim(tbl15.Rows(0).Item(4))

                ' ejecuta el constructor de insertar el codigo de calificación
                Dim frm_modificar_FIPRCACO As New frm_modificar_FIPRCACO(txtFIPRNUFI.Text, txtFIPRNURE.Text, txtRESODEPA.Text, txtRESOMUNI.Text, txtRESOTIRE.Text, txtRESOCLSE.Text, txtRESOVIGE.Text, txtRESOCODI.Text, stFPCCTIPO, Trim(txtFPCOUNID.Text), Trim(txtFPCOCLCO.Text), Trim(txtFPCOTICO.Text), Trim(lblFPCOSECU.Text))
                frm_modificar_FIPRCACO.ShowDialog()

                pro_ReconsultarConstruccion()
                pro_ReconsultarCalificacion()

            Else
                MessageBox.Show("Existe un error con la clasificación del tipo de calificación, favor validar la ficha", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdELIMINAR_FIPRCACO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_FIPRCACO.Click
        Try
            Dim Codigo As String = Trim(txtFPCCCODI.Text)

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim objdatos As New cla_FIPRCACO

                If objdatos.fun_Eliminar_FIPRCACO(Val(lblFPCCIDRE.Text)) = True Then

                    '=============================================
                    '*** ACTUALIZA EL REGISTRO EN CONSTRUCCIÓN ***
                    '=============================================

                    ' suma puntos de calificacion de consrtucción
                    pro_SumaPuntosDeCalificacionDeConstruccion()

                    ' buscar cadena de conexion
                    Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                    Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                    ' crear conexión
                    oAdapter = New SqlDataAdapter
                    oConexion = New SqlConnection(stCadenaConexion)

                    ' abre la conexion
                    oConexion.Open()

                    ' parametros de la consulta
                    Dim ParametrosConsulta As String = ""

                    ' variables
                    Dim stFPCCNUFI As String = vp_FichaPredial
                    Dim stFPCCUNID As String = Trim(txtFPCOUNID.Text)
                    Dim stFPCCPUNT As String = Trim(lblFPCCTOTA.Text)

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta += "update FIPRCONS "
                    ParametrosConsulta += "set FPCOPUNT = '" & stFPCCPUNT & "' "
                    ParametrosConsulta += "where FPCONUFI = '" & stFPCCNUFI & "' and "
                    ParametrosConsulta += "FPCOUNID = '" & stFPCCUNID & "' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oReader = oEjecutar.ExecuteReader

                    ' cierra la conexion
                    oConexion.Close()
                    oReader = Nothing

                    pro_ReconsultarConstruccion()

                    pro_LimpiarCamposCalificacion()
                    pro_ReconsultarCalificacion()

                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdCONSULTAR_FIPRCACO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_FIPRCACO.Click
        Try
            Me.cmdCONSULTAR_FICHPRED.PerformClick()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdRECONSULTAR_FIPRCACO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_FIPRCACO.Click
        Try
            pro_ReconsultarCalificacion()
            pro_ListaDeValoresCalificacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

#End Region

#Region "MENU LINDERO"

    Private Sub cmdAGREGAR_FIPRLIND_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_FIPRLIND.Click
        Try
            Dim frm_insertar_FIPRLIND As New frm_insertar_FIPRLIND(txtFIPRNUFI.Text, txtFIPRNURE.Text, txtRESODEPA.Text, txtRESOMUNI.Text, txtRESOTIRE.Text, txtRESOCLSE.Text, txtRESOVIGE.Text, txtRESOCODI.Text)
            frm_insertar_FIPRLIND.ShowDialog()

            pro_ReconsultarLinderos()

            'Verifica si existen registros de propietario e inscribe
            Dim objdatos As New cla_FIPRCART
            Dim tbl As New DataTable

            tbl = objdatos.fun_Consultar_FIPRCART_X_FICHA_PREDIAL(vp_FichaPredial)

            If tbl.Rows.Count = 0 Then
                If MessageBox.Show("Desea ingresar la cartografia", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    tabINSCFICHPRED.SelectTab(tabFIPRCART)
                    cmdAGREGAR_FIPRCART.PerformClick()
                Else
                    tabINSCFICHPRED.SelectTab(TabFICHPRED)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdMODIFICAR_FIPRLIND_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_FIPRLIND.Click
        Try
            Dim frm_modificar_FIPRLIND As New frm_modificar_FIPRLIND(Val(lblFPLIIDRE.Text), _
                                                                     txtFIPRNUFI.Text, _
                                                                     txtFIPRNURE.Text, _
                                                                     txtRESODEPA.Text, _
                                                                     txtRESOMUNI.Text, _
                                                                     txtRESOTIRE.Text, _
                                                                     txtRESOCLSE.Text, _
                                                                     txtRESOVIGE.Text, _
                                                                     txtRESOCODI.Text)

            frm_modificar_FIPRLIND.ShowDialog()

            pro_ReconsultarLinderos()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_FIPRLIND_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_FIPRLIND.Click
        Try
            Dim Codigo As String = txtFPLICOLI.Text

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim objdatos As New cla_FIPRLIND

                If objdatos.fun_Eliminar_FIPRLIND(Val(lblFPLIIDRE.Text)) = True Then
                    pro_LimpiarCamposLinderos()
                    pro_ReconsultarLinderos()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdCONSULTAR_FIPRLIND_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_FIPRLIND.Click
        Me.cmdCONSULTAR_FICHPRED.PerformClick()
    End Sub
    Private Sub cmdRECONSULTAR_FIPRLIND_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_FIPRLIND.Click
        pro_ReconsultarLinderos()
    End Sub

#End Region

#Region "MENU CARTOGRAFIA"

    Private Sub cmdAGREGAR_FIPRCART_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_FIPRCART.Click
        Try
            Dim frm_insertar_FIPRCART As New frm_insertar_FIPRCART(txtFIPRNUFI.Text, txtFIPRNURE.Text, txtRESODEPA.Text, txtRESOMUNI.Text, txtRESOTIRE.Text, txtRESOCLSE.Text, txtRESOVIGE.Text, txtRESOCODI.Text)
            frm_insertar_FIPRCART.ShowDialog()

            pro_ReconsultarCartografia()

            ''Verifica los registros para avanzar en las pestañas
            'Dim objdatos As New cla_FICHPRED

            'If MessageBox.Show("Desea ingresar una ficha predial nueva", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            '    tabINSCFICHPRED.SelectTab(TabFICHPRED)
            '    cmdAGREGAR_FICHPRED.PerformClick()
            'Else
            '    tabINSCFICHPRED.SelectTab(tabFIPRCART)
            'End If

            tabINSCFICHPRED.SelectTab(TabFICHPRED)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdMODIFICAR_FIPRCART_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_FIPRCART.Click
        Try
            Dim frm_modificar_FIPRCART As New frm_modificar_FIPRCART(Val(lblFPCAIDRE.Text), txtFIPRNUFI.Text, txtFIPRNURE.Text, txtRESODEPA.Text, txtRESOMUNI.Text, txtRESOTIRE.Text, txtRESOCLSE.Text, txtRESOVIGE.Text, txtRESOCODI.Text)

            frm_modificar_FIPRCART.ShowDialog()

            pro_ReconsultarCartografia()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_FIPRCART_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_FIPRCART.Click
        Try
            Dim Codigo As String = lblFPCASECU.Text

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim objdatos As New cla_FIPRCART

                If objdatos.fun_Eliminar_FIPRCART(Val(lblFPCAIDRE.Text)) = True Then
                    pro_LimpiarCamposCartografia()
                    pro_ReconsultarCartografia()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdCONSULTAR_FIPRCART_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_FIPRCART.Click
        Me.cmdCONSULTAR_FICHPRED.PerformClick()
    End Sub
    Private Sub cmdRECONSULTAR_FIPRCART_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_FIPRCART.Click
        pro_ReconsultarCartografia()
    End Sub

#End Region

#Region "MENU ZONA FISICA"

    Private Sub cmdAGREGAR_FIPRZOFI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_FIPRZOFI.Click
        Try
            Dim frm_insertar_FIPRZOFI As New frm_insertar_FIPRZOFI(txtFIPRNUFI.Text, txtFIPRNURE.Text, txtRESODEPA.Text, txtRESOMUNI.Text, txtRESOTIRE.Text, txtRESOCLSE.Text, txtRESOVIGE.Text, txtRESOCODI.Text)
            frm_insertar_FIPRZOFI.ShowDialog()

            pro_ReconsultarZonaFisica()

            'Verifica si existen registros de propietario e inscribe
            Dim objdatos As New cla_FIPRZOEC
            Dim tbl As New DataTable

            tbl = objdatos.fun_Consultar_FIPRZOEC_X_FICHA_PREDIAL(vp_FichaPredial)

            If tbl.Rows.Count = 0 Then
                If MessageBox.Show("Desea ingresar la zona económica", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    tabINSCFICHPRED.SelectTab(TabFIPRZOEC)
                    cmdAGREGAR_FIPRZOEC.PerformClick()
                Else
                    tabINSCFICHPRED.SelectTab(tabFIPRZOFI)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdMODIFICAR_FIPRZOFI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_FIPRZOFI.Click
        Try
            Dim frm_modificar_FIPRZOFI As New frm_modificar_FIPRZOFI(Val(lblFPZFIDRE.Text), txtFIPRNUFI.Text, txtFIPRNURE.Text, txtRESODEPA.Text, txtRESOMUNI.Text, txtRESOTIRE.Text, txtRESOCLSE.Text, txtRESOVIGE.Text, txtRESOCODI.Text)

            frm_modificar_FIPRZOFI.ShowDialog()

            pro_ReconsultarZonafisica()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_FIPRZOFI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_FIPRZOFI.Click
        Try
            Dim Codigo As String = txtFPZFZOFI.Text

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim objdatos As New cla_FIPRZOFI

                If objdatos.fun_Eliminar_FIPRZOFI(Val(lblFPZFIDRE.Text)) = True Then
                    pro_LimpiarCamposZonaFisica()
                    pro_ReconsultarZonafisica()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdCONSULTAR_FIPRZOFI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_FIPRZOFI.Click
        Me.cmdCONSULTAR_FICHPRED.PerformClick()
    End Sub
    Private Sub cmdRECONSULTAR_FIPRZOFI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_FIPRZOFI.Click
        pro_ReconsultarZonafisica()
    End Sub

#End Region

#Region "MENU ZONA ECONOMICA"

    Private Sub cmdAGREGAR_FIPRZOEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAGREGAR_FIPRZOEC.Click
        Try
            Dim frm_insertar_FIPRZOEC As New frm_insertar_FIPRZOEC(txtFIPRNUFI.Text, txtFIPRNURE.Text, txtRESODEPA.Text, txtRESOMUNI.Text, txtRESOTIRE.Text, txtRESOCLSE.Text, txtRESOVIGE.Text, txtRESOCODI.Text)
            frm_insertar_FIPRZOEC.ShowDialog()

            pro_ReconsultarZonaEconomica()

            tabINSCFICHPRED.SelectTab(TabFIPRZOEC)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdMODIFICAR_FIPRZOEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMODIFICAR_FIPRZOEC.Click
        Try
            Dim frm_modificar_FIPRZOEC As New frm_modificar_FIPRZOEC(Val(lblFPZEIDRE.Text), txtFIPRNUFI.Text, txtFIPRNURE.Text, txtRESODEPA.Text, txtRESOMUNI.Text, txtRESOTIRE.Text, txtRESOCLSE.Text, txtRESOVIGE.Text, txtRESOCODI.Text)

            frm_modificar_FIPRZOEC.ShowDialog()

            pro_ReconsultarZonaEconomica()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdELIMINAR_FIPRZOEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdELIMINAR_FIPRZOEC.Click
        Try
            Dim Codigo As String = txtFPZEZOEC.Text

            If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro código : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                Dim objdatos As New cla_FIPRZOEC

                If objdatos.fun_Eliminar_FIPRZOEC(Val(lblFPZEIDRE.Text)) = True Then
                    pro_LimpiarCamposZonaEconomica()
                    pro_ReconsultarZonaEconomica()
                Else
                    frm_INCO_eliminar_registro_padre_con_relación_de_registros_hijos.ShowDialog()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdCONSULTAR_FIPRZOEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR_FIPRZOEC.Click
        Me.cmdCONSULTAR_FICHPRED.PerformClick()
    End Sub
    Private Sub cmdRECONSULTAR_FIPRZOEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRECONSULTAR_FIPRZOEC.Click
        pro_ReconsultarZonaEconomica()
    End Sub

#End Region

#Region "FORMULARIO FICHA PREDIAL"

    Private Sub frm_FICHPRED_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_inicializarControles()
        pro_AsignarPermisosFichaPredial()
        strBARRESTA.Items(0).Text = "Ficha Predial"

        Me.ToolTip1.SetToolTip(Me.cmdFIPRVALI, "Validar ficha predial")
        Me.ToolTip1.SetToolTip(Me.cmdCONSULTA_PARAMETRIZADA, "Consuta parametrizada")
        Me.ToolTip1.SetToolTip(Me.cmdBORRACALIFICACION, "Elimina toda la calificación")
        Me.ToolTip1.SetToolTip(Me.cmdIMagenPredio, "Imagen del predio")
        Me.ToolTip1.SetToolTip(Me.cmdLiquidaAvaluo, "Liquida avalúo")
        Me.ToolTip1.SetToolTip(Me.cmdLiquidaPredial, "Liquida predial")
        Me.ToolTip1.SetToolTip(Me.cmdFIPROBSE, "Observación")
        Me.ToolTip1.SetToolTip(Me.cmdESTRFIPR, "Estrato")
        Me.ToolTip1.SetToolTip(Me.cmdJuridicaPredio, "Investigación juridica")
        Me.ToolTip1.SetToolTip(Me.cmdREGICONT, "Registro y control")
        Me.ToolTip1.SetToolTip(Me.cmdCAPRFIPR, "Categoria de predio")


        'tabINSCFICHPRED.TabPages(1).Focus()
        'tabINSCFICHPRED.SelectTab(tabFIPRDEEC)
        'tabINSCFICHPRED.TabPages.Remove(0)

    End Sub

    Private Sub BindingNavigator_FICHPRED_1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BindingNavigator_FICHPRED_1.KeyDown

        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F2 Then
            If cmdAGREGAR_FICHPRED.Enabled = True Then
                cmdAGREGAR_FICHPRED.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If cmdMODIFICAR_FICHPRED.Enabled = True Then
                cmdMODIFICAR_FICHPRED.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_FICHPRED_1.Count

                If ContarRegistros = 0 Then
                    mod_MENSAJE.No_Existe_Un_Registro_Seleccionado()
                Else
                    mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
                End If

            End If
        End If

        '===============================================================================================
        '*** ELIMINAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.Delete Then
            If cmdELIMINAR_FICHPRED.Enabled = True Then
                cmdELIMINAR_FICHPRED.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_FICHPRED_1.Count

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
            If cmdCONSULTAR_FICHPRED.Enabled = True Then
                cmdCONSULTAR_FICHPRED.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If cmdCONSULTAR_FICHPRED.Enabled = True Then
                cmdRECONSULTAR_FICHPRED.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If
    End Sub
    Private Sub TabFICHPRED_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabFICHPRED.MouseHover, BindingNavigator_FICHPRED_1.MouseHover, txtFIPRBAAN.MouseHover, txtFIPRBARR.MouseHover, txtFIPRCAPR.MouseHover, txtFIPRCASA.MouseHover, txtFIPRCASU.MouseHover, txtFIPRCLSE.MouseHover, txtFIPRCOAN.MouseHover, txtFIPRCORR.MouseHover, txtFIPRCSAN.MouseHover, txtFIPRDESC.MouseHover, txtFIPRDIRE.MouseHover, txtFIPREDAN.MouseHover, txtFIPRMAAN.MouseHover, txtFIPRMANZ.MouseHover, txtFIPRMOAD.MouseHover, txtFIPRMUAN.MouseHover, txtFIPRMUNI.MouseHover, txtFIPRNUFI.MouseHover, txtFIPRPOLI.MouseHover, txtFIPRPRAN.MouseHover, txtFIPRUPAN.MouseHover, fraFICHPRED.MouseHover, fraOPCIONES.MouseHover, lblDescripcion.MouseHover, lblCodigo.MouseHover, lblMunicipio.MouseHover, lblCorregimiento.MouseHover, lblBarrio.MouseHover, lblManzana.MouseHover, lblPredio.MouseHover, lblEdificio.MouseHover, lblUnidadPredial.MouseHover, lblCedulaActual.MouseHover, lblCedulaAnterior.MouseHover
        Dim seleccion As Integer

        seleccion = tabINSCFICHPRED.SelectedIndex

        Select Case seleccion
            Case 0
                BindingNavigator_FICHPRED_1.Focus()
            Case 1
                BindingNavigator_FIPRDEEC_1.Focus()
            Case 2
            Case 3

        End Select
    End Sub
    Private Sub frm_FICHPRED_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        Dim opacity As Double = Convert.ToDouble(0.5)
        Me.Opacity = opacity
    End Sub
    Private Sub frm_FICHPRED_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim opacity As Double = Convert.ToDouble(100)
        Me.Opacity = opacity
    End Sub
#End Region

#Region "FORMULARIO DESTINO ECONOMICO"

    Private Sub dgvFIPRDEEC_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFIPRDEEC.CellClick
        pro_ListaDeValoresDestinoEconomico()

    End Sub
    Private Sub dgvFIPRDEEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFIPRDEEC.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F2 Then
            If cmdAGREGAR_FIPRDEEC.Enabled = True Then
                cmdAGREGAR_FIPRDEEC.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If cmdMODIFICAR_FIPRDEEC.Enabled = True Then
                cmdMODIFICAR_FIPRDEEC.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_FIPRDEEC_1.Count

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
            If cmdELIMINAR_FIPRDEEC.Enabled = True Then
                cmdELIMINAR_FIPRDEEC.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_FIPRDEEC_1.Count

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
            If cmdCONSULTAR_FIPRDEEC.Enabled = True Then
                cmdCONSULTAR_FIPRDEEC.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If cmdCONSULTAR_FIPRDEEC.Enabled = True Then
                cmdCONSULTAR_FIPRDEEC.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If
    End Sub
    Private Sub dgvFIPRDEEC_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFIPRDEEC.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresDestinoEconomico()
        End If
    End Sub
    Private Sub cmdVALIDAR_FIPRDEEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVALIDAR_FIPRDEEC.Click
        pro_ValidarFichaPredial()
    End Sub

#End Region

#Region "FORMULARIO PROPIETARIO"

    Private Sub dgvFIPRPROP_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFIPRPROP.CellClick
        pro_ListaDeValoresPropietario()
    End Sub
    Private Sub dgvFIPRPROP_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFIPRPROP.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresPropietario()
        End If
    End Sub
    Private Sub dgvFIPRPROP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFIPRPROP.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F2 Then
            If cmdAGREGAR_FIPRPROP.Enabled = True Then
                cmdAGREGAR_FIPRPROP.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If cmdMODIFICAR_FIPRPROP.Enabled = True Then
                cmdMODIFICAR_FIPRPROP.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_FIPRPROP_1.Count

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
            If cmdELIMINAR_FIPRPROP.Enabled = True Then
                cmdELIMINAR_FIPRPROP.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_FIPRPROP_1.Count

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
            If cmdCONSULTAR_FIPRPROP.Enabled = True Then
                cmdCONSULTAR_FIPRPROP.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If cmdCONSULTAR_FIPRPROP.Enabled = True Then
                cmdCONSULTAR_FIPRPROP.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If
    End Sub

    Private Sub txtFIPRMOAD_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMOAD.TextChanged

        If Trim(Me.txtFIPRMOAD.Text) = "3" Then
            Me.lblModoAdquisicionPropietario.Visible = False
            Me.txtFPPRMOAD.Visible = False
            Me.lblFPPRMOAD.Visible = False
        Else
            Me.lblModoAdquisicionPropietario.Visible = True
            Me.txtFPPRMOAD.Visible = True
            Me.lblFPPRMOAD.Visible = True
        End If

    End Sub
    Private Sub cmdVALIDAR_FIPRPROP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVALIDAR_FIPRPROP.Click
        pro_ValidarFichaPredial()
    End Sub

#End Region

#Region "FORMULARIO CONSTRUCCION"

    Private Sub dgvFIPRCONS_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFIPRCONS.CellClick
        pro_ListaDeValoresConstruccion()
        pro_ReconsultarCalificacion()
        pro_ListaDeValoresCalificacionInicial()
    End Sub
    Private Sub dgvFIPRCONS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFIPRCONS.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F2 Then
            If cmdAGREGAR_FIPRCONS.Enabled = True Then
                cmdAGREGAR_FIPRCONS.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If cmdMODIFICAR_FIPRCONS.Enabled = True Then
                cmdMODIFICAR_FIPRCONS.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_FIPRCONS_1.Count

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
            If cmdELIMINAR_FIPRCONS.Enabled = True Then
                cmdELIMINAR_FIPRCONS.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_FIPRCONS_1.Count

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
            If cmdCONSULTAR_FIPRCONS.Enabled = True Then
                cmdCONSULTAR_FIPRCONS.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If cmdCONSULTAR_FIPRCONS.Enabled = True Then
                cmdCONSULTAR_FIPRCONS.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If
    End Sub
    Private Sub dgvFIPRCONS_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFIPRCONS.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresConstruccion()
            pro_ReconsultarCalificacion()
            pro_ListaDeValoresCalificacionInicial()
        End If
    End Sub
    Private Sub cmdVALIDAR_FIPRCONS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVALIDAR_FIPRCONS.Click
        pro_ValidarFichaPredial()
    End Sub

#End Region

#Region "FORMULARIO CALIFICACION"

    Private Sub dgvFIPRCOCA_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFIPRCOCA.CellClick
        pro_ListaDeValoresConstruccion()
        pro_ReconsultarCalificacion()
        pro_ListaDeValoresCalificacion()
    End Sub
    Private Sub dgvFIPRCOCA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFIPRCOCA.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresConstruccion()
            pro_ReconsultarCalificacion()
            pro_ListaDeValoresCalificacion()
        End If
    End Sub

    Private Sub dgvFIPRCACO_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFIPRCACO.CellClick
        pro_ListaDeValoresCalificacion()
    End Sub
    Private Sub dgvFIPRCACO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFIPRCACO.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F2 Then
            If cmdAGREGAR_FIPRCACO.Enabled = True Then
                cmdAGREGAR_FIPRCACO.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If cmdMODIFICAR_FIPRCACO.Enabled = True Then
                cmdMODIFICAR_FIPRCACO.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_FIPRCACO_1.Count

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
            If cmdELIMINAR_FIPRCACO.Enabled = True Then
                cmdELIMINAR_FIPRCACO.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_FIPRCACO_1.Count

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
            If cmdCONSULTAR_FIPRCACO.Enabled = True Then
                cmdCONSULTAR_FIPRCACO.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If cmdCONSULTAR_FIPRCACO.Enabled = True Then
                cmdCONSULTAR_FIPRCACO.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If
    End Sub
    Private Sub dgvFIPRCACO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFIPRCACO.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresCalificacion()
        End If
    End Sub

    Private Sub rbdFPCCRESI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdFPCCRESI.CheckedChanged
        If rbdFPCCRESI.Checked = True Then
            stFPCCTIPO = "R"
        Else
            stFPCCTIPO = ""
        End If
    End Sub
    Private Sub rbdFPCCCOME_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdFPCCCOME.CheckedChanged
        If rbdFPCCCOME.Checked = True Then
            stFPCCTIPO = "C"
        Else
            stFPCCTIPO = ""
        End If
    End Sub
    Private Sub rbdFPCCINDU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdFPCCINDU.CheckedChanged
        If rbdFPCCINDU.Checked = True Then
            stFPCCTIPO = "I"
        Else
            stFPCCTIPO = ""
        End If
    End Sub
    Private Sub rbdFPCCOTRA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdFPCCOTRA.CheckedChanged
        If rbdFPCCOTRA.Checked = True Then
            stFPCCTIPO = "O"
        Else
            stFPCCTIPO = ""
        End If
    End Sub

    Private Sub cmdBORRACALIFICACION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBORRACALIFICACION.Click
        Try
            ' verifica que se utilice una ficha predial
            If Trim(txtFIPRNUFI.Text) = "" Then
                MessageBox.Show("Selecione una ficha predial", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                ' almacena la unidad de construcción
                Dim Codigo As String = Trim(txtFPCOUNID.Text)
                Dim ClaseConstruccion As String = Trim(txtFPCOCLCO.Text)

                ' pregunta si decea eliminarla
                If MessageBox.Show("¿ Desea eliminar el registro seleccionado ? " & Chr(Keys.Enter) & Chr(Keys.Enter) & "Nro unidad : " & Codigo, "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    If BindingSource_FIPRCACO_1.Count = 0 Then
                        MessageBox.Show("No existe código de calificación para la unidad " & Codigo, "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    Else
                        ' eliminar los codigos de calificacion
                        Dim objdatos1 As New cla_FIPRCACO

                        objdatos1.fun_Eliminar_Todos_Los_Registros_FIPRCACO(Trim(txtFIPRNUFI.Text), Trim(txtFPCOUNID.Text))

                        ' suma puntos de calificacion de consrtucción
                        pro_SumaPuntosDeCalificacionDeConstruccion()

                        If ClaseConstruccion <> 2 Then

                            '=============================================
                            '*** ACTUALIZA EL REGISTRO EN CONSTRUCCIÓN ***
                            '=============================================

                            ' buscar cadena de conexion
                            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                            ' crear conexión
                            oAdapter = New SqlDataAdapter
                            oConexion = New SqlConnection(stCadenaConexion)

                            ' abre la conexion
                            oConexion.Open()

                            ' parametros de la consulta
                            Dim ParametrosConsulta As String = ""

                            ' variables
                            Dim stFPCCNUFI As String = vp_FichaPredial
                            Dim stFPCCUNID As String = Trim(txtFPCOUNID.Text)
                            Dim stFPCCPUNT As String = Trim(lblFPCCTOTA.Text)

                            ' Concatena la condicion de la consulta
                            ParametrosConsulta += "update FIPRCONS "
                            ParametrosConsulta += "set FPCOPUNT = '" & stFPCCPUNT & "' "
                            ParametrosConsulta += "where FPCONUFI = '" & stFPCCNUFI & "' and "
                            ParametrosConsulta += "FPCOUNID = '" & stFPCCUNID & "' "

                            ' ejecuta la consulta
                            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                            ' procesa la consulta 
                            oEjecutar.CommandTimeout = 360
                            oEjecutar.CommandType = CommandType.Text
                            oReader = oEjecutar.ExecuteReader

                            ' cierra la conexion
                            oConexion.Close()
                            oReader = Nothing

                        End If

                        pro_ReconsultarConstruccion()

                        pro_LimpiarCamposCalificacion()
                        pro_ReconsultarCalificacion()

                    End If
                Else
                    mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdVALIDAR_FIPRCACO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVALIDAR_FIPRCACO.Click
        pro_ValidarFichaPredial()
    End Sub

#End Region

#Region "FORMULARIO LINDERO"

    Private Sub dgvFIPRLIND_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFIPRLIND.CellClick
        pro_ListaDeValoresLinderos()

    End Sub
    Private Sub dgvFIPRLIND_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFIPRLIND.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F2 Then
            If cmdAGREGAR_FIPRLIND.Enabled = True Then
                cmdAGREGAR_FIPRLIND.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If cmdMODIFICAR_FIPRLIND.Enabled = True Then
                cmdMODIFICAR_FIPRLIND.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_FIPRLIND_1.Count

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
            If cmdELIMINAR_FIPRLIND.Enabled = True Then
                cmdELIMINAR_FIPRLIND.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_FIPRLIND_1.Count

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
            If cmdCONSULTAR_FIPRLIND.Enabled = True Then
                cmdCONSULTAR_FIPRLIND.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If cmdCONSULTAR_FIPRLIND.Enabled = True Then
                cmdCONSULTAR_FIPRLIND.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If
    End Sub
    Private Sub dgvFIPRLIND_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFIPRLIND.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresLinderos()
        End If
    End Sub
    Private Sub cmdVALIDAR_FIPRLIND_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVALIDAR_FIPRLIND.Click
        pro_ValidarFichaPredial()
    End Sub

#End Region

#Region "FORMULARIO CARTOGRAFIA"

    Private Sub dgvFIPRCART_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFIPRCART_1.CellClick, dgvFIPRCART_2.CellClick
        pro_ListaDeValoresCartografia()

    End Sub
    Private Sub dgvFIPRCART_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFIPRCART_1.KeyDown, dgvFIPRCART_2.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F2 Then
            If cmdAGREGAR_FIPRCART.Enabled = True Then
                cmdAGREGAR_FIPRCART.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If cmdMODIFICAR_FIPRCART.Enabled = True Then
                cmdMODIFICAR_FIPRCART.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_FIPRCART_1.Count

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
            If cmdELIMINAR_FIPRCART.Enabled = True Then
                cmdELIMINAR_FIPRCART.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_FIPRCART_1.Count

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
            If cmdCONSULTAR_FIPRCART.Enabled = True Then
                cmdCONSULTAR_FIPRCART.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If cmdCONSULTAR_FIPRCART.Enabled = True Then
                cmdCONSULTAR_FIPRCART.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If
    End Sub
    Private Sub dgvFIPRCART_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFIPRCART_1.KeyUp, dgvFIPRCART_2.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresCartografia()
        End If
    End Sub
    Private Sub cmdVALIDAR_FIPRCART_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVALIDAR_FIPRCART.Click
        pro_ValidarFichaPredial()
    End Sub

#End Region

#Region "FORMULARIO ZONA FISICA"

    Private Sub dgvFIPRZOFI_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFIPRZOFI.CellClick
        pro_ListaDeValoresZonaFisica()

    End Sub
    Private Sub dgvFIPRZOFI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFIPRZOFI.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F2 Then
            If cmdAGREGAR_FIPRZOFI.Enabled = True Then
                cmdAGREGAR_FIPRZOFI.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If cmdMODIFICAR_FIPRZOFI.Enabled = True Then
                cmdMODIFICAR_FIPRZOFI.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_FIPRZOFI_1.Count

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
            If cmdELIMINAR_FIPRZOFI.Enabled = True Then
                cmdELIMINAR_FIPRZOFI.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_FIPRZOFI_1.Count

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
            If cmdCONSULTAR_FIPRZOFI.Enabled = True Then
                cmdCONSULTAR_FIPRZOFI.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If cmdCONSULTAR_FIPRZOFI.Enabled = True Then
                cmdCONSULTAR_FIPRZOFI.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If
    End Sub
    Private Sub dgvFIPRZOFI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFIPRZOFI.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresZonaFisica()
        End If
    End Sub
    Private Sub cmdVALIDAR_FIPRZOFI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVALIDAR_FIPRZOFI.Click
        pro_ValidarFichaPredial()
    End Sub

#End Region

#Region "FORMULARIO ZONA ECONOMICA"

    Private Sub dgvFIPRZOEC_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFIPRZOEC.CellClick
        pro_ListaDeValoresZonaEconomica()

    End Sub
    Private Sub dgvFIPRZOEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFIPRZOEC.KeyDown
        '===============================================================================================
        '*** INSERTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F2 Then
            If cmdAGREGAR_FIPRZOEC.Enabled = True Then
                cmdAGREGAR_FIPRZOEC.PerformClick()
            Else
                mod_MENSAJE.Usuario_No_Tiene_Permiso_Para_Realizar_La_Operacion()
            End If
        End If

        '===============================================================================================
        'MODIFICAR REGISTROS
        '===============================================================================================

        If e.KeyCode = Keys.F3 Then
            If cmdMODIFICAR_FIPRZOEC.Enabled = True Then
                cmdMODIFICAR_FIPRZOEC.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_FIPRZOEC_1.Count

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
            If cmdELIMINAR_FIPRZOEC.Enabled = True Then
                cmdELIMINAR_FIPRZOEC.PerformClick()
            Else
                Dim ContarRegistros As Integer = BindingSource_FIPRZOEC_1.Count

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
            If cmdCONSULTAR_FIPRZOEC.Enabled = True Then
                cmdCONSULTAR_FIPRZOEC.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If

        '===============================================================================================
        '*** RECONSULTAR REGISTROS ***
        '===============================================================================================

        If e.KeyCode = Keys.F8 Then
            If cmdCONSULTAR_FIPRZOEC.Enabled = True Then
                cmdCONSULTAR_FIPRZOEC.PerformClick()
            Else
                mod_MENSAJE.No_Existen_Registros_En_Base_De_Datos()
            End If
        End If
    End Sub
    Private Sub dgvFIPRZOEC_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvFIPRZOEC.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Enter Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Then
            pro_ListaDeValoresZonaEconomica()
        End If
    End Sub
    Private Sub cmdVALIDAR_FIPRZOEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVALIDAR_FIPRZOEC.Click
        pro_ValidarFichaPredial()
    End Sub

#End Region

 

End Class
