Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_CEESPRED

    '=============================================================
    '*** INSERTAR PREDIOS CERTIFICACION ESTRATO SOCIOECONOMICO ***
    '=============================================================

#Region "VARIABLE"

    Dim inCEPRIDRE As Integer
    Dim inCEPRNURE As Integer
    Dim stCEPRFERE As String
    Dim inCEPRSECU As Integer

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer, ByVal inNURE As Integer, ByVal stFERE As String)
        inCEPRIDRE = inIDRE
        inCEPRSECU = inSECU
        inCEPRNURE = inNURE
        stCEPRFERE = stFERE

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()

    End Sub
    Public Sub New(ByVal inSECU As Integer, ByVal inNURE As Integer, ByVal stFERE As String)
        inCEPRSECU = inSECU
        inCEPRNURE = inNURE
        stCEPRFERE = stFERE

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtCEPRMUNI.Text = "266"
        Me.txtCEPRCORR.Text = "01"
        Me.txtCEPRBARR.Text = ""
        Me.txtCEPRMANZ.Text = ""
        Me.txtCEPRPRED.Text = ""
        Me.txtCEPREDIF.Text = ""
        Me.txtCEPRUNPR.Text = ""
        Me.txtCEPRMAIN.Text = ""
        Me.txtCEPRDIPR.Text = ""
        Me.txtCEPRNUFI.Text = "0"
        Me.txtCEPRARTE.Text = "0"
        Me.txtCEPRVATP.Text = "0"
        Me.txtCEPRVACP.Text = "0"
        Me.txtCEPRAVCA.Text = "0"
        Me.lblCEPRCLSE.Text = ""
        Me.lblCEPRZOPL.Text = ""
        Me.lblCEPRSEPU.Text = ""
        Me.nudCEPRUNID.Value = 0

        Me.cboCEPRCLSE.DataSource = New DataTable
        Me.cboCEPRZOPL.DataSource = New DataTable
        Me.cboCEPRSEPU.DataSource = New DataTable
        Me.cboCEPRESTA.DataSource = New DataTable

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_CEESPRED
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_CEESPRED(inCEPRIDRE)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraCEDUCATA.Text = "MODIFICAR PREDIOS"

                    Me.txtCEPRMAIN.ReadOnly = True

                    Me.txtCEPRMUNI.Text = Trim(tbl.Rows(0).Item("CEPRMUNI"))
                    Me.txtCEPRCORR.Text = Trim(tbl.Rows(0).Item("CEPRCORR"))
                    Me.txtCEPRBARR.Text = Trim(tbl.Rows(0).Item("CEPRBARR"))
                    Me.txtCEPRMANZ.Text = Trim(tbl.Rows(0).Item("CEPRMANZ"))
                    Me.txtCEPRPRED.Text = Trim(tbl.Rows(0).Item("CEPRPRED"))
                    Me.txtCEPREDIF.Text = Trim(tbl.Rows(0).Item("CEPREDIF"))
                    Me.txtCEPRUNPR.Text = Trim(tbl.Rows(0).Item("CEPRUNPR"))

                    Dim objdatos1 As New cla_CLASSECT

                    Me.cboCEPRCLSE.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CLASSECT
                    Me.cboCEPRCLSE.DisplayMember = "CLSEDESC"
                    Me.cboCEPRCLSE.ValueMember = "CLSECODI"

                    Me.cboCEPRCLSE.SelectedValue = tbl.Rows(0).Item("CEPRCLSE")

                    Me.txtCEPRDIPR.Text = Trim(tbl.Rows(0).Item("CEPRDIPR"))
                    Me.nudCEPRUNID.Value = tbl.Rows(0).Item("CEPRUNID")

                    Me.txtCEPRMAIN.Text = Trim(tbl.Rows(0).Item("CEPRMAIN"))
                    Me.txtCEPRNUFI.Text = Trim(tbl.Rows(0).Item("CEPRNUFI"))
                    Me.txtCEPRARTE.Text = Trim(tbl.Rows(0).Item("CEPRARTE"))

                    Me.txtCEPRVATP.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("CEPRVATP")))
                    Me.txtCEPRVACP.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("CEPRVACP")))
                    Me.txtCEPRAVCA.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("CEPRAVCA")))

                    Dim objdatos2 As New cla_ZONAPLAN

                    Me.cboCEPRZOPL.DataSource = objdatos2.fun_Consultar_CAMPOS_MANT_ZONAPLAN
                    Me.cboCEPRZOPL.DisplayMember = "ZOPLDESC"
                    Me.cboCEPRZOPL.ValueMember = "ZOPLCODI"

                    Me.cboCEPRZOPL.SelectedValue = tbl.Rows(0).Item("CEPRZOPL")

                    Dim objdatos4 As New cla_SERVICIOS

                    Me.cboCEPRSEPU.DataSource = objdatos4.fun_Consultar_CAMPOS_MANT_SERVICIOS
                    Me.cboCEPRSEPU.DisplayMember = "SERVDESC"
                    Me.cboCEPRSEPU.ValueMember = "SERVCODI"

                    Me.cboCEPRSEPU.SelectedValue = tbl.Rows(0).Item("CEPRSEPU")
                    Me.chkCEPRPRPH.Checked = tbl.Rows(0).Item("CEPRPRPH")

                    Dim objdatos3 As New cla_ESTADO

                    Me.cboCEPRESTA.DataSource = objdatos3.fun_Consultar_TODOS_LOS_ESTADOS
                    Me.cboCEPRESTA.DisplayMember = "ESTADESC"
                    Me.cboCEPRESTA.ValueMember = "ESTACODI"

                    Me.cboCEPRESTA.SelectedValue = tbl.Rows(0).Item("CEPRESTA")

                    Me.lblCEPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboCEPRCLSE), String)
                    Me.lblCEPRZOPL.Text = CType(fun_Buscar_Lista_Valores_ZONAPLAN_Codigo(Me.cboCEPRZOPL), String)
                    Me.lblCEPRSEPU.Text = CType(fun_Buscar_Lista_Valores_SERVPUBL_Codigo(Me.cboCEPRSEPU), String)

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
            Dim stNroMatricula As String = fun_Formato_Mascara_7_Reales(Trim(Me.txtCEPRMAIN.Text))
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
                    Me.txtCEPRNUFI.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRNUFI").ToString)
                    Me.txtCEPRMUNI.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRMUNI").ToString)
                    Me.txtCEPRCORR.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRCORR").ToString)
                    Me.txtCEPRBARR.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRBARR").ToString)
                    Me.txtCEPRMANZ.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRMANZ").ToString)
                    Me.txtCEPRPRED.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRPRED").ToString)
                    Me.txtCEPREDIF.Text = Trim(dtFICHPRED.Rows(0).Item("FIPREDIF").ToString)
                    Me.txtCEPRUNPR.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRUNPR").ToString)
                    Me.txtCEPRDIPR.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRDIRE").ToString)

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

                        Me.cboCEPRZOPL.DataSource = objdatos11.fun_Consultar_CAMPOS_MANT_ZONAPLAN
                        Me.cboCEPRZOPL.DisplayMember = "ZOPLDESC"
                        Me.cboCEPRZOPL.ValueMember = "ZOPLCODI"

                        Me.cboCEPRZOPL.SelectedValue = dtZOPLBARR.Rows(0).Item("ZPBAZOPL")

                        Me.lblCEPRZOPL.Text = fun_Buscar_Lista_Valores_ZONAPLAN_Codigo(Me.cboCEPRZOPL)

                    End If

                    ' declara la clase
                    Dim objdatos1 As New cla_CLASSECT

                    Me.cboCEPRCLSE.DataSource = objdatos1.fun_Consultar_CAMPOS_MANT_CLASSECT
                    Me.cboCEPRCLSE.DisplayMember = "CLSEDESC"
                    Me.cboCEPRCLSE.ValueMember = "CLSECODI"

                    Me.cboCEPRCLSE.SelectedValue = dtFICHPRED.Rows(0).Item("FIPRCLSE")

                    Me.lblCEPRCLSE.Text = fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboCEPRCLSE)

                    ' area de predio normales
                    If CInt(dtFICHPRED.Rows(0).Item("FIPRCAPR")) = 1 Then
                        Me.txtCEPRARTE.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRARTE").ToString)
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
                            Me.txtCEPRARTE.Text = Trim(dtFICHRESU.Rows(0).Item("FIPRATLO").ToString)
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
                        Me.txtCEPRVATP.Text = fun_Formato_Mascara_Pesos_Enteros(CStr(CDbl(dtHISTAVAL.Rows(0).Item("HIAVVATP")) + CDbl(dtHISTAVAL.Rows(0).Item("HIAVVATC"))))
                        Me.txtCEPRVACP.Text = fun_Formato_Mascara_Pesos_Enteros(CStr(CDbl(dtHISTAVAL.Rows(0).Item("HIAVVACP")) + CDbl(dtHISTAVAL.Rows(0).Item("HIAVVACC"))))
                        Me.txtCEPRAVCA.Text = fun_Formato_Mascara_Pesos_Enteros(CStr(CDbl(dtHISTAVAL.Rows(0).Item("HIAVAVAL"))))
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
                Me.txtCEPRVATP.Text = fun_Quita_Letras(Trim(Me.txtCEPRVATP.Text))
                Me.txtCEPRVACP.Text = fun_Quita_Letras(Trim(Me.txtCEPRVACP.Text))
                Me.txtCEPRAVCA.Text = fun_Quita_Letras(Trim(Me.txtCEPRAVCA.Text))

                ' instancia la clase
                Dim objdatos As New cla_CEESPRED

                Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_CEESPRED(inCEPRNURE, stCEPRFERE, Me.txtCEPRMAIN)

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boCEPRMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRMUNI)
                Dim boCEPRCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRCORR)
                Dim boCEPRBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRBARR)
                Dim boCEPRMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRMANZ)
                Dim boCEPRPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRPRED)
                Dim boCEPREDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPREDIF)
                Dim boCEPRUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRUNPR)
                Dim boCEPRCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCEPRCLSE)
                Dim boCEPRDIPR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCEPRDIPR)
                Dim boCEPRMAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRMAIN)
                Dim boCEPRNUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRNUFI)
                Dim boCEPRARTE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRARTE)
                Dim boCEPRVATP As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRVATP)
                Dim boCEPRVACP As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRVACP)
                Dim boCEPRAVCA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRAVCA)
                Dim boCEPRZOPL As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCEPRZOPL)
                Dim boCEPRSEPU As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCEPRSEPU)
                Dim boCEPRESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCEPRESTA)

                ' verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And _
                   boCEPRMUNI = True And _
                   boCEPRCORR = True And _
                   boCEPRBARR = True And _
                   boCEPRMANZ = True And _
                   boCEPRPRED = True And _
                   boCEPREDIF = True And _
                   boCEPRUNPR = True And _
                   boCEPRCLSE = True And _
                   boCEPRDIPR = True And _
                   boCEPRMAIN = True And _
                   boCEPRZOPL = True And _
                   boCEPRSEPU = True And _
                   boCEPRARTE = True And _
                   boCEPRVATP = True And _
                   boCEPRVACP = True And _
                   boCEPRAVCA = True And _
                   boCEPRESTA = True And _
                   boCEPRNUFI = True Then

                    Dim objdatos22 As New cla_CEESPRED

                    If (objdatos22.fun_Insertar_CEESPRED(inCEPRSECU, _
                                                         inCEPRNURE, _
                                                         stCEPRFERE, _
                                                         Me.txtCEPRMAIN.Text, _
                                                         Me.txtCEPRMUNI.Text, _
                                                         Me.txtCEPRCORR.Text, _
                                                         Me.txtCEPRBARR.Text, _
                                                         Me.txtCEPRMANZ.Text, _
                                                         Me.txtCEPRPRED.Text, _
                                                         Me.txtCEPREDIF.Text, _
                                                         Me.txtCEPRUNPR.Text, _
                                                         Me.cboCEPRCLSE.SelectedValue, _
                                                         Me.txtCEPRDIPR.Text, _
                                                         Me.nudCEPRUNID.Value, _
                                                         Me.txtCEPRNUFI.Text, _
                                                         Me.txtCEPRARTE.Text, _
                                                         Me.txtCEPRVATP.Text, _
                                                         Me.txtCEPRVACP.Text, _
                                                         Me.txtCEPRAVCA.Text, _
                                                         Me.cboCEPRZOPL.SelectedValue, _
                                                         Me.cboCEPRSEPU.SelectedValue, _
                                                         Me.chkCEPRPRPH.Checked, _
                                                         Me.cboCEPRESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtCEPRMAIN.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' quita letras
                Me.txtCEPRVATP.Text = fun_Quita_Letras(Trim(Me.txtCEPRVATP.Text))
                Me.txtCEPRVACP.Text = fun_Quita_Letras(Trim(Me.txtCEPRVACP.Text))
                Me.txtCEPRAVCA.Text = fun_Quita_Letras(Trim(Me.txtCEPRAVCA.Text))

                ' instancia la clase
                Dim objVerifica As New cla_Verificar_Dato

                Dim boCEPRMUNI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRMUNI)
                Dim boCEPRCORR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRCORR)
                Dim boCEPRBARR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRBARR)
                Dim boCEPRMANZ As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRMANZ)
                Dim boCEPRPRED As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRPRED)
                Dim boCEPREDIF As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPREDIF)
                Dim boCEPRUNPR As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRUNPR)
                Dim boCEPRCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCEPRCLSE)
                Dim boCEPRDIPR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.txtCEPRDIPR)
                Dim boCEPRMAIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRMAIN)
                Dim boCEPRNUFI As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRNUFI)
                Dim boCEPRARTE As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRARTE)
                Dim boCEPRVATP As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRVATP)
                Dim boCEPRVACP As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRVACP)
                Dim boCEPRAVCA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtCEPRAVCA)
                Dim boCEPRZOPL As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCEPRZOPL)
                Dim boCEPRSEPU As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCEPRSEPU)
                Dim boCEPRESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCEPRESTA)

                ' verifica los datos del formulario 
                If boCEPRMUNI = True And _
                   boCEPRCORR = True And _
                   boCEPRBARR = True And _
                   boCEPRMANZ = True And _
                   boCEPRPRED = True And _
                   boCEPREDIF = True And _
                   boCEPRUNPR = True And _
                   boCEPRCLSE = True And _
                   boCEPRDIPR = True And _
                   boCEPRMAIN = True And _
                   boCEPRZOPL = True And _
                   boCEPRSEPU = True And _
                   boCEPRARTE = True And _
                   boCEPRVATP = True And _
                   boCEPRVACP = True And _
                   boCEPRAVCA = True And _
                   boCEPRESTA = True And _
                   boCEPRNUFI = True Then

                    Dim objdatos22 As New cla_CEESPRED

                    If (objdatos22.fun_Actualizar_CEESPRED(inCEPRIDRE, _
                                                           inCEPRSECU, _
                                                           inCEPRNURE, _
                                                           stCEPRFERE, _
                                                           Me.txtCEPRMAIN.Text, _
                                                           Me.txtCEPRMUNI.Text, _
                                                           Me.txtCEPRCORR.Text, _
                                                           Me.txtCEPRBARR.Text, _
                                                           Me.txtCEPRMANZ.Text, _
                                                           Me.txtCEPRPRED.Text, _
                                                           Me.txtCEPREDIF.Text, _
                                                           Me.txtCEPRUNPR.Text, _
                                                           Me.cboCEPRCLSE.SelectedValue, _
                                                           Me.txtCEPRDIPR.Text, _
                                                           Me.nudCEPRUNID.Value, _
                                                           Me.txtCEPRNUFI.Text, _
                                                           Me.txtCEPRARTE.Text, _
                                                           Me.txtCEPRVATP.Text, _
                                                           Me.txtCEPRVACP.Text, _
                                                           Me.txtCEPRAVCA.Text, _
                                                           Me.cboCEPRZOPL.SelectedValue, _
                                                           Me.cboCEPRSEPU.SelectedValue, _
                                                           Me.chkCEPRPRPH.Checked, _
                                                           Me.cboCEPRESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.txtCEPRMUNI.Focus()
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
        Me.txtCEPRMUNI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCEPRMUNI.KeyPress, txtCEPRCORR.KeyPress, txtCEPRBARR.KeyPress, txtCEPRMANZ.KeyPress, txtCEPRPRED.KeyPress, txtCEPRMAIN.KeyPress, txtCEPRNUFI.KeyPress, cboCEPRCLSE.KeyPress, txtCEPREDIF.KeyPress, txtCEPRUNPR.KeyPress, cboCEPRZOPL.KeyPress, cboCEPRESTA.KeyPress, txtCEPRARTE.KeyPress, txtCEPRVATP.KeyPress, txtCEPRVACP.KeyPress, txtCEPRAVCA.KeyPress, txtCEPRDIPR.KeyPress, nudCEPRUNID.KeyPress, cboCEPRSEPU.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboOBINCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCEPRCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboCEPRCLSE, Me.cboCEPRCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboCEPRZOPL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCEPRZOPL.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ZONAPLAN_Descripcion(Me.cboCEPRZOPL, Me.cboCEPRZOPL.SelectedIndex)
        End If
    End Sub
    Private Sub cboCEPRSEPU_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCEPRSEPU.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_SERVICOS_Descripcion(Me.cboCEPRSEPU, Me.cboCEPRSEPU.SelectedIndex)
        End If
    End Sub
    Private Sub cboCEPRESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCEPRESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboCEPRESTA, Me.cboCEPRESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboOBINCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCEPRCLSE.SelectedIndexChanged
        Me.lblCEPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboCEPRCLSE), String)
    End Sub
    Private Sub cboCEPRZOPL_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCEPRZOPL.SelectedIndexChanged
        Me.lblCEPRZOPL.Text = CType(fun_Buscar_Lista_Valores_ZONAPLAN_Codigo(Me.cboCEPRZOPL), String)
    End Sub
    Private Sub cboCEPRSEPU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCEPRSEPU.SelectedIndexChanged
        Me.lblCEPRSEPU.Text = CType(fun_Buscar_Lista_Valores_SERVICIOS_Codigo(Me.cboCEPRSEPU), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboOBINCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCEPRCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboCEPRCLSE, Me.cboCEPRCLSE.SelectedIndex)
    End Sub
    Private Sub cboCEPRZOPL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCEPRZOPL.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAPLAN_Descripcion(Me.cboCEPRZOPL, Me.cboCEPRZOPL.SelectedIndex)
    End Sub
    Private Sub cboCEPRSEPU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCEPRSEPU.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_SERVICOS_Descripcion(Me.cboCEPRSEPU, Me.cboCEPRSEPU.SelectedIndex)
    End Sub
    Private Sub cboCEPRESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCEPRESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboCEPRESTA, Me.cboCEPRESTA.SelectedIndex)
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEPRMUNI.GotFocus, txtCEPRCORR.GotFocus, txtCEPRBARR.GotFocus, txtCEPRMANZ.GotFocus, txtCEPRPRED.GotFocus, txtCEPRMAIN.GotFocus, txtCEPRNUFI.GotFocus, txtCEPREDIF.GotFocus, txtCEPRUNPR.GotFocus, txtCEPRARTE.GotFocus, txtCEPRVATP.GotFocus, txtCEPRVACP.GotFocus, txtCEPRAVCA.GotFocus, txtCEPRDIPR.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCEPRCLSE.GotFocus, cboCEPRESTA.GotFocus, cboCEPRZOPL.GotFocus, cboCEPRSEPU.GotFocus, nudCEPRUNID.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtCEPRMAIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEPRMAIN.Validated, txtCEPRNUFI.Validated, txtCEPRARTE.Validated, txtCEPRVATP.Validated, txtCEPRVACP.Validated, txtCEPRAVCA.Validated

        If Trim(sender.text) = "" Then
            sender.text = 0
        Else
            pro_GuardarAtributosDelPredio()

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtCEPRVATP.Text) = True Then
                Me.txtCEPRVATP.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtCEPRVATP.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtCEPRVACP.Text) = True Then
                Me.txtCEPRVACP.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtCEPRVACP.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtCEPRAVCA.Text) = True Then
                Me.txtCEPRAVCA.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtCEPRAVCA.Text)
            End If

        End If

    End Sub
    Private Sub txtTRCAMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEPRMUNI.Validated
        If Me.txtCEPRMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtCEPRMUNI.Text) = True Then
            Me.txtCEPRMUNI.Text = fun_Formato_Mascara_3_String(Me.txtCEPRMUNI.Text)
        End If
    End Sub
    Private Sub txtTRCACORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEPRCORR.Validated
        If Me.txtCEPRCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtCEPRCORR.Text) = True Then
            Me.txtCEPRCORR.Text = fun_Formato_Mascara_2_String(Me.txtCEPRCORR.Text)
        End If
    End Sub
    Private Sub txtTRCABARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEPRBARR.Validated
        If Me.txtCEPRBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtCEPRBARR.Text) = True Then
            Me.txtCEPRBARR.Text = fun_Formato_Mascara_3_String(Me.txtCEPRBARR.Text)
        End If
    End Sub
    Private Sub txtTRCAMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEPRMANZ.Validated
        If Me.txtCEPRMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtCEPRMANZ.Text) = True Then
            Me.txtCEPRMANZ.Text = fun_Formato_Mascara_3_String(Me.txtCEPRMANZ.Text)
        End If
    End Sub
    Private Sub txtTRCAPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEPRPRED.Validated
        If Me.txtCEPRPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtCEPRPRED.Text) = True Then
            Me.txtCEPRPRED.Text = fun_Formato_Mascara_5_String(Me.txtCEPRPRED.Text)
        End If
    End Sub
    Private Sub txtCEPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEPREDIF.Validated
        If Me.txtCEPREDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtCEPREDIF.Text) = True Then
            Me.txtCEPREDIF.Text = fun_Formato_Mascara_3_String(Me.txtCEPREDIF.Text)
        End If
    End Sub
    Private Sub txtCEPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCEPRUNPR.Validated
        If Me.txtCEPRUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtCEPRUNPR.Text) = True Then
            Me.txtCEPRUNPR.Text = fun_Formato_Mascara_5_String(Me.txtCEPRUNPR.Text)
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