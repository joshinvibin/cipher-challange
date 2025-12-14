Module Module1

    Sub Main()
        Dim key(4, 4) As String
        For i = 0 To 4
            For j = 0 To 4
                Console.WriteLine(i & j)
                key(i, j) = Console.ReadLine()
            Next j
        Next i

        Console.WriteLine("input")
        Dim input As String = Console.ReadLine()
        Dim encrypt As String = ""
        For i = 0 To input.Length() - 1
            If Asc(input(i)) < 91 And Asc(input(i)) > 64 Then
                encrypt &= input(i)
            End If
        Next i

        Dim decrypt As String = ""

        For i = 0 To encrypt.Length() / 2
            Dim encryptSplit As String = ""
            If i < encrypt.Length() - 2 Then encryptSplit = encrypt(2 * i) + encrypt((2 * i) + 1)

            Dim location1x As Integer = 0
            Dim location2x As Integer = 0
            Dim location1y As Integer = 0
            Dim location2y As Integer = 0
            For k = 0 To 4
                For j = 0 To 4
                    If key(k, j) = encryptSplit(0) Then
                        location1x = k
                        location1y = j
                    End If
                    If key(k, j) = encryptSplit(1) Then
                        location2x = k
                        location2y = j
                    End If
                Next j
            Next k

            If location1x = location2x Then
                If location1x = 4 Then location1x = -1
                If location2x = 4 Then location2x = -1
                decrypt &= key(location1x + 1, location1y)
                decrypt &= key(location2x + 1, location2y)
            ElseIf location1y = location2y Then
                If location1x = 4 Then location1x = -1
                If location2x = 4 Then location2x = -1
                decrypt &= key(location1x + 1, location1y)
                decrypt &= key(location2x + 1, location2y)
            Else
                decrypt &= key(location2x, location1y)
                decrypt &= key(location1x, location2y)
            End If
        Next i

        Console.WriteLine(decrypt)
    End Sub

End Module
