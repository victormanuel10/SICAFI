Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_REAVPRAF

    '==================================================
    '*** CLASE PREDIOS AFECTADOS REVISION DE AVALUO ***
    '==================================================

    ''' <summary>
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_REAVPRAF(ByVal inRAPASECU As Integer, _
                                            ByVal stRAPAMUNI As String, _
                                            ByVal stRAPACORR As String, _
                                            ByVal stRAPABARR As String, _
                                            ByVal stRAPAMANZ As String, _
                                            ByVal stRAPAPRED As String, _
                                            ByVal stRAPAEDIF As String, _
                                            ByVal stRAPAUNPR As String) As Boolean


        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "REAVPRAF "

            stConsultaSQL += "( "
            stConsultaSQL += "RAPASECU, "
            stConsultaSQL += "RAPAMUNI, "
            stConsultaSQL += "RAPACORR, "
            stConsultaSQL += "RAPABARR, "
            stConsultaSQL += "RAPAMANZ, "
            stConsultaSQL += "RAPAPRED, "
            stConsultaSQL += "RAPAEDIF, "
            stConsultaSQL += "RAPAUNPR "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inRAPASECU) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAPAMUNI)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAPACORR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAPABARR)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAPAMANZ)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAPAPRED)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAPAEDIF)) & "', "
            stConsultaSQL += "'" & CStr(Trim(stRAPAUNPR)) & "' "
            stConsultaSQL += ") "

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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_REAVPRAF")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_REAVPRAF(ByVal inRAPAIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REAVPRAF "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAPAIDRE = '" & CInt(inRAPAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_REAVPRAF")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_REAVPRAF(ByVal inRAPASECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "REAVPRAF "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAPASECU = '" & CInt(inRAPASECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_REAVPRAF")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_REAVPRAF(ByVal inRAPAIDRE As Integer, _
                                            ByVal inRAPASECU As Integer, _
                                            ByVal stRAPAMUNI As String, _
                                            ByVal stRAPACORR As String, _
                                            ByVal stRAPABARR As String, _
                                            ByVal stRAPAMANZ As String, _
                                            ByVal stRAPAPRED As String, _
                                            ByVal stRAPAEDIF As String, _
                                            ByVal stRAPAUNPR As String) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "REAVPRAF "

            stConsultaSQL += "SET "
            stConsultaSQL += "RAPASECU = '" & CInt(inRAPASECU) & "', "
            stConsultaSQL += "RAPAMUNI = '" & CStr(Trim(stRAPAMUNI)) & "', "
            stConsultaSQL += "RAPACORR = '" & CStr(Trim(stRAPACORR)) & "', "
            stConsultaSQL += "RAPABARR = '" & CStr(Trim(stRAPABARR)) & "', "
            stConsultaSQL += "RAPAMANZ = '" & CStr(Trim(stRAPAMANZ)) & "', "
            stConsultaSQL += "RAPAPRED = '" & CStr(Trim(stRAPAPRED)) & "', "
            stConsultaSQL += "RAPAEDIF = '" & CStr(Trim(stRAPAEDIF)) & "', "
            stConsultaSQL += "RAPAUNPR = '" & CStr(Trim(stRAPAUNPR)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAPAIDRE = '" & CInt(inRAPAIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_REAVPRAF")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_REAVPRAF() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RAPAIDRE, "
            stConsultaSQL += "RAPASECU, "
            stConsultaSQL += "RAPAMUNI, "
            stConsultaSQL += "RAPACORR, "
            stConsultaSQL += "RAPABARR, "
            stConsultaSQL += "RAPAMANZ, "
            stConsultaSQL += "RAPAPRED, "
            stConsultaSQL += "RAPAEDIF, "
            stConsultaSQL += "RAPAUNPR "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVPRAF "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RAPAMUNI, RAPACORR, RAPABARR, RAPAMANZ, RAPAPRED, RAPAEDIF, RAPAUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_REAVPRAF")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_REAVPRAF() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVPRAF "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RAPAMUNI, RAPACORR, RAPABARR, RAPAMANZ, RAPAPRED, RAPAEDIF, RAPAUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_REAVPRAF")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_REAVPRAF(ByVal inRAPAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVPRAF "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAPAIDRE = '" & CInt(inRAPAIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_REAVPRAF")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_X_REAVPRAF(ByVal inRAPASECU As Integer, ByVal inRAPAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVPRAF "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAPASECU = '" & CInt(inRAPASECU) & "' and "
            stConsultaSQL += "RAPAIDRE = '" & CInt(inRAPAIDRE) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_REAVPRAF")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVPRAF(ByVal inRAPAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RAPAIDRE, "
            stConsultaSQL += "RAPASECU, "
            stConsultaSQL += "RAPAMUNI, "
            stConsultaSQL += "RAPACORR, "
            stConsultaSQL += "RAPABARR, "
            stConsultaSQL += "RAPAMANZ, "
            stConsultaSQL += "RAPAPRED, "
            stConsultaSQL += "RAPAEDIF, "
            stConsultaSQL += "RAPAUNPR "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVPRAF "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "RAPASECU = '" & CInt(inRAPAIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "RAPAMUNI, RAPACORR, RAPABARR, RAPAMANZ, RAPAPRED, RAPAEDIF, RAPAUNPR "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_REAVPRAF")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca la secuencia maxima
    ''' </summary>
    Public Function fun_Buscar_SECUENCIA_X_REAVPRAF() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "RAPASECU "

            stConsultaSQL += "FROM "
            stConsultaSQL += "REAVPRAF "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECUENCIA_MAXINA_X_REAVPRAF")
            Return Nothing
        End Try

    End Function

End Class
