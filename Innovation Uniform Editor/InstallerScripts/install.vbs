' Because Visual Studio Installer Scripts doesn't want to replace files for some reason
' I had to create this script to FORCE it to set freshinstall to true, which is, yknow nice.

Set objShell = CreateObject("WScript.Shell")
strAppData = objShell.ExpandEnvironmentStrings("%APPDATA%")

strFolder = strAppData & "\thoricelli"
strFile = strFolder & "\freshinstall"

Set fso = CreateObject("Scripting.FileSystemObject")

If Not fso.FolderExists(strFolder) Then
    fso.CreateFolder(strFolder)
End If

Set file = fso.CreateTextFile(strFile, True)
file.Write "true"
file.Close
