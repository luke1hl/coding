Public Class Form1

    Public mygraphics As Graphics

    Public mypen As Pen

    Public mybrush As Brush

    Public brusher As Brush
    Dim died As Boolean                     'stores if you have died by overfilling grid

    Public Structure piece                  'stores the single current block that is falling

        Public x() As Integer               'x-coordinate of block in grid

        Public y() As Integer               'y-coordinate of block in grid

        Public centrex, centrey As Double   'centre of block - needed for using as the centre of rotation of the block

        Public blocktype As Integer         'type of block 1-6 for the different shaped blocks

    End Structure

    Private block As piece

    Private board(10, 20) As Integer        'holds contents of grid - needed as whole rows will be eliminated when full

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mygraphics = PictureBox1.CreateGraphics()

        Initialise()

    End Sub



    Private Function rand(ByVal low As Integer, ByVal high As Integer) As Integer

        rand = Int((high - low + 1) * Rnd()) + low

    End Function



    Public Sub newblock()               'starts a new block from the top

        Dim typeofblock As Integer

        typeofblock = rand(1, 6)

        Select Case typeofblock

            Case 1                      'backwards L-shape

                block.x(0) = 5

                block.y(0) = 0

                block.x(1) = 6

                block.y(1) = 0

                block.x(2) = 7

                block.y(2) = 0

                block.x(3) = 7

                block.y(3) = 1

                block.centrex = 6

                block.centrey = 1

            Case 2                      'L-shape

                block.x(0) = 5

                block.y(0) = 1

                block.x(1) = 6

                block.y(1) = 1

                block.x(2) = 7

                block.y(2) = 1

                block.x(3) = 7

                block.y(3) = 0

                block.centrex = 6

                block.centrey = 0

            Case 3                      'square

                block.x(0) = 5

                block.y(0) = 0

                block.x(1) = 5

                block.y(1) = 1

                block.x(2) = 6

                block.y(2) = 0

                block.x(3) = 6

                block.y(3) = 1

                block.centrex = 5

                block.centrey = 0

            Case 4                      'column

                block.x(0) = 5

                block.y(0) = 0

                block.x(1) = 6

                block.y(1) = 0

                block.x(2) = 6

                block.y(2) = 1

                block.x(3) = 7

                block.y(3) = 1

                block.centrex = 5

                block.centrey = 1

            Case 5                      'zigzag 1

                block.x(0) = 5

                block.y(0) = 0

                block.x(1) = 6

                block.y(1) = 0

                block.x(2) = 4

                block.y(2) = 1

                block.x(3) = 5

                block.y(3) = 1

                block.centrex = 6

                block.centrey = 1

            Case 6                      'zigzag 2

                block.x(0) = 5

                block.y(0) = 0

                block.x(1) = 5

                block.y(1) = 1

                block.x(2) = 5

                block.y(2) = 2

                block.x(3) = 5

                block.y(3) = 3

                block.centrex = 5

                block.centrey = 2

        End Select

        block.blocktype = typeofblock

    End Sub



    Public Sub Initialise()

        Randomize()

        For a = 0 To 9              'sets whole grid to be empty

            For b = 0 To 19

                board(a, b) = 0

            Next

        Next

        ReDim block.x(4)

        ReDim block.y(4)

        newblock()                  'puts initial block at the top

        died = False

    End Sub



    Public Sub setpencolour(choice As Integer)      'chooses colour depending on type of piece

        Select Case choice

            Case 0

                mypen = New Pen(Drawing.Color.LightGray, 2)
                brusher = New SolidBrush(Color.White)


            Case 1

                mypen = New Pen(Drawing.Color.Red, 2)
                brusher = New SolidBrush(Color.Pink)


            Case 2

                mypen = New Pen(Drawing.Color.DarkGreen, 2)
                brusher = New SolidBrush(Color.Lime)

            Case 3

                mypen = New Pen(Drawing.Color.Blue, 2)
                brusher = New SolidBrush(Color.SkyBlue)


            Case 4

                mypen = New Pen(Drawing.Color.Gold, 2)
                brusher = New SolidBrush(Color.Yellow)


            Case 5

                mypen = New Pen(Drawing.Color.Purple, 2)
                brusher = New SolidBrush(Color.MediumPurple)


            Case 6

                mypen = New Pen(Drawing.Color.Brown, 2)
                brusher = New SolidBrush(Color.Orange)


        End Select

    End Sub

    Public Sub display()                        'draws grid including used pieces AND draws current block

        Dim myrect As New Rectangle

        mygraphics.Clear(Drawing.Color.Black)



        myrect.X = 47                           'these six lines just draw an outer box around the grid

        myrect.Y = 87

        myrect.Width = 106

        myrect.Height = 165

        mypen = New Pen(Drawing.Color.White, 5)

        mygraphics.DrawRectangle(mypen, myrect)



        For a = 0 To 9

            For b = 0 To 19

                setpencolour(board(a, b))

                If board(a, b) <> 0 Then

                    myrect.X = 50 + a * 10      'grid drawn on screen with 50 border on left and top and each cell is 10x10 square

                    myrect.Y = 50 + b * 10

                    myrect.Width = 10

                    myrect.Height = 10

                    mygraphics.DrawRectangle(mypen, myrect)
                    mygraphics.FillRectangle(brusher, myrect)


                End If

            Next

        Next



        setpencolour(block.blocktype)           'draws each of the four elements of the current block (0-3)

        For a = 0 To 3

            myrect.X = 50 + block.x(a) * 10

            myrect.Y = 50 + block.y(a) * 10

            myrect.Width = 10

            myrect.Height = 10

            mygraphics.DrawRectangle(mypen, myrect)
            mygraphics.FillRectangle(brusher, myrect)

        Next

    End Sub



    Public Sub fall()                           'lets current block fall if it can

        Dim canfall = True                      'can the block fall or is there something in the way

        Dim hitbottom = False                   'has the block hit the bottom of the grid

        For a = 0 To 3

            If (board(block.x(a), block.y(a) + 1) <> 0) Then    'if there is something where the block would go then it cannot fall

                canfall = False

            End If

            If (block.y(a) + 1) > 19 Then                       'if the block goes below 19 rows down then it has hit the bottom

                hitbottom = True

            End If

        Next

        If ((canfall = True) And (hitbottom = False)) Then      'if ok to fall then add one to y-coordinates of each element of block

            For a = 0 To 3

                block.y(a) += 1

            Next

            block.centrey += 1                                  'the centre of mass of block needs moving as well

        End If

        If ((hitbottom = True) Or (canfall = False)) Then       'when piece has finished falling then it is copied onto the grid

            For a = 0 To 3

                board(block.x(a), block.y(a)) = block.blocktype

                If block.y(a) < 4 Then                          'if piece still has any part in the top 3 rows then you have died

                    died = True

                End If

            Next

            If died = True Then

                TextBox1.Text = "you died"

            End If

            If died = False Then

                newblock()

            End If

        End If

    End Sub

    Private Sub checklines()
        Dim isitfull As Boolean
        For a = 19 To 4 Step -1
            isitfull = True
            For b = 0 To 9
                If (board(b, a) = 0) Then
                    isitfull = False
                End If
            Next
            If isitfull = True Then
                For c = a To 4 Step -1
                    For d = 0 To 9
                        board(d, c) = board(d, c - 1)
                    Next
                Next
                Label1.Text = CInt(Label1.Text) + 50
            End If
        Next
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If died = False Then
            checklines()
            display()

            fall()

        End If

    End Sub



    Private Sub moveblcok(xoffset As Integer)          'moves the block across by +1 or -1 depending what xoffset is set to

        Dim canmove As Boolean

        canmove = True

        For a = 0 To 3

            If ((block.x(a) + xoffset > 9) Or (block.x(a) + xoffset < 0)) Then      'cannot go off grid

                canmove = False

            End If

        Next

        If canmove = True Then                              'if ok to move then move block

            For a = 0 To 3

                block.x(a) += xoffset

            Next

            block.centrex += xoffset                        'also move the centre of mass of the block

        End If

    End Sub



    Private Sub rotateblock(direction As Integer)                               'rotates the block clockwise

        Dim newpositionblock As piece

        Dim temp As Integer

        Dim canrotate As Boolean = True

        ReDim newpositionblock.x(4)

        ReDim newpositionblock.y(4)

        If block.blocktype = 3 Then                             'cannot rotate the square pieces

            canrotate = False

        End If

        For a = 0 To 3

            newpositionblock.x(a) = block.x(a) - block.centrex  'move the coordinates to the origin

            newpositionblock.y(a) = block.y(a) - block.centrey


            If direction = 1 Then
                temp = newpositionblock.x(a)                        'to rotate 90 degrees clockwise (x,y) maps to (y,-x)

                newpositionblock.x(a) = newpositionblock.y(a)

                newpositionblock.y(a) = -temp

            ElseIf direction = 2 Then
                temp = newpositionblock.x(a)                        'to rotate 90 degrees clockwise (x,y) maps to (y,-x)

                newpositionblock.x(a) = newpositionblock.y(a)

                newpositionblock.y(a) = temp
            End If



            newpositionblock.x(a) = newpositionblock.x(a) + block.centrex   'move the coordinates back to where it was

            newpositionblock.y(a) = newpositionblock.y(a) + block.centrey

        Next

        For a = 0 To 3                          'if any of the blocks have rotated off the grid then it cannot rotate

            If ((newpositionblock.x(a) > 9) Or (newpositionblock.x(a) < 0) Or (newpositionblock.y(a) < 0)) Then

                canrotate = False

            End If

        Next

        If canrotate = True Then                'if any of the blocks rotate to being on top of something then it cannot rotate

            For a = 0 To 3

                If board(newpositionblock.x(a), newpositionblock.y(a)) <> 0 Then

                    canrotate = False

                End If

            Next

        End If

        If canrotate = True Then                'if ok to rotate then rotate block

            For a = 0 To 3

                block.x(a) = newpositionblock.x(a)

                block.y(a) = newpositionblock.y(a)

            Next

        End If

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean  'deals with key presses

        If keyData = Keys.Left Then

            moveblcok(-1)
            If keyData <> Keys.Down Then
                Timer1.Interval = 300
            End If
        ElseIf keyData = Keys.Right Then

            moveblcok(1)
            If keyData <> Keys.Down Then
                Timer1.Interval = 300
            End If
        ElseIf keyData = Keys.Down Then
            Timer1.Interval = 100

        ElseIf keyData = Keys.Up Then
            rotateblock(1)
            If keyData <> Keys.Down Then
                Timer1.Interval = 300
            End If
        ElseIf keyData <> Keys.Down Then
            Timer1.Interval = 300
        End If



        Return True

    End Function

End Class