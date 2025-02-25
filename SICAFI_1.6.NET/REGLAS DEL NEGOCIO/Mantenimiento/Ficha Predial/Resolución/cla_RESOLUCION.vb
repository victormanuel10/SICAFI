Imports SYSTEM.Security.Principal
Imports SYSTEM.Security.Permissions
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_RESOLUCION

    '========================
    '*** CLASE RESOLUCIÓN ***
    '========================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_RANGARTE(ByVal obRESODEPA As Object, _
                                                         ByVal obRESOMUNI As Object, _
                                                         ByVal obRESOCLSE As Object, _
                                                         ByVal obRESOTIRE As Object, _
                                                         ByVal obRESOVIGE As Object, _
                                                         ByVal obRESOCODI As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obRESODEPA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRESOMUNI.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRESOCLSE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRESOTIRE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRESOVIGE.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obRESOCODI.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obRESODEPA.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRESOMUNI.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRESOCLSE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRESOTIRE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRESOVIGE.SelectedValue) = True And _
                   obVerifica.fun_Verificar_Dato_Numerico(obRESOCODI.Text) = True Then

                    Dim objdatos1 As New cla_RESOLUCION
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_TIPO_Y_CLASE_Y_VIGENCIA_Y_CODIGO_RESOLUCION(obRESODEPA.SelectedValue, _
                                                                                                                    obRESOMUNI.SelectedValue, _
                                                                                                                    obRESOTIRE.SelectedValue, _
                                                                                                                    obRESOCLSE.SelectedValue, _
                                                                                                                    obRESOVIGE.SelectedValue, _
                                                                                                                    obRESOCODI.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & Trim(obRESODEPA.Text) & " - " & _
                                                     Trim(obRESOMUNI.Text) & " - " & _
                                                     Trim(obRESOTIRE.Text) & " - " & _
                                                     Trim(obRESOCLSE.Text) & " - " & _
                                                     Trim(obRESOVIGE.Text) & " - " & _
                                                     Trim(obRESOCODI.Text) & " - " & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obRESODEPA.Focus()
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
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_RESOLUCION() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RESOIDRE, "
            stConsultaSQL += "RESODEPA, "
            stConsultaSQL += "DEPADESC, "
            stConsultaSQL += "RESOMUNI, "
            stConsultaSQL += "MUNIDESC, "
            stConsultaSQL += "RESOTIRE, "
            stConsultaSQL += "TIREDESC, "
            stConsultaSQL += "RESOCLSE, "
            stConsultaSQL += "CLSEDESC, "
            stConsultaSQL += "RESOVIGE, "
            stConsultaSQL += "VIGEDESC, "
            stConsultaSQL += "RESOCODI, "
            stConsultaSQL += "RESODESC, "
            stConsultaSQL += "RESONURE, "
            stConsultaSQL += "RESOARTE, "
            stConsultaSQL += "RESOARCO, "
            stConsultaSQL += "RESOPUNT, "
            stConsultaSQL += "RESOTOPA, "
            stConsultaSQL += "RESORESO, "
            stConsultaSQL += "RESOESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOLUCION, "
            stConsultaSQL += "MANT_DEPARTAMENTO, "
            stConsultaSQL += "MANT_MUNICIPIO, "
            stConsultaSQL += "MANT_CLASSECT, "
            stConsultaSQL += "MANT_TIPORESO, "
            stConsultaSQL += "VIGENCIA, "
            stConsultaSQL += "ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "DEPACODI = RESODEPA AND "
            stConsultaSQL += "MUNIDEPA = RESODEPA AND "
            stConsultaSQL += "MUNICODI = RESOMUNI AND "
            stConsultaSQL += "CLSECODI = RESOCLSE AND "
            stConsultaSQL += "TIRECODI = RESOTIRE AND "
            stConsultaSQL += "VIGECODI = RESOVIGE AND "
            stConsultaSQL += "ESTACODI = RESOESTA "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RESODEPA,RESOMUNI,RESOTIRE,RESOCLSE,RESOVIGE,RESOCODI "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_RANGARTE")
            Return Nothing
        End Try

    End Function

    '''   <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_RESOLUCION() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_RESOLUCION")

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Funcion que busca el campo de la notaria en estado activo 
    ''' (Solo debuelve el campo de la notaria)
    ''' </summary>
    Public Function fun_Consultar_RESOLUCION_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_RESOLUCION_X_ESTADO")

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_RESOLUCION(ByVal stRESODEPA As String, _
                                              ByVal stRESOMUNI As String, _
                                              ByVal inRESOTIRE As Integer, _
                                              ByVal inRESOCLSE As Integer, _
                                              ByVal inRESOVIGE As Integer, _
                                              ByVal inRESOCODI As Integer, _
                                              ByVal stRESODESC As String, _
                                              ByVal boRESOTOPA As Boolean, _
                                              ByVal stRESOESTA As String, _
                                              ByVal stRESOCONT As String) As Boolean


        '*** INSTANCIA QUE IDENTIFICA EL NOMBRE DE LA MAQUINA ***
        Dim MyIdentity As WindowsIdentity = WindowsIdentity.GetCurrent()
        Dim MyPrincipal As New WindowsPrincipal(MyIdentity)

        Dim stRESOMAQU As String = MyPrincipal.Identity.Name

        ' *** INSTANCIA LA FECHA Y HORA ***
        Dim dateNow As DateTime = DateTime.Now

        Dim stRESOUSMO As String = ""
        Dim daRESOFEIN As Date = DateTime.Now.ToString()    'Fecha y hora
        Dim daRESOFEMO As Date = DateTime.Now.ToString()    'Fecha y hora

        Dim inRESONURE As Integer = 0
        Dim doRESOARTE As Double = 0.0
        Dim doRESOARCO As Double = 0.0
        Dim inRESOPUNT As Integer = 0

        Dim stRESODEPA_CODI As String = Trim(stRESODEPA)
        Dim stRESOMUNI_CODI As String = Trim(stRESOMUNI)
        Dim stRESOTIRE_CODI As String = inRESOTIRE
        Dim stRESOCLSE_CODI As String = inRESOCLSE
        Dim stRESOVIGE_CODI As String = inRESOVIGE
        Dim stRESORESO_CODI As String = inRESOCODI

        stRESODEPA_CODI = stRESODEPA_CODI.PadLeft(2, "0")
        stRESODEPA_CODI = stRESODEPA_CODI.Substring(0, 2)

        stRESOMUNI_CODI = stRESOMUNI_CODI.PadLeft(3, "0")
        stRESOMUNI_CODI = stRESOMUNI_CODI.Substring(0, 3)

        stRESOTIRE_CODI = stRESOTIRE_CODI.PadLeft(3, "0")
        stRESOTIRE_CODI = stRESOTIRE_CODI.Substring(0, 3)

        stRESOCLSE_CODI = stRESOCLSE_CODI.PadLeft(1, "0")
        stRESOCLSE_CODI = stRESOCLSE_CODI.Substring(0, 1)

        stRESOVIGE_CODI = stRESOVIGE_CODI.PadLeft(4, "0")
        stRESOVIGE_CODI = stRESOVIGE_CODI.Substring(0, 4)

        stRESORESO_CODI = stRESORESO_CODI.PadLeft(7, "0")
        stRESORESO_CODI = stRESORESO_CODI.Substring(0, 7)

        Dim stRESORESO As String = stRESODEPA_CODI & stRESOMUNI_CODI & stRESOTIRE_CODI & stRESOCLSE_CODI & stRESOVIGE_CODI & stRESORESO_CODI

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stRESODEPA As New SqlParameter("@RESODEPA", stRESODEPA)
            Dim o_stRESOMUNI As New SqlParameter("@RESOMUNI", stRESOMUNI)
            Dim o_inRESOTIRE As New SqlParameter("@RESOTIRE", inRESOTIRE)
            Dim o_inRESOCLSE As New SqlParameter("@RESOCLSE", inRESOCLSE)
            Dim o_inRESOVIGE As New SqlParameter("@RESOVIGE", inRESOVIGE)
            Dim o_inRESOCODI As New SqlParameter("@RESOCODI", inRESOCODI)
            Dim o_stRESODESC As New SqlParameter("@RESODESC", stRESODESC)
            Dim o_inRESONURE As New SqlParameter("@RESONURE", inRESONURE)
            Dim o_doRESOARTE As New SqlParameter("@RESOARTE", doRESOARTE)
            Dim o_doRESOARCO As New SqlParameter("@RESOARCO", doRESOARCO)
            Dim o_inRESOPUNT As New SqlParameter("@RESOPUNT", inRESOPUNT)
            Dim o_boRESOTOPA As New SqlParameter("@RESOTOPA", boRESOTOPA)
            Dim o_stRESOESTA As New SqlParameter("@RESOESTA", stRESOESTA)
            Dim o_stRESOUSIN As New SqlParameter("@RESOUSIN", vp_usuario)
            Dim o_stRESOUSMO As New SqlParameter("@RESOUSMO", stRESOUSMO)
            Dim o_daRESOFEIN As New SqlParameter("@RESOFEIN", daRESOFEIN)
            Dim o_daRESOFEMO As New SqlParameter("@RESOFEMO", daRESOFEMO)
            Dim o_stRESOMAQU As New SqlParameter("@RESOMAQU", stRESOMAQU)
            Dim o_stRESORESO As New SqlParameter("@RESORESO", stRESORESO)
            Dim o_stRESOCONT As New SqlParameter("@RESOCONT", stRESOCONT)

            Dim VecParametros(19) As SqlParameter

            VecParametros(0) = o_stRESODEPA
            VecParametros(1) = o_stRESOMUNI
            VecParametros(2) = o_inRESOTIRE
            VecParametros(3) = o_inRESOCLSE
            VecParametros(4) = o_inRESOVIGE
            VecParametros(5) = o_inRESOCODI
            VecParametros(6) = o_stRESODESC
            VecParametros(7) = o_inRESONURE
            VecParametros(8) = o_doRESOARTE
            VecParametros(9) = o_doRESOARCO
            VecParametros(10) = o_inRESOPUNT
            VecParametros(11) = o_boRESOTOPA
            VecParametros(12) = o_stRESOESTA
            VecParametros(13) = o_stRESOUSIN
            VecParametros(14) = o_stRESOUSMO
            VecParametros(15) = o_daRESOFEIN
            VecParametros(16) = o_daRESOFEMO
            VecParametros(17) = o_stRESOMAQU
            VecParametros(18) = o_stRESORESO
            VecParametros(19) = o_stRESOCONT

            objenq.ActualizarDb(VecParametros, "insertar_RESOLUCION")

            Return True

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_RESOLUCION(ByVal inRESOIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inNOTAIDRE As New SqlParameter("@RESOIDRE", inRESOIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inNOTAIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_RESOLUCION") Then
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
    Public Function fun_Actualizar_RESOLUCION(ByVal inRESOIDRE As Integer, _
                                              ByVal stRESODEPA As String, _
                                              ByVal stRESOMUNI As String, _
                                              ByVal inRESOTIRE As Integer, _
                                              ByVal inRESOCLSE As Integer, _
                                              ByVal inRESOVIGE As Integer, _
                                              ByVal inRESOCODI As Integer, _
                                              ByVal stRESODESC As String, _
                                              ByVal inRESONURE As Integer, _
                                              ByVal doRESOARTE As Double, _
                                              ByVal doRESOARCO As Double, _
                                              ByVal inRESOPUNT As Integer, _
                                              ByVal boRESOTOPA As Boolean, _
                                              ByVal stRESOESTA As String, _
                                              ByVal stRESOUSIN As String, _
                                              ByVal daRESOFEIN As Date, _
                                              ByVal stRESORESO As String, _
                                              ByVal stRESOCONT As String) As Boolean

        '*** INSTANCIA QUE IDENTIFICA EL NOMBRE DE LA MAQUINA ***
        Dim MyIdentity As WindowsIdentity = WindowsIdentity.GetCurrent()
        Dim MyPrincipal As New WindowsPrincipal(MyIdentity)

        Dim stRESOMAQU As String = MyPrincipal.Identity.Name

        ' *** INSTANCIA LA FECHA Y HORA ***
        Dim dateNow As DateTime = DateTime.Now

        Dim daRESOFEMO As Date = DateTime.Now.ToString()    'Fecha y hora

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inRESOIDRE As New SqlParameter("@RESOIDRE", inRESOIDRE)
            Dim o_stRESODEPA As New SqlParameter("@RESODEPA", stRESODEPA)
            Dim o_stRESOMUNI As New SqlParameter("@RESOMUNI", stRESOMUNI)
            Dim o_inRESOTIRE As New SqlParameter("@RESOTIRE", inRESOTIRE)
            Dim o_inRESOCLSE As New SqlParameter("@RESOCLSE", inRESOCLSE)
            Dim o_inRESOVIGE As New SqlParameter("@RESOVIGE", inRESOVIGE)
            Dim o_inRESOCODI As New SqlParameter("@RESOCODI", inRESOCODI)
            Dim o_stRESODESC As New SqlParameter("@RESODESC", stRESODESC)
            Dim o_inRESONURE As New SqlParameter("@RESONURE", inRESONURE)
            Dim o_doRESOARTE As New SqlParameter("@RESOARTE", doRESOARTE)
            Dim o_doRESOARCO As New SqlParameter("@RESOARCO", doRESOARCO)
            Dim o_inRESOPUNT As New SqlParameter("@RESOPUNT", inRESOPUNT)
            Dim o_boRESOTOPA As New SqlParameter("@RESOTOPA", boRESOTOPA)
            Dim o_stRESOESTA As New SqlParameter("@RESOESTA", stRESOESTA)
            Dim o_stRESOUSIN As New SqlParameter("@RESOUSIN", stRESOUSIN)
            Dim o_stRESOUSMO As New SqlParameter("@RESOUSMO", vp_usuario)
            Dim o_daRESOFEIN As New SqlParameter("@RESOFEIN", daRESOFEIN)
            Dim o_daRESOFEMO As New SqlParameter("@RESOFEMO", daRESOFEMO)
            Dim o_stRESOMAQU As New SqlParameter("@RESOMAQU", stRESOMAQU)
            Dim o_stRESORESO As New SqlParameter("@RESORESO", stRESORESO)
            Dim o_stRESOCONT As New SqlParameter("@RESOCONT", stRESOCONT)

            Dim VecParametros(20) As SqlParameter

            VecParametros(0) = o_inRESOIDRE
            VecParametros(1) = o_stRESODEPA
            VecParametros(2) = o_stRESOMUNI
            VecParametros(3) = o_inRESOTIRE
            VecParametros(4) = o_inRESOCLSE
            VecParametros(5) = o_inRESOVIGE
            VecParametros(6) = o_inRESOCODI
            VecParametros(7) = o_stRESODESC
            VecParametros(8) = o_inRESONURE
            VecParametros(9) = o_doRESOARTE
            VecParametros(10) = o_doRESOARCO
            VecParametros(11) = o_inRESOPUNT
            VecParametros(12) = o_boRESOTOPA
            VecParametros(13) = o_stRESOESTA
            VecParametros(14) = o_stRESOUSIN
            VecParametros(15) = o_stRESOUSMO
            VecParametros(16) = o_daRESOFEIN
            VecParametros(17) = o_daRESOFEMO
            VecParametros(18) = o_stRESOMAQU
            VecParametros(19) = o_stRESORESO
            VecParametros(20) = o_stRESOCONT

            objenq.ActualizarDb(VecParametros, "actualizar_RESOLUCION")

            Return True

        Catch ex As Exception
            Return False
            MessageBox.Show(Err.Description)
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_RESOLUCION(ByVal inRESOIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inRESOIDRE As New SqlParameter("@RESOIDRE", inRESOIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inRESOIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_RESOLUCION")

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO del registro para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_RESOLUCION(ByVal inRESORESO As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inRESORESO As New SqlParameter("RESORESO", inRESORESO)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inRESORESO

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_RESOLUCION")

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el DEPARTAMENTO, MUNICIPIO Y CÓDIGO DE NOTARIA para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_TIPO_Y_CLASE_Y_VIGENCIA_Y_CODIGO_RESOLUCION(ByVal stRESODEPA As String, _
                                                                              ByVal stRESOMUNI As String, _
                                                                              ByVal inRESOTIRE As Integer, _
                                                                              ByVal inRESOCLSE As Integer, _
                                                                              ByVal inRESOVIGE As Integer, _
                                                                              ByVal inRESOCODI As Integer) As DataTable
        Try

            Dim objeq As New cExecuteQuery

            Dim o_stRESODEPA As New SqlParameter("@RESODEPA", stRESODEPA)
            Dim o_stRESOMUNI As New SqlParameter("@RESOMUNI", stRESOMUNI)
            Dim o_inRESOTIRE As New SqlParameter("@RESOTIRE", inRESOTIRE)
            Dim o_inRESOCLSE As New SqlParameter("@RESOCLSE", inRESOCLSE)
            Dim o_inRESOVIGE As New SqlParameter("@RESOVIGE", inRESOVIGE)
            Dim o_inRESOCODI As New SqlParameter("@RESOCODI", inRESOCODI)


            Dim VecParametros(5) As SqlParameter

            VecParametros(0) = o_stRESODEPA
            VecParametros(1) = o_stRESOMUNI
            VecParametros(2) = o_inRESOTIRE
            VecParametros(3) = o_inRESOCLSE
            VecParametros(4) = o_inRESOVIGE
            VecParametros(5) = o_inRESOCODI


            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "Buscar_DEPARTAMENTO_Y_MUNICIPIO_TIPO_Y_CLASE_Y_VIGENCIA_Y_CODIGO_RESOLUCION")

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el DEPARTAMENTO, MUNICIPIO Y CÓDIGO DE NOTARIA para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_TIPO_Y_CLASE_Y_VIGENCIA_Y_RESOLUCION(ByVal inRESORESO As Integer, _
                                                                    ByVal inRESOTIRE As Integer, _
                                                                    ByVal inRESOCLSE As Integer, _
                                                                    ByVal inRESOVIGE As Integer) As DataTable
        Try

          ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' PROCatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "RESOLUCION "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RESOCODI = '" & CInt(inRESORESO) & "' AND "
            stConsultaSQL += "RESOTIRE = '" & CInt(inRESOTIRE) & "' AND "
            stConsultaSQL += "RESOCLSE = '" & CInt(inRESOCLSE) & "' AND "
            stConsultaSQL += "RESOVIGE = '" & CInt(inRESOVIGE) & "' "

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

End Class
