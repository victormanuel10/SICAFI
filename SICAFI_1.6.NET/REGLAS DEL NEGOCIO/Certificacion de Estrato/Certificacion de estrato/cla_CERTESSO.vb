Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CERTESSO

    '==================================================
    '*** CLASE CERTIFICACION ESTRATO SOCIOECONOMICO ***
    '==================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_CERTESSO(ByVal obCEESNURA As Object, _
                                                         ByVal obCEESFERA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCEESNURA.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obCEESFERA.Text) = True Then

                Dim objdatos1 As New cla_CERTESSO
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_CERTESSO(obCEESNURA.Text, obCEESFERA.Text)

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
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
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_CERTESSO(ByVal inCEESSECU As Integer, _
                                          ByVal inCEESCLAS As Integer, _
                                          ByVal inCEESMERE As Integer, _
                                          ByVal inCEESNURA As Integer, _
                                          ByVal stCEESFERA As String, _
                                          ByVal inCEESVIRA As Integer, _
                                          ByVal stCEESASUN As String, _
                                          ByVal stCEESOFSA As String, _
                                          ByVal stCEESOBSE As String, _
                                          ByVal stCEESESTA As String) As Boolean


        Try

            ' variables 
            Dim inCEESVIGE As Integer = fun_Vigencia()
            Dim daCEESFEIN As Date = fun_fecha()
            Dim stCEESUSIN As String = fun_usuario()
            Dim stCEESNDIN As String = fun_cedula()
            Dim stCEESMAQU As String = fun_Nombre_de_maquina()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "CERTESSO "

            stConsultaSQL += "( "
            stConsultaSQL += "CEESSECU, "
            stConsultaSQL += "CEESCLAS, "
            stConsultaSQL += "CEESMERE, "
            stConsultaSQL += "CEESNURA, "
            stConsultaSQL += "CEESFERA, "
            stConsultaSQL += "CEESVIRA, "
            stConsultaSQL += "CEESVIGE, "
            stConsultaSQL += "CEESASUN, "
            stConsultaSQL += "CEESOFSA, "
            stConsultaSQL += "CEESOBSE, "
            stConsultaSQL += "CEESESTA, "
            stConsultaSQL += "CEESUSIN, "
            stConsultaSQL += "CEESNDIN, "
            stConsultaSQL += "CEESFEIN, "
            stConsultaSQL += "CEESUSFI, "
            stConsultaSQL += "CEESNDFI, "
            stConsultaSQL += "CEESFEFI, "
            stConsultaSQL += "CEESMAQU "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inCEESSECU) & "', "
            stConsultaSQL += "'" & CInt(inCEESCLAS) & "', "
            stConsultaSQL += "'" & CInt(inCEESMERE) & "', "
            stConsultaSQL += "'" & CInt(inCEESNURA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEESFERA)) & "', "
            stConsultaSQL += "'" & CInt(inCEESVIRA) & "', "
            stConsultaSQL += "'" & CInt(inCEESVIGE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEESASUN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEESOFSA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEESOBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEESESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEESUSIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEESNDIN)) & "', "
            stConsultaSQL += "'" & CDate(daCEESFEIN) & "', "
            stConsultaSQL += "'" & CStr(Trim("")) & "', "
            stConsultaSQL += "'" & CStr(Trim("")) & "', "
            stConsultaSQL += "'" & CStr(Trim("")) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCEESMAQU)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_CERTESSO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_CERTESSO(ByVal inCEESIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "CERTESSO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEESIDRE = '" & CInt(inCEESIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_CERTESSO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_CERTESSO(ByVal inCEESSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "CERTESSO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEESSECU = '" & CInt(inCEESSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_CERTESSO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_CERTESSO(ByVal inCEESIDRE As Integer, _
                                            ByVal inCEESSECU As Integer, _
                                            ByVal inCEESCLAS As Integer, _
                                            ByVal inCEESMERE As Integer, _
                                            ByVal inCEESNURA As Integer, _
                                            ByVal stCEESFERA As String, _
                                            ByVal inCEESVIRA As Integer, _
                                            ByVal stCEESASUN As String, _
                                            ByVal stCEESOFSA As String, _
                                            ByVal stCEESESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "CERTESSO "

            stConsultaSQL += "SET "
            stConsultaSQL += "CEESSECU = '" & CInt(inCEESSECU) & "', "
            stConsultaSQL += "CEESCLAS = '" & CInt(inCEESCLAS) & "', "
            stConsultaSQL += "CEESMERE = '" & CInt(inCEESMERE) & "', "
            stConsultaSQL += "CEESNURA = '" & CInt(inCEESNURA) & "', "
            stConsultaSQL += "CEESFERA = '" & CStr(Trim(stCEESFERA)) & "', "
            stConsultaSQL += "CEESVIRA = '" & CInt(inCEESVIRA) & "', "
            stConsultaSQL += "CEESASUN = '" & CStr(Trim(stCEESASUN)) & "', "
            stConsultaSQL += "CEESOFSA = '" & CStr(Trim(stCEESOFSA)) & "', "
            stConsultaSQL += "CEESESTA = '" & CStr(Trim(stCEESESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEESIDRE = '" & CInt(inCEESIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_CERTESSO")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_CERTESSO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 0 "
            stConsultaSQL += "CEESIDRE, "
            stConsultaSQL += "CEESSECU, "
            stConsultaSQL += "CEESCLAS, "
            stConsultaSQL += "ACADDESC, "
            stConsultaSQL += "CEESMERE, "
            stConsultaSQL += "MEREDESC, "
            stConsultaSQL += "CEESNURA, "
            stConsultaSQL += "CEESFERA, "
            stConsultaSQL += "CEESVIRA, "
            stConsultaSQL += "CEESVIGE, "
            stConsultaSQL += "CEESASUN, "
            stConsultaSQL += "CEESOFSA, "
            stConsultaSQL += "CEESOBSE, "
            stConsultaSQL += "CEESUSIN, "
            stConsultaSQL += "CEESNDIN, "
            stConsultaSQL += "CEESFEIN, "
            stConsultaSQL += "CEESUSFI, "
            stConsultaSQL += "CEESNDFI, "
            stConsultaSQL += "CEESFEFI, "
            stConsultaSQL += "CEESESTA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "CEESMAQU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CERTESSO, ESTADO, MANT_MEDIRESE, MANT_ACTOADMI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEESESTA = ESTACODI AND "
            stConsultaSQL += "CEESCLAS = ACADCODI AND "
            stConsultaSQL += "CEESMERE = MERECODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CEESSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CERTESSO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_CERTESSO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CERTESSO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CEESSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_CERTESSO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CERTESSO_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CERTESSO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEESESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CEESSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CERTESSO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_CERTESSO(ByVal inCEESIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CERTESSO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEESIDRE = '" & CInt(inCEESIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_CERTESSO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_CERTESSO(ByVal inCEESNURA As Integer, _
                                                 ByVal stCEESFERA As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CERTESSO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEESNURA = '" & CInt(inCEESNURA) & "'AND  "
            stConsultaSQL += "CEESFERA = '" & CStr(Trim(stCEESFERA)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_CERTESSO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_CERTESSO(ByVal inCEESSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CERTESSO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEESSECU = '" & CInt(inCEESSECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_CERTESSO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_CERTESSO(ByVal inCEESIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 1 "
            stConsultaSQL += "CEESIDRE, "
            stConsultaSQL += "CEESSECU, "
            stConsultaSQL += "CEESCLAS, "
            stConsultaSQL += "ACADDESC, "
            stConsultaSQL += "CEESMERE, "
            stConsultaSQL += "MEREDESC, "
            stConsultaSQL += "CEESNURA, "
            stConsultaSQL += "CEESFERA, "
            stConsultaSQL += "CEESVIRA, "
            stConsultaSQL += "CEESVIGE, "
            stConsultaSQL += "CEESASUN, "
            stConsultaSQL += "CEESOFSA, "
            stConsultaSQL += "CEESOBSE, "
            stConsultaSQL += "CEESUSIN, "
            stConsultaSQL += "CEESNDIN, "
            stConsultaSQL += "CEESFEIN, "
            stConsultaSQL += "CEESUSFI, "
            stConsultaSQL += "CEESNDFI, "
            stConsultaSQL += "CEESFEFI, "
            stConsultaSQL += "CEESESTA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "CEESMAQU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CERTESSO, ESTADO, MANT_MEDIRESE, MANT_ACTOADMI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CEESESTA = ESTACODI AND "
            stConsultaSQL += "CEESCLAS = ACADCODI AND "
            stConsultaSQL += "CEESMERE = MERECODI AND "
            stConsultaSQL += "CEESIDRE = '" & CInt(inCEESIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CEESSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_CERTESSO")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_CERTESSO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CEESSECU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "CERTESSO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_X_CERTESSO")
            Return Nothing
        End Try

    End Function

End Class
