Imports REGLAS_DEL_NEGOCIO

Public Class frm_insertar_OBURINGE

    '==============================================================
    '*** INSERTAR INFORMACION GENERAL OBLIGACIONES URBANISTICAS ***
    '==============================================================

#Region "VARIABLE"

    Dim inOUIGIDRE As Integer
    Dim stOUIGCLEN As String
    Dim inOUIGNURE As Integer
    Dim stOUIGFERE As String
    Dim inOUIGSECU As Integer

    Dim boINSERTAR As Boolean = False
    Dim boMODIFICAR As Boolean = False

    Dim vl_inTotalAreaTerreno As Integer = 0
    Dim vl_loTotalAvaluoCatastral As Long = 0
    Dim vl_loTotalAvaluoTerreno As Long = 0
    Dim vl_doDensidad As Double = 0.0
    Dim vl_loSalarioMinimo As Long = 0
    Dim vl_loTotalAvaluoComercial As Long = 0
    Dim vl_loTotalAvaluoComercialM2 As Long = 0

#End Region

#Region "CONSTRUCTOR"

    Public Sub New(ByVal inIDRE As Integer, ByVal inSECU As Integer, ByVal stCLEN As String, ByVal inNURE As Integer, ByVal stFERE As String)
        inOUIGIDRE = inIDRE
        inOUIGSECU = inSECU
        stOUIGCLEN = stCLEN
        inOUIGNURE = inNURE
        stOUIGFERE = stFERE

        boMODIFICAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
        pro_ConsultarAtributosDelPredio()
        fun_ValidacionPorClaseDeObligacion()

    End Sub
    Public Sub New(ByVal inSECU As Integer, ByVal stCLEN As String, ByVal inNURE As Integer, ByVal stFERE As String)
        inOUIGSECU = inSECU
        stOUIGCLEN = stCLEN
        inOUIGNURE = inNURE
        stOUIGFERE = stFERE

        boINSERTAR = True

        InitializeComponent()
        pro_LimpiarCampos()
        pro_inicializarControles()
        pro_ConsultarAtributosDelPredio()

    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtOUIGATLO.Text = ""
        Me.txtOUIGATCO.Text = ""
        Me.txtOUIGDENS.Text = ""
        Me.txtOUIGUNID.Text = ""
        Me.txtOUIGSMLV.Text = ""
        Me.txtOUIGAVCA.Text = ""
        Me.txtOUIGAVCO.Text = ""
        Me.txtOUIGLIQU.Text = ""

        Me.lblOUIGCLOU.Text = ""
        Me.lblOUIGTILI.Text = ""
        Me.lblOUIGCLSE.Text = ""
        Me.lblOUIGESSO.Text = ""
        Me.lblOUIGTIPO.Text = ""

        Me.cboOUIGCLOU.DataSource = New DataTable
        Me.cboOUIGTILI.DataSource = New DataTable
        Me.cboOUIGCLSE.DataSource = New DataTable
        Me.cboOUIGESSO.DataSource = New DataTable
        Me.cboOUIGTIPO.DataSource = New DataTable
        Me.cboOUIGESTA.DataSource = New DataTable

    End Sub
    Private Sub pro_inicializarControles()

        Try
            If boMODIFICAR = True Then

                ' instancia la clase
                Dim objdatos As New cla_OBURINGE
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_OBURINGE(inOUIGIDRE)

                If tbl.Rows.Count > 0 Then

                    Me.Text = "Modificar registro"
                    Me.fraCEDUCATA.Text = "MODIFICAR INFORMACIÓN GENERAL"

                    Me.cboOUIGCLOU.Enabled = False
                    Me.cboOUIGCLSE.Enabled = False
                    Me.cboOUIGESSO.Enabled = False
                    Me.cboOUIGTIPO.Enabled = False

                    Dim objdatos11 As New cla_CLASOBUR

                    Me.cboOUIGCLOU.DataSource = objdatos11.fun_Consultar_CAMPOS_MANT_CLASOBUR
                    Me.cboOUIGCLOU.DisplayMember = "CLOUDESC"
                    Me.cboOUIGCLOU.ValueMember = "CLOUCODI"

                    Me.cboOUIGCLOU.SelectedValue = tbl.Rows(0).Item("OUIGCLOU")

                    Me.txtOUIGNULI.Text = Trim(tbl.Rows(0).Item("OUIGNULI"))

                    Dim objdatos12 As New cla_TIPOLIQU

                    Me.cboOUIGTILI.DataSource = objdatos12.fun_Consultar_CAMPOS_MANT_TIPOLIQU
                    Me.cboOUIGTILI.DisplayMember = "TILIDESC"
                    Me.cboOUIGTILI.ValueMember = "TILICODI"

                    Me.cboOUIGTILI.SelectedValue = tbl.Rows(0).Item("OUIGTILI")

                    Dim objdatos13 As New cla_CLASSECT

                    Me.cboOUIGCLSE.DataSource = objdatos13.fun_Consultar_CAMPOS_MANT_CLASSECT
                    Me.cboOUIGCLSE.DisplayMember = "CLSEDESC"
                    Me.cboOUIGCLSE.ValueMember = "CLSECODI"

                    Me.cboOUIGCLSE.SelectedValue = tbl.Rows(0).Item("OUIGCLSE")

                    Me.txtOUIGATLO.Text = Trim(tbl.Rows(0).Item("OUIGATLO"))
                    Me.txtOUIGATCO.Text = Trim(tbl.Rows(0).Item("OUIGATCO"))
                    Me.txtOUIGDENS.Text = Trim(tbl.Rows(0).Item("OUIGDENS"))
                    Me.txtOUIGUNID.Text = Trim(tbl.Rows(0).Item("OUIGUNID"))
                    Me.txtOUIGSMLV.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("OUIGSMLV")))

                    Dim objdatos14 As New cla_ESTRATO

                    Me.cboOUIGESSO.DataSource = objdatos14.fun_Consultar_CAMPOS_MANT_ESTRATO
                    Me.cboOUIGESSO.DisplayMember = "ESTRDESC"
                    Me.cboOUIGESSO.ValueMember = "ESTRCODI"

                    Me.cboOUIGESSO.SelectedValue = tbl.Rows(0).Item("OUIGESSO")

                    Dim objdatos15 As New cla_TIPOCALI

                    Me.cboOUIGTIPO.DataSource = objdatos15.fun_Consultar_CAMPOS_MANT_TIPOCALI
                    Me.cboOUIGTIPO.DisplayMember = "TICADESC"
                    Me.cboOUIGTIPO.ValueMember = "TICACODI"

                    Me.cboOUIGTIPO.SelectedValue = tbl.Rows(0).Item("OUIGTIPO")

                    Me.txtOUIGAVCA.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("OUIGAVCA")))
                    Me.txtOUIGAVCO.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("OUIGAVCO")))
                    Me.txtOUIGLIQU.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(tbl.Rows(0).Item("OUIGLIQU")))
                    Me.txtOUIGOBSE.Text = Trim(tbl.Rows(0).Item("OUIGOBSE"))
                    Me.chkOUIGPLPA.Checked = CBool(tbl.Rows(0).Item("OUIGPLPA"))
                    Me.chkOUIGADLI.Checked = CBool(tbl.Rows(0).Item("OUIGADLI"))

                    Dim objdatos3 As New cla_ESTADO

                    Me.cboOUIGESTA.DataSource = objdatos3.fun_Consultar_TODOS_LOS_ESTADOS
                    Me.cboOUIGESTA.DisplayMember = "ESTADESC"
                    Me.cboOUIGESTA.ValueMember = "ESTACODI"

                    Me.cboOUIGESTA.SelectedValue = tbl.Rows(0).Item("OUIGESTA")

                    Me.lblOUIGCLOU.Text = CType(fun_Buscar_Lista_Valores_CLASOBUR_Codigo(Me.cboOUIGCLOU), String)
                    Me.lblOUIGTILI.Text = CType(fun_Buscar_Lista_Valores_TIPOLIQU_Codigo(Me.cboOUIGTILI), String)
                    Me.lblOUIGTIPO.Text = CType(fun_Buscar_Lista_Valores_TIPOCALI_Codigo(Me.cboOUIGTIPO), String)
                    Me.lblOUIGCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboOUIGCLSE), String)
                    Me.lblOUIGESSO.Text = CType(fun_Buscar_Lista_Valores_ESTRATO_Codigo(Me.cboOUIGESSO), String)

                End If

            ElseIf boINSERTAR = True Then

                Me.Text = "Insertar registro"
                Me.fraCEDUCATA.Text = "INSERTAR INFORMACIÓN GENERAL"

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ConsultarAtributosDelPredio()

        Try
            ' consulta sumatoria de area de terreno y avaluo catastral
            Dim obOBURPRED1 As New cla_OBURPRED
            Dim dtOBURPRED1 As New DataTable

            dtOBURPRED1 = obOBURPRED1.fun_Buscar_CODIGO_X_OBURPRED(stOUIGCLEN, inOUIGNURE, stOUIGFERE)

            If dtOBURPRED1.Rows.Count > 0 Then

                ' declara la variable
                Dim inTotalAreaTerreno As Integer = 0
                Dim loTotalAvaluoCatastral As Long = 0
                Dim loTotalAvaluoTerreno As Long = 0

                Dim i As Integer = 0

                For i = 0 To dtOBURPRED1.Rows.Count - 1

                    inTotalAreaTerreno += CInt(dtOBURPRED1.Rows(i).Item("OUPRARTE"))
                    loTotalAvaluoCatastral += CLng(dtOBURPRED1.Rows(i).Item("OUPRAVCA"))
                    loTotalAvaluoTerreno += CLng(dtOBURPRED1.Rows(i).Item("OUPRVATP"))

                Next

                ' almacena el resultado
                vl_inTotalAreaTerreno = inTotalAreaTerreno
                vl_loTotalAvaluoCatastral = loTotalAvaluoCatastral
                vl_loTotalAvaluoTerreno = loTotalAvaluoTerreno

            End If

            ' consulta la densidad
            Dim obOBURPRED2 As New cla_OBURPRED
            Dim dtOBURPRED2 As New DataTable

            dtOBURPRED2 = obOBURPRED2.fun_Buscar_CODIGO_X_OBURPRED(stOUIGCLEN, inOUIGNURE, stOUIGFERE)

            If dtOBURPRED2.Rows.Count > 0 Then

                ' declara la variable
                Dim doDensidad As Double = 0.0

                Dim i As Integer = 0

                For i = 0 To dtOBURPRED2.Rows.Count - 1

                    ' declara la variable
                    Dim stOUPRMUNI As String = fun_Formato_Mascara_3_String(CStr(Trim(dtOBURPRED2.Rows(i).Item("OUPRMUNI").ToString)))
                    Dim stOUPRCORR As String = fun_Formato_Mascara_3_String(CStr(Trim(dtOBURPRED2.Rows(i).Item("OUPRCORR").ToString)))
                    Dim stOUPRBARR As String = fun_Formato_Mascara_3_String(CStr(Trim(dtOBURPRED2.Rows(i).Item("OUPRBARR").ToString)))
                    Dim stOUPRMANZ As String = fun_Formato_Mascara_4_String(CStr(Trim(dtOBURPRED2.Rows(i).Item("OUPRMANZ").ToString)))
                    Dim stOUPRPRED As String = fun_Formato_Mascara_5_String(CStr(Trim(dtOBURPRED2.Rows(i).Item("OUPRPRED").ToString)))
                    Dim inOUPRCLSE As Integer = CInt(dtOBURPRED2.Rows(i).Item("OUPRCLSE"))

                    ' declara la variable
                    Dim stCEDUCATA As String = Trim(stOUPRMUNI) & inOUPRCLSE & Trim(stOUPRCORR) & Trim(stOUPRBARR) & Trim(stOUPRMANZ) & Trim(stOUPRPRED)

                    ' declara la instancia
                    Dim obDENSIDAD As New cla_DENSIDAD
                    Dim dtDENSIDAD As New DataTable

                    dtDENSIDAD = obDENSIDAD.fun_Buscar_CODIGO_DENSIDAD(CStr(stCEDUCATA))

                    If dtDENSIDAD.Rows.Count > 0 Then
                        doDensidad = CDbl(dtDENSIDAD.Rows(0).Item("DENSDENS"))
                    End If

                    ' compara la densidad mayor
                    If doDensidad > vl_doDensidad Then
                        vl_doDensidad = doDensidad
                    End If

                Next

            End If

            ' consulta el salario mensual legal vigente
            Dim obVIGEACTU As New cla_PERIACTU
            Dim dtVIGEACTU As New DataTable

            dtVIGEACTU = obVIGEACTU.fun_Consultar_VIGENCIA_ACTUAL_X_MANT_PERIACTU()

            If dtVIGEACTU.Rows.Count > 0 Then

                Dim obSALAMINI As New cla_SALAMINI
                Dim dtSALAMINI As New DataTable

                dtSALAMINI = obSALAMINI.fun_Buscar_CODIGO_SALAMINI(dtVIGEACTU.Rows(0).Item("PEACCODI"))

                If dtSALAMINI.Rows.Count > 0 Then
                    vl_loSalarioMinimo = CLng(dtSALAMINI.Rows(0).Item("SAMISAMI"))
                End If

            End If

            ' consulta avaluo comercial
            Dim obOBURAVCO3 As New cla_OBURAVCO
            Dim dtOBURAVCO3 As New DataTable

            dtOBURAVCO3 = obOBURAVCO3.fun_Buscar_CODIGO_X_OBURAVCO(stOUIGCLEN, inOUIGNURE, stOUIGFERE)

            If dtOBURAVCO3.Rows.Count > 0 Then

                ' declara la variable
                Dim loTotalAvaluoComercial As Long = 0
                Dim loTotalAvaluoComercialM2 As Long = 0

                Dim i As Integer = 0

                For i = 0 To dtOBURAVCO3.Rows.Count - 1

                    loTotalAvaluoComercial += CLng(dtOBURAVCO3.Rows(i).Item("OUACAVCO"))
                    loTotalAvaluoComercialM2 += CLng(dtOBURAVCO3.Rows(i).Item("OUACACM2"))

                Next

                ' almacena el resultado
                vl_loTotalAvaluoComercial = loTotalAvaluoComercial
                vl_loTotalAvaluoComercialM2 = loTotalAvaluoComercialM2

            End If

            ' registra el resultado
            If Trim(Me.txtOUIGATLO.Text) <> "0" Or Trim(Me.txtOUIGATLO.Text) <> "" Then
                Me.txtOUIGATLO.Text = vl_inTotalAreaTerreno
            End If
            If Trim(Me.txtOUIGAVCA.Text) <> "0" Then
                Me.txtOUIGAVCA.Text = fun_Formato_Mascara_Pesos_Enteros(vl_loTotalAvaluoTerreno)
            End If
            If Trim(Me.txtOUIGDENS.Text) = "0" Or Trim(Me.txtOUIGDENS.Text) = "" Then
                Me.txtOUIGDENS.Text = vl_doDensidad
            End If
            If Trim(Me.txtOUIGSMLV.Text) <> "0" Then
                Me.txtOUIGSMLV.Text = fun_Formato_Mascara_Pesos_Enteros(vl_loSalarioMinimo)
            End If
            If Trim(Me.txtOUIGAVCO.Text) <> "0" Then
                Me.txtOUIGAVCO.Text = fun_Formato_Mascara_Pesos_Enteros(vl_loTotalAvaluoComercialM2)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_NumeroDeSecuenciaDeRegistro() As Integer

        Try
            Dim inOBURSECU As Integer = 0

            Dim objdatos5 As New cla_OBURINGE
            Dim tbl10 As New DataTable

            tbl10 = objdatos5.fun_Buscar_SECUENCIA_X_OBURINGE(inOUIGSECU, stOUIGCLEN, inOUIGNURE, stOUIGFERE, Me.cboOUIGCLOU.SelectedValue)

            If tbl10.Rows.Count = 0 Then
                inOBURSECU = 1
            Else
                Dim i As Integer
                Dim NroMayor As Integer
                Dim Posicion As Integer

                Posicion = Val(tbl10.Rows(0).Item("OUIGNULI"))

                For i = 0 To tbl10.Rows.Count - 1
                    NroMayor = Val(tbl10.Rows(i).Item("OUIGNULI"))

                    If NroMayor > Posicion Then
                        inOBURSECU = NroMayor
                        Posicion = NroMayor
                    Else
                        inOBURSECU = Posicion
                    End If
                Next

                inOBURSECU += 1
            End If

            Return inOBURSECU

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ValidacionPorClaseDeObligacion() As Boolean

        Try
            Dim boVALIDACION As Boolean = False

            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boOUIGCLOU As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUIGCLOU)
            Dim boOUIGCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUIGCLSE)
            Dim boOUIGESSO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUIGESSO)
            Dim boOUIGTIPO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUIGTIPO)
            Dim boOUIGTILI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUIGTILI)
            Dim boOUIGESTA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboOUIGESTA)

            ' valida los datos principales
            If boOUIGCLOU = True And _
               boOUIGCLSE = True And _
               boOUIGESSO = True And _
               boOUIGTIPO = True And _
               boOUIGTILI = True And _
               boOUIGESTA = True Then

                ' quita letras
                Me.txtOUIGSMLV.Text = fun_Quita_Letras(Trim(Me.txtOUIGSMLV.Text))
                Me.txtOUIGAVCA.Text = fun_Quita_Letras(Trim(Me.txtOUIGAVCA.Text))
                Me.txtOUIGAVCO.Text = fun_Quita_Letras(Trim(Me.txtOUIGAVCO.Text))
                Me.txtOUIGLIQU.Text = fun_Quita_Letras(Trim(Me.txtOUIGLIQU.Text))
                Me.txtOUIGATLO.Text = fun_Quita_Letras(Trim(Me.txtOUIGATLO.Text))
                Me.txtOUIGATCO.Text = fun_Quita_Letras(Trim(Me.txtOUIGATCO.Text))

                ' genera la secuencia
                If boOUIGCLOU = True And boINSERTAR = True Then
                    Me.txtOUIGNULI.Text = fun_NumeroDeSecuenciaDeRegistro()
                End If

                ' Valida Cesion Equipamiento Residencial Urbano
                If Me.cboOUIGCLOU.SelectedValue = 1 And _
                   Me.cboOUIGCLSE.SelectedValue = 1 And _
                   Me.cboOUIGTIPO.SelectedValue = "R" Then

                    If boINSERTAR = True Then

                        ' asigna propiedades
                        Me.txtOUIGATLO.Text = "0"
                        Me.txtOUIGDENS.Text = "0"
                        Me.txtOUIGAVCA.Text = "0"
                        Me.txtOUIGAVCO.Text = "0"
                        Me.txtOUIGLIQU.Text = "0"

                    End If

                    ' aplica plan parcial
                    If Me.chkOUIGPLPA.Checked = False Then
                        Me.txtOUIGATLO.Enabled = False
                    Else
                        Me.txtOUIGATLO.Enabled = True
                    End If

                    Me.txtOUIGDENS.Enabled = False
                    Me.txtOUIGAVCA.Enabled = False
                    Me.txtOUIGAVCO.Enabled = False
                    Me.txtOUIGLIQU.Enabled = False

                    ' declara la variable
                    Dim boOUIGATCO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGATCO)
                    Dim boOUIGSMLV As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGSMLV)
                    Dim boOUIGUNID As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGUNID)

                    ' valida los datos
                    If boOUIGATCO = True And _
                       boOUIGSMLV = True And _
                       boOUIGUNID = True Then

                        ' retorna la variable
                        boVALIDACION = True

                    End If

                    ' Valida Cesion Equipamiento Otros Usos Urbano
                ElseIf Me.cboOUIGCLOU.SelectedValue = 1 And _
                       Me.cboOUIGCLSE.SelectedValue = 1 And _
                       Me.cboOUIGTIPO.SelectedValue = "U" Then

                    If boINSERTAR = True Then

                        ' asigna propiedades
                        Me.txtOUIGATLO.Text = "0"
                        Me.txtOUIGDENS.Text = "0"
                        Me.txtOUIGAVCA.Text = "0"
                        Me.txtOUIGAVCO.Text = "0"
                        Me.txtOUIGLIQU.Text = "0"

                    End If

                    ' aplica plan parcial
                    If Me.chkOUIGPLPA.Checked = False Then
                        Me.txtOUIGATLO.Enabled = False
                    Else
                        Me.txtOUIGATLO.Enabled = True
                    End If

                    Me.txtOUIGDENS.Enabled = False
                    Me.txtOUIGAVCA.Enabled = False
                    Me.txtOUIGAVCO.Enabled = False
                    Me.txtOUIGLIQU.Enabled = False

                    ' declara la variable
                    Dim boOUIGATCO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGATCO)
                    Dim boOUIGSMLV As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGSMLV)
                    Dim boOUIGUNID As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGUNID)

                    ' valida los datos
                    If boOUIGATCO = True And _
                       boOUIGSMLV = True And _
                       boOUIGUNID = True Then

                        ' retorna la variable
                        boVALIDACION = True

                    End If

                    ' Valida Cesion Espacio Publico Residencial Urbano
                ElseIf Me.cboOUIGCLOU.SelectedValue = 2 And _
                       Me.cboOUIGCLSE.SelectedValue = 1 And _
                       Me.cboOUIGTIPO.SelectedValue = "R" Then

                    If boINSERTAR = True Then

                        ' asigna propiedades
                        Me.txtOUIGLIQU.Text = "0"

                    End If

                    Me.txtOUIGLIQU.Enabled = False

                    ' declara la variable
                    Dim boOUIGUNID As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGUNID)
                    Dim boOUIGDENS As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtOUIGDENS)
                    Dim boOUIGATLO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGATLO)
                    Dim boOUIGATCO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGATCO)
                    Dim boOUIGAVCO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGAVCO)

                    ' valida los datos
                    If boOUIGUNID = True And _
                       boOUIGDENS = True And _
                       boOUIGATLO = True And _
                       boOUIGATCO = True And _
                       boOUIGAVCO = True Then

                        ' retorna la variable
                        boVALIDACION = True

                    End If

                    ' Valida Cesion Espacio Publico Otros Usos Urbano
                ElseIf Me.cboOUIGCLOU.SelectedValue = 2 And _
                       Me.cboOUIGCLSE.SelectedValue = 1 And _
                       Me.cboOUIGTIPO.SelectedValue = "U" Then

                    If boINSERTAR = True Then

                        ' asigna propiedades
                        Me.txtOUIGSMLV.Text = "0"
                        Me.txtOUIGLIQU.Text = "0"

                    End If

                    Me.txtOUIGSMLV.Enabled = False
                    Me.txtOUIGLIQU.Enabled = False

                    ' declara la variable
                    Dim boOUIGUNID As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGUNID)
                    Dim boOUIGATLO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGATLO)
                    Dim boOUIGATCO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGATCO)
                    Dim boOUIGAVCO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGAVCO)
                    Dim boOUIGAVCA As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGAVCA)
                    Dim boOUIGDENS As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Decimal(Me.txtOUIGDENS)

                    ' valida los datos
                    If boOUIGATLO = True And _
                       boOUIGATCO = True And _
                       boOUIGAVCO = True And _
                       boOUIGAVCA = True And _
                       boOUIGDENS = True And _
                       boOUIGUNID = True Then

                        ' retorna la variable
                        boVALIDACION = True

                    End If

                    ' Valida Cesion Equipamiento Residencial Rural
                ElseIf Me.cboOUIGCLOU.SelectedValue = 1 And _
                       Me.cboOUIGCLSE.SelectedValue = 2 And _
                       Me.cboOUIGTIPO.SelectedValue = "R" Then

                    If boINSERTAR = True Then

                        ' asigna propiedades
                        Me.txtOUIGATLO.Text = "0"
                        Me.txtOUIGATCO.Text = "0"
                        Me.txtOUIGDENS.Text = "0"
                        Me.txtOUIGAVCA.Text = "0"
                        Me.txtOUIGAVCO.Text = "0"
                        Me.txtOUIGLIQU.Text = "0"

                    End If

                    Me.txtOUIGATLO.Enabled = False
                    Me.txtOUIGATCO.Enabled = False
                    Me.txtOUIGDENS.Enabled = False
                    Me.txtOUIGAVCA.Enabled = False
                    Me.txtOUIGAVCO.Enabled = False
                    Me.txtOUIGLIQU.Enabled = False

                    ' declara la variable
                    Dim boOUIGSMLV As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGSMLV)
                    Dim boOUIGUNID As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGUNID)

                    ' valida los datos
                    If boOUIGSMLV = True And _
                       boOUIGUNID = True Then

                        ' retorna la variable
                        boVALIDACION = True

                    End If

                    ' Valida Liquida Cesion Equipamiento Otros Usos Rural
                ElseIf Me.cboOUIGCLOU.SelectedValue = 1 And _
                       Me.cboOUIGCLSE.SelectedValue = 2 And _
                       Me.cboOUIGTIPO.SelectedValue = "U" Then

                    If boINSERTAR = True Then

                        ' asigna propiedades
                        Me.txtOUIGATLO.Text = "0"
                        Me.txtOUIGDENS.Text = "0"
                        Me.txtOUIGUNID.Text = "0"
                        Me.txtOUIGAVCA.Text = "0"
                        Me.txtOUIGAVCO.Text = "0"
                        Me.txtOUIGLIQU.Text = "0"

                    End If

                    Me.txtOUIGATLO.Enabled = False
                    Me.txtOUIGDENS.Enabled = False
                    Me.txtOUIGUNID.Enabled = False
                    Me.txtOUIGAVCA.Enabled = False
                    Me.txtOUIGAVCO.Enabled = False
                    Me.txtOUIGLIQU.Enabled = False

                    ' declara la variable
                    Dim boOUIGSMLV As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGSMLV)
                    Dim boOUIGATCO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGATCO)

                    ' valida los datos
                    If boOUIGSMLV = True And _
                       boOUIGATCO = True Then

                        ' retorna la variable
                        boVALIDACION = True

                    End If

                    ' Valida Cesion Espacio Publico Residencial Rural
                ElseIf Me.cboOUIGCLOU.SelectedValue = 2 And _
                       Me.cboOUIGCLSE.SelectedValue = 2 And _
                       Me.cboOUIGTIPO.SelectedValue = "R" Then

                    If boINSERTAR = True Then

                        ' asigna propiedades
                        Me.txtOUIGATCO.Text = "0"
                        Me.txtOUIGDENS.Text = "0"
                        Me.txtOUIGUNID.Text = "0"
                        Me.txtOUIGSMLV.Text = "0"
                        Me.txtOUIGAVCA.Text = "0"
                        Me.txtOUIGLIQU.Text = "0"

                    End If

                    Me.txtOUIGATCO.Enabled = False
                    Me.txtOUIGDENS.Enabled = False
                    Me.txtOUIGUNID.Enabled = False
                    Me.txtOUIGSMLV.Enabled = False
                    Me.txtOUIGAVCA.Enabled = False
                    Me.txtOUIGLIQU.Enabled = False

                    ' declara la variable
                    Dim boOUIGATCO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGATCO)
                    Dim boOUIGAVCO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGAVCO)

                    ' valida los datos
                    If boOUIGATCO = True And _
                       boOUIGAVCO = True Then

                        ' retorna la variable
                        boVALIDACION = True

                    End If

                    ' Valida Cesion Espacio Publico Otros Usos Rural
                ElseIf Me.cboOUIGCLOU.SelectedValue = 2 And _
                       Me.cboOUIGCLSE.SelectedValue = 2 And _
                       Me.cboOUIGTIPO.SelectedValue = "U" Then

                    If boINSERTAR = True Then

                        ' asigna propiedades
                        Me.txtOUIGATCO.Text = "0"
                        Me.txtOUIGDENS.Text = "0"
                        Me.txtOUIGUNID.Text = "0"
                        Me.txtOUIGSMLV.Text = "0"
                        Me.txtOUIGAVCA.Text = "0"
                        Me.txtOUIGLIQU.Text = "0"

                    End If

                    Me.txtOUIGATCO.Enabled = False
                    Me.txtOUIGDENS.Enabled = False
                    Me.txtOUIGUNID.Enabled = False
                    Me.txtOUIGSMLV.Enabled = False
                    Me.txtOUIGAVCA.Enabled = False
                    Me.txtOUIGLIQU.Enabled = False

                    ' declara la variable
                    Dim boOUIGATCO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGATCO)
                    Dim boOUIGAVCO As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGAVCO)

                    ' valida los datos
                    If boOUIGATCO = True And _
                       boOUIGAVCO = True Then

                        ' retorna la variable
                        boVALIDACION = True

                    End If

                    ' Valida Densidad Adicinal
                ElseIf Me.cboOUIGCLOU.SelectedValue = 5 And _
                       Me.cboOUIGCLSE.SelectedValue = 1 And _
                      (Me.cboOUIGTIPO.SelectedValue = "R" Or _
                       Me.cboOUIGTIPO.SelectedValue = "U") Then

                    If boINSERTAR = True Then

                        ' asigna propiedades
                        Me.txtOUIGATLO.Text = "0"
                        Me.txtOUIGATCO.Text = "0"
                        Me.txtOUIGSMLV.Text = "0"
                        Me.txtOUIGAVCA.Text = "0"
                        Me.txtOUIGLIQU.Text = "0"

                    End If

                    Me.txtOUIGATLO.Enabled = False
                    Me.txtOUIGATCO.Enabled = False
                    Me.txtOUIGSMLV.Enabled = False
                    Me.txtOUIGAVCA.Enabled = False
                    Me.txtOUIGLIQU.Enabled = False

                    ' declara la variable
                    Dim boOUIGAVM2 As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGAVCO)
                    Dim boOUIGUNID As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGUNID)
                    Dim boOUIGDENS As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGDENS)

                    ' valida los datos
                    If boOUIGAVM2 = True And _
                        boOUIGUNID = True And _
                        boOUIGDENS = True Then

                        ' retorna la variable
                        boVALIDACION = True

                    End If

                    ' Valida compensacion
                ElseIf Me.cboOUIGCLOU.SelectedValue = 6 And _
                       Me.cboOUIGCLSE.SelectedValue = 1 And _
                      (Me.cboOUIGTIPO.SelectedValue = "R" Or _
                       Me.cboOUIGTIPO.SelectedValue = "U") Then

                    If boINSERTAR = True Then

                        ' asigna propiedades
                        Me.txtOUIGATLO.Text = "0"
                        Me.txtOUIGATCO.Text = "0"
                        Me.txtOUIGDENS.Text = "0"
                        Me.txtOUIGAVCO.Text = "0"
                        Me.txtOUIGAVCA.Text = "0"
                        Me.txtOUIGLIQU.Text = "0"

                    End If

                    Me.txtOUIGATLO.Enabled = False
                    Me.txtOUIGATCO.Enabled = False
                    Me.txtOUIGDENS.Enabled = False
                    Me.txtOUIGAVCO.Enabled = False
                    Me.txtOUIGAVCA.Enabled = False
                    Me.txtOUIGLIQU.Enabled = False

                    ' declara la variable
                    Dim boOUIGSMLV As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGSMLV)
                    Dim boOUIGUNID As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtOUIGUNID)

                    ' valida los datos
                    If boOUIGSMLV = True And _
                        boOUIGUNID = True Then

                        ' retorna la variable
                        boVALIDACION = True

                    End If

                Else
                    ' retorna la variable
                    boVALIDACION = False
                End If

                ' asigna formato
                If Trim(Me.txtOUIGSMLV.Text) <> "0" And Trim(Me.txtOUIGSMLV.Text) <> "" Then
                    Me.txtOUIGSMLV.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(Me.txtOUIGSMLV.Text))
                End If
                If Trim(Me.txtOUIGAVCA.Text) <> "0" And Trim(Me.txtOUIGAVCA.Text) <> "" Then
                    Me.txtOUIGAVCA.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(Me.txtOUIGAVCA.Text))
                End If
                If Trim(Me.txtOUIGAVCO.Text) <> "0" And Trim(Me.txtOUIGAVCO.Text) <> "" Then
                    Me.txtOUIGAVCO.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(Me.txtOUIGAVCO.Text))
                End If
                If Trim(Me.txtOUIGLIQU.Text) <> "0" And Trim(Me.txtOUIGLIQU.Text) <> "" Then
                    Me.txtOUIGLIQU.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(Me.txtOUIGLIQU.Text))
                End If
                If Trim(Me.txtOUIGATLO.Text) <> "0" And Trim(Me.txtOUIGATLO.Text) <> "" Then
                    Me.txtOUIGATLO.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(Me.txtOUIGATLO.Text))
                End If
                If Trim(Me.txtOUIGATCO.Text) <> "0" And Trim(Me.txtOUIGATCO.Text) <> "" Then
                    Me.txtOUIGATCO.Text = fun_Formato_Mascara_Pesos_Enteros(Trim(Me.txtOUIGATCO.Text))
                End If

            End If

            ' retorna la variable
            Return boVALIDACION

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Function

#End Region

#Region "MENU"

    Private Sub cmdGUARDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.Click

        Try
            ' inserta el registro
            If boINSERTAR = True Then

                ' quita letras
                Me.txtOUIGSMLV.Text = fun_Quita_Letras(Trim(Me.txtOUIGSMLV.Text))
                Me.txtOUIGAVCA.Text = fun_Quita_Letras(Trim(Me.txtOUIGAVCA.Text))
                Me.txtOUIGAVCO.Text = fun_Quita_Letras(Trim(Me.txtOUIGAVCO.Text))
                Me.txtOUIGLIQU.Text = fun_Quita_Letras(Trim(Me.txtOUIGLIQU.Text))
                Me.txtOUIGATLO.Text = fun_Quita_Letras(Trim(Me.txtOUIGATLO.Text))
                Me.txtOUIGATCO.Text = fun_Quita_Letras(Trim(Me.txtOUIGATCO.Text))

                ' instancia la clase
                Dim objdatos As New cla_OBURINGE

                Dim boLLAVEPRIMARIA As Boolean = objdatos.fun_Verifica_llave_Primaria_OBURINGE(stOUIGCLEN, inOUIGNURE, stOUIGFERE, Me.cboOUIGCLOU, Me.txtOUIGNULI)

                ' verifica los datos del formulario 
                If boLLAVEPRIMARIA = True And fun_ValidacionPorClaseDeObligacion() = True Then

                    Dim objdatos22 As New cla_OBURINGE

                    If (objdatos22.fun_Insertar_OBURINGE(inOUIGSECU, _
                                                         stOUIGCLEN, _
                                                         inOUIGNURE, _
                                                         stOUIGFERE, _
                                                         Me.cboOUIGCLOU.SelectedValue, _
                                                         Me.txtOUIGNULI.Text, _
                                                         Me.cboOUIGTILI.SelectedValue, _
                                                         Me.cboOUIGCLSE.SelectedValue, _
                                                         Me.txtOUIGATLO.Text, _
                                                         Me.txtOUIGATCO.Text, _
                                                         Me.txtOUIGDENS.Text, _
                                                         Me.txtOUIGUNID.Text, _
                                                         Me.txtOUIGSMLV.Text, _
                                                         Me.cboOUIGESSO.SelectedValue, _
                                                         Me.cboOUIGTIPO.SelectedValue, _
                                                         Me.txtOUIGAVCA.Text, _
                                                         Me.txtOUIGAVCO.Text, _
                                                         Me.txtOUIGLIQU.Text, _
                                                         Me.chkOUIGPLPA.Checked, _
                                                         Me.chkOUIGADLI.Checked, _
                                                         Me.txtOUIGOBSE.Text, _
                                                         Me.cboOUIGESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboOUIGCLOU.Focus()
                        Me.Close()
                    Else
                        mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
                    End If

                End If

                ' modifica el registro
            ElseIf boMODIFICAR = True Then

                ' quita letras
                Me.txtOUIGSMLV.Text = fun_Quita_Letras(Trim(Me.txtOUIGSMLV.Text))
                Me.txtOUIGAVCA.Text = fun_Quita_Letras(Trim(Me.txtOUIGAVCA.Text))
                Me.txtOUIGAVCO.Text = fun_Quita_Letras(Trim(Me.txtOUIGAVCO.Text))
                Me.txtOUIGLIQU.Text = fun_Quita_Letras(Trim(Me.txtOUIGLIQU.Text))
                Me.txtOUIGATLO.Text = fun_Quita_Letras(Trim(Me.txtOUIGATLO.Text))
                Me.txtOUIGATCO.Text = fun_Quita_Letras(Trim(Me.txtOUIGATCO.Text))

                ' verifica los datos del formulario 
                If fun_ValidacionPorClaseDeObligacion() = True Then

                    Dim objdatos22 As New cla_OBURINGE

                    If (objdatos22.fun_Actualizar_OBURINGE(inOUIGIDRE, _
                                                           inOUIGSECU, _
                                                           stOUIGCLEN, _
                                                           inOUIGNURE, _
                                                           stOUIGFERE, _
                                                           Me.cboOUIGCLOU.SelectedValue, _
                                                           Me.txtOUIGNULI.Text, _
                                                           Me.cboOUIGTILI.SelectedValue, _
                                                           Me.cboOUIGCLSE.SelectedValue, _
                                                           Me.txtOUIGATLO.Text, _
                                                           Me.txtOUIGATCO.Text, _
                                                           Me.txtOUIGDENS.Text, _
                                                           Me.txtOUIGUNID.Text, _
                                                           Me.txtOUIGSMLV.Text, _
                                                           Me.cboOUIGESSO.SelectedValue, _
                                                           Me.cboOUIGTIPO.SelectedValue, _
                                                           Me.txtOUIGAVCA.Text, _
                                                           Me.txtOUIGAVCO.Text, _
                                                           Me.txtOUIGLIQU.Text, _
                                                           Me.chkOUIGPLPA.Checked, _
                                                           Me.chkOUIGADLI.Checked, _
                                                           Me.txtOUIGOBSE.Text, _
                                                           Me.cboOUIGESTA.SelectedValue)) = True Then

                        mod_MENSAJE.Se_Guardaron_Los_Datos_Correctamente()
                        Me.cboOUIGCLOU.Focus()
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
        Me.txtOUIGDENS.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOUIGDENS.KeyPress, txtOUIGUNID.KeyPress, txtOUIGSMLV.KeyPress, txtOUIGATLO.KeyPress, cboOUIGCLSE.KeyPress, cboOUIGCLOU.KeyPress, cboOUIGESTA.KeyPress, txtOUIGATCO.KeyPress, txtOUIGAVCA.KeyPress, txtOUIGAVCO.KeyPress, txtOUIGLIQU.KeyPress, cboOUIGESSO.KeyPress, cboOUIGTIPO.KeyPress, cboOUIGTILI.KeyPress, txtOUIGOBSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboOUIGCLOU_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUIGCLOU.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASOBUR_Descripcion(Me.cboOUIGCLOU, Me.cboOUIGCLOU.SelectedIndex)
        End If
    End Sub
    Private Sub cboOUIGTILI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUIGTILI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOLIQU_Descripcion(Me.cboOUIGTILI, Me.cboOUIGTILI.SelectedIndex)
        End If
    End Sub
    Private Sub cboOBINCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUIGCLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboOUIGCLSE, Me.cboOUIGCLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboOUIGESSO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUIGESSO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboOUIGESSO, Me.cboOUIGESSO.SelectedIndex)
        End If
    End Sub
    Private Sub cboOUIGTIPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUIGTIPO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboOUIGTIPO, Me.cboOUIGTIPO.SelectedIndex)
        End If
    End Sub
    Private Sub cboOUIGESTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboOUIGESTA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboOUIGESTA, Me.cboOUIGESTA.SelectedIndex)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboOUIGCLOU_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOUIGCLOU.SelectedIndexChanged
        Me.lblOUIGCLOU.Text = CType(fun_Buscar_Lista_Valores_CLASOBUR_Codigo(Me.cboOUIGCLOU), String)
    End Sub
    Private Sub cboOUIGTILI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOUIGTILI.SelectedIndexChanged
        Me.lblOUIGTILI.Text = CType(fun_Buscar_Lista_Valores_TIPOLIQU_Codigo(Me.cboOUIGTILI), String)
    End Sub
    Private Sub cboOBINCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOUIGCLSE.SelectedIndexChanged
        Me.lblOUIGCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboOUIGCLSE), String)
    End Sub
    Private Sub cboOUIGESSO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOUIGESSO.SelectedIndexChanged
        Me.lblOUIGESSO.Text = CType(fun_Buscar_Lista_Valores_ESTRATO_Codigo(Me.cboOUIGESSO), String)
    End Sub
    Private Sub cboOUIGTIPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOUIGTIPO.SelectedIndexChanged
        Me.lblOUIGTIPO.Text = CType(fun_Buscar_Lista_Valores_TIPOCALI_Codigo(Me.cboOUIGTIPO), String)
    End Sub

#End Region

#Region "Click"

    Private Sub cboOUIGCLOU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUIGCLOU.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASOBUR_Descripcion(Me.cboOUIGCLOU, Me.cboOUIGCLOU.SelectedIndex)
    End Sub
    Private Sub cboOBINCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUIGCLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboOUIGCLSE, Me.cboOUIGCLSE.SelectedIndex)
    End Sub
    Private Sub cboOUIGTILI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUIGTILI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOLIQU_Descripcion(Me.cboOUIGTILI, Me.cboOUIGTILI.SelectedIndex)
    End Sub
    Private Sub cboOUIGESSO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUIGESSO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboOUIGESSO, Me.cboOUIGESSO.SelectedIndex)
    End Sub
    Private Sub cboOUIGTIPO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUIGTIPO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboOUIGTIPO, Me.cboOUIGTIPO.SelectedIndex)
    End Sub
    Private Sub cboOUIGESTA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUIGESTA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTADO_Descripcion(Me.cboOUIGESTA, Me.cboOUIGESTA.SelectedIndex)
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUIGDENS.GotFocus, txtOUIGUNID.GotFocus, txtOUIGSMLV.GotFocus, txtOUIGATLO.GotFocus, txtOUIGATCO.GotFocus, txtOUIGAVCA.GotFocus, txtOUIGAVCO.GotFocus, txtOUIGLIQU.GotFocus, txtOUIGOBSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGUARDAR.GotFocus, cmdSALIR.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOUIGCLSE.GotFocus, cboOUIGESTA.GotFocus, cboOUIGCLOU.GotFocus, cboOUIGESSO.GotFocus, cboOUIGTILI.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtOUIGAVCA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOUIGAVCA.Validated, txtOUIGAVCO.Validated, txtOUIGLIQU.Validated, txtOUIGSMLV.Validated, txtOUIGATCO.Validated, txtOUIGATLO.Validated

        If Trim(sender.text) = "" Then
            sender.text = ""
        Else

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUIGSMLV.Text) = True Then
                Me.txtOUIGSMLV.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOUIGSMLV.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUIGAVCA.Text) = True Then
                Me.txtOUIGAVCA.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOUIGAVCA.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUIGAVCO.Text) = True Then
                Me.txtOUIGAVCO.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOUIGAVCO.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUIGLIQU.Text) = True Then
                Me.txtOUIGLIQU.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOUIGLIQU.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUIGATLO.Text) = True Then
                Me.txtOUIGATLO.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOUIGATLO.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtOUIGATCO.Text) = True Then
                Me.txtOUIGATCO.Text = fun_Formato_Mascara_Pesos_Enteros(Me.txtOUIGATCO.Text)
            End If

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

#Region "CheckedChanged"

    Private Sub chkOUIGPLPA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOUIGPLPA.CheckedChanged

        Try
            ' verifica la condicion
            If Me.chkOUIGPLPA.Checked = True Then
                Me.txtOUIGATCO.Enabled = True
            End If

            ' verifica la condicion
            If Me.chkOUIGPLPA.Checked = False Then
                Me.txtOUIGATCO.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#End Region

End Class