Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frm_consulta_geografica_FICHPRED

    '===========================
    '*** CONSULTA GEOGRAFICA ***
    '===========================

#Region "CONSTRUCTORES"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private ds As New DataSet
    Private dt As New DataTable

    Dim tblCONSULTA As New DataTable

#End Region

#Region "INSTANCIAR FORMULARIO"

    Private Shared frm_Instance = Nothing

    Public Shared Function instance() As frm_consulta_geografica_FICHPRED
        If frm_Instance Is Nothing OrElse frm_Instance.isdisposed = True Then
            frm_Instance = New frm_consulta_geografica_FICHPRED
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

    ' variables verificar datos
    Dim stFIPRNUFI As String
    Dim stFIPRDIRE As String
    Dim stFIPRMUNI As String
    Dim stFIPRCORR As String
    Dim stFIPRBARR As String
    Dim stFIPRMANZ As String
    Dim stFIPRPRED As String
    Dim stFIPREDIF As String
    Dim stFIPRUNPR As String
    Dim stFIPRCLSE As String
    Dim stFIPRESTA As String
    Dim stFIPRCASU As String
    Dim stFIPRCAPR As String
    Dim stFIPRMOAD As String
    Dim Separador As String

    ' variables guardar consulta
    Dim Guardar_stFIPRNUFI As String
    Dim Guardar_stFIPRDIRE As String
    Dim Guardar_stFIPRMUNI As String
    Dim Guardar_stFIPRCORR As String
    Dim Guardar_stFIPRBARR As String
    Dim Guardar_stFIPRMANZ As String
    Dim Guardar_stFIPRPRED As String
    Dim Guardar_stFIPREDIF As String
    Dim Guardar_stFIPRUNPR As String
    Dim Guardar_stFIPRCLSE As String
    Dim Guardar_stFIPRESTA As String
    Dim Guardar_stFIPRCASU As String
    Dim Guardar_stFIPRCAPR As String
    Dim Guardar_stFIPRMOAD As String

    Dim dt_CONSULTA As New DataTable

    Dim inProceso As Integer = 0

    ' declara la variable
    Dim vl_inFicha As Integer = 0
    Dim vl_inTipoFicha As Integer = 0
    Dim vl_stMunicipio As String = ""
    Dim vl_stSector As String = ""
    Dim vl_stCorregi As String = ""
    Dim vl_stBarrio As String = ""
    Dim vl_stManzana As String = ""
    Dim vl_stPredio As String = ""
    Dim vl_stEdificio As String = ""
    Dim vl_stUnidad As String = ""
    Dim vl_inNro_Cons As Integer = 0
    Dim vl_stCarac_Pred As String = ""
    Dim vl_stDescripcion_CP As String = ""
    Dim vl_stDestino As String = ""
    Dim vl_stDescripcion_DE As String = ""
    Dim vl_stUso As String = ""
    Dim vl_boMejora As Boolean = False
    Dim vl_stIdentificador As String = ""
    Dim vl_stArea As String = ""

    Dim dr_CONSULTA As DataRow

#End Region

#Region "FUNCIONES"

    Private Function fun_Buscarvl_stDestinoEconomico(ByVal inFIPRNUFI As Integer) As Integer

        Try
            Dim invl_stDestino As Integer = 0

            Dim objDatos As New cla_FIPRDEEC
            Dim tblDatos As New DataTable

            tblDatos = objDatos.fun_Consultar_FIPRDEEC_X_FICHA_PREDIAL(inFIPRNUFI)

            If tblDatos.Rows.Count > 0 Then

                invl_stDestino = tblDatos.Rows(0).Item("FPDEDEEC")

            End If

            Return invl_stDestino

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_BuscarTotalEdificio(ByVal stFIPRMUNI As String, _
                                             ByVal inFIPRCLSE As Integer, _
                                             ByVal stFIPRCORR As String, _
                                             ByVal stFIPRBARR As String, _
                                             ByVal stFIPRMANZ As String, _
                                             ByVal stFIPRPRED As String, _
                                             ByVal inFIPRTIFI As Integer, _
                                             ByVal inFIPRCAPR As Integer) As Integer

        Try
            Dim inTotalEdificio As Integer = 0

            If inFIPRCAPR = 1 Or inFIPRCAPR = 6 Or inFIPRCAPR = 7 Then
                inTotalEdificio = 0

            ElseIf inFIPRCAPR = 2 Or inFIPRCAPR = 3 Or inFIPRCAPR = 5 Then
                inTotalEdificio = 1

            ElseIf inFIPRCAPR = 4 Then

                Dim objDatos As New cla_FICHPRED
                Dim tblDatos As New DataTable

                tblDatos = objDatos.fun_Consultar_FICHA_PREDIAL_x_CEDULA(stFIPRMUNI, inFIPRCLSE, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, inFIPRTIFI)

                If tblDatos.Rows.Count > 0 Then

                    inTotalEdificio = CInt(tblDatos.Rows(0).Item("FIPRTOED"))

                End If

            End If

            Return inTotalEdificio

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_BuscarTotalUnidadesPrediales(ByVal stFIPRMUNI As String, _
                                                      ByVal inFIPRCLSE As Integer, _
                                                      ByVal stFIPRCORR As String, _
                                                      ByVal stFIPRBARR As String, _
                                                      ByVal stFIPRMANZ As String, _
                                                      ByVal stFIPRPRED As String, _
                                                      ByVal inFIPRTIFI As Integer, _
                                                      ByVal inFIPRCAPR As Integer) As Integer

        Try
            Dim inTotalEdificio As Integer = 0

            If inFIPRCAPR = 1 Or inFIPRCAPR = 6 Or inFIPRCAPR = 7 Then
                inTotalEdificio = 0

            ElseIf inFIPRCAPR = 2 Or inFIPRCAPR = 3 Or inFIPRCAPR = 5 Then

                Dim objDatos As New cla_FICHPRED
                Dim tblDatos As New DataTable

                tblDatos = objDatos.fun_Consultar_FICHA_PREDIAL_x_CEDULA(stFIPRMUNI, inFIPRCLSE, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, inFIPRTIFI)

                If tblDatos.Rows.Count > 0 Then

                    inTotalEdificio = CInt(tblDatos.Rows(0).Item("FIPRURPH"))

                End If

            ElseIf inFIPRCAPR = 4 And inFIPRTIFI = 1 Then

                Dim objDatos As New cla_FICHPRED
                Dim tblDatos As New DataTable

                tblDatos = objDatos.fun_Consultar_FICHA_PREDIAL_x_CEDULA(stFIPRMUNI, inFIPRCLSE, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, inFIPRTIFI)

                If tblDatos.Rows.Count > 0 Then

                    inTotalEdificio = CInt(tblDatos.Rows(0).Item("FIPRUNCO"))

                End If

            ElseIf inFIPRCAPR = 4 And inFIPRTIFI = 2 Then

                Dim objDatos As New cla_FICHPRED
                Dim tblDatos As New DataTable

                tblDatos = objDatos.fun_Consultar_FICHA_PREDIAL_x_CEDULA(stFIPRMUNI, inFIPRCLSE, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, inFIPRTIFI)

                If tblDatos.Rows.Count > 0 Then

                    inTotalEdificio = CInt(tblDatos.Rows(0).Item("FIPRURPH"))

                End If

            End If

            Return inTotalEdificio

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_BuscarNroDeFichaPredial(ByVal stFIPRMUNI As String, _
                                                 ByVal inFIPRCLSE As Integer, _
                                                 ByVal stFIPRCORR As String, _
                                                 ByVal stFIPRBARR As String, _
                                                 ByVal stFIPRMANZ As String, _
                                                 ByVal stFIPRPRED As String, _
                                                 ByVal inFIPRTIFI As Integer, _
                                                 ByVal inFIPRCAPR As Integer) As Integer

        Try
            Dim inNroFicha As Integer = 0

            If inFIPRCAPR = 1 Or inFIPRCAPR = 6 Or inFIPRCAPR = 7 Then

                Dim objDatos As New cla_FICHPRED
                Dim tblDatos As New DataTable

                tblDatos = objDatos.fun_Consultar_FICHA_PREDIAL_x_CEDULA(stFIPRMUNI, inFIPRCLSE, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, inFIPRTIFI)

                If tblDatos.Rows.Count > 0 Then

                    inNroFicha = CInt(tblDatos.Rows(0).Item("FIPRNUFI"))

                End If

            End If

            Return inNroFicha

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_BuscarNroDeFichaPredial(ByVal stFIPRMUNI As String, _
                                                ByVal inFIPRCLSE As Integer, _
                                                ByVal stFIPRCORR As String, _
                                                ByVal stFIPRBARR As String, _
                                                ByVal stFIPRMANZ As String, _
                                                ByVal stFIPRPRED As String, _
                                                ByVal stFIPREDIF As String, _
                                                ByVal stFIPRUNPR As String, _
                                                ByVal inFIPRTIFI As Integer, _
                                                ByVal inFIPRCAPR As Integer) As Integer

        Try
            Dim inNroFicha As Integer = 0

            Dim objDatos As New cla_FICHPRED
            Dim tblDatos As New DataTable

            tblDatos = objDatos.fun_Consultar_FICHA_PREDIAL_x_CEDULA(stFIPRMUNI, inFIPRCLSE, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, stFIPREDIF, stFIPRUNPR, inFIPRTIFI)

            If tblDatos.Rows.Count > 0 Then

                inNroFicha = CInt(tblDatos.Rows(0).Item("FIPRNUFI"))

            End If

            Return inNroFicha

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_BuscarCantidadNroDeFichaPredial(ByVal stFIPRMUNI As String, _
                                                         ByVal inFIPRCLSE As Integer, _
                                                         ByVal stFIPRCORR As String, _
                                                         ByVal stFIPRBARR As String, _
                                                         ByVal stFIPRMANZ As String, _
                                                         ByVal stFIPRPRED As String, _
                                                         ByVal stFIPREDIF As String, _
                                                         ByVal stFIPRUNPR As String, _
                                                         ByVal inFIPRTIFI As Integer, _
                                                         ByVal inFIPRCAPR As Integer) As DataTable

        Try
            Dim inNroFicha As Integer = 0

            Dim objDatos As New cla_FICHPRED
            Dim tblDatos As New DataTable

            tblDatos = objDatos.fun_Consultar_FICHA_PREDIAL_x_CEDULA(stFIPRMUNI, inFIPRCLSE, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, stFIPREDIF, stFIPRUNPR, inFIPRTIFI)

            Return tblDatos

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_BuscarTipoDeFichaPredial(ByVal stFIPRMUNI As String, _
                                                 ByVal inFIPRCLSE As Integer, _
                                                 ByVal stFIPRCORR As String, _
                                                 ByVal stFIPRBARR As String, _
                                                 ByVal stFIPRMANZ As String, _
                                                 ByVal stFIPRPRED As String, _
                                                 ByVal inFIPRCAPR As Integer) As Integer

        Try
            Dim vl_inTipoFicha As Integer = 0

            If inFIPRCAPR = 1 Or inFIPRCAPR = 6 Or inFIPRCAPR = 7 Then
                vl_inTipoFicha = 0

            ElseIf inFIPRCAPR = 2 Or inFIPRCAPR = 3 Or inFIPRCAPR = 5 Then
                vl_inTipoFicha = 2

            ElseIf inFIPRCAPR = 4 Then
                vl_inTipoFicha = 1

            End If

            Return vl_inTipoFicha

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_BuscarUsoDeConstruccion(ByVal inFIPRNUFI As Integer, _
                                                 ByVal inFPCOUNID As Integer) As String

        Try
            Dim vl_stUso As String = ""

            Dim objDatos1 As New cla_FIPRCONS
            Dim tblDatos1 As New DataTable

            tblDatos1 = objDatos1.fun_Buscar_CODIGO_FIPRCONS(inFIPRNUFI, inFPCOUNID)


            Dim objDatos2 As New cla_FICHPRED
            Dim tblDatos2 As New DataTable

            tblDatos2 = objDatos2.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(inFIPRNUFI)


            Dim objDatos3 As New cla_TIPOCONS
            Dim tblDatos3 As New DataTable

            tblDatos3 = objDatos3.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(tblDatos2.Rows(0).Item("FIPRDEPA"), _
                                                                                                                           tblDatos2.Rows(0).Item("FIPRMUNI"), _
                                                                                                                           tblDatos1.Rows(0).Item("FPCOCLCO"), _
                                                                                                                           tblDatos2.Rows(0).Item("FIPRCLSE"), _
                                                                                                                           tblDatos1.Rows(0).Item("FPCOTICO"))

            If tblDatos3.Rows.Count > 0 Then
                vl_stUso = tblDatos3.Rows(0).Item("TICOTIPO")

                Dim objDatos4 As New cla_TIPOCALI
                Dim tblDatos4 As New DataTable

                tblDatos4 = objDatos4.fun_Buscar_CODIGO_MANT_TIPOCALI(Trim(vl_stUso))

                If tblDatos4.Rows.Count > 0 Then
                    vl_stUso = Trim(tblDatos4.Rows(0).Item("TICADESC"))
                Else
                    vl_stUso = ""
                End If

            Else
                vl_stUso = ""
            End If

            Return vl_stUso

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_BuscarMejora(ByVal inFIPRNUFI As Integer, _
                                      ByVal inFPCOUNID As Integer) As Boolean

        Try
            Dim vl_boMejora As Boolean = False

            Dim objDatos1 As New cla_FIPRCONS
            Dim tblDatos1 As New DataTable

            tblDatos1 = objDatos1.fun_Buscar_CODIGO_FIPRCONS(inFIPRNUFI, inFPCOUNID)

            If tblDatos1.Rows.Count > 0 Then

                If CBool(tblDatos1.Rows(0).Item("FPCOMEJO")) = True Then

                    vl_boMejora = True

                End If

            End If

            Return vl_boMejora

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_BuscarIdentificadorDeConstruccion(ByVal inFIPRNUFI As Integer, _
                                                           ByVal inFPCOUNID As Integer) As String

        Try
            Dim vl_stIdentificador As String = ""

            Dim objDatos1 As New cla_FIPRCONS
            Dim tblDatos1 As New DataTable

            tblDatos1 = objDatos1.fun_Buscar_CODIGO_FIPRCONS(inFIPRNUFI, inFPCOUNID)

            If tblDatos1.Rows.Count > 0 Then
                vl_stIdentificador = tblDatos1.Rows(0).Item("FPCOTICO")
            Else
                vl_stIdentificador = ""
            End If

            Return vl_stIdentificador

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_LimpiarCampos()

        Me.txtFIPRNUFI.Text = ""
        Me.txtFIPRDIRE.Text = ""
        Me.txtFIPRMUNI.Text = ""
        Me.txtFIPRCORR.Text = ""
        Me.txtFIPRBARR.Text = ""
        Me.txtFIPRMANZ.Text = ""
        Me.txtFIPRPRED.Text = ""
        Me.txtFIPREDIF.Text = ""
        Me.txtFIPRUNPR.Text = ""
        Me.txtFIPRCLSE.Text = ""
        Me.txtFIPRESTA.Text = ""
        Me.txtFIPRCAPR.Text = ""

        Me.cmdCONSULTAR.Enabled = True

        Me.strBARRESTA.Items(2).Text = "Registros : 0"

        Me.dgvCONSULTA.DataSource = New DataTable

    End Sub
    Private Sub pro_VerificarDatos()

        '*** VERIFICA DATOS DE FICHA PREDIAL ***

        If Trim(Me.txtFIPRNUFI.Text) = "" Then
            stFIPRNUFI = "%"
        Else
            stFIPRNUFI = Trim(Me.txtFIPRNUFI.Text)
        End If

        If Trim(Me.txtFIPRDIRE.Text) = "" Then
            stFIPRDIRE = "%"
        Else
            stFIPRDIRE = Trim(Me.txtFIPRDIRE.Text)
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

        If Trim(Me.txtFIPRCAPR.Text) = "" Then
            stFIPRCAPR = "%"
        Else
            stFIPRCAPR = Trim(Me.txtFIPRCAPR.Text)
        End If

    End Sub
    Private Sub pro_GuardarConsulta()

        Guardar_stFIPRNUFI = Trim(Me.txtFIPRNUFI.Text)
        Guardar_stFIPRDIRE = Trim(Me.txtFIPRDIRE.Text)
        Guardar_stFIPRMUNI = Trim(Me.txtFIPRMUNI.Text)
        Guardar_stFIPRCORR = Trim(Me.txtFIPRCORR.Text)
        Guardar_stFIPRBARR = Trim(Me.txtFIPRBARR.Text)
        Guardar_stFIPRMANZ = Trim(Me.txtFIPRMANZ.Text)
        Guardar_stFIPRPRED = Trim(Me.txtFIPRPRED.Text)
        Guardar_stFIPREDIF = Trim(Me.txtFIPREDIF.Text)
        Guardar_stFIPRUNPR = Trim(Me.txtFIPRUNPR.Text)
        Guardar_stFIPRCLSE = Trim(Me.txtFIPRCLSE.Text)
        Guardar_stFIPRESTA = Trim(Me.txtFIPRESTA.Text)
        Guardar_stFIPRCAPR = Trim(Me.txtFIPRCAPR.Text)

    End Sub
    Private Sub pro_ObtenerConsulta()

        Me.txtFIPRNUFI.Text = Guardar_stFIPRNUFI
        Me.txtFIPRDIRE.Text = Guardar_stFIPRDIRE
        Me.txtFIPRMUNI.Text = Guardar_stFIPRMUNI
        Me.txtFIPRCORR.Text = Guardar_stFIPRCORR
        Me.txtFIPRBARR.Text = Guardar_stFIPRBARR
        Me.txtFIPRMANZ.Text = Guardar_stFIPRMANZ
        Me.txtFIPRPRED.Text = Guardar_stFIPRPRED
        Me.txtFIPREDIF.Text = Guardar_stFIPREDIF
        Me.txtFIPRUNPR.Text = Guardar_stFIPRUNPR
        Me.txtFIPRCLSE.Text = Guardar_stFIPRCLSE
        Me.txtFIPRESTA.Text = Guardar_stFIPRESTA
        Me.txtFIPRCAPR.Text = Guardar_stFIPRCAPR

    End Sub
    Private Sub pro_PermisoControlDeComandos()

        Try

            Me.cmdExportarExcel.Enabled = fun_PermisoControlDeComandos(vp_usuario, Me.Name, Me.cmdExportarExcel.Name)
            Me.cmdExportarPlano.Enabled = fun_PermisoControlDeComandos(vp_usuario, Me.Name, Me.cmdExportarPlano.Name)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_InsertarRegistro(ByVal i As Integer)

        Try
            ' llena las variables de la ficha predial
            vl_stMunicipio = fun_Formato_Mascara_3_Reales(Trim(dt.Rows(i).Item("FIPRMUNI")))
            vl_stSector = Trim(dt.Rows(i).Item("FIPRCLSE"))
            vl_stCorregi = fun_Formato_Mascara_2_Reales(Trim(dt.Rows(i).Item("FIPRCORR")))
            vl_stBarrio = fun_Formato_Mascara_3_Reales(Trim(dt.Rows(i).Item("FIPRBARR")))
            vl_stManzana = fun_Formato_Mascara_3_Reales(Trim(dt.Rows(i).Item("FIPRMANZ")))
            vl_stPredio = fun_Formato_Mascara_5_Reales(Trim(dt.Rows(i).Item("FIPRPRED")))
            vl_stEdificio = fun_Formato_Mascara_3_Reales(Trim(dt.Rows(i).Item("FIPREDIF")))
            vl_stUnidad = fun_Formato_Mascara_5_Reales(Trim(dt.Rows(i).Item("FIPRUNPR")))
            vl_stCarac_Pred = Trim(dt.Rows(i).Item("FIPRCAPR"))

            ' declara la variable
            Dim dt2 As New DataTable

            ' almacena la cantidad de predios y mejora
            dt2 = fun_BuscarCantidadNroDeFichaPredial(vl_stMunicipio, vl_stSector, vl_stCorregi, vl_stBarrio, vl_stManzana, vl_stPredio, vl_stEdificio, vl_stUnidad, vl_inTipoFicha, vl_stCarac_Pred)

            If dt2.Rows.Count > 0 Then

                Dim k As Integer = 0

                For k = 0 To dt2.Rows.Count - 1

                    ' predio sin mejoras
                    If dt2.Rows.Count > 0 Then

                        vl_inFicha = CInt(dt2.Rows(k).Item("FIPRNUFI"))
                        vl_stDescripcion_CP = Trim(fun_Buscar_Lista_Valores_CARAPRED(Trim(dt.Rows(i).Item("FIPRCAPR"))))

                        vl_stDestino = fun_Buscarvl_stDestinoEconomico(fun_BuscarNroDeFichaPredial(vl_stMunicipio, vl_stSector, vl_stCorregi, vl_stBarrio, vl_stManzana, vl_stPredio, vl_stEdificio, vl_stUnidad, vl_inTipoFicha, vl_stCarac_Pred))
                        vl_stDescripcion_DE = Trim(fun_Buscar_Lista_Valores_DESTECON(vl_stDestino))

                        Dim objDatos As New cla_FIPRCONS
                        Dim tblDatos As New DataTable

                        tblDatos = objDatos.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(vl_inFicha)

                        If tblDatos.Rows.Count > 0 Then

                            Dim ii As Integer = 0

                            For ii = 0 To tblDatos.Rows.Count - 1

                                Dim inNroCons As Integer = CInt(tblDatos.Rows(ii).Item("FPCOUNID"))
                                Dim boMejora As Boolean = CBool(tblDatos.Rows(ii).Item("FPCOMEJO"))
                                vl_stUso = CStr(fun_BuscarUsoDeConstruccion(vl_inFicha, inNroCons))
                                vl_boMejora = CBool(fun_BuscarMejora(vl_inFicha, inNroCons))
                                vl_stIdentificador = CStr(tblDatos.Rows(ii).Item("FPCOTICO"))
                                vl_stArea = CStr(tblDatos.Rows(ii).Item("FPCOARCO"))

                                ' predio normal sin mejoras y posee una sola construccion
                                If Me.rbdUnaConstruccion.Checked = True And tblDatos.Rows.Count = 1 And dt2.Rows.Count = 1 Then

                                    ' inserta un nuevo registro
                                    dr_CONSULTA = dt_CONSULTA.NewRow()

                                    dr_CONSULTA("Nro_Ficha") = Trim(vl_inFicha)
                                    dr_CONSULTA("Municipio") = Trim(vl_stMunicipio)
                                    dr_CONSULTA("Sector") = Trim(vl_stSector)
                                    dr_CONSULTA("Corregi") = Trim(vl_stCorregi)
                                    dr_CONSULTA("Barrio") = Trim(vl_stBarrio)
                                    dr_CONSULTA("Manzana") = Trim(vl_stManzana)
                                    dr_CONSULTA("Predio") = Trim(vl_stPredio)
                                    dr_CONSULTA("Edificio") = Trim(vl_stEdificio)
                                    dr_CONSULTA("Unidad") = Trim(vl_stUnidad)
                                    dr_CONSULTA("Nro_Cons") = inNroCons
                                    dr_CONSULTA("Carac_Pred") = Trim(vl_stCarac_Pred)
                                    dr_CONSULTA("Descripcion_CP") = Trim(vl_stDescripcion_CP)
                                    dr_CONSULTA("Destino") = Trim(vl_stDestino)
                                    dr_CONSULTA("Descripcion_DE") = Trim(vl_stDescripcion_DE)
                                    dr_CONSULTA("Uso") = vl_stUso
                                    dr_CONSULTA("Mejora") = vl_boMejora
                                    dr_CONSULTA("Identificador") = vl_stIdentificador
                                    dr_CONSULTA("Area") = vl_stArea

                                    dt_CONSULTA.Rows.Add(dr_CONSULTA)

                                    ' inserta cuando tiene mas de una construccion
                                ElseIf Me.rbdMayorUnaConstruccion.Checked = True And tblDatos.Rows.Count > 1 Then

                                    ' inserta un nuevo registro
                                    dr_CONSULTA = dt_CONSULTA.NewRow()

                                    dr_CONSULTA("Nro_Ficha") = Trim(vl_inFicha)
                                    dr_CONSULTA("Municipio") = Trim(vl_stMunicipio)
                                    dr_CONSULTA("Sector") = Trim(vl_stSector)
                                    dr_CONSULTA("Corregi") = Trim(vl_stCorregi)
                                    dr_CONSULTA("Barrio") = Trim(vl_stBarrio)
                                    dr_CONSULTA("Manzana") = Trim(vl_stManzana)
                                    dr_CONSULTA("Predio") = Trim(vl_stPredio)
                                    dr_CONSULTA("Edificio") = Trim(vl_stEdificio)
                                    dr_CONSULTA("Unidad") = Trim(vl_stUnidad)
                                    dr_CONSULTA("Nro_Cons") = inNroCons
                                    dr_CONSULTA("Carac_Pred") = Trim(vl_stCarac_Pred)
                                    dr_CONSULTA("Descripcion_CP") = Trim(vl_stDescripcion_CP)
                                    dr_CONSULTA("Destino") = Trim(vl_stDestino)
                                    dr_CONSULTA("Descripcion_DE") = Trim(vl_stDescripcion_DE)
                                    dr_CONSULTA("Uso") = vl_stUso
                                    dr_CONSULTA("Mejora") = vl_boMejora
                                    dr_CONSULTA("Identificador") = vl_stIdentificador
                                    dr_CONSULTA("Area") = vl_stArea

                                    dt_CONSULTA.Rows.Add(dr_CONSULTA)

                                    ' inserta las mejoras
                                ElseIf CInt(inNroCons) > 1000 And CBool(boMejora) = True Then

                                    ' inserta un nuevo registro
                                    dr_CONSULTA = dt_CONSULTA.NewRow()

                                    dr_CONSULTA("Nro_Ficha") = Trim(vl_inFicha)
                                    dr_CONSULTA("Municipio") = Trim(vl_stMunicipio)
                                    dr_CONSULTA("Sector") = Trim(vl_stSector)
                                    dr_CONSULTA("Corregi") = Trim(vl_stCorregi)
                                    dr_CONSULTA("Barrio") = Trim(vl_stBarrio)
                                    dr_CONSULTA("Manzana") = Trim(vl_stManzana)
                                    dr_CONSULTA("Predio") = Trim(vl_stPredio)
                                    dr_CONSULTA("Edificio") = Trim(vl_stEdificio)
                                    dr_CONSULTA("Unidad") = Trim(vl_stUnidad)
                                    dr_CONSULTA("Nro_Cons") = inNroCons
                                    dr_CONSULTA("Carac_Pred") = Trim(vl_stCarac_Pred)
                                    dr_CONSULTA("Descripcion_CP") = Trim(vl_stDescripcion_CP)
                                    dr_CONSULTA("Destino") = Trim(vl_stDestino)
                                    dr_CONSULTA("Descripcion_DE") = Trim(vl_stDescripcion_DE)
                                    dr_CONSULTA("Uso") = vl_stUso
                                    dr_CONSULTA("Mejora") = vl_boMejora
                                    dr_CONSULTA("Identificador") = vl_stIdentificador
                                    dr_CONSULTA("Area") = vl_stArea

                                    dt_CONSULTA.Rows.Add(dr_CONSULTA)

                                End If

                            Next

                        Else
                            ' inserta un nuevo registro
                            dr_CONSULTA = dt_CONSULTA.NewRow()

                            dr_CONSULTA("Nro_Ficha") = Trim(vl_inFicha)
                            dr_CONSULTA("Municipio") = Trim(vl_stMunicipio)
                            dr_CONSULTA("Sector") = Trim(vl_stSector)
                            dr_CONSULTA("Corregi") = Trim(vl_stCorregi)
                            dr_CONSULTA("Barrio") = Trim(vl_stBarrio)
                            dr_CONSULTA("Manzana") = Trim(vl_stManzana)
                            dr_CONSULTA("Predio") = Trim(vl_stPredio)
                            dr_CONSULTA("Edificio") = Trim(vl_stEdificio)
                            dr_CONSULTA("Unidad") = Trim(vl_stUnidad)
                            dr_CONSULTA("Nro_Cons") = ""
                            dr_CONSULTA("Carac_Pred") = Trim(vl_stCarac_Pred)
                            dr_CONSULTA("Descripcion_CP") = Trim(vl_stDescripcion_CP)
                            dr_CONSULTA("Destino") = Trim(vl_stDestino)
                            dr_CONSULTA("Descripcion_DE") = Trim(vl_stDescripcion_DE)
                            dr_CONSULTA("Uso") = "Lote"
                            dr_CONSULTA("Mejora") = False
                            dr_CONSULTA("Identificador") = ""
                            dr_CONSULTA("Area") = ""

                            dt_CONSULTA.Rows.Add(dr_CONSULTA)

                        End If

                    End If

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_ConsultaNivelPredio()

        Try
            Me.cmdCONSULTAR.Enabled = False

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

            ' guarda la consulta
            pro_GuardarConsulta()

            ' verifica los datos de los campos
            pro_VerificarDatos()

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select FiprMuni,FiprClse,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEsta,FiprCapr from Fichpred where "
            ParametrosConsulta += "FiprMuni like '" & stFIPRMUNI & "' and "
            ParametrosConsulta += "FiprClse like '" & stFIPRCLSE & "' and "
            ParametrosConsulta += "FiprCorr like '" & stFIPRCORR & "' and "
            ParametrosConsulta += "FiprBarr like '" & stFIPRBARR & "' and "
            ParametrosConsulta += "FiprManz like '" & stFIPRMANZ & "' and "
            ParametrosConsulta += "FiprPred like '" & stFIPRPRED & "' and "
            ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' "
            ParametrosConsulta += "group by FiprMuni,FiprClse,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEsta,FiprCapr "
            ParametrosConsulta += "order by FiprClse,FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred "

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

                If MessageBox.Show("¿ Desea continuar ? " & "Nro de registros: " & dt.Rows.Count, "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    Dim dr_CONSULTA As DataRow

                    dt_CONSULTA = New DataTable

                    ' crea las columnas
                    dt_CONSULTA.Columns.Add(New DataColumn("Municipio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Sector", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Corregi", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Barrio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Manzana", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Predio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Carac_Pred", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Descripcion_CP", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Destino", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Descripcion_DE", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Total_Edif", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Total_RPH", GetType(String)))

                    ' declara la variable
                    vl_inFicha = 0
                    vl_inTipoFicha = 0
                    vl_stMunicipio = ""
                    vl_stSector = ""
                    vl_stCorregi = ""
                    vl_stBarrio = ""
                    vl_stManzana = ""
                    vl_stPredio = ""
                    vl_stCarac_Pred = ""
                    vl_stDescripcion_CP = ""
                    vl_stDestino = ""
                    vl_stDescripcion_DE = ""
                    Dim stTotal_Edif As String = ""
                    Dim stTotal_RPH As String = ""

                    ' Valores predeterminados ProgressBar
                    inProceso = 0
                    pbPROCESO.Value = 0
                    pbPROCESO.Maximum = dt.Rows.Count
                    Timer1.Enabled = True

                    Dim i As Integer = 0

                    For i = 0 To dt.Rows.Count - 1

                        ' llena las variables de la ficha predial
                        vl_stMunicipio = fun_Formato_Mascara_3_Reales(Trim(dt.Rows(i).Item("FIPRMUNI")))
                        vl_stSector = Trim(dt.Rows(i).Item("FIPRCLSE"))
                        vl_stCorregi = fun_Formato_Mascara_2_Reales(Trim(dt.Rows(i).Item("FIPRCORR")))
                        vl_stBarrio = fun_Formato_Mascara_3_Reales(Trim(dt.Rows(i).Item("FIPRBARR")))
                        vl_stManzana = fun_Formato_Mascara_3_Reales(Trim(dt.Rows(i).Item("FIPRMANZ")))
                        vl_stPredio = fun_Formato_Mascara_5_Reales(Trim(dt.Rows(i).Item("FIPRPRED")))

                        vl_stCarac_Pred = Trim(dt.Rows(i).Item("FIPRCAPR"))
                        vl_stDescripcion_CP = Trim(fun_Buscar_Lista_Valores_CARAPRED(Trim(dt.Rows(i).Item("FIPRCAPR"))))

                        vl_inTipoFicha = fun_BuscarTipoDeFichaPredial(vl_stMunicipio, vl_stSector, vl_stCorregi, vl_stBarrio, vl_stManzana, vl_stPredio, vl_stCarac_Pred)

                        vl_stDestino = fun_Buscarvl_stDestinoEconomico(fun_BuscarNroDeFichaPredial(vl_stMunicipio, vl_stSector, vl_stCorregi, vl_stBarrio, vl_stManzana, vl_stPredio, vl_inTipoFicha, vl_stCarac_Pred))
                        vl_stDescripcion_DE = Trim(fun_Buscar_Lista_Valores_DESTECON(vl_stDestino))

                        stTotal_Edif = fun_BuscarTotalEdificio(vl_stMunicipio, vl_stSector, vl_stCorregi, vl_stBarrio, vl_stManzana, vl_stPredio, vl_inTipoFicha, vl_stCarac_Pred)
                        stTotal_RPH = fun_BuscarTotalUnidadesPrediales(vl_stMunicipio, vl_stSector, vl_stCorregi, vl_stBarrio, vl_stManzana, vl_stPredio, vl_inTipoFicha, vl_stCarac_Pred)

                        ' inserta un nuevo registro
                        dr_CONSULTA = dt_CONSULTA.NewRow()

                        dr_CONSULTA("Municipio") = Trim(vl_stMunicipio)
                        dr_CONSULTA("Sector") = Trim(vl_stSector)
                        dr_CONSULTA("Corregi") = Trim(vl_stCorregi)
                        dr_CONSULTA("Barrio") = Trim(vl_stBarrio)
                        dr_CONSULTA("Manzana") = Trim(vl_stManzana)
                        dr_CONSULTA("Predio") = Trim(vl_stPredio)
                        dr_CONSULTA("Carac_Pred") = Trim(vl_stCarac_Pred)
                        dr_CONSULTA("Descripcion_CP") = Trim(vl_stDescripcion_CP)
                        dr_CONSULTA("Destino") = Trim(vl_stDestino)
                        dr_CONSULTA("Descripcion_DE") = Trim(vl_stDescripcion_DE)
                        dr_CONSULTA("Total_Edif") = Trim(stTotal_Edif)
                        dr_CONSULTA("Total_RPH") = Trim(stTotal_RPH)

                        dt_CONSULTA.Rows.Add(dr_CONSULTA)

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbPROCESO.Value = inProceso

                    Next

                    ' llena el datagridview
                    Me.dgvCONSULTA.DataSource = dt_CONSULTA

                End If

            Else
                Me.dgvCONSULTA.DataSource = New DataTable
                mod_MENSAJE.Consulta_No_Encontro_Registros()

            End If

            ' Numero de registros recuperados
            Me.strBARRESTA.Items(2).Text = "Registros : " & dgvCONSULTA.RowCount.ToString

            Me.pbPROCESO.Value = 0

            Me.cmdCONSULTAR.Enabled = True
            Me.dgvCONSULTA.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ConsultaNivelConstruccion()

        Try
            Me.cmdCONSULTAR.Enabled = False

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

            ' guarda la consulta
            pro_GuardarConsulta()

            ' verifica los datos de los campos
            pro_VerificarDatos()

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Select FiprMuni,FiprClse,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr,FiprEsta,FiprCapr from Fichpred where "
            ParametrosConsulta += "FiprNufi like '" & stFIPRNUFI & "' and "
            ParametrosConsulta += "FiprDire like '" & stFIPRDIRE & "' and "
            ParametrosConsulta += "FiprMuni like '" & stFIPRMUNI & "' and "
            ParametrosConsulta += "FiprClse like '" & stFIPRCLSE & "' and "
            ParametrosConsulta += "FiprCorr like '" & stFIPRCORR & "' and "
            ParametrosConsulta += "FiprBarr like '" & stFIPRBARR & "' and "
            ParametrosConsulta += "FiprManz like '" & stFIPRMANZ & "' and "
            ParametrosConsulta += "FiprPred like '" & stFIPRPRED & "' and "
            ParametrosConsulta += "FiprEdif like '" & stFIPREDIF & "' and "
            ParametrosConsulta += "FiprUnpr like '" & stFIPRUNPR & "' and "
            ParametrosConsulta += "FiprCapr like '" & stFIPRCAPR & "' and "
            ParametrosConsulta += "FiprEsta like '" & stFIPRESTA & "' and "
            ParametrosConsulta += "FiprTifi = 0 "
            ParametrosConsulta += "group by FiprMuni,FiprClse,FiprCorr,FiprBarr,FiprManz,FiprPred,FiprEdif,FiprUnpr,FiprEsta,FiprCapr "
            ParametrosConsulta += "order by FiprClse,FiprMuni,FiprCorr,FiprBarr,FiprManz,FiprPred "

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

                If MessageBox.Show("¿ Desea continuar ? " & "Nro de registros: " & dt.Rows.Count, "Mensaje ...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then

                    dt_CONSULTA = New DataTable

                    ' crea las columnas
                    dt_CONSULTA.Columns.Add(New DataColumn("Nro_Ficha", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Municipio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Sector", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Corregi", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Barrio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Manzana", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Predio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Edificio", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Unidad", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Nro_Cons", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Carac_Pred", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Descripcion_CP", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Destino", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Descripcion_DE", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Uso", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Mejora", GetType(Boolean)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Identificador", GetType(String)))
                    dt_CONSULTA.Columns.Add(New DataColumn("Area", GetType(String)))

                    ' declara la variable
                    vl_inFicha = 0
                    vl_inTipoFicha = 0
                    vl_stMunicipio = ""
                    vl_stSector = ""
                    vl_stCorregi = ""
                    vl_stBarrio = ""
                    vl_stManzana = ""
                    vl_stPredio = ""
                    vl_stEdificio = ""
                    vl_stUnidad = ""
                    vl_inNro_Cons = 0
                    vl_stCarac_Pred = ""
                    vl_stDescripcion_CP = ""
                    vl_stDestino = ""
                    vl_stDescripcion_DE = ""
                    vl_stUso = ""
                    vl_boMejora = False
                    vl_stIdentificador = ""
                    vl_stArea = ""

                    ' Valores predeterminados ProgressBar
                    inProceso = 0
                    pbPROCESO.Value = 0
                    pbPROCESO.Maximum = dt.Rows.Count
                    Timer1.Enabled = True

                    Dim i As Integer = 0

                    For i = 0 To dt.Rows.Count - 1

                        If Me.rbdCaracteristicaNormal.Checked = True And CInt(Trim(dt.Rows(i).Item("FIPRCAPR"))) = 1 Then

                            pro_InsertarRegistro(i)

                        ElseIf Me.rbdCaracteristicaNormal.Checked = False Then

                            pro_InsertarRegistro(i)

                        End If

                        ' Incrementa la barra
                        inProceso = inProceso + 1
                        pbPROCESO.Value = inProceso

                    Next

                    ' llena el datagridview
                    Me.dgvCONSULTA.DataSource = dt_CONSULTA

                End If

            Else
                Me.dgvCONSULTA.DataSource = New DataTable
                mod_MENSAJE.Consulta_No_Encontro_Registros()

            End If

            ' Numero de registros recuperados
            Me.strBARRESTA.Items(2).Text = "Registros : " & dgvCONSULTA.RowCount.ToString

            Me.pbPROCESO.Value = 0

            Me.cmdCONSULTAR.Enabled = True
            Me.dgvCONSULTA.Focus()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

#Region "MENU"

    Private Sub cmdCONSULTAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.Click

        Try
            If Me.cboSELECCION.Text = "" Then
                MessageBox.Show("Seleccione una opción", "Mensaje...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                Dim seleccion As String

                seleccion = cboSELECCION.SelectedIndex

                Select Case seleccion
                    Case 0
                        pro_ConsultaNivelPredio()
                    Case 1
                        pro_ConsultaNivelConstruccion()

                End Select
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub cmdULTIMACONSULTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdULTIMACONSULTA.Click
        pro_LimpiarCampos()
        pro_ObtenerConsulta()
        cmdCONSULTAR.Focus()
    End Sub
    Private Sub cmdPLANO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.Click
        Try

            If dgvCONSULTA.RowCount > 0 Then

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

                    ' se carga el separador
                    Separador = Trim(txtSEPARADOR.Text)

                    'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas
                    Using archivo As StreamWriter = New StreamWriter(oCrear.FileName)

                        ' variable para almacenar la línea actual del dataview
                        Dim linea As String = String.Empty

                        With dgvCONSULTA
                            ' Recorrer las filas del dataGridView
                            For fila As Integer = 0 To .RowCount - 1
                                ' vaciar la línea
                                linea = String.Empty

                                ' Recorrer la cantidad de columnas que contiene el dataGridView
                                For col As Integer = 0 To .Columns.Count - 1
                                    ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
                                    linea = linea & Trim(.Item(col, fila).Value.ToString) & Separador
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
                    'txtRUTA.Text = ""
                    txtFIPRNUFI.Focus()
                End If
            Else
                MessageBox.Show("Ejecute la consulta antes de exportar el plano", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdLIMPIAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.Click
        pro_LimpiarCampos()
        Me.txtFIPRNUFI.Focus()
    End Sub
    Private Sub cmdExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.Click
        Try
            If Me.dgvCONSULTA.RowCount = 0 Then
                MessageBox.Show("No existe datos para exportar", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Else
                Dim oExp As New cla_ExportarTablaExcel
                oExp.DataTableToExcel(CType(Me.dgvCONSULTA.DataSource, DataTable))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub
    Private Sub cmdSALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSALIR.Click
        Me.txtFIPRNUFI.Focus()
        Me.Close()
    End Sub

#End Region

#Region "FORMULARIO"

#Region "Load"

    Private Sub frm_consulta_propietario_FIPRPROP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pro_LimpiarCampos()
        Me.txtFIPRNUFI.Focus()

        pro_PermisoControlDeComandos()
    End Sub

#End Region

#Region "GotFocus"

    Private Sub txtFIPRNUFI_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRNUFI.GotFocus
        txtFIPRNUFI.SelectionStart = 0
        txtFIPRNUFI.SelectionLength = Len(txtFIPRNUFI.Text)
        strBARRESTA.Items(0).Text = txtFIPRNUFI.AccessibleDescription
    End Sub
    Private Sub txtFIPRDIRE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRDIRE.GotFocus
        txtFIPRDIRE.SelectionStart = 0
        txtFIPRDIRE.SelectionLength = Len(txtFIPRDIRE.Text)
        strBARRESTA.Items(0).Text = txtFIPRDIRE.AccessibleDescription
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
    Private Sub txtFIPRESTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRESTA.GotFocus
        txtFIPRESTA.SelectionStart = 0
        txtFIPRESTA.SelectionLength = Len(txtFIPRESTA.Text)
        strBARRESTA.Items(0).Text = txtFIPRESTA.AccessibleDescription
    End Sub
    Private Sub cboFPPRSEXO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCAPR.GotFocus
        txtFIPRCAPR.SelectionStart = 0
        txtFIPRCAPR.SelectionLength = Len(txtFIPRCAPR.Text)
        strBARRESTA.Items(0).Text = txtFIPRCAPR.AccessibleDescription
    End Sub
    Private Sub txtGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCLSE.GotFocus, txtFIPRCAPR.GotFocus
        pp_pro_SobrearCampo(sender)
        pp_pro_DescripcionCampo(Me.strBARRESTA.Items(0), sender)
    End Sub


    Private Sub cmdCONSULTAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCONSULTAR.GotFocus
        strBARRESTA.Items(0).Text = cmdCONSULTAR.AccessibleDescription
    End Sub
    Private Sub cmdPLANO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarPlano.GotFocus
        strBARRESTA.Items(0).Text = cmdExportarPlano.AccessibleDescription
    End Sub
    Private Sub cmdSALIR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSALIR.GotFocus
        strBARRESTA.Items(0).Text = cmdSALIR.AccessibleDescription
    End Sub
    Private Sub cmdLIMPIAR_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLIMPIAR.GotFocus
        strBARRESTA.Items(0).Text = cmdLIMPIAR.AccessibleDescription
    End Sub
    Private Sub dgvCONSULTA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvCONSULTA.GotFocus
        strBARRESTA.Items(0).Text = dgvCONSULTA.AccessibleDescription
    End Sub
    Private Sub cmdExportarExcel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportarExcel.GotFocus
        strBARRESTA.Items(0).Text = cmdExportarExcel.AccessibleDescription
    End Sub

#End Region

#Region "KeyPress"

    Private Sub txtFIPRNUFI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRNUFI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRDIRE.Focus()
        End If

    End Sub
    Private Sub txtFIPRDIRE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRDIRE.KeyPress
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
            txtFIPRESTA.Focus()
        End If

    End Sub
    Private Sub txtFIPRCLSE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCLSE.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            cmdCONSULTAR.Focus()
        End If
    End Sub
    Private Sub txtFIPRESTA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRESTA.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCLSE.Focus()
        End If
    End Sub
    Private Sub txtFIPRCASU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCAPR.Focus()
        End If
    End Sub
    Private Sub txtFIPRCAPR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCAPR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtFIPRCLSE.Focus()
        End If
    End Sub
    Private Sub txtKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFIPRCLSE.KeyPress, txtFIPRCAPR.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Enter) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then
            pp_pro_SaltarCampo()
        End If

    End Sub

#End Region

#Region "KeyDown"

    Private Sub cmdCONSULTAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdCONSULTAR.KeyDown, txtFIPRNUFI.KeyDown, txtFIPRDIRE.KeyDown, txtFIPRMUNI.KeyDown, txtFIPRCORR.KeyDown, txtFIPRBARR.KeyDown, txtFIPRMANZ.KeyDown, txtFIPRPRED.KeyDown, txtFIPREDIF.KeyDown, txtFIPRUNPR.KeyDown, txtFIPRCLSE.KeyDown, txtFIPRESTA.KeyDown, dgvCONSULTA.KeyDown, txtFIPRCAPR.KeyDown
        If e.KeyCode = Keys.F8 Then
            cmdCONSULTAR.PerformClick()
        End If

        If e.KeyCode = Keys.F7 Then
            cmdULTIMACONSULTA.PerformClick()
        End If

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
    Private Sub txtFIPRCLSE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCLSE.Validated
        If Trim(txtFIPRCLSE.Text) = "" Then
            lblFIPRCLSE.Text = ""
        Else
            lblFIPRCLSE.Text = CType(fun_Buscar_Lista_Valores_CLASSECT(Trim(txtFIPRCLSE.Text)), String)
        End If
    End Sub
    Private Sub txtFIPRCAPR_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFIPRCAPR.Validated
        If Trim(txtFIPRCAPR.Text) = "" Then
            lblFIPRCAPR.Text = ""
        Else
            lblFIPRCAPR.Text = CType(fun_Buscar_Lista_Valores_CALIPROP(Trim(txtFIPRCAPR.Text)), String)
        End If
    End Sub

#End Region

#Region "TextChanged"

    Private Sub tstBAESDESC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tstBAESDESC.TextChanged
        If tstBAESDESC.Text <> "" Then
            MessageBox.Show(Trim(tstBAESDESC.Text), "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"

    Private Sub cboSELECCION_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSELECCION.SelectedIndexChanged

        Dim inSeleccion As Integer = Me.cboSELECCION.SelectedIndex

        Select Case inSeleccion

            Case 0
                Me.fraCansulta1.Visible = False
                Me.fraCansulta2.Visible = False

            Case 1
                Me.fraCansulta1.Visible = True
                Me.fraCansulta2.Visible = True

        End Select

    End Sub

#End Region

#End Region

End Class