Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_Cruce_Areas_Construccion_BD_Geodata

    '=================================================
    '*** CRUCE DE AREAS DE CONSTRUCCION VS GEODATA ***
    '=================================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Cruce_Areas_Construccion_BD_Geodata
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Cruce_Areas_Construccion_BD_Geodata
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
    Dim dt_CargaGeodata As New DataTable
    Dim dt_CargaCruceAreaDeConstruccion As New DataTable

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
            Me.dgvCruceArea.DataSource = New DataTable

            Me.cmdCruceAreasDeConstruccionBDvsGeodata.Enabled = False
            Me.cmdCruceAreasDeConstruccionGeodataVsBD.Enabled = False

            Me.lblFecha2.Visible = False

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
            ParametrosConsulta += "FiprNufi, "
            ParametrosConsulta += "FiprMuni, "
            ParametrosConsulta += "FiprCorr, "
            ParametrosConsulta += "FiprBarr, "
            ParametrosConsulta += "FiprManz, "
            ParametrosConsulta += "FiprPred, "
            ParametrosConsulta += "FiprEdif, "
            ParametrosConsulta += "FiprUnpr, "
            ParametrosConsulta += "FiprClse, "
            ParametrosConsulta += "FpcoUnid, "
            ParametrosConsulta += "FpcoTico, "
            ParametrosConsulta += "FpcoPunt, "
            ParametrosConsulta += "FpcoArco  "
            ParametrosConsulta += "From FichPred, FiprCons where "
            ParametrosConsulta += "FiprNufi = FpcoNufi and "
            ParametrosConsulta += "FiprNufi like '" & vl_stFIPRNUFI & "' and "
            ParametrosConsulta += "FiprTifi = '" & "0" & "' and "
            ParametrosConsulta += "FiprMuni like '" & vl_stFIPRMUNI & "' and "
            ParametrosConsulta += "FiprCorr like '" & vl_stFIPRCORR & "' and "
            ParametrosConsulta += "FiprBarr like '" & vl_stFIPRBARR & "' and "
            ParametrosConsulta += "FiprManz like '" & vl_stFIPRMANZ & "' and "
            ParametrosConsulta += "FiprPred like '" & vl_stFIPRPRED & "' and "
            ParametrosConsulta += "FiprClse like '" & vl_stFIPRCLSE & "' and "
            ParametrosConsulta += "FiprEsta = '" & "ac" & "' and "
            ParametrosConsulta += "FpcoEsta = '" & "ac" & "' "
            ParametrosConsulta += "order by FiprClse,FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred "

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
                dt_CargaFichaPredial.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                dt_CargaFichaPredial.Columns.Add(New DataColumn("Municipio", GetType(String)))
                dt_CargaFichaPredial.Columns.Add(New DataColumn("Correg", GetType(String)))
                dt_CargaFichaPredial.Columns.Add(New DataColumn("Barrio", GetType(String)))
                dt_CargaFichaPredial.Columns.Add(New DataColumn("Manzana", GetType(String)))
                dt_CargaFichaPredial.Columns.Add(New DataColumn("Predio", GetType(String)))
                dt_CargaFichaPredial.Columns.Add(New DataColumn("Edificio", GetType(String)))
                dt_CargaFichaPredial.Columns.Add(New DataColumn("Unidad_Predial", GetType(String)))
                dt_CargaFichaPredial.Columns.Add(New DataColumn("Sector", GetType(String)))
                dt_CargaFichaPredial.Columns.Add(New DataColumn("Nro_Cons", GetType(String)))
                dt_CargaFichaPredial.Columns.Add(New DataColumn("Identificador", GetType(String)))
                dt_CargaFichaPredial.Columns.Add(New DataColumn("Puntos", GetType(String)))
                dt_CargaFichaPredial.Columns.Add(New DataColumn("Area_Cons", GetType(String)))

                ' declara las variables
                Dim stFIPRNUFI As String = ""
                Dim stFIPRMUNI As String = ""
                Dim stFIPRCORR As String = ""
                Dim stFIPRBARR As String = ""
                Dim stFIPRMANZ As String = ""
                Dim stFIPRPRED As String = ""
                Dim stFIPREDIF As String = ""
                Dim stFIPRUNPR As String = ""
                Dim stFIPRCLSE As String = ""
                Dim stFPCOUNID As String = ""
                Dim stFPCOTICO As String = ""
                Dim stFPCOPUNT As String = ""
                Dim stFPCOARCO As String = ""

                ' declara la variable
                Dim i As Integer = 0

                For i = 0 To dt_1.Rows.Count - 1

                    stFIPRNUFI = CType(Trim(dt_1.Rows(i).Item(0).ToString), String)
                    stFIPRMUNI = CType(Trim(dt_1.Rows(i).Item(1).ToString), String)
                    stFIPRCORR = CType(Trim(dt_1.Rows(i).Item(2).ToString), String)
                    stFIPRBARR = CType(Trim(dt_1.Rows(i).Item(3).ToString), String)
                    stFIPRMANZ = CType(Trim(dt_1.Rows(i).Item(4).ToString), String)
                    stFIPRPRED = CType(Trim(dt_1.Rows(i).Item(5).ToString), String)
                    stFIPREDIF = CType(Trim(dt_1.Rows(i).Item(6).ToString), String)
                    stFIPRUNPR = CType(Trim(dt_1.Rows(i).Item(7).ToString), String)
                    stFIPRCLSE = CType(Trim(dt_1.Rows(i).Item(8).ToString), String)
                    stFPCOUNID = CType(Trim(dt_1.Rows(i).Item(9).ToString), String)
                    stFPCOTICO = CType(fun_Formato_Mascara_3_String(Trim(dt_1.Rows(i).Item(10).ToString)), String)
                    stFPCOPUNT = CType(Trim(dt_1.Rows(i).Item(11).ToString), String)
                    stFPCOARCO = CType(fun_Formato_Decimal_2_Decimales(Trim(dt_1.Rows(i).Item(12).ToString)), String)

                    dr1 = dt_CargaFichaPredial.NewRow()

                    dr1("Nro_Ficha") = CStr(stFIPRNUFI)
                    dr1("Municipio") = CStr(stFIPRMUNI)
                    dr1("Correg") = CStr(stFIPRCORR)
                    dr1("Barrio") = CStr(stFIPRBARR)
                    dr1("Manzana") = CStr(stFIPRMANZ)
                    dr1("Predio") = CStr(stFIPRPRED)
                    dr1("Edificio") = CStr(stFIPREDIF)
                    dr1("Unidad_Predial") = CStr(stFIPRUNPR)
                    dr1("Sector") = CStr(stFIPRCLSE)
                    dr1("Nro_Cons") = CStr(stFPCOUNID)
                    dr1("Identificador") = CStr(stFPCOTICO)
                    dr1("Puntos") = CStr(stFPCOPUNT)
                    dr1("Area_Cons") = CStr(stFPCOARCO)

                    dt_CargaFichaPredial.Rows.Add(dr1)

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
        Me.dgvListadoGeodata.DataSource = New DataTable
        Me.dgvCruceArea.DataSource = New DataTable

        Me.strBARRESTA.Items(2).Text = "Registro : 0"

        Me.cmdCruceAreasDeConstruccionBDvsGeodata.Enabled = False
        Me.cmdCruceAreasDeConstruccionGeodataVsBD.Enabled = False

        Me.cmdValidaDatos.Enabled = False

    End Sub
    Private Sub pro_ControlDeBotones()

        If Me.dgvListadoGeodata.RowCount > 0 And Me.dgvListadoFichaPredial.RowCount > 0 Then
            Me.cmdValidaDatos.Enabled = True

            Me.cmdCruceAreasDeConstruccionBDvsGeodata.Enabled = False
            Me.cmdCruceAreasDeConstruccionGeodataVsBD.Enabled = False
        Else
            Me.cmdValidaDatos.Enabled = False
        End If

    End Sub
    Private Sub pro_ValidarAreaConstruccionFichaPredial()

        ' limpia los datagrigview
        Me.dgvCruceArea.DataSource = New DataTable

        ' Valores predeterminados ProgressBar
        inProceso = 0
        pbPROCESO.Value = 0
        pbPROCESO.Maximum = Me.dgvListadoGeodata.RowCount + 1
        Timer1.Enabled = True

        ' Crea objeto de columnas y registros
        Dim dt1 As New DataTable
        Dim dr1 As DataRow

        ' Crea las columnas
        dt1.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
        dt1.Columns.Add(New DataColumn("Unidad", GetType(String)))
        dt1.Columns.Add(New DataColumn("Identificador", GetType(String)))
        dt1.Columns.Add(New DataColumn("Puntos", GetType(String)))
        dt1.Columns.Add(New DataColumn("Area", GetType(String)))

        ' crea la variable
        Dim i As Integer = 0

        ' crea la tabla
        dt_CargaGeodata = New DataTable

        ' carga la tabla
        dt_CargaGeodata = Me.dgvListadoGeodata.DataSource

        For i = 0 To dt_CargaGeodata.Rows.Count - 1

            ' verifica que el campo Nro_Ficha
            If Trim(dt_CargaGeodata.Rows(i).Item(0).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = "El Nro. de ficha esta vacio"
                dr1("Unidad") = Trim(dt_CargaGeodata.Rows(i).Item(1).ToString)
                dr1("Identificador") = Trim(dt_CargaGeodata.Rows(i).Item(2).ToString)
                dr1("Puntos") = Trim(dt_CargaGeodata.Rows(i).Item(3).ToString)
                dr1("Area") = Trim(dt_CargaGeodata.Rows(i).Item(4).ToString)

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_CargaGeodata.Rows(i).Item(0).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Nro_Ficha") = "El Nro. no es numerico"
                    dr1("Unidad") = Trim(dt_CargaGeodata.Rows(i).Item(1).ToString)
                    dr1("Identificador") = Trim(dt_CargaGeodata.Rows(i).Item(2).ToString)
                    dr1("Puntos") = Trim(dt_CargaGeodata.Rows(i).Item(3).ToString)
                    dr1("Area") = Trim(dt_CargaGeodata.Rows(i).Item(4).ToString)

                    dt1.Rows.Add(dr1)

                End If

            End If

            ' verifica que el campo Unidad
            If Trim(dt_CargaGeodata.Rows(i).Item(1).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_CargaGeodata.Rows(i).Item(0).ToString)
                dr1("Unidad") = "El campo unidad esta vacio"
                dr1("Identificador") = Trim(dt_CargaGeodata.Rows(i).Item(2).ToString)
                dr1("Puntos") = Trim(dt_CargaGeodata.Rows(i).Item(3).ToString)
                dr1("Area") = Trim(dt_CargaGeodata.Rows(i).Item(4).ToString)

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_CargaGeodata.Rows(i).Item(1).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Nro_Ficha") = Trim(dt_CargaGeodata.Rows(i).Item(0).ToString)
                    dr1("Unidad") = "El campo unidad no es numerico"
                    dr1("Identificador") = Trim(dt_CargaGeodata.Rows(i).Item(2).ToString)
                    dr1("Puntos") = Trim(dt_CargaGeodata.Rows(i).Item(3).ToString)
                    dr1("Area") = Trim(dt_CargaGeodata.Rows(i).Item(4).ToString)

                    dt1.Rows.Add(dr1)

                End If

            End If

            ' verifica que el campo Identificador
            If Trim(dt_CargaGeodata.Rows(i).Item(2).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_CargaGeodata.Rows(i).Item(0).ToString)
                dr1("Unidad") = Trim(dt_CargaGeodata.Rows(i).Item(1).ToString)
                dr1("Identificador") = "El campo Identificador esta vacio"
                dr1("Puntos") = Trim(dt_CargaGeodata.Rows(i).Item(3).ToString)
                dr1("Area") = Trim(dt_CargaGeodata.Rows(i).Item(4).ToString)

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_CargaGeodata.Rows(i).Item(2).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Nro_Ficha") = Trim(dt_CargaGeodata.Rows(i).Item(0).ToString)
                    dr1("Unidad") = Trim(dt_CargaGeodata.Rows(i).Item(1).ToString)
                    dr1("Identificador") = "El campo Identificador no es numerico"
                    dr1("Puntos") = Trim(dt_CargaGeodata.Rows(i).Item(3).ToString)
                    dr1("Area") = Trim(dt_CargaGeodata.Rows(i).Item(4).ToString)

                    dt1.Rows.Add(dr1)

                End If

            End If

            ' verifica que el campo Puntos
            If Trim(dt_CargaGeodata.Rows(i).Item(3).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_CargaGeodata.Rows(i).Item(0).ToString)
                dr1("Unidad") = Trim(dt_CargaGeodata.Rows(i).Item(1).ToString)
                dr1("Identificador") = Trim(dt_CargaGeodata.Rows(i).Item(2).ToString)
                dr1("Puntos") = "El campo Puntos esta vacio"
                dr1("Area") = Trim(dt_CargaGeodata.Rows(i).Item(4).ToString)

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_CargaGeodata.Rows(i).Item(3).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Nro_Ficha") = Trim(dt_CargaGeodata.Rows(i).Item(0).ToString)
                    dr1("Unidad") = Trim(dt_CargaGeodata.Rows(i).Item(1).ToString)
                    dr1("Identificador") = Trim(dt_CargaGeodata.Rows(i).Item(2).ToString)
                    dr1("Puntos") = "El campo Puntos no es numerico"
                    dr1("Area") = Trim(dt_CargaGeodata.Rows(i).Item(4).ToString)

                    dt1.Rows.Add(dr1)

                End If

            End If

            ' verifica que el campo Puntos
            If Trim(dt_CargaGeodata.Rows(i).Item(4).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_CargaGeodata.Rows(i).Item(0).ToString)
                dr1("Unidad") = Trim(dt_CargaGeodata.Rows(i).Item(1).ToString)
                dr1("Identificador") = Trim(dt_CargaGeodata.Rows(i).Item(2).ToString)
                dr1("Puntos") = Trim(dt_CargaGeodata.Rows(i).Item(3).ToString)
                dr1("Area") = "El campo Area esta vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Decimal_Evento_Validated(Trim(dt_CargaGeodata.Rows(i).Item(4).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Nro_Ficha") = Trim(dt_CargaGeodata.Rows(i).Item(0).ToString)
                    dr1("Unidad") = Trim(dt_CargaGeodata.Rows(i).Item(1).ToString)
                    dr1("Identificador") = Trim(dt_CargaGeodata.Rows(i).Item(2).ToString)
                    dr1("Puntos") = Trim(dt_CargaGeodata.Rows(i).Item(3).ToString)
                    dr1("Area") = "El campo Area no es numerico"

                    dt1.Rows.Add(dr1)

                End If

            End If

            ' Incrementa la barra
            inProceso = inProceso + 1
            pbPROCESO.Value = inProceso

        Next

        ' Llena el datagrigview
        TabControl1.SelectTab(TabPage3)
        Me.dgvCruceArea.DataSource = dt1
        pbPROCESO.Value = 0

        ' comando grabar datos
        If dt1.Rows.Count = 0 Then
            Me.cmdCruceAreasDeConstruccionBDvsGeodata.Enabled = True
            Me.cmdCruceAreasDeConstruccionGeodataVsBD.Enabled = True
            Me.lblFecha2.Visible = True
            Me.cmdValidaDatos.Enabled = False
            Me.cmdCruceAreasDeConstruccionBDvsGeodata.Focus()
            MessageBox.Show("Proceso de validación terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Me.cmdValidaDatos.Enabled = True
            MessageBox.Show("Proceso de validación inconsistente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

        Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvCruceArea.RowCount

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdCruceAreasDeConstruccionGeodataVsBD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCruceAreasDeConstruccionGeodataVsBD.Click

        Try
            ' limpia las tablas
            dt_CargaFichaPredial = New DataTable
            dt_CargaGeodata = New DataTable

            ' llena las tablas
            dt_CargaFichaPredial = Me.dgvListadoFichaPredial.DataSource
            dt_CargaGeodata = Me.dgvListadoGeodata.DataSource

            ' verifica que existan registros
            If dt_CargaFichaPredial.Rows.Count > 0 And dt_CargaGeodata.Rows.Count > 0 Then

                ' Crea objeto registros
                Dim dr1 As DataRow

                ' crea la tabla
                dt_CargaCruceAreaDeConstruccion = New DataTable

                ' Crea las columnas
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Municipio", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Correg", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Barrio", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Manzana", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Predio", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Edificio", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Unidad_Predial", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Sector", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Nro_Cons", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Ident", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Puntos", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Area_Cons_BD", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Area_Cons_GDB", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Porcentaje", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Observacion", GetType(String)))

                ' declaro la variables
                Dim stFIPRNUFI As String = ""
                Dim stFIPRMUNI As String = ""
                Dim stFIPRCORR As String = ""
                Dim stFIPRBARR As String = ""
                Dim stFIPRMANZ As String = ""
                Dim stFIPRPRED As String = ""
                Dim stFIPREDIF As String = ""
                Dim stFIPRUNPR As String = ""
                Dim stFIPRCLSE As String = ""
                Dim stFPCOUNID As String = ""
                Dim stFPCOTICO As String = ""
                Dim stFPCOPUNT As String = ""
                Dim stFPCOARCO As String = ""

                ' declaro la variables
                Dim stCARTNUFI As String = ""
                Dim stCARTMUNI As String = ""
                Dim stCARTCORR As String = ""
                Dim stCARTBARR As String = ""
                Dim stCARTMANZ As String = ""
                Dim stCARTPRED As String = ""
                Dim stCARTEDIF As String = ""
                Dim stCARTUNPR As String = ""
                Dim stCARTCLSE As String = ""
                Dim stCARTUNID As String = ""
                Dim stCARTTICO As String = ""
                Dim stCARTPUNT As String = ""
                Dim stCARTARCO As String = ""

                ' Valores predeterminados ProgressBar
                inProceso = 0
                Me.pbPROCESO.Value = 0
                Me.pbPROCESO.Maximum = dt_CargaGeodata.Rows.Count + 1
                Me.Timer1.Enabled = True

                ' declaro la variable
                Dim i As Integer = 0

                ' recorro la tabla
                For i = 0 To dt_CargaGeodata.Rows.Count - 1

                    stCARTNUFI = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaGeodata.Rows(i).Item(0).ToString)), String)
                    stCARTMUNI = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaGeodata.Rows(i).Item(1).ToString)), String)
                    stCARTCORR = CType(fun_Formato_Mascara_2_Reales(Trim(dt_CargaGeodata.Rows(i).Item(2).ToString)), String)
                    stCARTBARR = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaGeodata.Rows(i).Item(3).ToString)), String)
                    stCARTMANZ = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaGeodata.Rows(i).Item(4).ToString)), String)
                    stCARTPRED = CType(fun_Formato_Mascara_5_Reales(Trim(dt_CargaGeodata.Rows(i).Item(5).ToString)), String)
                    stCARTEDIF = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaGeodata.Rows(i).Item(6).ToString)), String)
                    stCARTUNPR = CType(fun_Formato_Mascara_5_Reales(Trim(dt_CargaGeodata.Rows(i).Item(7).ToString)), String)
                    stCARTCLSE = CType(Trim(dt_CargaGeodata.Rows(i).Item(8).ToString), String)
                    stCARTUNID = CType(Trim(dt_CargaGeodata.Rows(i).Item(9).ToString), String)
                    stCARTTICO = CType(Trim(dt_CargaGeodata.Rows(i).Item(10).ToString), String)
                    stCARTPUNT = CType(Trim(dt_CargaGeodata.Rows(i).Item(11).ToString), String)
                    stCARTARCO = CType(Trim(dt_CargaGeodata.Rows(i).Item(12).ToString), String)

                    Dim sw1 As Byte = 0
                    Dim j1 As Integer = 0
                    Dim bySW As Byte = 0
                    Dim boEncuentraRegistro As Boolean = False

                    While j1 < dt_CargaFichaPredial.Rows.Count And sw1 = 0

                        stFIPRNUFI = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaFichaPredial.Rows(j1).Item(0).ToString)), String)
                        stFIPRMUNI = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaFichaPredial.Rows(j1).Item(1).ToString)), String)
                        stFIPRCORR = CType(fun_Formato_Mascara_2_Reales(Trim(dt_CargaFichaPredial.Rows(j1).Item(2).ToString)), String)
                        stFIPRBARR = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaFichaPredial.Rows(j1).Item(3).ToString)), String)
                        stFIPRMANZ = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaFichaPredial.Rows(j1).Item(4).ToString)), String)
                        stFIPRPRED = CType(fun_Formato_Mascara_5_Reales(Trim(dt_CargaFichaPredial.Rows(j1).Item(5).ToString)), String)
                        stFIPREDIF = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaFichaPredial.Rows(j1).Item(6).ToString)), String)
                        stFIPRUNPR = CType(fun_Formato_Mascara_5_Reales(Trim(dt_CargaFichaPredial.Rows(j1).Item(7).ToString)), String)
                        stFIPRCLSE = CType(Trim(dt_CargaFichaPredial.Rows(j1).Item(8).ToString), String)
                        stFPCOUNID = CType(Trim(dt_CargaFichaPredial.Rows(j1).Item(9).ToString), String)
                        stFPCOTICO = CType(Trim(dt_CargaFichaPredial.Rows(j1).Item(10).ToString), String)
                        stFPCOPUNT = CType(Trim(dt_CargaFichaPredial.Rows(j1).Item(11).ToString), String)
                        stFPCOARCO = CType(Trim(dt_CargaFichaPredial.Rows(j1).Item(12).ToString), String)

                        If stFIPRNUFI = stCARTNUFI And _
                           stFIPRMUNI = stCARTMUNI And _
                           stFIPRCORR = stCARTCORR And _
                           stFIPRBARR = stCARTBARR And _
                           stFIPRMANZ = stCARTMANZ And _
                           stFIPRPRED = stCARTPRED And _
                           stFIPREDIF = stCARTEDIF And _
                           stFIPRUNPR = stCARTUNPR And _
                           stFIPRCLSE = stCARTCLSE And _
                           stFPCOUNID = stCARTUNID Then

                            boEncuentraRegistro = True

                            ' verifica el area de terreno
                            If stFPCOARCO = stCARTARCO Then

                                dr1 = dt_CargaCruceAreaDeConstruccion.NewRow()

                                dr1("Nro_Ficha") = stCARTNUFI
                                dr1("Municipio") = stCARTMUNI
                                dr1("Correg") = stCARTCORR
                                dr1("Barrio") = stCARTBARR
                                dr1("Manzana") = stCARTMANZ
                                dr1("Predio") = stCARTPRED
                                dr1("Edificio") = stCARTEDIF
                                dr1("Unidad_Predial") = stCARTUNPR
                                dr1("Sector") = stCARTCLSE
                                dr1("Nro_Cons") = stCARTUNID
                                dr1("Ident") = stCARTTICO
                                dr1("Puntos") = stCARTPUNT
                                dr1("Area_Cons_BD") = stFPCOARCO
                                dr1("Area_Cons_GDB") = stCARTARCO
                                dr1("Porcentaje") = "0.00"
                                dr1("Observacion") = "Area sin diferencia"

                                dt_CargaCruceAreaDeConstruccion.Rows.Add(dr1)

                                bySW = 1
                                sw1 = 1

                            Else

                                ' declara las variables
                                Dim inNroMayor As Integer = 0
                                Dim inNroMenor As Integer = 0
                                Dim doPorcentajeCruce As Double = 0.0

                                ' compara las variables
                                If CInt(stFPCOARCO) > CInt(stCARTARCO) And CInt(stCARTARCO) <> 0 And CInt(stFPCOARCO) <> 0 Then

                                    ' llenas las variables
                                    inNroMayor = stFPCOARCO
                                    inNroMenor = stCARTARCO

                                    ' calcula el porcentaje de diferencia
                                    doPorcentajeCruce = fun_Formato_Decimal_2_Decimales(((inNroMayor * 100) / inNroMenor) - 100)

                                ElseIf CInt(stCARTARCO) > CInt(stFPCOARCO) And CInt(stCARTARCO) <> 0 And CInt(stFPCOARCO) <> 0 Then
                                    ' llenas las variables
                                    inNroMayor = stCARTARCO
                                    inNroMenor = stFPCOARCO

                                    ' calcula el porcentaje de diferencia
                                    doPorcentajeCruce = fun_Formato_Decimal_2_Decimales(((inNroMayor * 100) / inNroMenor) - 100)

                                End If

                                dr1 = dt_CargaCruceAreaDeConstruccion.NewRow()

                                dr1("Nro_Ficha") = stCARTNUFI
                                dr1("Municipio") = stCARTMUNI
                                dr1("Correg") = stCARTCORR
                                dr1("Barrio") = stCARTBARR
                                dr1("Manzana") = stCARTMANZ
                                dr1("Predio") = stCARTPRED
                                dr1("Edificio") = stCARTEDIF
                                dr1("Unidad_Predial") = stCARTUNPR
                                dr1("Sector") = stCARTCLSE
                                dr1("Nro_Cons") = stCARTUNID
                                dr1("Ident") = stCARTTICO
                                dr1("Puntos") = stCARTPUNT
                                dr1("Area_Cons_BD") = stFPCOARCO
                                dr1("Area_Cons_GDB") = stCARTARCO
                                dr1("Porcentaje") = doPorcentajeCruce
                                dr1("Observacion") = "Area con diferencia"

                                dt_CargaCruceAreaDeConstruccion.Rows.Add(dr1)

                                bySW = 1
                                sw1 = 1

                            End If

                            j1 = j1 + 1
                        Else
                            j1 = j1 + 1
                        End If

                    End While

                    ' verifica si encontro el registro
                    If boEncuentraRegistro = False Then

                        dr1 = dt_CargaCruceAreaDeConstruccion.NewRow()

                        dr1("Nro_Ficha") = stCARTNUFI
                        dr1("Municipio") = stCARTMUNI
                        dr1("Correg") = stCARTCORR
                        dr1("Barrio") = stCARTBARR
                        dr1("Manzana") = stCARTMANZ
                        dr1("Predio") = stCARTPRED
                        dr1("Edificio") = stCARTEDIF
                        dr1("Unidad_Predial") = stCARTUNPR
                        dr1("Sector") = stCARTCLSE
                        dr1("Nro_Cons") = stCARTUNID
                        dr1("Ident") = stCARTTICO
                        dr1("Puntos") = stCARTPUNT
                        dr1("Area_Cons_BD") = stFPCOARCO
                        dr1("Area_Cons_GDB") = stCARTARCO
                        dr1("Porcentaje") = "0.00"
                        dr1("Observacion") = "No se encontro la construccion en la BD"

                        dt_CargaCruceAreaDeConstruccion.Rows.Add(dr1)

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbPROCESO.Value = inProceso

                Next

                ' inicia la barra de progreso
                pbPROCESO.Value = 0

                Me.lblFecha2.Visible = False
                'Me.cmdCruceAreasDeTerreno.Enabled = False

                If dt_CargaCruceAreaDeConstruccion.Rows.Count > 0 Then
                    Me.dgvCruceArea.DataSource = dt_CargaCruceAreaDeConstruccion
                    MessageBox.Show("Cruce de registros se genero correctamente", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    MessageBox.Show("Cruce de registros no genero resultado", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

                Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dt_CargaCruceAreaDeConstruccion.Rows.Count

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdAbrirArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivo.Click

        Try
            Me.dgvListadoGeodata.DataSource = New DataTable
            Me.dgvCruceArea.DataSource = New DataTable

            Me.cmdCruceAreasDeConstruccionBDvsGeodata.Enabled = False
            Me.cmdCruceAreasDeConstruccionGeodataVsBD.Enabled = False

            Me.lblFecha2.Visible = False

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

                    Me.dgvListadoGeodata.DataSource = DtSet.Tables(0)

                    Me.lblRutaArchivo.Text = Trim(oLeer.FileName)

                    Me.TabControl1.SelectTab(TabPage2)

                    inTotalRegistrosCartografia = Me.dgvListadoGeodata.RowCount

                    Me.lblCantidadPrediosCartografia.Text = inTotalRegistrosCartografia

                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvListadoGeodata.RowCount

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

                    Me.dgvListadoGeodata.DataSource = DtSet.Tables(0)

                    Me.lblRutaArchivo.Text = Trim(oLeer.FileName)

                    Me.TabControl1.SelectTab(TabPage2)

                    inTotalRegistrosCartografia = Me.dgvListadoGeodata.RowCount

                    Me.lblCantidadPrediosCartografia.Text = inTotalRegistrosCartografia

                    Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvListadoGeodata.RowCount

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
            If Me.rbdFichaPredial.Checked = True Then
                pro_CargaConsultaFichaPredial()
                pro_ControlDeBotones()

            ElseIf Me.rbdFichaResumen.Checked = True Then


            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdValidaDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValidaDatos.Click

        Try
            ' apaga los comandos
            Me.cmdValidaDatos.Enabled = False

            Me.cmdCruceAreasDeConstruccionBDvsGeodata.Enabled = False
            Me.cmdCruceAreasDeConstruccionGeodataVsBD.Enabled = False

            Me.lblFecha2.Visible = False

            If Trim(stRutaArchivoCartografia) <> "" And Me.dgvListadoGeodata.RowCount > 0 Then

                pro_ValidarAreaConstruccionFichaPredial()

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdCruceAreasDeConstruccionBDvsGeodata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCruceAreasDeConstruccionBDvsGeodata.Click

        Try
            ' limpia las tablas
            dt_CargaFichaPredial = New DataTable
            dt_CargaGeodata = New DataTable

            ' llena las tablas
            dt_CargaFichaPredial = Me.dgvListadoFichaPredial.DataSource
            dt_CargaGeodata = Me.dgvListadoGeodata.DataSource

            ' verifica que existan registros
            If dt_CargaFichaPredial.Rows.Count > 0 And dt_CargaGeodata.Rows.Count > 0 Then

                ' Crea objeto registros
                Dim dr1 As DataRow

                ' crea la tabla
                dt_CargaCruceAreaDeConstruccion = New DataTable

                ' Crea las columnas
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Municipio", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Correg", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Barrio", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Manzana", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Predio", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Edificio", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Unidad_Predial", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Sector", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Nro_Cons", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Ident", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Puntos", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Area_Cons_BD", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Area_Cons_GDB", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Porcentaje", GetType(String)))
                dt_CargaCruceAreaDeConstruccion.Columns.Add(New DataColumn("Observacion", GetType(String)))

                ' declaro la variables
                Dim stFIPRNUFI As String = ""
                Dim stFIPRMUNI As String = ""
                Dim stFIPRCORR As String = ""
                Dim stFIPRBARR As String = ""
                Dim stFIPRMANZ As String = ""
                Dim stFIPRPRED As String = ""
                Dim stFIPREDIF As String = ""
                Dim stFIPRUNPR As String = ""
                Dim stFIPRCLSE As String = ""
                Dim stFPCOUNID As String = ""
                Dim stFPCOTICO As String = ""
                Dim stFPCOPUNT As String = ""
                Dim stFPCOARCO As String = ""

                ' declaro la variables
                Dim stCARTNUFI As String = ""
                Dim stCARTMUNI As String = ""
                Dim stCARTCORR As String = ""
                Dim stCARTBARR As String = ""
                Dim stCARTMANZ As String = ""
                Dim stCARTPRED As String = ""
                Dim stCARTEDIF As String = ""
                Dim stCARTUNPR As String = ""
                Dim stCARTCLSE As String = ""
                Dim stCARTUNID As String = ""
                Dim stCARTTICO As String = ""
                Dim stCARTPUNT As String = ""
                Dim stCARTARCO As String = ""

                ' Valores predeterminados ProgressBar
                inProceso = 0
                Me.pbPROCESO.Value = 0
                Me.pbPROCESO.Maximum = dt_CargaGeodata.Rows.Count + 1
                Me.Timer1.Enabled = True

                ' declaro la variable
                Dim i As Integer = 0

                ' recorro la tabla
                For i = 0 To dt_CargaFichaPredial.Rows.Count - 1

                    stFIPRNUFI = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaFichaPredial.Rows(i).Item(0).ToString)), String)
                    stFIPRMUNI = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaFichaPredial.Rows(i).Item(1).ToString)), String)
                    stFIPRCORR = CType(fun_Formato_Mascara_2_Reales(Trim(dt_CargaFichaPredial.Rows(i).Item(2).ToString)), String)
                    stFIPRBARR = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaFichaPredial.Rows(i).Item(3).ToString)), String)
                    stFIPRMANZ = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaFichaPredial.Rows(i).Item(4).ToString)), String)
                    stFIPRPRED = CType(fun_Formato_Mascara_5_Reales(Trim(dt_CargaFichaPredial.Rows(i).Item(5).ToString)), String)
                    stFIPREDIF = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaFichaPredial.Rows(i).Item(6).ToString)), String)
                    stFIPRUNPR = CType(fun_Formato_Mascara_5_Reales(Trim(dt_CargaFichaPredial.Rows(i).Item(7).ToString)), String)
                    stFIPRCLSE = CType(Trim(dt_CargaFichaPredial.Rows(i).Item(8).ToString), String)
                    stFPCOUNID = CType(Trim(dt_CargaFichaPredial.Rows(i).Item(9).ToString), String)
                    stFPCOTICO = CType(Trim(dt_CargaFichaPredial.Rows(i).Item(10).ToString), String)
                    stFPCOPUNT = CType(Trim(dt_CargaFichaPredial.Rows(i).Item(11).ToString), String)
                    stFPCOARCO = CType(Trim(dt_CargaFichaPredial.Rows(i).Item(12).ToString), String)

                    Dim sw1 As Byte = 0
                    Dim j1 As Integer = 0
                    Dim bySW As Byte = 0
                    Dim boEncuentraRegistro As Boolean = False

                    While j1 < dt_CargaGeodata.Rows.Count And sw1 = 0

                        stCARTNUFI = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaGeodata.Rows(j1).Item(0).ToString)), String)
                        stCARTMUNI = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaGeodata.Rows(j1).Item(1).ToString)), String)
                        stCARTCORR = CType(fun_Formato_Mascara_2_Reales(Trim(dt_CargaGeodata.Rows(j1).Item(2).ToString)), String)
                        stCARTBARR = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaGeodata.Rows(j1).Item(3).ToString)), String)
                        stCARTMANZ = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaGeodata.Rows(j1).Item(4).ToString)), String)
                        stCARTPRED = CType(fun_Formato_Mascara_5_Reales(Trim(dt_CargaGeodata.Rows(j1).Item(5).ToString)), String)
                        stCARTEDIF = CType(fun_Formato_Mascara_3_Reales(Trim(dt_CargaGeodata.Rows(j1).Item(6).ToString)), String)
                        stCARTUNPR = CType(fun_Formato_Mascara_5_Reales(Trim(dt_CargaGeodata.Rows(j1).Item(7).ToString)), String)
                        stCARTCLSE = CType(Trim(dt_CargaGeodata.Rows(j1).Item(8).ToString), String)
                        stCARTUNID = CType(Trim(dt_CargaGeodata.Rows(j1).Item(9).ToString), String)
                        stCARTTICO = CType(Trim(dt_CargaGeodata.Rows(j1).Item(10).ToString), String)
                        stCARTPUNT = CType(Trim(dt_CargaGeodata.Rows(j1).Item(11).ToString), String)
                        stCARTARCO = CType(Trim(dt_CargaGeodata.Rows(j1).Item(12).ToString), String)

                        If stFIPRNUFI = stCARTNUFI And _
                           stFIPRMUNI = stCARTMUNI And _
                           stFIPRCORR = stCARTCORR And _
                           stFIPRBARR = stCARTBARR And _
                           stFIPRMANZ = stCARTMANZ And _
                           stFIPRPRED = stCARTPRED And _
                           stFIPREDIF = stCARTEDIF And _
                           stFIPRUNPR = stCARTUNPR And _
                           stFIPRCLSE = stCARTCLSE And _
                           stFPCOUNID = stCARTUNID Then

                            boEncuentraRegistro = True

                            ' verifica el area de terreno
                            If stFPCOARCO = stCARTARCO Then

                                dr1 = dt_CargaCruceAreaDeConstruccion.NewRow()

                                dr1("Nro_Ficha") = stFIPRNUFI
                                dr1("Municipio") = stFIPRMUNI
                                dr1("Correg") = stFIPRCORR
                                dr1("Barrio") = stFIPRBARR
                                dr1("Manzana") = stFIPRMANZ
                                dr1("Predio") = stFIPRPRED
                                dr1("Edificio") = stFIPREDIF
                                dr1("Unidad_Predial") = stFIPRUNPR
                                dr1("Sector") = stFIPRCLSE
                                dr1("Nro_Cons") = stFPCOUNID
                                dr1("Ident") = stFPCOTICO
                                dr1("Puntos") = stFPCOPUNT
                                dr1("Area_Cons_BD") = stFPCOARCO
                                dr1("Area_Cons_GDB") = stCARTARCO
                                dr1("Porcentaje") = "0.00"
                                dr1("Observacion") = "Area sin diferencia"

                                dt_CargaCruceAreaDeConstruccion.Rows.Add(dr1)

                                bySW = 1
                                sw1 = 1

                            Else

                                ' declara las variables
                                Dim inNroMayor As Integer = 0
                                Dim inNroMenor As Integer = 0
                                Dim doPorcentajeCruce As Double = 0.0

                                ' compara las variables
                                If CInt(stFPCOARCO) > CInt(stCARTARCO) And CInt(stCARTARCO) <> 0 And CInt(stFPCOARCO) <> 0 Then

                                    ' llenas las variables
                                    inNroMayor = stFPCOARCO
                                    inNroMenor = stCARTARCO

                                    ' calcula el porcentaje de diferencia
                                    doPorcentajeCruce = fun_Formato_Decimal_2_Decimales(((inNroMayor * 100) / inNroMenor) - 100)

                                ElseIf CInt(stCARTARCO) > CInt(stFPCOARCO) And CInt(stCARTARCO) <> 0 And CInt(stFPCOARCO) <> 0 Then
                                    ' llenas las variables
                                    inNroMayor = stCARTARCO
                                    inNroMenor = stFPCOARCO

                                    ' calcula el porcentaje de diferencia
                                    doPorcentajeCruce = fun_Formato_Decimal_2_Decimales(((inNroMayor * 100) / inNroMenor) - 100)

                                End If

                                dr1 = dt_CargaCruceAreaDeConstruccion.NewRow()

                                dr1("Nro_Ficha") = stFIPRNUFI
                                dr1("Municipio") = stFIPRMUNI
                                dr1("Correg") = stFIPRCORR
                                dr1("Barrio") = stFIPRBARR
                                dr1("Manzana") = stFIPRMANZ
                                dr1("Predio") = stFIPRPRED
                                dr1("Edificio") = stFIPREDIF
                                dr1("Unidad_Predial") = stFIPRUNPR
                                dr1("Sector") = stFIPRCLSE
                                dr1("Nro_Cons") = stFPCOUNID
                                dr1("Ident") = stFPCOTICO
                                dr1("Puntos") = stFPCOPUNT
                                dr1("Area_Cons_BD") = stFPCOARCO
                                dr1("Area_Cons_GDB") = stCARTARCO
                                dr1("Porcentaje") = doPorcentajeCruce
                                dr1("Observacion") = "Area con diferencia"

                                dt_CargaCruceAreaDeConstruccion.Rows.Add(dr1)

                                bySW = 1
                                sw1 = 1

                            End If

                            j1 = j1 + 1
                        Else
                            j1 = j1 + 1
                        End If

                    End While

                    ' verifica si encontro el registro
                    If boEncuentraRegistro = False Then

                        dr1 = dt_CargaCruceAreaDeConstruccion.NewRow()

                        dr1("Nro_Ficha") = stFIPRNUFI
                        dr1("Municipio") = stFIPRMUNI
                        dr1("Correg") = stFIPRCORR
                        dr1("Barrio") = stFIPRBARR
                        dr1("Manzana") = stFIPRMANZ
                        dr1("Predio") = stFIPRPRED
                        dr1("Edificio") = stFIPREDIF
                        dr1("Unidad_Predial") = stFIPRUNPR
                        dr1("Sector") = stFIPRCLSE
                        dr1("Nro_Cons") = stFPCOUNID
                        dr1("Ident") = stFPCOTICO
                        dr1("Puntos") = stFPCOPUNT
                        dr1("Area_Cons_BD") = stFPCOARCO
                        dr1("Area_Cons_GDB") = stCARTARCO
                        dr1("Porcentaje") = "0.00"
                        dr1("Observacion") = "No se encontro la construccion en GDB"

                        dt_CargaCruceAreaDeConstruccion.Rows.Add(dr1)

                    End If

                    ' Incrementa la barra
                    inProceso = inProceso + 1
                    pbPROCESO.Value = inProceso

                Next

                ' inicia la barra de progreso
                pbPROCESO.Value = 0

                Me.lblFecha2.Visible = False
                'Me.cmdCruceAreasDeTerreno.Enabled = False

                If dt_CargaCruceAreaDeConstruccion.Rows.Count > 0 Then
                    Me.dgvCruceArea.DataSource = dt_CargaCruceAreaDeConstruccion
                    MessageBox.Show("Cruce de registros se genero correctamente", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    MessageBox.Show("Cruce de registros no genero resultado", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

                Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dt_CargaCruceAreaDeConstruccion.Rows.Count

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

                If Me.dgvListadoGeodata.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvListadoGeodata.DataSource, DataTable))
                End If

            ElseIf rbdCruceAreaTerreno.Checked = True Then

                If Me.dgvCruceArea.RowCount = 0 Then
                    MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Else
                    Dim oExp As New cla_ExportarTablaExcel
                    oExp.DataTableToExcel(CType(Me.dgvCruceArea.DataSource, DataTable))
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
    Private Sub cmd_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus, cmdAbrirArchivo.GotFocus, cmdConsultarFichaPredial.GotFocus, cmdCruceAreasDeConstruccionBDvsGeodata.GotFocus, cmdExportarExcel.GotFocus, cmdLIMPIAR.GotFocus, cmdCruceAreasDeConstruccionBDvsGeodata.GotFocus
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