Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_FIPRCROQ

    '===================================
    '*** CLASE CROQUIS FICHA PREDIAL ***
    '===================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_FIPRCROQ(ByVal obFPCRNUFI As Object, _
                                                         ByVal obFPCRUNID As Object, _
                                                         ByVal obFPCRNUFO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obFPCRNUFI.Text) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obFPCRUNID.Text) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obFPCRNUFO.Text) = True Then

                Dim objdatos1 As New cla_FIPRCROQ
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_FIPRCROQ(obFPCRNUFI.Text, obFPCRUNID.Text, obFPCRNUFO.Text)

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("La ficha " & obFPCRNUFI.Text & " - " & obFPCRUNID.Text & " - " & obFPCRNUFO.Text & " del campo " & obFPCRNUFI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    obFPCRNUFI.Focus()
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
    Public Function fun_Insertar_FIPRCROQ(ByVal inFPCRNUFI As Integer, _
                                          ByVal inFPCRUNID As Integer, _
                                          ByVal inFPCRNUFO As Integer, _
                                          ByVal stFPCRRUTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "FIPRCROQ "

            stConsultaSQL += "( "
            stConsultaSQL += "FPCRNUFI, "
            stConsultaSQL += "FPCRUNID, "
            stConsultaSQL += "FPCRNUFO, "
            stConsultaSQL += "FPCRRUTA  "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inFPCRNUFI) & "', "
            stConsultaSQL += "'" & CInt(inFPCRUNID) & "', "
            stConsultaSQL += "'" & CInt(inFPCRNUFO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFPCRRUTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_FIPRCROQ")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_FIPRCROQ(ByVal inFPCRIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "FIPRCROQ "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPCRIDRE = '" & CInt(inFPCRIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_FIPRCROQ")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_FIPRCROQ() As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "FIPRCROQ "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_FIPRCROQ")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_X_NUFI_X_NUFO_X_FIPRCROQ(ByVal inFPCRNUFI As Integer, _
                                                          ByVal inFPCRUNID As Integer, _
                                                          ByVal inFPCRNUFO As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "FIPRCROQ "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPCRNUFI = '" & CInt(inFPCRNUFI) & "' AND "
            stConsultaSQL += "FPCRUNID = '" & CInt(inFPCRUNID) & "' AND "
            stConsultaSQL += "FPCRNUFO = '" & CInt(inFPCRNUFO) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_FIPRCROQ")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_FIPRCROQ(ByVal inFPCRNUFI As Integer, _
                                            ByVal inFPCRUNID As Integer, _
                                            ByVal inFPCRNUFO As Integer, _
                                            ByVal stFPCRRUTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "FIPRCROQ "

            stConsultaSQL += "SET "
            stConsultaSQL += "FPCRNUFI = '" & CInt(inFPCRNUFI) & "', "
            stConsultaSQL += "FPCRUNID = '" & CInt(inFPCRUNID) & "', "
            stConsultaSQL += "FPCRNUFO = '" & CInt(inFPCRNUFO) & "', "
            stConsultaSQL += "FPCRRUTA = '" & CStr(Trim(stFPCRRUTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPCRNUFI = '" & CInt(inFPCRNUFI) & "' AND "
            stConsultaSQL += "FPCRUNID = '" & CInt(inFPCRUNID) & "' AND "
            stConsultaSQL += "FPCRNUFO = '" & CInt(inFPCRNUFO) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_FIPRCROQ")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_FIPRCROQ() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FPCRIDRE, "
            stConsultaSQL += "FPCRNUFI, "
            stConsultaSQL += "FPCRUNID, "
            stConsultaSQL += "FPCRNUFO  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FIPRCROQ "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FPCRNUFI,FPCRUNID,FPCRNUFO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_FIPRCROQ")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos FIPRCROQrio principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_FIPRCROQ() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FIPRCROQ "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FPCRNUFI,FPCRUNID,FPCRNUFO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_FIPRCROQ")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_FIPRCROQ(ByVal inFPCRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FIPRCROQ "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPCRIDRE = '" & CInt(inFPCRIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_FIPRCROQ")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_FIPRCROQ(ByVal inFPCRNUFI As Integer, _
                                               ByVal inFPCRUNID As Integer, _
                                               ByVal inFPCRNUFO As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FIPRCROQ "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPCRNUFI = '" & CInt(inFPCRNUFI) & "' AND "
            stConsultaSQL += "FPCRUNID = '" & CInt(inFPCRUNID) & "' AND "
            stConsultaSQL += "FPCRNUFO = '" & CInt(inFPCRNUFO) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_FIPRCROQ")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_FIPRCROQ(ByVal inFPCRNUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FIPRCROQ "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPCRNUFI = '" & CInt(inFPCRNUFI) & "'  "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_FIPRCROQ")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_FIPRCROQ(ByVal inFPCRIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FPCRIDRE, "
            stConsultaSQL += "FPCRNUFI, "
            stConsultaSQL += "FPCRUNID, "
            stConsultaSQL += "FPCRNUFO  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FIPRCROQ "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPCRIDRE = '" & CInt(inFPCRIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FPCRNUFI,FPCRUNID,FPCRNUFO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_FIPRCROQ")
            Return Nothing

        End Try

    End Function

End Class
