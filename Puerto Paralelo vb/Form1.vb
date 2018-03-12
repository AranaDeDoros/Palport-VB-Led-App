Public Class Form1
    ' variables globales
    Public direccion As Integer = 888
    Public D7 As Integer, D6 As Integer, D5 As Integer, D4 As Integer, D3 As Integer, D2 As Integer, _
    D1 As Integer, D0 As Integer
    Dim num As Integer
    Dim demal As Integer
    Dim binario As String
    Dim asr As Char()
    Dim azr As IEnumerable(Of Char)
    Dim inicio As Integer
    Dim final As Integer
    Dim ztart As String
    Dim zend As String
    Dim numero As Integer
    Dim devent As Boolean


    'carga la forma junto con la subrutina de reseteo
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Reset_LEDs()
    End Sub

    'inicia los leds apagados
    Private Sub Reset_LEDs()
        Reset_Box() 'desmarca casillas
        ' Resetea todos los Led al iniciar el programa.
        Try
            Puerto_Paralelo_vb.PortInterop.Output(direccion, 0)
            Puerto_Paralelo_vb.PortInterop.Input(direccion)
        Catch generatedExceptionName As DllNotFoundException
            Alerta_1()
        End Try

        pictureBox_D0.Image = My.Resources.off  ' Elegimos la luz apagada de la imagen.
        PictureBox_D1.Image = My.Resources.off
        PictureBox_D2.Image = My.Resources.off
        PictureBox_D3.Image = My.Resources.off
        PictureBox_D4.Image = My.Resources.off
        PictureBox_D5.Image = My.Resources.off
        PictureBox_D6.Image = My.Resources.off
        PictureBox_D7.Image = My.Resources.off
    End Sub

    'enciendo todo
    Private Sub ON_LEDs()
        Init_Box()
        ' Inicia todos los Led al iniciar el programa.
        Try
            Puerto_Paralelo_vb.PortInterop.Output(direccion, 255)
            Puerto_Paralelo_vb.PortInterop.Input(direccion)
        Catch generatedExceptionName As DllNotFoundException
            Alerta_1()
        End Try
        pictureBox_D0.Image = My.Resources.onn
        PictureBox_D1.Image = My.Resources.onn
        PictureBox_D2.Image = My.Resources.onn
        PictureBox_D3.Image = My.Resources.onn
        PictureBox_D4.Image = My.Resources.onn
        PictureBox_D5.Image = My.Resources.onn
        PictureBox_D6.Image = My.Resources.onn
        PictureBox_D7.Image = My.Resources.onn

    End Sub

    'excepción en caso de que la librería no se encuentre
    Private Shared Sub Alerta_1()
        MessageBox.Show("No se escuentra la dll especificada." & vbCr & vbLf & vbCr & vbLf & "Asegúrate que la dll 'inpout32.dl' esté al lado del ejecutable principal." & vbCr & vbLf & "La reinstalación puede resolver el problema.", "Aviso:", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
    End Sub

    'verifica el valor de Dn, se obteiene el valor correspondiente al led que encenderemos y se envia
#Region "Opciones."
    Public Sub opciones()
        Dim value As Integer = 0

        If D0 = 1 Then
            value += CInt(Math.Pow(2, 0))
            LoadNewPict_D0()
        Else
            LoadOldPict_D0()
        End If
        value += 0

        If D1 = 1 Then
            value += CInt(Math.Pow(2, 1))
            LoadNewPict_D1()
        Else
            LoadOldPict_D1()
        End If
        value += 0

        If D2 = 1 Then
            value += CInt(Math.Pow(2, 2))
            LoadNewPict_D2()
        Else
            LoadOldPict_D2()
        End If
        value += 0

        If D3 = 1 Then
            value += CInt(Math.Pow(2, 3))
            LoadNewPict_D3()
        Else
            LoadOldPict_D3()
        End If
        value += 0

        If D4 = 1 Then
            value += CInt(Math.Pow(2, 4))
            LoadNewPict_D4()
        Else
            LoadOldPict_D4()
        End If
        value += 0

        If D5 = 1 Then
            value += CInt(Math.Pow(2, 5))
            LoadNewPict_D5()
        Else
            LoadOldPict_D5()
        End If
        value += 0

        If D6 = 1 Then
            value += CInt(Math.Pow(2, 6))
            LoadNewPict_D6()
        Else
            LoadOldPict_D6()
        End If
        value += 0

        If D7 = 1 Then
            value += CInt(Math.Pow(2, 7))
            LoadNewPict_D7()
        Else
            LoadOldPict_D7()
        End If
        value += 0

        'a partir de aqui envia a la interfaz
        Try
            Puerto_Paralelo_vb.PortInterop.Output(direccion, value)
            'MsgBox(value)
        Catch generatedExceptionName As DllNotFoundException
            Alerta_1()
        End Try

    End Sub

#End Region

    'se encarga de cambiar la imagen al hacer click sobre los focos
#Region "Cargando los Led de la imagen."

    Private Sub LoadNewPict_D0()
        pictureBox_D0.Image = My.Resources.onn
    End Sub

    Private Sub LoadNewPict_D1()
        PictureBox_D1.Image = My.Resources.onn
    End Sub

    Private Sub LoadNewPict_D2()
        PictureBox_D2.Image = My.Resources.onn
    End Sub

    Private Sub LoadNewPict_D3()
        PictureBox_D3.Image = My.Resources.onn
    End Sub

    Private Sub LoadNewPict_D4()
        PictureBox_D4.Image = My.Resources.onn
    End Sub

    Private Sub LoadNewPict_D5()
        PictureBox_D5.Image = My.Resources.onn
    End Sub

    Private Sub LoadNewPict_D6()
        PictureBox_D6.Image = My.Resources.onn
    End Sub

    Private Sub LoadNewPict_D7()
        PictureBox_D7.Image = My.Resources.onn
    End Sub


    Private Sub LoadOldPict_D0()
        pictureBox_D0.Image = My.Resources.off
    End Sub

    Private Sub LoadOldPict_D1()
        PictureBox_D1.Image = My.Resources.off
    End Sub

    Private Sub LoadOldPict_D2()
        PictureBox_D2.Image = My.Resources.off
    End Sub

    Private Sub LoadOldPict_D3()
        PictureBox_D3.Image = My.Resources.off
    End Sub

    Private Sub LoadOldPict_D4()
        PictureBox_D4.Image = My.Resources.off
    End Sub

    Private Sub LoadOldPict_D5()
        PictureBox_D5.Image = My.Resources.off
    End Sub

    Private Sub LoadOldPict_D6()
        PictureBox_D6.Image = My.Resources.off
    End Sub

    Private Sub LoadOldPict_D7()
        PictureBox_D7.Image = My.Resources.off
    End Sub

#End Region

  
    'boton enviar
    Private Sub button_Address_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_Address.Click
        If textBox_port_adress.Text = "378" Then
            direccion = 888
            'MessageBox.Show(direccion, "sd")
        ElseIf (textBox_port_adress.Text = "0" Or vbNull) Then
            'direccion = 0
            MessageBox.Show("Introduce 378/632")
        End If
        'button_Address.Enabled = False


    End Sub

    'envia a la dirección dada junto con el valor del campo...
    Private Sub button_Enviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_Enviar.Click
        Reset_LEDs()
        Try
            If (campoDato.Text = "") Then
                MessageBox.Show("Inserta un valor")
            Else
                binarioConv() 'esto lo ocupa el programa 
                Puerto_Paralelo_vb.PortInterop.Output(direccion, Int32.Parse(campoDato.Text)) 'esto lo recibe la interfaz
            End If
        Catch generatedExceptionName As DllNotFoundException
            Alerta_1()
        End Try
    End Sub

    'reinicia leds a petición
    Private Sub button_Reset_Leds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_Reset_Leds.Click
        Reset_LEDs()
        D7 = 0 'se resetea los valores de D para no almacenar basura
        D6 = 0
        D5 = 0
        D4 = 0
        D3 = 0
        D2 = 0
        D1 = 0
        D0 = 0
    End Sub

    'enciende todos los leds
    Private Sub botonTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botonTodos.Click
        ON_LEDs()
        D7 = 1
        D6 = 1
        D5 = 1
        D4 = 1
        D3 = 1
        D2 = 1
        D1 = 1
        D0 = 1
    End Sub

    'cuenta de 0 a 255
    Private Sub botonContar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botonContar.Click
        Reset_LEDs()
        ztart = campoInicio.Text
        zend = campoFinal.Text
        If (campoInicio.Text = "" Or campoFinal.Text = "") Then
            MessageBox.Show("Inserta un valor")
        Else
            System.Threading.Thread.Sleep(400)
            For c As Integer = ztart To zend
                binario = Convert.ToString(c, 2)
                azr = binario.Reverse.ToArray
                For Me.num = 0 To binario.Length - 1
                    If (azr(num) = "1") Then
                        conCo()
                    Else
                        conCf()
                    End If
                Next
                System.Threading.Thread.Sleep(150)
                Puerto_Paralelo_vb.PortInterop.Output(direccion, c)
                ' Debug.WriteLine(c)
            Next
        End If
    End Sub


    'convierte a binario

    'binario

    Public Sub binarioConv()
        demal = Int32.Parse(campoDato.Text) 'decimal get
        binario = Convert.ToString(demal, 2) 'binario get
        azr = binario.Reverse.ToArray 'array a ser leido inversamente
        'asr = binario.ToCharArray
        For Me.num = 0 To binario.Length - 1
            'MsgBox(azr(0))
            'MsgBox(azr(num))
            If (azr(num) = "1") Then
                convOn()
                'MsgBox("es 1")
            Else
                convOff()
                'MsgBox("es 0")
            End If
        Next
        MessageBox.Show("La cadena fue: " + binario)

    End Sub

    'encendido de leds por binarios
    Private Sub convOn()
        'Dim OK As Integer = num
        'MsgBox(OK)
        Select Case num
            Case 0
                'MsgBox(" LED0")
                D0 = 1
                LoadNewPict_D0()
                casilla1.CheckState = CheckState.Checked
            Case 1
                'MsgBox("LED 1")
                D1 = 1
                LoadNewPict_D1()
                casilla2.CheckState = CheckState.Checked
            Case 2
                '    MsgBox("LED 2")
                D2 = 1
                LoadNewPict_D2()
                casilla3.CheckState = CheckState.Checked
            Case 3
                '   MsgBox("LED 3")
                D3 = 1
                LoadNewPict_D3()
                casilla4.CheckState = CheckState.Checked
            Case 4
                '  MsgBox("LED 4")
                D4 = 1
                LoadNewPict_D4()
                casilla5.CheckState = CheckState.Checked
            Case 5
                ' MsgBox("LED 5")
                D5 = 1
                LoadNewPict_D5()
                casilla6.CheckState = CheckState.Checked
            Case 6
                'MsgBox("LED 6")
                D6 = 1
                LoadNewPict_D6()
                casilla7.CheckState = CheckState.Checked
            Case 7
                'MsgBox("LED 7")
                D7 = 1
                LoadNewPict_D7()
                casilla8.CheckState = CheckState.Checked
        End Select

    End Sub

    'apagado de leds por binarios
    Private Sub convOff() 'apaga si recibe 0 del valor ingresado
        'Dim OK As Integer = num
        'MsgBox(OK)
        Select Case num
            Case 0
                'MsgBox(" LED0 F")
                D0 = 0
                LoadOldPict_D0()
            Case 1
                'MsgBox("LED 1 F")
                D1 = 0
                LoadOldPict_D1()
            Case 2
                'MsgBox("LED 2 F")
                D2 = 0
                LoadOldPict_D2()
            Case 3
                'MsgBox("LED 3 F")
                D3 = 0
                LoadOldPict_D3()
            Case 4
                'MsgBox("LED 4")
                D4 = 0
                LoadOldPict_D4()
            Case 5
                'MsgBox("LED 5")
                D5 = 0
                LoadOldPict_D5()
            Case 6
                'MsgBox("LED 6")
                D6 = 0
                LoadOldPict_D6()
            Case 7
                'MsgBox("LED 7")
                D7 = 0
                LoadOldPict_D7()
        End Select
    End Sub

    'Private Sub conver()
    '    Dim OK As Integer = num
    '    'MsgBox(OK)
    '    If (num = 0) Then
    '        'MsgBox(" LED0")
    '        D0 = 1
    '        LoadNewPict_D0()
    '    End If
    '    If (num = 1) Then
    '        '   MsgBox("LED 1")
    '        D1 = 1
    '        LoadNewPict_D1()
    '    End If
    '    If (num = 2) Then
    '        '    MsgBox("LED 2")
    '        D2 = 1
    '        LoadNewPict_D2()
    '    End If
    '    If (num = 3) Then
    '        '   MsgBox("LED 3")
    '        D3 = 1
    '        LoadNewPict_D3()
    '    End If
    '    If (num = 4) Then
    '        '  MsgBox("LED 4")
    '        D4 = 1
    '        LoadNewPict_D4()
    '    End If
    '    If (num = 5) Then
    '        ' MsgBox("LED 5")
    '        D5 = 1
    '        LoadNewPict_D5()
    '    End If
    '    If (num = 6) Then
    '        'MsgBox("LED 6")
    '        D6 = 1
    '        LoadNewPict_D6()
    '    End If
    '    If (num = 7) Then
    '        'MsgBox("LED 7")
    '        D7 = 1
    '        LoadNewPict_D7()
    '    End If

    'End Sub

    'cajas de verificación
#Region "Checkbox"
    Private Sub casilla1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles casilla1.CheckedChanged
        If (casilla1.Checked = True) Then
            D0 = 1
            opciones()
        Else
            D0 = 0
            opciones()
        End If

    End Sub

    Private Sub casilla2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles casilla2.CheckedChanged
        If (casilla2.Checked = True) Then
            D1 = 1
            opciones()
        Else
            D1 = 0
            opciones()
        End If
    End Sub

    Private Sub casilla3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles casilla3.CheckedChanged
        If (casilla3.Checked = True) Then
            D2 = 1
            opciones()
        Else
            D2 = 0
            opciones()
        End If
    End Sub

    Private Sub casilla4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles casilla4.CheckedChanged
        If (casilla4.Checked = True) Then
            D3 = 1
            opciones()
        Else
            D3 = 0
            opciones()
        End If
    End Sub

    Private Sub casilla5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles casilla5.CheckedChanged
        If (casilla5.Checked = True) Then
            D4 = 1
            opciones()
        Else
            D4 = 0
            opciones()
        End If
    End Sub

    Private Sub casilla6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles casilla6.CheckedChanged
        If (casilla6.Checked = True) Then
            D5 = 1
            opciones()
        Else
            D5 = 0
            opciones()
        End If
    End Sub

    Private Sub casilla7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles casilla7.CheckedChanged
        If (casilla7.Checked = True) Then
            D6 = 1
            opciones()
        Else
            D6 = 0
            opciones()
        End If
    End Sub

    Private Sub casilla8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles casilla8.CheckedChanged
        If (casilla8.Checked = True) Then
            D7 = 1
            'MsgBox(D7)
            opciones()
        Else
            D7 = 0
            opciones()
            'MsgBox(D7)
        End If
    End Sub
#End Region

    'desmarca las cajas de verificacíón
    Public Sub Reset_Box()
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is CheckBox Then
                DirectCast(ctrl, CheckBox).CheckState = CheckState.Unchecked
            End If
        Next
    End Sub

    'marca las cajas
    Private Sub Init_Box()
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is CheckBox Then
                DirectCast(ctrl, CheckBox).CheckState = CheckState.Checked
            End If
        Next
    End Sub

    'encendido de leds por binarios y marcado de casillas
    Private Sub conCo()
        'Dim OK As Integer = num
        'MsgBox(OK)
        Select Case num
            Case 0
                'MsgBox(" LED0")
                D0 = 1
                LoadNewPict_D0()
                casilla1.CheckState = CheckState.Checked
            Case 1
                'MsgBox("LED 1")
                D1 = 1
                LoadNewPict_D1()
                casilla2.CheckState = CheckState.Checked
            Case 2
                'MsgBox("LED 2")
                D2 = 1
                LoadNewPict_D2()
                casilla3.CheckState = CheckState.Checked
            Case 3
                'MsgBox("LED 3")
                D3 = 1
                LoadNewPict_D3()
                casilla4.CheckState = CheckState.Checked
            Case 4
                '  MsgBox("LED 4")
                D4 = 1
                LoadNewPict_D4()
                casilla5.CheckState = CheckState.Checked
            Case 5
                ' MsgBox("LED 5")
                D5 = 1
                LoadNewPict_D5()
                casilla6.CheckState = CheckState.Checked
            Case 6
                'MsgBox("LED 6")
                D6 = 1
                LoadNewPict_D6()
                casilla7.CheckState = CheckState.Checked
            Case 7
                'MsgBox("LED 7")
                D7 = 1
                LoadNewPict_D7()
                casilla8.CheckState = CheckState.Checked
        End Select

    End Sub

    'apagado de leds por binarios y desmarcado de casillas
    Private Sub conCf() 'apaga si recibe 0 del valor ingresado
        'Dim OK As Integer = num
        'MsgBox(OK)
        Select Case num
            Case 0
                'MsgBox(" LED0 F")
                D0 = 0
                LoadOldPict_D0()
                casilla1.CheckState = CheckState.Unchecked
            Case 1
                'MsgBox("LED 1 F")
                D1 = 0
                LoadOldPict_D1()
                casilla2.CheckState = CheckState.Unchecked
            Case 2
                'MsgBox("LED 2 F")
                D2 = 0
                LoadOldPict_D2()
                casilla3.CheckState = CheckState.Unchecked
            Case 3
                'MsgBox("LED 3 F")
                D3 = 0
                LoadOldPict_D3()
                casilla4.CheckState = CheckState.Unchecked
            Case 4
                'MsgBox("LED 4")
                D4 = 0
                LoadOldPict_D4()
                casilla5.CheckState = CheckState.Unchecked
            Case 5
                'MsgBox("LED 5")
                D5 = 0
                LoadOldPict_D5()
                casilla6.CheckState = CheckState.Unchecked
            Case 6
                'MsgBox("LED 6")
                D6 = 0
                LoadOldPict_D6()
                casilla7.CheckState = CheckState.Unchecked
            Case 7
                'MsgBox("LED 7")
                D7 = 0
                LoadOldPict_D7()
                casilla8.CheckState = CheckState.Unchecked
        End Select
    End Sub

    Private Sub Reset_LEDs2()
        D7 = 0
        D6 = 0
        D5 = 0
        D4 = 0
        D3 = 0
        D2 = 0
        D1 = 0
        D0 = 0

        LoadOldPict_D0()
        LoadOldPict_D1()
        LoadOldPict_D2()
        LoadOldPict_D3()
        LoadOldPict_D4()
        LoadOldPict_D5()
        LoadOldPict_D6()
        LoadOldPict_D7()
    End Sub

    Private Sub botonRandom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botonRandom.Click
        '    ztart = campoInicio.Text
        '   zend = campoFinal.Text
        devent = False
        If (devent = False) Then
            For c As Integer = 0 To 100
                Dim r As Random = New Random
                numero = r.Next(1, 255) 'numero entre dos valores
                binario = Convert.ToString(numero, 2)
                azr = binario.Reverse.ToArray
                For Me.num = 0 To binario.Length
                    If (azr(num) = "1") Then
                        conCo()
                    Else
                        conCf()
                    End If
                Next
                System.Threading.Thread.Sleep(200)
                Puerto_Paralelo_vb.PortInterop.Output(direccion, numero)
                'Debug.WriteLine(numero)
                'Debug.WriteLine(c)
            Next
            MessageBox.Show("La cadena fue: " + numero.ToString)
        End If
        devent = True
    End Sub

    Private Sub botonB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles botonB.Click
        '   devent = False
        numero = CInt(Math.Pow(2, 0))
        For c As Integer = 1 To 5
            For potencia As Integer = 1 To 7
                System.Threading.Thread.Sleep(200)
                Puerto_Paralelo_vb.PortInterop.Output(direccion, numero)
                numero = CInt(Math.Pow(2, potencia))
                'Debug.WriteLine(potencia)
                'Debug.WriteLine(numero)
            Next
            For potencia As Integer = 7 To 1 Step -1
                System.Threading.Thread.Sleep(200)
                Puerto_Paralelo_vb.PortInterop.Output(direccion, numero)
                numero = CInt(Math.Pow(2, potencia))
                'Debug.WriteLine(potencia)
                'Debug.WriteLine(numero)
            Next
        Next
        MessageBox.Show("Terminado")
    End Sub
End Class
