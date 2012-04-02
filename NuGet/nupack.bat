xcopy /s /y %~dp0..\MFUnit\bin\Debug\* .\package\lib\netmf41
nuget pack .\package\MFUnit.nuspec