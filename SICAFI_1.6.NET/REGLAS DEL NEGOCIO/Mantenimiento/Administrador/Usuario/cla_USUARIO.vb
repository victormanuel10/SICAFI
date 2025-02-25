Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_USUARIO

    '=====================
    '*** CLASE USUARIO ***
    '=====================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_USUARIO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_USUARIO")

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
    Public Function fun_Consultar_CAMPOS_USUARIO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_USUARIO")

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
    Public Function fun_Consultar_USUARIO_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "USUAESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "USUANOMB "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_USUARIO(ByVal stUSUANUDO As String, _
                                         ByVal inUSUATIDO As Integer, _
                                         ByVal inUSUACAPR As Integer, _
                                         ByVal inUSUASEXO As Integer, _
                                         ByVal stUSUANOMB As String, _
                                         ByVal stUSUAPRAP As String, _
                                         ByVal stUSUASEAP As String, _
                                         ByVal stUSUASICO As String, _
                                         ByVal stUSUATEL1 As String, _
                                         ByVal stUSUATEL2 As String, _
                                         ByVal stUSUAFAX1 As String, _
                                         ByVal stUSUADIRE As String, _
                                         ByVal stUSUAESTA As String, _
                                         ByVal stUSUAOBSE As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            ' *** INSTANCIA LA FECHA Y HORA ***
            Dim dateNow As DateTime = DateTime.Now

            Dim stUSUAUSMO As String = ""
            Dim daUSUAFEIN As Date = DateTime.Now.ToString()    'Fecha y hora
            Dim daUSUAFEMO As Date = DateTime.Now.ToString()

            Dim o_stUSUANUDO As New SqlParameter("@USUANUDO", stUSUANUDO)
            Dim o_inUSUATIDO As New SqlParameter("@USUATIDO", inUSUATIDO)
            Dim o_inUSUACAPR As New SqlParameter("@USUACAPR", inUSUACAPR)
            Dim o_inUSUASEXO As New SqlParameter("@USUASEXO", inUSUASEXO)
            Dim o_stUSUANOMB As New SqlParameter("@USUANOMB", stUSUANOMB)
            Dim o_stUSUAPRAP As New SqlParameter("@USUAPRAP", stUSUAPRAP)
            Dim o_stUSUASEAP As New SqlParameter("@USUASEAP", stUSUASEAP)
            Dim o_stUSUASICO As New SqlParameter("@USUASICO", stUSUASICO)
            Dim o_stUSUATEL1 As New SqlParameter("@USUATEL1", stUSUATEL1)
            Dim o_stUSUATEL2 As New SqlParameter("@USUATEL2", stUSUATEL2)
            Dim o_stUSUAFAX1 As New SqlParameter("@USUAFAX1", stUSUAFAX1)
            Dim o_stUSUADIRE As New SqlParameter("@USUADIRE", stUSUADIRE)
            Dim o_stUSUAESTA As New SqlParameter("@USUAESTA", stUSUAESTA)
            Dim o_stUSUAUSIN As New SqlParameter("@USUAUSIN", vp_usuario)
            Dim o_stUSUAUSMO As New SqlParameter("@USUAUSMO", stUSUAUSMO)
            Dim o_daUSUAFEIN As New SqlParameter("@USUAFEIN", daUSUAFEIN)
            Dim o_daUSUAFEMO As New SqlParameter("@USUAFEMO", daUSUAFEMO)
            Dim o_stUSUAOBSE As New SqlParameter("@USUAOBSE", stUSUAOBSE)

            Dim VecParametros(17) As SqlParameter

            VecParametros(0) = o_stUSUANUDO
            VecParametros(1) = o_inUSUATIDO
            VecParametros(2) = o_inUSUACAPR
            VecParametros(3) = o_inUSUASEXO
            VecParametros(4) = o_stUSUANOMB
            VecParametros(5) = o_stUSUAPRAP
            VecParametros(6) = o_stUSUASEAP
            VecParametros(7) = o_stUSUASICO
            VecParametros(8) = o_stUSUATEL1
            VecParametros(9) = o_stUSUATEL2
            VecParametros(10) = o_stUSUAFAX1
            VecParametros(11) = o_stUSUADIRE
            VecParametros(12) = o_stUSUAESTA
            VecParametros(13) = o_stUSUAUSIN
            VecParametros(14) = o_stUSUAUSMO
            VecParametros(15) = o_daUSUAFEIN
            VecParametros(16) = o_daUSUAFEMO
            VecParametros(17) = o_stUSUAOBSE

            objenq.ActualizarDb(VecParametros, "insertar_USUARIO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try
     
    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_USUARIO(ByVal inUSUAIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inUSUAIDRE As New SqlParameter("@USUAIDRE", inUSUAIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inUSUAIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_USUARIO") Then
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
    Public Function fun_Actualizar_USUARIO(ByVal inUSUAIDRE As Integer, _
                                           ByVal stUSUANUDO As String, _
                                           ByVal inUSUATIDO As Integer, _
                                           ByVal inUSUACAPR As Integer, _
                                           ByVal inUSUASEXO As Integer, _
                                           ByVal stUSUANOMB As String, _
                                           ByVal stUSUAPRAP As String, _
                                           ByVal stUSUASEAP As String, _
                                           ByVal stUSUASICO As String, _
                                           ByVal stUSUATEL1 As String, _
                                           ByVal stUSUATEL2 As String, _
                                           ByVal stUSUAFAX1 As String, _
                                           ByVal stUSUADIRE As String, _
                                           ByVal stUSUAESTA As String, _
                                           ByVal stUSUAUSIN As String, _
                                           ByVal daUSUAFEIN As Date, _
                                           ByVal stUSUAOBSE As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            ' *** INSTANCIA LA FECHA Y HORA ***
            Dim dateNow As DateTime = DateTime.Now

            Dim daUSUAFEMO As Date = DateTime.Now.ToString()    'Fecha y hora

            Dim o_inUSUAIDRE As New SqlParameter("@USUAIDRE", inUSUAIDRE)
            Dim o_stUSUANUDO As New SqlParameter("@USUANUDO", stUSUANUDO)
            Dim o_inUSUATIDO As New SqlParameter("@USUATIDO", inUSUATIDO)
            Dim o_inUSUACAPR As New SqlParameter("@USUACAPR", inUSUACAPR)
            Dim o_inUSUASEXO As New SqlParameter("@USUASEXO", inUSUASEXO)
            Dim o_stUSUANOMB As New SqlParameter("@USUANOMB", stUSUANOMB)
            Dim o_stUSUAPRAP As New SqlParameter("@USUAPRAP", stUSUAPRAP)
            Dim o_stUSUASEAP As New SqlParameter("@USUASEAP", stUSUASEAP)
            Dim o_stUSUASICO As New SqlParameter("@USUASICO", stUSUASICO)
            Dim o_stUSUATEL1 As New SqlParameter("@USUATEL1", stUSUATEL1)
            Dim o_stUSUATEL2 As New SqlParameter("@USUATEL2", stUSUATEL2)
            Dim o_stUSUAFAX1 As New SqlParameter("@USUAFAX1", stUSUAFAX1)
            Dim o_stUSUADIRE As New SqlParameter("@USUADIRE", stUSUADIRE)
            Dim o_stUSUAESTA As New SqlParameter("@USUAESTA", stUSUAESTA)
            Dim o_stUSUAUSIN As New SqlParameter("@USUAUSIN", stUSUAUSIN)
            Dim o_stUSUAUSMO As New SqlParameter("@USUAUSMO", vp_usuario)
            Dim o_daUSUAFEIN As New SqlParameter("@USUAFEIN", daUSUAFEIN)
            Dim o_daUSUAFEMO As New SqlParameter("@USUAFEMO", daUSUAFEMO)
            Dim o_stUSUAOBSE As New SqlParameter("@USUAOBSE", stUSUAOBSE)

            Dim VecParametros(18) As SqlParameter

            VecParametros(0) = o_inUSUAIDRE
            VecParametros(1) = o_stUSUANUDO
            VecParametros(2) = o_inUSUATIDO
            VecParametros(3) = o_inUSUACAPR
            VecParametros(4) = o_inUSUASEXO
            VecParametros(5) = o_stUSUANOMB
            VecParametros(6) = o_stUSUAPRAP
            VecParametros(7) = o_stUSUASEAP
            VecParametros(8) = o_stUSUASICO
            VecParametros(9) = o_stUSUATEL1
            VecParametros(10) = o_stUSUATEL2
            VecParametros(11) = o_stUSUAFAX1
            VecParametros(12) = o_stUSUADIRE
            VecParametros(13) = o_stUSUAESTA
            VecParametros(14) = o_stUSUAUSIN
            VecParametros(15) = o_stUSUAUSMO
            VecParametros(16) = o_daUSUAFEIN
            VecParametros(17) = o_daUSUAFEMO
            VecParametros(18) = o_stUSUAOBSE

            objenq.ActualizarDb(VecParametros, "actualizar_USUARIO")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_USUARIO(ByVal inUSUAIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inUSUAIDRE As New SqlParameter("@USUAIDRE", inUSUAIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inUSUAIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_USUARIO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DEL USUARIO (Documento de identidad)
    ''' para que no se guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_USUARIO(ByVal stUSUANUDO As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stUSUANUDO As New SqlParameter("@USUANUDO", stUSUANUDO)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stUSUANUDO

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_USUARIO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_Nombre_Completo_USUARIO() As DataTable

        Try
            ' Crea objeto registros
            Dim dr1 As DataRow

            ' crea la tabla
            Dim dt_USUARIO As New DataTable

            dt_USUARIO.Columns.Add(New DataColumn("USUANUDO", GetType(String)))
            dt_USUARIO.Columns.Add(New DataColumn("USUANOMB", GetType(String)))

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "USUARIO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "USUAESTA = 'ac' AND USUACAPR = '1'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "USUANOMB "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            If tbl.Rows.Count > 0 Then

                Dim i As Integer = 0

                For i = 0 To tbl.Rows.Count - 1

                    dr1 = dt_USUARIO.NewRow()

                    dr1("USUANUDO") = Trim(tbl.Rows(i).Item("USUANUDO").ToString)
                    dr1("USUANOMB") = Trim(tbl.Rows(i).Item("USUANOMB").ToString) & " " & Trim(tbl.Rows(i).Item("USUAPRAP").ToString) & " " & Trim(tbl.Rows(i).Item("USUASEAP").ToString)

                    dt_USUARIO.Rows.Add(dr1)

                Next

                tbl = dt_USUARIO

            End If

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_Nombre_Completo_USUARIO")
            Return Nothing
        End Try

    End Function

End Class
