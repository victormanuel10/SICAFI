Module mod_fun_VERIFICAR_MUNICIPIO_ENCRIPTADO

    '======================================
    '*** VERIFICAR MUNICIPIO ENCRIPTADO ***
    '======================================

#Region "VARIABLES"

    Dim objdatos As New cla_CRIPTOLOGIA
    Dim objRespu As Boolean = False

    Private stMUNIDEPA As String = ""
    Private stMUNICODI As String = ""
    Private inMUNITIRE As Integer = 0
    Private inMUNICLSE As Integer = 0
    Private stMUNICONT As String = ""

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub pro_VerificaSectorUrbano()

        Try
            ' crea nueva instancia
            objdatos = New cla_CRIPTOLOGIA

            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "002" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-002-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "004" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-004-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "021" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-021-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "030" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-030-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "031" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-031-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "034" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-034-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "036" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-036-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "038" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-038-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "040" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-040-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "042" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-042-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "044" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-044-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "045" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-045-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "051" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-051-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "055" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-055-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "059" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-059-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "079" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-079-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "088" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-088-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "086" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-086-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "091" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-091-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "093" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-093-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "101" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-101-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "107" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-107-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "113" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-113-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "120" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-120-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "125" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-125-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "129" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-129-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "134" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-134-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "138" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-138-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "142" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-142-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "145" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-145-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "147" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-147-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "148" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-148-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "150" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-150-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "154" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-154-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "172" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-172-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "190" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-190-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "197" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-197-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "206" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-206-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "209" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-209-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "212" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-212-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "234" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-234-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "237" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-237-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "240" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-240-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "250" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-250-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "607" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-607-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "697" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-697-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "264" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-264-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "266" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-266-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "282" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-282-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "284" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-284-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "306" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-306-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "308" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-308-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "310" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-310-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "313" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-313-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "315" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-315-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "318" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-318-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "321" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-321-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "347" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-347-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "353" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-353-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "360" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-360-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "361" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-361-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "364" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-364-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "368" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-368-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "376" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-376-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "380" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-380-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "390" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-390-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "400" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-400-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "411" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-411-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "425" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-425-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "440" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-440-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "467" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-467-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "475" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-475-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "480" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-480-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "483" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-483-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "495" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-495-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "490" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-490-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "501" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-501-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "541" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-541-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "543" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-543-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "576" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-576-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "579" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-579-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "585" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-585-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "591" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-591-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "604" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-604-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "615" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-615-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "628" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-628-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "631" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-631-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "642" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-642-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "647" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-647-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "649" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-649-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "652" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-652-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "656" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-656-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "658" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-658-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "659" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-659-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "660" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-660-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "664" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-664-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "665" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-665-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "667" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-667-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "670" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-670-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "674" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-674-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "679" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-679-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "686" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-686-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "690" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-690-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "736" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-736-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "756" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-756-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "761" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-761-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "789" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-789-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "790" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-790-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "792" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-792-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "809" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-809-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "819" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-819-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "837" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-837-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "842" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-842-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "847" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-847-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "854" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-854-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "856" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-856-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "858" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-858-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "861" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-861-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "873" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-873-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "885" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-885-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "887" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-887-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "890" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-890-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "893" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-893-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "895" And inMUNITIRE = "184" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-895-184-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If

            ' CONTRASEÑA PARA INTERVENTORIAS

            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "002" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-002-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "004" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-004-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "021" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-021-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "030" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-030-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "031" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-031-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "034" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-034-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "036" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-036-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "038" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-038-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "040" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-040-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "042" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-042-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "044" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-044-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "045" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-045-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "051" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-051-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "055" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-055-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "059" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-059-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "079" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-079-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "088" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-088-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "086" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-086-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "091" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-091-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "093" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-093-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "101" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-101-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "107" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-107-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "113" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-113-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "120" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-120-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "125" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-125-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "129" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-129-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "134" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-134-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "138" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-138-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "142" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-142-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "145" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-145-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "147" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-147-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "148" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-148-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "150" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-150-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "154" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-154-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "172" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-172-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "190" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-190-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "197" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-197-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "206" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-206-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "209" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-209-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "212" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-212-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "234" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-234-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "237" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-237-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "240" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-240-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "250" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-250-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "607" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-607-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "697" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-697-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "264" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-264-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "266" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-266-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "282" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-282-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "284" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-284-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "306" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-306-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "308" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-308-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "310" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-310-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "313" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-313-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "315" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-315-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "318" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-318-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "321" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-321-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "347" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-347-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "353" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-353-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "360" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-360-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "361" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-361-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "364" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-364-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "368" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-368-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "376" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-376-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "380" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-380-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "390" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-390-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "400" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-400-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "411" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-411-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "425" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-425-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "440" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-440-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "467" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-467-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "475" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-475-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "480" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-480-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "483" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-483-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "495" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-495-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "490" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-490-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "501" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-501-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "541" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-541-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "543" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-543-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "576" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-576-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "579" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-579-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "585" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-585-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "591" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-591-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "604" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-604-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "615" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-615-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "628" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-628-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "631" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-631-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "642" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-642-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "647" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-647-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "649" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-649-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "652" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-652-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "656" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-656-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "658" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-658-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "659" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-659-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "660" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-660-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "664" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-664-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "665" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-665-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "667" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-667-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "670" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-670-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "674" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-674-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "679" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-679-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "686" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-686-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "690" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-690-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "736" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-736-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "756" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-756-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "761" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-761-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "789" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-789-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "790" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-790-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "792" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-792-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "809" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-809-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "819" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-819-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "837" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-837-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "842" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-842-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "847" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-847-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "854" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-854-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "856" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-856-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "858" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-858-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "861" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-861-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "873" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-873-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "885" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-885-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "887" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-887-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "890" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-890-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "893" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-893-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "895" And inMUNITIRE = "185" And inMUNICLSE = 1 Then
                If objdatos.Comparar("05-895-185-1", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub
    Private Sub pro_VerificaSectorRural()

        Try
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "002" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-002-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "004" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-004-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "021" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-021-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "030" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-030-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "031" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-031-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "034" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-034-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "036" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-036-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "038" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-038-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "040" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-040-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "042" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-042-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "044" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-044-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "045" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-045-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "051" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-051-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "055" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-055-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "059" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-059-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "079" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-079-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "088" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-088-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "086" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-086-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "091" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-091-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "093" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-093-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "101" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-101-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "107" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-107-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "113" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-113-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "120" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-120-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "125" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-125-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "129" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-129-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "134" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-134-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "138" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-138-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "142" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-142-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "145" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-145-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "147" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-147-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "148" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-148-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "150" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-150-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "154" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-154-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "172" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-172-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "190" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-190-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "197" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-197-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "206" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-206-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "209" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-209-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "212" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-212-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "234" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-234-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "237" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-237-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "240" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-240-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "250" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-250-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "607" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-607-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "697" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-697-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "264" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-264-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "266" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-266-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "282" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-282-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "284" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-284-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "306" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-306-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "308" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-308-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "310" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-310-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "313" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-313-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "315" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-315-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "318" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-318-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "321" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-321-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "347" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-347-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "353" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-353-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "360" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-360-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "361" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-361-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "364" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-364-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "368" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-368-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "376" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-376-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "380" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-380-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "390" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-390-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "400" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-400-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "411" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-411-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "425" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-425-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "440" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-440-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "467" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-467-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "475" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-475-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "480" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-480-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "483" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-483-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "495" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-495-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "490" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-490-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "501" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-501-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "541" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-541-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "543" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-543-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "576" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-576-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "579" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-579-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "585" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-585-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "591" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-591-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "604" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-604-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "615" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-615-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "628" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-628-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "631" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-631-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "642" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-642-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "647" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-647-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "649" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-649-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "652" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-652-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "656" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-656-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "658" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-658-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "659" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-659-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "660" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-660-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "664" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-664-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "665" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-665-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "667" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-667-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "670" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-670-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "674" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-674-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "679" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-679-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "686" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-686-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "690" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-690-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "736" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-736-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "756" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-756-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "761" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-761-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "789" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-789-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "790" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-790-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "792" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-792-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "809" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-809-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "819" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-819-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "837" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-837-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "842" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-842-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "847" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-847-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "854" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-854-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "856" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-856-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "858" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-858-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "861" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-861-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "873" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-873-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "885" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-885-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "887" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-887-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "890" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-890-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "893" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-893-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "895" And inMUNITIRE = "184" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-895-184-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If

            ' CONSTRASEÑAS PARA INTERVENTORIAS

            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "002" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-002-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "004" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-004-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "021" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-021-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "030" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-030-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "031" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-031-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "034" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-034-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "036" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-036-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "038" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-038-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "040" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-040-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "042" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-042-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "044" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-044-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "045" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-045-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "051" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-051-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "055" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-055-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "059" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-059-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "079" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-079-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "088" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-088-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "086" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-086-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "091" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-091-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "093" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-093-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "101" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-101-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "107" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-107-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "113" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-113-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "120" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-120-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "125" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-125-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "129" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-129-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "134" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-134-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "138" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-138-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "142" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-142-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "145" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-145-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "147" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-147-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "148" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-148-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "150" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-150-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "154" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-154-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "172" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-172-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "190" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-190-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "197" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-197-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "206" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-206-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "209" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-209-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "212" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-212-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "234" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-234-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "237" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-237-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "240" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-240-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "250" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-250-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "607" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-607-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "697" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-697-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "264" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-264-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "266" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-266-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "282" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-282-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "284" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-284-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "306" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-306-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "308" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-308-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "310" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-310-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "313" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-313-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "315" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-315-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "318" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-318-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "321" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-321-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "347" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-347-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "353" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-353-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "360" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-360-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "361" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-361-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "364" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-364-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "368" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-368-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "376" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-376-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "380" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-380-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "390" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-390-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "400" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-400-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "411" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-411-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "425" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-425-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "440" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-440-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "467" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-467-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "475" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-475-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "480" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-480-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "483" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-483-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "495" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-495-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "490" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-490-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "501" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-501-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "541" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-541-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "543" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-543-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "576" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-576-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "579" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-579-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "585" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-585-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "591" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-591-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "604" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-604-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "615" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-615-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "628" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-628-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "631" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-631-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "642" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-642-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "647" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-647-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "649" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-649-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "652" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-652-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "656" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-656-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "658" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-658-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "659" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-659-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "660" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-660-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "664" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-664-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "665" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-665-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "667" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-667-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "670" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-670-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "674" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-674-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "679" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-679-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "686" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-686-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "690" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-690-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "736" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-736-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "756" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-756-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "761" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-761-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "789" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-789-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "790" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-790-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "792" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-792-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "809" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-809-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "819" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-819-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "837" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-837-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "842" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-842-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "847" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-847-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "854" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-854-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "856" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-856-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "858" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-858-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "861" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-861-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "873" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-873-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "885" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-885-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "887" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-887-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "890" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-890-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "893" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-893-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If
            If Trim(stMUNIDEPA) = "05" And Trim(stMUNICODI) = "895" And inMUNITIRE = "185" And inMUNICLSE = 2 Then
                If objdatos.Comparar("05-895-185-2", Trim(stMUNICONT)) = True Then
                    objRespu = True
                Else
                    objRespu = False
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try
    End Sub

#End Region

#Region "FUNCIONES"

    Public Function fun_Verificar_Municipio_Encriptado(ByVal o_stMUNIDEPA As String, _
                                                       ByVal o_stMUNICODI As String, _
                                                       ByVal o_inMUNITIRE As Integer, _
                                                       ByVal o_inMUNICLSE As Integer, _
                                                       ByVal o_stMUNICONT As String) As Boolean

        Try
            ' carga las variables
            stMUNIDEPA = o_stMUNIDEPA
            stMUNICODI = o_stMUNICODI
            inMUNITIRE = o_inMUNITIRE
            inMUNICLSE = o_inMUNICLSE
            stMUNICONT = o_stMUNICONT

            '================================================
            '*** VERIFICA LA RESOLUCION DEL SECTOR URBANO ***
            '================================================

            If inMUNICLSE = 1 Then

                pro_VerificaSectorUrbano()

            End If

            '===============================================
            '*** VERIFICA LA RESOLUCION DEL SECTOR RURAL ***
            '===============================================

            If inMUNICLSE = 2 Then

                pro_VerificaSectorRural()

            End If

            Return objRespu

        Catch ex As Exception
            objRespu = False
            MessageBox.Show(Err.Description)
        End Try

    End Function

#End Region

End Module
