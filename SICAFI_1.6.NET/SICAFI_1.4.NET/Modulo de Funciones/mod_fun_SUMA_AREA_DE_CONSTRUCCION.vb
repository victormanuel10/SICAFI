Imports REGLAS_DEL_NEGOCIO

Module mod_fun_SUMA_AREA_DE_CONSTRUCCION

    '=================================
    '*** SUMA ÁREA DE CONSTRUCCIÓN ***
    '=================================

    Public Function fun_Suma_Area_De_Construccion(ByVal vl_dt As DataTable) As Decimal

        Try
            Dim deSumaConstruccion As Decimal = 0

            If vl_dt.Rows.Count > 0 Then

                Dim i As Integer

                For i = 0 To vl_dt.Rows.Count - 1

                    Dim stFichaPredial As String = vl_dt.Rows(i).Item("FIPRNUFI")

                    Dim objdatos As New cla_FIPRCONS
                    Dim tbl As New DataTable

                    tbl = objdatos.fun_Consultar_FIPRCONS_X_FICHA_PREDIAL(stFichaPredial)

                    If tbl.Rows.Count > 0 Then

                        Dim k As Integer

                        For k = 0 To tbl.Rows.Count - 1

                            deSumaConstruccion += CType(tbl.Rows(k).Item("FPCOARCO"), Decimal)

                        Next

                    End If

                Next

            End If

            Return deSumaConstruccion

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)

        End Try


    End Function



End Module
