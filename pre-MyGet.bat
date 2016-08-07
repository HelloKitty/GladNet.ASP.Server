cd ./src/GladNet.ASP.Server
dotnet restore
%nuget% update GladNet.ASP.Server.xproj -noninteractive
cd ..
cd ..

cd ./src/GladNet.ASP.Formatters
dotnet restore
%nuget% update GladNet.ASP.Formatters.xproj -noninteractive
cd ..
cd ..


