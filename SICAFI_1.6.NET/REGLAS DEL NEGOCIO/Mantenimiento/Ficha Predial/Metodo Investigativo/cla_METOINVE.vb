﻿Imports DATOS

Public Class cla_METOINVE

    '============================
    '*** METODO INVESTIGATIVO ***
    '============================

    ''' <summary>
    ''' Verifica que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_METOINVE(ByVal obMEINCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obMEINCODI.Text) = True Then

                Dim objdatos1 As New cla_METOINVE
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_METOINVE(Trim(obMEINCODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obMEINCODI.Text & " del campo " & obMEINCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obMEINCODI.Focus()
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
    Public Function fun_Insertar_METOINVE(ByVal inMEINCODI As Integer, _
                                          ByVal stMEINDESC As String, _
                                          ByVal stMEINESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "METOINVE "

            stConsultaSQL += "( "
            stConsultaSQL += "MEINCODI, "
            stConsultaSQL += "MEINDESC, "
            stConsultaSQL += "MEINESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMEINCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMEINDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMEINESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_METOINVE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_METOINVE(ByVal inMEINIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "METOINVE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MEINIDRE = '" & CInt(inMEINIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_METOINVE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_METOINVE(ByVal inMEINIDRE As Integer, _
                                            ByVal inMEINCODI As Integer, _
                                            ByVal stMEINDESC As String, _
                                            ByVal stMEINESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "METOINVE "

            stConsultaSQL += "SET "
            stConsultaSQL += "MEINCODI = '" & CInt(inMEINCODI) & "', "
            stConsultaSQL += "MEINDESC = '" & CStr(Trim(stMEINDESC)) & "', "
            stConsultaSQL += "MEINESTA = '" & CStr(Trim(stMEINESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MEINIDRE = '" & CInt(inMEINIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_METOINVE")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_METOINVE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MEINIDRE, "
            stConsultaSQL += "MEINCODI, "
            stConsultaSQL += "MEINDESC, "
            stConsultaSQL += "MEINESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "METOINVE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MEINCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_METOINVE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el METOINVE "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_METOINVE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "METOINVE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MEINCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_METOINVE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el METOINVE "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_METOINVE_X_ESTADO() As DataTable

        Try
            Dim boInsertar As Boolean = True

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "METOINVE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MEINESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MEINCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_METOINVE_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_METOINVE(ByVal inMEINIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "METOINVE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MEINIDRE = '" & CInt(inMEINIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_METOINVE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_METOINVE(ByVal inMEINCODI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "METOINVE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MEINCODI = '" & CInt(inMEINCODI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_METOINVE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_METOINVE(ByVal inMEINIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MEINIDRE, "
            stConsultaSQL += "MEINCODI, "
            stConsultaSQL += "MEINDESC, "
            stConsultaSQL += "MEINESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "METOINVE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MEINIDRE = '" & CInt(inMEINIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MEINCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_METOINVE")
            Return Nothing

        End Try

    End Function

End Class
