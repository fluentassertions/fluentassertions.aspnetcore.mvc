@ECHO OFF
pushd %~dp0

%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\msbuild FluentAssertionsMvc.msbuild /m /nr:false /v:M /fl /flp:LogFile=bin\msbuild.log;Verbosity=Normal
if errorlevel 1 goto BuildFail

echo.
echo *** BUILD SUCCESSFUL ***
echo.

.nuget\nuget pack src\FluentAssertions.Mvc3\FluentAssertions.Mvc3.csproj
.nuget\nuget pack src\FluentAssertions.Mvc4\FluentAssertions.Mvc4.csproj
if errorlevel 1 goto PackageFail

echo.
echo *** PACKAGE SUCCESSFUL ***
echo.
goto End

:BuildFail
echo.
echo *** BUILD FAILED ***
goto End

:BuildFail
echo.
echo *** PACKAGE FAILED ***
goto End


:End
popd

echo.
pause