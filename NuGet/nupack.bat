robocopy %~dp0..\MFUnit\bin\Debug\ .\package\lib\ /S
nuget pack .\package\MFUnit.nuspec