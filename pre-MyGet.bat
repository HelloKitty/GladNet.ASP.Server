cd ./src/GladNet.ASP.Server
dotnet restore
%nuget% update -noninteractive
cd ..
cd ..

cd ./src/GladNet.ASP.Formatters
dotnet restore
%nuget% update -noninteractive
cd ..
cd ..


