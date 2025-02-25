Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MENUCONT

    '=============================
    '*** CLASE MENU CONTENEDOR ***
    '=============================

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_MENUCONT() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MANT_MENUCONT")

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
    Public Function fun_Consultar_CAMPOS_MANT_MENUCONT() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_CAMPOS_MANT_MENUCONT")

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
    Public Function fun_Consultar_MENUCONT_X_ESTADO() As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb("Consultar_MENUCONT_X_ESTADO")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_MENUCONT(ByVal stMECOCODI As String, _
                                                   ByVal stMECODESC As String, _
                                                   ByVal stMECOESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_stMECOCODI As New SqlParameter("@MECOCODI", stMECOCODI)
            Dim o_stMECODESC As New SqlParameter("@MECODESC", stMECODESC)
            Dim o_stMECOESTA As New SqlParameter("@MECOESTA", stMECOESTA)

            Dim VecParametros(2) As SqlParameter

            VecParametros(0) = o_stMECOCODI
            VecParametros(1) = o_stMECODESC
            VecParametros(2) = o_stMECOESTA

            objenq.ActualizarDb(VecParametros, "insertar_MANT_MENUCONT")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_MENUCONT(ByVal inMECOIDRE As Integer) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inMECOIDRE As New SqlParameter("@MECOIDRE", inMECOIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inMECOIDRE

            If objenq.ActualizarDb(VecParametros, "eliminar_MANT_MENUCONT") Then
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
    Public Function fun_Actualizar_MANT_MENUCONT(ByVal inMECOIDRE As Integer, _
                                                     ByVal stMECOCODI As String, _
                                                     ByVal stMECODESC As String, _
                                                     ByVal stMECOESTA As String) As Boolean

        Try
            Dim objenq As New cExecuteNonQuery

            Dim o_inMECOIDRE As New SqlParameter("@MECOIDRE", inMECOIDRE)
            Dim o_stMECOCODI As New SqlParameter("@MECOCODI", stMECOCODI)
            Dim o_stMECODESC As New SqlParameter("@MECODESC", stMECODESC)
            Dim o_stMECOESTA As New SqlParameter("@MECOESTA", stMECOESTA)

            Dim VecParametros(3) As SqlParameter

            VecParametros(0) = o_inMECOIDRE
            VecParametros(1) = o_stMECOCODI
            VecParametros(2) = o_stMECODESC
            VecParametros(3) = o_stMECOESTA

            objenq.ActualizarDb(VecParametros, "actualizar_MANT_MENUCONT")

            Return True

        Catch ex As Exception

            Return False
            MessageBox.Show(Err.Description)

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_MENUCONT(ByVal inMECOIDRE As Integer) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_inMECOIDRE As New SqlParameter("@MECOIDRE", inMECOIDRE)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_inMECOIDRE

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_ID_MANT_MENUCONT")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO DEL MENU CONTENEDOR (Etiqueta menu)
    ''' para que no se guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MANT_MENUCONT(ByVal stMECOCODI As String) As DataTable

        Try
            Dim objeq As New cExecuteQuery

            Dim o_stMECOCODI As New SqlParameter("@MECOCODI", stMECOCODI)

            Dim VecParametros(0) As SqlParameter

            VecParametros(0) = o_stMECOCODI

            Dim tbl As New DataTable
            tbl = objeq.ConsultarDb(VecParametros, "buscar_CODIGO_MANT_MENUCONT")

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description)
            Return Nothing

        End Try

    End Function

End Class
