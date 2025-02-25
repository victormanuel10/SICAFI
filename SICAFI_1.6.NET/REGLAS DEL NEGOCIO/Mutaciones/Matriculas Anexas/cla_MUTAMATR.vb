Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DATOS

Public Class cla_MUTAMATR

    '============================================
    '*** CLASE MUTAMATR MATRICULAS ADJUNTAS ***
    '============================================

    ''' <summary>
    ''' procedimiento que verifica la llave primaria.
    ''' </summary>
    Public Function fun_Verifica_llave_Primaria_MUTAMATR(ByVal obMUMASECU As Object, _
                                                         ByVal obMUMANUFI As Object, _
                                                         ByVal obMUMAMAIN As Object) As Boolean

        Try
            Dim boRespuesta As Boolean = False

            Dim obVerifica As New cla_Verificar_Dato

            If obVerifica.fun_Verificar_Campo_Lleno(obMUMASECU.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMUMANUFI.Text) = True And _
                obVerifica.fun_Verificar_Campo_Lleno(obMUMAMAIN.Text) = True Then

                If obVerifica.fun_Verificar_Dato_Numerico(obMUMASECU.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obMUMANUFI.Text) = True And _
                    obVerifica.fun_Verificar_Dato_Numerico(obMUMAMAIN.Text) = True Then

                    Dim objdatos1 As New cla_MUTAMATR
                    Dim tbl As New DataTable

                    tbl = objdatos1.fun_Buscar_CODIGO_X_MUTAMATR(obMUMASECU.Text, obMUMANUFI.Text, obMUMAMAIN.Text)

                    If tbl.Rows.Count > 0 Then
                        MessageBox.Show("El registro existe en la base de datos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
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
    Public Function fun_Insertar_MUTAMATR(ByVal inMUMASECU As Integer, _
                                          ByVal inMUMANUFI As Integer, _
                                          ByVal inMUMAMAIN As Integer, _
                                          ByVal loMUMAVACO As Long) As Boolean

        Try

            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "INSERT INTO "
            stConsultaSQL += "MUTAMATR "

            stConsultaSQL += "( "
            stConsultaSQL += "MUMASECU, "
            stConsultaSQL += "MUMANUFI, "
            stConsultaSQL += "MUMAMAIN, "
            stConsultaSQL += "MUMAVACO "
            stConsultaSQL += ") "

            stConsultaSQL += "VALUES "

            stConsultaSQL += "( "
            stConsultaSQL += "'" & CInt(inMUMASECU) & "', "
            stConsultaSQL += "'" & CInt(inMUMANUFI) & "', "
            stConsultaSQL += "'" & CInt(inMUMAMAIN) & "', "
            stConsultaSQL += "'" & CLng(loMUMAVACO) & "' "
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
            MessageBox.Show(Err.Description & " " & "fun_Insertar_MUTAMATR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_IDRE_MUTAMATR(ByVal inMUMAIDRE As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAMATR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMAIDRE = '" & CInt(inMUMAIDRE) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MUTAMATR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Elimina el registro.
    ''' </summary>
    Public Function fun_Eliminar_SECU_MUTAMATR(ByVal inMUMASECU As Integer) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "DELETE "
            stConsultaSQL += "MUTAMATR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMASECU = '" & CInt(inMUMASECU) & "' "

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
            MessageBox.Show(Err.Description & " " & "fun_Eliminar_MUTAMATR")
        End Try

    End Function

    ''' <summary>
    ''' Función que Modifica el registro.
    ''' </summary>
    Public Function fun_Actualizar_MUTAMATR(ByVal inMUMAIDRE As Integer, _
                                            ByVal inMUMASECU As Integer, _
                                            ByVal inMUMANUFI As Integer, _
                                            ByVal inMUMAMAIN As Integer, _
                                            ByVal loMUMAVACO As Long) As Boolean

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "UPDATE "
            stConsultaSQL += "MUTAMATR "

            stConsultaSQL += "SET "
            stConsultaSQL += "MUMASECU = '" & CInt(inMUMASECU) & "', "
            stConsultaSQL += "MUMANUFI = '" & CInt(inMUMANUFI) & "', "
            stConsultaSQL += "MUMAMAIN = '" & CInt(inMUMAMAIN) & "', "
            stConsultaSQL += "MUMAVACO = '" & CLng(loMUMAVACO) & "' "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMAIDRE = '" & CInt(inMUMAIDRE) & "'"

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
            MessageBox.Show(Err.Description & " " & "fun_Actualizar_MUTAMATR")
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el CÓDIGO para que no se 
    ''' guarden registros duplicados.
    ''' </summary>
    ''' 
    Public Function fun_Buscar_CODIGO_X_MUTAMATR(ByVal inMUMASECU As Integer, _
                                                 ByVal inMUMANUFI As Integer, _
                                                 ByVal inMUMAMAIN As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "* "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAMATR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMASECU = '" & CInt(inMUMASECU) & "' and "
            stConsultaSQL += "MUMANUFI = '" & CInt(inMUMANUFI) & "' and "
            stConsultaSQL += "MUMAMAIN = '" & CInt(inMUMAMAIN) & "' "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception
            MessageBox.Show(Err.Description & " " & "fun_Buscar_CODIGO_MUTAMATR")
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMATR(ByVal inMUMAIDRE As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MUMAIDRE, "
            stConsultaSQL += "MUMASECU, "
            stConsultaSQL += "MUMANUFI, "
            stConsultaSQL += "MUMAMAIN, "
            stConsultaSQL += "MUMAVACO "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAMATR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMAIDRE = '" & CInt(inMUMAIDRE) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUMAMAIN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_ID_X_CONSULTA_PARAMETRIZADA_MUTAMUNI")
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Función que busca el ID del codigo buscado para ejecutar la consulta
    ''' parametrizada.
    ''' </summary>
    Public Function fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_MUTAMATR(ByVal inMUMASECU As Integer) As DataTable

        Try
            ' parametros de la consulta
            Dim stConsultaSQL As String = ""

            ' Concatena la consulta
            stConsultaSQL += "SELECT "
            stConsultaSQL += "MUMAIDRE, "
            stConsultaSQL += "MUMASECU, "
            stConsultaSQL += "MUMANUFI, "
            stConsultaSQL += "MUMAMAIN, "
            stConsultaSQL += "MUMAVACO "

            stConsultaSQL += "FROM "
            stConsultaSQL += "MUTAMATR "

            stConsultaSQL += "WHERE "
            stConsultaSQL += "MUMASECU = '" & CInt(inMUMASECU) & "' "

            stConsultaSQL += "ORDER BY "
            stConsultaSQL += "MUMAMAIN "

            ' instancia la clase
            Dim objeq As New cExecuteQuery

            ' declaro la variable
            Dim tbl As New DataTable

            tbl = objeq.ConsultarDb_Text_SQL(stConsultaSQL)

            Return tbl

        Catch ex As Exception

            MessageBox.Show(Err.Description & " " & "fun_Buscar_SECU_X_CONSULTA_PARAMETRIZADA_MUTAMATR")
            Return Nothing

        End Try

    End Function

 End Class