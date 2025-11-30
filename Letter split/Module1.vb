Module Module1

    Sub Main()
        Dim input As String = Console.ReadLine()
        Dim encrypt As String = ""
        Dim key As Integer = Console.ReadLine()
        Console.WriteLine()
        For i = 0 To input.Length() - 1
            If input(i) <> " " Then encrypt += input(i)
        Next i
        For i = 0 To encrypt.Length() / key
            If (i * key) - 1 < encrypt.Length Then
                Console.Write(encrypt(key * i))
            End If
        Next i
    End Sub

End Module
