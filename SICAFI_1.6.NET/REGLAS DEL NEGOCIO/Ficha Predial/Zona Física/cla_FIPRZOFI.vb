Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_FIPRZOFI

    '=========================
    '*** CLASE ZONA FISICA ***
    '=========================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_FIPRZOFI(ByVal inFPZFNUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPZFNUFI As New SqlParameter("@FPZFNUFI", inFPZFNUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPZFNUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FIPRZOFI")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_FIPRZOFI(ByVal inFPZFNUFI As Integer, _
                                               ByVal inFPZFZOFI As Integer, _
                                               ByVal inFPZFPORC As Integer, _
                                               ByVal stFPZFDEPA As String, _
                                               ByVal stFPZFMUNI As String, _
                                               ByVal inFPZFTIRE As Integer, _
                                               ByVal inFPZFCLSE As Integer, _
                                               ByVal inFPZFVIGE As Integer, _
                                               ByVal inFPZFRESO As Integer, _
                                               ByVal inFPZFSECU As Integer, _
                                               ByVal inFPZFNURE As Integer, _
                                               ByVal stFPZFESTA As String) As Boolean

        ''*** INSTANCIA QUE IDENTIFICA EL NOMBRE DE LA MAQUINA ***
        Dim stFPZFMAQU As String = fun_Nombre_de_maquina()

        '' *** INSTANCIA LA FECHA Y HORA ***
        Dim daFPZFFEIN As Date = fun_Hora_y_fecha()
        Dim daFPZFFEMO As Date = fun_Hora_y_fecha()

        '' *** USUARIO QUE MODIFICA ***
        Dim stFPZFUSMO As String = ""

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPZFNUFI As New SqlParameter("@FPZFNUFI", inFPZFNUFI)
            Dim o_inFPZFZOFI As New SqlParameter("@FPZFZOFI", inFPZFZOFI)
            Dim o_inFPZFPORC As New SqlParameter("@FPZFPORC", inFPZFPORC)
            Dim o_stFPZFDEPA As New SqlParameter("@FPZFDEPA", stFPZFDEPA)
            Dim o_stFPZFMUNI As New SqlParameter("@FPZFMUNI", stFPZFMUNI)
            Dim o_inFPZFTIRE As New SqlParameter("@FPZFTIRE", inFPZFTIRE)
            Dim o_inFPZFCLSE As New SqlParameter("@FPZFCLSE", inFPZFCLSE)
            Dim o_inFPZFVIGE As New SqlParameter("@FPZFVIGE", inFPZFVIGE)
            Dim o_inFPZFRESO As New SqlParameter("@FPZFRESO", inFPZFRESO)
            Dim o_inFPZFSECU As New SqlParameter("@FPZFSECU", inFPZFSECU)
            Dim o_inFPZFNURE As New SqlParameter("@FPZFNURE", inFPZFNURE)
            Dim o_stFPZFESTA As New SqlParameter("@FPZFESTA", stFPZFESTA)
            Dim o_stFPZFUSIN As New SqlParameter("@FPZFUSIN", vp_usuario)
            Dim o_stFPZFUSMO As New SqlParameter("@FPZFUSMO", stFPZFUSMO)
            Dim o_daFPZFFEIN As New SqlParameter("@FPZFFEIN", daFPZFFEIN)
            Dim o_daFPZFFEMO As New SqlParameter("@FPZFFEMO", daFPZFFEMO)
            Dim o_stFPZFMAQU As New SqlParameter("@FPZFMAQU", stFPZFMAQU)

            Dim VecParametros(16) As SqlParameter

            VecParametros(0) = o_inFPZFNUFI
            VecParametros(1) = o_inFPZFZOFI
            VecParametros(2) = o_inFPZFPORC
            VecParametros(3) = o_stFPZFDEPA
            VecParametros(4) = o_stFPZFMUNI
            VecParametros(5) = o_inFPZFTIRE
            VecParametros(6) = o_inFPZFCLSE
            VecParametros(7) = o_inFPZFVIGE
            VecParametros(8) = o_inFPZFRESO
            VecParametros(9) = o_inFPZFSECU
            VecParametros(10) = o_inFPZFNURE
            VecParametros(11) = o_stFPZFESTA
            VecParametros(12) = o_stFPZFUSIN
            VecParametros(13) = o_stFPZFUSMO
            VecParametros(14) = o_daFPZFFEIN
            VecParametros(15) = o_daFPZFFEMO
            VecParametros(16) = o_stFPZFMAQU

            objenq.ActualizarDb(VecParametros, "insertar_FIPRZOFI")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_FIPRZOFI(ByVal inFPZFIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPZFIDRE As New SqlParameter("@FPZFIDRE", inFPZFIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPZFIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_FIPRZOFI") Then
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
    ''' Función que Elimina el registro por Nro de ficha predial.
    ''' </summary>
    Public Function fun_Eliminar_FIPRZOFI_X_FICHA_PREDIAL(ByVal inFPZFNUFI As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPZFNUFI As New SqlParameter("@FPZFNUFI", inFPZFNUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPZFNUFI

            If objenq.ActualizarDb(VecParametros, "eliminar_FIPRZOFI_X_NRO_FICHA_PREDIAL") Then
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
    Public Function fun_Actualizar_FIPRZOFI(ByVal inFPZFIDRE As Integer, _
                                               ByVal inFPZFNUFI As Integer, _
                                               ByVal inFPZFZOFI As Integer, _
                                               ByVal inFPZFPORC As Integer, _
                                               ByVal stFPZFDEPA As String, _
                                               ByVal stFPZFMUNI As String, _
                                               ByVal inFPZFTIRE As Integer, _
                                               ByVal inFPZFCLSE As Integer, _
                                               ByVal inFPZFVIGE As Integer, _
                                               ByVal inFPZFRESO As Integer, _
                                               ByVal inFPZFSECU As Integer, _
                                               ByVal inFPZFNURE As Integer, _
                                               ByVal stFPZFESTA As String, _
                                               ByVal stFPZFUSIN As String, _
                                               ByVal daFPZFFEIN As Date) As Boolean


        Dim stFPZFMAQU As String = fun_Nombre_de_maquina()
        Dim daFPZFFEMO As Date = fun_Hora_y_fecha()

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPZFIDRE As New SqlParameter("@FPZFIDRE", inFPZFIDRE)
            Dim o_inFPZFNUFI As New SqlParameter("@FPZFNUFI", inFPZFNUFI)
            Dim o_inFPZFZOFI As New SqlParameter("@FPZFZOFI", inFPZFZOFI)
            Dim o_inFPZFPORC As New SqlParameter("@FPZFPORC", inFPZFPORC)
            Dim o_stFPZFDEPA As New SqlParameter("@FPZFDEPA", stFPZFDEPA)
            Dim o_stFPZFMUNI As New SqlParameter("@FPZFMUNI", stFPZFMUNI)
            Dim o_inFPZFTIRE As New SqlParameter("@FPZFTIRE", inFPZFTIRE)
            Dim o_inFPZFCLSE As New SqlParameter("@FPZFCLSE", inFPZFCLSE)
            Dim o_inFPZFVIGE As New SqlParameter("@FPZFVIGE", inFPZFVIGE)
            Dim o_inFPZFRESO As New SqlParameter("@FPZFRESO", inFPZFRESO)
            Dim o_inFPZFSECU As New SqlParameter("@FPZFSECU", inFPZFSECU)
            Dim o_inFPZFNURE As New SqlParameter("@FPZFNURE", inFPZFNURE)
            Dim o_stFPZFESTA As New SqlParameter("@FPZFESTA", stFPZFESTA)
            Dim o_stFPZFUSIN As New SqlParameter("@FPZFUSIN", stFPZFUSIN)
            Dim o_stFPZFUSMO As New SqlParameter("@FPZFUSMO", vp_usuario)
            Dim o_daFPZFFEIN As New SqlParameter("@FPZFFEIN", daFPZFFEIN)
            Dim o_daFPZFFEMO As New SqlParameter("@FPZFFEMO", daFPZFFEMO)
            Dim o_stFPZFMAQU As New SqlParameter("@FPZFMAQU", stFPZFMAQU)

            Dim VecParametros(17) As SqlParameter

            VecParametros(0) = o_inFPZFIDRE
            VecParametros(1) = o_inFPZFNUFI
            VecParametros(2) = o_inFPZFZOFI
            VecParametros(3) = o_inFPZFPORC
            VecParametros(4) = o_stFPZFDEPA
            VecParametros(5) = o_stFPZFMUNI
            VecParametros(6) = o_inFPZFTIRE
            VecParametros(7) = o_inFPZFCLSE
            VecParametros(8) = o_inFPZFVIGE
            VecParametros(9) = o_inFPZFRESO
            VecParametros(10) = o_inFPZFSECU
            VecParametros(11) = o_inFPZFNURE
            VecParametros(12) = o_stFPZFESTA
            VecParametros(13) = o_stFPZFUSIN
            VecParametros(14) = o_stFPZFUSMO
            VecParametros(15) = o_daFPZFFEIN
            VecParametros(16) = o_daFPZFFEMO
            VecParametros(17) = o_stFPZFMAQU

            objenq.ActualizarDb(VecParametros, "actualizar_FIPRZOFI")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_FIPRZOFI(ByVal inFPZFIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPZFIDRE As New SqlParameter("@FPZFIDRE", inFPZFIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPZFIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_FIPRZOFI")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_FIPRZOFI(ByVal inFPZFNUFI As Integer, _
                                                ByVal inFPZFZOFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPZFNUFI As New SqlParameter("@FPZFNUFI", inFPZFNUFI)
            Dim o_inFPZFZOFI As New SqlParameter("@FPZFZOFI", inFPZFZOFI)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_inFPZFNUFI
            VecParametros(1) = o_inFPZFZOFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_FIPRZOFI")

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
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_FIPRZOFI(ByVal inFPZFNUFI As Integer, _
                                                                    ByVal inFPZFZOFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPZFNUFI As New SqlParameter("@FPZFNUFI", inFPZFNUFI)
            Dim o_inFPZFZOFI As New SqlParameter("@FPZFZOFI", inFPZFZOFI)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_inFPZFNUFI
            VecParametros(1) = o_inFPZFZOFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_ID_X_CONSULTA_PARAMETRIZADA_FIPRZOFI")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el EL NUMERO DE SECUENCIA de acuerdo al numero de la ficha predial.
    ''' </summary>
    Public Function fun_Buscar_NRO_SECUENCIA_FIPRZOFI_X_FICHA_PREDIAL(ByVal inFPZFNUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPZFNUFI As New SqlParameter("@FPZFNUFI", inFPZFNUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPZFNUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_NRO_SECUENCIA_FIPRZOFI_X_FICHA_PREDIAL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que consulta la sumatoria de los porcentajes que se encuantran activos.
    ''' </summary>
    Public Function fun_Consultar_SUMA_X_FPZFPORC_FIPRZOFI(ByVal inFPZFNUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPZFNUFI As New SqlParameter("@FPZFNUFI", inFPZFNUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPZFNUFI

            Dim SumaDestino As New DataTable
            SumaDestino = objeq.ConsultarDb(VecParametros, "Consultar_SUMA_X_FPZFPORC_FIPRZOFI")

            Return SumaDestino

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Consulta todos los campos de propietario por ficha predial para llenar los
    ''' campos del formulario ficha predial
    ''' </summary>
    Public Function fun_Consultar_FIPRZOFI_X_FICHA_PREDIAL(ByVal inFPZFNUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPZFNUFI As New SqlParameter("@FPZFNUFI", inFPZFNUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPZFNUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FIPRZOFI_X_FICHA_PREDIAL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la zona segun departamento, municipio y sector
    ''' </summary>
    Public Function fun_buscar_ZOFIDEPA_X_ZOFIMUNI_X_ZOFICLSE_X_MANT_ZONAFISI(ByVal stZOFIDEPA As String, _
                                                                 ByVal stZOFIMUNI As String, _
                                                                 ByVal inZOFICLSE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stZOFIDEPA As New SqlParameter("@ZOFIDEPA", stZOFIDEPA)
            Dim o_stZOFIMUNI As New SqlParameter("@ZOFIMUNI", stZOFIMUNI)
            Dim o_inZOFICLSE As New SqlParameter("@ZOFICLSE", inZOFICLSE)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_stZOFIDEPA
            VecParametros(1) = o_stZOFIMUNI
            VecParametros(2) = o_inZOFICLSE


            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ZOFIDEPA_X_ZOFIMUNI_X_ZOFICLSE_X_MANT_ZONAFISI")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function
    ''' <summary>
    ''' Función que busca la zona fisica actual 
    ''' </summary>
    Public Function fun_buscar_ZOFIMUNI_X_ZOFICLSE_X_MANT_ZONAFISI(ByVal stFPZFMUNI As String, _
                                                                   ByVal inFPZFCLSE As Integer, _
                                                                   ByVal inFPZFZOFI As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "FIPRZOFI "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPZFMUNI = '" & CStr(Trim(stFPZFMUNI)) & "' and "
            stConsultaSQL += "FPZFCLSE = '" & CInt(inFPZFCLSE) & "' and "
            stConsultaSQL += "FPZFZOFI = '" & CInt(inFPZFZOFI) & "' and "
            stConsultaSQL += "FPZFPORC = '100' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MUNI_CLSE_X_MANT_VARIZOFI")
            Return Nothing
        End Try

    End Function


End Class
