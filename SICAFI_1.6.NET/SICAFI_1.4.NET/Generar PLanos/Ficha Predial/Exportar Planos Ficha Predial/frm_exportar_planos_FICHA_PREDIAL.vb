Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Public Class frm_exportar_planos_FICHA_PREDIAL

    '=====================================================================
    '*** FORMULARIO IMPORTAR Y EXPORTAR PLANOS FICHA PREDIAL Y RESUMEN ***
    '=====================================================================

#Region "CONSTRUCTOR"

    Public Sub New(ByVal idRegistro As Integer)
        vp_inConsulta = idRegistro
        InitializeComponent()
    End Sub

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_exportar_planos_FICHA_PREDIAL
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_exportar_planos_FICHA_PREDIAL
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

#Region "VARIABLES LOCALES"

    ' variables de conexion
    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable
    Private dt_FR_1_Y_2 As New DataTable
    Private dt_FR_1 As New DataTable
    Private dt_FR_2 As New DataTable
    Private dtSumaTerreno As New DataTable
    Private dtSumaConstruccion As New DataTable
    Private dtSumaPuntosCalificacion As New DataTable

    Private oCrear As New SaveFileDialog

    ' variables de instacia
    Private objResolucion As New cla_RESOLUCION
    Private objFichaPredial As New cla_FICHPRED
    Private objDestino As New cla_FIPRDEEC
    Private objPropietarios As New cla_FIPRPROP
    Private objConstruccion As New cla_FIPRCONS
    Private objCalificacion As New cla_FIPRCACO
    Private objLinderos As New cla_FIPRLIND
    Private objCartografia As New cla_FIPRCART

    ' variables de datatable
    Private tblResolucion As New DataTable
    Private tblFichaPredial As New DataTable
    Private tblDestino As New DataTable
    Private tblPropietarios As New DataTable
    Private tblConstruccion As New DataTable
    Private tblCalificacion As New DataTable
    Private tblLinderos As New DataTable
    Private tblCartografia As New DataTable

    ' variable ruta
    Private stRutaArchivoActualizacion As String = ""
    Private stRutaArchivoAdministrativa As String = ""
    Private stRutaArchivoParametrizada As String = ""

    ' variable progressBar
    Private inProceso As Integer

    ' crea datatable
    Private dt_FICHPRED As New DataTable
    Private dt_FIPRDEEC As New DataTable
    Private dt_FIPRPROP As New DataTable
    Private dt_FIPRCONS As New DataTable
    Private dt_FIPRCACO As New DataTable
    Private dt_FIPRLIND As New DataTable
    Private dt_FIPRCART As New DataTable

    ' instancia la clase
    Private objCedula As New cla_FICHPRED
    Private tblCedula As New DataTable

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_ExportarPlanoFichaPredialActualizacion()

        Try
            ' verifica si se a seleccionado una resolución
            If Me.txtREACRESO.Text = "" Then
                MessageBox.Show("Seleccione una resolución", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                ' verifica la ruta del acchivo
                If Trim(stRutaArchivoActualizacion) <> "" Then

                    ' recorre el archivo a exportar
                    FileOpen(1, oCrear.FileName, OpenMode.Output) 'crea y destruye si hay otro igual

                    ' variable separador
                    Dim stSeparador As String = Trim(Me.txtSEPARADOR.Text)

                    ' apaga el boton
                    Me.cmdExportarPlanoActualizacion.Enabled = False

                    '==========================
                    '*** GENERA LA CONSULTA ***
                    '==========================

                    ' crea un datable
                    dt = New DataTable

                    ' llena el datatable con la consulta
                    dt = fun_EjecutarConsultaFichaPredialActualizacion()

                    '============================
                    '*** CUENTA LOS REGISTROS ***
                    '============================

                    Dim objdatos As New cla_VALIFIPR
                    Dim ds As New DataSet

                    ds = objdatos.fun_Consultar_NRO_REGISTROS_DE_EXPORTACION(Me.txtREACDEPA.Text, Me.txtREACMUNI.Text, Me.txtREACTIRE.Text, Me.txtREACCLSE.Text, Me.txtREACVIGE.Text, Val(Me.txtREACRESO.Text))

                    ' crea nuevos datatable
                    dt_FICHPRED = New DataTable
                    dt_FIPRDEEC = New DataTable
                    dt_FIPRPROP = New DataTable
                    dt_FIPRCONS = New DataTable
                    dt_FIPRCACO = New DataTable
                    dt_FIPRLIND = New DataTable
                    dt_FIPRCART = New DataTable

                    ' almacena la información
                    dt_FICHPRED = ds.Tables(0)
                    dt_FIPRDEEC = ds.Tables(1)
                    dt_FIPRPROP = ds.Tables(2)
                    dt_FIPRCONS = ds.Tables(3)
                    dt_FIPRCACO = ds.Tables(4)
                    dt_FIPRLIND = ds.Tables(5)
                    dt_FIPRCART = ds.Tables(6)

                    ' cuenta los registros
                    Dim in_Nro_Registros_FICHPRED As Integer = dt_FICHPRED.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRDEEC As Integer = dt_FIPRDEEC.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRPROP As Integer = dt_FIPRPROP.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRCONS As Integer = dt_FIPRCONS.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRCACO As Integer = dt_FIPRCACO.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRLIND As Integer = dt_FIPRLIND.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRCART As Integer = dt_FIPRCART.Rows(0).Item(0)

                    'inProceso = 0
                    'Me.pbProcesoActualizacion.Value = 0
                    'Me.pbProcesoActualizacion.Maximum = in_Nro_Registros_FICHPRED + in_Nro_Registros_FIPRDEEC + in_Nro_Registros_FIPRPROP + in_Nro_Registros_FIPRCONS + in_Nro_Registros_FIPRCACO + in_Nro_Registros_FIPRLIND + in_Nro_Registros_FIPRCART
                    'Me.Timer1.Enabled = True

                    '==========================
                    '*** EXPORTA RESOLUCIÓN ***
                    '==========================

                    ' numero de registros
                    Dim vl_stRESONURE As String = CType(in_Nro_Registros_FICHPRED + in_Nro_Registros_FIPRDEEC + in_Nro_Registros_FIPRPROP + in_Nro_Registros_FIPRCONS + in_Nro_Registros_FIPRCACO + in_Nro_Registros_FIPRLIND + in_Nro_Registros_FIPRCART + 1, String)

                    ' área de terreno total
                    Dim vl_stRESOARTE As String = CType(fun_Formato_Decimal_4_Decimales((fun_SumaAreaDeTerreno() / 10000)), String)

                    ' suma de puntos de calificación
                    Dim vl_stRESOPUNT As String = CType(fun_SumaPuntosDeCalificacion(), String)

                    ' área de construcción total
                    Dim vl_stRESOARCO As String = CType(fun_Formato_Decimal_2_Decimales(fun_Suma_Area_De_Construccion(dt)), String)

                    ' buscar cadena de conexion
                    Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                    Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                    ' crear conexión
                    oAdapter = New SqlDataAdapter
                    oConexion = New SqlConnection(stCadenaConexion)

                    ' abre la conexion
                    oConexion.Open()

                    ' parametros de la consulta
                    Dim ParametrosConsulta As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta += "update RESOLUCION "
                    ParametrosConsulta += "set RESONURE = '" & vl_stRESONURE & "', "
                    ParametrosConsulta += "RESOARTE = '" & vl_stRESOARTE & "', "
                    ParametrosConsulta += "RESOARCO = '" & vl_stRESOARCO & "', "
                    ParametrosConsulta += "RESOPUNT = '" & vl_stRESOPUNT & "' "

                    ParametrosConsulta += "where RESODEPA = '" & Trim(Me.txtREACDEPA.Text) & "' AND "
                    ParametrosConsulta += "RESOMUNI = '" & Trim(Me.txtREACMUNI.Text) & "' AND "
                    ParametrosConsulta += "RESOTIRE = '" & Trim(Me.txtREACTIRE.Text) & "' AND "
                    ParametrosConsulta += "RESOCLSE = '" & Trim(Me.txtREACCLSE.Text) & "' AND "
                    ParametrosConsulta += "RESOVIGE = '" & Trim(Me.txtREACVIGE.Text) & "' AND "
                    ParametrosConsulta += "RESOCODI = '" & Trim(Me.txtREACRESO.Text) & "' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 0
                    oEjecutar.CommandType = CommandType.Text

                    oReader = oEjecutar.ExecuteReader

                    ' cierra la conexion
                    oConexion.Close()
                    oReader = Nothing

                    '==================
                    '*** RESOLUCIÓN ***
                    '==================

                    ' crea la tabla 
                    tblResolucion = New DataTable

                    ' almacena la consulta
                    tblResolucion = objResolucion.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_TIPO_Y_CLASE_Y_VIGENCIA_Y_CODIGO_RESOLUCION(txtREACDEPA.Text, txtREACMUNI.Text, txtREACTIRE.Text, txtREACCLSE.Text, txtREACVIGE.Text, txtREACRESO.Text)

                    ' variales directas
                    Dim stRESOIDRE As String = "1"
                    Dim stRESOVIGE As String = tblResolucion.Rows(0).Item("RESOVIGE").ToString
                    Dim stRESOTIRE As String = tblResolucion.Rows(0).Item("RESOTIRE").ToString
                    Dim stRESORESO As String = tblResolucion.Rows(0).Item("RESOCODI").ToString
                    Dim stRESOMUNI As String = tblResolucion.Rows(0).Item("RESOMUNI").ToString
                    Dim stRESOCLSE As String = tblResolucion.Rows(0).Item("RESOCLSE").ToString
                    Dim stRESONURE As String = vl_stRESONURE
                    Dim stRESOARTE As String = vl_stRESOARTE
                    Dim stRESOARCO As String = vl_stRESOARCO
                    Dim stRESOSUPU As String = vl_stRESOPUNT
                    Dim boRESOTOPA As Boolean = tblResolucion.Rows(0).Item("RESOTOPA").ToString

                    ' variables indirectas
                    Dim stRESOTOPA As String = ""

                    ' parcial o total
                    If boRESOTOPA = False Then
                        stRESOTOPA = 2
                    Else
                        stRESOTOPA = 1
                    End If

                    ' formato vigencia
                    stRESOVIGE = stRESOVIGE.PadLeft(4, "0")
                    stRESOVIGE = stRESOVIGE.Substring(0, 4)

                    ' formato tipo de resolución
                    stRESOTIRE = stRESOTIRE.PadLeft(3, "0")
                    stRESOTIRE = stRESOTIRE.Substring(0, 3)

                    ' formato resolución
                    stRESORESO = stRESORESO.PadLeft(7, "0")
                    stRESORESO = stRESORESO.Substring(0, 7)

                    ' formato municipio
                    stRESOMUNI = stRESOMUNI.PadLeft(3, "0")
                    stRESOMUNI = stRESOMUNI.Substring(0, 3)

                    ' formato clase o sector
                    stRESOCLSE = stRESOCLSE.PadLeft(1, "0")
                    stRESOCLSE = stRESOCLSE.Substring(0, 1)

                    ' formato numero de registro
                    stRESONURE = stRESONURE.PadLeft(7, "0")
                    stRESONURE = stRESONURE.Substring(0, 7)

                    ' formato área de terreno
                    stRESOARTE = stRESOARTE.Replace(".", "")
                    stRESOARTE = stRESOARTE.PadLeft(12, "0")
                    stRESOARTE = stRESOARTE.Substring(0, 12)

                    ' formato área de construcción
                    stRESOARCO = stRESOARCO.Replace(".", "")
                    stRESOARCO = stRESOARCO.PadLeft(10, "0")
                    stRESOARCO = stRESOARCO.Substring(0, 10)

                    ' formato suma de puntos
                    stRESOSUPU = stRESOSUPU.PadLeft(10, "0")
                    stRESOSUPU = stRESOSUPU.Substring(0, 10)

                    ' formato parcial o total
                    stRESOTOPA = stRESOTOPA.PadLeft(1, "0")
                    stRESOTOPA = stRESOTOPA.Substring(0, 1)

                    ' exportar los datos
                    PrintLine(1, stRESOIDRE & stSeparador & _
                                 stRESOVIGE & stSeparador & _
                                 stRESOTIRE & stSeparador & _
                                 stRESORESO & stSeparador & _
                                 stRESOMUNI & stSeparador & _
                                 stRESOCLSE & stSeparador & _
                                 stRESONURE & stSeparador & _
                                 stRESOARTE & stSeparador & _
                                 stRESOARCO & stSeparador & _
                                 stRESOSUPU & stSeparador & _
                                 stRESOTOPA)


                    ' recorre la consulta
                    If dt.Rows.Count > 0 Then

                        ' carga la barra de progreso
                        inProceso = 0
                        pbProcesoActualizacion.Value = 0
                        pbProcesoActualizacion.Maximum = dt.Rows.Count
                        Timer1.Enabled = True

                        '=============================
                        '*** EXPORTA FICHA PREDIAL ***
                        '=============================

                        Dim i As Integer = 0

                        For i = 0 To dt.Rows.Count - 1

                            ' crea la tabla
                            tblFichaPredial = New DataTable

                            ' almacena consulta
                            tblFichaPredial = objFichaPredial.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dt.Rows(i).Item("FIPRNUFI"))

                            ' variables directas
                            Dim stFIPRIDRE As String = "2"
                            Dim stFIPRVIGE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRVIGE").ToString)
                            Dim stFIPRTIRE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRTIRE").ToString)
                            Dim stFIPRRESO As String = Trim(tblFichaPredial.Rows(0).Item("FIPRRESO").ToString)
                            Dim stFIPRNUFI As String = Trim(tblFichaPredial.Rows(0).Item("FIPRNUFI").ToString)
                            Dim stFIPRNURE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRNURE").ToString)
                            Dim stFIPRMUNI As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMUNI").ToString)
                            Dim stFIPRCLSE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCLSE").ToString)
                            Dim stFIPRCORR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCORR").ToString)
                            Dim stFIPRBARR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRBARR").ToString)
                            Dim stFIPRMANZ As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMANZ").ToString)
                            Dim stFIPRPRED As String = Trim(tblFichaPredial.Rows(0).Item("FIPRPRED").ToString)
                            Dim stFIPREDIF As String = Trim(tblFichaPredial.Rows(0).Item("FIPREDIF").ToString)
                            Dim stFIPRUNPR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRUNPR").ToString)
                            Dim stFIPRARTE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRARTE").ToString)
                            Dim stFIPRDIRE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRDIRE").ToString)
                            Dim stFIPRCAPR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCAPR").ToString)
                            Dim stFIPRCASU As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCASU").ToString)
                            Dim stFIPRCOPR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCOPR").ToString)
                            Dim stFIPRCOED As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCOED").ToString)
                            Dim stFIPRMUAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMUAN").ToString)
                            Dim stFIPRCSAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCSAN").ToString)
                            Dim stFIPRCOAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCOAN").ToString)
                            Dim stFIPRBAAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRBAAN").ToString)
                            Dim stFIPRMAAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMAAN").ToString)
                            Dim stFIPRPRAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRPRAN").ToString)
                            Dim stFIPREDAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPREDAN").ToString)
                            Dim stFIPRUPAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRUPAN").ToString)
                            Dim stFIPRCASA As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCASA").ToString)

                            ' formato vigencia
                            stFIPRVIGE = stFIPRVIGE.PadLeft(4, "0")
                            stFIPRVIGE = stFIPRVIGE.Substring(0, 4)

                            ' formato tipo de resolución
                            stFIPRTIRE = stFIPRTIRE.PadLeft(3, "0")
                            stFIPRTIRE = stFIPRTIRE.Substring(0, 3)

                            ' formato resolución
                            stFIPRRESO = stFIPRRESO.PadLeft(7, "0")
                            stFIPRRESO = stFIPRRESO.Substring(0, 7)

                            ' formato numero de ficha
                            stFIPRNUFI = stFIPRNUFI.PadLeft(9, "0")
                            stFIPRNUFI = stFIPRNUFI.Substring(0, 9)

                            ' formato numero de registro
                            stFIPRNURE = stFIPRNURE.PadLeft(5, "0")
                            stFIPRNURE = stFIPRNURE.Substring(0, 5)

                            ' formato municipio actual
                            stFIPRMUNI = stFIPRMUNI.PadLeft(3, "0")
                            stFIPRMUNI = stFIPRMUNI.Substring(0, 3)

                            ' formato clase o sector actual
                            stFIPRCLSE = stFIPRCLSE.PadLeft(1, "0")
                            stFIPRCLSE = stFIPRCLSE.Substring(0, 1)

                            ' formato corregimiento actual
                            stFIPRCORR = stFIPRCORR.PadLeft(3, "0")
                            stFIPRCORR = stFIPRCORR.Substring(0, 3)

                            ' formato barrio actual
                            stFIPRBARR = stFIPRBARR.PadLeft(3, "0")
                            stFIPRBARR = stFIPRBARR.Substring(0, 3)

                            ' formato manzana actual
                            stFIPRMANZ = stFIPRMANZ.PadLeft(3, "0")
                            stFIPRMANZ = stFIPRMANZ.Substring(0, 3)

                            ' formato predio actual
                            stFIPRPRED = stFIPRPRED.PadLeft(5, "0")
                            stFIPRPRED = stFIPRPRED.Substring(0, 5)

                            ' formato edificio actual
                            stFIPREDIF = stFIPREDIF.PadLeft(5, "0")
                            stFIPREDIF = stFIPREDIF.Substring(0, 5)

                            ' formato unidad predial actual
                            stFIPRUNPR = stFIPRUNPR.PadLeft(5, "0")
                            stFIPRUNPR = stFIPRUNPR.Substring(0, 5)

                            ' formato área de terreno
                            stFIPRARTE = stFIPRARTE.PadLeft(10, "0")
                            stFIPRARTE = stFIPRARTE.Substring(0, 10)

                            ' formato dirección
                            stFIPRDIRE = stFIPRDIRE.PadRight(49, " ")
                            stFIPRDIRE = stFIPRDIRE.Substring(0, 49)

                            ' formato caracteristica de predio
                            stFIPRCAPR = stFIPRCAPR.PadLeft(1, "0")
                            stFIPRCAPR = stFIPRCAPR.Substring(0, 1)

                            ' formato categoria de suelo
                            stFIPRCASU = stFIPRCASU.PadLeft(1, "0")
                            stFIPRCASU = stFIPRCASU.Substring(0, 1)

                            ' formato coeficiente de predio
                            stFIPRCOPR = stFIPRCOPR.Replace(".", "")
                            stFIPRCOPR = stFIPRCOPR.PadLeft(9, "0")
                            stFIPRCOPR = stFIPRCOPR.Substring(0, 9)

                            ' formato coeficiente de edificio
                            stFIPRCOED = stFIPRCOED.Replace(".", "")
                            stFIPRCOED = stFIPRCOED.PadLeft(9, "0")
                            stFIPRCOED = stFIPRCOED.Substring(0, 9)

                            ' formato municipio anterior
                            stFIPRMUAN = stFIPRMUAN.PadLeft(3, "0")
                            stFIPRMUAN = stFIPRMUAN.Substring(0, 3)

                            ' formato clase o sector anterior
                            stFIPRCSAN = stFIPRCSAN.PadLeft(1, "0")
                            stFIPRCSAN = stFIPRCSAN.Substring(0, 1)

                            ' formato corregimiento anterior
                            stFIPRCOAN = stFIPRCOAN.PadLeft(3, "0")
                            stFIPRCOAN = stFIPRCOAN.Substring(0, 3)

                            ' formato barrio anterior
                            stFIPRBAAN = stFIPRBAAN.PadLeft(3, "0")
                            stFIPRBAAN = stFIPRBAAN.Substring(0, 3)

                            ' formato manzana anterior
                            stFIPRMAAN = stFIPRMAAN.PadLeft(3, "0")
                            stFIPRMAAN = stFIPRMAAN.Substring(0, 3)

                            ' formato predio anterior
                            stFIPRPRAN = stFIPRPRAN.PadLeft(5, "0")
                            stFIPRPRAN = stFIPRPRAN.Substring(0, 5)

                            ' formato edificio anterior
                            stFIPREDAN = stFIPREDAN.PadLeft(5, "0")
                            stFIPREDAN = stFIPREDAN.Substring(0, 5)

                            ' formato unidad predial anterior
                            stFIPRUPAN = stFIPRUPAN.PadLeft(5, "0")
                            stFIPRUPAN = stFIPRUPAN.Substring(0, 5)

                            ' formato clasificador de suelo anterior
                            stFIPRCASA = stFIPRCASA.PadLeft(1, "0")
                            stFIPRCASA = stFIPRCASA.Substring(0, 1)

                            ' exportar los datos
                            PrintLine(1, stFIPRIDRE & stSeparador & _
                                         stFIPRVIGE & stSeparador & _
                                         stFIPRTIRE & stSeparador & _
                                         stFIPRRESO & stSeparador & _
                                         stFIPRNUFI & stSeparador & _
                                         stFIPRNURE & stSeparador & _
                                         stFIPRMUNI & stSeparador & _
                                         stFIPRCLSE & stSeparador & _
                                         stFIPRCORR & stSeparador & _
                                         stFIPRBARR & stSeparador & _
                                         stFIPRMANZ & stSeparador & _
                                         stFIPRPRED & stSeparador & _
                                         stFIPREDIF & stSeparador & _
                                         stFIPRUNPR & stSeparador & _
                                         stFIPRARTE & stSeparador & _
                                         stFIPRDIRE & stSeparador & _
                                         stFIPRCAPR & stSeparador & _
                                         stFIPRCASU & stSeparador & _
                                         stFIPRCOPR & stSeparador & _
                                         stFIPRCOED & stSeparador & _
                                         stFIPRMUAN & stSeparador & _
                                         stFIPRCSAN & stSeparador & _
                                         stFIPRCOAN & stSeparador & _
                                         stFIPRBAAN & stSeparador & _
                                         stFIPRMAAN & stSeparador & _
                                         stFIPRPRAN & stSeparador & _
                                         stFIPREDAN & stSeparador & _
                                         stFIPRUPAN & stSeparador & _
                                         stFIPRCASA)

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbProcesoActualizacion.Value = inProceso

                        Next

                        ' limpia la barra de progreso
                        pbProcesoActualizacion.Value = 0

                        '=====================================
                        '*** EXPORTA DESTINACIÓN ECONÓMICA ***
                        '=====================================

                        ' carga la barra de progreso
                        inProceso = 0
                        pbProcesoActualizacion.Value = 0
                        pbProcesoActualizacion.Maximum = dt.Rows.Count
                        Timer1.Enabled = True

                        Dim k As Integer = 0

                        For k = 0 To dt.Rows.Count - 1

                            ' crea la tabla
                            tblDestino = New DataTable

                            ' almacena consulta
                            tblDestino = objDestino.fun_Consultar_FIPRDEEC_X_FICHA_PREDIAL(dt.Rows(k).Item("FIPRNUFI"))

                            Dim a As Integer = 0

                            For a = 0 To tblDestino.Rows.Count - 1

                                ' verifica que se encuentre activa
                                If Trim(tblDestino.Rows(a).Item("FPDEESTA").ToString) = "ac" Then

                                    ' variables directas
                                    Dim stFPDEIDRE As String = "3"
                                    Dim stFPDEVIGE As String = Trim(tblDestino.Rows(a).Item("FPDEVIGE").ToString)
                                    Dim stFPDETIRE As String = Trim(tblDestino.Rows(a).Item("FPDETIRE").ToString)
                                    Dim stFPDERESO As String = Trim(tblDestino.Rows(a).Item("FPDERESO").ToString)
                                    Dim stFPDENUFI As String = Trim(tblDestino.Rows(a).Item("FPDENUFI").ToString)
                                    Dim stFPDENURE As String = Trim(tblDestino.Rows(a).Item("FPDENURE").ToString)
                                    Dim stFPDEDEEC As String = Trim(tblDestino.Rows(a).Item("FPDEDEEC").ToString)
                                    Dim stFPDEPORC As String = Trim(tblDestino.Rows(a).Item("FPDEPORC").ToString)

                                    ' formato vigencia
                                    stFPDEVIGE = stFPDEVIGE.PadLeft(4, "0")
                                    stFPDEVIGE = stFPDEVIGE.Substring(0, 4)

                                    ' formato tipo de resolución
                                    stFPDETIRE = stFPDETIRE.PadLeft(3, "0")
                                    stFPDETIRE = stFPDETIRE.Substring(0, 3)

                                    ' formato resolución
                                    stFPDERESO = stFPDERESO.PadLeft(7, "0")
                                    stFPDERESO = stFPDERESO.Substring(0, 7)

                                    ' formato numero de ficha
                                    stFPDENUFI = stFPDENUFI.PadLeft(9, "0")
                                    stFPDENUFI = stFPDENUFI.Substring(0, 9)

                                    ' formato numero de registro
                                    stFPDENURE = stFPDENURE.PadLeft(5, "0")
                                    stFPDENURE = stFPDENURE.Substring(0, 5)

                                    ' formato destinación
                                    stFPDEDEEC = stFPDEDEEC.PadLeft(2, "0")
                                    stFPDEDEEC = stFPDEDEEC.Substring(0, 2)

                                    ' formato porcentaje
                                    stFPDEPORC = stFPDEPORC.PadLeft(3, "0")
                                    stFPDEPORC = stFPDEPORC.Substring(0, 3)

                                    ' exportar los datos
                                    PrintLine(1, stFPDEIDRE & stSeparador & _
                                                 stFPDEVIGE & stSeparador & _
                                                 stFPDETIRE & stSeparador & _
                                                 stFPDERESO & stSeparador & _
                                                 stFPDENUFI & stSeparador & _
                                                 stFPDENURE & stSeparador & _
                                                 stFPDEDEEC & stSeparador & _
                                                 stFPDEPORC)

                                End If

                            Next

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbProcesoActualizacion.Value = inProceso

                        Next

                        ' limpia la barra de progreso
                        pbProcesoActualizacion.Value = 0

                        '============================
                        '*** EXPORTA PROPIETARIOS ***
                        '============================

                        ' carga la barra de progreso
                        inProceso = 0
                        pbProcesoActualizacion.Value = 0
                        pbProcesoActualizacion.Maximum = dt.Rows.Count
                        Timer1.Enabled = True

                        Dim j As Integer = 0

                        For j = 0 To dt.Rows.Count - 1

                            ' crea la tabla
                            tblPropietarios = New DataTable

                            ' almacena consulta
                            tblPropietarios = objPropietarios.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(dt.Rows(j).Item("FIPRNUFI"))

                            Dim b As Integer = 0

                            For b = 0 To tblPropietarios.Rows.Count - 1

                                ' verifica que se encuentre activa
                                If Trim(tblPropietarios.Rows(b).Item("FPPRESTA").ToString) = "ac" Then

                                    ' variables directas
                                    Dim stFPPRIDRE As String = "4"
                                    Dim stFPPRVIGE As String = Trim(tblPropietarios.Rows(b).Item("FPPRVIGE").ToString)
                                    Dim stFPPRTIRE As String = Trim(tblPropietarios.Rows(b).Item("FPPRTIRE").ToString)
                                    Dim stFPPRRESO As String = Trim(tblPropietarios.Rows(b).Item("FPPRRESO").ToString)
                                    Dim stFPPRNUFI As String = Trim(tblPropietarios.Rows(b).Item("FPPRNUFI").ToString)
                                    Dim stFPPRNURE As String = Trim(tblPropietarios.Rows(b).Item("FPPRNURE").ToString)
                                    Dim stFPPRTIDO As String = Trim(tblPropietarios.Rows(b).Item("FPPRTIDO").ToString)
                                    Dim stFPPRNUDO As String = Trim(tblPropietarios.Rows(b).Item("FPPRNUDO").ToString)
                                    Dim stFPPRPRAP As String = Trim(tblPropietarios.Rows(b).Item("FPPRPRAP").ToString)
                                    Dim stFPPRNOMB As String = Trim(tblPropietarios.Rows(b).Item("FPPRNOMB").ToString)
                                    Dim stFPPRDERE As String = Trim(tblPropietarios.Rows(b).Item("FPPRDERE").ToString)
                                    Dim stFPPRNOTA As String = Trim(tblPropietarios.Rows(b).Item("FPPRDENO").ToString) & Trim(tblPropietarios.Rows(b).Item("FPPRMUNO").ToString) & Trim(tblPropietarios.Rows(b).Item("FPPRNOTA").ToString)
                                    Dim stFPPRESCR As String = Trim(tblPropietarios.Rows(b).Item("FPPRESCR").ToString)
                                    Dim stFPPRFEES As String = Trim(tblPropietarios.Rows(b).Item("FPPRFEES").ToString)
                                    Dim stFPPRFERE As String = Trim(tblPropietarios.Rows(b).Item("FPPRFERE").ToString)
                                    Dim stFPPRTOMO As String = Trim(tblPropietarios.Rows(b).Item("FPPRTOMO").ToString)
                                    Dim stFPPRMAIN As String = Trim(tblPropietarios.Rows(b).Item("FPPRMAIN").ToString)
                                    Dim stFPPRCAPR As String = Trim(tblPropietarios.Rows(b).Item("FPPRCAPR").ToString)
                                    Dim boFPPRGRAV As Boolean = tblPropietarios.Rows(b).Item("FPPRGRAV").ToString
                                    Dim stFPPRMOAD As String = Trim(tblPropietarios.Rows(b).Item("FPPRMOAD").ToString)
                                    Dim boFPPRLITI As Boolean = tblPropietarios.Rows(b).Item("FPPRLITI").ToString
                                    Dim stFPPRPOLI As String = Trim(tblPropietarios.Rows(b).Item("FPPRPOLI").ToString)
                                    Dim stFPPRSEAP As String = Trim(tblPropietarios.Rows(b).Item("FPPRSEAP").ToString)
                                    Dim stFPPRSICO As String = Trim(tblPropietarios.Rows(b).Item("FPPRSICO").ToString)
                                    Dim stFPPRSEXO As String = Trim(tblPropietarios.Rows(b).Item("FPPRSEXO").ToString)

                                    If Not IsDate(stFPPRFEES) Then
                                        stFPPRFEES = "          "
                                    End If

                                    If Not IsDate(stFPPRFERE) Then
                                        stFPPRFERE = "          "
                                    End If

                                    ' variables indirectas
                                    Dim stFPPRGRAV As String = ""
                                    Dim stFPPRLITI As String = ""

                                    ' litigio
                                    If boFPPRLITI = False Then
                                        stFPPRLITI = 2
                                    Else
                                        stFPPRLITI = 1
                                    End If

                                    ' gravable
                                    If boFPPRGRAV = False Then
                                        stFPPRGRAV = 2
                                    Else
                                        stFPPRGRAV = 1
                                    End If

                                    ' tipo de documento
                                    If stFPPRTIDO = 8 And Me.chkGenerarCodigoAsignado.Checked = False Then
                                        stFPPRNUDO = ""
                                    End If

                                    ' formato vigencia
                                    stFPPRVIGE = stFPPRVIGE.PadLeft(4, "0")
                                    stFPPRVIGE = stFPPRVIGE.Substring(0, 4)

                                    ' formato tipo de resolución
                                    stFPPRTIRE = stFPPRTIRE.PadLeft(3, "0")
                                    stFPPRTIRE = stFPPRTIRE.Substring(0, 3)

                                    ' formato resolución
                                    stFPPRRESO = stFPPRRESO.PadLeft(7, "0")
                                    stFPPRRESO = stFPPRRESO.Substring(0, 7)

                                    ' formato numero de ficha
                                    stFPPRNUFI = stFPPRNUFI.PadLeft(9, "0")
                                    stFPPRNUFI = stFPPRNUFI.Substring(0, 9)

                                    ' formato numero de registro
                                    stFPPRNURE = stFPPRNURE.PadLeft(5, "0")
                                    stFPPRNURE = stFPPRNURE.Substring(0, 5)

                                    ' formato tipo de documento
                                    stFPPRTIDO = stFPPRTIDO.PadLeft(2, "0")
                                    stFPPRTIDO = stFPPRTIDO.Substring(0, 2)

                                    ' formato numero de documento
                                    stFPPRNUDO = stFPPRNUDO.PadRight(14, " ")
                                    stFPPRNUDO = stFPPRNUDO.Substring(0, 14)

                                    ' formato primer apellido
                                    stFPPRPRAP = stFPPRPRAP.PadRight(15, " ")
                                    stFPPRPRAP = stFPPRPRAP.Substring(0, 15)

                                    ' formato nombre
                                    stFPPRNOMB = stFPPRNOMB.PadRight(20, " ")
                                    stFPPRNOMB = stFPPRNOMB.Substring(0, 20)

                                    ' formato derecho
                                    stFPPRDERE = stFPPRDERE.Replace(".", "")
                                    stFPPRDERE = stFPPRDERE.PadLeft(9, "0")
                                    stFPPRDERE = stFPPRDERE.Substring(0, 9)

                                    ' formato notaria
                                    stFPPRNOTA = stFPPRNOTA.PadRight(10, " ")
                                    stFPPRNOTA = stFPPRNOTA.Substring(0, 10)

                                    ' formato escritura
                                    stFPPRESCR = stFPPRESCR.PadLeft(7, "0")
                                    stFPPRESCR = stFPPRESCR.Substring(0, 7)

                                    ' formato fecha de escritura
                                    stFPPRFEES = stFPPRFEES.PadRight(10, " ")
                                    stFPPRFEES = stFPPRFEES.Substring(0, 10)

                                    ' formato fecha de registro
                                    stFPPRFERE = stFPPRFERE.PadRight(10, " ")
                                    stFPPRFERE = stFPPRFERE.Substring(0, 10)

                                    ' formato tomo
                                    stFPPRTOMO = stFPPRTOMO.PadLeft(3, "0")
                                    stFPPRTOMO = stFPPRTOMO.Substring(0, 3)

                                    ' formato matricula inmobiliaria
                                    stFPPRMAIN = stFPPRMAIN.PadRight(15, " ")
                                    stFPPRMAIN = stFPPRMAIN.Substring(0, 15)

                                    ' formato calidad de propietario
                                    stFPPRCAPR = stFPPRCAPR.PadLeft(2, "0")
                                    stFPPRCAPR = stFPPRCAPR.Substring(0, 2)

                                    ' formato gravable
                                    stFPPRGRAV = stFPPRGRAV.PadLeft(1, "0")
                                    stFPPRGRAV = stFPPRGRAV.Substring(0, 1)

                                    ' formato modo de adquisición
                                    stFPPRMOAD = stFPPRMOAD.PadLeft(1, "0")
                                    stFPPRMOAD = stFPPRMOAD.Substring(0, 1)

                                    ' formato litigio
                                    stFPPRLITI = stFPPRLITI.PadLeft(1, "0")
                                    stFPPRLITI = stFPPRLITI.Substring(0, 1)

                                    ' formato porcentaje de litigio
                                    stFPPRPOLI = stFPPRPOLI.Replace(".", "")
                                    stFPPRPOLI = stFPPRPOLI.PadLeft(5, "0")
                                    stFPPRPOLI = stFPPRPOLI.Substring(0, 5)

                                    ' formato segundo apellido
                                    stFPPRSEAP = stFPPRSEAP.PadRight(15, " ")
                                    stFPPRSEAP = stFPPRSEAP.Substring(0, 15)

                                    ' formato sigla comercial
                                    stFPPRSICO = stFPPRSICO.PadRight(20, " ")
                                    stFPPRSICO = stFPPRSICO.Substring(0, 20)

                                    ' formato sexo
                                    stFPPRSEXO = stFPPRSEXO.PadLeft(1, "0")
                                    stFPPRSEXO = stFPPRSEXO.Substring(0, 1)

                                    ' exportar los datos
                                    PrintLine(1, stFPPRIDRE & stSeparador & _
                                                 stFPPRVIGE & stSeparador & _
                                                 stFPPRTIRE & stSeparador & _
                                                 stFPPRRESO & stSeparador & _
                                                 stFPPRNUFI & stSeparador & _
                                                 stFPPRNURE & stSeparador & _
                                                 stFPPRTIDO & stSeparador & _
                                                 stFPPRNUDO & stSeparador & _
                                                 stFPPRPRAP & stSeparador & _
                                                 stFPPRNOMB & stSeparador & _
                                                 stFPPRDERE & stSeparador & _
                                                 stFPPRNOTA & stSeparador & _
                                                 stFPPRESCR & stSeparador & _
                                                 stFPPRFEES & stSeparador & _
                                                 stFPPRFERE & stSeparador & _
                                                 stFPPRTOMO & stSeparador & _
                                                 stFPPRMAIN & stSeparador & _
                                                 stFPPRCAPR & stSeparador & _
                                                 stFPPRGRAV & stSeparador & _
                                                 stFPPRMOAD & stSeparador & _
                                                 stFPPRLITI & stSeparador & _
                                                 stFPPRPOLI & stSeparador & _
                                                 stFPPRSEAP & stSeparador & _
                                                 stFPPRSICO & stSeparador & _
                                                 stFPPRSEXO)

                                End If

                            Next

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbProcesoActualizacion.Value = inProceso

                        Next

                        ' limpia la barra de progreso
                        pbProcesoActualizacion.Value = 0

                        '============================
                        '*** EXPORTA CONSTRUCCIÓN ***
                        '============================

                        ' carga la barra de progreso
                        inProceso = 0
                        pbProcesoActualizacion.Value = 0
                        pbProcesoActualizacion.Maximum = dt.Rows.Count
                        Timer1.Enabled = True

                        Dim h As Integer = 0

                        For h = 0 To dt.Rows.Count - 1

                            ' crea la tabla
                            tblConstruccion = New DataTable

                            ' almacena consulta
                            tblConstruccion = objConstruccion.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(dt.Rows(h).Item("FIPRNUFI"))

                            Dim c As Integer = 0

                            For c = 0 To tblConstruccion.Rows.Count - 1

                                ' verifica que se encuentre activa
                                If Trim(tblConstruccion.Rows(c).Item("FPCOESTA").ToString) = "ac" Then

                                    ' variables directas
                                    Dim stFPCOIDRE As String = "5"
                                    Dim stFPCOVIGE As String = Trim(tblConstruccion.Rows(c).Item("FPCOVIGE").ToString)
                                    Dim stFPCOTIRE As String = Trim(tblConstruccion.Rows(c).Item("FPCOTIRE").ToString)
                                    Dim stFPCORESO As String = Trim(tblConstruccion.Rows(c).Item("FPCORESO").ToString)
                                    Dim stFPCONUFI As String = Trim(tblConstruccion.Rows(c).Item("FPCONUFI").ToString)
                                    Dim stFPCONURE As String = Trim(tblConstruccion.Rows(c).Item("FPCONURE").ToString)
                                    Dim stFPCOUNID As String = Trim(tblConstruccion.Rows(c).Item("FPCOUNID").ToString)
                                    Dim stFPCOPUNT As String = Trim(tblConstruccion.Rows(c).Item("FPCOPUNT").ToString)
                                    Dim stFPCOARCO As String = Trim(tblConstruccion.Rows(c).Item("FPCOARCO").ToString)
                                    Dim boFPCOMEJO As Boolean = tblConstruccion.Rows(c).Item("FPCOMEJO").ToString
                                    Dim boFPCOLEY As Boolean = tblConstruccion.Rows(c).Item("FPCOLEY").ToString
                                    Dim stFPCOTICO As String = fun_Quita_Letras(Trim(tblConstruccion.Rows(c).Item("FPCOTICO").ToString))
                                    Dim stFPCOACUE As String = Trim(tblConstruccion.Rows(c).Item("FPCOACUE").ToString)
                                    Dim stFPCOTELE As String = Trim(tblConstruccion.Rows(c).Item("FPCOTELE").ToString)
                                    Dim stFPCOALCA As String = Trim(tblConstruccion.Rows(c).Item("FPCOALCA").ToString)
                                    Dim stFPCOENER As String = Trim(tblConstruccion.Rows(c).Item("FPCOENER").ToString)
                                    Dim stFPCOGAS As String = Trim(tblConstruccion.Rows(c).Item("FPCOGAS").ToString)
                                    Dim stFPCOPISO As String = Trim(tblConstruccion.Rows(c).Item("FPCOPISO").ToString)
                                    Dim stFPCOPOCO As String = Trim(tblConstruccion.Rows(c).Item("FPCOPOCO").ToString)
                                    Dim stFPCOEDCO As String = Trim(tblConstruccion.Rows(c).Item("FPCOEDCO").ToString)

                                    ' variables indirectas
                                    Dim stFPCOMEJO As String = ""
                                    Dim stFPCOLEY As String = ""

                                    ' mejora
                                    If boFPCOMEJO = False Then
                                        stFPCOMEJO = 2
                                    Else
                                        stFPCOMEJO = 1
                                    End If

                                    ' ley 56
                                    If boFPCOLEY = False Then
                                        stFPCOLEY = 2
                                    Else
                                        stFPCOLEY = 1
                                    End If

                                    ' formato vigencia
                                    stFPCOVIGE = stFPCOVIGE.PadLeft(4, "0")
                                    stFPCOVIGE = stFPCOVIGE.Substring(0, 4)

                                    ' formato tipo de resolución
                                    stFPCOTIRE = stFPCOTIRE.PadLeft(3, "0")
                                    stFPCOTIRE = stFPCOTIRE.Substring(0, 3)

                                    ' formato resolución
                                    stFPCORESO = stFPCORESO.PadLeft(7, "0")
                                    stFPCORESO = stFPCORESO.Substring(0, 7)

                                    ' formato numero de ficha
                                    stFPCONUFI = stFPCONUFI.PadLeft(9, "0")
                                    stFPCONUFI = stFPCONUFI.Substring(0, 9)

                                    ' formato numero de registro
                                    stFPCONURE = stFPCONURE.PadLeft(5, "0")
                                    stFPCONURE = stFPCONURE.Substring(0, 5)

                                    ' formato unidad 
                                    stFPCOUNID = stFPCOUNID.PadLeft(5, "0")
                                    stFPCOUNID = stFPCOUNID.Substring(0, 5)

                                    ' formato puntos
                                    stFPCOPUNT = stFPCOPUNT.PadLeft(3, "0")
                                    stFPCOPUNT = stFPCOPUNT.Substring(0, 3)

                                    ' formato área de construcción
                                    stFPCOARCO = stFPCOARCO.Replace(".", "")
                                    stFPCOARCO = stFPCOARCO.PadLeft(9, "0")
                                    stFPCOARCO = stFPCOARCO.Substring(0, 9)

                                    ' formato mejora
                                    stFPCOMEJO = stFPCOMEJO.PadLeft(1, "0")
                                    stFPCOMEJO = stFPCOMEJO.Substring(0, 1)

                                    ' formato ley 56
                                    stFPCOLEY = stFPCOLEY.PadLeft(1, "0")
                                    stFPCOLEY = stFPCOLEY.Substring(0, 1)

                                    ' formato tipo de construcción
                                    stFPCOTICO = stFPCOTICO.PadLeft(3, "0")
                                    stFPCOTICO = stFPCOTICO.Substring(0, 3)

                                    ' formato acueducto
                                    stFPCOACUE = stFPCOACUE.PadLeft(1, "0")
                                    stFPCOACUE = stFPCOACUE.Substring(0, 1)

                                    ' formato telefono
                                    stFPCOTELE = stFPCOTELE.PadLeft(1, "0")
                                    stFPCOTELE = stFPCOTELE.Substring(0, 1)

                                    ' formato alcantarillado
                                    stFPCOALCA = stFPCOALCA.PadLeft(1, "0")
                                    stFPCOALCA = stFPCOALCA.Substring(0, 1)

                                    ' formato energia
                                    stFPCOENER = stFPCOENER.PadLeft(1, "0")
                                    stFPCOENER = stFPCOENER.Substring(0, 1)

                                    ' formato gas
                                    stFPCOGAS = stFPCOGAS.PadLeft(1, "0")
                                    stFPCOGAS = stFPCOGAS.Substring(0, 1)

                                    ' formato numero de pisos
                                    stFPCOPISO = stFPCOPISO.PadLeft(2, "0")
                                    stFPCOPISO = stFPCOPISO.Substring(0, 2)

                                    ' formato porcentaje construido
                                    stFPCOPOCO = stFPCOPOCO.PadLeft(3, "0")
                                    stFPCOPOCO = stFPCOPOCO.Substring(0, 3)

                                    ' formato edad de construcción
                                    stFPCOEDCO = stFPCOEDCO.PadLeft(4, "0")
                                    stFPCOEDCO = stFPCOEDCO.Substring(0, 4)

                                    ' exportar los datos
                                    PrintLine(1, stFPCOIDRE & stSeparador & _
                                                 stFPCOVIGE & stSeparador & _
                                                 stFPCOTIRE & stSeparador & _
                                                 stFPCORESO & stSeparador & _
                                                 stFPCONUFI & stSeparador & _
                                                 stFPCONURE & stSeparador & _
                                                 stFPCOUNID & stSeparador & _
                                                 stFPCOPUNT & stSeparador & _
                                                 stFPCOARCO & stSeparador & _
                                                 stFPCOMEJO & stSeparador & _
                                                 stFPCOLEY & stSeparador & _
                                                 stFPCOTICO & stSeparador & _
                                                 stFPCOACUE & stSeparador & _
                                                 stFPCOTELE & stSeparador & _
                                                 stFPCOALCA & stSeparador & _
                                                 stFPCOENER & stSeparador & _
                                                 stFPCOGAS & stSeparador & _
                                                 stFPCOPISO & stSeparador & _
                                                 stFPCOPOCO & stSeparador & _
                                                 stFPCOEDCO)
                                End If

                            Next

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbProcesoActualizacion.Value = inProceso

                        Next

                        ' limpia la barra de progreso
                        pbProcesoActualizacion.Value = 0

                        '============================
                        '*** EXPORTA CALIFICACIÓN ***
                        '============================

                        ' carga la barra de progreso
                        inProceso = 0
                        pbProcesoActualizacion.Value = 0
                        pbProcesoActualizacion.Maximum = dt.Rows.Count
                        Timer1.Enabled = True

                        Dim f As Integer = 0

                        For f = 0 To dt.Rows.Count - 1

                            ' crea la tabla
                            tblCalificacion = New DataTable

                            ' almacena consulta
                            tblCalificacion = objCalificacion.fun_Consultar_FIPRCACO_X_FICHA_PREDIAL_TODAS_LAS_UNIDADES(dt.Rows(f).Item("FIPRNUFI"))

                            Dim d As Integer = 0

                            For d = 0 To tblCalificacion.Rows.Count - 1

                                ' verifica que se encuentre activa
                                If Trim(tblCalificacion.Rows(d).Item("FPCCESTA").ToString) = "ac" Then

                                    ' variables directas
                                    Dim stFPCCIDRE As String = "6"
                                    Dim stFPCCVIGE As String = Trim(tblCalificacion.Rows(d).Item("FPCCVIGE").ToString)
                                    Dim stFPCCTIRE As String = Trim(tblCalificacion.Rows(d).Item("FPCCTIRE").ToString)
                                    Dim stFPCCRESO As String = Trim(tblCalificacion.Rows(d).Item("FPCCRESO").ToString)
                                    Dim stFPCCNUFI As String = Trim(tblCalificacion.Rows(d).Item("FPCCNUFI").ToString)
                                    Dim stFPCCNURE As String = Trim(tblCalificacion.Rows(d).Item("FPCCNURE").ToString)
                                    Dim stFPCCUNID As String = Trim(tblCalificacion.Rows(d).Item("FPCCUNID").ToString)
                                    Dim stFPCCTIPO As String = Trim(tblCalificacion.Rows(d).Item("FPCCTIPO").ToString)
                                    Dim stFPCCCODI As String = Trim(tblCalificacion.Rows(d).Item("FPCCCODI").ToString)
                                    Dim stFPCCPUNT As String = Trim(tblCalificacion.Rows(d).Item("FPCCPUNT").ToString)

                                    ' formato vigencia
                                    stFPCCVIGE = stFPCCVIGE.PadLeft(4, "0")
                                    stFPCCVIGE = stFPCCVIGE.Substring(0, 4)

                                    ' formato tipo de resolución
                                    stFPCCTIRE = stFPCCTIRE.PadLeft(3, "0")
                                    stFPCCTIRE = stFPCCTIRE.Substring(0, 3)

                                    ' formato resolución
                                    stFPCCRESO = stFPCCRESO.PadLeft(7, "0")
                                    stFPCCRESO = stFPCCRESO.Substring(0, 7)

                                    ' formato numero de ficha
                                    stFPCCNUFI = stFPCCNUFI.PadLeft(9, "0")
                                    stFPCCNUFI = stFPCCNUFI.Substring(0, 9)

                                    ' formato numero de registro
                                    stFPCCNURE = stFPCCNURE.PadLeft(5, "0")
                                    stFPCCNURE = stFPCCNURE.Substring(0, 5)

                                    ' formato unidad 
                                    stFPCCUNID = stFPCCUNID.PadLeft(5, "0")
                                    stFPCCUNID = stFPCCUNID.Substring(0, 5)

                                    ' formato tipo de calificación
                                    stFPCCTIPO = stFPCCTIPO.PadRight(1, " ")
                                    stFPCCTIPO = stFPCCTIPO.Substring(0, 1)

                                    ' formato código de calificación
                                    stFPCCCODI = stFPCCCODI.PadLeft(4, "0")
                                    stFPCCCODI = stFPCCCODI.Substring(0, 4)

                                    ' formato puntos
                                    stFPCCPUNT = stFPCCPUNT.PadLeft(3, "0")
                                    stFPCCPUNT = stFPCCPUNT.Substring(0, 3)

                                    ' exportar los datos
                                    PrintLine(1, stFPCCIDRE & stSeparador & _
                                                 stFPCCVIGE & stSeparador & _
                                                 stFPCCTIRE & stSeparador & _
                                                 stFPCCRESO & stSeparador & _
                                                 stFPCCNUFI & stSeparador & _
                                                 stFPCCNURE & stSeparador & _
                                                 stFPCCUNID & stSeparador & _
                                                 stFPCCTIPO & stSeparador & _
                                                 stFPCCCODI & stSeparador & _
                                                 stFPCCPUNT)
                                End If

                            Next

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbProcesoActualizacion.Value = inProceso

                        Next

                        ' limpia la barra de progreso
                        pbProcesoActualizacion.Value = 0

                        '========================
                        '*** EXPORTA LINDEROS ***
                        '========================

                        ' carga la barra de progreso
                        inProceso = 0
                        pbProcesoActualizacion.Value = 0
                        pbProcesoActualizacion.Maximum = dt.Rows.Count
                        Timer1.Enabled = True

                        Dim w As Integer = 0

                        For w = 0 To dt.Rows.Count - 1

                            ' crea la tabla
                            tblLinderos = New DataTable

                            ' almacena consulta
                            tblLinderos = objLinderos.fun_Consultar_FIPRLIND_X_FICHA_PREDIAL(dt.Rows(w).Item("FIPRNUFI"))

                            Dim d As Integer = 0

                            For d = 0 To tblLinderos.Rows.Count - 1

                                ' verifica que se encuentre activa
                                If Trim(tblLinderos.Rows(d).Item("FPLIESTA").ToString) = "ac" Then

                                    ' variables directas
                                    Dim stFPLIIDRE As String = "7"
                                    Dim stFPLIVIGE As String = Trim(tblLinderos.Rows(d).Item("FPLIVIGE").ToString)
                                    Dim stFPLITIRE As String = Trim(tblLinderos.Rows(d).Item("FPLITIRE").ToString)
                                    Dim stFPLIRESO As String = Trim(tblLinderos.Rows(d).Item("FPLIRESO").ToString)
                                    Dim stFPLINUFI As String = Trim(tblLinderos.Rows(d).Item("FPLINUFI").ToString)
                                    Dim stFPLINURE As String = Trim(tblLinderos.Rows(d).Item("FPLINURE").ToString)
                                    Dim stFPLIPUCA As String = Trim(tblLinderos.Rows(d).Item("FPLIPUCA").ToString)
                                    Dim stFPLICOLI As String = Trim(tblLinderos.Rows(d).Item("FPLICOLI").ToString)

                                    ' formato vigencia
                                    stFPLIVIGE = stFPLIVIGE.PadLeft(4, "0")
                                    stFPLIVIGE = stFPLIVIGE.Substring(0, 4)

                                    ' formato tipo de resolución
                                    stFPLITIRE = stFPLITIRE.PadLeft(3, "0")
                                    stFPLITIRE = stFPLITIRE.Substring(0, 3)

                                    ' formato resolución
                                    stFPLIRESO = stFPLIRESO.PadLeft(7, "0")
                                    stFPLIRESO = stFPLIRESO.Substring(0, 7)

                                    ' formato numero de ficha
                                    stFPLINUFI = stFPLINUFI.PadLeft(9, "0")
                                    stFPLINUFI = stFPLINUFI.Substring(0, 9)

                                    ' formato numero de registro
                                    stFPLINURE = stFPLINURE.PadLeft(5, "0")
                                    stFPLINURE = stFPLINURE.Substring(0, 5)

                                    ' formato punto cardinal
                                    stFPLIPUCA = stFPLIPUCA.PadRight(2, " ")
                                    stFPLIPUCA = stFPLIPUCA.Substring(0, 2)

                                    ' formato colindante
                                    stFPLICOLI = stFPLICOLI.PadRight(30, " ")
                                    stFPLICOLI = stFPLICOLI.Substring(0, 30)

                                    ' exportar los datos
                                    PrintLine(1, stFPLIIDRE & stSeparador & _
                                                 stFPLIVIGE & stSeparador & _
                                                 stFPLITIRE & stSeparador & _
                                                 stFPLIRESO & stSeparador & _
                                                 stFPLINUFI & stSeparador & _
                                                 stFPLINURE & stSeparador & _
                                                 stFPLIPUCA & stSeparador & _
                                                 stFPLICOLI)
                                End If

                            Next

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbProcesoActualizacion.Value = inProceso

                        Next

                        ' limpia la barra de progreso
                        pbProcesoActualizacion.Value = 0

                        '===========================
                        '*** EXPORTA CARTOGRAFIA ***
                        '===========================

                        ' carga la barra de progreso
                        inProceso = 0
                        pbProcesoActualizacion.Value = 0
                        pbProcesoActualizacion.Maximum = dt.Rows.Count
                        Timer1.Enabled = True

                        Dim r As Integer = 0

                        For r = 0 To dt.Rows.Count - 1

                            ' crea la tabla
                            tblCartografia = New DataTable

                            ' almacena consulta
                            tblCartografia = objCartografia.fun_Consultar_FIPRCART_X_FICHA_PREDIAL(dt.Rows(r).Item("FIPRNUFI"))

                            Dim d As Integer = 0

                            For d = 0 To tblCartografia.Rows.Count - 1

                                ' verifica que se encuentre activa
                                If Trim(tblCartografia.Rows(d).Item("FPCAESTA").ToString) = "ac" Then

                                    ' variables directas
                                    Dim stFPCAIDRE As String = "8"
                                    Dim stFPCAVIGE As String = Trim(tblCartografia.Rows(d).Item("FPCAVIGE").ToString)
                                    Dim stFPCATIRE As String = Trim(tblCartografia.Rows(d).Item("FPCATIRE").ToString)
                                    Dim stFPCARESO As String = Trim(tblCartografia.Rows(d).Item("FPCARESO").ToString)
                                    Dim stFPCANUFI As String = Trim(tblCartografia.Rows(d).Item("FPCANUFI").ToString)
                                    Dim stFPCANURE As String = Trim(tblCartografia.Rows(d).Item("FPCANURE").ToString)
                                    Dim stFPCAPLAN As String = Trim(tblCartografia.Rows(d).Item("FPCAPLAN").ToString)
                                    Dim stFPCAVENT As String = Trim(tblCartografia.Rows(d).Item("FPCAVENT").ToString)
                                    Dim stFPCAESGR As String = Trim(tblCartografia.Rows(d).Item("FPCAESGR").ToString)
                                    Dim stFPCAVIGR As String = Trim(tblCartografia.Rows(d).Item("FPCAVIGR").ToString)
                                    Dim stFPCAVUEL As String = Trim(tblCartografia.Rows(d).Item("FPCAVUEL").ToString)
                                    Dim stFPCAFAJA As String = Trim(tblCartografia.Rows(d).Item("FPCAFAJA").ToString)
                                    Dim stFPCAFOTO As String = Trim(tblCartografia.Rows(d).Item("FPCAFOTO").ToString)
                                    Dim stFPCAVIAE As String = Trim(tblCartografia.Rows(d).Item("FPCAVIAE").ToString)
                                    Dim stFPCAAMPL As String = Trim(tblCartografia.Rows(d).Item("FPCAAMPL").ToString)
                                    Dim stFPCAESAE As String = Trim(tblCartografia.Rows(d).Item("FPCAESAE").ToString)

                                    ' formato vigencia
                                    stFPCAVIGE = stFPCAVIGE.PadLeft(4, "0")
                                    stFPCAVIGE = stFPCAVIGE.Substring(0, 4)

                                    ' formato tipo de resolución
                                    stFPCATIRE = stFPCATIRE.PadLeft(3, "0")
                                    stFPCATIRE = stFPCATIRE.Substring(0, 3)

                                    ' formato resolución
                                    stFPCARESO = stFPCARESO.PadLeft(7, "0")
                                    stFPCARESO = stFPCARESO.Substring(0, 7)

                                    ' formato numero de ficha
                                    stFPCANUFI = stFPCANUFI.PadLeft(9, "0")
                                    stFPCANUFI = stFPCANUFI.Substring(0, 9)

                                    ' formato numero de registro
                                    stFPCANURE = stFPCANURE.PadLeft(5, "0")
                                    stFPCANURE = stFPCANURE.Substring(0, 5)

                                    ' formato plancha
                                    stFPCAPLAN = stFPCAPLAN.PadRight(15, " ")
                                    stFPCAPLAN = stFPCAPLAN.Substring(0, 15)

                                    ' formato ventana
                                    stFPCAVENT = stFPCAVENT.PadRight(15, " ")
                                    stFPCAVENT = stFPCAVENT.Substring(0, 15)

                                    ' formato escala grafica
                                    stFPCAESGR = stFPCAESGR.PadRight(15, " ")
                                    stFPCAESGR = stFPCAESGR.Substring(0, 15)

                                    ' formato vigencia grafica
                                    stFPCAVIGR = stFPCAVIGR.PadLeft(4, "0")
                                    stFPCAVIGR = stFPCAVIGR.Substring(0, 4)

                                    ' formato vuelo
                                    stFPCAVUEL = stFPCAVUEL.PadRight(15, " ")
                                    stFPCAVUEL = stFPCAVUEL.Substring(0, 15)

                                    ' formato faja
                                    stFPCAFAJA = stFPCAFAJA.PadRight(15, " ")
                                    stFPCAFAJA = stFPCAFAJA.Substring(0, 15)

                                    ' formato foto
                                    stFPCAFOTO = stFPCAFOTO.PadRight(15, " ")
                                    stFPCAFOTO = stFPCAFOTO.Substring(0, 15)

                                    ' formato vigencia aerofotografica
                                    stFPCAVIAE = stFPCAVIAE.PadLeft(4, "0")
                                    stFPCAVIAE = stFPCAVIAE.Substring(0, 4)

                                    ' formato ampliación
                                    stFPCAAMPL = stFPCAAMPL.PadRight(15, " ")
                                    stFPCAAMPL = stFPCAAMPL.Substring(0, 15)

                                    ' formato escala aerofotografica
                                    stFPCAESAE = stFPCAESAE.PadRight(15, " ")
                                    stFPCAESAE = stFPCAESAE.Substring(0, 15)

                                    ' exportar los datos
                                    PrintLine(1, stFPCAIDRE & stSeparador & _
                                                 stFPCAVIGE & stSeparador & _
                                                 stFPCATIRE & stSeparador & _
                                                 stFPCARESO & stSeparador & _
                                                 stFPCANUFI & stSeparador & _
                                                 stFPCANURE & stSeparador & _
                                                 stFPCAPLAN & stSeparador & _
                                                 stFPCAVENT & stSeparador & _
                                                 stFPCAESGR & stSeparador & _
                                                 stFPCAVIGR & stSeparador & _
                                                 stFPCAVUEL & stSeparador & _
                                                 stFPCAFAJA & stSeparador & _
                                                 stFPCAFOTO & stSeparador & _
                                                 stFPCAVIAE & stSeparador & _
                                                 stFPCAAMPL & stSeparador & _
                                                 stFPCAESAE)
                                End If

                            Next

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbProcesoActualizacion.Value = inProceso

                        Next

                        ' Limpia los campos
                        pbProcesoActualizacion.Value = 0

                        MessageBox.Show("Archivo plano creado corectamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                        ' prende el boton
                        Me.cmdExportarPlanoActualizacion.Enabled = True

                        If MessageBox.Show("¿ Desea abrir el archivo plano ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                            ' Abrir con Process.Start el archivo de texto
                            Process.Start(stRutaArchivoActualizacion)
                        End If

                    Else
                        MessageBox.Show("No existen registros en base de datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        cmdExportarPlanoActualizacion.Focus()
                    End If

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub pro_ExportarPlanoFichaResumenActualizacion()

        Try
            ' verifica si se a seleccionado una resolución
            If Me.txtREACRESO.Text = "" Then
                MessageBox.Show("Seleccione una resolución", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                ' verifica la ruta del acchivo
                If Trim(stRutaArchivoActualizacion) <> "" Then

                    ' recorre el archivo a exportar
                    FileOpen(1, oCrear.FileName, OpenMode.Output) 'crea y destruye si hay otro igual

                    ' variable separador
                    Dim stSeparador As String = Trim(Me.txtSEPARADOR.Text)

                    ' apaga el boton
                    Me.cmdExportarPlanoActualizacion.Enabled = False

                    '==========================
                    '*** GENERA LA CONSULTA ***
                    '==========================

                    ' crea un datable
                    dt = New DataTable

                    ' llena el datatable con la consulta
                    dt_FR_1_Y_2 = fun_EjecutarConsultaFichaResumen1y2Actualizacion()
                    dt_FR_1 = fun_EjecutarConsultaFichaResumen1Actualizacion()
                    dt_FR_2 = fun_EjecutarConsultaFichaResumen2Actualizacion()

                    '============================
                    '*** CUENTA LOS REGISTROS ***
                    '============================

                    Dim objdatos As New cla_VALIFIPR
                    Dim ds As New DataSet

                    ds = objdatos.fun_Consultar_NRO_REGISTROS_DE_EXPORTACION_FICHA_RESUMEN(Me.txtREACDEPA.Text, _
                                                                                           Me.txtREACMUNI.Text, _
                                                                                           Me.txtREACTIRE.Text, _
                                                                                           Me.txtREACCLSE.Text, _
                                                                                           Me.txtREACVIGE.Text, _
                                                                                           Me.txtREACRESO.Text)

                    ' crea nuevos datatable
                    dt_FICHPRED = New DataTable
                    dt_FIPRDEEC = New DataTable
                    dt_FIPRPROP = New DataTable
                    dt_FIPRCONS = New DataTable
                    dt_FIPRCACO = New DataTable
                    dt_FIPRLIND = New DataTable
                    dt_FIPRCART = New DataTable

                    ' almacena la información
                    dt_FICHPRED = ds.Tables(0)
                    dt_FIPRDEEC = ds.Tables(1)
                    dt_FIPRPROP = ds.Tables(2)
                    dt_FIPRCONS = ds.Tables(3)
                    dt_FIPRCACO = ds.Tables(4)
                    dt_FIPRLIND = ds.Tables(5)
                    dt_FIPRCART = ds.Tables(6)

                    ' cuenta los registros
                    Dim in_Nro_Registros_FICHPRED As Integer = dt_FICHPRED.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRDEEC As Integer = dt_FIPRDEEC.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRPROP As Integer = dt_FIPRPROP.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRCONS As Integer = dt_FIPRCONS.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRCACO As Integer = dt_FIPRCACO.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRLIND As Integer = dt_FIPRLIND.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRCART As Integer = dt_FIPRCART.Rows(0).Item(0)

                    inProceso = 0
                    pbProcesoActualizacion.Value = 0
                    pbProcesoActualizacion.Maximum = in_Nro_Registros_FICHPRED + in_Nro_Registros_FIPRDEEC + in_Nro_Registros_FIPRPROP + in_Nro_Registros_FIPRCONS + in_Nro_Registros_FIPRCACO + in_Nro_Registros_FIPRLIND + in_Nro_Registros_FIPRCART
                    Timer1.Enabled = True

                    ' recorre la consulta
                    If dt.Rows.Count > 0 Then

                        '================================
                        '*** ID : 1 EXPORTA RESUMEN 1 ***
                        '================================

                        Dim i As Integer = 0

                        For i = 0 To dt_FR_1.Rows.Count - 1

                            ' crea la tabla
                            tblFichaPredial = New DataTable

                            ' almacena consulta
                            tblFichaPredial = objFichaPredial.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dt_FR_1.Rows(i).Item("FIPRNUFI"))

                            ' variables directas
                            Dim stFIPRIDRE As String = "1"
                            Dim stFIPRMUNI As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMUNI").ToString)
                            Dim stFIPRCLSE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCLSE").ToString)
                            Dim stFIPRCORR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCORR").ToString)
                            Dim stFIPRBARR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRBARR").ToString)
                            Dim stFIPRMANZ As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMANZ").ToString)
                            Dim stFIPRPRED As String = Trim(tblFichaPredial.Rows(0).Item("FIPRPRED").ToString)
                            Dim stFIPRATLO As String = Trim(tblFichaPredial.Rows(0).Item("FIPRATLO").ToString)
                            Dim stFIPRACLO As String = Trim(tblFichaPredial.Rows(0).Item("FIPRACLO").ToString)
                            Dim stFIPRAPCA As String = Trim(tblFichaPredial.Rows(0).Item("FIPRAPCA").ToString)
                            Dim stFIPRUNCO As String = Trim(tblFichaPredial.Rows(0).Item("FIPRUNCO").ToString)
                            Dim stFIPRTOED As String = Trim(tblFichaPredial.Rows(0).Item("FIPRTOED").ToString)
                            Dim stFIPRCUUT As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCUUT").ToString)
                            Dim stFIPRLOCA As String = Trim(tblFichaPredial.Rows(0).Item("FIPRLOCA").ToString)
                            Dim stFIPRGACU As String = Trim(tblFichaPredial.Rows(0).Item("FIPRGACU").ToString)
                            Dim stFIPRGADE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRGADE").ToString)
                            Dim stFIPRDIRE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRDIRE").ToString)
                            Dim stFIPRCAPR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCAPR").ToString)

                            ' formato municipio actual
                            stFIPRMUNI = stFIPRMUNI.PadLeft(3, "0")
                            stFIPRMUNI = stFIPRMUNI.Substring(0, 3)

                            ' formato clase o sector actual
                            stFIPRCLSE = stFIPRCLSE.PadLeft(1, "0")
                            stFIPRCLSE = stFIPRCLSE.Substring(0, 1)

                            ' formato corregimiento actual
                            stFIPRCORR = stFIPRCORR.PadLeft(3, "0")
                            stFIPRCORR = stFIPRCORR.Substring(0, 3)

                            ' formato barrio actual
                            stFIPRBARR = stFIPRBARR.PadLeft(3, "0")
                            stFIPRBARR = stFIPRBARR.Substring(0, 3)

                            ' formato manzana actual
                            stFIPRMANZ = stFIPRMANZ.PadLeft(3, "0")
                            stFIPRMANZ = stFIPRMANZ.Substring(0, 3)

                            ' formato predio actual
                            stFIPRPRED = stFIPRPRED.PadLeft(5, "0")
                            stFIPRPRED = stFIPRPRED.Substring(0, 5)

                            ' formato área total de lote
                            stFIPRATLO = stFIPRATLO.PadLeft(11, "0")
                            stFIPRATLO = stFIPRATLO.Substring(0, 11)

                            ' formato área comun de lote
                            stFIPRACLO = stFIPRACLO.PadLeft(11, "0")
                            stFIPRACLO = stFIPRACLO.Substring(0, 11)

                            ' formato apartamentos o casa
                            stFIPRAPCA = stFIPRAPCA.PadLeft(4, "0")
                            stFIPRAPCA = stFIPRAPCA.Substring(0, 4)

                            ' formato unidades en condominio
                            stFIPRUNCO = stFIPRUNCO.PadLeft(4, "0")
                            stFIPRUNCO = stFIPRUNCO.Substring(0, 4)

                            ' formato total edificios
                            stFIPRTOED = stFIPRTOED.PadLeft(4, "0")
                            stFIPRTOED = stFIPRTOED.Substring(0, 4)

                            ' formato cuartos utilies
                            stFIPRCUUT = stFIPRCUUT.PadLeft(4, "0")
                            stFIPRCUUT = stFIPRCUUT.Substring(0, 4)

                            ' formato locales
                            stFIPRLOCA = stFIPRLOCA.PadLeft(4, "0")
                            stFIPRLOCA = stFIPRLOCA.Substring(0, 4)

                            ' formato garajes cubiertos
                            stFIPRGACU = stFIPRGACU.PadLeft(4, "0")
                            stFIPRGACU = stFIPRGACU.Substring(0, 4)

                            ' formato garajes descubiertos
                            stFIPRGADE = stFIPRGADE.PadLeft(4, "0")
                            stFIPRGADE = stFIPRGADE.Substring(0, 4)

                            ' formato dirección
                            stFIPRDIRE = stFIPRDIRE.PadRight(49, " ")
                            stFIPRDIRE = stFIPRDIRE.Substring(0, 49)

                            ' formato caracteristica de predio
                            stFIPRCAPR = stFIPRCAPR.PadLeft(1, "0")
                            stFIPRCAPR = stFIPRCAPR.Substring(0, 1)

                            ' exportar los datos
                            PrintLine(1, stFIPRIDRE & stSeparador & _
                                         stFIPRMUNI & stSeparador & _
                                         stFIPRCLSE & stSeparador & _
                                         stFIPRCORR & stSeparador & _
                                         stFIPRBARR & stSeparador & _
                                         stFIPRMANZ & stSeparador & _
                                         stFIPRPRED & stSeparador & _
                                         stFIPRATLO & stSeparador & _
                                         stFIPRACLO & stSeparador & _
                                         stFIPRAPCA & stSeparador & _
                                         stFIPRUNCO & stSeparador & _
                                         stFIPRTOED & stSeparador & _
                                         stFIPRCUUT & stSeparador & _
                                         stFIPRLOCA & stSeparador & _
                                         stFIPRGACU & stSeparador & _
                                         stFIPRGADE & stSeparador & _
                                         stFIPRDIRE & stSeparador & _
                                         stFIPRCAPR)

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbProcesoActualizacion.Value = inProceso

                        Next

                        '================================
                        '*** ID : 2 EXPORTA RESUMEN 2 ***
                        '================================

                        Dim k As Integer = 0

                        For k = 0 To dt_FR_2.Rows.Count - 1

                            ' crea la tabla
                            tblFichaPredial = New DataTable

                            ' almacena consulta
                            tblFichaPredial = objFichaPredial.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dt_FR_2.Rows(k).Item("FIPRNUFI"))

                            ' variables directas
                            Dim stFIPRIDRE As String = "2"
                            Dim stFIPRMUNI As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMUNI").ToString)
                            Dim stFIPRCLSE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCLSE").ToString)
                            Dim stFIPRCORR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCORR").ToString)
                            Dim stFIPRBARR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRBARR").ToString)
                            Dim stFIPRMANZ As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMANZ").ToString)
                            Dim stFIPRPRED As String = Trim(tblFichaPredial.Rows(0).Item("FIPRPRED").ToString)
                            Dim stFIPREDIF As String = Trim(tblFichaPredial.Rows(0).Item("FIPREDIF").ToString)
                            Dim stFIPRATLO As String = Trim(tblFichaPredial.Rows(0).Item("FIPRATLO").ToString)
                            Dim stFIPRACLO As String = Trim(tblFichaPredial.Rows(0).Item("FIPRACLO").ToString)
                            Dim stFIPRPISO As String = Trim(tblFichaPredial.Rows(0).Item("FIPRPISO").ToString)
                            Dim stFIPRURPH As String = Trim(tblFichaPredial.Rows(0).Item("FIPRURPH").ToString)
                            Dim stFIPRAPCA As String = Trim(tblFichaPredial.Rows(0).Item("FIPRAPCA").ToString)
                            Dim stFIPRCUUT As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCUUT").ToString)
                            Dim stFIPRLOCA As String = Trim(tblFichaPredial.Rows(0).Item("FIPRLOCA").ToString)
                            Dim stFIPRGACU As String = Trim(tblFichaPredial.Rows(0).Item("FIPRGACU").ToString)
                            Dim stFIPRGADE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRGADE").ToString)
                            Dim stFIPRDIRE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRDIRE").ToString)
                            Dim stFIPRCAPR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCAPR").ToString)

                            If Me.chkEdificioEnCeros.Checked = True Then
                                stFIPREDIF = "000"
                            End If

                            ' formato municipio actual
                            stFIPRMUNI = stFIPRMUNI.PadLeft(3, "0")
                            stFIPRMUNI = stFIPRMUNI.Substring(0, 3)

                            ' formato clase o sector actual
                            stFIPRCLSE = stFIPRCLSE.PadLeft(1, "0")
                            stFIPRCLSE = stFIPRCLSE.Substring(0, 1)

                            ' formato corregimiento actual
                            stFIPRCORR = stFIPRCORR.PadLeft(3, "0")
                            stFIPRCORR = stFIPRCORR.Substring(0, 3)

                            ' formato barrio actual
                            stFIPRBARR = stFIPRBARR.PadLeft(3, "0")
                            stFIPRBARR = stFIPRBARR.Substring(0, 3)

                            ' formato manzana actual
                            stFIPRMANZ = stFIPRMANZ.PadLeft(3, "0")
                            stFIPRMANZ = stFIPRMANZ.Substring(0, 3)

                            ' formato predio actual
                            stFIPRPRED = stFIPRPRED.PadLeft(5, "0")
                            stFIPRPRED = stFIPRPRED.Substring(0, 5)

                            ' formato edificio
                            stFIPREDIF = stFIPREDIF.PadLeft(5, "0")
                            stFIPREDIF = stFIPREDIF.Substring(0, 5)

                            ' formato área total de lote
                            stFIPRATLO = stFIPRATLO.PadLeft(10, "0")
                            stFIPRATLO = stFIPRATLO.Substring(0, 10)

                            ' formato área comun de lote
                            stFIPRACLO = stFIPRACLO.PadLeft(10, "0")
                            stFIPRACLO = stFIPRACLO.Substring(0, 10)

                            ' formato pisos
                            stFIPRPISO = stFIPRPISO.PadLeft(3, "0")
                            stFIPRPISO = stFIPRPISO.Substring(0, 3)

                            ' formato unidades en rph
                            stFIPRURPH = stFIPRURPH.PadLeft(4, "0")
                            stFIPRURPH = stFIPRURPH.Substring(0, 4)

                            ' formato apartamentos o casa
                            stFIPRAPCA = stFIPRAPCA.PadLeft(4, "0")
                            stFIPRAPCA = stFIPRAPCA.Substring(0, 4)

                            ' formato cuartos utilies
                            stFIPRCUUT = stFIPRCUUT.PadLeft(4, "0")
                            stFIPRCUUT = stFIPRCUUT.Substring(0, 4)

                            ' formato locales
                            stFIPRLOCA = stFIPRLOCA.PadLeft(4, "0")
                            stFIPRLOCA = stFIPRLOCA.Substring(0, 4)

                            ' formato garajes cubiertos
                            stFIPRGACU = stFIPRGACU.PadLeft(4, "0")
                            stFIPRGACU = stFIPRGACU.Substring(0, 4)

                            ' formato garajes descubiertos
                            stFIPRGADE = stFIPRGADE.PadLeft(4, "0")
                            stFIPRGADE = stFIPRGADE.Substring(0, 4)

                            ' formato dirección
                            stFIPRDIRE = stFIPRDIRE.PadRight(49, " ")
                            stFIPRDIRE = stFIPRDIRE.Substring(0, 49)

                            ' formato caracteristica de predio
                            stFIPRCAPR = stFIPRCAPR.PadLeft(1, "0")
                            stFIPRCAPR = stFIPRCAPR.Substring(0, 1)

                            ' exportar los datos
                            PrintLine(1, stFIPRIDRE & stSeparador & _
                                         stFIPRMUNI & stSeparador & _
                                         stFIPRCLSE & stSeparador & _
                                         stFIPRCORR & stSeparador & _
                                         stFIPRBARR & stSeparador & _
                                         stFIPRMANZ & stSeparador & _
                                         stFIPRPRED & stSeparador & _
                                         stFIPREDIF & stSeparador & _
                                         stFIPRATLO & stSeparador & _
                                         stFIPRACLO & stSeparador & _
                                         stFIPRPISO & stSeparador & _
                                         stFIPRURPH & stSeparador & _
                                         stFIPRAPCA & stSeparador & _
                                         stFIPRCUUT & stSeparador & _
                                         stFIPRLOCA & stSeparador & _
                                         stFIPRGACU & stSeparador & _
                                         stFIPRGADE & stSeparador & _
                                         stFIPRDIRE & stSeparador & _
                                         stFIPRCAPR)

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbProcesoActualizacion.Value = inProceso

                        Next

                        '===================================
                        '*** ID : 3 EXPORTA CONSTRUCCIÓN ***
                        '===================================

                        Dim h As Integer = 0

                        For h = 0 To dt_FR_1_Y_2.Rows.Count - 1

                            ' crea la tabla
                            tblConstruccion = New DataTable

                            ' almacena consulta
                            tblConstruccion = objConstruccion.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(dt_FR_1_Y_2.Rows(h).Item("FIPRNUFI"))

                            ' recorro la tabla
                            Dim c As Integer = 0

                            For c = 0 To tblConstruccion.Rows.Count - 1

                                ' verifica que se encuentre activa
                                If Trim(tblConstruccion.Rows(c).Item("FPCOESTA").ToString) = "ac" Then

                                    ' instancia la clase
                                    objCedula = New cla_FICHPRED
                                    tblCedula = New DataTable

                                    ' consulta la cedula catastral por numero de ficha
                                    tblCedula = objCedula.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(tblConstruccion.Rows(c).Item("FPCONUFI"))

                                    ' variables directas
                                    Dim stFPCOIDRE As String = "3"
                                    Dim stFPCOMUNI As String = Trim(tblCedula.Rows(0).Item("FIPRMUNI").ToString)
                                    Dim stFPCOCLSE As String = Trim(tblCedula.Rows(0).Item("FIPRCLSE").ToString)
                                    Dim stFPCOCORR As String = Trim(tblCedula.Rows(0).Item("FIPRCORR").ToString)
                                    Dim stFPCOBARR As String = Trim(tblCedula.Rows(0).Item("FIPRBARR").ToString)
                                    Dim stFPCOMANZ As String = Trim(tblCedula.Rows(0).Item("FIPRMANZ").ToString)
                                    Dim stFPCOPRED As String = Trim(tblCedula.Rows(0).Item("FIPRPRED").ToString)
                                    Dim stFPCOEDIF As String = Trim(tblCedula.Rows(0).Item("FIPREDIF").ToString)

                                    Dim stFPCOUNID As String = Trim(tblConstruccion.Rows(c).Item("FPCOUNID").ToString)
                                    Dim stFPCOTIPO As String = Trim(fun_BuscaTipoDeCalificación(vp_Departamento, Trim(tblConstruccion.Rows(c).Item("FPCOMUNI").ToString), tblConstruccion.Rows(c).Item("FPCOCLCO").ToString, tblConstruccion.Rows(c).Item("FPCOCLSE").ToString, Trim(tblConstruccion.Rows(c).Item("FPCOTICO").ToString)))
                                    Dim stFPCOTICO As String = fun_Quita_Letras(Trim(tblConstruccion.Rows(c).Item("FPCOTICO").ToString))
                                    Dim stFPCOARCO As String = Trim(tblConstruccion.Rows(c).Item("FPCOARCO").ToString)
                                    Dim stFPCOPUNT As String = Trim(tblConstruccion.Rows(c).Item("FPCOPUNT").ToString)
                                    Dim stFPCOACUE As String = Trim(tblConstruccion.Rows(c).Item("FPCOACUE").ToString)
                                    Dim stFPCOALCA As String = Trim(tblConstruccion.Rows(c).Item("FPCOALCA").ToString)
                                    Dim stFPCOENER As String = Trim(tblConstruccion.Rows(c).Item("FPCOENER").ToString)
                                    Dim stFPCOTELE As String = Trim(tblConstruccion.Rows(c).Item("FPCOTELE").ToString)
                                    Dim stFPCOGAS As String = Trim(tblConstruccion.Rows(c).Item("FPCOGAS").ToString)
                                    Dim stFPCOPISO As String = Trim(tblConstruccion.Rows(c).Item("FPCOPISO").ToString)
                                    Dim stFPCOPOCO As String = Trim(tblConstruccion.Rows(c).Item("FPCOPOCO").ToString)
                                    Dim stFPCOEDCO As String = Trim(tblConstruccion.Rows(c).Item("FPCOEDCO").ToString)

                                    If Me.chkEdificioEnCeros.Checked = True Then
                                        stFPCOEDIF = "000"
                                    End If

                                    ' formato municipio actual
                                    stFPCOMUNI = stFPCOMUNI.PadLeft(3, "0")
                                    stFPCOMUNI = stFPCOMUNI.Substring(0, 3)

                                    ' formato clase o sector actual
                                    stFPCOCLSE = stFPCOCLSE.PadLeft(1, "0")
                                    stFPCOCLSE = stFPCOCLSE.Substring(0, 1)

                                    ' formato corregimiento actual
                                    stFPCOCORR = stFPCOCORR.PadLeft(3, "0")
                                    stFPCOCORR = stFPCOCORR.Substring(0, 3)

                                    ' formato barrio actual
                                    stFPCOBARR = stFPCOBARR.PadLeft(3, "0")
                                    stFPCOBARR = stFPCOBARR.Substring(0, 3)

                                    ' formato manzana actual
                                    stFPCOMANZ = stFPCOMANZ.PadLeft(3, "0")
                                    stFPCOMANZ = stFPCOMANZ.Substring(0, 3)

                                    ' formato predio actual
                                    stFPCOPRED = stFPCOPRED.PadLeft(5, "0")
                                    stFPCOPRED = stFPCOPRED.Substring(0, 5)

                                    ' formato edificio
                                    stFPCOEDIF = stFPCOEDIF.PadLeft(5, "0")
                                    stFPCOEDIF = stFPCOEDIF.Substring(0, 5)

                                    ' formato unidad 
                                    stFPCOUNID = stFPCOUNID.PadLeft(5, "0")
                                    stFPCOUNID = stFPCOUNID.Substring(0, 5)

                                    ' formato tipo de calificación
                                    stFPCOTIPO = stFPCOTIPO.PadRight(1, " ")
                                    stFPCOTIPO = stFPCOTIPO.Substring(0, 1)

                                    ' formato tipo de construcción
                                    stFPCOTICO = stFPCOTICO.PadLeft(3, "0")
                                    stFPCOTICO = stFPCOTICO.Substring(0, 3)

                                    ' formato área de construcción
                                    stFPCOARCO = stFPCOARCO.Replace(".", "")
                                    stFPCOARCO = stFPCOARCO.PadLeft(8, "0")
                                    stFPCOARCO = stFPCOARCO.Substring(0, 8)

                                    ' formato puntos
                                    stFPCOPUNT = stFPCOPUNT.PadLeft(3, "0")
                                    stFPCOPUNT = stFPCOPUNT.Substring(0, 3)

                                    ' formato acueducto
                                    stFPCOACUE = stFPCOACUE.PadLeft(1, "0")
                                    stFPCOACUE = stFPCOACUE.Substring(0, 1)

                                    ' formato alcantarillado
                                    stFPCOALCA = stFPCOALCA.PadLeft(1, "0")
                                    stFPCOALCA = stFPCOALCA.Substring(0, 1)

                                    ' formato energia
                                    stFPCOENER = stFPCOENER.PadLeft(1, "0")
                                    stFPCOENER = stFPCOENER.Substring(0, 1)

                                    ' formato telefono
                                    stFPCOTELE = stFPCOTELE.PadLeft(1, "0")
                                    stFPCOTELE = stFPCOTELE.Substring(0, 1)

                                    ' formato gas
                                    stFPCOGAS = stFPCOGAS.PadLeft(1, "0")
                                    stFPCOGAS = stFPCOGAS.Substring(0, 1)

                                    ' formato numero de pisos
                                    stFPCOPISO = stFPCOPISO.PadLeft(2, "0")
                                    stFPCOPISO = stFPCOPISO.Substring(0, 2)

                                    ' formato porcentaje construido
                                    stFPCOPOCO = stFPCOPOCO.PadLeft(3, "0")
                                    stFPCOPOCO = stFPCOPOCO & "00"
                                    stFPCOPOCO = stFPCOPOCO.Substring(0, 5)

                                    ' formato edad de construcción
                                    stFPCOEDCO = stFPCOEDCO.PadLeft(4, "0")
                                    stFPCOEDCO = stFPCOEDCO.Substring(0, 4)

                                    ' exportar los datos
                                    PrintLine(1, stFPCOIDRE & stSeparador & _
                                                 stFPCOMUNI & stSeparador & _
                                                 stFPCOCLSE & stSeparador & _
                                                 stFPCOCORR & stSeparador & _
                                                 stFPCOBARR & stSeparador & _
                                                 stFPCOMANZ & stSeparador & _
                                                 stFPCOPRED & stSeparador & _
                                                 stFPCOEDIF & stSeparador & _
                                                 stFPCOUNID & stSeparador & _
                                                 stFPCOTIPO & stSeparador & _
                                                 stFPCOTICO & stSeparador & _
                                                 stFPCOARCO & stSeparador & _
                                                 stFPCOPUNT & stSeparador & _
                                                 stFPCOACUE & stSeparador & _
                                                 stFPCOALCA & stSeparador & _
                                                 stFPCOENER & stSeparador & _
                                                 stFPCOTELE & stSeparador & _
                                                 stFPCOGAS & stSeparador & _
                                                 stFPCOPISO & stSeparador & _
                                                 stFPCOPOCO & stSeparador & _
                                                 stFPCOEDCO)

                                    ' Incrementa la barra
                                    inProceso = inProceso + 1
                                    pbProcesoActualizacion.Value = inProceso

                                End If

                            Next

                        Next

                        '===================================
                        '*** ID : 4 EXPORTA CALIFICACIÓN ***
                        '===================================

                        Dim f As Integer = 0

                        For f = 0 To dt_FR_1_Y_2.Rows.Count - 1

                            ' crea la tabla
                            tblCalificacion = New DataTable

                            ' almacena consulta
                            tblCalificacion = objCalificacion.fun_Consultar_FIPRCACO_X_FICHA_PREDIAL_TODAS_LAS_UNIDADES(dt_FR_1_Y_2.Rows(f).Item("FIPRNUFI"))

                            ' recorro la tabla
                            Dim d As Integer = 0

                            For d = 0 To tblCalificacion.Rows.Count - 1

                                ' verifica que se encuentre activa
                                If Trim(tblCalificacion.Rows(d).Item("FPCCESTA").ToString) = "ac" Then

                                    ' instancia la clase
                                    objCedula = New cla_FICHPRED
                                    tblCedula = New DataTable

                                    tblCedula = objCedula.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(tblCalificacion.Rows(d).Item("FPCCNUFI"))

                                    ' variables directas
                                    Dim stFPCCIDRE As String = "4"
                                    Dim stFPCCMUNI As String = Trim(tblCedula.Rows(0).Item("FIPRMUNI").ToString)
                                    Dim stFPCCCLSE As String = Trim(tblCedula.Rows(0).Item("FIPRCLSE").ToString)
                                    Dim stFPCCCORR As String = Trim(tblCedula.Rows(0).Item("FIPRCORR").ToString)
                                    Dim stFPCCBARR As String = Trim(tblCedula.Rows(0).Item("FIPRBARR").ToString)
                                    Dim stFPCCMANZ As String = Trim(tblCedula.Rows(0).Item("FIPRMANZ").ToString)
                                    Dim stFPCCPRED As String = Trim(tblCedula.Rows(0).Item("FIPRPRED").ToString)
                                    Dim stFPCCEDIF As String = Trim(tblCedula.Rows(0).Item("FIPREDIF").ToString)

                                    Dim stFPCCUNID As String = Trim(tblCalificacion.Rows(d).Item("FPCCUNID").ToString)
                                    Dim stFPCCCODI As String = Trim(tblCalificacion.Rows(d).Item("FPCCCODI").ToString)
                                    Dim stFPCCTIPO As String = Trim(tblCalificacion.Rows(d).Item("FPCCTIPO").ToString)
                                    Dim stFPCCPUNT As String = Trim(tblCalificacion.Rows(d).Item("FPCCPUNT").ToString)

                                    If Me.chkEdificioEnCeros.Checked = True Then
                                        stFPCCEDIF = "000"
                                    End If

                                    ' formato municipio actual
                                    stFPCCMUNI = stFPCCMUNI.PadLeft(3, "0")
                                    stFPCCMUNI = stFPCCMUNI.Substring(0, 3)

                                    ' formato clase o sector actual
                                    stFPCCCLSE = stFPCCCLSE.PadLeft(1, "0")
                                    stFPCCCLSE = stFPCCCLSE.Substring(0, 1)

                                    ' formato corregimiento actual
                                    stFPCCCORR = stFPCCCORR.PadLeft(3, "0")
                                    stFPCCCORR = stFPCCCORR.Substring(0, 3)

                                    ' formato barrio actual
                                    stFPCCBARR = stFPCCBARR.PadLeft(3, "0")
                                    stFPCCBARR = stFPCCBARR.Substring(0, 3)

                                    ' formato manzana actual
                                    stFPCCMANZ = stFPCCMANZ.PadLeft(3, "0")
                                    stFPCCMANZ = stFPCCMANZ.Substring(0, 3)

                                    ' formato predio actual
                                    stFPCCPRED = stFPCCPRED.PadLeft(5, "0")
                                    stFPCCPRED = stFPCCPRED.Substring(0, 5)

                                    ' formato edificio
                                    stFPCCEDIF = stFPCCEDIF.PadLeft(5, "0")
                                    stFPCCEDIF = stFPCCEDIF.Substring(0, 5)

                                    ' formato unidad 
                                    stFPCCUNID = stFPCCUNID.PadLeft(5, "0")
                                    stFPCCUNID = stFPCCUNID.Substring(0, 5)

                                    ' formato código de calificación
                                    stFPCCCODI = stFPCCCODI.PadLeft(3, "0")
                                    stFPCCCODI = stFPCCCODI.Substring(0, 3)

                                    ' formato tipo de calificación
                                    stFPCCTIPO = stFPCCTIPO.PadRight(1, " ")
                                    stFPCCTIPO = stFPCCTIPO.Substring(0, 1)

                                    ' formato puntos
                                    stFPCCPUNT = stFPCCPUNT.PadLeft(3, "0")
                                    stFPCCPUNT = stFPCCPUNT.Substring(0, 3)

                                    ' exportar los datos
                                    PrintLine(1, stFPCCIDRE & stSeparador & _
                                                 stFPCCMUNI & stSeparador & _
                                                 stFPCCCLSE & stSeparador & _
                                                 stFPCCCORR & stSeparador & _
                                                 stFPCCBARR & stSeparador & _
                                                 stFPCCMANZ & stSeparador & _
                                                 stFPCCPRED & stSeparador & _
                                                 stFPCCEDIF & stSeparador & _
                                                 stFPCCUNID & stSeparador & _
                                                 stFPCCCODI & stSeparador & _
                                                 stFPCCTIPO & stSeparador & _
                                                 stFPCCPUNT)

                                    ' Incrementa la barra
                                    inProceso = inProceso + 1
                                    pbProcesoActualizacion.Value = inProceso

                                End If

                            Next

                        Next

                        '==================================
                        '*** ID : 5 EXPORTA CARTOGRAFIA ***
                        '==================================

                        Dim r As Integer = 0

                        For r = 0 To dt_FR_1_Y_2.Rows.Count - 1

                            ' crea la tabla
                            tblCartografia = New DataTable

                            ' almacena consulta
                            tblCartografia = objCartografia.fun_Consultar_FIPRCART_X_FICHA_PREDIAL(dt_FR_1_Y_2.Rows(r).Item("FIPRNUFI"))

                            ' recorro la tabla
                            Dim d As Integer = 0

                            For d = 0 To tblCartografia.Rows.Count - 1

                                ' verifica que se encuentre activa
                                If Trim(tblCartografia.Rows(d).Item("FPCAESTA").ToString) = "ac" Then

                                    ' instancia la clase
                                    objCedula = New cla_FICHPRED
                                    tblCedula = New DataTable

                                    tblCedula = objCedula.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(tblCartografia.Rows(d).Item("FPCANUFI"))

                                    ' variables directas
                                    Dim stFPCAIDRE As String = "5"
                                    Dim stFPCAMUNI As String = Trim(tblCedula.Rows(0).Item("FIPRMUNI").ToString)
                                    Dim stFPCACLSE As String = Trim(tblCedula.Rows(0).Item("FIPRCLSE").ToString)
                                    Dim stFPCACORR As String = Trim(tblCedula.Rows(0).Item("FIPRCORR").ToString)
                                    Dim stFPCABARR As String = Trim(tblCedula.Rows(0).Item("FIPRBARR").ToString)
                                    Dim stFPCAMANZ As String = Trim(tblCedula.Rows(0).Item("FIPRMANZ").ToString)
                                    Dim stFPCAPRED As String = Trim(tblCedula.Rows(0).Item("FIPRPRED").ToString)
                                    Dim stFPCAEDIF As String = Trim(tblCedula.Rows(0).Item("FIPREDIF").ToString)
                                    Dim stFPCAPLAN As String = Trim(tblCartografia.Rows(d).Item("FPCAPLAN").ToString)
                                    Dim stFPCAVENT As String = Trim(tblCartografia.Rows(d).Item("FPCAVENT").ToString)
                                    Dim stFPCAESGR As String = Trim(tblCartografia.Rows(d).Item("FPCAESGR").ToString)
                                    Dim stFPCAVIGR As String = Trim(tblCartografia.Rows(d).Item("FPCAVIGR").ToString)
                                    Dim stFPCAVUEL As String = Trim(tblCartografia.Rows(d).Item("FPCAVUEL").ToString)
                                    Dim stFPCAFAJA As String = Trim(tblCartografia.Rows(d).Item("FPCAFAJA").ToString)
                                    Dim stFPCAFOTO As String = Trim(tblCartografia.Rows(d).Item("FPCAFOTO").ToString)
                                    Dim stFPCAVIAE As String = Trim(tblCartografia.Rows(d).Item("FPCAVIAE").ToString)
                                    Dim stFPCAAMPL As String = Trim(tblCartografia.Rows(d).Item("FPCAAMPL").ToString)
                                    Dim stFPCAESAE As String = Trim(tblCartografia.Rows(d).Item("FPCAESAE").ToString)

                                    If Me.chkEdificioEnCeros.Checked = True Then
                                        stFPCAEDIF = "000"
                                    End If

                                    ' formato municipio actual
                                    stFPCAMUNI = stFPCAMUNI.PadLeft(3, "0")
                                    stFPCAMUNI = stFPCAMUNI.Substring(0, 3)

                                    ' formato clase o sector actual
                                    stFPCACLSE = stFPCACLSE.PadLeft(1, "0")
                                    stFPCACLSE = stFPCACLSE.Substring(0, 1)

                                    ' formato corregimiento actual
                                    stFPCACORR = stFPCACORR.PadLeft(3, "0")
                                    stFPCACORR = stFPCACORR.Substring(0, 3)

                                    ' formato barrio actual
                                    stFPCABARR = stFPCABARR.PadLeft(3, "0")
                                    stFPCABARR = stFPCABARR.Substring(0, 3)

                                    ' formato manzana actual
                                    stFPCAMANZ = stFPCAMANZ.PadLeft(3, "0")
                                    stFPCAMANZ = stFPCAMANZ.Substring(0, 3)

                                    ' formato predio actual
                                    stFPCAPRED = stFPCAPRED.PadLeft(5, "0")
                                    stFPCAPRED = stFPCAPRED.Substring(0, 5)

                                    ' formato edificio
                                    stFPCAEDIF = stFPCAEDIF.PadLeft(5, "0")
                                    stFPCAEDIF = stFPCAEDIF.Substring(0, 5)

                                    ' formato plancha
                                    stFPCAPLAN = stFPCAPLAN.PadRight(15, " ")
                                    stFPCAPLAN = stFPCAPLAN.Substring(0, 15)

                                    ' formato ventana
                                    stFPCAVENT = stFPCAVENT.PadRight(15, " ")
                                    stFPCAVENT = stFPCAVENT.Substring(0, 15)

                                    ' formato escala grafica
                                    stFPCAESGR = stFPCAESGR.PadRight(15, " ")
                                    stFPCAESGR = stFPCAESGR.Substring(0, 15)

                                    ' formato vigencia grafica
                                    stFPCAVIGR = stFPCAVIGR.PadLeft(4, "0")
                                    stFPCAVIGR = stFPCAVIGR.Substring(0, 4)

                                    ' formato vuelo
                                    stFPCAVUEL = stFPCAVUEL.PadRight(15, " ")
                                    stFPCAVUEL = stFPCAVUEL.Substring(0, 15)

                                    ' formato faja
                                    stFPCAFAJA = stFPCAFAJA.PadRight(15, " ")
                                    stFPCAFAJA = stFPCAFAJA.Substring(0, 15)

                                    ' formato foto
                                    stFPCAFOTO = stFPCAFOTO.PadRight(15, " ")
                                    stFPCAFOTO = stFPCAFOTO.Substring(0, 15)

                                    ' formato vigencia aerofotografica
                                    stFPCAVIAE = stFPCAVIAE.PadLeft(4, "0")
                                    stFPCAVIAE = stFPCAVIAE.Substring(0, 4)

                                    ' formato ampliación
                                    stFPCAAMPL = stFPCAAMPL.PadRight(15, " ")
                                    stFPCAAMPL = stFPCAAMPL.Substring(0, 15)

                                    ' formato escala aerofotografica
                                    stFPCAESAE = stFPCAESAE.PadRight(15, " ")
                                    stFPCAESAE = stFPCAESAE.Substring(0, 15)

                                    ' exportar los datos
                                    PrintLine(1, stFPCAIDRE & stSeparador & _
                                                 stFPCAMUNI & stSeparador & _
                                                 stFPCACLSE & stSeparador & _
                                                 stFPCACORR & stSeparador & _
                                                 stFPCABARR & stSeparador & _
                                                 stFPCAMANZ & stSeparador & _
                                                 stFPCAPRED & stSeparador & _
                                                 stFPCAEDIF & stSeparador & _
                                                 stFPCAPLAN & stSeparador & _
                                                 stFPCAVENT & stSeparador & _
                                                 stFPCAESGR & stSeparador & _
                                                 stFPCAVIGR & stSeparador & _
                                                 stFPCAVUEL & stSeparador & _
                                                 stFPCAFAJA & stSeparador & _
                                                 stFPCAFOTO & stSeparador & _
                                                 stFPCAVIAE & stSeparador & _
                                                 stFPCAAMPL & stSeparador & _
                                                 stFPCAESAE)

                                    ' Incrementa la barra
                                    inProceso = inProceso + 1
                                    pbProcesoActualizacion.Value = inProceso

                                End If

                            Next

                        Next

                        '===============================
                        '*** ID : 6 EXPORTA LINDEROS ***
                        '===============================

                        Dim w As Integer = 0

                        For w = 0 To dt_FR_1_Y_2.Rows.Count - 1

                            ' crea la tabla
                            tblLinderos = New DataTable

                            ' almacena consulta
                            tblLinderos = objLinderos.fun_Consultar_FIPRLIND_X_FICHA_PREDIAL(dt_FR_1_Y_2.Rows(w).Item("FIPRNUFI"))

                            ' recorro la tabla
                            Dim d As Integer = 0

                            For d = 0 To tblLinderos.Rows.Count - 1

                                ' verifica que se encuentre activa
                                If Trim(tblLinderos.Rows(d).Item("FPLIESTA").ToString) = "ac" Then

                                    ' instancia la clase
                                    objCedula = New cla_FICHPRED
                                    tblCedula = New DataTable

                                    tblCedula = objCedula.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(tblLinderos.Rows(d).Item("FPLINUFI"))

                                    ' variables directas
                                    Dim stFPLIIDRE As String = "6"
                                    Dim stFPLIMUNI As String = Trim(tblCedula.Rows(0).Item("FIPRMUNI").ToString)
                                    Dim stFPLICLSE As String = Trim(tblCedula.Rows(0).Item("FIPRCLSE").ToString)
                                    Dim stFPLICORR As String = Trim(tblCedula.Rows(0).Item("FIPRCORR").ToString)
                                    Dim stFPLIBARR As String = Trim(tblCedula.Rows(0).Item("FIPRBARR").ToString)
                                    Dim stFPLIMANZ As String = Trim(tblCedula.Rows(0).Item("FIPRMANZ").ToString)
                                    Dim stFPLIPRED As String = Trim(tblCedula.Rows(0).Item("FIPRPRED").ToString)
                                    Dim stFPLIEDIF As String = Trim(tblCedula.Rows(0).Item("FIPREDIF").ToString)
                                    Dim stFPLIPUCA As String = Trim(tblLinderos.Rows(d).Item("FPLIPUCA").ToString)
                                    Dim stFPLICOLI As String = Trim(tblLinderos.Rows(d).Item("FPLICOLI").ToString)

                                    If Me.chkEdificioEnCeros.Checked = True Then
                                        stFPLIEDIF = "000"
                                    End If

                                    ' formato municipio actual
                                    stFPLIMUNI = stFPLIMUNI.PadLeft(3, "0")
                                    stFPLIMUNI = stFPLIMUNI.Substring(0, 3)

                                    ' formato clase o sector actual
                                    stFPLICLSE = stFPLICLSE.PadLeft(1, "0")
                                    stFPLICLSE = stFPLICLSE.Substring(0, 1)

                                    ' formato corregimiento actual
                                    stFPLICORR = stFPLICORR.PadLeft(3, "0")
                                    stFPLICORR = stFPLICORR.Substring(0, 3)

                                    ' formato barrio actual
                                    stFPLIBARR = stFPLIBARR.PadLeft(3, "0")
                                    stFPLIBARR = stFPLIBARR.Substring(0, 3)

                                    ' formato manzana actual
                                    stFPLIMANZ = stFPLIMANZ.PadLeft(3, "0")
                                    stFPLIMANZ = stFPLIMANZ.Substring(0, 3)

                                    ' formato predio actual
                                    stFPLIPRED = stFPLIPRED.PadLeft(5, "0")
                                    stFPLIPRED = stFPLIPRED.Substring(0, 5)

                                    ' formato edificio
                                    stFPLIEDIF = stFPLIEDIF.PadLeft(5, "0")
                                    stFPLIEDIF = stFPLIEDIF.Substring(0, 5)

                                    ' formato punto cardinal
                                    stFPLIPUCA = stFPLIPUCA.PadRight(2, " ")
                                    stFPLIPUCA = stFPLIPUCA.Substring(0, 2)

                                    ' formato colindante
                                    stFPLICOLI = stFPLICOLI.PadRight(30, " ")
                                    stFPLICOLI = stFPLICOLI.Substring(0, 30)

                                    ' exportar los datos
                                    PrintLine(1, stFPLIIDRE & stSeparador & _
                                                 stFPLIMUNI & stSeparador & _
                                                 stFPLICLSE & stSeparador & _
                                                 stFPLICORR & stSeparador & _
                                                 stFPLIBARR & stSeparador & _
                                                 stFPLIMANZ & stSeparador & _
                                                 stFPLIPRED & stSeparador & _
                                                 stFPLIEDIF & stSeparador & _
                                                 stFPLIPUCA & stSeparador & _
                                                 stFPLICOLI)

                                    ' Incrementa la barra
                                    inProceso = inProceso + 1
                                    pbProcesoActualizacion.Value = inProceso

                                End If

                            Next

                        Next

                        ' coloca la barra en cero
                        pbProcesoActualizacion.Value = 0

                        MessageBox.Show("Archivo plano creado corectamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                        ' prende el boton
                        Me.cmdExportarPlanoActualizacion.Enabled = True

                        If MessageBox.Show("¿ Desea abrir el archivo plano ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                            ' Abrir con Process.Start el archivo de texto
                            Process.Start(stRutaArchivoActualizacion)
                        End If

                    Else
                        MessageBox.Show("No existen registros en base de datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        cmdExportarPlanoActualizacion.Focus()
                    End If

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub

    Private Sub pro_ExportarPlanoFichaPredialAdministrativa()

        Try
            ' verifica si se a seleccionado una resolución
            If Me.txtREADRESO.Text = "" Then
                MessageBox.Show("Seleccione una resolución administrativa", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                ' verifica la ruta del acchivo
                If Trim(stRutaArchivoAdministrativa) <> "" Then

                    ' recorre el archivo a exportar
                    FileOpen(1, oCrear.FileName, OpenMode.Output) 'crea y destruye si hay otro igual

                    ' variable separador
                    Dim stSeparador As String = Trim(Me.txtSEPARADOR.Text)

                    ' apaga el boton
                    Me.cmdExportarPlanoAdministrativa.Enabled = False

                    '==========================
                    '*** GENERA LA CONSULTA ***
                    '==========================

                    ' crea un datable
                    dt = New DataTable

                    ' llena el datatable con la consulta
                    dt = fun_EjecutarConsultaFichaPredialAdministrativa()

                    '============================
                    '*** CUENTA LOS REGISTROS ***
                    '============================

                    Dim objdatos As New cla_VALIFIPR
                    Dim ds As New DataSet

                    ds = objdatos.fun_Consultar_NRO_REGISTROS_DE_EXPORTACION_RESOADMI(Me.txtREADTIRE.Text, _
                                                                                      Me.txtREADCLSE.Text, _
                                                                                      Me.txtREADVIGE.Text, _
                                                                                      Val(Me.txtREADRESO.Text))

                    ' crea nuevos datatable
                    dt_FICHPRED = New DataTable
                    dt_FIPRDEEC = New DataTable
                    dt_FIPRPROP = New DataTable
                    dt_FIPRCONS = New DataTable
                    dt_FIPRCACO = New DataTable
                    dt_FIPRLIND = New DataTable
                    dt_FIPRCART = New DataTable

                    ' almacena la información
                    dt_FICHPRED = ds.Tables(0)
                    dt_FIPRDEEC = ds.Tables(1)
                    dt_FIPRPROP = ds.Tables(2)
                    dt_FIPRCONS = ds.Tables(3)
                    dt_FIPRCACO = ds.Tables(4)
                    dt_FIPRLIND = ds.Tables(5)
                    dt_FIPRCART = ds.Tables(6)

                    ' cuenta los registros
                    Dim in_Nro_Registros_FICHPRED As Integer = dt_FICHPRED.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRDEEC As Integer = dt_FIPRDEEC.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRPROP As Integer = dt_FIPRPROP.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRCONS As Integer = dt_FIPRCONS.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRCACO As Integer = dt_FIPRCACO.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRLIND As Integer = dt_FIPRLIND.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRCART As Integer = dt_FIPRCART.Rows(0).Item(0)

                    '==================
                    '*** RESOLUCIÓN ***
                    '==================

                    ' crea la tabla 
                    tblResolucion = New DataTable

                    ' almacena la consulta
                    tblResolucion = objResolucion.fun_Buscar_TIPO_Y_CLASE_Y_VIGENCIA_Y_RESOLUCION(txtREADRESO.Text, txtREADTIRE.Text, txtREADCLSE.Text, txtREADVIGE.Text)

                    ' variales directas
                    Dim stRESOIDRE As String = "1"
                    Dim stRESOVIGE As String = CInt(Trim(Me.txtREADVIGE.Text))
                    Dim stRESOTIRE As String = CInt(Trim(Me.txtREADTIRE.Text))
                    Dim stRESORESO As String = CInt(Trim(Me.txtREADRESO.Text))
                    Dim stRESOMUNI As String = "266"
                    Dim stRESOCLSE As String = CInt(Trim(Me.txtREADCLSE.Text))
                    Dim stRESONURE As String = "0"
                    Dim stRESOARTE As String = "0"
                    Dim stRESOARCO As String = "0"
                    Dim stRESOSUPU As String = "0"
                    Dim boRESOTOPA As Boolean = "0"

                    ' variables indirectas
                    Dim stRESOTOPA As String = ""

                    ' parcial o total
                    If boRESOTOPA = False Then
                        stRESOTOPA = 2
                    Else
                        stRESOTOPA = 1
                    End If

                    ' formato vigencia
                    stRESOVIGE = stRESOVIGE.PadLeft(4, "0")
                    stRESOVIGE = stRESOVIGE.Substring(0, 4)

                    ' formato tipo de resolución
                    stRESOTIRE = stRESOTIRE.PadLeft(3, "0")
                    stRESOTIRE = stRESOTIRE.Substring(0, 3)

                    ' formato resolución
                    stRESORESO = stRESORESO.PadLeft(7, "0")
                    stRESORESO = stRESORESO.Substring(0, 7)

                    ' formato municipio
                    stRESOMUNI = stRESOMUNI.PadLeft(3, "0")
                    stRESOMUNI = stRESOMUNI.Substring(0, 3)

                    ' formato clase o sector
                    stRESOCLSE = stRESOCLSE.PadLeft(1, "0")
                    stRESOCLSE = stRESOCLSE.Substring(0, 1)

                    ' formato numero de registro
                    stRESONURE = stRESONURE.PadLeft(7, "0")
                    stRESONURE = stRESONURE.Substring(0, 7)

                    ' formato área de terreno
                    stRESOARTE = stRESOARTE.Replace(".", "")
                    stRESOARTE = stRESOARTE.PadLeft(12, "0")
                    stRESOARTE = stRESOARTE.Substring(0, 12)

                    ' formato área de construcción
                    stRESOARCO = stRESOARCO.Replace(".", "")
                    stRESOARCO = stRESOARCO.PadLeft(10, "0")
                    stRESOARCO = stRESOARCO.Substring(0, 10)

                    ' formato suma de puntos
                    stRESOSUPU = stRESOSUPU.PadLeft(10, "0")
                    stRESOSUPU = stRESOSUPU.Substring(0, 10)

                    ' formato parcial o total
                    stRESOTOPA = stRESOTOPA.PadLeft(1, "0")
                    stRESOTOPA = stRESOTOPA.Substring(0, 1)

                    ' exportar los datos
                    PrintLine(1, stRESOIDRE & stSeparador & _
                                 stRESOVIGE & stSeparador & _
                                 stRESOTIRE & stSeparador & _
                                 stRESORESO & stSeparador & _
                                 stRESOMUNI & stSeparador & _
                                 stRESOCLSE & stSeparador & _
                                 stRESONURE & stSeparador & _
                                 stRESOARTE & stSeparador & _
                                 stRESOARCO & stSeparador & _
                                 stRESOSUPU & stSeparador & _
                                 stRESOTOPA)


                    ' recorre la consulta
                    If dt.Rows.Count > 0 Then

                        ' carga la barra de progreso
                        inProceso = 0
                        pbProcesoAdministrativa.Value = 0
                        pbProcesoAdministrativa.Maximum = dt.Rows.Count
                        Timer1.Enabled = True

                        '=============================
                        '*** EXPORTA FICHA PREDIAL ***
                        '=============================

                        Dim i As Integer = 0

                        For i = 0 To dt.Rows.Count - 1

                            ' crea la tabla
                            tblFichaPredial = New DataTable

                            ' almacena consulta
                            tblFichaPredial = objFichaPredial.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dt.Rows(i).Item("FIPRNUFI"))

                            ' variables directas
                            Dim stFIPRIDRE As String = "2"
                            Dim stFIPRVIGE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRVIGE").ToString)
                            Dim stFIPRTIRE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRTIRE").ToString)
                            Dim stFIPRRESO As String = Trim(tblFichaPredial.Rows(0).Item("FIPRRESO").ToString)
                            Dim stFIPRNUFI As String = Trim(tblFichaPredial.Rows(0).Item("FIPRNUFI").ToString)
                            Dim stFIPRNURE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRNURE").ToString)
                            Dim stFIPRMUNI As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMUNI").ToString)
                            Dim stFIPRCLSE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCLSE").ToString)
                            Dim stFIPRCORR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCORR").ToString)
                            Dim stFIPRBARR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRBARR").ToString)
                            Dim stFIPRMANZ As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMANZ").ToString)
                            Dim stFIPRPRED As String = Trim(tblFichaPredial.Rows(0).Item("FIPRPRED").ToString)
                            Dim stFIPREDIF As String = Trim(tblFichaPredial.Rows(0).Item("FIPREDIF").ToString)
                            Dim stFIPRUNPR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRUNPR").ToString)
                            Dim stFIPRARTE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRARTE").ToString)
                            Dim stFIPRDIRE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRDIRE").ToString)
                            Dim stFIPRCAPR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCAPR").ToString)
                            Dim stFIPRCASU As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCASU").ToString)
                            Dim stFIPRCOPR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCOPR").ToString)
                            Dim stFIPRCOED As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCOED").ToString)
                            Dim stFIPRMUAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMUAN").ToString)
                            Dim stFIPRCSAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCSAN").ToString)
                            Dim stFIPRCOAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCOAN").ToString)
                            Dim stFIPRBAAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRBAAN").ToString)
                            Dim stFIPRMAAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMAAN").ToString)
                            Dim stFIPRPRAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRPRAN").ToString)
                            Dim stFIPREDAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPREDAN").ToString)
                            Dim stFIPRUPAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRUPAN").ToString)
                            Dim stFIPRCASA As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCASA").ToString)

                            ' formato vigencia
                            stFIPRVIGE = stFIPRVIGE.PadLeft(4, "0")
                            stFIPRVIGE = stFIPRVIGE.Substring(0, 4)

                            ' formato tipo de resolución
                            stFIPRTIRE = stFIPRTIRE.PadLeft(3, "0")
                            stFIPRTIRE = stFIPRTIRE.Substring(0, 3)

                            ' formato resolución
                            stFIPRRESO = stFIPRRESO.PadLeft(7, "0")
                            stFIPRRESO = stFIPRRESO.Substring(0, 7)

                            ' formato numero de ficha
                            stFIPRNUFI = stFIPRNUFI.PadLeft(9, "0")
                            stFIPRNUFI = stFIPRNUFI.Substring(0, 9)

                            ' formato numero de registro
                            stFIPRNURE = stFIPRNURE.PadLeft(5, "0")
                            stFIPRNURE = stFIPRNURE.Substring(0, 5)

                            ' formato municipio actual
                            stFIPRMUNI = stFIPRMUNI.PadLeft(3, "0")
                            stFIPRMUNI = stFIPRMUNI.Substring(0, 3)

                            ' formato clase o sector actual
                            stFIPRCLSE = stFIPRCLSE.PadLeft(1, "0")
                            stFIPRCLSE = stFIPRCLSE.Substring(0, 1)

                            ' formato corregimiento actual
                            stFIPRCORR = stFIPRCORR.PadLeft(3, "0")
                            stFIPRCORR = stFIPRCORR.Substring(0, 3)

                            ' formato barrio actual
                            stFIPRBARR = stFIPRBARR.PadLeft(3, "0")
                            stFIPRBARR = stFIPRBARR.Substring(0, 3)

                            ' formato manzana actual
                            stFIPRMANZ = stFIPRMANZ.PadLeft(3, "0")
                            stFIPRMANZ = stFIPRMANZ.Substring(0, 3)

                            ' formato predio actual
                            stFIPRPRED = stFIPRPRED.PadLeft(5, "0")
                            stFIPRPRED = stFIPRPRED.Substring(0, 5)

                            ' formato edificio actual
                            stFIPREDIF = stFIPREDIF.PadLeft(5, "0")
                            stFIPREDIF = stFIPREDIF.Substring(0, 5)

                            ' formato unidad predial actual
                            stFIPRUNPR = stFIPRUNPR.PadLeft(5, "0")
                            stFIPRUNPR = stFIPRUNPR.Substring(0, 5)

                            ' formato área de terreno
                            stFIPRARTE = stFIPRARTE.PadLeft(10, "0")
                            stFIPRARTE = stFIPRARTE.Substring(0, 10)

                            ' formato dirección
                            stFIPRDIRE = stFIPRDIRE.PadRight(49, " ")
                            stFIPRDIRE = stFIPRDIRE.Substring(0, 49)

                            ' formato caracteristica de predio
                            stFIPRCAPR = stFIPRCAPR.PadLeft(1, "0")
                            stFIPRCAPR = stFIPRCAPR.Substring(0, 1)

                            ' formato categoria de suelo
                            stFIPRCASU = stFIPRCASU.PadLeft(1, "0")
                            stFIPRCASU = stFIPRCASU.Substring(0, 1)

                            ' formato coeficiente de predio
                            stFIPRCOPR = stFIPRCOPR.Replace(".", "")
                            stFIPRCOPR = stFIPRCOPR.PadLeft(9, "0")
                            stFIPRCOPR = stFIPRCOPR.Substring(0, 9)

                            ' formato coeficiente de edificio
                            stFIPRCOED = stFIPRCOED.Replace(".", "")
                            stFIPRCOED = stFIPRCOED.PadLeft(9, "0")
                            stFIPRCOED = stFIPRCOED.Substring(0, 9)

                            ' formato municipio anterior
                            stFIPRMUAN = stFIPRMUAN.PadLeft(3, "0")
                            stFIPRMUAN = stFIPRMUAN.Substring(0, 3)

                            ' formato clase o sector anterior
                            stFIPRCSAN = stFIPRCSAN.PadLeft(1, "0")
                            stFIPRCSAN = stFIPRCSAN.Substring(0, 1)

                            ' formato corregimiento anterior
                            stFIPRCOAN = stFIPRCOAN.PadLeft(3, "0")
                            stFIPRCOAN = stFIPRCOAN.Substring(0, 3)

                            ' formato barrio anterior
                            stFIPRBAAN = stFIPRBAAN.PadLeft(3, "0")
                            stFIPRBAAN = stFIPRBAAN.Substring(0, 3)

                            ' formato manzana anterior
                            stFIPRMAAN = stFIPRMAAN.PadLeft(3, "0")
                            stFIPRMAAN = stFIPRMAAN.Substring(0, 3)

                            ' formato predio anterior
                            stFIPRPRAN = stFIPRPRAN.PadLeft(5, "0")
                            stFIPRPRAN = stFIPRPRAN.Substring(0, 5)

                            ' formato edificio anterior
                            stFIPREDAN = stFIPREDAN.PadLeft(5, "0")
                            stFIPREDAN = stFIPREDAN.Substring(0, 5)

                            ' formato unidad predial anterior
                            stFIPRUPAN = stFIPRUPAN.PadLeft(5, "0")
                            stFIPRUPAN = stFIPRUPAN.Substring(0, 5)

                            ' formato clasificador de suelo anterior
                            stFIPRCASA = stFIPRCASA.PadLeft(1, "0")
                            stFIPRCASA = stFIPRCASA.Substring(0, 1)

                            ' exportar los datos
                            PrintLine(1, stFIPRIDRE & stSeparador & _
                                         stFIPRVIGE & stSeparador & _
                                         stFIPRTIRE & stSeparador & _
                                         stFIPRRESO & stSeparador & _
                                         stFIPRNUFI & stSeparador & _
                                         stFIPRNURE & stSeparador & _
                                         stFIPRMUNI & stSeparador & _
                                         stFIPRCLSE & stSeparador & _
                                         stFIPRCORR & stSeparador & _
                                         stFIPRBARR & stSeparador & _
                                         stFIPRMANZ & stSeparador & _
                                         stFIPRPRED & stSeparador & _
                                         stFIPREDIF & stSeparador & _
                                         stFIPRUNPR & stSeparador & _
                                         stFIPRARTE & stSeparador & _
                                         stFIPRDIRE & stSeparador & _
                                         stFIPRCAPR & stSeparador & _
                                         stFIPRCASU & stSeparador & _
                                         stFIPRCOPR & stSeparador & _
                                         stFIPRCOED & stSeparador & _
                                         stFIPRMUAN & stSeparador & _
                                         stFIPRCSAN & stSeparador & _
                                         stFIPRCOAN & stSeparador & _
                                         stFIPRBAAN & stSeparador & _
                                         stFIPRMAAN & stSeparador & _
                                         stFIPRPRAN & stSeparador & _
                                         stFIPREDAN & stSeparador & _
                                         stFIPRUPAN & stSeparador & _
                                         stFIPRCASA)

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbProcesoAdministrativa.Value = inProceso

                        Next

                        ' limpia la barra de progreso
                        pbProcesoAdministrativa.Value = 0

                        '=====================================
                        '*** EXPORTA DESTINACIÓN ECONÓMICA ***
                        '=====================================

                        ' carga la barra de progreso
                        inProceso = 0
                        pbProcesoAdministrativa.Value = 0
                        pbProcesoAdministrativa.Maximum = dt.Rows.Count
                        Timer1.Enabled = True

                        Dim k As Integer = 0

                        For k = 0 To dt.Rows.Count - 1

                            ' crea la tabla
                            tblDestino = New DataTable

                            ' almacena consulta
                            tblDestino = objDestino.fun_Consultar_FIPRDEEC_X_FICHA_PREDIAL(dt.Rows(k).Item("FIPRNUFI"))

                            Dim a As Integer = 0

                            For a = 0 To tblDestino.Rows.Count - 1

                                ' verifica que se encuentre activa
                                If Trim(tblDestino.Rows(a).Item("FPDEESTA").ToString) = "ac" Then

                                    ' variables directas
                                    Dim stFPDEIDRE As String = "3"
                                    Dim stFPDEVIGE As String = Trim(tblDestino.Rows(a).Item("FPDEVIGE").ToString)
                                    Dim stFPDETIRE As String = Trim(tblDestino.Rows(a).Item("FPDETIRE").ToString)
                                    Dim stFPDERESO As String = Trim(tblDestino.Rows(a).Item("FPDERESO").ToString)
                                    Dim stFPDENUFI As String = Trim(tblDestino.Rows(a).Item("FPDENUFI").ToString)
                                    Dim stFPDENURE As String = Trim(tblDestino.Rows(a).Item("FPDENURE").ToString)
                                    Dim stFPDEDEEC As String = Trim(tblDestino.Rows(a).Item("FPDEDEEC").ToString)
                                    Dim stFPDEPORC As String = Trim(tblDestino.Rows(a).Item("FPDEPORC").ToString)

                                    ' formato vigencia
                                    stFPDEVIGE = stFPDEVIGE.PadLeft(4, "0")
                                    stFPDEVIGE = stFPDEVIGE.Substring(0, 4)

                                    ' formato tipo de resolución
                                    stFPDETIRE = stFPDETIRE.PadLeft(3, "0")
                                    stFPDETIRE = stFPDETIRE.Substring(0, 3)

                                    ' formato resolución
                                    stFPDERESO = stFPDERESO.PadLeft(7, "0")
                                    stFPDERESO = stFPDERESO.Substring(0, 7)

                                    ' formato numero de ficha
                                    stFPDENUFI = stFPDENUFI.PadLeft(9, "0")
                                    stFPDENUFI = stFPDENUFI.Substring(0, 9)

                                    ' formato numero de registro
                                    stFPDENURE = stFPDENURE.PadLeft(5, "0")
                                    stFPDENURE = stFPDENURE.Substring(0, 5)

                                    ' formato destinación
                                    stFPDEDEEC = stFPDEDEEC.PadLeft(2, "0")
                                    stFPDEDEEC = stFPDEDEEC.Substring(0, 2)

                                    ' formato porcentaje
                                    stFPDEPORC = stFPDEPORC.PadLeft(3, "0")
                                    stFPDEPORC = stFPDEPORC.Substring(0, 3)

                                    ' exportar los datos
                                    PrintLine(1, stFPDEIDRE & stSeparador & _
                                                 stFPDEVIGE & stSeparador & _
                                                 stFPDETIRE & stSeparador & _
                                                 stFPDERESO & stSeparador & _
                                                 stFPDENUFI & stSeparador & _
                                                 stFPDENURE & stSeparador & _
                                                 stFPDEDEEC & stSeparador & _
                                                 stFPDEPORC)

                                End If

                            Next

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbProcesoAdministrativa.Value = inProceso

                        Next

                        ' limpia la barra de progreso
                        pbProcesoAdministrativa.Value = 0

                        '============================
                        '*** EXPORTA PROPIETARIOS ***
                        '============================

                        ' carga la barra de progreso
                        inProceso = 0
                        pbProcesoAdministrativa.Value = 0
                        pbProcesoAdministrativa.Maximum = dt.Rows.Count
                        Timer1.Enabled = True

                        Dim j As Integer = 0

                        For j = 0 To dt.Rows.Count - 1

                            ' crea la tabla
                            tblPropietarios = New DataTable

                            ' almacena consulta
                            tblPropietarios = objPropietarios.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(dt.Rows(j).Item("FIPRNUFI"))

                            Dim b As Integer = 0

                            For b = 0 To tblPropietarios.Rows.Count - 1

                                ' verifica que se encuentre activa
                                If Trim(tblPropietarios.Rows(b).Item("FPPRESTA").ToString) = "ac" Then

                                    ' variables directas
                                    Dim stFPPRIDRE As String = "4"
                                    Dim stFPPRVIGE As String = Trim(tblPropietarios.Rows(b).Item("FPPRVIGE").ToString)
                                    Dim stFPPRTIRE As String = Trim(tblPropietarios.Rows(b).Item("FPPRTIRE").ToString)
                                    Dim stFPPRRESO As String = Trim(tblPropietarios.Rows(b).Item("FPPRRESO").ToString)
                                    Dim stFPPRNUFI As String = Trim(tblPropietarios.Rows(b).Item("FPPRNUFI").ToString)
                                    Dim stFPPRNURE As String = Trim(tblPropietarios.Rows(b).Item("FPPRNURE").ToString)
                                    Dim stFPPRTIDO As String = Trim(tblPropietarios.Rows(b).Item("FPPRTIDO").ToString)
                                    Dim stFPPRNUDO As String = Trim(tblPropietarios.Rows(b).Item("FPPRNUDO").ToString)
                                    Dim stFPPRPRAP As String = Trim(tblPropietarios.Rows(b).Item("FPPRPRAP").ToString)
                                    Dim stFPPRNOMB As String = Trim(tblPropietarios.Rows(b).Item("FPPRNOMB").ToString)
                                    Dim stFPPRDERE As String = Trim(tblPropietarios.Rows(b).Item("FPPRDERE").ToString)
                                    Dim stFPPRNOTA As String = Trim(tblPropietarios.Rows(b).Item("FPPRDENO").ToString) & Trim(tblPropietarios.Rows(b).Item("FPPRMUNO").ToString) & Trim(tblPropietarios.Rows(b).Item("FPPRNOTA").ToString)
                                    Dim stFPPRESCR As String = Trim(tblPropietarios.Rows(b).Item("FPPRESCR").ToString)
                                    Dim stFPPRFEES As String = Trim(tblPropietarios.Rows(b).Item("FPPRFEES").ToString)
                                    Dim stFPPRFERE As String = Trim(tblPropietarios.Rows(b).Item("FPPRFERE").ToString)
                                    Dim stFPPRTOMO As String = Trim(tblPropietarios.Rows(b).Item("FPPRTOMO").ToString)
                                    Dim stFPPRMAIN As String = Trim(tblPropietarios.Rows(b).Item("FPPRMAIN").ToString)
                                    Dim stFPPRCAPR As String = Trim(tblPropietarios.Rows(b).Item("FPPRCAPR").ToString)
                                    Dim boFPPRGRAV As Boolean = tblPropietarios.Rows(b).Item("FPPRGRAV").ToString
                                    Dim stFPPRMOAD As String = Trim(tblPropietarios.Rows(b).Item("FPPRMOAD").ToString)
                                    Dim boFPPRLITI As Boolean = tblPropietarios.Rows(b).Item("FPPRLITI").ToString
                                    Dim stFPPRPOLI As String = Trim(tblPropietarios.Rows(b).Item("FPPRPOLI").ToString)
                                    Dim stFPPRSEAP As String = Trim(tblPropietarios.Rows(b).Item("FPPRSEAP").ToString)
                                    Dim stFPPRSICO As String = Trim(tblPropietarios.Rows(b).Item("FPPRSICO").ToString)
                                    Dim stFPPRSEXO As String = Trim(tblPropietarios.Rows(b).Item("FPPRSEXO").ToString)

                                    If Not IsDate(stFPPRFEES) Then
                                        stFPPRFEES = "          "
                                    End If

                                    If Not IsDate(stFPPRFERE) Then
                                        stFPPRFERE = "          "
                                    End If

                                    ' variables indirectas
                                    Dim stFPPRGRAV As String = ""
                                    Dim stFPPRLITI As String = ""

                                    ' litigio
                                    If boFPPRLITI = False Then
                                        stFPPRLITI = 2
                                    Else
                                        stFPPRLITI = 1
                                    End If

                                    ' gravable
                                    If boFPPRGRAV = False Then
                                        stFPPRGRAV = 2
                                    Else
                                        stFPPRGRAV = 1
                                    End If

                                    ' tipo de documento
                                    If stFPPRTIDO = 8 And Me.chkGenerarCodigoAsignado.Checked = False Then
                                        stFPPRNUDO = ""
                                    End If

                                    ' formato vigencia
                                    stFPPRVIGE = stFPPRVIGE.PadLeft(4, "0")
                                    stFPPRVIGE = stFPPRVIGE.Substring(0, 4)

                                    ' formato tipo de resolución
                                    stFPPRTIRE = stFPPRTIRE.PadLeft(3, "0")
                                    stFPPRTIRE = stFPPRTIRE.Substring(0, 3)

                                    ' formato resolución
                                    stFPPRRESO = stFPPRRESO.PadLeft(7, "0")
                                    stFPPRRESO = stFPPRRESO.Substring(0, 7)

                                    ' formato numero de ficha
                                    stFPPRNUFI = stFPPRNUFI.PadLeft(9, "0")
                                    stFPPRNUFI = stFPPRNUFI.Substring(0, 9)

                                    ' formato numero de registro
                                    stFPPRNURE = stFPPRNURE.PadLeft(5, "0")
                                    stFPPRNURE = stFPPRNURE.Substring(0, 5)

                                    ' formato tipo de documento
                                    stFPPRTIDO = stFPPRTIDO.PadLeft(2, "0")
                                    stFPPRTIDO = stFPPRTIDO.Substring(0, 2)

                                    ' formato numero de documento
                                    stFPPRNUDO = stFPPRNUDO.PadRight(14, " ")
                                    stFPPRNUDO = stFPPRNUDO.Substring(0, 14)

                                    ' formato primer apellido
                                    stFPPRPRAP = stFPPRPRAP.PadRight(15, " ")
                                    stFPPRPRAP = stFPPRPRAP.Substring(0, 15)

                                    ' formato nombre
                                    stFPPRNOMB = stFPPRNOMB.PadRight(20, " ")
                                    stFPPRNOMB = stFPPRNOMB.Substring(0, 20)

                                    ' formato derecho
                                    stFPPRDERE = stFPPRDERE.Replace(".", "")
                                    stFPPRDERE = stFPPRDERE.PadLeft(9, "0")
                                    stFPPRDERE = stFPPRDERE.Substring(0, 9)

                                    ' formato notaria
                                    stFPPRNOTA = stFPPRNOTA.PadRight(10, " ")
                                    stFPPRNOTA = stFPPRNOTA.Substring(0, 10)

                                    ' formato escritura
                                    stFPPRESCR = stFPPRESCR.PadLeft(7, "0")
                                    stFPPRESCR = stFPPRESCR.Substring(0, 7)

                                    ' formato fecha de escritura
                                    stFPPRFEES = stFPPRFEES.PadRight(10, " ")
                                    stFPPRFEES = stFPPRFEES.Substring(0, 10)

                                    ' formato fecha de registro
                                    stFPPRFERE = stFPPRFERE.PadRight(10, " ")
                                    stFPPRFERE = stFPPRFERE.Substring(0, 10)

                                    ' formato tomo
                                    stFPPRTOMO = stFPPRTOMO.PadLeft(3, "0")
                                    stFPPRTOMO = stFPPRTOMO.Substring(0, 3)

                                    ' formato matricula inmobiliaria
                                    stFPPRMAIN = stFPPRMAIN.PadRight(15, " ")
                                    stFPPRMAIN = stFPPRMAIN.Substring(0, 15)

                                    ' formato calidad de propietario
                                    stFPPRCAPR = stFPPRCAPR.PadLeft(2, "0")
                                    stFPPRCAPR = stFPPRCAPR.Substring(0, 2)

                                    ' formato gravable
                                    stFPPRGRAV = stFPPRGRAV.PadLeft(1, "0")
                                    stFPPRGRAV = stFPPRGRAV.Substring(0, 1)

                                    ' formato modo de adquisición
                                    stFPPRMOAD = stFPPRMOAD.PadLeft(1, "0")
                                    stFPPRMOAD = stFPPRMOAD.Substring(0, 1)

                                    ' formato litigio
                                    stFPPRLITI = stFPPRLITI.PadLeft(1, "0")
                                    stFPPRLITI = stFPPRLITI.Substring(0, 1)

                                    ' formato porcentaje de litigio
                                    stFPPRPOLI = stFPPRPOLI.Replace(".", "")
                                    stFPPRPOLI = stFPPRPOLI.PadLeft(5, "0")
                                    stFPPRPOLI = stFPPRPOLI.Substring(0, 5)

                                    ' formato segundo apellido
                                    stFPPRSEAP = stFPPRSEAP.PadRight(15, " ")
                                    stFPPRSEAP = stFPPRSEAP.Substring(0, 15)

                                    ' formato sigla comercial
                                    stFPPRSICO = stFPPRSICO.PadRight(20, " ")
                                    stFPPRSICO = stFPPRSICO.Substring(0, 20)

                                    ' formato sexo
                                    stFPPRSEXO = stFPPRSEXO.PadLeft(1, "0")
                                    stFPPRSEXO = stFPPRSEXO.Substring(0, 1)

                                    ' exportar los datos
                                    PrintLine(1, stFPPRIDRE & stSeparador & _
                                                 stFPPRVIGE & stSeparador & _
                                                 stFPPRTIRE & stSeparador & _
                                                 stFPPRRESO & stSeparador & _
                                                 stFPPRNUFI & stSeparador & _
                                                 stFPPRNURE & stSeparador & _
                                                 stFPPRTIDO & stSeparador & _
                                                 stFPPRNUDO & stSeparador & _
                                                 stFPPRPRAP & stSeparador & _
                                                 stFPPRNOMB & stSeparador & _
                                                 stFPPRDERE & stSeparador & _
                                                 stFPPRNOTA & stSeparador & _
                                                 stFPPRESCR & stSeparador & _
                                                 stFPPRFEES & stSeparador & _
                                                 stFPPRFERE & stSeparador & _
                                                 stFPPRTOMO & stSeparador & _
                                                 stFPPRMAIN & stSeparador & _
                                                 stFPPRCAPR & stSeparador & _
                                                 stFPPRGRAV & stSeparador & _
                                                 stFPPRMOAD & stSeparador & _
                                                 stFPPRLITI & stSeparador & _
                                                 stFPPRPOLI & stSeparador & _
                                                 stFPPRSEAP & stSeparador & _
                                                 stFPPRSICO & stSeparador & _
                                                 stFPPRSEXO)

                                End If

                            Next

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbProcesoAdministrativa.Value = inProceso

                        Next

                        ' limpia la barra de progreso
                        pbProcesoAdministrativa.Value = 0

                        '============================
                        '*** EXPORTA CONSTRUCCIÓN ***
                        '============================

                        ' carga la barra de progreso
                        inProceso = 0
                        pbProcesoAdministrativa.Value = 0
                        pbProcesoAdministrativa.Maximum = dt.Rows.Count
                        Timer1.Enabled = True

                        Dim h As Integer = 0

                        For h = 0 To dt.Rows.Count - 1

                            ' crea la tabla
                            tblConstruccion = New DataTable

                            ' almacena consulta
                            tblConstruccion = objConstruccion.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(dt.Rows(h).Item("FIPRNUFI"))

                            Dim c As Integer = 0

                            For c = 0 To tblConstruccion.Rows.Count - 1

                                ' verifica que se encuentre activa
                                If Trim(tblConstruccion.Rows(c).Item("FPCOESTA").ToString) = "ac" Then

                                    ' variables directas
                                    Dim stFPCOIDRE As String = "5"
                                    Dim stFPCOVIGE As String = Trim(tblConstruccion.Rows(c).Item("FPCOVIGE").ToString)
                                    Dim stFPCOTIRE As String = Trim(tblConstruccion.Rows(c).Item("FPCOTIRE").ToString)
                                    Dim stFPCORESO As String = Trim(tblConstruccion.Rows(c).Item("FPCORESO").ToString)
                                    Dim stFPCONUFI As String = Trim(tblConstruccion.Rows(c).Item("FPCONUFI").ToString)
                                    Dim stFPCONURE As String = Trim(tblConstruccion.Rows(c).Item("FPCONURE").ToString)
                                    Dim stFPCOUNID As String = Trim(tblConstruccion.Rows(c).Item("FPCOUNID").ToString)
                                    Dim stFPCOPUNT As String = Trim(tblConstruccion.Rows(c).Item("FPCOPUNT").ToString)
                                    Dim stFPCOARCO As String = Trim(tblConstruccion.Rows(c).Item("FPCOARCO").ToString)
                                    Dim boFPCOMEJO As Boolean = tblConstruccion.Rows(c).Item("FPCOMEJO").ToString
                                    Dim boFPCOLEY As Boolean = tblConstruccion.Rows(c).Item("FPCOLEY").ToString
                                    Dim stFPCOTICO As String = fun_Quita_Letras(Trim(tblConstruccion.Rows(c).Item("FPCOTICO").ToString))
                                    Dim stFPCOACUE As String = Trim(tblConstruccion.Rows(c).Item("FPCOACUE").ToString)
                                    Dim stFPCOTELE As String = Trim(tblConstruccion.Rows(c).Item("FPCOTELE").ToString)
                                    Dim stFPCOALCA As String = Trim(tblConstruccion.Rows(c).Item("FPCOALCA").ToString)
                                    Dim stFPCOENER As String = Trim(tblConstruccion.Rows(c).Item("FPCOENER").ToString)
                                    Dim stFPCOGAS As String = Trim(tblConstruccion.Rows(c).Item("FPCOGAS").ToString)
                                    Dim stFPCOPISO As String = Trim(tblConstruccion.Rows(c).Item("FPCOPISO").ToString)
                                    Dim stFPCOPOCO As String = Trim(tblConstruccion.Rows(c).Item("FPCOPOCO").ToString)
                                    Dim stFPCOEDCO As String = Trim(tblConstruccion.Rows(c).Item("FPCOEDCO").ToString)

                                    ' variables indirectas
                                    Dim stFPCOMEJO As String = ""
                                    Dim stFPCOLEY As String = ""

                                    ' mejora
                                    If boFPCOMEJO = False Then
                                        stFPCOMEJO = 2
                                    Else
                                        stFPCOMEJO = 1
                                    End If

                                    ' ley 56
                                    If boFPCOLEY = False Then
                                        stFPCOLEY = 2
                                    Else
                                        stFPCOLEY = 1
                                    End If

                                    ' formato vigencia
                                    stFPCOVIGE = stFPCOVIGE.PadLeft(4, "0")
                                    stFPCOVIGE = stFPCOVIGE.Substring(0, 4)

                                    ' formato tipo de resolución
                                    stFPCOTIRE = stFPCOTIRE.PadLeft(3, "0")
                                    stFPCOTIRE = stFPCOTIRE.Substring(0, 3)

                                    ' formato resolución
                                    stFPCORESO = stFPCORESO.PadLeft(7, "0")
                                    stFPCORESO = stFPCORESO.Substring(0, 7)

                                    ' formato numero de ficha
                                    stFPCONUFI = stFPCONUFI.PadLeft(9, "0")
                                    stFPCONUFI = stFPCONUFI.Substring(0, 9)

                                    ' formato numero de registro
                                    stFPCONURE = stFPCONURE.PadLeft(5, "0")
                                    stFPCONURE = stFPCONURE.Substring(0, 5)

                                    ' formato unidad 
                                    stFPCOUNID = stFPCOUNID.PadLeft(5, "0")
                                    stFPCOUNID = stFPCOUNID.Substring(0, 5)

                                    ' formato puntos
                                    stFPCOPUNT = stFPCOPUNT.PadLeft(3, "0")
                                    stFPCOPUNT = stFPCOPUNT.Substring(0, 3)

                                    ' formato área de construcción
                                    stFPCOARCO = stFPCOARCO.Replace(".", "")
                                    stFPCOARCO = stFPCOARCO.PadLeft(9, "0")
                                    stFPCOARCO = stFPCOARCO.Substring(0, 9)

                                    ' formato mejora
                                    stFPCOMEJO = stFPCOMEJO.PadLeft(1, "0")
                                    stFPCOMEJO = stFPCOMEJO.Substring(0, 1)

                                    ' formato ley 56
                                    stFPCOLEY = stFPCOLEY.PadLeft(1, "0")
                                    stFPCOLEY = stFPCOLEY.Substring(0, 1)

                                    ' formato tipo de construcción
                                    stFPCOTICO = stFPCOTICO.PadLeft(3, "0")
                                    stFPCOTICO = stFPCOTICO.Substring(0, 3)

                                    ' formato acueducto
                                    stFPCOACUE = stFPCOACUE.PadLeft(1, "0")
                                    stFPCOACUE = stFPCOACUE.Substring(0, 1)

                                    ' formato telefono
                                    stFPCOTELE = stFPCOTELE.PadLeft(1, "0")
                                    stFPCOTELE = stFPCOTELE.Substring(0, 1)

                                    ' formato alcantarillado
                                    stFPCOALCA = stFPCOALCA.PadLeft(1, "0")
                                    stFPCOALCA = stFPCOALCA.Substring(0, 1)

                                    ' formato energia
                                    stFPCOENER = stFPCOENER.PadLeft(1, "0")
                                    stFPCOENER = stFPCOENER.Substring(0, 1)

                                    ' formato gas
                                    stFPCOGAS = stFPCOGAS.PadLeft(1, "0")
                                    stFPCOGAS = stFPCOGAS.Substring(0, 1)

                                    ' formato numero de pisos
                                    stFPCOPISO = stFPCOPISO.PadLeft(2, "0")
                                    stFPCOPISO = stFPCOPISO.Substring(0, 2)

                                    ' formato porcentaje construido
                                    stFPCOPOCO = stFPCOPOCO.PadLeft(3, "0")
                                    stFPCOPOCO = stFPCOPOCO.Substring(0, 3)

                                    ' formato edad de construcción
                                    stFPCOEDCO = stFPCOEDCO.PadLeft(4, "0")
                                    stFPCOEDCO = stFPCOEDCO.Substring(0, 4)

                                    ' exportar los datos
                                    PrintLine(1, stFPCOIDRE & stSeparador & _
                                                 stFPCOVIGE & stSeparador & _
                                                 stFPCOTIRE & stSeparador & _
                                                 stFPCORESO & stSeparador & _
                                                 stFPCONUFI & stSeparador & _
                                                 stFPCONURE & stSeparador & _
                                                 stFPCOUNID & stSeparador & _
                                                 stFPCOPUNT & stSeparador & _
                                                 stFPCOARCO & stSeparador & _
                                                 stFPCOMEJO & stSeparador & _
                                                 stFPCOLEY & stSeparador & _
                                                 stFPCOTICO & stSeparador & _
                                                 stFPCOACUE & stSeparador & _
                                                 stFPCOTELE & stSeparador & _
                                                 stFPCOALCA & stSeparador & _
                                                 stFPCOENER & stSeparador & _
                                                 stFPCOGAS & stSeparador & _
                                                 stFPCOPISO & stSeparador & _
                                                 stFPCOPOCO & stSeparador & _
                                                 stFPCOEDCO)
                                End If

                            Next

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbProcesoAdministrativa.Value = inProceso

                        Next

                        ' limpia la barra de progreso
                        pbProcesoAdministrativa.Value = 0

                        '============================
                        '*** EXPORTA CALIFICACIÓN ***
                        '============================

                        ' carga la barra de progreso
                        inProceso = 0
                        pbProcesoAdministrativa.Value = 0
                        pbProcesoAdministrativa.Maximum = dt.Rows.Count
                        Timer1.Enabled = True

                        Dim f As Integer = 0

                        For f = 0 To dt.Rows.Count - 1

                            ' crea la tabla
                            tblCalificacion = New DataTable

                            ' almacena consulta
                            tblCalificacion = objCalificacion.fun_Consultar_FIPRCACO_X_FICHA_PREDIAL_TODAS_LAS_UNIDADES(dt.Rows(f).Item("FIPRNUFI"))

                            Dim d As Integer = 0

                            For d = 0 To tblCalificacion.Rows.Count - 1

                                ' verifica que se encuentre activa
                                If Trim(tblCalificacion.Rows(d).Item("FPCCESTA").ToString) = "ac" Then

                                    ' variables directas
                                    Dim stFPCCIDRE As String = "6"
                                    Dim stFPCCVIGE As String = Trim(tblCalificacion.Rows(d).Item("FPCCVIGE").ToString)
                                    Dim stFPCCTIRE As String = Trim(tblCalificacion.Rows(d).Item("FPCCTIRE").ToString)
                                    Dim stFPCCRESO As String = Trim(tblCalificacion.Rows(d).Item("FPCCRESO").ToString)
                                    Dim stFPCCNUFI As String = Trim(tblCalificacion.Rows(d).Item("FPCCNUFI").ToString)
                                    Dim stFPCCNURE As String = Trim(tblCalificacion.Rows(d).Item("FPCCNURE").ToString)
                                    Dim stFPCCUNID As String = Trim(tblCalificacion.Rows(d).Item("FPCCUNID").ToString)
                                    Dim stFPCCTIPO As String = Trim(tblCalificacion.Rows(d).Item("FPCCTIPO").ToString)
                                    Dim stFPCCCODI As String = Trim(tblCalificacion.Rows(d).Item("FPCCCODI").ToString)
                                    Dim stFPCCPUNT As String = Trim(tblCalificacion.Rows(d).Item("FPCCPUNT").ToString)

                                    ' formato vigencia
                                    stFPCCVIGE = stFPCCVIGE.PadLeft(4, "0")
                                    stFPCCVIGE = stFPCCVIGE.Substring(0, 4)

                                    ' formato tipo de resolución
                                    stFPCCTIRE = stFPCCTIRE.PadLeft(3, "0")
                                    stFPCCTIRE = stFPCCTIRE.Substring(0, 3)

                                    ' formato resolución
                                    stFPCCRESO = stFPCCRESO.PadLeft(7, "0")
                                    stFPCCRESO = stFPCCRESO.Substring(0, 7)

                                    ' formato numero de ficha
                                    stFPCCNUFI = stFPCCNUFI.PadLeft(9, "0")
                                    stFPCCNUFI = stFPCCNUFI.Substring(0, 9)

                                    ' formato numero de registro
                                    stFPCCNURE = stFPCCNURE.PadLeft(5, "0")
                                    stFPCCNURE = stFPCCNURE.Substring(0, 5)

                                    ' formato unidad 
                                    stFPCCUNID = stFPCCUNID.PadLeft(5, "0")
                                    stFPCCUNID = stFPCCUNID.Substring(0, 5)

                                    ' formato tipo de calificación
                                    stFPCCTIPO = stFPCCTIPO.PadRight(1, " ")
                                    stFPCCTIPO = stFPCCTIPO.Substring(0, 1)

                                    ' formato código de calificación
                                    stFPCCCODI = stFPCCCODI.PadLeft(4, "0")
                                    stFPCCCODI = stFPCCCODI.Substring(0, 4)

                                    ' formato puntos
                                    stFPCCPUNT = stFPCCPUNT.PadLeft(3, "0")
                                    stFPCCPUNT = stFPCCPUNT.Substring(0, 3)

                                    ' exportar los datos
                                    PrintLine(1, stFPCCIDRE & stSeparador & _
                                                 stFPCCVIGE & stSeparador & _
                                                 stFPCCTIRE & stSeparador & _
                                                 stFPCCRESO & stSeparador & _
                                                 stFPCCNUFI & stSeparador & _
                                                 stFPCCNURE & stSeparador & _
                                                 stFPCCUNID & stSeparador & _
                                                 stFPCCTIPO & stSeparador & _
                                                 stFPCCCODI & stSeparador & _
                                                 stFPCCPUNT)
                                End If

                            Next

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbProcesoAdministrativa.Value = inProceso

                        Next

                        ' limpia la barra de progreso
                        pbProcesoAdministrativa.Value = 0

                        '========================
                        '*** EXPORTA LINDEROS ***
                        '========================

                        ' carga la barra de progreso
                        inProceso = 0
                        pbProcesoAdministrativa.Value = 0
                        pbProcesoAdministrativa.Maximum = dt.Rows.Count
                        Timer1.Enabled = True

                        Dim w As Integer = 0

                        For w = 0 To dt.Rows.Count - 1

                            ' crea la tabla
                            tblLinderos = New DataTable

                            ' almacena consulta
                            tblLinderos = objLinderos.fun_Consultar_FIPRLIND_X_FICHA_PREDIAL(dt.Rows(w).Item("FIPRNUFI"))

                            Dim d As Integer = 0

                            For d = 0 To tblLinderos.Rows.Count - 1

                                ' verifica que se encuentre activa
                                If Trim(tblLinderos.Rows(d).Item("FPLIESTA").ToString) = "ac" Then

                                    ' variables directas
                                    Dim stFPLIIDRE As String = "7"
                                    Dim stFPLIVIGE As String = Trim(tblLinderos.Rows(d).Item("FPLIVIGE").ToString)
                                    Dim stFPLITIRE As String = Trim(tblLinderos.Rows(d).Item("FPLITIRE").ToString)
                                    Dim stFPLIRESO As String = Trim(tblLinderos.Rows(d).Item("FPLIRESO").ToString)
                                    Dim stFPLINUFI As String = Trim(tblLinderos.Rows(d).Item("FPLINUFI").ToString)
                                    Dim stFPLINURE As String = Trim(tblLinderos.Rows(d).Item("FPLINURE").ToString)
                                    Dim stFPLIPUCA As String = Trim(tblLinderos.Rows(d).Item("FPLIPUCA").ToString)
                                    Dim stFPLICOLI As String = Trim(tblLinderos.Rows(d).Item("FPLICOLI").ToString)

                                    ' formato vigencia
                                    stFPLIVIGE = stFPLIVIGE.PadLeft(4, "0")
                                    stFPLIVIGE = stFPLIVIGE.Substring(0, 4)

                                    ' formato tipo de resolución
                                    stFPLITIRE = stFPLITIRE.PadLeft(3, "0")
                                    stFPLITIRE = stFPLITIRE.Substring(0, 3)

                                    ' formato resolución
                                    stFPLIRESO = stFPLIRESO.PadLeft(7, "0")
                                    stFPLIRESO = stFPLIRESO.Substring(0, 7)

                                    ' formato numero de ficha
                                    stFPLINUFI = stFPLINUFI.PadLeft(9, "0")
                                    stFPLINUFI = stFPLINUFI.Substring(0, 9)

                                    ' formato numero de registro
                                    stFPLINURE = stFPLINURE.PadLeft(5, "0")
                                    stFPLINURE = stFPLINURE.Substring(0, 5)

                                    ' formato punto cardinal
                                    stFPLIPUCA = stFPLIPUCA.PadRight(2, " ")
                                    stFPLIPUCA = stFPLIPUCA.Substring(0, 2)

                                    ' formato colindante
                                    stFPLICOLI = stFPLICOLI.PadRight(30, " ")
                                    stFPLICOLI = stFPLICOLI.Substring(0, 30)

                                    ' exportar los datos
                                    PrintLine(1, stFPLIIDRE & stSeparador & _
                                                 stFPLIVIGE & stSeparador & _
                                                 stFPLITIRE & stSeparador & _
                                                 stFPLIRESO & stSeparador & _
                                                 stFPLINUFI & stSeparador & _
                                                 stFPLINURE & stSeparador & _
                                                 stFPLIPUCA & stSeparador & _
                                                 stFPLICOLI)
                                End If

                            Next

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbProcesoAdministrativa.Value = inProceso

                        Next

                        ' limpia la barra de progreso
                        pbProcesoAdministrativa.Value = 0

                        '===========================
                        '*** EXPORTA CARTOGRAFIA ***
                        '===========================

                        ' carga la barra de progreso
                        inProceso = 0
                        pbProcesoAdministrativa.Value = 0
                        pbProcesoAdministrativa.Maximum = dt.Rows.Count
                        Timer1.Enabled = True

                        Dim r As Integer = 0

                        For r = 0 To dt.Rows.Count - 1

                            ' crea la tabla
                            tblCartografia = New DataTable

                            ' almacena consulta
                            tblCartografia = objCartografia.fun_Consultar_FIPRCART_X_FICHA_PREDIAL(dt.Rows(r).Item("FIPRNUFI"))

                            Dim d As Integer = 0

                            For d = 0 To tblCartografia.Rows.Count - 1

                                ' verifica que se encuentre activa
                                If Trim(tblCartografia.Rows(d).Item("FPCAESTA").ToString) = "ac" Then

                                    ' variables directas
                                    Dim stFPCAIDRE As String = "8"
                                    Dim stFPCAVIGE As String = Trim(tblCartografia.Rows(d).Item("FPCAVIGE").ToString)
                                    Dim stFPCATIRE As String = Trim(tblCartografia.Rows(d).Item("FPCATIRE").ToString)
                                    Dim stFPCARESO As String = Trim(tblCartografia.Rows(d).Item("FPCARESO").ToString)
                                    Dim stFPCANUFI As String = Trim(tblCartografia.Rows(d).Item("FPCANUFI").ToString)
                                    Dim stFPCANURE As String = Trim(tblCartografia.Rows(d).Item("FPCANURE").ToString)
                                    Dim stFPCAPLAN As String = Trim(tblCartografia.Rows(d).Item("FPCAPLAN").ToString)
                                    Dim stFPCAVENT As String = Trim(tblCartografia.Rows(d).Item("FPCAVENT").ToString)
                                    Dim stFPCAESGR As String = Trim(tblCartografia.Rows(d).Item("FPCAESGR").ToString)
                                    Dim stFPCAVIGR As String = Trim(tblCartografia.Rows(d).Item("FPCAVIGR").ToString)
                                    Dim stFPCAVUEL As String = Trim(tblCartografia.Rows(d).Item("FPCAVUEL").ToString)
                                    Dim stFPCAFAJA As String = Trim(tblCartografia.Rows(d).Item("FPCAFAJA").ToString)
                                    Dim stFPCAFOTO As String = Trim(tblCartografia.Rows(d).Item("FPCAFOTO").ToString)
                                    Dim stFPCAVIAE As String = Trim(tblCartografia.Rows(d).Item("FPCAVIAE").ToString)
                                    Dim stFPCAAMPL As String = Trim(tblCartografia.Rows(d).Item("FPCAAMPL").ToString)
                                    Dim stFPCAESAE As String = Trim(tblCartografia.Rows(d).Item("FPCAESAE").ToString)

                                    ' formato vigencia
                                    stFPCAVIGE = stFPCAVIGE.PadLeft(4, "0")
                                    stFPCAVIGE = stFPCAVIGE.Substring(0, 4)

                                    ' formato tipo de resolución
                                    stFPCATIRE = stFPCATIRE.PadLeft(3, "0")
                                    stFPCATIRE = stFPCATIRE.Substring(0, 3)

                                    ' formato resolución
                                    stFPCARESO = stFPCARESO.PadLeft(7, "0")
                                    stFPCARESO = stFPCARESO.Substring(0, 7)

                                    ' formato numero de ficha
                                    stFPCANUFI = stFPCANUFI.PadLeft(9, "0")
                                    stFPCANUFI = stFPCANUFI.Substring(0, 9)

                                    ' formato numero de registro
                                    stFPCANURE = stFPCANURE.PadLeft(5, "0")
                                    stFPCANURE = stFPCANURE.Substring(0, 5)

                                    ' formato plancha
                                    stFPCAPLAN = stFPCAPLAN.PadRight(15, " ")
                                    stFPCAPLAN = stFPCAPLAN.Substring(0, 15)

                                    ' formato ventana
                                    stFPCAVENT = stFPCAVENT.PadRight(15, " ")
                                    stFPCAVENT = stFPCAVENT.Substring(0, 15)

                                    ' formato escala grafica
                                    stFPCAESGR = stFPCAESGR.PadRight(15, " ")
                                    stFPCAESGR = stFPCAESGR.Substring(0, 15)

                                    ' formato vigencia grafica
                                    stFPCAVIGR = stFPCAVIGR.PadLeft(4, "0")
                                    stFPCAVIGR = stFPCAVIGR.Substring(0, 4)

                                    ' formato vuelo
                                    stFPCAVUEL = stFPCAVUEL.PadRight(15, " ")
                                    stFPCAVUEL = stFPCAVUEL.Substring(0, 15)

                                    ' formato faja
                                    stFPCAFAJA = stFPCAFAJA.PadRight(15, " ")
                                    stFPCAFAJA = stFPCAFAJA.Substring(0, 15)

                                    ' formato foto
                                    stFPCAFOTO = stFPCAFOTO.PadRight(15, " ")
                                    stFPCAFOTO = stFPCAFOTO.Substring(0, 15)

                                    ' formato vigencia aerofotografica
                                    stFPCAVIAE = stFPCAVIAE.PadLeft(4, "0")
                                    stFPCAVIAE = stFPCAVIAE.Substring(0, 4)

                                    ' formato ampliación
                                    stFPCAAMPL = stFPCAAMPL.PadRight(15, " ")
                                    stFPCAAMPL = stFPCAAMPL.Substring(0, 15)

                                    ' formato escala aerofotografica
                                    stFPCAESAE = stFPCAESAE.PadRight(15, " ")
                                    stFPCAESAE = stFPCAESAE.Substring(0, 15)

                                    ' exportar los datos
                                    PrintLine(1, stFPCAIDRE & stSeparador & _
                                                 stFPCAVIGE & stSeparador & _
                                                 stFPCATIRE & stSeparador & _
                                                 stFPCARESO & stSeparador & _
                                                 stFPCANUFI & stSeparador & _
                                                 stFPCANURE & stSeparador & _
                                                 stFPCAPLAN & stSeparador & _
                                                 stFPCAVENT & stSeparador & _
                                                 stFPCAESGR & stSeparador & _
                                                 stFPCAVIGR & stSeparador & _
                                                 stFPCAVUEL & stSeparador & _
                                                 stFPCAFAJA & stSeparador & _
                                                 stFPCAFOTO & stSeparador & _
                                                 stFPCAVIAE & stSeparador & _
                                                 stFPCAAMPL & stSeparador & _
                                                 stFPCAESAE)
                                End If

                            Next

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbProcesoAdministrativa.Value = inProceso

                        Next

                        ' Limpia los campos
                        pbProcesoAdministrativa.Value = 0

                        MessageBox.Show("Archivo plano creado corectamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                        ' prende el boton
                        Me.cmdExportarPlanoAdministrativa.Enabled = True

                        If MessageBox.Show("¿ Desea abrir el archivo plano ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                            ' Abrir con Process.Start el archivo de texto
                            Process.Start(stRutaArchivoAdministrativa)
                        End If

                    Else
                        MessageBox.Show("No existen registros en base de datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        cmdExportarPlanoAdministrativa.Focus()
                    End If

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub pro_ExportarPlanoFichaResumenAdministrativa()

        Try
            ' verifica si se a seleccionado una resolución
            If Me.txtREADRESO.Text = "" Then
                MessageBox.Show("Seleccione una resolución", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                ' verifica la ruta del acchivo
                If Trim(stRutaArchivoAdministrativa) <> "" Then

                    ' recorre el archivo a exportar
                    FileOpen(1, oCrear.FileName, OpenMode.Output) 'crea y destruye si hay otro igual

                    ' variable separador
                    Dim stSeparador As String = Trim(Me.txtSEPARADOR.Text)

                    ' apaga el boton
                    Me.cmdExportarPlanoAdministrativa.Enabled = False

                    '==========================
                    '*** GENERA LA CONSULTA ***
                    '==========================

                    ' crea un datable
                    dt = New DataTable

                    ' llena el datatable con la consulta
                    dt_FR_1_Y_2 = fun_EjecutarConsultaFichaResumen1y2Administrativa()
                    dt_FR_1 = fun_EjecutarConsultaFichaResumen1Administrativa()
                    dt_FR_2 = fun_EjecutarConsultaFichaResumen2Administrativa()

                    '============================
                    '*** CUENTA LOS REGISTROS ***
                    '============================

                    Dim objdatos As New cla_VALIFIPR
                    Dim ds As New DataSet

                    ds = objdatos.fun_Consultar_NRO_REGISTROS_DE_EXPORTACION_FICHA_RESUMEN_RESOADMI(Me.txtREADTIRE.Text, _
                                                                                                    Me.txtREADCLSE.Text, _
                                                                                                    Me.txtREADVIGE.Text, _
                                                                                                    Me.txtREADRESO.Text)

                    ' crea nuevos datatable
                    dt_FICHPRED = New DataTable
                    dt_FIPRDEEC = New DataTable
                    dt_FIPRPROP = New DataTable
                    dt_FIPRCONS = New DataTable
                    dt_FIPRCACO = New DataTable
                    dt_FIPRLIND = New DataTable
                    dt_FIPRCART = New DataTable

                    ' almacena la información
                    dt_FICHPRED = ds.Tables(0)
                    dt_FIPRDEEC = ds.Tables(1)
                    dt_FIPRPROP = ds.Tables(2)
                    dt_FIPRCONS = ds.Tables(3)
                    dt_FIPRCACO = ds.Tables(4)
                    dt_FIPRLIND = ds.Tables(5)
                    dt_FIPRCART = ds.Tables(6)

                    ' cuenta los registros
                    Dim in_Nro_Registros_FICHPRED As Integer = dt_FICHPRED.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRDEEC As Integer = dt_FIPRDEEC.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRPROP As Integer = dt_FIPRPROP.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRCONS As Integer = dt_FIPRCONS.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRCACO As Integer = dt_FIPRCACO.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRLIND As Integer = dt_FIPRLIND.Rows(0).Item(0)
                    Dim in_Nro_Registros_FIPRCART As Integer = dt_FIPRCART.Rows(0).Item(0)

                    inProceso = 0
                    pbProcesoAdministrativa.Value = 0
                    pbProcesoAdministrativa.Maximum = in_Nro_Registros_FICHPRED + in_Nro_Registros_FIPRDEEC + in_Nro_Registros_FIPRPROP + in_Nro_Registros_FIPRCONS + in_Nro_Registros_FIPRCACO + in_Nro_Registros_FIPRLIND + in_Nro_Registros_FIPRCART
                    Timer1.Enabled = True

                    ' recorre la consulta
                    If dt.Rows.Count > 0 Then

                        '================================
                        '*** ID : 1 EXPORTA RESUMEN 1 ***
                        '================================

                        Dim i As Integer = 0

                        For i = 0 To dt_FR_1.Rows.Count - 1

                            ' crea la tabla
                            tblFichaPredial = New DataTable

                            ' almacena consulta
                            tblFichaPredial = objFichaPredial.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dt_FR_1.Rows(i).Item("FIPRNUFI"))

                            ' variables directas
                            Dim stFIPRIDRE As String = "1"
                            Dim stFIPRMUNI As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMUNI").ToString)
                            Dim stFIPRCLSE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCLSE").ToString)
                            Dim stFIPRCORR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCORR").ToString)
                            Dim stFIPRBARR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRBARR").ToString)
                            Dim stFIPRMANZ As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMANZ").ToString)
                            Dim stFIPRPRED As String = Trim(tblFichaPredial.Rows(0).Item("FIPRPRED").ToString)
                            Dim stFIPRATLO As String = Trim(tblFichaPredial.Rows(0).Item("FIPRATLO").ToString)
                            Dim stFIPRACLO As String = Trim(tblFichaPredial.Rows(0).Item("FIPRACLO").ToString)
                            Dim stFIPRAPCA As String = Trim(tblFichaPredial.Rows(0).Item("FIPRAPCA").ToString)
                            Dim stFIPRUNCO As String = Trim(tblFichaPredial.Rows(0).Item("FIPRUNCO").ToString)
                            Dim stFIPRTOED As String = Trim(tblFichaPredial.Rows(0).Item("FIPRTOED").ToString)
                            Dim stFIPRCUUT As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCUUT").ToString)
                            Dim stFIPRLOCA As String = Trim(tblFichaPredial.Rows(0).Item("FIPRLOCA").ToString)
                            Dim stFIPRGACU As String = Trim(tblFichaPredial.Rows(0).Item("FIPRGACU").ToString)
                            Dim stFIPRGADE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRGADE").ToString)
                            Dim stFIPRDIRE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRDIRE").ToString)
                            Dim stFIPRCAPR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCAPR").ToString)

                            ' formato municipio actual
                            stFIPRMUNI = stFIPRMUNI.PadLeft(3, "0")
                            stFIPRMUNI = stFIPRMUNI.Substring(0, 3)

                            ' formato clase o sector actual
                            stFIPRCLSE = stFIPRCLSE.PadLeft(1, "0")
                            stFIPRCLSE = stFIPRCLSE.Substring(0, 1)

                            ' formato corregimiento actual
                            stFIPRCORR = stFIPRCORR.PadLeft(3, "0")
                            stFIPRCORR = stFIPRCORR.Substring(0, 3)

                            ' formato barrio actual
                            stFIPRBARR = stFIPRBARR.PadLeft(3, "0")
                            stFIPRBARR = stFIPRBARR.Substring(0, 3)

                            ' formato manzana actual
                            stFIPRMANZ = stFIPRMANZ.PadLeft(3, "0")
                            stFIPRMANZ = stFIPRMANZ.Substring(0, 3)

                            ' formato predio actual
                            stFIPRPRED = stFIPRPRED.PadLeft(5, "0")
                            stFIPRPRED = stFIPRPRED.Substring(0, 5)

                            ' formato área total de lote
                            stFIPRATLO = stFIPRATLO.PadLeft(11, "0")
                            stFIPRATLO = stFIPRATLO.Substring(0, 11)

                            ' formato área comun de lote
                            stFIPRACLO = stFIPRACLO.PadLeft(11, "0")
                            stFIPRACLO = stFIPRACLO.Substring(0, 11)

                            ' formato apartamentos o casa
                            stFIPRAPCA = stFIPRAPCA.PadLeft(4, "0")
                            stFIPRAPCA = stFIPRAPCA.Substring(0, 4)

                            ' formato unidades en condominio
                            stFIPRUNCO = stFIPRUNCO.PadLeft(4, "0")
                            stFIPRUNCO = stFIPRUNCO.Substring(0, 4)

                            ' formato total edificios
                            stFIPRTOED = stFIPRTOED.PadLeft(4, "0")
                            stFIPRTOED = stFIPRTOED.Substring(0, 4)

                            ' formato cuartos utilies
                            stFIPRCUUT = stFIPRCUUT.PadLeft(4, "0")
                            stFIPRCUUT = stFIPRCUUT.Substring(0, 4)

                            ' formato locales
                            stFIPRLOCA = stFIPRLOCA.PadLeft(4, "0")
                            stFIPRLOCA = stFIPRLOCA.Substring(0, 4)

                            ' formato garajes cubiertos
                            stFIPRGACU = stFIPRGACU.PadLeft(4, "0")
                            stFIPRGACU = stFIPRGACU.Substring(0, 4)

                            ' formato garajes descubiertos
                            stFIPRGADE = stFIPRGADE.PadLeft(4, "0")
                            stFIPRGADE = stFIPRGADE.Substring(0, 4)

                            ' formato dirección
                            stFIPRDIRE = stFIPRDIRE.PadRight(49, " ")
                            stFIPRDIRE = stFIPRDIRE.Substring(0, 49)

                            ' formato caracteristica de predio
                            stFIPRCAPR = stFIPRCAPR.PadLeft(1, "0")
                            stFIPRCAPR = stFIPRCAPR.Substring(0, 1)

                            ' exportar los datos
                            PrintLine(1, stFIPRIDRE & stSeparador & _
                                         stFIPRMUNI & stSeparador & _
                                         stFIPRCLSE & stSeparador & _
                                         stFIPRCORR & stSeparador & _
                                         stFIPRBARR & stSeparador & _
                                         stFIPRMANZ & stSeparador & _
                                         stFIPRPRED & stSeparador & _
                                         stFIPRATLO & stSeparador & _
                                         stFIPRACLO & stSeparador & _
                                         stFIPRAPCA & stSeparador & _
                                         stFIPRUNCO & stSeparador & _
                                         stFIPRTOED & stSeparador & _
                                         stFIPRCUUT & stSeparador & _
                                         stFIPRLOCA & stSeparador & _
                                         stFIPRGACU & stSeparador & _
                                         stFIPRGADE & stSeparador & _
                                         stFIPRDIRE & stSeparador & _
                                         stFIPRCAPR)

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbProcesoAdministrativa.Value = inProceso

                        Next

                        '================================
                        '*** ID : 2 EXPORTA RESUMEN 2 ***
                        '================================

                        Dim k As Integer = 0

                        For k = 0 To dt_FR_2.Rows.Count - 1

                            ' crea la tabla
                            tblFichaPredial = New DataTable

                            ' almacena consulta
                            tblFichaPredial = objFichaPredial.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dt_FR_2.Rows(k).Item("FIPRNUFI"))

                            ' variables directas
                            Dim stFIPRIDRE As String = "2"
                            Dim stFIPRMUNI As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMUNI").ToString)
                            Dim stFIPRCLSE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCLSE").ToString)
                            Dim stFIPRCORR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCORR").ToString)
                            Dim stFIPRBARR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRBARR").ToString)
                            Dim stFIPRMANZ As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMANZ").ToString)
                            Dim stFIPRPRED As String = Trim(tblFichaPredial.Rows(0).Item("FIPRPRED").ToString)
                            Dim stFIPREDIF As String = Trim(tblFichaPredial.Rows(0).Item("FIPREDIF").ToString)
                            Dim stFIPRATLO As String = Trim(tblFichaPredial.Rows(0).Item("FIPRATLO").ToString)
                            Dim stFIPRACLO As String = Trim(tblFichaPredial.Rows(0).Item("FIPRACLO").ToString)
                            Dim stFIPRPISO As String = Trim(tblFichaPredial.Rows(0).Item("FIPRPISO").ToString)
                            Dim stFIPRURPH As String = Trim(tblFichaPredial.Rows(0).Item("FIPRURPH").ToString)
                            Dim stFIPRAPCA As String = Trim(tblFichaPredial.Rows(0).Item("FIPRAPCA").ToString)
                            Dim stFIPRCUUT As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCUUT").ToString)
                            Dim stFIPRLOCA As String = Trim(tblFichaPredial.Rows(0).Item("FIPRLOCA").ToString)
                            Dim stFIPRGACU As String = Trim(tblFichaPredial.Rows(0).Item("FIPRGACU").ToString)
                            Dim stFIPRGADE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRGADE").ToString)
                            Dim stFIPRDIRE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRDIRE").ToString)
                            Dim stFIPRCAPR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCAPR").ToString)

                            If Me.chkEdificioEnCeros.Checked = True Then
                                stFIPREDIF = "000"
                            End If

                            ' formato municipio actual
                            stFIPRMUNI = stFIPRMUNI.PadLeft(3, "0")
                            stFIPRMUNI = stFIPRMUNI.Substring(0, 3)

                            ' formato clase o sector actual
                            stFIPRCLSE = stFIPRCLSE.PadLeft(1, "0")
                            stFIPRCLSE = stFIPRCLSE.Substring(0, 1)

                            ' formato corregimiento actual
                            stFIPRCORR = stFIPRCORR.PadLeft(3, "0")
                            stFIPRCORR = stFIPRCORR.Substring(0, 3)

                            ' formato barrio actual
                            stFIPRBARR = stFIPRBARR.PadLeft(3, "0")
                            stFIPRBARR = stFIPRBARR.Substring(0, 3)

                            ' formato manzana actual
                            stFIPRMANZ = stFIPRMANZ.PadLeft(3, "0")
                            stFIPRMANZ = stFIPRMANZ.Substring(0, 3)

                            ' formato predio actual
                            stFIPRPRED = stFIPRPRED.PadLeft(5, "0")
                            stFIPRPRED = stFIPRPRED.Substring(0, 5)

                            ' formato edificio
                            stFIPREDIF = stFIPREDIF.PadLeft(5, "0")
                            stFIPREDIF = stFIPREDIF.Substring(0, 5)

                            ' formato área total de lote
                            stFIPRATLO = stFIPRATLO.PadLeft(10, "0")
                            stFIPRATLO = stFIPRATLO.Substring(0, 10)

                            ' formato área comun de lote
                            stFIPRACLO = stFIPRACLO.PadLeft(10, "0")
                            stFIPRACLO = stFIPRACLO.Substring(0, 10)

                            ' formato pisos
                            stFIPRPISO = stFIPRPISO.PadLeft(3, "0")
                            stFIPRPISO = stFIPRPISO.Substring(0, 3)

                            ' formato unidades en rph
                            stFIPRURPH = stFIPRURPH.PadLeft(4, "0")
                            stFIPRURPH = stFIPRURPH.Substring(0, 4)

                            ' formato apartamentos o casa
                            stFIPRAPCA = stFIPRAPCA.PadLeft(4, "0")
                            stFIPRAPCA = stFIPRAPCA.Substring(0, 4)

                            ' formato cuartos utilies
                            stFIPRCUUT = stFIPRCUUT.PadLeft(4, "0")
                            stFIPRCUUT = stFIPRCUUT.Substring(0, 4)

                            ' formato locales
                            stFIPRLOCA = stFIPRLOCA.PadLeft(4, "0")
                            stFIPRLOCA = stFIPRLOCA.Substring(0, 4)

                            ' formato garajes cubiertos
                            stFIPRGACU = stFIPRGACU.PadLeft(4, "0")
                            stFIPRGACU = stFIPRGACU.Substring(0, 4)

                            ' formato garajes descubiertos
                            stFIPRGADE = stFIPRGADE.PadLeft(4, "0")
                            stFIPRGADE = stFIPRGADE.Substring(0, 4)

                            ' formato dirección
                            stFIPRDIRE = stFIPRDIRE.PadRight(49, " ")
                            stFIPRDIRE = stFIPRDIRE.Substring(0, 49)

                            ' formato caracteristica de predio
                            stFIPRCAPR = stFIPRCAPR.PadLeft(1, "0")
                            stFIPRCAPR = stFIPRCAPR.Substring(0, 1)

                            ' exportar los datos
                            PrintLine(1, stFIPRIDRE & stSeparador & _
                                         stFIPRMUNI & stSeparador & _
                                         stFIPRCLSE & stSeparador & _
                                         stFIPRCORR & stSeparador & _
                                         stFIPRBARR & stSeparador & _
                                         stFIPRMANZ & stSeparador & _
                                         stFIPRPRED & stSeparador & _
                                         stFIPREDIF & stSeparador & _
                                         stFIPRATLO & stSeparador & _
                                         stFIPRACLO & stSeparador & _
                                         stFIPRPISO & stSeparador & _
                                         stFIPRURPH & stSeparador & _
                                         stFIPRAPCA & stSeparador & _
                                         stFIPRCUUT & stSeparador & _
                                         stFIPRLOCA & stSeparador & _
                                         stFIPRGACU & stSeparador & _
                                         stFIPRGADE & stSeparador & _
                                         stFIPRDIRE & stSeparador & _
                                         stFIPRCAPR)

                            ' Incrementa la barra
                            inProceso = inProceso + 1
                            pbProcesoAdministrativa.Value = inProceso

                        Next

                        '===================================
                        '*** ID : 3 EXPORTA CONSTRUCCIÓN ***
                        '===================================

                        Dim h As Integer = 0

                        For h = 0 To dt_FR_1_Y_2.Rows.Count - 1

                            ' crea la tabla
                            tblConstruccion = New DataTable

                            ' almacena consulta
                            tblConstruccion = objConstruccion.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(dt_FR_1_Y_2.Rows(h).Item("FIPRNUFI"))

                            ' recorro la tabla
                            Dim c As Integer = 0

                            For c = 0 To tblConstruccion.Rows.Count - 1

                                ' verifica que se encuentre activa
                                If Trim(tblConstruccion.Rows(c).Item("FPCOESTA").ToString) = "ac" Then

                                    ' instancia la clase
                                    objCedula = New cla_FICHPRED
                                    tblCedula = New DataTable

                                    ' consulta la cedula catastral por numero de ficha
                                    tblCedula = objCedula.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(tblConstruccion.Rows(c).Item("FPCONUFI"))

                                    ' variables directas
                                    Dim stFPCOIDRE As String = "3"
                                    Dim stFPCOMUNI As String = Trim(tblCedula.Rows(0).Item("FIPRMUNI").ToString)
                                    Dim stFPCOCLSE As String = Trim(tblCedula.Rows(0).Item("FIPRCLSE").ToString)
                                    Dim stFPCOCORR As String = Trim(tblCedula.Rows(0).Item("FIPRCORR").ToString)
                                    Dim stFPCOBARR As String = Trim(tblCedula.Rows(0).Item("FIPRBARR").ToString)
                                    Dim stFPCOMANZ As String = Trim(tblCedula.Rows(0).Item("FIPRMANZ").ToString)
                                    Dim stFPCOPRED As String = Trim(tblCedula.Rows(0).Item("FIPRPRED").ToString)
                                    Dim stFPCOEDIF As String = Trim(tblCedula.Rows(0).Item("FIPREDIF").ToString)

                                    Dim stFPCOUNID As String = Trim(tblConstruccion.Rows(c).Item("FPCOUNID").ToString)
                                    Dim stFPCOTIPO As String = Trim(fun_BuscaTipoDeCalificación(vp_Departamento, Trim(tblConstruccion.Rows(c).Item("FPCOMUNI").ToString), tblConstruccion.Rows(c).Item("FPCOCLCO").ToString, tblConstruccion.Rows(c).Item("FPCOCLSE").ToString, Trim(tblConstruccion.Rows(c).Item("FPCOTICO").ToString)))
                                    Dim stFPCOTICO As String = fun_Quita_Letras(Trim(tblConstruccion.Rows(c).Item("FPCOTICO").ToString))
                                    Dim stFPCOARCO As String = Trim(tblConstruccion.Rows(c).Item("FPCOARCO").ToString)
                                    Dim stFPCOPUNT As String = Trim(tblConstruccion.Rows(c).Item("FPCOPUNT").ToString)
                                    Dim stFPCOACUE As String = Trim(tblConstruccion.Rows(c).Item("FPCOACUE").ToString)
                                    Dim stFPCOALCA As String = Trim(tblConstruccion.Rows(c).Item("FPCOALCA").ToString)
                                    Dim stFPCOENER As String = Trim(tblConstruccion.Rows(c).Item("FPCOENER").ToString)
                                    Dim stFPCOTELE As String = Trim(tblConstruccion.Rows(c).Item("FPCOTELE").ToString)
                                    Dim stFPCOGAS As String = Trim(tblConstruccion.Rows(c).Item("FPCOGAS").ToString)
                                    Dim stFPCOPISO As String = Trim(tblConstruccion.Rows(c).Item("FPCOPISO").ToString)
                                    Dim stFPCOPOCO As String = Trim(tblConstruccion.Rows(c).Item("FPCOPOCO").ToString)
                                    Dim stFPCOEDCO As String = Trim(tblConstruccion.Rows(c).Item("FPCOEDCO").ToString)

                                    If Me.chkEdificioEnCeros.Checked = True Then
                                        stFPCOEDIF = "000"
                                    End If

                                    ' formato municipio actual
                                    stFPCOMUNI = stFPCOMUNI.PadLeft(3, "0")
                                    stFPCOMUNI = stFPCOMUNI.Substring(0, 3)

                                    ' formato clase o sector actual
                                    stFPCOCLSE = stFPCOCLSE.PadLeft(1, "0")
                                    stFPCOCLSE = stFPCOCLSE.Substring(0, 1)

                                    ' formato corregimiento actual
                                    stFPCOCORR = stFPCOCORR.PadLeft(3, "0")
                                    stFPCOCORR = stFPCOCORR.Substring(0, 3)

                                    ' formato barrio actual
                                    stFPCOBARR = stFPCOBARR.PadLeft(3, "0")
                                    stFPCOBARR = stFPCOBARR.Substring(0, 3)

                                    ' formato manzana actual
                                    stFPCOMANZ = stFPCOMANZ.PadLeft(3, "0")
                                    stFPCOMANZ = stFPCOMANZ.Substring(0, 3)

                                    ' formato predio actual
                                    stFPCOPRED = stFPCOPRED.PadLeft(5, "0")
                                    stFPCOPRED = stFPCOPRED.Substring(0, 5)

                                    ' formato edificio
                                    stFPCOEDIF = stFPCOEDIF.PadLeft(5, "0")
                                    stFPCOEDIF = stFPCOEDIF.Substring(0, 5)

                                    ' formato unidad 
                                    stFPCOUNID = stFPCOUNID.PadLeft(5, "0")
                                    stFPCOUNID = stFPCOUNID.Substring(0, 5)

                                    ' formato tipo de calificación
                                    stFPCOTIPO = stFPCOTIPO.PadRight(1, " ")
                                    stFPCOTIPO = stFPCOTIPO.Substring(0, 1)

                                    ' formato tipo de construcción
                                    stFPCOTICO = stFPCOTICO.PadLeft(3, "0")
                                    stFPCOTICO = stFPCOTICO.Substring(0, 3)

                                    ' formato área de construcción
                                    stFPCOARCO = stFPCOARCO.Replace(".", "")
                                    stFPCOARCO = stFPCOARCO.PadLeft(8, "0")
                                    stFPCOARCO = stFPCOARCO.Substring(0, 8)

                                    ' formato puntos
                                    stFPCOPUNT = stFPCOPUNT.PadLeft(3, "0")
                                    stFPCOPUNT = stFPCOPUNT.Substring(0, 3)

                                    ' formato acueducto
                                    stFPCOACUE = stFPCOACUE.PadLeft(1, "0")
                                    stFPCOACUE = stFPCOACUE.Substring(0, 1)

                                    ' formato alcantarillado
                                    stFPCOALCA = stFPCOALCA.PadLeft(1, "0")
                                    stFPCOALCA = stFPCOALCA.Substring(0, 1)

                                    ' formato energia
                                    stFPCOENER = stFPCOENER.PadLeft(1, "0")
                                    stFPCOENER = stFPCOENER.Substring(0, 1)

                                    ' formato telefono
                                    stFPCOTELE = stFPCOTELE.PadLeft(1, "0")
                                    stFPCOTELE = stFPCOTELE.Substring(0, 1)

                                    ' formato gas
                                    stFPCOGAS = stFPCOGAS.PadLeft(1, "0")
                                    stFPCOGAS = stFPCOGAS.Substring(0, 1)

                                    ' formato numero de pisos
                                    stFPCOPISO = stFPCOPISO.PadLeft(2, "0")
                                    stFPCOPISO = stFPCOPISO.Substring(0, 2)

                                    ' formato porcentaje construido
                                    stFPCOPOCO = stFPCOPOCO.PadLeft(3, "0")
                                    stFPCOPOCO = stFPCOPOCO & "00"
                                    stFPCOPOCO = stFPCOPOCO.Substring(0, 5)

                                    ' formato edad de construcción
                                    stFPCOEDCO = stFPCOEDCO.PadLeft(4, "0")
                                    stFPCOEDCO = stFPCOEDCO.Substring(0, 4)

                                    ' exportar los datos
                                    PrintLine(1, stFPCOIDRE & stSeparador & _
                                                 stFPCOMUNI & stSeparador & _
                                                 stFPCOCLSE & stSeparador & _
                                                 stFPCOCORR & stSeparador & _
                                                 stFPCOBARR & stSeparador & _
                                                 stFPCOMANZ & stSeparador & _
                                                 stFPCOPRED & stSeparador & _
                                                 stFPCOEDIF & stSeparador & _
                                                 stFPCOUNID & stSeparador & _
                                                 stFPCOTIPO & stSeparador & _
                                                 stFPCOTICO & stSeparador & _
                                                 stFPCOARCO & stSeparador & _
                                                 stFPCOPUNT & stSeparador & _
                                                 stFPCOACUE & stSeparador & _
                                                 stFPCOALCA & stSeparador & _
                                                 stFPCOENER & stSeparador & _
                                                 stFPCOTELE & stSeparador & _
                                                 stFPCOGAS & stSeparador & _
                                                 stFPCOPISO & stSeparador & _
                                                 stFPCOPOCO & stSeparador & _
                                                 stFPCOEDCO)

                                    ' Incrementa la barra
                                    inProceso = inProceso + 1
                                    pbProcesoAdministrativa.Value = inProceso

                                End If

                            Next

                        Next

                        '===================================
                        '*** ID : 4 EXPORTA CALIFICACIÓN ***
                        '===================================

                        Dim f As Integer = 0

                        For f = 0 To dt_FR_1_Y_2.Rows.Count - 1

                            ' crea la tabla
                            tblCalificacion = New DataTable

                            ' almacena consulta
                            tblCalificacion = objCalificacion.fun_Consultar_FIPRCACO_X_FICHA_PREDIAL_TODAS_LAS_UNIDADES(dt_FR_1_Y_2.Rows(f).Item("FIPRNUFI"))

                            ' recorro la tabla
                            Dim d As Integer = 0

                            For d = 0 To tblCalificacion.Rows.Count - 1

                                ' verifica que se encuentre activa
                                If Trim(tblCalificacion.Rows(d).Item("FPCCESTA").ToString) = "ac" Then

                                    ' instancia la clase
                                    objCedula = New cla_FICHPRED
                                    tblCedula = New DataTable

                                    tblCedula = objCedula.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(tblCalificacion.Rows(d).Item("FPCCNUFI"))

                                    ' variables directas
                                    Dim stFPCCIDRE As String = "4"
                                    Dim stFPCCMUNI As String = Trim(tblCedula.Rows(0).Item("FIPRMUNI").ToString)
                                    Dim stFPCCCLSE As String = Trim(tblCedula.Rows(0).Item("FIPRCLSE").ToString)
                                    Dim stFPCCCORR As String = Trim(tblCedula.Rows(0).Item("FIPRCORR").ToString)
                                    Dim stFPCCBARR As String = Trim(tblCedula.Rows(0).Item("FIPRBARR").ToString)
                                    Dim stFPCCMANZ As String = Trim(tblCedula.Rows(0).Item("FIPRMANZ").ToString)
                                    Dim stFPCCPRED As String = Trim(tblCedula.Rows(0).Item("FIPRPRED").ToString)
                                    Dim stFPCCEDIF As String = Trim(tblCedula.Rows(0).Item("FIPREDIF").ToString)

                                    Dim stFPCCUNID As String = Trim(tblCalificacion.Rows(d).Item("FPCCUNID").ToString)
                                    Dim stFPCCCODI As String = Trim(tblCalificacion.Rows(d).Item("FPCCCODI").ToString)
                                    Dim stFPCCTIPO As String = Trim(tblCalificacion.Rows(d).Item("FPCCTIPO").ToString)
                                    Dim stFPCCPUNT As String = Trim(tblCalificacion.Rows(d).Item("FPCCPUNT").ToString)

                                    If Me.chkEdificioEnCeros.Checked = True Then
                                        stFPCCEDIF = "000"
                                    End If

                                    ' formato municipio actual
                                    stFPCCMUNI = stFPCCMUNI.PadLeft(3, "0")
                                    stFPCCMUNI = stFPCCMUNI.Substring(0, 3)

                                    ' formato clase o sector actual
                                    stFPCCCLSE = stFPCCCLSE.PadLeft(1, "0")
                                    stFPCCCLSE = stFPCCCLSE.Substring(0, 1)

                                    ' formato corregimiento actual
                                    stFPCCCORR = stFPCCCORR.PadLeft(3, "0")
                                    stFPCCCORR = stFPCCCORR.Substring(0, 3)

                                    ' formato barrio actual
                                    stFPCCBARR = stFPCCBARR.PadLeft(3, "0")
                                    stFPCCBARR = stFPCCBARR.Substring(0, 3)

                                    ' formato manzana actual
                                    stFPCCMANZ = stFPCCMANZ.PadLeft(3, "0")
                                    stFPCCMANZ = stFPCCMANZ.Substring(0, 3)

                                    ' formato predio actual
                                    stFPCCPRED = stFPCCPRED.PadLeft(5, "0")
                                    stFPCCPRED = stFPCCPRED.Substring(0, 5)

                                    ' formato edificio
                                    stFPCCEDIF = stFPCCEDIF.PadLeft(5, "0")
                                    stFPCCEDIF = stFPCCEDIF.Substring(0, 5)

                                    ' formato unidad 
                                    stFPCCUNID = stFPCCUNID.PadLeft(5, "0")
                                    stFPCCUNID = stFPCCUNID.Substring(0, 5)

                                    ' formato código de calificación
                                    stFPCCCODI = stFPCCCODI.PadLeft(3, "0")
                                    stFPCCCODI = stFPCCCODI.Substring(0, 3)

                                    ' formato tipo de calificación
                                    stFPCCTIPO = stFPCCTIPO.PadRight(1, " ")
                                    stFPCCTIPO = stFPCCTIPO.Substring(0, 1)

                                    ' formato puntos
                                    stFPCCPUNT = stFPCCPUNT.PadLeft(3, "0")
                                    stFPCCPUNT = stFPCCPUNT.Substring(0, 3)

                                    ' exportar los datos
                                    PrintLine(1, stFPCCIDRE & stSeparador & _
                                                 stFPCCMUNI & stSeparador & _
                                                 stFPCCCLSE & stSeparador & _
                                                 stFPCCCORR & stSeparador & _
                                                 stFPCCBARR & stSeparador & _
                                                 stFPCCMANZ & stSeparador & _
                                                 stFPCCPRED & stSeparador & _
                                                 stFPCCEDIF & stSeparador & _
                                                 stFPCCUNID & stSeparador & _
                                                 stFPCCCODI & stSeparador & _
                                                 stFPCCTIPO & stSeparador & _
                                                 stFPCCPUNT)

                                    ' Incrementa la barra
                                    inProceso = inProceso + 1
                                    pbProcesoAdministrativa.Value = inProceso

                                End If

                            Next

                        Next

                        '==================================
                        '*** ID : 5 EXPORTA CARTOGRAFIA ***
                        '==================================

                        Dim r As Integer = 0

                        For r = 0 To dt_FR_1_Y_2.Rows.Count - 1

                            ' crea la tabla
                            tblCartografia = New DataTable

                            ' almacena consulta
                            tblCartografia = objCartografia.fun_Consultar_FIPRCART_X_FICHA_PREDIAL(dt_FR_1_Y_2.Rows(r).Item("FIPRNUFI"))

                            ' recorro la tabla
                            Dim d As Integer = 0

                            For d = 0 To tblCartografia.Rows.Count - 1

                                ' verifica que se encuentre activa
                                If Trim(tblCartografia.Rows(d).Item("FPCAESTA").ToString) = "ac" Then

                                    ' instancia la clase
                                    objCedula = New cla_FICHPRED
                                    tblCedula = New DataTable

                                    tblCedula = objCedula.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(tblCartografia.Rows(d).Item("FPCANUFI"))

                                    ' variables directas
                                    Dim stFPCAIDRE As String = "5"
                                    Dim stFPCAMUNI As String = Trim(tblCedula.Rows(0).Item("FIPRMUNI").ToString)
                                    Dim stFPCACLSE As String = Trim(tblCedula.Rows(0).Item("FIPRCLSE").ToString)
                                    Dim stFPCACORR As String = Trim(tblCedula.Rows(0).Item("FIPRCORR").ToString)
                                    Dim stFPCABARR As String = Trim(tblCedula.Rows(0).Item("FIPRBARR").ToString)
                                    Dim stFPCAMANZ As String = Trim(tblCedula.Rows(0).Item("FIPRMANZ").ToString)
                                    Dim stFPCAPRED As String = Trim(tblCedula.Rows(0).Item("FIPRPRED").ToString)
                                    Dim stFPCAEDIF As String = Trim(tblCedula.Rows(0).Item("FIPREDIF").ToString)
                                    Dim stFPCAPLAN As String = Trim(tblCartografia.Rows(d).Item("FPCAPLAN").ToString)
                                    Dim stFPCAVENT As String = Trim(tblCartografia.Rows(d).Item("FPCAVENT").ToString)
                                    Dim stFPCAESGR As String = Trim(tblCartografia.Rows(d).Item("FPCAESGR").ToString)
                                    Dim stFPCAVIGR As String = Trim(tblCartografia.Rows(d).Item("FPCAVIGR").ToString)
                                    Dim stFPCAVUEL As String = Trim(tblCartografia.Rows(d).Item("FPCAVUEL").ToString)
                                    Dim stFPCAFAJA As String = Trim(tblCartografia.Rows(d).Item("FPCAFAJA").ToString)
                                    Dim stFPCAFOTO As String = Trim(tblCartografia.Rows(d).Item("FPCAFOTO").ToString)
                                    Dim stFPCAVIAE As String = Trim(tblCartografia.Rows(d).Item("FPCAVIAE").ToString)
                                    Dim stFPCAAMPL As String = Trim(tblCartografia.Rows(d).Item("FPCAAMPL").ToString)
                                    Dim stFPCAESAE As String = Trim(tblCartografia.Rows(d).Item("FPCAESAE").ToString)

                                    If Me.chkEdificioEnCeros.Checked = True Then
                                        stFPCAEDIF = "000"
                                    End If

                                    ' formato municipio actual
                                    stFPCAMUNI = stFPCAMUNI.PadLeft(3, "0")
                                    stFPCAMUNI = stFPCAMUNI.Substring(0, 3)

                                    ' formato clase o sector actual
                                    stFPCACLSE = stFPCACLSE.PadLeft(1, "0")
                                    stFPCACLSE = stFPCACLSE.Substring(0, 1)

                                    ' formato corregimiento actual
                                    stFPCACORR = stFPCACORR.PadLeft(3, "0")
                                    stFPCACORR = stFPCACORR.Substring(0, 3)

                                    ' formato barrio actual
                                    stFPCABARR = stFPCABARR.PadLeft(3, "0")
                                    stFPCABARR = stFPCABARR.Substring(0, 3)

                                    ' formato manzana actual
                                    stFPCAMANZ = stFPCAMANZ.PadLeft(3, "0")
                                    stFPCAMANZ = stFPCAMANZ.Substring(0, 3)

                                    ' formato predio actual
                                    stFPCAPRED = stFPCAPRED.PadLeft(5, "0")
                                    stFPCAPRED = stFPCAPRED.Substring(0, 5)

                                    ' formato edificio
                                    stFPCAEDIF = stFPCAEDIF.PadLeft(5, "0")
                                    stFPCAEDIF = stFPCAEDIF.Substring(0, 5)

                                    ' formato plancha
                                    stFPCAPLAN = stFPCAPLAN.PadRight(15, " ")
                                    stFPCAPLAN = stFPCAPLAN.Substring(0, 15)

                                    ' formato ventana
                                    stFPCAVENT = stFPCAVENT.PadRight(15, " ")
                                    stFPCAVENT = stFPCAVENT.Substring(0, 15)

                                    ' formato escala grafica
                                    stFPCAESGR = stFPCAESGR.PadRight(15, " ")
                                    stFPCAESGR = stFPCAESGR.Substring(0, 15)

                                    ' formato vigencia grafica
                                    stFPCAVIGR = stFPCAVIGR.PadLeft(4, "0")
                                    stFPCAVIGR = stFPCAVIGR.Substring(0, 4)

                                    ' formato vuelo
                                    stFPCAVUEL = stFPCAVUEL.PadRight(15, " ")
                                    stFPCAVUEL = stFPCAVUEL.Substring(0, 15)

                                    ' formato faja
                                    stFPCAFAJA = stFPCAFAJA.PadRight(15, " ")
                                    stFPCAFAJA = stFPCAFAJA.Substring(0, 15)

                                    ' formato foto
                                    stFPCAFOTO = stFPCAFOTO.PadRight(15, " ")
                                    stFPCAFOTO = stFPCAFOTO.Substring(0, 15)

                                    ' formato vigencia aerofotografica
                                    stFPCAVIAE = stFPCAVIAE.PadLeft(4, "0")
                                    stFPCAVIAE = stFPCAVIAE.Substring(0, 4)

                                    ' formato ampliación
                                    stFPCAAMPL = stFPCAAMPL.PadRight(15, " ")
                                    stFPCAAMPL = stFPCAAMPL.Substring(0, 15)

                                    ' formato escala aerofotografica
                                    stFPCAESAE = stFPCAESAE.PadRight(15, " ")
                                    stFPCAESAE = stFPCAESAE.Substring(0, 15)

                                    ' exportar los datos
                                    PrintLine(1, stFPCAIDRE & stSeparador & _
                                                 stFPCAMUNI & stSeparador & _
                                                 stFPCACLSE & stSeparador & _
                                                 stFPCACORR & stSeparador & _
                                                 stFPCABARR & stSeparador & _
                                                 stFPCAMANZ & stSeparador & _
                                                 stFPCAPRED & stSeparador & _
                                                 stFPCAEDIF & stSeparador & _
                                                 stFPCAPLAN & stSeparador & _
                                                 stFPCAVENT & stSeparador & _
                                                 stFPCAESGR & stSeparador & _
                                                 stFPCAVIGR & stSeparador & _
                                                 stFPCAVUEL & stSeparador & _
                                                 stFPCAFAJA & stSeparador & _
                                                 stFPCAFOTO & stSeparador & _
                                                 stFPCAVIAE & stSeparador & _
                                                 stFPCAAMPL & stSeparador & _
                                                 stFPCAESAE)

                                    ' Incrementa la barra
                                    inProceso = inProceso + 1
                                    pbProcesoAdministrativa.Value = inProceso

                                End If

                            Next

                        Next

                        '===============================
                        '*** ID : 6 EXPORTA LINDEROS ***
                        '===============================

                        Dim w As Integer = 0

                        For w = 0 To dt_FR_1_Y_2.Rows.Count - 1

                            ' crea la tabla
                            tblLinderos = New DataTable

                            ' almacena consulta
                            tblLinderos = objLinderos.fun_Consultar_FIPRLIND_X_FICHA_PREDIAL(dt_FR_1_Y_2.Rows(w).Item("FIPRNUFI"))

                            ' recorro la tabla
                            Dim d As Integer = 0

                            For d = 0 To tblLinderos.Rows.Count - 1

                                ' verifica que se encuentre activa
                                If Trim(tblLinderos.Rows(d).Item("FPLIESTA").ToString) = "ac" Then

                                    ' instancia la clase
                                    objCedula = New cla_FICHPRED
                                    tblCedula = New DataTable

                                    tblCedula = objCedula.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(tblLinderos.Rows(d).Item("FPLINUFI"))

                                    ' variables directas
                                    Dim stFPLIIDRE As String = "6"
                                    Dim stFPLIMUNI As String = Trim(tblCedula.Rows(0).Item("FIPRMUNI").ToString)
                                    Dim stFPLICLSE As String = Trim(tblCedula.Rows(0).Item("FIPRCLSE").ToString)
                                    Dim stFPLICORR As String = Trim(tblCedula.Rows(0).Item("FIPRCORR").ToString)
                                    Dim stFPLIBARR As String = Trim(tblCedula.Rows(0).Item("FIPRBARR").ToString)
                                    Dim stFPLIMANZ As String = Trim(tblCedula.Rows(0).Item("FIPRMANZ").ToString)
                                    Dim stFPLIPRED As String = Trim(tblCedula.Rows(0).Item("FIPRPRED").ToString)
                                    Dim stFPLIEDIF As String = Trim(tblCedula.Rows(0).Item("FIPREDIF").ToString)
                                    Dim stFPLIPUCA As String = Trim(tblLinderos.Rows(d).Item("FPLIPUCA").ToString)
                                    Dim stFPLICOLI As String = Trim(tblLinderos.Rows(d).Item("FPLICOLI").ToString)

                                    If Me.chkEdificioEnCeros.Checked = True Then
                                        stFPLIEDIF = "000"
                                    End If

                                    ' formato municipio actual
                                    stFPLIMUNI = stFPLIMUNI.PadLeft(3, "0")
                                    stFPLIMUNI = stFPLIMUNI.Substring(0, 3)

                                    ' formato clase o sector actual
                                    stFPLICLSE = stFPLICLSE.PadLeft(1, "0")
                                    stFPLICLSE = stFPLICLSE.Substring(0, 1)

                                    ' formato corregimiento actual
                                    stFPLICORR = stFPLICORR.PadLeft(3, "0")
                                    stFPLICORR = stFPLICORR.Substring(0, 3)

                                    ' formato barrio actual
                                    stFPLIBARR = stFPLIBARR.PadLeft(3, "0")
                                    stFPLIBARR = stFPLIBARR.Substring(0, 3)

                                    ' formato manzana actual
                                    stFPLIMANZ = stFPLIMANZ.PadLeft(3, "0")
                                    stFPLIMANZ = stFPLIMANZ.Substring(0, 3)

                                    ' formato predio actual
                                    stFPLIPRED = stFPLIPRED.PadLeft(5, "0")
                                    stFPLIPRED = stFPLIPRED.Substring(0, 5)

                                    ' formato edificio
                                    stFPLIEDIF = stFPLIEDIF.PadLeft(5, "0")
                                    stFPLIEDIF = stFPLIEDIF.Substring(0, 5)

                                    ' formato punto cardinal
                                    stFPLIPUCA = stFPLIPUCA.PadRight(2, " ")
                                    stFPLIPUCA = stFPLIPUCA.Substring(0, 2)

                                    ' formato colindante
                                    stFPLICOLI = stFPLICOLI.PadRight(30, " ")
                                    stFPLICOLI = stFPLICOLI.Substring(0, 30)

                                    ' exportar los datos
                                    PrintLine(1, stFPLIIDRE & stSeparador & _
                                                 stFPLIMUNI & stSeparador & _
                                                 stFPLICLSE & stSeparador & _
                                                 stFPLICORR & stSeparador & _
                                                 stFPLIBARR & stSeparador & _
                                                 stFPLIMANZ & stSeparador & _
                                                 stFPLIPRED & stSeparador & _
                                                 stFPLIEDIF & stSeparador & _
                                                 stFPLIPUCA & stSeparador & _
                                                 stFPLICOLI)

                                    ' Incrementa la barra
                                    inProceso = inProceso + 1
                                    pbProcesoAdministrativa.Value = inProceso

                                End If

                            Next

                        Next

                        ' coloca la barra en cero
                        pbProcesoAdministrativa.Value = 0

                        MessageBox.Show("Archivo plano creado corectamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                        ' prende el boton
                        Me.cmdExportarPlanoAdministrativa.Enabled = True

                        If MessageBox.Show("¿ Desea abrir el archivo plano ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                            ' Abrir con Process.Start el archivo de texto
                            Process.Start(stRutaArchivoAdministrativa)
                        End If

                    Else
                        MessageBox.Show("No existen registros en base de datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        cmdExportarPlanoAdministrativa.Focus()
                    End If

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub

    Private Sub pro_ExportarPlanoFichaPredialParametrizada()

        Try
            ' verifica la ruta del acchivo
            If Trim(stRutaArchivoParametrizada) <> "" Then

                ' recorre el archivo a exportar
                FileOpen(1, oCrear.FileName, OpenMode.Output) 'crea y destruye si hay otro igual

                'variable separador
                Dim stSeparador As String = Trim(Me.txtSEPARADOR.Text)

                ' apaga el boton
                Me.cmdExportarPlanoActualizacion.Enabled = False

                '==========================
                '*** GENERA LA CONSULTA ***
                '==========================

                ' crea un datable
                dt = New DataTable

                ' llena el datatable con la consulta
                dt = fun_EjecutarConsultaParametrizadaFichaPredial()

                '============================
                '*** CUENTA LOS REGISTROS ***
                '============================

                inProceso = 0
                pbProcesoActualizacion.Value = 0
                pbProcesoActualizacion.Maximum = dt.Rows.Count
                Timer1.Enabled = True

                '==========================
                '*** EXPORTA RESOLUCIÓN ***
                '==========================

                ' numero de registros
                Dim vl_stRESONURE As String = dt.Rows.Count.ToString

                ' área de terreno total
                Dim vl_stRESOARTE As String = CType(fun_Formato_Decimal_4_Decimales((fun_Suma_Area_De_Terreno(dt) / 10000)), String)

                ' área de construcción total
                Dim vl_stRESOARCO As String = CType(fun_Formato_Decimal_2_Decimales(fun_Suma_Area_De_Construccion(dt)), String)

                ' suma de puntos de calificación
                Dim vl_stRESOPUNT As String = CType(fun_Suma_Puntos_De_Calificacion(dt), String)

                ' variales directas
                Dim stRESOIDRE As String = "1"
                Dim stRESOVIGE As String = Trim(Me.txtFIPRVIGE_RESO.Text)
                Dim stRESOTIRE As String = Trim(Me.txtFIPRTIRE_RESO.Text)
                Dim stRESORESO As String = Trim(Me.txtFIPRRESO_RESO.Text)
                Dim stRESOMUNI As String = Trim(Me.txtFIPRMUNI_RESO.Text)
                Dim stRESOCLSE As String = Trim(Me.txtFIPRCLSE_RESO.Text)
                Dim stRESONURE As String = vl_stRESONURE
                Dim stRESOARTE As String = vl_stRESOARTE
                Dim stRESOARCO As String = vl_stRESOARCO
                Dim stRESOSUPU As String = vl_stRESOPUNT
                Dim stRESOPATO As String = "1"

                ' parcial o total
                If stRESOPATO = 0 Then
                    stRESOPATO = 2
                Else
                    stRESOPATO = 1
                End If

                ' formato vigencia
                stRESOVIGE = stRESOVIGE.PadLeft(4, "0")
                stRESOVIGE = stRESOVIGE.Substring(0, 4)

                ' formato tipo de resolución
                stRESOTIRE = stRESOTIRE.PadLeft(3, "0")
                stRESOTIRE = stRESOTIRE.Substring(0, 3)

                ' formato resolución
                stRESORESO = stRESORESO.PadLeft(7, "0")
                stRESORESO = stRESORESO.Substring(0, 7)

                ' formato municipio
                stRESOMUNI = stRESOMUNI.PadLeft(3, "0")
                stRESOMUNI = stRESOMUNI.Substring(0, 3)

                ' formato clase o sector
                stRESOCLSE = stRESOCLSE.PadLeft(1, "0")
                stRESOCLSE = stRESOCLSE.Substring(0, 1)

                ' formato numero de registro
                stRESONURE = stRESONURE.PadLeft(7, "0")
                stRESONURE = stRESONURE.Substring(0, 7)

                ' formato área de terreno
                stRESOARTE = stRESOARTE.Replace(".", "")
                stRESOARTE = stRESOARTE.PadLeft(12, "0")
                stRESOARTE = stRESOARTE.Substring(0, 12)

                ' formato área de construcción
                stRESOARCO = stRESOARCO.Replace(".", "")
                stRESOARCO = stRESOARCO.PadLeft(10, "0")
                stRESOARCO = stRESOARCO.Substring(0, 10)

                ' formato suma de puntos
                stRESOSUPU = stRESOSUPU.PadLeft(10, "0")
                stRESOSUPU = stRESOSUPU.Substring(0, 10)

                ' formato parcial o total
                stRESOPATO = stRESOPATO.PadLeft(1, "0")
                stRESOPATO = stRESOPATO.Substring(0, 1)

                ' exportar los datos
                PrintLine(1, stRESOIDRE & stSeparador & _
                             stRESOVIGE & stSeparador & _
                             stRESOTIRE & stSeparador & _
                             stRESORESO & stSeparador & _
                             stRESOMUNI & stSeparador & _
                             stRESOCLSE & stSeparador & _
                             stRESONURE & stSeparador & _
                             stRESOARTE & stSeparador & _
                             stRESOARCO & stSeparador & _
                             stRESOSUPU & stSeparador & _
                             stRESOPATO)

                ' recorre la consulta
                If dt.Rows.Count > 0 Then

                    '=============================
                    '*** EXPORTA FICHA PREDIAL ***
                    '=============================

                    Dim i As Integer = 0

                    For i = 0 To dt.Rows.Count - 1

                        ' crea la tabla
                        tblFichaPredial = New DataTable

                        ' almacena consulta
                        tblFichaPredial = objFichaPredial.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dt.Rows(i).Item("FIPRNUFI"))

                        ' variables directas
                        Dim stFIPRIDRE As String = "2"
                        Dim stFIPRVIGE As String = Trim(Me.txtFIPRVIGE_RESO.Text)
                        Dim stFIPRTIRE As String = Trim(Me.txtFIPRTIRE_RESO.Text)
                        Dim stFIPRRESO As String = Trim(Me.txtFIPRRESO_RESO.Text)
                        Dim stFIPRNUFI As String = Trim(tblFichaPredial.Rows(0).Item("FIPRNUFI").ToString)
                        Dim stFIPRNURE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRNURE").ToString)
                        Dim stFIPRMUNI As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMUNI").ToString)
                        Dim stFIPRCLSE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCLSE").ToString)
                        Dim stFIPRCORR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCORR").ToString)
                        Dim stFIPRBARR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRBARR").ToString)
                        Dim stFIPRMANZ As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMANZ").ToString)
                        Dim stFIPRPRED As String = Trim(tblFichaPredial.Rows(0).Item("FIPRPRED").ToString)
                        Dim stFIPREDIF As String = Trim(tblFichaPredial.Rows(0).Item("FIPREDIF").ToString)
                        Dim stFIPRUNPR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRUNPR").ToString)
                        Dim stFIPRARTE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRARTE").ToString)
                        Dim stFIPRDIRE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRDIRE").ToString)
                        Dim stFIPRCAPR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCAPR").ToString)
                        Dim stFIPRCASU As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCASU").ToString)
                        Dim stFIPRCOPR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCOPR").ToString)
                        Dim stFIPRCOED As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCOED").ToString)
                        Dim stFIPRMUAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMUAN").ToString)
                        Dim stFIPRCSAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCSAN").ToString)
                        Dim stFIPRCOAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCOAN").ToString)
                        Dim stFIPRBAAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRBAAN").ToString)
                        Dim stFIPRMAAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMAAN").ToString)
                        Dim stFIPRPRAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRPRAN").ToString)
                        Dim stFIPREDAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPREDAN").ToString)
                        Dim stFIPRUPAN As String = Trim(tblFichaPredial.Rows(0).Item("FIPRUPAN").ToString)
                        Dim stFIPRCASA As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCASA").ToString)

                        ' formato vigencia
                        stFIPRVIGE = stFIPRVIGE.PadLeft(4, "0")
                        stFIPRVIGE = stFIPRVIGE.Substring(0, 4)

                        ' formato tipo de resolución
                        stFIPRTIRE = stFIPRTIRE.PadLeft(3, "0")
                        stFIPRTIRE = stFIPRTIRE.Substring(0, 3)

                        ' formato resolución
                        stFIPRRESO = stFIPRRESO.PadLeft(7, "0")
                        stFIPRRESO = stFIPRRESO.Substring(0, 7)

                        ' formato numero de ficha
                        stFIPRNUFI = stFIPRNUFI.PadLeft(9, "0")
                        stFIPRNUFI = stFIPRNUFI.Substring(0, 9)

                        ' formato numero de registro
                        stFIPRNURE = stFIPRNURE.PadLeft(5, "0")
                        stFIPRNURE = stFIPRNURE.Substring(0, 5)

                        ' formato municipio actual
                        stFIPRMUNI = stFIPRMUNI.PadLeft(3, "0")
                        stFIPRMUNI = stFIPRMUNI.Substring(0, 3)

                        ' formato clase o sector actual
                        stFIPRCLSE = stFIPRCLSE.PadLeft(1, "0")
                        stFIPRCLSE = stFIPRCLSE.Substring(0, 1)

                        ' formato corregimiento actual
                        stFIPRCORR = stFIPRCORR.PadLeft(3, "0")
                        stFIPRCORR = stFIPRCORR.Substring(0, 3)

                        ' formato barrio actual
                        stFIPRBARR = stFIPRBARR.PadLeft(3, "0")
                        stFIPRBARR = stFIPRBARR.Substring(0, 3)

                        ' formato manzana actual
                        stFIPRMANZ = stFIPRMANZ.PadLeft(3, "0")
                        stFIPRMANZ = stFIPRMANZ.Substring(0, 3)

                        ' formato predio actual
                        stFIPRPRED = stFIPRPRED.PadLeft(5, "0")
                        stFIPRPRED = stFIPRPRED.Substring(0, 5)

                        ' formato edificio actual
                        stFIPREDIF = stFIPREDIF.PadLeft(5, "0")
                        stFIPREDIF = stFIPREDIF.Substring(0, 5)

                        ' formato unidad predial actual
                        stFIPRUNPR = stFIPRUNPR.PadLeft(5, "0")
                        stFIPRUNPR = stFIPRUNPR.Substring(0, 5)

                        ' formato área de terreno
                        stFIPRARTE = stFIPRARTE.PadLeft(10, "0")
                        stFIPRARTE = stFIPRARTE.Substring(0, 10)

                        ' formato dirección
                        stFIPRDIRE = stFIPRDIRE.PadRight(49, " ")
                        stFIPRDIRE = stFIPRDIRE.Substring(0, 49)

                        ' formato caracteristica de predio
                        stFIPRCAPR = stFIPRCAPR.PadLeft(1, "0")
                        stFIPRCAPR = stFIPRCAPR.Substring(0, 1)

                        ' formato categoria de suelo
                        stFIPRCASU = stFIPRCASU.PadLeft(1, "0")
                        stFIPRCASU = stFIPRCASU.Substring(0, 1)

                        ' formato coeficiente de predio
                        stFIPRCOPR = stFIPRCOPR.Replace(".", "")
                        stFIPRCOPR = stFIPRCOPR.PadLeft(9, "0")
                        stFIPRCOPR = stFIPRCOPR.Substring(0, 9)

                        ' formato coeficiente de edificio
                        stFIPRCOED = stFIPRCOED.Replace(".", "")
                        stFIPRCOED = stFIPRCOED.PadLeft(9, "0")
                        stFIPRCOED = stFIPRCOED.Substring(0, 9)

                        ' formato municipio anterior
                        stFIPRMUAN = stFIPRMUAN.PadLeft(3, "0")
                        stFIPRMUAN = stFIPRMUAN.Substring(0, 3)

                        ' formato clase o sector anterior
                        stFIPRCSAN = stFIPRCSAN.PadLeft(1, "0")
                        stFIPRCSAN = stFIPRCSAN.Substring(0, 1)

                        ' formato corregimiento anterior
                        stFIPRCOAN = stFIPRCOAN.PadLeft(3, "0")
                        stFIPRCOAN = stFIPRCOAN.Substring(0, 3)

                        ' formato barrio anterior
                        stFIPRBAAN = stFIPRBAAN.PadLeft(3, "0")
                        stFIPRBAAN = stFIPRBAAN.Substring(0, 3)

                        ' formato manzana anterior
                        stFIPRMAAN = stFIPRMAAN.PadLeft(3, "0")
                        stFIPRMAAN = stFIPRMAAN.Substring(0, 3)

                        ' formato predio anterior
                        stFIPRPRAN = stFIPRPRAN.PadLeft(5, "0")
                        stFIPRPRAN = stFIPRPRAN.Substring(0, 5)

                        ' formato edificio anterior
                        stFIPREDAN = stFIPREDAN.PadLeft(5, "0")
                        stFIPREDAN = stFIPREDAN.Substring(0, 5)

                        ' formato unidad predial anterior
                        stFIPRUPAN = stFIPRUPAN.PadLeft(5, "0")
                        stFIPRUPAN = stFIPRUPAN.Substring(0, 5)

                        ' formato clasificador de suelo anterior
                        stFIPRCASA = stFIPRCASA.PadLeft(1, "0")
                        stFIPRCASA = stFIPRCASA.Substring(0, 1)

                        ' exportar los datos
                        PrintLine(1, stFIPRIDRE & stSeparador & _
                                     stFIPRVIGE & stSeparador & _
                                     stFIPRTIRE & stSeparador & _
                                     stFIPRRESO & stSeparador & _
                                     stFIPRNUFI & stSeparador & _
                                     stFIPRNURE & stSeparador & _
                                     stFIPRMUNI & stSeparador & _
                                     stFIPRCLSE & stSeparador & _
                                     stFIPRCORR & stSeparador & _
                                     stFIPRBARR & stSeparador & _
                                     stFIPRMANZ & stSeparador & _
                                     stFIPRPRED & stSeparador & _
                                     stFIPREDIF & stSeparador & _
                                     stFIPRUNPR & stSeparador & _
                                     stFIPRARTE & stSeparador & _
                                     stFIPRDIRE & stSeparador & _
                                     stFIPRCAPR & stSeparador & _
                                     stFIPRCASU & stSeparador & _
                                     stFIPRCOPR & stSeparador & _
                                     stFIPRCOED & stSeparador & _
                                     stFIPRMUAN & stSeparador & _
                                     stFIPRCSAN & stSeparador & _
                                     stFIPRCOAN & stSeparador & _
                                     stFIPRBAAN & stSeparador & _
                                     stFIPRMAAN & stSeparador & _
                                     stFIPRPRAN & stSeparador & _
                                     stFIPREDAN & stSeparador & _
                                     stFIPRUPAN & stSeparador & _
                                     stFIPRCASA)

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbProcesoActualizacion.Value = inProceso

                    Next

                    '=====================================
                    '*** EXPORTA DESTINACIÓN ECONÓMICA ***
                    '=====================================

                    Dim k As Integer = 0

                    For k = 0 To dt.Rows.Count - 1

                        ' crea la tabla
                        tblDestino = New DataTable

                        ' almacena consulta
                        tblDestino = objDestino.fun_Consultar_FIPRDEEC_X_FICHA_PREDIAL(dt.Rows(k).Item("FIPRNUFI"))

                        Dim a As Integer = 0

                        For a = 0 To tblDestino.Rows.Count - 1

                            ' verifica que se encuentre activa
                            If Trim(tblDestino.Rows(a).Item("FPDEESTA").ToString) = "ac" Then

                                ' variables directas
                                Dim stFPDEIDRE As String = "3"
                                Dim stFPDEVIGE As String = Trim(Me.txtFIPRVIGE_RESO.Text)
                                Dim stFPDETIRE As String = Trim(Me.txtFIPRTIRE_RESO.Text)
                                Dim stFPDERESO As String = Trim(Me.txtFIPRRESO_RESO.Text)
                                Dim stFPDENUFI As String = Trim(tblDestino.Rows(a).Item("FPDENUFI").ToString)
                                Dim stFPDENURE As String = Trim(tblDestino.Rows(a).Item("FPDENURE").ToString)
                                Dim stFPDEDEEC As String = Trim(tblDestino.Rows(a).Item("FPDEDEEC").ToString)
                                Dim stFPDEPORC As String = Trim(tblDestino.Rows(a).Item("FPDEPORC").ToString)

                                ' formato vigencia
                                stFPDEVIGE = stFPDEVIGE.PadLeft(4, "0")
                                stFPDEVIGE = stFPDEVIGE.Substring(0, 4)

                                ' formato tipo de resolución
                                stFPDETIRE = stFPDETIRE.PadLeft(3, "0")
                                stFPDETIRE = stFPDETIRE.Substring(0, 3)

                                ' formato resolución
                                stFPDERESO = stFPDERESO.PadLeft(7, "0")
                                stFPDERESO = stFPDERESO.Substring(0, 7)

                                ' formato numero de ficha
                                stFPDENUFI = stFPDENUFI.PadLeft(9, "0")
                                stFPDENUFI = stFPDENUFI.Substring(0, 9)

                                ' formato numero de registro
                                stFPDENURE = stFPDENURE.PadLeft(5, "0")
                                stFPDENURE = stFPDENURE.Substring(0, 5)

                                ' formato destinación
                                stFPDEDEEC = stFPDEDEEC.PadLeft(2, "0")
                                stFPDEDEEC = stFPDEDEEC.Substring(0, 2)

                                ' formato porcentaje
                                stFPDEPORC = stFPDEPORC.PadLeft(3, "0")
                                stFPDEPORC = stFPDEPORC.Substring(0, 3)

                                ' exportar los datos
                                PrintLine(1, stFPDEIDRE & stSeparador & _
                                             stFPDEVIGE & stSeparador & _
                                             stFPDETIRE & stSeparador & _
                                             stFPDERESO & stSeparador & _
                                             stFPDENUFI & stSeparador & _
                                             stFPDENURE & stSeparador & _
                                             stFPDEDEEC & stSeparador & _
                                             stFPDEPORC)
                            End If

                        Next

                    Next

                    '============================
                    '*** EXPORTA PROPIETARIOS ***
                    '============================

                    Dim j As Integer = 0

                    For j = 0 To dt.Rows.Count - 1

                        ' crea la tabla
                        tblPropietarios = New DataTable

                        ' almacena consulta
                        tblPropietarios = objPropietarios.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(dt.Rows(j).Item("FIPRNUFI"))

                        Dim b As Integer = 0

                        For b = 0 To tblPropietarios.Rows.Count - 1

                            ' verifica que se encuentre activa
                            If Trim(tblPropietarios.Rows(b).Item("FPPRESTA").ToString) = "ac" Then

                                ' variables directas
                                Dim stFPPRIDRE As String = "4"
                                Dim stFPPRVIGE As String = Trim(Me.txtFIPRVIGE_RESO.Text)
                                Dim stFPPRTIRE As String = Trim(Me.txtFIPRTIRE_RESO.Text)
                                Dim stFPPRRESO As String = Trim(Me.txtFIPRRESO_RESO.Text)
                                Dim stFPPRNUFI As String = Trim(tblPropietarios.Rows(b).Item("FPPRNUFI").ToString)
                                Dim stFPPRNURE As String = Trim(tblPropietarios.Rows(b).Item("FPPRNURE").ToString)
                                Dim stFPPRTIDO As String = Trim(tblPropietarios.Rows(b).Item("FPPRTIDO").ToString)
                                Dim stFPPRNUDO As String = Trim(tblPropietarios.Rows(b).Item("FPPRNUDO").ToString)
                                Dim stFPPRPRAP As String = Trim(tblPropietarios.Rows(b).Item("FPPRPRAP").ToString)
                                Dim stFPPRNOMB As String = Trim(tblPropietarios.Rows(b).Item("FPPRNOMB").ToString)
                                Dim stFPPRDERE As String = Trim(tblPropietarios.Rows(b).Item("FPPRDERE").ToString)
                                Dim stFPPRNOTA As String = Trim(tblPropietarios.Rows(b).Item("FPPRDENO").ToString) & Trim(tblPropietarios.Rows(b).Item("FPPRMUNO").ToString) & Trim(tblPropietarios.Rows(b).Item("FPPRNOTA").ToString)
                                Dim stFPPRESCR As String = Trim(tblPropietarios.Rows(b).Item("FPPRESCR").ToString)
                                Dim stFPPRFEES As String = Trim(tblPropietarios.Rows(b).Item("FPPRFEES").ToString)
                                Dim stFPPRFERE As String = Trim(tblPropietarios.Rows(b).Item("FPPRFERE").ToString)
                                Dim stFPPRTOMO As String = Trim(tblPropietarios.Rows(b).Item("FPPRTOMO").ToString)
                                Dim stFPPRMAIN As String = Trim(tblPropietarios.Rows(b).Item("FPPRMAIN").ToString)
                                Dim stFPPRCAPR As String = Trim(tblPropietarios.Rows(b).Item("FPPRCAPR").ToString)
                                Dim boFPPRGRAV As Boolean = tblPropietarios.Rows(b).Item("FPPRGRAV").ToString
                                Dim stFPPRMOAD As String = Trim(tblPropietarios.Rows(b).Item("FPPRMOAD").ToString)
                                Dim boFPPRLITI As Boolean = tblPropietarios.Rows(b).Item("FPPRLITI").ToString
                                Dim stFPPRPOLI As String = Trim(tblPropietarios.Rows(b).Item("FPPRPOLI").ToString)
                                Dim stFPPRSEAP As String = Trim(tblPropietarios.Rows(b).Item("FPPRSEAP").ToString)
                                Dim stFPPRSICO As String = Trim(tblPropietarios.Rows(b).Item("FPPRSICO").ToString)
                                Dim stFPPRSEXO As String = Trim(tblPropietarios.Rows(b).Item("FPPRSEXO").ToString)

                                If Not IsDate(stFPPRFEES) Then
                                    stFPPRFEES = "          "
                                End If

                                If Not IsDate(stFPPRFERE) Then
                                    stFPPRFERE = "          "
                                End If

                                ' variables indirectas
                                Dim stFPPRLITI As String = ""
                                Dim stFPPRGRAV As String = ""

                                ' litigio
                                If boFPPRLITI = False Then
                                    stFPPRLITI = 2
                                Else
                                    stFPPRLITI = 1
                                End If

                                ' gravable
                                If boFPPRGRAV = False Then
                                    stFPPRGRAV = 2
                                Else
                                    stFPPRGRAV = 1
                                End If

                                ' tipo de documento
                                If stFPPRTIDO = 8 Then
                                    stFPPRNUDO = ""
                                End If

                                ' formato vigencia
                                stFPPRVIGE = stFPPRVIGE.PadLeft(4, "0")
                                stFPPRVIGE = stFPPRVIGE.Substring(0, 4)

                                ' formato tipo de resolución
                                stFPPRTIRE = stFPPRTIRE.PadLeft(3, "0")
                                stFPPRTIRE = stFPPRTIRE.Substring(0, 3)

                                ' formato resolución
                                stFPPRRESO = stFPPRRESO.PadLeft(7, "0")
                                stFPPRRESO = stFPPRRESO.Substring(0, 7)

                                ' formato numero de ficha
                                stFPPRNUFI = stFPPRNUFI.PadLeft(9, "0")
                                stFPPRNUFI = stFPPRNUFI.Substring(0, 9)

                                ' formato numero de registro
                                stFPPRNURE = stFPPRNURE.PadLeft(5, "0")
                                stFPPRNURE = stFPPRNURE.Substring(0, 5)

                                ' formato tipo de documento
                                stFPPRTIDO = stFPPRTIDO.PadLeft(2, "0")
                                stFPPRTIDO = stFPPRTIDO.Substring(0, 2)

                                ' formato numero de documento
                                stFPPRNUDO = stFPPRNUDO.PadRight(14, " ")
                                stFPPRNUDO = stFPPRNUDO.Substring(0, 14)

                                ' formato primer apellido
                                stFPPRPRAP = stFPPRPRAP.PadRight(15, " ")
                                stFPPRPRAP = stFPPRPRAP.Substring(0, 15)

                                ' formato nombre
                                stFPPRNOMB = stFPPRNOMB.PadRight(20, " ")
                                stFPPRNOMB = stFPPRNOMB.Substring(0, 20)

                                ' formato derecho
                                stFPPRDERE = stFPPRDERE.Replace(".", "")
                                stFPPRDERE = stFPPRDERE.PadLeft(9, "0")
                                stFPPRDERE = stFPPRDERE.Substring(0, 9)

                                ' formato notaria
                                stFPPRNOTA = stFPPRNOTA.PadRight(10, " ")
                                stFPPRNOTA = stFPPRNOTA.Substring(0, 10)

                                ' formato escritura
                                stFPPRESCR = stFPPRESCR.PadLeft(7, "0")
                                stFPPRESCR = stFPPRESCR.Substring(0, 7)

                                ' formato fecha de escritura
                                stFPPRFEES = stFPPRFEES.PadRight(10, " ")
                                stFPPRFEES = stFPPRFEES.Substring(0, 10)

                                ' formato fecha de registro
                                stFPPRFERE = stFPPRFERE.PadRight(10, " ")
                                stFPPRFERE = stFPPRFERE.Substring(0, 10)

                                ' formato tomo
                                stFPPRTOMO = stFPPRTOMO.PadLeft(3, "0")
                                stFPPRTOMO = stFPPRTOMO.Substring(0, 3)

                                ' formato matricula inmobiliaria
                                stFPPRMAIN = stFPPRMAIN.PadRight(15, " ")
                                stFPPRMAIN = stFPPRMAIN.Substring(0, 15)

                                ' formato calidad de propietario
                                stFPPRCAPR = stFPPRCAPR.PadLeft(2, "0")
                                stFPPRCAPR = stFPPRCAPR.Substring(0, 2)

                                ' formato gravable
                                stFPPRGRAV = stFPPRGRAV.PadLeft(1, "0")
                                stFPPRGRAV = stFPPRGRAV.Substring(0, 1)

                                ' formato modo de adquisición
                                stFPPRMOAD = stFPPRMOAD.PadLeft(1, "0")
                                stFPPRMOAD = stFPPRMOAD.Substring(0, 1)

                                ' formato litigio
                                stFPPRLITI = stFPPRLITI.PadLeft(1, "0")
                                stFPPRLITI = stFPPRLITI.Substring(0, 1)

                                ' formato porcentaje de litigio
                                stFPPRPOLI = stFPPRPOLI.Replace(".", "")
                                stFPPRPOLI = stFPPRPOLI.PadLeft(5, "0")
                                stFPPRPOLI = stFPPRPOLI.Substring(0, 5)

                                ' formato segundo apellido
                                stFPPRSEAP = stFPPRSEAP.PadRight(15, " ")
                                stFPPRSEAP = stFPPRSEAP.Substring(0, 15)

                                ' formato sigla comercial
                                stFPPRSICO = stFPPRSICO.PadRight(20, " ")
                                stFPPRSICO = stFPPRSICO.Substring(0, 20)

                                ' formato sexo
                                stFPPRSEXO = stFPPRSEXO.PadLeft(1, "0")
                                stFPPRSEXO = stFPPRSEXO.Substring(0, 1)

                                ' exportar los datos
                                PrintLine(1, stFPPRIDRE & stSeparador & _
                                             stFPPRVIGE & stSeparador & _
                                             stFPPRTIRE & stSeparador & _
                                             stFPPRRESO & stSeparador & _
                                             stFPPRNUFI & stSeparador & _
                                             stFPPRNURE & stSeparador & _
                                             stFPPRTIDO & stSeparador & _
                                             stFPPRNUDO & stSeparador & _
                                             stFPPRPRAP & stSeparador & _
                                             stFPPRNOMB & stSeparador & _
                                             stFPPRDERE & stSeparador & _
                                             stFPPRNOTA & stSeparador & _
                                             stFPPRESCR & stSeparador & _
                                             stFPPRFEES & stSeparador & _
                                             stFPPRFERE & stSeparador & _
                                             stFPPRTOMO & stSeparador & _
                                             stFPPRMAIN & stSeparador & _
                                             stFPPRCAPR & stSeparador & _
                                             stFPPRGRAV & stSeparador & _
                                             stFPPRMOAD & stSeparador & _
                                             stFPPRLITI & stSeparador & _
                                             stFPPRPOLI & stSeparador & _
                                             stFPPRSEAP & stSeparador & _
                                             stFPPRSICO & stSeparador & _
                                             stFPPRSEXO)
                            End If

                        Next

                    Next

                    '============================
                    '*** EXPORTA CONSTRUCCIÓN ***
                    '============================

                    Dim h As Integer = 0

                    For h = 0 To dt.Rows.Count - 1

                        ' crea la tabla
                        tblConstruccion = New DataTable

                        ' almacena consulta
                        tblConstruccion = objConstruccion.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(dt.Rows(h).Item("FIPRNUFI"))

                        Dim c As Integer = 0

                        For c = 0 To tblConstruccion.Rows.Count - 1

                            ' verifica que se encuentre activa
                            If Trim(tblConstruccion.Rows(c).Item("FPCOESTA").ToString) = "ac" Then

                                ' variables directas
                                Dim stFPCOIDRE As String = "5"
                                Dim stFPCOVIGE As String = Trim(Me.txtFIPRVIGE_RESO.Text)
                                Dim stFPCOTIRE As String = Trim(Me.txtFIPRTIRE_RESO.Text)
                                Dim stFPCORESO As String = Trim(Me.txtFIPRRESO_RESO.Text)
                                Dim stFPCONUFI As String = Trim(tblConstruccion.Rows(c).Item("FPCONUFI").ToString)
                                Dim stFPCONURE As String = Trim(tblConstruccion.Rows(c).Item("FPCONURE").ToString)
                                Dim stFPCOUNID As String = Trim(tblConstruccion.Rows(c).Item("FPCOUNID").ToString)
                                Dim stFPCOPUNT As String = Trim(tblConstruccion.Rows(c).Item("FPCOPUNT").ToString)
                                Dim stFPCOARCO As String = Trim(tblConstruccion.Rows(c).Item("FPCOARCO").ToString)
                                Dim boFPCOMEJO As Boolean = tblConstruccion.Rows(c).Item("FPCOMEJO").ToString
                                Dim boFPCOLEY As Boolean = tblConstruccion.Rows(c).Item("FPCOLEY").ToString
                                Dim stFPCOTICO As String = fun_Quita_Letras(Trim(tblConstruccion.Rows(c).Item("FPCOTICO").ToString))
                                Dim stFPCOACUE As String = Trim(tblConstruccion.Rows(c).Item("FPCOACUE").ToString)
                                Dim stFPCOTELE As String = Trim(tblConstruccion.Rows(c).Item("FPCOTELE").ToString)
                                Dim stFPCOALCA As String = Trim(tblConstruccion.Rows(c).Item("FPCOALCA").ToString)
                                Dim stFPCOENER As String = Trim(tblConstruccion.Rows(c).Item("FPCOENER").ToString)
                                Dim stFPCOGAS As String = Trim(tblConstruccion.Rows(c).Item("FPCOGAS").ToString)
                                Dim stFPCOPISO As String = Trim(tblConstruccion.Rows(c).Item("FPCOPISO").ToString)
                                Dim stFPCOPOCO As String = Trim(tblConstruccion.Rows(c).Item("FPCOPOCO").ToString)
                                Dim stFPCOEDCO As String = Trim(tblConstruccion.Rows(c).Item("FPCOEDCO").ToString)

                                ' variables indirectas
                                Dim stFPCOMEJO As String = ""
                                Dim stFPCOLEY As String = ""

                                ' mejora
                                If boFPCOMEJO = False Then
                                    stFPCOMEJO = 2
                                Else
                                    stFPCOMEJO = 1
                                End If

                                ' ley 56
                                If boFPCOLEY = False Then
                                    stFPCOLEY = 2
                                Else
                                    stFPCOLEY = 1
                                End If

                                ' formato vigencia
                                stFPCOVIGE = stFPCOVIGE.PadLeft(4, "0")
                                stFPCOVIGE = stFPCOVIGE.Substring(0, 4)

                                ' formato tipo de resolución
                                stFPCOTIRE = stFPCOTIRE.PadLeft(3, "0")
                                stFPCOTIRE = stFPCOTIRE.Substring(0, 3)

                                ' formato resolución
                                stFPCORESO = stFPCORESO.PadLeft(7, "0")
                                stFPCORESO = stFPCORESO.Substring(0, 7)

                                ' formato numero de ficha
                                stFPCONUFI = stFPCONUFI.PadLeft(9, "0")
                                stFPCONUFI = stFPCONUFI.Substring(0, 9)

                                ' formato numero de registro
                                stFPCONURE = stFPCONURE.PadLeft(5, "0")
                                stFPCONURE = stFPCONURE.Substring(0, 5)

                                ' formato unidad 
                                stFPCOUNID = stFPCOUNID.PadLeft(5, "0")
                                stFPCOUNID = stFPCOUNID.Substring(0, 5)

                                ' formato puntos
                                stFPCOPUNT = stFPCOPUNT.PadLeft(3, "0")
                                stFPCOPUNT = stFPCOPUNT.Substring(0, 3)

                                ' formato área de construcción
                                stFPCOARCO = stFPCOARCO.Replace(".", "")
                                stFPCOARCO = stFPCOARCO.PadLeft(9, "0")
                                stFPCOARCO = stFPCOARCO.Substring(0, 9)

                                ' formato mejora
                                stFPCOMEJO = stFPCOMEJO.PadLeft(1, "0")
                                stFPCOMEJO = stFPCOMEJO.Substring(0, 1)

                                ' formato ley 56
                                stFPCOLEY = stFPCOLEY.PadLeft(1, "0")
                                stFPCOLEY = stFPCOLEY.Substring(0, 1)

                                ' formato tipo de construcción
                                stFPCOTICO = stFPCOTICO.PadLeft(3, "0")
                                stFPCOTICO = stFPCOTICO.Substring(0, 3)

                                ' formato acueducto
                                stFPCOACUE = stFPCOACUE.PadLeft(1, "0")
                                stFPCOACUE = stFPCOACUE.Substring(0, 1)

                                ' formato telefono
                                stFPCOTELE = stFPCOTELE.PadLeft(1, "0")
                                stFPCOTELE = stFPCOTELE.Substring(0, 1)

                                ' formato alcantarillado
                                stFPCOALCA = stFPCOALCA.PadLeft(1, "0")
                                stFPCOALCA = stFPCOALCA.Substring(0, 1)

                                ' formato energia
                                stFPCOENER = stFPCOENER.PadLeft(1, "0")
                                stFPCOENER = stFPCOENER.Substring(0, 1)

                                ' formato gas
                                stFPCOGAS = stFPCOGAS.PadLeft(1, "0")
                                stFPCOGAS = stFPCOGAS.Substring(0, 1)

                                ' formato numero de pisos
                                stFPCOPISO = stFPCOPISO.PadLeft(2, "0")
                                stFPCOPISO = stFPCOPISO.Substring(0, 2)

                                ' formato porcentaje construido
                                stFPCOPOCO = stFPCOPOCO.PadLeft(3, "0")
                                stFPCOPOCO = stFPCOPOCO.Substring(0, 3)

                                ' formato edad de construcción
                                stFPCOEDCO = stFPCOEDCO.PadLeft(4, "0")
                                stFPCOEDCO = stFPCOEDCO.Substring(0, 4)

                                ' exportar los datos
                                PrintLine(1, stFPCOIDRE & stSeparador & _
                                             stFPCOVIGE & stSeparador & _
                                             stFPCOTIRE & stSeparador & _
                                             stFPCORESO & stSeparador & _
                                             stFPCONUFI & stSeparador & _
                                             stFPCONURE & stSeparador & _
                                             stFPCOUNID & stSeparador & _
                                             stFPCOPUNT & stSeparador & _
                                             stFPCOARCO & stSeparador & _
                                             stFPCOMEJO & stSeparador & _
                                             stFPCOLEY & stSeparador & _
                                             stFPCOTICO & stSeparador & _
                                             stFPCOACUE & stSeparador & _
                                             stFPCOTELE & stSeparador & _
                                             stFPCOALCA & stSeparador & _
                                             stFPCOENER & stSeparador & _
                                             stFPCOGAS & stSeparador & _
                                             stFPCOPISO & stSeparador & _
                                             stFPCOPOCO & stSeparador & _
                                             stFPCOEDCO)

                            End If

                        Next

                    Next

                    '============================
                    '*** EXPORTA CALIFICACIÓN ***
                    '============================

                    Dim f As Integer = 0

                    For f = 0 To dt.Rows.Count - 1

                        ' crea la tabla
                        tblCalificacion = New DataTable

                        ' almacena consulta
                        tblCalificacion = objCalificacion.fun_Consultar_FIPRCACO_X_FICHA_PREDIAL_TODAS_LAS_UNIDADES(dt.Rows(f).Item("FIPRNUFI"))

                        Dim d As Integer = 0

                        For d = 0 To tblCalificacion.Rows.Count - 1

                            ' verifica que se encuentre activa
                            If Trim(tblCalificacion.Rows(d).Item("FPCCESTA").ToString) = "ac" Then

                                ' variables directas
                                Dim stFPCCIDRE As String = "6"
                                Dim stFPCCVIGE As String = Trim(Me.txtFIPRVIGE_RESO.Text)
                                Dim stFPCCTIRE As String = Trim(Me.txtFIPRTIRE_RESO.Text)
                                Dim stFPCCRESO As String = Trim(Me.txtFIPRRESO_RESO.Text)
                                Dim stFPCCNUFI As String = Trim(tblCalificacion.Rows(d).Item("FPCCNUFI").ToString)
                                Dim stFPCCNURE As String = Trim(tblCalificacion.Rows(d).Item("FPCCNURE").ToString)
                                Dim stFPCCUNID As String = Trim(tblCalificacion.Rows(d).Item("FPCCUNID").ToString)
                                Dim stFPCCTIPO As String = Trim(tblCalificacion.Rows(d).Item("FPCCTIPO").ToString)
                                Dim stFPCCCODI As String = Trim(tblCalificacion.Rows(d).Item("FPCCCODI").ToString)
                                Dim stFPCCPUNT As String = Trim(tblCalificacion.Rows(d).Item("FPCCPUNT").ToString)

                                ' formato vigencia
                                stFPCCVIGE = stFPCCVIGE.PadLeft(4, "0")
                                stFPCCVIGE = stFPCCVIGE.Substring(0, 4)

                                ' formato tipo de resolución
                                stFPCCTIRE = stFPCCTIRE.PadLeft(3, "0")
                                stFPCCTIRE = stFPCCTIRE.Substring(0, 3)

                                ' formato resolución
                                stFPCCRESO = stFPCCRESO.PadLeft(7, "0")
                                stFPCCRESO = stFPCCRESO.Substring(0, 7)

                                ' formato numero de ficha
                                stFPCCNUFI = stFPCCNUFI.PadLeft(9, "0")
                                stFPCCNUFI = stFPCCNUFI.Substring(0, 9)

                                ' formato numero de registro
                                stFPCCNURE = stFPCCNURE.PadLeft(5, "0")
                                stFPCCNURE = stFPCCNURE.Substring(0, 5)

                                ' formato unidad 
                                stFPCCUNID = stFPCCUNID.PadLeft(5, "0")
                                stFPCCUNID = stFPCCUNID.Substring(0, 5)

                                ' formato tipo de calificación
                                stFPCCTIPO = stFPCCTIPO.PadRight(1, " ")
                                stFPCCTIPO = stFPCCTIPO.Substring(0, 1)

                                ' formato código de calificación
                                stFPCCCODI = stFPCCCODI.PadLeft(4, "0")
                                stFPCCCODI = stFPCCCODI.Substring(0, 4)

                                ' formato puntos
                                stFPCCPUNT = stFPCCPUNT.PadLeft(3, "0")
                                stFPCCPUNT = stFPCCPUNT.Substring(0, 3)

                                ' exportar los datos
                                PrintLine(1, stFPCCIDRE & stSeparador & _
                                             stFPCCVIGE & stSeparador & _
                                             stFPCCTIRE & stSeparador & _
                                             stFPCCRESO & stSeparador & _
                                             stFPCCNUFI & stSeparador & _
                                             stFPCCNURE & stSeparador & _
                                             stFPCCUNID & stSeparador & _
                                             stFPCCTIPO & stSeparador & _
                                             stFPCCCODI & stSeparador & _
                                             stFPCCPUNT)
                            End If

                        Next

                    Next

                    '========================
                    '*** EXPORTA LINDEROS ***
                    '========================

                    Dim w As Integer = 0

                    For w = 0 To dt.Rows.Count - 1

                        ' crea la tabla
                        tblLinderos = New DataTable

                        ' almacena consulta
                        tblLinderos = objLinderos.fun_Consultar_FIPRLIND_X_FICHA_PREDIAL(dt.Rows(w).Item("FIPRNUFI"))

                        Dim d As Integer = 0

                        For d = 0 To tblLinderos.Rows.Count - 1

                            ' verifica que se encuentre activa
                            If Trim(tblLinderos.Rows(d).Item("FPLIESTA").ToString) = "ac" Then

                                ' variables directas
                                Dim stFPLIIDRE As String = "7"
                                Dim stFPLIVIGE As String = Trim(Me.txtFIPRVIGE_RESO.Text)
                                Dim stFPLITIRE As String = Trim(Me.txtFIPRTIRE_RESO.Text)
                                Dim stFPLIRESO As String = Trim(Me.txtFIPRRESO_RESO.Text)
                                Dim stFPLINUFI As String = Trim(tblLinderos.Rows(d).Item("FPLINUFI").ToString)
                                Dim stFPLINURE As String = Trim(tblLinderos.Rows(d).Item("FPLINURE").ToString)
                                Dim stFPLIPUCA As String = Trim(tblLinderos.Rows(d).Item("FPLIPUCA").ToString)
                                Dim stFPLICOLI As String = Trim(tblLinderos.Rows(d).Item("FPLICOLI").ToString)

                                ' formato vigencia
                                stFPLIVIGE = stFPLIVIGE.PadLeft(4, "0")
                                stFPLIVIGE = stFPLIVIGE.Substring(0, 4)

                                ' formato tipo de resolución
                                stFPLITIRE = stFPLITIRE.PadLeft(3, "0")
                                stFPLITIRE = stFPLITIRE.Substring(0, 3)

                                ' formato resolución
                                stFPLIRESO = stFPLIRESO.PadLeft(7, "0")
                                stFPLIRESO = stFPLIRESO.Substring(0, 7)

                                ' formato numero de ficha
                                stFPLINUFI = stFPLINUFI.PadLeft(9, "0")
                                stFPLINUFI = stFPLINUFI.Substring(0, 9)

                                ' formato numero de registro
                                stFPLINURE = stFPLINURE.PadLeft(5, "0")
                                stFPLINURE = stFPLINURE.Substring(0, 5)

                                ' formato punto cardinal
                                stFPLIPUCA = stFPLIPUCA.PadRight(2, " ")
                                stFPLIPUCA = stFPLIPUCA.Substring(0, 2)

                                ' formato colindante
                                stFPLICOLI = stFPLICOLI.PadRight(30, " ")
                                stFPLICOLI = stFPLICOLI.Substring(0, 30)

                                ' exportar los datos
                                PrintLine(1, stFPLIIDRE & stSeparador & _
                                             stFPLIVIGE & stSeparador & _
                                             stFPLITIRE & stSeparador & _
                                             stFPLIRESO & stSeparador & _
                                             stFPLINUFI & stSeparador & _
                                             stFPLINURE & stSeparador & _
                                             stFPLIPUCA & stSeparador & _
                                             stFPLICOLI)

                            End If

                        Next

                    Next

                    '===========================
                    '*** EXPORTA CARTOGRAFIA ***
                    '===========================

                    Dim r As Integer = 0

                    For r = 0 To dt.Rows.Count - 1

                        ' crea la tabla
                        tblCartografia = New DataTable

                        ' almacena consulta
                        tblCartografia = objCartografia.fun_Consultar_FIPRCART_X_FICHA_PREDIAL(dt.Rows(r).Item("FIPRNUFI"))

                        Dim d As Integer = 0

                        For d = 0 To tblCartografia.Rows.Count - 1

                            ' verifica que se encuentre activa
                            If Trim(tblCartografia.Rows(d).Item("FPCAESTA").ToString) = "ac" Then

                                ' variables directas
                                Dim stFPCAIDRE As String = "8"
                                Dim stFPCAVIGE As String = Trim(Me.txtFIPRVIGE_RESO.Text)
                                Dim stFPCATIRE As String = Trim(Me.txtFIPRTIRE_RESO.Text)
                                Dim stFPCARESO As String = Trim(Me.txtFIPRRESO_RESO.Text)
                                Dim stFPCANUFI As String = Trim(tblCartografia.Rows(d).Item("FPCANUFI").ToString)
                                Dim stFPCANURE As String = Trim(tblCartografia.Rows(d).Item("FPCANURE").ToString)
                                Dim stFPCAPLAN As String = Trim(tblCartografia.Rows(d).Item("FPCAPLAN").ToString)
                                Dim stFPCAVENT As String = Trim(tblCartografia.Rows(d).Item("FPCAVENT").ToString)
                                Dim stFPCAESGR As String = Trim(tblCartografia.Rows(d).Item("FPCAESGR").ToString)
                                Dim stFPCAVIGR As String = Trim(tblCartografia.Rows(d).Item("FPCAVIGR").ToString)
                                Dim stFPCAVUEL As String = Trim(tblCartografia.Rows(d).Item("FPCAVUEL").ToString)
                                Dim stFPCAFAJA As String = Trim(tblCartografia.Rows(d).Item("FPCAFAJA").ToString)
                                Dim stFPCAFOTO As String = Trim(tblCartografia.Rows(d).Item("FPCAFOTO").ToString)
                                Dim stFPCAVIAE As String = Trim(tblCartografia.Rows(d).Item("FPCAVIAE").ToString)
                                Dim stFPCAAMPL As String = Trim(tblCartografia.Rows(d).Item("FPCAAMPL").ToString)
                                Dim stFPCAESAE As String = Trim(tblCartografia.Rows(d).Item("FPCAESAE").ToString)

                                ' formato vigencia
                                stFPCAVIGE = stFPCAVIGE.PadLeft(4, "0")
                                stFPCAVIGE = stFPCAVIGE.Substring(0, 4)

                                ' formato tipo de resolución
                                stFPCATIRE = stFPCATIRE.PadLeft(3, "0")
                                stFPCATIRE = stFPCATIRE.Substring(0, 3)

                                ' formato resolución
                                stFPCARESO = stFPCARESO.PadLeft(7, "0")
                                stFPCARESO = stFPCARESO.Substring(0, 7)

                                ' formato numero de ficha
                                stFPCANUFI = stFPCANUFI.PadLeft(9, "0")
                                stFPCANUFI = stFPCANUFI.Substring(0, 9)

                                ' formato numero de registro
                                stFPCANURE = stFPCANURE.PadLeft(5, "0")
                                stFPCANURE = stFPCANURE.Substring(0, 5)

                                ' formato plancha
                                stFPCAPLAN = stFPCAPLAN.PadRight(15, " ")
                                stFPCAPLAN = stFPCAPLAN.Substring(0, 15)

                                ' formato ventana
                                stFPCAVENT = stFPCAVENT.PadRight(15, " ")
                                stFPCAVENT = stFPCAVENT.Substring(0, 15)

                                ' formato escala grafica
                                stFPCAESGR = stFPCAESGR.PadRight(15, " ")
                                stFPCAESGR = stFPCAESGR.Substring(0, 15)

                                ' formato vigencia grafica
                                stFPCAVIGR = stFPCAVIGR.PadLeft(4, "0")
                                stFPCAVIGR = stFPCAVIGR.Substring(0, 4)

                                ' formato vuelo
                                stFPCAVUEL = stFPCAVUEL.PadRight(15, " ")
                                stFPCAVUEL = stFPCAVUEL.Substring(0, 15)

                                ' formato faja
                                stFPCAFAJA = stFPCAFAJA.PadRight(15, " ")
                                stFPCAFAJA = stFPCAFAJA.Substring(0, 15)

                                ' formato foto
                                stFPCAFOTO = stFPCAFOTO.PadRight(15, " ")
                                stFPCAFOTO = stFPCAFOTO.Substring(0, 15)

                                ' formato vigencia aerofotografica
                                stFPCAVIAE = stFPCAVIAE.PadLeft(4, "0")
                                stFPCAVIAE = stFPCAVIAE.Substring(0, 4)

                                ' formato ampliación
                                stFPCAAMPL = stFPCAAMPL.PadRight(15, " ")
                                stFPCAAMPL = stFPCAAMPL.Substring(0, 15)

                                ' formato escala aerofotografica
                                stFPCAESAE = stFPCAESAE.PadRight(15, " ")
                                stFPCAESAE = stFPCAESAE.Substring(0, 15)

                                ' exportar los datos
                                PrintLine(1, stFPCAIDRE & stSeparador & _
                                             stFPCAVIGE & stSeparador & _
                                             stFPCATIRE & stSeparador & _
                                             stFPCARESO & stSeparador & _
                                             stFPCANUFI & stSeparador & _
                                             stFPCANURE & stSeparador & _
                                             stFPCAPLAN & stSeparador & _
                                             stFPCAVENT & stSeparador & _
                                             stFPCAESGR & stSeparador & _
                                             stFPCAVIGR & stSeparador & _
                                             stFPCAVUEL & stSeparador & _
                                             stFPCAFAJA & stSeparador & _
                                             stFPCAFOTO & stSeparador & _
                                             stFPCAVIAE & stSeparador & _
                                             stFPCAAMPL & stSeparador & _
                                             stFPCAESAE)
                            End If

                        Next

                    Next

                    ' coloca la barra en cero
                    pbProcesoActualizacion.Value = 0

                    mod_MENSAJE.Proceso_Termino_Correctamente()

                    ' prende el boton
                    Me.cmdExportarPlanoActualizacion.Enabled = True

                    If MessageBox.Show("¿ Desea abrir el archivo plano ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        ' Abrir con Process.Start el archivo de texto
                        Process.Start(stRutaArchivoParametrizada)
                    End If

                Else
                    mod_MENSAJE.No_Se_Encontro_Ningun_registro()
                    cmdExportarPlanoActualizacion.Focus()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub
    Private Sub pro_ExportarPlanoFichaResumenParametrizada()

        Try
            ' verifica la ruta del acchivo
            If Trim(stRutaArchivoParametrizada) <> "" Then

                ' recorre el archivo a exportar
                FileOpen(1, oCrear.FileName, OpenMode.Output) 'crea y destruye si hay otro igual

                ' variable separador
                Dim stSeparador As String = Trim(Me.txtSEPARADOR.Text)

                ' apaga el boton
                Me.cmdExportarPlanoActualizacion.Enabled = False

                '==========================
                '*** GENERA LA CONSULTA ***
                '==========================

                ' declara la variables
                dt = New DataTable

                ' llena el datatable con la consulta
                dt_FR_1_Y_2 = fun_EjecutarConsultaParametrizadaFichaResumen1y2()
                dt_FR_1 = fun_EjecutarConsultaParametrizadaFichaResumen1()
                dt_FR_2 = fun_EjecutarConsultaParametrizadaFichaResumen2()

                '============================
                '*** CUENTA LOS REGISTROS ***
                '============================

                inProceso = 0
                pbProcesoActualizacion.Value = 0
                pbProcesoActualizacion.Maximum = dt_FR_1_Y_2.Rows.Count
                Timer1.Enabled = True

                ' recorre la consulta
                If dt_FR_1_Y_2.Rows.Count > 0 Then

                    '================================
                    '*** ID : 1 EXPORTA RESUMEN 1 ***
                    '================================

                    Dim i As Integer = 0

                    For i = 0 To dt_FR_1.Rows.Count - 1

                        ' crea la tabla
                        tblFichaPredial = New DataTable

                        ' almacena consulta
                        tblFichaPredial = objFichaPredial.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dt_FR_1.Rows(i).Item("FIPRNUFI"))

                        ' variables directas
                        Dim stFIPRIDRE As String = "1"
                        Dim stFIPRMUNI As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMUNI").ToString)
                        Dim stFIPRCLSE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCLSE").ToString)
                        Dim stFIPRCORR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCORR").ToString)
                        Dim stFIPRBARR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRBARR").ToString)
                        Dim stFIPRMANZ As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMANZ").ToString)
                        Dim stFIPRPRED As String = Trim(tblFichaPredial.Rows(0).Item("FIPRPRED").ToString)
                        Dim stFIPRATLO As String = Trim(tblFichaPredial.Rows(0).Item("FIPRATLO").ToString)
                        Dim stFIPRACLO As String = Trim(tblFichaPredial.Rows(0).Item("FIPRACLO").ToString)
                        Dim stFIPRAPCA As String = Trim(tblFichaPredial.Rows(0).Item("FIPRAPCA").ToString)
                        Dim stFIPRUNCO As String = Trim(tblFichaPredial.Rows(0).Item("FIPRUNCO").ToString)
                        Dim stFIPRTOED As String = Trim(tblFichaPredial.Rows(0).Item("FIPRTOED").ToString)
                        Dim stFIPRCUUT As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCUUT").ToString)
                        Dim stFIPRLOCA As String = Trim(tblFichaPredial.Rows(0).Item("FIPRLOCA").ToString)
                        Dim stFIPRGACU As String = Trim(tblFichaPredial.Rows(0).Item("FIPRGACU").ToString)
                        Dim stFIPRGADE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRGADE").ToString)
                        Dim stFIPRDIRE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRDIRE").ToString)
                        Dim stFIPRCAPR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCAPR").ToString)

                        ' formato municipio actual
                        stFIPRMUNI = stFIPRMUNI.PadLeft(3, "0")
                        stFIPRMUNI = stFIPRMUNI.Substring(0, 3)

                        ' formato clase o sector actual
                        stFIPRCLSE = stFIPRCLSE.PadLeft(1, "0")
                        stFIPRCLSE = stFIPRCLSE.Substring(0, 1)

                        ' formato corregimiento actual
                        stFIPRCORR = stFIPRCORR.PadLeft(3, "0")
                        stFIPRCORR = stFIPRCORR.Substring(0, 3)

                        ' formato barrio actual
                        stFIPRBARR = stFIPRBARR.PadLeft(3, "0")
                        stFIPRBARR = stFIPRBARR.Substring(0, 3)

                        ' formato manzana actual
                        stFIPRMANZ = stFIPRMANZ.PadLeft(3, "0")
                        stFIPRMANZ = stFIPRMANZ.Substring(0, 3)

                        ' formato predio actual
                        stFIPRPRED = stFIPRPRED.PadLeft(5, "0")
                        stFIPRPRED = stFIPRPRED.Substring(0, 5)

                        ' formato área total de lote
                        stFIPRATLO = stFIPRATLO.PadLeft(11, "0")
                        stFIPRATLO = stFIPRATLO.Substring(0, 11)

                        ' formato área comun de lote
                        stFIPRACLO = stFIPRACLO.PadLeft(11, "0")
                        stFIPRACLO = stFIPRACLO.Substring(0, 11)

                        ' formato apartamentos o casa
                        stFIPRAPCA = stFIPRAPCA.PadLeft(4, "0")
                        stFIPRAPCA = stFIPRAPCA.Substring(0, 4)

                        ' formato unidades en condominio
                        stFIPRUNCO = stFIPRUNCO.PadLeft(4, "0")
                        stFIPRUNCO = stFIPRUNCO.Substring(0, 4)

                        ' formato total edificios
                        stFIPRTOED = stFIPRTOED.PadLeft(4, "0")
                        stFIPRTOED = stFIPRTOED.Substring(0, 4)

                        ' formato cuartos utilies
                        stFIPRCUUT = stFIPRCUUT.PadLeft(4, "0")
                        stFIPRCUUT = stFIPRCUUT.Substring(0, 4)

                        ' formato locales
                        stFIPRLOCA = stFIPRLOCA.PadLeft(4, "0")
                        stFIPRLOCA = stFIPRLOCA.Substring(0, 4)

                        ' formato garajes cubiertos
                        stFIPRGACU = stFIPRGACU.PadLeft(4, "0")
                        stFIPRGACU = stFIPRGACU.Substring(0, 4)

                        ' formato garajes descubiertos
                        stFIPRGADE = stFIPRGADE.PadLeft(4, "0")
                        stFIPRGADE = stFIPRGADE.Substring(0, 4)

                        ' formato dirección
                        stFIPRDIRE = stFIPRDIRE.PadRight(49, " ")
                        stFIPRDIRE = stFIPRDIRE.Substring(0, 49)

                        ' formato caracteristica de predio
                        stFIPRCAPR = stFIPRCAPR.PadLeft(1, "0")
                        stFIPRCAPR = stFIPRCAPR.Substring(0, 1)

                        ' exportar los datos
                        PrintLine(1, stFIPRIDRE & stSeparador & _
                                     stFIPRMUNI & stSeparador & _
                                     stFIPRCLSE & stSeparador & _
                                     stFIPRCORR & stSeparador & _
                                     stFIPRBARR & stSeparador & _
                                     stFIPRMANZ & stSeparador & _
                                     stFIPRPRED & stSeparador & _
                                     stFIPRATLO & stSeparador & _
                                     stFIPRACLO & stSeparador & _
                                     stFIPRAPCA & stSeparador & _
                                     stFIPRUNCO & stSeparador & _
                                     stFIPRTOED & stSeparador & _
                                     stFIPRCUUT & stSeparador & _
                                     stFIPRLOCA & stSeparador & _
                                     stFIPRGACU & stSeparador & _
                                     stFIPRGADE & stSeparador & _
                                     stFIPRDIRE & stSeparador & _
                                     stFIPRCAPR)

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbProcesoActualizacion.Value = inProceso

                    Next

                    '================================
                    '*** ID : 2 EXPORTA RESUMEN 2 ***
                    '================================

                    Dim k As Integer = 0

                    For k = 0 To dt_FR_2.Rows.Count - 1

                        ' crea la tabla
                        tblFichaPredial = New DataTable

                        ' almacena consulta
                        tblFichaPredial = objFichaPredial.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(dt_FR_2.Rows(k).Item("FIPRNUFI"))

                        ' variables directas
                        Dim stFIPRIDRE As String = "2"
                        Dim stFIPRMUNI As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMUNI").ToString)
                        Dim stFIPRCLSE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCLSE").ToString)
                        Dim stFIPRCORR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCORR").ToString)
                        Dim stFIPRBARR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRBARR").ToString)
                        Dim stFIPRMANZ As String = Trim(tblFichaPredial.Rows(0).Item("FIPRMANZ").ToString)
                        Dim stFIPRPRED As String = Trim(tblFichaPredial.Rows(0).Item("FIPRPRED").ToString)
                        Dim stFIPREDIF As String = Trim(tblFichaPredial.Rows(0).Item("FIPREDIF").ToString)
                        Dim stFIPRATLO As String = Trim(tblFichaPredial.Rows(0).Item("FIPRATLO").ToString)
                        Dim stFIPRACLO As String = Trim(tblFichaPredial.Rows(0).Item("FIPRACLO").ToString)
                        Dim stFIPRPISO As String = Trim(tblFichaPredial.Rows(0).Item("FIPRPISO").ToString)
                        Dim stFIPRURPH As String = Trim(tblFichaPredial.Rows(0).Item("FIPRURPH").ToString)
                        Dim stFIPRAPCA As String = Trim(tblFichaPredial.Rows(0).Item("FIPRAPCA").ToString)
                        Dim stFIPRCUUT As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCUUT").ToString)
                        Dim stFIPRLOCA As String = Trim(tblFichaPredial.Rows(0).Item("FIPRLOCA").ToString)
                        Dim stFIPRGACU As String = Trim(tblFichaPredial.Rows(0).Item("FIPRGACU").ToString)
                        Dim stFIPRGADE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRGADE").ToString)
                        Dim stFIPRDIRE As String = Trim(tblFichaPredial.Rows(0).Item("FIPRDIRE").ToString)
                        Dim stFIPRCAPR As String = Trim(tblFichaPredial.Rows(0).Item("FIPRCAPR").ToString)

                        If Me.chkEdificioEnCeros.Checked = True Then
                            stFIPREDIF = "000"
                        End If

                        ' formato municipio actual
                        stFIPRMUNI = stFIPRMUNI.PadLeft(3, "0")
                        stFIPRMUNI = stFIPRMUNI.Substring(0, 3)

                        ' formato clase o sector actual
                        stFIPRCLSE = stFIPRCLSE.PadLeft(1, "0")
                        stFIPRCLSE = stFIPRCLSE.Substring(0, 1)

                        ' formato corregimiento actual
                        stFIPRCORR = stFIPRCORR.PadLeft(3, "0")
                        stFIPRCORR = stFIPRCORR.Substring(0, 3)

                        ' formato barrio actual
                        stFIPRBARR = stFIPRBARR.PadLeft(3, "0")
                        stFIPRBARR = stFIPRBARR.Substring(0, 3)

                        ' formato manzana actual
                        stFIPRMANZ = stFIPRMANZ.PadLeft(3, "0")
                        stFIPRMANZ = stFIPRMANZ.Substring(0, 3)

                        ' formato predio actual
                        stFIPRPRED = stFIPRPRED.PadLeft(5, "0")
                        stFIPRPRED = stFIPRPRED.Substring(0, 5)

                        ' formato edificio
                        stFIPREDIF = stFIPREDIF.PadLeft(5, "0")
                        stFIPREDIF = stFIPREDIF.Substring(0, 5)

                        ' formato área total de lote
                        stFIPRATLO = stFIPRATLO.PadLeft(10, "0")
                        stFIPRATLO = stFIPRATLO.Substring(0, 10)

                        ' formato área comun de lote
                        stFIPRACLO = stFIPRACLO.PadLeft(10, "0")
                        stFIPRACLO = stFIPRACLO.Substring(0, 10)

                        ' formato pisos
                        stFIPRPISO = stFIPRPISO.PadLeft(3, "0")
                        stFIPRPISO = stFIPRPISO.Substring(0, 3)

                        ' formato unidades en rph
                        stFIPRURPH = stFIPRURPH.PadLeft(4, "0")
                        stFIPRURPH = stFIPRURPH.Substring(0, 4)

                        ' formato apartamentos o casa
                        stFIPRAPCA = stFIPRAPCA.PadLeft(4, "0")
                        stFIPRAPCA = stFIPRAPCA.Substring(0, 4)

                        ' formato cuartos utilies
                        stFIPRCUUT = stFIPRCUUT.PadLeft(4, "0")
                        stFIPRCUUT = stFIPRCUUT.Substring(0, 4)

                        ' formato locales
                        stFIPRLOCA = stFIPRLOCA.PadLeft(4, "0")
                        stFIPRLOCA = stFIPRLOCA.Substring(0, 4)

                        ' formato garajes cubiertos
                        stFIPRGACU = stFIPRGACU.PadLeft(4, "0")
                        stFIPRGACU = stFIPRGACU.Substring(0, 4)

                        ' formato garajes descubiertos
                        stFIPRGADE = stFIPRGADE.PadLeft(4, "0")
                        stFIPRGADE = stFIPRGADE.Substring(0, 4)

                        ' formato dirección
                        stFIPRDIRE = stFIPRDIRE.PadRight(49, " ")
                        stFIPRDIRE = stFIPRDIRE.Substring(0, 49)

                        ' formato caracteristica de predio
                        stFIPRCAPR = stFIPRCAPR.PadLeft(1, "0")
                        stFIPRCAPR = stFIPRCAPR.Substring(0, 1)

                        ' exportar los datos
                        PrintLine(1, stFIPRIDRE & stSeparador & _
                                     stFIPRMUNI & stSeparador & _
                                     stFIPRCLSE & stSeparador & _
                                     stFIPRCORR & stSeparador & _
                                     stFIPRBARR & stSeparador & _
                                     stFIPRMANZ & stSeparador & _
                                     stFIPRPRED & stSeparador & _
                                     stFIPREDIF & stSeparador & _
                                     stFIPRATLO & stSeparador & _
                                     stFIPRACLO & stSeparador & _
                                     stFIPRPISO & stSeparador & _
                                     stFIPRURPH & stSeparador & _
                                     stFIPRAPCA & stSeparador & _
                                     stFIPRCUUT & stSeparador & _
                                     stFIPRLOCA & stSeparador & _
                                     stFIPRGACU & stSeparador & _
                                     stFIPRGADE & stSeparador & _
                                     stFIPRDIRE & stSeparador & _
                                     stFIPRCAPR)

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbProcesoActualizacion.Value = inProceso

                    Next

                    '===================================
                    '*** ID : 3 EXPORTA CONSTRUCCIÓN ***
                    '===================================

                    Dim h As Integer = 0

                    For h = 0 To dt_FR_1_Y_2.Rows.Count - 1

                        ' crea la tabla
                        tblConstruccion = New DataTable

                        ' almacena consulta
                        tblConstruccion = objConstruccion.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(dt_FR_1_Y_2.Rows(h).Item("FIPRNUFI"))

                        ' recorro la tabla
                        Dim c As Integer = 0

                        For c = 0 To tblConstruccion.Rows.Count - 1

                            ' verifica que se encuentre activa
                            If Trim(tblConstruccion.Rows(c).Item("FPCOESTA").ToString) = "ac" Then

                                ' instancia la clase
                                objCedula = New cla_FICHPRED
                                tblCedula = New DataTable

                                ' consulta la cedula catastral por numero de ficha
                                tblCedula = objCedula.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(tblConstruccion.Rows(c).Item("FPCONUFI"))

                                ' variables directas
                                Dim stFPCOIDRE As String = "3"
                                Dim stFPCOMUNI As String = Trim(tblCedula.Rows(0).Item("FIPRMUNI").ToString)
                                Dim stFPCOCLSE As String = Trim(tblCedula.Rows(0).Item("FIPRCLSE").ToString)
                                Dim stFPCOCORR As String = Trim(tblCedula.Rows(0).Item("FIPRCORR").ToString)
                                Dim stFPCOBARR As String = Trim(tblCedula.Rows(0).Item("FIPRBARR").ToString)
                                Dim stFPCOMANZ As String = Trim(tblCedula.Rows(0).Item("FIPRMANZ").ToString)
                                Dim stFPCOPRED As String = Trim(tblCedula.Rows(0).Item("FIPRPRED").ToString)
                                Dim stFPCOEDIF As String = Trim(tblCedula.Rows(0).Item("FIPREDIF").ToString)

                                Dim stFPCOUNID As String = Trim(tblConstruccion.Rows(c).Item("FPCOUNID").ToString)
                                Dim stFPCOTIPO As String = Trim(fun_BuscaTipoDeCalificación(vp_Departamento, Trim(tblConstruccion.Rows(c).Item("FPCOMUNI").ToString), tblConstruccion.Rows(c).Item("FPCOCLCO").ToString, tblConstruccion.Rows(c).Item("FPCOCLSE").ToString, Trim(tblConstruccion.Rows(c).Item("FPCOTICO").ToString)))
                                Dim stFPCOTICO As String = fun_Quita_Letras(Trim(tblConstruccion.Rows(c).Item("FPCOTICO").ToString))
                                Dim stFPCOARCO As String = Trim(tblConstruccion.Rows(c).Item("FPCOARCO").ToString)
                                Dim stFPCOPUNT As String = Trim(tblConstruccion.Rows(c).Item("FPCOPUNT").ToString)
                                Dim stFPCOACUE As String = Trim(tblConstruccion.Rows(c).Item("FPCOACUE").ToString)
                                Dim stFPCOALCA As String = Trim(tblConstruccion.Rows(c).Item("FPCOALCA").ToString)
                                Dim stFPCOENER As String = Trim(tblConstruccion.Rows(c).Item("FPCOENER").ToString)
                                Dim stFPCOTELE As String = Trim(tblConstruccion.Rows(c).Item("FPCOTELE").ToString)
                                Dim stFPCOGAS As String = Trim(tblConstruccion.Rows(c).Item("FPCOGAS").ToString)
                                Dim stFPCOPISO As String = Trim(tblConstruccion.Rows(c).Item("FPCOPISO").ToString)
                                Dim stFPCOPOCO As String = Trim(tblConstruccion.Rows(c).Item("FPCOPOCO").ToString)
                                Dim stFPCOEDCO As String = Trim(tblConstruccion.Rows(c).Item("FPCOEDCO").ToString)

                                ' formato municipio actual
                                stFPCOMUNI = stFPCOMUNI.PadLeft(3, "0")
                                stFPCOMUNI = stFPCOMUNI.Substring(0, 3)

                                ' formato clase o sector actual
                                stFPCOCLSE = stFPCOCLSE.PadLeft(1, "0")
                                stFPCOCLSE = stFPCOCLSE.Substring(0, 1)

                                ' formato corregimiento actual
                                stFPCOCORR = stFPCOCORR.PadLeft(3, "0")
                                stFPCOCORR = stFPCOCORR.Substring(0, 3)

                                ' formato barrio actual
                                stFPCOBARR = stFPCOBARR.PadLeft(3, "0")
                                stFPCOBARR = stFPCOBARR.Substring(0, 3)

                                ' formato manzana actual
                                stFPCOMANZ = stFPCOMANZ.PadLeft(3, "0")
                                stFPCOMANZ = stFPCOMANZ.Substring(0, 3)

                                ' formato predio actual
                                stFPCOPRED = stFPCOPRED.PadLeft(5, "0")
                                stFPCOPRED = stFPCOPRED.Substring(0, 5)

                                ' formato edificio
                                stFPCOEDIF = stFPCOEDIF.PadLeft(5, "0")
                                stFPCOEDIF = stFPCOEDIF.Substring(0, 5)

                                ' formato unidad 
                                stFPCOUNID = stFPCOUNID.PadLeft(5, "0")
                                stFPCOUNID = stFPCOUNID.Substring(0, 5)

                                ' formato tipo de calificación
                                stFPCOTIPO = stFPCOTIPO.PadRight(1, " ")
                                stFPCOTIPO = stFPCOTIPO.Substring(0, 1)

                                ' formato tipo de construcción
                                stFPCOTICO = stFPCOTICO.PadLeft(3, "0")
                                stFPCOTICO = stFPCOTICO.Substring(0, 3)

                                ' formato área de construcción
                                stFPCOARCO = stFPCOARCO.Replace(".", "")
                                stFPCOARCO = stFPCOARCO.PadLeft(8, "0")
                                stFPCOARCO = stFPCOARCO.Substring(0, 8)

                                ' formato puntos
                                stFPCOPUNT = stFPCOPUNT.PadLeft(3, "0")
                                stFPCOPUNT = stFPCOPUNT.Substring(0, 3)

                                ' formato acueducto
                                stFPCOACUE = stFPCOACUE.PadLeft(1, "0")
                                stFPCOACUE = stFPCOACUE.Substring(0, 1)

                                ' formato alcantarillado
                                stFPCOALCA = stFPCOALCA.PadLeft(1, "0")
                                stFPCOALCA = stFPCOALCA.Substring(0, 1)

                                ' formato energia
                                stFPCOENER = stFPCOENER.PadLeft(1, "0")
                                stFPCOENER = stFPCOENER.Substring(0, 1)

                                ' formato telefono
                                stFPCOTELE = stFPCOTELE.PadLeft(1, "0")
                                stFPCOTELE = stFPCOTELE.Substring(0, 1)

                                ' formato gas
                                stFPCOGAS = stFPCOGAS.PadLeft(1, "0")
                                stFPCOGAS = stFPCOGAS.Substring(0, 1)

                                ' formato numero de pisos
                                stFPCOPISO = stFPCOPISO.PadLeft(2, "0")
                                stFPCOPISO = stFPCOPISO.Substring(0, 2)

                                ' formato porcentaje construido
                                stFPCOPOCO = stFPCOPOCO.PadLeft(3, "0")
                                stFPCOPOCO = stFPCOPOCO & "00"
                                stFPCOPOCO = stFPCOPOCO.Substring(0, 5)

                                ' formato edad de construcción
                                stFPCOEDCO = stFPCOEDCO.PadLeft(4, "0")
                                stFPCOEDCO = stFPCOEDCO.Substring(0, 4)

                                ' exportar los datos
                                PrintLine(1, stFPCOIDRE & stSeparador & _
                                             stFPCOMUNI & stSeparador & _
                                             stFPCOCLSE & stSeparador & _
                                             stFPCOCORR & stSeparador & _
                                             stFPCOBARR & stSeparador & _
                                             stFPCOMANZ & stSeparador & _
                                             stFPCOPRED & stSeparador & _
                                             stFPCOEDIF & stSeparador & _
                                             stFPCOUNID & stSeparador & _
                                             stFPCOTIPO & stSeparador & _
                                             stFPCOTICO & stSeparador & _
                                             stFPCOARCO & stSeparador & _
                                             stFPCOPUNT & stSeparador & _
                                             stFPCOACUE & stSeparador & _
                                             stFPCOALCA & stSeparador & _
                                             stFPCOENER & stSeparador & _
                                             stFPCOTELE & stSeparador & _
                                             stFPCOGAS & stSeparador & _
                                             stFPCOPISO & stSeparador & _
                                             stFPCOPOCO & stSeparador & _
                                             stFPCOEDCO)

                                ' Incrementa la barra
                                'inProceso = inProceso + 1
                                'pbPROCESO.Value = inProceso

                            End If

                        Next

                    Next

                    '===================================
                    '*** ID : 4 EXPORTA CALIFICACIÓN ***
                    '===================================

                    Dim f As Integer = 0

                    For f = 0 To dt_FR_1_Y_2.Rows.Count - 1

                        ' crea la tabla
                        tblCalificacion = New DataTable

                        ' almacena consulta
                        tblCalificacion = objCalificacion.fun_Consultar_FIPRCACO_X_FICHA_PREDIAL_TODAS_LAS_UNIDADES(dt_FR_1_Y_2.Rows(f).Item("FIPRNUFI"))

                        ' recorro la tabla
                        Dim d As Integer = 0

                        For d = 0 To tblCalificacion.Rows.Count - 1

                            ' verifica que se encuentre activa
                            If Trim(tblCalificacion.Rows(d).Item("FPCCESTA").ToString) = "ac" Then

                                ' instancia la clase
                                objCedula = New cla_FICHPRED
                                tblCedula = New DataTable

                                tblCedula = objCedula.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(tblCalificacion.Rows(d).Item("FPCCNUFI"))

                                ' variables directas
                                Dim stFPCCIDRE As String = "4"
                                Dim stFPCCMUNI As String = Trim(tblCedula.Rows(0).Item("FIPRMUNI").ToString)
                                Dim stFPCCCLSE As String = Trim(tblCedula.Rows(0).Item("FIPRCLSE").ToString)
                                Dim stFPCCCORR As String = Trim(tblCedula.Rows(0).Item("FIPRCORR").ToString)
                                Dim stFPCCBARR As String = Trim(tblCedula.Rows(0).Item("FIPRBARR").ToString)
                                Dim stFPCCMANZ As String = Trim(tblCedula.Rows(0).Item("FIPRMANZ").ToString)
                                Dim stFPCCPRED As String = Trim(tblCedula.Rows(0).Item("FIPRPRED").ToString)
                                Dim stFPCCEDIF As String = Trim(tblCedula.Rows(0).Item("FIPREDIF").ToString)

                                Dim stFPCCUNID As String = Trim(tblCalificacion.Rows(d).Item("FPCCUNID").ToString)
                                Dim stFPCCCODI As String = Trim(tblCalificacion.Rows(d).Item("FPCCCODI").ToString)
                                Dim stFPCCTIPO As String = Trim(tblCalificacion.Rows(d).Item("FPCCTIPO").ToString)
                                Dim stFPCCPUNT As String = Trim(tblCalificacion.Rows(d).Item("FPCCPUNT").ToString)

                                ' formato municipio actual
                                stFPCCMUNI = stFPCCMUNI.PadLeft(3, "0")
                                stFPCCMUNI = stFPCCMUNI.Substring(0, 3)

                                ' formato clase o sector actual
                                stFPCCCLSE = stFPCCCLSE.PadLeft(1, "0")
                                stFPCCCLSE = stFPCCCLSE.Substring(0, 1)

                                ' formato corregimiento actual
                                stFPCCCORR = stFPCCCORR.PadLeft(3, "0")
                                stFPCCCORR = stFPCCCORR.Substring(0, 3)

                                ' formato barrio actual
                                stFPCCBARR = stFPCCBARR.PadLeft(3, "0")
                                stFPCCBARR = stFPCCBARR.Substring(0, 3)

                                ' formato manzana actual
                                stFPCCMANZ = stFPCCMANZ.PadLeft(3, "0")
                                stFPCCMANZ = stFPCCMANZ.Substring(0, 3)

                                ' formato predio actual
                                stFPCCPRED = stFPCCPRED.PadLeft(5, "0")
                                stFPCCPRED = stFPCCPRED.Substring(0, 5)

                                ' formato edificio
                                stFPCCEDIF = stFPCCEDIF.PadLeft(5, "0")
                                stFPCCEDIF = stFPCCEDIF.Substring(0, 5)

                                ' formato unidad 
                                stFPCCUNID = stFPCCUNID.PadLeft(5, "0")
                                stFPCCUNID = stFPCCUNID.Substring(0, 5)

                                ' formato código de calificación
                                stFPCCCODI = stFPCCCODI.PadLeft(3, "0")
                                stFPCCCODI = stFPCCCODI.Substring(0, 3)

                                ' formato tipo de calificación
                                stFPCCTIPO = stFPCCTIPO.PadRight(1, " ")
                                stFPCCTIPO = stFPCCTIPO.Substring(0, 1)

                                ' formato puntos
                                stFPCCPUNT = stFPCCPUNT.PadLeft(3, "0")
                                stFPCCPUNT = stFPCCPUNT.Substring(0, 3)

                                ' exportar los datos
                                PrintLine(1, stFPCCIDRE & stSeparador & _
                                             stFPCCMUNI & stSeparador & _
                                             stFPCCCLSE & stSeparador & _
                                             stFPCCCORR & stSeparador & _
                                             stFPCCBARR & stSeparador & _
                                             stFPCCMANZ & stSeparador & _
                                             stFPCCPRED & stSeparador & _
                                             stFPCCEDIF & stSeparador & _
                                             stFPCCUNID & stSeparador & _
                                             stFPCCCODI & stSeparador & _
                                             stFPCCTIPO & stSeparador & _
                                             stFPCCPUNT)

                                ' Incrementa la barra
                                'inProceso = inProceso + 1
                                'pbPROCESO.Value = inProceso

                            End If

                        Next

                    Next

                    '==================================
                    '*** ID : 5 EXPORTA CARTOGRAFIA ***
                    '==================================

                    Dim r As Integer = 0

                    For r = 0 To dt_FR_1_Y_2.Rows.Count - 1

                        ' crea la tabla
                        tblCartografia = New DataTable

                        ' almacena consulta
                        tblCartografia = objCartografia.fun_Consultar_FIPRCART_X_FICHA_PREDIAL(dt_FR_1_Y_2.Rows(r).Item("FIPRNUFI"))

                        ' recorro la tabla
                        Dim d As Integer = 0

                        For d = 0 To tblCartografia.Rows.Count - 1

                            ' verifica que se encuentre activa
                            If Trim(tblCartografia.Rows(d).Item("FPCAESTA").ToString) = "ac" Then

                                ' instancia la clase
                                objCedula = New cla_FICHPRED
                                tblCedula = New DataTable

                                tblCedula = objCedula.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(tblCartografia.Rows(d).Item("FPCANUFI"))

                                ' variables directas
                                Dim stFPCAIDRE As String = "5"
                                Dim stFPCAMUNI As String = Trim(tblCedula.Rows(0).Item("FIPRMUNI").ToString)
                                Dim stFPCACLSE As String = Trim(tblCedula.Rows(0).Item("FIPRCLSE").ToString)
                                Dim stFPCACORR As String = Trim(tblCedula.Rows(0).Item("FIPRCORR").ToString)
                                Dim stFPCABARR As String = Trim(tblCedula.Rows(0).Item("FIPRBARR").ToString)
                                Dim stFPCAMANZ As String = Trim(tblCedula.Rows(0).Item("FIPRMANZ").ToString)
                                Dim stFPCAPRED As String = Trim(tblCedula.Rows(0).Item("FIPRPRED").ToString)
                                Dim stFPCAEDIF As String = Trim(tblCedula.Rows(0).Item("FIPREDIF").ToString)
                                Dim stFPCAPLAN As String = Trim(tblCartografia.Rows(d).Item("FPCAPLAN").ToString)
                                Dim stFPCAVENT As String = Trim(tblCartografia.Rows(d).Item("FPCAVENT").ToString)
                                Dim stFPCAESGR As String = Trim(tblCartografia.Rows(d).Item("FPCAESGR").ToString)
                                Dim stFPCAVIGR As String = Trim(tblCartografia.Rows(d).Item("FPCAVIGR").ToString)
                                Dim stFPCAVUEL As String = Trim(tblCartografia.Rows(d).Item("FPCAVUEL").ToString)
                                Dim stFPCAFAJA As String = Trim(tblCartografia.Rows(d).Item("FPCAFAJA").ToString)
                                Dim stFPCAFOTO As String = Trim(tblCartografia.Rows(d).Item("FPCAFOTO").ToString)
                                Dim stFPCAVIAE As String = Trim(tblCartografia.Rows(d).Item("FPCAVIAE").ToString)
                                Dim stFPCAAMPL As String = Trim(tblCartografia.Rows(d).Item("FPCAAMPL").ToString)
                                Dim stFPCAESAE As String = Trim(tblCartografia.Rows(d).Item("FPCAESAE").ToString)

                                ' formato municipio actual
                                stFPCAMUNI = stFPCAMUNI.PadLeft(3, "0")
                                stFPCAMUNI = stFPCAMUNI.Substring(0, 3)

                                ' formato clase o sector actual
                                stFPCACLSE = stFPCACLSE.PadLeft(1, "0")
                                stFPCACLSE = stFPCACLSE.Substring(0, 1)

                                ' formato corregimiento actual
                                stFPCACORR = stFPCACORR.PadLeft(3, "0")
                                stFPCACORR = stFPCACORR.Substring(0, 3)

                                ' formato barrio actual
                                stFPCABARR = stFPCABARR.PadLeft(3, "0")
                                stFPCABARR = stFPCABARR.Substring(0, 3)

                                ' formato manzana actual
                                stFPCAMANZ = stFPCAMANZ.PadLeft(3, "0")
                                stFPCAMANZ = stFPCAMANZ.Substring(0, 3)

                                ' formato predio actual
                                stFPCAPRED = stFPCAPRED.PadLeft(5, "0")
                                stFPCAPRED = stFPCAPRED.Substring(0, 5)

                                ' formato edificio
                                stFPCAEDIF = stFPCAEDIF.PadLeft(5, "0")
                                stFPCAEDIF = stFPCAEDIF.Substring(0, 5)

                                ' formato plancha
                                stFPCAPLAN = stFPCAPLAN.PadRight(15, " ")
                                stFPCAPLAN = stFPCAPLAN.Substring(0, 15)

                                ' formato ventana
                                stFPCAVENT = stFPCAVENT.PadRight(15, " ")
                                stFPCAVENT = stFPCAVENT.Substring(0, 15)

                                ' formato escala grafica
                                stFPCAESGR = stFPCAESGR.PadRight(15, " ")
                                stFPCAESGR = stFPCAESGR.Substring(0, 15)

                                ' formato vigencia grafica
                                stFPCAVIGR = stFPCAVIGR.PadLeft(4, "0")
                                stFPCAVIGR = stFPCAVIGR.Substring(0, 4)

                                ' formato vuelo
                                stFPCAVUEL = stFPCAVUEL.PadRight(15, " ")
                                stFPCAVUEL = stFPCAVUEL.Substring(0, 15)

                                ' formato faja
                                stFPCAFAJA = stFPCAFAJA.PadRight(15, " ")
                                stFPCAFAJA = stFPCAFAJA.Substring(0, 15)

                                ' formato foto
                                stFPCAFOTO = stFPCAFOTO.PadRight(15, " ")
                                stFPCAFOTO = stFPCAFOTO.Substring(0, 15)

                                ' formato vigencia aerofotografica
                                stFPCAVIAE = stFPCAVIAE.PadLeft(4, "0")
                                stFPCAVIAE = stFPCAVIAE.Substring(0, 4)

                                ' formato ampliación
                                stFPCAAMPL = stFPCAAMPL.PadRight(15, " ")
                                stFPCAAMPL = stFPCAAMPL.Substring(0, 15)

                                ' formato escala aerofotografica
                                stFPCAESAE = stFPCAESAE.PadRight(15, " ")
                                stFPCAESAE = stFPCAESAE.Substring(0, 15)

                                ' exportar los datos
                                PrintLine(1, stFPCAIDRE & stSeparador & _
                                             stFPCAMUNI & stSeparador & _
                                             stFPCACLSE & stSeparador & _
                                             stFPCACORR & stSeparador & _
                                             stFPCABARR & stSeparador & _
                                             stFPCAMANZ & stSeparador & _
                                             stFPCAPRED & stSeparador & _
                                             stFPCAEDIF & stSeparador & _
                                             stFPCAPLAN & stSeparador & _
                                             stFPCAVENT & stSeparador & _
                                             stFPCAESGR & stSeparador & _
                                             stFPCAVIGR & stSeparador & _
                                             stFPCAVUEL & stSeparador & _
                                             stFPCAFAJA & stSeparador & _
                                             stFPCAFOTO & stSeparador & _
                                             stFPCAVIAE & stSeparador & _
                                             stFPCAAMPL & stSeparador & _
                                             stFPCAESAE)

                                ' Incrementa la barra
                                'inProceso = inProceso + 1
                                'pbPROCESO.Value = inProceso

                            End If

                        Next

                    Next

                    '===============================
                    '*** ID : 6 EXPORTA LINDEROS ***
                    '===============================

                    Dim w As Integer = 0

                    For w = 0 To dt_FR_1_Y_2.Rows.Count - 1

                        ' crea la tabla
                        tblLinderos = New DataTable

                        ' almacena consulta
                        tblLinderos = objLinderos.fun_Consultar_FIPRLIND_X_FICHA_PREDIAL(dt_FR_1_Y_2.Rows(w).Item("FIPRNUFI"))

                        ' recorro la tabla
                        Dim d As Integer = 0

                        For d = 0 To tblLinderos.Rows.Count - 1

                            ' verifica que se encuentre activa
                            If Trim(tblLinderos.Rows(d).Item("FPLIESTA").ToString) = "ac" Then

                                ' instancia la clase
                                objCedula = New cla_FICHPRED
                                tblCedula = New DataTable

                                tblCedula = objCedula.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(tblLinderos.Rows(d).Item("FPLINUFI"))

                                ' variables directas
                                Dim stFPLIIDRE As String = "6"
                                Dim stFPLIMUNI As String = Trim(tblCedula.Rows(0).Item("FIPRMUNI").ToString)
                                Dim stFPLICLSE As String = Trim(tblCedula.Rows(0).Item("FIPRCLSE").ToString)
                                Dim stFPLICORR As String = Trim(tblCedula.Rows(0).Item("FIPRCORR").ToString)
                                Dim stFPLIBARR As String = Trim(tblCedula.Rows(0).Item("FIPRBARR").ToString)
                                Dim stFPLIMANZ As String = Trim(tblCedula.Rows(0).Item("FIPRMANZ").ToString)
                                Dim stFPLIPRED As String = Trim(tblCedula.Rows(0).Item("FIPRPRED").ToString)
                                Dim stFPLIEDIF As String = Trim(tblCedula.Rows(0).Item("FIPREDIF").ToString)
                                Dim stFPLIPUCA As String = Trim(tblLinderos.Rows(d).Item("FPLIPUCA").ToString)
                                Dim stFPLICOLI As String = Trim(tblLinderos.Rows(d).Item("FPLICOLI").ToString)

                                ' formato municipio actual
                                stFPLIMUNI = stFPLIMUNI.PadLeft(3, "0")
                                stFPLIMUNI = stFPLIMUNI.Substring(0, 3)

                                ' formato clase o sector actual
                                stFPLICLSE = stFPLICLSE.PadLeft(1, "0")
                                stFPLICLSE = stFPLICLSE.Substring(0, 1)

                                ' formato corregimiento actual
                                stFPLICORR = stFPLICORR.PadLeft(3, "0")
                                stFPLICORR = stFPLICORR.Substring(0, 3)

                                ' formato barrio actual
                                stFPLIBARR = stFPLIBARR.PadLeft(3, "0")
                                stFPLIBARR = stFPLIBARR.Substring(0, 3)

                                ' formato manzana actual
                                stFPLIMANZ = stFPLIMANZ.PadLeft(3, "0")
                                stFPLIMANZ = stFPLIMANZ.Substring(0, 3)

                                ' formato predio actual
                                stFPLIPRED = stFPLIPRED.PadLeft(5, "0")
                                stFPLIPRED = stFPLIPRED.Substring(0, 5)

                                ' formato edificio
                                stFPLIEDIF = stFPLIEDIF.PadLeft(5, "0")
                                stFPLIEDIF = stFPLIEDIF.Substring(0, 5)

                                ' formato punto cardinal
                                stFPLIPUCA = stFPLIPUCA.PadRight(2, " ")
                                stFPLIPUCA = stFPLIPUCA.Substring(0, 2)

                                ' formato colindante
                                stFPLICOLI = stFPLICOLI.PadRight(30, " ")
                                stFPLICOLI = stFPLICOLI.Substring(0, 30)

                                ' exportar los datos
                                PrintLine(1, stFPLIIDRE & stSeparador & _
                                             stFPLIMUNI & stSeparador & _
                                             stFPLICLSE & stSeparador & _
                                             stFPLICORR & stSeparador & _
                                             stFPLIBARR & stSeparador & _
                                             stFPLIMANZ & stSeparador & _
                                             stFPLIPRED & stSeparador & _
                                             stFPLIEDIF & stSeparador & _
                                             stFPLIPUCA & stSeparador & _
                                             stFPLICOLI)

                                ' Incrementa la barra
                                'inProceso = inProceso + 1
                                'pbPROCESO.Value = inProceso

                            End If

                        Next

                    Next

                    ' coloca la barra en cero
                    pbProcesoActualizacion.Value = 0

                    MessageBox.Show("Archivo plano creado corectamente", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    ' prende el boton
                    Me.cmdExportarPlanoActualizacion.Enabled = True

                    If MessageBox.Show("¿ Desea abrir el archivo plano ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        ' Abrir con Process.Start el archivo de texto
                        Process.Start(stRutaArchivoParametrizada)
                    End If

                Else
                    MessageBox.Show("No existen registros en base de datos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    cmdExportarPlanoActualizacion.Focus()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            FileClose(1)
        End Try

    End Sub

    Private Sub pro_LimpiarCampos()

        ' campos resolución actualizacion
        Me.txtREACDEPA.Text = ""
        Me.txtREACMUNI.Text = ""
        Me.txtREACTIRE.Text = ""
        Me.txtREACVIGE.Text = ""
        Me.txtREACCLSE.Text = ""
        Me.txtREACRESO.Text = ""
        Me.lblREACDEPA.Text = ""
        Me.lblREACMUNI.Text = ""
        Me.lblREACTIRE.Text = ""
        Me.lblREACVIGE.Text = ""
        Me.lblREACCLSE.Text = ""
        Me.lblREACRESO.Text = ""

        ' campos resolución administrativa
        Me.txtREADCLAS.Text = ""
        Me.txtREADFERE.Text = ""
        Me.txtREADTIRE.Text = ""
        Me.txtREADVIGE.Text = ""
        Me.txtREADCLSE.Text = ""
        Me.txtREADRESO.Text = ""
        Me.lblREADCLAS.Text = ""
        Me.lblREADTIRE.Text = ""
        Me.lblREADVIGE.Text = ""
        Me.lblREADCLSE.Text = ""

        ' campos ficha predial
        Me.txtFIPRFIIN.Text = "0"
        Me.txtFIPRFIFI.Text = "999999999"
        Me.txtFIPRMUNI.Text = "%"
        Me.txtFIPRCORR.Text = "%"
        Me.txtFIPRBARR.Text = "%"
        Me.txtFIPRPRED.Text = "%"
        Me.txtFIPREDIF.Text = "%"
        Me.txtFIPRUNPR.Text = "%"
        Me.txtFIPRCLSE.Text = "%"

        ' campos resolución
        Me.txtFIPRMUNI_RESO.Text = ""
        Me.txtFIPRVIGE_RESO.Text = ""
        Me.txtFIPRTIRE_RESO.Text = ""
        Me.txtFIPRRESO_RESO.Text = ""
        Me.txtFIPRCLSE_RESO.Text = ""

        Me.lblRutaArchivoActualizacion.Text = ""

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_EjecutarConsultaFichaPredialActualizacion() As DataTable

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

            ' variable de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprDepa = '" & Trim(Me.txtREACDEPA.Text) & "' and "
            ParametrosConsulta += "FiprMuni = '" & Trim(Me.txtREACMUNI.Text) & "' and "
            ParametrosConsulta += "FiprTire = '" & Val(Trim(Me.txtREACTIRE.Text)) & "' and "
            ParametrosConsulta += "FiprClse = '" & Val(Trim(Me.txtREACCLSE.Text)) & "' and "
            ParametrosConsulta += "FiprVige = '" & Val(Trim(Me.txtREACVIGE.Text)) & "' and "
            ParametrosConsulta += "FiprReso = '" & Val(Trim(Me.txtREACRESO.Text)) & "' and "
            ParametrosConsulta += "FiprTifi = '0' and "
            ParametrosConsulta += "FiprEsta = 'ac' "
            ParametrosConsulta += "order by FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr"

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
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_EjecutarConsultaFichaResumen1y2Actualizacion() As DataTable

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

            ' variable de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprDepa = '" & Trim(txtREACDEPA.Text) & "' and "
            ParametrosConsulta += "FiprMuni = '" & Trim(txtREACMUNI.Text) & "' and "
            ParametrosConsulta += "FiprTire = '" & Val(Trim(txtREACTIRE.Text)) & "' and "
            ParametrosConsulta += "FiprClse = '" & Val(Trim(txtREACCLSE.Text)) & "' and "
            ParametrosConsulta += "FiprVige = '" & Val(Trim(txtREACVIGE.Text)) & "' and "
            ParametrosConsulta += "FiprReso = '" & Val(Trim(txtREACRESO.Text)) & "' and "
            ParametrosConsulta += "FiprTifi in ('1','2') and "
            ParametrosConsulta += "FiprEsta = 'ac' "
            ParametrosConsulta += "order by FiprTifi,FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr"

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

            Return dt

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_EjecutarConsultaFichaResumen1Actualizacion() As DataTable

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

            ' variable de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprDepa = '" & Trim(txtREACDEPA.Text) & "' and "
            ParametrosConsulta += "FiprMuni = '" & Trim(txtREACMUNI.Text) & "' and "
            ParametrosConsulta += "FiprTire = '" & Val(Trim(txtREACTIRE.Text)) & "' and "
            ParametrosConsulta += "FiprClse = '" & Val(Trim(txtREACCLSE.Text)) & "' and "
            ParametrosConsulta += "FiprVige = '" & Val(Trim(txtREACVIGE.Text)) & "' and "
            ParametrosConsulta += "FiprReso = '" & Val(Trim(txtREACRESO.Text)) & "' and "
            ParametrosConsulta += "FiprTifi = 1 and "
            ParametrosConsulta += "FiprEsta = 'ac' "
            ParametrosConsulta += "order by FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr"

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

            Return dt

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_EjecutarConsultaFichaResumen2Actualizacion() As DataTable

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

            ' variable de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprDepa = '" & Trim(txtREACDEPA.Text) & "' and "
            ParametrosConsulta += "FiprMuni = '" & Trim(txtREACMUNI.Text) & "' and "
            ParametrosConsulta += "FiprTire = '" & Val(Trim(txtREACTIRE.Text)) & "' and "
            ParametrosConsulta += "FiprClse = '" & Val(Trim(txtREACCLSE.Text)) & "' and "
            ParametrosConsulta += "FiprVige = '" & Val(Trim(txtREACVIGE.Text)) & "' and "
            ParametrosConsulta += "FiprReso = '" & Val(Trim(txtREACRESO.Text)) & "' and "
            ParametrosConsulta += "FiprTifi = 2 and "
            ParametrosConsulta += "FiprEsta = 'ac' "
            ParametrosConsulta += "order by FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr"

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

            Return dt

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function

    Private Function fun_EjecutarConsultaFichaPredialAdministrativa() As DataTable

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

            ' variable de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprReso = '" & Val(Trim(Me.txtREADRESO.Text)) & "' and "
            ParametrosConsulta += "FiprTire = '" & Val(Trim(Me.txtREADTIRE.Text)) & "' and "
            ParametrosConsulta += "FiprClse = '" & Val(Trim(Me.txtREADCLSE.Text)) & "' and "
            ParametrosConsulta += "FiprVige = '" & Val(Trim(Me.txtREADVIGE.Text)) & "' and "
            ParametrosConsulta += "FiprTifi = '0' and "
            ParametrosConsulta += "FiprEsta = 'ac' "
            ParametrosConsulta += "order by FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr"

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
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_EjecutarConsultaFichaResumen1y2Administrativa() As DataTable

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

            ' variable de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprTire = '" & Val(Trim(txtREADTIRE.Text)) & "' and "
            ParametrosConsulta += "FiprClse = '" & Val(Trim(txtREADCLSE.Text)) & "' and "
            ParametrosConsulta += "FiprVige = '" & Val(Trim(txtREADVIGE.Text)) & "' and "
            ParametrosConsulta += "FiprReso = '" & Val(Trim(txtREADRESO.Text)) & "' and "
            ParametrosConsulta += "FiprTifi in ('1','2') and "
            ParametrosConsulta += "FiprEsta = 'ac' "
            ParametrosConsulta += "order by FiprTifi,FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr"

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

            Return dt

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_EjecutarConsultaFichaResumen1Administrativa() As DataTable

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

            ' variable de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprTire = '" & Val(Trim(txtREADTIRE.Text)) & "' and "
            ParametrosConsulta += "FiprClse = '" & Val(Trim(txtREADCLSE.Text)) & "' and "
            ParametrosConsulta += "FiprVige = '" & Val(Trim(txtREADVIGE.Text)) & "' and "
            ParametrosConsulta += "FiprReso = '" & Val(Trim(txtREADRESO.Text)) & "' and "
            ParametrosConsulta += "FiprTifi = 1 and "
            ParametrosConsulta += "FiprEsta = 'ac' "
            ParametrosConsulta += "order by FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr"

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

            Return dt

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_EjecutarConsultaFichaResumen2Administrativa() As DataTable

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

            ' variable de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprTire = '" & Val(Trim(txtREADTIRE.Text)) & "' and "
            ParametrosConsulta += "FiprClse = '" & Val(Trim(txtREADCLSE.Text)) & "' and "
            ParametrosConsulta += "FiprVige = '" & Val(Trim(txtREADVIGE.Text)) & "' and "
            ParametrosConsulta += "FiprReso = '" & Val(Trim(txtREADRESO.Text)) & "' and "
            ParametrosConsulta += "FiprTifi = 2 and "
            ParametrosConsulta += "FiprEsta = 'ac' "
            ParametrosConsulta += "order by FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr"

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

            Return dt

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function

    Private Function fun_EjecutarConsultaParametrizadaFichaPredial() As DataTable

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

            ' variable de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(txtFIPRMUNI.Text) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(txtFIPRCORR.Text) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(txtFIPRBARR.Text) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(txtFIPRMANZ.Text) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(txtFIPRPRED.Text) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(txtFIPREDIF.Text) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(txtFIPRUNPR.Text) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(txtFIPRCLSE.Text) & "' and "
            ParametrosConsulta += "FiprTifi = '0' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(txtFIPRFIIN.Text) & "' and '" & Trim(txtFIPRFIFI.Text) & "' and "
            ParametrosConsulta += "FiprEsta = 'ac' "
            ParametrosConsulta += "Order by FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr "

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

            Return dt

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_EjecutarConsultaParametrizadaFichaResumen1y2() As DataTable

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

            ' variable de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(txtFIPRMUNI.Text) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(txtFIPRCORR.Text) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(txtFIPRBARR.Text) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(txtFIPRMANZ.Text) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(txtFIPRPRED.Text) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(txtFIPREDIF.Text) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(txtFIPRUNPR.Text) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(txtFIPRCLSE.Text) & "' and "
            ParametrosConsulta += "FiprTifi in ('1','2') and "
            ParametrosConsulta += "FiprNufi between '" & Trim(txtFIPRFIIN.Text) & "' and '" & Trim(txtFIPRFIFI.Text) & "' and "
            ParametrosConsulta += "FiprEsta = 'ac' "
            ParametrosConsulta += "Order by FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr "

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

            Return dt

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_EjecutarConsultaParametrizadaFichaResumen1() As DataTable

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

            ' variable de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(txtFIPRMUNI.Text) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(txtFIPRCORR.Text) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(txtFIPRBARR.Text) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(txtFIPRMANZ.Text) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(txtFIPRPRED.Text) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(txtFIPREDIF.Text) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(txtFIPRUNPR.Text) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(txtFIPRCLSE.Text) & "' and "
            ParametrosConsulta += "FiprTifi = '1' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(txtFIPRFIIN.Text) & "' and '" & Trim(txtFIPRFIFI.Text) & "' and "
            ParametrosConsulta += "FiprEsta = 'ac' "
            ParametrosConsulta += "Order by FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr "

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

            Return dt

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_EjecutarConsultaParametrizadaFichaResumen2() As DataTable

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

            ' variable de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "FiprNufi "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprMuni like '" & Trim(txtFIPRMUNI.Text) & "' and "
            ParametrosConsulta += "FiprCorr like '" & Trim(txtFIPRCORR.Text) & "' and "
            ParametrosConsulta += "FiprBarr like '" & Trim(txtFIPRBARR.Text) & "' and "
            ParametrosConsulta += "FiprManz like '" & Trim(txtFIPRMANZ.Text) & "' and "
            ParametrosConsulta += "FiprPred like '" & Trim(txtFIPRPRED.Text) & "' and "
            ParametrosConsulta += "FiprEdif like '" & Trim(txtFIPREDIF.Text) & "' and "
            ParametrosConsulta += "FiprUnpr like '" & Trim(txtFIPRUNPR.Text) & "' and "
            ParametrosConsulta += "FiprClse like '" & Trim(txtFIPRCLSE.Text) & "' and "
            ParametrosConsulta += "FiprTifi = '2' and "
            ParametrosConsulta += "FiprNufi between '" & Trim(txtFIPRFIIN.Text) & "' and '" & Trim(txtFIPRFIFI.Text) & "' and "
            ParametrosConsulta += "FiprEsta = 'ac' "
            ParametrosConsulta += "Order by FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr "

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

            Return dt

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function

    Private Function fun_SumaAreaDeTerreno() As Integer

        Try
            ' declara area de terreno
            Dim inAreaDeTerreno As Integer = 0

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtSumaTerreno = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' variable de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "Sum(FiprArte), count(1) as NroRegistro "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprDepa = '" & Trim(txtREACDEPA.Text) & "' and "
            ParametrosConsulta += "FiprMuni = '" & Trim(txtREACMUNI.Text) & "' and "
            ParametrosConsulta += "FiprTire = '" & Val(Trim(txtREACTIRE.Text)) & "' and "
            ParametrosConsulta += "FiprClse = '" & Val(Trim(txtREACCLSE.Text)) & "' and "
            ParametrosConsulta += "FiprVige = '" & Val(Trim(txtREACVIGE.Text)) & "' and "
            ParametrosConsulta += "FiprReso = '" & Val(Trim(txtREACRESO.Text)) & "' and "
            ParametrosConsulta += "FiprTifi = '0' and "
            ParametrosConsulta += "FiprEsta = 'ac' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtSumaTerreno)

            If dtSumaTerreno.Rows(0).Item(1) = 0 Then
                inAreaDeTerreno = 0
            Else
                inAreaDeTerreno = dtSumaTerreno.Rows(0).Item(0)
            End If

            ' cierra la conexion
            oConexion.Close()

            Return inAreaDeTerreno

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_SumaAreaDeConstruccion() As Decimal

        Try
            ' declara area de terreno
            Dim inAreaDeConstruccion As Integer = 0

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtSumaTerreno = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' variable de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "Sum(FiprArte) "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprDepa = '" & Trim(txtREACDEPA.Text) & "' and "
            ParametrosConsulta += "FiprMuni = '" & Trim(txtREACMUNI.Text) & "' and "
            ParametrosConsulta += "FiprTire = '" & Trim(Val(txtREACTIRE.Text)) & "' and "
            ParametrosConsulta += "FiprClse = '" & Trim(Val(txtREACCLSE.Text)) & "' and "
            ParametrosConsulta += "FiprVige = '" & Trim(Val(txtREACVIGE.Text)) & "' and "
            ParametrosConsulta += "FiprReso = '" & Trim(Val(txtREACRESO.Text)) & "' and "
            ParametrosConsulta += "FiprTifi = '0' and "
            ParametrosConsulta += "FiprEsta = 'ac' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena el datatable 
            oAdapter.Fill(dtSumaTerreno)

            ' cierra la conexion
            oConexion.Close()

            inAreaDeConstruccion = dtSumaTerreno.Rows(0).Item(0)

            Return inAreaDeConstruccion

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_SumaPuntosDeCalificacion() As Integer

        Try
            ' declara puntos de calificaion
            Dim inPuntosDeCalificacion As Integer = 0

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crea el datatable
            dtSumaPuntosCalificacion = New DataTable

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' abre la conexion
            oConexion.Open()

            ' variable de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "Sum(FpcoPunt), count(1) as NroRegistro "
            ParametrosConsulta += "From FiprCons where FpcoEsta = 'ac' and "
            ParametrosConsulta += "Exists(Select 1 from FichPred where "
            ParametrosConsulta += "FiprNufi = FpcoNufi and  "
            ParametrosConsulta += "FiprDepa = '" & Trim(txtREACDEPA.Text) & "' and "
            ParametrosConsulta += "FiprMuni = '" & Trim(txtREACMUNI.Text) & "' and "
            ParametrosConsulta += "FiprTire = '" & Val(Trim(txtREACTIRE.Text)) & "' and "
            ParametrosConsulta += "FiprClse = '" & Val(Trim(txtREACCLSE.Text)) & "' and "
            ParametrosConsulta += "FiprVige = '" & Val(Trim(txtREACVIGE.Text)) & "' and "
            ParametrosConsulta += "FiprReso = '" & Val(Trim(txtREACRESO.Text)) & "' and "
            ParametrosConsulta += "FiprTifi = '0' and "
            ParametrosConsulta += "FiprEsta = 'ac' ) "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 360
            oEjecutar.CommandType = CommandType.Text
            oAdapter.SelectCommand = oEjecutar

            ' llena la tabla
            oAdapter.Fill(dtSumaPuntosCalificacion)

            ' llena el datatable 
            If dtSumaPuntosCalificacion.Rows(0).Item(1) = 0 Then
                inPuntosDeCalificacion = 0
            Else
                inPuntosDeCalificacion = dtSumaPuntosCalificacion.Rows(0).Item(0)
            End If

            ' cierra la conexion
            oConexion.Close()

            Return inPuntosDeCalificacion

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function

    Private Function fun_BuscaTipoDeCalificación(ByVal stFPCODEPA As String, _
                                                 ByVal stFPCOMUNI As String, _
                                                 ByVal inFPCOCLCO As String, _
                                                 ByVal inFPCOCLSE As String, _
                                                 ByVal stFPCOTICO As String) As String

        Try
            Dim objdatos15 As New cla_TIPOCONS
            Dim tbl15 As New DataTable

            tbl15 = objdatos15.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(Trim(stFPCODEPA), Trim(stFPCOMUNI), Trim(inFPCOCLCO), Trim(inFPCOCLSE), Trim(stFPCOTICO))

            Dim stFPCOTIPO As String = ""

            If tbl15.Rows.Count > 0 Then
                stFPCOTIPO = Trim(tbl15.Rows(0).Item("TICOTIPO")).ToString
            Else
                stFPCOTIPO = ""
            End If

            Return stFPCOTIPO

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try
    End Function

#End Region

#Region "MENU"

    Private Sub cmdExportarPlanoActualizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarPlanoActualizacion.Click

        Try
            ' exporta planos ficha predial
            If Me.rbdFichaPredialActualizacion.Checked = True Then
                If Me.txtREACRESO.Text <> "" Then
                    pro_ExportarPlanoFichaPredialActualizacion()
                Else
                    MessageBox.Show("Seleccione una resolución", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If

            ' exporta planos ficha resumen
            If Me.rbdFichaResumenActualizacion.Checked = True Then
                If Me.txtREACRESO.Text <> "" Then
                    pro_ExportarPlanoFichaResumenActualizacion()
                Else
                    MessageBox.Show("Seleccione una resolución", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdExportarPlanoAdministrativa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarPlanoAdministrativa.Click

        Try
            ' exporta planos ficha predial
            If Me.rbdFichaPredialAdministrativa.Checked = True Then
                If Me.txtREADRESO.Text <> "" Then
                    pro_ExportarPlanoFichaPredialAdministrativa()
                Else
                    MessageBox.Show("Seleccione una resolución", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If

            ' exporta planos ficha resumen
            If Me.rbdFichaResumenAdministrativa.Checked = True Then
                If Me.txtREADRESO.Text <> "" Then
                    pro_ExportarPlanoFichaResumenAdministrativa()
                Else
                    MessageBox.Show("Seleccione una resolución", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdExportarPlanoParametrizada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarPlanoParametrizada.Click

        Try
            ' exporta planos ficha predial parametrizada
            If Me.rbdFichaPredialParametrizada.Checked = True Then
                If Me.txtFIPRMUNI_RESO.Text <> "" AndAlso _
                   Me.txtFIPRVIGE_RESO.Text <> "" AndAlso _
                   Me.txtFIPRTIRE_RESO.Text <> "" AndAlso _
                   Me.txtFIPRRESO_RESO.Text <> "" AndAlso _
                   Me.txtFIPRCLSE_RESO.Text <> "" Then

                    pro_ExportarPlanoFichaPredialParametrizada()

                Else
                    If MessageBox.Show("Existen datos de la resolución sin diligenciar. " & Chr(Keys.Enter) & Chr(Keys.Enter) & "¿ Desea continuar ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        pro_ExportarPlanoFichaPredialParametrizada()

                    End If
                End If
            End If

            ' exporta planos ficha resumen parametrizada
            If Me.rbdFichaResumenParametrizada.Checked = True Then
                If Me.txtFIPRMUNI_RESO.Text <> "" AndAlso _
                   Me.txtFIPRVIGE_RESO.Text <> "" AndAlso _
                   Me.txtFIPRTIRE_RESO.Text <> "" AndAlso _
                   Me.txtFIPRRESO_RESO.Text <> "" AndAlso _
                   Me.txtFIPRCLSE_RESO.Text <> "" Then

                    pro_ExportarPlanoFichaResumenParametrizada()

                Else
                    If MessageBox.Show("Existen datos de la resolución sin diligenciar. " & Chr(Keys.Enter) & Chr(Keys.Enter) & "¿ Desea continuar ?", "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                        pro_ExportarPlanoFichaResumenParametrizada()

                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub cmdRuraArchivoActualizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRuraArchivoActualizacion.Click

        Try
            ' instacia la caja de dialogo
            oCrear = New SaveFileDialog

            ' llama la caja de dialogo
            oCrear.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            oCrear.Filter = "Archivo de texto (*.txt)|*.txt"
            oCrear.FilterIndex = 1 'coloca por defecto el *.txt
            oCrear.FileName = ""
            oCrear.ShowDialog()

            stRutaArchivoActualizacion = oCrear.FileName
            lblRutaArchivoActualizacion.Text = oCrear.FileName

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRuraArchivoAdministrativa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRuraArchivoAdministrativa.Click

        Try
            ' instacia la caja de dialogo
            oCrear = New SaveFileDialog

            ' llama la caja de dialogo
            oCrear.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            oCrear.Filter = "Archivo de texto (*.txt)|*.txt"
            oCrear.FilterIndex = 1 'coloca por defecto el *.txt
            oCrear.FileName = ""
            oCrear.ShowDialog()

            stRutaArchivoAdministrativa = oCrear.FileName
            lblRutaArchivoAdministrativa.Text = oCrear.FileName

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdRuraArchivoParametrizada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRuraArchivoParametrizada.Click

        Try
            ' instacia la caja de dialogo
            oCrear = New SaveFileDialog

            ' llama la caja de dialogo
            oCrear.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            oCrear.Filter = "Archivo de texto (*.txt)|*.txt"
            oCrear.FilterIndex = 1 'coloca por defecto el *.txt
            oCrear.FileName = ""
            oCrear.ShowDialog()

            stRutaArchivoParametrizada = oCrear.FileName
            lblRutaArchivoParametrizada.Text = oCrear.FileName

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub cmdSeleccionResolucionActualizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSeleccionResolucionActualizacion.Click

        Try
            ' seleccina ninguna resolución
            vp_inConsulta = 0

            ' llama el formulario de consulta
            frm_consultar_RESOLUCION_EXPORTAR_FICHPRED.ShowDialog()

            ' verifica si hay alguna seleccionada
            If vp_inConsulta <> 0 Then

                Dim objdatos As New cla_RESOLUCION
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_RESOLUCION(vp_inConsulta)

                ' coloca los valores en los campos
                Me.txtREACDEPA.Text = CType(fun_Formato_Mascara_2_Reales(tbl.Rows(0).Item("RESODEPA")), String)
                Me.txtREACMUNI.Text = CType(fun_Formato_Mascara_3_Reales(tbl.Rows(0).Item("RESOMUNI")), String)
                Me.txtREACTIRE.Text = CType(fun_Formato_Mascara_3_Reales(tbl.Rows(0).Item("RESOTIRE")), String)
                Me.txtREACCLSE.Text = Trim(tbl.Rows(0).Item("RESOCLSE"))
                Me.txtREACVIGE.Text = CType(fun_Formato_Mascara_4_Reales(tbl.Rows(0).Item("RESOVIGE")), String)
                Me.txtREACRESO.Text = CType(fun_Formato_Mascara_7_Reales(tbl.Rows(0).Item("RESOCODI")), String)
                Me.lblREACRESO.Text = Trim(tbl.Rows(0).Item("RESODESC"))

                ' coloca la lista de valores
                Me.lblREACDEPA.Text = CType(fun_Buscar_Lista_Valores_DEPARTAMENTO(Trim(Me.txtREACDEPA.Text)), String)
                Me.lblREACMUNI.Text = CType(fun_Buscar_Lista_Valores_MUNICIPIO(Trim(Me.txtREACDEPA.Text), Trim(Me.txtREACMUNI.Text)), String)
                Me.lblREACTIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO(Trim(Me.txtREACTIRE.Text)), String)
                Me.lblREACCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(Me.txtREACCLSE.Text)), String)
                Me.lblREACVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Trim(Me.txtREACVIGE.Text)), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdSeleccionResolucionAdministrativa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSeleccionResolucionAdministrativa.Click

        Try
            ' seleccina ninguna resolución
            vp_inConsulta = 0

            ' llama el formulario de consulta
            frm_consultar_RESOADMI_PUBLICA.ShowDialog()

            ' verifica si hay alguna seleccionada
            If vp_inConsulta <> 0 Then

                Dim objdatos As New cla_RESOADMI
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_ID_RESOADMI(vp_inConsulta)

                ' coloca los valores en los campos
                Me.txtREADCLAS.Text = CStr(tbl.Rows(0).Item("READCLAS").ToString)
                Me.txtREADRESO.Text = CStr(tbl.Rows(0).Item("READNURE").ToString)
                Me.txtREADFERE.Text = CStr(tbl.Rows(0).Item("READFERE").ToString)
                Me.txtREADCLSE.Text = CStr(tbl.Rows(0).Item("READCLSE").ToString)
                Me.txtREADVIGE.Text = CStr(tbl.Rows(0).Item("READVIRE").ToString)
                Me.txtREADTIRE.Text = CStr(tbl.Rows(0).Item("READTIRE").ToString)
               
                ' coloca la lista de valores
                Me.lblREADCLAS.Text = CType(fun_Buscar_Lista_Valores_CLASIFICACION(Trim(Me.txtREADCLAS.Text)), String)
                Me.lblREADTIRE.Text = CType(fun_Buscar_Lista_Valores_TIPORESO(Trim(Me.txtREADTIRE.Text)), String)
                Me.lblREADCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(Me.txtREADCLSE.Text)), String)
                Me.lblREADVIGE.Text = CType(fun_Buscar_Lista_Valores_VIGENCIA(Trim(Me.txtREADVIGE.Text)), String)

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
    End Sub

    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Validated"

    Private Sub txtFIPRFIIN_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIIN.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRFIIN.Text)) = True Then
            Me.txtFIPRFIIN.Text = Val(Trim(Me.txtFIPRFIIN.Text))
        Else
            mod_MENSAJE.Inco_Valo_Nume()
            Me.txtFIPRFIIN.Focus()
        End If
    End Sub
    Private Sub txtFIPRFIFI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRFIFI.Validated
        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(Me.txtFIPRFIFI.Text)) = True Then
            Me.txtFIPRFIFI.Text = Val(Trim(Me.txtFIPRFIFI.Text))
        Else
            mod_MENSAJE.Inco_Valo_Nume()
            Me.txtFIPRFIFI.Focus()
        End If
    End Sub
    Private Sub txtFIPRMUNI_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMUNI.Validated
        txtFIPRMUNI.Text = fun_Formato_Mascara_3_String(txtFIPRMUNI.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRCORR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCORR.Validated
        txtFIPRCORR.Text = fun_Formato_Mascara_2_String(txtFIPRCORR.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRBARR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRBARR.Validated
        txtFIPRBARR.Text = fun_Formato_Mascara_3_String(txtFIPRBARR.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRMANZ_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRMANZ.Validated
        txtFIPRMANZ.Text = fun_Formato_Mascara_3_String(txtFIPRMANZ.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRPRED_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRPRED.Validated
        txtFIPRPRED.Text = fun_Formato_Mascara_5_String(txtFIPRPRED.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPREDIF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPREDIF.Validated
        txtFIPREDIF.Text = fun_Formato_Mascara_3_String(txtFIPREDIF.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub
    Private Sub txtFIPRUNPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR.Validated
        txtFIPRUNPR.Text = fun_Formato_Mascara_5_String(txtFIPRUNPR.Text)
        strBARRESTA.Items(1).Text = ""
    End Sub

#End Region

#Region "TextChanged"

    Private Sub lblRutaArchivo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblRutaArchivoActualizacion.TextChanged, lblRutaArchivoAdministrativa.TextChanged, lblRutaArchivoParametrizada.TextChanged

        If lblRutaArchivoActualizacion.Text.Length > 0 Then
            cmdExportarPlanoActualizacion.Enabled = True
        Else
            cmdExportarPlanoActualizacion.Enabled = False
        End If

        If lblRutaArchivoAdministrativa.Text.Length > 0 Then
            cmdExportarPlanoAdministrativa.Enabled = True
        Else
            cmdExportarPlanoAdministrativa.Enabled = False
        End If

        If lblRutaArchivoParametrizada.Text.Length > 0 Then
            cmdExportarPlanoParametrizada.Enabled = True
        Else
            cmdExportarPlanoParametrizada.Enabled = False
        End If
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
            txtFIPRMUNI.Focus()
        End If
    End Sub
    Private Sub txtFIPRMUNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMUNI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCORR.Focus()
        End If
    End Sub
    Private Sub txtFIPRCORR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCORR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRBARR.Focus()
        End If
    End Sub
    Private Sub txtFIPRBARR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRBARR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRMANZ.Focus()
        End If
    End Sub
    Private Sub txtFIPRMANZ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRMANZ.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRPRED.Focus()
        End If
    End Sub
    Private Sub txtFIPRPRED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRPRED.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPREDIF.Focus()
        End If
    End Sub
    Private Sub txtFIPREDIF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPREDIF.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRUNPR.Focus()
        End If
    End Sub
    Private Sub txtFIPRUNPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRUNPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCLSE.Focus()
        End If
    End Sub
    Private Sub txtFIPRCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdRuraArchivoActualizacion.Focus()
        End If
    End Sub

#End Region

#Region "GotFocus"

    Private Sub rbdFichaPredial_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbdFichaPredialActualizacion.GotFocus
        strBARRESTA.Items(0).Text = rbdFichaPredialActualizacion.AccessibleDescription
    End Sub
    Private Sub rbdFichaResumen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbdFichaResumenActualizacion.GotFocus
        strBARRESTA.Items(0).Text = rbdFichaResumenActualizacion.AccessibleDescription
    End Sub
    Private Sub rbdParametrizadaFichaPredial_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbdFichaPredialParametrizada.GotFocus
        strBARRESTA.Items(0).Text = rbdFichaPredialParametrizada.AccessibleDescription
    End Sub
    Private Sub rbdParametrizadaFichaResumen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbdFichaResumenParametrizada.GotFocus
        strBARRESTA.Items(0).Text = rbdFichaResumenParametrizada.AccessibleDescription
    End Sub
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
    Private Sub cmdSeleccionResolucion_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSeleccionResolucionActualizacion.GotFocus
        strBARRESTA.Items(0).Text = cmdSeleccionResolucionActualizacion.AccessibleDescription
    End Sub
    Private Sub cmdRuraArchivo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRuraArchivoActualizacion.GotFocus
        strBARRESTA.Items(0).Text = cmdRuraArchivoActualizacion.AccessibleDescription
    End Sub
    Private Sub cmdExportarPlano_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarPlanoActualizacion.GotFocus
        strBARRESTA.Items(0).Text = cmdExportarPlanoActualizacion.AccessibleDescription
    End Sub
    Private Sub cmdLimpiar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLimpiar.GotFocus
        strBARRESTA.Items(0).Text = cmdLimpiar.AccessibleDescription
    End Sub
    Private Sub cmdSalir_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSalir.GotFocus
        strBARRESTA.Items(0).Text = cmdSalir.AccessibleDescription
    End Sub

#End Region

#Region "CheckedChanged"

    Private Sub rbdFichaPredial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdFichaPredialActualizacion.CheckedChanged, rbdFichaResumenActualizacion.CheckedChanged, rbdFichaPredialParametrizada.CheckedChanged, rbdFichaResumenParametrizada.CheckedChanged

        If rbdFichaResumenActualizacion.Checked = True Or rbdFichaResumenParametrizada.Checked = True Or rbdFichaResumenAdministrativa.Checked = True Then
            Me.chkEdificioEnCeros.Visible = True
            Me.chkGenerarCodigoAsignado.Visible = False

        ElseIf rbdFichaResumenActualizacion.Checked = False Or rbdFichaResumenParametrizada.Checked = False Or rbdFichaResumenAdministrativa.Checked = False Then
            Me.chkEdificioEnCeros.Visible = False
            Me.chkGenerarCodigoAsignado.Visible = True
        End If

    End Sub

#End Region

#End Region

End Class