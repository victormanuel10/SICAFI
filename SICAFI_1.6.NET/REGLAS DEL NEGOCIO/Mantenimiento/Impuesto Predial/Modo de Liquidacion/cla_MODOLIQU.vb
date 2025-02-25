Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MODOLIQU

    '=================================
    '*** CLASE MODO DE LIQUIDACIÓN ***
    '=================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MODOLIQU(ByVal obMOLICODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obMOLICODI.Text) = True Then
                If obVerifica.fun_Verificar_Dato_Numerico(obMOLICODI.Text) = True Then

                    Dim objdatos1 As New cla_MODOLIQU
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_MANT_MODOLIQU(Trim(obMOLICODI.Text))

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obMOLICODI.Text & " del campo " & obMOLICODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obMOLICODI.Focus()
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
    Public Function fun_Insertar_MANT_MODOLIQU(ByVal inMOLICODI As Integer, _
                                               ByVal stMOLIDESC As String, _
                                               ByVal stMOLIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_MODOLIQU "

            stConsultaSQL += "( "
            stConsultaSQL += "MOLICODI, "
            stConsultaSQL += "MOLIDESC, "
            stConsultaSQL += "MOLIESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMOLICODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOLIDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMOLIESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_MODOLIQU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_MODOLIQU(ByVal inMOLIIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_MODOLIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOLIIDRE = '" & CInt(inMOLIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_MODOLIQU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_MODOLIQU(ByVal inMOLIIDRE As Integer, _
                                                 ByVal inMOLICODI As Integer, _
                                                 ByVal stMOLIDESC As String, _
                                                 ByVal stMOLIESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_MODOLIQU "

            stConsultaSQL += "SET "
            stConsultaSQL += "MOLICODI = '" & CInt(inMOLICODI) & "', "
            stConsultaSQL += "MOLIDESC = '" & CStr(Trim(stMOLIDESC)) & "', "
            stConsultaSQL += "MOLIESTA = '" & CStr(Trim(stMOLIESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOLIIDRE = '" & CInt(inMOLIIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_MODOLIQU")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_MODOLIQU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MOLIIDRE, "
            stConsultaSQL += "MOLICODI, "
            stConsultaSQL += "MOLIDESC, "
            stConsultaSQL += "MOLIESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MODOLIQU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MOLICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_MODOLIQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_MODOLIQU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MODOLIQU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CAPRCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_MODOLIQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_MODOLIQU_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MODOLIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOLIESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MOLICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_MODOLIQU_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_MODOLIQU(ByVal inMOLIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MODOLIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOLIIDRE = '" & CInt(inMOLIIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_MODOLIQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_MODOLIQU(ByVal inMOLICODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MODOLIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOLICODI = '" & CInt(inMOLICODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_MODOLIQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_MODOLIQU(ByVal inMOLIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MOLIIDRE, "
            stConsultaSQL += "MOLICODI, "
            stConsultaSQL += "MOLIDESC, "
            stConsultaSQL += "MOLIESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MODOLIQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MOLIIDRE = '" & CInt(inMOLIIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MOLICODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_MODOLIQU")
            Return Nothing

        End Try

    End Function

End Class
