Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MACAFORM

    '========================================
    '*** MATERIAL DE CAMPO POR FORMULARIO ***
    '========================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MANT_MACAFORM(ByVal obMCFOFORM As Object, ByVal obMCFOMACA As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obMCFOMACA.SelectedValue) = True And _
               obVerifica.fun_Verificar_Campo_Lleno(obMCFOFORM.SelectedValue) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obMCFOMACA.SelectedValue) = True Then

                    Dim objdatos1 As New cla_MACAFORM
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_MACAFORM(Trim(obMCFOFORM.SelectedValue), obMCFOMACA.SelectedValue)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El dato " & obMCFOFORM.Text & " - " & obMCFOMACA.Text & " existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        obMCFOMACA.Focus()
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
    ''' Función que inserta el registro.
    ''' </summary>
    Public Function fun_Insertar_MANT_MACAFORM(ByVal stMCFOFORM As String, _
                                               ByVal inMCFOMACA As Integer, _
                                               ByVal stMCFOESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MCFOatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MANT_MACAFORM "

            stConsultaSQL += "( "
            stConsultaSQL += "MCFOFORM, "
            stConsultaSQL += "MCFOMACA, "
            stConsultaSQL += "MCFOESTA "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CStr(Trim(stMCFOFORM)) & "', "
            stConsultaSQL += "'" & CInt(inMCFOMACA) & "', "
            stConsultaSQL += "'" & CStr(Trim(stMCFOESTA)) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MANT_MACAFORM")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_MANT_MACAFORM(ByVal inMCFOIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MCFOatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MANT_MACAFORM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MCFOIDRE = '" & CInt(inMCFOIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MANT_MACAFORM")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MANT_MACAFORM(ByVal inMCFOIDRE As Integer, _
                                                 ByVal stMCFOFORM As String, _
                                                 ByVal inMCFOMACA As Integer, _
                                                 ByVal stMCFOESTA As String) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MCFOatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MANT_MACAFORM "

            stConsultaSQL += "SET "
            stConsultaSQL += "MCFOFORM = '" & CStr(Trim(stMCFOFORM)) & "', "
            stConsultaSQL += "MCFOMACA = '" & CInt(inMCFOMACA) & "', "
            stConsultaSQL += "MCFOESTA = '" & CStr(Trim(stMCFOESTA)) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MCFOIDRE = '" & CInt(inMCFOIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MACAFORM")
        End Try

    End Function

    ''' <summary>
    ''' Consulta para llenar el DataGridView y colocar el nombre del encabezado
    ''' de la columna. 
    ''' </summary>
    Public Function fun_Consultar_MANT_MACAFORM() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MCFOatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MCFOIDRE, "
            stConsultaSQL += "MCFOFORM, "
            stConsultaSQL += "FORMDESC, "
            stConsultaSQL += "MCFOMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "MCFOESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MACAFORM, "
            stConsultaSQL += "MANT_FORMULARIO, "
            stConsultaSQL += "MANT_MATECAMP, "
            stConsultaSQL += "ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MCFOFORM = FORMCODI AND "
            stConsultaSQL += "MCFOMACA = MACACODI AND "
            stConsultaSQL += "MCFOESTA = ESTACODI "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MCFOFORM, MCFOMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la MACAFORM
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_MACAFORM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos e inactivos formulario principal 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_CAMPOS_MANT_MACAFORM() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MCFOatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MACAFORM "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MCFOFORM, MCFOMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la MACAFORM
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_CAMPOS_MANT_MACAFORM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Llena el ComboBox con datos activos formulario insertar y modificar 
    ''' esta funcion se llama desde el procedimiento "pro_inicializarControles()".
    ''' </summary>
    Public Function fun_Consultar_MANT_MACAFORM_X_ESTADO() As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MCFOatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MACAFORM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MCFOESTA = 'ac' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MCFOFORM, MCFOMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la MACAFORM
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Consultar_MANT_MACAFORM_X_ESTADO")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del registro a modificar o eliminar.
    ''' </summary>
    Public Function fun_Buscar_ID_MANT_MACAFORM(ByVal inMCFOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MCFOatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MACAFORM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MCFOIDRE = '" & CInt(inMCFOIDRE) & "'"

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la MACAFORM
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_MANT_MACAFORM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MACAFORM(ByVal stMCFOFORM As String, ByVal inMCFOMACA As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MCFOatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MACAFORM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MCFOFORM = '" & CStr(Trim(stMCFOFORM)) & "' and "
            stConsultaSQL += "MCFOMACA = '" & CInt(inMCFOMACA) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la MACAFORM
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MACAFORM")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el MACAFORM por el ID
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_MACAFORM(ByVal inMCFOIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MCFOatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MCFOIDRE, "
            stConsultaSQL += "MCFOFORM, "
            stConsultaSQL += "FORMDESC, "
            stConsultaSQL += "MCFOMACA, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "MCFOESTA, "
            stConsultaSQL += "ESTADESC "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MACAFORM, "
            stConsultaSQL += "MANT_FORMULARIO, "
            stConsultaSQL += "MANT_MATECAMP, "
            stConsultaSQL += "ESTADO "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MCFOFORM = FORMCODI AND "
            stConsultaSQL += "MCFOMACA = MACACODI AND "
            stConsultaSQL += "MCFOESTA = ESTACODI AND "
            stConsultaSQL += "MCFOIDRE = '" & CInt(inMCFOIDRE) & "'"

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MCFOFORM, MCFOMACA "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la MACAFORM
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MANT_MACAFORM")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el MACAFORM por tipo de impuesto
    ''' </summary>
    Public Function fun_Buscar_CODIGO_MACAFORM_X_FORMULARIO(ByVal stMCFOFORM As String) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MCFOatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MACAIDRE, "
            stConsultaSQL += "MACACODI, "
            stConsultaSQL += "MACADESC, "
            stConsultaSQL += "MACAESTA "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MACAFORM, MANT_MATECAMP "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MCFOMACA = MACACODI AND "
            stConsultaSQL += "MCFOFORM = '" & CStr(Trim(stMCFOFORM)) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la MACAFORM
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MACAFORM_X_TIPOIMPU")
            Return Nothing
        End Try

    End Function
    Public Function fun_Buscar_CODIGO_MACAFORM_X_TIPOMCFO(ByVal stMCFOFORM As String, ByVal inMCFOMACA As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' MCFOatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MANT_MACAFORM "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MCFOFORM = '" & CStr(Trim(stMCFOFORM)) & "' AND "
            stConsultaSQL += "MCFOMACA = '" & CInt(inMCFOMACA) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la MACAFORM
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MACAFORM_X_TIPOIMPU")
            Return Nothing
        End Try

    End Function

End Class
