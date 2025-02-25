Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_Cruce_Areas_Terreno_DB_vs_Cartografia

    '===============================================
    '*** CRUCE DE AREAS DE TERRENO BD VS GEODATA ***
    '===============================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Cruce_Areas_Terreno_DB_vs_Cartografia
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Cruce_Areas_Terreno_DB_vs_Cartografia
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

#Region "VARIABLES"

    ' crea las variables de conexion
    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private ds As New DataSet
    Private dt As New DataTable

    ' crea el objeto para abrir el archivo
    Dim oLeer As New OpenFileDialog

    ' crea los objetos datatable
    Dim dt_CargaFichaPredial As New DataTable
    Dim dt_CargaCartografia As New DataTable
    Dim dt_CargaCruceAreaDeTerreno As New DataTable

    Dim dt_1 As New DataTable
    Dim dt_2 As New DataTable
    Dim dt_3 As New DataTable
    Dim dt_4 As New DataTable
    Dim dt_5 As New DataTable

    ' otros procesos
    Dim stRutaArchivoCartografia As String
    Dim inProceso As Integer = 0

    Dim inTotalRegistrosCartografia As Integer = 0
    Dim inTotalRegistrosFichaPredial As Integer = 0

    ' variables ficha predial
    Dim vl_stFIPRNUFI As String = ""
    Dim vl_stFIPRTIFI As String = ""
    Dim vl_stFIPRDIRE As String = ""
    Dim vl_stFIPRMUNI As String = ""
    Dim vl_stFIPRCORR As String = ""
    Dim vl_stFIPRBARR As String = ""
    Dim vl_stFIPRMANZ As String = ""
    Dim vl_stFIPRPRED As String = ""
    Dim vl_stFIPREDIF As String = ""
    Dim vl_stFIPRUNPR As String = ""
    Dim vl_stFIPRCLSE As String = ""

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_CargaConsultaFichaPredial()

        Try
            ' limpia las tablas
            Me.dgvListadoFichaPredial.DataSource = New DataTable
            Me.dgvCruceAreaDeTerreno.DataSource = New DataTable

            Me.cmdCruceAreasDeTerrenoBDvsCart.Enabled = False
            Me.cmdCruceAreasDeTerrenoCartvsBD.Enabled = False


            ' apaga el boton
            Me.cmdConsultarFichaPredial.Enabled = False

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dt_1 = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' verifica los datos de los campos
            pro_VerificarCampos()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprMuni, "
            ParametrosConsulta += "FiprCorr, "
            ParametrosConsulta += "FiprBarr, "
            ParametrosConsulta += "FiprManz, "
            ParametrosConsulta += "FiprPred, "
            ParametrosConsulta += "FiprClse  "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprNufi like '" & vl_stFIPRNUFI & "' and "
            ParametrosConsulta += "FiprTifi like '" & vl_stFIPRTIFI & "' and "
            ParametrosConsulta += "FiprDire like '" & vl_stFIPRDIRE & "' and "
            ParametrosConsulta += "FiprMuni like '" & vl_stFIPRMUNI & "' and "
            ParametrosConsulta += "FiprCorr like '" & vl_stFIPRCORR & "' and "
            ParametrosConsulta += "FiprBarr like '" & vl_stFIPRBARR & "' and "
            ParametrosConsulta += "FiprManz like '" & vl_stFIPRMANZ & "' and "
            ParametrosConsulta += "FiprPred like '" & vl_stFIPRPRED & "' and "
            ParametrosConsulta += "FiprClse like '" & vl_stFIPRCLSE & "' and "
            ParametrosConsulta += "FiprEsta like '" & "ac" & "' "
            ParametrosConsulta += "group by FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprClse "
            ParametrosConsulta += "order by FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprClse "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dt_1)

            ' cierra la conexion
            oConexion.Close()

            ' carga el datagrid de la ficha predial
            If dt_1.Rows.Count > 0 Then

                ' Valores predeterminados ProgressBar
                inProceso = 0
                pbPROCESO.Value = 0
                pbPROCESO.Maximum = dt_1.Rows.Count + 1
                Timer1.Enabled = True

                ' Crea objeto registros
                Dim dr1 As DataRow

                ' crea la tabla
                dt_CargaFichaPredial = New DataTable

                ' Crea las columnas
                dt_CargaFichaPredial.Columns.Add(New DataColumn("Municipio", GetType(String)))
                dt_CargaFichaPredial.Columns.Add(New DataColumn("Correg", GetType(String)))
                dt_CargaFichaPredial.Columns.Add(New DataColumn("Barrio", GetType(String)))
                dt_CargaFichaPredial.Columns.Add(New DataColumn("Manzana", GetType(String)))
                dt_CargaFichaPredial.Columns.Add(New DataColumn("Predio", GetType(String)))
                dt_CargaFichaPredial.Columns.Add(New DataColumn("Sector", GetType(String)))
                dt_CargaFichaPredial.Columns.Add(New DataColumn("Area", GetType(String)))

                ' declara las variables
                Dim stFIPRMUNI As String = ""
                Dim stFIPRCORR As String = ""
                Dim stFIPRBARR As String = ""
                Dim stFIPRMANZ As String = ""
                Dim stFIPRPRED As String = ""
                Dim stFIPRCLSE As String = ""
                Dim stFIPRCAPR As String = ""
                Dim stFIPRARTE As String = ""

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dt_1.Rows.Count - 1

                    stFIPRMUNI = CType(fun_Formato_Mascara_3_Reales(Trim(dt_1.Rows(i).Item(0).ToString)), String)
                    stFIPRCORR = CType(fun_Formato_Mascara_2_Reales(Trim(dt_1.Rows(i).Item(1).ToString)), String)
                    stFIPRBARR = CType(fun_Formato_Mascara_3_Reales(Trim(dt_1.Rows(i).Item(2).ToString)), String)
                    stFIPRMANZ = CType(fun_Formato_Mascara_3_Reales(Trim(dt_1.Rows(i).Item(3).ToString)), String)
                    stFIPRPRED = CType(fun_Formato_Mascara_5_Reales(Trim(dt_1.Rows(i).Item(4).ToString)), String)
                    stFIPRCLSE = CType(Trim(dt_1.Rows(i).Item(5).ToString), String)

                    ' buscar cadena de conexion
                    Dim oCadenaConexion2 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                    Dim stCadenaConexion2 As String = oCadenaConexion2.fun_ConnectionString

                    ' crea el datatable
                    dt_2 = New DataTable

                    ' crear conexión
                    oAdapter = New SqlDataAdapter
                    oConexion = New SqlConnection(stCadenaConexion2)

                    ' abre la conexion
                    oConexion.Open()

                    ' parametros de la consulta
                    Dim ParametrosConsulta2 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta2 += "Select "
                    ParametrosConsulta2 += "FiprNufi, FiprCapr "
                    ParametrosConsulta2 += "From FichPred where "
                    ParametrosConsulta2 += "(exists(select 1 from fiprcons where fiprnufi = fpconufi and fpcomejo = 0 and fpcoesta = 'ac') or not exists(select 1 from fiprcons where fiprnufi = fpconufi)) and "
                    ParametrosConsulta2 += "FiprMuni = '" & stFIPRMUNI & "' and "
                    ParametrosConsulta2 += "FiprCorr = '" & stFIPRCORR & "' and "
                    ParametrosConsulta2 += "FiprBarr = '" & stFIPRBARR & "' and "
                    ParametrosConsulta2 += "FiprManz = '" & stFIPRMANZ & "' and "
                    ParametrosConsulta2 += "FiprPred = '" & stFIPRPRED & "' and "
                    ParametrosConsulta2 += "FiprClse = '" & stFIPRCLSE & "' and "
                    ParametrosConsulta2 += "FiprTifi = '" & "0" & "' and "
                    ParametrosConsulta2 += "FiprEsta = '" & "ac" & "' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 0
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_2)

                    ' cierra la conexion
                    oConexion.Close()

                    ' verifica que exista al registro
                    If dt_2.Rows.Count > 0 Then

                        ' verifica que no sea predio en reglamento
                        If CInt(dt_2.Rows(0).Item("FiprCapr")) = 1 Or CInt(dt_2.Rows(0).Item("FiprCapr")) = 6 Or CInt(dt_2.Rows(0).Item("FiprCapr")) = 7 Then

                            ' buscar cadena de conexion
                            Dim oCadenaConexion3 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                            Dim stCadenaConexion3 As String = oCadenaConexion3.fun_ConnectionString

                            ' crea el datatable
                            dt_3 = New DataTable

                            ' crear conexión
                            oAdapter = New SqlDataAdapter
                            oConexion = New SqlConnection(stCadenaConexion3)

                            ' abre la conexion
                            oConexion.Open()

                            ' parametros de la consulta
                            Dim ParametrosConsulta3 As String = ""

                            ' Concatena la condicion de la consulta
                            ParametrosConsulta3 += "Select "
                            ParametrosConsulta3 += "FiprNufi "
                            ParametrosConsulta3 += "From FichPred where "
                            ParametrosConsulta3 += "(exists(select 1 from fiprcons where fiprnufi = fpconufi and fpcomejo = 0 and fpcoesta = 'ac') or not exists(select 1 from fiprcons where fiprnufi = fpconufi)) and "
                            ParametrosConsulta3 += "FiprMuni = '" & stFIPRMUNI & "' and "
                            ParametrosConsulta3 += "FiprCorr = '" & stFIPRCORR & "' and "
                            ParametrosConsulta3 += "FiprBarr = '" & stFIPRBARR & "' and "
                            ParametrosConsulta3 += "FiprManz = '" & stFIPRMANZ & "' and "
                            ParametrosConsulta3 += "FiprPred = '" & stFIPRPRED & "' and "
                            ParametrosConsulta3 += "FiprClse = '" & stFIPRCLSE & "' and "
                            ParametrosConsulta3 += "FiprCapr = '" & CInt(dt_2.Rows(0).Item("FiprCapr")) & "' and "
                            ParametrosConsulta3 += "FiprTifi = '" & "0" & "' and "
                            ParametrosConsulta3 += "FiprEsta = '" & "ac" & "' "

                            ' ejecuta la consulta
                            oEjecutar = New SqlCommand(ParametrosConsulta3, oConexion)

                            ' procesa la consulta 
                            oEjecutar.CommandTimeout = 0
                            oEjecutar.CommandType = CommandType.Text
                            oAdapter.SelectCommand = oEjecutar

                            ' llena el datatable 
                            oAdapter.Fill(dt_3)

                            ' cierra la conexion
                            oConexion.Close()

                            'instancia la clase
                            Dim objdatos3 As New cla_FICHPRED
                            Dim tbl3 As New DataTable

                            tbl3 = objdatos3.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dt_3.Rows(0).Item("FiprNufi"))

                            If tbl3.Rows.Count > 0 Then

                                dr1 = dt_CargaFichaPredial.NewRow()

                                dr1("Municipio") = CStr(stFIPRMUNI)
                                dr1("Correg") = CStr(stFIPRCORR)
                                dr1("Barrio") = CStr(stFIPRBARR)
                                dr1("Manzana") = CStr(stFIPRMANZ)
                                dr1("Predio") = CStr(stFIPRPRED)
                                dr1("Sector") = CStr(stFIPRCLSE)
                                dr1("Area") = CStr(tbl3.Rows(0).Item("FIPRARTE"))

                                dt_CargaFichaPredial.Rows.Add(dr1)

                            End If

                            ' predio en reglamento
                        ElseIf CInt(dt_2.Rows(0).Item("FiprCapr")) = 2 Or CInt(dt_2.Rows(0).Item("FiprCapr")) = 3 Then

                            ' buscar cadena de conexion
                            Dim oCadenaConexion4 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                            Dim stCadenaConexion4 As String = oCadenaConexion4.fun_ConnectionString

                            ' crea el datatable
                            dt_4 = New DataTable

                            ' crear conexión
                            oAdapter = New SqlDataAdapter
                            oConexion = New SqlConnection(stCadenaConexion4)

                            ' abre la conexion
                            oConexion.Open()

                            ' parametros de la consulta
                            Dim ParametrosConsulta4 As String = ""

                            ' Concatena la condicion de la consulta
                            ParametrosConsulta4 += "Select "
                            ParametrosConsulta4 += "FiprNufi "
                            ParametrosConsulta4 += "From FichPred where "
                            ParametrosConsulta4 += "(exists(select 1 from fiprcons where fiprnufi = fpconufi and fpcomejo = 0 and fpcoesta = 'ac') or not exists(select 1 from fiprcons where fiprnufi = fpconufi)) and "
                            ParametrosConsulta4 += "FiprMuni = '" & stFIPRMUNI & "' and "
                            ParametrosConsulta4 += "FiprCorr = '" & stFIPRCORR & "' and "
                            ParametrosConsulta4 += "FiprBarr = '" & stFIPRBARR & "' and "
                            ParametrosConsulta4 += "FiprManz = '" & stFIPRMANZ & "' and "
                            ParametrosConsulta4 += "FiprPred = '" & stFIPRPRED & "' and "
                            ParametrosConsulta4 += "FiprClse = '" & stFIPRCLSE & "' and "
                            ParametrosConsulta4 += "FiprCapr = '" & CInt(dt_2.Rows(0).Item("FiprCapr")) & "' and "
                            ParametrosConsulta4 += "FiprTifi = '" & "2" & "' and "
                            ParametrosConsulta4 += "FiprEsta = '" & "ac" & "' "

                            ' ejecuta la consulta
                            oEjecutar = New SqlCommand(ParametrosConsulta4, oConexion)

                            ' procesa la consulta 
                            oEjecutar.CommandTimeout = 0
                            oEjecutar.CommandType = CommandType.Text
                            oAdapter.SelectCommand = oEjecutar

                            ' llena el datatable 
                            oAdapter.Fill(dt_4)

                            ' cierra la conexion
                            oConexion.Close()

                            If dt_4.Rows.Count > 0 Then

                                'instancia la clase
                                Dim objdatos4 As New cla_FICHPRED
                                Dim tbl4 As New DataTable

                                tbl4 = objdatos4.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dt_4.Rows(0).Item("FiprNufi"))

                                If tbl4.Rows.Count > 0 Then

                                    dr1 = dt_CargaFichaPredial.NewRow()

                                    dr1("Municipio") = CStr(stFIPRMUNI)
                                    dr1("Correg") = CStr(stFIPRCORR)
                                    dr1("Barrio") = CStr(stFIPRBARR)
                                    dr1("Manzana") = CStr(stFIPRMANZ)
                                    dr1("Predio") = CStr(stFIPRPRED)
                                    dr1("Sector") = CStr(stFIPRCLSE)
                                    dr1("Area") = CStr(tbl4.Rows(0).Item("FIPRATLO"))

                                    dt_CargaFichaPredial.Rows.Add(dr1)

                                End If

                            Else

                                dr1 = dt_CargaFichaPredial.NewRow()

                                dr1("Municipio") = CStr(stFIPRMUNI)
                                dr1("Correg") = CStr(stFIPRCORR)
                                dr1("Barrio") = CStr(stFIPRBARR)
                                dr1("Manzana") = CStr(stFIPRMANZ)
                                dr1("Predio") = CStr(stFIPRPRED)
                                dr1("Sector") = CStr(stFIPRCLSE)
                                dr1("Area") = "0"

                                dt_CargaFichaPredial.Rows.Add(dr1)

                            End If


                            ' verifica el predio en condominio
                        ElseIf CInt(dt_2.Rows(0).Item("FiprCapr")) = 4 Then

                            ' buscar cadena de conexion
                            Dim oCadenaConexion5 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                            Dim stCadenaConexion5 As String = oCadenaConexion5.fun_ConnectionString

                            ' crea el datatable
                            dt_5 = New DataTable

                            ' crear conexión
                            oAdapter = New SqlDataAdapter
                            oConexion = New SqlConnection(stCadenaConexion5)

                            ' abre la conexion
                            oConexion.Open()

                            ' parametros de la consulta
                            Dim ParametrosConsulta5 As String = ""

                            ' Concatena la condicion de la consulta
                            ParametrosConsulta5 += "Select "
                            ParametrosConsulta5 += "FiprNufi "
                            ParametrosConsulta5 += "From FichPred where "
                            ParametrosConsulta5 += "(exists(select 1 from fiprcons where fiprnufi = fpconufi and fpcomejo = 0 and fpcoesta = 'ac') or not exists(select 1 from fiprcons where fiprnufi = fpconufi)) and "
                            ParametrosConsulta5 += "FiprMuni = '" & stFIPRMUNI & "' and "
                            ParametrosConsulta5 += "FiprCorr = '" & stFIPRCORR & "' and "
                            ParametrosConsulta5 += "FiprBarr = '" & stFIPRBARR & "' and "
                            ParametrosConsulta5 += "FiprManz = '" & stFIPRMANZ & "' and "
                            ParametrosConsulta5 += "FiprPred = '" & stFIPRPRED & "' and "
                            ParametrosConsulta5 += "FiprClse = '" & stFIPRCLSE & "' and "
                            ParametrosConsulta5 += "FiprCapr = '" & CInt(dt_2.Rows(0).Item("FiprCapr")) & "' and "
                            ParametrosConsulta5 += "FiprTifi = '" & "1" & "' and "
                            ParametrosConsulta5 += "FiprEsta = '" & "ac" & "' "

                            ' ejecuta la consulta
                            oEjecutar = New SqlCommand(ParametrosConsulta5, oConexion)

                            ' procesa la consulta 
                            oEjecutar.CommandTimeout = 0
                            oEjecutar.CommandType = CommandType.Text
                            oAdapter.SelectCommand = oEjecutar

                            ' llena el datatable 
                            oAdapter.Fill(dt_5)

                            ' cierra la conexion
                            oConexion.Close()

                            If dt_5.Rows.Count > 0 Then

                                'instancia la clase
                                Dim objdatos5 As New cla_FICHPRED
                                Dim tbl5 As New DataTable

                                tbl5 = objdatos5.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dt_5.Rows(0).Item("FiprNufi"))

                                If tbl5.Rows.Count > 0 Then

                                    dr1 = dt_CargaFichaPredial.NewRow()

                                    dr1("Municipio") = CStr(stFIPRMUNI)
                                    dr1("Correg") = CStr(stFIPRCORR)
                                    dr1("Barrio") = CStr(stFIPRBARR)
                                    dr1("Manzana") = CStr(stFIPRMANZ)
                                    dr1("Predio") = CStr(stFIPRPRED)
                                    dr1("Sector") = CStr(stFIPRCLSE)
                                    dr1("Area") = CStr(tbl5.Rows(0).Item("FIPRATLO"))

                                    dt_CargaFichaPredial.Rows.Add(dr1)

                                End If

                            Else

                                dr1 = dt_CargaFichaPredial.NewRow()

                                dr1("Municipio") = CStr(stFIPRMUNI)
                                dr1("Correg") = CStr(stFIPRCORR)
                                dr1("Barrio") = CStr(stFIPRBARR)
                                dr1("Manzana") = CStr(stFIPRMANZ)
                                dr1("Predio") = CStr(stFIPRPRED)
                                dr1("Sector") = CStr(stFIPRCLSE)
                                dr1("Area") = "0"

                                dt_CargaFichaPredial.Rows.Add(dr1)

                            End If

                        End If

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbPROCESO.Value = inProceso

                Next

                pbPROCESO.Value = 0

                Me.dgvListadoFichaPredial.DataSource = dt_CargaFichaPredial
                Me.lblCantidadPrediosFichaPredial.Text = dt_CargaFichaPredial.Rows.Count
                Me.TabControl1.SelectTab(TabPage1)

                MessageBox.Show("Consulta encontro registros", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                Me.dgvListadoFichaPredial.DataSource = New DataTable
                Me.lblCantidadPrediosFichaPredial.Text = "0"

                MessageBox.Show("Consulta no encontro registros", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            End If

            ' prende el boton
            Me.cmdConsultarFichaPredial.Enabled = True

            pro_ControlDeBotones()

            Me.strBARRESTA.Items(2).Text = "Registro : " & dt_CargaFichaPredial.Rows.Count

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & vl_stFIPRNUFI)
        End Try

    End Sub
    Private Sub pro_VerificarCampos()

        If Trim(Me.txtFIPRNUFI.Text) = "" Then
            vl_stFIPRNUFI = "%"
        Else
            vl_stFIPRNUFI = Trim(Me.txtFIPRNUFI.Text)
        End If

        If Trim(Me.txtFIPRTIFI.Text) = "" Then
            vl_stFIPRTIFI = "%"
        Else
            vl_stFIPRTIFI = Trim(Me.txtFIPRTIFI.Text)
        End If

        If Trim(Me.txtFIPRDIRE.Text) = "" Then
            vl_stFIPRDIRE = "%"
        Else
            vl_stFIPRDIRE = Trim(Me.txtFIPRDIRE.Text)
        End If

        If Trim(Me.txtFIPRMUNI.Text) = "" Then
            vl_stFIPRMUNI = "%"
        Else
            vl_stFIPRMUNI = Trim(Me.txtFIPRMUNI.Text)
        End If

        If Trim(Me.txtFIPRCORR.Text) = "" Then
            vl_stFIPRCORR = "%"
        Else
            vl_stFIPRCORR = Trim(Me.txtFIPRCORR.Text)
        End If

        If Trim(Me.txtFIPRBARR.Text) = "" Then
            vl_stFIPRBARR = "%"
        Else
            vl_stFIPRBARR = Trim(Me.txtFIPRBARR.Text)
        End If

        If Trim(Me.txtFIPRMANZ.Text) = "" Then
            vl_stFIPRMANZ = "%"
        Else
            vl_stFIPRMANZ = Trim(Me.txtFIPRMANZ.Text)
        End If

        If Trim(Me.txtFIPRPRED.Text) = "" Then
            vl_stFIPRPRED = "%"
        Else
            vl_stFIPRPRED = Trim(Me.txtFIPRPRED.Text)
        End If

        If Trim(Me.txtFIPREDIF.Text) = "" Then
            vl_stFIPREDIF = "%"
        Else
            vl_stFIPREDIF = Trim(Me.txtFIPREDIF.Text)
        End If

        If Trim(Me.txtFIPRUNPR.Text) = "" Then
            vl_stFIPRUNPR = "%"
        Else
            vl_stFIPRUNPR = Trim(Me.txtFIPRUNPR.Text)
        End If

        If Trim(Me.txtFIPRCLSE.Text) = "" Then
            vl_stFIPRCLSE = "%"
        Else
            vl_stFIPRCLSE = Trim(Me.txtFIPRCLSE.Text)
        End If

    End Sub
    Private Sub pro_LimpiarCampos()

        Me.lblRutaArchivo.Text = ""

        Me.txtFIPRNUFI.Text = ""
        Me.txtFIPRTIFI.Text = ""
        Me.txtFIPRDIRE.Text = ""
        Me.txtFIPRMUNI.Text = ""
        Me.txtFIPRCORR.Text = ""
        Me.txtFIPRBARR.Text = ""
        Me.txtFIPRMANZ.Text = ""
        Me.txtFIPRPRED.Text = ""
        Me.txtFIPREDIF.Text = ""
        Me.txtFIPRUNPR.Text = ""
        Me.txtFIPRCLSE.Text = ""

        Me.dgvListadoFichaPredial.DataSource = New DataTable
        Me.dgvListadoCartografia.DataSource = New DataTable
        Me.dgvCruceAreaDeTerreno.DataSource = New DataTable

        Me.strBARRESTA.Items(2).Text = "Registro : 0"

        Me.cmdCruceAreasDeTerrenoBDvsCart.Enabled = False
        Me.cmdCruceAreasDeTerrenoCartvsBD.Enabled = False

        Me.cmdValidaDatos.Enabled = False

    End Sub
    Private Sub pro_ControlDeBotones()

        If Me.dgvListadoCartografia.RowCount > 0 And Me.dgvListadoFichaPredial.RowCount > 0 Then
            Me.cmdValidaDatos.Enabled = True

            Me.cmdCruceAreasDeTerrenoBDvsCart.Enabled = False
            Me.cmdCruceAreasDeTerrenoCartvsBD.Enabled = False
        Else
            Me.cmdValidaDatos.Enabled = False
        End If

    End Sub
    Private Sub pro_ValidarAreaTerrenoFichaPredial()

        ' limpia los datagrigview
        Me.dgvCruceAreaDeTerreno.DataSource = New DataTable

        ' Valores predeterminados ProgressBar
        inProceso = 0
        pbPROCESO.Value = 0
        pbPROCESO.Maximum = Me.dgvListadoCartografia.RowCount + 1
        Timer1.Enabled = True

        ' Crea objeto de columnas y registros
        Dim dt1 As New DataTable
        Dim dr1 As DataRow

        ' Crea las columnas
        dt1.Columns.Add(New DataColumn("Municipio", GetType(String)))
        dt1.Columns.Add(New DataColumn("Corregi", GetType(String)))
        dt1.Columns.Add(New DataColumn("Barrio", GetType(String)))
        dt1.Columns.Add(New DataColumn("Manzana", GetType(String)))
        dt1.Columns.Add(New DataColumn("Predio", GetType(String)))
        dt1.Columns.Add(New DataColumn("Sector", GetType(String)))
        dt1.Columns.Add(New DataColumn("Area", GetType(String)))

        ' crea la variable
        Dim i As Integer = 0

        ' crea la tabla
        dt_CargaCartografia = New DataTable

        ' carga la tabla
        dt_CargaCartografia = Me.dgvListadoCartografia.DataSource

        For i = 0 To dt_CargaCartografia.Rows.Count - 1

            ' verifica que el campo Municipio
            If Trim(dt_CargaCartografia.Rows(i).Item(0).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Municipio") = "El campo Municipio esta vacio"
                dr1("Corregi") = Trim(dt_CargaCartografia.Rows(i).Item(1).ToString)
                dr1("Barrio") = Trim(dt_CargaCartografia.Rows(i).Item(2).ToString)
                dr1("Manzana") = Trim(dt_CargaCartografia.Rows(i).Item(3).ToString)
                dr1("Predio") = Trim(dt_CargaCartografia.Rows(i).Item(4).ToString)
                dr1("Sector") = Trim(dt_CargaCartografia.Rows(i).Item(5).ToString)
                dr1("Area") = Trim(dt_CargaCartografia.Rows(i).Item(6).ToString)

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo Corregimiento
            If Trim(dt_CargaCartografia.Rows(i).Item(1).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Municipio") = Trim(dt_CargaCartografia.Rows(i).Item(0).ToString)
                dr1("Corregi") = "El campo Corregimiento esta vacio"
                dr1("Barrio") = Trim(dt_CargaCartografia.Rows(i).Item(2).ToString)
                dr1("Manzana") = Trim(dt_CargaCartografia.Rows(i).Item(3).ToString)
                dr1("Predio") = Trim(dt_CargaCartografia.Rows(i).Item(4).ToString)
                dr1("Sector") = Trim(dt_CargaCartografia.Rows(i).Item(5).ToString)
                dr1("Area") = Trim(dt_CargaCartografia.Rows(i).Item(6).ToString)

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo Barrio
            If Trim(dt_CargaCartografia.Rows(i).Item(2).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Municipio") = Trim(dt_CargaCartografia.Rows(i).Item(0).ToString)
                dr1("Corregi") = Trim(dt_CargaCartografia.Rows(i).Item(1).ToString)
                dr1("Barrio") = "El campo Barrio esta vacio"
                dr1("Manzana") = Trim(dt_CargaCartografia.Rows(i).Item(3).ToString)
                dr1("Predio") = Trim(dt_CargaCartografia.Rows(i).Item(4).ToString)
                dr1("Sector") = Trim(dt_CargaCartografia.Rows(i).Item(5).ToString)
                dr1("Area") = Trim(dt_CargaCartografia.Rows(i).Item(6).ToString)

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo Manzana
            If Trim(dt_CargaCartografia.Rows(i).Item(3).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Municipio") = Trim(dt_CargaCartografia.Rows(i).Item(0).ToString)
                dr1("Corregi") = Trim(dt_CargaCartografia.Rows(i).Item(1).ToString)
                dr1("Barrio") = Trim(dt_CargaCartografia.Rows(i).Item(2).ToString)
                dr1("Manzana") = "El campo Manzana esta vacio"
                dr1("Predio") = Trim(dt_CargaCartografia.Rows(i).Item(4).ToString)
                dr1("Sector") = Trim(dt_CargaCartografia.Rows(i).Item(5).ToString)
                dr1("Area") = Trim(dt_CargaCartografia.Rows(i).Item(6).ToString)

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo Predio
            If Trim(dt_CargaCartografia.Rows(i).Item(4).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Municipio") = Trim(dt_CargaCartografia.Rows(i).Item(0).ToString)
                dr1("Corregi") = Trim(dt_CargaCartografia.Rows(i).Item(1).ToString)
                dr1("Barrio") = Trim(dt_CargaCartografia.Rows(i).Item(2).ToString)
                dr1("Manzana") = Trim(dt_CargaCartografia.Rows(i).Item(3).ToString)
                dr1("Predio") = "El campo Predio esta vacio"
                dr1("Sector") = Trim(dt_CargaCartografia.Rows(i).Item(5).ToString)
                dr1("Area") = Trim(dt_CargaCartografia.Rows(i).Item(6).ToString)

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo Sector
            If Trim(dt_CargaCartografia.Rows(i).Item(5).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Municipio") = Trim(dt_CargaCartografia.Rows(i).Item(0).ToString)
                dr1("Corregi") = Trim(dt_CargaCartografia.Rows(i).Item(1).ToString)
                dr1("Barrio") = Trim(dt_CargaCartografia.Rows(i).Item(2).ToString)
                dr1("Manzana") = Trim(dt_CargaCartografia.Rows(i).Item(3).ToString)
                dr1("Predio") = Trim(dt_CargaCartografia.Rows(i).Item(4).ToString)
                dr1("Sector") = "El campo Sector esta vacio"
                dr1("Area") = Trim(dt_CargaCartografia.Rows(i).Item(6).ToString)

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_CargaCartografia.Rows(i).Item(5).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Municipio") = Trim(dt_CargaCartografia.Rows(i).Item(0).ToString)
                    dr1("Corregi") = Trim(dt_CargaCartografia.Rows(i).Item(1).ToString)
                    dr1("Barrio") = Trim(dt_CargaCartografia.Rows(i).Item(2).ToString)
                    dr1("Manzana") = Trim(dt_CargaCartografia.Rows(i).Item(3).ToString)
                    dr1("Predio") = Trim(dt_CargaCartografia.Rows(i).Item(4).ToString)
                    dr1("Sector") = "El campo Sector no es numerico"
                    dr1("Area") = Trim(dt_CargaCartografia.Rows(i).Item(6).ToString)

                    dt1.Rows.Add(dr1)

                Else

                    Dim objdatos22 As New cla_CLASSECT
                    Dim tbl22 As New DataTable

                    tbl22 = objdatos22.fun_Buscar_CODIGO_MANT_CLASSECT(Trim(dt_CargaCartografia.Rows(i).Item(5).ToString))

                    If tbl22.Rows.Count = 0 Then

                        dr1 = dt1.NewRow()

                        dr1("Municipio") = Trim(dt_CargaCartografia.Rows(i).Item(0).ToString)
                        dr1("Corregi") = Trim(dt_CargaCartografia.Rows(i).Item(1).ToString)
                        dr1("Barrio") = Trim(dt_CargaCartografia.Rows(i).Item(2).ToString)
                        dr1("Manzana") = Trim(dt_CargaCartografia.Rows(i).Item(3).ToString)
                        dr1("Predio") = Trim(dt_CargaCartografia.Rows(i).Item(4).ToString)
                        dr1("Sector") = "El campo Sector no existe"
                        dr1("Area") = Trim(dt_CargaCartografia.Rows(i).Item(6).ToString)

                        dt1.Rows.Add(dr1)

                    End If

                End If

            End If

            ' verifica que el campo area de terreno
            If Trim(dt_CargaCartografia.Rows(i).Item(6).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Municipio") = Trim(dt_CargaCartografia.Rows(i).Item(0).ToString)
                dr1("Corregi") = Trim(dt_CargaCartografia.Rows(i).Item(1).ToString)
                dr1("Barrio") = Trim(dt_CargaCartografia.Rows(i).Item(2).ToString)
                dr1("Manzana") = Trim(dt_CargaCartografia.Rows(i).Item(3).ToString)
                dr1("Predio") = Trim(dt_CargaCartografia.Rows(i).Item(4).ToString)
                dr1("Sector") = Trim(dt_CargaCartografia.Rows(i).Item(5).ToString)
                dr1("Area") = "El campo Area de Terreno esta vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_CargaCartografia.Rows(i).Item(6).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Municipio") = Trim(dt_CargaCartografia.Rows(i).Item(0).ToString)
                    dr1("Corregi") = Trim(dt_CargaCartografia.Rows(i).Item(1).ToString)
                    dr1("Barrio") = Trim(dt_CargaCartografia.Rows(i).Item(2).ToString)
                    dr1("Manzana") = Trim(dt_CargaCartografia.Rows(i).Item(3).ToString)
                    dr1("Predio") = Trim(dt_CargaCartografia.Rows(i).Item(4).ToString)
                    dr1("Sector") = Trim(dt_CargaCartografia.Rows(i).Item(5).ToString)
                    dr1("Area") = "El campo Area de Terreno no es numerico"

                    dt1.Rows.Add(dr1)

                End If

            End If


            ' Incrementa la barra
            inProceso = inProceso + 1
            pbPROCESO.Value = inProceso

        Next

        ' Llena el datagrigview
        TabControl1.SelectTab(TabPage3)
        Me.dgvCruceAreaDeTerreno.DataSource = dt1
        pbPROCESO.Value = 0

        ' comando grabar datos
        If dt1.Rows.Count = 0 Then
            Me.cmdCruceAreasDeTerrenoBDvsCart.Enabled = True
            Me.cmdCruceAreasDeTerrenoCartvsBD.Enabled = True
            Me.cmdValidaDatos.Enabled = False
            Me.cmdCruceAreasDeTerrenoBDvsCart.Focus()
            MessageBox.Show("Proceso de validación terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Me.cmdValidaDatos.Enabled = True
            MessageBox.Show("Proceso de validación inconsistente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

        Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCruceAreaDeTerreno.RowCount

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdCruceAreasDeTerrenoCartvsBD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCruceAreasDeTerrenoCartvsBD.Click

        Try
            ' limpia las tablas
            dt_CargaFichaPredial = New DataTable
            dt_CargaCartografia = New DataTable

            ' llena las tablas
            dt_CargaFichaPredial = Me.dgvListadoFichaPredial.DataSource
            dt_CargaCartografia = Me.dgvListadoCartografia.DataSource

            ' verifica que existan registros
            If dt_CargaFichaPredial.Rows.Count > 0 And dt_CargaCartografia.Rows.Count > 0 Then

                ' Crea objeto registros
                Dim dr1 As DataRow

                ' crea la tabla
                dt_CargaCruceAreaDeTerreno = New DataTable

                ' Crea las columnas
                dt_CargaCruceAreaDeTerreno.Columns.Add(New DataColumn("Municipio", GetType(String)))
                dt_CargaCruceAreaDeTerreno.Columns.Add(New DataColumn("Correg", GetType(String)))
                dt_CargaCruceAreaDeTerreno.Columns.Add(New DataColumn("Barrio", GetType(String)))
                dt_CargaCruceAreaDeTerreno.Columns.Add(New DataColumn("Manzana", GetType(String)))
                dt_CargaCruceAreaDeTerreno.Columns.Add(New DataColumn("Predio", GetType(String)))
                dt_CargaCruceAreaDeTerreno.Columns.Add(New DataColumn("Sector", GetType(String)))
                dt_CargaCruceAreaDeTerreno.Columns.Add(New DataColumn("Area_Ficha_Predial", GetType(String)))
                dt_CargaCruceAreaDeTerreno.Columns.Add(New DataColumn("Area_Cartografia", GetType(String)))
                dt_CargaCruceAreaDeTerreno.Columns.Add(New DataColumn("Porcentaje", GetType(String)))
                dt_CargaCruceAreaDeTerreno.Columns.Add(New DataColumn("Observacion", GetType(String)))

                ' declaro la variables
                Dim stFIPRDEPA As String = "05"
                Dim stFIPRMUNI As String = ""
                Dim stFIPRCORR As String = ""
                Dim stFIPRBARR As String = ""
                Dim stFIPRMANZ As String = ""
                Dim stFIPRPRED As String = ""
                Dim stFIPRCLSE As String = ""
                Dim stFIPRCAPR As String = ""
                Dim stFIPRARTE As String = ""

                ' declaro la variables
                Dim stCARTMUNI As String = ""
                Dim stCARTCORR As String = ""
                Dim stCARTBARR As String = ""
                Dim stCARTMANZ As String = ""
                Dim stCARTPRED As String = ""
                Dim stCARTCLSE As String = ""
                Dim stCARTCAPR As String = ""
                Dim stCARTARTE As String = ""

                Dim boCARTARTE_0 As Boolean = True

                ' Valores predeterminados ProgressBar
                inProceso = 0
                pbPROCESO.Value = 0
                pbPROCESO.Maximum = dt_CargaCartografia.Rows.Count + 1
                Timer1.Enabled = True

                ' declaro la variable
                Dim i As Integer = 0

                ' recorro la tabla
                For i = 0 To dt_CargaCartografia.Rows.Count - 1

                    stFIPRMUNI = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaCartografia.Rows(i).Item(0).ToString)), String)
                    stFIPRCORR = CType(fun_Formato_Mascara_2_Reales(Trim(dt_CargaCartografia.Rows(i).Item(1).ToString)), String)
                    stFIPRBARR = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaCartografia.Rows(i).Item(2).ToString)), String)
                    stFIPRMANZ = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaCartografia.Rows(i).Item(3).ToString)), String)
                    stFIPRPRED = CType(fun_Formato_Mascara_5_Reales(Trim(dt_CargaCartografia.Rows(i).Item(4).ToString)), String)
                    stFIPRCLSE = CType(Trim(dt_CargaCartografia.Rows(i).Item(5).ToString), String)
                    stFIPRARTE = CType(Trim(dt_CargaCartografia.Rows(i).Item(6).ToString), String)

                    Dim sw1 As Byte = 0
                    Dim j1 As Integer = 0
                    Dim bySW As Byte = 0
                    Dim boEncuentraRegistro As Boolean = False

                    While j1 < dt_CargaFichaPredial.Rows.Count And sw1 = 0

                        stCARTMUNI = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaFichaPredial.Rows(j1).Item(0).ToString)), String)
                        stCARTCORR = CType(fun_Formato_Mascara_2_Reales(Trim(dt_CargaFichaPredial.Rows(j1).Item(1).ToString)), String)
                        stCARTBARR = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaFichaPredial.Rows(j1).Item(2).ToString)), String)
                        stCARTMANZ = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaFichaPredial.Rows(j1).Item(3).ToString)), String)
                        stCARTPRED = CType(fun_Formato_Mascara_5_Reales(Trim(dt_CargaFichaPredial.Rows(j1).Item(4).ToString)), String)
                        stCARTCLSE = CType(Trim(dt_CargaFichaPredial.Rows(j1).Item(5).ToString), String)
                        stCARTARTE = CType(Trim(dt_CargaFichaPredial.Rows(j1).Item(6).ToString), String)

                        If stFIPRMUNI = stCARTMUNI And _
                           stFIPRCORR = stCARTCORR And _
                           stFIPRBARR = stCARTBARR And _
                           stFIPRMANZ = stCARTMANZ And _
                           stFIPRPRED = stCARTPRED And _
                           stFIPRCLSE = stCARTCLSE Then

                            boEncuentraRegistro = True

                            ' verifica area en cero
                            If stCARTARTE = "0" Then
                                boCARTARTE_0 = True

                                dr1 = dt_CargaCruceAreaDeTerreno.NewRow()

                                dr1("Municipio") = stCARTMUNI
                                dr1("Correg") = stCARTCORR
                                dr1("Barrio") = stCARTBARR
                                dr1("Manzana") = stCARTMANZ
                                dr1("Predio") = stCARTPRED
                                dr1("Sector") = stCARTCLSE
                                dr1("Area_Ficha_Predial") = stFIPRARTE
                                dr1("Area_Cartografia") = stCARTARTE
                                dr1("Porcentaje") = "0.00"
                                dr1("Observacion") = "Area GDB en cero"

                                dt_CargaCruceAreaDeTerreno.Rows.Add(dr1)

                                bySW = 1
                                sw1 = 1

                            Else
                                boCARTARTE_0 = False
                            End If

                            ' verifica el area de terreno
                            If boCARTARTE_0 = False Then
                                If stFIPRARTE = stCARTARTE Then

                                    dr1 = dt_CargaCruceAreaDeTerreno.NewRow()

                                    dr1("Municipio") = stCARTMUNI
                                    dr1("Correg") = stCARTCORR
                                    dr1("Barrio") = stCARTBARR
                                    dr1("Manzana") = stCARTMANZ
                                    dr1("Predio") = stCARTPRED
                                    dr1("Sector") = stCARTCLSE
                                    dr1("Area_Ficha_Predial") = stFIPRARTE
                                    dr1("Area_Cartografia") = stCARTARTE
                                    dr1("Porcentaje") = "0.00"
                                    dr1("Observacion") = "Area sin diferencia"

                                    dt_CargaCruceAreaDeTerreno.Rows.Add(dr1)

                                    bySW = 1
                                    sw1 = 1

                                Else

                                    ' declara las variables
                                    Dim inNroMayor As Integer = 0
                                    Dim inNroMenor As Integer = 0
                                    Dim doPorcentajeCruce As Double = 0.0

                                    ' compara las variables
                                    If CInt(stCARTARTE) > CInt(stFIPRARTE) And CInt(stCARTARTE) <> 0 And CInt(stFIPRARTE) <> 0 Then

                                        ' llenas las variables
                                        inNroMayor = stCARTARTE
                                        inNroMenor = stFIPRARTE

                                        ' calcula el porcentaje de diferencia
                                        doPorcentajeCruce = fun_Formato_Decimal_2_Decimales(((inNroMayor * 100) / inNroMenor) - 100)

                                    ElseIf CInt(stCARTARTE) <> 0 And CInt(stFIPRARTE) <> 0 Then
                                        ' llenas las variables
                                        inNroMayor = stFIPRARTE
                                        inNroMenor = stCARTARTE

                                        ' calcula el porcentaje de diferencia
                                        doPorcentajeCruce = fun_Formato_Decimal_2_Decimales(((inNroMayor * 100) / inNroMenor) - 100)

                                    Else
                                        doPorcentajeCruce = CInt(stCARTARTE)
                                    End If

                                    ' instancia la clase
                                    Dim objdatos55 As New cla_RANGARTE
                                    Dim tbl55 As New DataTable

                                    tbl55 = objdatos55.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_RANGARTE(stFIPRDEPA, stFIPRMUNI, stFIPRCLSE)

                                    If tbl55.Rows.Count > 0 Then

                                        ' declara la variable
                                        Dim inAreaInicial As Integer = 0
                                        Dim inAreaFinal As Integer = 0
                                        Dim doPorcentajePermitido As Double = 0.0

                                        Dim sw2 As Byte = 0
                                        Dim j2 As Integer = 0

                                        While j2 < tbl55.Rows.Count And sw2 = 0

                                            ' declara la variable
                                            inAreaInicial = CInt(tbl55.Rows(j2).Item("RAATATIN"))
                                            inAreaFinal = CInt(tbl55.Rows(j2).Item("RAATATFI"))
                                            doPorcentajePermitido = CDbl(tbl55.Rows(j2).Item("RAATPORC"))

                                            If (inAreaInicial <= inNroMayor) And (inAreaFinal > inNroMayor) Then

                                                If doPorcentajeCruce > doPorcentajePermitido Then

                                                    dr1 = dt_CargaCruceAreaDeTerreno.NewRow()

                                                    dr1("Municipio") = stCARTMUNI
                                                    dr1("Correg") = stCARTCORR
                                                    dr1("Barrio") = stCARTBARR
                                                    dr1("Manzana") = stCARTMANZ
                                                    dr1("Predio") = stCARTPRED
                                                    dr1("Sector") = stCARTCLSE
                                                    dr1("Area_Ficha_Predial") = stFIPRARTE
                                                    dr1("Area_Cartografia") = stCARTARTE
                                                    dr1("Porcentaje") = "Area con % " & doPorcentajeCruce & " mayor al permitido : " & doPorcentajePermitido
                                                    dr1("Observacion") = "Area incorrecta"

                                                    dt_CargaCruceAreaDeTerreno.Rows.Add(dr1)

                                                Else

                                                    dr1 = dt_CargaCruceAreaDeTerreno.NewRow()

                                                    dr1("Municipio") = stCARTMUNI
                                                    dr1("Correg") = stCARTCORR
                                                    dr1("Barrio") = stCARTBARR
                                                    dr1("Manzana") = stCARTMANZ
                                                    dr1("Predio") = stCARTPRED
                                                    dr1("Sector") = stCARTCLSE
                                                    dr1("Area_Ficha_Predial") = stFIPRARTE
                                                    dr1("Area_Cartografia") = stCARTARTE
                                                    dr1("Porcentaje") = "Area con % " & doPorcentajeCruce & " menor al permitido : " & doPorcentajePermitido
                                                    dr1("Observacion") = "Area correcta"

                                                    dt_CargaCruceAreaDeTerreno.Rows.Add(dr1)

                                                End If

                                                sw2 = 1
                                            Else
                                                j2 = j2 + 1
                                            End If

                                        End While

                                    Else
                                        j1 = j1 + 1
                                    End If

                                    j1 = j1 + 1
                                End If
                            End If

                            j1 = j1 + 1
                        Else
                            j1 = j1 + 1
                        End If

                    End While

                    ' verifica si encontro el registro
                    If boEncuentraRegistro = False Then

                        dr1 = dt_CargaCruceAreaDeTerreno.NewRow()

                        dr1("Municipio") = stCARTMUNI
                        dr1("Correg") = stCARTCORR
                        dr1("Barrio") = stCARTBARR
                        dr1("Manzana") = stCARTMANZ
                        dr1("Predio") = stCARTPRED
                        dr1("Sector") = stCARTCLSE
                        dr1("Area_Ficha_Predial") = stFIPRARTE
                        dr1("Area_Cartografia") = stCARTARTE
                        dr1("Porcentaje") = "0.00"
                        dr1("Observacion") = "No se encontro el predio en la DB"

                        dt_CargaCruceAreaDeTerreno.Rows.Add(dr1)

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbPROCESO.Value = inProceso

                Next

                ' inicia la barra de progreso
                pbPROCESO.Value = 0

                'Me.cmdCruceAreasDeTerreno.Enabled = False

                If dt_CargaCruceAreaDeTerreno.Rows.Count > 0 Then
                    Me.dgvCruceAreaDeTerreno.DataSource = dt_CargaCruceAreaDeTerreno
                    MessageBox.Show("Cruce de registros se genero correctamente", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    MessageBox.Show("Cruce de registros no genero resultado", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

                Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dt_CargaCruceAreaDeTerreno.Rows.Count

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdAbrirArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivo.Click

        Try
            Me.dgvListadoCartografia.DataSource = New DataTable
            Me.dgvCruceAreaDeTerreno.DataSource = New DataTable

            Me.cmdCruceAreasDeTerrenoBDvsCart.Enabled = False
            Me.cmdCruceAreasDeTerrenoCartvsBD.Enabled = False

            ' selecciona archivo de excel
            If Me.rbdArchivoExcel.Checked = True Then

                ' declara variable
                inTotalRegistrosCartografia = 0

                ' enruta el archivo
                oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
                oLeer.Filter = "Archivo de texto (*.xls)|*.xls" 'Colocar varias extensiones
                oLeer.FilterIndex = 1 'coloca por defecto el *.txt
                oLeer.FileName = ""
                oLeer.ShowDialog()

                stRutaArchivoCartografia = Trim(oLeer.FileName)

                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

                MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & stRutaArchivoCartografia & "'; Extended Properties=Excel 8.0;")

                Dim stNombreLibro As String = InputBox("Ingrese el nombre de la hoja de excel", "Mensaje")

                If Trim(stNombreLibro) <> "" Then

                    MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & stNombreLibro & "$]", MyConnection)

                    MyCommand.TableMappings.Add("Table", "TestTable")
                    DtSet = New System.Data.DataSet
                    MyCommand.Fill(DtSet)

                    Me.dgvListadoCartografia.DataSource = DtSet.Tables(0)

                    Me.lblRutaArchivo.Text = Trim(oLeer.FileName)

                    Me.TabControl1.SelectTab(TabPage2)

                    inTotalRegistrosCartografia = Me.dgvListadoCartografia.RowCount

                    Me.lblCantidadPrediosCartografia.Text = inTotalRegistrosCartografia

                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvListadoCartografia.RowCount

                    MyConnection.Close()

                Else
                    Me.lblRutaArchivo.Text = ""
                    Me.lblCantidadPrediosCartografia.Text = "0"
                End If



                ' selecciona el archivo de access
            ElseIf Me.rbdArchivoAccess.Checked = True Then

                ' declara variable
                inTotalRegistrosCartografia = 0

                ' enruta el archivo
                oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
                oLeer.Filter = "Archivo de texto (*.mdb)|*.mdb" 'Colocar varias extensiones
                oLeer.FilterIndex = 1 'coloca por defecto el *.txt
                oLeer.FileName = ""
                oLeer.ShowDialog()

                stRutaArchivoCartografia = Trim(oLeer.FileName)

                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

                MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & stRutaArchivoCartografia & "'")

                Dim stNombreLibro As String = InputBox("Ingrese el nombre de la tabla de access", "Mensaje")

                If Trim(stNombreLibro) <> "" Then

                    MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & stNombreLibro & "]", MyConnection)

                    MyCommand.TableMappings.Add("Table", "TestTable")
                    DtSet = New System.Data.DataSet
                    MyCommand.Fill(DtSet)

                    Me.dgvListadoCartografia.DataSource = DtSet.Tables(0)

                    Me.lblRutaArchivo.Text = Trim(oLeer.FileName)

                    Me.TabControl1.SelectTab(TabPage2)

                    inTotalRegistrosCartografia = Me.dgvListadoCartografia.RowCount

                    Me.lblCantidadPrediosCartografia.Text = inTotalRegistrosCartografia

                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvListadoCartografia.RowCount

                    MyConnection.Close()

                Else
                    Me.lblRutaArchivo.Text = ""
                    Me.lblCantidadPrediosCartografia.Text = "0"
                End If

            End If

            pro_ControlDeBotones()

        Catch ex As Exception
            Me.lblRutaArchivo.Text = ""
            Me.lblCantidadPrediosCartografia.Text = "0"
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdConsultarFichaPredial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultarFichaPredial.Click

        Try
            pro_CargaConsultaFichaPredial()
            pro_ControlDeBotones()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdValidaDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValidaDatos.Click

        Try
            ' apaga los comandos
            Me.cmdValidaDatos.Enabled = False

            Me.cmdCruceAreasDeTerrenoBDvsCart.Enabled = False
            Me.cmdCruceAreasDeTerrenoCartvsBD.Enabled = False

            If Trim(stRutaArchivoCartografia) <> "" And Me.dgvListadoCartografia.RowCount > 0 Then

                pro_ValidarAreaTerrenoFichaPredial()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCruceAreasDeTerreno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCruceAreasDeTerrenoBDvsCart.Click

        Try
            ' limpia las tablas
            dt_CargaFichaPredial = New DataTable
            dt_CargaCartografia = New DataTable

            ' llena las tablas
            dt_CargaFichaPredial = Me.dgvListadoFichaPredial.DataSource
            dt_CargaCartografia = Me.dgvListadoCartografia.DataSource

            ' verifica que existan registros
            If dt_CargaFichaPredial.Rows.Count > 0 And dt_CargaCartografia.Rows.Count > 0 Then

                ' Crea objeto registros
                Dim dr1 As DataRow

                ' crea la tabla
                dt_CargaCruceAreaDeTerreno = New DataTable

                ' Crea las columnas
                dt_CargaCruceAreaDeTerreno.Columns.Add(New DataColumn("Municipio", GetType(String)))
                dt_CargaCruceAreaDeTerreno.Columns.Add(New DataColumn("Correg", GetType(String)))
                dt_CargaCruceAreaDeTerreno.Columns.Add(New DataColumn("Barrio", GetType(String)))
                dt_CargaCruceAreaDeTerreno.Columns.Add(New DataColumn("Manzana", GetType(String)))
                dt_CargaCruceAreaDeTerreno.Columns.Add(New DataColumn("Predio", GetType(String)))
                dt_CargaCruceAreaDeTerreno.Columns.Add(New DataColumn("Sector", GetType(String)))
                dt_CargaCruceAreaDeTerreno.Columns.Add(New DataColumn("Area_Ficha_Predial", GetType(String)))
                dt_CargaCruceAreaDeTerreno.Columns.Add(New DataColumn("Area_Cartografia", GetType(String)))
                dt_CargaCruceAreaDeTerreno.Columns.Add(New DataColumn("Porcentaje", GetType(String)))
                dt_CargaCruceAreaDeTerreno.Columns.Add(New DataColumn("Observacion", GetType(String)))

                ' declaro la variables
                Dim stFIPRDEPA As String = "05"
                Dim stFIPRMUNI As String = ""
                Dim stFIPRCORR As String = ""
                Dim stFIPRBARR As String = ""
                Dim stFIPRMANZ As String = ""
                Dim stFIPRPRED As String = ""
                Dim stFIPRCLSE As String = ""
                Dim stFIPRCAPR As String = ""
                Dim stFIPRARTE As String = ""

                ' declaro la variables
                Dim stCARTMUNI As String = ""
                Dim stCARTCORR As String = ""
                Dim stCARTBARR As String = ""
                Dim stCARTMANZ As String = ""
                Dim stCARTPRED As String = ""
                Dim stCARTCLSE As String = ""
                Dim stCARTCAPR As String = ""
                Dim stCARTARTE As String = ""

                Dim boFIPRARTE_0 As Boolean = True

                ' Valores predeterminados ProgressBar
                inProceso = 0
                pbPROCESO.Value = 0
                pbPROCESO.Maximum = dt_CargaFichaPredial.Rows.Count + 1
                Timer1.Enabled = True

                ' declaro la variable
                Dim i As Integer = 0

                ' recorro la tabla
                For i = 0 To dt_CargaFichaPredial.Rows.Count - 1

                    stFIPRMUNI = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaFichaPredial.Rows(i).Item(0).ToString)), String)
                    stFIPRCORR = CType(fun_Formato_Mascara_2_Reales(Trim(dt_CargaFichaPredial.Rows(i).Item(1).ToString)), String)
                    stFIPRBARR = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaFichaPredial.Rows(i).Item(2).ToString)), String)
                    stFIPRMANZ = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaFichaPredial.Rows(i).Item(3).ToString)), String)
                    stFIPRPRED = CType(fun_Formato_Mascara_5_Reales(Trim(dt_CargaFichaPredial.Rows(i).Item(4).ToString)), String)
                    stFIPRCLSE = CType(Trim(dt_CargaFichaPredial.Rows(i).Item(5).ToString), String)
                    stFIPRARTE = CType(Trim(dt_CargaFichaPredial.Rows(i).Item(6).ToString), String)

                    Dim sw1 As Byte = 0
                    Dim j1 As Integer = 0
                    Dim bySW As Byte = 0
                    Dim boEncuentraRegistro As Boolean = False

                    While j1 < dt_CargaCartografia.Rows.Count And sw1 = 0

                        stCARTMUNI = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaCartografia.Rows(j1).Item(0).ToString)), String)
                        stCARTCORR = CType(fun_Formato_Mascara_2_Reales(Trim(dt_CargaCartografia.Rows(j1).Item(1).ToString)), String)
                        stCARTBARR = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaCartografia.Rows(j1).Item(2).ToString)), String)
                        stCARTMANZ = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaCartografia.Rows(j1).Item(3).ToString)), String)
                        stCARTPRED = CType(fun_Formato_Mascara_5_Reales(Trim(dt_CargaCartografia.Rows(j1).Item(4).ToString)), String)
                        stCARTCLSE = CType(Trim(dt_CargaCartografia.Rows(j1).Item(5).ToString), String)
                        stCARTARTE = CType(Trim(dt_CargaCartografia.Rows(j1).Item(6).ToString), String)

                        If stFIPRMUNI = stCARTMUNI And _
                           stFIPRCORR = stCARTCORR And _
                           stFIPRBARR = stCARTBARR And _
                           stFIPRMANZ = stCARTMANZ And _
                           stFIPRPRED = stCARTPRED And _
                           stFIPRCLSE = stCARTCLSE Then

                            boEncuentraRegistro = True

                            ' verifica area en cero
                            If stFIPRARTE = "0" Then
                                boFIPRARTE_0 = True

                                dr1 = dt_CargaCruceAreaDeTerreno.NewRow()

                                dr1("Municipio") = stFIPRMUNI
                                dr1("Correg") = stFIPRCORR
                                dr1("Barrio") = stFIPRBARR
                                dr1("Manzana") = stFIPRMANZ
                                dr1("Predio") = stFIPRPRED
                                dr1("Sector") = stFIPRCLSE
                                dr1("Area_Ficha_Predial") = stFIPRARTE
                                dr1("Area_Cartografia") = stCARTARTE
                                dr1("Porcentaje") = "0.00"
                                dr1("Observacion") = "Area BD en cero"

                                dt_CargaCruceAreaDeTerreno.Rows.Add(dr1)

                                bySW = 1
                                sw1 = 1

                            Else
                                boFIPRARTE_0 = False
                            End If

                            ' verifica el area de terreno
                            If boFIPRARTE_0 = False Then
                                If stFIPRARTE = stCARTARTE Then

                                    dr1 = dt_CargaCruceAreaDeTerreno.NewRow()

                                    dr1("Municipio") = stFIPRMUNI
                                    dr1("Correg") = stFIPRCORR
                                    dr1("Barrio") = stFIPRBARR
                                    dr1("Manzana") = stFIPRMANZ
                                    dr1("Predio") = stFIPRPRED
                                    dr1("Sector") = stFIPRCLSE
                                    dr1("Area_Ficha_Predial") = stFIPRARTE
                                    dr1("Area_Cartografia") = stCARTARTE
                                    dr1("Porcentaje") = "0.00"
                                    dr1("Observacion") = "Area sin diferencia"

                                    dt_CargaCruceAreaDeTerreno.Rows.Add(dr1)

                                    bySW = 1
                                    sw1 = 1

                                Else

                                    ' declara las variables
                                    Dim inNroMayor As Integer = 0
                                    Dim inNroMenor As Integer = 0
                                    Dim doPorcentajeCruce As Double = 0.0

                                    ' compara las variables
                                    If CInt(stFIPRARTE) > CInt(stCARTARTE) And CInt(stCARTARTE) <> 0 And CInt(stFIPRARTE) <> 0 Then

                                        ' llenas las variables
                                        inNroMayor = stFIPRARTE
                                        inNroMenor = stCARTARTE

                                        ' calcula el porcentaje de diferencia
                                        doPorcentajeCruce = fun_Formato_Decimal_2_Decimales(((inNroMayor * 100) / inNroMenor) - 100)

                                    ElseIf CInt(stCARTARTE) <> 0 And CInt(stFIPRARTE) <> 0 Then
                                        ' llenas las variables
                                        inNroMayor = stCARTARTE
                                        inNroMenor = stFIPRARTE

                                        ' calcula el porcentaje de diferencia
                                        doPorcentajeCruce = fun_Formato_Decimal_2_Decimales(((inNroMayor * 100) / inNroMenor) - 100)

                                    Else

                                        doPorcentajeCruce = CInt(stFIPRARTE)

                                    End If

                                    ' instancia la clase
                                    Dim objdatos55 As New cla_RANGARTE
                                    Dim tbl55 As New DataTable

                                    tbl55 = objdatos55.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_RANGARTE(stFIPRDEPA, stFIPRMUNI, stFIPRCLSE)

                                    If tbl55.Rows.Count > 0 Then

                                        ' declara la variable
                                        Dim inAreaInicial As Integer = 0
                                        Dim inAreaFinal As Integer = 0
                                        Dim doPorcentajePermitido As Double = 0.0

                                        Dim sw2 As Byte = 0
                                        Dim j2 As Integer = 0

                                        While j2 < tbl55.Rows.Count And sw2 = 0

                                            ' declara la variable
                                            inAreaInicial = CInt(tbl55.Rows(j2).Item("RAATATIN"))
                                            inAreaFinal = CInt(tbl55.Rows(j2).Item("RAATATFI"))
                                            doPorcentajePermitido = CDbl(tbl55.Rows(j2).Item("RAATPORC"))

                                            If (inAreaInicial <= inNroMayor) And (inAreaFinal > inNroMayor) Then

                                                If doPorcentajeCruce > doPorcentajePermitido Then

                                                    dr1 = dt_CargaCruceAreaDeTerreno.NewRow()

                                                    dr1("Municipio") = stFIPRMUNI
                                                    dr1("Correg") = stFIPRCORR
                                                    dr1("Barrio") = stFIPRBARR
                                                    dr1("Manzana") = stFIPRMANZ
                                                    dr1("Predio") = stFIPRPRED
                                                    dr1("Sector") = stFIPRCLSE
                                                    dr1("Area_Ficha_Predial") = stFIPRARTE
                                                    dr1("Area_Cartografia") = stCARTARTE
                                                    dr1("Porcentaje") = "Area con % " & doPorcentajeCruce & " mayor al permitido : " & doPorcentajePermitido
                                                    dr1("Observacion") = "Area incorrecta"

                                                    dt_CargaCruceAreaDeTerreno.Rows.Add(dr1)

                                                Else

                                                    dr1 = dt_CargaCruceAreaDeTerreno.NewRow()

                                                    dr1("Municipio") = stFIPRMUNI
                                                    dr1("Correg") = stFIPRCORR
                                                    dr1("Barrio") = stFIPRBARR
                                                    dr1("Manzana") = stFIPRMANZ
                                                    dr1("Predio") = stFIPRPRED
                                                    dr1("Sector") = stFIPRCLSE
                                                    dr1("Area_Ficha_Predial") = stFIPRARTE
                                                    dr1("Area_Cartografia") = stCARTARTE
                                                    dr1("Porcentaje") = "Area con % " & doPorcentajeCruce & " menor al permitido : " & doPorcentajePermitido
                                                    dr1("Observacion") = "Area correcta"

                                                    dt_CargaCruceAreaDeTerreno.Rows.Add(dr1)

                                                End If

                                                sw2 = 1
                                            Else
                                                j2 = j2 + 1
                                            End If

                                        End While

                                    Else
                                        j1 = j1 + 1
                                    End If

                                    j1 = j1 + 1
                                End If
                            End If
                            j1 = j1 + 1
                        Else
                            j1 = j1 + 1
                        End If

                    End While

                    ' verifica si encontro el registro
                    If boEncuentraRegistro = False Then

                        dr1 = dt_CargaCruceAreaDeTerreno.NewRow()

                        dr1("Municipio") = stFIPRMUNI
                        dr1("Correg") = stFIPRCORR
                        dr1("Barrio") = stFIPRBARR
                        dr1("Manzana") = stFIPRMANZ
                        dr1("Predio") = stFIPRPRED
                        dr1("Sector") = stFIPRCLSE
                        dr1("Area_Ficha_Predial") = stFIPRARTE
                        dr1("Area_Cartografia") = stCARTARTE
                        dr1("Porcentaje") = "0.00"
                        dr1("Observacion") = "No se encontro el predio en la GDB"

                        dt_CargaCruceAreaDeTerreno.Rows.Add(dr1)

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbPROCESO.Value = inProceso

                Next

                ' inicia la barra de progreso
                pbPROCESO.Value = 0

                'Me.cmdCruceAreasDeTerreno.Enabled = False

                If dt_CargaCruceAreaDeTerreno.Rows.Count > 0 Then
                    Me.dgvCruceAreaDeTerreno.DataSource = dt_CargaCruceAreaDeTerreno
                    MessageBox.Show("Cruce de registros se genero correctamente", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    MessageBox.Show("Cruce de registros no genero resultado", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

                Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dt_CargaCruceAreaDeTerreno.Rows.Count

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        Try
            If rbdListadoBaseDeDatos.Checked = True Then

                If Me.dgvListadoFichaPredial.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvListadoFichaPredial.DataSource, DataTable))
                End If

            ElseIf rbdListadoCartografia.Checked = True Then

                If Me.dgvListadoCartografia.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvListadoCartografia.DataSource, DataTable))
                End If

            ElseIf rbdCruceAreaTerreno.Checked = True Then

                If Me.dgvCruceAreaDeTerreno.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvCruceAreaDeTerreno.DataSource, DataTable))
                End If

            End If

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

#End Region

#Region "FORMULARIO"

#Region "KeyPress"

    Private Sub txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRNUFI.KeyPress, txtFIPRTIFI.KeyPress, txtFIPRDIRE.KeyPress, txtFIPRDIRE.KeyPress, txtFIPRMUNI.KeyPress, txtFIPRCORR.KeyPress, txtFIPRBARR.KeyPress, txtFIPRMANZ.KeyPress, txtFIPRPRED.KeyPress, txtFIPREDIF.KeyPress, txtFIPRUNPR.KeyPress, txtFIPRCLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRNUFI.GotFocus, txtFIPRTIFI.GotFocus, txtFIPRDIRE.GotFocus, txtFIPRDIRE.GotFocus, txtFIPRMUNI.GotFocus, txtFIPRCORR.GotFocus, txtFIPRBARR.GotFocus, txtFIPRMANZ.GotFocus, txtFIPRPRED.GotFocus, txtFIPREDIF.GotFocus, txtFIPRUNPR.GotFocus, txtFIPRCLSE.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus, cmdAbrirArchivo.GotFocus, cmdConsultarFichaPredial.GotFocus, cmdCruceAreasDeTerrenoBDvsCart.GotFocus, cmdExportarExcel.GotFocus, cmdLIMPIAR.GotFocus, cmdCruceAreasDeTerrenoBDvsCart.GotFocus
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub

#End Region

#Region "Validated"

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