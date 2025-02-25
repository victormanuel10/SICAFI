Public Class cla_ConnectionString

    '===================================================================================
    ' CADENA DE CONEXION A LA BASE DE DATOS DE LOS PROYECTOS REGLAS DEL NEGOCIO Y SICAFI
    '===================================================================================
    Public Function fun_ConnectionString_PROYECTO_DATOS() As String
        Return vp_stConexionBD
    End Function

    Public Function fun_ConnectionString_RED_PROYECTO_DATOS() As String
        Return vp_stConexionRED
    End Function

    Public Function fun_ConnectionString_LOCAL_PROYECTO_DATOS() As String
        Return vp_stConexionLOCAL
    End Function

    ' FUNCIONES PARAMETROS DE CONEXION
    Public Function fun_DataSource() As String
        Return vp_stDataSource
    End Function
    Public Function fun_InitialCatalog() As String
        Return vp_stInitialCatalog
    End Function
    Public Function fun_UserID() As String
        Return vp_stUserID
    End Function
    Public Function fun_Password() As String
        Return vp_stPassword
    End Function

End Class
