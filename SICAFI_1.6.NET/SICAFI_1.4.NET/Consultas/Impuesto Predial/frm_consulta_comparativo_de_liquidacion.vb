Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_consulta_comparativo_de_liquidacion

    '============================================
    '*** CONSULTA COMPARATIVOS DE LIQUIDACIÓN ***
    '============================================

#Region "CONSTRUCTORES"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private ds As New DataSet
    Private dt As New DataTable

    Private dt1 As New DataTable
    Private dt2 As New DataTable
    Private dt3 As New DataTable
    Private dt4 As New DataTable
    Private dt5 As New DataTable
    Private dt6 As New DataTable

    Dim tblCONSULTA As New DataTable

#End Region

#Region "VARIABLES"

    Dim dtConsultaDePrediosPorParametros As New DataTable

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

    Dim dt_0_al_10 As New DataTable
    Dim dt_11_al_28 As New DataTable
    Dim dt_29_al_46 As New DataTable
    Dim dt_47_al_64 As New DataTable
    Dim dt_65_al_82 As New DataTable
    Dim dt_83_al_100 As New DataTable

    Dim dt_0_al_10_INCRPUNT As New DataTable
    Dim dt_11_al_28_INCRPUNT As New DataTable
    Dim dt_29_al_46_INCRPUNT As New DataTable
    Dim dt_47_al_64_INCRPUNT As New DataTable
    Dim dt_65_al_82_INCRPUNT As New DataTable
    Dim dt_83_al_100_INCRPUNT As New DataTable

    Dim stINCREMENTO_RANGO_1 As String = ""
    Dim stINCREMENTO_RANGO_2 As String = ""
    Dim stINCREMENTO_RANGO_3 As String = ""
    Dim stINCREMENTO_RANGO_4 As String = ""
    Dim stINCREMENTO_RANGO_5 As String = ""
    Dim stINCREMENTO_RANGO_6 As String = ""

    Dim stINCREMENTO_MINIMA_RANGO_1 As String = ""
    Dim stINCREMENTO_MINIMA_RANGO_2 As String = ""
    Dim stINCREMENTO_MINIMA_RANGO_3 As String = ""
    Dim stINCREMENTO_MINIMA_RANGO_4 As String = ""
    Dim stINCREMENTO_MINIMA_RANGO_5 As String = ""
    Dim stINCREMENTO_MINIMA_RANGO_6 As String = ""

    Dim stINCREMENTO_MAXIMA_RANGO_1 As String = ""
    Dim stINCREMENTO_MAXIMA_RANGO_2 As String = ""
    Dim stINCREMENTO_MAXIMA_RANGO_3 As String = ""
    Dim stINCREMENTO_MAXIMA_RANGO_4 As String = ""
    Dim stINCREMENTO_MAXIMA_RANGO_5 As String = ""
    Dim stINCREMENTO_MAXIMA_RANGO_6 As String = ""

    Dim vl_inCantidadRegistrosMenor As Integer = 0
    Dim vl_inCantidadRegistrosMayor As Integer = 0
    Dim vl_loPRO_AVALUO_Menor As Long = 0
    Dim vl_loPRO_AVALUO_Mayor As Long = 0

    Dim vl_loAvaluoInicial As Long = 0
    Dim vl_loAvaluoFinal As Long = 0

    Private inProceso As Integer = 0

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_consulta_comparativo_de_liquidacion
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_consulta_comparativo_de_liquidacion
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

#Region "FUNCIONES"

    Private Function fun_ConsultarPrediosAptoCasa(ByVal stFICHA As String) As Boolean

        Try
            Dim boFICHAAPTOCASA As Boolean = False

            Dim obFIPRCONS As New cla_FIPRCONS
            Dim dtFIPRCONS As New DataTable

            dtFIPRCONS = obFIPRCONS.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(Trim(stFICHA))

            If dtFIPRCONS.Rows.Count = 0 Then
                boFICHAAPTOCASA = False
            Else
                Dim i As Integer = 0

                For i = 0 To dtFIPRCONS.Rows.Count - 1

                    Dim stIDENTIFICADOR As String = Trim(dtFIPRCONS.Rows(i).Item("FPCOTICO").ToString)

                    If Trim(stIDENTIFICADOR) = "039" Or _
                       Trim(stIDENTIFICADOR) = "036" Or _
                       Trim(stIDENTIFICADOR) = "043" Or _
                       Trim(stIDENTIFICADOR) = "045" Or _
                       Trim(stIDENTIFICADOR) = "047" Or _
                       Trim(stIDENTIFICADOR) = "001" Or _
                       Trim(stIDENTIFICADOR) = "002" Or _
                       Trim(stIDENTIFICADOR) = "003" Then

                        boFICHAAPTOCASA = True
                    End If

                Next

            End If

            Return boFICHAAPTOCASA

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ContarPrediosPorTipoDeCalificacion(ByVal stFIPRDEPA As String, ByVal stFIPRMUNI As String, ByVal inFIPRCLSE As Integer, ByVal stTIPOCALI As String, ByVal inVIGEPROY As Integer) As Integer

        Try
            ' declara la variable
            Dim inCAntidad As Integer = 0

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            Dim dt_Cantidad As New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "SELECT COUNT(1) "
            ParametrosConsulta += "FROM FICHPRED, HISTLIQU  WHERE "
            ParametrosConsulta += "FIPRNUFI = HILINUFI and "
            ParametrosConsulta += "FIPRDEPA = '" & CStr(Trim(stFIPRDEPA)) & "' AND "
            ParametrosConsulta += "FIPRMUNI = '" & CStr(Trim(stFIPRMUNI)) & "' AND "
            ParametrosConsulta += "FIPRCLSE = '" & CInt(inFIPRCLSE) & "' AND "
            ParametrosConsulta += "HILIVIGE = '" & CInt(inVIGEPROY) & "' AND "

            If Trim(stTIPOCALI) = "R" Then
                ParametrosConsulta += "HILITIPO = '" & CStr(Trim(stTIPOCALI)) & "' "

            ElseIf Trim(stTIPOCALI) = "C" Or Trim(stTIPOCALI) = "I" Then
                ParametrosConsulta += "HILITIPO IN ('C','I') "

            End If

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_Cantidad)

            ' cierra la conexion
            oConexion.Close()

            If dt_Cantidad.Rows.Count > 0 Then
                inCAntidad = CInt(dt_Cantidad.Rows(0).Item(0))
            End If

            Return inCAntidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

#Region "RANGO DE AVALUO POR ESTRATO"

    Private Sub pro_ProyeccionLiquidacionAvaluoPorEstrato()

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boPOINDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOLIDEPA)
            Dim boPOINMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOLIMUNI)
            Dim boPOINCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOLICLSE)
            Dim boPOINVIAC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOLIVIAC)
            Dim boPOINVIPR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOLIVIPR)
            Dim boPOINTIPO As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOLITIPO)
            Dim boPOINESTR As Boolean = False
            Dim boPOINRAAV As Boolean = False

            ' valida el rango segun el tipo
            If Me.cboCOLITIPO.SelectedValue = "R" Then
                boPOINRAAV = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOLIRAAV_R)
                boPOINESTR = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOLIESTR)

            ElseIf (Me.cboCOLITIPO.SelectedValue = "C" Or Me.cboCOLITIPO.SelectedValue = "I") Then
                boPOINRAAV = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOLIRAAV_C)
                boPOINESTR = True

            End If

            ' valida los parametros
            If boPOINDEPA = True And _
               boPOINMUNI = True And _
               boPOINCLSE = True And _
               boPOINVIAC = True And _
               boPOINVIPR = True And _
               boPOINTIPO = True And _
               boPOINESTR = True And _
               boPOINRAAV = True Then

                ' consulta los predios
                pro_ConsultaDePrediosAvaluoPorEstrato()

                ' cuenta los registros
                If dtConsultaDePrediosPorParametros.Rows.Count > 0 Then

                    If MessageBox.Show("Nro. de registros para cargar :  " & dtConsultaDePrediosPorParametros.Rows.Count & Chr(Keys.Enter) & Chr(Keys.Enter) & _
                                       "¿ Desea continuar ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        ' ejecuta el procedimiento
                        pro_PorcentajeIncrementoAvaluoPorEstrato()

                        ' cantidad de registros
                        Me.lblNroRegistrosConsulta_7.Text = CStr(dtConsultaDePrediosPorParametros.Rows.Count)

                    Else
                        Exit Sub
                    End If

                Else
                    Me.dgvCONSULTA_7.DataSource = New DataTable
                    mod_MENSAJE.Consulta_No_Encontro_Registros()

                End If

                mod_MENSAJE.Proceso_Termino_Correctamente()

                ' Numero de registros recuperados
                Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCONSULTA_1.RowCount.ToString

                Me.dgvCONSULTA_1.Focus()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ConsultaDePrediosAvaluoPorEstrato()

        Try
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
            ParametrosConsulta += "suimnufi as Nro_ficha, "
            ParametrosConsulta += "suimdepa as Departamento, "
            ParametrosConsulta += "suimmuni as Municipio, "
            ParametrosConsulta += "suimclse as Sector, "
            ParametrosConsulta += "a.afsivaba as Avaluo_Actual, "
            ParametrosConsulta += "b.afsivaba as Avaluo_Proyectado, "
            ParametrosConsulta += "a.afsivali as Predial_Actual, "
            ParametrosConsulta += "b.afsivali as Predial_Proyectado, "
            ParametrosConsulta += "hilideec as Destino, "
            ParametrosConsulta += "hilipunt as Puntos, "
            ParametrosConsulta += "hilitipo as Tipo, "
            ParametrosConsulta += "hililote as Lote, "
            ParametrosConsulta += "hiliestr as Estrato "

            ParametrosConsulta += "from aforsuim a, aforsuim b, sujeimpu, histliqu where "

            ParametrosConsulta += "suimnufi = a.afsinufi and "
            ParametrosConsulta += "suimnufi = b.afsinufi and "
            ParametrosConsulta += "a.afsinufi = b.afsinufi and "
            ParametrosConsulta += "suimnufi = hilinufi and "
            ParametrosConsulta += "hilivige = b.afsivige and "

            ParametrosConsulta += "a.afsivaba <> 0 and "
            ParametrosConsulta += "a.afsivali <> 0 and "

            ParametrosConsulta += "suimmuni like '" & stCOLIMUNI & "' and "
            ParametrosConsulta += "suimclse like '" & stCOLICLSE & "' and "
            ParametrosConsulta += "a.afsivige like '" & stCOLIVIAC & "' and "
            ParametrosConsulta += "b.afsivige like '" & stCOLIVIPR & "' and "

            If Trim(stCOLITIPO) = "R" Then
                ParametrosConsulta += "hilitipo like '" & stCOLITIPO & "%' and "

            ElseIf Trim(stCOLITIPO) = "C" Or Trim(stCOLITIPO) = "I" Then
                ParametrosConsulta += "hilitipo IN ('C','I') and "

            End If


            ParametrosConsulta += "hiliestr like '" & stCOLIESTR & "%' and "
            ParametrosConsulta += "b.afsivaba between '" & CLng(vl_loAvaluoInicial) & "' and '" & CLng(vl_loAvaluoFinal) & "' "

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

        If Trim(Me.cboCOLIMUNI.Text) = "" Then
            stCOLIMUNI = "%"
        Else
            stCOLIMUNI = Trim(Me.cboCOLIMUNI.SelectedValue)
        End If

        If Trim(Me.cboCOLICLSE.Text) = "" Then
            stCOLICLSE = "%"
        Else
            stCOLICLSE = Trim(Me.cboCOLICLSE.SelectedValue)
        End If

        If Trim(Me.cboCOLICLCO.Text) = "" Then
            stCOLICLCO = "%"
        Else
            stCOLICLCO = Trim(Me.cboCOLICLCO.SelectedValue)
        End If

        If Trim(Me.cboCOLITICO.Text) = "" Then
            stCOLITICO = "%"
        Else
            stCOLITICO = Trim(Me.cboCOLITICO.SelectedValue)
        End If

        If Trim(Me.cboCOLIZOEC.Text) = "" Then
            stCOLIZOEC = "%"
        Else
            stCOLIZOEC = Trim(Me.cboCOLIZOEC.SelectedValue)
        End If

        If Trim(Me.cboCOLIVIAC.Text) = "" Then
            stCOLIVIAC = "%"
        Else
            stCOLIVIAC = Trim(Me.cboCOLIVIAC.SelectedValue)
        End If

        If Trim(Me.cboCOLIVIPR.Text) = "" Then
            stCOLIVIPR = "%"
        Else
            stCOLIVIPR = Trim(Me.cboCOLIVIPR.SelectedValue)
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

        If Me.chkCOLILOTE.CheckState = CheckState.Indeterminate Then
            stCOLILOTE = "%"
        ElseIf Me.chkCOLILOTE.Checked = False Then
            stCOLILOTE = "0"
        ElseIf Me.chkCOLILOTE.Checked = True Then
            stCOLILOTE = "1"
        End If

        If Me.chkCOLILE44.CheckState = CheckState.Indeterminate Then
            stCOLILE44 = "%"
        ElseIf Me.chkCOLILE44.Checked = False Then
            stCOLILE44 = "0"
        ElseIf Me.chkCOLILE44.Checked = True Then
            stCOLILE44 = "1"
        End If

    End Sub
    Private Sub pro_PorcentajeIncrementoAvaluoPorEstrato()

        Try
            ' verifica que existan datos
            If dtConsultaDePrediosPorParametros.Rows.Count > 0 Then

                ' declara la variable
                Dim stFIPRNUFI As String = ""
                Dim stFIPRDEPA As String = ""
                Dim stFIPRMUNI As String = ""
                Dim stFIPRCLSE As String = ""
                Dim stFIPRAVPR As String = ""
                Dim stFIPRESTR As String = ""
                Dim stFIPRPUNT As String = ""
                Dim stFIPRPRAC As String = ""
                Dim stFIPRTIPO As String = ""

                ' instancia la clase
                Dim obPOINESTR_1 As New cla_POINESTR
                obPOINESTR_1.fun_Eliminar_POINESTR()

                ' Valores predeterminados ProgressBar
                inProceso = 0
                Me.pbPROCESO.Value = 0
                Me.pbPROCESO.Maximum = dtConsultaDePrediosPorParametros.Rows.Count + 1
                Me.Timer1.Enabled = True

                ' declara la variable
                Dim ii As Integer = 0

                ' recorre la tabla
                For ii = 0 To dtConsultaDePrediosPorParametros.Rows.Count - 1

                    ' llenas las variables
                    stFIPRDEPA = Trim(dtConsultaDePrediosPorParametros.Rows(ii).Item(1))
                    stFIPRMUNI = Trim(dtConsultaDePrediosPorParametros.Rows(ii).Item(2))
                    stFIPRCLSE = Trim(dtConsultaDePrediosPorParametros.Rows(ii).Item(3))
                    stFIPRESTR = Trim(dtConsultaDePrediosPorParametros.Rows(ii).Item(12))
                    stFIPRPUNT = Trim(dtConsultaDePrediosPorParametros.Rows(ii).Item(9))
                    stFIPRAVPR = Trim(dtConsultaDePrediosPorParametros.Rows(ii).Item(5))
                    stFIPRPRAC = Trim(dtConsultaDePrediosPorParametros.Rows(ii).Item(6))
                    stFIPRNUFI = Trim(dtConsultaDePrediosPorParametros.Rows(ii).Item(0))
                    stFIPRTIPO = Trim(dtConsultaDePrediosPorParametros.Rows(ii).Item(10))

                    ' valida los datos
                    If fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRDEPA) = True And _
                       fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRMUNI) = True And _
                       fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRCLSE) = True And _
                       fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRESTR) = True And _
                       fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRAVPR) = True And _
                       Trim(stFIPRAVPR) <> "0" And _
                       Trim(stFIPRPRAC) <> "0" Then

                        ' declara la variable
                        Dim obPOINBARR_2 As New cla_POINESTR

                        ' inserta el registro
                        obPOINBARR_2.fun_Insertar_POINESTR(stFIPRDEPA, stFIPRMUNI, stFIPRCLSE, stFIPRAVPR, stFIPRPRAC, stFIPRESTR, stFIPRPUNT)

                    End If

                    inProceso += 1
                    Me.pbPROCESO.Value = inProceso

                Next

                Me.pbPROCESO.Value = 0

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

                ' parametros de la consulta
                Dim ParametrosConsulta As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "Select "
                ParametrosConsulta += "PiesDepa, "
                ParametrosConsulta += "PiesMuni, "
                ParametrosConsulta += "PiesClse, "
                ParametrosConsulta += "PiesEstr, "
                ParametrosConsulta += "PiesAvpr, "
                ParametrosConsulta += "PiesPrpr "
                ParametrosConsulta += "From PoinEstr where "
                ParametrosConsulta += "PiesDepa like '" & Trim(stFIPRDEPA) & "' and "
                ParametrosConsulta += "PiesMuni like '" & Trim(stFIPRMUNI) & "' and "
                ParametrosConsulta += "PiesClse like '" & Trim(stFIPRCLSE) & "'  "

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

                ' verifica la tabla
                If dt.Rows.Count > 0 Then

                    ' crea la tabla
                    Dim dt_PorcentajeIncrementoAvaluoPorEstrato As New DataTable

                    If Trim(Me.cboCOLITIPO.SelectedValue) = "C" Or Trim(Me.cboCOLITIPO.SelectedValue = "I") Then
                        stCOLIESTR = "0"
                    End If

                    ' instancia la clase
                    Dim objTARIRAAV As New cla_TARIRAAV
                    Dim tblTARIRAAV As New DataTable

                    tblTARIRAAV = objTARIRAAV.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_DEEC_ESTR_TIPO_AVIN_AVFI_X_TARIRAAV(stCOLIDEPA, stCOLIMUNI, stCOLICLSE, stCOLIVIPR, "11", stCOLIESTR, stCOLITIPO, vl_loAvaluoInicial, vl_loAvaluoFinal)

                    Dim stTarifaAplicada As String = ""

                    If tblTARIRAAV.Rows.Count > 0 Then
                        stTarifaAplicada = Trim(tblTARIRAAV.Rows(0).Item("TARATARI"))
                    End If

                    ' Crea objeto registros
                    Dim dr1 As DataRow

                    ' Crea las columnas
                    dt_PorcentajeIncrementoAvaluoPorEstrato.Columns.Add(New DataColumn("Estrato", GetType(String)))
                    dt_PorcentajeIncrementoAvaluoPorEstrato.Columns.Add(New DataColumn("Rango_Avaluo", GetType(String)))
                    dt_PorcentajeIncrementoAvaluoPorEstrato.Columns.Add(New DataColumn("Cantidad", GetType(String)))
                    dt_PorcentajeIncrementoAvaluoPorEstrato.Columns.Add(New DataColumn("Porcentaje(%)", GetType(String)))
                    dt_PorcentajeIncrementoAvaluoPorEstrato.Columns.Add(New DataColumn("Tarifa_Aplicada", GetType(String)))
                    dt_PorcentajeIncrementoAvaluoPorEstrato.Columns.Add(New DataColumn("Tarifa_Promedio", GetType(String)))
                    dt_PorcentajeIncrementoAvaluoPorEstrato.Columns.Add(New DataColumn("Tarifa_Minima", GetType(String)))
                    dt_PorcentajeIncrementoAvaluoPorEstrato.Columns.Add(New DataColumn("Tarifa_Maxima", GetType(String)))
                    dt_PorcentajeIncrementoAvaluoPorEstrato.Columns.Add(New DataColumn("Valor_Total_Predial", GetType(String)))
                    dt_PorcentajeIncrementoAvaluoPorEstrato.Columns.Add(New DataColumn("Valor_Total_Avaluo", GetType(String)))

                    ' declara la variable
                    Dim inTotalRegistros As Integer = CInt(dt.Rows.Count)
                    Dim doPromedio As Double = 0
                    Dim doTarifaPromedio As Double = 0.0
                    Dim doTarifaMinima As Double = 16
                    Dim doTarifaMaxima As Double = 1
                    Dim doIncremento As Double = 0.1
                    Dim loAvaluoCatastral As Long = 0
                    Dim loImpuestoPredial As Long = 0
                    Dim loSumaAvaluoCatastral As Long = 0
                    Dim loSumaImpuestoPredial As Long = 0

                    ' Valores predeterminados ProgressBar
                    inProceso = 0
                    Me.pbPROCESO.Value = 0
                    Me.pbPROCESO.Maximum = dt.Rows.Count + 1
                    Me.Timer1.Enabled = True

                    ' declara la variable
                    Dim j1 As Integer = 0

                    For j1 = 0 To dt.Rows.Count - 1

                        ' almacena el avaluo y predial
                        loSumaAvaluoCatastral += CLng(dt.Rows(j1).Item(4))
                        loSumaImpuestoPredial += CLng(dt.Rows(j1).Item(5))

                        ' almacena el avaluo y predial
                        loAvaluoCatastral = CLng(dt.Rows(j1).Item(4))
                        loImpuestoPredial = CLng(dt.Rows(j1).Item(5))

                        ' restablece la tarifa
                        doIncremento = 0.1

                        ' declara la variable
                        Dim sw1 As Byte = 0
                        Dim j4 As Integer = 0

                        While j4 < 160 And sw1 = 0

                            ' incrementa la tarifa
                            doIncremento += 0.1

                            ' genera la liquidacion
                            Dim loLiquidacion As Long = ((loAvaluoCatastral * doIncremento) / 1000)

                            If loLiquidacion >= loImpuestoPredial Then
                                doTarifaPromedio += doIncremento
                                sw1 = 1
                            End If

                            j4 = j4 + 1

                        End While

                        ' tarifa minima
                        If doIncremento < doTarifaMinima Then
                            doTarifaMinima = doIncremento
                        End If

                        ' tarifa maxima
                        If doIncremento > doTarifaMaxima Then
                            doTarifaMaxima = doIncremento
                        End If

                        ' incrementa la barra
                        inProceso += 1
                        Me.pbPROCESO.Value = inProceso

                    Next

                    ' limpia la barra
                    Me.pbPROCESO.Value = 0

                    ' promedia la tarifa
                    doTarifaPromedio = (doTarifaPromedio / dt.Rows.Count)

                    ' declara la variable
                    Dim inCantidadTipo As Integer = fun_ContarPrediosPorTipoDeCalificacion(stCOLIDEPA, stCOLIMUNI, stCOLICLSE, Me.cboCOLITIPO.SelectedValue, Me.cboCOLIVIPR.SelectedValue)
                    Dim inCantidadPredios As Integer = 0
                    Dim stRangoAvaluo As String = ""

                    ' genera el porcentaje
                    If Me.cboCOLITIPO.SelectedValue = "R" Then
                        doPromedio = fun_Formato_Decimal_3_Decimales((dt.Rows.Count * 100) / inCantidadTipo)
                        inCantidadPredios = inCantidadTipo
                        stRangoAvaluo = Trim(Me.cboCOLIRAAV_R.SelectedItem)

                    ElseIf Me.cboCOLITIPO.SelectedValue = "C" Or Me.cboCOLITIPO.SelectedValue = "I" Then
                        doPromedio = fun_Formato_Decimal_3_Decimales((dt.Rows.Count * 100) / inCantidadTipo)
                        inCantidadPredios = inCantidadTipo
                        stRangoAvaluo = Trim(Me.cboCOLIRAAV_C.SelectedItem)
                    End If

                    ' Inserta el registro en el DataTable
                    dr1 = dt_PorcentajeIncrementoAvaluoPorEstrato.NewRow()

                    dr1("Estrato") = Me.cboCOLIESTR.SelectedValue
                    dr1("Rango_Avaluo") = stRangoAvaluo
                    dr1("Cantidad") = dt.Rows.Count & " / " & inCantidadTipo
                    dr1("Porcentaje(%)") = doPromedio
                    dr1("Tarifa_Aplicada") = fun_Formato_Decimal_2_Decimales(stTarifaAplicada)
                    dr1("Tarifa_Promedio") = fun_Formato_Decimal_2_Decimales(doTarifaPromedio)
                    dr1("Tarifa_Minima") = fun_Formato_Decimal_2_Decimales(doTarifaMinima)
                    dr1("Tarifa_Maxima") = fun_Formato_Decimal_2_Decimales(doTarifaMaxima)
                    dr1("Valor_Total_Avaluo") = fun_Formato_Mascara_Pesos(loSumaAvaluoCatastral)
                    dr1("Valor_Total_Predial") = fun_Formato_Mascara_Pesos(loSumaImpuestoPredial)

                    dt_PorcentajeIncrementoAvaluoPorEstrato.Rows.Add(dr1)

                    Me.dgvCONSULTA_7.DataSource = dt_PorcentajeIncrementoAvaluoPorEstrato
                    Me.lblNroRegistrosConsulta_5.Text = CStr(inTotalRegistros)

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_IncrementoAvaluoPorEstratoRango(ByVal stFIPRDEPA As String, ByVal stFIPRMUNI As String, ByVal stFIPRCLSE As String)

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt1 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "* "
            ParametrosConsulta += "From Poinestr where "
            ParametrosConsulta += "PiesDepa like '" & Trim(stFIPRDEPA) & "' and "
            ParametrosConsulta += "PiesMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "PiesClse like '" & Trim(stFIPRCLSE) & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt1)

            ' cierra la conexion
            oConexion.Close()

            Dim inINCREMENTO As Integer = 0

            If dt1.Rows.Count = 0 Then
                stINCREMENTO_MINIMA_RANGO_1 = 0
                stINCREMENTO_MAXIMA_RANGO_1 = 0
                stINCREMENTO_RANGO_1 = 0
            Else
                stINCREMENTO_MINIMA_RANGO_1 = 100
                stINCREMENTO_MAXIMA_RANGO_1 = 0

                Dim i As Integer = 0

                For i = 0 To dt1.Rows.Count - 1

                    inINCREMENTO += CInt(dt1.Rows(i).Item("PIESINPR"))

                    If CInt(dt1.Rows(i).Item("PIESINPR")) > CInt(stINCREMENTO_MAXIMA_RANGO_1) Then
                        stINCREMENTO_MAXIMA_RANGO_1 = CInt(dt1.Rows(i).Item("PIPUINPR"))
                    End If

                    If CInt(dt1.Rows(i).Item("PIESINPR")) < CInt(stINCREMENTO_MINIMA_RANGO_1) Then
                        stINCREMENTO_MINIMA_RANGO_1 = CInt(dt1.Rows(i).Item("PIPUINPR"))
                    End If

                Next

                stINCREMENTO_RANGO_1 = (inINCREMENTO / dt1.Rows.Count)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "RANGO DE AREA POR DESTINACION"

    Private Sub pro_PorcentajeIncrementoPorDestinacion()

        Try
            If Me.dgvCONSULTA_1.RowCount > 0 Then

                Dim dtListadoDePredios As New DataTable
                dtListadoDePredios = Me.dgvCONSULTA_1.DataSource

                Dim stFIPRDEPA As String = ""
                Dim stFIPRMUNI As String = ""
                Dim stFIPRCORR As String = ""
                Dim stFIPRBARR As String = ""
                Dim stFIPRCLSE As String = ""
                Dim stFIPRARTE As String = ""
                Dim stFIPRDEEC As String = ""
                Dim stFIPRDESC As String = ""
                Dim stFIPRCANT As String = ""
                Dim stFIPRINPR As String = ""
                Dim stFIPRINAV As String = ""
                Dim stFIPRAVPR As String = ""
                Dim stFIPRPRPR As String = ""
                Dim stFIPRVIPR As String = ""

                ' instancia la clase
                Dim obPOINPUNT_1 As New cla_POINDEEC
                obPOINPUNT_1.fun_Eliminar_POINDEEC()

                Dim ii As Integer = 0

                For ii = 0 To dtListadoDePredios.Rows.Count - 1

                    stFIPRDEPA = Me.cboCOLIDEPA.SelectedValue
                    stFIPRMUNI = Me.cboCOLIMUNI.SelectedValue
                    stFIPRCLSE = Me.cboCOLICLSE.SelectedValue
                    stFIPRVIPR = Me.cboCOLIVIPR.SelectedValue
                    stFIPRCORR = Trim(dtListadoDePredios.Rows(ii).Item(3))
                    stFIPRBARR = Trim(dtListadoDePredios.Rows(ii).Item(4))
                    stFIPRARTE = Trim(dtListadoDePredios.Rows(ii).Item(28))
                    stFIPRDEEC = Trim(dtListadoDePredios.Rows(ii).Item(20))
                    stFIPRINPR = Trim(dtListadoDePredios.Rows(ii).Item(27))
                    stFIPRINAV = Trim(dtListadoDePredios.Rows(ii).Item(26))

                    If fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRDEEC) = True And
                       Trim(stFIPRAVPR) <> "0" And _
                       Trim(stFIPRPRPR) <> "0" Then

                        Dim obPOINDEEC_2 As New cla_POINDEEC
                        obPOINDEEC_2.fun_Insertar_POINDEEC(stFIPRDEPA, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRCLSE, stFIPRARTE, stFIPRDEEC, stFIPRINPR, stFIPRINAV)

                    End If

                Next

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

                ' parametros de la consulta
                Dim ParametrosConsulta As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "Select "
                ParametrosConsulta += "PideDepa, "
                ParametrosConsulta += "PideMuni, "
                ParametrosConsulta += "PideClse, "
                ParametrosConsulta += "PideDeec, "
                ParametrosConsulta += "count(PideDeec) as PideCant "
                ParametrosConsulta += "From PoinDeec where "
                ParametrosConsulta += "PideDepa like '" & Trim(stFIPRDEPA) & "' and "
                ParametrosConsulta += "PideMuni like '" & Trim(stFIPRMUNI) & "' and "
                ParametrosConsulta += "PideClse like '" & Trim(stFIPRCLSE) & "'  "
                ParametrosConsulta += "group by PideDepa, PideMuni, PideClse, PideDeec "

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

                ' verifica la tabla
                If dt.Rows.Count > 0 Then

                    ' instancia la clase
                    Dim obTARIRAAR As New cla_TARIRAAR
                    Dim dtTARIRAAR As New DataTable

                    dtTARIRAAR = obTARIRAAR.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_X_TARIRAAR(stFIPRDEPA, stFIPRMUNI, stFIPRCLSE, stFIPRVIPR)

                    If dtTARIRAAR.Rows.Count > 0 Then

                        ' crea la tabla
                        Dim dt_PorcentajeIncrementoPorDestinacion As New DataTable

                        ' Crea objeto registros
                        Dim dr1 As DataRow

                        ' Crea las columnas
                        dt_PorcentajeIncrementoPorDestinacion.Columns.Add(New DataColumn("Estadistica por destinación economica y áreas de terreno", GetType(String)))

                        Dim k As Integer = 0

                        For k = 0 To dtTARIRAAR.Rows.Count - 1

                            ' declara las variables
                            Dim stTADEDEEC As String = Trim(dtTARIRAAR.Rows(k).Item("TARADEEC").ToString)
                            Dim stDEECDESC As String = Trim(fun_Buscar_Lista_Valores_DESTECON(stTADEDEEC))
                            Dim stTADEARIN As String = Trim(dtTARIRAAR.Rows(k).Item("TARAAVIN").ToString)
                            Dim stTADEARFI As String = Trim(dtTARIRAAR.Rows(k).Item("TARAAVFI").ToString)
                            Dim stTADETARI As String = Trim(dtTARIRAAR.Rows(k).Item("TARATARI").ToString)

                            ' Crea las columnas
                            'dt_PorcentajeIncrementoPorDestinacion.Columns.Add(New DataColumn("Destino: " & stTADEDEEC & " Rango: " & stTADEARIN & " - " & stTADEARFI, GetType(String)))

                            ' instancia la clase
                            Dim obPOINDEEC As New cla_POINDEEC
                            Dim dtPOINDEEC As New DataTable

                            dtPOINDEEC = obPOINDEEC.fun_Consultar_POINDEEC()

                            If dtPOINDEEC.Rows.Count > 0 Then

                                ' declara las variables
                                Dim inCantidadRegistrosTotales As Integer = dtPOINDEEC.Rows.Count
                                Dim inCantidadRegistrosDestino As Integer = 0
                                Dim inPromedioIncrementoPredial As Integer = 0
                                Dim inPromedioIncrementoAvaluo As Integer = 0
                                Dim inPorcentaje As Integer = 0

                                Dim kk As Integer = 0

                                For kk = 0 To dtPOINDEEC.Rows.Count - 1

                                    If Trim(dtPOINDEEC.Rows(kk).Item("PIDEDEEC").ToString) = Trim(stTADEDEEC) AndAlso _
                                       (CInt(dtPOINDEEC.Rows(kk).Item("PIDEARTE")) >= CInt(stTADEARIN) And _
                                        CInt(dtPOINDEEC.Rows(kk).Item("PIDEARTE")) <= CInt(stTADEARFI)) Then

                                        inCantidadRegistrosDestino += 1
                                        inPromedioIncrementoPredial += CInt(dtPOINDEEC.Rows(kk).Item("PIDEINPR"))
                                        inPromedioIncrementoAvaluo += CInt(dtPOINDEEC.Rows(kk).Item("PIDEINAV"))

                                    End If

                                Next

                                If inCantidadRegistrosDestino <> 0 Then
                                    inPorcentaje = ((100 * inCantidadRegistrosDestino) / inCantidadRegistrosTotales)
                                End If

                                ' Inserta el registro en el DataTable
                                dr1 = dt_PorcentajeIncrementoPorDestinacion.NewRow()

                                'dr1("Destino: " & stTADEDEEC & " Rango: " & stTADEARIN & " - " & stTADEARFI) = "Nro. Fichas: " & inCantidadRegistrosDestino & " / " & inCantidadRegistrosTotales & " - " & "Porcentaje: " & fun_Formato_Decimal_2_Decimales(inPorcentaje) & "(%)" & " - " & "Incremento predial: " & fun_Formato_Decimal_2_Decimales(inPromedioIncrementoPredial / inCantidadRegistrosDestino) & "(%)" & " - " & "Incremento avalúo: " & fun_Formato_Decimal_2_Decimales(inPromedioIncrementoAvaluo / inCantidadRegistrosDestino) & "(%)"
                                dr1("Estadistica por destinación economica y áreas de terreno") = "Destino: " & stTADEDEEC & " - " & stDEECDESC & " - " & "Rango de área m2: (" & fun_Formato_Mascara_Pesos(stTADEARIN) & " - " & fun_Formato_Mascara_Pesos(stTADEARFI) & ") - " & "Nro. Fichas: (" & inCantidadRegistrosDestino & " / " & inCantidadRegistrosTotales & ") - " & "Porcentaje: " & fun_Formato_Decimal_2_Decimales(inPorcentaje) & "(%)" & " - " & "Incremento predial: " & fun_Formato_Decimal_2_Decimales(inPromedioIncrementoPredial / inCantidadRegistrosDestino) & "(%)" & " - " & "Incremento avalúo: " & fun_Formato_Decimal_2_Decimales(inPromedioIncrementoAvaluo / inCantidadRegistrosDestino) & "(%)" & " - " & "Tarifa: " & stTADETARI

                                dt_PorcentajeIncrementoPorDestinacion.Rows.Add(dr1)

                            Else
                                ' Inserta el registro en el DataTable
                                dr1 = dt_PorcentajeIncrementoPorDestinacion.NewRow()

                                dr1("Estadistica por destinación economica y áreas de terreno") = "No existen registros"

                                dt_PorcentajeIncrementoPorDestinacion.Rows.Add(dr1)

                            End If

                        Next

                        Me.dgvCONSULTA_6.DataSource = dt_PorcentajeIncrementoPorDestinacion
                        Me.lblNroRegistrosConsulta_6.Text = Me.dgvCONSULTA_6.RowCount

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "RANGO DE ZONAS ECONOMICAS POR PUNTOS DE CALIFICACION"

    Private Sub pro_ListadoPrediosComparativoLiquidacionAvaluoPorEstrato()

        Try
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

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' verifica los datos de los campos
            pro_VerificarDatosAvaluoPorEstrato()

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "a.afsinufi as Nro_ficha, "
            ParametrosConsulta += "suimdepa as Departamento, "
            ParametrosConsulta += "suimmuni as Municipio, "
            ParametrosConsulta += "suimcorr as Corregi, "
            ParametrosConsulta += "suimbarr as Barrio, "
            ParametrosConsulta += "bavedesc as Descripcion, "
            ParametrosConsulta += "suimmanz as Manzana, "
            ParametrosConsulta += "suimpred as Predio, "
            ParametrosConsulta += "suimedif as Edificio, "
            ParametrosConsulta += "suimunpr as Unidad, "
            ParametrosConsulta += "suimdire as Direccion, "
            ParametrosConsulta += "suimclse as Sector, "
            ParametrosConsulta += "a.afsivaba as Avaluo_Actual, "
            ParametrosConsulta += "b.afsivaba as Avaluo_Proyectado, "
            ParametrosConsulta += "a.afsivali as Predial_Actual, "
            ParametrosConsulta += "b.afsivali as Predial_Proyectado, "
            ParametrosConsulta += "a.afsizo01 as Zona_Actual, "
            ParametrosConsulta += "b.afsizo01 as Zona_Proyectado, "
            ParametrosConsulta += "a.afsita01 as Tarifa_Actual, "
            ParametrosConsulta += "b.afsita01 as Tarifa_Proyectado, "
            ParametrosConsulta += "hilideec as Destino, "
            ParametrosConsulta += "hilipunt as Puntos, "
            ParametrosConsulta += "hilitipo as Tipo, "
            ParametrosConsulta += "hililote as Lote, "
            ParametrosConsulta += "hiliestr as Estrato, "
            ParametrosConsulta += "hilile44 as Ley44, "
            ParametrosConsulta += "((b.afsivaba * 100 / a.afsivaba) -100 ) as Inc_avaluo, "
            ParametrosConsulta += "((b.afsivali * 100 / a.afsivali) -100 ) as Inc_predial, "
            ParametrosConsulta += "hiliarte as Area_Actual_m2 "

            ParametrosConsulta += "from aforsuim a, aforsuim b, sujeimpu, histliqu, mant_barrvere where "

            ParametrosConsulta += "suimdepa = bavedepa and "
            ParametrosConsulta += "suimmuni = bavemuni and "
            ParametrosConsulta += "suimcorr = bavecorr and "
            ParametrosConsulta += "a.afsiclse = baveclse and "
            ParametrosConsulta += "suimbarr = bavecodi and "
            ParametrosConsulta += "a.afsinufi = b.afsinufi and "
            ParametrosConsulta += "a.afsiclse = b.afsiclse and "
            ParametrosConsulta += "suimnufi = a.afsinufi and "
            ParametrosConsulta += "suimnufi = b.afsinufi and "
            ParametrosConsulta += "hilinufi = a.afsinufi and "
            ParametrosConsulta += "hilinufi = b.afsinufi and "
            ParametrosConsulta += "hilinufi = suimnufi and "
            ParametrosConsulta += "b.afsivige = hilivige and "
            ParametrosConsulta += "a.afsivaba <> 0 and "
            ParametrosConsulta += "a.afsivali <> 0 and "

            ParametrosConsulta += "suimmuni like '" & stCOLIMUNI & "' and "
            ParametrosConsulta += "a.afsiclse like '" & stCOLICLSE & "' and "
            ParametrosConsulta += "a.afsivige like '" & stCOLIVIAC & "' and "
            ParametrosConsulta += "b.afsivige like '" & stCOLIVIPR & "' and "
            ParametrosConsulta += "hilitipo like '" & stCOLITIPO & "%' and "
            ParametrosConsulta += "hiliestr like '" & stCOLIESTR & "%' and "
            ParametrosConsulta += "hililote like '" & stCOLILOTE & "' and "
            ParametrosConsulta += "hilile44 like '" & stCOLILE44 & "' and "
            ParametrosConsulta += "hilipunt between '" & Me.nudCOLIPUIN.Value & "' and '" & Me.nudCOLIPUFI.Value & "' "

            ParametrosConsulta += "order by Inc_predial desc "

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

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.cboCOLIDEPA.DataSource = New DataTable
        Me.cboCOLIMUNI.DataSource = New DataTable
        Me.cboCOLICLSE.DataSource = New DataTable
        Me.cboCOLICLCO.DataSource = New DataTable
        Me.cboCOLITICO.DataSource = New DataTable
        Me.cboCOLIESTR.DataSource = New DataTable
        Me.cboCOLIZOEC.DataSource = New DataTable
        Me.cboCOLIVIAC.DataSource = New DataTable
        Me.cboCOLIVIPR.DataSource = New DataTable
        Me.cboCOLITIPO.DataSource = New DataTable
        Me.cboCOLIDEEC.DataSource = New DataTable

        Me.lblCOLIDEPA.Text = ""
        Me.lblCOLIMUNI.Text = ""
        Me.lblCOLICLSE.Text = ""
        Me.lblCOLICLCO.Text = ""
        Me.lblCOLITICO.Text = ""
        Me.lblCOLIESTR.Text = ""
        Me.lblCOLIZOEC.Text = ""
        Me.lblCOLIVIAC.Text = ""
        Me.lblCOLIVIPR.Text = ""
        Me.lblCOLITIPO.Text = ""
        Me.lblCOLIDEEC.Text = ""

        Me.dgvCONSULTA_1.DataSource = New DataTable
        Me.dgvCONSULTA_2.DataSource = New DataTable
        Me.dgvCONSULTA_3.DataSource = New DataTable
        Me.dgvCONSULTA_4.DataSource = New DataTable
        Me.dgvCONSULTA_5.DataSource = New DataTable
        Me.dgvCONSULTA_6.DataSource = New DataTable

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

    End Sub
    Private Sub pro_VerificarDatos()

        If Trim(Me.cboCOLIDEPA.Text) = "" Then
            stCOLIDEPA = "%"
        Else
            stCOLIDEPA = Trim(Me.cboCOLIDEPA.SelectedValue)
        End If

        If Trim(Me.cboCOLIMUNI.Text) = "" Then
            stCOLIMUNI = "%"
        Else
            stCOLIMUNI = Trim(Me.cboCOLIMUNI.SelectedValue)
        End If

        If Trim(Me.cboCOLICLSE.Text) = "" Then
            stCOLICLSE = "%"
        Else
            stCOLICLSE = Trim(Me.cboCOLICLSE.SelectedValue)
        End If

        If Trim(Me.cboCOLICLCO.Text) = "" Then
            stCOLICLCO = "%"
        Else
            stCOLICLCO = Trim(Me.cboCOLICLCO.SelectedValue)
        End If

        If Trim(Me.cboCOLITICO.Text) = "" Then
            stCOLITICO = "%"
        Else
            stCOLITICO = Trim(Me.cboCOLITICO.SelectedValue)
        End If

        If Trim(Me.cboCOLIZOEC.Text) = "" Then
            stCOLIZOEC = "%"
        Else
            stCOLIZOEC = Trim(Me.cboCOLIZOEC.SelectedValue)
        End If

        If Trim(Me.cboCOLIVIAC.Text) = "" Then
            stCOLIVIAC = "%"
        Else
            stCOLIVIAC = Trim(Me.cboCOLIVIAC.SelectedValue)
        End If

        If Trim(Me.cboCOLIVIPR.Text) = "" Then
            stCOLIVIPR = "%"
        Else
            stCOLIVIPR = Trim(Me.cboCOLIVIPR.SelectedValue)
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

        ' rango de avaluo residencial
        If Me.cboCOLIRAAV_R.SelectedIndex = 0 Then
            vl_loAvaluoInicial = 0
            vl_loAvaluoFinal = 15000000

        ElseIf Me.cboCOLIRAAV_R.SelectedIndex = 1 Then
            vl_loAvaluoInicial = 15000001
            vl_loAvaluoFinal = 30000000

        ElseIf Me.cboCOLIRAAV_R.SelectedIndex = 2 Then
            vl_loAvaluoInicial = 15000001
            vl_loAvaluoFinal = 30000000

        ElseIf Me.cboCOLIRAAV_R.SelectedIndex = 3 Then
            vl_loAvaluoInicial = 30000001
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

        If Me.chkCOLILOTE.CheckState = CheckState.Indeterminate Then
            stCOLILOTE = "%"
        ElseIf Me.chkCOLILOTE.Checked = False Then
            stCOLILOTE = "0"
        ElseIf Me.chkCOLILOTE.Checked = True Then
            stCOLILOTE = "1"
        End If

        If Me.chkCOLILE44.CheckState = CheckState.Indeterminate Then
            stCOLILE44 = "%"
        ElseIf Me.chkCOLILE44.Checked = False Then
            stCOLILE44 = "0"
        ElseIf Me.chkCOLILE44.Checked = True Then
            stCOLILE44 = "1"
        End If

    End Sub
    Private Sub pro_ListadoPrediosComparativoLiquidacion()

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            Dim boPOINDEPA As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOLIDEPA)
            Dim boPOINMUNI As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOLIMUNI)
            Dim boPOINCLSE As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOLICLSE)
            Dim boPOINVIAC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOLIVIAC)
            Dim boPOINVIPR As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOLIVIPR)
            Dim boPOINZOEC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOLIZOEC)

            If boPOINDEPA = True And _
               boPOINMUNI = True And _
               boPOINCLSE = True And _
               boPOINVIAC = True And _
               boPOINZOEC = True And _
               boPOINVIPR = True Then

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

                ' parametros de la consulta
                Dim ParametrosConsulta As String = ""

                ' verifica los datos de los campos
                pro_VerificarDatos()

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "Select "
                ParametrosConsulta += "a.afsinufi as Nro_ficha, "
                ParametrosConsulta += "suimdepa as Departamento, "
                ParametrosConsulta += "suimmuni as Municipio, "
                ParametrosConsulta += "suimcorr as Corregi, "
                ParametrosConsulta += "suimbarr as Barrio, "
                ParametrosConsulta += "bavedesc as Descripcion, "
                ParametrosConsulta += "suimmanz as Manzana, "
                ParametrosConsulta += "suimpred as Predio, "
                ParametrosConsulta += "suimedif as Edificio, "
                ParametrosConsulta += "suimunpr as Unidad, "
                ParametrosConsulta += "suimdire as Direccion, "
                ParametrosConsulta += "suimclse as Sector, "
                ParametrosConsulta += "a.afsivaba as Avaluo_Actual, "
                ParametrosConsulta += "b.afsivaba as Avaluo_Proyectado, "
                ParametrosConsulta += "a.afsivali as Predial_Actual, "
                ParametrosConsulta += "b.afsivali as Predial_Proyectado, "
                ParametrosConsulta += "a.afsizo01 as Zona_Actual, "
                ParametrosConsulta += "b.afsizo01 as Zona_Proyectado, "
                ParametrosConsulta += "a.afsita01 as Tarifa_Actual, "
                ParametrosConsulta += "b.afsita01 as Tarifa_Proyectado, "
                ParametrosConsulta += "hilideec as Destino, "
                ParametrosConsulta += "hilipunt as Puntos, "
                ParametrosConsulta += "hilitipo as Tipo, "
                ParametrosConsulta += "hililote as Lote, "
                ParametrosConsulta += "hiliestr as Estrato, "
                ParametrosConsulta += "hilile44 as Ley44, "
                ParametrosConsulta += "((b.afsivaba * 100 / a.afsivaba) -100 ) as Inc_avaluo, "
                ParametrosConsulta += "((b.afsivali * 100 / a.afsivali) -100 ) as Inc_predial, "
                ParametrosConsulta += "hiliarte as Area_Actual_m2 "

                ParametrosConsulta += "from aforsuim a, aforsuim b, sujeimpu, histliqu, mant_barrvere where "

                ParametrosConsulta += "suimdepa = bavedepa and "
                ParametrosConsulta += "suimmuni = bavemuni and "
                ParametrosConsulta += "suimcorr = bavecorr and "
                ParametrosConsulta += "a.afsiclse = baveclse and "
                ParametrosConsulta += "suimbarr = bavecodi and "
                ParametrosConsulta += "a.afsinufi = b.afsinufi and "
                ParametrosConsulta += "a.afsiclse = b.afsiclse and "
                ParametrosConsulta += "suimnufi = a.afsinufi and "
                ParametrosConsulta += "suimnufi = b.afsinufi and "
                ParametrosConsulta += "hilinufi = a.afsinufi and "
                ParametrosConsulta += "hilinufi = b.afsinufi and "
                ParametrosConsulta += "hilinufi = suimnufi and "
                ParametrosConsulta += "b.afsivige = hilivige and "
                ParametrosConsulta += "a.afsivaba <> 0 and "
                ParametrosConsulta += "a.afsivali <> 0 and "

                If Me.cboCOLICLCO.Text <> "" And Me.cboCOLITICO.Text <> "" Then
                    ParametrosConsulta += "exists(select 1 from fiprcons where a.afsinufi = fpconufi and b.afsinufi = fpconufi and suimnufi = fpconufi and hilinufi = fpconufi and fpcoesta = 'ac' and fpcoclco = '" & Me.cboCOLICLCO.SelectedValue & "' and fpcotico = '" & Me.cboCOLITICO.SelectedValue & "') and "
                End If

                If Me.cboCOLIZOEC.Text <> "" Then
                    ParametrosConsulta += "exists(select 1 from histzona where a.afsinufi = hizonufi and b.afsinufi = hizonufi and suimnufi = hizonufi and hilinufi = hizonufi and hizozoec = '" & Me.cboCOLIZOEC.SelectedValue & "' and hizovige = '" & Me.cboCOLIVIPR.SelectedValue & "') and "
                End If

                If Me.cboCOLIDEEC.Text <> "" Then
                    ParametrosConsulta += "exists(select 1 from histliqu where a.afsinufi = hilinufi and b.afsinufi = hilinufi and suimnufi = hilinufi and hilideec like '" & Me.cboCOLIDEEC.SelectedValue & "%') and "
                End If

                ParametrosConsulta += "suimmuni like '" & stCOLIMUNI & "' and "
                ParametrosConsulta += "a.afsiclse like '" & stCOLICLSE & "' and "
                ParametrosConsulta += "a.afsivige like '" & stCOLIVIAC & "' and "
                ParametrosConsulta += "b.afsivige like '" & stCOLIVIPR & "' and "
                ParametrosConsulta += "hilitipo like '" & stCOLITIPO & "%' and "
                ParametrosConsulta += "hiliestr like '" & stCOLIESTR & "%' and "
                ParametrosConsulta += "hililote like '" & stCOLILOTE & "' and "
                ParametrosConsulta += "hilile44 like '" & stCOLILE44 & "' and "
                ParametrosConsulta += "hilipunt between '" & Me.nudCOLIPUIN.Value & "' and '" & Me.nudCOLIPUFI.Value & "' "

                ParametrosConsulta += "order by Inc_predial desc "

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

                ' cuenta los registros
                If dt.Rows.Count > 0 Then

                    If MessageBox.Show("Nro. de registros para cargar :  " & dt.Rows.Count & Chr(Keys.Enter) & Chr(Keys.Enter) & _
                                       "¿ Desea continuar ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        ' llena el datagridview
                        Me.dgvCONSULTA_1.DataSource = dt
                        Me.lblNroRegistrosConsulta_1.Text = Me.dgvCONSULTA_1.RowCount
                        Me.dgvCONSULTA_1.Columns("Avaluo_Actual").DefaultCellStyle.Format = "c"
                        Me.dgvCONSULTA_1.Columns("Avaluo_Proyectado").DefaultCellStyle.Format = "c"
                        Me.dgvCONSULTA_1.Columns("Predial_Actual").DefaultCellStyle.Format = "c"
                        Me.dgvCONSULTA_1.Columns("Predial_Proyectado").DefaultCellStyle.Format = "c"

                        ' Valores predeterminados ProgressBar
                        inProceso = 0
                        Me.pbPROCESO.Value = 0
                        Me.pbPROCESO.Maximum = 5
                        Me.Timer1.Enabled = True

                        pro_PorcentajeIncrementoPorBarrio()
                        inProceso += 1
                        Me.pbPROCESO.Value = inProceso

                        pro_PorcentajeIncrementoPorPuntos()
                        inProceso += 1
                        Me.pbPROCESO.Value = inProceso

                        pro_PorcentajeIncrementoPorZona()
                        inProceso += 1
                        Me.pbPROCESO.Value = inProceso

                        pro_PorcentajeIncrementoPorEstrato()
                        inProceso += 1
                        Me.pbPROCESO.Value = inProceso

                        pro_PorcentajeIncrementoPorDestinacion()
                        inProceso += 1
                        Me.pbPROCESO.Value = inProceso

                        Me.pbPROCESO.Value = 0
                    Else
                        Exit Sub
                    End If

                Else
                    Me.dgvCONSULTA_1.DataSource = New DataTable
                    mod_MENSAJE.Consulta_No_Encontro_Registros()

                End If

                mod_MENSAJE.Proceso_Termino_Correctamente()

                ' Numero de registros recuperados
                Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCONSULTA_1.RowCount.ToString

                Me.dgvCONSULTA_1.Focus()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_PorcentajeIncrementoPorBarrio()

        Try
            If Me.dgvCONSULTA_1.RowCount > 0 Then

                Dim dtListadoDePredios As New DataTable
                dtListadoDePredios = Me.dgvCONSULTA_1.DataSource

                Dim stFIPRDEPA As String = ""
                Dim stFIPRMUNI As String = ""
                Dim stFIPRCLSE As String = ""
                Dim stFIPRCORR As String = ""
                Dim stFIPRBARR As String = ""
                Dim stFIPRDESC As String = ""
                Dim stFIPRCANT As String = ""
                Dim stFIPRINPR As String = ""
                Dim stFIPRAVPR As String = ""
                Dim stFIPRPRPR As String = ""
                Dim stFIPRTIPO As String = ""

                ' instancia la clase
                Dim obPOINBARR_1 As New cla_POINBARR
                obPOINBARR_1.fun_Eliminar_POINBARR()

                Dim ii As Integer = 0

                For ii = 0 To dtListadoDePredios.Rows.Count - 1

                    stFIPRDEPA = Me.cboCOLIDEPA.SelectedValue
                    stFIPRMUNI = Me.cboCOLIMUNI.SelectedValue
                    stFIPRCLSE = Me.cboCOLICLSE.SelectedValue
                    stFIPRCORR = Trim(dtListadoDePredios.Rows(ii).Item(3))
                    stFIPRBARR = Trim(dtListadoDePredios.Rows(ii).Item(4))
                    stFIPRINPR = Trim(dtListadoDePredios.Rows(ii).Item(27))
                    stFIPRAVPR = Trim(dtListadoDePredios.Rows(ii).Item(13))
                    stFIPRPRPR = Trim(dtListadoDePredios.Rows(ii).Item(15))
                    stFIPRTIPO = Trim(dtListadoDePredios.Rows(ii).Item(22))

                    Dim objVerifica As New cla_Verificar_Dato
                    Dim boPOINZOEC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOLIZOEC)

                    If boPOINZOEC = False Then

                        If fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRDEPA) = True And _
                           fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRMUNI) = True And _
                           fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRCLSE) = True And _
                           fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRCORR) = True And _
                           fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRBARR) = True And _
                           Trim(stFIPRAVPR) <> "0" And _
                           Trim(stFIPRPRPR) <> "0" Then

                            Dim obPOINBARR_2 As New cla_POINBARR
                            obPOINBARR_2.fun_Insertar_POINBARR(stFIPRDEPA, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRCLSE, stFIPRINPR)

                        End If

                    ElseIf boPOINZOEC = True Then

                        Dim obTARIZOEC As New cla_TARIZOEC
                        Dim dtTARIZOEC As New DataTable

                        dtTARIZOEC = obTARIZOEC.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_ZOEC_X_TARIZOEC(Me.cboCOLIDEPA.SelectedValue, Me.cboCOLIMUNI.SelectedValue, Me.cboCOLICLSE.SelectedValue, Me.cboCOLIVIPR.SelectedValue, Me.cboCOLIZOEC.SelectedValue)

                        If dtTARIZOEC.Rows.Count > 0 Then

                            Dim stZONA As String = Trim(dtTARIZOEC.Rows(0).Item("TAZEZOEC").ToString)
                            Dim stZONA_APLICADA As String = Trim(dtTARIZOEC.Rows(0).Item("TAZEZOAP").ToString)

                            If Trim(stZONA) = Trim(stZONA_APLICADA) Then

                                If fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRDEPA) = True And _
                                   fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRMUNI) = True And _
                                   fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRCLSE) = True And _
                                   fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRCORR) = True And _
                                   fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRBARR) = True And _
                                   Trim(stFIPRAVPR) <> "0" And _
                                   Trim(stFIPRPRPR) <> "0" Then

                                    Dim obPOINBARR_2 As New cla_POINBARR
                                    obPOINBARR_2.fun_Insertar_POINBARR(stFIPRDEPA, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRCLSE, stFIPRINPR)

                                End If

                            Else

                                If Trim(stFIPRTIPO) = "C" Then

                                    If fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRDEPA) = True And _
                                       fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRMUNI) = True And _
                                       fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRCLSE) = True And _
                                       fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRCORR) = True And _
                                       fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRBARR) = True And _
                                       Trim(stFIPRAVPR) <> "0" And _
                                       Trim(stFIPRPRPR) <> "0" Then

                                        Dim obPOINBARR_2 As New cla_POINBARR
                                        obPOINBARR_2.fun_Insertar_POINBARR(stFIPRDEPA, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRCLSE, stFIPRINPR)

                                    End If

                                End If

                            End If

                        End If

                    End If

                Next

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

                ' parametros de la consulta
                Dim ParametrosConsulta As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "Select "
                ParametrosConsulta += "PibaDepa, "
                ParametrosConsulta += "PibaMuni, "
                ParametrosConsulta += "PibaCorr, "
                ParametrosConsulta += "PibaBarr, "
                ParametrosConsulta += "PibaClse, "
                ParametrosConsulta += "PibaInpr, "
                ParametrosConsulta += "count(PibaInpr) as PibaCant "
                ParametrosConsulta += "From PoinBarr where "
                ParametrosConsulta += "PibaDepa like '" & Trim(stFIPRDEPA) & "' and "
                ParametrosConsulta += "PibaMuni like '" & Trim(stFIPRMUNI) & "' and "
                ParametrosConsulta += "PibaClse like '" & Trim(stFIPRCLSE) & "'  "
                ParametrosConsulta += "group by PibaDepa, PibaMuni, PibaCorr, PibaBarr, PibaClse, PibaInpr "

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

                ' verifica la tabla
                If dt.Rows.Count > 0 Then

                    ' crea la tabla
                    Dim dt_PorcentajeIncrementoPorBarrio As New DataTable

                    ' Crea objeto registros
                    Dim dr1 As DataRow

                    ' Crea las columnas
                    dt_PorcentajeIncrementoPorBarrio.Columns.Add(New DataColumn("Departamento", GetType(String)))
                    dt_PorcentajeIncrementoPorBarrio.Columns.Add(New DataColumn("Municipio", GetType(String)))
                    dt_PorcentajeIncrementoPorBarrio.Columns.Add(New DataColumn("Sector", GetType(String)))
                    dt_PorcentajeIncrementoPorBarrio.Columns.Add(New DataColumn("Corregimiento", GetType(String)))
                    dt_PorcentajeIncrementoPorBarrio.Columns.Add(New DataColumn("Barrio", GetType(String)))
                    dt_PorcentajeIncrementoPorBarrio.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                    dt_PorcentajeIncrementoPorBarrio.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt_PorcentajeIncrementoPorBarrio.Columns.Add(New DataColumn("Porc_Incre(%)", GetType(Integer)))
                    dt_PorcentajeIncrementoPorBarrio.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                    ' suma la totalidad de los registros encontrados
                    Dim inTotalRegistros As Integer
                    Dim doTotalPorcentaje As Double
                    Dim i As Integer

                    For i = 0 To dt.Rows.Count - 1
                        inTotalRegistros += CType(dt.Rows(i).Item("PibaCant"), Integer)
                    Next

                    ' inserta la consulta agrupada 
                    Dim j As Integer

                    For j = 0 To dt.Rows.Count - 1

                        ' declara las variables
                        Dim stDEPARTAMENTO As String = Trim(dt.Rows(j).Item("PibaDepa"))
                        Dim stMUNICIPIO As String = Trim(dt.Rows(j).Item("PibaMuni"))
                        Dim stCORREGIMIENTO As String = Trim(dt.Rows(j).Item("PibaCorr"))
                        Dim stBARRIO As String = Trim(dt.Rows(j).Item("PibaBarr"))
                        Dim stSECTOR As String = Trim(dt.Rows(j).Item("PibaClse"))
                        Dim stDESCRIPCION As String = Trim(fun_Buscar_Lista_Valores_BARRVERE(stDEPARTAMENTO, stMUNICIPIO, stSECTOR, stBARRIO))
                        Dim stCANTIDAD As String = Trim(dt.Rows(j).Item("PibaCant"))
                        Dim stPORCENTAJE_INC As String = Trim(dt.Rows(j).Item("PibaInpr"))
                        Dim stPORCENTAJE As String = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stCANTIDAD) / inTotalRegistros, Double)))

                        ' suma el porcentaje
                        doTotalPorcentaje += CType(stPORCENTAJE, Double)

                        ' Inserta el registro en el DataTable
                        dr1 = dt_PorcentajeIncrementoPorBarrio.NewRow()

                        dr1("Departamento") = stDEPARTAMENTO
                        dr1("Municipio") = stMUNICIPIO
                        dr1("Sector") = stSECTOR
                        dr1("Corregimiento") = stCORREGIMIENTO
                        dr1("Barrio") = stBARRIO
                        dr1("Descripcion") = stDESCRIPCION
                        dr1("Cantidad") = stCANTIDAD
                        dr1("Porc_Incre(%)") = stPORCENTAJE_INC
                        dr1("Porcentaje(%)") = stPORCENTAJE

                        dt_PorcentajeIncrementoPorBarrio.Rows.Add(dr1)

                    Next

                    Me.dgvCONSULTA_2.DataSource = dt_PorcentajeIncrementoPorBarrio
                    Me.lblNroRegistrosConsulta_2.Text = inTotalRegistros

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_PorcentajeIncrementoPorPuntos()

        Try
            If Me.dgvCONSULTA_1.RowCount > 0 Then

                Dim dtListadoDePredios As New DataTable
                dtListadoDePredios = Me.dgvCONSULTA_1.DataSource

                Dim stFIPRDEPA As String = ""
                Dim stFIPRMUNI As String = ""
                Dim stFIPRCORR As String = ""
                Dim stFIPRBARR As String = ""
                Dim stFIPRCLSE As String = ""
                Dim stFIPRPUNT As String = ""
                Dim stFIPRDESC As String = ""
                Dim stFIPRCANT As String = ""
                Dim stFIPRINPR As String = ""
                Dim stFIPRAVPR As String = ""
                Dim stFIPRPRPR As String = ""
                Dim stFIPRTIPO As String = ""

                ' instancia la clase
                Dim obPOINPUNT_1 As New cla_POINPUNT
                obPOINPUNT_1.fun_Eliminar_POINPUNT()

                Dim ii As Integer = 0

                For ii = 0 To dtListadoDePredios.Rows.Count - 1

                    stFIPRDEPA = Me.cboCOLIDEPA.SelectedValue
                    stFIPRMUNI = Me.cboCOLIMUNI.SelectedValue
                    stFIPRCLSE = Me.cboCOLICLSE.SelectedValue
                    stFIPRCORR = Trim(dtListadoDePredios.Rows(ii).Item(3))
                    stFIPRBARR = Trim(dtListadoDePredios.Rows(ii).Item(4))
                    stFIPRPUNT = Trim(dtListadoDePredios.Rows(ii).Item(21))
                    stFIPRINPR = Trim(dtListadoDePredios.Rows(ii).Item(27))
                    stFIPRAVPR = Trim(dtListadoDePredios.Rows(ii).Item(13))
                    stFIPRPRPR = Trim(dtListadoDePredios.Rows(ii).Item(15))
                    stFIPRTIPO = Trim(dtListadoDePredios.Rows(ii).Item(22))

                    Dim objVerifica As New cla_Verificar_Dato
                    Dim boPOINZOEC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOLIZOEC)

                    If boPOINZOEC = False Then

                        If fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRDEPA) = True And _
                           fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRMUNI) = True And _
                           fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRCLSE) = True And _
                           fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRCORR) = True And _
                           fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRBARR) = True And _
                           fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRPUNT) = True And _
                           Trim(stFIPRAVPR) <> "0" And _
                           Trim(stFIPRPRPR) <> "0" Then

                            Dim obPOINPUNT_2 As New cla_POINPUNT
                            obPOINPUNT_2.fun_Insertar_POINPUNT(stFIPRDEPA, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRCLSE, stFIPRPUNT, stFIPRINPR)

                        End If

                    ElseIf boPOINZOEC = True Then

                        Dim obTARIZOEC As New cla_TARIZOEC
                        Dim dtTARIZOEC As New DataTable

                        dtTARIZOEC = obTARIZOEC.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_ZOEC_X_TARIZOEC(Me.cboCOLIDEPA.SelectedValue, Me.cboCOLIMUNI.SelectedValue, Me.cboCOLICLSE.SelectedValue, Me.cboCOLIVIPR.SelectedValue, Me.cboCOLIZOEC.SelectedValue)

                        If dtTARIZOEC.Rows.Count > 0 Then

                            Dim stZONA As String = Trim(dtTARIZOEC.Rows(0).Item("TAZEZOEC").ToString)
                            Dim stZONA_APLICADA As String = Trim(dtTARIZOEC.Rows(0).Item("TAZEZOAP").ToString)

                            If Trim(stZONA) = Trim(stZONA_APLICADA) Then

                                If fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRDEPA) = True And _
                                   fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRMUNI) = True And _
                                   fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRCLSE) = True And _
                                   fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRCORR) = True And _
                                   fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRBARR) = True And _
                                   fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRPUNT) = True And _
                                   Trim(stFIPRAVPR) <> "0" And _
                                   Trim(stFIPRPRPR) <> "0" Then

                                    Dim obPOINPUNT_2 As New cla_POINPUNT
                                    obPOINPUNT_2.fun_Insertar_POINPUNT(stFIPRDEPA, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRCLSE, stFIPRPUNT, stFIPRINPR)

                                End If

                            Else

                                If Trim(stFIPRTIPO) = "C" Then

                                    If fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRDEPA) = True And _
                                       fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRMUNI) = True And _
                                       fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRCLSE) = True And _
                                       fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRCORR) = True And _
                                       fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRBARR) = True And _
                                       fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRPUNT) = True And _
                                       Trim(stFIPRAVPR) <> "0" And _
                                       Trim(stFIPRPRPR) <> "0" Then

                                        Dim obPOINPUNT_2 As New cla_POINPUNT
                                        obPOINPUNT_2.fun_Insertar_POINPUNT(stFIPRDEPA, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRCLSE, stFIPRPUNT, stFIPRINPR)

                                    End If

                                End If

                            End If

                        End If

                    End If

                Next

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

                ' parametros de la consulta
                Dim ParametrosConsulta As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "Select "
                ParametrosConsulta += "PipuDepa, "
                ParametrosConsulta += "PipuMuni, "
                ParametrosConsulta += "PipuClse "
                ParametrosConsulta += "From PoinPunt where "
                ParametrosConsulta += "PipuDepa like '" & Trim(stFIPRDEPA) & "' and "
                ParametrosConsulta += "PipuMuni like '" & Trim(stFIPRMUNI) & "' and "
                ParametrosConsulta += "PipuClse like '" & Trim(stFIPRCLSE) & "'  "
                ParametrosConsulta += "group by PipuDepa, PipuMuni, PipuClse "

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

                ' verifica la tabla
                If dt.Rows.Count > 0 Then

                    ' limpia las tablas
                    dt_0_al_10 = New DataTable
                    dt_11_al_28 = New DataTable
                    dt_29_al_46 = New DataTable
                    dt_47_al_64 = New DataTable
                    dt_65_al_82 = New DataTable
                    dt_83_al_100 = New DataTable

                    ' declara las variables
                    Dim stDEPA As String = Trim(dt.Rows(0).Item("PipuDepa").ToString)
                    Dim stMUNI As String = Trim(dt.Rows(0).Item("PipuMuni").ToString)
                    Dim stCLSE As String = Trim(dt.Rows(0).Item("PipuClse").ToString)

                    ' llena las tablas
                    pro_GenerarPuntos_0_al_10(stDEPA, stMUNI, stCLSE)
                    pro_GenerarPuntos_11_al_28(stDEPA, stMUNI, stCLSE)
                    pro_GenerarPuntos_29_al_46(stDEPA, stMUNI, stCLSE)
                    pro_GenerarPuntos_47_al_64(stDEPA, stMUNI, stCLSE)
                    pro_GenerarPuntos_65_al_82(stDEPA, stMUNI, stCLSE)
                    pro_GenerarPuntos_83_al_100(stDEPA, stMUNI, stCLSE)

                    ' limpia las tablas
                    dt_0_al_10_INCRPUNT = New DataTable
                    dt_11_al_28_INCRPUNT = New DataTable
                    dt_29_al_46_INCRPUNT = New DataTable
                    dt_47_al_64_INCRPUNT = New DataTable
                    dt_65_al_82_INCRPUNT = New DataTable
                    dt_83_al_100_INCRPUNT = New DataTable

                    ' limpia las variavles
                    stINCREMENTO_RANGO_1 = 0
                    stINCREMENTO_RANGO_2 = 0
                    stINCREMENTO_RANGO_3 = 0
                    stINCREMENTO_RANGO_4 = 0
                    stINCREMENTO_RANGO_5 = 0
                    stINCREMENTO_RANGO_6 = 0

                    stINCREMENTO_MINIMA_RANGO_1 = ""
                    stINCREMENTO_MINIMA_RANGO_2 = ""
                    stINCREMENTO_MINIMA_RANGO_3 = ""
                    stINCREMENTO_MINIMA_RANGO_4 = ""
                    stINCREMENTO_MINIMA_RANGO_5 = ""
                    stINCREMENTO_MINIMA_RANGO_6 = ""

                    stINCREMENTO_MAXIMA_RANGO_1 = ""
                    stINCREMENTO_MAXIMA_RANGO_2 = ""
                    stINCREMENTO_MAXIMA_RANGO_3 = ""
                    stINCREMENTO_MAXIMA_RANGO_4 = ""
                    stINCREMENTO_MAXIMA_RANGO_5 = ""
                    stINCREMENTO_MAXIMA_RANGO_6 = ""

                    ' llena las tablas
                    pro_IncrementoPuntosRango1(stDEPA, stMUNI, stCLSE)
                    pro_IncrementoPuntosRango2(stDEPA, stMUNI, stCLSE)
                    pro_IncrementoPuntosRango3(stDEPA, stMUNI, stCLSE)
                    pro_IncrementoPuntosRango4(stDEPA, stMUNI, stCLSE)
                    pro_IncrementoPuntosRango5(stDEPA, stMUNI, stCLSE)
                    pro_IncrementoPuntosRango6(stDEPA, stMUNI, stCLSE)

                    ' crea la tabla
                    Dim dt_PorcentajeIncrementoPorPuntos As New DataTable

                    ' Crea objeto registros
                    Dim dr1 As DataRow

                    ' Crea las columnas
                    dt_PorcentajeIncrementoPorPuntos.Columns.Add(New DataColumn("Departamento", GetType(String)))
                    dt_PorcentajeIncrementoPorPuntos.Columns.Add(New DataColumn("Municipio", GetType(String)))
                    dt_PorcentajeIncrementoPorPuntos.Columns.Add(New DataColumn("Sector", GetType(String)))
                    dt_PorcentajeIncrementoPorPuntos.Columns.Add(New DataColumn("Rango 1 (0-10) bajo-bajo", GetType(String)))
                    dt_PorcentajeIncrementoPorPuntos.Columns.Add(New DataColumn("Rango 2 (11-28) bajo-medio", GetType(String)))
                    dt_PorcentajeIncrementoPorPuntos.Columns.Add(New DataColumn("Rango 3 (29-46) medio-medio", GetType(String)))
                    dt_PorcentajeIncrementoPorPuntos.Columns.Add(New DataColumn("Rango 4 (47-64) medio-alto", GetType(String)))
                    dt_PorcentajeIncrementoPorPuntos.Columns.Add(New DataColumn("Rango 5 (65-82) alto", GetType(String)))
                    dt_PorcentajeIncrementoPorPuntos.Columns.Add(New DataColumn("Rango 6 (83-100) muy alto", GetType(String)))

                    Dim inTotalRegistros As Integer = 0

                    Dim obTotalRegistros As New cla_POINPUNT
                    Dim dtTotalRegistros As New DataTable

                    dtTotalRegistros = obTotalRegistros.fun_Consultar_POINPUNT()

                    If dtTotalRegistros.Rows.Count > 0 Then
                        inTotalRegistros = dtTotalRegistros.Rows.Count
                    Else
                        inTotalRegistros = 0
                    End If

                    ' declara las variables
                    Dim inCANTIDAD_1 As Integer = 0
                    Dim inCANTIDAD_2 As Integer = 0
                    Dim inCANTIDAD_3 As Integer = 0
                    Dim inCANTIDAD_4 As Integer = 0
                    Dim inCANTIDAD_5 As Integer = 0
                    Dim inCANTIDAD_6 As Integer = 0

                    ' declara la cantidad
                    If dt_0_al_10.Rows.Count = 0 Then
                        inCANTIDAD_1 = 0
                    Else
                        inCANTIDAD_1 = dt_0_al_10.Rows(0).Item(0)
                    End If

                    If dt_11_al_28.Rows.Count = 0 Then
                        inCANTIDAD_2 = 0
                    Else
                        inCANTIDAD_2 = dt_11_al_28.Rows(0).Item(0)
                    End If

                    If dt_29_al_46.Rows.Count = 0 Then
                        inCANTIDAD_3 = 0
                    Else
                        inCANTIDAD_3 = dt_29_al_46.Rows(0).Item(0)
                    End If

                    If dt_47_al_64.Rows.Count = 0 Then
                        inCANTIDAD_4 = 0
                    Else
                        inCANTIDAD_4 = dt_47_al_64.Rows(0).Item(0)
                    End If

                    If dt_65_al_82.Rows.Count = 0 Then
                        inCANTIDAD_5 = 0
                    Else
                        inCANTIDAD_5 = dt_65_al_82.Rows(0).Item(0)
                    End If

                    If dt_83_al_100.Rows.Count = 0 Then
                        inCANTIDAD_6 = 0
                    Else
                        inCANTIDAD_6 = dt_83_al_100.Rows(0).Item(0)
                    End If

                    ' inserta la consulta agrupada 
                    Dim j As Integer

                    For j = 0 To dt.Rows.Count - 1

                        ' declara las variables
                        Dim stDEPARTAMENTO As String = Trim(dt.Rows(j).Item("PipuDepa"))
                        Dim stMUNICIPIO As String = Trim(dt.Rows(j).Item("PipuMuni"))
                        Dim stSECTOR As String = Trim(dt.Rows(j).Item("PipuClse"))
                        Dim stRANGO1 As String = "Nro. Fichas: " & CInt(inCANTIDAD_1) & " / " & inTotalRegistros & " - " & "Porcentaje: " & fun_Formato_Decimal_2_Decimales(Trim(CType((CInt(inCANTIDAD_1) * 100) / inTotalRegistros, Double))) & "(%)" & " - " & "Incremento Predial: " & fun_Formato_Decimal_2_Decimales(Trim(stINCREMENTO_RANGO_1)) & "(%)" & " - " & "Mínimo Incremento: " & fun_Formato_Decimal_2_Decimales(Trim(stINCREMENTO_MINIMA_RANGO_1)) & "(%)" & " - " & "Máximo Incremento: " & fun_Formato_Decimal_2_Decimales(Trim(stINCREMENTO_MAXIMA_RANGO_1)) & "(%)"
                        Dim stRANGO2 As String = "Nro. Fichas: " & CInt(inCANTIDAD_2) & " / " & inTotalRegistros & " - " & "Porcentaje: " & fun_Formato_Decimal_2_Decimales(Trim(CType((CInt(inCANTIDAD_2) * 100) / inTotalRegistros, Double))) & "(%)" & " - " & "Incremento Predial: " & fun_Formato_Decimal_2_Decimales(Trim(stINCREMENTO_RANGO_2)) & "(%)" & " - " & "Mínimo Incremento: " & fun_Formato_Decimal_2_Decimales(Trim(stINCREMENTO_MINIMA_RANGO_2)) & "(%)" & " - " & "Máximo Incremento: " & fun_Formato_Decimal_2_Decimales(Trim(stINCREMENTO_MAXIMA_RANGO_2)) & "(%)"
                        Dim stRANGO3 As String = "Nro. Fichas: " & CInt(inCANTIDAD_3) & " / " & inTotalRegistros & " - " & "Porcentaje: " & fun_Formato_Decimal_2_Decimales(Trim(CType((CInt(inCANTIDAD_3) * 100) / inTotalRegistros, Double))) & "(%)" & " - " & "Incremento Predial: " & fun_Formato_Decimal_2_Decimales(Trim(stINCREMENTO_RANGO_3)) & "(%)" & " - " & "Mínimo Incremento: " & fun_Formato_Decimal_2_Decimales(Trim(stINCREMENTO_MINIMA_RANGO_3)) & "(%)" & " - " & "Máximo Incremento: " & fun_Formato_Decimal_2_Decimales(Trim(stINCREMENTO_MAXIMA_RANGO_3)) & "(%)"
                        Dim stRANGO4 As String = "Nro. Fichas: " & CInt(inCANTIDAD_4) & " / " & inTotalRegistros & " - " & "Porcentaje: " & fun_Formato_Decimal_2_Decimales(Trim(CType((CInt(inCANTIDAD_4) * 100) / inTotalRegistros, Double))) & "(%)" & " - " & "Incremento Predial: " & fun_Formato_Decimal_2_Decimales(Trim(stINCREMENTO_RANGO_4)) & "(%)" & " - " & "Mínimo Incremento: " & fun_Formato_Decimal_2_Decimales(Trim(stINCREMENTO_MINIMA_RANGO_4)) & "(%)" & " - " & "Máximo Incremento: " & fun_Formato_Decimal_2_Decimales(Trim(stINCREMENTO_MAXIMA_RANGO_4)) & "(%)"
                        Dim stRANGO5 As String = "Nro. Fichas: " & CInt(inCANTIDAD_5) & " / " & inTotalRegistros & " - " & "Porcentaje: " & fun_Formato_Decimal_2_Decimales(Trim(CType((CInt(inCANTIDAD_5) * 100) / inTotalRegistros, Double))) & "(%)" & " - " & "Incremento Predial: " & fun_Formato_Decimal_2_Decimales(Trim(stINCREMENTO_RANGO_5)) & "(%)" & " - " & "Mínimo Incremento: " & fun_Formato_Decimal_2_Decimales(Trim(stINCREMENTO_MINIMA_RANGO_5)) & "(%)" & " - " & "Máximo Incremento: " & fun_Formato_Decimal_2_Decimales(Trim(stINCREMENTO_MAXIMA_RANGO_5)) & "(%)"
                        Dim stRANGO6 As String = "Nro. Fichas: " & CInt(inCANTIDAD_6) & " / " & inTotalRegistros & " - " & "Porcentaje: " & fun_Formato_Decimal_2_Decimales(Trim(CType((CInt(inCANTIDAD_6) * 100) / inTotalRegistros, Double))) & "(%)" & " - " & "Incremento Predial: " & fun_Formato_Decimal_2_Decimales(Trim(stINCREMENTO_RANGO_6)) & "(%)" & " - " & "Mínimo Incremento: " & fun_Formato_Decimal_2_Decimales(Trim(stINCREMENTO_MINIMA_RANGO_6)) & "(%)" & " - " & "Máximo Incremento: " & fun_Formato_Decimal_2_Decimales(Trim(stINCREMENTO_MAXIMA_RANGO_6)) & "(%)"

                        ' Inserta el registro en el DataTable
                        dr1 = dt_PorcentajeIncrementoPorPuntos.NewRow()

                        dr1("Departamento") = stDEPARTAMENTO
                        dr1("Municipio") = stMUNICIPIO
                        dr1("Sector") = stSECTOR
                        dr1("Rango 1 (0-10) bajo-bajo") = stRANGO1
                        dr1("Rango 2 (11-28) bajo-medio") = stRANGO2
                        dr1("Rango 3 (29-46) medio-medio") = stRANGO3
                        dr1("Rango 4 (47-64) medio-alto") = stRANGO4
                        dr1("Rango 5 (65-82) alto") = stRANGO5
                        dr1("Rango 6 (83-100) muy alto") = stRANGO6

                        dt_PorcentajeIncrementoPorPuntos.Rows.Add(dr1)

                    Next

                    Me.dgvCONSULTA_3.DataSource = dt_PorcentajeIncrementoPorPuntos
                    Me.lblNroRegistrosConsulta_3.Text = Me.dgvCONSULTA_3.RowCount

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_PorcentajeIncrementoPorZona()

        Try
            If Me.dgvCONSULTA_1.RowCount > 0 Then

                Dim stFIPRDEPA As String = ""
                Dim stFIPRMUNI As String = ""
                Dim stFIPRCLSE As String = ""
                Dim stFIPRCANT As String = ""
                Dim stFIPRINPR As String = ""

                Dim dtListadoDePredios As New DataTable
                dtListadoDePredios = Me.dgvCONSULTA_1.DataSource

                stFIPRDEPA = Me.cboCOLIDEPA.SelectedValue
                stFIPRMUNI = Me.cboCOLIMUNI.SelectedValue
                stFIPRCLSE = Me.cboCOLICLSE.SelectedValue

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

                ' parametros de la consulta
                Dim ParametrosConsulta As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "Select "
                ParametrosConsulta += "PibaDepa, "
                ParametrosConsulta += "PibaMuni, "
                ParametrosConsulta += "PibaClse, "
                ParametrosConsulta += "PibaInpr, "
                ParametrosConsulta += "count(PibaInpr) as PibaCant "
                ParametrosConsulta += "From PoinBarr where "
                ParametrosConsulta += "PibaDepa like '" & Trim(stFIPRDEPA) & "' and "
                ParametrosConsulta += "PibaMuni like '" & Trim(stFIPRMUNI) & "' and "
                ParametrosConsulta += "PibaClse like '" & Trim(stFIPRCLSE) & "'  "
                ParametrosConsulta += "group by PibaDepa, PibaMuni, PibaClse, PibaInpr "

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

                ' verifica la tabla
                If dt.Rows.Count > 0 Then

                    ' crea la tabla
                    Dim dt_PorcentajeIncrementoPorZona As New DataTable

                    ' Crea objeto registros
                    Dim dr1 As DataRow

                    ' Crea las columnas
                    dt_PorcentajeIncrementoPorZona.Columns.Add(New DataColumn("Departamento", GetType(String)))
                    dt_PorcentajeIncrementoPorZona.Columns.Add(New DataColumn("Municipio", GetType(String)))
                    dt_PorcentajeIncrementoPorZona.Columns.Add(New DataColumn("Sector", GetType(String)))
                    dt_PorcentajeIncrementoPorZona.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt_PorcentajeIncrementoPorZona.Columns.Add(New DataColumn("Porc_Incre(%)", GetType(Integer)))
                    dt_PorcentajeIncrementoPorZona.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))

                    ' suma la totalidad de los registros encontrados
                    Dim inTotalRegistros As Integer
                    Dim doTotalPorcentaje As Double
                    Dim i As Integer

                    For i = 0 To dt.Rows.Count - 1
                        inTotalRegistros += CType(dt.Rows(i).Item("PibaCant"), Integer)
                    Next

                    ' inserta la consulta agrupada 
                    Dim j As Integer

                    For j = 0 To dt.Rows.Count - 1

                        ' declara las variables
                        Dim stDEPARTAMENTO As String = Trim(dt.Rows(j).Item("PibaDepa"))
                        Dim stMUNICIPIO As String = Trim(dt.Rows(j).Item("PibaMuni"))
                        Dim stSECTOR As String = Trim(dt.Rows(j).Item("PibaClse"))
                        Dim stCANTIDAD As String = Trim(dt.Rows(j).Item("PibaCant"))
                        Dim stPORCENTAJE_INC As String = Trim(dt.Rows(j).Item("PibaInpr"))
                        Dim stPORCENTAJE As String = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stCANTIDAD) / inTotalRegistros, Double)))

                        ' suma el porcentaje
                        doTotalPorcentaje += CType(stPORCENTAJE, Double)

                        ' Inserta el registro en el DataTable
                        dr1 = dt_PorcentajeIncrementoPorZona.NewRow()

                        dr1("Departamento") = stDEPARTAMENTO
                        dr1("Municipio") = stMUNICIPIO
                        dr1("Sector") = stSECTOR
                        dr1("Cantidad") = stCANTIDAD
                        dr1("Porc_Incre(%)") = stPORCENTAJE_INC
                        dr1("Porcentaje(%)") = stPORCENTAJE

                        dt_PorcentajeIncrementoPorZona.Rows.Add(dr1)

                    Next

                    Me.dgvCONSULTA_4.DataSource = dt_PorcentajeIncrementoPorZona
                    Me.lblNroRegistrosConsulta_4.Text = inTotalRegistros

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_PorcentajeIncrementoPorEstrato()

        Try
            If Me.dgvCONSULTA_1.RowCount > 0 Then

                Dim dtListadoDePredios As New DataTable
                dtListadoDePredios = Me.dgvCONSULTA_1.DataSource

                Dim stFIPRNUFI As String = ""
                Dim stFIPRDEPA As String = ""
                Dim stFIPRMUNI As String = ""
                Dim stFIPRCLSE As String = ""
                Dim stFIPRAVPR As String = ""
                Dim stFIPRESTR As String = ""
                Dim stFIPRPUNT As String = ""
                Dim stFIPRPRPR As String = ""
                Dim stFIPRTIPO As String = ""

                ' instancia la clase
                Dim obPOINESTR_1 As New cla_POINESTR
                obPOINESTR_1.fun_Eliminar_POINESTR()

                Dim ii As Integer = 0

                For ii = 0 To dtListadoDePredios.Rows.Count - 1

                    stFIPRDEPA = Trim(dtListadoDePredios.Rows(ii).Item(1))
                    stFIPRMUNI = Trim(dtListadoDePredios.Rows(ii).Item(2))
                    stFIPRCLSE = Trim(dtListadoDePredios.Rows(ii).Item(11))
                    stFIPRESTR = Trim(dtListadoDePredios.Rows(ii).Item(24))
                    stFIPRPUNT = Trim(dtListadoDePredios.Rows(ii).Item(21))
                    stFIPRAVPR = Trim(dtListadoDePredios.Rows(ii).Item(13))
                    stFIPRPRPR = Trim(dtListadoDePredios.Rows(ii).Item(15))
                    stFIPRNUFI = Trim(dtListadoDePredios.Rows(ii).Item(0))
                    stFIPRTIPO = Trim(dtListadoDePredios.Rows(ii).Item(22))

                    Dim objVerifica As New cla_Verificar_Dato
                    Dim boPOINZOEC As Boolean = objVerifica.fun_Verificar_Dato_Lleno(Me.cboCOLIZOEC)

                    If boPOINZOEC = False Then

                        ' excluir garajes, cuertos utiles, comercio e industria
                        If Me.chkExcluirParqueaderos.Checked = True Then

                            Dim boAPTOCASA As Boolean = False
                            boAPTOCASA = fun_ConsultarPrediosAptoCasa(stFIPRNUFI)

                            If fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRDEPA) = True And _
                               fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRMUNI) = True And _
                               fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRCLSE) = True And _
                               fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRESTR) = True And _
                               fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRPUNT) = True And _
                               Trim(stFIPRAVPR) <> "0" And _
                               Trim(stFIPRPRPR) <> "0" And
                               boAPTOCASA = True Then

                                Dim obPOINBARR_2 As New cla_POINESTR
                                obPOINBARR_2.fun_Insertar_POINESTR(stFIPRDEPA, stFIPRMUNI, stFIPRCLSE, stFIPRAVPR, stFIPRPRPR, stFIPRESTR, stFIPRPUNT)

                            End If

                            ' incluye todos las construcciones
                        ElseIf Me.chkExcluirParqueaderos.Checked = False Then

                            If fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRDEPA) = True And _
                               fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRMUNI) = True And _
                               fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRCLSE) = True And _
                               fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRESTR) = True And _
                               fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRPUNT) = True And _
                               Trim(stFIPRAVPR) <> "0" And _
                               Trim(stFIPRPRPR) <> "0" Then

                                Dim obPOINBARR_2 As New cla_POINESTR
                                obPOINBARR_2.fun_Insertar_POINESTR(stFIPRDEPA, stFIPRMUNI, stFIPRCLSE, stFIPRAVPR, stFIPRPRPR, stFIPRESTR, stFIPRPUNT)

                            End If

                        End If

                    ElseIf boPOINZOEC = True Then

                        Dim boCOMERCIAL As Boolean = False
                        Dim obTARIZOEC As New cla_TARIZOEC
                        Dim dtTARIZOEC As New DataTable

                        dtTARIZOEC = obTARIZOEC.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_ZOEC_X_TARIZOEC(Me.cboCOLIDEPA.SelectedValue, Me.cboCOLIMUNI.SelectedValue, Me.cboCOLICLSE.SelectedValue, Me.cboCOLIVIPR.SelectedValue, Me.cboCOLIZOEC.SelectedValue)

                        If dtTARIZOEC.Rows.Count > 0 Then

                            Dim stZONA As String = Trim(dtTARIZOEC.Rows(0).Item("TAZEZOEC").ToString)
                            Dim stZONA_APLICADA As String = Trim(dtTARIZOEC.Rows(0).Item("TAZEZOAP").ToString)

                            If Trim(stZONA) <> Trim(stZONA_APLICADA) Then
                                boCOMERCIAL = True
                            End If

                        End If

                        If boCOMERCIAL = True Then

                            If fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRDEPA) = True And _
                               fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRMUNI) = True And _
                               fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRCLSE) = True And _
                               fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRESTR) = True And _
                               fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRPUNT) = True And _
                               Trim(stFIPRAVPR) <> "0" And _
                               Trim(stFIPRPRPR) <> "0" And
                               stFIPRTIPO = "C" Then

                                Dim obPOINBARR_2 As New cla_POINESTR
                                obPOINBARR_2.fun_Insertar_POINESTR(stFIPRDEPA, stFIPRMUNI, stFIPRCLSE, stFIPRAVPR, stFIPRPRPR, stFIPRESTR, stFIPRPUNT)

                            End If

                        ElseIf boCOMERCIAL = False Then

                            ' excluir garajes, cuertos utiles, comercio e industria
                            If Me.chkExcluirParqueaderos.Checked = True Then

                                Dim boAPTOCASA As Boolean = False
                                boAPTOCASA = fun_ConsultarPrediosAptoCasa(stFIPRNUFI)

                                If fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRDEPA) = True And _
                                   fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRMUNI) = True And _
                                   fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRCLSE) = True And _
                                   fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRESTR) = True And _
                                   fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRPUNT) = True And _
                                   Trim(stFIPRAVPR) <> "0" And _
                                   Trim(stFIPRPRPR) <> "0" And
                                   boAPTOCASA = True Then

                                    Dim obPOINBARR_2 As New cla_POINESTR
                                    obPOINBARR_2.fun_Insertar_POINESTR(stFIPRDEPA, stFIPRMUNI, stFIPRCLSE, stFIPRAVPR, stFIPRPRPR, stFIPRESTR, stFIPRPUNT)

                                End If

                                ' incluye todos las construcciones
                            ElseIf Me.chkExcluirParqueaderos.Checked = False Then

                                If fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRDEPA) = True And _
                                   fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRMUNI) = True And _
                                   fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRCLSE) = True And _
                                   fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRESTR) = True And _
                                   fun_Verificar_Dato_Numerico_Evento_Validated(stFIPRPUNT) = True And _
                                   Trim(stFIPRAVPR) <> "0" And _
                                   Trim(stFIPRPRPR) <> "0" Then

                                    Dim obPOINBARR_2 As New cla_POINESTR
                                    obPOINBARR_2.fun_Insertar_POINESTR(stFIPRDEPA, stFIPRMUNI, stFIPRCLSE, stFIPRAVPR, stFIPRPRPR, stFIPRESTR, stFIPRPUNT)

                                End If

                            End If

                        End If

                    End If

                Next

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

                ' parametros de la consulta
                Dim ParametrosConsulta As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "Select "
                ParametrosConsulta += "PiesDepa, "
                ParametrosConsulta += "PiesMuni, "
                ParametrosConsulta += "PiesClse, "
                ParametrosConsulta += "PiesEstr, "
                ParametrosConsulta += "count(PiesEstr) as PiesCant "
                ParametrosConsulta += "From PoinEstr where "
                ParametrosConsulta += "PiesDepa like '" & Trim(stFIPRDEPA) & "' and "
                ParametrosConsulta += "PiesMuni like '" & Trim(stFIPRMUNI) & "' and "
                ParametrosConsulta += "PiesClse like '" & Trim(stFIPRCLSE) & "'  "
                ParametrosConsulta += "group by PiesDepa, PiesMuni, PiesClse, PiesEstr "

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

                ' verifica la tabla
                If dt.Rows.Count > 0 Then

                    ' crea la tabla
                    Dim dt_PorcentajeIncrementoPorEstrato As New DataTable

                    ' Crea objeto registros
                    Dim dr1 As DataRow

                    ' Crea las columnas
                    dt_PorcentajeIncrementoPorEstrato.Columns.Add(New DataColumn("Departamento", GetType(String)))
                    dt_PorcentajeIncrementoPorEstrato.Columns.Add(New DataColumn("Municipio", GetType(String)))
                    dt_PorcentajeIncrementoPorEstrato.Columns.Add(New DataColumn("Sector", GetType(String)))
                    dt_PorcentajeIncrementoPorEstrato.Columns.Add(New DataColumn("Estrato", GetType(Integer)))
                    dt_PorcentajeIncrementoPorEstrato.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                    dt_PorcentajeIncrementoPorEstrato.Columns.Add(New DataColumn("Porcentaje(%)", GetType(Double)))
                    dt_PorcentajeIncrementoPorEstrato.Columns.Add(New DataColumn("Estadistica_1_Avaluos_<_135_SMMLV", GetType(String)))
                    dt_PorcentajeIncrementoPorEstrato.Columns.Add(New DataColumn("Estadistica_2_Avaluos_>_135_SMMLV", GetType(String)))


                    ' suma la totalidad de los registros encontrados
                    Dim inTotalRegistros As Integer
                    Dim i As Integer

                    For i = 0 To dt.Rows.Count - 1
                        inTotalRegistros += CType(dt.Rows(i).Item("PiesCant"), Integer)
                    Next

                    ' inserta la consulta agrupada 
                    Dim j As Integer

                    For j = 0 To dt.Rows.Count - 1

                        ' declara las variables
                        Dim stDEPARTAMENTO As String = Trim(dt.Rows(j).Item("PiesDepa"))
                        Dim stMUNICIPIO As String = Trim(dt.Rows(j).Item("PiesMuni"))
                        Dim stSECTOR As String = Trim(dt.Rows(j).Item("PiesClse"))
                        Dim stESTRATO As String = Trim(dt.Rows(j).Item("PiesEstr"))
                        Dim stCANTIDAD As String = Trim(dt.Rows(j).Item("PiesCant"))
                        Dim stPORCENTAJE As String = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stCANTIDAD) / inTotalRegistros, Double)))
                        Dim stPORCENTAJE_1 As String = "0.00"
                        Dim stPORCENTAJE_2 As String = "0.00"

                        ' limpia las variables
                        vl_inCantidadRegistrosMenor = 0
                        vl_inCantidadRegistrosMayor = 0
                        vl_loPRO_AVALUO_Menor = 0
                        vl_loPRO_AVALUO_Mayor = 0

                        ' llama al procedimiento
                        pro_CantidadFichaMenoresyMayores135Salarios(stDEPARTAMENTO, stMUNICIPIO, stSECTOR, stESTRATO)

                        Dim stCANTIDAD_1 As String = vl_inCantidadRegistrosMenor

                        If vl_inCantidadRegistrosMenor <> 0 And vl_inCantidadRegistrosMayor <> 0 Then
                            stPORCENTAJE_1 = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stCANTIDAD_1) / (vl_inCantidadRegistrosMenor + vl_inCantidadRegistrosMayor), Double)))
                        End If

                        Dim stPRO_AVALUO_1 As String = fun_Formato_Mascara_Pesos_Enteros(vl_loPRO_AVALUO_Menor)

                        Dim stCANTIDAD_2 As String = vl_inCantidadRegistrosMayor

                        If vl_inCantidadRegistrosMenor <> 0 And vl_inCantidadRegistrosMayor <> 0 Then
                            stPORCENTAJE_2 = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stCANTIDAD_2) / (vl_inCantidadRegistrosMenor + vl_inCantidadRegistrosMayor), Double)))
                        End If

                        Dim stPRO_AVALUO_2 As String = fun_Formato_Mascara_Pesos_Enteros(vl_loPRO_AVALUO_Mayor)

                        Dim stESTADITICA_1 As String = "Nro. Fichas: " & "( " & stCANTIDAD_1 & " / " & stCANTIDAD & " ) " & " / " & inTotalRegistros & " - " & "Porcentaje: " & stPORCENTAJE_1 & "(%)" & " - " & "Promedio avalúo: " & stPRO_AVALUO_1 & "($)"
                        Dim stESTADITICA_2 As String = "Nro. Fichas: " & "( " & stCANTIDAD_2 & " / " & stCANTIDAD & " ) " & " / " & inTotalRegistros & " - " & "Porcentaje: " & stPORCENTAJE_2 & "(%)" & " - " & "Promedio avalúo: " & stPRO_AVALUO_2 & "($)"

                        ' Inserta el registro en el DataTable
                        dr1 = dt_PorcentajeIncrementoPorEstrato.NewRow()

                        dr1("Departamento") = stDEPARTAMENTO
                        dr1("Municipio") = stMUNICIPIO
                        dr1("Sector") = stSECTOR
                        dr1("Estrato") = stESTRATO
                        dr1("Cantidad") = stCANTIDAD
                        dr1("Porcentaje(%)") = stPORCENTAJE

                        dr1("Estadistica_1_Avaluos_<_135_SMMLV") = stESTADITICA_1
                        dr1("Estadistica_2_Avaluos_>_135_SMMLV") = stESTADITICA_2

                        dt_PorcentajeIncrementoPorEstrato.Rows.Add(dr1)

                    Next

                    Me.dgvCONSULTA_5.DataSource = dt_PorcentajeIncrementoPorEstrato
                    Me.lblNroRegistrosConsulta_5.Text = inTotalRegistros

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_CantidadFichaMenoresyMayores135Salarios(ByVal stDEPA As String, ByVal stMUNI As String, ByVal stCLSE As String, ByVal stESTR As String)

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            Dim dtTABLA As New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "* "
            ParametrosConsulta += "From PoinEstr where "
            ParametrosConsulta += "PiesDepa like '" & Trim(stDEPA) & "' and "
            ParametrosConsulta += "PiesMuni like '" & Trim(stMUNI) & "' and "
            ParametrosConsulta += "PiesClse like '" & Trim(stCLSE) & "' and "
            ParametrosConsulta += "PiesEstr like '" & Trim(stESTR) & "'  "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtTABLA)

            ' cierra la conexion
            oConexion.Close()

            ' declara las variables
            Dim inCantidadRegistrosMenor As Integer = 0
            Dim inCantidadRegistrosMayor As Integer = 0
            Dim loAVALUO As Long = 0
            Dim loPRO_AVALUO_Menor As Long = 0
            Dim loPRO_AVALUO_Mayor As Long = 0
            Dim loSUM_AVALUO_Menor As Long = 0
            Dim loSUM_AVALUO_Mayor As Long = 0

            ' verifica la tabla
            If dtTABLA.Rows.Count > 0 Then

                ' declara las variables
                Dim i As Integer = 0

                ' recorre la tabla
                For i = 0 To dtTABLA.Rows.Count - 1

                    ' almacena el avalúo
                    loAVALUO = CLng(dtTABLA.Rows(i).Item("PIESAVPR"))

                    ' menor a 80.000.000
                    If CLng(loAVALUO) < CLng(80000000) Then

                        ' almacena el dato
                        inCantidadRegistrosMenor += 1
                        loSUM_AVALUO_Menor += loAVALUO

                        ' mayor a 80.000.000
                    ElseIf CLng(loAVALUO) > CLng(80000000) Then

                        ' almacena el dato
                        inCantidadRegistrosMayor += 1
                        loSUM_AVALUO_Mayor += loAVALUO

                    End If

                Next

                ' promedio de avalúo
                If inCantidadRegistrosMenor <> 0 Then
                    loPRO_AVALUO_Menor = ((loSUM_AVALUO_Menor / inCantidadRegistrosMenor))
                End If
                If inCantidadRegistrosMayor <> 0 Then
                    loPRO_AVALUO_Mayor = ((loSUM_AVALUO_Mayor / inCantidadRegistrosMayor))
                End If

                ' almacena la información a nivel local
                vl_inCantidadRegistrosMenor = inCantidadRegistrosMenor
                vl_inCantidadRegistrosMayor = inCantidadRegistrosMayor
                vl_loPRO_AVALUO_Menor = loPRO_AVALUO_Menor
                vl_loPRO_AVALUO_Mayor = loPRO_AVALUO_Mayor

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_GenerarPuntos_0_al_10(ByVal stFIPRDEPA As String, ByVal stFIPRMUNI As String, ByVal stFIPRCLSE As String)

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt1 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "Count(Pipuidre) as PibaCant "
            ParametrosConsulta += "From Poinpunt where "
            ParametrosConsulta += "PipuDepa like '" & Trim(stFIPRDEPA) & "' and "
            ParametrosConsulta += "PipuMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "PipuClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "PipuPunt between 0 and 10 "
            ParametrosConsulta += "group by PipuDepa, PipuMuni, PipuClse "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt1)

            ' almacena la consulta
            dt_0_al_10 = dt1

            ' cierra la conexion
            oConexion.Close()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GenerarPuntos_11_al_28(ByVal stFIPRDEPA As String, ByVal stFIPRMUNI As String, ByVal stFIPRCLSE As String)

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt2 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "Count(Pipuidre) as PibaCant "
            ParametrosConsulta += "From Poinpunt where "
            ParametrosConsulta += "PipuDepa like '" & Trim(stFIPRDEPA) & "' and "
            ParametrosConsulta += "PipuMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "PipuClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "PipuPunt between 11 and 28 "
            ParametrosConsulta += "group by PipuDepa, PipuMuni, PipuClse "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt2)

            ' almacena la consulta
            dt_11_al_28 = dt2

            ' cierra la conexion
            oConexion.Close()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GenerarPuntos_29_al_46(ByVal stFIPRDEPA As String, ByVal stFIPRMUNI As String, ByVal stFIPRCLSE As String)

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt3 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "Count(Pipuidre) as PibaCant "
            ParametrosConsulta += "From Poinpunt where "
            ParametrosConsulta += "PipuDepa like '" & Trim(stFIPRDEPA) & "' and "
            ParametrosConsulta += "PipuMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "PipuClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "PipuPunt between 29 and 46 "
            ParametrosConsulta += "group by PipuDepa, PipuMuni, PipuClse "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt3)

            ' almacena la consulta
            dt_29_al_46 = dt3

            ' cierra la conexion
            oConexion.Close()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GenerarPuntos_47_al_64(ByVal stFIPRDEPA As String, ByVal stFIPRMUNI As String, ByVal stFIPRCLSE As String)

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt4 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "Count(Pipuidre) as PibaCant "
            ParametrosConsulta += "From Poinpunt where "
            ParametrosConsulta += "PipuDepa like '" & Trim(stFIPRDEPA) & "' and "
            ParametrosConsulta += "PipuMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "PipuClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "PipuPunt between 47 and 64 "
            ParametrosConsulta += "group by PipuDepa, PipuMuni, PipuClse "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt4)

            ' almacena la consulta
            dt_47_al_64 = dt4

            ' cierra la conexion
            oConexion.Close()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GenerarPuntos_65_al_82(ByVal stFIPRDEPA As String, ByVal stFIPRMUNI As String, ByVal stFIPRCLSE As String)

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt5 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "Count(Pipuidre) as PibaCant "
            ParametrosConsulta += "From Poinpunt where "
            ParametrosConsulta += "PipuDepa like '" & Trim(stFIPRDEPA) & "' and "
            ParametrosConsulta += "PipuMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "PipuClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "PipuPunt between 65 and 82 "
            ParametrosConsulta += "group by PipuDepa, PipuMuni, PipuClse "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt5)

            ' almacena la consulta
            dt_65_al_82 = dt5

            ' cierra la conexion
            oConexion.Close()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GenerarPuntos_83_al_100(ByVal stFIPRDEPA As String, ByVal stFIPRMUNI As String, ByVal stFIPRCLSE As String)

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt6 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "Count(Pipuidre) as PibaCant "
            ParametrosConsulta += "From Poinpunt where "
            ParametrosConsulta += "PipuDepa like '" & Trim(stFIPRDEPA) & "' and "
            ParametrosConsulta += "PipuMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "PipuClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "PipuPunt between 83 and 100 "
            ParametrosConsulta += "group by PipuDepa, PipuMuni, PipuClse "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt6)

            ' almacena la consulta
            dt_83_al_100 = dt6

            ' cierra la conexion
            oConexion.Close()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_IncrementoPuntosRango1(ByVal stFIPRDEPA As String, ByVal stFIPRMUNI As String, ByVal stFIPRCLSE As String)

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt1 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "* "
            ParametrosConsulta += "From Poinpunt where "
            ParametrosConsulta += "PipuDepa like '" & Trim(stFIPRDEPA) & "' and "
            ParametrosConsulta += "PipuMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "PipuClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "PipuPunt between 0 and 10 "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt1)

            ' almacena la consulta
            dt_0_al_10_INCRPUNT = dt1

            ' cierra la conexion
            oConexion.Close()

            Dim inINCREMENTO As Integer = 0

            If dt_0_al_10_INCRPUNT.Rows.Count = 0 Then
                stINCREMENTO_MINIMA_RANGO_1 = 0
                stINCREMENTO_MAXIMA_RANGO_1 = 0
                stINCREMENTO_RANGO_1 = 0
            Else
                stINCREMENTO_MINIMA_RANGO_1 = 100
                stINCREMENTO_MAXIMA_RANGO_1 = 0

                Dim i As Integer = 0

                For i = 0 To dt_0_al_10_INCRPUNT.Rows.Count - 1

                    inINCREMENTO += CInt(dt_0_al_10_INCRPUNT.Rows(i).Item("PIPUINPR"))

                    If CInt(dt_0_al_10_INCRPUNT.Rows(i).Item("PIPUINPR")) > CInt(stINCREMENTO_MAXIMA_RANGO_1) Then
                        stINCREMENTO_MAXIMA_RANGO_1 = CInt(dt_0_al_10_INCRPUNT.Rows(i).Item("PIPUINPR"))
                    End If

                    If CInt(dt_0_al_10_INCRPUNT.Rows(i).Item("PIPUINPR")) < CInt(stINCREMENTO_MINIMA_RANGO_1) Then
                        stINCREMENTO_MINIMA_RANGO_1 = CInt(dt_0_al_10_INCRPUNT.Rows(i).Item("PIPUINPR"))
                    End If

                Next

                stINCREMENTO_RANGO_1 = (inINCREMENTO / dt_0_al_10_INCRPUNT.Rows.Count)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_IncrementoPuntosRango2(ByVal stFIPRDEPA As String, ByVal stFIPRMUNI As String, ByVal stFIPRCLSE As String)

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt2 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "* "
            ParametrosConsulta += "From Poinpunt where "
            ParametrosConsulta += "PipuDepa like '" & Trim(stFIPRDEPA) & "' and "
            ParametrosConsulta += "PipuMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "PipuClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "PipuPunt between 11 and 28 "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt2)

            ' almacena la consulta
            dt_11_al_28_INCRPUNT = dt2

            ' cierra la conexion
            oConexion.Close()

            Dim inINCREMENTO As Integer = 0

            If dt_11_al_28_INCRPUNT.Rows.Count = 0 Then
                stINCREMENTO_MINIMA_RANGO_2 = 0
                stINCREMENTO_MAXIMA_RANGO_2 = 0
                stINCREMENTO_RANGO_2 = 0
            Else
                stINCREMENTO_MINIMA_RANGO_2 = 100
                stINCREMENTO_MAXIMA_RANGO_2 = 0

                Dim i As Integer = 0

                For i = 0 To dt_11_al_28_INCRPUNT.Rows.Count - 1

                    inINCREMENTO += CInt(dt_11_al_28_INCRPUNT.Rows(i).Item("PIPUINPR"))

                    If CInt(dt_11_al_28_INCRPUNT.Rows(i).Item("PIPUINPR")) > CInt(stINCREMENTO_MAXIMA_RANGO_2) Then
                        stINCREMENTO_MAXIMA_RANGO_2 = CInt(dt_11_al_28_INCRPUNT.Rows(i).Item("PIPUINPR"))
                    End If

                    If CInt(dt_11_al_28_INCRPUNT.Rows(i).Item("PIPUINPR")) < CInt(stINCREMENTO_MINIMA_RANGO_2) Then
                        stINCREMENTO_MINIMA_RANGO_2 = CInt(dt_11_al_28_INCRPUNT.Rows(i).Item("PIPUINPR"))
                    End If

                Next

                stINCREMENTO_RANGO_2 = (inINCREMENTO / dt_11_al_28_INCRPUNT.Rows.Count)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_IncrementoPuntosRango3(ByVal stFIPRDEPA As String, ByVal stFIPRMUNI As String, ByVal stFIPRCLSE As String)

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt3 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "* "
            ParametrosConsulta += "From Poinpunt where "
            ParametrosConsulta += "PipuDepa like '" & Trim(stFIPRDEPA) & "' and "
            ParametrosConsulta += "PipuMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "PipuClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "PipuPunt between 29 and 46 "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt3)

            ' almacena la consulta
            dt_29_al_46_INCRPUNT = dt3

            ' cierra la conexion
            oConexion.Close()

            Dim inINCREMENTO As Integer = 0

            If dt_29_al_46_INCRPUNT.Rows.Count = 0 Then
                stINCREMENTO_MINIMA_RANGO_3 = 0
                stINCREMENTO_MAXIMA_RANGO_3 = 0
                stINCREMENTO_RANGO_3 = 0
            Else
                stINCREMENTO_MINIMA_RANGO_3 = 100
                stINCREMENTO_MAXIMA_RANGO_3 = 0

                Dim i As Integer = 0

                For i = 0 To dt_29_al_46_INCRPUNT.Rows.Count - 1

                    inINCREMENTO += CInt(dt_29_al_46_INCRPUNT.Rows(i).Item("PIPUINPR"))

                    If CInt(dt_29_al_46_INCRPUNT.Rows(i).Item("PIPUINPR")) > CInt(stINCREMENTO_MAXIMA_RANGO_3) Then
                        stINCREMENTO_MAXIMA_RANGO_3 = CInt(dt_29_al_46_INCRPUNT.Rows(i).Item("PIPUINPR"))
                    End If

                    If CInt(dt_29_al_46_INCRPUNT.Rows(i).Item("PIPUINPR")) < CInt(stINCREMENTO_MINIMA_RANGO_3) Then
                        stINCREMENTO_MINIMA_RANGO_3 = CInt(dt_29_al_46_INCRPUNT.Rows(i).Item("PIPUINPR"))
                    End If

                Next

                stINCREMENTO_RANGO_3 = (inINCREMENTO / dt_29_al_46_INCRPUNT.Rows.Count)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_IncrementoPuntosRango4(ByVal stFIPRDEPA As String, ByVal stFIPRMUNI As String, ByVal stFIPRCLSE As String)

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt4 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "* "
            ParametrosConsulta += "From Poinpunt where "
            ParametrosConsulta += "PipuDepa like '" & Trim(stFIPRDEPA) & "' and "
            ParametrosConsulta += "PipuMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "PipuClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "PipuPunt between 47 and 64 "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt4)

            ' almacena la consulta
            dt_47_al_64_INCRPUNT = dt4

            ' cierra la conexion
            oConexion.Close()

            Dim inINCREMENTO As Integer = 0

            If dt_47_al_64_INCRPUNT.Rows.Count = 0 Then
                stINCREMENTO_MINIMA_RANGO_4 = 0
                stINCREMENTO_MAXIMA_RANGO_4 = 0
                stINCREMENTO_RANGO_4 = 0
            Else
                stINCREMENTO_MINIMA_RANGO_4 = 100
                stINCREMENTO_MAXIMA_RANGO_4 = 0

                Dim i As Integer = 0

                For i = 0 To dt_47_al_64_INCRPUNT.Rows.Count - 1

                    inINCREMENTO += CInt(dt_47_al_64_INCRPUNT.Rows(i).Item("PIPUINPR"))

                    If CInt(dt_47_al_64_INCRPUNT.Rows(i).Item("PIPUINPR")) > CInt(stINCREMENTO_MAXIMA_RANGO_4) Then
                        stINCREMENTO_MAXIMA_RANGO_4 = CInt(dt_47_al_64_INCRPUNT.Rows(i).Item("PIPUINPR"))
                    End If

                    If CInt(dt_47_al_64_INCRPUNT.Rows(i).Item("PIPUINPR")) < CInt(stINCREMENTO_MINIMA_RANGO_4) Then
                        stINCREMENTO_MINIMA_RANGO_4 = CInt(dt_47_al_64_INCRPUNT.Rows(i).Item("PIPUINPR"))
                    End If

                Next

                stINCREMENTO_RANGO_4 = (inINCREMENTO / dt_47_al_64_INCRPUNT.Rows.Count)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_IncrementoPuntosRango5(ByVal stFIPRDEPA As String, ByVal stFIPRMUNI As String, ByVal stFIPRCLSE As String)

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt5 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "* "
            ParametrosConsulta += "From Poinpunt where "
            ParametrosConsulta += "PipuDepa like '" & Trim(stFIPRDEPA) & "' and "
            ParametrosConsulta += "PipuMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "PipuClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "PipuPunt between 65 and 82 "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt5)

            ' almacena la consulta
            dt_65_al_82_INCRPUNT = dt5

            ' cierra la conexion
            oConexion.Close()

            Dim inINCREMENTO As Integer = 0

            If dt_65_al_82_INCRPUNT.Rows.Count = 0 Then
                stINCREMENTO_MINIMA_RANGO_5 = 0
                stINCREMENTO_MAXIMA_RANGO_5 = 0
                stINCREMENTO_RANGO_5 = 0
            Else
                stINCREMENTO_MINIMA_RANGO_5 = 100
                stINCREMENTO_MAXIMA_RANGO_5 = 0

                Dim i As Integer = 0

                For i = 0 To dt_65_al_82_INCRPUNT.Rows.Count - 1

                    inINCREMENTO += CInt(dt_65_al_82_INCRPUNT.Rows(i).Item("PIPUINPR"))

                    If CInt(dt_65_al_82_INCRPUNT.Rows(i).Item("PIPUINPR")) > CInt(stINCREMENTO_MAXIMA_RANGO_5) Then
                        stINCREMENTO_MAXIMA_RANGO_5 = CInt(dt_65_al_82_INCRPUNT.Rows(i).Item("PIPUINPR"))
                    End If

                    If CInt(dt_65_al_82_INCRPUNT.Rows(i).Item("PIPUINPR")) < CInt(stINCREMENTO_MINIMA_RANGO_5) Then
                        stINCREMENTO_MINIMA_RANGO_5 = CInt(dt_65_al_82_INCRPUNT.Rows(i).Item("PIPUINPR"))
                    End If

                Next

                stINCREMENTO_RANGO_5 = (inINCREMENTO / dt_65_al_82_INCRPUNT.Rows.Count)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_IncrementoPuntosRango6(ByVal stFIPRDEPA As String, ByVal stFIPRMUNI As String, ByVal stFIPRCLSE As String)

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt6 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "* "
            ParametrosConsulta += "From Poinpunt where "
            ParametrosConsulta += "PipuDepa like '" & Trim(stFIPRDEPA) & "' and "
            ParametrosConsulta += "PipuMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "PipuClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "PipuPunt between 83 and 100 "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt6)

            ' almacena la consulta
            dt_83_al_100_INCRPUNT = dt6

            ' cierra la conexion
            oConexion.Close()

            Dim inINCREMENTO As Integer = 0

            If dt_83_al_100_INCRPUNT.Rows.Count = 0 Then
                stINCREMENTO_MINIMA_RANGO_6 = 0
                stINCREMENTO_MAXIMA_RANGO_6 = 0
                stINCREMENTO_RANGO_6 = 0
            Else
                stINCREMENTO_MINIMA_RANGO_6 = 100
                stINCREMENTO_MAXIMA_RANGO_6 = 0

                Dim i As Integer = 0

                For i = 0 To dt_83_al_100_INCRPUNT.Rows.Count - 1

                    inINCREMENTO += CInt(dt_83_al_100_INCRPUNT.Rows(i).Item("PIPUINPR"))

                    If CInt(dt_83_al_100_INCRPUNT.Rows(i).Item("PIPUINPR")) > CInt(stINCREMENTO_MAXIMA_RANGO_6) Then
                        stINCREMENTO_MAXIMA_RANGO_6 = CInt(dt_83_al_100_INCRPUNT.Rows(i).Item("PIPUINPR"))
                    End If

                    If CInt(dt_83_al_100_INCRPUNT.Rows(i).Item("PIPUINPR")) < CInt(stINCREMENTO_MINIMA_RANGO_6) Then
                        stINCREMENTO_MINIMA_RANGO_6 = CInt(dt_83_al_100_INCRPUNT.Rows(i).Item("PIPUINPR"))
                    End If

                Next

                stINCREMENTO_RANGO_6 = (inINCREMENTO / dt_83_al_100_INCRPUNT.Rows.Count)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region
  
#End Region

#Region "MENU"

    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            Me.cmdCONSULTAR.Enabled = False

            pro_ProyeccionLiquidacionAvaluoPorEstrato()
            'pro_ListadoPrediosComparativoLiquidacion()

            Me.cmdCONSULTAR.Enabled = True

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click

        Try
            If Me.cboSELECCION.SelectedIndex = 0 Then
                If Me.dgvCONSULTA_1.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvCONSULTA_1.DataSource, DataTable))
                End If
            ElseIf Me.cboSELECCION.SelectedIndex = 1 Then
                If Me.dgvCONSULTA_2.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvCONSULTA_2.DataSource, DataTable))
                End If
            ElseIf Me.cboSELECCION.SelectedIndex = 2 Then
                If Me.dgvCONSULTA_3.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvCONSULTA_3.DataSource, DataTable))
                End If
            ElseIf Me.cboSELECCION.SelectedIndex = 3 Then
                If Me.dgvCONSULTA_4.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvCONSULTA_4.DataSource, DataTable))
                End If
            ElseIf Me.cboSELECCION.SelectedIndex = 4 Then
                If Me.dgvCONSULTA_5.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvCONSULTA_5.DataSource, DataTable))
                End If
            ElseIf Me.cboSELECCION.SelectedIndex = 5 Then
                If Me.dgvCONSULTA_6.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvCONSULTA_6.DataSource, DataTable))
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCOLIDEPA.KeyPress, cboCOLIMUNI.KeyPress, cboCOLICLSE.KeyPress, cboCOLICLSE.KeyPress, cboCOLITICO.KeyPress, cboCOLIESTR.KeyPress, cboCOLIZOEC.KeyPress, cboCOLIVIAC.KeyPress, cboCOLIVIPR.KeyPress, cboCOLITIPO.KeyPress, cboCOLICLCO.KeyPress, cboCOLIDEEC.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub
#End Region

#Region "KeyDown"

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
    Private Sub cboCOLIESTR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOLIESTR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboCOLIESTR, Me.cboCOLIESTR.SelectedIndex)
        End If
    End Sub
    Private Sub cboCOLIZOEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOLIZOEC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON_X_MUNICIPIO_Descripcion(Me.cboCOLIZOEC, Me.cboCOLIZOEC.SelectedIndex, Me.cboCOLIDEPA, Me.cboCOLIMUNI, Me.cboCOLICLSE)
        End If
    End Sub
    Private Sub cboCOLITIPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOLITIPO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboCOLITIPO, Me.cboCOLITIPO.SelectedIndex)
        End If
    End Sub
    Private Sub cboCOLICLCO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOLICLCO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_CLASCONS_Descripcion(Me.cboCOLICLCO, Me.cboCOLICLCO.SelectedIndex)
        End If
    End Sub
    Private Sub cboCOLITICO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOLITICO.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCONS_X_MUNICIPIO_Descripcion(Me.cboCOLITICO, Me.cboCOLITICO.SelectedIndex, Me.cboCOLIDEPA, Me.cboCOLIMUNI, Me.cboCOLICLCO, Me.cboCOLICLSE)
        End If
    End Sub
    Private Sub cboCOLIVIAC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOLIVIAC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboCOLIVIAC, Me.cboCOLIVIAC.SelectedIndex)
        End If
    End Sub
    Private Sub cboCOLIVIPR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOLIVIPR.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboCOLIVIPR, Me.cboCOLIVIPR.SelectedIndex)
        End If
    End Sub
    Private Sub cboCOLIDEEC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCOLIDEEC.KeyDown
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboCOLIDEEC, Me.cboCOLIDEEC.SelectedIndex)
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus, cmdCONSULTAR.GotFocus, cmdLIMPIAR.GotFocus, cmdExportarExcel.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cbo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOLIDEPA.GotFocus, cboCOLIMUNI.GotFocus, cboCOLICLSE.GotFocus, cboCOLICLCO.GotFocus, cboCOLITICO.GotFocus, cboCOLIESTR.GotFocus, cboCOLITIPO.GotFocus, cboCOLIVIAC.GotFocus, cboCOLIVIPR.GotFocus, cboCOLIDEEC.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboCOLIDEPA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOLIDEPA.SelectedIndexChanged
        Me.lblCOLIDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(Me.cboCOLIDEPA), String)

        Me.cboCOLIMUNI.DataSource = New DataTable
        Me.lblCOLIMUNI.Text = ""

        Me.cboCOLICLSE.DataSource = New DataTable
        Me.lblCOLICLSE.Text = ""

        Me.cboCOLIZOEC.DataSource = New DataTable
        Me.lblCOLIZOEC.Text = ""

        Me.cboCOLICLCO.DataSource = New DataTable
        Me.lblCOLICLCO.Text = ""

        Me.cboCOLITICO.DataSource = New DataTable
        Me.lblCOLITICO.Text = ""

    End Sub
    Private Sub cboCOLIMUNI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOLIMUNI.SelectedIndexChanged
        Me.lblCOLIMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(Me.cboCOLIDEPA, Me.cboCOLIMUNI), String)

        Me.cboCOLICLSE.DataSource = New DataTable
        Me.lblCOLICLSE.Text = ""

        Me.cboCOLIZOEC.DataSource = New DataTable
        Me.lblCOLIZOEC.Text = ""

        Me.cboCOLICLCO.DataSource = New DataTable
        Me.lblCOLICLCO.Text = ""

        Me.cboCOLITICO.DataSource = New DataTable
        Me.lblCOLITICO.Text = ""

    End Sub
    Private Sub cboCOLICLSE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOLICLSE.SelectedIndexChanged
        Me.lblCOLICLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT_Codigo(Me.cboCOLICLSE), String)

        Me.cboCOLIZOEC.DataSource = New DataTable
        Me.lblCOLIZOEC.Text = ""

        Me.cboCOLICLCO.DataSource = New DataTable
        Me.lblCOLICLCO.Text = ""

        Me.cboCOLITICO.DataSource = New DataTable
        Me.lblCOLITICO.Text = ""

    End Sub
    Private Sub cboCOLIESTR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOLIESTR.SelectedIndexChanged
        Me.lblCOLIESTR.Text = CType(fun_Buscar_Lista_Valores_ESTRATO_Codigo(Me.cboCOLIESTR), String)
    End Sub
    Private Sub cboCOLIZOEC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOLIZOEC.SelectedIndexChanged
        Me.lblCOLIZOEC.Text = CType(fun_Buscar_Lista_Valores_ZONAECON_Codigo(Me.cboCOLIDEPA, Me.cboCOLIMUNI, Me.cboCOLICLSE, Me.cboCOLIZOEC), String)
    End Sub
    Private Sub cboCOLITIPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOLITIPO.SelectedIndexChanged
        Me.lblCOLITIPO.Text = CType(fun_Buscar_Lista_Valores_TIPOCALI_Codigo(Me.cboCOLITIPO), String)
    End Sub
    Private Sub cboCOLICLCO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOLICLCO.SelectedIndexChanged
        Me.lblCOLICLCO.Text = CType(fun_Buscar_Lista_Valores_CLASCONS_Codigo(Me.cboCOLICLCO), String)

        Me.cboCOLITICO.DataSource = New DataTable
        Me.lblCOLITICO.Text = ""
    End Sub
    Private Sub cboCOLITICO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOLITICO.SelectedIndexChanged
        Me.lblCOLITICO.Text = CType(fun_Buscar_Lista_Valores_TIPOCONS_Codigo(Me.cboCOLIDEPA, Me.cboCOLIMUNI, Me.cboCOLICLCO, Me.cboCOLICLSE, Me.cboCOLITICO), String)
    End Sub
    Private Sub cboCOLIVIAC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOLIVIAC.SelectedIndexChanged
        Me.lblCOLIVIAC.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboCOLIVIAC), String)
    End Sub
    Private Sub cboCOLIVIPR_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOLIVIPR.SelectedIndexChanged
        Me.lblCOLIVIPR.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA_Codigo(Me.cboCOLIVIPR), String)
    End Sub
    Private Sub cboCOLIDEEC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCOLIDEEC.SelectedIndexChanged
        Me.lblCOLIDEEC.Text = CType(fun_Buscar_Lista_Valores_DESTECON_Codigo(Me.cboCOLIDEEC), String)
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
    Private Sub cboCOLIESTR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOLIESTR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ESTRATO_Descripcion(Me.cboCOLIESTR, Me.cboCOLIESTR.SelectedIndex)
    End Sub
    Private Sub cboCOLIZOEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOLIZOEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_ZONAECON_X_MUNICIPIO_Descripcion(Me.cboCOLIZOEC, Me.cboCOLIZOEC.SelectedIndex, Me.cboCOLIDEPA, Me.cboCOLIMUNI, Me.cboCOLICLSE)
    End Sub
    Private Sub cboCOLITIPO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOLITIPO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCALI_Descripcion(Me.cboCOLITIPO, Me.cboCOLITIPO.SelectedIndex)
    End Sub
    Private Sub cboCOLICLCO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOLICLCO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_CLASCONS_Descripcion(Me.cboCOLICLCO, Me.cboCOLICLCO.SelectedIndex)
    End Sub
    Private Sub cboCOLITICO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOLITICO.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_TIPOCONS_X_MUNICIPIO_Descripcion(Me.cboCOLITICO, Me.cboCOLITICO.SelectedIndex, Me.cboCOLIDEPA, Me.cboCOLIMUNI, Me.cboCOLICLCO, Me.cboCOLICLSE)
    End Sub
    Private Sub cboCOLIVIAC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOLIVIAC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboCOLIVIAC, Me.cboCOLIVIAC.SelectedIndex)
    End Sub
    Private Sub cboCOLIVIPR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOLIVIPR.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_VIGENCIA_Descripcion(Me.cboCOLIVIPR, Me.cboCOLIVIPR.SelectedIndex)
    End Sub
    Private Sub cboCOLIDEEC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCOLIDEEC.Click
        fun_Cargar_ComboBox_Con_Datos_Activos_DESTECON_Descripcion(Me.cboCOLIDEEC, Me.cboCOLIDEEC.SelectedIndex)
    End Sub

#End Region

#End Region

End Class