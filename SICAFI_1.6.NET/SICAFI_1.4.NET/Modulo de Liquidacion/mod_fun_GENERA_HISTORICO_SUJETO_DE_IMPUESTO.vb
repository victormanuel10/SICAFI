Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Module mod_fun_GENERA_HISTORICO_SUJETO_DE_IMPUESTO

    '=================================
    '*** GENERA SUJETO DE IMPUESTO ***
    '=================================

#Region "VARIABLES"

#Region "Tablas"

    ' Tabla 0
    Private dt_FICHPRED As New DataTable
    ' Tabla 1
    'Private dt_FIPRDEEC As New DataTable
    ' Tabla 2
    Private dt_FIPRPROP As New DataTable
    ' Tabla 3
    'Private dt_FIPRCONS As New DataTable
    ' Tabla 4
    'Private dt_FIPRCACO As New DataTable
    ' Tabla 5
    'Private dt_FIPRLIND As New DataTable
    ' Tabla 6
    'Private dt_FIPRCART As New DataTable
    ' Tabla 7
    'Private dt_FIPRZOEC As New DataTable
    ' Tabla 8
    'Private dt_FIPRZOFI As New DataTable

#End Region

#Region "Ficha Predial"

    Private vl_inSUIMNUFI As Integer
    Private vl_inSUIMCLSE As Integer
    Private vl_stSUIMVIGE As String = ""
    Private vl_inSUIMTIFI As Integer
    Private vl_boSUIMVIAN As Boolean
    Private vl_boSUIMVIAC As Boolean
    Private vl_stFPPRMAIN As String = ""
    Private vl_stSUIMMAIN As String = ""
    Private vl_boSUIMMEJO As Boolean = False
    Private vl_boSUIMPRRE As Boolean = False
    Private vl_boRemplazarTodosLosPredios As Boolean = False
    Private vl_boInscribirSoloPrediosNuevos As Boolean = False

    ' declara las variables ficha predial
    Private vl_stFIPRDESC As String = ""
    Private vl_stFIPRDIRE As String = ""
    Private vl_stFIPRCOMU As String = ""
    Private vl_stFIPRDEPA As String = ""
    Private vl_stFIPRMUNI As String = ""
    Private vl_stFIPRCORR As String = ""
    Private vl_stFIPRBARR As String = ""
    Private vl_stFIPRMANZ As String = ""
    Private vl_stFIPRPRED As String = ""
    Private vl_stFIPREDIF As String = ""
    Private vl_stFIPRUNPR As String = ""
    Private vl_stFIPRCLSE As String = ""
    Private vl_stFIPRCOMA As String = ""
    Private vl_stFIPRDEAN As String = ""
    Private vl_stFIPRMUAN As String = ""
    Private vl_stFIPRCOAN As String = ""
    Private vl_stFIPRBAAN As String = ""
    Private vl_stFIPRMAAN As String = ""
    Private vl_stFIPRPRAN As String = ""
    Private vl_stFIPREDAN As String = ""
    Private vl_stFIPRUPAN As String = ""
    Private vl_stFIPRCSAN As String = ""
    Private vl_stFIPRCAPR As String = ""
    Private vl_inFIPRMOAD As Integer = 0
    Private vl_stFIPRSUAC As String = ""
    Private vl_stFIPRESTA As String = ""

    ' declara las variables sujeto de impuesto
    Private vl_stSUIMCOMU As String = ""
    Private vl_stSUIMDEPA As String = ""
    Private vl_stSUIMMUNI As String = ""
    Private vl_stSUIMCORR As String = ""
    Private vl_stSUIMBARR As String = ""
    Private vl_stSUIMMANZ As String = ""
    Private vl_stSUIMPRED As String = ""
    Private vl_stSUIMEDIF As String = ""
    Private vl_stSUIMUNPR As String = ""
    Private vl_stSUIMCLSE As String = ""
    Private vl_stSUIMCOMA As String = ""
    Private vl_stSUIMDEAN As String = ""
    Private vl_stSUIMMUAN As String = ""
    Private vl_stSUIMCOAN As String = ""
    Private vl_stSUIMBAAN As String = ""
    Private vl_stSUIMMAAN As String = ""
    Private vl_stSUIMPRAN As String = ""
    Private vl_stSUIMEDAN As String = ""
    Private vl_stSUIMUPAN As String = ""
    Private vl_stSUIMCSAN As String = ""
    Private vl_stSUIMCAPR As String = ""
    Private vl_stSUIMMOAD As String = ""
    Private vl_stSUIMVIAC As String = ""
    Private vl_stSUIMVIAN As String = ""
    Private vl_stSUIMSUAC As String = ""
    Private vl_stSUIMESTA As String = ""
    Private vl_stSUIMSUAN As String = ""
    Private vl_boSUIMPRNU As Boolean = False
    Private vl_boSUIMPRCA As Boolean = False
    Private vl_boSUIMMANU As Boolean = False
    Private vl_boSUIMMACA As Boolean = False

    Private vl_stSUIMNI01 As String = ""
    Private vl_stSUIMNI02 As String = ""
    Private vl_stSUIMNI03 As String = ""
    Private vl_stSUIMNI04 As String = ""
    Private vl_stSUIMNI05 As String = ""
    Private vl_stSUIMNI06 As String = ""
    Private vl_stSUIMNI07 As String = ""
    Private vl_stSUIMNI08 As String = ""
    Private vl_stSUIMNI09 As String = ""
    Private vl_stSUIMNI10 As String = ""
    Private vl_stSUIMNI11 As String = ""
    Private vl_stSUIMNI12 As String = ""
    Private vl_stSUIMNI13 As String = ""
    Private vl_stSUIMNI14 As String = ""
    Private vl_stSUIMNI15 As String = ""
    Private vl_stSUIMNI16 As String = ""
    Private vl_stSUIMNI17 As String = ""
    Private vl_stSUIMNI18 As String = ""
    Private vl_stSUIMNI19 As String = ""
    Private vl_stSUIMNI20 As String = ""
    Private vl_stSUIMNI21 As String = ""
    Private vl_stSUIMNI22 As String = ""
    Private vl_stSUIMNI23 As String = ""
    Private vl_stSUIMNI24 As String = ""
    Private vl_stSUIMNI25 As String = ""
    Private vl_stSUIMNI26 As String = ""
    Private vl_stSUIMNI27 As String = ""
    Private vl_stSUIMNI28 As String = ""
    Private vl_stSUIMNI29 As String = ""
    Private vl_stSUIMNI30 As String = ""

#End Region

#Region "Conexion"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#End Region

#Region "FUNCIONES"

    Private Function fun_BuscaMatriculaInmobiliaria() As String

        Try
            Dim stMatricula As String = ""

            Dim objPropietario As New cla_FIPRPROP
            Dim tblPropietario As New DataTable

            tblPropietario = objPropietario.fun_Consultar_FIPRPROP_X_FICHA_PREDIAL(vl_inSUIMNUFI)

            If tblPropietario.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To tblPropietario.Rows.Count - 1

                    If Trim(tblPropietario.Rows(i).Item("FPPRESTA")) = "ac" Then

                        stMatricula = Trim(tblPropietario.Rows(i).Item("FPPRMAIN"))

                    End If

                Next

            End If

            Return stMatricula

        Catch ex As Exception
            Return ""
        End Try

    End Function
    Private Function fun_BuscaPredioMejora() As Boolean

        Try
            Dim boMejora As Boolean = False

            Dim objConstruccion As New cla_FIPRCONS
            Dim tblConstruccion As New DataTable

            tblConstruccion = objConstruccion.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(vl_inSUIMNUFI)

            If tblConstruccion.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To tblConstruccion.Rows.Count - 1

                    If Trim(tblConstruccion.Rows(i).Item("FPCOESTA")) = "ac" Then
                        If tblConstruccion.Rows(i).Item("FPCOMEJO") = True Then
                            boMejora = True
                        End If
                    End If

                Next

            End If

            Return boMejora

        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Function fun_BuscaPredioPorNroDeFichaPredial(ByVal stSUIMNUFI As String) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim objSujetoImpuesto11 As New cla_SUJEIMPU
            Dim tblSujetoImpuesto11 As New DataTable

            tblSujetoImpuesto11 = objSujetoImpuesto11.fun_Consultar_SUJEIMPU_X_NRO_FICHA(stSUIMNUFI)

            If tblSujetoImpuesto11.Rows.Count > 0 Then
                boRespuesta = True
            Else
                boRespuesta = False
            End If

            Return boRespuesta

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_BuscaPredioPorMatriculaInmobiliaria(ByVal stSUIMMAIN As String) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim objSujetoImpuesto11 As New cla_SUJEIMPU
            Dim tblSujetoImpuesto11 As New DataTable

            tblSujetoImpuesto11 = objSujetoImpuesto11.fun_Consultar_SUJEIMPU_X_MATRICULA(stSUIMMAIN)

            If tblSujetoImpuesto11.Rows.Count > 0 Then
                boRespuesta = True
            Else
                boRespuesta = False
            End If

            Return boRespuesta

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_BuscaPredioPorCedulaCatastralActual(ByVal stSUIMMUNI As String, _
                                                             ByVal stSUIMCORR As String, _
                                                             ByVal stSUIMBARR As String, _
                                                             ByVal stSUIMMANZ As String, _
                                                             ByVal stSUIMPRED As String, _
                                                             ByVal stSUIMEDIF As String, _
                                                             ByVal stSUIMUNPR As String, _
                                                             ByVal stSUIMCLSE As String) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim objSujetoImpuesto11 As New cla_SUJEIMPU
            Dim tblSujetoImpuesto11 As New DataTable

            tblSujetoImpuesto11 = objSujetoImpuesto11.fun_Consultar_SUJEIMPU_X_CEDULA_CATASTRAL_ACTUAL(stSUIMMUNI, _
                                                                                                       stSUIMCORR, _
                                                                                                       stSUIMBARR, _
                                                                                                       stSUIMMANZ, _
                                                                                                       stSUIMPRED, _
                                                                                                       stSUIMEDIF, _
                                                                                                       stSUIMUNPR, _
                                                                                                       stSUIMCLSE)

            If tblSujetoImpuesto11.Rows.Count > 0 Then
                boRespuesta = True
            Else
                boRespuesta = False
            End If

            Return boRespuesta

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_BuscaPredioPorCedulaCatastralAnterior(ByVal stSUIMMUAN As String, _
                                                               ByVal stSUIMCOAN As String, _
                                                               ByVal stSUIMBAAN As String, _
                                                               ByVal stSUIMMAAN As String, _
                                                               ByVal stSUIMPRAN As String, _
                                                               ByVal stSUIMEDAN As String, _
                                                               ByVal stSUIMUPAN As String, _
                                                               ByVal stSUIMCSAN As String) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim objSujetoImpuesto11 As New cla_SUJEIMPU
            Dim tblSujetoImpuesto11 As New DataTable

            tblSujetoImpuesto11 = objSujetoImpuesto11.fun_Consultar_SUJEIMPU_X_CEDULA_CATASTRAL_ANTERIOR(stSUIMMUAN, _
                                                                                                         stSUIMCOAN, _
                                                                                                         stSUIMBAAN, _
                                                                                                         stSUIMMAAN, _
                                                                                                         stSUIMPRAN, _
                                                                                                         stSUIMEDAN, _
                                                                                                         stSUIMUPAN, _
                                                                                                         stSUIMCSAN)

            If tblSujetoImpuesto11.Rows.Count > 0 Then
                boRespuesta = True
            Else
                boRespuesta = False
            End If

            Return boRespuesta

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_BuscaPredioPorMatricula(ByVal stSUIMMAIN As String) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim objSujetoImpuesto11 As New cla_SUJEIMPU
            Dim tblSujetoImpuesto11 As New DataTable

            tblSujetoImpuesto11 = objSujetoImpuesto11.fun_Consultar_SUJEIMPU_X_MATRICULA(stSUIMMAIN)

            If tblSujetoImpuesto11.Rows.Count > 0 Then
                boRespuesta = True
            Else
                boRespuesta = False
            End If

            Return boRespuesta

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_GENERA_HISTORICO_DE_SUJETO_DE_IMPUESTO(ByVal o_inFIPRNUFI As Integer, _
                                                          ByVal o_inSUIMCLSE As Integer, _
                                                          ByVal o_inSUIMVIGE As Integer, _
                                                          ByVal o_boSUIMVIAC As Boolean, _
                                                          ByVal o_boSUIMVIAN As Boolean, _
                                                          ByVal o_boSUIMREPR As Boolean, _
                                                          ByVal o_boSUIMINPR As Boolean)

        Try
            ' declaro variables
            vl_inSUIMNUFI = o_inFIPRNUFI
            vl_inSUIMCLSE = o_inSUIMCLSE
            vl_stSUIMVIGE = o_inSUIMVIGE
            vl_boSUIMVIAC = o_boSUIMVIAC
            vl_boSUIMVIAN = o_boSUIMVIAN
            vl_boRemplazarTodosLosPredios = o_boSUIMREPR
            vl_boInscribirSoloPrediosNuevos = o_boSUIMINPR

            ' Carga las tablas
            pro_CargarTablasFichaPredial()

            ' Liquida avaluo por caracteritica de predio
            If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Or dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Or dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                If Trim(dt_FICHPRED.Rows(0).Item("FIPRESTA")) = "ac" Then

                    ' filtra caracteristica de predio 
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 5 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

                        pro_GuardarHistoricoSujetoImpuesto()
                    End If

                End If
            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "Liquida Historicos de Liquidacion Impuestos")
        End Try

    End Sub

    Private Sub pro_CargarTablasFichaPredial()

        Try

            Dim objdatos As New cla_FIPRAVAL
            Dim ds As New DataSet

            ds = objdatos.fun_Consultar_TABLAS_FICHA_PREDIAL(vl_inSUIMNUFI)

            ' instancia las tablas
            dt_FICHPRED = New DataTable
            dt_FIPRPROP = New DataTable

            ' Tabla 0
            dt_FICHPRED = ds.Tables(0)
            ' Tabla 7
            dt_FIPRPROP = ds.Tables(2)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GuardarHistoricoSujetoImpuesto()

        Try

            ' declara las variables 
            vl_inSUIMTIFI = dt_FICHPRED.Rows(0).Item("FIPRTIFI")

            ' Guarda las zonas de la ficha predial
            If vl_inSUIMTIFI = 0 Then

                ' declara las variables ficha predial
                vl_stFIPRCOMU = "00"
                vl_inFIPRMOAD = 1
                vl_stSUIMCLSE = ""
                vl_stSUIMCSAN = ""

                ' declara las variables sujeto de impuesto
                vl_stSUIMCOMU = "00"
                vl_stSUIMCOMA = "00"
                vl_stSUIMESTA = CStr(Trim(dt_FICHPRED.Rows(0).Item("FIPRESTA")))

                If vl_boSUIMVIAC = True Then
                    vl_stSUIMVIAC = vl_stSUIMVIGE
                    vl_stSUIMVIAN = vl_stSUIMVIGE - 1
                    vl_stSUIMCLSE = vl_inSUIMCLSE

                ElseIf vl_boSUIMVIAN = True Then
                    vl_stSUIMVIAN = vl_stSUIMVIGE
                    vl_stSUIMCSAN = vl_inSUIMCLSE
                End If

                vl_boSUIMPRNU = False
                vl_boSUIMPRCA = False
                vl_boSUIMMANU = False
                vl_boSUIMMACA = False

                vl_boSUIMMEJO = fun_BuscaPredioMejora()
                vl_stSUIMMAIN = fun_BuscaMatriculaInmobiliaria()

                ' declara la instancia
                Dim objFichaPredial As New cla_FICHPRED
                Dim tblFichaPredial As New DataTable

                tblFichaPredial = objFichaPredial.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(vl_inSUIMNUFI)

                If tblFichaPredial.Rows.Count > 0 Then

                    vl_stFIPRDESC = Trim(dt_FICHPRED.Rows(0).Item("FIPRDESC"))
                    vl_stFIPRDIRE = Trim(dt_FICHPRED.Rows(0).Item("FIPRDIRE"))
                    vl_stFIPRCAPR = Trim(dt_FICHPRED.Rows(0).Item("FIPRCAPR"))
                    vl_inFIPRMOAD = Trim(dt_FICHPRED.Rows(0).Item("FIPRMOAD"))
                    vl_stFIPRESTA = Trim(dt_FICHPRED.Rows(0).Item("FIPRESTA"))

                    vl_stSUIMDEPA = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                    vl_stSUIMMUNI = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                    vl_stSUIMCORR = Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR"))
                    vl_stSUIMBARR = Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR"))
                    vl_stSUIMMANZ = Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ"))
                    vl_stSUIMPRED = Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED"))
                    vl_stSUIMEDIF = Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF"))
                    vl_stSUIMUNPR = Trim(dt_FICHPRED.Rows(0).Item("FIPRUNPR"))
                    vl_stSUIMCLSE = Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE"))
                    vl_stSUIMDEAN = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                    vl_stSUIMMUAN = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUAN"))
                    vl_stSUIMCOAN = Trim(dt_FICHPRED.Rows(0).Item("FIPRCOAN"))
                    vl_stSUIMBAAN = Trim(dt_FICHPRED.Rows(0).Item("FIPRBAAN"))
                    vl_stSUIMMAAN = Trim(dt_FICHPRED.Rows(0).Item("FIPRMAAN"))
                    vl_stSUIMPRAN = Trim(dt_FICHPRED.Rows(0).Item("FIPRPRAN"))
                    vl_stSUIMEDAN = Trim(dt_FICHPRED.Rows(0).Item("FIPREDAN"))
                    vl_stSUIMUPAN = Trim(dt_FICHPRED.Rows(0).Item("FIPRUPAN"))
                    vl_stSUIMCSAN = Trim(dt_FICHPRED.Rows(0).Item("FIPRCSAN"))
                  
                    ' inscribe predios de la vigencia anterior 
                    If vl_boSUIMVIAN = True Then

                        ' concatena la cedula catastral anterior
                        vl_stSUIMSUAN = vl_stSUIMDEPA & vl_stSUIMMUNI & vl_stSUIMCLSE & vl_stSUIMCORR & vl_stSUIMBARR & vl_stSUIMMANZ & vl_stSUIMPRED & vl_stSUIMEDIF & vl_stSUIMUNPR

                        ' remplaza el predio
                        If vl_boRemplazarTodosLosPredios = True Then

                            ' instancia la clase
                            Dim objSujetoImpuesto11 As New cla_SUJEIMPU
                            Dim tblSujetoImpuesto11 As New DataTable

                            tblSujetoImpuesto11 = objSujetoImpuesto11.fun_Consultar_SUJEIMPU_X_NRO_FICHA(vl_inSUIMNUFI)

                            If tblSujetoImpuesto11.Rows.Count > 0 Then
                                ' actualiza sujeto de impuesto
                                pro_ActualizarSujetoImpuesto()
                            Else
                                ' inserta sujeto de impuesto
                                pro_InsertarSujetoImpuesto()
                            End If

                            ' solo inscribe predios nuevos
                        ElseIf vl_boInscribirSoloPrediosNuevos = True Then

                            ' instancia la clase
                            Dim objSujetoImpuesto12 As New cla_SUJEIMPU
                            Dim tblSujetoImpuesto12 As New DataTable

                            tblSujetoImpuesto12 = objSujetoImpuesto12.fun_Consultar_SUJEIMPU_X_NRO_FICHA(vl_inSUIMNUFI)

                            If tblSujetoImpuesto12.Rows.Count = 0 Then
                                ' inserta sujeto de impuesto
                                pro_InsertarSujetoImpuesto()
                            End If

                        End If

                        ' inscribe predios de la vigencia actual 
                    ElseIf vl_boSUIMVIAC = True Then

                        ' concatena la cedula catastral actual
                        vl_stSUIMSUAC = vl_stSUIMDEPA & vl_stSUIMMUNI & vl_stSUIMCLSE & vl_stSUIMCORR & vl_stSUIMBARR & vl_stSUIMMANZ & vl_stSUIMPRED & vl_stSUIMEDIF & vl_stSUIMUNPR

                        ' concatena la cedula catastral anterior
                        vl_stSUIMSUAN = vl_stSUIMDEAN & vl_stSUIMMUAN & vl_stSUIMCSAN & vl_stSUIMCOAN & vl_stSUIMBAAN & vl_stSUIMMAAN & vl_stSUIMPRAN & vl_stSUIMEDAN & vl_stSUIMUPAN

                        ' remplaza el predio
                        If vl_boRemplazarTodosLosPredios = True Then

                            ' instancia la clase
                            Dim objSujetoImpuesto11 As New cla_SUJEIMPU
                            Dim tblSujetoImpuesto11 As New DataTable

                            tblSujetoImpuesto11 = objSujetoImpuesto11.fun_Consultar_SUJEIMPU_X_NRO_FICHA(vl_inSUIMNUFI)

                            If tblSujetoImpuesto11.Rows.Count > 0 Then

                                ' llena las variables
                                vl_stSUIMDEAN = vl_stSUIMDEPA
                                vl_stSUIMMUAN = vl_stSUIMMUNI
                                vl_stSUIMCOAN = vl_stSUIMCORR
                                vl_stSUIMBAAN = vl_stSUIMBARR
                                vl_stSUIMMAAN = vl_stSUIMMANZ
                                vl_stSUIMPRAN = vl_stSUIMPRED
                                vl_stSUIMEDAN = vl_stSUIMEDIF
                                vl_stSUIMUPAN = vl_stSUIMUNPR
                                vl_stSUIMCSAN = vl_stSUIMCLSE

                                vl_boSUIMPRRE = True

                                ' actualiza sujeto de impuesto
                                pro_ActualizarSujetoImpuesto()

                            Else

                                ' llena la variable
                                vl_boSUIMMANU = True
                                vl_boSUIMPRNU = True

                                ' inserta sujeto de impuesto
                                pro_InsertarSujetoImpuesto()

                            End If

                        ElseIf vl_boInscribirSoloPrediosNuevos = True Then

                            ' instancia la clase
                            Dim objSujetoImpuesto12 As New cla_SUJEIMPU
                            Dim tblSujetoImpuesto12 As New DataTable

                            tblSujetoImpuesto12 = objSujetoImpuesto12.fun_Consultar_SUJEIMPU_X_NRO_FICHA(vl_inSUIMNUFI)

                            If tblSujetoImpuesto12.Rows.Count = 0 Then

                                ' llena la variable
                                vl_boSUIMMANU = True
                                vl_boSUIMPRNU = True

                                ' inserta sujeto de impuesto
                                pro_InsertarSujetoImpuesto()
                            End If

                        End If

                    End If
                End If

            End If


        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_InsertarSujetoImpuesto()

        Try
            ' instancia la instancia
            Dim objSujetoImpuesto As New cla_SUJEIMPU

            If objSujetoImpuesto.fun_Insertar_SUJEIMPU(vl_inSUIMNUFI,
                                    Trim(vl_stSUIMSUAC), _
                                    Trim(vl_stSUIMSUAN), _
                                    Trim(vl_stSUIMDEPA), _
                                    Trim(vl_stSUIMMUNI), _
                                    Trim(vl_stSUIMCORR), _
                                    Trim(vl_stSUIMBARR), _
                                    Trim(vl_stSUIMMANZ), _
                                    Trim(vl_stSUIMPRED), _
                                    Trim(vl_stSUIMEDIF), _
                                    Trim(vl_stSUIMUNPR), _
                                    Trim(vl_stSUIMCLSE), _
                                    Trim(vl_stFIPRCAPR), _
                                    Trim(vl_stFIPRDIRE), _
                                    Trim(vl_stFIPRDESC), _
                                    Trim(vl_stSUIMVIAC), _
                                    Trim(vl_stSUIMVIAN), _
                                    Trim(vl_stSUIMMAIN), _
                                    vl_boSUIMPRNU, _
                                    vl_boSUIMPRCA, _
                                    vl_boSUIMMANU, _
                                    vl_boSUIMMACA, _
                                    Trim(vl_stSUIMNI01), _
                                    Trim(vl_stSUIMNI02), _
                                    Trim(vl_stSUIMNI03), _
                                    Trim(vl_stSUIMNI04), _
                                    Trim(vl_stSUIMNI05), _
                                    Trim(vl_stSUIMNI06), _
                                    Trim(vl_stSUIMNI07), _
                                    Trim(vl_stSUIMNI08), _
                                    Trim(vl_stSUIMNI09), _
                                    Trim(vl_stSUIMNI10), _
                                    Trim(vl_stSUIMNI11), _
                                    Trim(vl_stSUIMNI12), _
                                    Trim(vl_stSUIMNI13), _
                                    Trim(vl_stSUIMNI14), _
                                    Trim(vl_stSUIMNI15), _
                                    Trim(vl_stSUIMNI16), _
                                    Trim(vl_stSUIMNI17), _
                                    Trim(vl_stSUIMNI18), _
                                    Trim(vl_stSUIMNI19), _
                                    Trim(vl_stSUIMNI20), _
                                    Trim(vl_stSUIMNI21), _
                                    Trim(vl_stSUIMNI22), _
                                    Trim(vl_stSUIMNI23), _
                                    Trim(vl_stSUIMNI24), _
                                    Trim(vl_stSUIMNI25), _
                                    Trim(vl_stSUIMNI26), _
                                    Trim(vl_stSUIMNI27), _
                                    Trim(vl_stSUIMNI28), _
                                    Trim(vl_stSUIMNI29), _
                                    Trim(vl_stSUIMNI30), _
                                    Trim(vl_stFIPRESTA), _
                                    Trim(vl_stSUIMCOMU), _
                                    Trim(vl_stSUIMCOMA), _
                                    Trim(vl_stSUIMDEAN), _
                                    Trim(vl_stSUIMMUAN), _
                                    Trim(vl_stSUIMCOAN), _
                                    Trim(vl_stSUIMBAAN), _
                                    Trim(vl_stSUIMMAAN), _
                                    Trim(vl_stSUIMPRAN), _
                                    Trim(vl_stSUIMEDAN), _
                                    Trim(vl_stSUIMUPAN), _
                                    Trim(vl_stSUIMCSAN), _
                                    vl_inFIPRMOAD, _
                                    vl_boSUIMMEJO, _
                                    vl_boSUIMPRRE) = True Then

            Else
                mod_MENSAJE.No_Se_Modifico_El_Registro_En_La_Base_De_Datos()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_ActualizarSujetoImpuesto()

        Try
            ' instancia la instancia
            Dim objSujetoImpuesto As New cla_SUJEIMPU

            If objSujetoImpuesto.fun_Actualizar_NUFI_SUJEIMPU(vl_inSUIMNUFI,
                                                    Trim(vl_stSUIMSUAC), _
                                                    Trim(vl_stSUIMSUAN), _
                                                    Trim(vl_stSUIMDEPA), _
                                                    Trim(vl_stSUIMMUNI), _
                                                    Trim(vl_stSUIMCORR), _
                                                    Trim(vl_stSUIMBARR), _
                                                    Trim(vl_stSUIMMANZ), _
                                                    Trim(vl_stSUIMPRED), _
                                                    Trim(vl_stSUIMEDIF), _
                                                    Trim(vl_stSUIMUNPR), _
                                                    Trim(vl_stSUIMCLSE), _
                                                    Trim(vl_stFIPRCAPR), _
                                                    Trim(vl_stFIPRDIRE), _
                                                    Trim(vl_stFIPRDESC), _
                                                    Trim(vl_stSUIMVIAC), _
                                                    Trim(vl_stSUIMVIAN), _
                                                    Trim(vl_stSUIMMAIN), _
                                                    vl_boSUIMPRNU, _
                                                    vl_boSUIMPRCA, _
                                                    vl_boSUIMMANU, _
                                                    vl_boSUIMMACA, _
                                                    Trim(vl_stSUIMNI01), _
                                                    Trim(vl_stSUIMNI02), _
                                                    Trim(vl_stSUIMNI03), _
                                                    Trim(vl_stSUIMNI04), _
                                                    Trim(vl_stSUIMNI05), _
                                                    Trim(vl_stSUIMNI06), _
                                                    Trim(vl_stSUIMNI07), _
                                                    Trim(vl_stSUIMNI08), _
                                                    Trim(vl_stSUIMNI09), _
                                                    Trim(vl_stSUIMNI10), _
                                                    Trim(vl_stSUIMNI11), _
                                                    Trim(vl_stSUIMNI12), _
                                                    Trim(vl_stSUIMNI13), _
                                                    Trim(vl_stSUIMNI14), _
                                                    Trim(vl_stSUIMNI15), _
                                                    Trim(vl_stSUIMNI16), _
                                                    Trim(vl_stSUIMNI17), _
                                                    Trim(vl_stSUIMNI18), _
                                                    Trim(vl_stSUIMNI19), _
                                                    Trim(vl_stSUIMNI20), _
                                                    Trim(vl_stSUIMNI21), _
                                                    Trim(vl_stSUIMNI22), _
                                                    Trim(vl_stSUIMNI23), _
                                                    Trim(vl_stSUIMNI24), _
                                                    Trim(vl_stSUIMNI25), _
                                                    Trim(vl_stSUIMNI26), _
                                                    Trim(vl_stSUIMNI27), _
                                                    Trim(vl_stSUIMNI28), _
                                                    Trim(vl_stSUIMNI29), _
                                                    Trim(vl_stSUIMNI30), _
                                                    Trim(vl_stFIPRESTA), _
                                                    Trim(vl_stSUIMCOMU), _
                                                    Trim(vl_stSUIMCOMA), _
                                                    Trim(vl_stSUIMDEAN), _
                                                    Trim(vl_stSUIMMUAN), _
                                                    Trim(vl_stSUIMCOAN), _
                                                    Trim(vl_stSUIMBAAN), _
                                                    Trim(vl_stSUIMMAAN), _
                                                    Trim(vl_stSUIMPRAN), _
                                                    Trim(vl_stSUIMEDAN), _
                                                    Trim(vl_stSUIMUPAN), _
                                                    Trim(vl_stSUIMCSAN), _
                                                    vl_inFIPRMOAD, _
                                                    vl_boSUIMMEJO, _
                                                    vl_boSUIMPRRE) = True Then

            Else
                mod_MENSAJE.No_Se_Guardo_El_Registro_En_La_Base_De_Datos()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

End Module
