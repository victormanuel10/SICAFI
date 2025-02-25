Imports DATOS
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class cla_FIPRLIND

    '======================
    '*** CLASE LINDEROS ***
    '======================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_FIPRLIND(ByVal inFPLINUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPLINUFI As New SqlParameter("@FPLINUFI", inFPLINUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPLINUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FIPRLIND")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_FIPRLIND(ByVal inFPLINUFI As Integer, _
                                               ByVal stFPLIPUCA As String, _
                                               ByVal stFPLICOLI As String, _
                                               ByVal stFPLIDEPA As String, _
                                               ByVal stFPLIMUNI As String, _
                                               ByVal inFPLITIRE As Integer, _
                                               ByVal inFPLICLSE As Integer, _
                                               ByVal inFPLIVIGE As Integer, _
                                               ByVal inFPLIRESO As Integer, _
                                               ByVal inFPLISECU As Integer, _
                                               ByVal inFPLINURE As Integer, _
                                               ByVal stFPLIESTA As String) As Boolean

        ''*** INSTANCIA QUE IDENTIFICA EL NOMBRE DE LA MAQUINA ***
        Dim stFPLIMAQU As String = fun_Nombre_de_maquina()

        '' *** INSTANCIA LA FECHA Y HORA ***
        Dim daFPLIFEIN As Date = fun_Hora_y_fecha()
        Dim daFPLIFEMO As Date = fun_Hora_y_fecha()

        '' *** USUARIO QUE MODIFICA ***
        Dim stFPLIUSMO As String = ""

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPLINUFI As New SqlParameter("@FPLINUFI", inFPLINUFI)
            Dim o_stFPLIPUCA As New SqlParameter("@FPLIPUCA", stFPLIPUCA)
            Dim o_stFPLICOLI As New SqlParameter("@FPLICOLI", stFPLICOLI)
            Dim o_stFPLIDEPA As New SqlParameter("@FPLIDEPA", stFPLIDEPA)
            Dim o_stFPLIMUNI As New SqlParameter("@FPLIMUNI", stFPLIMUNI)
            Dim o_inFPLITIRE As New SqlParameter("@FPLITIRE", inFPLITIRE)
            Dim o_inFPLICLSE As New SqlParameter("@FPLICLSE", inFPLICLSE)
            Dim o_inFPLIVIGE As New SqlParameter("@FPLIVIGE", inFPLIVIGE)
            Dim o_inFPLIRESO As New SqlParameter("@FPLIRESO", inFPLIRESO)
            Dim o_inFPLISECU As New SqlParameter("@FPLISECU", inFPLISECU)
            Dim o_inFPLINURE As New SqlParameter("@FPLINURE", inFPLINURE)
            Dim o_stFPLIESTA As New SqlParameter("@FPLIESTA", stFPLIESTA)
            Dim o_stFPLIUSIN As New SqlParameter("@FPLIUSIN", vp_usuario)
            Dim o_stFPLIUSMO As New SqlParameter("@FPLIUSMO", stFPLIUSMO)
            Dim o_daFPLIFEIN As New SqlParameter("@FPLIFEIN", daFPLIFEIN)
            Dim o_daFPLIFEMO As New SqlParameter("@FPLIFEMO", daFPLIFEMO)
            Dim o_stFPLIMAQU As New SqlParameter("@FPLIMAQU", stFPLIMAQU)

            Dim VecParametros(16) As SqlParameter

            VecParametros(0) = o_inFPLINUFI
            VecParametros(1) = o_stFPLIPUCA
            VecParametros(2) = o_stFPLICOLI
            VecParametros(3) = o_stFPLIDEPA
            VecParametros(4) = o_stFPLIMUNI
            VecParametros(5) = o_inFPLITIRE
            VecParametros(6) = o_inFPLICLSE
            VecParametros(7) = o_inFPLIVIGE
            VecParametros(8) = o_inFPLIRESO
            VecParametros(9) = o_inFPLISECU
            VecParametros(10) = o_inFPLINURE
            VecParametros(11) = o_stFPLIESTA
            VecParametros(12) = o_stFPLIUSIN
            VecParametros(13) = o_stFPLIUSMO
            VecParametros(14) = o_daFPLIFEIN
            VecParametros(15) = o_daFPLIFEMO
            VecParametros(16) = o_stFPLIMAQU

            objenq.ActualizarDb(VecParametros, "insertar_FIPRLIND")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_FIPRLIND(ByVal inFPLIIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPLIIDRE As New SqlParameter("@FPLIIDRE", inFPLIIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPLIIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_FIPRLIND") Then
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
    Public Function fun_Actualizar_FIPRLIND(ByVal inFPLIIDRE As Integer, _
                                               ByVal inFPLINUFI As Integer, _
                                               ByVal stFPLIPUCA As String, _
                                               ByVal stFPLICOLI As String, _
                                               ByVal stFPLIDEPA As String, _
                                               ByVal stFPLIMUNI As String, _
                                               ByVal inFPLITIRE As Integer, _
                                               ByVal inFPLICLSE As Integer, _
                                               ByVal inFPLIVIGE As Integer, _
                                               ByVal inFPLIRESO As Integer, _
                                               ByVal inFPLISECU As Integer, _
                                               ByVal inFPLINURE As Integer, _
                                               ByVal stFPLIESTA As String, _
                                               ByVal stFPLIUSIN As String, _
                                               ByVal daFPLIFEIN As Date) As Boolean


        Dim stFPLIMAQU As String = fun_Nombre_de_maquina()
        Dim daFPLIFEMO As Date = fun_Hora_y_fecha()

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPLIIDRE As New SqlParameter("@FPLIIDRE", inFPLIIDRE)
            Dim o_inFPLINUFI As New SqlParameter("@FPLINUFI", inFPLINUFI)
            Dim o_stFPLIPUCA As New SqlParameter("@FPLIPUCA", stFPLIPUCA)
            Dim o_stFPLICOLI As New SqlParameter("@FPLICOLI", stFPLICOLI)
            Dim o_stFPLIDEPA As New SqlParameter("@FPLIDEPA", stFPLIDEPA)
            Dim o_stFPLIMUNI As New SqlParameter("@FPLIMUNI", stFPLIMUNI)
            Dim o_inFPLITIRE As New SqlParameter("@FPLITIRE", inFPLITIRE)
            Dim o_inFPLICLSE As New SqlParameter("@FPLICLSE", inFPLICLSE)
            Dim o_inFPLIVIGE As New SqlParameter("@FPLIVIGE", inFPLIVIGE)
            Dim o_inFPLIRESO As New SqlParameter("@FPLIRESO", inFPLIRESO)
            Dim o_inFPLISECU As New SqlParameter("@FPLISECU", inFPLISECU)
            Dim o_inFPLINURE As New SqlParameter("@FPLINURE", inFPLINURE)
            Dim o_stFPLIESTA As New SqlParameter("@FPLIESTA", stFPLIESTA)
            Dim o_stFPLIUSIN As New SqlParameter("@FPLIUSIN", stFPLIUSIN)
            Dim o_stFPLIUSMO As New SqlParameter("@FPLIUSMO", vp_usuario)
            Dim o_daFPLIFEIN As New SqlParameter("@FPLIFEIN", daFPLIFEIN)
            Dim o_daFPLIFEMO As New SqlParameter("@FPLIFEMO", daFPLIFEMO)
            Dim o_stFPLIMAQU As New SqlParameter("@FPLIMAQU", stFPLIMAQU)

            Dim VecParametros(17) As SqlParameter

            VecParametros(0) = o_inFPLIIDRE
            VecParametros(1) = o_inFPLINUFI
            VecParametros(2) = o_stFPLIPUCA
            VecParametros(3) = o_stFPLICOLI
            VecParametros(4) = o_stFPLIDEPA
            VecParametros(5) = o_stFPLIMUNI
            VecParametros(6) = o_inFPLITIRE
            VecParametros(7) = o_inFPLICLSE
            VecParametros(8) = o_inFPLIVIGE
            VecParametros(9) = o_inFPLIRESO
            VecParametros(10) = o_inFPLISECU
            VecParametros(11) = o_inFPLINURE
            VecParametros(12) = o_stFPLIESTA
            VecParametros(13) = o_stFPLIUSIN
            VecParametros(14) = o_stFPLIUSMO
            VecParametros(15) = o_daFPLIFEIN
            VecParametros(16) = o_daFPLIFEMO
            VecParametros(17) = o_stFPLIMAQU

            objenq.ActualizarDb(VecParametros, "actualizar_FIPRLIND")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica o actualiza el registro.
    ''' </summary>
    Public Function fun_Actualizar_FIPRLIND(ByVal inFPLIIDRE As Integer, _
                                            ByVal inFPLINUFI As Integer, _
                                            ByVal stFPLIPUCA As String, _
                                            ByVal stFPLICOLI As String) As Boolean



        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "FIPRLIND "

            stConsultaSQL += "SET "
            stConsultaSQL += "FPLINUFI = '" & CInt(inFPLINUFI) & "', "
            stConsultaSQL += "FPLIPUCA = '" & CStr(Trim(stFPLIPUCA)) & "', "
            stConsultaSQL += "FPLICOLI = '" & CStr(Trim(stFPLICOLI)) & "'  "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPLIIDRE = '" & CInt(inFPLIIDRE) & "'"

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
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_FIPRLIND(ByVal inFPLIIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPLIIDRE As New SqlParameter("@FPLIIDRE", inFPLIIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPLIIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_FIPRLIND")

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
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_FIPRLIND(ByVal inFPLINUFI As Integer, _
                                                                    ByVal stFPLIPUCA As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPLINUFI As New SqlParameter("@FPLINUFI", inFPLINUFI)
            Dim o_stFPLIPUCA As New SqlParameter("@FPLIPUCA", stFPLIPUCA)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_inFPLINUFI
            VecParametros(1) = o_stFPLIPUCA

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_ID_X_CONSULTA_PARAMETRIZADA_FIPRLIND")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el EL NUMERO DE SECUENCIA de acuerdo
    ''' al numero de la ficha predial.
    ''' </summary>
    Public Function fun_Buscar_NRO_SECUENCIA_FIPRLIND_X_FICHA_PREDIAL(ByVal inFPLINUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPLINUFI As New SqlParameter("@FPLINUFI", inFPLINUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPLINUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_NRO_SECUENCIA_FIPRLIND_X_FICHA_PREDIAL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Consulta todos los campos de la construccion por ficha predial para llenar los
    ''' campos del formulario ficha predial
    ''' </summary>
    Public Function fun_Consultar_FIPRLIND_X_FICHA_PREDIAL(ByVal inFPLINUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPLINUFI As New SqlParameter("@FPLINUFI", inFPLINUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPLINUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FIPRLIND_X_FICHA_PREDIAL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_NUFI_FIPRLIND(ByVal inFPLINUFI As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "FIPRLIND "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPLINUFI = '" & CInt(inFPLINUFI) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_IDRE_MUTADEPA")
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_PUCA_COLI_FIPRLIND(ByVal inFPLINUFI As Integer, _
                                                     ByVal inFPLIIDRE As Integer, _
                                                     ByVal stFPLIPUCA As String, _
                                                     ByVal stFPLICOLI As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FIPRLIND "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPLINUFI = '" & CInt(inFPLINUFI) & "' and "
            stConsultaSQL += "NOT FPLIIDRE = '" & CInt(inFPLIIDRE) & "' and "
            stConsultaSQL += "FPLIPUCA = '" & CStr(Trim(stFPLIPUCA)) & "' and "
            stConsultaSQL += "FPLICOLI = '" & CStr(Trim(stFPLICOLI)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_REGICONT")
            Return Nothing
        End Try

    End Function
End Class
