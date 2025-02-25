Imports DATOS
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class cla_CruceInformacionICARE

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_ICARE(ByVal stICARDEPA As String, _
                                       ByVal stICARMUNI As String, _
                                       ByVal inICARCLSE As Integer, _
                                       ByVal stICARCIRE As String, _
                                       ByVal stICARMAIN As String, _
                                       ByVal stICARPROR As String, _
                                       ByVal stICARTIPO As String, _
                                       ByVal stICARDIIC As String, _
                                       ByVal stICARPRIC As String, _
                                       ByVal stICARESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "ICARE "

            stConsultaSQL += "( "
            stConsultaSQL += "ICARDEPA, "
            stConsultaSQL += "ICARMUNI, "
            stConsultaSQL += "ICARCLSE, "
            stConsultaSQL += "ICARCIRE, "
            stConsultaSQL += "ICARMAIN, "
            stConsultaSQL += "ICARPROR, "
            stConsultaSQL += "ICARTIPO, "
            stConsultaSQL += "ICARDIIC, "
            stConsultaSQL += "ICARPRIC, "
            stConsultaSQL += "ICARESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stICARDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stICARMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inICARCLSE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stICARCIRE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stICARMAIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stICARPROR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stICARTIPO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stICARDIIC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stICARPRIC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stICARESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_AREACONS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_ICARE(ByVal stICARDEPA As String, _
                                       ByVal stICARMUNI As String, _
                                       ByVal inICARCLSE As Integer) As Boolean


        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "ICARE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "ICARDEPA = '" & CStr(Trim(stICARDEPA)) & "' AND "
            stConsultaSQL += "ICARMUNI = '" & CStr(Trim(stICARMUNI)) & "' AND "
            stConsultaSQL += "ICARCLSE = '" & CInt(inICARCLSE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_AREACONS")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_ICARE_X_DEPA_Y_MUNI(ByVal stICARDEPA As String, _
                                                      ByVal stICARMUNI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "ICARDEPA, "
            stConsultaSQL += "ICARMUNI, "
            stConsultaSQL += "ICARCLSE, "
            stConsultaSQL += "ICARCIRE, "
            stConsultaSQL += "ICARMAIN, "
            stConsultaSQL += "ICARPROR, "
            stConsultaSQL += "ICARTIPO, "
            stConsultaSQL += "ICARDIIC, "
            stConsultaSQL += "ICARPRIC, "
            stConsultaSQL += "ICARESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "ICARE "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "ICARDEPA = '" & CStr(Trim(stICARDEPA)) & "' AND "
            stConsultaSQL += "ICARMUNI = '" & CStr(Trim(stICARMUNI)) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "ICARIDRE DESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_ICARE_X_DEPA_Y_MUNI")
            Return Nothing
        End Try

    End Function

End Class
