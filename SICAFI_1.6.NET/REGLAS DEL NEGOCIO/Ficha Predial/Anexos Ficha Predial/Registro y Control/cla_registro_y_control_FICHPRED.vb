Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_registro_y_control_FICHPRED

    '===========================================
    '*** REGISTRO Y CONTROL DE FICHA PREDIAL ***
    '===========================================

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_REGICONT(ByVal inRECONUFI As Integer, _
                                          ByVal stRECOINGE As String, _
                                          ByVal stRECOPRED As String, _
                                          ByVal stRECOEMPR As String, _
                                          ByVal stRECOPROP As String, _
                                          ByVal stRECOREPR As String, _
                                          ByVal stRECOFECH As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "REGICONT "

            stConsultaSQL += "( "
            stConsultaSQL += "RECONUFI, "
            stConsultaSQL += "RECOINGE, "
            stConsultaSQL += "RECOPRED, "
            stConsultaSQL += "RECOEMPR, "
            stConsultaSQL += "RECOPROP, "
            stConsultaSQL += "RECOREPR, "
            stConsultaSQL += "RECOFECH  "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRECONUFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECOINGE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECOPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECOEMPR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECOPROP)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECOREPR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECOFECH.ToString.Substring(0, 10))) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_REGICONT")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_REGICONT(ByVal inRECOIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REGICONT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECOIDRE = '" & CInt(inRECOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_REGICONT")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_NRO_FICHA_REGICONT(ByVal inRECONUFI As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REGICONT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECONUFI = '" & CInt(inRECONUFI) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_REGICONT")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_ID_REGICONT(ByVal inRECOIDRE As Integer, _
                                            ByVal inRECONUFI As Integer, _
                                            ByVal stRECOINGE As String, _
                                            ByVal stRECOPRED As String, _
                                            ByVal stRECOEMPR As String, _
                                            ByVal stRECOPROP As String, _
                                            ByVal stRECOREPR As String, _
                                            ByVal stRECOFECH As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "REGICONT "

            stConsultaSQL += "SET "
            stConsultaSQL += "RECONUFI = '" & CInt(inRECONUFI) & "', "
            stConsultaSQL += "RECOINGE = '" & CStr(Trim(stRECOINGE)) & "', "
            stConsultaSQL += "RECOPRED = '" & CStr(Trim(stRECOPRED)) & "', "
            stConsultaSQL += "RECOEMPR = '" & CStr(Trim(stRECOEMPR)) & "', "
            stConsultaSQL += "RECOPROP = '" & CStr(Trim(stRECOPROP)) & "', "
            stConsultaSQL += "RECOREPR = '" & CStr(Trim(stRECOREPR)) & "', "
            stConsultaSQL += "RECOFECH = '" & CStr(Trim(stRECOFECH)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECOIDRE = '" & CInt(inRECOIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_REGICONT")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_NRO_FICHA_REGICONT(ByVal inRECONUFI As Integer, _
                                                      ByVal stRECOINGE As String, _
                                                      ByVal stRECOPRED As String, _
                                                      ByVal stRECOEMPR As String, _
                                                      ByVal stRECOPROP As String, _
                                                      ByVal stRECOREPR As String, _
                                                      ByVal stRECOFECH As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "REGICONT "

            stConsultaSQL += "SET "
            stConsultaSQL += "RECOINGE = '" & CStr(Trim(stRECOINGE)) & "', "
            stConsultaSQL += "RECOPRED = '" & CStr(Trim(stRECOPRED)) & "', "
            stConsultaSQL += "RECOEMPR = '" & CStr(Trim(stRECOEMPR)) & "', "
            stConsultaSQL += "RECOPROP = '" & CStr(Trim(stRECOPROP)) & "', "
            stConsultaSQL += "RECOREPR = '" & CStr(Trim(stRECOREPR)) & "', "
            stConsultaSQL += "RECOFECH = '" & CStr(Trim(stRECOFECH)) & "'  "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECONUFI = '" & CInt(inRECONUFI) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_REGICONT")
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_REGICONT() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REGICONT "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RECONUFI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_REGICONT")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_REGICONT(ByVal inRECOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REGICONT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECOIDRE = '" & CInt(inRECOIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_REGICONT")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el NRO FICHA del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_NRO_FICHA_REGICONT(ByVal inRECONUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REGICONT "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECONUFI = '" & CInt(inRECONUFI) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_REGICONT")
            Return Nothing
        End Try

    End Function


End Class
