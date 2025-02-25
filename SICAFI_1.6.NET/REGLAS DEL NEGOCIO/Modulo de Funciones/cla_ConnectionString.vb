Public Class cla_ConnectionString

    '==================================================
    ' DEVUELVE LA CADENA DE CONECION AL PROYECTO SICAFI
    '==================================================

    Public Function fun_ConnectionString() As String
        Dim stConexionBD As New DATOS.cla_ConnectionString()
        Dim stConexion As String = ""

        stConexion = stConexionBD.fun_ConnectionString_PROYECTO_DATOS

        Return stConexion

    End Function

    Public Function fun_ConnectionString_RED() As String
        Dim stConexionBD As New DATOS.cla_ConnectionString()
        Dim stConexionRED As String = ""

        stConexionRED = stConexionBD.fun_ConnectionString_RED_PROYECTO_DATOS

        Return stConexionRED

    End Function

    Public Function fun_ConnectionString_LOCAL() As String
        Dim stConexionBD As New DATOS.cla_ConnectionString()
        Dim stConexionLOCAL As String = ""

        stConexionLOCAL = stConexionBD.fun_ConnectionString_LOCAL_PROYECTO_DATOS

        Return stConexionLOCAL

    End Function

    ' FUNCIONES DE CONEXION
    Public Function fun_DataSource() As String
        Dim obDataSource As New DATOS.cla_ConnectionString()
        Dim stDataSource As String = ""

        stDataSource = obDataSource.fun_DataSource

        Return stDataSource

    End Function
    Public Function fun_InitialCatalog() As String
        Dim obInitialCatalog As New DATOS.cla_ConnectionString()
        Dim stInitialCatalog As String = ""

        stInitialCatalog = obInitialCatalog.fun_InitialCatalog

        Return stInitialCatalog

    End Function
    Public Function fun_UserID() As String
        Dim obUserID As New DATOS.cla_ConnectionString()
        Dim stUserID As String = ""

        stUserID = obUserID.fun_UserID

        Return stUserID

    End Function
    Public Function fun_Password() As String
        Dim obPassword As New DATOS.cla_ConnectionString()
        Dim stPassword As String = ""

        stPassword = obPassword.fun_Password

        Return stPassword

    End Function

End Class
