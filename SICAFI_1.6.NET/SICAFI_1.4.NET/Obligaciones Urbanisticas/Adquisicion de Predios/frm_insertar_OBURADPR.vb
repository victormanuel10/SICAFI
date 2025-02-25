Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_OBURADPR

    '=================================================================
    '*** INSERTAR ADQUISICION DE PREDIOS OBLIGACIONES URBANISTICAS ***
    '=================================================================

#Region "VARIABLE"

    Dim inOUAPIDRE As Integer
    Dim stOUAPCLEN As String
    Dim inOUAPNURE As Integer
    Dim stOUAPFERE As String
    Dim inOUAPCLOU As Integer
    Dim inOUAPSECU As Integer
    Dim stOUAPNDSU As String

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer, ByVal stCLEN As String, ByVal inNURE As Integer, ByVal stFERE As String, ByVal stNDSU As String)
        inOUAPIDRE = inIDRE
        inOUAPSECU = inSECU
        stOUAPCLEN = stCLEN
        inOUAPNURE = inNURE
        stOUAPFERE = stFERE
        stOUAPNDSU = stNDSU

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inSECU As Integer, ByVal stCLEN As String, ByVal inNURE As Integer, ByVal stFERE As String)
        inOUAPSECU = inSECU
        stOUAPCLEN = stCLEN
        inOUAPNURE = inNURE
        stOUAPFERE = stFERE

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtOUAPMUNI.Text = "266"
        Me.txtOUAPCORR.Text = "01"
        Me.txtOUAPBARR.Text = ""
        Me.txtOUAPMANZ.Text = ""
        Me.txtOUAPPRED.Text = ""
        Me.txtOUAPEDIF.Text = ""
        Me.txtOUAPUNPR.Text = ""
        Me.txtOUAPMAIN.Text = ""
        Me.txtOUAPNUOF.Text = "0"
        Me.lblOUAPNDSU.Text = ""
        Me.txtOUAPARTE.Text = "0"
        Me.txtOUAPAVCA.Text = "0"
        Me.txtOUAPAVCO.Text = "0"
        Me.txtOUAPVACO.Text = "0"
        Me.txtOUAPDESC.Text = ""
        Me.txtOUAPOBSE.Text = ""

        Me.cboOUAPCLSE.DataSource = New DataTable
        Me.cboOUAPSUPE.DataSource = New DataTable
        Me.cboOUAPESTA.DataSource = New DataTable

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_OBURADPR
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_OBURADPR(inOUAPIDRE)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraCEDUCATA.Text = "MODIFICAR ADQUISICIÓN DE PREDIOS"

                    Me.txtOUAPMAIN.ReadOnly = True

                    Me.txtOUAPMUNI.Text = Trim(tbl.Rows(0).Item("OUAPMUNI"))
                    Me.txtOUAPCORR.Text = Trim(tbl.Rows(0).Item("OUAPCORR"))
                    Me.txtOUAPBARR.Text = Trim(tbl.Rows(0).Item("OUAPBARR"))
                    Me.txtOUAPMANZ.Text = Trim(tbl.Rows(0).Item("OUAPMANZ"))
                    Me.txtOUAPPRED.Text = Trim(tbl.Rows(0).Item("OUAPPRED"))
                    Me.txtOUAPEDIF.Text = Trim(tbl.Rows(0).Item("OUAPEDIF"))
                    Me.txtOUAPUNPR.Text = Trim(tbl.Rows(0).Item("OUAPUNPR"))

                    Dim objdatos1 As New cla_CLASSECT

                    Me.cboOUAPCLSE.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CLASSECT
                    Me.cboOUAPCLSE.DisplayMember = "CLSEDESC"
                    Me.cboOUAPCLSE.ValueMember = "CLSECODI"

                    Me.cboOUAPCLSE.SelectedValue = tbl.Rows(0).Item("OUAPCLSE")

                    Dim objdatos11 As New cla_CLASOBUR

                    Me.cboOUAPCLOU.DataSource = objdatos11.fun_Consultar_CAMPOS_MANT_CLASOBUR
                    Me.cboOUAPCLOU.DisplayMember = "CLOUDESC"
                    Me.cboOUAPCLOU.ValueMember = "CLOUCODI"

                    Me.cboOUAPCLOU.SelectedValue = tbl.Rows(0).Item("OUAPCLOU")

                    Me.txtOUAPDIRE.Text = Trim(tbl.Rows(0).Item("OUAPDIRE"))
                    Me.txtOUAPMAIN.Text = Trim(tbl.Rows(0).Item("OUAPMAIN"))
                    Me.txtOUAPNUOF.Text = Trim(tbl.Rows(0).Item("OUAPNUOF"))
                    Me.txtOUAPARTE.Text = Trim(tbl.Rows(0).Item("OUAPARTE"))
                    Me.txtOUAPDESC.Text = Trim(tbl.Rows(0).Item("OUAPDESC"))
                    Me.txtOUAPOBSE.Text = Trim(tbl.Rows(0).Item("OUAPOBSE"))
                    Me.txtOUAPAVCA.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("OUAPAVCA")))
                    Me.txtOUAPAVCO.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("OUAPAVCO")))
                    Me.txtOUAPVACO.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("OUAPVACO")))

                    Dim objdatos2 As New cla_USUARIO

                    Me.cboOUAPSUPE.DataSource = objdatos2.fun_Buscar_CODIGO_USUARIO(Trim(stOUAPNDSU))
                    Me.cboOUAPSUPE.DisplayMember = "USUANOMB"
                    Me.cboOUAPSUPE.ValueMember = "USUANUDO"

                    Me.lblOUAPNDSU.Text = Trim(tbl.Rows(0).Item("OUAPNDSU"))

                    Dim objdatos3 As New cla_ESTADO

                    Me.cboOUAPESTA.DataSource = objdatos3.fun_Consultar_TODOS_LOS_ESTADOS
                    Me.cboOUAPESTA.DisplayMember = "ESTADESC"
                    Me.cboOUAPESTA.ValueMember = "ESTACODI"

                    Me.cboOUAPESTA.SelectedValue = tbl.Rows(0).Item("OUAPESTA")

                    Me.lblOUAPCLOU.Text = CType(fun_Buscar_Lista_Valores_CLASOBUR_Codigo(Me.cboOUAPCLOU), String)

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraCEDUCATA.Text = "INSERTAR ADQUISICIÓN DE PREDIOS"

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GuardarAtributosDelPredio()

        Try
            ' declara las variables
            Dim stCiuculoRegistral As String = "001-"
            Dim stNroMatricula As String = fun_Formato_Mascara_7_Reales(Trim(Me.txtOUAPMAIN.Text))
            Dim stMatricula As String = stCiuculoRegistral & stNroMatricula

            ' instancia la clase
            Dim obFIPRPROP As New cla_FIPRPROP
            Dim dtFIPRPROP As New DataTable

            dtFIPRPROP = obFIPRPROP.fun_Buscar_FIPRPROP_X_MATRICULA(stMatricula)

            If dtFIPRPROP.Rows.Count > 0 Then

                ' instancia la clase
                Dim obFICHPRED As New cla_FICHPRED
                Dim dtFICHPRED As New DataTable

                dtFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dtFIPRPROP.Rows(0).Item("FPPRNUFI").ToString)

                If dtFICHPRED.Rows.Count > 0 Then

                    ' declara las variables
                    Me.txtOUAPMUNI.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRMUNI").ToString)
                    Me.txtOUAPCORR.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRCORR").ToString)
                    Me.txtOUAPBARR.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRBARR").ToString)
                    Me.txtOUAPMANZ.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRMANZ").ToString)
                    Me.txtOUAPPRED.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRPRED").ToString)
                    Me.txtOUAPEDIF.Text = Trim(dtFICHPRED.Rows(0).Item("FIPREDIF").ToString)
                    Me.txtOUAPUNPR.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRUNPR").ToString)
                    Me.txtOUAPDIRE.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRDIRE").ToString)

                    ' declara la clase
                    Dim objdatos1 As New cla_CLASSECT

                    Me.cboOUAPCLSE.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CLASSECT
                    Me.cboOUAPCLSE.DisplayMember = "CLSEDESC"
                    Me.cboOUAPCLSE.ValueMember = "CLSECODI"

                    Me.cboOUAPCLSE.SelectedValue = dtFICHPRED.Rows(0).Item("FIPRCLSE")

                    ' area de predio normales
                    If CInt(dtFICHPRED.Rows(0).Item("FIPRCAPR")) = 1 Then
                        Me.txtOUAPARTE.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRARTE").ToString)
                    End If

                    ' area de predio en rph
                    If CInt(dtFICHPRED.Rows(0).Item("FIPRCAPR")) = 2 Or _
                        CInt(dtFICHPRED.Rows(0).Item("FIPRCAPR")) = 3 Then

                        ' instancia la clase
                        Dim obFICHRESU As New cla_FICHRESU
                        Dim dtFICHRESU As New DataTable

                        dtFICHRESU = obFICHRESU.fun_Consultar_FICHA_RESUMEN_x_CEDULA(Trim(dtFICHPRED.Rows(0).Item("FIPRMUNI").ToString), _
                                                                                     dtFICHPRED.Rows(0).Item("FIPRCLSE"), _
                                                                                     Trim(dtFICHPRED.Rows(0).Item("FIPRCORR").ToString), _
                                                                                     Trim(dtFICHPRED.Rows(0).Item("FIPRBARR").ToString), _
                                                                                     Trim(dtFICHPRED.Rows(0).Item("FIPRMANZ").ToString), _
                                                                                     Trim(dtFICHPRED.Rows(0).Item("FIPRPRED").ToString), 2)
                        ' area total de lote
                        If dtFICHRESU.Rows.Count > 0 Then
                            Me.txtOUAPARTE.Text = Trim(dtFICHRESU.Rows(0).Item("FIPRATLO").ToString)
                        End If

                    End If

                    ' declara la variable
                    Dim inVIGEACTU As Integer = 0

                    ' instancia la clase
                    Dim obPERIACTU As New cla_PERIACTU
                    Dim dtPERIACTU As New DataTable

                    dtPERIACTU = obPERIACTU.fun_Consultar_VIGENCIA_ACTUAL_X_MANT_PERIACTU

                    If dtPERIACTU.Rows.Count > 0 Then
                        inVIGEACTU = CInt(dtPERIACTU.Rows(0).Item("PEACCODI"))
                    Else
                        mod_MENSAJE.No_Existe_Una_Vigencia_Actual_Seleccionada()
                    End If

                    ' instancia la clase
                    Dim obHISTAVAL As New cla_HISTAVAL
                    Dim dtHISTAVAL As New DataTable

                    dtHISTAVAL = obHISTAVAL.fun_Buscar_CODIGO_NUFI_VIGE_X_HISTAVAL(Trim(dtFICHPRED.Rows(0).Item("FIPRNUFI").ToString), inVIGEACTU)

                    If dtHISTAVAL.Rows.Count > 0 Then
                        Me.txtOUAPAVCA.Text = fun_Formato_Mascara_Pesos_Enteros(CStr(CDbl(dtHISTAVAL.Rows(0).Item("HIAVAVAL"))))
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
            ' inserta el registro
            If boINSERTAR = True Then

                ' quita letras
                Me.txtOUAPAVCA.Text = fun_Quita_Letras(Trim(Me.txtOUAPAVCA.Text))
                Me.txtOUAPAVCO.Text = fun_Quita_Letras(Trim(Me.txtOUAPAVCO.Text))
                Me.txtOUAPVACO.Text = fun_Quita_Letras(Trim(Me.txtOUAPVACO.Text))

                ' instancia la clase
                Dim objdatos As New cla_OBURADPR

                Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_OBURADPR(stOUAPCLEN, inOUAPNURE, stOUAPFERE, Me.txtOUAPMAIN)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boOUAPMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPMUNI)
                Dim boOUAPCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPCORR)
                Dim boOUAPBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPBARR)
                Dim boOUAPMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPMANZ)
                Dim boOUAPPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPPRED)
                Dim boOUAPEDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPEDIF)
                Dim boOUAPUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPUNPR)
                Dim boOUAPCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUAPCLSE)
                Dim boOUAPMAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPMAIN)
                Dim boOUAPNUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPNUOF)
                Dim boOUAPARTE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPARTE)
                Dim boOUAPVATP As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPAVCA)
                Dim boOUAPVACP As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPAVCO)
                Dim boOUAPAVCA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPVACO)
                Dim boOUAPSUPE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUAPSUPE)
                Dim boOUAPCLOU As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUAPCLOU)
                Dim boOUAPESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUAPESTA)

                ' verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And _
                   boOUAPMUNI = True And _
                   boOUAPCORR = True And _
                   boOUAPBARR = True And _
                   boOUAPMANZ = True And _
                   boOUAPPRED = True And _
                   boOUAPEDIF = True And _
                   boOUAPUNPR = True And _
                   boOUAPCLSE = True And _
                   boOUAPMAIN = True And _
                   boOUAPSUPE = True And _
                   boOUAPCLOU = True And _
                   boOUAPARTE = True And _
                   boOUAPVATP = True And _
                   boOUAPVACP = True And _
                   boOUAPAVCA = True And _
                   boOUAPESTA = True And _
                   boOUAPNUFI = True Then

                    Dim objdatos22 As New cla_OBURADPR

                    If (objdatos22.fun_Insertar_OBURADPR(inOUAPSECU, _
                                                         stOUAPCLEN, _
                                                         inOUAPNURE, _
                                                         stOUAPFERE, _
                                                         Me.txtOUAPMAIN.Text, _
                                                         Me.cboOUAPCLOU.SelectedValue, _
                                                         Me.txtOUAPNUOF.Text, _
                                                         Me.cboOUAPSUPE.SelectedValue, _
                                                         Me.lblOUAPNDSU.Text, _
                                                         Me.txtOUAPMUNI.Text, _
                                                         Me.txtOUAPCORR.Text, _
                                                         Me.txtOUAPBARR.Text, _
                                                         Me.txtOUAPMANZ.Text, _
                                                         Me.txtOUAPPRED.Text, _
                                                         Me.txtOUAPEDIF.Text, _
                                                         Me.txtOUAPUNPR.Text, _
                                                         Me.cboOUAPCLSE.SelectedValue, _
                                                         Me.txtOUAPDIRE.Text, _
                                                         Me.txtOUAPARTE.Text, _
                                                         Me.txtOUAPAVCA.Text, _
                                                         Me.txtOUAPAVCO.Text, _
                                                         Me.txtOUAPVACO.Text, _
                                                         Me.txtOUAPDESC.Text, _
                                                         Me.txtOUAPOBSE.Text, _
                                                         Me.cboOUAPESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtOUAPMAIN.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' quita letras
                Me.txtOUAPAVCA.Text = fun_Quita_Letras(Trim(Me.txtOUAPAVCA.Text))
                Me.txtOUAPAVCO.Text = fun_Quita_Letras(Trim(Me.txtOUAPAVCO.Text))
                Me.txtOUAPVACO.Text = fun_Quita_Letras(Trim(Me.txtOUAPVACO.Text))

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boOUAPMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPMUNI)
                Dim boOUAPCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPCORR)
                Dim boOUAPBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPBARR)
                Dim boOUAPMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPMANZ)
                Dim boOUAPPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPPRED)
                Dim boOUAPEDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPEDIF)
                Dim boOUAPUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPUNPR)
                Dim boOUAPCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUAPCLSE)
                Dim boOUAPMAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPMAIN)
                Dim boOUAPNUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPNUOF)
                Dim boOUAPARTE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPARTE)
                Dim boOUAPVATP As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPAVCA)
                Dim boOUAPVACP As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPAVCO)
                Dim boOUAPAVCA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUAPVACO)
                Dim boOUAPSUPE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUAPSUPE)
                Dim boOUAPCLOU As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUAPCLOU)
                Dim boOUAPESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUAPESTA)

                ' verifica los datos del formulario 
                If boOUAPMUNI = True And _
                   boOUAPCORR = True And _
                   boOUAPBARR = True And _
                   boOUAPMANZ = True And _
                   boOUAPPRED = True And _
                   boOUAPEDIF = True And _
                   boOUAPUNPR = True And _
                   boOUAPCLSE = True And _
                   boOUAPMAIN = True And _
                   boOUAPSUPE = True And _
                   boOUAPCLOU = True And _
                   boOUAPARTE = True And _
                   boOUAPVATP = True And _
                   boOUAPVACP = True And _
                   boOUAPAVCA = True And _
                   boOUAPESTA = True And _
                   boOUAPNUFI = True Then

                    Dim objdatos22 As New cla_OBURADPR

                    If (objdatos22.fun_Actualizar_OBURADPR(inOUAPIDRE, _
                                                           inOUAPSECU, _
                                                           stOUAPCLEN, _
                                                           inOUAPNURE, _
                                                           stOUAPFERE, _
                                                           Me.txtOUAPMAIN.Text, _
                                                           Me.cboOUAPCLOU.SelectedValue, _
                                                           Me.txtOUAPNUOF.Text, _
                                                           Me.cboOUAPSUPE.SelectedValue, _
                                                           Me.lblOUAPNDSU.Text, _
                                                           Me.txtOUAPMUNI.Text, _
                                                           Me.txtOUAPCORR.Text, _
                                                           Me.txtOUAPBARR.Text, _
                                                           Me.txtOUAPMANZ.Text, _
                                                           Me.txtOUAPPRED.Text, _
                                                           Me.txtOUAPEDIF.Text, _
                                                           Me.txtOUAPUNPR.Text, _
                                                           Me.cboOUAPCLSE.SelectedValue, _
                                                           Me.txtOUAPDIRE.Text, _
                                                           Me.txtOUAPARTE.Text, _
                                                           Me.txtOUAPAVCA.Text, _
                                                           Me.txtOUAPAVCO.Text, _
                                                           Me.txtOUAPVACO.Text, _
                                                           Me.txtOUAPDESC.Text, _
                                                           Me.txtOUAPOBSE.Text, _
                                                           Me.cboOUAPESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtOUAPMUNI.Focus()
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
        Me.txtOUAPMUNI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "SelectedIndexChanged"

    Private Sub cboOUIGCLOU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOUAPCLOU.SelectedIndexChanged
        Me.lblOUAPCLOU.Text = CType(fun_Buscar_Lista_Valores_CLASOBUR_Codigo(Me.cboOUAPCLOU), String)
    End Sub
    Private Sub cboOUAPSUPE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOUAPSUPE.SelectedIndexChanged
        Me.lblOUAPNDSU.Text = CType(fun_Buscar_Lista_Valores_USUARIO_Codigo(Me.cboOUAPSUPE), String)
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOUAPMUNI.KeyPress, txtOUAPCORR.KeyPress, txtOUAPBARR.KeyPress, txtOUAPMANZ.KeyPress, txtOUAPPRED.KeyPress, txtOUAPMAIN.KeyPress, txtOUAPNUOF.KeyPress, cboOUAPCLSE.KeyPress, txtOUAPEDIF.KeyPress, txtOUAPUNPR.KeyPress, cboOUAPSUPE.KeyPress, cboOUAPESTA.KeyPress, txtOUAPARTE.KeyPress, txtOUAPAVCA.KeyPress, txtOUAPAVCO.KeyPress, txtOUAPVACO.KeyPress, txtOUAPDIRE.KeyPress, cboOUAPCLOU.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboOUIGCLOU_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUAPCLOU.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASOBUR_Descripcion(Me.cboOUAPCLOU, Me.cboOUAPCLOU.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUAPCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboOUAPCLSE, Me.cboOUAPCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboOUAPSUPE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUAPSUPE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboOUAPSUPE, Me.cboOUAPSUPE.SelectedIndex)
        End If
    End Sub
    Private Sub cboOUAPESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUAPESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboOUAPESTA, Me.cboOUAPESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "Click"

    Private Sub cboOUIGCLOU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUAPCLOU.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASOBUR_Descripcion(Me.cboOUAPCLOU, Me.cboOUAPCLOU.SelectedIndex)
    End Sub
    Private Sub cboOBINCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUAPCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboOUAPCLSE, Me.cboOUAPCLSE.SelectedIndex)
    End Sub
    Private Sub cboOUAPSUPE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUAPSUPE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_USUARIO_Descripcion(Me.cboOUAPSUPE, Me.cboOUAPSUPE.SelectedIndex)
    End Sub
    Private Sub cboOUAPESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUAPESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboOUAPESTA, Me.cboOUAPESTA.SelectedIndex)
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUAPMUNI.GotFocus, txtOUAPCORR.GotFocus, txtOUAPBARR.GotFocus, txtOUAPMANZ.GotFocus, txtOUAPPRED.GotFocus, txtOUAPMAIN.GotFocus, txtOUAPNUOF.GotFocus, txtOUAPEDIF.GotFocus, txtOUAPUNPR.GotFocus, txtOUAPARTE.GotFocus, txtOUAPAVCA.GotFocus, txtOUAPAVCO.GotFocus, txtOUAPVACO.GotFocus, txtOUAPDIRE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUAPCLSE.GotFocus, cboOUAPESTA.GotFocus, cboOUAPSUPE.GotFocus, cboOUAPCLOU.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtOUAPMAIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUAPMAIN.Validated, txtOUAPAVCA.Validated, txtOUAPAVCO.Validated, txtOUAPVACO.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        Else
            If Trim(Me.txtOUAPARTE.Text) <> "" Then
                If CInt(Me.txtOUAPARTE.Text) = 0 Then
                    pro_GuardarAtributosDelPredio()
                End If
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUAPAVCA.Text) = True Then
                Me.txtOUAPAVCA.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOUAPAVCA.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUAPAVCO.Text) = True Then
                Me.txtOUAPAVCO.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOUAPAVCO.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUAPVACO.Text) = True Then
                Me.txtOUAPVACO.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOUAPVACO.Text)
            End If

        End If

    End Sub
    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUAPMUNI.Validated
        If Me.txtOUAPMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUAPMUNI.Text) = True Then
            Me.txtOUAPMUNI.Text = fun_Formato_Mascara_3_String(Me.txtOUAPMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUAPCORR.Validated
        If Me.txtOUAPCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUAPCORR.Text) = True Then
            Me.txtOUAPCORR.Text = fun_Formato_Mascara_2_String(Me.txtOUAPCORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUAPBARR.Validated
        If Me.txtOUAPBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUAPBARR.Text) = True Then
            Me.txtOUAPBARR.Text = fun_Formato_Mascara_3_String(Me.txtOUAPBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUAPMANZ.Validated
        If Me.txtOUAPMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUAPMANZ.Text) = True Then
            Me.txtOUAPMANZ.Text = fun_Formato_Mascara_3_String(Me.txtOUAPMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUAPPRED.Validated
        If Me.txtOUAPPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUAPPRED.Text) = True Then
            Me.txtOUAPPRED.Text = fun_Formato_Mascara_5_String(Me.txtOUAPPRED.Text)
        End If
    End Sub
    Private Sub txtOUAPEDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUAPEDIF.Validated
        If Me.txtOUAPEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUAPEDIF.Text) = True Then
            Me.txtOUAPEDIF.Text = fun_Formato_Mascara_3_String(Me.txtOUAPEDIF.Text)
        End If
    End Sub
    Private Sub txtOUAPUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUAPUNPR.Validated
        If Me.txtOUAPUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUAPUNPR.Text) = True Then
            Me.txtOUAPUNPR.Text = fun_Formato_Mascara_5_String(Me.txtOUAPUNPR.Text)
        End If
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