Imports System.Console
Module Module1

    Sub Main()
        Dim word As String = ReadLine()
        Dim letterasc As Integer = 0
        Dim decrypt As String = ""
        Dim count As Integer = 1
        WriteLine()
        WriteLine()
        For i = 0 To word.Length() - 1
            If word(i) <> " " Then
                Select Case count
                    Case 1
                        letterasc = Asc(word(i)) - 13
                    Case 2
                        letterasc = Asc(word(i)) - 4
                    Case 3
                        letterasc = Asc(word(i)) - 22
                    Case 4
                        letterasc = Asc(word(i)) - 24
                    Case 5
                        letterasc = Asc(word(i)) - 14
                    Case 6
                        letterasc = Asc(word(i)) - 17
                    Case 7
                        letterasc = Asc(word(i)) - 10
                End Select
                count = count + 1
                If count = 8 Then count = 1
                If letterasc < 65 Then letterasc += 26

                decrypt += Chr(letterasc)
            Else
                decrypt += " "
            End If
        Next i

        WriteLine(decrypt)
    End Sub

End Module
