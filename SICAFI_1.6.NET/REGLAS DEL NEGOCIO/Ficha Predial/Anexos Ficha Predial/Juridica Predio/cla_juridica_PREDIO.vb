Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_juridica_PREDIO

    '=======================
    '*** JURIDICA PREDIO ***
    '=======================

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_JURIDICA(ByVal inJURINUFI As Integer, _
                                          ByVal stJURIFOLI As String, _
                                          ByVal stJURIMASE As String, _
                                          ByVal stJURIMAAB As String, _
                                          ByVal stJURITOAB As String, _
                                          ByVal stJURIFOAB As String, _
                                          ByVal stJURIARTE As String, _
                                          ByVal boJURIFATR As Boolean, _
                                          ByVal stJURIADEO As String, _
                                          ByVal boJURIPLPT As Boolean, _
                                          ByVal stJURIOBSE As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "JURIDICA "

            stConsultaSQL += "( "
            stConsultaSQL += "JURINUFI, "
            stConsultaSQL += "JURIFOLI, "
            stConsultaSQL += "JURIMASE, "
            stConsultaSQL += "JURIMAAB, "
            stConsultaSQL += "JURITOAB, "
            stConsultaSQL += "JURIFOAB, "
            stConsultaSQL += "JURIARTE, "
            stConsultaSQL += "JURIFATR, "
            stConsultaSQL += "JURIADEO, "
            stConsultaSQL += "JURIPLPR, "
            stConsultaSQL += "JURIOBSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inJURINUFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stJURIFOLI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stJURIMASE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stJURIMAAB)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stJURITOAB)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stJURIFOAB)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stJURIARTE)) & "', "
            stConsultaSQL += "'" & CBool(boJURIFATR) & "', "
            stConsultaSQL += "'" & CStr(Trim(stJURIADEO)) & "', "
            stConsultaSQL += "'" & CBool(boJURIPLPT) & "', "
            stConsultaSQL += "'" & CStr(Trim(stJURIOBSE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_JURIDICA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_JURIDICA(ByVal inJURIIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "JURIDICA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "JURIIDRE = '" & CInt(inJURIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_JURIDICA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_NRO_FICHA_JURIDICA(ByVal inJURINUFI As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "JURIDICA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "JURINUFI = '" & CInt(inJURINUFI) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_JURIDICA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_ID_JURIDICA(ByVal inJURIIDRE As Integer, _
                                            ByVal inJURINUFI As Integer, _
                                            ByVal stJURIFOLI As String, _
                                            ByVal stJURIMASE As String, _
                                            ByVal stJURIMAAB As String, _
                                            ByVal stJURITOAB As String, _
                                            ByVal stJURIFOAB As String, _
                                            ByVal stJURIARTE As String, _
                                            ByVal boJURIFATR As Boolean, _
                                            ByVal stJURIADEO As String, _
                                            ByVal boJURIPLPT As Boolean, _
                                            ByVal stJURIOBSE As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "JURIDICA "

            stConsultaSQL += "SET "
            stConsultaSQL += "JURINUFI = '" & CInt(inJURINUFI) & "', "
            stConsultaSQL += "JURIFOLI = '" & CStr(Trim(stJURIFOLI)) & "', "
            stConsultaSQL += "JURIMASE = '" & CStr(Trim(stJURIMASE)) & "', "
            stConsultaSQL += "JURIMAAB = '" & CStr(Trim(stJURIMAAB)) & "', "
            stConsultaSQL += "JURITOAB = '" & CStr(Trim(stJURITOAB)) & "', "
            stConsultaSQL += "JURIFOAB = '" & CStr(Trim(stJURIFOAB)) & "', "
            stConsultaSQL += "JURIARTE = '" & CStr(Trim(stJURIARTE)) & "', "
            stConsultaSQL += "JURIFATR = '" & CBool(boJURIFATR) & "', "
            stConsultaSQL += "JURIADEO = '" & CStr(Trim(stJURIADEO)) & "', "
            stConsultaSQL += "JURIPLPT = '" & CBool(boJURIPLPT) & "', "
            stConsultaSQL += "JURIOBSE = '" & CStr(Trim(stJURIOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "JURIIDRE = '" & CInt(inJURIIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_JURIDICA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_NRO_FICHA_JURIDICA(ByVal inJURINUFI As Integer, _
                                            ByVal stJURIFOLI As String, _
                                            ByVal stJURIMASE As String, _
                                            ByVal stJURIMAAB As String, _
                                            ByVal stJURITOAB As String, _
                                            ByVal stJURIFOAB As String, _
                                            ByVal stJURIARTE As String, _
                                            ByVal boJURIFATR As Boolean, _
                                            ByVal stJURIADEO As String, _
                                            ByVal boJURIPLPT As Boolean, _
                                            ByVal stJURIOBSE As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "JURIDICA "

            stConsultaSQL += "SET "
            stConsultaSQL += "JURIFOLI = '" & CStr(Trim(stJURIFOLI)) & "', "
            stConsultaSQL += "JURIMASE = '" & CStr(Trim(stJURIMASE)) & "', "
            stConsultaSQL += "JURIMAAB = '" & CStr(Trim(stJURIMAAB)) & "', "
            stConsultaSQL += "JURITOAB = '" & CStr(Trim(stJURITOAB)) & "', "
            stConsultaSQL += "JURIFOAB = '" & CStr(Trim(stJURIFOAB)) & "', "
            stConsultaSQL += "JURIARTE = '" & CStr(Trim(stJURIARTE)) & "', "
            stConsultaSQL += "JURIFATR = '" & CBool(boJURIFATR) & "', "
            stConsultaSQL += "JURIADEO = '" & CStr(Trim(stJURIADEO)) & "', "
            stConsultaSQL += "JURIPLPR = '" & CBool(boJURIPLPT) & "', "
            stConsultaSQL += "JURIOBSE = '" & CStr(Trim(stJURIOBSE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "JURINUFI = '" & CInt(inJURINUFI) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_JURIDICA")
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_JURIDICA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "JURIDICA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "JURINUFI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_JURIDICA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_JURIDICA(ByVal inJURIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "JURIDICA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "JURIIDRE = '" & CInt(inJURIIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_JURIDICA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el NRO FICHA del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_NRO_FICHA_JURIDICA(ByVal inJURINUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "JURIDICA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "JURINUFI = '" & CInt(inJURINUFI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_JURIDICA")
            Return Nothing
        End Try

    End Function

End Class
