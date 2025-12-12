Imports System.Console
Module Module1
    Function userChoice(message As String, start As Integer, max As Integer) As Integer
        Dim input As Integer = 0
        Dim key As Integer = 0

        Do
            WriteLine(message) 'Menu
            SetCursorPosition(0, start + input) 'For scrolling menu. input stores where the cursor is supposed to be
            Write("> ") 'Displays the pointer

            key = ReadKey(True).Key 'Takes in key input

            Select Case key 'Increments or decrements input based on user action
                Case Is = ConsoleKey.DownArrow
                    If input < max Then
                        input += 1
                    End If
                Case Is = ConsoleKey.UpArrow
                    If input > 0 Then
                        input -= 1
                    End If
            End Select
            Clear() 'So that cursor position resets
        Loop Until key = ConsoleKey.Enter

        Return input
    End Function

    Function generateKey(length As Integer) As String
        Dim key As String = ""
        For i = 0 To length - 1
            Randomize()
            key &= Chr((Rnd() * 93) + 33)
        Next i

        Return key
    End Function

    Function decToBin(dec As Integer) As Integer()
        Dim convertedNum(7) As Integer
        For i = 7 To 0 Step -1
            convertedNum(i) = dec Mod 2
            dec = dec \ 2
        Next i

        Return convertedNum
    End Function

    Function binToDec(bin As Integer()) As Integer
        Dim dec As Integer = 0
        For i = 0 To 7
            dec += 2 ^ (7 - i) * bin(i)
        Next i

        Return dec
    End Function

    Function xorText(plain As String, key As String)
        Dim encrypt As String = ""
        Dim plainCurBin(7) As Integer
        Dim keyCurBin(7) As Integer
        Dim encryptCurBin(7) As Integer

        For i = 0 To plain.Length() - 1
            plainCurBin = decToBin(Asc(plain(i)))
            keyCurBin = decToBin(Asc(key(i)))

            For j = 0 To 7
                encryptCurBin(j) = CInt(CBool(plainCurBin(j)) Xor CBool(keyCurBin(j))) * -1
            Next j

            encrypt &= Chr(binToDec(encryptCurBin))
        Next i

        Return encrypt
    End Function

    Function processChoice(input As Integer)
        Dim key As String = ""
        Dim txtin As String = ""
        Dim use As Boolean = True
        Select Case input
            Case 0
                hasKey(txtin, key, "encrypt")
            Case 1
                WriteLine("Please enter in your text")
                txtin = ReadLine()
                key = generateKey(txtin.Length())
                WriteLine("Your key is: " & key)
                WriteLine("Your encrpyt is:")
                WriteLine(xorText(txtin, key))
            Case 2
                hasKey(txtin, key, "decrypt")
            Case 3
                use = False
        End Select
        ReadLine()

        Return use
    End Function

    Sub hasKey(txtin As String, key As String, direction As String)
        txtin = processInput(key)
        WriteLine($"Your {direction} is:")
        WriteLine(xorText(txtin, key))
    End Sub

    Function processInput(ByRef key As String)
        Dim txtin As String = ""
        WriteLine("Please enter your key")
        key = ReadLine()
        WriteLine("Please enter your text")
        txtin = ReadLine()
        Return txtin
    End Function

    Sub Main()
        Dim use As Boolean = True
        Do
            Dim input As Integer = userChoice("__     __                                 ____ _       _
\ \   / /__ _ __ _ __   __ _ _ __ ___    / ___(_)_ __ | |__   ___ _ __
 \ \ / / _ \ '__| '_ \ / _` | '_ ` _ \  | |   | | '_ \| '_ \ / _ \ '__|
  \ V /  __/ |  | | | | (_| | | | | | | | |___| | |_) | | | |  __/ |
   \_/ \___|_|  |_| |_|\__,_|_| |_| |_|  \____|_| .__/|_| |_|\___|_|
                                                |_|
Please choose an option: 
    Encrypt text with selected key
    Encrypt text and generate key
    Decrypt text with key
    Exit", 7, 3)

            Clear()

            use = processChoice(input)
        Loop Until use = False
    End Sub
End Module