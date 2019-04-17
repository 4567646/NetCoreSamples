@echo off

cd ../Sample.Gateway

dotnet publish -c Release -o ../publish/Sample.Gateway

cd ../publish/Sample.Gateway

echo "publish success"

