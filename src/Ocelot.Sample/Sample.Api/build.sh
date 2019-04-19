#!/bin/bash
sudo docker stop api.a
sudo docker rm api.a
sudo docker stop api.b
sudo docker rm api.b
sudo docker stop api.c
sudo docker rm api.c

sudo docker rmi api.a

sudo docker build --no-cache -t api.a .
sudo docker run --name=api.a -d -p 5001:6001 -e "ASPNETCORE_URLS=http://+:6001" api.a
sudo docker run --name=api.b -d -p 5002:6002 -e "ASPNETCORE_URLS=http://+:6002" api.a
sudo docker run --name=api.c -d -p 5003:6003 -e "ASPNETCORE_URLS=http://+:6003" api.a