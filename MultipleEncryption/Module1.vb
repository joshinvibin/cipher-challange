Imports System.Console
Module Module1

    Function tryCatch(message As String) As Integer
        Dim crash As Boolean
        Dim input As Integer

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
        Dim input As Integer = 0
        input = userChoice(" _____                             _
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
                caesar(1)
            Case 1

            Case 2
                vigenere(1)
            Case 3
                encryptRailFence()
        End Select
        ReadLine()
    End Sub

    Sub decrypt()
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

        Clear()

        Select Case input
            Case 0
                caesar(-1)
            Case 1

            Case 2
                vigenere(-1)
            Case 3
                decryptRailFence()
        End Select
        ReadLine()
    End Sub

    Sub decryptRailFence()
        Dim input As String = ""
        Dim decrypt As String = ""
        Dim rail1 As String = ""
        Dim rail2 As String = ""
        Dim rail3 As String = ""
        Dim add1 As Integer = 0
        Dim add2 As Integer = 0

        WriteLine(" ____       _ _   _____
|  _ \ __ _(_) | |  ___|__ _ __   ___ ___
| |_) / _` | | | | |_ / _ \ '_ \ / __/ _ \
|  _ < (_| | | | |  _|  __/ | | | (_|  __/
|_| \_\__,_|_|_| |_|  \___|_| |_|\___\___|

Please enter in your encrypted text")

        input = ReadLine().ToUpper()
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

        rail1 = input.Substring(0, (input.Length / 4) + add1)
        rail2 = input.Substring((input.Length / 4) + add1, (input.Length / 2) + add2)
        rail3 = input.Substring(((input.Length / 4) * 3) + add2 + add1, input.Length / 4)

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

        WriteLine(decrypt)
    End Sub

    Sub caesar(direction As Integer)
        Dim output As String = ""
        Dim name As String = "plain"
        If direction = -1 Then name = "encrypted"
        WriteLine($"  ____
 / ___|__ _  ___  ___  __ _ _ __
| |   / _` |/ _ \/ __|/ _` | '__|
| |__| (_| |  __/\__ \ (_| | |
 \____\__,_|\___||___/\__,_|_|

Enter in your {name} text")
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

        WriteLine(output)
    End Sub

    Sub vigenere(direction As Integer)
        Dim output As String = ""
        Dim curShift As Integer = 0
        Dim name As String = "plain"

        If direction = -1 Then name = "encrypted"

        WriteLine($"__     ___
\ \   / (_) __ _  ___ _ __   ___ _ __ ___
 \ \ / /| |/ _` |/ _ \ '_ \ / _ \ '__/ _ \
  \ V / | | (_| |  __/ | | |  __/ | |  __/
   \_/  |_|\__, |\___|_| |_|\___|_|  \___|
           |___/

Enter in you {name} text:")
        Dim input As String = ReadLine().ToUpper()
        input = cleanInput(input)

        WriteLine("Enter your key")
        Dim key As String = ReadLine().ToUpper()
        For i = 0 To input.Length() - 1
            Dim letter As Integer = 0
            curShift = Asc(key(i Mod key.Length())) - 65
            If Asc(input(i)) < 91 And Asc(input(i)) > 64 Then
                letter = Asc(input(i)) + (curShift * direction)
                If letter < 65 Then letter += 26
                If letter > 90 Then letter -= 26
            Else
                letter = Asc(input(i))
            End If
            output += Chr(letter)
        Next i

        WriteLine(output)
    End Sub

    Sub encryptRailFence()
        Dim input As String = ""
        Dim encrypt As String = ""
        WriteLine(" ____       _ _   _____
|  _ \ __ _(_) | |  ___|__ _ __   ___ ___
| |_) / _` | | | | |_ / _ \ '_ \ / __/ _ \
|  _ < (_| | | | |  _|  __/ | | | (_|  __/
|_| \_\__,_|_|_| |_|  \___|_| |_|\___\___|

Please enter in your plain text")

        input = ReadLine().ToUpper()
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

        WriteLine(encrypt)
    End Sub

    Function cleanInput(input As String) As String
        Dim output As String = ""
        For i = 0 To input.Length() - 1
            If Asc(input(i)) > 64 And Asc(input(i)) < 91 Then output &= input(i)
        Next i
        Return output
    End Function

    Sub Main()
        Dim use As Boolean = True
        Dim input As Integer = 0
        Do
            input = userChoice(" __  __       _ _   _       _
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