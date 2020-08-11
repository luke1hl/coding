Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1
    Dim ticker As Integer = 0
    Dim arty As Boolean = False
    Dim timercounter As Integer = 0
    Private Pinky As New Series
    Private inf As New Series
    Private Blacky As New Series
    Private d As New Series
    Dim sizing = New Size(62, 200)
    Dim heightpink As Integer = 196
    Dim heighblack As Integer = 4
    Public mygraphics As Graphics
    Public mypen As Pen
    Public numoballs As Integer = 50
    Public howbig As Integer = 8

    Structure ball
        Dim xpos As Double                  'x-coordinate of ball
        Dim ypos As Double                  'y-coordinate of ball
        Dim infected As Boolean
        Dim velx As Double
        Dim vely As Double
        Dim timeleft As Integer
    End Structure

    Dim balls(500) As ball                  'maximum number of balls is 200

    Private Function rand(ByVal low As Integer, ByVal high As Integer) As Integer

        rand = Int((high - low + 1) * Rnd()) + low

    End Function



    Private Sub initialise()
        Tickspeed.Value = 101 - Timer1.Interval
        Label4.Text = numoballs - 1
        Label3.Text = 1
        initGraph()
        heightpink = numoballs * 4 - 4
        heighblack = 4
        Randomize()

        For a = 0 To numoballs - 1

            balls(a).xpos = rand(100, 300)

            balls(a).ypos = rand(100, 300)

            balls(a).infected = 0

            balls(a).velx = rand(-5, 5)

            balls(a).vely = rand(-5, 5)

            balls(a).timeleft = 0

        Next

        balls(0).infected = True


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mygraphics = PictureBox2.CreateGraphics()

        initialise()

    End Sub



    Private Sub drawborder()

        Dim myrect As Rectangle

        mypen = New Pen(Drawing.Color.ForestGreen, 5)

        myrect.X = 0

        myrect.Y = 0

        myrect.Width = 585

        myrect.Height = 585

        mygraphics.DrawRectangle(mypen, myrect)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = 101 - Tickspeed.Value
        UpdateGraph()
        Dim myrect As Rectangle

        Dim a As Integer
        Label4.Text = heightpink / 4
        Label3.Text = heighblack / 4

        ticker += 1
        If ticker = 200 And arty = True Then
            mygraphics.Clear(Drawing.Color.White)
            ticker = 0
        ElseIf arty = False Then
            mygraphics.Clear(Drawing.Color.White)
        End If

        drawborder()

        Dim numberofinfected = 0
        For a = 0 To numoballs - 1
            If balls(a).infected = True Then
                numberofinfected += 1
            End If
        Next
        If numberofinfected = 0 Then
            balls(0).infected = True

        End If
        For a = 0 To numoballs - 1

            myrect.X = Math.Round(balls(a).xpos - 0.5 * howbig)
            myrect.Y = Math.Round(balls(a).ypos - 0.5 * howbig)
            myrect.Height = howbig
            myrect.Width = howbig


            Select Case balls(a).infected

                Case True

                    mypen = New Pen(Drawing.Color.Black, 2)          'uninfected

                Case False
                    mypen = New Pen(Drawing.Color.Fuchsia, 2)           'infected
            End Select

            mygraphics.DrawArc(mypen, myrect, 0, 360)
        Next
        For a = 0 To numoballs - 1
            balls(a).timeleft -= 10
        Next
        For a = 0 To numoballs - 1                                                               'move balls
            If balls(a).xpos < (howbig / 2) Then balls(a).velx = -balls(a).velx             'deal with hitting left wall
            If balls(a).ypos < (howbig / 2) Then balls(a).vely = -balls(a).vely             'deal with hitting top wall
            If balls(a).xpos > (585 - (howbig / 2)) Then balls(a).velx = -balls(a).velx     'deal with hitting right wall
            If balls(a).ypos > (585 - (howbig / 2)) Then balls(a).vely = -balls(a).vely     'deal with hitting bottom wall
            balls(a).xpos = balls(a).xpos + balls(a).velx                                      'change position by velocity
            balls(a).ypos = balls(a).ypos + balls(a).vely
        Next


        For a = 0 To numoballs - 2                    'check all pairs of balls for collisions

            For b = a + 1 To numoballs - 1

                If (((balls(a).xpos - balls(b).xpos) ^ 2) + ((balls(a).ypos - balls(b).ypos) ^ 2)) < (howbig ^ 2) Then

                    If balls(a).infected = False And balls(b).infected = True Then         'uninfected ball hits infected ball

                        balls(a).infected = True
                        balls(a).timeleft = 50
                        heightpink -= 4
                        pink.Height = heightpink
                        heighblack += 4

                        black.Height = heighblack

                    End If

                    If balls(b).infected = False And balls(a).infected = True Then         'infected ball hits uninfected ball

                        balls(b).infected = True
                        balls(b).timeleft = 50
                        heightpink -= 4
                        pink.Height = heightpink
                        heighblack += 4
                        black.Height = heighblack


                    End If
                    If balls(a).infected = True And balls(b).infected = True And balls(a).timeleft <= 0 And balls(b).timeleft <= 0 Then
                        balls(a).infected = False

                        balls(b).infected = False
                        heightpink += 8
                        pink.Height = heightpink
                        heighblack -= 8
                        black.Height = heighblack
                    End If


                    'passes the velocities and coordinates of the two colliding balls, subroutine changes the velocities (call by ref)

                    collision(balls(a).velx, balls(a).vely, balls(b).velx, balls(b).vely, balls(a).xpos, balls(a).ypos, balls(b).xpos, balls(b).ypos)

                End If

            Next

        Next

    End Sub

    Private Sub initGraph()
        graph.Name = ""
        graph.ChartAreas(0).AxisX.LabelStyle.Enabled = False

        graph.Series.Clear()
        Pinky.Points.Clear()
        Blacky.Points.Clear()

        Pinky.Name = "Healthy"
        Blacky.Name = "Infected"

        Pinky.ChartType = SeriesChartType.Line
        Blacky.ChartType = SeriesChartType.Line

        Pinky.Color = Color.Magenta
        Blacky.Color = Color.Black

        graph.Series.Add(Pinky)
        graph.Series.Add(Blacky)


    End Sub

    Private Sub UpdateGraph()
        timercounter += 1
        Pinky.Points.AddXY(timercounter, CInt(Label4.Text))
        Blacky.Points.AddXY(timercounter, CInt(Label3.Text))
    End Sub

    Private Sub collision(ByRef vx1 As Double, ByRef vy1 As Double, ByRef vx2 As Double, ByRef vy2 As Double, ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double)

        Dim dotproduct1, dotproduct2 As Double

        Dim distsquared As Double

        dotproduct1 = ((vx1 - vx2) * (x1 - x2)) + ((vy1 - vy2) * (y1 - y2))

        dotproduct2 = ((vx2 - vx1) * (x2 - x1)) + ((vy2 - vy1) * (y2 - y1))

        distsquared = ((x1 - x2) ^ 2) + ((y1 - y2) ^ 2)
        If distsquared <> 0 And dotproduct1 <> 0 And dotproduct2 <> 0 Then

            vx1 = vx1 - (dotproduct1 / distsquared) * (x1 - x2)

            vx2 = vx2 - (dotproduct2 / distsquared) * (x2 - x1)

            vy1 = vy1 - (dotproduct1 / distsquared) * (y1 - y2)

            vy2 = vy2 - (dotproduct2 / distsquared) * (y2 - y1)
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        numoballs = CInt(TextBox1.Text)
        Timer1.Interval = CInt(TextBox2.Text)
        initialise()

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub art_CheckedChanged(sender As Object, e As EventArgs) Handles art.CheckedChanged
        If art.Checked = True Then
            arty = True
        Else
            arty = False
        End If
    End Sub
End Class

