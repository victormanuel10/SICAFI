Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_PERMCOCO

    '=========================================
    '*** CLASE PERMISO CONTROL DE COMANDOS ***
    '=========================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_PERMCOCO(ByVal obPECCUSUA As Object, _
                                                         ByVal obPECCFORM As Object, _
                                                         ByVal obPECCCOCO As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obPECCUSUA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPECCFORM.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPECCCOCO.SelectedValue) = True Then


                Dim objdatos1 As New cla_PERMCOCO
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_PERMCOCO(Trim(obPECCUSUA.SelectedValue), _
                                                             Trim(obPECCFORM.SelectedValue), _
                                                             Trim(obPECCCOCO.SelectedValue))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obPECCUSUA.SelectedValue & " - " & obPECCFORM.SelectedValue & " - " & obPECCCOCO.SelectedValue & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    obPECCUSUA.Focus()
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
    Public Function fun_Insertar_PERMCOCO(ByVal stPECCUSUA As String, _
                                          ByVal stPECCFORM As String, _
                                          ByVal stPECCCOCO As String, _
                                          ByVal boPECCHABI As Boolean, _
                                          ByVal boPECCDESH As Boolean, _
                                          ByVal stPECCESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "PERMCOCO "

            stConsultaSQL += "( "
            stConsultaSQL += "PECCUSUA, "
            stConsultaSQL += "PECCFORM, "
            stConsultaSQL += "PECCCOCO, "
            stConsultaSQL += "PECCHABI, "
            stConsultaSQL += "PECCDESH, "
            stConsultaSQL += "PECCESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stPECCUSUA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPECCFORM)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPECCCOCO)) & "', "
            stConsultaSQL += "'" & CBool(boPECCHABI) & "', "
            stConsultaSQL += "'" & CBool(boPECCDESH) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPECCESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_PERMCOCO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_PERMCOCO(ByVal inPECCIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "PERMCOCO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PECCIDRE = '" & CInt(inPECCIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_PERMCOCO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_PERMCOCO(ByVal inPECCIDRE As Integer, _
                                            ByVal stPECCUSUA As String, _
                                            ByVal stPECCFORM As String, _
                                            ByVal stPECCCOCO As String, _
                                            ByVal boPECCHABI As Boolean, _
                                            ByVal boPECCDESH As Boolean, _
                                            ByVal stPECCESTA As String) As Boolean


        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "PERMCOCO "

            stConsultaSQL += "SET "
            stConsultaSQL += "PECCUSUA = '" & CStr(Trim(stPECCUSUA)) & "', "
            stConsultaSQL += "PECCFORM = '" & CStr(Trim(stPECCFORM)) & "', "
            stConsultaSQL += "PECCCOCO = '" & CStr(Trim(stPECCCOCO)) & "', "
            stConsultaSQL += "PECCHABI = '" & CBool(boPECCHABI) & "', "
            stConsultaSQL += "PECCDESH = '" & CBool(boPECCDESH) & "', "
            stConsultaSQL += "PECCESTA = '" & CStr(Trim(stPECCESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PECCIDRE = '" & CInt(inPECCIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_PERMCOCO")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_PERMCOCO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PECCIDRE, "
            stConsultaSQL += "PECCUSUA, "
            stConsultaSQL += "PECCFORM, "
            stConsultaSQL += "PECCCOCO, "
            stConsultaSQL += "PECCHABI, "
            stConsultaSQL += "PECCDESH, "
            stConsultaSQL += "PECCESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PERMCOCO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PECCUSUA, PECCFORM, PECCCOCO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_PERMCOCO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_PERMCOCO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PERMCOCO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PECCUSUA, PECCFORM, PECCCOCO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_PERMCOCO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_PERMCOCO_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PERMCOCO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PECCESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PECCUSUA, PECCFORM, PECCCOCO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_PERMCOCO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_PERMCOCO(ByVal inPECCIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PERMCOCO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PECCIDRE = '" & CInt(inPECCIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_PERMCOCO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_PERMCOCO(ByVal stPECCUSUA As String, _
                                                 ByVal stPECCFORM As String, _
                                                 ByVal stPECCCOCO As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PERMCOCO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PECCUSUA = '" & CStr(Trim(stPECCUSUA)) & "' and "
            stConsultaSQL += "PECCFORM = '" & CStr(Trim(stPECCFORM)) & "' and "
            stConsultaSQL += "PECCCOCO = '" & CStr(Trim(stPECCCOCO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_PERMCOCO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_PERMCOCO(ByVal inPECCIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PECCIDRE, "
            stConsultaSQL += "PECCUSUA, "
            stConsultaSQL += "PECCFORM, "
            stConsultaSQL += "PECCCOCO, "
            stConsultaSQL += "PECCHABI, "
            stConsultaSQL += "PECCDESH, "
            stConsultaSQL += "PECCESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PERMCOCO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PECCIDRE = '" & CInt(inPECCIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PECCUSUA, PECCFORM, PECCCOCO "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_PERMCOCO")
            Return Nothing

        End Try

    End Function


End Class
