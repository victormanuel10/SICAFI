Imports REGLAS_DEL_NEGOCIO

Module mod_fun_VALIDACION_CARGA_FICHA_RESUMEN

    '======================================
    '*** VALIDACION CARGA FICHA PREDIAL ***
    '======================================

#Region "VARIABLES"

    Private dt_FICHRES1 As New DataTable
    Private dt_FICHRES2 As New DataTable
    Private dt_FIPRCONS As New DataTable
    Private dt_FIPRCACO As New DataTable
    Private dt_FIPRLIND As New DataTable
    Private dt_FIPRCART As New DataTable

    Private stFIPRNUFI As String
    Private stFIPRCODI As String
    Private stFIPRDESC As String
    Private stFIPRMUNI As String
    Private stFIPRCORR As String
    Private stFIPRBARR As String
    Private stFIPRMANZ As String
    Private stFIPRPRED As String
    Private stFIPREDIF As String
    Private stFIPRUNPR As String
    Private stFIPRCLSE As String
    Private stFIPRRESO As String

    Private stRESODEPA As String
    Private stRESOMUNI As String
    Private stRESOVIGE As String
    Private stRESOTIRE As String
    Private stRESORESO As String
    Private stRESOCLSE As String

#End Region

#Region "PROCEDIMIENTOS"

#Region "Validar Ficha Predial"

    Public Sub pro_VALIDAR_CARGA_FICHA_RESUMEN(ByVal o_dt_FICHRES1 As DataTable, _
                                               ByVal o_dt_FICHRES2 As DataTable, _
                                               ByVal o_dt_FIPRCONS As DataTable, _
                                               ByVal o_dt_FIPRCACO As DataTable, _
                                               ByVal o_dt_FIPRLIND As DataTable, _
                                               ByVal o_dt_FIPRCART As DataTable, _
                                               ByVal o_st_RESOLUCION As String, _
                                               ByVal o_st_NROFICHA As String)

        Try

            ' crea los objetos datatable
            dt_FICHRES1 = New DataTable
            dt_FICHRES2 = New DataTable
            dt_FIPRCONS = New DataTable
            dt_FIPRCACO = New DataTable
            dt_FIPRLIND = New DataTable
            dt_FIPRCART = New DataTable

            ' asigna los valores recibidos
            dt_FICHRES1 = o_dt_FICHRES1
            dt_FICHRES2 = o_dt_FICHRES2
            dt_FIPRCONS = o_dt_FIPRCONS
            dt_FIPRCACO = o_dt_FIPRCACO
            dt_FIPRLIND = o_dt_FIPRLIND
            dt_FIPRCART = o_dt_FIPRCART

            stRESODEPA = "05"
            stRESOMUNI = o_st_RESOLUCION.Substring(0, 3).ToString
            stRESOVIGE = o_st_RESOLUCION.Substring(3, 4).ToString
            stRESOTIRE = o_st_RESOLUCION.Substring(7, 3).ToString
            stRESORESO = o_st_RESOLUCION.Substring(10, 7).ToString
            stRESOCLSE = o_st_RESOLUCION.Substring(17, 1).ToString

            ' carga la resolución
            stFIPRRESO = o_st_RESOLUCION

            ' carga la ficha predial
            stFIPRNUFI = o_st_NROFICHA

            ' valida tabla RESOLUCI
            If dt_FICHRES1.Rows.Count > 0 Then
                pro_EliminarResolucion()
                pro_ValidarFichRes1()
            End If

            ' valida tabla FICHPRED
            If dt_FICHRES2.Rows.Count > 0 Then
                pro_EliminarResolucion()
                pro_ValidarFichRes2()
            End If

            ' valida tabla FIPRCONS
            If dt_FIPRCONS.Rows.Count > 0 Then
                pro_ValidarFiprCons()
            End If

            ' valida tabla FIPRCACO
            If dt_FIPRCACO.Rows.Count > 0 Then
                pro_ValidarFiprCaco()
            End If

            ' valida tabla FIPRLIND
            If dt_FIPRLIND.Rows.Count > 0 Then
                pro_ValidarFiprLind()
            End If

            ' valida tabla FIPRCART
            If dt_FIPRCART.Rows.Count > 0 Then
                pro_ValidarFiprCart()
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try


    End Sub

    Private Sub pro_EliminarFichaPredial()

        Dim objdatos As New cla_VALIFIPR

        objdatos.fun_Eliminar_FIPRINCO(Trim(stFIPRNUFI))

    End Sub
    Private Sub pro_EliminarResolucion()

        Dim objdatos As New cla_VALIFIPR

        objdatos.fun_Eliminar_FIPRINCO(Trim(stFIPRRESO))

    End Sub

#End Region

#Region "Guardar Inconsistencias"

    Private Sub pro_GrabarInconsistencia(ByVal stCODIGO As String, ByVal stDESCRIPCION As String)


        ' declara si se encuentra nothing

        If stFIPREDIF Is Nothing Then
            stFIPREDIF = "000"
        End If

        If stFIPRUNPR Is Nothing Then
            stFIPRUNPR = "00000"
        End If

        Dim objdatos1 As New cla_VALIFIPR

        objdatos1.fun_Insertar_FIPRINCO(stFIPRNUFI, stFIPRCODI, stFIPRDESC, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, stFIPREDIF, stFIPRUNPR, stFIPRCLSE, stFIPRRESO)

    End Sub

#End Region

#Region "Validar FichRes1"

    Private Sub pro_ValidarFichRes1()

        Dim stContenido As String = ""
        Dim i As Integer

        For i = 0 To dt_FICHRES1.Rows.Count - 1

            ' almacena el codigo catastral
            stFIPRNUFI = stFIPRNUFI
            stFIPRCODI = "101-FICHA RESUMEN 1"
            stFIPRMUNI = dt_FICHRES1.Rows(i).Item("RES1MUNI").ToString
            stFIPRCORR = dt_FICHRES1.Rows(i).Item("RES1CORR").ToString
            stFIPRBARR = dt_FICHRES1.Rows(i).Item("RES1BARR").ToString
            stFIPRMANZ = dt_FICHRES1.Rows(i).Item("RES1MANZ").ToString
            stFIPRPRED = dt_FICHRES1.Rows(i).Item("RES1PRED").ToString
            stFIPRCLSE = dt_FICHRES1.Rows(i).Item("RES1CLSE").ToString

            ' valida campo RES1IDRE
            stContenido = dt_FICHRES1.Rows(i).Item("RES1IDRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo Id registro"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES1MUNI
            stContenido = dt_FICHRES1.Rows(i).Item("RES1MUNI").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo municipio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES1CLSE
            stContenido = dt_FICHRES1.Rows(i).Item("RES1CLSE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo clase o sector"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES1CORR
            stContenido = dt_FICHRES1.Rows(i).Item("RES1CORR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo corregimiento"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES1BARR
            stContenido = dt_FICHRES1.Rows(i).Item("RES1BARR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo barrio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES1MANZ
            stContenido = dt_FICHRES1.Rows(i).Item("RES1MANZ").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo manzana"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES1PRED
            stContenido = dt_FICHRES1.Rows(i).Item("RES1PRED").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo predio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES1ATLO
            stContenido = dt_FICHRES1.Rows(i).Item("RES1ATLO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo area total de lote"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES1ACLO
            stContenido = dt_FICHRES1.Rows(i).Item("RES1ACLO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo area comun de lote"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES1APCA
            stContenido = dt_FICHRES1.Rows(i).Item("RES1APCA").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo apartamentos o casas"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES1UNCO
            stContenido = dt_FICHRES1.Rows(i).Item("RES1UNCO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo unidades en condominio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES1TOED
            stContenido = dt_FICHRES1.Rows(i).Item("RES1TOED").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo total edificio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES1CUUT
            stContenido = dt_FICHRES1.Rows(i).Item("RES1CUUT").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo cuartos utiles"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES1LOCA
            stContenido = dt_FICHRES1.Rows(i).Item("RES1LOCA").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo locales"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES1GACU
            stContenido = dt_FICHRES1.Rows(i).Item("RES1GACU").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo garajes cubiertos"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES1GADE
            stContenido = dt_FICHRES1.Rows(i).Item("RES1GADE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo garajes descubiertos"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES1CAPR
            stContenido = dt_FICHRES1.Rows(i).Item("RES1CAPR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo caracteristica de predio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If


            ' valida la lista de valores de ficha predial
            Dim stRES1MUNI As String = dt_FICHRES1.Rows(i).Item("RES1MUNI").ToString
            Dim stRES1CLSE As String = dt_FICHRES1.Rows(i).Item("RES1CLSE").ToString
            Dim stRES1CAPR As String = dt_FICHRES1.Rows(i).Item("RES1CAPR").ToString

            ' valida el campo de municipio 
            If fun_Buscar_Dato_MUNICIPIO(stRESODEPA, stRES1MUNI) = False Then
                stFIPRDESC = "Municipio no existe" & ". Código : " & stRES1MUNI

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida el campo de clase o sector
            If fun_Buscar_Dato_CLASSECT(stRES1CLSE) = False Then
                stFIPRDESC = "Clase o sector no existe" & ". Código : " & stRES1CLSE

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida el campo caracteristica de predio
            If fun_Buscar_Dato_CARAPRED(stRES1CAPR) = False Then
                stFIPRDESC = "Caracteristica de predio no existe" & ". Código : " & stRES1CAPR

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

        Next

    End Sub

#End Region

#Region "Validar FichRes2"

    Private Sub pro_ValidarFichRes2()

        Dim stContenido As String = ""
        Dim i As Integer

        For i = 0 To dt_FICHRES2.Rows.Count - 1

            ' almacena el codigo catastral
            stFIPRNUFI = stFIPRNUFI
            stFIPRCODI = "201-FICHA RESUMEN 2"
            stFIPRMUNI = dt_FICHRES2.Rows(i).Item("RES2MUNI").ToString
            stFIPRCORR = dt_FICHRES2.Rows(i).Item("RES2CORR").ToString
            stFIPRBARR = dt_FICHRES2.Rows(i).Item("RES2BARR").ToString
            stFIPRMANZ = dt_FICHRES2.Rows(i).Item("RES2MANZ").ToString
            stFIPRPRED = dt_FICHRES2.Rows(i).Item("RES2PRED").ToString
            stFIPREDIF = dt_FICHRES2.Rows(i).Item("RES2EDIF").ToString
            stFIPRCLSE = dt_FICHRES2.Rows(i).Item("RES2CLSE").ToString

            ' valida campo RES2IDRE
            stContenido = dt_FICHRES2.Rows(i).Item("RES2IDRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo Id registro"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES2MUNI
            stContenido = dt_FICHRES2.Rows(i).Item("RES2MUNI").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo municipio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES2CLSE
            stContenido = dt_FICHRES2.Rows(i).Item("RES2CLSE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo clase o sector"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES2CORR
            stContenido = dt_FICHRES2.Rows(i).Item("RES2CORR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo corregimiento"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES2BARR
            stContenido = dt_FICHRES2.Rows(i).Item("RES2BARR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo barrio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES2MANZ
            stContenido = dt_FICHRES2.Rows(i).Item("RES2MANZ").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo manzana"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES2PRED
            stContenido = dt_FICHRES2.Rows(i).Item("RES2PRED").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo predio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES2EDIF
            stContenido = dt_FICHRES2.Rows(i).Item("RES2EDIF").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo edificio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES2ATLO
            stContenido = dt_FICHRES2.Rows(i).Item("RES2ATLO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo area total de lote"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES2ACLO
            stContenido = dt_FICHRES2.Rows(i).Item("RES2ACLO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo area comun de lote"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES2PISO
            stContenido = dt_FICHRES2.Rows(i).Item("RES2PISO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo total pisos"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES2URPH
            stContenido = dt_FICHRES2.Rows(i).Item("RES2URPH").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo unidades en RPH"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES2APCA
            stContenido = dt_FICHRES2.Rows(i).Item("RES2APCA").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo apartamentos o casas"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES2CUUT
            stContenido = dt_FICHRES2.Rows(i).Item("RES2CUUT").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo cuartos utiles"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES2LOCA
            stContenido = dt_FICHRES2.Rows(i).Item("RES2LOCA").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo locales"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES2GACU
            stContenido = dt_FICHRES2.Rows(i).Item("RES2GACU").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo garajes cubiertos"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES2GADE
            stContenido = dt_FICHRES2.Rows(i).Item("RES2GADE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo garajes descubiertos"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RES2CAPR
            stContenido = dt_FICHRES2.Rows(i).Item("RES2CAPR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo caracteristica de predio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If


            ' valida la lista de valores de ficha predial
            Dim stRES2MUNI As String = dt_FICHRES2.Rows(i).Item("RES2MUNI").ToString
            Dim stRES2CLSE As String = dt_FICHRES2.Rows(i).Item("RES2CLSE").ToString
            Dim stRES2CAPR As String = dt_FICHRES2.Rows(i).Item("RES2CAPR").ToString

            ' valida el campo de municipio 
            If fun_Buscar_Dato_MUNICIPIO(stRESODEPA, stRES2MUNI) = False Then
                stFIPRDESC = "Municipio no existe" & ". Código : " & stRES2MUNI

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida el campo de clase o sector
            If fun_Buscar_Dato_CLASSECT(stRES2CLSE) = False Then
                stFIPRDESC = "Clase o sector no existe" & ". Código : " & stRES2CLSE

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida el campo caracteristica de predio
            If fun_Buscar_Dato_CARAPRED(stRES2CAPR) = False Then
                stFIPRDESC = "Caracteristica de predio no existe" & ". Código : " & stRES2CAPR

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

        Next

    End Sub

#End Region

#Region "Validar FiprCons"

    Private Sub pro_ValidarFiprCons()

        Dim stContenido As String = ""
        Dim i As Integer

        For i = 0 To dt_FIPRCONS.Rows.Count - 1

            stFIPRNUFI = stFIPRNUFI
            stFIPRCODI = "301-CONSTRUCCION"
            stFIPRMUNI = dt_FIPRCONS.Rows(i).Item("FPCOMUNI").ToString
            stFIPRCORR = dt_FIPRCONS.Rows(i).Item("FPCOCORR").ToString
            stFIPRBARR = dt_FIPRCONS.Rows(i).Item("FPCOBARR").ToString
            stFIPRMANZ = dt_FIPRCONS.Rows(i).Item("FPCOMANZ").ToString
            stFIPRPRED = dt_FIPRCONS.Rows(i).Item("FPCOPRED").ToString
            stFIPREDIF = dt_FIPRCONS.Rows(i).Item("FPCOEDIF").ToString
            stFIPRCLSE = dt_FIPRCONS.Rows(i).Item("FPCOCLSE").ToString

            ' valida campo FPCOIDRE
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOIDRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo Id registro"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOMUNI
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOMUNI").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo municipio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOCLSE
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOCLSE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo clase o sector"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOCORR
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOCORR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo tipo de corregimiento"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOBARR
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOBARR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo barrio o vereda"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOMANZ
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOMANZ").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo manzana"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOPRED
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOPRED").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo predio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOEDIF
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOEDIF").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo edificio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOUNID
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOUNID").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo unidad predial"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOTIPO
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOTIPO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = True Then
                stFIPRDESC = "Valor numèrico campo tipo de calificación"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOTICO
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOTICO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo identificador de construcción"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOARCO
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOARCO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo area de construccion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOPUNT
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOPUNT").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo puntos"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOACUE
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOACUE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo acueducto"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOALCA
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOALCA").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo alcantarillado"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOENER
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOENER").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo energia"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOTELE
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOTELE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo telefono"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOGAS
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOGAS").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo gas"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOPISO
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOPISO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo pisos"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOPOCO
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOPOCO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo porcentaje construido"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOEDCO
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOEDCO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo edad de construccion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida la lista de valores de ficha predial
            Dim stFPCODEPA As String = stRESODEPA
            Dim stFPCOMUNI As String = stRESOMUNI
            Dim stFPCOCLCO As String = ""
            Dim stFPCOCLSE As String = stRESOCLSE
            Dim stFPCOTICO As String = dt_FIPRCONS.Rows(i).Item("FPCOTICO").ToString
            Dim stFPCOTIPO As String = Trim(dt_FIPRCONS.Rows(i).Item("FPCOTIPO").ToString)

            ' coloca la clase 1
            If fun_Verificar_Dato_Numerico_Evento_Validated(stFPCOTICO) = True Then
                If stFPCOTICO < 500 AndAlso _
                   stFPCOTICO <> "020" Or stFPCOTICO <> "037" Or _
                   stFPCOTICO <> "019" Or stFPCOTICO <> "028" Or _
                   stFPCOTICO <> "032" Or stFPCOTICO <> "072" Or _
                   stFPCOTICO <> "074" Or stFPCOTICO <> "075" Or _
                   stFPCOTICO <> "076" Or stFPCOTICO <> "077" Or _
                   stFPCOTICO <> "078" Or stFPCOTICO <> "073" Then

                    stFPCOCLCO = 1
                End If
            End If

            ' coloca la clase 2
            If fun_Verificar_Dato_Numerico_Evento_Validated(stFPCOTICO) = True Then
                If stFPCOTICO < 500 AndAlso _
                   stFPCOTICO = "020" Or stFPCOTICO = "037" Or _
                   stFPCOTICO = "019" Or stFPCOTICO = "028" Or _
                   stFPCOTICO = "032" Or stFPCOTICO = "072" Or _
                   stFPCOTICO = "074" Or stFPCOTICO = "075" Or _
                   stFPCOTICO = "076" Or stFPCOTICO = "077" Or _
                   stFPCOTICO = "078" Or stFPCOTICO = "073" Then

                    stFPCOCLCO = 2
                End If
            Else
                stFPCOCLCO = 1
            End If

            ' coloca la clase 3
            If fun_Verificar_Dato_Numerico_Evento_Validated(stFPCOTICO) = True Then
                If stFPCOTICO > 500 Then
                    stFPCOCLCO = 3
                End If
            Else
                stFPCOCLCO = 1
            End If

            ' valida el identificador de construcción
            If fun_Buscar_Dato_TIPOCONS(stFPCODEPA, stFPCOMUNI, stFPCOCLCO, stFPCOCLSE, stFPCOTICO) = False Then
                stFIPRDESC = "Identificador de construcción no existe" & ". Código : " & stFPCODEPA & "-" & stFPCOMUNI & "-" & stFPCOCLCO & "-" & stFPCOCLSE & "-" & stFPCOTICO

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            '' valida el tipo de calificación
            'If fun_Buscar_Dato_TIPOCALI(stFPCOTIPO) = False Then
            '    stFIPRDESC = "Tipo de calificación no existe" & ". Código : " & stFPCOTIPO

            '    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            'End If


            ' valida acueducto
            If dt_FIPRCONS.Rows(i).Item("FPCOACUE").ToString <> "1" And dt_FIPRCONS.Rows(i).Item("FPCOACUE").ToString <> "2" Then
                stFIPRDESC = "Acueducto no existe" & ". Código : " & dt_FIPRCONS.Rows(i).Item("FPCOACUE").ToString

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida el alcantarilla
            If dt_FIPRCONS.Rows(i).Item("FPCOALCA").ToString <> 1 And dt_FIPRCONS.Rows(i).Item("FPCOALCA").ToString <> 2 Then
                stFIPRDESC = "Alcantarillado no existe" & ". Código : " & dt_FIPRCONS.Rows(i).Item("FPCOALCA").ToString

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida energia
            If dt_FIPRCONS.Rows(i).Item("FPCOENER").ToString <> 1 And dt_FIPRCONS.Rows(i).Item("FPCOENER").ToString <> 2 Then
                stFIPRDESC = "Energia no existe" & ". Código : " & dt_FIPRCONS.Rows(i).Item("FPCOENER").ToString

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida gas
            If dt_FIPRCONS.Rows(i).Item("FPCOGAS").ToString <> 1 And dt_FIPRCONS.Rows(i).Item("FPCOGAS").ToString <> 2 Then
                stFIPRDESC = "Gas no existe" & ". Código : " & dt_FIPRCONS.Rows(i).Item("FPCOGAS").ToString

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

        Next

    End Sub

#End Region

#Region "Validar FiprCaco"

    Private Sub pro_ValidarFiprCaco()

        Dim stContenido As String = ""
        Dim i As Integer

        For i = 0 To dt_FIPRCACO.Rows.Count - 1

            ' almacena el codigo catastral
            stFIPRNUFI = stFIPRNUFI
            stFIPRCODI = "401-CALIFICACION"
            stFIPRMUNI = dt_FIPRCACO.Rows(i).Item("FPCCMUNI").ToString
            stFIPRCORR = dt_FIPRCACO.Rows(i).Item("FPCCCORR").ToString
            stFIPRBARR = dt_FIPRCACO.Rows(i).Item("FPCCBARR").ToString
            stFIPRMANZ = dt_FIPRCACO.Rows(i).Item("FPCCMANZ").ToString
            stFIPRPRED = dt_FIPRCACO.Rows(i).Item("FPCCPRED").ToString
            stFIPREDIF = dt_FIPRCACO.Rows(i).Item("FPCCEDIF").ToString
            stFIPRCLSE = dt_FIPRCACO.Rows(i).Item("FPCCCLSE").ToString

            ' valida campo FPCCIDRE
            stContenido = dt_FIPRCACO.Rows(i).Item("FPCCIDRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo Id registro"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCCMUNI
            stContenido = dt_FIPRCACO.Rows(i).Item("FPCCMUNI").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo municipio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCCCLSE
            stContenido = dt_FIPRCACO.Rows(i).Item("FPCCCLSE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo clase o sector"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCCCORR
            stContenido = dt_FIPRCACO.Rows(i).Item("FPCCCORR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo corregimiento"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCCBARR
            stContenido = dt_FIPRCACO.Rows(i).Item("FPCCBARR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo barrio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCCMANZ
            stContenido = dt_FIPRCACO.Rows(i).Item("FPCCMANZ").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo manzana o vereda"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCCPRED
            stContenido = dt_FIPRCACO.Rows(i).Item("FPCCPRED").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo predio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCCEDIF
            stContenido = dt_FIPRCACO.Rows(i).Item("FPCCEDIF").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo edificio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCCUNID
            stContenido = dt_FIPRCACO.Rows(i).Item("FPCCUNID").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo nro de construccion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCCCODI
            stContenido = dt_FIPRCACO.Rows(i).Item("FPCCCODI").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo codigo"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCCTIPO
            stContenido = dt_FIPRCACO.Rows(i).Item("FPCCTIPO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = True Then
                stFIPRDESC = "Valor numèrico campo tipo de calificación"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCCPUNT
            stContenido = dt_FIPRCACO.Rows(i).Item("FPCCPUNT").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numérico campo puntos de calificación"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida la lista de valores de ficha predial
            Dim stFPCCTIPO As String = dt_FIPRCACO.Rows(i).Item("FPCCTIPO").ToString
            Dim stFPCOCODI As String = dt_FIPRCACO.Rows(i).Item("FPCCCODI").ToString

            ' valida el tipo de calificación
            If fun_Buscar_Dato_TIPOCALI(stFPCCTIPO) = False Then
                stFIPRDESC = "Tipo de calificación no existe" & ". Código : " & stFPCCTIPO

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida el codigo de calificación
            If fun_Buscar_Dato_CODICALI(stFPCOCODI) = False Then
                stFIPRDESC = "Código de calificación no existe" & ". Código : " & stFPCOCODI

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

        Next

    End Sub

#End Region

#Region "Validar FiprLind"

    Private Sub pro_ValidarFiprLind()

        Dim stContenido As String = ""
        Dim i As Integer

        For i = 0 To dt_FIPRLIND.Rows.Count - 1

            ' almacena el codigo catastral
            stFIPRNUFI = stFIPRNUFI
            stFIPRCODI = "601-LINDERO"
            stFIPRMUNI = dt_FIPRLIND.Rows(i).Item("FPLIMUNI").ToString
            stFIPRCORR = dt_FIPRLIND.Rows(i).Item("FPLICORR").ToString
            stFIPRBARR = dt_FIPRLIND.Rows(i).Item("FPLIBARR").ToString
            stFIPRMANZ = dt_FIPRLIND.Rows(i).Item("FPLIMANZ").ToString
            stFIPRPRED = dt_FIPRLIND.Rows(i).Item("FPLIPRED").ToString
            stFIPREDIF = dt_FIPRLIND.Rows(i).Item("FPLIEDIF").ToString
            stFIPRCLSE = dt_FIPRLIND.Rows(i).Item("FPLICLSE").ToString


            ' valida campo FPLIIDRE
            stContenido = dt_FIPRLIND.Rows(i).Item("FPLIIDRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo Id registro"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPLIMUNI
            stContenido = dt_FIPRLIND.Rows(i).Item("FPLIMUNI").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo municipio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPLICLSE
            stContenido = dt_FIPRLIND.Rows(i).Item("FPLICLSE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo clase o sector"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPLICORR
            stContenido = dt_FIPRLIND.Rows(i).Item("FPLICORR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo corregimiento"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPLIBARR
            stContenido = dt_FIPRLIND.Rows(i).Item("FPLIBARR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo barrio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPLIMANZ
            stContenido = dt_FIPRLIND.Rows(i).Item("FPLIMANZ").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo manzana o vereda"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPLIPRED
            stContenido = dt_FIPRLIND.Rows(i).Item("FPLIMANZ").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo predio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPLIEDIF
            stContenido = dt_FIPRLIND.Rows(i).Item("FPLIEDIF").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo edificio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida la lista de valores 
            Dim stFPLIPUCA As String = Trim(dt_FIPRLIND.Rows(i).Item("FPLIPUCA").ToString)

            ' valida el punto cardinal
            If fun_Buscar_Dato_PUNTCARD(stFPLIPUCA) = False Then
                stFIPRDESC = "Punto cardinal no existe" & ". Código : " & stFPLIPUCA

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

        Next

    End Sub

#End Region

#Region "Validar FiprCart"

    Private Sub pro_ValidarFiprCart()

        Dim stContenido As String = ""
        Dim i As Integer

        For i = 0 To dt_FIPRCART.Rows.Count - 1

            ' almacena el codigo catastral
            stFIPRNUFI = stFIPRNUFI
            stFIPRCODI = "501-CARTOGRAFIA"
            stFIPRMUNI = dt_FIPRCART.Rows(i).Item("FPCAMUNI").ToString
            stFIPRCORR = dt_FIPRCART.Rows(i).Item("FPCACORR").ToString
            stFIPRBARR = dt_FIPRCART.Rows(i).Item("FPCABARR").ToString
            stFIPRMANZ = dt_FIPRCART.Rows(i).Item("FPCAMANZ").ToString
            stFIPRPRED = dt_FIPRCART.Rows(i).Item("FPCAPRED").ToString
            stFIPREDIF = dt_FIPRCART.Rows(i).Item("FPCAEDIF").ToString
            stFIPRCLSE = dt_FIPRCART.Rows(i).Item("FPCACLSE").ToString


            ' valida campo FPCAIDRE
            stContenido = dt_FIPRCART.Rows(i).Item("FPCAIDRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo Id registro"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCAMUNI
            stContenido = dt_FIPRCART.Rows(i).Item("FPCAMUNI").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo municipio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCACLSE
            stContenido = dt_FIPRCART.Rows(i).Item("FPCACLSE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo clase o sector"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCACORR
            stContenido = dt_FIPRCART.Rows(i).Item("FPCACORR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo corregimiento"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCABARR
            stContenido = dt_FIPRCART.Rows(i).Item("FPCABARR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo barrio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCAMANZ
            stContenido = dt_FIPRCART.Rows(i).Item("FPCAMANZ").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo manzana o vereda"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCAPRED
            stContenido = dt_FIPRCART.Rows(i).Item("FPCAPRED").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo predio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCAEDIF
            stContenido = dt_FIPRCART.Rows(i).Item("FPCAEDIF").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo edificio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCAVIGR
            stContenido = dt_FIPRCART.Rows(i).Item("FPCAVIGR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo vigencia grafica"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCAVIAE
            stContenido = dt_FIPRCART.Rows(i).Item("FPCAVIAE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo vigencia aerofotografica"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida la lista de valores 
            Dim stFPCAVIGR As String = Trim(dt_FIPRCART.Rows(i).Item("FPCAVIGR").ToString)
            Dim stFPCAVIAE As String = Trim(dt_FIPRCART.Rows(i).Item("FPCAVIAE").ToString)

            ' valida la vigencia grafica
            If fun_Buscar_Dato_VIGENCIA(stFPCAVIGR) = False Then
                stFIPRDESC = "Vigencia grafica no existe" & ". Código : " & stFPCAVIGR

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida la vigencia aerofotografica
            If fun_Buscar_Dato_VIGENCIA(stFPCAVIAE) = False Then
                stFIPRDESC = "Vigencia aerofotografica no existe" & ". Código : " & stFPCAVIAE

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

        Next

    End Sub

#End Region

#End Region

End Module
