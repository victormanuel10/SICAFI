Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_CONTRASENA

    '========================
    '*** CLASE CONTRASENA ***
    '========================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_CONTRASENA() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CONTRASENA")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_CONTRASENA() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_CONTRASENA")

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
    Public Function fun_Consultar_USUARIO_CONTRASENA_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_USUARIO_CONTRASENA_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_CONTRASENA(ByVal stCONTNUDO As String, _
                                            ByVal stCONTUSUA As String, _
                                            ByVal stCONTCONT As String, _
                                            ByVal stCONTESTA As String, _
                                            ByVal boCONTAGRE As Boolean, _
                                            ByVal boCONTMODI As Boolean, _
                                            ByVal boCONTELIM As Boolean) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stCONTNUDO As New SqlParameter("@CONTNUDO", stCONTNUDO)
            Dim o_stCONTUSUA As New SqlParameter("@CONTUSUA", stCONTUSUA)
            Dim o_stCONTCONT As New SqlParameter("@CONTCONT", stCONTCONT)
            Dim o_stCONTESTA As New SqlParameter("@CONTESTA", stCONTESTA)
            Dim o_boCONTAGRE As New SqlParameter("@CONTAGRE", boCONTAGRE)
            Dim o_boCONTMODI As New SqlParameter("@CONTMODI", boCONTMODI)
            Dim o_boCONTELIM As New SqlParameter("@CONTELIM", boCONTELIM)

            Dim VecParametros(6) As SqlParameter

            VecParametros(0) = o_stCONTNUDO
            VecParametros(1) = o_stCONTUSUA
            VecParametros(2) = o_stCONTCONT
            VecParametros(3) = o_stCONTESTA
            VecParametros(4) = o_boCONTAGRE
            VecParametros(5) = o_boCONTMODI
            VecParametros(6) = o_boCONTELIM

            objenq.ActualizarDb(VecParametros, "insertar_CONTRASENA")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_CONTRASENA(ByVal stCONTNUDO As String, _
                                            ByVal stCONTUSUA As String, _
                                            ByVal stCONTCONT As String, _
                                            ByVal stCONTESTA As String, _
                                            ByVal boCONTAGRE As Boolean, _
                                            ByVal boCONTMODI As Boolean, _
                                            ByVal boCONTELIM As Boolean, _
                                            ByVal boCONTCOFP As Boolean, _
                                            ByVal boCONTCOSI As Boolean) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "CONTRASENA "

            stConsultaSQL += "( "
            stConsultaSQL += "CONTNUDO, "
            stConsultaSQL += "CONTUSUA, "
            stConsultaSQL += "CONTCONT, "
            stConsultaSQL += "CONTESTA, "
            stConsultaSQL += "CONTAGRE, "
            stConsultaSQL += "CONTMODI, "
            stConsultaSQL += "CONTELIM, "
            stConsultaSQL += "CONTCOFP, "
            stConsultaSQL += "CONTCOSI "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stCONTNUDO)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCONTUSUA)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCONTCONT)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stCONTESTA)) & "', "
            stConsultaSQL += "'" & CBool(boCONTAGRE) & "', "
            stConsultaSQL += "'" & CBool(boCONTMODI) & "', "
            stConsultaSQL += "'" & CBool(boCONTELIM) & "', "
            stConsultaSQL += "'" & CBool(boCONTCOFP) & "', "
            stConsultaSQL += "'" & CBool(boCONTCOSI) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_CONTRASENA")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_CONTRASENA(ByVal inCONTIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inCONTIDRE As New SqlParameter("@CONTIDRE", inCONTIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCONTIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_CONTRASENA") Then
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
    Public Function fun_Actualizar_CONTRASENA(ByVal inCONTIDRE As Integer, _
                                            ByVal stCONTNUDO As String, _
                                            ByVal stCONTUSUA As String, _
                                            ByVal stCONTCONU As String, _
                                            ByVal stCONTESTA As String, _
                                            ByVal boCONTAGRE As Boolean, _
                                            ByVal boCONTMODI As Boolean, _
                                            ByVal boCONTELIM As Boolean,
                                            ByVal boCONTCOFP As Boolean,
                                            ByVal boCONTCOSI As Boolean) As Boolean


        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inCONTIDRE As New SqlParameter("@CONTIDRE", inCONTIDRE)
            Dim o_stCONTNUDO As New SqlParameter("@CONTNUDO", stCONTNUDO)
            Dim o_stCONTUSUA As New SqlParameter("@CONTUSUA", stCONTUSUA)
            Dim o_stCONTCONT As New SqlParameter("@CONTCONT", stCONTCONU)
            Dim o_stCONTESTA As New SqlParameter("@CONTESTA", stCONTESTA)
            Dim o_boCONTAGRE As New SqlParameter("@CONTAGRE", boCONTAGRE)
            Dim o_boCONTMODI As New SqlParameter("@CONTMODI", boCONTMODI)
            Dim o_boCONTELIM As New SqlParameter("@CONTELIM", boCONTELIM)
            Dim o_boCONTCOFP As New SqlParameter("@CONTCOFP", boCONTCOFP)
            Dim o_boCONTCOSI As New SqlParameter("@CONTCOSI", boCONTCOSI)

            Dim VecParametros(9) As SqlParameter

            VecParametros(0) = o_inCONTIDRE
            VecParametros(1) = o_stCONTNUDO
            VecParametros(2) = o_stCONTUSUA
            VecParametros(3) = o_stCONTCONT
            VecParametros(4) = o_stCONTESTA
            VecParametros(5) = o_boCONTAGRE
            VecParametros(6) = o_boCONTMODI
            VecParametros(7) = o_boCONTELIM
            VecParametros(8) = o_boCONTCOFP
            VecParametros(9) = o_boCONTCOSI

            objenq.ActualizarDb(VecParametros, "actualizar_CONTRASENA")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_CONTRASENA(ByVal inCONTIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inCONTIDRE As New SqlParameter("@CONTIDRE", inCONTIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCONTIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_CONTRASENA")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DE LA CALIDAD DE PROPIETARIO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_CONTRASENA(ByVal inCONTNUDO As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inCONTNUDO As New SqlParameter("@CONTNUDO", inCONTNUDO)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inCONTNUDO

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_CONTRASENA")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el USUARIO DE LA CONSTRASEÑA para encontrar el ID del usuario.  
    ''' </summary>
    Public Function fun_Buscar_USUARIO_CONTRASENA(ByVal stCONTUSUA As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stCONTUSUA As New SqlParameter("@CONTUSUA", stCONTUSUA)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stCONTUSUA

            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb(VecParametros, "buscar_USUARIO_CONTRASENA")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

End Class
