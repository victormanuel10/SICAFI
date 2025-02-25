Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_DENSIDAD

    '================
    '*** DENSIDAD ***
    '================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_DENSIDAD(ByVal obDENSCECA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obDENSCECA.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obDENSCECA.Text) = True Then

                    Dim objdatos1 As New cla_DENSIDAD
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DENSIDAD(Trim(obDENSCECA.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obDENSCECA.Text & " del campo " & obDENSCECA.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obDENSCECA.Focus()
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
    Public Function fun_Insertar_MANT_DENSIDAD(ByVal stDENSCECA As String, _
                                               ByVal stDENSDENS As String, _
                                               ByVal stDENSESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' DENSatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_DENSIDAD "

            stConsultaSQL += "( "
            stConsultaSQL += "DENSCECA, "
            stConsultaSQL += "DENSDENS, "
            stConsultaSQL += "DENSESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stDENSCECA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDENSDENS)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDENSESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_DENSIDAD")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_DENSIDAD(ByVal inDENSIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' DENSatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_DENSIDAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DENSIDRE = '" & CInt(inDENSIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_DENSIDAD")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_x_CECA_MANT_DENSIDAD(ByVal stDENSCECA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' DENSatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_DENSIDAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DENSCECA = '" & CStr(Trim(stDENSCECA)) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_DENSIDAD")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_DENSIDAD(ByVal inDENSIDRE As Integer, _
                                                 ByVal stDENSCECA As String, _
                                                 ByVal stDENSDENS As String, _
                                                 ByVal stDENSESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' DENSatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_DENSIDAD "

            stConsultaSQL += "SET "
            stConsultaSQL += "DENSCECA = '" & CStr(Trim(stDENSCECA)) & "', "
            stConsultaSQL += "DENSCECA = '" & CStr(Trim(stDENSDENS)) & "', "
            stConsultaSQL += "DENSESTA = '" & CStr(Trim(stDENSESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DENSIDRE = '" & CInt(inDENSIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_DENSIDAD")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_DENSIDAD() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' DENSatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 10 "
            stConsultaSQL += "DENSIDRE, "
            stConsultaSQL += "DENSCECA, "
            stConsultaSQL += "DENSDENS, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "DENSESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DENSIDAD, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DENSESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DENSCECA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_DENSIDAD")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_DENSIDAD() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' DENSatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DENSIDAD "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DENSCECA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_DENSIDAD")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_DENSIDAD_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' DENSatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DENSIDAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DENSESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DENSCECA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_DENSIDAD_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_DENSIDAD(ByVal inDENSIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' DENSatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DENSIDAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DENSIDRE = '" & CInt(inDENSIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_DENSIDAD")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DENSIDAD(ByVal stDENSCECA As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' DENSatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DENSIDAD "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DENSCECA = '" & CStr(Trim(stDENSCECA)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_DENSIDAD")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el DENSIDAD por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_DENSIDAD(ByVal inDENSIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' DENSatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "DENSIDRE, "
            stConsultaSQL += "DENSCECA, "
            stConsultaSQL += "DENSDENS, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "DENSESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DENSIDAD, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DENSESTA = ESTACODI AND "
            stConsultaSQL += "DENSIDRE = '" & CInt(inDENSIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DENSCECA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_DENSIDAD")
            Return Nothing

        End Try

    End Function

End Class
