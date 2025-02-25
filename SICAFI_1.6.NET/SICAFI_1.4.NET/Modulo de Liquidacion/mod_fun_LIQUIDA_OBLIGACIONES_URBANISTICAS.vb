Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text
Imports System.Math

Module mod_fun_LIQUIDA_OBLIGACIONES_URBANISTICAS

    '=========================================
    '*** LIQUIDA OBLIGACIONES URBANISTICAS ***
    '=========================================

#Region "VARIABLES"

    Dim vl_inOBURIDRE As Integer = 0
    Dim vl_inOBURSECU As Integer = 0
    Dim vl_stOBURCLEN As String = ""
    Dim vl_inOBURNURE As Integer = 0
    Dim vl_stOBURFERE As String = ""
    Dim vl_inOBURCLOU As Integer = 0
    Dim vl_inOBURNULI As Integer = 0
    Dim vl_loOBURLIQU As Long = 0
    Dim vl_boOBURAJLI As Boolean = False

    Dim vl_loLIQUIDACION_DEFINITIVA As Long = 0

    Dim vl_loLIQUIDACION_CESI_EQUI_RESI_URBANO As Long = 0
    Dim vl_loLIQUIDACION_CESI_EQUI_OTRO_URBANO As Long = 0
    Dim vl_loLIQUIDACION_CESI_ESPU_RESI_URBANO As Long = 0
    Dim vl_loLIQUIDACION_CESI_ESPU_OTRO_URBANO As Long = 0
    Dim vl_loLIQUIDACION_DENS_ADIC_RESI_URBANO As Long = 0
    Dim vl_loLIQUIDACION_DENS_ADIC_OTRO_URBANO As Long = 0
    Dim vl_loLIQUIDACION_COMPENSAC_RESI_URBANO As Long = 0
    Dim vl_loLIQUIDACION_COMPENSAC_OTRO_URBANO As Long = 0

    Dim vl_loLIQUIDACION_CESI_EQUI_RESI_RURAL As Long = 0
    Dim vl_loLIQUIDACION_CESI_EQUI_OTRO_RURAL As Long = 0
    Dim vl_loLIQUIDACION_CESI_ESPU_RESI_RURAL As Long = 0
    Dim vl_loLIQUIDACION_CESI_ESPU_OTRO_RURAL As Long = 0

    Dim dt_OBURINGE As New DataTable

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable

#End Region

#Region "FUNCIONES"

    Private Function fun_LiquidaCesionEquipamientoResidencialUrbano() As Long

        Try
            'declara la variable
            Dim loValorLiquidado As Long = 0

            ' almacena el dato
            Dim inOUIGESSO As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGESSO"))
            Dim loOUIGATLO As Long = CInt(dt_OBURINGE.Rows(0).Item("OUIGATLO"))
            Dim inOUIGATCO As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGATCO"))
            Dim loOUIGSMLV As Long = CLng(dt_OBURINGE.Rows(0).Item("OUIGSMLV"))
            Dim inOUIGUNID As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGUNID"))
            Dim boOUIGPLPA As Integer = CBool(dt_OBURINGE.Rows(0).Item("OUIGPLPA"))

            ' instancia la clase
            Dim obCESIEQUI As New cla_CESIEQUI
            Dim dtCESIEQUI As New DataTable

            dtCESIEQUI = obCESIEQUI.fun_Consultar_MANT_CESIEQUI_X_ESTADO

            If dtCESIEQUI.Rows.Count > 0 Then

                Dim loOUIGUNDE As Double = 0
                Dim loOUIGEQSA As Double = 0

                ' declaro la variable
                Dim i As Integer = 0

                For i = 0 To dtCESIEQUI.Rows.Count - 1

                    If CInt(dtCESIEQUI.Rows(i).Item("CEEQESSO")) = CInt(inOUIGESSO) Then

                        loOUIGUNDE = CDbl(dtCESIEQUI.Rows(i).Item("CEEQUNDE"))
                        loOUIGEQSA = CDbl(dtCESIEQUI.Rows(i).Item("CEEQEQSA"))

                    End If

                Next

                ' verifica plan parcial
                If boOUIGPLPA = True Then

                    Dim loValor1 As Long = CLng(inOUIGATCO / loOUIGUNDE)
                    Dim loValor2 As Long = CLng(loValor1 * (loOUIGEQSA * loOUIGSMLV))

                    ' almacena la liquidacion
                    loValorLiquidado = CLng(loValor2)

                ElseIf boOUIGPLPA = False Then

                    ' almacena la liquidacion
                    loValorLiquidado = CLng((loOUIGEQSA * loOUIGSMLV) * inOUIGUNID)

                End If
             
            End If

            Return loValorLiquidado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Function
    Private Function fun_LiquidaCesionEquipamientoOtrosUsosUrbano() As Long

        Try
            'declara la variable
            Dim loValorLiquidado As Long = 0
            Dim loValorLiquidado_parcial_1 As Long = 0
            Dim loValorLiquidado_parcial_2 As Long = 0

            ' almacena la variable
            Dim inOUIGATCO As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGATCO"))
            Dim inOUIGUNID As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGUNID"))
            Dim inOUIGESSO As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGESSO"))
            Dim loOUIGSMLV As Long = CLng(dt_OBURINGE.Rows(0).Item("OUIGSMLV"))

            ' instancia la clase
            Dim obCESIEQUI As New cla_CESIEQUI
            Dim dtCESIEQUI As New DataTable

            dtCESIEQUI = obCESIEQUI.fun_Consultar_MANT_CESIEQUI_X_ESTADO

            If dtCESIEQUI.Rows.Count > 0 Then

                Dim loOUIGUNDE As Double = 0
                Dim loOUIGEQSA As Double = 0

                ' declaro la variable
                Dim i As Integer = 0

                For i = 0 To dtCESIEQUI.Rows.Count - 1

                    If CInt(dtCESIEQUI.Rows(i).Item("CEEQESSO")) = CInt(inOUIGESSO) Then

                        loOUIGUNDE = CDbl(dtCESIEQUI.Rows(i).Item("CEEQUNDE"))
                        loOUIGEQSA = CDbl(dtCESIEQUI.Rows(i).Item("CEEQEQSA"))

                    End If

                Next

                Dim deValorA As Decimal = ((inOUIGATCO * loOUIGUNDE) / 100)
                Dim deValorB As Decimal = (loOUIGEQSA * loOUIGSMLV) / (loOUIGUNDE)
                Dim deValorC As Decimal = (deValorA * deValorB)

                ' almacena la liquidacion - se retira por solicitud Mauricio 20-10-2016 y se incorpora 10-11-2016
                loValorLiquidado_parcial_1 = deValorC
                loValorLiquidado_parcial_2 = ((loOUIGEQSA * loOUIGSMLV) * inOUIGUNID)

                If loValorLiquidado_parcial_1 > loValorLiquidado_parcial_2 Then
                    loValorLiquidado = loValorLiquidado_parcial_1
                Else
                    loValorLiquidado = loValorLiquidado_parcial_2
                End If

            End If

            Return loValorLiquidado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

    Private Function fun_LiquidaCesionEspacioPublicoResidencialUrbano() As Long

        Try
            'declara la variable
            Dim loValorLiquidado As Long = 0
            Dim boLiquidaAvaluoCatastral As Boolean = False

            'declaro la variable
            Dim inOUIGUNID As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGUNID"))
            Dim inOUIGATLO As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGATLO"))
            Dim inOUIGUNID_C As Integer = 0
            Dim inOUIGDENS_C As Integer = 0
            Dim inOUIGOTUS_C As Integer = 0

            ' funcion totaliza unidades
            Dim inOUIGUNID_TOTAL As Integer = CInt(inOUIGUNID) + CInt(fun_SumatoriaUnidadesPorClaseDeObligacion(vl_inOBURSECU, vl_stOBURCLEN, vl_inOBURNURE, vl_stOBURFERE, vl_inOBURCLOU, "U"))

            ' instancia la clase
            Dim obOBURAVCO As New cla_OBURAVCO
            Dim dtOBURAVCO As New DataTable

            ' almacena el avaluo comercial
            dtOBURAVCO = obOBURAVCO.fun_Buscar_CODIGO_X_OBURAVCO(vl_stOBURCLEN, vl_inOBURNURE, vl_stOBURFERE)

            If dtOBURAVCO.Rows.Count = 0 Then
                boLiquidaAvaluoCatastral = True
            Else
                boLiquidaAvaluoCatastral = False
            End If

            ' menor a 5 unidades
            If (inOUIGUNID_TOTAL <= 5 And inOUIGATLO <= 300) And boLiquidaAvaluoCatastral = True Then

                ' declara la variable
                Dim loOUIGAVCA As Long = CLng(dt_OBURINGE.Rows(0).Item("OUIGAVCA"))

                ' almacena la liquidacion
                loValorLiquidado = (((loOUIGAVCA * 5) / 100) * inOUIGUNID)

            ElseIf inOUIGATLO > 300 Or boLiquidaAvaluoCatastral = False Then

                ' declara la variable
                Dim inOUIGDENS As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGDENS"))
                Dim inOUIGATCO As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGATCO"))
                Dim loOUIGACM2 As Long = CInt(dt_OBURINGE.Rows(0).Item("OUIGAVCO"))
                Dim inOUIGATCO_C As Integer = 0

                ' instancia la clase
                Dim obCESIESPU As New cla_CESIESPU
                Dim dtCESIESPU As New DataTable

                dtCESIESPU = obCESIESPU.fun_Consultar_MANT_CESIESPU_X_ESTADO

                If dtCESIESPU.Rows.Count > 0 Then

                    Dim inOUIGARCE As Integer = 0
                    Dim inOUIGOTUS As Integer = 0
                    Dim inOUIGAMCE As Integer = 0

                    ' declaro la variable
                    Dim i As Integer = 0

                    For i = 0 To dtCESIESPU.Rows.Count - 1

                        If CInt(dtCESIESPU.Rows(i).Item("CEEPDEVI")) = CInt(inOUIGDENS) Then

                            inOUIGARCE = CInt(dtCESIESPU.Rows(i).Item("CEEPARCE"))
                            inOUIGOTUS = CInt(dtCESIESPU.Rows(i).Item("CEEPOTUS"))
                            inOUIGAMCE = CInt(dtCESIESPU.Rows(i).Item("CEEPAMCE"))

                        End If

                    Next

                    ' si es mayor 100 mts2
                    If CInt(inOUIGATCO) > 100 Then

                        ' declaro las variables
                        Dim boExisteRegistroResicencial As Boolean = True
                        Dim boExisteRegistroOtrosUsos As Boolean = False

                        ' instancia la clase comercial
                        Dim obOBURINGE_C As New cla_OBURINGE
                        Dim dtOBURINGE_C As New DataTable

                        dtOBURINGE_C = obOBURINGE_C.fun_Consultar_Unidades_OBURINGE(vl_inOBURSECU, vl_stOBURCLEN, vl_inOBURNURE, vl_stOBURFERE, vl_inOBURCLOU, "U")

                        ' verifica existencia de registros
                        If dtOBURINGE_C.Rows.Count > 0 Then

                            inOUIGATCO_C = CInt(dtOBURINGE_C.Rows(0).Item("OUIGATCO"))
                            inOUIGUNID_C = CInt(dtOBURINGE_C.Rows(0).Item("OUIGUNID"))
                            inOUIGDENS_C = CInt(dtOBURINGE_C.Rows(0).Item("OUIGDENS"))

                            ' declaro la variable
                            Dim ii As Integer = 0

                            For ii = 0 To dtCESIESPU.Rows.Count - 1

                                If CInt(dtCESIESPU.Rows(ii).Item("CEEPDEVI")) = CInt(inOUIGDENS_C) Then
                                    inOUIGOTUS_C = CInt(dtCESIESPU.Rows(ii).Item("CEEPOTUS"))

                                End If

                            Next

                            boExisteRegistroOtrosUsos = True
                        End If

                        ' existe residencial y no otros usos
                        If boExisteRegistroResicencial = True And boExisteRegistroOtrosUsos = False Then

                            ' almacena las áreas
                            Dim inAreaLiquidacion_Parcial_1 As Integer = ((inOUIGATLO * inOUIGAMCE) / 100)
                            Dim inAreaLiquidacion_Parcial_R As Integer = (inOUIGARCE * inOUIGUNID)

                            ' obtiene mayor area
                            If inAreaLiquidacion_Parcial_1 > inAreaLiquidacion_Parcial_R Then
                                loValorLiquidado = (((inOUIGATLO * inOUIGAMCE) / 100) * loOUIGACM2)

                            ElseIf inAreaLiquidacion_Parcial_R > inAreaLiquidacion_Parcial_1 Then
                                loValorLiquidado = ((inOUIGARCE * inOUIGUNID) * loOUIGACM2)

                            End If

                            ' existe residencial y otros usos
                        ElseIf boExisteRegistroResicencial = True And boExisteRegistroOtrosUsos = True Then

                            ' declara la variable
                            Dim loResultadoFormula01 As Long = 0
                            Dim loResultadoFormula02 As Long = 0

                            ' almacena las áreas
                            Dim inAreaLiquidacion_Parcial_R_F01 As Integer = (inOUIGARCE * inOUIGUNID)
                            Dim inAreaLiquidacion_Parcial_C_F01 As Integer = (inOUIGOTUS_C * inOUIGUNID_C)

                            ' almacena la liquidacion
                            loResultadoFormula01 = ((inAreaLiquidacion_Parcial_R_F01 + inAreaLiquidacion_Parcial_C_F01) * loOUIGACM2)

                            ' almacena las áreas
                            Dim inAreaLiquidacion_Parcial_1_F02 As Integer = ((inOUIGATLO * inOUIGAMCE) / 100)
                            Dim inAreaLiquidacion_Parcial_R_F02 As Integer = (inOUIGARCE * inOUIGUNID)
                            Dim inAreaLiquidacion_Parcial_C_F02 As Integer = ((inOUIGOTUS * inOUIGATCO_C) / 100)

                            ' obtiene mayor area y liquida
                            If inAreaLiquidacion_Parcial_1_F02 > (inAreaLiquidacion_Parcial_R_F02 + inAreaLiquidacion_Parcial_C_F02) Then
                                loResultadoFormula02 = (((inOUIGATLO * inOUIGAMCE) / 100) * loOUIGACM2)

                            ElseIf (inAreaLiquidacion_Parcial_R_F02 + inAreaLiquidacion_Parcial_C_F02) > inAreaLiquidacion_Parcial_1_F02 Then
                                loResultadoFormula02 = ((inAreaLiquidacion_Parcial_R_F02 + inAreaLiquidacion_Parcial_C_F02) * loOUIGACM2)

                            End If

                            ' compara el valor de liquidacion maximo
                            If loResultadoFormula01 > loResultadoFormula02 Then
                                loValorLiquidado = loResultadoFormula01

                            ElseIf loResultadoFormula02 > loResultadoFormula01 Then
                                loValorLiquidado = loResultadoFormula02

                            End If

                            ' se divide debido que posee un registro residencial y otros usos
                            loValorLiquidado = (loValorLiquidado / 2)

                        End If

                        ' si es menor o igual a 100 mts2
                    ElseIf CInt(inOUIGATCO) <= 100 Then

                        ' almacena la liquidacion
                        loValorLiquidado = (inOUIGARCE * inOUIGUNID) * loOUIGACM2

                    End If


                End If

            End If

            Return loValorLiquidado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_LiquidaCesionEspacioPublicoOtrosUsosUrbano() As Long

        Try
            'declara la variable
            Dim loValorLiquidado As Long = 0
            Dim boLiquidaAvaluoCatastral As Boolean = False

            'declaro la variable
            Dim inOUIGUNID As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGUNID"))
            Dim inOUIGATLO As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGATLO"))
            Dim inOUIGATLO_R As Integer = 0
            Dim inOUIGARCE_R As Integer = 0
            Dim inOUIGUNID_R As Integer = 0
            Dim inOUIGDENS_R As Integer = 0

            ' funcion totaliza unidades
            Dim inOUIGUNID_TOTAL As Integer = CInt(inOUIGUNID) + CInt(fun_SumatoriaUnidadesPorClaseDeObligacion(vl_inOBURSECU, vl_stOBURCLEN, vl_inOBURNURE, vl_stOBURFERE, vl_inOBURCLOU, "R"))

            ' instancia la clase
            Dim obOBURAVCO As New cla_OBURAVCO
            Dim dtOBURAVCO As New DataTable

            ' almacena el avaluo comercial
            dtOBURAVCO = obOBURAVCO.fun_Buscar_CODIGO_X_OBURAVCO(vl_stOBURCLEN, vl_inOBURNURE, vl_stOBURFERE)

            If dtOBURAVCO.Rows.Count = 0 Then
                boLiquidaAvaluoCatastral = True
            Else
                boLiquidaAvaluoCatastral = False
            End If

            ' menor a 5 unidades
            If (inOUIGUNID_TOTAL <= 5 And inOUIGATLO <= 300) And boLiquidaAvaluoCatastral = True Then

                ' declara la variable
                Dim loOUIGAVCA As Long = CLng(dt_OBURINGE.Rows(0).Item("OUIGAVCA"))

                ' almacena la liquidacion
                loValorLiquidado = (((loOUIGAVCA * 5) / 100) * inOUIGUNID)

            ElseIf inOUIGATLO > 300 Or boLiquidaAvaluoCatastral = False Then

                ' almacena la variable
                Dim inOUIGATCO As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGATCO"))
                Dim loOUIGACM2 As Long = CInt(dt_OBURINGE.Rows(0).Item("OUIGAVCO"))
                Dim inOUIGDENS As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGDENS"))

                ' instancia la clase
                Dim obCESIESPU As New cla_CESIESPU
                Dim dtCESIESPU As New DataTable

                dtCESIESPU = obCESIESPU.fun_Consultar_MANT_CESIESPU_X_ESTADO

                If dtCESIESPU.Rows.Count > 0 Then

                    Dim inOUIGARCE As Integer = 0
                    Dim inOUIGOTUS As Integer = 0
                    Dim inOUIGAMCE As Integer = 0

                    ' declaro la variable
                    Dim i As Integer = 0

                    For i = 0 To dtCESIESPU.Rows.Count - 1

                        If CInt(dtCESIESPU.Rows(i).Item("CEEPDEVI")) = CInt(inOUIGDENS) Then

                            inOUIGARCE = CInt(dtCESIESPU.Rows(i).Item("CEEPARCE"))
                            inOUIGOTUS = CInt(dtCESIESPU.Rows(i).Item("CEEPOTUS"))
                            inOUIGAMCE = CInt(dtCESIESPU.Rows(i).Item("CEEPAMCE"))

                        End If

                    Next

                    ' si es mayor 100 mts2
                    If CInt(inOUIGATCO) > 100 Then

                        ' declaro las variables
                        Dim boExisteRegistroResicencial As Boolean = False
                        Dim boExisteRegistroOtrosUsos As Boolean = True

                        ' instancia la clase comercial
                        Dim obOBURINGE_R As New cla_OBURINGE
                        Dim dtOBURINGE_R As New DataTable

                        dtOBURINGE_R = obOBURINGE_R.fun_Consultar_Unidades_OBURINGE(vl_inOBURSECU, vl_stOBURCLEN, vl_inOBURNURE, vl_stOBURFERE, vl_inOBURCLOU, "R")

                        ' verifica existencia de registros
                        If dtOBURINGE_R.Rows.Count > 0 Then

                            ' almaceno los datos
                            inOUIGATLO_R = CInt(dtOBURINGE_R.Rows(0).Item("OUIGATLO"))
                            inOUIGUNID_R = CInt(dtOBURINGE_R.Rows(0).Item("OUIGUNID"))
                            inOUIGDENS_R = CInt(dtOBURINGE_R.Rows(0).Item("OUIGDENS"))

                            ' declaro la variable
                            Dim ii As Integer = 0

                            For ii = 0 To dtCESIESPU.Rows.Count - 1

                                If CInt(dtCESIESPU.Rows(ii).Item("CEEPDEVI")) = CInt(inOUIGDENS_R) Then
                                    inOUIGARCE_R = CInt(dtCESIESPU.Rows(ii).Item("CEEPARCE"))
                                End If

                            Next

                            boExisteRegistroResicencial = True
                        End If

                        ' existe otros usos y no residencial
                        If boExisteRegistroOtrosUsos = True And boExisteRegistroResicencial = False Then

                            ' almacena las áreas
                            Dim inAreaLiquidacion_Parcial_1 As Integer = ((inOUIGATLO * inOUIGAMCE) / 100)
                            Dim inAreaLiquidacion_Parcial_C As Integer = ((inOUIGOTUS * inOUIGATCO) / 100)

                            ' obtiene mayor area
                            If inAreaLiquidacion_Parcial_1 > inAreaLiquidacion_Parcial_C Then
                                loValorLiquidado = (((inOUIGATLO * inOUIGAMCE) / 100) * loOUIGACM2)

                            ElseIf inAreaLiquidacion_Parcial_C > inAreaLiquidacion_Parcial_1 Then
                                loValorLiquidado = (((inOUIGATCO * inOUIGOTUS) / 100) * loOUIGACM2)

                            End If

                            ' existe residencial y otros usos
                        ElseIf boExisteRegistroResicencial = True And boExisteRegistroOtrosUsos = True Then

                            ' declara la variable
                            Dim loResultadoFormula01 As Long = 0
                            Dim loResultadoFormula02 As Long = 0

                            ' almacena las áreas
                            Dim inAreaLiquidacion_Parcial_R_F01 As Integer = (inOUIGARCE_R * inOUIGUNID_R)
                            Dim inAreaLiquidacion_Parcial_C_F01 As Integer = (inOUIGOTUS * inOUIGUNID)

                            ' almacena la liquidacion
                            loResultadoFormula01 = ((inAreaLiquidacion_Parcial_R_F01 + inAreaLiquidacion_Parcial_C_F01) * loOUIGACM2)

                            ' almacena las áreas
                            Dim inAreaLiquidacion_Parcial_1_F02 As Integer = ((inOUIGATLO * inOUIGAMCE) / 100)
                            Dim inAreaLiquidacion_Parcial_R_F02 As Integer = (inOUIGARCE_R * inOUIGUNID_R)
                            Dim inAreaLiquidacion_Parcial_C_F02 As Integer = ((inOUIGOTUS * inOUIGATCO) / 100)

                            ' obtiene mayor area
                            If inAreaLiquidacion_Parcial_1_F02 > (inAreaLiquidacion_Parcial_R_F02 + inAreaLiquidacion_Parcial_C_F02) Then
                                loResultadoFormula02 = (((inOUIGATLO * inOUIGAMCE) / 100) * loOUIGACM2)

                            ElseIf (inAreaLiquidacion_Parcial_R_F02 + inAreaLiquidacion_Parcial_C_F02) > inAreaLiquidacion_Parcial_1_F02 Then
                                loResultadoFormula02 = ((inAreaLiquidacion_Parcial_R_F02 + inAreaLiquidacion_Parcial_C_F02) * loOUIGACM2)

                            End If

                            ' compara el valor de liquidacion maximo
                            If loResultadoFormula01 > loResultadoFormula02 Then
                                loValorLiquidado = loResultadoFormula01

                            ElseIf loResultadoFormula02 > loResultadoFormula01 Then
                                loValorLiquidado = loResultadoFormula02

                            End If

                            ' se divide debido que posee un registro residencial y otros usos
                            loValorLiquidado = (loValorLiquidado / 2)

                        End If

                        ' si es menor a 100 mts2
                    ElseIf CInt(inOUIGATCO) <= 100 Then

                        ' almacena la liquidacion
                        loValorLiquidado = (inOUIGOTUS * inOUIGUNID) * loOUIGACM2

                    End If

                End If

            End If

            Return loValorLiquidado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

    Private Function fun_LiquidaDensidadAdionalResidencialUrbano() As Long

        Try
            'declara la variable
            Dim loValorLiquidado As Long = 0

            ' almacena el dato
            Dim loOUIGACM2 As Long = CInt(dt_OBURINGE.Rows(0).Item("OUIGAVCO"))
            Dim inOUIGUNID As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGUNID"))
            Dim inOUIGDENS As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGDENS"))

            If inOUIGDENS <> 0 Then

                Dim deAreaXHe As Decimal = (10000 / inOUIGDENS)

                ' almacena la liquidacion
                loValorLiquidado = ((((deAreaXHe * inOUIGUNID) * loOUIGACM2) * 70) / 100)

            Else
                MessageBox.Show("La densidad se encuentra en cero", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

            Return loValorLiquidado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_LiquidaDensidadAdionalOtrosUsosUrbano() As Long

        Try
            'declara la variable
            Dim loValorLiquidado As Long = 0

            ' almacena el dato
            Dim loOUIGACM2 As Long = CInt(dt_OBURINGE.Rows(0).Item("OUIGAVCO"))
            Dim inOUIGUNID As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGUNID"))
            Dim inOUIGDENS As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGDENS"))

            If inOUIGDENS <> 0 Then

                Dim deAreaXHe As Decimal = (10000 / inOUIGDENS)
                Dim deAreaXHeXUnidad As Decimal = (deAreaXHe * inOUIGUNID)

                ' almacena la liquidacion
                loValorLiquidado = (((deAreaXHeXUnidad * loOUIGACM2) * 70) / 100)

            Else
                MessageBox.Show("La densidad se encuentra en cero", "Mensaje ...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If

            Return loValorLiquidado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

    Private Function fun_LiquidaCompensacionResidencialUrbano() As Long

        Try
            'declara la variable
            Dim loValorLiquidado As Long = 0

            ' almacena el dato
            Dim loOUIGSMLV As Long = CLng(dt_OBURINGE.Rows(0).Item("OUIGSMLV"))
            Dim inOUIGUNID As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGUNID"))

            ' almacena la liquidacion
            loValorLiquidado = ((12 * loOUIGSMLV) * inOUIGUNID)

            Return loValorLiquidado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_LiquidaCompensacionOtrosUsoslUrbano() As Long

        Try
            'declara la variable
            Dim loValorLiquidado As Long = 0

            ' almacena el dato
            Dim loOUIGSMLV As Long = CLng(dt_OBURINGE.Rows(0).Item("OUIGSMLV"))
            Dim inOUIGUNID As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGUNID"))

            ' almacena la liquidacion
            loValorLiquidado = ((12 * loOUIGSMLV) * inOUIGUNID)

            Return loValorLiquidado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

    Private Function fun_LiquidaCesionEquipamientoResidencialRural() As Long

        Try
            'declara la variable
            Dim loValorLiquidado As Long = 0

            ' almacena el dato
            Dim inOUIGUNID As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGUNID"))
            Dim loOUIGSMLV As Long = CLng(dt_OBURINGE.Rows(0).Item("OUIGSMLV"))

            Dim inMetroM2POT As Integer = 15
            Dim loUnidadesPorMetroM2 As Long = (inMetroM2POT * inOUIGUNID)

            loValorLiquidado = ((loOUIGSMLV * 2) * loUnidadesPorMetroM2)

            Return loValorLiquidado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Function
    Private Function fun_LiquidaCesionEquipamientoOtrosUsosRural() As Long

        Try
            'declara la variable
            Dim loValorLiquidado As Long = 0

            ' almacena el dato
            Dim inOUIGATCO As Integer = CInt(dt_OBURINGE.Rows(0).Item("OUIGATCO"))
            Dim loOUIGSMLV As Long = CLng(dt_OBURINGE.Rows(0).Item("OUIGSMLV"))

            loValorLiquidado = (((15 * inOUIGATCO) / 100) * (loOUIGSMLV * 2))

            Return loValorLiquidado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Function

    Private Function fun_LiquidaCesionEspacioPublicoResidencialRural() As Long

        Try
            'declara la variable
            Dim loValorLiquidado As Long = 0

            ' almacena el dato
            Dim loOUIGATLO As Long = CInt(dt_OBURINGE.Rows(0).Item("OUIGATLO"))
            Dim loOUIGACM2 As Long = CInt(dt_OBURINGE.Rows(0).Item("OUIGAVCO"))

            loValorLiquidado = (((loOUIGATLO * 15) / 100) * loOUIGACM2)

            Return loValorLiquidado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Function
    Private Function fun_LiquidaCesionEspacioPublicoOtrosUsosRural() As Long

        Try
            'declara la variable
            Dim loValorLiquidado As Long = 0

            ' almacena el dato
            Dim loOUIGATLO As Long = CInt(dt_OBURINGE.Rows(0).Item("OUIGATLO"))
            Dim loOUIGACM2 As Long = CInt(dt_OBURINGE.Rows(0).Item("OUIGAVCO"))

            loValorLiquidado = (((loOUIGATLO * 15) / 100) * loOUIGACM2)

            Return loValorLiquidado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Function

    Private Function fun_SumatoriaUnidadesPorClaseDeObligacion(ByVal inOUIGSECU As Integer, _
                                                               ByVal stOUIGCLEN As String, _
                                                               ByVal inOUIGNURE As Integer, _
                                                               ByVal stOUIGFERE As String, _
                                                               ByVal inOUIGCLOU As Integer, _
                                                               ByVal stOUIGTIPO As String) As Integer

        Try
            ' declaro la variable
            Dim inTotalUnidades As Integer = 0

            ' instancia la clase
            Dim obOBURINGE As New cla_OBURINGE
            Dim dtOBURINGE_1 As New DataTable
            Dim dtOBURINGE_2 As New DataTable

            dtOBURINGE_1 = obOBURINGE.fun_Consultar_Unidades_OBURINGE(inOUIGSECU, stOUIGCLEN, inOUIGNURE, stOUIGFERE, inOUIGCLOU, stOUIGTIPO)

            If dtOBURINGE_1.Rows.Count > 0 Then

                dtOBURINGE_2 = obOBURINGE.fun_Consultar_Sumatoria_Unidades_OBURINGE(inOUIGSECU, stOUIGCLEN, inOUIGNURE, stOUIGFERE, inOUIGCLOU, stOUIGTIPO)

                If dtOBURINGE_2.Rows.Count > 0 Then

                    inTotalUnidades = CInt(dtOBURINGE_2.Rows(0).Item("TOTAL"))

                End If

            End If

            Return inTotalUnidades

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Private Function fun_ConsultaAreaConstruccionEspacioPublicoOtrosUsos(ByVal inOUIGSECU As Integer, _
                                                                         ByVal stOUIGCLEN As String, _
                                                                         ByVal inOUIGNURE As Integer, _
                                                                         ByVal stOUIGFERE As String, _
                                                                         ByVal inOUIGCLOU As Integer, _
                                                                         ByVal stOUIGTIPO As String) As Integer

        Try
            ' declaro la variable
            Dim inAreaConstruccion As Integer = 0

            ' instancia la clase
            Dim obOBURINGE As New cla_OBURINGE
            Dim dtOBURINGE As New DataTable

            dtOBURINGE = obOBURINGE.fun_Consultar_Unidades_OBURINGE(inOUIGSECU, stOUIGCLEN, inOUIGNURE, stOUIGFERE, inOUIGCLOU, stOUIGTIPO)

            If dtOBURINGE.Rows.Count > 0 Then

                inAreaConstruccion = CInt(dtOBURINGE.Rows(0).Item("OUIGATCO"))

            End If

            Return inAreaConstruccion

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

#Region "PROCEDIMIENTOS"

    Public Sub pro_LIQUIDA_OBLIGACIONES_URBANISTICAS(ByVal o_inOBURSECU As Integer, _
                                                     ByVal o_stOBURCLEN As String, _
                                                     ByVal o_inOBURNURE As Integer, _
                                                     ByVal o_stOBURFERE As String, _
                                                     ByVal o_inOBURCLOU As Integer, _
                                                     ByVal o_inOBURNULI As Integer, _
                                                     ByVal o_boOBURAJLI As Boolean)

        ' declara las variables
        vl_inOBURSECU = o_inOBURSECU
        vl_stOBURCLEN = o_stOBURCLEN
        vl_inOBURNURE = o_inOBURNURE
        vl_stOBURFERE = o_stOBURFERE
        vl_inOBURCLOU = o_inOBURCLOU
        vl_inOBURNULI = o_inOBURNULI
        vl_boOBURAJLI = o_boOBURAJLI

        ' cargar informacion general
        pro_ConsultarTablaInformacionGeneral()

        ' verifica los datos
        If dt_OBURINGE.Rows.Count > 0 Then

            ' verifica no poseen ajuste de liquidacion
            If vl_boOBURAJLI = False Then

                ' liquida equipamiento colectivo
                If CInt(vl_inOBURCLOU) = 1 Then

                    ' liquidacion residencia
                    If CInt(dt_OBURINGE.Rows(0).Item("OUIGCLSE")) = 1 Then
                        If Trim(dt_OBURINGE.Rows(0).Item("OUIGTIPO")) = "R" Then

                            ' liquida cesion equipamiento 
                            vl_loLIQUIDACION_CESI_EQUI_RESI_URBANO = fun_LiquidaCesionEquipamientoResidencialUrbano()
                            vl_loLIQUIDACION_DEFINITIVA = vl_loLIQUIDACION_CESI_EQUI_RESI_URBANO

                            ' liquida otros usos
                        ElseIf Trim(dt_OBURINGE.Rows(0).Item("OUIGTIPO")) = "U" Then

                            ' liquida cesion equipamiento 
                            vl_loLIQUIDACION_CESI_EQUI_OTRO_URBANO = fun_LiquidaCesionEquipamientoOtrosUsosUrbano()
                            vl_loLIQUIDACION_DEFINITIVA = vl_loLIQUIDACION_CESI_EQUI_OTRO_URBANO

                        End If
                    End If

                    ' sector rural
                    If CInt(dt_OBURINGE.Rows(0).Item("OUIGCLSE")) = 2 Then
                        If Trim(dt_OBURINGE.Rows(0).Item("OUIGTIPO")) = "R" Then

                            ' liquida cesion equipamiento 
                            vl_loLIQUIDACION_CESI_EQUI_RESI_RURAL = fun_LiquidaCesionEquipamientoResidencialRural()
                            vl_loLIQUIDACION_DEFINITIVA = vl_loLIQUIDACION_CESI_EQUI_RESI_RURAL

                            ' liquida otros usos
                        ElseIf Trim(dt_OBURINGE.Rows(0).Item("OUIGTIPO")) = "U" Then

                            ' liquida cesion equipamiento 
                            vl_loLIQUIDACION_CESI_EQUI_OTRO_RURAL = fun_LiquidaCesionEquipamientoOtrosUsosRural()
                            vl_loLIQUIDACION_DEFINITIVA = vl_loLIQUIDACION_CESI_EQUI_OTRO_RURAL

                        End If
                    End If
                End If

                ' liquida espacio publico
                If CInt(vl_inOBURCLOU) = 2 Then

                    ' liquidacion residencia
                    If CInt(dt_OBURINGE.Rows(0).Item("OUIGCLSE")) = 1 Then
                        If Trim(dt_OBURINGE.Rows(0).Item("OUIGTIPO")) = "R" Then

                            ' liquida cesion equipamiento residencial
                            vl_loLIQUIDACION_CESI_ESPU_RESI_URBANO = fun_LiquidaCesionEspacioPublicoResidencialUrbano()
                            vl_loLIQUIDACION_DEFINITIVA = vl_loLIQUIDACION_CESI_ESPU_RESI_URBANO

                            ' liquida otros usos
                        ElseIf Trim(dt_OBURINGE.Rows(0).Item("OUIGTIPO")) = "U" Then

                            ' liquida cesion equipamiento otros usos
                            vl_loLIQUIDACION_CESI_ESPU_OTRO_URBANO = fun_LiquidaCesionEspacioPublicoOtrosUsosUrbano()
                            vl_loLIQUIDACION_DEFINITIVA = vl_loLIQUIDACION_CESI_ESPU_OTRO_URBANO

                        End If
                    End If


                    ' liquidacion residencia
                    If CInt(dt_OBURINGE.Rows(0).Item("OUIGCLSE")) = 2 Then
                        If Trim(dt_OBURINGE.Rows(0).Item("OUIGTIPO")) = "R" Then

                            ' liquida cesion equipamiento residencial
                            vl_loLIQUIDACION_CESI_ESPU_RESI_RURAL = fun_LiquidaCesionEspacioPublicoResidencialRural()
                            vl_loLIQUIDACION_DEFINITIVA = vl_loLIQUIDACION_CESI_ESPU_RESI_RURAL

                            ' liquida otros usos
                        ElseIf Trim(dt_OBURINGE.Rows(0).Item("OUIGTIPO")) = "U" Then

                            ' liquida cesion equipamiento otros usos
                            vl_loLIQUIDACION_CESI_ESPU_OTRO_RURAL = fun_LiquidaCesionEspacioPublicoOtrosUsosRural()
                            vl_loLIQUIDACION_DEFINITIVA = vl_loLIQUIDACION_CESI_ESPU_OTRO_RURAL

                        End If
                    End If
                End If

                ' liquida densidad adional
                If CInt(vl_inOBURCLOU) = 5 Then

                    ' liquidacion residencia
                    If CInt(dt_OBURINGE.Rows(0).Item("OUIGCLSE")) = 1 Then
                        If Trim(dt_OBURINGE.Rows(0).Item("OUIGTIPO")) = "R" Then

                            ' liquida cesion equipamiento residencial
                            vl_loLIQUIDACION_DENS_ADIC_RESI_URBANO = fun_LiquidaDensidadAdionalResidencialUrbano()
                            vl_loLIQUIDACION_DEFINITIVA = vl_loLIQUIDACION_DENS_ADIC_RESI_URBANO

                            ' liquida otros usos
                        ElseIf Trim(dt_OBURINGE.Rows(0).Item("OUIGTIPO")) = "U" Then

                            ' liquida cesion equipamiento otros usos
                            vl_loLIQUIDACION_DENS_ADIC_OTRO_URBANO = fun_LiquidaDensidadAdionalOtrosUsosUrbano()
                            vl_loLIQUIDACION_DEFINITIVA = vl_loLIQUIDACION_DENS_ADIC_OTRO_URBANO
                        End If

                    End If

                End If

                ' liquida compensacion
                If CInt(vl_inOBURCLOU) = 6 Then

                    ' liquidacion residencia
                    If CInt(dt_OBURINGE.Rows(0).Item("OUIGCLSE")) = 1 Then
                        If Trim(dt_OBURINGE.Rows(0).Item("OUIGTIPO")) = "R" Then

                            ' liquida cesion equipamiento residencial
                            vl_loLIQUIDACION_COMPENSAC_RESI_URBANO = fun_LiquidaCompensacionResidencialUrbano()
                            vl_loLIQUIDACION_DEFINITIVA = vl_loLIQUIDACION_COMPENSAC_RESI_URBANO

                            ' liquida otros usos
                        ElseIf Trim(dt_OBURINGE.Rows(0).Item("OUIGTIPO")) = "U" Then

                            ' liquida cesion equipamiento otros usos
                            vl_loLIQUIDACION_COMPENSAC_OTRO_URBANO = fun_LiquidaCompensacionOtrosUsoslUrbano()
                            vl_loLIQUIDACION_DEFINITIVA = vl_loLIQUIDACION_COMPENSAC_OTRO_URBANO
                        End If

                    End If

                End If

                ' ejecuta procesos 
                pro_GuardarTablaInformacionGeneral()
                pro_MarcarFechaDeLiquidacion(vl_inOBURSECU)
                pro_MarcarGrandesContribuyentes(vl_inOBURSECU)

            End If

        Else
            mod_MENSAJE.No_Se_Encontro_Ningun_registro()
        End If

    End Sub

    Private Sub pro_ConsultarTablaInformacionGeneral()

        Try
            ' instancia la clase
            Dim obOBURINGE As New cla_OBURINGE
            dt_OBURINGE = New DataTable

            dt_OBURINGE = obOBURINGE.fun_Buscar_INFO_GENE_X_OBURINGE(vl_inOBURSECU, vl_stOBURCLEN, vl_inOBURNURE, vl_stOBURFERE, vl_inOBURCLOU, vl_inOBURNULI)

            If dt_OBURINGE.Rows.Count > 0 Then
                vl_inOBURIDRE = CInt(dt_OBURINGE.Rows(0).Item("OUIGIDRE"))
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_GuardarTablaInformacionGeneral()

        Try
            ' instancia la clase
            Dim obOUIGINGE_1 As New cla_OBURINGE

            obOUIGINGE_1.fun_Actualizar_OBURINGE(vl_inOBURIDRE, _
                                                 vl_inOBURSECU, _
                                                 vl_stOBURCLEN, _
                                                 vl_inOBURNURE, _
                                                 vl_stOBURFERE, _
                                                 vl_inOBURCLOU, _
                                                 vl_inOBURNULI, _
                                                 vl_loLIQUIDACION_DEFINITIVA)

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_MarcarFechaDeLiquidacion(ByVal inOBURSECU As Integer)

        Try

            ' buscar cadena de conexion
            Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
            Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

            ' crear conexión
            oAdapter = New SqlDataAdapter
            oConexion = New SqlConnection(stCadenaConexion)

            ' declara la variable
            Dim stOBURFELI As String = fun_fecha()

            ' abre la conexion
            oConexion.Open()

            ' parametros de la consulta
            Dim ParametrosConsulta As String = ""

            ' Concatena la condicion de la consulta
            ParametrosConsulta += "Update OBLIURBA "
            ParametrosConsulta += "Set OBURFELI = '" & CStr(Trim(stOBURFELI)) & "' "
            ParametrosConsulta += "Where OBURSECU = '" & CInt(inOBURSECU) & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text

            oReader = oEjecutar.ExecuteReader

            ' cierra la conexion
            oConexion.Close()
            oReader = Nothing

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_MarcarGrandesContribuyentes(ByVal inOBURSECU As Integer)

        Try
            ' declara la variable
            Dim inUnidadesTotales As Integer = 0

            ' instancia la clase
            Dim obOBURINGE As New cla_OBURINGE
            Dim dtOBURINGE As New DataTable

            dtOBURINGE = obOBURINGE.fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURINGE(vl_inOBURSECU)

            If dtOBURINGE.Rows.Count > 0 Then

                ' declaro las variables
                Dim inUnidadesEquipamiento As Integer = 0
                Dim inUnidadesEspacioPublico As Integer = 0

                ' declaro la variable
                Dim ii As Integer = 0

                For ii = 0 To dtOBURINGE.Rows.Count - 1

                    If CInt(dtOBURINGE.Rows(ii).Item("OUIGCLOU")) = 2 Then
                        inUnidadesEspacioPublico += CInt(dtOBURINGE.Rows(ii).Item("OUIGUNID"))
                        inUnidadesTotales = inUnidadesEspacioPublico
                    End If

                Next

                If inUnidadesEspacioPublico = 0 Then

                    ' declaro la variable
                    Dim i As Integer = 0

                    For i = 0 To dtOBURINGE.Rows.Count - 1

                        If CInt(dtOBURINGE.Rows(i).Item("OUIGCLOU")) = 1 Then
                            inUnidadesEquipamiento += CInt(dtOBURINGE.Rows(i).Item("OUIGUNID"))
                            inUnidadesTotales = inUnidadesEquipamiento
                        End If

                    Next

                End If

            End If

            ' declara la variable
            Dim boOBURGRCO As Boolean = False

            ' grandes contribuyentes
            If inUnidadesTotales <= 5 Then
                boOBURGRCO = False
            ElseIf inUnidadesTotales > 5 Then
                boOBURGRCO = True
            End If

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
            ParametrosConsulta += "Update OBLIURBA "
            ParametrosConsulta += "Set OBURGRCO = '" & CBool(boOBURGRCO) & "' "
            ParametrosConsulta += "Where OBURSECU = '" & CInt(inOBURSECU) & "' "

            ' ejecuta la consulta
            oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

            ' procesa la consulta 
            oEjecutar.CommandTimeout = 0
            oEjecutar.CommandType = CommandType.Text

            oReader = oEjecutar.ExecuteReader

            ' cierra la conexion
            oConexion.Close()
            oReader = Nothing

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

#End Region

End Module
