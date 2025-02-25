Module mod_fun_HORA_Y_FECHA

    Public Function fun_Hora_y_fecha() As Date

        Try

            Dim dateNow As DateTime = DateTime.Now
            Dim daFECHA As Date = DateTime.Now.ToString()

            Return daFECHA

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function

    Public Function fun_fecha() As Date

        Try

            Dim dateNow As DateTime = DateTime.Now
            Dim daFECHA As Date = dateNow.Date

            Return daFECHA

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function

End Module
