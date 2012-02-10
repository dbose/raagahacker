@echo off
copy "E:\My Projects\RaagaHackerL\Mp3Encoding\lame_enc.dll" "E:\My Projects\RaagaHackerL\bin\Debug\"
copy "E:\My Projects\RaagaHackerL\Mp3Encoding\lame.exe" "E:\My Projects\RaagaHackerL\bin\Debug\"
copy "E:\My Projects\RaagaHackerL\AdSignatures.xml" "E:\My Projects\RaagaHackerL\bin\Debug\"
copy "E:\My Projects\RaagaHackerL\Tours\*.rtf" "E:\My Projects\RaagaHackerL\bin\Debug\"
if errorlevel 1 goto CSharpReportError
goto CSharpEnd
:CSharpReportError
echo Project error: A tool returned an error code from the build event
exit 1
:CSharpEnd