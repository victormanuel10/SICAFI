Imports REGLAS_DEL_NEGOCIO

Public Class frm_consultar_RESOCONS

    '===========================================
    '*** CONSULTA RESOLUCION DE CONSERVACION ***
    '===========================================

#Region "VARIABLES"

    Dim boCONSULTA As Boolean = False
    Dim inID_REGISTRO As Integer

    Dim dt As DataTable

#End Region

#Region "CONSTRUCTOR"

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal inInRegistro As Integer)
        inID_REGISTRO = inInRegistro

        InitializeComponent()
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_ReconsultarResolucionDeConservacion()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de los campos
            Dim stRECONURE As String = ""
            Dim stRECOFERE As String = ""
            Dim stRECONURA As String = ""
            Dim stRECOFERA As String = ""
            Dim stRECODESC As String = ""

            ' carga los campos
            If Trim(Me.txtRECONURE.Text) = "" Then
                stRECONURE = "%"
            Else
                stRECONURE = Trim(Me.txtRECONURE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECOFERE.Text) = "" Then
                stRECOFERE = "%"
            Else
                stRECOFERE = Trim(Me.txtRECOFERE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECONURA.Text) = "" Then
                stRECONURA = "%"
            Else
                stRECONURA = Trim(Me.txtRECONURA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECOFERA.Text) = "" Then
                stRECOFERA = "%"
            Else
                stRECOFERA = Trim(Me.txtRECOFERA.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRECODESC.Text) = "" Then
                stRECODESC = "%"
            Else
                stRECODESC = Trim(Me.txtRECODESC.Text)
            End If

            ' crea la variable de consulta
            Dim stConsultaSQL As String = ""

            'concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "RECOIDRE, "
            stConsultaSQL += "RECONURE as 'Nro. Resolución', "
            stConsultaSQL += "RECOFERE as 'Fecha de resolución', "
            stConsultaSQL += "CLSEDESC as 'Sector', "
            stConsultaSQL += "RECONURA as 'Nro. Radicado OVC', "
            stConsultaSQL += "RECOFERA as 'Fecha de radicado OVC', "
            stConsultaSQL += "RECOVIRE as 'Vigencia resolución', "
            stConsultaSQL += "RECOVIFI as 'Vigencia fiscal', "
            stConsultaSQL += "RECODESC as 'Descripción', "
            stConsultaSQL += "RECOFEIN as 'Fecha de ingreso', "
            stConsultaSQL += "ESTADESC as 'Estado' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOCONS, MANT_CLASSECT, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECOCLSE = CLSECODI AND "
            stConsultaSQL += "RECOESTA = ESTACODI AND "
            stConsultaSQL += "RECONURE LIKE '" & stRECONURE & "' AND "
            stConsultaSQL += "RECOFERE LIKE '" & stRECOFERE & "' AND "
            stConsultaSQL += "RECONURA LIKE '" & stRECONURA & "' AND "
            stConsultaSQL += "RECOFERA LIKE '" & stRECOFERA & "' AND "
            stConsultaSQL += "RECODESC LIKE '" & stRECODESC & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RECONURE, RECOFERE "


            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

            Me.dgvCONSULTA_RESOCONS.DataSource = dt

            Me.dgvCONSULTA_RESOCONS.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA_RESOCONS.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptarResolucionConservacion.Enabled = False
                Me.txtRECONURE.Focus()
            Else
                Me.cmdAceptarResolucionConservacion.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count
         

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarResolucionDeConservacionPredioRetirados()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de los campos
            Dim stRCPRMUNI As String = ""
            Dim stRCPRCORR As String = ""
            Dim stRCPRBARR As String = ""
            Dim stRCPRMANZ As String = ""
            Dim stRCPRPRED As String = ""
            Dim stRCPREDIF As String = ""
            Dim stRCPRUNPR As String = ""
            Dim stRCPRCLSE As String = ""
            Dim stRCPRNUFI As String = ""
            Dim stRCPRMAIN As String = ""

            ' carga los campos
            If Trim(Me.txtRCPRMUNI.Text) = "" Then
                stRCPRMUNI = "%"
            Else
                stRCPRMUNI = Trim(Me.txtRCPRMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPRCORR.Text) = "" Then
                stRCPRCORR = "%"
            Else
                stRCPRCORR = Trim(Me.txtRCPRCORR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPRBARR.Text) = "" Then
                stRCPRBARR = "%"
            Else
                stRCPRBARR = Trim(Me.txtRCPRBARR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPRMANZ.Text) = "" Then
                stRCPRMANZ = "%"
            Else
                stRCPRMANZ = Trim(Me.txtRCPRMANZ.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPRPRED.Text) = "" Then
                stRCPRPRED = "%"
            Else
                stRCPRPRED = Trim(Me.txtRCPRPRED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPREDIF.Text) = "" Then
                stRCPREDIF = "%"
            Else
                stRCPREDIF = Trim(Me.txtRCPREDIF.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPRUNPR.Text) = "" Then
                stRCPRUNPR = "%"
            Else
                stRCPRUNPR = Trim(Me.txtRCPRUNPR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPRCLSE.Text) = "" Then
                stRCPRCLSE = "%"
            Else
                stRCPRCLSE = Trim(Me.txtRCPRCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPRNUFI.Text) = "" Then
                stRCPRNUFI = "%"
            Else
                stRCPRNUFI = Trim(Me.txtRCPRNUFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPRMAIN.Text) = "" Then
                stRCPRMAIN = "%"
            Else
                stRCPRMAIN = Trim(Me.txtRCPRMAIN.Text)
            End If

            ' crea la variable de consulta
            Dim stConsultaSQL As String = ""

            'concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "RECOIDRE, "
            stConsultaSQL += "RCPRNURE as 'Nro. Resolución', "
            stConsultaSQL += "RCPRFERE as 'Fecha de resolución', "
            stConsultaSQL += "RCPRMUNI as 'Municipio', "
            stConsultaSQL += "RCPRCORR as 'Corregi.', "
            stConsultaSQL += "RCPRBARR as 'Barrio', "
            stConsultaSQL += "RCPRMANZ as 'Manzana - Vereda', "
            stConsultaSQL += "RCPRPRED as 'Predio', "
            stConsultaSQL += "RCPREDIF as 'Edificio', "
            stConsultaSQL += "RCPRUNPR as 'Unidad predial', "
            stConsultaSQL += "CLSEDESC as 'Sector', "
            stConsultaSQL += "RCPRNUFI as 'Nro. Ficha predial', "
            stConsultaSQL += "RCPRMAIN as 'Matricula inmobiliria' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOCONS, RECOPRRE, MANT_CLASSECT "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "RECONURE = RCPRNURE AND "
            stConsultaSQL += "RECOFERE = RCPRFERE AND "
            stConsultaSQL += "RECOSECU = RCPRSECU AND "

            stConsultaSQL += "RCPRCLSE = CLSECODI AND "

            stConsultaSQL += "RCPRMUNI LIKE '" & stRCPRMUNI & "' AND "
            stConsultaSQL += "RCPRCORR LIKE '" & stRCPRCORR & "' AND "
            stConsultaSQL += "RCPRBARR LIKE '" & stRCPRBARR & "' AND "
            stConsultaSQL += "RCPRMANZ LIKE '" & stRCPRMANZ & "' AND "
            stConsultaSQL += "RCPRPRED LIKE '" & stRCPRPRED & "' AND "
            stConsultaSQL += "RCPREDIF LIKE '" & stRCPREDIF & "' AND "
            stConsultaSQL += "RCPRUNPR LIKE '" & stRCPRUNPR & "' AND "
            stConsultaSQL += "RCPRCLSE LIKE '" & stRCPRCLSE & "' AND "
            stConsultaSQL += "RCPRNUFI LIKE '" & stRCPRNUFI & "' AND "
            stConsultaSQL += "RCPRMAIN LIKE '%" & stRCPRMAIN & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RECONURE, RECOFERE "


            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

            Me.dgvCONSULTA_RECOPRRE.DataSource = dt

            Me.dgvCONSULTA_RECOPRRE.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA_RECOPRRE.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()

                Me.cmdAceptarPredioRetirado.Enabled = False
                Me.txtRECONURE.Focus()

                Me.strBARRESTA.Items(2).Text = "Registros : " & "0"
            Else
                Me.cmdAceptarPredioRetirado.Enabled = True

                Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarResolucionDeConservacionPredioSegregado()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de los campos
            Dim stRCPSMUNI As String = ""
            Dim stRCPSCORR As String = ""
            Dim stRCPSBARR As String = ""
            Dim stRCPSMANZ As String = ""
            Dim stRCPSPRED As String = ""
            Dim stRCPSEDIF As String = ""
            Dim stRCPSUNPR As String = ""
            Dim stRCPSCLSE As String = ""
            Dim stRCPSNUFI As String = ""
            Dim stRCPSMAIN As String = ""

            ' carga los campos
            If Trim(Me.txtRCPSMUNI.Text) = "" Then
                stRCPSMUNI = "%"
            Else
                stRCPSMUNI = Trim(Me.txtRCPSMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPSCORR.Text) = "" Then
                stRCPSCORR = "%"
            Else
                stRCPSCORR = Trim(Me.txtRCPSCORR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPSBARR.Text) = "" Then
                stRCPSBARR = "%"
            Else
                stRCPSBARR = Trim(Me.txtRCPSBARR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPSMANZ.Text) = "" Then
                stRCPSMANZ = "%"
            Else
                stRCPSMANZ = Trim(Me.txtRCPSMANZ.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPSPRED.Text) = "" Then
                stRCPSPRED = "%"
            Else
                stRCPSPRED = Trim(Me.txtRCPSPRED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPSEDIF.Text) = "" Then
                stRCPSEDIF = "%"
            Else
                stRCPSEDIF = Trim(Me.txtRCPSEDIF.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPSUNPR.Text) = "" Then
                stRCPSUNPR = "%"
            Else
                stRCPSUNPR = Trim(Me.txtRCPSUNPR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPSCLSE.Text) = "" Then
                stRCPSCLSE = "%"
            Else
                stRCPSCLSE = Trim(Me.txtRCPSCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPSNUFI.Text) = "" Then
                stRCPSNUFI = "%"
            Else
                stRCPSNUFI = Trim(Me.txtRCPSNUFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPSMAIN.Text) = "" Then
                stRCPSMAIN = "%"
            Else
                stRCPSMAIN = Trim(Me.txtRCPSMAIN.Text)
            End If

            ' crea la variable de consulta
            Dim stConsultaSQL As String = ""

            'concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "RECOIDRE, "
            stConsultaSQL += "RCPSNURE as 'Nro. Resolución', "
            stConsultaSQL += "RCPSFERE as 'Fecha de resolución', "
            stConsultaSQL += "RCPSMUNI as 'Municipio', "
            stConsultaSQL += "RCPSCORR as 'Corregi.', "
            stConsultaSQL += "RCPSBARR as 'Barrio', "
            stConsultaSQL += "RCPSMANZ as 'Manzana - Vereda', "
            stConsultaSQL += "RCPSPRED as 'Predio', "
            stConsultaSQL += "RCPSEDIF as 'Edificio', "
            stConsultaSQL += "RCPSUNPR as 'Unidad predial', "
            stConsultaSQL += "CLSEDESC as 'Sector', "
            stConsultaSQL += "RCPSNUFI as 'Nro. Ficha predial', "
            stConsultaSQL += "RCPSMAIN as 'Matricula inmobiliria' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOCONS, RECOPRSE, MANT_CLASSECT "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "RECONURE = RCPSNURE AND "
            stConsultaSQL += "RECOFERE = RCPSFERE AND "
            stConsultaSQL += "RECOSECU = RCPSSECU AND "

            stConsultaSQL += "RCPSCLSE = CLSECODI AND "

            stConsultaSQL += "RCPSMUNI LIKE '" & stRCPSMUNI & "' AND "
            stConsultaSQL += "RCPSCORR LIKE '" & stRCPSCORR & "' AND "
            stConsultaSQL += "RCPSBARR LIKE '" & stRCPSBARR & "' AND "
            stConsultaSQL += "RCPSMANZ LIKE '" & stRCPSMANZ & "' AND "
            stConsultaSQL += "RCPSPRED LIKE '" & stRCPSPRED & "' AND "
            stConsultaSQL += "RCPSEDIF LIKE '" & stRCPSEDIF & "' AND "
            stConsultaSQL += "RCPSUNPR LIKE '" & stRCPSUNPR & "' AND "
            stConsultaSQL += "RCPSCLSE LIKE '" & stRCPSCLSE & "' AND "
            stConsultaSQL += "RCPSNUFI LIKE '" & stRCPSNUFI & "' AND "
            stConsultaSQL += "RCPSMAIN LIKE '%" & stRCPSMAIN & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RECONURE, RECOFERE "


            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

            Me.dgvCONSULTA_RECOPRSE.DataSource = dt

            Me.dgvCONSULTA_RECOPRSE.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA_RECOPRSE.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()

                Me.cmdAceptarPredioSegregado.Enabled = False
                Me.txtRECONURE.Focus()

                Me.strBARRESTA.Items(2).Text = "Registros : " & "0"
            Else
                Me.cmdAceptarPredioSegregado.Enabled = True

                Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarResolucionDeConservacionPredioModificado()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de los campos
            Dim stRCPMMUNI As String = ""
            Dim stRCPMCORR As String = ""
            Dim stRCPMBARR As String = ""
            Dim stRCPMMANZ As String = ""
            Dim stRCPMPRED As String = ""
            Dim stRCPMEDIF As String = ""
            Dim stRCPMUNPR As String = ""
            Dim stRCPMCLSE As String = ""
            Dim stRCPMNUFI As String = ""
            Dim stRCPMMAIN As String = ""

            ' carga los campos
            If Trim(Me.txtRCPMMUNI.Text) = "" Then
                stRCPMMUNI = "%"
            Else
                stRCPMMUNI = Trim(Me.txtRCPMMUNI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPMCORR.Text) = "" Then
                stRCPMCORR = "%"
            Else
                stRCPMCORR = Trim(Me.txtRCPMCORR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPMBARR.Text) = "" Then
                stRCPMBARR = "%"
            Else
                stRCPMBARR = Trim(Me.txtRCPMBARR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPMMANZ.Text) = "" Then
                stRCPMMANZ = "%"
            Else
                stRCPMMANZ = Trim(Me.txtRCPMMANZ.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPMPRED.Text) = "" Then
                stRCPMPRED = "%"
            Else
                stRCPMPRED = Trim(Me.txtRCPMPRED.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPMEDIF.Text) = "" Then
                stRCPMEDIF = "%"
            Else
                stRCPMEDIF = Trim(Me.txtRCPMEDIF.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPMUNPR.Text) = "" Then
                stRCPMUNPR = "%"
            Else
                stRCPMUNPR = Trim(Me.txtRCPMUNPR.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPMCLSE.Text) = "" Then
                stRCPMCLSE = "%"
            Else
                stRCPMCLSE = Trim(Me.txtRCPMCLSE.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPMNUFI.Text) = "" Then
                stRCPMNUFI = "%"
            Else
                stRCPMNUFI = Trim(Me.txtRCPMNUFI.Text)
            End If

            ' carga los campos
            If Trim(Me.txtRCPMMAIN.Text) = "" Then
                stRCPMMAIN = "%"
            Else
                stRCPMMAIN = Trim(Me.txtRCPMMAIN.Text)
            End If

            ' crea la variable de consulta
            Dim stConsultaSQL As String = ""

            'concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "RECOIDRE, "
            stConsultaSQL += "RCPMNURE as 'Nro. Resolución', "
            stConsultaSQL += "RCPMFERE as 'Fecha de resolución', "
            stConsultaSQL += "RCPMMUNI as 'Municipio', "
            stConsultaSQL += "RCPMCORR as 'Corregi.', "
            stConsultaSQL += "RCPMBARR as 'Barrio', "
            stConsultaSQL += "RCPMMANZ as 'Manzana - Vereda', "
            stConsultaSQL += "RCPMPRED as 'Predio', "
            stConsultaSQL += "RCPMEDIF as 'Edificio', "
            stConsultaSQL += "RCPMUNPR as 'Unidad predial', "
            stConsultaSQL += "CLSEDESC as 'Sector', "
            stConsultaSQL += "RCPMNUFI as 'Nro. Ficha predial', "
            stConsultaSQL += "RCPMMAIN as 'Matricula inmobiliria' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOCONS, RECOPRMO, MANT_CLASSECT "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "RECONURE = RCPMNURE AND "
            stConsultaSQL += "RECOFERE = RCPMFERE AND "
            stConsultaSQL += "RECOSECU = RCPMSECU AND "

            stConsultaSQL += "RCPMCLSE = CLSECODI AND "

            stConsultaSQL += "RCPMMUNI LIKE '" & stRCPMMUNI & "' AND "
            stConsultaSQL += "RCPMCORR LIKE '" & stRCPMCORR & "' AND "
            stConsultaSQL += "RCPMBARR LIKE '" & stRCPMBARR & "' AND "
            stConsultaSQL += "RCPMMANZ LIKE '" & stRCPMMANZ & "' AND "
            stConsultaSQL += "RCPMPRED LIKE '" & stRCPMPRED & "' AND "
            stConsultaSQL += "RCPMEDIF LIKE '" & stRCPMEDIF & "' AND "
            stConsultaSQL += "RCPMUNPR LIKE '" & stRCPMUNPR & "' AND "
            stConsultaSQL += "RCPMCLSE LIKE '" & stRCPMCLSE & "' AND "
            stConsultaSQL += "RCPMNUFI LIKE '" & stRCPMNUFI & "' AND "
            stConsultaSQL += "RCPMMAIN LIKE '%" & stRCPMMAIN & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RECONURE, RECOFERE "


            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

            Me.dgvCONSULTA_RECOPRMO.DataSource = dt

            Me.dgvCONSULTA_RECOPRMO.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA_RECOPRMO.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()

                Me.cmdAceptarPredioModificado.Enabled = False
                Me.txtRECONURE.Focus()

                Me.strBARRESTA.Items(2).Text = "Registros : " & "0"
            Else
                Me.cmdAceptarPredioModificado.Enabled = True

                Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ReconsultarResolucionDeConservacionMatriculaInmobiliaria()

        Try
            ' instancia un dt
            dt = New DataTable

            ' crea la variable de los campos
            Dim stREPRMAIN As String = ""

            ' carga los campos
            If Trim(Me.txtREPRMAIN.Text) = "" Then
                stREPRMAIN = "%"
            Else
                stREPRMAIN = Trim(Me.txtREPRMAIN.Text)
            End If

            ' crea la variable de consulta
            Dim stConsultaSQL As String = ""

            'concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "RECOIDRE, "
            stConsultaSQL += "RECONURE as 'Nro. Resolución', "
            stConsultaSQL += "RECOFERE as 'Fecha de resolución', "
            stConsultaSQL += "CLSEDESC as 'Sector', "
            stConsultaSQL += "RECONURA as 'Nro. Radicado OVC', "
            stConsultaSQL += "RECOFERA as 'Fecha de radicado OVC', "
            stConsultaSQL += "RECOVIRE as 'Vigencia resolución', "
            stConsultaSQL += "RECOVIFI as 'Vigencia fiscal', "
            stConsultaSQL += "RECODESC as 'Descripción', "
            stConsultaSQL += "RECOFEIN as 'Fecha de ingreso', "
            stConsultaSQL += "ESTADESC as 'Estado' "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOCONS, MANT_CLASSECT, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECOCLSE = CLSECODI AND "
            stConsultaSQL += "RECOESTA = ESTACODI AND "
            stConsultaSQL += "EXISTS(SELECT 1 FROM RECOPROP WHERE RECOSECU = RCPRSECU AND RCPRMAIN LIKE '" & CStr(Trim(stREPRMAIN)) & "') "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RECONURE, RECOFERE "


            ' instancia la clase y almacena la consulta
            Dim oConsulta As New cla_Consulta_ConexionString

            dt = oConsulta.fun_Consultar_ConexionString(stConsultaSQL)

            Me.dgvCONSULTA_RECOMAIN.DataSource = dt

            Me.dgvCONSULTA_RECOMAIN.Columns(0).Visible = False

            ' verifica si existen datos consultados
            If Me.dgvCONSULTA_RECOMAIN.RowCount = 0 Then
                mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                Me.cmdAceptarMatriculaInmobiliaria.Enabled = False
                Me.txtREPRMAIN.Focus()
            Else
                Me.cmdAceptarMatriculaInmobiliaria.Enabled = True
            End If

            Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_LimpiarCamposResolucionDeConservacion()

        Me.txtRECONURE.Text = ""
        Me.txtRECOFERE.Text = ""
        Me.txtRECONURA.Text = ""
        Me.txtRECOFERA.Text = ""
        Me.txtRECODESC.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA_RESOCONS.DataSource = New DataTable

        Me.cmdAceptarResolucionConservacion.Enabled = False

    End Sub
    Private Sub pro_LimpiarCamposResolucionDeConservacionPredioRetirados()

        Me.txtRCPRMUNI.Text = ""
        Me.txtRCPRCORR.Text = ""
        Me.txtRCPRBARR.Text = ""
        Me.txtRCPRMANZ.Text = ""
        Me.txtRCPRPRED.Text = ""
        Me.txtRCPREDIF.Text = ""
        Me.txtRCPRUNPR.Text = ""
        Me.txtRCPRCLSE.Text = ""
        Me.txtRCPRNUFI.Text = ""
        Me.txtRCPRMAIN.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA_RECOPRRE.DataSource = New DataTable

        Me.cmdAceptarPredioRetirado.Enabled = False

    End Sub
    Private Sub pro_LimpiarCamposResolucionDeConservacionPredioSegregado()

        Me.txtRCPSMUNI.Text = ""
        Me.txtRCPSCORR.Text = ""
        Me.txtRCPSBARR.Text = ""
        Me.txtRCPSMANZ.Text = ""
        Me.txtRCPSPRED.Text = ""
        Me.txtRCPSEDIF.Text = ""
        Me.txtRCPSUNPR.Text = ""
        Me.txtRCPSCLSE.Text = ""
        Me.txtRCPSNUFI.Text = ""
        Me.txtRCPSMAIN.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA_RECOPRSE.DataSource = New DataTable

        Me.cmdAceptarPredioSegregado.Enabled = False

    End Sub
    Private Sub pro_LimpiarCamposResolucionDeConservacionPredioModificado()

        Me.txtRCPMMUNI.Text = ""
        Me.txtRCPMCORR.Text = ""
        Me.txtRCPMBARR.Text = ""
        Me.txtRCPMMANZ.Text = ""
        Me.txtRCPMPRED.Text = ""
        Me.txtRCPMEDIF.Text = ""
        Me.txtRCPMUNPR.Text = ""
        Me.txtRCPMCLSE.Text = ""
        Me.txtRCPMNUFI.Text = ""
        Me.txtRCPMMAIN.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA_RECOPRMO.DataSource = New DataTable

        Me.cmdAceptarPredioModificado.Enabled = False

    End Sub
    Private Sub pro_LimpiarCamposResolucionDeConservacionMatriculaInmobiliaria()

        Me.txtREPRMAIN.Text = ""

    End Sub


#End Region

#Region "MENU"

    Private Sub cmdConsultarResolucionConservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarResolucionConservacion.Click

        Try
            pro_ReconsultarResolucionDeConservacion()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdConsultarPredioSegregado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarPredioSegregado.Click

        Try
            pro_ReconsultarResolucionDeConservacionPredioSegregado()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdConsultarPredioRetirado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarPredioRetirado.Click

        Try
            pro_ReconsultarResolucionDeConservacionPredioRetirados()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdConsultarPredioModificado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarPredioModificado.Click

        Try
            pro_ReconsultarResolucionDeConservacionPredioModificado()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdConsultarMatriculaInmobiliaria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarMatriculaInmobiliaria.Click
        pro_ReconsultarResolucionDeConservacionMatriculaInmobiliaria()
    End Sub

    Private Sub cmdAceptarLibroRadicador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptarResolucionConservacion.Click

        If Me.dgvCONSULTA_RESOCONS.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_RESOCONS(Integer.Parse(Me.dgvCONSULTA_RESOCONS.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtRECONURE.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdAceptarPredioSegregado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptarPredioSegregado.Click

        If Me.dgvCONSULTA_RECOPRSE.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_RESOCONS(Integer.Parse(Me.dgvCONSULTA_RECOPRSE.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtRCPSMUNI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdAceptarPredioRetirado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptarPredioRetirado.Click

        If Me.dgvCONSULTA_RECOPRRE.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_RESOCONS(Integer.Parse(Me.dgvCONSULTA_RECOPRRE.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtRCPRMUNI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdAceptarPredioModificado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptarPredioModificado.Click

        If Me.dgvCONSULTA_RECOPRMO.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_RESOCONS(Integer.Parse(Me.dgvCONSULTA_RECOPRMO.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtRCPMMUNI.Focus()
            Me.Close()
        End If

    End Sub
    Private Sub cmdAceptarMatriculaInmobiliaria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptarMatriculaInmobiliaria.Click

        If Me.dgvCONSULTA_RECOMAIN.RowCount = 0 Then
            MessageBox.Show("No existen registro seleccionados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Dim inId_Reg As New frm_RESOCONS(Integer.Parse(Me.dgvCONSULTA_RECOMAIN.SelectedRows.Item(0).Cells(0).Value.ToString()))
            Me.txtREPRMAIN.Focus()
            Me.Close()
        End If

    End Sub

    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiarResolucionConservacion.Click
        pro_LimpiarCamposResolucionDeConservacion()
        Me.txtRECONURE.Focus()
    End Sub
    Private Sub cmdLimpiarPredioSegregado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiarPredioSegregado.Click
        pro_LimpiarCamposResolucionDeConservacionPredioSegregado()
        Me.txtRCPSMUNI.Focus()
    End Sub
    Private Sub cmdLimpiarPredioRetirado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiarPredioRetirado.Click
        pro_LimpiarCamposResolucionDeConservacionPredioRetirados()
        Me.txtRCPRMUNI.Focus()
    End Sub
    Private Sub cmdLimpiarPredioModificado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiarPredioModificado.Click
        pro_LimpiarCamposResolucionDeConservacionPredioModificado()
        Me.txtRCPMMUNI.Focus()
    End Sub
    Private Sub cmdLimpiarMatriculaInmobiliaria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiarMatriculaInmobiliaria.Click
        pro_LimpiarCamposResolucionDeConservacionMatriculaInmobiliaria()
    End Sub

    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Dim inNroIdRe As New frm_RESOCONS(inID_REGISTRO)
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub Frm_Consultar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCamposResolucionDeConservacion()
        pro_LimpiarCamposResolucionDeConservacionPredioRetirados()
        pro_LimpiarCamposResolucionDeConservacionPredioSegregado()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub frm_consultar_TRABCAMP_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Me.txtRECONURE.Focus()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRECONURE.KeyPress, txtRECOFERE.KeyPress, txtRECONURA.KeyPress, txtRECOFERA.KeyPress, txtRECODESC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub


#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRECOFERE.GotFocus, txtRECONURE.GotFocus, txtRECONURA.GotFocus, txtRECOFERA.GotFocus, txtRECODESC.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptarResolucionConservacion.GotFocus, cmdSalir.GotFocus, cmdConsultarResolucionConservacion.GotFocus, cmdLimpiarResolucionConservacion.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

    Private Sub txtLRPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSMUNI.Validated
        If Me.txtRCPSMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSMUNI.Text) = True Then
            Me.txtRCPSMUNI.Text = fun_Formato_Mascara_3_String(Me.txtRCPSMUNI.Text)
        End If
    End Sub
    Private Sub txtRCPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPRMUNI.Validated
        If Me.txtRCPRMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPRMUNI.Text) = True Then
            Me.txtRCPRMUNI.Text = fun_Formato_Mascara_3_String(Me.txtRCPRMUNI.Text)
        End If
    End Sub
    Private Sub txtLRPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSCORR.Validated
        If Me.txtRCPSCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSCORR.Text) = True Then
            Me.txtRCPSCORR.Text = fun_Formato_Mascara_2_String(Me.txtRCPSCORR.Text)
        End If
    End Sub
    Private Sub txtRCPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPRCORR.Validated
        If Me.txtRCPRCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPRCORR.Text) = True Then
            Me.txtRCPRCORR.Text = fun_Formato_Mascara_2_String(Me.txtRCPRCORR.Text)
        End If
    End Sub
    Private Sub txtLRPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSBARR.Validated
        If Me.txtRCPSBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSBARR.Text) = True Then
            Me.txtRCPSBARR.Text = fun_Formato_Mascara_3_String(Me.txtRCPSBARR.Text)
        End If
    End Sub
    Private Sub txtRCPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPRBARR.Validated
        If Me.txtRCPRBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPRBARR.Text) = True Then
            Me.txtRCPRBARR.Text = fun_Formato_Mascara_3_String(Me.txtRCPRBARR.Text)
        End If
    End Sub
    Private Sub txtLRPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSMANZ.Validated
        If Me.txtRCPSMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSMANZ.Text) = True Then
            Me.txtRCPSMANZ.Text = fun_Formato_Mascara_3_String(Me.txtRCPSMANZ.Text)
        End If
    End Sub
    Private Sub txtRCPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPRMANZ.Validated
        If Me.txtRCPRMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPRMANZ.Text) = True Then
            Me.txtRCPRMANZ.Text = fun_Formato_Mascara_3_String(Me.txtRCPRMANZ.Text)
        End If
    End Sub
    Private Sub txtLRPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSPRED.Validated
        If Me.txtRCPSPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSPRED.Text) = True Then
            Me.txtRCPSPRED.Text = fun_Formato_Mascara_5_String(Me.txtRCPSPRED.Text)
        End If
    End Sub
    Private Sub txtRCPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPRPRED.Validated
        If Me.txtRCPRPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPRPRED.Text) = True Then
            Me.txtRCPRPRED.Text = fun_Formato_Mascara_5_String(Me.txtRCPRPRED.Text)
        End If
    End Sub
    Private Sub txtLRPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSEDIF.Validated
        If Me.txtRCPSEDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSEDIF.Text) = True Then
            Me.txtRCPSEDIF.Text = fun_Formato_Mascara_3_String(Me.txtRCPSEDIF.Text)
        End If
    End Sub
    Private Sub txtRCPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPREDIF.Validated
        If Me.txtRCPREDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPREDIF.Text) = True Then
            Me.txtRCPREDIF.Text = fun_Formato_Mascara_3_String(Me.txtRCPREDIF.Text)
        End If
    End Sub
    Private Sub txtLRPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPSUNPR.Validated
        If Me.txtRCPSUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPSUNPR.Text) = True Then
            Me.txtRCPSUNPR.Text = fun_Formato_Mascara_5_String(Me.txtRCPSUNPR.Text)
        End If
    End Sub
    Private Sub txtRCPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRCPRUNPR.Validated
        If Me.txtRCPRUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtRCPRUNPR.Text) = True Then
            Me.txtRCPRUNPR.Text = fun_Formato_Mascara_5_String(Me.txtRCPRUNPR.Text)
        End If
    End Sub

#End Region

#Region "CellDoubleClick"

    Private Sub dgvCONSULTA_RESOCONS_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA_RESOCONS.CellDoubleClick
        Me.cmdAceptarResolucionConservacion.PerformClick()
    End Sub
    Private Sub dgvCONSULTA_RECOMAIN_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCONSULTA_RECOMAIN.CellDoubleClick
        Me.cmdAceptarMatriculaInmobiliaria.PerformClick()
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