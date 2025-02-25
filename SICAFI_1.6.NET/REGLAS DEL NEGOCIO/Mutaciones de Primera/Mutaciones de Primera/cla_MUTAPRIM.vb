Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MUTAPRIM

    '=========================================
    '*** CLASE MUTACIONES DE PRIMERA CLASE ***
    '=========================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MUTAPRIM(ByVal obMUPRVIGE As Object, _
                                                         ByVal obMUPRTIRE As Object, _
                                                         ByVal obMUPRRESO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obMUPRVIGE.SelectedValue) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMUPRTIRE.SelectedValue) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMUPRRESO.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obMUPRVIGE.SelectedValue) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obMUPRTIRE.SelectedValue) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obMUPRRESO.Text) = True Then

                    Dim objdatos1 As New cla_MUTAPRIM
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MUTAPRIM(obMUPRVIGE.SelectedValue, obMUPRTIRE.SelectedValue, obMUPRRESO.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        obMUPRVIGE.Focus()
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
    Public Function fun_Insertar_MUTAPRIM(ByVal inMUPRSECU As Integer, _
                                          ByVal inMUPRVIGE As Integer, _
                                          ByVal inMUPRTIRE As Integer, _
                                          ByVal inMUPRRESO As Integer, _
                                          ByVal inMUPRSEMA As Integer, _
                                          ByVal stMUPRNUDO As String, _
                                          ByVal stMUPRUSUA As String, _
                                          ByVal stMUPRESTA As String, _
                                          ByVal stMUPROBSE As String) As Boolean


        Try
            ' variables 
            Dim daMUPRFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MUTAPRIM "

            stConsultaSQL += "( "
            stConsultaSQL += "MUPRSECU, "
            stConsultaSQL += "MUPRVIGE, "
            stConsultaSQL += "MUPRTIRE, "
            stConsultaSQL += "MUPRRESO, "
            stConsultaSQL += "MUPRSEMA, "
            stConsultaSQL += "MUPRFEIN, "
            stConsultaSQL += "MUPRNUDO, "
            stConsultaSQL += "MUPRUSUA, "
            stConsultaSQL += "MUPRESTA, "
            stConsultaSQL += "MUPROBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMUPRSECU) & "', "
            stConsultaSQL += "'" & CInt(inMUPRVIGE) & "', "
            stConsultaSQL += "'" & CInt(inMUPRTIRE) & "', "
            stConsultaSQL += "'" & CInt(inMUPRRESO) & "', "
            stConsultaSQL += "'" & CInt(inMUPRSEMA) & "', "
            stConsultaSQL += "'" & CDate(daMUPRFEIN) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUPRNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUPRUSUA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUPRESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMUPROBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MUTAPRIM")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MUTAPRIM(ByVal inMUPRIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAPRIM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUPRIDRE = '" & CInt(inMUPRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MUTAPRIM")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MUTAPRIM(ByVal inMUPRSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAPRIM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUPRSECU = '" & CInt(inMUPRSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MUTAPRIM")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MUTAPRIM(ByVal inMUPRIDRE As Integer, _
                                            ByVal inMUPRSECU As Integer, _
                                            ByVal inMUPRVIGE As Integer, _
                                            ByVal inMUPRTIRE As Integer, _
                                            ByVal inMUPRRESO As Integer, _
                                            ByVal inMUPRSEMA As Integer, _
                                            ByVal stMUPRNUDO As String, _
                                            ByVal stMUPRUSUA As String, _
                                            ByVal stMUPRESTA As String, _
                                            ByVal stMUPROBSE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MUTAPRIM "

            stConsultaSQL += "SET "
            stConsultaSQL += "MUPRSECU = '" & CInt(inMUPRSECU) & "', "
            stConsultaSQL += "MUPRVIGE = '" & CInt(inMUPRVIGE) & "', "
            stConsultaSQL += "MUPRTIRE = '" & CInt(inMUPRTIRE) & "', "
            stConsultaSQL += "MUPRRESO = '" & CInt(inMUPRRESO) & "', "
            stConsultaSQL += "MUPRSEMA = '" & CInt(inMUPRSEMA) & "', "
            stConsultaSQL += "MUPRNUDO = '" & CStr(Trim(stMUPRNUDO)) & "', "
            stConsultaSQL += "MUPRUSUA = '" & CStr(Trim(stMUPRUSUA)) & "', "
            stConsultaSQL += "MUPRESTA = '" & CStr(Trim(stMUPRESTA)) & "', "
            stConsultaSQL += "MUPROBSE = '" & CStr(Trim(stMUPROBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUPRIDRE = '" & CInt(inMUPRIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MUTAPRIM")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MUTAPRIM() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 0 "
            stConsultaSQL += "MUPRIDRE, "
            stConsultaSQL += "MUPRSECU, "
            stConsultaSQL += "MUPRVIGE, "
            stConsultaSQL += "MUPRTIRE, "
            stConsultaSQL += "TIREDESC, "
            stConsultaSQL += "MUPRRESO, "
            stConsultaSQL += "MUPRSEMA, "
            stConsultaSQL += "MUPRFEIN, "
            stConsultaSQL += "MUPRNUDO, "
            stConsultaSQL += "MUPRUSUA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "MUPROBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAPRIM, ESTADO, MANT_TIPORESO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUPRESTA = ESTACODI AND "
            stConsultaSQL += "MUPRTIRE = TIRECODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUPRVIGE, MUPRTIRE, MUPRRESO, MUPRSEMA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MUTAPRIM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MUTAPRIM() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAPRIM "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUPRVIGE, MUPRTIRE, MUPRRESO, MUPRSEMA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MUTAPRIM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MUTAPRIM_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAPRIM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUPRESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUPRVIGE, MUPRTIRE, MUPRRESO, MUPRSEMA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MUTAPRIM_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MUTAPRIM(ByVal inMUPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAPRIM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUPRIDRE = '" & CInt(inMUPRIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MUTAPRIM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MUTAPRIM(ByVal inMUPRVIGE As Integer, _
                                                 ByVal inMUPRTIRE As Integer, _
                                                 ByVal inMUPRRESO As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAPRIM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUPRVIGE = '" & CInt(inMUPRVIGE) & "'AND  "
            stConsultaSQL += "MUPRTIRE = '" & CInt(inMUPRTIRE) & "'AND  "
            stConsultaSQL += "MUPRRESO = '" & CInt(inMUPRRESO) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MUTAPRIM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_MUTAPRIM(ByVal inMUPRSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAPRIM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUPRSECU = '" & CInt(inMUPRSECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MUTAPRIM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAPRIM(ByVal inMUPRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MUPRIDRE, "
            stConsultaSQL += "MUPRSECU, "
            stConsultaSQL += "MUPRVIGE, "
            stConsultaSQL += "MUPRTIRE, "
            stConsultaSQL += "TIREDESC, "
            stConsultaSQL += "MUPRRESO, "
            stConsultaSQL += "MUPRSEMA, "
            stConsultaSQL += "MUPRFEIN, "
            stConsultaSQL += "MUPRNUDO, "
            stConsultaSQL += "MUPRUSUA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "MUPROBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAPRIM, ESTADO, MANT_TIPORESO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUPRESTA = ESTACODI AND "
            stConsultaSQL += "MUPRTIRE = TIRECODI AND "
            stConsultaSQL += "MUPRIDRE = '" & CInt(inMUPRIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUPRVIGE, MUPRTIRE, MUPRRESO, MUPRSEMA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAPRIM")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia maxima
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_MUTAPRIM() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MUPRSECU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAPRIM "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_MAXINA_X_MUTAPRIM")
            Return Nothing
        End Try

    End Function

End Class
