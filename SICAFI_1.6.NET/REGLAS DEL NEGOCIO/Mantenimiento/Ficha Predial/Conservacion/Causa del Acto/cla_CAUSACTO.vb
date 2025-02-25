Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CAUSACTO

    '============================
    '*** CLASE CAUSA DEL ACTO ***
    '============================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_CAUSACTO(ByVal obCAACCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obCAACCODI.Text) = True Then

                Dim objdatos1 As New cla_CAUSACTO
                Dim tbl As New DataTable

                tbl = objdatos1.fun_Buscar_CODIGO_MANT_CAUSACTO(Trim(obCAACCODI.Text))

                If tbl.Rows.Count > 0 Then
                    MessageBox.Show("El dato " & obCAACCODI.Text & " del campo " & obCAACCODI.AccessibleDescription & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                    obCAACCODI.Focus()
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
    Public Function fun_Insertar_MANT_CAUSACTO(ByVal stCAACCODI As String, _
                                               ByVal stCAACDESC As String, _
                                               ByVal boCAACINPR As Boolean, _
                                               ByVal boCAACREPR As Boolean, _
                                               ByVal boCAACINCO As Boolean, _
                                               ByVal boCAACRECO As Boolean, _
                                               ByVal stCAACESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_CAUSACTO "

            stConsultaSQL += "( "
            stConsultaSQL += "CAACCODI, "
            stConsultaSQL += "CAACDESC, "
            stConsultaSQL += "CAACINPR, "
            stConsultaSQL += "CAACREPR, "
            stConsultaSQL += "CAACINCO, "
            stConsultaSQL += "CAACRECO, "
            stConsultaSQL += "CAACESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stCAACCODI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCAACDESC)) & "', "
            stConsultaSQL += "'" & CBool(boCAACINPR) & "', "
            stConsultaSQL += "'" & CBool(boCAACREPR) & "', "
            stConsultaSQL += "'" & CBool(boCAACINCO) & "', "
            stConsultaSQL += "'" & CBool(boCAACRECO) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCAACESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_CAUSACTO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_CAUSACTO(ByVal inCAACIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_CAUSACTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAACIDRE = '" & CInt(inCAACIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_CAUSACTO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_CAUSACTO(ByVal inCAACIDRE As Integer, _
                                                 ByVal stCAACCODI As String, _
                                                 ByVal stCAACDESC As String, _
                                                 ByVal boCAACINPR As Boolean, _
                                                 ByVal boCAACREPR As Boolean, _
                                                 ByVal boCAACINCO As Boolean, _
                                                 ByVal boCAACRECO As Boolean, _
                                                 ByVal stCAACESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_CAUSACTO "

            stConsultaSQL += "SET "
            stConsultaSQL += "CAACCODI = '" & CStr(Trim(stCAACCODI)) & "', "
            stConsultaSQL += "CAACDESC = '" & CStr(Trim(stCAACDESC)) & "', "
            stConsultaSQL += "CAACINPR = '" & CBool(boCAACINPR) & "', "
            stConsultaSQL += "CAACREPR = '" & CBool(boCAACREPR) & "', "
            stConsultaSQL += "CAACINCO = '" & CBool(boCAACINCO) & "', "
            stConsultaSQL += "CAACRECO = '" & CBool(boCAACRECO) & "', "
            stConsultaSQL += "CAACESTA = '" & CStr(Trim(stCAACESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAACIDRE = '" & CInt(inCAACIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_CAUSACTO")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_CAUSACTO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CAACIDRE, "
            stConsultaSQL += "CAACCODI, "
            stConsultaSQL += "CAACDESC, "
            stConsultaSQL += "CAACINPR, "
            stConsultaSQL += "CAACREPR, "
            stConsultaSQL += "CAACINCO, "
            stConsultaSQL += "CAACRECO, "
            stConsultaSQL += "CAACESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CAUSACTO "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CAACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CAUSACTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos MANT_CAUSACTOrio principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_CAUSACTO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CAACIDRE, "
            stConsultaSQL += "CAACCODI, "
            stConsultaSQL += "CAACDESC, "
            stConsultaSQL += "CAACINPR, "
            stConsultaSQL += "CAACREPR, "
            stConsultaSQL += "CAACINCO, "
            stConsultaSQL += "CAACRECO, "
            stConsultaSQL += "CAACESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CAUSACTO, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAACESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CAACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_CAUSACTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos MANT_CAUSACTOrio insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_CAUSACTO_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CAUSACTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAACESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CAACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_CAUSACTO_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_CAUSACTO(ByVal inCAACIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CAUSACTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAACIDRE = '" & CInt(inCAACIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_CAUSACTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_CAUSACTO(ByVal stCAACCODI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CAUSACTO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAACCODI = '" & CStr(Trim(stCAACCODI)) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MANT_CAUSACTO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CAUSACTO(ByVal inCAACIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "CAACIDRE, "
            stConsultaSQL += "CAACCODI, "
            stConsultaSQL += "CAACDESC, "
            stConsultaSQL += "CAACINPR, "
            stConsultaSQL += "CAACREPR, "
            stConsultaSQL += "CAACINCO, "
            stConsultaSQL += "CAACRECO, "
            stConsultaSQL += "CAACESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_CAUSACTO, ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "CAACESTA = ESTACODI AND "
            stConsultaSQL += "CAACIDRE = '" & CInt(inCAACIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "CAACCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_CAUSACTO")
            Return Nothing

        End Try

    End Function

End Class
