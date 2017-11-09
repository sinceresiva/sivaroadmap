dotnet clean
dotnet publish -f netcoreapp2.0
cf push -f manifest.yml -p bin/Debug/netcoreapp2.0/publish
