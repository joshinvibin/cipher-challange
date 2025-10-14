Imports System.Console
Module Module1
    Sub affine(ByRef word As String, ByRef word1 As String)
        word = ReadLine()
        Dim letter As Integer = 0
        Dim extra As Integer = 1
        For i = 0 To 26
            For j = 1 To 12
                word1 = ""
                For k = 0 To Len(word) - 1
                    If word(k) <> " " Then
                        letter = Asc(word(k))
                        letter = letter - 65
                        extra = assist(j)
                        letter = ((letter + i) * extra) Mod 26
                        word1 &= Chr(letter + 65)
                    Else
                        word1 &= " "
                    End If
                Next

                WriteLine(word1)
                WriteLine()
                ReadLine()

            Next
        Next
    End Sub



    Function assist(ByRef value As Integer) As Integer
        Select Case value
            Case 1
                Return 1
            Case 2
                Return 9
            Case 3
                Return 21
            Case 4
                Return 15
            Case 5
                Return 3
            Case 6
                Return 19
            Case 7
                Return 7
            Case 8
                Return 23
            Case 9
                Return 11
            Case 10
                Return 5
            Case 11
                Return 17
            Case 12
                Return 25
            Case Else
                Return 1
        End Select
    End Function

    Sub Main()
        Dim word As String = ""
        Dim word1 As String = ""
        affine(word, word1)
    End Sub
End Module
