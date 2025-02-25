Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_importar_excel_AREATERR

    '=================================================
    '*** FORMULARIO IMPORTAR EXCEL AREA DE TERRENO ***
    '=================================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_importar_excel_AREATERR
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_importar_excel_AREATERR
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

    Dim oLeer As New OpenFileDialog

    ' crea los objetos datatable
    Dim dt_CONSULTA As New DataTable
    Dim dt_ARTELIST As New DataTable

    ' otros procesos
    Dim stRutaArchivo As String
    Dim stSeparador As String
    Dim inTotalRegistros As Integer
    Dim stRESOLUCION As String
    Dim inProceso As Integer

    ' variable contador de registros totales
    Dim a As Integer

    ' variables de conexion
    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

    Private dt1 As New DataTable
    Private dt2 As New DataTable

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.dgvFIPRLIST.DataSource = New DataTable

        Me.lblRUTA.Text = ""
        Me.strBARRESTA.Items(2).Text = "Registros: 0"

        Me.cmdValidaDatos.Enabled = False
        Me.cmdGrabarDatos.Enabled = False
        Me.lblFecha2.Visible = False

        Me.strBARRESTA.Items(2).Text = "Registro : 0"


    End Sub
    Private Sub pro_ValidarAreaTerrenoFichaPredialCedulaCatastral()

        ' limpia los datagrigview
        Me.dgvFIPRINCO.DataSource = New DataTable

        ' Valores predeterminados ProgressBar
        inProceso = 0
        pbPROCESO.Value = 0
        pbPROCESO.Maximum = inTotalRegistros + 1
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
        dt_ARTELIST = New DataTable

        ' carga la tabla
        dt_ARTELIST = Me.dgvFIPRLIST.DataSource

        For i = 0 To dt_ARTELIST.Rows.Count - 1

            ' verifica que el campo Municipio
            If Trim(dt_ARTELIST.Rows(i).Item(0).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Municipio") = "El campo Municipio esta vacio"
                dr1("Corregi") = Trim(dt_ARTELIST.Rows(i).Item(1).ToString)
                dr1("Barrio") = Trim(dt_ARTELIST.Rows(i).Item(2).ToString)
                dr1("Manzana") = Trim(dt_ARTELIST.Rows(i).Item(3).ToString)
                dr1("Predio") = Trim(dt_ARTELIST.Rows(i).Item(4).ToString)
                dr1("Sector") = Trim(dt_ARTELIST.Rows(i).Item(5).ToString)
                dr1("Area") = Trim(dt_ARTELIST.Rows(i).Item(6).ToString)

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo Corregimiento
            If Trim(dt_ARTELIST.Rows(i).Item(1).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Municipio") = Trim(dt_ARTELIST.Rows(i).Item(0).ToString)
                dr1("Corregi") = "El campo Corregimiento esta vacio"
                dr1("Barrio") = Trim(dt_ARTELIST.Rows(i).Item(2).ToString)
                dr1("Manzana") = Trim(dt_ARTELIST.Rows(i).Item(3).ToString)
                dr1("Predio") = Trim(dt_ARTELIST.Rows(i).Item(4).ToString)
                dr1("Sector") = Trim(dt_ARTELIST.Rows(i).Item(5).ToString)
                dr1("Area") = Trim(dt_ARTELIST.Rows(i).Item(6).ToString)

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo Barrio
            If Trim(dt_ARTELIST.Rows(i).Item(2).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Municipio") = Trim(dt_ARTELIST.Rows(i).Item(0).ToString)
                dr1("Corregi") = Trim(dt_ARTELIST.Rows(i).Item(1).ToString)
                dr1("Barrio") = "El campo Barrio esta vacio"
                dr1("Manzana") = Trim(dt_ARTELIST.Rows(i).Item(3).ToString)
                dr1("Predio") = Trim(dt_ARTELIST.Rows(i).Item(4).ToString)
                dr1("Sector") = Trim(dt_ARTELIST.Rows(i).Item(5).ToString)
                dr1("Area") = Trim(dt_ARTELIST.Rows(i).Item(6).ToString)

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo Manzana
            If Trim(dt_ARTELIST.Rows(i).Item(3).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Municipio") = Trim(dt_ARTELIST.Rows(i).Item(0).ToString)
                dr1("Corregi") = Trim(dt_ARTELIST.Rows(i).Item(1).ToString)
                dr1("Barrio") = Trim(dt_ARTELIST.Rows(i).Item(2).ToString)
                dr1("Manzana") = "El campo Manzana esta vacio"
                dr1("Predio") = Trim(dt_ARTELIST.Rows(i).Item(4).ToString)
                dr1("Sector") = Trim(dt_ARTELIST.Rows(i).Item(5).ToString)
                dr1("Area") = Trim(dt_ARTELIST.Rows(i).Item(6).ToString)

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo Predio
            If Trim(dt_ARTELIST.Rows(i).Item(4).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Municipio") = Trim(dt_ARTELIST.Rows(i).Item(0).ToString)
                dr1("Corregi") = Trim(dt_ARTELIST.Rows(i).Item(1).ToString)
                dr1("Barrio") = Trim(dt_ARTELIST.Rows(i).Item(2).ToString)
                dr1("Manzana") = Trim(dt_ARTELIST.Rows(i).Item(3).ToString)
                dr1("Predio") = "El campo Predio esta vacio"
                dr1("Sector") = Trim(dt_ARTELIST.Rows(i).Item(5).ToString)
                dr1("Area") = Trim(dt_ARTELIST.Rows(i).Item(6).ToString)

                dt1.Rows.Add(dr1)

            End If

            ' verifica que el campo Sector
            If Trim(dt_ARTELIST.Rows(i).Item(5).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Municipio") = Trim(dt_ARTELIST.Rows(i).Item(0).ToString)
                dr1("Corregi") = Trim(dt_ARTELIST.Rows(i).Item(1).ToString)
                dr1("Barrio") = Trim(dt_ARTELIST.Rows(i).Item(2).ToString)
                dr1("Manzana") = Trim(dt_ARTELIST.Rows(i).Item(3).ToString)
                dr1("Predio") = Trim(dt_ARTELIST.Rows(i).Item(4).ToString)
                dr1("Sector") = "El campo Sector esta vacio"
                dr1("Area") = Trim(dt_ARTELIST.Rows(i).Item(6).ToString)

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_ARTELIST.Rows(i).Item(5).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Municipio") = Trim(dt_ARTELIST.Rows(i).Item(0).ToString)
                    dr1("Corregi") = Trim(dt_ARTELIST.Rows(i).Item(1).ToString)
                    dr1("Barrio") = Trim(dt_ARTELIST.Rows(i).Item(2).ToString)
                    dr1("Manzana") = Trim(dt_ARTELIST.Rows(i).Item(3).ToString)
                    dr1("Predio") = Trim(dt_ARTELIST.Rows(i).Item(4).ToString)
                    dr1("Sector") = "El campo Sector no es numerico"
                    dr1("Area") = Trim(dt_ARTELIST.Rows(i).Item(6).ToString)

                    dt1.Rows.Add(dr1)

                Else

                    Dim objdatos22 As New cla_CLASSECT
                    Dim tbl22 As New DataTable

                    tbl22 = objdatos22.fun_Buscar_CODIGO_MANT_CLASSECT(Trim(dt_ARTELIST.Rows(i).Item(5).ToString))

                    If tbl22.Rows.Count = 0 Then

                        dr1 = dt1.NewRow()

                        dr1("Municipio") = Trim(dt_ARTELIST.Rows(i).Item(0).ToString)
                        dr1("Corregi") = Trim(dt_ARTELIST.Rows(i).Item(1).ToString)
                        dr1("Barrio") = Trim(dt_ARTELIST.Rows(i).Item(2).ToString)
                        dr1("Manzana") = Trim(dt_ARTELIST.Rows(i).Item(3).ToString)
                        dr1("Predio") = Trim(dt_ARTELIST.Rows(i).Item(4).ToString)
                        dr1("Sector") = "El campo Sector no existe"
                        dr1("Area") = Trim(dt_ARTELIST.Rows(i).Item(6).ToString)

                        dt1.Rows.Add(dr1)

                    End If

                End If

            End If

            ' verifica que el campo area de terreno
            If Trim(dt_ARTELIST.Rows(i).Item(6).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Municipio") = Trim(dt_ARTELIST.Rows(i).Item(0).ToString)
                dr1("Corregi") = Trim(dt_ARTELIST.Rows(i).Item(1).ToString)
                dr1("Barrio") = Trim(dt_ARTELIST.Rows(i).Item(2).ToString)
                dr1("Manzana") = Trim(dt_ARTELIST.Rows(i).Item(3).ToString)
                dr1("Predio") = Trim(dt_ARTELIST.Rows(i).Item(4).ToString)
                dr1("Sector") = Trim(dt_ARTELIST.Rows(i).Item(5).ToString)
                dr1("Area") = "El campo Area de Terreno esta vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_ARTELIST.Rows(i).Item(6).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Municipio") = Trim(dt_ARTELIST.Rows(i).Item(0).ToString)
                    dr1("Corregi") = Trim(dt_ARTELIST.Rows(i).Item(1).ToString)
                    dr1("Barrio") = Trim(dt_ARTELIST.Rows(i).Item(2).ToString)
                    dr1("Manzana") = Trim(dt_ARTELIST.Rows(i).Item(3).ToString)
                    dr1("Predio") = Trim(dt_ARTELIST.Rows(i).Item(4).ToString)
                    dr1("Sector") = Trim(dt_ARTELIST.Rows(i).Item(5).ToString)
                    dr1("Area") = "El campo Area de Terreno no es numerico"

                    dt1.Rows.Add(dr1)

                End If

            End If


            ' Incrementa la barra
            inProceso = inProceso + 1
            pbPROCESO.Value = inProceso

        Next

        ' Llena el datagrigview
        TabControl1.SelectTab(TabPage2)
        Me.dgvFIPRINCO.DataSource = dt1
        pbPROCESO.Value = 0

        ' comando grabar datos
        If dt1.Rows.Count = 0 Then
            Me.cmdGrabarDatos.Enabled = True
            Me.lblFecha2.Visible = True
            Me.cmdValidaDatos.Enabled = False
            Me.cmdGrabarDatos.Focus()
            MessageBox.Show("Proceso de validación terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Me.cmdValidaDatos.Enabled = True
            MessageBox.Show("Proceso de validación inconsistente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

        Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRLIST.RowCount

    End Sub
    Private Sub pro_ValidarAreaTerrenoFichaPredialNroFichaPredial()

        ' limpia los datagrigview
        Me.dgvFIPRINCO.DataSource = New DataTable

        ' Valores predeterminados ProgressBar
        inProceso = 0
        pbPROCESO.Value = 0
        pbPROCESO.Maximum = inTotalRegistros + 1
        Timer1.Enabled = True

        ' Crea objeto de columnas y registros
        Dim dt1 As New DataTable
        Dim dr1 As DataRow

        ' Crea las columnas
        dt1.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
        dt1.Columns.Add(New DataColumn("Area", GetType(String)))

        ' crea la variable
        Dim i As Integer = 0

        ' crea la tabla
        dt_ARTELIST = New DataTable

        ' carga la tabla
        dt_ARTELIST = Me.dgvFIPRLIST.DataSource

        For i = 0 To dt_ARTELIST.Rows.Count - 1

            ' verifica que el campo Nro ficha predial
            If Trim(dt_ARTELIST.Rows(i).Item(0).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = "El campo Nro de ficha esta vacio"
                dr1("Area") = Trim(dt_ARTELIST.Rows(i).Item(1).ToString)

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_ARTELIST.Rows(i).Item(0).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Nro_Ficha") = "El campo Nro de ficha no es numerico"
                    dr1("Area") = Trim(dt_ARTELIST.Rows(i).Item(1).ToString)

                    dt1.Rows.Add(dr1)

                End If

            End If

            ' verifica que el campo area de terreno
            If Trim(dt_ARTELIST.Rows(i).Item(1).ToString) = "" Then

                dr1 = dt1.NewRow()

                dr1("Nro_Ficha") = Trim(dt_ARTELIST.Rows(i).Item(0).ToString)
                dr1("Area") = "El campo Area de Terreno esta vacio"

                dt1.Rows.Add(dr1)

            Else

                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_ARTELIST.Rows(i).Item(1).ToString)) = False Then

                    dr1 = dt1.NewRow()

                    dr1("Nro_Ficha") = Trim(dt_ARTELIST.Rows(i).Item(0).ToString)
                    dr1("Area") = "El campo Area de Terreno no es numerico"

                    dt1.Rows.Add(dr1)

                End If

            End If


            ' Incrementa la barra
            inProceso = inProceso + 1
            pbPROCESO.Value = inProceso

        Next

        ' Llena el datagrigview
        TabControl1.SelectTab(TabPage2)
        Me.dgvFIPRINCO.DataSource = dt1
        pbPROCESO.Value = 0

        ' comando grabar datos
        If dt1.Rows.Count = 0 Then
            Me.cmdGrabarDatos.Enabled = True
            Me.lblFecha2.Visible = True
            Me.cmdValidaDatos.Enabled = False
            Me.cmdGrabarDatos.Focus()
            MessageBox.Show("Proceso de validación terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Else
            Me.cmdValidaDatos.Enabled = True
            MessageBox.Show("Proceso de validación inconsistente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If

        Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRLIST.RowCount

    End Sub
    Private Sub pro_GuardarAreaTerrenoFichaPredialCedulaCatastral()

        Try
            ' apaga el boton grabar datos
            Me.cmdGrabarDatos.Enabled = False

            ' Valores predeterminados ProgressBar
            inProceso = 0
            pbPROCESO.Value = 0
            pbPROCESO.Maximum = inTotalRegistros + 1
            Timer1.Enabled = True

            ' declara la variable
            Dim i As Integer = 0

            ' crea la tabla
            dt_ARTELIST = New DataTable

            ' declara las variables
            Dim stARTEMUNI As String = ""
            Dim stARTECORR As String = ""
            Dim stARTEBARR As String = ""
            Dim stARTEMANZ As String = ""
            Dim stARTEPRED As String = ""
            Dim stARTECLSE As String = ""
            Dim stARTEARTE As String = ""

            ' carga la tabla
            dt_ARTELIST = Me.dgvFIPRLIST.DataSource

            For i = 0 To dt_ARTELIST.Rows.Count - 1

                ' almacena los datos
                stARTEMUNI = CType(fun_Formato_Mascara_3_Reales(Trim(dt_ARTELIST.Rows(i).Item(0).ToString)), String)
                stARTECORR = CType(fun_Formato_Mascara_2_Reales(Trim(dt_ARTELIST.Rows(i).Item(1).ToString)), String)
                stARTEBARR = CType(fun_Formato_Mascara_3_Reales(Trim(dt_ARTELIST.Rows(i).Item(2).ToString)), String)
                stARTEMANZ = CType(fun_Formato_Mascara_3_Reales(Trim(dt_ARTELIST.Rows(i).Item(3).ToString)), String)
                stARTEPRED = CType(fun_Formato_Mascara_5_Reales(Trim(dt_ARTELIST.Rows(i).Item(4).ToString)), String)

                stARTECLSE = CType(Trim(dt_ARTELIST.Rows(i).Item(5).ToString), String)
                stARTEARTE = CType(Trim(dt_ARTELIST.Rows(i).Item(6).ToString), String)

                ' buscar cadena de conexion
                Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

                ' crea el datatable
                dt1 = New DataTable

                ' crear conexión
                oAdapter = New SqlDataAdapter
                oConexion = New SqlConnection(stCadenaConexion1)

                ' abre la conexion
                oConexion.Open()

                ' parametros de la consulta
                Dim ParametrosConsulta1 As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta1 += "Select "
                ParametrosConsulta1 += "FiprNufi, FiprCapr "
                ParametrosConsulta1 += "From FichPred where "
                ParametrosConsulta1 += "(exists(select 1 from fiprcons where fiprnufi = fpconufi and fpcomejo = 0 and fpcoesta = 'ac') or not exists(select 1 from fiprcons where fiprnufi = fpconufi)) and "
                ParametrosConsulta1 += "FiprMuni = '" & stARTEMUNI & "' and "
                ParametrosConsulta1 += "FiprCorr = '" & stARTECORR & "' and "
                ParametrosConsulta1 += "FiprBarr = '" & stARTEBARR & "' and "
                ParametrosConsulta1 += "FiprManz = '" & stARTEMANZ & "' and "
                ParametrosConsulta1 += "FiprPred = '" & stARTEPRED & "' and "
                ParametrosConsulta1 += "FiprClse = '" & stARTECLSE & "' and "
                ParametrosConsulta1 += "FiprTifi = '" & "0" & "' and "
                ParametrosConsulta1 += "FiprEsta = '" & "ac" & "' "

                ' ejecuta la consulta
                oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

                ' procesa la consulta 
                oEjecutar.CommandTimeout = 0
                oEjecutar.CommandType = CommandType.Text
                oAdapter.SelectCommand = oEjecutar

                ' llena el datatable 
                oAdapter.Fill(dt1)

                ' cierra la conexion
                oConexion.Close()

                ' verifica que exista al registro
                If dt1.Rows.Count > 0 Then

                    ' verifica que no sea predio en reglamento
                    If CInt(dt1.Rows(0).Item("FiprCapr")) = 1 Or CInt(dt1.Rows(0).Item("FiprCapr")) = 6 Or CInt(dt1.Rows(0).Item("FiprCapr")) = 7 Then

                        ' buscar cadena de conexion
                        Dim oCadenaConexion2 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion2 As String = oCadenaConexion2.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion2)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta2 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta2 += "update FICHPRED "
                        ParametrosConsulta2 += "set FIPRARTE = '" & stARTEARTE & "' "
                        ParametrosConsulta2 += "where "
                        ParametrosConsulta2 += "(exists(select 1 from fiprcons where fiprnufi = fpconufi and fpcomejo = 0 and fpcoesta = 'ac') or not exists(select 1 from fiprcons where fiprnufi = fpconufi)) and "
                        ParametrosConsulta2 += "FiprMuni = '" & stARTEMUNI & "' and "
                        ParametrosConsulta2 += "FiprCorr = '" & stARTECORR & "' and "
                        ParametrosConsulta2 += "FiprBarr = '" & stARTEBARR & "' and "
                        ParametrosConsulta2 += "FiprManz = '" & stARTEMANZ & "' and "
                        ParametrosConsulta2 += "FiprPred = '" & stARTEPRED & "' and "
                        ParametrosConsulta2 += "FiprClse = '" & stARTECLSE & "' and "
                        ParametrosConsulta2 += "FiprTifi = '" & "0" & "' and "
                        ParametrosConsulta2 += "FiprEsta = 'ac' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        ' predio en reglamento
                    ElseIf CInt(dt1.Rows(0).Item("FiprCapr")) = 2 Or CInt(dt1.Rows(0).Item("FiprCapr")) = 3 Then

                        ' buscar cadena de conexion
                        Dim oCadenaConexion2 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion2 As String = oCadenaConexion2.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion2)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta2 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta2 += "update FICHPRED "
                        ParametrosConsulta2 += "set FIPRATLO = '" & stARTEARTE & "' "
                        ParametrosConsulta2 += "where "
                        ParametrosConsulta2 += "(exists(select 1 from fiprcons where fiprnufi = fpconufi and fpcomejo = 0 and fpcoesta = 'ac') or not exists(select 1 from fiprcons where fiprnufi = fpconufi)) and "
                        ParametrosConsulta2 += "FiprMuni = '" & stARTEMUNI & "' and "
                        ParametrosConsulta2 += "FiprCorr = '" & stARTECORR & "' and "
                        ParametrosConsulta2 += "FiprBarr = '" & stARTEBARR & "' and "
                        ParametrosConsulta2 += "FiprManz = '" & stARTEMANZ & "' and "
                        ParametrosConsulta2 += "FiprPred = '" & stARTEPRED & "' and "
                        ParametrosConsulta2 += "FiprClse = '" & stARTECLSE & "' and "
                        ParametrosConsulta2 += "FiprTifi = '" & "2" & "' and "
                        ParametrosConsulta2 += "FiprEsta = 'ac' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        If Me.chkCalcularAreaFichaResumen.Checked = True Then

                            ' instancia la clase
                            Dim obFICHRESU As New cla_FICHRESU
                            Dim dtFICHRESU As New DataTable

                            dtFICHRESU = obFICHRESU.fun_Consultar_FICHA_RESUMEN_x_CEDULA(stARTEMUNI, stARTECLSE, stARTECORR, stARTEBARR, stARTEMANZ, stARTEPRED, "2")

                            If dtFICHRESU.Rows.Count > 0 Then

                                ' calcula el área total y generales
                                fun_Calcular_Total_Generales_Ficha_Resumen(dtFICHRESU.Rows(0).Item("FIPRNUFI").ToString)

                            End If

                        End If

                        ' verifica el predio en condominio
                    ElseIf CInt(dt1.Rows(0).Item("FiprCapr")) = 4 Then

                        ' buscar cadena de conexion
                        Dim oCadenaConexion2 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                        Dim stCadenaConexion2 As String = oCadenaConexion2.fun_ConnectionString

                        ' crear conexión
                        oAdapter = New SqlDataAdapter
                        oConexion = New SqlConnection(stCadenaConexion2)

                        ' abre la conexion
                        oConexion.Open()

                        ' parametros de la consulta
                        Dim ParametrosConsulta2 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta2 += "update FICHPRED "
                        ParametrosConsulta2 += "set FIPRATLO = '" & stARTEARTE & "' "
                        ParametrosConsulta2 += "where "
                        ParametrosConsulta2 += "(exists(select 1 from fiprcons where fiprnufi = fpconufi and fpcomejo = 0 and fpcoesta = 'ac') or not exists(select 1 from fiprcons where fiprnufi = fpconufi)) and "
                        ParametrosConsulta2 += "FiprMuni = '" & stARTEMUNI & "' and "
                        ParametrosConsulta2 += "FiprCorr = '" & stARTECORR & "' and "
                        ParametrosConsulta2 += "FiprBarr = '" & stARTEBARR & "' and "
                        ParametrosConsulta2 += "FiprManz = '" & stARTEMANZ & "' and "
                        ParametrosConsulta2 += "FiprPred = '" & stARTEPRED & "' and "
                        ParametrosConsulta2 += "FiprClse = '" & stARTECLSE & "' and "
                        ParametrosConsulta2 += "FiprTifi = '" & "1" & "' and "
                        ParametrosConsulta2 += "FiprEsta = 'ac' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 0
                        oEjecutar.CommandType = CommandType.Text

                        oReader = oEjecutar.ExecuteReader

                        ' cierra la conexion
                        oConexion.Close()
                        oReader = Nothing

                        If Me.chkCalcularAreaFichaResumen.Checked = True Then

                            ' instancia la clase
                            Dim obFICHRESU As New cla_FICHRESU
                            Dim dtFICHRESU As New DataTable

                            dtFICHRESU = obFICHRESU.fun_Consultar_FICHA_RESUMEN_x_CEDULA(stARTEMUNI, stARTECLSE, stARTECORR, stARTEBARR, stARTEMANZ, stARTEPRED, "1")

                            If dtFICHRESU.Rows.Count > 0 Then

                                ' calcula el área total y generales
                                fun_Calcular_Total_Generales_Ficha_Resumen(dtFICHRESU.Rows(0).Item("FIPRNUFI").ToString)

                            End If

                        End If

                    End If

                End If

                ' Incrementa la barra
                inProceso = inProceso + 1
                pbPROCESO.Value = inProceso

            Next

            ' Llena el datagrigview
            TabControl1.SelectTab(TabPage1)
            pbPROCESO.Value = 0

            ' comando grabar datos
            MessageBox.Show("Proceso de guardado terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            Me.cmdGrabarDatos.Enabled = False
            Me.lblFecha2.Visible = False
            Me.cmdValidaDatos.Enabled = False

            Me.cmdAbrirArchivo.Focus()

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRLIST.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GuardarAreaTerrenoFichaPredialNroFichaPredial()

        Try
            ' apaga el boton grabar datos
            Me.cmdGrabarDatos.Enabled = False

            ' Valores predeterminados ProgressBar
            inProceso = 0
            pbPROCESO.Value = 0
            pbPROCESO.Maximum = inTotalRegistros + 1
            Timer1.Enabled = True

            ' declara la variable
            Dim i As Integer = 0

            ' crea la tabla
            dt_ARTELIST = New DataTable

            ' declara las variables
            Dim stARTENUFI As String = ""
            Dim stARTEARTE As String = ""

            ' carga la tabla
            dt_ARTELIST = Me.dgvFIPRLIST.DataSource

            For i = 0 To dt_ARTELIST.Rows.Count - 1

                ' almacena los datos
                stARTENUFI = CType(Trim(dt_ARTELIST.Rows(i).Item(0).ToString), String)
                stARTEARTE = CType(Trim(dt_ARTELIST.Rows(i).Item(1).ToString), String)

                ' buscar cadena de conexion
                Dim oCadenaConexion1 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                Dim stCadenaConexion1 As String = oCadenaConexion1.fun_ConnectionString

                ' crea el datatable
                dt1 = New DataTable

                ' crear conexión
                oAdapter = New SqlDataAdapter
                oConexion = New SqlConnection(stCadenaConexion1)

                ' abre la conexion
                oConexion.Open()

                ' parametros de la consulta
                Dim ParametrosConsulta1 As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta1 += "Select "
                ParametrosConsulta1 += "FiprNufi "
                ParametrosConsulta1 += "From FichPred where "
                ParametrosConsulta1 += "FiprNufi = '" & stARTENUFI & "' and "
                ParametrosConsulta1 += "FiprTifi = '" & "0" & "' and "
                ParametrosConsulta1 += "FiprEsta = '" & "ac" & "' "

                ' ejecuta la consulta
                oEjecutar = New SqlCommand(ParametrosConsulta1, oConexion)

                ' procesa la consulta 
                oEjecutar.CommandTimeout = 0
                oEjecutar.CommandType = CommandType.Text
                oAdapter.SelectCommand = oEjecutar

                ' llena el datatable 
                oAdapter.Fill(dt1)

                ' cierra la conexion
                oConexion.Close()

                ' verifica que exista al registro
                If dt1.Rows.Count > 0 Then

                    ' buscar cadena de conexion
                    Dim oCadenaConexion2 As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                    Dim stCadenaConexion2 As String = oCadenaConexion2.fun_ConnectionString

                    ' crear conexión
                    oAdapter = New SqlDataAdapter
                    oConexion = New SqlConnection(stCadenaConexion2)

                    ' abre la conexion
                    oConexion.Open()

                    ' parametros de la consulta
                    Dim ParametrosConsulta2 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta2 += "update FICHPRED "
                    ParametrosConsulta2 += "set FIPRARTE = '" & stARTEARTE & "' "
                    ParametrosConsulta2 += "where "
                    ParametrosConsulta2 += "FiprNufi = '" & stARTENUFI & "' and "
                    ParametrosConsulta2 += "FiprTifi = '" & "0" & "' and "
                    ParametrosConsulta2 += "FiprEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 0
                    oEjecutar.CommandType = CommandType.Text

                    oReader = oEjecutar.ExecuteReader

                    ' cierra la conexion
                    oConexion.Close()
                    oReader = Nothing

                End If

                ' Incrementa la barra
                inProceso = inProceso + 1
                pbPROCESO.Value = inProceso

            Next

            ' Llena el datagrigview
            TabControl1.SelectTab(TabPage1)
            pbPROCESO.Value = 0

            ' comando grabar datos
            MessageBox.Show("Proceso de guardado terminado correctamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            Me.cmdGrabarDatos.Enabled = False
            Me.lblFecha2.Visible = False
            Me.cmdValidaDatos.Enabled = False

            Me.cmdAbrirArchivo.Focus()

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRLIST.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ExportarPlano(ByVal dtl As DataTable)
        Try
            Me.dgvFIPRLIST.DataSource = dtl

            If dgvFIPRLIST.RowCount > 0 Then

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

                        With dgvFIPRLIST
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
                    Me.cmdExportarPlano.Focus()
                End If
            Else
                MessageBox.Show("Ejecute la consulta antes de exportar el plano", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub



#End Region

#Region "MENU"

    Private Sub cmdAbrirArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivo.Click

        Try
            ' declara variable
            inTotalRegistros = 0

            ' apaga los comandos
            Me.cmdValidaDatos.Enabled = False
            Me.cmdGrabarDatos.Enabled = False

            pro_LimpiarCampos()

            Me.lblFecha2.Visible = False

            ' enruta el archivo
            oLeer.InitialDirectory = "C:\Documents and Settings\Estudiante\Mis documentos"
            oLeer.Filter = "Archivo de texto (*.xls)|*.xls" 'Colocar varias extensiones
            oLeer.FilterIndex = 1 'coloca por defecto el *.txt
            oLeer.FileName = ""
            oLeer.ShowDialog()

            stRutaArchivo = Trim(oLeer.FileName)
            Me.lblRUTA.Text = Trim(oLeer.FileName)

            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim DtSet As System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

            MyConnection = New System.Data.OleDb.OleDbConnection _
            ("provider=Microsoft.Jet.OLEDB.4.0;" & _
            " Data Source='" & stRutaArchivo & "'; " & _
             "Extended Properties=Excel 8.0;")

            Dim stNombreLibro As String = InputBox("Ingrese el nombre de la hoja de excel", "Mensaje")

            If Trim(stNombreLibro) <> "" Then

                MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & stNombreLibro & "$]", MyConnection)

                MyCommand.TableMappings.Add("Table", "TestTable")
                DtSet = New System.Data.DataSet
                MyCommand.Fill(DtSet)
                Me.dgvFIPRLIST.DataSource = DtSet.Tables(0)

                MyConnection.Close()

            Else
                stNombreLibro = InputBox("Ingrese el nombre de la hoja de excel", "Mensaje")
            End If

            ' verifica que exista registros
            If Me.dgvFIPRLIST.RowCount > 0 Then
                Me.cmdValidaDatos.Enabled = True
                inTotalRegistros = Me.dgvFIPRLIST.RowCount
            Else
                Me.cmdValidaDatos.Enabled = False
            End If

            TabControl1.SelectTab(TabPage1)

            Me.strBARRESTA.Items(2).Text = "Registros : " & Me.dgvFIPRLIST.RowCount

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdValidaDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValidaDatos.Click
        Try
            ' apaga los comandos
            Me.cmdValidaDatos.Enabled = False
            Me.cmdGrabarDatos.Enabled = False

            Me.lblFecha2.Visible = False

            If Trim(stRutaArchivo) <> "" And Me.dgvFIPRLIST.RowCount > 0 Then

                If Me.rbdImportarCedulaCatastral.Checked = True Then
                    pro_ValidarAreaTerrenoFichaPredialCedulaCatastral()

                ElseIf Me.rbdImportarFichaPredial.Checked = True Then
                    pro_ValidarAreaTerrenoFichaPredialNroFichaPredial()

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdGrabarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabarDatos.Click

        Try
            If Me.dgvFIPRINCO.RowCount = 0 Then
                If Trim(stRutaArchivo) <> "" Then

                    If Me.rbdImportarCedulaCatastral.Checked = True Then
                        pro_GuardarAreaTerrenoFichaPredialCedulaCatastral()

                    ElseIf Me.rbdImportarFichaPredial.Checked = True Then
                        pro_GuardarAreaTerrenoFichaPredialNroFichaPredial()

                    End If


                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error al guardar los datos, revise la integridad del archivo", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End Try

    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        Try
            ' exporta ficha predial
            If Me.dgvFIPRLIST.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvFIPRLIST.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdExportarPlano_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.Click

        Try
            If Me.dgvFIPRLIST.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                pro_ExportarPlano(Me.dgvFIPRLIST.DataSource)
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
    End Sub
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_importar_planos_FICHA_PREDIAL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.strBARRESTA.Items(0).Text = "Importar planos"
        Me.strBARRESTA.Items(2).Text = "Registros: 0"
    End Sub

#End Region

#Region "GotFocus"

    Private Sub cmdAbrirArchivo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAbrirArchivo.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdAbrirArchivo.AccessibleDescription
    End Sub
    Private Sub cmdValidaDatos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdValidaDatos.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdValidaDatos.AccessibleDescription
    End Sub
    Private Sub cmdGrabarDatos_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdGrabarDatos.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdGrabarDatos.AccessibleDescription
    End Sub
    Private Sub cmdExportarExcel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdExportarExcel.AccessibleDescription
    End Sub
    Private Sub cmdExportarPlano_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdExportarPlano.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        Me.strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub dgvFIPRINCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFIPRLIST.GotFocus
        Me.strBARRESTA.Items(0).Text = dgvFIPRLIST.AccessibleDescription
    End Sub
    Private Sub dgvFIREINCO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.strBARRESTA.Items(0).Text = dgvFIPRINCO.AccessibleDescription
    End Sub

#End Region

#Region "CheckedChanged"

    Private Sub rbdImportarCedulaCatastral_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdImportarCedulaCatastral.CheckedChanged, rbdImportarFichaPredial.CheckedChanged

        If Me.rbdImportarCedulaCatastral.Checked = True Then
            Me.chkCalcularAreaFichaResumen.Visible = True
        Else
            Me.chkCalcularAreaFichaResumen.Visible = False
        End If

        If Me.rbdImportarFichaPredial.Checked = True Then
            Me.chkCalcularAreaFichaResumen.Visible = False
        Else
            Me.chkCalcularAreaFichaResumen.Visible = True
        End If

    End Sub

#End Region

#End Region

End Class