Imports System.Console
Module Module1

    Sub Vingenere(ByRef word As String)
        Dim word1 As String = ""
        Dim letter As Integer = 0
        Dim key As String = ""
        Dim count As Integer = 0
        key = ReadLine().ToUpper()
        For i = 0 To Len(word) - 1
            If word(i) <> " " Then
                letter = Asc(word(i))
                letter -= (Asc(key(count)) - 65)
                count = count + 1
                If count = 4 Then count = 0
            Else
                letter = 32
            End If

            If letter > 90 Then
                letter = 65 + (letter Mod 26)
            ElseIf letter < 65 And letter <> 32 Then
                letter = 91 - (letter Mod 26)
            End If

            word1 += Chr(letter)
        Next

        WriteLine(word1)
    End Sub

    Sub Main()
        Dim word As String = ReadLine()
        Vingenere(word)
    End Sub

End Module
