Module mod_pro_ASIGNAR_RANGO_MUNICIPIO

    '=====================================
    '*** ASIGNA EL RANGO DEL MUNICIPIO ***
    '=====================================

    Public Sub pro_Asigna_Rango_Ficha_Municipio(ByVal stCodigoMunicipio As String, _
                                                ByRef inRangoInicial As Integer, _
                                                ByRef inRangoFinal As Integer)


        Try
            If stCodigoMunicipio = "002" Then
                inRangoInicial = 1
                inRangoFinal = 200000
            End If
            If stCodigoMunicipio = "004" Then
                inRangoInicial = 200001
                inRangoFinal = 400000
            End If
            If stCodigoMunicipio = "021" Then
                inRangoInicial = 400001
                inRangoFinal = 600000
            End If
            If stCodigoMunicipio = "030" Then
                inRangoInicial = 600001
                inRangoFinal = 800000
            End If
            If stCodigoMunicipio = "031" Then
                inRangoInicial = 800001
                inRangoFinal = 1000000
            End If
            If stCodigoMunicipio = "034" Then
                inRangoInicial = 1000001
                inRangoFinal = 1200000
            End If
            If stCodigoMunicipio = "036" Then
                inRangoInicial = 1200001
                inRangoFinal = 1400000
            End If
            If stCodigoMunicipio = "038" Then
                inRangoInicial = 1400001
                inRangoFinal = 1600000
            End If
            If stCodigoMunicipio = "040" Then
                inRangoInicial = 1600001
                inRangoFinal = 1800000
            End If
            If stCodigoMunicipio = "042" Then
                inRangoInicial = 1800001
                inRangoFinal = 2000000
            End If
            If stCodigoMunicipio = "044" Then
                inRangoInicial = 2000001
                inRangoFinal = 2200000
            End If
            If stCodigoMunicipio = "045" Then
                inRangoInicial = 2200001
                inRangoFinal = 2400000
            End If
            If stCodigoMunicipio = "051" Then
                inRangoInicial = 2400001
                inRangoFinal = 2600000
            End If
            If stCodigoMunicipio = "055" Then
                inRangoInicial = 2600001
                inRangoFinal = 2800000
            End If
            If stCodigoMunicipio = "059" Then
                inRangoInicial = 2800001
                inRangoFinal = 3000000
            End If
            If stCodigoMunicipio = "079" Then
                inRangoInicial = 3000001
                inRangoFinal = 3200000
            End If
            If stCodigoMunicipio = "088" Then
                inRangoInicial = 3200001
                inRangoFinal = 3700000
            End If
            If stCodigoMunicipio = "086" Then
                inRangoInicial = 3700001
                inRangoFinal = 3900000
            End If
            If stCodigoMunicipio = "091" Then
                inRangoInicial = 3900001
                inRangoFinal = 4100000
            End If
            If stCodigoMunicipio = "093" Then
                inRangoInicial = 4100001
                inRangoFinal = 4300000
            End If
            If stCodigoMunicipio = "101" Then
                inRangoInicial = 4300001
                inRangoFinal = 4500000
            End If
            If stCodigoMunicipio = "107" Then
                inRangoInicial = 4500001
                inRangoFinal = 4700000
            End If
            If stCodigoMunicipio = "113" Then
                inRangoInicial = 4700001
                inRangoFinal = 4900000
            End If
            If stCodigoMunicipio = "120" Then
                inRangoInicial = 4900001
                inRangoFinal = 5100000
            End If
            If stCodigoMunicipio = "125" Then
                inRangoInicial = 5100001
                inRangoFinal = 5300000
            End If
            If stCodigoMunicipio = "129" Then
                inRangoInicial = 5300001
                inRangoFinal = 5500000
            End If
            If stCodigoMunicipio = "134" Then
                inRangoInicial = 5500001
                inRangoFinal = 5700000
            End If
            If stCodigoMunicipio = "138" Then
                inRangoInicial = 5700001
                inRangoFinal = 5900000
            End If
            If stCodigoMunicipio = "142" Then
                inRangoInicial = 5900001
                inRangoFinal = 6100000
            End If
            If stCodigoMunicipio = "145" Then
                inRangoInicial = 6100001
                inRangoFinal = 6300000
            End If
            If stCodigoMunicipio = "147" Then
                inRangoInicial = 6300001
                inRangoFinal = 6500000
            End If
            If stCodigoMunicipio = "148" Then
                inRangoInicial = 6500001
                inRangoFinal = 6700000
            End If
            If stCodigoMunicipio = "150" Then
                inRangoInicial = 6700001
                inRangoFinal = 6900000
            End If
            If stCodigoMunicipio = "154" Then
                inRangoInicial = 6900001
                inRangoFinal = 7100000
            End If
            If stCodigoMunicipio = "172" Then
                inRangoInicial = 7100001
                inRangoFinal = 7300000
            End If
            If stCodigoMunicipio = "190" Then
                inRangoInicial = 7300001
                inRangoFinal = 7500000
            End If
            If stCodigoMunicipio = "197" Then
                inRangoInicial = 7500001
                inRangoFinal = 7700000
            End If
            If stCodigoMunicipio = "206" Then
                inRangoInicial = 7700001
                inRangoFinal = 7900000
            End If
            If stCodigoMunicipio = "209" Then
                inRangoInicial = 7900001
                inRangoFinal = 8100000
            End If
            If stCodigoMunicipio = "212" Then
                inRangoInicial = 8100001
                inRangoFinal = 8300000
            End If
            If stCodigoMunicipio = "234" Then
                inRangoInicial = 8300001
                inRangoFinal = 8500000
            End If
            If stCodigoMunicipio = "237" Then
                inRangoInicial = 8500001
                inRangoFinal = 8700000
            End If
            If stCodigoMunicipio = "240" Then
                inRangoInicial = 8700001
                inRangoFinal = 8900000
            End If
            If stCodigoMunicipio = "250" Then
                inRangoInicial = 8900001
                inRangoFinal = 9100000
            End If
            If stCodigoMunicipio = "607" Then
                inRangoInicial = 9100001
                inRangoFinal = 9300000
            End If
            If stCodigoMunicipio = "697" Then
                inRangoInicial = 9300001
                inRangoFinal = 9500000
            End If
            If stCodigoMunicipio = "264" Then
                inRangoInicial = 9500001
                inRangoFinal = 9700000
            End If
            If stCodigoMunicipio = "266" Then
                inRangoInicial = 9700001
                inRangoFinal = 10200000
            End If
            If stCodigoMunicipio = "282" Then
                inRangoInicial = 10200001
                inRangoFinal = 10400000
            End If
            If stCodigoMunicipio = "284" Then
                inRangoInicial = 10400001
                inRangoFinal = 10600000
            End If
            If stCodigoMunicipio = "306" Then
                inRangoInicial = 10600001
                inRangoFinal = 10800000
            End If
            If stCodigoMunicipio = "308" Then
                inRangoInicial = 10800001
                inRangoFinal = 11000000
            End If
            If stCodigoMunicipio = "310" Then
                inRangoInicial = 11000001
                inRangoFinal = 11200000
            End If
            If stCodigoMunicipio = "313" Then
                inRangoInicial = 11200001
                inRangoFinal = 11400000
            End If
            If stCodigoMunicipio = "315" Then
                inRangoInicial = 11400001
                inRangoFinal = 11600000
            End If
            If stCodigoMunicipio = "318" Then
                inRangoInicial = 11600001
                inRangoFinal = 11800000
            End If
            If stCodigoMunicipio = "321" Then
                inRangoInicial = 11800001
                inRangoFinal = 12000000
            End If
            If stCodigoMunicipio = "347" Then
                inRangoInicial = 12000001
                inRangoFinal = 12200000
            End If
            If stCodigoMunicipio = "353" Then
                inRangoInicial = 12200001
                inRangoFinal = 12400000
            End If
            If stCodigoMunicipio = "360" Then
                inRangoInicial = 12400001
                inRangoFinal = 12900000
            End If
            If stCodigoMunicipio = "361" Then
                inRangoInicial = 12900001
                inRangoFinal = 13100000
            End If
            If stCodigoMunicipio = "364" Then
                inRangoInicial = 13100001
                inRangoFinal = 13300000
            End If
            If stCodigoMunicipio = "368" Then
                inRangoInicial = 13300001
                inRangoFinal = 13500000
            End If
            If stCodigoMunicipio = "376" Then
                inRangoInicial = 13500001
                inRangoFinal = 13700000
            End If
            If stCodigoMunicipio = "380" Then
                inRangoInicial = 13700001
                inRangoFinal = 13900000
            End If
            If stCodigoMunicipio = "390" Then
                inRangoInicial = 13900001
                inRangoFinal = 14100000
            End If
            If stCodigoMunicipio = "400" Then
                inRangoInicial = 14100001
                inRangoFinal = 14300000
            End If
            If stCodigoMunicipio = "411" Then
                inRangoInicial = 14300001
                inRangoFinal = 14500000
            End If
            If stCodigoMunicipio = "425" Then
                inRangoInicial = 14500001
                inRangoFinal = 14700000
            End If
            If stCodigoMunicipio = "440" Then
                inRangoInicial = 14700001
                inRangoFinal = 14900000
            End If
            If stCodigoMunicipio = "467" Then
                inRangoInicial = 14900001
                inRangoFinal = 15100000
            End If
            If stCodigoMunicipio = "475" Then
                inRangoInicial = 15100001
                inRangoFinal = 15300000
            End If
            If stCodigoMunicipio = "480" Then
                inRangoInicial = 15300001
                inRangoFinal = 15500000
            End If
            If stCodigoMunicipio = "483" Then
                inRangoInicial = 15500001
                inRangoFinal = 15700000
            End If
            If stCodigoMunicipio = "495" Then
                inRangoInicial = 15700001
                inRangoFinal = 15900000
            End If
            If stCodigoMunicipio = "490" Then
                inRangoInicial = 15900001
                inRangoFinal = 16100000
            End If
            If stCodigoMunicipio = "501" Then
                inRangoInicial = 16100001
                inRangoFinal = 16300000
            End If
            If stCodigoMunicipio = "541" Then
                inRangoInicial = 16300001
                inRangoFinal = 16500000
            End If
            If stCodigoMunicipio = "543" Then
                inRangoInicial = 16500001
                inRangoFinal = 16700000
            End If
            If stCodigoMunicipio = "576" Then
                inRangoInicial = 16700001
                inRangoFinal = 16900000
            End If
            If stCodigoMunicipio = "579" Then
                inRangoInicial = 16900001
                inRangoFinal = 17100000
            End If
            If stCodigoMunicipio = "587" Then
                inRangoInicial = 17100001
                inRangoFinal = 17300000
            End If
            If stCodigoMunicipio = "591" Then
                inRangoInicial = 17300001
                inRangoFinal = 17500000
            End If
            If stCodigoMunicipio = "604" Then
                inRangoInicial = 17500001
                inRangoFinal = 17700000
            End If
            If stCodigoMunicipio = "615" Then
                inRangoInicial = 17700001
                inRangoFinal = 17900000
            End If
            If stCodigoMunicipio = "628" Then
                inRangoInicial = 17900001
                inRangoFinal = 18100000
            End If
            If stCodigoMunicipio = "631" Then
                inRangoInicial = 18100001
                inRangoFinal = 18300000
            End If
            If stCodigoMunicipio = "642" Then
                inRangoInicial = 18300001
                inRangoFinal = 18500000
            End If
            If stCodigoMunicipio = "647" Then
                inRangoInicial = 18500001
                inRangoFinal = 18700000
            End If
            If stCodigoMunicipio = "649" Then
                inRangoInicial = 18700001
                inRangoFinal = 18900000
            End If
            If stCodigoMunicipio = "652" Then
                inRangoInicial = 18900001
                inRangoFinal = 19100000
            End If
            If stCodigoMunicipio = "656" Then
                inRangoInicial = 19100001
                inRangoFinal = 19300000
            End If
            If stCodigoMunicipio = "658" Then
                inRangoInicial = 19300001
                inRangoFinal = 19500000
            End If
            If stCodigoMunicipio = "659" Then
                inRangoInicial = 19500001
                inRangoFinal = 19700000
            End If
            If stCodigoMunicipio = "660" Then
                inRangoInicial = 19700001
                inRangoFinal = 19900000
            End If
            If stCodigoMunicipio = "664" Then
                inRangoInicial = 19900001
                inRangoFinal = 20100000
            End If
            If stCodigoMunicipio = "665" Then
                inRangoInicial = 20100001
                inRangoFinal = 20300000
            End If
            If stCodigoMunicipio = "667" Then
                inRangoInicial = 20300001
                inRangoFinal = 20500000
            End If
            If stCodigoMunicipio = "670" Then
                inRangoInicial = 20500001
                inRangoFinal = 20700000
            End If
            If stCodigoMunicipio = "674" Then
                inRangoInicial = 20700001
                inRangoFinal = 20900000
            End If
            If stCodigoMunicipio = "679" Then
                inRangoInicial = 20900001
                inRangoFinal = 21100000
            End If
            If stCodigoMunicipio = "686" Then
                inRangoInicial = 21300001
                inRangoFinal = 21500000
            End If
            If stCodigoMunicipio = "690" Then
                inRangoInicial = 21500001
                inRangoFinal = 21700000
            End If
            If stCodigoMunicipio = "736" Then
                inRangoInicial = 21700001
                inRangoFinal = 21900000
            End If
            If stCodigoMunicipio = "756" Then
                inRangoInicial = 21900001
                inRangoFinal = 22100000
            End If
            If stCodigoMunicipio = "761" Then
                inRangoInicial = 22100001
                inRangoFinal = 22300000
            End If
            If stCodigoMunicipio = "789" Then
                inRangoInicial = 22300001
                inRangoFinal = 22500000
            End If
            If stCodigoMunicipio = "790" Then
                inRangoInicial = 22500001
                inRangoFinal = 22700000
            End If
            If stCodigoMunicipio = "792" Then
                inRangoInicial = 22700001
                inRangoFinal = 22900000
            End If
            If stCodigoMunicipio = "809" Then
                inRangoInicial = 22900001
                inRangoFinal = 23100000
            End If
            If stCodigoMunicipio = "819" Then
                inRangoInicial = 23100001
                inRangoFinal = 23300000
            End If
            If stCodigoMunicipio = "837" Then
                inRangoInicial = 23300001
                inRangoFinal = 23500000
            End If
            If stCodigoMunicipio = "842" Then
                inRangoInicial = 23500001
                inRangoFinal = 23700000
            End If
            If stCodigoMunicipio = "847" Then
                inRangoInicial = 23700001
                inRangoFinal = 23900000
            End If
            If stCodigoMunicipio = "854" Then
                inRangoInicial = 23900001
                inRangoFinal = 24100000
            End If
            If stCodigoMunicipio = "856" Then
                inRangoInicial = 24100001
                inRangoFinal = 24300000
            End If
            If stCodigoMunicipio = "858" Then
                inRangoInicial = 24300001
                inRangoFinal = 24500000
            End If
            If stCodigoMunicipio = "861" Then
                inRangoInicial = 24500001
                inRangoFinal = 24700000
            End If
            If stCodigoMunicipio = "873" Then
                inRangoInicial = 24700001
                inRangoFinal = 24900000
            End If
            If stCodigoMunicipio = "885" Then
                inRangoInicial = 24900001
                inRangoFinal = 25100000
            End If
            If stCodigoMunicipio = "887" Then
                inRangoInicial = 25100001
                inRangoFinal = 25300000
            End If
            If stCodigoMunicipio = "890" Then
                inRangoInicial = 25300001
                inRangoFinal = 25500000
            End If
            If stCodigoMunicipio = "893" Then
                inRangoInicial = 25500001
                inRangoFinal = 25700000
            End If
            If stCodigoMunicipio = "895" Then
                inRangoInicial = 25700001
                inRangoFinal = 25900000
            End If

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Sub

End Module
