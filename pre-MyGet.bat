cd ./src/GladNet.ASP.Server
dotnet restore
%nuget% update GladNet.ASP.Server.csproj -noninteractive
cd ..
cd ..

cd ./src/GladNet.ASP.Formatters
dotnet restore
%nuget% update GladNet.ASP.Formatters.csproj -noninteractive
cd ..
cd ..


