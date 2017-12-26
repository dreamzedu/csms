Set WshShell = CreateObject("WScript.Shell") 
WshShell.Run chr(34) & "dbcreate.bat" & Chr(34)
Set WshShell = Nothing