Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_MUPRPROP

    '========================================================
    '*** INSERTAR MUTACIONES PRIMERA CLASE - PROPIETARIOS ***
    '========================================================

#Region "VARIABLE"

    Dim inMPPRIDRE As Integer
    Dim inMPPRSECU As Integer
    Dim inMPPRVIGE As Integer
    Dim inMPPRTIRE As Integer
    Dim inMPPRRESO As Integer
    Dim inMPPRNUFI As Integer
    Dim inMPPRNURE As Integer
    Dim stMPPRNUDO As String

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer, _
                   ByVal inSECU As Integer, _
                   ByVal inVIGE As Integer, _
                   ByVal inTIRE As Integer, _
                   ByVal inRESO As Integer, _
                   ByVal inNUFI As Integer, _
                   ByVal inNURE As Integer, _
                   ByVal stNUDO As String)

        inMPPRIDRE = inIDRE
        inMPPRSECU = inSECU
        inMPPRVIGE = inVIGE
        inMPPRTIRE = inTIRE
        inMPPRRESO = inRESO
        inMPPRNUFI = inNUFI
        inMPPRNURE = inNURE
        stMPPRNUDO = stNUDO

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inSECU As Integer, _
                   ByVal inVIGE As Integer, _
                   ByVal inTIRE As Integer, _
                   ByVal inRESO As Integer)

        inMPPRSECU = inSECU
        inMPPRVIGE = inVIGE
        inMPPRTIRE = inTIRE
        inMPPRRESO = inRESO

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtMPPRNUFI.Text = ""
        Me.txtMPPRNUDO.Text = ""
        Me.txtMPPRNUFI.Text = ""
        Me.txtMPPRMAIN.Text = ""
        Me.txtMPPRCIRE.Text = ""
        Me.txtMPPRESCR.Text = ""
        Me.txtMPPRFEES.Text = ""
        Me.txtMPPRVACO.Text = ""
        Me.txtMPPRENTI.Text = ""
        Me.txtMPPRDENO.Text = ""
        Me.txtMPPRMUNO.Text = ""
        Me.txtMPPRFAEN.Text = ""
        Me.txtMPPRDERE.Text = ""
        Me.txtMPPRFERE.Text = ""
        Me.txtMPPRLIRE.Text = ""
        Me.txtMPPRTORE.Text = ""
        Me.txtMPPRPARE.Text = ""
        Me.txtMPPRCOFI.Text = ""
        Me.txtMPPRNOFI.Text = ""
        Me.txtMPPRPRNO.Text = ""
        Me.txtMPPRSENO.Text = ""
        Me.txtMPPRPRAP.Text = ""
        Me.txtMPPRSEAP.Text = ""
        Me.txtMPPRRASO.Text = ""
        Me.txtMPPRTELE.Text = ""
        Me.txtMPPRCOEL.Text = ""
        Me.txtMPPRCELU.Text = ""
        Me.txtMPPRDIRE.Text = ""
        Me.txtMPPRSICO.Text = ""

        Me.lblMPPRTIRE.Text = ""
        Me.lblMPPRVIGE.Text = ""
        Me.lblMPPRRESO.Text = ""

        Me.cboMPPRTIDO.DataSource = New DataTable
        Me.cboMPPRCAPR.DataSource = New DataTable
        Me.cboMPPRESTA.DataSource = New DataTable

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_MUPRPROP
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_MUPRPROP(inMPPRIDRE)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraCEDUCATA.Text = "MODIFICAR PROPIETARIOS"

                    Me.txtMPPRNUDO.ReadOnly = True

                    Me.lblMPPRVIGE.Text = inMPPRVIGE
                    Me.lblMPPRTIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO(inMPPRTIRE), String)
                    Me.lblMPPRRESO.Text = inMPPRRESO

                    Dim objdatos11 As New cla_TIPODOCU

                    Me.cboMPPRTIDO.DataSource = objdatos11.fun_Consultar_CAMPOS_MANT_TIPODOCU
                    Me.cboMPPRTIDO.DisplayMember = "TIDODESC"
                    Me.cboMPPRTIDO.ValueMember = "TIDOCODI"

                    Me.cboMPPRTIDO.SelectedValue = tbl.Rows(0).Item("MPPRTIDO")

                    Dim objdatos1 As New cla_CALIPROP

                    Me.cboMPPRCAPR.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CALIPROP
                    Me.cboMPPRCAPR.DisplayMember = "CAPRDESC"
                    Me.cboMPPRCAPR.ValueMember = "CAPRCODI"

                    Me.cboMPPRCAPR.SelectedValue = tbl.Rows(0).Item("MPPRCAPR")

                    Dim objdatos13 As New cla_SEXO

                    Me.cboMPPRSEXO.DataSource = objdatos13.fun_Consultar_CAMPOS_MANT_SEXO
                    Me.cboMPPRSEXO.DisplayMember = "SEXODESC"
                    Me.cboMPPRSEXO.ValueMember = "SEXOCODI"

                    Me.cboMPPRSEXO.SelectedValue = tbl.Rows(0).Item("MPPRSEXO")

                    Dim objdatos3 As New cla_ESTADO

                    Me.cboMPPRESTA.DataSource = objdatos3.fun_Consultar_TODOS_LOS_ESTADOS
                    Me.cboMPPRESTA.DisplayMember = "ESTADESC"
                    Me.cboMPPRESTA.ValueMember = "ESTACODI"

                    Me.cboMPPRESTA.SelectedValue = tbl.Rows(0).Item("MPPRESTA")

                    Me.txtMPPRNUDO.Text = Trim(tbl.Rows(0).Item("MPPRNUDO"))
                    Me.txtMPPRNUFI.Text = Trim(tbl.Rows(0).Item("MPPRNUFI"))
                    Me.txtMPPRNOVC.Text = Trim(tbl.Rows(0).Item("MPPRNOVC"))
                    Me.txtMPPRMAIN.Text = Trim(tbl.Rows(0).Item("MPPRMAIN"))
                    Me.txtMPPRCIRE.Text = Trim(tbl.Rows(0).Item("MPPRCIRE"))
                    Me.txtMPPRESCR.Text = Trim(tbl.Rows(0).Item("MPPRESCR"))
                    Me.txtMPPRFEES.Text = Trim(tbl.Rows(0).Item("MPPRFEES"))
                    Me.txtMPPRVACO.Text = Trim(tbl.Rows(0).Item("MPPRVACO"))
                    Me.txtMPPRENTI.Text = Trim(tbl.Rows(0).Item("MPPRENTI"))
                    Me.txtMPPRDENO.Text = Trim(tbl.Rows(0).Item("MPPRDENO"))
                    Me.txtMPPRMUNO.Text = Trim(tbl.Rows(0).Item("MPPRMUNO"))
                    Me.txtMPPRFAEN.Text = Trim(tbl.Rows(0).Item("MPPRFAEN"))
                    Me.txtMPPRDERE.Text = Trim(tbl.Rows(0).Item("MPPRDERE"))
                    Me.chkMPPRGRAV.Checked = tbl.Rows(0).Item("MPPRGRAV")
                    Me.txtMPPRFERE.Text = Trim(tbl.Rows(0).Item("MPPRFERE"))
                    Me.txtMPPRLIRE.Text = Trim(tbl.Rows(0).Item("MPPRLIRE"))
                    Me.txtMPPRTORE.Text = Trim(tbl.Rows(0).Item("MPPRTORE"))
                    Me.txtMPPRPARE.Text = Trim(tbl.Rows(0).Item("MPPRPARE"))
                    Me.txtMPPRCOFI.Text = Trim(tbl.Rows(0).Item("MPPRCOFI"))
                    Me.txtMPPRNOFI.Text = Trim(tbl.Rows(0).Item("MPPRNOFI"))
                    Me.txtMPPRPRNO.Text = Trim(tbl.Rows(0).Item("MPPRPRNO"))
                    Me.txtMPPRSENO.Text = Trim(tbl.Rows(0).Item("MPPRSENO"))
                    Me.txtMPPRPRAP.Text = Trim(tbl.Rows(0).Item("MPPRPRAP"))
                    Me.txtMPPRSEAP.Text = Trim(tbl.Rows(0).Item("MPPRSEAP"))
                    Me.txtMPPRRASO.Text = Trim(tbl.Rows(0).Item("MPPRRASO"))
                    Me.txtMPPRTELE.Text = Trim(tbl.Rows(0).Item("MPPRTELE"))
                    Me.txtMPPRCOEL.Text = Trim(tbl.Rows(0).Item("MPPRCOEL"))
                    Me.txtMPPRCELU.Text = Trim(tbl.Rows(0).Item("MPPRCELU"))
                    Me.txtMPPRDIRE.Text = Trim(tbl.Rows(0).Item("MPPRDIRE"))
                    Me.txtMPPRSICO.Text = Trim(tbl.Rows(0).Item("MPPRSICO"))

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraCEDUCATA.Text = "INSERTAR PROPIETARIOS"

                Me.lblMPPRVIGE.Text = inMPPRVIGE
                Me.lblMPPRTIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO(inMPPRTIRE), String)
                Me.lblMPPRRESO.Text = inMPPRRESO

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_NumeroDeSecuenciaDeRegistro() As Integer

        Try
            Dim inFPDESECU As Integer = 0

            Dim objdatos5 As New cla_MUPRPROP
            Dim tbl10 As New DataTable

            tbl10 = objdatos5.fun_Buscar_SECUENCIA_X_MUPRPROP(inMPPRVIGE, inMPPRTIRE, inMPPRRESO, Me.txtMPPRNUDO.Text)

            If tbl10.Rows.Count = 0 Then
                inFPDESECU = 1
            Else
                Dim i As Integer
                Dim NroMayor As Integer
                Dim Posicion As Integer

                Posicion = Val(tbl10.Rows(0).Item("MUPRNURE"))

                For i = 0 To tbl10.Rows.Count - 1
                    NroMayor = Val(tbl10.Rows(i).Item("MUPRNURE"))

                    If NroMayor > Posicion Then
                        inFPDESECU = NroMayor
                        Posicion = NroMayor
                    Else
                        inFPDESECU = Posicion
                    End If
                Next

                inFPDESECU += 1
            End If

            Return inFPDESECU

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            'inserta el registro
            If boINSERTAR = True Then

                'instancia la clase
                Dim objdatos As New cla_MUPRPROP

                Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_MUPRPROP(inMPPRVIGE, inMPPRTIRE, inMPPRRESO, txtMPPRNUFI, inMPPRNURE, txtMPPRNUDO)

                'instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boMPPRNUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMPPRNUDO)
                Dim boMPPRNUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPPRNUFI)
                Dim boMPPRNOVC As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPPRNOVC)
                Dim boMPPRMAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPPRMAIN)
                Dim boMPPRCIRE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPPRCIRE)
                Dim boMPPRESCR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPPRESCR)
                Dim boMPPRFEES As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtMPPRFEES)
                Dim boMPPRVACO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPPRVACO)
                Dim boMPPRENTI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMPPRENTI)
                Dim boMPPRDENO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPPRDENO)
                Dim boMPPRMUNO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPPRMUNO)
                Dim boMPPRFAEN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMPPRFAEN)
                Dim boMPPRDERE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtMPPRDERE)
                Dim boMPPRFERE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtMPPRFERE)
                Dim boMPPRPRNO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMPPRPRNO)
                Dim boMPPRPRAP As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMPPRPRAP)
                Dim boMPPRDIRE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMPPRDIRE)
                Dim boMPPRTIDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMPPRTIDO)
                Dim boMPPRCAPR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMPPRCAPR)
                Dim boMPPRSEXO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMPPRSEXO)
                Dim boMPPRESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMPPRESTA)

                'verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And _
                   boMPPRNUDO = True And _
                   boMPPRNUFI = True And _
                   boMPPRNOVC = True And _
                   boMPPRMAIN = True And _
                   boMPPRCIRE = True And _
                   boMPPRESCR = True And _
                   boMPPRFEES = True And _
                   boMPPRVACO = True And _
                   boMPPRENTI = True And _
                   boMPPRDENO = True And _
                   boMPPRMUNO = True And _
                   boMPPRFAEN = True And _
                   boMPPRDERE = True And _
                   boMPPRFERE = True And _
                   boMPPRPRNO = True And _
                   boMPPRPRAP = True And _
                   boMPPRDIRE = True And _
                   boMPPRTIDO = True And _
                   boMPPRCAPR = True And _
                   boMPPRSEXO = True And _
                   boMPPRESTA = True Then

                    ' numero de registro
                    Dim stNUMEREGI As String = CStr(fun_NumeroDeSecuenciaDeRegistro())

                    Dim objdatos22 As New cla_MUPRPROP

                    If (objdatos22.fun_Insertar_MUPRPROP(inMPPRSECU, _
                                                         inMPPRVIGE, _
                                                         inMPPRTIRE, _
                                                         inMPPRRESO, _
                                                         Me.txtMPPRNUFI.Text, _
                                                         stNUMEREGI, _
                                                         Me.txtMPPRNUDO.Text, _
                                                         Me.txtMPPRNOVC.Text, _
                                                         Me.cboMPPRTIDO.SelectedValue, _
                                                         Me.txtMPPRMAIN.Text, _
                                                         Me.txtMPPRCIRE.Text, _
                                                         Me.txtMPPRESCR.Text, _
                                                         Me.txtMPPRFEES.Text, _
                                                         Me.txtMPPRVACO.Text, _
                                                         Me.txtMPPRENTI.Text, _
                                                         Me.txtMPPRDENO.Text, _
                                                         Me.txtMPPRMUNO.Text, _
                                                         Me.txtMPPRFAEN.Text, _
                                                         Me.txtMPPRDERE.Text, _
                                                         Me.chkMPPRGRAV.Checked, _
                                                         Me.txtMPPRFERE.Text, _
                                                         Me.txtMPPRLIRE.Text, _
                                                         Me.txtMPPRTORE.Text, _
                                                         Me.txtMPPRPARE.Text, _
                                                         Me.txtMPPRCOFI.Text, _
                                                         Me.txtMPPRNOFI.Text, _
                                                         Me.txtMPPRPRNO.Text, _
                                                         Me.txtMPPRSENO.Text, _
                                                         Me.txtMPPRPRAP.Text, _
                                                         Me.txtMPPRSEAP.Text, _
                                                         Me.txtMPPRRASO.Text, _
                                                         Me.txtMPPRTELE.Text, _
                                                         Me.txtMPPRCOEL.Text, _
                                                         Me.txtMPPRCELU.Text, _
                                                         Me.txtMPPRDIRE.Text, _
                                                         Me.txtMPPRSICO.Text, _
                                                         Me.cboMPPRCAPR.SelectedValue, _
                                                         Me.cboMPPRSEXO.SelectedValue, _
                                                         Me.cboMPPRESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtMPPRNUDO.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boMPPRNUDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMPPRNUDO)
                Dim boMPPRNUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPPRNUFI)
                Dim boMPPRNOVC As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPPRNOVC)
                Dim boMPPRMAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPPRMAIN)
                Dim boMPPRCIRE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPPRCIRE)
                Dim boMPPRESCR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPPRESCR)
                Dim boMPPRFEES As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtMPPRFEES)
                Dim boMPPRVACO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPPRVACO)
                Dim boMPPRENTI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMPPRENTI)
                Dim boMPPRDENO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPPRDENO)
                Dim boMPPRMUNO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtMPPRMUNO)
                Dim boMPPRFAEN As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMPPRFAEN)
                Dim boMPPRDERE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtMPPRDERE)
                Dim boMPPRFERE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Fecha(Me.txtMPPRFERE)
                Dim boMPPRPRNO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMPPRPRNO)
                Dim boMPPRPRAP As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMPPRPRAP)
                Dim boMPPRDIRE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtMPPRDIRE)
                Dim boMPPRTIDO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMPPRTIDO)
                Dim boMPPRCAPR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMPPRCAPR)
                Dim boMPPRSEXO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMPPRSEXO)
                Dim boMPPRESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboMPPRESTA)

                ' verifica los datos del formulario 
                If boMPPRNUDO = True And _
                   boMPPRNOVC = True And _
                   boMPPRNUFI = True And _
                   boMPPRMAIN = True And _
                   boMPPRCIRE = True And _
                   boMPPRESCR = True And _
                   boMPPRFEES = True And _
                   boMPPRVACO = True And _
                   boMPPRENTI = True And _
                   boMPPRDENO = True And _
                   boMPPRMUNO = True And _
                   boMPPRFAEN = True And _
                   boMPPRDERE = True And _
                   boMPPRFERE = True And _
                   boMPPRPRNO = True And _
                   boMPPRPRAP = True And _
                   boMPPRDIRE = True And _
                   boMPPRTIDO = True And _
                   boMPPRCAPR = True And _
                   boMPPRSEXO = True And _
                   boMPPRESTA = True Then

                    Dim objdatos22 As New cla_MUPRPROP

                    If (objdatos22.fun_Actualizar_MUPRPROP(inMPPRIDRE, _
                                                           inMPPRSECU, _
                                                           inMPPRVIGE, _
                                                           inMPPRTIRE, _
                                                           inMPPRRESO, _
                                                           Me.txtMPPRNUFI.Text, _
                                                           inMPPRNURE, _
                                                           Me.txtMPPRNUDO.Text, _
                                                           Me.txtMPPRNOVC.Text, _
                                                           Me.cboMPPRTIDO.SelectedValue, _
                                                           Me.txtMPPRMAIN.Text, _
                                                           Me.txtMPPRCIRE.Text, _
                                                           Me.txtMPPRESCR.Text, _
                                                           Me.txtMPPRFEES.Text, _
                                                           Me.txtMPPRVACO.Text, _
                                                           Me.txtMPPRENTI.Text, _
                                                           Me.txtMPPRDENO.Text, _
                                                           Me.txtMPPRMUNO.Text, _
                                                           Me.txtMPPRFAEN.Text, _
                                                           Me.txtMPPRDERE.Text, _
                                                           Me.chkMPPRGRAV.Checked, _
                                                           Me.txtMPPRFERE.Text, _
                                                           Me.txtMPPRLIRE.Text, _
                                                           Me.txtMPPRTORE.Text, _
                                                           Me.txtMPPRPARE.Text, _
                                                           Me.txtMPPRCOFI.Text, _
                                                           Me.txtMPPRNOFI.Text, _
                                                           Me.txtMPPRPRNO.Text, _
                                                           Me.txtMPPRSENO.Text, _
                                                           Me.txtMPPRPRAP.Text, _
                                                           Me.txtMPPRSEAP.Text, _
                                                           Me.txtMPPRRASO.Text, _
                                                           Me.txtMPPRTELE.Text, _
                                                           Me.txtMPPRCOEL.Text, _
                                                           Me.txtMPPRCELU.Text, _
                                                           Me.txtMPPRDIRE.Text, _
                                                           Me.txtMPPRSICO.Text, _
                                                           Me.cboMPPRCAPR.SelectedValue, _
                                                           Me.cboMPPRSEXO.SelectedValue, _
                                                           Me.cboMPPRESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboMPPRTIDO.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.cboMPPRTIDO.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMPPRPRNO.KeyPress, txtMPPRSENO.KeyPress, txtMPPRPRAP.KeyPress, txtMPPRSEAP.KeyPress, txtMPPRCIRE.KeyPress, txtMPPRNUDO.KeyPress, cboMPPRCAPR.KeyPress, txtMPPRESCR.KeyPress, txtMPPRFEES.KeyPress, cboMPPRESTA.KeyPress, txtMPPRMAIN.KeyPress, txtMPPRNUFI.KeyPress, cboMPPRTIDO.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboMPPRTIDO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMPPRTIDO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPODOCU_Descripcion(Me.cboMPPRTIDO, Me.cboMPPRTIDO.SelectedIndex)
        End If
    End Sub
    Private Sub cboMPPRCAPR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMPPRCAPR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CALIPROP_Descripcion(Me.cboMPPRCAPR, Me.cboMPPRCAPR.SelectedIndex)
        End If
    End Sub
    Private Sub cboMPPRSEXO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMPPRSEXO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_SEXO_Descripcion(Me.cboMPPRSEXO, Me.cboMPPRSEXO.SelectedIndex)
        End If
    End Sub
    Private Sub cboMPPRESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMPPRESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboMPPRESTA, Me.cboMPPRESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "Click"

    Private Sub cboMPPRTIDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMPPRTIDO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPODOCU_Descripcion(Me.cboMPPRTIDO, Me.cboMPPRTIDO.SelectedIndex)
    End Sub
    Private Sub cboMPPRCAPR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMPPRCAPR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CALIPROP_Descripcion(Me.cboMPPRCAPR, Me.cboMPPRCAPR.SelectedIndex)
    End Sub
    Private Sub cboMPPRSEXO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMPPRSEXO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_SEXO_Descripcion(Me.cboMPPRSEXO, Me.cboMPPRSEXO.SelectedIndex)
    End Sub
    Private Sub cboMPPRESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMPPRESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboMPPRESTA, Me.cboMPPRESTA.SelectedIndex)
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMPPRPRNO.GotFocus, txtMPPRSENO.GotFocus, txtMPPRPRAP.GotFocus, txtMPPRSEAP.GotFocus, txtMPPRCIRE.GotFocus, txtMPPRNUDO.GotFocus, txtMPPRESCR.GotFocus, txtMPPRFEES.GotFocus, txtMPPRMAIN.GotFocus, txtMPPRNUFI.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMPPRCAPR.GotFocus, cboMPPRESTA.GotFocus, cboMPPRTIDO.GotFocus
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

#End Region

End Class