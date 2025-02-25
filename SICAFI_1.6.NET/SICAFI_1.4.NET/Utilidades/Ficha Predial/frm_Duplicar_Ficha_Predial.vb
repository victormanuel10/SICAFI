Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_Duplicar_Ficha_Predial

    '=================================
    '*** DUPLICAR FICHAS PREDIALES ***
    '=================================

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_Duplicar_Ficha_Predial
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_Duplicar_Ficha_Predial
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

    ' otros procesos
    Dim inProceso As Integer = 0

    ' declara los campos de la resolución
    Dim vl_inFIPRNFFU As Integer = 0
    Dim vl_inFIPRNFIN As Integer = 0
    Dim vl_inFIPRNUFI As Integer = 0
    Dim vl_stFIPRDEPA As String = ""
    Dim vl_stFIPRMUNI As String = ""
    Dim vl_inFIPRCLSE As Integer = 0
    Dim vl_inFIPRVIGE As Integer = 0
    Dim vl_inFIPRTIRE As Integer = 0
    Dim vl_inFIPRRESO As Integer = 0
    Dim vl_inFIPRNURE As Integer = 0

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtFIPRNFFU.Text = ""
        Me.txtFIPRNFIN.Text = ""
        Me.txtFIPRMUNI_FUENTE.Text = ""
        Me.txtFIPRMUNI_INICIAL.Text = ""
        Me.txtFIPRMUNI_FINAL.Text = ""
        Me.txtFIPRCORR_FUENTE.Text = ""
        Me.txtFIPRCORR_INICIAL.Text = ""
        Me.txtFIPRCORR_FINAL.Text = ""
        Me.txtFIPRBARR_FUENTE.Text = ""
        Me.txtFIPRBARR_INICIAL.Text = ""
        Me.txtFIPRBARR_FINAL.Text = ""
        Me.txtFIPRMANZ_FUENTE.Text = ""
        Me.txtFIPRMANZ_INICIAL.Text = ""
        Me.txtFIPRMANZ_FINAL.Text = ""
        Me.txtFIPRPRED_FUENTE.Text = ""
        Me.txtFIPRPRED_INICIAL.Text = ""
        Me.txtFIPRPRED_FINAL.Text = ""
        Me.txtFIPREDIF_FUENTE.Text = ""
        Me.txtFIPREDIF_INICIAL.Text = ""
        Me.txtFIPREDIF_FINAL.Text = ""
        Me.txtFIPRUNPR_FUENTE.Text = ""
        Me.txtFIPRUNPR_INICIAL.Text = ""
        Me.txtFIPRUNPR_FINAL.Text = ""

        Me.cmdEjecutarCopia.Enabled = False

    End Sub
    Private Sub pro_ConsultarFichaFuente()

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            ' valida el dato
            Dim boFIPRNFFU As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtFIPRNFFU)
            Dim boFIPRNFIN As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtFIPRNFIN)

            ' verifica el dato
            If boFIPRNFFU = True And boFIPRNFIN = True Then

                ' instancia la clase
                Dim obFICHPRED As New cla_FICHPRED
                Dim dtFICHPRED As New DataTable

                dtFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(Me.txtFIPRNFFU.Text)

                ' verifica que exista registros
                If dtFICHPRED.Rows.Count > 0 Then

                    ' verifica que el registro sea ficha predial
                    If CInt(dtFICHPRED.Rows(0).Item("FIPRTIFI")) = 0 Then

                        ' almacena la resolucion
                        vl_inFIPRNFIN = CInt(Me.txtFIPRNFIN.Text)
                        vl_inFIPRNFFU = CInt(dtFICHPRED.Rows(0).Item("FIPRNUFI"))
                        vl_stFIPRDEPA = CStr(Trim(dtFICHPRED.Rows(0).Item("FIPRDEPA").ToString))
                        vl_stFIPRMUNI = CStr(Trim(dtFICHPRED.Rows(0).Item("FIPRMUNI").ToString))
                        vl_inFIPRCLSE = CInt(dtFICHPRED.Rows(0).Item("FIPRCLSE"))
                        vl_inFIPRVIGE = CInt(dtFICHPRED.Rows(0).Item("FIPRVIGE"))
                        vl_inFIPRTIRE = CInt(dtFICHPRED.Rows(0).Item("FIPRTIRE"))
                        vl_inFIPRRESO = CInt(dtFICHPRED.Rows(0).Item("FIPRRESO"))

                        ' llena la cedulas catastrales
                        Me.txtFIPRMUNI_FUENTE.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRMUNI").ToString)
                        Me.txtFIPRMUNI_INICIAL.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRMUNI").ToString)
                        Me.txtFIPRMUNI_FINAL.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRMUNI").ToString)
                        Me.txtFIPRCORR_FUENTE.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRCORR").ToString)
                        Me.txtFIPRCORR_INICIAL.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRCORR").ToString)
                        Me.txtFIPRCORR_FINAL.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRCORR").ToString)
                        Me.txtFIPRBARR_FUENTE.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRBARR").ToString)
                        Me.txtFIPRBARR_INICIAL.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRBARR").ToString)
                        Me.txtFIPRBARR_FINAL.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRBARR").ToString)
                        Me.txtFIPRMANZ_FUENTE.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRMANZ").ToString)
                        Me.txtFIPRMANZ_INICIAL.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRMANZ").ToString)
                        Me.txtFIPRMANZ_FINAL.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRMANZ").ToString)
                        Me.txtFIPRPRED_FUENTE.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRPRED").ToString)
                        Me.txtFIPRPRED_INICIAL.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRPRED").ToString)
                        Me.txtFIPRPRED_FINAL.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRPRED").ToString)
                        Me.txtFIPREDIF_FUENTE.Text = Trim(dtFICHPRED.Rows(0).Item("FIPREDIF").ToString)
                        Me.txtFIPREDIF_INICIAL.Text = Trim(dtFICHPRED.Rows(0).Item("FIPREDIF").ToString)
                        Me.txtFIPREDIF_FINAL.Text = Trim(dtFICHPRED.Rows(0).Item("FIPREDIF").ToString)
                        Me.txtFIPRUNPR_FUENTE.Text = Trim(dtFICHPRED.Rows(0).Item("FIPRUNPR").ToString)
                        Me.txtFIPRUNPR_INICIAL.Text = ""
                        Me.txtFIPRUNPR_FINAL.Text = ""

                        ' prende el boton
                        Me.cmdEjecutarCopia.Enabled = True

                    Else
                        mod_MENSAJE.El_Resultado_De_La_consulta_No_Corresponde_a_una_Ficha_Predial()
                    End If

                Else
                    mod_MENSAJE.Consulta_No_Encontro_Registros()
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_EjecutarCopia()

        Try
            ' instancia la clase
            Dim objVerifica As New cla_Verificar_Dato

            ' valida el dato
            Dim boFIPRUNPR_INICIAL As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtFIPRUNPR_INICIAL)
            Dim boFIPRUNPR_FINAL As Boolean = objVerifica.fun_Verificar_Dato_Vacio_Y_Numerico(Me.txtFIPRUNPR_FINAL)

            ' verifica el dato
            If boFIPRUNPR_FINAL = True And boFIPRUNPR_FINAL = True Then

                ' declara la clase
                Dim obFICHPRED As New cla_FICHPRED
                Dim dtFICHPRED As New DataTable

                dtFICHPRED = obFICHPRED.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(vl_inFIPRNFFU)

                ' verifica que exista el registro
                If dtFICHPRED.Rows.Count > 0 Then

                    ' almacena la destinacion
                    Dim obFIPRDEEC As New cla_FIPRDEEC
                    Dim dtFIPRDEEC As New DataTable

                    dtFIPRDEEC = obFIPRDEEC.fun_Consultar_FIPRDEEC_X_FICHA_PREDIAL(vl_inFIPRNFFU)

                    ' almacena los propietarios
                    Dim obFIPRPROP As New cla_FIPRPROP
                    Dim dtFIPRPROP As New DataTable

                    dtFIPRPROP = obFIPRPROP.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(vl_inFIPRNFFU)

                    ' almacena la construccion
                    Dim obFIPRCONS As New cla_FIPRCONS
                    Dim dtFIPRCONS As New DataTable

                    dtFIPRCONS = obFIPRCONS.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(vl_inFIPRNFFU)

                    ' almacena los linderos
                    Dim obFIPRLIND As New cla_FIPRLIND
                    Dim dtFIPRLIND As New DataTable

                    dtFIPRLIND = obFIPRLIND.fun_Consultar_FIPRLIND_X_FICHA_PREDIAL(vl_inFIPRNFFU)

                    ' almacena la cartografia
                    Dim obFIPRCART As New cla_FIPRCART
                    Dim dtFIPRCART As New DataTable

                    dtFIPRCART = obFIPRCART.fun_Consultar_FIPRCART_X_FICHA_PREDIAL(vl_inFIPRNFFU)

                    ' almacena la zona fisica
                    Dim obFIPRZOFI As New cla_FIPRZOFI
                    Dim dtFIPRZOFI As New DataTable

                    dtFIPRZOFI = obFIPRZOFI.fun_Consultar_FIPRZOFI_X_FICHA_PREDIAL(vl_inFIPRNFFU)

                    ' almacena la zona economica
                    Dim obFIPRZOEC As New cla_FIPRZOEC
                    Dim dtFIPRZOEC As New DataTable

                    dtFIPRZOEC = obFIPRZOEC.fun_Consultar_FIPRZOEC_X_FICHA_PREDIAL(vl_inFIPRNFFU)

                    ' almacela el estrato
                    Dim obESTRFIPR As New cla_ESTRFIPR
                    Dim dtESTRFIPR As New DataTable

                    dtESTRFIPR = obESTRFIPR.fun_Buscar_ESTRATO_X_NRO_DE_FICHA(vl_inFIPRNFFU)

                    ' almacena la categoria
                    Dim obCAPRFIPR As New cla_CAPRFIPR
                    Dim dtCAPRFIPR As New DataTable

                    dtCAPRFIPR = obCAPRFIPR.fun_Buscar_CATEGORIA_X_NRO_DE_FICHA(vl_inFIPRNFFU)

                    ' declara la variable
                    Dim inNumeroCiclos As Integer = ((CInt(Me.txtFIPRUNPR_FINAL.Text) - CInt(Me.txtFIPRUNPR_INICIAL.Text))) + 1
                    Dim inFIPRUNPR As Integer = CInt(Me.txtFIPRUNPR_INICIAL.Text)
                    vl_inFIPRNUFI = vl_inFIPRNFIN

                    ' Valores predeterminados ProgressBar
                    inProceso = 0
                    Me.pbProceso.Value = 0
                    Me.pbProceso.Maximum = inNumeroCiclos + 1
                    Me.Timer1.Enabled = True

                    ' declara la variable
                    Dim i As Integer = 0

                    For i = 0 To inNumeroCiclos - 1

                        ' declara la variable y la esmascara
                        Dim stFIPRUNPR As String = fun_Formato_Mascara_5_String(inFIPRUNPR)

                        ' establece el numero de registro
                        vl_inFIPRNURE = fun_AsignarNumeroDeRegistro(vl_stFIPRDEPA, vl_stFIPRMUNI, vl_inFIPRTIRE, vl_inFIPRVIGE, vl_inFIPRCLSE, vl_inFIPRRESO)

                        ' declara la variable
                        Dim objdatos11 As New cla_FICHPRED
                        Dim dtFICHPRED11 As DataTable

                        dtFICHPRED11 = objdatos11.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(vl_inFIPRNUFI)

                        ' verifica que exista la ficha
                        If dtFICHPRED11.Rows.Count = 0 Then

                            ' inserta la ficha predial
                            objdatos11.fun_Insertar_FICHPRED(vl_inFIPRNUFI, _
                                                             vl_inFIPRVIGE, _
                                                             vl_inFIPRTIRE, _
                                                             vl_inFIPRRESO, _
                                                             dtFICHPRED.Rows(0).Item("FIPRDIRE"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRDESC"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRCONJ"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRFECH"), _
                                                             vl_inFIPRNURE, _
                                                             vl_stFIPRDEPA, _
                                                             dtFICHPRED.Rows(0).Item("FIPRMUNI"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRCORR"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRBARR"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRMANZ"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRPRED"), _
                                                             dtFICHPRED.Rows(0).Item("FIPREDIF"), _
                                                             stFIPRUNPR, _
                                                             dtFICHPRED.Rows(0).Item("FIPRCLSE"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRCASU"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRMUAN"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRCOAN"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRBAAN"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRMAAN"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRPRAN"), _
                                                             dtFICHPRED.Rows(0).Item("FIPREDAN"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRUPAN"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRCSAN"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRCASA"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRCAPR"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRMOAD"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRESTA"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRLITI"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRPOLI"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRCORE"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRARTE"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRCOPR"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRCOED"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRTIFI"), _
                                                             dtFICHPRED.Rows(0).Item("FIPRINCO"))

                            ' verifica que existan registros
                            If dtFIPRDEEC.Rows.Count > 0 Then

                                ' declara la variable
                                Dim i1 As Integer = 0

                                For i1 = 0 To dtFIPRDEEC.Rows.Count - 1

                                    ' optiene la secuencia
                                    Dim inFPDESECU As Integer = fun_BuscarNroSecuenciaDestinacionEconomica(vl_inFIPRNUFI)

                                    ' declara la variable
                                    Dim objdatos As New cla_FIPRDEEC

                                    ' inserta la destinacion
                                    objdatos.fun_Insertar_FIPRDEEC(vl_inFIPRNUFI, _
                                                                   dtFIPRDEEC.Rows(i1).Item("FPDEDEEC"), _
                                                                   dtFIPRDEEC.Rows(i1).Item("FPDEPORC"), _
                                                                   vl_stFIPRDEPA, _
                                                                   vl_stFIPRMUNI, _
                                                                   vl_inFIPRTIRE, _
                                                                   vl_inFIPRCLSE, _
                                                                   vl_inFIPRVIGE, _
                                                                   vl_inFIPRRESO, _
                                                                   inFPDESECU, _
                                                                   vl_inFIPRNURE, _
                                                                   dtFIPRDEEC.Rows(i1).Item("FPDEESTA"))
                                Next

                            End If

                            ' verifica que existan registros
                            If dtFIPRPROP.Rows.Count > 0 Then

                                ' declara la variable
                                Dim i2 As Integer = 0

                                For i2 = 0 To dtFIPRPROP.Rows.Count - 1

                                    ' optiene la secuencia
                                    Dim inFPPRSECU As Integer = fun_BuscarNroSecuenciaPropietario(vl_inFIPRNUFI)

                                    ' declara la variable
                                    Dim objDatos As New cla_FIPRPROP

                                    objDatos.fun_Insertar_FIPRPROP(vl_inFIPRNUFI, _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRCAPR"), _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRSEXO"), _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRTIDO"), _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRNUDO"), _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRPRAP"), _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRSEAP"), _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRNOMB"), _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRDERE"), _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRSICO"), _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRESCR"), _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRDENO"), _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRMUNO"), _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRNOTA"), _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRFEES"), _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRFERE"), _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRTOMO"), _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRMAIN"), _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRGRAV"), _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRMOAD"), _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRLITI"), _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRPOLI"), _
                                                                   vl_stFIPRDEPA, _
                                                                   vl_stFIPRMUNI, _
                                                                   vl_inFIPRTIRE, _
                                                                   vl_inFIPRCLSE, _
                                                                   vl_inFIPRVIGE, _
                                                                   vl_inFIPRRESO, _
                                                                   inFPPRSECU, _
                                                                   vl_inFIPRNURE, _
                                                                   dtFIPRPROP.Rows(i2).Item("FPPRESTA"))

                                Next

                            End If

                            ' verifica que existan registros
                            If dtFIPRCONS.Rows.Count > 0 Then

                                ' declara la variable
                                Dim i3 As Integer = 0

                                For i3 = 0 To dtFIPRCONS.Rows.Count - 1

                                    ' optiene la secuencia
                                    Dim inFPCOSECU As Integer = fun_BuscarNroSecuenciaConstruccion(vl_inFIPRNUFI)

                                    ' declara la variable
                                    Dim objdatos As New cla_FIPRCONS

                                    ' inserta la construccion
                                    If objdatos.fun_Insertar_FIPRCONS(vl_inFIPRNUFI, _
                                                                      dtFIPRCONS.Rows(i3).Item("FPCOUNID"), _
                                                                      dtFIPRCONS.Rows(i3).Item("FPCOCLCO"), _
                                                                      dtFIPRCONS.Rows(i3).Item("FPCOTICO"), _
                                                                      dtFIPRCONS.Rows(i3).Item("FPCOPUNT"), _
                                                                      dtFIPRCONS.Rows(i3).Item("FPCOARCO"), _
                                                                      dtFIPRCONS.Rows(i3).Item("FPCOACUE"), _
                                                                      dtFIPRCONS.Rows(i3).Item("FPCOALCA"), _
                                                                      dtFIPRCONS.Rows(i3).Item("FPCOENER"), _
                                                                      dtFIPRCONS.Rows(i3).Item("FPCOTELE"), _
                                                                      dtFIPRCONS.Rows(i3).Item("FPCOGAS"), _
                                                                      dtFIPRCONS.Rows(i3).Item("FPCOPISO"), _
                                                                      dtFIPRCONS.Rows(i3).Item("FPCOEDCO"), _
                                                                      dtFIPRCONS.Rows(i3).Item("FPCOPOCO"), _
                                                                      dtFIPRCONS.Rows(i3).Item("FPCOMEJO"), _
                                                                      dtFIPRCONS.Rows(i3).Item("FPCOLEY"), _
                                                                      dtFIPRCONS.Rows(i3).Item("FPCOAVCO"), _
                                                                      vl_stFIPRDEPA, _
                                                                      vl_stFIPRMUNI, _
                                                                      vl_inFIPRTIRE, _
                                                                      vl_inFIPRCLSE, _
                                                                      vl_inFIPRVIGE, _
                                                                      vl_inFIPRRESO, _
                                                                      inFPCOSECU, _
                                                                      vl_inFIPRNURE, _
                                                                      dtFIPRCONS.Rows(i3).Item("FPCOESTA")) = True Then


                                        ' almacena la calificacion
                                        Dim obFIPRCACO As New cla_FIPRCACO
                                        Dim dtFIPRCACO As New DataTable

                                        dtFIPRCACO = obFIPRCACO.fun_Consultar_FIPRCACO_X_FICHA_PREDIAL(vl_inFIPRNFFU, dtFIPRCONS.Rows(i3).Item("FPCOUNID"))

                                        ' verifica que exista registros
                                        If dtFIPRCACO.Rows.Count > 0 Then

                                            ' declara la variable
                                            Dim i4 As Integer = 0

                                            For i4 = 0 To dtFIPRCACO.Rows.Count - 1

                                                ' declara la variable
                                                Dim objdatos2 As New cla_FIPRCACO

                                                ' inserta la calificacion
                                                objdatos2.fun_Insertar_FIPRCACO(vl_inFIPRNUFI, _
                                                                                dtFIPRCACO.Rows(i4).Item("FPCCCODI"), _
                                                                                dtFIPRCACO.Rows(i4).Item("FPCCTIPO"), _
                                                                                dtFIPRCACO.Rows(i4).Item("FPCCPUNT"), _
                                                                                dtFIPRCACO.Rows(i4).Item("FPCCUNID"), _
                                                                                dtFIPRCACO.Rows(i4).Item("FPCCCLCO"), _
                                                                                dtFIPRCACO.Rows(i4).Item("FPCCTICO"), _
                                                                                vl_stFIPRDEPA, _
                                                                                vl_stFIPRMUNI, _
                                                                                vl_inFIPRTIRE, _
                                                                                vl_inFIPRCLSE, _
                                                                                vl_inFIPRVIGE, _
                                                                                vl_inFIPRRESO, _
                                                                                inFPCOSECU, _
                                                                                vl_inFIPRNURE, _
                                                                                dtFIPRCACO.Rows(i4).Item("FPCCESTA"))

                                            Next

                                        End If

                                    End If

                                Next

                            End If

                            ' verifica que existan registros
                            If dtFIPRLIND.Rows.Count > 0 Then

                                ' declara la variable
                                Dim i5 As Integer = 0

                                For i5 = 0 To dtFIPRLIND.Rows.Count - 1

                                    ' optiene la secuencia
                                    Dim inFPLISECU As Integer = fun_BuscarNroSecuenciaLindero(vl_inFIPRNUFI)

                                    ' declara la variable
                                    Dim objdatos As New cla_FIPRLIND

                                    ' inserta los linderos
                                    objdatos.fun_Insertar_FIPRLIND(vl_inFIPRNUFI, _
                                                                   dtFIPRLIND.Rows(i5).Item("FPLIPUCA"), _
                                                                   dtFIPRLIND.Rows(i5).Item("FPLICOLI"), _
                                                                   vl_stFIPRDEPA, _
                                                                   vl_stFIPRMUNI, _
                                                                   vl_inFIPRTIRE, _
                                                                   vl_inFIPRCLSE, _
                                                                   vl_inFIPRVIGE, _
                                                                   vl_inFIPRRESO, _
                                                                   inFPLISECU, _
                                                                   vl_inFIPRNURE, _
                                                                   dtFIPRLIND.Rows(i5).Item("FPLIESTA"))

                                Next

                            End If

                            ' verifica que existan registros
                            If dtFIPRCART.Rows.Count > 0 Then

                                ' declara la variable
                                Dim i6 As Integer = 0

                                For i6 = 0 To dtFIPRCART.Rows.Count - 1

                                    ' optiene la secuencia
                                    Dim inFPCASECU As Integer = fun_BuscarNroSecuenciaCartografia(vl_inFIPRNUFI)

                                    ' declara la variable
                                    Dim objdatos As New cla_FIPRCART

                                    ' inserta la cartografia
                                    objdatos.fun_Insertar_FIPRCART(vl_inFIPRNUFI, _
                                                                   dtFIPRCART.Rows(i6).Item("FPCAPLAN"), _
                                                                   dtFIPRCART.Rows(i6).Item("FPCAVENT"), _
                                                                   dtFIPRCART.Rows(i6).Item("FPCAESGR"), _
                                                                   dtFIPRCART.Rows(i6).Item("FPCAVIGR"), _
                                                                   dtFIPRCART.Rows(i6).Item("FPCAVUEL"), _
                                                                   dtFIPRCART.Rows(i6).Item("FPCAFAJA"), _
                                                                   dtFIPRCART.Rows(i6).Item("FPCAFOTO"), _
                                                                   dtFIPRCART.Rows(i6).Item("FPCAVIAE"), _
                                                                   dtFIPRCART.Rows(i6).Item("FPCAAMPL"), _
                                                                   dtFIPRCART.Rows(i6).Item("FPCAESAE"), _
                                                                   vl_stFIPRDEPA, _
                                                                   vl_stFIPRMUNI, _
                                                                   vl_inFIPRTIRE, _
                                                                   vl_inFIPRCLSE, _
                                                                   vl_inFIPRVIGE, _
                                                                   vl_inFIPRRESO, _
                                                                   inFPCASECU, _
                                                                   vl_inFIPRNURE, _
                                                                   dtFIPRCART.Rows(i6).Item("FPCAESTA"))

                                Next

                            End If

                            ' verifica que existan registros
                            If dtFIPRZOFI.Rows.Count > 0 Then

                                ' declara la variable
                                Dim i7 As Integer = 0

                                For i7 = 0 To dtFIPRZOFI.Rows.Count - 1

                                    ' optiene la secuencia
                                    Dim inFPZFSECU As Integer = fun_BuscarNroSecuenciaZonaFisica(vl_inFIPRNUFI)

                                    ' declara la variable
                                    Dim objdatos As New cla_FIPRZOFI

                                    ' inserta la zona fisica
                                    objdatos.fun_Insertar_FIPRZOFI(vl_inFIPRNUFI, _
                                                                   dtFIPRZOFI.Rows(i7).Item("FPZFZOFI"), _
                                                                   dtFIPRZOFI.Rows(i7).Item("FPZFPORC"), _
                                                                   vl_stFIPRDEPA, _
                                                                   vl_stFIPRMUNI, _
                                                                   vl_inFIPRTIRE, _
                                                                   vl_inFIPRCLSE, _
                                                                   vl_inFIPRVIGE, _
                                                                   vl_inFIPRRESO, _
                                                                   inFPZFSECU, _
                                                                   vl_inFIPRNURE, _
                                                                   dtFIPRZOFI.Rows(i7).Item("FPZFESTA"))


                                Next

                            End If

                            ' verifica que existan registros
                            If dtFIPRZOEC.Rows.Count > 0 Then

                                ' declara la variable
                                Dim i8 As Integer = 0

                                For i8 = 0 To dtFIPRZOEC.Rows.Count - 1

                                    ' optiene la secuencia
                                    Dim inFPZESECU As Integer = fun_BuscarNroSecuenciaZonaEconomica(vl_inFIPRNUFI)

                                    ' declara la variable
                                    Dim objdatos As New cla_FIPRZOEC

                                    ' inserta la zona economica
                                    objdatos.fun_Insertar_FIPRZOEC(vl_inFIPRNUFI, _
                                                                   dtFIPRZOEC.Rows(i8).Item("FPZEZOEC"), _
                                                                   dtFIPRZOEC.Rows(i8).Item("FPZEPORC"), _
                                                                   vl_stFIPRDEPA, _
                                                                   vl_stFIPRMUNI, _
                                                                   vl_inFIPRTIRE, _
                                                                   vl_inFIPRCLSE, _
                                                                   vl_inFIPRVIGE, _
                                                                   vl_inFIPRRESO, _
                                                                   inFPZESECU, _
                                                                   vl_inFIPRNURE, _
                                                                   dtFIPRZOEC.Rows(i8).Item("FPZEESTA"))


                                Next

                            End If

                            ' verifica que existan registros
                            If dtESTRFIPR.Rows.Count > 0 Then

                                ' declara la clase
                                Dim obESTRFIPR1 As New cla_ESTRFIPR

                                obESTRFIPR1.fun_Insertar_ESTRFIPR(vl_inFIPRNUFI, _
                                                                  dtESTRFIPR.Rows(0).Item("ESFPESTR"), _
                                                                  dtESTRFIPR.Rows(0).Item("ESFPESTA"))

                            End If

                            ' verifica que existan registros
                            If dtCAPRFIPR.Rows.Count > 0 Then

                                ' declara la clase
                                Dim obCAPRFIPR1 As New cla_CAPRFIPR

                                obCAPRFIPR1.fun_Insertar_CAPRFIPR(vl_inFIPRNUFI, _
                                                                  dtCAPRFIPR.Rows(0).Item("CPFPCAPR"), _
                                                                  dtCAPRFIPR.Rows(0).Item("CPFPESTA"))

                            End If

                            ' incrementa el numero de ficha
                            vl_inFIPRNUFI += 1

                            ' incrementa la unidad predial
                            inFIPRUNPR += 1

                        Else
                            MessageBox.Show("Ficha predial: " & vl_inFIPRNUFI & " existe en la base de datos", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)

                            If MessageBox.Show("Desea continuar", "Mensaje...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                                Exit For
                            End If

                        End If

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbProceso.Value = inProceso

                    Next

                    ' inicia la barra de progreso
                    pbProceso.Value = 0

                End If

                ' apaga el boton
                Me.cmdEjecutarCopia.Enabled = False

                mod_MENSAJE.Proceso_Termino_Correctamente()

            Else
                Me.txtFIPRUNPR_FINAL.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "FUNCIONES"

    Private Function fun_AsignarNumeroDeRegistro(ByVal fun_stFIPRDEPA, ByVal fun_stFIPRMUNI, ByVal fun_inFIPRTIRE, ByVal fun_inFIPRVIGE, ByVal fun_inFIPRCLSE, ByVal fun_inFIPRRESO) As Integer

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

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select "
            ParametrosConsulta += "max(FiprNure) as FiprNure "
            ParametrosConsulta += "From FichPred where "
            ParametrosConsulta += "FiprDepa = '" & fun_stFIPRDEPA & "' and "
            ParametrosConsulta += "FiprMuni = '" & fun_stFIPRMUNI & "' and "
            ParametrosConsulta += "FiprTire = '" & fun_inFIPRTIRE & "' and "
            ParametrosConsulta += "FiprVige = '" & fun_inFIPRVIGE & "' and "
            ParametrosConsulta += "FiprClse = '" & fun_inFIPRCLSE & "' and "
            ParametrosConsulta += "FiprReso = '" & fun_inFIPRRESO & "' "

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

            ' declara la variable 
            Dim inNUMEFIPR As Integer = 0

            If dt.Rows.Count > 0 Then

                inNUMEFIPR = CInt(dt.Rows(0).Item("FIPRNURE")) + 1

            End If

            Return inNUMEFIPR

        Catch ex As Exception
            MessageBox.Show(Err.Description & ". Error en numero de registro de ficha predial")
        End Try

    End Function
    Private Function fun_BuscarNroSecuenciaDestinacionEconomica(ByVal inFPDENUFI As Integer) As Integer
        Dim inFPDESECU As Integer = 0

        Dim objdatos5 As New cla_FIPRDEEC
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRDEEC_X_FICHA_PREDIAL(Val(inFPDENUFI))

        If tbl10.Rows.Count = 0 Then
            inFPDESECU = 1
        Else
            Dim i As Integer
            Dim NroMayor As Integer
            Dim Posicion As Integer

            Posicion = Val(tbl10.Rows(0).Item("FPDESECU"))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item("FPDESECU"))

                If NroMayor > Posicion Then
                    inFPDESECU = NroMayor
                    Posicion = NroMayor
                Else
                    inFPDESECU = Posicion
                End If
            Next
            inFPDESECU = inFPDESECU + 1
        End If

        Return inFPDESECU

    End Function
    Private Function fun_BuscarNroSecuenciaPropietario(ByVal inFPPRNUFI As Integer) As Integer
        Dim inSECUENCIA As Integer = 0

        ' busca el numero de secuencia de la base datos
        Dim objdatos5 As New cla_FIPRPROP
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRPROP_X_FICHA_PREDIAL(Val(inFPPRNUFI))

        If tbl10.Rows.Count = 0 Then
            inSECUENCIA = 1
        Else
            ' asigna el numero de secuencia
            Dim i As Integer
            Dim NroMayor As Integer = 0
            Dim Posicion As Integer = 0

            Posicion = Val(tbl10.Rows(0).Item("FPPRSECU"))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item("FPPRSECU"))

                If NroMayor > Posicion Then
                    inSECUENCIA = NroMayor
                    Posicion = NroMayor
                Else
                    inSECUENCIA = Posicion
                End If
            Next

            inSECUENCIA = inSECUENCIA + 1
        End If

        Return inSECUENCIA

    End Function
    Private Function fun_BuscarNroSecuenciaConstruccion(ByVal inFPCONUFI As Integer) As Integer
        Dim inSECUENCIA As Integer = 0

        Dim objdatos5 As New cla_FIPRCONS
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRCONS_X_FICHA_PREDIAL(Val(inFPCONUFI))

        If tbl10.Rows.Count = 0 Then
            inSECUENCIA = 1
        Else
            Dim i As Integer
            Dim NroMayor As Integer
            Dim Posicion As Integer

            Posicion = Val(tbl10.Rows(0).Item("FPCOSECU"))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item("FPCOSECU"))

                If NroMayor > Posicion Then
                    inSECUENCIA = NroMayor
                    Posicion = NroMayor
                Else
                    inSECUENCIA = Posicion
                End If
            Next
            inSECUENCIA = inSECUENCIA + 1
        End If

        Return inSECUENCIA

    End Function
    Private Function fun_BuscarNroSecuenciaLindero(ByVal inFPLINUFI As Integer) As Integer
        Dim inSECUENCIA As Integer = 0

        Dim objdatos5 As New cla_FIPRLIND
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRLIND_X_FICHA_PREDIAL(Val(inFPLINUFI))

        If tbl10.Rows.Count = 0 Then
            inSECUENCIA = 1
        Else
            Dim i As Integer
            Dim NroMayor As Integer
            Dim Posicion As Integer

            Posicion = Val(tbl10.Rows(0).Item("FPLISECU"))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item("FPLISECU"))

                If NroMayor > Posicion Then
                    inSECUENCIA = NroMayor
                    Posicion = NroMayor
                Else
                    inSECUENCIA = Posicion
                End If
            Next
            inSECUENCIA = inSECUENCIA + 1
        End If

        Return inSECUENCIA

    End Function
    Private Function fun_BuscarNroSecuenciaCartografia(ByVal inFPCANUFI As Integer) As Integer
        Dim inSECUENCIA As Integer = 0

        Dim objdatos5 As New cla_FIPRCART
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRCART_X_FICHA_PREDIAL(Val(inFPCANUFI))

        If tbl10.Rows.Count = 0 Then
            inSECUENCIA = 1
        Else
            Dim i As Integer
            Dim NroMayor As Integer
            Dim Posicion As Integer

            Posicion = Val(tbl10.Rows(0).Item("FPCASECU"))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item("FPCASECU"))

                If NroMayor > Posicion Then
                    inSECUENCIA = NroMayor
                    Posicion = NroMayor
                Else
                    inSECUENCIA = Posicion
                End If
            Next
            inSECUENCIA = inSECUENCIA + 1
        End If

        Return inSECUENCIA

    End Function
    Private Function fun_BuscarNroSecuenciaZonaFisica(ByVal inFPZFNUFI As Integer) As Integer
        Dim inSECUENCIA As Integer = 0

        Dim objdatos5 As New cla_FIPRZOFI
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRZOFI_X_FICHA_PREDIAL(Val(inFPZFNUFI))

        If tbl10.Rows.Count = 0 Then
            inSECUENCIA = 1
        Else
            Dim i As Integer
            Dim NroMayor As Integer
            Dim Posicion As Integer

            Posicion = Val(tbl10.Rows(0).Item("FPZFSECU"))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item("FPZFSECU"))

                If NroMayor > Posicion Then
                    inSECUENCIA = NroMayor
                    Posicion = NroMayor
                Else
                    inSECUENCIA = Posicion
                End If
            Next
            inSECUENCIA = inSECUENCIA + 1
        End If

        Return inSECUENCIA

    End Function
    Private Function fun_BuscarNroSecuenciaZonaEconomica(ByVal inFPZENUFI As Integer) As Integer
        Dim inSECUENCIA As Integer = 0

        Dim objdatos5 As New cla_FIPRZOEC
        Dim tbl10 As New DataTable

        tbl10 = objdatos5.fun_Buscar_NRO_SECUENCIA_FIPRZOEC_X_FICHA_PREDIAL(Val(inFPZENUFI))

        If tbl10.Rows.Count = 0 Then
            inSECUENCIA = 1
        Else
            Dim i As Integer
            Dim NroMayor As Integer
            Dim Posicion As Integer

            Posicion = Val(tbl10.Rows(0).Item("FPZESECU"))

            For i = 0 To tbl10.Rows.Count - 1
                NroMayor = Val(tbl10.Rows(i).Item("FPZESECU"))

                If NroMayor > Posicion Then
                    inSECUENCIA = NroMayor
                    Posicion = NroMayor
                Else
                    inSECUENCIA = Posicion
                End If
            Next
            inSECUENCIA = inSECUENCIA + 1
        End If

        Return inSECUENCIA

    End Function

#End Region

#Region "MENU"

    Private Sub cmdConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsultar.Click
        pro_ConsultarFichaFuente()
    End Sub
    Private Sub cmdEjecutarCopia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEjecutarCopia.Click
        pro_EjecutarCopia()
    End Sub
    Private Sub cmdLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLimpiar.Click
        pro_LimpiarCampos()
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_Duplicar_Ficha_Predial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.strBARRESTA.Items(0).Text = "Duplicar Fichas"
        pro_LimpiarCampos()
        Me.txtFIPRNFFU.Focus()
    End Sub

#End Region

#Region "Validated"

    Private Sub txtFIPRUNPR_INICIAL_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR_INICIAL.Validated
        If Me.txtFIPRUNPR_INICIAL.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRUNPR_INICIAL.Text) = True Then
            Me.txtFIPRUNPR_INICIAL.Text = fun_Formato_Mascara_5_String(Me.txtFIPRUNPR_INICIAL.Text)
        End If
    End Sub
    Private Sub txtFIPRUNPR_FINAL_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRUNPR_FINAL.Validated
        If Me.txtFIPRUNPR_FINAL.Text <> "" And fun_Verificar_Dato_Numerico_Evento_Validated(Me.txtFIPRUNPR_FINAL.Text) = True Then
            Me.txtFIPRUNPR_FINAL.Text = fun_Formato_Mascara_5_String(Me.txtFIPRUNPR_FINAL.Text)
        End If
    End Sub

#End Region

  
#End Region

End Class