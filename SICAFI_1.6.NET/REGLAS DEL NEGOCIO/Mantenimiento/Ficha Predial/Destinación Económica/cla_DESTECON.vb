Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_DESTECON

    '===================================
    '*** CLASE DESTINACIÓN ECONÓMICA ***
    '===================================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_DESTECON() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "DEECIDRE, "
            stConsultaSQL += "DEECCODI, "
            stConsultaSQL += "DEECDESC, "
            stConsultaSQL += "DEECLOTE, "
            stConsultaSQL += "DEECESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DESTECON "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DEECCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_ESTRATO")
            Return Nothing
        End Try

    End Function

    '''   <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_DESTECON() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_MANT_DESTECON")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_DESTECON_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_DESTECON_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_DESTECON(ByVal inDEECCODI As Integer, _
                                               ByVal stDEECDESC As String, _
                                               ByVal stDEECESTA As String, _
                                               ByVal boDEECLOTE As Boolean) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_DESTECON "

            stConsultaSQL += "( "
            stConsultaSQL += "DEECCODI, "
            stConsultaSQL += "DEECDESC, "
            stConsultaSQL += "DEECESTA, "
            stConsultaSQL += "DEECLOTE  "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inDEECCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDEECDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDEECESTA)) & "', "
            stConsultaSQL += "'" & CBool(boDEECLOTE) & "'  "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_ESTRATO")
        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_DESTECON(ByVal inDEECCODI As Integer, _
                                               ByVal stDEECDESC As String, _
                                               ByVal stDEECESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_DESTECON "

            stConsultaSQL += "( "
            stConsultaSQL += "DEECCODI, "
            stConsultaSQL += "DEECDESC, "
            stConsultaSQL += "DEECESTA  "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inDEECCODI) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDEECDESC)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stDEECESTA)) & "'  "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_ESTRATO")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_DESTECON(ByVal inDEECIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inDEECIDRE As New SqlParameter("@DEECIDRE", inDEECIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inDEECIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_MANT_DESTECON") Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica o actualiza el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_DESTECON(ByVal inDEECIDRE As Integer, _
                                                 ByVal inDEECCODI As Integer, _
                                                 ByVal stDEECDESC As String, _
                                                 ByVal stDEECESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inDEECIDRE As New SqlParameter("@DEECIDRE", inDEECIDRE)
            Dim o_inDEECCODI As New SqlParameter("@DEECCODI", inDEECCODI)
            Dim o_stDEECDESC As New SqlParameter("@DEECDESC", stDEECDESC)
            Dim o_stDEECESTA As New SqlParameter("@DEECESTA", stDEECESTA)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_inDEECIDRE
            VecParametros(1) = o_inDEECCODI
            VecParametros(2) = o_stDEECDESC
            VecParametros(3) = o_stDEECESTA

            objenq.ActualizarDb(VecParametros, "actualizar_MANT_DESTECON")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica o actualiza el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_DESTECON(ByVal inDEECIDRE As Integer, _
                                                 ByVal inDEECCODI As Integer, _
                                                 ByVal stDEECDESC As String, _
                                                 ByVal stDEECESTA As String, _
                                                 ByVal boDEECLOTE As Boolean) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_DESTECON "

            stConsultaSQL += "SET "
            stConsultaSQL += "DEECCODI = '" & CInt(inDEECCODI) & "', "
            stConsultaSQL += "DEECDESC = '" & CStr(Trim(stDEECDESC)) & "', "
            stConsultaSQL += "DEECESTA = '" & CStr(Trim(stDEECESTA)) & "', "
            stConsultaSQL += "DEECLOTE = '" & CBool(boDEECLOTE) & "'  "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DEECIDRE = '" & CInt(inDEECIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MANT_ESTRATO")
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_DESTECON(ByVal inDEECIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inDEECIDRE As New SqlParameter("@DEECIDRE", inDEECIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inDEECIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_MANT_DESTECON")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA DESTINACIÓN ECONÓMICA para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_DESTECON(ByVal inDEECCODI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inDEECCODI As New SqlParameter("@DEECCODI", inDEECCODI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inDEECCODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_MANT_DESTECON")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_DESTECON(ByVal inDEECIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "DEECIDRE, "
            stConsultaSQL += "DEECCODI, "
            stConsultaSQL += "DEECDESC, "
            stConsultaSQL += "DEECLOTE, "
            stConsultaSQL += "DEECESTA  "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DESTECON "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DEECIDRE = '" & CInt(inDEECIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DEECCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_ESTRATO")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Carga el codigo y la descripcion de los registros activos que carga el combobox
    ''' </summary>
    Public Function fun_Consultar_Campos_MANT_DESTECON_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "DEECCODI, "
            stConsultaSQL += "DEECDESC, "
            stConsultaSQL += "DEECESTA, "
            stConsultaSQL += "DEECLOTE  "


            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_DESTECON "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DEECESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "DEECDESC "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_campos_MANT_DEPARTAMENTO_X_ESTADO")
            Return Nothing
        End Try

    End Function

  
End Class
