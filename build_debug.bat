dotnet restore GaiaOnline.Unity.Library.sln
dotnet publish src/GaiaOnline.Game.Common/GaiaOnline.Game.Common.csproj -c debug
dotnet publish src/GaiaOnline.Game.Client/GaiaOnline.Game.Client.csproj -c debug
dotnet publish src/GaiaOnline.Game.Network.Client/GaiaOnline.Game.Network.Client.csproj -c debug
dotnet publish src/GaiaOnline.AdditionalDependencies/GaiaOnline.AdditionalDependencies.csproj -c debug

if not exist "build" mkdir build
if not exist "build\debug" mkdir build\debug
xcopy lib\Booma.Client build\debug /Y /EXCLUDE:BuildExclude.txt
xcopy src\GaiaOnline.Game.Common\bin\debug\netstandard2.0\publish build\debug /Y /EXCLUDE:BuildExclude.txt
xcopy src\GaiaOnline.Game.Client\bin\debug\netstandard2.0\publish build\debug /Y /EXCLUDE:BuildExclude.txt
xcopy src\GaiaOnline.Game.Network.Client\bin\debug\netstandard2.0\publish build\debug /Y /EXCLUDE:BuildExclude.txt
xcopy src\GaiaOnline.AdditionalDependencies\bin\debug\netstandard2.0\publish build\debug /Y /EXCLUDE:BuildExclude.txt

PAUSE