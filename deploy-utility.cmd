SET app=ffmpeg-batch
rd /s /q .\utility\%app%\bin\Release
dotnet build -c Release .\utility\%app%\%app%.csproj
nuget push .\utility\%app%\bin\Release\*.nupkg -Source https://api.nuget.org/v3/index.json