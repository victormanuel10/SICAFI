Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_LIRADEDI

    '===================================================
    '*** CLASE LIBRO RADICADOR DESTINATARIO DIVISION ***
    '===================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_LIRADEDI(ByVal inLRDDNURA As Integer, _
                                                         ByVal stLRDDFERA As String, _
                                                         ByVal inLRDDSECU As Integer, _
                                                         ByVal obLRDDDIVI As Object, _
                                                         ByVal obLRDDFEAS As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(inLRDDNURA) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(stLRDDFERA) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(inLRDDSECU) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obLRDDDIVI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obLRDDFEAS.Text) = True Then

                Dim objdatos1 As New cla_LIRADEDI
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_LIRADEDI(inLRDDNURA, stLRDDFERA, inLRDDSECU, obLRDDDIVI.SelectedValue, obLRDDFEAS.Text)

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
    Public Function fun_Insertar_LIRADEDI(ByVal inLRDDNURA As Integer, _
                                          ByVal stLRDDFERA As String, _
                                          ByVal inLRDDSECU As Integer, _
                                          ByVal inLRDDDIVI As Integer, _
                                          ByVal stLRDDFEAS As String, _
                                          ByVal stLRDDNUDO As String, _
                                          ByVal stLRDDUSUA As String, _
                                          ByVal inLRDDNRDE As Integer, _
                                          ByVal stLRDDFEDE As String) As Boolean


        Try
            ' declara la variable
            Dim daLRDDFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "LIRADEDI "

            stConsultaSQL += "( "
            stConsultaSQL += "LRDDNURA, "
            stConsultaSQL += "LRDDFERA, "
            stConsultaSQL += "LRDDSECU, "
            stConsultaSQL += "LRDDDIVI, "
            stConsultaSQL += "LRDDFEAS, "
            stConsultaSQL += "LRDDFEIN, "
            stConsultaSQL += "LRDDNUDO, "
            stConsultaSQL += "LRDDUSUA, "
            stConsultaSQL += "LRDDNRDE, "
            stConsultaSQL += "LRDDFEDE "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inLRDDNURA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRDDFERA)) & "', "
            stConsultaSQL += "'" & CInt(inLRDDSECU) & "', "
            stConsultaSQL += "'" & CInt(inLRDDDIVI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRDDFEAS)) & "', "
            stConsultaSQL += "'" & CDate(daLRDDFEIN) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRDDNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRDDUSUA)) & "', "
            stConsultaSQL += "'" & CInt(inLRDDNRDE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLRDDFEDE)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_LIRADEDI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_LIRADEDI(ByVal inLRDDIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "LIRADEDI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRDDIDRE = '" & CInt(inLRDDIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_LIRADEDI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_LIRADEDI(ByVal inLRDDSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "LIRADEDI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRDDSECU = '" & CInt(inLRDDSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_LIRADEDI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_LIRADEDI(ByVal inLRDDIDRE As Integer, _
                                            ByVal inLRDDNURA As Integer, _
                                            ByVal stLRDDFERA As String, _
                                            ByVal inLRDDSECU As Integer, _
                                            ByVal inLRDDDIVI As Integer, _
                                            ByVal stLRDDFEAS As String, _
                                            ByVal inLRDDNRDE As Integer, _
                                            ByVal stLRDDFEDE As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "LIRADEDI "

            stConsultaSQL += "SET "
            stConsultaSQL += "LRDDNURA = '" & CInt(inLRDDNURA) & "', "
            stConsultaSQL += "LRDDFERA = '" & CStr(Trim(stLRDDFERA)) & "', "
            stConsultaSQL += "LRDDSECU = '" & CInt(inLRDDSECU) & "', "
            stConsultaSQL += "LRDDDIVI = '" & CInt(inLRDDDIVI) & "', "
            stConsultaSQL += "LRDDFEAS = '" & CStr(Trim(stLRDDFEAS)) & "', "
            stConsultaSQL += "LRDDNRDE = '" & CInt(inLRDDNRDE) & "', "
            stConsultaSQL += "LRDDFEDE = '" & CStr(Trim(stLRDDFEDE)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRDDIDRE = '" & CInt(inLRDDIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_LIRADEDI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_LIRADEDI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "LRDDIDRE, "
            stConsultaSQL += "LRDDNURA, "
            stConsultaSQL += "LRDDFERA, "
            stConsultaSQL += "LRDDSECU, "
            stConsultaSQL += "DIVIDESC, "
            stConsultaSQL += "LRDDFEAS, "
            stConsultaSQL += "LRDDFEIN, "
            stConsultaSQL += "LRDDNUDO, "
            stConsultaSQL += "LRDDUSUA, "
            stConsultaSQL += "LRDDNRDE, "
            stConsultaSQL += "LRDDFEDE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRADEDI, MANT_DIVISION "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "LRDDDIVI = DIVICODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LRDDIDRE DESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_LIRADEDI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_LIRADEDI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRADEDI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LRDDIDRE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_LIRADEDI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_LIRADEDI(ByVal inLRDDIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRADEDI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRDDIDRE = '" & CInt(inLRDDIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_LIRADEDI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_LIRADEDI(ByVal inLRDDNURA As Integer, _
                                                 ByVal stLRDDFERA As String, _
                                                 ByVal inLRDDSECU As Integer, _
                                                 ByVal inLRDDDIVI As Integer, _
                                                 ByVal stLRDDFEAS As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRADEDI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LRDDNURA = '" & CInt(inLRDDNURA) & "'AND  "
            stConsultaSQL += "LRDDFERA = '" & CStr(Trim(stLRDDFERA)) & "' AND "
            stConsultaSQL += "LRDDSECU = '" & CInt(inLRDDSECU) & "'AND  "
            stConsultaSQL += "LRDDDIVI = '" & CInt(inLRDDDIVI) & "' AND "
            stConsultaSQL += "LRDDFEAS = '" & CStr(Trim(stLRDDFEAS)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_LIRADEDI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LIRADEDI(ByVal inLRDDIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "LRDDIDRE, "
            stConsultaSQL += "LRDDNURA, "
            stConsultaSQL += "LRDDFERA, "
            stConsultaSQL += "LRDDSECU, "
            stConsultaSQL += "DIVIDESC, "
            stConsultaSQL += "LRDDFEAS, "
            stConsultaSQL += "LRDDFEIN, "
            stConsultaSQL += "LRDDNUDO, "
            stConsultaSQL += "LRDDUSUA, "
            stConsultaSQL += "LRDDNRDE, "
            stConsultaSQL += "LRDDFEDE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRADEDI, MANT_DIVISION "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "LRDDDIVI = DIVICODI AND "
            stConsultaSQL += "LRDDIDRE = '" & CInt(inLRDDIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LRDDIDRE DESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LIRADEDI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_LIRADEDI(ByVal inLRDDSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "LRDDIDRE, "
            stConsultaSQL += "LRDDNURA, "
            stConsultaSQL += "LRDDFERA, "
            stConsultaSQL += "LRDDSECU, "
            stConsultaSQL += "DIVIDESC, "
            stConsultaSQL += "LRDDFEAS, "
            stConsultaSQL += "LRDDFEIN, "
            stConsultaSQL += "LRDDNUDO, "
            stConsultaSQL += "LRDDUSUA, "
            stConsultaSQL += "LRDDNRDE, "
            stConsultaSQL += "LRDDFEDE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIRADEDI, MANT_DIVISION "

            stConsultaSQL += "WHERE  "
            stConsultaSQL += "LRDDDIVI = DIVICODI AND "
            stConsultaSQL += "LRDDSECU = '" & CInt(inLRDDSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LRDDIDRE DESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LIRADEDI")
            Return Nothing

        End Try

    End Function

End Class
