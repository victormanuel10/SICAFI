Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RESOCONS

    '==========================================
    '*** CLASE RESOLUCIONES DE CONSERVACION ***
    '==========================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RESOCONS(ByVal obRECONURE As Object, _
                                                         ByVal obRECOFERE As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRECONURE.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obRECOFERE.Text) = True Then

                Dim objdatos1 As New cla_RESOCONS
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_RESOCONS(obRECONURE.Text, obRECOFERE.Text)

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
    Public Function fun_Insertar_RESOCONS(ByVal inRECOSECU As Integer, _
                                          ByVal inRECOCLAS As Integer, _
                                          ByVal inRECONURE As Integer, _
                                          ByVal stRECOFERE As String, _
                                          ByVal inRECOCLSE As Integer, _
                                          ByVal inRECOVIRE As Integer, _
                                          ByVal inRECOVIFI As Integer, _
                                          ByVal inRECONURA As Integer, _
                                          ByVal stRECOFERA As String, _
                                          ByVal stRECODESC As String, _
                                          ByVal stRECONUDO As String, _
                                          ByVal stRECOUSUA As String, _
                                          ByVal stRECOOBSE As String, _
                                          ByVal stRECOFEES As String, _
                                          ByVal boRECOAJPR As Boolean, _
                                          ByVal boRECOAJVA As Boolean, _
                                          ByVal inRECOUNID As Integer, _
                                          ByVal stRECOESTA As String) As Boolean


        Try

            ' variables 
            Dim daRECOFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "RESOCONS "

            stConsultaSQL += "( "
            stConsultaSQL += "RECOSECU, "
            stConsultaSQL += "RECOCLAS, "
            stConsultaSQL += "RECONURE, "
            stConsultaSQL += "RECOFERE, "
            stConsultaSQL += "RECOCLSE, "
            stConsultaSQL += "RECOVIRE, "
            stConsultaSQL += "RECOVIFI, "
            stConsultaSQL += "RECONURA, "
            stConsultaSQL += "RECOFERA, "
            stConsultaSQL += "RECODESC, "
            stConsultaSQL += "RECONUDO, "
            stConsultaSQL += "RECOUSUA, "
            stConsultaSQL += "RECOFEIN, "
            stConsultaSQL += "RECOOBSE, "
            stConsultaSQL += "RECOFEES, "
            stConsultaSQL += "RECOAJPR, "
            stConsultaSQL += "RECOAJVA, "
            stConsultaSQL += "RECOUNID, "
            stConsultaSQL += "RECOESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRECOSECU) & "', "
            stConsultaSQL += "'" & CInt(inRECOCLAS) & "', "
            stConsultaSQL += "'" & CInt(inRECONURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECOFERE)) & "', "
            stConsultaSQL += "'" & CInt(inRECOCLSE) & "', "
            stConsultaSQL += "'" & CInt(inRECOVIRE) & "', "
            stConsultaSQL += "'" & CInt(inRECOVIFI) & "', "
            stConsultaSQL += "'" & CInt(inRECONURA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECOFERA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECODESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECONUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECOUSUA)) & "', "
            stConsultaSQL += "'" & CDate(daRECOFEIN) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECOOBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECOFEES)) & "', "
            stConsultaSQL += "'" & CBool(boRECOAJPR) & "', "
            stConsultaSQL += "'" & CBool(boRECOAJVA) & "', "
            stConsultaSQL += "'" & CInt(inRECOUNID) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRECOESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_RESOCONS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_RESOCONS(ByVal inRECOIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RESOCONS "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RESOCONS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_RESOCONS(ByVal inRECOSECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "RESOCONS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECOSECU = '" & CInt(inRECOSECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_RESOCONS")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_RESOCONS(ByVal inRECOIDRE As Integer, _
                                            ByVal inRECOCLAS As Integer, _
                                            ByVal inRECONURE As Integer, _
                                            ByVal stRECOFERE As String, _
                                            ByVal inRECOCLSE As Integer, _
                                            ByVal inRECOVIRE As Integer, _
                                            ByVal inRECOVIFI As Integer, _
                                            ByVal inRECONURA As Integer, _
                                            ByVal stRECOFERA As String, _
                                            ByVal stRECODESC As String, _
                                            ByVal stRECOFEES As String, _
                                            ByVal boRECOAJPR As Boolean, _
                                            ByVal boRECOAJVA As Boolean, _
                                            ByVal inRECOUNID As Integer, _
                                            ByVal stRECOESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "RESOCONS "

            stConsultaSQL += "SET "
            stConsultaSQL += "RECOCLAS = '" & CInt(inRECOCLAS) & "', "
            stConsultaSQL += "RECONURE = '" & CInt(inRECONURE) & "', "
            stConsultaSQL += "RECOFERE = '" & CStr(Trim(stRECOFERE)) & "', "
            stConsultaSQL += "RECOCLSE = '" & CInt(inRECOCLSE) & "', "
            stConsultaSQL += "RECOVIRE = '" & CInt(inRECOVIRE) & "', "
            stConsultaSQL += "RECOVIFI = '" & CInt(inRECOVIFI) & "', "
            stConsultaSQL += "RECONURA = '" & CInt(inRECONURA) & "', "
            stConsultaSQL += "RECOFERA = '" & CStr(Trim(stRECOFERA)) & "', "
            stConsultaSQL += "RECODESC = '" & CStr(Trim(stRECODESC)) & "', "
            stConsultaSQL += "RECOFEES = '" & CStr(Trim(stRECOFEES)) & "', "
            stConsultaSQL += "RECOAJPR = '" & CBool(boRECOAJPR) & "', "
            stConsultaSQL += "RECOAJVA = '" & CBool(boRECOAJVA) & "', "
            stConsultaSQL += "RECOUNID = '" & CInt(inRECOUNID) & "', "
            stConsultaSQL += "RECOESTA = '" & CStr(Trim(stRECOESTA)) & "' "


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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_RESOCONS")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RESOCONS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 0 "
            stConsultaSQL += "RECOIDRE, "
            stConsultaSQL += "RECOSECU, "
            stConsultaSQL += "RECOCLAS, "
            stConsultaSQL += "CLASDESC, "
            stConsultaSQL += "RECONURE, "
            stConsultaSQL += "RECOFERE, "
            stConsultaSQL += "RECOCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "RECOVIRE, "
            stConsultaSQL += "RECOVIFI, "
            stConsultaSQL += "RECONURA, "
            stConsultaSQL += "RECOFERA, "
            stConsultaSQL += "RECODESC, "
            stConsultaSQL += "RECONUDO, "
            stConsultaSQL += "RECOUSUA, "
            stConsultaSQL += "RECOFEIN, "
            stConsultaSQL += "RECOFEFI, "
            stConsultaSQL += "RECOUSFI, "
            stConsultaSQL += "RECONDFI, "
            stConsultaSQL += "RECOFELI, "
            stConsultaSQL += "RECOUSLI, "
            stConsultaSQL += "RECONDLI, "
            stConsultaSQL += "RECOAJLI, "
            stConsultaSQL += "RECODOAL, "
            stConsultaSQL += "RECOFEAL, "
            stConsultaSQL += "RECOUSAL, "
            stConsultaSQL += "RECONDAL, "
            stConsultaSQL += "RECOOBSE, "
            stConsultaSQL += "RECOFEES, "
            stConsultaSQL += "RECOESTA, "
            stConsultaSQL += "RECOAJPR, "
            stConsultaSQL += "RECOAJVA, "
            stConsultaSQL += "RECOUNID, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOCONS, MANT_CLASIFICACION, MANT_CLASSECT, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECOCLAS = CLASCODI AND "
            stConsultaSQL += "RECOCLSE = CLSECODI AND "
            stConsultaSQL += "RECOESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RECOSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RESOCONS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_RESOCONS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOCONS "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RECOSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_RESOCONS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_RESOCONS_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOCONS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECOESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RECOSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RESOCONS_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_RESOCONS_X_ESTADO(ByVal stRECOESTA As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOCONS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECOESTA = '" & CStr(Trim(stRECOESTA)) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RECOSECU "

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
    Public Function fun_Buscar_ID_RESOCONS(ByVal inRECOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOCONS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECOIDRE = '" & CInt(inRECOIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_RESOCONS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RESOCONS(ByVal inRECONURE As Integer, _
                                                 ByVal stRECOFERE As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOCONS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECONURE = '" & CInt(inRECONURE) & "'AND  "
            stConsultaSQL += "RECOFERE = '" & CStr(Trim(stRECOFERE)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_RESOCONS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_RESOCONS(ByVal inRECOSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOCONS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECOSECU = '" & CInt(inRECOSECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_RESOCONS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RESOCONS(ByVal inRECOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 1 "
            stConsultaSQL += "RECOIDRE, "
            stConsultaSQL += "RECOSECU, "
            stConsultaSQL += "RECOCLAS, "
            stConsultaSQL += "CLASDESC, "
            stConsultaSQL += "RECONURE, "
            stConsultaSQL += "RECOFERE, "
            stConsultaSQL += "RECOCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "RECOVIRE, "
            stConsultaSQL += "RECOVIFI, "
            stConsultaSQL += "RECONURA, "
            stConsultaSQL += "RECOFERA, "
            stConsultaSQL += "RECODESC, "
            stConsultaSQL += "RECONUDO, "
            stConsultaSQL += "RECOUSUA, "
            stConsultaSQL += "RECOFEIN, "
            stConsultaSQL += "RECOFEFI, "
            stConsultaSQL += "RECOUSFI, "
            stConsultaSQL += "RECONDFI, "
            stConsultaSQL += "RECOFELI, "
            stConsultaSQL += "RECOUSLI, "
            stConsultaSQL += "RECONDLI, "
            stConsultaSQL += "RECOAJLI, "
            stConsultaSQL += "RECODOAL, "
            stConsultaSQL += "RECOFEAL, "
            stConsultaSQL += "RECOUSAL, "
            stConsultaSQL += "RECONDAL, "
            stConsultaSQL += "RECOOBSE, "
            stConsultaSQL += "RECOFEES, "
            stConsultaSQL += "RECOESTA, "
            stConsultaSQL += "RECOAJPR, "
            stConsultaSQL += "RECOAJVA, "
            stConsultaSQL += "RECOUNID, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOCONS, MANT_CLASIFICACION, MANT_CLASSECT, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECOCLAS = CLASCODI AND "
            stConsultaSQL += "RECOCLSE = CLSECODI AND "
            stConsultaSQL += "RECOESTA = ESTACODI AND "
            stConsultaSQL += "RECOIDRE = '" & CInt(inRECOIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RECOSECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_RESOCONS")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_RESOCONS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RECOSECU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOCONS "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_X_RESOCONS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RESOCONS_X_BITACORA(ByVal stRECOESTA As String, ByVal boRECOAJLI As Boolean) As DataTable

        Try

            ' instancia la fecha
            Dim daFECHA As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RECOIDRE, "
            stConsultaSQL += "RECOSECU, "
            stConsultaSQL += "RECONURE, "
            stConsultaSQL += "RECOFERE, "
            stConsultaSQL += "RECOFEIN, "
            stConsultaSQL += "RECOFEES, "
            stConsultaSQL += "RECOVIFI, "
            stConsultaSQL += "(Select datediff(day, RECOFERE, '" & daFECHA & "')) AS RECOFERE_1, "

            If boRECOAJLI = True Then
                stConsultaSQL += "(Select datediff(day, RECOFEAL, '" & daFECHA & "')) AS RECOFEIN_1, "

            ElseIf boRECOAJLI = False Then
                stConsultaSQL += "(Select datediff(day, RECOFEIN, '" & daFECHA & "')) AS RECOFEIN_1, "

            End If

            stConsultaSQL += "RECOUNID, "
            stConsultaSQL += "RECOESTA, "
            stConsultaSQL += "RECOAJPR, "
            stConsultaSQL += "RECOAJVA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "RECOOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOCONS, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECOESTA = ESTACODI AND "
            stConsultaSQL += "RECOESTA = '" & CStr(Trim(stRECOESTA)) & "' AND "
            stConsultaSQL += "RECOAJLI = '" & CBool(boRECOAJLI) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RECONURE, RECOFERE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLAMOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RESOCONS_X_BITACORA(ByVal inRECOIDRE As Integer) As DataTable

        Try
            ' declaro la variable
            Dim stLIRAESTA As String = "ac"

            ' instancia la fecha
            Dim daFECHA As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RECOIDRE, "
            stConsultaSQL += "RECOSECU, "
            stConsultaSQL += "RECONURE, "
            stConsultaSQL += "RECOFERE, "
            stConsultaSQL += "RECOFEIN, "
            stConsultaSQL += "RECOVIRE, "
            stConsultaSQL += "RECOVIFI, "
            stConsultaSQL += "(Select datediff(day, RECOFERE, '" & daFECHA & "')) AS RECOFERE_1, "
            stConsultaSQL += "(Select datediff(day, RECOFEIN, '" & daFECHA & "')) AS RECOFEIN_1, "
            stConsultaSQL += "RECOESTA, "
            stConsultaSQL += "RECOAJPR, "
            stConsultaSQL += "RECOAJVA, "
            stConsultaSQL += "RECOUNID, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "RECOOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOCONS, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RECOESTA = ESTACODI AND "
            stConsultaSQL += "RECOESTA = '" & CStr(Trim(stLIRAESTA)) & "' AND "
            stConsultaSQL += "RECOIDRE = '" & CInt(inRECOIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RECONURE, RECOFERE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RECLAMOS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_Cantidad_de_Usuario_x_Estado_RESOCONS(ByVal stRECOUSFI As String, ByVal stRECOESTA As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "Select RECOUSFI as Usuario, "
            stConsultaSQL += "Count(1) as Cantidad "
            stConsultaSQL += "From RESOCONS "
            stConsultaSQL += "Where "
            stConsultaSQL += "RECOESTA = '" & CStr(Trim(stRECOESTA)) & "' AND "
            stConsultaSQL += "RECOUSFI = '" & CStr(Trim(stRECOUSFI)) & "' "
            stConsultaSQL += "Group by RECOUSFI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_Cantidad_de_Usuario_x_Estado_LIBRRADI")
            Return Nothing
        End Try

    End Function

    Public Function fun_Consultar_Cantidad_de_Usuario_RESOCONS() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "Select RECOUSFI as Usuario, "
            stConsultaSQL += "Count(1) as Cantidad "
            stConsultaSQL += "From RESOCONS "
            stConsultaSQL += "Where "
            stConsultaSQL += "RECOESTA = 'fi' "
            stConsultaSQL += "Group by RECOUSFI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_Cantidad_de_Usuario_LIBRRADI")
            Return Nothing
        End Try

    End Function

End Class
