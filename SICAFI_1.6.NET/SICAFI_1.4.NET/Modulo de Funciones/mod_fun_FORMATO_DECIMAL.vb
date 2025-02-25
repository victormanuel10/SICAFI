Module mod_fun_FORMATO_DECIMAL

    ''' <summary>
    '''  Se utiliza para darle formato decimal a un campo alfanumerico
    ''' </summary>
    Public Function fun_Formato_Decimal_2_Decimales(ByVal stDATO As String) As String

        Try
            'Dim stFORMATO As String = "{0:#,###,###,##0.00}"
            Dim stFORMATO As String = "{0:######0.00}"
            Dim doFORMATO As Decimal
            Dim stDATO_FORMATO As String = ""

            If Trim(stDATO) = "" Then
                stDATO = "0.0"
            End If

            doFORMATO = Convert.ToDecimal(stDATO)
            stDATO_FORMATO = String.Format(stFORMATO, doFORMATO)

            Return stDATO_FORMATO

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Formato_Decimal_3_Decimales(ByVal stDATO As String) As String

        Try
            'Dim stFORMATO As String = "{0:#,###,###,##0.00}"
            Dim stFORMATO As String = "{0:######0.000}"
            Dim doFORMATO As Decimal
            Dim stDATO_FORMATO As String = ""

            If Trim(stDATO) = "" Then
                stDATO = "0.0"
            End If

            doFORMATO = Convert.ToDecimal(stDATO)
            stDATO_FORMATO = String.Format(stFORMATO, doFORMATO)

            Return stDATO_FORMATO

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Formato_Decimal_4_Decimales(ByVal stDATO As String) As String

        Try
            'Dim stFORMATO As String = "{0:#,###,###,##0.0000}"
            Dim stFORMATO As String = "{0:######0.0000}"
            Dim doFORMATO As Decimal
            Dim stDATO_FORMATO As String = ""

            If Trim(stDATO) = "" Then
                stDATO = "0.0"
            End If

            doFORMATO = Convert.ToDecimal(stDATO)
            stDATO_FORMATO = String.Format(stFORMATO, doFORMATO)

            Return stDATO_FORMATO

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Formato_Decimal_6_Decimales(ByVal stDATO As String) As String

        Try
            'Dim stFORMATO As String = "{0:#,###,###,##0.000000}"
            Dim stFORMATO As String = "{0:######0.000000}"
            Dim doFORMATO As Decimal
            Dim stDATO_FORMATO As String = ""

            If Trim(stDATO) = "" Then
                stDATO = "0.0"
            End If

            doFORMATO = Convert.ToDecimal(stDATO)
            stDATO_FORMATO = String.Format(stFORMATO, doFORMATO)

            Return stDATO_FORMATO

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Formato_Decimal_9_Decimales(ByVal stDATO As String) As String

        Try
            'Dim stFORMATO As String = "{0:#,###,###,##0.000000000}"
            Dim stFORMATO As String = "{0:######0.000000000}"
            Dim doFORMATO As Decimal
            Dim stDATO_FORMATO As String = ""

            If Trim(stDATO) = "" Then
                stDATO = "0.0"
            End If

            doFORMATO = Convert.ToDecimal(stDATO)
            stDATO_FORMATO = String.Format(stFORMATO, doFORMATO)

            Return stDATO_FORMATO

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function

    ''' <summary>
    '''  Se utiliza cuando el dato se sabe que numerico
    ''' </summary>
    Public Function fun_Formato_Mascara_2_Reales(ByVal stDATO As String) As String

        Try
            Dim stFORMATO As String = "{0:00}"
            Dim inFORMATO As Integer
            Dim stDATO_FORMATO As String = ""

            If Trim(stDATO) = "" Then
                stDATO = "0"
            End If

            inFORMATO = CType(stDATO, Integer)
            stDATO_FORMATO = String.Format(stFORMATO, inFORMATO)

            Return stDATO_FORMATO

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Formato_Mascara_3_Reales(ByVal stDATO As String) As String

        Try
            Dim stFORMATO As String = "{0:000}"
            Dim inFORMATO As Integer
            Dim stDATO_FORMATO As String = ""

            If Trim(stDATO) = "" Then
                stDATO = "0"
            End If

            inFORMATO = CType(stDATO, Integer)
            stDATO_FORMATO = String.Format(stFORMATO, inFORMATO)

            Return stDATO_FORMATO

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Formato_Mascara_4_Reales(ByVal stDATO As String) As String

        Try
            Dim stFORMATO As String = "{0:0000}"
            Dim inFORMATO As Integer
            Dim stDATO_FORMATO As String = ""

            If Trim(stDATO) = "" Then
                stDATO = "0"
            End If

            inFORMATO = CType(stDATO, Integer)
            stDATO_FORMATO = String.Format(stFORMATO, inFORMATO)

            Return stDATO_FORMATO

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Formato_Mascara_5_Reales(ByVal stDATO As String) As String

        Try
            Dim stFORMATO As String = "{0:00000}"
            Dim inFORMATO As Integer
            Dim stDATO_FORMATO As String = ""

            If Trim(stDATO) = "" Then
                stDATO = "0"
            End If

            inFORMATO = CType(stDATO, Integer)
            stDATO_FORMATO = String.Format(stFORMATO, inFORMATO)

            Return stDATO_FORMATO

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Formato_Mascara_7_Reales(ByVal stDATO As String) As String

        Try
            Dim stFORMATO As String = "{0:0000000}"
            Dim inFORMATO As Integer
            Dim stDATO_FORMATO As String = ""

            If Trim(stDATO) = "" Then
                stDATO = "0"
            End If

            inFORMATO = CType(stDATO, Integer)
            stDATO_FORMATO = String.Format(stFORMATO, inFORMATO)

            Return stDATO_FORMATO

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Formato_Mascara_9_Reales(ByVal stDATO As String) As String

        Try
            Dim stFORMATO As String = "{0:000000000}"
            Dim inFORMATO As Integer
            Dim stDATO_FORMATO As String = ""

            If Trim(stDATO) = "" Then
                stDATO = "0"
            End If

            inFORMATO = CType(stDATO, Integer)
            stDATO_FORMATO = String.Format(stFORMATO, inFORMATO)

            Return stDATO_FORMATO

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function


    ''' <summary>
    '''  Se utiliza cuando se sabe que es caracter y se tiene que validar 
    '''  primero para darle el formato.
    ''' </summary>
    Public Function fun_Formato_Mascara_2_String(ByVal stDATO As String) As String

        Try
            Dim stFORMATO As String = "{0:00}"
            Dim inFORMATO As Integer
            Dim stDATO_FORMATO As String = ""

            If Trim(stDATO) = "" Then
                stDATO = "0"
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(stDATO) = True Then
                inFORMATO = CType(stDATO, Integer)
                stDATO_FORMATO = String.Format(stFORMATO, inFORMATO)
            Else
                stDATO_FORMATO = stDATO
            End If

            Return stDATO_FORMATO

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Formato_Mascara_3_String(ByVal stDATO As String) As String

        Try
            Dim stFORMATO As String = "{0:000}"
            Dim inFORMATO As Integer
            Dim stDATO_FORMATO As String = ""

            If Trim(stDATO) = "" Then
                stDATO = "0"
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(stDATO) = True Then
                inFORMATO = CType(stDATO, Integer)
                stDATO_FORMATO = String.Format(stFORMATO, inFORMATO)
            Else
                stDATO_FORMATO = stDATO
            End If

            Return stDATO_FORMATO

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Formato_Mascara_4_String(ByVal stDATO As String) As String

        Try
            Dim stFORMATO As String = "{0:0000}"
            Dim inFORMATO As Integer
            Dim stDATO_FORMATO As String = ""

            If Trim(stDATO) = "" Then
                stDATO = "0"
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(stDATO) = True Then
                inFORMATO = CType(stDATO, Integer)
                stDATO_FORMATO = String.Format(stFORMATO, inFORMATO)
            Else
                stDATO_FORMATO = stDATO
            End If

            Return stDATO_FORMATO

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Formato_Mascara_5_String(ByVal stDATO As String) As String

        Try
            Dim stFORMATO As String = "{0:00000}"
            Dim inFORMATO As Integer
            Dim stDATO_FORMATO As String = ""

            If Trim(stDATO) = "" Then
                stDATO = "0"
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(stDATO) = True Then
                inFORMATO = CType(stDATO, Integer)
                stDATO_FORMATO = String.Format(stFORMATO, inFORMATO)
            Else
                stDATO_FORMATO = stDATO
            End If

            Return stDATO_FORMATO

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Formato_Mascara_7_String(ByVal stDATO As String) As String

        Try
            Dim stFORMATO As String = "{0:0000000}"
            Dim inFORMATO As Integer
            Dim stDATO_FORMATO As String = ""

            If Trim(stDATO) = "" Then
                stDATO = "0"
            End If

            If fun_Verificar_Dato_Numerico_Evento_Validated(stDATO) = True Then
                inFORMATO = CType(stDATO, Integer)
                stDATO_FORMATO = String.Format(stFORMATO, inFORMATO)
            Else
                stDATO_FORMATO = stDATO
            End If

            Return stDATO_FORMATO

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function

    ''' <summary>
    '''  Se utiliza para dar formato de pesos a un dato numerico o decimal
    ''' </summary>
    Public Function fun_Formato_Mascara_Pesos(ByVal stDATO As String) As String

        Try
            Dim stFORMATO As String = "{0:#,###,###,##0.00}"
            'Dim stFORMATO As String = "{0:######0.00}"
            Dim doFORMATO As Decimal
            Dim stDATO_FORMATO As String = ""

            If Trim(stDATO) = "" Then
                stDATO = "0.0"
            End If

            doFORMATO = Convert.ToDecimal(stDATO)
            stDATO_FORMATO = String.Format(stFORMATO, doFORMATO)

            Return stDATO_FORMATO

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function
    ''' <summary>
    '''  Se utiliza para dar formato de pesos a un dato numerico o decimal
    ''' </summary>
    Public Function fun_Formato_Mascara_Pesos_Enteros(ByVal stDATO As String) As String

        Try
            Dim stFORMATO As String = "{0:#,###,###,##0}"
            'Dim stFORMATO As String = "{0:######0.00}"
            Dim doFORMATO As Decimal
            Dim stDATO_FORMATO As String = ""

            If Trim(stDATO) = "" Then
                stDATO = "0.0"
            End If

            doFORMATO = Convert.ToDecimal(stDATO)
            stDATO_FORMATO = String.Format(stFORMATO, doFORMATO)

            Return stDATO_FORMATO

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function


End Module
