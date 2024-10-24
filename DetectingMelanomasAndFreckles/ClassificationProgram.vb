Imports DetectingMelanomasAndFreckles.Interfaces

Public Class ClassificationProgram
    Private ReadOnly _scriptRunner As IScriptRunner
    Private ReadOnly _userNotifier As IUserNotifier

    Public Sub New(scriptRunner As IScriptRunner, userNotifier As IUserNotifier)
        _scriptRunner = scriptRunner
        _userNotifier = userNotifier
    End Sub

    Public Sub Run()
        Try
            Const imagePath As String = "C:\Users\ramon\OneDrive\Programacion de juegos\Fundamentos C#\MelanomasAndFreckles\melanoma.jpg"
            Const pythonScriptPath As String = "C:\Users\ramon\OneDrive\Programacion de juegos\Fundamentos C#\MelanomasAndFreckles\imageClassification.py"

            _userNotifier.DisplayMessage("Cargando..." + Environment.NewLine)

            Dim result As (String, String) = _scriptRunner.RunScript(pythonScriptPath, imagePath)

            Dim output As String = result.Item1
            Dim errors As String = result.Item2

            If Not String.IsNullOrEmpty(errors) Then
                _userNotifier.DisplayErrorMessage("Errores:")
                _userNotifier.DisplayErrorMessage(errors)
            Else
                _userNotifier.DisplayMessage("Resultado de la clasificación es")
                _userNotifier.DisplayMessage(output)
            End If

            _userNotifier.DisplayMessage("El script ha finalizado.")
        Catch ex As Exception
            _userNotifier.DisplayErrorMessage("Error al ejecutar el script de Python:")
            _userNotifier.DisplayErrorMessage(ex.Message)
        End Try
    End Sub
End Class