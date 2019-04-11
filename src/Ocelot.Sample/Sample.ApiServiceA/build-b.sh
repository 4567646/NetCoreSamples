#!/bin/bash
echo "123"
sudo docker stop api.b
sudo docker rm api.b

sudo docker build -t api.b .
sudo docker run --name=api.b -d -p 5002:5002 -e "ASPNETCORE_URLS=http://+:5002" api.b