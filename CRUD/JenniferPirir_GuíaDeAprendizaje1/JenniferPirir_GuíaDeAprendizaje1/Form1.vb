'Librerìa para conectar SQL Server con Visual Basic
Imports System.Data.SqlClient
Public Class Form1

    'Variable que contiene la conexiòn con la base de datos
    Dim conexion As New SqlConnection(My.Settings.Conexión)


    'Mètodo para verificar la existencia del usuario que se ingrese
    Function Verificar(ByVal sql)
        'Abrir la conexiòn con SQL Server
        conexion.Open()
        'Variable que guardarà la sentencia de SQL Server
        Dim comando As New SqlCommand(sql, conexion)
        'Variable nùmerica que contredrà la ejecuciòn de la sentencia SQL Server
        Dim i As Integer = comando.ExecuteNonQuery
        'Cerrar la conexiòn con SQL Server
        conexion.Close()

        'Si el programa se ejecuta correctamente
        If (i > 0) Then
            Return True
            'Si hay errores en la ejecuciòn del programa
        Else
            Return False
        End If

    End Function

    Private Sub btn_cerrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        'Para finalizar la ejecuciòn del programa
        End
    End Sub

    Private Sub btn_ingresar_Click(sender As Object, e As EventArgs) Handles btn_ingresar.Click
        'Variable que contiene el Form2
        Dim f2 = Form2
        'Variables que contienen las sentencias de verificaciòn de SQL Server
        Dim existencia As String = "UPDATE TablaLogin SET Contraseña=Contraseña WHERE NombreDeUsuario = '" + txt_nombre.Text + "' AND Contraseña = '" + txt_contraseña.Text + "' "
        Dim verificar1 As String = "UPDATE TablaLogin SET Contraseña=Contraseña WHERE NombreDeUsuario = '" + txt_nombre.Text + "' AND Contraseña = '" + txt_contraseña.Text + "' AND RolDeUsuario = 'Administrador' "
        Dim verificar2 As String = "UPDATE TablaLogin SET Contraseña=Contraseña WHERE NombreDeUsuario = '" + txt_nombre.Text + "' AND Contraseña = '" + txt_contraseña.Text + "' AND RolDeUsuario = 'Secretaria' "
        Dim verificar3 As String = "UPDATE TablaLogin SET Contraseña=Contraseña WHERE NombreDeUsuario = '" + txt_nombre.Text + "' AND Contraseña = '" + txt_contraseña.Text + "' AND RolDeUsuario = 'Usuario' "


        'Estructura condicional 
        'Si ambos textbox estàn vacìos...
        If txt_nombre.Text = "" And txt_contraseña.Text = "" Then
            MsgBox("Por favor, ingrese su nombre y su contraseña")

            'Si el textbox de la contraseña està vacìo
        ElseIf txt_contraseña.Text = "" Then
            MsgBox("Por favor, ingrese su contraseña")

            'Si el textbox del nombre està vacìo
        ElseIf txt_nombre.Text = "" Then
            MsgBox("Por favor, ingrese su nombre de usuario")

            'Si ambos textbox NO estàn vacìos
        Else
            'Si el usuario SI existe en la base de datos
            If Verificar(existencia) Then

                'Si el usuario es un administrador
                If Verificar(verificar1) Then
                    'Ocultar el form actual
                    Me.Hide()
                    'Mostrar el form 2
                    Form2.Show()
                    'Mensaje de bienvenida
                    f2.lbl_mensaje.Text = "Bienvenido Administrador"
                    'Limpiar los textbox de nombre y contraseña
                    txt_nombre.Clear()
                    txt_contraseña.Clear()

                    'Mostrar todos los botones
                    f2.btn_mostrar.Visible = True
                    f2.btn_buscar.Visible = True
                    f2.btn_insertar.Visible = True
                    f2.btn_modificar.Visible = True
                    f2.btn_eliminar.Visible = True

                    'Mostrar todos los labels y textbox
                    f2.Label1.Visible = True
                    f2.Label3.Visible = True
                    f2.Label4.Visible = True
                    f2.Label5.Visible = True

                    f2.txt_id.Visible = True
                    f2.txt_correo.Visible = True
                    f2.txt_pais.Visible = True
                    f2.txt_ocupacion.Visible = True

                    'Cambiar la posición del DataGridView
                    f2.DGV1.Location = New Point(198, 291)

                    'Cambiar el tamaño del Form
                    f2.Size = New Size(1013, 649)

                    'Cambiar la posición del label y el textbox para el nombre de usuario
                    f2.Label2.Location = New Point(312, 188)
                    f2.txt_nombre.Location = New Point(390, 185)

                    'Habilitar el textbox de ID
                    f2.txt_id.Enabled = True


                    'Si el usuario es una secretaria
                ElseIf Verificar(verificar2) Then
                    'Ocultar el form actual
                    Me.Hide()
                    'Mostrar el form 2
                    Form2.Show()
                    'Mensaje de bienvenida
                    f2.lbl_mensaje.Text = "Bienvenida Secretaria"
                    'Limpiar los textbox de nombre y contraseña
                    txt_nombre.Clear()
                    txt_contraseña.Clear()

                    'Ocultar los botones que no deben usar las secretarias
                    f2.btn_modificar.Visible = False
                    f2.btn_eliminar.Visible = False

                    'Mostrar los botones disponibles para las secretarias
                    f2.btn_insertar.Visible = True
                    f2.btn_mostrar.Visible = True
                    f2.btn_buscar.Visible = True

                    'Mostrar todos los labels y textbox 
                    f2.Label1.Visible = True
                    f2.Label3.Visible = True
                    f2.Label4.Visible = True
                    f2.Label5.Visible = True

                    f2.txt_id.Visible = True
                    f2.txt_correo.Visible = True
                    f2.txt_pais.Visible = True
                    f2.txt_ocupacion.Visible = True

                    'Cambiar la posición del DataGridView
                    f2.DGV1.Location = New Point(198, 291)

                    'Cambiar el tamaño del Form
                    f2.Size = New Size(1013, 649)

                    'Cambiar la posición del label y el textbox para el nombre de usuario
                    f2.Label2.Location = New Point(312, 188)
                    f2.txt_nombre.Location = New Point(390, 185)

                    'Deshabilitar el textbox de ID
                    f2.txt_id.Enabled = False


                    'Si es un usuario normal
                ElseIf Verificar(verificar3) Then
                    'Ocultar el form actual
                    Me.Hide()
                    'Mostrar el form 2
                    Form2.Show()
                    'Mensaje de bienvenida
                    f2.lbl_mensaje.Text = "Bienvenido Usuario"
                    'Limpiar los textbox de nombre y contraseña
                    txt_nombre.Clear()
                    txt_contraseña.Clear()

                    'Ocultar los botones que no deben usar los usuarios normales
                    f2.btn_insertar.Visible = False
                    f2.btn_modificar.Visible = False
                    f2.btn_eliminar.Visible = False

                    'Ocultar los labels y textbox que no deben usar los usuarios normales
                    f2.Label1.Visible = False
                    f2.Label3.Visible = False
                    f2.Label4.Visible = False
                    f2.Label5.Visible = False

                    f2.txt_id.Visible = False
                    f2.txt_correo.Visible = False
                    f2.txt_pais.Visible = False
                    f2.txt_ocupacion.Visible = False

                    'Cambiar la posición del DataGridView
                    f2.DGV1.Location = New Point(198, 232)

                    'Cambiar el tamaño del Form
                    f2.Size = New Size(1013, 585)

                    'Cambiar la posición del label y el textbox para el nombre de usuario
                    f2.Label2.Location = New Point(194, 188)
                    f2.txt_nombre.Location = New Point(273, 185)

                End If

                'Si el usuario NO existe
            Else
                MsgBox("ERROR, el usuario o contraseña que usted ingresó es inválido")

            End If

        End If

    End Sub

End Class
