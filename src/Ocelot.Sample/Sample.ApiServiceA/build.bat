@echo off

echo "Windows Docker build"

cd ../Sample.ApiServiceA

dotnet publish -c Release -o ../publish/ApiServiceA

cd ../publish/ApiServiceA

echo "publish success"

#docker stop api.a

#docker rm api.a


#docker build -t api.a .
#docker run --name=api.a -p 6000 -d  api.a