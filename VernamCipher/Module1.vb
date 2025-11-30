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
            key &= Chr((Rnd() * 119) + 7)
        Next i
        Return key
    End Function

    Sub Main()
        Dim plaintxt As String = ""
        Dim encrypt As String = ""
        Dim key As String = ""
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

        Select Case input
            Case 1
            Case 2
                key = generateKey(Len(input))
            Case 3
        End Select
    End Sub

End Module
