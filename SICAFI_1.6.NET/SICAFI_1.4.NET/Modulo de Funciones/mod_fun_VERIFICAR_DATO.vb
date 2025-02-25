Module mod_fun_VERIFICAR_DATO

    '===============
    ' VERIFICAR DATO
    '===============

    Public Function fun_Verificar_Dato_Decimal_Evento_KeyPress(ByVal KCode As Int16) As Boolean

        If (KCode >= 48 And KCode <= 57) Or _
            KCode = (Keys.Back) Or _
            KCode = 46 Or _
            KCode = (Keys.Enter) Then
            Return True
        Else
            mod_MENSAJE.Inco_Valo_Nume()
            Return False
        End If

        ' 46 = PUNTO

    End Function
    Public Function fun_Verificar_Dato_Fecha_Evento_KeyPress(ByVal KCode As Int16) As Boolean

        If (KCode >= 48 And KCode <= 57) Or _
            KCode = (Keys.Back) Or _
            KCode = 45 Or _
            KCode = (Keys.Enter) Then
            Return True
        Else
            mod_MENSAJE.Inco_Valo_Nume()
            Return False
        End If

        ' 45 = GUION

    End Function
    Public Function fun_Verificar_Dato_Numerico_Evento_KeyPress(ByVal KCode As Int16) As Boolean

        If (KCode >= 48 And KCode <= 57) Or _
            KCode = (Keys.Back) Or _
            KCode = (Keys.Enter) Then
            Return True
        Else
            mod_MENSAJE.Inco_Valo_Nume()
            Return False
        End If

    End Function

    ' Evento que validad los datos ingresados a los campos de los formulario de insertar y modificar
    ' de ficha predial
    Public Function fun_Verificar_Dato_Numerico_Evento_Validated(ByVal stDATO As String) As Boolean

        Try
            Dim boResultado As Boolean = False
            Dim inTamano As Integer = stDATO.Length
            Dim stLetra As String

            Dim sw2, j2 As Integer

            While j2 < inTamano And sw2 = 0

                stLetra = stDATO.Substring(j2, 1)

                If Not IsNumeric(stLetra) Then
                    boResultado = False
                    sw2 = 1
                Else
                    j2 = j2 + 1
                    boResultado = True
                End If
            End While

            Return boResultado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Verificar_Dato_Fecha_Evento_Validated(ByVal stDATO As String) As Boolean

        Try
            Dim boResultado As Boolean = False

            If Not IsDate(stDATO) Then
                boResultado = False
            Else
                boResultado = True
            End If

            Return boResultado

        Catch ex As Exception
            MessageBox.Show(Err.Description)
        End Try

    End Function
    Public Function fun_Verificar_Dato_Decimal_Evento_Validated(ByVal stDATO As String) As Boolean

        Try
            '=================================================
            ' VERIFICA LAS POSICIONES SI SON VALORES NUMERICOS
            '=================================================

            Dim inTamano As Integer = stDATO.Length.ToString
            Dim stLetra As String
            Dim boResultado As Boolean
            Dim boDatoFinal As Double

            ' si esta vacio el dato
            If stDATO = "" Then
                boResultado = True
                stDATO = "0.0"
            End If

            ' contadores para el ciclo mientras
            Dim sw2, j2 As Integer
            ' ciclo mientras con sw
            While j2 < inTamano And sw2 = 0
                ' sustrae la letra de la palabra
                stLetra = stDATO.Substring(j2, 1)
                ' si esta separado por punto
                If stLetra = "." Then
                    stLetra = 0
                End If
                ' verifica si es numerico
                If Not IsNumeric(stLetra) Then
                    ' sale del ciclo mientras
                    boResultado = False
                    sw2 = 1
                Else
                    ' incrementa el contador
                    j2 = j2 + 1
                    boResultado = True
                End If
            End While

            ' verifica si es numerico
            boDatoFinal = stDATO

            Return boResultado

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function

    ' Evento que validad los datos ingresados a los campos de los formulario de insertar y modificar
    ' de ficha predial
    Public Function fun_Extra_Informacion_Antes_del_Signo_Menor(ByVal stDATO As String) As String

        Try
            Dim inTamano As Integer = stDATO.Length
            Dim stLetra As String = ""
            Dim stContenido As String = ""

            Dim sw2, j2 As Integer

            While j2 < inTamano And sw2 = 0

                stLetra = stDATO.Substring(j2, 1)

                If (stLetra) = "<" Then
                    sw2 = 1
                Else
                    j2 = j2 + 1
                    stContenido += stLetra
                End If
            End While

            Return stContenido

        Catch ex As Exception
            Return ""
            MessageBox.Show(Err.Description)
        End Try

    End Function

End Module
