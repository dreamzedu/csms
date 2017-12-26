@echo off
cls

:begin

set rootpath=%~dp0

@echo on

cd/
cd "windows\system32"

@echo "%rootpath%csms_db_script.sql"

sqlcmd -S .\sqlexpress -t 60000 -i "%rootpath%csms_db_script.sql" 


:end
