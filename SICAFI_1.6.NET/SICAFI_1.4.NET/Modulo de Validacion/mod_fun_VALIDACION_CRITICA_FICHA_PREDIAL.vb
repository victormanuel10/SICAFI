Imports REGLAS_DEL_NEGOCIO
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.Sqlclient
Imports System.Configuration
Imports System.Text

Module mod_fun_VALIDACION_CRITICA_FICHA_PREDIAL

    '========================================
    '*** VALIDACION CRITICA FICHA PREDIAL ***
    '========================================

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

    Private dt_VALIRETI As New DataTable

    Private filas() As DataRow

#End Region

#Region "Ficha Predial"

    Private stFIPRNUFI As String
    Private byFIPRINCO As Byte = 1

#End Region

#Region "Conexion"

    Private oEjecutar As New SqlCommand
    Private oConexion As New SqlConnection
    Private oAdapter As New SqlDataAdapter
    Private oReader As SqlDataReader
    Private ds As New DataSet
    Private dt As New DataTable
    Private dt_1 As New DataTable
    Private dt_2 As New DataTable
    Private dt_3 As New DataTable

#End Region

#End Region

#Region "PROCEDIMIENTOS"

#Region "Validar Ficha Predial"

    Public Sub pro_VALIDAR_CRITICA_FICHA_PREDIAL(ByVal o_stFIPRNUFI As Integer)

        Try
            ' variable numero de ficha predial 
            stFIPRNUFI = o_stFIPRNUFI

            ' Elimina las inconsistencias
            Dim objdatos As New cla_VALIFIPR

            objdatos.fun_Eliminar_FIPRINCO(Trim(o_stFIPRNUFI))

            ' Carga las tablas
            pro_CargarTablasIncosistencia()
            pro_CargarTablasFichaPredial()

            If Trim(dt_FICHPRED.Rows(0).Item("FIPRESTA")) = "ac" Then

                ' Valida las tablas
                pro_ValidarFichPred()
                pro_ValidarFiprDeec()
                pro_ValidarFiprProp()
                pro_ValidarFiprCons()
                pro_ValidarFiprCaco()
                pro_ValidarFiprLind()
                pro_ValidarFiprCart()
                pro_ValidarFiprZoec()
                pro_ValidarFiprZofi()
                pro_ValidarFichResu1()
                pro_ValidarFichResu2()

                Dim objdatos1 As New cla_VALIFIPR
                Dim tbl1 As New DataTable

                tbl1 = objdatos1.fun_Consultar_INCONSISTENCIA_X_FICHA_PREDIAL(Trim(stFIPRNUFI))

                ' verifica la inconsistencia de la ficha 
                If tbl1.Rows.Count > 0 Then
                    byFIPRINCO = 1
                Else
                    byFIPRINCO = 0
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
            Else

                pro_Inconsistencia_167()

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

        ' instancia las tablas
        dt_FICHPRED = New DataTable
        dt_FIPRDEEC = New DataTable
        dt_FIPRPROP = New DataTable
        dt_FIPRCONS = New DataTable
        dt_FIPRCACO = New DataTable
        dt_FIPRLIND = New DataTable
        dt_FIPRCART = New DataTable
        dt_FIPRZOEC = New DataTable
        dt_FIPRZOFI = New DataTable

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
        dt_FIPRCART = ds.Tables(6)
        ' Tabla 7
        dt_FIPRZOEC = ds.Tables(7)
        ' Tabla 8
        dt_FIPRZOFI = ds.Tables(8)

    End Sub
    Private Sub pro_CargarTablasIncosistencia()

        Try
            Dim obj_VALIRETI As New cla_VALIRETI

            dt_VALIRETI = New DataTable

            dt_VALIRETI = obj_VALIRETI.fun_Consultar_CAMPOS_MANT_VALIRETI

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
  
#End Region

#Region "Grabar Inconsistencias"

    Private Sub pro_GrabarInconsistencia(ByVal stCODIGO As String, ByVal stDESCRIPCION As String)

        Dim objdatos1 As New cla_VALIFIPR

        Dim stFIPRRESO As String = ""

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
                                        dt_FICHPRED.Rows(0).Item("FIPRCLSE"), _
                                        stFIPRRESO)
    End Sub

#End Region

#Region "Validar FichPred 100"

    Private Sub pro_ValidarFichPred()

        Try
            ' Inconsistencias de ficha predial
            pro_Inconsistencia_104()
            pro_Inconsistencia_105()
            pro_Inconsistencia_106()
            pro_Inconsistencia_107()
            pro_Inconsistencia_108()
            pro_Inconsistencia_109()
            pro_Inconsistencia_110()
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
            pro_Inconsistencia_147()
            pro_Inconsistencia_148()
            pro_Inconsistencia_149()
            pro_Inconsistencia_150()
            pro_Inconsistencia_151()
            pro_Inconsistencia_152()
            pro_Inconsistencia_153()
            pro_Inconsistencia_154()
            pro_Inconsistencia_155()
            pro_Inconsistencia_156()
            pro_Inconsistencia_157()
            pro_Inconsistencia_158()
            pro_Inconsistencia_159()
            pro_Inconsistencia_160()
            pro_Inconsistencia_161()
            pro_Inconsistencia_162()
            pro_Inconsistencia_163()
            pro_Inconsistencia_164()
            pro_Inconsistencia_165()
            pro_Inconsistencia_166()
            pro_Inconsistencia_168()
            pro_Inconsistencia_169()
            pro_Inconsistencia_170()
            pro_Inconsistencia_171()
            pro_Inconsistencia_172()

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Ficha Predial")
        End Try

    End Sub

    Private Sub pro_Inconsistencia_104()
        Dim inconsistencia As String = "Campo Municipio ó Corregimiento ó Barrio o Manzana ó Predio en cero."
        Dim codigo As String = "104"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) = "0" Or Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) = "000" Or _
                       Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) = "0" Or Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) = "00" Or _
                       Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) = "0" Or Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) = "000" Or _
                       Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) = "0" Or Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) = "000" Or _
                       Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) = "0" Or Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) = "00000" Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                    End If

                ElseIf dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
                    If Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) = "0" Or Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) = "000" Or _
                       Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) = "0" Or Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) = "00" Or _
                       Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) = "0" Or Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) = "000" Or _
                       Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) = "0" Or Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) = "00000" Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_105()
        Dim inconsistencia As String = "Terreno en cero para ficha que no es mejora"
        Dim codigo As String = "105"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

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

                                    pro_GrabarInconsistencia(codigo & "-" & stError, inconsistencia & " Unidad nro: " & stFPCOUNID)

                                End If

                            Next

                        Else

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                        End If

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_106()
        Dim inconsistencia As String = "Ficha es de mejora con área de terreno"
        Dim codigo As String = "106"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

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

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & stFPCOUNID)

                                End If

                            Next

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_107()
        Dim inconsistencia As String = "Abreviatura invalidad para la dirección."
        Dim codigo As String = "107"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 3 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRDIRE").ToString.Substring(0, 3) <> "AV " Then
                        If dt_FICHPRED.Rows(0).Item("FIPRDIRE").ToString.Substring(0, 4) <> "CIR " Then
                            If dt_FICHPRED.Rows(0).Item("FIPRDIRE").ToString.Substring(0, 3) <> "CL " Then
                                If dt_FICHPRED.Rows(0).Item("FIPRDIRE").ToString.Substring(0, 3) <> "CR " Then
                                    If dt_FICHPRED.Rows(0).Item("FIPRDIRE").ToString.Substring(0, 5) <> "CRVN " Then
                                        If dt_FICHPRED.Rows(0).Item("FIPRDIRE").ToString.Substring(0, 3) <> "DG " Then
                                            If dt_FICHPRED.Rows(0).Item("FIPRDIRE").ToString.Substring(0, 3) <> "TV " Then
                                                If dt_FICHPRED.Rows(0).Item("FIPRDIRE").ToString.Substring(0, 4) <> "ACR " Then
                                                    If dt_FICHPRED.Rows(0).Item("FIPRDIRE").ToString.Substring(0, 3) <> "AU " Then
                                                        If dt_FICHPRED.Rows(0).Item("FIPRDIRE").ToString.Substring(0, 3) <> "CQ " Then

                                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " " & dt_FICHPRED.Rows(0).Item("FIPRDIRE").ToString.Substring(0, 3))

                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_108()
        Dim inconsistencia As String = "Edificio en cero para caracteristica de predio"
        Dim codigo As String = "108"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then
                        If Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")) = "000" Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " " & dt_FICHPRED.Rows(0).Item("FIPRCAPR"))

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_109()
        Dim inconsistencia As String = "Unidad predial en cero para caracteristica de predio"
        Dim codigo As String = "109"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then
                        If Trim(dt_FICHPRED.Rows(0).Item("FIPRUNPR")) = "00000" Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " " & dt_FICHPRED.Rows(0).Item("FIPRCAPR"))

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_110()
        Dim inconsistencia As String = "Clasificador del suelo invalido "
        Dim codigo As String = "110"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCASU") <> 1 And dt_FICHPRED.Rows(0).Item("FIPRCASU") <> 2 And dt_FICHPRED.Rows(0).Item("FIPRCASU") <> 3 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Categoria: " & dt_FICHPRED.Rows(0).Item("FIPRCASU"))

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_112()
        Dim inconsistencia As String = "Coeficiente de edificio diferente al 100 %"
        Dim codigo As String = "112"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                        ' declaro variables
                        Dim stFIPRCLSE As String = dt_FICHPRED.Rows(0).Item("FIPRCLSE")
                        Dim stFIPRCAPR As String = dt_FICHPRED.Rows(0).Item("FIPRCAPR")
                        Dim stFIPRMUNI As String = dt_FICHPRED.Rows(0).Item("FIPRMUNI")
                        Dim stFIPRCORR As String = dt_FICHPRED.Rows(0).Item("FIPRCORR")
                        Dim stFIPRBARR As String = dt_FICHPRED.Rows(0).Item("FIPRBARR")
                        Dim stFIPRMANZ As String = dt_FICHPRED.Rows(0).Item("FIPRMANZ")
                        Dim stFIPRPRED As String = dt_FICHPRED.Rows(0).Item("FIPRPRED")
                        Dim stFIPREDIF As String = dt_FICHPRED.Rows(0).Item("FIPREDIF")
                        Dim stFIPRESTA As String = dt_FICHPRED.Rows(0).Item("FIPRESTA")

                        Dim objdatos As New cla_VALIFIPR
                        dt = New DataTable

                        dt = objdatos.fun_Consultar_FIPRCOED_X_FICHA_PREDIAL_INCO_112(stFIPRCLSE, stFIPRCAPR, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, stFIPREDIF, stFIPRESTA)

                        Dim h As Integer
                        Dim doTotal As Decimal

                        ' suma el coeficiente de edificio
                        For h = 0 To dt.Rows.Count - 1
                            doTotal += Double.Parse(dt.Rows(h).Item(0)).ToString
                        Next

                        If doTotal <> 100 Then
                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " total: " & doTotal)
                        End If

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_113()
        Dim inconsistencia As String = "Coeficiente de predio diferente al 100 %"
        Dim codigo As String = "113"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                        ' declaro variables
                        Dim stFIPRCLSE As String = dt_FICHPRED.Rows(0).Item("FIPRCLSE")
                        Dim stFIPRCAPR As String = dt_FICHPRED.Rows(0).Item("FIPRCAPR")
                        Dim stFIPRMUNI As String = dt_FICHPRED.Rows(0).Item("FIPRMUNI")
                        Dim stFIPRCORR As String = dt_FICHPRED.Rows(0).Item("FIPRCORR")
                        Dim stFIPRBARR As String = dt_FICHPRED.Rows(0).Item("FIPRBARR")
                        Dim stFIPRMANZ As String = dt_FICHPRED.Rows(0).Item("FIPRMANZ")
                        Dim stFIPRPRED As String = dt_FICHPRED.Rows(0).Item("FIPRPRED")
                        Dim stFIPREDIF As String = dt_FICHPRED.Rows(0).Item("FIPREDIF")
                        Dim stFIPRESTA As String = dt_FICHPRED.Rows(0).Item("FIPRESTA")

                        Dim objdatos As New cla_VALIFIPR
                        dt = New DataTable

                        dt = objdatos.fun_Consultar_FIPRCOPR_X_FICHA_PREDIAL_INCO_113(stFIPRCLSE, stFIPRCAPR, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, stFIPRESTA)

                        Dim h As Integer
                        Dim doTotal As Decimal

                        ' suma el coeficiente de pred
                        For h = 0 To dt.Rows.Count - 1
                            doTotal += CType(Trim(dt.Rows(h).Item(0)), Double)
                        Next

                        If doTotal <> 100 Then
                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " total: " & doTotal)
                        End If

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_114()
        Dim inconsistencia As String = "Coeficiente del predio en cero con característica 4 "
        Dim codigo As String = "114"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then
                        If CType(Trim(dt_FICHPRED.Rows(0).Item("FIPRCOPR")), Double) = 0 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_115()
        Dim inconsistencia As String = "Coeficiente del edificio en cero para características 2,3 o 4"
        Dim codigo As String = "115"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then
                        If CType(Trim(dt_FICHPRED.Rows(0).Item("FIPRCOED")), Double) = 0 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_116()
        Dim inconsistencia As String = "Edificio o unidad predial mayor a -0- para característica del predio."
        Dim codigo As String = "116"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then
                        If Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")) <> "000" Or Trim(dt_FICHPRED.Rows(0).Item("FIPRUNPR")) <> "00000" Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " " & dt_FICHPRED.Rows(0).Item("FIPRCAPR") & " edificio: " & Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")) & " Unidad: " & Trim(dt_FICHPRED.Rows(0).Item("FIPRUNPR")))

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_117()
        Dim inconsistencia As String = "Clasificador del suelo invalido para el sector urbano."
        Dim codigo As String = "117"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCASU") = 1 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_118()
        Dim inconsistencia As String = "Área de terreno mayor a 50 hectáreas para predios urbanos con características normal."
        Dim codigo As String = "118"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                        If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Then
                            If dt_FICHPRED.Rows(0).Item("FIPRARTE") > 500000 Then

                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                            End If
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_119()
        Dim inconsistencia As String = "Área de terreno mayor a 1 hectárea para predios con características rph."
        Dim codigo As String = "119"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                        If dt_FICHPRED.Rows(0).Item("FIPRARTE") > 10000 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_120()
        Dim inconsistencia As String = "Área de terreno mayor a 500 hectáreas para predios con características parcelación."
        Dim codigo As String = "120"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then
                        If dt_FICHPRED.Rows(0).Item("FIPRARTE") > 5000000 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_121()
        Dim inconsistencia As String = "Área de terreno mayor a 1 hectárea para predios con características condominio."
        Dim codigo As String = "121"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then
                        If dt_FICHPRED.Rows(0).Item("FIPRARTE") > 10000 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_122()
        Dim inconsistencia As String = "Área de terreno mayor a 10 hectáreas para predios con características parque cementerio."
        Dim codigo As String = "122"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 5 Then
                        If dt_FICHPRED.Rows(0).Item("FIPRARTE") > 100000 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_123()
        Dim inconsistencia As String = "No existe ficha resumen 2 para predios con característica de predio "
        Dim codigo As String = "123"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

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

                        Dim objdatos As New cla_VALIFIPR
                        dt = New DataTable

                        dt = objdatos.fun_Consultar_FICHA_RESUMEN_2_INCO_123(stFIPRCLSE, stFIPRTIFI, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, stFIPREDIF, stFIPRESTA)


                        If dt.Rows.Count = 0 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " " & dt_FICHPRED.Rows(0).Item("FIPRCAPR"))

                        End If

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_124()
        Dim inconsistencia As String = "No existe ficha resumen 1 para predios con características condominios."
        Dim codigo As String = "124"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

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

                        Dim objdatos As New cla_VALIFIPR
                        dt = New DataTable

                        dt = objdatos.fun_Consultar_FICHA_RESUMEN_1_INCO_124(stFIPRCLSE, stFIPRTIFI, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, stFIPREDIF, stFIPRESTA)

                        If dt.Rows.Count = 0 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_130()
        Dim inconsistencia As String = "Área lote en cero para unidad predial con características de parcelación."
        Dim codigo As String = "130"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 AndAlso _
                   dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 AndAlso _
                   dt_FICHPRED.Rows(0).Item("FIPRARTE") = 0 Then

                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_131()
        Dim inconsistencia As String = "Barrio no corresponde al clasificador del suelo para el sector rural"
        Dim codigo As String = "131"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
                    If Val(Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR"))) > 0 Then
                        If dt_FICHPRED.Rows(0).Item("FIPRCASU") <> 1 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                        End If
                    End If
                End If

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
                    If Val(Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR"))) = 0 Then
                        If dt_FICHPRED.Rows(0).Item("FIPRCASU") = 1 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_133()
        Dim inconsistencia As String = "No existe datos en la tabla de propietario"
        Dim codigo As String = "133"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FIPRPROP.Rows.Count = 0 AndAlso dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                Else
                    If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                        Dim i As Integer
                        Dim byCONTADOR As Byte = 0

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                byCONTADOR = 1
                            End If
                        Next

                        If byCONTADOR = 0 Then
                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " -- los registros se encuentra todos en estado inactivo")
                        End If

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_134()
        Dim inconsistencia As String = "No existe datos en la tabla de destinación económica"
        Dim codigo As String = "134"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FIPRDEEC.Rows.Count = 0 AndAlso dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                Else
                    If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                        Dim i As Integer
                        Dim byCONTADOR As Byte = 0

                        For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                            If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                                byCONTADOR = 1
                            End If
                        Next

                        If byCONTADOR = 0 Then
                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " -- los registros se encuentra todos en estado inactivo")
                        End If

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_135()
        Dim inconsistencia As String = "No existe datos en la tabla de construcción"
        Dim codigo As String = "135"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                Dim byCONTADOR As Byte = 0

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                        If dt_FIPRCONS.Rows.Count > 0 Then

                            Dim i As Integer

                            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                                    byCONTADOR = 1
                                End If
                            Next

                        End If
                    End If
                End If

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 And dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRCONS.Rows.Count = 0 Then
                        If dt_FIPRDEEC.Rows.Count = 0 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Dirección " & Trim(dt_FICHPRED.Rows(0).Item("FIPRDIRE")) & " - No posee Destinación Económica")
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

                                        Dim filas2() As DataRow

                                        filas2 = dt_FICHPRED.Select("FIPRDIRE like '% INT%' and FIPRESTA = 'ac'")

                                        If bySW = 0 And filas2.Length = 0 Then
                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Dirección " & dt_FICHPRED.Rows(0).Item("FIPRDIRE"))
                                            bySW = 1
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    Else
                        If byCONTADOR = 0 And dt_FIPRCONS.Rows.Count > 0 Then
                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " -- los registros se encuentra todos en estado inactivo")
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_136()
        Dim inconsistencia As String = "No existe datos en la tabla de linderos"
        Dim codigo As String = "136"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                Dim boFPCOMEJO As Boolean = False
                Dim bySW As Byte = 0
                Dim boINCO As Boolean = False

                ' verifica si la ficha es mejora
                Dim j As Integer

                For j = 0 To dt_FIPRCONS.Rows.Count - 1

                    If dt_FIPRCONS.Rows(j).Item("FPCOMEJO") = True Then

                        If bySW = 0 Then
                            boFPCOMEJO = True
                            bySW = 1
                        End If
                    End If

                Next

                ' veririca si la ficha tiene registros en linderos y construccion
                If dt_FIPRLIND.Rows.Count = 0 Then
                    If dt_FIPRCONS.Rows.Count = 0 Then

                        boINCO = True

                    End If
                End If

                ' verifica si la ficha no es mejora y no tiene linderos
                If boFPCOMEJO = False Then
                    If dt_FIPRLIND.Rows.Count = 0 Then

                        boINCO = True

                    End If
                End If

                If boINCO = True Then
                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                End If

                ' verifica si la ficha no es mejora y tiene los registros inactivos
                If boFPCOMEJO = False Then
                    If dt_FIPRLIND.Rows.Count > 0 Then


                        Dim i As Integer
                        Dim byCONTADOR As Byte = 0

                        For i = 0 To dt_FIPRLIND.Rows.Count - 1

                            If Trim(dt_FIPRLIND.Rows(i).Item("FPLIESTA")) = "ac" Then
                                byCONTADOR = 1
                            End If

                        Next

                        If byCONTADOR = 0 Then
                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " -- los registros se encuentra todos en estado inactivo")
                        End If

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_137()
        Dim inconsistencia As String = "No existe datos en la tabla de cartografia"
        Dim codigo As String = "137"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FIPRCART.Rows.Count = 0 Then

                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                Else
                    Dim i As Integer
                    Dim byCONTADOR As Byte = 0

                    For i = 0 To dt_FIPRCART.Rows.Count - 1

                        If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                            byCONTADOR = 1
                        End If
                    Next

                    If byCONTADOR = 0 Then
                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " -- los registros se encuentra todos en estado inactivo")
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_138()
        Dim inconsistencia As String = "Coeficiente predio mayor a 0 para característica diferente de condominio "
        Dim codigo As String = "138"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If CType(Trim(dt_FICHPRED.Rows(0).Item("FIPRCOPR")), Double) > 0 Then
                        If dt_FICHPRED.Rows(0).Item("FIPRCAPR") <> 4 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_139()
        Dim inconsistencia As String = "Coeficiente edificio mayor a 0 para característica diferente a rph, parcelación y condominio"
        Dim codigo As String = "139"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If CType(Trim(dt_FICHPRED.Rows(0).Item("FIPRCOED")), Double) > 0 Then
                        If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_140()
        Dim inconsistencia As String = "Cedula catastral repetida ficha predial."
        Dim codigo As String = "140"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                ' Si no es litigio
                If Trim(dt_FICHPRED.Rows(0).Item("FIPRLITI")) = False Then
                    If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                        Dim boFPCOMEJO As Boolean = False

                        If dt_FIPRCONS.Rows.Count > 0 Then

                            Dim i As Integer

                            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                                If dt_FIPRCONS.Rows(i).Item("FPCOMEJO") = True Then
                                    boFPCOMEJO = True
                                End If

                            Next

                        End If

                        ' verifica que la ficha no es mejora
                        If boFPCOMEJO = False Then

                            Dim stFIPRMUNI As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                            Dim stFIPRCORR As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR"))
                            Dim stFIPRBARR As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR"))
                            Dim stFIPRMANZ As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ"))
                            Dim stFIPRPRED As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED"))
                            Dim stFIPREDIF As String = Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF"))
                            Dim stFIPRUNPR As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRUNPR"))
                            Dim stFIPRCLSE As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE"))
                            Dim stFIPRESTA As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRESTA"))
                            Dim stFIPRTIFI As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRTIFI"))

                            Dim objdatos As New cla_VALIFIPR
                            dt = New DataTable

                            dt = objdatos.fun_Consultar_CEDULA_CATASTRAL_REPETIDA_INCO_140(stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, stFIPREDIF, stFIPRUNPR, stFIPRCLSE, stFIPRESTA, stFIPRTIFI)

                            If dt.Rows.Count > 1 Then
                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                            End If

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_142()
        Dim inconsistencia As String = "Campo de edificio mayor a -1- para característica de predio 2 o 3"
        Dim codigo As String = "142"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then
                    If Val(Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF"))) > 1 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_143()
        Dim inconsistencia As String = "No existe datos en la tabla de zonas economicas"
        Dim codigo As String = "143"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                Dim boFPCOMEJO As Boolean = False
                Dim bySW As Byte = 0

                ' verifica si la ficha es mejora
                Dim j As Integer

                For j = 0 To dt_FIPRCONS.Rows.Count - 1

                    If dt_FIPRCONS.Rows(j).Item("FPCOMEJO") = True Then

                        If bySW = 0 Then
                            boFPCOMEJO = True
                            bySW = 1
                        End If
                    End If

                Next

                If boFPCOMEJO = False Then
                    If dt_FIPRZOEC.Rows.Count = 0 Then
                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                    Else
                        Dim i As Integer
                        Dim byCONTADOR As Byte = 0

                        For i = 0 To dt_FIPRZOEC.Rows.Count - 1

                            If Trim(dt_FIPRZOEC.Rows(i).Item("FPZEESTA")) = "ac" Then
                                byCONTADOR = 1
                            End If
                        Next

                        If byCONTADOR = 0 Then
                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " -- los registros se encuentra todos en estado inactivo")
                        End If

                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_144()
        Dim inconsistencia As String = "No existe datos en la tabla de zonas fisicas"
        Dim codigo As String = "144"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                Dim boFPCOMEJO As Boolean = False
                Dim bySW As Byte = 0

                ' verifica si la ficha es mejora
                Dim j As Integer

                For j = 0 To dt_FIPRCONS.Rows.Count - 1

                    If dt_FIPRCONS.Rows(j).Item("FPCOMEJO") = True Then

                        If bySW = 0 Then
                            boFPCOMEJO = True
                            bySW = 1
                        End If
                    End If

                Next

                If boFPCOMEJO = False Then
                    If dt_FIPRZOFI.Rows.Count = 0 Then
                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                    Else
                        Dim i As Integer
                        Dim byCONTADOR As Byte = 0

                        For i = 0 To dt_FIPRZOFI.Rows.Count - 1

                            If Trim(dt_FIPRZOFI.Rows(i).Item("FPZFESTA")) = "ac" Then
                                byCONTADOR = 1
                            End If
                        Next

                        If byCONTADOR = 0 Then
                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " -- los registros se encuentra todos en estado inactivo")
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_145()
        Dim inconsistencia As String = "Predio NO debe estar marcado como conjunto para carac. de predio 1 e identificador en conjunto"
        Dim codigo As String = "145"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCONJ") = True Then

                        If dt_FIPRCONS.Rows.Count > 0 Then

                            Dim i As Integer

                            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                                Dim stFPCOTICO As String = dt_FIPRCONS.Rows(i).Item("FPCOTICO")

                                If stFPCOTICO <> "002" AndAlso _
                                   stFPCOTICO <> "003" AndAlso _
                                   stFPCOTICO <> "043" AndAlso _
                                   stFPCOTICO <> "045" AndAlso _
                                   stFPCOTICO <> "047" Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                End If

                            Next

                        Else
                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                        End If

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_146()
        Dim inconsistencia As String = "Predio debe estar marcado como conjunto para característica de predio 3 o 4."
        Dim codigo As String = "146"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCONJ") = False Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_147()
        Dim inconsistencia As String = "Existen registros de linderos para predio que es mejora"
        Dim codigo As String = "147"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                Dim boFPCOMEJO As Boolean = False
                Dim bySW As Byte = 0

                ' verifica si la ficha es mejora
                Dim j As Integer

                For j = 0 To dt_FIPRCONS.Rows.Count - 1

                    If dt_FIPRCONS.Rows(j).Item("FPCOMEJO") = True Then

                        If bySW = 0 Then
                            boFPCOMEJO = True
                            bySW = 1
                        End If
                    End If

                Next

                ' verifica si la ficha no es mejora y tiene los registros activos
                If boFPCOMEJO = True Then

                    Dim i As Integer
                    Dim byCONTADOR As Byte = 0

                    For i = 0 To dt_FIPRLIND.Rows.Count - 1

                        If Trim(dt_FIPRLIND.Rows(i).Item("FPLIESTA")) = "ac" Then
                            byCONTADOR = 1
                        End If

                    Next

                    If byCONTADOR = 1 Then
                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_148()
        Dim inconsistencia As String = "Existen registros de zonas económicas para predio que es mejora"
        Dim codigo As String = "148"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                Dim boFPCOMEJO As Boolean = False
                Dim bySW As Byte = 0

                ' verifica si la ficha es mejora
                Dim j As Integer

                For j = 0 To dt_FIPRCONS.Rows.Count - 1

                    If dt_FIPRCONS.Rows(j).Item("FPCOMEJO") = True Then

                        If bySW = 0 Then
                            boFPCOMEJO = True
                            bySW = 1
                        End If
                    End If

                Next

                ' verifica si la ficha no es mejora y tiene los registros activos
                If boFPCOMEJO = True Then

                    Dim i As Integer
                    Dim byCONTADOR As Byte = 0

                    For i = 0 To dt_FIPRZOEC.Rows.Count - 1

                        If Trim(dt_FIPRZOEC.Rows(i).Item("FPZEESTA")) = "ac" Then
                            byCONTADOR = 1
                        End If

                    Next

                    If byCONTADOR = 1 Then
                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_149()
        Dim inconsistencia As String = "Existen registros de zonas físicas para predio que es mejora"
        Dim codigo As String = "149"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                Dim boFPCOMEJO As Boolean = False
                Dim bySW As Byte = 0

                ' verifica si la ficha es mejora
                Dim j As Integer

                For j = 0 To dt_FIPRCONS.Rows.Count - 1

                    If dt_FIPRCONS.Rows(j).Item("FPCOMEJO") = True Then

                        If bySW = 0 Then
                            boFPCOMEJO = True
                            bySW = 1
                        End If
                    End If

                Next

                ' verifica si la ficha no es mejora y tiene los registros activos
                If boFPCOMEJO = True Then

                    Dim i As Integer
                    Dim byCONTADOR As Byte = 0

                    For i = 0 To dt_FIPRZOFI.Rows.Count - 1

                        If Trim(dt_FIPRZOFI.Rows(i).Item("FPZFESTA")) = "ac" Then
                            byCONTADOR = 1
                        End If

                    Next

                    If byCONTADOR = 1 Then
                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_150()
        Dim inconsistencia As String = "Predio con caracteristica 3 (RPH parcelación) en sector urbano."
        Dim codigo As String = "150"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_151()
        Dim inconsistencia As String = "Predio con caracteristica 2,3 ó 4 y modo de adquisición 2."
        Dim codigo As String = "151"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRMOAD") = 2 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_152()
        Dim inconsistencia As String = "Caracteristica de predio incorrecta para ficha resumen."
        Dim codigo As String = "152"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Or dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 5 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " " & dt_FICHPRED.Rows(0).Item("FIPRTIFI"))

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_153()
        Dim inconsistencia As String = "Predio con caracteristica 2,3 o 4 y abreviatura en la dirección de apto ‘ A o AP ’ con área de construcción menor a 10 mts2."
        Dim codigo As String = "153"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                        Dim filas1() As DataRow
                        Dim filas2() As DataRow

                        filas1 = dt_FICHPRED.Select("FIPRDIRE like '% A %' and FIPRESTA = 'ac'")
                        filas2 = dt_FICHPRED.Select("FIPRDIRE like '% AP %' and FIPRESTA = 'ac'")

                        If filas1.Length > 0 Or filas2.Length > 0 Then

                            If dt_FIPRCONS.Rows.Count > 0 Then

                                Dim i As Integer

                                For i = 0 To dt_FIPRCONS.Rows.Count - 1

                                    If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                                        If dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 1 Then
                                            If CType(Trim(dt_FIPRCONS.Rows(i).Item("FPCOARCO")), Double) < 10 Then

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                            End If
                                        End If
                                    End If

                                Next

                            End If

                        End If

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_154()
        Dim inconsistencia As String = "Predio con abreviatura en la dirección de lote ‘LT’ o ‘LO’ y con construcción valorable o no convencional."
        Dim codigo As String = "154"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    Dim filas1() As DataRow
                    Dim filas2() As DataRow
                    Dim filas3() As DataRow

                    filas1 = dt_FICHPRED.Select("FIPRDIRE like 'LT%' and FIPRESTA = 'ac'")
                    filas2 = dt_FICHPRED.Select("FIPRDIRE like '% INT%' and FIPRESTA = 'ac'")
                    filas3 = dt_FICHPRED.Select("FIPRDIRE like 'LO%' and FIPRESTA = 'ac'")

                    If (filas1.Length > 0 Or filas3.Length > 0) And filas2.Length = 0 Then

                        If dt_FIPRCONS.Rows.Count > 0 Then

                            Dim i As Integer

                            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                                    If dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 1 Or dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 2 Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Dirección: " & dt_FICHPRED.Rows(0).Item("FIPRDIRE"))

                                    End If
                                End If

                            Next

                        End If

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_155()
        Dim inconsistencia As String = "Edificio diferente de cero para caracteristica de predio 4 rph condominio ficha resumen 1"
        Dim codigo As String = "155"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then
                        If Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")) <> "000" Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " " & dt_FICHPRED.Rows(0).Item("FIPREDIF"))

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_156()
        Dim inconsistencia As String = "Edificio igual a cero para caracteristica de predio 2,3 o 4 ficha resumen 2"
        Dim codigo As String = "156"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                        If Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")) = "000" Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " " & dt_FICHPRED.Rows(0).Item("FIPREDIF"))

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_157()
        Dim inconsistencia As String = "Predio en cero"
        Dim codigo As String = "157"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) = "00000" Or Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) = "0" Then

                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_158()
        Dim inconsistencia As String = "Barrio en cero para el sector urbano"
        Dim codigo As String = "158"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) = "000" Or Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) = "0" Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_159()
        Dim inconsistencia As String = "Manzana o vereda en cero."
        Dim codigo As String = "159"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) = "000" Or Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) = "0" Then

                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_160()
        Dim inconsistencia As String = "Predio sin estrato socieconómico."
        Dim codigo As String = "160"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If Trim(dt_FICHPRED.Rows(0).Item("FIPRTIFI")) = 0 Then

                    Dim objdatos As New cla_ESTRFIPR
                    Dim tbl As New DataTable

                    tbl = objdatos.fun_Buscar_ESTRATO_X_NRO_DE_FICHA(Trim(dt_FICHPRED.Rows(0).Item("FIPRNUFI")))

                    If tbl.Rows.Count = 0 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                    Else
                        If tbl.Rows(0).Item("ESFPESTR") = 0 Or tbl.Rows(0).Item("ESFPESTR") > 6 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Estrato: " & tbl.Rows(0).Item("ESFPESTR"))

                        End If

                    End If

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_161()
        Dim inconsistencia As String = "Campo con un caracter de coma."
        Dim codigo As String = "161"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If Trim(dt_FICHPRED.Rows(0).Item("FIPRTIFI")) = 0 Then

                    Dim stCOEFEDIF As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRCOED"))
                    Dim stCOEFPRED As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRCOPR"))

                    Dim i As Integer = 0
                    Dim sw1 As Byte = 0

                    For i = 0 To stCOEFEDIF.Length - 1

                        Dim stLETRA As String = stCOEFEDIF.Substring(i, 1)

                        If stLETRA = "," Then
                            sw1 = 1
                        End If

                    Next

                    If sw1 = 1 Then
                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Coeficiente de edificio: " & dt_FICHPRED.Rows(0).Item("FIPRCOED"))
                    End If

                    Dim k As Integer = 0
                    Dim sw2 As Byte = 0

                    For k = 0 To stCOEFPRED.Length - 1

                        Dim stLETRA As String = stCOEFPRED.Substring(k, 1)

                        If stLETRA = "," Then
                            sw2 = 1
                        End If

                    Next

                    If sw2 = 1 Then
                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Coeficiente de predio: " & dt_FICHPRED.Rows(0).Item("FIPRCOPR"))
                    End If

                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim f As Integer = 0

                        For f = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(f).Item("FPPRESTA")) = "ac" Then

                                Dim stDERECHO As String = Trim(dt_FIPRPROP.Rows(f).Item("FPPRDERE"))

                                Dim j As Integer = 0
                                Dim sw3 As Byte = 0

                                For j = 0 To stDERECHO.Length - 1

                                    Dim stLETRA As String = stDERECHO.Substring(j, 1)

                                    If stLETRA = "," Then
                                        sw3 = 1
                                    End If

                                    If sw3 = 1 Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Nro. Documento: " & dt_FIPRPROP.Rows(f).Item("FPPRNUDO") & " Derecho: " & dt_FIPRPROP.Rows(f).Item("FPPRDERE"))
                                    End If

                                Next

                            End If
                        Next

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_162()
        Dim inconsistencia As String = "Caracteristica de predio invalido."
        Dim codigo As String = "162"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or _
                    dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
                    dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
                    dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Or _
                    dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 5 Or _
                    dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Or _
                    dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

                Else
                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_163()
        Dim inconsistencia As String = "Destinación económica invalido."
        Dim codigo As String = "163"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRDEEC.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                            If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                                If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 1 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 2 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 3 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 4 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 5 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 6 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 7 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 8 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 9 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 10 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 11 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 12 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 13 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 14 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 15 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 16 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 17 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 18 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 19 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 20 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 21 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 22 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 23 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 24 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 25 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 26 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 27 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 28 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 29 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 30 Or _
                                   dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 31 Then

                                Else
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                End If
                            End If
                        Next
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_164()
        Dim inconsistencia As String = "Modo de adquisición invalido."
        Dim codigo As String = "164"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    If dt_FICHPRED.Rows(0).Item("FIPRMOAD") = 1 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRMOAD") = 2 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRMOAD") = 3 Then

                    Else
                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_165()
        Dim inconsistencia As String = "Calidad del propietario invalido."
        Dim codigo As String = "165"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                If dt_FIPRPROP.Rows(i).Item("FPPRCAPR") = 1 Or _
                                    dt_FIPRPROP.Rows(i).Item("FPPRCAPR") = 2 Or _
                                    dt_FIPRPROP.Rows(i).Item("FPPRCAPR") = 3 Or _
                                    dt_FIPRPROP.Rows(i).Item("FPPRCAPR") = 4 Or _
                                    dt_FIPRPROP.Rows(i).Item("FPPRCAPR") = 5 Or _
                                    dt_FIPRPROP.Rows(i).Item("FPPRCAPR") = 6 Or _
                                    dt_FIPRPROP.Rows(i).Item("FPPRCAPR") = 7 Or _
                                    dt_FIPRPROP.Rows(i).Item("FPPRCAPR") = 8 Or _
                                    dt_FIPRPROP.Rows(i).Item("FPPRCAPR") = 9 Or _
                                    dt_FIPRPROP.Rows(i).Item("FPPRCAPR") = 10 Or _
                                    dt_FIPRPROP.Rows(i).Item("FPPRCAPR") = 11 Then

                                Else
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                End If

                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_166()
        Dim inconsistencia As String = "Tipo de documento invalido."
        Dim codigo As String = "166"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 1 Or _
                                    dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 2 Or _
                                    dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 3 Or _
                                    dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 4 Or _
                                    dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 5 Or _
                                    dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 6 Or _
                                    dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 7 Or _
                                    dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 8 Or _
                                    dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 9 Then

                                Else
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                End If

                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_167()
        Dim inconsistencia As String = "Ficha predial inactiva"
        Dim codigo As String = "167"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_168()
        Dim inconsistencia As String = "No existe corregimiento."
        Dim codigo As String = "168"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Or
                   dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Or
                   dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then

                    If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then

                        Dim obCORREGIMIENTO As New cla_CORREGIMIENTO
                        Dim tbCORREGIMIENTO As New DataTable

                        tbCORREGIMIENTO = obCORREGIMIENTO.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_X_CORREGIMIENTO(dt_FICHPRED.Rows(0).Item("FIPRDEPA"), _
                                                                                                                dt_FICHPRED.Rows(0).Item("FIPRMUNI"), _
                                                                                                                dt_FICHPRED.Rows(0).Item("FIPRCLSE"), _
                                                                                                                dt_FICHPRED.Rows(0).Item("FIPRCORR"))
                        If tbCORREGIMIENTO.Rows.Count = 0 Then
                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Corregimiento: " & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")))
                        End If

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_169()
        Dim inconsistencia As String = "No existe barrio."
        Dim codigo As String = "169"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Or
                   dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Or
                   dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then

                    If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then

                        Dim obBARRVERE As New cla_BARRVERE
                        Dim tbBARRVERE As New DataTable

                        tbBARRVERE = obBARRVERE.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_BAVE_X_BARRVERE(dt_FICHPRED.Rows(0).Item("FIPRDEPA"), _
                                                                                                      dt_FICHPRED.Rows(0).Item("FIPRMUNI"), _
                                                                                                      dt_FICHPRED.Rows(0).Item("FIPRCLSE"), _
                                                                                                      dt_FICHPRED.Rows(0).Item("FIPRCORR"), _
                                                                                                      dt_FICHPRED.Rows(0).Item("FIPRBARR"))
                        If tbBARRVERE.Rows.Count = 0 Then
                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Barrio: " & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")))
                        End If

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_170()
        Dim inconsistencia As String = "No existe vereda."
        Dim codigo As String = "170"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Or
                   dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Or
                   dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then

                    If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then

                        Dim obBARRVERE As New cla_BARRVERE
                        Dim tbBARRVERE As New DataTable

                        tbBARRVERE = obBARRVERE.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_BAVE_X_BARRVERE(dt_FICHPRED.Rows(0).Item("FIPRDEPA"), _
                                                                                                      dt_FICHPRED.Rows(0).Item("FIPRMUNI"), _
                                                                                                      dt_FICHPRED.Rows(0).Item("FIPRCLSE"), _
                                                                                                      dt_FICHPRED.Rows(0).Item("FIPRCORR"), _
                                                                                                      dt_FICHPRED.Rows(0).Item("FIPRMANZ"))
                        If tbBARRVERE.Rows.Count = 0 Then
                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Vereda: " & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")))
                        End If

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_171()
        Dim inconsistencia As String = "Predio baldio de propiedad de un particular y no es mejora."
        Dim codigo As String = "171"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then

                        If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

                            Dim byCONTADOR1 As Byte = 0

                            Dim sw1 As Byte = 0
                            Dim j1 As Integer = 0

                            While j1 < dt_FIPRPROP.Rows.Count And sw1 = 0
                                If dt_FIPRPROP.Rows(j1).Item("FPPRCAPR") = 1 Then
                                    byCONTADOR1 = 1
                                    sw1 = 1
                                Else
                                    j1 = j1 + 1
                                End If
                            End While

                            If byCONTADOR1 = 1 Then

                                Dim sw2 As Byte = 0
                                Dim j2 As Integer = 0

                                While j2 < dt_FIPRCONS.Rows.Count And sw2 = 0
                                    If CBool(dt_FIPRCONS.Rows(j2).Item("FPCOMEJO")) = False Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(j2).Item("FPCOUNID"))

                                        sw2 = 1
                                    Else
                                        j2 = j2 + 1
                                    End If
                                End While

                            End If

                        End If

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_172()
        Dim inconsistencia As String = "Predio sin categoria de predio."
        Dim codigo As String = "172"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If Trim(dt_FICHPRED.Rows(0).Item("FIPRTIFI")) = 0 Then

                    Dim objdatos As New cla_CAPRFIPR
                    Dim tbl As New DataTable

                    tbl = objdatos.fun_Buscar_CATEGORIA_X_NRO_DE_FICHA(Trim(dt_FICHPRED.Rows(0).Item("FIPRNUFI")))

                    If tbl.Rows.Count = 0 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                    End If

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub

#End Region

#Region "Validar FiprDeec 200"

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
            pro_Inconsistencia_214()
            pro_Inconsistencia_215()
            pro_Inconsistencia_216()
            pro_Inconsistencia_217()
            pro_Inconsistencia_218()
            pro_Inconsistencia_219()
            pro_Inconsistencia_220()
            pro_Inconsistencia_221()
            pro_Inconsistencia_222()
            pro_Inconsistencia_223()
            pro_Inconsistencia_224()
            pro_Inconsistencia_225()
            pro_Inconsistencia_226()
            pro_Inconsistencia_227()
            pro_Inconsistencia_228()
            pro_Inconsistencia_229()
            pro_Inconsistencia_230()
            pro_Inconsistencia_231()

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Destinación económica")
        End Try


    End Sub

    Private Sub pro_Inconsistencia_200()
        Dim inconsistencia As String = "Destino economico no suma el 100 %."
        Dim codigo As String = "200"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

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

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Total: " & inTOTAL)

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_201()
        Dim inconsistencia As String = "Área construida mayor o igual a cero para DE 12,13,14,15 y clase de cons. 1 o 2."
        Dim codigo As String = "201"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

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

                                            If Trim(dt_FIPRCONS.Rows(k).Item("FPCOESTA")) = "ac" Then

                                                stFPCOCLCO = dt_FIPRCONS.Rows(k).Item("FPCOCLCO")
                                                doFPCOARCO = CType(Trim(dt_FIPRCONS.Rows(k).Item("FPCOARCO")), Double)

                                                If stFPCOCLCO = 1 Or stFPCOCLCO = 2 Then
                                                    If doFPCOARCO >= 0 Then
                                                        If bySW = 0 Then

                                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Destino: " & dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") & " Área cons.: " & doFPCOARCO)

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

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_202()
        Dim inconsistencia As String = "En sector urbano no es valido destinaciones 17 y 18 ."
        Dim codigo As String = "202"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                        If dt_FIPRDEEC.Rows.Count > 0 Then

                            Dim i As Integer

                            For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                                If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                                    If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 17 Or dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 18 Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                    End If
                                End If
                            Next
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_203()
        Dim inconsistencia As String = "En sector rural no es valido destinaciones 12,13 y 14."
        Dim codigo As String = "203"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
                        If dt_FIPRDEEC.Rows.Count > 0 Then

                            Dim i As Integer

                            For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                                If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                                    If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 12 Or _
                                       dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 13 Or _
                                       dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 14 Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                    End If
                                End If
                            Next
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_204()
        Dim inconsistencia As String = "Destinaciones económica no valida para características 5."
        Dim codigo As String = "204"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

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

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                    End If
                                End If
                            Next
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_205()
        Dim inconsistencia As String = "Destinación económica 16 invalida para característica 4."
        Dim codigo As String = "205"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then
                        If dt_FIPRDEEC.Rows.Count > 0 Then

                            Dim i As Integer

                            For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                                If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                                    If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 16 Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                    End If
                                End If
                            Next
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_206()
        Dim inconsistencia As String = "Destinación económica invalida para características 2,3 o 4 sector 1."
        Dim codigo As String = "206"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then


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

                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                        End If
                                    End If
                                Next
                            End If
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_207()
        Dim inconsistencia As String = "Destinación económica no valida para características 6 sector 2."
        Dim codigo As String = "207"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

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

                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                        End If
                                    End If
                                Next
                            End If
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_208()
        Dim inconsistencia As String = "Destinación económica no valida para características 7."
        Dim codigo As String = "208"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 AndAlso _
                   dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

                    If dt_FIPRDEEC.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                            If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                                If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 4 Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Destino: " & dt_FIPRDEEC.Rows(i).Item("FPDEDEEC"))

                                End If
                            End If
                        Next
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_209()
        Dim inconsistencia As String = "Destinación económica 17 no valida para calidad de propietario diferente a 2"
        Dim codigo As String = "209"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

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

                                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento nro: " & dt_FIPRPROP.Rows(k).Item("FPPRNUDO"))

                                                End If
                                            End If
                                        Next
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_210()
        Dim inconsistencia As String = "Destinación económica 18 no valida para cálida del propietario diferente a 7 "
        Dim codigo As String = "210"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

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

                                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento nro: " & dt_FIPRPROP.Rows(k).Item("FPPRNUDO"))

                                                End If
                                            End If
                                        Next
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_211()
        Dim inconsistencia As String = "% Destinación económica diferente a 100 para DE 9-12-13-14-15-16-17-18-19."
        Dim codigo As String = "211"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

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

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Destino nro: " & dt_FIPRDEEC.Rows(i).Item("FPDEDEEC"))

                                    End If
                                End If
                            End If
                        Next
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_212()
        Dim inconsistencia As String = "D.E. 16 con construcción para característica 2 o 3 y clase cons. 1 o 2."
        Dim codigo As String = "212"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

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

                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(k).Item("FPCOUNID"))

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

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_213()
        Dim inconsistencia As String = "D.E. diferente de 1,2,3,6,7,8,15,19,27,31 para predios rurales con área de terreno menor a 2000 mts"
        Dim codigo As String = "213"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
                        If dt_FICHPRED.Rows(0).Item("FIPRARTE") < 2000 Then
                            If dt_FICHPRED.Rows(0).Item("FIPRARTE") <> 0 Then
                                If dt_FIPRDEEC.Rows.Count > 0 Then

                                    Dim i As Integer

                                    For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                                        If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                                            If CInt(dt_FIPRDEEC.Rows(i).Item("FPDEDEEC")) <> 1 And _
                                               CInt(dt_FIPRDEEC.Rows(i).Item("FPDEDEEC")) <> 2 And _
                                               CInt(dt_FIPRDEEC.Rows(i).Item("FPDEDEEC")) <> 3 And _
                                               CInt(dt_FIPRDEEC.Rows(i).Item("FPDEDEEC")) <> 6 And _
                                               CInt(dt_FIPRDEEC.Rows(i).Item("FPDEDEEC")) <> 8 And _
                                               CInt(dt_FIPRDEEC.Rows(i).Item("FPDEDEEC")) <> 19 And _
                                               CInt(dt_FIPRDEEC.Rows(i).Item("FPDEDEEC")) <> 27 And _
                                               CInt(dt_FIPRDEEC.Rows(i).Item("FPDEDEEC")) <> 29 And _
                                               CInt(dt_FIPRDEEC.Rows(i).Item("FPDEDEEC")) <> 31 And
                                               CInt(dt_FIPRDEEC.Rows(i).Item("FPDEDEEC")) <> 15 And _
                                               CInt(dt_FIPRDEEC.Rows(i).Item("FPDEDEEC")) <> 7 Then

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Destino nro: " & dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") & " Área terreno: " & dt_FICHPRED.Rows(0).Item("FIPRARTE"))

                                            End If
                                        End If

                                    Next

                                End If
                            End If
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_214()
        Dim inconsistencia As String = "Porcentaje de destinación económica en cero ‘0’."
        Dim codigo As String = "214"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                    If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                        If CType(dt_FIPRDEEC.Rows(i).Item("FPDEPORC"), Integer) = "0" Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Destino: " & dt_FIPRDEEC.Rows(i).Item("FPDEDEEC"))

                        End If
                    End If

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_215()
        Dim inconsistencia As String = "D.E. 16 con caracteristica de predio 1 o 3."
        Dim codigo As String = "215"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FIPRDEEC.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                        If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                            If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 16 Then
                                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Destino: " & dt_FIPRDEEC.Rows(i).Item("FPDEDEEC"))

                                End If
                            End If
                        End If

                    Next

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_216()
        Dim inconsistencia As String = "D.E. 4,5,13,14,15 o 19 con caracteristica de predio diferente de 1 Normal ó 6 Embalse."
        Dim codigo As String = "216"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FIPRDEEC.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                        If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                            If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 4 Or _
                               dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 5 Or _
                               dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 13 Or _
                               dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 14 Or _
                               dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 15 Or _
                               dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 19 Then

                                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") <> 1 And dt_FICHPRED.Rows(0).Item("FIPRCAPR") <> 6 Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Destino: " & dt_FIPRDEEC.Rows(i).Item("FPDEDEEC"))

                                End If
                            End If

                        End If

                    Next

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_217()
        Dim inconsistencia As String = "D.E. 4,5,20 para predio urbano."
        Dim codigo As String = "217"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                    If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                        If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 4 Or _
                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 5 Or _
                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 20 Then

                            If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then

                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Destino: " & dt_FIPRDEEC.Rows(i).Item("FPDEDEEC"))

                            End If

                        End If
                    End If

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_218()
        Dim inconsistencia As String = "D.E. 12,13,14,15 con caracteristica de predio 3 para el sector urbano."
        Dim codigo As String = "218"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                    If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                        If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 12 Or _
                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 13 Or _
                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 14 Or _
                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 15 Then

                            If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 And dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then

                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Destino: " & dt_FIPRDEEC.Rows(i).Item("FPDEDEEC"))

                            End If

                        End If
                    End If

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_219()
        Dim inconsistencia As String = "D.E. 19 con clase de documento o genero diferente de 3."
        Dim codigo As String = "219"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                    If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                        If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 19 Then

                            If dt_FIPRPROP.Rows.Count > 0 Then

                                Dim j As Integer

                                For j = 0 To dt_FIPRPROP.Rows.Count - 1

                                    If Trim(dt_FIPRPROP.Rows(j).Item("FPPRESTA")) = "ac" Then
                                        If (dt_FIPRPROP.Rows(j).Item("FPPRTIDO") <> 3 And _
                                           dt_FIPRPROP.Rows(j).Item("FPPRTIDO") <> 8) Or _
                                           dt_FIPRPROP.Rows(j).Item("FPPRSEXO") <> 3 Then

                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Nro. documento: " & dt_FIPRPROP.Rows(j).Item("FPPRNUDO"))

                                        End If
                                    End If

                                Next

                            End If

                        End If
                    End If

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_220()
        Dim inconsistencia As String = "D.E. 15 con calidad de propietario diferente de 1 Particular."
        Dim codigo As String = "220"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                    If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                        If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 15 Then

                            If dt_FIPRPROP.Rows.Count > 0 Then

                                Dim j As Integer

                                For j = 0 To dt_FIPRPROP.Rows.Count - 1

                                    If Trim(dt_FIPRPROP.Rows(j).Item("FPPRESTA")) = "ac" Then
                                        If dt_FIPRPROP.Rows(j).Item("FPPRCAPR") <> 1 Then

                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Nro. documento: " & dt_FIPRPROP.Rows(j).Item("FPPRNUDO"))

                                        End If
                                    End If

                                Next

                            End If

                        End If
                    End If

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_221()
        Dim inconsistencia As String = "D.E. 19 con calidad de propietario diferente de 2,3 o 4."
        Dim codigo As String = "221"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                    If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                        If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 19 Then

                            If dt_FIPRPROP.Rows.Count > 0 Then

                                Dim j As Integer

                                For j = 0 To dt_FIPRPROP.Rows.Count - 1

                                    If Trim(dt_FIPRPROP.Rows(j).Item("FPPRESTA")) = "ac" Then
                                        If dt_FIPRPROP.Rows(j).Item("FPPRCAPR") <> 2 And _
                                           dt_FIPRPROP.Rows(j).Item("FPPRCAPR") <> 3 And _
                                           dt_FIPRPROP.Rows(j).Item("FPPRCAPR") <> 4 Then

                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Nro. documento: " & dt_FIPRPROP.Rows(j).Item("FPPRNUDO"))

                                        End If
                                    End If

                                Next

                            End If

                        End If
                    End If

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_222()
        Dim inconsistencia As String = "D.E. 13 con área de terreno menor a 2000 mts. Para el sector urbano"
        Dim codigo As String = "222"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                        If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                            If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 13 Then
                                If dt_FICHPRED.Rows(0).Item("FIPRARTE") < 2000 Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Area terreno: " & dt_FICHPRED.Rows(0).Item("FIPRARTE"))

                                End If
                            End If
                        End If

                    Next

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_223()
        Dim inconsistencia As String = "D.E. 1 con área de terreno mayor a 30000 mts. Para el sector rural."
        Dim codigo As String = "223"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRARTE") > 30000 Then
                        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then

                            Dim i As Integer

                            For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                                If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                                    If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 1 Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Area terreno: " & dt_FICHPRED.Rows(0).Item("FIPRARTE"))

                                    End If
                                End If

                            Next

                        End If

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_224()
        Dim inconsistencia As String = "D.E. 4,5,11,17,18,20,24 con área de terreno menor a 2000 mts. Para el sector rural."
        Dim codigo As String = "224"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRARTE") < 2000 Then
                        If dt_FICHPRED.Rows(0).Item("FIPRARTE") <> 0 Then
                            If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then

                                Dim i As Integer

                                For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                                    If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                                        If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 4 Or _
                                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 5 Or _
                                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 11 Or _
                                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 17 Or _
                                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 18 Or _
                                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 24 Or _
                                           dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 20 Then

                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Area terreno: " & dt_FICHPRED.Rows(0).Item("FIPRARTE") & " Destino: " & dt_FIPRDEEC.Rows(i).Item("FPDEDEEC"))

                                        End If
                                    End If

                                Next

                            End If

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_225()
        Dim inconsistencia As String = "Predio con mas de un destino económico."
        Dim codigo As String = "225"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    Dim inContador As Integer = 0
                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                        If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                            inContador += 1
                        End If

                    Next

                    If inContador > 1 Then
                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                    End If

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_226()
        Dim inconsistencia As String = "D.E. 12,13 o 14 donde el área de construcción es mayor al 16% sobre el área de terreno."
        Dim codigo As String = "226"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRARTE") > 0 Then
                        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then

                            Dim doResultado As Double = 0.0
                            Dim i As Integer = 0

                            For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                                If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                                    If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 12 Or _
                                       dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 13 Or _
                                       dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 14 Then

                                        If dt_FIPRCONS.Rows.Count > 0 Then

                                            Dim doAreaConstruccion As Double = 0.0
                                            Dim k As Integer = 0

                                            For k = 0 To dt_FIPRCONS.Rows.Count - 1

                                                If Trim(dt_FIPRCONS.Rows(k).Item("FPCOESTA")) = "ac" Then
                                                    If dt_FIPRCONS.Rows(k).Item("FPCOCLCO") = 1 Or _
                                                       dt_FIPRCONS.Rows(k).Item("FPCOCLCO") = 2 Then

                                                        doAreaConstruccion += CType(Trim(dt_FIPRCONS.Rows(k).Item("FPCOARCO")), Decimal)

                                                    End If
                                                End If

                                            Next

                                            doResultado = ((doAreaConstruccion * 100) / CInt(dt_FICHPRED.Rows(0).Item("FIPRARTE")))

                                        End If

                                        If doResultado > 16 Then

                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                        End If

                                    End If
                                End If

                            Next

                        End If

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_227()
        Dim inconsistencia As String = "D.E. 12,13 o 14 Con construcción no valorable privada clase 3."
        Dim codigo As String = "227"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRARTE") > 0 Then
                        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then

                            Dim i As Integer = 0

                            For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                                If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                                    If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 12 Or _
                                       dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 13 Or _
                                       dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 14 Then

                                        If dt_FIPRCONS.Rows.Count > 0 Then

                                            Dim k As Integer = 0

                                            For k = 0 To dt_FIPRCONS.Rows.Count - 1

                                                If Trim(dt_FIPRCONS.Rows(k).Item("FPCOESTA")) = "ac" Then
                                                    If dt_FIPRCONS.Rows(k).Item("FPCOCLCO") = 3 Then

                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                                    End If
                                                End If

                                            Next

                                        End If

                                    End If
                                End If

                            Next

                        End If

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_228()
        Dim inconsistencia As String = "En sector urbano no es valido destinaciones 21, 22, 23, 24, 25, 28 y 31."
        Dim codigo As String = "228"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                        If dt_FIPRDEEC.Rows.Count > 0 Then

                            Dim i As Integer

                            For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                                If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                                    If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 21 Or _
                                       dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 22 Or _
                                       dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 23 Or _
                                       dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 24 Or _
                                       dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 25 Or _
                                       dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 28 Or _
                                       dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 31 Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                    End If
                                End If
                            Next
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_229()
        Dim inconsistencia As String = "D.E. 27 Sin construcción valorable con identificador 056 o 009 (construcciones educativas)."
        Dim codigo As String = "229"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Then
                        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then

                            Dim i As Integer = 0

                            For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                                If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                                    If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 27 Then

                                        If dt_FIPRCONS.Rows.Count > 0 Then

                                            Dim k As Integer = 0
                                            Dim bySW As Byte = 0

                                            For k = 0 To dt_FIPRCONS.Rows.Count - 1

                                                If Trim(dt_FIPRCONS.Rows(k).Item("FPCOESTA")) = "ac" Then
                                                    If dt_FIPRCONS.Rows(k).Item("FPCOTICO") = "056" Then

                                                        bySW = 1

                                                    End If
                                                End If

                                            Next

                                            If bySW = 0 Then

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                            End If

                                        End If

                                    End If
                                End If

                            Next

                        ElseIf dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then

                            Dim i As Integer = 0

                            For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                                If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                                    If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 27 Then

                                        If dt_FIPRCONS.Rows.Count > 0 Then

                                            Dim k As Integer = 0
                                            Dim bySW As Byte = 0

                                            For k = 0 To dt_FIPRCONS.Rows.Count - 1

                                                If Trim(dt_FIPRCONS.Rows(k).Item("FPCOESTA")) = "ac" Then
                                                    If dt_FIPRCONS.Rows(k).Item("FPCOTICO") = "009" Then

                                                        bySW = 1

                                                    End If
                                                End If

                                            Next

                                            If bySW = 0 Then

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                            End If

                                        End If

                                    End If
                                End If

                            Next
                        End If

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_230()
        Dim inconsistencia As String = "D.E. 29 Sin construcción valorable con identificador 011 ó 067 (Iglesias)."
        Dim codigo As String = "230"
        Dim stError As String = "AVISO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Then
                        If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Or
                           dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then

                            Dim i As Integer = 0

                            For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                                If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                                    If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 29 Then

                                        If dt_FIPRCONS.Rows.Count > 0 Then

                                            Dim k As Integer = 0
                                            Dim bySW As Byte = 0

                                            For k = 0 To dt_FIPRCONS.Rows.Count - 1

                                                If Trim(dt_FIPRCONS.Rows(k).Item("FPCOESTA")) = "ac" Then
                                                    If dt_FIPRCONS.Rows(k).Item("FPCOTICO") = "011" Or _
                                                       dt_FIPRCONS.Rows(k).Item("FPCOTICO") = "067" Then

                                                        bySW = 1

                                                    End If
                                                End If

                                            Next

                                            If bySW = 0 Then

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                            End If

                                        End If

                                    End If
                                End If

                            Next

                        End If

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_231()
        Dim inconsistencia As String = "Área construida mayor o igual a cero para DE 31 y clase de cons. 1 o 2."
        Dim codigo As String = "231"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRDEEC.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRDEEC.Rows.Count - 1

                            If Trim(dt_FIPRDEEC.Rows(i).Item("FPDEESTA")) = "ac" Then
                                If dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") = 31 Then

                                    If dt_FIPRCONS.Rows.Count > 0 Then

                                        Dim k As Integer
                                        Dim bySW As Byte
                                        Dim stFPCOCLCO As String
                                        Dim doFPCOARCO As Double

                                        For k = 0 To dt_FIPRCONS.Rows.Count - 1

                                            If Trim(dt_FIPRCONS.Rows(k).Item("FPCOESTA")) = "ac" Then

                                                stFPCOCLCO = dt_FIPRCONS.Rows(k).Item("FPCOCLCO")
                                                doFPCOARCO = CType(Trim(dt_FIPRCONS.Rows(k).Item("FPCOARCO")), Double)

                                                If stFPCOCLCO = 1 Or stFPCOCLCO = 2 Then
                                                    If doFPCOARCO >= 0 Then
                                                        If bySW = 0 Then

                                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Destino: " & dt_FIPRDEEC.Rows(i).Item("FPDEDEEC") & " Área cons.: " & doFPCOARCO)

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

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub

#End Region

#Region "Validar FiprProp 300"

    Private Sub pro_ValidarFiprProp()

        Try

            ' Inconsistencias propietario
            pro_Inconsistencia_303()
            pro_Inconsistencia_304()
            pro_Inconsistencia_305()
            pro_Inconsistencia_306()
            pro_Inconsistencia_307()
            pro_Inconsistencia_308()
            pro_Inconsistencia_309()
            pro_Inconsistencia_310()
            pro_Inconsistencia_311()
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
            pro_Inconsistencia_344()
            pro_Inconsistencia_345()
            pro_Inconsistencia_346()
            pro_Inconsistencia_347()
            pro_Inconsistencia_348()
            pro_Inconsistencia_349()
            pro_Inconsistencia_350()
            pro_Inconsistencia_351()
            pro_Inconsistencia_352()
            pro_Inconsistencia_353()
            pro_Inconsistencia_354()
            pro_Inconsistencia_355()
            pro_Inconsistencia_356()
            pro_Inconsistencia_357()
            pro_Inconsistencia_358()
            pro_Inconsistencia_359()
            pro_Inconsistencia_360()
            pro_Inconsistencia_361()
            pro_Inconsistencia_362()
            pro_Inconsistencia_363()
            pro_Inconsistencia_364()
            pro_Inconsistencia_365()
            pro_Inconsistencia_366()
            pro_Inconsistencia_367()
            pro_Inconsistencia_368()
            pro_Inconsistencia_369()
            pro_Inconsistencia_370()
            pro_Inconsistencia_371()
            pro_Inconsistencia_372()

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Propietario")
        End Try

    End Sub

    Private Sub pro_Inconsistencia_303()
        Dim inconsistencia As String = "Rango de nro. de documento errado para clase de documento 1 cédula de hombre."
        Dim codigo As String = "303"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

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

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento nro: " & stNUMEDOCU)

                                    Else
                                        If (Val(stNUMEDOCU) > 0 And Val(stNUMEDOCU) < 20000000) Then
                                            byINCO = 1
                                        ElseIf (Val(stNUMEDOCU) > 70000000 And Val(stNUMEDOCU) < 100000000) Then
                                            byINCO = 1
                                        End If
                                    End If

                                    If byINCO = 0 Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento nro: " & stNUMEDOCU)

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_304()
        Dim inconsistencia As String = "Rango de nro. de documento errado para clase de documento 2 cédula de mujeres."
        Dim codigo As String = "304"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer
                        Dim stNUMEDOCU As String

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 2 Then

                                    stNUMEDOCU = Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO"))

                                    If fun_Verificar_Dato_Numerico_Evento_Validated(stNUMEDOCU) = False Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento nro: " & stNUMEDOCU)

                                    Else
                                        If Not (Val(stNUMEDOCU) > 20000000 And Val(stNUMEDOCU) < 70000000) Then

                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento nro: " & stNUMEDOCU)

                                        End If
                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_305()
        Dim inconsistencia As String = "Primer apellido en blanco."
        Dim codigo As String = "305"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If dt_FIPRPROP.Rows(i).Item("FPPRPRAP").ToString.Length = 0 Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento nro: " & dt_FIPRPROP.Rows(i).Item("FPPRNUDO"))

                                End If
                            End If

                        Next

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_306()
        Dim inconsistencia As String = "Nombre en blanco."
        Dim codigo As String = "306"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If dt_FIPRPROP.Rows(i).Item("FPPRNOMB").ToString.Length = 0 Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento nro: " & dt_FIPRPROP.Rows(i).Item("FPPRNUDO"))

                                End If
                            End If

                        Next

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_307()
        Dim inconsistencia As String = "Formato de matricula invalida para derecho real o sucesión."
        Dim codigo As String = "307"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

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
                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Circulo de registro: " & stCirculoRegistro)
                                        End If
                                        If stSeparador <> "-" Then
                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Separador: " & stSeparador)
                                        End If
                                        If fun_Verificar_Dato_Numerico_Evento_Validated(stMatricula) = False Then
                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Matricula: " & stMatricula)
                                        End If
                                    Else
                                        If Trim(dt_FIPRPROP.Rows(i).Item("FPPRTOMO")) = 0 Then
                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Matricula: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN")))
                                        End If
                                    End If
                                End If
                            End If
                        Next

                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_308()
        Dim inconsistencia As String = "Predio en posesión con datos juridicos."
        Dim codigo As String = "308"
        Dim stError As String = "SEVERO"

        Try
            Dim filas() As DataRow
            filas = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If dt_FIPRPROP.Rows(i).Item("FPPRMOAD") = 2 Then

                                    'If Val(Trim(dt_FIPRPROP.Rows(i).Item("FPPRESCR"))) <> 0 Then
                                    '    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Nro escritura: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRESCR")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                    'End If
                                    'If Trim(dt_FIPRPROP.Rows(i).Item("FPPRDENO")).ToString.Length > 0 Then
                                    '    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Departamento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRDEPA")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                    'End If
                                    'If Trim(dt_FIPRPROP.Rows(i).Item("FPPRMUNO")).ToString.Length > 0 Then
                                    '    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Municipio: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRMUNI")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                    'End If
                                    'If Trim(dt_FIPRPROP.Rows(i).Item("FPPRNOTA")).ToString.Length > 0 Then
                                    '    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Notaria: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNOTA")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                    'End If
                                    'If Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")).ToString.Length > 0 Then
                                    '    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Fecha escritura: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                    'End If
                                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")).ToString.Length > 0 Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Fecha registro: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                    End If
                                    If Val(Trim(dt_FIPRPROP.Rows(i).Item("FPPRTOMO"))) <> 0 Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Tomo: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRTOMO")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                    End If
                                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN")).ToString.Length > 0 Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Matricula: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                    End If

                                End If
                            End If
                        Next

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_309()
        Dim inconsistencia As String = "Primer apellido inicia con espacio a la izquierda."
        Dim codigo As String = "309"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim filas() As DataRow

                        filas = dt_FIPRPROP.Select("FPPRPRAP like ' %' and FPPRESTA = 'ac'")

                        If filas.Length > 0 Then
                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                        End If

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_310()
        Dim inconsistencia As String = "Segundo apellido inicia con espacio a la izquierda."
        Dim codigo As String = "310"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim filas() As DataRow

                        filas = dt_FIPRPROP.Select("FPPRSEAP like ' %' and FPPRESTA = 'ac'")

                        If filas.Length > 0 Then
                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                        End If

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_311()
        Dim inconsistencia As String = "Nombre inicia con espacio a la izquierda."
        Dim codigo As String = "311"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim filas() As DataRow

                        filas = dt_FIPRPROP.Select("FPPRNOMB like ' %' and FPPRESTA = 'ac'")

                        If filas.Length > 0 Then
                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                        End If

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_319()
        Dim inconsistencia As String = "Porcentaje de litigio invalido."
        Dim codigo As String = "319"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRLITI") = True Then

                        Dim stFIPRMUNI As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                        Dim stFIPRCORR As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR"))
                        Dim stFIPRBARR As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR"))
                        Dim stFIPRMANZ As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ"))
                        Dim stFIPRPRED As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED"))
                        Dim stFIPREDIF As String = Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF"))
                        Dim stFIPRUNPR As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRUNPR"))
                        Dim stFIPRCLSE As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE"))
                        Dim stFIPRESTA As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRESTA"))
                        Dim stFIPRTIFI As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRTIFI"))
                        Dim boFIPRLITI As Boolean = dt_FICHPRED.Rows(0).Item("FIPRLITI")

                        Dim objdatos As New cla_VALIFIPR
                        dt = New DataTable

                        dt = objdatos.fun_Consultar_PORCENTAJE_LITIGIO_INVALIDO_INCO_319(stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, stFIPREDIF, stFIPRUNPR, stFIPRCLSE, stFIPRESTA, stFIPRTIFI, boFIPRLITI)

                        Dim i As Integer
                        Dim deTOTAL As Decimal

                        For i = 0 To dt.Rows.Count - 1

                            deTOTAL += Trim(dt.Rows(i).Item("FIPRPOLI"))

                        Next

                        If deTOTAL <> 200 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Total porcentaje: " & deTOTAL)

                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_320()
        Dim inconsistencia As String = "Faltan datos juridicos para predio en derecho real o sucesión."
        Dim codigo As String = "320"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If dt_FIPRPROP.Rows(i).Item("FPPRMOAD") = 1 Or dt_FIPRPROP.Rows(i).Item("FPPRMOAD") = 3 Then

                                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRDENO")).ToString.Length = 0 Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Departamento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRDEPA")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                    End If
                                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRMUNO")).ToString.Length = 0 Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Municipio: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRMUNI")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                    End If
                                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRNOTA")).ToString.Length = 0 Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Notaria: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNOTA")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                    End If
                                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")).ToString.Length = 0 Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Fecha escritura: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                    End If
                                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")).ToString.Length = 0 Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Fecha registro: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                    End If
                                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN")).ToString.Length = 0 Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Matricula: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                    End If

                                End If
                            End If
                        Next

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_323()
        Dim inconsistencia As String = "Derecho no es igual al 100 %."
        Dim codigo As String = "323"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    ' predio con adquisicion derecho real o posesion
                    If dt_FICHPRED.Rows(0).Item("FIPRMOAD") = 1 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRMOAD") = 2 Then

                        If dt_FIPRPROP.Rows.Count > 0 Then

                            Dim i As Integer
                            Dim deTOTAL As Decimal

                            For i = 0 To dt_FIPRPROP.Rows.Count - 1

                                If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                    deTOTAL += Trim(dt_FIPRPROP.Rows(i).Item("FPPRDERE"))

                                End If

                            Next

                            If deTOTAL <> 100 Then

                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Total: " & deTOTAL)

                            End If


                        End If

                        ' predio con adquisicion sucesion
                    ElseIf dt_FICHPRED.Rows(0).Item("FIPRMOAD") = 3 Then

                        If dt_FIPRPROP.Rows.Count > 0 Then

                            Dim iNO_GRAVABLE_MOAD_3 As Integer = 0
                            Dim iSI_GRAVABLE_MOAD_3 As Integer = 0
                            Dim iSI_GRAVABLE_MOAD_2 As Integer = 0

                            Dim deTOTAL_NO_GRAVABLE_MOAD_3 As Decimal = 0.0
                            Dim deTOTAL_SI_GRAVABLE_MOAD_3 As Decimal = 0.0
                            Dim deTOTAL_SI_GRAVABLE_MOAD_2 As Decimal = 0.0

                            Dim bo_GRAV_NO_MOAD_3 As Boolean = False
                            Dim bo_GRAV_SI_MOAD_3 As Boolean = False
                            Dim bo_GRAV_SI_MOAD_2 As Boolean = False

                            ' gravable verdadero y adquision sucesion
                            For iSI_GRAVABLE_MOAD_3 = 0 To dt_FIPRPROP.Rows.Count - 1

                                If CStr(Trim(dt_FIPRPROP.Rows(iSI_GRAVABLE_MOAD_3).Item("FPPRESTA"))) = "ac" And _
                                   CBool(dt_FIPRPROP.Rows(iSI_GRAVABLE_MOAD_3).Item("FPPRGRAV")) = True And _
                                   CInt(dt_FIPRPROP.Rows(iSI_GRAVABLE_MOAD_3).Item("FPPRMOAD")) = 3 Then

                                    deTOTAL_SI_GRAVABLE_MOAD_3 += CDec(Trim(dt_FIPRPROP.Rows(iSI_GRAVABLE_MOAD_3).Item("FPPRDERE")))
                                    bo_GRAV_SI_MOAD_3 = True

                                End If

                            Next

                            ' gravable falso y adquision sucesion
                            For iNO_GRAVABLE_MOAD_3 = 0 To dt_FIPRPROP.Rows.Count - 1

                                If CStr(Trim(dt_FIPRPROP.Rows(iNO_GRAVABLE_MOAD_3).Item("FPPRESTA"))) = "ac" And _
                                   CBool(dt_FIPRPROP.Rows(iNO_GRAVABLE_MOAD_3).Item("FPPRGRAV")) = False And _
                                   CInt(dt_FIPRPROP.Rows(iNO_GRAVABLE_MOAD_3).Item("FPPRMOAD")) = 3 Then

                                    deTOTAL_NO_GRAVABLE_MOAD_3 += CDec(Trim(dt_FIPRPROP.Rows(iNO_GRAVABLE_MOAD_3).Item("FPPRDERE")))
                                    bo_GRAV_NO_MOAD_3 = True

                                End If

                            Next

                            ' gravable verdadero y adquision posesion
                            For iSI_GRAVABLE_MOAD_2 = 0 To dt_FIPRPROP.Rows.Count - 1

                                If CStr(Trim(dt_FIPRPROP.Rows(iSI_GRAVABLE_MOAD_2).Item("FPPRESTA"))) = "ac" And _
                                   CBool(dt_FIPRPROP.Rows(iSI_GRAVABLE_MOAD_2).Item("FPPRGRAV")) = True And _
                                   CInt(dt_FIPRPROP.Rows(iSI_GRAVABLE_MOAD_2).Item("FPPRMOAD")) = 2 Then

                                    deTOTAL_SI_GRAVABLE_MOAD_2 += CDec(Trim(dt_FIPRPROP.Rows(iSI_GRAVABLE_MOAD_2).Item("FPPRDERE")))
                                    bo_GRAV_SI_MOAD_2 = True

                                End If

                            Next

                            ' verifica los derechos
                            If bo_GRAV_SI_MOAD_3 = True Then

                                If deTOTAL_SI_GRAVABLE_MOAD_3 <> 100 Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Propietarios si gravables en sucesion. " & " Total: " & deTOTAL_SI_GRAVABLE_MOAD_3)

                                End If

                            End If

                            If bo_GRAV_NO_MOAD_3 = True Then

                                If deTOTAL_NO_GRAVABLE_MOAD_3 <> 100 Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Propietarios no gravables en sucesion. " & " Total: " & deTOTAL_NO_GRAVABLE_MOAD_3)

                                End If

                            End If

                            If bo_GRAV_SI_MOAD_2 = True Then

                                If deTOTAL_SI_GRAVABLE_MOAD_2 <> 100 Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Propietarios si gravables en posesion. " & " Total: " & deTOTAL_SI_GRAVABLE_MOAD_2)

                                End If

                            End If

                            If bo_GRAV_SI_MOAD_3 = True And bo_GRAV_SI_MOAD_2 = True Then

                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Existen propietarios si gravables en sucesion y posesion. " & " Total: " & (deTOTAL_SI_GRAVABLE_MOAD_3 + deTOTAL_SI_GRAVABLE_MOAD_2))

                            End If

                        End If

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_325()
        Dim inconsistencia As String = "Documento inicia con ceros o espacio a la izquierda."
        Dim codigo As String = "325"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                If fun_Verificar_Dato_Numerico_Evento_Validated(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")) = True Then
                                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")).ToString.Substring(0, 1) = 0 Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                    End If

                                Else
                                    If dt_FIPRPROP.Rows(i).Item("FPPRNUDO").ToString.Substring(0, 1) = " " Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_329()
        Dim inconsistencia As String = "Formato o fecha invalida para predio en derecho real o sucesión."
        Dim codigo As String = "329"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If dt_FIPRPROP.Rows(i).Item("FPPRMOAD") = 1 Or dt_FIPRPROP.Rows(i).Item("FPPRMOAD") = 3 Then

                                    If Not IsDate(Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES"))) Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Fecha escritura: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                    End If

                                    If Not IsDate(Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE"))) Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Fecha registro: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                    End If

                                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")).ToString.Length = 10 Then

                                        Dim stFPPRFEES_DIA As String = Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")).ToString.Substring(0, 2)
                                        Dim stFPPRFEES_MES As String = Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")).ToString.Substring(3, 2)
                                        Dim stFPPRFEES_ANO As String = Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")).ToString.Substring(6, 4)

                                        If fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRFEES_DIA) = False Then
                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Dia fecha escritura: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                        End If
                                        If fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRFEES_MES) = False Then
                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Mes fecha escritura: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                        End If
                                        If fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRFEES_ANO) = False Then
                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Año fecha escritura: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                        End If

                                        If stFPPRFEES_ANO < 1778 Then
                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Año de escritura menor a 1778 - Fecha: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                        End If
                                    Else
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Fecha escritura: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFEES")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                    End If

                                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")).ToString.Length = 10 Then

                                        Dim stFPPRFERE_DIA As String = Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")).ToString.Substring(0, 2)
                                        Dim stFPPRFERE_MES As String = Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")).ToString.Substring(3, 2)
                                        Dim stFPPRFERE_ANO As String = Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")).ToString.Substring(6, 4)

                                        If fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRFERE_DIA) = False Then
                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Dia fecha registro: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                        End If
                                        If fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRFERE_MES) = False Then
                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Mes fecha registro: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                        End If
                                        If fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRFERE_ANO) = False Then
                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Año fecha registro: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                        End If

                                        If stFPPRFERE_ANO < 1778 Then
                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Año de registro menor a 1778 - Fecha: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                        End If
                                    Else
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Fecha registro: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRFERE")) & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))
                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_335()
        Dim inconsistencia As String = "Rango de nro. de documento errado para clase de documento 3 persona juridica."
        Dim codigo As String = "335"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer
                        Dim stNUMEDOCU As String

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 3 Then

                                    stNUMEDOCU = Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO"))

                                    If fun_Verificar_Dato_Numerico_Evento_Validated(stNUMEDOCU) = False Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento nro: " & stNUMEDOCU)

                                    Else
                                        If Not (Val(stNUMEDOCU) > 800000000 And Val(stNUMEDOCU) < 999999999) Then

                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento nro: " & stNUMEDOCU)

                                        End If
                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_340()
        Dim inconsistencia As String = "Rango de nro. de documento errado para clase de documento 9 NÚIP."
        Dim codigo As String = "340"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer
                        Dim stNUMEDOCU As String

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 9 Then

                                    stNUMEDOCU = Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO"))

                                    If fun_Verificar_Dato_Numerico_Evento_Validated(stNUMEDOCU) = False Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento nro: " & stNUMEDOCU)

                                    Else
                                        If (Val(stNUMEDOCU) < 1000000000) Then

                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento nro: " & stNUMEDOCU)

                                        End If
                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_341()
        Dim inconsistencia As String = "Calidad de propietario 4 municipal marcado como gravable."
        Dim codigo As String = "341"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If dt_FIPRPROP.Rows(i).Item("FPPRCAPR") = 4 Then
                                    If dt_FIPRPROP.Rows(i).Item("FPPRGRAV") = True Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Nro. Documento: " & dt_FIPRPROP.Rows(i).Item("FPPRNUDO"))

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_342()
        Dim inconsistencia As String = "Propietario marcado como no gravable para calidad de propietario incorrecta."
        Dim codigo As String = "342"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then


                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If dt_FIPRPROP.Rows(i).Item("FPPRGRAV") = False Then
                                    If dt_FIPRPROP.Rows(i).Item("FPPRCAPR") <> 4 Then
                                        If dt_FIPRPROP.Rows(i).Item("FPPRMOAD") <> 3 Then

                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Nro. Documento: " & dt_FIPRPROP.Rows(i).Item("FPPRNUDO"))

                                        End If
                                    End If
                                End If
                            End If

                        Next

                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_343()
        Dim inconsistencia As String = "Matricula diferente para predio con más de un propietario."
        Dim codigo As String = "343"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRPROP.Rows.Count > 0 Then

                    Dim stMATRICULA As String = ""
                    Dim bySW As Byte = 0
                    Dim i As Integer

                    For i = 0 To dt_FIPRPROP.Rows.Count - 1

                        If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                            If bySW = 0 Then
                                stMATRICULA = Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN"))
                                bySW = 1
                            End If

                            If stMATRICULA <> Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN")) Then

                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                            End If
                        End If

                    Next

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_344()
        Dim inconsistencia As String = "Genero invalido para clase de documento 1."
        Dim codigo As String = "344"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = "1" Then
                                    If dt_FIPRPROP.Rows(i).Item("FPPRSEXO") <> "1" Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_345()
        Dim inconsistencia As String = "Genero invalido para clase de documento 2."
        Dim codigo As String = "345"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = "2" Then
                                    If dt_FIPRPROP.Rows(i).Item("FPPRSEXO") <> "2" Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_346()
        Dim inconsistencia As String = "Genero invalido para clase de documento 3."
        Dim codigo As String = "346"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = "3" Then
                                    If dt_FIPRPROP.Rows(i).Item("FPPRSEXO") <> "3" Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_347()
        Dim inconsistencia As String = "Genero invalido para clase de documento 9."
        Dim codigo As String = "347"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = "9" Then
                                    If dt_FIPRPROP.Rows(i).Item("FPPRSEXO") <> "1" And _
                                       dt_FIPRPROP.Rows(i).Item("FPPRSEXO") <> "2" Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_348()
        Dim inconsistencia As String = "Porcentaje de derecho en cero ‘0’."
        Dim codigo As String = "348"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If CType(Trim(dt_FIPRPROP.Rows(i).Item("FPPRDERE")), Double) = "0" Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_349()
        Dim inconsistencia As String = "Para calidad de propietario 2 clase de documento diferente de 3 o 8.  "
        Dim codigo As String = "349"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                If dt_FIPRPROP.Rows(i).Item("FPPRCAPR") = "2" Then
                                    If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") <> "3" And _
                                       dt_FIPRPROP.Rows(i).Item("FPPRTIDO") <> "8" Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_350()
        Dim inconsistencia As String = "Para calidad de propietario 2 genero diferente de 3."
        Dim codigo As String = "350"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                If dt_FIPRPROP.Rows(i).Item("FPPRCAPR") = "2" Then
                                    If dt_FIPRPROP.Rows(i).Item("FPPRSEXO") <> "3" Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_351()
        Dim inconsistencia As String = "Para calidad de propietario 3 clase de documento diferente de 3 o 8."
        Dim codigo As String = "351"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                If dt_FIPRPROP.Rows(i).Item("FPPRCAPR") = "3" Then
                                    If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") <> "3" And _
                                       dt_FIPRPROP.Rows(i).Item("FPPRTIDO") <> "8" Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_352()
        Dim inconsistencia As String = "Para calidad de propietario 4 clase de documento diferente de 3."
        Dim codigo As String = "352"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                If dt_FIPRPROP.Rows(i).Item("FPPRCAPR") = "4" Then
                                    If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") <> "3" Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_353()
        Dim inconsistencia As String = "Para calidad de propietario 3 genero diferente de 3."
        Dim codigo As String = "353"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                If dt_FIPRPROP.Rows(i).Item("FPPRCAPR") = "3" Then
                                    If dt_FIPRPROP.Rows(i).Item("FPPRSEXO") <> "3" Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_354()
        Dim inconsistencia As String = "Para clase de documento 4 genero diferente de 1 o 2. "
        Dim codigo As String = "354"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = "4" Then
                                    If dt_FIPRPROP.Rows(i).Item("FPPRSEXO") <> "1" And _
                                       dt_FIPRPROP.Rows(i).Item("FPPRSEXO") <> "2" Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_355()
        Dim inconsistencia As String = "Para clase de documento 5 genero diferente de 1 o 2. "
        Dim codigo As String = "355"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = "5" Then
                                    If dt_FIPRPROP.Rows(i).Item("FPPRSEXO") <> "1" And _
                                       dt_FIPRPROP.Rows(i).Item("FPPRSEXO") <> "2" Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_356()
        Dim inconsistencia As String = "Para clase de documento 6 genero diferente de 1 o 2. "
        Dim codigo As String = "356"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = "6" Then
                                    If dt_FIPRPROP.Rows(i).Item("FPPRSEXO") <> "1" And _
                                       dt_FIPRPROP.Rows(i).Item("FPPRSEXO") <> "2" Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_357()
        Dim inconsistencia As String = "Para clase de documento 7 genero diferente de 1 o 2. "
        Dim codigo As String = "357"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = "7" Then
                                    If dt_FIPRPROP.Rows(i).Item("FPPRSEXO") <> "1" And _
                                       dt_FIPRPROP.Rows(i).Item("FPPRSEXO") <> "2" Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_358()
        Dim inconsistencia As String = "Nro. de escritura en cero para predio con numero de notaria."
        Dim codigo As String = "358"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRMOAD") = 1 Or dt_FICHPRED.Rows(0).Item("FIPRMOAD") = 3 Then

                        If dt_FIPRPROP.Rows.Count > 0 Then

                            Dim i As Integer

                            For i = 0 To dt_FIPRPROP.Rows.Count - 1

                                If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                    If dt_FIPRPROP.Rows(i).Item("FPPRESCR") = 0 Then
                                        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRPROP.Rows(i).Item("FPPRNOTA"))) = True Then

                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                        End If
                                    End If

                                End If

                            Next

                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_359()
        Dim inconsistencia As String = "Matricula inmobiliaria con círculo registral y Nro. De tomo diferente de cero."
        Dim codigo As String = "359"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRMOAD") = 1 Or dt_FICHPRED.Rows(0).Item("FIPRMOAD") = 3 Then

                        If dt_FIPRPROP.Rows.Count > 0 Then

                            Dim i As Integer

                            For i = 0 To dt_FIPRPROP.Rows.Count - 1

                                If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                    If dt_FIPRPROP.Rows(i).Item("FPPRTOMO") <> 0 Then

                                        Dim filas() As DataRow

                                        filas = dt_FIPRPROP.Select("FPPRMAIN like '%-%'")

                                        If filas.Length > 0 Then

                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                        End If

                                    End If
                                End If

                            Next

                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_360()
        Dim inconsistencia As String = "Predio con numero de escritura y campo notaria con valor no numérico."
        Dim codigo As String = "360"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRMOAD") = 1 Or dt_FICHPRED.Rows(0).Item("FIPRMOAD") = 3 Then

                        If dt_FIPRPROP.Rows.Count > 0 Then

                            Dim i As Integer

                            For i = 0 To dt_FIPRPROP.Rows.Count - 1

                                If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                    If dt_FIPRPROP.Rows(i).Item("FPPRESCR") <> 0 Then
                                        If Trim(dt_FIPRPROP.Rows(i).Item("FPPRNOTA")) <> "INC" And Trim(dt_FIPRPROP.Rows(i).Item("FPPRNOTA")) <> "inc" Then
                                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRPROP.Rows(i).Item("FPPRNOTA"))) = False Then

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")) & " Notaria: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNOTA")))

                                            End If
                                        End If
                                    End If

                                End If

                            Next

                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_361()
        Dim inconsistencia As String = "Rango de documento errado para tipo de documento diferente de 8."
        Dim codigo As String = "361"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") <> 8 Then
                                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO"))) = True Then
                                        If CType(dt_FIPRPROP.Rows(i).Item("FPPRNUDO"), Long) < 1000 Then

                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                        End If
                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_362()
        Dim inconsistencia As String = "Rango de Nro. De documento incorrecto para tipo de documento 9 NUIP."
        Dim codigo As String = "362"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 9 Then
                                    If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO"))) = True Then
                                        If CType(dt_FIPRPROP.Rows(i).Item("FPPRNUDO"), Long) > 10000000000 Then

                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                        End If
                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_363()
        Dim inconsistencia As String = "Año incorrecto del Nro. De documento para tipo de documento 6 T.I."
        Dim codigo As String = "363"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 6 Then
                                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")).Length >= 2 Then
                                        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO").ToString).Substring(0, 2)) = True Then
                                            If CType(Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO").ToString).Substring(0, 2), Integer) < 75 Then

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                            End If
                                        End If
                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_364()
        Dim inconsistencia As String = "Longitud incorrecta para Nro. De documento con tipo de documento 6 T.I."
        Dim codigo As String = "364"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 6 Then
                                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")).Length < 11 Or Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")).Length > 12 Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_365()
        Dim inconsistencia As String = "Mes incorrecto del Nro. De documento para tipo de documento 6 T.I."
        Dim codigo As String = "365"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 6 Then
                                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")).Length >= 4 Then
                                        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO").ToString).Substring(0, 4)) = True Then
                                            If CType(Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO").ToString).Substring(2, 2), Integer) > 12 Then

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                            End If
                                        End If
                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_366()
        Dim inconsistencia As String = "Día incorrecto del Nro. De documento para tipo de documento 6 T.I."
        Dim codigo As String = "366"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If dt_FIPRPROP.Rows(i).Item("FPPRTIDO") = 6 Then
                                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")).Length >= 6 Then
                                        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO").ToString).Substring(0, 4)) = True Then
                                            If CType(Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO").ToString).Substring(4, 2), Integer) > 31 Then

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                            End If
                                        End If
                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_367()
        Dim inconsistencia As String = "Caracteres especiales en el campo de nombre."
        Dim codigo As String = "367"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If Trim(dt_FIPRPROP.Rows(i).Item("FPPRNOMB").ToString) <> "" Then

                                    Dim inCantidad As Integer = Trim(dt_FIPRPROP.Rows(i).Item("FPPRNOMB").ToString.Length)

                                    Dim y As Integer = 0

                                    For y = 0 To inCantidad - 1

                                        Dim SW As Byte = 0

                                        Dim stLetra As String = dt_FIPRPROP.Rows(i).Item("FPPRNOMB").ToString.Substring(y, 1)

                                        If stLetra = "/" Or _
                                            stLetra = "+" Or _
                                            stLetra = "-" Or _
                                            stLetra = "*" Or _
                                            stLetra = "'" Or _
                                            stLetra = "(" Or _
                                            stLetra = ")" Or _
                                            stLetra = "=" Or _
                                            stLetra = "#" Or _
                                            stLetra = "|" Or _
                                            stLetra = "$" Or _
                                            stLetra = "&" Or _
                                            stLetra = "{" Or _
                                            stLetra = "}" Or _
                                            stLetra = ";" Or _
                                            stLetra = ":" Or _
                                            stLetra = "_" Then

                                            SW = 1

                                        End If

                                        ' existen caracteres
                                        If SW = 1 Then
                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")) & " " & " Nombre: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNOMB")) & " " & " Carácter: " & Trim(stLetra))
                                        End If

                                    Next

                                End If
                            End If
                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_368()
        Dim inconsistencia As String = "Caracteres especiales en el campo de primer apellido."
        Dim codigo As String = "368"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If Trim(dt_FIPRPROP.Rows(i).Item("FPPRPRAP").ToString) <> "" Then

                                    Dim inCantidad As Integer = Trim(dt_FIPRPROP.Rows(i).Item("FPPRPRAP").ToString.Length)

                                    Dim y As Integer = 0

                                    For y = 0 To inCantidad - 1

                                        Dim SW As Byte = 0

                                        Dim stLetra As String = dt_FIPRPROP.Rows(i).Item("FPPRPRAP").ToString.Substring(y, 1)

                                        If stLetra = "/" Or _
                                            stLetra = "+" Or _
                                            stLetra = "-" Or _
                                            stLetra = "*" Or _
                                            stLetra = "'" Or _
                                            stLetra = "(" Or _
                                            stLetra = ")" Or _
                                            stLetra = "=" Or _
                                            stLetra = "#" Or _
                                            stLetra = "|" Or _
                                            stLetra = "$" Or _
                                            stLetra = "&" Or _
                                            stLetra = "{" Or _
                                            stLetra = "}" Or _
                                            stLetra = ";" Or _
                                            stLetra = ":" Or _
                                            stLetra = "_" Then

                                            SW = 1

                                        End If

                                        ' existen caracteres
                                        If SW = 1 Then
                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")) & " " & " Primer apellido: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRPRAP")) & " " & " Carácter: " & Trim(stLetra))
                                        End If

                                    Next

                                End If
                            End If
                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_369()
        Dim inconsistencia As String = "Caracteres especiales en el campo de segundo apellido."
        Dim codigo As String = "369"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If Trim(dt_FIPRPROP.Rows(i).Item("FPPRSEAP").ToString) <> "" Then

                                    Dim inCantidad As Integer = Trim(dt_FIPRPROP.Rows(i).Item("FPPRSEAP").ToString.Length)

                                    Dim y As Integer = 0

                                    For y = 0 To inCantidad - 1

                                        Dim SW As Byte = 0

                                        Dim stLetra As String = dt_FIPRPROP.Rows(i).Item("FPPRSEAP").ToString.Substring(y, 1)

                                        If stLetra = "/" Or _
                                            stLetra = "+" Or _
                                            stLetra = "-" Or _
                                            stLetra = "*" Or _
                                            stLetra = "'" Or _
                                            stLetra = "(" Or _
                                            stLetra = ")" Or _
                                            stLetra = "=" Or _
                                            stLetra = "#" Or _
                                            stLetra = "|" Or _
                                            stLetra = "$" Or _
                                            stLetra = "&" Or _
                                            stLetra = "{" Or _
                                            stLetra = "}" Or _
                                            stLetra = ";" Or _
                                            stLetra = ":" Or _
                                            stLetra = "_" Then

                                            SW = 1

                                        End If

                                        ' existen caracteres
                                        If SW = 1 Then
                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")) & " " & " Segundo apellido: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRSEAP")) & " " & " Carácter: " & Trim(stLetra))
                                        End If

                                    Next

                                End If
                            End If
                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_370()
        Dim inconsistencia As String = "Circulo de registro diferente al asigando al municipio."
        Dim codigo As String = "370"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then
                                If Trim(dt_FIPRPROP.Rows(i).Item("FPPRTOMO").ToString) = "0" And Trim(dt_FIPRPROP.Rows(i).Item("FPPRMOAD").ToString) <> 2 Then
                                    If Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN").ToString.Length) >= 3 Then

                                        Dim stCirculoRegistro As String = Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN").ToString.Substring(0, 3))

                                        Dim objdatos As New cla_CIRCREGI
                                        Dim tbl As New DataTable

                                        tbl = objdatos.fun_Buscar_CODIGO_DEPA_MUNI_X_MANT_CIRCREGI(Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA").ToString), Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI").ToString))

                                        If tbl.Rows.Count > 0 Then

                                            If Trim(tbl.Rows(0).Item("CIREESTA").ToString) = "ac" Then
                                                If Trim(tbl.Rows(0).Item("CIRECIRE").ToString) <> "" Then

                                                    If Trim(tbl.Rows(0).Item("CIRECIRE").ToString) <> Trim(stCirculoRegistro) Then

                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")) & " " & " Circulo registral: " & stCirculoRegistro)

                                                    End If

                                                End If
                                            End If

                                        End If

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_371()
        Dim inconsistencia As String = "No existe propietario anterior"
        Dim codigo As String = "371"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRMOAD") = 1 Or dt_FICHPRED.Rows(0).Item("FIPRMOAD") = 3 Then

                        Dim boMejora As Boolean = False

                        If dt_FIPRCONS.Rows.Count = 0 Then
                            boMejora = False
                        Else
                            Dim j As Integer = 0

                            For j = 0 To dt_FIPRCONS.Rows.Count - 1

                                If Trim(dt_FIPRCONS.Rows(j).Item("FPCOESTA")) = "ac" Then
                                    If dt_FIPRCONS.Rows(j).Item("FPCOCLCO") = 1 Or dt_FIPRCONS.Rows(j).Item("FPCOCLCO") = 3 Then
                                        If dt_FIPRCONS.Rows(j).Item("FPCOMEJO") = True Then

                                            boMejora = True

                                        End If
                                    End If
                                End If

                            Next

                        End If

                        If dt_FIPRPROP.Rows.Count > 0 And boMejora = False Then

                            Dim i As Integer

                            For i = 0 To dt_FIPRPROP.Rows.Count - 1

                                If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                    Dim objdatos As New cla_PROPANTE
                                    Dim tbl As New DataTable

                                    tbl = objdatos.fun_Buscar_PROPIETARIOS_X_NRO_DE_FICHA_Y_NRO_DE_DOCUMENTO(Trim(dt_FICHPRED.Rows(0).Item("FIPRNUFI").ToString), Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO").ToString))

                                    If tbl.Rows.Count = 0 Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")))

                                    End If

                                End If

                            Next

                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_372()
        Dim inconsistencia As String = "-AVISO- Predios con característica 7 Baldío, adquisición 2 Posesión"
        Dim codigo As String = "372"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 And _
                   dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 And _
                   dt_FICHPRED.Rows(0).Item("FIPRMOAD") = 2 Then

                    If dt_FIPRPROP.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRPROP.Rows.Count - 1

                            If Trim(dt_FIPRPROP.Rows(i).Item("FPPRESTA")) = "ac" Then

                                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN").ToString.Substring(0, 1))) = True Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " " & "con matricula" & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")) & " Matricula: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN")))
                                Else
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " " & "sin matricula" & " Documento: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRNUDO")) & " Matricula: " & Trim(dt_FIPRPROP.Rows(i).Item("FPPRMAIN")))

                                End If

                            End If

                        Next

                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub

#End Region

#Region "Validar FiprCons 400"

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
            pro_Inconsistencia_459()
            pro_Inconsistencia_460()
            pro_Inconsistencia_461()
            pro_Inconsistencia_462()
            pro_Inconsistencia_463()
            pro_Inconsistencia_464()
            pro_Inconsistencia_465()
            pro_Inconsistencia_466()
            pro_Inconsistencia_467()
            pro_Inconsistencia_468()
            pro_Inconsistencia_469()
            pro_Inconsistencia_470()
            pro_Inconsistencia_471()
            pro_Inconsistencia_472()
            pro_Inconsistencia_473()
            pro_Inconsistencia_474()
            pro_Inconsistencia_475()
            pro_Inconsistencia_476()
            pro_Inconsistencia_477()

        Catch ex As Exception
            MessageBox.Show(Err.Description & "Construcción")
        End Try

    End Sub

    Private Sub pro_Inconsistencia_400()
        Dim inconsistencia As String = "Numero de construcción invalido para predio que no es mejora."
        Dim codigo As String = "400"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If dt_FIPRCONS.Rows(i).Item("FPCOUNID") > 1000 Then
                                If dt_FIPRCONS.Rows(i).Item("FPCOMEJO") = False Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                End If
                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_401()
        Dim inconsistencia As String = "Numero de construcción invalido para predio que es mejora."
        Dim codigo As String = "401"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If dt_FIPRCONS.Rows(i).Item("FPCOUNID") < 1001 Then
                                If dt_FIPRCONS.Rows(i).Item("FPCOMEJO") = True Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                End If
                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_402()
        Dim inconsistencia As String = "No existe calificación para las unidades construidas."
        Dim codigo As String = "402"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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

                                    If byCONTADOR = 0 Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
                                        byCONTADOR = 0
                                    End If
                                Else
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
                                End If
                            End If
                        End If
                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_403()
        Dim inconsistencia As String = "Puntaje diferente entre los datos generales y calificación."
        Dim codigo As String = "403"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
                                    End If

                                Else
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
                                End If
                            End If
                        End If
                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_404()
        Dim inconsistencia As String = "Área construcción igual a cero."
        Dim codigo As String = "404"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If CType(Trim(dt_FIPRCONS.Rows(i).Item("FPCOARCO")), Double) = 0 Then
                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_408()
        Dim inconsistencia As String = "Puntos construcción no pueden ser mayor tabla codazzi."
        Dim codigo As String = "408"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then


                            ' declaro variables
                            Dim stFPCODEPA As String = Trim(dt_FIPRCONS.Rows(i).Item("FPCODEPA"))
                            Dim stFPCOMUNI As String = Trim(dt_FIPRCONS.Rows(i).Item("FPCOMUNI"))
                            Dim stFPCOCLCO As String = Trim(dt_FIPRCONS.Rows(i).Item("FPCOCLCO"))
                            Dim stFPCOTICO As String = Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))

                            Dim objdatos As New cla_VALIFIPR
                            dt = New DataTable

                            dt = objdatos.fun_Consultar_PUNTOS_MAYOR_TABLA_CODAZZI_INCO_408(stFPCODEPA, stFPCOMUNI, stFPCOCLCO, stFPCOTICO)

                            If dt.Rows.Count > 0 Then

                                If dt_FIPRCONS.Rows(i).Item("FPCOPUNT") > dt.Rows(0).Item(0) Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                End If
                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_435()
        Dim inconsistencia As String = "Numero de pisos invalido."
        Dim codigo As String = "435"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If dt_FIPRCONS.Rows(i).Item("FPCOPISO") > 20 Then
                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_436()
        Dim inconsistencia As String = "Porcentaje construido en cero."
        Dim codigo As String = "436"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If dt_FIPRCONS.Rows(i).Item("FPCOPOCO") = 0 Then
                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_437()
        Dim inconsistencia As String = "Edad de construcción en cero."
        Dim codigo As String = "437"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If dt_FIPRCONS.Rows(i).Item("FPCOEDCO") = 0 Then
                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_443()
        Dim inconsistencia As String = "Área construida mayor a área de terreno para predios normales."
        Dim codigo As String = "443"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Then

                        If dt_FIPRCONS.Rows.Count > 0 Then
                            If dt_FIPRCONS.Rows.Count = 1 Then

                                Dim i As Integer

                                For i = 0 To dt_FIPRCONS.Rows.Count - 1

                                    If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOMEJO")) = False Then
                                            If ((CType(Trim(dt_FIPRCONS.Rows(i).Item("FPCOARCO")), Double) * 0.9) / dt_FIPRCONS.Rows(i).Item("FPCOPISO")) > dt_FICHPRED.Rows(0).Item("FIPRARTE") Then

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                            End If
                                        End If
                                    End If

                                Next

                            Else

                                Dim inTotalPiso As Integer = 0
                                Dim doTotalArea As Double = 0
                                Dim j As Integer

                                For j = 0 To dt_FIPRCONS.Rows.Count - 1

                                    If Trim(dt_FIPRCONS.Rows(j).Item("FPCOESTA")) = "ac" Then
                                        If Trim(dt_FIPRCONS.Rows(j).Item("FPCOMEJO")) = False Then

                                            inTotalPiso += dt_FIPRCONS.Rows(j).Item("FPCOPISO")
                                            doTotalArea += dt_FIPRCONS.Rows(j).Item("FPCOARCO")

                                        End If
                                    End If

                                Next

                                If ((doTotalArea * 0.9) / inTotalPiso) > dt_FICHPRED.Rows(0).Item("FIPRARTE") Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                End If

                            End If
                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_446()
        Dim inconsistencia As String = "Construcciones valorables no convencionales con calificación."
        Dim codigo As String = "446"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
                                        byCONTADOR = 0
                                    End If

                                End If
                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_447()
        Dim inconsistencia As String = "Identificador residencial invalido para el sector rural."
        Dim codigo As String = "447"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_448()
        Dim inconsistencia As String = "Identificador residencial invalido para el sector urbano."
        Dim codigo As String = "448"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Identi.: " & dt_FIPRCONS.Rows(i).Item("FPCOTICO"))

                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_449()
        Dim inconsistencia As String = "Identificador comercial invalido para el sector rural."
        Dim codigo As String = "449"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_450()
        Dim inconsistencia As String = "Identificador comercial invalido para el sector urbano."
        Dim codigo As String = "450"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_451()
        Dim inconsistencia As String = "Identificador industrial invalido para el sector rural."
        Dim codigo As String = "451"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Then
                    If dt_FIPRCONS.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRCONS.Rows.Count - 1

                            If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "067" Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_452()
        Dim inconsistencia As String = "Identificador industrial invalido para el sector urbano."
        Dim codigo As String = "452"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCONS.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRCONS.Rows.Count - 1

                            If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "011" Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_453()
        Dim inconsistencia As String = "Predio marcado como conjunto para identificador residencial utilizado en urbanismo comun."
        Dim codigo As String = "453"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCONJ") = True Then
                    If dt_FIPRCONS.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRCONS.Rows.Count - 1

                            If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "001" Or _
                                   Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "021" Or _
                                   Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "039" Or _
                                   Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "036" Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_454()
        Dim inconsistencia As String = "Predio NO marcado como conjunto para identificador utilizado en conjunto residencial."
        Dim codigo As String = "454"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_455()
        Dim inconsistencia As String = "Numero de construcción inválido para ficha resumen 1 o 2."
        Dim codigo As String = "455"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Or _
                   dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then

                    If dt_FIPRCONS.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRCONS.Rows.Count - 1

                            If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") > 1000 Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_456()
        Dim inconsistencia As String = "Construcción marcada como mejora para ficha resumen 1 o 2."
        Dim codigo As String = "456"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Or _
                   dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then

                    If dt_FIPRCONS.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRCONS.Rows.Count - 1

                            If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                                If dt_FIPRCONS.Rows(i).Item("FPCOMEJO") = True Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_457()
        Dim inconsistencia As String = "Construcción marcada con ley 56 para característica diferente de 6."
        Dim codigo As String = "457"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRCONS.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRCONS.Rows.Count - 1

                            If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                                If dt_FIPRCONS.Rows(i).Item("FPCOLEY") = True Then
                                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") <> 6 Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_458()
        Dim inconsistencia As String = "Construcción marcada con ley 56 para ficha resumen 1 o 2."
        Dim codigo As String = "458"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Or _
                   dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then

                    If dt_FIPRCONS.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRCONS.Rows.Count - 1

                            If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                                If dt_FIPRCONS.Rows(i).Item("FPCOLEY") = True Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_459()
        Dim inconsistencia As String = "Construcción marcada como mejora para característica de predio 2,3,4 y 5."
        Dim codigo As String = "459"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If dt_FIPRCONS.Rows(i).Item("FPCOMEJO") = True Then

                                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
                                   dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
                                   dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Or _
                                   dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 5 Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                End If

                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_460()
        Dim inconsistencia As String = "Unidad predial mayor a 1000 para característica de predio 2,3,4 y 5"
        Dim codigo As String = "460"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If dt_FIPRCONS.Rows(i).Item("FPCOUNID") > 1000 Then

                                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
                                   dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
                                   dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Or _
                                   dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 5 Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                End If

                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_461()
        Dim inconsistencia As String = "Unidad de construcción mayor al Nro. de construcciones totales para predios que no son mejoras."
        Dim codigo As String = "461"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count = 1 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" And dt_FIPRCONS.Rows(i).Item("FPCOMEJO") = False Then
                            If dt_FIPRCONS.Rows(i).Item("FPCOUNID") > 1 Then

                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_462()
        Dim inconsistencia As String = "Área de construcción con 1 mt2."
        Dim codigo As String = "462"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If CType(dt_FIPRCONS.Rows(i).Item("FPCOARCO"), Double) = 1.0 Then

                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Dirección: " & dt_FICHPRED.Rows(0).Item("FIPRDIRE"))

                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_463()
        Dim inconsistencia As String = "Generales de construcción en 2 para predio con característica RPH."
        Dim codigo As String = "463"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
                       dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                        If dt_FIPRCONS.Rows.Count > 0 Then

                            Dim i As Integer

                            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" And _
                                   Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) <> "050" And _
                                   Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) <> "014" Then

                                    If dt_FIPRCONS.Rows(i).Item("FPCOACUE") = 2 And _
                                       dt_FIPRCONS.Rows(i).Item("FPCOALCA") = 2 And _
                                       dt_FIPRCONS.Rows(i).Item("FPCOENER") = 2 And _
                                       dt_FIPRCONS.Rows(i).Item("FPCOTELE") = 2 And _
                                       dt_FIPRCONS.Rows(i).Item("FPCOGAS") = 2 And _
                                       dt_FIPRCONS.Rows(i).Item("FPCOPOCO") = 100 Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Identificador: " & dt_FIPRCONS.Rows(i).Item("FPCOTICO"))

                                    End If
                                End If

                            Next

                        End If

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_464()
        Dim inconsistencia As String = "Predio con cons. Que SI es mejora y posee otra(s) cons. Que NO es mejora."
        Dim codigo As String = "464"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRCONS.Rows.Count > 0 Then

                        Dim bySW_Mejora As Byte = 0
                        Dim bySW_Predio As Byte = 0
                        Dim i As Integer = 0

                        For i = 0 To dt_FIPRCONS.Rows.Count - 1

                            If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                                If dt_FIPRCONS.Rows(i).Item("FPCOMEJO") = True Then
                                    bySW_Mejora = 1
                                Else
                                    bySW_Predio = 1
                                End If
                            End If

                        Next

                        If bySW_Mejora = 1 And bySW_Predio = 1 Then
                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                        End If

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_465()
        Dim inconsistencia As String = "Predio con cons. Que NO es mejora y posee otra(s) cons. Que SI es mejora."
        Dim codigo As String = "465"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FIPRCONS.Rows.Count > 0 Then

                        Dim bySW_Mejora As Byte = 0
                        Dim bySW_Predio As Byte = 0
                        Dim i As Integer = 0

                        For i = 0 To dt_FIPRCONS.Rows.Count - 1

                            If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                                If dt_FIPRCONS.Rows(i).Item("FPCOMEJO") = False Then
                                    bySW_Mejora = 1
                                Else
                                    bySW_Predio = 1
                                End If
                            End If

                        Next

                        If bySW_Mejora = 1 And bySW_Predio = 1 Then
                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                        End If

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_466()
        Dim inconsistencia As String = "Nro. De pisos diferene de 1 para construcciones con identificador de la clase valorable no convencional. "
        Dim codigo As String = "466"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If dt_FIPRCONS.Rows(i).Item("FPCOCLCO") = 2 Then
                                If dt_FIPRCONS.Rows(i).Item("FPCOPISO") <> 1 Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                End If
                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_467()
        Dim inconsistencia As String = "Predio con identificador de parqueadero residencial y con calificación de baño o cocina."
        Dim codigo As String = "467"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "014" Or Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "050" Then

                                If dt_FIPRCACO.Rows.Count > 0 Then

                                    Dim sw1 As Byte = 0
                                    Dim k As Integer = 0

                                    While k < dt_FIPRCACO.Rows.Count And sw1 = 0
                                        If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                            Dim j1 As Integer = 0

                                            For j1 = 0 To dt_FIPRCACO.Rows.Count - 1

                                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then

                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 312 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 313 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 314 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 321 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 322 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 323 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 324 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 325 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 326 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 331 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 332 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 333 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 334 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 335 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 341 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 342 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 343 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 344 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 412 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 413 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 414 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 421 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 422 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 423 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 424 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 425 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 426 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 431 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 432 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 433 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 434 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 435 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 441 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 442 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 443 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If
                                                    If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 444 Then
                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
                                                    End If

                                                End If

                                            Next

                                            sw1 = 1
                                        Else
                                            k = k + 1
                                        End If

                                    End While

                                End If
                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_468()
        Dim inconsistencia As String = "Area de construcción mayor 1000 mt2."
        Dim codigo As String = "468"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If CType(dt_FIPRCONS.Rows(i).Item("FPCOARCO"), Decimal) > 1000 Then

                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Área cons: " & dt_FIPRCONS.Rows(i).Item("FPCOARCO") & " Identificador: " & dt_FIPRCONS.Rows(i).Item("FPCOTICO"))

                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_469()
        Dim inconsistencia As String = "Predio en R.P.H. y con construcción no valorable y destino económico 1 habitacional."
        Dim codigo As String = "469"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or _
                   dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or _
                   dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                    Dim swConstruccion As Byte = 0
                    Dim swDestino As Byte = 0
                    Dim stIdentificador As String = ""

                    ' Verifica la construcción
                    If dt_FIPRCONS.Rows.Count > 0 Then

                        Dim sw1 As Byte = 0
                        Dim j1 As Integer = 0

                        While j1 < dt_FIPRCONS.Rows.Count And sw1 = 0
                            If Trim(dt_FIPRCONS.Rows(j1).Item("FPCOESTA")) = "ac" Then
                                If dt_FIPRCONS.Rows(j1).Item("FPCOCLCO") = 3 Then
                                    stIdentificador = dt_FIPRCONS.Rows(j1).Item("FPCOTICO")
                                    swConstruccion = 1
                                    sw1 = 1
                                Else
                                    j1 = j1 + 1
                                End If
                            End If

                        End While

                    End If

                    ' Verifica la destinación económica
                    If dt_FIPRDEEC.Rows.Count > 0 Then

                        Dim sw1 As Byte = 0
                        Dim j1 As Integer = 0

                        While j1 < dt_FIPRDEEC.Rows.Count And sw1 = 0
                            If Trim(dt_FIPRDEEC.Rows(j1).Item("FPDEESTA")) = "ac" Then
                                If dt_FIPRDEEC.Rows(j1).Item("FPDEDEEC") = 1 Then
                                    swDestino = 1
                                    sw1 = 1
                                Else
                                    j1 = j1 + 1
                                End If
                            End If

                        End While

                    End If

                    ' almacena la inconsistencia
                    If swConstruccion = 1 And swDestino = 1 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Identificador: " & stIdentificador)

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_470()
        Dim inconsistencia As String = "Puntos de construcción en cero."
        Dim codigo As String = "470"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If CType(dt_FIPRCONS.Rows(i).Item("FPCOPUNT"), Integer) = 0 Then

                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Área cons: " & dt_FIPRCONS.Rows(i).Item("FPCOARCO") & " Identificador: " & dt_FIPRCONS.Rows(i).Item("FPCOTICO"))

                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_471()
        Dim inconsistencia As String = "Área de construcción mayor a 100 mts para identificador de parqueadero en para predio en RPH."
        Dim codigo As String = "471"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then

                        If dt_FIPRCONS.Rows.Count > 0 Then

                            Dim i As Integer

                            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                                    If CType(dt_FIPRCONS.Rows(i).Item("FPCOARCO"), Decimal) > 100 Then

                                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "050" Or _
                                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "014" Or _
                                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "075" Or _
                                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "75A" Or _
                                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "75B" Or _
                                           Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "75C" Then


                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Área cons: " & dt_FIPRCONS.Rows(i).Item("FPCOARCO") & " Identificador: " & dt_FIPRCONS.Rows(i).Item("FPCOTICO"))

                                        End If

                                    End If
                                End If

                            Next

                        End If

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_472()
        Dim inconsistencia As String = "Predio con Nro. De mejora repetida."
        Dim codigo As String = "472"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

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
                    ParametrosConsulta += "Select fpcoUnid, count(1) as FIPRCANT "
                    ParametrosConsulta += "From FichPred, FiprCons where "
                    ParametrosConsulta += "FiprNufi = FpcoNufi and "
                    ParametrosConsulta += "FpcoMejo = '" & 1 & "' and "
                    ParametrosConsulta += "FiprTifi = '" & 0 & "' and "
                    ParametrosConsulta += "FiprMuni = '" & Trim(CStr(dt_FICHPRED.Rows(0).Item("FIPRMUNI").ToString)) & "' and "
                    ParametrosConsulta += "FiprCorr = '" & Trim(CStr(dt_FICHPRED.Rows(0).Item("FIPRCORR").ToString)) & "' and "
                    ParametrosConsulta += "FiprBarr = '" & Trim(CStr(dt_FICHPRED.Rows(0).Item("FIPRBARR").ToString)) & "' and "
                    ParametrosConsulta += "FiprManz = '" & Trim(CStr(dt_FICHPRED.Rows(0).Item("FIPRMANZ").ToString)) & "' and "
                    ParametrosConsulta += "FiprPred = '" & Trim(CStr(dt_FICHPRED.Rows(0).Item("FIPRPRED").ToString)) & "' and "
                    ParametrosConsulta += "FiprClse = '" & Trim(CInt(dt_FICHPRED.Rows(0).Item("FIPRCLSE").ToString)) & "' and "
                    ParametrosConsulta += "FiprEsta = '" & "ac" & "' and "
                    ParametrosConsulta += "FpcoEsta = '" & "ac" & "' "
                    ParametrosConsulta += "group by fpcounid "

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

                    ' verifica que existen mejoras
                    If dt.Rows.Count > 0 Then

                        ' declaro la variable
                        Dim i As Integer

                        For i = 0 To dt.Rows.Count - 1

                            If CInt(dt.Rows(i).Item("FIPRCANT").ToString) > 1 Then

                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt.Rows(i).Item("fpcoUnid"))

                            End If

                        Next

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_473()
        Dim inconsistencia As String = "Predio con construcción menor a 65 puntos y con identificador 021."
        Dim codigo As String = "473"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If CType(dt_FIPRCONS.Rows(i).Item("FPCOPUNT"), Integer) < 65 And Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "021" Then

                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Puntos: " & dt_FIPRCONS.Rows(i).Item("FPCOPUNT") & " Identificador: " & dt_FIPRCONS.Rows(i).Item("FPCOTICO"))

                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_474()
        Dim inconsistencia As String = "Unidad de construcción mayor al Nro. De construcciones."
        Dim codigo As String = "474"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim inNroConstrucciones As Integer = CInt(dt_FIPRCONS.Rows.Count)

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If dt_FIPRCONS.Rows(i).Item("FPCOMEJO") = False Then
                                If CType(dt_FIPRCONS.Rows(i).Item("FPCOUNID"), Integer) > inNroConstrucciones Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Puntos: " & dt_FIPRCONS.Rows(i).Item("FPCOPUNT") & " Identificador: " & dt_FIPRCONS.Rows(i).Item("FPCOTICO"))

                                End If
                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_475()
        Dim inconsistencia As String = "Predio con identificador 056 y NO posee Destinación económica 27."
        Dim codigo As String = "475"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Then

                    Dim swConstruccion As Byte = 0
                    Dim swDestino As Byte = 0

                    ' Verifica la construcción
                    If dt_FIPRCONS.Rows.Count > 0 Then

                        Dim sw1 As Byte = 0
                        Dim j1 As Integer = 0

                        While j1 < dt_FIPRCONS.Rows.Count And sw1 = 0
                            If Trim(dt_FIPRCONS.Rows(j1).Item("FPCOESTA")) = "ac" Then
                                If dt_FIPRCONS.Rows(j1).Item("FPCOTICO") = "056" Then

                                    swConstruccion = 1
                                    sw1 = 1
                                Else
                                    j1 = j1 + 1
                                End If

                            End If

                        End While

                    End If

                    ' Verifica la destinación económica
                    If dt_FIPRDEEC.Rows.Count > 0 And swConstruccion = 1 Then

                        Dim sw1 As Byte = 0
                        Dim j1 As Integer = 0

                        While j1 < dt_FIPRDEEC.Rows.Count And sw1 = 0
                            If Trim(dt_FIPRDEEC.Rows(j1).Item("FPDEESTA")) = "ac" Then
                                If dt_FIPRDEEC.Rows(j1).Item("FPDEDEEC") = "27" Then
                                    swDestino = 1
                                    sw1 = 1
                                Else
                                    j1 = j1 + 1
                                End If
                            End If

                        End While

                    End If

                    ' almacena la inconsistencia
                    If swConstruccion = 1 And swDestino = 0 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_476()
        Dim inconsistencia As String = "Predio con identificador 011 ó 067 y NO posee Destinación económica 29."
        Dim codigo As String = "476"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Then

                    Dim swConstruccion As Byte = 0
                    Dim swDestino As Byte = 0

                    ' Verifica la construcción
                    If dt_FIPRCONS.Rows.Count > 0 Then

                        Dim sw1 As Byte = 0
                        Dim j1 As Integer = 0

                        While j1 < dt_FIPRCONS.Rows.Count And sw1 = 0
                            If Trim(dt_FIPRCONS.Rows(j1).Item("FPCOESTA")) = "ac" Then
                                If dt_FIPRCONS.Rows(j1).Item("FPCOTICO") = "011" Or _
                                   dt_FIPRCONS.Rows(j1).Item("FPCOTICO") = "067" Then

                                    swConstruccion = 1
                                    sw1 = 1
                                Else
                                    j1 = j1 + 1
                                End If

                            End If

                        End While

                    End If

                    ' Verifica la destinación económica
                    If dt_FIPRDEEC.Rows.Count > 0 And swConstruccion = 1 Then

                        Dim sw1 As Byte = 0
                        Dim j1 As Integer = 0

                        While j1 < dt_FIPRDEEC.Rows.Count And sw1 = 0
                            If Trim(dt_FIPRDEEC.Rows(j1).Item("FPDEESTA")) = "ac" Then
                                If dt_FIPRDEEC.Rows(j1).Item("FPDEDEEC") = "29" Then
                                    swDestino = 1
                                    sw1 = 1
                                Else
                                    j1 = j1 + 1
                                End If
                            End If

                        End While

                    End If

                    ' almacena la inconsistencia
                    If swConstruccion = 1 And swDestino = 0 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_477()
        Dim inconsistencia As String = "Predio rural que es mejora con destinación económica 4 ó 31."
        Dim codigo As String = "477"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 And _
                   dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then

                    Dim swConstruccion As Byte = 0
                    Dim swDestino As Byte = 0

                    ' Verifica la construcción
                    If dt_FIPRCONS.Rows.Count > 0 Then

                        Dim sw1 As Byte = 0
                        Dim j1 As Integer = 0

                        While j1 < dt_FIPRCONS.Rows.Count And sw1 = 0
                            If Trim(dt_FIPRCONS.Rows(j1).Item("FPCOESTA")) = "ac" Then
                                If CBool(dt_FIPRCONS.Rows(j1).Item("FPCOMEJO")) = True Then

                                    swConstruccion = 1
                                    sw1 = 1
                                Else
                                    j1 = j1 + 1
                                End If

                            End If

                        End While

                    End If

                    ' Verifica la destinación económica
                    If dt_FIPRDEEC.Rows.Count > 0 And swConstruccion = 1 Then

                        Dim sw1 As Byte = 0
                        Dim j1 As Integer = 0

                        While j1 < dt_FIPRDEEC.Rows.Count And sw1 = 0
                            If Trim(dt_FIPRDEEC.Rows(j1).Item("FPDEESTA")) = "ac" Then
                                If dt_FIPRDEEC.Rows(j1).Item("FPDEDEEC") = "4" Or dt_FIPRDEEC.Rows(j1).Item("FPDEDEEC") = "31" Then
                                    swDestino = 1
                                    sw1 = 1
                                Else
                                    j1 = j1 + 1
                                End If
                            End If

                        End While

                    End If

                    ' almacena la inconsistencia
                    If swConstruccion = 1 And swDestino = 1 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
#End Region

#Region "Validar FiprCaco 500"

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
            pro_Inconsistencia_512()
            pro_Inconsistencia_513()
            pro_Inconsistencia_514()
            pro_Inconsistencia_515()
            pro_Inconsistencia_516()
            pro_Inconsistencia_517()
            pro_Inconsistencia_518()
            pro_Inconsistencia_519()
            pro_Inconsistencia_520()
            pro_Inconsistencia_521()
            pro_Inconsistencia_522()
            pro_Inconsistencia_523()
            pro_Inconsistencia_524()
            pro_Inconsistencia_525()
            pro_Inconsistencia_526()
            pro_Inconsistencia_527()
            pro_Inconsistencia_528()
            pro_Inconsistencia_529()
            pro_Inconsistencia_530()
            pro_Inconsistencia_531()
            pro_Inconsistencia_532()
            pro_Inconsistencia_533()
            pro_Inconsistencia_534()
            pro_Inconsistencia_535()
            pro_Inconsistencia_536()
            pro_Inconsistencia_537()
            pro_Inconsistencia_538()
            pro_Inconsistencia_539()
            pro_Inconsistencia_540()
            pro_Inconsistencia_541()

        Catch ex As Exception
            MessageBox.Show(Err.Description & " Calificación de construcción")
        End Try

    End Sub

    Private Sub pro_Inconsistencia_504()
        Dim inconsistencia As String = "Identificador residencial invalido para calificación 114."
        Dim codigo As String = "504"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
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

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_505()
        Dim inconsistencia As String = "Identificador residencial invalido para calificación 115."
        Dim codigo As String = "505"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
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

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_506()
        Dim inconsistencia As String = "Identificador mayor de 500 y calificaciones diferentes de 141,241,341,441."
        Dim codigo As String = "506"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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

                                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI"))

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
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_507()
        Dim inconsistencia As String = "Identificador residencial invalido para característica 3 o 4."
        Dim codigo As String = "507"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                    End If
                                End If

                            Next

                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_508()
        Dim inconsistencia As String = "Identificador residencial invalido para característica 1."
        Dim codigo As String = "508"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 0 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Then

                        If dt_FIPRCONS.Rows.Count > 0 Then

                            Dim i As Integer

                            For i = 0 To dt_FIPRCONS.Rows.Count - 1

                                If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                                    If Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "003" Or _
                                       Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "045" Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                    End If
                                End If

                            Next

                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_509()
        Dim inconsistencia As String = "Clase de construcción invalida para identificador mayor de 500."
        Dim codigo As String = "509"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))) = True Then
                                If Val(Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))) > 500 Then
                                    If dt_FIPRCONS.Rows(i).Item("FPCOCLCO") <> 3 Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                    End If
                                End If
                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_510()
        Dim inconsistencia As String = "Clase de construcción invalida diferente de 3 para identificador mayor de 500."
        Dim codigo As String = "510"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))) = True Then
                                If Val(Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))) > 500 Then
                                    If dt_FIPRCONS.Rows(i).Item("FPCOCLCO") <> 3 Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                    End If
                                End If
                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_511()
        Dim inconsistencia As String = "Clase de construcción invalida para identificador no convencional."
        Dim codigo As String = "511"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))) = False Then
                                If dt_FIPRCONS.Rows(i).Item("FPCOCLCO") <> 2 Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))

                                End If
                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_512()
        Dim inconsistencia As String = "Identificador residencial invalido calificación 111."
        Dim codigo As String = "512"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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
                                            If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 111 Then

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
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

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try


    End Sub
    Private Sub pro_Inconsistencia_513()
        Dim inconsistencia As String = "Identificador residencial invalido calificación 112."
        Dim codigo As String = "513"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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
                                            If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 112 Then

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
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

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_514()
        Dim inconsistencia As String = "Identificador residencial invalido calificación 113."
        Dim codigo As String = "514"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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
                                            If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 113 Then

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID"))
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

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_515()
        Dim inconsistencia As String = "Código 111 cruce invalido con 124-125-134-135-136-144-214-215-244-425-433-443 tipo residencial."
        Dim codigo As String = "515"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            If dt_FIPRCACO.Rows.Count > 0 Then

                                Dim sw1 As Byte = 0
                                Dim j1 As Integer = 0

                                While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 111 AndAlso _
                                           Trim(dt_FIPRCACO.Rows(j1).Item("FPCCTIPO")) = "R" Then

                                            Dim k As Integer = 0

                                            For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                    If dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 124 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 125 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 134 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 135 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 136 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 144 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 214 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 215 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 244 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 425 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 433 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 443 Then

                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI"))
                                                    End If

                                                End If

                                            Next

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

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_516()
        Dim inconsistencia As String = "Código 111 cruce invalido con 124-125-134-135-136-144-214-215-244 tipo comercial."
        Dim codigo As String = "516"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            If dt_FIPRCACO.Rows.Count > 0 Then

                                Dim sw1 As Byte = 0
                                Dim j1 As Integer = 0

                                While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 111 AndAlso _
                                           Trim(dt_FIPRCACO.Rows(j1).Item("FPCCTIPO")) = "C" Then

                                            Dim k As Integer = 0

                                            For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                    If dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 124 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 125 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 134 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 135 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 136 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 144 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 214 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 215 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 244 Then

                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI"))
                                                    End If

                                                End If

                                            Next

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

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_517()
        Dim inconsistencia As String = "Código 111 cruce invalido con 124-125-134-135-143-144-212-213-243-244 tipo industrial."
        Dim codigo As String = "517"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            If dt_FIPRCACO.Rows.Count > 0 Then

                                Dim sw1 As Byte = 0
                                Dim j1 As Integer = 0

                                While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 111 AndAlso _
                                           Trim(dt_FIPRCACO.Rows(j1).Item("FPCCTIPO")) = "I" Then

                                            Dim k As Integer = 0

                                            For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                    If dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 124 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 125 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 134 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 135 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 143 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 144 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 212 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 213 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 243 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 244 Then

                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI"))
                                                    End If

                                                End If

                                            Next

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

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_518()
        Dim inconsistencia As String = "Código 312 cruce invalido con 334-335 tipo residencial."
        Dim codigo As String = "518"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            If dt_FIPRCACO.Rows.Count > 0 Then

                                Dim sw1 As Byte = 0
                                Dim j1 As Integer = 0

                                While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 312 AndAlso _
                                           Trim(dt_FIPRCACO.Rows(j1).Item("FPCCTIPO")) = "R" Then

                                            Dim k As Integer = 0

                                            For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                    If dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 334 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 335 Then

                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI"))
                                                    End If

                                                End If

                                            Next

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

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_519()
        Dim inconsistencia As String = "Código 412 cruce invalido con 434-435 tipo residencial."
        Dim codigo As String = "519"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            If dt_FIPRCACO.Rows.Count > 0 Then

                                Dim sw1 As Byte = 0
                                Dim j1 As Integer = 0

                                While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 412 AndAlso _
                                           Trim(dt_FIPRCACO.Rows(j1).Item("FPCCTIPO")) = "R" Then

                                            Dim k As Integer = 0

                                            For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                    If dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 434 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 435 Then

                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI"))
                                                    End If

                                                End If

                                            Next

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

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_520()
        Dim inconsistencia As String = "Código 112 cruce invalido con 121-122-123-125-131-133-135-136-214-215-224-225-231-236-237-314-334-335-414-425-433-434-435-443-444 tipo residencial."
        Dim codigo As String = "520"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            If dt_FIPRCACO.Rows.Count > 0 Then

                                Dim sw1 As Byte = 0
                                Dim j1 As Integer = 0

                                While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 112 AndAlso _
                                           Trim(dt_FIPRCACO.Rows(j1).Item("FPCCTIPO")) = "R" Then

                                            Dim k As Integer = 0

                                            For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                    If dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 121 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 122 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 123 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 125 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 131 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 133 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 135 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 136 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 214 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 215 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 224 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 225 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 231 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 236 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 237 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 314 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 334 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 335 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 414 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 425 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 433 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 434 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 435 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 443 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 444 Then

                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI"))
                                                    End If

                                                End If

                                            Next

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

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_521()
        Dim inconsistencia As String = "Código 112 cruce invalido con 121-122-123-125-131-133-135-231 tipo comercial."
        Dim codigo As String = "521"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            If dt_FIPRCACO.Rows.Count > 0 Then

                                Dim sw1 As Byte = 0
                                Dim j1 As Integer = 0

                                While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 112 AndAlso _
                                           Trim(dt_FIPRCACO.Rows(j1).Item("FPCCTIPO")) = "C" Then

                                            Dim k As Integer = 0

                                            For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                    If dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 121 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 122 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 123 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 125 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 131 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 133 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 135 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 231 Then

                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI"))
                                                    End If

                                                End If

                                            Next

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

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_522()
        Dim inconsistencia As String = "Código 112 cruce invalido con 121-122-123-125-131-133-135-512-513-514 tipo industrial."
        Dim codigo As String = "522"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            If dt_FIPRCACO.Rows.Count > 0 Then

                                Dim sw1 As Byte = 0
                                Dim j1 As Integer = 0

                                While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 112 AndAlso _
                                           Trim(dt_FIPRCACO.Rows(j1).Item("FPCCTIPO")) = "I" Then

                                            Dim k As Integer = 0

                                            For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                    If dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 121 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 122 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 123 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 125 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 131 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 133 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 135 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 512 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 513 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 514 Then

                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI"))
                                                    End If

                                                End If

                                            Next

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

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_523()
        Dim inconsistencia As String = "Código 113 cruce invalido con 121-122-124-135 tipo residencial."
        Dim codigo As String = "523"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            If dt_FIPRCACO.Rows.Count > 0 Then

                                Dim sw1 As Byte = 0
                                Dim j1 As Integer = 0

                                While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 113 AndAlso _
                                           Trim(dt_FIPRCACO.Rows(j1).Item("FPCCTIPO")) = "R" Then

                                            Dim k As Integer = 0

                                            For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                    If dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 121 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 122 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 124 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 135 Then

                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI"))
                                                    End If

                                                End If

                                            Next

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

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_524()
        Dim inconsistencia As String = "Código 113 cruce invalido con 121-122-124-135 tipo comercial."
        Dim codigo As String = "524"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            If dt_FIPRCACO.Rows.Count > 0 Then

                                Dim sw1 As Byte = 0
                                Dim j1 As Integer = 0

                                While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 113 AndAlso _
                                           Trim(dt_FIPRCACO.Rows(j1).Item("FPCCTIPO")) = "C" Then

                                            Dim k As Integer = 0

                                            For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                    If dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 121 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 122 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 124 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 135 Then

                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI"))
                                                    End If

                                                End If

                                            Next

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

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_525()
        Dim inconsistencia As String = "Código 113 cruce invalido con los códigos 121-144 tipo industrial."
        Dim codigo As String = "525"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            If dt_FIPRCACO.Rows.Count > 0 Then

                                Dim sw1 As Byte = 0
                                Dim j1 As Integer = 0

                                While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 113 AndAlso _
                                           Trim(dt_FIPRCACO.Rows(j1).Item("FPCCTIPO")) = "I" Then

                                            Dim k As Integer = 0

                                            For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                    If dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 121 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 144 Then

                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI"))
                                                    End If

                                                End If

                                            Next

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

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_526()
        Dim inconsistencia As String = "Código 114 cruce invalido con el código 124 tipo residencial."
        Dim codigo As String = "526"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            If dt_FIPRCACO.Rows.Count > 0 Then

                                Dim sw1 As Byte = 0
                                Dim j1 As Integer = 0

                                While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 114 AndAlso _
                                           Trim(dt_FIPRCACO.Rows(j1).Item("FPCCTIPO")) = "R" Then

                                            Dim k As Integer = 0

                                            For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                    If dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 124 Then

                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI"))
                                                    End If

                                                End If

                                            Next

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

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_527()
        Dim inconsistencia As String = "Código 114 cruce invalido con el código 124 tipo comercial."
        Dim codigo As String = "527"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            If dt_FIPRCACO.Rows.Count > 0 Then

                                Dim sw1 As Byte = 0
                                Dim j1 As Integer = 0

                                While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 114 AndAlso _
                                           Trim(dt_FIPRCACO.Rows(j1).Item("FPCCTIPO")) = "C" Then

                                            Dim k As Integer = 0

                                            For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                    If dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 124 Then

                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI"))
                                                    End If

                                                End If

                                            Next

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

                    Next

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_528()
        Dim inconsistencia As String = "Código 114 cruce invalido con el código 124 tipo industrial."
        Dim codigo As String = "528"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            If dt_FIPRCACO.Rows.Count > 0 Then

                                Dim sw1 As Byte = 0
                                Dim j1 As Integer = 0

                                While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 114 AndAlso _
                                           Trim(dt_FIPRCACO.Rows(j1).Item("FPCCTIPO")) = "I" Then

                                            Dim k As Integer = 0

                                            For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                    If dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 124 Then

                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI"))
                                                    End If

                                                End If

                                            Next

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

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_529()
        Dim inconsistencia As String = "Código 311 no puede existir otro código dentro del bloque."
        Dim codigo As String = "529"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            If dt_FIPRCACO.Rows.Count > 0 Then

                                Dim sw1 As Byte = 0
                                Dim j1 As Integer = 0

                                While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 311 AndAlso _
                                           Trim(dt_FIPRCACO.Rows(j1).Item("FPCCTIPO")) = "R" Then

                                            Dim k As Integer = 0

                                            For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                    If dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 321 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 322 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 323 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 324 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 325 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 326 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 331 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 332 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 333 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 334 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 335 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 341 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 342 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 343 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 344 Then

                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI"))
                                                    End If

                                                End If

                                            Next

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

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_530()
        Dim inconsistencia As String = "Código 411 no puede existir otro código dentro del bloque."
        Dim codigo As String = "530"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            If dt_FIPRCACO.Rows.Count > 0 Then

                                Dim sw1 As Byte = 0
                                Dim j1 As Integer = 0

                                While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 411 AndAlso _
                                           Trim(dt_FIPRCACO.Rows(j1).Item("FPCCTIPO")) = "R" Then

                                            Dim k As Integer = 0

                                            For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                    If dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 421 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 422 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 423 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 424 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 425 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 426 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 431 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 432 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 433 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 434 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 435 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 441 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 442 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 443 Or _
                                                       dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 444 Then

                                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI"))
                                                    End If

                                                End If

                                            Next

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

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_531()
        Dim inconsistencia As String = "Construcción prefabricada con código 112 y con Nro. De piso diferente de uno."
        Dim codigo As String = "531"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            If dt_FIPRCACO.Rows.Count > 0 Then

                                Dim sw1 As Byte = 0
                                Dim j1 As Integer = 0

                                While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 112 AndAlso _
                                           Trim(dt_FIPRCACO.Rows(j1).Item("FPCCTIPO")) = "R" Then

                                            If dt_FIPRCONS.Rows(i).Item("FPCOPISO") <> 1 Then

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Nro. Pisos: " & dt_FIPRCONS.Rows(i).Item("FPCOPISO"))

                                            End If

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

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_532()
        Dim inconsistencia As String = "Código invalido para identificador residencial."
        Dim codigo As String = "532"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            Dim stFIPRDEPA As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                            Dim stFIPRMUNI As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                            Dim stFIPRCLSE As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE"))
                            Dim stFPCOCLCO As String = Trim(dt_FIPRCONS.Rows(i).Item("FPCOCLCO"))
                            Dim stFPCOTICO As String = Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))
                            
                            Dim objDatos As New cla_TIPOCONS
                            Dim tbl As DataTable

                            tbl = objDatos.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(stFIPRDEPA, stFIPRMUNI, stFPCOCLCO, stFIPRCLSE, stFPCOTICO)

                            If tbl.Rows.Count > 0 Then

                                Dim stTICOTIPO As String = Trim(tbl.Rows(0).Item("TICOTIPO"))

                                If stTICOTIPO = "R" Then

                                    If dt_FIPRCACO.Rows.Count > 0 Then

                                        Dim sw1 As Byte = 0
                                        Dim j1 As Integer = 0

                                        While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                            If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then

                                                Dim k As Integer = 0

                                                For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                        If dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 511 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 512 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 513 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 514 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 515 Then

                                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI") & " Identificador: " & dt_FIPRCONS.Rows(i).Item("FPCOTICO"))
                                                        End If

                                                    End If

                                                Next

                                                sw1 = 1
                                            Else
                                                j1 = j1 + 1
                                            End If

                                        End While

                                    End If
                                End If
                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_533()
        Dim inconsistencia As String = "Código invalido para identificador comercial."
        Dim codigo As String = "533"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            Dim stFIPRDEPA As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                            Dim stFIPRMUNI As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                            Dim stFIPRCLSE As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE"))
                            Dim stFPCOCLCO As String = Trim(dt_FIPRCONS.Rows(i).Item("FPCOCLCO"))
                            Dim stFPCOTICO As String = Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))

                            Dim objDatos As New cla_TIPOCONS
                            Dim tbl As DataTable

                            tbl = objDatos.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(stFIPRDEPA, stFIPRMUNI, stFPCOCLCO, stFIPRCLSE, stFPCOTICO)

                            If tbl.Rows.Count > 0 Then

                                Dim stTICOTIPO As String = Trim(tbl.Rows(0).Item("TICOTIPO"))

                                If stTICOTIPO = "C" Then

                                    If dt_FIPRCACO.Rows.Count > 0 Then

                                        Dim sw1 As Byte = 0
                                        Dim j1 As Integer = 0

                                        While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                            If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then

                                                Dim k As Integer = 0

                                                For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                        If dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 311 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 312 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 313 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 314 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 321 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 322 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 323 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 324 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 325 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 326 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 341 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 342 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 343 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 344 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 411 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 412 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 413 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 414 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 421 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 422 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 423 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 424 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 425 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 426 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 441 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 442 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 443 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 444 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 511 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 512 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 513 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 514 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 515 Then

                                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI") & " Identificador: " & dt_FIPRCONS.Rows(i).Item("FPCOTICO"))
                                                        End If

                                                    End If

                                                Next

                                                sw1 = 1
                                            Else
                                                j1 = j1 + 1
                                            End If

                                        End While

                                    End If
                                End If
                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_534()
        Dim inconsistencia As String = "Código invalido para identificador industrial."
        Dim codigo As String = "534"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            Dim stFIPRDEPA As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                            Dim stFIPRMUNI As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                            Dim stFIPRCLSE As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE"))
                            Dim stFPCOCLCO As String = Trim(dt_FIPRCONS.Rows(i).Item("FPCOCLCO"))
                            Dim stFPCOTICO As String = Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))

                            Dim objDatos As New cla_TIPOCONS
                            Dim tbl As DataTable

                            tbl = objDatos.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(stFIPRDEPA, stFIPRMUNI, stFPCOCLCO, stFIPRCLSE, stFPCOTICO)

                            If tbl.Rows.Count > 0 Then

                                Dim stTICOTIPO As String = Trim(tbl.Rows(0).Item("TICOTIPO"))

                                If stTICOTIPO = "I" Then

                                    If dt_FIPRCACO.Rows.Count > 0 Then

                                        Dim sw1 As Byte = 0
                                        Dim j1 As Integer = 0

                                        While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                            If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then

                                                Dim k As Integer = 0

                                                For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                        If dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 115 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 136 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 214 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 215 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 223 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 224 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 225 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 234 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 236 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 237 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 311 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 312 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 313 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 314 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 321 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 322 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 323 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 324 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 325 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 326 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 331 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 332 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 333 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 334 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 335 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 341 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 342 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 343 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 344 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 411 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 412 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 413 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 414 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 421 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 422 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 423 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 424 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 425 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 426 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 431 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 432 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 433 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 434 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 435 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 441 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 442 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 443 Or _
                                                           dt_FIPRCACO.Rows(k).Item("FPCCCODI") = 444 Then

                                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI") & " Identificador: " & dt_FIPRCONS.Rows(i).Item("FPCOTICO"))
                                                        End If

                                                    End If

                                                Next

                                                sw1 = 1
                                            Else
                                                j1 = j1 + 1
                                            End If

                                        End While

                                    End If
                                End If
                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_535()
        Dim inconsistencia As String = "Tipo del código de calificación diferente al tipo del identificador residencial."
        Dim codigo As String = "535"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            Dim stFIPRDEPA As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                            Dim stFIPRMUNI As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                            Dim stFIPRCLSE As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE"))
                            Dim stFPCOCLCO As String = Trim(dt_FIPRCONS.Rows(i).Item("FPCOCLCO"))
                            Dim stFPCOTICO As String = Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))

                            Dim objDatos As New cla_TIPOCONS
                            Dim tbl As DataTable

                            tbl = objDatos.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(stFIPRDEPA, stFIPRMUNI, stFPCOCLCO, stFIPRCLSE, stFPCOTICO)

                            If tbl.Rows.Count > 0 Then

                                Dim stTICOTIPO As String = Trim(tbl.Rows(0).Item("TICOTIPO"))

                                If stTICOTIPO = "R" Then

                                    If dt_FIPRCACO.Rows.Count > 0 Then

                                        Dim sw1 As Byte = 0
                                        Dim j1 As Integer = 0

                                        While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                            If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then

                                                Dim k As Integer = 0

                                                For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                        If Trim(dt_FIPRCACO.Rows(k).Item("FPCCTIPO")) <> "R" Then

                                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI") & " Identificador: " & dt_FIPRCONS.Rows(i).Item("FPCOTICO") & " Tipo: " & dt_FIPRCACO.Rows(k).Item("FPCCTIPO"))
                                                        End If

                                                    End If

                                                Next

                                                sw1 = 1
                                            Else
                                                j1 = j1 + 1
                                            End If

                                        End While

                                    End If
                                End If
                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_536()
        Dim inconsistencia As String = "Tipo del código de calificación diferente al tipo del identificador comercial."
        Dim codigo As String = "536"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            Dim stFIPRDEPA As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                            Dim stFIPRMUNI As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                            Dim stFIPRCLSE As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE"))
                            Dim stFPCOCLCO As String = Trim(dt_FIPRCONS.Rows(i).Item("FPCOCLCO"))
                            Dim stFPCOTICO As String = Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))

                            Dim objDatos As New cla_TIPOCONS
                            Dim tbl As DataTable

                            tbl = objDatos.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(stFIPRDEPA, stFIPRMUNI, stFPCOCLCO, stFIPRCLSE, stFPCOTICO)

                            If tbl.Rows.Count > 0 Then

                                Dim stTICOTIPO As String = Trim(tbl.Rows(0).Item("TICOTIPO"))

                                If stTICOTIPO = "C" Then

                                    If dt_FIPRCACO.Rows.Count > 0 Then

                                        Dim sw1 As Byte = 0
                                        Dim j1 As Integer = 0

                                        While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                            If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then

                                                Dim k As Integer = 0

                                                For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                        If Trim(dt_FIPRCACO.Rows(k).Item("FPCCTIPO")) <> "C" Then

                                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI") & " Identificador: " & dt_FIPRCONS.Rows(i).Item("FPCOTICO") & " Tipo: " & dt_FIPRCACO.Rows(k).Item("FPCCTIPO"))
                                                        End If

                                                    End If

                                                Next

                                                sw1 = 1
                                            Else
                                                j1 = j1 + 1
                                            End If

                                        End While

                                    End If
                                End If
                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_537()
        Dim inconsistencia As String = "Tipo del código de calificación diferente al tipo del identificador industrial."
        Dim codigo As String = "537"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer = 0

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then

                            Dim stFIPRDEPA As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA"))
                            Dim stFIPRMUNI As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI"))
                            Dim stFIPRCLSE As String = Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE"))
                            Dim stFPCOCLCO As String = Trim(dt_FIPRCONS.Rows(i).Item("FPCOCLCO"))
                            Dim stFPCOTICO As String = Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO"))

                            Dim objDatos As New cla_TIPOCONS
                            Dim tbl As DataTable

                            tbl = objDatos.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(stFIPRDEPA, stFIPRMUNI, stFPCOCLCO, stFIPRCLSE, stFPCOTICO)

                            If tbl.Rows.Count > 0 Then

                                Dim stTICOTIPO As String = Trim(tbl.Rows(0).Item("TICOTIPO"))

                                If stTICOTIPO = "I" Then

                                    If dt_FIPRCACO.Rows.Count > 0 Then

                                        Dim sw1 As Byte = 0
                                        Dim j1 As Integer = 0

                                        While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                            If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then

                                                Dim k As Integer = 0

                                                For k = 0 To dt_FIPRCACO.Rows.Count - 1

                                                    If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(k).Item("FPCCUNID") Then

                                                        If Trim(dt_FIPRCACO.Rows(k).Item("FPCCTIPO")) <> "I" Then

                                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Código: " & dt_FIPRCACO.Rows(k).Item("FPCCCODI") & " Identificador: " & dt_FIPRCONS.Rows(i).Item("FPCOTICO") & " Tipo: " & dt_FIPRCACO.Rows(k).Item("FPCCTIPO"))
                                                        End If

                                                    End If

                                                Next

                                                sw1 = 1
                                            Else
                                                j1 = j1 + 1
                                            End If

                                        End While

                                    End If
                                End If
                            End If
                        End If

                    Next

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_538()
        Dim inconsistencia As String = "No existe codigo de calificación de tipo residencial."
        Dim codigo As String = "538"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count = 1 Then

                    If Trim(dt_FIPRCONS.Rows(0).Item("FPCOESTA")) = "ac" Then

                        If dt_FIPRCACO.Rows.Count > 0 Then

                            Dim boEstructura_Armazon As Boolean = False
                            Dim boEstructura_Muros As Boolean = False
                            Dim boEstructura_Cubierta As Boolean = False
                            Dim boEstructura_Conservacion As Boolean = False
                            Dim boAcabados_Fachadas As Boolean = False
                            Dim boAcabados_Muros As Boolean = False
                            Dim boAcabados_Pisos As Boolean = False
                            Dim boAcabados_Conservacion As Boolean = False
                            Dim boValidaBano As Boolean = True
                            Dim boBano_Tamano As Boolean = False
                            Dim boBano_Enchapes As Boolean = False
                            Dim boBano_Mobiliario As Boolean = False
                            Dim boBano_Conservacion As Boolean = False
                            Dim boValidaCocina As Boolean = True
                            Dim boCocina_Tamano As Boolean = False
                            Dim boCocina_Enchapes As Boolean = False
                            Dim boCocina_Mobiliario As Boolean = False
                            Dim boCocina_Conservacion As Boolean = False

                            Dim boResidencial As Boolean = False

                            Dim sw1 As Byte = 0
                            Dim j1 As Integer = 0

                            While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0

                                If Trim(dt_FIPRCACO.Rows(j1).Item("FPCCTIPO")) = "R" Then

                                    boResidencial = True

                                    If dt_FIPRCONS.Rows(0).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 311 Then
                                            boValidaBano = False
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 411 Then
                                            boValidaCocina = False
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 111 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 112 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 113 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 114 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 115 Then

                                            boEstructura_Armazon = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 121 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 122 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 123 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 124 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 125 Then

                                            boEstructura_Muros = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 131 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 132 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 133 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 134 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 135 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 136 Then

                                            boEstructura_Cubierta = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 141 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 142 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 143 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 144 Then

                                            boEstructura_Conservacion = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 211 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 212 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 213 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 214 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 215 Then

                                            boAcabados_Fachadas = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 221 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 222 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 223 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 224 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 225 Then

                                            boAcabados_Muros = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 231 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 232 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 233 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 234 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 235 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 236 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 237 Then

                                            boAcabados_Pisos = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 241 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 242 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 243 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 244 Then

                                            boAcabados_Conservacion = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 311 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 312 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 313 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 314 Then

                                            boBano_Tamano = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 321 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 322 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 323 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 324 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 325 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 326 Then

                                            boBano_Enchapes = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 331 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 332 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 333 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 334 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 335 Then

                                            boBano_Mobiliario = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 341 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 342 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 343 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 344 Then

                                            boBano_Conservacion = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 411 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 412 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 413 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 414 Then

                                            boCocina_Tamano = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 421 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 422 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 423 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 424 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 425 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 426 Then

                                            boCocina_Enchapes = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 431 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 432 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 433 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 434 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 435 Then

                                            boCocina_Mobiliario = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 441 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 442 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 443 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 444 Then

                                            boCocina_Conservacion = True
                                        End If

                                        j1 = j1 + 1

                                    End If

                                Else
                                    sw1 = 1
                                End If

                            End While

                            If boResidencial = True Then

                                If boEstructura_Armazon = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Estructura - Armazon")
                                End If
                                If boEstructura_Muros = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Estructura - Muros")
                                End If
                                If boEstructura_Cubierta = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Estructura - Cubierta")
                                End If
                                If boEstructura_Conservacion = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Estructura - Conservacion")
                                End If

                                If boAcabados_Fachadas = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Acabados - Fachada")
                                End If
                                If boAcabados_Muros = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Acabados - Muros")
                                End If
                                If boAcabados_Pisos = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Acabados - Pisos")
                                End If
                                If boAcabados_Conservacion = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Acabados - Conservacion")
                                End If

                                If boValidaBano = True Then
                                    If boBano_Tamano = False Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Baño - Tamaño")
                                    End If
                                    If boBano_Enchapes = False Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Baño - Enchapes")
                                    End If
                                    If boBano_Mobiliario = False Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Baño - Mobiliario")
                                    End If
                                    If boBano_Conservacion = False Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Baño - Conservacion")
                                    End If
                                End If

                                If boValidaCocina = True Then
                                    If boCocina_Tamano = False Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Cocina - Tamaño")
                                    End If
                                    If boCocina_Enchapes = False Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Cocina - Enchapes")
                                    End If
                                    If boCocina_Mobiliario = False Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Cocina - Mobiliario")
                                    End If
                                    If boCocina_Conservacion = False Then
                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Cocina - Conservacion")
                                    End If
                                End If

                            End If

                        End If
                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_539()
        Dim inconsistencia As String = "No existe codigo de calificación de tipo comercial."
        Dim codigo As String = "539"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count = 1 Then

                    If Trim(dt_FIPRCONS.Rows(0).Item("FPCOESTA")) = "ac" Then

                        If dt_FIPRCACO.Rows.Count > 0 Then

                            Dim boEstructura_Armazon As Boolean = False
                            Dim boEstructura_Muros As Boolean = False
                            Dim boEstructura_Cubierta As Boolean = False
                            Dim boEstructura_Conservacion As Boolean = False
                            Dim boAcabados_Fachadas As Boolean = False
                            Dim boAcabados_Muros As Boolean = False
                            Dim boAcabados_Pisos As Boolean = False
                            Dim boAcabados_Conservacion As Boolean = False
                            Dim boBano_Mobiliario As Boolean = False
                            Dim boCocina_Mobiliario As Boolean = False

                            Dim boComercial As Boolean = False

                            Dim sw1 As Byte = 0
                            Dim j1 As Integer = 0

                            While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0

                                If Trim(dt_FIPRCACO.Rows(j1).Item("FPCCTIPO")) = "C" Then

                                    boComercial = True

                                    If dt_FIPRCONS.Rows(0).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 111 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 112 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 113 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 114 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 115 Then

                                            boEstructura_Armazon = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 121 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 122 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 123 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 124 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 125 Then

                                            boEstructura_Muros = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 131 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 132 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 133 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 134 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 135 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 136 Then

                                            boEstructura_Cubierta = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 141 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 142 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 143 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 144 Then

                                            boEstructura_Conservacion = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 211 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 212 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 213 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 214 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 215 Then

                                            boAcabados_Fachadas = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 221 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 222 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 223 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 224 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 225 Then

                                            boAcabados_Muros = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 231 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 232 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 233 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 234 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 235 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 236 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 237 Then

                                            boAcabados_Pisos = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 241 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 242 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 243 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 244 Then

                                            boAcabados_Conservacion = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 331 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 332 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 333 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 334 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 335 Then

                                            boBano_Mobiliario = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 431 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 432 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 433 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 434 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 435 Then

                                            boCocina_Mobiliario = True
                                        End If

                                        j1 = j1 + 1

                                    End If

                                Else
                                    sw1 = 1
                                End If

                            End While

                            If boComercial = True Then

                                If boEstructura_Armazon = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Estructura - Armazon")
                                End If
                                If boEstructura_Muros = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Estructura - Muros")
                                End If
                                If boEstructura_Cubierta = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Estructura - Cubierta")
                                End If
                                If boEstructura_Conservacion = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Estructura - Conservacion")
                                End If

                                If boAcabados_Fachadas = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Acabados - Fachada")
                                End If
                                If boAcabados_Muros = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Acabados - Muros")
                                End If
                                If boAcabados_Pisos = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Acabados - Pisos")
                                End If
                                If boAcabados_Conservacion = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Acabados - Conservacion")
                                End If

                                If boBano_Mobiliario = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Baño - Mobiliario")
                                End If

                                If boCocina_Mobiliario = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Cocina - Mobiliario")
                                End If

                            End If

                        End If
                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_540()
        Dim inconsistencia As String = "No existe codigo de calificación de tipo industrial."
        Dim codigo As String = "540"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count = 1 Then

                    If Trim(dt_FIPRCONS.Rows(0).Item("FPCOESTA")) = "ac" Then

                        If dt_FIPRCACO.Rows.Count > 0 Then

                            Dim boEstructura_Armazon As Boolean = False
                            Dim boEstructura_Muros As Boolean = False
                            Dim boEstructura_Cubierta As Boolean = False
                            Dim boEstructura_Conservacion As Boolean = False
                            Dim boAcabados_Fachadas As Boolean = False
                            Dim boAcabados_Muros As Boolean = False
                            Dim boAcabados_Pisos As Boolean = False
                            Dim boAcabados_Conservacion As Boolean = False

                            Dim boIndustrial As Boolean = False

                            Dim sw1 As Byte = 0
                            Dim j1 As Integer = 0

                            While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0

                                If Trim(dt_FIPRCACO.Rows(j1).Item("FPCCTIPO")) = "I" Then

                                    boIndustrial = True

                                    If dt_FIPRCONS.Rows(0).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 111 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 112 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 113 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 114 Then

                                            boEstructura_Armazon = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 121 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 122 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 123 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 124 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 125 Then

                                            boEstructura_Muros = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 131 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 132 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 133 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 134 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 135 Then

                                            boEstructura_Cubierta = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 141 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 142 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 143 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 144 Then

                                            boEstructura_Conservacion = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 211 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 212 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 213 Then

                                            boAcabados_Fachadas = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 221 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 222 Then

                                            boAcabados_Muros = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 231 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 232 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 233 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 235 Then

                                            boAcabados_Pisos = True
                                        End If

                                        If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 241 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 242 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 243 Or _
                                           dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 244 Then

                                            boAcabados_Conservacion = True
                                        End If

                                        j1 = j1 + 1

                                    End If

                                Else
                                    sw1 = 1
                                End If

                            End While

                            If boIndustrial = True Then

                                If boEstructura_Armazon = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Estructura - Armazon")
                                End If
                                If boEstructura_Muros = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Estructura - Muros")
                                End If
                                If boEstructura_Cubierta = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Estructura - Cubierta")
                                End If
                                If boEstructura_Conservacion = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Estructura - Conservacion")
                                End If

                                If boAcabados_Fachadas = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Acabados - Fachada")
                                End If
                                If boAcabados_Muros = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Acabados - Muros")
                                End If
                                If boAcabados_Pisos = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Acabados - Pisos")
                                End If
                                If boAcabados_Conservacion = False Then
                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(0).Item("FPCOUNID") & " Código: " & "Acabados - Conservacion")
                                End If

                            End If

                        End If
                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_541()
        Dim inconsistencia As String = "Parqueadero con codigo invalido de calificación de tipo residencial."
        Dim codigo As String = "541"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRCONS.Rows.Count > 0 Then

                    Dim i As Integer

                    For i = 0 To dt_FIPRCONS.Rows.Count - 1

                        If Trim(dt_FIPRCONS.Rows(i).Item("FPCOESTA")) = "ac" Then
                            If Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "050" Or _
                               Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "014" Or _
                               Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "075" Or _
                               Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "75A" Or _
                               Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "75B" Or _
                               Trim(dt_FIPRCONS.Rows(i).Item("FPCOTICO")) = "75C" Then

                                If dt_FIPRCACO.Rows.Count > 0 Then

                                    Dim sw1 As Byte = 0
                                    Dim j1 As Integer = 0

                                    While j1 < dt_FIPRCACO.Rows.Count And sw1 = 0
                                        If dt_FIPRCONS.Rows(i).Item("FPCOUNID") = dt_FIPRCACO.Rows(j1).Item("FPCCUNID") Then
                                            If dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 223 Or _
                                                dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 224 Or _
                                                dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 225 Or _
                                                dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 233 Or _
                                                dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 234 Or _
                                                dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 235 Or _
                                                dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 236 Or _
                                                dt_FIPRCACO.Rows(j1).Item("FPCCCODI") = 237 Then

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidad nro: " & dt_FIPRCONS.Rows(i).Item("FPCOUNID") & " Codigo: " & dt_FIPRCACO.Rows(j1).Item("FPCCCODI"))
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

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub

#End Region

#Region "Validar FiprLind 600"

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
            pro_Inconsistencia_610()
            pro_Inconsistencia_611()
            pro_Inconsistencia_612()

        Catch ex As Exception
            MessageBox.Show(Err.Description & ". Linderos")
        End Try

    End Sub

    Private Sub pro_Inconsistencia_600()
        Dim inconsistencia As String = "Falta punto cardinal norte."
        Dim codigo As String = "600"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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
                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_601()
        Dim inconsistencia As String = "Falta punto cardinal oriente."
        Dim codigo As String = "601"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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
                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_602()
        Dim inconsistencia As String = "Falta punto cardinal occidente."
        Dim codigo As String = "602"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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
                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_603()
        Dim inconsistencia As String = "Falta punto cardinal sur."
        Dim codigo As String = "603"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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
                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_604()
        Dim inconsistencia As String = "Falta punto cardinal nadir para característica rph."
        Dim codigo As String = "604"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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
                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                            End If

                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_605()
        Dim inconsistencia As String = "Falta punto cardinal zenit para característica rph."
        Dim codigo As String = "605"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

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
                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                            End If

                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_606()
        Dim inconsistencia As String = "Linderos esta la expresión expansión."
        Dim codigo As String = "606"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRLIND.Rows.Count > 0 Then

                    Dim filas() As DataRow

                    filas = dt_FIPRLIND.Select("FPLICOLI like '%EXPANSI%' and FPLIESTA = 'ac'")

                    If filas.Length > 0 Then
                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_607()
        Dim inconsistencia As String = "Linderos esta la expresión rural."
        Dim codigo As String = "607"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRLIND.Rows.Count > 0 Then

                    Dim filas() As DataRow

                    filas = dt_FIPRLIND.Select("FPLICOLI like '%RURAL%' and FPLIESTA = 'ac'")

                    If filas.Length > 0 Then
                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_608()
        Dim inconsistencia As String = "Linderos esta la expresión urbana."
        Dim codigo As String = "608"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRLIND.Rows.Count > 0 Then

                    Dim filas() As DataRow

                    filas = dt_FIPRLIND.Select("FPLICOLI like '%URBAN%' and FPLIESTA = 'ac'")

                    If filas.Length > 0 Then
                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_609()
        Dim inconsistencia As String = "Lindero con espacio en blanco al inicio."
        Dim codigo As String = "609"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRLIND.Rows.Count > 0 Then

                    Dim filas() As DataRow

                    filas = dt_FIPRLIND.Select("FPLICOLI like ' %' and FPLIESTA = 'ac'")

                    If filas.Length > 0 Then
                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_610()
        Dim inconsistencia As String = "Ficha resumen con punto cardinal nadir."
        Dim codigo As String = "610"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Or dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
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

                        If inContador = 1 Then
                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                        End If
                    End If
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_611()
        Dim inconsistencia As String = "Ficha resumen con punto cardinal zenit."
        Dim codigo As String = "611"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Or dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                    If dt_FIPRLIND.Rows.Count > 0 Then

                        Dim inContador As Byte = 0
                        Dim sw1 As Byte = 0
                        Dim j1 As Integer = 0

                        While j1 < dt_FIPRLIND.Rows.Count And sw1 = 0
                            If Trim(dt_FIPRLIND.Rows(j1).Item("FPLIESTA")) = "ac" Then
                                If Trim(dt_FIPRLIND.Rows(j1).Item("FPLIPUCA")) = "ZE" Then
                                    inContador = 1
                                    sw1 = 1
                                Else
                                    j1 = j1 + 1
                                End If
                            Else
                                j1 = j1 + 1
                            End If
                        End While

                        If inContador = 1 Then
                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_612()
        Dim inconsistencia As String = "Longitud menor para la estructura de lindero."
        Dim codigo As String = "612"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                Dim i As Integer = 0

                For i = 0 To dt_FIPRLIND.Rows.Count - 1

                    If Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) = Trim(dt_FIPRLIND.Rows(i).Item("FPLICOLI").ToString.Substring(0, 3)) Then

                        Dim stDato As String = Trim(dt_FIPRLIND.Rows(i).Item("FPLICOLI"))
                        Dim inLongitud As Integer = stDato.Length

                        If inLongitud < 19 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & "Punto cardinal: " & Trim(dt_FIPRLIND.Rows(i).Item("FPLIPUCA").ToString & " - Lindero: " & dt_FIPRLIND.Rows(i).Item("FPLICOLI").ToString))

                        End If
                    End If

                Next

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub

#End Region

#Region "Validar FiprCart 700"

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
            pro_Inconsistencia_715()
            pro_Inconsistencia_716()
            pro_Inconsistencia_717()
            pro_Inconsistencia_718()
            pro_Inconsistencia_719()
            pro_Inconsistencia_720()
            pro_Inconsistencia_721()
            pro_Inconsistencia_722()
            pro_Inconsistencia_723()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_Inconsistencia_700()
        Dim inconsistencia As String = "Codificación letras minúsculas no válida para la escala de 1:25000"
        Dim codigo As String = "700"
        Dim stError As String = "SEVERO"

        Try

            'If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
            '    If dt_FIPRCART.Rows.Count > 0 Then

            '        Dim i As Integer

            '        For i = 0 To dt_FIPRCART.Rows.Count - 1

            '            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
            '                If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:25000" Then
            '                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 8 Then
            '                        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(7, 1)) = False Then
            '                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(7, 1).ToLower = True Then

            '                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

            '                            End If
            '                        End If
            '                    End If
            '                End If
            '            End If

            '        Next

            '    End If
            'End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_701()
        Dim inconsistencia As String = "Codificación numérica no válida para la escala  1:25000"
        Dim codigo As String = "701"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:25000" Then
                                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 8 Then
                                        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(0, 3)) = False Then

                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                        End If
                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_702()
        Dim inconsistencia As String = "Codificación mayor a la longitud valida para la escala 1:25000"
        Dim codigo As String = "702"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:25000" Then
                                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length > 8 Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_703()
        Dim inconsistencia As String = "Codificación letras mayúsculas no valida para la escala  1:25000"
        Dim codigo As String = "703"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then

                        Dim i As Integer
                        Dim bySW As Byte = 0
                        Dim bySW1 As Byte = 0

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:25000" Then
                                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 8 Then
                                        If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(7, 1).ToUpper = "A" Then
                                            bySW = 1
                                        ElseIf Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(7, 1).ToUpper = "B" Then
                                            bySW = 1
                                        ElseIf Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(7, 1).ToUpper = "C" Then
                                            bySW = 1
                                        ElseIf Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(7, 1).ToUpper = "D" Then
                                            bySW = 1
                                        End If

                                        If bySW = 0 And bySW1 = 0 Then
                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                                            bySW1 = 1
                                        End If
                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_704()
        Dim inconsistencia As String = "Codificación romana no valida para la escala de 1:25000"
        Dim codigo As String = "704"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:25000" Then
                                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 8 Then
                                        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(0, 3)) = True Then
                                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(4, 2)) = True Then

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                            End If
                                        End If
                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_705()
        Dim inconsistencia As String = "Codificación mayor a la longitud valida para la escala 1:10000"
        Dim codigo As String = "705"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:10000" Then
                                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length > 10 Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_706()
        Dim inconsistencia As String = "Codificación romana no valida para la escala de 1:10000"
        Dim codigo As String = "706"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:10000" Then
                                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 10 Then
                                        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(0, 3)) = True Then
                                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(4, 2)) = True Then

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                            End If
                                        End If
                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_707()
        Dim inconsistencia As String = "Codificación letras mayúsculas no valida para la escala  1:10000"
        Dim codigo As String = "707"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
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


                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                        End If
                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_708()
        Dim inconsistencia As String = "Codificación números arábigos no validos para la escala 1:10000"
        Dim codigo As String = "708"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:10000" Then
                                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 10 Then
                                        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(0, 3)) = False Or _
                                           fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1)) = False Then

                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                        Else
                                            If Not Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1) = "1" Or _
                                                   Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1) = "2" Or _
                                                   Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1) = "3" Or _
                                                   Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1) = "4" Then

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                            End If
                                        End If
                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_709()
        Dim inconsistencia As String = "Codificación mayor a la longitud valida para la escala 1:5000"
        Dim codigo As String = "709"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:5000" Then
                                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length > 12 Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_710()
        Dim inconsistencia As String = "Codificación romana no valida para la escala de 1:5000"
        Dim codigo As String = "710"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:5000" Then
                                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 12 Then
                                        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(0, 3)) = True Then
                                            If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(4, 2)) = True Then

                                                pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                            End If
                                        End If
                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_711()
        Dim inconsistencia As String = "Codificación letras mayúsculas no valida para la escala  1:5000"
        Dim codigo As String = "711"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:5000" Or Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1-5000" Then

                                    Dim stFPCAPLAN As String = Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN"))
                                    Dim bySW As Byte = 0

                                    If stFPCAPLAN.Length = 12 Then

                                        If stFPCAPLAN.Substring(7, 1).ToString = "A" Then
                                            bySW = 1
                                        End If

                                        If stFPCAPLAN.Substring(7, 1).ToString = "B" Then
                                            bySW = 1
                                        End If

                                        If stFPCAPLAN.Substring(7, 1).ToString = "C" Then
                                            bySW = 1
                                        End If

                                        If stFPCAPLAN.Substring(7, 1).ToString = "D" Then
                                            bySW = 1
                                        End If

                                        If bySW = 0 Then
                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                                        End If

                                    End If

                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_712()
        Dim inconsistencia As String = "Codificación números arábigos no validos para la escala 1:5000"
        Dim codigo As String = "712"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:5000" Or Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1-5000" Then
                                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 12 Then
                                        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(0, 3)) = False Or _
                                           fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(9, 1)) = False Then

                                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                        Else
                                            Dim stFPCAPLAN As String = Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN"))
                                            Dim bySW As Byte = 0

                                            If stFPCAPLAN.Length = 12 Then

                                                If stFPCAPLAN.Substring(9, 1).ToString = "1" Then
                                                    bySW = 1
                                                End If

                                                If stFPCAPLAN.Substring(9, 1).ToString = "2" Then
                                                    bySW = 1
                                                End If

                                                If stFPCAPLAN.Substring(9, 1).ToString = "3" Then
                                                    bySW = 1
                                                End If

                                                If stFPCAPLAN.Substring(9, 1).ToString = "4" Then
                                                    bySW = 1
                                                End If

                                                If bySW = 0 Then
                                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                                                End If

                                            End If

                                        End If
                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_713()
        Dim inconsistencia As String = "Codificación letras minúsculas no válida para la escala de 1:5000"
        Dim codigo As String = "713"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then


                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1:5000" Or Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR")) = "1-5000" Then
                                    If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Length = 12 Then
                                        If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN")).Substring(11, 1)) = False Then

                                            Dim stFPCAPLAN As String = Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN"))
                                            Dim bySW As Byte = 0

                                            If stFPCAPLAN.Length = 12 Then

                                                If stFPCAPLAN.Substring(11, 1).ToString = "a" Then
                                                    bySW = 1
                                                End If

                                                If stFPCAPLAN.Substring(11, 1).ToString = "b" Then
                                                    bySW = 1
                                                End If

                                                If stFPCAPLAN.Substring(11, 1).ToString = "c" Then
                                                    bySW = 1
                                                End If

                                                If stFPCAPLAN.Substring(11, 1).ToString = "d" Then
                                                    bySW = 1
                                                End If

                                                If bySW = 0 Then
                                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)
                                                End If

                                            End If

                                        End If
                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_714()
        Dim inconsistencia As String = "Plancha en nulo."
        Dim codigo As String = "714"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then


                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAPLAN").ToString) = "" Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                End If
                            End If
                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_715()
        Dim inconsistencia As String = "Escala grafica en nulo."
        Dim codigo As String = "715"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then


                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAESGR").ToString) = "" Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                End If
                            End If
                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_716()
        Dim inconsistencia As String = "Vigencia grafica en nulo."
        Dim codigo As String = "716"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then


                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAVIGR").ToString) = "" Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                End If
                            End If
                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_717()
        Dim inconsistencia As String = "Numero de vuelo en nulo."
        Dim codigo As String = "717"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then


                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAVUEL").ToString) = "" Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                End If
                            End If
                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_718()
        Dim inconsistencia As String = "Numero de faja en nulo."
        Dim codigo As String = "718"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then


                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAFAJA").ToString) = "" Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                End If
                            End If
                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_719()
        Dim inconsistencia As String = "Numero de foto en nulo."
        Dim codigo As String = "719"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then


                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAFOTO").ToString) = "" Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                End If
                            End If
                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_720()
        Dim inconsistencia As String = "Vigencia foto en nulo."
        Dim codigo As String = "720"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then


                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAVIAE").ToString) = "" Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                End If
                            End If
                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_721()
        Dim inconsistencia As String = "Escala foto en nulo."
        Dim codigo As String = "721"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then


                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAESAE").ToString) = "" Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                End If
                            End If
                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_722()
        Dim inconsistencia As String = "Vigencia grafica invalidad por vigencia de actualización."
        Dim codigo As String = "722"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then

                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If fun_Verificar_Dato_Numerico_Evento_Validated(Trim(dt_FIPRCART.Rows(i).Item("FPCAVIGR").ToString)) = True Then


                                    If CInt(Trim(dt_FIPRCART.Rows(i).Item("FPCAVIGR").ToString)) <> CInt(Trim(dt_FICHPRED.Rows(0).Item("FIPRVIGE").ToString) - 1) Then

                                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                    End If
                                End If
                            End If

                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_723()
        Dim inconsistencia As String = "Vigencia aerofotografica mayor a la vigencia de actualización."
        Dim codigo As String = "723"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCLSE") = 1 Then
                    If dt_FIPRCART.Rows.Count > 0 Then


                        Dim i As Integer

                        For i = 0 To dt_FIPRCART.Rows.Count - 1

                            If Trim(dt_FIPRCART.Rows(i).Item("FPCAESTA")) = "ac" Then
                                If Trim(dt_FIPRCART.Rows(i).Item("FPCAVIAE").ToString) > Trim(dt_FICHPRED.Rows(0).Item("FIPRVIGE").ToString) Then

                                    pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                                End If
                            End If
                        Next

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub


#End Region

#Region "Validar FiprZoec 800"

    Private Sub pro_ValidarFiprZoec()

        Try
            'Inconsistencias zonas economicas
            pro_Inconsistencia_801()
            pro_Inconsistencia_802()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_Inconsistencia_801()
        Dim inconsistencia As String = "Zona económica no suma el 100 %."
        Dim codigo As String = "801"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRZOEC.Rows.Count > 0 Then

                    Dim i As Integer
                    Dim inTOTAL As Integer

                    For i = 0 To dt_FIPRZOEC.Rows.Count - 1

                        If Trim(dt_FIPRZOEC.Rows(i).Item("FPZEESTA")) = "ac" Then

                            inTOTAL += dt_FIPRZOEC.Rows(i).Item("FPZEPORC")

                        End If

                    Next

                    If inTOTAL <> 100 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Total: " & inTOTAL)

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_802()
        Dim inconsistencia As String = "Porcentaje de zona económica en cero ‘0’."
        Dim codigo As String = "802"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRZOEC.Rows.Count - 1

                    If Trim(dt_FIPRZOEC.Rows(i).Item("FPZEESTA")) = "ac" Then
                        If CType(dt_FIPRZOEC.Rows(i).Item("FPZEPORC"), Integer) = "0" Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Zona: " & dt_FIPRZOEC.Rows(i).Item("FPZEZOEC"))

                        End If
                    End If

                Next

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub

#End Region

#Region "Validar FiprZofi 900"

    Private Sub pro_ValidarFiprZofi()

        Try
            'Inconsistencias zonas economicas
            pro_Inconsistencia_901()
            pro_Inconsistencia_902()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_Inconsistencia_901()
        Dim inconsistencia As String = "Zona física no suma el 100 %."
        Dim codigo As String = "901"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FIPRZOFI.Rows.Count > 0 Then

                    Dim i As Integer
                    Dim inTOTAL As Integer

                    For i = 0 To dt_FIPRZOFI.Rows.Count - 1

                        If Trim(dt_FIPRZOFI.Rows(i).Item("FPZFESTA")) = "ac" Then

                            inTOTAL += dt_FIPRZOFI.Rows(i).Item("FPZFPORC")

                        End If

                    Next

                    If inTOTAL <> 100 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Total: " & inTOTAL)

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_902()
        Dim inconsistencia As String = "Porcentaje de zona física en cero ‘0’."
        Dim codigo As String = "902"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                Dim i As Integer

                For i = 0 To dt_FIPRZOFI.Rows.Count - 1

                    If Trim(dt_FIPRZOFI.Rows(i).Item("FPZFESTA")) = "ac" Then
                        If CType(dt_FIPRZOFI.Rows(i).Item("FPZFPORC"), Integer) = "0" Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Zona: " & dt_FIPRZOFI.Rows(i).Item("FPZFZOFI"))

                        End If
                    End If

                Next

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub

#End Region

#Region "Validar FichResu1 1100"

    Private Sub pro_ValidarFichResu1()

        Try
            'Inconsistencias ficha resumen 1
            pro_Inconsistencia_1103()
            pro_Inconsistencia_1108()
            pro_Inconsistencia_1109()
            pro_Inconsistencia_1110()
            pro_Inconsistencia_1111()
            pro_Inconsistencia_1112()
            pro_Inconsistencia_1113()
            pro_Inconsistencia_1114()
            pro_Inconsistencia_1115()
            pro_Inconsistencia_1116()
            pro_Inconsistencia_1117()
            pro_Inconsistencia_1118()
            pro_Inconsistencia_1119()
            pro_Inconsistencia_1120()
            pro_Inconsistencia_1121()
            pro_Inconsistencia_1122()
            pro_Inconsistencia_1123()
            pro_Inconsistencia_1124()
            pro_Inconsistencia_1125()
            pro_Inconsistencia_1126()
            pro_Inconsistencia_1127()
            pro_Inconsistencia_1128()
            pro_Inconsistencia_1129()
            pro_Inconsistencia_1130()
            pro_Inconsistencia_1131()
            pro_Inconsistencia_1132()
            pro_Inconsistencia_1133()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_Inconsistencia_1103()
        Dim inconsistencia As String = "Campo edificio diferente de cero para condominio."
        Dim codigo As String = "1103"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then
                    If Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")) <> "000" Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Edificio: " & dt_FICHPRED.Rows(0).Item("FIPREDIF"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1108()
        Dim inconsistencia As String = "Área común ficha resumen 1 diferente a la sumatoria de las áreas comunes y áreas privadas de las fichas resumen 2."
        Dim codigo As String = "1108"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then

                    Dim stAreaTotalLote As String = 0
                    Dim stAreaComunLote As String = 0
                    Dim stAreaPrivadaLote As String = 0
                    Dim inSumAreaComunLote As Integer = 0
                    Dim inSumAreaPrivadaLote As Integer = 0

                    stAreaTotalLote = dt_FICHPRED.Rows(0).Item("FIPRATLO")
                    stAreaComunLote = dt_FICHPRED.Rows(0).Item("FIPRACLO")
                    stAreaPrivadaLote = dt_FICHPRED.Rows(0).Item("FIPRAPLO")

                    '===========================================================================
                    ' *** CONSULTA LA SUMA DE LA AREAS COMUNES DE LOTE DE LA FICHA RESUMEN 2 ***
                    '===========================================================================

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

                    ' variable de la consulta
                    Dim ParametrosConsulta As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta += "Select "
                    ParametrosConsulta += "Sum(FiprAclo), Count(1) as NroRegistro "
                    ParametrosConsulta += "From FichPred where "
                    ParametrosConsulta += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta += "FiprCapr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCAPR")) & "' and "
                    ParametrosConsulta += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta += "FiprTifi = '" & 2 & "' and "
                    ParametrosConsulta += "FiprEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_1)

                    ' cierra la conexion
                    oConexion.Close()

                    ' verifica la variable
                    If dt_1.Rows(0).Item(1) = 0 Then
                        inSumAreaComunLote = 0
                    Else
                        ' total area comun de lote
                        inSumAreaComunLote = dt_1.Rows(0).Item(0)
                    End If

                    '============================================================================
                    ' *** CONSULTA LA SUMA DE LA AREAS PRIVADAS DE LOTE DE LA FICHA RESUMEN 2 ***
                    '============================================================================

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

                    ' variable de la consulta
                    Dim ParametrosConsulta3 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta3 += "Select "
                    ParametrosConsulta3 += "Sum(FiprAplo), Count(1) as NroRegistro "
                    ParametrosConsulta3 += "From FichPred where "
                    ParametrosConsulta3 += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta3 += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta3 += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta3 += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta3 += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta3 += "FiprCapr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCAPR")) & "' and "
                    ParametrosConsulta3 += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta3 += "FiprTifi = '" & 2 & "' and "
                    ParametrosConsulta3 += "FiprEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta3, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_3)

                    ' cierra la conexion
                    oConexion.Close()

                    ' verifica la variable
                    If dt_3.Rows(0).Item(1) = 0 Then
                        inSumAreaPrivadaLote = 0
                    Else
                        ' total area comun de lote
                        inSumAreaPrivadaLote = dt_3.Rows(0).Item(0)
                    End If

                    If (Val(stAreaComunLote) <> (Val(stAreaTotalLote) - (Val(inSumAreaComunLote) + Val(inSumAreaPrivadaLote)))) Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " ATL: " & stAreaTotalLote & " ACL: " & stAreaComunLote & " APL: " & stAreaPrivadaLote)

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1109()
        Dim inconsistencia As String = "Área privada de lote mayor que el área total de lote."
        Dim codigo As String = "1109"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRAPLO") > dt_FICHPRED.Rows(0).Item("FIPRATLO") Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " ATL: " & dt_FICHPRED.Rows(0).Item("FIPRATLO") & " APL: " & dt_FICHPRED.Rows(0).Item("FIPRAPLO"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1110()
        Dim inconsistencia As String = "No existe ficha resumen 2 para condominio."
        Dim codigo As String = "1110"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then

                    '=====================================================
                    ' *** CONSULTA LA TOTALIDAD DE LAS FICHA RESUMEN 2 ***
                    '=====================================================
                    ' declaro la variable
                    Dim inTotalFichaResumen2 As Integer = 0

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

                    ' variable de la consulta
                    Dim ParametrosConsulta As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta += "Select "
                    ParametrosConsulta += "Count(1) as NroRegistro "
                    ParametrosConsulta += "From FichPred where "
                    ParametrosConsulta += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta += "FiprCapr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCAPR")) & "' and "
                    ParametrosConsulta += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta += "FiprTifi = '" & 2 & "' and "
                    ParametrosConsulta += "FiprEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_1)

                    ' cierra la conexion
                    oConexion.Close()

                    ' verifica la variable
                    inTotalFichaResumen2 = dt_1.Rows(0).Item(0)

                    ' verifica la cantidad
                    If inTotalFichaResumen2 = 0 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1111()
        Dim inconsistencia As String = "Existe menos de dos fichas resumen 2 para condominio."
        Dim codigo As String = "1111"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then

                    '=====================================================
                    ' *** CONSULTA LA TOTALIDAD DE LAS FICHA RESUMEN 2 ***
                    '=====================================================
                    ' declaro la variable
                    Dim inTotalFichaResumen2 As Integer = 0

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

                    ' variable de la consulta
                    Dim ParametrosConsulta As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta += "Select "
                    ParametrosConsulta += "Count(1) as NroRegistro "
                    ParametrosConsulta += "From FichPred where "
                    ParametrosConsulta += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta += "FiprCapr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCAPR")) & "' and "
                    ParametrosConsulta += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta += "FiprTifi = '" & 2 & "' and "
                    ParametrosConsulta += "FiprEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_1)

                    ' cierra la conexion
                    oConexion.Close()

                    ' verifica la variable
                    inTotalFichaResumen2 = dt_1.Rows(0).Item(0)

                    ' verifica la cantidad
                    If inTotalFichaResumen2 < 2 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1112()
        Dim inconsistencia As String = "Sector invalido para ficha resumen 1."
        Dim codigo As String = "1112"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCLSE") <> 1 And dt_FICHPRED.Rows(0).Item("FIPRCLSE") <> 2 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Sector: " & dt_FICHPRED.Rows(0).Item("FIPRCLSE"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1113()
        Dim inconsistencia As String = "Características del predio diferente a condominio."
        Dim codigo As String = "1113"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") <> 4 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Caracteristica: " & dt_FICHPRED.Rows(0).Item("FIPRCAPR"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1114()
        Dim inconsistencia As String = "Total de edificio debe ser mayor a cero."
        Dim codigo As String = "1114"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRTOED") = 0 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Edificio: " & dt_FICHPRED.Rows(0).Item("FIPRTOED"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1115()
        Dim inconsistencia As String = "Área total lote mayor a 5 hectáreas para condominio ."
        Dim codigo As String = "1115"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRATLO") > 50000 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Area total lote: " & dt_FICHPRED.Rows(0).Item("FIPRATLO"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1116()
        Dim inconsistencia As String = "No existe ficha predial para ficha resumen 1."
        Dim codigo As String = "1116"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then

                    '=====================================================
                    ' *** CONSULTA LA TOTALIDAD DE LAS FICHA PREDIALES ***
                    '=====================================================
                    ' declaro la variable
                    Dim inTotalFichaPredial As Integer = 0

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

                    ' variable de la consulta
                    Dim ParametrosConsulta As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta += "Select "
                    ParametrosConsulta += "Count(1) as NroRegistro "
                    ParametrosConsulta += "From FichPred where "
                    ParametrosConsulta += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta += "FiprCapr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCAPR")) & "' and "
                    ParametrosConsulta += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta += "FiprTifi = '" & 0 & "' and "
                    ParametrosConsulta += "FiprEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_1)

                    ' cierra la conexion
                    oConexion.Close()

                    ' verifica la variable
                    inTotalFichaPredial = dt_1.Rows(0).Item(0)

                    ' verifica la cantidad
                    If inTotalFichaPredial = 0 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1117()
        Dim inconsistencia As String = "Total apartamentos o casas en condominio incorrecto."
        Dim codigo As String = "1117"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then

                    ' declaro la variable
                    Dim inTotalApartamentosCasas As Integer = 0

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

                    ' variable de la consulta
                    Dim ParametrosConsulta2 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta2 += "Select "
                    ParametrosConsulta2 += "Sum(FiprApca), Count(1) as NroRegistros "
                    ParametrosConsulta2 += "From FichPred where "
                    ParametrosConsulta2 += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta2 += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta2 += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta2 += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta2 += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta2 += "FiprCapr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCAPR")) & "' and "
                    ParametrosConsulta2 += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta2 += "FiprTifi = '" & 2 & "' and "
                    ParametrosConsulta2 += "FiprEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_2)

                    ' cierra la conexion
                    oConexion.Close()

                    ' verifica la variable
                    If dt_2.Rows(0).Item(1) = 0 Then
                        inTotalApartamentosCasas = 0
                    Else
                        ' total area comun de lote
                        inTotalApartamentosCasas = dt_2.Rows(0).Item(0)
                    End If

                    ' compara la variable
                    If dt_FICHPRED.Rows(0).Item("FIPRAPCA") <> inTotalApartamentosCasas Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Nro. apartamentos o casas correcta: " & inTotalApartamentosCasas)

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1118()
        Dim inconsistencia As String = "Campo total edificio menor a dos."
        Dim codigo As String = "1118"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRTOED") < 2 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Edificio: " & dt_FICHPRED.Rows(0).Item("FIPRTOED"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1119()
        Dim inconsistencia As String = "Campo unidades en condominio en cero."
        Dim codigo As String = "1119"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRUNCO") = 0 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidades en condominio: " & dt_FICHPRED.Rows(0).Item("FIPRUNCO"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1120()
        Dim inconsistencia As String = "Campo total de pisos diferente de cero."
        Dim codigo As String = "1120"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRPISO") <> 0 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Piso: " & dt_FICHPRED.Rows(0).Item("FIPRPISO"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1121()
        Dim inconsistencia As String = "Total unidades en condominio incorrecta."
        Dim codigo As String = "1121"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then


                    '===========================================================================================
                    ' *** CONSULTA LA SUMA DE LAS UNIDADES EN RPH PARA DETERMINAR LAS UNIDADES EN CONDOMINIO ***
                    '===========================================================================================
                    ' declaro la variable
                    Dim inTotalUnidadesRPH As Integer = 0

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

                    ' variable de la consulta
                    Dim ParametrosConsulta2 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta2 += "Select "
                    ParametrosConsulta2 += "Sum(FiprUrph), Count(1) as NroRegistros "
                    ParametrosConsulta2 += "From FichPred where "
                    ParametrosConsulta2 += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta2 += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta2 += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta2 += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta2 += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta2 += "FiprCapr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCAPR")) & "' and "
                    ParametrosConsulta2 += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta2 += "FiprTifi = '" & 2 & "' and "
                    ParametrosConsulta2 += "FiprEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_2)

                    ' cierra la conexion
                    oConexion.Close()

                    ' verifica la variable
                    If dt_2.Rows(0).Item(1) = 0 Then
                        inTotalUnidadesRPH = 0
                    Else
                        ' total area comun de lote
                        inTotalUnidadesRPH = dt_2.Rows(0).Item(0)
                    End If

                    ' compara la variable
                    If dt_FICHPRED.Rows(0).Item("FIPRUNCO") <> inTotalUnidadesRPH Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Nro. de unidades en condominio correcta: " & inTotalUnidadesRPH)

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1122()
        Dim inconsistencia As String = "Área común de lote mayor que el área total de lote."
        Dim codigo As String = "1122"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRACLO") > dt_FICHPRED.Rows(0).Item("FIPRATLO") Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " ATL: " & dt_FICHPRED.Rows(0).Item("FIPRATLO") & " ACL: " & dt_FICHPRED.Rows(0).Item("FIPRACLO"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1123()
        Dim inconsistencia As String = "Área privada de lote diferente de cero."
        Dim codigo As String = "1123"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRAPLO") <> 0 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " APL: " & dt_FICHPRED.Rows(0).Item("FIPRAPLO"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1124()
        Dim inconsistencia As String = "Campo unidades en RPH diferente de cero."
        Dim codigo As String = "1124"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRURPH") <> 0 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidades RPH: " & dt_FICHPRED.Rows(0).Item("FIPRURPH"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1125()
        Dim inconsistencia As String = "Total locales en condominio incorrecto."
        Dim codigo As String = "1125"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then


                    ' declaro la variable
                    Dim inTotalLocales As Integer = 0

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

                    ' variable de la consulta
                    Dim ParametrosConsulta2 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta2 += "Select "
                    ParametrosConsulta2 += "Sum(FiprLoca), Count(1) as NroRegistros "
                    ParametrosConsulta2 += "From FichPred where "
                    ParametrosConsulta2 += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta2 += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta2 += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta2 += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta2 += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta2 += "FiprCapr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCAPR")) & "' and "
                    ParametrosConsulta2 += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta2 += "FiprTifi = '" & 2 & "' and "
                    ParametrosConsulta2 += "FiprEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_2)

                    ' cierra la conexion
                    oConexion.Close()

                    ' verifica la variable
                    If dt_2.Rows(0).Item(1) = 0 Then
                        inTotalLocales = 0
                    Else
                        ' total area comun de lote
                        inTotalLocales = dt_2.Rows(0).Item(0)
                    End If

                    ' compara la variable
                    If dt_FICHPRED.Rows(0).Item("FIPRLOCA") <> inTotalLocales Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Nro. locales: " & inTotalLocales)

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1126()
        Dim inconsistencia As String = "Total cuartos útiles en condominio incorrecto."
        Dim codigo As String = "1126"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then

                    ' declaro la variable
                    Dim inTotalCuartosUtiles As Integer = 0

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

                    ' variable de la consulta
                    Dim ParametrosConsulta2 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta2 += "Select "
                    ParametrosConsulta2 += "Sum(FiprCuut), Count(1) as NroRegistros "
                    ParametrosConsulta2 += "From FichPred where "
                    ParametrosConsulta2 += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta2 += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta2 += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta2 += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta2 += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta2 += "FiprCapr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCAPR")) & "' and "
                    ParametrosConsulta2 += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta2 += "FiprTifi = '" & 2 & "' and "
                    ParametrosConsulta2 += "FiprEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_2)

                    ' cierra la conexion
                    oConexion.Close()

                    ' verifica la variable
                    If dt_2.Rows(0).Item(1) = 0 Then
                        inTotalCuartosUtiles = 0
                    Else
                        ' total area comun de lote
                        inTotalCuartosUtiles = dt_2.Rows(0).Item(0)
                    End If

                    ' compara la variable
                    If dt_FICHPRED.Rows(0).Item("FIPRCUUT") <> inTotalCuartosUtiles Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Nro. cuartos utiles: " & inTotalCuartosUtiles)

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1127()
        Dim inconsistencia As String = "Total garajes cubiertos en condominio incorrecto."
        Dim codigo As String = "1127"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then

                    ' declaro la variable
                    Dim inTotalGarajesCubiertos As Integer = 0

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

                    ' variable de la consulta
                    Dim ParametrosConsulta2 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta2 += "Select "
                    ParametrosConsulta2 += "Sum(FiprGacu), Count(1) as NroRegistros "
                    ParametrosConsulta2 += "From FichPred where "
                    ParametrosConsulta2 += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta2 += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta2 += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta2 += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta2 += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta2 += "FiprCapr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCAPR")) & "' and "
                    ParametrosConsulta2 += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta2 += "FiprTifi = '" & 2 & "' and "
                    ParametrosConsulta2 += "FiprEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_2)

                    ' cierra la conexion
                    oConexion.Close()

                    ' verifica la variable
                    If dt_2.Rows(0).Item(1) = 0 Then
                        inTotalGarajesCubiertos = 0
                    Else
                        ' total area comun de lote
                        inTotalGarajesCubiertos = dt_2.Rows(0).Item(0)
                    End If

                    ' compara la variable
                    If dt_FICHPRED.Rows(0).Item("FIPRGACU") <> inTotalGarajesCubiertos Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Nro. garajes cubiertos: " & inTotalGarajesCubiertos)

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1128()
        Dim inconsistencia As String = "Total garajes descubiertos en condominio incorrecto."
        Dim codigo As String = "1128"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then

                    ' declaro la variable
                    Dim inTotalGarajesDescubiertos As Integer = 0

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

                    ' variable de la consulta
                    Dim ParametrosConsulta2 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta2 += "Select "
                    ParametrosConsulta2 += "Sum(FiprGade), Count(1) as NroRegistros "
                    ParametrosConsulta2 += "From FichPred where "
                    ParametrosConsulta2 += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta2 += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta2 += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta2 += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta2 += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta2 += "FiprCapr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCAPR")) & "' and "
                    ParametrosConsulta2 += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta2 += "FiprTifi = '" & 2 & "' and "
                    ParametrosConsulta2 += "FiprEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_2)

                    ' cierra la conexion
                    oConexion.Close()

                    ' verifica la variable
                    If dt_2.Rows(0).Item(1) = 0 Then
                        inTotalGarajesDescubiertos = 0
                    Else
                        ' total area comun de lote
                        inTotalGarajesDescubiertos = dt_2.Rows(0).Item(0)
                    End If

                    ' compara la variable
                    If dt_FICHPRED.Rows(0).Item("FIPRGADE") <> inTotalGarajesDescubiertos Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Nro. garajes descubiertos: " & inTotalGarajesDescubiertos)

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1129()
        Dim inconsistencia As String = "Total edificios en condominio incorrecto."
        Dim codigo As String = "1129"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then

                    ' declaro la variable
                    Dim inTotalTotalEdificio As Integer = 0

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

                    ' variable de la consulta
                    Dim ParametrosConsulta2 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta2 += "Select "
                    ParametrosConsulta2 += "Sum(FiprToed), Count(1) as NroRegistros "
                    ParametrosConsulta2 += "From FichPred where "
                    ParametrosConsulta2 += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta2 += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta2 += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta2 += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta2 += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta2 += "FiprCapr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCAPR")) & "' and "
                    ParametrosConsulta2 += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta2 += "FiprTifi = '" & 2 & "' and "
                    ParametrosConsulta2 += "FiprEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_2)

                    ' cierra la conexion
                    oConexion.Close()

                    ' verifica la variable
                    If dt_2.Rows(0).Item(1) = 0 Then
                        inTotalTotalEdificio = 0
                    Else
                        ' total area comun de lote
                        inTotalTotalEdificio = dt_2.Rows(0).Item(0)
                    End If

                    ' compara la variable
                    If dt_FICHPRED.Rows(0).Item("FIPRTOED") <> inTotalTotalEdificio Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Nro. total edificio: " & inTotalTotalEdificio)

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1130()
        Dim inconsistencia As String = "Área total lote ó Área común de lote ficha resumen 1 requiere verificación en la sumatoria de áreas."
        Dim codigo As String = "1130"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then

                    Dim stAreaTotalLote As String = 0
                    Dim stAreaComunLote As String = 0
                    Dim stAreaPrivadaLote As String = 0
                    Dim inSumAreaComunLote As Integer = 0
                    Dim inSumAreaPrivadaLote As Integer = 0

                    stAreaTotalLote = dt_FICHPRED.Rows(0).Item("FIPRATLO")
                    stAreaComunLote = dt_FICHPRED.Rows(0).Item("FIPRACLO")
                    stAreaPrivadaLote = dt_FICHPRED.Rows(0).Item("FIPRAPLO")

                    '===========================================================================
                    ' *** CONSULTA LA SUMA DE LA AREAS COMUNES DE LOTE DE LA FICHA RESUMEN 2 ***
                    '===========================================================================

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

                    ' variable de la consulta
                    Dim ParametrosConsulta As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta += "Select "
                    ParametrosConsulta += "Sum(FiprAclo), Count(1) as NroRegistro "
                    ParametrosConsulta += "From FichPred where "
                    ParametrosConsulta += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta += "FiprCapr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCAPR")) & "' and "
                    ParametrosConsulta += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta += "FiprTifi = '" & 2 & "' and "
                    ParametrosConsulta += "FiprEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_1)

                    ' cierra la conexion
                    oConexion.Close()

                    ' verifica la variable
                    If dt_1.Rows(0).Item(1) = 0 Then
                        inSumAreaComunLote = 0
                    Else
                        ' total area comun de lote
                        inSumAreaComunLote = dt_1.Rows(0).Item(0)
                    End If

                    '============================================================================
                    ' *** CONSULTA LA SUMA DE LA AREAS PRIVADAS DE LOTE DE LA FICHA RESUMEN 2 ***
                    '============================================================================

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

                    ' variable de la consulta
                    Dim ParametrosConsulta3 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta3 += "Select "
                    ParametrosConsulta3 += "Sum(FiprAplo), Count(1) as NroRegistro "
                    ParametrosConsulta3 += "From FichPred where "
                    ParametrosConsulta3 += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta3 += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta3 += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta3 += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta3 += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta3 += "FiprCapr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCAPR")) & "' and "
                    ParametrosConsulta3 += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta3 += "FiprTifi = '" & 2 & "' and "
                    ParametrosConsulta3 += "FiprEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta3, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_3)

                    ' cierra la conexion
                    oConexion.Close()

                    ' verifica la variable
                    If dt_3.Rows(0).Item(1) = 0 Then
                        inSumAreaPrivadaLote = 0
                    Else
                        ' total area comun de lote
                        inSumAreaPrivadaLote = dt_3.Rows(0).Item(0)
                    End If

                    If (Val(stAreaComunLote) <> (Val(stAreaTotalLote) - (Val(inSumAreaComunLote) + Val(inSumAreaPrivadaLote)))) Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " ATL: " & stAreaTotalLote & " ACL: " & stAreaComunLote & " APL: " & stAreaPrivadaLote)

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1131()
        Dim inconsistencia As String = "Ficha con área común de lote sin zona física comun."
        Dim codigo As String = "1131"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then

                    ' declaro la variable
                    Dim inTotalTotalEdificio As Integer = 0

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

                    ' variable de la consulta
                    Dim ParametrosConsulta2 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta2 += "Select "
                    ParametrosConsulta2 += "ZofiCodi "
                    ParametrosConsulta2 += "From mant_ZonaFisi where "
                    ParametrosConsulta2 += "ZofiDepa = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA")) & "' and "
                    ParametrosConsulta2 += "ZofiMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta2 += "ZofiClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta2 += "ZofiZoco = '" & 1 & "' and "
                    ParametrosConsulta2 += "ZofiEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_2)

                    ' cierra la conexion
                    oConexion.Close()

                    ' declara la variable encontro
                    Dim byExiste As Byte = 0
                    Dim byRegistroActivo As Byte = 0

                    ' verifica la tabla
                    If dt_2.Rows.Count > 0 And dt_FICHPRED.Rows(0).Item("FIPRACLO") > 0 Then

                        ' declara la variable de mantenimiento
                        Dim i As Integer = 0

                        For i = 0 To dt_2.Rows.Count - 1

                            ' declaro la variable de zona ficha
                            Dim k As Integer = 0

                            For k = 0 To dt_FIPRZOFI.Rows.Count - 1

                                If Trim(dt_FIPRZOFI.Rows(k).Item("FPZFESTA")) = "ac" Then
                                    byRegistroActivo = 1

                                    If dt_2.Rows(i).Item("ZOFICODI") = dt_FIPRZOFI.Rows(k).Item("FPZFZOFI") Then

                                        If byExiste = 0 Then
                                            byExiste = 1
                                        End If

                                    End If
                                End If

                            Next

                        Next

                        ' compara la variable
                        If byExiste = 0 And byRegistroActivo = 1 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                        End If

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1132()
        Dim inconsistencia As String = "Ficha con área común de lote sin zona económica comun."
        Dim codigo As String = "1132"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then

                    ' declaro la variable
                    Dim inTotalTotalEdificio As Integer = 0

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

                    ' variable de la consulta
                    Dim ParametrosConsulta2 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta2 += "Select "
                    ParametrosConsulta2 += "ZoecCodi "
                    ParametrosConsulta2 += "From mant_ZonaEcon where "
                    ParametrosConsulta2 += "ZoecDepa = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA")) & "' and "
                    ParametrosConsulta2 += "ZoecMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta2 += "ZoecClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta2 += "ZoecZoco = '" & 1 & "' and "
                    ParametrosConsulta2 += "ZoecEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_2)

                    ' cierra la conexion
                    oConexion.Close()

                    ' declara la variable encontro
                    Dim byExiste As Byte = 0
                    Dim byRegistroActivo As Byte = 0

                    ' verifica la tabla
                    If dt_2.Rows.Count > 0 And dt_FICHPRED.Rows(0).Item("FIPRACLO") > 0 Then

                        ' declara la variable de mantenimiento
                        Dim i As Integer = 0

                        For i = 0 To dt_2.Rows.Count - 1

                            ' declaro la variable de zona ficha
                            Dim k As Integer = 0

                            For k = 0 To dt_FIPRZOEC.Rows.Count - 1

                                If Trim(dt_FIPRZOEC.Rows(k).Item("FPZEESTA")) = "ac" Then
                                    byRegistroActivo = 1

                                    If dt_2.Rows(i).Item("ZOECCODI") = dt_FIPRZOEC.Rows(k).Item("FPZEZOEC") Then

                                        If byExiste = 0 Then
                                            byExiste = 1
                                        End If

                                    End If
                                End If

                            Next

                        Next

                        ' compara la variable
                        If byExiste = 0 And byRegistroActivo = 1 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                        End If

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1133()
        Dim inconsistencia As String = "Ficha con área común de lote menor a cero."
        Dim codigo As String = "1133"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 1 Then

                    If dt_FICHPRED.Rows(0).Item("FIPRACLO") < 0 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Área comun: " & dt_FICHPRED.Rows(0).Item("FIPRACLO"))

                    End If

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub

#End Region

#Region "Validar FichResu2 1200"

    Private Sub pro_ValidarFichResu2()

        Try
            'Inconsistencias ficha resumen 2
            pro_Inconsistencia_1203()
            pro_Inconsistencia_1208()
            pro_Inconsistencia_1209()
            pro_Inconsistencia_1210()
            pro_Inconsistencia_1211()
            pro_Inconsistencia_1212()
            pro_Inconsistencia_1213()
            pro_Inconsistencia_1214()
            pro_Inconsistencia_1215()
            pro_Inconsistencia_1216()
            pro_Inconsistencia_1217()
            pro_Inconsistencia_1218()
            pro_Inconsistencia_1219()
            pro_Inconsistencia_1220()
            pro_Inconsistencia_1221()
            pro_Inconsistencia_1222()
            pro_Inconsistencia_1223()
            pro_Inconsistencia_1224()
            pro_Inconsistencia_1225()
            pro_Inconsistencia_1226()
            pro_Inconsistencia_1227()
            pro_Inconsistencia_1228()
            pro_Inconsistencia_1229()
            pro_Inconsistencia_1230()
            pro_Inconsistencia_1231()

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    Private Sub pro_Inconsistencia_1203()
        Dim inconsistencia As String = "Área privada de lote mayor que el área total lote."
        Dim codigo As String = "1203"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRAPLO") > dt_FICHPRED.Rows(0).Item("FIPRATLO") Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " ATL: " & dt_FICHPRED.Rows(0).Item("FIPRATLO") & " APL: " & dt_FICHPRED.Rows(0).Item("FIPRAPLO"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1208()
        Dim inconsistencia As String = "Área común lote mayor que el área total lote."
        Dim codigo As String = "1208"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRACLO") > dt_FICHPRED.Rows(0).Item("FIPRATLO") Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " ATL: " & dt_FICHPRED.Rows(0).Item("FIPRATLO") & " ACL: " & dt_FICHPRED.Rows(0).Item("FIPRACLO"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1209()
        Dim inconsistencia As String = "Sector invalido para ficha resumen 2."
        Dim codigo As String = "1209"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCLSE") <> 1 And dt_FICHPRED.Rows(0).Item("FIPRCLSE") <> 2 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Sector: " & dt_FICHPRED.Rows(0).Item("FIPRCLSE"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1210()
        Dim inconsistencia As String = "Total unidades en RPH incorrecto."
        Dim codigo As String = "1210"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then

                    ' declaro la variable
                    Dim inTotalUnidadesRPH As Integer = 0

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

                    ' variable de la consulta
                    Dim ParametrosConsulta2 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta2 += "Select "
                    ParametrosConsulta2 += "Count(1) as NroRegistros "
                    ParametrosConsulta2 += "From FichPred where "
                    ParametrosConsulta2 += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta2 += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta2 += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta2 += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta2 += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta2 += "FiprEdif = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")) & "' and "
                    ParametrosConsulta2 += "FiprCapr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCAPR")) & "' and "
                    ParametrosConsulta2 += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta2 += "FiprTifi = '" & 0 & "' and "
                    ParametrosConsulta2 += "FiprEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_2)

                    ' cierra la conexion
                    oConexion.Close()

                    ' verifica la variable
                    If dt_2.Rows(0).Item(0) = 0 Then
                        inTotalUnidadesRPH = 0
                    Else
                        ' total area comun de lote
                        inTotalUnidadesRPH = dt_2.Rows(0).Item(0)
                    End If

                    ' compara la variable
                    If dt_FICHPRED.Rows(0).Item("FIPRURPH") <> inTotalUnidadesRPH Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Nro. unidades RPH: " & inTotalUnidadesRPH)

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1211()
        Dim inconsistencia As String = "No existe ficha resumen 1 para condominio."
        Dim codigo As String = "1211"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then


                        ' declaro la variable
                        Dim inTotalFichaResumen1 As Integer = 0

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

                        ' variable de la consulta
                        Dim ParametrosConsulta2 As String = ""

                        ' Concatena la condicion de la consulta
                        ParametrosConsulta2 += "Select "
                        ParametrosConsulta2 += "Count(1) as NroRegistros "
                        ParametrosConsulta2 += "From FichPred where "
                        ParametrosConsulta2 += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                        ParametrosConsulta2 += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                        ParametrosConsulta2 += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                        ParametrosConsulta2 += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                        ParametrosConsulta2 += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                        ParametrosConsulta2 += "FiprCapr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCAPR")) & "' and "
                        ParametrosConsulta2 += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                        ParametrosConsulta2 += "FiprTifi = '" & 1 & "' and "
                        ParametrosConsulta2 += "FiprEsta = 'ac' "

                        ' ejecuta la consulta
                        oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                        ' procesa la consulta 
                        oEjecutar.CommandTimeout = 360
                        oEjecutar.CommandType = CommandType.Text
                        oAdapter.SelectCommand = oEjecutar

                        ' llena el datatable 
                        oAdapter.Fill(dt_2)

                        ' cierra la conexion
                        oConexion.Close()

                        ' verifica la variable
                        If dt_2.Rows(0).Item(0) = 0 Then
                            inTotalFichaResumen1 = 0
                        Else
                            ' total area comun de lote
                            inTotalFichaResumen1 = dt_2.Rows(0).Item(0)
                        End If

                        ' compara la variable
                        If inTotalFichaResumen1 = 0 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                        End If

                        ' compara la variable
                        If inTotalFichaResumen1 > 1 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Existe mas de una ficha resumen 1 para un mismo código catastral")

                        End If

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try


    End Sub
    Private Sub pro_Inconsistencia_1212()
        Dim inconsistencia As String = "Característica del predio invalido."
        Dim codigo As String = "1212"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 1 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 6 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 7 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Caracteristica de predio: " & dt_FICHPRED.Rows(0).Item("FIPRCAPR"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1213()
        Dim inconsistencia As String = "Total pisos debe ser mayor a cero."
        Dim codigo As String = "1213"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRPISO") = 0 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Total de pisos: " & dt_FICHPRED.Rows(0).Item("FIPRPISO"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1214()
        Dim inconsistencia As String = "Área total lote mayor a 5 hectáreas para condominio."
        Dim codigo As String = "1214"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 4 Then
                        If dt_FICHPRED.Rows(0).Item("FIPRATLO") > 50000 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Área total lote: " & dt_FICHPRED.Rows(0).Item("FIPRATLO"))

                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1215()
        Dim inconsistencia As String = "Total de apartamentos o casas igual a cero para rph."
        Dim codigo As String = "1215"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRAPCA") = 0 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Total apartamentos o casas: " & dt_FICHPRED.Rows(0).Item("FIPRAPCA"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1216()
        Dim inconsistencia As String = "Total locales mayor a cero para parcelación rural."
        Dim codigo As String = "1216"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then
                        If dt_FICHPRED.Rows(0).Item("FIPRLOCA") > 0 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Total locales: " & dt_FICHPRED.Rows(0).Item("FIPRLOCA"))

                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1217()
        Dim inconsistencia As String = "Total cuartos útiles mayor a cero para parcelación."
        Dim codigo As String = "1217"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then
                        If dt_FICHPRED.Rows(0).Item("FIPRCUUT") > 0 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Total cuartos utiles: " & dt_FICHPRED.Rows(0).Item("FIPRCUUT"))

                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1218()
        Dim inconsistencia As String = "Total garajes cubiertos mayor a cero para parcelación."
        Dim codigo As String = "1218"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then
                        If dt_FICHPRED.Rows(0).Item("FIPRGACU") > 0 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Total garajes cubiertos: " & dt_FICHPRED.Rows(0).Item("FIPRGACU"))

                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1219()
        Dim inconsistencia As String = "Total garajes descubiertos mayor a cero para parcelación."
        Dim codigo As String = "1219"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then
                        If dt_FICHPRED.Rows(0).Item("FIPRGADE") > 0 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Total garajes descubiertos: " & dt_FICHPRED.Rows(0).Item("FIPRGADE"))

                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1220()
        Dim inconsistencia As String = "No existe ficha predial para ficha resumen 2."
        Dim codigo As String = "1220"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then

                    '=====================================================
                    ' *** CONSULTA LA TOTALIDAD DE LAS FICHA PREDIALES ***
                    '=====================================================
                    ' declaro la variable
                    Dim inTotalFichaPredial As Integer = 0

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

                    ' variable de la consulta
                    Dim ParametrosConsulta As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta += "Select "
                    ParametrosConsulta += "Count(1) as NroRegistro "
                    ParametrosConsulta += "From FichPred where "
                    ParametrosConsulta += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta += "FiprEdif = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")) & "' and "
                    ParametrosConsulta += "FiprCapr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCAPR")) & "' and "
                    ParametrosConsulta += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta += "FiprTifi = '" & 0 & "' and "
                    ParametrosConsulta += "FiprEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_1)

                    ' cierra la conexion
                    oConexion.Close()

                    ' verifica la variable
                    inTotalFichaPredial = dt_1.Rows(0).Item(0)

                    ' verifica la cantidad
                    If inTotalFichaPredial = 0 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1221()
        Dim inconsistencia As String = "Campo total edificio diferente de uno."
        Dim codigo As String = "1221"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRTOED") <> 1 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Total edificio: " & dt_FICHPRED.Rows(0).Item("FIPRTOED"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1222()
        Dim inconsistencia As String = "Campo unidades en rph en cero."
        Dim codigo As String = "1222"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRURPH") = 0 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Total unidades en RPH: " & dt_FICHPRED.Rows(0).Item("FIPRURPH"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1223()
        Dim inconsistencia As String = "Campo total de pisos en cero."
        Dim codigo As String = "1223"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRPISO") = 0 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Total pisos: " & dt_FICHPRED.Rows(0).Item("FIPRPISO"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1224()
        Dim inconsistencia As String = "Área privada de lote diferente a la sumaria de las áreas de terreno de las fichas prediales."
        Dim codigo As String = "1224"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then

                    Dim stAreaPrivadaLote As String = 0
                    Dim inSumAreaPrivadaLote As Integer = 0

                    stAreaPrivadaLote = dt_FICHPRED.Rows(0).Item("FIPRAPLO")



                    '=================================================================
                    ' *** CONSULTA LA SUMA DE LA AREAS DE LOTE DE LA FICHA PREDIAL ***
                    '=================================================================

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

                    ' variable de la consulta
                    Dim ParametrosConsulta3 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta3 += "Select "
                    ParametrosConsulta3 += "Sum(FiprArte), Count(1) as NroRegistro "
                    ParametrosConsulta3 += "From FichPred where "
                    ParametrosConsulta3 += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta3 += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta3 += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta3 += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta3 += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta3 += "FiprEdif = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")) & "' and "
                    ParametrosConsulta3 += "FiprCapr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCAPR")) & "' and "
                    ParametrosConsulta3 += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta3 += "FiprTifi = '" & 0 & "' and "
                    ParametrosConsulta3 += "FiprEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta3, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_3)

                    ' cierra la conexion
                    oConexion.Close()

                    ' verifica la variable
                    If dt_3.Rows(0).Item(1) = 0 Then
                        inSumAreaPrivadaLote = 0
                    Else
                        ' total area comun de lote
                        inSumAreaPrivadaLote = dt_3.Rows(0).Item(0)
                    End If

                    If Val(stAreaPrivadaLote) <> Val(inSumAreaPrivadaLote) Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " APL: " & inSumAreaPrivadaLote)

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1225()
        Dim inconsistencia As String = "Campo edificio diferente de uno para característica 2 o 3."
        Dim codigo As String = "1225"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then
                        If Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")) <> "001" Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Edificio: " & dt_FICHPRED.Rows(0).Item("FIPREDIF"))

                        End If
                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1226()
        Dim inconsistencia As String = "Área total lote de ficha resumen 2 diferente a la suma del área común de lote más las áreas de terreno de las unidades prediales."
        Dim codigo As String = "1226"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then

                    Dim stAreaTotalLote As String = 0
                    Dim stAreaComunLote As String = 0
                    Dim stAreaPrivadaLote As String = 0
                    Dim inSumAreaPrivadaLote As Integer = 0

                    stAreaTotalLote = dt_FICHPRED.Rows(0).Item("FIPRATLO")
                    stAreaComunLote = dt_FICHPRED.Rows(0).Item("FIPRACLO")

                    '=================================================================
                    ' *** CONSULTA LA SUMA DE LA AREAS DE LOTE DE LA FICHA PREDIAL ***
                    '=================================================================

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

                    ' variable de la consulta
                    Dim ParametrosConsulta3 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta3 += "Select "
                    ParametrosConsulta3 += "Sum(FiprArte), Count(1) as NroRegistro "
                    ParametrosConsulta3 += "From FichPred where "
                    ParametrosConsulta3 += "FiprMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta3 += "FiprCorr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCORR")) & "' and "
                    ParametrosConsulta3 += "FiprBarr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRBARR")) & "' and "
                    ParametrosConsulta3 += "FiprManz = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMANZ")) & "' and "
                    ParametrosConsulta3 += "FiprPred = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRPRED")) & "' and "
                    ParametrosConsulta3 += "FiprEdif = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPREDIF")) & "' and "
                    ParametrosConsulta3 += "FiprCapr = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCAPR")) & "' and "
                    ParametrosConsulta3 += "FiprClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta3 += "FiprTifi = '" & 0 & "' and "
                    ParametrosConsulta3 += "FiprEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta3, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_3)

                    ' cierra la conexion
                    oConexion.Close()

                    ' verifica la variable
                    If dt_3.Rows(0).Item(1) = 0 Then
                        inSumAreaPrivadaLote = 0
                    Else
                        ' total area comun de lote
                        inSumAreaPrivadaLote = dt_3.Rows(0).Item(0)
                    End If

                    If (Val(stAreaTotalLote) <> (Val(stAreaComunLote) + (Val(inSumAreaPrivadaLote)))) Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " ATL: " & stAreaTotalLote & " ACL: " & stAreaComunLote & " APL: " & inSumAreaPrivadaLote)

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1227()
        Dim inconsistencia As String = "Sumatoria de apartamentos, locales, cuartos útiles, garajes cubiertos y descubiertos diferente al total de unidades en RPH."
        Dim codigo As String = "1223"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then

                    Dim inTotalGenerales As Integer = Val(dt_FICHPRED.Rows(0).Item("FIPRAPCA")) + Val(dt_FICHPRED.Rows(0).Item("FIPRLOCA")) + Val(dt_FICHPRED.Rows(0).Item("FIPRCUUT")) + Val(dt_FICHPRED.Rows(0).Item("FIPRGACU")) + Val(dt_FICHPRED.Rows(0).Item("FIPRGADE"))

                    If Val(dt_FICHPRED.Rows(0).Item("FIPRURPH")) <> inTotalGenerales Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Total generales: " & inTotalGenerales)

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1228()
        Dim inconsistencia As String = "Campo unidades en condominio diferente de cero."
        Dim codigo As String = "1228"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRUNCO") <> 0 Then

                        pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Unidades en condominio: " & dt_FICHPRED.Rows(0).Item("FIPRUNCO"))

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1229()
        Dim inconsistencia As String = "Ficha con área común y característica de predio 3 sin zona física común."
        Dim codigo As String = "1229"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 And dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then

                    ' declaro la variable
                    Dim inTotalTotalEdificio As Integer = 0

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

                    ' variable de la consulta
                    Dim ParametrosConsulta2 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta2 += "Select "
                    ParametrosConsulta2 += "ZofiCodi "
                    ParametrosConsulta2 += "From mant_ZonaFisi where "
                    ParametrosConsulta2 += "ZofiDepa = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA")) & "' and "
                    ParametrosConsulta2 += "ZofiMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta2 += "ZofiClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta2 += "ZofiZoco = '" & 1 & "' and "
                    ParametrosConsulta2 += "ZofiEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_2)

                    ' cierra la conexion
                    oConexion.Close()

                    ' declara la variable encontro
                    Dim byExiste As Byte = 0
                    Dim byRegistroActivo As Byte = 0

                    ' verifica la tabla
                    If dt_2.Rows.Count > 0 And dt_FICHPRED.Rows(0).Item("FIPRACLO") > 0 Then

                        ' declara la variable de mantenimiento
                        Dim i As Integer = 0

                        For i = 0 To dt_2.Rows.Count - 1

                            ' declaro la variable de zona ficha
                            Dim k As Integer = 0

                            For k = 0 To dt_FIPRZOFI.Rows.Count - 1

                                If Trim(dt_FIPRZOFI.Rows(k).Item("FPZFESTA")) = "ac" Then
                                    byRegistroActivo = 1

                                    If dt_2.Rows(i).Item("ZOFICODI") = dt_FIPRZOFI.Rows(k).Item("FPZFZOFI") Then

                                        If byExiste = 0 Then
                                            byExiste = 1
                                        End If

                                    End If
                                End If

                            Next

                        Next

                        ' compara la variable
                        If byExiste = 0 And byRegistroActivo = 1 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                        End If

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1230()
        Dim inconsistencia As String = "Ficha con área común y característica de predio 3 sin zona económica común."
        Dim codigo As String = "1230"
        Dim stError As String = "SEVERO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 And dt_FICHPRED.Rows(0).Item("FIPRCAPR") = 3 Then

                    ' declaro la variable
                    Dim inTotalTotalEdificio As Integer = 0

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

                    ' variable de la consulta
                    Dim ParametrosConsulta2 As String = ""

                    ' Concatena la condicion de la consulta
                    ParametrosConsulta2 += "Select "
                    ParametrosConsulta2 += "ZoecCodi "
                    ParametrosConsulta2 += "From mant_ZonaEcon where "
                    ParametrosConsulta2 += "ZoecDepa = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRDEPA")) & "' and "
                    ParametrosConsulta2 += "ZoecMuni = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRMUNI")) & "' and "
                    ParametrosConsulta2 += "ZoecClse = '" & Trim(dt_FICHPRED.Rows(0).Item("FIPRCLSE")) & "' and "
                    ParametrosConsulta2 += "ZoecZoco = '" & 1 & "' and "
                    ParametrosConsulta2 += "ZoecEsta = 'ac' "

                    ' ejecuta la consulta
                    oEjecutar = New SqlCommand(ParametrosConsulta2, oConexion)

                    ' procesa la consulta 
                    oEjecutar.CommandTimeout = 360
                    oEjecutar.CommandType = CommandType.Text
                    oAdapter.SelectCommand = oEjecutar

                    ' llena el datatable 
                    oAdapter.Fill(dt_2)

                    ' cierra la conexion
                    oConexion.Close()

                    ' declara la variable encontro
                    Dim byExiste As Byte = 0
                    Dim byRegistroActivo As Byte = 0

                    ' verifica la tabla
                    If dt_2.Rows.Count > 0 And dt_FICHPRED.Rows(0).Item("FIPRACLO") > 0 Then

                        ' declara la variable de mantenimiento
                        Dim i As Integer = 0

                        For i = 0 To dt_2.Rows.Count - 1

                            ' declaro la variable de zona ficha
                            Dim k As Integer = 0

                            For k = 0 To dt_FIPRZOEC.Rows.Count - 1

                                If Trim(dt_FIPRZOEC.Rows(k).Item("FPZEESTA")) = "ac" Then
                                    byRegistroActivo = 1

                                    If dt_2.Rows(i).Item("ZOECCODI") = dt_FIPRZOEC.Rows(k).Item("FPZEZOEC") Then

                                        If byExiste = 0 Then
                                            byExiste = 1
                                        End If

                                    End If
                                End If

                            Next

                        Next

                        ' compara la variable
                        If byExiste = 0 And byRegistroActivo = 1 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia)

                        End If

                    End If

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub
    Private Sub pro_Inconsistencia_1231()
        Dim inconsistencia As String = "Ficha resumen con más de 3 pisos y sin construcciones comunes."
        Dim codigo As String = "1231"
        Dim stError As String = "AVISO"

        Try
            Dim filas1() As DataRow
            filas1 = dt_VALIRETI.Select("VARECODI =  '" & codigo & "' and VAREESTA = 'ac'")
            If filas1.Length = 0 Then

                If dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 2 Or dt_FICHPRED.Rows(0).Item("FIPRTIFI") = 3 Then
                    If dt_FICHPRED.Rows(0).Item("FIPRPISO") > 3 Then

                        If dt_FIPRCONS.Rows.Count = 0 Then

                            pro_GrabarInconsistencia(codigo & " - " & stError, inconsistencia & " Piso: " & dt_FICHPRED.Rows(0).Item("FIPRPISO"))

                        End If

                    End If
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & codigo & " " & dt_FICHPRED.Rows(0).Item("FIPRNUFI"))
        End Try

    End Sub

#End Region

#End Region

End Module
