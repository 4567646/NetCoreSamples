#!/bin/bash
sudo docker stop api.a
sudo docker rm api.a
sudo docker stop api.b
sudo docker rm api.b
sudo docker stop api.c
sudo docker rm api.c

sudo docker rmi api.a

sudo docker build --no-cache -t api.a .
sudo docker run --name=api.a -d -p 5001:5001 -e "ASPNETCORE_URLS=http://+:5001" api.a
sudo docker run --name=api.b -d -p 5002:5002 -e "ASPNETCORE_URLS=http://+:5002" api.a
sudo docker run --name=api.c -d -p 5003:5003 -e "ASPNETCORE_URLS=http://+:5003" api.a