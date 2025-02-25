Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_AFORSUIM

    '=======================================
    '*** CLASE LIQUIDA AFORO DE IMPUESTO ***
    '=======================================

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_AFORSUIM(ByVal inAFSINUFI As Integer, _
                                            ByVal inAFSITIIM As Integer, _
                                            ByVal inAFSICONC As Integer, _
                                            ByVal inAFSIVIGE As Integer, _
                                            ByVal inAFSICLSE As Integer, _
                                            ByVal loAFSIVABA As Long, _
                                            ByVal loAFSIVALI As Long, _
                                            ByVal loAFSIVAIM As Long, _
                                            ByVal stAFSIZO01 As String, _
                                            ByVal stAFSIZO02 As String, _
                                            ByVal stAFSIZO03 As String, _
                                            ByVal stAFSIZO04 As String, _
                                            ByVal stAFSIZO05 As String, _
                                            ByVal stAFSIZO06 As String, _
                                            ByVal stAFSIZO07 As String, _
                                            ByVal stAFSITA01 As String, _
                                            ByVal stAFSITA02 As String, _
                                            ByVal stAFSITA03 As String, _
                                            ByVal stAFSITA04 As String, _
                                            ByVal stAFSITA05 As String, _
                                            ByVal stAFSITA06 As String, _
                                            ByVal stAFSITA07 As String, _
                                            ByVal inAFSIMOLI As Integer, _
                                            ByVal inAFSITIAF As Integer, _
                                            ByVal boAFSIEXEN As Boolean, _
                                            ByVal stAFSIESTA As String) As Boolean

        Try
            ' variables del sistema
            Dim stAFSIUSIN As String = vp_usuario
            Dim stAFSIUSMO As String = ""
            Dim daAFSIFEIN As Date = fun_fecha()
            Dim daAFSIFEMO As Date = fun_fecha()
            Dim daAFSIFEAF As Date = fun_fecha()
            Dim stAFSIMAQU As String = fun_Nombre_de_maquina()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "AFORSUIM "

            stConsultaSQL += "( "
            stConsultaSQL += "AFSINUFI, "
            stConsultaSQL += "AFSITIIM, "
            stConsultaSQL += "AFSICONC, "
            stConsultaSQL += "AFSIVIGE, "
            stConsultaSQL += "AFSICLSE, "
            stConsultaSQL += "AFSIVABA, "
            stConsultaSQL += "AFSIVALI, "
            stConsultaSQL += "AFSIVAIM, "
            stConsultaSQL += "AFSIZO01, "
            stConsultaSQL += "AFSIZO02, "
            stConsultaSQL += "AFSIZO03, "
            stConsultaSQL += "AFSIZO04, "
            stConsultaSQL += "AFSIZO05, "
            stConsultaSQL += "AFSIZO06, "
            stConsultaSQL += "AFSIZO07, "
            stConsultaSQL += "AFSITA01, "
            stConsultaSQL += "AFSITA02, "
            stConsultaSQL += "AFSITA03, "
            stConsultaSQL += "AFSITA04, "
            stConsultaSQL += "AFSITA05, "
            stConsultaSQL += "AFSITA06, "
            stConsultaSQL += "AFSITA07, "
            stConsultaSQL += "AFSIMOLI, "
            stConsultaSQL += "AFSITIAF, "
            stConsultaSQL += "AFSIEXEN, "
            stConsultaSQL += "AFSIFEAF, "
            stConsultaSQL += "AFSIESTA, "
            stConsultaSQL += "AFSIUSIN, "
            stConsultaSQL += "AFSIUSMO, "
            stConsultaSQL += "AFSIFEIN, "
            stConsultaSQL += "AFSIFEMO, "
            stConsultaSQL += "AFSIMAQU  "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inAFSINUFI) & "', "
            stConsultaSQL += "'" & CInt(inAFSITIIM) & "', "
            stConsultaSQL += "'" & CInt(inAFSICONC) & "', "
            stConsultaSQL += "'" & CInt(inAFSIVIGE) & "', "
            stConsultaSQL += "'" & CInt(inAFSICLSE) & "', "
            stConsultaSQL += "'" & CLng(loAFSIVABA) & "', "
            stConsultaSQL += "'" & CLng(loAFSIVALI) & "', "
            stConsultaSQL += "'" & CLng(loAFSIVAIM) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAFSIZO01)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAFSIZO02)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAFSIZO03)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAFSIZO04)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAFSIZO05)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAFSIZO06)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAFSIZO07)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAFSITA01)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAFSITA02)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAFSITA03)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAFSITA04)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAFSITA05)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAFSITA06)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAFSITA07)) & "', "
            stConsultaSQL += "'" & CInt(inAFSIMOLI) & "', "
            stConsultaSQL += "'" & CInt(inAFSITIAF) & "', "
            stConsultaSQL += "'" & CBool(boAFSIEXEN) & "', "
            stConsultaSQL += "'" & CDate(daAFSIFEAF) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAFSIESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAFSIUSIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAFSIUSMO)) & "', "
            stConsultaSQL += "'" & CDate(daAFSIFEIN) & "', "
            stConsultaSQL += "'" & CDate(daAFSIFEMO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stAFSIMAQU)) & "'  "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_AFORSUIM")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_AFORSUIM(ByVal inAFSIIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "AFORSUIM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AFSIIDRE = '" & CInt(inAFSIIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_AFORSUIM")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro con el numero de ficha.
    ''' </summary>
    Public Function fun_Eliminar_NUFI_X_AFORSUIM(ByVal inAFSINUFI As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "AFORSUIM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AFSINUFI = '" & CInt(inAFSINUFI) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_AFORSUIM")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro con el numero de ficha.
    ''' </summary>
    Public Function fun_Eliminar_NUFI_VIGE_CLSE_TIIM_CONC_X_AFORSUIM(ByVal inAFSINUFI As Integer, _
                                                                     ByVal inAFSIVIGE As Integer, _
                                                                     ByVal inAFSICLSE As Integer, _
                                                                     ByVal inAFSITIIM As Integer, _
                                                                     ByVal inAFSICONC As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "AFORSUIM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AFSINUFI = '" & CInt(inAFSINUFI) & "' and "
            stConsultaSQL += "AFSIVIGE = '" & CInt(inAFSIVIGE) & "' and "
            stConsultaSQL += "AFSICLSE = '" & CInt(inAFSICLSE) & "' and "
            stConsultaSQL += "AFSITIIM = '" & CInt(inAFSITIIM) & "' and "
            stConsultaSQL += "AFSICONC = '" & CInt(inAFSICONC) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_AFORSUIM")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_AFORSUIM(ByVal inAFSIIDRE As Integer, _
                                            ByVal inAFSINUFI As Integer, _
                                            ByVal stAFSIDEPA As String, _
                                            ByVal stAFSIMUNI As String, _
                                            ByVal stAFSICORR As String, _
                                            ByVal stAFSIBARR As String, _
                                            ByVal stAFSIMANZ As String, _
                                            ByVal stAFSIPRED As String, _
                                            ByVal stAFSIEDIF As String, _
                                            ByVal stAFSIUNPR As String, _
                                            ByVal inAFSITIFI As Integer, _
                                            ByVal inAFSICLSE As Integer, _
                                            ByVal inAFSIVIGE As Integer, _
                                            ByVal inAFSIZOEC As Integer, _
                                            ByVal inAFSIPORC As Integer, _
                                            ByVal stAFSIESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "AFORSUIM "

            stConsultaSQL += "SET "
            stConsultaSQL += "AFSINUFI = '" & CInt(inAFSINUFI) & "', "
            stConsultaSQL += "AFSIDEPA = '" & CStr(Trim(stAFSIDEPA)) & "', "
            stConsultaSQL += "AFSIMUNI = '" & CStr(Trim(stAFSIMUNI)) & "', "
            stConsultaSQL += "AFSICORR = '" & CStr(Trim(stAFSICORR)) & "', "
            stConsultaSQL += "AFSIBARR = '" & CStr(Trim(stAFSIBARR)) & "', "
            stConsultaSQL += "AFSIMANZ = '" & CStr(Trim(stAFSIMANZ)) & "', "
            stConsultaSQL += "AFSIPRED = '" & CStr(Trim(stAFSIPRED)) & "', "
            stConsultaSQL += "AFSIEDIF = '" & CStr(Trim(stAFSIEDIF)) & "', "
            stConsultaSQL += "AFSIUNPR = '" & CStr(Trim(stAFSIUNPR)) & "', "
            stConsultaSQL += "AFSITIFI = '" & CInt(inAFSITIFI) & "', "
            stConsultaSQL += "AFSICLSE = '" & CInt(inAFSICLSE) & "', "
            stConsultaSQL += "AFSIVIGE = '" & CInt(inAFSIVIGE) & "', "
            stConsultaSQL += "AFSIZOEC = '" & CInt(inAFSIZOEC) & "', "
            stConsultaSQL += "AFSIPORC = '" & CInt(inAFSIPORC) & "', "
            stConsultaSQL += "AFSIESTA = '" & CStr(Trim(stAFSIESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AFSIIDRE = '" & CInt(inAFSIIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_AFORSUIM")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_NUFI_DEPA_MUNI_CLSE_VIGE_ZONA_X_AFORSUIM(ByVal inAFSINUFI As Integer, _
                                                        ByVal stAFSIDEPA As String, _
                                                        ByVal stAFSIMUNI As String, _
                                                        ByVal inAFSICLSE As Integer, _
                                                        ByVal inAFSIVIGE As Integer, _
                                                        ByVal inAFSIZOEC As Integer, _
                                                        ByVal inAFSIPORC As Integer, _
                                                        ByVal stAFSIESTA As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "AFORSUIM "

            stConsultaSQL += "SET "
            stConsultaSQL += "AFSINUFI = '" & CInt(inAFSINUFI) & "', "
            stConsultaSQL += "AFSIDEPA = '" & CStr(Trim(stAFSIDEPA)) & "', "
            stConsultaSQL += "AFSIMUNI = '" & CStr(Trim(stAFSIMUNI)) & "', "
            stConsultaSQL += "AFSICLSE = '" & CInt(inAFSICLSE) & "', "
            stConsultaSQL += "AFSIVIGE = '" & CInt(inAFSIVIGE) & "', "
            stConsultaSQL += "AFSIZOEC = '" & CInt(inAFSIZOEC) & "', "
            stConsultaSQL += "AFSIPORC = '" & CInt(inAFSIPORC) & "', "
            stConsultaSQL += "AFSIESTA = '" & CStr(Trim(stAFSIESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AFSINUFI = '" & CInt(inAFSINUFI) & "' and "
            stConsultaSQL += "AFSIDEPA = '" & CStr(Trim(stAFSIDEPA)) & "' and "
            stConsultaSQL += "AFSIMUNI = '" & CStr(Trim(stAFSIMUNI)) & "' and "
            stConsultaSQL += "AFSICLSE = '" & CInt(inAFSICLSE) & "' and "
            stConsultaSQL += "AFSIVIGE = '" & CInt(inAFSIVIGE) & "' and "
            stConsultaSQL += "AFSIZOEC = '" & CInt(inAFSIZOEC) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_AFORSUIM")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_AFORSUIM() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "AFSIIDRE, "
            stConsultaSQL += "AFSINUFI, "
            stConsultaSQL += "AFSIDEPA, "
            stConsultaSQL += "AFSIMUNI, "
            stConsultaSQL += "AFSICORR, "
            stConsultaSQL += "AFSIBARR, "
            stConsultaSQL += "AFSIMANZ, "
            stConsultaSQL += "AFSIPRED, "
            stConsultaSQL += "AFSIEDIF, "
            stConsultaSQL += "AFSIUNPR, "
            stConsultaSQL += "AFSITIFI, "
            stConsultaSQL += "AFSICLSE, "
            stConsultaSQL += "AFSIVIGE, "
            stConsultaSQL += "AFSIZOEC, "
            stConsultaSQL += "AFSIPORC, "
            stConsultaSQL += "AFSIESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AFORSUIM "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AFSIDEPA, AFSIMUNI, AFSICLSE, AFSIVIGE, AFSIZOEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_AFORSUIM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_AFORSUIM() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AFORSUIM "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AFSIDEPA, AFSIMUNI, AFSICLSE, AFSIVIGE, AFSIZOEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_AFORSUIM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_AFORSUIM_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AFORSUIM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AFSIESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AFSIDEPA, AFSIMUNI, AFSICLSE, AFSIVIGE, AFSIZOEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_AFORSUIM_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_AFORSUIM(ByVal inAFSIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AFORSUIM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AFSIIDRE = '" & CInt(inAFSIIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_AFORSUIM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_NUFI_DEPA_MUNI_CLSE_VIGE_ZONA_X_AFORSUIM(ByVal inAFSINUFI As Integer, _
                                                                               ByVal stAFSIDEPA As String, _
                                                                               ByVal stAFSIMUNI As String, _
                                                                               ByVal inAFSICLSE As Integer, _
                                                                               ByVal inAFSIVIGE As Integer, _
                                                                               ByVal inAFSIZOEC As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AFORSUIM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AFSINUFI = '" & CInt(inAFSINUFI) & "' and "
            stConsultaSQL += "AFSIDEPA = '" & CStr(Trim(stAFSIDEPA)) & "' and "
            stConsultaSQL += "AFSIMUNI = '" & CStr(Trim(stAFSIMUNI)) & "' and "
            stConsultaSQL += "AFSICLSE = '" & CInt(inAFSICLSE) & "' and "
            stConsultaSQL += "AFSIVIGE = '" & CInt(inAFSIVIGE) & "' and "
            stConsultaSQL += "AFSIZOEC = '" & CInt(inAFSIZOEC) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_AFORSUIM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_NUFI_VIGE_X_AFORSUIM(ByVal inAFSINUFI As Integer, _
                                                           ByVal inAFSIVIGE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AFORSUIM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AFSINUFI = '" & CInt(inAFSINUFI) & "' and "
            stConsultaSQL += "AFSIVIGE = '" & CInt(inAFSIVIGE) & "'  "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_AFORSUIM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AFORSUIM(ByVal inAFSIIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "AFSIIDRE, "
            stConsultaSQL += "AFSINUFI, "
            stConsultaSQL += "AFSITIIM, "
            stConsultaSQL += "AFSICONC, "
            stConsultaSQL += "AFSIVIGE, "
            stConsultaSQL += "AFSIVALI, "
            stConsultaSQL += "AFSIVAIM, "
            stConsultaSQL += "AFSIZO01, "
            stConsultaSQL += "AFSIZO02, "
            stConsultaSQL += "AFSIZO03, "
            stConsultaSQL += "AFSIZO04, "
            stConsultaSQL += "AFSIZO05, "
            stConsultaSQL += "AFSIZO06, "
            stConsultaSQL += "AFSIZO07, "
            stConsultaSQL += "AFSITA01, "
            stConsultaSQL += "AFSITA02, "
            stConsultaSQL += "AFSITA03, "
            stConsultaSQL += "AFSITA04, "
            stConsultaSQL += "AFSITA05, "
            stConsultaSQL += "AFSITA06, "
            stConsultaSQL += "AFSITA07, "
            stConsultaSQL += "AFSIMOLI, "
            stConsultaSQL += "AFSITIAF, "
            stConsultaSQL += "AFSIEXEN, "
            stConsultaSQL += "AFSIFEAF, "
            stConsultaSQL += "AFSIESTA, "
            stConsultaSQL += "AFSIUSIN, "
            stConsultaSQL += "AFSIUSMO, "
            stConsultaSQL += "AFSIFEIN, "
            stConsultaSQL += "AFSIFEMO, "
            stConsultaSQL += "AFSIMAQU  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AFORSUIM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AFSIIDRE = '" & CInt(inAFSIIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AFSIVIGE, AFSITIIM, AFSICONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AFORSUIM")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_NUFI_X_CONSULTA_PARAMETRIZADA_AFORSUIM(ByVal inAFSINUFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "AFSIIDRE, "
            stConsultaSQL += "AFSINUFI, "
            stConsultaSQL += "AFSIVIGE, "
            stConsultaSQL += "AFSITIIM, "
            stConsultaSQL += "AFSICONC, "
            stConsultaSQL += "AFSICLSE, "
            stConsultaSQL += "AFSIVABA, "
            stConsultaSQL += "AFSIVALI, "
            stConsultaSQL += "AFSIVAIM, "
            stConsultaSQL += "AFSIZO01, "
            stConsultaSQL += "AFSIZO02, "
            stConsultaSQL += "AFSIZO03, "
            stConsultaSQL += "AFSIZO04, "
            stConsultaSQL += "AFSIZO05, "
            stConsultaSQL += "AFSIZO06, "
            stConsultaSQL += "AFSIZO07, "
            stConsultaSQL += "AFSITA01, "
            stConsultaSQL += "AFSITA02, "
            stConsultaSQL += "AFSITA03, "
            stConsultaSQL += "AFSITA04, "
            stConsultaSQL += "AFSITA05, "
            stConsultaSQL += "AFSITA06, "
            stConsultaSQL += "AFSITA07, "
            stConsultaSQL += "AFSIMOLI, "
            stConsultaSQL += "AFSITIAF, "
            stConsultaSQL += "AFSIEXEN, "
            stConsultaSQL += "AFSIFEAF, "
            stConsultaSQL += "AFSIESTA, "
            stConsultaSQL += "AFSIUSIN, "
            stConsultaSQL += "AFSIUSMO, "
            stConsultaSQL += "AFSIFEIN, "
            stConsultaSQL += "AFSIFEMO, "
            stConsultaSQL += "AFSIMAQU  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AFORSUIM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AFSINUFI = '" & CInt(inAFSINUFI) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AFSIVIGE "
            stConsultaSQL += "DESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AFORSUIM")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el Nro ficha y vigencia del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Consultar_NUFI_VIGE_X_AFORSUIM(ByVal inAFSINUFI As Integer, ByVal inAFSIVIGE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AFORSUIM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AFSINUFI = '" & CInt(inAFSINUFI) & "' and "
            stConsultaSQL += "AFSIVIGE = '" & CInt(inAFSIVIGE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AFSICLSE, AFSITIIM, AFSICONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AFORSUIM")
            Return Nothing

        End Try

    End Function
    ''' <summary>
    ''' Función que busca el Nro ficha y vigencia del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Consultar_NUFI_VIGE_CONC_X_AFORSUIM(ByVal inAFSINUFI As Integer, ByVal inAFSIVIGE As Integer, ByVal inAFSICONC As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "AFORSUIM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "AFSINUFI = '" & CInt(inAFSINUFI) & "' and "
            stConsultaSQL += "AFSICONC = '" & CInt(inAFSICONC) & "' and "
            stConsultaSQL += "AFSIVIGE = '" & CInt(inAFSIVIGE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "AFSICLSE, AFSITIIM, AFSICONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_AFORSUIM")
            Return Nothing

        End Try

    End Function

  
End Class
