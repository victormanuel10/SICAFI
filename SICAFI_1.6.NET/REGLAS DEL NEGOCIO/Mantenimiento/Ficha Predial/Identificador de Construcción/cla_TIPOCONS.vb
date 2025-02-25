Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_TIPOCONS

    '==================================
    '*** CLASE TIPO DE CONSTRUCCIÓN ***
    '==================================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_TIPOCONS() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_TIPOCONS")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    '''   <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_TIPOCONS() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_MANT_TIPOCONS")

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
    Public Function fun_Consultar_MANT_TIPOCONS_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_TIPOCONS_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try
      
    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_TIPOCONS(ByVal stTICODEPA As String, _
                                                ByVal stTICOMUNI As String, _
                                                ByVal inTICOCLCO As Integer, _
                                                ByVal stTICOTIPO As String, _
                                                ByVal stTICOCODI As String, _
                                                ByVal stTICODESC As String, _
                                                ByVal inTICOPUNT As Integer, _
                                                ByVal inTICOPUMA As Integer, _
                                                ByVal doTICOFAC1 As Double, _
                                                ByVal doTICOFAC2 As Double, _
                                                ByVal stTICOMOLI As String, _
                                                ByVal boTICOARCO As Boolean, _
                                                ByVal stTICOESTA As String, _
                                                ByVal inTICOCLSE As Integer, _
                                                ByVal stTICOPOIN As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stTICODEPA As New SqlParameter("@TICODEPA", stTICODEPA)
            Dim o_stTICOMUNI As New SqlParameter("@TICOMUNI", stTICOMUNI)
            Dim o_inTICOCLCO As New SqlParameter("@TICOCLCO", inTICOCLCO)
            Dim o_stTICOTIPO As New SqlParameter("@TICOTIPO", stTICOTIPO)
            Dim o_stTICOCODI As New SqlParameter("@TICOCODI", stTICOCODI)
            Dim o_stTICODESC As New SqlParameter("@TICODESC", stTICODESC)
            Dim o_inTICOPUNT As New SqlParameter("@TICOPUNT", inTICOPUNT)
            Dim o_inTICOPUMA As New SqlParameter("@TICOPUMA", inTICOPUMA)
            Dim o_doTICOFAC1 As New SqlParameter("@TICOFAC1", doTICOFAC1)
            Dim o_doTICOFAC2 As New SqlParameter("@TICOFAC2", doTICOFAC2)
            Dim o_stTICOMOLI As New SqlParameter("@TICOMOLI", stTICOMOLI)
            Dim o_boTICOARCO As New SqlParameter("@TICOARCO", boTICOARCO)
            Dim o_stTICOESTA As New SqlParameter("@TICOESTA", stTICOESTA)
            Dim o_inTICOCLSE As New SqlParameter("@TICOCLSE", inTICOCLSE)
            Dim o_stTICOPOIN As New SqlParameter("@TICOPOIN", stTICOPOIN)

            Dim VecParametros(14) As SqlParameter

            VecParametros(0) = o_stTICODEPA
            VecParametros(1) = o_stTICOMUNI
            VecParametros(2) = o_inTICOCLCO
            VecParametros(3) = o_stTICOTIPO
            VecParametros(4) = o_stTICOCODI
            VecParametros(5) = o_stTICODESC
            VecParametros(6) = o_inTICOPUNT
            VecParametros(7) = o_inTICOPUMA
            VecParametros(8) = o_doTICOFAC1
            VecParametros(9) = o_doTICOFAC2
            VecParametros(10) = o_stTICOMOLI
            VecParametros(11) = o_boTICOARCO
            VecParametros(12) = o_stTICOESTA
            VecParametros(13) = o_inTICOCLSE
            VecParametros(14) = o_stTICOPOIN

            objenq.ActualizarDb(VecParametros, "insertar_MANT_TIPOCONS")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_TIPOCONS(ByVal inTICOIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inTICOIDRE As New SqlParameter("@TICOIDRE", inTICOIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inTICOIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_MANT_TIPOCONS") Then
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
    Public Function fun_Actualizar_MANT_TIPOCONS(ByVal inTICOIDRE As Integer, _
                                                ByVal stTICODEPA As String, _
                                                ByVal stTICOMUNI As String, _
                                                ByVal inTICOCLCO As Integer, _
                                                ByVal stTICOTIPO As String, _
                                                ByVal stTICOCODI As String, _
                                                ByVal stTICODESC As String, _
                                                ByVal inTICOPUNT As Integer, _
                                                ByVal inTICOPUMA As Integer, _
                                                ByVal doTICOFAC1 As Double, _
                                                ByVal doTICOFAC2 As Double, _
                                                ByVal stTICOMOLI As String, _
                                                ByVal boTICOARCO As Boolean, _
                                                ByVal stTICOESTA As String, _
                                                ByVal inTICOCLSE As Integer, _
                                                ByVal stTICOPOIN As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inTICOIDRE As New SqlParameter("@TICOIDRE", inTICOIDRE)
            Dim o_stTICODEPA As New SqlParameter("@TICODEPA", stTICODEPA)
            Dim o_stTICOMUNI As New SqlParameter("@TICOMUNI", stTICOMUNI)
            Dim o_inTICOCLCO As New SqlParameter("@TICOCLCO", inTICOCLCO)
            Dim o_stTICOTIPO As New SqlParameter("@TICOTIPO", stTICOTIPO)
            Dim o_stTICOCODI As New SqlParameter("@TICOCODI", stTICOCODI)
            Dim o_stTICODESC As New SqlParameter("@TICODESC", stTICODESC)
            Dim o_inTICOPUNT As New SqlParameter("@TICOPUNT", inTICOPUNT)
            Dim o_inTICOPUMA As New SqlParameter("@TICOPUMA", inTICOPUMA)
            Dim o_doTICOFAC1 As New SqlParameter("@TICOFAC1", doTICOFAC1)
            Dim o_doTICOFAC2 As New SqlParameter("@TICOFAC2", doTICOFAC2)
            Dim o_stTICOMOLI As New SqlParameter("@TICOMOLI", stTICOMOLI)
            Dim o_boTICOARCO As New SqlParameter("@TICOARCO", boTICOARCO)
            Dim o_stTICOESTA As New SqlParameter("@TICOESTA", stTICOESTA)
            Dim o_inTICOCLSE As New SqlParameter("@TICOCLSE", inTICOCLSE)
            Dim o_stTICOPOIN As New SqlParameter("@TICOPOIN", stTICOPOIN)

            Dim VecParametros(15) As SqlParameter

            VecParametros(0) = o_inTICOIDRE
            VecParametros(1) = o_stTICODEPA
            VecParametros(2) = o_stTICOMUNI
            VecParametros(3) = o_inTICOCLCO
            VecParametros(4) = o_stTICOTIPO
            VecParametros(5) = o_stTICOCODI
            VecParametros(6) = o_stTICODESC
            VecParametros(7) = o_inTICOPUNT
            VecParametros(8) = o_inTICOPUMA
            VecParametros(9) = o_doTICOFAC1
            VecParametros(10) = o_doTICOFAC2
            VecParametros(11) = o_stTICOMOLI
            VecParametros(12) = o_boTICOARCO
            VecParametros(13) = o_stTICOESTA
            VecParametros(14) = o_inTICOCLSE
            VecParametros(15) = o_stTICOPOIN

            objenq.ActualizarDb(VecParametros, "actualizar_MANT_TIPOCONS")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_TIPOCONS(ByVal inTICOIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inTICOIDRE As New SqlParameter("@TICOIDRE", inTICOIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inTICOIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_MANT_TIPOCONS")

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
    Public Function fun_buscar_TIPO_CONS_X_CLASE_CONS_MANT_TIPOCONS(ByVal inTICOCLCO As Integer, _
                                                                    ByVal stTICOCODI As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inTICOCLCO As New SqlParameter("@TICOCLCO", inTICOCLCO)
            Dim o_stTICOCODI As New SqlParameter("@TICOCODI", stTICOCODI)

            Dim VecParametros(1) As SqlParameter

            VecParametros(0) = o_inTICOCLCO
            VecParametros(1) = o_stTICOCODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_TIPO_CONS_X_CLASE_CONS_MANT_TIPOCONS")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el DEPARTAMENTO, MUNICIPIO, CLASE, TIPO  Y CODIGO DE IDENTIFICADOR
    ''' para que no se guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_CLASE_Y_TIPO_Y_SECTOR_Y_CODIGO_MANT_TIPOCONS(ByVal stTICODEPA As String, _
                                                                                 ByVal stTICOMUNI As String, _
                                                                                 ByVal inTICOCLCO As Integer, _
                                                                                 ByVal stTICOTIPO As String, _
                                                                                 ByVal inTICOCLSE As Integer, _
                                                                                 ByVal stTICOCODI As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stTICODEPA As New SqlParameter("@TICODEPA", stTICODEPA)
            Dim o_stTICOMUNI As New SqlParameter("@TICOMUNI", stTICOMUNI)
            Dim o_inTICOCLCO As New SqlParameter("@TICOCLCO", inTICOCLCO)
            Dim o_stTICOTIPO As New SqlParameter("@TICOTIPO", stTICOTIPO)
            Dim o_inTICOCLSE As New SqlParameter("@TICOCLSE", inTICOCLSE)
            Dim o_stTICOCODI As New SqlParameter("@TICOCODI", stTICOCODI)

            Dim VecParametros(5) As SqlParameter

            VecParametros(0) = o_stTICODEPA
            VecParametros(1) = o_stTICOMUNI
            VecParametros(2) = o_inTICOCLCO
            VecParametros(3) = o_stTICOTIPO
            VecParametros(4) = o_inTICOCLSE
            VecParametros(5) = o_stTICOCODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_DEPARTAMENTO_Y_MUNICIPIO_Y_CLASE_Y_TIPO_Y_SECTOR_Y_CODIGO_MANT_TIPOCONS")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el identificador segun la depar, municipio, clase cons
    ''' sector para carbar el combobox en el formulario insertar. 
    ''' </summary>
    Public Function fun_buscar_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(ByVal stTICODEPA As String, _
                                                                 ByVal stTICOMUNI As String, _
                                                                 ByVal inTICOCLCO As Integer, _
                                                                 ByVal inTICOCLSE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stTICODEPA As New SqlParameter("@TICODEPA", stTICODEPA)
            Dim o_stTICOMUNI As New SqlParameter("@TICOMUNI", stTICOMUNI)
            Dim o_inTICOCLCO As New SqlParameter("@TICOCLCO", inTICOCLCO)
            Dim o_inTICOCLSE As New SqlParameter("@TICOCLSE", inTICOCLSE)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_stTICODEPA
            VecParametros(1) = o_stTICOMUNI
            VecParametros(2) = o_inTICOCLCO
            VecParametros(3) = o_inTICOCLSE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_TIPOCONS_X_CLASCONS_MANT_TIPOCONS")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_DEPA_MUNI_CLCO_CLSE_X_TIPOCONS(ByVal stTICODEPA As String, _
                                                                     ByVal stTICOMUNI As String, _
                                                                     ByVal inTICOCLCO As Integer, _
                                                                     ByVal inTICOCLSE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_TIPOCONS "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "TICODEPA = '" & CStr(Trim(stTICODEPA)) & "' and "
            stConsultaSQL += "TICOMUNI = '" & CStr(Trim(stTICOMUNI)) & "' and "
            stConsultaSQL += "TICOCLCO = '" & CInt(inTICOCLCO) & "' and "
            stConsultaSQL += "TICOCLSE = '" & CInt(inTICOCLSE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_DEPA_MUNI_CLSE_X_TIPOCONS")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el identificador segun la depar, municipio, clase cons
    ''' sector, tipo cons para carbar el combobox en el formulario modificar. 
    ''' </summary>
    Public Function fun_buscar_TIPOCONS_X_CLASCONS_X_TIPOCONS_MANT_TIPOCONS(ByVal stTICODEPA As String, _
                                                                 ByVal stTICOMUNI As String, _
                                                                 ByVal inTICOCLCO As Integer, _
                                                                 ByVal inTICOCLSE As Integer, _
                                                                 ByVal stTICOTIPO As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stTICODEPA As New SqlParameter("@TICODEPA", stTICODEPA)
            Dim o_stTICOMUNI As New SqlParameter("@TICOMUNI", stTICOMUNI)
            Dim o_inTICOCLCO As New SqlParameter("@TICOCLCO", inTICOCLCO)
            Dim o_inTICOCLSE As New SqlParameter("@TICOCLSE", inTICOCLSE)
            Dim o_stTICOTIPO As New SqlParameter("@TICOTIPO", stTICOTIPO)

            Dim VecParametros(4) As SqlParameter

            VecParametros(0) = o_stTICODEPA
            VecParametros(1) = o_stTICOMUNI
            VecParametros(2) = o_inTICOCLCO
            VecParametros(3) = o_inTICOCLSE
            VecParametros(4) = o_stTICOTIPO

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_TIPOCONS_X_CLASCONS_X_TIPOCONS_MANT_TIPOCONS")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el identificador segun la depar, municipio, clase cons, tipo cali,
    ''' sector para obtener los campos del tipo y area comercial en el formulario principal
    ''' </summary>
    Public Function fun_buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS(ByVal stTICODEPA As String, _
                                                                 ByVal stTICOMUNI As String, _
                                                                 ByVal inTICOCLCO As Integer, _
                                                                 ByVal inTICOCLSE As Integer, _
                                                                 ByVal stTICOCODI As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stTICODEPA As New SqlParameter("@TICODEPA", stTICODEPA)
            Dim o_stTICOMUNI As New SqlParameter("@TICOMUNI", stTICOMUNI)
            Dim o_inTICOCLCO As New SqlParameter("@TICOCLCO", inTICOCLCO)
            Dim o_inTICOCLSE As New SqlParameter("@TICOCLSE", inTICOCLSE)
            Dim o_stTICOCODI As New SqlParameter("@TICOCODI", stTICOCODI)

            Dim VecParametros(4) As SqlParameter

            VecParametros(0) = o_stTICODEPA
            VecParametros(1) = o_stTICOMUNI
            VecParametros(2) = o_inTICOCLCO
            VecParametros(3) = o_inTICOCLSE
            VecParametros(4) = o_stTICOCODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_TICODEPA_X_TICOMUNI_X_TICOCLCO_X_TICOCLSE_X_TIPOCONS_X_CLASCONS_MANT_TIPOCONS")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el identificador individual, solo el identificador .
    ''' </summary>
    Public Function fun_buscar_IDENTIFICADOR_MANT_TIPOCONS(ByVal stTICOCODI As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stTICOCODI As New SqlParameter("@TICOCODI", stTICOCODI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stTICOCODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_IDENTIFICADOR_MANT_TIPOCONS")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

  
End Class
