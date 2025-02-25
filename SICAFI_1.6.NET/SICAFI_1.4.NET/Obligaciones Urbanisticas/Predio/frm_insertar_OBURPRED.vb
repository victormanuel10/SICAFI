Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_OBURPRED

    '==================================================
    '*** INSERTAR PREDIOS OBLIGACIONES URBANISTICAS ***
    '==================================================

#Region "VARIABLE"

    Dim inOUPRIDRE As Integer
    Dim stOUPRCLEN As String
    Dim inOUPRNURE As Integer
    Dim stOUPRFERE As String
    Dim inOUPRSECU As Integer

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer, ByVal stCLEN As String, ByVal inNURE As Integer, ByVal stFERE As String)
        inOUPRIDRE = inIDRE
        inOUPRSECU = inSECU
        stOUPRCLEN = stCLEN
        inOUPRNURE = inNURE
        stOUPRFERE = stFERE

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inSECU As Integer, ByVal stCLEN As String, ByVal inNURE As Integer, ByVal stFERE As String)
        inOUPRSECU = inSECU
        stOUPRCLEN = stCLEN
        inOUPRNURE = inNURE
        stOUPRFERE = stFERE

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtOUPRMUNI.Text = "266"
        Me.txtOUPRCORR.Text = "01"
        Me.txtOUPRBARR.Text = ""
        Me.txtOUPRMANZ.Text = ""
        Me.txtOUPRPRED.Text = ""
        Me.txtOUPREDIF.Text = ""
        Me.txtOUPRUNPR.Text = ""
        Me.txtOUPRMAIN.Text = ""
        Me.txtOUPRNUFI.Text = "0"
        Me.txtOUPRARTE.Text = "0"
        Me.txtOUPRVATP.Text = "0"
        Me.txtOUPRVACP.Text = "0"
        Me.txtOUPRAVCA.Text = "0"
        Me.lblOUPRCLSE.Text = ""
        Me.lblOUPRZOPL.Text = ""

        Me.cboOUPRCLSE.DataSource = New DataTable
        Me.cboOUPRZOPL.DataSource = New DataTable
        Me.cboOUPRESTA.DataSource = New DataTable

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_OBURPRED
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_OBURPRED(inOUPRIDRE)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraCEDUCATA.Text = "MODIFICAR PREDIOS"

                    Me.txtOUPRMAIN.ReadOnly = True

                    Me.txtOUPRMUNI.Text = Trim(tbl.Rows(0).Item("OUPRMUNI"))
                    Me.txtOUPRCORR.Text = Trim(tbl.Rows(0).Item("OUPRCORR"))
                    Me.txtOUPRBARR.Text = Trim(tbl.Rows(0).Item("OUPRBARR"))
                    Me.txtOUPRMANZ.Text = Trim(tbl.Rows(0).Item("OUPRMANZ"))
                    Me.txtOUPRPRED.Text = Trim(tbl.Rows(0).Item("OUPRPRED"))
                    Me.txtOUPREDIF.Text = Trim(tbl.Rows(0).Item("OUPREDIF"))
                    Me.txtOUPRUNPR.Text = Trim(tbl.Rows(0).Item("OUPRUNPR"))

                    Dim objdatos1 As New cla_CLASSECT

                    Me.cboOUPRCLSE.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CLASSECT
                    Me.cboOUPRCLSE.DisplayMember = "CLSEDESC"
                    Me.cboOUPRCLSE.ValueMember = "CLSECODI"

                    Me.cboOUPRCLSE.SelectedValue = tbl.Rows(0).Item("OUPRCLSE")

                    Me.txtOUPRMAIN.Text = Trim(tbl.Rows(0).Item("OUPRMAIN"))
                    Me.txtOUPRNUFI.Text = Trim(tbl.Rows(0).Item("OUPRNUFI"))
                    Me.txtOUPRARTE.Text = Trim(tbl.Rows(0).Item("OUPRARTE"))
                    Me.txtOUPRVATP.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("OUPRVATP")))
                    Me.txtOUPRVACP.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("OUPRVACP")))
                    Me.txtOUPRAVCA.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("OUPRAVCA")))

                    Dim objdatos2 As New cla_ZONAPLAN

                    Me.cboOUPRZOPL.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_ZONAPLAN
                    Me.cboOUPRZOPL.DisplayMember = "ZOPLDESC"
                    Me.cboOUPRZOPL.ValueMember = "ZOPLCODI"

                    Me.cboOUPRZOPL.SelectedValue = tbl.Rows(0).Item("OUPRZOPL")

                    Dim objdatos3 As New cla_ESTADO

                    Me.cboOUPRESTA.DataSource = objdatos3.fun_Consultar_TODOS_LOS_ESTADOS
                    Me.cboOUPRESTA.DisplayMember = "ESTADESC"
                    Me.cboOUPRESTA.ValueMember = "ESTACODI"

                    Me.cboOUPRESTA.SelectedValue = tbl.Rows(0).Item("OUPRESTA")

                    Me.lblOUPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboOUPRCLSE), String)
                    Me.lblOUPRZOPL.Text = CType(fun_Buscar_Lista_Valores_ZONAPLAN_Codigo(Me.cboOUPRZOPL), String)

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraCEDUCATA.Text = "INSERTAR PREDIOS"

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GuardarAtributosDelPredio()

        Try
            ' declara las variables
            Dim stCiuculoRegistral As String = "001-"
            Dim stNroMatricula As String = fun_Formato_Mascara_7_Reales(Trim(Me.txtOUPRMAIN.Text))
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
                    Me.txtOUPRNUFI.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRNUFI").ToString)
                    Me.txtOUPRMUNI.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRMUNI").ToString)
                    Me.txtOUPRCORR.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRCORR").ToString)
                    Me.txtOUPRBARR.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRBARR").ToString)
                    Me.txtOUPRMANZ.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRMANZ").ToString)
                    Me.txtOUPRPRED.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRPRED").ToString)
                    Me.txtOUPREDIF.Text = Trim(dtFICHPRED.Rows(0).Item("FIPREDIF").ToString)
                    Me.txtOUPRUNPR.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRUNPR").ToString)

                    ' instancia la clase
                    Dim obZOPLBARR As New cla_ZOPLBARR
                    Dim dtZOPLBARR As New DataTable

                    If dtFICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                        dtZOPLBARR = obZOPLBARR.fun_Buscar_CODIGO_X_ZOPLBARR("05", Trim(dtFICHPRED.Rows(0).Item("FIPRMUNI").ToString), dtFICHPRED.Rows(0).Item("FIPRCLSE"), Trim(dtFICHPRED.Rows(0).Item("FIPRCORR").ToString), Trim(dtFICHPRED.Rows(0).Item("FIPRBARR").ToString))

                    ElseIf dtFICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
                        dtZOPLBARR = obZOPLBARR.fun_Buscar_CODIGO_X_ZOPLBARR("05", Trim(dtFICHPRED.Rows(0).Item("FIPRMUNI").ToString), dtFICHPRED.Rows(0).Item("FIPRCLSE"), Trim(dtFICHPRED.Rows(0).Item("FIPRCORR").ToString), Trim(dtFICHPRED.Rows(0).Item("FIPRMANZ").ToString))

                    End If

                    If dtZOPLBARR.Rows.Count > 0 Then

                        Dim objdatos11 As New cla_ZONAPLAN

                        Me.cboOUPRZOPL.DataSource = objdatos11.fun_Consultar_CAMPOS_MANT_ZONAPLAN
                        Me.cboOUPRZOPL.DisplayMember = "ZOPLDESC"
                        Me.cboOUPRZOPL.ValueMember = "ZOPLCODI"

                        Me.cboOUPRZOPL.SelectedValue = dtZOPLBARR.Rows(0).Item("ZPBAZOPL")

                        Me.lblOUPRZOPL.Text = fun_Buscar_Lista_Valores_ZONAPLAN_Codigo(Me.cboOUPRZOPL)

                    End If

                    ' declara la clase
                    Dim objdatos1 As New cla_CLASSECT

                    Me.cboOUPRCLSE.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CLASSECT
                    Me.cboOUPRCLSE.DisplayMember = "CLSEDESC"
                    Me.cboOUPRCLSE.ValueMember = "CLSECODI"

                    Me.cboOUPRCLSE.SelectedValue = dtFICHPRED.Rows(0).Item("FIPRCLSE")

                    Me.lblOUPRCLSE.Text = fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboOUPRCLSE)

                    ' area de predio normales
                    If CInt(dtFICHPRED.Rows(0).Item("FIPRCAPR")) = 1 Then
                        Me.txtOUPRARTE.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRARTE").ToString)
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
                            Me.txtOUPRARTE.Text = Trim(dtFICHRESU.Rows(0).Item("FIPRATLO").ToString)
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
                        Me.txtOUPRVATP.Text = fun_Formato_Mascara_Pesos_Enteros(CStr(CDbl(dtHISTAVAL.Rows(0).Item("HIAVVATP")) + CDbl(dtHISTAVAL.Rows(0).Item("HIAVVATC"))))
                        Me.txtOUPRVACP.Text = fun_Formato_Mascara_Pesos_Enteros(CStr(CDbl(dtHISTAVAL.Rows(0).Item("HIAVVACP")) + CDbl(dtHISTAVAL.Rows(0).Item("HIAVVACC"))))
                        Me.txtOUPRAVCA.Text = fun_Formato_Mascara_Pesos_Enteros(CStr(CDbl(dtHISTAVAL.Rows(0).Item("HIAVAVAL"))))
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
                Me.txtOUPRVATP.Text = fun_Quita_Letras(Trim(Me.txtOUPRVATP.Text))
                Me.txtOUPRVACP.Text = fun_Quita_Letras(Trim(Me.txtOUPRVACP.Text))
                Me.txtOUPRAVCA.Text = fun_Quita_Letras(Trim(Me.txtOUPRAVCA.Text))

                ' instancia la clase
                Dim objdatos As New cla_OBURPRED

                Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_OBURPRED(stOUPRCLEN, inOUPRNURE, stOUPRFERE, Me.txtOUPRMAIN)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boOUPRMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRMUNI)
                Dim boOUPRCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRCORR)
                Dim boOUPRBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRBARR)
                Dim boOUPRMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRMANZ)
                Dim boOUPRPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRPRED)
                Dim boOUPREDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPREDIF)
                Dim boOUPRUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRUNPR)
                Dim boOUPRCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUPRCLSE)
                Dim boOUPRMAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRMAIN)
                Dim boOUPRNUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRNUFI)
                Dim boOUPRARTE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRARTE)
                Dim boOUPRVATP As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRVATP)
                Dim boOUPRVACP As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRVACP)
                Dim boOUPRAVCA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRAVCA)
                Dim boOUPRZOPL As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUPRZOPL)
                Dim boOUPRESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUPRESTA)

                ' verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And _
                   boOUPRMUNI = True And _
                   boOUPRCORR = True And _
                   boOUPRBARR = True And _
                   boOUPRMANZ = True And _
                   boOUPRPRED = True And _
                   boOUPREDIF = True And _
                   boOUPRUNPR = True And _
                   boOUPRCLSE = True And _
                   boOUPRMAIN = True And _
                   boOUPRZOPL = True And _
                   boOUPRARTE = True And _
                   boOUPRVATP = True And _
                   boOUPRVACP = True And _
                   boOUPRAVCA = True And _
                   boOUPRESTA = True And _
                   boOUPRNUFI = True Then

                    Dim objdatos22 As New cla_OBURPRED

                    If (objdatos22.fun_Insertar_OBURPRED(inOUPRSECU, _
                                                         stOUPRCLEN, _
                                                         inOUPRNURE, _
                                                         stOUPRFERE, _
                                                         Me.txtOUPRMAIN.Text, _
                                                         Me.txtOUPRMUNI.Text, _
                                                         Me.txtOUPRCORR.Text, _
                                                         Me.txtOUPRBARR.Text, _
                                                         Me.txtOUPRMANZ.Text, _
                                                         Me.txtOUPRPRED.Text, _
                                                         Me.txtOUPREDIF.Text, _
                                                         Me.txtOUPRUNPR.Text, _
                                                         Me.cboOUPRCLSE.SelectedValue, _
                                                         Me.txtOUPRNUFI.Text, _
                                                         Me.txtOUPRARTE.Text, _
                                                         Me.txtOUPRVATP.Text, _
                                                         Me.txtOUPRVACP.Text, _
                                                         Me.txtOUPRAVCA.Text, _
                                                         Me.cboOUPRZOPL.SelectedValue, _
                                                         Me.cboOUPRESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtOUPRMAIN.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' quita letras
                Me.txtOUPRVATP.Text = fun_Quita_Letras(Trim(Me.txtOUPRVATP.Text))
                Me.txtOUPRVACP.Text = fun_Quita_Letras(Trim(Me.txtOUPRVACP.Text))
                Me.txtOUPRAVCA.Text = fun_Quita_Letras(Trim(Me.txtOUPRAVCA.Text))

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boOUPRMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRMUNI)
                Dim boOUPRCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRCORR)
                Dim boOUPRBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRBARR)
                Dim boOUPRMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRMANZ)
                Dim boOUPRPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRPRED)
                Dim boOUPREDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPREDIF)
                Dim boOUPRUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRUNPR)
                Dim boOUPRCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUPRCLSE)
                Dim boOUPRMAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRMAIN)
                Dim boOUPRNUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRNUFI)
                Dim boOUPRARTE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRARTE)
                Dim boOUPRVATP As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRVATP)
                Dim boOUPRVACP As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRVACP)
                Dim boOUPRAVCA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUPRAVCA)
                Dim boOUPRZOPL As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUPRZOPL)
                Dim boOUPRESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUPRESTA)

                ' verifica los datos del formulario 
                If boOUPRMUNI = True And _
                   boOUPRCORR = True And _
                   boOUPRBARR = True And _
                   boOUPRMANZ = True And _
                   boOUPRPRED = True And _
                   boOUPREDIF = True And _
                   boOUPRUNPR = True And _
                   boOUPRCLSE = True And _
                   boOUPRMAIN = True And _
                   boOUPRZOPL = True And _
                   boOUPRARTE = True And _
                   boOUPRVATP = True And _
                   boOUPRVACP = True And _
                   boOUPRAVCA = True And _
                   boOUPRESTA = True And _
                   boOUPRNUFI = True Then

                    Dim objdatos22 As New cla_OBURPRED

                    If (objdatos22.fun_Actualizar_OBURPRED(inOUPRIDRE, _
                                                           inOUPRSECU, _
                                                           stOUPRCLEN, _
                                                           inOUPRNURE, _
                                                           stOUPRFERE, _
                                                           Me.txtOUPRMAIN.Text, _
                                                           Me.txtOUPRMUNI.Text, _
                                                           Me.txtOUPRCORR.Text, _
                                                           Me.txtOUPRBARR.Text, _
                                                           Me.txtOUPRMANZ.Text, _
                                                           Me.txtOUPRPRED.Text, _
                                                           Me.txtOUPREDIF.Text, _
                                                           Me.txtOUPRUNPR.Text, _
                                                           Me.cboOUPRCLSE.SelectedValue, _
                                                           Me.txtOUPRNUFI.Text, _
                                                           Me.txtOUPRARTE.Text, _
                                                           Me.txtOUPRVATP.Text, _
                                                           Me.txtOUPRVACP.Text, _
                                                           Me.txtOUPRAVCA.Text, _
                                                           Me.cboOUPRZOPL.SelectedValue, _
                                                           Me.cboOUPRESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtOUPRMUNI.Focus()
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
        Me.txtOUPRMUNI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOUPRMUNI.KeyPress, txtOUPRCORR.KeyPress, txtOUPRBARR.KeyPress, txtOUPRMANZ.KeyPress, txtOUPRPRED.KeyPress, txtOUPRMAIN.KeyPress, txtOUPRNUFI.KeyPress, cboOUPRCLSE.KeyPress, txtOUPREDIF.KeyPress, txtOUPRUNPR.KeyPress, cboOUPRZOPL.KeyPress, cboOUPRESTA.KeyPress, txtOUPRARTE.KeyPress, txtOUPRVATP.KeyPress, txtOUPRVACP.KeyPress, txtOUPRAVCA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboOBINCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUPRCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboOUPRCLSE, Me.cboOUPRCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboOUPRZOPL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUPRZOPL.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ZONAPLAN_Descripcion(Me.cboOUPRZOPL, Me.cboOUPRZOPL.SelectedIndex)
        End If
    End Sub
    Private Sub cboOUPRESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUPRESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboOUPRESTA, Me.cboOUPRESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboOBINCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOUPRCLSE.SelectedIndexChanged
        Me.lblOUPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboOUPRCLSE), String)
    End Sub
    Private Sub cboOUPRZOPL_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOUPRZOPL.SelectedIndexChanged
        Me.lblOUPRZOPL.Text = CType(fun_Buscar_Lista_Valores_ZONAPLAN_Codigo(Me.cboOUPRZOPL), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboOBINCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUPRCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboOUPRCLSE, Me.cboOUPRCLSE.SelectedIndex)
    End Sub
    Private Sub cboOUPRZOPL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUPRZOPL.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAPLAN_Descripcion(Me.cboOUPRZOPL, Me.cboOUPRZOPL.SelectedIndex)
    End Sub
    Private Sub cboOUPRESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUPRESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboOUPRESTA, Me.cboOUPRESTA.SelectedIndex)
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUPRMUNI.GotFocus, txtOUPRCORR.GotFocus, txtOUPRBARR.GotFocus, txtOUPRMANZ.GotFocus, txtOUPRPRED.GotFocus, txtOUPRMAIN.GotFocus, txtOUPRNUFI.GotFocus, txtOUPREDIF.GotFocus, txtOUPRUNPR.GotFocus, txtOUPRARTE.GotFocus, txtOUPRVATP.GotFocus, txtOUPRVACP.GotFocus, txtOUPRAVCA.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUPRCLSE.GotFocus, cboOUPRESTA.GotFocus, cboOUPRZOPL.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtOUPRMAIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUPRMAIN.Validated, txtOUPRNUFI.Validated, txtOUPRARTE.Validated, txtOUPRVATP.Validated, txtOUPRVACP.Validated, txtOUPRAVCA.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        Else
            pro_GuardarAtributosDelPredio()

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUPRVATP.Text) = True Then
                Me.txtOUPRVATP.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOUPRVATP.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUPRVACP.Text) = True Then
                Me.txtOUPRVACP.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOUPRVACP.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUPRAVCA.Text) = True Then
                Me.txtOUPRAVCA.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOUPRAVCA.Text)
            End If

        End If

    End Sub
    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUPRMUNI.Validated
        If Me.txtOUPRMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUPRMUNI.Text) = True Then
            Me.txtOUPRMUNI.Text = fun_Formato_Mascara_3_String(Me.txtOUPRMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUPRCORR.Validated
        If Me.txtOUPRCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUPRCORR.Text) = True Then
            Me.txtOUPRCORR.Text = fun_Formato_Mascara_2_String(Me.txtOUPRCORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUPRBARR.Validated
        If Me.txtOUPRBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUPRBARR.Text) = True Then
            Me.txtOUPRBARR.Text = fun_Formato_Mascara_3_String(Me.txtOUPRBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUPRMANZ.Validated
        If Me.txtOUPRMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUPRMANZ.Text) = True Then
            Me.txtOUPRMANZ.Text = fun_Formato_Mascara_3_String(Me.txtOUPRMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUPRPRED.Validated
        If Me.txtOUPRPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUPRPRED.Text) = True Then
            Me.txtOUPRPRED.Text = fun_Formato_Mascara_5_String(Me.txtOUPRPRED.Text)
        End If
    End Sub
    Private Sub txtOUPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUPREDIF.Validated
        If Me.txtOUPREDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUPREDIF.Text) = True Then
            Me.txtOUPREDIF.Text = fun_Formato_Mascara_3_String(Me.txtOUPREDIF.Text)
        End If
    End Sub
    Private Sub txtOUPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUPRUNPR.Validated
        If Me.txtOUPRUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUPRUNPR.Text) = True Then
            Me.txtOUPRUNPR.Text = fun_Formato_Mascara_5_String(Me.txtOUPRUNPR.Text)
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