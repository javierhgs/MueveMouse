Imports System.Runtime.InteropServices

Public Class Form1
    ' Importar la función SetCursorPos de la API de Windows
    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function SetCursorPos(ByVal X As Integer, ByVal Y As Integer) As Boolean
    End Function

    Private timer As Timer = New Timer()

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Configurar el temporizador
        timer.Interval = 1000 ' Intervalo en milisegundos
        AddHandler timer.Tick, AddressOf Timer_Tick

        ' Establecer la propiedad FormBorderStyle en FixedSingle
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
    End Sub

    Private Sub btnIniciar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnIniciar.Click
        Dim segundos As Double
        If Double.TryParse(txtSegundos.Text, segundos) Then
            If segundos > 0 AndAlso segundos <= 3600 Then ' Limitar los segundos a un rango razonable (de 0 a 3600)
                ' Iniciar el temporizador
                timer.Interval = CInt(segundos * 1000) ' Convertir segundos a milisegundos
                timer.Start()
                btnIniciar.Enabled = False
                txtSegundos.Enabled = False
            Else
                MessageBox.Show("Por favor, ingresa un valor válido para los segundos (entre 0 y 3600).")
            End If
        Else
            MessageBox.Show("Por favor, ingresa un valor numérico válido para los segundos.")
        End If
    End Sub

    Private Sub Timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        ' Mover el mouse a una posición aleatoria en la pantalla
        Dim rand As Random = New Random()
        Dim x As Integer = rand.Next(Screen.PrimaryScreen.Bounds.Width)
        Dim y As Integer = rand.Next(Screen.PrimaryScreen.Bounds.Height)
        SetCursorPos(x, y)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelar.Click
        ' Detener el temporizador
        timer.Stop()
        btnIniciar.Enabled = True
        txtSegundos.Enabled = True
    End Sub
End Class
