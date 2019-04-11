#!/bin/bash
echo "123"
sudo docker stop api.c
sudo docker rm api.c

sudo docker build -t api.c .
sudo docker run --name=api.c -d -p 5003:5003 -e "ASPNETCORE_URLS=http://+:5003" api.c