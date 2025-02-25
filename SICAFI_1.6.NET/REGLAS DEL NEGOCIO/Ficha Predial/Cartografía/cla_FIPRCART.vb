Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_FIPRCART

    '=========================
    '*** CLASE CARTOGRAFIA ***
    '=========================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_FIPRCART(ByVal inFPCANUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPCANUFI As New SqlParameter("@FPCANUFI", inFPCANUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPCANUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FIPRCART")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_FIPRCART(ByVal inFPCANUFI As Integer, _
                                          ByVal stFPCAPLAN As String, _
                                          ByVal stFPCAVENT As String, _
                                          ByVal stFPCAESGR As String, _
                                          ByVal inFPCAVIGR As Integer, _
                                          ByVal stFPCAVUEL As String, _
                                          ByVal stFPCAFAJA As String, _
                                          ByVal stFPCAFOTO As String, _
                                          ByVal inFPCAVIAE As Integer, _
                                          ByVal stFPCAAMPL As String, _
                                          ByVal stFPCAESAE As String, _
                                          ByVal stFPCADEPA As String, _
                                          ByVal stFPCAMUNI As String, _
                                          ByVal inFPCATIRE As Integer, _
                                          ByVal inFPCACLSE As Integer, _
                                          ByVal inFPCAVIGE As Integer, _
                                          ByVal inFPCARESO As Integer, _
                                          ByVal inFPCASECU As Integer, _
                                          ByVal inFPCANURE As Integer, _
                                          ByVal stFPCAESTA As String) As Boolean

        ''*** INSTANCIA QUE IDENTIFICA EL NOMBRE DE LA MAQUINA ***
        Dim stFPCAMAQU As String = fun_Nombre_de_maquina()

        '' *** INSTANCIA LA FECHA Y HORA ***
        Dim daFPCAFEIN As Date = fun_Hora_y_fecha()
        Dim daFPCAFEMO As Date = fun_Hora_y_fecha()

        '' *** USUARIO QUE MODIFICA ***
        Dim stFPCAUSMO As String = ""

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPCANUFI As New SqlParameter("@FPCANUFI", inFPCANUFI)
            Dim o_stFPCAPLAN As New SqlParameter("@FPCAPLAN", stFPCAPLAN)
            Dim o_stFPCAVENT As New SqlParameter("@FPCAVENT", stFPCAVENT)
            Dim o_stFPCAESGR As New SqlParameter("@FPCAESGR", stFPCAESGR)
            Dim o_inFPCAVIGR As New SqlParameter("@FPCAVIGR", inFPCAVIGR)
            Dim o_stFPCAVUEL As New SqlParameter("@FPCAVUEL", stFPCAVUEL)
            Dim o_stFPCAFAJA As New SqlParameter("@FPCAFAJA", stFPCAFAJA)
            Dim o_stFPCAFOTO As New SqlParameter("@FPCAFOTO", stFPCAFOTO)
            Dim o_inFPCAVIAE As New SqlParameter("@FPCAVIAE", inFPCAVIAE)
            Dim o_stFPCAAMPL As New SqlParameter("@FPCAAMPL", stFPCAAMPL)
            Dim o_stFPCAESAE As New SqlParameter("@FPCAESAE", stFPCAESAE)
            Dim o_stFPCADEPA As New SqlParameter("@FPCADEPA", stFPCADEPA)
            Dim o_stFPCAMUNI As New SqlParameter("@FPCAMUNI", stFPCAMUNI)
            Dim o_inFPCATIRE As New SqlParameter("@FPCATIRE", inFPCATIRE)
            Dim o_inFPCACLSE As New SqlParameter("@FPCACLSE", inFPCACLSE)
            Dim o_inFPCAVIGE As New SqlParameter("@FPCAVIGE", inFPCAVIGE)
            Dim o_inFPCARESO As New SqlParameter("@FPCARESO", inFPCARESO)
            Dim o_inFPCASECU As New SqlParameter("@FPCASECU", inFPCASECU)
            Dim o_inFPCANURE As New SqlParameter("@FPCANURE", inFPCANURE)
            Dim o_stFPCAESTA As New SqlParameter("@FPCAESTA", stFPCAESTA)
            Dim o_stFPCAUSIN As New SqlParameter("@FPCAUSIN", vp_usuario)
            Dim o_stFPCAUSMO As New SqlParameter("@FPCAUSMO", stFPCAUSMO)
            Dim o_daFPCAFEIN As New SqlParameter("@FPCAFEIN", daFPCAFEIN)
            Dim o_daFPCAFEMO As New SqlParameter("@FPCAFEMO", daFPCAFEMO)
            Dim o_stFPCAMAQU As New SqlParameter("@FPCAMAQU", stFPCAMAQU)

            Dim VecParametros(24) As SqlParameter

            VecParametros(0) = o_inFPCANUFI
            VecParametros(1) = o_stFPCAPLAN
            VecParametros(2) = o_stFPCAVENT
            VecParametros(3) = o_stFPCAESGR
            VecParametros(4) = o_inFPCAVIGR
            VecParametros(5) = o_stFPCAVUEL
            VecParametros(6) = o_stFPCAFAJA
            VecParametros(7) = o_stFPCAFOTO
            VecParametros(8) = o_inFPCAVIAE
            VecParametros(9) = o_stFPCAAMPL
            VecParametros(10) = o_stFPCAESAE
            VecParametros(11) = o_stFPCADEPA
            VecParametros(12) = o_stFPCAMUNI
            VecParametros(13) = o_inFPCATIRE
            VecParametros(14) = o_inFPCACLSE
            VecParametros(15) = o_inFPCAVIGE
            VecParametros(16) = o_inFPCARESO
            VecParametros(17) = o_inFPCASECU
            VecParametros(18) = o_inFPCANURE
            VecParametros(19) = o_stFPCAESTA
            VecParametros(20) = o_stFPCAUSIN
            VecParametros(21) = o_stFPCAUSMO
            VecParametros(22) = o_daFPCAFEIN
            VecParametros(23) = o_daFPCAFEMO
            VecParametros(24) = o_stFPCAMAQU

            objenq.ActualizarDb(VecParametros, "insertar_FIPRCART")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_FIPRCART(ByVal inFPCAIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPCAIDRE As New SqlParameter("@FPCAIDRE", inFPCAIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPCAIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_FIPRCART") Then
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
    Public Function fun_Actualizar_FIPRCART(ByVal inFPCAIDRE As Integer, _
                                            ByVal inFPCANUFI As Integer, _
                                            ByVal stFPCAPLAN As String, _
                                            ByVal stFPCAVENT As String, _
                                            ByVal stFPCAESGR As String, _
                                            ByVal inFPCAVIGR As Integer, _
                                            ByVal stFPCAVUEL As String, _
                                            ByVal stFPCAFAJA As String, _
                                            ByVal stFPCAFOTO As String, _
                                            ByVal inFPCAVIAE As Integer, _
                                            ByVal stFPCAAMPL As String, _
                                            ByVal stFPCAESAE As String, _
                                            ByVal stFPCADEPA As String, _
                                            ByVal stFPCAMUNI As String, _
                                            ByVal inFPCATIRE As Integer, _
                                            ByVal inFPCACLSE As Integer, _
                                            ByVal inFPCAVIGE As Integer, _
                                            ByVal inFPCARESO As Integer, _
                                            ByVal inFPCASECU As Integer, _
                                            ByVal inFPCANURE As Integer, _
                                            ByVal stFPCAESTA As String, _
                                            ByVal stFPCAUSIN As String, _
                                            ByVal daFPCAFEIN As Date) As Boolean


        Dim stFPCAMAQU As String = fun_Nombre_de_maquina()
        Dim daFPCAFEMO As Date = fun_Hora_y_fecha()

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inFPCAIDRE As New SqlParameter("@FPCAIDRE", inFPCAIDRE)
            Dim o_inFPCANUFI As New SqlParameter("@FPCANUFI", inFPCANUFI)
            Dim o_stFPCAPLAN As New SqlParameter("@FPCAPLAN", stFPCAPLAN)
            Dim o_stFPCAVENT As New SqlParameter("@FPCAVENT", stFPCAVENT)
            Dim o_stFPCAESGR As New SqlParameter("@FPCAESGR", stFPCAESGR)
            Dim o_inFPCAVIGR As New SqlParameter("@FPCAVIGR", inFPCAVIGR)
            Dim o_stFPCAVUEL As New SqlParameter("@FPCAVUEL", stFPCAVUEL)
            Dim o_stFPCAFAJA As New SqlParameter("@FPCAFAJA", stFPCAFAJA)
            Dim o_stFPCAFOTO As New SqlParameter("@FPCAFOTO", stFPCAFOTO)
            Dim o_inFPCAVIAE As New SqlParameter("@FPCAVIAE", inFPCAVIAE)
            Dim o_stFPCAAMPL As New SqlParameter("@FPCAAMPL", stFPCAAMPL)
            Dim o_stFPCAESAE As New SqlParameter("@FPCAESAE", stFPCAESAE)
            Dim o_stFPCADEPA As New SqlParameter("@FPCADEPA", stFPCADEPA)
            Dim o_stFPCAMUNI As New SqlParameter("@FPCAMUNI", stFPCAMUNI)
            Dim o_inFPCATIRE As New SqlParameter("@FPCATIRE", inFPCATIRE)
            Dim o_inFPCACLSE As New SqlParameter("@FPCACLSE", inFPCACLSE)
            Dim o_inFPCAVIGE As New SqlParameter("@FPCAVIGE", inFPCAVIGE)
            Dim o_inFPCARESO As New SqlParameter("@FPCARESO", inFPCARESO)
            Dim o_inFPCASECU As New SqlParameter("@FPCASECU", inFPCASECU)
            Dim o_inFPCANURE As New SqlParameter("@FPCANURE", inFPCANURE)
            Dim o_stFPCAESTA As New SqlParameter("@FPCAESTA", stFPCAESTA)
            Dim o_stFPCAUSIN As New SqlParameter("@FPCAUSIN", stFPCAUSIN)
            Dim o_stFPCAUSMO As New SqlParameter("@FPCAUSMO", vp_usuario)
            Dim o_daFPCAFEIN As New SqlParameter("@FPCAFEIN", daFPCAFEIN)
            Dim o_daFPCAFEMO As New SqlParameter("@FPCAFEMO", daFPCAFEMO)
            Dim o_stFPCAMAQU As New SqlParameter("@FPCAMAQU", stFPCAMAQU)

            Dim VecParametros(25) As SqlParameter

            VecParametros(0) = o_inFPCAIDRE
            VecParametros(1) = o_inFPCANUFI
            VecParametros(2) = o_stFPCAPLAN
            VecParametros(3) = o_stFPCAVENT
            VecParametros(4) = o_stFPCAESGR
            VecParametros(5) = o_inFPCAVIGR
            VecParametros(6) = o_stFPCAVUEL
            VecParametros(7) = o_stFPCAFAJA
            VecParametros(8) = o_stFPCAFOTO
            VecParametros(9) = o_inFPCAVIAE
            VecParametros(10) = o_stFPCAAMPL
            VecParametros(11) = o_stFPCAESAE
            VecParametros(12) = o_stFPCADEPA
            VecParametros(13) = o_stFPCAMUNI
            VecParametros(14) = o_inFPCATIRE
            VecParametros(15) = o_inFPCACLSE
            VecParametros(16) = o_inFPCAVIGE
            VecParametros(17) = o_inFPCARESO
            VecParametros(18) = o_inFPCASECU
            VecParametros(19) = o_inFPCANURE
            VecParametros(20) = o_stFPCAESTA
            VecParametros(21) = o_stFPCAUSIN
            VecParametros(22) = o_stFPCAUSMO
            VecParametros(23) = o_daFPCAFEIN
            VecParametros(24) = o_daFPCAFEMO
            VecParametros(25) = o_stFPCAMAQU

            objenq.ActualizarDb(VecParametros, "actualizar_FIPRCART")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_FIPRCART(ByVal inFPCAIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPCAIDRE As New SqlParameter("@FPCAIDRE", inFPCAIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPCAIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_FIPRCART")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el EL NUMERO DE SECUENCIA de acuerdo al numero de la ficha predial.
    ''' </summary>
    Public Function fun_Buscar_NRO_SECUENCIA_FIPRCART_X_FICHA_PREDIAL(ByVal inFPCANUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPCANUFI As New SqlParameter("@FPCANUFI", inFPCANUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPCANUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_NRO_SECUENCIA_FIPRCART_X_FICHA_PREDIAL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Consulta todos los campos de la cartografia por ficha predial para llenar los
    ''' campos del formulario ficha predial
    ''' </summary>
    Public Function fun_Consultar_FIPRCART_X_FICHA_PREDIAL(ByVal inFPCANUFI As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inFPCANUFI As New SqlParameter("@FPCANUFI", inFPCANUFI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inFPCANUFI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Consultar_FIPRCART_X_FICHA_PREDIAL")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_NUFI_FIPRCART(ByVal inFPCANUFI As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "FIPRCART "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPCANUFI = '" & CInt(inFPCANUFI) & "' "

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
    ''' Función que Elimina el registro por numero de ficha predial.
    ''' </summary>
    Public Function fun_Eliminar_FIPRCART_X_FICHA_PREDIAL(ByVal inFPCANUFI As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "FIPRCART "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "FPCANUFI = '" & CInt(inFPCANUFI) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_FIPRCART_X_FICHA_PREDIAL")
        End Try

    End Function


   
End Class
