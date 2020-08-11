Public Class Form1
    Dim cellsize As Integer = 20
    Dim lost As Boolean = False
    Dim boardrows As Integer = 9
    Dim boardcols As Integer = 9
    Dim minecount As Integer = 11
    Dim seconds As Integer = 0
    Dim markedmines As Integer = 0
    Dim minefield(8, 8) As Minecell
    Dim cheatson As Boolean = False
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.E Then

            Me.Hide()
            If cheatson = False Then
                MsgBox("cheats activated")
                My.Computer.Audio.Play(My.Resources.Lightsaber_Turn_On_SoundBible_com_647586083, AudioPlayMode.Background)
                cheatson = True
                For row = 0 To boardrows - 1
                    For col = 0 To boardcols - 1
                        If minefield(row, col).hasmine Then
                            minefield(row, col).buttoncolor = Color.Red
                            Refresh()
                        End If

                        If minefield(row, col).number > 0 Then
                            If cheatson = True Then
                                minefield(row, col).buttoncolor = Color.Green
                                Refresh()
                            End If

                            '  minefield(row, col).View = Minecell.minecellview.Number
                        End If
                    Next
                Next



            Else
                cheatson = False
                MsgBox("cheats deactivating")
                My.Computer.Audio.Play(My.Resources.Lightsaber_Turn_Off_SoundBible_com_726724693, AudioPlayMode.Background)

                For row = 0 To boardrows - 1
                    For col = 0 To boardcols - 1
                        minefield(row, col).buttoncolor = Color.LightGray
                        Refresh()
                    Next
                Next
            End If
        End If
        Me.Show()
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Set fixed border
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        'Disable the minimize box And the maximize box
        Me.MinimizeBox = False
        Me.MaximizeBox = False

        buildboard()



    End Sub

    Private Sub buildboard()
        labelmessage.Text = ""
        Button1.Image = My.Resources.smiley1
        lost = False
        ReDim minefield(boardrows + 10, boardcols + 10)
        markedmines = 0
        Timer1.Enabled = False
        seconds = 0
        dolabels()
        cheatson = False
        Me.Hide()
        'loop through rows and collums
        ReDim minefield(boardrows - 1, boardcols - 1)
        Panelmine.Controls.Clear()
        For row As Integer = 0 To boardrows - 1
            For col As Integer = 0 To boardcols - 1
                Dim c As New Minecell
                Panelmine.Controls.Add(c)
                c.Left = cellsize * col
                c.Top = cellsize * row
                c.Width = cellsize
                c.Height = cellsize
                c.hasmine = False
                c.number = 0
                c.x = col
                c.y = row
                c.View = Minecell.minecellview.Button
                minefield(row, col) = c
                AddHandler c.MouseClick, AddressOf MineClick
            Next
        Next
        'generate random mine locations
        labelmines.Text = CType(minecount - markedmines, String)

        Dim RX As New Random
        For m As Integer = 1 To minecount
            Dim x As Integer = 0
            Dim y As Integer = 0
            Do
                x = RX.Next(1, boardcols)
                y = RX.Next(1, boardrows)

            Loop Until Not minefield(y, x).hasmine
            minefield(y, x).hasmine = True
            '   minefield(x, y).View = Minecell.minecellview.Mine
            If cheatson = True Then

            End If
        Next

        'count the mines
        For row As Integer = 0 To boardrows - 1
            For col As Integer = 0 To boardcols - 1
                minefield(row, col).number = 0
                If Not minefield(row, col).hasmine Then
                    For DR As Integer = -1 To 1
                        For DC As Integer = -1 To 1
                            If row + DR >= 0 And row + DR < boardrows And
                                    col + DC >= 0 And col + DC < boardcols And
                                    Not (DC = 0 And DR = 0) Then
                                If minefield(row + DR, col + DC).hasmine Then
                                    minefield(row, col).number += 1

                                End If

                            End If
                        Next
                    Next
                    If minefield(row, col).number > 0 Then
                        If cheatson = True Then
                            minefield(row, col).buttoncolor = Color.Green
                            Refresh()
                        End If

                        '  minefield(row, col).View = Minecell.minecellview.Number
                    End If
                End If

            Next
        Next

        'resize window to fit the board difficulty
        Me.Width = boardcols * cellsize
        Do Until Me.Panelmine.Width = boardcols * cellsize
            Me.Width += 1
        Loop
        Me.Height = boardrows * cellsize
        Do Until Me.Panelmine.Height = boardrows * cellsize
            Me.Height += 1
        Loop
        Me.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, NewToolStripMenuItem.Click
        My.Computer.Audio.Play(My.Resources.Click_SoundBible_com_1387633738, AudioPlayMode.Background)

        buildboard()
    End Sub
    Private Sub startgame(rows As Integer, cols As Integer, mines As Integer)
        boardrows = rows
        boardcols = cols
        minecount = mines
        buildboard()
    End Sub
    Private Sub MineClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        If lost = False Then
            My.Computer.Audio.Play(My.Resources.Tiny_Button_Push_SoundBible_com_513260752, AudioPlayMode.Background)

            labelmessage.Text = "game in progress"
            Timer1.Enabled = True
            Dim m As Minecell = sender


            If e.Button = Windows.Forms.MouseButtons.Left Then
                If m.hasmine Then
                    For r As Integer = 0 To boardrows - 1
                        For c As Integer = 0 To boardcols - 1
                            Dim Currentcell As Minecell = minefield(c, r)
                            If Currentcell.hasmine Then
                                Currentcell.View = Minecell.minecellview.Mine
                                Currentcell.Refresh()
                                Timer1.Enabled = False
                                lost = True
                                Button1.Image = My.Resources.smiley3
                                labelmessage.Text = "Game Over"
                                My.Computer.Audio.Play(My.Resources.Explosion_9, AudioPlayMode.Background)

                            End If
                        Next
                    Next





                ElseIf m.number > 0 Then
                    m.View = Minecell.minecellview.Number
                    m.Refresh()
                    If gameover() Then
                        Timer1.Enabled = False
                        Button1.Image = My.Resources.smiley
                        labelmessage.Text = "You Win"
                        My.Computer.Audio.Play(My.Resources.Ta_Da_SoundBible_com_1884170640, AudioPlayMode.Background)

                    End If
                ElseIf m.number = 0 Then
                    Me.Hide()
                    showblanks(m)
                    Me.Show()
                    If gameover() Then
                        Timer1.Enabled = False
                        Button1.Image = My.Resources.smiley
                        labelmessage.Text = "you win"
                        My.Computer.Audio.Play(My.Resources.Ta_Da_SoundBible_com_1884170640, AudioPlayMode.Background)

                    End If
                End If
            ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                Select Case m.View
                    Case Minecell.minecellview.Button
                        If markedmines < 11 Then
                            m.View = Minecell.minecellview.Flag
                            markedmines += 1
                            m.Refresh()
                            dolabels()
                        End If

                    Case Minecell.minecellview.Flag
                        m.View = Minecell.minecellview.Question
                        markedmines -= 1
                        dolabels()
                        m.Refresh()
                    Case Minecell.minecellview.Question
                        m.View = Minecell.minecellview.Button
                        m.Refresh()
                End Select

            End If
        End If
    End Sub
    Private Sub showblanks(ByVal m As Minecell)

        m.View = Minecell.minecellview.Number
        m.Refresh()
        For R As Integer = m.y - 1 To m.y + 1
            For c As Integer = m.x - 1 To m.x + 1
                If R >= 0 And R < boardrows And c >= 0 And c < boardcols Then
                    Dim mc As Minecell = minefield(R, c)
                    If mc.View = Minecell.minecellview.Button Then
                        If mc.number = 0 Then
                            showblanks(mc)

                        Else
                            mc.View = Minecell.minecellview.Number

                        End If
                        Refresh()
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        seconds += 1
        Dolabels()
    End Sub
    Private Sub dolabels()
        Labelclock.Text = seconds.ToString
        labelmines.Text = (minecount - markedmines).ToString
    End Sub
    Private Function gameover()
        Dim tv As Boolean = True
        For Each mc As Minecell In minefield
            If Not mc.hasmine And Not mc.View = Minecell.minecellview.Number Then
                tv = False
            End If
        Next
        Return tv
    End Function

    Private Sub BeginnerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BeginnerToolStripMenuItem.Click
        startgame(9, 9, 11)
        My.Computer.Audio.Play(My.Resources.Click_SoundBible_com_1387633738, AudioPlayMode.Background)

    End Sub

    Private Sub IntermidiateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IntermidiateToolStripMenuItem.Click
        startgame(16, 16, 40)
        My.Computer.Audio.Play(My.Resources.Click_SoundBible_com_1387633738, AudioPlayMode.Background)

    End Sub

    Private Sub AdvancedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdvancedToolStripMenuItem.Click
        startgame(16, 30, 99)
        My.Computer.Audio.Play(My.Resources.Click_SoundBible_com_1387633738, AudioPlayMode.Background)

    End Sub
End Class
