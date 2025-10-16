Imports System.Console
Module Module1

    Sub Main()
        Dim text As String = ReadLine()
        Dim text1 As String = ""
        Dim encrypt As String = ""
        Dim decrypt As String = ""

        Do
            encrypt = ReadLine()
            decrypt = ReadLine()


            For i = 0 To text.Length() - 1
                If text(i) = encrypt Then
                    text1 += decrypt
                Else
                    text1 += text(i)
                End If
            Next

            WriteLine(text)
        Loop
    End Sub

End Module
