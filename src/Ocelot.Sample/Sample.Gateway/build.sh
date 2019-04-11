#!/bin/bash
echo "123"
sudo docker stop api.gateway
sudo docker rm api.gateway

sudo docker build -t api.a .
sudo docker run --name=api.gateway -d -p 5001:5001 -e "ASPNETCORE_URLS=http://+:5001" api.a