#!/bin/bash
echo "123"
sudo docker stop api.a
sudo docker rm api.a

sudo docker build -t api.a .
sudo docker run --name=api.a -d -p 5001:5001 -e "ASPNETCORE_URLS=http://+:5001" api.a