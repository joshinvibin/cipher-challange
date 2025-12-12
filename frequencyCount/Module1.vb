Imports System.Console
Module Module1

    Function Freq_Analysis(word As String) As Integer()
        Dim letters(26) As Integer
        Dim letter As Integer = 0

        For i = 0 To Len(word) - 1
            If Asc(word(i)) < 92 And Asc(word(i)) > 64 Then
                letter = Asc(word(i)) - 64

                letters(letter) += 1
            End If
        Next i
        WriteLine()
        For i = 1 To 26
            Write(Chr(i + 64) & ": " & letters(i) & "    ")
        Next
        WriteLine()
        WriteLine()
        For i = 1 To 26
            Write(Chr(i + 64) & ": " & Math.Round(letters(i) / word.Length(), 3) * 100 & "    ")
        Next
        WriteLine()
        Return letters
    End Function
    Sub Main()
        Dim word As String = ReadLine()
        Dim clean As String = ""
        Dim letters(26) As Integer
        Dim freqTab(26) As String

        For i = 0 To word.Length() - 1
            If Asc(word(i)) < 92 And Asc(word(i)) > 64 Then
                clean &= word(i)
            End If
        Next i

        Dim temp As Integer = 0
        letters = Freq_Analysis(clean)

        WriteLine(clean.Length())

        'For i = 1 To 25
        '    If letters(i) > letters(i) + 1 Then
        '        temp = letters(i + i)
        '        letters(i + 1) = letters(i)
        '        letters(i) = temp
        '    End If
        'Next
    End Sub

End Module
