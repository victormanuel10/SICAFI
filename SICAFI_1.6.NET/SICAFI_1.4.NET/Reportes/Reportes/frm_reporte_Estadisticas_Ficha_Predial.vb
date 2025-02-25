Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_reporte_Estadisticas_Ficha_Predial

    '==================================
    '*** ESTADISTICAS FICHA PREDIAL ***
    '==================================

#Region "VARIABLES"

    ' Conexion
    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

    ' Crea objeto de columnas y registros
    Dim dt1 As New DataTable
    Dim dr1 As DataRow

    ' Crea objeto para almacenar puntaje
    Dim inNroConstruccionesTotales As Integer
    Dim dt_0_al_10 As New DataTable
    Dim dt_11_al_28 As New DataTable
    Dim dt_29_al_46 As New DataTable
    Dim dt_47_al_64 As New DataTable
    Dim dt_65_al_82 As New DataTable
    Dim dt_83_al_100 As New DataTable
    Dim stSeparador As String
    Dim dt_FICHPRED As DataTable
    Dim dt_FICHPRED_TOTAL As DataTable

    ' variables verificar datos
    Dim stFIPRFIIN As String = ""
    Dim stFIPRFIFI As String = ""
    Dim stFIPRTIFI As String = ""
    Dim stFIPRDIRE As String = ""
    Dim stFIPRMUNI As String = ""
    Dim stFIPRCORR As String = ""
    Dim stFIPRBARR As String = ""
    Dim stFIPRMANZ As String = ""
    Dim stFIPRPRED As String = ""
    Dim stFIPREDIF As String = ""
    Dim stFIPRUNPR As String = ""
    Dim stFIPRCLSE As String = ""
    Dim stFIPRESTA As String = ""

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_reporte_Estadisticas_Ficha_Predial
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_reporte_Estadisticas_Ficha_Predial
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
        Me.txtFIPRTIFI.Text = "0"
        Me.txtFIPRMUNI.Text = ""
        Me.txtFIPRCORR.Text = ""
        Me.txtFIPRBARR.Text = ""
        Me.txtFIPRMANZ.Text = ""
        Me.txtFIPRPRED.Text = ""
        Me.txtFIPREDIF.Text = ""
        Me.txtFIPRUNPR.Text = ""
        Me.txtFIPRCLSE.Text = ""
        Me.txtFIPRESTA.Text = ""
        Me.txtFIPRESTADISTICO.Text = ""
        Me.cboTIPOREPO.SelectedIndex = 0
        Me.strBARRESTA.Items(2).Text = "Registros : 0"
        Me.lblTotalPorcentaje.Text = ""
        Me.lblTotalRegistros.Text = ""
        Me.cmdGrafico.Enabled = False

        Me.dgvFIPRESTA.DataSource = New DataTable

    End Sub
    Private Sub pro_VerificarDatos()

        If Trim(Me.txtFIPRFIIN.Text) = "" Then
            stFIPRFIIN = "%"
        Else
            stFIPRFIIN = Trim(Me.txtFIPRFIIN.Text)
        End If

        If Trim(Me.txtFIPRFIFI.Text) = "" Then
            stFIPRFIFI = "%"
        Else
            stFIPRFIFI = Trim(Me.txtFIPRFIFI.Text)
        End If

        If Trim(Me.txtFIPRTIFI.Text) = "" Then
            stFIPRTIFI = "%"
        Else
            stFIPRTIFI = Trim(Me.txtFIPRTIFI.Text)
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

        If Trim(Me.txtFIPRCLSE.Text) = "" Then
            stFIPRCLSE = "%"
        Else
            stFIPRCLSE = Trim(Me.txtFIPRCLSE.Text)
        End If

        If Trim(Me.txtFIPRESTA.Text) = "" Then
            stFIPRESTA = "%"
        Else
            stFIPRESTA = Trim(Me.txtFIPRESTA.Text)
        End If

    End Sub

    Private Sub pro_GenerarDestinacionEconomica()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' verifica los datos
            pro_VerificarDatos()

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
            ParametrosConsulta += "FpdeDeec, "
            ParametrosConsulta += "count(FpdeDeec) as FpdeCant "
            ParametrosConsulta += "From FiprDeec, FichPred where "
            ParametrosConsulta += "FiprNufi = FpdeNufi and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FpdeEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "'  "
            ParametrosConsulta += "group by FpdeDeec "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' Crea objeto de columnas y registros
                Dim dt1 As New DataTable
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Destino", GetType(String)))
                dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(String)))

                ' suma la totalidad de los registros encontrados
                Dim inTotalRegistros As Integer
                Dim doTotalPorcentaje As Double
                Dim i As Integer

                For i = 0 To dt.Rows.Count - 1
                    inTotalRegistros += CType(dt.Rows(i).Item("FPDECANT"), Integer)
                Next

                ' inserta la consulta agrupada 
                Dim j As Integer

                For j = 0 To dt.Rows.Count - 1

                    ' declara las variables
                    Dim stFPDEDEEC As String = Trim(dt.Rows(j).Item("FPDEDEEC"))
                    Dim stFPDEDESC As String = fun_Buscar_Lista_Valores_DESTECON(dt.Rows(j).Item("FPDEDEEC"))
                    Dim stFPDECANT As String = Trim(dt.Rows(j).Item("FPDECANT"))
                    Dim stFPDEPORC As String = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stFPDECANT) / inTotalRegistros, Double)))

                    ' suma el porcentaje
                    doTotalPorcentaje += CType(stFPDEPORC, Double)

                    ' inserta el registro campo texto 
                    txtFIPRESTADISTICO.Text += "Destino: " & stFPDEDEEC & " " & stFPDEDESC & _
                                        "Cantidad: " & stFPDECANT & " " & _
                                        "%: " & stFPDEPORC & vbCrLf

                    ' Inserta el registro en el DataTable
                    dr1 = dt1.NewRow()
                    dr1("Destino") = stFPDEDEEC
                    dr1("Descripcion") = stFPDEDESC
                    dr1("Cantidad") = stFPDECANT
                    dr1("Porcentaje(%)") = stFPDEPORC
                    dt1.Rows.Add(dr1)

                Next

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt1

                ' llena los totales
                lblTotalPorcentaje.Text = CType(doTotalPorcentaje, Integer)
                lblTotalRegistros.Text = CType(inTotalRegistros, String)

                ' inserta la totalidad de registros
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & vbCrLf & vbCrLf & "------------------------- "
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & "Total registros: " & inTotalRegistros & " -------------------------"
                strBARRESTA.Items(2).Text = "Registros : " & inTotalRegistros

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_GenerarTipoDeDocumento()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpprTido, "
            ParametrosConsulta += "count(FpprTido) as FpprCant "
            ParametrosConsulta += "From FiprProp, FichPred where "
            ParametrosConsulta += "FiprNufi = FpprNufi and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FpprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "'  "
            ParametrosConsulta += "group by FpprTido "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' Crea objeto de columnas y registros
                Dim dt1 As New DataTable
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Clase Documento", GetType(String)))
                dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(String)))

                ' suma la totalidad de los registros encontrados
                Dim inTotalRegistros As Integer
                Dim doTotalPorcentaje As Double
                Dim i As Integer

                For i = 0 To dt.Rows.Count - 1
                    inTotalRegistros += CType(dt.Rows(i).Item("FPPRCANT"), Integer)
                Next

                ' inserta la consulta agrupada 
                Dim j As Integer

                For j = 0 To dt.Rows.Count - 1

                    ' declara las variables
                    Dim stFPPRTIDO As String = Trim(dt.Rows(j).Item("FPPRTIDO"))
                    Dim stFPPRDESC As String = fun_Buscar_Lista_Valores_TIPODOCU(dt.Rows(j).Item("FPPRTIDO"))
                    Dim stFPPRCANT As String = Trim(dt.Rows(j).Item("FPPRCANT"))
                    Dim stFPPRPORC As String = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stFPPRCANT) / inTotalRegistros, Double)))

                    ' suma el porcentaje
                    doTotalPorcentaje += CType(stFPPRPORC, Double)

                    ' inserta el registro campo texto 
                    txtFIPRESTADISTICO.Text += "Clase documento: " & stFPPRTIDO & " " & stFPPRDESC & _
                                        "Cantidad: " & stFPPRCANT & " " & _
                                        "%: " & stFPPRPORC & vbCrLf

                    ' Inserta el registro en el DataTable
                    dr1 = dt1.NewRow()
                    dr1("Clase Documento") = stFPPRTIDO
                    dr1("Descripcion") = stFPPRDESC
                    dr1("Cantidad") = stFPPRCANT
                    dr1("Porcentaje(%)") = stFPPRPORC
                    dt1.Rows.Add(dr1)

                Next

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt1

                ' llena los totales
                lblTotalPorcentaje.Text = CType(doTotalPorcentaje, Integer)
                lblTotalRegistros.Text = CType(inTotalRegistros, String)

                ' inserta la totalidad de registros
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & vbCrLf & vbCrLf & "------------------------- "
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & "Total registros: " & inTotalRegistros & " -------------------------"
                strBARRESTA.Items(2).Text = "Registros : " & inTotalRegistros

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try
    End Sub
    Private Sub pro_GenerarTipoDeConstruccion()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpcoTico, "
            ParametrosConsulta += "TicoDesc, "
            ParametrosConsulta += "count(FpcoTico) as FpcoCant "
            ParametrosConsulta += "From FiprCons, FichPred, Mant_Tipocons where "
            ParametrosConsulta += "FiprNufi = FpcoNufi and "
            ParametrosConsulta += "FpcoDepa = TicoDepa and "
            ParametrosConsulta += "FpcoMuni = TicoMuni and "
            ParametrosConsulta += "FpcoClco = TicoClco and "
            ParametrosConsulta += "FpcoTico = TicoCodi and "
            ParametrosConsulta += "FiprClse = TicoClse and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FpcoEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' "
            ParametrosConsulta += "group by FpcoTico, TicoDesc "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' Crea objeto de columnas y registros
                Dim dt1 As New DataTable
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Identificador", GetType(String)))
                dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(String)))

                ' suma la totalidad de los registros encontrados
                Dim inTotalRegistros As Integer
                Dim doTotalPorcentaje As Double
                Dim i As Integer

                For i = 0 To dt.Rows.Count - 1
                    inTotalRegistros += CType(dt.Rows(i).Item("FPCOCANT"), Integer)
                Next

                ' inserta la consulta agrupada 
                Dim j As Integer

                For j = 0 To dt.Rows.Count - 1

                    ' declara las variables
                    Dim stFPCOTICO As String = Trim(dt.Rows(j).Item("FPCOTICO"))
                    Dim stFPCODESC As String = Trim(dt.Rows(j).Item("TICODESC"))
                    Dim stFPCOCANT As String = Trim(dt.Rows(j).Item("FPCOCANT"))
                    Dim stFPCOPORC As String = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stFPCOCANT) / inTotalRegistros, Double)))

                    ' suma el porcentaje
                    doTotalPorcentaje += CType(stFPCOPORC, Double)

                    ' inserta el registro campo texto 
                    txtFIPRESTADISTICO.Text += "Identificador: " & stFPCOTICO & " " & stFPCODESC & " " & _
                                        "Cantidad: " & stFPCOCANT & " " & _
                                        "%: " & stFPCOPORC & vbCrLf

                    ' Inserta el registro en el DataTable
                    dr1 = dt1.NewRow()
                    dr1("Identificador") = stFPCOTICO
                    dr1("Descripcion") = stFPCODESC
                    dr1("Cantidad") = stFPCOCANT
                    dr1("Porcentaje(%)") = stFPCOPORC
                    dt1.Rows.Add(dr1)

                Next

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt1

                ' llena los totales
                lblTotalPorcentaje.Text = CType(doTotalPorcentaje, Integer)
                lblTotalRegistros.Text = CType(inTotalRegistros, String)

                ' inserta la totalidad de registros
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & vbCrLf & vbCrLf & "------------------------- "
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & "Total registros: " & inTotalRegistros & " -------------------------"
                strBARRESTA.Items(2).Text = "Registros : " & inTotalRegistros

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try
    End Sub
    Private Sub pro_GenerarZonaEconomica()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpzeZoec, "
            ParametrosConsulta += "ZoecDesc, "
            ParametrosConsulta += "count(FpzeZoec) as FpzeCant "
            ParametrosConsulta += "From FiprZoec, FichPred, Mant_ZonaEcon where "
            ParametrosConsulta += "FiprNufi = FpzeNufi and "
            ParametrosConsulta += "FpzeDepa = ZoecDepa and "
            ParametrosConsulta += "FpzeMuni = ZoecMuni and "
            ParametrosConsulta += "FpzeZoec = ZoecCodi and "
            ParametrosConsulta += "FiprClse = ZoecClse and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FpzeEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' "
            ParametrosConsulta += "group by FpzeZoec, ZoecDesc "

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

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' Crea objeto de columnas y registros
                Dim dt1 As New DataTable
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Zona economica", GetType(String)))
                dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(String)))

                ' suma la totalidad de los registros encontrados
                Dim inTotalRegistros As Integer
                Dim doTotalPorcentaje As Double
                Dim i As Integer

                For i = 0 To dt.Rows.Count - 1
                    inTotalRegistros += CType(dt.Rows(i).Item("FPZECANT"), Integer)
                Next

                ' inserta la consulta agrupada 
                Dim j As Integer

                For j = 0 To dt.Rows.Count - 1

                    ' declara las variables
                    Dim stFPZEZOEC As String = Trim(dt.Rows(j).Item("FPZEZOEC"))
                    Dim stFPZEDESC As String = Trim(dt.Rows(j).Item("ZOECDESC"))
                    Dim stFPZECANT As String = Trim(dt.Rows(j).Item("FPZECANT"))
                    Dim stFPZEPORC As String = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stFPZECANT) / inTotalRegistros, Double)))

                    ' suma el porcentaje
                    doTotalPorcentaje += CType(stFPZEPORC, Double)

                    ' inserta el registro campo texto 
                    txtFIPRESTADISTICO.Text += "Zona economica: " & stFPZEZOEC & " " & stFPZEDESC & " " & _
                                        "Cantidad: " & stFPZECANT & " " & _
                                        "%: " & stFPZEPORC & vbCrLf

                    ' Inserta el registro en el DataTable
                    dr1 = dt1.NewRow()
                    dr1("Zona economica") = stFPZEZOEC
                    dr1("Descripcion") = stFPZEDESC
                    dr1("Cantidad") = stFPZECANT
                    dr1("Porcentaje(%)") = stFPZEPORC
                    dt1.Rows.Add(dr1)

                Next

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt1

                ' llena los totales
                lblTotalPorcentaje.Text = CType(doTotalPorcentaje, Integer)
                lblTotalRegistros.Text = CType(inTotalRegistros, String)

                ' inserta la totalidad de registros
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & vbCrLf & vbCrLf & "------------------------- "
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & "Total registros: " & inTotalRegistros & " -------------------------"
                strBARRESTA.Items(2).Text = "Registros : " & inTotalRegistros

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try
    End Sub
    Private Sub pro_GenerarZonaFisica()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpzfZofi, "
            ParametrosConsulta += "ZofiDesc, "
            ParametrosConsulta += "count(FpzfZofi) as FpzfCant "
            ParametrosConsulta += "From FiprZofi, FichPred, Mant_ZonaFisi where "
            ParametrosConsulta += "FiprNufi = FpzfNufi and "
            ParametrosConsulta += "FpzfDepa = ZofiDepa and "
            ParametrosConsulta += "FpzfMuni = ZofiMuni and "
            ParametrosConsulta += "FpzfZofi = ZofiCodi and "
            ParametrosConsulta += "FiprClse = ZofiClse and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FpzfEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' "
            ParametrosConsulta += "group by FpzfZofi, ZofiDesc "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' Crea objeto de columnas y registros
                Dim dt1 As New DataTable
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Zona fisica", GetType(String)))
                dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(String)))

                ' suma la totalidad de los registros encontrados
                Dim inTotalRegistros As Integer
                Dim doTotalPorcentaje As Double
                Dim i As Integer

                For i = 0 To dt.Rows.Count - 1
                    inTotalRegistros += CType(dt.Rows(i).Item("FPZFCANT"), Integer)
                Next

                ' inserta la consulta agrupada 
                Dim j As Integer

                For j = 0 To dt.Rows.Count - 1

                    ' declara las variables
                    Dim stFPZFZOFI As String = Trim(dt.Rows(j).Item("FPZFZOFI"))
                    Dim stFPZFDESC As String = Trim(dt.Rows(j).Item("ZOFIDESC"))
                    Dim stFPZFCANT As String = Trim(dt.Rows(j).Item("FPZFCANT"))
                    Dim stFPZFPORC As String = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stFPZFCANT) / inTotalRegistros, Double)))

                    ' suma el porcentaje
                    doTotalPorcentaje += CType(stFPZFPORC, Double)

                    ' inserta el registro campo texto 
                    txtFIPRESTADISTICO.Text += "Zona fisica: " & stFPZFZOFI & " " & stFPZFDESC & " " & _
                                        "Cantidad: " & stFPZFCANT & " " & _
                                        "%: " & stFPZFPORC & vbCrLf

                    ' Inserta el registro en el DataTable
                    dr1 = dt1.NewRow()
                    dr1("Zona fisica") = stFPZFZOFI
                    dr1("Descripcion") = stFPZFDESC
                    dr1("Cantidad") = stFPZFCANT
                    dr1("Porcentaje(%)") = stFPZFPORC
                    dt1.Rows.Add(dr1)

                Next

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt1

                ' llena los totales
                lblTotalPorcentaje.Text = CType(doTotalPorcentaje, Integer)
                lblTotalRegistros.Text = CType(inTotalRegistros, String)

                ' inserta la totalidad de registros
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & vbCrLf & vbCrLf & "------------------------- "
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & "Total registros: " & inTotalRegistros & " -------------------------"
                strBARRESTA.Items(2).Text = "Registros : " & inTotalRegistros

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try
    End Sub
    Private Sub pro_GenerarModoDeAdquisicion()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprMoad, "
            ParametrosConsulta += "count(FiprMoad) as FiprCant "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' "
            ParametrosConsulta += "group by FiprMoad "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' Crea objeto de columnas y registros
                Dim dt1 As New DataTable
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Modo adquisicion", GetType(String)))
                dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(String)))

                ' suma la totalidad de los registros encontrados
                Dim inTotalRegistros As Integer
                Dim doTotalPorcentaje As Double
                Dim i As Integer

                For i = 0 To dt.Rows.Count - 1
                    inTotalRegistros += CType(dt.Rows(i).Item("FIPRCANT"), Integer)
                Next

                ' inserta la consulta agrupada 
                Dim j As Integer

                For j = 0 To dt.Rows.Count - 1

                    ' declara las variables
                    Dim stFIPRMOAD As String = Trim(dt.Rows(j).Item("FIPRMOAD"))
                    Dim stFIPRDESC As String = fun_Buscar_Lista_Valores_MODOADQU(dt.Rows(j).Item("FIPRMOAD"))
                    Dim stFIPRCANT As String = Trim(dt.Rows(j).Item("FIPRCANT"))
                    Dim stFIPRPORC As String = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stFIPRCANT) / inTotalRegistros, Double)))

                    ' suma el porcentaje
                    doTotalPorcentaje += CType(stFIPRPORC, Double)

                    ' inserta el registro campo texto 
                    txtFIPRESTADISTICO.Text += "Modo adquisicion: " & stFIPRMOAD & " " & stFIPRDESC & " " & _
                                        "Cantidad: " & stFIPRCANT & " " & _
                                        "%: " & stFIPRPORC & vbCrLf

                    ' Inserta el registro en el DataTable
                    dr1 = dt1.NewRow()
                    dr1("Modo adquisicion") = stFIPRMOAD
                    dr1("Descripcion") = stFIPRDESC
                    dr1("Cantidad") = stFIPRCANT
                    dr1("Porcentaje(%)") = stFIPRPORC
                    dt1.Rows.Add(dr1)

                Next

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt1

                ' llena los totales
                lblTotalPorcentaje.Text = CType(doTotalPorcentaje, Integer)
                lblTotalRegistros.Text = CType(inTotalRegistros, String)

                ' inserta la totalidad de registros
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & vbCrLf & vbCrLf & "------------------------- "
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & "Total registros: " & inTotalRegistros & " -------------------------"
                strBARRESTA.Items(2).Text = "Registros : " & inTotalRegistros

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_GenerarCaracteristicaDePredio()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprCapr, "
            ParametrosConsulta += "count(FiprCapr) as FiprCant "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' "
            ParametrosConsulta += "group by FiprCapr "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' Crea objeto de columnas y registros
                Dim dt1 As New DataTable
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Caracteristica", GetType(String)))
                dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(String)))

                ' suma la totalidad de los registros encontrados
                Dim inTotalRegistros As Integer
                Dim doTotalPorcentaje As Double
                Dim i As Integer

                For i = 0 To dt.Rows.Count - 1
                    inTotalRegistros += CType(dt.Rows(i).Item("FIPRCANT"), Integer)
                Next

                ' inserta la consulta agrupada 
                Dim j As Integer

                For j = 0 To dt.Rows.Count - 1

                    ' declara las variables
                    Dim stFIPRCAPR As String = Trim(dt.Rows(j).Item("FIPRCAPR"))
                    Dim stFIPRDESC As String = fun_Buscar_Lista_Valores_CARAPRED(dt.Rows(j).Item("FIPRCAPR"))
                    Dim stFIPRCANT As String = Trim(dt.Rows(j).Item("FIPRCANT"))
                    Dim stFIPRPORC As String = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stFIPRCANT) / inTotalRegistros, Double)))

                    ' suma el porcentaje
                    doTotalPorcentaje += CType(stFIPRPORC, Double)

                    ' inserta el registro campo texto 
                    txtFIPRESTADISTICO.Text += "Caracteristica: " & stFIPRCAPR & " " & stFIPRDESC & " " & _
                                        "Cantidad: " & stFIPRCANT & " " & _
                                        "%: " & stFIPRPORC & vbCrLf

                    ' Inserta el registro en el DataTable
                    dr1 = dt1.NewRow()
                    dr1("Caracteristica") = stFIPRCAPR
                    dr1("Descripcion") = stFIPRDESC
                    dr1("Cantidad") = stFIPRCANT
                    dr1("Porcentaje(%)") = stFIPRPORC
                    dt1.Rows.Add(dr1)

                Next

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt1

                ' llena los totales
                lblTotalPorcentaje.Text = CType(doTotalPorcentaje, Integer)
                lblTotalRegistros.Text = CType(inTotalRegistros, String)

                ' inserta la totalidad de registros
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & vbCrLf & vbCrLf & "------------------------- "
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & "Total registros: " & inTotalRegistros & " -------------------------"
                strBARRESTA.Items(2).Text = "Registros : " & inTotalRegistros

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_GenerarClaseoSector()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprClse, "
            ParametrosConsulta += "count(FiprClse) as FiprCant "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' "
            ParametrosConsulta += "group by FiprClse "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' Crea objeto de columnas y registros
                Dim dt1 As New DataTable
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Clase o sector", GetType(String)))
                dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(String)))

                ' suma la totalidad de los registros encontrados
                Dim inTotalRegistros As Integer
                Dim doTotalPorcentaje As Double
                Dim i As Integer

                For i = 0 To dt.Rows.Count - 1
                    inTotalRegistros += CType(dt.Rows(i).Item("FIPRCANT"), Integer)
                Next

                ' inserta la consulta agrupada 
                Dim j As Integer

                For j = 0 To dt.Rows.Count - 1

                    ' declara las variables
                    Dim stFIPRCLSE As String = Trim(dt.Rows(j).Item("FIPRCLSE"))
                    Dim stFIPRDESC As String = fun_Buscar_Lista_Valores_CLASSECT(dt.Rows(j).Item("FIPRCLSE"))
                    Dim stFIPRCANT As String = Trim(dt.Rows(j).Item("FIPRCANT"))
                    Dim stFIPRPORC As String = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stFIPRCANT) / inTotalRegistros, Double)))

                    ' suma el porcentaje
                    doTotalPorcentaje += CType(stFIPRPORC, Double)

                    ' inserta el registro campo texto 
                    txtFIPRESTADISTICO.Text += "Clase o sector: " & stFIPRCLSE & " " & stFIPRDESC & " " & _
                                        "Cantidad: " & stFIPRCANT & " " & _
                                        "%: " & stFIPRPORC & vbCrLf

                    ' Inserta el registro en el DataTable
                    dr1 = dt1.NewRow()
                    dr1("Clase o sector") = stFIPRCLSE
                    dr1("Descripcion") = stFIPRDESC
                    dr1("Cantidad") = stFIPRCANT
                    dr1("Porcentaje(%)") = stFIPRPORC
                    dt1.Rows.Add(dr1)

                Next

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt1

                ' llena los totales
                lblTotalPorcentaje.Text = CType(doTotalPorcentaje, Integer)
                lblTotalRegistros.Text = CType(inTotalRegistros, String)

                ' inserta la totalidad de registros
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & vbCrLf & vbCrLf & "------------------------- "
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & "Total registros: " & inTotalRegistros & " -------------------------"
                strBARRESTA.Items(2).Text = "Registros : " & inTotalRegistros

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try
    End Sub
    Private Sub pro_GenerarAreaDeTerreno()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprArte, "
            ParametrosConsulta += "count(FiprNufi) as FiprCant "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' "
            ParametrosConsulta += "group by FiprArte "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' Crea objeto de columnas y registros
                Dim dt1 As New DataTable
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Area Terreno", GetType(String)))
                dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(String)))

                ' suma la totalidad de los registros encontrados
                Dim inTotalRegistros As Integer
                Dim doTotalPorcentaje As Double
                Dim i As Integer

                For i = 0 To dt.Rows.Count - 1
                    inTotalRegistros += CType(dt.Rows(i).Item("FIPRCANT"), Integer)
                Next

                ' inserta la consulta agrupada 
                Dim j As Integer

                For j = 0 To dt.Rows.Count - 1

                    ' declara las variables
                    Dim stFIPRARTE As String = Trim(dt.Rows(j).Item("FIPRARTE"))
                    Dim stFIPRCANT As String = Trim(dt.Rows(j).Item("FIPRCANT"))
                    Dim stFIPRPORC As String = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stFIPRCANT) / inTotalRegistros, Double)))

                    ' suma el porcentaje
                    doTotalPorcentaje += CType(stFIPRPORC, Double)

                    ' inserta el registro campo texto 
                    txtFIPRESTADISTICO.Text += "Area Terreno: " & stFIPRARTE & " " & _
                                        "Cantidad: " & stFIPRCANT & " " & _
                                        "%: " & stFIPRPORC & vbCrLf

                    ' Inserta el registro en el DataTable
                    dr1 = dt1.NewRow()
                    dr1("Area Terreno") = stFIPRARTE
                    dr1("Cantidad") = stFIPRCANT
                    dr1("Porcentaje(%)") = stFIPRPORC
                    dt1.Rows.Add(dr1)

                Next

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt1

                ' llena los totales
                lblTotalPorcentaje.Text = CType(doTotalPorcentaje, Integer)
                lblTotalRegistros.Text = CType(inTotalRegistros, String)

                ' inserta la totalidad de registros
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & vbCrLf & vbCrLf & "------------------------- "
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & "Total registros: " & inTotalRegistros & " -------------------------"
                strBARRESTA.Items(2).Text = "Registros : " & inTotalRegistros

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try
    End Sub
    Private Sub pro_GenerarAreaDeConstruccion()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpcoArco, "
            ParametrosConsulta += "count(Fpcounid) as FpcoCant "
            ParametrosConsulta += "From FichPred, FiprCons where "
            ParametrosConsulta += "FiprNufi = FpcoNufi and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FpcoEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "FpcoClco = '01' "
            ParametrosConsulta += "group by FpcoArco "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' Crea objeto de columnas y registros
                Dim dt1 As New DataTable
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Area Construida", GetType(String)))
                dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(String)))

                ' suma la totalidad de los registros encontrados
                Dim inTotalRegistros As Integer
                Dim doTotalPorcentaje As Double
                Dim i As Integer

                For i = 0 To dt.Rows.Count - 1
                    inTotalRegistros += CType(dt.Rows(i).Item("FPCOCANT"), Integer)
                Next

                ' inserta la consulta agrupada 
                Dim j As Integer

                For j = 0 To dt.Rows.Count - 1

                    ' declara las variables
                    Dim stFPCOARCO As String = Trim(dt.Rows(j).Item("FPCOARCO"))
                    Dim stFPCOCANT As String = Trim(dt.Rows(j).Item("FPCOCANT"))
                    Dim stFPCOPORC As String = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stFPCOCANT) / inTotalRegistros, Double)))

                    ' suma el porcentaje
                    doTotalPorcentaje += CType(stFPCOPORC, Double)

                    ' inserta el registro campo texto 
                    txtFIPRESTADISTICO.Text += "Area Construida: " & stFPCOARCO & " " & _
                                        "Cantidad: " & stFPCOCANT & " " & _
                                        "%: " & stFPCOPORC & vbCrLf

                    ' Inserta el registro en el DataTable
                    dr1 = dt1.NewRow()
                    dr1("Area Construida") = stFPCOARCO
                    dr1("Cantidad") = stFPCOCANT
                    dr1("Porcentaje(%)") = stFPCOPORC
                    dt1.Rows.Add(dr1)

                Next

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt1

                ' llena los totales
                lblTotalPorcentaje.Text = CType(doTotalPorcentaje, Integer)
                lblTotalRegistros.Text = CType(inTotalRegistros, String)

                ' inserta la totalidad de registros
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & vbCrLf & vbCrLf & "------------------------- "
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & "Total registros: " & inTotalRegistros & " -------------------------"
                strBARRESTA.Items(2).Text = "Registros : " & inTotalRegistros

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try
    End Sub
    Private Sub pro_GenerarPuntosDeCalificacion()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            Dim dt2 As New DataTable
            dt1 = dt2

            ' Crea las columnas
            dt1.Columns.Add(New DataColumn("Rango Puntaje", GetType(String)))
            dt1.Columns.Add(New DataColumn("Estrato", GetType(String)))
            dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
            dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(String)))

            ' totaliza los registros
            pro_GenerarNroConstrucciones()

            ' realiza la consulta
            pro_GenerarPuntos_0_al_10()

            ' Inserta el registro en el DataTable
            dr1 = dt1.NewRow()
            dr1("Rango Puntaje") = "( 0 - 10 )"
            dr1("Estrato") = "( bajo - bajo )"
            dr1("Cantidad") = dt_0_al_10.Rows(0).Item("FPCOCANT")
            dr1("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * Val(dt_0_al_10.Rows(0).Item("FPCOCANT"))) / inNroConstruccionesTotales, Double)))
            dt1.Rows.Add(dr1)

            ' realiza la consulta
            pro_GenerarPuntos_11_al_28()

            ' Inserta el registro en el DataTable
            dr1 = dt1.NewRow()
            dr1("Rango Puntaje") = "( 11 - 28 )"
            dr1("Estrato") = "( bajo - medio )"
            dr1("Cantidad") = dt_11_al_28.Rows(0).Item("FPCOCANT")
            dr1("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * Val(dt_11_al_28.Rows(0).Item("FPCOCANT"))) / inNroConstruccionesTotales, Double)))
            dt1.Rows.Add(dr1)

            ' realiza la consulta
            pro_GenerarPuntos_29_al_46()

            ' Inserta el registro en el DataTable
            dr1 = dt1.NewRow()
            dr1("Rango Puntaje") = "( 29 - 46 )"
            dr1("Estrato") = "( medio - medio )"
            dr1("Cantidad") = dt_29_al_46.Rows(0).Item("FPCOCANT")
            dr1("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * Val(dt_29_al_46.Rows(0).Item("FPCOCANT"))) / inNroConstruccionesTotales, Double)))
            dt1.Rows.Add(dr1)

            ' realiza la consulta
            pro_GenerarPuntos_47_al_64()

            ' Inserta el registro en el DataTable
            dr1 = dt1.NewRow()
            dr1("Rango Puntaje") = "( 47 - 64 )"
            dr1("Estrato") = "( medio - alto )"
            dr1("Cantidad") = dt_47_al_64.Rows(0).Item("FPCOCANT")
            dr1("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * Val(dt_47_al_64.Rows(0).Item("FPCOCANT"))) / inNroConstruccionesTotales, Double)))
            dt1.Rows.Add(dr1)

            ' realiza la consulta
            pro_GenerarPuntos_65_al_82()

            ' Inserta el registro en el DataTable
            dr1 = dt1.NewRow()
            dr1("Rango Puntaje") = "( 65 - 82 )"
            dr1("Estrato") = "( alto )"
            dr1("Cantidad") = dt_65_al_82.Rows(0).Item("FPCOCANT")
            dr1("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * Val(dt_65_al_82.Rows(0).Item("FPCOCANT"))) / inNroConstruccionesTotales, Double)))
            dt1.Rows.Add(dr1)

            ' realiza la consulta
            pro_GenerarPuntos_83_al_100()

            ' Inserta el registro en el DataTable
            dr1 = dt1.NewRow()
            dr1("Rango Puntaje") = "( 83 - 100 )"
            dr1("Estrato") = "( muy alto )"
            dr1("Cantidad") = dt_83_al_100.Rows(0).Item("FPCOCANT")
            dr1("Porcentaje(%)") = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * Val(dt_83_al_100.Rows(0).Item("FPCOCANT"))) / inNroConstruccionesTotales, Double)))
            dt1.Rows.Add(dr1)

            ' verifica la existencia de registros
            If inNroConstruccionesTotales > 0 Then

                ' declaro variables
                Dim inTotalRegistros As Integer
                Dim doTotalPorcentaje As Double

                ' suma total de registros
                Dim i As Integer

                For i = 0 To dt1.Rows.Count - 1
                    inTotalRegistros += CType(dt1.Rows(i).Item("Cantidad"), Integer)
                    doTotalPorcentaje += CType(dt1.Rows(i).Item("Porcentaje(%)"), Integer)
                Next

                ' inserta la consulta agrupada 
                Dim j As Integer

                For j = 0 To dt1.Rows.Count - 1

                    ' declara las variables
                    Dim stFPCORANG As String = Trim(dt1.Rows(j).Item("Rango Puntaje"))
                    Dim stFPCOESTR As String = Trim(dt1.Rows(j).Item("Estrato"))
                    Dim stFPCOCANT As String = Trim(dt1.Rows(j).Item("Cantidad"))
                    Dim stFPCOPORC As String = Trim(dt1.Rows(j).Item("Porcentaje(%)"))

                    ' inserta el registro campo texto 
                    txtFIPRESTADISTICO.Text += "Rango Puntaje: " & stFPCORANG & " " & _
                                        "Estrato: " & stFPCOESTR & " " & _
                                        "Cantidad: " & stFPCOCANT & " " & _
                                        "%: " & stFPCOPORC & vbCrLf

                Next

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt1

                ' llena los totales
                lblTotalPorcentaje.Text = CType(doTotalPorcentaje, Integer)
                lblTotalRegistros.Text = CType(inTotalRegistros, String)

                ' inserta la totalidad de registros
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & vbCrLf & vbCrLf & "------------------------- "
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & "Total registros: " & inTotalRegistros & " -------------------------"
                strBARRESTA.Items(2).Text = "Registros : " & inTotalRegistros

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try
    End Sub
    Private Sub pro_GenerarNroConstrucciones()
        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "count(Fpcounid) as FpcoCant "
            ParametrosConsulta += "From FichPred, FiprCons where "
            ParametrosConsulta += "FiprNufi = FpcoNufi and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FpcoEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FpcoClco = '01' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' almacena la consulta
            inNroConstruccionesTotales = CType(dt.Rows(0).Item("FPCOCANT"), Integer)

            ' cierra la conexion
            oConexion.Close()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub pro_GenerarPuntos_0_al_10()

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "count(Fpcounid) as FpcoCant "
            ParametrosConsulta += "From FichPred, FiprCons where "
            ParametrosConsulta += "FiprNufi = FpcoNufi and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FpcoEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "FpcoPunt between 0 and 10 and "
            ParametrosConsulta += "FpcoClco = '01' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' almacena la consulta
            dt_0_al_10 = dt

            ' cierra la conexion
            oConexion.Close()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GenerarPuntos_11_al_28()

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "count(Fpcounid) as FpcoCant "
            ParametrosConsulta += "From FichPred, FiprCons where "
            ParametrosConsulta += "FiprNufi = FpcoNufi and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(txtFIPRTIFI.Text) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FpcoEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "FpcoPunt between 11 and 28 and "
            ParametrosConsulta += "FpcoClco = '01' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' almacena la consulta
            dt_11_al_28 = dt

            ' cierra la conexion
            oConexion.Close()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GenerarPuntos_29_al_46()

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "count(Fpcounid) as FpcoCant "
            ParametrosConsulta += "From FichPred, FiprCons where "
            ParametrosConsulta += "FiprNufi = FpcoNufi and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(txtFIPRTIFI.Text) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FpcoEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "FpcoPunt between 29 and 46 and "
            ParametrosConsulta += "FpcoClco = '01' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' almacena la consulta
            dt_29_al_46 = dt

            ' cierra la conexion
            oConexion.Close()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GenerarPuntos_47_al_64()

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "count(Fpcounid) as FpcoCant "
            ParametrosConsulta += "From FichPred, FiprCons where "
            ParametrosConsulta += "FiprNufi = FpcoNufi and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(txtFIPRTIFI.Text) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FpcoEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "FpcoPunt between 47 and 64 and "
            ParametrosConsulta += "FpcoClco = '01' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' almacena la consulta
            dt_47_al_64 = dt

            ' cierra la conexion
            oConexion.Close()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GenerarPuntos_65_al_82()

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "count(Fpcounid) as FpcoCant "
            ParametrosConsulta += "From FichPred, FiprCons where "
            ParametrosConsulta += "FiprNufi = FpcoNufi and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(txtFIPRTIFI.Text) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FpcoEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "FpcoPunt between 65 and 82 and "
            ParametrosConsulta += "FpcoClco = '01' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' almacena la consulta
            dt_65_al_82 = dt

            ' cierra la conexion
            oConexion.Close()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GenerarPuntos_83_al_100()

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "count(Fpcounid) as FpcoCant "
            ParametrosConsulta += "From FichPred, FiprCons where "
            ParametrosConsulta += "FiprNufi = FpcoNufi and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(txtFIPRTIFI.Text) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FpcoEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "FpcoPunt between 83 and 100 and "
            ParametrosConsulta += "FpcoClco = '01' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' almacena la consulta
            dt_83_al_100 = dt

            ' cierra la conexion
            oConexion.Close()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GenerarPrediosConDestinoPorcentajeMaximo()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "a1.FiprNufi as NroFicha, "
            ParametrosConsulta += "a1.FiprClse as ClaseSector, "
            ParametrosConsulta += "a1.FiprMuni as Municipio, "
            ParametrosConsulta += "a1.FiprCorr as Corregimi, "
            ParametrosConsulta += "a1.FiprBarr as Barrio, "
            ParametrosConsulta += "a1.FiprManz as Manzana, "
            ParametrosConsulta += "a1.FiprPred as Predio, "
            ParametrosConsulta += "a1.FiprEdif as Edificio, "
            ParametrosConsulta += "a1.FiprUnpr as UnidadPred, "
            ParametrosConsulta += "b1.FpdeDeec as Destino, "
            ParametrosConsulta += "b1.FpdePorc as Porcentje "
            ParametrosConsulta += "From FiprDeec b1, FichPred a1, "
            ParametrosConsulta += "(Select a2.FiprNufi as Ficha2, "
            ParametrosConsulta += "Max(b2.FpdePorc) as Destino from "
            ParametrosConsulta += "FiprDeec b2, FichPred a2 "
            ParametrosConsulta += "where b2.FpdeNufi = a2.FiprNufi and "
            ParametrosConsulta += "a2.FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "a2.FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "a2.FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "a2.FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "a2.FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "a2.FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "a2.FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "a2.FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "a2.FiprTifi like '" & Trim(txtFIPRTIFI.Text) & "' and "
            ParametrosConsulta += "a2.FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' "
            ParametrosConsulta += "group by a2.FiprNufi) TotalDestino where "
            ParametrosConsulta += "a1.fipresta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "a1.fiprnufi = b1.fpdenufi and "
            ParametrosConsulta += "b1.fpdeesta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "TotalDestino.ficha2= a1.fiprnufi and "
            ParametrosConsulta += "TotalDestino.Destino = b1.fpdeporc "
            ParametrosConsulta += "Order by a1.fiprMuni, a1.fiprCorr, a1.fiprBarr, a1.fiprManz, a1.fiprPred, a1.fiprEdif, a1.fiprUnpr "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt

                ' llena los totales
                lblTotalPorcentaje.Text = "0"
                lblTotalRegistros.Text = Me.dgvFIPRESTA.RowCount.ToString

                ' inserta la totalidad de registros
                strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRESTA.RowCount.ToString

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_GenerarPredioConAreaConstruidaMaxima()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "a1.FiprNufi as NroFicha, "
            ParametrosConsulta += "a1.FiprClse as ClaseSector, "
            ParametrosConsulta += "a1.FiprMuni as Municipio, "
            ParametrosConsulta += "a1.FiprCorr as Corregimi, "
            ParametrosConsulta += "a1.FiprBarr as Barrio, "
            ParametrosConsulta += "a1.FiprManz as Manzana, "
            ParametrosConsulta += "a1.FiprPred as Predio, "
            ParametrosConsulta += "a1.FiprEdif as Edificio, "
            ParametrosConsulta += "a1.FiprUnpr as UnidadPred, "
            ParametrosConsulta += "b1.FpcoUnid as NroCons, "
            ParametrosConsulta += "b1.FpcoClco as Clase, "
            ParametrosConsulta += "b1.FpcoTico as Identificador, "
            ParametrosConsulta += "b1.FpcoPunt as Puntos, "
            ParametrosConsulta += "b1.FpcoArco as AreaCons "
            ParametrosConsulta += "From FiprCons b1, FichPred a1, "
            ParametrosConsulta += "(Select a2.FiprNufi as Ficha2, "
            ParametrosConsulta += "Max(b2.FpcoArco) as AreaCons from "
            ParametrosConsulta += "FiprCons b2, FichPred a2 "
            ParametrosConsulta += "where b2.FpcoNufi = a2.FiprNufi and "
            ParametrosConsulta += "b2.fpcoclco in ('1','2') and "
            ParametrosConsulta += "a2.FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "a2.FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "a2.FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "a2.FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "a2.FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "a2.FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "a2.FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "a2.FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "a2.FiprTifi like '" & Trim(txtFIPRTIFI.Text) & "' and "
            ParametrosConsulta += "a2.FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' "
            ParametrosConsulta += "group by a2.FiprNufi) TotalArea where "
            ParametrosConsulta += "a1.fipresta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "a1.fiprnufi = b1.fpcoNufi and "
            ParametrosConsulta += "b1.fpcoesta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "TotalArea.ficha2= a1.fiprnufi and "
            ParametrosConsulta += "TotalArea.AreaCons = b1.fpcoArco "
            ParametrosConsulta += "Order by a1.fiprMuni, a1.fiprCorr, a1.fiprBarr, a1.fiprManz, a1.fiprPred, a1.fiprEdif, a1.fiprUnpr "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt

                ' llena los totales
                lblTotalPorcentaje.Text = "0"
                lblTotalRegistros.Text = Me.dgvFIPRESTA.RowCount.ToString

                ' inserta la totalidad de registros
                strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRESTA.RowCount.ToString

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try
    End Sub
    Private Sub pro_GenerarCalidadDePropietario()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpprCapr, "
            ParametrosConsulta += "count(FpprCapr) as FpprCant "
            ParametrosConsulta += "From FiprProp, FichPred where "
            ParametrosConsulta += "FiprNufi = FpprNufi and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FpprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' "
            ParametrosConsulta += "group by FpprCapr "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' Crea objeto de columnas y registros
                Dim dt1 As New DataTable
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Calidad Propietario", GetType(String)))
                dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(String)))

                ' suma la totalidad de los registros encontrados
                Dim inTotalRegistros As Integer
                Dim doTotalPorcentaje As Double
                Dim i As Integer

                For i = 0 To dt.Rows.Count - 1
                    inTotalRegistros += CType(dt.Rows(i).Item("FPPRCANT"), Integer)
                Next

                ' inserta la consulta agrupada 
                Dim j As Integer

                For j = 0 To dt.Rows.Count - 1

                    ' declara las variables
                    Dim stFPPRCAPR As String = Trim(dt.Rows(j).Item("FPPRCAPR"))
                    Dim stFPPRDESC As String = fun_Buscar_Lista_Valores_CALIPROP(dt.Rows(j).Item("FPPRCAPR"))
                    Dim stFPPRCANT As String = Trim(dt.Rows(j).Item("FPPRCANT"))
                    Dim stFPPRPORC As String = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stFPPRCANT) / inTotalRegistros, Double)))

                    ' suma el porcentaje
                    doTotalPorcentaje += CType(stFPPRPORC, Double)

                    ' inserta el registro campo texto 
                    txtFIPRESTADISTICO.Text += "Calidad Propietario: " & stFPPRCAPR & " " & stFPPRDESC & _
                                        "Cantidad: " & stFPPRCANT & " " & _
                                        "%: " & stFPPRPORC & vbCrLf

                    ' Inserta el registro en el DataTable
                    dr1 = dt1.NewRow()
                    dr1("Calidad Propietario") = stFPPRCAPR
                    dr1("Descripcion") = stFPPRDESC
                    dr1("Cantidad") = stFPPRCANT
                    dr1("Porcentaje(%)") = stFPPRPORC
                    dt1.Rows.Add(dr1)

                Next

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt1

                ' llena los totales
                lblTotalPorcentaje.Text = CType(doTotalPorcentaje, Integer)
                lblTotalRegistros.Text = CType(inTotalRegistros, String)

                ' inserta la totalidad de registros
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & vbCrLf & vbCrLf & "------------------------- "
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & "Total registros: " & inTotalRegistros & " -------------------------"
                strBARRESTA.Items(2).Text = "Registros : " & inTotalRegistros

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_GenerarAvaluosPorTipoDeConstruccion()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpcoTico, "
            ParametrosConsulta += "TicoDesc, "
            ParametrosConsulta += "count(FpcoTico) as FpcoCant, "
            ParametrosConsulta += "sum(FpavVatp) as ValTerPri, "
            ParametrosConsulta += "sum(FpavVatc) as ValTerCom, "
            ParametrosConsulta += "sum(FpavVacp) as ValConPri, "
            ParametrosConsulta += "sum(FpavVacc) as ValConCom, "
            ParametrosConsulta += "sum(FpavAval) as AvaluoTotal "
            ParametrosConsulta += "From FiprCons, FichPred, Mant_Tipocons, FiprAval where "
            ParametrosConsulta += "FiprNufi = FpcoNufi and "
            ParametrosConsulta += "FiprNufi = FpavNufi and "
            ParametrosConsulta += "FpcoDepa = TicoDepa and "
            ParametrosConsulta += "FpcoMuni = TicoMuni and "
            ParametrosConsulta += "FpcoClco = TicoClco and "
            ParametrosConsulta += "FpcoTico = TicoCodi and "
            ParametrosConsulta += "FiprClse = TicoClse and "
            ParametrosConsulta += "FpcoClco in ('1','2') and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FpcoEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprTifi = '0' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' "
            ParametrosConsulta += "group by FpcoTico, TicoDesc "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' Crea objeto de columnas y registros
                Dim dt1 As New DataTable
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Identificador", GetType(String)))
                dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(String)))

                dt1.Columns.Add(New DataColumn("ValorLotePrivado", GetType(String)))
                dt1.Columns.Add(New DataColumn("ValorLoteComun", GetType(String)))
                dt1.Columns.Add(New DataColumn("ValorConsPrivado", GetType(String)))
                dt1.Columns.Add(New DataColumn("ValorConsComun", GetType(String)))
                dt1.Columns.Add(New DataColumn("AvaluoTotal", GetType(String)))

                ' suma la totalidad de los registros encontrados
                Dim inTotalRegistros As Integer
                Dim doTotalPorcentaje As Double
                Dim i As Integer

                For i = 0 To dt.Rows.Count - 1
                    inTotalRegistros += CType(dt.Rows(i).Item("FPCOCANT"), Integer)
                Next

                ' inserta la consulta agrupada 
                Dim j As Integer

                For j = 0 To dt.Rows.Count - 1

                    ' declara las variables
                    Dim stFPCOTICO As String = Trim(dt.Rows(j).Item("FPCOTICO"))
                    Dim stFPCODESC As String = Trim(dt.Rows(j).Item("TICODESC"))
                    Dim stFPCOCANT As String = Trim(dt.Rows(j).Item("FPCOCANT"))
                    Dim stFPCOPORC As String = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stFPCOCANT) / inTotalRegistros, Double)))

                    Dim stFPAVVALT As String = Trim(dt.Rows(j).Item("ValTerPri"))
                    Dim stFPAVVALC As String = Trim(dt.Rows(j).Item("ValTerCom"))
                    Dim stFPAVVACP As String = Trim(dt.Rows(j).Item("ValConPri"))
                    Dim stFPAVVACC As String = Trim(dt.Rows(j).Item("ValConCom"))
                    Dim stFPAVAVAL As String = Trim(dt.Rows(j).Item("AvaluoTotal"))

                    ' suma el porcentaje
                    doTotalPorcentaje += CType(stFPCOPORC, Double)


                    ' Inserta el registro en el DataTable
                    dr1 = dt1.NewRow()
                    dr1("Identificador") = stFPCOTICO
                    dr1("Descripcion") = stFPCODESC
                    dr1("Cantidad") = stFPCOCANT
                    dr1("Porcentaje(%)") = stFPCOPORC

                    dr1("ValorLotePrivado") = stFPAVVALT
                    dr1("ValorLoteComun") = stFPAVVALC
                    dr1("ValorConsPrivado") = stFPAVVACP
                    dr1("ValorConsComun") = stFPAVVACC
                    dr1("AvaluoTotal") = stFPAVAVAL
                    dt1.Rows.Add(dr1)

                Next

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt1

                ' llena los totales
                lblTotalPorcentaje.Text = CType(doTotalPorcentaje, Integer)
                lblTotalRegistros.Text = CType(inTotalRegistros, String)

                ' inserta la totalidad de registros
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & vbCrLf & vbCrLf & "------------------------- "
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & "Total registros: " & inTotalRegistros & " -------------------------"
                strBARRESTA.Items(2).Text = "Registros : " & inTotalRegistros

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try
    End Sub
    Private Sub pro_GenerarAvaluosPorZonaEconomica()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpzeZoec, "
            ParametrosConsulta += "ZoecDesc, "
            ParametrosConsulta += "count(FpzeZoec) as FpzeCant, "
            ParametrosConsulta += "sum(FpavVatp) as ValTerPri, "
            ParametrosConsulta += "sum(FpavVatc) as ValTerCom, "
            ParametrosConsulta += "sum(FpavVacp) as ValConPri, "
            ParametrosConsulta += "sum(FpavVacc) as ValConCom, "
            ParametrosConsulta += "sum(FpavAval) as AvaluoTotal "
            ParametrosConsulta += "From FiprZoec, FichPred, Mant_ZonaEcon, FiprAval where "
            ParametrosConsulta += "FiprNufi = FpzeNufi and "
            ParametrosConsulta += "FiprNufi = FpavNufi and "
            ParametrosConsulta += "FpzeDepa = ZoecDepa and "
            ParametrosConsulta += "FpzeMuni = ZoecMuni and "
            ParametrosConsulta += "FpzeZoec = ZoecCodi and "
            ParametrosConsulta += "FiprClse = ZoecClse and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FpzeEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprTifi = '0' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' "
            ParametrosConsulta += "group by FpzeZoec, ZoecDesc "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' Crea objeto de columnas y registros
                Dim dt1 As New DataTable
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Zona economica", GetType(String)))
                dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(String)))

                dt1.Columns.Add(New DataColumn("ValorLotePrivado", GetType(String)))
                dt1.Columns.Add(New DataColumn("ValorLoteComun", GetType(String)))
                dt1.Columns.Add(New DataColumn("ValorConsPrivado", GetType(String)))
                dt1.Columns.Add(New DataColumn("ValorConsComun", GetType(String)))
                dt1.Columns.Add(New DataColumn("AvaluoTotal", GetType(String)))

                ' suma la totalidad de los registros encontrados
                Dim inTotalRegistros As Integer
                Dim doTotalPorcentaje As Double
                Dim i As Integer

                For i = 0 To dt.Rows.Count - 1
                    inTotalRegistros += CType(dt.Rows(i).Item("FPZECANT"), Integer)
                Next

                ' inserta la consulta agrupada 
                Dim j As Integer

                For j = 0 To dt.Rows.Count - 1

                    ' declara las variables
                    Dim stFPZEZOEC As String = Trim(dt.Rows(j).Item("FPZEZOEC"))
                    Dim stFPZEDESC As String = Trim(dt.Rows(j).Item("ZOECDESC"))
                    Dim stFPZECANT As String = Trim(dt.Rows(j).Item("FPZECANT"))
                    Dim stFPZEPORC As String = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stFPZECANT) / inTotalRegistros, Double)))

                    Dim stFPAVVALT As String = Trim(dt.Rows(j).Item("ValTerPri"))
                    Dim stFPAVVALC As String = Trim(dt.Rows(j).Item("ValTerCom"))
                    Dim stFPAVVACP As String = Trim(dt.Rows(j).Item("ValConPri"))
                    Dim stFPAVVACC As String = Trim(dt.Rows(j).Item("ValConCom"))
                    Dim stFPAVAVAL As String = Trim(dt.Rows(j).Item("AvaluoTotal"))

                    ' suma el porcentaje
                    doTotalPorcentaje += CType(stFPZEPORC, Double)

                    ' Inserta el registro en el DataTable
                    dr1 = dt1.NewRow()
                    dr1("Zona economica") = stFPZEZOEC
                    dr1("Descripcion") = stFPZEDESC
                    dr1("Cantidad") = stFPZECANT
                    dr1("Porcentaje(%)") = stFPZEPORC

                    dr1("ValorLotePrivado") = stFPAVVALT
                    dr1("ValorLoteComun") = stFPAVVALC
                    dr1("ValorConsPrivado") = stFPAVVACP
                    dr1("ValorConsComun") = stFPAVVACC
                    dr1("AvaluoTotal") = stFPAVAVAL
                    dt1.Rows.Add(dr1)

                Next

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt1

                ' llena los totales
                lblTotalPorcentaje.Text = CType(doTotalPorcentaje, Integer)
                lblTotalRegistros.Text = CType(inTotalRegistros, String)

                ' inserta la totalidad de registros
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & vbCrLf & vbCrLf & "------------------------- "
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & "Total registros: " & inTotalRegistros & " -------------------------"
                strBARRESTA.Items(2).Text = "Registros : " & inTotalRegistros

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try
    End Sub
    Private Sub pro_GenerarAvaluosPorDestinacionEconomica()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpdeDeec, "
            ParametrosConsulta += "count(FpdeDeec) as FpdeCant, "
            ParametrosConsulta += "sum(FpavVatp) as ValTerPri, "
            ParametrosConsulta += "sum(FpavVatc) as ValTerCom, "
            ParametrosConsulta += "sum(FpavVacp) as ValConPri, "
            ParametrosConsulta += "sum(FpavVacc) as ValConCom, "
            ParametrosConsulta += "sum(FpavAval) as AvaluoTotal "
            ParametrosConsulta += "From FiprDeec, FichPred, FiprAval where "
            ParametrosConsulta += "FiprNufi = FpdeNufi and "
            ParametrosConsulta += "FiprNufi = FpavNufi and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FpdeEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' "
            ParametrosConsulta += "group by FpdeDeec "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' Crea objeto de columnas y registros
                Dim dt1 As New DataTable
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Destino", GetType(String)))
                dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(String)))

                dt1.Columns.Add(New DataColumn("ValorLotePrivado", GetType(String)))
                dt1.Columns.Add(New DataColumn("ValorLoteComun", GetType(String)))
                dt1.Columns.Add(New DataColumn("ValorConsPrivado", GetType(String)))
                dt1.Columns.Add(New DataColumn("ValorConsComun", GetType(String)))
                dt1.Columns.Add(New DataColumn("AvaluoTotal", GetType(String)))

                ' suma la totalidad de los registros encontrados
                Dim inTotalRegistros As Integer
                Dim doTotalPorcentaje As Double
                Dim i As Integer

                For i = 0 To dt.Rows.Count - 1
                    inTotalRegistros += CType(dt.Rows(i).Item("FPDECANT"), Integer)
                Next

                ' inserta la consulta agrupada 
                Dim j As Integer

                For j = 0 To dt.Rows.Count - 1

                    ' declara las variables
                    Dim stFPDEDEEC As String = Trim(dt.Rows(j).Item("FPDEDEEC"))
                    Dim stFPDEDESC As String = fun_Buscar_Lista_Valores_DESTECON(dt.Rows(j).Item("FPDEDEEC"))
                    Dim stFPDECANT As String = Trim(dt.Rows(j).Item("FPDECANT"))
                    Dim stFPDEPORC As String = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stFPDECANT) / inTotalRegistros, Double)))

                    Dim stFPAVVALT As String = Trim(dt.Rows(j).Item("ValTerPri"))
                    Dim stFPAVVALC As String = Trim(dt.Rows(j).Item("ValTerCom"))
                    Dim stFPAVVACP As String = Trim(dt.Rows(j).Item("ValConPri"))
                    Dim stFPAVVACC As String = Trim(dt.Rows(j).Item("ValConCom"))
                    Dim stFPAVAVAL As String = Trim(dt.Rows(j).Item("AvaluoTotal"))

                    ' suma el porcentaje
                    doTotalPorcentaje += CType(stFPDEPORC, Double)

                    ' Inserta el registro en el DataTable
                    dr1 = dt1.NewRow()
                    dr1("Destino") = stFPDEDEEC
                    dr1("Descripcion") = stFPDEDESC
                    dr1("Cantidad") = stFPDECANT
                    dr1("Porcentaje(%)") = stFPDEPORC

                    dr1("ValorLotePrivado") = stFPAVVALT
                    dr1("ValorLoteComun") = stFPAVVALC
                    dr1("ValorConsPrivado") = stFPAVVACP
                    dr1("ValorConsComun") = stFPAVVACC
                    dr1("AvaluoTotal") = stFPAVAVAL
                    dt1.Rows.Add(dr1)

                Next

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt1

                ' llena los totales
                lblTotalPorcentaje.Text = CType(doTotalPorcentaje, Integer)
                lblTotalRegistros.Text = CType(inTotalRegistros, String)

                ' inserta la totalidad de registros
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & vbCrLf & vbCrLf & "------------------------- "
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & "Total registros: " & inTotalRegistros & " -------------------------"
                strBARRESTA.Items(2).Text = "Registros : " & inTotalRegistros

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_GenerarAvaluosPorCalidadDePropietario()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FpprCapr, "
            ParametrosConsulta += "count(FpprCapr) as FpprCant, "
            ParametrosConsulta += "sum(FpavVatp) as ValTerPri, "
            ParametrosConsulta += "sum(FpavVatc) as ValTerCom, "
            ParametrosConsulta += "sum(FpavVacp) as ValConPri, "
            ParametrosConsulta += "sum(FpavVacc) as ValConCom, "
            ParametrosConsulta += "sum(FpavAval) as AvaluoTotal "
            ParametrosConsulta += "From FiprProp, FichPred, FiprAval where "
            ParametrosConsulta += "FiprNufi = FpprNufi and "
            ParametrosConsulta += "FiprNufi = FpavNufi and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FpprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' "
            ParametrosConsulta += "group by FpprCapr "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' Crea objeto de columnas y registros
                Dim dt1 As New DataTable
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Calidad Propietario", GetType(String)))
                dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(String)))

                dt1.Columns.Add(New DataColumn("ValorLotePrivado", GetType(String)))
                dt1.Columns.Add(New DataColumn("ValorLoteComun", GetType(String)))
                dt1.Columns.Add(New DataColumn("ValorConsPrivado", GetType(String)))
                dt1.Columns.Add(New DataColumn("ValorConsComun", GetType(String)))
                dt1.Columns.Add(New DataColumn("AvaluoTotal", GetType(String)))

                ' suma la totalidad de los registros encontrados
                Dim inTotalRegistros As Integer
                Dim doTotalPorcentaje As Double
                Dim i As Integer

                For i = 0 To dt.Rows.Count - 1
                    inTotalRegistros += CType(dt.Rows(i).Item("FPPRCANT"), Integer)
                Next

                ' inserta la consulta agrupada 
                Dim j As Integer

                For j = 0 To dt.Rows.Count - 1

                    ' declara las variables
                    Dim stFPPRCAPR As String = Trim(dt.Rows(j).Item("FPPRCAPR"))
                    Dim stFPPRDESC As String = fun_Buscar_Lista_Valores_CALIPROP(dt.Rows(j).Item("FPPRCAPR"))
                    Dim stFPPRCANT As String = Trim(dt.Rows(j).Item("FPPRCANT"))
                    Dim stFPPRPORC As String = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stFPPRCANT) / inTotalRegistros, Double)))

                    Dim stFPAVVALT As String = Trim(dt.Rows(j).Item("ValTerPri"))
                    Dim stFPAVVALC As String = Trim(dt.Rows(j).Item("ValTerCom"))
                    Dim stFPAVVACP As String = Trim(dt.Rows(j).Item("ValConPri"))
                    Dim stFPAVVACC As String = Trim(dt.Rows(j).Item("ValConCom"))
                    Dim stFPAVAVAL As String = Trim(dt.Rows(j).Item("AvaluoTotal"))

                    ' suma el porcentaje
                    doTotalPorcentaje += CType(stFPPRPORC, Double)

                    ' Inserta el registro en el DataTable
                    dr1 = dt1.NewRow()
                    dr1("Calidad Propietario") = stFPPRCAPR
                    dr1("Descripcion") = stFPPRDESC
                    dr1("Cantidad") = stFPPRCANT
                    dr1("Porcentaje(%)") = stFPPRPORC

                    dr1("ValorLotePrivado") = stFPAVVALT
                    dr1("ValorLoteComun") = stFPAVVALC
                    dr1("ValorConsPrivado") = stFPAVVACP
                    dr1("ValorConsComun") = stFPAVVACC
                    dr1("AvaluoTotal") = stFPAVAVAL
                    dt1.Rows.Add(dr1)

                Next

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt1

                ' llena los totales
                lblTotalPorcentaje.Text = CType(doTotalPorcentaje, Integer)
                lblTotalRegistros.Text = CType(inTotalRegistros, String)

                ' inserta la totalidad de registros
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & vbCrLf & vbCrLf & "------------------------- "
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & "Total registros: " & inTotalRegistros & " -------------------------"
                strBARRESTA.Items(2).Text = "Registros : " & inTotalRegistros

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_GenerarAvaluosTotales()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "sum(FpavAtpr) as AreTerPri, "
            ParametrosConsulta += "sum(FpavAtco) as AreTerCom, "
            ParametrosConsulta += "sum(FpavVatp) as ValTerPri, "
            ParametrosConsulta += "sum(FpavVatc) as ValTerCom, "
            ParametrosConsulta += "sum(FpavVacp) as ValConPri, "
            ParametrosConsulta += "sum(FpavVacc) as ValConCom, "
            ParametrosConsulta += "sum(FpavAval) as AvaluoTotal "
            ParametrosConsulta += "From FichPred, FiprAval where "
            ParametrosConsulta += "FiprNufi = FpavNufi and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' Crea objeto de columnas y registros
                Dim dt1 As New DataTable
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("AreaTerrenoPrivado", GetType(String)))
                dt1.Columns.Add(New DataColumn("AreaTerrenoComun", GetType(String)))
                dt1.Columns.Add(New DataColumn("ValorLotePrivado", GetType(String)))
                dt1.Columns.Add(New DataColumn("ValorLoteComun", GetType(String)))
                dt1.Columns.Add(New DataColumn("ValorConsPrivado", GetType(String)))
                dt1.Columns.Add(New DataColumn("ValorConsComun", GetType(String)))
                dt1.Columns.Add(New DataColumn("AvaluoTotal", GetType(String)))

                ' inserta la consulta agrupada 
                Dim j As Integer

                For j = 0 To dt.Rows.Count - 1

                    Dim stFPAVATPR As String = Trim(dt.Rows(j).Item("AreTerPri"))
                    Dim stFPAVATCO As String = Trim(dt.Rows(j).Item("AreTerCom"))
                    Dim stFPAVVALT As String = Trim(dt.Rows(j).Item("ValTerPri"))
                    Dim stFPAVVALC As String = Trim(dt.Rows(j).Item("ValTerCom"))
                    Dim stFPAVVACP As String = Trim(dt.Rows(j).Item("ValConPri"))
                    Dim stFPAVVACC As String = Trim(dt.Rows(j).Item("ValConCom"))
                    Dim stFPAVAVAL As String = Trim(dt.Rows(j).Item("AvaluoTotal"))

                    ' Inserta el registro en el DataTable
                    dr1 = dt1.NewRow()
                    dr1("AreaTerrenoPrivado") = stFPAVATPR
                    dr1("AreaTerrenoComun") = stFPAVATCO
                    dr1("ValorLotePrivado") = stFPAVVALT
                    dr1("ValorLoteComun") = stFPAVVALC
                    dr1("ValorConsPrivado") = stFPAVVACP
                    dr1("ValorConsComun") = stFPAVVACC
                    dr1("AvaluoTotal") = stFPAVAVAL
                    dt1.Rows.Add(dr1)

                Next

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt1

                ' llena los totales
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = dt.Rows.Count

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_ReporteFichaPredial()

        Try
            Me.txtFIPRESTADISTICO.Text = ""
            Me.cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select FiprNufi "
            ParametrosConsulta += "From FichPred "
            ParametrosConsulta += "where "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' "
            ParametrosConsulta += "Order by FiprClse,FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr "

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

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                Dim boAgregarCalificacion As Boolean = True

                If MessageBox.Show("¿ Desea agregar la calificación de construcción en el reporte ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    boAgregarCalificacion = True
                Else
                    boAgregarCalificacion = False
                End If

                ' crea la tabla
                dt_FICHPRED = New DataTable

                ' crea el registro
                Dim dr_FICHPRED As DataRow

                ' Crea las columnas
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL01", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL02", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL03", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL04", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL05", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL06", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL07", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL08", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL09", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL10", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL11", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL12", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL13", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL14", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL15", GetType(String)))

                ' declara la variable
                Dim i As Integer

                For i = 0 To dt.Rows.Count - 1

                    ' delcara la variable 
                    Dim inNumeroFicha As Integer = 0

                    ' almacena la variable
                    inNumeroFicha = CInt(dt.Rows(i).Item("FIPRNUFI").ToString)

                    ' instancio la clase ficha predial
                    Dim objFichaPredial As New cla_FICHPRED
                    Dim tblFichaPredial As New DataTable

                    tblFichaPredial = objFichaPredial.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(inNumeroFicha)

                    ' Inserta el registro 
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = "Nro_Ficha"
                    dr_FICHPRED("NIVEL02") = "Direccion"
                    dr_FICHPRED("NIVEL03") = "Munici_Ac"
                    dr_FICHPRED("NIVEL04") = "Correg_Ac"
                    dr_FICHPRED("NIVEL05") = "Barrio_Ac"
                    dr_FICHPRED("NIVEL06") = "Manzan_Ac"
                    dr_FICHPRED("NIVEL07") = "Predio_Ac"
                    dr_FICHPRED("NIVEL08") = "Edifio_Ac"
                    dr_FICHPRED("NIVEL09") = "Unidad_Ac"
                    dr_FICHPRED("NIVEL10") = "Sector_Ac"
                    dr_FICHPRED("NIVEL11") = "Catego_Ac"
                    dr_FICHPRED("NIVEL12") = "Cara_Pred"
                    dr_FICHPRED("NIVEL13") = "Adquisici"
                    dr_FICHPRED("NIVEL14") = "Litigio"
                    dr_FICHPRED("NIVEL15") = "Porc_Liti"

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    ' Inserta el registro 
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = Trim(tblFichaPredial.Rows(0).Item("FIPRNUFI")) & "_"
                    dr_FICHPRED("NIVEL02") = Trim(tblFichaPredial.Rows(0).Item("FIPRDIRE")) & "_"
                    dr_FICHPRED("NIVEL03") = Trim(tblFichaPredial.Rows(0).Item("FIPRMUNI")) & "_"
                    dr_FICHPRED("NIVEL04") = Trim(tblFichaPredial.Rows(0).Item("FIPRCORR")) & "_"
                    dr_FICHPRED("NIVEL05") = Trim(tblFichaPredial.Rows(0).Item("FIPRBARR")) & "_"
                    dr_FICHPRED("NIVEL06") = Trim(tblFichaPredial.Rows(0).Item("FIPRMANZ")) & "_"
                    dr_FICHPRED("NIVEL07") = Trim(tblFichaPredial.Rows(0).Item("FIPRPRED")) & "_"
                    dr_FICHPRED("NIVEL08") = Trim(tblFichaPredial.Rows(0).Item("FIPREDIF")) & "_"
                    dr_FICHPRED("NIVEL09") = Trim(tblFichaPredial.Rows(0).Item("FIPRUNPR")) & "_"
                    dr_FICHPRED("NIVEL10") = Trim(tblFichaPredial.Rows(0).Item("FIPRCLSE")) & "_"
                    dr_FICHPRED("NIVEL11") = Trim(tblFichaPredial.Rows(0).Item("FIPRCASU")) & "_"
                    dr_FICHPRED("NIVEL12") = Trim(tblFichaPredial.Rows(0).Item("FIPRCAPR")) & "_"
                    dr_FICHPRED("NIVEL13") = Trim(tblFichaPredial.Rows(0).Item("FIPRMOAD")) & "_"

                    If tblFichaPredial.Rows(0).Item("FIPRLITI") = True Then
                        dr_FICHPRED("NIVEL14") = "1" & "_"
                    Else
                        dr_FICHPRED("NIVEL14") = "2" & "_"
                    End If

                    dr_FICHPRED("NIVEL15") = Trim(tblFichaPredial.Rows(0).Item("FIPRPOLI")) & "_"

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    ' Inserta el registro limpio
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = ""
                    dr_FICHPRED("NIVEL02") = ""
                    dr_FICHPRED("NIVEL03") = ""
                    dr_FICHPRED("NIVEL04") = ""
                    dr_FICHPRED("NIVEL05") = ""
                    dr_FICHPRED("NIVEL06") = ""
                    dr_FICHPRED("NIVEL07") = ""
                    dr_FICHPRED("NIVEL08") = ""
                    dr_FICHPRED("NIVEL09") = ""
                    dr_FICHPRED("NIVEL10") = ""
                    dr_FICHPRED("NIVEL11") = ""
                    dr_FICHPRED("NIVEL12") = ""
                    dr_FICHPRED("NIVEL13") = ""
                    dr_FICHPRED("NIVEL14") = ""
                    dr_FICHPRED("NIVEL15") = ""

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    ' Inserta el registro 
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = ""
                    dr_FICHPRED("NIVEL02") = ""
                    dr_FICHPRED("NIVEL03") = "Munici_An"
                    dr_FICHPRED("NIVEL04") = "Correg_An"
                    dr_FICHPRED("NIVEL05") = "Barrio_An"
                    dr_FICHPRED("NIVEL06") = "Manzan_An"
                    dr_FICHPRED("NIVEL07") = "Predio_An"
                    dr_FICHPRED("NIVEL08") = "Edifio_An"
                    dr_FICHPRED("NIVEL09") = "Unidad_An"
                    dr_FICHPRED("NIVEL10") = "Sector_An"
                    dr_FICHPRED("NIVEL11") = "Catego_An"
                    dr_FICHPRED("NIVEL12") = ""
                    dr_FICHPRED("NIVEL13") = "Estrato"
                    dr_FICHPRED("NIVEL14") = "Categoria"
                    dr_FICHPRED("NIVEL15") = ""

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)


                    ' Inserta el registro 
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = ""
                    dr_FICHPRED("NIVEL02") = ""
                    dr_FICHPRED("NIVEL03") = Trim(tblFichaPredial.Rows(0).Item("FIPRMUAN")) & "_"
                    dr_FICHPRED("NIVEL04") = Trim(tblFichaPredial.Rows(0).Item("FIPRCOAN")) & "_"
                    dr_FICHPRED("NIVEL05") = Trim(tblFichaPredial.Rows(0).Item("FIPRBAAN")) & "_"
                    dr_FICHPRED("NIVEL06") = Trim(tblFichaPredial.Rows(0).Item("FIPRMAAN")) & "_"
                    dr_FICHPRED("NIVEL07") = Trim(tblFichaPredial.Rows(0).Item("FIPRPRAN")) & "_"
                    dr_FICHPRED("NIVEL08") = Trim(tblFichaPredial.Rows(0).Item("FIPREDAN")) & "_"
                    dr_FICHPRED("NIVEL09") = Trim(tblFichaPredial.Rows(0).Item("FIPRUPAN")) & "_"
                    dr_FICHPRED("NIVEL10") = Trim(tblFichaPredial.Rows(0).Item("FIPRCSAN")) & "_"
                    dr_FICHPRED("NIVEL11") = Trim(tblFichaPredial.Rows(0).Item("FIPRCASA")) & "_"
                    dr_FICHPRED("NIVEL12") = ""

                    ' consulta el estrato
                    Dim obESTRFIPR As New cla_ESTRFIPR
                    Dim dtESTRFIPR As New DataTable

                    dtESTRFIPR = obESTRFIPR.fun_Buscar_ESTRATO_X_NRO_DE_FICHA(inNumeroFicha)

                    If dtESTRFIPR.Rows.Count > 0 Then
                        dr_FICHPRED("NIVEL13") = Trim(dtESTRFIPR.Rows(0).Item("ESFPESTR")) & "_"
                    Else
                        dr_FICHPRED("NIVEL13") = ""
                    End If

                    ' consulta la categoria de predio
                    Dim obCAPRFIPR As New cla_CAPRFIPR
                    Dim dtCAPRFIPR As New DataTable

                    dtCAPRFIPR = obCAPRFIPR.fun_Buscar_CATEGORIA_X_NRO_DE_FICHA(inNumeroFicha)

                    If dtCAPRFIPR.Rows.Count > 0 Then
                        dr_FICHPRED("NIVEL14") = Trim(dtCAPRFIPR.Rows(0).Item("CPFPCAPR")) & "_"
                    Else
                        dr_FICHPRED("NIVEL14") = ""
                    End If

                    dr_FICHPRED("NIVEL15") = ""

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    ' Inserta el registro limpio
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = ""
                    dr_FICHPRED("NIVEL02") = ""
                    dr_FICHPRED("NIVEL03") = ""
                    dr_FICHPRED("NIVEL04") = ""
                    dr_FICHPRED("NIVEL05") = ""
                    dr_FICHPRED("NIVEL06") = ""
                    dr_FICHPRED("NIVEL07") = ""
                    dr_FICHPRED("NIVEL08") = ""
                    dr_FICHPRED("NIVEL09") = ""
                    dr_FICHPRED("NIVEL10") = ""
                    dr_FICHPRED("NIVEL11") = ""
                    dr_FICHPRED("NIVEL12") = ""
                    dr_FICHPRED("NIVEL13") = ""
                    dr_FICHPRED("NIVEL14") = ""
                    dr_FICHPRED("NIVEL15") = ""

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    '___________________________________________________

                    ' instancia la clase 
                    Dim objDestinoEconomico As New cla_FIPRDEEC
                    Dim tblDestinoEconomico As New DataTable

                    tblDestinoEconomico = objDestinoEconomico.fun_Consultar_FIPRDEEC_X_FICHA_PREDIAL(inNumeroFicha)

                    ' verifica la cantidad de registros
                    If tblDestinoEconomico.Rows.Count > 0 Then

                        ' Inserta el registro 
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = "Destino_Ec"
                        dr_FICHPRED("NIVEL02") = "Porcentaje(%)"

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)


                        ' declara la variable 
                        Dim q As Integer = 0

                        For q = 0 To tblDestinoEconomico.Rows.Count - 1

                            ' Inserta el registro 
                            dr_FICHPRED = dt_FICHPRED.NewRow()

                            dr_FICHPRED("NIVEL01") = Trim(tblDestinoEconomico.Rows(q).Item("FPDEDEEC")) & "_"
                            dr_FICHPRED("NIVEL02") = Trim(tblDestinoEconomico.Rows(q).Item("FPDEPORC")) & "_"

                            dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        Next

                        ' Inserta el registro limpio
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = ""
                        dr_FICHPRED("NIVEL02") = ""
                        dr_FICHPRED("NIVEL03") = ""
                        dr_FICHPRED("NIVEL04") = ""
                        dr_FICHPRED("NIVEL05") = ""
                        dr_FICHPRED("NIVEL06") = ""
                        dr_FICHPRED("NIVEL07") = ""
                        dr_FICHPRED("NIVEL08") = ""
                        dr_FICHPRED("NIVEL09") = ""
                        dr_FICHPRED("NIVEL10") = ""
                        dr_FICHPRED("NIVEL11") = ""
                        dr_FICHPRED("NIVEL12") = ""
                        dr_FICHPRED("NIVEL13") = ""
                        dr_FICHPRED("NIVEL14") = ""
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    End If

                    '___________________________________________________

                    ' instancia la clase 
                    Dim objPropietario As New cla_FIPRPROP
                    Dim tblPropietario As New DataTable

                    tblPropietario = objPropietario.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(inNumeroFicha)

                    ' verifica la cantidad de registros
                    If tblPropietario.Rows.Count > 0 Then

                        ' Inserta el registro 
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = "Secuencia"
                        dr_FICHPRED("NIVEL02") = "Calidad_P"
                        dr_FICHPRED("NIVEL03") = "Gravable"
                        dr_FICHPRED("NIVEL04") = "Sexo"
                        dr_FICHPRED("NIVEL05") = "Tipo_Docu"
                        dr_FICHPRED("NIVEL06") = "Nro_Docum"
                        dr_FICHPRED("NIVEL07") = "Nombre(s)"
                        dr_FICHPRED("NIVEL08") = "Pri_Apell"
                        dr_FICHPRED("NIVEL09") = "Seg_Apell"
                        dr_FICHPRED("NIVEL10") = "Derecho"
                        dr_FICHPRED("NIVEL11") = ""
                        dr_FICHPRED("NIVEL12") = ""
                        dr_FICHPRED("NIVEL13") = ""
                        dr_FICHPRED("NIVEL14") = ""
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        ' declara la variable 
                        Dim g As Integer = 0

                        For g = 0 To tblPropietario.Rows.Count - 1

                            ' Inserta el registro 
                            dr_FICHPRED = dt_FICHPRED.NewRow()

                            dr_FICHPRED("NIVEL01") = Trim(tblPropietario.Rows(g).Item("FPPRSECU")) & "_"
                            dr_FICHPRED("NIVEL02") = Trim(tblPropietario.Rows(g).Item("FPPRCAPR")) & "_"

                            If tblPropietario.Rows(g).Item("FPPRGRAV") = True Then
                                dr_FICHPRED("NIVEL03") = "1" & "_"
                            Else
                                dr_FICHPRED("NIVEL03") = "2" & "_"
                            End If

                            dr_FICHPRED("NIVEL04") = Trim(tblPropietario.Rows(g).Item("FPPRSEXO")) & "_"
                            dr_FICHPRED("NIVEL05") = Trim(tblPropietario.Rows(g).Item("FPPRTIDO")) & "_"
                            dr_FICHPRED("NIVEL06") = Trim(tblPropietario.Rows(g).Item("FPPRNUDO")) & "_"
                            dr_FICHPRED("NIVEL07") = Trim(tblPropietario.Rows(g).Item("FPPRNOMB")) & "_"
                            dr_FICHPRED("NIVEL08") = Trim(tblPropietario.Rows(g).Item("FPPRPRAP")) & "_"
                            dr_FICHPRED("NIVEL09") = Trim(tblPropietario.Rows(g).Item("FPPRSEAP")) & "_"
                            dr_FICHPRED("NIVEL10") = Trim(tblPropietario.Rows(g).Item("FPPRDERE")) & "_"
                            dr_FICHPRED("NIVEL11") = ""
                            dr_FICHPRED("NIVEL12") = ""
                            dr_FICHPRED("NIVEL13") = ""
                            dr_FICHPRED("NIVEL14") = ""
                            dr_FICHPRED("NIVEL15") = ""

                            dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        Next

                        ' Inserta el registro limpio
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = ""
                        dr_FICHPRED("NIVEL02") = ""
                        dr_FICHPRED("NIVEL03") = ""
                        dr_FICHPRED("NIVEL04") = ""
                        dr_FICHPRED("NIVEL05") = ""
                        dr_FICHPRED("NIVEL06") = ""
                        dr_FICHPRED("NIVEL07") = ""
                        dr_FICHPRED("NIVEL08") = ""
                        dr_FICHPRED("NIVEL09") = ""
                        dr_FICHPRED("NIVEL10") = ""
                        dr_FICHPRED("NIVEL11") = ""
                        dr_FICHPRED("NIVEL12") = ""
                        dr_FICHPRED("NIVEL13") = ""
                        dr_FICHPRED("NIVEL14") = ""
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        ' Inserta el registro 
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = "Secuencia"
                        dr_FICHPRED("NIVEL02") = "Escritura"
                        dr_FICHPRED("NIVEL03") = "Notaria"
                        dr_FICHPRED("NIVEL04") = "Fec_Escri"
                        dr_FICHPRED("NIVEL05") = "Fec_Regis"
                        dr_FICHPRED("NIVEL06") = "Tomo"
                        dr_FICHPRED("NIVEL07") = "Matricula"
                        dr_FICHPRED("NIVEL08") = ""
                        dr_FICHPRED("NIVEL09") = ""
                        dr_FICHPRED("NIVEL10") = ""
                        dr_FICHPRED("NIVEL11") = ""
                        dr_FICHPRED("NIVEL12") = ""
                        dr_FICHPRED("NIVEL13") = ""
                        dr_FICHPRED("NIVEL14") = ""
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        ' declara la variable 
                        Dim p As Integer = 0

                        For p = 0 To tblPropietario.Rows.Count - 1

                            ' Inserta el registro 
                            dr_FICHPRED = dt_FICHPRED.NewRow()

                            dr_FICHPRED("NIVEL01") = Trim(tblPropietario.Rows(p).Item("FPPRSECU")) & "_"
                            dr_FICHPRED("NIVEL02") = Trim(tblPropietario.Rows(p).Item("FPPRESCR")) & "_"
                            dr_FICHPRED("NIVEL03") = Trim(tblPropietario.Rows(p).Item("FPPRDENO")) & "-" & Trim(tblPropietario.Rows(p).Item("FPPRMUNO")) & "-" & Trim(tblPropietario.Rows(p).Item("FPPRNOTA")) & "_"
                            dr_FICHPRED("NIVEL04") = Trim(tblPropietario.Rows(p).Item("FPPRFEES")) & "_"
                            dr_FICHPRED("NIVEL05") = Trim(tblPropietario.Rows(p).Item("FPPRFERE")) & "_"
                            dr_FICHPRED("NIVEL06") = Trim(tblPropietario.Rows(p).Item("FPPRTOMO")) & "_"
                            dr_FICHPRED("NIVEL07") = Trim(tblPropietario.Rows(p).Item("FPPRMAIN")) & "_"
                            dr_FICHPRED("NIVEL08") = ""
                            dr_FICHPRED("NIVEL09") = ""
                            dr_FICHPRED("NIVEL10") = ""
                            dr_FICHPRED("NIVEL11") = ""
                            dr_FICHPRED("NIVEL12") = ""
                            dr_FICHPRED("NIVEL13") = ""
                            dr_FICHPRED("NIVEL14") = ""
                            dr_FICHPRED("NIVEL15") = ""

                            dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        Next

                        ' Inserta el registro limpio
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = ""
                        dr_FICHPRED("NIVEL02") = ""
                        dr_FICHPRED("NIVEL03") = ""
                        dr_FICHPRED("NIVEL04") = ""
                        dr_FICHPRED("NIVEL05") = ""
                        dr_FICHPRED("NIVEL06") = ""
                        dr_FICHPRED("NIVEL07") = ""
                        dr_FICHPRED("NIVEL08") = ""
                        dr_FICHPRED("NIVEL09") = ""
                        dr_FICHPRED("NIVEL10") = ""
                        dr_FICHPRED("NIVEL11") = ""
                        dr_FICHPRED("NIVEL12") = ""
                        dr_FICHPRED("NIVEL13") = ""
                        dr_FICHPRED("NIVEL14") = ""
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    End If

                    '_____________________________________________________

                    ' instancia la clase 
                    Dim objConstruccion As New cla_FIPRCONS
                    Dim tblConstruccion As New DataTable

                    tblConstruccion = objConstruccion.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(inNumeroFicha)

                    ' verifica la cantidad de registros
                    If tblConstruccion.Rows.Count > 0 Then

                        ' Inserta el registro 
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = "Nro_Const"
                        dr_FICHPRED("NIVEL02") = "Identific"
                        dr_FICHPRED("NIVEL03") = "Puntos"
                        dr_FICHPRED("NIVEL04") = "Area_Cons"
                        dr_FICHPRED("NIVEL05") = "Mejora"
                        dr_FICHPRED("NIVEL06") = "Ley_56"
                        dr_FICHPRED("NIVEL07") = "Acueducto"
                        dr_FICHPRED("NIVEL08") = "Alcantari"
                        dr_FICHPRED("NIVEL09") = "Energia"
                        dr_FICHPRED("NIVEL10") = "Telefono"
                        dr_FICHPRED("NIVEL11") = "Gas"
                        dr_FICHPRED("NIVEL12") = "Tot_Piso"
                        dr_FICHPRED("NIVEL13") = "Edad"
                        dr_FICHPRED("NIVEL14") = "(%)_Cons"
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        ' declara la variable 
                        Dim f As Integer = 0

                        For f = 0 To tblConstruccion.Rows.Count - 1

                            ' Inserta el registro 
                            dr_FICHPRED = dt_FICHPRED.NewRow()

                            dr_FICHPRED("NIVEL01") = Trim(tblConstruccion.Rows(f).Item("FPCOUNID")) & "_"
                            dr_FICHPRED("NIVEL02") = Trim(tblConstruccion.Rows(f).Item("FPCOTICO")) & "_"
                            dr_FICHPRED("NIVEL03") = Trim(tblConstruccion.Rows(f).Item("FPCOPUNT")) & "_"
                            dr_FICHPRED("NIVEL04") = Trim(tblConstruccion.Rows(f).Item("FPCOARCO")) & "_"

                            If tblConstruccion.Rows(f).Item("FPCOMEJO") = True Then
                                dr_FICHPRED("NIVEL05") = "1" & "_"
                            Else
                                dr_FICHPRED("NIVEL05") = "2" & "_"
                            End If

                            If tblConstruccion.Rows(f).Item("FPCOLEY") = True Then
                                dr_FICHPRED("NIVEL06") = "1" & "_"
                            Else
                                dr_FICHPRED("NIVEL06") = "2" & "_"
                            End If

                            dr_FICHPRED("NIVEL07") = Trim(tblConstruccion.Rows(f).Item("FPCOACUE")) & "_"
                            dr_FICHPRED("NIVEL08") = Trim(tblConstruccion.Rows(f).Item("FPCOALCA")) & "_"
                            dr_FICHPRED("NIVEL09") = Trim(tblConstruccion.Rows(f).Item("FPCOENER")) & "_"
                            dr_FICHPRED("NIVEL10") = Trim(tblConstruccion.Rows(f).Item("FPCOTELE")) & "_"
                            dr_FICHPRED("NIVEL11") = Trim(tblConstruccion.Rows(f).Item("FPCOGAS")) & "_"
                            dr_FICHPRED("NIVEL12") = Trim(tblConstruccion.Rows(f).Item("FPCOPISO")) & "_"
                            dr_FICHPRED("NIVEL13") = Trim(tblConstruccion.Rows(f).Item("FPCOEDCO")) & "_"
                            dr_FICHPRED("NIVEL14") = Trim(tblConstruccion.Rows(f).Item("FPCOPOCO")) & "_"
                            dr_FICHPRED("NIVEL15") = ""

                            dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        Next

                        ' Inserta el registro limpio
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = ""
                        dr_FICHPRED("NIVEL02") = ""
                        dr_FICHPRED("NIVEL03") = ""
                        dr_FICHPRED("NIVEL04") = ""
                        dr_FICHPRED("NIVEL05") = ""
                        dr_FICHPRED("NIVEL06") = ""
                        dr_FICHPRED("NIVEL07") = ""
                        dr_FICHPRED("NIVEL08") = ""
                        dr_FICHPRED("NIVEL09") = ""
                        dr_FICHPRED("NIVEL10") = ""
                        dr_FICHPRED("NIVEL11") = ""
                        dr_FICHPRED("NIVEL12") = ""
                        dr_FICHPRED("NIVEL13") = ""
                        dr_FICHPRED("NIVEL14") = ""
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    End If

                    '_____________________________________________________

                    ' agrega la calificación
                    If boAgregarCalificacion = True Then

                        ' instancia la clase 
                        Dim objCalificacion As New cla_FIPRCACO
                        Dim tblCalificacion As New DataTable

                        tblCalificacion = objCalificacion.fun_Consultar_FIPRCACO_X_FICHA_PREDIAL_TODAS_LAS_UNIDADES(inNumeroFicha)

                        ' verifica la cantidad de registros
                        If tblCalificacion.Rows.Count > 0 Then

                            ' Inserta el registro 
                            dr_FICHPRED = dt_FICHPRED.NewRow()

                            dr_FICHPRED("NIVEL01") = "Nro_Const"
                            dr_FICHPRED("NIVEL02") = "Detalle"
                            dr_FICHPRED("NIVEL03") = "Codigo"
                            dr_FICHPRED("NIVEL04") = "Puntos"
                            dr_FICHPRED("NIVEL05") = "Tipo"
                            dr_FICHPRED("NIVEL06") = ""
                            dr_FICHPRED("NIVEL07") = ""
                            dr_FICHPRED("NIVEL08") = ""
                            dr_FICHPRED("NIVEL09") = ""
                            dr_FICHPRED("NIVEL10") = ""
                            dr_FICHPRED("NIVEL11") = ""
                            dr_FICHPRED("NIVEL12") = ""
                            dr_FICHPRED("NIVEL13") = ""
                            dr_FICHPRED("NIVEL14") = ""
                            dr_FICHPRED("NIVEL15") = ""

                            dt_FICHPRED.Rows.Add(dr_FICHPRED)

                            ' declara la variable 
                            Dim f As Integer = 0

                            For f = 0 To tblCalificacion.Rows.Count - 1

                                ' Inserta el registro 
                                dr_FICHPRED = dt_FICHPRED.NewRow()

                                dr_FICHPRED("NIVEL01") = Trim(tblCalificacion.Rows(f).Item("FPCCUNID")) & "_"
                                dr_FICHPRED("NIVEL02") = Trim(fun_Buscar_Lista_Valores_CODICALI(tblCalificacion.Rows(f).Item("FPCCCODI")))
                                dr_FICHPRED("NIVEL03") = Trim(tblCalificacion.Rows(f).Item("FPCCCODI")) & "_"
                                dr_FICHPRED("NIVEL04") = Trim(tblCalificacion.Rows(f).Item("FPCCPUNT")) & "_"
                                dr_FICHPRED("NIVEL05") = Trim(tblCalificacion.Rows(f).Item("FPCCTIPO")) & "_"
                                dr_FICHPRED("NIVEL06") = ""
                                dr_FICHPRED("NIVEL07") = ""
                                dr_FICHPRED("NIVEL08") = ""
                                dr_FICHPRED("NIVEL09") = ""
                                dr_FICHPRED("NIVEL10") = ""
                                dr_FICHPRED("NIVEL11") = ""
                                dr_FICHPRED("NIVEL12") = ""
                                dr_FICHPRED("NIVEL13") = ""
                                dr_FICHPRED("NIVEL14") = ""
                                dr_FICHPRED("NIVEL15") = ""

                                dt_FICHPRED.Rows.Add(dr_FICHPRED)

                            Next

                            ' Inserta el registro limpio
                            dr_FICHPRED = dt_FICHPRED.NewRow()

                            dr_FICHPRED("NIVEL01") = ""
                            dr_FICHPRED("NIVEL02") = ""
                            dr_FICHPRED("NIVEL03") = ""
                            dr_FICHPRED("NIVEL04") = ""
                            dr_FICHPRED("NIVEL05") = ""
                            dr_FICHPRED("NIVEL06") = ""
                            dr_FICHPRED("NIVEL07") = ""
                            dr_FICHPRED("NIVEL08") = ""
                            dr_FICHPRED("NIVEL09") = ""
                            dr_FICHPRED("NIVEL10") = ""
                            dr_FICHPRED("NIVEL11") = ""
                            dr_FICHPRED("NIVEL12") = ""
                            dr_FICHPRED("NIVEL13") = ""
                            dr_FICHPRED("NIVEL14") = ""
                            dr_FICHPRED("NIVEL15") = ""

                            dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        End If
                    End If

                    '_____________________________________________________

                    ' instancio la clase ficha predial
                    Dim objFichaPredial1 As New cla_FICHPRED
                    Dim tblFichaPredial1 As New DataTable

                    tblFichaPredial1 = objFichaPredial1.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(inNumeroFicha)

                    ' Inserta el registro 
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = "Terreno"
                    dr_FICHPRED("NIVEL02") = ""
                    dr_FICHPRED("NIVEL03") = "Coe_Edificio"
                    dr_FICHPRED("NIVEL04") = "Coe_Predio"
                    dr_FICHPRED("NIVEL05") = ""
                    dr_FICHPRED("NIVEL06") = ""
                    dr_FICHPRED("NIVEL07") = ""
                    dr_FICHPRED("NIVEL08") = ""
                    dr_FICHPRED("NIVEL09") = ""
                    dr_FICHPRED("NIVEL10") = ""
                    dr_FICHPRED("NIVEL11") = ""
                    dr_FICHPRED("NIVEL12") = ""
                    dr_FICHPRED("NIVEL13") = ""
                    dr_FICHPRED("NIVEL14") = ""
                    dr_FICHPRED("NIVEL15") = ""

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    ' Inserta el registro 
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = Trim(tblFichaPredial1.Rows(0).Item("FIPRARTE")) & "_"
                    dr_FICHPRED("NIVEL02") = ""
                    dr_FICHPRED("NIVEL03") = Trim(tblFichaPredial1.Rows(0).Item("FIPRCOED")) & "_"
                    dr_FICHPRED("NIVEL04") = Trim(tblFichaPredial1.Rows(0).Item("FIPRCOPR")) & "_"
                    dr_FICHPRED("NIVEL05") = ""
                    dr_FICHPRED("NIVEL06") = ""
                    dr_FICHPRED("NIVEL07") = ""
                    dr_FICHPRED("NIVEL08") = ""
                    dr_FICHPRED("NIVEL09") = ""
                    dr_FICHPRED("NIVEL10") = ""
                    dr_FICHPRED("NIVEL11") = ""
                    dr_FICHPRED("NIVEL12") = ""
                    dr_FICHPRED("NIVEL13") = ""
                    dr_FICHPRED("NIVEL14") = ""
                    dr_FICHPRED("NIVEL15") = ""

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    ' Inserta el registro limpio
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = ""
                    dr_FICHPRED("NIVEL02") = ""
                    dr_FICHPRED("NIVEL03") = ""
                    dr_FICHPRED("NIVEL04") = ""
                    dr_FICHPRED("NIVEL05") = ""
                    dr_FICHPRED("NIVEL06") = ""
                    dr_FICHPRED("NIVEL07") = ""
                    dr_FICHPRED("NIVEL08") = ""
                    dr_FICHPRED("NIVEL09") = ""
                    dr_FICHPRED("NIVEL10") = ""
                    dr_FICHPRED("NIVEL11") = ""
                    dr_FICHPRED("NIVEL12") = ""
                    dr_FICHPRED("NIVEL13") = ""
                    dr_FICHPRED("NIVEL14") = ""
                    dr_FICHPRED("NIVEL15") = ""

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    '_____________________________________________________

                    ' instancia la clase 
                    Dim objZonaFisica As New cla_FIPRZOFI
                    Dim tblZonaFisica As New DataTable

                    tblZonaFisica = objZonaFisica.fun_Consultar_FIPRZOFI_X_FICHA_PREDIAL(inNumeroFicha)

                    ' verifica la cantidad de registros
                    If tblZonaFisica.Rows.Count > 0 Then

                        ' Inserta el registro 
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = "Zona_Fisica"
                        dr_FICHPRED("NIVEL02") = "Porcentaje(%)"

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)


                        ' declara la variable 
                        Dim q As Integer = 0

                        For q = 0 To tblZonaFisica.Rows.Count - 1

                            ' Inserta el registro 
                            dr_FICHPRED = dt_FICHPRED.NewRow()

                            dr_FICHPRED("NIVEL01") = "F" & Trim(tblZonaFisica.Rows(q).Item("FPZFZOFI")) & "_"
                            dr_FICHPRED("NIVEL02") = Trim(tblZonaFisica.Rows(q).Item("FPZFPORC")) & "_"

                            dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        Next

                        ' Inserta el registro limpio
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = ""
                        dr_FICHPRED("NIVEL02") = ""
                        dr_FICHPRED("NIVEL03") = ""
                        dr_FICHPRED("NIVEL04") = ""
                        dr_FICHPRED("NIVEL05") = ""
                        dr_FICHPRED("NIVEL06") = ""
                        dr_FICHPRED("NIVEL07") = ""
                        dr_FICHPRED("NIVEL08") = ""
                        dr_FICHPRED("NIVEL09") = ""
                        dr_FICHPRED("NIVEL10") = ""
                        dr_FICHPRED("NIVEL11") = ""
                        dr_FICHPRED("NIVEL12") = ""
                        dr_FICHPRED("NIVEL13") = ""
                        dr_FICHPRED("NIVEL14") = ""
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    End If

                    '_____________________________________________________

                    ' instancia la clase 
                    Dim objZonaEconomica As New cla_FIPRZOEC
                    Dim tblZonaEconomica As New DataTable

                    tblZonaEconomica = objZonaEconomica.fun_Consultar_FIPRZOEC_X_FICHA_PREDIAL(inNumeroFicha)

                    ' verifica la cantidad de registros
                    If tblZonaEconomica.Rows.Count > 0 Then

                        ' Inserta el registro 
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = "Zona_Econo"
                        dr_FICHPRED("NIVEL02") = "Porcentaje(%)"

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)


                        ' declara la variable 
                        Dim q As Integer = 0

                        For q = 0 To tblZonaEconomica.Rows.Count - 1

                            ' Inserta el registro 
                            dr_FICHPRED = dt_FICHPRED.NewRow()

                            dr_FICHPRED("NIVEL01") = "E" & Trim(tblZonaEconomica.Rows(q).Item("FPZEZOEC")) & "_"
                            dr_FICHPRED("NIVEL02") = Trim(tblZonaEconomica.Rows(q).Item("FPZEPORC")) & "_"

                            dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        Next

                        ' Inserta el registro limpio
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = ""
                        dr_FICHPRED("NIVEL02") = ""
                        dr_FICHPRED("NIVEL03") = ""
                        dr_FICHPRED("NIVEL04") = ""
                        dr_FICHPRED("NIVEL05") = ""
                        dr_FICHPRED("NIVEL06") = ""
                        dr_FICHPRED("NIVEL07") = ""
                        dr_FICHPRED("NIVEL08") = ""
                        dr_FICHPRED("NIVEL09") = ""
                        dr_FICHPRED("NIVEL10") = ""
                        dr_FICHPRED("NIVEL11") = ""
                        dr_FICHPRED("NIVEL12") = ""
                        dr_FICHPRED("NIVEL13") = ""
                        dr_FICHPRED("NIVEL14") = ""
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    End If

                    '_____________________________________________________

                    ' instancia la clase 
                    Dim objLindero As New cla_FIPRLIND
                    Dim tblLindero As New DataTable

                    tblLindero = objLindero.fun_Consultar_FIPRLIND_X_FICHA_PREDIAL(inNumeroFicha)

                    ' verifica la cantidad de registros
                    If tblLindero.Rows.Count > 0 Then

                        ' Inserta el registro 
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = "Punto_Car"
                        dr_FICHPRED("NIVEL02") = "Lindero"
                        dr_FICHPRED("NIVEL03") = ""
                        dr_FICHPRED("NIVEL04") = ""
                        dr_FICHPRED("NIVEL05") = ""
                        dr_FICHPRED("NIVEL06") = ""
                        dr_FICHPRED("NIVEL07") = ""
                        dr_FICHPRED("NIVEL08") = ""
                        dr_FICHPRED("NIVEL09") = ""
                        dr_FICHPRED("NIVEL10") = ""
                        dr_FICHPRED("NIVEL11") = ""
                        dr_FICHPRED("NIVEL12") = ""
                        dr_FICHPRED("NIVEL13") = ""
                        dr_FICHPRED("NIVEL14") = ""
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        ' declara la variable 
                        Dim z As Integer = 0

                        For z = 0 To tblLindero.Rows.Count - 1

                            ' Inserta el registro 
                            dr_FICHPRED = dt_FICHPRED.NewRow()

                            dr_FICHPRED("NIVEL01") = Trim(tblLindero.Rows(z).Item("FPLIPUCA")) & "_"
                            dr_FICHPRED("NIVEL02") = Trim(tblLindero.Rows(z).Item("FPLICOLI")) & "_"
                            dr_FICHPRED("NIVEL03") = ""
                            dr_FICHPRED("NIVEL04") = ""
                            dr_FICHPRED("NIVEL05") = ""
                            dr_FICHPRED("NIVEL06") = ""
                            dr_FICHPRED("NIVEL07") = ""
                            dr_FICHPRED("NIVEL08") = ""
                            dr_FICHPRED("NIVEL09") = ""
                            dr_FICHPRED("NIVEL10") = ""
                            dr_FICHPRED("NIVEL11") = ""
                            dr_FICHPRED("NIVEL12") = ""
                            dr_FICHPRED("NIVEL13") = ""
                            dr_FICHPRED("NIVEL14") = ""
                            dr_FICHPRED("NIVEL15") = ""

                            dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        Next

                        ' Inserta el registro limpio
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = ""
                        dr_FICHPRED("NIVEL02") = ""
                        dr_FICHPRED("NIVEL03") = ""
                        dr_FICHPRED("NIVEL04") = ""
                        dr_FICHPRED("NIVEL05") = ""
                        dr_FICHPRED("NIVEL06") = ""
                        dr_FICHPRED("NIVEL07") = ""
                        dr_FICHPRED("NIVEL08") = ""
                        dr_FICHPRED("NIVEL09") = ""
                        dr_FICHPRED("NIVEL10") = ""
                        dr_FICHPRED("NIVEL11") = ""
                        dr_FICHPRED("NIVEL12") = ""
                        dr_FICHPRED("NIVEL13") = ""
                        dr_FICHPRED("NIVEL14") = ""
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    End If

                    '____________________________________________

                    ' instancia la clase 
                    Dim objCartografia As New cla_FIPRCART
                    Dim tblCartografia As New DataTable

                    tblCartografia = objCartografia.fun_Consultar_FIPRCART_X_FICHA_PREDIAL(inNumeroFicha)

                    ' verifica la cantidad de registros
                    If tblCartografia.Rows.Count > 0 Then

                        ' Inserta el registro 
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = "Plancha"
                        dr_FICHPRED("NIVEL02") = "Ventana"
                        dr_FICHPRED("NIVEL03") = "Escala"
                        dr_FICHPRED("NIVEL04") = "Vigencia"
                        dr_FICHPRED("NIVEL05") = "Vuelo"
                        dr_FICHPRED("NIVEL06") = "Faja"
                        dr_FICHPRED("NIVEL07") = "Foto"
                        dr_FICHPRED("NIVEL08") = "Vigencia"
                        dr_FICHPRED("NIVEL09") = "Ampliacio"
                        dr_FICHPRED("NIVEL10") = "Escala"
                        dr_FICHPRED("NIVEL11") = ""
                        dr_FICHPRED("NIVEL12") = ""
                        dr_FICHPRED("NIVEL13") = ""
                        dr_FICHPRED("NIVEL14") = ""
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        ' declara la variable 
                        Dim x As Integer = 0

                        For x = 0 To tblCartografia.Rows.Count - 1

                            ' Inserta el registro 
                            dr_FICHPRED = dt_FICHPRED.NewRow()

                            dr_FICHPRED("NIVEL01") = Trim(tblCartografia.Rows(x).Item("FPCAPLAN")) & "_"
                            dr_FICHPRED("NIVEL02") = Trim(tblCartografia.Rows(x).Item("FPCAVENT")) & "_"
                            dr_FICHPRED("NIVEL03") = Trim(tblCartografia.Rows(x).Item("FPCAESGR")) & "_"
                            dr_FICHPRED("NIVEL04") = Trim(tblCartografia.Rows(x).Item("FPCAVIGR")) & "_"
                            dr_FICHPRED("NIVEL05") = Trim(tblCartografia.Rows(x).Item("FPCAVUEL")) & "_"
                            dr_FICHPRED("NIVEL06") = Trim(tblCartografia.Rows(x).Item("FPCAFAJA")) & "_"
                            dr_FICHPRED("NIVEL07") = Trim(tblCartografia.Rows(x).Item("FPCAFOTO")) & "_"
                            dr_FICHPRED("NIVEL08") = Trim(tblCartografia.Rows(x).Item("FPCAVIAE")) & "_"
                            dr_FICHPRED("NIVEL09") = Trim(tblCartografia.Rows(x).Item("FPCAAMPL")) & "_"
                            dr_FICHPRED("NIVEL10") = Trim(tblCartografia.Rows(x).Item("FPCAESAE")) & "_"
                            dr_FICHPRED("NIVEL11") = ""
                            dr_FICHPRED("NIVEL12") = ""
                            dr_FICHPRED("NIVEL13") = ""
                            dr_FICHPRED("NIVEL14") = ""
                            dr_FICHPRED("NIVEL15") = ""

                            dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        Next

                        ' Inserta el registro limpio
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = ""
                        dr_FICHPRED("NIVEL02") = ""
                        dr_FICHPRED("NIVEL03") = ""
                        dr_FICHPRED("NIVEL04") = ""
                        dr_FICHPRED("NIVEL05") = ""
                        dr_FICHPRED("NIVEL06") = ""
                        dr_FICHPRED("NIVEL07") = ""
                        dr_FICHPRED("NIVEL08") = ""
                        dr_FICHPRED("NIVEL09") = ""
                        dr_FICHPRED("NIVEL10") = ""
                        dr_FICHPRED("NIVEL11") = ""
                        dr_FICHPRED("NIVEL12") = ""
                        dr_FICHPRED("NIVEL13") = ""
                        dr_FICHPRED("NIVEL14") = ""
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    End If


                Next


                '___________________________________________________

                ' crea la tabla maestra
                dt_FICHPRED_TOTAL = New DataTable

                ' llena la tabla
                dt_FICHPRED_TOTAL = dt_FICHPRED
                'dt_FICHPRED_TOTAL = dt_FIPRDEEC

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt_FICHPRED_TOTAL

                ' llena los totales
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = dt_FICHPRED_TOTAL.Rows.Count

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_ReporteCantidadDePrediosConTomoDiferenteDeCero()
        Try
            Me.txtFIPRESTADISTICO.Text = ""
            Me.cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "count(FiprNufi) as Cantidad From "
            ParametrosConsulta += "FichPred where "
            ParametrosConsulta += "Exists(Select 1 from FiprProp Where FiprNufi = FpprNufi And FpprTomo <> 0 and FpprEsta = 'ac') and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' suma la totalidad de los registros encontrados
                Dim inTotalRegistros As Integer = CType(dt.Rows(0).Item("Cantidad"), Integer)

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt

                ' llena los totales
                lblTotalRegistros.Text = CType(inTotalRegistros, String)

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                Me.strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Me.dgvFIPRESTA.DataSource = New DataTable

                Me.txtFIPRESTADISTICO.Text = ""
                Me.lblTotalPorcentaje.Text = ""
                Me.lblTotalRegistros.Text = ""

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_GenerarCantidadDePrediosQueFaltanPorLevantarEnTrabajoDeCampo()

        Try
            Me.txtFIPRESTADISTICO.Text = ""
            Me.cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "TrcaVige as Vigencia, sum(TrcaPrnu) as Cantidad from TRABCAMP "
            ParametrosConsulta += "where "
            ParametrosConsulta += "TrcaEsta IN('ac','ej') "
            ParametrosConsulta += "group by TrcaVige "
            ParametrosConsulta += "order by TrcaVige "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' suma la totalidad de los registros encontrados
                Dim inTotalRegistros As Integer = 0

                Dim i As Integer = 0

                For i = 0 To dt.Rows.Count - 1

                    inTotalRegistros += CType(dt.Rows(i).Item("Cantidad"), Integer)

                Next

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt

                ' llena los totales
                lblTotalRegistros.Text = CType(inTotalRegistros, String)

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                Me.strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Me.dgvFIPRESTA.DataSource = New DataTable

                Me.txtFIPRESTADISTICO.Text = ""
                Me.lblTotalPorcentaje.Text = ""
                Me.lblTotalRegistros.Text = ""

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_GenerarCantidadPrediosQueNoSonMejoras()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "count(1) as Cantidad "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "(exists(select 1 from fiprcons where fiprnufi = fpconufi and fpcomejo = 0 ) or (not exists(select 1 from fiprcons where fiprnufi = fpconufi ))) and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' "

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

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' suma la totalidad de los registros encontrados
                Dim inTotalRegistros As Integer

                inTotalRegistros += CType(dt.Rows(0).Item("Cantidad"), Integer)

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt

                ' llena los totales
                lblTotalRegistros.Text = CType(inTotalRegistros, String)

                ' inserta la totalidad de registros
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & vbCrLf & vbCrLf & "------------------------- "
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & "Total registros: " & inTotalRegistros & " -------------------------"
                strBARRESTA.Items(2).Text = "Registros : " & inTotalRegistros

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_GenerarCantidadPrediosQueSonMejoras()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "count(1) as Cantidad "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "exists(select 1 from fiprcons where fiprnufi = fpconufi and fpcomejo = 1) and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' "

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

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' suma la totalidad de los registros encontrados
                Dim inTotalRegistros As Integer

                inTotalRegistros += CType(dt.Rows(0).Item("Cantidad"), Integer)

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt

                ' llena los totales
                lblTotalRegistros.Text = CType(inTotalRegistros, String)

                ' inserta la totalidad de registros
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & vbCrLf & vbCrLf & "------------------------- "
                txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & "Total registros: " & inTotalRegistros & " -------------------------"
                strBARRESTA.Items(2).Text = "Registros : " & inTotalRegistros

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Dim tbl15 As New DataTable
                Me.dgvFIPRESTA.DataSource = tbl15

                txtFIPRESTADISTICO.Text = ""
                lblTotalPorcentaje.Text = ""
                lblTotalRegistros.Text = ""

            End If

            cmdGENERAR.Enabled = True
            cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_GenerarEstractificacion()
        Try
            txtFIPRESTADISTICO.Text = ""
            cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "Esfpestr, "
            ParametrosConsulta += "count(Esfpestr) as EsfpCant "
            ParametrosConsulta += "From EstrFipr, FichPred where "
            ParametrosConsulta += "FiprNufi = EsfpNufi and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "EsfpEsta like '" & Trim(stFIPRESTA) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' "
            ParametrosConsulta += "group by Esfpestr "

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

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' Crea objeto de columnas y registros
                Dim dt1 As New DataTable
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Estrato", GetType(String)))
                dt1.Columns.Add(New DataColumn("Descripcion", GetType(String)))
                dt1.Columns.Add(New DataColumn("Cantidad", GetType(Integer)))
                dt1.Columns.Add(New DataColumn("Porcentaje(%)", GetType(String)))

                ' suma la totalidad de los registros encontrados
                Dim inTotalRegistros As Integer
                Dim doTotalPorcentaje As Double
                Dim i As Integer

                For i = 0 To dt.Rows.Count - 1
                    inTotalRegistros += CType(dt.Rows(i).Item("ESFPCANT"), Integer)
                Next

                ' inserta la consulta agrupada 
                Dim j As Integer

                For j = 0 To dt.Rows.Count - 1

                    ' declara las variables
                    Dim stESFPESTR As String = Trim(dt.Rows(j).Item("ESFPESTR"))
                    Dim stESFPDESC As String = fun_Buscar_Lista_Valores_ESTRATO(dt.Rows(j).Item("ESFPESTR"))
                    Dim stESFPCANT As String = Trim(dt.Rows(j).Item("ESFPCANT"))
                    Dim stESFPPORC As String = fun_Formato_Decimal_2_Decimales(Trim(CType((100 * stESFPCANT) / inTotalRegistros, Double)))

                    ' suma el porcentaje
                    doTotalPorcentaje += CType(stESFPPORC, Double)

                    ' inserta el registro campo texto 
                    txtFIPRESTADISTICO.Text += "Destino: " & stESFPESTR & " " & stESFPDESC & _
                                        "Cantidad: " & stESFPCANT & " " & _
                                        "%: " & stESFPPORC & vbCrLf

                    ' Inserta el registro en el DataTable
                    dr1 = dt1.NewRow()
                    dr1("Estrato") = stESFPESTR
                    dr1("Descripcion") = stESFPDESC
                    dr1("Cantidad") = stESFPCANT
                    dr1("Porcentaje(%)") = stESFPPORC
                    dt1.Rows.Add(dr1)

                Next

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt1

                ' llena los totales
                Me.lblTotalPorcentaje.Text = CType(doTotalPorcentaje, Integer)
                Me.lblTotalRegistros.Text = CType(inTotalRegistros, String)

                ' inserta la totalidad de registros
                Me.txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & vbCrLf & vbCrLf & "------------------------- "
                Me.txtFIPRESTADISTICO.Text = txtFIPRESTADISTICO.Text & "Total registros: " & inTotalRegistros & " -------------------------"
                Me.strBARRESTA.Items(2).Text = "Registros : " & inTotalRegistros

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                Me.strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Me.dgvFIPRESTA.DataSource = New DataTable

                Me.txtFIPRESTADISTICO.Text = ""
                Me.lblTotalPorcentaje.Text = ""
                Me.lblTotalRegistros.Text = ""

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Me.cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_GenerarRegistroControl()

        Try
            Me.txtFIPRESTADISTICO.Text = ""
            Me.cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FIPRNUFI AS NRO_FICHA, "
            ParametrosConsulta += "FIPRMUNI AS MUNICIPIO, "
            ParametrosConsulta += "FIPRCORR AS CORREGIMI, "
            ParametrosConsulta += "FIPRBARR AS BARRIO, "
            ParametrosConsulta += "FIPRMANZ AS MANZ_VERE, "
            ParametrosConsulta += "FIPRPRED AS PREDIO, "
            ParametrosConsulta += "FIPREDIF AS EDIFICIO, "
            ParametrosConsulta += "FIPRUNPR AS UNID_PRED, "
            ParametrosConsulta += "FIPRCLSE AS SECTOR, "
            ParametrosConsulta += "FIPRTIFI AS TIPO_FICHA, "
            ParametrosConsulta += "RECOINGE AS INGENIERO, "
            ParametrosConsulta += "RECOPRED AS PREDIADOR, "
            ParametrosConsulta += "RECOEMPR AS EMPRESA, "
            ParametrosConsulta += "RECOPROP AS PROPIETARIO, "
            ParametrosConsulta += "RECOREPR AS REPRESENTANTE, "
            ParametrosConsulta += "RECOFECH + '.' AS FECHA, "
            ParametrosConsulta += "FIPROBSE AS OBSERVACION "
            ParametrosConsulta += "From REGICONT, FichPred where "
            ParametrosConsulta += "FiprNufi = RECONufi and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(txtFIPRTIFI.Text) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' "
            ParametrosConsulta += "ORDER by FiprClse, FiprTifi, FiprMuni, FiprCorr, FiprBarr, FiprManz, FiprPred, FiprEdif, FiprUnpr "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt)

            ' cierra la conexion
            oConexion.Close()

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt

                Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count
            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Me.dgvFIPRESTA.DataSource = New DataTable

                Me.txtFIPRESTADISTICO.Text = ""

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_ReporteFichaResumen()

        Try
            Me.txtFIPRESTADISTICO.Text = ""
            Me.cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' predetermina las variables
            stFIPRTIFI = "2"

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select FiprNufi "
            ParametrosConsulta += "From FichPred "
            ParametrosConsulta += "where "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' "
            ParametrosConsulta += "Order by FiprClse,FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr "

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

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                Dim boAgregarCalificacion As Boolean = True

                If MessageBox.Show("¿ Desea agregar la calificación de construcción en el reporte ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    boAgregarCalificacion = True
                Else
                    boAgregarCalificacion = False
                End If

                ' crea la tabla
                dt_FICHPRED = New DataTable

                ' crea el registro
                Dim dr_FICHPRED As DataRow

                ' Crea las columnas
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL01", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL02", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL03", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL04", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL05", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL06", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL07", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL08", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL09", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL10", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL11", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL12", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL13", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL14", GetType(String)))
                dt_FICHPRED.Columns.Add(New DataColumn("NIVEL15", GetType(String)))

                ' declara la variable
                Dim i As Integer

                For i = 0 To dt.Rows.Count - 1

                    ' delcara la variable 
                    Dim inNumeroFicha As Integer = 0

                    ' almacena la variable
                    inNumeroFicha = CInt(dt.Rows(i).Item("FIPRNUFI").ToString)

                    ' instancio la clase ficha predial
                    Dim objFichaPredial As New cla_FICHPRED
                    Dim tblFichaPredial As New DataTable

                    tblFichaPredial = objFichaPredial.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(inNumeroFicha)

                    ' Inserta el registro 
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = "Nro_Ficha"
                    dr_FICHPRED("NIVEL02") = "Direccion"
                    dr_FICHPRED("NIVEL03") = "Munici_Ac"
                    dr_FICHPRED("NIVEL04") = "Correg_Ac"
                    dr_FICHPRED("NIVEL05") = "Barrio_Ac"
                    dr_FICHPRED("NIVEL06") = "Manzan_Ac"
                    dr_FICHPRED("NIVEL07") = "Predio_Ac"
                    dr_FICHPRED("NIVEL08") = "Edifio_Ac"
                    dr_FICHPRED("NIVEL09") = ""
                    dr_FICHPRED("NIVEL10") = "Sector_Ac"
                    dr_FICHPRED("NIVEL11") = "Catego_Ac"
                    dr_FICHPRED("NIVEL12") = "Cara_Pred"
                    dr_FICHPRED("NIVEL13") = ""
                    dr_FICHPRED("NIVEL14") = ""
                    dr_FICHPRED("NIVEL15") = ""

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    ' Inserta el registro 
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = Trim(tblFichaPredial.Rows(0).Item("FIPRNUFI")) & "_"
                    dr_FICHPRED("NIVEL02") = Trim(tblFichaPredial.Rows(0).Item("FIPRDIRE")) & "_"
                    dr_FICHPRED("NIVEL03") = Trim(tblFichaPredial.Rows(0).Item("FIPRMUNI")) & "_"
                    dr_FICHPRED("NIVEL04") = Trim(tblFichaPredial.Rows(0).Item("FIPRCORR")) & "_"
                    dr_FICHPRED("NIVEL05") = Trim(tblFichaPredial.Rows(0).Item("FIPRBARR")) & "_"
                    dr_FICHPRED("NIVEL06") = Trim(tblFichaPredial.Rows(0).Item("FIPRMANZ")) & "_"
                    dr_FICHPRED("NIVEL07") = Trim(tblFichaPredial.Rows(0).Item("FIPRPRED")) & "_"
                    dr_FICHPRED("NIVEL08") = Trim(tblFichaPredial.Rows(0).Item("FIPREDIF")) & "_"
                    dr_FICHPRED("NIVEL09") = ""
                    dr_FICHPRED("NIVEL10") = Trim(tblFichaPredial.Rows(0).Item("FIPRCLSE")) & "_"
                    dr_FICHPRED("NIVEL11") = Trim(tblFichaPredial.Rows(0).Item("FIPRCASU")) & "_"
                    dr_FICHPRED("NIVEL12") = Trim(tblFichaPredial.Rows(0).Item("FIPRCAPR")) & "_"
                    dr_FICHPRED("NIVEL13") = ""
                    dr_FICHPRED("NIVEL14") = ""
                    dr_FICHPRED("NIVEL15") = ""

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    ' Inserta el registro limpio
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = ""
                    dr_FICHPRED("NIVEL02") = ""
                    dr_FICHPRED("NIVEL03") = ""
                    dr_FICHPRED("NIVEL04") = ""
                    dr_FICHPRED("NIVEL05") = ""
                    dr_FICHPRED("NIVEL06") = ""
                    dr_FICHPRED("NIVEL07") = ""
                    dr_FICHPRED("NIVEL08") = ""
                    dr_FICHPRED("NIVEL09") = ""
                    dr_FICHPRED("NIVEL10") = ""
                    dr_FICHPRED("NIVEL11") = ""
                    dr_FICHPRED("NIVEL12") = ""
                    dr_FICHPRED("NIVEL13") = ""
                    dr_FICHPRED("NIVEL14") = ""
                    dr_FICHPRED("NIVEL15") = ""

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    ' Inserta el registro 
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = ""
                    dr_FICHPRED("NIVEL02") = ""
                    dr_FICHPRED("NIVEL03") = "Munici_An"
                    dr_FICHPRED("NIVEL04") = "Correg_An"
                    dr_FICHPRED("NIVEL05") = "Barrio_An"
                    dr_FICHPRED("NIVEL06") = "Manzan_An"
                    dr_FICHPRED("NIVEL07") = "Predio_An"
                    dr_FICHPRED("NIVEL08") = "Edifio_An"
                    dr_FICHPRED("NIVEL09") = ""
                    dr_FICHPRED("NIVEL10") = "Sector_An"
                    dr_FICHPRED("NIVEL11") = "Catego_An"
                    dr_FICHPRED("NIVEL12") = ""
                    dr_FICHPRED("NIVEL13") = ""
                    dr_FICHPRED("NIVEL14") = ""
                    dr_FICHPRED("NIVEL15") = ""

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)


                    ' Inserta el registro 
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = ""
                    dr_FICHPRED("NIVEL02") = ""
                    dr_FICHPRED("NIVEL03") = Trim(tblFichaPredial.Rows(0).Item("FIPRMUAN")) & "_"
                    dr_FICHPRED("NIVEL04") = Trim(tblFichaPredial.Rows(0).Item("FIPRCOAN")) & "_"
                    dr_FICHPRED("NIVEL05") = Trim(tblFichaPredial.Rows(0).Item("FIPRBAAN")) & "_"
                    dr_FICHPRED("NIVEL06") = Trim(tblFichaPredial.Rows(0).Item("FIPRMAAN")) & "_"
                    dr_FICHPRED("NIVEL07") = Trim(tblFichaPredial.Rows(0).Item("FIPRPRAN")) & "_"
                    dr_FICHPRED("NIVEL08") = Trim(tblFichaPredial.Rows(0).Item("FIPREDAN")) & "_"
                    dr_FICHPRED("NIVEL09") = ""
                    dr_FICHPRED("NIVEL10") = Trim(tblFichaPredial.Rows(0).Item("FIPRCSAN")) & "_"
                    dr_FICHPRED("NIVEL11") = Trim(tblFichaPredial.Rows(0).Item("FIPRCASA")) & "_"
                    dr_FICHPRED("NIVEL12") = ""
                    dr_FICHPRED("NIVEL13") = ""
                    dr_FICHPRED("NIVEL14") = ""
                    dr_FICHPRED("NIVEL15") = ""

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    ' Inserta el registro limpio
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = ""
                    dr_FICHPRED("NIVEL02") = ""
                    dr_FICHPRED("NIVEL03") = ""
                    dr_FICHPRED("NIVEL04") = ""
                    dr_FICHPRED("NIVEL05") = ""
                    dr_FICHPRED("NIVEL06") = ""
                    dr_FICHPRED("NIVEL07") = ""
                    dr_FICHPRED("NIVEL08") = ""
                    dr_FICHPRED("NIVEL09") = ""
                    dr_FICHPRED("NIVEL10") = ""
                    dr_FICHPRED("NIVEL11") = ""
                    dr_FICHPRED("NIVEL12") = ""
                    dr_FICHPRED("NIVEL13") = ""
                    dr_FICHPRED("NIVEL14") = ""
                    dr_FICHPRED("NIVEL15") = ""

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    ' Inserta el registro 
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = ""
                    dr_FICHPRED("NIVEL02") = "Area_Total_Lote_M2"
                    dr_FICHPRED("NIVEL03") = "Edificio"
                    dr_FICHPRED("NIVEL04") = "Unid_Cond"
                    dr_FICHPRED("NIVEL05") = "Unid_RPH"
                    dr_FICHPRED("NIVEL06") = "Apto_Casa"
                    dr_FICHPRED("NIVEL07") = "Locales"
                    dr_FICHPRED("NIVEL08") = "Cuartos_U"
                    dr_FICHPRED("NIVEL09") = "Gara_Cubi"
                    dr_FICHPRED("NIVEL10") = "Gara_Desc"
                    dr_FICHPRED("NIVEL11") = "Pisos"
                    dr_FICHPRED("NIVEL12") = ""
                    dr_FICHPRED("NIVEL13") = ""
                    dr_FICHPRED("NIVEL14") = ""
                    dr_FICHPRED("NIVEL15") = ""

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)


                    ' Inserta el registro 
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = ""
                    dr_FICHPRED("NIVEL02") = Trim(tblFichaPredial.Rows(0).Item("FIPRATLO")) & "_"
                    dr_FICHPRED("NIVEL03") = Trim(tblFichaPredial.Rows(0).Item("FIPRTOED")) & "_"
                    dr_FICHPRED("NIVEL04") = Trim(tblFichaPredial.Rows(0).Item("FIPRUNCO")) & "_"
                    dr_FICHPRED("NIVEL05") = Trim(tblFichaPredial.Rows(0).Item("FIPRURPH")) & "_"
                    dr_FICHPRED("NIVEL06") = Trim(tblFichaPredial.Rows(0).Item("FIPRAPCA")) & "_"
                    dr_FICHPRED("NIVEL07") = Trim(tblFichaPredial.Rows(0).Item("FIPRLOCA")) & "_"
                    dr_FICHPRED("NIVEL08") = Trim(tblFichaPredial.Rows(0).Item("FIPRCUUT")) & "_"
                    dr_FICHPRED("NIVEL09") = Trim(tblFichaPredial.Rows(0).Item("FIPRGACU")) & "_"
                    dr_FICHPRED("NIVEL10") = Trim(tblFichaPredial.Rows(0).Item("FIPRGADE")) & "_"
                    dr_FICHPRED("NIVEL11") = Trim(tblFichaPredial.Rows(0).Item("FIPRPISO")) & "_"
                    dr_FICHPRED("NIVEL12") = ""
                    dr_FICHPRED("NIVEL13") = ""
                    dr_FICHPRED("NIVEL14") = ""
                    dr_FICHPRED("NIVEL15") = ""

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    ' Inserta el registro 
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = ""
                    dr_FICHPRED("NIVEL02") = "Area_Comun_Lote_M2"
                    dr_FICHPRED("NIVEL03") = ""
                    dr_FICHPRED("NIVEL04") = ""
                    dr_FICHPRED("NIVEL05") = ""
                    dr_FICHPRED("NIVEL06") = ""
                    dr_FICHPRED("NIVEL07") = ""
                    dr_FICHPRED("NIVEL08") = ""
                    dr_FICHPRED("NIVEL09") = ""
                    dr_FICHPRED("NIVEL10") = ""
                    dr_FICHPRED("NIVEL11") = ""
                    dr_FICHPRED("NIVEL12") = ""
                    dr_FICHPRED("NIVEL13") = ""
                    dr_FICHPRED("NIVEL14") = ""
                    dr_FICHPRED("NIVEL15") = ""

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    ' Inserta el registro 
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = ""
                    dr_FICHPRED("NIVEL02") = Trim(tblFichaPredial.Rows(0).Item("FIPRACLO")) & "_"
                    dr_FICHPRED("NIVEL03") = ""
                    dr_FICHPRED("NIVEL04") = ""
                    dr_FICHPRED("NIVEL05") = ""
                    dr_FICHPRED("NIVEL06") = ""
                    dr_FICHPRED("NIVEL07") = ""
                    dr_FICHPRED("NIVEL08") = ""
                    dr_FICHPRED("NIVEL09") = ""
                    dr_FICHPRED("NIVEL10") = ""
                    dr_FICHPRED("NIVEL11") = ""
                    dr_FICHPRED("NIVEL12") = ""
                    dr_FICHPRED("NIVEL13") = ""
                    dr_FICHPRED("NIVEL14") = ""
                    dr_FICHPRED("NIVEL15") = ""

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    ' Inserta el registro 
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = ""
                    dr_FICHPRED("NIVEL02") = "Area_Privada_Lote_M2"
                    dr_FICHPRED("NIVEL03") = ""
                    dr_FICHPRED("NIVEL04") = ""
                    dr_FICHPRED("NIVEL05") = ""
                    dr_FICHPRED("NIVEL06") = ""
                    dr_FICHPRED("NIVEL07") = ""
                    dr_FICHPRED("NIVEL08") = ""
                    dr_FICHPRED("NIVEL09") = ""
                    dr_FICHPRED("NIVEL10") = ""
                    dr_FICHPRED("NIVEL11") = ""
                    dr_FICHPRED("NIVEL12") = ""
                    dr_FICHPRED("NIVEL13") = ""
                    dr_FICHPRED("NIVEL14") = ""
                    dr_FICHPRED("NIVEL15") = ""

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    ' Inserta el registro 
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = ""
                    dr_FICHPRED("NIVEL02") = Trim(tblFichaPredial.Rows(0).Item("FIPRAPLO")) & "_"
                    dr_FICHPRED("NIVEL03") = ""
                    dr_FICHPRED("NIVEL04") = ""
                    dr_FICHPRED("NIVEL05") = ""
                    dr_FICHPRED("NIVEL06") = ""
                    dr_FICHPRED("NIVEL07") = ""
                    dr_FICHPRED("NIVEL08") = ""
                    dr_FICHPRED("NIVEL09") = ""
                    dr_FICHPRED("NIVEL10") = ""
                    dr_FICHPRED("NIVEL11") = ""
                    dr_FICHPRED("NIVEL12") = ""
                    dr_FICHPRED("NIVEL13") = ""
                    dr_FICHPRED("NIVEL14") = ""
                    dr_FICHPRED("NIVEL15") = ""

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    ' Inserta el registro limpio
                    dr_FICHPRED = dt_FICHPRED.NewRow()

                    dr_FICHPRED("NIVEL01") = ""
                    dr_FICHPRED("NIVEL02") = ""
                    dr_FICHPRED("NIVEL03") = ""
                    dr_FICHPRED("NIVEL04") = ""
                    dr_FICHPRED("NIVEL05") = ""
                    dr_FICHPRED("NIVEL06") = ""
                    dr_FICHPRED("NIVEL07") = ""
                    dr_FICHPRED("NIVEL08") = ""
                    dr_FICHPRED("NIVEL09") = ""
                    dr_FICHPRED("NIVEL10") = ""
                    dr_FICHPRED("NIVEL11") = ""
                    dr_FICHPRED("NIVEL12") = ""
                    dr_FICHPRED("NIVEL13") = ""
                    dr_FICHPRED("NIVEL14") = ""
                    dr_FICHPRED("NIVEL15") = ""

                    dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    '_____________________________________________________

                    ' instancia la clase 
                    Dim objConstruccion As New cla_FIPRCONS
                    Dim tblConstruccion As New DataTable

                    tblConstruccion = objConstruccion.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(inNumeroFicha)

                    ' verifica la cantidad de registros
                    If tblConstruccion.Rows.Count > 0 Then

                        ' Inserta el registro 
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = "Nro_Const"
                        dr_FICHPRED("NIVEL02") = "Identific"
                        dr_FICHPRED("NIVEL03") = "Puntos"
                        dr_FICHPRED("NIVEL04") = "Area_Cons"
                        dr_FICHPRED("NIVEL05") = "Mejora"
                        dr_FICHPRED("NIVEL06") = "Ley_56"
                        dr_FICHPRED("NIVEL07") = "Acueducto"
                        dr_FICHPRED("NIVEL08") = "Alcantari"
                        dr_FICHPRED("NIVEL09") = "Energia"
                        dr_FICHPRED("NIVEL10") = "Telefono"
                        dr_FICHPRED("NIVEL11") = "Gas"
                        dr_FICHPRED("NIVEL12") = "Tot_Piso"
                        dr_FICHPRED("NIVEL13") = "Edad"
                        dr_FICHPRED("NIVEL14") = "(%)_Cons"
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        ' declara la variable 
                        Dim f As Integer = 0

                        For f = 0 To tblConstruccion.Rows.Count - 1

                            ' Inserta el registro 
                            dr_FICHPRED = dt_FICHPRED.NewRow()

                            dr_FICHPRED("NIVEL01") = Trim(tblConstruccion.Rows(f).Item("FPCOUNID")) & "_"
                            dr_FICHPRED("NIVEL02") = Trim(tblConstruccion.Rows(f).Item("FPCOTICO")) & "_"
                            dr_FICHPRED("NIVEL03") = Trim(tblConstruccion.Rows(f).Item("FPCOPUNT")) & "_"
                            dr_FICHPRED("NIVEL04") = Trim(tblConstruccion.Rows(f).Item("FPCOARCO")) & "_"

                            If tblConstruccion.Rows(f).Item("FPCOMEJO") = True Then
                                dr_FICHPRED("NIVEL05") = "1" & "_"
                            Else
                                dr_FICHPRED("NIVEL05") = "2" & "_"
                            End If

                            If tblConstruccion.Rows(f).Item("FPCOLEY") = True Then
                                dr_FICHPRED("NIVEL06") = "1" & "_"
                            Else
                                dr_FICHPRED("NIVEL06") = "2" & "_"
                            End If

                            dr_FICHPRED("NIVEL07") = Trim(tblConstruccion.Rows(f).Item("FPCOACUE")) & "_"
                            dr_FICHPRED("NIVEL08") = Trim(tblConstruccion.Rows(f).Item("FPCOALCA")) & "_"
                            dr_FICHPRED("NIVEL09") = Trim(tblConstruccion.Rows(f).Item("FPCOENER")) & "_"
                            dr_FICHPRED("NIVEL10") = Trim(tblConstruccion.Rows(f).Item("FPCOTELE")) & "_"
                            dr_FICHPRED("NIVEL11") = Trim(tblConstruccion.Rows(f).Item("FPCOGAS")) & "_"
                            dr_FICHPRED("NIVEL12") = Trim(tblConstruccion.Rows(f).Item("FPCOPISO")) & "_"
                            dr_FICHPRED("NIVEL13") = Trim(tblConstruccion.Rows(f).Item("FPCOEDCO")) & "_"
                            dr_FICHPRED("NIVEL14") = Trim(tblConstruccion.Rows(f).Item("FPCOPOCO")) & "_"
                            dr_FICHPRED("NIVEL15") = ""

                            dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        Next

                        ' Inserta el registro limpio
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = ""
                        dr_FICHPRED("NIVEL02") = ""
                        dr_FICHPRED("NIVEL03") = ""
                        dr_FICHPRED("NIVEL04") = ""
                        dr_FICHPRED("NIVEL05") = ""
                        dr_FICHPRED("NIVEL06") = ""
                        dr_FICHPRED("NIVEL07") = ""
                        dr_FICHPRED("NIVEL08") = ""
                        dr_FICHPRED("NIVEL09") = ""
                        dr_FICHPRED("NIVEL10") = ""
                        dr_FICHPRED("NIVEL11") = ""
                        dr_FICHPRED("NIVEL12") = ""
                        dr_FICHPRED("NIVEL13") = ""
                        dr_FICHPRED("NIVEL14") = ""
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    End If

                    '_____________________________________________________

                    ' agrega la calificación
                    If boAgregarCalificacion = True Then

                        ' instancia la clase 
                        Dim objCalificacion As New cla_FIPRCACO
                        Dim tblCalificacion As New DataTable

                        tblCalificacion = objCalificacion.fun_Consultar_FIPRCACO_X_FICHA_PREDIAL_TODAS_LAS_UNIDADES(inNumeroFicha)

                        ' verifica la cantidad de registros
                        If tblCalificacion.Rows.Count > 0 Then

                            ' Inserta el registro 
                            dr_FICHPRED = dt_FICHPRED.NewRow()

                            dr_FICHPRED("NIVEL01") = "Nro_Const"
                            dr_FICHPRED("NIVEL02") = "Detalle"
                            dr_FICHPRED("NIVEL03") = "Codigo"
                            dr_FICHPRED("NIVEL04") = "Puntos"
                            dr_FICHPRED("NIVEL05") = "Tipo"
                            dr_FICHPRED("NIVEL06") = ""
                            dr_FICHPRED("NIVEL07") = ""
                            dr_FICHPRED("NIVEL08") = ""
                            dr_FICHPRED("NIVEL09") = ""
                            dr_FICHPRED("NIVEL10") = ""
                            dr_FICHPRED("NIVEL11") = ""
                            dr_FICHPRED("NIVEL12") = ""
                            dr_FICHPRED("NIVEL13") = ""
                            dr_FICHPRED("NIVEL14") = ""
                            dr_FICHPRED("NIVEL15") = ""

                            dt_FICHPRED.Rows.Add(dr_FICHPRED)

                            ' declara la variable 
                            Dim f As Integer = 0

                            For f = 0 To tblCalificacion.Rows.Count - 1

                                ' Inserta el registro 
                                dr_FICHPRED = dt_FICHPRED.NewRow()

                                dr_FICHPRED("NIVEL01") = Trim(tblCalificacion.Rows(f).Item("FPCCUNID")) & "_"
                                dr_FICHPRED("NIVEL02") = Trim(fun_Buscar_Lista_Valores_CODICALI(tblCalificacion.Rows(f).Item("FPCCCODI")))
                                dr_FICHPRED("NIVEL03") = Trim(tblCalificacion.Rows(f).Item("FPCCCODI")) & "_"
                                dr_FICHPRED("NIVEL04") = Trim(tblCalificacion.Rows(f).Item("FPCCPUNT")) & "_"
                                dr_FICHPRED("NIVEL05") = Trim(tblCalificacion.Rows(f).Item("FPCCTIPO")) & "_"
                                dr_FICHPRED("NIVEL06") = ""
                                dr_FICHPRED("NIVEL07") = ""
                                dr_FICHPRED("NIVEL08") = ""
                                dr_FICHPRED("NIVEL09") = ""
                                dr_FICHPRED("NIVEL10") = ""
                                dr_FICHPRED("NIVEL11") = ""
                                dr_FICHPRED("NIVEL12") = ""
                                dr_FICHPRED("NIVEL13") = ""
                                dr_FICHPRED("NIVEL14") = ""
                                dr_FICHPRED("NIVEL15") = ""

                                dt_FICHPRED.Rows.Add(dr_FICHPRED)

                            Next

                            ' Inserta el registro limpio
                            dr_FICHPRED = dt_FICHPRED.NewRow()

                            dr_FICHPRED("NIVEL01") = ""
                            dr_FICHPRED("NIVEL02") = ""
                            dr_FICHPRED("NIVEL03") = ""
                            dr_FICHPRED("NIVEL04") = ""
                            dr_FICHPRED("NIVEL05") = ""
                            dr_FICHPRED("NIVEL06") = ""
                            dr_FICHPRED("NIVEL07") = ""
                            dr_FICHPRED("NIVEL08") = ""
                            dr_FICHPRED("NIVEL09") = ""
                            dr_FICHPRED("NIVEL10") = ""
                            dr_FICHPRED("NIVEL11") = ""
                            dr_FICHPRED("NIVEL12") = ""
                            dr_FICHPRED("NIVEL13") = ""
                            dr_FICHPRED("NIVEL14") = ""
                            dr_FICHPRED("NIVEL15") = ""

                            dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        End If
                    End If


                    '_____________________________________________________


                    ' instancia la clase 
                    Dim objZonaFisica As New cla_FIPRZOFI
                    Dim tblZonaFisica As New DataTable

                    tblZonaFisica = objZonaFisica.fun_Consultar_FIPRZOFI_X_FICHA_PREDIAL(inNumeroFicha)

                    ' verifica la cantidad de registros
                    If tblZonaFisica.Rows.Count > 0 Then

                        ' Inserta el registro 
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = "Zona_Fisica"
                        dr_FICHPRED("NIVEL02") = "Porcentaje(%)"

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)


                        ' declara la variable 
                        Dim q As Integer = 0

                        For q = 0 To tblZonaFisica.Rows.Count - 1

                            ' Inserta el registro 
                            dr_FICHPRED = dt_FICHPRED.NewRow()

                            dr_FICHPRED("NIVEL01") = "F" & Trim(tblZonaFisica.Rows(q).Item("FPZFZOFI")) & "_"
                            dr_FICHPRED("NIVEL02") = Trim(tblZonaFisica.Rows(q).Item("FPZFPORC")) & "_"

                            dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        Next

                        ' Inserta el registro limpio
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = ""
                        dr_FICHPRED("NIVEL02") = ""
                        dr_FICHPRED("NIVEL03") = ""
                        dr_FICHPRED("NIVEL04") = ""
                        dr_FICHPRED("NIVEL05") = ""
                        dr_FICHPRED("NIVEL06") = ""
                        dr_FICHPRED("NIVEL07") = ""
                        dr_FICHPRED("NIVEL08") = ""
                        dr_FICHPRED("NIVEL09") = ""
                        dr_FICHPRED("NIVEL10") = ""
                        dr_FICHPRED("NIVEL11") = ""
                        dr_FICHPRED("NIVEL12") = ""
                        dr_FICHPRED("NIVEL13") = ""
                        dr_FICHPRED("NIVEL14") = ""
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    End If

                    '_____________________________________________________

                    ' instancia la clase 
                    Dim objZonaEconomica As New cla_FIPRZOEC
                    Dim tblZonaEconomica As New DataTable

                    tblZonaEconomica = objZonaEconomica.fun_Consultar_FIPRZOEC_X_FICHA_PREDIAL(inNumeroFicha)

                    ' verifica la cantidad de registros
                    If tblZonaEconomica.Rows.Count > 0 Then

                        ' Inserta el registro 
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = "Zona_Econo"
                        dr_FICHPRED("NIVEL02") = "Porcentaje(%)"

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)


                        ' declara la variable 
                        Dim q As Integer = 0

                        For q = 0 To tblZonaEconomica.Rows.Count - 1

                            ' Inserta el registro 
                            dr_FICHPRED = dt_FICHPRED.NewRow()

                            dr_FICHPRED("NIVEL01") = "E" & Trim(tblZonaEconomica.Rows(q).Item("FPZEZOEC")) & "_"
                            dr_FICHPRED("NIVEL02") = Trim(tblZonaEconomica.Rows(q).Item("FPZEPORC")) & "_"

                            dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        Next

                        ' Inserta el registro limpio
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = ""
                        dr_FICHPRED("NIVEL02") = ""
                        dr_FICHPRED("NIVEL03") = ""
                        dr_FICHPRED("NIVEL04") = ""
                        dr_FICHPRED("NIVEL05") = ""
                        dr_FICHPRED("NIVEL06") = ""
                        dr_FICHPRED("NIVEL07") = ""
                        dr_FICHPRED("NIVEL08") = ""
                        dr_FICHPRED("NIVEL09") = ""
                        dr_FICHPRED("NIVEL10") = ""
                        dr_FICHPRED("NIVEL11") = ""
                        dr_FICHPRED("NIVEL12") = ""
                        dr_FICHPRED("NIVEL13") = ""
                        dr_FICHPRED("NIVEL14") = ""
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    End If

                    '_____________________________________________________

                    ' instancia la clase 
                    Dim objLindero As New cla_FIPRLIND
                    Dim tblLindero As New DataTable

                    tblLindero = objLindero.fun_Consultar_FIPRLIND_X_FICHA_PREDIAL(inNumeroFicha)

                    ' verifica la cantidad de registros
                    If tblLindero.Rows.Count > 0 Then

                        ' Inserta el registro 
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = "Punto_Car"
                        dr_FICHPRED("NIVEL02") = "Lindero"
                        dr_FICHPRED("NIVEL03") = ""
                        dr_FICHPRED("NIVEL04") = ""
                        dr_FICHPRED("NIVEL05") = ""
                        dr_FICHPRED("NIVEL06") = ""
                        dr_FICHPRED("NIVEL07") = ""
                        dr_FICHPRED("NIVEL08") = ""
                        dr_FICHPRED("NIVEL09") = ""
                        dr_FICHPRED("NIVEL10") = ""
                        dr_FICHPRED("NIVEL11") = ""
                        dr_FICHPRED("NIVEL12") = ""
                        dr_FICHPRED("NIVEL13") = ""
                        dr_FICHPRED("NIVEL14") = ""
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        ' declara la variable 
                        Dim z As Integer = 0

                        For z = 0 To tblLindero.Rows.Count - 1

                            ' Inserta el registro 
                            dr_FICHPRED = dt_FICHPRED.NewRow()

                            dr_FICHPRED("NIVEL01") = Trim(tblLindero.Rows(z).Item("FPLIPUCA")) & "_"
                            dr_FICHPRED("NIVEL02") = Trim(tblLindero.Rows(z).Item("FPLICOLI")) & "_"
                            dr_FICHPRED("NIVEL03") = ""
                            dr_FICHPRED("NIVEL04") = ""
                            dr_FICHPRED("NIVEL05") = ""
                            dr_FICHPRED("NIVEL06") = ""
                            dr_FICHPRED("NIVEL07") = ""
                            dr_FICHPRED("NIVEL08") = ""
                            dr_FICHPRED("NIVEL09") = ""
                            dr_FICHPRED("NIVEL10") = ""
                            dr_FICHPRED("NIVEL11") = ""
                            dr_FICHPRED("NIVEL12") = ""
                            dr_FICHPRED("NIVEL13") = ""
                            dr_FICHPRED("NIVEL14") = ""
                            dr_FICHPRED("NIVEL15") = ""

                            dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        Next

                        ' Inserta el registro limpio
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = ""
                        dr_FICHPRED("NIVEL02") = ""
                        dr_FICHPRED("NIVEL03") = ""
                        dr_FICHPRED("NIVEL04") = ""
                        dr_FICHPRED("NIVEL05") = ""
                        dr_FICHPRED("NIVEL06") = ""
                        dr_FICHPRED("NIVEL07") = ""
                        dr_FICHPRED("NIVEL08") = ""
                        dr_FICHPRED("NIVEL09") = ""
                        dr_FICHPRED("NIVEL10") = ""
                        dr_FICHPRED("NIVEL11") = ""
                        dr_FICHPRED("NIVEL12") = ""
                        dr_FICHPRED("NIVEL13") = ""
                        dr_FICHPRED("NIVEL14") = ""
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    End If

                    '____________________________________________

                    ' instancia la clase 
                    Dim objCartografia As New cla_FIPRCART
                    Dim tblCartografia As New DataTable

                    tblCartografia = objCartografia.fun_Consultar_FIPRCART_X_FICHA_PREDIAL(inNumeroFicha)

                    ' verifica la cantidad de registros
                    If tblCartografia.Rows.Count > 0 Then

                        ' Inserta el registro 
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = "Plancha"
                        dr_FICHPRED("NIVEL02") = "Ventana"
                        dr_FICHPRED("NIVEL03") = "Escala"
                        dr_FICHPRED("NIVEL04") = "Vigencia"
                        dr_FICHPRED("NIVEL05") = "Vuelo"
                        dr_FICHPRED("NIVEL06") = "Faja"
                        dr_FICHPRED("NIVEL07") = "Foto"
                        dr_FICHPRED("NIVEL08") = "Vigencia"
                        dr_FICHPRED("NIVEL09") = "Ampliacio"
                        dr_FICHPRED("NIVEL10") = "Escala"
                        dr_FICHPRED("NIVEL11") = ""
                        dr_FICHPRED("NIVEL12") = ""
                        dr_FICHPRED("NIVEL13") = ""
                        dr_FICHPRED("NIVEL14") = ""
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        ' declara la variable 
                        Dim x As Integer = 0

                        For x = 0 To tblCartografia.Rows.Count - 1

                            ' Inserta el registro 
                            dr_FICHPRED = dt_FICHPRED.NewRow()

                            dr_FICHPRED("NIVEL01") = Trim(tblCartografia.Rows(x).Item("FPCAPLAN")) & "_"
                            dr_FICHPRED("NIVEL02") = Trim(tblCartografia.Rows(x).Item("FPCAVENT")) & "_"
                            dr_FICHPRED("NIVEL03") = Trim(tblCartografia.Rows(x).Item("FPCAESGR")) & "_"
                            dr_FICHPRED("NIVEL04") = Trim(tblCartografia.Rows(x).Item("FPCAVIGR")) & "_"
                            dr_FICHPRED("NIVEL05") = Trim(tblCartografia.Rows(x).Item("FPCAVUEL")) & "_"
                            dr_FICHPRED("NIVEL06") = Trim(tblCartografia.Rows(x).Item("FPCAFAJA")) & "_"
                            dr_FICHPRED("NIVEL07") = Trim(tblCartografia.Rows(x).Item("FPCAFOTO")) & "_"
                            dr_FICHPRED("NIVEL08") = Trim(tblCartografia.Rows(x).Item("FPCAVIAE")) & "_"
                            dr_FICHPRED("NIVEL09") = Trim(tblCartografia.Rows(x).Item("FPCAAMPL")) & "_"
                            dr_FICHPRED("NIVEL10") = Trim(tblCartografia.Rows(x).Item("FPCAESAE")) & "_"
                            dr_FICHPRED("NIVEL11") = ""
                            dr_FICHPRED("NIVEL12") = ""
                            dr_FICHPRED("NIVEL13") = ""
                            dr_FICHPRED("NIVEL14") = ""
                            dr_FICHPRED("NIVEL15") = ""

                            dt_FICHPRED.Rows.Add(dr_FICHPRED)

                        Next

                        ' Inserta el registro limpio
                        dr_FICHPRED = dt_FICHPRED.NewRow()

                        dr_FICHPRED("NIVEL01") = ""
                        dr_FICHPRED("NIVEL02") = ""
                        dr_FICHPRED("NIVEL03") = ""
                        dr_FICHPRED("NIVEL04") = ""
                        dr_FICHPRED("NIVEL05") = ""
                        dr_FICHPRED("NIVEL06") = ""
                        dr_FICHPRED("NIVEL07") = ""
                        dr_FICHPRED("NIVEL08") = ""
                        dr_FICHPRED("NIVEL09") = ""
                        dr_FICHPRED("NIVEL10") = ""
                        dr_FICHPRED("NIVEL11") = ""
                        dr_FICHPRED("NIVEL12") = ""
                        dr_FICHPRED("NIVEL13") = ""
                        dr_FICHPRED("NIVEL14") = ""
                        dr_FICHPRED("NIVEL15") = ""

                        dt_FICHPRED.Rows.Add(dr_FICHPRED)

                    End If


                Next


                '___________________________________________________

                ' crea la tabla maestra
                dt_FICHPRED_TOTAL = New DataTable

                ' llena la tabla
                dt_FICHPRED_TOTAL = dt_FICHPRED
                'dt_FICHPRED_TOTAL = dt_FIPRDEEC

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt_FICHPRED_TOTAL

                ' llena los totales
                Me.lblTotalPorcentaje.Text = ""
                Me.lblTotalRegistros.Text = dt_FICHPRED_TOTAL.Rows.Count

            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Me.dgvFIPRESTA.DataSource = New DataTable

                Me.txtFIPRESTADISTICO.Text = ""
                Me.lblTotalPorcentaje.Text = ""
                Me.lblTotalRegistros.Text = ""

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()


        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_ReporteCantidadDePrediosPorBarrio()

        Try
            Me.txtFIPRESTADISTICO.Text = ""
            Me.cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprMuni AS Municipio, "
            ParametrosConsulta += "FiprClse AS Sector, "
            ParametrosConsulta += "FiprCorr AS Corregimiento, "
            ParametrosConsulta += "FiprBarr AS Barrio, "
            ParametrosConsulta += "Count(1) AS Cantidad "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' "
            ParametrosConsulta += "Group by FiprMuni, FiprClse, FiprCorr, FiprBarr "
            ParametrosConsulta += "Order by FiprMuni, FiprClse, FiprCorr, FiprBarr "

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

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt

                Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count
            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Me.dgvFIPRESTA.DataSource = New DataTable

                Me.txtFIPRESTADISTICO.Text = ""

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_ReporteCantidadDePrediosPorBarrioSegunUsuario()

        Try
            Me.txtFIPRESTADISTICO.Text = ""
            Me.cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "Fiprusin AS Usuario, "
            ParametrosConsulta += "FiprMuni AS Municipio, "
            ParametrosConsulta += "FiprClse AS Sector, "
            ParametrosConsulta += "FiprCorr AS Corregimiento, "
            ParametrosConsulta += "FiprBarr AS Barrio, "
            ParametrosConsulta += "Count(1) AS Cantidad "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' "
            ParametrosConsulta += "Group by Fiprusin, FiprMuni, FiprClse, FiprCorr, FiprBarr "
            ParametrosConsulta += "Order by Fiprusin, FiprMuni, FiprClse, FiprCorr, FiprBarr "

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

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt

                Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count
            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Me.dgvFIPRESTA.DataSource = New DataTable

                Me.txtFIPRESTADISTICO.Text = ""

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_ReporteCantidadDePrediosPorBarrioManzana()

        Try
            Me.txtFIPRESTADISTICO.Text = ""
            Me.cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprMuni AS Municipio, "
            ParametrosConsulta += "FiprClse AS Sector, "
            ParametrosConsulta += "FiprCorr AS Corregimiento, "
            ParametrosConsulta += "FiprBarr AS Barrio, "
            ParametrosConsulta += "FiprManz AS Manzana, "
            ParametrosConsulta += "Count(1) AS Cantidad "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' "
            ParametrosConsulta += "Group by FiprMuni, FiprClse, FiprCorr, FiprBarr, FiprManz "
            ParametrosConsulta += "Order by FiprMuni, FiprClse, FiprCorr, FiprBarr, FiprManz "

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

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt

                Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count
            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Me.dgvFIPRESTA.DataSource = New DataTable

                Me.txtFIPRESTADISTICO.Text = ""

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_ReporteCantidadDePrediosPorBarrioManzanaSegunUsuario()

        Try
            Me.txtFIPRESTADISTICO.Text = ""
            Me.cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "Fiprusin AS Usuario, "
            ParametrosConsulta += "FiprMuni AS Municipio, "
            ParametrosConsulta += "FiprClse AS Sector, "
            ParametrosConsulta += "FiprCorr AS Corregimiento, "
            ParametrosConsulta += "FiprBarr AS Barrio, "
            ParametrosConsulta += "FiprManz AS Manzana, "
            ParametrosConsulta += "Count(1) AS Cantidad "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' "
            ParametrosConsulta += "Group by Fiprusin, FiprMuni, FiprClse, FiprCorr, FiprBarr, FiprManz "
            ParametrosConsulta += "Order by Fiprusin, FiprMuni, FiprClse, FiprCorr, FiprBarr, FiprManz "

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

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt

                Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count
            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Me.dgvFIPRESTA.DataSource = New DataTable

                Me.txtFIPRESTADISTICO.Text = ""

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_ReporteCantidadDeViviendasPorBarrio()

        Try
            Me.txtFIPRESTADISTICO.Text = ""
            Me.cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprMuni AS Municipio, "
            ParametrosConsulta += "FiprClse AS Sector, "
            ParametrosConsulta += "FiprCorr AS Corregimiento, "
            ParametrosConsulta += "FiprBarr AS Barrio, "
            ParametrosConsulta += "Count(1) AS Cantidad "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "Exists(Select 1 from fiprcons where fiprnufi = fpconufi and fpcotico in ('001','002','003','039','036','043','045','047') and fpcoesta = 'ac') and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' "
            ParametrosConsulta += "Group by FiprMuni, FiprClse, FiprCorr, FiprBarr "
            ParametrosConsulta += "Order by FiprMuni, FiprClse, FiprCorr, FiprBarr "

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

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt

                Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count
            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Me.dgvFIPRESTA.DataSource = New DataTable

                Me.txtFIPRESTADISTICO.Text = ""

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_ReporteCantidadDeViviendasPorBarrioManzana()

        Try
            Me.txtFIPRESTADISTICO.Text = ""
            Me.cmdGENERAR.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprMuni AS Municipio, "
            ParametrosConsulta += "FiprClse AS Sector, "
            ParametrosConsulta += "FiprCorr AS Corregimiento, "
            ParametrosConsulta += "FiprBarr AS Barrio, "
            ParametrosConsulta += "FiprManz AS Manzana, "
            ParametrosConsulta += "Count(1) AS Cantidad "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "Exists(Select 1 from fiprcons where fiprnufi = fpconufi and fpcotico in ('001','002','003','039','036','043','045','047') and fpcoesta = 'ac') and "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(stFIPREDIF) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(stFIPRUNPR) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' "
            ParametrosConsulta += "Group by FiprMuni, FiprClse, FiprCorr, FiprBarr, FiprManz "
            ParametrosConsulta += "Order by FiprMuni, FiprClse, FiprCorr, FiprBarr, FiprManz "

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

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt

                Me.strBARRESTA.Items(2).Text = "Registros : " & dt.Rows.Count
            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Me.dgvFIPRESTA.DataSource = New DataTable

                Me.txtFIPRESTADISTICO.Text = ""

            End If

            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub
    Private Sub pro_ReporteCantidadDePrediosMejorasRPHPorBarrioManzana()

        Try
            ' opera el comando
            Me.cmdGENERAR.Enabled = False

            ' declara la tabla
            Dim dtAgrupacionPorManzana As New DataTable

            ' almacena la tabla
            dtAgrupacionPorManzana = fun_AgrupacionPorManzana()

            ' realiza la insercion mediante la consulta
            If dtAgrupacionPorManzana.Rows.Count > 0 Then

                ' Crea objeto de columnas y registros
                Dim dt1 As New DataTable
                Dim dr1 As DataRow

                ' Crea las columnas
                dt1.Columns.Add(New DataColumn("Municipio", GetType(String)))
                dt1.Columns.Add(New DataColumn("Sector", GetType(String)))
                dt1.Columns.Add(New DataColumn("Corregimiento", GetType(String)))
                dt1.Columns.Add(New DataColumn("Barrio", GetType(String)))
                dt1.Columns.Add(New DataColumn("Manzana", GetType(String)))
                dt1.Columns.Add(New DataColumn("Nro_Predios", GetType(String)))
                dt1.Columns.Add(New DataColumn("Nro_Mejoras", GetType(String)))
                dt1.Columns.Add(New DataColumn("Nro_Lotes", GetType(String)))
                dt1.Columns.Add(New DataColumn("Nro_RPH", GetType(String)))
                dt1.Columns.Add(New DataColumn("Nro_Unidades_RPH", GetType(String)))

                ' declara la variable
                Dim i As Integer = 0

                ' recorre la tabla
                For i = 0 To dtAgrupacionPorManzana.Rows.Count - 1

                    dr1 = dt1.NewRow()

                    dr1("Municipio") = Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprMuni").ToString)
                    dr1("Sector") = Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprClse").ToString)
                    dr1("Corregimiento") = Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprCorr").ToString)
                    dr1("Barrio") = Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprBarr").ToString)
                    dr1("Manzana") = Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprManz").ToString)
                    dr1("Nro_Predios") = fun_CantidadDePrediosPorManzana(Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprMuni").ToString), Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprClse").ToString), Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprCorr").ToString), Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprBarr").ToString), Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprManz").ToString))
                    dr1("Nro_Mejoras") = fun_CantidadDeMejorasPorManzana(Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprMuni").ToString), Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprClse").ToString), Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprCorr").ToString), Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprBarr").ToString), Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprManz").ToString))
                    dr1("Nro_Lotes") = fun_CantidadDeLotesPorManzana(Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprMuni").ToString), Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprClse").ToString), Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprCorr").ToString), Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprBarr").ToString), Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprManz").ToString))
                    dr1("Nro_RPH") = fun_CantidadDeRPHPorManzana(Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprMuni").ToString), Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprClse").ToString), Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprCorr").ToString), Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprBarr").ToString), Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprManz").ToString))
                    dr1("Nro_Unidades_RPH") = fun_CantidadDeUnidadesRPHPorManzana(Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprMuni").ToString), Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprClse").ToString), Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprCorr").ToString), Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprBarr").ToString), Trim(dtAgrupacionPorManzana.Rows(i).Item("FiprManz").ToString))

                    dt1.Rows.Add(dr1)

                Next

                ' llena el el datagridview
                Me.dgvFIPRESTA.DataSource = dt1

                Me.strBARRESTA.Items(2).Text = "Registros : " & dt1.Rows.Count
            Else

                mod_MENSAJE.Consulta_No_Encontro_Registros()
                strBARRESTA.Items(2).Text = "Registros : 0"

                ' limpia el reporte
                Me.dgvFIPRESTA.DataSource = New DataTable

            End If

            ' opera el comando
            Me.cmdGENERAR.Enabled = True
            Me.cmdGENERAR.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            cmdGENERAR.Enabled = True
        End Try

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_AgrupacionPorManzana() As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprMuni, "
            ParametrosConsulta += "FiprClse, "
            ParametrosConsulta += "FiprCorr, "
            ParametrosConsulta += "FiprBarr, "
            ParametrosConsulta += "FiprManz "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' "
            ParametrosConsulta += "Group by FiprMuni, FiprClse, FiprCorr, FiprBarr, FiprManz "
            ParametrosConsulta += "Order by FiprMuni, FiprClse, FiprCorr, FiprBarr, FiprManz "

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

            Return dt

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_AgrupacionPorPredio() As DataTable

        Try
            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' verifica los datos
            pro_VerificarDatos()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprMuni, "
            ParametrosConsulta += "FiprClse, "
            ParametrosConsulta += "FiprCorr, "
            ParametrosConsulta += "FiprBarr, "
            ParametrosConsulta += "FiprManz, "
            ParametrosConsulta += "FiprPred "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(stFIPRMUNI) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(stFIPRCORR) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(stFIPRBARR) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(stFIPRMANZ) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(stFIPRPRED) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(stFIPRCLSE) & "' and "
            ParametrosConsulta += "FiprTifi like '" & Trim(stFIPRTIFI) & "' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(stFIPRFIIN) & "' and '" & Trim(stFIPRFIFI) & "' and "
            ParametrosConsulta += "FiprEsta like '" & Trim(stFIPRESTA) & "' "
            ParametrosConsulta += "Group by FiprMuni, FiprClse, FiprCorr, FiprBarr, FiprManz, FiprPred "
            ParametrosConsulta += "Order by FiprMuni, FiprClse, FiprCorr, FiprBarr, FiprManz, FiprPred "

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

            Return dt

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

    Private Function fun_CantidadDePrediosPorManzana(ByVal stFIPRMUNI_1 As String, ByVal stFIPRCLSE_1 As String, ByVal stFIPRCORR_1 As String, ByVal stFIPRBARR_1 As String, ByVal stFIPRMANZ_1 As String) As Integer

        Try
            Dim inCantidad As Integer = 0

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
            ParametrosConsulta += "Select FiprMuni, FiprCorr, FiprBarr, FiprManz, FiprPred, FiprClse "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni = '" & Trim(stFIPRMUNI_1) & "' and "
            ParametrosConsulta += "FiprCorr = '" & Trim(stFIPRCORR_1) & "' and "
            ParametrosConsulta += "FiprBarr = '" & Trim(stFIPRBARR_1) & "' and "
            ParametrosConsulta += "FiprManz = '" & Trim(stFIPRMANZ_1) & "' and "
            ParametrosConsulta += "FiprClse = '" & Trim(stFIPRCLSE_1) & "' and "
            ParametrosConsulta += "FiprTifi = '0' and "
            ParametrosConsulta += "(exists(select 1 from fiprcons where fiprnufi = fpconufi and fpcomejo = 0 ) or (not exists(select 1 from fiprcons where fiprnufi = fpconufi ))) and "
            ParametrosConsulta += "FiprEsta = 'ac' "
            ParametrosConsulta += "Group by FiprMuni, FiprCorr, FiprBarr, FiprManz, FiprPred, FiprClse "

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

            ' verifica la existencia de registros
            If dt.Rows.Count > 0 Then

                ' declara la variable
                Dim i As Integer = 0

                ' recorre la tabla
                For i = 0 To dt.Rows.Count - 1

                    ' almacena la cantidad
                    inCantidad += 1

                Next

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_CantidadDeMejorasPorManzana(ByVal stFIPRMUNI_1 As String, ByVal stFIPRCLSE_1 As String, ByVal stFIPRCORR_1 As String, ByVal stFIPRBARR_1 As String, ByVal stFIPRMANZ_1 As String) As Integer

        Try
            Dim inCantidad As Integer = 0

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
            ParametrosConsulta += "Select FiprNufi, FiprMuni, FiprCorr, FiprBarr, FiprManz, FiprPred, FiprClse "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni = '" & Trim(stFIPRMUNI_1) & "' and "
            ParametrosConsulta += "FiprCorr = '" & Trim(stFIPRCORR_1) & "' and "
            ParametrosConsulta += "FiprBarr = '" & Trim(stFIPRBARR_1) & "' and "
            ParametrosConsulta += "FiprManz = '" & Trim(stFIPRMANZ_1) & "' and "
            ParametrosConsulta += "FiprClse = '" & Trim(stFIPRCLSE_1) & "' and "
            ParametrosConsulta += "FiprTifi = '0' and "
            ParametrosConsulta += "exists(select 1 from fiprcons where fiprnufi = fpconufi and fpcomejo = 1 ) and "
            ParametrosConsulta += "FiprEsta = 'ac' "
            ParametrosConsulta += "Group by FiprNufi, FiprMuni, FiprCorr, FiprBarr, FiprManz, FiprPred, FiprClse "

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

            ' verifica la existencia de registros
            If dt.Rows.Count > 0 Then

                ' declara la variable
                Dim i As Integer = 0

                ' recorre la tabla
                For i = 0 To dt.Rows.Count - 1

                    ' almacena la cantidad
                    inCantidad += 1

                Next

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_CantidadDeLotesPorManzana(ByVal stFIPRMUNI_1 As String, ByVal stFIPRCLSE_1 As String, ByVal stFIPRCORR_1 As String, ByVal stFIPRBARR_1 As String, ByVal stFIPRMANZ_1 As String) As Integer

        Try
            Dim inCantidad As Integer = 0

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
             ParametrosConsulta += "Select FiprNufi, FiprMuni, FiprCorr, FiprBarr, FiprManz, FiprPred, FiprClse "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni = '" & Trim(stFIPRMUNI_1) & "' and "
            ParametrosConsulta += "FiprCorr = '" & Trim(stFIPRCORR_1) & "' and "
            ParametrosConsulta += "FiprBarr = '" & Trim(stFIPRBARR_1) & "' and "
            ParametrosConsulta += "FiprManz = '" & Trim(stFIPRMANZ_1) & "' and "
            ParametrosConsulta += "FiprClse = '" & Trim(stFIPRCLSE_1) & "' and "
            ParametrosConsulta += "FiprTifi = '0' and "
            ParametrosConsulta += "not exists(select 1 from fiprcons where fiprnufi = fpconufi and fpcoesta = 'ac') and "
            ParametrosConsulta += "FiprEsta = 'ac' "
            ParametrosConsulta += "Group by FiprNufi, FiprMuni, FiprCorr, FiprBarr, FiprManz, FiprPred, FiprClse "

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

            ' verifica la existencia de registros
            If dt.Rows.Count > 0 Then

                ' declara la variable
                Dim i As Integer = 0

                ' recorre la tabla
                For i = 0 To dt.Rows.Count - 1

                    ' almacena la cantidad
                    inCantidad += 1

                Next

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_CantidadDeRPHPorManzana(ByVal stFIPRMUNI_1 As String, ByVal stFIPRCLSE_1 As String, ByVal stFIPRCORR_1 As String, ByVal stFIPRBARR_1 As String, ByVal stFIPRMANZ_1 As String) As Integer

        Try
            Dim inCantidad As Integer = 0

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
            ParametrosConsulta += "count(1) as Cantidad "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni = '" & Trim(stFIPRMUNI_1) & "' and "
            ParametrosConsulta += "FiprCorr = '" & Trim(stFIPRCORR_1) & "' and "
            ParametrosConsulta += "FiprBarr = '" & Trim(stFIPRBARR_1) & "' and "
            ParametrosConsulta += "FiprManz = '" & Trim(stFIPRMANZ_1) & "' and "
            ParametrosConsulta += "FiprClse = '" & Trim(stFIPRCLSE_1) & "' and "
            ParametrosConsulta += "FiprTifi = '2' and "
            ParametrosConsulta += "FiprCapr in ('2','3') and "
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

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' almacena la cantidad
                inCantidad = CType(dt.Rows(0).Item("Cantidad"), Integer)

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_CantidadDeUnidadesRPHPorManzana(ByVal stFIPRMUNI_1 As String, ByVal stFIPRCLSE_1 As String, ByVal stFIPRCORR_1 As String, ByVal stFIPRBARR_1 As String, ByVal stFIPRMANZ_1 As String) As Integer

        Try
            Dim inCantidad As Integer = 0

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
            ParametrosConsulta += "count(1) as Cantidad "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni = '" & Trim(stFIPRMUNI_1) & "' and "
            ParametrosConsulta += "FiprCorr = '" & Trim(stFIPRCORR_1) & "' and "
            ParametrosConsulta += "FiprBarr = '" & Trim(stFIPRBARR_1) & "' and "
            ParametrosConsulta += "FiprManz = '" & Trim(stFIPRMANZ_1) & "' and "
            ParametrosConsulta += "FiprClse = '" & Trim(stFIPRCLSE_1) & "' and "
            ParametrosConsulta += "FiprTifi = '0' and "
            ParametrosConsulta += "FiprCapr in ('2','3') and "
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

            ' realiza la insercion mediante la consulta
            If dt.Rows.Count > 0 Then

                ' almacena la cantidad
                inCantidad = CType(dt.Rows(0).Item("Cantidad"), Integer)

            End If

            Return inCantidad

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "MENU"

    Private Sub cmdGENERAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGENERAR.Click

        Try

            If cboTIPOREPO.SelectedIndex = 0 Then
                pro_GenerarDestinacionEconomica()
            End If
            If cboTIPOREPO.SelectedIndex = 1 Then
                pro_GenerarTipoDeDocumento()
            End If
            If cboTIPOREPO.SelectedIndex = 2 Then
                pro_GenerarTipoDeConstruccion()
            End If
            If cboTIPOREPO.SelectedIndex = 3 Then
                pro_GenerarZonaEconomica()
            End If
            If cboTIPOREPO.SelectedIndex = 4 Then
                pro_GenerarZonaFisica()
            End If
            If cboTIPOREPO.SelectedIndex = 5 Then
                pro_GenerarModoDeAdquisicion()
            End If
            If cboTIPOREPO.SelectedIndex = 6 Then
                pro_GenerarCaracteristicaDePredio()
            End If
            If cboTIPOREPO.SelectedIndex = 7 Then
                pro_GenerarClaseoSector()
            End If
            If cboTIPOREPO.SelectedIndex = 8 Then
                pro_GenerarAreaDeTerreno()
            End If
            If cboTIPOREPO.SelectedIndex = 9 Then
                pro_GenerarAreaDeConstruccion()
            End If
            If cboTIPOREPO.SelectedIndex = 10 Then
                pro_GenerarPuntosDeCalificacion()
            End If
            If cboTIPOREPO.SelectedIndex = 11 Then
                pro_GenerarPrediosConDestinoPorcentajeMaximo()
            End If
            If cboTIPOREPO.SelectedIndex = 12 Then
                pro_GenerarPredioConAreaConstruidaMaxima()
            End If
            If cboTIPOREPO.SelectedIndex = 13 Then
                pro_GenerarCalidadDePropietario()
            End If
            If cboTIPOREPO.SelectedIndex = 14 Then
                pro_GenerarAvaluosPorTipoDeConstruccion()
            End If
            If cboTIPOREPO.SelectedIndex = 15 Then
                pro_GenerarAvaluosPorZonaEconomica()
            End If
            If cboTIPOREPO.SelectedIndex = 16 Then
                pro_GenerarAvaluosPorDestinacionEconomica()
            End If
            If cboTIPOREPO.SelectedIndex = 17 Then
                pro_GenerarAvaluosPorCalidadDePropietario()
            End If
            If cboTIPOREPO.SelectedIndex = 18 Then
                pro_GenerarAvaluosTotales()
            End If
            If cboTIPOREPO.SelectedIndex = 19 Then
                pro_ReporteFichaPredial()
            End If
            If cboTIPOREPO.SelectedIndex = 20 Then
                pro_ReporteCantidadDePrediosConTomoDiferenteDeCero()
            End If
            If cboTIPOREPO.SelectedIndex = 21 Then
                pro_GenerarCantidadDePrediosQueFaltanPorLevantarEnTrabajoDeCampo()
            End If
            If cboTIPOREPO.SelectedIndex = 22 Then
                pro_GenerarCantidadPrediosQueNoSonMejoras()
            End If
            If cboTIPOREPO.SelectedIndex = 23 Then
                pro_GenerarCantidadPrediosQueSonMejoras()
            End If
            If cboTIPOREPO.SelectedIndex = 24 Then
                pro_GenerarEstractificacion()
            End If
            If cboTIPOREPO.SelectedIndex = 25 Then
                pro_GenerarRegistroControl()
            End If
            If cboTIPOREPO.SelectedIndex = 26 Then
                pro_ReporteCantidadDePrediosPorBarrio()
            End If
            If cboTIPOREPO.SelectedIndex = 27 Then
                pro_ReporteCantidadDePrediosPorBarrioSegunUsuario()
            End If
            If cboTIPOREPO.SelectedIndex = 28 Then
                pro_ReporteCantidadDePrediosPorBarrioManzana()
            End If
            If cboTIPOREPO.SelectedIndex = 29 Then
                pro_ReporteCantidadDePrediosPorBarrioManzanaSegunUsuario()
            End If
            If cboTIPOREPO.SelectedIndex = 30 Then
                pro_ReporteCantidadDeViviendasPorBarrio()
            End If
            If cboTIPOREPO.SelectedIndex = 31 Then
                pro_ReporteCantidadDeViviendasPorBarrioManzana()
            End If
            If cboTIPOREPO.SelectedIndex = 32 Then
                pro_ReporteFichaResumen()
            End If
            If cboTIPOREPO.SelectedIndex = 33 Then
                pro_ReporteCantidadDePrediosMejorasRPHPorBarrioManzana()
            End If


            If Me.dgvFIPRESTA.RowCount > 0 Then
                Me.cmdGrafico.Enabled = True
            Else
                Me.cmdGrafico.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdGrafico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrafico.Click

        Dim frm_Grafica As New frm_grafica_Estadistica_Ficha_Predial(CType(Me.dgvFIPRESTA.DataSource, DataTable), Trim(Me.cboTIPOREPO.Text))
        frm_Grafica.ShowDialog()

    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
        txtFIPRFIIN.Focus()

    End Sub
    Private Sub cmdIMPRIMIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIMPRIMIR.Click
        ' PrintDialog permite al usuario seleccionar la impresora en la que desea imprimir, 
        ' además de otras opciones de impresión.

        PrintDialog1.Document = PrintDocument1
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.Print()
        End If

    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        pro_LimpiarCampos()
        txtFIPRFIIN.Focus()
        Me.Close()
    End Sub
    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        ' PrintPreviewDialog está asociado a PrintDocument; cuando se procesa la 
        ' vista previa, se desencadena el evento PrintPage. A este evento se pasa un contexto 
        ' gráfico en el que se "dibuja" la página.

        Try
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.ShowDialog()
        Catch exp As Exception
            MsgBox("An error occurred while trying to load the " & _
                "document for Print Preview. Make sure you currently have " & _
                "access to a printer. A printer must be connected and " & _
                "accessible for Print Preview to work.", MsgBoxStyle.OkOnly, _
                 Me.Text)
        End Try

    End Sub
    Private Sub btnPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPageSetup.Click
        ' La configuración de página permite especificar aspectos tales como el tamaño del papel, la orientación vertical, 
        ' horizontal, etc.

        With PageSetupDialog1
            .Document = PrintDocument1
            .PageSettings = PrintDocument1.DefaultPageSettings
        End With

        If PageSetupDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.DefaultPageSettings = PageSetupDialog1.PageSettings
        End If

    End Sub
    Private Sub pdoc_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        '-------------------------------------------------------------------------------------------------------
        '*** ESTE SUB PROGRAMA DEBE COPIAR EN EL FORMULARIO QUE SE INSTALE LOS BOTONES PARA IMPRIMIR ***
        '-----------------------------------------------------------------------------------------------

        'TamanoFuente = "10" 'nudTAMANO.Value 'determina el tamaño de la letra de impresión

        ' Declare una variable que contenga la posición del último carácter impreso. Declárela
        ' como estática para que los siguiente eventos PrintPage puedan hacer referencia a ella.
        Static intCurrentChar As Int32
        ' Inicialice la fuente que se va a utilizar en la impresión.
        Dim font As New Font("Arial", 10)

        Dim intPrintAreaHeight, intPrintAreaWidth, marginLeft, marginTop As Int32
        With PrintDocument1.DefaultPageSettings
            ' Inicialice variables locales que contengan los límites del rectángulo del 
            ' área de impresión.
            intPrintAreaHeight = .PaperSize.Height - .Margins.Top - .Margins.Bottom
            intPrintAreaWidth = .PaperSize.Width - .Margins.Left - .Margins.Right

            ' Inicialice variables locales que contengan los valores de margen que servirán
            ' de coordenadas X e Y para la esquina superior izquierda del rectángulo 
            ' del área de impresión.
            marginLeft = .Margins.Left ' Coordenada X
            marginTop = .Margins.Top ' Coordenada Y
        End With

        ' Si el usuario ha seleccionado el modo Horizontal, cambie el alto y el ancho 
        ' del área de impresión.
        If PrintDocument1.DefaultPageSettings.Landscape Then
            Dim intTemp As Int32
            intTemp = intPrintAreaHeight
            intPrintAreaHeight = intPrintAreaWidth
            intPrintAreaWidth = intTemp
        End If

        ' Calcule el número total de líneas en el documento a partir del alto del
        ' área de impresión y del alto de la fuente.
        Dim intLineCount As Int32 = CInt(intPrintAreaHeight / font.Height)
        ' Inicialice la estructura del rectángulo que define el área de impresión.
        Dim rectPrintingArea As New RectangleF(marginLeft, marginTop, intPrintAreaWidth, intPrintAreaHeight)

        ' Cree una instancia de la clase StringFormat, que encapsula la información de diseño 
        ' del texto (como la alineación y el espaciado de las líneas ), muestra las manipulaciones 
        ' (como la inserción de puntos suspensivos y la sustitución de dígitos nacionales) y las características de 
        ' OpenType. El uso de StringFormat permite que MeasureString y DrawString utilicen
        ' sólo un número entero de líneas al imprimir cada página, omitiendo las líneas
        ' parciales que probablemente se imprimirían si el número de líneas por 
        ' página no se dividiera exactamente para cada página (lo que ocurre habitualmente).
        ' Consulte la documentación del SDK sobre StringFormatFlags para obtener más información.
        Dim fmt As New StringFormat(StringFormatFlags.LineLimit)
        ' Llame a MeasureString para determinar el número de caracteres que caben en
        ' el rectángulo del área de impresión. A CharFitted Int32 se pasa ByRef y se utiliza
        ' más adelante cuando se calcula intCurrentChar y, por tanto, HasMorePages. LinesFilled 
        ' no es necesario para este ejemplo, pero debe pasarse cuando se pasa CharsFitted.
        ' Mid se utiliza para pasar el segmento de texto restante que queda de la 
        ' página anterior impresa (recuerde que intCurrentChar se declaró como 
        ' estática).
        Dim intLinesFilled, intCharsFitted As Int32
        e.Graphics.MeasureString(Mid(txtFIPRESTADISTICO.Text, intCurrentChar + 1), font, _
                    New SizeF(intPrintAreaWidth, intPrintAreaHeight), fmt, _
                    intCharsFitted, intLinesFilled)

        ' Imprima el texto en la página.
        e.Graphics.DrawString(Mid(txtFIPRESTADISTICO.Text, intCurrentChar + 1), font, _
            Brushes.Black, rectPrintingArea, fmt)

        ' Haga avanzar el carácter actual hasta el último carácter impreso de esta página. Como 
        ' intCurrentChar es una variable estática, su valor se puede utilizar para la página
        ' siguiente que se va a imprimir. Aumenta en 1 y se pasa a Mid() para imprimir la
        ' página siguiente (vea MeasureString() más arriba).
        intCurrentChar += intCharsFitted

        ' HasMorePages indica al módulo de impresión si debe desencadenarse otro
        ' evento PrintPage.
        If intCurrentChar < txtFIPRESTADISTICO.Text.Length Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
            ' Debe restablecer explícitamente intCurrentChar ya que es estática.
            intCurrentChar = 0
        End If
    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        Try
            If Me.dgvFIPRESTA.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvFIPRESTA.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarPlano_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.Click
        Try

            If dgvFIPRESTA.RowCount > 0 Then

                ' crea la instancia para crear y salvar
                Dim oCrear As New SaveFileDialog

                oCrear.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                oCrear.Filter = "Archivo de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*" 'Colocar varias extensiones
                oCrear.FilterIndex = 1 'coloca por defecto el *.txt
                oCrear.ShowDialog() 'abre la caja de dialogo para guardar


                ' si existe una ruta seleccionada
                If Trim(oCrear.FileName) <> "" Then

                    ' lleba la ruta al label
                    'txtRUTA.Text = oCrear.FileName

                    ' se carga el stSeparador
                    stSeparador = Trim(txtSEPARADOR.Text)

                    'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas
                    Using archivo As StreamWriter = New StreamWriter(oCrear.FileName)

                        ' variable para almacenar la línea actual del dataview
                        Dim linea As String = String.Empty

                        With dgvFIPRESTA
                            ' Recorrer las filas del dataGridView
                            For fila As Integer = 0 To .RowCount - 1
                                ' vaciar la línea
                                linea = String.Empty

                                ' Recorrer la cantidad de columnas que contiene el dataGridView
                                For col As Integer = 0 To .Columns.Count - 1
                                    ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
                                    linea = linea & Trim(.Item(col, fila).Value.ToString) & stSeparador
                                Next

                                ' Escribir una línea con el método WriteLine
                                With archivo
                                    ' eliminar el último caracter ";" de la cadena
                                    linea = linea.Remove(linea.Length - 1).ToString
                                    ' escribir la fila
                                    .WriteLine(linea.ToString)
                                End With
                            Next
                        End With
                    End Using

                    MessageBox.Show("Plano generado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    If MessageBox.Show("¿ Desea abrir el archivo plano ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        ' Abrir con Process.Start el archivo de texto
                        Process.Start(oCrear.FileName)
                    End If

                Else
                    txtFIPRFIIN.Focus()
                End If
            Else
                MessageBox.Show("Ejecute la consulta antes de exportar el plano", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_REPO_FIPRESTA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboTIPOREPO.SelectedIndex = 0
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtFIPRFIIN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRFIIN.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub
    Private Sub txtFIPRFIFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRFIFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub
    Private Sub txtFIPRTIFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRTIFI.KeyPress
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
                        txtFIPRCLSE.Focus()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtFIPRCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCLSE.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then
            If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                If e.KeyChar <> Convert.ToChar(37) Then
                    If e.KeyChar <> Convert.ToChar(Keys.Enter) Then
                        e.Handled = True
                        strBARRESTA.Items(1).Text = IncoValoNume
                        mod_MENSAJE.Inco_Valo_Nume()
                    Else
                        strBARRESTA.Items(1).Text = ""
                        cmdGENERAR.Focus()
                    End If
                End If
            End If
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
    Private Sub txtFIPRTIFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRTIFI.GotFocus
        txtFIPRTIFI.SelectionStart = 0
        txtFIPRTIFI.SelectionLength = Len(txtFIPRTIFI.Text)
        strBARRESTA.Items(0).Text = txtFIPRTIFI.AccessibleDescription
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
    Private Sub txtFIPRCLSE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCLSE.GotFocus
        txtFIPRCLSE.SelectionStart = 0
        txtFIPRCLSE.SelectionLength = Len(txtFIPRCLSE.Text)
        strBARRESTA.Items(0).Text = txtFIPRCLSE.AccessibleDescription
    End Sub
    Private Sub txtFIPRREPO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRESTADISTICO.GotFocus
        strBARRESTA.Items(0).Text = txtFIPRESTADISTICO.AccessibleDescription
    End Sub
    Private Sub cmdGENERAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGENERAR.GotFocus
        strBARRESTA.Items(0).Text = cmdGENERAR.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub
    Private Sub cmdIMPRIMIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdIMPRIMIR.GotFocus
        strBARRESTA.Items(0).Text = cmdIMPRIMIR.AccessibleDescription
    End Sub
    Private Sub btnPrintPreview_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintPreview.GotFocus
        strBARRESTA.Items(0).Text = btnPrintPreview.AccessibleDescription
    End Sub
    Private Sub btnPageSetup_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPageSetup.GotFocus
        strBARRESTA.Items(0).Text = btnPageSetup.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub cmdExportarExcel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.GotFocus
        strBARRESTA.Items(0).Text = cmdExportarExcel.AccessibleDescription
    End Sub
    Private Sub cmdExportarPlano_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.GotFocus
        strBARRESTA.Items(0).Text = cmdExportarPlano.AccessibleDescription
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFIPRTIFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRTIFI.Validated
        Me.strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.Validated
        If Me.txtFIPRMUNI.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRMUNI.Text) = True Then
            Me.txtFIPRMUNI.Text = fun_Formato_Mascara_3_String(Me.txtFIPRMUNI.Text)
        End If
    End Sub
    Private Sub txtFIPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.Validated
        If Me.txtFIPRCORR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRCORR.Text) = True Then
            Me.txtFIPRCORR.Text = fun_Formato_Mascara_2_String(Me.txtFIPRCORR.Text)
        End If
    End Sub
    Private Sub txtFIPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.Validated
        If Me.txtFIPRBARR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRBARR.Text) = True Then
            Me.txtFIPRBARR.Text = fun_Formato_Mascara_3_String(Me.txtFIPRBARR.Text)
        End If
    End Sub
    Private Sub txtFIPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.Validated
        If Me.txtFIPRMANZ.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRMANZ.Text) = True Then
            Me.txtFIPRMANZ.Text = fun_Formato_Mascara_3_String(Me.txtFIPRMANZ.Text)
        End If
    End Sub
    Private Sub txtFIPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.Validated
        If Me.txtFIPRPRED.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRPRED.Text) = True Then
            Me.txtFIPRPRED.Text = fun_Formato_Mascara_5_String(Me.txtFIPRPRED.Text)
        End If
    End Sub
    Private Sub txtFIPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.Validated
        If Me.txtFIPREDIF.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPREDIF.Text) = True Then
            Me.txtFIPREDIF.Text = fun_Formato_Mascara_3_String(Me.txtFIPREDIF.Text)
        End If
    End Sub
    Private Sub txtFIPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.Validated
        If Me.txtFIPRUNPR.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRUNPR.Text) = True Then
            Me.txtFIPRUNPR.Text = fun_Formato_Mascara_5_String(Me.txtFIPRUNPR.Text)
        End If
    End Sub

#End Region

#End Region

End Class