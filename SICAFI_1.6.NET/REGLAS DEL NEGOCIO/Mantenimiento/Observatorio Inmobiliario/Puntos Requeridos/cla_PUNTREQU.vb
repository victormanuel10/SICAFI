Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_PUNTREQU

    '===============================
    '*** CLASE PUNTOS REQUERIDOS ***
    '===============================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_PUNTREQU(ByVal obPUREDEPA As Object, _
                                                         ByVal obPUREMUNI As Object, _
                                                         ByVal obPURECLSE As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obPUREDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPUREMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obPURECLSE.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obPUREDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obPUREMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obPURECLSE.SelectedValue) = True Then

                    Dim objdatos1 As New cla_PUNTREQU
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_PUNTREQU(obPUREDEPA.SelectedValue, _
                                                                                obPUREMUNI.SelectedValue, _
                                                                                obPURECLSE.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obPUREDEPA.Text) & " - " & _
                                                     Trim(obPUREMUNI.Text) & " - " & _
                                                     Trim(obPURECLSE.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obPUREDEPA.Focus()
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
    Public Function fun_Insertar_PUNTREQU(ByVal stPUREDEPA As String, _
                                          ByVal stPUREMUNI As String, _
                                          ByVal inPURECLSE As Integer, _
                                          ByVal inPUREPURE As Integer, _
                                          ByVal stPUREESTA As String) As Boolean

        Try

            ' variables del sistema
            Dim stPUREMAQU As String = fun_Nombre_de_maquina()
            Dim stPUREUSIN As String = vp_usuario
            Dim stPUREUSMO As String = ""

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "PUNTREQU "

            stConsultaSQL += "( "
            stConsultaSQL += "PUREDEPA, "
            stConsultaSQL += "PUREMUNI, "
            stConsultaSQL += "PURECLSE, "
            stConsultaSQL += "PUREPURE, "
            stConsultaSQL += "PUREESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stPUREDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPUREMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inPURECLSE) & "', "
            stConsultaSQL += "'" & CInt(inPUREPURE) & "', "
            stConsultaSQL += "'" & CStr(Trim(stPUREESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_PUNTREQU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_PUNTREQU(ByVal inPUREIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "PUNTREQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PUREIDRE = '" & CInt(inPUREIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_PUNTREQU")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_PUNTREQU(ByVal inPUREIDRE As Integer, _
                                            ByVal stPUREDEPA As String, _
                                            ByVal stPUREMUNI As String, _
                                            ByVal inPURECLSE As Integer, _
                                            ByVal inPUREPURE As Integer, _
                                            ByVal stPUREESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "PUNTREQU "

            stConsultaSQL += "SET "
            stConsultaSQL += "PUREDEPA = '" & CStr(Trim(stPUREDEPA)) & "', "
            stConsultaSQL += "PUREMUNI = '" & CStr(Trim(stPUREMUNI)) & "', "
            stConsultaSQL += "PURECLSE = '" & CInt(inPURECLSE) & "', "
            stConsultaSQL += "PUREPURE = '" & CInt(inPUREPURE) & "', "
            stConsultaSQL += "PUREESTA = '" & CStr(Trim(stPUREESTA)) & "' "
            
            stConsultaSQL += "WHERE "
            stConsultaSQL += "PUREIDRE = '" & CInt(inPUREIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_PUNTREQU")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_PUNTREQU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PUREIDRE, "
            stConsultaSQL += "PUREDEPA, "
            stConsultaSQL += "DEPADESC, "
            stConsultaSQL += "PUREMUNI, "
            stConsultaSQL += "MUNIDESC, "
            stConsultaSQL += "PURECLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "PUREPURE, "
            stConsultaSQL += "PUREESTA, "
            stConsultaSQL += "ESTADESC  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PUNTREQU, MANT_DEPARTAMENTO, MANT_MUNICIPIO, MANT_CLASSECT, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PUREDEPA = DEPACODI AND "
            stConsultaSQL += "PUREDEPA = MUNIDEPA AND "
            stConsultaSQL += "PUREMUNI = MUNICODI AND "
            stConsultaSQL += "PURECLSE = CLSECODI AND "
            stConsultaSQL += "PUREESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PUREDEPA, PUREMUNI, PURECLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_PUNTREQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_PUNTREQU() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PUNTREQU "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PUREDEPA, PUREMUNI, PURECLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_PUNTREQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_PUNTREQU_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PUNTREQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PUREESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PUREDEPA, PUREMUNI, PURECLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_PUNTREQU_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_PUNTREQU(ByVal inPUREIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PUNTREQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PUREIDRE = '" & CInt(inPUREIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_PUNTREQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_PUNTREQU(ByVal stPUREDEPA As String, _
                                                                ByVal stPUREMUNI As String, _
                                                                ByVal inPURECLSE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PUNTREQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PUREDEPA = '" & CStr(Trim(stPUREDEPA)) & "' and "
            stConsultaSQL += "PUREMUNI = '" & CStr(Trim(stPUREMUNI)) & "' and "
            stConsultaSQL += "PURECLSE = '" & CInt(inPURECLSE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_PUNTREQU")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_PUNTREQU(ByVal inPUREIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "PUREIDRE, "
            stConsultaSQL += "PUREDEPA, "
            stConsultaSQL += "DEPADESC, "
            stConsultaSQL += "PUREMUNI, "
            stConsultaSQL += "MUNIDESC, "
            stConsultaSQL += "PURECLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "PUREPURE, "
            stConsultaSQL += "PUREESTA, "
            stConsultaSQL += "ESTADESC  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PUNTREQU, MANT_DEPARTAMENTO, MANT_MUNICIPIO, MANT_CLASSECT, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PUREDEPA = DEPACODI AND "
            stConsultaSQL += "PUREDEPA = MUNIDEPA AND "
            stConsultaSQL += "PUREMUNI = MUNICODI AND "
            stConsultaSQL += "PURECLSE = CLSECODI AND "
            stConsultaSQL += "PUREESTA = ESTACODI AND "

            stConsultaSQL += "PUREIDRE = '" & CInt(inPUREIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "PUREDEPA, PUREMUNI, PURECLSE "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_PUNTREQU")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca por depa, muni, sector, vigencia
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_X_PUNTREQU(ByVal stPUREDEPA As String, _
                                                                     ByVal stPUREMUNI As String, _
                                                                     ByVal inPURECLSE As Integer, _
                                                                     ByVal inPUREPURE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "PUNTREQU "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "PUREDEPA = '" & CStr(Trim(stPUREDEPA)) & "' and "
            stConsultaSQL += "PUREMUNI = '" & CStr(Trim(stPUREMUNI)) & "' and "
            stConsultaSQL += "PURECLSE = '" & CInt(inPURECLSE) & "' and "
            stConsultaSQL += "PUREVIGE = '" & CInt(inPUREPURE) & "' "


            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_X_PUNTREQU")
            Return Nothing
        End Try

    End Function


End Class
