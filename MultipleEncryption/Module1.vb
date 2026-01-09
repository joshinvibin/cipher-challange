Imports System.Console
Module Module1

    Function tryCatch(message As String) As Integer
        Dim crash As Boolean = False
        Dim input As Integer = 0

        Do
            WriteLine($"{message}")
            crash = False
            Try
                input = ReadLine()
            Catch ex As Exception
                WriteLine("Invalid input. Please enter in a new input")
                crash = True
            End Try
        Loop Until crash = False

        Return input
    End Function

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

    Sub encrypt()
        Dim output As String = ""
        Dim input As Integer = userChoice(" _____                             _
| ____|_ __   ___ _ __ _   _ _ __ | |_
|  _| | '_ \ / __| '__| | | | '_ \| __|
| |___| | | | (__| |  | |_| | |_) | |_
|_____|_| |_|\___|_|   \__, | .__/ \__|
                       |___/|_|

Please choose an option:
    Caesar
    Vernam
    Vigenere
    Rail fence", 8, 3)

        Select Case input
            Case 0
                output = caesar(1)
            Case 1
                output = vernam(1)
            Case 2
                output = vigenere(1)
            Case 3
                output = encryptRailFence()
        End Select

        WriteLine("Your encrypted text is :")
        WriteLine(output)
        ReadLine()
    End Sub

    Sub decrypt()
        Dim output As String = ""
        Dim input As Integer = userChoice(" ____                             _
|  _ \  ___  ___ _ __ _   _ _ __ | |_
| | | |/ _ \/ __| '__| | | | '_ \| __|
| |_| |  __/ (__| |  | |_| | |_) | |_
|____/ \___|\___|_|   \__, | .__/ \__|
                      |___/|_|

Please choose an option:
    Caesar
    Vernam
    Vigenere
    Rail fence", 8, 3)

        Select Case input
            Case 0
                output = caesar(-1)
            Case 1
                output = vernam(-1)
            Case 2
                output = vigenere(-1)
            Case 3
                output = decryptRailFence()
        End Select

        WriteLine("Your decrypted text is :")
        WriteLine(output)
        ReadLine()
    End Sub

    Function vernam(direction As Integer) As String
        Dim type As String = "plain"
        Dim key As String = ""
        Dim output As String = ""
        Dim input As String = ""
        If direction = -1 Then type = "encrypted"
        WriteLine($"__     __                              
\ \   / /__ _ __ _ __   __ _ _ __ ___  
 \ \ / / _ \ '__| '_ \ / _` | '_ ` _ \ 
  \ V /  __/ |  | | | | (_| | | | | | |
   \_/ \___|_|  |_| |_|\__,_|_| |_| |_|

Enter you {type} text")

        input = ReadLine()

        Clear()

        Select Case direction
            Case 1
                Dim choiceIn As Integer = userChoice("__     __                              
\ \   / /__ _ __ _ __   __ _ _ __ ___  
 \ \ / / _ \ '__| '_ \ / _` | '_ ` _ \ 
  \ V /  __/ |  | | | | (_| | | | | | |
   \_/ \___|_|  |_| |_|\__,_|_| |_| |_|

Do you have a key?
    Yes
    No", 7, 1)
                Select Case choiceIn
                    Case 0
                        WriteLine("__     __                              
\ \   / /__ _ __ _ __   __ _ _ __ ___  
 \ \ / / _ \ '__| '_ \ / _` | '_ ` _ \ 
  \ V /  __/ |  | | | | (_| | | | | | |
   \_/ \___|_|  |_| |_|\__,_|_| |_| |_|

Enter in your key")
                        key = ReadLine()
                    Case 1
                        key = generateKey(input.Length())
                        WriteLine($"__     __                              
\ \   / /__ _ __ _ __   __ _ _ __ ___  
 \ \ / / _ \ '__| '_ \ / _` | '_ ` _ \ 
  \ V /  __/ |  | | | | (_| | | | | | |
   \_/ \___|_|  |_| |_|\__,_|_| |_| |_|

Your key is: {key}")
                End Select
            Case -1
                WriteLine("__     __                              
\ \   / /__ _ __ _ __   __ _ _ __ ___  
 \ \ / / _ \ '__| '_ \ / _` | '_ ` _ \ 
  \ V /  __/ |  | | | | (_| | | | | | |
   \_/ \___|_|  |_| |_|\__,_|_| |_| |_|

Enter in your key")
                key = ReadLine()
        End Select

        output = xorText(input, key)

        Return output
    End Function

    Function generateKey(length As Integer) As String
        Dim key As String = ""
        For i = 0 To length - 1
            Randomize()
            key &= Chr((Rnd() * 30) + 33)
        Next i

        Return key
    End Function

    Function xorText(plain As String, key As String)
        Dim encrypt As String = ""
        Dim plainCurBin(7) As Integer
        Dim keyCurBin(7) As Integer
        Dim encryptCurBin(7) As Integer

        For i = 0 To plain.Length() - 1
            If plain(i) = " " Then
                encrypt &= " "
            Else
                plainCurBin = decToBin(Asc(plain(i)))
                keyCurBin = decToBin(Asc(key(i)))

                For j = 0 To 7
                    encryptCurBin(j) = CInt(CBool(plainCurBin(j)) Xor CBool(keyCurBin(j))) * -1
                Next j

                encrypt &= Chr(binToDec(encryptCurBin))
            End If

        Next i

        Return encrypt
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

    Function decryptRailFence() As String
        Dim decrypt As String = ""
        Dim add1 As Integer = 0
        Dim add2 As Integer = 0

        WriteLine(" ____       _ _   _____
|  _ \ __ _(_) | |  ___|__ _ __   ___ ___
| |_) / _` | | | | |_ / _ \ '_ \ / __/ _ \
|  _ < (_| | | | |  _|  __/ | | | (_|  __/
|_| \_\__,_|_|_| |_|  \___|_| |_|\___\___|

Please enter in your encrypted text")

        Dim input As String = ReadLine().ToUpper()
        input = cleanInput(input)

        If input.Length() Mod 4 <> 0 Then
            add1 = 1
        End If

        Select Case input.Length() Mod 4
            Case 2
                add2 = 1
            Case 3
                add2 = 2
        End Select

        Dim rail1 As String = input.Substring(0, (input.Length \ 4) + add1)
        Dim rail2 As String = input.Substring((input.Length \ 4) + add1, (input.Length / 2) + add2)
        Dim rail3 As String = input.Substring(((input.Length \ 4) * 3) + add2 + add1, input.Length / 4)

        For i = 1 To input.Length()
            If i Mod 2 = 0 Then
                decrypt &= rail2((i / 2) - 1)
            Else
                Select Case i Mod 4
                    Case 1
                        decrypt &= rail1(i \ 4)
                    Case 3
                        decrypt &= rail3(i \ 4)
                End Select
            End If
        Next i

        Return decrypt
    End Function

    Function caesar(direction As Integer) As String
        Dim output As String = ""
        Dim type As String = "plain"
        If direction = -1 Then type = "encrypted"
        WriteLine($"  ____
 / ___|__ _  ___  ___  __ _ _ __
| |   / _` |/ _ \/ __|/ _` | '__|
| |__| (_| |  __/\__ \ (_| | |
 \____\__,_|\___||___/\__,_|_|

Enter in your {type} text")
        Dim input As String = ReadLine().ToUpper()
        input = cleanInput(input)
        Dim key As Integer = tryCatch("Enter your key")

        For i = 0 To input.Length() - 1
            Dim letter As Integer = 0
            If Asc(input(i)) < 91 And Asc(input(i)) > 64 Then
                letter = Asc(input(i)) + key * direction
                If letter < 65 Then letter += 26
                If letter > 90 Then letter -= 26
            Else
                letter = Asc(input(i))
            End If
            output += Chr(letter)
        Next i

        Return output
    End Function

    Function vigenere(direction As Integer) As String
        Dim output As String = ""
        Dim type As String = "plain"

        If direction = -1 Then type = "encrypted"

        WriteLine($"__     ___
\ \   / (_) __ _  ___ _ __   ___ _ __ ___
 \ \ / /| |/ _` |/ _ \ '_ \ / _ \ '__/ _ \
  \ V / | | (_| |  __/ | | |  __/ | |  __/
   \_/  |_|\__, |\___|_| |_|\___|_|  \___|
           |___/

Enter in your {type} text:")
        Dim input As String = ReadLine().ToUpper()
        input = cleanInput(input)

        WriteLine("Enter your key")
        Dim key As String = ReadLine().ToUpper()
        For i = 0 To input.Length() - 1
            Dim letter As Integer = 0
            Dim curShift As Integer = Asc(key(i Mod key.Length())) - 65
            If Asc(input(i)) < 91 And Asc(input(i)) > 64 Then
                letter = Asc(input(i)) + (curShift * direction)
                If letter < 65 Then letter += 26
                If letter > 90 Then letter -= 26
            Else
                letter = Asc(input(i))
            End If
            output += Chr(letter)
        Next i

        Return output
    End Function

    Function encryptRailFence() As String
        Dim encrypt As String = ""
        WriteLine(" ____       _ _   _____
|  _ \ __ _(_) | |  ___|__ _ __   ___ ___
| |_) / _` | | | | |_ / _ \ '_ \ / __/ _ \
|  _ < (_| | | | |  _|  __/ | | | (_|  __/
|_| \_\__,_|_|_| |_|  \___|_| |_|\___\___|

Please enter in your plain text")

        Dim input As String = ReadLine().ToUpper()
        input = cleanInput(input)

        For i = 0 To input.Length() - 1 Step 4
            encrypt &= input(i)
        Next i

        encrypt &= " "

        For i = 1 To input.Length() - 1 Step 2
            encrypt &= input(i)
        Next i

        encrypt &= " "

        For i = 2 To input.Length() - 1 Step 4
            encrypt &= input(i)
        Next i

        Return encrypt
    End Function

    Function cleanInput(input As String) As String
        Dim output As String = ""
        For i = 0 To input.Length() - 1
            If Asc(input(i)) > 64 And Asc(input(i)) < 91 Then output &= input(i)
        Next i
        Return output
    End Function

    Sub Main()
        Dim use As Boolean = True
        Do
            Dim input As Integer = userChoice(" __  __       _ _   _       _
|  \/  |_   _| | |_(_)_ __ | | ___
| |\/| | | | | | __| | '_ \| |/ _ \
| |  | | |_| | | |_| | |_) | |  __/
|_|__|_|\__,_|_|\__|_| .__/|_|\___|_   _
| ____|_ __   ___ _ _|_|   _ _ __ | |_(_) ___  _ __
|  _| | '_ \ / __| '__| | | | '_ \| __| |/ _ \| '_ \
| |___| | | | (__| |  | |_| | |_) | |_| | (_) | | | |
|_____|_| |_|\___|_|   \__, | .__/ \__|_|\___/|_| |_|
                       |___/|_|

Please choose an option:
    Encrypt
    Decrypt
    Exit", 12, 2)
            Select Case input
                Case 0
                    encrypt()
                Case 1
                    decrypt()
                Case 2
                    use = False
            End Select
            Clear()
        Loop Until use = False
    End Sub

End Module