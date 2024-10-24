Imports DetectingMelanomasAndFreckles.Interfaces

Module Program
    Sub Main(args As String())
        Dim scriptRunner As IScriptRunner = New PythonScriptRunner()
        Dim userNotifier As IUserNotifier = New ConsoleUserNotifier()
        Dim classificationProgram As New ClassificationProgram(scriptRunner, userNotifier)
        classificationProgram.Run()
    End Sub
End Module