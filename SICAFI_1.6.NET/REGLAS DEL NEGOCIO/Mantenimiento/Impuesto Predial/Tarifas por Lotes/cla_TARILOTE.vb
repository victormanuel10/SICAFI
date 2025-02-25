Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_TARILOTE

    '==============================
    '*** CLASE TARIFA POR LOTES ***
    '==============================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_TARILOTE(ByVal obTALODEPA As Object, _
                                                         ByVal obTALOMUNI As Object, _
                                                         ByVal obTALOCLSE As Object, _
                                                         ByVal obTALOVIGE As Object, _
                                                         ByVal obTALOZOEC As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obTALODEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTALOMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTALOCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTALOVIGE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obTALOZOEC.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obTALODEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTALOMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTALOCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTALOVIGE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obTALOZOEC.SelectedValue) = True Then

                    Dim objdatos1 As New cla_TARILOTE
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_ZOEC_X_TARILOTE(obTALODEPA.SelectedValue, _
                                                                                          obTALOMUNI.SelectedValue, _
                                                                                          obTALOCLSE.SelectedValue, _
                                                                                          obTALOVIGE.SelectedValue, _
                                                                                          obTALOZOEC.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obTALODEPA.Text) & " - " & _
                                                     Trim(obTALOMUNI.Text) & " - " & _
                                                     Trim(obTALOCLSE.Text) & " - " & _
                                                     Trim(obTALOVIGE.Text) & " - " & _
                                                     Trim(obTALOZOEC.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obTALODEPA.Focus()
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
    Public Function fun_Insertar_TARILOTE(ByVal stTALODEPA As String, _
                                          ByVal stTALOMUNI As String, _
                                          ByVal inTALOCLSE As Integer, _
                                          ByVal inTALOVIGE As Integer, _
                                          ByVal inTALOZOEC As Integer, _
                                          ByVal inTALOTARI As Integer, _
                                          ByVal loTALOAVIN As Long, _
                                          ByVal loTALOAVFI As Long, _
                                          ByVal stTALOESTA As String) As Boolean

        Try

            ' variables del sistema
            Dim stTALOMAQU As String = fun_Nombre_de_maquina()
            Dim stTALOUSIN As String = vp_usuario
            Dim stTALOUSMO As String = ""

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "TARILOTE "

            stConsultaSQL += "( "
            stConsultaSQL += "TALODEPA, "
            stConsultaSQL += "TALOMUNI, "
            stConsultaSQL += "TALOCLSE, "
            stConsultaSQL += "TALOVIGE, "
            stConsultaSQL += "TALOZOEC, "
            stConsultaSQL += "TALOTARI, "
            stConsultaSQL += "TALOAVIN, "
            stConsultaSQL += "TALOAVFI, "
            stConsultaSQL += "TALOESTA, "
            stConsultaSQL += "TALOUSIN, "
            stConsultaSQL += "TALOUSMO, "
            stConsultaSQL += "TALOMAQU "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stTALODEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTALOMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inTALOCLSE) & "', "
            stConsultaSQL += "'" & CInt(inTALOVIGE) & "', "
            stConsultaSQL += "'" & CInt(inTALOZOEC) & "', "
            stConsultaSQL += "'" & CInt(inTALOTARI) & "', "
            stConsultaSQL += "'" & CLng(loTALOAVIN) & "', "
            stConsultaSQL += "'" & CLng(loTALOAVFI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTALOESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTALOUSIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTALOUSMO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stTALOMAQU)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_TARILOTE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_TARILOTE(ByVal inTALOIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "TARILOTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TALOIDRE = '" & CInt(inTALOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_TARILOTE")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_TARILOTE(ByVal inTALOIDRE As Integer, _
                                          ByVal stTALODEPA As String, _
                                          ByVal stTALOMUNI As String, _
                                          ByVal inTALOCLSE As Integer, _
                                          ByVal inTALOVIGE As Integer, _
                                          ByVal inTALOZOEC As Integer, _
                                          ByVal inTALOTARI As Integer, _
                                          ByVal loTALOAVIN As Long, _
                                          ByVal loTALOAVFI As Long, _
                                          ByVal stTALOESTA As String) As Boolean

        Try
            ' variables del sistema
            Dim stTALOMAQU As String = fun_Nombre_de_maquina()
            Dim stTALOUSIN As String = vp_usuario
            Dim stTALOUSMO As String = vp_usuario

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "TARILOTE "

            stConsultaSQL += "SET "
            stConsultaSQL += "TALODEPA = '" & CStr(Trim(stTALODEPA)) & "', "
            stConsultaSQL += "TALOMUNI = '" & CStr(Trim(stTALOMUNI)) & "', "
            stConsultaSQL += "TALOCLSE = '" & CInt(inTALOCLSE) & "', "
            stConsultaSQL += "TALOVIGE = '" & CInt(inTALOVIGE) & "', "
            stConsultaSQL += "TALOZOEC = '" & CInt(inTALOZOEC) & "', "
            stConsultaSQL += "TALOTARI = '" & CInt(inTALOTARI) & "', "
            stConsultaSQL += "TALOAVIN = '" & CLng(loTALOAVIN) & "', "
            stConsultaSQL += "TALOAVFI = '" & CLng(loTALOAVFI) & "', "
            stConsultaSQL += "TALOESTA = '" & CStr(Trim(stTALOESTA)) & "', "
            stConsultaSQL += "TALOUSIN = '" & CStr(Trim(stTALOUSIN)) & "', "
            stConsultaSQL += "TALOUSMO = '" & CStr(Trim(stTALOUSMO)) & "', "
            stConsultaSQL += "TALOMAQU = '" & CStr(Trim(stTALOMAQU)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TALOIDRE = '" & CInt(inTALOIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_TARILOTE")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_TARILOTE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TALOIDRE, "
            stConsultaSQL += "TALODEPA, "
            stConsultaSQL += "TALOMUNI, "
            stConsultaSQL += "TALOCLSE, "
            stConsultaSQL += "TALOVIGE, "
            stConsultaSQL += "TALOZOEC, "
            stConsultaSQL += "TALOTARI, "
            stConsultaSQL += "TALOAVIN, "
            stConsultaSQL += "TALOAVFI, "
            stConsultaSQL += "TALOESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARILOTE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TALODEPA, TALOMUNI, TALOCLSE, TALOZOEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_TARILOTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_TARILOTE() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARILOTE "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TALODEPA, TALOMUNI, TALOCLSE, TALOZOEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_TARILOTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_TARILOTE_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARILOTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TALOESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TALODEPA, TALOMUNI, TALOCLSE, TALOZOEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_TARILOTE_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_TARILOTE(ByVal inTALOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARILOTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TALOIDRE = '" & CInt(inTALOIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_TARILOTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_ZOEC_X_TARILOTE(ByVal stTALODEPA As String, _
                                                                          ByVal stTALOMUNI As String, _
                                                                          ByVal inTALOCLSE As Integer, _
                                                                          ByVal inTALOVIGE As Integer, _
                                                                          ByVal inTALOZOEC As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARILOTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TALODEPA = '" & CStr(Trim(stTALODEPA)) & "' and "
            stConsultaSQL += "TALOMUNI = '" & CStr(Trim(stTALOMUNI)) & "' and "
            stConsultaSQL += "TALOCLSE = '" & CInt(inTALOCLSE) & "' and "
            stConsultaSQL += "TALOVIGE = '" & CInt(inTALOVIGE) & "' and "
            stConsultaSQL += "TALOZOEC = '" & CInt(inTALOZOEC) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_TARILOTE")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TARILOTE(ByVal inTALOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "TALOIDRE, "
            stConsultaSQL += "TALODEPA, "
            stConsultaSQL += "TALOMUNI, "
            stConsultaSQL += "TALOCLSE, "
            stConsultaSQL += "TALOVIGE, "
            stConsultaSQL += "TALOZOEC, "
            stConsultaSQL += "TALOTARI, "
            stConsultaSQL += "TALOAVIN, "
            stConsultaSQL += "TALOAVFI, "
            stConsultaSQL += "TALOESTA, "

            stConsultaSQL += "FROM "
            stConsultaSQL += "TARILOTE "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TALOIDRE = '" & CInt(inTALOIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "TALODEPA, TALOMUNI, TALOCLSE, TALOZOEC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_TARILOTE")
            Return Nothing

        End Try

    End Function


End Class
