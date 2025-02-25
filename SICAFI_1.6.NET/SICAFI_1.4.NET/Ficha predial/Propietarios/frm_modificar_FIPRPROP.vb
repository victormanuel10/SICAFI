Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_modificar_FIPRPROP

    '==============================
    '*** MODIFICAR PROPIETARIOS ***
    '==============================

#Region "CONSTRUCTORES"

    Public Sub New(ByVal inFPPRIDRE As Integer, ByVal inFIPRNUFI As Integer, ByVal inFIPRNURE As Integer, ByVal idRESODEPA As String, ByVal idRESOMUNI As String, ByVal idRESOTIRE As Integer, ByVal idRESOCLSE As Integer, ByVal idRESOVIGE As Integer, ByVal idRESORESO As Integer)

        vl_inFPPRIDRE = inFPPRIDRE
        vp_FichaPredial = inFIPRNUFI
        vl_inFIPRNURE = inFIPRNURE
        vl_stRESODEPA = idRESODEPA
        vl_stRESOMUNI = idRESOMUNI
        vl_inRESOTIRE = idRESOTIRE
        vl_inRESOCLSE = idRESOCLSE
        vl_inRESOVIGE = idRESOVIGE
        vl_inRESORESO = idRESORESO

        InitializeComponent()
        pro_inicializarControles()

    End Sub

#End Region

#Region "VARIABLES"

    '*** VARIABLES QUE RECIBE DEL FORMULARIO DE FICHA PREDIAL ***
    Dim vl_inFIPRNURE As Integer
    Dim vl_stRESODEPA As String
    Dim vl_stRESOMUNI As String
    Dim vl_inRESOTIRE As Integer
    Dim vl_inRESOCLSE As Integer
    Dim vl_inRESOVIGE As Integer
    Dim vl_inRESORESO As Integer
    Dim vl_stFPPRNUDO As String
    Dim vl_inFPPRIDRE As Integer

    Dim vl_boSWVerificaDatoAlGuardar As Boolean = True
    Dim vl_inFPPRMOAD As Integer
    Dim vl_inFIPRMOAD As Integer
    Dim inFIPRCAPR As Integer = 0

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        '=================================
        ' CARGA LOS COMBOBOX CON LOS DATOS 
        '=================================

        fun_Cargar_ComboBox_Con_Todos_Los_Datos_TIPODOCU(cboFPPRTIDO, cboFPPRTIDO.SelectedValue)
        fun_Cargar_ComboBox_Con_Todos_Los_Datos_CALIPROP(cboFPPRCAPR, cboFPPRCAPR.SelectedValue)
        fun_Cargar_ComboBox_Con_Todos_Los_Datos_SEXO(cboFPPRSEXO, cboFPPRSEXO.SelectedValue)
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO(cboFPPRESTA, cboFPPRESTA.SelectedValue)

        '==============================================ç================================
        'ACTIVA LOS COMANDOS DE INGRESO DE LA JURIDICA DE ACUERDO AL MODO DE ADQUISICIÓN 
        '==============================================ç================================

        Dim objdatos222 As New cla_FIPRPROP
        Dim tbl222 As New DataTable

        ' extrae los datos de ficha predial que se guardaran el propietaio
        tbl222 = objdatos222.fun_Buscar_ID_FIPRPROP(vl_inFPPRIDRE)

        vl_inFPPRMOAD = Trim(tbl222.Rows(0).Item("FPPRMOAD"))

        Dim objdatos43 As New cla_FICHPRED
        Dim tbl43 As New DataTable

        tbl43 = objdatos43.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(Val(Trim(tbl222.Rows(0).Item("FPPRNUFI").ToString)))

        vl_inFIPRMOAD = CInt(tbl43.Rows(0).Item("FIPRMOAD").ToString)


        If vl_inFIPRMOAD = 3 Then

            Me.lblAdquisicionDelPredioPropietario.Visible = True
            Me.cboFPPRMOAD.Visible = True
            Me.lblFPPRMOAD.Visible = True

            Dim objdatos22 As New cla_MODOADQU

            Me.cboFPPRMOAD.DataSource = objdatos22.fun_Consultar_MANT_MODOADQU_X_ESTADO
            Me.cboFPPRMOAD.DisplayMember = "MOADCODI"
            Me.cboFPPRMOAD.ValueMember = "MOADCODI"

            Me.cboFPPRMOAD.SelectedValue = Trim(tbl222.Rows(0).Item("FPPRMOAD"))

            Me.lblFPPRMOAD.Text = CStr(fun_Buscar_Lista_Valores_MODOADQU(Me.cboFPPRMOAD.SelectedValue))

        Else
            Me.lblAdquisicionDelPredioPropietario.Visible = False
            Me.cboFPPRMOAD.Visible = False
            Me.lblFPPRMOAD.Visible = False

        End If

        If vl_inFIPRMOAD = 2 Then

            Me.txtFPPRESCR.Enabled = True
            Me.cboFPPRDEPA.Enabled = True
            Me.cboFPPRMUNI.Enabled = True
            Me.cboFPPRNOTA.Enabled = True

            If inFIPRCAPR = 7 Then
                Me.txtFPPRFERE.Enabled = True
                Me.txtFPPRTOMO.Enabled = True
                Me.txtFPPRMAIN.Enabled = True
            Else
                Me.txtFPPRFERE.Enabled = False
                Me.txtFPPRTOMO.Enabled = False
                Me.txtFPPRMAIN.Enabled = False
            End If

            If Trim(tbl222.Rows(0).Item("FPPRDENO")) <> "" Then

                Dim objdatos20 As New cla_DEPARTAMENTO

                cboFPPRDEPA.DataSource = objdatos20.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
                cboFPPRDEPA.DisplayMember = "DEPACODI"
                cboFPPRDEPA.ValueMember = "DEPACODI"

            End If

            If Trim(tbl222.Rows(0).Item("FPPRMUNO")) <> "" Then

                Dim objdatos21 As New cla_MUNICIPIO

                cboFPPRMUNI.DataSource = objdatos21.fun_Consultar_CAMPOS_MANT_MUNICIPIO
                cboFPPRMUNI.DisplayMember = "MUNICODI"
                cboFPPRMUNI.ValueMember = "MUNICODI"

            End If

            If Trim(tbl222.Rows(0).Item("FPPRNOTA")) <> "" Then

                Dim objdatos22 As New cla_NOTARIA

                cboFPPRNOTA.DataSource = objdatos22.fun_Consultar_CAMPOS_MANT_NOTARIA
                cboFPPRNOTA.DisplayMember = "NOTACODI"
                cboFPPRNOTA.ValueMember = "NOTACODI"

            End If


            Me.lblAdquisicionDelPredioPropietario.Visible = False
            Me.cboFPPRMOAD.Visible = False
            Me.lblFPPRMOAD.Visible = False

        ElseIf vl_inFIPRMOAD = 1 Then

            '=====================
            ' CARGA LA DESCRIPCIÓN 
            '=====================

            Dim objdatos20 As New cla_DEPARTAMENTO

            cboFPPRDEPA.DataSource = objdatos20.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
            cboFPPRDEPA.DisplayMember = "DEPACODI"
            cboFPPRDEPA.ValueMember = "DEPACODI"

            Dim objdatos21 As New cla_MUNICIPIO

            cboFPPRMUNI.DataSource = objdatos21.fun_Consultar_CAMPOS_MANT_MUNICIPIO
            cboFPPRMUNI.DisplayMember = "MUNICODI"
            cboFPPRMUNI.ValueMember = "MUNICODI"

            Dim objdatos22 As New cla_NOTARIA

            cboFPPRNOTA.DataSource = objdatos22.fun_Consultar_CAMPOS_MANT_NOTARIA
            cboFPPRNOTA.DisplayMember = "NOTACODI"
            cboFPPRNOTA.ValueMember = "NOTACODI"

            '=================================
            ' ACTIVA LOS CAMPOS DE LA JURIDICA  
            '=================================

            txtFPPRESCR.Enabled = True
            cboFPPRDEPA.Enabled = True
            cboFPPRMUNI.Enabled = True
            cboFPPRNOTA.Enabled = True
            txtFPPRFEES.Enabled = True
            txtFPPRFERE.Enabled = True
            txtFPPRTOMO.Enabled = True
            txtFPPRMAIN.Enabled = True

            Me.lblAdquisicionDelPredioPropietario.Visible = False
            Me.cboFPPRMOAD.Visible = False
            Me.lblFPPRMOAD.Visible = False

        ElseIf vl_inFIPRMOAD = 3 Then

            '=====================
            ' CARGA LA DESCRIPCIÓN 
            '=====================

            If Trim(tbl222.Rows(0).Item("FPPRDENO")) <> "" Then

                Dim objdatos20 As New cla_DEPARTAMENTO

                cboFPPRDEPA.DataSource = objdatos20.fun_Consultar_CAMPOS_MANT_DEPARTAMENTO
                cboFPPRDEPA.DisplayMember = "DEPACODI"
                cboFPPRDEPA.ValueMember = "DEPACODI"

            End If

            If Trim(tbl222.Rows(0).Item("FPPRMUNO")) <> "" Then

                Dim objdatos21 As New cla_MUNICIPIO

                cboFPPRMUNI.DataSource = objdatos21.fun_Consultar_CAMPOS_MANT_MUNICIPIO
                cboFPPRMUNI.DisplayMember = "MUNICODI"
                cboFPPRMUNI.ValueMember = "MUNICODI"

            End If

            If Trim(tbl222.Rows(0).Item("FPPRNOTA")) <> "" Then

                Dim objdatos22 As New cla_NOTARIA

                cboFPPRNOTA.DataSource = objdatos22.fun_Consultar_CAMPOS_MANT_NOTARIA
                cboFPPRNOTA.DisplayMember = "NOTACODI"
                cboFPPRNOTA.ValueMember = "NOTACODI"

            End If

            '=================================
            ' ACTIVA LOS CAMPOS DE LA JURIDICA  
            '=================================

            txtFPPRESCR.Enabled = True
            cboFPPRDEPA.Enabled = True
            cboFPPRMUNI.Enabled = True
            cboFPPRNOTA.Enabled = True
            txtFPPRFEES.Enabled = True
            txtFPPRFERE.Enabled = True
            txtFPPRTOMO.Enabled = True
            txtFPPRMAIN.Enabled = True

            Me.lblAdquisicionDelPredioPropietario.Visible = True
            Me.cboFPPRMOAD.Visible = True
            Me.lblFPPRMOAD.Visible = True

        End If

        '==================================
        ' LLENA LOS CAMPOS DE ACUERDO AL ID
        '==================================

        Dim objdatos As New cla_FIPRPROP
        Dim tbl As New DataTable

        tbl = objdatos.fun_Buscar_ID_FIPRPROP(vl_inFPPRIDRE)

        'lblFPPRIDRE.Text = Trim(tbl.Rows(0).Item(0))
        'txtFPPRNUFI.Text = Trim(tbl.Rows(0).Item(1))
        cboFPPRCAPR.SelectedValue = tbl.Rows(0).Item(2)
        cboFPPRSEXO.SelectedValue = tbl.Rows(0).Item(3)
        cboFPPRTIDO.SelectedValue = tbl.Rows(0).Item(4)
        txtFPPRNUDO.Text = Trim(tbl.Rows(0).Item(5))
        txtFPPRPRAP.Text = Trim(tbl.Rows(0).Item(6))
        txtFPPRSEAP.Text = Trim(tbl.Rows(0).Item(7))
        txtFPPRNOMB.Text = Trim(tbl.Rows(0).Item(8))
        txtFPPRDERE.Text = Trim(tbl.Rows(0).Item(9))
        txtFPPRSICO.Text = Trim(tbl.Rows(0).Item(10))
        txtFPPRESCR.Text = Trim(tbl.Rows(0).Item(11))

        ' Carga los datos notariales
        If vl_inFPPRMOAD = 2 And cboFPPRDEPA.Text <> "" Then
            cboFPPRDEPA.Text = tbl.Rows(0).Item(12)
        End If

        If vl_inFPPRMOAD = 2 And cboFPPRMUNI.Text <> "" Then
            cboFPPRMUNI.Text = tbl.Rows(0).Item(13)
        End If

        If vl_inFPPRMOAD = 2 And cboFPPRNOTA.Text <> "" Then
            cboFPPRNOTA.Text = tbl.Rows(0).Item(14)
        End If

        If vl_inFPPRMOAD = 1 Or vl_inFPPRMOAD = 3 Then
            cboFPPRDEPA.Text = tbl.Rows(0).Item(12)
            cboFPPRMUNI.Text = tbl.Rows(0).Item(13)
            cboFPPRNOTA.Text = tbl.Rows(0).Item(14)
        End If

        txtFPPRFEES.Text = Trim(tbl.Rows(0).Item(15))
        txtFPPRFERE.Text = Trim(tbl.Rows(0).Item(16))
        txtFPPRTOMO.Text = Trim(tbl.Rows(0).Item(17))
        txtFPPRMAIN.Text = Trim(tbl.Rows(0).Item(18))
        chkFPPRGRAV.Checked = tbl.Rows(0).Item(19)
        'txtFPPRMOAD.Text = Trim(tbl.Rows(0).Item(20))
        'chkFPPRLITI.Checked = tbl.Rows(0).Item(21)
        'txtFPPRPOLI.Text = Trim(tbl.Rows(0).Item(22))
        'txtFPPRDEPA.Text = Trim(tbl.Rows(0).Item(23))
        'txtFPPRMUNI.Text = Trim(tbl.Rows(0).Item(24))
        'txtFPPRTIRE.Text = Trim(tbl.Rows(0).Item(25))
        'txtFPPRCLSE.Text = Trim(tbl.Rows(0).Item(26))
        'txtFPPRVIGE.Text = Trim(tbl.Rows(0).Item(27))
        'txtFPPRRESO.Text = Trim(tbl.Rows(0).Item(28))
        'lblFPPRSECU.Text = Trim(tbl.Rows(0).Item(29))
        'txtFPPRNURE.Text = Trim(tbl.Rows(0).Item(30))
        cboFPPRESTA.SelectedValue = Trim(tbl.Rows(0).Item(31))
        'txtFPPRUSIN.Text = Trim(tbl.Rows(0).Item(32))
        'txtFPPRUSMO.Text = Trim(tbl.Rows(0).Item(33))
        'txtFPPRFEIN.Text = Trim(tbl.Rows(0).Item(34))
        'txtFPPRFEMO.Text = Trim(tbl.Rows(0).Item(35))
        'txtFPPRMAQU.Text = Trim(tbl.Rows(0).Item(36))

        ' Almacena el numero de documento para verificar si existe al momento de guardar
        vl_stFPPRNUDO = Trim(tbl.Rows(0).Item(5))

        '==========================================================
        ' CARGA LA DESCRIPCIÓN (Los reg. activos ya estan cargados)
        '==========================================================
        Try
            Dim boFPPRCAPR As Boolean = fun_Buscar_Dato_CALIPROP(cboFPPRCAPR.Text)
            Dim boFPPRSEXO As Boolean = fun_Buscar_Dato_SEXO(cboFPPRSEXO.Text)
            Dim boFPPRTIDO As Boolean = fun_Buscar_Dato_TIPODOCU(cboFPPRTIDO.Text)

            If boFPPRCAPR = True AndAlso boFPPRSEXO = True AndAlso boFPPRTIDO = True Then
                lblFPPRCAPR.Text = CType(fun_Buscar_Lista_Valores_CALIPROP(cboFPPRCAPR.Text), String)
                lblFPPRSEXO.Text = CType(fun_Buscar_Lista_Valores_SEXO(cboFPPRSEXO.Text), String)
                lblFPPRTIDO.Text = CType(fun_Buscar_Lista_Valores_TIPODOCU(cboFPPRTIDO.Text), String)

                If vl_inFPPRMOAD <> 2 Then
                    lblFPPRNOTA.Text = CType(fun_Buscar_Lista_Valores_NOTARIA(Trim(cboFPPRDEPA.Text), Trim(cboFPPRMUNI.Text), Trim(cboFPPRNOTA.Text)), String)
                End If
            Else
                frm_INCO_insertar_registro_sin_listas_de_valores.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

        cboFPPRCAPR.Focus()
    End Sub
    Private Sub pro_Guardar()

        Try
            ' verifica que los datos esten correctos numericos o decimales
            If vl_boSWVerificaDatoAlGuardar = False Then
                mod_MENSAJE.Inco_Valo_Nume()
            Else
                '=====================================================================
                ' ESTRAE LA INFORMACIÓN DEL REGISTRO A MODIFICAR O ELIMINAR ANTES DE..
                '=====================================================================

                Dim objdatos As New cla_FIPRPROP
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_FIPRPROP(vl_inFPPRIDRE)

                Dim inFPDESECU As Integer = Val(Trim(tbl.Rows(0).Item(29)))
                Dim inFPDENURE As Integer = Val(Trim(tbl.Rows(0).Item(30)))

                Dim objdatos43 As New cla_FICHPRED
                Dim tbl43 As New DataTable

                tbl43 = objdatos43.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(Val(Trim(tbl.Rows(0).Item("FPPRNUFI").ToString)))

                vl_inFIPRMOAD = CInt(tbl43.Rows(0).Item("FIPRMOAD").ToString)

                Dim inFPPRMOAD As Integer = 0

                If vl_inFIPRMOAD = 3 Then
                    inFPPRMOAD = Me.cboFPPRMOAD.SelectedValue
                Else
                    inFPPRMOAD = Val(Trim(tbl.Rows(0).Item(20)))
                End If

                Dim stFPPRUSIN As String = Trim(tbl.Rows(0).Item(32))
                Dim daFPPRFEIN As Date = tbl.Rows(0).Item(34)
                Dim boFPPRLITI As Boolean = tbl.Rows(0).Item(21)
                Dim stFPPRPOLI As String = Trim(tbl.Rows(0).Item(22))

                Dim stFPPRFEES As String = Trim(txtFPPRFEES.Text)
                Dim stFPPRFERE As String = Trim(txtFPPRFERE.Text)
                Dim stFPPRMAIN As String = Trim(txtFPPRMAIN.Text)
                Dim stFPPRTOMO As String = Trim(txtFPPRTOMO.Text)

                If Not IsDate(Trim(txtFPPRFERE.Text)) Then
                    txtFPPRFERE.Mask = ("")
                    stFPPRFERE = txtFPPRFERE.Text
                Else
                    stFPPRFERE = txtFPPRFERE.Text
                End If

                Dim stMATRICULA As String

                stMATRICULA = txtFPPRMAIN.Text.ToString
                stMATRICULA = stMATRICULA.Substring(0, 1)

                If Not IsNumeric(stMATRICULA) Then
                    txtFPPRMAIN.Mask = ("")
                    stFPPRMAIN = txtFPPRMAIN.Text
                Else
                    stFPPRMAIN = txtFPPRMAIN.Text
                End If


                If inFPPRMOAD = 2 And vl_inFIPRMOAD <> 3 Then

                    ' verifica las fechas y matricula para guardar sin separador
                    If Not IsDate(Trim(txtFPPRFEES.Text)) Then
                        txtFPPRFEES.Mask = ("")
                        stFPPRFEES = txtFPPRFEES.Text
                    Else
                        stFPPRFEES = txtFPPRFEES.Text
                    End If

                    'stFPPRFEES = ""
                    stFPPRFERE = ""
                    stFPPRMAIN = ""
                    stFPPRTOMO = "0"
                End If

                ' verifica si existe el documento en la tabla de tercero
                Dim objdatos111 As New cla_TERCERO
                Dim tbl111 As New DataTable

                tbl111 = objdatos111.fun_Buscar_CODIGO_TERCERO(Trim(txtFPPRNUDO.Text))

                If tbl111.Rows.Count = 0 Then
                    objdatos111.fun_Insertar_TERCERO(txtFPPRNUDO.Text, _
                                                     cboFPPRTIDO.SelectedValue, _
                                                     cboFPPRCAPR.SelectedValue, _
                                                     cboFPPRSEXO.SelectedValue, _
                                                     Trim(Me.txtFPPRNOMB.Text), _
                                                     Trim(Me.txtFPPRPRAP.Text), _
                                                     Trim(Me.txtFPPRSEAP.Text), _
                                                     txtFPPRSICO.Text, _
                                                     "", "", "", "", "ac", "Propietario desde ficha predial")
                End If

                ' verifica si modifica el mismo propietario elegido
                If vl_stFPPRNUDO = Trim(txtFPPRNUDO.Text) Then

                    If objdatos.fun_Actualizar_FIPRPROP(vl_inFPPRIDRE, _
                                                          vp_FichaPredial, _
                                                          cboFPPRCAPR.SelectedValue, _
                                                          cboFPPRSEXO.SelectedValue, _
                                                          cboFPPRTIDO.SelectedValue, _
                                                          txtFPPRNUDO.Text, _
                                                          Trim(Me.txtFPPRPRAP.Text), _
                                                          Trim(Me.txtFPPRSEAP.Text), _
                                                          Trim(Me.txtFPPRNOMB.Text), _
                                                          txtFPPRDERE.Text, _
                                                          txtFPPRSICO.Text, _
                                                          txtFPPRESCR.Text, _
                                                          cboFPPRDEPA.Text, _
                                                          cboFPPRMUNI.Text, _
                                                          cboFPPRNOTA.Text, _
                                                          stFPPRFEES, _
                                                          stFPPRFERE, _
                                                          txtFPPRTOMO.Text, _
                                                          stFPPRMAIN, _
                                                          chkFPPRGRAV.Checked, _
                                                          inFPPRMOAD, _
                                                          boFPPRLITI, _
                                                          stFPPRPOLI, _
                                                          vl_stRESODEPA, _
                                                          vl_stRESOMUNI, _
                                                          vl_inRESOTIRE, _
                                                          vl_inRESOCLSE, _
                                                          vl_inRESOVIGE, _
                                                          vl_inRESORESO, _
                                                          inFPDESECU, _
                                                          inFPDENURE, _
                                                          cboFPPRESTA.SelectedValue, _
                                                          stFPPRUSIN, _
                                                          daFPPRFEIN) = True Then


                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        cboFPPRCAPR.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                        cboFPPRCAPR.Focus()
                    End If

                Else
                    '===========================================
                    ' BUSCA EL PROPIETARIO EN LA BD SI YA EXISTE
                    '===========================================

                    Dim objdatos12 As New cla_FIPRPROP
                    Dim tbl12 As New DataTable

                    tbl12 = objdatos12.fun_Buscar_CODIGO_FIPRPROP(vp_FichaPredial, Trim(txtFPPRNUDO.Text))

                    If tbl12.Rows.Count > 0 Then
                        mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                        txtFPPRNUDO.Focus()
                    Else
                        If objdatos.fun_Actualizar_FIPRPROP(vl_inFPPRIDRE, _
                                                              vp_FichaPredial, _
                                                              cboFPPRCAPR.SelectedValue, _
                                                              cboFPPRSEXO.SelectedValue, _
                                                              cboFPPRTIDO.SelectedValue, _
                                                              txtFPPRNUDO.Text, _
                                                              txtFPPRPRAP.Text, _
                                                              txtFPPRSEAP.Text, _
                                                              txtFPPRNOMB.Text, _
                                                              txtFPPRDERE.Text, _
                                                              txtFPPRSICO.Text, _
                                                              txtFPPRESCR.Text, _
                                                              cboFPPRDEPA.Text, _
                                                              cboFPPRMUNI.Text, _
                                                              cboFPPRNOTA.Text, _
                                                              stFPPRFEES, _
                                                              stFPPRFERE, _
                                                              txtFPPRTOMO.Text, _
                                                              stFPPRMAIN, _
                                                              chkFPPRGRAV.Checked, _
                                                              inFPPRMOAD, _
                                                              boFPPRLITI, _
                                                              stFPPRPOLI, _
                                                              vl_stRESODEPA, _
                                                              vl_stRESOMUNI, _
                                                              vl_inRESOTIRE, _
                                                              vl_inRESOCLSE, _
                                                              vl_inRESOVIGE, _
                                                              vl_inRESORESO, _
                                                              inFPDESECU, _
                                                              inFPDENURE, _
                                                              cboFPPRESTA.SelectedValue, _
                                                              stFPPRUSIN, _
                                                              daFPPRFEIN) = True Then

                            ' actualiza el propietario anterior
                            Dim objdatos55 As New cla_PROPANTE
                            Dim tbl55 As New DataTable

                            tbl55 = objdatos55.fun_Buscar_PROPIETARIOS_X_NRO_DE_FICHA_Y_NRO_DE_DOCUMENTO(vp_FichaPredial, Trim(vl_stFPPRNUDO))

                            If tbl55.Rows.Count > 0 Then

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

                                ' Concatena la condicion de la consulta
                                ParametrosConsulta += "update PROPANTE "
                                ParametrosConsulta += "set PRANNUDO = '" & Trim(Me.txtFPPRNUDO.Text) & "' "
                                ParametrosConsulta += "where PRANNUDO = '" & Trim(vl_stFPPRNUDO) & "' and "
                                ParametrosConsulta += "PRANNUFI = '" & Trim(vp_FichaPredial) & "' "

                                ' ejecuta la consulta
                                oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                                ' procesa la consulta 
                                oEjecutar.CommandTimeout = 360
                                oEjecutar.CommandType = CommandType.Text

                                oReader = oEjecutar.ExecuteReader

                                Dim i As Integer = oReader.RecordsAffected

                                ' cierra la conexion
                                oConexion.Close()
                                oReader = Nothing

                            End If

                            mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                            cboFPPRCAPR.Focus()
                            Me.Close()
                        Else
                            mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                            cboFPPRCAPR.Focus()
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtFPPRNUDO.Text = ""
        Me.txtFPPRPRAP.Text = ""
        Me.txtFPPRSEAP.Text = ""
        Me.txtFPPRNOMB.Text = ""
        Me.txtFPPRDERE.Text = ""
        Me.txtFPPRSICO.Text = ""
        Me.txtFPPRESCR.Text = ""
        Me.lblFPPRNOTA.Text = ""
        Me.txtFPPRFEES.Text = ""
        Me.txtFPPRFERE.Text = ""
        Me.txtFPPRTOMO.Text = ""
        Me.txtFPPRMAIN.Text = ""
        Me.lblFPPRCAPR.Text = ""
        Me.lblFPPRSEXO.Text = ""
        Me.lblFPPRTIDO.Text = ""
        Me.lblFPPRMOAD.Text = ""

        Me.cboFPPRMOAD.DataSource = New DataTable

        strBARRESTA.Items(1).Text = ""

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            ' Verifica los campos si el predio es posesion
            If vl_inFPPRMOAD = 2 Then
                If fun_Verificar_Campos_Llenos_8_DATOS(cboFPPRCAPR.Text, _
                                                       cboFPPRSEXO.Text, _
                                                       cboFPPRTIDO.Text, _
                                                       txtFPPRNUDO.Text, _
                                                       txtFPPRPRAP.Text, _
                                                       txtFPPRNOMB.Text, _
                                                       txtFPPRDERE.Text, _
                                                       cboFPPRESTA.Text) = False Then
                    mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                    cboFPPRCAPR.Focus()
                Else
                    pro_Guardar()
                End If
            ElseIf vl_inFPPRMOAD = 1 Then
                ' Verifica los campos si el predio es derecho real o sucesion
                If fun_Verificar_Campos_Llenos_16_DATOS(cboFPPRCAPR.Text, _
                                                       cboFPPRSEXO.Text, _
                                                       cboFPPRTIDO.Text, _
                                                       txtFPPRNUDO.Text, _
                                                       txtFPPRPRAP.Text, _
                                                       txtFPPRNOMB.Text, _
                                                       txtFPPRDERE.Text, _
                                                       txtFPPRESCR.Text, _
                                                       cboFPPRDEPA.Text, _
                                                       cboFPPRMUNI.Text, _
                                                       cboFPPRNOTA.Text, _
                                                       txtFPPRFEES.Text, _
                                                       txtFPPRFERE.Text, _
                                                       txtFPPRTOMO.Text, _
                                                       txtFPPRMAIN.Text, _
                                                       cboFPPRESTA.Text) = False Then

                    mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                    cboFPPRCAPR.Focus()
                Else
                    pro_Guardar()
                End If

            ElseIf vl_inFPPRMOAD = 3 Then

                If fun_Verificar_Campos_Llenos_8_DATOS(Me.cboFPPRCAPR.Text, _
                                                                     Me.cboFPPRSEXO.Text, _
                                                                     Me.cboFPPRTIDO.Text, _
                                                                     Me.txtFPPRNUDO.Text, _
                                                                     Me.txtFPPRPRAP.Text, _
                                                                     Me.txtFPPRNOMB.Text, _
                                                                     Me.txtFPPRDERE.Text, _
                                                                     Me.cboFPPRESTA.Text) = False Then
                    mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                    cboFPPRCAPR.Focus()
                Else
                    pro_Guardar()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        cboFPPRCAPR.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub cboFPPRCAPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPPRCAPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFPPRSEXO.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CALIPROP(cboFPPRCAPR, cboFPPRCAPR.SelectedIndex)
        End If
    End Sub
    Private Sub cboFPPRSEXO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPPRSEXO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFPPRTIDO.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_SEXO(cboFPPRSEXO, cboFPPRSEXO.SelectedIndex)
        End If
    End Sub
    Private Sub cboFPPRTIDO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPPRTIDO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPPRNUDO.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPODOCU(cboFPPRTIDO, cboFPPRTIDO.SelectedIndex)
        End If
    End Sub
    Private Sub txtFPPRNUDO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPPRNUDO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPPRPRAP.Focus()
        End If
    End Sub
    Private Sub txtFPPRPRAP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPPRPRAP.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPPRSEAP.Focus()
        End If
    End Sub
    Private Sub txtFPPRSEAP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPPRSEAP.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPPRNOMB.Focus()
        End If
    End Sub
    Private Sub txtFPPRNOMB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPPRNOMB.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPPRDERE.Focus()
        End If
    End Sub
    Private Sub txtFPPRDERE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPPRDERE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPPRSICO.Focus()
        End If
    End Sub
    Private Sub txtFPPRSICO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPPRSICO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            If txtFPPRESCR.Enabled = True Then
                txtFPPRESCR.Focus()
            Else
                cmdGUARDAR.Focus()
            End If
        End If
    End Sub
    Private Sub txtFPPRESCR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPPRESCR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFPPRDEPA.Focus()
        End If
    End Sub
    Private Sub cboFPPRDEPA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPPRDEPA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFPPRMUNI.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO(cboFPPRDEPA, cboFPPRDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboFPPRMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPPRMUNI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFPPRNOTA.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO(cboFPPRMUNI, cboFPPRMUNI.SelectedIndex)
        End If
    End Sub
    Private Sub cboFPPRNOTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPPRNOTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPPRFEES.Focus()
        End If

        If Char.IsNumber(e.KeyChar) Then
            fun_Cargar_ComboBox_Con_Datos_Activos_NOTARIA(cboFPPRNOTA, cboFPPRNOTA.SelectedIndex)
        End If
    End Sub
    Private Sub txtFPPRFEES_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPPRFEES.KeyPress

        If vl_inFPPRMOAD = 1 Or vl_inFPPRMOAD = 3 Then
            If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                Me.txtFPPRFERE.Focus()
            End If
        ElseIf vl_inFPPRMOAD = 2 Then
            If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                Me.cmdGUARDAR.Focus()
            End If
        End If

    End Sub
    Private Sub txtFPPRFERE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPPRFERE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPPRTOMO.Focus()
        End If
    End Sub
    Private Sub txtFPPRTOMO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPPRTOMO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFPPRMAIN.Focus()
        End If
    End Sub
    Private Sub txtFPPRMAIN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFPPRMAIN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cboFPPRESTA.Focus()
        End If
    End Sub
    Private Sub cboFPPRESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboFPPRESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdGUARDAR.Focus()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboFPPRCAPR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFPPRCAPR.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim Insertar_CALIPROP As New frm_insertar_CALIPROP
            Insertar_CALIPROP.Show()
        End If
    End Sub
    Private Sub cboFPPRSEXO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFPPRSEXO.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim Insertar_SEXO As New frm_insertar_SEXO
            Insertar_SEXO.Show()
        End If
    End Sub
    Private Sub cboFPPRTIDO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFPPRTIDO.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim Insertar_TIPODOCU As New frm_insertar_TIPODOCU
            Insertar_TIPODOCU.Show()
        End If
    End Sub
    Private Sub cboFPPRDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFPPRDEPA.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim Insertar_DEPARTAMENTO As New frm_insertar_DEPARTAMENTO
            Insertar_DEPARTAMENTO.Show()
        End If
    End Sub
    Private Sub cboFPPRMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFPPRMUNI.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim Insertar_MUNICIPIO As New frm_insertar_MUNICIPIO
            Insertar_MUNICIPIO.Show()
        End If
    End Sub
    Private Sub cboFPPRNOTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFPPRNOTA.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim Insertar_NOTARIA As New frm_insertar_NOTARIA
            Insertar_NOTARIA.Show()
        End If
    End Sub

#End Region

#Region "Click"

    Private Sub cboFPPRCAPR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRCAPR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CALIPROP(cboFPPRCAPR, cboFPPRCAPR.SelectedIndex)
    End Sub
    Private Sub cboFPPRSEXO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRSEXO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_SEXO(cboFPPRSEXO, cboFPPRSEXO.SelectedIndex)
    End Sub
    Private Sub cboFPPRTIDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRTIDO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPODOCU(cboFPPRTIDO, cboFPPRTIDO.SelectedIndex)
    End Sub
    Private Sub cboFPPRDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO(cboFPPRDEPA, cboFPPRDEPA.SelectedIndex)
    End Sub
    Private Sub cboFPPRMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO(cboFPPRMUNI, cboFPPRMUNI.SelectedIndex)
    End Sub
    Private Sub cboFPPRNOTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRNOTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_NOTARIA(cboFPPRNOTA, cboFPPRNOTA.SelectedIndex)
    End Sub
    Private Sub cboFPPRMOAD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRMOAD.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MODOADQU(cboFPPRMOAD, cboFPPRMOAD.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboFPPRCAPR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFPPRCAPR.SelectedIndexChanged
        lblFPPRCAPR.Text = CType(fun_Buscar_Lista_Valores_CALIPROP(Val(cboFPPRCAPR.Text)), String)
    End Sub
    Private Sub cboFPPRSEXO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFPPRSEXO.SelectedIndexChanged
        lblFPPRSEXO.Text = CType(fun_Buscar_Lista_Valores_SEXO(Val(cboFPPRSEXO.Text)), String)
    End Sub
    Private Sub cboFPPRTIDO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFPPRTIDO.SelectedIndexChanged
        lblFPPRTIDO.Text = CType(fun_Buscar_Lista_Valores_TIPODOCU(Val(cboFPPRTIDO.Text)), String)
    End Sub
    Private Sub cboFPPRDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFPPRDEPA.SelectedIndexChanged
        lblFPPRNOTA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Trim(cboFPPRDEPA.Text)), String)
    End Sub
    Private Sub cboFPPRMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFPPRMUNI.SelectedIndexChanged
        lblFPPRNOTA.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Trim(cboFPPRDEPA.Text), Trim(cboFPPRMUNI.Text)), String)
    End Sub
    Private Sub cboFPPRNOTA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFPPRNOTA.SelectedIndexChanged
        lblFPPRNOTA.Text = CType(fun_Buscar_Lista_Valores_NOTARIA(Trim(cboFPPRDEPA.Text), Trim(cboFPPRMUNI.Text), Trim(cboFPPRNOTA.Text)), String)
    End Sub
    Private Sub cboFPPRMOAD_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFPPRMOAD.SelectedIndexChanged
        lblFPPRMOAD.Text = CType(fun_Buscar_Lista_Valores_MODOADQU(Trim(cboFPPRMOAD.Text)), String)
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cboFPPRCAPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRCAPR.GotFocus
        strBARRESTA.Items(0).Text = cboFPPRCAPR.AccessibleDescription
    End Sub
    Private Sub cboFPPRSEXO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRSEXO.GotFocus
        strBARRESTA.Items(0).Text = cboFPPRSEXO.AccessibleDescription
    End Sub
    Private Sub cboFPPRTIDO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRTIDO.GotFocus
        strBARRESTA.Items(0).Text = cboFPPRTIDO.AccessibleDescription
    End Sub
    Private Sub txtFPPRNUDO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRNUDO.GotFocus
        txtFPPRNUDO.SelectionStart = 0
        txtFPPRNUDO.SelectionLength = Len(txtFPPRNUDO.Text)
        strBARRESTA.Items(0).Text = txtFPPRNUDO.AccessibleDescription
    End Sub
    Private Sub txtFPPRPRAP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRPRAP.GotFocus
        txtFPPRPRAP.SelectionStart = 0
        txtFPPRPRAP.SelectionLength = Len(txtFPPRPRAP.Text)
        strBARRESTA.Items(0).Text = txtFPPRPRAP.AccessibleDescription
    End Sub
    Private Sub txtFPPRSEAP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRSEAP.GotFocus
        txtFPPRSEAP.SelectionStart = 0
        txtFPPRSEAP.SelectionLength = Len(txtFPPRSEAP.Text)
        strBARRESTA.Items(0).Text = txtFPPRSEAP.AccessibleDescription
    End Sub
    Private Sub txtFPPRNOMB_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRNOMB.GotFocus
        txtFPPRNOMB.SelectionStart = 0
        txtFPPRNOMB.SelectionLength = Len(txtFPPRNOMB.Text)
        strBARRESTA.Items(0).Text = txtFPPRNOMB.AccessibleDescription
    End Sub
    Private Sub txtFPPRDERE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRDERE.GotFocus
        txtFPPRDERE.SelectionStart = 0
        txtFPPRDERE.SelectionLength = Len(txtFPPRDERE.Text)
        strBARRESTA.Items(0).Text = txtFPPRDERE.AccessibleDescription
    End Sub
    Private Sub txtFPPRSICO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRSICO.GotFocus
        txtFPPRSICO.SelectionStart = 0
        txtFPPRSICO.SelectionLength = Len(txtFPPRSICO.Text)
        strBARRESTA.Items(0).Text = txtFPPRSICO.AccessibleDescription
    End Sub
    Private Sub txtFPPRESCR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRESCR.GotFocus
        txtFPPRESCR.SelectionStart = 0
        txtFPPRESCR.SelectionLength = Len(txtFPPRESCR.Text)
        strBARRESTA.Items(0).Text = txtFPPRESCR.AccessibleDescription
    End Sub
    Private Sub cboFPPRDEPA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRDEPA.GotFocus
        strBARRESTA.Items(0).Text = cboFPPRDEPA.AccessibleDescription
    End Sub
    Private Sub cboFPPRMUNI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRMUNI.GotFocus
        strBARRESTA.Items(0).Text = cboFPPRMUNI.AccessibleDescription
    End Sub
    Private Sub cboFPPRNOTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRNOTA.GotFocus
        strBARRESTA.Items(0).Text = cboFPPRNOTA.AccessibleDescription
    End Sub
    Private Sub txtFPPRFEES_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRFEES.GotFocus
        txtFPPRFEES.SelectionStart = 0
        txtFPPRFEES.SelectionLength = Len(txtFPPRFEES.Text)
        strBARRESTA.Items(0).Text = txtFPPRFEES.AccessibleDescription
    End Sub
    Private Sub txtFPPRFERE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRFERE.GotFocus
        txtFPPRFERE.SelectionStart = 0
        txtFPPRFERE.SelectionLength = Len(txtFPPRFERE.Text)
        strBARRESTA.Items(0).Text = txtFPPRFERE.AccessibleDescription
    End Sub
    Private Sub txtFPPRTOMO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRTOMO.GotFocus
        txtFPPRTOMO.SelectionStart = 0
        txtFPPRTOMO.SelectionLength = Len(txtFPPRTOMO.Text)
        strBARRESTA.Items(0).Text = txtFPPRTOMO.AccessibleDescription
    End Sub
    Private Sub txtFPPRMAIN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRMAIN.GotFocus
        txtFPPRMAIN.SelectionStart = 0
        txtFPPRMAIN.SelectionLength = Len(txtFPPRMAIN.Text)
        strBARRESTA.Items(0).Text = txtFPPRMAIN.AccessibleDescription
    End Sub
    Private Sub chkFPPRGRAV_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFPPRGRAV.GotFocus
        strBARRESTA.Items(0).Text = chkFPPRGRAV.AccessibleDescription
    End Sub
    Private Sub cboFPPRESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRESTA.GotFocus
        strBARRESTA.Items(0).Text = cboFPPRESTA.AccessibleDescription
    End Sub
    Private Sub cboFPPRMOAD_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRMOAD.GotFocus
        strBARRESTA.Items(0).Text = cboFPPRMOAD.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub


#End Region

#Region "Validated"

    Private Sub txtFPPRNUDO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRNUDO.Validated

        Try
            If Trim(txtFPPRNUDO.Text) = "" Then
                txtFPPRNUDO.Focus()
                mod_MENSAJE.Inco_Valo_Nulo()
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""

                ' Busca el propietario en la base de datos
                Dim objdatos12 As New cla_FIPRPROP
                Dim tbl12 As New DataTable

                tbl12 = objdatos12.fun_Buscar_CODIGO_FIPRPROP(vp_FichaPredial, Trim(txtFPPRNUDO.Text))

                If tbl12.Rows.Count > 0 And vl_stFPPRNUDO <> Trim(txtFPPRNUDO.Text) Then
                    strBARRESTA.Items(1).Text = "Código existente en la base de datos"
                    txtFPPRNUDO.Focus()
                Else
                    strBARRESTA.Items(0).Text = ""
                    strBARRESTA.Items(1).Text = ""

                    ' extrae el tercero si ya existe en base de datos
                    Dim objdatos1 As New cla_TERCERO
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_CODIGO_TERCERO(Trim(txtFPPRNUDO.Text))

                    If tbl1.Rows.Count > 0 And Trim(Me.cboFPPRTIDO.Text) <> 8 Then
                        cboFPPRTIDO.SelectedValue = Trim(tbl1.Rows(0).Item(2))
                        cboFPPRCAPR.SelectedValue = Trim(tbl1.Rows(0).Item(3))
                        cboFPPRSEXO.SelectedValue = Trim(tbl1.Rows(0).Item(4))
                        txtFPPRNOMB.Text = Trim(tbl1.Rows(0).Item(5))
                        txtFPPRPRAP.Text = Trim(tbl1.Rows(0).Item(6))
                        txtFPPRSEAP.Text = Trim(tbl1.Rows(0).Item(7))
                        txtFPPRSICO.Text = Trim(tbl1.Rows(0).Item(8))
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub
    Private Sub txtFPPRPRAP_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRPRAP.Validated
        If Trim(txtFPPRPRAP.Text) = "" Then
            txtFPPRPRAP.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtFPPRSEAP_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRSEAP.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFPPRNOMB_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRNOMB.Validated
        If Trim(txtFPPRNOMB.Text) = "" Then
            txtFPPRNOMB.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtFPPRDERE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRDERE.Validated

        If Trim(txtFPPRDERE.Text) = "" Then
            txtFPPRDERE.Focus()
            strBARRESTA.Items(1).Text = IncoValoNume
        Else
            If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(txtFPPRDERE.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFPPRDERE.Focus()
                strBARRESTA.Items(1).Text = IncoValoDeci
            Else
                vl_boSWVerificaDatoAlGuardar = True

                If Val(txtFPPRDERE.Text) > 100 Then
                    strBARRESTA.Items(1).Text = "Porcentaje mayor al 100 %"
                    MessageBox.Show("Porcentaje superior al 100 %", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)

                    txtFPPRDERE.Focus()
                Else
                    vl_boSWVerificaDatoAlGuardar = True

                    txtFPPRDERE.Text = fun_Formato_Decimal_6_Decimales(txtFPPRDERE.Text)

                    strBARRESTA.Items(0).Text = ""
                    strBARRESTA.Items(1).Text = ""
                End If
            End If
        End If

    End Sub
    Private Sub txtFPPRSICO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRSICO.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFPPRESCR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRESCR.Validated
        If Trim(txtFPPRESCR.Text) = "" Then
            txtFPPRESCR.Text = "0"
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFPPRESCR.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFPPRESCR.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub cboFPPRDEPA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRDEPA.Validated

        If vl_inFPPRMOAD <> 2 And Trim(cboFPPRDEPA.Text) <> "" Then
            If Trim(cboFPPRDEPA.Text) = "" Then
                cboFPPRDEPA.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If

    End Sub
    Private Sub cboFPPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRMUNI.Validated

        If vl_inFPPRMOAD <> 2 And Trim(cboFPPRMUNI.Text) <> "" Then
            If Trim(cboFPPRMUNI.Text) = "" Then
                cboFPPRMUNI.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If

    End Sub
    Private Sub cboFPPRNOTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRNOTA.Validated

        If vl_inFPPRMOAD <> 2 And Trim(cboFPPRNOTA.Text) <> "" Then
            If Trim(cboFPPRNOTA.Text) = "" Then
                cboFPPRNOTA.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If

    End Sub
    Private Sub txtFPPRFEES_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRFEES.Validated

        If vl_inFPPRMOAD <> 2 Then

            Dim dateNow As DateTime = DateTime.Now
            Dim daFechaPresente As Date = DateTime.Now.ToString

            If Trim(txtFPPRFEES.Text) = "" Then
                txtFPPRFEES.Focus()
                strBARRESTA.Items(1).Text = IncoValoNulo
            ElseIf Not IsDate(txtFPPRFEES.Text) Then
                txtFPPRFEES.Focus()
                strBARRESTA.Items(1).Text = IncoValoFech
            ElseIf CDate(txtFPPRFEES.Text) < CDate("01-01-1778") Then
                txtFPPRFEES.Focus()
                strBARRESTA.Items(1).Text = "Año inferior a 1778"
            ElseIf txtFPPRFEES.Text > daFechaPresente Then
                txtFPPRFEES.Focus()
                strBARRESTA.Items(1).Text = "Año superior a " & daFechaPresente
            Else
                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If

        End If

    End Sub
    Private Sub txtFPPRFERE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRFERE.Validated
        Dim dateNow As DateTime = DateTime.Now
        Dim daFechaPresente As Date = DateTime.Now.ToString

        If Trim(txtFPPRFERE.Text) = "" Then
            txtFPPRFERE.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        ElseIf Not IsDate(txtFPPRFERE.Text) Then
            txtFPPRFERE.Focus()
            strBARRESTA.Items(1).Text = IncoValoFech
        ElseIf CDate(txtFPPRFEES.Text) < CDate("01-01-1778") Then
            txtFPPRFERE.Focus()
            strBARRESTA.Items(1).Text = "Año inferior a 1778"
        ElseIf txtFPPRFEES.Text > daFechaPresente Then
            txtFPPRFERE.Focus()
            strBARRESTA.Items(1).Text = "Año superior a " & daFechaPresente
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtFPPRTOMO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRTOMO.Validated
        If Trim(txtFPPRTOMO.Text) = "" Then
            txtFPPRTOMO.Text = "0"
        Else
            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(txtFPPRTOMO.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                txtFPPRTOMO.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
            Else
                vl_boSWVerificaDatoAlGuardar = True

                strBARRESTA.Items(0).Text = ""
                strBARRESTA.Items(1).Text = ""
            End If
        End If
    End Sub
    Private Sub txtFPPRMAIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRMAIN.Validated
        If Trim(txtFPPRMAIN.Text) = "" Then
            txtFPPRMAIN.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboFPPRESTA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRESTA.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cmdGUARDAR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub cmdCANCELAR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.Validated
        strBARRESTA.Items(0).Text = ""
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "TextChanged"

    Private Sub txtFPPRTOMO_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRTOMO.TextChanged
        If Trim(txtFPPRTOMO.Text) = "0" Then
            txtFPPRMAIN.Mask = ("000-0000000")
        Else
            txtFPPRMAIN.Mask = ("0000000000")
        End If
    End Sub

#End Region

#Region "ResizeBegin"

    Private Sub frm_insertar_FICHPRED_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        Me.Opacity = vp_Opacity
    End Sub

#End Region

#Region "ResizeEnd"

    Private Sub frm_insertar_FICHPRED_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Dim opacity As Double = Convert.ToDouble(100)
        Me.Opacity = opacity
    End Sub

#End Region


#End Region

   
End Class