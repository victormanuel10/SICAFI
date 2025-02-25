Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_FACTPROY

    '=============================
    '*** FACTORES POR PROYECTO ***
    '=============================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_FACTPROY(ByVal obFACTDEPA As Object, _
                                                              ByVal obFACTMUNI As Object, _
                                                              ByVal obFACTCLSE As Object, _
                                                              ByVal obFACTPROY As Object, _
                                                              ByVal obFACTTIVA As Object, _
                                                              ByVal obFACTVARI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obFACTVARI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obFACTDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obFACTMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obFACTCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obFACTTIVA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obFACTPROY.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obFACTVARI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obFACTDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obFACTMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obFACTCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obFACTTIVA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obFACTPROY.SelectedValue) = True Then


                    Dim objdatos1 As New cla_FACTPROY
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_FACTPROY(obFACTDEPA.SelectedValue, _
                                                               obFACTMUNI.SelectedValue, _
                                                               obFACTCLSE.SelectedValue, _
                                                               obFACTPROY.SelectedValue, _
                                                               obFACTTIVA.SelectedValue, _
                                                               obFACTVARI.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obFACTTIVA.Text & " - " & obFACTVARI.Text & " del campo " & obFACTVARI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obFACTVARI.Focus()
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
    Public Function fun_Insertar_MANT_FACTPROY(ByVal stFACTDEPA As String, _
                                               ByVal stFACTMUNI As String, _
                                               ByVal inFACTCLSE As Integer, _
                                               ByVal inFACTPROY As Integer, _
                                               ByVal inFACTTIVA As Integer, _
                                               ByVal inFACTVARI As Integer, _
                                               ByVal stFACTDESC As String, _
                                               ByVal stFACTFAIN As String, _
                                               ByVal stFACTFAFI As String, _
                                               ByVal stFACTFAAP As String, _
                                               ByVal stFACTESTA As String, _
                                               ByVal boFACTAPRA As Boolean) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_FACTPROY "

            stConsultaSQL += "( "
            stConsultaSQL += "FAPRDEPA, "
            stConsultaSQL += "FAPRMUNI, "
            stConsultaSQL += "FAPRCLSE, "
            stConsultaSQL += "FAPRPROY, "
            stConsultaSQL += "FAPRTIVA, "
            stConsultaSQL += "FAPRVARI, "
            stConsultaSQL += "FAPRDESC, "
            stConsultaSQL += "FAPRFAIN, "
            stConsultaSQL += "FAPRFAFI, "
            stConsultaSQL += "FAPRFAAP, "
            stConsultaSQL += "FAPRESTA, "
            stConsultaSQL += "FAPRAPRA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stFACTDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFACTMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inFACTCLSE) & "', "
            stConsultaSQL += "'" & CInt(inFACTPROY) & "', "
            stConsultaSQL += "'" & CInt(inFACTTIVA) & "', "
            stConsultaSQL += "'" & CInt(inFACTVARI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFACTDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFACTFAIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFACTFAFI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFACTFAAP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFACTESTA)) & "', "
            stConsultaSQL += "'" & CBool(boFACTAPRA) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_FACTPROY")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_FACTPROY(ByVal inFACTIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_FACTPROY "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FAPRIDRE = '" & CInt(inFACTIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_FACTPROY")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_FACTPROY(ByVal inFACTIDRE As Integer, _
                                                 ByVal stFACTDEPA As String, _
                                                 ByVal stFACTMUNI As String, _
                                                 ByVal inFACTCLSE As Integer, _
                                                 ByVal inFACTPROY As Integer, _
                                                 ByVal inFACTTIVA As Integer, _
                                                 ByVal inFACTVARI As Integer, _
                                                 ByVal stFACTDESC As String, _
                                                 ByVal stFACTFAIN As String, _
                                                 ByVal stFACTFAFI As String, _
                                                 ByVal stFACTFAAP As String, _
                                                 ByVal stFACTESTA As String, _
                                                 ByVal boFACTAPRA As Boolean) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_FACTPROY "

            stConsultaSQL += "SET "
            stConsultaSQL += "FAPRDEPA = '" & CStr(Trim(stFACTDEPA)) & "', "
            stConsultaSQL += "FAPRMUNI = '" & CStr(Trim(stFACTMUNI)) & "', "
            stConsultaSQL += "FAPRCLSE = '" & CInt(inFACTCLSE) & "', "
            stConsultaSQL += "FAPRPROY = '" & CInt(inFACTPROY) & "', "
            stConsultaSQL += "FAPRTIVA = '" & CInt(inFACTTIVA) & "', "
            stConsultaSQL += "FAPRVARI = '" & CInt(inFACTVARI) & "', "
            stConsultaSQL += "FAPRDESC = '" & CStr(Trim(stFACTDESC)) & "', "
            stConsultaSQL += "FAPRFAIN = '" & CStr(Trim(stFACTFAIN)) & "', "
            stConsultaSQL += "FAPRFAFI = '" & CStr(Trim(stFACTFAFI)) & "', "
            stConsultaSQL += "FAPRFAAP = '" & CStr(Trim(stFACTFAAP)) & "', "
            stConsultaSQL += "FAPRESTA = '" & CStr(Trim(stFACTESTA)) & "', "
            stConsultaSQL += "FAPRAPRA = '" & CBool(boFACTAPRA) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FAPRIDRE = '" & CInt(inFACTIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_FACTPROY")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_FACTPROY() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FAPRIDRE, "
            stConsultaSQL += "FAPRDEPA, "
            stConsultaSQL += "DEPADESC, "
            stConsultaSQL += "FAPRMUNI, "
            stConsultaSQL += "MUNIDESC, "
            stConsultaSQL += "FAPRCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "FAPRPROY, "
            stConsultaSQL += "PROYDESC, "
            stConsultaSQL += "FAPRTIVA, "
            stConsultaSQL += "TIVADESC, "
            stConsultaSQL += "FAPRVARI, "
            stConsultaSQL += "VARIDESC, "
            stConsultaSQL += "FAPRDESC, "
            stConsultaSQL += "FAPRFAIN, "
            stConsultaSQL += "FAPRFAFI, "
            stConsultaSQL += "FAPRFAAP, "
            stConsultaSQL += "FAPRESTA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "FAPRAPRA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FACTPROY, "
            stConsultaSQL += "MANT_DEPARTAMENTO, "
            stConsultaSQL += "MANT_MUNICIPIO, "
            stConsultaSQL += "MANT_CLASSECT, "
            stConsultaSQL += "PROYECTO, "
            stConsultaSQL += "MANT_TIPOVARI, "
            stConsultaSQL += "MANT_VARIABLE, "
            stConsultaSQL += "ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DEPACODI = FAPRDEPA AND "
            stConsultaSQL += "MUNIDEPA = FAPRDEPA AND "
            stConsultaSQL += "MUNICODI = FAPRMUNI AND "
            stConsultaSQL += "CLSECODI = FAPRCLSE AND "
            stConsultaSQL += "PROYDEPA = FAPRDEPA AND "
            stConsultaSQL += "PROYMUNI = FAPRMUNI AND "
            stConsultaSQL += "PROYCLSE = FAPRCLSE AND "
            stConsultaSQL += "PROYCODI = FAPRPROY AND "
            stConsultaSQL += "TIVACODI = FAPRTIVA AND "
            stConsultaSQL += "VARITIVA = FAPRTIVA AND "
            stConsultaSQL += "VARICODI = FAPRVARI AND "
            stConsultaSQL += "ESTACODI = PROYESTA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FAPRDEPA, FAPRMUNI, FAPRCLSE, FAPRTIVA, FAPRVARI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_FACTPROY")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_FACTPROY_X_RANGO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FAPRIDRE, "
            stConsultaSQL += "FAPRDEPA, "
            stConsultaSQL += "DEPADESC, "
            stConsultaSQL += "FAPRMUNI, "
            stConsultaSQL += "MUNIDESC, "
            stConsultaSQL += "FAPRCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "FAPRPROY, "
            stConsultaSQL += "PROYDESC, "
            stConsultaSQL += "FAPRTIVA, "
            stConsultaSQL += "TIVADESC, "
            stConsultaSQL += "FAPRVARI, "
            stConsultaSQL += "VARIDESC, "
            stConsultaSQL += "FAPRDESC, "
            stConsultaSQL += "FAPRFAIN, "
            stConsultaSQL += "FAPRFAFI, "
            stConsultaSQL += "FAPRFAAP, "
            stConsultaSQL += "FAPRESTA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "FAPRAPRA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FACTPROY, "
            stConsultaSQL += "MANT_DEPARTAMENTO, "
            stConsultaSQL += "MANT_MUNICIPIO, "
            stConsultaSQL += "MANT_CLASSECT, "
            stConsultaSQL += "PROYECTO, "
            stConsultaSQL += "MANT_TIPOVARI, "
            stConsultaSQL += "MANT_VARIABLE, "
            stConsultaSQL += "ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DEPACODI = FAPRDEPA AND "
            stConsultaSQL += "MUNIDEPA = FAPRDEPA AND "
            stConsultaSQL += "MUNICODI = FAPRMUNI AND "
            stConsultaSQL += "CLSECODI = FAPRCLSE AND "
            stConsultaSQL += "PROYDEPA = FAPRDEPA AND "
            stConsultaSQL += "PROYMUNI = FAPRMUNI AND "
            stConsultaSQL += "PROYCLSE = FAPRCLSE AND "
            stConsultaSQL += "PROYCODI = FAPRPROY AND "
            stConsultaSQL += "TIVACODI = FAPRTIVA AND "
            stConsultaSQL += "VARITIVA = FAPRTIVA AND "
            stConsultaSQL += "VARICODI = FAPRVARI AND "
            stConsultaSQL += "ESTACODI = PROYESTA AND "
            stConsultaSQL += "FAPRAPRA = 1 "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FAPRDEPA, FAPRMUNI, FAPRCLSE, FAPRTIVA, FAPRVARI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_FACTPROY")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_FACTPROY() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FACTPROY "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FAPRDEPA, FAPRMUNI, FAPRCLSE, FAPRTIVA, FAPRVARI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_FACTPROY")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_FACTPROY_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FACTPROY "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FAPRESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FAPRDEPA, FAPRMUNI, FAPRCLSE, FAPRTIVA, FAPRVARI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_FACTPROY_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_FACTPROY(ByVal inFACTIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FACTPROY "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FAPRIDRE = '" & CInt(inFACTIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_FACTPROY")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_FACTPROY(ByVal stFACTDEPA As String, _
                                               ByVal stFACTMUNI As String, _
                                               ByVal inFACTCLSE As Integer, _
                                               ByVal inFACTPROY As Integer, _
                                               ByVal inFACTTIVA As Integer, _
                                               ByVal inFACTVARI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FACTPROY "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FAPRDEPA = '" & CStr(Trim(stFACTDEPA)) & "' and "
            stConsultaSQL += "FAPRMUNI = '" & CStr(Trim(stFACTMUNI)) & "' and "
            stConsultaSQL += "FAPRCLSE = '" & CInt(inFACTCLSE) & "' and "
            stConsultaSQL += "FAPRPROY = '" & CInt(inFACTPROY) & "' and "
            stConsultaSQL += "FAPRTIVA = '" & CInt(inFACTTIVA) & "' and "
            stConsultaSQL += "FAPRVARI = '" & CInt(inFACTVARI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_FACTPROY")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el FAPRPROY por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_FACTPROY(ByVal inFACTIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FAPRIDRE, "
            stConsultaSQL += "FAPRDEPA, "
            stConsultaSQL += "DEPADESC, "
            stConsultaSQL += "FAPRMUNI, "
            stConsultaSQL += "MUNIDESC, "
            stConsultaSQL += "FAPRCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "FAPRPROY, "
            stConsultaSQL += "PROYDESC, "
            stConsultaSQL += "FAPRTIVA, "
            stConsultaSQL += "TIVADESC, "
            stConsultaSQL += "FAPRVARI, "
            stConsultaSQL += "VARIDESC, "
            stConsultaSQL += "FAPRDESC, "
            stConsultaSQL += "FAPRFAIN, "
            stConsultaSQL += "FAPRFAFI, "
            stConsultaSQL += "FAPRFAAP, "
            stConsultaSQL += "FAPRESTA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "FAPRAPRA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FACTPROY, "
            stConsultaSQL += "MANT_DEPARTAMENTO, "
            stConsultaSQL += "MANT_MUNICIPIO, "
            stConsultaSQL += "MANT_CLASSECT, "
            stConsultaSQL += "PROYECTO, "
            stConsultaSQL += "MANT_TIPOVARI, "
            stConsultaSQL += "MANT_VARIABLE, "
            stConsultaSQL += "ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DEPACODI = FAPRDEPA AND "
            stConsultaSQL += "MUNIDEPA = FAPRDEPA AND "
            stConsultaSQL += "MUNICODI = FAPRMUNI AND "
            stConsultaSQL += "CLSECODI = FAPRCLSE AND "
            stConsultaSQL += "PROYDEPA = FAPRDEPA AND "
            stConsultaSQL += "PROYMUNI = FAPRMUNI AND "
            stConsultaSQL += "PROYCLSE = FAPRCLSE AND "
            stConsultaSQL += "PROYCODI = FAPRPROY AND "
            stConsultaSQL += "TIVACODI = FAPRTIVA AND "
            stConsultaSQL += "VARITIVA = FAPRTIVA AND "
            stConsultaSQL += "VARICODI = FAPRVARI AND "
            stConsultaSQL += "ESTACODI = PROYESTA AND "

            stConsultaSQL += "FAPRIDRE = '" & CInt(inFACTIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FAPRTIVA, FAPRVARI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_FACTPROY")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el FAPRPROY por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_FACTPROY_X_RANGO(ByVal inFACTIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FAPRIDRE, "
            stConsultaSQL += "FAPRDEPA, "
            stConsultaSQL += "DEPADESC, "
            stConsultaSQL += "FAPRMUNI, "
            stConsultaSQL += "MUNIDESC, "
            stConsultaSQL += "FAPRCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "FAPRPROY, "
            stConsultaSQL += "PROYDESC, "
            stConsultaSQL += "FAPRTIVA, "
            stConsultaSQL += "TIVADESC, "
            stConsultaSQL += "FAPRVARI, "
            stConsultaSQL += "VARIDESC, "
            stConsultaSQL += "FAPRDESC, "
            stConsultaSQL += "FAPRFAIN, "
            stConsultaSQL += "FAPRFAFI, "
            stConsultaSQL += "FAPRFAAP, "
            stConsultaSQL += "FAPRESTA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "FAPRAPRA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FACTPROY, "
            stConsultaSQL += "MANT_DEPARTAMENTO, "
            stConsultaSQL += "MANT_MUNICIPIO, "
            stConsultaSQL += "MANT_CLASSECT, "
            stConsultaSQL += "PROYECTO, "
            stConsultaSQL += "MANT_TIPOVARI, "
            stConsultaSQL += "MANT_VARIABLE, "
            stConsultaSQL += "ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DEPACODI = FAPRDEPA AND "
            stConsultaSQL += "MUNIDEPA = FAPRDEPA AND "
            stConsultaSQL += "MUNICODI = FAPRMUNI AND "
            stConsultaSQL += "CLSECODI = FAPRCLSE AND "
            stConsultaSQL += "PROYDEPA = FAPRDEPA AND "
            stConsultaSQL += "PROYMUNI = FAPRMUNI AND "
            stConsultaSQL += "PROYCLSE = FAPRCLSE AND "
            stConsultaSQL += "PROYCODI = FAPRPROY AND "
            stConsultaSQL += "TIVACODI = FAPRTIVA AND "
            stConsultaSQL += "VARITIVA = FAPRTIVA AND "
            stConsultaSQL += "VARICODI = FAPRVARI AND "
            stConsultaSQL += "ESTACODI = PROYESTA AND "
            stConsultaSQL += "FAPRAPRA = 1 AND "

            stConsultaSQL += "FAPRIDRE = '" & CInt(inFACTIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FAPRTIVA, FAPRVARI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_FACTPROY")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el FAPRPROY por tipo de impuesto
    ''' </summary>
    Public Function fun_Buscar_CODIGO_FACTPROY_X_TIPOIMPU(ByVal inFACTTIVA As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_FACTPROY "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FAPRTIVA = '" & CInt(inFACTTIVA) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_FACTPROY_X_TIPOIMPU")
            Return Nothing
        End Try

    End Function


End Class
