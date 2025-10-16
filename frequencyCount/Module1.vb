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

        Return letters
    End Function
    Sub Main()
        Dim word As String = ReadLine()
        Dim letters(26) As Integer
        Dim freqTab(26) As String

        Dim temp As Integer = 0
        letters = Freq_Analysis(word)

        'For i = 1 To 25
        '    If letters(i) > letters(i) + 1 Then
        '        temp = letters(i + i)
        '        letters(i + 1) = letters(i)
        '        letters(i) = temp
        '    End If
        'Next
    End Sub

End Module
