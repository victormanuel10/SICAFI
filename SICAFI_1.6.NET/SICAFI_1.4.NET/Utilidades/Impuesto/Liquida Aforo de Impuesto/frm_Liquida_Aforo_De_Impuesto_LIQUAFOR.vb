Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_Liquida_Aforo_De_Impuesto_LIQUAFOR

    '==================================
    '*** LIQUIDAR AFORO DE IMPUESTO ***
    '==================================

#Region "VARIABLES"

#Region "Conexion"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

    ' variables de procesos
    Private inProceso As Integer
    Private inTotalRegistros As Integer
    Private inNroInconsistencias As Integer
    Private stSeparador As String

    ' variables ficha predial
    Private stFIPRFIIN As String
    Private stFIPRFIFI As String
    Private stFIPRVIGE As String
    Private stFIPRMUNI As String
    Private stFIPRCORR As String
    Private stFIPRBARR As String
    Private stFIPRMANZ As String
    Private stFIPRPRED As String
    Private stFIPREDIF As String
    Private stFIPRUNPR As String
    Private stFIPRCLSE As String

    Dim stCOLIDEPA As String = ""
    Dim stCOLIMUNI As String = ""
    Dim stCOLICLSE As String = ""
    Dim stCOLICLCO As String = ""
    Dim stCOLITICO As String = ""
    Dim stCOLIVIAC As String = ""
    Dim stCOLIVIPR As String = ""
    Dim stCOLIZOEC As String = ""
    Dim stCOLITIPO As String = ""
    Dim stCOLIESTR As String = ""
    Dim stCOLILOTE As String = ""
    Dim stCOLILE44 As String = ""

    Dim vl_loAvaluoInicial As Long = 0
    Dim vl_loAvaluoFinal As Long = 0

    Dim dtConsultaDePrediosPorParametros As New DataTable

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Liquida_Aforo_De_Impuesto_LIQUAFOR
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Liquida_Aforo_De_Impuesto_LIQUAFOR
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

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtFIPRFIIN.Text = "0"
        Me.txtFIPRFIFI.Text = "999999999"
        Me.txtFIPRMUNI.Text = ""
        Me.txtFIPRCORR.Text = ""
        Me.txtFIPRBARR.Text = ""
        Me.txtFIPRMANZ.Text = ""
        Me.txtFIPRPRED.Text = ""
        Me.txtFIPREDIF.Text = ""
        Me.txtFIPRUNPR.Text = ""
        Me.lblAFSIVIGE.Text = ""
        Me.lblAFSICLSE.Text = ""
        Me.lblAFSITIIM.Text = ""
        Me.lblAFSICONC.Text = ""

        Me.pbPROCESO.Value = 0

        Me.cboAFSICLSE.DataSource = New DataTable
        Me.cboAFSIVIGE.DataSource = New DataTable
        Me.cboAFSITIIM.DataSource = New DataTable
        Me.cboAFSICONC.DataSource = New DataTable

        Me.cboCOLIDEPA.DataSource = New DataTable
        Me.cboCOLIMUNI.DataSource = New DataTable
        Me.cboCOLICLSE.DataSource = New DataTable
        Me.cboCOLIZOEC.DataSource = New DataTable

        Me.lblCOLIDEPA.Text = ""
        Me.lblCOLIMUNI.Text = ""
        Me.lblCOLICLSE.Text = ""
        Me.lblCOLIZOEC.Text = ""

        Me.strBARRESTA.Items(2).Text = "Registros : 0"


    End Sub
    Private Sub pro_VerificarCampos()

        Try
            If Trim(Me.txtFIPRFIIN.Text) = "" Then
                stFIPRFIIN = "0"
            Else
                stFIPRFIIN = Trim(Me.txtFIPRFIIN.Text)
            End If

            If Trim(Me.txtFIPRFIFI.Text) = "" Then
                stFIPRFIFI = "0"
            Else
                stFIPRFIFI = Trim(Me.txtFIPRFIFI.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRFIIN.Text)) = False Then
                stFIPRFIIN = "0"
            Else
                stFIPRFIIN = Trim(Me.txtFIPRFIIN.Text)
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRFIFI.Text)) = False Then
                stFIPRFIFI = "0"
            Else
                stFIPRFIFI = Trim(Me.txtFIPRFIFI.Text)
            End If

            If Trim(Me.txtFIPRMUNI.Text) = "" Then
                stFIPRMUNI = "%"
            Else
                stFIPRMUNI = Trim(Me.txtFIPRMUNI.Text)
            End If

            If Trim(Me.txtFIPRCORR.Text) = "" Then
                stFIPRCORR = "%"
            Else
                stFIPRCORR = Trim(Me.txtFIPRCORR.Text)
            End If

            If Trim(Me.txtFIPRBARR.Text) = "" Then
                stFIPRBARR = "%"
            Else
                stFIPRBARR = Trim(Me.txtFIPRBARR.Text)
            End If

            If Trim(Me.txtFIPRMANZ.Text) = "" Then
                stFIPRMANZ = "%"
            Else
                stFIPRMANZ = Trim(Me.txtFIPRMANZ.Text)
            End If

            If Trim(Me.txtFIPRPRED.Text) = "" Then
                stFIPRPRED = "%"
            Else
                stFIPRPRED = Trim(Me.txtFIPRPRED.Text)
            End If

            If Trim(Me.txtFIPREDIF.Text) = "" Then
                stFIPREDIF = "%"
            Else
                stFIPREDIF = Trim(Me.txtFIPREDIF.Text)
            End If

            If Trim(Me.txtFIPRUNPR.Text) = "" Then
                stFIPRUNPR = "%"
            Else
                stFIPRUNPR = Trim(Me.txtFIPRUNPR.Text)
            End If

            If Trim(Me.cboAFSICLSE.Text) = "" Then
                stFIPRCLSE = "%"
            Else
                stFIPRCLSE = Trim(Me.cboAFSICLSE.SelectedValue)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_VerificarDatosAvaluoPorEstrato()

        If Trim(Me.cboCOLIDEPA.Text) = "" Then
            stCOLIDEPA = "%"
        Else
            stCOLIDEPA = Trim(Me.cboCOLIDEPA.SelectedValue)
        End If

        If Trim(Me.txtFIPRMUNI.Text) = "" Then
            stCOLIMUNI = "%"
        Else
            stCOLIMUNI = Trim(Me.txtFIPRMUNI.Text)
        End If

        If Trim(Me.cboAFSICLSE.Text) = "" Then
            stCOLICLSE = "%"
        Else
            stCOLICLSE = Trim(Me.cboAFSICLSE.SelectedValue)
        End If

        If Trim(Me.cboAFSIVIGE.Text) = "" Then
            stCOLIVIPR = "%"
        Else
            stCOLIVIPR = Trim(Me.cboAFSIVIGE.SelectedValue)
        End If

        If Trim(Me.cboCOLIZOEC.Text) = "" Then
            stCOLIZOEC = "%"
        Else
            stCOLIZOEC = Trim(Me.cboCOLIZOEC.SelectedValue)
        End If

        If Trim(Me.cboCOLITIPO.Text) = "" Then
            stCOLITIPO = "%"
        Else
            stCOLITIPO = Trim(Me.cboCOLITIPO.SelectedValue)
        End If

        If Trim(Me.cboCOLIESTR.Text) = "" Then
            stCOLIESTR = "%"
        Else
            stCOLIESTR = Trim(Me.cboCOLIESTR.SelectedValue)
        End If

        ' tipo residencial
        If Trim(stCOLITIPO) = "R" Then

            ' rango de avaluo residencial
            If Me.cboCOLIRAAV_R.SelectedIndex = 0 Then
                vl_loAvaluoInicial = 0
                vl_loAvaluoFinal = 15000000

            ElseIf Me.cboCOLIRAAV_R.SelectedIndex = 1 Then
                vl_loAvaluoInicial = 15000001
                vl_loAvaluoFinal = 30000000

            ElseIf Me.cboCOLIRAAV_R.SelectedIndex = 2 Then
                vl_loAvaluoInicial = 30000001
                vl_loAvaluoFinal = 50000000

            ElseIf Me.cboCOLIRAAV_R.SelectedIndex = 3 Then
                vl_loAvaluoInicial = 50000001
                vl_loAvaluoFinal = 80000000

            ElseIf Me.cboCOLIRAAV_R.SelectedIndex = 4 Then
                vl_loAvaluoInicial = 80000001
                vl_loAvaluoFinal = 100000000

            ElseIf Me.cboCOLIRAAV_R.SelectedIndex = 5 Then
                vl_loAvaluoInicial = 100000001
                vl_loAvaluoFinal = 150000000

            ElseIf Me.cboCOLIRAAV_R.SelectedIndex = 6 Then
                vl_loAvaluoInicial = 150000001
                vl_loAvaluoFinal = 250000000

            ElseIf Me.cboCOLIRAAV_R.SelectedIndex = 7 Then
                vl_loAvaluoInicial = 250000001
                vl_loAvaluoFinal = 350000000

            ElseIf Me.cboCOLIRAAV_R.SelectedIndex = 8 Then
                vl_loAvaluoInicial = 350000001
                vl_loAvaluoFinal = 500000000

            ElseIf Me.cboCOLIRAAV_R.SelectedIndex = 9 Then
                vl_loAvaluoInicial = 500000001
                vl_loAvaluoFinal = 600000000

            ElseIf Me.cboCOLIRAAV_R.SelectedIndex = 10 Then
                vl_loAvaluoInicial = 600000001
                vl_loAvaluoFinal = 700000000

            ElseIf Me.cboCOLIRAAV_R.SelectedIndex = 11 Then
                vl_loAvaluoInicial = 700000001
                vl_loAvaluoFinal = 1000000000

            ElseIf Me.cboCOLIRAAV_R.SelectedIndex = 12 Then
                vl_loAvaluoInicial = 1000000001
                vl_loAvaluoFinal = 900000000000

            Else
                vl_loAvaluoInicial = 0
                vl_loAvaluoFinal = 0

            End If

        End If

        ' tipo comercial o industrial
        If Trim(stCOLITIPO) = "C" Or Trim(stCOLITIPO) = "I" Then

            ' rango de avaluo comercial
            If Me.cboCOLIRAAV_C.SelectedIndex = 0 Then
                vl_loAvaluoInicial = 0
                vl_loAvaluoFinal = 15000000

            ElseIf Me.cboCOLIRAAV_C.SelectedIndex = 1 Then
                vl_loAvaluoInicial = 15000001
                vl_loAvaluoFinal = 25000000

            ElseIf Me.cboCOLIRAAV_C.SelectedIndex = 2 Then
                vl_loAvaluoInicial = 25000001
                vl_loAvaluoFinal = 40000000

            ElseIf Me.cboCOLIRAAV_C.SelectedIndex = 3 Then
                vl_loAvaluoInicial = 40000001
                vl_loAvaluoFinal = 60000000

            ElseIf Me.cboCOLIRAAV_C.SelectedIndex = 4 Then
                vl_loAvaluoInicial = 60000001
                vl_loAvaluoFinal = 90000000

            ElseIf Me.cboCOLIRAAV_C.SelectedIndex = 5 Then
                vl_loAvaluoInicial = 90000001
                vl_loAvaluoFinal = 130000000

            ElseIf Me.cboCOLIRAAV_C.SelectedIndex = 6 Then
                vl_loAvaluoInicial = 130000001
                vl_loAvaluoFinal = 200000000

            ElseIf Me.cboCOLIRAAV_C.SelectedIndex = 7 Then
                vl_loAvaluoInicial = 200000001
                vl_loAvaluoFinal = 500000000

            ElseIf Me.cboCOLIRAAV_C.SelectedIndex = 8 Then
                vl_loAvaluoInicial = 500000001
                vl_loAvaluoFinal = 1000000000

            ElseIf Me.cboCOLIRAAV_C.SelectedIndex = 9 Then
                vl_loAvaluoInicial = 1000000001
                vl_loAvaluoFinal = 900000000000

            Else
                vl_loAvaluoInicial = 0
                vl_loAvaluoFinal = 0

            End If

        End If

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdLIQUIDAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIQUIDAR.Click

        Try
            ' verifica la vigencia
            If Me.cboAFSIVIGE.Text = "" Then
                MessageBox.Show("Ingrese la vigencia", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Me.cboAFSIVIGE.Focus()
            Else
                If Me.cboAFSITIIM.Text = "" Then
                    MessageBox.Show("Ingrese el tipo de impuesto", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    Me.cboAFSITIIM.Focus()
                Else
                    If Me.cboAFSICONC.Text = "" Then
                        MessageBox.Show("Ingrese el concepto", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        Me.cboAFSICONC.Focus()
                    Else
                        If Me.cboAFSICLSE.Text = "" Then
                            MessageBox.Show("Ingrese el sector", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                            Me.cboAFSICLSE.Focus()
                        Else

                            ' liquida por cedula catastral
                            If Me.chkLiquidaPorZonas.Checked = False And _
                               Me.chkLiquidaPorAvaluoYEstrato.Checked = False Then

                                ' valores predeterminados
                                Me.cmdLIQUIDAR.Enabled = False

                                ' buscar cadena de conexion
                                Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                                Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                                ' crea el datatable
                                dt = New DataTable

                                ' crear conexión
                                oAdapter = New SqlDataAdapter
                                oConexion = New SqlConnection(stCadenaConexion)

                                ' abre la conexion
                                oConexion.Open()

                                ' verifica los campos
                                pro_VerificarCampos()

                                ' parametros de la consulta
                                Dim ParametrosConsulta As String = ""

                                ' Concatena la condicion de la consulta
                                ParametrosConsulta += "Select "
                                ParametrosConsulta += "Fiprnufi, "
                                ParametrosConsulta += "FiprDepa, "
                                ParametrosConsulta += "FiprMuni, "
                                ParametrosConsulta += "FiprCorr, "
                                ParametrosConsulta += "FiprBarr, "
                                ParametrosConsulta += "FiprManz, "
                                ParametrosConsulta += "FiprPred, "
                                ParametrosConsulta += "FiprEdif, "
                                ParametrosConsulta += "FiprUnpr, "
                                ParametrosConsulta += "FiprClse, "
                                ParametrosConsulta += "FiprVige, "
                                ParametrosConsulta += "FiprTifi "
                                ParametrosConsulta += "From FichPred where "
                                ParametrosConsulta += "FiprMuni like '" & stFIPRMUNI & "' and "
                                ParametrosConsulta += "FiprCorr like '" & stFIPRCORR & "' and "
                                ParametrosConsulta += "FiprBarr like '" & stFIPRBARR & "' and "
                                ParametrosConsulta += "FiprManz like '" & stFIPRMANZ & "' and "
                                ParametrosConsulta += "FiprPred like '" & stFIPRPRED & "' and "
                                ParametrosConsulta += "FiprEdif like '" & stFIPREDIF & "' and "
                                ParametrosConsulta += "FiprUnpr like '" & stFIPRUNPR & "' and "
                                ParametrosConsulta += "FiprClse like '" & stFIPRCLSE & "' and "
                                ParametrosConsulta += "FiprTifi in ('0') " & " and "
                                ParametrosConsulta += "FiprNufi between '" & stFIPRFIIN & "' and '" & stFIPRFIFI & "' and "
                                ParametrosConsulta += "FiprEsta = 'ac' "

                                ' ejecuta la consulta
                                oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                                ' procesa la consulta 
                                oEjecutar.CommandTimeout = 0
                                oEjecutar.CommandType = CommandType.Text
                                oAdapter.SelectCommand = oEjecutar

                                ' llena el datatable 
                                oAdapter.Fill(dt)

                                ' cierra la conexion
                                oConexion.Close()

                                ' valida las ficha encontradas en la consulta
                                If dt.Rows.Count > 0 Then

                                    If MessageBox.Show("Se registraron: " & dt.Rows.Count & " predios. " & " ¿ Desea continuar ? ", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                                        ' Valores predeterminados ProgressBar
                                        inProceso = 0
                                        Me.pbPROCESO.Value = 0
                                        Me.pbPROCESO.Maximum = dt.Rows.Count
                                        Me.Timer1.Enabled = True

                                        'Recorre el rango asignado
                                        Dim i As Integer

                                        ' recorre la fichas consultadas
                                        For i = 0 To dt.Rows.Count - 1

                                            Dim inFIPRNUFI As Integer = CInt(dt.Rows(i).Item("FIPRNUFI"))

                                            Dim stFIPRDEPA As String = CStr(Trim(dt.Rows(0).Item("FIPRDEPA").ToString))
                                            Dim stFIPRMUNI As String = CStr(Trim(dt.Rows(0).Item("FIPRMUNI").ToString))
                                            Dim inFIPRCLSE As Integer = CInt(Me.cboAFSICLSE.SelectedValue)
                                            Dim inFIPRVIGE As Integer = CInt(Me.cboAFSIVIGE.SelectedValue)
                                            Dim inFIPRTIIM As Integer = CInt(Me.cboAFSITIIM.SelectedValue)
                                            Dim inFIPRCONC As Integer = CInt(Me.cboAFSICONC.SelectedValue)

                                            ' instancia la clase
                                            Dim objdatos66 As New cla_PEPELIQU
                                            Dim tbl66 As New DataTable

                                            tbl66 = objdatos66.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_TIIM_CONC_X_PEPELIQU(stFIPRDEPA, stFIPRMUNI, inFIPRCLSE, inFIPRVIGE, inFIPRTIIM, inFIPRCONC)

                                            If tbl66.Rows.Count = 0 OrElse CBool(tbl66.Rows(0).Item("PPLIAFSI")) = False Then
                                                If MessageBox.Show("La ficha Nro.: " & inFIPRNUFI & " no tiene permiso para ejecutar el proceso." & Chr(Keys.Enter) & "¿ Desea continuar ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                                                    Exit For
                                                End If
                                            Else
                                                pro_LIQUIDA_AFORO_IMPUESTO(inFIPRNUFI, Me.cboAFSIVIGE.SelectedValue, Me.cboAFSICLSE.SelectedValue, Me.cboAFSITIIM.SelectedValue, Me.cboAFSICONC.SelectedValue, Me.chkAplicarPorcentajeMaximoDeLiquidacion.Checked, Me.rbdAplicarTarifaUnicaAlLote.Checked, Me.rbdAplicarTarifaPorZonaAlLote.Checked)
                                            End If

                                            ' incrementa la barra
                                            inProceso = inProceso + 1
                                            Me.pbPROCESO.Value = inProceso

                                        Next

                                        ' Llena el datagrigview
                                        Me.pbPROCESO.Value = 0

                                        MessageBox.Show("Proceso de aforo terminado", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                                    End If

                                Else
                                    ' Mensaje terminacion
                                    MessageBox.Show("NO existen registros con los parametros asignados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    Me.strBARRESTA.Items(2).Text = "Registros : 0"
                                End If

                                ' liquida por zonas económicas
                            ElseIf Me.chkLiquidaPorZonas.Checked = True Then

                                ' valores predeterminados
                                Me.cmdLIQUIDAR.Enabled = False

                                ' buscar cadena de conexion
                                Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                                Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                                ' crea el datatable
                                dt = New DataTable

                                ' crear conexión
                                oAdapter = New SqlDataAdapter
                                oConexion = New SqlConnection(stCadenaConexion)

                                ' abre la conexion
                                oConexion.Open()

                                ' verifica los campos
                                pro_VerificarCampos()

                                ' parametros de la consulta
                                Dim ParametrosConsulta As String = ""

                                ' Concatena la condicion de la consulta
                                ParametrosConsulta += "Select "
                                ParametrosConsulta += "Fiprnufi, "
                                ParametrosConsulta += "FiprDepa, "
                                ParametrosConsulta += "FiprMuni, "
                                ParametrosConsulta += "FiprCorr, "
                                ParametrosConsulta += "FiprBarr, "
                                ParametrosConsulta += "FiprManz, "
                                ParametrosConsulta += "FiprPred, "
                                ParametrosConsulta += "FiprEdif, "
                                ParametrosConsulta += "FiprUnpr, "
                                ParametrosConsulta += "FiprClse, "
                                ParametrosConsulta += "FiprVige, "
                                ParametrosConsulta += "FiprTifi "
                                ParametrosConsulta += "From FichPred where "
                                ParametrosConsulta += "FiprMuni like '" & Me.cboCOLIMUNI.SelectedValue & "' and "
                                ParametrosConsulta += "FiprClse like '" & Me.cboCOLICLSE.SelectedValue & "' and "
                                ParametrosConsulta += "exists(select 1 from histzona where Fiprnufi = hizonufi and hizozoec = '" & Me.cboCOLIZOEC.SelectedValue & "' and hizovige = '" & Me.cboAFSIVIGE.SelectedValue & "') and "

                                ParametrosConsulta += "FiprTifi in ('0') " & " and "
                                ParametrosConsulta += "FiprEsta = 'ac' "

                                ' ejecuta la consulta
                                oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                                ' procesa la consulta 
                                oEjecutar.CommandTimeout = 0
                                oEjecutar.CommandType = CommandType.Text
                                oAdapter.SelectCommand = oEjecutar

                                ' llena el datatable 
                                oAdapter.Fill(dt)

                                ' cierra la conexion
                                oConexion.Close()

                                ' valida las ficha encontradas en la consulta
                                If dt.Rows.Count > 0 Then

                                    If MessageBox.Show("Se registraron: " & dt.Rows.Count & " predios. " & " ¿ Desea continuar ? ", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                                        ' Valores predeterminados ProgressBar
                                        inProceso = 0
                                        Me.pbPROCESO.Value = 0
                                        Me.pbPROCESO.Maximum = dt.Rows.Count
                                        Me.Timer1.Enabled = True

                                        'Recorre el rango asignado
                                        Dim i As Integer

                                        ' recorre la fichas consultadas
                                        For i = 0 To dt.Rows.Count - 1

                                            Dim inFIPRNUFI As Integer = CInt(dt.Rows(i).Item("FIPRNUFI"))

                                            Dim stFIPRDEPA As String = CStr(Trim(dt.Rows(0).Item("FIPRDEPA").ToString))
                                            Dim stFIPRMUNI As String = CStr(Trim(dt.Rows(0).Item("FIPRMUNI").ToString))
                                            Dim inFIPRCLSE As Integer = CInt(Me.cboAFSICLSE.SelectedValue)
                                            Dim inFIPRVIGE As Integer = CInt(Me.cboAFSIVIGE.SelectedValue)
                                            Dim inFIPRTIIM As Integer = CInt(Me.cboAFSITIIM.SelectedValue)
                                            Dim inFIPRCONC As Integer = CInt(Me.cboAFSICONC.SelectedValue)

                                            ' instancia la clase
                                            Dim objdatos66 As New cla_PEPELIQU
                                            Dim tbl66 As New DataTable

                                            tbl66 = objdatos66.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_TIIM_CONC_X_PEPELIQU(stFIPRDEPA, stFIPRMUNI, inFIPRCLSE, inFIPRVIGE, inFIPRTIIM, inFIPRCONC)

                                            If tbl66.Rows.Count = 0 OrElse CBool(tbl66.Rows(0).Item("PPLIHIAV")) = False Then
                                                If MessageBox.Show("La ficha Nro.: " & inFIPRNUFI & " no tiene permiso para ejecutar el proceso." & Chr(Keys.Enter) & "¿ Desea continuar ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                                                    Exit For
                                                End If
                                            Else
                                                pro_LIQUIDA_AFORO_IMPUESTO(inFIPRNUFI, Me.cboAFSIVIGE.SelectedValue, Me.cboAFSICLSE.SelectedValue, Me.cboAFSITIIM.SelectedValue, Me.cboAFSICONC.SelectedValue, Me.chkAplicarPorcentajeMaximoDeLiquidacion.Checked, Me.rbdAplicarTarifaUnicaAlLote.Checked, Me.rbdAplicarTarifaPorZonaAlLote.Checked)
                                            End If

                                            ' incrementa la barra
                                            inProceso = inProceso + 1
                                            Me.pbPROCESO.Value = inProceso

                                        Next

                                        ' Llena el datagrigview
                                        Me.pbPROCESO.Value = 0

                                        MessageBox.Show("Proceso de aforo terminado", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                                    End If

                                Else
                                    ' Mensaje terminacion
                                    MessageBox.Show("NO existen registros con los parametros asignados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    Me.strBARRESTA.Items(2).Text = "Registros : 0"
                                End If

                                ' liquida por rango de avaluo y estrato
                            ElseIf Me.chkLiquidaPorAvaluoYEstrato.Checked = True Then

                                ' valores predeterminados
                                Me.cmdLIQUIDAR.Enabled = False

                                ' buscar cadena de conexion
                                Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                                Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                                ' crea el datatable
                                dtConsultaDePrediosPorParametros = New DataTable

                                ' crear conexión
                                oAdapter = New SqlDataAdapter
                                oConexion = New SqlConnection(stCadenaConexion)

                                ' abre la conexion
                                oConexion.Open()

                                ' parametros de la consulta
                                Dim ParametrosConsulta As String = ""

                                ' verifica los datos de los campos
                                pro_VerificarDatosAvaluoPorEstrato()

                                ' Concatena la condicion de la consulta
                                ParametrosConsulta += "Select "
                                ParametrosConsulta += "suimnufi, "
                                ParametrosConsulta += "suimdepa, "
                                ParametrosConsulta += "suimmuni, "
                                ParametrosConsulta += "suimclse, "
                                ParametrosConsulta += "afsivaba, "
                                ParametrosConsulta += "afsivali, "
                                ParametrosConsulta += "hilideec, "
                                ParametrosConsulta += "hilipunt, "
                                ParametrosConsulta += "hilitipo, "
                                ParametrosConsulta += "hililote, "
                                ParametrosConsulta += "hiliestr "

                                ParametrosConsulta += "from aforsuim, sujeimpu, histliqu where "

                                ParametrosConsulta += "suimnufi = afsinufi and "
                                ParametrosConsulta += "suimnufi = hilinufi and "
                                ParametrosConsulta += "hilivige = afsivige and "

                                ParametrosConsulta += "afsivaba <> 0 and "
                                ParametrosConsulta += "afsivali <> 0 and "

                                ParametrosConsulta += "suimmuni like '" & stCOLIMUNI & "' and "
                                ParametrosConsulta += "suimclse like '" & stCOLICLSE & "' and "
                                ParametrosConsulta += "afsivige like '" & stCOLIVIPR & "' and "

                                If Trim(stCOLITIPO) = "R" Then
                                    ParametrosConsulta += "hilitipo like '" & stCOLITIPO & "%' and "

                                ElseIf Trim(stCOLITIPO) = "C" Or Trim(stCOLITIPO) = "I" Then
                                    ParametrosConsulta += "hilitipo IN ('C','I') and "

                                End If

                                ParametrosConsulta += "hiliestr like '" & stCOLIESTR & "%' and "
                                ParametrosConsulta += "afsivaba between '" & CLng(vl_loAvaluoInicial) & "' and '" & CLng(vl_loAvaluoFinal) & "' "

                                ' ejecuta la consulta
                                oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                                ' procesa la consulta 
                                oEjecutar.CommandTimeout = 0
                                oEjecutar.CommandType = CommandType.Text
                                oAdapter.SelectCommand = oEjecutar

                                ' llena el datatable 
                                oAdapter.Fill(dtConsultaDePrediosPorParametros)

                                ' cierra la conexion
                                oConexion.Close()

                                ' valida las ficha encontradas en la consulta
                                If dtConsultaDePrediosPorParametros.Rows.Count > 0 Then

                                    If MessageBox.Show("Se registraron: " & dtConsultaDePrediosPorParametros.Rows.Count & " predios. " & " ¿ Desea continuar ? ", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                                        ' Valores predeterminados ProgressBar
                                        inProceso = 0
                                        Me.pbPROCESO.Value = 0
                                        Me.pbPROCESO.Maximum = dtConsultaDePrediosPorParametros.Rows.Count
                                        Me.Timer1.Enabled = True

                                        'Recorre el rango asignado
                                        Dim i As Integer

                                        ' recorre la fichas consultadas
                                        For i = 0 To dtConsultaDePrediosPorParametros.Rows.Count - 1

                                            Dim inFIPRNUFI As Integer = CInt(dtConsultaDePrediosPorParametros.Rows(i).Item("suimnufi"))

                                            Dim stFIPRDEPA As String = CStr(Trim(dtConsultaDePrediosPorParametros.Rows(0).Item("suimdepa").ToString))
                                            Dim stFIPRMUNI As String = CStr(Trim(dtConsultaDePrediosPorParametros.Rows(0).Item("suimmuni").ToString))
                                            Dim inFIPRCLSE As Integer = CInt(Me.cboAFSICLSE.SelectedValue)
                                            Dim inFIPRVIGE As Integer = CInt(Me.cboAFSIVIGE.SelectedValue)
                                            Dim inFIPRTIIM As Integer = CInt(Me.cboAFSITIIM.SelectedValue)
                                            Dim inFIPRCONC As Integer = CInt(Me.cboAFSICONC.SelectedValue)

                                            ' instancia la clase
                                            Dim objdatos66 As New cla_PEPELIQU
                                            Dim tbl66 As New DataTable

                                            tbl66 = objdatos66.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_TIIM_CONC_X_PEPELIQU(stFIPRDEPA, stFIPRMUNI, inFIPRCLSE, inFIPRVIGE, inFIPRTIIM, inFIPRCONC)

                                            If tbl66.Rows.Count = 0 OrElse CBool(tbl66.Rows(0).Item("PPLIHIAV")) = False Then
                                                If MessageBox.Show("La ficha Nro.: " & inFIPRNUFI & " no tiene permiso para ejecutar el proceso." & Chr(Keys.Enter) & "¿ Desea continuar ?", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                                                    Exit For
                                                End If
                                            Else
                                                pro_LIQUIDA_AFORO_IMPUESTO(inFIPRNUFI, inFIPRVIGE, inFIPRCLSE, inFIPRTIIM, inFIPRCONC, Me.chkAplicarPorcentajeMaximoDeLiquidacion.Checked, Me.rbdAplicarTarifaUnicaAlLote.Checked, Me.rbdAplicarTarifaPorZonaAlLote.Checked)
                                            End If

                                            ' incrementa la barra
                                            inProceso = inProceso + 1
                                            Me.pbPROCESO.Value = inProceso

                                        Next

                                        ' Llena el datagrigview
                                        Me.pbPROCESO.Value = 0

                                        MessageBox.Show("Proceso de aforo terminado", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                                    End If

                                Else
                                    ' Mensaje terminacion
                                    MessageBox.Show("NO existen registros con los parametros asignados", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    Me.strBARRESTA.Items(2).Text = "Registros : 0"
                                End If

                            End If

                            Me.cmdLIQUIDAR.Enabled = True
                            Me.cmdLIQUIDAR.Focus()

                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdLIQUIDAR.Enabled = True
        End Try

    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        pro_LimpiarCampos()
        txtFIPRFIIN.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_REPO_FIPRINCO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtFIPRFIIN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRFIIN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRFIFI.Focus()
        End If
    End Sub
    Private Sub txtFIPRFIFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRFIFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.txtFIPRMUNI.Focus()
        End If
    End Sub
    Private Sub cboTAAPVIGE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAFSIVIGE.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRMUNI.Focus()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtFIPRMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMUNI.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRCORR.Focus()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtFIPRCORR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCORR.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRBARR.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRBARR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRBARR.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRMANZ.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRMANZ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMANZ.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRPRED.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRPRED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRPRED.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPREDIF.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPREDIF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPREDIF.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        txtFIPRUNPR.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRUNPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRUNPR.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        cboAFSITIIM.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub cboAFSITIIM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAFSITIIM.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cboAFSICONC.Focus()
        End If
    End Sub
    Private Sub cboAFSICONC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAFSICONC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cboAFSIVIGE.Focus()
        End If
    End Sub
    Private Sub cboFIPRVIGE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAFSIVIGE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cboAFSICLSE.Focus()
        End If
    End Sub
    Private Sub cboFIPRCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAFSICLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            Me.cmdLIQUIDAR.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtFIPRFIIN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIIN.GotFocus
        txtFIPRFIIN.SelectionStart = 0
        txtFIPRFIIN.SelectionLength = Len(txtFIPRFIIN.Text)
        strBARRESTA.Items(0).Text = txtFIPRFIIN.AccessibleDescription
    End Sub
    Private Sub txtFIPRFIFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIFI.GotFocus
        txtFIPRFIFI.SelectionStart = 0
        txtFIPRFIFI.SelectionLength = Len(txtFIPRFIFI.Text)
        strBARRESTA.Items(0).Text = txtFIPRFIFI.AccessibleDescription
    End Sub
    Private Sub cboTAAPVIGE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFSIVIGE.GotFocus
        strBARRESTA.Items(0).Text = cboAFSIVIGE.AccessibleDescription
    End Sub
    Private Sub cboTAAPCLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFSICLSE.GotFocus
        strBARRESTA.Items(0).Text = cboAFSICLSE.AccessibleDescription
    End Sub
    Private Sub txtFIPRMUNI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.GotFocus
        txtFIPRMUNI.SelectionStart = 0
        txtFIPRMUNI.SelectionLength = Len(txtFIPRMUNI.Text)
        strBARRESTA.Items(0).Text = txtFIPRMUNI.AccessibleDescription
    End Sub
    Private Sub txtFIPRCORR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.GotFocus
        txtFIPRCORR.SelectionStart = 0
        txtFIPRCORR.SelectionLength = Len(txtFIPRCORR.Text)
        strBARRESTA.Items(0).Text = txtFIPRCORR.AccessibleDescription
    End Sub
    Private Sub txtFIPRBARR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.GotFocus
        txtFIPRBARR.SelectionStart = 0
        txtFIPRBARR.SelectionLength = Len(txtFIPRBARR.Text)
        strBARRESTA.Items(0).Text = txtFIPRBARR.AccessibleDescription
    End Sub
    Private Sub txtFIPRMANZ_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.GotFocus
        txtFIPRMANZ.SelectionStart = 0
        txtFIPRMANZ.SelectionLength = Len(txtFIPRMANZ.Text)
        strBARRESTA.Items(0).Text = txtFIPRMANZ.AccessibleDescription
    End Sub
    Private Sub txtFIPRPRED_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.GotFocus
        txtFIPRPRED.SelectionStart = 0
        txtFIPRPRED.SelectionLength = Len(txtFIPRPRED.Text)
        strBARRESTA.Items(0).Text = txtFIPRPRED.AccessibleDescription
    End Sub
    Private Sub txtFIPREDIF_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.GotFocus
        txtFIPREDIF.SelectionStart = 0
        txtFIPREDIF.SelectionLength = Len(txtFIPREDIF.Text)
        strBARRESTA.Items(0).Text = txtFIPREDIF.AccessibleDescription
    End Sub
    Private Sub txtFIPRUNPR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.GotFocus
        txtFIPRUNPR.SelectionStart = 0
        txtFIPRUNPR.SelectionLength = Len(txtFIPRUNPR.Text)
        strBARRESTA.Items(0).Text = txtFIPRUNPR.AccessibleDescription
    End Sub
    Private Sub cboFIPRCLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFSICLSE.GotFocus
        strBARRESTA.Items(0).Text = cboAFSICLSE.AccessibleDescription
    End Sub
    Private Sub cboAFSITIIM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFSITIIM.GotFocus
        strBARRESTA.Items(0).Text = cboAFSITIIM.AccessibleDescription
    End Sub
    Private Sub cboAFSICONC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFSICONC.GotFocus
        strBARRESTA.Items(0).Text = cboAFSICONC.AccessibleDescription
    End Sub
    Private Sub cmdVALIDAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIQUIDAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIQUIDAR.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFIPRFIIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIIN.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRFIIN.Text)) = True Then
            Me.txtFIPRFIIN.Text = Val(Trim(Me.txtFIPRFIIN.Text))
        Else
            Me.txtFIPRFIIN.Focus()
            mod_MENSAJE.Inco_Valo_Nume()
        End If

    End Sub
    Private Sub txtFIPRFIFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIFI.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRFIFI.Text)) = True Then
            Me.txtFIPRFIFI.Text = Val(Trim(Me.txtFIPRFIFI.Text))
        Else
            Me.txtFIPRFIFI.Focus()
            mod_MENSAJE.Inco_Valo_Nume()
        End If

    End Sub
    Private Sub txtFIPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.Validated
        If Trim(Me.txtFIPRMUNI.Text) <> "" Then
            txtFIPRMUNI.Text = fun_Formato_Mascara_3_String(Me.txtFIPRMUNI.Text)
        End If
    End Sub
    Private Sub txtFIPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.Validated
        If Trim(Me.txtFIPRCORR.Text) <> "" Then
            Me.txtFIPRCORR.Text = fun_Formato_Mascara_2_String(Me.txtFIPRCORR.Text)
        End If
    End Sub
    Private Sub txtFIPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.Validated
        If Trim(Me.txtFIPRBARR.Text) <> "" Then
            Me.txtFIPRBARR.Text = fun_Formato_Mascara_3_String(Me.txtFIPRBARR.Text)
        End If
    End Sub
    Private Sub txtFIPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.Validated
        If Trim(Me.txtFIPRMANZ.Text) <> "" Then
            Me.txtFIPRMANZ.Text = fun_Formato_Mascara_3_String(Me.txtFIPRMANZ.Text)
        End If
    End Sub
    Private Sub txtFIPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.Validated
        If Trim(Me.txtFIPRPRED.Text) <> "" Then
            Me.txtFIPRPRED.Text = fun_Formato_Mascara_5_String(Me.txtFIPRPRED.Text)
        End If
    End Sub
    Private Sub txtFIPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.Validated
        If Trim(Me.txtFIPREDIF.Text) <> "" Then
            Me.txtFIPREDIF.Text = fun_Formato_Mascara_3_String(Me.txtFIPREDIF.Text)
        End If
    End Sub
    Private Sub txtFIPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.Validated
        If Trim(Me.txtFIPRUNPR.Text) <> "" Then
            Me.txtFIPRUNPR.Text = fun_Formato_Mascara_5_String(Me.txtFIPRUNPR.Text)
        End If
    End Sub

#End Region

#Region "Click"

    Private Sub cboFIPRCLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFSICLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboAFSICLSE, Me.cboAFSICLSE.SelectedIndex)
    End Sub
    Private Sub cboFIPRVIGE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFSIVIGE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboAFSIVIGE, Me.cboAFSIVIGE.SelectedIndex)
    End Sub
    Private Sub cboAFSITIIM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFSITIIM.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboAFSITIIM, Me.cboAFSITIIM.SelectedIndex)
    End Sub
    Private Sub cboAFSICONC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAFSICONC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboAFSICONC, Me.cboAFSICONC.SelectedIndex, Me.cboAFSITIIM)
    End Sub

#End Region

#Region "KeyDown"

    Private Sub cboFIPRCLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAFSICLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboAFSICLSE, Me.cboAFSICLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboFIPRVIGE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAFSIVIGE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboAFSIVIGE, Me.cboAFSIVIGE.SelectedIndex)
        End If
    End Sub
    Private Sub cboAFSITIIM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAFSITIIM.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOIMPU_Descripcion(Me.cboAFSITIIM, Me.cboAFSITIIM.SelectedIndex)
        End If
    End Sub
    Private Sub cboAFSICONC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAFSICONC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CONCEPTO_Descripcion(Me.cboAFSICONC, Me.cboAFSICONC.SelectedIndex, Me.cboAFSITIIM)
        End If
    End Sub
    Private Sub cboCOLIDEPA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOLIDEPA.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboCOLIDEPA, Me.cboCOLIDEPA.SelectedIndex)
        End If
    End Sub
    Private Sub cboCOLIMUNI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOLIMUNI.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboCOLIMUNI, Me.cboCOLIMUNI.SelectedIndex, Me.cboCOLIDEPA)
        End If
    End Sub
    Private Sub cboCOLICLSE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOLICLSE.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboCOLICLSE, Me.cboCOLICLSE.SelectedIndex)
        End If
    End Sub
    Private Sub cboCOLIZOEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOLIZOEC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON_X_MUNICIPIO_Descripcion(Me.cboCOLIZOEC, Me.cboCOLIZOEC.SelectedIndex, Me.cboCOLIDEPA, Me.cboCOLIMUNI, Me.cboCOLICLSE)
        End If
    End Sub
    Private Sub cboCOLIESTR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOLIESTR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboCOLIESTR, Me.cboCOLIESTR.SelectedIndex)
        End If
    End Sub
    Private Sub cboCOLITIPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOLITIPO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboCOLITIPO, Me.cboCOLITIPO.SelectedIndex)
        End If
    End Sub

#End Region

#Region "Click"

    Private Sub cboCOLIDEPA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOLIDEPA.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DEPARTAMENTO_Descripcion(Me.cboCOLIDEPA, Me.cboCOLIDEPA.SelectedIndex)
    End Sub
    Private Sub cboCOLIMUNI_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOLIMUNI.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_MUNICIPIO_X_DEPARTAMENTO_Descripcion(Me.cboCOLIMUNI, Me.cboCOLIMUNI.SelectedIndex, Me.cboCOLIDEPA)
    End Sub
    Private Sub cboCOLICLSE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOLICLSE.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASSECT_Descripcion(Me.cboCOLICLSE, Me.cboCOLICLSE.SelectedIndex)
    End Sub
    Private Sub cboCOLIZOEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOLIZOEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON_X_MUNICIPIO_Descripcion(Me.cboCOLIZOEC, Me.cboCOLIZOEC.SelectedIndex, Me.cboCOLIDEPA, Me.cboCOLIMUNI, Me.cboCOLICLSE)
    End Sub
    Private Sub cboCOLIESTR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOLIESTR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboCOLIESTR, Me.cboCOLIESTR.SelectedIndex)
    End Sub
    Private Sub cboCOLITIPO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOLITIPO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboCOLITIPO, Me.cboCOLITIPO.SelectedIndex)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboFIPRCLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAFSICLSE.SelectedIndexChanged
        Me.lblAFSICLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboAFSICLSE), String)
    End Sub
    Private Sub cboFIPRVIGE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAFSIVIGE.SelectedIndexChanged
        Me.lblAFSIVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboAFSIVIGE), String)
    End Sub
    Private Sub cboAFSITIIM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAFSITIIM.SelectedIndexChanged
        Me.lblAFSITIIM.Text = CType(fun_Buscar_Lista_Valores_TIPOIMPU_Codigo(Me.cboAFSITIIM), String)

        Me.cboAFSICONC.DataSource = New DataTable
        Me.lblAFSICONC.Text = ""
    End Sub
    Private Sub cboAFSICONC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAFSICONC.SelectedIndexChanged
        Me.lblAFSICONC.Text = CType(fun_Buscar_Lista_Valores_CONCEPTO_Codigo(Me.cboAFSITIIM, Me.cboAFSICONC), String)
    End Sub
    Private Sub cboCOLIESTR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOLIESTR.SelectedIndexChanged
        Me.lblCOLIESTR.Text = CType(fun_Buscar_Lista_Valores_ESTRATO_Codigo(Me.cboCOLIESTR), String)
    End Sub
    Private Sub cboCOLITIPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOLITIPO.SelectedIndexChanged
        Me.lblCOLITIPO.Text = CType(fun_Buscar_Lista_Valores_TIPOCALI_Codigo(Me.cboCOLITIPO), String)
    End Sub

#End Region

#Region "CheckedChanged"

    Private Sub chkLiquidaPorZonas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLiquidaPorZonas.CheckedChanged

        If Me.chkLiquidaPorZonas.Checked = False Then

            Me.cboCOLIDEPA.DataSource = New DataTable
            Me.cboCOLIMUNI.DataSource = New DataTable
            Me.cboCOLICLSE.DataSource = New DataTable
            Me.cboCOLIZOEC.DataSource = New DataTable

            Me.lblCOLIDEPA.Text = ""
            Me.lblCOLIMUNI.Text = ""
            Me.lblCOLICLSE.Text = ""
            Me.lblCOLIZOEC.Text = ""

            Me.cboCOLIDEPA.Enabled = False
            Me.cboCOLIMUNI.Enabled = False
            Me.cboCOLICLSE.Enabled = False
            Me.cboCOLIZOEC.Enabled = False

        ElseIf Me.chkLiquidaPorZonas.Checked = True Then

            Me.cboCOLIDEPA.Enabled = True
            Me.cboCOLIMUNI.Enabled = True
            Me.cboCOLICLSE.Enabled = True
            Me.cboCOLIZOEC.Enabled = True

        End If

    End Sub
    Private Sub cboCOLIDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOLIDEPA.SelectedIndexChanged
        Me.lblCOLIDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboCOLIDEPA), String)

        Me.cboCOLIMUNI.DataSource = New DataTable
        Me.lblCOLIMUNI.Text = ""

        Me.cboCOLICLSE.DataSource = New DataTable
        Me.lblCOLICLSE.Text = ""

        Me.cboCOLIZOEC.DataSource = New DataTable
        Me.lblCOLIZOEC.Text = ""

    End Sub
    Private Sub cboCOLIMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOLIMUNI.SelectedIndexChanged
        Me.lblCOLIMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboCOLIDEPA, Me.cboCOLIMUNI), String)

        Me.cboCOLICLSE.DataSource = New DataTable
        Me.lblCOLICLSE.Text = ""

        Me.cboCOLIZOEC.DataSource = New DataTable
        Me.lblCOLIZOEC.Text = ""

    End Sub
    Private Sub cboCOLICLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOLICLSE.SelectedIndexChanged
        Me.lblCOLICLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboCOLICLSE), String)

        Me.cboCOLIZOEC.DataSource = New DataTable
        Me.lblCOLIZOEC.Text = ""

    End Sub
    Private Sub cboCOLIZOEC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOLIZOEC.SelectedIndexChanged
        Me.lblCOLIZOEC.Text = CType(fun_Buscar_Lista_Valores_ZONAECON_Codigo(Me.cboCOLIDEPA, Me.cboCOLIMUNI, Me.cboCOLICLSE, Me.cboCOLIZOEC), String)
    End Sub

#End Region

#End Region

End Class