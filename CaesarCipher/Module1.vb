Imports System.Console
Module Module1
    Sub Main()
        Dim word As String = ""
        Dim word1 As String = ""
    End Sub

    Sub Caesar(ByRef word As String, ByRef word1 As String)
        Dim letter As Integer = 0
        word = ReadLine().ToUpper
        For i = 1 To 50
            word1 = ""

            For j = 0 To Len(word) - 1
                If word(j) <> " " Then
                    letter = Asc(word(j))
                    letter += i
                Else
                    letter = 32
                End If

                If letter > 90 Then
                    letter = 65 + (letter Mod 26)
                ElseIf letter < 65 And letter <> 32 Then
                    letter = 91 - (letter Mod 27)
                End If

                word1 = word1 + Chr(letter)

            Next
            WriteLine(word1)
        Next
    End Sub
End Module
