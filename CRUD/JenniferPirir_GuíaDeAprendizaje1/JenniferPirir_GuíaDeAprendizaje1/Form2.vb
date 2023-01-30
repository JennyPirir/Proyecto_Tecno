'Librerìa para conectar SQL Server con Visual Basic
Imports System.Data.SqlClient

Public Class Form2

    'Variable que contiene la conexiòn con la base de datos
    Dim conexión As New SqlConnection(My.Settings.Conexión)
    'Variable para el mensaje y la sentencia SQL
    Dim sentencia, mensaje As String

    'Método para ejecutar la sentencia de SQL Server
    Sub EjecutarEnSql(ByVal sql As String, ByVal msg As String)
        'Método Try catch
        Try
            'Variable para el comando de SQL Server
            Dim comando As New SqlCommand(sql, conexión)
            'Abrir la conexión con SQL Server
            conexión.Open()
            'Ejecutar el comando de SQL Server
            comando.ExecuteNonQuery()
            'Cerrar la conexión con SQL Server
            conexión.Close()
            'Mostrar mensaje
            MsgBox(msg)

        Catch ex As Exception
            'Mensaje para errores
            MsgBox(ex.Message)
            conexión.Close()

        End Try

    End Sub


    'Mètodo para verificar la existencia del usuario que se ingrese
    Function Verificar(ByVal sql)
        'Abrir la conexiòn con SQL Server
        conexión.Open()
        'Variable que guardarà la sentencia de SQL Server
        Dim comando As New SqlCommand(sql, conexión)
        'Variable nùmerica que contredrà la ejecuciòn de la sentencia SQL Server
        Dim i As Integer = comando.ExecuteNonQuery
        'Cerrar la conexiòn con SQL Server
        conexión.Close()

        'Si el programa se ejecuta correctamente
        If (i > 0) Then
            Return True
            'Si hay errores en la ejecuciòn del programa
        Else
            Return False
        End If

    End Function


    Sub MostrarDatos()
        'Método Try catch
        Try
            'Variable que muestra la tabla de registros
            Dim da As New SqlDataAdapter("SELECT *FROM TablaRegistros", conexión)
            'Crear DataSet
            Dim ds As New DataSet
            da.Fill(ds)
            'Mostrar todos los datos de la tabla en el datagridview
            Me.DGV1.DataSource = ds.Tables(0)

        Catch ex As Exception
            'Mostrar mensaje de error
            MsgBox(ex.Message)

        End Try

    End Sub


    Private Sub btn_cerrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        'Finalizar la ejecuciòn del programa
        End
    End Sub

    Private Sub btn_regresar_Click(sender As Object, e As EventArgs) Handles btn_regresar.Click
        'Ocultar el form actual
        Hide()
        'Mostrar el form del login
        Form1.Show()

        'Limpiar todos los textbox el form
        txt_id.Text = ""
        txt_nombre.Text = ""
        txt_correo.Text = ""
        txt_pais.Text = ""
        txt_ocupacion.Text = ""

    End Sub

    Private Sub btn_mostrar_Click(sender As Object, e As EventArgs) Handles btn_mostrar.Click
        'Mandar a llamar el método para mostrar los datos en el datagridview
        MostrarDatos()

    End Sub

    Private Sub btn_insertar_Click(sender As Object, e As EventArgs) Handles btn_insertar.Click
        If txt_nombre.Text = "" Or txt_ocupacion.Text = "" Or txt_pais.Text = "" Or txt_correo.Text = "" Then
            MsgBox("Por favor, ingrese todos los datos que se solicitan")

        Else
            'Sentencia SQL y mensaje
            sentencia = "INSERT INTO TablaRegistros VALUES ('" + txt_nombre.Text + "', '" + txt_correo.Text + "', '" + txt_pais.Text + "', '" + txt_ocupacion.Text + "') "
            mensaje = "Registro agregado exitosamente"
            'Mandar a llamar el método EjecutarEnSQL
            EjecutarEnSql(sentencia, mensaje)
            'Mandar a llamar el método para mostrar los datos
            MostrarDatos()

            'Limpiar todos los textbox el form
            txt_id.Text = ""
            txt_nombre.Text = ""
            txt_correo.Text = ""
            txt_pais.Text = ""
            txt_ocupacion.Text = ""

        End If

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Mandar a llamar el método para mostrar los datos
        MostrarDatos()

    End Sub

    Private Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        If txt_nombre.Text = "" Or txt_id.Text = "" Or txt_ocupacion.Text = "" Or txt_pais.Text = "" Or txt_correo.Text = "" Then
            MsgBox("Por favor, ingrese todos los datos que se solicitan")

        Else
            Dim existencia As String = "UPDATE TablaRegistros SET Nombre=Nombre WHERE ID = " + txt_id.Text + " "
            If Verificar(existencia) Then
                'Sentencia SQL y el mensaje
                sentencia = "UPDATE TablaRegistros SET Nombre = '" + txt_nombre.Text + "', Correo = '" + txt_correo.Text + "', País = '" + txt_pais.Text + "', Ocupación = '" + txt_ocupacion.Text + "' WHERE ID = " + txt_id.Text + " "
                mensaje = "Registro actualizado exitosamente"
                'Mandar a llamar el método EjecutarEnSQL
                EjecutarEnSql(sentencia, mensaje)
                'Mandar a llamar el método para mostrar los datos
                MostrarDatos()

                'Limpiar todos los textbox el form
                txt_id.Text = ""
                txt_nombre.Text = ""
                txt_correo.Text = ""
                txt_pais.Text = ""
                txt_ocupacion.Text = ""

            Else
                MsgBox("El ID que usted ingresó, no existe")

            End If


        End If

    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        If txt_id.Text = "" Then
            MsgBox("Por favor, ingrese el ID para eliminar registros")

        Else
            Dim existencia As String = "UPDATE TablaRegistros SET Nombre=Nombre WHERE ID = " + txt_id.Text + " "
            If Verificar(existencia) Then
                'Sentencia SQL y el mensaje
                sentencia = "DELETE FROM TablaRegistros WHERE ID = " + txt_id.Text + " "
                mensaje = "Registro eliminado exitosamente"
                'Mandar a llamar el método EjecutarEnSQL
                EjecutarEnSql(sentencia, mensaje)
                'Mandar a llamar el método para mostrar los datos
                MostrarDatos()

                'Limpiar el textbox de ID
                txt_id.Text = ""

            Else
                MsgBox("El ID que usted ingresó, no existe")

            End If

        End If

    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        If txt_nombre.Text = "" Then
            MsgBox("Por favor, ingrese el nombre de usuario para realizar una búsqueda")

        Else
            Dim existencia As String = "UPDATE TablaRegistros SET Nombre=Nombre WHERE Nombre = '" + txt_nombre.Text + "' "
            If Verificar(existencia) Then
                'Variable que busca en la tabla de registros
                Dim da As New SqlDataAdapter("SELECT *FROM TablaRegistros WHERE Nombre = '" + txt_nombre.Text + "' ", conexión)
                'Crear DataSet
                Dim ds As New DataSet
                da.Fill(ds)
                'Mostrar todos los datos de la tabla en el datagridview
                Me.DGV1.DataSource = ds.Tables(0)

                'Limpiar el textbox de Nombre
                txt_nombre.Text = ""

            Else
                MsgBox("El usuario que usted ingresó, no existe")

            End If

        End If

    End Sub

End Class