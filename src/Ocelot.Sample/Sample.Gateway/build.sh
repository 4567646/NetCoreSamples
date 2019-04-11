#!/bin/bash
sudo docker stop api.gateway
sudo docker rm api.gateway

sudo docker build -t api.gateway .
sudo docker run --name=api.gateway -d -p 5000:5000 -e "ASPNETCORE_URLS=http://+:5000" api.gateway