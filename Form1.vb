Imports System.ComponentModel
Imports System.Data.Common
Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports Google.Protobuf.WellKnownTypes
Imports Microsoft.VisualBasic.FileIO
Imports MySql.Data.MySqlClient
Imports Microsoft.Office.Interop

Public Class Form1
    Private Shared ReadOnly Servidor As String = "localhost"
    Private Shared ReadOnly Puerto As String = "3306"
    Private Shared ReadOnly BaseDatos1 As String = "catalogos"
    Private Shared ReadOnly Usuario As String = "root"
    Private Shared ReadOnly Contraseña As String = "Lucia30"
    Private Shared ReadOnly CadenaConexion1 As String = $"Server={Servidor};Port={Puerto};Database={BaseDatos1};Uid={Usuario};Pwd={Contraseña};"
    Private Sub BtnCargar_Click(sender As Object, e As EventArgs) Handles BtnCargar.Click
        Dim dt As New DataTable()
        Dim cadena As String

        Using archivo As New OpenFileDialog()

            archivo.Title = "Seleccionar archivo"
            archivo.Filter = "Text Files (*.txt)|*.txt|CSV files (*.csv)|*.csv|Excel files (*.xlsx)|*.xlsx"
            archivo.InitialDirectory = "C:\subir_archivos"

            If archivo.ShowDialog() = DialogResult.OK Then
                TxtArchivo.Text = archivo.FileName
                DataGridView1.DataSource = Nothing
                cadena = TxtArchivo.Text

                If cadena.Contains(".csv") Or cadena.Contains(".txt") Then
                    ' El texto SÍ contiene la palabra
                    dt = GetDataTable(TxtArchivo.Text)
                    DataGridView1.DataSource = dt
                Else
                    importar_archivo(archivo.FileName, DataGridView1)
                End If

            End If

        End Using
    End Sub
    Public Function importar_archivo(ByRef path As String, ByVal dataGrid As DataGridView)
        Dim nombreArchivo As String
        nombreArchivo = TxtArchivo.Text
        If nombreArchivo.Contains("cat_agencias") Then
            Try
                Dim stCon As String =
                    "Provider=Microsoft.ACE.OLEDB.12.0;" &
                    "Data Source=" & path & ";" &
                   "Extended Properties = 'Excel 12.0;HDR=YES;'"
                Dim cConex As New System.Data.OleDb.OleDbConnection(stCon)
                Dim Cmd As New OleDbCommand("Select * From [Hoja1$]")
                Dim Ds As New DataSet
                Dim Da As New OleDbDataAdapter
                Dim Dt As New System.Data.DataTable
                cConex.Open()
                Cmd.Connection = cConex
                Da.SelectCommand = Cmd
                Da.Fill(Ds)
                Dt = Ds.Tables(0)
                dataGrid.Columns.Clear()
                dataGrid.DataSource = Dt


            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        Else
            Try
                Dim stCon As String =
                    "Provider=Microsoft.ACE.OLEDB.12.0;" &
                    "Data Source=" & path & ";" &
                   "Extended Properties = 'Excel 12.0;HDR=YES;'"
                Dim cConex As New System.Data.OleDb.OleDbConnection(stCon)
                Dim Cmd As New OleDbCommand("Select * From [ATMs$]")
                Dim Ds As New DataSet
                Dim Da As New OleDbDataAdapter
                Dim Dt As New System.Data.DataTable
                cConex.Open()
                Cmd.Connection = cConex
                Da.SelectCommand = Cmd
                Da.Fill(Ds)
                Dt = Ds.Tables(0)
                dataGrid.Columns.Clear()
                dataGrid.DataSource = Dt


            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If

    End Function
    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        Limpiar()
    End Sub
    Public Shared Function GetDataTable(ByVal strNombreArchivo As String) As DataTable
        Dim dt As New DataTable()
        Dim i, j As Short
        Dim cabecera() As String
        Dim fila() As String

        Using myArchivo As New TextFieldParser(strNombreArchivo)
            myArchivo.TextFieldType = FieldType.Delimited
            myArchivo.SetDelimiters(";")

            cabecera = myArchivo.ReadFields()
            For Each campo As String In cabecera
                dt.Columns.Add(campo)
            Next

            While Not myArchivo.EndOfData
                fila = myArchivo.ReadFields
                dt.Rows.Add(fila)
            End While

        End Using

        Return dt

    End Function
    Public Sub Limpiar()
        DataGridView1.DataSource = Nothing
        TxtArchivo.Clear()
    End Sub
    Private Sub GuardarBaseDeDatos1()

        Dim cadena_agencia As String = "Insert into gladys_lucero_cat_agencias(codigo_agencia,  nombre_agencia, tipo_canal,distrito,Municipio,Departamento,fecha_proceso, Efectivo) values(@codigo_agencia, @nombre_agencia, @tipo_canal,@distrito,@Municipio,@Departamento,@fecha_proceso,@Efectivo)"
        Dim cadena_corresponsales As String = "Insert into gladys_lucero_cat_corresponsales(NO_CF, NO_TIENDA, Nombre_CF,Nombre_Tienda,FechaInstalacion,Distrito, Departamento,Direccion_Tienda,Saldo) values(@NO_CF, @NO_TIENDA, @Nombre_CF,@Nombre_Tienda,@FechaInstalacion,@Distrito, @Departamento,@Direccion_Tienda,@Saldo)"
        Dim cadena_atm As String = "Insert into gladys_lucero_cat_atms(ID, Nombre,Estado, Municipio, Departamento,Dirección,Saldo) values(@ID, @Nombre,@Estado, @Municipio, @Departamento,@Dirección,@Saldo)"
        Dim cadena_kioskos As String = "Insert into gladys_lucero_cat_kioskos(ID, Ubicacion, Tipo,Categoria_interna,Municipio,Departamento,Dirección) values(@ID, @Ubicacion, @Tipo,@Categoria_interna,@Municipio,@Departamento,@Dirección)"
        Dim cadena_borrar_corresponsales As String = "truncate table gladys_lucero_cat_corresponsales"
        Dim cadena_borrar_kioskos As String = "truncate table gladys_lucero_cat_kioskos"
        Dim cadena_borrar_atm As String = "truncate table gladys_lucero_cat_atms"
        Dim cadena_borrar_agencias As String = "truncate table gladys_lucero_cat_agencias"
        Dim nombreArchivo As String
        Dim fechaInstalacion As DateTime
        Dim fechaProceso As DateTime

        nombreArchivo = TxtArchivo.Text

        Using conexion As New MySqlConnection(CadenaConexion1)
            Try
                conexion.Open()

                If nombreArchivo.Contains("cat_corresponsales") Then
                    ' borrando informacion en tabla de corresponsales
                    Using comandoBorrar As New MySqlCommand(cadena_borrar_corresponsales, conexion)
                        comandoBorrar.ExecuteNonQuery()
                    End Using

                    ' insertando informacion en tabla de corresponsales
                    For Each fila As DataGridViewRow In DataGridView1.Rows
                        ' Evitamos procesar la fila vacía del final del DataGridView
                        If Not fila.IsNewRow Then


                            Using comando As New MySqlCommand(cadena_corresponsales, conexion)
                                comando.Parameters.Clear()
                                ' Mapea los valores de las celdas del DataGridView a los parámetros SQL.
                                comando.Parameters.AddWithValue("@FechaCarga", DateTime.Now)
                                comando.Parameters.AddWithValue("@NO_CF", Convert.ToInt64(fila.Cells(0).Value))
                                comando.Parameters.AddWithValue("@NO_TIENDA", Convert.ToInt64(fila.Cells(1).Value))
                                comando.Parameters.AddWithValue("@Nombre_CF", Convert.ToString(fila.Cells(2).Value))
                                comando.Parameters.AddWithValue("@Nombre_Tienda", Convert.ToString(fila.Cells(3).Value))
                                If DateTime.TryParse(fila.Cells(4).Value, fechaInstalacion) Then
                                    comando.Parameters.AddWithValue("@FechaInstalacion", fechaInstalacion)
                                Else
                                    comando.Parameters.AddWithValue("@FechaInstalacion", DBNull.Value)
                                End If
                                comando.Parameters.AddWithValue("@Distrito", Convert.ToString(fila.Cells(5).Value))
                                comando.Parameters.AddWithValue("@Departamento", Convert.ToString(fila.Cells(6).Value))
                                comando.Parameters.AddWithValue("@Direccion_Tienda", Convert.ToString(fila.Cells(7).Value))
                                comando.Parameters.AddWithValue("@Saldo", Convert.ToString(fila.Cells(8).Value))

                                ' Ejecuta la inserción de la fila actual
                                comando.ExecuteNonQuery()
                            End Using
                        End If
                    Next
                    MsgBox("¡Todos los datos del DataGridView se guardaron con éxito en la tabla 'gladys_lucero_cat_corresposales'!", MsgBoxStyle.Information, "Éxito al Guardar")
                    Limpiar()
                ElseIf nombreArchivo.Contains("cat_kioskos") Then
                    ' borrando informacion en tabla de kioskos
                    Using comandoBorrar As New MySqlCommand(cadena_borrar_kioskos, conexion)
                        comandoBorrar.ExecuteNonQuery()
                    End Using

                    ' inserntando informacion en tabla de kioskos
                    For Each fila As DataGridViewRow In DataGridView1.Rows
                        ' Evitamos procesar la fila vacía del final del DataGridView
                        If Not fila.IsNewRow Then
                            Using comando As New MySqlCommand(cadena_kioskos, conexion)
                                comando.Parameters.Clear()
                                ' Mapea los valores de las celdas del DataGridView a los parámetros .
                                comando.Parameters.AddWithValue("@FechaCarga", DateTime.Now)
                                comando.Parameters.AddWithValue("@ID", Convert.ToString(fila.Cells(0).Value))
                                comando.Parameters.AddWithValue("@Ubicacion", Convert.ToString(fila.Cells(1).Value))
                                comando.Parameters.AddWithValue("@Tipo", Convert.ToString(fila.Cells(2).Value))
                                comando.Parameters.AddWithValue("@Categoria_interna", Convert.ToString(fila.Cells(3).Value))
                                comando.Parameters.AddWithValue("@Municipio", Convert.ToString(fila.Cells(4).Value))
                                comando.Parameters.AddWithValue("@Departamento", Convert.ToString(fila.Cells(5).Value))
                                comando.Parameters.AddWithValue("@Dirección", Convert.ToString(fila.Cells(6).Value))

                                ' Ejecuta la inserción de la fila actual
                                comando.ExecuteNonQuery()
                            End Using
                        End If
                    Next
                    MsgBox("¡Todos los datos del DataGridView se guardaron con éxito en la tabla 'gladys_lucero_cat_kioskos'!", MsgBoxStyle.Information, "Éxito al Guardar")
                    Limpiar()
                ElseIf nombreArchivo.Contains("cat_agencias") Then
                    ' borrando informacion en tabla de agencias
                    Using comandoBorrar As New MySqlCommand(cadena_borrar_agencias, conexion)
                        comandoBorrar.ExecuteNonQuery()
                    End Using
                    ' insertando informacion en tabla de agencias
                    For Each fila As DataGridViewRow In DataGridView1.Rows
                        ' Evitamos procesar la fila vacía del final del DataGridView
                        If Not fila.IsNewRow Then
                            Using comando As New MySqlCommand(cadena_agencia, conexion)
                                comando.Parameters.Clear()
                                ' Mapea los valores de las celdas del DataGridView a los parámetros SQL.
                                comando.Parameters.AddWithValue("@FechaCarga", DateTime.Now)
                                comando.Parameters.AddWithValue("@codigo_agencia", Convert.ToString(fila.Cells(0).Value))
                                comando.Parameters.AddWithValue("@nombre_agencia", Convert.ToString(fila.Cells(1).Value))
                                comando.Parameters.AddWithValue("@tipo_canal", Convert.ToString(fila.Cells(2).Value))
                                comando.Parameters.AddWithValue("@distrito", Convert.ToString(fila.Cells(3).Value))
                                comando.Parameters.AddWithValue("@municipio", Convert.ToString(fila.Cells(4).Value))
                                comando.Parameters.AddWithValue("@Departamento", Convert.ToString(fila.Cells(5).Value))
                                If DateTime.TryParse(fila.Cells(6).Value, fechaProceso) Then
                                    comando.Parameters.AddWithValue("@fecha_proceso", fechaProceso)
                                Else
                                    comando.Parameters.AddWithValue("@fecha_proceso", DBNull.Value)
                                End If

                                Dim efectivoTexto As String = Convert.ToString(fila.Cells(7).Value)
                                efectivoTexto = efectivoTexto.Replace("$", "").Replace(",", "").Trim()

                                Dim efectivoDecimal As Double
                                If Double.TryParse(efectivoTexto, efectivoDecimal) Then
                                    comando.Parameters.AddWithValue("@Efectivo", efectivoDecimal)
                                Else
                                    comando.Parameters.AddWithValue("@Efectivo", 0.0)
                                End If
                                ' Ejecuta la inserción de la fila actual
                                comando.ExecuteNonQuery()
                            End Using
                        End If
                    Next
                    MsgBox("¡Todos los datos del DataGridView se guardaron con éxito en la tabla 'gladys_lucero_cat_agencias'!", MsgBoxStyle.Information, "Éxito al Guardar")
                    Limpiar()
                ElseIf nombreArchivo.Contains("cat_atms") Then
                    ' borrando informacion en tabla de atms
                    Using comandoBorrar As New MySqlCommand(cadena_borrar_atm, conexion)
                        comandoBorrar.ExecuteNonQuery()
                    End Using
                    ' inserntando informacion en tabla de atms
                    For Each fila As DataGridViewRow In DataGridView1.Rows
                        ' Evitamos procesar la fila vacía del final del DataGridView
                        If Not fila.IsNewRow Then
                            Using comando As New MySqlCommand(cadena_atm, conexion)
                                comando.Parameters.Clear()
                                ' Mapea los valores de las celdas del DataGridView a los parámetros SQL.

                                comando.Parameters.AddWithValue("@FechaCarga", DateTime.Now)
                                comando.Parameters.AddWithValue("@ID", Convert.ToString(fila.Cells(0).Value))
                                comando.Parameters.AddWithValue("@Nombre", Convert.ToString(fila.Cells(1).Value))
                                comando.Parameters.AddWithValue("@Estado", Convert.ToString(fila.Cells(2).Value))
                                comando.Parameters.AddWithValue("@Municipio", Convert.ToString(fila.Cells(3).Value))
                                comando.Parameters.AddWithValue("@Departamento", Convert.ToString(fila.Cells(4).Value))
                                comando.Parameters.AddWithValue("@Dirección", Convert.ToString(fila.Cells(5).Value))


                                Dim efectivoTexto As String = Convert.ToString(fila.Cells(6).Value)
                                efectivoTexto = efectivoTexto.Replace("$", "").Replace(",", "").Trim()

                                Dim efectivoDecimal As Double
                                If Double.TryParse(efectivoTexto, efectivoDecimal) Then
                                    comando.Parameters.AddWithValue("@Saldo", efectivoDecimal)
                                Else
                                    comando.Parameters.AddWithValue("@Saldo", 0.0)
                                End If
                                comando.Parameters.AddWithValue("@FechaCorte", Convert.ToString(fila.Cells(7).Value))


                                ' Ejecuta la inserción de la fila actual
                                comando.ExecuteNonQuery()
                            End Using
                        End If
                    Next
                    MsgBox("¡Todos los datos del DataGridView se guardaron con éxito en la tabla 'gladys_lucero_cat_atms'!", MsgBoxStyle.Information, "Éxito al Guardar")
                    Limpiar()
                End If


            Catch ex As MySqlException
                MsgBox("Error de MySQL al guardar: " & ex.Message, MsgBoxStyle.Critical, "Error de BD")
            Catch ex As Exception
                MsgBox("Error general al procesar los datos: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End Using
    End Sub
    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click

        ' Validamos si el DataGridView tiene datos antes de intentar conectar
        If DataGridView1.Rows.Count <= 1 AndAlso DataGridView1.Rows(0).IsNewRow Then
            MsgBox("El DataGridView no contiene datos para almacenar.", MsgBoxStyle.Exclamation, "Aviso")
            Exit Sub
        End If
        ' Ejecutamos el flujo
        If MyConexion() Then
            GuardarBaseDeDatos1()
        Else
            MsgBox("La operación fue cancelada debido a problemas de comunicación.", MsgBoxStyle.Exclamation, "Operación Detenida")
        End If
    End Sub
    Private Function MyConexion() As Boolean

        Using conexion As New MySqlConnection(CadenaConexion1)
            Try
                conexion.Open()
                Return True
            Catch ex As MySqlException
                MsgBox("Error MySQL (" & ex.Number & "): " & ex.Message, MsgBoxStyle.Critical, "Error de Conexión")
                Return False
            Catch ex As Exception
                MsgBox("Error : " & ex.Message, MsgBoxStyle.Critical, "Error")
                Return False
            End Try
        End Using
    End Function
End Class
