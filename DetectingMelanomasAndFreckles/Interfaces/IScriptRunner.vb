Namespace Interfaces
    Public Interface IScriptRunner
        Function RunScript(scriptPath As String, imagePath As String) As (String, String)
    End Interface
End Namespace