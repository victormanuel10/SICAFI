Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_FIPRDEEC

    '===================================
    '*** CLASE DESTINACIÓN ECONÓMICA ***
    '===================================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_FIPRDEEC(ByVal inFPDENUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPDENUFI As New SqlParameter("@FPDENUFI", inFPDENUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPDENUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FIPRDEEC")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function
	
    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_FIPRDEEC(ByVal inFPDENUFI As Integer, _
                                               ByVal inFPDEDEEC As Integer, _
                                               ByVal inFPDEPORC As Integer, _
                                               ByVal stFPDEDEPA As String, _
                                               ByVal stFPDEMUNI As String, _
                                               ByVal inFPDETIRE As Integer, _
                                               ByVal inFPDECLSE As Integer, _
                                               ByVal inFPDEVIGE As Integer, _
                                               ByVal inFPDERESO As Integer, _
                                               ByVal inFPDESECU As Integer, _
                                               ByVal inFPDENURE As Integer, _
                                               ByVal stFPDEESTA As String) As Boolean

        ''*** INSTANCIA QUE IDENTIFICA EL NOMBRE DE LA MAQUINA ***
        Dim stFPDEMAQU As String = fun_Nombre_de_maquina()

        '' *** INSTANCIA LA FECHA Y HORA ***
        Dim daFPDEFEIN As Date = fun_Hora_y_fecha()
        Dim daFPDEFEMO As Date = fun_Hora_y_fecha()

        '' *** USUARIO QUE MODIFICA ***
        Dim stFPDEUSMO As String = ""

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPDENUFI As New SqlParameter("@FPDENUFI", inFPDENUFI)
            Dim o_inFPDEDEEC As New SqlParameter("@FPDEDEEC", inFPDEDEEC)
            Dim o_inFPDEPORC As New SqlParameter("@FPDEPORC", inFPDEPORC)
            Dim o_stFPDEDEPA As New SqlParameter("@FPDEDEPA", stFPDEDEPA)
            Dim o_stFPDEMUNI As New SqlParameter("@FPDEMUNI", stFPDEMUNI)
            Dim o_inFPDETIRE As New SqlParameter("@FPDETIRE", inFPDETIRE)
            Dim o_inFPDECLSE As New SqlParameter("@FPDECLSE", inFPDECLSE)
            Dim o_inFPDEVIGE As New SqlParameter("@FPDEVIGE", inFPDEVIGE)
            Dim o_inFPDERESO As New SqlParameter("@FPDERESO", inFPDERESO)
            Dim o_inFPDESECU As New SqlParameter("@FPDESECU", inFPDESECU)
            Dim o_inFPDENURE As New SqlParameter("@FPDENURE", inFPDENURE)
            Dim o_stFPDEESTA As New SqlParameter("@FPDEESTA", stFPDEESTA)
            Dim o_stFPDEUSIN As New SqlParameter("@FPDEUSIN", vp_usuario)
            Dim o_stFPDEUSMO As New SqlParameter("@FPDEUSMO", stFPDEUSMO)
            Dim o_daFPDEFEIN As New SqlParameter("@FPDEFEIN", daFPDEFEIN)
            Dim o_daFPDEFEMO As New SqlParameter("@FPDEFEMO", daFPDEFEMO)
            Dim o_stFPDEMAQU As New SqlParameter("@FPDEMAQU", stFPDEMAQU)

            Dim VecParametros(16) As SqlParameter

            VecParametros(0) = o_inFPDENUFI
            VecParametros(1) = o_inFPDEDEEC
            VecParametros(2) = o_inFPDEPORC
            VecParametros(3) = o_stFPDEDEPA
            VecParametros(4) = o_stFPDEMUNI
            VecParametros(5) = o_inFPDETIRE
            VecParametros(6) = o_inFPDECLSE
            VecParametros(7) = o_inFPDEVIGE
            VecParametros(8) = o_inFPDERESO
            VecParametros(9) = o_inFPDESECU
            VecParametros(10) = o_inFPDENURE
            VecParametros(11) = o_stFPDEESTA
            VecParametros(12) = o_stFPDEUSIN
            VecParametros(13) = o_stFPDEUSMO
            VecParametros(14) = o_daFPDEFEIN
            VecParametros(15) = o_daFPDEFEMO
            VecParametros(16) = o_stFPDEMAQU

            objenq.ActualizarDb(VecParametros, "insertar_FIPRDEEC")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_FIPRDEEC(ByVal inFPDEIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPDEIDRE As New SqlParameter("@FPDEIDRE", inFPDEIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPDEIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_FIPRDEEC") Then
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
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_NUFI_FIPRDEEC(ByVal inFPDENUFI As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "FIPRDEEC "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPDENUFI = '" & CInt(inFPDENUFI) & "' "

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
    ''' Función que Modifica o actualiza el registro.
    ''' </summary>
    Public Function fun_Actualizar_FIPRDEEC(ByVal inFPDEIDRE As Integer, _
                                               ByVal inFPDENUFI As Integer, _
                                               ByVal inFPDEDEEC As Integer, _
                                               ByVal inFPDEPORC As Integer, _
                                               ByVal stFPDEDEPA As String, _
                                               ByVal stFPDEMUNI As String, _
                                               ByVal inFPDETIRE As Integer, _
                                               ByVal inFPDECLSE As Integer, _
                                               ByVal inFPDEVIGE As Integer, _
                                               ByVal inFPDERESO As Integer, _
                                               ByVal inFPDESECU As Integer, _
                                               ByVal inFPDENURE As Integer, _
                                               ByVal stFPDEESTA As String, _
                                               ByVal stFPDEUSIN As String, _
                                               ByVal daFPDEFEIN As Date) As Boolean


        Dim stFPDEMAQU As String = fun_Nombre_de_maquina()
        Dim daFPDEFEMO As Date = fun_Hora_y_fecha()

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPDEIDRE As New SqlParameter("@FPDEIDRE", inFPDEIDRE)
            Dim o_inFPDENUFI As New SqlParameter("@FPDENUFI", inFPDENUFI)
            Dim o_inFPDEDEEC As New SqlParameter("@FPDEDEEC", inFPDEDEEC)
            Dim o_inFPDEPORC As New SqlParameter("@FPDEPORC", inFPDEPORC)
            Dim o_stFPDEDEPA As New SqlParameter("@FPDEDEPA", stFPDEDEPA)
            Dim o_stFPDEMUNI As New SqlParameter("@FPDEMUNI", stFPDEMUNI)
            Dim o_inFPDETIRE As New SqlParameter("@FPDETIRE", inFPDETIRE)
            Dim o_inFPDECLSE As New SqlParameter("@FPDECLSE", inFPDECLSE)
            Dim o_inFPDEVIGE As New SqlParameter("@FPDEVIGE", inFPDEVIGE)
            Dim o_inFPDERESO As New SqlParameter("@FPDERESO", inFPDERESO)
            Dim o_inFPDESECU As New SqlParameter("@FPDESECU", inFPDESECU)
            Dim o_inFPDENURE As New SqlParameter("@FPDENURE", inFPDENURE)
            Dim o_stFPDEESTA As New SqlParameter("@FPDEESTA", stFPDEESTA)
            Dim o_stFPDEUSIN As New SqlParameter("@FPDEUSIN", stFPDEUSIN)
            Dim o_stFPDEUSMO As New SqlParameter("@FPDEUSMO", vp_usuario)
            Dim o_daFPDEFEIN As New SqlParameter("@FPDEFEIN", daFPDEFEIN)
            Dim o_daFPDEFEMO As New SqlParameter("@FPDEFEMO", daFPDEFEMO)
            Dim o_stFPDEMAQU As New SqlParameter("@FPDEMAQU", stFPDEMAQU)

            Dim VecParametros(17) As SqlParameter

            VecParametros(0) = o_inFPDEIDRE
            VecParametros(1) = o_inFPDENUFI
            VecParametros(2) = o_inFPDEDEEC
            VecParametros(3) = o_inFPDEPORC
            VecParametros(4) = o_stFPDEDEPA
            VecParametros(5) = o_stFPDEMUNI
            VecParametros(6) = o_inFPDETIRE
            VecParametros(7) = o_inFPDECLSE
            VecParametros(8) = o_inFPDEVIGE
            VecParametros(9) = o_inFPDERESO
            VecParametros(10) = o_inFPDESECU
            VecParametros(11) = o_inFPDENURE
            VecParametros(12) = o_stFPDEESTA
            VecParametros(13) = o_stFPDEUSIN
            VecParametros(14) = o_stFPDEUSMO
            VecParametros(15) = o_daFPDEFEIN
            VecParametros(16) = o_daFPDEFEMO
            VecParametros(17) = o_stFPDEMAQU

            objenq.ActualizarDb(VecParametros, "actualizar_FIPRDEEC")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_FIPRDEEC(ByVal inFPDEIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPDEIDRE As New SqlParameter("@FPDEIDRE", inFPDEIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPDEIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_FIPRDEEC")

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
    Public Function fun_Buscar_CODIGO_FIPRDEEC(ByVal inFPDENUFI As Integer, _
                                                ByVal inFPDEDEEC As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPDENUFI As New SqlParameter("@FPDENUFI", inFPDENUFI)
            Dim o_inFPDEDEEC As New SqlParameter("@FPDEDEEC", inFPDEDEEC)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_inFPDENUFI
            VecParametros(1) = o_inFPDEDEEC

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_FIPRDEEC")

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
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_FIPRDEEC(ByVal inFPDENUFI As Integer, _
                                                                    ByVal inFPDEDEEC As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPDENUFI As New SqlParameter("@FPDENUFI", inFPDENUFI)
            Dim o_inFPDEDEEC As New SqlParameter("@FPDEDEEC", inFPDEDEEC)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_inFPDENUFI
            VecParametros(1) = o_inFPDEDEEC

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_ID_X_CONSULTA_PARAMETRIZADA_FIPRDEEC")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el EL NUMERO DE SECUENCIA DE LA DESTINACIÓN ECONOMICA MAXIMO de acuerdo
    ''' al numero de la ficha predial.
    ''' </summary>
    Public Function fun_Buscar_NRO_SECUENCIA_FIPRDEEC_X_FICHA_PREDIAL(ByVal inFPDENUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPDENUFI As New SqlParameter("@FPDENUFI", inFPDENUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPDENUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_NRO_SECUENCIA_FIPRDEEC_X_FICHA_PREDIAL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que consulta la sumatoria de los porcentajes de la destinación economica
    ''' que se encuantran activos.
    ''' </summary>
    Public Function fun_Consultar_SUMA_X_FPDEPORC_FIPRDEEC(ByVal inFPDENUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPDENUFI As New SqlParameter("@FPDENUFI", inFPDENUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPDENUFI

            Dim SumaDestino As New DataTable
            SumaDestino = objeq.ConsultarDb(VecParametros, "Consultar_SUMA_X_FPDEPORC_FIPRDEEC")

            Return SumaDestino

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Consulta todos los campos de destinación económica por ficha predial para llenar los
    ''' campos del formulario ficha predial
    ''' </summary>
    Public Function fun_Consultar_FIPRDEEC_X_FICHA_PREDIAL(ByVal inFPDENUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPDENUFI As New SqlParameter("@FPDENUFI", inFPDENUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPDENUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FIPRDEEC_X_FICHA_PREDIAL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function




End Class
