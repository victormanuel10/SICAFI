Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RANGOS

    '==============
    '*** RANGOS ***
    '==============

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_RANGOS(ByVal obRANGDEPA As Object, _
                                                            ByVal obRANGMUNI As Object, _
                                                            ByVal obRANGCLSE As Object, _
                                                            ByVal obRANGPROY As Object, _
                                                            ByVal obRANGTIVA As Object, _
                                                            ByVal obRANGVARI As Object, _
                                                            ByVal obRANGRAIN As Object, _
                                                            ByVal obRANGRAFI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRANGVARI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRANGDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRANGMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRANGCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRANGTIVA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRANGPROY.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRANGRAIN.Text) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRANGRAFI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obRANGVARI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRANGDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRANGMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRANGCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRANGTIVA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRANGPROY.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRANGRAIN.Text) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRANGRAFI.Text) = True Then


                    Dim objdatos1 As New cla_RANGOS
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_RANGOS(obRANGDEPA.SelectedValue, _
                                                             obRANGMUNI.SelectedValue, _
                                                             obRANGCLSE.SelectedValue, _
                                                             obRANGPROY.SelectedValue, _
                                                             obRANGTIVA.SelectedValue, _
                                                             obRANGVARI.SelectedValue, _
                                                             obRANGRAIN.Text, _
                                                             obRANGRAFI.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obRANGVARI.Focus()
                        boRespuesta = False
                    Else
                        boRespuesta = True
                    End If

                End If
            End If

            Return boRespuesta

        Catch ex As Exception
            Return False
        End Try

    End Function


    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_RANGOS(ByVal stRANGDEPA As String, _
                                               ByVal stRANGMUNI As String, _
                                               ByVal inRANGCLSE As Integer, _
                                               ByVal inRANGPROY As Integer, _
                                               ByVal inRANGTIVA As Integer, _
                                               ByVal inRANGVARI As Integer, _
                                               ByVal loRANGRAIN As Long, _
                                               ByVal loRANGRAFI As Long, _
                                               ByVal stRANGFAIN As String, _
                                               ByVal stRANGFAFI As String, _
                                               ByVal stRANGFAAP As String, _
                                               ByVal stRANGESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_RANGOS "

            stConsultaSQL += "( "
            stConsultaSQL += "RANGDEPA, "
            stConsultaSQL += "RANGMUNI, "
            stConsultaSQL += "RANGCLSE, "
            stConsultaSQL += "RANGPROY, "
            stConsultaSQL += "RANGTIVA, "
            stConsultaSQL += "RANGVARI, "
            stConsultaSQL += "RANGRAIN, "
            stConsultaSQL += "RANGRAFI, "
            stConsultaSQL += "RANGFAIN, "
            stConsultaSQL += "RANGFAFI, "
            stConsultaSQL += "RANGFAAP, "
            stConsultaSQL += "RANGESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stRANGDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRANGMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inRANGCLSE) & "', "
            stConsultaSQL += "'" & CInt(inRANGPROY) & "', "
            stConsultaSQL += "'" & CInt(inRANGTIVA) & "', "
            stConsultaSQL += "'" & CInt(inRANGVARI) & "', "
            stConsultaSQL += "'" & CLng(loRANGRAIN) & "', "
            stConsultaSQL += "'" & CLng(loRANGRAFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRANGFAIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRANGFAFI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRANGFAAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRANGESTA)) & "' "
            stConsultaSQL += ") "

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_RANGOS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_RANGOS(ByVal inRANGIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_RANGOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RANGIDRE = '" & CInt(inRANGIDRE) & "' "

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_RANGOS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_RANGOS(ByVal inRANGIDRE As Integer, _
                                                 ByVal stRANGDEPA As String, _
                                                 ByVal stRANGMUNI As String, _
                                                 ByVal inRANGCLSE As Integer, _
                                                 ByVal inRANGPROY As Integer, _
                                                 ByVal inRANGTIVA As Integer, _
                                                 ByVal inRANGVARI As Integer, _
                                                 ByVal loRANGRAIN As Long, _
                                                 ByVal loRANGRAFI As Long, _
                                                 ByVal stRANGFAIN As String, _
                                                 ByVal stRANGFAFI As String, _
                                                 ByVal stRANGFAAP As String, _
                                                 ByVal stRANGESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_RANGOS "

            stConsultaSQL += "SET "
            stConsultaSQL += "RANGDEPA = '" & CStr(Trim(stRANGDEPA)) & "', "
            stConsultaSQL += "RANGMUNI = '" & CStr(Trim(stRANGMUNI)) & "', "
            stConsultaSQL += "RANGCLSE = '" & CInt(inRANGCLSE) & "', "
            stConsultaSQL += "RANGPROY = '" & CInt(inRANGPROY) & "', "
            stConsultaSQL += "RANGTIVA = '" & CInt(inRANGTIVA) & "', "
            stConsultaSQL += "RANGVARI = '" & CInt(inRANGVARI) & "', "
            stConsultaSQL += "RANGRAIN = '" & CLng(loRANGRAIN) & "', "
            stConsultaSQL += "RANGRAFI = '" & CLng(loRANGRAFI) & "', "
            stConsultaSQL += "RANGFAIN = '" & CStr(Trim(stRANGFAIN)) & "', "
            stConsultaSQL += "RANGFAFI = '" & CStr(Trim(stRANGFAFI)) & "', "
            stConsultaSQL += "RANGFAAP = '" & CStr(Trim(stRANGFAAP)) & "', "
            stConsultaSQL += "RANGESTA = '" & CStr(Trim(stRANGESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RANGIDRE = '" & CInt(inRANGIDRE) & "'"

            ' instancia la clase
            Dim objenq As New cExecuteNonQuery

            ' verifica la operación
            If objenq.ActualizarDb_Text_SQL(stConsultaSQL) = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RANGOS")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_RANGOS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RANGIDRE, "
            stConsultaSQL += "RANGDEPA, "
            stConsultaSQL += "DEPADESC, "
            stConsultaSQL += "RANGMUNI, "
            stConsultaSQL += "MUNIDESC, "
            stConsultaSQL += "RANGCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "RANGPROY, "
            stConsultaSQL += "PROYDESC, "
            stConsultaSQL += "RANGTIVA, "
            stConsultaSQL += "TIVADESC, "
            stConsultaSQL += "RANGVARI, "
            stConsultaSQL += "VARIDESC, "
            stConsultaSQL += "RANGRAIN, "
            stConsultaSQL += "RANGRAFI, "
            stConsultaSQL += "RANGFAIN, "
            stConsultaSQL += "RANGFAFI, "
            stConsultaSQL += "RANGFAAP, "
            stConsultaSQL += "RANGESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RANGOS, "
            stConsultaSQL += "MANT_DEPARTAMENTO, "
            stConsultaSQL += "MANT_MUNICIPIO, "
            stConsultaSQL += "MANT_CLASSECT, "
            stConsultaSQL += "PROYECTO, "
            stConsultaSQL += "MANT_TIPOVARI, "
            stConsultaSQL += "MANT_VARIABLE, "
            stConsultaSQL += "ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DEPACODI = RANGDEPA AND "
            stConsultaSQL += "MUNIDEPA = RANGDEPA AND "
            stConsultaSQL += "MUNICODI = RANGMUNI AND "
            stConsultaSQL += "CLSECODI = RANGCLSE AND "
            stConsultaSQL += "PROYDEPA = RANGDEPA AND "
            stConsultaSQL += "PROYMUNI = RANGMUNI AND "
            stConsultaSQL += "PROYCLSE = RANGCLSE AND "
            stConsultaSQL += "PROYCODI = RANGPROY AND "
            stConsultaSQL += "TIVACODI = RANGTIVA AND "
            stConsultaSQL += "VARITIVA = RANGTIVA AND "
            stConsultaSQL += "VARICODI = RANGVARI AND "
            stConsultaSQL += "ESTACODI = PROYESTA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RANGDEPA, RANGMUNI, RANGCLSE, RANGTIVA, RANGVARI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_RANGOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_RANGOS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RANGOS "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RANGDEPA, RANGMUNI, RANGCLSE, RANGTIVA, RANGVARI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_RANGOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_RANGOS_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RANGOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RANGESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RANGDEPA, RANGMUNI, RANGCLSE, RANGTIVA, RANGVARI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_RANGOS_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_RANGOS(ByVal inRANGIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RANGOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RANGIDRE = '" & CInt(inRANGIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_RANGOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_RANGOS(ByVal stRANGDEPA As String, _
                                             ByVal stRANGMUNI As String, _
                                             ByVal inRANGCLSE As Integer, _
                                             ByVal inRANGPROY As Integer, _
                                             ByVal inRANGTIVA As Integer, _
                                             ByVal inRANGVARI As Integer, _
                                             ByVal loRANGRAIN As Long, _
                                             ByVal loRANGRAFI As Long) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RANGOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RANGDEPA = '" & CStr(Trim(stRANGDEPA)) & "' and "
            stConsultaSQL += "RANGMUNI = '" & CStr(Trim(stRANGMUNI)) & "' and "
            stConsultaSQL += "RANGCLSE = '" & CInt(inRANGCLSE) & "' and "
            stConsultaSQL += "RANGPROY = '" & CInt(inRANGPROY) & "' and "
            stConsultaSQL += "RANGTIVA = '" & CInt(inRANGTIVA) & "' and "
            stConsultaSQL += "RANGVARI = '" & CInt(inRANGVARI) & "' and "
            stConsultaSQL += "RANGRAIN = '" & CLng(loRANGRAIN) & "' and "
            stConsultaSQL += "RANGRAFI = '" & CLng(loRANGRAFI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RANGOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_RANGOS(ByVal stRANGDEPA As String, _
                                             ByVal stRANGMUNI As String, _
                                             ByVal inRANGCLSE As Integer, _
                                             ByVal inRANGPROY As Integer, _
                                             ByVal inRANGTIVA As Integer, _
                                             ByVal inRANGVARI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RANGOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RANGDEPA = '" & CStr(Trim(stRANGDEPA)) & "' and "
            stConsultaSQL += "RANGMUNI = '" & CStr(Trim(stRANGMUNI)) & "' and "
            stConsultaSQL += "RANGCLSE = '" & CInt(inRANGCLSE) & "' and "
            stConsultaSQL += "RANGPROY = '" & CInt(inRANGPROY) & "' and "
            stConsultaSQL += "RANGTIVA = '" & CInt(inRANGTIVA) & "' and "
            stConsultaSQL += "RANGVARI = '" & CInt(inRANGVARI) & "' "
          
            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RANGRAIN DESC"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RANGOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el RANGOS por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_RANGOS(ByVal inRANGIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RANGIDRE, "
            stConsultaSQL += "RANGDEPA, "
            stConsultaSQL += "DEPADESC, "
            stConsultaSQL += "RANGMUNI, "
            stConsultaSQL += "MUNIDESC, "
            stConsultaSQL += "RANGCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "RANGPROY, "
            stConsultaSQL += "PROYDESC, "
            stConsultaSQL += "RANGTIVA, "
            stConsultaSQL += "TIVADESC, "
            stConsultaSQL += "RANGVARI, "
            stConsultaSQL += "VARIDESC, "
            stConsultaSQL += "RANGRAIN, "
            stConsultaSQL += "RANGRAFI, "
            stConsultaSQL += "RANGFAIN, "
            stConsultaSQL += "RANGFAFI, "
            stConsultaSQL += "RANGFAAP, "
            stConsultaSQL += "RANGESTA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "RANGAPRA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RANGOS, "
            stConsultaSQL += "MANT_DEPARTAMENTO, "
            stConsultaSQL += "MANT_MUNICIPIO, "
            stConsultaSQL += "MANT_CLASSECT, "
            stConsultaSQL += "PROYECTO, "
            stConsultaSQL += "MANT_TIPOVARI, "
            stConsultaSQL += "MANT_VARIABLE, "
            stConsultaSQL += "ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DEPACODI = RANGDEPA AND "
            stConsultaSQL += "MUNIDEPA = RANGDEPA AND "
            stConsultaSQL += "MUNICODI = RANGMUNI AND "
            stConsultaSQL += "CLSECODI = RANGCLSE AND "
            stConsultaSQL += "PROYDEPA = RANGDEPA AND "
            stConsultaSQL += "PROYMUNI = RANGMUNI AND "
            stConsultaSQL += "PROYCLSE = RANGCLSE AND "
            stConsultaSQL += "PROYCODI = RANGPROY AND "
            stConsultaSQL += "TIVACODI = RANGTIVA AND "
            stConsultaSQL += "VARITIVA = RANGTIVA AND "
            stConsultaSQL += "VARICODI = RANGVARI AND "
            stConsultaSQL += "ESTACODI = PROYESTA AND "

            stConsultaSQL += "RANGIDRE = '" & CInt(inRANGIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RANGTIVA, RANGVARI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_RANGOS")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el RANGOS por tipo de impuesto
    ''' </summary>
    Public Function fun_Buscar_CODIGO_RANGOS_X_TIPOIMPU(ByVal inRANGTIVA As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_RANGOS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RANGTIVA = '" & CInt(inRANGTIVA) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RANGOS_X_TIPOIMPU")
            Return Nothing
        End Try

    End Function

End Class
