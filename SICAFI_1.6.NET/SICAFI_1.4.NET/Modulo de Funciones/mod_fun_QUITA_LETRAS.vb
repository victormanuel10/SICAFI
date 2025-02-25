Module mod_fun_QUITA_LETRAS

    '====================================================
    '*** QUITA LAS LETRAS DE UNA CADENA DE CARACTERES ***
    '====================================================

    Public Function fun_Quita_Letras(ByVal stDATO As String) As String

        Dim inTamano As Integer = stDATO.Length
        Dim stLetra As String = ""
        Dim stResultado As String = ""

        Try
            inTamano = inTamano - 1

            Dim i As Integer

            For i = 0 To inTamano

                stLetra = stDATO.Substring(i, 1)

                If IsNumeric(stLetra) Then
                    stResultado += stLetra
                End If

            Next

            Return stResultado

        Catch ex As Exception
            Return stResultado
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Quita_Letras(ByVal obDATO As Object) As String

        Dim inTamano As Integer = obDATO.Text.ToString.Length
        Dim stLetra As String = ""
        Dim stResultado As String = ""

        Try
            inTamano = inTamano - 1

            Dim i As Integer

            For i = 0 To inTamano

                stLetra = obDATO.Text.ToString.Substring(i, 1)

                If IsNumeric(stLetra) Then
                    stResultado += stLetra
                End If

            Next

            Return stResultado

        Catch ex As Exception
            Return stResultado
            MessageBox.Show(Err.Description)
        End Try

    End Function

End Module
