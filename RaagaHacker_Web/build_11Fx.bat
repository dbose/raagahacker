@echo off

echo Settings VS.NET environment...
"C:\Program Files\Microsoft Visual Studio 8\VC\vcvarsall.bat"

msbuild RaagaHackerWeb.csproj /p:TargetFX1_1=true /p:CustomAfterMicrosoftCommonTargets="%ProgramFiles%\MSBuild\MSBee\MSBuildExtras.Fx1_1.CSharp.targets"