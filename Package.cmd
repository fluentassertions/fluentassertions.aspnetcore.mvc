@ECHO OFF
pushd %~dp0

REM %SystemRoot%\Microsoft.NET\Framework\v4.0.30319\msbuild FluentAssertionsMvc.msbuild /m /nr:false /v:M /fl /flp:LogFile=bin\msbuild.log;Verbosity=Normal
%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\msbuild FluentAssertionsMvc.msbuild /maxcpucount /nodeReuse:false /verbosity:quiet /fileLogger /fileloggerparameters:LogFile=bin\msbuild.log;
if errorlevel 1 goto BuildFail

echo.
echo *** BUILD SUCCESSFUL ***
echo.

REM .nuget\nuget pack src\FluentAssertions.Mvc3\FluentAssertions.Mvc3.csproj 
.nuget\nuget pack src\FluentAssertions.Mvc4\FluentAssertions.Mvc4.csproj -verbosity detailed
.nuget\nuget pack src\FluentAssertions.Mvc5\FluentAssertions.Mvc5.csproj -verbosity detailed
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