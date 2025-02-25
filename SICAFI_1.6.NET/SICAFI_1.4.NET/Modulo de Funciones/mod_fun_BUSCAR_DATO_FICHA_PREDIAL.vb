Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports REGLAS_DEL_NEGOCIO

Module mod_fun_BUSCAR_DATO_FICHA_PREDIAL

    '======================================================================================
    'Buscar los datos que se cargan los combobox de acuerdo con la información del registro
    'y devuelve un valor boleano, para porder cargase el formulario insertar o modificar. 
    '======================================================================================

    Public Function fun_Buscar_Dato_DEPARTAMENTO(ByVal stDEPACODI As String) As Boolean

        Try
            Dim objdatos As New cla_DEPARTAMENTO
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_DEPARTAMENTO(Trim(stDEPACODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_MUNICIPIO(ByVal stMUNIDEPA As String, _
                                              ByVal stMUNICODI As String) As Boolean

        Try
            Dim objdatos As New cla_MUNICIPIO
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_DEPARTAMENTO_Y_CODIGO_MANT_MUNICIPIO(Trim(stMUNIDEPA), Trim(stMUNICODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_ZONAFISI(ByVal stZOFIDEPA As String, _
                                             ByVal stZOFIMUNI As String, _
                                             ByVal stZOFICLSE As String, _
                                             ByVal stZONACODI As String) As Boolean

        Try
            Dim objdatos As New cla_ZONAFISI
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_SECTOR_Y_CODIGO_MANT_ZONAFISI(Trim(stZOFIDEPA), Trim(stZOFIMUNI), Trim(stZOFICLSE), Trim(stZONACODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_CORREGIMIENTO(ByVal stMUNIDEPA As String, _
                                                  ByVal stMUNICODI As String, _
                                                  ByVal stMUNICLSE As String, _
                                                  ByVal stMUNICORR As String) As Boolean

        Try
            Dim objdatos As New cla_CORREGIMIENTO
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_X_CORREGIMIENTO(Trim(stMUNIDEPA), Trim(stMUNICODI), Trim(stMUNICLSE), Trim(stMUNICORR))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_CLASCONS(ByVal stCLCOCODI As String) As Boolean

        Try
            Dim objdatos As New cla_CLASCONS
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_CLASCONS(Trim(stCLCOCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_CLASSECT(ByVal stCLSECODI As String) As Boolean

        Try
            Dim objdatos As New cla_CLASSECT
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_CLASSECT(Trim(stCLSECODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_CLASVERS(ByVal stCLVECODI As String) As Boolean

        Try
            Dim objdatos As New cla_CLASVERS
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_CLASVERS(Trim(stCLVECODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_USUARIO(ByVal stUSUACODI As String) As Boolean

        Try
            Dim objdatos As New cla_USUARIO
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_USUARIO(Trim(stUSUACODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_USUARIO_X_CONTRASENA(ByVal stCONTUSUA As String) As Boolean

        Try
            Dim objdatos As New cla_CONTRASENA
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_USUARIO_CONTRASENA(Trim(stCONTUSUA))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_CLASSUEL(ByVal stCLSUCODI As String) As Boolean

        Try
            Dim objdatos As New cla_CLASSUEL
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_CLASSUEL(Trim(stCLSUCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_AREAACTI(ByVal stARACCODI As String) As Boolean

        Try
            Dim objdatos As New cla_AREAACTI
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_AREAACTI(Trim(stARACCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_TRATURBA(ByVal stTRURCODI As String) As Boolean

        Try
            Dim objdatos As New cla_TRATURBA
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_TRATURBA(Trim(stTRURCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_CALIPROP(ByVal stCAPRCODI As String) As Boolean

        Try
            Dim objdatos As New cla_CALIPROP
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_CALIPROP(Trim(stCAPRCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_CONTCOMA(ByVal stCOCOCODI As String) As Boolean

        Try
            Dim objdatos As New cla_CONTCOMA
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_CONTCOMA(Trim(stCOCOCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_CARAPRED(ByVal stCAPRCODI As String) As Boolean

        Try
            Dim objdatos As New cla_CARAPRED
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_CARAPRED(Trim(stCAPRCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_CATESUEL(ByVal stCASUCODI As String) As Boolean

        Try
            Dim objdatos As New cla_CATESUEL
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_CATESUEL(Trim(stCASUCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_DESTECON(ByVal stDEECCODI As String) As Boolean

        Try
            Dim objdatos As New cla_DESTECON
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_DESTECON(Trim(stDEECCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_MODOADQU(ByVal stMOADCODI As String) As Boolean

        Try
            Dim objdatos As New cla_MODOADQU
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_MODOADQU(Trim(stMOADCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_NOTARIA(ByVal stNOTADEPA As String, _
                                            ByVal stNOTAMUNI As String, _
                                            ByVal stNOTANOTA As String) As Boolean

        Try

            If Not stNOTADEPA Is Nothing And _
               Not stNOTAMUNI Is Nothing And _
               Not stNOTANOTA Is Nothing Then

                Dim objdatos As New cla_NOTARIA
                Dim tbl As New DataTable

                tbl = objdatos.fun_Buscar_CODIGO_MANT_NOTARIA(stNOTADEPA, stNOTAMUNI, stNOTANOTA)

                If tbl.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_SEXO(ByVal stSEXOCODI As String) As Boolean

        Try
            Dim objdatos As New cla_SEXO
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_SEXO(Trim(stSEXOCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_PUNTCARD(ByVal stPUCACODI As String) As Boolean

        Try
            Dim objdatos As New cla_PUNTCARD
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_PUNTCARD(Trim(stPUCACODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_TIPOCONS(ByVal stTICODEPA As String, _
                                             ByVal stTICOMUNI As String, _
                                             ByVal inTICOCLCO As Integer, _
                                             ByVal inTICOCLSE As Integer, _
                                             ByVal stTICOCODI As String) As Boolean

        Try
            Dim objdatos As New cla_TIPOCONS
            Dim tbl As New DataTable

            tbl = objdatos.fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(Trim(stTICODEPA), Trim(stTICOMUNI), inTICOCLCO, inTICOCLSE, Trim(stTICOCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_TIPOCALI(ByVal stTICACODI As String) As Boolean

        Try
            Dim objdatos As New cla_TIPOCALI
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_TIPOCALI(Trim(stTICACODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_TIPODOCU(ByVal stTIDOCODI As String) As Boolean

        Try
            Dim objdatos As New cla_TIPODOCU
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_TIPODOCU(Trim(stTIDOCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_TIPORESU(ByVal stTIRECODI As String) As Boolean

        Try
            Dim objdatos As New cla_TIPORESO
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_TIPORESO(Trim(stTIRECODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_ZONAECON(ByVal stZOECCODI As String) As Boolean

        Try
            Dim objdatos As New cla_ZONAECON
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_ZONAECON(Trim(stZOECCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_ZONAFISI(ByVal stZOFICODI As String) As Boolean

        Try
            Dim objdatos As New cla_ZONAFISI
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_ZONAFISI(Trim(stZOFICODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_CODICALI(ByVal stCOCACODI As String) As Boolean

        Try
            Dim objdatos As New cla_CODICALI
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_CODICALI(Trim(stCOCACODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_CODICACO(ByVal stCOCCCODI As String) As Boolean

        Try
            Dim objdatos As New cla_CODICACO
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_CODICACO(Trim(stCOCCCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_VIGENCIA(ByVal stVIGECODI As String) As Boolean

        Try
            Dim objdatos As New cla_VIGENCIA
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_VIGENCIA(Trim(stVIGECODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_SERVICIOS(ByVal stSERVCODI As String) As Boolean

        Try
            Dim objdatos As New cla_SERVICIOS
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_SERVICIOS(Trim(stSERVCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_VIAS(ByVal stVIASCODI As String) As Boolean

        Try
            Dim objdatos As New cla_VIAS
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_VIAS(Trim(stVIASCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_TOPOGRAFIA(ByVal stTOPOCODI As String) As Boolean

        Try
            Dim objdatos As New cla_TOPOGRAFIA
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_TOPOGRAFIA(Trim(stTOPOCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_AGUAS(ByVal stAGUACODI As String) As Boolean

        Try
            Dim objdatos As New cla_AGUAS
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_AGUAS(Trim(stAGUACODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_AHT(ByVal stAHTCODI As String) As Boolean

        Try
            Dim objdatos As New cla_AHT
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_AHT(Trim(stAHTCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_RESOLUCION(ByVal stVIGEDEPA As String, _
                                               ByVal stVIGEMUNI As String, _
                                               ByVal stVIGETIRE As String, _
                                               ByVal stVIGECLSE As String, _
                                               ByVal stVIGEVIGE As String, _
                                               ByVal stVIGERESO As String) As Boolean

        Try
            Dim idDepartamento As String = stVIGEDEPA
            Dim idMunicipio As String = stVIGEMUNI
            Dim idTipoResolucion As String = Val(stVIGETIRE)
            Dim idClaseoSector As String = Val(stVIGECLSE)
            Dim idVigencia As String = Val(stVIGEVIGE)
            Dim idResolucion As String = Val(stVIGERESO)

            Dim objdatos1 As New cla_RESOLUCION
            Dim tbl As New DataTable

            tbl = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_TIPO_Y_CLASE_Y_VIGENCIA_Y_CODIGO_RESOLUCION(idDepartamento, idMunicipio, idTipoResolucion, idClaseoSector, idVigencia, idResolucion)

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_IDENTIFICADOR(ByVal stTICOCODI As String) As Boolean

        Try
            Dim objdatos As New cla_TIPOCONS
            Dim tbl As New DataTable

            tbl = objdatos.fun_buscar_IDENTIFICADOR_MANT_TIPOCONS(Trim(stTICOCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_PERMFORM(ByVal stPEFOCODI As String) As Boolean

        Try
            Dim objdatos As New cla_PERMFORM
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_PERMFORM(Trim(stPEFOCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_FORMULARIO(ByVal stFORMCODI As String) As Boolean

        Try
            Dim objdatos As New cla_FORMULARIO
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_FORMULARIO(Trim(stFORMCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_MATECAMP(ByVal stMACACODI As String) As Boolean

        Try
            Dim objdatos As New cla_MATECAMP
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_MATECAMP(Trim(stMACACODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_SUBFORMULARIO(ByVal stSUFOCODI As String) As Boolean

        Try
            Dim objdatos As New cla_PERMSUFO
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_PERMSUFO(Trim(stSUFOCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_ETIQUETA(ByVal stETIQCODI As String) As Boolean

        Try
            Dim objdatos As New cla_PERMETIQ
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_PERMETIQ(Trim(stETIQCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_ESTRATO(ByVal stESTRCODI As String) As Boolean

        Try
            Dim objdatos As New cla_ESTRATO
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_ESTRATO(Trim(stESTRCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_TIPOIMPU(ByVal stTIIMCODI As String) As Boolean

        Try
            Dim objdatos As New cla_TIPOIMPU
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_TIPOIMPU(Trim(stTIIMCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_TIPOVARI(ByVal stTIVACODI As String) As Boolean

        Try
            Dim objdatos As New cla_TIPOVARI
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_TIPOVARI(Trim(stTIVACODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_DESTINACION(ByVal stDESTCODI As String) As Boolean

        Try
            Dim objdatos As New cla_DESTINACION
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_DESTINACION(Trim(stDESTCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_PROYECTO(ByVal stPROYDEPA As String, _
                                             ByVal stPROYMUNI As String, _
                                             ByVal stPROYCLSE As String, _
                                             ByVal stPROYCODI As String) As Boolean

        Try
            Dim objdatos As New cla_PROYECTO
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_PROYECTO(Trim(stPROYDEPA), Trim(stPROYMUNI), Trim(stPROYCLSE), Trim(stPROYCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_CONCEPTO(ByVal stCONCTIIM As String, _
                                             ByVal stCONCCODI As String) As Boolean

        Try
            Dim objdatos As New cla_CONCEPTO
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_CONCEPTO(Trim(stCONCTIIM), Trim(stCONCCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_SEGUDEST(ByVal stSEDEDEST As String, _
                                             ByVal stSEDECODI As String) As Boolean

        Try
            Dim objdatos As New cla_SEGUDEST
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_SEGUDEST(Trim(stSEDEDEST), Trim(stSEDECODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_FORMULA(ByVal stFORMCODI As String) As Boolean

        Try
            Dim objdatos As New cla_FORMULA
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_FORMULA(Trim(stFORMCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_CAUSACTO(ByVal stCAACCODI As String) As Boolean

        Try
            Dim objdatos As New cla_CAUSACTO
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_CAUSACTO(Trim(stCAACCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_TIPOTRAM(ByVal stTITRCODI As String) As Boolean

        Try
            Dim objdatos As New cla_TIPOTRAM
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_TIPOTRAM(Trim(stTITRCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_CLASIFICACION(ByVal stCLASCODI As String) As Boolean

        Try
            Dim objdatos As New cla_CLASIFICACION
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_CLASIFICACION(Trim(stCLASCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_MEDIRESE(ByVal stMERECODI As String) As Boolean

        Try
            Dim objdatos As New cla_MEDIRESE
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_MEDIRESE(Trim(stMERECODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_RESOAJUS(ByVal stREAJCODI As String) As Boolean

        Try
            Dim objdatos As New cla_RESOAJUS
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_RESOAJUS(Trim(stREAJCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_SOLICITANTE(ByVal stSOLICODI As String) As Boolean

        Try
            Dim objdatos As New cla_SOLICITANTE
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_SOLICITANTE(Trim(stSOLICODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_PROCEDIMIENTO(ByVal stPROCCODI As String) As Boolean

        Try
            Dim objdatos As New cla_PROCEDIMIENTO
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_PROCEDIMIENTO(Trim(stPROCCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_TABLAS(ByVal stTABLCODI As String) As Boolean

        Try
            Dim objdatos As New cla_TABLAS
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_TABLAS(Trim(stTABLCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_CAMPOS(ByVal stCAMPCODI As String) As Boolean

        Try
            Dim objdatos As New cla_CAMPOS
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_MANT_CAMPOS(Trim(stCAMPCODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Buscar_Dato_VARIABLE(ByVal stVARITIVA As String, _
                                             ByVal stVARICODI As String) As Boolean

        Try
            Dim objdatos As New cla_VARIABLE
            Dim tbl As New DataTable

            tbl = objdatos.fun_Buscar_CODIGO_VARIABLE(Trim(stVARITIVA), Trim(stVARICODI))

            If tbl.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function

End Module
