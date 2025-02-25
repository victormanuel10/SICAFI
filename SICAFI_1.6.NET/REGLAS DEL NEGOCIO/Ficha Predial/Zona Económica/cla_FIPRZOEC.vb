Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_FIPRZOEC

    '============================
    '*** CLASE ZONA ECONOMICA ***
    '============================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_FIPRZOEC(ByVal inFPZENUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPZENUFI As New SqlParameter("@FPZENUFI", inFPZENUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPZENUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FIPRZOEC")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_FIPRZOEC(ByVal inFPZENUFI As Integer, _
                                               ByVal inFPZEZOEC As Integer, _
                                               ByVal inFPZEPORC As Integer, _
                                               ByVal stFPZEDEPA As String, _
                                               ByVal stFPZEMUNI As String, _
                                               ByVal inFPZETIRE As Integer, _
                                               ByVal inFPZECLSE As Integer, _
                                               ByVal inFPZEVIGE As Integer, _
                                               ByVal inFPZERESO As Integer, _
                                               ByVal inFPZESECU As Integer, _
                                               ByVal inFPZENURE As Integer, _
                                               ByVal stFPZEESTA As String) As Boolean

        ''*** INSTANCIA QUE IDENTIFICA EL NOMBRE DE LA MAQUINA ***
        Dim stFPZEMAQU As String = fun_Nombre_de_maquina()

        '' *** INSTANCIA LA FECHA Y HORA ***
        Dim daFPZEFEIN As Date = fun_Hora_y_fecha()
        Dim daFPZEFEMO As Date = fun_Hora_y_fecha()

        '' *** USUARIO QUE MODIFICA ***
        Dim stFPZEUSMO As String = ""

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPZENUFI As New SqlParameter("@FPZENUFI", inFPZENUFI)
            Dim o_inFPZEZOEC As New SqlParameter("@FPZEZOEC", inFPZEZOEC)
            Dim o_inFPZEPORC As New SqlParameter("@FPZEPORC", inFPZEPORC)
            Dim o_stFPZEDEPA As New SqlParameter("@FPZEDEPA", stFPZEDEPA)
            Dim o_stFPZEMUNI As New SqlParameter("@FPZEMUNI", stFPZEMUNI)
            Dim o_inFPZETIRE As New SqlParameter("@FPZETIRE", inFPZETIRE)
            Dim o_inFPZECLSE As New SqlParameter("@FPZECLSE", inFPZECLSE)
            Dim o_inFPZEVIGE As New SqlParameter("@FPZEVIGE", inFPZEVIGE)
            Dim o_inFPZERESO As New SqlParameter("@FPZERESO", inFPZERESO)
            Dim o_inFPZESECU As New SqlParameter("@FPZESECU", inFPZESECU)
            Dim o_inFPZENURE As New SqlParameter("@FPZENURE", inFPZENURE)
            Dim o_stFPZEESTA As New SqlParameter("@FPZEESTA", stFPZEESTA)
            Dim o_stFPZEUSIN As New SqlParameter("@FPZEUSIN", vp_usuario)
            Dim o_stFPZEUSMO As New SqlParameter("@FPZEUSMO", stFPZEUSMO)
            Dim o_daFPZEFEIN As New SqlParameter("@FPZEFEIN", daFPZEFEIN)
            Dim o_daFPZEFEMO As New SqlParameter("@FPZEFEMO", daFPZEFEMO)
            Dim o_stFPZEMAQU As New SqlParameter("@FPZEMAQU", stFPZEMAQU)

            Dim VecParametros(16) As SqlParameter

            VecParametros(0) = o_inFPZENUFI
            VecParametros(1) = o_inFPZEZOEC
            VecParametros(2) = o_inFPZEPORC
            VecParametros(3) = o_stFPZEDEPA
            VecParametros(4) = o_stFPZEMUNI
            VecParametros(5) = o_inFPZETIRE
            VecParametros(6) = o_inFPZECLSE
            VecParametros(7) = o_inFPZEVIGE
            VecParametros(8) = o_inFPZERESO
            VecParametros(9) = o_inFPZESECU
            VecParametros(10) = o_inFPZENURE
            VecParametros(11) = o_stFPZEESTA
            VecParametros(12) = o_stFPZEUSIN
            VecParametros(13) = o_stFPZEUSMO
            VecParametros(14) = o_daFPZEFEIN
            VecParametros(15) = o_daFPZEFEMO
            VecParametros(16) = o_stFPZEMAQU

            objenq.ActualizarDb(VecParametros, "insertar_FIPRZOEC")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro por ID.
    ''' </summary>
    Public Function fun_Eliminar_FIPRZOEC(ByVal inFPZEIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPZEIDRE As New SqlParameter("@FPZEIDRE", inFPZEIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPZEIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_FIPRZOEC") Then
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
    Public Function fun_Eliminar_FIPRZOEC_X_FICHA_PREDIAL(ByVal inFPZENUFI As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPZENUFI As New SqlParameter("@FPZENUFI", inFPZENUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPZENUFI

            If objenq.ActualizarDb(VecParametros, "eliminar_FIPRZOEC_X_NRO_FICHA_PREDIAL") Then
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
    Public Function fun_Actualizar_FIPRZOEC(ByVal inFPZEIDRE As Integer, _
                                               ByVal inFPZENUFI As Integer, _
                                               ByVal inFPZEZOEC As Integer, _
                                               ByVal inFPZEPORC As Integer, _
                                               ByVal stFPZEDEPA As String, _
                                               ByVal stFPZEMUNI As String, _
                                               ByVal inFPZETIRE As Integer, _
                                               ByVal inFPZECLSE As Integer, _
                                               ByVal inFPZEVIGE As Integer, _
                                               ByVal inFPZERESO As Integer, _
                                               ByVal inFPZESECU As Integer, _
                                               ByVal inFPZENURE As Integer, _
                                               ByVal stFPZEESTA As String, _
                                               ByVal stFPZEUSIN As String, _
                                               ByVal daFPZEFEIN As Date) As Boolean


        Dim stFPZEMAQU As String = fun_Nombre_de_maquina()
        Dim daFPZEFEMO As Date = fun_Hora_y_fecha()

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPZEIDRE As New SqlParameter("@FPZEIDRE", inFPZEIDRE)
            Dim o_inFPZENUFI As New SqlParameter("@FPZENUFI", inFPZENUFI)
            Dim o_inFPZEZOEC As New SqlParameter("@FPZEZOEC", inFPZEZOEC)
            Dim o_inFPZEPORC As New SqlParameter("@FPZEPORC", inFPZEPORC)
            Dim o_stFPZEDEPA As New SqlParameter("@FPZEDEPA", stFPZEDEPA)
            Dim o_stFPZEMUNI As New SqlParameter("@FPZEMUNI", stFPZEMUNI)
            Dim o_inFPZETIRE As New SqlParameter("@FPZETIRE", inFPZETIRE)
            Dim o_inFPZECLSE As New SqlParameter("@FPZECLSE", inFPZECLSE)
            Dim o_inFPZEVIGE As New SqlParameter("@FPZEVIGE", inFPZEVIGE)
            Dim o_inFPZERESO As New SqlParameter("@FPZERESO", inFPZERESO)
            Dim o_inFPZESECU As New SqlParameter("@FPZESECU", inFPZESECU)
            Dim o_inFPZENURE As New SqlParameter("@FPZENURE", inFPZENURE)
            Dim o_stFPZEESTA As New SqlParameter("@FPZEESTA", stFPZEESTA)
            Dim o_stFPZEUSIN As New SqlParameter("@FPZEUSIN", stFPZEUSIN)
            Dim o_stFPZEUSMO As New SqlParameter("@FPZEUSMO", vp_usuario)
            Dim o_daFPZEFEIN As New SqlParameter("@FPZEFEIN", daFPZEFEIN)
            Dim o_daFPZEFEMO As New SqlParameter("@FPZEFEMO", daFPZEFEMO)
            Dim o_stFPZEMAQU As New SqlParameter("@FPZEMAQU", stFPZEMAQU)

            Dim VecParametros(17) As SqlParameter

            VecParametros(0) = o_inFPZEIDRE
            VecParametros(1) = o_inFPZENUFI
            VecParametros(2) = o_inFPZEZOEC
            VecParametros(3) = o_inFPZEPORC
            VecParametros(4) = o_stFPZEDEPA
            VecParametros(5) = o_stFPZEMUNI
            VecParametros(6) = o_inFPZETIRE
            VecParametros(7) = o_inFPZECLSE
            VecParametros(8) = o_inFPZEVIGE
            VecParametros(9) = o_inFPZERESO
            VecParametros(10) = o_inFPZESECU
            VecParametros(11) = o_inFPZENURE
            VecParametros(12) = o_stFPZEESTA
            VecParametros(13) = o_stFPZEUSIN
            VecParametros(14) = o_stFPZEUSMO
            VecParametros(15) = o_daFPZEFEIN
            VecParametros(16) = o_daFPZEFEMO
            VecParametros(17) = o_stFPZEMAQU

            objenq.ActualizarDb(VecParametros, "actualizar_FIPRZOEC")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_FIPRZOEC(ByVal inFPZEIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPZEIDRE As New SqlParameter("@FPZEIDRE", inFPZEIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPZEIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_FIPRZOEC")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_FIPRZOEC(ByVal inFPZENUFI As Integer, _
                                                ByVal inFPZEZOEC As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPZENUFI As New SqlParameter("@FPZENUFI", inFPZENUFI)
            Dim o_inFPZEZOEC As New SqlParameter("@FPZEZOEC", inFPZEZOEC)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_inFPZENUFI
            VecParametros(1) = o_inFPZEZOEC

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_FIPRZOEC")

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
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_FIPRZOEC(ByVal inFPZENUFI As Integer, _
                                                                    ByVal inFPZEZOEC As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPZENUFI As New SqlParameter("@FPZENUFI", inFPZENUFI)
            Dim o_inFPZEZOEC As New SqlParameter("@FPZEZOEC", inFPZEZOEC)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_inFPZENUFI
            VecParametros(1) = o_inFPZEZOEC

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_ID_X_CONSULTA_PARAMETRIZADA_FIPRZOEC")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el EL NUMERO DE SECUENCIA de acuerdo al numero de la ficha predial.
    ''' </summary>
    Public Function fun_Buscar_NRO_SECUENCIA_FIPRZOEC_X_FICHA_PREDIAL(ByVal inFPZENUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPZENUFI As New SqlParameter("@FPZENUFI", inFPZENUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPZENUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_NRO_SECUENCIA_FIPRZOEC_X_FICHA_PREDIAL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que consulta la sumatoria de los porcentajes que se encuantran activos.
    ''' </summary>
    Public Function fun_Consultar_SUMA_X_FPZEPORC_FIPRZOEC(ByVal inFPZENUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPZENUFI As New SqlParameter("@FPZENUFI", inFPZENUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPZENUFI

            Dim SumaDestino As New DataTable
            SumaDestino = objeq.ConsultarDb(VecParametros, "Consultar_SUMA_X_FPZEPORC_FIPRZOEC")

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
    Public Function fun_Consultar_FIPRZOEC_X_FICHA_PREDIAL(ByVal inFPZENUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPZENUFI As New SqlParameter("@FPZENUFI", inFPZENUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPZENUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FIPRZOEC_X_FICHA_PREDIAL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function


End Class
