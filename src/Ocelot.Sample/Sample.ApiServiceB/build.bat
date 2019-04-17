@echo off

cd ../Sample.ApiServiceB

dotnet publish -c Release -o ../publish/Sample.ApiServiceB

cd ../publish/Sample.ApiServiceB

echo "publish success"

