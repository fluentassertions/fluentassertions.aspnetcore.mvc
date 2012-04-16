@ECHO OFF
pushd %~dp0

%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\msbuild FluentAssertionsMvc.msbuild /m /nr:false /v:M /fl /flp:LogFile=bin\msbuild.log;Verbosity=Normal
if errorlevel 1 goto BuildFail

echo.
echo *** BUILD SUCCESSFUL ***
echo.

cd release
nuget pack
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