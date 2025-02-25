Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_UBICVIVI

    '===================================
    '*** CLASE UBICACION DE VIVIENDA ***
    '===================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_UBICVIVI(ByVal obUBVICODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obUBVICODI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obUBVICODI.Text) = True Then

                    Dim objdatos1 As New cla_UBICVIVI
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_UBICVIVI(Trim(obUBVICODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obUBVICODI.Text & " del campo " & obUBVICODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obUBVICODI.Focus()
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
    Public Function fun_Insertar_MANT_UBICVIVI(ByVal inUBVICODI As Integer, _
                                               ByVal stUBVIDESC As String, _
                                               ByVal stUBVIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' UBVIatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_UBICVIVI "

            stConsultaSQL += "( "
            stConsultaSQL += "UBVICODI, "
            stConsultaSQL += "UBVIDESC, "
            stConsultaSQL += "UBVIESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inUBVICODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stUBVIDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stUBVIESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_UBICVIVI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_UBICVIVI(ByVal inUBVIIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' UBVIatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_UBICVIVI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "UBVIIDRE = '" & CInt(inUBVIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_UBICVIVI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_UBICVIVI(ByVal inUBVIIDRE As Integer, _
                                                 ByVal inUBVICODI As Integer, _
                                                 ByVal stUBVIDESC As String, _
                                                 ByVal stUBVIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' UBVIatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_UBICVIVI "

            stConsultaSQL += "SET "
            stConsultaSQL += "UBVICODI = '" & CInt(inUBVICODI) & "', "
            stConsultaSQL += "UBVIDESC = '" & CStr(Trim(stUBVIDESC)) & "', "
            stConsultaSQL += "UBVIESTA = '" & CStr(Trim(stUBVIESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "UBVIIDRE = '" & CInt(inUBVIIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_UBICVIVI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_UBICVIVI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' UBVIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "UBVIIDRE, "
            stConsultaSQL += "UBVICODI, "
            stConsultaSQL += "UBVIDESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "UBVIESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_UBICVIVI, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "UBVIESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "UBVICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_UBICVIVI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_UBICVIVI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' UBVIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_UBICVIVI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "UBVICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_UBICVIVI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_UBICVIVI_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' UBVIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_UBICVIVI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "UBVIESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "UBVICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_UBICVIVI_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_UBICVIVI(ByVal inUBVIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' UBVIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_UBICVIVI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "UBVIIDRE = '" & CInt(inUBVIIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_UBICVIVI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_UBICVIVI(ByVal inUBVICODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' UBVIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_UBICVIVI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "UBVICODI = '" & CInt(inUBVICODI) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_UBICVIVI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el UBICVIVI por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_UBICVIVI(ByVal inUBVIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' UBVIatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "UBVIIDRE, "
            stConsultaSQL += "UBVICODI, "
            stConsultaSQL += "UBVIDESC, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "UBVIESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_UBICVIVI, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "UBVIESTA = ESTACODI AND "
            stConsultaSQL += "UBVIIDRE = '" & CInt(inUBVIIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "UBVICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_UBICVIVI")
            Return Nothing

        End Try

    End Function

End Class
