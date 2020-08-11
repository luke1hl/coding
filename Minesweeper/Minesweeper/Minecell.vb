Public Class Minecell
    Public Enum minecellview
        Button
        Mine
        Number
        Flag
        Question
    End Enum

    Private mView As minecellview
    Private mNumber As Integer
    Private mhasmine As Boolean
    Private xcord As Integer
    Private ycord As Integer
    Private mbuttoncolor As Color = Color.LightGray
    Public Property buttoncolor() As Color
        Get
            Return mbuttoncolor
        End Get
        Set(value As Color)
            mbuttoncolor = value
        End Set
    End Property
    Public Property hasmine() As Boolean
        Get
            Return mhasmine
        End Get
        Set(value As Boolean)
            mhasmine = value
        End Set
    End Property
    Public Property x As Integer
        Get
            Return xcord
        End Get
        Set(value As Integer)
            xcord = value
        End Set
    End Property
    Public Property y() As Integer
        Get
            Return ycord
        End Get
        Set(value As Integer)
            ycord = value
        End Set
    End Property
    Public Property View() As minecellview
        Get
            Return mView
        End Get
        Set(value As minecellview)
            mView = value
        End Set
    End Property
    Public Property number() As Integer
        Get
            Return mNumber

        End Get
        Set(ByVal value As Integer)
            mNumber = value
            Me.Invalidate()
        End Set
    End Property
    Private Sub Minecell_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Minecell_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Select Case mView
            Case minecellview.Button
                With e.Graphics
                    .ResetTransform()
                    .TranslateTransform(Me.Width / 2, Me.Height / 2)
                    .ScaleTransform(Me.Width / 2, Me.Height / 2)
                    .Clear(mbuttoncolor)
                    Dim topleft As New PointF(-1, -1)
                    Dim topright As New PointF(1, -1)
                    Dim bottomleft As New PointF(-1, 1)
                    Dim bottomright As New PointF(1, 1)
                    Dim mpen As New Pen(Color.Gray, 0.3)
                    .DrawLine(mpen, bottomright, bottomleft)
                    .DrawLine(mpen, bottomright, topright)
                    mpen = New Pen(Color.White, 0.3)
                    .DrawLine(mpen, topright, topleft)
                    .DrawLine(mpen, topleft, bottomleft)
                End With
            Case minecellview.Flag
                With e.Graphics
                    .ResetTransform()
                    .TranslateTransform(Me.Width / 2, Me.Height / 2)
                    .ScaleTransform(Me.Width / 2, Me.Height / 2)
                    .Clear(Color.LightGray)
                    Dim topleft As New PointF(-1, -1)
                    Dim topright As New PointF(1, -1)
                    Dim bottomleft As New PointF(-1, 1)
                    Dim bottomright As New PointF(1, 1)
                    Dim mpen As New Pen(Color.Gray, 0.3)
                    .DrawLine(mpen, bottomright, bottomleft)
                    .DrawLine(mpen, bottomright, topright)
                    mpen = New Pen(Color.White, 0.3)
                    .DrawLine(mpen, topright, topleft)
                    .DrawLine(mpen, topleft, bottomleft)

                    'drawring the actual flag
                    Dim poletop As New PointF(0, -0.7)
                    Dim polebottom As New PointF(0, 0.5)
                    Dim flagtip As New PointF(-0.7, -0.3)
                    Dim flagbottom As New PointF(0, 0.1)


                    'pole
                    mpen = New Pen(Color.Brown, 0.1)
                    .DrawLine(mpen, poletop, polebottom)
                    'flag
                    Dim fpts() As PointF = {poletop, flagtip, flagbottom}
                    Dim fbrush As New SolidBrush(Color.Red)
                    .FillPolygon(fbrush, fpts)


                End With
            Case minecellview.Mine
                With e.Graphics
                    .ResetTransform()
                    .TranslateTransform(Me.Width / 2, Me.Height / 2)
                    .ScaleTransform(Me.Width / 2, Me.Height / 2)
                    .Clear(Color.WhiteSmoke)

                    'draw the mine
                    Dim crect As New RectangleF(-0.6, -0.6, 1.2, 1.2)
                    Dim cbrush As New SolidBrush(Color.Black)
                    .FillEllipse(cbrush, crect)

                    'draw minepegs
                    Dim irad As Single = 0.5
                    Dim orad As Single = 0.8
                    Dim ppen As New Pen(Color.Black, 0.15)
                    ppen.EndCap = Drawing2D.LineCap.Round
                    For angle As Single = 0 To 1.75 * Math.PI Step 0.25 * Math.PI
                        Dim inner As New PointF(irad * Math.Cos(angle), irad * Math.Sin(angle))
                        Dim outer As New PointF(orad * Math.Cos(angle), orad * Math.Sin(angle))
                        .DrawLine(ppen, inner, outer)
                    Next

                    'draw highlights
                    Dim hrect As New RectangleF(-0.3, -0.3, 0.2, 0.2)
                    Dim wbrush As New SolidBrush(Color.White)
                    .FillRectangle(wbrush, hrect)

                    'draw border
                    Dim brect As New Rectangle(-1, -1, 2, 2)
                    Dim bpen As New Pen(Color.Gray, 0.05)
                    .DrawRectangle(bpen, brect)
                End With
            Case minecellview.Number
                Dim Ncolours() As Color = {Color.Blue, Color.Green, Color.Red,
                    Color.Navy, Color.DarkGreen, Color.DarkRed,
                    Color.Brown, Color.Black}
                With e.Graphics
                    .ResetTransform()
                    .TranslateTransform(Me.Width / 2, Me.Height / 2)
                    .ScaleTransform(Me.Width / 2, Me.Height / 2)
                    .Clear(Color.WhiteSmoke)
                    If mNumber > 0 And mNumber <= 8 Then
                        'draw number
                        Dim NBrush As New SolidBrush(Ncolours(mNumber - 1))
                        Dim myfont As New Font("comic sans", 1.5, FontStyle.Bold, GraphicsUnit.World)
                        Dim SS As SizeF = .MeasureString(mNumber.ToString, myfont)
                        .DrawString(mNumber.ToString, myfont, NBrush, -SS.Width / 2, -SS.Height / 2)
                    End If

                    'boarder
                    Dim brect As New Rectangle(-1, -1, 2, 2)
                    Dim bpen As New Pen(Color.Gray, 0.05)
                    .DrawRectangle(bpen, brect)
                End With

            Case minecellview.Question
                With e.Graphics
                    .ResetTransform()
                    .TranslateTransform(Me.Width / 2, Me.Height / 2)
                    .ScaleTransform(Me.Width / 2, Me.Height / 2)
                    .Clear(Color.LightGray)
                    'draw number
                    Dim NBrush As New SolidBrush(Color.DarkGreen)
                    Dim myfont As New Font("comic sans", 1.5, FontStyle.Bold, GraphicsUnit.World)
                    Dim SS As SizeF = .MeasureString("?", myfont)
                    .DrawString("?", myfont, NBrush, -SS.Width / 2, -SS.Height / 2)
                    Dim topleft As New PointF(-1, -1)
                    Dim topright As New PointF(1, -1)
                    Dim bottomleft As New PointF(-1, 1)
                    Dim bottomright As New PointF(1, 1)
                    Dim mpen As New Pen(Color.Gray, 0.3)
                    .DrawLine(mpen, bottomright, bottomleft)
                    .DrawLine(mpen, bottomright, topright)
                    mpen = New Pen(Color.White, 0.3)
                    .DrawLine(mpen, topright, topleft)
                    .DrawLine(mpen, topleft, bottomleft)
                End With
        End Select
    End Sub
End Class
