Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_FORMMUNI

    '===============================
    '*** CLASE FORMULA MUNICIPIO ***
    '===============================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_FORMMUNI(ByVal obFOMUDEPA As Object, _
                                                         ByVal obFOMUMUNI As Object, _
                                                         ByVal obFOMUCLSE As Object, _
                                                         ByVal obFOMUVIGE As Object, _
                                                         ByVal obFOMUTIIM As Object, _
                                                         ByVal obFOMUCONC As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obFOMUDEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obFOMUMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obFOMUCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obFOMUVIGE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obFOMUTIIM.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obFOMUCONC.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obFOMUDEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obFOMUMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obFOMUCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obFOMUVIGE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obFOMUTIIM.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obFOMUCONC.SelectedValue) = True Then

                    Dim objdatos1 As New cla_FORMMUNI
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_TIIM_CONC_X_FORMMUNI(obFOMUDEPA.SelectedValue, _
                                                                                          obFOMUMUNI.SelectedValue, _
                                                                                          obFOMUCLSE.SelectedValue, _
                                                                                          obFOMUVIGE.SelectedValue, _
                                                                                          obFOMUTIIM.SelectedValue, _
                                                                                          obFOMUCONC.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obFOMUDEPA.Text) & " - " & _
                                                     Trim(obFOMUMUNI.Text) & " - " & _
                                                     Trim(obFOMUCLSE.Text) & " - " & _
                                                     Trim(obFOMUVIGE.Text) & " - " & _
                                                     Trim(obFOMUTIIM.Text) & " - " & _
                                                     Trim(obFOMUCONC.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obFOMUDEPA.Focus()
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
    Public Function fun_Insertar_FORMMUNI(ByVal stFOMUDEPA As String, _
                                          ByVal stFOMUMUNI As String, _
                                          ByVal inFOMUCLSE As Integer, _
                                          ByVal inFOMUVIGE As Integer, _
                                          ByVal inFOMUTIIM As Integer, _
                                          ByVal inFOMUCONC As Integer, _
                                          ByVal stFOMUFORM As String, _
                                          ByVal stFOMUDESC As String, _
                                          ByVal boFOMUIMPR As Boolean, _
                                          ByVal boFOMUACBO As Boolean, _
                                          ByVal boFOMUALPU As Boolean, _
                                          ByVal boFOMUTAAS As Boolean, _
                                          ByVal boFOMUCO01 As Boolean, _
                                          ByVal boFOMUCO02 As Boolean, _
                                          ByVal boFOMUCO03 As Boolean, _
                                          ByVal boFOMUCO04 As Boolean, _
                                          ByVal boFOMUCO05 As Boolean, _
                                          ByVal stFOMUESTA As String) As Boolean

        Try

            ' variables del sistema
            Dim stFOMUMAQU As String = fun_Nombre_de_maquina()
            Dim stFOMUUSIN As String = vp_usuario
            Dim stFOMUUSMO As String = ""

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "FORMMUNI "

            stConsultaSQL += "( "
            stConsultaSQL += "FOMUDEPA, "
            stConsultaSQL += "FOMUMUNI, "
            stConsultaSQL += "FOMUCLSE, "
            stConsultaSQL += "FOMUVIGE, "
            stConsultaSQL += "FOMUTIIM, "
            stConsultaSQL += "FOMUCONC, "
            stConsultaSQL += "FOMUFORM, "
            stConsultaSQL += "FOMUDESC, "
            stConsultaSQL += "FOMUIMPR, "
            stConsultaSQL += "FOMUACBO, "
            stConsultaSQL += "FOMUALPU, "
            stConsultaSQL += "FOMUTAAS, "
            stConsultaSQL += "FOMUCO01, "
            stConsultaSQL += "FOMUCO02, "
            stConsultaSQL += "FOMUCO03, "
            stConsultaSQL += "FOMUCO04, "
            stConsultaSQL += "FOMUCO05, "
            stConsultaSQL += "FOMUESTA, "
            stConsultaSQL += "FOMUUSIN, "
            stConsultaSQL += "FOMUUSMO, "
            stConsultaSQL += "FOMUMAQU "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stFOMUDEPA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFOMUMUNI)) & "', "
            stConsultaSQL += "'" & CInt(inFOMUCLSE) & "', "
            stConsultaSQL += "'" & CInt(inFOMUVIGE) & "', "
            stConsultaSQL += "'" & CInt(inFOMUTIIM) & "', "
            stConsultaSQL += "'" & CInt(inFOMUCONC) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFOMUFORM)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFOMUDESC)) & "', "
            stConsultaSQL += "'" & CBool(boFOMUIMPR) & "', "
            stConsultaSQL += "'" & CBool(boFOMUACBO) & "', "
            stConsultaSQL += "'" & CBool(boFOMUALPU) & "', "
            stConsultaSQL += "'" & CBool(boFOMUTAAS) & "', "
            stConsultaSQL += "'" & CBool(boFOMUCO01) & "', "
            stConsultaSQL += "'" & CBool(boFOMUCO02) & "', "
            stConsultaSQL += "'" & CBool(boFOMUCO03) & "', "
            stConsultaSQL += "'" & CBool(boFOMUCO04) & "', "
            stConsultaSQL += "'" & CBool(boFOMUCO05) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFOMUESTA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFOMUUSIN)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFOMUUSMO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stFOMUMAQU)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_FORMMUNI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_FORMMUNI(ByVal inFOMUIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "FORMMUNI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FOMUIDRE = '" & CInt(inFOMUIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_FORMMUNI")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_FORMMUNI(ByVal inFOMUIDRE As Integer, _
                                          ByVal stFOMUDEPA As String, _
                                          ByVal stFOMUMUNI As String, _
                                          ByVal inFOMUCLSE As Integer, _
                                          ByVal inFOMUVIGE As Integer, _
                                          ByVal inFOMUTIIM As Integer, _
                                          ByVal inFOMUCONC As Integer, _
                                          ByVal stFOMUFORM As String, _
                                          ByVal stFOMUDESC As String, _
                                          ByVal boFOMUIMPR As Boolean, _
                                          ByVal boFOMUACBO As Boolean, _
                                          ByVal boFOMUALPU As Boolean, _
                                          ByVal boFOMUTAAS As Boolean, _
                                          ByVal boFOMUCO01 As Boolean, _
                                          ByVal boFOMUCO02 As Boolean, _
                                          ByVal boFOMUCO03 As Boolean, _
                                          ByVal boFOMUCO04 As Boolean, _
                                          ByVal boFOMUCO05 As Boolean, _
                                          ByVal stFOMUESTA As String) As Boolean

        Try
            ' variables del sistema
            Dim stFOMUMAQU As String = fun_Nombre_de_maquina()
            Dim stFOMUUSIN As String = vp_usuario
            Dim stFOMUUSMO As String = vp_usuario

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "FORMMUNI "

            stConsultaSQL += "SET "
            stConsultaSQL += "FOMUDEPA = '" & CStr(Trim(stFOMUDEPA)) & "', "
            stConsultaSQL += "FOMUMUNI = '" & CStr(Trim(stFOMUMUNI)) & "', "
            stConsultaSQL += "FOMUCLSE = '" & CInt(inFOMUCLSE) & "', "
            stConsultaSQL += "FOMUVIGE = '" & CInt(inFOMUVIGE) & "', "
            stConsultaSQL += "FOMUTIIM = '" & CInt(inFOMUTIIM) & "', "
            stConsultaSQL += "FOMUCONC = '" & CInt(inFOMUCONC) & "', "
            stConsultaSQL += "FOMUFORM = '" & CStr(Trim(stFOMUFORM)) & "', "
            stConsultaSQL += "FOMUDESC = '" & CStr(Trim(stFOMUDESC)) & "', "
            stConsultaSQL += "FOMUIMPR = '" & CBool(boFOMUIMPR) & "', "
            stConsultaSQL += "FOMUACBO = '" & CBool(boFOMUACBO) & "', "
            stConsultaSQL += "FOMUALPU = '" & CBool(boFOMUALPU) & "', "
            stConsultaSQL += "FOMUTAAS = '" & CBool(boFOMUTAAS) & "', "
            stConsultaSQL += "FOMUCO01 = '" & CBool(boFOMUCO01) & "', "
            stConsultaSQL += "FOMUCO02 = '" & CBool(boFOMUCO02) & "', "
            stConsultaSQL += "FOMUCO03 = '" & CBool(boFOMUCO03) & "', "
            stConsultaSQL += "FOMUCO04 = '" & CBool(boFOMUCO04) & "', "
            stConsultaSQL += "FOMUCO05 = '" & CBool(boFOMUCO05) & "', "
            stConsultaSQL += "FOMUESTA = '" & CStr(Trim(stFOMUESTA)) & "', "
            stConsultaSQL += "FOMUUSIN = '" & CStr(Trim(stFOMUUSIN)) & "', "
            stConsultaSQL += "FOMUUSMO = '" & CStr(Trim(stFOMUUSMO)) & "', "
            stConsultaSQL += "FOMUMAQU = '" & CStr(Trim(stFOMUMAQU)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FOMUIDRE = '" & CInt(inFOMUIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_FORMMUNI")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_FORMMUNI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FOMUIDRE, "
            stConsultaSQL += "FOMUDEPA, "
            stConsultaSQL += "FOMUMUNI, "
            stConsultaSQL += "FOMUCLSE, "
            stConsultaSQL += "FOMUVIGE, "
            stConsultaSQL += "FOMUTIIM, "
            stConsultaSQL += "FOMUCONC, "
            stConsultaSQL += "FOMUFORM, "
            stConsultaSQL += "FOMUDESC, "
            stConsultaSQL += "FOMUIMPR, "
            stConsultaSQL += "FOMUACBO, "
            stConsultaSQL += "FOMUALPU, "
            stConsultaSQL += "FOMUTAAS, "
            stConsultaSQL += "FOMUCO01, "
            stConsultaSQL += "FOMUCO02, "
            stConsultaSQL += "FOMUCO03, "
            stConsultaSQL += "FOMUCO04, "
            stConsultaSQL += "FOMUCO05, "
            stConsultaSQL += "FOMUESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FORMMUNI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FOMUDEPA, FOMUMUNI, FOMUCLSE, FOMUTIIM, FOMUCONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_FORMMUNI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_FORMMUNI() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FORMMUNI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FOMUDEPA, FOMUMUNI, FOMUCLSE, FOMUTIIM, FOMUCONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_FORMMUNI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_FORMMUNI_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FORMMUNI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FOMUESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FOMUDEPA, FOMUMUNI, FOMUCLSE, FOMUTIIM, FOMUCONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_FORMMUNI_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_FORMMUNI(ByVal inFOMUIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FORMMUNI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FOMUIDRE = '" & CInt(inFOMUIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_FORMMUNI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLSE_VIGE_TIIM_CONC_X_FORMMUNI(ByVal stFOMUDEPA As String, _
                                                                          ByVal stFOMUMUNI As String, _
                                                                          ByVal inFOMUCLSE As Integer, _
                                                                          ByVal inFOMUVIGE As Integer, _
                                                                          ByVal inFOMUTIIM As Integer, _
                                                                          ByVal inFOMUCONC As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FORMMUNI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FOMUDEPA = '" & CStr(Trim(stFOMUDEPA)) & "' and "
            stConsultaSQL += "FOMUMUNI = '" & CStr(Trim(stFOMUMUNI)) & "' and "
            stConsultaSQL += "FOMUCLSE = '" & CInt(inFOMUCLSE) & "' and "
            stConsultaSQL += "FOMUVIGE = '" & CInt(inFOMUVIGE) & "' and "
            stConsultaSQL += "FOMUTIIM = '" & CInt(inFOMUTIIM) & "' and "
            stConsultaSQL += "FOMUCONC = '" & CInt(inFOMUCONC) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_FORMMUNI")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_FORMMUNI(ByVal inFOMUIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "FOMUIDRE, "
            stConsultaSQL += "FOMUDEPA, "
            stConsultaSQL += "FOMUMUNI, "
            stConsultaSQL += "FOMUCLSE, "
            stConsultaSQL += "FOMUVIGE, "
            stConsultaSQL += "FOMUTIIM, "
            stConsultaSQL += "FOMUCONC, "
            stConsultaSQL += "FOMUFORM, "
            stConsultaSQL += "FOMUDESC, "
            stConsultaSQL += "FOMUIMPR, "
            stConsultaSQL += "FOMUACBO, "
            stConsultaSQL += "FOMUALPU, "
            stConsultaSQL += "FOMUTAAS, "
            stConsultaSQL += "FOMUCO01, "
            stConsultaSQL += "FOMUCO02, "
            stConsultaSQL += "FOMUCO03, "
            stConsultaSQL += "FOMUCO04, "
            stConsultaSQL += "FOMUCO05, "
            stConsultaSQL += "FOMUESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FORMMUNI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FOMUIDRE = '" & CInt(inFOMUIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "FOMUDEPA, FOMUMUNI, FOMUCLSE, FOMUTIIM, FOMUCONC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_FORMMUNI")
            Return Nothing

        End Try

    End Function

End Class
