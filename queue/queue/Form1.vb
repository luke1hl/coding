Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1
    Dim queuefrontx As Integer = 250
    Dim queuefronty As Integer = 140
    Dim numberinqueue As Integer = 0
    Dim yellowempty As Boolean = True
    Dim blueempty As Boolean = True
    Dim greenempty As Boolean = True
    Dim peoples As New Queue(Of PictureBox)()
    Dim ontheatms As New Queue(Of PictureBox)()
    Dim greenatm As PictureBox
    Dim yellowatm As PictureBox
    Dim blueatm As PictureBox
    Private inqueue As New Series

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Timer1.Interval = randomnumber(100, 200)
        initGraph()
    End Sub
    Sub loopover()

        Timer1.Interval = randomnumber(1000, 3000)
    End Sub
    Sub movethelist()
        For i = 0 To numberinqueue - 1
            If numberinqueue <> 0 Then
                peoples(i).Top -= 50

            End If
        Next
    End Sub
    Function randomnumber(lower As Integer, upper As Integer)
        Randomize()
        Return Int((upper * Rnd()) + lower)
    End Function
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        loopover()
        newqueuemember()
    End Sub
    Sub shiftthelist()
        peoples.Dequeue()

        For i = 1 To numberinqueue

        Next
    End Sub
    Private Sub newqueuemember()
        'If numberinqueue < 10 Then
        numberinqueue += 1
        Dim pictureBox As New PictureBox
        Controls.Add(pictureBox)
        pictureBox.Width = 50

        pictureBox.Visible = True
        pictureBox.Height = 50
        Dim selectperson As Integer = randomnumber(1, 3)
        If selectperson = 1 Then
            pictureBox.Image = My.Resources.person1

        ElseIf selectperson = 2 Then
            pictureBox.Image = My.Resources.person2

        Else
            pictureBox.Image = My.Resources.person3

        End If
        pictureBox.Location = New Point(250, queuefronty + 50 * numberinqueue)
        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage

        peoples.Enqueue(pictureBox)
        'End If

    End Sub

    Private Sub MovefrontGreen(sender As Object)

        ontheatms.Enqueue(sender)
        greenatm = sender
        Do Until sender.Location.X = 436
            sender.Left += 1
        Loop
        Do Until sender.Location.Y = 90
            sender.Top -= 1
        Loop
        movethelist()
        greentimer()
    End Sub

    Private Sub MovefrontYellow(sender As Object)
        ontheatms.Enqueue(sender)
        yellowatm = sender
        Do Until sender.Location.X = 250
            sender.Left -= 1
        Loop
        Do Until sender.Location.Y = 90
            sender.Top -= 1
        Loop
        movethelist()
        yellowtimer()
    End Sub

    Private Sub Movefrontblue(sender As Object)
        ontheatms.Enqueue(sender)
        blueatm = sender
        'MsgBox(sender.location.x & " " & sender.location.y)
        Do Until sender.Location.X = 74
            sender.Left -= 1
        Loop
        Do Until sender.Location.Y = 90
            sender.Top -= 1
        Loop
        movethelist()
        bluetimer()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If greenempty = True Then
            If numberinqueue <> 0 Then
                greenempty = False

                numberinqueue -= 1

                MovefrontGreen(peoples.Dequeue)
                '  shiftthelist()
            End If

        ElseIf yellowempty = True Then
            If numberinqueue <> 0 Then
                yellowempty = False

                numberinqueue -= 1

                MovefrontYellow(peoples.Dequeue)
                'shiftthelist()
            End If

        ElseIf blueempty = True Then
            If numberinqueue <> 0 Then
                blueempty = False

                numberinqueue -= 1

                Movefrontblue(peoples.Dequeue)
                ' shiftthelist()

            End If
        End If
    End Sub
    Private Sub initGraph()
        Graph.Name = ""
        Graph.ChartAreas(0).AxisX.LabelStyle.Enabled = False

        Graph.Series.Clear()
        inqueue.Points.Clear()

        inqueue.Name = "number in queue"

        inqueue.ChartType = SeriesChartType.Line

        inqueue.Color = Color.Green

        Graph.Series.Add(inqueue)


    End Sub
    Dim timercounter As Double = 0
    Private Sub UpdateGraph()
        timercounter += 0.05
        inqueue.Points.AddXY(timercounter, numberinqueue)

    End Sub
    Dim bluecounter As Integer = 0
    Dim yellowcounter As Integer = 0
    Dim greencounter As Integer = 0
    Dim numbablue As Integer
    Dim numbayellow As Integer
    Dim numbagreen As Integer
    Sub greentimer()
        numbagreen = randomnumber(500, 1000)
        greencounter = 0
        green.Enabled = True
    End Sub
    Sub yellowtimer()
        numbayellow = randomnumber(500, 1000)
        yellowcounter = 0
        yellow.Enabled = True

    End Sub

    Sub bluetimer()
        numbablue = randomnumber(500, 1000)
        bluecounter = 0
        Blue.Enabled = True

    End Sub

    Private Sub Blue_Tick(sender As Object, e As EventArgs) Handles Blue.Tick
        bluecounter += 100
        If bluecounter >= numbablue Then
            blueatm.Visible = False
            blueempty = True
            Blue.Enabled = False
        End If
    End Sub

    Private Sub yellow_Tick(sender As Object, e As EventArgs) Handles yellow.Tick
        yellowcounter += 100
        If yellowcounter >= numbayellow Then
            yellowatm.Visible = False
            yellowempty = True
            yellow.Enabled = False
        End If
    End Sub

    Private Sub green_Tick(sender As Object, e As EventArgs) Handles green.Tick
        greencounter += 100
        If greencounter >= numbagreen Then

            greenatm.Visible = False
            greenempty = True
            green.Enabled = False
        End If
    End Sub

    Private Sub graphing_Tick(sender As Object, e As EventArgs) Handles graphing.Tick
        UpdateGraph()
        Label1.Text = numberinqueue
    End Sub
End Class
