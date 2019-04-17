@echo off

cd ../Sample.ApiServiceA

dotnet publish -c Release -o ../publish/Sample.ApiServiceA

cd ../publish/Sample.ApiServiceA

echo "publish success"

