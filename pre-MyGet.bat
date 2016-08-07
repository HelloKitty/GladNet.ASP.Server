cd ./src/GladNet.ASP.Server
dotnet restore
%nuget% update project.json -noninteractive
cd ..
cd ..

cd ./src/GladNet.ASP.Formatters
dotnet restore
%nuget% update project.json -noninteractive
cd ..
cd ..


