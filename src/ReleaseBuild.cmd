@ECHO OFF

IF EXIST "%VS100COMNTOOLS%vsvars32.bat" GOTO MSBUILD
IF EXIST "C:\Program Files\MonoDevelop\bin\mdtool.exe" GOTO MDTOOL_C
IF EXIST "D:\Program Files\MonoDevelop\bin\mdtool.exe" GOTO MDTOOL_D

ECHO ERROR: Cannnot find MSBUILD .net4 or MDTool

GOTO END

#============================================================


:MDTOOL_D

"D:\Program Files\MonoDevelop\bin\mdtool.exe" build --configuration:RELEASE

GOTO COPY

#============================================================

:MSBUILD

CALL "%VS100COMNTOOLS%vsvars32.bat"



GOTO COPY

#============================================================

:COPY

COPY FluentAssertions.Mvc3\bin\Release\*.* _Package\Lib\Mvc3

GOTO PACKAGE

#============================================================

:PACKAGE

..\tools\nuget pack _Package\Package.nuspec -o _Package

GOTO END

#============================================================

:END

pause
