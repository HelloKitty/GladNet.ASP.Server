cd ./src/GladNet.ASP.Server
dotnet restore
%nuget% update GladNet.ASP.Server.sln -noninteractive
cd ..
cd ..

cd ./src/GladNet.ASP.Formatters
dotnet restore
%nuget% update GladNet.ASP.Server.sln -noninteractive
cd ..
cd ..


