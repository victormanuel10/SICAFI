Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_TIPOIMPU

    '========================
    '*** TIPO DE IMPUESTO ***
    '========================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_TIPOIMPU(ByVal obTIIMCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obTIIMCODI.Text) = True Then
                If obVerifica.fun_Verificar_Dato_Numerico(obTIIMCODI.Text) = True Then

                    Dim objdatos1 As New cla_TIPOIMPU
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_MANT_TIPOIMPU(Trim(obTIIMCODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obTIIMCODI.Text & " del campo " & obTIIMCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obTIIMCODI.Focus()
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
    Public Function fun_Insertar_MANT_TIPOIMPU(ByVal inTIIMCODI As Integer, _
                                               ByVal stTIIMDESC As String, _
                                               ByVal stTIIMESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TIIMatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_TIPOIMPU "

            stConsultaSQL += "( "
            stConsultaSQL += "TIIMCODI, "
            stConsultaSQL += "TIIMDESC, "
            stConsultaSQL += "TIIMESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inTIIMCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTIIMDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTIIMESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_TIPOIMPU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_TIPOIMPU(ByVal inTIIMIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TIIMatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_TIPOIMPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TIIMIDRE = '" & CInt(inTIIMIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_TIPOIMPU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_TIPOIMPU(ByVal inTIIMIDRE As Integer, _
                                                 ByVal inTIIMCODI As Integer, _
                                                 ByVal stTIIMDESC As String, _
                                                 ByVal stTIIMESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TIIMatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_TIPOIMPU "

            stConsultaSQL += "SET "
            stConsultaSQL += "TIIMCODI = '" & CInt(inTIIMCODI) & "', "
            stConsultaSQL += "TIIMDESC = '" & CStr(Trim(stTIIMDESC)) & "', "
            stConsultaSQL += "TIIMESTA = '" & CStr(Trim(stTIIMESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TIIMIDRE = '" & CInt(inTIIMIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_TIPOIMPU")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_TIPOIMPU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TIIMatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TIIMIDRE, "
            stConsultaSQL += "TIIMCODI, "
            stConsultaSQL += "TIIMDESC, "
            stConsultaSQL += "TIIMESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOIMPU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TIIMCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_TIPOIMPU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_TIPOIMPU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TIIMatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOIMPU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TIIMCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_TIPOIMPU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_TIPOIMPU_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TIIMatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOIMPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TIIMESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TIIMCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_TIPOIMPU_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_TIPOIMPU(ByVal inTIIMIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TIIMatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOIMPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TIIMIDRE = '" & CInt(inTIIMIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_TIPOIMPU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_TIPOIMPU(ByVal inTIIMCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TIIMatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOIMPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TIIMCODI = '" & CInt(inTIIMCODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_TIPOIMPU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_TIPOIMPU(ByVal inTIIMIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' TIIMatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TIIMIDRE, "
            stConsultaSQL += "TIIMCODI, "
            stConsultaSQL += "TIIMDESC, "
            stConsultaSQL += "TIIMESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOIMPU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TIIMIDRE = '" & CInt(inTIIMIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TIIMCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_TIPOIMPU")
            Return Nothing

        End Try

    End Function

End Class
