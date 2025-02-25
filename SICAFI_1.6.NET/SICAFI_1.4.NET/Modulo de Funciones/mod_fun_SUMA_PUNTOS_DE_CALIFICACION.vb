Imports REGLAS_DEL_NEGOCIO

Module mod_fun_SUMA_PUNTOS_DE_CALIFICACION

    '===================================
    '*** SUMA PUNTOS DE CALIFICACION ***
    '===================================

    Public Function fun_Suma_Puntos_De_Calificacion(ByVal vl_dt As DataTable) As Integer

        Try
            Dim inSumaPuntos As Integer = 0

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

                            inSumaPuntos += CType(tbl.Rows(k).Item("FPCOPUNT"), Integer)

                        Next

                    End If

                Next

            End If

            Return inSumaPuntos

        Catch ex As Exception
            Return Nothing
            MessageBox.Show(Err.Description)

        End Try


    End Function

End Module
