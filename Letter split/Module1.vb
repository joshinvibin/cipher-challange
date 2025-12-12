Module Module1

    Sub Main()
        Dim input As String = Console.ReadLine()
        Dim encrypt As String = ""
        Console.WriteLine()
        For i = 0 To input.Length() - 1
            If input(i) <> " " Then encrypt += input(i)
        Next i
        Console.WriteLine()

        For j = 3 To 10
            For i = 0 To encrypt.Length() / j
                If (i * j) < encrypt.Length() Then
                    Console.Write(encrypt(j * i))
                End If
            Next i
            Console.WriteLine("

")
        Next j
    End Sub

End Module
