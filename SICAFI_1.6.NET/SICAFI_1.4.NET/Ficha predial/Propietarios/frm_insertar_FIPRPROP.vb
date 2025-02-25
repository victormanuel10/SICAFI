Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_FIPRPROP

    '============================
    '*** INSERTAR PROPIETARIO ***
    '============================

#Region "CONSTRUCTORES"

    Public Sub New(ByVal inFIPRNUFI As Integer, _
                  ByVal inFIPRNURE As Integer, _
                  ByVal stRESODEPA As String, _
                  ByVal stRESOMUNI As String, _
                  ByVal inRESOTIRE As Integer, _
                  ByVal inRESOCLSE As Integer, _
                  ByVal inRESOVIGE As Integer, _
                  ByVal inRESORESO As Integer)

        vp_FichaPredial = inFIPRNUFI
        vl_inFIPRNURE = inFIPRNURE
        vl_stRESODEPA = stRESODEPA
        vl_stRESOMUNI = stRESOMUNI
        vl_inRESOTIRE = inRESOTIRE
        vl_inRESOCLSE = inRESOCLSE
        vl_inRESOVIGE = inRESOVIGE
        vl_inRESORESO = inRESORESO

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
        pro_NumeroDeSecuenciaDeRegistro()
        pro_ReconsultarPropietario()
        pro_Sumar_Porcentaje()



    End Sub

#End Region
   
#Region "VARIABLES LOCALES"

    '*** VARIABLES QUE RECIBE DEL FORMULARIO DE FICHA PREDIAL ***
    Dim vl_inFIPRNURE As Integer
    Dim vl_stRESODEPA As String
    Dim vl_stRESOMUNI As String
    Dim vl_inRESOTIRE As Integer
    Dim vl_inRESOCLSE As Integer
    Dim vl_inRESOVIGE As Integer
    Dim vl_inRESORESO As Integer
    Dim vl_boSWVerificaDatoAlGuardar As Boolean = True
    Dim stMODOADQU As String
    Dim inFPPRMOAD As Integer
    Dim inFIPRCAPR As Integer = 0

    Private vl_doTotalDerecho As Double = 0.0


#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_inicializarControles()

        Try
            '=========================================
            ' CARGA LOS COMBOBOX CON LOS DATOS ACTIVOS
            '=========================================

            Dim objdatos2 As New cla_ESTADO

            cboFPPRESTA.DataSource = objdatos2.fun_Consultar_ESTADO_X_ESTADO
            cboFPPRESTA.DisplayMember = "ESTADESC"
            cboFPPRESTA.ValueMember = "ESTACODI"

            Dim objdatos222 As New cla_FICHPRED
            Dim tbl222 As New DataTable

            ' extrae los datos de ficha predial que se guardaran el propietaio
            tbl222 = objdatos222.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(vp_FichaPredial)

            inFPPRMOAD = Trim(tbl222.Rows(0).Item(30))

            If inFPPRMOAD = 3 Then

                Me.lblAdquisicionDelPredioPropietario.Visible = True
                Me.cboFPPRMOAD.Visible = True
                Me.lblFPPRMOAD.Visible = True

                Dim objdatos22 As New cla_MODOADQU

                Me.cboFPPRMOAD.DataSource = objdatos22.fun_Consultar_MANT_MODOADQU_X_ESTADO
                Me.cboFPPRMOAD.DisplayMember = "MOADCODI"
                Me.cboFPPRMOAD.ValueMember = "MOADCODI"

                Me.cboFPPRMOAD.SelectedValue = Trim(tbl222.Rows(0).Item(30))

                Me.lblFPPRMOAD.Text = CStr(fun_Buscar_Lista_Valores_MODOADQU(Me.cboFPPRMOAD.SelectedValue))

            Else
                Me.lblAdquisicionDelPredioPropietario.Visible = False
                Me.cboFPPRMOAD.Visible = False
                Me.lblFPPRMOAD.Visible = False

            End If

            '==============================================ç================================
            'ACTIVA LOS COMANDOS DE INGRESO DE LA JURIDICA DE ACUERDO AL MODO DE ADQUISICIÓN 
            '==============================================ç================================

            Dim objdatos10 As New cla_FICHPRED
            Dim tbl10 As New DataTable

            tbl10 = objdatos10.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(vp_FichaPredial)

            stMODOADQU = CStr(Trim(tbl10.Rows(0).Item("FIPRMOAD")))
            inFIPRCAPR = CInt(tbl10.Rows(0).Item("FIPRMOAD"))

            If stMODOADQU = 2 Then

                '==============================
                ' DESACTIVA Y LIMPIA LOS CAMPOS
                '==============================

                Me.cboFPPRDEPA.DataSource = New DataTable
                Me.cboFPPRDEPA.DisplayMember = ""
                Me.cboFPPRDEPA.ValueMember = ""

                Me.cboFPPRMUNI.DataSource = New DataTable
                Me.cboFPPRMUNI.DisplayMember = ""
                Me.cboFPPRMUNI.ValueMember = ""

                Me.cboFPPRNOTA.DataSource = New DataTable
                Me.cboFPPRNOTA.DisplayMember = ""
                Me.cboFPPRNOTA.ValueMember = ""

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

                Me.lblAdquisicionDelPredioPropietario.Visible = False
                Me.cboFPPRMOAD.Visible = False
                Me.lblFPPRMOAD.Visible = False

            ElseIf stMODOADQU = 1 Then
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

            ElseIf stMODOADQU = 3 Then
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

            Me.cboFPPRCAPR.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarPropietario()
        Try
            Dim objdatos As New cla_FIPRPROP

            BindingSource_FIPRPROP_1.DataSource = objdatos.fun_Consultar_FIPRPROP(vp_FichaPredial)
            dgvFIPRPROP.DataSource = BindingSource_FIPRPROP_1.DataSource
            BindingNavigator_FIPRPROP_1.BindingSource = BindingSource_FIPRPROP_1

            dgvFIPRPROP.Columns(0).Visible = False
            dgvFIPRPROP.Columns(1).Visible = False
            dgvFIPRPROP.Columns(2).Visible = False
            dgvFIPRPROP.Columns(3).Visible = False

            strBARRESTA.Items(2).Text = "Registros : " & BindingSource_FIPRPROP_1.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_NumeroDeSecuenciaDeRegistro()
        Dim inFPPRSECU As Integer = 0

        Dim objdatos5 As New cla_FIPRPROP
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRPROP_X_FICHA_PREDIAL(Val(vp_FichaPredial))

        If tbl10.Rows.Count = 0 Then
            inFPPRSECU = 1
        Else
            Dim i As Integer
            Dim NroMayor As Integer
            Dim Posicion As Integer

            Posicion = Val(tbl10.Rows(0).Item(29))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item(29))

                If NroMayor > Posicion Then
                    inFPPRSECU = NroMayor
                    Posicion = NroMayor
                Else
                    inFPPRSECU = Posicion
                End If
            Next

            inFPPRSECU = inFPPRSECU + 1
        End If

        lblFPPRSECU.Text = inFPPRSECU
    End Sub
    Private Sub pro_LimpiarCampos()

        Me.txtFPPRNUDO.Text = ""
        Me.txtFPPRPRAP.Text = ""
        Me.txtFPPRSEAP.Text = ""
        Me.txtFPPRNOMB.Text = ""
        Me.txtFPPRDERE.Text = ""
        Me.txtFPPRSICO.Text = ""
        Me.txtFPPRESCR.Text = "0"
        Me.txtFPPRFEES.Text = ""
        Me.txtFPPRFERE.Text = ""
        Me.txtFPPRTOMO.Text = "0"
        Me.txtFPPRMAIN.Text = ""

        Me.lblFPPRCAPR.Text = ""
        Me.lblFPPRSEXO.Text = ""
        Me.lblFPPRTIDO.Text = ""
        Me.lblFPPRNOTA.Text = ""

        strBARRESTA.Items(1).Text = ""
        ErrorProvider1.SetError(Me.txtFPPRNUDO, "")

        Dim tbl As New DataTable

        Me.cboFPPRCAPR.DataSource = tbl
        Me.cboFPPRSEXO.DataSource = tbl
        Me.cboFPPRTIDO.DataSource = tbl
        Me.cboFPPRDEPA.DataSource = tbl
        Me.cboFPPRMUNI.DataSource = tbl
        Me.cboFPPRNOTA.DataSource = tbl

        Me.cboFPPRMOAD.DataSource = New DataTable
        Me.lblFPPRMOAD.Text = ""

    End Sub
    Private Sub pro_Sumar_Porcentaje()

        Try
            Dim objdatos2 As New cla_FIPRPROP
            Dim tbl1 As New DataTable
            Dim tbl2 As New DataTable

            If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(Me.txtFPPRDERE.Text)) = True Then
                If Trim(Me.txtFPPRDERE.Text) <> "" Then
                    vl_doTotalDerecho = CDbl(Trim(Me.txtFPPRDERE.Text))
                End If
            End If

            tbl2 = objdatos2.fun_Consultar_FIPRPROP(Val(vp_FichaPredial))

            If tbl2.Rows.Count > 0 Then

                tbl1 = objdatos2.fun_Consultar_SUMA_X_FPPRDERE_FIPRPROP(Val(vp_FichaPredial))

                Dim i As Integer
                Dim doTOTAL As Double

                ' ciclo debido que el dato se almacena en un campo string
                For i = 0 To tbl1.Rows.Count - 1
                    doTOTAL += CType(tbl1.Rows(i).Item("FPPRDERE"), Double)
                Next

                Me.lblFPPRTOTA.Text = (doTOTAL + vl_doTotalDerecho)

                vl_doTotalDerecho = (doTOTAL + vl_doTotalDerecho)

            Else
                lblFPPRTOTA.Text = "0"

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub pro_Guardar()

        Try

            ' verifica que los datos esten correctos numericos o decimales
            If vl_boSWVerificaDatoAlGuardar = False Then
                mod_MENSAJE.Inco_Valo_Nume()
            Else
                ' almacena el codigo 
                Dim id As String = Trim(txtFPPRNUDO.Text)

                Dim objdatos1 As New cla_FIPRPROP
                Dim tbl As New DataTable
                tbl = objdatos1.fun_Buscar_CODIGO_FIPRPROP(vp_FichaPredial, id)

                ' verifica si existe el codigo 
                If tbl.Rows.Count > 0 Then
                    mod_MENSAJE.Codigo_Existente_En_Base_De_Datos()
                    cboFPPRCAPR.Focus()
                Else
                    Dim objdatos As New cla_FIPRPROP
                    Dim inSECUENCIA As Integer = 0

                    ' busca el numero de secuencia de la base datos
                    Dim objdatos5 As New cla_FIPRPROP
                    Dim tbl10 As New DataTable

                    tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRPROP_X_FICHA_PREDIAL(Val(vp_FichaPredial))

                    If tbl10.Rows.Count = 0 Then
                        inSECUENCIA = 1
                    Else
                        ' asigna el numero de secuencia
                        Dim i As Integer
                        Dim NroMayor As Integer
                        Dim Posicion As Integer

                        Posicion = Val(tbl10.Rows(0).Item(29))

                        For i = 0 To tbl10.Rows.Count - 1
                            NroMayor = Val(tbl10.Rows(i).Item(29))

                            If NroMayor > Posicion Then
                                inSECUENCIA = NroMayor
                                Posicion = NroMayor
                            Else
                                inSECUENCIA = Posicion
                            End If
                        Next
                        inSECUENCIA = inSECUENCIA + 1
                    End If

                    lblFPPRSECU.Text = inSECUENCIA

                    Dim objdatos22 As New cla_FICHPRED
                    Dim tbl22 As New DataTable

                    Dim boFPPRLITI As Boolean
                    Dim stFPPRPOLI As String

                    ' extrae los datos de ficha predial que se guardaran el propietaio
                    tbl22 = objdatos22.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(vp_FichaPredial)

                    If inFPPRMOAD = 3 Then
                        inFPPRMOAD = Me.cboFPPRMOAD.SelectedValue
                    Else
                        inFPPRMOAD = Trim(tbl22.Rows(0).Item(30))
                    End If


                    boFPPRLITI = tbl22.Rows(0).Item(46)
                    stFPPRPOLI = Trim(tbl22.Rows(0).Item(47))

                    Dim stFPPRFEES As String
                    Dim stFPPRFERE As String
                    Dim stFPPRMAIN As String

                    ' verifica las fechas y matricula para guardar sin separador
                    If Not IsDate(Trim(txtFPPRFEES.Text)) Then
                        txtFPPRFEES.Mask = ("")
                        stFPPRFEES = txtFPPRFEES.Text
                    Else
                        stFPPRFEES = txtFPPRFEES.Text
                    End If

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

                    ' verifica los datos de la notaria 
                    If cboFPPRDEPA.SelectedValue Is Nothing Then
                        cboFPPRDEPA.Text = ""
                    End If

                    If cboFPPRMUNI.SelectedValue Is Nothing Then
                        cboFPPRMUNI.Text = ""
                    End If

                    If cboFPPRNOTA.SelectedValue Is Nothing Then
                        cboFPPRNOTA.Text = ""
                    End If

                    ' guarda el propietario en la tabla se tercero si no existe
                    Dim idNumeroDocumento As String = Trim(txtFPPRNUDO.Text)

                    Dim objdatos111 As New cla_TERCERO
                    Dim tbl111 As New DataTable
                    tbl111 = objdatos111.fun_Buscar_CODIGO_TERCERO(idNumeroDocumento)

                    If tbl111.Rows.Count = 0 Then
                        objdatos111.fun_Insertar_TERCERO(Me.txtFPPRNUDO.Text, _
                                                         Me.cboFPPRTIDO.SelectedValue, _
                                                         Me.cboFPPRCAPR.SelectedValue, _
                                                         Me.cboFPPRSEXO.SelectedValue, _
                                                         Me.txtFPPRNOMB.Text, _
                                                         Me.txtFPPRPRAP.Text, _
                                                         Me.txtFPPRSEAP.Text, _
                                                         Me.txtFPPRSICO.Text, _
                                                         "", "", "", "", "ac", "Propietario desde ficha predial")
                    End If

                    ' inserta los datos 
                    If (objdatos.fun_Insertar_FIPRPROP(vp_FichaPredial, _
                                                       Me.cboFPPRCAPR.SelectedValue, _
                                                       Me.cboFPPRSEXO.SelectedValue, _
                                                       Me.cboFPPRTIDO.SelectedValue, _
                                                       Me.txtFPPRNUDO.Text, _
                                                       Me.txtFPPRPRAP.Text, _
                                                       Me.txtFPPRSEAP.Text, _
                                                       Me.txtFPPRNOMB.Text, _
                                                       Me.txtFPPRDERE.Text, _
                                                       Me.txtFPPRSICO.Text, _
                                                       Me.txtFPPRESCR.Text, _
                                                       Me.cboFPPRDEPA.Text, _
                                                       Me.cboFPPRMUNI.Text, _
                                                       Me.cboFPPRNOTA.Text, _
                                                       stFPPRFEES, _
                                                       stFPPRFERE, _
                                                       Me.txtFPPRTOMO.Text, _
                                                       stFPPRMAIN, _
                                                       Me.chkFPPRGRAV.Checked, _
                                                       inFPPRMOAD, _
                                                       boFPPRLITI, _
                                                       stFPPRPOLI, _
                                                       vl_stRESODEPA, _
                                                       vl_stRESOMUNI, _
                                                       vl_inRESOTIRE, _
                                                       vl_inRESOCLSE, _
                                                       vl_inRESOVIGE, _
                                                       vl_inRESORESO, _
                                                       inSECUENCIA, _
                                                       vl_inFIPRNURE, _
                                                       Me.cboFPPRESTA.SelectedValue)) = True Then
                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()

                        ' suma el porcentaje de derecho
                        Dim objdatos3 As New cla_FIPRPROP
                        Dim tbl3 As New DataTable
                        Dim siTOTAL As Single
                        Dim i As Integer

                        tbl3 = objdatos3.fun_Consultar_SUMA_X_FPPRDERE_FIPRPROP(vp_FichaPredial)

                        For i = 0 To tbl3.Rows.Count - 1
                            siTOTAL += CType(tbl3.Rows(i).Item(0), Single)
                        Next

                        If siTOTAL >= 100 Then
                            Me.Close()
                        Else
                            If MessageBox.Show("¿ Desea agregar otro registro ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                                cboFPPRCAPR.Focus()
                                Me.Close()
                            End If

                            ' se coloca la mascara de los campos de la juridica
                            txtFPPRFEES.Mask = ("00-00-0000")
                            txtFPPRFERE.Mask = ("00-00-0000")
                            txtFPPRMAIN.Mask = ("000-0000000")

                            pro_NumeroDeSecuenciaDeRegistro()
                            pro_Sumar_Porcentaje()
                        End If

                        pro_ReconsultarPropietario()

                        ' limpiar la informacion del propietario (Solo opera a propietario)
                        cboFPPRCAPR.SelectedIndex = 0
                        cboFPPRSEXO.SelectedIndex = 0
                        cboFPPRTIDO.SelectedIndex = 0
                        txtFPPRNUDO.Text = ""
                        txtFPPRPRAP.Text = ""
                        txtFPPRSEAP.Text = ""
                        txtFPPRNOMB.Text = ""
                        txtFPPRDERE.Text = ""

                        'pro_LimpiarCampos()
                        cboFPPRCAPR.Focus()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click
        Try
            ' Verifica los campos si el predio es posesion
            If stMODOADQU = 2 Then
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

            ElseIf inFPPRMOAD = 1 Then
                ' Verifica los campos si el predio es derecho real o sucesion
                If fun_Verificar_Campos_Llenos_16_DATOS(Me.cboFPPRCAPR.Text, _
                                                       Me.cboFPPRSEXO.Text, _
                                                       Me.cboFPPRTIDO.Text, _
                                                       Me.txtFPPRNUDO.Text, _
                                                       Me.txtFPPRPRAP.Text, _
                                                       Me.txtFPPRNOMB.Text, _
                                                       Me.txtFPPRDERE.Text, _
                                                       Me.txtFPPRESCR.Text, _
                                                       Me.cboFPPRDEPA.Text, _
                                                       Me.cboFPPRMUNI.Text, _
                                                       Me.cboFPPRNOTA.Text, _
                                                       Me.txtFPPRFEES.Text, _
                                                       Me.txtFPPRFERE.Text, _
                                                       Me.txtFPPRTOMO.Text, _
                                                       Me.txtFPPRMAIN.Text, _
                                                       Me.cboFPPRESTA.Text) = False Then

                    mod_MENSAJE.Existen_Campos_Sin_Diligenciar()
                    cboFPPRCAPR.Focus()
                Else
                    pro_Guardar()
                End If

            ElseIf inFPPRMOAD = 3 Then
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
            MessageBox.Show(Err.Description & "Guardar")
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        cboFPPRCAPR.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_insertar_FIPRPROP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strBARRESTA.Items(0).Text = "Propietarios"
    End Sub

#End Region

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

        If inFPPRMOAD = 1 Or inFPPRMOAD = 3 Then
            If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                Me.txtFPPRFERE.Focus()
            End If
        ElseIf inFPPRMOAD = 2 Then
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
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_CALIPROP()
        End If
    End Sub
    Private Sub cboFPPRSEXO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFPPRSEXO.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_SEXO()
        End If
    End Sub
    Private Sub cboFPPRTIDO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFPPRTIDO.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_TIPODOCU()
        End If
    End Sub
    Private Sub cboFPPRDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFPPRDEPA.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_DEPARTAMENTO()
        End If
    End Sub
    Private Sub cboFPPRMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFPPRMUNI.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_MUNICIPIO()
        End If
    End Sub
    Private Sub cboFPPRNOTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboFPPRNOTA.KeyDown
        If e.KeyCode = Keys.F2 Then
            mod_LLAMAR_FORMULARIO_INSERTAR.pro_Llamar_formulario_frm_NOTARIA()
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
    Private Sub dgvFIPRPROP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFIPRPROP.GotFocus
        strBARRESTA.Items(0).Text = dgvFIPRPROP.AccessibleDescription
    End Sub
    Private Sub cmdGUARDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGUARDAR.AccessibleDescription
    End Sub
    Private Sub cmdCANCELAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub


#End Region

#Region "Validated"

    Private Sub cboFPPRCAPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRCAPR.Validated
        If Trim(cboFPPRCAPR.Text) = "" Then
            cboFPPRCAPR.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboFPPRSEXO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRSEXO.Validated
        If Trim(cboFPPRSEXO.Text) = "" Then
            cboFPPRSEXO.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub cboFPPRTIDO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFPPRTIDO.Validated
        If Trim(cboFPPRTIDO.Text) = "" Then
            cboFPPRTIDO.Focus()
            strBARRESTA.Items(1).Text = IncoValoNulo
        Else
            strBARRESTA.Items(0).Text = ""
            strBARRESTA.Items(1).Text = ""
        End If
    End Sub
    Private Sub txtFPPRNUDO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFPPRNUDO.Validated
        Try
            If Trim(txtFPPRNUDO.Text) = "" Then
                txtFPPRNUDO.Focus()
                strBARRESTA.Items(1).Text = IncoValoNume
                ErrorProvider1.SetError(Me.txtFPPRNUDO, "")
            Else
                strBARRESTA.Items(1).Text = ""

                Dim Codigo As String = Trim(txtFPPRNUDO.Text)

                Dim objdatos As New cla_FIPRPROP
                Dim tbl As New DataTable
                tbl = objdatos.fun_Buscar_CODIGO_FIPRPROP(vp_FichaPredial, Codigo)

                If tbl.Rows.Count > 0 Then
                    ErrorProvider1.SetError(Me.txtFPPRNUDO, "Código existente en la base de datos")
                    strBARRESTA.Items(1).Text = "Código existente en la base de datos"
                    txtFPPRNUDO.Focus()
                Else
                    ErrorProvider1.SetError(Me.txtFPPRNUDO, "")

                    ' extrae el tercero si ya existe en base de datos
                    Dim objdatos1 As New cla_TERCERO
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_CODIGO_TERCERO(Trim(txtFPPRNUDO.Text))

                    If tbl1.Rows.Count > 0 And Trim(Me.cboFPPRTIDO.SelectedValue) <> 8 Then

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

        If Trim(Me.txtFPPRDERE.Text) = "" Then
            Me.txtFPPRDERE.Focus()
            Me.strBARRESTA.Items(1).Text = IncoValoDeci
        Else
            If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(Me.txtFPPRDERE.Text)) = False Then
                vl_boSWVerificaDatoAlGuardar = False

                Me.txtFPPRDERE.Focus()
                Me.strBARRESTA.Items(1).Text = IncoValoDeci
            Else
                vl_boSWVerificaDatoAlGuardar = True

                pro_Sumar_Porcentaje()

                Me.txtFPPRDERE.Text = fun_Formato_Decimal_6_Decimales(Trim(Me.txtFPPRDERE.Text))
                Me.strBARRESTA.Items(1).Text = ""

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

        If inFPPRMOAD <> 2 And Trim(cboFPPRDEPA.Text) <> "" Then
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

        If inFPPRMOAD <> 2 And Trim(cboFPPRMUNI.Text) <> "" Then
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

        If inFPPRMOAD <> 2 And Trim(cboFPPRNOTA.Text) <> "" Then
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

        If inFPPRMOAD <> 3 And inFPPRMOAD <> 2 Then

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

        If inFPPRMOAD <> 3 Then

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