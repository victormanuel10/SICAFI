Imports REGLAS_DEL_NEGOCIO

Module mod_fun_SUMA_AREA_DE_TERRENO

    '============================
    '*** SUMA ÁREA DE TERRENO ***
    '============================

    Public Function fun_Suma_Area_De_Terreno(ByVal vl_dt As DataTable) As Integer

        Try
            Dim inSumaAreaTerreno As Integer = 0

            If vl_dt.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To vl_dt.Rows.Count - 1

                    Dim objdatos As New cla_FICHPRED
                    Dim tbl As New DataTable

                    tbl = objdatos.fun_Consultar_FICHA_PREDIAL_X_NRO_FICHA_PREDIAL(vl_dt.Rows(i).Item("FIPRNUFI"))

                    inSumaAreaTerreno += CType(tbl.Rows(0).Item("FIPRARTE"), Integer)

                Next

            End If

            Return inSumaAreaTerreno

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)

        End Try

    End Function

End Module
