Public Class cla_Verificar_Dato

    ' Funciones nueva version 5.1

    ''' <summary>
    ''' Verifica el dato numerico.
    ''' </summary>
    Public Function fun_Verificar_Dato_Numerico(ByVal stDATO As String) As Boolean

        Try
            ' declara las variables
            Dim inTamanoCampo As Integer = stDATO.Length
            Dim stPosicionDato As String = ""
            Dim boResultado As Boolean = False

            Dim sw2, j2 As Integer

            ' recorre el dato
            While j2 < inTamanoCampo And sw2 = 0

                stPosicionDato = stDATO.Substring(j2, 1)

                ' verifica que el dato sea nuemrico
                If Not IsNumeric(stPosicionDato) Then
                    boResultado = False
                    sw2 = 1
                Else
                    j2 = j2 + 1
                    boResultado = True
                End If

            End While

            ' retorna el resultado
            Return boResultado

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function

    ''' <summary>
    ''' Verifica el dato decimal.
    ''' </summary>
    Public Function fun_Verificar_Dato_Decimal(ByVal stDATO As String) As Boolean

        Try
            ' declara las variables
            Dim inTamano As Integer = stDATO.Length.ToString
            Dim stLetra As String = ""
            Dim boResultado As Boolean = False
            Dim boDatoFinal As Double = 0.0
            Dim inContadorPuntos As Integer = 0

            ' verifica si el dato es ta vacio
            If stDATO = "" Then
                boResultado = True
                stDATO = "0.0"
            End If

            ' recorre el dato mediante un ciclo
            Dim sw2, j2 As Integer

            While j2 < inTamano And sw2 = 0

                ' almacela el dato individual mediante la posición
                stLetra = stDATO.Substring(j2, 1)

                ' verifica si el dato es un punto
                If stLetra = "." Then

                    ' cuanta los puntos
                    inContadorPuntos += 1

                    ' valida la cantidad de puntos y el dato no sea un solo punto
                    If (inContadorPuntos > 1) Or (inContadorPuntos = 1 And inTamano = 1) Then
                        boResultado = False
                        sw2 = 1
                    Else
                        ' declara si el es primer punto
                        stLetra = 0
                    End If

                End If

                ' verifica que el dato sea numerico
                If Not IsNumeric(stLetra) Then
                    boResultado = False
                    sw2 = 1
                Else
                    j2 = j2 + 1
                    boResultado = True
                End If

            End While

            ' revuelve el resultado
            Return boResultado

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function

    ''' <summary>
    ''' Verifica el dato fecha.
    ''' </summary>
    Public Function fun_Verificar_Dato_Fecha(ByVal stDATO As String) As Boolean

        Try
           
            Dim boResultado As Boolean = False
          
            If Not IsDate(Trim(stDATO)) Then
                boResultado = False
            Else
                boResultado = True
            End If

            ' revuelve el resultado
            Return boResultado

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function


    ''' <summary>
    ''' Verifica que el dato este vacio mediante el text.
    ''' </summary>
    Public Function fun_Verificar_Campo_Lleno(ByVal stCAMPO As String) As Boolean

        Try
            If Trim(stCAMPO) = "" Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try
    End Function

    ''' <summary>
    ''' Verifica que el dato este vacio mediante un objeto.
    ''' </summary>
    Public Function fun_Verificar_Dato_Lleno(ByVal obCAMPO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            If Trim(obCAMPO.Text) = "" Then
                MessageBox.Show("El campo " & obCAMPO.AccessibleDescription & " esta vacio.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                obCAMPO.Focus()
                boRespuesta = False
            Else
                boRespuesta = True
            End If

            Return boRespuesta

        Catch ex As Exception
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Verifica que el dato este vacio y entero mediante un objeto.
    ''' </summary>
    Public Function fun_Verificar_Dato_Vacio_Y_Numerico(ByVal obCAMPO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            If fun_Verificar_Campo_Lleno(obCAMPO.Text) = False Then
                MessageBox.Show("El campo " & obCAMPO.AccessibleDescription & " esta vacio.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                obCAMPO.Focus()
                boRespuesta = False
            Else
                If fun_Verificar_Dato_Numerico(obCAMPO.Text) = False Then
                    MessageBox.Show("El campo " & obCAMPO.AccessibleDescription & " no es numerico.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    obCAMPO.Focus()
                    boRespuesta = False
                Else
                    boRespuesta = True
                End If
            End If

            Return boRespuesta

        Catch ex As Exception
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Verifica que el dato este vacio y decimal mediante un objeto.
    ''' </summary>
    Public Function fun_Verificar_Dato_Vacio_Y_Decimal(ByVal obCAMPO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            If fun_Verificar_Campo_Lleno(obCAMPO.Text) = False Then
                MessageBox.Show("El campo " & obCAMPO.AccessibleDescription & " esta vacio.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                obCAMPO.Focus()
                boRespuesta = False
            Else
                If fun_Verificar_Dato_Decimal(obCAMPO.Text) = False Then
                    MessageBox.Show("El campo " & obCAMPO.AccessibleDescription & " no es decimal.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    obCAMPO.Focus()
                    boRespuesta = False
                Else
                    boRespuesta = True
                End If
            End If

            Return boRespuesta

        Catch ex As Exception
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Verifica que el dato este vacio y fecha mediante un objeto.
    ''' </summary>
    Public Function fun_Verificar_Dato_Vacio_Y_Fecha(ByVal obCAMPO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            If fun_Verificar_Campo_Lleno(obCAMPO.Text) = False Then
                MessageBox.Show("El campo " & obCAMPO.AccessibleDescription & " esta vacio.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                obCAMPO.Focus()
                boRespuesta = False
            Else
                If fun_Verificar_Dato_Fecha(obCAMPO.Text) = False Then
                    MessageBox.Show("El campo " & obCAMPO.AccessibleDescription & " no es fecha.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    obCAMPO.Focus()
                    boRespuesta = False
                Else
                    boRespuesta = True
                End If
            End If

            Return boRespuesta

        Catch ex As Exception
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Verifica que el dato de la cedula catastral
    ''' </summary>
    Public Function fun_Verificar_Dato_Departamento(ByVal stDepartamento As String) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obDEPARTAMENTO As New cla_DEPARTAMENTO
            Dim dtDEPARTAMENTO As New DataTable

            dtDEPARTAMENTO = obDEPARTAMENTO.fun_Buscar_CODIGO_MANT_DEPARTAMENTO(Trim(stDepartamento))

            If dtDEPARTAMENTO.Rows.Count > 0 Then
                boRespuesta = True
            Else
                MessageBox.Show("El campo Departamento " & stDepartamento & " No existe.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                boRespuesta = False
            End If

            Return boRespuesta

        Catch ex As Exception
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Verifica que el dato de la cedula catastral
    ''' </summary>
    Public Function fun_Verificar_Dato_Municipio(ByVal stDepartamento As String, ByVal stMunicipio As String) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obMUNICIPIO As New cla_MUNICIPIO
            Dim dtMUNICIPIO As New DataTable

            dtMUNICIPIO = obMUNICIPIO.fun_Buscar_DEPARTAMENTO_Y_CODIGO_MANT_MUNICIPIO(Trim(stDepartamento), Trim(stMunicipio))

            If dtMUNICIPIO.Rows.Count > 0 Then
                boRespuesta = True
            Else
                MessageBox.Show("El campo Municipio " & stMunicipio & " No existe.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                boRespuesta = False
            End If

            Return boRespuesta

        Catch ex As Exception
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Verifica que el dato de la cedula catastral
    ''' </summary>
    Public Function fun_Verificar_Dato_Corregimiento(ByVal stDepartamento As String, ByVal stMunicipio As String, ByVal stSector As String, ByVal stCorregimiento As String) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            If stSector Is Nothing Then
                stSector = ""
            End If

            Dim obCORREGIMIENTO As New cla_CORREGIMIENTO
            Dim dtCORREGIMIENTO As New DataTable

            dtCORREGIMIENTO = obCORREGIMIENTO.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_X_CORREGIMIENTO(Trim(stDepartamento), Trim(stMunicipio), Trim(stSector), Trim(stCorregimiento))

            If dtCORREGIMIENTO.Rows.Count > 0 Then
                boRespuesta = True
            Else
                MessageBox.Show("El campo Corregimiento " & stCorregimiento & " No existe.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                boRespuesta = False
            End If

            Return boRespuesta

        Catch ex As Exception
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Verifica que el dato de la cedula catastral
    ''' </summary>
    Public Function fun_Verificar_Dato_BarrioVereda(ByVal stDepartamento As String, ByVal stMunicipio As String, ByVal stSector As String, ByVal stCorregimiento As String, ByVal stBarrioVereda As String) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            If stSector Is Nothing Then
                stSector = ""
            End If

            Dim obBARRVERE As New cla_BARRVERE
            Dim dtBARRVERE As New DataTable

            dtBARRVERE = obBARRVERE.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_CORR_BAVE_X_BARRVERE(Trim(stDepartamento), Trim(stMunicipio), Trim(stSector), Trim(stCorregimiento), Trim(stBarrioVereda))

            If dtBARRVERE.Rows.Count > 0 Then
                boRespuesta = True
            Else
                MessageBox.Show("El campo Barrio ó Vereda " & stBarrioVereda & " No existe.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                boRespuesta = False
            End If

            Return boRespuesta

        Catch ex As Exception
            Return False
        End Try

    End Function

End Class
