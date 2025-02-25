Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_DEECLOTE

    '=============================================
    '*** CLASE DESTINACION ECONOMICA POR LOTES ***
    '=============================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_DEECLOTE(ByVal obDELODEPA As Object, _
                                                         ByVal obDELOMUNI As Object, _
                                                         ByVal obDELOCLSE As Object, _
                                                         ByVal obDELOVIGE As Object, _
                                                         ByVal obDELODEEC As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obDELODEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obDELOMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obDELOCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obDELOVIGE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obDELODEEC.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obDELODEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obDELOMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obDELOCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obDELOVIGE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obDELODEEC.SelectedValue) = True Then

                    Dim objdatos1 As New cla_DEECLOTE
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_DEEC_X_DEECLOTE(obDELODEPA.SelectedValue, _
                                                                                          obDELOMUNI.SelectedValue, _
                                                                                          obDELOCLSE.SelectedValue, _
                                                                                          obDELOVIGE.SelectedValue, _
                                                                                          obDELODEEC.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obDELODEPA.Text) & " - " & _
                                                     Trim(obDELOMUNI.Text) & " - " & _
                                                     Trim(obDELOCLSE.Text) & " - " & _
                                                     Trim(obDELOVIGE.Text) & " - " & _
                                                     Trim(obDELODEEC.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obDELODEPA.Focus()
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
    Public Function fun_Insertar_DEECLOTE(ByVal stDELODEPA As String, _
                                          ByVal stDELOMUNI As String, _
                                          ByVal inDELOCLSE As Integer, _
                                          ByVal inDELOVIGE As Integer, _
                                          ByVal inDELODEEC As Integer, _
                                          ByVal boDELOLOTE As Boolean, _
                                          ByVal boDELOLE44 As Boolean, _
                                          ByVal boDELOIMPR As Boolean, _
                                          ByVal boDELOACBO As Boolean, _
                                          ByVal boDELOALPU As Boolean, _
                                          ByVal boDELOTAAS As Boolean, _
                                          ByVal stDELOESTA As String) As Boolean

        Try

            ' variables del sistema
            Dim stDELOMAQU As String = fun_Nombre_de_maquina()
            Dim stDELOUSIN As String = vp_usuario
            Dim stDELOUSMO As String = ""

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "DEECLOTE "

            stConsultaSQL += "( "
            stConsultaSQL += "DELODEPA, "
            stConsultaSQL += "DELOMUNI, "
            stConsultaSQL += "DELOCLSE, "
            stConsultaSQL += "DELOVIGE, "
            stConsultaSQL += "DELODEEC, "
            stConsultaSQL += "DELOLOTE, "
            stConsultaSQL += "DELOLE44, "
            stConsultaSQL += "DELOIMPR, "
            stConsultaSQL += "DELOACBO, "
            stConsultaSQL += "DELOALPU, "
            stConsultaSQL += "DELOTAAS, "
            stConsultaSQL += "DELOESTA, "
            stConsultaSQL += "DELOUSIN, "
            stConsultaSQL += "DELOUSMO, "
            stConsultaSQL += "DELOMAQU "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stDELODEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDELOMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inDELOCLSE) & "', "
            stConsultaSQL += "'" & CInt(inDELOVIGE) & "', "
            stConsultaSQL += "'" & CInt(inDELODEEC) & "', "
            stConsultaSQL += "'" & CBool(boDELOLOTE) & "', "
            stConsultaSQL += "'" & CBool(boDELOLE44) & "', "
            stConsultaSQL += "'" & CBool(boDELOIMPR) & "', "
            stConsultaSQL += "'" & CBool(boDELOACBO) & "', "
            stConsultaSQL += "'" & CBool(boDELOALPU) & "', "
            stConsultaSQL += "'" & CBool(boDELOTAAS) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDELOESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDELOUSIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDELOUSMO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDELOMAQU)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_DEECLOTE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_DEECLOTE(ByVal inDELOIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "DEECLOTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DELOIDRE = '" & CInt(inDELOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_DEECLOTE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_DEECLOTE(ByVal inDELOIDRE As Integer, _
                                          ByVal stDELODEPA As String, _
                                          ByVal stDELOMUNI As String, _
                                          ByVal inDELOCLSE As Integer, _
                                          ByVal inDELOVIGE As Integer, _
                                          ByVal inDELODEEC As Integer, _
                                          ByVal boDELOLOTE As Boolean, _
                                          ByVal boDELOLE44 As Boolean, _
                                          ByVal boDELOIMPR As Boolean, _
                                          ByVal boDELOACBO As Boolean, _
                                          ByVal boDELOALPU As Boolean, _
                                          ByVal boDELOTAAS As Boolean, _
                                          ByVal stDELOESTA As String) As Boolean

        Try
            ' variables del sistema
            Dim stDELOMAQU As String = fun_Nombre_de_maquina()
            Dim stDELOUSIN As String = vp_usuario
            Dim stDELOUSMO As String = vp_usuario

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "DEECLOTE "

            stConsultaSQL += "SET "
            stConsultaSQL += "DELODEPA = '" & CStr(Trim(stDELODEPA)) & "', "
            stConsultaSQL += "DELOMUNI = '" & CStr(Trim(stDELOMUNI)) & "', "
            stConsultaSQL += "DELOCLSE = '" & CInt(inDELOCLSE) & "', "
            stConsultaSQL += "DELOVIGE = '" & CInt(inDELOVIGE) & "', "
            stConsultaSQL += "DELODEEC = '" & CInt(inDELODEEC) & "', "
            stConsultaSQL += "DELOLOTE = '" & CBool(boDELOLOTE) & "', "
            stConsultaSQL += "DELOLE44 = '" & CBool(boDELOLE44) & "', "
            stConsultaSQL += "DELOIMPR = '" & CBool(boDELOIMPR) & "', "
            stConsultaSQL += "DELOACBO = '" & CBool(boDELOACBO) & "', "
            stConsultaSQL += "DELOALPU = '" & CBool(boDELOALPU) & "', "
            stConsultaSQL += "DELOTAAS = '" & CBool(boDELOTAAS) & "', "
            stConsultaSQL += "DELOESTA = '" & CStr(Trim(stDELOESTA)) & "', "
            stConsultaSQL += "DELOUSIN = '" & CStr(Trim(stDELOUSIN)) & "', "
            stConsultaSQL += "DELOUSMO = '" & CStr(Trim(stDELOUSMO)) & "', "
            stConsultaSQL += "DELOMAQU = '" & CStr(Trim(stDELOMAQU)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DELOIDRE = '" & CInt(inDELOIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_DEECLOTE")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_DEECLOTE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "DELOIDRE, "
            stConsultaSQL += "DELODEPA, "
            stConsultaSQL += "DELOMUNI, "
            stConsultaSQL += "DELOCLSE, "
            stConsultaSQL += "DELOVIGE, "
            stConsultaSQL += "DELODEEC, "
            stConsultaSQL += "DELOLOTE, "
            stConsultaSQL += "DELOLE44, "
            stConsultaSQL += "DELOIMPR, "
            stConsultaSQL += "DELOACBO, "
            stConsultaSQL += "DELOALPU, "
            stConsultaSQL += "DELOTAAS, "
            stConsultaSQL += "DELOESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "DEECLOTE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DELODEPA, DELOMUNI, DELOCLSE, DELODEEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_DEECLOTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_DEECLOTE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "DEECLOTE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DELODEPA, DELOMUNI, DELOCLSE, DELODEEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_DEECLOTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_DEECLOTE_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "DEECLOTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DELOESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DELODEPA, DELOMUNI, DELOCLSE, DELODEEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_DEECLOTE_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_DEECLOTE(ByVal inDELOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "DEECLOTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DELOIDRE = '" & CInt(inDELOIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_DEECLOTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_DEEC_X_DEECLOTE(ByVal stDELODEPA As String, _
                                                                          ByVal stDELOMUNI As String, _
                                                                          ByVal inDELOCLSE As Integer, _
                                                                          ByVal inDELOVIGE As Integer, _
                                                                          ByVal inDELODEEC As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "DEECLOTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DELODEPA = '" & CStr(Trim(stDELODEPA)) & "' and "
            stConsultaSQL += "DELOMUNI = '" & CStr(Trim(stDELOMUNI)) & "' and "
            stConsultaSQL += "DELOCLSE = '" & CInt(inDELOCLSE) & "' and "
            stConsultaSQL += "DELOVIGE = '" & CInt(inDELOVIGE) & "' and "
            stConsultaSQL += "DELODEEC = '" & CInt(inDELODEEC) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_DEECLOTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_DEECLOTE(ByVal inDELOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "DELOIDRE, "
            stConsultaSQL += "DELODEPA, "
            stConsultaSQL += "DELOMUNI, "
            stConsultaSQL += "DELOCLSE, "
            stConsultaSQL += "DELOVIGE, "
            stConsultaSQL += "DELODEEC, "
            stConsultaSQL += "DELOLOTE, "
            stConsultaSQL += "DELOLE44, "
            stConsultaSQL += "DELOIMPR, "
            stConsultaSQL += "DELOACBO, "
            stConsultaSQL += "DELOALPU, "
            stConsultaSQL += "DELOTAAS, "
            stConsultaSQL += "DELOESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "DEECLOTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DELOIDRE = '" & CInt(inDELOIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DELODEPA, DELOMUNI, DELOCLSE, DELODEEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_DEECLOTE")
            Return Nothing

        End Try

    End Function

End Class
