Imports REGLAS_DEL_NEGOCIO

Module mod_fun_VALIDACION_CARGA_FICHA_PREDIAL

    '======================================
    '*** VALIDACION CARGA FICHA PREDIAL ***
    '======================================

#Region "VARIABLES"

    Private dt_RESOLUCI As New DataTable
    Private dt_FICHPRED As New DataTable
    Private dt_FIPRDEEC As New DataTable
    Private dt_FIPRPROP As New DataTable
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

    Private boPLANSICA As Boolean
    Private boFICHAOVC As Boolean

    Dim stRESOESTA As String = "ac"

#End Region

#Region "PROCEDIMIENTOS"

#Region "Validar Ficha Predial"

    Public Sub pro_VALIDAR_CARGA_FICHA_PREDIAL(ByVal o_dt_RESOLUCI As DataTable, _
                                               ByVal o_dt_FICHPRED As DataTable, _
                                               ByVal o_dt_FIPRDEEC As DataTable, _
                                               ByVal o_dt_FIPRPROP As DataTable, _
                                               ByVal o_dt_FIPRCONS As DataTable, _
                                               ByVal o_dt_FIPRCACO As DataTable, _
                                               ByVal o_dt_FIPRLIND As DataTable, _
                                               ByVal o_dt_FIPRCART As DataTable, _
                                               ByVal o_st_RESOLUCION As String, _
                                               ByVal o_st_NROFICHA As String, _
                                               ByVal o_bo_PLANSICA As Boolean, _
                                               ByVal o_bo_FICHAOVC As Boolean)

        Try

            ' crea los objetos datatable
            dt_RESOLUCI = New DataTable
            dt_FICHPRED = New DataTable
            dt_FIPRDEEC = New DataTable
            dt_FIPRPROP = New DataTable
            dt_FIPRCONS = New DataTable
            dt_FIPRCACO = New DataTable
            dt_FIPRLIND = New DataTable
            dt_FIPRCART = New DataTable

            ' asigna los valores recibidos
            dt_RESOLUCI = o_dt_RESOLUCI
            dt_FICHPRED = o_dt_FICHPRED
            dt_FIPRDEEC = o_dt_FIPRDEEC
            dt_FIPRPROP = o_dt_FIPRPROP
            dt_FIPRCONS = o_dt_FIPRCONS
            dt_FIPRCACO = o_dt_FIPRCACO
            dt_FIPRLIND = o_dt_FIPRLIND
            dt_FIPRCART = o_dt_FIPRCART

            ' carga el plano sicafi
            boPLANSICA = o_bo_PLANSICA
            boFICHAOVC = o_bo_FICHAOVC

            stRESODEPA = vp_Departamento
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
            If dt_RESOLUCI.Rows.Count > 0 Then
                pro_EliminarResolucion()
                pro_ValidarResoluci()
            End If

            ' valida tabla FICHPRED
            If dt_FICHPRED.Rows.Count > 0 Then
                pro_EliminarFichaPredial()
                pro_ValidarFichPred()
            End If

            ' valida tabla FIPRDEEC
            If dt_FIPRDEEC.Rows.Count > 0 Then
                pro_ValidarFiprDeec()
            End If

            ' valida tabla FIPRPROP
            If dt_FIPRPROP.Rows.Count > 0 Then
                pro_ValidarFiprProp()
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

        Dim objdatos1 As New cla_VALIFIPR

        objdatos1.fun_Insertar_FIPRINCO(stFIPRNUFI, stFIPRCODI, stFIPRDESC, stFIPRMUNI, stFIPRCORR, stFIPRBARR, stFIPRMANZ, stFIPRPRED, stFIPREDIF, stFIPRUNPR, stFIPRCLSE, stFIPRRESO)

    End Sub

#End Region

#Region "Validar Resoluci"

    Private Sub pro_ValidarResoluci()

        Dim stContenido As String = ""
        Dim i As Integer

        For i = 0 To dt_RESOLUCI.Rows.Count - 1

            ' almacena el codigo catastral
            stFIPRNUFI = stFIPRRESO
            stFIPRCODI = "101-RESOLUCION"
            stFIPRMUNI = dt_RESOLUCI.Rows(i).Item("RESOMUNI").ToString
            stFIPRCORR = ""
            stFIPRBARR = ""
            stFIPRMANZ = ""
            stFIPRPRED = ""
            stFIPREDIF = ""
            stFIPRUNPR = ""
            stFIPRCLSE = dt_RESOLUCI.Rows(i).Item("RESOCLSE").ToString

            ' valida campo RESOIDRE
            stContenido = dt_RESOLUCI.Rows(i).Item("RESOIDRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo Id registro"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RESOVIGE
            stContenido = dt_RESOLUCI.Rows(i).Item("RESOVIGE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo vigencia"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RESOTIRE
            stContenido = dt_RESOLUCI.Rows(i).Item("RESOTIRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo tipo resolucion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RESORESO
            stContenido = dt_RESOLUCI.Rows(i).Item("RESORESO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo resolucion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RESOMUNI
            stContenido = dt_RESOLUCI.Rows(i).Item("RESOMUNI").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo municipio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RESOCLSE
            stContenido = dt_RESOLUCI.Rows(i).Item("RESOCLSE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo clase o sector"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RESONURE
            stContenido = dt_RESOLUCI.Rows(i).Item("RESONURE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo numero de registro"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RESOARTE
            stContenido = dt_RESOLUCI.Rows(i).Item("RESOARTE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo area de terreno"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RESOARCO
            stContenido = dt_RESOLUCI.Rows(i).Item("RESOARCO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo area de construccion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RESOSUPU
            stContenido = dt_RESOLUCI.Rows(i).Item("RESOSUPU").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo suma de puntos"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo RESOPATO
            stContenido = dt_RESOLUCI.Rows(i).Item("RESOPATO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo parcial o total"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida la lista de valores de ficha predial
            Dim stRESOVIGE As String = dt_RESOLUCI.Rows(i).Item("RESOVIGE").ToString
            Dim stRESOTIRE As String = dt_RESOLUCI.Rows(i).Item("RESOTIRE").ToString
            Dim stRESORESO As String = dt_RESOLUCI.Rows(i).Item("RESORESO").ToString
            Dim stRESOMUNI As String = dt_RESOLUCI.Rows(i).Item("RESOMUNI").ToString
            Dim stRESOCLSE As String = dt_RESOLUCI.Rows(i).Item("RESOCLSE").ToString

            ' valida el campo vigencia
            If fun_Buscar_Dato_VIGENCIA(stRESOVIGE) = False Then

                If boPLANSICA = True Then

                    Dim objRESOVIGE As New cla_VIGENCIA

                    objRESOVIGE.fun_Insertar_VIGENCIA(stRESOVIGE, stRESOVIGE, stRESOESTA)

                Else
                    stFIPRDESC = "Vigencia no existe" & ". Código : " & stRESOVIGE

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)
                End If
              
            End If

            ' valida el campo tipo de resolucion
            If fun_Buscar_Dato_TIPORESU(stRESOTIRE) = False Then

                If boPLANSICA = True Then

                    Dim objRESOTIRE As New cla_TIPORESO

                    objRESOTIRE.fun_Insertar_MANT_TIPORESO(stRESOTIRE, stRESOTIRE, stRESOESTA)

                Else
                    stFIPRDESC = "Tipo de resolución no existe" & ". Código : " & stRESOTIRE

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)
                End If

            End If

            ' valida el campo de resolucion
            If fun_Buscar_Dato_RESOLUCION(stRESODEPA, stRESOMUNI, stRESOTIRE, stRESOCLSE, stRESOVIGE, stRESORESO) = False Then

                stFIPRDESC = "Resolución no existe"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida el campo de municipio 
            If fun_Buscar_Dato_MUNICIPIO(stRESODEPA, stRESOMUNI) = False Then

                If boPLANSICA = True Then

                    If Trim(stRESODEPA) <> "05" Then

                        Dim objMUNICIPIO As New cla_MUNICIPIO

                        objMUNICIPIO.fun_Insertar_MANT_MUNICIPIO(stRESODEPA, stRESOMUNI, stRESOMUNI, 0, 0, stRESOESTA)

                    End If

                Else
                    stFIPRDESC = "Municipio no existe" & ". Código : " & stRESOMUNI

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

                End If
                
            End If

            ' valida el campo de clase o sector
            If fun_Buscar_Dato_CLASSECT(stRESOCLSE) = False Then

                If boPLANSICA = True Then

                    Dim objCLASSECT As New cla_CLASSECT

                    objCLASSECT.fun_Insertar_MANT_CLASSECT(stRESOCLSE, stRESOCLSE, stRESOESTA)

                Else
                    stFIPRDESC = "Clase o sector no existe" & ". Código : " & stRESOCLSE

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

                End If
                
            End If

        Next

        ' valida el numero de registros
        If dt_RESOLUCI.Rows.Count > 1 Then
            stFIPRDESC = "Existe mas de un registro para la tabla de resolución"

            pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

        End If


    End Sub

#End Region

#Region "Validar FichPred"

    Private Sub pro_ValidarFichPred()

        stFIPRCODI = "201-FICHA PREDIAL"

        Dim stContenido As String = ""
        Dim i As Integer

        For i = 0 To dt_FICHPRED.Rows.Count - 1

            ' almacena el codigo catastral
            stFIPRNUFI = dt_FICHPRED.Rows(i).Item("FIPRNUFI").ToString
            stFIPRMUNI = dt_FICHPRED.Rows(i).Item("FIPRMUNI").ToString
            stFIPRCORR = dt_FICHPRED.Rows(i).Item("FIPRCORR").ToString
            stFIPRBARR = dt_FICHPRED.Rows(i).Item("FIPRBARR").ToString
            stFIPRMANZ = dt_FICHPRED.Rows(i).Item("FIPRMANZ").ToString
            stFIPRPRED = dt_FICHPRED.Rows(i).Item("FIPRPRED").ToString
            stFIPREDIF = dt_FICHPRED.Rows(i).Item("FIPREDIF").ToString
            stFIPRUNPR = dt_FICHPRED.Rows(i).Item("FIPRUNPR").ToString
            stFIPRCLSE = dt_FICHPRED.Rows(i).Item("FIPRCLSE").ToString

            ' valida campo FIPRIDRE
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRIDRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo Id registro"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRVIGE
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRVIGE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo vigencia"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRTIRE
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRTIRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo tipo de resolucion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRRESO
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRRESO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo resolucion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            Dim inNroFicha As Integer = 0

            ' valida campo FIPRNUFI
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRNUFI").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo numero de ficha"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            Else
                inNroFicha = CType(dt_FICHPRED.Rows(i).Item("FIPRNUFI"), Integer)

            End If

            ' valida el rango de la ficha 
            Dim objdatos55 As New cla_MUNICIPIO
            Dim tbl55 As New DataTable

            Dim inRangoInicial As Integer = 0
            Dim inRangoFinal As Integer = 0

            tbl55 = objdatos55.fun_Buscar_DEPARTAMENTO_Y_CODIGO_MANT_MUNICIPIO(Trim("05"), dt_FICHPRED.Rows(i).Item("FIPRMUNI").ToString)

            If tbl55.Rows.Count > 0 And fun_Verificar_Dato_Numerico_Evento_Validated(inNroFicha) = True Then

                Dim boSW As Boolean = False
                Dim stFIPRNUFI As String = stContenido

                If stFIPRNUFI.ToString.Substring(0, 3) = Trim(stFIPRMUNI) And stFIPRNUFI.ToString.Substring(3, 1) = stFIPRCLSE Then
                    boSW = True
                Else
                    boSW = False
                End If

                inRangoInicial = CType(tbl55.Rows(0).Item("MUNIRAIN"), Integer)
                inRangoFinal = CType(tbl55.Rows(0).Item("MUNIRAFI"), Integer)

                If Val(inNroFicha) < inRangoInicial Or Val(inNroFicha) > inRangoFinal Then

                    If boSW = False And boFICHAOVC = False Then

                        stFIPRDESC = "El rango de la ficha no corresponde con el municipio."

                        pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

                    End If

                End If

            End If

            ' valida campo FIPRNURE
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRNURE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo numero de registro"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRMUNI
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRMUNI").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo municipio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRCLSE
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRCLSE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo clase o sector"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRCORR
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRCORR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo corregimiento"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRBARR
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRBARR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo barrio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRMANZ
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRMANZ").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo manzana"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRPRED
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRPRED").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo predio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPREDIF
            stContenido = dt_FICHPRED.Rows(i).Item("FIPREDIF").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo edificio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRUNPR
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRUNPR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo unidad predial"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRARTE
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRARTE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo area de terrreno"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRCAPR
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRCAPR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo caracteristica de predio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRCASU
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRCASU").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo categoria de suelo"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRCOPR
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRCOPR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo coeficiente de predio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRCOED
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRCOED").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo coeficiente de edificio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRMUAN
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRMUAN").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo municipio anterior"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRCSAN
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRCSAN").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo clase o sector anterior"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRCOAN
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRCOAN").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo corregimiento anterior"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRBAAN
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRBAAN").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo barrio anterior"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRMAAN
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRMAAN").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo manzana anterior"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRPRAN
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRPRAN").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo predio anterior"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPREDAN
            stContenido = dt_FICHPRED.Rows(i).Item("FIPREDAN").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo edificio anterior"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRUPAN
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRUPAN").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo unidad predial anterior"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FIPRCASA
            stContenido = dt_FICHPRED.Rows(i).Item("FIPRCASA").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo categoria de suelo anterior"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida la lista de valores de ficha predial
            Dim stFIPRSECT As String = dt_FICHPRED.Rows(i).Item("FIPRCLSE").ToString
            Dim stFIPRCASU As String = dt_FICHPRED.Rows(i).Item("FIPRCASU").ToString
            Dim stFIPRCSAN As String = dt_FICHPRED.Rows(i).Item("FIPRCSAN").ToString
            Dim stFIPRCASA As String = dt_FICHPRED.Rows(i).Item("FIPRCASA").ToString
            Dim stFIPRCAPR As String = dt_FICHPRED.Rows(i).Item("FIPRCAPR").ToString

            ' valida la clase o sector
            If fun_Buscar_Dato_CLASSECT(stFIPRSECT) = False Then

                If boPLANSICA = True Then

                    Dim objCLASSECT As New cla_CLASSECT

                    objCLASSECT.fun_Insertar_MANT_CLASSECT(stFIPRSECT, stFIPRSECT, stRESOESTA)
                Else
                    stFIPRDESC = "Clase o sector no existe" & ". Código : " & stFIPRSECT

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)
                End If

            End If

            ' valida la clase o sector anterior
            If fun_Buscar_Dato_CLASSECT(stFIPRCSAN) = False Then

                If boPLANSICA = True Then

                    Dim objCLASSECT As New cla_CLASSECT

                    objCLASSECT.fun_Insertar_MANT_CLASSECT(stFIPRCSAN, stFIPRCSAN, stRESOESTA)
                Else
                    stFIPRDESC = "Clase o sector anterior no existe" & ". Código : " & stFIPRCSAN

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

                End If

            End If

            ' valida la categoria de suelo
            If fun_Buscar_Dato_CATESUEL(stFIPRCASU) = False Then

                If boPLANSICA = True Then

                    Dim objCATESUEL As New cla_CATESUEL

                    objCATESUEL.fun_Insertar_MANT_CATESUEL(stFIPRCASU, stFIPRCASU, stRESOESTA)
                Else
                    stFIPRDESC = "Categoria de suelo no existe" & ". Código : " & stFIPRCASU

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

                End If

            End If

            ' valida la categoria de suelo anterior
            If fun_Buscar_Dato_CATESUEL(stFIPRCASA) = False Then

                If boPLANSICA = True Then

                    Dim objCATESUEL As New cla_CATESUEL

                    objCATESUEL.fun_Insertar_MANT_CATESUEL(stFIPRCASA, stFIPRCASA, stRESOESTA)
                Else

                    stFIPRDESC = "Categoria de suelo anterior no existe" & ". Código : " & stFIPRCASA

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

                End If

            End If

            ' valida la caracteristica de predio
            If fun_Buscar_Dato_CARAPRED(stFIPRCAPR) = False Then

                If boPLANSICA = True Then

                    Dim objFIPRCAPR As New cla_CARAPRED

                    objFIPRCAPR.fun_Insertar_MANT_CARAPRED(stFIPRCAPR, stFIPRCAPR, stRESOESTA)
                Else
                    stFIPRDESC = "Caracteristica de predio no existe" & ". Código : " & stFIPRCAPR

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

                End If

            End If

        Next

    End Sub

#End Region

#Region "Validar FiprDeec"

    Private Sub pro_ValidarFiprDeec()

        stFIPRCODI = "301-DESTINO"

        Dim stContenido As String = ""
        Dim i As Integer

        For i = 0 To dt_FIPRDEEC.Rows.Count - 1

            Dim sw1 As Byte = 0
            Dim j1 As Integer = 0

            While j1 < dt_FICHPRED.Rows.Count And sw1 = 0
                If dt_FIPRDEEC.Rows(i).Item("FPDENUFI") = dt_FICHPRED.Rows(j1).Item("FIPRNUFI") Then

                    ' almacena el codigo catastral
                    stFIPRNUFI = dt_FICHPRED.Rows(j1).Item("FIPRNUFI").ToString
                    stFIPRMUNI = dt_FICHPRED.Rows(j1).Item("FIPRMUNI").ToString
                    stFIPRCORR = dt_FICHPRED.Rows(j1).Item("FIPRCORR").ToString
                    stFIPRBARR = dt_FICHPRED.Rows(j1).Item("FIPRBARR").ToString
                    stFIPRMANZ = dt_FICHPRED.Rows(j1).Item("FIPRMANZ").ToString
                    stFIPRPRED = dt_FICHPRED.Rows(j1).Item("FIPRPRED").ToString
                    stFIPREDIF = dt_FICHPRED.Rows(j1).Item("FIPREDIF").ToString
                    stFIPRUNPR = dt_FICHPRED.Rows(j1).Item("FIPRUNPR").ToString
                    stFIPRCLSE = dt_FICHPRED.Rows(j1).Item("FIPRCLSE").ToString

                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            ' valida campo FPDEIDRE
            stContenido = dt_FIPRDEEC.Rows(i).Item("FPDEIDRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo Id registro"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPDEVIGE
            stContenido = dt_FIPRDEEC.Rows(i).Item("FPDEVIGE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo vigencia"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPDETIRE
            stContenido = dt_FIPRDEEC.Rows(i).Item("FPDETIRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo tipo de resolucion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPDERESO
            stContenido = dt_FIPRDEEC.Rows(i).Item("FPDERESO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo resolucion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPDENUFI
            stContenido = dt_FIPRDEEC.Rows(i).Item("FPDENUFI").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo numero de ficha"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPDENURE
            stContenido = dt_FIPRDEEC.Rows(i).Item("FPDENURE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo numero de registro"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPDEDEEC
            stContenido = dt_FIPRDEEC.Rows(i).Item("FPDEDEEC").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo destino economico"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPDEPORC
            stContenido = dt_FIPRDEEC.Rows(i).Item("FPDEPORC").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo porcentaje de destino"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida la lista de valores de ficha predial
            Dim stFPDEDEEC As String = dt_FIPRDEEC.Rows(i).Item("FPDEDEEC").ToString
            
            ' valida la clase o sector
            If fun_Buscar_Dato_DESTECON(stFPDEDEEC) = False Then

                If boPLANSICA = True Then

                    Dim objDESTECON As New cla_DESTECON

                    objDESTECON.fun_Insertar_MANT_DESTECON(stFPDEDEEC, stFPDEDEEC, stRESOESTA)
                Else
                    stFIPRDESC = "Destino económico no existe" & ". Código : " & stFPDEDEEC

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

                End If
                
            End If

        Next

    End Sub

#End Region

#Region "Validar FiprProp"

    Private Sub pro_ValidarFiprProp()

        stFIPRCODI = "401-PROPIETARIO"

        Dim stContenido As String = ""
        Dim i As Integer

        For i = 0 To dt_FIPRPROP.Rows.Count - 1

            Dim sw1 As Byte = 0
            Dim j1 As Integer = 0

            While j1 < dt_FICHPRED.Rows.Count And sw1 = 0
                If dt_FIPRPROP.Rows(i).Item("FPPRNUFI") = dt_FICHPRED.Rows(j1).Item("FIPRNUFI") Then

                    ' almacena el codigo catastral
                    stFIPRNUFI = dt_FICHPRED.Rows(j1).Item("FIPRNUFI").ToString
                    stFIPRMUNI = dt_FICHPRED.Rows(j1).Item("FIPRMUNI").ToString
                    stFIPRCORR = dt_FICHPRED.Rows(j1).Item("FIPRCORR").ToString
                    stFIPRBARR = dt_FICHPRED.Rows(j1).Item("FIPRBARR").ToString
                    stFIPRMANZ = dt_FICHPRED.Rows(j1).Item("FIPRMANZ").ToString
                    stFIPRPRED = dt_FICHPRED.Rows(j1).Item("FIPRPRED").ToString
                    stFIPREDIF = dt_FICHPRED.Rows(j1).Item("FIPREDIF").ToString
                    stFIPRUNPR = dt_FICHPRED.Rows(j1).Item("FIPRUNPR").ToString
                    stFIPRCLSE = dt_FICHPRED.Rows(j1).Item("FIPRCLSE").ToString

                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If

            End While

            ' valida campo FPPRIDRE
            stContenido = dt_FIPRPROP.Rows(i).Item("FPPRIDRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo Id registro"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPPRVIGE
            stContenido = dt_FIPRPROP.Rows(i).Item("FPPRVIGE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo vigencia"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPPRTIRE
            stContenido = dt_FIPRPROP.Rows(i).Item("FPPRTIRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo tipo de resolucion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPPRRESO
            stContenido = dt_FIPRPROP.Rows(i).Item("FPPRRESO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo resolucion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPPRNUFI
            stContenido = dt_FIPRPROP.Rows(i).Item("FPPRNUFI").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo numero de ficha"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPPRNURE
            stContenido = dt_FIPRPROP.Rows(i).Item("FPPRNURE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo numero de registro"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPPRTIDO
            stContenido = dt_FIPRPROP.Rows(i).Item("FPPRTIDO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo clase de documento"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPPRDERE
            stContenido = dt_FIPRPROP.Rows(i).Item("FPPRDERE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo derecho"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPPRESCR
            stContenido = dt_FIPRPROP.Rows(i).Item("FPPRESCR").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo escritura"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPPRTOMO
            stContenido = dt_FIPRPROP.Rows(i).Item("FPPRTOMO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo tomo"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPPRCAPR
            stContenido = Trim(dt_FIPRPROP.Rows(i).Item("FPPRCAPR").ToString)

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo calidad de propietario"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPPRGRAV
            stContenido = dt_FIPRPROP.Rows(i).Item("FPPRGRAV").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo gravable"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPPRMOAD
            stContenido = dt_FIPRPROP.Rows(i).Item("FPPRMOAD").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo modo de adquisicion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPPRLITI
            stContenido = dt_FIPRPROP.Rows(i).Item("FPPRLITI").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo litigio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPPRPOLI
            stContenido = dt_FIPRPROP.Rows(i).Item("FPPRPOLI").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo porcentaje de litigio"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPPRSEXO
            stContenido = dt_FIPRPROP.Rows(i).Item("FPPRSEXO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo sexo"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida la lista de valores de ficha predial
            Dim stFPPRCAPR As String = dt_FIPRPROP.Rows(i).Item("FPPRCAPR").ToString
            Dim stFPPRSEXO As String = dt_FIPRPROP.Rows(i).Item("FPPRSEXO").ToString
            Dim stFPPRTIDO As String = dt_FIPRPROP.Rows(i).Item("FPPRTIDO").ToString
            Dim stFPPRDENO As String = Trim(dt_FIPRPROP.Rows(i).Item("FPPRDENO").ToString)
            Dim stFPPRMUNO As String = Trim(dt_FIPRPROP.Rows(i).Item("FPPRMUNO").ToString)
            Dim stFPPRNOTA As String = Trim(dt_FIPRPROP.Rows(i).Item("FPPRNOTA").ToString)
            Dim stFPPRMOAD As String = dt_FIPRPROP.Rows(i).Item("FPPRMOAD").ToString
            Dim stFPPRLITI As String = dt_FIPRPROP.Rows(i).Item("FPPRLITI").ToString

            ' valida el modo de adquisición
            If fun_Buscar_Dato_MODOADQU(stFPPRMOAD) = False And fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRMOAD) = True Then

                If boPLANSICA = True Then

                    Dim objMODOADQU As New cla_MODOADQU

                    objMODOADQU.fun_Insertar_MANT_MODOADQU(stFPPRMOAD, stFPPRMOAD, stRESOESTA)
                Else
                    stFIPRDESC = "Modo de adquisición no existe" & ". Código : " & stFPPRMOAD

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)
                End If

            End If

            ' valida la calida de propietario
            If fun_Buscar_Dato_CALIPROP(stFPPRCAPR) = False And fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRCAPR) = True Then

                If boPLANSICA = True Then

                    Dim objCALIPROP As New cla_CALIPROP

                    objCALIPROP.fun_Insertar_MANT_CALIPROP(stFPPRCAPR, stFPPRCAPR, stRESOESTA)
                Else
                    stFIPRDESC = "Calidad de propietario no existe" & ". Código : " & stFPPRCAPR

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)
                End If

            End If

            ' valida el genero
            If fun_Buscar_Dato_SEXO(stFPPRSEXO) = False And fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRSEXO) = True Then

                If boPLANSICA = True Then

                    Dim objSEXO As New cla_SEXO

                    objSEXO.fun_Insertar_MANT_SEXO(stFPPRSEXO, stFPPRSEXO, stRESOESTA)
                Else
                    stFIPRDESC = "Genero no existe" & ". Código : " & stFPPRSEXO

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)
                End If

            End If

            ' valida el tipo de documento
            If fun_Buscar_Dato_TIPODOCU(stFPPRTIDO) = False And fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRTIDO) = True Then

                If boPLANSICA = True Then

                    Dim objTIPODOCU As New cla_TIPODOCU

                    objTIPODOCU.fun_Insertar_MANT_TIPODOCU(stFPPRTIDO, stFPPRTIDO, stRESOESTA)
                Else
                    stFIPRDESC = "Clase de documento no existe" & ". Código : " & stFPPRTIDO

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)
                End If

            End If

            ' valida el departamento 
            If fun_Buscar_Dato_DEPARTAMENTO(stFPPRDENO) = False And fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRDENO) = True Then

                If boPLANSICA = True Then

                    Dim objDEPARTAMENTO As New cla_DEPARTAMENTO

                    objDEPARTAMENTO.fun_Insertar_MANT_DEPARTAMENTO(Trim(stFPPRDENO), Trim(stFPPRDENO), stRESOESTA)
                Else
                    stFIPRDESC = "Departamento no existe" & ". Código : " & stFPPRDENO

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)
                End If

            End If

            ' valida el municipio
            If fun_Buscar_Dato_MUNICIPIO(stFPPRDENO, stFPPRMUNO) = False And fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRDENO) = True And fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRMUNO) = True Then

                If boPLANSICA = True Then

                    Dim objMUNICIPIO As New cla_MUNICIPIO

                    objMUNICIPIO.fun_Insertar_MANT_MUNICIPIO(Trim(stFPPRDENO), Trim(stFPPRMUNO), Trim(stFPPRMUNO), 0, 0, Trim(stRESOESTA))

                Else
                    stFIPRDESC = "Municipio no existe" & ". Código : " & stFPPRDENO & "-" & stFPPRMUNO

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)
                End If

            End If

            ' valida la notaria
            If fun_Buscar_Dato_NOTARIA(stFPPRDENO, stFPPRMUNO, stFPPRNOTA) = False And fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRDENO) = True And fun_Verificar_Dato_Numerico_Evento_Validated(stFPPRMUNO) = True Then

                If boPLANSICA = True Then

                    Dim objNOTARIA As New cla_NOTARIA

                    objNOTARIA.fun_Insertar_MANT_NOTARIA(Trim(stFPPRDENO), Trim(stFPPRMUNO), Trim(stFPPRNOTA), Trim(stFPPRNOTA), stRESOESTA)
                Else
                    stFIPRDESC = "Notaria no existe" & ". Código : " & stFPPRDENO & "-" & stFPPRMUNO & "-" & stFPPRNOTA

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)
                End If

            End If

            ' valida el gravable
            If stFPPRLITI <> 1 And stFPPRLITI <> 2 Then
                stFIPRDESC = "Litigio no existe"

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

            stFIPRCODI = "501-CONSTRUCCION"

            Dim sw1 As Byte = 0
            Dim j1 As Integer = 0

            While j1 < dt_FICHPRED.Rows.Count And sw1 = 0
                If dt_FIPRCONS.Rows(i).Item("FPCONUFI") = dt_FICHPRED.Rows(j1).Item("FIPRNUFI") Then

                    ' almacena el codigo catastral
                    stFIPRNUFI = dt_FICHPRED.Rows(j1).Item("FIPRNUFI").ToString
                    stFIPRMUNI = dt_FICHPRED.Rows(j1).Item("FIPRMUNI").ToString
                    stFIPRCORR = dt_FICHPRED.Rows(j1).Item("FIPRCORR").ToString
                    stFIPRBARR = dt_FICHPRED.Rows(j1).Item("FIPRBARR").ToString
                    stFIPRMANZ = dt_FICHPRED.Rows(j1).Item("FIPRMANZ").ToString
                    stFIPRPRED = dt_FICHPRED.Rows(j1).Item("FIPRPRED").ToString
                    stFIPREDIF = dt_FICHPRED.Rows(j1).Item("FIPREDIF").ToString
                    stFIPRUNPR = dt_FICHPRED.Rows(j1).Item("FIPRUNPR").ToString
                    stFIPRCLSE = dt_FICHPRED.Rows(j1).Item("FIPRCLSE").ToString

                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If

            End While

            ' valida campo FPCOIDRE
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOIDRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo Id registro"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOVIGE
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOVIGE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo vigencia"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOTIRE
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOTIRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo tipo de resolucion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCORESO
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCORESO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo resolucion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCONUFI
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCONUFI").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo numero de ficha"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCONURE
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCONURE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo numero de registro"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOUNID
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOUNID").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo nro de construccion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOPUNT
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOPUNT").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo puntos"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOARCO
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOARCO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo area de construccion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOMEJO
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOMEJO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo mejora"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOLEY
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOLEY").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo ley 56"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOTICO
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOTICO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo identificador"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOACUE
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOACUE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo acueducto"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCOTELE
            stContenido = dt_FIPRCONS.Rows(i).Item("FPCOTELE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo telefono"

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
            Dim stFPCOTIPO As String = ""
            Dim stFPCOCLSE As String = stRESOCLSE
            Dim stFPCOTICO As String = dt_FIPRCONS.Rows(i).Item("FPCOTICO").ToString
            Dim stFPCOMEJO As String = dt_FIPRCONS.Rows(i).Item("FPCOMEJO").ToString
            Dim stFPCOLEY As String = dt_FIPRCONS.Rows(i).Item("FPCOLEY").ToString
            Dim stFPCOACUE As String = dt_FIPRCONS.Rows(i).Item("FPCOACUE").ToString

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

            ' valida el tipo de construccion
            If fun_Buscar_Dato_TIPOCONS(stFPCODEPA, stFPCOMUNI, stFPCOCLCO, stFPCOCLSE, stFPCOTICO) = False Then

                If boPLANSICA = True Then

                    ' tipo residencial
                    If Trim(stFPCOTICO) = "001" Or _
                       Trim(stFPCOTICO) = "002" Or _
                       Trim(stFPCOTICO) = "003" Or _
                       Trim(stFPCOTICO) = "014" Or _
                       Trim(stFPCOTICO) = "021" Or _
                       Trim(stFPCOTICO) = "033" Or _
                       Trim(stFPCOTICO) = "036" Or _
                       Trim(stFPCOTICO) = "038" Or _
                       Trim(stFPCOTICO) = "039" Or _
                       Trim(stFPCOTICO) = "040" Or _
                       Trim(stFPCOTICO) = "041" Or _
                       Trim(stFPCOTICO) = "042" Or _
                       Trim(stFPCOTICO) = "043" Or _
                       Trim(stFPCOTICO) = "044" Or _
                       Trim(stFPCOTICO) = "045" Or _
                       Trim(stFPCOTICO) = "046" Or _
                       Trim(stFPCOTICO) = "047" Or _
                       Trim(stFPCOTICO) = "048" Or _
                       Trim(stFPCOTICO) = "049" Or _
                       Trim(stFPCOTICO) = "050" Or _
                       Trim(stFPCOTICO) = "086" Or _
                       Trim(stFPCOTICO) = "087" Or _
                       Trim(stFPCOTICO) = "088" Or _
                       Trim(stFPCOTICO) = "089" Then

                        stFPCOTIPO = "R"

                    End If

                    ' tipo comercial
                    If Trim(stFPCOTICO) = "004" Or _
                       Trim(stFPCOTICO) = "005" Or _
                       Trim(stFPCOTICO) = "007" Or _
                       Trim(stFPCOTICO) = "008" Or _
                       Trim(stFPCOTICO) = "009" Or _
                       Trim(stFPCOTICO) = "013" Or _
                       Trim(stFPCOTICO) = "022" Or _
                       Trim(stFPCOTICO) = "023" Or _
                       Trim(stFPCOTICO) = "027" Or _
                       Trim(stFPCOTICO) = "031" Or _
                       Trim(stFPCOTICO) = "035" Or _
                       Trim(stFPCOTICO) = "051" Or _
                       Trim(stFPCOTICO) = "052" Or _
                       Trim(stFPCOTICO) = "053" Or _
                       Trim(stFPCOTICO) = "054" Or _
                       Trim(stFPCOTICO) = "055" Or _
                       Trim(stFPCOTICO) = "056" Or _
                       Trim(stFPCOTICO) = "057" Or _
                       Trim(stFPCOTICO) = "058" Or _
                       Trim(stFPCOTICO) = "059" Or _
                       Trim(stFPCOTICO) = "060" Or _
                       Trim(stFPCOTICO) = "061" Or _
                       Trim(stFPCOTICO) = "062" Or _
                       Trim(stFPCOTICO) = "063" Or _
                       Trim(stFPCOTICO) = "082" Then

                        stFPCOTIPO = "C"

                    End If

                    ' tipo industrial
                    If Trim(stFPCOTICO) = "006" Or _
                      Trim(stFPCOTICO) = "010" Or _
                      Trim(stFPCOTICO) = "011" Or _
                      Trim(stFPCOTICO) = "012" Or _
                      Trim(stFPCOTICO) = "015" Or _
                      Trim(stFPCOTICO) = "016" Or _
                      Trim(stFPCOTICO) = "017" Or _
                      Trim(stFPCOTICO) = "018" Or _
                      Trim(stFPCOTICO) = "024" Or _
                      Trim(stFPCOTICO) = "026" Or _
                      Trim(stFPCOTICO) = "034" Or _
                      Trim(stFPCOTICO) = "064" Or _
                      Trim(stFPCOTICO) = "065" Or _
                      Trim(stFPCOTICO) = "066" Or _
                      Trim(stFPCOTICO) = "067" Or _
                      Trim(stFPCOTICO) = "068" Or _
                      Trim(stFPCOTICO) = "069" Or _
                      Trim(stFPCOTICO) = "070" Or _
                      Trim(stFPCOTICO) = "071" Or _
                      Trim(stFPCOTICO) = "079" Or _
                      Trim(stFPCOTICO) = "080" Or _
                      Trim(stFPCOTICO) = "081" Or _
                      Trim(stFPCOTICO) = "083" Or _
                      Trim(stFPCOTICO) = "084" Then

                        stFPCOTIPO = "I"

                    End If

                    ' no convencional
                    If Trim(stFPCOTICO) = "019" Or _
                       Trim(stFPCOTICO) = "020" Or _
                       Trim(stFPCOTICO) = "025" Or _
                       Trim(stFPCOTICO) = "028" Or _
                       Trim(stFPCOTICO) = "030" Or _
                       Trim(stFPCOTICO) = "032" Or _
                       Trim(stFPCOTICO) = "037" Or _
                       Trim(stFPCOTICO) = "072" Or _
                       Trim(stFPCOTICO) = "073" Or _
                       Trim(stFPCOTICO) = "074" Or _
                       Trim(stFPCOTICO) = "075" Or _
                       Trim(stFPCOTICO) = "076" Or _
                       Trim(stFPCOTICO) = "077" Or _
                       Trim(stFPCOTICO) = "078" Or _
                       Trim(stFPCOTICO) = "085" Then

                        stFPCOTIPO = "O"

                    End If

                    If Trim(stFPCOTIPO) <> "" Then

                        Dim objTIPOCONS As New cla_TIPOCONS

                        objTIPOCONS.fun_Insertar_MANT_TIPOCONS(stFPCODEPA, stFPCOMUNI, stFPCOCLCO, stFPCOTIPO, stFPCOTICO, stFPCOTICO, 0, 100, 0.0, 0.0, "Ninguno", False, stRESOESTA, stFPCOCLSE, "0.0")

                    End If

                Else
                    stFIPRDESC = "Identificador de construcción no existe" & ". Código : " & stFPCODEPA & "-" & stFPCOMUNI & "-" & stFPCOCLCO & "-" & stFPCOCLSE & "-" & stFPCOTICO

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)
                End If

            End If

            ' valida acueducto
            If stFPCOACUE <> "1" And stFPCOACUE <> "2" Then
                stFIPRDESC = "Acueducto no existe" & ". Código : " & stFPCOACUE

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

            ' valida la mejora
            If stFPCOMEJO <> 1 And stFPCOMEJO <> 2 Then
                stFIPRDESC = "Mejora no existe" & ". Código : " & stFPCOMEJO

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida la ley 56
            If stFPCOLEY <> 1 And stFPCOLEY <> 2 Then
                stFIPRDESC = "Ley 56 no existe" & ". Código : " & stFPCOLEY

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

        Next

    End Sub



#End Region

#Region "Validar FiprCaco"

    Private Sub pro_ValidarFiprCaco()

        stFIPRCODI = "601-CALIFICACION"

        Dim stContenido As String = ""
        Dim i As Integer

        For i = 0 To dt_FIPRCACO.Rows.Count - 1

            Dim sw1 As Byte = 0
            Dim j1 As Integer = 0

            While j1 < dt_FICHPRED.Rows.Count And sw1 = 0
                If dt_FIPRCACO.Rows(i).Item("FPCCNUFI") = dt_FICHPRED.Rows(j1).Item("FIPRNUFI") Then

                    ' almacena el codigo catastral
                    stFIPRNUFI = dt_FICHPRED.Rows(j1).Item("FIPRNUFI").ToString
                    stFIPRMUNI = dt_FICHPRED.Rows(j1).Item("FIPRMUNI").ToString
                    stFIPRCORR = dt_FICHPRED.Rows(j1).Item("FIPRCORR").ToString
                    stFIPRBARR = dt_FICHPRED.Rows(j1).Item("FIPRBARR").ToString
                    stFIPRMANZ = dt_FICHPRED.Rows(j1).Item("FIPRMANZ").ToString
                    stFIPRPRED = dt_FICHPRED.Rows(j1).Item("FIPRPRED").ToString
                    stFIPREDIF = dt_FICHPRED.Rows(j1).Item("FIPREDIF").ToString
                    stFIPRUNPR = dt_FICHPRED.Rows(j1).Item("FIPRUNPR").ToString
                    stFIPRCLSE = dt_FICHPRED.Rows(j1).Item("FIPRCLSE").ToString

                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            ' valida campo FPCCIDRE
            stContenido = dt_FIPRCACO.Rows(i).Item("FPCCIDRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo Id registro"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCCVIGE
            stContenido = dt_FIPRCACO.Rows(i).Item("FPCCVIGE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo vigencia"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCCTIRE
            stContenido = dt_FIPRCACO.Rows(i).Item("FPCCTIRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo tipo de resolucion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCCRESO
            stContenido = dt_FIPRCACO.Rows(i).Item("FPCCRESO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo resolucion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCCNUFI
            stContenido = dt_FIPRCACO.Rows(i).Item("FPCCNUFI").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo numero de ficha"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCCNURE
            stContenido = dt_FIPRCACO.Rows(i).Item("FPCCNURE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo numero de registro"

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

                If boPLANSICA = True Then

                    Dim objTIPOCALI As New cla_TIPOCALI

                    objTIPOCALI.fun_Insertar_MANT_TIPOCALI(stFPCCTIPO, stFPCCTIPO, stRESOESTA)
                Else
                    stFIPRDESC = "Tipo de calificación no existe" & ". Código : " & stFPCCTIPO

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

                End If
              
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

        stFIPRCODI = "701-LINDERO"

        Dim stContenido As String = ""
        Dim i As Integer

        For i = 0 To dt_FIPRLIND.Rows.Count - 1

            Dim sw1 As Byte = 0
            Dim j1 As Integer = 0

            While j1 < dt_FICHPRED.Rows.Count And sw1 = 0
                If dt_FIPRLIND.Rows(i).Item("FPLINUFI") = dt_FICHPRED.Rows(j1).Item("FIPRNUFI") Then

                    ' almacena el codigo catastral
                    stFIPRNUFI = dt_FICHPRED.Rows(j1).Item("FIPRNUFI").ToString
                    stFIPRMUNI = dt_FICHPRED.Rows(j1).Item("FIPRMUNI").ToString
                    stFIPRCORR = dt_FICHPRED.Rows(j1).Item("FIPRCORR").ToString
                    stFIPRBARR = dt_FICHPRED.Rows(j1).Item("FIPRBARR").ToString
                    stFIPRMANZ = dt_FICHPRED.Rows(j1).Item("FIPRMANZ").ToString
                    stFIPRPRED = dt_FICHPRED.Rows(j1).Item("FIPRPRED").ToString
                    stFIPREDIF = dt_FICHPRED.Rows(j1).Item("FIPREDIF").ToString
                    stFIPRUNPR = dt_FICHPRED.Rows(j1).Item("FIPRUNPR").ToString
                    stFIPRCLSE = dt_FICHPRED.Rows(j1).Item("FIPRCLSE").ToString

                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            ' valida campo FPLIIDRE
            stContenido = dt_FIPRLIND.Rows(i).Item("FPLIIDRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo Id registro"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPLIVIGE
            stContenido = dt_FIPRLIND.Rows(i).Item("FPLIVIGE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo vigencia"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPLITIRE
            stContenido = dt_FIPRLIND.Rows(i).Item("FPLITIRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo tipo de resolucion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPLIRESO
            stContenido = dt_FIPRLIND.Rows(i).Item("FPLIRESO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo resolucion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPLINUFI
            stContenido = dt_FIPRLIND.Rows(i).Item("FPLINUFI").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo numero de ficha"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPLINURE
            stContenido = dt_FIPRLIND.Rows(i).Item("FPLINURE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo numero de registro"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida la lista de valores 
            Dim stFPLIPUCA As String = dt_FIPRLIND.Rows(i).Item("FPLIPUCA").ToString

            ' valida la clase o sector
            If fun_Buscar_Dato_PUNTCARD(stFPLIPUCA) = False Then

                If boPLANSICA = True Then

                    Dim objPUNTCARD As New cla_PUNTCARD

                    objPUNTCARD.fun_Insertar_MANT_PUNTCARD(stFPLIPUCA, stFPLIPUCA, stRESOESTA)
                Else
                    stFIPRDESC = "Punto cardinal no existe" & ". Código : " & stFPLIPUCA

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)
                End If
              
            End If

        Next

    End Sub

#End Region

#Region "Validar FiprCart"

    Private Sub pro_ValidarFiprCart()

        stFIPRCODI = "801-CARTOGRAFIA"

        Dim stContenido As String = ""
        Dim i As Integer

        For i = 0 To dt_FIPRCART.Rows.Count - 1

            Dim sw1 As Byte = 0
            Dim j1 As Integer = 0

            While j1 < dt_FICHPRED.Rows.Count And sw1 = 0
                If dt_FIPRCART.Rows(i).Item("FPCANUFI") = dt_FICHPRED.Rows(j1).Item("FIPRNUFI") Then

                    ' almacena el codigo catastral
                    stFIPRNUFI = dt_FICHPRED.Rows(j1).Item("FIPRNUFI").ToString
                    stFIPRMUNI = dt_FICHPRED.Rows(j1).Item("FIPRMUNI").ToString
                    stFIPRCORR = dt_FICHPRED.Rows(j1).Item("FIPRCORR").ToString
                    stFIPRBARR = dt_FICHPRED.Rows(j1).Item("FIPRBARR").ToString
                    stFIPRMANZ = dt_FICHPRED.Rows(j1).Item("FIPRMANZ").ToString
                    stFIPRPRED = dt_FICHPRED.Rows(j1).Item("FIPRPRED").ToString
                    stFIPREDIF = dt_FICHPRED.Rows(j1).Item("FIPREDIF").ToString
                    stFIPRUNPR = dt_FICHPRED.Rows(j1).Item("FIPRUNPR").ToString
                    stFIPRCLSE = dt_FICHPRED.Rows(j1).Item("FIPRCLSE").ToString

                    sw1 = 1
                Else
                    j1 = j1 + 1
                End If
            End While

            ' valida campo FPCAIDRE
            stContenido = dt_FIPRCART.Rows(i).Item("FPCAIDRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo Id registro"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCAVIGE
            stContenido = dt_FIPRCART.Rows(i).Item("FPCAVIGE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo vigencia"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCATIRE
            stContenido = dt_FIPRCART.Rows(i).Item("FPCATIRE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo tipo de resolucion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCARESO
            stContenido = dt_FIPRCART.Rows(i).Item("FPCARESO").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo resolucion"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCANUFI
            stContenido = dt_FIPRCART.Rows(i).Item("FPCANUFI").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo numero de ficha"

                pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

            End If

            ' valida campo FPCANURE
            stContenido = dt_FIPRCART.Rows(i).Item("FPCANURE").ToString

            If fun_Verificar_Dato_Numerico_Evento_Validated(stContenido) = False Then
                stFIPRDESC = "Valor no numèrico campo numero de registro"

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

                If boPLANSICA = True Then

                    Dim objVIGENCIA As New cla_VIGENCIA

                    objVIGENCIA.fun_Insertar_VIGENCIA(stFPCAVIGR, stFPCAVIGR, stRESOESTA)
                Else
                    stFIPRDESC = "Vigencia grafica no existe" & ". Código : " & stFPCAVIGR

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)
                End If

            End If

            ' valida la vigencia aerofotografica
            If fun_Buscar_Dato_VIGENCIA(stFPCAVIAE) = False Then

                If boPLANSICA = True Then

                    Dim objVIGENCIA As New cla_VIGENCIA

                    objVIGENCIA.fun_Insertar_VIGENCIA(stFPCAVIGR, stFPCAVIGR, stRESOESTA)
                Else
                    stFIPRDESC = "Vigencia aerofotografica no existe" & ". Código : " & stFPCAVIAE

                    pro_GrabarInconsistencia(stFIPRCODI, stFIPRDESC)

                End If

            End If

        Next

    End Sub

#End Region

#End Region

End Module
