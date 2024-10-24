Imports DetectingMelanomasAndFreckles.Interfaces

Public Class ConsoleUserNotifier
    Implements IUserNotifier

    Public Sub DisplayMessage(message As String) Implements IUserNotifier.DisplayMessage
        Console.WriteLine(message)
    End Sub

    Public Sub DisplayErrorMessage(message As String) Implements IUserNotifier.DisplayErrorMessage
        Dim originalColor As ConsoleColor = Console.ForegroundColor

        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine(message)
        Console.ForegroundColor = originalColor
    End Sub
End Class