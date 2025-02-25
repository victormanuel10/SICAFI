Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports REGLAS_DEL_NEGOCIO

Module mod_fun_LISTA_VALORES_FICHA_PREDIAL

    '================================
    ' *** LISTA DE VALORES SICAFI ***
    '================================

    ''' <summary>
    ''' carga el codigo seleccionado desde un combobox
    ''' </summary>
    Public Function fun_Buscar_Lista_Valores_DEPARTAMENTO_Codigo(ByVal obDEPACODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obDEPACODI.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_DEPARTAMENTO
                Dim tbl As New DataTable

                tbl = objdatos2.fun_Buscar_CODIGO_MANT_DEPARTAMENTO(Trim(obDEPACODI.SelectedValue))

                Dim sw, j As Integer

                While j < tbl.Rows.Count And sw = 0
                    If Trim(obDEPACODI.SelectedValue) = Trim(tbl.Rows(j).Item("DEPACODI")) Then
                        Descripcion = tbl.Rows(j).Item("DEPACODI")
                        sw = 1
                    Else
                        j = j + 1
                    End If
                End While

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_MUNICIPIO_Codigo(ByVal obMUNIDEPA As Object, _
                                                              ByVal obMUNICODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obMUNIDEPA.SelectedValue Is Nothing Then
                If Not obMUNICODI.SelectedValue Is Nothing Then

                    Dim objdatos1 As New cla_MUNICIPIO
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_DEPARTAMENTO_Y_CODIGO_MANT_MUNICIPIO(Trim(obMUNIDEPA.SelectedValue), Trim(obMUNICODI.SelectedValue))

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If Trim(obMUNICODI.SelectedValue) = Trim(tbl1.Rows(j1).Item("MUNICODI")) Then
                            Descripcion = tbl1.Rows(j1).Item("MUNICODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While

                End If
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_MES_Codigo(ByVal obMUNIVIGE As Object, _
                                                        ByVal obMUNIMES As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obMUNIVIGE.SelectedValue Is Nothing Then
                If Not obMUNIMES.SelectedValue Is Nothing Then

                    Dim objdatos1 As New cla_PERIODO
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_CODIGO_VIGENCIA_X_MES_X_PERIODO(Trim(obMUNIVIGE.SelectedValue), Trim(obMUNIMES.SelectedValue))

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If Trim(obMUNIMES.SelectedValue) = Trim(tbl1.Rows(j1).Item("PERIMES")) Then
                            Descripcion = tbl1.Rows(j1).Item("PERIMES")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While

                End If
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CLASSECT_Codigo(ByVal obCLSECODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obCLSECODI.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_CLASSECT
                Dim tbl2 As New DataTable

                If Not IsNumeric(obCLSECODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_CLASSECT(obCLSECODI.SelectedValue)

                    Dim sw2, j2 As Integer

                    While j2 < tbl2.Rows.Count And sw2 = 0
                        If obCLSECODI.SelectedValue = tbl2.Rows(j2).Item("CLSECODI") Then
                            Descripcion = tbl2.Rows(j2).Item("CLSECODI")
                            sw2 = 1
                        Else
                            j2 = j2 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_TIPOLIQU_Codigo(ByVal obTILICODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obTILICODI.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_TIPOLIQU
                Dim tbl2 As New DataTable

                If Not IsNumeric(obTILICODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl2 = objdatos2.fun_Buscar_CODIGO_TIPOLIQU(obTILICODI.SelectedValue)

                    Dim sw2, j2 As Integer

                    While j2 < tbl2.Rows.Count And sw2 = 0
                        If obTILICODI.SelectedValue = tbl2.Rows(j2).Item("TILICODI") Then
                            Descripcion = tbl2.Rows(j2).Item("TILICODI")
                            sw2 = 1
                        Else
                            j2 = j2 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CLASOBUR_Codigo(ByVal obCLOUCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obCLOUCODI.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_CLASOBUR
                Dim tbl2 As New DataTable

                If Not IsNumeric(obCLOUCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl2 = objdatos2.fun_Buscar_CODIGO_CLASOBUR(obCLOUCODI.SelectedValue)

                    Dim sw2, j2 As Integer

                    While j2 < tbl2.Rows.Count And sw2 = 0
                        If obCLOUCODI.SelectedValue = tbl2.Rows(j2).Item("CLOUCODI") Then
                            Descripcion = tbl2.Rows(j2).Item("CLOUCODI")
                            sw2 = 1
                        Else
                            j2 = j2 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_FOPAPLPA_Codigo(ByVal obFPPPCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obFPPPCODI.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_FOPAPLPA
                Dim tbl2 As New DataTable

                If Not IsNumeric(obFPPPCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl2 = objdatos2.fun_Buscar_CODIGO_FOPAPLPA(obFPPPCODI.SelectedValue)

                    Dim sw2, j2 As Integer

                    While j2 < tbl2.Rows.Count And sw2 = 0
                        If obFPPPCODI.SelectedValue = tbl2.Rows(j2).Item("FPPPCODI") Then
                            Descripcion = tbl2.Rows(j2).Item("FPPPCODI")
                            sw2 = 1
                        Else
                            j2 = j2 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_ZONAPLAN_Codigo(ByVal obZOPLCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obZOPLCODI.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_ZONAPLAN
                Dim tbl2 As New DataTable

                If Not IsNumeric(obZOPLCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl2 = objdatos2.fun_Buscar_CODIGO_ZONAPLAN(obZOPLCODI.SelectedValue)

                    Dim sw2, j2 As Integer

                    While j2 < tbl2.Rows.Count And sw2 = 0
                        If obZOPLCODI.SelectedValue = tbl2.Rows(j2).Item("ZOPLCODI") Then
                            Descripcion = tbl2.Rows(j2).Item("ZOPLCODI")
                            sw2 = 1
                        Else
                            j2 = j2 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_SERVPUBL_Codigo(ByVal obSEPUCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obSEPUCODI.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_SERVPUBL
                Dim tbl2 As New DataTable

                If Not IsNumeric(obSEPUCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl2 = objdatos2.fun_Buscar_CODIGO_SERVPUBL(obSEPUCODI.SelectedValue)

                    Dim sw2, j2 As Integer

                    While j2 < tbl2.Rows.Count And sw2 = 0
                        If obSEPUCODI.SelectedValue = tbl2.Rows(j2).Item("SEPUCODI") Then
                            Descripcion = tbl2.Rows(j2).Item("SEPUCODI")
                            sw2 = 1
                        Else
                            j2 = j2 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_FORMULARIO_Codigo(ByVal obFORMCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obFORMCODI.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_FORMULARIO
                Dim tbl2 As New DataTable

                If IsNumeric(obFORMCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_FORMULARIO(obFORMCODI.SelectedValue)

                    Dim sw2, j2 As Integer

                    While j2 < tbl2.Rows.Count And sw2 = 0
                        If Trim(obFORMCODI.SelectedValue) = Trim(tbl2.Rows(j2).Item("FORMCODI")) Then
                            Descripcion = tbl2.Rows(j2).Item("FORMCODI")
                            sw2 = 1
                        Else
                            j2 = j2 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_MATECAMP_Codigo(ByVal obMACACODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obMACACODI.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_MATECAMP
                Dim tbl2 As New DataTable

                If Not IsNumeric(obMACACODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_MATECAMP(obMACACODI.SelectedValue)

                    Dim sw2, j2 As Integer

                    While j2 < tbl2.Rows.Count And sw2 = 0
                        If Trim(obMACACODI.SelectedValue) = Trim(tbl2.Rows(j2).Item("MACACODI")) Then
                            Descripcion = tbl2.Rows(j2).Item("MACACODI")
                            sw2 = 1
                        Else
                            j2 = j2 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CARPFOTO_Codigo(ByVal obCAFOCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obCAFOCODI.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_CARPFOTO
                Dim tbl2 As New DataTable

                If Not IsNumeric(obCAFOCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_CARPFOTO(obCAFOCODI.SelectedValue)

                    Dim sw2, j2 As Integer

                    While j2 < tbl2.Rows.Count And sw2 = 0
                        If obCAFOCODI.SelectedValue = tbl2.Rows(j2).Item("CAFOCODI") Then
                            Descripcion = tbl2.Rows(j2).Item("CAFOCODI")
                            sw2 = 1
                        Else
                            j2 = j2 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_PLANCART_Codigo(ByVal obPLCACODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obPLCACODI.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_PLANCART
                Dim tbl2 As New DataTable

                If Not IsNumeric(obPLCACODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_PLANCART(obPLCACODI.SelectedValue)

                    Dim sw2, j2 As Integer

                    While j2 < tbl2.Rows.Count And sw2 = 0
                        If obPLCACODI.SelectedValue = tbl2.Rows(j2).Item("PLCACODI") Then
                            Descripcion = tbl2.Rows(j2).Item("PLCACODI")
                            sw2 = 1
                        Else
                            j2 = j2 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_FIPRDIGI_Codigo(ByVal obFPDICODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obFPDICODI.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_FIPRDIGI
                Dim tbl2 As New DataTable

                If Not IsNumeric(obFPDICODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_FIPRDIGI(obFPDICODI.SelectedValue)

                    Dim sw2, j2 As Integer

                    While j2 < tbl2.Rows.Count And sw2 = 0
                        If obFPDICODI.SelectedValue = tbl2.Rows(j2).Item("FPDICODI") Then
                            Descripcion = tbl2.Rows(j2).Item("FPDICODI")
                            sw2 = 1
                        Else
                            j2 = j2 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_DOCUGENE_Codigo(ByVal obDOGEDEPA As Object, _
                                                             ByVal obDOGEMUNI As Object, _
                                                             ByVal obDOGECODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obDOGEDEPA.SelectedValue Is Nothing And _
               Not obDOGEMUNI.SelectedValue Is Nothing And _
               Not obDOGECODI.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_DOCUGENE
                Dim tbl2 As New DataTable

                If Not IsNumeric(obDOGEDEPA.SelectedValue) And _
                   Not IsNumeric(obDOGEMUNI.SelectedValue) And _
                   Not IsNumeric(obDOGECODI.SelectedValue) Then

                    Descripcion = ""
                Else
                    tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_DOCUGENE(obDOGEDEPA.SelectedValue, obDOGEMUNI.SelectedValue, obDOGECODI.SelectedValue)

                    Dim sw2, j2 As Integer

                    While j2 < tbl2.Rows.Count And sw2 = 0
                        If obDOGECODI.SelectedValue = tbl2.Rows(j2).Item("DOGECODI") Then
                            Descripcion = tbl2.Rows(j2).Item("DOGECODI")
                            sw2 = 1
                        Else
                            j2 = j2 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CARAPRED_Codigo(ByVal obCAPRCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obCAPRCODI.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_CARAPRED
                Dim tbl2 As New DataTable

                If Not IsNumeric(obCAPRCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_CARAPRED(obCAPRCODI.SelectedValue)

                    Dim sw2, j2 As Integer

                    While j2 < tbl2.Rows.Count And sw2 = 0
                        If obCAPRCODI.SelectedValue = tbl2.Rows(j2).Item("CAPRCODI") Then
                            Descripcion = tbl2.Rows(j2).Item("CAPRCODI")
                            sw2 = 1
                        Else
                            j2 = j2 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CLASPRED_Codigo(ByVal obCLPRCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obCLPRCODI.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_CLASPRED
                Dim tbl2 As New DataTable

                If Not IsNumeric(obCLPRCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl2 = objdatos2.fun_Buscar_CODIGO_CLASPRED(obCLPRCODI.SelectedValue)

                    Dim sw2, j2 As Integer

                    While j2 < tbl2.Rows.Count And sw2 = 0
                        If obCLPRCODI.SelectedValue = tbl2.Rows(j2).Item("CLPRCODI") Then
                            Descripcion = tbl2.Rows(j2).Item("CLPRCODI")
                            sw2 = 1
                        Else
                            j2 = j2 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_MOBILIARIO_Codigo(ByVal obMOBICODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obMOBICODI.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_MOBILIARIO
                Dim tbl2 As New DataTable

                If Not IsNumeric(obMOBICODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl2 = objdatos2.fun_Buscar_CODIGO_MOBILIARIO(obMOBICODI.SelectedValue)

                    Dim sw2, j2 As Integer

                    While j2 < tbl2.Rows.Count And sw2 = 0
                        If obMOBICODI.SelectedValue = tbl2.Rows(j2).Item("MOBICODI") Then
                            Descripcion = tbl2.Rows(j2).Item("MOBICODI")
                            sw2 = 1
                        Else
                            j2 = j2 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_METOINVE_Codigo(ByVal obMEINCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obMEINCODI.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_METOINVE
                Dim tbl2 As New DataTable

                If Not IsNumeric(obMEINCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl2 = objdatos2.fun_Buscar_CODIGO_METOINVE(obMEINCODI.SelectedValue)

                    Dim sw2, j2 As Integer

                    While j2 < tbl2.Rows.Count And sw2 = 0
                        If obMEINCODI.SelectedValue = tbl2.Rows(j2).Item("MEINCODI") Then
                            Descripcion = tbl2.Rows(j2).Item("MEINCODI")
                            sw2 = 1
                        Else
                            j2 = j2 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CLASCONS_Codigo(ByVal obCLCOCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obCLCOCODI.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_CLASCONS
                Dim tbl2 As New DataTable

                If Not IsNumeric(obCLCOCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_CLASCONS(obCLCOCODI.SelectedValue)

                    Dim sw2, j2 As Integer

                    While j2 < tbl2.Rows.Count And sw2 = 0
                        If obCLCOCODI.SelectedValue = tbl2.Rows(j2).Item("CLCOCODI") Then
                            Descripcion = tbl2.Rows(j2).Item("CLCOCODI")
                            sw2 = 1
                        Else
                            j2 = j2 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_DESTECON_Codigo(ByVal obDEECCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obDEECCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_DESTECON
                Dim tbl1 As New DataTable

                If Not IsNumeric(obDEECCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_DESTECON(obDEECCODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obDEECCODI.SelectedValue = tbl1.Rows(j1).Item("DEECCODI") Then
                            Descripcion = tbl1.Rows(j1).Item("DEECCODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_ZONAECON_Codigo(ByVal obZOECDEPA As Object, _
                                                             ByVal obZOECMUNI As Object, _
                                                             ByVal obZOECCLSE As Object, _
                                                             ByVal obZOECCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obZOECDEPA.SelectedValue Is Nothing Then
                If Not obZOECMUNI.SelectedValue Is Nothing Then
                    If Not obZOECCLSE.SelectedValue Is Nothing Then
                        If Not obZOECCODI.SelectedValue Is Nothing Then

                            If Not IsNumeric(obZOECCLSE.SelectedValue) AndAlso _
                               Not IsNumeric(obZOECCODI.SelectedValue) Then
                                Descripcion = ""
                            Else
                                Dim objdatos1 As New cla_ZONAECON
                                Dim tbl1 As New DataTable

                                tbl1 = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAECON(Trim(obZOECDEPA.SelectedValue), Trim(obZOECMUNI.SelectedValue), obZOECCLSE.SelectedValue, obZOECCODI.SelectedValue)

                                Dim sw1, j1 As Integer

                                While j1 < tbl1.Rows.Count And sw1 = 0
                                    If obZOECCODI.SelectedValue = tbl1.Rows(j1).Item("ZOECCODI") Then
                                        Descripcion = tbl1.Rows(j1).Item("ZOECCODI")
                                        sw1 = 1
                                    Else
                                        j1 = j1 + 1
                                    End If
                                End While
                            End If

                        End If
                    End If
                End If
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_VIGENCIA_Codigo(ByVal obVIGECODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obVIGECODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_VIGENCIA
                Dim tbl1 As New DataTable

                If Not IsNumeric(obVIGECODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_VIGENCIA(obVIGECODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obVIGECODI.SelectedValue = tbl1.Rows(j1).Item("VIGECODI") Then
                            Descripcion = tbl1.Rows(j1).Item("VIGECODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_AREAACTI_Codigo(ByVal obARACCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obARACCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_AREAACTI
                Dim tbl1 As New DataTable

                If Not IsNumeric(obARACCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_AREAACTI(obARACCODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obARACCODI.SelectedValue = tbl1.Rows(j1).Item("ARACCODI") Then
                            Descripcion = tbl1.Rows(j1).Item("ARACCODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_TRATURBA_Codigo(ByVal obTRURCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obTRURCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_TRATURBA
                Dim tbl1 As New DataTable

                If Not IsNumeric(obTRURCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_TRATURBA(obTRURCODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obTRURCODI.SelectedValue = tbl1.Rows(j1).Item("TRURCODI") Then
                            Descripcion = tbl1.Rows(j1).Item("TRURCODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_SERVICIOS_Codigo(ByVal obSERVCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obSERVCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_SERVICIOS
                Dim tbl1 As New DataTable

                If Not IsNumeric(obSERVCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_SERVICIOS(obSERVCODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obSERVCODI.SelectedValue = tbl1.Rows(j1).Item("SERVCODI") Then
                            Descripcion = tbl1.Rows(j1).Item("SERVCODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_VIAS_Codigo(ByVal obVIASCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obVIASCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_VIAS
                Dim tbl1 As New DataTable

                If Not IsNumeric(obVIASCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_VIAS(obVIASCODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obVIASCODI.SelectedValue = tbl1.Rows(j1).Item("VIASCODI") Then
                            Descripcion = tbl1.Rows(j1).Item("VIASCODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_TOPOGRAFIA_Codigo(ByVal obTOPOCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obTOPOCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_TOPOGRAFIA
                Dim tbl1 As New DataTable

                If Not IsNumeric(obTOPOCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_TOPOGRAFIA(obTOPOCODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obTOPOCODI.SelectedValue = tbl1.Rows(j1).Item("TOPOCODI") Then
                            Descripcion = tbl1.Rows(j1).Item("TOPOCODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_AGUAS_Codigo(ByVal obAGUACODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obAGUACODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_AGUAS
                Dim tbl1 As New DataTable

                If Not IsNumeric(obAGUACODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_AGUAS(obAGUACODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obAGUACODI.SelectedValue = tbl1.Rows(j1).Item("AGUACODI") Then
                            Descripcion = tbl1.Rows(j1).Item("AGUACODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_AHT_Codigo(ByVal obAHTCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obAHTCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_AHT
                Dim tbl1 As New DataTable

                If Not IsNumeric(obAHTCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_AHT(obAHTCODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obAHTCODI.SelectedValue = tbl1.Rows(j1).Item("AHTCODI") Then
                            Descripcion = tbl1.Rows(j1).Item("AHTCODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CLASSUEL_Codigo(ByVal obCLSUCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obCLSUCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_CLASSUEL
                Dim tbl1 As New DataTable

                If Not IsNumeric(obCLSUCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_CLASSUEL(obCLSUCODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obCLSUCODI.SelectedValue = tbl1.Rows(j1).Item("CLSUCODI") Then
                            Descripcion = tbl1.Rows(j1).Item("CLSUCODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_SOLICITANTE_Codigo(ByVal obSOLICODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obSOLICODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_SOLICITANTE
                Dim tbl1 As New DataTable

                If Not IsNumeric(obSOLICODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_SOLICITANTE(obSOLICODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obSOLICODI.SelectedValue = tbl1.Rows(j1).Item("SOLICODI") Then
                            Descripcion = tbl1.Rows(j1).Item("SOLICODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CLASIFICACION_Codigo(ByVal obCLASCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obCLASCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_CLASIFICACION
                Dim tbl1 As New DataTable

                If Not IsNumeric(obCLASCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_CLASIFICACION(obCLASCODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obCLASCODI.SelectedValue = tbl1.Rows(j1).Item("CLASCODI") Then
                            Descripcion = tbl1.Rows(j1).Item("CLASCODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_MEDIRESE_Codigo(ByVal obMERECODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obMERECODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_MEDIRESE
                Dim tbl1 As New DataTable

                If Not IsNumeric(obMERECODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_MEDIRESE(obMERECODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obMERECODI.SelectedValue = tbl1.Rows(j1).Item("MERECODI") Then
                            Descripcion = tbl1.Rows(j1).Item("MERECODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_MEDINOTI_Codigo(ByVal obMENOCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obMENOCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_MEDINOTI
                Dim tbl1 As New DataTable

                If Not IsNumeric(obMENOCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_MEDINOTI(obMENOCODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obMENOCODI.SelectedValue = tbl1.Rows(j1).Item("MENOCODI") Then
                            Descripcion = tbl1.Rows(j1).Item("MENOCODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_DIVISION_Codigo(ByVal obDIVICODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obDIVICODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_DIVISION
                Dim tbl1 As New DataTable

                If Not IsNumeric(obDIVICODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_DIVISION(obDIVICODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obDIVICODI.SelectedValue = tbl1.Rows(j1).Item("DIVICODI") Then
                            Descripcion = tbl1.Rows(j1).Item("DIVICODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_RESOAJUS_Codigo(ByVal obREAJCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obREAJCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_RESOAJUS
                Dim tbl1 As New DataTable

                If Not IsNumeric(obREAJCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_RESOAJUS(obREAJCODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obREAJCODI.SelectedValue = tbl1.Rows(j1).Item("REAJCODI") Then
                            Descripcion = tbl1.Rows(j1).Item("REAJCODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_ESTADO_Codigo(ByVal obESTACODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obESTACODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_ESTADO
                Dim tbl1 As New DataTable

                If Not IsNumeric(obESTACODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_ESTADO(obESTACODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obESTACODI.SelectedValue = tbl1.Rows(j1).Item("ESTACODI") Then
                            Descripcion = tbl1.Rows(j1).Item("ESTACODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_ESTRATO_Codigo(ByVal obESTRCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obESTRCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_ESTRATO
                Dim tbl1 As New DataTable

                If Not IsNumeric(obESTRCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_ESTRATO(obESTRCODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obESTRCODI.SelectedValue = tbl1.Rows(j1).Item("ESTRCODI") Then
                            Descripcion = tbl1.Rows(j1).Item("ESTRCODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While

                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_TIPOCALI_Codigo(ByVal obTICACODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obTICACODI.SelectedValue Is Nothing Then
                obTICACODI.Text = ""

                Dim objdatos1 As New cla_TIPOCALI
                Dim tbl1 As New DataTable

                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_TIPOCALI(obTICACODI.SelectedValue)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If Trim(obTICACODI.SelectedValue) = Trim(tbl1.Rows(j1).Item("TICACODI")) Then
                        Descripcion = tbl1.Rows(j1).Item("TICACODI")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CONCEPTO_Codigo(ByVal obCONCTIIM As Object, _
                                                             ByVal obCONCCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obCONCTIIM.SelectedValue Is Nothing Then
                If Not obCONCCODI.SelectedValue Is Nothing Then

                    Dim objdatos1 As New cla_CONCEPTO
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_CODIGO_CONCEPTO(Trim(obCONCTIIM.SelectedValue), Trim(obCONCCODI.SelectedValue))

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If Trim(obCONCCODI.SelectedValue) = Trim(tbl1.Rows(j1).Item("CONCCODI")) Then
                            Descripcion = tbl1.Rows(j1).Item("CONCCODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While

                End If
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_SEGUDEST_Codigo(ByVal obSEDEDEST As Object, _
                                                             ByVal obSEDECODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obSEDEDEST.SelectedValue Is Nothing Then
                If Not obSEDECODI.SelectedValue Is Nothing Then

                    Dim objdatos1 As New cla_SEGUDEST
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_CODIGO_SEGUDEST(Trim(obSEDEDEST.SelectedValue), Trim(obSEDECODI.SelectedValue))

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If Trim(obSEDECODI.SelectedValue) = Trim(tbl1.Rows(j1).Item("SEDECODI")) Then
                            Descripcion = tbl1.Rows(j1).Item("SEDECODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While

                End If
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_VARIABLE_Codigo(ByVal obVARITIVA As Object, _
                                                             ByVal obVARICODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obVARITIVA.SelectedValue Is Nothing Then
                If Not obVARICODI.SelectedValue Is Nothing Then

                    Dim objdatos1 As New cla_VARIABLE
                    Dim tbl1 As New DataTable

                    tbl1 = objdatos1.fun_Buscar_CODIGO_VARIABLE(Trim(obVARITIVA.SelectedValue), Trim(obVARICODI.SelectedValue))

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If Trim(obVARICODI.SelectedValue) = Trim(tbl1.Rows(j1).Item("VARICODI")) Then
                            Descripcion = tbl1.Rows(j1).Item("VARICODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While

                End If
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_TIPOIMPU_Codigo(ByVal obTIIMCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obTIIMCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_TIPOIMPU
                Dim tbl1 As New DataTable

                If Not IsNumeric(obTIIMCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_TIPOIMPU(obTIIMCODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obTIIMCODI.SelectedValue = tbl1.Rows(j1).Item("TIIMCODI") Then
                            Descripcion = tbl1.Rows(j1).Item("TIIMCODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try


    End Function
    Public Function fun_Buscar_Lista_Valores_TIPOVARI_Codigo(ByVal obTIVACODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obTIVACODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_TIPOVARI
                Dim tbl1 As New DataTable

                If Not IsNumeric(obTIVACODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_TIPOVARI(obTIVACODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obTIVACODI.SelectedValue = tbl1.Rows(j1).Item("TIVACODI") Then
                            Descripcion = tbl1.Rows(j1).Item("TIVACODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try


    End Function
    Public Function fun_Buscar_Lista_Valores_DESTINACION_Codigo(ByVal obDESTCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obDESTCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_DESTINACION
                Dim tbl1 As New DataTable

                If Not IsNumeric(obDESTCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_DESTINACION(obDESTCODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obDESTCODI.SelectedValue = tbl1.Rows(j1).Item("DESTCODI") Then
                            Descripcion = tbl1.Rows(j1).Item("DESTCODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try


    End Function
    Public Function fun_Buscar_Lista_Valores_PROYECTO_Codigo(ByVal obPROYDEPA As Object, _
                                                             ByVal obPROYMUNI As Object, _
                                                             ByVal obPROYCLSE As Object, _
                                                             ByVal obPROYCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obPROYDEPA.SelectedValue Is Nothing Then
                If Not obPROYMUNI.SelectedValue Is Nothing Then
                    If Not obPROYCLSE.SelectedValue Is Nothing Then
                        If Not obPROYCODI.SelectedValue Is Nothing Then

                            Dim objdatos1 As New cla_PROYECTO
                            Dim tbl1 As New DataTable

                            If Not IsNumeric(obPROYDEPA.SelectedValue) AndAlso _
                               Not IsNumeric(obPROYMUNI.SelectedValue) AndAlso _
                               Not IsNumeric(obPROYCLSE.SelectedValue) AndAlso _
                               Not IsNumeric(obPROYCODI.SelectedValue) Then
                                Descripcion = ""
                            Else
                                tbl1 = objdatos1.fun_Buscar_CODIGO_PROYECTO(obPROYDEPA.SelectedValue, _
                                                                            obPROYMUNI.SelectedValue, _
                                                                            obPROYCLSE.SelectedValue, _
                                                                            obPROYCODI.SelectedValue)

                                Dim sw1, j1 As Integer

                                While j1 < tbl1.Rows.Count And sw1 = 0
                                    If obPROYCODI.SelectedValue = tbl1.Rows(j1).Item("PROYCODI") Then
                                        Descripcion = tbl1.Rows(j1).Item("PROYCODI")
                                        sw1 = 1
                                    Else
                                        j1 = j1 + 1
                                    End If
                                End While

                            End If

                        End If
                    End If
                End If
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try


    End Function
    Public Function fun_Buscar_Lista_Valores_FORMULA_Codigo(ByVal obFORMCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obFORMCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_FORMULA
                Dim tbl1 As New DataTable

                If (obFORMCODI.SelectedValue) = "" Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_FORMULA(obFORMCODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obFORMCODI.SelectedValue = tbl1.Rows(j1).Item("FORMCODI") Then
                            Descripcion = tbl1.Rows(j1).Item("FORMCODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try


    End Function
    Public Function fun_Buscar_Lista_Valores_CAUSACTO_Codigo(ByVal obCAACCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obCAACCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_CAUSACTO
                Dim tbl1 As New DataTable

                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_CAUSACTO(obCAACCODI.SelectedValue)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If obCAACCODI.SelectedValue = tbl1.Rows(j1).Item("CAACCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("CAACCODI")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CLASVERS_Codigo(ByVal obCLVECODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obCLVECODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_CLASVERS
                Dim tbl1 As New DataTable

                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_CLASVERS(obCLVECODI.SelectedValue)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If obCLVECODI.SelectedValue = tbl1.Rows(j1).Item("CLVECODI") Then
                        Descripcion = tbl1.Rows(j1).Item("CLVECODI")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_USUARIO_Codigo(ByVal obUSUANUDO As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obUSUANUDO.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_USUARIO
                Dim tbl1 As New DataTable

                If Not IsNumeric(obUSUANUDO.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_USUARIO(obUSUANUDO.SelectedValue)

                    Dim j1 As Integer = 0
                    Dim sw1 As Integer = 0

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If Trim(obUSUANUDO.SelectedValue) = Trim(tbl1.Rows(j1).Item("USUANUDO")) Then
                            Descripcion = tbl1.Rows(j1).Item("USUANUDO")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While
                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_TIPODOCU_Codigo(ByVal obTIDOCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obTIDOCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_TIPODOCU
                Dim tbl1 As New DataTable

                If Not IsNumeric(obTIDOCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_TIPODOCU(obTIDOCODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obTIDOCODI.SelectedValue = tbl1.Rows(j1).Item("TIDOCODI") Then
                            Descripcion = tbl1.Rows(j1).Item("TIDOCODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While

                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CALIPROP_Codigo(ByVal obCAPRCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obCAPRCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_CALIPROP
                Dim tbl1 As New DataTable

                If Not IsNumeric(obCAPRCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_CALIPROP(obCAPRCODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obCAPRCODI.SelectedValue = tbl1.Rows(j1).Item("CAPRCODI") Then
                            Descripcion = tbl1.Rows(j1).Item("CAPRCODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While

                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_SEXO_Codigo(ByVal obSEXOCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obSEXOCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_SEXO
                Dim tbl1 As New DataTable

                If Not IsNumeric(obSEXOCODI.SelectedValue) Then
                    Descripcion = ""
                Else
                    tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_SEXO(obSEXOCODI.SelectedValue)

                    Dim sw1, j1 As Integer

                    While j1 < tbl1.Rows.Count And sw1 = 0
                        If obSEXOCODI.SelectedValue = tbl1.Rows(j1).Item("SEXOCODI") Then
                            Descripcion = tbl1.Rows(j1).Item("SEXOCODI")
                            sw1 = 1
                        Else
                            j1 = j1 + 1
                        End If
                    End While

                End If

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_TIPOTRAM_Codigo(ByVal obTITRCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obTITRCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_TIPOTRAM
                Dim tbl1 As New DataTable

                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_TIPOTRAM(obTITRCODI.SelectedValue)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If obTITRCODI.SelectedValue = tbl1.Rows(j1).Item("TITRCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("TITRCODI")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_ACTOADMI_Codigo(ByVal obACADCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obACADCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_ACTOADMI
                Dim tbl1 As New DataTable

                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_ACTOADMI(obACADCODI.SelectedValue)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If obACADCODI.SelectedValue = tbl1.Rows(j1).Item("ACADCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("ACADCODI")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CLASENTI_Codigo(ByVal obCLENCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obCLENCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_CLASENTI
                Dim tbl1 As New DataTable

                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_CLASENTI(obCLENCODI.SelectedValue)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If obCLENCODI.SelectedValue = tbl1.Rows(j1).Item("CLENCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("CLENCODI")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_TIPORESO_Codigo(ByVal obACADCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obACADCODI.SelectedValue Is Nothing Then

                Dim objdatos1 As New cla_TIPORESO
                Dim tbl1 As New DataTable

                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_TIPORESO(obACADCODI.SelectedValue)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If obACADCODI.SelectedValue = tbl1.Rows(j1).Item("TIRECODI") Then
                        Descripcion = tbl1.Rows(j1).Item("TIRECODI")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_PROCEDIMIENTO_Codigo(ByVal obPROCCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obPROCCODI.SelectedValue Is Nothing Then

                Dim objdatos2 As New cla_PROCEDIMIENTO
                Dim tbl2 As New DataTable

                tbl2 = objdatos2.fun_Buscar_CODIGO_PROCEDIMIENTO(obPROCCODI.SelectedValue)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If Trim(obPROCCODI.SelectedValue) = Trim(tbl2.Rows(j2).Item("PROCCODI")) Then
                        Descripcion = tbl2.Rows(j2).Item("PROCCODI")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_TABLAS_Codigo(ByVal obTABLCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obTABLCODI.SelectedValue Is Nothing Then

                Dim a As Object = obTABLCODI.SelectedValue

                Dim objdatos2 As New cla_TABLAS
                Dim tbl2 As New DataTable

                tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_TABLAS(obTABLCODI.SelectedValue)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If Trim(obTABLCODI.SelectedValue) = Trim(tbl2.Rows(j2).Item("TABLCODI")) Then
                        Descripcion = tbl2.Rows(j2).Item("TABLCODI")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_COMUNA_Codigo(ByVal obCOMUDEPA As Object, _
                                                           ByVal obCOMUMUNI As Object, _
                                                           ByVal obCOMUCLSE As Object, _
                                                           ByVal obCOMUCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obCOMUDEPA.SelectedValue Is Nothing Then
                If Not obCOMUMUNI.SelectedValue Is Nothing Then
                    If Not obCOMUCLSE.SelectedValue Is Nothing Then
                        If Not obCOMUCODI.SelectedValue Is Nothing Then

                            If Not IsNumeric(obCOMUCLSE.SelectedValue) AndAlso _
                               Not IsNumeric(obCOMUCODI.SelectedValue) Then
                                Descripcion = ""
                            Else
                                Dim objdatos1 As New cla_COMUNA
                                Dim tbl1 As New DataTable

                                tbl1 = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_COMU_X_COMUNA(Trim(obCOMUDEPA.SelectedValue), Trim(obCOMUMUNI.SelectedValue), Trim(obCOMUCLSE.SelectedValue), Trim(obCOMUCODI.SelectedValue))

                                Dim sw1, j1 As Integer

                                While j1 < tbl1.Rows.Count And sw1 = 0
                                    If Trim(obCOMUCODI.SelectedValue) = Trim(tbl1.Rows(j1).Item("COMUCODI")) Then
                                        Descripcion = tbl1.Rows(j1).Item("COMUCODI")
                                        sw1 = 1
                                    Else
                                        j1 = j1 + 1
                                    End If
                                End While

                            End If
                        End If

                    End If
                End If
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CORREGIMIENTO_Codigo(ByVal obCORRDEPA As Object, _
                                                                  ByVal obCORRMUNI As Object, _
                                                                  ByVal obCORRCLSE As Object, _
                                                                  ByVal obCORRCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obCORRDEPA.SelectedValue Is Nothing Then
                If Not obCORRMUNI.SelectedValue Is Nothing Then
                    If Not obCORRCLSE.SelectedValue Is Nothing Then
                        If Not obCORRCODI.SelectedValue Is Nothing Then

                            If Not IsNumeric(obCORRCLSE.SelectedValue) AndAlso _
                               Not IsNumeric(obCORRCODI.SelectedValue) Then
                                Descripcion = ""
                            Else
                                Dim objdatos1 As New cla_CORREGIMIENTO
                                Dim tbl1 As New DataTable

                                tbl1 = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_X_CORREGIMIENTO(Trim(obCORRDEPA.SelectedValue), Trim(obCORRMUNI.SelectedValue), Trim(obCORRCLSE.SelectedValue), Trim(obCORRCODI.SelectedValue))

                                Dim sw1, j1 As Integer

                                While j1 < tbl1.Rows.Count And sw1 = 0
                                    If Trim(obCORRCODI.SelectedValue) = Trim(tbl1.Rows(j1).Item("CORRCODI")) Then
                                        Descripcion = tbl1.Rows(j1).Item("CORRCODI")
                                        sw1 = 1
                                    Else
                                        j1 = j1 + 1
                                    End If
                                End While

                            End If
                        End If

                    End If
                End If
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_BARRVERE_Codigo(ByVal obBAVEDEPA As Object, _
                                                             ByVal obBAVEMUNI As Object, _
                                                             ByVal obBAVECLSE As Object, _
                                                             ByVal obBAVECODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obBAVEDEPA.SelectedValue Is Nothing Then
                If Not obBAVEMUNI.SelectedValue Is Nothing Then
                    If Not obBAVECLSE.SelectedValue Is Nothing Then
                        If Not obBAVECODI.SelectedValue Is Nothing Then

                            If Not IsNumeric(obBAVECLSE.SelectedValue) AndAlso _
                               Not IsNumeric(obBAVECODI.SelectedValue) Then
                                Descripcion = ""
                            Else
                                If obBAVECLSE.SelectedValue = 1 Or obBAVECLSE.SelectedValue = 3 Then

                                    Dim objdatos1 As New cla_BARRVERE
                                    Dim tbl1 As New DataTable

                                    tbl1 = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_BAVE_X_BARRVERE(Trim(obBAVEDEPA.SelectedValue), Trim(obBAVEMUNI.SelectedValue), Trim(obBAVECLSE.SelectedValue), Trim(obBAVECODI.SelectedValue))

                                    Dim sw1, j1 As Integer

                                    While j1 < tbl1.Rows.Count And sw1 = 0
                                        If Trim(obBAVECODI.SelectedValue) = Trim(tbl1.Rows(j1).Item("BAVECODI")) Then
                                            Descripcion = tbl1.Rows(j1).Item("BAVECODI")
                                            sw1 = 1
                                        Else
                                            j1 = j1 + 1
                                        End If
                                    End While

                                ElseIf obBAVECLSE.SelectedValue = 2 Then

                                    Dim objdatos1 As New cla_BARRVERE
                                    Dim tbl1 As New DataTable

                                    tbl1 = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_BAVE_X_BARRVERE(Trim(obBAVEDEPA.SelectedValue), Trim(obBAVEMUNI.SelectedValue), Trim(obBAVECLSE.SelectedValue), Trim(obBAVECODI.SelectedValue))

                                    Dim sw1, j1 As Integer

                                    While j1 < tbl1.Rows.Count And sw1 = 0
                                        If Trim(obBAVECODI.SelectedValue) = Trim(tbl1.Rows(j1).Item("BAVECODI")) Then
                                            Descripcion = tbl1.Rows(j1).Item("BAVECODI")
                                            sw1 = 1
                                        Else
                                            j1 = j1 + 1
                                        End If
                                    End While

                                End If

                            End If
                        End If

                    End If
                End If
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_BARRVERE_Codigo(ByVal obBAVEDEPA As Object, _
                                                             ByVal obBAVEMUNI As Object, _
                                                             ByVal obBAVECLSE As Object, _
                                                             ByVal obBAVECODI As Object, _
                                                             ByVal obBAVECORR As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obBAVEDEPA.SelectedValue Is Nothing Then
                If Not obBAVEMUNI.SelectedValue Is Nothing Then
                    If Not obBAVECLSE.SelectedValue Is Nothing Then
                        If Not obBAVECODI.SelectedValue Is Nothing Then
                            If Not obBAVECORR.SelectedValue Is Nothing Then

                                If Not IsNumeric(obBAVECLSE.SelectedValue) AndAlso _
                                   Not IsNumeric(obBAVECODI.SelectedValue) Then
                                    Descripcion = ""
                                Else
                                    If obBAVECLSE.SelectedValue = 1 Or obBAVECLSE.SelectedValue = 3 Then

                                        Dim objdatos1 As New cla_BARRVERE
                                        Dim tbl1 As New DataTable

                                        tbl1 = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_BAVE_X_BARRVERE(Trim(obBAVEDEPA.SelectedValue), Trim(obBAVEMUNI.SelectedValue), Trim(obBAVECLSE.SelectedValue), Trim(obBAVECORR.SelectedValue), Trim(obBAVECODI.SelectedValue))

                                        Dim sw1, j1 As Integer

                                        While j1 < tbl1.Rows.Count And sw1 = 0
                                            If Trim(obBAVECODI.SelectedValue) = Trim(tbl1.Rows(j1).Item("BAVECODI")) Then
                                                Descripcion = tbl1.Rows(j1).Item("BAVECODI")
                                                sw1 = 1
                                            Else
                                                j1 = j1 + 1
                                            End If
                                        End While

                                    ElseIf obBAVECLSE.SelectedValue = 2 Then

                                        Dim objdatos1 As New cla_BARRVERE
                                        Dim tbl1 As New DataTable

                                        tbl1 = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_BAVE_X_BARRVERE(Trim(obBAVEDEPA.SelectedValue), Trim(obBAVEMUNI.SelectedValue), Trim(obBAVECLSE.SelectedValue), Trim(obBAVECORR.SelectedValue), Trim(obBAVECODI.SelectedValue))

                                        Dim sw1, j1 As Integer

                                        While j1 < tbl1.Rows.Count And sw1 = 0
                                            If Trim(obBAVECODI.SelectedValue) = Trim(tbl1.Rows(j1).Item("BAVECODI")) Then
                                                Descripcion = tbl1.Rows(j1).Item("BAVECODI")
                                                sw1 = 1
                                            Else
                                                j1 = j1 + 1
                                            End If
                                        End While

                                    End If

                                End If
                            End If
                        End If
                    End If
                End If
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_TIPOCONS_Codigo(ByVal obTICODEPA As Object, _
                                                             ByVal obTICOMUNI As Object, _
                                                             ByVal obTICOCLCO As Object, _
                                                             ByVal obTICOCLSE As Object, _
                                                             ByVal obTICOCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obTICODEPA.SelectedValue Is Nothing Then
                If Not obTICOMUNI.SelectedValue Is Nothing Then
                    If Not obTICOCLSE.SelectedValue Is Nothing Then
                        If Not obTICOCODI.SelectedValue Is Nothing Then

                            If Not IsNumeric(obTICOCLCO.SelectedValue) AndAlso _
                               Not IsNumeric(obTICOCLSE.SelectedValue) AndAlso _
                               Not IsNumeric(obTICOCODI.SelectedValue) Then
                                Descripcion = ""
                            Else
                                Dim objdatos1 As New cla_TIPOCONS
                                Dim tbl1 As New DataTable

                                tbl1 = objdatos1.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(Trim(obTICODEPA.SelectedValue), Trim(obTICOMUNI.SelectedValue), Trim(obTICOCLCO.SelectedValue), Trim(obTICOCLSE.SelectedValue), Trim(obTICOCODI.SelectedValue))

                                Dim sw1, j1 As Integer

                                While j1 < tbl1.Rows.Count And sw1 = 0
                                    If Trim(obTICOCODI.SelectedValue) = Trim(tbl1.Rows(j1).Item("TICOCODI")) Then
                                        Descripcion = tbl1.Rows(j1).Item("TICOCODI")
                                        sw1 = 1
                                    Else
                                        j1 = j1 + 1
                                    End If
                                End While

                            End If
                        End If

                    End If
                End If
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_ZONAFISI_Codigo(ByVal obZOFIDEPA As Object, _
                                                             ByVal obZOFIMUNI As Object, _
                                                             ByVal obZOFICLSE As Object, _
                                                             ByVal obZOFICODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obZOFIDEPA.SelectedValue Is Nothing Then
                If Not obZOFIMUNI.SelectedValue Is Nothing Then
                    If Not obZOFICLSE.SelectedValue Is Nothing Then
                        If Not obZOFICODI.SelectedValue Is Nothing Then

                            If Not IsNumeric(obZOFICLSE.SelectedValue) AndAlso _
                               Not IsNumeric(obZOFICODI.SelectedValue) Then
                                Descripcion = ""
                            Else
                                Dim objdatos1 As New cla_ZONAFISI
                                Dim tbl1 As New DataTable

                                tbl1 = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAFISI(Trim(obZOFIDEPA.SelectedValue), Trim(obZOFIMUNI.SelectedValue), obZOFICLSE.SelectedValue, obZOFICODI.SelectedValue)

                                Dim sw1, j1 As Integer

                                While j1 < tbl1.Rows.Count And sw1 = 0
                                    If obZOFICODI.SelectedValue = tbl1.Rows(j1).Item("ZOFICODI") Then
                                        Descripcion = tbl1.Rows(j1).Item("ZOFICODI")
                                        sw1 = 1
                                    Else
                                        j1 = j1 + 1
                                    End If
                                End While
                            End If

                        End If
                    End If
                End If
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_ZOFIACTU_Codigo(ByVal obZFACDEPA As Object, _
                                                             ByVal obZFACMUNI As Object, _
                                                             ByVal obZFACCLSE As Object, _
                                                             ByVal obZFACCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obZFACDEPA.SelectedValue Is Nothing Then
                If Not obZFACMUNI.SelectedValue Is Nothing Then
                    If Not obZFACCLSE.SelectedValue Is Nothing Then
                        If Not obZFACCODI.SelectedValue Is Nothing Then

                            If Not IsNumeric(obZFACCLSE.SelectedValue) AndAlso _
                               Not IsNumeric(obZFACCODI.SelectedValue) Then
                                Descripcion = ""
                            Else
                                Dim objdatos1 As New cla_ZOFIACTU
                                Dim tbl1 As New DataTable

                                tbl1 = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_X_MANT_ZOFIACTU(Trim(obZFACDEPA.SelectedValue), Trim(obZFACMUNI.SelectedValue), obZFACCLSE.SelectedValue, obZFACCODI.SelectedValue)

                                Dim sw1, j1 As Integer

                                While j1 < tbl1.Rows.Count And sw1 = 0
                                    If obZFACCODI.SelectedValue = tbl1.Rows(j1).Item("ZFACCODI") Then
                                        Descripcion = tbl1.Rows(j1).Item("ZFACCODI")
                                        sw1 = 1
                                    Else
                                        j1 = j1 + 1
                                    End If
                                End While
                            End If

                        End If
                    End If
                End If
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_ZOECACTU_Codigo(ByVal obZEACDEPA As Object, _
                                                             ByVal obZEACMUNI As Object, _
                                                             ByVal obZEACCLSE As Object, _
                                                             ByVal obZEACCODI As Object) As String

        Try
            Dim Descripcion As String = ""

            If Not obZEACDEPA.SelectedValue Is Nothing Then
                If Not obZEACMUNI.SelectedValue Is Nothing Then
                    If Not obZEACCLSE.SelectedValue Is Nothing Then
                        If Not obZEACCODI.SelectedValue Is Nothing Then

                            If Not IsNumeric(obZEACCLSE.SelectedValue) AndAlso _
                               Not IsNumeric(obZEACCODI.SelectedValue) Then
                                Descripcion = ""
                            Else
                                Dim objdatos1 As New cla_ZOECACTU
                                Dim tbl1 As New DataTable

                                tbl1 = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_X_MANT_ZOECACTU(Trim(obZEACDEPA.SelectedValue), Trim(obZEACMUNI.SelectedValue), obZEACCLSE.SelectedValue, obZEACCODI.SelectedValue)

                                Dim sw1, j1 As Integer

                                While j1 < tbl1.Rows.Count And sw1 = 0
                                    If obZEACCODI.SelectedValue = tbl1.Rows(j1).Item("ZEACCODI") Then
                                        Descripcion = tbl1.Rows(j1).Item("ZEACCODI")
                                        sw1 = 1
                                    Else
                                        j1 = j1 + 1
                                    End If
                                End While
                            End If

                        End If
                    End If
                End If
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function

    ''' <summary>
    ''' carga la descripcion
    ''' </summary>
    Public Function fun_Buscar_Lista_Valores_DEPARTAMENTO(ByVal stDEPACODI As String) As String

        Try

            ' Converte un valor nothing en null para ejecutar la consulta
            If stDEPACODI Is Nothing Then
                stDEPACODI = ""
            End If

            Dim objdatos2 As New cla_DEPARTAMENTO
            Dim tbl As New DataTable
            Dim Descripcion As String = ""

            tbl = objdatos2.fun_Buscar_CODIGO_MANT_DEPARTAMENTO(Trim(stDEPACODI))

            Dim sw, j As Integer

            While j < tbl.Rows.Count And sw = 0
                If Trim(stDEPACODI) = Trim(tbl.Rows(j).Item("DEPACODI")) Then
                    Descripcion = tbl.Rows(j).Item("DEPADESC")
                    sw = 1
                Else
                    j = j + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_MUNICIPIO(ByVal stMUNIDEPA As String, _
                                                       ByVal stMUNICODI As String) As String

        Try
            ' Converte un valor nothing en null para ejecutar la consulta
            If stMUNIDEPA Is Nothing Then
                stMUNIDEPA = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stMUNICODI Is Nothing Then
                stMUNICODI = ""
            End If

            Dim objdatos1 As New cla_MUNICIPIO
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_DEPARTAMENTO_Y_CODIGO_MANT_MUNICIPIO(Trim(stMUNIDEPA), Trim(stMUNICODI))

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stMUNICODI) = Trim(tbl1.Rows(j1).Item("MUNICODI")) Then
                    Descripcion = tbl1.Rows(j1).Item("MUNIDESC")
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_PLAN_PARCIAL(ByVal stPLPANURE As String, _
                                                          ByVal stPLPAFERE As String) As String

        Try
            ' Converte un valor nothing en null para ejecutar la consulta
            If stPLPANURE Is Nothing Then
                stPLPANURE = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stPLPAFERE Is Nothing Then
                stPLPAFERE = ""
            End If

            Dim objdatos1 As New cla_PLANPARC
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_CODIGO_PLANPARC(Trim(stPLPANURE), Trim(stPLPAFERE))

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stPLPANURE) = Trim(tbl1.Rows(j1).Item("PLPANURE")) And _
                     Trim(stPLPAFERE) = Trim(tbl1.Rows(j1).Item("PLPAFERE")) Then

                    Descripcion = tbl1.Rows(j1).Item("PLPADESC")
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_COMUNA(ByVal stCOMUDEPA As String, _
                                                    ByVal stCOMUMUNI As String, _
                                                    ByVal stCOMUCLSE As String, _
                                                    ByVal stCOMUCODI As String) As String

        Try
            ' Converte un valor nothing en null para ejecutar la consulta
            If stCOMUDEPA Is Nothing Then
                stCOMUDEPA = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stCOMUMUNI Is Nothing Then
                stCOMUMUNI = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stCOMUCLSE Is Nothing Then
                stCOMUCLSE = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stCOMUCODI Is Nothing Then
                stCOMUCODI = ""
            End If

            Dim objdatos1 As New cla_COMUNA
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_COMU_X_COMUNA(Trim(stCOMUDEPA), Trim(stCOMUMUNI), Trim(stCOMUCLSE), Trim(stCOMUCODI))

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stCOMUCODI) = Trim(tbl1.Rows(j1).Item("COMUCODI")) Then
                    Descripcion = tbl1.Rows(j1).Item("COMUDESC")
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CORREGIMIENTO(ByVal stCORRDEPA As String, _
                                                           ByVal stCORRMUNI As String, _
                                                           ByVal stCORRCLSE As String, _
                                                           ByVal stCORRCODI As String) As String

        Try
            ' Converte un valor nothing en null para ejecutar la consulta
            If stCORRDEPA Is Nothing Then
                stCORRDEPA = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stCORRMUNI Is Nothing Then
                stCORRMUNI = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stCORRCLSE Is Nothing Then
                stCORRCLSE = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stCORRCODI Is Nothing Then
                stCORRCODI = ""
            End If

            Dim objdatos1 As New cla_CORREGIMIENTO
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_X_CORREGIMIENTO(Trim(stCORRDEPA), Trim(stCORRMUNI), Trim(stCORRCLSE), Trim(stCORRCODI))

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stCORRCODI) = Trim(tbl1.Rows(j1).Item("CORRCODI")) Then
                    Descripcion = tbl1.Rows(j1).Item("CORRDESC")
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_BARRIO(ByVal stBAVEDEPA As String, _
                                                    ByVal stBAVEMUNI As String, _
                                                    ByVal stBAVECLSE As String, _
                                                    ByVal stBAVEBARR As String) As String

        Try
            ' Converte un valor nothing en null para ejecutar la consulta
            If stBAVEDEPA Is Nothing Then
                stBAVEDEPA = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stBAVEMUNI Is Nothing Then
                stBAVEMUNI = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stBAVECLSE Is Nothing Then
                stBAVECLSE = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stBAVEBARR Is Nothing Then
                stBAVEBARR = ""
            End If

            Dim objdatos1 As New cla_BARRVERE
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_BAVE_X_BARRVERE(Trim(stBAVEDEPA), Trim(stBAVEMUNI), Trim(stBAVECLSE), Trim(stBAVEBARR))

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stBAVEBARR) = Trim(tbl1.Rows(j1).Item("BAVECODI")) Then
                    Descripcion = tbl1.Rows(j1).Item("BAVEDESC")
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_BARRIO(ByVal stBAVEDEPA As String, _
                                                    ByVal stBAVEMUNI As String, _
                                                    ByVal stBAVECLSE As String, _
                                                    ByVal stBAVEBARR As String, _
                                                    ByVal stBAVECORR As String) As String

        Try
            ' Converte un valor nothing en null para ejecutar la consulta
            If stBAVEDEPA Is Nothing Then
                stBAVEDEPA = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stBAVEMUNI Is Nothing Then
                stBAVEMUNI = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stBAVECLSE Is Nothing Then
                stBAVECLSE = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stBAVEBARR Is Nothing Then
                stBAVEBARR = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stBAVECORR Is Nothing Then
                stBAVECORR = ""
            End If

            Dim objdatos1 As New cla_BARRVERE
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_BAVE_X_BARRVERE(Trim(stBAVEDEPA), Trim(stBAVEMUNI), Trim(stBAVECLSE), Trim(stBAVECORR), Trim(stBAVEBARR))

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stBAVEBARR) = Trim(tbl1.Rows(j1).Item("BAVECODI")) Then
                    Descripcion = tbl1.Rows(j1).Item("BAVEDESC")
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_VEREDA(ByVal stBAVEDEPA As String, _
                                                    ByVal stBAVEMUNI As String, _
                                                    ByVal stBAVECLSE As String, _
                                                    ByVal stBAVEVERE As String) As String

        Try
            ' Converte un valor nothing en null para ejecutar la consulta
            If stBAVEDEPA Is Nothing Then
                stBAVEDEPA = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stBAVEMUNI Is Nothing Then
                stBAVEMUNI = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stBAVECLSE Is Nothing Then
                stBAVECLSE = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stBAVEVERE Is Nothing Then
                stBAVEVERE = ""
            End If

            Dim objdatos1 As New cla_BARRVERE
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_BAVE_X_BARRVERE(Trim(stBAVEDEPA), Trim(stBAVEMUNI), Trim(stBAVECLSE), Trim(stBAVEVERE))

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stBAVEVERE) = Trim(tbl1.Rows(j1).Item("BAVECODI")) Then
                    Descripcion = tbl1.Rows(j1).Item("BAVEDESC")
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_VEREDA(ByVal stBAVEDEPA As String, _
                                                   ByVal stBAVEMUNI As String, _
                                                   ByVal stBAVECLSE As String, _
                                                   ByVal stBAVEVERE As String, _
                                                   ByVal stBAVECORR As String) As String

        Try
            ' Converte un valor nothing en null para ejecutar la consulta
            If stBAVEDEPA Is Nothing Then
                stBAVEDEPA = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stBAVEMUNI Is Nothing Then
                stBAVEMUNI = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stBAVECLSE Is Nothing Then
                stBAVECLSE = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stBAVEVERE Is Nothing Then
                stBAVEVERE = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stBAVECORR Is Nothing Then
                stBAVECORR = ""
            End If

            Dim objdatos1 As New cla_BARRVERE
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_BAVE_X_BARRVERE(Trim(stBAVEDEPA), Trim(stBAVEMUNI), Trim(stBAVECLSE), Trim(stBAVECORR), Trim(stBAVEVERE))

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stBAVEVERE) = Trim(tbl1.Rows(j1).Item("BAVECODI")) Then
                    Descripcion = tbl1.Rows(j1).Item("BAVEDESC")
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CARGBENE(ByVal stCABENURE As String, _
                                                      ByVal stCABEFERE As String, _
                                                      ByVal stCABEUAU As String) As String

        Try
            ' Converte un valor nothing en null para ejecutar la consulta
            If stCABENURE Is Nothing Then
                stCABENURE = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stCABEFERE Is Nothing Then
                stCABEFERE = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stCABEUAU Is Nothing Then
                stCABEUAU = ""
            End If

            Dim objdatos1 As New cla_CARGBENE
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_CODIGO_CARGBENE(Trim(stCABENURE), Trim(stCABEFERE), Trim(stCABEUAU))

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stCABENURE) = Trim(tbl1.Rows(j1).Item("CABENURE")) And _
                    Trim(stCABEFERE) = Trim(tbl1.Rows(j1).Item("CABEFERE")) And _
                    Trim(stCABEUAU) = Trim(tbl1.Rows(j1).Item("CABEUAU")) Then

                    Descripcion = tbl1.Rows(j1).Item("CABEDESC")
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CLASCONS(ByVal stCLCOCODI As String) As String

        Try
            Dim objdatos2 As New cla_CLASCONS
            Dim tbl2 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stCLCOCODI Is Nothing Then
                stCLCOCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stCLCOCODI) Then
                Descripcion = ""
            Else
                tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_CLASCONS(stCLCOCODI)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If stCLCOCODI = tbl2.Rows(j2).Item("CLCOCODI") Then
                        Descripcion = tbl2.Rows(j2).Item("CLCODESC")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CLASENTI(ByVal stCLENCODI As String) As String

        Try
            Dim objdatos2 As New cla_CLASENTI
            Dim tbl2 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stCLENCODI Is Nothing Then
                stCLENCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Trim(stCLENCODI) = "" Then
                Descripcion = ""
            Else
                tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_CLASENTI(Trim(stCLENCODI))

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If Trim(stCLENCODI) = Trim(tbl2.Rows(j2).Item("CLENCODI")) Then
                        Descripcion = tbl2.Rows(j2).Item("CLENDESC")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CLASSECT(ByVal stCLSECODI As String) As String

        Try
            Dim objdatos2 As New cla_CLASSECT
            Dim tbl2 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stCLSECODI Is Nothing Then
                stCLSECODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stCLSECODI) Then
                Descripcion = ""
            Else
                tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_CLASSECT(stCLSECODI)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If stCLSECODI = tbl2.Rows(j2).Item("CLSECODI") Then
                        Descripcion = tbl2.Rows(j2).Item("CLSEDESC")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_ZONAPLAN(ByVal stZOPLCODI As String) As String

        Try
            Dim objdatos2 As New cla_ZONAPLAN
            Dim tbl2 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stZOPLCODI Is Nothing Then
                stZOPLCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stZOPLCODI) Then
                Descripcion = ""
            Else
                tbl2 = objdatos2.fun_Buscar_CODIGO_ZONAPLAN(stZOPLCODI)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If stZOPLCODI = tbl2.Rows(j2).Item("ZOPLCODI") Then
                        Descripcion = tbl2.Rows(j2).Item("ZOPLDESC")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CONTCOMA(ByVal stCOCOCODI As String) As String

        Try
            Dim objdatos2 As New cla_CONTCOMA
            Dim tbl2 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stCOCOCODI Is Nothing Then
                stCOCOCODI = ""
                Descripcion = ""
            Else
                tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_CONTCOMA(stCOCOCODI)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If Trim(stCOCOCODI) = Trim(tbl2.Rows(j2).Item("COCOCODI")) Then
                        Descripcion = tbl2.Rows(j2).Item("COCODESC")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CARPFOTO(ByVal stCAFOCODI As String) As String

        Try
            Dim objdatos2 As New cla_CARPFOTO
            Dim tbl2 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stCAFOCODI Is Nothing Then
                stCAFOCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stCAFOCODI) Then
                Descripcion = ""
            Else
                tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_CARPFOTO(stCAFOCODI)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If stCAFOCODI = tbl2.Rows(j2).Item("CAFOCODI") Then
                        Descripcion = tbl2.Rows(j2).Item("CAFODESC")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_PLANCART(ByVal stPLCACODI As String) As String

        Try
            Dim objdatos2 As New cla_PLANCART
            Dim tbl2 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stPLCACODI Is Nothing Then
                stPLCACODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stPLCACODI) Then
                Descripcion = ""
            Else
                tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_PLANCART(stPLCACODI)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If stPLCACODI = tbl2.Rows(j2).Item("PLCACODI") Then
                        Descripcion = tbl2.Rows(j2).Item("PLCADESC")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_FIPRDIGI(ByVal stFPDICODI As String) As String

        Try
            Dim objdatos2 As New cla_FIPRDIGI
            Dim tbl2 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stFPDICODI Is Nothing Then
                stFPDICODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stFPDICODI) Then
                Descripcion = ""
            Else
                tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_FIPRDIGI(stFPDICODI)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If stFPDICODI = tbl2.Rows(j2).Item("FPDICODI") Then
                        Descripcion = tbl2.Rows(j2).Item("FPDIDESC")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_DOCUGENE(ByVal stDOGEDEPA As String, _
                                                      ByVal stDOGEMUNI As String, _
                                                      ByVal stDOGECODI As String) As String

        Try
            Dim objdatos2 As New cla_DOCUGENE
            Dim tbl2 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stDOGEDEPA Is Nothing Then
                stDOGEDEPA = ""
            End If

            ' Converte un valor nothing en null 
            If stDOGEMUNI Is Nothing Then
                stDOGEMUNI = ""
            End If

            ' Converte un valor nothing en null 
            If stDOGECODI Is Nothing Then
                stDOGECODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stDOGECODI) Then
                Descripcion = ""
            Else
                tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_DOCUGENE(stDOGEDEPA, stDOGEMUNI, stDOGECODI)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If stDOGECODI = tbl2.Rows(j2).Item("DOGECODI") Then
                        Descripcion = tbl2.Rows(j2).Item("DOGEDESC")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_MOBILIARIO(ByVal stMOBICODI As String) As String

        Try
            Dim objdatos2 As New cla_MOBILIARIO
            Dim tbl2 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stMOBICODI Is Nothing Then
                stMOBICODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stMOBICODI) Then
                Descripcion = ""
            Else
                tbl2 = objdatos2.fun_Buscar_CODIGO_MOBILIARIO(stMOBICODI)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If stMOBICODI = tbl2.Rows(j2).Item("MOBICODI") Then
                        Descripcion = tbl2.Rows(j2).Item("MOBIDESC")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_METOINVE(ByVal stMEINCODI As String) As String

        Try
            Dim objdatos2 As New cla_METOINVE
            Dim tbl2 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stMEINCODI Is Nothing Then
                stMEINCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stMEINCODI) Then
                Descripcion = ""
            Else
                tbl2 = objdatos2.fun_Buscar_CODIGO_METOINVE(stMEINCODI)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If stMEINCODI = tbl2.Rows(j2).Item("MEINCODI") Then
                        Descripcion = tbl2.Rows(j2).Item("MEINDESC")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CLASPRED(ByVal stCLPRCODI As String) As String

        Try
            Dim objdatos2 As New cla_CLASPRED
            Dim tbl2 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stCLPRCODI Is Nothing Then
                stCLPRCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stCLPRCODI) Then
                Descripcion = ""
            Else
                tbl2 = objdatos2.fun_Buscar_CODIGO_CLASPRED(stCLPRCODI)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If stCLPRCODI = tbl2.Rows(j2).Item("CLPRCODI") Then
                        Descripcion = tbl2.Rows(j2).Item("CLPRDESC")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CALIPROP(ByVal stCAPRCODI As String) As String

        Try
            Dim objdatos1 As New cla_CALIPROP
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stCAPRCODI Is Nothing Then
                stCAPRCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stCAPRCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_CALIPROP(stCAPRCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stCAPRCODI = tbl1.Rows(j1).Item("CAPRCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("CAPRDESC")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CATEPRED(ByVal stCAPRCODI As String) As String

        Try
            Dim objdatos1 As New cla_CATEPRED
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stCAPRCODI Is Nothing Then
                stCAPRCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stCAPRCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_CATEPRED(stCAPRCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stCAPRCODI = tbl1.Rows(j1).Item("CAPRCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("CAPRDESC")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CARAPRED(ByVal stCAPRCODI As String) As String

        Try
            Dim objdatos1 As New cla_CARAPRED
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null
            If stCAPRCODI Is Nothing Then
                stCAPRCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stCAPRCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_CARAPRED(stCAPRCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stCAPRCODI = tbl1.Rows(j1).Item("CAPRCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("CAPRDESC")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CATESUEL(ByVal stCASUCODI As String) As String

        Try
            Dim objdatos1 As New cla_CATESUEL
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stCASUCODI Is Nothing Then
                stCASUCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stCASUCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_CATESUEL(stCASUCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stCASUCODI = tbl1.Rows(j1).Item("CASUCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("CASUDESC")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_DESTECON(ByVal stDEECCODI As String) As String

        Try
            Dim objdatos1 As New cla_DESTECON
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stDEECCODI Is Nothing Then
                stDEECCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stDEECCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_DESTECON(stDEECCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stDEECCODI = tbl1.Rows(j1).Item("DEECCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("DEECDESC")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_MODOADQU(ByVal stMOADCODI As String) As String

        Try
            Dim objdatos1 As New cla_MODOADQU
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stMOADCODI Is Nothing Then
                stMOADCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stMOADCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_MODOADQU(stMOADCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stMOADCODI = tbl1.Rows(j1).Item("MOADCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("MOADDESC")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_NOTARIA(ByVal stNOTADEPA As String, _
                                                     ByVal stNOTAMUNI As String, _
                                                     ByVal stNOTANOTA As String) As String

        Try
            ' Converte un valor nothing en null para ejecutar la consulta
            If stNOTADEPA Is Nothing Then
                stNOTADEPA = ""
            End If

            If stNOTAMUNI Is Nothing Then
                stNOTAMUNI = ""
            End If

            If stNOTANOTA Is Nothing Then
                stNOTANOTA = ""
            End If

            Dim objdatos1 As New cla_NOTARIA
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_NOTARIA(Trim(stNOTADEPA), Trim(stNOTAMUNI), Trim(stNOTANOTA))

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stNOTANOTA) = Trim(tbl1.Rows(j1).Item("NOTACODI")) Then
                    Descripcion = tbl1.Rows(j1).Item("NOTADESC")
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_SEXO(ByVal stSEXOCODI As String) As String

        Try
            Dim objdatos1 As New cla_SEXO
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null para ejecutar la consulta
            If stSEXOCODI Is Nothing Then
                stSEXOCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stSEXOCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_SEXO(stSEXOCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stSEXOCODI = tbl1.Rows(j1).Item("SEXOCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("SEXODESC")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_PUNTCARD(ByVal stPUCACODI As String) As String

        Try
            ' Converte un valor nothing en null para ejecutar la consulta
            If stPUCACODI Is Nothing Then
                stPUCACODI = ""
            End If

            Dim objdatos1 As New cla_PUNTCARD
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_PUNTCARD(stPUCACODI)

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stPUCACODI) = Trim(tbl1.Rows(j1).Item("PUCACODI")) Then
                    Descripcion = tbl1.Rows(j1).Item("PUCADESC")
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_TIPOCONS(ByVal stTICODEPA As String, _
                                                      ByVal stTICOMUNI As String, _
                                                      ByVal stTICOCLCO As String, _
                                                      ByVal stTICOCLSE As String, _
                                                      ByVal stTICOCODI As String) As String

        Try
            Dim objdatos1 As New cla_TIPOCONS
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stTICODEPA Is Nothing Then
                stTICODEPA = ""
            End If

            If stTICOMUNI Is Nothing Then
                stTICOMUNI = ""
            End If

            If stTICOCLCO Is Nothing Then
                stTICOCLCO = ""
            End If

            If stTICOCLSE Is Nothing Then
                stTICOCLSE = ""
            End If

            If stTICOCODI Is Nothing Then
                stTICOCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stTICOCLCO) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(Trim(stTICODEPA), Trim(stTICOMUNI), Trim(stTICOCLCO), Trim(stTICOCLSE), Trim(stTICOCODI))

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stTICOCODI = tbl1.Rows(j1).Item("TICOCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("TICODESC")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_TIPOCALI(ByVal stTICACODI As String) As String

        Try
            ' Converte un valor nothing en null para ejecutar la consulta
            If stTICACODI Is Nothing Then
                stTICACODI = ""
            End If

            Dim objdatos1 As New cla_TIPOCALI
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_TIPOCALI(stTICACODI)

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stTICACODI) = Trim(tbl1.Rows(j1).Item("TICACODI")) Then
                    Descripcion = tbl1.Rows(j1).Item("TICADESC")
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_TIPODOCU(ByVal stTIDOCODI As String) As String

        Try
            Dim objdatos1 As New cla_TIPODOCU
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stTIDOCODI Is Nothing Then
                stTIDOCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stTIDOCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_TIPODOCU(stTIDOCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stTIDOCODI = tbl1.Rows(j1).Item("TIDOCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("TIDODESC")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_TIPORESO(ByVal stTIRECODI As String) As String

        Try
            Dim objdatos1 As New cla_TIPORESO
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stTIRECODI Is Nothing Then
                stTIRECODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stTIRECODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_TIPORESO(stTIRECODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stTIRECODI = tbl1.Rows(j1).Item("TIRECODI") Then
                        Descripcion = tbl1.Rows(j1).Item("TIREDESC")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_NOVEDAD(ByVal stNOVECODI As String) As String

        Try
            Dim objdatos1 As New cla_NOVEDAD
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stNOVECODI Is Nothing Then
                stNOVECODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stNOVECODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_NOVEDAD(stNOVECODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stNOVECODI = tbl1.Rows(j1).Item("NOVECODI") Then
                        Descripcion = tbl1.Rows(j1).Item("NOVEDESC")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_ZONAECON(ByVal stZOECDEPA As String, _
                                                      ByVal stZOECMUNI As String, _
                                                      ByVal stZOECCLSE As String, _
                                                      ByVal stZOECCODI As String) As String

        Try
            Dim objdatos1 As New cla_ZONAECON
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null
            If stZOECDEPA Is Nothing Then
                stZOECDEPA = ""
            End If

            If stZOECMUNI Is Nothing Then
                stZOECMUNI = ""
            End If

            If stZOECCLSE Is Nothing Then
                stZOECCLSE = ""
            End If

            If stZOECCODI Is Nothing Then
                stZOECCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stZOECCLSE) AndAlso _
               Not IsNumeric(stZOECCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAECON(Trim(stZOECDEPA), Trim(stZOECMUNI), stZOECCLSE, stZOECCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stZOECCODI = tbl1.Rows(j1).Item("ZOECCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("ZOECDESC")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_BARRVERE(ByVal stBAVEDEPA As String, _
                                                      ByVal stBAVEMUNI As String, _
                                                      ByVal stBAVECLSE As String, _
                                                      ByVal stBAVECODI As String) As String

        Try
            Dim objdatos1 As New cla_BARRVERE
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null
            If stBAVEDEPA Is Nothing Then
                stBAVEDEPA = ""
            End If

            If stBAVEMUNI Is Nothing Then
                stBAVEMUNI = ""
            End If

            If stBAVECLSE Is Nothing Then
                stBAVECLSE = ""
            End If

            If stBAVECODI Is Nothing Then
                stBAVECODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stBAVECLSE) AndAlso _
               Not IsNumeric(stBAVECODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_BAVE_X_BARRVERE(Trim(stBAVEDEPA), Trim(stBAVEMUNI), stBAVECLSE, stBAVECODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stBAVECODI = tbl1.Rows(j1).Item("BAVECODI") Then
                        Descripcion = tbl1.Rows(j1).Item("BAVEDESC")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_ZONAFISI(ByVal stZOFIDEPA As String, _
                                                      ByVal stZOFIMUNI As String, _
                                                      ByVal stZOFICLSE As String, _
                                                      ByVal stZOFICODI As String) As String

        Try
            Dim objdatos1 As New cla_ZONAFISI
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stZOFIDEPA Is Nothing Then
                stZOFIDEPA = ""
            End If

            If stZOFIMUNI Is Nothing Then
                stZOFIMUNI = ""
            End If

            If stZOFICLSE Is Nothing Then
                stZOFICLSE = ""
            End If

            If stZOFICODI Is Nothing Then
                stZOFICODI = ""
            End If


            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stZOFICODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAFISI(stZOFIDEPA, stZOFIMUNI, stZOFICLSE, stZOFICODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stZOFICODI = tbl1.Rows(j1).Item("ZOFICODI") Then
                        Descripcion = tbl1.Rows(j1).Item("ZOFIDESC")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CODICALI(ByVal stCOCACODI As String) As String

        Try
            Dim objdatos1 As New cla_CODICALI
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stCOCACODI Is Nothing Then
                stCOCACODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stCOCACODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_CODICALI(stCOCACODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stCOCACODI = tbl1.Rows(j1).Item("COCACODI") Then
                        Descripcion = tbl1.Rows(j1).Item("COCADESC")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CODICALI_COCACOPA(ByVal stCOCACODI As String) As String

        Try
            Dim objdatos1 As New cla_CODICALI
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stCOCACODI Is Nothing Then
                stCOCACODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stCOCACODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_CODICALI(stCOCACODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stCOCACODI = tbl1.Rows(j1).Item("COCACODI") Then
                        Descripcion = tbl1.Rows(j1).Item("COCACOPA")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CODICALI_COCACOHI(ByVal stCOCACODI As String) As String

        Try
            Dim objdatos1 As New cla_CODICALI
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stCOCACODI Is Nothing Then
                stCOCACODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stCOCACODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_CODICALI(stCOCACODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stCOCACODI = tbl1.Rows(j1).Item("COCACODI") Then
                        Descripcion = tbl1.Rows(j1).Item("COCACOHI")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CODICACO(ByVal stCOCCCODI As String, _
                                                      ByVal stCOCCTIPO As String)

        Try
            Dim objdatos1 As New cla_CODICACO
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null
            If stCOCCCODI Is Nothing Then
                stCOCCCODI = ""
            End If

            If stCOCCTIPO Is Nothing Then
                stCOCCTIPO = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stCOCCCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_CODICACO(stCOCCCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stCOCCCODI = tbl1.Rows(j1).Item("COCCCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("COCCDESC")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try


    End Function
    Public Function fun_Buscar_Lista_Valores_VIGENCIA(ByVal stVIGECODI As String) As String

        Try
            Dim objdatos1 As New cla_VIGENCIA
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stVIGECODI Is Nothing Then
                stVIGECODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stVIGECODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_VIGENCIA(stVIGECODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stVIGECODI = tbl1.Rows(j1).Item("VIGECODI") Then
                        Descripcion = tbl1.Rows(j1).Item("VIGEDESC")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try


    End Function
    Public Function fun_Buscar_Lista_Valores_RESOLUCION(ByVal stRESODEPA As String, _
                                                        ByVal stRESOMUNI As String, _
                                                        ByVal stRESOTIRE As String, _
                                                        ByVal stRESOCLSE As String, _
                                                        ByVal stRESOVIGE As String, _
                                                        ByVal stRESOCODI As String) As String

        Try
            ' Converte un valor nothing en null para ejecutar la consulta
            If stRESODEPA Is Nothing Then
                stRESODEPA = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stRESOMUNI Is Nothing Then
                stRESOMUNI = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stRESOTIRE Is Nothing Then
                stRESOTIRE = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stRESOCLSE Is Nothing Then
                stRESOCLSE = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stRESOVIGE Is Nothing Then
                stRESOVIGE = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stRESOCODI Is Nothing Then
                stRESOCODI = ""
            End If

            Dim objdatos1 As New cla_RESOLUCION
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_TIPO_Y_CLASE_Y_VIGENCIA_Y_CODIGO_RESOLUCION(stRESODEPA, stRESOMUNI, stRESOTIRE, stRESOCLSE, stRESOVIGE, stRESOCODI)

            If tbl1.Rows.Count > 0 Then
                Descripcion = tbl1.Rows(0).Item("RESODESC")
            Else
                Descripcion = ""
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_FORMULARIO(ByVal stFORMCODI As String) As String

        Try

            ' Converte un valor nothing en null para ejecutar la consulta
            If stFORMCODI Is Nothing Then
                stFORMCODI = ""
            End If

            Dim objdatos2 As New cla_PERMFORM
            Dim tbl As New DataTable
            Dim Descripcion As String = ""

            tbl = objdatos2.fun_Buscar_CODIGO_PERMFORM(Trim(stFORMCODI))

            Dim sw, j As Integer

            While j < tbl.Rows.Count And sw = 0
                If Trim(stFORMCODI) = Trim(tbl.Rows(j).Item("PEFOFORM")) Then
                    Descripcion = tbl.Rows(j).Item("PEFODESC")
                    sw = 1
                Else
                    j = j + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_SUBFORMULARIO(ByVal stSUFOCODI As String) As String

        Try

            ' Converte un valor nothing en null para ejecutar la consulta
            If stSUFOCODI Is Nothing Then
                stSUFOCODI = ""
            End If

            Dim objdatos2 As New cla_PERMSUFO
            Dim tbl As New DataTable
            Dim Descripcion As String = ""

            tbl = objdatos2.fun_Buscar_CODIGO_PERMSUFO(Trim(stSUFOCODI))

            Dim sw, j As Integer

            While j < tbl.Rows.Count And sw = 0
                If Trim(stSUFOCODI) = Trim(tbl.Rows(j).Item("PESFFORM")) Then
                    Descripcion = tbl.Rows(j).Item("PESFDESC")
                    sw = 1
                Else
                    j = j + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_ETIQUETAS(ByVal stETIQCODI As String) As String

        Try

            ' Converte un valor nothing en null para ejecutar la consulta
            If stETIQCODI Is Nothing Then
                stETIQCODI = ""
            End If

            Dim objdatos2 As New cla_PERMETIQ
            Dim tbl As New DataTable
            Dim Descripcion As String = ""

            tbl = objdatos2.fun_Buscar_CODIGO_PERMETIQ(Trim(stETIQCODI))

            Dim sw, j As Integer

            While j < tbl.Rows.Count And sw = 0
                If Trim(stETIQCODI) = Trim(tbl.Rows(j).Item("PEETETIQ")) Then
                    Descripcion = tbl.Rows(j).Item("PEETDESC")
                    sw = 1
                Else
                    j = j + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_ESTRATO(ByVal stESTRCODI As String) As String

        Try
            Dim objdatos1 As New cla_ESTRATO
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stESTRCODI Is Nothing Then
                stESTRCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stESTRCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_ESTRATO(stESTRCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stESTRCODI = tbl1.Rows(j1).Item("ESTRCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("ESTRDESC")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try


    End Function
    Public Function fun_Buscar_Lista_Valores_CONCEPTO(ByVal stCONCTIIM As String, ByVal stCONCCODI As String) As String

        Try
            Dim objdatos1 As New cla_CONCEPTO
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stCONCTIIM Is Nothing Then
                stCONCTIIM = ""
            End If

            ' Converte un valor nothing en null 
            If stCONCCODI Is Nothing Then
                stCONCCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stCONCTIIM) And Not IsNumeric(stCONCCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_CONCEPTO(stCONCTIIM, stCONCCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If Trim(stCONCCODI) = Trim(tbl1.Rows(j1).Item("CONCCODI")) Then
                        Descripcion = tbl1.Rows(j1).Item("CONCDESC")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_VARIABLE(ByVal stVARITIVA As String, ByVal stVARICODI As String) As String

        Try
            Dim objdatos1 As New cla_VARIABLE
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stVARITIVA Is Nothing Then
                stVARITIVA = ""
            End If

            ' Converte un valor nothing en null 
            If stVARICODI Is Nothing Then
                stVARICODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stVARITIVA) And Not IsNumeric(stVARICODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_VARIABLE(stVARITIVA, stVARICODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If Trim(stVARICODI) = Trim(tbl1.Rows(j1).Item("VARICODI")) Then
                        Descripcion = tbl1.Rows(j1).Item("VARIDESC")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_TIPOIMPU(ByVal stTIIMCODI As String) As String

        Try

            ' Converte un valor nothing en null para ejecutar la consulta
            If stTIIMCODI Is Nothing Then
                stTIIMCODI = ""
            End If

            Dim objdatos2 As New cla_TIPOIMPU
            Dim tbl As New DataTable
            Dim Descripcion As String = ""

            tbl = objdatos2.fun_Buscar_CODIGO_MANT_TIPOIMPU(Trim(stTIIMCODI))

            Dim sw, j As Integer

            While j < tbl.Rows.Count And sw = 0
                If Trim(stTIIMCODI) = Trim(tbl.Rows(j).Item("TIIMCODI")) Then
                    Descripcion = tbl.Rows(j).Item("TIIMDESC")
                    sw = 1
                Else
                    j = j + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_TIPOVARI(ByVal stTIVACODI As String) As String

        Try

            ' Converte un valor nothing en null para ejecutar la consulta
            If stTIVACODI Is Nothing Then
                stTIVACODI = ""
            End If

            Dim objdatos2 As New cla_TIPOVARI
            Dim tbl As New DataTable

            Dim Descripcion As String = ""

            tbl = objdatos2.fun_Buscar_CODIGO_MANT_TIPOVARI(Trim(stTIVACODI))

            Dim sw, j As Integer

            While j < tbl.Rows.Count And sw = 0
                If Trim(stTIVACODI) = Trim(tbl.Rows(j).Item("TIVACODI")) Then
                    Descripcion = tbl.Rows(j).Item("TIVADESC")
                    sw = 1
                Else
                    j = j + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_PROYECTO(ByVal stPROYDEPA As String, _
                                                      ByVal stPROYMUNI As String, _
                                                      ByVal stPROYCLSE As String, _
                                                      ByVal stPROYCODI As String) As String

        Try

            ' Converte un valor nothing en null para ejecutar la consulta
            If stPROYDEPA Is Nothing Then
                stPROYDEPA = ""
            End If

            If stPROYMUNI Is Nothing Then
                stPROYMUNI = ""
            End If

            If stPROYCLSE Is Nothing Then
                stPROYCLSE = ""
            End If

            If stPROYCODI Is Nothing Then
                stPROYCODI = ""
            End If

            Dim objdatos2 As New cla_PROYECTO
            Dim tbl As New DataTable

            Dim Descripcion As String = ""

            tbl = objdatos2.fun_Buscar_CODIGO_PROYECTO(Trim(stPROYDEPA), Trim(stPROYMUNI), Trim(stPROYCLSE), Trim(stPROYCODI))

            Dim sw, j As Integer

            While j < tbl.Rows.Count And sw = 0
                If Trim(stPROYCODI) = Trim(tbl.Rows(j).Item("PROYCODI")) Then
                    Descripcion = tbl.Rows(j).Item("PROYDESC")
                    sw = 1
                Else
                    j = j + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_FORMULA(ByVal stFORMCODI As String) As String

        Try

            ' Converte un valor nothing en null para ejecutar la consulta
            If stFORMCODI Is Nothing Then
                stFORMCODI = ""
            End If

            Dim objdatos2 As New cla_FORMULA
            Dim tbl As New DataTable
            Dim Descripcion As String = ""

            tbl = objdatos2.fun_Buscar_CODIGO_FORMULA(Trim(stFORMCODI))

            Dim sw, j As Integer

            While j < tbl.Rows.Count And sw = 0
                If Trim(stFORMCODI) = Trim(tbl.Rows(j).Item("FORMCODI")) Then
                    Descripcion = tbl.Rows(j).Item("FORMDESC")
                    sw = 1
                Else
                    j = j + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CAUSACTO(ByVal stCAACCODI As String) As String

        Try
            ' Converte un valor nothing en null 
            If stCAACCODI Is Nothing Then
                stCAACCODI = ""
            End If

            Dim objdatos1 As New cla_CAUSACTO
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_CAUSACTO(stCAACCODI)

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stCAACCODI) = Trim(tbl1.Rows(j1).Item("CAACCODI")) Then
                    Descripcion = tbl1.Rows(j1).Item("CAACDESC")
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CLASVERS(ByVal stCLVECODI As String) As String

        Try
            ' Converte un valor nothing en null 
            If stCLVECODI Is Nothing Then
                stCLVECODI = ""
            End If

            Dim objdatos1 As New cla_CLASVERS
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_CLASVERS(stCLVECODI)

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stCLVECODI) = Trim(tbl1.Rows(j1).Item("CLVECODI")) Then
                    Descripcion = tbl1.Rows(j1).Item("CLVEDESC")
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_ESTADO(ByVal stESTACODI As String) As String

        Try
            ' Converte un valor nothing en null 
            If stESTACODI Is Nothing Then
                stESTACODI = ""
            End If

            Dim objdatos1 As New cla_ESTADO
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Consultar_TODOS_LOS_ESTADOS

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stESTACODI) = Trim(tbl1.Rows(j1).Item("ESTACODI")) Then
                    Descripcion = tbl1.Rows(j1).Item("ESTADESC")
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_MODOLIQU(ByVal stMOLICODI As String) As String

        Try
            Dim objdatos1 As New cla_MODOLIQU
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stMOLICODI Is Nothing Then
                stMOLICODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stMOLICODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_MODOLIQU(stMOLICODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If Trim(stMOLICODI) = tbl1.Rows(j1).Item("MOLICODI") Then
                        Descripcion = Trim(tbl1.Rows(j1).Item("MOLIDESC"))
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_TIPOAFOR(ByVal stTIAFCODI As String) As String

        Try
            Dim objdatos1 As New cla_TIPOAFOR
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stTIAFCODI Is Nothing Then
                stTIAFCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stTIAFCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_TIPOAFOR(stTIAFCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If Trim(stTIAFCODI) = tbl1.Rows(j1).Item("TIAFCODI") Then
                        Descripcion = Trim(tbl1.Rows(j1).Item("TIAFDESC"))
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_TIPOTRAM(ByVal stTITRCODI As String) As String

        Try
            Dim objdatos1 As New cla_TIPOTRAM
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stTITRCODI Is Nothing Then
                stTITRCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stTITRCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_TIPOTRAM(stTITRCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If Trim(stTITRCODI) = tbl1.Rows(j1).Item("TITRCODI") Then
                        Descripcion = Trim(tbl1.Rows(j1).Item("TITRDESC"))
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_SOLICITANTE(ByVal stSOLICODI As String) As String

        Try
            Dim objdatos1 As New cla_SOLICITANTE
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stSOLICODI Is Nothing Then
                stSOLICODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stSOLICODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_SOLICITANTE(stSOLICODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If Trim(stSOLICODI) = tbl1.Rows(j1).Item("SOLICODI") Then
                        Descripcion = Trim(tbl1.Rows(j1).Item("SOLIDESC"))
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_ACTOADMI(ByVal stACADCODI As String) As String

        Try
            Dim objdatos1 As New cla_ACTOADMI
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stACADCODI Is Nothing Then
                stACADCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stACADCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_ACTOADMI(stACADCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If Trim(stACADCODI) = tbl1.Rows(j1).Item("ACADCODI") Then
                        Descripcion = Trim(tbl1.Rows(j1).Item("ACADDESC"))
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_PROCEDIMIENTO(ByVal stPROCCODI As String) As String

        Try

            ' Converte un valor nothing en null para ejecutar la consulta
            If stPROCCODI Is Nothing Then
                stPROCCODI = ""
            End If

            Dim objdatos2 As New cla_PROCEDIMIENTO
            Dim tbl As New DataTable
            Dim Descripcion As String = ""

            tbl = objdatos2.fun_Buscar_CODIGO_PROCEDIMIENTO(Trim(stPROCCODI))

            Dim sw, j As Integer

            While j < tbl.Rows.Count And sw = 0
                If Trim(stPROCCODI) = Trim(tbl.Rows(j).Item("PROCCODI")) Then
                    Descripcion = tbl.Rows(j).Item("PROCDESC")
                    sw = 1
                Else
                    j = j + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_TABLAS(ByVal stTABLCODI As String) As String

        Try

            ' Converte un valor nothing en null para ejecutar la consulta
            If stTABLCODI Is Nothing Then
                stTABLCODI = ""
            End If

            Dim objdatos2 As New cla_TABLAS
            Dim tbl As New DataTable
            Dim Descripcion As String = ""

            tbl = objdatos2.fun_Buscar_CODIGO_MANT_TABLAS(Trim(stTABLCODI))

            Dim sw, j As Integer

            While j < tbl.Rows.Count And sw = 0
                If Trim(stTABLCODI) = Trim(tbl.Rows(j).Item("TABLCODI")) Then
                    Descripcion = tbl.Rows(j).Item("TABLDESC")
                    sw = 1
                Else
                    j = j + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_USUARIO(ByVal stUSUANUDO As String) As String

        Try
            ' Converte un valor nothing en null 
            If stUSUANUDO Is Nothing Then
                stUSUANUDO = ""
            End If

            Dim objdatos1 As New cla_USUARIO
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_CODIGO_USUARIO(Trim(stUSUANUDO))

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stUSUANUDO) = Trim(tbl1.Rows(j1).Item("USUANUDO")) Then
                    Descripcion = Trim(tbl1.Rows(j1).Item("USUANOMB")) & " " & Trim(tbl1.Rows(j1).Item("USUAPRAP")) & " " & Trim(tbl1.Rows(j1).Item("USUASEAP"))
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_NOMBRE_X_USUARIO(ByVal stCONTUSUA As String) As String

        Try
            ' declara la variable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stCONTUSUA Is Nothing Then
                stCONTUSUA = ""
            End If

            ' declara la instancia
            Dim obCONTRASENA As New cla_CONTRASENA
            Dim dtCONTRASENA As New DataTable

            dtCONTRASENA = obCONTRASENA.fun_Buscar_USUARIO_CONTRASENA(Trim(stCONTUSUA))

            If dtCONTRASENA.Rows.Count > 0 Then

                ' declara la variable
                Dim stUSUANUDO As String = CStr(Trim(dtCONTRASENA.Rows(0).Item("CONTNUDO").ToString))

                Dim objdatos1 As New cla_USUARIO
                Dim tbl1 As New DataTable

                tbl1 = objdatos1.fun_Buscar_CODIGO_USUARIO(Trim(stUSUANUDO))

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If Trim(stUSUANUDO) = Trim(tbl1.Rows(j1).Item("USUANUDO")) Then
                        Descripcion = Trim(tbl1.Rows(j1).Item("USUANOMB")) & " " & Trim(tbl1.Rows(j1).Item("USUAPRAP")) & " " & Trim(tbl1.Rows(j1).Item("USUASEAP"))
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While

            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_CLASIFICACION(ByVal stCLASCODI As String) As String

        Try
            Dim objdatos2 As New cla_CLASIFICACION
            Dim tbl2 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stCLASCODI Is Nothing Then
                stCLASCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stCLASCODI) Then
                Descripcion = ""
            Else
                tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_CLASIFICACION(stCLASCODI)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If stCLASCODI = tbl2.Rows(j2).Item("CLASCODI") Then
                        Descripcion = tbl2.Rows(j2).Item("CLASDESC")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_MEDIRESE(ByVal stMERECODI As String) As String

        Try
            Dim objdatos2 As New cla_MEDIRESE
            Dim tbl2 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stMERECODI Is Nothing Then
                stMERECODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stMERECODI) Then
                Descripcion = ""
            Else
                tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_MEDIRESE(stMERECODI)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If stMERECODI = tbl2.Rows(j2).Item("MERECODI") Then
                        Descripcion = tbl2.Rows(j2).Item("MEREDESC")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_RESOAJUS(ByVal stREAJCODI As String) As String

        Try
            Dim objdatos2 As New cla_RESOAJUS
            Dim tbl2 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stREAJCODI Is Nothing Then
                stREAJCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stREAJCODI) Then
                Descripcion = ""
            Else
                tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_RESOAJUS(stREAJCODI)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If stREAJCODI = tbl2.Rows(j2).Item("REAJCODI") Then
                        Descripcion = tbl2.Rows(j2).Item("REAJDESC")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function

    ''' <summary>
    ''' lista los codigos para los formularios principales
    ''' </summary>
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_DEPARTAMENTO_Codigo(ByVal stDEPACODI As String) As String

        Try

            ' Converte un valor nothing en null para ejecutar la consulta
            If stDEPACODI Is Nothing Then
                stDEPACODI = ""
            End If

            Dim objdatos2 As New cla_DEPARTAMENTO
            Dim tbl As New DataTable
            Dim Descripcion As String = ""

            tbl = objdatos2.fun_Buscar_CODIGO_MANT_DEPARTAMENTO(Trim(stDEPACODI))

            Dim sw, j As Integer

            While j < tbl.Rows.Count And sw = 0
                If Trim(stDEPACODI) = Trim(tbl.Rows(j).Item("DEPACODI")) Then
                    Descripcion = tbl.Rows(j).Item("DEPACODI")
                    sw = 1
                Else
                    j = j + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_MUNICIPIO_Codigo(ByVal stMUNIDEPA As String, ByVal stMUNICODI As String) As String

        Try
            ' Converte un valor nothing en null para ejecutar la consulta
            If stMUNIDEPA Is Nothing Then
                stMUNIDEPA = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stMUNICODI Is Nothing Then
                stMUNICODI = ""
            End If

            Dim objdatos1 As New cla_MUNICIPIO
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_DEPARTAMENTO_Y_CODIGO_MANT_MUNICIPIO(Trim(stMUNIDEPA), Trim(stMUNICODI))

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stMUNICODI) = Trim(tbl1.Rows(j1).Item("MUNICODI")) Then
                    Descripcion = tbl1.Rows(j1).Item("MUNICODI")
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_VARIZOFI_Codigo(ByVal stVAZFDEPA As String, _
                                                                                  ByVal stVAZFMUNI As String, _
                                                                                  ByVal stVAZFCLSE As String, _
                                                                                  ByVal stVAZFCODI As String) As String

        Try
            ' Converte un valor nothing en null para ejecutar la consulta
            If stVAZFDEPA Is Nothing Then
                stVAZFDEPA = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stVAZFMUNI Is Nothing Then
                stVAZFMUNI = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stVAZFCLSE Is Nothing Then
                stVAZFCLSE = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stVAZFCODI Is Nothing Then
                stVAZFCODI = ""
            End If

            Dim objdatos1 As New cla_ZONAFISI
            Dim tbl1 As New DataTable

            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAFISI(Trim(stVAZFDEPA), Trim(stVAZFMUNI), Trim(stVAZFCLSE), Trim(stVAZFCODI))

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stVAZFCODI) = Trim(tbl1.Rows(j1).Item("ZOFICODI")) Then
                    Descripcion = tbl1.Rows(j1).Item("ZOFICODI")
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_VARIABLE_Codigo(ByVal stVARITIVA As String, ByVal stVARICODI As String) As String

        Try
            ' Converte un valor nothing en null para ejecutar la consulta
            If stVARITIVA Is Nothing Then
                stVARITIVA = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stVARICODI Is Nothing Then
                stVARICODI = ""
            End If

            Dim objdatos1 As New cla_VARIABLE
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_CODIGO_VARIABLE_X_TIPOVARI(Trim(stVARITIVA), Trim(stVARICODI))

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stVARICODI) = Trim(tbl1.Rows(j1).Item("VARICODI")) Then
                    Descripcion = tbl1.Rows(j1).Item("VARICODI")
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_PROYECTO_Codigo(ByVal stPROYDEPA As String, _
                                                                                  ByVal stPROYMUNI As String, _
                                                                                  ByVal stPROYCLSE As String, _
                                                                                  ByVal stPROYCODI As String) As String

        Try
            ' Converte un valor nothing en null para ejecutar la consulta
            If stPROYDEPA Is Nothing Then
                stPROYDEPA = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stPROYMUNI Is Nothing Then
                stPROYMUNI = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stPROYCLSE Is Nothing Then
                stPROYCLSE = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stPROYCODI Is Nothing Then
                stPROYCODI = ""
            End If

            Dim objdatos1 As New cla_PROYECTO
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_CODIGO_PROYECTO_X_DEPA_MUNI_CLSE_CODI(Trim(stPROYDEPA), Trim(stPROYMUNI), Trim(stPROYCLSE), Trim(stPROYCODI))

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stPROYCODI) = Trim(tbl1.Rows(j1).Item("PROYCODI")) Then
                    Descripcion = tbl1.Rows(j1).Item("PROYCODI")
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_TIPORESO_Codigo(ByVal stTIRECODI As String) As String

        Try
            Dim objdatos1 As New cla_TIPORESO
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stTIRECODI Is Nothing Then
                stTIRECODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stTIRECODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_TIPORESO(stTIRECODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stTIRECODI = tbl1.Rows(j1).Item("TIRECODI") Then
                        Descripcion = tbl1.Rows(j1).Item("TIRECODI")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_CLASSECT_Codigo(ByVal stCLSECODI As String) As String

        Try
            Dim objdatos2 As New cla_CLASSECT
            Dim tbl2 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stCLSECODI Is Nothing Then
                stCLSECODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stCLSECODI) Then
                Descripcion = ""
            Else
                tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_CLASSECT(stCLSECODI)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If stCLSECODI = tbl2.Rows(j2).Item("CLSECODI") Then
                        Descripcion = tbl2.Rows(j2).Item("CLSECODI")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_CONTCOMA_Codigo(ByVal stCOCOCODI As String) As String

        Try
            Dim objdatos2 As New cla_CONTCOMA
            Dim tbl2 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stCOCOCODI Is Nothing Then
                stCOCOCODI = ""
                Descripcion = ""
            Else
                tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_CONTCOMA(stCOCOCODI)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If stCOCOCODI = tbl2.Rows(j2).Item("COCOCODI") Then
                        Descripcion = tbl2.Rows(j2).Item("COCOCODI")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_TIPOVARI_Codigo(ByVal stTIVACODI As String) As String

        Try
            Dim objdatos2 As New cla_TIPOVARI
            Dim tbl2 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stTIVACODI Is Nothing Then
                stTIVACODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stTIVACODI) Then
                Descripcion = ""
            Else
                tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_TIPOVARI(stTIVACODI)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If stTIVACODI = tbl2.Rows(j2).Item("TIVACODI") Then
                        Descripcion = tbl2.Rows(j2).Item("TIVACODI")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_MATECAMP_Codigo(ByVal stMACACODI As String) As String

        Try
            Dim objdatos2 As New cla_MATECAMP
            Dim tbl2 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stMACACODI Is Nothing Then
                stMACACODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stMACACODI) Then
                Descripcion = ""
            Else
                tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_MATECAMP(stMACACODI)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If stMACACODI = tbl2.Rows(j2).Item("MACACODI") Then
                        Descripcion = tbl2.Rows(j2).Item("MACACODI")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_FORMULARIO_Codigo(ByVal stFORMCODI As String) As String

        Try
            Dim objdatos2 As New cla_FORMULARIO
            Dim tbl2 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stFORMCODI Is Nothing Then
                stFORMCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If IsNumeric(stFORMCODI) Then
                Descripcion = ""
            Else
                tbl2 = objdatos2.fun_Buscar_CODIGO_MANT_FORMULARIO(stFORMCODI)

                Dim sw2, j2 As Integer

                While j2 < tbl2.Rows.Count And sw2 = 0
                    If Trim(stFORMCODI) = Trim(tbl2.Rows(j2).Item("FORMCODI").ToString) Then
                        Descripcion = tbl2.Rows(j2).Item("FORMCODI")
                        sw2 = 1
                    Else
                        j2 = j2 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_VIGENCIA_Codigo(ByVal stVIGECODI As String) As String

        Try
            Dim objdatos1 As New cla_VIGENCIA
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stVIGECODI Is Nothing Then
                stVIGECODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stVIGECODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_VIGENCIA(stVIGECODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stVIGECODI = tbl1.Rows(j1).Item("VIGECODI") Then
                        Descripcion = tbl1.Rows(j1).Item("VIGECODI")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_CLASSUEL_Codigo(ByVal stCLSUCODI As String) As String

        Try
            Dim objdatos1 As New cla_CLASSUEL
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stCLSUCODI Is Nothing Then
                stCLSUCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stCLSUCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_CLASSUEL(stCLSUCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stCLSUCODI = tbl1.Rows(j1).Item("CLSUCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("CLSUCODI")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_AREAACTI_Codigo(ByVal stARACCODI As String) As String

        Try
            Dim objdatos1 As New cla_AREAACTI
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stARACCODI Is Nothing Then
                stARACCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stARACCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_AREAACTI(stARACCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stARACCODI = tbl1.Rows(j1).Item("ARACCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("ARACCODI")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_TRATURBA_Codigo(ByVal stTRURCODI As String) As String

        Try
            Dim objdatos1 As New cla_TRATURBA
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stTRURCODI Is Nothing Then
                stTRURCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stTRURCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_TRATURBA(stTRURCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stTRURCODI = tbl1.Rows(j1).Item("TRURCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("TRURCODI")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_DESTINACION_Codigo(ByVal stDESTCODI As String) As String

        Try
            Dim objdatos1 As New cla_DESTINACION
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stDESTCODI Is Nothing Then
                stDESTCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stDESTCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_DESTINACION(stDESTCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stDESTCODI = tbl1.Rows(j1).Item("DESTCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("DESTCODI")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_DESCTECON_Codigo(ByVal stDEECCODI As String) As String

        Try
            Dim objdatos1 As New cla_DESTECON
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stDEECCODI Is Nothing Then
                stDEECCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stDEECCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_DESTECON(stDEECCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stDEECCODI = tbl1.Rows(j1).Item("DEECCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("DEECCODI")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_ESTRATO_Codigo(ByVal stESTRCODI As String) As String

        Try
            Dim objdatos1 As New cla_ESTRATO
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stESTRCODI Is Nothing Then
                stESTRCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stESTRCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_ESTRATO(stESTRCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stESTRCODI = tbl1.Rows(j1).Item("ESTRCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("ESTRCODI")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_PERMFORM_Codigo(ByVal stPEFOCODI As String) As String

        Try
            Dim objdatos1 As New cla_PERMFORM
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stPEFOCODI Is Nothing Then
                stPEFOCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stPEFOCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_PERMFORM(Trim(stPEFOCODI))

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If Trim(stPEFOCODI) = Trim(tbl1.Rows(j1).Item("PEFOFORM")) Then
                        Descripcion = tbl1.Rows(j1).Item("PEFOFORM")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_SEGUDEST_Codigo(ByVal stSEDEDEST As String, ByVal stSEDECODI As String) As String

        Try
            ' Converte un valor nothing en null para ejecutar la consulta
            If stSEDEDEST Is Nothing Then
                stSEDEDEST = ""
            End If

            ' Converte un valor nothing en null para ejecutar la consulta
            If stSEDECODI Is Nothing Then
                stSEDECODI = ""
            End If

            Dim objdatos1 As New cla_SEGUDEST
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            tbl1 = objdatos1.fun_Buscar_CODIGO_SEGUDEST(Trim(stSEDEDEST), Trim(stSEDECODI))

            Dim sw1, j1 As Integer

            While j1 < tbl1.Rows.Count And sw1 = 0
                If Trim(stSEDECODI) = Trim(tbl1.Rows(j1).Item("SEDECODI")) Then
                    Descripcion = tbl1.Rows(j1).Item("SEDECODI")
                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_SERVICIOS_Codigo(ByVal stSERVCODI As String) As String

        Try
            Dim objdatos1 As New cla_SERVICIOS
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stSERVCODI Is Nothing Then
                stSERVCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stSERVCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_SERVICIOS(stSERVCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stSERVCODI = tbl1.Rows(j1).Item("SERVCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("SERVCODI")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_VIAS_Codigo(ByVal stVIASCODI As String) As String

        Try
            Dim objdatos1 As New cla_VIAS
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stVIASCODI Is Nothing Then
                stVIASCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stVIASCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_VIAS(stVIASCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stVIASCODI = tbl1.Rows(j1).Item("VIASCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("VIASCODI")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Lista_Valores_Formulario_Principal_TOPOGRAFIA_Codigo(ByVal stTOPOCODI As String) As String

        Try
            Dim objdatos1 As New cla_TOPOGRAFIA
            Dim tbl1 As New DataTable
            Dim Descripcion As String = ""

            ' Converte un valor nothing en null 
            If stTOPOCODI Is Nothing Then
                stTOPOCODI = ""
            End If

            ' Verifica que el dato sea numerico 
            If Not IsNumeric(stTOPOCODI) Then
                Descripcion = ""
            Else
                tbl1 = objdatos1.fun_Buscar_CODIGO_MANT_TOPOGRAFIA(stTOPOCODI)

                Dim sw1, j1 As Integer

                While j1 < tbl1.Rows.Count And sw1 = 0
                    If stTOPOCODI = tbl1.Rows(j1).Item("TOPOCODI") Then
                        Descripcion = tbl1.Rows(j1).Item("TOPOCODI")
                        sw1 = 1
                    Else
                        j1 = j1 + 1
                    End If
                End While
            End If

            Return Descripcion

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function

End Module
