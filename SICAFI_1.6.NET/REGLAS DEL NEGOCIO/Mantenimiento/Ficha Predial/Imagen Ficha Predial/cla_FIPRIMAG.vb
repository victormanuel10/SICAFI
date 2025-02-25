Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_FIPRIMAG

    '==================================
    '*** CLASE IMAGEN FICHA PREDIAL ***
    '==================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_FIPRIMAG(ByVal obFPIMNUFI As Object, _
                                                         ByVal obFPIMUNID As Object, _
                                                         ByVal obFPIMNUFO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obFPIMNUFI.Text) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obFPIMUNID.Text) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obFPIMNUFO.Text) = True Then

                Dim objdatos1 As New cla_FIPRIMAG
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_FIPRIMAG(obFPIMNUFI.Text, obFPIMUNID.Text, obFPIMNUFO.Text)

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("La ficha " & obFPIMNUFI.Text & " - " & obFPIMUNID.Text & " - " & obFPIMNUFO.Text & " del campo " & obFPIMNUFI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    obFPIMNUFI.Focus()
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
    Public Function fun_Insertar_FIPRIMAG(ByVal inFPIMNUFI As Integer, _
                                          ByVal inFPIMUNID As Integer, _
                                          ByVal inFPIMNUFO As Integer, _
                                          ByVal stFPIMRUTA As String, _
                                          ByVal stFPIMDEPA As String, _
                                          ByVal stFPIMMUNI As String, _
                                          ByVal inFPIMCLSE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "FIPRIMAG "

            stConsultaSQL += "( "
            stConsultaSQL += "FPIMNUFI, "
            stConsultaSQL += "FPIMUNID, "
            stConsultaSQL += "FPIMNUFO, "
            stConsultaSQL += "FPIMRUTA, "
            stConsultaSQL += "FPIMDEPA, "
            stConsultaSQL += "FPIMMUNI, "
            stConsultaSQL += "FPIMCLSE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inFPIMNUFI) & "', "
            stConsultaSQL += "'" & CInt(inFPIMUNID) & "', "
            stConsultaSQL += "'" & CInt(inFPIMNUFO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFPIMRUTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFPIMDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFPIMMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inFPIMCLSE) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_FIPRIMAG")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_FIPRIMAG(ByVal inFPIMIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "FIPRIMAG "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPIMIDRE = '" & CInt(inFPIMIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_FIPRIMAG")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_FIPRIMAG() As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "FIPRIMAG "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_FIPRIMAG")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_X_NUFI_X_NUFO_X_FIPRIMAG(ByVal inFPIMNUFI As Integer, _
                                                          ByVal inFPIMUNID As Integer, _
                                                          ByVal inFPIMNUFO As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "FIPRIMAG "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPIMNUFI = '" & CInt(inFPIMNUFI) & "' AND "
            stConsultaSQL += "FPIMUNID = '" & CInt(inFPIMUNID) & "' AND "
            stConsultaSQL += "FPIMNUFO = '" & CInt(inFPIMNUFO) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_FIPRIMAG")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_X_DEPA_X_MUNI_X_CLSE_X_FIPRIMAG(ByVal stFPIMDEPA As String, _
                                                                 ByVal stFPIMMUNI As String, _
                                                                 ByVal inFPIMCLSE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "FIPRIMAG "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPIMDEPA = '" & CStr(Trim(stFPIMDEPA)) & "' AND "
            stConsultaSQL += "FPIMMUNI = '" & CStr(Trim(stFPIMMUNI)) & "' AND "
            stConsultaSQL += "FPIMCLSE = '" & CInt(inFPIMCLSE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_FIPRIMAG")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_FIPRIMAG(ByVal inFPIMNUFI As Integer, _
                                            ByVal inFPIMUNID As Integer, _
                                            ByVal inFPIMNUFO As Integer, _
                                            ByVal stFPIMRUTA As String, _
                                            ByVal stFPIMDEPA As String, _
                                            ByVal stFPIMMUNI As String, _
                                            ByVal inFPIMCLSE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "FIPRIMAG "

            stConsultaSQL += "SET "
            stConsultaSQL += "FPIMNUFI = '" & CInt(inFPIMNUFI) & "', "
            stConsultaSQL += "FPIMUNID = '" & CInt(inFPIMUNID) & "', "
            stConsultaSQL += "FPIMNUFO = '" & CInt(inFPIMNUFO) & "', "
            stConsultaSQL += "FPIMRUTA = '" & CStr(Trim(stFPIMRUTA)) & "', "
            stConsultaSQL += "FPIMDEPA = '" & CStr(Trim(stFPIMDEPA)) & "', "
            stConsultaSQL += "FPIMMUNI = '" & CStr(Trim(stFPIMMUNI)) & "', "
            stConsultaSQL += "FPIMCLSE = '" & CInt(inFPIMCLSE) & "' "


            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPIMNUFI = '" & CInt(inFPIMNUFI) & "' AND "
            stConsultaSQL += "FPIMUNID = '" & CInt(inFPIMUNID) & "' AND "
            stConsultaSQL += "FPIMNUFO = '" & CInt(inFPIMNUFO) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_FIPRIMAG")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_FIPRIMAG() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FPIMIDRE, "
            stConsultaSQL += "FPIMNUFI, "
            stConsultaSQL += "FPIMUNID, "
            stConsultaSQL += "FPIMNUFO  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FIPRIMAG "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FPIMNUFI,FPIMUNID,FPIMNUFO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_FIPRIMAG")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos FIPRIMAGrio principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_FIPRIMAG() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FIPRIMAG "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FPIMNUFI,FPIMUNID,FPIMNUFO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_FIPRIMAG")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_FIPRIMAG(ByVal inFPIMIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FIPRIMAG "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPIMIDRE = '" & CInt(inFPIMIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_FIPRIMAG")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_FIPRIMAG(ByVal inFPIMNUFI As Integer, _
                                               ByVal inFPIMUNID As Integer, _
                                               ByVal inFPIMNUFO As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FIPRIMAG "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPIMNUFI = '" & CInt(inFPIMNUFI) & "' AND "
            stConsultaSQL += "FPIMUNID = '" & CInt(inFPIMUNID) & "' AND "
            stConsultaSQL += "FPIMNUFO = '" & CInt(inFPIMNUFO) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_FIPRIMAG")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_FIPRIMAG(ByVal inFPIMNUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FIPRIMAG "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPIMNUFI = '" & CInt(inFPIMNUFI) & "'  "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_FIPRIMAG")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_FIPRIMAG(ByVal inFPIMIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FPIMIDRE, "
            stConsultaSQL += "FPIMNUFI, "
            stConsultaSQL += "FPIMUNID, "
            stConsultaSQL += "FPIMNUFO  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FIPRIMAG "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPIMIDRE = '" & CInt(inFPIMIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FPIMNUFI,FPIMUNID,FPIMNUFO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_FIPRIMAG")
            Return Nothing

        End Try

    End Function

End Class
