Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_OBURPLPA

    '==================================================
    '*** OBLIGACIONES URBANISTICAS DEL PLAN PARCIAL ***
    '==================================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_OBURPLPA(ByVal stOUPPCLEN As String, _
                                                         ByVal inOUPPNURE As Integer, _
                                                         ByVal stOUPPFERE As String, _
                                                         ByVal inOUPPRESO As Integer, _
                                                         ByVal stOUPPFECH As String, _
                                                         ByVal inOUPPUAU As Integer, _
                                                         ByVal inOUPPCABE As Integer, _
                                                         ByVal inOUPPCLOU As Integer, _
                                                         ByVal inOUPPNULI As Integer) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(stOUPPCLEN) = True And
                obVerifica.fun_Verificar_Campo_Lleno(inOUPPNURE) = True And
                obVerifica.fun_Verificar_Campo_Lleno(stOUPPFERE) = True And
                obVerifica.fun_Verificar_Campo_Lleno(inOUPPRESO) = True And
                obVerifica.fun_Verificar_Campo_Lleno(stOUPPFECH) = True And
                obVerifica.fun_Verificar_Campo_Lleno(inOUPPUAU) = True And
                obVerifica.fun_Verificar_Campo_Lleno(inOUPPCABE) = True And
                obVerifica.fun_Verificar_Campo_Lleno(inOUPPCLOU) = True And
                 obVerifica.fun_Verificar_Campo_Lleno(inOUPPNULI) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(inOUPPNURE) = True And
                    obVerifica.fun_Verificar_Dato_Fecha(stOUPPFERE) = True And
                    obVerifica.fun_Verificar_Dato_Numerico(inOUPPRESO) = True And
                    obVerifica.fun_Verificar_Dato_Numerico(inOUPPUAU) = True And
                    obVerifica.fun_Verificar_Dato_Numerico(inOUPPCABE) = True And
                    obVerifica.fun_Verificar_Dato_Numerico(inOUPPCLOU) = True And
                    obVerifica.fun_Verificar_Dato_Numerico(inOUPPNULI) = True And
                     obVerifica.fun_Verificar_Dato_Fecha(stOUPPFECH) = True Then

                    Dim objdatos1 As New cla_OBURPLPA
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_OBURPLPA(Trim(stOUPPCLEN), inOUPPNURE, Trim(stOUPPFERE), inOUPPRESO, Trim(stOUPPFECH), inOUPPUAU, inOUPPCABE, inOUPPCLOU, inOUPPNULI)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(inOUPPRESO) & " - " & Trim(stOUPPFECH) & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        boRespuesta = False
                    Else
                        boRespuesta = True
                    End If

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
    Public Function fun_Insertar_OBURPLPA(ByVal inOUPPSECU As Integer, _
                                          ByVal stOUPPCLEN As String, _
                                          ByVal inOUPPNURE As Integer, _
                                          ByVal stOUPPFERE As String, _
                                          ByVal inOUPPRESO As Integer, _
                                          ByVal stOUPPFECH As String, _
                                          ByVal inOUPPUAU As Integer, _
                                          ByVal inOUPPCABE As Integer, _
                                          ByVal inOUPPCLOU As Integer, _
                                          ByVal inOUPPNULI As Integer, _
                                          ByVal inOUPPFOPA As Integer, _
                                          ByVal inOUPPCOFP As Integer, _
                                          ByVal stOUPPESTA As String) As Boolean

        Try
            ' declara las variables
            Dim daOUPPFEIN As Date = fun_fecha()
            Dim inOUPPVIGE As Integer = fun_Vigencia()

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' OUPPatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "OBURPLPA "

            stConsultaSQL += "( "
            stConsultaSQL += "OUPPSECU, "
            stConsultaSQL += "OUPPCLEN, "
            stConsultaSQL += "OUPPNURE, "
            stConsultaSQL += "OUPPFERE, "
            stConsultaSQL += "OUPPRESO, "
            stConsultaSQL += "OUPPFECH, "
            stConsultaSQL += "OUPPUAU, "
            stConsultaSQL += "OUPPCABE, "
            stConsultaSQL += "OUPPCLOU, "
            stConsultaSQL += "OUPPNULI, "
            stConsultaSQL += "OUPPFOPA, "
            stConsultaSQL += "OUPPCOFP, "
            stConsultaSQL += "OUPPVIGE, "
            stConsultaSQL += "OUPPFEIN, "
            stConsultaSQL += "OUPPESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inOUPPSECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUPPCLEN)) & "', "
            stConsultaSQL += "'" & CInt(inOUPPNURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUPPFERE)) & "', "
            stConsultaSQL += "'" & CInt(inOUPPRESO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUPPFECH)) & "', "
            stConsultaSQL += "'" & CInt(inOUPPUAU) & "', "
            stConsultaSQL += "'" & CInt(inOUPPCABE) & "', "
            stConsultaSQL += "'" & CInt(inOUPPCLOU) & "', "
            stConsultaSQL += "'" & CInt(inOUPPNULI) & "', "
            stConsultaSQL += "'" & CInt(inOUPPFOPA) & "', "
            stConsultaSQL += "'" & CInt(inOUPPCOFP) & "', "
            stConsultaSQL += "'" & CInt(inOUPPVIGE) & "', "
            stConsultaSQL += "'" & CDate(daOUPPFEIN) & "', "
            stConsultaSQL += "'" & CStr(Trim(stOUPPESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_OBURPLPA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_OBURPLPA(ByVal inOUPPIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' OUPPatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "OBURPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUPPIDRE = '" & CInt(inOUPPIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_OBURPLPA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_OBURPLPA(ByVal inOUPPSECU As Integer, _
                                          ByVal inOUPPCLOU As Integer, _
                                          ByVal inOUPPNULI As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' OUPPatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "OBURPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUPPSECU = '" & CInt(inOUPPSECU) & "' AND "
            stConsultaSQL += "OUPPCLOU = '" & CInt(inOUPPCLOU) & "' AND "
            stConsultaSQL += "OUPPNULI = '" & CInt(inOUPPNULI) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_OBURPLPA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_OBURPLPA(ByVal inOUPPIDRE As Integer, _
                                            ByVal inOUPPSECU As Integer, _
                                            ByVal stOUPPCLEN As String, _
                                            ByVal inOUPPNURE As Integer, _
                                            ByVal stOUPPFERE As String, _
                                            ByVal inOUPPRESO As Integer, _
                                            ByVal stOUPPFECH As String, _
                                            ByVal inOUPPUAU As Integer, _
                                            ByVal inOUPPCABE As Integer, _
                                            ByVal inOUPPCLOU As Integer, _
                                            ByVal inOUPPNULI As Integer, _
                                            ByVal inOUPPFOPA As Integer, _
                                            ByVal inOUPPCOFP As Integer, _
                                            ByVal stOUPPESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' OUPPatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "OBURPLPA "

            stConsultaSQL += "SET "
            stConsultaSQL += "OUPPSECU = '" & CInt(inOUPPSECU) & "', "
            stConsultaSQL += "OUPPCLEN = '" & CStr(Trim(stOUPPCLEN)) & "', "
            stConsultaSQL += "OUPPNURE = '" & CInt(inOUPPNURE) & "', "
            stConsultaSQL += "OUPPFERE = '" & CStr(Trim(stOUPPFERE)) & "', "
            stConsultaSQL += "OUPPRESO = '" & CInt(inOUPPRESO) & "', "
            stConsultaSQL += "OUPPFECH = '" & CStr(Trim(stOUPPFECH)) & "', "
            stConsultaSQL += "OUPPUAU = '" & CInt(inOUPPUAU) & "', "
            stConsultaSQL += "OUPPCABE = '" & CInt(inOUPPCABE) & "', "
            stConsultaSQL += "OUPPCLOU = '" & CInt(inOUPPCLOU) & "', "
            stConsultaSQL += "OUPPNULI = '" & CInt(inOUPPNULI) & "', "
            stConsultaSQL += "OUPPFOPA = '" & CInt(inOUPPFOPA) & "', "
            stConsultaSQL += "OUPPCOFP = '" & CInt(inOUPPCOFP) & "', "
            stConsultaSQL += "OUPPESTA = '" & CStr(Trim(stOUPPESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUPPIDRE = '" & CInt(inOUPPIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_OBURPLPA")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_OBURPLPA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' OUPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUPPIDRE, "
            stConsultaSQL += "OUPPSECU, "
            stConsultaSQL += "OUPPCLEN, "
            stConsultaSQL += "OUPPNURE, "
            stConsultaSQL += "OUPPFERE, "
            stConsultaSQL += "OUPPRESO, "
            stConsultaSQL += "OUPPFECH, "
            stConsultaSQL += "PLPADESC, "
            stConsultaSQL += "OUPPCLOU, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "OUPPCABE, "
            stConsultaSQL += "CBPPDESC, "
            stConsultaSQL += "OUPPUAU, "
            stConsultaSQL += "FPPPDESC, "
            stConsultaSQL += "COFPDESC, "
            stConsultaSQL += "OUPPNULI, "
            stConsultaSQL += "OUPPFOPA, "
            stConsultaSQL += "OUPPCOFP, "
            stConsultaSQL += "OUPPVIGE, "
            stConsultaSQL += "OUPPFEIN, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "OUPPESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURPLPA, ESTADO, MANT_PLANPARC, MANT_CLASOBUR, MANT_CABEPLPA, MANT_FOPAPLPA, MANT_COFPPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUPPESTA = ESTACODI AND "
            stConsultaSQL += "OUPPCLOU = CLOUCODI AND "
            stConsultaSQL += "OUPPRESO = PLPANURE AND "
            stConsultaSQL += "OUPPFECH = PLPAFERE AND "
            stConsultaSQL += "OUPPCABE = CBPPCODI AND "
            stConsultaSQL += "OUPPFOPA = FPPPCODI AND "
            stConsultaSQL += "OUPPCOFP = COFPCODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUPPNURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_OBURPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_OBURPLPA() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' OUPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURPLPA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUPPNURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_OBURPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_OBURPLPA_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' OUPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUPPESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUPPNURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_OBURPLPA_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_OBURPLPA(ByVal inOUPPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' OUPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUPPIDRE = '" & CInt(inOUPPIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_OBURPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el SECU del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_SECU_OBURPLPA(ByVal inOUPPSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' OUPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUPPSECU = '" & CInt(inOUPPSECU) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_OBURPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_OBURPLPA(ByVal stOUPPCLEN As String, _
                                               ByVal inOUPPNURE As Integer, _
                                               ByVal stOUPPFERE As String, _
                                               ByVal inOUPPRESO As Integer, _
                                               ByVal stOUPPFECH As String, _
                                               ByVal inOUPPUAU As Integer, _
                                               ByVal inOUPPCABE As Integer, _
                                               ByVal inOUPPCLOU As Integer, _
                                               ByVal inOUPPNULI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' OUPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUPPCLEN = '" & CStr(Trim(stOUPPCLEN)) & "' AND "
            stConsultaSQL += "OUPPNURE = '" & CInt(inOUPPNURE) & "' AND "
            stConsultaSQL += "OUPPFERE = '" & CStr(Trim(stOUPPFERE)) & "' AND "
            stConsultaSQL += "OUPPRESO = '" & CInt(inOUPPRESO) & "' AND "
            stConsultaSQL += "OUPPUAU = '" & CInt(inOUPPUAU) & "' AND "
            stConsultaSQL += "OUPPCABE = '" & CInt(inOUPPCABE) & "' AND "
            stConsultaSQL += "OUPPCLOU = '" & CInt(inOUPPCLOU) & "' AND "
            stConsultaSQL += "OUPPNULI = '" & CInt(inOUPPNULI) & "' AND "
            stConsultaSQL += "OUPPFECH = '" & CStr(Trim(stOUPPFECH)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_OBURPLPA")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el OBURPLPA por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURPLPA(ByVal inOUPPIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' OUPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUPPIDRE, "
            stConsultaSQL += "OUPPSECU, "
            stConsultaSQL += "OUPPCLEN, "
            stConsultaSQL += "OUPPNURE, "
            stConsultaSQL += "OUPPFERE, "
            stConsultaSQL += "OUPPRESO, "
            stConsultaSQL += "OUPPFECH, "
            stConsultaSQL += "PLPADESC, "
            stConsultaSQL += "OUPPCLOU, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "OUPPCABE, "
            stConsultaSQL += "CBPPDESC, "
            stConsultaSQL += "OUPPUAU, "
            stConsultaSQL += "FPPPDESC, "
            stConsultaSQL += "COFPDESC, "
            stConsultaSQL += "OUPPNULI, "
            stConsultaSQL += "OUPPFOPA, "
            stConsultaSQL += "OUPPCOFP, "
            stConsultaSQL += "OUPPVIGE, "
            stConsultaSQL += "OUPPFEIN, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "OUPPESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURPLPA, ESTADO, MANT_PLANPARC, MANT_CLASOBUR, MANT_CABEPLPA, MANT_FOPAPLPA, MANT_COFPPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUPPESTA = ESTACODI AND "
            stConsultaSQL += "OUPPCLOU = CLOUCODI AND "
            stConsultaSQL += "OUPPRESO = PLPANURE AND "
            stConsultaSQL += "OUPPFECH = PLPAFERE AND "
            stConsultaSQL += "OUPPCABE = CBPPCODI AND "
            stConsultaSQL += "OUPPFOPA = FPPPCODI AND "
            stConsultaSQL += "OUPPCOFP = COFPCODI AND "
            stConsultaSQL += "OUPPIDRE = '" & CInt(inOUPPIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUPPNURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURPLPA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el OBURPLPA por la SECU
    ''' </summary>
    Public Function fun_Buscar_CONSULTA_PARAMETRIZADA_OBURPLPA(ByVal inOUPPSECU As Integer, _
                                                               ByVal inOUPPCLOU As Integer, _
                                                               ByVal inOUPPNULI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' OUPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUPPIDRE, "
            stConsultaSQL += "OUPPSECU, "
            stConsultaSQL += "OUPPCLEN, "
            stConsultaSQL += "OUPPNURE, "
            stConsultaSQL += "OUPPFERE, "
            stConsultaSQL += "OUPPRESO, "
            stConsultaSQL += "OUPPFECH, "
            stConsultaSQL += "PLPADESC, "
            stConsultaSQL += "OUPPCLOU, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "OUPPCABE, "
            stConsultaSQL += "CBPPDESC, "
            stConsultaSQL += "OUPPUAU, "
            stConsultaSQL += "FPPPDESC, "
            stConsultaSQL += "COFPDESC, "
            stConsultaSQL += "OUPPNULI, "
            stConsultaSQL += "OUPPFOPA, "
            stConsultaSQL += "OUPPCOFP, "
            stConsultaSQL += "OUPPVIGE, "
            stConsultaSQL += "OUPPFEIN, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "OUPPESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURPLPA, ESTADO, MANT_PLANPARC, MANT_CLASOBUR, MANT_CABEPLPA, MANT_FOPAPLPA, MANT_COFPPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUPPESTA = ESTACODI AND "
            stConsultaSQL += "OUPPCLOU = CLOUCODI AND "
            stConsultaSQL += "OUPPRESO = PLPANURE AND "
            stConsultaSQL += "OUPPFECH = PLPAFERE AND "
            stConsultaSQL += "OUPPCABE = CBPPCODI AND "
            stConsultaSQL += "OUPPFOPA = FPPPCODI AND "
            stConsultaSQL += "OUPPCOFP = COFPCODI AND "
            stConsultaSQL += "OUPPSECU = '" & CInt(inOUPPSECU) & "' AND "
            stConsultaSQL += "OUPPCLOU = '" & CInt(inOUPPCLOU) & "' AND "
            stConsultaSQL += "OUPPNULI = '" & CInt(inOUPPNULI) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUPPNURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURPLPA")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el OBURPLPA por la SECU
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_OBURPLPA(ByVal inOUPPSECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' OUPPatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "SELECT "
            stConsultaSQL += "OUPPIDRE, "
            stConsultaSQL += "OUPPSECU, "
            stConsultaSQL += "OUPPCLEN, "
            stConsultaSQL += "OUPPNURE, "
            stConsultaSQL += "OUPPFERE, "
            stConsultaSQL += "OUPPRESO, "
            stConsultaSQL += "OUPPFECH, "
            stConsultaSQL += "PLPADESC, "
            stConsultaSQL += "OUPPCLOU, "
            stConsultaSQL += "CLOUDESC, "
            stConsultaSQL += "OUPPCABE, "
            stConsultaSQL += "CBPPDESC, "
            stConsultaSQL += "OUPPUAU, "
            stConsultaSQL += "FPPPDESC, "
            stConsultaSQL += "COFPDESC, "
            stConsultaSQL += "OUPPNULI, "
            stConsultaSQL += "OUPPFOPA, "
            stConsultaSQL += "OUPPCOFP, "
            stConsultaSQL += "OUPPVIGE, "
            stConsultaSQL += "OUPPFEIN, "
            stConsultaSQL += "ESTADESC, "
            stConsultaSQL += "OUPPESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "OBURPLPA, ESTADO, MANT_PLANPARC, MANT_CLASOBUR, MANT_CABEPLPA, MANT_FOPAPLPA, MANT_COFPPLPA "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "OUPPESTA = ESTACODI AND "
            stConsultaSQL += "OUPPCLOU = CLOUCODI AND "
            stConsultaSQL += "OUPPRESO = PLPANURE AND "
            stConsultaSQL += "OUPPFECH = PLPAFERE AND "
            stConsultaSQL += "OUPPCABE = CBPPCODI AND "
            stConsultaSQL += "OUPPFOPA = FPPPCODI AND "
            stConsultaSQL += "OUPPCOFP = COFPCODI AND "
            stConsultaSQL += "OUPPSECU = '" & CInt(inOUPPSECU) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "OUPPNURE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_OBURPLPA")
            Return Nothing

        End Try

    End Function

End Class
