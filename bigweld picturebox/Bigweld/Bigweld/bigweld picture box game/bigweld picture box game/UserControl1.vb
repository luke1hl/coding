Module module1
    Sub main()

        Application.Run()
    End Sub
End Module
Public Class UserControl1
    Dim emptyx As Integer
    Dim emptyy As Integer
    Dim picturex As Integer
    Dim picturey As Integer
    Dim locationting As Integer
    Dim direction As String
    Dim emptylocation As Integer
    Dim grid(2, 2) As picturegrid
    Dim igrid(2, 2) As Object
    Dim objectholder As Object
    Dim won As Boolean = False
    Structure picturegrid
        Dim location As Integer
        Dim locationx As Integer
        Dim locationy As Integer
    End Structure
    Sub didyouwin()
        If won = False And findlocation(picture1) = 1 And findlocation(picture2) = 2 And findlocation(picture3) = 3 And findlocation(picture4) = 4 And findlocation(picture5) = 5 And findlocation(picture6) = 6 And findlocation(picture7) = 7 And findlocation(picture8) = 8 Then

            won = True
            Timer1.Enabled = False
            MsgBox("won you!")
            Environment.Exit(0)
        End If
    End Sub
    Sub mixitup()
        Randomize()
        For i = 0 To Int((100 * Rnd()) + 20)
            Dim randomnumbery = Int((3 * Rnd()) + 0)
            Dim randomnumberx = Int((3 * Rnd()) + 0)
            Dim randomnumberytwo = Int((3 * Rnd()) + 0)
            Dim randomnumberxtwo = Int((3 * Rnd()) + 0)
            objectholder = igrid(randomnumberx, randomnumbery).location

            igrid(randomnumberx, randomnumbery).location = igrid(randomnumberxtwo, randomnumberytwo).location
            igrid(randomnumberxtwo, randomnumberytwo).location = objectholder

        Next

    End Sub
    Function findlocation(sender As Object)
        ' MsgBox(sender.location.X & sender.location.y)
        locationting = 0
        If sender.location.x = 214 And sender.location.y = 29 Then
            locationting = 1
        ElseIf sender.location.x = 340 And sender.location.y = 29 Then
            locationting = 2

        ElseIf sender.location.x = 466 And sender.location.y = 29 Then
            locationting = 3

        ElseIf sender.location.x = 214 And sender.location.y = 155 Then
            locationting = 4

        ElseIf sender.location.x = 340 And sender.location.y = 155 Then
            locationting = 5

        ElseIf sender.location.x = 466 And sender.location.y = 155 Then
            locationting = 6

        ElseIf sender.location.x = 214 And sender.location.y = 281 Then
            locationting = 7
        ElseIf sender.location.x = 340 And sender.location.y = 281 Then
            locationting = 8

        ElseIf sender.location.x = 466 And sender.location.y = 281 Then
            locationting = 9

        End If
        ' MsgBox(locationting)
        Return locationting
    End Function
    Function processor(locating)
        emptylocation = findlocation(empty)
        If locating = 1 Then
            If emptylocation = 2 Then
                Return "right"
            ElseIf emptylocation = 4 Then
                Return "below"
            Else
                Return "null"
            End If
        ElseIf locating = 2 Then
            If emptylocation = 3 Then
                Return "right"
            ElseIf emptylocation = 5 Then
                Return "below"
            ElseIf emptylocation = 1 Then
                Return "left"
            Else
                Return "null"
            End If
        ElseIf locating = 3 Then
            If emptylocation = 2 Then
                Return "left"
            ElseIf emptylocation = 6 Then
                Return "below"
            Else
                Return "null"
            End If
        ElseIf locating = 4 Then
            If emptylocation = 5 Then
                Return "right"
            ElseIf emptylocation = 7 Then
                Return "below"
            ElseIf emptylocation = 1 Then
                Return "above"
            Else
                Return "null"
            End If
        ElseIf locating = 5 Then
            If emptylocation = 6 Then
                Return "right"
            ElseIf emptylocation = 8 Then
                Return "below"
            ElseIf emptylocation = 4 Then
                Return "left"
            ElseIf emptylocation = 2 Then
                Return "above"
            Else
                Return "null"
            End If
        ElseIf locating = 6 Then
            If emptylocation = 5 Then
                Return "left"
            ElseIf emptylocation = 9 Then
                Return "below"
            ElseIf emptylocation = 3 Then
                Return "above"
            Else
                Return "null"
            End If
        ElseIf locating = 7 Then
            If emptylocation = 8 Then
                Return "right"
            ElseIf emptylocation = 4 Then
                Return "above"

            Else
                Return "null"
            End If
        ElseIf locating = 8 Then
            If emptylocation = 9 Then
                Return "right"
            ElseIf emptylocation = 5 Then
                Return "above"
            ElseIf emptylocation = 7 Then
                Return "left"
            Else
                Return "null"
            End If
        ElseIf locating = 9 Then
            If emptylocation = 8 Then
                Return "left"
            ElseIf emptylocation = 6 Then
                Return "above"

            Else
                Return "null"
            End If
        End If
    End Function

    Sub moving(sender As Object)

        If direction = "above" Then
            sender.top -= 1
            empty.Top += 1
        ElseIf direction = "below" Then
            sender.top += 1
            empty.Top -= 1
        ElseIf direction = "right" Then
            sender.left += 1
            empty.Left -= 1
        ElseIf direction = "left" Then
            sender.left -= 1
            empty.Left += 1
        End If

    End Sub
    Sub swap(sender As Object)
        Dim counter As Integer = 0
        emptyx = empty.Location.X
        emptyy = empty.Location.Y

        While counter <= 125
            Threading.Thread.Sleep(1)
            moving(sender)
            counter += 1
        End While


    End Sub

    Private Sub UserControl1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        emptyx = empty.Location.X
        emptyy = empty.Location.Y
        grid(0, 0).location = 1 And grid(0, 0).locationx = 214 And grid(0, 0).locationy = 29
        grid(1, 0).location = 2 And grid(1, 0).locationx = 340 And grid(1, 0).locationy = 29
        grid(2, 0).location = 3 And grid(2, 0).locationx = 466 And grid(2, 0).locationy = 29
        grid(0, 1).location = 4 And grid(0, 0).locationx = 214 And grid(0, 0).locationy = 155
        grid(1, 1).location = 5 And grid(1, 0).locationx = 340 And grid(1, 0).locationy = 155
        grid(2, 1).location = 6 And grid(2, 0).locationx = 466 And grid(2, 0).locationy = 155
        grid(0, 2).location = 7 And grid(0, 0).locationx = 214 And grid(0, 0).locationy = 281
        grid(1, 2).location = 8 And grid(1, 0).locationx = 340 And grid(1, 0).locationy = 281
        grid(2, 2).location = 9 And grid(2, 0).locationx = 466 And grid(2, 0).locationy = 281
        igrid(1, 1) = picture5
        igrid(1, 2) = picture8
        igrid(0, 0) = picture1
        igrid(1, 0) = picture2
        igrid(2, 0) = picture3
        igrid(0, 1) = picture4
        igrid(2, 1) = picture6
        igrid(0, 2) = picture7
        igrid(2, 2) = empty
        mixitup()

    End Sub

    Private Sub picture1_Click(sender As Object, e As EventArgs) Handles picture1.Click
        direction = processor(findlocation(sender))
        ' MsgBox(direction)
        If direction <> "null" Then
            swap(sender)
        End If

    End Sub

    Private Sub picture2_Click(sender As Object, e As EventArgs) Handles picture2.Click
        direction = processor(findlocation(sender))
        ' MsgBox(direction)
        If direction <> "null" Then
            swap(sender)
        End If

    End Sub

    Private Sub picture3_Click(sender As Object, e As EventArgs) Handles picture3.Click
        direction = processor(findlocation(sender))
        ' MsgBox(direction)
        If direction <> "null" Then
            swap(sender)
        End If

    End Sub

    Private Sub picture4_Click(sender As Object, e As EventArgs) Handles picture4.Click
        direction = processor(findlocation(sender))
        ' MsgBox(direction)
        If direction <> "null" Then
            swap(sender)
        End If

    End Sub

    Private Sub picture5_Click(sender As Object, e As EventArgs) Handles picture5.Click
        direction = processor(findlocation(sender))
        ' MsgBox(direction)
        If direction <> "null" Then
            swap(sender)
        End If

    End Sub

    Private Sub picture6_Click(sender As Object, e As EventArgs) Handles picture6.Click
        direction = processor(findlocation(sender))
        ' MsgBox(direction)
        If direction <> "null" Then
            swap(sender)
        End If

    End Sub

    Private Sub picture7_Click(sender As Object, e As EventArgs) Handles picture7.Click
        direction = processor(findlocation(sender))
        ' MsgBox(direction)
        If direction <> "null" Then
            swap(sender)
        End If

    End Sub

    Private Sub picture8_Click(sender As Object, e As EventArgs) Handles picture8.Click
        direction = processor(findlocation(sender))
        ' MsgBox(direction)
        If direction <> "null" Then
            swap(sender)
        End If

    End Sub

    Private Sub empty_Click(sender As Object, e As EventArgs) Handles empty.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        didyouwin()
    End Sub
End Class
