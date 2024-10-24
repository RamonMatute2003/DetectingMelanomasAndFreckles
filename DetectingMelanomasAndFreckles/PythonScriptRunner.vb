Imports DetectingMelanomasAndFreckles.Interfaces

Public Class PythonScriptRunner
    Implements IScriptRunner

    Public Function RunScript(scriptPath As String, imagePath As String) As (String, String) Implements IScriptRunner.RunScript
        Dim psi As New ProcessStartInfo()
        psi.FileName = "python"
        psi.Arguments = String.Format("""{0}"" ""{1}""", scriptPath, imagePath)
        psi.RedirectStandardOutput = True
        psi.RedirectStandardError = True
        psi.UseShellExecute = False
        psi.CreateNoWindow = True

        Using process As Process = Process.Start(psi)
            Dim output As String = process.StandardOutput.ReadToEnd()
            Dim errors As String = process.StandardError.ReadToEnd()
            process.WaitForExit()
            Return (output, errors)
        End Using
    End Function
End Class