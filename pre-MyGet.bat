cd ./src/GladNet.ASP.Server
dotnet restore
cd ..
cd ..

cd ./src/GladNet.ASP.Formatters
dotnet restore
cd ..
cd ..

%nuget% update GladNet.ASP.Server.sln -noninteractive
