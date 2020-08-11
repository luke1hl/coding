Imports System

Module Program

    Sub Main()
            Dim coded As String = ""
            Dim count As Byte = 0
            Dim letter As Char
            loading()
            encoding(count, letter, coded)
        End Sub
        Sub loading()
            For yeet = 0 To 3
                Console.WriteLine("loading |")
                System.Threading.Thread.Sleep(50)
                Console.Clear()
                Console.WriteLine("loading /")
                System.Threading.Thread.Sleep(50)
                Console.Clear()
                Console.WriteLine("loading -")
                System.Threading.Thread.Sleep(50)
                Console.Clear()
                Console.WriteLine("loading \")
                System.Threading.Thread.Sleep(50)
                Console.Clear()

            Next
        End Sub
        Function getword()
            Console.WriteLine("please input a word to encode")
            Return Console.ReadLine()
        End Function

        Sub encoding(ByRef count As Byte, ByRef letter As Char, ByRef coded As String)
            Dim mytext = getword()
            count = 1
            Dim nextletterthesame As Boolean = True
            For looper = 0 To Len(mytext) - 1
                While nextletterthesame = True
                    If looper <> Len(mytext) - 1 Then
                        If mytext(looper) = mytext(looper + 1) Then
                            count += 1
                            looper = looper + 1

                        Else
                            nextletterthesame = False
                            If count = 1 Then
                                coded = coded & mytext(looper)
                            End If
                        End If
                    Else
                        nextletterthesame = False
                    End If



                End While
            If count > 1 Then
                coded = coded & "@" & count & mytext(looper - 1)
            End If
            count = 1
                nextletterthesame = True

            Next

            Console.WriteLine(coded)
            Console.ReadLine()
        End Sub

End Module
