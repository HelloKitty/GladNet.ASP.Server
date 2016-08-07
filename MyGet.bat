dotnet restore
%NuGet% update GladNet.ASP.Server.sln -noninteractive
dotnet pack src/GladNet.ASP.Server/ -c Release
dotnet pack src/GladNet.ASP.Formatters/ -c Release