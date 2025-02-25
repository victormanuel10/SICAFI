Imports DATOS
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text
Public Class cla_ValidarFichaPredial

    '================================
    '*** VALIDACION FICHA PREDIAL ***
    '================================

#Region "VARIABLES"

#Region "Tablas"

    ' Tabla 0
    Private dt_FICHPRED As New DataTable
    ' Tabla 1
    Private dt_FIPRDEEC As New DataTable
    ' Tabla 2
    Private dt_FIPRPROP As New DataTable
    ' Tabla 3
    Private dt_FIPRCONS As New DataTable
    ' Tabla 4
    Private dt_FIPRCACO As New DataTable
    ' Tabla 5
    Private dt_FIPRLIND As New DataTable
    ' Tabla 6
    Private dt_FIPRCART As New DataTable
    ' Tabla 7
    Private dt_FIPRZOEC As New DataTable
    ' Tabla 8
    Private dt_FIPRZOFI As New DataTable

#End Region

#Region "Ficha Predial"

    Private stFIPRNUFI As String

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

#Region "PROCEDIMIENTOS"

#Region "Validar Ficha Predial"

    Public Sub pro_VALIDAR_FICHA_PREDIAL(ByVal o_stFIPRNUFI As Integer)

        Try

            stFIPRNUFI = o_stFIPRNUFI

            ' Elimina las inconsistencias
            Dim objdatos As New cla_VALIFIPR

            objdatos.fun_Elimina_FIPRINCO(Trim(o_stFIPRNUFI))

            ' Carga las tablas
            pro_CargarTablasFichaPredial()

            ' Valida las tablas
            pro_ValidarFichPred()
            pro_ValidarFiprDeec()
            pro_ValidarFiprProp()
            pro_ValidarFiprCons()
            pro_ValidarFiprCaco()
            pro_ValidarFiprLind()
            'pro_ValidarFiprCart()
            'pro_ValidarFiprZoec()
            'pro_ValidarFiprZofi()

            Dim objdatos1 As New cla_VALIFIPR
            Dim tbl1 As New DataTable

            tbl1 = objdatos1.fun_Consultar_INCONSISTENCIA_X_FICHA_PREDIAL(Trim(stFIPRNUFI))

            If tbl1.Rows.Count > 0 Then

                ' buscar cadena de conexion
                Dim oCadenaConexion As New REGLAS_DEL_NEGOCIO.cla_ConnectionString
                Dim stCadenaConexion As String = oCadenaConexion.fun_ConnectionString

                ' crear conexión
                oAdapter = New SqlDataAdapter
                oConexion = New SqlConnection(stCadenaConexion)

                ' abre la conexion
                oConexion.Open()

                ' variables
                Dim byFIPRINCO As Byte = 1

                ' parametros de la consulta
                Dim ParametrosConsulta As String = ""

                ' Concatena la condicion de la consulta
                ParametrosConsulta += "update FICHPRED "
                ParametrosConsulta += "set FIPRINCO = '" & byFIPRINCO & "' "
                ParametrosConsulta += "where FIPRNUFI = '" & stFIPRNUFI & "'"

                ' ejecuta la consulta
                oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                ' procesa la consulta 
                oEjecutar.CommandTimeout = 360
                oEjecutar.CommandType = CommandType.Text
                oReader = oEjecutar.ExecuteReader

                ' cierra la conexion
                oConexion.Close()
                oReader = Nothing

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "Validar ficha predial")
        End Try

    End Sub

#End Region

#Region "Cargar Tablas Ficha Predial"

    Private Sub pro_CargarTablasFichaPredial()

        Dim objdatos As New cla_VALIFIPR
        Dim ds As New DataSet

        ds = objdatos.fun_Consultar_TABLAS_FICHA_PREDIAL(stFIPRNUFI)

        ' Tabla 0
        dt_FICHPRED = ds.Tables(0)
        ' Tabla 1
        dt_FIPRDEEC = ds.Tables(1)
        ' Tabla 2
        dt_FIPRPROP = ds.Tables(2)
        ' Tabla 3
        dt_FIPRCONS = ds.Tables(3)
        ' Tabla 4
        dt_FIPRCACO = ds.Tables(4)
        ' Tabla 5
        dt_FIPRLIND = ds.Tables(5)
        ' Tabla 6
        'dt_FIPRCART = ds.Tables(6)
        ' Tabla 7
        'dt_FIPRZOEC = ds.Tables(7)
        ' Tabla 8
        'dt_FIPRZOFI = ds.Tables(8)

    End Sub
    Private Sub pro_GrabarInconsistencia(ByVal stCODIGO As String, ByVal stDESCRIPCION As String)

        Dim objdatos1 As New cla_VALIFIPR

        objdatos1.fun_Insertar_FIPRINCO(stFIPRNUFI, _
                                        stCODIGO, _
                                        stDESCRIPCION, _
                                        dt_FICHPRED.Rows(0).Item("FIPRMUNI"), _
                                        dt_FICHPRED.Rows(0).Item("FIPRCORR"), _
                                        dt_FICHPRED.Rows(0).Item("FIPRBARR"), _
                                        dt_FICHPRED.Rows(0).Item("FIPRMANZ"), _
                                        dt_FICHPRED.Rows(0).Item("FIPRPRED"), _
                                        dt_FICHPRED.Rows(0).Item("FIPREDIF"), _
                                        dt_FICHPRED.Rows(0).Item("FIPRUNPR"), _
                                        dt_FICHPRED.Rows(0).Item("FIPRCLSE"))
    End Sub

#End Region

#Region "Validar FichPred"

    Private Sub pro_ValidarFichPred()

        Try
            ' Inconsistencias de ficha predial
            pro_Inconsistencia_105()
            pro_Inconsistencia_106()
            pro_Inconsistencia_107()
            pro_Inconsistencia_108()
            pro_Inconsistencia_109()
            pro_Inconsistencia_112()
            pro_Inconsistencia_113()
            pro_Inconsistencia_114()
            pro_Inconsistencia_115()
            pro_Inconsistencia_116()
            pro_Inconsistencia_117()
            pro_Inconsistencia_118()
            pro_Inconsistencia_119()
            pro_Inconsistencia_120()
            pro_Inconsistencia_121()
            pro_Inconsistencia_122()
            pro_Inconsistencia_123()
            pro_Inconsistencia_124()
            pro_Inconsistencia_130()
            pro_Inconsistencia_131()
            pro_Inconsistencia_133()
            pro_Inconsistencia_134()
            pro_Inconsistencia_135()
            pro_Inconsistencia_136()
            pro_Inconsistencia_137()
            pro_Inconsistencia_138()
            pro_Inconsistencia_139()
            pro_Inconsistencia_140()
            pro_Inconsistencia_142()
            pro_Inconsistencia_143()
            pro_Inconsistencia_144()
            pro_Inconsistencia_145()
            pro_Inconsistencia_146()

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Ficha Predial")
        End Try

    End Sub

    Private Sub pro_Inconsistencia_105()
        Dim inconsistencia As String = "Terreno en cero para ficha que no es mejora"
        Dim codigo As String = "105"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRARTE") = 0 And dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer
                    Dim boFPCOMEJO As Boolean
                    Dim stFPCOUNID As String

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        boFPCOMEJO = dt_FIPRCONS.Rows(i).Item("FPCOMEJO")
                        stFPCOUNID = dt_FIPRCONS.Rows(i).Item("FPCOUNID")

                        If boFPCOMEJO = False Then

                            pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & stFPCOUNID)

                        End If

                    Next

                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_106()
        Dim inconsistencia As String = "Ficha es de mejora con área de terreno"
        Dim codigo As String = "106"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRARTE") > 0 And dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer
                    Dim boFPCOMEJO As Boolean
                    Dim stFPCOUNID As String

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        boFPCOMEJO = dt_FIPRCONS.Rows(i).Item("FPCOMEJO")
                        stFPCOUNID = dt_FIPRCONS.Rows(i).Item("FPCOUNID")

                        If boFPCOMEJO = True Then

                            pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & stFPCOUNID)

                        End If

                    Next

                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_107()
        Dim inconsistencia As String = "Abreviatura invalidad para la dirección."
        Dim codigo As String = "107"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 3 Then
            If dt_FICHPRED.Rows(0).Item("FIPRDIRE").ToString.Substring(0, 3) <> "AV " Then
                If dt_FICHPRED.Rows(0).Item("FIPRDIRE").ToString.Substring(0, 4) <> "CIR " Then
                    If dt_FICHPRED.Rows(0).Item("FIPRDIRE").ToString.Substring(0, 3) <> "CL " Then
                        If dt_FICHPRED.Rows(0).Item("FIPRDIRE").ToString.Substring(0, 3) <> "CR " Then
                            If dt_FICHPRED.Rows(0).Item("FIPRDIRE").ToString.Substring(0, 5) <> "CRVN " Then
                                If dt_FICHPRED.Rows(0).Item("FIPRDIRE").ToString.Substring(0, 3) <> "DG " Then
                                    If dt_FICHPRED.Rows(0).Item("FIPRDIRE").ToString.Substring(0, 3) <> "TV " Then

                                        pro_GrabarInconsistencia(codigo, inconsistencia & " " & dt_FICHPRED.Rows(0).Item("FIPRDIRE").ToString.Substring(0, 3))

                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub pro_Inconsistencia_108()
        Dim inconsistencia As String = "Edificio en cero para caracteristica de predio"
        Dim codigo As String = "108"

        If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
           dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
           dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then
            If Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")) = "000" Then

                pro_GrabarInconsistencia(codigo, inconsistencia & " " & dt_FICHPRED.Rows(0).Item("FIPRCAPR"))

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_109()
        Dim inconsistencia As String = "Unidad predial en cero para caracteristica de predio"
        Dim codigo As String = "109"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then
                If Trim(dt_FICHPRED.Rows(0).Item("FIPRUNPR")) = "00000" Then

                    pro_GrabarInconsistencia(codigo, inconsistencia & " " & dt_FICHPRED.Rows(0).Item("FIPRCAPR"))

                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_112()
        Dim inconsistencia As String = "Coeficiente de edificio diferente al 100 %"
        Dim codigo As String = "112"

        Try


            If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                    ' declaro variables
                    Dim stFIPRMUNI As String = dt_FICHPRED.Rows(0).Item("FIPRMUNI")
                    Dim stFIPRCORR As String = dt_FICHPRED.Rows(0).Item("FIPRCORR")
                    Dim stFIPRBARR As String = dt_FICHPRED.Rows(0).Item("FIPRBARR")
                    Dim stFIPRMANZ As String = dt_FICHPRED.Rows(0).Item("FIPRMANZ")
                    Dim stFIPRPRED As String = dt_FICHPRED.Rows(0).Item("FIPRPRED")
                    Dim stFIPREDIF As String = dt_FICHPRED.Rows(0).Item("FIPREDIF")
                    Dim stFIPRCAPR As String = dt_FICHPRED.Rows(0).Item("FIPRCAPR")
                    Dim stFIPRCLSE As String = dt_FICHPRED.Rows(0).Item("FIPRCLSE")
                    Dim stFIPRESTA As String = dt_FICHPRED.Rows(0).Item("FIPRESTA")

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
                    ParametrosConsulta += "FiprCoed "
                    ParametrosConsulta += "From FichPred where "
                    ParametrosConsulta += "FiprClse = '" & stFIPRCLSE & "' and "
                    ParametrosConsulta += "FiprMuni = '" & stFIPRMUNI & "' and "
                    ParametrosConsulta += "FiprCorr = '" & stFIPRCORR & "' and "
                    ParametrosConsulta += "FiprBarr = '" & stFIPRBARR & "' and "
                    ParametrosConsulta += "FiprManz = '" & stFIPRMANZ & "' and "
                    ParametrosConsulta += "FiprPred = '" & stFIPRPRED & "' and "
                    ParametrosConsulta += "FiprEdif = '" & stFIPREDIF & "' and "
                    ParametrosConsulta += "FiprEsta = '" & stFIPRESTA & "' and "
                    ParametrosConsulta += "FiprCapr = '" & stFIPRCAPR & "'"

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

                    Dim h As Integer
                    Dim doTotal As Double

                    ' suma el coeficiente de edificio
                    For h = 0 To dt.Rows.Count - 1
                        doTotal += CType(Trim(dt.Rows(h).Item(0)), Double)
                    Next

                    If doTotal <> 100 Then

                        pro_GrabarInconsistencia(codigo, inconsistencia & " total: " & doTotal)

                    End If

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo)
        End Try

    End Sub
    Private Sub pro_Inconsistencia_113()
        Dim inconsistencia As String = "Coeficiente de predio diferente al 100 %"
        Dim codigo As String = "113"

        Try

            If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                    ' declaro variables
                    Dim stFIPRMUNI As String = dt_FICHPRED.Rows(0).Item("FIPRMUNI")
                    Dim stFIPRCORR As String = dt_FICHPRED.Rows(0).Item("FIPRCORR")
                    Dim stFIPRBARR As String = dt_FICHPRED.Rows(0).Item("FIPRBARR")
                    Dim stFIPRMANZ As String = dt_FICHPRED.Rows(0).Item("FIPRMANZ")
                    Dim stFIPRPRED As String = dt_FICHPRED.Rows(0).Item("FIPRPRED")
                    Dim stFIPREDIF As String = dt_FICHPRED.Rows(0).Item("FIPREDIF")
                    Dim stFIPRCAPR As String = dt_FICHPRED.Rows(0).Item("FIPRCAPR")
                    Dim stFIPRCLSE As String = dt_FICHPRED.Rows(0).Item("FIPRCLSE")
                    Dim stFIPRESTA As String = dt_FICHPRED.Rows(0).Item("FIPRESTA")

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
                    ParametrosConsulta += "FiprCopr "
                    ParametrosConsulta += "From FichPred where "
                    ParametrosConsulta += "FiprClse = '" & stFIPRCLSE & "' and "
                    ParametrosConsulta += "FiprMuni = '" & stFIPRMUNI & "' and "
                    ParametrosConsulta += "FiprCorr = '" & stFIPRCORR & "' and "
                    ParametrosConsulta += "FiprBarr = '" & stFIPRBARR & "' and "
                    ParametrosConsulta += "FiprManz = '" & stFIPRMANZ & "' and "
                    ParametrosConsulta += "FiprPred = '" & stFIPRPRED & "' and "
                    ParametrosConsulta += "FiprEdif = '" & stFIPREDIF & "' and "
                    ParametrosConsulta += "FiprEsta = '" & stFIPRESTA & "' and "
                    ParametrosConsulta += "FiprCapr = '" & stFIPRCAPR & "'"

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

                    Dim h As Integer
                    Dim doTotal As Double

                    ' suma el coeficiente de pred
                    For h = 0 To dt.Rows.Count - 1
                        doTotal += CType(Trim(dt.Rows(h).Item(0)), Double)
                    Next

                    If doTotal <> 100 Then

                        pro_GrabarInconsistencia(codigo, inconsistencia & " total: " & doTotal)

                    End If

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo)
        End Try

    End Sub
    Private Sub pro_Inconsistencia_114()
        Dim inconsistencia As String = "Coeficiente del predio en cero con característica 4 "
        Dim codigo As String = "114"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then
                If CType(Trim(dt_FICHPRED.Rows(0).Item("FIPRCOPR")), Double) = 0 Then

                    pro_GrabarInconsistencia(codigo, inconsistencia)

                End If
            End If
        End If


    End Sub
    Private Sub pro_Inconsistencia_115()
        Dim inconsistencia As String = "Coeficiente del edificio en cero para características 2,3 o 4"
        Dim codigo As String = "115"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then
                If CType(Trim(dt_FICHPRED.Rows(0).Item("FIPRCOED")), Double) = 0 Then

                    pro_GrabarInconsistencia(codigo, inconsistencia)

                End If
            End If
        End If


    End Sub
    Private Sub pro_Inconsistencia_116()
        Dim inconsistencia As String = "Edificio o unidad predial mayor a -0- para característica del predio."
        Dim codigo As String = "116"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then
                If Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")) <> "000" Or Trim(dt_FICHPRED.Rows(0).Item("FIPRUNPR")) <> "00000" Then

                    pro_GrabarInconsistencia(codigo, inconsistencia & " " & dt_FICHPRED.Rows(0).Item("FIPRCAPR") & " edificio: " & Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")) & " Unidad: " & Trim(dt_FICHPRED.Rows(0).Item("FIPRUNPR")))

                End If
            End If
        End If


    End Sub
    Private Sub pro_Inconsistencia_117()
        Dim inconsistencia As String = "Clasificador del suelo invalido para el sector urbano."
        Dim codigo As String = "117"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCASU") = 1 Then

                pro_GrabarInconsistencia(codigo, inconsistencia)

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_118()
        Dim inconsistencia As String = "Área de terreno mayor a 50 hectáreas para predios urbanos con características normal."
        Dim codigo As String = "118"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRARTE") > 500000 Then

                        pro_GrabarInconsistencia(codigo, inconsistencia)

                    End If
                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_119()
        Dim inconsistencia As String = "Área de terreno mayor a 1 hectárea para predios con características rph."
        Dim codigo As String = "119"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                If dt_FICHPRED.Rows(0).Item("FIPRARTE") > 10000 Then

                    pro_GrabarInconsistencia(codigo, inconsistencia)

                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_120()
        Dim inconsistencia As String = "Área de terreno mayor a 500 hectáreas para predios con características parcelación."
        Dim codigo As String = "120"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then
                If dt_FICHPRED.Rows(0).Item("FIPRARTE") > 5000000 Then

                    pro_GrabarInconsistencia(codigo, inconsistencia)

                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_121()
        Dim inconsistencia As String = "Área de terreno mayor a 1 hectárea para predios con características condominio."
        Dim codigo As String = "121"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then
                If dt_FICHPRED.Rows(0).Item("FIPRARTE") > 10000 Then

                    pro_GrabarInconsistencia(codigo, inconsistencia)

                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_122()
        Dim inconsistencia As String = "Área de terreno mayor a 10 hectáreas para predios con características parque cementerio."
        Dim codigo As String = "122"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 5 Then
                If dt_FICHPRED.Rows(0).Item("FIPRARTE") > 100000 Then

                    pro_GrabarInconsistencia(codigo, inconsistencia)

                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_123()
        Dim inconsistencia As String = "No existe ficha resumen 2 para predios con característica"
        Dim codigo As String = "123"

        Try

            If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
                   dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
                   dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Or _
                   dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 5 Then

                    ' declaro variables
                    Dim stFIPRCLSE As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE"))
                    Dim stFIPRMUNI As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                    Dim stFIPRCORR As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR"))
                    Dim stFIPRBARR As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR"))
                    Dim stFIPRMANZ As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ"))
                    Dim stFIPRPRED As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED"))
                    Dim stFIPREDIF As String = Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF"))
                    Dim stFIPRTIFI As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRTIFI"))
                    Dim stFIPRESTA As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRESTA"))

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
                    ParametrosConsulta += "Fiprnufi "
                    ParametrosConsulta += "From FichPred where "
                    ParametrosConsulta += "FiprClse = '" & stFIPRCLSE & "' and "
                    ParametrosConsulta += "FiprMuni = '" & stFIPRMUNI & "' and "
                    ParametrosConsulta += "FiprCorr = '" & stFIPRCORR & "' and "
                    ParametrosConsulta += "FiprBarr = '" & stFIPRBARR & "' and "
                    ParametrosConsulta += "FiprManz = '" & stFIPRMANZ & "' and "
                    ParametrosConsulta += "FiprPred = '" & stFIPRPRED & "' and "
                    ParametrosConsulta += "FiprEdif = '" & stFIPREDIF & "' and "
                    ParametrosConsulta += "FiprEsta = '" & stFIPRESTA & "' and "
                    ParametrosConsulta += "FiprTifi = '" & 2 & "' and "
                    ParametrosConsulta += "Exists(Select 1 from FichPred where "
                    ParametrosConsulta += "FiprClse = '" & stFIPRCLSE & "' and "
                    ParametrosConsulta += "FiprMuni = '" & stFIPRMUNI & "' and "
                    ParametrosConsulta += "FiprCorr = '" & stFIPRCORR & "' and "
                    ParametrosConsulta += "FiprBarr = '" & stFIPRBARR & "' and "
                    ParametrosConsulta += "FiprManz = '" & stFIPRMANZ & "' and "
                    ParametrosConsulta += "FiprPred = '" & stFIPRPRED & "' and "
                    ParametrosConsulta += "FiprEdif = '" & stFIPREDIF & "' and "
                    ParametrosConsulta += "FiprEsta = '" & stFIPRESTA & "' and "
                    ParametrosConsulta += "FiprTifi = '" & stFIPRTIFI & "')"

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


                    If dt.Rows.Count = 0 Then

                        pro_GrabarInconsistencia(codigo, inconsistencia & " " & dt_FICHPRED.Rows(0).Item("FIPRCAPR"))

                    End If

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo)
        End Try

    End Sub
    Private Sub pro_Inconsistencia_124()
        Dim inconsistencia As String = "No existe ficha resumen 1 para predios con características condominios."
        Dim codigo As String = "124"

        Try
            If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

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
                    ParametrosConsulta += "Fiprnufi "
                    ParametrosConsulta += "From FichPred where "
                    ParametrosConsulta += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta += "FiprEdif = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")) & "' and "
                    ParametrosConsulta += "FiprEsta = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRESTA")) & "' and "
                    ParametrosConsulta += "FiprTifi = '" & 1 & "' and "
                    ParametrosConsulta += "Exists (Select * from FichPred where "
                    ParametrosConsulta += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta += "FiprEdif = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")) & "' and "
                    ParametrosConsulta += "FiprEsta = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRESTA")) & "' and "
                    ParametrosConsulta += "FiprTifi = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRTIFI")) & "')"

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


                    If dt.Rows.Count = 0 Then

                        pro_GrabarInconsistencia(codigo, inconsistencia)

                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo)
        End Try

    End Sub
    Private Sub pro_Inconsistencia_130()
        Dim inconsistencia As String = "Área lote en cero para unidad predial con características de parcelación."
        Dim codigo As String = "130"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 AndAlso _
           dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 AndAlso _
           dt_FICHPRED.Rows(0).Item("FIPRARTE") = 0 Then

            pro_GrabarInconsistencia(codigo, inconsistencia)

        End If

    End Sub
    Private Sub pro_Inconsistencia_131()
        Dim inconsistencia As String = "Barrio no corresponde al clasificador del suelo para el sector rural"
        Dim codigo As String = "131"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
            If Val(Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR"))) > 0 Then
                If dt_FICHPRED.Rows(0).Item("FIPRCASU") <> 1 Then

                    pro_GrabarInconsistencia(codigo, inconsistencia)

                End If
            End If
        End If

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
            If Val(Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR"))) = 0 Then
                If dt_FICHPRED.Rows(0).Item("FIPRCASU") = 1 Then

                    pro_GrabarInconsistencia(codigo, inconsistencia)

                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_133()
        Dim inconsistencia As String = "No existe datos en la tabla de propietario"
        Dim codigo As String = "133"

        If dt_FIPRPROP.Rows.Count = 0 AndAlso dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

            pro_GrabarInconsistencia(codigo, inconsistencia)

        Else
            Dim i As Integer
            Dim byCONTADOR As Byte = 0

            For i = 0 To dt_FIPRPROP.Rows.Count - 1

                If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                    byCONTADOR = 1
                End If
            Next

            If byCONTADOR = 0 Then
                pro_GrabarInconsistencia(codigo, inconsistencia & " -- los registros se encuentra todos en estado inactivo")
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_134()
        Dim inconsistencia As String = "No existe datos en la tabla de destinación económica"
        Dim codigo As String = "134"

        If dt_FIPRDEEC.Rows.Count = 0 AndAlso dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

            pro_GrabarInconsistencia(codigo, inconsistencia)

        Else
            Dim i As Integer
            Dim byCONTADOR As Byte = 0

            For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                    byCONTADOR = 1
                End If
            Next

            If byCONTADOR = 0 Then
                pro_GrabarInconsistencia(codigo, inconsistencia & " -- los registros se encuentra todos en estado inactivo")
            End If

        End If

    End Sub
    Private Sub pro_Inconsistencia_135()
        Dim inconsistencia As String = "No existe datos en la tabla de construcción"
        Dim codigo As String = "135"

        Dim byCONTADOR As Byte = 0

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FIPRCONS.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCONS.Rows.Count - 1

                    If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                        byCONTADOR = 1
                    End If
                Next

            End If

            If dt_FIPRCONS.Rows.Count = 0 Then
                If dt_FIPRDEEC.Rows.Count = 0 Then
                    pro_GrabarInconsistencia(codigo, inconsistencia)
                Else
                    Dim i As Integer
                    Dim bySW As Byte

                    For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                        If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                            If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = "1" Or _
                                dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = "2" Or _
                                dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = "3" Or _
                                dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = "6" Or _
                                dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = "7" Or _
                                dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = "8" Or _
                                dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = "9" Then

                                If bySW = 0 Then
                                    pro_GrabarInconsistencia(codigo, inconsistencia)
                                    bySW = 1
                                End If
                            End If
                        End If
                    Next
                End If
            Else
                If byCONTADOR = 0 And dt_FIPRCONS.Rows.Count > 0 Then
                    pro_GrabarInconsistencia(codigo, inconsistencia & " -- los registros se encuentra todos en estado inactivo")
                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_136()
        Dim inconsistencia As String = "No existe datos en la tabla de linderos"
        Dim codigo As String = "136"

        If dt_FIPRLIND.Rows.Count = 0 Then

            pro_GrabarInconsistencia(codigo, inconsistencia)

        Else
            Dim i As Integer
            Dim byCONTADOR As Byte = 0

            For i = 0 To dt_FIPRLIND.Rows.Count - 1

                If Trim(dt_FIPRLIND.Rows(i).Item("FPLIESTA")) = "ac" Then
                    byCONTADOR = 1
                End If
            Next

            If byCONTADOR = 0 Then
                pro_GrabarInconsistencia(codigo, inconsistencia & " -- los registros se encuentra todos en estado inactivo")
            End If
        End If


    End Sub
    Private Sub pro_Inconsistencia_137()
        Dim inconsistencia As String = "No existe datos en la tabla de cartografia"
        Dim codigo As String = "137"

        If dt_FIPRCART.Rows.Count = 0 Then

            pro_GrabarInconsistencia(codigo, inconsistencia)

        Else
            Dim i As Integer
            Dim byCONTADOR As Byte = 0

            For i = 0 To dt_FIPRCART.Rows.Count - 1

                If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                    byCONTADOR = 1
                End If
            Next

            If byCONTADOR = 0 Then
                pro_GrabarInconsistencia(codigo, inconsistencia & " -- los registros se encuentra todos en estado inactivo")
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_138()
        Dim inconsistencia As String = "Coeficiente predio mayor a 0 para característica diferente de condominio "
        Dim codigo As String = "138"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If CType(Trim(dt_FICHPRED.Rows(0).Item("FIPRCOPR")), Double) > 0 Then
                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") <> 4 Then

                    pro_GrabarInconsistencia(codigo, inconsistencia)

                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_139()
        Dim inconsistencia As String = "Coeficiente edificio mayor a 0 para característica diferente a rph, parcelación y condominio"
        Dim codigo As String = "139"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If CType(Trim(dt_FICHPRED.Rows(0).Item("FIPRCOED")), Double) > 0 Then
                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Then

                    pro_GrabarInconsistencia(codigo, inconsistencia)

                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_140()
        Dim inconsistencia As String = "Cedula catastral repetida."
        Dim codigo As String = "140"

        Try
            ' Si no es litigio
            If Trim(dt_FICHPRED.Rows(0).Item("FIPRLITI")) = False Then


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
                ParametrosConsulta += "a.Fiprnufi "
                ParametrosConsulta += "From FichPred a where "
                ParametrosConsulta += "a.FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                ParametrosConsulta += "a.FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                ParametrosConsulta += "a.FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                ParametrosConsulta += "a.FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                ParametrosConsulta += "a.FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                ParametrosConsulta += "a.FiprEdif = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")) & "' and "
                ParametrosConsulta += "a.FiprUnpr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRUNPR")) & "' and "
                ParametrosConsulta += "a.FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                ParametrosConsulta += "a.FiprEsta = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRESTA")) & "' and "
                ParametrosConsulta += "a.FiprTifi = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRTIFI")) & "' and "
                ParametrosConsulta += "Exists (Select * from FichPred b where "
                ParametrosConsulta += "b.FiprMuni = a.FiprMuni and "
                ParametrosConsulta += "b.FiprCorr = a.FiprCorr and "
                ParametrosConsulta += "b.FiprBarr = a.FiprBarr and "
                ParametrosConsulta += "b.FiprManz = a.FiprManz and "
                ParametrosConsulta += "b.FiprPred = a.FiprPred and "
                ParametrosConsulta += "b.FiprEdif = a.FiprEdif and "
                ParametrosConsulta += "b.FiprUnpr = a.FiprUnpr and "
                ParametrosConsulta += "b.FiprClse = a.FiprClse and "
                ParametrosConsulta += "b.FiprTifi = a.FiprTifi and "
                ParametrosConsulta += "b.FiprEsta = a.FiprEsta) "

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

                If dt.Rows.Count > 1 Then

                    pro_GrabarInconsistencia(codigo, inconsistencia)

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo)
        End Try

    End Sub
    Private Sub pro_Inconsistencia_142()
        Dim inconsistencia As String = "Campo de edificio mayor a -1- para característica de predio 2 o 3"
        Dim codigo As String = "142"

        If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then
            If Val(Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF"))) > 1 Then

                pro_GrabarInconsistencia(codigo, inconsistencia)

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_143()
        Dim inconsistencia As String = "No existe datos en la tabla de zonas economicas"
        Dim codigo As String = "143"

        If dt_FIPRZOEC.Rows.Count = 0 Then

            pro_GrabarInconsistencia(codigo, inconsistencia)

        Else
            Dim i As Integer
            Dim byCONTADOR As Byte = 0

            For i = 0 To dt_FIPRZOEC.Rows.Count - 1

                If Trim(dt_FIPRZOEC.Rows(i).Item("FPZEESTA")) = "ac" Then
                    byCONTADOR = 1
                End If
            Next

            If byCONTADOR = 0 Then
                pro_GrabarInconsistencia(codigo, inconsistencia & " -- los registros se encuentra todos en estado inactivo")
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_144()
        Dim inconsistencia As String = "No existe datos en la tabla de zonas fisicas"
        Dim codigo As String = "144"


        If dt_FIPRZOFI.Rows.Count = 0 Then

            pro_GrabarInconsistencia(codigo, inconsistencia)

        Else
            Dim i As Integer
            Dim byCONTADOR As Byte = 0

            For i = 0 To dt_FIPRZOFI.Rows.Count - 1

                If Trim(dt_FIPRZOFI.Rows(i).Item("FPZFESTA")) = "ac" Then
                    byCONTADOR = 1
                End If
            Next

            If byCONTADOR = 0 Then
                pro_GrabarInconsistencia(codigo, inconsistencia & " -- los registros se encuentra todos en estado inactivo")
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_145()
        Dim inconsistencia As String = "Predio NO debe estar marcado como conjunto para característica de predio 1"
        Dim codigo As String = "145"

        If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCONJ") = True Then

                pro_GrabarInconsistencia(codigo, inconsistencia)

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_146()
        Dim inconsistencia As String = "Predio debe estar marcado como conjunto para característica de predio 3 o 4."
        Dim codigo As String = "146"

        If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCONJ") = False Then

                pro_GrabarInconsistencia(codigo, inconsistencia)

            End If
        End If

    End Sub


#End Region

#Region "Validar FiprDeec"

    Private Sub pro_ValidarFiprDeec()

        Try
            ' Inconsistencias destinación económico
            pro_Inconsistencia_200()
            pro_Inconsistencia_201()
            pro_Inconsistencia_202()
            pro_Inconsistencia_203()
            pro_Inconsistencia_204()
            pro_Inconsistencia_205()
            pro_Inconsistencia_206()
            pro_Inconsistencia_207()
            pro_Inconsistencia_208()
            pro_Inconsistencia_209()
            pro_Inconsistencia_210()
            pro_Inconsistencia_211()
            pro_Inconsistencia_212()
            pro_Inconsistencia_213()

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Destinación económica")
        End Try


    End Sub

    Private Sub pro_Inconsistencia_200()
        Dim inconsistencia As String = "Destino economico no suma el 100 %."
        Dim codigo As String = "200"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FIPRDEEC.Rows.Count > 0 Then

                Dim i As Integer
                Dim inTOTAL As Integer

                For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                    If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then

                        inTOTAL += dt_FIPRDEEC.Rows(i).Item("FPDEPORC")

                    End If

                Next

                If inTOTAL <> 100 Then

                    pro_GrabarInconsistencia(codigo, inconsistencia & " Total: " & inTOTAL)

                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_201()
        Dim inconsistencia As String = "Área construida mayor o igual a cero para DE 12,13,14,15 y clase de cons. 1 o 2."
        Dim codigo As String = "201"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FIPRDEEC.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                    If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                        If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 12 Or _
                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 13 Or _
                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 14 Or _
                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 15 Then

                            If dt_FIPRCONS.Rows.Count > 0 Then

                                Dim k As Integer
                                Dim bySW As Byte
                                Dim stFPCOCLCO As String
                                Dim doFPCOARCO As Double

                                For k = 0 To dt_FIPRCONS.Rows.Count - 1

                                    If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                                        stFPCOCLCO = dt_FIPRCONS.Rows(i).Item("FPCOCLCO")
                                        doFPCOARCO = CType(Trim(dt_FIPRCONS.Rows(i).Item("FPCOARCO")), Double)

                                        If stFPCOCLCO = 1 Or stFPCOCLCO = 2 Then
                                            If doFPCOARCO >= 0 Then
                                                If bySW = 0 Then

                                                    pro_GrabarInconsistencia(codigo, inconsistencia)

                                                    bySW = 1
                                                End If
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                        End If
                    End If
                Next
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_202()
        Dim inconsistencia As String = "En sector urbano no es valido destinaciones 17 y 18 ."
        Dim codigo As String = "202"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                If dt_FIPRDEEC.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                        If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                            If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 17 Or dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 18 Then

                                pro_GrabarInconsistencia(codigo, inconsistencia)

                            End If
                        End If
                    Next
                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_203()
        Dim inconsistencia As String = "En sector rural no es valido destinaciones 12,13 y 14."
        Dim codigo As String = "203"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
                If dt_FIPRDEEC.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                        If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                            If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 12 Or _
                               dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 13 Or _
                               dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 14 Then

                                pro_GrabarInconsistencia(codigo, inconsistencia)

                            End If
                        End If
                    Next
                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_204()
        Dim inconsistencia As String = "Destinaciones económica no valida para características 5."
        Dim codigo As String = "204"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 5 Then
                If dt_FIPRDEEC.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                        If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                            If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 2 Or _
                               dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 3 Or _
                               dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 4 Or _
                               dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 5 Or _
                               dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 7 Or _
                               dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 8 Or _
                               dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 15 Or _
                               dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 18 Or _
                               dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 19 Or _
                               dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 20 Then

                                pro_GrabarInconsistencia(codigo, inconsistencia)

                            End If
                        End If
                    Next
                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_205()
        Dim inconsistencia As String = "Destinación económica 16 invalida para característica 4."
        Dim codigo As String = "205"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then
                If dt_FIPRDEEC.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                        If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                            If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 16 Then

                                pro_GrabarInconsistencia(codigo, inconsistencia)

                            End If
                        End If
                    Next
                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_206()
        Dim inconsistencia As String = "Destinación económica invalida para características 2,3 o 4 sector 1."
        Dim codigo As String = "206"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
                   dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
                   dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                    If dt_FIPRDEEC.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                            If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                                If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 4 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 5 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 15 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 18 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 19 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 20 Then

                                    pro_GrabarInconsistencia(codigo, inconsistencia)

                                End If
                            End If
                        Next
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_207()
        Dim inconsistencia As String = "Destinación económica no valida para características 6 sector 2."
        Dim codigo As String = "207"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Then
                    If dt_FIPRDEEC.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                            If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                                If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 12 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 13 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 14 Then

                                    pro_GrabarInconsistencia(codigo, inconsistencia)

                                End If
                            End If
                        Next
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_208()
        Dim inconsistencia As String = "Destinación económica no valida para características 7."
        Dim codigo As String = "208"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 AndAlso _
           dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

            If dt_FIPRDEEC.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                    If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                        If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 4 Then

                            pro_GrabarInconsistencia(codigo, inconsistencia & " Destino: " & dt_FIPRDEEC.Rows(i).Item("FPDEDEEC"))

                        End If
                    End If
                Next
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_209()
        Dim inconsistencia As String = "Destinación económica 17 no valida para calidad de propietario diferente a 2"
        Dim codigo As String = "209"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FIPRDEEC.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                    If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                        If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 17 Then

                            If dt_FIPRPROP.Rows.Count > 0 Then

                                Dim k As Integer

                                For k = 0 To dt_FIPRPROP.Rows.Count - 1

                                    If Trim(dt_FIPRPROP.Rows(k).Item("FPPRESTA")) = "ac" Then
                                        If dt_FIPRPROP.Rows(k).Item("FPPRCAPR") <> 2 Then

                                            pro_GrabarInconsistencia(codigo, inconsistencia & " Documento nro: " & dt_FIPRPROP.Rows(k).Item("FPPRNUDO"))

                                        End If
                                    End If
                                Next
                            End If
                        End If
                    End If
                Next
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_210()
        Dim inconsistencia As String = "Destinación económica 18 no valida para cálida del propietario diferente a 7 "
        Dim codigo As String = "210"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FIPRDEEC.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                    If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                        If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 18 Then

                            If dt_FIPRPROP.Rows.Count > 0 Then

                                Dim k As Integer

                                For k = 0 To dt_FIPRPROP.Rows.Count - 1

                                    If Trim(dt_FIPRPROP.Rows(k).Item("FPPRESTA")) = "ac" Then
                                        If dt_FIPRPROP.Rows(k).Item("FPPRCAPR") <> 7 Then

                                            pro_GrabarInconsistencia(codigo, inconsistencia & " Documento nro: " & dt_FIPRPROP.Rows(k).Item("FPPRNUDO"))

                                        End If
                                    End If
                                Next
                            End If
                        End If
                    End If
                Next
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_211()
        Dim inconsistencia As String = "% Destinación económica diferente a 100 para DE 9-12-13-14-15-16-17-18-19."
        Dim codigo As String = "211"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FIPRDEEC.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                    If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                        If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 9 Or _
                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 12 Or _
                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 13 Or _
                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 14 Or _
                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 15 Or _
                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 16 Or _
                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 17 Or _
                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 18 Or _
                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 19 Then

                            If dt_FIPRDEEC.Rows(i).Item("FPDEPORC") <> 100 Then

                                pro_GrabarInconsistencia(codigo, inconsistencia & " Destino nro: " & dt_FIPRDEEC.Rows(i).Item("FPDEDEEC"))

                            End If
                        End If
                    End If
                Next
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_212()
        Dim inconsistencia As String = "DE 16 con construcción para característica 2 o 3 y clase cons. 1 o 2."
        Dim codigo As String = "212"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FIPRDEEC.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                    If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                        If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 16 Then
                            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then

                                If dt_FIPRCONS.Rows.Count > 0 Then

                                    Dim k As Integer

                                    For k = 0 To dt_FIPRCONS.Rows.Count - 1

                                        If Trim(dt_FIPRCONS.Rows(k).Item("FPCOESTA")) = "ac" Then
                                            If dt_FIPRCONS.Rows(k).Item("FPCOCLCO") = 1 Or dt_FIPRCONS.Rows(k).Item("FPCOCLCO") = 2 Then

                                                pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(k).Item("FPCOUNID"))

                                            End If
                                        End If
                                    Next
                                End If
                            End If
                        End If
                    End If
                Next
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_213()
        Dim inconsistencia As String = "DE diferente de 1 para predios rurales con área de terreno menor a 3000 mts."
        Dim codigo As String = "213"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
                If dt_FICHPRED.Rows(0).Item("FIPRARTE") > 3000 Then

                    If dt_FIPRDEEC.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                            If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                                If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") <> 1 Then

                                    pro_GrabarInconsistencia(codigo, inconsistencia & " Destino nro: " & dt_FIPRDEEC.Rows(i).Item("FPDEDEEC"))

                                End If
                            End If
                        Next
                    End If
                End If
            End If
        End If

    End Sub

#End Region

#Region "Validar FiprProp"

    Private Sub pro_ValidarFiprProp()

        Try
            ' Inconsistencias propietario
            pro_Inconsistencia_303()
            pro_Inconsistencia_304()
            pro_Inconsistencia_307()
            pro_Inconsistencia_308()
            pro_Inconsistencia_319()
            pro_Inconsistencia_320()
            pro_Inconsistencia_323()
            pro_Inconsistencia_325()
            pro_Inconsistencia_329()
            pro_Inconsistencia_335()
            pro_Inconsistencia_340()
            pro_Inconsistencia_341()
            pro_Inconsistencia_342()
            pro_Inconsistencia_343()

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Propietario")
        End Try

    End Sub

    Private Sub pro_Inconsistencia_303()
        Dim inconsistencia As String = "Rango de nro. de documento errado para clase de documento 1 cédula de hombre."
        Dim codigo As String = "303"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FIPRPROP.Rows.Count > 0 Then

                Dim i As Integer
                Dim byINCO As Byte
                Dim stNUMEDOCU As String

                For i = 0 To dt_FIPRPROP.Rows.Count - 1

                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                        If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 1 Then

                            stNUMEDOCU = Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO"))

                            If fun_Verificar_Dato_Numerico_Evento_Validated(stNUMEDOCU) = False Then

                                pro_GrabarInconsistencia(codigo, inconsistencia & " Documento nro: " & stNUMEDOCU)

                            Else
                                If (Val(stNUMEDOCU) > 0 And Val(stNUMEDOCU) < 20000000) Then
                                    byINCO = 1
                                ElseIf (Val(stNUMEDOCU) > 70000000 And Val(stNUMEDOCU) < 100000000) Then
                                    byINCO = 1
                                End If
                            End If

                            If byINCO = 0 Then

                                pro_GrabarInconsistencia(codigo, inconsistencia & " Documento nro: " & stNUMEDOCU)

                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_304()
        Dim inconsistencia As String = "Rango de nro. de documento errado para clase de documento 2 cédula de mujeres."
        Dim codigo As String = "304"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FIPRPROP.Rows.Count > 0 Then

                Dim i As Integer
                Dim stNUMEDOCU As String

                For i = 0 To dt_FIPRPROP.Rows.Count - 1

                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                        If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 2 Then

                            stNUMEDOCU = Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO"))

                            If fun_Verificar_Dato_Numerico_Evento_Validated(stNUMEDOCU) = False Then

                                pro_GrabarInconsistencia(codigo, inconsistencia & " Documento nro: " & stNUMEDOCU)

                            Else
                                If Not (Val(stNUMEDOCU) > 20000000 And Val(stNUMEDOCU) < 70000000) Then

                                    pro_GrabarInconsistencia(codigo, inconsistencia & " Documento nro: " & stNUMEDOCU)

                                End If
                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_307()
        Dim inconsistencia As String = "Formato de matricula invalida para derecho real o sucesión."
        Dim codigo As String = "307"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FIPRPROP.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRPROP.Rows.Count - 1

                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                        If dt_FIPRPROP.Rows(i).Item("FPPRMOAD") = 1 Or dt_FIPRPROP.Rows(i).Item("FPPRMOAD") = 3 Then
                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN")).ToString.Length = 11 Then

                                Dim stCirculoRegistro As String = Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN")).ToString.Substring(0, 3)
                                Dim stSeparador As String = Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN")).ToString.Substring(3, 1)
                                Dim stMatricula As String = Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN")).ToString.Substring(4, 7)

                                If fun_Verificar_Dato_Numerico_Evento_Validated(stCirculoRegistro) = False Then
                                    pro_GrabarInconsistencia(codigo, inconsistencia & " Circulo de registro: " & stCirculoRegistro)
                                End If
                                If stSeparador <> "-" Then
                                    pro_GrabarInconsistencia(codigo, inconsistencia & " Separador: " & stSeparador)
                                End If
                                If fun_Verificar_Dato_Numerico_Evento_Validated(stMatricula) = False Then
                                    pro_GrabarInconsistencia(codigo, inconsistencia & " Matricula: " & stMatricula)
                                End If
                            Else
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Matricula: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN")))
                            End If
                        End If
                    End If
                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_308()
        Dim inconsistencia As String = "Predio en posesión con datos juridicos."
        Dim codigo As String = "308"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FIPRPROP.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRPROP.Rows.Count - 1

                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                        If dt_FIPRPROP.Rows(i).Item("FPPRMOAD") = 2 Then

                            If Val(Trim(dt_FIPRPROP.Rows(i).Item("FPPRESCR"))) <> 0 Then
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Nro escritura: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRESCR")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                            End If
                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRDEPA")).ToString.Length > 0 Then
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Departamento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRDEPA")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                            End If
                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRMUNI")).ToString.Length > 0 Then
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Municipio: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRMUNI")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                            End If
                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRNOTA")).ToString.Length > 0 Then
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Notaria: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNOTA")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                            End If
                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")).ToString.Length > 0 Then
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Fecha escritura: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                            End If
                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")).ToString.Length > 0 Then
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Fecha registro: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                            End If
                            If Val(Trim(dt_FIPRPROP.Rows(i).Item("FPPRTOMO"))) <> 0 Then
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Tomo: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRTOMO")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                            End If
                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN")).ToString.Length > 0 Then
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Matricula: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                            End If

                        End If
                    End If
                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_319()
        Dim inconsistencia As String = "Porcentaje de litigio invalido."
        Dim codigo As String = "319"

        Try
            If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                If dt_FICHPRED.Rows(0).Item("FIPRLITI") = True Then

                    Dim byFIPRLITI As Byte

                    If dt_FICHPRED.Rows(0).Item("FIPRLITI") = True Then
                        byFIPRLITI = 1
                    Else
                        byFIPRLITI = 0
                    End If

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
                    ParametrosConsulta += "a.Fiprnufi, "
                    ParametrosConsulta += "a.FiprPoli "
                    ParametrosConsulta += "From FichPred a where "
                    ParametrosConsulta += "a.FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta += "a.FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta += "a.FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta += "a.FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta += "a.FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta += "a.FiprEdif = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")) & "' and "
                    ParametrosConsulta += "a.FiprUnpr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRUNPR")) & "' and "
                    ParametrosConsulta += "a.FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta += "a.FiprEsta = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRESTA")) & "' and "
                    ParametrosConsulta += "a.FiprTifi = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRTIFI")) & "' and "
                    ParametrosConsulta += "a.FiprLiti = '" & byFIPRLITI & "' "

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

                    Dim i As Integer
                    Dim doTOTAL As Double

                    For i = 0 To dt.Rows.Count - 1

                        doTOTAL += CType(Trim(dt.Rows(i).Item("FIPRPOLI")), Double)

                    Next

                    If doTOTAL <> 200 Then

                        pro_GrabarInconsistencia(codigo, inconsistencia & " Total porcentaje: " & doTOTAL)

                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo)
        End Try

    End Sub
    Private Sub pro_Inconsistencia_320()
        Dim inconsistencia As String = "Faltan datos juridicos para predio en derecho real o sucesión."
        Dim codigo As String = "320"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FIPRPROP.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRPROP.Rows.Count - 1

                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                        If dt_FIPRPROP.Rows(i).Item("FPPRMOAD") = 1 Or dt_FIPRPROP.Rows(i).Item("FPPRMOAD") = 3 Then

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRDEPA")).ToString.Length = 0 Then
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Departamento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRDEPA")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                            End If
                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRMUNI")).ToString.Length = 0 Then
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Municipio: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRMUNI")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                            End If
                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRNOTA")).ToString.Length = 0 Then
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Notaria: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNOTA")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                            End If
                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")).ToString.Length = 0 Then
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Fecha escritura: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                            End If
                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")).ToString.Length = 0 Then
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Fecha registro: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                            End If
                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN")).ToString.Length = 0 Then
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Matricula: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                            End If

                        End If
                    End If
                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_323()
        Dim inconsistencia As String = "Derecho no es igual al 100 %."
        Dim codigo As String = "323"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FIPRPROP.Rows.Count > 0 Then

                Dim i As Integer
                Dim doTOTAL As Double

                For i = 0 To dt_FIPRPROP.Rows.Count - 1

                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                        doTOTAL += CType(Trim(dt_FIPRPROP.Rows(i).Item("FPPRDERE")), Double)

                    End If

                Next

                If doTOTAL <> 100 Then

                    pro_GrabarInconsistencia(codigo, inconsistencia & " Total: " & doTOTAL)

                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_325()
        Dim inconsistencia As String = "Documento inicia con ceros o espacio a la izquierda."
        Dim codigo As String = "325"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FIPRPROP.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRPROP.Rows.Count - 1

                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                        If Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")).ToString.Substring(0, 1) = 0 Or _
                           dt_FIPRPROP.Rows(i).Item("FPPRNUDO").ToString.Substring(0, 1) = " " Then

                            pro_GrabarInconsistencia(codigo, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                        End If
                    End If

                Next
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_329()
        Dim inconsistencia As String = "Formato o fecha invalida para predio en derecho real o sucesión."
        Dim codigo As String = "329"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FIPRPROP.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRPROP.Rows.Count - 1

                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                        If dt_FIPRPROP.Rows(i).Item("FPPRMOAD") = 1 Or dt_FIPRPROP.Rows(i).Item("FPPRMOAD") = 3 Then

                            If Not IsDate(Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES"))) Then
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Fecha escritura: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                            End If

                            If Not IsDate(Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE"))) Then
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Fecha registro: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                            End If

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")).ToString.Length = 10 Then

                                Dim stFPPRFEES_DIA As String = Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")).ToString.Substring(0, 2)
                                Dim stFPPRFEES_MES As String = Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")).ToString.Substring(3, 2)
                                Dim stFPPRFEES_ANO As String = Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")).ToString.Substring(6, 4)

                                If fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRFEES_DIA) = False Then
                                    pro_GrabarInconsistencia(codigo, inconsistencia & " Dia fecha escritura: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                End If
                                If fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRFEES_MES) = False Then
                                    pro_GrabarInconsistencia(codigo, inconsistencia & " Mes fecha escritura: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                End If
                                If fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRFEES_ANO) = False Then
                                    pro_GrabarInconsistencia(codigo, inconsistencia & " Año fecha escritura: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                End If

                                If stFPPRFEES_ANO < 1778 Then
                                    pro_GrabarInconsistencia(codigo, inconsistencia & " Año de escritura menor a 1778 - Fecha: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                End If
                            Else
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Fecha escritura: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                            End If

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")).ToString.Length = 10 Then

                                Dim stFPPRFERE_DIA As String = Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")).ToString.Substring(0, 2)
                                Dim stFPPRFERE_MES As String = Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")).ToString.Substring(3, 2)
                                Dim stFPPRFERE_ANO As String = Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")).ToString.Substring(6, 4)

                                If fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRFERE_DIA) = False Then
                                    pro_GrabarInconsistencia(codigo, inconsistencia & " Dia fecha registro: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                End If
                                If fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRFERE_MES) = False Then
                                    pro_GrabarInconsistencia(codigo, inconsistencia & " Mes fecha registro: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                End If
                                If fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRFERE_ANO) = False Then
                                    pro_GrabarInconsistencia(codigo, inconsistencia & " Año fecha registro: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                End If

                                If stFPPRFERE_ANO < 1778 Then
                                    pro_GrabarInconsistencia(codigo, inconsistencia & " Año de registro menor a 1778 - Fecha: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                End If
                            Else
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Fecha registro: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_335()
        Dim inconsistencia As String = "Rango de nro. de documento errado para clase de documento 3 persona juridica."
        Dim codigo As String = "335"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FIPRPROP.Rows.Count > 0 Then

                Dim i As Integer
                Dim stNUMEDOCU As String

                For i = 0 To dt_FIPRPROP.Rows.Count - 1

                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                        If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 3 Then

                            stNUMEDOCU = Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO"))

                            If fun_Verificar_Dato_Numerico_Evento_Validated(stNUMEDOCU) = False Then

                                pro_GrabarInconsistencia(codigo, inconsistencia & " Documento nro: " & stNUMEDOCU)

                            Else
                                If Not (Val(stNUMEDOCU) > 800000000 And Val(stNUMEDOCU) < 999999999) Then

                                    pro_GrabarInconsistencia(codigo, inconsistencia & " Documento nro: " & stNUMEDOCU)

                                End If
                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_340()
        Dim inconsistencia As String = "Rango de nro. de documento errado para clase de documento 9 NÚIP."
        Dim codigo As String = "340"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FIPRPROP.Rows.Count > 0 Then

                Dim i As Integer
                Dim stNUMEDOCU As String

                For i = 0 To dt_FIPRPROP.Rows.Count - 1

                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                        If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 9 Then

                            stNUMEDOCU = Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO"))

                            If fun_Verificar_Dato_Numerico_Evento_Validated(stNUMEDOCU) = False Then

                                pro_GrabarInconsistencia(codigo, inconsistencia & " Documento nro: " & stNUMEDOCU)

                            Else
                                If (Val(stNUMEDOCU) < 1000000000) Then

                                    pro_GrabarInconsistencia(codigo, inconsistencia & " Documento nro: " & stNUMEDOCU)

                                End If
                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_341()
        Dim inconsistencia As String = "Calidad de propietario 4 municipal marcado como gravable (verificar nit mensaje de aviso)."
        Dim codigo As String = "341"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FIPRPROP.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRPROP.Rows.Count - 1

                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                        If dt_FIPRPROP.Rows(i).Item("FPPRCAPR") = 4 Then
                            If dt_FIPRPROP.Rows(i).Item("FPPRGRAV") = True Then

                                pro_GrabarInconsistencia(codigo, inconsistencia)

                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_342()
        Dim inconsistencia As String = "Propietario marcado como no gravable para calidad de propietario incorrecta."
        Dim codigo As String = "342"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FIPRPROP.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRPROP.Rows.Count - 1

                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                        If dt_FIPRPROP.Rows(i).Item("FPPRGRAV") = False Then
                            If dt_FIPRPROP.Rows(i).Item("FPPRCAPR") <> 4 Then

                                pro_GrabarInconsistencia(codigo, inconsistencia)

                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_343()
        Dim inconsistencia As String = "Matricula diferente para predio con más de un propietario."
        Dim codigo As String = "343"

        If dt_FIPRPROP.Rows.Count > 0 Then

            Dim stMATRICULA As String = ""
            Dim bySW As Byte = 0
            Dim i As Integer

            For i = 0 To dt_FIPRPROP.Rows.Count - 1

                If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                    If i < 1 Then
                        stMATRICULA = Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN"))
                    End If

                    If stMATRICULA <> Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN")) Then

                        pro_GrabarInconsistencia(codigo, inconsistencia)

                    End If
                End If

            Next

        End If

    End Sub

#End Region

#Region "Validar FiprCons"

    Private Sub pro_ValidarFiprCons()

        Try
            'Inconsistencias construcción
            pro_Inconsistencia_400()
            pro_Inconsistencia_401()
            pro_Inconsistencia_402()
            pro_Inconsistencia_403()
            pro_Inconsistencia_404()
            pro_Inconsistencia_408()
            pro_Inconsistencia_435()
            pro_Inconsistencia_436()
            pro_Inconsistencia_437()
            pro_Inconsistencia_443()
            pro_Inconsistencia_446()
            pro_Inconsistencia_447()
            pro_Inconsistencia_448()
            pro_Inconsistencia_449()
            pro_Inconsistencia_450()
            pro_Inconsistencia_451()
            pro_Inconsistencia_452()
            pro_Inconsistencia_453()
            pro_Inconsistencia_454()
            pro_Inconsistencia_455()
            pro_Inconsistencia_456()
            pro_Inconsistencia_457()
            pro_Inconsistencia_458()


        Catch ex As Exception
            MessageBox.Show(Err.Description & "Construcción")
        End Try

    End Sub

    Private Sub pro_Inconsistencia_400()
        Dim inconsistencia As String = "Numero de construcción invalido para predio que no es mejora."
        Dim codigo As String = "400"

        If dt_FIPRCONS.Rows.Count > 0 Then

            Dim i As Integer

            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") > 1000 Then
                        If dt_FIPRCONS.Rows(i).Item("FPCOMEJO") = False Then

                            pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                        End If
                    End If
                End If

            Next

        End If
    End Sub
    Private Sub pro_Inconsistencia_401()
        Dim inconsistencia As String = "Numero de construcción invalido para predio que es mejora."
        Dim codigo As String = "401"

        If dt_FIPRCONS.Rows.Count > 0 Then

            Dim i As Integer

            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") < 1001 Then
                        If dt_FIPRCONS.Rows(i).Item("FPCOMEJO") = True Then

                            pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                        End If
                    End If
                End If

            Next

        End If
    End Sub
    Private Sub pro_Inconsistencia_402()
        Dim inconsistencia As String = "No existe calificación para las unidades construidas."
        Dim codigo As String = "402"

        If dt_FIPRCONS.Rows.Count > 0 Then

            Dim i As Integer

            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                    If dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 1 Or dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 3 Then
                        If dt_FIPRCACO.Rows.Count > 0 Then

                            Dim byCONTADOR As Byte

                            Dim sw1 As Byte = 0
                            Dim j1 As Integer = 0

                            While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                    byCONTADOR = 1
                                    sw1 = 1
                                Else
                                    j1 = j1 + 1
                                End If
                            End While

                            'Dim k As Integer

                            'For k = 0 To dt_FIPRCACO.Rows.Count - 1

                            '    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then
                            '        byCONTADOR = 1
                            '    End If

                            'Next

                            If byCONTADOR = 0 Then
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
                                byCONTADOR = 0
                            End If
                        Else
                            pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
                        End If
                    End If
                End If
            Next

        End If

    End Sub
    Private Sub pro_Inconsistencia_403()
        Dim inconsistencia As String = "Puntaje diferente entre los datos generales y calificación."
        Dim codigo As String = "403"

        If dt_FIPRCONS.Rows.Count > 0 Then

            Dim i As Integer

            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                    If dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 1 Or dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 3 Then
                        If dt_FIPRCACO.Rows.Count > 0 Then

                            Dim k As Integer
                            Dim inFPCOPUNT As Integer = 0

                            For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then
                                    inFPCOPUNT += dt_FIPRCACO.Rows(k).Item("FPCCPUNT")
                                End If

                            Next

                            If dt_FIPRCONS.Rows(i).Item("FPCOPUNT") <> inFPCOPUNT Then
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
                            End If

                        Else
                            pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
                        End If
                    End If
                End If
            Next

        End If

    End Sub
    Private Sub pro_Inconsistencia_404()
        Dim inconsistencia As String = "Área construcción igual a cero."
        Dim codigo As String = "404"

        If dt_FIPRCONS.Rows.Count > 0 Then

            Dim i As Integer

            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                    If CType(Trim(dt_FIPRCONS.Rows(i).Item("FPCOARCO")), Double) = 0 Then
                        pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
                    End If
                End If

            Next

        End If

    End Sub
    Private Sub pro_Inconsistencia_408()
        Dim inconsistencia As String = "Puntos construcción no pueden ser mayor tabla codazzi."
        Dim codigo As String = "408"

        If dt_FIPRCONS.Rows.Count > 0 Then

            Dim i As Integer

            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then


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
                    ParametrosConsulta += "TicoPuma "
                    ParametrosConsulta += "From Mant_TipoCons where "
                    ParametrosConsulta += "TicoDepa = '" & Trim(dt_FIPRCONS.Rows(i).Item("FPCODEPA")) & "' and "
                    ParametrosConsulta += "TicoMuni = '" & Trim(dt_FIPRCONS.Rows(i).Item("FPCOMUNI")) & "' and "
                    ParametrosConsulta += "TicoClco = '" & Trim(dt_FIPRCONS.Rows(i).Item("FPCOCLCO")) & "' and "
                    ParametrosConsulta += "TicoCodi = '" & Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) & "' "

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

                    If dt.Rows.Count > 0 Then

                        If dt_FIPRCONS.Rows(i).Item("FPCOPUNT") > dt.Rows(0).Item(0) Then

                            pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                        End If
                    End If
                End If

            Next

        End If

    End Sub
    Private Sub pro_Inconsistencia_435()
        Dim inconsistencia As String = "Numero de pisos invalido."
        Dim codigo As String = "435"

        If dt_FIPRCONS.Rows.Count > 0 Then

            Dim i As Integer

            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                    If dt_FIPRCONS.Rows(i).Item("FPCOPISO") > 20 Then
                        pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
                    End If
                End If

            Next

        End If

    End Sub
    Private Sub pro_Inconsistencia_436()
        Dim inconsistencia As String = "Porcentaje construido en cero."
        Dim codigo As String = "436"

        If dt_FIPRCONS.Rows.Count > 0 Then

            Dim i As Integer

            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                    If dt_FIPRCONS.Rows(i).Item("FPCOPOCO") = 0 Then
                        pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
                    End If
                End If

            Next

        End If

    End Sub
    Private Sub pro_Inconsistencia_437()
        Dim inconsistencia As String = "Edad de construcción en cero."
        Dim codigo As String = "437"

        If dt_FIPRCONS.Rows.Count > 0 Then

            Dim i As Integer

            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                    If dt_FIPRCONS.Rows(i).Item("FPCOEDCO") = 0 Then
                        pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
                    End If
                End If

            Next

        End If

    End Sub
    Private Sub pro_Inconsistencia_443()
        Dim inconsistencia As String = "Área construida mayor a área de terreno para predios normales."
        Dim codigo As String = "443"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If ((CType(Trim(dt_FIPRCONS.Rows(i).Item("FPCOARCO")), Double) * 0.9) / dt_FIPRCONS.Rows(i).Item("FPCOPISO")) > dt_FICHPRED.Rows(0).Item("FIPRARTE") Then

                                pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                            End If
                        End If

                    Next

                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_446()
        Dim inconsistencia As String = "Construcciones valorables no convencionales con calificación."
        Dim codigo As String = "446"

        If dt_FIPRCONS.Rows.Count > 0 Then

            Dim i As Integer

            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                    If dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 2 Then

                        If dt_FIPRCACO.Rows.Count > 0 Then

                            Dim byCONTADOR As Byte

                            Dim sw1 As Byte = 0
                            Dim j1 As Integer = 0

                            While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                    byCONTADOR = 1
                                    sw1 = 1
                                Else
                                    j1 = j1 + 1
                                End If
                            End While

                            If byCONTADOR = 1 Then
                                pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
                                byCONTADOR = 0
                            End If

                        End If
                    End If
                End If

            Next

        End If

    End Sub
    Private Sub pro_Inconsistencia_447()
        Dim inconsistencia As String = "Identificador residencial invalido para el sector rural."
        Dim codigo As String = "446"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
            If dt_FIPRCONS.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCONS.Rows.Count - 1

                    If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "039" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "045" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "036" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "045" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "047" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "050" Then

                            pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_448()
        Dim inconsistencia As String = "Identificador residencial invalido para el sector urbano."
        Dim codigo As String = "448"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
            If dt_FIPRCONS.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCONS.Rows.Count - 1

                    If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "001" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "021" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "044" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "002" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "003" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "014" Then

                            pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_449()
        Dim inconsistencia As String = "Identificador comercial invalido para el sector rural."
        Dim codigo As String = "449"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
            If dt_FIPRCONS.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCONS.Rows.Count - 1

                    If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "051" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "054" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "055" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "057" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "058" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "059" Then

                            pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_450()
        Dim inconsistencia As String = "Identificador comercial invalido para el sector urbano."
        Dim codigo As String = "450"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
            If dt_FIPRCONS.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCONS.Rows.Count - 1

                    If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "004" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "007" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "008" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "009" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "022" Then

                            pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_451()
        Dim inconsistencia As String = "Identificador industrial invalido para el sector rural."
        Dim codigo As String = "451"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
            If dt_FIPRCONS.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCONS.Rows.Count - 1

                    If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "067" Then

                            pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_452()
        Dim inconsistencia As String = "Identificador industrial invalido para el sector urbano."
        Dim codigo As String = "452"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
            If dt_FIPRCONS.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCONS.Rows.Count - 1

                    If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "011" Then

                            pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_453()
        Dim inconsistencia As String = "Predio marcado como conjunto para identificador residencial utilizado en urbanismo comun."
        Dim codigo As String = "453"

        If dt_FICHPRED.Rows(0).Item("FIPRCONJ") = True Then
            If dt_FIPRCONS.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCONS.Rows.Count - 1

                    If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "001" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "021" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "039" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "036" Then

                            pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_454()
        Dim inconsistencia As String = "Predio NO marcado como conjunto para identificador utilizado en conjunto residencial."
        Dim codigo As String = "454"

        If dt_FICHPRED.Rows(0).Item("FIPRCONJ") = False Then
            If dt_FIPRCONS.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCONS.Rows.Count - 1

                    If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "044" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "002" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "003" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "043" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "045" Or _
                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "047" Then

                            pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_455()
        Dim inconsistencia As String = "Numero de construcción inválido para ficha resumen 1 o 2."
        Dim codigo As String = "455"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Or _
           dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then

            If dt_FIPRCONS.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCONS.Rows.Count - 1

                    If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                        If dt_FIPRCONS.Rows(i).Item("FPCOUNID") > 1000 Then

                            pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_456()
        Dim inconsistencia As String = "Construcción marcada como mejora para ficha resumen 1 o 2."
        Dim codigo As String = "456"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Or _
           dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then

            If dt_FIPRCONS.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCONS.Rows.Count - 1

                    If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                        If dt_FIPRCONS.Rows(i).Item("FPCOMEJO") = True Then

                            pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_457()
        Dim inconsistencia As String = "Construcción marcada con ley 56 para característica diferente de 7."
        Dim codigo As String = "457"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FIPRCONS.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCONS.Rows.Count - 1

                    If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                        If dt_FIPRCONS.Rows(i).Item("FPCOLEY") = True Then
                            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") <> 7 Then

                                pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_458()
        Dim inconsistencia As String = "Construcción marcada con ley 56 para ficha resumen 1 o 2."
        Dim codigo As String = "458"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Or _
           dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then

            If dt_FIPRCONS.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCONS.Rows.Count - 1

                    If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                        If dt_FIPRCONS.Rows(i).Item("FPCOLEY") = True Then

                            pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                        End If
                    End If

                Next

            End If
        End If

    End Sub


#End Region

#Region "Validar FiprCaco"

    Private Sub pro_ValidarFiprCaco()

        Try
            'Inconsistencias calificacion 
            pro_Inconsistencia_504()
            pro_Inconsistencia_505()
            pro_Inconsistencia_506()
            pro_Inconsistencia_507()
            pro_Inconsistencia_508()
            pro_Inconsistencia_509()
            pro_Inconsistencia_510()
            pro_Inconsistencia_511()


        Catch ex As Exception
            MessageBox.Show(Err.Description & " Calificación de construcción")
        End Try

    End Sub

    Private Sub pro_Inconsistencia_504()
        Dim inconsistencia As String = "Identificador residencial invalido calificación 114."
        Dim codigo As String = "504"

        If dt_FIPRCONS.Rows.Count > 0 Then

            Dim i As Integer

            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                    If Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "021" Or _
                       Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "044" Or _
                       Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "003" Or _
                       Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "036" Or _
                       Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "043" Or _
                       Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "045" Then

                        If dt_FIPRCACO.Rows.Count > 0 Then

                            Dim sw1 As Byte = 0
                            Dim j1 As Integer = 0

                            While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 114 Then

                                        pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
                                        sw1 = 1
                                    Else
                                        j1 = j1 + 1
                                    End If
                                Else
                                    j1 = j1 + 1
                                End If

                            End While

                        End If
                    End If
                End If

            Next

        End If

    End Sub
    Private Sub pro_Inconsistencia_505()
        Dim inconsistencia As String = "Identificador residencial invalido para calificación 115."
        Dim codigo As String = "505"

        If dt_FIPRCONS.Rows.Count > 0 Then

            Dim i As Integer

            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                    If Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "001" Or _
                       Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "002" Or _
                       Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "039" Or _
                       Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "047" Or _
                       Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "033" Or _
                       Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "038" Then

                        If dt_FIPRCACO.Rows.Count > 0 Then

                            Dim sw1 As Byte = 0
                            Dim j1 As Integer = 0

                            While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 115 Then

                                        pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
                                        sw1 = 1
                                    Else
                                        j1 = j1 + 1
                                    End If
                                Else
                                    j1 = j1 + 1
                                End If

                            End While

                        End If
                    End If
                End If

            Next

        End If

    End Sub
    Private Sub pro_Inconsistencia_506()
        Dim inconsistencia As String = "Identificador mayor de 500 y calificaciones diferentes de 141,241,341,441."
        Dim codigo As String = "506"

        If dt_FIPRCONS.Rows.Count > 0 Then

            Dim i As Integer

            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))) = True Then
                        If Val(Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))) > 500 Then

                            If dt_FIPRCACO.Rows.Count > 0 Then

                                Dim k As Integer

                                For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then
                                        If dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 142 Or _
                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 143 Or _
                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 144 Or _
                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 242 Or _
                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 243 Or _
                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 244 Or _
                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 342 Or _
                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 343 Or _
                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 344 Or _
                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 442 Or _
                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 443 Or _
                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 444 Then

                                            pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI"))

                                        End If
                                    End If

                                Next

                            End If
                        End If
                    End If
                End If

            Next

        End If

    End Sub
    Private Sub pro_Inconsistencia_507()
        Dim inconsistencia As String = "Identificador residencial invalido para característica 3 o 4."
        Dim codigo As String = "507"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "001" Or _
                               Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "021" Or _
                               Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "044" Or _
                               Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "039" Or _
                               Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "043" Or _
                               Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "036" Then

                                pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                            End If
                        End If

                    Next

                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_508()
        Dim inconsistencia As String = "Identificador residencial invalido para característica 1."
        Dim codigo As String = "508"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "002" Or _
                               Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "003" Or _
                               Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "045" Or _
                               Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "047" Then

                                pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                            End If
                        End If

                    Next

                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_509()
        Dim inconsistencia As String = "Clase de construcción invalida para identificador mayor de 500."
        Dim codigo As String = "509"

        If dt_FIPRCONS.Rows.Count > 0 Then

            Dim i As Integer

            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))) = True Then
                        If Val(Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))) > 500 Then
                            If dt_FIPRCONS.Rows(i).Item("FPCOCLCO") <> 3 Then

                                pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                            End If
                        End If
                    End If
                End If

            Next

        End If

    End Sub
    Private Sub pro_Inconsistencia_510()
        Dim inconsistencia As String = "Clase de construcción invalida para identificador menor de 500."
        Dim codigo As String = "510"

        If dt_FIPRCONS.Rows.Count > 0 Then

            Dim i As Integer

            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))) = True Then
                        If Val(Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))) < 500 Then
                            If dt_FIPRCONS.Rows(i).Item("FPCOCLCO") <> 1 Then

                                pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                            End If
                        End If
                    End If
                End If

            Next

        End If

    End Sub
    Private Sub pro_Inconsistencia_511()
        Dim inconsistencia As String = "Clase de construcción invalida para identificador no convencional."
        Dim codigo As String = "511"

        If dt_FIPRCONS.Rows.Count > 0 Then

            Dim i As Integer

            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))) = False Then
                        If dt_FIPRCONS.Rows(i).Item("FPCOCLCO") <> 2 Then

                            pro_GrabarInconsistencia(codigo, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                        End If
                    End If
                End If

            Next

        End If

    End Sub

#End Region

#Region "Validar FiprLind"

    Private Sub pro_ValidarFiprLind()

        Try

            'Inconsistencias linderos
            pro_Inconsistencia_600()
            pro_Inconsistencia_601()
            pro_Inconsistencia_602()
            pro_Inconsistencia_603()
            pro_Inconsistencia_604()
            pro_Inconsistencia_605()
            pro_Inconsistencia_606()
            pro_Inconsistencia_607()
            pro_Inconsistencia_608()
            pro_Inconsistencia_609()

        Catch ex As Exception
            MessageBox.Show(Err.Description & ". Linderos")
        End Try

    End Sub

    Private Sub pro_Inconsistencia_600()
        Dim inconsistencia As String = "Falta punto cardinal norte."
        Dim codigo As String = "600"

        If dt_FIPRLIND.Rows.Count > 0 Then

            Dim inContador As Byte = 0
            Dim sw1 As Byte = 0
            Dim j1 As Integer = 0

            While j1 < dt_FIPRLIND.Rows.Count And sw1 = 0
                If Trim(dt_FIPRLIND.Rows(j1).Item("FPLIESTA")) = "ac" Then
                    If Trim(dt_FIPRLIND.Rows(j1).Item("FPLIPUCA")) = "N" Then
                        inContador = 1
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                Else
                    j1 = j1 + 1
                End If
            End While

            If inContador = 0 Then
                pro_GrabarInconsistencia(codigo, inconsistencia)
            End If

        End If

    End Sub
    Private Sub pro_Inconsistencia_601()
        Dim inconsistencia As String = "Falta punto cardinal oriente."
        Dim codigo As String = "601"

        If dt_FIPRLIND.Rows.Count > 0 Then

            Dim inContador As Byte = 0
            Dim sw1 As Byte = 0
            Dim j1 As Integer = 0

            While j1 < dt_FIPRLIND.Rows.Count And sw1 = 0
                If Trim(dt_FIPRLIND.Rows(j1).Item("FPLIESTA")) = "ac" Then
                    If Trim(dt_FIPRLIND.Rows(j1).Item("FPLIPUCA")) = "E" Then
                        inContador = 1
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                Else
                    j1 = j1 + 1
                End If
            End While

            If inContador = 0 Then
                pro_GrabarInconsistencia(codigo, inconsistencia)
            End If

        End If

    End Sub
    Private Sub pro_Inconsistencia_602()
        Dim inconsistencia As String = "Falta punto cardinal occidente."
        Dim codigo As String = "602"

        If dt_FIPRLIND.Rows.Count > 0 Then

            Dim inContador As Byte = 0
            Dim sw1 As Byte = 0
            Dim j1 As Integer = 0

            While j1 < dt_FIPRLIND.Rows.Count And sw1 = 0
                If Trim(dt_FIPRLIND.Rows(j1).Item("FPLIESTA")) = "ac" Then
                    If Trim(dt_FIPRLIND.Rows(j1).Item("FPLIPUCA")) = "O" Then
                        inContador = 1
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                Else
                    j1 = j1 + 1
                End If
            End While

            If inContador = 0 Then
                pro_GrabarInconsistencia(codigo, inconsistencia)
            End If

        End If

    End Sub
    Private Sub pro_Inconsistencia_603()
        Dim inconsistencia As String = "Falta punto cardinal sur."
        Dim codigo As String = "603"

        If dt_FIPRLIND.Rows.Count > 0 Then

            Dim inContador As Byte = 0
            Dim sw1 As Byte = 0
            Dim j1 As Integer = 0

            While j1 < dt_FIPRLIND.Rows.Count And sw1 = 0
                If Trim(dt_FIPRLIND.Rows(j1).Item("FPLIESTA")) = "ac" Then
                    If Trim(dt_FIPRLIND.Rows(j1).Item("FPLIPUCA")) = "S" Then
                        inContador = 1
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                Else
                    j1 = j1 + 1
                End If
            End While

            If inContador = 0 Then
                pro_GrabarInconsistencia(codigo, inconsistencia)
            End If

        End If

    End Sub
    Private Sub pro_Inconsistencia_604()
        Dim inconsistencia As String = "Falta punto cardinal nadir para característica rph."
        Dim codigo As String = "604"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                If dt_FIPRLIND.Rows.Count > 0 Then

                    Dim inContador As Byte = 0
                    Dim sw1 As Byte = 0
                    Dim j1 As Integer = 0

                    While j1 < dt_FIPRLIND.Rows.Count And sw1 = 0
                        If Trim(dt_FIPRLIND.Rows(j1).Item("FPLIESTA")) = "ac" Then
                            If Trim(dt_FIPRLIND.Rows(j1).Item("FPLIPUCA")) = "NA" Then
                                inContador = 1
                                sw1 = 1
                            Else
                                j1 = j1 + 1
                            End If
                        Else
                            j1 = j1 + 1
                        End If
                    End While

                    If inContador = 0 Then
                        pro_GrabarInconsistencia(codigo, inconsistencia)
                    End If

                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_605()
        Dim inconsistencia As String = "Falta punto cardinal zenit para característica rph."
        Dim codigo As String = "605"

        If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
            If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
               dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                If dt_FIPRLIND.Rows.Count > 0 Then

                    Dim inContador As Byte = 0
                    Dim sw1 As Byte = 0
                    Dim j1 As Integer = 0

                    While j1 < dt_FIPRLIND.Rows.Count And sw1 = 0
                        If Trim(dt_FIPRLIND.Rows(j1).Item("FPLIESTA")) = "ac" Then
                            If (Trim(dt_FIPRLIND.Rows(j1).Item("FPLIPUCA"))) = "ZE" Then
                                inContador = 1
                                sw1 = 1
                            Else
                                j1 = j1 + 1
                            End If
                        Else
                            j1 = j1 + 1
                        End If
                    End While

                    If inContador = 0 Then
                        pro_GrabarInconsistencia(codigo, inconsistencia)
                    End If

                End If
            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_606()
        Dim inconsistencia As String = "Linderos esta la expresión expansión."
        Dim codigo As String = "606"

        If dt_FIPRLIND.Rows.Count > 0 Then

            Dim filas() As DataRow

            filas = dt_FIPRLIND.Select("FPLICOLI like '%EXPANSI%' and FPLIESTA = 'ac'")

            If filas.Length > 0 Then
                pro_GrabarInconsistencia(codigo, inconsistencia)
            End If

        End If

    End Sub
    Private Sub pro_Inconsistencia_607()
        Dim inconsistencia As String = "Linderos esta la expresión rural."
        Dim codigo As String = "607"

        If dt_FIPRLIND.Rows.Count > 0 Then

            Dim filas() As DataRow

            filas = dt_FIPRLIND.Select("FPLICOLI like '%RURAL%' and FPLIESTA = 'ac'")

            If filas.Length > 0 Then
                pro_GrabarInconsistencia(codigo, inconsistencia)
            End If

        End If

    End Sub
    Private Sub pro_Inconsistencia_608()
        Dim inconsistencia As String = "Linderos esta la expresión urbana."
        Dim codigo As String = "608"

        If dt_FIPRLIND.Rows.Count > 0 Then

            Dim filas() As DataRow

            filas = dt_FIPRLIND.Select("FPLICOLI like '%URBAN%' and FPLIESTA = 'ac'")

            If filas.Length > 0 Then
                pro_GrabarInconsistencia(codigo, inconsistencia)
            End If

        End If

    End Sub
    Private Sub pro_Inconsistencia_609()
        Dim inconsistencia As String = "Lindero con espacio en blanco al inicio."
        Dim codigo As String = "609"

        If dt_FIPRLIND.Rows.Count > 0 Then

            Dim filas() As DataRow

            filas = dt_FIPRLIND.Select("FPLICOLI like ' %' and FPLIESTA = 'ac'")

            If filas.Length > 0 Then
                pro_GrabarInconsistencia(codigo, inconsistencia)
            End If

        End If

    End Sub

#End Region

#Region "Validar FiprCart"

    Private Sub pro_ValidarFiprCart()

        Try
            'Inconsistencias cartografia
            pro_Inconsistencia_700()
            pro_Inconsistencia_701()
            pro_Inconsistencia_702()
            pro_Inconsistencia_703()
            pro_Inconsistencia_704()
            pro_Inconsistencia_705()
            pro_Inconsistencia_706()
            pro_Inconsistencia_707()
            pro_Inconsistencia_708()
            pro_Inconsistencia_709()
            pro_Inconsistencia_710()
            pro_Inconsistencia_711()
            pro_Inconsistencia_712()
            pro_Inconsistencia_713()
            pro_Inconsistencia_714()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_Inconsistencia_700()
        Dim inconsistencia As String = "Codificación letras minúsculas no válida para la escala de 1:25000"
        Dim codigo As String = "700"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
            If dt_FIPRCART.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCART.Rows.Count - 1

                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                        If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:25000" Then
                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 8 Then
                                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(7, 1)) = False Then
                                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(7, 1).ToLower = True Then

                                        pro_GrabarInconsistencia(codigo, inconsistencia)

                                    End If
                                End If
                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_701()
        Dim inconsistencia As String = "Codificación numérica no válida para la escala  1:25000"
        Dim codigo As String = "701"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
            If dt_FIPRCART.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCART.Rows.Count - 1

                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                        If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:25000" Then
                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 8 Then
                                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(0, 3)) = False Then

                                    pro_GrabarInconsistencia(codigo, inconsistencia)

                                End If
                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_702()
        Dim inconsistencia As String = "Codificación mayor a la longitud valida para la escala 1:25000"
        Dim codigo As String = "702"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
            If dt_FIPRCART.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCART.Rows.Count - 1

                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                        If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:25000" Then
                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length > 8 Then

                                pro_GrabarInconsistencia(codigo, inconsistencia)

                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_703()
        Dim inconsistencia As String = "Codificación letras mayúsculas no valida para la escala  1:25000"
        Dim codigo As String = "703"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
            If dt_FIPRCART.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCART.Rows.Count - 1

                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                        If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:25000" Then
                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 8 Then
                                If Not Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(7, 1).ToUpper = "A" Or _
                                       Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(7, 1).ToUpper = "B" Or _
                                       Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(7, 1).ToUpper = "C" Or _
                                       Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(7, 1).ToUpper = "D" Then


                                    pro_GrabarInconsistencia(codigo, inconsistencia)

                                End If
                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_704()
        Dim inconsistencia As String = "Codificación romana no valida para la escala de 1:25000"
        Dim codigo As String = "704"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
            If dt_FIPRCART.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCART.Rows.Count - 1

                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                        If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:25000" Then
                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 8 Then
                                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(0, 3)) = True Then
                                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(4, 2)) = True Then

                                        pro_GrabarInconsistencia(codigo, inconsistencia)

                                    End If
                                End If
                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_705()
        Dim inconsistencia As String = "Codificación mayor a la longitud valida para la escala 1:10000"
        Dim codigo As String = "705"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
            If dt_FIPRCART.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCART.Rows.Count - 1

                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                        If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:10000" Then
                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length > 10 Then

                                pro_GrabarInconsistencia(codigo, inconsistencia)

                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_706()
        Dim inconsistencia As String = "Codificación romana no valida para la escala de 1:10000"
        Dim codigo As String = "706"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
            If dt_FIPRCART.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCART.Rows.Count - 1

                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                        If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:10000" Then
                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 10 Then
                                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(0, 3)) = True Then
                                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(4, 2)) = True Then

                                        pro_GrabarInconsistencia(codigo, inconsistencia)

                                    End If
                                End If
                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_707()
        Dim inconsistencia As String = "Codificación letras mayúsculas no valida para la escala  1:10000"
        Dim codigo As String = "707"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
            If dt_FIPRCART.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCART.Rows.Count - 1

                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                        If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:10000" Then
                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 10 Then
                                If Not Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(7, 1).ToUpper = "A" Or _
                                       Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(7, 1).ToUpper = "B" Or _
                                       Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(7, 1).ToUpper = "C" Or _
                                       Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(7, 1).ToUpper = "D" Then


                                    pro_GrabarInconsistencia(codigo, inconsistencia)

                                End If
                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_708()
        Dim inconsistencia As String = "Codificación números arábigos no validos para la escala 1:10000"
        Dim codigo As String = "708"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
            If dt_FIPRCART.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCART.Rows.Count - 1

                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                        If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:10000" Then
                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 10 Then
                                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(0, 3)) = False Or _
                                   fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1)) = False Then

                                    pro_GrabarInconsistencia(codigo, inconsistencia)

                                Else
                                    If Not Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1) = "1" Or _
                                           Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1) = "2" Or _
                                           Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1) = "3" Or _
                                           Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1) = "4" Then

                                        pro_GrabarInconsistencia(codigo, inconsistencia)

                                    End If
                                End If
                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_709()
        Dim inconsistencia As String = "Codificación mayor a la longitud valida para la escala 1:5000"
        Dim codigo As String = "709"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
            If dt_FIPRCART.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCART.Rows.Count - 1

                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                        If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:5000" Then
                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length > 12 Then

                                pro_GrabarInconsistencia(codigo, inconsistencia)

                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_710()
        Dim inconsistencia As String = "Codificación romana no valida para la escala de 1:5000"
        Dim codigo As String = "710"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
            If dt_FIPRCART.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCART.Rows.Count - 1

                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                        If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:5000" Then
                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 12 Then
                                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(0, 3)) = True Then
                                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(4, 2)) = True Then

                                        pro_GrabarInconsistencia(codigo, inconsistencia)

                                    End If
                                End If
                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_711()
        Dim inconsistencia As String = "Codificación letras mayúsculas no valida para la escala  1:5000"
        Dim codigo As String = "711"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
            If dt_FIPRCART.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCART.Rows.Count - 1

                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                        If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:5000" Then
                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 12 Then
                                If Not Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(7, 1).ToUpper = "A" Or _
                                       Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(7, 1).ToUpper = "B" Or _
                                       Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(7, 1).ToUpper = "C" Or _
                                       Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(7, 1).ToUpper = "D" Then


                                    pro_GrabarInconsistencia(codigo, inconsistencia)

                                End If
                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_712()
        Dim inconsistencia As String = "Codificación números arábigos no validos para la escala 1:5000"
        Dim codigo As String = "712"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
            If dt_FIPRCART.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRCART.Rows.Count - 1

                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                        If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:5000" Then
                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 12 Then
                                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(0, 3)) = False Or _
                                   fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1)) = False Then

                                    pro_GrabarInconsistencia(codigo, inconsistencia)

                                Else
                                    If Not Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1) = "1" Or _
                                           Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1) = "2" Or _
                                           Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1) = "3" Or _
                                           Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1) = "4" Then

                                        pro_GrabarInconsistencia(codigo, inconsistencia)

                                    End If
                                End If
                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_713()
        Dim inconsistencia As String = "Codificación letras minúsculas no válida para la escala de 1:5000"
        Dim codigo As String = "713"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
            If dt_FIPRCART.Rows.Count > 0 Then


                Dim i As Integer

                For i = 0 To dt_FIPRCART.Rows.Count - 1

                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                        If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:5000" Then
                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 12 Then
                                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(11, 1)) = False Then
                                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(11, 1).ToLower = False Then

                                        pro_GrabarInconsistencia(codigo, inconsistencia)

                                    Else
                                        If Not Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1).ToLower = "a" Or _
                                               Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1).ToLower = "b" Or _
                                               Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1).ToLower = "c" Or _
                                               Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1).ToLower = "d" Then

                                            pro_GrabarInconsistencia(codigo, inconsistencia)

                                        End If

                                    End If
                                End If
                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub
    Private Sub pro_Inconsistencia_714()
        Dim inconsistencia As String = "Plancha en nulo."
        Dim codigo As String = "714"

        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
            If dt_FIPRCART.Rows.Count > 0 Then


                Dim i As Integer

                For i = 0 To dt_FIPRCART.Rows.Count - 1

                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                        If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:5000" Then
                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 12 Then
                                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(11, 1)) = False Then
                                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(11, 1).ToLower = False Then

                                        pro_GrabarInconsistencia(codigo, inconsistencia)

                                    Else
                                        If Not Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1).ToLower = "a" Or _
                                               Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1).ToLower = "b" Or _
                                               Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1).ToLower = "c" Or _
                                               Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1).ToLower = "d" Then

                                            pro_GrabarInconsistencia(codigo, inconsistencia)

                                        End If

                                    End If
                                End If
                            End If
                        End If
                    End If

                Next

            End If
        End If

    End Sub

#End Region

#Region "Validar FiprZoec"

    Private Sub pro_ValidarFiprZoec()

        Try
            'Inconsistencias zonas economicas
            pro_Inconsistencia_801()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_Inconsistencia_801()
        Dim inconsistencia As String = "Zona económica no suma el 100 %."
        Dim codigo As String = "801"

        If dt_FIPRZOEC.Rows.Count > 0 Then

            Dim i As Integer
            Dim inTOTAL As Integer

            For i = 0 To dt_FIPRZOEC.Rows.Count - 1

                If Trim(dt_FIPRZOEC.Rows(i).Item("FPZEESTA")) = "ac" Then

                    inTOTAL += dt_FIPRZOEC.Rows(i).Item("FPZEPORC")

                End If

            Next

            If inTOTAL <> 100 Then

                pro_GrabarInconsistencia(codigo, inconsistencia & " Total: " & inTOTAL)

            End If
        End If

    End Sub

#End Region

#Region "Validar FiprZofi"

    Private Sub pro_ValidarFiprZofi()

        Try
            'Inconsistencias zonas economicas
            pro_Inconsistencia_901()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_Inconsistencia_901()
        Dim inconsistencia As String = "Zona física no suma el 100 %."
        Dim codigo As String = "901"

        If dt_FIPRZOFI.Rows.Count > 0 Then

            Dim i As Integer
            Dim inTOTAL As Integer

            For i = 0 To dt_FIPRZOFI.Rows.Count - 1

                If Trim(dt_FIPRZOFI.Rows(i).Item("FPZFESTA")) = "ac" Then

                    inTOTAL += dt_FIPRZOFI.Rows(i).Item("FPZFPORC")

                End If

            Next

            If inTOTAL <> 100 Then

                pro_GrabarInconsistencia(codigo, inconsistencia & " Total: " & inTOTAL)

            End If
        End If

    End Sub

#End Region

#End Region


End Class
