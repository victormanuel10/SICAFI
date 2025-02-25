Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_LIRADEFU

    '======================================================
    '*** CLASE LIBRO RADICADOR DESTINATARIO FUNCIONARIO ***
    '======================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_LIRADEFU(ByVal inLRDFNURA As Integer, _
                                                         ByVal stLRDFFERA As String, _
                                                         ByVal inLRDFSECU As Integer, _
                                                         ByVal obLRDFNUDO As Object, _
                                                         ByVal obLRDFFEAS As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inLRDFNURA) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(stLRDFFERA) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(inLRDFSECU) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obLRDFNUDO.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obLRDFFEAS.Text) = True Then

                Dim objdatos1 As New cla_LIRADEFU
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_LIRADEFU(inLRDFNURA, stLRDFFERA, inLRDFSECU, obLRDFNUDO.SelectedValue, obLRDFFEAS.Text)

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
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
    Public Function fun_Insertar_LIRADEFU(ByVal inLRDFNURA As Integer, _
                                          ByVal stLRDFFERA As String, _
                                          ByVal inLRDFSECU As Integer, _
                                          ByVal stLRDFNUDO As String, _
                                          ByVal stLRDFFEAS As String, _
                                          ByVal stLRDFUSUA As String, _
                                          ByVal inLRDFNRDE As Integer, _
                                          ByVal stLRDFFEDE As String) As Boolean


        Try
            ' declara la variable
            Dim daLRDFFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "LIRADEFU "

            stConsultaSQL += "( "
            stConsultaSQL += "LRDFNURA, "
            stConsultaSQL += "LRDFFERA, "
            stConsultaSQL += "LRDFSECU, "
            stConsultaSQL += "LRDFNUDO, "
            stConsultaSQL += "LRDFFEAS, "
            stConsultaSQL += "LRDFFEIN, "
            stConsultaSQL += "LRDFUSUA, "
            stConsultaSQL += "LRDFNRDE, "
            stConsultaSQL += "LRDFFEDE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inLRDFNURA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRDFFERA)) & "', "
            stConsultaSQL += "'" & CInt(inLRDFSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRDFNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRDFFEAS)) & "', "
            stConsultaSQL += "'" & CDate(daLRDFFEIN) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRDFUSUA)) & "', "
            stConsultaSQL += "'" & CInt(inLRDFNRDE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRDFFEDE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_LIRADEFU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_LIRADEFU(ByVal inLRDFIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "LIRADEFU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRDFIDRE = '" & CInt(inLRDFIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_LIRADEFU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_LIRADEFU(ByVal inLRDFSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "LIRADEFU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRDFSECU = '" & CInt(inLRDFSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_LIRADEFU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_LIRADEFU(ByVal inLRDFIDRE As Integer, _
                                            ByVal inLRDFNURA As Integer, _
                                            ByVal stLRDFFERA As String, _
                                            ByVal inLRDFSECU As Integer, _
                                            ByVal stLRDFNUDO As String, _
                                            ByVal stLRDFFEAS As String, _
                                            ByVal inLRDFNRDE As Integer, _
                                            ByVal stLRDFFEDE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "LIRADEFU "

            stConsultaSQL += "SET "
            stConsultaSQL += "LRDFNURA = '" & CInt(inLRDFNURA) & "', "
            stConsultaSQL += "LRDFFERA = '" & CStr(Trim(stLRDFFERA)) & "', "
            stConsultaSQL += "LRDFSECU = '" & CInt(inLRDFSECU) & "', "
            stConsultaSQL += "LRDFNUDO = '" & CStr(Trim(stLRDFNUDO)) & "', "
            stConsultaSQL += "LRDFFEAS = '" & CStr(Trim(stLRDFFEAS)) & "', "
            stConsultaSQL += "LRDFNRDE = '" & CInt(inLRDFNRDE) & "', "
            stConsultaSQL += "LRDFFEDE = '" & CStr(Trim(stLRDFFEDE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRDFIDRE = '" & CInt(inLRDFIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_LIRADEFU")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_LIRADEFU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "LRDFIDRE, "
            stConsultaSQL += "LRDFNURA, "
            stConsultaSQL += "LRDFFERA, "
            stConsultaSQL += "LRDFSECU, "
            stConsultaSQL += "LRDFNUDO, "
            stConsultaSQL += "LRDFUSUA, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "LRDFFEAS, "
            stConsultaSQL += "LRDFFEIN, "
            stConsultaSQL += "LRDFNRDE, "
            stConsultaSQL += "LRDFFEDE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRADEFU, USUARIO "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "LRDFNUDO = USUANUDO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LRDFIDRE DESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_LIRADEFU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_LIRADEFU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRADEFU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LRDFIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_LIRADEFU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_LIRADEFU(ByVal inLRDFIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRADEFU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRDFIDRE = '" & CInt(inLRDFIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_LIRADEFU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_LIRADEFU(ByVal inLRDFNURA As Integer, _
                                                 ByVal stLRDFFERA As String, _
                                                 ByVal inLRDFSECU As Integer, _
                                                 ByVal stLRDFNUDO As String, _
                                                 ByVal stLRDFFEAS As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRADEFU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRDFNURA = '" & CInt(inLRDFNURA) & "'AND  "
            stConsultaSQL += "LRDFFERA = '" & CStr(Trim(stLRDFFERA)) & "' AND "
            stConsultaSQL += "LRDFSECU = '" & CInt(inLRDFSECU) & "'AND  "
            stConsultaSQL += "LRDFNUDO = '" & CStr(Trim(stLRDFNUDO)) & "' AND "
            stConsultaSQL += "LRDFFEAS = '" & CStr(Trim(stLRDFFEAS)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_LIRADEFU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LIRADEFU(ByVal inLRDFIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "LRDFIDRE, "
            stConsultaSQL += "LRDFNURA, "
            stConsultaSQL += "LRDFFERA, "
            stConsultaSQL += "LRDFSECU, "
            stConsultaSQL += "LRDFNUDO, "
            stConsultaSQL += "LRDFUSUA, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "LRDFFEAS, "
            stConsultaSQL += "LRDFFEIN, "
            stConsultaSQL += "LRDFNRDE, "
            stConsultaSQL += "LRDFFEDE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRADEFU, USUARIO "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "LRDFNUDO = USUANUDO AND "
            stConsultaSQL += "LRDFIDRE = '" & CInt(inLRDFIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LRDFIDRE DESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LIRADEFU")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_LIRADEFU(ByVal inLRDFSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "LRDFIDRE, "
            stConsultaSQL += "LRDFNURA, "
            stConsultaSQL += "LRDFFERA, "
            stConsultaSQL += "LRDFSECU, "
            stConsultaSQL += "LRDFNUDO, "
            stConsultaSQL += "LRDFUSUA, "
            stConsultaSQL += "USUANOMB, "
            stConsultaSQL += "USUAPRAP, "
            stConsultaSQL += "USUASEAP, "
            stConsultaSQL += "LRDFFEAS, "
            stConsultaSQL += "LRDFFEIN, "
            stConsultaSQL += "LRDFNRDE, "
            stConsultaSQL += "LRDFFEDE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRADEFU, USUARIO "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "LRDFNUDO = USUANUDO AND "
            stConsultaSQL += "LRDFSECU = '" & CInt(inLRDFSECU) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LRDFIDRE DESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LIRADEFU")
            Return Nothing

        End Try

    End Function

End Class
