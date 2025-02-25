Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_LIBRRADI

    '=============================
    '*** CLASE LIBRO RADICADOR ***
    '=============================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_LIBRRADI(ByVal obLIRANURA As Object, _
                                                         ByVal obLIRAFERA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obLIRANURA.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obLIRAFERA.Text) = True Then

                Dim objdatos1 As New cla_LIBRRADI
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_X_LIBRRADI(obLIRANURA.Text, obLIRAFERA.Text)

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
    Public Function fun_Insertar_LIBRRADI(ByVal inLIRASECU As Integer, _
                                          ByVal inLIRAACAD As Integer, _
                                          ByVal inLIRAMERE As Integer, _
                                          ByVal inLIRANURA As Integer, _
                                          ByVal stLIRAFERA As String, _
                                          ByVal stLIRAASUN As String, _
                                          ByVal inLIRAMENO As Integer, _
                                          ByVal stLIRAFEMN As String, _
                                          ByVal inLIRADIVI As Integer, _
                                          ByVal stLIRANUDO As String, _
                                          ByVal stLIRAUSUA As String, _
                                          ByVal stLIRAOBSE As String, _
                                          ByVal stLIRAOFSA As String, _
                                          ByVal stLIRAESTA As String, _
                                          ByVal stLIRAFEAS As String) As Boolean


        Try

            ' variables 
            Dim daLIRAFEIN As Date = fun_fecha()
            Dim inLIRAVIGE As Integer = fun_Vigencia()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "LIBRRADI "

            stConsultaSQL += "( "
            stConsultaSQL += "LIRASECU, "
            stConsultaSQL += "LIRAACAD, "
            stConsultaSQL += "LIRAMERE, "
            stConsultaSQL += "LIRANURA, "
            stConsultaSQL += "LIRAFERA, "
            stConsultaSQL += "LIRAASUN, "
            stConsultaSQL += "LIRAMENO, "
            stConsultaSQL += "LIRAFEMN, "
            stConsultaSQL += "LIRADIVI, "
            stConsultaSQL += "LIRANUDO, "
            stConsultaSQL += "LIRAUSUA, "
            stConsultaSQL += "LIRAFEIN, "
            stConsultaSQL += "LIRAVIGE, "
            stConsultaSQL += "LIRAOBSE, "
            stConsultaSQL += "LIRAOFSA, "
            stConsultaSQL += "LIRAESTA, "
            stConsultaSQL += "LIRAFEAS "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inLIRASECU) & "', "
            stConsultaSQL += "'" & CInt(inLIRAACAD) & "', "
            stConsultaSQL += "'" & CInt(inLIRAMERE) & "', "
            stConsultaSQL += "'" & CInt(inLIRANURA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLIRAFERA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLIRAASUN)) & "', "
            stConsultaSQL += "'" & CInt(inLIRAMENO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLIRAFEMN)) & "', "
            stConsultaSQL += "'" & CInt(inLIRADIVI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLIRANUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLIRAUSUA)) & "', "
            stConsultaSQL += "'" & CDate(daLIRAFEIN) & "', "
            stConsultaSQL += "'" & CInt(inLIRAVIGE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLIRAOBSE)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLIRAOFSA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLIRAESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stLIRAFEAS)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_LIBRRADI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_LIBRRADI(ByVal inLIRAIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "LIBRRADI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIRAIDRE = '" & CInt(inLIRAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_LIBRRADI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_LIBRRADI(ByVal inLIRASECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "LIBRRADI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIRASECU = '" & CInt(inLIRASECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_LIBRRADI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_LIBRRADI(ByVal inLIRAIDRE As Integer, _
                                            ByVal inLIRASECU As Integer, _
                                            ByVal inLIRAACAD As Integer, _
                                            ByVal inLIRAMERE As Integer, _
                                            ByVal inLIRANURA As Integer, _
                                            ByVal stLIRAFERA As String, _
                                            ByVal stLIRAASUN As String, _
                                            ByVal inLIRAMENO As Integer, _
                                            ByVal stLIRAFEMN As String, _
                                            ByVal inLIRADIVI As Integer, _
                                            ByVal stLIRANUDO As String, _
                                            ByVal stLIRAUSUA As String, _
                                            ByVal stLIRAOFSA As String, _
                                            ByVal stLIRAESTA As String, _
                                            ByVal stLIRAFEAS As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "LIBRRADI "

            stConsultaSQL += "SET "
            stConsultaSQL += "LIRASECU = '" & CInt(inLIRASECU) & "', "
            stConsultaSQL += "LIRAACAD = '" & CInt(inLIRAACAD) & "', "
            stConsultaSQL += "LIRAMERE = '" & CInt(inLIRAMERE) & "', "
            stConsultaSQL += "LIRANURA = '" & CInt(inLIRANURA) & "', "
            stConsultaSQL += "LIRAFERA = '" & CStr(Trim(stLIRAFERA)) & "', "
            stConsultaSQL += "LIRAASUN = '" & CStr(Trim(stLIRAASUN)) & "', "
            stConsultaSQL += "LIRAMENO = '" & CInt(inLIRAMENO) & "', "
            stConsultaSQL += "LIRAFEMN = '" & CStr(Trim(stLIRAFEMN)) & "', "
            stConsultaSQL += "LIRADIVI = '" & CInt(inLIRADIVI) & "', "
            stConsultaSQL += "LIRANUDO = '" & CStr(Trim(stLIRANUDO)) & "', "
            stConsultaSQL += "LIRAUSUA = '" & CStr(Trim(stLIRAUSUA)) & "', "
            stConsultaSQL += "LIRAOFSA = '" & CStr(Trim(stLIRAOFSA)) & "', "
            stConsultaSQL += "LIRAESTA = '" & CStr(Trim(stLIRAESTA)) & "', "
            stConsultaSQL += "LIRAFEAS = '" & CStr(Trim(stLIRAFEAS)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIRAIDRE = '" & CInt(inLIRAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_LIBRRADI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_LIBRRADI(ByVal inLIRAIDRE As Integer, _
                                            ByVal inLIRAMENO As Integer, _
                                            ByVal stLIRAFEMN As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "LIBRRADI "

            stConsultaSQL += "SET "
            stConsultaSQL += "LIRAMENO = '" & CInt(inLIRAMENO) & "', "
            stConsultaSQL += "LIRAFEMN = '" & CStr(Trim(stLIRAFEMN)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIRAIDRE = '" & CInt(inLIRAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_LIBRRADI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_LIBRRADI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 0 "
            stConsultaSQL += "LIRAIDRE, "
            stConsultaSQL += "LIRASECU, "
            stConsultaSQL += "LIRAACAD, "
            stConsultaSQL += "ACADDESC, "
            stConsultaSQL += "LIRAMERE, "
            stConsultaSQL += "MEREDESC, "
            stConsultaSQL += "LIRANURA, "
            stConsultaSQL += "LIRAFERA, "
            stConsultaSQL += "LIRAFEAS, "
            stConsultaSQL += "LIRAFEFI, "
            stConsultaSQL += "LIRAASUN, "
            stConsultaSQL += "LIRAMENO, "
            stConsultaSQL += "MENODESC, "
            stConsultaSQL += "LIRAFEMN, "
            stConsultaSQL += "LIRADIVI, "
            stConsultaSQL += "LIRAOFSA, "
            stConsultaSQL += "DIVIDESC, "
            stConsultaSQL += "LIRANUDO, "
            stConsultaSQL += "LIRAUSUA, "
            stConsultaSQL += "LIRAFEIN, "
            stConsultaSQL += "LIRAVIGE, "
            stConsultaSQL += "LIRAOBSE, "
            stConsultaSQL += "LIRAESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIBRRADI, MANT_ACTOADMI, MANT_MEDIRESE, MANT_MEDINOTI, MANT_DIVISION, VIGENCIA, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIRAACAD = ACADCODI AND "
            stConsultaSQL += "LIRAMERE = MERECODI AND "
            stConsultaSQL += "LIRAMENO = MENOCODI AND "
            stConsultaSQL += "LIRADIVI = DIVICODI AND "
            stConsultaSQL += "LIRAVIGE = VIGECODI AND "
            stConsultaSQL += "LIRAESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LIRASECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_LIBRRADI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_LIBRRADI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIBRRADI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LIRASECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_LIBRRADI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_LIBRRADI_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIBRRADI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIRAESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LIRASECU "

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
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_LIBRRADI_X_ESTADO(ByVal stLIRAESTA As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIBRRADI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIRAESTA = '" & CStr(Trim(stLIRAESTA)) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LIRASECU "

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
    Public Function fun_Buscar_ID_LIBRRADI(ByVal inLIRAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIBRRADI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIRAIDRE = '" & CInt(inLIRAIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_LIBRRADI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_LIBRRADI(ByVal inLIRANURA As Integer, _
                                                 ByVal stLIRAFERA As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIBRRADI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIRANURA = '" & CInt(inLIRANURA) & "'AND  "
            stConsultaSQL += "LIRAFERA = '" & CStr(Trim(stLIRAFERA)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_NURA_FERA_X_LIBRRADI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_LIBRRADI(ByVal inLIRASECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIBRRADI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIRASECU = '" & CInt(inLIRASECU) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_LIBRRADI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LIBRRADI(ByVal inLIRAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TOP 1 "
            stConsultaSQL += "LIRAIDRE, "
            stConsultaSQL += "LIRASECU, "
            stConsultaSQL += "LIRAACAD, "
            stConsultaSQL += "ACADDESC, "
            stConsultaSQL += "LIRAMERE, "
            stConsultaSQL += "MEREDESC, "
            stConsultaSQL += "LIRANURA, "
            stConsultaSQL += "LIRAFERA, "
            stConsultaSQL += "LIRAFEAS, "
            stConsultaSQL += "LIRAFEFI, "
            stConsultaSQL += "LIRAASUN, "
            stConsultaSQL += "LIRAMENO, "
            stConsultaSQL += "MENODESC, "
            stConsultaSQL += "LIRAFEMN, "
            stConsultaSQL += "LIRADIVI, "
            stConsultaSQL += "LIRAOFSA, "
            stConsultaSQL += "DIVIDESC, "
            stConsultaSQL += "LIRANUDO, "
            stConsultaSQL += "LIRAUSUA, "
            stConsultaSQL += "LIRAFEIN, "
            stConsultaSQL += "LIRAVIGE, "
            stConsultaSQL += "LIRAOBSE, "
            stConsultaSQL += "LIRAESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIBRRADI, MANT_ACTOADMI, MANT_MEDIRESE, MANT_MEDINOTI, MANT_DIVISION, VIGENCIA, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIRAACAD = ACADCODI AND "
            stConsultaSQL += "LIRAMERE = MERECODI AND "
            stConsultaSQL += "LIRAMENO = MENOCODI AND "
            stConsultaSQL += "LIRADIVI = DIVICODI AND "
            stConsultaSQL += "LIRAVIGE = VIGECODI AND "
            stConsultaSQL += "LIRAESTA = ESTACODI AND "
            stConsultaSQL += "LIRAIDRE = '" & CInt(inLIRAIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LIRASECU "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_LIBRRADI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_LIBRRADI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "LIRASECU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIBRRADI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_X_LIBRRADI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_LIBRRADI_X_BITACORA() As DataTable

        Try
           ' declaro la variable
            Dim stLIRAESTA As String = "fi"

            ' instancia la fecha
            Dim daMOGEFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "LIRAIDRE, "
            stConsultaSQL += "LIRASECU, "
            stConsultaSQL += "LIRANURA, "
            stConsultaSQL += "LIRAFERA, "
            stConsultaSQL += "LRDFFEAS, "
            stConsultaSQL += "LIRAFEAS, "
            stConsultaSQL += "LIRAFEIN, "
            stConsultaSQL += "(Select datediff(day, LIRAFERA, '" & daMOGEFEIN & "')) AS LIRADTFR, "
            stConsultaSQL += "(Select datediff(day, LRDFFEAS, '" & daMOGEFEIN & "')) AS LRDFDTFA, "
            stConsultaSQL += "LIRAFEFI, "
            stConsultaSQL += "LIRAVIGE, "
            stConsultaSQL += "LIRAESTA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "LIRAUSUA, "
            stConsultaSQL += "LIRANUDO, "
            stConsultaSQL += "A.USUANOMB, "
            stConsultaSQL += "A.USUAPRAP, "
            stConsultaSQL += "A.USUASEAP, "
            stConsultaSQL += "LRDFUSUA, "
            stConsultaSQL += "LRDFNUDO, "
            stConsultaSQL += "B.USUANOMB, "
            stConsultaSQL += "B.USUAPRAP, "
            stConsultaSQL += "B.USUASEAP, "
            stConsultaSQL += "LIRAASUN, "
            stConsultaSQL += "LIRAOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIBRRADI, LIRADEFU, USUARIO A, USUARIO B, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIRANURA = LRDFNURA AND "
            stConsultaSQL += "LIRAFERA = LRDFFERA AND "
            stConsultaSQL += "LIRASECU = LRDFSECU AND "
            stConsultaSQL += "LIRANUDO = A.USUANUDO AND "
            stConsultaSQL += "LRDFNUDO = B.USUANUDO AND "
            stConsultaSQL += "LIRAESTA = ESTACODI AND "
            stConsultaSQL += "LIRAESTA <> '" & CStr(Trim(stLIRAESTA)) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LIRANURA, LIRAFERA "

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
    Public Function fun_Consultar_LIBRRADI_X_BITACORA(ByVal stLIRANUDO As String) As DataTable

        Try
            ' declaro la variable
            Dim stLIRAESTA As String = "fi"

            ' instancia la fecha
            Dim daMOGEFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "LIRAIDRE, "
            stConsultaSQL += "LIRASECU, "
            stConsultaSQL += "LIRANURA, "
            stConsultaSQL += "LIRAFERA, "
            stConsultaSQL += "LRDFFEAS, "
            stConsultaSQL += "LIRAFEAS, "
            stConsultaSQL += "LIRAFEIN, "
            stConsultaSQL += "(Select datediff(day, LIRAFERA, '" & daMOGEFEIN & "')) AS LIRADTFR, "
            stConsultaSQL += "(Select datediff(day, LRDFFEAS, '" & daMOGEFEIN & "')) AS LRDFDTFA, "
            stConsultaSQL += "LIRAFEFI, "
            stConsultaSQL += "LIRAVIGE, "
            stConsultaSQL += "LIRAESTA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "LIRAUSUA, "
            stConsultaSQL += "LIRANUDO, "
            stConsultaSQL += "A.USUANOMB, "
            stConsultaSQL += "A.USUAPRAP, "
            stConsultaSQL += "A.USUASEAP, "
            stConsultaSQL += "LRDFUSUA, "
            stConsultaSQL += "LRDFNUDO, "
            stConsultaSQL += "B.USUANOMB, "
            stConsultaSQL += "B.USUAPRAP, "
            stConsultaSQL += "B.USUASEAP, "
            stConsultaSQL += "LIRAASUN, "
            stConsultaSQL += "LIRAOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIBRRADI, LIRADEFU, USUARIO A, USUARIO B, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIRANURA = LRDFNURA AND "
            stConsultaSQL += "LIRAFERA = LRDFFERA AND "
            stConsultaSQL += "LIRASECU = LRDFSECU AND "
            stConsultaSQL += "LIRANUDO = A.USUANUDO AND "
            stConsultaSQL += "LRDFNUDO = B.USUANUDO AND "
            stConsultaSQL += "LIRAESTA = ESTACODI AND "
            stConsultaSQL += "LIRAESTA <> '" & CStr(Trim(stLIRAESTA)) & "' AND "
            stConsultaSQL += "LRDFNUDO = '" & CStr(Trim(stLIRANUDO)) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LIRANURA, LIRAFERA "

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
    Public Function fun_Consultar_LIBRRADI_X_BITACORA(ByVal stLIRANUDO As String, _
                                                      ByVal stLIRAESTA As String) As DataTable

        Try

            ' instancia la fecha
            Dim daMOGEFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "LIRAIDRE, "
            stConsultaSQL += "LIRASECU, "
            stConsultaSQL += "LIRANURA, "
            stConsultaSQL += "LIRAFERA, "
            stConsultaSQL += "LRDFFEAS, "
            stConsultaSQL += "LIRAFEAS, "
            stConsultaSQL += "LIRAFEIN, "
            stConsultaSQL += "(Select datediff(day, LIRAFERA, '" & daMOGEFEIN & "')) AS LIRADTFR, "
            stConsultaSQL += "(Select datediff(day, LRDFFEAS, '" & daMOGEFEIN & "')) AS LRDFDTFA, "
            stConsultaSQL += "LIRAFEFI, "
            stConsultaSQL += "LIRAVIGE, "
            stConsultaSQL += "LIRAESTA, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "LIRAUSUA, "
            stConsultaSQL += "LIRANUDO, "
            stConsultaSQL += "A.USUANOMB, "
            stConsultaSQL += "A.USUAPRAP, "
            stConsultaSQL += "A.USUASEAP, "
            stConsultaSQL += "LRDFUSUA, "
            stConsultaSQL += "LRDFNUDO, "
            stConsultaSQL += "B.USUANOMB, "
            stConsultaSQL += "B.USUAPRAP, "
            stConsultaSQL += "B.USUASEAP, "
            stConsultaSQL += "LIRAASUN, "
            stConsultaSQL += "LIRAOBSE "

            stConsultaSQL += "FROM "
            stConsultaSQL += "LIBRRADI, LIRADEFU, USUARIO A, USUARIO B, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "LIRANURA = LRDFNURA AND "
            stConsultaSQL += "LIRAFERA = LRDFFERA AND "
            stConsultaSQL += "LIRASECU = LRDFSECU AND "
            stConsultaSQL += "LIRANUDO = A.USUANUDO AND "
            stConsultaSQL += "LRDFNUDO = B.USUANUDO AND "
            stConsultaSQL += "LIRAESTA = ESTACODI AND "
            stConsultaSQL += "LIRAESTA = '" & CStr(Trim(stLIRAESTA)) & "' AND "
            stConsultaSQL += "LRDFNUDO = '" & CStr(Trim(stLIRANUDO)) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "LIRANURA, LIRAFERA "

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
    Public Function fun_Consultar_Cantidad_de_Usuario_x_Estado_LIBRRADI(ByVal stLRDFUSUA As String, ByVal stLIRAESTA As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "Select LRDFUSUA as Usuario, "
            stConsultaSQL += "Count(1) as Cantidad "
            stConsultaSQL += "From LIBRRADI, LIRADEFU "
            stConsultaSQL += "Where "
            stConsultaSQL += "LIRANURA = LRDFNURA AND "
            stConsultaSQL += "LIRAFERA = LRDFFERA AND "
            stConsultaSQL += "LIRASECU = LRDFSECU AND "

            If Trim(stLIRAESTA) = "pe" Then
                stConsultaSQL += "LIRAESTA NOT IN ('fi','ca','in') AND "
            End If

            If Trim(stLIRAESTA) = "fi" Then
                stConsultaSQL += "LIRAESTA = '" & CStr(Trim(stLIRAESTA)) & "' AND "
            End If

            stConsultaSQL += "LRDFUSUA = '" & CStr(Trim(stLRDFUSUA)) & "' "
            stConsultaSQL += "Group by LRDFUSUA "

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

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_Cantidad_de_Usuario_LIBRRADI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "Select LRDFUSUA as Usuario, "
            stConsultaSQL += "Count(1) as Cantidad "
            stConsultaSQL += "From LIBRRADI, LIRADEFU "
            stConsultaSQL += "Where "
            stConsultaSQL += "LIRANURA = LRDFNURA AND "
            stConsultaSQL += "LIRAFERA = LRDFFERA AND "
            stConsultaSQL += "LIRASECU = LRDFSECU AND "
            stConsultaSQL += "LIRAESTA <> 'fi' "
            stConsultaSQL += "Group by LRDFUSUA "

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

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_Cantidad_x_Usuario_LIBRRADI(ByVal stUSUARIO As String) As DataTable

        Try
            ' instancia la fecha
            Dim daFECHA As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "(Select datediff(day, LRDFFEAS, '" & daFECHA & "')) AS Cantidad "
            stConsultaSQL += "From LIBRRADI, LIRADEFU "
            stConsultaSQL += "Where "
            stConsultaSQL += "LIRANURA = LRDFNURA AND "
            stConsultaSQL += "LIRAFERA = LRDFFERA AND "
            stConsultaSQL += "LIRASECU = LRDFSECU AND "
            stConsultaSQL += "LIRAESTA <> 'fi' AND "
            stConsultaSQL += "LRDFUSUA = '" & CStr(Trim(stUSUARIO)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_Cantidad_x_Usuario_LIBRRADI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_Cantidad_x_Usuario_y_Vigencia_LIBRRADI(ByVal stUSUARIO As String, _
                                                                         ByVal inVIGENCIA As Integer, _
                                                                         ByVal stESTADO As String) As DataTable

        Try
            ' instancia la fecha
            Dim daMOGEFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "LRDFUSUA, "
            stConsultaSQL += "LIRAVIGE, "
            stConsultaSQL += "Count(1) as Cantidad "
            stConsultaSQL += "From LIBRRADI, LIRADEFU "
            stConsultaSQL += "Where "
            stConsultaSQL += "LIRANURA = LRDFNURA AND "
            stConsultaSQL += "LIRAFERA = LRDFFERA AND "
            stConsultaSQL += "LIRASECU = LRDFSECU AND "
            stConsultaSQL += "LIRAESTA = '" & CStr(Trim(stESTADO)) & "' AND "
            stConsultaSQL += "LRDFUSUA = '" & CStr(Trim(stUSUARIO)) & "' AND "
            stConsultaSQL += "LIRAVIGE = '" & CInt(inVIGENCIA) & "' "
            stConsultaSQL += "Group by LRDFUSUA, LIRAVIGE "

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
    Public Function fun_Consultar_Cantidad_x_Vigencia_LIBRRADI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "LIRAVIGE as Vigencia, "
            stConsultaSQL += "Count(1) as Cantidad "
            stConsultaSQL += "From LIBRRADI, LIRADEFU "
            stConsultaSQL += "Where "
            stConsultaSQL += "LIRANURA = LRDFNURA AND "
            stConsultaSQL += "LIRAFERA = LRDFFERA AND "
            stConsultaSQL += "LIRASECU = LRDFSECU "
            stConsultaSQL += "Group by LIRAVIGE "

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
    Public Function fun_Consultar_Cantidad_x_Usuario_y_Vigencia_LIBRRADI(ByVal inVIGENCIA As Integer, _
                                                                         ByVal stESTADO As String) As DataTable

        Try
            ' instancia la fecha
            Dim daMOGEFEIN As Date = fun_fecha()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "Select "
            stConsultaSQL += "LIRAVIGE, "
            stConsultaSQL += "Count(1) as Cantidad "
            stConsultaSQL += "From LIBRRADI, LIRADEFU "
            stConsultaSQL += "Where "
            stConsultaSQL += "LIRANURA = LRDFNURA AND "
            stConsultaSQL += "LIRAFERA = LRDFFERA AND "
            stConsultaSQL += "LIRASECU = LRDFSECU AND "

            If Trim(stESTADO) = "ej" Then
                stConsultaSQL += "LIRAESTA NOT IN ('fi','ca','in') AND "
            End If

            If Trim(stESTADO) = "fi" Or Trim(stESTADO) = "ca" Then
                stConsultaSQL += "LIRAESTA = '" & CStr(Trim(stESTADO)) & "' AND "
            End If

            stConsultaSQL += "LIRAVIGE = '" & CInt(inVIGENCIA) & "' "
            stConsultaSQL += "Group by LIRAVIGE "

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

End Class
