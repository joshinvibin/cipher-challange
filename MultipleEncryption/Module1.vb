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
            Case 3
        End Select
        ReadLine()
    End Sub

    Sub decrypt()
        Dim input As Integer = 0
        input = userChoice(" ____                             _
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
                caesar(-1)
            Case 1
            Case 2
            Case 3
        End Select
        ReadLine()
    End Sub

    Sub caesar(direction As Integer)
        Dim encrypt As String = ""
        Dim decrypt As String = ""
        Dim letter As Integer = 0
        Dim name As String = "plain"
        If direction = -1 Then name = "encrypted"
        WriteLine($"  ____
 / ___|__ _  ___  ___  __ _ _ __
| |   / _` |/ _ \/ __|/ _` | '__|
| |__| (_| |  __/\__ \ (_| | |
 \____\__,_|\___||___/\__,_|_|

Enter in your {name} text")
        encrypt = ReadLine().ToUpper()
        Dim key As Integer = tryCatch("Enter your key")

        For i = 0 To encrypt.Length() - 1
            If Asc(encrypt(i)) < 91 And Asc(encrypt(i)) > 64 Then
                letter = Asc(encrypt(i)) + key * direction
                If letter < 65 Then letter += 26
                If letter > 90 Then letter -= 26
            Else
                letter = Asc(encrypt(i))
            End If
            decrypt += Chr(letter)
        Next i

        WriteLine(decrypt)
    End Sub

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
    Decrypt", 12, 1)
            Select Case input
                Case 0
                    encrypt()
                Case 1
                    decrypt()
            End Select
        Loop Until use = False
    End Sub

End Module