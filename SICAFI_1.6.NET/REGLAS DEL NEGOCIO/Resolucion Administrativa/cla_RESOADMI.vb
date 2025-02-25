Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RESOADMI

    '=======================================
    '*** CLASE RESOLUCION ADMINISTRATIVA ***
    '=======================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RESOADMI(ByVal obREADNURE As Object, _
                                                         ByVal obREADFERE As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obREADNURE.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obREADFERE.Text) = True Then

                Dim objdatos1 As New cla_RESOADMI
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_RESOADMI(obREADNURE.Text, obREADFERE.Text)

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
    Public Function fun_Insertar_RESOADMI(ByVal inREADCLAS As Integer, _
                                          ByVal inREADNURE As Integer, _
                                          ByVal stREADFERE As String, _
                                          ByVal inREADTIRE As Integer, _
                                          ByVal inREADCLSE As Integer, _
                                          ByVal inREADVIRE As Integer, _
                                          ByVal stREADESTA As String) As Boolean


        Try

            ' variables 
            Dim daREADFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RESOADMI "

            stConsultaSQL += "( "
            stConsultaSQL += "READCLAS, "
            stConsultaSQL += "READNURE, "
            stConsultaSQL += "READFERE, "
            stConsultaSQL += "READTIRE, "
            stConsultaSQL += "READCLSE, "
            stConsultaSQL += "READVIRE, "
            stConsultaSQL += "READESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inREADCLAS) & "', "
            stConsultaSQL += "'" & CInt(inREADNURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREADFERE)) & "', "
            stConsultaSQL += "'" & CInt(inREADTIRE) & "', "
            stConsultaSQL += "'" & CInt(inREADCLSE) & "', "
            stConsultaSQL += "'" & CInt(inREADVIRE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stREADESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RESOADMI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RESOADMI(ByVal inREADIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RESOADMI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "READIDRE = '" & CInt(inREADIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RESOADMI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RESOADMI(ByVal inREADSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RESOADMI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "READSECU = '" & CInt(inREADSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RESOADMI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RESOADMI(ByVal inREADIDRE As Integer, _
                                            ByVal inREADCLAS As Integer, _
                                            ByVal inREADNURE As Integer, _
                                            ByVal stREADFERE As String, _
                                            ByVal inREADTIRE As Integer, _
                                            ByVal inREADCLSE As Integer, _
                                            ByVal inREADVIRE As Integer, _
                                            ByVal stREADESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RESOADMI "

            stConsultaSQL += "SET "
            stConsultaSQL += "READCLAS = '" & CInt(inREADCLAS) & "', "
            stConsultaSQL += "READNURE = '" & CInt(inREADNURE) & "', "
            stConsultaSQL += "READFERE = '" & CStr(Trim(stREADFERE)) & "', "
            stConsultaSQL += "READTIRE = '" & CInt(inREADTIRE) & "', "
            stConsultaSQL += "READCLSE = '" & CInt(inREADCLSE) & "', "
            stConsultaSQL += "READVIRE = '" & CInt(inREADVIRE) & "', "
            stConsultaSQL += "READESTA = '" & CStr(Trim(stREADESTA)) & "' "


            stConsultaSQL += "WHERE "
            stConsultaSQL += "READIDRE = '" & CInt(inREADIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RESOADMI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RESOADMI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "READIDRE, "
            stConsultaSQL += "READCLAS, "
            stConsultaSQL += "CLASDESC, "
            stConsultaSQL += "READNURE, "
            stConsultaSQL += "READFERE, "
            stConsultaSQL += "READTIRE, "
            stConsultaSQL += "TIREDESC, "
            stConsultaSQL += "READCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "READVIRE, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOADMI, MANT_CLASIFICACION, MANT_CLASSECT, MANT_TIPORESO, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "READCLAS = CLASCODI AND "
            stConsultaSQL += "READCLSE = CLSECODI AND "
            stConsultaSQL += "READTIRE = TIRECODI AND "
            stConsultaSQL += "READESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "READNURE, READFERE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RESOADMI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_RESOADMI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOADMI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "READNURE, READFERE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_RESOADMI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_RESOADMI_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOADMI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "READESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "READNURE, READFERE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RESOADMI_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_RESOADMI_X_ESTADO(ByVal stREADESTA As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOADMI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "READESTA = '" & CStr(Trim(stREADESTA)) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "READNURE, READFERE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_LIBRRADI_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_RESOADMI(ByVal inREADIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOADMI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "READIDRE = '" & CInt(inREADIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_RESOADMI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RESOADMI(ByVal inREADNURE As Integer, _
                                                 ByVal stREADFERE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOADMI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "READNURE = '" & CInt(inREADNURE) & "'AND  "
            stConsultaSQL += "READFERE = '" & CStr(Trim(stREADFERE)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_RESOADMI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RESOADMI(ByVal inREADSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOADMI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "READSECU = '" & CInt(inREADSECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RESOADMI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RESOADMI(ByVal inREADIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 1 "
            stConsultaSQL += "READIDRE, "
            stConsultaSQL += "READCLAS, "
            stConsultaSQL += "CLASDESC, "
            stConsultaSQL += "READNURE, "
            stConsultaSQL += "READFERE, "
            stConsultaSQL += "READTIRE, "
            stConsultaSQL += "TIREDESC, "
            stConsultaSQL += "READCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "READVIRE, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOADMI, MANT_CLASIFICACION, MANT_CLASSECT, MANT_TIPORESO, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "READCLAS = CLASCODI AND "
            stConsultaSQL += "READCLSE = CLSECODI AND "
            stConsultaSQL += "READTIRE = TIRECODI AND "
            stConsultaSQL += "READESTA = ESTACODI AND "
            stConsultaSQL += "READIDRE = '" & CInt(inREADIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "READNURE, READFERE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RESOADMI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_Todos_los_Registros_RESOADMI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "READIDRE, "
            stConsultaSQL += "READCLAS, "
            stConsultaSQL += "CLASDESC, "
            stConsultaSQL += "READNURE, "
            stConsultaSQL += "READFERE, "
            stConsultaSQL += "READTIRE, "
            stConsultaSQL += "TIREDESC, "
            stConsultaSQL += "READCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "READVIRE, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOADMI, MANT_CLASIFICACION, MANT_CLASSECT, MANT_TIPORESO, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "READCLAS = CLASCODI AND "
            stConsultaSQL += "READCLSE = CLSECODI AND "
            stConsultaSQL += "READTIRE = TIRECODI AND "
            stConsultaSQL += "READESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "READNURE, READFERE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RESOADMI")
            Return Nothing
        End Try

    End Function

End Class
